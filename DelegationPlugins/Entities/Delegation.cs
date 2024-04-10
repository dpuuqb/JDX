// *********************************************************************
// Created by : Latebound Constants Generator 1.2023.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://orgb649ef22.crm3.dynamics.com
// Filename   : C:\Users\User\source\repos\JDX\Delegation.cs
// Created    : 2024-04-08 19:29:55
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
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "jms_name";
        /// <summary>Type: Lookup, RequiredLevel: ApplicationRequired, Targets: systemuser</summary>
        public const string DelegatedUser = "jms_delegateduser";
        /// <summary>Type: Lookup, RequiredLevel: ApplicationRequired, Targets: systemuser</summary>
        public const string DelegatingUser = "jms_delegatinguser";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: -2147483648, MaxValue: 2147483647</summary>
        public const string Duration = "jms_duration";
        /// <summary>Type: DateTime, RequiredLevel: ApplicationRequired, Format: DateOnly, DateTimeBehavior: DateOnly</summary>
        public const string EffectiveDate = "jms_effectivedate";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Email</summary>
        public const string EmailAddress = "emailaddress";
        /// <summary>Type: DateTime, RequiredLevel: ApplicationRequired, Format: DateOnly, DateTimeBehavior: DateOnly</summary>
        public const string ExpiryDate = "jms_expirydate";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: -2147483648, MaxValue: 2147483647</summary>
        public const string ImportSequenceNumber = "importsequencenumber";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 200, Format: Text</summary>
        public const string  DelegatedUserName = "jms_delegatedusername";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 200, Format: Text</summary>
        //public const string1 = "jms_delegateduseryominame";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 200, Format: Text</summary>
        //public const string2 = "jms_delegatingusername";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 200, Format: Text</summary>
        //public const string3 = "jms_delegatinguseryominame";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        //public const string4 = "jms_methodname";
        /// <summary>Type: Picklist, RequiredLevel: None, DisplayName: Method, OptionSetType: Picklist, DefaultFormValue: 952700000</summary>
        public const string Method = "jms_method";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: organization</summary>
        public const string OrganizationId = "organizationid";
        /// <summary>Type: String (Logical), RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        //public const string5 = "organizationidname";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 2000</summary>
        public const string ProcessLog = "jms_processlog";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateOnly, DateTimeBehavior: UserLocal</summary>
        public const string RecordCreatedOn = "overriddencreatedon";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 2000</summary>
        public const string Roles = "jms_roles";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        //public const string6 = "statecodename";
        /// <summary>Type: State, RequiredLevel: SystemRequired, DisplayName: Status, OptionSetType: State</summary>
        public const string Status = "statecode";
        /// <summary>Type: Status, RequiredLevel: None, DisplayName: Status Reason, OptionSetType: Status</summary>
        public const string StatusReason = "statuscode";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        //public const string7 = "statuscodename";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 2000</summary>
        public const string Teams = "jms_teams";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: -1, MaxValue: 2147483647</summary>
        public const string TimeZoneRuleVersionNumber = "timezoneruleversionnumber";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: -1, MaxValue: 2147483647</summary>
        public const string UTCConversionTimeZoneCode = "utcconversiontimezonecode";
        /// <summary>Type: BigInt, RequiredLevel: None, MinValue: -9223372036854775808, MaxValue: 9223372036854775807</summary>
        public const string VersionNumber = "versionnumber";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Organization" Child: "Delegation" Lookup: "OrganizationId"</summary>
        public const string RelM1_DelegationOrganizationId = "organization_jms_delegation";
        /// <summary>Parent: "User" Child: "Delegation" Lookup: "DelegatedUser"</summary>
        public const string RelM1_DelegationDelegatedUser = "jms_systemuser_jms_delegation_DelegatedUser";
        /// <summary>Parent: "User" Child: "Delegation" Lookup: "DelegatingUser"</summary>
        public const string RelM1_DelegationDelegatingUser = "jms_systemuser_jms_delegation_DelegatingUser";
        /// <summary>Parent: "Delegation" Child: "ActivityParty" Lookup: ""</summary>
        public const string Rel1M_jms_delegation_ActivityParties = "jms_delegation_ActivityParties";
        /// <summary>Parent: "Delegation" Child: "FieldSharing" Lookup: ""</summary>
        public const string Rel1M_jms_delegation_PrincipalObjectAttributeAccesses = "jms_delegation_PrincipalObjectAttributeAccesses";

        #endregion Relationships

        #region OptionSets

        public enum Method_OptionSet
        {
            Byteams = 952700000,
            ByRoles = 952700001,
            Bothteamsandroles = 952700002
        }
        public enum Status_OptionSet
        {
            Active = 0,
            Inactive = 1
        }
        public enum StatusReason_OptionSet
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
