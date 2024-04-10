using DelegationPlugins.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SharedLibrary;
using SharedLibrary.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DelegationPlugins
{
    public class StartDelegation:JdxPlugin
    {
        
        
        public StartDelegation()
        {
            RegisterEvent(PipelineStage.PostOperation, PipelineMessage.Update, Delegation.EntityName, ExcuteSingle);
            RegisterEvent(PipelineStage.PostOperation, PipelineMessage.Delete, CustomTrigger.EntityName, ExecuteMultiple);
        }
        /// <summary>
        /// Start Delegation individually once published and effective date hits.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentException"></exception>
        public void ExcuteSingle(LocalPluginContext context)
        {
            context.Trace($"Execute Single Process: Update status to start delegation.");

            int pre_status = context.PreImage.GetAttributeValue<OptionSetValue>("statuscode").Value;
            int post_status = context.PostImage.GetAttributeValue<OptionSetValue>("statuscode").Value;

            context.Trace($"status change from {pre_status} to {post_status}.");
            //status reason transit from Published to Delegating
            if (pre_status == 952700000 && post_status == 952700002)
            {
                Entity target = context.PluginExecutionContext.InputParameters["Target"] as Entity;
                context.Trace($"Retrieved target: {target.Id}.");
                Entity delegation = context.OrganizationService.Retrieve(Delegation.EntityName, target.Id, new ColumnSet(true));
                context.Trace($"Retrieved delegation: {delegation.Id}.");
                
                DelegationUtils.StartDelegating(context, delegation);
            }
        }
        /// <summary>
        /// start Delegation mass-call from Delete event on custom trigger by system nightly job (at 2:00 AM daily)
        /// search all active deletion records that are in Pending.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidPluginExecutionException"></exception>
        public void ExecuteMultiple(LocalPluginContext context) 
        {
            context.Trace($"Execute Multiple Process: Update status to start delegation.");
            #region find all pending delegations that effective date are on execution date.
            List<Entity> delegations = context.OrganizationDataContext.CreateQuery(Delegation.EntityName).Where(d=>d.GetAttributeValue<DateTime>(Delegation.EffectiveDate).Equals(DateTime.Today) && d.GetAttributeValue<OptionSetValue>(Delegation.StatusReason).Value == 952700001).ToList();
            #endregion

            //Conside heavy-duty
            delegations.ForEach(delegation => DelegationUtils.StartDelegating(context, delegation));
            

        }

        
    }
}
