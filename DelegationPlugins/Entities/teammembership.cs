// *********************************************************************
// Created by : Latebound Constants Generator 1.2023.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://orgb649ef22.crm3.dynamics.com
// Filename   : C:\Users\User\source\repos\JDX\DelegationPlugins\Entities\teammembership.cs
// Created    : 2024-04-08 20:13:22
// *********************************************************************
namespace  DelegationPlugins.Entities
{
    /// <summary>OwnershipType: None, IntroducedVersion: 5.0.0.0</summary>
    public static class teammembership
    {
        public const string EntityName = "teammembership";
        public const string EntityCollectionName = "";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "teammembershipid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string  SystemUserId= "systemuserid";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string TeamId = "teamid";
        /// <summary>Type: BigInt, RequiredLevel: None, MinValue: -9223372036854775808, MaxValue: 9223372036854775807</summary>
        public const string VersionNumber = "versionnumber";

        #endregion Attributes

        #region Relationships

        /// <summary>Entity 1: "Team" Entity 2: "User"</summary>
        public const string RelMM_teammembership_association = "teammembership_association";

        #endregion Relationships
    }
}
