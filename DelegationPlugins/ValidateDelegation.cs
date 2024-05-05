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
        /// <summary>
        /// A user must be delegated only onece at a time. Also, the user must not in a state of delegating other users.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userId"></param>
        /// <exception cref="ArgumentException"></exception>
        public void IsDelegatedUserValid(LocalPluginContext context, Guid userId)
        {
            int count = context.OrganizationDataContext.CreateQuery(Delegation.EntityLogicalName)
                .Cast<Delegation>()
                .Where(d =>(d.DelegatedUser.Equals(userId)|| d.DelegatingUser.Equals(userId)) && (d.StatusReason.Equals(Delegation.StatusReasonEnum.Pending) || d.StatusReason.Equals(Delegation.StatusReasonEnum.Delegating)))
                .ToList()
                .Count();
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