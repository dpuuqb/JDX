using DelegationPlugins.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SharedLibrary;
using SharedLibrary.Constants;
using System;
using static DelegationPlugins.Entities.SecurityRole;


namespace DelegationPlugins
{
    
    public class UpdateDelegation : JdxPlugin
    {
        public UpdateDelegation()
        {
            RegisterEvent(PipelineStage.PreOperation, PipelineMessage.Update, Delegation.EntityLogicalName, ExecutePreUpdate);
            RegisterEvent(PipelineStage.PostOperation, PipelineMessage.Update, Delegation.EntityLogicalName, ExecutePostUpdate);
        }
        /// <summary>
        /// For delegations pulished manually from Ribbon Button. Preoperation to update status reason.
        /// </summary>
        /// <param name="context"></param>
        public void ExecutePreUpdate(LocalPluginContext context)
        {
            context.Trace($"Debugger:ExecutePreUpdate: {context.PluginExecutionContext.InputParameters["Target"].GetType()}");

            Entity target = context.PluginExecutionContext.InputParameters["Target"] as Entity;

            Delegation update = target.ToEntity<Delegation>();
            Delegation preDelegation = context.PreImage.ToEntity<Delegation>();
            
            //condition: update target fields contains status reason and it transits from Draft to Published.
            if (update.Contains(Delegation.Fields.StatusReason) && preDelegation.StatusReason.Equals(Delegation.StatusReasonEnum.Draft) && update.StatusReason.Equals(Delegation.StatusReasonEnum.Published))
            {

                context.Trace("[ExecutePreUpdate]: Published manually from button.");
                DateTime effectiveDate = preDelegation.EffectiveDate ?? DateTime.MinValue;

                context.Trace($"[ExecutePreUpdate] Status Reason: {Delegation.StatusReasonEnum.Published} -- Start to analysis Effective Date {effectiveDate.ToLocalTime()}.");

                if (effectiveDate > DateTime.Today)
                {
                    context.Trace($"pre-update status reason to: {Delegation.StatusReasonEnum.Pending}.");
                    update.StatusReason = Delegation.StatusReasonEnum.Pending;
                }
                else
                {
                    context.Trace($"pre-update status reason to: {Delegation.StatusReasonEnum.Delegating}.");
                    update.StatusReason = Delegation.StatusReasonEnum.Delegating;
                }
            }
            else {

                context.Trace("[ExecutePreUpdate] : condition not match. Exit!");
            }
            
        }

        public void ExecutePostUpdate(LocalPluginContext context) 
        {
            Delegation delegation;
            OrganizationRequestCollection organizationRequests;
            DelegationManager delegationManager = new DelegationManager(context);
            Entity target = context.PluginExecutionContext.InputParameters["Target"] as Entity;
            Delegation update = target.ToEntity<Delegation>();
            Delegation preDelegation = context.PreImage.ToEntity<Delegation>();
            Delegation postDelegation = context.PostImage.ToEntity<Delegation>();

            if (update.Contains(Delegation.Fields.StatusReason) && postDelegation.StatusReason == Delegation.StatusReasonEnum.Delegating && preDelegation.StatusReason != Delegation.StatusReasonEnum.Delegating)
            {
                context.Trace($"[ExecutePostUpdate]: delegation started!");
                delegation = context.OrganizationService.Retrieve(Delegation.EntityLogicalName, target.Id, new ColumnSet(true)) as Delegation;

                if (delegation.DelegationMode == Delegation.DelegationModeEnum.Teambased)
                {
                    organizationRequests = delegationManager.CreateJoinTeamRequests(delegation);
                    organizationRequests.AddRange(delegationManager.CreateStartDelegationReassignRequests(delegation));
                    context.Trace($"[ExecutePostUpdate]: total request = {organizationRequests.Count}");
                    delegationManager.ExcuteMultiple(organizationRequests);
                }
                else if (delegation.DelegationMode == Delegation.DelegationModeEnum.Rolebased)
                {
                    organizationRequests = delegationManager.CreateRoleAssociateRequests(delegation);
                    organizationRequests.AddRange(delegationManager.CreateStartDelegationReassignRequests(delegation));
                    context.Trace($"[ExecutePostUpdate]: total request = {organizationRequests.Count}");
                    delegationManager.ExcuteMultiple(organizationRequests);
                }
                

                delegationManager.SendEmailFromTemplate(delegation, true);
            }
            else if (update.Contains(Delegation.Fields.StatusReason) && postDelegation.StatusReason == Delegation.StatusReasonEnum.Canceled && preDelegation.StatusReason != Delegation.StatusReasonEnum.Canceled)
            {
                context.Trace($"[ExecutePostUpdate]: delegation canceled!");
                delegation = context.OrganizationService.Retrieve(Delegation.EntityLogicalName, target.Id, new ColumnSet(true)) as Delegation;

                if (delegation.DelegationMode == Delegation.DelegationModeEnum.Teambased)
                {
                    organizationRequests = delegationManager.CreateLeaveTeamRequests(delegation, Delegation.StatusReasonEnum.Canceled);
                    organizationRequests.AddRange(delegationManager.CreateEndDelegationReassignRequests(delegation));
                    context.Trace($"[ExecutePostUpdate]: total request = {organizationRequests.Count}");
                    delegationManager.ExcuteMultiple(organizationRequests);
                }
                else if (delegation.DelegationMode == Delegation.DelegationModeEnum.Rolebased)
                {
                    organizationRequests = delegationManager.CreateRoleDisassociateRequests(delegation, Delegation.StatusReasonEnum.Canceled);
                    organizationRequests.AddRange(delegationManager.CreateStartDelegationReassignRequests(delegation));
                    context.Trace($"[ExecutePostUpdate]: total request = {organizationRequests.Count}");
                    delegationManager.ExcuteMultiple(organizationRequests);
                }


                
                delegationManager.SendEmailFromTemplate(delegation, false);
            }
            else
            {

                context.Trace("[ExecutePostUpdate] : condition not match. Exit!");
            }

            
        }



    }
}
