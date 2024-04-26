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
            List<Entity> delegationsStart = context.OrganizationDataContext.CreateQuery(Delegation.EntityLogicalName)
                .Where(d => d.GetAttributeValue<DateTime>(Delegation.Fields.EffectiveDate).Equals(DateTime.Today) && d.GetAttributeValue<OptionSetValue>(Delegation.Fields.StatusReason).Value.Equals((int)Delegation.StatusReasonEnum.Pending))
                .ToList();
            #endregion

            
           
            OrganizationRequestCollection requestsStart = new OrganizationRequestCollection();


            delegationsStart.ForEach(delegation =>
            {
                var mode = (int)delegation.Attributes[Delegation.Fields.DelegationMode];
                if (mode == (int)Delegation.DelegationModeEnum.Teambased)
                {
                    requestsStart.AddRange(delegationManager.CreateJoinTeamRequests(delegation.ToEntity<Delegation>()));
                    
                }
                else if(mode == (int)Delegation.DelegationModeEnum.Rolebased)
                {
                    requestsStart.AddRange(delegationManager.CreateRoleAssociateRequests(delegation.ToEntity<Delegation>()));
                   
                }
                requestsStart.AddRange(delegationManager.CreateStartDelegationReassignRequests(delegation.ToEntity<Delegation>()));

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
                var mode = (int)delegation.Attributes[Delegation.Fields.DelegationMode];

                if (mode == (int)Delegation.DelegationModeEnum.Teambased)
                {
                    requestsEnd.AddRange(delegationManager.CreateLeaveTeamRequests(delegation.ToEntity<Delegation>(), Delegation.StatusReasonEnum.Expired));

                }
                else if (mode == (int)Delegation.DelegationModeEnum.Rolebased)
                {
                    requestsEnd.AddRange(delegationManager.CreateRoleDisassociateRequests(delegation.ToEntity<Delegation>(), Delegation.StatusReasonEnum.Expired));

                }

                requestsEnd.AddRange(delegationManager.CreateEndDelegationReassignRequests(delegation.ToEntity<Delegation>()));

            });

            delegationManager.ExcuteMultiple(requestsEnd);
        }

        
    }
}
