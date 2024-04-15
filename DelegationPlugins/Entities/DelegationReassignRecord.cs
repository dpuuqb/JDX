// *********************************************************************
// Created by : Latebound Constants Generator 1.2021.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://dv-shl0.cdt.gccas-gccase.gc.ca/
// Filename   : C:\Users\clh641\source\test lab\JDX\DelegationPlugins\Entities\DelegationReassignRecord.cs
// Created    : 2024-04-12 19:55:24
// *********************************************************************

namespace DelegationPlugins.Entities
{
    /// <summary>DisplayName: Delegation Reassign Record, OwnershipType: OrganizationOwned, IntroducedVersion: 1.0.0.0</summary>
    public static class Delegationreassignrecord
    {
        public const string EntityName = "jms_delegationreassignrecord";
        public const string EntityCollectionName = "jms_delegationreassignrecords";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "jms_delegationreassignrecordid";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "jms_name";
        /// <summary>Type: Lookup, RequiredLevel: ApplicationRequired, Targets: jms_delegation</summary>
        public const string Delegation = "jms_delegation";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 100, Format: Text</summary>
        public const string EntityType = "jms_entityname";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 100, Format: Text</summary>
        public const string GuId = "jms_guid";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Delegation" Child: "Delegationreassignrecord" Lookup: "Delegation"</summary>
        public const string RelM1_JmsDelegationJmsDelegationreassignrecordDelegation = "jms_jms_delegation_jms_delegationreassignrecord_Delegation";

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
