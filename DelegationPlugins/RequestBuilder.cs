using DelegationPlugins.Entities;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;


namespace DelegationPlugins
{
    internal static class RequestBuilder
    {
        public static OrganizationRequest BuildCreateRequest(Entity create) 
        {
            CreateRequest createRequest = new CreateRequest()
            {

                Target = create
            };

            // Expect error if duplicate record found
            //createRequest["SuppressDuplicateDetection"] = false;
            // Set a shared variable that a plug-in can access
            //createRequest["tag"] = "RecordCreatedByDelegation";
            // Bypass plug-in logic if caller has prvBypassCustomPlugins privilege
            //createRequest["BypassCustomPluginExecution"] = true;
            // Don't trigger any flows for this operation
            //createRequest["SuppressCallbackRegistrationExpanderJob"] = true;

            return createRequest;
        }

        

        public static OrganizationRequest BuildUpdateRequest(Entity target)
        {
            UpdateRequest updateRequest = new UpdateRequest()
            {
                Target = target,
                // The operation will fail if the record is 
                // updated in the period since it was retrieved.
                ConcurrencyBehavior = ConcurrencyBehavior.AlwaysOverwrite
            };

            // Expect error if duplicate record found
            //updateRequest["SuppressDuplicateDetection"] = false;
            // Set a shared variable that a plug-in can access
           //updateRequest["tag"] = "RecordUpdatedByDelegation";
            // Bypass plug-in logic if caller has prvBypassCustomPlugins privilege
            //updateRequest["BypassCustomPluginExecution"] = true;
            // Don't trigger any flows for this operation
            //updateRequest["SuppressCallbackRegistrationExpanderJob"] = true;

            return updateRequest;
        }

        

        public static OrganizationRequest BuildDeleteRequest(EntityReference target)
        {
            DeleteRequest deleteRequest = new DeleteRequest()
            {
                Target = target,
                ConcurrencyBehavior = ConcurrencyBehavior.AlwaysOverwrite
            };

            

            return deleteRequest;
        }

       

        public static OrganizationRequest BuildAssociateRequest(Guid teamId, Guid userId)
        {
            AddMembersTeamRequest addMembersTeamRequest = new AddMembersTeamRequest() 
            {
                TeamId = teamId,
                MemberIds = new[] { userId }
            };
            return addMembersTeamRequest;
        }

        public static OrganizationRequest BuildRemoveMembersTeamRequest(Guid teamId, Guid userId)
        {
            RemoveMembersTeamRequest removeMembersTeamRequest = new RemoveMembersTeamRequest()
            {
                TeamId = teamId,
                MemberIds = new[] { userId }
            };
            return removeMembersTeamRequest;
        }

        
    }
}
