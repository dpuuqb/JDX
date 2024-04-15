// *********************************************************************
// Created by : Latebound Constants Generator 1.2021.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://dv-shl0.cdt.gccas-gccase.gc.ca/
// Filename   : C:\Users\clh641\source\test lab\JDX\DelegationPlugins\Entities\_common_.cs
// Created    : 2024-04-12 19:55:24
// *********************************************************************

namespace DelegationPlugins.Entities
{
    public static class Common
    {
        #region Attributes

        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser
        /// Used by entities: jms_customtrigger, jms_delegation, jms_delegationreassignconfiguration, jms_delegationreassignrecord</summary>
        public const string CreatedBy = "createdby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal
        /// Used by entities: jms_customtrigger, jms_delegation, jms_delegationreassignconfiguration, jms_delegationreassignrecord</summary>
        public const string CreatedOn = "createdon";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser
        /// Used by entities: jms_customtrigger, jms_delegation, jms_delegationreassignconfiguration, jms_delegationreassignrecord</summary>
        public const string ModifiedBy = "modifiedby";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal
        /// Used by entities: jms_customtrigger, jms_delegation, jms_delegationreassignconfiguration, jms_delegationreassignrecord</summary>
        public const string ModifiedOn = "modifiedon";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: organization
        /// Used by entities: jms_customtrigger, jms_delegation, jms_delegationreassignconfiguration, jms_delegationreassignrecord</summary>
        public const string OrganizationId = "organizationid";
        /// <summary>Type: State, RequiredLevel: SystemRequired, DisplayName: Status, OptionSetType: State
        /// Used by entities: jms_customtrigger, jms_delegation, jms_delegationreassignconfiguration, jms_delegationreassignrecord</summary>
        public const string StateCode = "statecode";
        /// <summary>Type: Status, RequiredLevel: None, DisplayName: Status Reason, OptionSetType: Status
        /// Used by entities: jms_customtrigger, jms_delegation, jms_delegationreassignconfiguration, jms_delegationreassignrecord</summary>
        public const string StatusCode = "statuscode";

        #endregion Attributes
    }
}
