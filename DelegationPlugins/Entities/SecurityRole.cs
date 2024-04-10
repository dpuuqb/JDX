// *********************************************************************
// Created by : Latebound Constants Generator 1.2023.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://orgb649ef22.crm3.dynamics.com
// Filename   : C:\Users\User\source\repos\JDX\DelegationPlugins\Entities\SecurityRole.cs
// Created    : 2024-04-08 20:13:22
// *********************************************************************
namespace DelegationPlugins.Entities
{
    /// <summary>DisplayName: Security Role, OwnershipType: BusinessOwned, IntroducedVersion: 5.0.0.0</summary>
    public static class SecurityRole
    {
        public const string EntityName = "role";
        public const string EntityCollectionName = "roles";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "roleid";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "name";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: businessunit</summary>
        public const string BusinessUnit = "businessunitid";
        /// <summary>Type: String (Logical), RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string BusinessUnitName = "businessunitidname";
        /// <summary>Type: ManagedProperty, RequiredLevel: SystemRequired</summary>
        public const string CanBeDeleted = "canbedeleted";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Component State, OptionSetType: Picklist, DefaultFormValue: -1</summary>
        public const string ComponentState = "componentstate";
        /// <summary>Type: ManagedProperty, RequiredLevel: SystemRequired</summary>
        public const string Customizable = "iscustomizable";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: -2147483648, MaxValue: 2147483647</summary>
        public const string ImportSequenceNumber = "importsequencenumber";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Is Inherited, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string IsInherited = "isinherited";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string IsInheritedName = "isinheritedname";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string IsManagedName = "ismanagedname";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string Organization = "organizationid";
        /// <summary>Type: String (Logical), RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string OrganizationName = "organizationidname";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: role</summary>
        public const string ParentRole = "parentroleid";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: role</summary>
        public const string ParentRootRole = "parentrootroleid";
        /// <summary>Type: String (Logical), RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string ParentRoleName = "parentroleidname";
        /// <summary>Type: String (Logical), RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string ParentRootRoleName = "parentrootroleidname";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateOnly, DateTimeBehavior: UserLocal</summary>
        public const string RecordCreatedOn = "overriddencreatedon";
        /// <summary>Type: DateTime, RequiredLevel: SystemRequired, Format: DateOnly, DateTimeBehavior: UserLocal</summary>
        public const string RecordOverwriteTime = "overwritetime";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: roletemplate</summary>
        public const string RoleTemplate = "roletemplateid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string Solution = "solutionid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string Solution1 = "supportingsolutionid";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string State = "ismanaged";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string UniqueId = "roleidunique";
        /// <summary>Type: BigInt, RequiredLevel: None, MinValue: -9223372036854775808, MaxValue: 9223372036854775807</summary>
        public const string Versionnumber = "versionnumber";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Organization" Child: "SecurityRole" Lookup: "Organization"</summary>
        public const string RelM1_SecurityRoleOrganization = "organization_roles";
        /// <summary>Parent: "BusinessUnit" Child: "SecurityRole" Lookup: "BusinessUnit"</summary>
        public const string RelM1_SecurityRoleBusinessUnit = "business_unit_roles";
        /// <summary>Parent: "RoleTemplate" Child: "SecurityRole" Lookup: "RoleTemplate"</summary>
        public const string RelM1_SecurityRoleRoleTemplate = "role_template_roles";
        /// <summary>Parent: "Solution" Child: "SecurityRole" Lookup: "Solution"</summary>
        public const string RelM1_SecurityRoleSolution = "solution_role";
        /// <summary>Entity 1: "User" Entity 2: "SecurityRole"</summary>
        public const string RelMM_systemuserroles_association = "systemuserroles_association";
        /// <summary>Entity 1: "Privilege" Entity 2: "SecurityRole"</summary>
        public const string RelMM_roleprivileges_association = "roleprivileges_association";
        /// <summary>Entity 1: "Model_drivenApp" Entity 2: "SecurityRole"</summary>
        public const string RelMM_appmoduleroles_association = "appmoduleroles_association";
        /// <summary>Entity 1: "Team" Entity 2: "SecurityRole"</summary>
        public const string RelMM_teamroles_association = "teamroles_association";
        /// <summary>Entity 1: "ApplicationUser" Entity 2: "SecurityRole"</summary>
        public const string RelMM_applicationuserrole = "applicationuserrole";
        /// <summary>Parent: "SecurityRole" Child: "SecurityRole" Lookup: "ParentRole"</summary>
        public const string Rel1M_SecurityRoleParentRole = "role_parent_role";
        /// <summary>Parent: "SecurityRole" Child: "SecurityRole" Lookup: "ParentRootRole"</summary>
        public const string Rel1M_SecurityRoleParentRootRole = "role_parent_root_role";
        /// <summary>Parent: "SecurityRole" Child: "Appprofilerolemapping" Lookup: ""</summary>
        public const string Rel1M_role_msdyn_appprofilerolemapping = "role_msdyn_appprofilerolemapping";
        /// <summary>Parent: "SecurityRole" Child: "ActionCardRoleSetting" Lookup: ""</summary>
        public const string Rel1M_lk_msdyn_roleid = "lk_msdyn_roleid";
        /// <summary>Parent: "SecurityRole" Child: "ServiceCopilotPluginRole" Lookup: ""</summary>
        public const string Rel1M_msdyn_role_msdyn_servicecopilotpluginrole_roleid = "msdyn_role_msdyn_servicecopilotpluginrole_roleid";
        /// <summary>Parent: "SecurityRole" Child: "PersonaSecurityRoleMapping" Lookup: ""</summary>
        public const string Rel1M_msdyn_role_msdyn_personasecurityrolemapping = "msdyn_role_msdyn_personasecurityrolemapping";

        #endregion Relationships

        #region OptionSets

        public enum ComponentState_OptionSet
        {
            Published = 0,
            Unpublished = 1,
            Deleted = 2,
            DeletedUnpublished = 3
        }
        public enum IsInherited_OptionSet
        {
            Teamprivilegesonly = 0,
            DirectUserBasicaccesslevelandTeamprivileges = 1
        }

        #endregion OptionSets
    }
}
