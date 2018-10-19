using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPWebToolsDBDLL.Tests.SetupInfo;
using CSSPWebToolsDBDLL.Models;
using System.Security.Principal;
using CSSPWebToolsDBDLL.Services;
using CSSPWebToolsDBDLL.Services.Resources;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Transactions;
using CSSPWebToolsDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for ClimateDataValueServiceTest
    /// </summary>
    [TestClass]
    public class ClimateDataValueServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "ClimateDataValue";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private ClimateDataValueService climateDataValueService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private ClimateDataValueModel climateDataValueModelNew { get; set; }
        private ClimateDataValue climateDataValue { get; set; }
        private ShimClimateDataValueService shimClimateDataValueService { get; set; }
        private ClimateSiteServiceTest climateSiteServiceTest { get; set; }
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #endregion Properties

        #region Constructors
        public ClimateDataValueServiceTest()
        {
            setupData = new SetupData();
        }
        #endregion Constructors

        #region Initialize and Cleanup
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion Initialize and Cleanup

        #region Testing Methods public
        [TestMethod]
        public void ClimateDataValueService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);

                ClimateDataValueService climateDataValueService = new ClimateDataValueService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);

                Assert.IsNotNull(climateDataValueService);
                Assert.IsNotNull(climateDataValueService.db);
                Assert.IsNotNull(climateDataValueService.LanguageRequest);
                Assert.IsNotNull(climateDataValueService.User);
                Assert.AreEqual(user.Identity.Name, climateDataValueService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), climateDataValueService.LanguageRequest);
            }
        }
        [TestMethod]
        public void ClimateDataValueService_ClimateDataValueModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = climateSiteServiceTest.AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    #region Good
                    climateDataValueModelNew.ClimateSiteID = climateSiteModelRet.ClimateSiteID;
                    FillClimateDataValueModel(climateDataValueModelNew);

                    string retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region ClimateSiteID
                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.ClimateSiteID = 0;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ClimateSiteID), retStr);

                    climateDataValueModelNew.ClimateSiteID = climateSiteModelRet.ClimateSiteID;
                    FillClimateDataValueModel(climateDataValueModelNew);

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ClimateSiteID

                    #region DateTime_Local
                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.DateTime_Local = DateTime.UtcNow;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.DateTime_Local = DateTime.UtcNow;
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimClimateDataValueService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion DateTime_Local

                    #region Keep
                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.Keep = false;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.Keep = true;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Keep

                    #region StorageDataType
                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.StorageDataType = (StorageDataTypeEnum)1000;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StorageDataType), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.StorageDataType = StorageDataTypeEnum.Archived;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion StorageDataType

                    #region Snow_cm
                    FillClimateDataValueModel(climateDataValueModelNew);
                    double Min = 0D;
                    double Max = 10000D;
                    climateDataValueModelNew.Snow_cm = Min - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Snow_cm, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.Snow_cm = Max + 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Snow_cm, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.Snow_cm = Max - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.Snow_cm = Min;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.Snow_cm = Max;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Snow_cm

                    #region Rainfall_mm
                    FillClimateDataValueModel(climateDataValueModelNew);
                    Min = 0D;
                    Max = 1000D;
                    climateDataValueModelNew.Rainfall_mm = Min - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Rainfall_mm, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.Rainfall_mm = Max + 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Rainfall_mm, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.Rainfall_mm = Max - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.Rainfall_mm = Min;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.Rainfall_mm = Max;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Rainfall_mm

                    #region RainfallEntered_mm
                    FillClimateDataValueModel(climateDataValueModelNew);
                    Min = 0D;
                    Max = 1000D;
                    climateDataValueModelNew.RainfallEntered_mm = Min - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.RainfallEntered_mm, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.RainfallEntered_mm = Max + 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.RainfallEntered_mm, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.RainfallEntered_mm = Max - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.RainfallEntered_mm = Min;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.RainfallEntered_mm = Max;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion RainfallEntered_mm

                    #region TotalPrecip_mm_cm
                    FillClimateDataValueModel(climateDataValueModelNew);
                    Min = 0D;
                    Max = 1000D;
                    climateDataValueModelNew.TotalPrecip_mm_cm = Min - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TotalPrecip_mm_cm, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.TotalPrecip_mm_cm = Max + 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TotalPrecip_mm_cm, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.TotalPrecip_mm_cm = Max - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.TotalPrecip_mm_cm = Min;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.TotalPrecip_mm_cm = Max;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TotalPrecip_mm_cm

                    #region MaxTemp_C
                    FillClimateDataValueModel(climateDataValueModelNew);
                    Min = -45D;
                    Max = 45D;
                    climateDataValueModelNew.MaxTemp_C = Min - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MaxTemp_C, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.MaxTemp_C = Max + 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MaxTemp_C, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.MaxTemp_C = Max - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.MaxTemp_C = Min;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.MaxTemp_C = Max;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MaxTemp_C

                    #region MinTemp_C
                    FillClimateDataValueModel(climateDataValueModelNew);
                    Min = -45D;
                    Max = 45D;
                    climateDataValueModelNew.MinTemp_C = Min - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MinTemp_C, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.MinTemp_C = Max + 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MinTemp_C, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.MinTemp_C = Max - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.MinTemp_C = Min;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.MinTemp_C = Max;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MinTemp_C

                    #region HeatDegDays_C
                    FillClimateDataValueModel(climateDataValueModelNew);
                    Min = 0D;
                    Max = 45D;
                    climateDataValueModelNew.HeatDegDays_C = Min - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.HeatDegDays_C, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.HeatDegDays_C = Max + 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.HeatDegDays_C, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.HeatDegDays_C = Max - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.HeatDegDays_C = Min;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.HeatDegDays_C = Max;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion HeatDegDays_C

                    #region CoolDegDays_C
                    FillClimateDataValueModel(climateDataValueModelNew);
                    Min = 0D;
                    Max = 45D;
                    climateDataValueModelNew.CoolDegDays_C = Min - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.CoolDegDays_C, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.CoolDegDays_C = Max + 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.CoolDegDays_C, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.CoolDegDays_C = Max - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.CoolDegDays_C = Min;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.CoolDegDays_C = Max;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion CoolDegDays_C

                    #region SnowOnGround_cm
                    FillClimateDataValueModel(climateDataValueModelNew);
                    Min = 0D;
                    Max = 10000D;
                    climateDataValueModelNew.SnowOnGround_cm = Min - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SnowOnGround_cm, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.SnowOnGround_cm = Max + 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SnowOnGround_cm, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.SnowOnGround_cm = Max - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.SnowOnGround_cm = Min;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.SnowOnGround_cm = Max;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SnowOnGround_cm

                    #region DirMaxGust_0North
                    FillClimateDataValueModel(climateDataValueModelNew);
                    Min = 0D;
                    Max = 360D;
                    climateDataValueModelNew.DirMaxGust_0North = Min - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DirMaxGust_0North, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.DirMaxGust_0North = Max + 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DirMaxGust_0North, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.DirMaxGust_0North = Max - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.DirMaxGust_0North = Min;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.DirMaxGust_0North = Max;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion DirMaxGust_0North

                    #region SpdMaxGust_kmh
                    FillClimateDataValueModel(climateDataValueModelNew);
                    Min = 0D;
                    Max = 200D;
                    climateDataValueModelNew.SpdMaxGust_kmh = Min - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SpdMaxGust_kmh, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.SpdMaxGust_kmh = Max + 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SpdMaxGust_kmh, Min, Max), retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.SpdMaxGust_kmh = Max - 1;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.SpdMaxGust_kmh = Min;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.SpdMaxGust_kmh = Max;

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SpdMaxGust_kmh

                    #region HourlyValues
                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.HourlyValues = "";

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateDataValueModel(climateDataValueModelNew);
                    climateDataValueModelNew.HourlyValues = randomService.RandomString("", 200);

                    retStr = climateDataValueService.ClimateDataValueModelOK(climateDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SpdMaxGust_kmh
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_FillClimateDataValue_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = climateSiteServiceTest.AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    climateDataValueModelNew.ClimateSiteID = climateSiteModelRet.ClimateSiteID;

                    FillClimateDataValueModel(climateDataValueModelNew);

                    ContactOK contactOK = climateDataValueService.IsContactOK();

                    string retStr = climateDataValueService.FillClimateDataValue(climateDataValue, climateDataValueModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, climateDataValue.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = climateDataValueService.FillClimateDataValue(climateDataValue, climateDataValueModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, climateDataValue.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_GetClimateDataValueModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                    Assert.AreEqual("", climateDataValueModelRet.Error);

                    int climateDataValueCount = climateDataValueService.GetClimateDataValueModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, climateDataValueCount);
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_GetClimateDataValueModelWithClimateDataValueIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                    Assert.AreEqual("", climateDataValueModelRet.Error);

                    ClimateDataValueModel climateDataValueModelRet2 = climateDataValueService.GetClimateDataValueModelWithClimateDataValueIDDB(climateDataValueModelRet.ClimateDataValueID);
                    Assert.AreEqual("", climateDataValueModelRet2.Error);

                    CompareClimateDataValueModels(climateDataValueModelRet, climateDataValueModelRet2);

                    int ClimateDataValueID = 0;
                    ClimateDataValueModel climateDataValueModelRet3 = climateDataValueService.GetClimateDataValueModelWithClimateDataValueIDDB(ClimateDataValueID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateDataValue, ServiceRes.ClimateDataValueID, ClimateDataValueID), climateDataValueModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_GetClimateDataValueModelExitDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                    Assert.AreEqual("", climateDataValueModelRet.Error);

                    ClimateDataValueModel climateDataValueModelRet2 = climateDataValueService.GetClimateDataValueModelExitDB(climateDataValueModelRet);
                    Assert.AreEqual("", climateDataValueModelRet2.Error);

                    climateDataValueModelRet.DateTime_Local = DateTime.Now.AddDays(-1200);
                    ClimateDataValueModel climateDataValueModelRet3 = climateDataValueService.GetClimateDataValueModelExitDB(climateDataValueModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateDataValue,
                    ServiceRes.ClimateSiteID + "," +
                    ServiceRes.DateTime_Local,
                    climateDataValueModelRet.ClimateSiteID.ToString() + "," +
                    climateDataValueModelRet.DateTime_Local), climateDataValueModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_GetClimateDataValueWithClimateDataValueIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();

                    ClimateDataValue climateDataValueRet = climateDataValueService.GetClimateDataValueWithClimateDataValueIDDB(climateDataValueModelRet.ClimateDataValueID);
                    Assert.AreEqual(climateDataValueModelRet.ClimateDataValueID, climateDataValueRet.ClimateDataValueID);

                    int ClimateDataValueID = 0;
                    ClimateDataValue climateDataValueRet2 = climateDataValueService.GetClimateDataValueWithClimateDataValueIDDB(ClimateDataValueID);
                    Assert.IsNull(climateDataValueRet2);
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    ClimateDataValueModel climateDataValueModelRet = climateDataValueService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, climateDataValueModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostAddDeleteUpdateClimateDataValueDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                    Assert.AreEqual("", climateDataValueModelRet.Error);

                    ClimateDataValueModel climateDataValueModelRet2 = UpdateClimateDataValue(climateDataValueModelRet);
                    Assert.AreEqual("", climateDataValueModelRet2.Error);

                    ClimateDataValueModel climateDataValueModelRet3 = climateDataValueService.PostDeleteClimateDataValueDB(climateDataValueModelRet2.ClimateDataValueID);
                    Assert.AreEqual("", climateDataValueModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostAddClimateDataValueDB_ClimateDataValueModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateDataValueService.ClimateDataValueModelOKClimateDataValueModel = (a) =>
                        {
                            return ErrorText;
                        };

                        ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                        Assert.AreEqual(ErrorText, climateDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostAddClimateDataValueDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateDataValueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                        Assert.AreEqual(ErrorText, climateDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostAddClimateDataValueDB_GetClimateDataValueExitDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimClimateDataValueService.GetClimateDataValueModelExitDBClimateDataValueModel = (a) =>
                        {
                            return new ClimateDataValueModel();
                        };

                        ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.ClimateDataValue), climateDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostAddClimateDataValueDB_FillClimateDataValueModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateDataValueService.FillClimateDataValueClimateDataValueClimateDataValueModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                        Assert.AreEqual(ErrorText, climateDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostAddClimateDataValueDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateDataValueService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                        Assert.AreEqual(ErrorText, climateDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostAddClimateDataValueDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimClimateDataValueService.FillClimateDataValueClimateDataValueClimateDataValueModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                        Assert.IsTrue(climateDataValueModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostDeleteClimateDataValueDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                    Assert.AreEqual("", climateDataValueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateDataValueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ClimateDataValueModel climateDataValueModelRet2 = climateDataValueService.PostDeleteClimateDataValueDB(climateDataValueModelRet.ClimateDataValueID);
                        Assert.AreEqual(ErrorText, climateDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostDeleteClimateDataValueDB_GetClimateDataValueWithClimateDataValueIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                    Assert.AreEqual("", climateDataValueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimClimateDataValueService.GetClimateDataValueWithClimateDataValueIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ClimateDataValueModel climateDataValueModelRet2 = climateDataValueService.PostDeleteClimateDataValueDB(climateDataValueModelRet.ClimateDataValueID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ClimateDataValue), climateDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostDeleteClimateDataValueDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                    Assert.AreEqual("", climateDataValueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateDataValueService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        ClimateDataValueModel climateDataValueModelRet2 = climateDataValueService.PostDeleteClimateDataValueDB(climateDataValueModelRet.ClimateDataValueID);
                        Assert.AreEqual(ErrorText, climateDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostUpdateClimateDataValueDB_ClimateDataValueModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                    Assert.AreEqual("", climateDataValueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateDataValueService.ClimateDataValueModelOKClimateDataValueModel = (a) =>
                        {
                            return ErrorText;
                        };

                        ClimateDataValueModel climateDataValueModelRet2 = UpdateClimateDataValue(climateDataValueModelRet);
                        Assert.AreEqual(ErrorText, climateDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostUpdateClimateDataValueDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                    Assert.AreEqual("", climateDataValueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateDataValueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ClimateDataValueModel climateDataValueModelRet2 = UpdateClimateDataValue(climateDataValueModelRet);
                        Assert.AreEqual(ErrorText, climateDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostUpdateClimateDataValueDB_GetClimateDataValueWithClimateDataValueIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                    Assert.AreEqual("", climateDataValueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimClimateDataValueService.GetClimateDataValueWithClimateDataValueIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ClimateDataValueModel climateDataValueModelRet2 = UpdateClimateDataValue(climateDataValueModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.ClimateDataValue), climateDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostUpdateClimateDataValueDB_FillClimateDataValueModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                    Assert.AreEqual("", climateDataValueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateDataValueService.FillClimateDataValueClimateDataValueClimateDataValueModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        ClimateDataValueModel climateDataValueModelRet2 = UpdateClimateDataValue(climateDataValueModelRet);
                        Assert.AreEqual(ErrorText, climateDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostUpdateClimateDataValueDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateDataValueModel climateDataValueModelRet = AddClimateDataValue();
                    Assert.AreEqual("", climateDataValueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateDataValueService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        ClimateDataValueModel climateDataValueModelRet2 = UpdateClimateDataValue(climateDataValueModelRet);
                        Assert.AreEqual(ErrorText, climateDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostAddDeleteClimateDataValueDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = climateSiteServiceTest.AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    SetupTest(contactModelListBad[0], culture);

                    climateDataValueModelNew.ClimateSiteID = climateSiteModelRet.ClimateSiteID;
                    FillClimateDataValueModel(climateDataValueModelNew);
                    ClimateDataValueModel climateDataValueModelRet = climateDataValueService.PostAddClimateDataValueDB(climateDataValueModelNew);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, climateDataValueModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ClimateDataValueService_PostAddDeleteClimateDataValueDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = climateSiteServiceTest.AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    SetupTest(contactModelListGood[2], culture);

                    climateDataValueModelNew.ClimateSiteID = climateSiteModelRet.ClimateSiteID;
                    FillClimateDataValueModel(climateDataValueModelNew);
                    ClimateDataValueModel climateDataValueModelRet = climateDataValueService.PostAddClimateDataValueDB(climateDataValueModelNew);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, climateDataValueModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Funtions
        private ClimateDataValueModel AddClimateDataValue()
        {
            ClimateSiteModel climateSiteModelRet = climateSiteServiceTest.AddClimateSiteModel();
            Assert.AreEqual("", climateSiteModelRet.Error);

            climateDataValueModelNew.ClimateSiteID = climateSiteModelRet.ClimateSiteID;

            FillClimateDataValueModel(climateDataValueModelNew);

            ClimateDataValueModel climateDataValueModelRet = climateDataValueService.PostAddClimateDataValueDB(climateDataValueModelNew);
            if (!string.IsNullOrWhiteSpace(climateDataValueModelRet.Error))
            {
                return climateDataValueModelRet;
            }

            Assert.IsNotNull(climateDataValueModelRet);
            CompareClimateDataValueModels(climateDataValueModelNew, climateDataValueModelRet);

            return climateDataValueModelRet;
        }
        private ClimateDataValueModel UpdateClimateDataValue(ClimateDataValueModel climateDataValueModelRet)
        {
            FillClimateDataValueModel(climateDataValueModelRet);

            ClimateDataValueModel climateDataValueModelRet2 = climateDataValueService.PostUpdateClimateDataValueDB(climateDataValueModelRet);
            if (!string.IsNullOrWhiteSpace(climateDataValueModelRet2.Error))
            {
                return climateDataValueModelRet2;
            }

            Assert.IsNotNull(climateDataValueModelRet2);
            CompareClimateDataValueModels(climateDataValueModelRet, climateDataValueModelRet2);

            return climateDataValueModelRet2;
        }
        private void CompareClimateDataValueModels(ClimateDataValueModel climateDataValueModelNew, ClimateDataValueModel climateDataValueModelRet)
        {
            Assert.AreEqual(climateDataValueModelNew.ClimateSiteID, climateDataValueModelRet.ClimateSiteID);
            Assert.AreEqual(climateDataValueModelNew.DateTime_Local, climateDataValueModelRet.DateTime_Local);
            Assert.AreEqual(climateDataValueModelNew.Keep, climateDataValueModelRet.Keep);
            Assert.AreEqual(climateDataValueModelNew.StorageDataType, climateDataValueModelRet.StorageDataType);
        }
        private void FillClimateDataValueModel(ClimateDataValueModel climateDataValueModelRet)
        {
            climateDataValueModelRet.ClimateSiteID = climateDataValueModelRet.ClimateSiteID;
            climateDataValueModelRet.DateTime_Local = randomService.RandomDateTime();
            climateDataValueModelRet.Keep = true;
            climateDataValueModelRet.StorageDataType = StorageDataTypeEnum.Archived;
            climateDataValueModelRet.Snow_cm = randomService.RandomDouble(0, 10000);
            climateDataValueModelRet.Rainfall_mm = randomService.RandomDouble(0, 1000);
            climateDataValueModelRet.RainfallEntered_mm = randomService.RandomDouble(0, 1000);
            climateDataValueModelRet.TotalPrecip_mm_cm = randomService.RandomDouble(0, 1000);
            climateDataValueModelRet.MaxTemp_C = randomService.RandomDouble(-45, 45);
            climateDataValueModelRet.MinTemp_C = randomService.RandomDouble(-45, 45);
            climateDataValueModelRet.HeatDegDays_C = randomService.RandomDouble(0, 45);
            climateDataValueModelRet.CoolDegDays_C = randomService.RandomDouble(0, 45);
            climateDataValueModelRet.SnowOnGround_cm = randomService.RandomDouble(0, 10000);
            climateDataValueModelRet.DirMaxGust_0North = randomService.RandomDouble(0, 360);
            climateDataValueModelRet.SpdMaxGust_kmh = randomService.RandomDouble(0, 200);
            climateDataValueModelRet.HourlyValues = randomService.RandomString("", 30);

            Assert.IsTrue(climateDataValueModelRet.ClimateSiteID != 0);
            Assert.IsTrue(climateDataValueModelRet.DateTime_Local != null);
            Assert.IsTrue(climateDataValueModelRet.Keep == true);
            Assert.IsTrue(climateDataValueModelRet.StorageDataType == StorageDataTypeEnum.Archived);
            Assert.IsTrue(climateDataValueModelRet.Snow_cm >= 0 && climateDataValueModelRet.Snow_cm <= 10000);
            Assert.IsTrue(climateDataValueModelRet.Rainfall_mm >= 0 && climateDataValueModelRet.Rainfall_mm <= 1000);
            Assert.IsTrue(climateDataValueModelRet.RainfallEntered_mm >= 0 && climateDataValueModelRet.RainfallEntered_mm <= 1000);
            Assert.IsTrue(climateDataValueModelRet.TotalPrecip_mm_cm >= 0 && climateDataValueModelRet.TotalPrecip_mm_cm <= 1000);
            Assert.IsTrue(climateDataValueModelRet.MaxTemp_C >= -45 && climateDataValueModelRet.MaxTemp_C <= 45);
            Assert.IsTrue(climateDataValueModelRet.MinTemp_C >= -45 && climateDataValueModelRet.MinTemp_C <= 45);
            Assert.IsTrue(climateDataValueModelRet.HeatDegDays_C >= 0 && climateDataValueModelRet.HeatDegDays_C <= 45);
            Assert.IsTrue(climateDataValueModelRet.CoolDegDays_C >= 0 && climateDataValueModelRet.CoolDegDays_C <= 45);
            Assert.IsTrue(climateDataValueModelRet.SnowOnGround_cm >= 0 && climateDataValueModelRet.SnowOnGround_cm <= 10000);
            Assert.IsTrue(climateDataValueModelRet.DirMaxGust_0North >= 0 && climateDataValueModelRet.DirMaxGust_0North <= 360);
            Assert.IsTrue(climateDataValueModelRet.SpdMaxGust_kmh >= 0 && climateDataValueModelRet.SpdMaxGust_kmh <= 200);
            Assert.IsTrue(climateDataValueModelRet.HourlyValues.Length == 30);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            climateDataValueService = new ClimateDataValueService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            climateDataValueModelNew = new ClimateDataValueModel();
            climateDataValue = new ClimateDataValue();
            climateSiteServiceTest = new ClimateSiteServiceTest();
            climateSiteServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimClimateDataValueService = new ShimClimateDataValueService(climateDataValueService);
        }
        #endregion Functions
    }
}
