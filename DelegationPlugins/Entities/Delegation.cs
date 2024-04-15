// *********************************************************************
// Created by : Latebound Constants Generator 1.2021.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://dv-shl0.cdt.gccas-gccase.gc.ca/
// Filename   : C:\Users\clh641\source\test lab\JDX\DelegationPlugins\Entities\Delegation.cs
// Created    : 2024-04-12 19:55:24
// *********************************************************************

namespace DelegationPlugins.Entities
{
    /// <summary>OwnershipType: OrganizationOwned, IntroducedVersion: 1.0.0.0</summary>
    public static class Delegation
    {
        public const string EntityName = "jms_delegation";
        public const string EntityCollectionName = "jms_delegations";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "jms_delegationid";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "jms_name";
        /// <summary>Type: Lookup, RequiredLevel: ApplicationRequired, Targets: systemuser</summary>
        public const string Delegated = "jms_delegated";
        /// <summary>Type: Lookup, RequiredLevel: ApplicationRequired, Targets: systemuser</summary>
        public const string Delegating = "jms_delegating";
        /// <summary>Type: DateTime, RequiredLevel: ApplicationRequired, Format: DateOnly, DateTimeBehavior: DateOnly</summary>
        public const string Effectivedate = "jms_effectivedate";
        /// <summary>Type: DateTime, RequiredLevel: ApplicationRequired, Format: DateOnly, DateTimeBehavior: DateOnly</summary>
        public const string Expirydate = "jms_expirydate";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 2000</summary>
        public const string Processlog = "jms_processlog";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 2000</summary>
        public const string TeamS = "jms_teams";

        #endregion Attributes

        #region Relationships

        /// <summary>Entity 1: "DelegationreassignConfiguration" Entity 2: "Delegation"</summary>
        public const string RelMM_JmsDelegationreassignConfigurationJmsD = "jms_jms_delegationreassignconfiguration_jms_d";
        /// <summary>Parent: "Delegation" Child: "Delegationreassignrecord" Lookup: "Delegation"</summary>
        public const string Rel1M_JmsDelegationJmsDelegationreassignrecordDelegation = "jms_jms_delegation_jms_delegationreassignrecord_Delegation";

        #endregion Relationships

        #region OptionSets

        public enum StateCode_OptionSet
        {
            Active = 0,
            Inactive = 1
        }
        public enum StatusCode_OptionSet
        {
            Draft = 1,
            Published = 952700000,
            Pending = 952700001,
            Delegating = 952700002,
            Canceled = 2,
            Expired = 952700003
        }

        #endregion OptionSets
    }
}
