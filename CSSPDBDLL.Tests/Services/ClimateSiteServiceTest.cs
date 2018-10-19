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
using System.Linq;
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
    /// Summary description for ClimateSiteServiceTest
    /// </summary>
    [TestClass]
    public class ClimateSiteServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "ClimateSite";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private ClimateSiteService climateSiteService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private ClimateSiteModel climateSiteModelNew { get; set; }
        private ClimateSite climateSite { get; set; }
        private ShimClimateSiteService shimClimateSiteService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
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
        public ClimateSiteServiceTest()
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

        #region Testing Methods Public
        [TestMethod]
        public void ClimateSiteService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Assert.IsNotNull(climateSiteService);
                Assert.IsNotNull(climateSiteService._TVItemService);
                Assert.IsNotNull(climateSiteService._TVItemService._TVItemLanguageService);
                Assert.IsNotNull(climateSiteService.db);
                Assert.IsNotNull(climateSiteService.LanguageRequest);
                Assert.IsNotNull(climateSiteService.User);
                Assert.AreEqual(user.Identity.Name, climateSiteService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), climateSiteService.LanguageRequest);
            }
        }
        [TestMethod]
        public void ClimateSiteService_ClimateSiteModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModel = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModel.Error);

                    #region Good
                    climateSiteModelNew.ClimateSiteTVItemID = randomService.RandomTVItem(TVTypeEnum.ClimateSite).TVItemID;
                    climateSiteModelNew.ClimateSiteName = randomService.RandomString("Climate Site ", 26);
                    FillClimateSiteModel(climateSiteModelNew);

                    string retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.ClimateSiteTVItemID = 0;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ClimateSiteTVItemID), retStr);

                    #endregion Good

                    #region ClimateSiteTVItemID

                    climateSiteModelNew.ClimateSiteTVItemID = climateSiteModel.ClimateSiteTVItemID;
                    climateSiteModelNew.ClimateSiteName = randomService.RandomString("Climate Site ", 26);
                    FillClimateSiteModel(climateSiteModelNew);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    climateSiteModelNew.ClimateSiteTVItemID = climateSiteModel.ClimateSiteTVItemID;
                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.ClimateSiteTVItemID = 0;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ClimateSiteTVItemID), retStr);
                    #endregion ClimateSiteTVItemID

                    #region ClimateSiteName
                    int Min = 2;
                    int Max = 100;

                    climateSiteModelNew.ClimateSiteTVItemID = randomService.RandomTVItem(TVTypeEnum.ClimateSite).TVItemID;
                    climateSiteModelNew.ClimateSiteName = randomService.RandomString("Climate Site ", 26);
                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.ClimateSiteName = randomService.RandomString("Cli", Min - 1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.ClimateSiteName, Min), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.ClimateSiteName = randomService.RandomString("Climate", Max + 1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ClimateSiteName, Max), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.ClimateSiteName = randomService.RandomString("Climate", Min);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.ClimateSiteName = randomService.RandomString("Climate", Max);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.ClimateSiteName = randomService.RandomString("Climate", Max - 1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ClimateSiteName

                    #region ECDBID
                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.ECDBID = 0;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ECDBID), retStr);
                    #endregion ECDBID

                    #region Province
                    Min = 2;
                    Max = 4;

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.Province = randomService.RandomString("", Min - 1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.Province, Min), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.Province = randomService.RandomString("", Max + 1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Province, Max), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.Province = randomService.RandomString("NB", 2);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Province

                    #region Elevation_m
                    FillClimateSiteModel(climateSiteModelNew);
                    double MinDbl = 0;
                    double MaxDbl = 10000;
                    climateSiteModelNew.Elevation_m = MinDbl - 1;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Elevation_m, MinDbl, MaxDbl), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.Elevation_m = MaxDbl + 1;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Elevation_m, MinDbl, MaxDbl), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.Elevation_m = MaxDbl - 1;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.Elevation_m = MinDbl;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.Elevation_m = MaxDbl;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Elevation_m

                    #region ClimateID
                    FillClimateSiteModel(climateSiteModelNew);
                    Max = 10;
                    climateSiteModelNew.ClimateID = randomService.RandomString("", 0);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.ClimateID = randomService.RandomString("", Max + 1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ClimateID, Max), retStr);
                    #endregion ClimateID

                    #region WMOID
                    FillClimateSiteModel(climateSiteModelNew);
                    Min = 10000;
                    Max = 99999;
                    climateSiteModelNew.WMOID = Min - 1;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WMOID, Min, Max), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.WMOID = Max + 1;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WMOID, Min, Max), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.WMOID = Max - 1;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.WMOID = Min;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.WMOID = Max;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion WMOID

                    #region TCID
                    FillClimateSiteModel(climateSiteModelNew);
                    Min = 3;
                    Max = 3;
                    climateSiteModelNew.TCID = randomService.RandomString("", 0);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.TCID = randomService.RandomString("", Max + 1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.TCID, Max), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.TCID = randomService.RandomString("", Max);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TCID

                    #region ProvSiteID
                    FillClimateSiteModel(climateSiteModelNew);
                    Max = 50;
                    climateSiteModelNew.ProvSiteID = randomService.RandomString("", 0);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.ProvSiteID = randomService.RandomString("", Max + 1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ProvSiteID, Max), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.ProvSiteID = randomService.RandomString("", Max);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ProvSiteID

                    #region TimeOffset_hour
                    FillClimateSiteModel(climateSiteModelNew);
                    MinDbl = -8;
                    MaxDbl = -3;
                    climateSiteModelNew.TimeOffset_hour = MinDbl - 1;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TimeOffset_hour, MinDbl, MaxDbl), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.TimeOffset_hour = MaxDbl + 1;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TimeOffset_hour, MinDbl, MaxDbl), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.TimeOffset_hour = MaxDbl - 1;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.TimeOffset_hour = MinDbl;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.TimeOffset_hour = MaxDbl;

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion TimeOffset_hour

                    #region File_desc
                    FillClimateSiteModel(climateSiteModelNew);
                    Max = 50;
                    climateSiteModelNew.File_desc = randomService.RandomString("", 0);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.File_desc = randomService.RandomString("", Max + 1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.File_desc, Max), retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.File_desc = randomService.RandomString("", Max);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion File_desc

                    #region HourlyStartDate_Local
                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.HourlyStartDate_Local = DateTime.UtcNow;
                    climateSiteModelNew.HourlyEndDate_Local = climateSiteModelNew.HourlyStartDate_Local.Value.AddHours(1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.HourlyStartDate_Local = DateTime.UtcNow;
                    climateSiteModelNew.HourlyEndDate_Local = climateSiteModelNew.HourlyStartDate_Local.Value.AddHours(-1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsBiggerOrEqualTo_, ServiceRes.HourlyStartDate_Local, ServiceRes.HourlyEndDate_Local), retStr);

                    #endregion HourlyStartDate_Local

                    #region DailyStartDate_Local
                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.DailyStartDate_Local = DateTime.UtcNow;
                    climateSiteModelNew.DailyEndDate_Local = climateSiteModelNew.DailyStartDate_Local.Value.AddHours(1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.DailyStartDate_Local = DateTime.UtcNow;
                    climateSiteModelNew.DailyEndDate_Local = climateSiteModelNew.DailyStartDate_Local.Value.AddHours(-1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsBiggerOrEqualTo_, ServiceRes.DailyStartDate_Local, ServiceRes.DailyEndDate_Local), retStr);

                    #endregion DailyStartDate_Local

                    #region MonthlyStartDate_Local
                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.MonthlyStartDate_Local = DateTime.UtcNow;
                    climateSiteModelNew.MonthlyEndDate_Local = climateSiteModelNew.MonthlyStartDate_Local.Value.AddHours(1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillClimateSiteModel(climateSiteModelNew);
                    climateSiteModelNew.MonthlyStartDate_Local = DateTime.UtcNow;
                    climateSiteModelNew.MonthlyEndDate_Local = climateSiteModelNew.MonthlyStartDate_Local.Value.AddHours(-1);

                    retStr = climateSiteService.ClimateSiteModelOK(climateSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsBiggerOrEqualTo_, ServiceRes.MonthlyStartDate_Local, ServiceRes.MonthlyEndDate_Local), retStr);

                    #endregion MonthlyStartDate_Local
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_FillClimateSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    climateSiteModelNew.ClimateSiteTVItemID = randomService.RandomTVItem(TVTypeEnum.ClimateSite).TVItemID;
                    climateSiteModelNew.ClimateSiteName = randomService.RandomString("Climate Site ", 26);
                    FillClimateSiteModel(climateSiteModelNew);

                    ContactOK contactOK = climateSiteService.IsContactOK();

                    string retStr = climateSiteService.FillClimateSite(climateSite, climateSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, climateSite.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = climateSiteService.FillClimateSite(climateSite, climateSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, climateSite.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_GetClimateSiteModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    int climateSiteCount = climateSiteService.GetClimateSiteModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, climateSiteCount);

                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_GetClimateSiteModelWithClimateIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    ClimateSiteModel climateSiteModelRet2 = climateSiteService.GetClimateSiteModelWithClimateIDDB(climateSiteModelRet.ClimateID);
                    Assert.IsNotNull(climateSiteModelRet2);
                    CompareClimateSiteModels(climateSiteModelRet, climateSiteModelRet2);

                    string ClimateID = "NOTExist";
                    ClimateSiteModel climateSiteModelRet3 = climateSiteService.GetClimateSiteModelWithClimateIDDB(ClimateID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateSite, ServiceRes.ClimateID, ClimateID), climateSiteModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_GetClimateSiteModelWithClimateSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    ClimateSiteModel climateSiteModelRet2 = climateSiteService.GetClimateSiteModelWithClimateSiteIDDB(climateSiteModelRet.ClimateSiteID);
                    Assert.IsNotNull(climateSiteModelRet2);
                    CompareClimateSiteModels(climateSiteModelRet, climateSiteModelRet2);

                    int ClimateSiteID = 0;
                    ClimateSiteModel climateSiteModelRet3 = climateSiteService.GetClimateSiteModelWithClimateSiteIDDB(ClimateSiteID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateSite, ServiceRes.ClimateSiteID, ClimateSiteID), climateSiteModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_GetClimateSiteModelWithClimateSiteTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    ClimateSiteModel climateSiteModelRet2 = climateSiteService.GetClimateSiteModelWithClimateSiteTVItemIDDB(climateSiteModelRet.ClimateSiteTVItemID);
                    Assert.IsNotNull(climateSiteModelRet2);
                    CompareClimateSiteModels(climateSiteModelRet, climateSiteModelRet2);

                    int ClimateSiteTVItemID = 0;
                    ClimateSiteModel climateSiteModelRet3 = climateSiteService.GetClimateSiteModelWithClimateSiteTVItemIDDB(ClimateSiteTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateSite, ServiceRes.ClimateSiteTVItemID, ClimateSiteTVItemID), climateSiteModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_GetClimateSiteWithClimateSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    ClimateSite climateSiteRet2 = climateSiteService.GetClimateSiteWithClimateSiteIDDB(climateSiteModelRet.ClimateSiteID);
                    Assert.IsNotNull(climateSiteRet2);
                    Assert.AreEqual(climateSiteModelRet.ClimateSiteID, climateSiteRet2.ClimateSiteID);

                    ClimateSite climateSiteRet3 = climateSiteService.GetClimateSiteWithClimateSiteIDDB(0);
                    Assert.IsNull(climateSiteRet3);
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    string retStr = climateSiteService.CreateTVText(climateSiteModelRet);
                    Assert.AreEqual(climateSiteModelRet.ClimateSiteName + (climateSiteModelRet.ClimateID == null ? (climateSiteModelRet.ProvSiteID == null ? "" : ("(" + climateSiteModelRet.ProvSiteID + ")")) : ("(" + climateSiteModelRet.ClimateID + ")")), retStr);

                    climateSiteModelRet.ClimateSiteName = "";
                    retStr = climateSiteService.CreateTVText(climateSiteModelRet);
                    Assert.AreEqual(climateSiteModelRet.ClimateSiteName + (climateSiteModelRet.ClimateID == null ? (climateSiteModelRet.ProvSiteID == null ? "" : ("(" + climateSiteModelRet.ProvSiteID + ")")) : ("(" + climateSiteModelRet.ClimateID + ")")), retStr);
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_GetProvinceTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> ProvTxtList = new List<string>()
                    {
                        "BC", "NB", "NFLD", "NS", "PEI", "QC", "QUE", "othertest", "", "lsiefj",
                    };

                    foreach (string s in ProvTxtList)
                    {
                        string retStr = climateSiteService.GetProvinceTVText(s);

                        if (culture.TwoLetterISOLanguageName == "fr")
                        {
                            switch (s)
                            {
                                case "BC":
                                    {
                                        Assert.AreEqual("Colombie-Britannique", retStr);
                                    }
                                    break;
                                case "NB":
                                    {
                                        Assert.AreEqual("Nouveau-Brunswick", retStr);
                                    }
                                    break;
                                case "NFLD":
                                    {
                                        Assert.AreEqual("Terre-Neuve et Labrador", retStr);
                                    }
                                    break;
                                case "NS":
                                    {
                                        Assert.AreEqual("Nouvelle-Écosse", retStr);
                                    }
                                    break;
                                case "PEI":
                                    {
                                        Assert.AreEqual("Ile-du-Prince-Edouard", retStr);
                                    }
                                    break;
                                case "QC":
                                    {
                                        Assert.AreEqual("Québec", retStr);
                                    }
                                    break;
                                case "QUE":
                                    {
                                        Assert.AreEqual("Québec", retStr);
                                    }
                                    break;
                                default:
                                    {
                                        Assert.AreEqual("", retStr);
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (s)
                            {
                                case "BC":
                                    {
                                        Assert.AreEqual("British Columbia", retStr);
                                    }
                                    break;
                                case "NB":
                                    {
                                        Assert.AreEqual("New Brunswick", retStr);
                                    }
                                    break;
                                case "NFLD":
                                    {
                                        Assert.AreEqual("Newfounland and Labrador", retStr);
                                    }
                                    break;
                                case "NS":
                                    {
                                        Assert.AreEqual("Nova Scotia", retStr);
                                    }
                                    break;
                                case "PEI":
                                    {
                                        Assert.AreEqual("Prince Edward Island", retStr);
                                    }
                                    break;
                                case "QC":
                                    {
                                        Assert.AreEqual("Quebec", retStr);
                                    }
                                    break;
                                case "QUE":
                                    {
                                        Assert.AreEqual("Quebec", retStr);
                                    }
                                    break;
                                default:
                                    {
                                        Assert.AreEqual("", retStr);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    ClimateSiteModel climateSiteModel = climateSiteService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, climateSiteModel.Error);
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostAddUpdateDeleteClimateSite_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    ClimateSiteModel climateSiteModelRet2 = UpdateClimateSiteModel(climateSiteModelRet);
                    Assert.AreEqual("", climateSiteModelRet2.Error);

                    ClimateSiteModel climateSiteModelRet3 = climateSiteService.PostDeleteClimateSiteDB(climateSiteModelRet2.ClimateSiteID);
                    Assert.AreEqual("", climateSiteModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostAddClimateSiteDB_ClimateSiteModelOK_Error_Test()
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
                        shimClimateSiteService.ClimateSiteModelOKClimateSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                        Assert.AreEqual(ErrorText, climateSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostAddClimateSiteDB_IsContactOK_Error_Test()
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
                        shimClimateSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                        Assert.AreEqual(ErrorText, climateSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostAddClimateSiteDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
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
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                        Assert.AreEqual(ErrorText, climateSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostAddClimateSiteDB_FillClimateSite_Error_Test()
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
                        shimClimateSiteService.FillClimateSiteClimateSiteClimateSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                        Assert.AreEqual(ErrorText, climateSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostAddClimateSiteDB_DoAddChanges_Error_Test()
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
                        shimClimateSiteService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                        Assert.AreEqual(ErrorText, climateSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostAddClimateSiteDB_Add_Error_Test()
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
                        shimClimateSiteService.FillClimateSiteClimateSiteClimateSiteModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                        Assert.IsTrue(climateSiteModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostAddClimateSiteDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.IsNotNull(climateSiteModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, climateSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostAddClimateSiteDB_UserClimateSiteNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.IsNotNull(climateSiteModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, climateSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostDeleteClimateSite_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostDeleteClimateSiteDB(climateSiteModelRet.ClimateSiteID);
                        Assert.AreEqual(ErrorText, climateSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostDeleteClimateSite_GetClimateSiteWithClimateSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimClimateSiteService.GetClimateSiteWithClimateSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostDeleteClimateSiteDB(climateSiteModelRet.ClimateSiteID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ClimateSite), climateSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostDeleteClimateSite_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateSiteService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostDeleteClimateSiteDB(climateSiteModelRet.ClimateSiteID);
                        Assert.AreEqual(ErrorText, climateSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostDeleteClimateSite_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostDeleteClimateSiteDB(climateSiteModelRet.ClimateSiteID);
                        Assert.AreEqual(ErrorText, climateSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostUpdateClimateSite_ClimateSiteModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    FillClimateSiteModel(climateSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateSiteService.ClimateSiteModelOKClimateSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostUpdateClimateSiteDB(climateSiteModelRet);
                        Assert.AreEqual(ErrorText, climateSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostUpdateClimateSite_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    FillClimateSiteModel(climateSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostUpdateClimateSiteDB(climateSiteModelRet);
                        Assert.AreEqual(ErrorText, climateSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostUpdateClimateSite_GetClimateSiteWithClimateSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    FillClimateSiteModel(climateSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimClimateSiteService.GetClimateSiteWithClimateSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostUpdateClimateSiteDB(climateSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.ClimateSite), climateSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostUpdateClimateSite_FillClimateSite_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    FillClimateSiteModel(climateSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateSiteService.FillClimateSiteClimateSiteClimateSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostUpdateClimateSiteDB(climateSiteModelRet);
                        Assert.AreEqual(ErrorText, climateSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostUpdateClimateSite_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    FillClimateSiteModel(climateSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimClimateSiteService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostUpdateClimateSiteDB(climateSiteModelRet);
                        Assert.AreEqual(ErrorText, climateSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostUpdateClimateSite_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    FillClimateSiteModel(climateSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostUpdateClimateSiteDB(climateSiteModelRet);
                        Assert.AreEqual(ErrorText, climateSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostUpdateClimateSite_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    FillClimateSiteModel(climateSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimClimateSiteService.CreateTVTextClimateSiteModel = (a) =>
                        {
                            return "";
                        };

                        ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostUpdateClimateSiteDB(climateSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, "TVText"), climateSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ClimateSiteService_PostUpdateClimateSite_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ClimateSiteModel climateSiteModelRet = AddClimateSiteModel();
                    Assert.AreEqual("", climateSiteModelRet.Error);

                    FillClimateSiteModel(climateSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostUpdateClimateSiteDB(climateSiteModelRet);
                        Assert.AreEqual(ErrorText, climateSiteModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Function
        public ClimateSiteModel AddClimateSiteModel()
        {
            int TVItemIDParent = randomService.RandomTVItem(TVTypeEnum.Province).TVItemID;

            string TVText = randomService.RandomString("Climate Site ", 26);
            TVItemModel tvItemModelClimateSite = climateSiteService._TVItemService.PostAddChildTVItemDB(TVItemIDParent, TVText, TVTypeEnum.ClimateSite);
            if (!string.IsNullOrWhiteSpace(tvItemModelClimateSite.Error))
            {
                return new ClimateSiteModel() { Error = tvItemModelClimateSite.Error };
            }

            climateSiteModelNew.ClimateSiteTVItemID = tvItemModelClimateSite.TVItemID;
            FillClimateSiteModel(climateSiteModelNew);


            ClimateSiteModel climateSiteModelRet = climateSiteService.PostAddClimateSiteDB(climateSiteModelNew);
            if (!string.IsNullOrWhiteSpace(climateSiteModelRet.Error))
            {
                return climateSiteModelRet;
            }

            climateSiteModelNew.ClimateSiteTVItemID = climateSiteModelRet.ClimateSiteTVItemID;

            CompareClimateSiteModels(climateSiteModelNew, climateSiteModelRet);

            return climateSiteModelRet;

        }
        public ClimateSiteModel UpdateClimateSiteModel(ClimateSiteModel climateSiteModel)
        {
            FillClimateSiteModel(climateSiteModel);

            ClimateSiteModel climateSiteModelRet2 = climateSiteService.PostUpdateClimateSiteDB(climateSiteModel);
            if (!string.IsNullOrWhiteSpace(climateSiteModelRet2.Error))
            {
                return climateSiteModelRet2;
            }

            CompareClimateSiteModels(climateSiteModel, climateSiteModelRet2);

            return climateSiteModelRet2;
        }
        public void CompareClimateSiteModels(ClimateSiteModel climateSiteModelRet, ClimateSiteModel climateSiteModel)
        {
            Assert.AreEqual(climateSiteModelRet.ECDBID, climateSiteModel.ECDBID);
            Assert.AreEqual(climateSiteModelRet.ClimateSiteName, climateSiteModel.ClimateSiteName);
            Assert.AreEqual(climateSiteModelRet.Province, climateSiteModel.Province);
            Assert.AreEqual(climateSiteModelRet.Elevation_m, climateSiteModel.Elevation_m);
            Assert.AreEqual(climateSiteModelRet.ClimateID, climateSiteModel.ClimateID);
            Assert.AreEqual(climateSiteModelRet.WMOID, climateSiteModel.WMOID);
            Assert.AreEqual(climateSiteModelRet.TCID, climateSiteModel.TCID);
            Assert.AreEqual(climateSiteModelRet.IsProvincial, climateSiteModel.IsProvincial);
            Assert.AreEqual(climateSiteModelRet.ProvSiteID, climateSiteModel.ProvSiteID);
            Assert.AreEqual(climateSiteModelRet.TimeOffset_hour, climateSiteModel.TimeOffset_hour);
            Assert.AreEqual(climateSiteModelRet.File_desc, climateSiteModel.File_desc);
            Assert.AreEqual(climateSiteModelRet.HourlyStartDate_Local, climateSiteModel.HourlyStartDate_Local);
            Assert.AreEqual(climateSiteModelRet.HourlyEndDate_Local, climateSiteModel.HourlyEndDate_Local);
            Assert.AreEqual(climateSiteModelRet.HourlyNow, climateSiteModel.HourlyNow);
            Assert.AreEqual(climateSiteModelRet.DailyStartDate_Local, climateSiteModel.DailyStartDate_Local);
            Assert.AreEqual(climateSiteModelRet.DailyEndDate_Local, climateSiteModel.DailyEndDate_Local);
            Assert.AreEqual(climateSiteModelRet.DailyNow, climateSiteModel.DailyNow);
            Assert.AreEqual(climateSiteModelRet.MonthlyStartDate_Local, climateSiteModel.MonthlyStartDate_Local);
            Assert.AreEqual(climateSiteModelRet.MonthlyEndDate_Local, climateSiteModel.MonthlyEndDate_Local);
            Assert.AreEqual(climateSiteModelRet.MonthlyNow, climateSiteModel.MonthlyNow);
        }
        public void FillClimateSiteModel(ClimateSiteModel climateSiteModel)
        {
            climateSiteModel.ClimateSiteTVItemID = climateSiteModel.ClimateSiteTVItemID;
            climateSiteModel.ClimateID = randomService.RandomString("81004", 10);
            climateSiteModel.ClimateSiteName = randomService.RandomString("Climate Site Name ", 30);
            climateSiteModel.DailyStartDate_Local = randomService.RandomDateTime();
            climateSiteModel.DailyEndDate_Local = climateSiteModel.DailyStartDate_Local.Value.AddHours(1);
            climateSiteModel.DailyNow = true;
            climateSiteModel.ECDBID = randomService.RandomInt(6918, 7918);
            climateSiteModel.Elevation_m = randomService.RandomInt(0, 10000);
            climateSiteModel.File_desc = randomService.RandomString("File_desc", 30);
            climateSiteModel.HourlyStartDate_Local = randomService.RandomDateTime();
            climateSiteModel.HourlyEndDate_Local = climateSiteModel.HourlyStartDate_Local.Value.AddHours(1);
            climateSiteModel.HourlyNow = true;
            climateSiteModel.IsProvincial = true;
            climateSiteModel.MonthlyStartDate_Local = randomService.RandomDateTime();
            climateSiteModel.MonthlyEndDate_Local = climateSiteModel.MonthlyStartDate_Local.Value.AddHours(1);
            climateSiteModel.MonthlyNow = false;
            climateSiteModel.Province = randomService.RandomString("NB", 2);
            climateSiteModel.ProvSiteID = randomService.RandomString("NB", 5);
            climateSiteModel.TCID = randomService.RandomString("WX", 3);
            climateSiteModel.TimeOffset_hour = randomService.RandomInt(-8, -3);
            climateSiteModel.WMOID = randomService.RandomInt(10000, 99999);

            Assert.IsTrue(climateSiteModel.ClimateSiteTVItemID > 0);
            Assert.IsTrue(climateSiteModel.ClimateID.Length == 10);
            Assert.IsTrue(climateSiteModel.ClimateSiteName.Length > 0);
            Assert.IsTrue(climateSiteModel.DailyEndDate_Local != null);
            Assert.IsTrue(climateSiteModel.DailyNow == true);
            Assert.IsTrue(climateSiteModel.DailyStartDate_Local != null);
            Assert.IsTrue(climateSiteModel.ECDBID >= 6918 && climateSiteModel.ECDBID <= 7918);
            Assert.IsTrue(climateSiteModel.Elevation_m >= 0 && climateSiteModel.Elevation_m <= 10000);
            Assert.IsTrue(climateSiteModel.File_desc.Length == 30);
            Assert.IsTrue(climateSiteModel.HourlyEndDate_Local != null);
            Assert.IsTrue(climateSiteModel.HourlyStartDate_Local != null);
            Assert.IsTrue(climateSiteModel.IsProvincial == true);
            Assert.IsTrue(climateSiteModel.MonthlyEndDate_Local != null);
            Assert.IsTrue(climateSiteModel.MonthlyNow == false);
            Assert.IsTrue(climateSiteModel.MonthlyStartDate_Local != null);
            Assert.IsTrue(climateSiteModel.Province == "NB");
            Assert.IsTrue(climateSiteModel.ProvSiteID.Length == 5);
            Assert.IsTrue(climateSiteModel.TCID.Length == 3);
            Assert.IsTrue(climateSiteModel.TimeOffset_hour >= -8 && climateSiteModel.TimeOffset_hour <= -4);
            Assert.IsTrue(climateSiteModel.WMOID >= 10000 && climateSiteModel.WMOID <= 99999);

        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            climateSiteService = new ClimateSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            climateSiteModelNew = new ClimateSiteModel();
            climateSite = new ClimateSite();
        }
        private void SetupShim()
        {
            shimClimateSiteService = new ShimClimateSiteService(climateSiteService);
            shimTVItemService = new ShimTVItemService(climateSiteService._TVItemService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(climateSiteService._TVItemService._TVItemLanguageService);
        }
        #endregion Function
    }
}
