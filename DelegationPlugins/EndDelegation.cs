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
    public class EndDelegation: JdxPlugin
    {
        public EndDelegation() {

            RegisterEvent(PipelineStage.PostOperation, PipelineMessage.Update, Delegation.EntityName, ExcuteSingle);
            RegisterEvent(PipelineStage.PostOperation, PipelineMessage.Delete, CustomTrigger.EntityName, ExecuteMultiple);
        }

        /// <summary>
        /// Handle Cancel delegation triggered manully, web api request update status from 0 to 1. 
        /// </summary>
        /// <param name="context"></param>
        private void ExcuteSingle(LocalPluginContext context)
        {
            context.Trace($"Execute Single Process: delegation canceled manually.");
            int pre_status = context.PreImage.GetAttributeValue<OptionSetValue>(Delegation.Status).Value;
            int post_status = context.PostImage.GetAttributeValue<OptionSetValue>(Delegation.Status).Value;

            if (pre_status == 0 && post_status == 1) 
            {
                Entity target = context.PluginExecutionContext.InputParameters["Target"] as Entity;
                context.Trace($"Retrieved target: {target.Id}.");
                Entity delegation = context.OrganizationService.Retrieve(Delegation.EntityName, target.Id, new ColumnSet(true));
                context.Trace($"Retrieved delegation: {delegation.Id}.");
               
                DelegationUtils.EndDelegating(context, delegation);
               
            }
        }

        private void ExecuteMultiple(LocalPluginContext context)
        {
            context.Trace($"Execute multiple Processes: delegations expired.");
            #region find all delegating delegations that expiry date are on execution date.
            List<Entity> delegations = context.OrganizationDataContext.CreateQuery(Delegation.EntityName).Where(d => d.GetAttributeValue<DateTime>(Delegation.EffectiveDate).Equals(DateTime.Today.AddDays(1)) && d.GetAttributeValue<OptionSetValue>(Delegation.StatusReason).Value == 952700002).ToList();
            #endregion

            delegations.ForEach(delegation => DelegationUtils.EndDelegating(context, delegation));
        }
    }
}
