// *********************************************************************
// Created by : Latebound Constants Generator 1.2023.12.1 for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : https://orgb649ef22.crm3.dynamics.com
// Filename   : C:\Users\User\source\repos\JDX\DelegationPlugins\Entities\User.cs
// Created    : 2024-04-08 20:13:22
// *********************************************************************
namespace DelegationPlugins.Entities
{
    /// <summary>OwnershipType: BusinessOwned, IntroducedVersion: 5.0.0.0</summary>
    public static class User
    {
        public const string EntityName = "systemuser";
        public const string EntityCollectionName = "systemusers";

        #region Attributes

        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string PrimaryKey = "systemuserid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 200, Format: Text</summary>
        public const string PrimaryName = "fullname";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string DeprecatedProcessStage = "stageid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1250, Format: Text</summary>
        public const string DeprecatedTraversedPath = "traversedpath";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Access Mode, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string AccessMode = "accessmode";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string  AccessModeName = "accessmodename";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string ActiveDirectoryGuid = "activedirectoryguid";
        /// <summary>Type: Memo (Logical), RequiredLevel: None, MaxLength: 1000</summary>
        public const string Address = "address1_composite";
        /// <summary>Type: Picklist (Logical), RequiredLevel: None, DisplayName: Address 1: Address Type, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string Address1AddressType = "address1_addresstypecode";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 128, Format: Text</summary>
        public const string Address1County = "address1_county";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 64, Format: Text</summary>
        public const string Address1Fax = "address1_fax";
        /// <summary>Type: Uniqueidentifier (Logical), RequiredLevel: None</summary>
        public const string Address1ID = "address1_addressid";
        /// <summary>Type: Double (Logical), RequiredLevel: None, MinValue: -90, MaxValue: 90, Precision: 5</summary>
        public const string Address1Latitude = "address1_latitude";
        /// <summary>Type: Double (Logical), RequiredLevel: None, MinValue: -180, MaxValue: 180, Precision: 5</summary>
        public const string Address1Longitude = "address1_longitude";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string Address1Name = "address1_name";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 40, Format: Text</summary>
        public const string Address1PostOfficeBox = "address1_postofficebox";
        /// <summary>Type: Picklist (Logical), RequiredLevel: None, DisplayName: Address 1: Shipping Method , OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string Address1ShippingMethod = "address1_shippingmethodcode";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 4, Format: Text</summary>
        public const string Address1UPSZone = "address1_upszone";
        /// <summary>Type: Integer (Logical), RequiredLevel: None, MinValue: -1500, MaxValue: 1500</summary>
        public const string Address1UTCOffset = "address1_utcoffset";
        /// <summary>Type: Picklist (Logical), RequiredLevel: None, DisplayName: Address 2: Address Type, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string Address2AddressType = "address2_addresstypecode";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 128, Format: Text</summary>
        public const string Address2County = "address2_county";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string Address2Fax = "address2_fax";
        /// <summary>Type: Uniqueidentifier (Logical), RequiredLevel: None</summary>
        public const string Address2ID = "address2_addressid";
        /// <summary>Type: Double (Logical), RequiredLevel: None, MinValue: -90, MaxValue: 90, Precision: 5</summary>
        public const string Address2Latitude = "address2_latitude";
        /// <summary>Type: Double (Logical), RequiredLevel: None, MinValue: -180, MaxValue: 180, Precision: 5</summary>
        public const string Address2Longitude = "address2_longitude";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string Address2Name = "address2_name";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 40, Format: Text</summary>
        public const string Address2PostOfficeBox = "address2_postofficebox";
        /// <summary>Type: Picklist (Logical), RequiredLevel: None, DisplayName: Address 2: Shipping Method , OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string Address2ShippingMethod = "address2_shippingmethodcode";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string Address2Telephone1 = "address2_telephone1";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string Address2Telephone2 = "address2_telephone2";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string Address2Telephone3 = "address2_telephone3";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 4, Format: Text</summary>
        public const string Address2UPSZone = "address2_upszone";
        /// <summary>Type: Integer (Logical), RequiredLevel: None, MinValue: -1500, MaxValue: 1500</summary>
        public const string Address2UTCOffset = "address2_utcoffset";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string Address1_AddressTypeCodeName = "address1_addresstypecodename";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string Address1_ShippingMethodCodeName = "address1_shippingmethodcodename";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string Address2_AddressTypeCodeName = "address2_addresstypecodename";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string Address2_ShippingMethodCodeName = "address2_shippingmethodcodename";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string ApplicationID = "applicationid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1024, Format: Text</summary>
        public const string ApplicationIDURI = "applicationiduri";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string AzureADObjectID = "azureactivedirectoryobjectid";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string AzureDeletedOn = "azuredeletedon";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Azure State, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string AzureState = "azurestate";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string AzureStateName = "azurestatename";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string BotapplicationID = "msdyn_botapplicationid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string Bothandle = "msdyn_bothandle";
        /// <summary>Type: Picklist, RequiredLevel: ApplicationRequired, DisplayName: Bot Provider, OptionSetType: Picklist, DefaultFormValue: 192350001</summary>
        public const string BotProvider = "msdyn_botprovider";
        /// <summary>Type: Lookup, RequiredLevel: SystemRequired, Targets: businessunit</summary>
        public const string BusinessUnit = "businessunitid";
        /// <summary>Type: String (Logical), RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string BusinessUnitName = "businessunitidname";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: calendar</summary>
        public const string Calendar = "calendarid";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string CalTypeName = "caltypename";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: 0, MaxValue: 2147483647</summary>
        public const string Capacity = "msdyn_capacity";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 128, Format: Text</summary>
        public const string City = "address1_city";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 128, Format: Text</summary>
        public const string Country_Region = "address1_country";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: transactioncurrency</summary>
        public const string Currency = "transactioncurrencyid";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string DefaultFiltersPopulated = "defaultfilterspopulated";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 200, Format: Text</summary>
        public const string DefaultOneDriveforBusinessFolderName = "defaultodbfoldername";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: msdyn_presence</summary>
        public const string DefaultPresence = "msdyn_defaultpresenceiduser";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: queue</summary>
        public const string DefaultQueue = "queueid";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string DefaultMailBoxName = "defaultmailboxname";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Delete State, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string DeletedState = "deletedstate";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string DeletedStateName = "deletedstatename";
        /// <summary>Type: Memo, RequiredLevel: None, MaxLength: 2000</summary>
        public const string Description = "msdyn_botdescription";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 500, Format: Text</summary>
        public const string DisabledReason = "disabledreason";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string DisplayinServiceViews = "displayinserviceviews";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string DisplayInserviceViewName = "displayinserviceviewsname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Email</summary>
        public const string Email2 = "personalemailaddress";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string EmailAddressO365AdminApprovalStatus = "isemailaddressapprovedbyo365admin";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string EmailRouterAccessApprovalName = "emailrouteraccessapprovalname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string Employee = "employeeid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string Endpoint = "msdyn_botendpoint";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string EntityImage = "entityimage";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string EntityImageId = "entityimageid";
        /// <summary>Type: BigInt (Logical), RequiredLevel: None, MinValue: -9223372036854775808, MaxValue: 9223372036854775807</summary>
        public const string EntityImage_TimeStamp = "entityimage_timestamp";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 200, Format: Url</summary>
        public const string EntityImage_Url = "entityimage_url";
        /// <summary>Type: Decimal, RequiredLevel: None, MinValue: 0.000000000001, MaxValue: 100000000000, Precision: 12</summary>
        public const string ExchangeRate = "exchangerate";
        /// <summary>Type: Boolean, RequiredLevel: ApplicationRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string ExpertEnabledSwarm = "msdyn_isexpertenabledforswarm";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 256, Format: Text</summary>
        public const string FirstName = "firstname";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string GDPROptout = "msdyn_gdproptout";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string Government = "governmentid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 4000, Format: Text</summary>
        public const string GridWrapperControlfield = "msdyn_gridwrappercontrolfield";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string HomePhone = "homephone";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: -2147483648, MaxValue: 2147483647</summary>
        public const string ImportSequenceNumber = "importsequencenumber";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Incoming Email Delivery Method, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string IncomingEmailDeliveryMethod = "incomingemaildeliverymethod";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string IncommingEmailDeliveryMethodName = "incomingemaildeliverymethodname";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string Integrationusermode = "isintegrationuser";
        /// <summary>Type: Picklist, RequiredLevel: ApplicationRequired, DisplayName: Invitation Status, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string InvitationStatus = "invitestatuscode";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string InviteStatusCodeName = "invitestatuscodename";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: True</summary>
        public const string IsActiveDirectoryUser = "isactivedirectoryuser";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string IsDisabledName = "isdisabledname";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string IsIntegrationUserName = "isintegrationusername";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string IsLicensedName = "islicensedname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string JobTitle = "jobtitle";
        /// <summary>Type: String, RequiredLevel: ApplicationRequired, MaxLength: 256, Format: Text</summary>
        public const string LastName = "lastname";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateAndTime, DateTimeBehavior: UserLocal</summary>
        public const string LatestUserUpdateTime = "latestupdatetime";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: CAL Type, OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string LicenseType = "caltype";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: mailbox</summary>
        public const string Mailbox = "defaultmailbox";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 64, Format: Text</summary>
        public const string MainPhone = "address1_telephone1";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: systemuser</summary>
        public const string Manager = "parentsystemuserid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string MiddleName = "middlename";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Email</summary>
        public const string MobileAlertEmail = "mobilealertemail";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: mobileofflineprofile</summary>
        public const string MobileOfflineProfile = "mobileofflineprofileid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 64, Format: Text</summary>
        public const string MobilePhone = "mobilephone";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string MobileOfflineProfileName = "mobileofflineprofileidname";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string Msdyn_AgentTypeName = "msdyn_agenttypename";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string Msdyn_BotProviderName = "msdyn_botprovidername";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string Msdyn_DefaultPresenceUserName = "msdyn_defaultpresenceidusername";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string Msdyn_GdProptOutName = "msdyn_gdproptoutname";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string Msdyn_IsExpertenabledForWarmName = "msdyn_isexpertenabledforswarmname";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string Msdyn_UserTypeName = "msdyn_usertypename";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string Nickname = "nickname";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: SystemRequired</summary>
        public const string Organization = "organizationid";
        /// <summary>Type: String (Logical), RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string OrganizationName = "organizationidname";
        /// <summary>Type: Memo (Logical), RequiredLevel: None, MaxLength: 1000</summary>
        public const string OtherAddress = "address2_composite";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 128, Format: Text</summary>
        public const string OtherCity = "address2_city";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 128, Format: Text</summary>
        public const string OtherCountry_Region = "address2_country";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string OtherPhone = "address1_telephone2";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 128, Format: Text</summary>
        public const string OtherState_Province = "address2_stateorprovince";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 1024, Format: Text</summary>
        public const string OtherStreet1 = "address2_line1";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 1024, Format: Text</summary>
        public const string OtherStreet2 = "address2_line2";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 1024, Format: Text</summary>
        public const string OtherStreet3 = "address2_line3";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 40, Format: Text</summary>
        public const string OtherZIP_PostalCode = "address2_postalcode";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Outgoing Email Delivery Method, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string OutgoingEmailDeliveryMethod = "outgoingemaildeliverymethod";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string OutgoingEmailDeliveryMethodName = "outgoingemaildeliverymethodname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 500, Format: Text</summary>
        public const string OwningEnvironmentId = "msdyn_owningenvironmentid";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 50, Format: Text</summary>
        public const string Pager = "address1_telephone3";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string ParentSystemUserName = "parentsystemuseridname";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string ParentSystemYomiName = "parentsystemuseridyominame";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: 0, MaxValue: 1000000000</summary>
        public const string PassportHi = "passporthi";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: 0, MaxValue: 1000000000</summary>
        public const string PassportLo = "passportlo";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 200, Format: Url</summary>
        public const string PhotoURL = "photourl";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: position</summary>
        public const string Position = "positionid";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string PositionName = "positionidname";
        /// <summary>Type: Picklist, RequiredLevel: None, DisplayName: Preferred Address, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string PreferredAddress = "preferredaddresscode";
        /// <summary>Type: Picklist, RequiredLevel: None, DisplayName: Preferred Email, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string PreferredEmail = "preferredemailcode";
        /// <summary>Type: Picklist, RequiredLevel: None, DisplayName: Preferred Phone, OptionSetType: Picklist, DefaultFormValue: 1</summary>
        public const string PreferredPhone = "preferredphonecode";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string PreferredAddressCodeName = "preferredaddresscodename";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string PreferredEmailCodeName = "preferredemailcodename";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string PreferredPhoneCodeName = "preferredphonecodename";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 100, Format: Email</summary>
        public const string PrimaryEmail = "internalemailaddress";
        /// <summary>Type: Picklist, RequiredLevel: SystemRequired, DisplayName: Shows whether the email address is approved for each mailbox for processing email through server-side synchronization or the Email Router., OptionSetType: Picklist, DefaultFormValue: 0</summary>
        public const string PrimaryEmailStatus = "emailrouteraccessapproval";
        /// <summary>Type: Uniqueidentifier, RequiredLevel: None</summary>
        public const string Process = "processid";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 400, Format: Text</summary>
        public const string QueueName = "queueidname";
        /// <summary>Type: DateTime, RequiredLevel: None, Format: DateOnly, DateTimeBehavior: UserLocal</summary>
        public const string RecordCreatedOn = "overriddencreatedon";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string RestrictedAccessMode = "setupuser";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 20, Format: Text</summary>
        public const string Salutation = "salutation";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string SecretKeys = "msdyn_botsecretkeys";
        /// <summary>Type: Virtual (Logical), RequiredLevel: None</summary>
        public const string SetupUserName = "setupusername";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1024, Format: Text</summary>
        public const string SharePointEmailAddress = "sharepointemailaddress";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: site</summary>
        public const string Site = "siteid";
        /// <summary>Type: String (Logical), RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string SiteName = "siteidname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string Skills = "skills";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 128, Format: Text</summary>
        public const string State_Province = "address1_stateorprovince";
        /// <summary>Type: Boolean, RequiredLevel: None, True: 1, False: 0, DefaultValue: False</summary>
        public const string Status = "isdisabled";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 1024, Format: Text</summary>
        public const string Street1 = "address1_line1";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 1024, Format: Text</summary>
        public const string Street2 = "address1_line2";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 1024, Format: Text</summary>
        public const string Street3 = "address1_line3";
        /// <summary>Type: Lookup, RequiredLevel: None, Targets: territory</summary>
        public const string Territory = "territoryid";
        /// <summary>Type: String (Logical), RequiredLevel: SystemRequired, MaxLength: 100, Format: Text</summary>
        public const string TerritoryName = "territoryidname";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: -1, MaxValue: 2147483647</summary>
        public const string TimeZoneRuleVersionNumber = "timezoneruleversionnumber";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 128, Format: Text</summary>
        public const string Title = "title";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string TransactionCurrencyName = "transactioncurrencyidname";
        /// <summary>Type: Picklist, RequiredLevel: None, DisplayName: Type, OptionSetType: Picklist, DefaultFormValue: 192350000</summary>
        public const string Type = "msdyn_usertype";
        /// <summary>Type: Integer, RequiredLevel: SystemRequired, MinValue: -2147483648, MaxValue: 2147483647</summary>
        public const string Uniqueuseridentityid = "identityid";
        /// <summary>Type: Integer, RequiredLevel: SystemRequired, MinValue: -2147483648, MaxValue: 2147483647</summary>
        public const string UserLicenseType = "userlicensetype";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string UserLicensed = "islicensed";
        /// <summary>Type: String, RequiredLevel: SystemRequired, MaxLength: 1024, Format: Text</summary>
        public const string UserName = "domainname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 100, Format: Text</summary>
        public const string UserPUID = "userpuid";
        /// <summary>Type: Boolean, RequiredLevel: SystemRequired, True: 1, False: 0, DefaultValue: False</summary>
        public const string UserSynced = "issyncwithdirectory";
        /// <summary>Type: Picklist, RequiredLevel: None, DisplayName: User type, OptionSetType: Picklist, DefaultFormValue: -1</summary>
        public const string Usertype = "msdyn_agentType";
        /// <summary>Type: Integer, RequiredLevel: None, MinValue: -1, MaxValue: 2147483647</summary>
        public const string UTCConversionTimeZoneCode = "utcconversiontimezonecode";
        /// <summary>Type: BigInt, RequiredLevel: None, MinValue: -9223372036854775808, MaxValue: 9223372036854775807</summary>
        public const string Versionnumber = "versionnumber";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 1024, Format: Email</summary>
        public const string WindowsLiveID = "windowsliveid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 200, Format: Email</summary>
        public const string YammerEmail = "yammeremailaddress";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 128, Format: Text</summary>
        public const string YammerUserID = "yammeruserid";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 64, Format: PhoneticGuide</summary>
        public const string YomiFirstName = "yomifirstname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 200, Format: PhoneticGuide</summary>
        public const string YomiFullName = "yomifullname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 64, Format: PhoneticGuide</summary>
        public const string YomiLastName = "yomilastname";
        /// <summary>Type: String, RequiredLevel: None, MaxLength: 50, Format: PhoneticGuide</summary>
        public const string YomiMiddleName = "yomimiddlename";
        /// <summary>Type: String (Logical), RequiredLevel: None, MaxLength: 40, Format: Text</summary>
        public const string ZIP_PostalCode = "address1_postalcode";

        #endregion Attributes

        #region Relationships

        /// <summary>Parent: "Mailbox" Child: "User" Lookup: "Mailbox"</summary>
        public const string RelM1_UserMailbox = "systemuser_defaultmailbox_mailbox";
        /// <summary>Parent: "Position" Child: "User" Lookup: "Position"</summary>
        public const string RelM1_UserPosition = "position_users";
        /// <summary>Parent: "Calendar" Child: "User" Lookup: "Calendar"</summary>
        public const string RelM1_UserCalendar = "calendar_system_users";
        /// <summary>Parent: "BusinessUnit" Child: "User" Lookup: "BusinessUnit"</summary>
        public const string RelM1_UserBusinessUnit = "business_unit_system_users";
        /// <summary>Parent: "MobileOfflineProfile" Child: "User" Lookup: "MobileOfflineProfile"</summary>
        public const string RelM1_UserMobileOfflineProfile = "MobileOfflineProfile_SystemUser";
        /// <summary>Parent: "Currency" Child: "User" Lookup: "Currency"</summary>
        public const string RelM1_UserCurrency = "TransactionCurrency_SystemUser";
        /// <summary>Parent: "Organization" Child: "User" Lookup: "Organization"</summary>
        public const string RelM1_UserOrganization = "organization_system_users";
        /// <summary>Parent: "Queue" Child: "User" Lookup: "DefaultQueue"</summary>
        public const string RelM1_UserDefaultQueue = "queue_system_user";
        /// <summary>Parent: "ProcessStage" Child: "User" Lookup: "DeprecatedProcessStage"</summary>
        public const string RelM1_UserDeprecatedProcessStage = "processstage_systemusers";
        /// <summary>Parent: "Territory" Child: "User" Lookup: "Territory"</summary>
        public const string RelM1_UserTerritory = "territory_system_users";
        /// <summary>Parent: "Site" Child: "User" Lookup: "Site"</summary>
        public const string RelM1_UserSite = "site_system_users";
        /// <summary>Parent: "Presence" Child: "User" Lookup: "DefaultPresence"</summary>
        public const string RelM1_UserDefaultPresence = "msdyn_msdyn_presence_systemuser";
        /// <summary>Entity 1: "Team" Entity 2: "User"</summary>
        public const string RelMM_teammembership_association = "teammembership_association";
        /// <summary>Entity 1: "Queue" Entity 2: "User"</summary>
        public const string RelMM_queuemembership_association = "queuemembership_association";
        /// <summary>Entity 1: "SiteComponent" Entity 2: "User"</summary>
        public const string RelMM_powerpagecomponent_webrole_systemuser = "powerpagecomponent_webrole_systemuser";
        /// <summary>Entity 1: "Appprofile" Entity 2: "User"</summary>
        public const string RelMM_msdyn_appconfiguration_systemuser = "msdyn_appconfiguration_systemuser";
        /// <summary>Entity 1: "ChannelIntegrationFrameworkv10Provider" Entity 2: "User"</summary>
        public const string RelMM_msdyn_ciprovider_systemuser_membership = "msdyn_ciprovider_systemuser_membership";
        /// <summary>Entity 1: "Sellerattributevalue" Entity 2: "User"</summary>
        public const string RelMM_msdyn_msdyn_attributevalue_systemuser = "msdyn_msdyn_attributevalue_systemuser";
        /// <summary>Entity 1: "WorkStream" Entity 2: "User"</summary>
        public const string RelMM_msdyn_msdyn_liveworkstream_systemuser = "msdyn_msdyn_liveworkstream_systemuser";
        /// <summary>Parent: "User" Child: "User" Lookup: "Manager"</summary>
        public const string Rel1M_UserManager = "user_parent_user";
        /// <summary>Parent: "User" Child: "FieldSharing" Lookup: ""</summary>
        public const string Rel1M_systemuser_principalobjectattributeaccess_principalid = "systemuser_principalobjectattributeaccess_principalid";
        /// <summary>Parent: "User" Child: "Goal" Lookup: ""</summary>
        public const string Rel1M_user_goal_goalowner = "user_goal_goalowner";
        /// <summary>Parent: "User" Child: "ProcessSession" Lookup: ""</summary>
        public const string Rel1M_lk_processsession_completedby = "lk_processsession_completedby";
        /// <summary>Parent: "User" Child: "SdkMessageProcessingStep" Lookup: ""</summary>
        public const string Rel1M_impersonatinguserid_sdkmessageprocessingstep = "impersonatinguserid_sdkmessageprocessingstep";
        /// <summary>Parent: "User" Child: "QueueItem" Lookup: ""</summary>
        public const string Rel1M_lk_queueitembase_workerid = "lk_queueitembase_workerid";
        /// <summary>Parent: "User" Child: "Email" Lookup: ""</summary>
        public const string Rel1M_SystemUser_Email_EmailSender = "SystemUser_Email_EmailSender";
        /// <summary>Parent: "User" Child: "MonthlyFiscalCalendar" Lookup: ""</summary>
        public const string Rel1M_lk_monthlyfiscalcalendar_salespersonid = "lk_monthlyfiscalcalendar_salespersonid";
        /// <summary>Parent: "User" Child: "Contact" Lookup: ""</summary>
        public const string Rel1M_system_user_contacts = "system_user_contacts";
        /// <summary>Parent: "User" Child: "QuarterlyFiscalCalendar" Lookup: ""</summary>
        public const string Rel1M_lk_quarterlyfiscalcalendar_salespersonid = "lk_quarterlyfiscalcalendar_salespersonid";
        /// <summary>Parent: "User" Child: "ProcessSession" Lookup: ""</summary>
        public const string Rel1M_lk_processsession_executedby = "lk_processsession_executedby";
        /// <summary>Parent: "User" Child: "Auditing" Lookup: ""</summary>
        public const string Rel1M_lk_audit_userid = "lk_audit_userid";
        /// <summary>Parent: "User" Child: "OwnerMapping" Lookup: ""</summary>
        public const string Rel1M_OwnerMapping_SystemUser = "OwnerMapping_SystemUser";
        /// <summary>Parent: "User" Child: "Connection" Lookup: ""</summary>
        public const string Rel1M_systemuser_connections1 = "systemuser_connections1";
        /// <summary>Parent: "User" Child: "FixedMonthlyFiscalCalendar" Lookup: ""</summary>
        public const string Rel1M_lk_fixedmonthlyfiscalcalendar_salespersonid = "lk_fixedmonthlyfiscalcalendar_salespersonid";
        /// <summary>Parent: "User" Child: "ProcessSession" Lookup: ""</summary>
        public const string Rel1M_lk_processsession_startedby = "lk_processsession_startedby";
        /// <summary>Parent: "User" Child: "Account" Lookup: ""</summary>
        public const string Rel1M_system_user_accounts = "system_user_accounts";
        /// <summary>Parent: "User" Child: "Team" Lookup: "Administrator"</summary>
        public const string Rel1M_TeamAdministrator = "lk_teambase_administratorid";
        /// <summary>Parent: "User" Child: "KnowledgeArticle" Lookup: ""</summary>
        public const string Rel1M_knowledgearticle_primaryauthorid = "knowledgearticle_primaryauthorid";
        /// <summary>Parent: "User" Child: "Feedback" Lookup: ""</summary>
        public const string Rel1M_lk_feedback_closedby = "lk_feedback_closedby";
        /// <summary>Parent: "User" Child: "Queue" Lookup: ""</summary>
        public const string Rel1M_queue_primary_user = "queue_primary_user";
        /// <summary>Parent: "User" Child: "ActivityParty" Lookup: ""</summary>
        public const string Rel1M_system_user_activity_parties = "system_user_activity_parties";
        /// <summary>Parent: "User" Child: "AnnualFiscalCalendar" Lookup: ""</summary>
        public const string Rel1M_lk_annualfiscalcalendar_salespersonid = "lk_annualfiscalcalendar_salespersonid";
        /// <summary>Parent: "User" Child: "Auditing" Lookup: ""</summary>
        public const string Rel1M_lk_audit_callinguserid = "lk_audit_callinguserid";
        /// <summary>Parent: "User" Child: "SemiannualFiscalCalendar" Lookup: ""</summary>
        public const string Rel1M_lk_semiannualfiscalcalendar_salespersonid = "lk_semiannualfiscalcalendar_salespersonid";
        /// <summary>Parent: "User" Child: "ProcessSession" Lookup: ""</summary>
        public const string Rel1M_lk_processsession_canceledby = "lk_processsession_canceledby";
        /// <summary>Parent: "User" Child: "ImportSourceFile" Lookup: ""</summary>
        public const string Rel1M_ImportFile_SystemUser = "ImportFile_SystemUser";
        /// <summary>Parent: "User" Child: "FieldSharing" Lookup: ""</summary>
        public const string Rel1M_systemuser_principalobjectattributeaccess = "systemuser_principalobjectattributeaccess";
        /// <summary>Parent: "User" Child: "Connection" Lookup: ""</summary>
        public const string Rel1M_systemuser_connections2 = "systemuser_connections2";
        /// <summary>Parent: "User" Child: "SystemUserAuthorizationChangeTracker" Lookup: ""</summary>
        public const string Rel1M_user_userauthztracker = "user_userauthztracker";
        /// <summary>Parent: "User" Child: "UserSettings" Lookup: ""</summary>
        public const string Rel1M_user_settings = "user_settings";
        /// <summary>Parent: "User" Child: "FlowMachineGroup" Lookup: ""</summary>
        public const string Rel1M_flowmachinegroup_PasswordChangedBy = "flowmachinegroup_PasswordChangedBy";
        /// <summary>Parent: "User" Child: "FlowMachineGroup" Lookup: ""</summary>
        public const string Rel1M_flowmachinegroup_RotationStartedBy = "flowmachinegroup_RotationStartedBy";
        /// <summary>Parent: "User" Child: "WorkQueueItem" Lookup: ""</summary>
        public const string Rel1M_workqueueitem_processinguser = "workqueueitem_processinguser";
        /// <summary>Parent: "User" Child: "AIPluginUserSetting" Lookup: ""</summary>
        public const string Rel1M_AIPluginUserSetting_SystemUser_Syst = "AIPluginUserSetting_SystemUser_Syst";
        /// <summary>Parent: "User" Child: "Chatbot" Lookup: ""</summary>
        public const string Rel1M_systemuser_bot_publishedby = "systemuser_bot_publishedby";
        /// <summary>Parent: "User" Child: "Territory" Lookup: ""</summary>
        public const string Rel1M_system_user_territories = "system_user_territories";
        /// <summary>Parent: "User" Child: "Email" Lookup: ""</summary>
        public const string Rel1M_email_acceptingentity_systemuser = "email_acceptingentity_systemuser";
        /// <summary>Parent: "User" Child: "Teamschat" Lookup: ""</summary>
        public const string Rel1M_teams_chat_activity_linkrecord_systemUser = "teams_chat_activity_linkrecord_systemUser";
        /// <summary>Parent: "User" Child: "Teamschat" Lookup: ""</summary>
        public const string Rel1M_teams_chat_activity_unlinkrecord_systemUser = "teams_chat_activity_unlinkrecord_systemUser";
        /// <summary>Parent: "User" Child: "UserMobileOfflineProfileMembership" Lookup: ""</summary>
        public const string Rel1M_systemuser_usermobileofflineprofilemembership_SystemUserId = "systemuser_usermobileofflineprofilemembership_SystemUserId";
        /// <summary>Parent: "User" Child: "MultistepFormSession" Lookup: ""</summary>
        public const string Rel1M_adx_webformsession_systemuser = "adx_webformsession_systemuser";
        /// <summary>Parent: "User" Child: "AdPlacement" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_adplacement_createdby = "mspp_systemuser_mspp_adplacement_createdby";
        /// <summary>Parent: "User" Child: "AdPlacement" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_adplacement_modifiedby = "mspp_systemuser_mspp_adplacement_modifiedby";
        /// <summary>Parent: "User" Child: "ColumnPermission" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_columnpermission_createdby = "mspp_systemuser_mspp_columnpermission_createdby";
        /// <summary>Parent: "User" Child: "ColumnPermission" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_columnpermission_modifiedby = "mspp_systemuser_mspp_columnpermission_modifiedby";
        /// <summary>Parent: "User" Child: "ColumnPermissionProfile" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_columnpermissionprofile_createdby = "mspp_systemuser_mspp_columnpermissionprofile_createdby";
        /// <summary>Parent: "User" Child: "ColumnPermissionProfile" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_columnpermissionprofile_modifiedby = "mspp_systemuser_mspp_columnpermissionprofile_modifiedby";
        /// <summary>Parent: "User" Child: "ContentSnippet" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_contentsnippet_createdby = "mspp_systemuser_mspp_contentsnippet_createdby";
        /// <summary>Parent: "User" Child: "ContentSnippet" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_contentsnippet_modifiedby = "mspp_systemuser_mspp_contentsnippet_modifiedby";
        /// <summary>Parent: "User" Child: "BasicForm" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_entityform_createdby = "mspp_systemuser_mspp_entityform_createdby";
        /// <summary>Parent: "User" Child: "BasicForm" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_entityform_modifiedby = "mspp_systemuser_mspp_entityform_modifiedby";
        /// <summary>Parent: "User" Child: "BasicFormMetadata" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_entityformmetadata_createdby = "mspp_systemuser_mspp_entityformmetadata_createdby";
        /// <summary>Parent: "User" Child: "BasicFormMetadata" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_entityformmetadata_modifiedby = "mspp_systemuser_mspp_entityformmetadata_modifiedby";
        /// <summary>Parent: "User" Child: "List" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_entitylist_createdby = "mspp_systemuser_mspp_entitylist_createdby";
        /// <summary>Parent: "User" Child: "List" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_entitylist_modifiedby = "mspp_systemuser_mspp_entitylist_modifiedby";
        /// <summary>Parent: "User" Child: "TablePermission" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_entitypermission_createdby = "mspp_systemuser_mspp_entitypermission_createdby";
        /// <summary>Parent: "User" Child: "TablePermission" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_entitypermission_modifiedby = "mspp_systemuser_mspp_entitypermission_modifiedby";
        /// <summary>Parent: "User" Child: "PageTemplate" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_pagetemplate_createdby = "mspp_systemuser_mspp_pagetemplate_createdby";
        /// <summary>Parent: "User" Child: "PageTemplate" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_pagetemplate_modifiedby = "mspp_systemuser_mspp_pagetemplate_modifiedby";
        /// <summary>Parent: "User" Child: "PollPlacement" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_pollplacement_createdby = "mspp_systemuser_mspp_pollplacement_createdby";
        /// <summary>Parent: "User" Child: "PollPlacement" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_pollplacement_modifiedby = "mspp_systemuser_mspp_pollplacement_modifiedby";
        /// <summary>Parent: "User" Child: "PublishingState" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_publishingstate_createdby = "mspp_systemuser_mspp_publishingstate_createdby";
        /// <summary>Parent: "User" Child: "PublishingState" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_publishingstate_modifiedby = "mspp_systemuser_mspp_publishingstate_modifiedby";
        /// <summary>Parent: "User" Child: "PublishingStateTransitionRule" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_publishingstatetransitionrule_createdby = "mspp_systemuser_mspp_publishingstatetransitionrule_createdby";
        /// <summary>Parent: "User" Child: "PublishingStateTransitionRule" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_publishingstatetransitionrule_modifiedby = "mspp_systemuser_mspp_publishingstatetransitionrule_modifiedby";
        /// <summary>Parent: "User" Child: "Redirect" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_redirect_createdby = "mspp_systemuser_mspp_redirect_createdby";
        /// <summary>Parent: "User" Child: "Redirect" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_redirect_modifiedby = "mspp_systemuser_mspp_redirect_modifiedby";
        /// <summary>Parent: "User" Child: "Shortcut" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_shortcut_createdby = "mspp_systemuser_mspp_shortcut_createdby";
        /// <summary>Parent: "User" Child: "Shortcut" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_shortcut_modifiedby = "mspp_systemuser_mspp_shortcut_modifiedby";
        /// <summary>Parent: "User" Child: "SiteMarker" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_sitemarker_createdby = "mspp_systemuser_mspp_sitemarker_createdby";
        /// <summary>Parent: "User" Child: "SiteMarker" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_sitemarker_modifiedby = "mspp_systemuser_mspp_sitemarker_modifiedby";
        /// <summary>Parent: "User" Child: "SiteSetting" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_sitesetting_createdby = "mspp_systemuser_mspp_sitesetting_createdby";
        /// <summary>Parent: "User" Child: "SiteSetting" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_sitesetting_modifiedby = "mspp_systemuser_mspp_sitesetting_modifiedby";
        /// <summary>Parent: "User" Child: "WebFile" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webfile_createdby = "mspp_systemuser_mspp_webfile_createdby";
        /// <summary>Parent: "User" Child: "WebFile" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webfile_modifiedby = "mspp_systemuser_mspp_webfile_modifiedby";
        /// <summary>Parent: "User" Child: "MultistepForm" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webform_createdby = "mspp_systemuser_mspp_webform_createdby";
        /// <summary>Parent: "User" Child: "MultistepForm" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webform_modifiedby = "mspp_systemuser_mspp_webform_modifiedby";
        /// <summary>Parent: "User" Child: "MultistepFormMetadata" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webformmetadata_createdby = "mspp_systemuser_mspp_webformmetadata_createdby";
        /// <summary>Parent: "User" Child: "MultistepFormMetadata" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webformmetadata_modifiedby = "mspp_systemuser_mspp_webformmetadata_modifiedby";
        /// <summary>Parent: "User" Child: "FormStep" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webformstep_createdby = "mspp_systemuser_mspp_webformstep_createdby";
        /// <summary>Parent: "User" Child: "FormStep" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webformstep_modifiedby = "mspp_systemuser_mspp_webformstep_modifiedby";
        /// <summary>Parent: "User" Child: "WebLink" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_weblink_createdby = "mspp_systemuser_mspp_weblink_createdby";
        /// <summary>Parent: "User" Child: "WebLink" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_weblink_modifiedby = "mspp_systemuser_mspp_weblink_modifiedby";
        /// <summary>Parent: "User" Child: "WebLinkSet" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_weblinkset_createdby = "mspp_systemuser_mspp_weblinkset_createdby";
        /// <summary>Parent: "User" Child: "WebLinkSet" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_weblinkset_modifiedby = "mspp_systemuser_mspp_weblinkset_modifiedby";
        /// <summary>Parent: "User" Child: "WebPage" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webpage_createdby = "mspp_systemuser_mspp_webpage_createdby";
        /// <summary>Parent: "User" Child: "WebPage" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webpage_modifiedby = "mspp_systemuser_mspp_webpage_modifiedby";
        /// <summary>Parent: "User" Child: "WebPageAccessControlRule" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webpageaccesscontrolrule_createdby = "mspp_systemuser_mspp_webpageaccesscontrolrule_createdby";
        /// <summary>Parent: "User" Child: "WebPageAccessControlRule" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webpageaccesscontrolrule_modifiedby = "mspp_systemuser_mspp_webpageaccesscontrolrule_modifiedby";
        /// <summary>Parent: "User" Child: "WebRole" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webrole_createdby = "mspp_systemuser_mspp_webrole_createdby";
        /// <summary>Parent: "User" Child: "WebRole" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webrole_modifiedby = "mspp_systemuser_mspp_webrole_modifiedby";
        /// <summary>Parent: "User" Child: "Website" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_website_createdby = "mspp_systemuser_mspp_website_createdby";
        /// <summary>Parent: "User" Child: "Website" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_website_modifiedby = "mspp_systemuser_mspp_website_modifiedby";
        /// <summary>Parent: "User" Child: "WebsiteAccess" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_websiteaccess_createdby = "mspp_systemuser_mspp_websiteaccess_createdby";
        /// <summary>Parent: "User" Child: "WebsiteAccess" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_websiteaccess_modifiedby = "mspp_systemuser_mspp_websiteaccess_modifiedby";
        /// <summary>Parent: "User" Child: "WebsiteLanguage" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_websitelanguage_createdby = "mspp_systemuser_mspp_websitelanguage_createdby";
        /// <summary>Parent: "User" Child: "WebsiteLanguage" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_websitelanguage_modifiedby = "mspp_systemuser_mspp_websitelanguage_modifiedby";
        /// <summary>Parent: "User" Child: "WebTemplate" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webtemplate_createdby = "mspp_systemuser_mspp_webtemplate_createdby";
        /// <summary>Parent: "User" Child: "WebTemplate" Lookup: ""</summary>
        public const string Rel1M_mspp_systemuser_mspp_webtemplate_modifiedby = "mspp_systemuser_mspp_webtemplate_modifiedby";
        /// <summary>Parent: "User" Child: "PropertyInstance" Lookup: ""</summary>
        public const string Rel1M_OwningUser_Dynamicpropertyinsatance = "OwningUser_Dynamicpropertyinsatance";
        /// <summary>Parent: "User" Child: "BookableResource" Lookup: ""</summary>
        public const string Rel1M_systemuser_bookableresource_UserId = "systemuser_bookableresource_UserId";
        /// <summary>Parent: "User" Child: "ResourceGroup" Lookup: ""</summary>
        public const string Rel1M_constraintbasedgroup_systemuser = "constraintbasedgroup_systemuser";
        /// <summary>Parent: "User" Child: "Facility_Equipment" Lookup: ""</summary>
        public const string Rel1M_equipment_systemuser = "equipment_systemuser";
        /// <summary>Parent: "User" Child: "Resource" Lookup: ""</summary>
        public const string Rel1M_systemuser_resources = "systemuser_resources";
        /// <summary>Parent: "User" Child: "InvoiceProduct" Lookup: ""</summary>
        public const string Rel1M_system_user_invoicedetail = "system_user_invoicedetail";
        /// <summary>Parent: "User" Child: "QuoteProduct" Lookup: ""</summary>
        public const string Rel1M_system_user_quotedetail = "system_user_quotedetail";
        /// <summary>Parent: "User" Child: "OrderProduct" Lookup: ""</summary>
        public const string Rel1M_system_user_salesorderdetail = "system_user_salesorderdetail";
        /// <summary>Parent: "User" Child: "SalesLiterature" Lookup: ""</summary>
        public const string Rel1M_system_user_sales_literature = "system_user_sales_literature";
        /// <summary>Parent: "User" Child: "ReadTracker" Lookup: ""</summary>
        public const string Rel1M_msdyn_msdyn_readtracker_systemuser = "msdyn_msdyn_readtracker_systemuser";
        /// <summary>Parent: "User" Child: "ShareAsConfiguration" Lookup: ""</summary>
        public const string Rel1M_msdyn_msdyn_shareasconfiguration_sharedbyuserid = "msdyn_msdyn_shareasconfiguration_sharedbyuserid";
        /// <summary>Parent: "User" Child: "ShareAsConfiguration" Lookup: ""</summary>
        public const string Rel1M_msdyn_msdyn_shareasconfiguration_sharedwithuserid = "msdyn_msdyn_shareasconfiguration_sharedwithuserid";
        /// <summary>Parent: "User" Child: "Forecast" Lookup: ""</summary>
        public const string Rel1M_msdyn_msdyn_forecast_ownerid = "msdyn_msdyn_forecast_ownerid";
        /// <summary>Parent: "User" Child: "Customeremailcommunication" Lookup: ""</summary>
        public const string Rel1M_msdyn_customeremailcommunication_ToUserId = "msdyn_customeremailcommunication_ToUserId";
        /// <summary>Parent: "User" Child: "wkwcolleaguesforcompany" Lookup: ""</summary>
        public const string Rel1M_systemuser_msdyn_wkwcolleaguesforcompany_introducer_systemuserid = "systemuser_msdyn_wkwcolleaguesforcompany_introducer_systemuserid";
        /// <summary>Parent: "User" Child: "wkwcolleaguesforcontact" Lookup: ""</summary>
        public const string Rel1M_systemuser_msdyn_wkwcolleaguesforcontact_introducer_systemuserid = "systemuser_msdyn_wkwcolleaguesforcontact_introducer_systemuserid";
        /// <summary>Parent: "User" Child: "CustomerVoicesurvey" Lookup: ""</summary>
        public const string Rel1M_msfp_systemuser_msfp_survey_publishedby = "msfp_systemuser_msfp_survey_publishedby";
        /// <summary>Parent: "User" Child: "Routingdiagnostic" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_unifiedroutingrun_assignedagent = "msdyn_systemuser_msdyn_unifiedroutingrun_assignedagent";
        /// <summary>Parent: "User" Child: "Swarmparticipant" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_swarmparticipant_userid = "msdyn_systemuser_msdyn_swarmparticipant_userid";
        /// <summary>Parent: "User" Child: "PreferredAgent" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_preferredagent_systemuserid = "msdyn_systemuser_msdyn_preferredagent_systemuserid";
        /// <summary>Parent: "User" Child: "AgentStatushistory" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_agentstatushistory_Agentid = "msdyn_systemuser_msdyn_agentstatushistory_Agentid";
        /// <summary>Parent: "User" Child: "Conversation" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_ocliveworkitem_activeagentid = "msdyn_systemuser_msdyn_ocliveworkitem_activeagentid";
        /// <summary>Parent: "User" Child: "OngoingconversationDeprecated" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_liveconversation = "msdyn_systemuser_msdyn_liveconversation";
        /// <summary>Parent: "User" Child: "WorkStream" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_liveworkstream_msdyn_bot_user = "msdyn_systemuser_msdyn_liveworkstream_msdyn_bot_user";
        /// <summary>Parent: "User" Child: "LiveWorkItemParticipantDeprecated" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_ocliveworkitemparticipant_agentid = "msdyn_systemuser_msdyn_ocliveworkitemparticipant_agentid";
        /// <summary>Parent: "User" Child: "Sessionparticipant" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_sessionparticipant_agentid = "msdyn_systemuser_msdyn_sessionparticipant_agentid";
        /// <summary>Parent: "User" Child: "RuleItem" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_ocruleitem = "msdyn_systemuser_ocruleitem";
        /// <summary>Parent: "User" Child: "Filter" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_wallsavedqueryusersettings_userid = "msdyn_systemuser_wallsavedqueryusersettings_userid";
        /// <summary>Parent: "User" Child: "Agentcapacityupdatehistory" Lookup: ""</summary>
        public const string Rel1M_user_msdyn_agentcapacityupdatehistory_agentid = "user_msdyn_agentcapacityupdatehistory_agentid";
        /// <summary>Parent: "User" Child: "AgentCapacityProfileUnit" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_agentcapacityprofileunit_agentid = "msdyn_systemuser_msdyn_agentcapacityprofileunit_agentid";
        /// <summary>Parent: "User" Child: "AgentStatus" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_agentstatus_agentid = "msdyn_systemuser_msdyn_agentstatus_agentid";
        /// <summary>Parent: "User" Child: "AgentChannelState" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_agentchannelstate_agentid = "msdyn_systemuser_msdyn_agentchannelstate_agentid";
        /// <summary>Parent: "User" Child: "ConversationCharacteristic" Lookup: ""</summary>
        public const string Rel1M_msdyn_ocliveworkitemcharacteristic_skilladdedby = "msdyn_ocliveworkitemcharacteristic_skilladdedby";
        /// <summary>Parent: "User" Child: "Trainingrecord" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_ocsitrainingdata_approvedby = "msdyn_systemuser_msdyn_ocsitrainingdata_approvedby";
        /// <summary>Parent: "User" Child: "AssignmentMap" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_msdyn_assignmentmap_systemuserid = "msdyn_systemuser_msdyn_msdyn_assignmentmap_systemuserid";
        /// <summary>Parent: "User" Child: "Salesroutingrun" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_salesroutingrun_ownerassigned = "msdyn_systemuser_msdyn_salesroutingrun_ownerassigned";
        /// <summary>Parent: "User" Child: "Salesroutingrun" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_salesroutingrun_previousowner = "msdyn_systemuser_msdyn_salesroutingrun_previousowner";
        /// <summary>Parent: "User" Child: "SuggestionPrincipalObjectAccess" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_suggestionprincipalobjectaccess_principalid = "msdyn_systemuser_suggestionprincipalobjectaccess_principalid";
        /// <summary>Parent: "User" Child: "DuplicateLeadMapping" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_duplicateleadmapping_DismissedBy = "msdyn_systemuser_msdyn_duplicateleadmapping_DismissedBy";
        /// <summary>Parent: "User" Child: "ConversationMessageBlock" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_conversationmessageblock_msdyn_agentid = "msdyn_systemuser_msdyn_conversationmessageblock_msdyn_agentid";
        /// <summary>Parent: "User" Child: "DataAnalyticsWorkspace" Lookup: ""</summary>
        public const string Rel1M_msdyn_systemuser_msdyn_dataanalyticsworkspace_configuredby = "msdyn_systemuser_msdyn_dataanalyticsworkspace_configuredby";
        /// <summary>Parent: "User" Child: "Delegation" Lookup: "DelegatedUser"</summary>
        public const string Rel1M_DelegationDelegatedUser = "jms_systemuser_jms_delegation_DelegatedUser";
        /// <summary>Parent: "User" Child: "Delegation" Lookup: "DelegatingUser"</summary>
        public const string Rel1M_DelegationDelegatingUser = "jms_systemuser_jms_delegation_DelegatingUser";
        /// <summary>Parent: "User" Child: "ConversationParticipantInsights" Lookup: ""</summary>
        public const string Rel1M_msdyn_msdyn_conversationparticipantinsights_systemuser_msdyn_User = "msdyn_msdyn_conversationparticipantinsights_systemuser_msdyn_User";
        /// <summary>Entity 1: "User" Entity 2: "FieldSecurityProfile"</summary>
        public const string RelMM_systemuserprofiles_association = "systemuserprofiles_association";
        /// <summary>Entity 1: "User" Entity 2: "SecurityRole"</summary>
        public const string RelMM_systemuserroles_association = "systemuserroles_association";
        /// <summary>Entity 1: "User" Entity 2: "OmnichannelQueueDeprecated"</summary>
        public const string RelMM_msdyn_systemuser_msdyn_omnichannelqueue = "msdyn_systemuser_msdyn_omnichannelqueue";

        #endregion Relationships

        #region OptionSets

        public enum AccessMode_OptionSet
        {
            Read_Write = 0,
            Administrative = 1,
            Read = 2,
            SupportUser = 3,
            Non_interactive = 4,
            DelegatedAdmin = 5
        }
        public enum Address1AddressType_OptionSet
        {
            DefaultValue = 1
        }
        public enum Address1ShippingMethod_OptionSet
        {
            DefaultValue = 1
        }
        public enum Address2AddressType_OptionSet
        {
            DefaultValue = 1
        }
        public enum Address2ShippingMethod_OptionSet
        {
            DefaultValue = 1
        }
        public enum AzureState_OptionSet
        {
            Exists = 0,
            Softdeleted = 1,
            Notfoundorharddeleted = 2
        }
        public enum BotProvider_OptionSet
        {
            VirtualAgent = 192350000,
            Other = 192350001,
            None = 192350002
        }
        public enum DeletedState_OptionSet
        {
            Notdeleted = 0,
            Softdeleted = 1
        }
        public enum IncomingEmailDeliveryMethod_OptionSet
        {
            None = 0,
            MicrosoftDynamics365forOutlook = 1,
            Server_SideSynchronizationorEmailRouter = 2,
            ForwardMailbox = 3
        }
        public enum InvitationStatus_OptionSet
        {
            InvitationNotSent = 0,
            Invited = 1,
            InvitationNearExpired = 2,
            InvitationExpired = 3,
            InvitationAccepted = 4,
            InvitationRejected = 5,
            InvitationRevoked = 6
        }
        public enum LicenseType_OptionSet
        {
            Professional = 0,
            Administrative = 1,
            Basic = 2,
            DeviceProfessional = 3,
            DeviceBasic = 4,
            Essential = 5,
            DeviceEssential = 6,
            Enterprise = 7,
            DeviceEnterprise = 8,
            Sales = 9,
            Service = 10,
            FieldService = 11,
            ProjectService = 12
        }
        public enum OutgoingEmailDeliveryMethod_OptionSet
        {
            None = 0,
            MicrosoftDynamics365forOutlook = 1,
            Server_SideSynchronizationorEmailRouter = 2
        }
        public enum PreferredAddress_OptionSet
        {
            MailingAddress = 1,
            OtherAddress = 2
        }
        public enum PreferredEmail_OptionSet
        {
            DefaultValue = 1
        }
        public enum PreferredPhone_OptionSet
        {
            MainPhone = 1,
            OtherPhone = 2,
            HomePhone = 3,
            MobilePhone = 4
        }
        public enum PrimaryEmailStatus_OptionSet
        {
            Empty = 0,
            Approved = 1,
            PendingApproval = 2,
            Rejected = 3
        }
        public enum Type_OptionSet
        {
            CRMUser = 192350000,
            BOTUser = 192350001
        }
        public enum Usertype_OptionSet
        {
            Applicationuser = 192350000,
            Botapplicationuser = 192350001
        }

        #endregion OptionSets
    }
}
