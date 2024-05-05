using DelegationPlugins.Entities;
using Microsoft.Xrm.Sdk;
using SharedLibrary;
using SharedLibrary.Constants;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DelegationPlugins
{
    public class DelegationSystemJobs: JdxPlugin
    {
        public DelegationSystemJobs() 
        {
            RegisterEvent(PipelineStage.PostOperation, PipelineMessage.Delete, CustomTrigger.EntityLogicalName, Execute);
        }

        /// <summary>
        /// Conside heavy-duty
        /// </summary>
        /// <param name="context"></param>
        public void Execute(LocalPluginContext context)
        {
            DelegationManager delegationManager = new DelegationManager(context);

            context.Trace($"Execute Multiple Process: Update status to start delegation.");
            #region find all pending delegations that effective date are on execution date.

            List<Delegation> delegationsStart = context.OrganizationDataContext.CreateQuery(Delegation.EntityLogicalName)
                .Cast<Delegation>()
                .Where(d => d.StatusReason.Equals(Delegation.StatusReasonEnum.Pending) && d.EffectiveDate.Equals(DateTime.Today))
                .ToList();
             
            #endregion



            OrganizationRequestCollection requestsStart = new OrganizationRequestCollection();


            delegationsStart.ForEach(delegation =>
            {
                
                if (delegation.DelegationMode.Equals(Delegation.DelegationModeEnum.Teambased))
                {
                    requestsStart.AddRange(delegationManager.CreateJoinTeamRequests(delegation));
                    
                }
                else if(delegation.DelegationMode.Equals(Delegation.DelegationModeEnum.Rolebased))
                {
                    requestsStart.AddRange(delegationManager.CreateRoleAssociateRequests(delegation));
                   
                }
                delegationManager.SendEmailFromTemplate(delegation, true);
                requestsStart.AddRange(delegationManager.CreateStartDelegationReassignRequests(delegation));

                if (delegation.SendNotifications == true)
                    delegationManager.SendEmailFromTemplate(delegation, true);
            });

            delegationManager.ExcuteMultiple(requestsStart);


            context.Trace($"Execute multiple Processes: delegations expired.");
            #region find all delegating delegations that expiry date are on execution date.
            List<Entity> delegationsEnd = context.OrganizationDataContext.CreateQuery(Delegation.EntityLogicalName)
                .Where(d => d.GetAttributeValue<DateTime>(Delegation.Fields.EffectiveDate).Equals(DateTime.Today.AddDays(1)) && d.GetAttributeValue<OptionSetValue>(Delegation.Fields.StatusReason).Value.Equals((int)Delegation.StatusReasonEnum.Delegating))
                .ToList();
            #endregion

            
            OrganizationRequestCollection requestsEnd = new OrganizationRequestCollection();


            delegationsEnd.ForEach(delegation =>
            {
               

                if (delegation.DelegationMode.Equals(Delegation.DelegationModeEnum.Teambased))
                {
                    requestsEnd.AddRange(delegationManager.CreateLeaveTeamRequests(delegation, Delegation.StatusReasonEnum.Expired));

                }
                else if (delegation.DelegationMode.Equals(Delegation.DelegationModeEnum.Rolebased))
                {
                    requestsEnd.AddRange(delegationManager.CreateRoleDisassociateRequests(delegation, Delegation.StatusReasonEnum.Expired));

                }
                delegationManager.SendEmailFromTemplate(delegation, false);
                requestsEnd.AddRange(delegationManager.CreateEndDelegationReassignRequests(delegation));

                if (delegation.SendNotifications == true)
                    delegationManager.SendEmailFromTemplate(delegation, false);
            });

            delegationManager.ExcuteMultiple(requestsEnd);
        }

        
    }
}
