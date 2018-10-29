using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class RandomService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Constructors
        public RandomService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {

        }
        #endregion Constructors

        #region Functions Random
        public AddressModel RandomAddressModel(TVItemModel tvItemModelCountry, TVItemModel tvItemModelProvince, TVItemModel tvItemModelMunicipality, bool Add)
        {
            AddressModel addressModel = new AddressModel();

            addressModel.CountryTVItemID = tvItemModelCountry.TVItemID;
            addressModel.ProvinceTVItemID = tvItemModelProvince.TVItemID;
            addressModel.MunicipalityTVItemID = tvItemModelMunicipality.TVItemID;
            addressModel.StreetName = RandomString("Street Name", "Street Name".Length + 3);
            addressModel.StreetNumber = RandomString("23", "23".Length + 2);
            addressModel.StreetType = StreetTypeEnum.Street;
            addressModel.AddressType = AddressTypeEnum.Mailing;
            //Assert.IsTrue(addressModel.CountryTVItemID != 0);
            //Assert.IsTrue(addressModel.ProvinceTVItemID != 0);
            //Assert.IsTrue(addressModel.MunicipalityTVItemID != 0);
            //Assert.IsTrue(addressModel.StreetType == StreetTypeEnum.Street);
            //Assert.IsTrue(addressModel.AddressType == AddressTypeEnum.Mailing);

            if (Add)
            {
                AddressService addressService = new AddressService(LanguageRequest, User);
                TVItemService tvItemService = new TVItemService(LanguageRequest, User);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                //Assert.AreEqual("", tvItemModelRoot.Error);

                string TVText = addressService.CreateTVText(addressModel);
                TVItemModel tvItemModelAddress = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Address);
                //Assert.AreEqual("", tvItemModelAddress.Error);

                addressModel.AddressTVItemID = tvItemModelAddress.TVItemID;

                AddressModel addressModelRet = addressService.PostAddAddressDB(addressModel);

                return addressModelRet;
            }

            return addressModel;
        }
        public AppErrLogModel RandomAppErrLogModel(bool Add)
        {
            AppErrLogModel appErrLogModel = new AppErrLogModel();

            appErrLogModel.Tag = RandomString("Tag Text", 10);
            appErrLogModel.DateTime_UTC = RandomDateTime();
            appErrLogModel.LineNumber = RandomInt(5, 150);
            appErrLogModel.Message = RandomString("Message text", 20);
            appErrLogModel.Source = RandomString("Source text", 20);
            //Assert.IsTrue(appErrLogModel.Tag.Length == 10);
            //Assert.IsTrue(appErrLogModel.DateTime_UTC != null);
            //Assert.IsTrue(appErrLogModel.LineNumber >= 5 && appErrLogModel.LineNumber <= 150);
            //Assert.IsTrue(appErrLogModel.Message.Length == 20);
            //Assert.IsTrue(appErrLogModel.Source.Length == 20);

            if (Add)
            {
                AppErrLogService appErrLogService = new AppErrLogService(LanguageRequest, User);

                AppErrLogModel appErrLogModelRet = appErrLogService.PostAddAppErrLogDB(appErrLogModel);

                return appErrLogModelRet;
            }

            return appErrLogModel;
        }
        public AppTaskLanguageModel RandomAppTaskLanguageModel(LanguageEnum Language)
        {
            AppTaskLanguageModel appTaskLanguageModel = new AppTaskLanguageModel();

            appTaskLanguageModel.Language = Language;
            appTaskLanguageModel.ErrorText = RandomString("Error Text", 20);
            appTaskLanguageModel.StatusText = RandomString("Status Text", 20);
            appTaskLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            //Assert.AreEqual(Language, appTaskLanguageModel.Language);
            //Assert.IsTrue(appTaskLanguageModel.ErrorText.Length == 20);
            //Assert.IsTrue(appTaskLanguageModel.StatusText.Length == 20);
            //Assert.IsTrue(appTaskLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);

            return appTaskLanguageModel;
        }
        public AppTaskModel RandomAppTaskModel(TVItemModel tvItemModelFirstTVItemID, TVItemModel tvItemModelSecondTVItemID, bool Add)
        {
            AppTaskModel appTaskModel = new AppTaskModel();

            appTaskModel.TVItemID = tvItemModelFirstTVItemID.TVItemID;
            appTaskModel.TVItemID2 = tvItemModelSecondTVItemID.TVItemID;
            appTaskModel.AppTaskCommand = AppTaskCommandEnum.MikeScenarioImport;
            appTaskModel.ErrorText = RandomString("ErrorText", 20);
            appTaskModel.StatusText = RandomString("StatusText", 20);
            appTaskModel.AppTaskStatus = AppTaskStatusEnum.Created;
            appTaskModel.PercentCompleted = RandomInt(0, 100);
            appTaskModel.Parameters = RandomString("TVPath,p1p5|||", "TVPath,p1p5|||".Length);
            appTaskModel.Language = LanguageEnum.en;
            appTaskModel.StartDateTime_UTC = RandomDateTime();
            appTaskModel.EndDateTime_UTC = appTaskModel.StartDateTime_UTC.AddHours(1);
            appTaskModel.EstimatedLength_second = RandomInt(3000, 5000);
            appTaskModel.RemainingTime_second = RandomInt(40000, 50000);
            //Assert.IsTrue(appTaskModel.TVItemID != 0);
            //Assert.IsTrue(appTaskModel.TVItemID2 != 0);
            //Assert.IsTrue(appTaskModel.Command == AppTaskCommandEnum.MikeScenarioImport);
            //Assert.IsTrue(appTaskModel.ErrorText.Length == 20);
            //Assert.IsTrue(appTaskModel.StatusText.Length == 20);
            //Assert.IsTrue(appTaskModel.Status == AppTaskStatusEnum.Created);
            //Assert.IsTrue(appTaskModel.PercentCompleted >= 0 && appTaskModel.PercentCompleted <= 100);
            //Assert.IsTrue(appTaskModel.Parameters == "TVPath,p1p5|||");
            //Assert.IsTrue(appTaskModel.Language == LanguageEnum.en);
            //Assert.IsTrue(appTaskModel.StartDateTime_UTC != null);
            //Assert.IsTrue(appTaskModel.EndDateTime_UTC != null);
            //Assert.IsTrue(appTaskModel.EndDateTime_UTC >= appTaskModel.StartDateTime_UTC);
            //Assert.IsTrue(appTaskModel.EstimatedLength_second >= 3000 && appTaskModel.EstimatedLength_second <= 5000);
            //Assert.IsTrue(appTaskModel.RemainingTime_second >= 40000 && appTaskModel.RemainingTime_second <= 50000);

            if (Add)
            {
                List<AppTaskLanguageModel> appTaskLanguageModelList = new List<AppTaskLanguageModel>()
                {
                    RandomAppTaskLanguageModel(LanguageEnum.en),
                    RandomAppTaskLanguageModel(LanguageEnum.fr),
                };

                AppTaskService appTaskService = new AppTaskService(LanguageRequest, User);

                AppTaskModel appTaskModelRet = appTaskService.PostAddAppTask(appTaskModel);

                return appTaskModelRet;
            }

            return appTaskModel;
        }
        public AspNetUserModel RandomAspNetUserModel(bool Add)
        {
            AspNetUserModel aspNetUserModel = new AspNetUserModel();

            string LoginEmail = RandomEmail();
            string Password = RandomPassword();

            ApplicationUser2 applicationUser = new ApplicationUser2() { UserName = LoginEmail };

            UserManager<ApplicationUser2> userManager = new UserManager<ApplicationUser2>(new UserStore<ApplicationUser2>(new IdentityDbContext("CSSPDBEntities")));

            try
            {
                IdentityResult result = userManager.Create(applicationUser, Password);
            }
            catch (Exception)
            {
                // nothing for now
            }

            aspNetUserModel.Id = applicationUser.Id;
            aspNetUserModel.Email = LoginEmail;
            aspNetUserModel.EmailConfirmed = applicationUser.EmailConfirmed;
            aspNetUserModel.PasswordHash = applicationUser.PasswordHash;
            aspNetUserModel.SecurityStamp = applicationUser.SecurityStamp;
            aspNetUserModel.PhoneNumber = applicationUser.PhoneNumber;
            aspNetUserModel.PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed;
            aspNetUserModel.TwoFactorEnabled = applicationUser.TwoFactorEnabled;
            aspNetUserModel.LockoutEndDateUtc = applicationUser.LockoutEndDateUtc;
            aspNetUserModel.LockoutEnabled = applicationUser.LockoutEnabled;
            aspNetUserModel.AccessFailedCount = applicationUser.AccessFailedCount;
            aspNetUserModel.UserName = LoginEmail;
            aspNetUserModel.LoginEmail = LoginEmail;
            aspNetUserModel.Password = Password;
            //Assert.IsFalse(string.IsNullOrWhiteSpace(LoginEmail));
            //Assert.IsFalse(string.IsNullOrWhiteSpace(Password));
            //Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.Id));
            //Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.Email));
            //Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.PasswordHash));
            //Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.SecurityStamp));
            //Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.UserName));
            //Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.LoginEmail));
            //Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.Password));
            //Assert.AreEqual(LoginEmail, aspNetUserModel.LoginEmail);
            //Assert.AreEqual(Password, aspNetUserModel.Password);

            if (Add)
            {

                AspNetUserService aspNetUserService = new AspNetUserService(LanguageRequest, User);

                AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);

                return aspNetUserModelRet;
            }

            return aspNetUserModel;
        }
        public BoxModelResultModel RandomBoxModelResultModel(BoxModelModel boxModelModel, bool Add)
        {
            BoxModelResultModel boxModelResultModel = new BoxModelResultModel();

            boxModelResultModel.BoxModelID = boxModelModel.BoxModelID;
            boxModelResultModel.BoxModelResultType = BoxModelResultTypeEnum.Dilution;
            boxModelResultModel.Volume_m3 = RandomDouble(1.0, 1000.0);
            boxModelResultModel.Surface_m2 = RandomDouble(1.0, 1000.0);
            boxModelResultModel.Radius_m = RandomDouble(1.0, 1000.0);
            boxModelResultModel.LeftSideDiameterLineAngle_deg = RandomDouble(1.0, 1000.0);
            boxModelResultModel.CircleCenterLatitude = RandomDouble(1.0, 1000.0);
            boxModelResultModel.CircleCenterLongitude = RandomDouble(1.0, 1000.0);
            boxModelResultModel.FixLength = true;
            boxModelResultModel.FixWidth = true;
            boxModelResultModel.RectLength_m = RandomDouble(1.0, 1000.0);
            boxModelResultModel.RectWidth_m = RandomDouble(1.0, 1000.0);
            boxModelResultModel.LeftSideLineAngle_deg = RandomDouble(1.0, 1000.0);
            boxModelResultModel.LeftSideLineStartLatitude = RandomDouble(1.0, 1000.0);
            boxModelResultModel.LeftSideLineStartLongitude = RandomDouble(1.0, 1000.0);
            //Assert.IsTrue(boxModelResultModel.BoxModelID == boxModelModel.BoxModelID);
            //Assert.IsTrue(boxModelResultModel.BoxModelResultType == BoxModelResultTypeEnum.Dilution);
            //Assert.IsTrue(boxModelResultModel.Volume_m3 >= 1 && boxModelResultModel.Volume_m3 <= 1000);
            //Assert.IsTrue(boxModelResultModel.Surface_m2 >= 1 && boxModelResultModel.Surface_m2 <= 1000);
            //Assert.IsTrue(boxModelResultModel.Radius_m >= 1 && boxModelResultModel.Radius_m <= 1000);
            //Assert.IsTrue(boxModelResultModel.LeftSideDiameterLineAngle_deg >= 1 && boxModelResultModel.LeftSideDiameterLineAngle_deg <= 1000);
            //Assert.IsTrue(boxModelResultModel.CircleCenterLatitude >= 1 && boxModelResultModel.CircleCenterLatitude <= 1000);
            //Assert.IsTrue(boxModelResultModel.CircleCenterLongitude >= 1 && boxModelResultModel.CircleCenterLongitude <= 1000);
            //Assert.IsTrue(boxModelResultModel.FixLength == true);
            //Assert.IsTrue(boxModelResultModel.FixWidth == true);
            //Assert.IsTrue(boxModelResultModel.RectLength_m >= 1 && boxModelResultModel.RectLength_m <= 1000);
            //Assert.IsTrue(boxModelResultModel.RectWidth_m >= 1 && boxModelResultModel.RectWidth_m <= 1000);
            //Assert.IsTrue(boxModelResultModel.LeftSideLineAngle_deg >= 1 && boxModelResultModel.LeftSideLineAngle_deg <= 1000);
            //Assert.IsTrue(boxModelResultModel.LeftSideLineStartLatitude >= 1 && boxModelResultModel.LeftSideLineStartLatitude <= 1000);
            //Assert.IsTrue(boxModelResultModel.LeftSideLineStartLongitude >= 1 && boxModelResultModel.LeftSideLineStartLongitude <= 1000);

            if (Add)
            {

                BoxModelResultService boxModelResultService = new BoxModelResultService(LanguageRequest, User);

                BoxModelResultModel boxModelResultModelRet = boxModelResultService.PostAddBoxModelResultDB(boxModelResultModel);

                return boxModelResultModelRet;
            }

            return boxModelResultModel;

        }
        public BoxModelLanguageModel RandomBoxModelLanguageModel(LanguageEnum Language)
        {
            BoxModelLanguageModel boxModelLanguageModel = new BoxModelLanguageModel();

            boxModelLanguageModel.Language = Language;
            boxModelLanguageModel.ScenarioName = RandomString("Scenario Name", 20);
            boxModelLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            //Assert.AreEqual(Language, boxModelLanguageModel.Language);
            //Assert.IsTrue(boxModelLanguageModel.ScenarioName.Length == 20);
            //Assert.IsTrue(boxModelLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);

            return boxModelLanguageModel;
        }
        public BoxModelModel RandomBoxModelModel(TVItemModel tvItemModelInfrastructure, bool Add)
        {
            BoxModelModel boxModelModel = new BoxModelModel();

            boxModelModel.InfrastructureTVItemID = tvItemModelInfrastructure.TVItemID;
            boxModelModel.ScenarioName = RandomString("ScenarioName", 20);
            boxModelModel.T90_hour = RandomInt(5, 7);
            boxModelModel.Temperature_C = RandomInt(9, 12);
            boxModelModel.DecayRate_per_day = RandomFloat(4.0f, 6.0f);
            boxModelModel.Discharge_m3_day = RandomFloat(1000.0f, 2000.0f);
            boxModelModel.DischargeDuration_hour = RandomInt(20, 24);
            boxModelModel.Dilution = RandomInt(100, 1000);
            boxModelModel.Depth_m = RandomFloat(2.0f, 4.0f);
            boxModelModel.FCUntreated_MPN_100ml = RandomInt(3000000, 3600000);
            boxModelModel.FCPreDisinfection_MPN_100ml = RandomInt(700, 900);
            boxModelModel.Concentration_MPN_100ml = RandomInt(14, 14);
            boxModelModel.FixLength = false;
            boxModelModel.Length_m = 0;
            boxModelModel.FixWidth = false;
            boxModelModel.Width_m = 0;
            //Assert.IsTrue(boxModelModel.InfrastructureTVItemID != 0);
            //Assert.IsTrue(boxModelModel.ScenarioName.Length == 20);
            //Assert.IsTrue(boxModelModel.T90_hour >= 5 && boxModelModel.T90_hour <= 7);
            //Assert.IsTrue(boxModelModel.Temperature_C >= 9 && boxModelModel.Temperature_C <= 12);
            //Assert.IsTrue(boxModelModel.DecayRate_per_day >= 4.0f && boxModelModel.DecayRate_per_day <= 6.0f);
            //Assert.IsTrue(boxModelModel.Discharge_m3_day >= 1000.0f && boxModelModel.Discharge_m3_day <= 2000.0f);
            //Assert.IsTrue(boxModelModel.DischargeDuration_hour >= 20 && boxModelModel.DischargeDuration_hour <= 24);
            //Assert.IsTrue(boxModelModel.Dilution >= 1000.0f && boxModelModel.Dilution <= 1001.0f);
            //Assert.IsTrue(boxModelModel.Depth_m >= 2.0f && boxModelModel.Depth_m <= 4.0f);
            //Assert.IsTrue(boxModelModel.FCUntreated_MPN_100ml >= 3000000.0f && boxModelModel.FCUntreated_MPN_100ml <= 3600000.0f);
            //Assert.IsTrue(boxModelModel.FCPreDisinfection_MPN_100ml >= 700.0f && boxModelModel.FCPreDisinfection_MPN_100ml <= 900.0f);
            //Assert.IsTrue(boxModelModel.Concentration_MPN_100ml >= 14 && boxModelModel.Concentration_MPN_100ml <= 14);
            //Assert.IsFalse(boxModelModel.FixLength);
            //Assert.IsTrue(boxModelModel.Length_m == 0);
            //Assert.IsFalse(boxModelModel.FixWidth);
            //Assert.IsTrue(boxModelModel.Width_m == 0);

            if (Add)
            {
                BoxModelService boxModelService = new BoxModelService(LanguageRequest, User);

                BoxModelModel boxModelModelRet = boxModelService.PostAddBoxModelDB(boxModelModel);

                return boxModelModelRet;
            }

            return boxModelModel;
        }
        public ClimateDataValueModel RandomClimateDataValueModel(ClimateSiteModel climateSiteModel, bool Add)
        {
            ClimateDataValueModel climateDataValueModel = new ClimateDataValueModel();

            climateDataValueModel.ClimateSiteID = climateSiteModel.ClimateSiteID;
            climateDataValueModel.DateTime_Local = RandomDateTime();
            climateDataValueModel.Keep = true;
            climateDataValueModel.StorageDataType = StorageDataTypeEnum.Archived;
            climateDataValueModel.HasBeenRead = true;
            climateDataValueModel.CoolDegDays_C = RandomDouble(0, 45);
            climateDataValueModel.DirMaxGust_0North = RandomDouble(0, 360);
            climateDataValueModel.HeatDegDays_C = RandomDouble(0, 45);
            climateDataValueModel.MaxTemp_C = RandomDouble(-45, 45);
            climateDataValueModel.MinTemp_C = RandomDouble(-45, 45);
            climateDataValueModel.Rainfall_mm = RandomDouble(0, 1000);
            climateDataValueModel.RainfallEntered_mm = RandomDouble(0, 1000);
            climateDataValueModel.Snow_cm = RandomDouble(0, 10000);
            climateDataValueModel.SnowOnGround_cm = RandomDouble(0, 10000);
            climateDataValueModel.SpdMaxGust_kmh = RandomDouble(0, 200);
            climateDataValueModel.TotalPrecip_mm_cm = RandomDouble(0, 1000);
            //Assert.IsTrue(climateDataValueModel.ClimateSiteID != 0);
            //Assert.IsTrue(climateDataValueModel.DateTime_Local != null);
            //Assert.IsTrue(climateDataValueModel.Keep == true);
            //Assert.IsTrue(climateDataValueModel.StorageDataType == StorageDataTypeEnum.Archived);
            //Assert.IsTrue(climateDataValueModel.CoolDegDays_C >= 0 && climateDataValueModel.CoolDegDays_C <= 45);
            //Assert.IsTrue(climateDataValueModel.DirMaxGust_0North >= 0 && climateDataValueModel.DirMaxGust_0North <= 360);
            //Assert.IsTrue(climateDataValueModel.HeatDegDays_C >= 0 && climateDataValueModel.HeatDegDays_C <= 45);
            //Assert.IsTrue(climateDataValueModel.MaxTemp_C >= -45 && climateDataValueModel.MaxTemp_C <= 45);
            //Assert.IsTrue(climateDataValueModel.MinTemp_C >= -45 && climateDataValueModel.MinTemp_C <= 45);
            //Assert.IsTrue(climateDataValueModel.Rainfall_mm >= 0 && climateDataValueModel.Rainfall_mm <= 1000);
            //Assert.IsTrue(climateDataValueModel.RainfallEntered_mm >= 0 && climateDataValueModel.RainfallEntered_mm <= 1000);
            //Assert.IsTrue(climateDataValueModel.Snow_cm >= 0 && climateDataValueModel.Snow_cm <= 10000);
            //Assert.IsTrue(climateDataValueModel.SnowOnGround_cm >= 0 && climateDataValueModel.SnowOnGround_cm <= 10000);
            //Assert.IsTrue(climateDataValueModel.SpdMaxGust_kmh >= 0 && climateDataValueModel.SpdMaxGust_kmh <= 200);
            //Assert.IsTrue(climateDataValueModel.TotalPrecip_mm_cm >= 0 && climateDataValueModel.TotalPrecip_mm_cm <= 1000);

            if (Add)
            {

                ClimateDataValueService climateDataValueService = new ClimateDataValueService(LanguageRequest, User);

                ClimateDataValueModel climateDataValueModelRet = climateDataValueService.PostAddClimateDataValueDB(climateDataValueModel);

                return climateDataValueModelRet;
            }

            return climateDataValueModel;
        }
        public ClimateSiteModel RandomClimateSiteModel(TVItemModel tvItemModelClimateSite, bool Add)
        {
            ClimateSiteModel climateSiteModel = new ClimateSiteModel();

            climateSiteModel.ClimateSiteTVItemID = tvItemModelClimateSite.TVItemID;
            climateSiteModel.ClimateID = RandomString("81004", 10);
            climateSiteModel.ClimateSiteName = RandomString("BAS CARAQUET", 15);
            climateSiteModel.DailyStartDate_Local = RandomDateTime();
            climateSiteModel.DailyEndDate_Local = climateSiteModel.DailyStartDate_Local.Value.AddHours(1);
            climateSiteModel.DailyNow = true;
            climateSiteModel.ECDBID = RandomInt(6918, 7918);
            climateSiteModel.Elevation_m = RandomInt(0, 10000);
            climateSiteModel.File_desc = RandomString("File_desc", 30);
            climateSiteModel.HourlyStartDate_Local = RandomDateTime();
            climateSiteModel.HourlyEndDate_Local = climateSiteModel.HourlyStartDate_Local.Value.AddHours(1);
            climateSiteModel.HourlyNow = true;
            climateSiteModel.IsProvincial = true;
            climateSiteModel.MonthlyStartDate_Local = RandomDateTime();
            climateSiteModel.MonthlyEndDate_Local = climateSiteModel.MonthlyStartDate_Local.Value.AddHours(1);
            climateSiteModel.MonthlyNow = false;
            climateSiteModel.Province = RandomString("NB", 2);
            climateSiteModel.ProvSiteID = RandomString("NB", 5);
            climateSiteModel.TCID = RandomString("WX", 3);
            climateSiteModel.TimeOffset_hour = RandomInt(-8, -3);
            climateSiteModel.WMOID = RandomInt(10000, 99999);
            //Assert.IsTrue(climateSiteModel.ClimateSiteTVItemID > 0);
            //Assert.IsTrue(climateSiteModel.ClimateID.Length == 10);
            //Assert.IsTrue(climateSiteModel.ClimateSiteName.Length == 15);
            //Assert.IsTrue(climateSiteModel.DailyEndDate_Local != null);
            //Assert.IsTrue(climateSiteModel.DailyNow == true);
            //Assert.IsTrue(climateSiteModel.DailyStartDate_Local != null);
            //Assert.IsTrue(climateSiteModel.ECDBID >= 6918 && climateSiteModel.ECDBID <= 7918);
            //Assert.IsTrue(climateSiteModel.Elevation_m >= 0 && climateSiteModel.Elevation_m <= 10000);
            //Assert.IsTrue(climateSiteModel.File_desc.Length == 30);
            //Assert.IsTrue(climateSiteModel.HourlyEndDate_Local != null);
            //Assert.IsTrue(climateSiteModel.HourlyStartDate_Local != null);
            //Assert.IsTrue(climateSiteModel.IsProvincial == true);
            //Assert.IsTrue(climateSiteModel.MonthlyEndDate_Local != null);
            //Assert.IsTrue(climateSiteModel.MonthlyNow == false);
            //Assert.IsTrue(climateSiteModel.MonthlyStartDate_Local != null);
            //Assert.IsTrue(climateSiteModel.Province == "NB");
            //Assert.IsTrue(climateSiteModel.ProvSiteID.Length == 5);
            //Assert.IsTrue(climateSiteModel.TCID.Length == 3);
            //Assert.IsTrue(climateSiteModel.TimeOffset_hour >= -8 && climateSiteModel.TimeOffset_hour <= -4);
            //Assert.IsTrue(climateSiteModel.WMOID >= 10000 && climateSiteModel.WMOID <= 99999);

            if (Add)
            {

                ClimateSiteService climateSiteService = new ClimateSiteService(LanguageRequest, User);

                ClimateSiteModel climateSiteModelRet = climateSiteService.PostAddClimateSiteDB(climateSiteModel);

                return climateSiteModelRet;
            }

            return climateSiteModel;
        }
        public ContactModel RandomContactModel()
        {
            ContactModel contactModel = new ContactModel();

            contactModel.Id = RandomGuid().ToString();
            contactModel.LoginEmail = RandomEmail();
            contactModel.FirstName = RandomString("FirstName", 14);
            contactModel.Initial = RandomString("Init", 8);
            contactModel.LastName = RandomString("LastName", 14);
            contactModel.WebName = RandomString("WebName", 14);
            contactModel.IsAdmin = true;
            contactModel.EmailValidated = true;
            contactModel.Disabled = false;

            return contactModel;
        }
        public EmailModel RandomEmailModel(bool Add)
        {
            EmailModel emailModel = new EmailModel();

            emailModel.EmailTVItemID = 1; // will be replace
            emailModel.EmailAddress = RandomEmail();
            emailModel.EmailType = EmailTypeEnum.Work;
            //Assert.IsTrue(emailModel.EmailTVItemID > 0);
            //Assert.IsTrue(emailModel.EmailAddress != null);
            //Assert.IsTrue(emailModel.EmailType == EmailTypeEnum.Work);

            if (Add)
            {

                EmailService emailService = new EmailService(LanguageRequest, User);

                TVItemModel tvItemModelRoot = emailService._TVItemService.GetRootTVItemModelDB();

                //Assert.AreEqual("", tvItemModelRoot.Error);

                string TVText = emailService.CreateTVText(emailModel);

                // Asssert
                //Assert.IsTrue(!string.IsNullOrWhiteSpace(TVText));

                TVItemModel tvItemEmail = emailService._TVItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Email);

                //Assert.AreEqual("", tvItemEmail.Error);

                emailModel.EmailTVItemID = tvItemEmail.TVItemID;

                EmailModel emailModelRet = emailService.PostAddEmailDB(emailModel);

                return emailModelRet;
            }

            return emailModel;
        }
        public HydrometricDataValueModel RandomHydrometricDataValueModel(HydrometricSiteModel hydrometricSiteModel, bool Add)
        {
            HydrometricDataValueModel hydrometricDataValueModel = new HydrometricDataValueModel();

            hydrometricDataValueModel.HydrometricSiteID = hydrometricSiteModel.HydrometricSiteID;
            hydrometricDataValueModel.DateTime_Local = RandomDateTime();
            hydrometricDataValueModel.Discharge_m3_s = RandomDouble(0, 2000);
            hydrometricDataValueModel.DischargeEntered_m3_s = RandomDouble(0, 2000);
            hydrometricDataValueModel.Level_m = RandomDouble(0, 2000);
            hydrometricDataValueModel.StorageDataType = StorageDataTypeEnum.Archived;
            //Assert.IsTrue(hydrometricDataValueModel.DateTime_Local != null);
            //Assert.IsTrue(hydrometricDataValueModel.Discharge_m3_s >= 0 && hydrometricDataValueModel.Discharge_m3_s <= 20000);

            if (Add)
            {

                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(LanguageRequest, User);

                HydrometricDataValueModel hydrometricDataValueModelRet = hydrometricDataValueService.PostAddHydrometricDataValueDB(hydrometricDataValueModel);

                return hydrometricDataValueModelRet;
            }

            return hydrometricDataValueModel;
        }
        public HydrometricSiteModel RandomHydrometricSiteModel(TVItemModel tvItemModelParent, TVItemModel tvItemModelHydrometricSite, bool Add)
        {
            HydrometricSiteModel hydrometricSiteModel = new HydrometricSiteModel();

            hydrometricSiteModel.HydrometricSiteTVItemID = tvItemModelHydrometricSite.TVItemID;
            hydrometricSiteModel.FedSiteNumber = RandomString("01BL", 7);
            hydrometricSiteModel.HydrometricSiteName = RandomString("Hydro site ", 20);
            hydrometricSiteModel.QuebecSiteNumber = RandomString("01", 7);
            hydrometricSiteModel.Description = RandomString("", 100);
            hydrometricSiteModel.Province = RandomString("NB", 2);
            hydrometricSiteModel.Elevation_m = RandomInt(0, 10000);
            hydrometricSiteModel.StartDate_Local = RandomDateTime();
            hydrometricSiteModel.EndDate_Local = hydrometricSiteModel.StartDate_Local.Value.AddHours(1);
            hydrometricSiteModel.TimeOffset_hour = RandomInt(-8, -3);
            hydrometricSiteModel.DrainageArea_km2 = RandomInt(1, 1000000);
            hydrometricSiteModel.IsNatural = true;
            hydrometricSiteModel.IsActive = true;
            hydrometricSiteModel.Sediment = true;
            hydrometricSiteModel.RHBN = true;
            hydrometricSiteModel.RealTime = true;
            hydrometricSiteModel.HasRatingCurve = true;
            //Assert.IsTrue(hydrometricSiteModel.HydrometricSiteTVItemID > 0);
            //Assert.IsTrue(hydrometricSiteModel.FedSiteNumber.Length == 7);
            //Assert.IsTrue(hydrometricSiteModel.HydrometricSiteName.Length == 20);
            //Assert.IsTrue(hydrometricSiteModel.QuebecSiteNumber.Length == 7);
            //Assert.IsTrue(hydrometricSiteModel.Description.Length == 100);
            //Assert.IsTrue(hydrometricSiteModel.Province == "NB");
            //Assert.IsTrue(hydrometricSiteModel.Elevation_m >= 0 && hydrometricSiteModel.Elevation_m <= 10000);
            //Assert.IsTrue(hydrometricSiteModel.StartDate_Local != null);
            //Assert.IsTrue(hydrometricSiteModel.EndDate_Local != null);
            //Assert.IsTrue(hydrometricSiteModel.TimeOffset_hour >= -8 && hydrometricSiteModel.TimeOffset_hour <= -3);
            //Assert.IsTrue(hydrometricSiteModel.DrainageArea_km2 >= 1 && hydrometricSiteModel.DrainageArea_km2 <= 1000000);
            //Assert.IsTrue(hydrometricSiteModel.IsNatural == true);
            //Assert.IsTrue(hydrometricSiteModel.IsActive == true);
            //Assert.IsTrue(hydrometricSiteModel.Sediment == true);
            //Assert.IsTrue(hydrometricSiteModel.RHBN == true);
            //Assert.IsTrue(hydrometricSiteModel.RealTime == true);
            //Assert.IsTrue(hydrometricSiteModel.HasRatingCurve == true);

            if (Add)
            {

                HydrometricSiteService hydrometricSiteService = new HydrometricSiteService(LanguageRequest, User);
                HydrometricSiteModel hydrometricSiteModelRet = hydrometricSiteService.PostAddHydrometricSiteDB(hydrometricSiteModel);

                return hydrometricSiteModelRet;
            }

            return hydrometricSiteModel;
        }
        public InfrastructureLanguageModel RandomInfrastructureLanguageModel(LanguageEnum Language)
        {
            InfrastructureLanguageModel infrastructureLanguageModel = new InfrastructureLanguageModel();

            infrastructureLanguageModel.Language = Language;
            infrastructureLanguageModel.Comment = RandomString("Comment", 200);
            infrastructureLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;
            //Assert.AreEqual(LanguageEnum.en, infrastructureLanguageModel.Language);
            //Assert.IsTrue(infrastructureLanguageModel.Comment.Length == 200);
            //Assert.IsTrue(infrastructureLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);

            return infrastructureLanguageModel;
        }
        public InfrastructureModel RandomInfrastructureModel(TVItemModel tvItemModelInfrastructure, bool Add)
        {
            InfrastructureModel infrastructureModel = new InfrastructureModel();

            infrastructureModel.InfrastructureTVItemID = tvItemModelInfrastructure.TVItemID;
            infrastructureModel.InfrastructureTVText = RandomString("Infrastructure", 30);
            infrastructureModel.Comment = RandomString("Comment", 80);
            infrastructureModel.PrismID = RandomInt(1, 100);
            infrastructureModel.TPID = RandomInt(1, 100);
            infrastructureModel.LSID = RandomInt(1, 100);
            infrastructureModel.SiteID = RandomInt(1, 100);
            infrastructureModel.Site = RandomInt(1, 100);
            infrastructureModel.InfrastructureCategory = "A";
            infrastructureModel.InfrastructureType = InfrastructureTypeEnum.LiftStation;
            infrastructureModel.TreatmentType = TreatmentTypeEnum.BioFilmReactor;
            infrastructureModel.DisinfectionType = DisinfectionTypeEnum.ChlorinationWithDechlorination;
            infrastructureModel.CollectionSystemType = CollectionSystemTypeEnum.Combined50Separated50;
            infrastructureModel.AlarmSystemType = AlarmSystemTypeEnum.SCADA;
            infrastructureModel.DesignFlow_m3_day = RandomDouble(1, 100000);
            infrastructureModel.AverageFlow_m3_day = RandomDouble(1, 100000);
            infrastructureModel.PeakFlow_m3_day = RandomDouble(1, 100000);
            infrastructureModel.PopServed = RandomInt(50, 100000);
            infrastructureModel.CanOverflow = true;
            infrastructureModel.PercFlowOfTotal = RandomDouble(0, 100);
            infrastructureModel.TimeOffset_hour = RandomDouble(-8, -4);
            infrastructureModel.TempCatchAllRemoveLater = RandomString("TempCatchAllRemoveLater", 200);
            infrastructureModel.AverageDepth_m = RandomDouble(0.1, 1000);
            infrastructureModel.NumberOfPorts = RandomInt(1, 100);
            infrastructureModel.PortDiameter_m = RandomDouble(0.1, 10);
            infrastructureModel.PortSpacing_m = RandomDouble(0.1, 10000);
            infrastructureModel.PortElevation_m = RandomDouble(0.1, 10000);
            infrastructureModel.VerticalAngle_deg = RandomDouble(-90, 90);
            infrastructureModel.HorizontalAngle_deg = RandomDouble(-180, 180);
            infrastructureModel.DecayRate_per_day = RandomDouble(0, 1000);
            infrastructureModel.NearFieldVelocity_m_s = RandomDouble(0, 10);
            infrastructureModel.FarFieldVelocity_m_s = RandomDouble(0, 10);
            infrastructureModel.ReceivingWaterSalinity_PSU = RandomDouble(0, 35);
            infrastructureModel.ReceivingWaterTemperature_C = RandomDouble(0, 35);
            infrastructureModel.ReceivingWater_MPN_per_100ml = RandomInt(0, 1000000);
            infrastructureModel.DistanceFromShore_m = RandomDouble(0, 10000);

            //Assert.IsTrue(infrastructureModel.InfrastructureTVItemID != 0);
            //Assert.IsTrue(infrastructureModel.InfrastructureTVText.Length == 30);
            //Assert.IsTrue(infrastructureModel.Comment.Length == 80);
            //Assert.IsTrue(infrastructureModel.PrismID >= 1 && infrastructureModel.PrismID <= 100);
            //Assert.IsTrue(infrastructureModel.TPID >= 1 && infrastructureModel.TPID <= 100);
            //Assert.IsTrue(infrastructureModel.LSID >= 1 && infrastructureModel.LSID <= 100);
            //Assert.IsTrue(infrastructureModel.SiteID >= 1 && infrastructureModel.SiteID <= 100);
            //Assert.IsTrue(infrastructureModel.Site >= 1 && infrastructureModel.Site <= 100);
            //Assert.IsTrue(infrastructureModel.InfrastructureCategory == "A");
            //Assert.IsTrue(infrastructureModel.InfrastructureType == InfrastructureTypeEnum.LiftStation);
            //Assert.IsTrue(infrastructureModel.TreatmentType == TreatmentTypeEnum.BioFilmReactor);
            //Assert.IsTrue(infrastructureModel.DisinfectionType == DisinfectionTypeEnum.ChlorinationWithDechlorination);
            //Assert.IsTrue(infrastructureModel.CollectionSystemType == CollectionSystemTypeEnum.Combined50Separated50);
            //Assert.IsTrue(infrastructureModel.AlarmSystemType == AlarmSystemTypeEnum.SCADA);
            //Assert.IsTrue(infrastructureModel.DesignFlow_m3_day >= 1 && infrastructureModel.DesignFlow_m3_day <= 100000);
            //Assert.IsTrue(infrastructureModel.AverageFlow_m3_day >= 1 && infrastructureModel.AverageFlow_m3_day <= 100000);
            //Assert.IsTrue(infrastructureModel.PeakFlow_m3_day >= 1 && infrastructureModel.PeakFlow_m3_day <= 100000);
            //Assert.IsTrue(infrastructureModel.PopServed >= 50 && infrastructureModel.PopServed <= 100000);
            //Assert.IsTrue(infrastructureModel.CanOverflow == true);
            //Assert.IsTrue(infrastructureModel.PercFlowOfTotal >= 0 && infrastructureModel.PercFlowOfTotal <= 100);
            //Assert.IsTrue(infrastructureModel.TimeOffset_hour >= -8 && infrastructureModel.TimeOffset_hour <= -4);
            //Assert.IsTrue(infrastructureModel.TempCatchAllRemoveLater.Length == 200);
            //Assert.IsTrue(infrastructureModel.AverageDepth_m >= 0.1 && infrastructureModel.AverageDepth_m <= 1000);
            //Assert.IsTrue(infrastructureModel.NumberOfPorts >= 1 && infrastructureModel.NumberOfPorts <= 100);
            //Assert.IsTrue(infrastructureModel.PortDiameter_m >= 0.1 && infrastructureModel.PortDiameter_m <= 10);
            //Assert.IsTrue(infrastructureModel.PortSpacing_m >= 0.1 && infrastructureModel.PortSpacing_m <= 10000);
            //Assert.IsTrue(infrastructureModel.PortElevation_m >= 0.1 && infrastructureModel.PortElevation_m <= 10000);
            //Assert.IsTrue(infrastructureModel.VerticalAngle_deg >= -90 && infrastructureModel.VerticalAngle_deg <= 90);
            //Assert.IsTrue(infrastructureModel.HorizontalAngle_deg >= -180 && infrastructureModel.HorizontalAngle_deg <= 180);
            //Assert.IsTrue(infrastructureModel.DecayRate_per_day >= 0 && infrastructureModel.DecayRate_per_day <= 1000);
            //Assert.IsTrue(infrastructureModel.NearFieldVelocity_m_s >= 0 && infrastructureModel.NearFieldVelocity_m_s <= 10);
            //Assert.IsTrue(infrastructureModel.FarFieldVelocity_m_s >= 0 && infrastructureModel.FarFieldVelocity_m_s <= 10);
            //Assert.IsTrue(infrastructureModel.ReceivingWaterSalinity_PSU >= 0 && infrastructureModel.ReceivingWaterSalinity_PSU <= 35);
            //Assert.IsTrue(infrastructureModel.ReceivingWaterTemperature_C >= 0 && infrastructureModel.ReceivingWaterTemperature_C <= 35);
            //Assert.IsTrue(infrastructureModel.ReceivingWater_MPN_per_100ml >= 0 && infrastructureModel.ReceivingWater_MPN_per_100ml <= 1000000);
            //Assert.IsTrue(infrastructureModel.ReceivingWaterSalinity_PSU >= 0 && infrastructureModel.ReceivingWaterSalinity_PSU <= 35);
            //Assert.IsTrue(infrastructureModel.DistanceFromShore_m >= 0 && infrastructureModel.DistanceFromShore_m <= 10000);

            if (Add)
            {
                InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, User);
                InfrastructureModel infrastructureModelRet = infrastructureService.PostAddInfrastructureDB(infrastructureModel);

                return infrastructureModelRet;
            }

            return infrastructureModel;
        }
        public MapInfoPointModel RandomMapInfoPointModel(MapInfoModel mapInfoModel, bool Add)
        {
            MapInfoPointModel mapInfoPointModel = new MapInfoPointModel();

            mapInfoPointModel.MapInfoID = mapInfoModel.MapInfoID;
            mapInfoPointModel.Lat = RandomDouble(45, 46);
            mapInfoPointModel.Lng = RandomDouble(-66, -65);
            mapInfoPointModel.Ordinal = RandomInt(0, 100);
            //Assert.IsTrue(mapInfoPointModel.MapInfoID != 0);
            //Assert.IsTrue(mapInfoPointModel.Lat >= 45 && mapInfoPointModel.Lat <= 46);
            //Assert.IsTrue(mapInfoPointModel.Lng >= -66 && mapInfoPointModel.Lng <= -65);
            //Assert.IsTrue(mapInfoPointModel.Ordinal >= 0 && mapInfoPointModel.Ordinal <= 100);

            if (Add)
            {

                MapInfoPointService mapInfoPointService = new MapInfoPointService(LanguageRequest, User);

                MapInfoPointModel mapInfoPointModelRet = mapInfoPointService.PostAddMapInfoPointDB(mapInfoPointModel);

                return mapInfoPointModelRet;
            }

            return mapInfoPointModel;
        }
        public MapInfoModel RandomMapInfoModel(TVItemModel tvItemModel, bool Add)
        {
            MapInfoModel mapInfoModel = new MapInfoModel();

            mapInfoModel.TVItemID = tvItemModel.TVItemID;
            mapInfoModel.TVType = TVTypeEnum.Municipality;
            //Assert.IsTrue(mapInfoModel.TVItemID != 0);
            //Assert.IsTrue(mapInfoModel.TVType == TVTypeEnum.Municipality);

            if (Add)
            {

                MapInfoService mapInfoService = new MapInfoService(LanguageRequest, User);

                MapInfoModel mapInfoModelRet = mapInfoService.PostAddMapInfoDB(mapInfoModel);

                return mapInfoModelRet;
            }

            return mapInfoModel;
        }
        public MikeBoundaryConditionModel RandomMikeBoundaryConditionModel(TVItemModel tvItemModelParent, TVItemModel tvItemModel, bool Add)
        {
            MikeBoundaryConditionModel mikeBoundaryConditionModel = new MikeBoundaryConditionModel();

            mikeBoundaryConditionModel.MikeBoundaryConditionTVItemID = tvItemModel.TVItemID;
            mikeBoundaryConditionModel.MikeBoundaryConditionTVText = RandomString("BC ", 20);
            mikeBoundaryConditionModel.MikeBoundaryConditionCode = RandomString("BC Code", 12);
            mikeBoundaryConditionModel.MikeBoundaryConditionFormat = RandomString("BC Format", 12);
            mikeBoundaryConditionModel.MikeBoundaryConditionLength_m = RandomInt(10, 10000);
            mikeBoundaryConditionModel.MikeBoundaryConditionName = RandomString("BC Name", 12);
            mikeBoundaryConditionModel.MikeBoundaryConditionLevelOrVelocity = MikeBoundaryConditionLevelOrVelocityEnum.Level;
            mikeBoundaryConditionModel.NumberOfWebTideNodes = RandomInt(10, 10000);
            mikeBoundaryConditionModel.WebTideDataSet = WebTideDataSetEnum.flood;
            mikeBoundaryConditionModel.WebTideDataFromStartToEndDate = "";
            mikeBoundaryConditionModel.TVType = TVTypeEnum.MikeBoundaryConditionWebTide;
            //Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionTVItemID != 0);
            //Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionTVText.Length == 20);
            //Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionCode.Length == 12);
            //Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionFormat.Length == 12);
            //Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionLength_m >= 10 && mikeBoundaryConditionModel.MikeBoundaryConditionLength_m <= 10000);
            //Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionName.Length == 12);
            //Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionLevelOrVelocity == MikeBoundaryConditionLevelOrVelocityEnum.Level);
            //Assert.IsTrue(mikeBoundaryConditionModel.NumberOfWebTideNodes >= 10 && mikeBoundaryConditionModel.NumberOfWebTideNodes <= 10000);
            //Assert.IsTrue(mikeBoundaryConditionModel.WebTideDataSet == WebTideDataSetEnum.flood);
            //Assert.IsTrue(mikeBoundaryConditionModel.WebTideDataFromStartToEndDate == "");
            //Assert.IsTrue(mikeBoundaryConditionModel.TVType == TVTypeEnum.MikeBoundaryConditionWebTide);

            if (Add)
            {
                MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(LanguageRequest, User);

                MikeBoundaryConditionModel mikeBoundaryConditionModelRet = mikeBoundaryConditionService.PostAddMikeBoundaryConditionDB(mikeBoundaryConditionModel);

                return mikeBoundaryConditionModelRet;
            }

            return mikeBoundaryConditionModel;
        }
        public MikeScenarioModel RandomMikeScenarioModel(TVItemModel tvItemModelMikeScenario, bool Add)
        {
            MikeScenarioModel mikeScenarioModel = new MikeScenarioModel();
            mikeScenarioModel.MikeScenarioTVItemID = tvItemModelMikeScenario.TVItemID;
            mikeScenarioModel.MikeScenarioTVText = RandomString("MikeScenario", 30);
            mikeScenarioModel.AmbientSalinity_PSU = RandomDouble(0, 35);
            mikeScenarioModel.AmbientTemperature_C = RandomDouble(0, 35);
            mikeScenarioModel.DecayFactor_per_day = RandomDouble(4.0f, 6.0f);
            mikeScenarioModel.DecayFactorAmplitude = mikeScenarioModel.DecayFactor_per_day - (double)0.1D;
            mikeScenarioModel.DecayIsConstant = true;
            mikeScenarioModel.ErrorInfo = RandomString("Error info", 200);
            mikeScenarioModel.EstimatedHydroFileSize = RandomInt(100, 4000000);
            mikeScenarioModel.EstimatedTransFileSize = RandomInt(100, 4000000);
            mikeScenarioModel.ManningNumber = RandomDouble(20D, 40D);
            mikeScenarioModel.MikeScenarioStartDateTime_Local = RandomDateTime();
            mikeScenarioModel.MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local.AddHours(1);
            mikeScenarioModel.MikeScenarioExecutionTime_min = RandomDouble(10, 1000);
            mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local = RandomDateTime();
            mikeScenarioModel.NumberOfElements = RandomInt(10, 6000);
            mikeScenarioModel.NumberOfHydroOutputParameters = RandomInt(2, 20);
            mikeScenarioModel.NumberOfSigmaLayers = RandomInt(2, 5);
            mikeScenarioModel.NumberOfTimeSteps = RandomInt(20, 80);
            mikeScenarioModel.NumberOfTransOutputParameters = RandomInt(2, 20);
            mikeScenarioModel.NumberOfZLayers = RandomInt(2, 8);
            mikeScenarioModel.ResultFrequency_min = RandomInt(5, 60);
            mikeScenarioModel.ParentMikeScenarioID = null;
            mikeScenarioModel.ScenarioStatus = ScenarioStatusEnum.Changing;
            mikeScenarioModel.WindDirection_deg = RandomDouble(0, 360);
            mikeScenarioModel.WindSpeed_km_h = RandomDouble(0, 100);
            //Assert.IsTrue(mikeScenarioModel.MikeScenarioTVItemID != 0);
            //Assert.IsTrue(mikeScenarioModel.MikeScenarioTVText.Length == 30);
            //Assert.IsTrue(mikeScenarioModel.AmbientSalinity_PSU >= 0 && mikeScenarioModel.AmbientSalinity_PSU <= 35);
            //Assert.IsTrue(mikeScenarioModel.AmbientTemperature_C >= 0 && mikeScenarioModel.AmbientTemperature_C <= 35);
            //Assert.IsTrue(mikeScenarioModel.DecayFactor_per_day >= 4 && mikeScenarioModel.DecayFactor_per_day <= 6);
            //Assert.IsTrue(mikeScenarioModel.DecayFactorAmplitude < mikeScenarioModel.DecayFactor_per_day);
            //Assert.IsTrue(mikeScenarioModel.DecayIsConstant == true);
            //Assert.IsTrue(mikeScenarioModel.ErrorInfo.Length == 200);
            //Assert.IsTrue(mikeScenarioModel.EstimatedHydroFileSize >= 100 && mikeScenarioModel.EstimatedHydroFileSize <= 4000000);
            //Assert.IsTrue(mikeScenarioModel.EstimatedTransFileSize >= 100 && mikeScenarioModel.EstimatedTransFileSize <= 4000000);
            //Assert.IsTrue(mikeScenarioModel.ManningNumber >= 20 && mikeScenarioModel.ManningNumber <= 40);
            //Assert.IsTrue(mikeScenarioModel.MikeScenarioStartDateTime_Local != null);
            //Assert.IsTrue(mikeScenarioModel.MikeScenarioEndDateTime_Local != null);
            //Assert.IsTrue(mikeScenarioModel.MikeScenarioEndDateTime_Local >= mikeScenarioModel.MikeScenarioStartDateTime_Local);
            //Assert.IsTrue(mikeScenarioModel.MikeScenarioExecutionTime_min >= 10 && mikeScenarioModel.MikeScenarioExecutionTime_min <= 1000);
            //Assert.IsTrue(mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local != null);
            //Assert.IsTrue(mikeScenarioModel.NumberOfElements >= 10 && mikeScenarioModel.NumberOfElements <= 6000);
            //Assert.IsTrue(mikeScenarioModel.NumberOfHydroOutputParameters >= 2 && mikeScenarioModel.NumberOfHydroOutputParameters <= 20);
            //Assert.IsTrue(mikeScenarioModel.NumberOfSigmaLayers >= 2 && mikeScenarioModel.NumberOfSigmaLayers <= 5);
            //Assert.IsTrue(mikeScenarioModel.NumberOfTimeSteps >= 20 && mikeScenarioModel.NumberOfTimeSteps <= 80);
            //Assert.IsTrue(mikeScenarioModel.NumberOfTransOutputParameters >= 2 && mikeScenarioModel.NumberOfTransOutputParameters <= 20);
            //Assert.IsTrue(mikeScenarioModel.NumberOfZLayers >= 2 && mikeScenarioModel.NumberOfZLayers <= 8);
            //Assert.IsTrue(mikeScenarioModel.ResultFrequency_min >= 5 && mikeScenarioModel.ResultFrequency_min <= 60);
            //Assert.IsTrue(mikeScenarioModel.ParentMikeScenarioID == null);
            //Assert.IsTrue(mikeScenarioModel.MikeScenarioStatus == ScenarioStatusEnum.Changing);
            //Assert.IsTrue(mikeScenarioModel.UseWebTide == true);
            //Assert.IsTrue(mikeScenarioModel.WindDirection_deg >= 0 && mikeScenarioModel.WindDirection_deg <= 360);
            //Assert.IsTrue(mikeScenarioModel.WindSpeed_km_h >= 0 && mikeScenarioModel.WindSpeed_km_h <= 100);

            if (Add)
            {
                MikeScenarioService mikeScenarioService = new MikeScenarioService(LanguageRequest, User);

                MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModel);

                return mikeScenarioModelRet;
            }

            return mikeScenarioModel;
        }
        public MikeSourceModel RandomMikeSourceModel(TVItemModel tvItemModelParent, TVItemModel tvItemModel, bool Add)
        {
            MikeSourceModel mikeSourceModel = new MikeSourceModel();

            mikeSourceModel.MikeSourceTVItemID = tvItemModel.TVItemID;
            mikeSourceModel.MikeSourceTVText = RandomString("MikeSource", 30);
            mikeSourceModel.Include = true;
            mikeSourceModel.IsContinuous = true;
            mikeSourceModel.IsRiver = true;
            mikeSourceModel.UseHydrometric = false;
            mikeSourceModel.HydrometricTVItemID = null;
            mikeSourceModel.DrainageArea_km2 = null;
            mikeSourceModel.Factor = null;
            mikeSourceModel.SourceNumberString = RandomString("Source 1", 10);
            //Assert.IsTrue(mikeSourceModel.MikeSourceTVItemID != 0);
            //Assert.IsTrue(mikeSourceModel.MikeSourceTVText.Length == 30);
            //Assert.IsTrue(mikeSourceModel.Include == true);
            //Assert.IsTrue(mikeSourceModel.IsContinuous == true);
            //Assert.IsTrue(mikeSourceModel.IsRiver == true);
            //Assert.IsTrue(mikeSourceModel.SourceNumberString.Length == 10);

            if (Add)
            {
                MikeSourceService mikeSourceService = new MikeSourceService(LanguageRequest, User);

                MikeSourceModel mikeSourceModelRet = mikeSourceService.PostAddMikeSourceDB(mikeSourceModel);

                return mikeSourceModelRet;
            }

            return mikeSourceModel;
        }
        public MikeSourceStartEndModel RandomMikeSourceStartEndModel(MikeSourceModel mikeSourceModel, bool Add)
        {
            MikeSourceStartEndModel mikeSourceStartEndModel = new MikeSourceStartEndModel();

            mikeSourceStartEndModel.MikeSourceID = mikeSourceModel.MikeSourceID;
            mikeSourceStartEndModel.StartDateAndTime_Local = RandomDateTime();
            mikeSourceStartEndModel.EndDateAndTime_Local = mikeSourceStartEndModel.StartDateAndTime_Local.AddHours(5);
            mikeSourceStartEndModel.SourceFlowStart_m3_day = RandomDouble(10, 1000);
            mikeSourceStartEndModel.SourceFlowEnd_m3_day = RandomDouble(10, 1000);
            mikeSourceStartEndModel.SourcePollutionStart_MPN_100ml = RandomInt(10, 1000000);
            mikeSourceStartEndModel.SourcePollutionEnd_MPN_100ml = RandomInt(10, 1000000);
            mikeSourceStartEndModel.SourceSalinityStart_PSU = RandomDouble(0, 32);
            mikeSourceStartEndModel.SourceSalinityEnd_PSU = RandomDouble(0, 32);
            mikeSourceStartEndModel.SourceTemperatureStart_C = RandomDouble(0, 25);
            mikeSourceStartEndModel.SourceTemperatureEnd_C = RandomDouble(0, 25);
            //Assert.IsTrue(mikeSourceStartEndModel.MikeSourceID != 0);
            //Assert.IsTrue(mikeSourceStartEndModel.StartDateAndTime_Local != null);
            //Assert.IsTrue(mikeSourceStartEndModel.EndDateAndTime_Local != null);
            //Assert.IsTrue(mikeSourceStartEndModel.SourceFlowStart_m3_day >= 10 && mikeSourceStartEndModel.SourceFlowStart_m3_day <= 1000);
            //Assert.IsTrue(mikeSourceStartEndModel.SourceFlowEnd_m3_day >= 10 && mikeSourceStartEndModel.SourceFlowEnd_m3_day <= 1000);
            //Assert.IsTrue(mikeSourceStartEndModel.SourcePollutionStart_MPN_100ml >= 10 && mikeSourceStartEndModel.SourcePollutionStart_MPN_100ml <= 1000000);
            //Assert.IsTrue(mikeSourceStartEndModel.SourcePollutionEnd_MPN_100ml >= 10 && mikeSourceStartEndModel.SourcePollutionEnd_MPN_100ml <= 1000000);
            //Assert.IsTrue(mikeSourceStartEndModel.SourceSalinityStart_PSU >= 0 && mikeSourceStartEndModel.SourceSalinityStart_PSU <= 32);
            //Assert.IsTrue(mikeSourceStartEndModel.SourceSalinityEnd_PSU >= 0 && mikeSourceStartEndModel.SourceSalinityEnd_PSU <= 32);
            //Assert.IsTrue(mikeSourceStartEndModel.SourceTemperatureStart_C >= 0 && mikeSourceStartEndModel.SourceTemperatureStart_C <= 25);
            //Assert.IsTrue(mikeSourceStartEndModel.SourceTemperatureEnd_C >= 0 && mikeSourceStartEndModel.SourceTemperatureEnd_C <= 25);

            if (Add)
            {

                MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(LanguageRequest, User);

                MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeSourceStartEndService.PostAddMikeSourceStartEndDB(mikeSourceStartEndModel);

                return mikeSourceStartEndModelRet;
            }

            return mikeSourceStartEndModel;
        }
        public MWQMLookupMPNModel RandomMWQMLookupMPNModel(bool Add)
        {
            MWQMLookupMPNModel mwqmLookupMPNModel = new MWQMLookupMPNModel();

            mwqmLookupMPNModel.Tubes01 = RandomInt(0, 5);
            mwqmLookupMPNModel.Tubes1 = RandomInt(0, 5);
            mwqmLookupMPNModel.Tubes10 = RandomInt(0, 5);
            mwqmLookupMPNModel.MPN_100ml = RandomInt(0, 1700);
            //Assert.IsTrue(mwqmLookupMPNModel.Tubes01 >= 0 && mwqmLookupMPNModel.Tubes01 <= 5);
            //Assert.IsTrue(mwqmLookupMPNModel.Tubes1 >= 0 && mwqmLookupMPNModel.Tubes1 <= 5);
            //Assert.IsTrue(mwqmLookupMPNModel.Tubes10 >= 0 && mwqmLookupMPNModel.Tubes10 <= 5);
            //Assert.IsTrue(mwqmLookupMPNModel.MPN_100ml >= 0 && mwqmLookupMPNModel.MPN_100ml <= 1700);

            if (Add)
            {

                MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(LanguageRequest, User);

                MWQMLookupMPNModel mwqmLookupMPNModelRet = mwqmLookupMPNService.PostAddMWQMLookupMPNDB(mwqmLookupMPNModel);

                return mwqmLookupMPNModelRet;
            }

            return mwqmLookupMPNModel;
        }
        public MWQMRunLanguageModel RandomMWQMRunLanguageModel(LanguageEnum Language)
        {
            MWQMRunLanguageModel mwqmRunLanguageModel = new MWQMRunLanguageModel();

            mwqmRunLanguageModel.Language = Language;
            mwqmRunLanguageModel.RunComment = RandomString("Run Comment", 30);
            mwqmRunLanguageModel.TranslationStatusRunComment = TranslationStatusEnum.Translated;
            mwqmRunLanguageModel.RunWeatherComment = RandomString("Run Weather Comment", 30);
            mwqmRunLanguageModel.TranslationStatusRunWeatherComment = TranslationStatusEnum.Translated;
            //Assert.AreEqual(LanguageEnum.en, mwqmRunLanguageModel.Language);
            //Assert.IsTrue(mwqmRunLanguageModel.MWQMRunComment.Length == 20);
            //Assert.IsTrue(mwqmRunLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);

            return mwqmRunLanguageModel;
        }
        public MWQMRunModel RandomMWQMRunModel(TVItemModel tvItemModelSubsector, TVItemModel tvItemModelRun, string SampleCrewInitials, TVItemModel tvItemModelValidatorContact, bool Add)
        {
            MWQMRunModel mwqmRunModel = new MWQMRunModel();

            mwqmRunModel.RunComment = RandomString("", 200);
            mwqmRunModel.RunWeatherComment = RandomString("", 200);
            mwqmRunModel.SubsectorTVItemID = tvItemModelSubsector.TVItemID;
            mwqmRunModel.MWQMRunTVItemID = tvItemModelRun.TVItemID;
            mwqmRunModel.AnalyzeMethod = AnalyzeMethodEnum.MF;
            mwqmRunModel.DateTime_Local = RandomDateTime();
            mwqmRunModel.StartDateTime_Local = RandomDateTime();
            mwqmRunModel.EndDateTime_Local = mwqmRunModel.StartDateTime_Local.Value.AddHours(2);
            mwqmRunModel.LabAnalyzeBath1IncubationStartDateTime_Local = RandomDateTime();
            mwqmRunModel.LabAnalyzeBath2IncubationStartDateTime_Local = RandomDateTime();
            mwqmRunModel.LabAnalyzeBath3IncubationStartDateTime_Local = RandomDateTime();
            mwqmRunModel.LabReceivedDateTime_Local = RandomDateTime();
            mwqmRunModel.Laboratory = LaboratoryEnum.ZZ_0;
            mwqmRunModel.SampleMatrix = SampleMatrixEnum.W;
            mwqmRunModel.RainDay1_mm = RandomDouble(0, 1000);
            mwqmRunModel.RainDay2_mm = RandomDouble(0, 1000);
            mwqmRunModel.RainDay3_mm = RandomDouble(0, 1000);
            mwqmRunModel.SampleCrewInitials = SampleCrewInitials;
            mwqmRunModel.SeaStateAtEnd_BeaufortScale = BeaufortScaleEnum.GentleBreeze;
            mwqmRunModel.SeaStateAtStart_BeaufortScale = BeaufortScaleEnum.GentleBreeze;
            mwqmRunModel.SampleStatus = SampleStatusEnum.SampleStatus3;
            mwqmRunModel.TemperatureControl1_C = RandomInt(-45, 45);
            mwqmRunModel.TemperatureControl2_C = RandomInt(-45, 45);
            mwqmRunModel.LabRunSampleApprovalDateTime_Local = RandomDateTime();
            mwqmRunModel.LabSampleApprovalContactTVItemID = tvItemModelValidatorContact.TVItemID;
            mwqmRunModel.WaterLevelAtBrook_m = RandomDouble(0.0, 10.0);
            mwqmRunModel.WaveHightAtEnd_m = RandomDouble(0.0, 10.0);
            mwqmRunModel.WaveHightAtStart_m = RandomDouble(0.0, 10.0);
            //Assert.IsTrue(mwqmRunModel.MWQMRunComment.Length == 200);
            //Assert.IsTrue(mwqmRunModel.SubsectorTVItemID != 0);
            //Assert.IsTrue(mwqmRunModel.MWQMRunTVItemID != 0);
            //Assert.IsTrue(mwqmRunModel.AnalyzeMethod == AnalyzeMethodEnum.MF);
            //Assert.IsTrue(mwqmRunModel.DateTime_Local != null);
            //Assert.IsTrue(mwqmRunModel.StartDateTime_Local != null);
            //Assert.IsTrue(mwqmRunModel.EndDateTime_Local != null);
            //Assert.IsTrue(mwqmRunModel.EndDateTime_Local >= mwqmRunModel.StartDateTime_Local);
            //Assert.IsTrue(mwqmRunModel.LabAnalyzeIncubationStartDateTime_Local != null);
            //Assert.IsTrue(mwqmRunModel.LabReceivedDateTime_Local != null);
            //Assert.IsTrue(mwqmRunModel.Laboratory == LaboratoryEnum._0);
            //Assert.IsTrue(mwqmRunModel.SampleMatrix == SampleMatrixEnum.W);
            //Assert.IsTrue(mwqmRunModel.RainDay1_mm >= 0 && mwqmRunModel.RainDay1_mm <= 1000);
            //Assert.IsTrue(mwqmRunModel.RainDay2_mm >= 0 && mwqmRunModel.RainDay1_mm <= 1000);
            //Assert.IsTrue(mwqmRunModel.RainDay3_mm >= 0 && mwqmRunModel.RainDay1_mm <= 1000);
            //Assert.IsTrue(mwqmRunModel.SampleCrewInitials.Length > 0);
            //Assert.IsTrue(mwqmRunModel.SeaStateAtEnd_BeaufortScale == BeaufortScaleEnum.GentleBreeze);
            //Assert.IsTrue(mwqmRunModel.SeaStateAtStart_BeaufortScale == BeaufortScaleEnum.GentleBreeze);
            //Assert.IsTrue(mwqmRunModel.SampleStatus == SampleStatusEnum.SampleStatus3);
            //Assert.IsTrue(mwqmRunModel.TemperatureControl1_C >= -45 && mwqmRunModel.TemperatureControl1_C <= 45);
            //Assert.IsTrue(mwqmRunModel.TemperatureControl2_C >= -45 && mwqmRunModel.TemperatureControl2_C <= 45);
            //Assert.IsTrue(mwqmRunModel.LabRunSampleApprovalDateTime_Local != null);
            //Assert.IsTrue(mwqmRunModel.LabSampleApprovalContactTVItemID > 0);
            //Assert.IsTrue(mwqmRunModel.WaterLevelAtBrook_m >= 0 && mwqmRunModel.WaterLevelAtBrook_m <= 10);
            //Assert.IsTrue(mwqmRunModel.WaveHightAtEnd_m >= 0 && mwqmRunModel.WaveHightAtEnd_m <= 10);
            //Assert.IsTrue(mwqmRunModel.WaveHightAtStart_m >= 0 && mwqmRunModel.WaveHightAtStart_m <= 10);

            if (Add)
            {
                MWQMRunService mwqmRunService = new MWQMRunService(LanguageRequest, User);

                MWQMRunModel mwqmRunModelRet = mwqmRunService.PostAddMWQMRunDB(mwqmRunModel);

                return mwqmRunModelRet;
            }

            return mwqmRunModel;
        }
        public MWQMSampleLanguageModel RandomMWQMSampleLanguageModel(LanguageEnum Language)
        {
            MWQMSampleLanguageModel mwqmSampleLanguageModel = new MWQMSampleLanguageModel();

            mwqmSampleLanguageModel.Language = Language;
            mwqmSampleLanguageModel.MWQMSampleNote = RandomString("Comment", 20);
            mwqmSampleLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            //Assert.AreEqual(LanguageEnum.en, mwqmSampleLanguageModel.Language);
            //Assert.IsTrue(mwqmSampleLanguageModel.MWQMSampleNote.Length == 20);
            //Assert.IsTrue(mwqmSampleLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);

            return mwqmSampleLanguageModel;
        }
        public MWQMSampleModel RandomMWQMSampleModel(TVItemModel tvItemModelMWQMSite, TVItemModel tvItemModelMWQMRun, bool Add)
        {
            MWQMSampleModel mwqmSampleModel = new MWQMSampleModel() { Error = "" };

            mwqmSampleModel.MWQMSampleNote = RandomString("", 200);
            mwqmSampleModel.MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID;
            mwqmSampleModel.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
            mwqmSampleModel.Depth_m = RandomDouble(0.0, 10000.0);
            mwqmSampleModel.FecCol_MPN_100ml = RandomInt(0, 10000000);
            mwqmSampleModel.PH = RandomDouble(0.0, 14.0);
            mwqmSampleModel.Salinity_PPT = RandomDouble(0.0, 35.0);
            mwqmSampleModel.SampleDateTime_Local = RandomDateTime();
            mwqmSampleModel.WaterTemp_C = RandomDouble(0.0, 35.0);
            mwqmSampleModel.SampleTypesText = ((int)SampleTypeEnum.Routine).ToString() + ",";

            //Assert.IsTrue(mwqmSampleModel.MWQMSampleNote.Length == 200);
            //Assert.IsTrue(mwqmSampleModel.MWQMSiteTVItemID != 0);
            //Assert.IsTrue(mwqmSampleModel.MWQMRunTVItemID != 0);
            //Assert.IsTrue(mwqmSampleModel.Depth_m >= 0.0 && mwqmSampleModel.Depth_m <= 10000.0);
            //Assert.IsTrue(mwqmSampleModel.FecCol_MPN_100ml >= 0 && mwqmSampleModel.FecCol_MPN_100ml <= 10000000);
            //Assert.IsTrue(mwqmSampleModel.PH >= 0.0 && mwqmSampleModel.PH <= 14.0);
            //Assert.IsTrue(mwqmSampleModel.Salinity_PPT >= 0.0 && mwqmSampleModel.Salinity_PPT <= 35.0);
            //Assert.IsTrue(mwqmSampleModel.SampleDateTime_Local != null);
            //Assert.IsTrue(mwqmSampleModel.WaterTemp_C >= 0.0 && mwqmSampleModel.WaterTemp_C <= 35.0);
            //Assert.IsTrue(mwqmSampleModel.SampleTypesText == ((int)SampleTypeEnum.Routine).ToString() + ",");

            if (Add)
            {
                MWQMSampleService mwqmSampleService = new MWQMSampleService(LanguageRequest, User);

                MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.PostAddMWQMSampleDB(mwqmSampleModel);
                //Assert.AreEqual("", mwqmSampleModelRet.Error);

                return mwqmSampleModelRet;
            }
            return mwqmSampleModel;
        }
        public MWQMSiteModel RandomMWQMSiteModel(TVItemModel tvItemModelMWQMSite, bool Add)
        {
            MWQMSiteModel mwqmSiteModel = new MWQMSiteModel();

            mwqmSiteModel.MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID;
            mwqmSiteModel.MWQMSiteTVText = RandomString("MWQMSite", 30);
            mwqmSiteModel.MWQMSiteNumber = RandomString("SN", 8);
            mwqmSiteModel.MWQMSiteDescription = RandomString("", 30);
            mwqmSiteModel.Ordinal = RandomInt(0, 100);

            //Assert.IsTrue(mwqmSiteModel.MWQMSiteTVItemID != 0);
            //Assert.IsTrue(mwqmSiteModel.MWQMSiteTVText.Length == 30);
            //Assert.IsTrue(mwqmSiteModel.MWQMSiteNumber.Length == 8);
            //Assert.IsTrue(mwqmSiteModel.MWQMSiteDescription.Length == 30);
            //Assert.IsTrue(mwqmSiteModel.Ordinal >= 0 && mwqmSiteModel.Ordinal <= 100);

            if (Add)
            {
                MWQMSiteService mwqmSiteService = new MWQMSiteService(LanguageRequest, User);

                MWQMSiteModel mwqmSiteModelRet = mwqmSiteService.PostAddMWQMSiteDB(mwqmSiteModel);

                return mwqmSiteModelRet;
            }

            return mwqmSiteModel;
        }
        public MWQMSubsectorLanguageModel RandomMWQMSubsectorLanguageModel(LanguageEnum Language)
        {
            MWQMSubsectorLanguageModel mwqmSubsectorLanguageModel = new MWQMSubsectorLanguageModel();

            mwqmSubsectorLanguageModel.Language = Language;
            mwqmSubsectorLanguageModel.SubsectorDesc = RandomString("ss desc", 20);
            mwqmSubsectorLanguageModel.TranslationStatusSubsectorDesc = TranslationStatusEnum.Translated;
            mwqmSubsectorLanguageModel.LogBook = RandomString("ss desc", 20);
            mwqmSubsectorLanguageModel.TranslationStatusLogBook = TranslationStatusEnum.Translated;
            //Assert.AreEqual(LanguageEnum.en, mwqmSubsectorLanguageModel.Language);
            //Assert.IsTrue(mwqmSubsectorLanguageModel.SubsectorDesc.Length == 20);
            //Assert.IsTrue(mwqmSubsectorLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);

            return mwqmSubsectorLanguageModel;
        }
        public MWQMSubsectorModel RandomMWQMSubsectorModel(TVItemModel tvItemModelSubsector, bool Add)
        {
            MWQMSubsectorModel mwqmSubsectorModel = new MWQMSubsectorModel();

            mwqmSubsectorModel.SubsectorDesc = RandomString("", 80);
            mwqmSubsectorModel.MWQMSubsectorTVItemID = tvItemModelSubsector.TVItemID;
            mwqmSubsectorModel.SubsectorHistoricKey = RandomString("subsekey", 20);
            //Assert.IsTrue(mwqmSubsectorModel.SubsectorDesc.Length == 80);
            //Assert.IsTrue(mwqmSubsectorModel.MWQMSubsectorTVItemID != 0);
            //Assert.IsTrue(mwqmSubsectorModel.SubsectorHistoricKey.Length == 20);

            if (Add)
            {
                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(LanguageRequest, User);

                MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorService.PostAddMWQMSubsectorDB(mwqmSubsectorModel);

                return mwqmSubsectorModelRet;
            }

            return mwqmSubsectorModel;
        }
        public PolSourceObservationIssueModel RandomPolSourceObservationIssueModel(PolSourceObservationModel polSourceObservationModel, bool Add)
        {
            PolSourceObservationIssueModel polSourceObservationIssueModel = new PolSourceObservationIssueModel();

            polSourceObservationIssueModel.PolSourceObservationID = polSourceObservationModel.PolSourceObservationID;
            polSourceObservationIssueModel.ObservationInfo = (int)PolSourceObsInfoEnum.SourceStart + "," +
                (int)PolSourceObsInfoEnum.AgriculturalSourceCrop + "," +
                (int)PolSourceObsInfoEnum.AreaSlopeLow + "," +
                (int)PolSourceObsInfoEnum.StatusDefiniteHi + "," +
                (int)PolSourceObsInfoEnum.RiskConfirmationConfirmedWater;
            //Assert.IsTrue(polSourceObservationIssueModel.PolSourceObservationID > 0);
            //Assert.IsTrue(polSourceObservationIssueModel.ObservationInfo == (int)PolSourceObsInfoEnum.SourceStart + "," +
            //(int)PolSourceObsInfoEnum.DistanceFromShoreInMeters10 + "," +
            //(int)PolSourceObsInfoEnum.AreaSlopeLow + "," +
            //(int)PolSourceObsInfoEnum.AreaMetersBetween101And250 + "," +
            //(int)PolSourceObsInfoEnum.StatusPotentiel + "," +
            //(int)PolSourceObsInfoEnum.RiskHighp);

            if (Add)
            {
                PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, User);

                PolSourceObservationIssueModel polSourceObservationIssueModelRet = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModel);

                return polSourceObservationIssueModelRet;
            }

            return polSourceObservationIssueModel;
        }
        public PolSourceObservationModel RandomPolSourceObservationModel(PolSourceSiteModel polSourceSiteModel, TVItemModel tvItemModelContact, bool Add)
        {
            PolSourceObservationModel polSourceObservationModel = new PolSourceObservationModel();

            polSourceObservationModel.PolSourceSiteID = polSourceSiteModel.PolSourceSiteID;
            polSourceObservationModel.ObservationDate_Local = RandomDateTime();
            polSourceObservationModel.ContactTVItemID = tvItemModelContact.TVItemID;
            polSourceObservationModel.Observation_ToBeDeleted = RandomString("", 20);

            //Assert.IsTrue(polSourceObservationModel.PolSourceSiteTVItemID != 0);
            //Assert.IsTrue(polSourceObservationModel.ObservationDate_Local != null);
            //Assert.IsTrue(polSourceObservationModel.ContactTVItemID != 0);
            //Assert.IsTrue(polSourceObservationModel.Observation_ToBeDeleted.Length == 20);

            if (Add)
            {
                PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, User);

                PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PostAddPolSourceObservationDB(polSourceObservationModel);
                //Assert.AreEqual("", polSourceObservationModelRet.Error);

                PolSourceObservationIssueModel polSourceObservationIssueModelRet = RandomPolSourceObservationIssueModel(polSourceObservationModelRet, true);
                //Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                return polSourceObservationModelRet;
            }

            return polSourceObservationModel;
        }
        public PolSourceSiteModel RandomPolSourceSiteModel(TVItemModel tvItemModelPolSourceSite, TVItemModel tvItemModelContact, bool Add)
        {
            PolSourceSiteModel polSourceSiteModel = new PolSourceSiteModel();

            polSourceSiteModel.PolSourceSiteTVItemID = tvItemModelPolSourceSite.TVItemID;
            polSourceSiteModel.PolSourceSiteTVText = RandomString("PolSourceSite", 30);
            polSourceSiteModel.Temp_Locator_CanDelete = RandomString("temp locator", 20);
            polSourceSiteModel.Oldsiteid = RandomInt(1, 100);
            polSourceSiteModel.Site = RandomInt(1, 100);
            polSourceSiteModel.SiteID = RandomInt(1, 100);
            polSourceSiteModel.IsPointSource = true;
            polSourceSiteModel.InactiveReason = PolSourceInactiveReasonEnum.Abandoned;
            polSourceSiteModel.CivicAddressTVItemID = RandomTVItem(TVTypeEnum.Address).TVItemID;

            //Assert.IsTrue(polSourceSiteModel.PolSourceSiteTVItemID != 0);
            //Assert.IsTrue(polSourceSiteModel.PolSourceSiteTVText.Length == 30);
            //Assert.IsTrue(polSourceSiteModel.Temp_Locator_CanDelete.Length == 20);
            //Assert.IsTrue(polSourceSiteModel.Oldsiteid >= 0 && polSourceSiteModel.Oldsiteid <= 100);
            //Assert.IsTrue(polSourceSiteModel.Site >= 0 && polSourceSiteModel.Site <= 100);
            //Assert.IsTrue(polSourceSiteModel.SiteID >= 0 && polSourceSiteModel.SiteID <= 100);
            //Assert.IsTrue(polSourceSiteModel.IsPointSource == true);
            //Assert.IsTrue(polSourceSiteModel.InactiveReason == PolSourceInactiveReasonEnum.Abandoned);
            //Assert.IsTrue(polSourceSiteModel.CivicAddressTVItemID > 0);

            if (Add)
            {
                PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, User);

                PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PostAddPolSourceSiteDB(polSourceSiteModel);
                //Assert.AreEqual("", polSourceSiteModelRet.Error);

                PolSourceObservationModel polSourceObservationModelRet = RandomPolSourceObservationModel(polSourceSiteModelRet, tvItemModelContact, true);
                //Assert.AreEqual("", polSourceObservationModelRet.Error);

                //PolSourceObservationIssueModel polSourceObservationIssueModelRet = RandomPolSourceObservationIssueModel(polSourceObservationModelRet, true);
                ////Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                return polSourceSiteModelRet;
            }

            return polSourceSiteModel;
        }
        public RatingCurveModel RandomRatingCurveModel(HydrometricSiteModel hydrometricSiteModel, bool Add)
        {
            RatingCurveModel ratingCurveModel = new RatingCurveModel();

            ratingCurveModel.HydrometricSiteID = hydrometricSiteModel.HydrometricSiteID;
            ratingCurveModel.RatingCurveNumber = RandomString("Rating Curve", 30);
            //Assert.IsTrue(ratingCurveModel.HydrometricSiteID != 0);
            //Assert.IsTrue(ratingCurveModel.RatingCurveNumber.Length == 30);

            if (Add)
            {

                RatingCurveService ratingCurveService = new RatingCurveService(LanguageRequest, User);

                RatingCurveModel ratingCurveModelRet = ratingCurveService.PostAddRatingCurveDB(ratingCurveModel);

                return ratingCurveModelRet;
            }

            return ratingCurveModel;
        }
        public RatingCurveValueModel RandomRatingCurveValueModel(RatingCurveModel ratingCurveModel, bool Add)
        {
            RatingCurveValueModel ratingCurveValueModel = new RatingCurveValueModel();

            ratingCurveValueModel.RatingCurveID = ratingCurveModel.RatingCurveID;
            ratingCurveValueModel.StageValue_m = RandomDouble(0, 10000);
            ratingCurveValueModel.DischargeValue_m3_s = RandomDouble(0, 100000);
            //Assert.IsTrue(ratingCurveValueModel.RatingCurveID != 0);
            //Assert.IsTrue(ratingCurveValueModel.StageValue_m >= 0 && ratingCurveValueModel.StageValue_m <= 10000);
            //Assert.IsTrue(ratingCurveValueModel.DischargeValue_m3_s >= 0 && ratingCurveValueModel.DischargeValue_m3_s <= 100000);

            if (Add)
            {

                RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(LanguageRequest, User);

                RatingCurveValueModel ratingCurveValueModelRet = ratingCurveValueService.PostAddRatingCurveValueDB(ratingCurveValueModel);

                return ratingCurveValueModelRet;
            }

            return ratingCurveValueModel;
        }
        public ResetPasswordModel RandomResetPasswordModel(bool Add)
        {
            ResetPasswordModel resetPasswordModel = new ResetPasswordModel();

            resetPasswordModel.Code = RandomInt(12345678, 98765432).ToString();
            resetPasswordModel.Email = RandomString("charles.leblanc2@canada.ca", "charles.leblanc2@canada.ca".Length);
            resetPasswordModel.Password = RandomPassword();
            resetPasswordModel.ConfirmPassword = resetPasswordModel.Password;
            resetPasswordModel.ExpireDate_Local = DateTime.UtcNow.AddDays(1);

            //Assert.IsTrue(resetPasswordModel.Code.Length == 8);
            //Assert.IsTrue(resetPasswordModel.Email == "charles.leblanc2@canada.ca");
            //Assert.IsTrue(resetPasswordModel.Password.Length > 8);
            //Assert.IsTrue(resetPasswordModel.ConfirmPassword.Length > 8);
            //Assert.AreEqual(resetPasswordModel.Password, resetPasswordModel.ConfirmPassword);
            //Assert.IsTrue(resetPasswordModel.ExpireDate_Local != null);

            if (Add)
            {

                ResetPasswordService resetPasswordService = new ResetPasswordService(LanguageRequest, User);

                ResetPasswordModel resetPasswordModelRet = resetPasswordService.PostAddResetPasswordDB(resetPasswordModel);

                return resetPasswordModelRet;
            }

            return resetPasswordModel;
        }
        public SpillLanguageModel RandomSpillLanguageModel(LanguageEnum Language)
        {
            SpillLanguageModel spillLanguageModel = new SpillLanguageModel();

            spillLanguageModel.Language = Language;
            spillLanguageModel.SpillComment = RandomString("SpillComment text", 80);
            spillLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;
            //Assert.AreEqual(LanguageEnum.en, spillLanguageModel.Language);
            //Assert.IsTrue(spillLanguageModel.SpillComment.Length == 80);
            //Assert.IsTrue(spillLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);

            return spillLanguageModel;
        }
        public SpillModel RandomSpillModel(TVItemModel tvItemModelMunicipality, TVItemModel tvItemModelInfrastructure, bool Add)
        {
            SpillModel spillModel = new SpillModel();

            spillModel.SpillComment = RandomString("SpillComment", 50);
            spillModel.MunicipalityTVItemID = tvItemModelMunicipality.TVItemID;
            spillModel.InfrastructureTVItemID = tvItemModelInfrastructure.TVItemID;
            spillModel.StartDateTime_Local = RandomDateTime();
            spillModel.EndDateTime_Local = spillModel.StartDateTime_Local.AddHours(1);
            spillModel.AverageFlow_m3_day = RandomDouble(0, 100000);
            //Assert.IsTrue(spillModel.SpillComment.Length == 50);
            //Assert.IsTrue(spillModel.MunicipalityTVItemID != 0);
            //Assert.IsTrue(spillModel.InfrastructureTVItemID != 0);
            //Assert.IsTrue(spillModel.StartDateTime_Local != null);
            //Assert.IsTrue(spillModel.EndDateTime_Local != null);
            //Assert.IsTrue(spillModel.EndDateTime_Local >= spillModel.StartDateTime_Local);
            //Assert.IsTrue(spillModel.AverageFlow_m3_day >= 0 && spillModel.AverageFlow_m3_day <= 100000);

            if (Add)
            {
                SpillService spillService = new SpillService(LanguageRequest, User);

                SpillModel spillModelRet = spillService.PostAddSpillDB(spillModel);

                return spillModelRet;
            }

            return spillModel;
        }
        public TelModel RandomTelModel(bool Add)
        {
            TelModel telModel = new TelModel();

            telModel.TelTVItemID = 1; // will be replace
            telModel.TelNumber = RandomTel();
            telModel.TelType = TelTypeEnum.Work;
            //Assert.AreEqual(1, telModel.TelTVItemID);
            //Assert.IsTrue(telModel.TelNumber != null);
            //Assert.IsTrue(telModel.TelType == TelTypeEnum.Work);

            if (Add)
            {
                TelService telService = new TelService(LanguageRequest, User);

                TVItemModel tvItemModelRoot = telService._TVItemService.GetRootTVItemModelDB();

                //Assert.AreEqual("", tvItemModelRoot.Error);

                string TVText = telService.CreateTVText(telModel);

                // Asssert
                //Assert.IsTrue(!string.IsNullOrWhiteSpace(TVText));

                TVItemModel tvItemTel = telService._TVItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Tel);

                //Assert.AreEqual("", tvItemTel.Error);

                telModel.TelTVItemID = tvItemTel.TVItemID;

                TelModel telModelRet = telService.PostAddTelDB(telModel);

                //Assert.AreEqual("", telModelRet.Error);

                return telModelRet;
            }

            return telModel;
        }
        public TideDataValueModel RandomTideDataValueModel(TideSiteModel tideSiteModel, bool Add)
        {
            TideDataValueModel tideDataValueModel = new TideDataValueModel();

            tideDataValueModel.TideSiteTVItemID = tideSiteModel.TideSiteTVItemID;
            tideDataValueModel.DateTime_Local = RandomDateTime();
            tideDataValueModel.Depth_m = RandomDouble(-10, 10);
            tideDataValueModel.UVelocity_m_s = RandomDouble(-10, 10);
            tideDataValueModel.VVelocity_m_s = RandomDouble(-10, 10);
            tideDataValueModel.TideStart = TideTextEnum.HighTide;
            tideDataValueModel.TideEnd = TideTextEnum.HighTideFalling;
            //Assert.IsTrue(tideDataValueModel.TideSiteTVItemID != 0);
            //Assert.IsTrue(tideDataValueModel.DateTime_Local != null);
            //Assert.IsTrue(tideDataValueModel.Depth_m >= -10 && tideDataValueModel.Depth_m <= 10);
            //Assert.IsTrue(tideDataValueModel.UVelocity_m_s >= -10 && tideDataValueModel.UVelocity_m_s <= 10);
            //Assert.IsTrue(tideDataValueModel.VVelocity_m_s >= -10 && tideDataValueModel.VVelocity_m_s <= 10);
            //Assert.IsTrue(tideDataValueModel.TideStart == TideTextEnum.HighTide);
            //Assert.IsTrue(tideDataValueModel.TideEnd == TideTextEnum.HighTideFalling);

            if (Add)
            {

                TideDataValueService tideDataValueService = new TideDataValueService(LanguageRequest, User);

                TideDataValueModel tideDataValueModelRet = tideDataValueService.PostAddTideDataValueDB(tideDataValueModel);

                return tideDataValueModelRet;
            }

            return tideDataValueModel;
        }
        public TideSiteModel RandomTideSiteModel(TVItemModel tvItemModelParent, TVItemModel tvItemModelTideSite, bool Add)
        {
            TideSiteModel tideSiteModel = new TideSiteModel();

            tideSiteModel.TideSiteTVItemID = tvItemModelTideSite.TVItemID;
            tideSiteModel.TideSiteTVText = RandomString("TideSite", 30);
            tideSiteModel.WebTideModel = RandomString("WTM", 10);
            tideSiteModel.WebTideDatum_m = RandomDouble(-10, 10);
            //Assert.IsTrue(tideSiteModel.TideSiteTVItemID > 0);
            //Assert.IsTrue(tideSiteModel.TideSiteTVText.Length == 30);
            //Assert.IsTrue(tideSiteModel.WebTideModel.Length == 10);
            //Assert.IsTrue(tideSiteModel.WebTideDatum_m >= -10 && tideSiteModel.WebTideDatum_m <= 10);

            if (Add)
            {

                TideSiteService tideSiteService = new TideSiteService(LanguageRequest, User);

                TideSiteModel tideSiteModelRet = tideSiteService.PostAddTideSiteDB(tideSiteModel);

                return tideSiteModelRet;
            }

            return tideSiteModel;
        }
        public TVFileModel RandomTVFileModel(TVItemModel tvItemModelTVFile, bool Add)
        {
            TVFileModel tvFileModel = new TVFileModel();

            TVFileService tvFileService = new TVFileService(LanguageRequest, User);

            string ServerFilePath = tvFileService.GetServerFilePath((int)tvItemModelTVFile.ParentID);
            string ServerFileName = RandomString("ServerFileName_", 20) + ".html";

            tvFileModel.TVFileTVItemID = tvItemModelTVFile.TVItemID;
            tvFileModel.Language = LanguageEnum.en;
            tvFileModel.Year = DateTime.Now.Year;
            tvFileModel.FilePurpose = FilePurposeEnum.ReportGenerated;
            tvFileModel.FileType = FileTypeEnum.HTML;
            tvFileModel.FileDescription = RandomString("File Description", 200);
            tvFileModel.FileSize_kb = 1;
            tvFileModel.FileInfo = RandomString("File Info", 200);
            tvFileModel.FileCreatedDate_UTC = RandomDateTime();
            tvFileModel.ClientFilePath = "";
            tvFileModel.ServerFileName = ServerFileName;
            tvFileModel.ServerFilePath = ServerFilePath;
            //Assert.IsTrue(tvFileModel.TVFileTVItemID != 0);
            //Assert.IsTrue(tvFileModel.Language == LanguageEnum.en);
            //Assert.IsTrue(tvFileModel.FilePurpose == FilePurposeEnum.Reported);
            //Assert.IsTrue(tvFileModel.FileType == FileTypeEnum.HTML);
            //Assert.IsTrue(tvFileModel.FileDescription.Length == 200);
            //Assert.IsTrue(tvFileModel.FileSize_kb == 1);
            //Assert.IsTrue(tvFileModel.FileInfo.Length == 200);
            //Assert.IsTrue(tvFileModel.FileCreatedDate_UTC != null);
            //Assert.IsTrue(tvFileModel.ClientFilePath.Length == 0);
            //Assert.IsTrue(tvFileModel.ServerFileName.Length == 25);
            //Assert.IsTrue(tvFileModel.ServerFilePath.Length > 3);

            if (Add)
            {

                TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModel);

                //Assert.AreEqual("", tvFileModelRet.Error);

                DirectoryInfo di = new DirectoryInfo(ServerFilePath);

                if (!di.Exists)
                {
                    di.Create();
                }

                di = new DirectoryInfo(ServerFilePath);

                if (!di.Exists)
                {
                    return new TVFileModel() { Error = "Could not create directory [" + ServerFilePath + "]" };
                }

                FileInfo fi = new FileInfo(ServerFilePath + ServerFileName);

                StreamWriter sw = fi.CreateText();
                sw.WriteLine(@"<!DOCTYPE html PUBLIC ""-//W3C//DTD HTML 4.01//EN""  ""http://www.w3.org/TR/html4/strict.dtd"">");
                sw.WriteLine(@"<html lang=""en"">");
                sw.WriteLine(@"<head>");
                sw.WriteLine(@"<meta http-equiv=""content-type"" content=""text/html; charset=utf-8"">");
                sw.WriteLine(@"<title>title</title>");
                sw.WriteLine(@"</head>");
                sw.WriteLine(@"<body>");
                sw.WriteLine(@"Full file name [" + ServerFilePath + ServerFileName + "]");
                sw.WriteLine(@"</body>");
                sw.WriteLine(@"</html>");

                sw.Close();

                int FileSize_kb = (int)(fi.Length / 1024);
                if (FileSize_kb == 0)
                {
                    FileSize_kb = 1;
                }
                tvFileModelRet.FileSize_kb = FileSize_kb;
                tvFileModelRet.FileCreatedDate_UTC = fi.CreationTimeUtc;

                TVFileModel tvFileModelRet2 = tvFileService.PostUpdateTVFileDB(tvFileModelRet);

                return tvFileModelRet2;
            }

            return tvFileModel;
        }
        public TVItemLanguageModel RandomTVItemLanguageModel(LanguageEnum Language)
        {
            TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel();

            tvItemLanguageModel.Language = Language;
            tvItemLanguageModel.TVText = RandomString("TV Text", 20);
            tvItemLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;
            //Assert.AreEqual(LanguageEnum.en, tvItemLanguageModel.Language);
            //Assert.IsTrue(tvItemLanguageModel.TVText.Length == 20);
            //Assert.IsTrue(tvItemLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);

            return tvItemLanguageModel;
        }
        public TVItemLinkModel RandomTVItemLinkModel(TVItemModel tvItemModelFrom, TVItemModel tvItemModelTo, bool Add)
        {
            TVItemLinkModel tvItemLinkModel = new TVItemLinkModel();

            tvItemLinkModel.FromTVItemID = tvItemModelFrom.TVItemID;
            tvItemLinkModel.ToTVItemID = tvItemModelTo.TVItemID;
            tvItemLinkModel.FromTVType = tvItemModelFrom.TVType;
            tvItemLinkModel.ToTVType = tvItemModelTo.TVType;
            tvItemLinkModel.StartDateTime_Local = RandomDateTime();
            tvItemLinkModel.EndDateTime_Local = tvItemLinkModel.StartDateTime_Local.Value.AddHours(1);
            tvItemLinkModel.Ordinal = 3;
            tvItemLinkModel.TVLevel = 0;
            tvItemLinkModel.TVPath = "p" + tvItemModelFrom.TVItemID + "p" + tvItemModelTo.TVItemID;
            //Assert.IsTrue(tvItemLinkModel.FromTVItemID != 0);
            //Assert.IsTrue(tvItemLinkModel.ToTVItemID != 0);
            //Assert.IsTrue(tvItemLinkModel.FromTVType == tvItemModelFrom.TVType);
            //Assert.IsTrue(tvItemLinkModel.ToTVType == tvItemModelTo.TVType);
            //Assert.IsTrue(tvItemLinkModel.FromTVItemID != 0);
            //Assert.IsTrue(tvItemLinkModel.StartDateTime_Local != null);
            //Assert.IsTrue(tvItemLinkModel.EndDateTime_Local != null);
            //Assert.IsTrue(tvItemLinkModel.EndDateTime_Local >= tvItemLinkModel.StartDateTime_Local);
            //Assert.IsTrue(tvItemLinkModel.Ordinal == 3);
            //Assert.IsTrue(tvItemLinkModel.TVLevel == 0);
            //Assert.IsTrue(tvItemLinkModel.TVPath == "p" + tvItemModelFrom.TVItemID + "p" + tvItemModelTo.TVItemID);

            if (Add)
            {

                TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, User);

                TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostAddTVItemLinkDB(tvItemLinkModel);

                return tvItemLinkModelRet;
            }

            return tvItemLinkModel;
        }
        public TVItemModel RandomTVItemModel(TVItemModel tvItemModelParent, TVTypeEnum tvType, bool Add)
        {
            TVItemModel tvItemModel = new TVItemModel();

            tvItemModel.TVLevel = tvItemModelParent.TVLevel + 1;
            tvItemModel.TVPath = tvItemModelParent.TVPath + "p0";
            tvItemModel.TVType = tvType;
            tvItemModel.ParentID = tvItemModelParent.TVItemID;
            tvItemModel.IsActive = true;
            //Assert.IsTrue(tvItemModel.TVLevel == tvItemModelParent.TVLevel + 1);
            //Assert.IsTrue(tvItemModel.TVPath == tvItemModelParent.TVPath + "p0");
            //Assert.IsTrue(tvItemModel.TVType == tvType);
            //Assert.IsTrue(tvItemModel.ParentID == tvItemModelParent.TVItemID);
            //Assert.IsTrue(tvItemModel.IsActive == true);

            if (Add)
            {
                string TVText = RandomString("tvText", 12);

                TVItemService tvItemService = new TVItemService(LanguageRequest, User);

                TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelParent.TVItemID, TVText, tvType);

                return tvItemModelRet;
            }

            return tvItemModel;
        }
        public TVItemUserAuthorizationModel RandomTVItemUserAuthorizationModel(bool Add)
        {
            TVItemUserAuthorizationModel tvItemUserAuthorizationModel = new TVItemUserAuthorizationModel();

            tvItemUserAuthorizationModel.ContactTVItemID = RandomContact().ContactTVItemID;
            tvItemUserAuthorizationModel.TVItemID1 = RandomTVItem(TVTypeEnum.Municipality).TVItemID;
            tvItemUserAuthorizationModel.TVItemID2 = tvItemUserAuthorizationModel.TVItemID1;
            tvItemUserAuthorizationModel.TVItemID3 = RandomTVItem(TVTypeEnum.Subsector).TVItemID;
            tvItemUserAuthorizationModel.TVItemID4 = RandomTVItem(TVTypeEnum.Sector).TVItemID;
            tvItemUserAuthorizationModel.TVAuth = TVAuthEnum.Create;
            //Assert.IsTrue(tvItemUserAuthorizationModel.ContactTVItemID != 0);
            //Assert.IsTrue(tvItemUserAuthorizationModel.TVItemID1 != 0);
            //Assert.IsTrue(tvItemUserAuthorizationModel.TVItemID2 != 0);
            //Assert.IsTrue(tvItemUserAuthorizationModel.TVItemID2 != 0);
            //Assert.IsTrue(tvItemUserAuthorizationModel.TVItemID4 != 0);
            //Assert.IsTrue(tvItemUserAuthorizationModel.TVAuth == TVAuthEnum.Create);

            if (Add)
            {

                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, User);

                TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.PostAddTVItemUserAuthorizationDB(tvItemUserAuthorizationModel);

                return tvItemUserAuthorizationModelRet;
            }

            return tvItemUserAuthorizationModel;
        }
        public TVTypeUserAuthorizationModel RandomTVTypeUserAuthorizationModel(bool Add)
        {
            TVTypeUserAuthorizationModel TVTypeUserAuthorizationModel = new TVTypeUserAuthorizationModel();

            TVTypeUserAuthorizationModel.ContactTVItemID = RandomContact().ContactTVItemID;
            TVTypeUserAuthorizationModel.TVType = TVTypeEnum.Municipality;
            TVTypeUserAuthorizationModel.TVAuth = TVAuthEnum.Create;
            //Assert.IsTrue(TVTypeUserAuthorizationModel.ContactTVItemID != 0);
            //Assert.IsTrue(TVTypeUserAuthorizationModel.TVType == TVTypeEnum.Municipality);
            //Assert.IsTrue(TVTypeUserAuthorizationModel.TVAuth == TVAuthEnum.Create);

            if (Add)
            {

                TVTypeUserAuthorizationService TVTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, User);

                TVTypeUserAuthorizationModel TVTypeUserAuthorizationModelRet = TVTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(TVTypeUserAuthorizationModel);

                return TVTypeUserAuthorizationModelRet;
            }

            return TVTypeUserAuthorizationModel;
        }
        public UseOfSiteModel RandomUseOfSiteModel(TVItemModel tvItemModelSite, TVItemModel tvItemModelSubsector, SiteTypeEnum siteType, bool Add)
        {
            UseOfSiteModel useOfSiteModel = new UseOfSiteModel();

            useOfSiteModel.SiteTVItemID = tvItemModelSite.TVItemID;
            useOfSiteModel.SubsectorTVItemID = tvItemModelSubsector.TVItemID;
            useOfSiteModel.SiteType = siteType;
            useOfSiteModel.Ordinal = 1;
            useOfSiteModel.StartYear = RandomInt(1999, 2003);
            useOfSiteModel.EndYear = useOfSiteModel.StartYear + 1;
            useOfSiteModel.UseWeight = true;
            useOfSiteModel.Weight_perc = RandomDouble(0, 100);
            useOfSiteModel.UseEquation = true;
            useOfSiteModel.Param1 = RandomDouble(0, 100);
            useOfSiteModel.Param2 = RandomDouble(0, 100);
            useOfSiteModel.Param3 = RandomDouble(0, 100);
            useOfSiteModel.Param4 = RandomDouble(0, 100);
            //Assert.IsTrue(useOfSiteModel.SiteTVItemID != 0);
            //Assert.IsTrue(useOfSiteModel.SubsectorTVItemID != 0);
            //Assert.IsTrue(useOfSiteModel.SiteType == siteType);
            //Assert.IsTrue(useOfSiteModel.Ordinal == 1);
            //Assert.IsTrue(useOfSiteModel.StartYear > 1998);
            //Assert.IsTrue(useOfSiteModel.EndYear > 1999);
            //Assert.IsTrue(useOfSiteModel.UseWeight == true);
            //Assert.IsTrue(useOfSiteModel.Weight_perc >= 0 && useOfSiteModel.Weight_perc <= 100);
            //Assert.IsTrue(useOfSiteModel.UseEquation == true);
            //Assert.IsTrue(useOfSiteModel.Param1 >= 0 && useOfSiteModel.Param1 <= 100);
            //Assert.IsTrue(useOfSiteModel.Param2 >= 0 && useOfSiteModel.Param2 <= 100);
            //Assert.IsTrue(useOfSiteModel.Param3 >= 0 && useOfSiteModel.Param3 <= 100);
            //Assert.IsTrue(useOfSiteModel.Param4 >= 0 && useOfSiteModel.Param4 <= 100);

            if (Add)
            {

                UseOfSiteService useOfSiteService = new UseOfSiteService(LanguageRequest, User);

                UseOfSiteModel useOfSiteModelRet = useOfSiteService.PostAddUseOfSiteDB(useOfSiteModel);

                return useOfSiteModelRet;
            }

            return useOfSiteModel;
        }
        public VPAmbientModel RandomVPAmbientModel(VPScenarioModel vpScenarioModel, bool Add)
        {
            VPAmbientModel vpAmbientModel = new VPAmbientModel();

            vpAmbientModel.VPScenarioID = vpScenarioModel.VPScenarioID;
            vpAmbientModel.Row = RandomInt(1, 8);
            vpAmbientModel.MeasurementDepth_m = RandomDouble(0, 1000);
            vpAmbientModel.CurrentSpeed_m_s = RandomDouble(0, 10);
            vpAmbientModel.CurrentDirection_deg = RandomDouble(0, 360);
            vpAmbientModel.AmbientSalinity_PSU = RandomDouble(0, 35);
            vpAmbientModel.AmbientTemperature_C = RandomDouble(0, 35);
            vpAmbientModel.BackgroundConcentration_MPN_100ml = RandomInt(1, 10000000);
            vpAmbientModel.PollutantDecayRate_per_day = RandomDouble(0, 100);
            vpAmbientModel.FarFieldCurrentSpeed_m_s = RandomDouble(0, 10);
            vpAmbientModel.FarFieldCurrentDirection_deg = RandomDouble(0, 360);
            vpAmbientModel.FarFieldDiffusionCoefficient = RandomDouble(0, 2);
            //Assert.IsTrue(vpAmbientModel.VPScenarioID != 0);
            //Assert.IsTrue(vpAmbientModel.Row >= 1 && vpAmbientModel.Row <= 8);
            //Assert.IsTrue(vpAmbientModel.MeasurementDepth_m >= 0 && vpAmbientModel.MeasurementDepth_m <= 1000);
            //Assert.IsTrue(vpAmbientModel.CurrentSpeed_m_s >= 0 && vpAmbientModel.CurrentSpeed_m_s <= 10);
            //Assert.IsTrue(vpAmbientModel.CurrentDirection_deg >= 0 && vpAmbientModel.CurrentDirection_deg <= 360);
            //Assert.IsTrue(vpAmbientModel.AmbientSalinity_PSU >= 0 && vpAmbientModel.AmbientSalinity_PSU <= 35);
            //Assert.IsTrue(vpAmbientModel.AmbientTemperature_C >= 0 && vpAmbientModel.AmbientTemperature_C <= 35);
            //Assert.IsTrue(vpAmbientModel.BackgroundConcentration_MPN_100ml >= 0 && vpAmbientModel.BackgroundConcentration_MPN_100ml <= 10000000);
            //Assert.IsTrue(vpAmbientModel.PollutantDecayRate_per_day >= 0 && vpAmbientModel.PollutantDecayRate_per_day <= 100);
            //Assert.IsTrue(vpAmbientModel.FarFieldCurrentSpeed_m_s >= 0 && vpAmbientModel.FarFieldCurrentSpeed_m_s <= 10);
            //Assert.IsTrue(vpAmbientModel.FarFieldCurrentDirection_deg >= 0 && vpAmbientModel.FarFieldCurrentDirection_deg <= 360);
            //Assert.IsTrue(vpAmbientModel.FarFieldDiffusionCoefficient >= 0 && vpAmbientModel.FarFieldDiffusionCoefficient <= 2);

            if (Add)
            {

                VPAmbientService vpAmbientService = new VPAmbientService(LanguageRequest, User);

                VPAmbientModel vpAmbientModelRet = vpAmbientService.PostAddVPAmbientDB(vpAmbientModel);

                return vpAmbientModelRet;
            }

            return vpAmbientModel;
        }
        public VPResultModel RandomVPResultModel(VPScenarioModel vpScenarioModel, bool Add)
        {
            VPResultModel vpResultModel = new VPResultModel();

            vpResultModel.VPScenarioID = vpScenarioModel.VPScenarioID;
            vpResultModel.Ordinal = RandomInt(1, 8000);
            vpResultModel.Concentration_MPN_100ml = RandomInt(0, 10000000);
            vpResultModel.Dilution = RandomDouble(1, 1000000);
            vpResultModel.FarFieldWidth_m = RandomDouble(0, 10000);
            vpResultModel.DispersionDistance_m = RandomDouble(0, 50000);
            vpResultModel.TravelTime_hour = RandomDouble(0, 200);
            //Assert.IsTrue(vpResultModel.VPScenarioID != 0);
            //Assert.IsTrue(vpResultModel.Ordinal >= 1 && vpResultModel.Ordinal <= 8000);
            //Assert.IsTrue(vpResultModel.Concentration_MPN_100ml >= 0 && vpResultModel.Concentration_MPN_100ml <= 10000000);
            //Assert.IsTrue(vpResultModel.Dilution >= 1 && vpResultModel.Dilution <= 1000000);
            //Assert.IsTrue(vpResultModel.FarFieldWidth_m >= 0 && vpResultModel.FarFieldWidth_m <= 10000);
            //Assert.IsTrue(vpResultModel.DispersionDistance_m >= 0 && vpResultModel.DispersionDistance_m <= 50000);
            //Assert.IsTrue(vpResultModel.TravelTime_hour >= 0 && vpResultModel.TravelTime_hour <= 200);

            if (Add)
            {

                VPResultService vpResultService = new VPResultService(LanguageRequest, User);

                VPResultModel vpResultModelRet = vpResultService.PostAddVPResultDB(vpResultModel);

                return vpResultModelRet;
            }

            return vpResultModel;
        }
        public VPScenarioLanguageModel RandomVPScenarioLanguageModel(LanguageEnum Language)
        {
            VPScenarioLanguageModel vpScenarioLanguageModel = new VPScenarioLanguageModel();

            vpScenarioLanguageModel.Language = Language;
            vpScenarioLanguageModel.VPScenarioName = RandomString("VPScenarioName Text", 30);
            vpScenarioLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;
            //Assert.AreEqual(LanguageEnum.en, vpScenarioLanguageModel.Language);
            //Assert.IsTrue(vpScenarioLanguageModel.VPScenarioName.Length == 30);
            //Assert.IsTrue(vpScenarioLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);

            return vpScenarioLanguageModel;
        }
        public VPScenarioModel RandomVPScenarioModel(TVItemModel tvItemModelInfrastructure, bool Add)
        {
            VPScenarioModel vpScenarioModel = new VPScenarioModel();

            vpScenarioModel.InfrastructureTVItemID = tvItemModelInfrastructure.TVItemID;
            vpScenarioModel.VPScenarioName = RandomString("", 30);
            vpScenarioModel.VPScenarioStatus = ScenarioStatusEnum.Changing;
            vpScenarioModel.UseAsBestEstimate = true;
            vpScenarioModel.EffluentFlow_m3_s = RandomDouble(0, 10);
            vpScenarioModel.EffluentConcentration_MPN_100ml = RandomInt(0, 10000000);
            vpScenarioModel.FroudeNumber = RandomDouble(0, 100);
            vpScenarioModel.PortDiameter_m = RandomDouble(0, 10);
            vpScenarioModel.PortDepth_m = RandomDouble(0, 1000);
            vpScenarioModel.PortElevation_m = RandomDouble(0, 1000);
            vpScenarioModel.VerticalAngle_deg = RandomDouble(-90, 90);
            vpScenarioModel.HorizontalAngle_deg = RandomDouble(-180, 180);
            vpScenarioModel.NumberOfPorts = RandomInt(1, 100);
            vpScenarioModel.PortSpacing_m = RandomDouble(0, 10000);
            vpScenarioModel.AcuteMixZone_m = RandomDouble(0, 1000);
            vpScenarioModel.ChronicMixZone_m = RandomDouble(0, 50000);
            vpScenarioModel.EffluentSalinity_PSU = RandomDouble(0, 35);
            vpScenarioModel.EffluentTemperature_C = RandomDouble(0, 35);
            vpScenarioModel.EffluentVelocity_m_s = RandomDouble(0, 10);
            //Assert.IsTrue(vpScenarioModel.InfrastructureTVItemID != 0);
            //Assert.IsTrue(vpScenarioModel.VPScenarioName.Length == 30);
            //Assert.IsTrue(vpScenarioModel.VPScenarioStatus == ScenarioStatusEnum.Changing);
            //Assert.IsTrue(vpScenarioModel.UseAsBestEstimate == true);
            //Assert.IsTrue(vpScenarioModel.EffluentFlow_m3_s >= 0 && vpScenarioModel.EffluentFlow_m3_s <= 10);
            //Assert.IsTrue(vpScenarioModel.EffluentConcentration_MPN_100ml >= 0 && vpScenarioModel.EffluentConcentration_MPN_100ml <= 10000000);
            //Assert.IsTrue(vpScenarioModel.FroudeNumber >= 0 && vpScenarioModel.FroudeNumber <= 100);
            //Assert.IsTrue(vpScenarioModel.PortDiameter_m >= 0 && vpScenarioModel.PortDiameter_m <= 10);
            //Assert.IsTrue(vpScenarioModel.PortDepth_m >= 0 && vpScenarioModel.PortDepth_m <= 1000);
            //Assert.IsTrue(vpScenarioModel.PortElevation_m >= 0 && vpScenarioModel.PortElevation_m <= 1000);
            //Assert.IsTrue(vpScenarioModel.VerticalAngle_deg >= -90 && vpScenarioModel.VerticalAngle_deg <= 90);
            //Assert.IsTrue(vpScenarioModel.HorizontalAngle_deg >= -180 && vpScenarioModel.HorizontalAngle_deg <= 180);
            //Assert.IsTrue(vpScenarioModel.NumberOfPorts >= 1 && vpScenarioModel.NumberOfPorts <= 100);
            //Assert.IsTrue(vpScenarioModel.PortSpacing_m >= 0 && vpScenarioModel.PortSpacing_m <= 10000);
            //Assert.IsTrue(vpScenarioModel.AcuteMixZone_m >= 0 && vpScenarioModel.AcuteMixZone_m <= 1000);
            //Assert.IsTrue(vpScenarioModel.ChronicMixZone_m >= 0 && vpScenarioModel.ChronicMixZone_m <= 50000);
            //Assert.IsTrue(vpScenarioModel.EffluentSalinity_PSU >= 0 && vpScenarioModel.EffluentSalinity_PSU <= 35);
            //Assert.IsTrue(vpScenarioModel.EffluentTemperature_C >= 0 && vpScenarioModel.EffluentTemperature_C <= 35);
            //Assert.IsTrue(vpScenarioModel.EffluentVelocity_m_s >= 0 && vpScenarioModel.EffluentVelocity_m_s <= 10);

            if (Add)
            {

                VPScenarioService vpScenarioService = new VPScenarioService(LanguageRequest, User);

                VPScenarioModel vpScenarioModelRet = vpScenarioService.PostAddVPScenarioDB(vpScenarioModel);

                return vpScenarioModelRet;
            }

            return vpScenarioModel;
        }

        #endregion Functions Random

        #region helpers
        public ContactModel RandomContact()
        {
            ContactService contactService = new ContactService(LanguageRequest, User);

            int Count = contactService.GetContactModelCountDB();

            if (Count == 0)
            {
                return new ContactModel() { ContactID = 0 };
            }

            int skip = random.Next(0, Count);

            ContactModel contactModel = contactService.GetContactModelListDB(skip, 1).FirstOrDefault<ContactModel>();

            return contactModel;
        }
        public DateTime RandomDateTime()
        {
            TVItemService tvItemService = new TVItemService(LanguageRequest, User);

            int Year = random.Next(2005, 2050);
            int Month = random.Next(1, 12);
            int Day = random.Next(1, 28);
            int Hour = random.Next(1, 24);
            int Minute = random.Next(0, 60);
            int Second = random.Next(0, 60);

            return new DateTime(Year, Month, Day, Hour, Minute, Second);
        }
        public double RandomDouble(double min, double max)
        {
            return min + (random.NextDouble() * (max - min));
        }
        public string RandomEmail()
        {
            string Part1 = RandomString("", 12);
            string Part2 = RandomString("", 12);
            string Part3 = RandomString("", 3);
            string Part4 = RandomString("", 2);
            string Part5 = RandomString("", 2);

            string Email = Part1 + "." + Part2 + "@" + Part3 + "." + Part4 + "." + Part5;

            return Email;
        }
        public float RandomFloat(float min, float max)
        {
            return (float)(min + (random.NextDouble() * (max - min)));
        }
        public Guid RandomGuid()
        {
            Guid guid = new Guid();

            return guid;
        }
        public int RandomInt(int min, int max)
        {
            int randomInt = 0;
            randomInt = random.Next(min, max);

            return randomInt;
        }
        public string RandomPassword()
        {
            string Part1 = RandomString("", 7);
            int Part2 = RandomInt(1, 20);

            string Password = Part1 + Part2 + "!";

            return Password;
        }
        public string RandomString(string startString, int length)
        {
            string retStr = startString;

            if (retStr.Length > length)
            {
                retStr = retStr.Substring(0, length);
            }
            else
            {
                int Count = length - retStr.Length;
                for (int i = 0; i < Count; i++)
                {
                    retStr += (char)random.Next(97, 122);
                }
            }

            return retStr;
        }
        public string RandomTel()
        {
            string Part1 = RandomInt(1, 1).ToString();
            string Part2 = RandomInt(506, 506).ToString();
            string Part3 = RandomInt(200, 900).ToString();
            string Part4 = RandomInt(1000, 9000).ToString();

            string Email = Part1 + " (" + Part2 + ") " + Part3 + "-" + Part4;

            return Email;
        }
        public TVItemModel RandomTVItem(TVTypeEnum TVType)
        {
            TVItemService tvItemService = new TVItemService(LanguageRequest, User);

            int Count = tvItemService.GetTVItemModelCountWithTVTypeDB(TVType);

            if (Count == 0)
            {
                return new TVItemModel() { TVItemID = 0 };
            }

            int skip = random.Next(0, Count);

            List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListWithTVTypeDB(TVType);

            return tvItemModelList.Skip(skip).Take(1).FirstOrDefault<TVItemModel>();
        }
        //public AppTaskModel RandomAppTask()
        //{
        //    AppTaskService appTaskService = new AppTaskService(LanguageRequest, User);

        //    int Count = appTaskService.GetAppTaskModelCountDB();

        //    if (Count == 0)
        //    {
        //        return new AppTaskModel() { AppTaskID = 0 };
        //    }

        //    int skip = random.Next(0, Count);

        //    AppTaskModel appTaskModel = appTaskService.GetAppTaskModelListDB(skip, 1).FirstOrDefault<AppTaskModel>();

        //    return appTaskModel;
        //}
        #endregion helpers
    }
}

