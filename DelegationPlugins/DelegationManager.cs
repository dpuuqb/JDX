using DelegationPlugins.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DelegationPlugins
{
    internal class DelegationManager
    {
        public readonly static int MAX_REQUESTS = 1000;
        IOrganizationService sv;
        ITracingService tsv;
        OrganizationServiceContext svc;

        /// <summary>
        /// Customized Constructor
        /// </summary>
        /// <param name="context"></param>
        public DelegationManager(LocalPluginContext context) {
            sv = context.OrganizationService;
            tsv = context.TracingService;
            svc = context.OrganizationDataContext;
        }
        /// <summary>
        /// Create OrganizationRequestCollection for join team request using RequestBuilder
        /// </summary>
        /// <param name="delegation"></param>
        /// <returns></returns>
        public OrganizationRequestCollection CreateJoinTeamRequests(Entity delegation)
        {
            tsv.Trace("-- CreateJoinTeamRequests --");
            OrganizationRequestCollection organizationRequests = new OrganizationRequestCollection();
            Guid ownerId = delegation.GetAttributeValue<EntityReference>(Delegation.Delegated).Id;
            Guid newOwnerId = delegation.GetAttributeValue<EntityReference>(Delegation.Delegating).Id;
            
            EntityCollection result = GetAssociatedTeamsByUser(ownerId);
            List<string> teamNames = new List<string>();
            foreach (Entity team in result.Entities)
            {
                organizationRequests.Add(RequestBuilder.BuildAssociateRequest(team.Id, newOwnerId));
                teamNames.Add(team.GetAttributeValue<string>(Team.PrimaryName));
            }

            Entity update = new Entity(Delegation.EntityName) {
                Id = delegation.Id,
                Attributes = {
                    [Common.StatusCode] = new OptionSetValue((int)Delegation.StatusCode_OptionSet.Delegating),
                    [Delegation.TeamS] = string.Join(";", teamNames)
                }
            };
            organizationRequests.Add(RequestBuilder.BuildUpdateRequest(update));

            return organizationRequests;
        }
        /// <summary>
        /// Create OrganizationRequestCollection for leave team request using RequestBuilder
        /// </summary>
        /// <param name="delegation"></param>
        /// <returns></returns>
        public OrganizationRequestCollection CreateLeaveTeamRequests(Entity delegation)
        {
            OrganizationRequestCollection organizationRequests = new OrganizationRequestCollection();
            Guid ownerId = delegation.GetAttributeValue<EntityReference>(Delegation.Delegated).Id;
            Guid newOwnerId = delegation.GetAttributeValue<EntityReference>(Delegation.Delegating).Id;
            OptionSetValue statusReason = delegation.GetAttributeValue<OptionSetValue>(Common.StatusCode);
            
            string[] result = GetAssociatingTeamsByDelegation(delegation);
            string[]  allFutureDelegatingTeams = GetAllFutureDelegatingTeamsByUser(delegation.GetAttributeValue<EntityReference>(Delegation.Delegating).Id);
           

            if (result is null) return organizationRequests;
            else 
            {

                EntityCollection actualOwningTeams = GetAssociatedTeamsByUser(newOwnerId);

                // for each team in the associated teammembership of current delegating user
                // remove the delegating user from the team if team Id is matching and not belongs to other delegating teams that are going to be removed in the future.
                foreach (string teamName in result)
                {
                    Entity team = svc.CreateQuery(Team.EntityName).Where(t => t.GetAttributeValue<string>(Team.PrimaryName).Equals(teamName)).First();

                    if (allFutureDelegatingTeams != null && allFutureDelegatingTeams.Length > 0)
                    {
                        if (actualOwningTeams.Entities.Any(t => t.Id.Equals(team.Id) && !allFutureDelegatingTeams.Any(s => s.Contains(t.GetAttributeValue<string>(Team.PrimaryName))))) organizationRequests.Add(RequestBuilder.BuildRemoveMembersTeamRequest(team.Id, newOwnerId));

                    }
                    else {
                        if (actualOwningTeams.Entities.Any(t => t.Id.Equals(team.Id))) organizationRequests.Add(RequestBuilder.BuildRemoveMembersTeamRequest(team.Id, newOwnerId));
                    }
                }

                //expiry triggered
                if (statusReason.Equals(Delegation.StatusCode_OptionSet.Delegating))
                {
                    Entity update = new Entity(Delegation.EntityName)
                    {
                        Id = delegation.Id,
                        Attributes = {
                        [Common.StateCode] = new OptionSetValue(1),
                        [Common.StatusCode] = new OptionSetValue((int)Delegation.StatusCode_OptionSet.Expired)
                }
                    };
                    organizationRequests.Add(RequestBuilder.BuildUpdateRequest(update));
                }


                return organizationRequests;

            }
            
        }
        /// <summary>
        /// Create OrganizationRequestCollection for Reassigning records when delegation starts.
        /// </summary>
        /// <param name="delegation"></param>
        /// <returns></returns>
        public OrganizationRequestCollection CreateStartDelegationReassignRequests(Entity delegation)
        {
            tsv.Trace("-- CreateStartDelegationReassignRequests --");
            OrganizationRequestCollection organizationRequests = new OrganizationRequestCollection();
            Guid ownerId = delegation.GetAttributeValue<EntityReference>(Delegation.Delegated).Id;
            Guid newOwnerId = delegation.GetAttributeValue<EntityReference>(Delegation.Delegating).Id;

            EntityCollection configs = QueryReassignConfigurations(delegation);
            foreach (Entity config in configs.Entities)
            {
                List<Entity> result = QueryReassignRecords(config, ownerId);
                tsv.Trace($"After filter on owner: {result.Count} records remains.");
                result.ForEach(e =>
                {
                    Entity create = new Entity(Delegationreassignrecord.EntityName)
                    {
                        Attributes = {
                            { Delegationreassignrecord.EntityType, e.LogicalName},
                            { Delegationreassignrecord.GuId, e.Id.ToString()},
                            { Delegationreassignrecord.Delegation, new EntityReference(Delegation.EntityName, delegation.Id)}
                        }
                    };

                    Entity update = new Entity(e.LogicalName)
                    {
                        Id = e.Id,
                        Attributes = {
                            {"ownerid", new EntityReference(User.EntityName, newOwnerId)}
                        }
                    };

                    organizationRequests.Add(RequestBuilder.BuildCreateRequest(create));
                    organizationRequests.Add(RequestBuilder.BuildUpdateRequest(update));
                });
            }
            return organizationRequests;
        }
        /// <summary>
        /// Create OrganizationRequestCollection for Reassigning records when delegation ends.
        /// </summary>
        /// <param name="delegation"></param>
        /// <returns></returns>
        public OrganizationRequestCollection CreateEndDelegationReassignRequests(Entity delegation)
        {
            OrganizationRequestCollection organizationRequests = new OrganizationRequestCollection();
            Guid ownerId = delegation.GetAttributeValue<EntityReference>(Delegation.Delegated).Id;
            Guid newOwnerId = delegation.GetAttributeValue<EntityReference>(Delegation.Delegating).Id;
            List<Entity> result = svc.CreateQuery(Delegationreassignrecord.EntityName).Where(e=>e.GetAttributeValue<EntityReference>(Delegationreassignrecord.Delegation).Id.Equals(delegation.Id)).ToList();

            result.ForEach(e =>
            {
                Entity update = new Entity(e.GetAttributeValue<string>(Delegationreassignrecord.EntityType))
                {
                    Id = new Guid(e.GetAttributeValue<string>(Delegationreassignrecord.GuId)),
                    Attributes =
                    {
                        {"ownerid", new EntityReference(User.EntityName, ownerId)}
                    }
                };

               

                organizationRequests.Add(RequestBuilder.BuildUpdateRequest(update));

                //keep as history records

                //EntityReference delete = new EntityReference(e.LogicalName, e.Id);
                //organizationRequests.Add(RequestBuilder.BuildDeleteRequest(delete));

            });
        
            return organizationRequests;
        }
        /// <summary>
        /// Query reassigning records based on configuration and owner Id.
        /// </summary>
        /// <param name="reassignConfig"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public List<Entity> QueryReassignRecords(Entity reassignConfig, Guid ownerId)
        {
            tsv.Trace("-- QueryReassignRecords --");
            string entityName = reassignConfig.GetAttributeValue<string>(DelegationreassignConfiguration.EntityType);
            string filter = reassignConfig.GetAttributeValue<string>(DelegationreassignConfiguration.Filter);

            string queryRecords = $@"<fetch> <entity name='{entityName}'><attribute name='ownerid'/>{filter}</entity></fetch>";
            EntityCollection records = sv.RetrieveMultiple(new FetchExpression(queryRecords));
            tsv.Trace($"Obtained {records.Entities.Count} records.");
            return records.Entities.Where(r => r.GetAttributeValue<EntityReference>("ownerid").Id == ownerId).ToList();
        }
        /// <summary>
        /// Query associated configurations through M:N relationship entity: jms_jms_delegationreassignconfiguration_jms
        /// </summary>
        /// <param name="delegation"></param>
        /// <returns></returns>
        public EntityCollection QueryReassignConfigurations(Entity delegation)
        {
            QueryExpression query = new QueryExpression(DelegationreassignConfiguration.EntityName)
            {
                ColumnSet = new ColumnSet(true),
                LinkEntities = {
                    new LinkEntity(Delegationreassignrecord.EntityName, "jms_jms_delegationreassignconfiguration_jms", DelegationreassignConfiguration.PrimaryKey, DelegationreassignConfiguration.PrimaryKey, JoinOperator.Inner)
                    {
                        LinkCriteria =
                        {
                            Filters =
                            {
                                new FilterExpression(){
                                    Conditions =  {
                                        new ConditionExpression()
                                        {
                                            AttributeName = Delegation.PrimaryKey,
                                            Operator = ConditionOperator.Equal,
                                            Values =
                                            {
                                                delegation.Id
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },

                },
            };
            return sv.RetrieveMultiple(query);

        }
        /// <summary>
        /// Query associated teams for a specific user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public EntityCollection GetAssociatedTeamsByUser(Guid userId)
        {
            var query = new QueryExpression("team");
            query.ColumnSet.AddColumns("name", "teamid", "isdefault", "teamtype", "businessunitid");
            query.Criteria.AddCondition("isdefault", ConditionOperator.Equal, false);
            var query_member = query.AddLink("teammembership", "teamid", "teamid");
            var query_user = query_member.AddLink("systemuser", "systemuserid", "systemuserid");
            query_user.LinkCriteria.AddCondition("systemuserid", ConditionOperator.Equal, userId);
           
            return sv.RetrieveMultiple(query);
        }
        /// <summary>
        /// query an array of delegating team names from given delegation record.
        /// </summary>
        /// <param name="delegation"></param>
        /// <returns></returns>
        public string[] GetAssociatingTeamsByDelegation(Entity delegation)
        {
            string str_teams = delegation.GetAttributeValue<string>(Delegation.TeamS);
            if (string.IsNullOrEmpty(str_teams) || string.IsNullOrWhiteSpace(str_teams))
            {
                tsv.Trace($"Get no Teams.");
                return null;
                
            }
            else {
                tsv.Trace($"Get Teams:{str_teams}");
                return str_teams.Split(';');
            }


        }
         /// <summary>
        /// Additional logic: retrieve all delegating teams by one user in case of a team was associated from multiple delegations
        /// followup with cancel/expiry logic where keeping this team until the latest delegation getting canceled or expired.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string[] GetAllFutureDelegatingTeamsByUser(Guid userId)
        {
            return svc.CreateQuery(Delegation.EntityName)
                    .Where(d => d.GetAttributeValue<OptionSetValue>(Common.StatusCode).Value.Equals((int)Delegation.StatusCode_OptionSet.Delegating) 
                                && d.GetAttributeValue<EntityReference>(Delegation.Delegating).Id.Equals(userId)
                                && d.GetAttributeValue<DateTime>(Delegation.Expirydate) > DateTime.Today)
                    .Select(d=>d.GetAttributeValue<string>(Delegation.TeamS))
                    .ToArray();

            
        }
        /// <summary>
        /// Allocately execute multiple requests.
        /// Conditions: 
        ///     tranaction timeOut limit= 2 minutes; 
        ///         Maximum of each call = 1000 requests; 
        ///             2 ExecuteMultipleRequest at most in concurrently
        /// </summary>
        /// <param name="requests"></param>
        /// <exception cref="InvalidPluginExecutionException"></exception>
        public void ExcuteMultiple(OrganizationRequestCollection requests)
        {
            if (requests.Count <= MAX_REQUESTS)
            {

                ExecuteMultipleRequest(requests);
            }

            else if (requests.Count <= MAX_REQUESTS * 2)
            {
                OrganizationRequestCollection first = (OrganizationRequestCollection)requests.Take(1000);
                OrganizationRequestCollection second = (OrganizationRequestCollection)requests.Skip(1000);
                ExecuteMultipleRequest(first);
                ExecuteMultipleRequest(second);
                tsv.Trace($"{DateTime.UtcNow.ToString()}: Execute Multiple Request for Delegations expiry today");

            }
            else
            {

                throw new InvalidPluginExecutionException($"Too many Requests! Please contact Service Administrator.");

            }
        }
        /// <summary>
        /// ExecuteMultipleRequest as sub-method
        /// </summary>
        /// <param name="requests"></param>
        public void ExecuteMultipleRequest(OrganizationRequestCollection requests)
        {

            ExecuteMultipleRequest requestWithResults = new ExecuteMultipleRequest()
            {
                // Assign settings that define execution behavior: continue on error, return responses. 
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                // Create an empty organization request collection.
                Requests = requests
            };

           


            // Execute all the requests in the request collection using a single web method call.
            ExecuteMultipleResponse responseWithResults =
                (ExecuteMultipleResponse)sv.Execute(requestWithResults);

            // Display the results returned in the responses.
            foreach (var responseItem in responseWithResults.Responses)
            {
                // A valid response.
                if (responseItem.Response != null)
                {
                    tsv.Trace($"responseItem.Response -- {requestWithResults.Requests[responseItem.RequestIndex]}:{responseItem.Response}");
                }

                // An error has occurred.
                else if (responseItem.Fault != null)
                {
                    tsv.Trace($"responseItem.Fault -- {requestWithResults.Requests[responseItem.RequestIndex]}:{responseItem.Fault}");

                }

            }

            

            


        }
    }
}
