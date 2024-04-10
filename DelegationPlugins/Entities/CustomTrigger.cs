// *********************************************************************
// Created by : Latebound Constants Generator 1.2023.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://orgb649ef22.crm3.dynamics.com
// Filename   : C:\Users\User\source\repos\JDX\DelegationPlugins\Entities\CustomTrigger.cs
// Created    : 2024-04-08 20:29:59
// *********************************************************************
namespace DelegationPlugins.Entities
{
    /// <summary>DisplayName: Custom Trigger, OwnershipType: OrganizationOwned, IntroducedVersion: 1.0.0.0</summary>
    public static class CustomTrigger
    {
        public const string EntityName = "jms_trigger";
        public const string EntityCollectionName = "jms_triggers";

        #region Relationships

        /// <summary>Parent: "Organization" Child: "CustomTrigger" Lookup: "OrganizationId"</summary>
        public const string RelM1_CustomTriggerOrganizationId = "organization_jms_trigger";
        /// <summary>Parent: "CustomTrigger" Child: "FieldSharing" Lookup: ""</summary>
        public const string Rel1M_jms_trigger_PrincipalObjectAttributeAccesses = "jms_trigger_PrincipalObjectAttributeAccesses";

        #endregion Relationships
    }
}
