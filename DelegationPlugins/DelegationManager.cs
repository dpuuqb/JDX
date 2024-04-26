using DelegationPlugins.Entities;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;


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
        public OrganizationRequestCollection CreateJoinTeamRequests(Delegation delegation)
        {
            tsv.Trace("-- CreateJoinTeamRequests --");
            OrganizationRequestCollection organizationRequests = new OrganizationRequestCollection();
            Guid ownerId = delegation.DelegatedUser.Value;
            Guid newOwnerId = delegation.DelegatingUser.Value;

            EntityCollection result = GetAssociatedTeamsByUser(ownerId);
            List<string> teamNames = new List<string>();
            foreach (Team team in result.Entities)
            {
                organizationRequests.Add(RequestBuilder.BuildTeamMemberAssociateRequest(team.Id, newOwnerId));
                
                teamNames.Add(team.TeamName);
            }

            Delegation update = new Delegation
            {
                Id = delegation.Id,
                StatusReason = Delegation.StatusReasonEnum.Delegating,
                Teams = string.Join(";", teamNames)
            };

           
            organizationRequests.Add(RequestBuilder.BuildUpdateRequest(update));

            return organizationRequests;
        }
        /// <summary>
        /// Create OrganizationRequestCollection for leave team request using RequestBuilder
        /// </summary>
        /// <param name="delegation"></param>
        /// <returns></returns>
        public OrganizationRequestCollection CreateLeaveTeamRequests(Delegation delegation, Delegation.StatusReasonEnum statusReason)
        {
            OrganizationRequestCollection organizationRequests = new OrganizationRequestCollection();
            Guid ownerId = delegation.DelegatedUser.Value;
            Guid newOwnerId = delegation.DelegatingUser.Value;
            
            
            string[] result = GetAssociatingTeamsByDelegation(delegation);
            string[]  allFutureDelegatingTeams = GetAllFutureDelegatingTeamsByUser(delegation.DelegatingUser.Value);
           

            if (result is null) return organizationRequests;
            else 
            {

                EntityCollection actualOwningTeams = GetAssociatedTeamsByUser(newOwnerId);

                // for each team in the associated teammembership of current delegating user
                // remove the delegating user from the team if team Id is matching and not belongs to other delegating teams that are going to be removed in the future.
                foreach (string teamName in result)
                {
                    Entity team = svc.CreateQuery(Team.EntityLogicalName).Where(t => t.GetAttributeValue<string>(Team.Fields.TeamName).Equals(teamName)).First();

                    if (allFutureDelegatingTeams != null && allFutureDelegatingTeams.Length > 0)
                    {
                        if (actualOwningTeams.Entities.Any(t => t.Id.Equals(team.Id) && !allFutureDelegatingTeams.Any(s => s.Contains(t.GetAttributeValue<string>(Team.Fields.TeamName))))) organizationRequests.Add(RequestBuilder.BuildRemoveMembersTeamRequest(team.Id, newOwnerId));

                    }
                    else {
                        if (actualOwningTeams.Entities.Any(t => t.Id.Equals(team.Id))) organizationRequests.Add(RequestBuilder.BuildRemoveMembersTeamRequest(team.Id, newOwnerId));
                    }
                }
 

            }
            //expiry triggered
            if (statusReason.Equals(Delegation.StatusReasonEnum.Expired))
            {
                Delegation update = new Delegation
                {
                    Id = delegation.Id,
                    Status = Delegation.StatusEnum.Inactive,
                    StatusReason = Delegation.StatusReasonEnum.Expired
                };
                organizationRequests.Add(RequestBuilder.BuildUpdateRequest(update));
            }
           

            
            
            return organizationRequests;
        }
        /// <summary>
        /// Create OrganizationRequestCollection for Reassigning records when delegation starts.
        /// </summary>
        /// <param name="delegation"></param>
        /// <returns></returns>
        public OrganizationRequestCollection CreateStartDelegationReassignRequests(Delegation delegation)
        {
            tsv.Trace("-- CreateStartDelegationReassignRequests --");
            OrganizationRequestCollection organizationRequests = new OrganizationRequestCollection();
            Guid ownerId = delegation.DelegatedUser.Value;
            Guid newOwnerId = delegation.DelegatingUser.Value;

            EntityCollection configs = QueryReassignConfigurations(delegation);
            foreach (Entity entity in configs.Entities)
            {
                DelegationReassignConfiguration config = entity as DelegationReassignConfiguration;
                List<Entity> result = QueryReassignRecords(config, ownerId);
                tsv.Trace($"After filter on owner: {result.Count} records remains.");
                result.ForEach(e =>
                {
                    Entity create = new Entity(DelegationReassignRecord.EntityLogicalName)
                    {
                        
                        Attributes = {
                            { DelegationReassignRecord.Fields.EntityName, e.LogicalName},
                            { DelegationReassignRecord.Fields.Guid, e.Id.ToString()},
                            { DelegationReassignRecord.Fields.RecordLink, GetRecordLink(e.LogicalName, e.Id)},
                            { DelegationReassignRecord.Fields.Delegation, new EntityReference(Delegation.EntityLogicalName, delegation.Id)}
                        }
                    };

                    Entity update = new Entity(e.LogicalName)
                    {
                        Id = e.Id,
                        Attributes = {
                            {"ownerid", new EntityReference(User.EntityLogicalName, newOwnerId)}
                        }
                    };

                    organizationRequests.Add(RequestBuilder.BuildCreateRequest(create));
                    organizationRequests.Add(RequestBuilder.BuildUpdateRequest(update));
                });
            }
            return organizationRequests;
        }

        private string GetRecordLink(string entityType, Guid id, string applicationId = "")
        {
            var request = new RetrieveCurrentOrganizationRequest();
            var response = (RetrieveCurrentOrganizationResponse)sv.Execute(request);
            if (response != null)
            {
                
                string webApplication = response.Detail.Endpoints.First().Value;
                string partialUrl = webApplication.Substring(webApplication.IndexOf('.'));
                string webUrl = webApplication.Substring(0, 8) + partialUrl.Split('/')[1] + partialUrl.Split('/')[0];
                string mainAspx = "/main.aspx?";

                string appId = string.IsNullOrEmpty(applicationId)? "":"appid=" + applicationId + "&";
                // localPluginContext.Trace($"Endpoints: {String.Join(", ", response.Detail.Endpoints.Select(e => String.Concat(e.Key, ": ", e.Value)))}");
                return webUrl + mainAspx + appId + "pagetype=entityrecord&etn=" + entityType + "&id=" + id.ToString();
            }
            return null;
        }

        /// <summary>
        /// Create OrganizationRequestCollection for Reassigning records when delegation ends.
        /// </summary>
        /// <param name="delegation"></param>
        /// <returns></returns>
        public OrganizationRequestCollection CreateEndDelegationReassignRequests(Delegation delegation)
        {
            OrganizationRequestCollection organizationRequests = new OrganizationRequestCollection();
            Guid ownerId = delegation.DelegatedUser.Value;
            Guid newOwnerId = delegation.DelegatingUser.Value;
            List<Entity> result = svc.CreateQuery(DelegationReassignRecord.EntityLogicalName).Where(e=>e.GetAttributeValue<EntityReference>(DelegationReassignRecord.Fields.Delegation).Id.Equals(delegation.Id)).ToList();

            result.ForEach(e =>
            {
                Entity update = new Entity(e.GetAttributeValue<string>(DelegationReassignRecord.Fields.EntityName))
                {
                    Id = new Guid(e.GetAttributeValue<string>(DelegationReassignRecord.Fields.Guid)),
                    Attributes =
                    {
                        {"ownerid", new EntityReference(User.EntityLogicalName, ownerId)}
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
        public List<Entity> QueryReassignRecords(DelegationReassignConfiguration reassignConfig, Guid ownerId)
        {
            tsv.Trace("-- QueryReassignRecords --");
            string entityName = reassignConfig.EntityName;
            string filter = reassignConfig.Filter;

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
        public EntityCollection QueryReassignConfigurations(Delegation delegation)
        {
            QueryExpression query = new QueryExpression(DelegationReassignConfiguration.EntityLogicalName)
            {
                ColumnSet = new ColumnSet(true),
                LinkEntities = {
                    new LinkEntity(DelegationReassignConfiguration.EntityLogicalName, "jms_jms_delegationreassignconfiguration_jms", DelegationReassignConfiguration.Fields.DelegationReassignConfigurationId, DelegationReassignConfiguration.Fields.DelegationReassignConfigurationId, JoinOperator.Inner)
                    {
                        LinkCriteria =
                        {
                            Filters =
                            {
                                new FilterExpression(){
                                    Conditions =  {
                                        new ConditionExpression()
                                        {
                                            AttributeName = Delegation.Fields.DelegationId,
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
        public string[] GetAssociatingTeamsByDelegation(Delegation delegation)
        {
            string str_teams = delegation.Teams;
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
        /// query an array of delegating team names from given delegation record.
        /// </summary>
        /// <param name="delegation"></param>
        /// <returns></returns>
        public string[] GetAssociatingRolesByDelegation(Delegation delegation)
        {
            string str_roles = delegation.Roles;
            if (string.IsNullOrEmpty(str_roles) || string.IsNullOrWhiteSpace(str_roles))
            {
                tsv.Trace($"Get no Roles.");
                return null;

            }
            else
            {
                tsv.Trace($"Get Teams:{str_roles}");
                return str_roles.Split(';');
            }


        }
        /// <summary>
        /// Add l
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string[] GetAllFutureDelegatingTeamsByUser(Guid userId)
        {
            return svc.CreateQuery(Delegation.EntityLogicalName)
                    .Where(d => d.GetAttributeValue<OptionSetValue>(Delegation.Fields.StatusReason).Value.Equals((int)Delegation.StatusReasonEnum.Delegating) 
                                && d.GetAttributeValue<EntityReference>(Delegation.Fields.DelegatingUser).Id.Equals(userId)
                                && d.GetAttributeValue<DateTime>(Delegation.Fields.ExpiryDate) > DateTime.Today)
                    .Select(d=>d.GetAttributeValue<string>(Delegation.Fields.Teams))
                    .ToArray();

            
        }
        public OrganizationRequestCollection CreateRoleAssociateRequests(Delegation delegation)
        {
            tsv.Trace("-- CreateRoleAssociateRequests --");
            OrganizationRequestCollection organizationRequests = new OrganizationRequestCollection();
            Guid ownerId = delegation.DelegatedUser.Value;
            Guid newOwnerId = delegation.DelegatingUser.Value;
            User user = sv.Retrieve(User.EntityLogicalName, newOwnerId, new ColumnSet(User.Fields.BusinessUnit)).ToEntity<User>();
            //get delegated user roles with Name, root, business unit.
            EntityCollection roles = GetAssociatedRolesByUser(ownerId);
            EntityCollection currentRoles = GetAssociatedRolesByUser(newOwnerId);
            List<string> roleNames = new List<string>();
            foreach (SecurityRole role in roles.Entities)
            {
                //check role Name
                if (!currentRoles.Entities.Any(e => e.GetAttributeValue<string>(SecurityRole.Fields.Name).Equals(role.Name)))
                {
                    //check rootRole and business unit
                    EntityCollection givingRoles = GetRoleMatchNameAndBusinessUnit(role.ParentRole, user.BusinessUnit);

                    if (givingRoles.Entities.Count > 0) {

                        //create request to assign to new user
                        organizationRequests.Add(RequestBuilder.BuildUserRoleAssociateRequest(givingRoles.Entities[0].Id, newOwnerId));
                        roleNames.Add(role.Name);
                    }
                    
                }

            }

            Delegation update = new Delegation
            {
                Id = delegation.Id,
                StatusReason = Delegation.StatusReasonEnum.Delegating,
                Roles = string.Join(";", roleNames)
            };


            organizationRequests.Add(RequestBuilder.BuildUpdateRequest(update));

            return organizationRequests;
        }


        public OrganizationRequestCollection CreateRoleDisassociateRequests(Delegation delegation, Delegation.StatusReasonEnum statusReason)
        {
            tsv.Trace("-- CreateRoleDisassociateRequests --");
            OrganizationRequestCollection organizationRequests = new OrganizationRequestCollection();
            
            Guid newOwnerId = delegation.DelegatingUser.Value;
            String[] roleNames = GetAssociatingRolesByDelegation(delegation);
            User user = sv.Retrieve(User.EntityLogicalName, newOwnerId, new ColumnSet(User.Fields.BusinessUnit)).ToEntity<User>();
            EntityCollection result = GetAssociatedRolesByUser(newOwnerId);

            foreach (Entity role in result.Entities)
            {
                if (roleNames.Any(r => r.Equals(role.GetAttributeValue<string>(SecurityRole.Fields.Name))))
                {
                    organizationRequests.Add(RequestBuilder.BuildUserRoleDisassociateRequest(role.Id, newOwnerId));
                } 
            }
            //expiry triggered
            if (statusReason.Equals(Delegation.StatusReasonEnum.Expired))
            {
                Delegation update = new Delegation
                {
                    Id = delegation.Id,
                    Status = Delegation.StatusEnum.Inactive,
                    StatusReason = Delegation.StatusReasonEnum.Expired
                };
                organizationRequests.Add(RequestBuilder.BuildUpdateRequest(update));
            }

            return organizationRequests;

        }

        public EntityCollection GetRoleMatchNameAndBusinessUnit(Guid? entRootRoleId, Guid? businessUnitId)
        {

            if (entRootRoleId == null || entRootRoleId == Guid.Empty || businessUnitId == null || businessUnitId == Guid.Empty) {
                throw new InvalidPluginExecutionException("[GetRoleMatchNameAndBusinessUnit]: entRootRoleId or businessUnitId missing.");
            }

            QueryExpression query = new QueryExpression
            {
                EntityName = "role",
                ColumnSet = new ColumnSet("roleid"),
                Criteria = new FilterExpression
                {
                    Conditions =
                        {

                            new ConditionExpression
                            {
                                AttributeName = "parentrootroleid",
                                Operator = ConditionOperator.Equal,
                                Values = { entRootRoleId}
                            },
                            new ConditionExpression
                            {
                                AttributeName = "businessunitid",
                                Operator = ConditionOperator.Equal,
                                Values = { businessUnitId}
                            }
                        }
                }
            };

            return sv.RetrieveMultiple(query);
        }

        public EntityCollection GetAssociatedRolesByUser(Guid ownerId)
        {
            QueryExpression query = new QueryExpression
            {
                EntityName = "role",
                ColumnSet = new ColumnSet(SecurityRole.Fields.Name, SecurityRole.Fields.ParentRootRole, SecurityRole.Fields.BusinessUnit),
                LinkEntities =
                {
                    new LinkEntity(SecurityRole.EntityLogicalName, SystemUserRoles.EntityLogicalName, SecurityRole.Fields.RoleId, SystemUserRoles.Fields.RoleId, JoinOperator.Inner)
                    {
                        LinkCriteria =
                        {
                            Filters =
                            {
                                new FilterExpression() {
                                    Conditions = {
                                        new ConditionExpression()
                                        {
                                            AttributeName = SystemUserRoles.Fields.SystemUserId,
                                            Operator = ConditionOperator.Equal,
                                            Values =
                                            {
                                                ownerId
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
            };
            return sv.RetrieveMultiple(query);
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
            /*//transform request to asynchornous to avoid "Cannot obtain lock on resource" on delegation row.
            OrganizationRequestCollection asyncReqs = new OrganizationRequestCollection();
            foreach (OrganizationRequest request in requests)
            {
                ExecuteAsyncRequest asyncReq = new ExecuteAsyncRequest()
                {
                    Request = request
                };
                asyncReqs.Add(asyncReq);
            }*/
            
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
        

        public bool SendEmailFromTemplate(Delegation delegation, bool isStart)
        {
            Guid fromUserId = delegation.GetAttributeValue<EntityReference>("createdby").Id;
            Guid ToUserId = delegation.DelegatingUser.Value;
            
            List<Entity> fromEntities = new List<Entity>();
            List<Entity> toEntities = new List<Entity>();
            Entity fromParty = new Entity();
            fromParty.LogicalName = "activityparty";
            fromParty.Attributes["partyid"] = new EntityReference("systemuser", fromUserId);
            fromEntities.Add(fromParty);
            Entity toParty = new Entity();
            toParty.LogicalName = "activityparty";
            toParty.Attributes["partyid"] = new EntityReference("systemuser", ToUserId);
            toEntities.Add(toParty);

            var alsoNotify = delegation.GetAttributeValue<EntityReference>("jms_alsonotifyuser");
            if (alsoNotify != null && alsoNotify.Id != null) {
                Entity activityParty = new Entity();
                activityParty.LogicalName = "activityparty";
                activityParty.Attributes["partyid"] = new EntityReference("systemuser", alsoNotify.Id);
                toEntities.Add(activityParty);
            }

            Entity email = new Entity("email");
            email.Attributes["from"] = fromEntities.ToArray();
            email.Attributes["to"] = toEntities.ToArray();

            SendEmailFromTemplateRequest emailUsingTemplateReq = new SendEmailFromTemplateRequest
            {
                Target = email,

                // Use a built-in Email Template of type "jms_delegation".
                TemplateId = svc.CreateQuery("template").Where(t => t.GetAttributeValue<string>("title").Equals(isStart?"Delegation Notification - Start":"Delegation Notification - End")).First().Id,

                // The regarding Id is required, and must be of the same type as the Email Template.
                RegardingId = delegation.Id,
                RegardingType = "jms_delegation"
            };

            SendEmailFromTemplateResponse emailUsingTemplateResp = (SendEmailFromTemplateResponse)sv.Execute(emailUsingTemplateReq);


            return true;
        }

    }
}
