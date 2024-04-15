using DelegationPlugins.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SharedLibrary;
using SharedLibrary.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegationPlugins
{
    public class EndDelegation : JdxPlugin
    {
        public EndDelegation()
        {

            RegisterEvent(PipelineStage.PostOperation, PipelineMessage.Update, Delegation.EntityName, ExcuteSingle);
            RegisterEvent(PipelineStage.PostOperation, PipelineMessage.Delete, Customtrigger.EntityName, ExecuteMultiple);
        }

        /// <summary>
        /// Handle Cancel delegation triggered manully, web api request update status from 0 to 1. 
        /// </summary>
        /// <param name="context"></param>
        private void ExcuteSingle(LocalPluginContext context)
        {
            
            int pre_state = context.PreImage.GetAttributeValue<OptionSetValue>(Common.StateCode).Value;
            int pre_status = context.PreImage.GetAttributeValue<OptionSetValue>(Common.StatusCode).Value;
            int post_state = context.PostImage.GetAttributeValue<OptionSetValue>(Common.StateCode).Value;
            int post_status = context.PreImage.GetAttributeValue<OptionSetValue>(Common.StatusCode).Value;
            // From Delegating to Canceled or Expired
            if (pre_state == 0 && post_state == 1 && pre_status == 952700002)
            {
                context.Trace($"Execute Single Process: delegation canceled manually.");
                Entity target = context.PluginExecutionContext.InputParameters["Target"] as Entity;
                context.Trace($"Retrieved target: {target.Id}.");
                Entity delegation = context.OrganizationService.Retrieve(Delegation.EntityName, target.Id, new ColumnSet(true));
                context.Trace($"Retrieved delegation: {delegation.Id}.");

                OrganizationRequestCollection organizationRequests = new OrganizationRequestCollection();
                DelegationManager delegationManager = new DelegationManager(context);

                organizationRequests.AddRange(delegationManager.CreateLeaveTeamRequests(delegation));
                organizationRequests.AddRange(delegationManager.CreateEndDelegationReassignRequests(delegation));

                delegationManager.ExcuteMultiple(organizationRequests);
            }
        }
        /// <summary>
        /// Handle system schedule jobs for delegation expiry event
        /// </summary>
        /// <param name="context"></param>
        private void ExecuteMultiple(LocalPluginContext context)
        {
            context.Trace($"Execute multiple Processes: delegations expired.");
            #region find all delegating delegations that expiry date are on execution date.
            List<Entity> delegations = context.OrganizationDataContext.CreateQuery(Delegation.EntityName)
                .Where(d => d.GetAttributeValue<DateTime>(Delegation.Effectivedate).Equals(DateTime.Today.AddDays(1)) && d.GetAttributeValue<OptionSetValue>(Common.StatusCode).Value.Equals((int)Delegation.StatusCode_OptionSet.Delegating))
                .ToList();
            #endregion

            DelegationManager delegationManager = new DelegationManager(context);
            OrganizationRequestCollection requests = new OrganizationRequestCollection();


            delegations.ForEach(delegation =>
            {
                requests.AddRange(delegationManager.CreateLeaveTeamRequests(delegation));
                requests.AddRange(delegationManager.CreateEndDelegationReassignRequests(delegation));

            });

            delegationManager.ExcuteMultiple(requests);
        }
    }
}
