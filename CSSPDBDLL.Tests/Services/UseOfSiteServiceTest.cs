using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPWebToolsDBDLL.Tests.SetupInfo;
using CSSPWebToolsDBDLL.Models;
using System.Security.Principal;
using CSSPWebToolsDBDLL.Services;
using CSSPWebToolsDBDLL.Services.Resources;
using System.Linq;
using System.Transactions;
using CSSPWebToolsDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Threading;
using System.Globalization;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for UseOfSiteServiceTest
    /// </summary>
    [TestClass]
    public class UseOfSiteServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "UseOfSite";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private UseOfSiteService useOfSiteService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private UseOfSiteModel useOfSiteModelNew { get; set; }
        private UseOfSite useOfSite { get; set; }
        private ShimUseOfSiteService shimUseOfSiteService { get; set; }
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
        public UseOfSiteServiceTest()
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
        public void UseOfSiteService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(useOfSiteService);
                Assert.IsNotNull(useOfSiteService.db);
                Assert.IsNotNull(useOfSiteService.LanguageRequest);
                Assert.IsNotNull(useOfSiteService.User);
                Assert.AreEqual(user.Identity.Name, useOfSiteService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), useOfSiteService.LanguageRequest);
            }
        }
        [TestMethod]
        public void UseOfSiteService_UseOfSiteModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModel = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModel.Error);

                    #region Good
                    useOfSiteModelNew.SiteTVItemID = useOfSiteModel.SiteTVItemID;
                    useOfSiteModelNew.SubsectorTVItemID = useOfSiteModel.SubsectorTVItemID;
                    FillUseOfSiteModel(useOfSiteModelNew);

                    string retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region SiteTVItemID
                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.SiteTVItemID = 0;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.SiteTVItemID), retStr);

                    useOfSiteModelNew.SiteTVItemID = useOfSiteModel.SiteTVItemID;
                    useOfSiteModelNew.SubsectorTVItemID = useOfSiteModel.SubsectorTVItemID;
                    FillUseOfSiteModel(useOfSiteModelNew);

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull("", retStr);

                    #endregion SiteTVItemID

                    #region SubsectorTVItemID
                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.SubsectorTVItemID = 0;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID), retStr);

                    useOfSiteModelNew.SiteTVItemID = useOfSiteModel.SiteTVItemID;
                    useOfSiteModelNew.SubsectorTVItemID = useOfSiteModel.SubsectorTVItemID;
                    FillUseOfSiteModel(useOfSiteModelNew);

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull("", retStr);

                    #endregion SubsectorTVItemID

                    #region SiteType
                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.SiteType = (SiteTypeEnum)10000;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.SiteType), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.SiteType = SiteTypeEnum.Hydrometric;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull("", retStr);

                    #endregion SiteType

                    #region Ordinal
                    int MinInt = 0;
                    int MaxInt = 100;
                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Ordinal = MinInt - 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Ordinal, MinInt, MaxInt), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Ordinal = MaxInt + 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Ordinal, MinInt, MaxInt), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Ordinal = MaxInt - 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull("", retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Ordinal = MinInt;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull("", retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Ordinal = MaxInt;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Ordinal

                    #region StartDateTime_Local
                    FillUseOfSiteModel(useOfSiteModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                        Assert.IsNotNull(ErrorText, retStr);
                    }
                    #endregion StartDateTime_Local

                    #region EndDateTime_Local
                    FillUseOfSiteModel(useOfSiteModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                        Assert.IsNotNull(ErrorText, retStr);
                    }
                    #endregion EndDateTime_Local

                    #region StartYear > EndYear
                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.StartYear = randomService.RandomDateTime().Year;
                    useOfSiteModelNew.EndYear = useOfSiteModelNew.StartYear -1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDate_Local, ServiceRes.EndDate_Local), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.StartYear = randomService.RandomDateTime().Year;
                    useOfSiteModelNew.EndYear = useOfSiteModelNew.StartYear + 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion StartYear > EndDateTime_Local

                    #region UseWeight
                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.UseWeight = true;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);
                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.UseWeight = false;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion UseWeight

                    #region Weight_perc
                    FillUseOfSiteModel(useOfSiteModelNew);
                    double Min = 0D;
                    double Max = 100D;
                    useOfSiteModelNew.Weight_perc = Min - 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Weight_perc, Min, Max), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Weight_perc = Max + 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Weight_perc, Min, Max), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Weight_perc = Max - 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Weight_perc = Min;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Weight_perc = Max;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Weight_perc

                    #region UseEquation
                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.UseEquation = true;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);
                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.UseEquation = false;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion UseEquation

                    #region Param1
                    FillUseOfSiteModel(useOfSiteModelNew);
                    Min = 0D;
                    Max = 100D;
                    useOfSiteModelNew.Param1 = Min - 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Param1, Min, Max), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param1 = Max + 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Param1, Min, Max), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param1 = Max - 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param1 = Min;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param1 = Max;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Param1

                    #region Param2
                    FillUseOfSiteModel(useOfSiteModelNew);
                    Min = 0D;
                    Max = 100D;
                    useOfSiteModelNew.Param2 = Min - 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Param2, Min, Max), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param2 = Max + 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Param2, Min, Max), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param2 = Max - 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param2 = Min;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param2 = Max;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Param2

                    #region Param3
                    FillUseOfSiteModel(useOfSiteModelNew);
                    Min = 0D;
                    Max = 100D;
                    useOfSiteModelNew.Param3 = Min - 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Param3, Min, Max), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param3 = Max + 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Param3, Min, Max), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param3 = Max - 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param3 = Min;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param3 = Max;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Param3

                    #region Param4
                    FillUseOfSiteModel(useOfSiteModelNew);
                    Min = 0D;
                    Max = 100D;
                    useOfSiteModelNew.Param4 = Min - 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Param4, Min, Max), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param4 = Max + 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Param4, Min, Max), retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param4 = Max - 1;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param4 = Min;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillUseOfSiteModel(useOfSiteModelNew);
                    useOfSiteModelNew.Param4 = Max;

                    retStr = useOfSiteService.UseOfSiteModelOK(useOfSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Param4
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_FillUseOfSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    useOfSiteModelNew.SiteTVItemID = randomService.RandomTVItem(TVTypeEnum.TideSite).TVItemID;
                    useOfSiteModelNew.SubsectorTVItemID = randomService.RandomTVItem(TVTypeEnum.Subsector).TVItemID;
                    FillUseOfSiteModel(useOfSiteModelNew);

                    ContactOK contactOK = useOfSiteService.IsContactOK();

                    string retStr = useOfSiteService.FillUseOfSite(useOfSite, useOfSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, useOfSite.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = useOfSiteService.FillUseOfSite(useOfSite, useOfSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, useOfSite.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_SiteTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                SiteTypeEnum siteType = (SiteTypeEnum)10000;

                string retStr = useOfSiteService._BaseEnumService.SiteTypeOK(siteType);

                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SiteType), retStr);

                siteType = SiteTypeEnum.Hydrometric;

                retStr = useOfSiteService._BaseEnumService.SiteTypeOK(siteType);

                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void UseOfSiteService_GetUseOfSiteModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();

                    int useOfSiteCount = useOfSiteService.GetUseOfSiteModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, useOfSiteCount);
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_GetUseOfSiteModelWithUseOfSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();

                    UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.GetUseOfSiteModelWithUseOfSiteIDDB(useOfSiteModelRet.UseOfSiteID);
                    Assert.AreEqual(useOfSiteModelRet.UseOfSiteID, useOfSiteModelRet2.UseOfSiteID);

                    int UseOfSiteID = 0;
                    useOfSiteModelRet2 = useOfSiteService.GetUseOfSiteModelWithUseOfSiteIDDB(UseOfSiteID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.UseOfSite, ServiceRes.UseOfSiteID, UseOfSiteID), useOfSiteModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_GetUseOfSiteListModelWithSiteTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();

                    List<UseOfSiteModel> useOfSiteModelList = useOfSiteService.GetUseOfSiteModelListWithSiteTVItemIDDB(useOfSiteModelRet.SiteTVItemID);
                    Assert.IsTrue(useOfSiteModelList.Where(c => c.UseOfSiteID == useOfSiteModelRet.UseOfSiteID).Any());
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_GetUseOfSiteModelListWithSiteTypeAndSubsectorTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();

                    List<UseOfSiteModel> useOfSiteModelList = useOfSiteService.GetUseOfSiteModelListWithSiteTypeAndSubsectorTVItemIDDB(useOfSiteModelRet.SiteType, useOfSiteModelRet.SubsectorTVItemID);
                    Assert.IsTrue(useOfSiteModelList.Where(c => c.UseOfSiteID == useOfSiteModelRet.UseOfSiteID).Any());
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_GetUseOfSiteModelWithSiteTVItemIDAndSubsectorTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();

                    UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.GetUseOfSiteModelWithSiteTVItemIDAndSubsectorTVItemIDDB(useOfSiteModelRet.SiteTVItemID, useOfSiteModelRet.SubsectorTVItemID);
                    Assert.AreEqual("", useOfSiteModelRet2.Error);

                    int SiteTVItemID = 0;
                    useOfSiteModelRet2 = useOfSiteService.GetUseOfSiteModelWithSiteTVItemIDAndSubsectorTVItemIDDB(SiteTVItemID, useOfSiteModelRet.SubsectorTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.UseOfSite, ServiceRes.SiteTVItemID + "," + ServiceRes.SubsectorTVItemID, SiteTVItemID.ToString() + "," + useOfSiteModelRet.SubsectorTVItemID.ToString()), useOfSiteModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_GetUseOfSiteModelListWithSubsectorTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();

                    List<UseOfSiteModel> useOfSiteModelList = useOfSiteService.GetUseOfSiteModelListWithSubsectorTVItemIDDB(useOfSiteModelRet.SubsectorTVItemID);
                    Assert.IsTrue(useOfSiteModelList.Count > 0);

                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_GetUseOfSiteModelExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    UseOfSiteModel useOfSiteModel = useOfSiteService.GetUseOfSiteModelExist(useOfSiteModelRet);
                    Assert.AreEqual("", useOfSiteModel.Error);

                    useOfSiteModelRet.SubsectorTVItemID = 0;
                    UseOfSiteModel useOfSiteModel2 = useOfSiteService.GetUseOfSiteModelExist(useOfSiteModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.UseOfSite,
                    ServiceRes.SubsectorTVItemID + "," +
                    ServiceRes.SiteType + "," +
                    ServiceRes.SiteTVItemID + "," +
                    ServiceRes.StartYear + "," +
                    ServiceRes.EndYear,
                    useOfSiteModelRet.SubsectorTVItemID.ToString() + "," +
                    useOfSiteModelRet.SiteType.ToString() + "," +
                    useOfSiteModelRet.SiteTVItemID.ToString() + "," +
                    useOfSiteModelRet.StartYear + "," +
                    useOfSiteModelRet.EndYear), useOfSiteModel2.Error);

                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_GetUseOfSiteWithUseOfSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();

                    UseOfSite useOfSite = useOfSiteService.GetUseOfSiteWithUseOfSiteIDDB(useOfSiteModelRet.UseOfSiteID);
                    Assert.AreEqual(useOfSiteModelRet.UseOfSiteID, useOfSite.UseOfSiteID);
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostAddUpdateDeleteUseOfSiteAndUseOfSiteLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostUpdateUseOfSiteDB(useOfSiteModelRet);
                    Assert.AreEqual("", useOfSiteModelRet2.Error);

                    UseOfSiteModel useOfSiteModelRet3 = useOfSiteService.PostDeleteUseOfSiteDB(useOfSiteModelRet2.UseOfSiteID);
                    Assert.AreEqual("", useOfSiteModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostAddUseOfSiteDB_UseOfSiteModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.UseOfSiteModelOKUseOfSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        useOfSiteModelRet.EndYear = 2050;

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostAddUseOfSiteDB(useOfSiteModelRet);
                        Assert.AreEqual(ErrorText, useOfSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostAddUseOfSiteDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        useOfSiteModelRet.EndYear = 2050;

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostAddUseOfSiteDB(useOfSiteModelRet);
                        Assert.AreEqual(ErrorText, useOfSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostAddUseOfSiteDB_GetUseOfSiteModelExist_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.GetUseOfSiteModelExistUseOfSiteModel = (a) =>
                        {
                            return new UseOfSiteModel() { Error = "" };
                        };

                        useOfSiteModelRet.EndYear = 2050;

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostAddUseOfSiteDB(useOfSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.UseOfSite), useOfSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostAddUseOfSiteDB_FillUseOfSite_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.FillUseOfSiteUseOfSiteUseOfSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        useOfSiteModelRet.EndYear = 2050;

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostAddUseOfSiteDB(useOfSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.UseOfSite), useOfSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostAddUseOfSiteDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        useOfSiteModelRet.EndYear = 2050;

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostAddUseOfSiteDB(useOfSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.UseOfSite), useOfSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostDeleteUseOfSiteDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostDeleteUseOfSiteDB(useOfSiteModelRet.UseOfSiteID);
                        Assert.AreEqual(ErrorText, useOfSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostDeleteUseOfSiteDB_GetUseOfSiteWithUseOfSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.GetUseOfSiteWithUseOfSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostDeleteUseOfSiteDB(useOfSiteModelRet.UseOfSiteID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.UseOfSite), useOfSiteModelRet2.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostDeleteUseOfSiteDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostDeleteUseOfSiteDB(useOfSiteModelRet.UseOfSiteID);
                        Assert.AreEqual(ErrorText, useOfSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostUpdateUseOfSiteDB_UseOfSiteModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.UseOfSiteModelOKUseOfSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostUpdateUseOfSiteDB(useOfSiteModelRet);
                        Assert.AreEqual(ErrorText, useOfSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostUpdateUseOfSiteDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostUpdateUseOfSiteDB(useOfSiteModelRet);
                        Assert.AreEqual(ErrorText, useOfSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostUpdateUseOfSiteDB_GetUseOfSiteWithUseOfSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.GetUseOfSiteWithUseOfSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostUpdateUseOfSiteDB(useOfSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.UseOfSite), useOfSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostUpdateUseOfSiteDB_FillUseOfSite_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.FillUseOfSiteUseOfSiteUseOfSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostUpdateUseOfSiteDB(useOfSiteModelRet);
                        Assert.AreEqual(ErrorText, useOfSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostUpdateUseOfSiteDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimUseOfSiteService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostUpdateUseOfSiteDB(useOfSiteModelRet);
                        Assert.AreEqual(ErrorText, useOfSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostAddUseOfSiteDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    SetupTest(contactModelListBad[0], culture);

                    useOfSiteModelRet.EndYear = 2050;

                    UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostAddUseOfSiteDB(useOfSiteModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, useOfSiteModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void UseOfSiteService_PostAddUseOfSiteDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    UseOfSiteModel useOfSiteModelRet = AddUseOfSiteModel();
                    Assert.AreEqual("", useOfSiteModelRet.Error);

                    SetupTest(contactModelListGood[2], culture);

                    useOfSiteModelRet.EndYear = 2050;

                    UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostAddUseOfSiteDB(useOfSiteModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, useOfSiteModelRet2.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public UseOfSiteModel AddUseOfSiteModel()
        {
            TVItemModel tvItemModelTideSite = randomService.RandomTVItem(TVTypeEnum.TideSite);

            Assert.AreEqual("", tvItemModelTideSite.Error);

            TVItemModel tvItemModelSubsector = randomService.RandomTVItem(TVTypeEnum.TideSite);

            Assert.AreEqual("", tvItemModelSubsector.Error);

            useOfSiteModelNew.SiteTVItemID = tvItemModelTideSite.TVItemID;
            useOfSiteModelNew.SubsectorTVItemID = tvItemModelSubsector.TVItemID;
            FillUseOfSiteModel(useOfSiteModelNew);

            UseOfSiteModel useOfSiteModelRet = useOfSiteService.PostAddUseOfSiteDB(useOfSiteModelNew);
            if (!string.IsNullOrWhiteSpace(useOfSiteModelRet.Error))
            {
                return useOfSiteModelRet;
            }

            CompareUseOfSiteModels(useOfSiteModelNew, useOfSiteModelRet);

            return useOfSiteModelRet;
        }
        public UseOfSiteModel UpdateUseOfSiteModel(UseOfSiteModel useOfSiteModel)
        {
            FillUseOfSiteModel(useOfSiteModel);

            UseOfSiteModel useOfSiteModelRet2 = useOfSiteService.PostUpdateUseOfSiteDB(useOfSiteModel);
            if (!string.IsNullOrWhiteSpace(useOfSiteModelRet2.Error))
            {
                return useOfSiteModelRet2;
            }

            CompareUseOfSiteModels(useOfSiteModel, useOfSiteModelRet2);

            return useOfSiteModelRet2;
        }
        private void CompareUseOfSiteModels(UseOfSiteModel useOfSiteModelNew, UseOfSiteModel useOfSiteModelRet)
        {
            Assert.AreEqual(useOfSiteModelNew.SiteTVItemID, useOfSiteModelRet.SiteTVItemID);
            Assert.AreEqual(useOfSiteModelNew.SubsectorTVItemID, useOfSiteModelRet.SubsectorTVItemID);
            Assert.AreEqual(useOfSiteModelNew.SiteType, useOfSiteModelRet.SiteType);
            Assert.AreEqual(useOfSiteModelNew.Ordinal, useOfSiteModelRet.Ordinal);
            Assert.AreEqual(useOfSiteModelNew.StartYear, useOfSiteModelRet.StartYear);
            Assert.AreEqual(useOfSiteModelNew.EndYear, useOfSiteModelRet.EndYear);
            Assert.AreEqual(useOfSiteModelNew.UseWeight, useOfSiteModelRet.UseWeight);
            Assert.AreEqual(useOfSiteModelNew.Weight_perc, useOfSiteModelRet.Weight_perc);
            Assert.AreEqual(useOfSiteModelNew.UseEquation, useOfSiteModelRet.UseEquation);
            Assert.AreEqual(useOfSiteModelNew.Param1, useOfSiteModelRet.Param1);
            Assert.AreEqual(useOfSiteModelNew.Param2, useOfSiteModelRet.Param2);
            Assert.AreEqual(useOfSiteModelNew.Param3, useOfSiteModelRet.Param3);
            Assert.AreEqual(useOfSiteModelNew.Param4, useOfSiteModelRet.Param4);
        }
        private void FillUseOfSiteModel(UseOfSiteModel useOfSiteModel)
        {
            useOfSiteModel.SiteTVItemID = useOfSiteModel.SiteTVItemID;
            useOfSiteModel.SubsectorTVItemID = randomService.RandomTVItem(TVTypeEnum.Subsector).TVItemID;
            useOfSiteModel.SiteType = SiteTypeEnum.Climate;
            useOfSiteModel.Ordinal = 1;
            useOfSiteModel.StartYear = randomService.RandomDateTime().Year;
            useOfSiteModel.EndYear = useOfSiteModel.StartYear + 1;
            useOfSiteModel.UseWeight = true;
            useOfSiteModel.Weight_perc = randomService.RandomDouble(0, 100);
            useOfSiteModel.UseEquation = true;
            useOfSiteModel.Param1 = randomService.RandomDouble(0, 100);
            useOfSiteModel.Param2 = randomService.RandomDouble(0, 100);
            useOfSiteModel.Param3 = randomService.RandomDouble(0, 100);
            useOfSiteModel.Param4 = randomService.RandomDouble(0, 100);

            Assert.IsTrue(useOfSiteModel.SiteTVItemID != 0);
            Assert.IsTrue(useOfSiteModel.SubsectorTVItemID != 0);
            Assert.IsTrue(useOfSiteModel.SiteType == SiteTypeEnum.Climate);
            Assert.IsTrue(useOfSiteModel.Ordinal == 1);
            Assert.IsTrue(useOfSiteModel.StartYear > 0);
            Assert.IsTrue(useOfSiteModel.EndYear > 0);
            Assert.IsTrue(useOfSiteModel.UseWeight == true);
            Assert.IsTrue(useOfSiteModel.Weight_perc >= 0 && useOfSiteModel.Weight_perc <= 100);
            Assert.IsTrue(useOfSiteModel.UseEquation == true);
            Assert.IsTrue(useOfSiteModel.Param1 >= 0 && useOfSiteModel.Param1 <= 100);
            Assert.IsTrue(useOfSiteModel.Param2 >= 0 && useOfSiteModel.Param2 <= 100);
            Assert.IsTrue(useOfSiteModel.Param3 >= 0 && useOfSiteModel.Param3 <= 100);
            Assert.IsTrue(useOfSiteModel.Param4 >= 0 && useOfSiteModel.Param4 <= 100);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            useOfSiteService = new UseOfSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            useOfSiteModelNew = new UseOfSiteModel();
            useOfSite = new UseOfSite();
        }
        private void SetupShim()
        {
            shimUseOfSiteService = new ShimUseOfSiteService(useOfSiteService);
        }
        #endregion Functions private
    }
}

