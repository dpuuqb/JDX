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
    public class ValidateDelegation : JdxPlugin
    {

        public ValidateDelegation()
        {
            RegisterEvent(PipelineStage.PreValidation, PipelineMessage.Create, Delegation.EntityLogicalName, ExecuteValidation);
            RegisterEvent(PipelineStage.PreValidation, PipelineMessage.Update, Delegation.EntityLogicalName, ExecuteValidation);
        }

        public void ExecuteValidation(LocalPluginContext context)
        {
            Delegation target = context.PluginExecutionContext.InputParameters["Target"] as Delegation;
            if (target != null)
            {
                try
                {
                    IsDelegatedUserValid(context, target.DelegatedUser.Value);
                    IsDatesValid(target.EffectiveDate, target.ExpiryDate);
                    IsUsersValid(target.GetAttributeValue<EntityReference>(Delegation.Fields.DelegatedUser), target.GetAttributeValue<EntityReference>(Delegation.Fields.DelegatingUser));
                }
                catch (ArgumentException ax)
                {
                    throw new InvalidPluginExecutionException(string.Format("Validation Failed: {0}",ax.Message));
                }
                    
            }


        }
        public void IsDelegatedUserValid(LocalPluginContext context, Guid userId)
        {
            int count = context.OrganizationDataContext.CreateQuery(Delegation.EntityLogicalName)
                .Where(d => d.GetAttributeValue<EntityReference>(Delegation.Fields.DelegatedUser).Id.Equals(userId) 
                && (d.GetAttributeValue<OptionSetValue>(Delegation.Fields.StatusReason).Value.Equals((int)Delegation.StatusReasonEnum.Pending) 
                || d.GetAttributeValue<OptionSetValue>(Delegation.Fields.StatusReason).Value.Equals((int)Delegation.StatusReasonEnum.Delegating))).ToList().Count();
            if (count > 0) 
            {
                throw new ArgumentException("Delegated User has already had active delegations!");
            }

        }
        public void IsDatesValid(DateTime? effectiveDate, DateTime? expiryDate)
        {
            if (effectiveDate == DateTime.MinValue || expiryDate == DateTime.MinValue)
            {

                throw new ArgumentException("Effective Date and Expiry Date must have values.");
            }
            else if (effectiveDate > expiryDate)
            {
                throw new ArgumentException("Effective Date must equal to or be earlier than Expiry Date.");
            }
            else if (expiryDate <= DateTime.Today)
            {
                throw new ArgumentException("Expiry Date must equal to or be greater than Execution Date(Today).");
            }


        }

        public void IsUsersValid(EntityReference delegatedUser, EntityReference delegatingUser)
        {
            if (delegatedUser == null || delegatingUser == null) throw new ArgumentException("Delegating User and Delegating User must be filled.");

            else if (delegatedUser.Id == delegatingUser.Id) throw new ArgumentException("Delegating User must be different from Delegated User.");
        }
    }
}