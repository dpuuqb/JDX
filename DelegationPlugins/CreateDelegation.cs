using DelegationPlugins.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using SharedLibrary;
using SharedLibrary.Constants;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DelegationPlugins
{
    public class CreateDelegation : JdxPlugin
    {
        public CreateDelegation() 
        {
            RegisterEvent(PipelineStage.PreOperation, PipelineMessage.Create, Delegation.EntityLogicalName, ExecutePreCreate);
            RegisterEvent(PipelineStage.PostOperation, PipelineMessage.Create, Delegation.EntityLogicalName, ExecutePostCreate);
        }
        /// <summary>
        /// Enable Auto-Publish to update status reason from Draft to Published at pre-create stage.
        /// </summary>
        /// <param name="context"></param>
        public void ExecutePreCreate(LocalPluginContext context)
        {
            Entity target = context.PluginExecutionContext.InputParameters["Target"] as Entity;
            Delegation create = target.ToEntity<Delegation>();
            

            if (create.IsAutoPublish.Value) {
                context.Trace($"[ExecutePreCreate] Is Auto-Publish: {create.IsAutoPublish} -- auto transit status reason from Draft to Published.");
                create.StatusReason = Delegation.StatusReasonEnum.Published;

                context.PluginExecutionContext.SharedVariables.Add(new KeyValuePair<string, object>("AutoPublished", true)) ;
            }

            
        }
        public void ExecutePostCreate(LocalPluginContext context)
        {
            Entity target = context.PluginExecutionContext.InputParameters["Target"] as Entity;
            Delegation create = target.ToEntity<Delegation>();


            //check Apply Default Configurations

            bool applyDefaultConfiguration = create.ApplyDefaultConfigurations ?? false;

            if (applyDefaultConfiguration)
            {

                List<Entity> defaultConfigs = context.OrganizationDataContext.CreateQuery(DelegationReassignConfiguration.EntityLogicalName)
                    .Where(d => ((DelegationReassignConfiguration)d).IsDefault.Equals(true)).ToList();


                EntityReferenceCollection configRefs = new EntityReferenceCollection();
                defaultConfigs.ForEach(c => configRefs.Add(c.ToEntityReference()));
                AssociateRequest request = new AssociateRequest()
                {
                    RelatedEntities = configRefs,
                    Relationship = new Relationship("jms_jms_delegationreassignconfiguration_jms_d"),
                    Target = new EntityReference(Delegation.EntityLogicalName, create.Id)
                };

                context.OrganizationService.Execute(request);
            }

            //Check Auto-Publish

            if (context.PluginExecutionContext.SharedVariables.Contains("AutoPublished"))
            {
                bool IsAutoPublished = (bool)context.PluginExecutionContext.SharedVariables["AutoPublished"];

                if (IsAutoPublished && create.StatusReason != null && create.StatusReason == Delegation.StatusReasonEnum.Published)
                {

                    DateTime effectiveDate = create.EffectiveDate ?? DateTime.Today;

                    context.Trace($"[ExecutePostCreate] Status Reason: {Delegation.StatusReasonEnum.Published} -- Start to analysis Effective Date {effectiveDate.ToLocalTime()}.");
                    Delegation update = new Delegation
                    {
                        Id = create.Id,
                        StatusReason = Delegation.StatusReasonEnum.Published
                    };

                    if (effectiveDate > DateTime.Today)
                    {
                        context.Trace($"update status reason to: {Delegation.StatusReasonEnum.Pending}.");
                        update.StatusReason = Delegation.StatusReasonEnum.Pending;
                    }
                    else
                    {
                        context.Trace($"update status reason to: {Delegation.StatusReasonEnum.Delegating}.");
                        update.StatusReason =Delegation.StatusReasonEnum.Delegating;
                    }

                    context.OrganizationService.Update(update);

                };
                    


            }
            

        }

           

            

        

        
    }
}
