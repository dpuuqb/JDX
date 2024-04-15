// *********************************************************************
// Created by : Latebound Constants Generator 1.2021.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://dv-shl0.cdt.gccas-gccase.gc.ca/
// Filename   : C:\Users\clh641\source\test lab\JDX\DelegationPlugins\Entities\CustomTrigger.cs
// Created    : 2024-04-12 19:55:24
// *********************************************************************

namespace DelegationPlugins.Entities
{
    /// <summary>DisplayName: Custom Trigger, OwnershipType: OrganizationOwned, IntroducedVersion: 1.0.0.0</summary>
    public static class Customtrigger
    {
        public const string EntityName = "jms_customtrigger";
        public const string EntityCollectionName = "jms_customtriggers";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "jms_customtriggerid";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 100, Format: Text</summary>
        public const string PrimaryName = "jms_name";

        #endregion Attributes

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
