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
    /// Summary description for HydrometricSiteServiceTest
    /// </summary>
    [TestClass]
    public class HydrometricSiteServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "HydrometricSite";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private HydrometricSiteService hydrometricSiteService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private HydrometricSiteModel hydrometricSiteModelNew { get; set; }
        private HydrometricSite hydrometricSite { get; set; }
        private ShimHydrometricSiteService shimHydrometricSiteService { get; set; }
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
        public HydrometricSiteServiceTest()
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
        public void HydrometricSiteService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(hydrometricSiteService);
                Assert.IsNotNull(hydrometricSiteService._TVItemService);
                Assert.IsNotNull(hydrometricSiteService._TVItemService._TVItemLanguageService);
                Assert.IsNotNull(hydrometricSiteService.db);
                Assert.IsNotNull(hydrometricSiteService.LanguageRequest);
                Assert.IsNotNull(hydrometricSiteService.User);
                Assert.AreEqual(user.Identity.Name, hydrometricSiteService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), hydrometricSiteService.LanguageRequest);
            }
        }
        [TestMethod]
        public void HydrometricSiteService_HydrometricSiteModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModel = AddHydrometricSiteModel();

                    #region Good
                    hydrometricSiteModelNew.HydrometricSiteTVItemID = hydrometricSiteModel.HydrometricSiteTVItemID;
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);

                    string retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.HydrometricSiteTVItemID = 0;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.HydrometricSiteTVItemID), retStr);

                    #endregion Good

                    #region HydrometricSiteTVItemID
                    hydrometricSiteModelNew.HydrometricSiteTVItemID = hydrometricSiteModel.HydrometricSiteTVItemID;
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    hydrometricSiteModelNew.HydrometricSiteTVItemID = hydrometricSiteModel.HydrometricSiteTVItemID;
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.HydrometricSiteTVItemID = 0;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.HydrometricSiteTVItemID), retStr);
                    #endregion HydrometricSiteTVItemID

                    #region HydrometricSiteName
                    int Min = 2;
                    int Max = 200;

                    hydrometricSiteModelNew.HydrometricSiteTVItemID = hydrometricSiteModel.HydrometricSiteTVItemID;
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.HydrometricSiteName = randomService.RandomString("", Min - 1);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.HydrometricSiteName, Min), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.HydrometricSiteName = randomService.RandomString("", Max + 1);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.HydrometricSiteName, Max), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.HydrometricSiteName = randomService.RandomString("", Min);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.HydrometricSiteName = randomService.RandomString("", Max);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.HydrometricSiteName = randomService.RandomString("", Max - 1);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion HydrometricSiteName

                    #region Province
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    Min = 2;
                    Max = 2;

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.Province = randomService.RandomString("", Min - 1);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.Province, Min), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.Province = randomService.RandomString("", Max + 1);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Province, Max), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.Province = randomService.RandomString("NB", Min);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Province

                    #region FedSiteNumber
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    Min = 7;
                    Max = 7;
                    hydrometricSiteModelNew.FedSiteNumber = randomService.RandomString("", 0);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.FedSiteNumber = randomService.RandomString("", Min - 1);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.FedSiteNumber = randomService.RandomString("", Max + 1);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.FedSiteNumber, Max), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.FedSiteNumber = randomService.RandomString("", Min);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion FedSiteNumber

                    #region QuebecSiteNumber
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    Max = 7;
                    hydrometricSiteModelNew.QuebecSiteNumber = randomService.RandomString("", 0);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.QuebecSiteNumber = randomService.RandomString("", Max + 1);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.QuebecSiteNumber, Max), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.QuebecSiteNumber = randomService.RandomString("", Min);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion QuebecSiteNumber

                    #region Description
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    Min = 2;
                    Max = 200;
                    hydrometricSiteModelNew.Description = randomService.RandomString("", 0);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.Description = randomService.RandomString("", Max + 1);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Description, Max), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.Description = randomService.RandomString("", Min);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Description

                    #region Elevation_m
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    double MinDbl = 0;
                    double MaxDbl = 10000;
                    hydrometricSiteModelNew.Elevation_m = MinDbl - 1;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Elevation_m, MinDbl, MaxDbl), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.Elevation_m = MaxDbl + 1;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Elevation_m, MinDbl, MaxDbl), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.Elevation_m = MaxDbl - 1;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.Elevation_m = MinDbl;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.Elevation_m = MaxDbl;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Elevation_m

                    #region HourlyStartDate_Local
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.StartDate_Local = DateTime.UtcNow;
                    hydrometricSiteModelNew.EndDate_Local = hydrometricSiteModelNew.StartDate_Local.Value.AddHours(1);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.StartDate_Local = DateTime.UtcNow;
                    hydrometricSiteModelNew.EndDate_Local = hydrometricSiteModelNew.StartDate_Local.Value.AddHours(-1);

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsBiggerOrEqualTo_, ServiceRes.StartDate_Local, ServiceRes.EndDate_Local), retStr);

                    #endregion HourlyStartDate_Local

                    #region TimeOffset_hour
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    MinDbl = -8;
                    MaxDbl = -3;
                    hydrometricSiteModelNew.TimeOffset_hour = MinDbl - 1;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TimeOffset_hour, MinDbl, MaxDbl), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.TimeOffset_hour = MaxDbl + 1;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TimeOffset_hour, MinDbl, MaxDbl), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.TimeOffset_hour = MaxDbl - 1;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.TimeOffset_hour = MinDbl;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.TimeOffset_hour = MaxDbl;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion TimeOffset_hour

                    #region DrainageArea_km2
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    MinDbl = 0;
                    MaxDbl = 10000000;
                    hydrometricSiteModelNew.DrainageArea_km2 = MinDbl - 1;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DrainageArea_km2, MinDbl, MaxDbl), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.DrainageArea_km2 = MaxDbl + 1;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DrainageArea_km2, MinDbl, MaxDbl), retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.DrainageArea_km2 = MaxDbl - 1;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.DrainageArea_km2 = MinDbl;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);
                    hydrometricSiteModelNew.DrainageArea_km2 = MaxDbl;

                    retStr = hydrometricSiteService.HydrometricSiteModelOK(hydrometricSiteModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion DrainageArea_km2
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_FillHydrometricSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModel = AddHydrometricSiteModel();
                    Assert.AreEqual("", hydrometricSiteModel.Error);

                    hydrometricSiteModelNew.HydrometricSiteID = hydrometricSiteModel.HydrometricSiteID;
                    FillHydrometricSiteModelNew(hydrometricSiteModelNew);

                    ContactOK contactOK = hydrometricSiteService.IsContactOK();

                    string retStr = hydrometricSiteService.FillHydrometricSite(hydrometricSite, hydrometricSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, hydrometricSite.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = hydrometricSiteService.FillHydrometricSite(hydrometricSite, hydrometricSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, hydrometricSite.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_GetHydrometricSiteModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    int hydrometricSiteCount = hydrometricSiteService.GetHydrometricSiteModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, hydrometricSiteCount);

                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_GetHydrometricSiteModelWithHydrometricSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.GetHydrometricSiteModelWithHydrometricSiteIDDB(hydrometricSiteModelRet.HydrometricSiteID);
                    Assert.IsNotNull(hydrometricSiteModelRet2);
                    CompareHydrometricSiteModels(hydrometricSiteModelRet, hydrometricSiteModelRet2);

                    int HydrometricSiteID = 0;
                    HydrometricSiteModel hydrometricSiteModelRet3 = hydrometricSiteService.GetHydrometricSiteModelWithHydrometricSiteIDDB(HydrometricSiteID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite, ServiceRes.HydrometricSiteID, HydrometricSiteID), hydrometricSiteModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_GetHydrometricSiteModelWithHydrometricSiteTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.GetHydrometricSiteModelWithHydrometricSiteTVItemIDDB(hydrometricSiteModelRet.HydrometricSiteTVItemID);
                    Assert.IsNotNull(hydrometricSiteModelRet2);
                    CompareHydrometricSiteModels(hydrometricSiteModelRet, hydrometricSiteModelRet2);

                    int HydrometricSiteTVItemID = 0;
                    HydrometricSiteModel hydrometricSiteModelRet3 = hydrometricSiteService.GetHydrometricSiteModelWithHydrometricSiteIDDB(HydrometricSiteTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite, ServiceRes.HydrometricSiteID, HydrometricSiteTVItemID), hydrometricSiteModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_GetHydrometricSiteWithHydrometricSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    HydrometricSite hydrometricSiteRet2 = hydrometricSiteService.GetHydrometricSiteWithHydrometricSiteIDDB(hydrometricSiteModelRet.HydrometricSiteID);
                    Assert.IsNotNull(hydrometricSiteRet2);
                    Assert.AreEqual(hydrometricSiteModelRet.HydrometricSiteID, hydrometricSiteRet2.HydrometricSiteID);

                    HydrometricSite hydrometricSiteRet3 = hydrometricSiteService.GetHydrometricSiteWithHydrometricSiteIDDB(0);
                    Assert.IsNull(hydrometricSiteRet3);
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    string retStr = hydrometricSiteService.CreateTVText(hydrometricSiteModelRet);
                    Assert.AreEqual(hydrometricSiteModelRet.HydrometricSiteName +
(hydrometricSiteModelRet.FedSiteNumber == null ? "" : " Fed:[" + hydrometricSiteModelRet.FedSiteNumber + "]") +
(hydrometricSiteModelRet.QuebecSiteNumber == null ? "" : " QC:[" + hydrometricSiteModelRet.QuebecSiteNumber + "]"), retStr);

                    hydrometricSiteModelRet.HydrometricSiteName = "";
                    retStr = hydrometricSiteService.CreateTVText(hydrometricSiteModelRet);
                    Assert.AreEqual(hydrometricSiteModelRet.HydrometricSiteName +
(hydrometricSiteModelRet.FedSiteNumber == null ? "" : " Fed:[" + hydrometricSiteModelRet.FedSiteNumber + "]") +
(hydrometricSiteModelRet.QuebecSiteNumber == null ? "" : " QC:[" + hydrometricSiteModelRet.QuebecSiteNumber + "]"), retStr);
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_GetProvinceTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    List<string> ProvTxtList = new List<string>()
                    {
                        "AB", "BC", "MB", "NB", "NL", "NS", "NT", "NU", "ON", "PE", "QC", "SK", "YT", "othertest", "", "lsiefj",
                    };

                    foreach (string s in ProvTxtList)
                    {
                        string retStr = hydrometricSiteService.GetProvinceTVText(s);

                        if (culture.TwoLetterISOLanguageName == "fr")
                        {
                            switch (s)
                            {
                                case "AB":
                                    {
                                        Assert.AreEqual("Alberta", retStr);
                                    }
                                    break;
                                case "BC":
                                    {
                                        Assert.AreEqual("Colombie-Britannique", retStr);
                                    }
                                    break;
                                case "MB":
                                    {
                                        Assert.AreEqual("Manitoba", retStr);
                                    }
                                    break;
                                case "NB":
                                    {
                                        Assert.AreEqual("Nouveau-Brunswick", retStr);
                                    }
                                    break;
                                case "NL":
                                    {
                                        Assert.AreEqual("Terre-Neuve et Labrador", retStr);
                                    }
                                    break;
                                case "NS":
                                    {
                                        Assert.AreEqual("Nouvelle-Écosse", retStr);
                                    }
                                    break;
                                case "NT":
                                    {
                                        Assert.AreEqual("Territoires du Nord-Ouest", retStr);
                                    }
                                    break;
                                case "NU":
                                    {
                                        Assert.AreEqual("Nunavut", retStr);
                                    }
                                    break;
                                case "ON":
                                    {
                                        Assert.AreEqual("Ontario", retStr);
                                    }
                                    break;
                                case "PE":
                                    {
                                        Assert.AreEqual("Ile-du-Prince-Edouard", retStr);
                                    }
                                    break;
                                case "QC":
                                    {
                                        Assert.AreEqual("Québec", retStr);
                                    }
                                    break;
                                case "SK":
                                    {
                                        Assert.AreEqual("Saskatchewan", retStr);
                                    }
                                    break;
                                case "YT":
                                    {
                                        Assert.AreEqual("Territoire du Yukon", retStr);
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
                                case "AB":
                                    {
                                        Assert.AreEqual("Alberta", retStr);
                                    }
                                    break;
                                case "BC":
                                    {
                                        Assert.AreEqual("British Columbia", retStr);
                                    }
                                    break;
                                case "MB":
                                    {
                                        Assert.AreEqual("Manitoba", retStr);
                                    }
                                    break;
                                case "NB":
                                    {
                                        Assert.AreEqual("New Brunswick", retStr);
                                    }
                                    break;
                                case "NL":
                                    {
                                        Assert.AreEqual("Newfounland and Labrador", retStr);
                                    }
                                    break;
                                case "NS":
                                    {
                                        Assert.AreEqual("Nova Scotia", retStr);
                                    }
                                    break;
                                case "NT":
                                    {
                                        Assert.AreEqual("Northwest Territories", retStr);
                                    }
                                    break;
                                case "NU":
                                    {
                                        Assert.AreEqual("Nunavut", retStr);
                                    }
                                    break;
                                case "ON":
                                    {
                                        Assert.AreEqual("Ontario", retStr);
                                    }
                                    break;
                                case "PE":
                                    {
                                        Assert.AreEqual("Prince Edward Island", retStr);
                                    }
                                    break;
                                case "QC":
                                    {
                                        Assert.AreEqual("Quebec", retStr);
                                    }
                                    break;
                                case "SK":
                                    {
                                        Assert.AreEqual("Saskatchewan", retStr);
                                    }
                                    break;
                                case "YT":
                                    {
                                        Assert.AreEqual("Yukon Territory", retStr);
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
        public void HydrometricSiteService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    HydrometricSiteModel hydrometricSiteModelRet = hydrometricSiteService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, hydrometricSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostAddUpdateDeleteHydrometricSite_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    HydrometricSiteModel hydrometricSiteModelRet2 = UpdateHydrometricSiteModel(hydrometricSiteModelRet);

                    HydrometricSiteModel hydrometricSiteModelRet3 = hydrometricSiteService.PostDeleteHydrometricSiteDB(hydrometricSiteModelRet2.HydrometricSiteID);
                    Assert.AreEqual("", hydrometricSiteModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostAddHydrometricSiteDB_HydrometricSiteModelOK_Error_Test()
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
                        shimHydrometricSiteService.HydrometricSiteModelOKHydrometricSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostAddHydrometricSiteDB_IsContactOK_Error_Test()
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
                        shimHydrometricSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostAddHydrometricSiteDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModel = AddHydrometricSiteModel();
                    Assert.AreEqual("", hydrometricSiteModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        HydrometricSiteModel hydrometricSiteModelRet = hydrometricSiteService.PostAddHydrometricSiteDB(hydrometricSiteModel);
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostAddHydrometricSiteDB_FillHydrometricSite_Error_Test()
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
                        shimHydrometricSiteService.FillHydrometricSiteHydrometricSiteHydrometricSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostAddHydrometricSiteDB_DoAddChanges_Error_Test()
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
                        shimHydrometricSiteService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostAddHydrometricSiteDB_Add_Error_Test()
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
                        shimHydrometricSiteService.FillHydrometricSiteHydrometricSiteHydrometricSiteModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();
                        Assert.IsTrue(hydrometricSiteModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostAddHydrometricSiteDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();
                    Assert.IsNotNull(hydrometricSiteModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, hydrometricSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostAddHydrometricSiteDB_UserHydrometricSiteNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();
                    Assert.IsNotNull(hydrometricSiteModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, hydrometricSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostDeleteHydrometricSite_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimHydrometricSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostDeleteHydrometricSiteDB(hydrometricSiteModelRet.HydrometricSiteID);
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostDeleteHydrometricSite_GetHydrometricSiteWithHydrometricSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimHydrometricSiteService.GetHydrometricSiteWithHydrometricSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostDeleteHydrometricSiteDB(hydrometricSiteModelRet.HydrometricSiteID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.HydrometricSite), hydrometricSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostDeleteHydrometricSite_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimHydrometricSiteService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostDeleteHydrometricSiteDB(hydrometricSiteModelRet.HydrometricSiteID);
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostDeleteHydrometricSite_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostDeleteHydrometricSiteDB(hydrometricSiteModelRet.HydrometricSiteID);
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostUpdateHydrometricSite_HydrometricSiteModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    FillHydrometricSiteModelUpdate(hydrometricSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimHydrometricSiteService.HydrometricSiteModelOKHydrometricSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostUpdateHydrometricSiteDB(hydrometricSiteModelRet);
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostUpdateHydrometricSite_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    FillHydrometricSiteModelUpdate(hydrometricSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimHydrometricSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostUpdateHydrometricSiteDB(hydrometricSiteModelRet);
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostUpdateHydrometricSite_GetHydrometricSiteWithHydrometricSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    FillHydrometricSiteModelUpdate(hydrometricSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimHydrometricSiteService.GetHydrometricSiteWithHydrometricSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostUpdateHydrometricSiteDB(hydrometricSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.HydrometricSite), hydrometricSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostUpdateHydrometricSite_FillHydrometricSite_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    FillHydrometricSiteModelUpdate(hydrometricSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimHydrometricSiteService.FillHydrometricSiteHydrometricSiteHydrometricSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostUpdateHydrometricSiteDB(hydrometricSiteModelRet);
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostUpdateHydrometricSite_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    FillHydrometricSiteModelUpdate(hydrometricSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimHydrometricSiteService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostUpdateHydrometricSiteDB(hydrometricSiteModelRet);
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostUpdateHydrometricSite_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    FillHydrometricSiteModelUpdate(hydrometricSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostUpdateHydrometricSiteDB(hydrometricSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, "TVItemLanguage", ServiceRes.TVItemID + "," + ServiceRes.Language, hydrometricSiteModelRet.HydrometricSiteTVItemID.ToString() + "," + culture.TwoLetterISOLanguageName), hydrometricSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostUpdateHydrometricSite_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    FillHydrometricSiteModelUpdate(hydrometricSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimHydrometricSiteService.CreateTVTextHydrometricSiteModel = (a) =>
                        {
                            return "";
                        };

                        HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostUpdateHydrometricSiteDB(hydrometricSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, "TVText"), hydrometricSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricSiteService_PostUpdateHydrometricSite_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = AddHydrometricSiteModel();

                    FillHydrometricSiteModelUpdate(hydrometricSiteModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostUpdateHydrometricSiteDB(hydrometricSiteModelRet);
                        Assert.AreEqual(ErrorText, hydrometricSiteModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Function
        public HydrometricSiteModel AddHydrometricSiteModel()
        {
            TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Province);

            string TVText = randomService.RandomString("Hydrometric Site ", 30);
            TVItemModel tvItemModelHydrometricSite = hydrometricSiteService._TVItemService.PostAddChildTVItemDB(tvItemModelParent.TVItemID, TVText, TVTypeEnum.HydrometricSite);
            if (!string.IsNullOrWhiteSpace(tvItemModelHydrometricSite.Error))
            {
                return new HydrometricSiteModel() { Error = tvItemModelHydrometricSite.Error };
            }

            hydrometricSiteModelNew.HydrometricSiteTVItemID = tvItemModelHydrometricSite.TVItemID;
            FillHydrometricSiteModelNew(hydrometricSiteModelNew);

            HydrometricSiteModel hydrometricSiteModelRet = hydrometricSiteService.PostAddHydrometricSiteDB(hydrometricSiteModelNew);
            if (!string.IsNullOrWhiteSpace(hydrometricSiteModelRet.Error))
            {
                return hydrometricSiteModelRet;
            }

            CompareHydrometricSiteModels(hydrometricSiteModelNew, hydrometricSiteModelRet);

            return hydrometricSiteModelRet;

        }
        public HydrometricSiteModel UpdateHydrometricSiteModel(HydrometricSiteModel hydrometricSiteModel)
        {
            FillHydrometricSiteModelUpdate(hydrometricSiteModel);

            HydrometricSiteModel hydrometricSiteModelRet2 = hydrometricSiteService.PostUpdateHydrometricSiteDB(hydrometricSiteModel);
            if (!string.IsNullOrWhiteSpace(hydrometricSiteModelRet2.Error))
            {
                return hydrometricSiteModelRet2;
            }

            CompareHydrometricSiteModels(hydrometricSiteModel, hydrometricSiteModelRet2);

            return hydrometricSiteModelRet2;
        }
        public void CompareHydrometricSiteModels(HydrometricSiteModel hydrometricSiteModelRet, HydrometricSiteModel hydrometricSiteModel)
        {
            Assert.AreEqual(hydrometricSiteModelRet.FedSiteNumber, hydrometricSiteModel.FedSiteNumber);
            Assert.AreEqual(hydrometricSiteModelRet.QuebecSiteNumber, hydrometricSiteModel.QuebecSiteNumber);
            Assert.AreEqual(hydrometricSiteModelRet.HydrometricSiteName, hydrometricSiteModel.HydrometricSiteName);
            Assert.AreEqual(hydrometricSiteModelRet.Description, hydrometricSiteModel.Description);
            Assert.AreEqual(hydrometricSiteModelRet.Province, hydrometricSiteModel.Province);
            Assert.AreEqual(hydrometricSiteModelRet.Elevation_m, hydrometricSiteModel.Elevation_m);
            Assert.AreEqual(hydrometricSiteModelRet.StartDate_Local, hydrometricSiteModel.StartDate_Local);
            Assert.AreEqual(hydrometricSiteModelRet.EndDate_Local, hydrometricSiteModel.EndDate_Local);
            Assert.AreEqual(hydrometricSiteModelRet.TimeOffset_hour, hydrometricSiteModel.TimeOffset_hour);
            Assert.AreEqual(hydrometricSiteModelRet.DrainageArea_km2, hydrometricSiteModel.DrainageArea_km2);
            Assert.AreEqual(hydrometricSiteModelRet.IsNatural, hydrometricSiteModel.IsNatural);
            Assert.AreEqual(hydrometricSiteModelRet.IsActive, hydrometricSiteModel.IsActive);
            Assert.AreEqual(hydrometricSiteModelRet.Sediment, hydrometricSiteModel.Sediment);
            Assert.AreEqual(hydrometricSiteModelRet.RHBN, hydrometricSiteModel.RHBN);
            Assert.AreEqual(hydrometricSiteModelRet.RealTime, hydrometricSiteModel.RealTime);
            Assert.AreEqual(hydrometricSiteModelRet.HasRatingCurve, hydrometricSiteModel.HasRatingCurve);
        }
        public void FillHydrometricSiteModelNew(HydrometricSiteModel hydrometricSiteModel)
        {
            hydrometricSiteModel.HydrometricSiteTVItemID = hydrometricSiteModel.HydrometricSiteTVItemID;
            hydrometricSiteModel.FedSiteNumber = randomService.RandomString("01BL", 7);
            hydrometricSiteModel.HydrometricSiteName = randomService.RandomString("Hydro site ", 20);
            hydrometricSiteModel.QuebecSiteNumber = randomService.RandomString("01", 7);
            hydrometricSiteModel.Description = randomService.RandomString("", 100);
            hydrometricSiteModel.Province = randomService.RandomString("NB", 2);
            hydrometricSiteModel.Elevation_m = randomService.RandomInt(0, 10000);
            hydrometricSiteModel.StartDate_Local = randomService.RandomDateTime();
            hydrometricSiteModel.EndDate_Local = hydrometricSiteModel.StartDate_Local.Value.AddHours(1);
            hydrometricSiteModel.TimeOffset_hour = randomService.RandomInt(-8, -3);
            hydrometricSiteModel.DrainageArea_km2 = randomService.RandomInt(1, 1000000);
            hydrometricSiteModel.IsNatural = true;
            hydrometricSiteModel.IsActive = true;
            hydrometricSiteModel.Sediment = true;
            hydrometricSiteModel.RHBN = true;
            hydrometricSiteModel.RealTime = true;
            hydrometricSiteModel.HasRatingCurve = true;

            Assert.IsTrue(hydrometricSiteModel.HydrometricSiteTVItemID > 0);
            Assert.IsTrue(hydrometricSiteModel.FedSiteNumber.Length == 7);
            Assert.IsTrue(hydrometricSiteModel.HydrometricSiteName.Length == 20);
            Assert.IsTrue(hydrometricSiteModel.QuebecSiteNumber.Length == 7);
            Assert.IsTrue(hydrometricSiteModel.Description.Length == 100);
            Assert.IsTrue(hydrometricSiteModel.Province == "NB");
            Assert.IsTrue(hydrometricSiteModel.Elevation_m >= 0 && hydrometricSiteModel.Elevation_m <= 10000);
            Assert.IsTrue(hydrometricSiteModel.StartDate_Local != null);
            Assert.IsTrue(hydrometricSiteModel.EndDate_Local != null);
            Assert.IsTrue(hydrometricSiteModel.TimeOffset_hour >= -8 && hydrometricSiteModel.TimeOffset_hour <= -3);
            Assert.IsTrue(hydrometricSiteModel.DrainageArea_km2 >= 1 && hydrometricSiteModel.DrainageArea_km2 <= 1000000);
            Assert.IsTrue(hydrometricSiteModel.IsNatural == true);
            Assert.IsTrue(hydrometricSiteModel.IsActive == true);
            Assert.IsTrue(hydrometricSiteModel.Sediment == true);
            Assert.IsTrue(hydrometricSiteModel.RHBN == true);
            Assert.IsTrue(hydrometricSiteModel.RealTime == true);
            Assert.IsTrue(hydrometricSiteModel.HasRatingCurve == true);

        }
        public void FillHydrometricSiteModelUpdate(HydrometricSiteModel hydrometricSiteModel)
        {
            hydrometricSiteModel.FedSiteNumber = randomService.RandomString("21BL", 7);
            hydrometricSiteModel.HydrometricSiteName = randomService.RandomString("Hydro2 site ", 20);
            hydrometricSiteModel.QuebecSiteNumber = randomService.RandomString("02", 7);
            hydrometricSiteModel.Description = randomService.RandomString("222", 100);
            hydrometricSiteModel.Province = randomService.RandomString("NB", 2);
            hydrometricSiteModel.Elevation_m = randomService.RandomInt(5, 1000);
            hydrometricSiteModel.StartDate_Local = randomService.RandomDateTime();
            hydrometricSiteModel.EndDate_Local = hydrometricSiteModel.StartDate_Local.Value.AddHours(1);
            hydrometricSiteModel.TimeOffset_hour = randomService.RandomInt(-8, -4);
            hydrometricSiteModel.DrainageArea_km2 = randomService.RandomInt(100, 10000);
            hydrometricSiteModel.IsNatural = false;
            hydrometricSiteModel.IsActive = false;
            hydrometricSiteModel.Sediment = false;
            hydrometricSiteModel.RHBN = false;
            hydrometricSiteModel.RealTime = false;
            hydrometricSiteModel.HasRatingCurve = false;

            Assert.IsTrue(hydrometricSiteModel.FedSiteNumber.Length == 7);
            Assert.IsTrue(hydrometricSiteModel.HydrometricSiteName.Length == 20);
            Assert.IsTrue(hydrometricSiteModel.QuebecSiteNumber.Length == 7);
            Assert.IsTrue(hydrometricSiteModel.Description.Length == 100);
            Assert.IsTrue(hydrometricSiteModel.Province == "NB");
            Assert.IsTrue(hydrometricSiteModel.Elevation_m >= 5 && hydrometricSiteModel.Elevation_m <= 1000);
            Assert.IsTrue(hydrometricSiteModel.StartDate_Local != null);
            Assert.IsTrue(hydrometricSiteModel.EndDate_Local != null);
            Assert.IsTrue(hydrometricSiteModel.TimeOffset_hour >= -8 && hydrometricSiteModel.TimeOffset_hour <= -4);
            Assert.IsTrue(hydrometricSiteModel.DrainageArea_km2 >= 100 && hydrometricSiteModel.DrainageArea_km2 <= 10000);
            Assert.IsTrue(hydrometricSiteModel.IsNatural == false);
            Assert.IsTrue(hydrometricSiteModel.IsActive == false);
            Assert.IsTrue(hydrometricSiteModel.Sediment == false);
            Assert.IsTrue(hydrometricSiteModel.RHBN == false);
            Assert.IsTrue(hydrometricSiteModel.RealTime == false);
            Assert.IsTrue(hydrometricSiteModel.HasRatingCurve == false);

        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            hydrometricSiteService = new HydrometricSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            hydrometricSiteModelNew = new HydrometricSiteModel();
            hydrometricSite = new HydrometricSite();
        }
        private void SetupShim()
        {
            shimHydrometricSiteService = new ShimHydrometricSiteService(hydrometricSiteService);
            shimTVItemService = new ShimTVItemService(hydrometricSiteService._TVItemService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(hydrometricSiteService._TVItemService._TVItemLanguageService);
        }
        #endregion Function
    }
}
