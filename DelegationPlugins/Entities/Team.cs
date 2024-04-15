// *********************************************************************
// Created by : Latebound Constants Generator 1.2023.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://orgb649ef22.crm3.dynamics.com
// Filename   : C:\Users\User\source\repos\JDX\Team.cs
// Created    : 2024-04-08 19:29:55
// *********************************************************************
namespace DelegationPlugins.Entities
{
    /// <summary>OwnershipType: BusinessOwned, IntroducedVersion: 5.0.0.0</summary>
    public static class Team
    {
        public const string EntityName = "team";
        public const string EntityCollectionName = "teams";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "teamid";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 160, Format: Text</summary>
        public const string PrimaryName = "name";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string DeprecatedProcessStage = "stageid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1250, Format: Text</summary>
        public const string DeprecatedTraversedPath = "traversedpath";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: systemuser</summary>
        public const string Administrator = "administratorid";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string AdministratorName = "administratoridname";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string AdministratorYomiName = "administratoridyominame";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: businessunit</summary>
        public const string BusinessUnit = "businessunitid";
        /// <summary>Type: String (Logical), RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string BusinessUnitName = "businessunitidname";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: transactioncurrency</summary>
        public const string Currency = "transactioncurrencyid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: queue</summary>
        public const string DefaultQueue = "queueid";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: delegatedauthorization</summary>
        public const string Delegatedauthorization = "delegatedauthorizationid";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string DelegatedAuthorizationName = "delegatedauthorizationidname";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 2000</summary>
        public const string Description = "description";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Email</summary>
        public const string Email = "emailaddress";
        /// <summary>Type: Decimal, RequiredLevel: None, MinValue: 0.000000000001, MaxValue: 100000000000, Precision: 12</summary>
        public const string ExchangeRate = "exchangerate";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: -2147483648, MaxValue: 2147483647</summary>
        public const string ImportSequenceNumber = "importsequencenumber";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string IsDefault = "isdefault";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string IsSystemManaged = "systemmanaged";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string IsFaultName = "isdefaultname";
        /// <summary>Type: Boolean (Logical), RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string IsSaTokenSet = "issastokenset";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string IsSaTokenSetName = "issastokensetname";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Membership Type, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string MembershipType = "membershiptype";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string MembershipTypeName = "membershiptypename";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string ObjectIdforagroup = "azureactivedirectoryobjectid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string Organization = "organizationid";
        /// <summary>Type: String (Logical), RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string OrganizationName = "organizationidname";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string Process = "processid";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 400, Format: Text</summary>
        public const string QueueName = "queueidname";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateOnly, DateTimeBehavior: UserLocal</summary>
        public const string RecordCreatedOn = "overriddencreatedon";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: knowledgearticle,opportunity</summary>
        public const string RegardingObjectId = "regardingobjectid";
        /// <summary>Type: EntityName, RequiredLevel: None</summary>
        public const string RegardingObjectType = "regardingobjecttypecode";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string SasToken = "sastoken";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1250, Format: Text</summary>
        public const string ShareLinkQualifier = "sharelinkqualifier";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string SystemManagedName = "systemmanagedname";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: teamtemplate</summary>
        public const string TeamTemplateIdentifier = "teamtemplateid";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Team Type, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string TeamType = "teamtype";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string TeamTypeName = "teamtypename";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string TransactionCurrencyName = "transactioncurrencyidname";
        /// <summary>Type: BigInt, RequiredLevel: None, MinValue: -9223372036854775808, MaxValue: 9223372036854775807</summary>
        public const string Versionnumber = "versionnumber";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 160, Format: PhoneticGuide</summary>
        public const string YomiName = "yominame";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Teamtemplate" Child: "Team" Lookup: "TeamTemplateIdentifier"</summary>
        public const string RelM1_TeamTeamTemplateIdentifier = "teamtemplate_Teams";
        /// <summary>Parent: "User" Child: "Team" Lookup: "Administrator"</summary>
        public const string RelM1_TeamAdministrator = "lk_teambase_administratorid";
        /// <summary>Parent: "ProcessStage" Child: "Team" Lookup: "DeprecatedProcessStage"</summary>
        public const string RelM1_TeamDeprecatedProcessStage = "processstage_teams";
        /// <summary>Parent: "Queue" Child: "Team" Lookup: "DefaultQueue"</summary>
        public const string RelM1_TeamDefaultQueue = "queue_team";
        /// <summary>Parent: "Currency" Child: "Team" Lookup: "Currency"</summary>
        public const string RelM1_TeamCurrency = "TransactionCurrency_Team";
        /// <summary>Parent: "BusinessUnit" Child: "Team" Lookup: "BusinessUnit"</summary>
        public const string RelM1_TeamBusinessUnit = "business_unit_teams";
        /// <summary>Parent: "Organization" Child: "Team" Lookup: "Organization"</summary>
        public const string RelM1_TeamOrganization = "organization_teams";
        /// <summary>Parent: "DelegatedAuthorization" Child: "Team" Lookup: "Delegatedauthorization"</summary>
        public const string RelM1_TeamDelegatedauthorization = "team_delegatedauthorization";
        /// <summary>Parent: "Team" Child: "FieldSharing" Lookup: ""</summary>
        public const string Rel1M_team_principalobjectattributeaccess_principalid = "team_principalobjectattributeaccess_principalid";
        /// <summary>Parent: "Team" Child: "Connection" Lookup: ""</summary>
        public const string Rel1M_team_connections2 = "team_connections2";
        /// <summary>Parent: "Team" Child: "Goal" Lookup: ""</summary>
        public const string Rel1M_team_goal_goalowner = "team_goal_goalowner";
        /// <summary>Parent: "Team" Child: "FieldSharing" Lookup: ""</summary>
        public const string Rel1M_team_principalobjectattributeaccess = "team_principalobjectattributeaccess";
        /// <summary>Parent: "Team" Child: "QueueItem" Lookup: ""</summary>
        public const string Rel1M_team_queueitembase_workerid = "team_queueitembase_workerid";
        /// <summary>Parent: "Team" Child: "Connection" Lookup: ""</summary>
        public const string Rel1M_team_connections1 = "team_connections1";
        /// <summary>Parent: "Team" Child: "ImportSourceFile" Lookup: ""</summary>
        public const string Rel1M_ImportFile_Team = "ImportFile_Team";
        /// <summary>Parent: "Team" Child: "TeamMobileOfflineProfileMembership" Lookup: ""</summary>
        public const string Rel1M_team_teammobileofflineprofilemembership_TeamId = "team_teammobileofflineprofilemembership_TeamId";
        /// <summary>Parent: "Team" Child: "ResourceSpecification" Lookup: ""</summary>
        public const string Rel1M_team_resource_specs = "team_resource_specs";
        /// <summary>Parent: "Team" Child: "SchedulingGroup" Lookup: ""</summary>
        public const string Rel1M_team_resource_groups = "team_resource_groups";
        /// <summary>Parent: "Team" Child: "Salesroutingrun" Lookup: ""</summary>
        public const string Rel1M_msdyn_team_msdyn_salesroutingrun_ownerassigned = "msdyn_team_msdyn_salesroutingrun_ownerassigned";
        /// <summary>Parent: "Team" Child: "Salesroutingrun" Lookup: ""</summary>
        public const string Rel1M_msdyn_team_msdyn_salesroutingrun_previousowner = "msdyn_team_msdyn_salesroutingrun_previousowner";
        /// <summary>Entity 1: "Team" Entity 2: "SecurityRole"</summary>
        public const string RelMM_teamroles_association = "teamroles_association";
        /// <summary>Entity 1: "Team" Entity 2: "User"</summary>
        public const string RelMM_teammembership_association = "teammembership_association";
        /// <summary>Entity 1: "Team" Entity 2: "FieldSecurityProfile"</summary>
        public const string RelMM_teamprofiles_association = "teamprofiles_association";

        #endregion Relationships

        #region OptionSets

        public enum MembershipType_OptionSet
        {
            Membersandguests = 0,
            Members = 1,
            Owners = 2,
            Guests = 3
        }
        public enum RegardingObjectType_OptionSet
        {
        }
        public enum TeamType_OptionSet
        {
            Owner = 0,
            Access = 1,
            SecurityGroup = 2,
            OfficeGroup = 3
        }

        #endregion OptionSets
    }
}
