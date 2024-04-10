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
    public class ValidateDelegation: JdxPlugin
    {
       
        public ValidateDelegation() {
            RegisterEvent(PipelineStage.PreValidation, PipelineMessage.Create, Delegation.EntityName, ExcuteValidation);
        }

        public void ExcuteValidation(LocalPluginContext context)
        {
            Entity target = context.PluginExecutionContext.InputParameters["Target"] as Entity;
            if (target != null)
            {
                Entity delegation = context.OrganizationService.Retrieve(Delegation.EntityName, target.Id, new ColumnSet(true));
                if (delegation != null)
                {
                    IsDatesValid(delegation.GetAttributeValue<DateTime>(Delegation.EffectiveDate), delegation.GetAttributeValue<DateTime>(Delegation.ExpiryDate));
                }
            }


        }
        public void IsDatesValid(DateTime effectiveDate, DateTime expiryDate)
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
                throw new ArgumentException("Expiry Date must equal to or be greater than Expiry Date.");
            }
            
        
        }

        public void IsUsersValid(Entity delegatedUser, Entity delegatingUser) {
            if (delegatedUser == null || delegatingUser == null) throw new ArgumentException("Delegating User and Delegating User must be filled.");

            else if (delegatedUser.Id == delegatingUser.Id) throw new ArgumentException("Delegating User must be different from Delegated User.");
        }
    }
}
