// *********************************************************************
// Created by : Latebound Constants Generator 1.2021.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://dv-shl0.cdt.gccas-gccase.gc.ca/
// Filename   : C:\Users\clh641\source\test lab\JDX\DelegationPlugins\Entities\DelegationReassignConfiguration.cs
// Created    : 2024-04-12 19:55:24
// *********************************************************************

namespace DelegationPlugins.Entities
{
    /// <summary>DisplayName: Delegation Reassign Configuration, OwnershipType: OrganizationOwned, IntroducedVersion: 1.0.0.0</summary>
    public static class DelegationreassignConfiguration
    {
        public const string EntityName = "jms_delegationreassignconfiguration";
        public const string EntityCollectionName = "jms_delegationreassignconfigurations";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "jms_delegationreassignconfigurationid";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "jms_name";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 100, Format: Text</summary>
        public const string EntityType = "jms_entityname";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 10000</summary>
        public const string Filter = "jms_filter";

        #endregion Attributes

        #region Relationships

        /// <summary>Entity 1: "DelegationreassignConfiguration" Entity 2: "Delegation"</summary>
        public const string RelMM_JmsDelegationreassignConfigurationJmsD = "jms_jms_delegationreassignconfiguration_jms_d";

        #endregion Relationships

        #region OptionSets

        public enum StateCode_OptionSet
        {
            Active = 0,
            Inactive = 1
        }
        public enum StatusCode_OptionSet
        {
            Active = 1,
            Inactive = 2
        }

        #endregion OptionSets
    }
}
