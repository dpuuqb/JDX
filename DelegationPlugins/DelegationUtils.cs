using DelegationPlugins.Entities;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegationPlugins
{
    internal static class DelegationUtils
    {
             

        public static void StartDelegating(LocalPluginContext context, Entity delegation)
        {


            DelegationConfig config = null;
            int method = delegation.GetAttributeValue<OptionSetValue>(Delegation.Method).Value;
            EntityReference delegatedUser = delegation.GetAttributeValue<EntityReference>(Delegation.DelegatedUser);
            EntityReference delegatingUser = delegation.GetAttributeValue<EntityReference>(Delegation.DelegatingUser);
            switch (method)
            {
                case 952700000:
                    BuildAddMemberTeamRequests(context, delegatedUser.Id, delegatingUser.Id, out config);
                    break;
                case 952700001:
                    break;
                case 952700002:
                    BuildAddMemberTeamRequests(context, delegatedUser.Id, delegatingUser.Id, out config);
                    break;
                default: throw new ArgumentException("Delegation Method Missing");
            }

            Entity updatedDelegation = new Entity(Delegation.EntityName)
            {
                Id = delegation.Id,
                [Delegation.StatusReason] = new OptionSetValue(952700002),
                [Delegation.ProcessLog] = config.ProcessLog,
                [Delegation.Teams] = config.Teams,
                [Delegation.Roles] = config.Roles
            };

            context.OrganizationService.Update(updatedDelegation);

            //send email notification
            

        }

        


        
        /// <summary>
        /// Build a list of AddMembersTeamRequest
        /// </summary>
        /// <param name="context"></param>
        /// <param name="delegatedUserId"></param>
        /// <param name="delegatingUserId"></param>
        /// <returns></returns>
        public static void BuildAddMemberTeamRequests(LocalPluginContext context, Guid delegatedUserId, Guid delegatingUserId, out DelegationConfig config)
        {
            config = new DelegationConfig()
            {
                ProcessLog = "",
                Teams = ""
            };
            EntityCollection teams_delegated = GetAssociatedTeamsByUser(context, delegatedUserId);
            EntityCollection teams_delegating = GetAssociatedTeamsByUser(context, delegatingUserId);
            
            var teams = teams_delegated.Entities.Where(t1 => teams_delegating.Entities.All(t2 => t1.Id != t2.Id));


            if (teams_delegated.Entities.Any(x => !teams_delegating.Entities.Contains(x)))
            {
                foreach (Entity team in teams)
                {
                    context.Trace($"Delegating User Join Team: {team.GetAttributeValue<string>("name")} : {team.Id}");
                    AddMembersTeamRequest req = new AddMembersTeamRequest();
                    req.TeamId = team.Id;
                    req.MemberIds = new[] { delegatingUserId };

                    AddMembersTeamResponse resp = (AddMembersTeamResponse)context.OrganizationService.Execute(req);
                    
                    config.ProcessLog += string.Format("{0}: Joined Team:{1}.\n\r", DateTime.UtcNow, team.GetAttributeValue<string>("name"));
                    config.Teams += string.Format("{0};", team.GetAttributeValue<string>("name"));


                }

                

                
            }
            
        }
        /// <summary>
        /// Get Teams that given user is associated with
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static EntityCollection GetAssociatedTeamsByUser(LocalPluginContext context, Guid userId)
        {
            var query = new QueryExpression("team");
            query.ColumnSet.AddColumns("name", "teamid", "isdefault", "teamtype", "businessunitid");
            query.Criteria.AddCondition("isdefault", ConditionOperator.Equal, false);
            var query_member = query.AddLink("teammembership", "teamid", "teamid");
            var query_user = query_member.AddLink("systemuser", "systemuserid", "systemuserid");
            query_user.LinkCriteria.AddCondition("systemuserid", ConditionOperator.Equal, userId);
            /*var query = new QueryExpression("teammembership");
            query.Criteria.AddCondition("systemuserid", ConditionOperator.Equal, userId);
            var query_team = query.AddLink("team", "teamid", "teamid");
            query_team.Columns.AddColumns("teamid","name");*/
            return context.OrganizationService.RetrieveMultiple(query);
        }

        

        /// <summary>
        /// The primary purpose of executing multiple requests it so improve performance in high-latency environments by reducing the total volume of data that is transmitted over the network.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requests"></param>
        public static DelegationConfig ExecuteMultipleRequest(LocalPluginContext context, List<AddMembersTeamRequest> requests, DelegationConfig config) {
            ExecuteMultipleRequest requestWithResults = new ExecuteMultipleRequest()
            {
                // Assign settings that define execution behavior: continue on error, return responses. 
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = false,
                    ReturnResponses = true
                },
                // Create an empty organization request collection.
                Requests = new OrganizationRequestCollection()
            };

            // Create several (local, in memory) entities in a collection. 
            

            // Add a CreateRequest for each entity to the request collection.
            foreach (var request in requests)
            {
                
                requestWithResults.Requests.Add(request);
            }

            // Execute all the requests in the request collection using a single web method call.
            ExecuteMultipleResponse responseWithResults =
                (ExecuteMultipleResponse)context.OrganizationService.Execute(requestWithResults);

            // Display the results returned in the responses.
            foreach (var responseItem in responseWithResults.Responses)
            {
                // A valid response.
                if (responseItem.Response != null)
                {
                    
                    context.Trace($"responseItem.Response -- {requestWithResults.Requests[responseItem.RequestIndex]}:{responseItem.Response}");

                }

                // An error has occurred.
                else if (responseItem.Fault != null)
                {
                    context.Trace($"responseItem.Fault -- {requestWithResults.Requests[responseItem.RequestIndex]}:{responseItem.Fault}");
                    config.ProcessLog += string.Format("Process failed : {0}\n\r", responseItem.Fault);
                    config.Teams = "";
                    break;
                }
      
            }

            if (!string.IsNullOrEmpty(config.Teams)) {

                config.ProcessLog += string.Format("Process Succeed on: {0}\n\r", DateTime.UtcNow.ToString());
            }

            return config;

        }

        public static bool UserInTeams(LocalPluginContext context, Guid userId, params string[] teamNames)
        {
            var query = new QueryExpression("teammembership");
            query.TopCount = 1;
            query.Criteria.AddCondition("systemuserid", ConditionOperator.Equal, userId);

            var query_role = query.AddLink("team", "teamid", "teamid");
            query_role.LinkCriteria.AddCondition("name", ConditionOperator.In, teamNames);

            var result = context.OrganizationService.RetrieveMultiple(query);
            return result.Entities.Any();
        }

        public static void EndDelegating(LocalPluginContext context, Entity delegation)
        {
            DelegationConfig config = new DelegationConfig() { 
                ProcessLog = delegation.GetAttributeValue<string>(Delegation.ProcessLog),
                Teams = delegation.GetAttributeValue<string>(Delegation.Teams),
                Roles = delegation.GetAttributeValue<string>(Delegation.Roles)
            };

            EntityReference delegatingUser = delegation.GetAttributeValue<EntityReference>(Delegation.DelegatingUser);
            string[] teamNames = config.Teams.Split(';');
            if (UserInTeams(context, delegatingUser.Id, teamNames))
            {
                foreach (string teamName in teamNames) {

                    RemoveMembersTeamRequest request = new RemoveMembersTeamRequest()
                    {
                        TeamId = context.OrganizationDataContext.CreateQuery("team").Where(t => t.GetAttributeValue<string>("name").Equals(teamName)).Select(t => t.GetAttributeValue<Guid>("teamid")).First(),
                        MemberIds = new[] { delegatingUser.Id }
                    };

                    context.OrganizationService.Execute(request);
                    config.ProcessLog += string.Format("{0}: {1} leave Team:{2}.\n\r", DateTime.UtcNow.ToString(), delegatingUser.Name, teamName);
                }
                
            }


        }
        
    }
}
