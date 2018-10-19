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
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for PolSourceSiteServiceTest
    /// </summary>
    [TestClass]
    public class PolSourceSiteServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "PolSourceSite";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private PolSourceSiteService polSourceSiteService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private PolSourceSiteModel polSourceSiteModelNew { get; set; }
        private PolSourceSite polSourceSite { get; set; }
        private ShimPolSourceSiteService shimPolSourceSiteService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
        private TVItemService tvItemService { get; set; }
        private ShimMapInfoService shimMapInfoService { get; set; }
        private ShimMapInfoPointService shimMapInfoPointService { get; set; }
        private ShimPolSourceObservationService shimPolSourceObservationService { get; set; }
        private ShimPolSourceObservationIssueService shimPolSourceObservationIssueService { get; set; }
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
        public PolSourceSiteServiceTest()
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
        public void PolSourceSiteService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(polSourceSiteService);
                Assert.IsNotNull(polSourceSiteService.db);
                Assert.IsNotNull(polSourceSiteService.LanguageRequest);
                Assert.IsNotNull(polSourceSiteService.User);
                Assert.AreEqual(user.Identity.Name, polSourceSiteService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), polSourceSiteService.LanguageRequest);
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceSiteModel polSourceSiteModel = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModel.Error);

                    polSourceSiteModelNew.PolSourceSiteTVItemID = polSourceSiteModel.PolSourceSiteTVItemID;

                    #region Good
                    FillPolSourceSiteModel(polSourceSiteModelNew);

                    string retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region PolSourceSiteTVItemID
                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.PolSourceSiteTVItemID = 0;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteTVItemID), retStr);

                    polSourceSiteModelNew.PolSourceSiteTVItemID = randomService.RandomTVItem(TVTypeEnum.PolSourceSite).TVItemID;
                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.PolSourceSiteTVItemID = 1;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PolSourceSiteTVItemID

                    polSourceSiteModelNew.PolSourceSiteTVItemID = polSourceSiteModel.PolSourceSiteTVItemID;

                    #region PolSourceSiteTVText
                    int Min = 3;
                    int Max = 200;

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.PolSourceSiteTVText = randomService.RandomString("", Min - 1);

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.PolSourceSiteTVText, Min), retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.PolSourceSiteTVText = randomService.RandomString("", Max + 1);

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.PolSourceSiteTVText, Max), retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.PolSourceSiteTVText = randomService.RandomString("", Min);

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.PolSourceSiteTVText = randomService.RandomString("", Max);

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.PolSourceSiteTVText = randomService.RandomString("", Max - 1);

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PolSourceSiteTVText

                    #region Temp_Locator_CanDelete
                    Max = 50;

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Temp_Locator_CanDelete = "";

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Temp_Locator_CanDelete = randomService.RandomString("", Max + 1);

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Temp_Locator_CanDelete, Max), retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Temp_Locator_CanDelete = randomService.RandomString("", Max);

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Temp_Locator_CanDelete = randomService.RandomString("", Max - 1);

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Temp_Locator_CanDelete

                    #region Oldsiteid
                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Oldsiteid = null;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Oldsiteid = 0;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Oldsiteid), retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Oldsiteid = 1;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Oldsiteid

                    #region Site
                    int min = 0;
                    int max = 1000000;
                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Site = null;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Site = min - 1;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Site, min, max), retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Site = max + 1;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Site, min, max), retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Site = min;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Site = max;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.Site = max - 1;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Site

                    #region SiteID
                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.SiteID = null;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);

                    Assert.AreEqual("", retStr);
                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.SiteID = 0;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SiteID), retStr);

                    FillPolSourceSiteModel(polSourceSiteModelNew);
                    polSourceSiteModelNew.SiteID = 1;

                    retStr = polSourceSiteService.PolSourceSiteModelOK(polSourceSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SiteID

                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_FillPolSourceSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRet = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVItemModel tvItemModelPolSourceSite = polSourceSiteService._TVItemService.PostAddChildTVItemDB(tvItemModelRet.TVItemID, randomService.RandomString("Pol Source ", 20), TVTypeEnum.PolSourceSite);
                    Assert.AreEqual("", tvItemModelPolSourceSite.Error);

                    polSourceSiteModelNew.PolSourceSiteTVItemID = tvItemModelPolSourceSite.TVItemID;

                    FillPolSourceSiteModel(polSourceSiteModelNew);

                    ContactOK contactOK = polSourceSiteService.IsContactOK();

                    string retStr = polSourceSiteService.FillPolSourceSite(polSourceSite, polSourceSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, polSourceSite.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = polSourceSiteService.FillPolSourceSite(polSourceSite, polSourceSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, polSourceSite.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_GetPolSourceSiteModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    int polSourceSiteCount = polSourceSiteService.GetPolSourceSiteModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, polSourceSiteCount);

                    PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostDeletePolSourceSiteDB(polSourceSiteModelRet.PolSourceSiteID);
                    Assert.AreEqual("", polSourceSiteModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_GetPolSourceSiteModelWithPolSourceSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteIDDB(polSourceSiteModelRet.PolSourceSiteID);

                    ComparePolSourceSiteModels(polSourceSiteModelRet, polSourceSiteModelRet2);

                    int PolSourceSiteID = 0;
                    PolSourceSiteModel polSourceSiteModelRet3 = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteIDDB(PolSourceSiteID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceSite, ServiceRes.PolSourceSiteID, PolSourceSiteID), polSourceSiteModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(polSourceSiteModelRet.PolSourceSiteTVItemID);

                    ComparePolSourceSiteModels(polSourceSiteModelRet, polSourceSiteModelRet2);

                    int PolSourceSiteTVItemID = 0;
                    PolSourceSiteModel polSourceSiteModelRet3 = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(PolSourceSiteTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceSite, ServiceRes.PolSourceSiteTVItemID, PolSourceSiteTVItemID), polSourceSiteModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_GetPolSourceSiteWithPolSourceSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    PolSourceSite polSourceSiteRet = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteIDDB(polSourceSiteModelRet.PolSourceSiteID);
                    Assert.AreEqual(polSourceSiteModelRet.PolSourceSiteID, polSourceSiteRet.PolSourceSiteID);

                    int PolSourceSiteID = 0;
                    PolSourceSite polSourceSiteRet2 = polSourceSiteService.GetPolSourceSiteWithPolSourceSiteIDDB(PolSourceSiteID);
                    Assert.IsNull(polSourceSiteRet2);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    string retStr = polSourceSiteService.CreateTVText(polSourceSiteModelRet);
                    Assert.AreEqual(polSourceSiteModelRet.PolSourceSiteTVText, retStr);

                    polSourceSiteModelRet.PolSourceSiteTVText = "";
                    retStr = polSourceSiteService.CreateTVText(polSourceSiteModelRet);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_GetIsItSameObject_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    TVItemModel tvItemModelPolSourceSite = polSourceSiteService._TVItemService.GetTVItemModelWithTVItemIDDB(polSourceSiteModelRet.PolSourceSiteTVItemID);
                    Assert.AreEqual("", tvItemModelPolSourceSite.Error);

                    bool retBool = polSourceSiteService.GetIsItSameObject(polSourceSiteModelRet, tvItemModelPolSourceSite);
                    Assert.IsTrue(retBool);

                    polSourceSiteModelRet.PolSourceSiteTVItemID = 0;
                    retBool = polSourceSiteService.GetIsItSameObject(polSourceSiteModelRet, tvItemModelPolSourceSite);
                    Assert.IsFalse(retBool);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";

                    PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                    Assert.AreEqual("", polSourceSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_ParentTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";
                    fc["ParentTVItemID"] = "";

                    PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID), polSourceSiteModelRet.Error);

                    fc.Remove("ParentTVItemID");
                    fc["ParentTVItemID"] = "0";

                    polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID), polSourceSiteModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_PolSourceSiteTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "";

                    PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteTVItemID), polSourceSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_IsActive_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";
                    fc["IsActive"] = "";

                    PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InactiveReason), polSourceSiteModelRet.Error);

                    fc.Remove("IsActive");
                    fc["IsActive"] = true.ToString();

                    polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    fc.Remove("IsActive");
                    fc["IsActive"] = false.ToString();

                    polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                    Assert.AreEqual("", polSourceSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_IsActive_False_InactiveReason_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";
                    fc["IsActive"] = ""; // false

                    fc.Remove("InactiveReason"); 

                    PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InactiveReason), polSourceSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_IsPointSource_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";
                    fc["IsPointSource"] = ""; // false

                    PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                    Assert.AreEqual(false, polSourceSiteModelRet.IsPointSource);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_Lat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";
                    fc["Lat"] = "";

                    PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Lat), polSourceSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_Lng_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";
                    fc["Lng"] = "";

                    PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Lng), polSourceSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_PostAddPolSourceSiteDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceSiteService.PostAddPolSourceSiteDBPolSourceSiteModel = (a) =>
                        {
                            return new PolSourceSiteModel() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_PostAddPolSourceObservationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationService.PostAddPolSourceObservationDBPolSourceObservationModel = (a) =>
                        {
                            return new PolSourceObservationModel() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_PostAddPolSourceObservationIssueDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationIssueService.PostAddPolSourceObservationIssueDBPolSourceObservationIssueModel = (a) =>
                        {
                            return new PolSourceObservationIssueModel() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Modify_PostUpdatePolSourceSiteDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    //fc["PolSourceSiteTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceSiteService.PostUpdatePolSourceSiteDBPolSourceSiteModel = (a) =>
                        {
                            return new PolSourceSiteModel() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_CreateMapInfoObjectDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDBInt32TVTypeEnumMapInfoDrawTypeEnum = (a, b, c) =>
                        {
                            return new List<MapInfoPointModel>();
                        };
                        shimMapInfoService.CreateMapInfoObjectDBListOfCoordMapInfoDrawTypeEnumTVTypeEnumInt32 = (a, b, c, d) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Add_PostUpdateMapInfoPointDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceSiteTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDBInt32TVTypeEnumMapInfoDrawTypeEnum = (a, b, c) =>
                        {
                            return new List<MapInfoPointModel>() { new MapInfoPointModel() };
                        };
                        shimMapInfoPointService.PostUpdateMapInfoPointDBMapInfoPointModel = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Modify_PostAddPolSourceObservationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    //fc["PolSourceSiteTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDBInt32 = (a) =>
                        {
                            return new PolSourceSiteModel() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PolSourceSiteAddOrModifyDB_Modify_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);

                    PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PolSourceSiteAddOrModifyDB(fc);
                    Assert.AreEqual("", polSourceSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostAddUpdateDeletePolSourceSiteDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModelRet);
                    Assert.AreEqual("", polSourceSiteModelRet2.Error);

                    PolSourceSiteModel polSourceSiteModelRet3 = polSourceSiteService.PostDeletePolSourceSiteDB(polSourceSiteModelRet2.PolSourceSiteID);
                    Assert.AreEqual("", polSourceSiteModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostAddPolSourceSiteDB_PolSourceSiteModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceSiteService.PolSourceSiteModelOKPolSourceSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostAddPolSourceSiteDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostAddPolSourceSiteDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        polSourceSiteModelRet = polSourceSiteService.PostAddPolSourceSiteDB(polSourceSiteModelRet);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostAddPolSourceSiteDB_FillPolSourceSiteModel_ErrorTest()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceSiteService.FillPolSourceSitePolSourceSitePolSourceSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostAddPolSourceSiteDB_DoAddChanges_ErrorTest()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceSiteService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostAddPolSourceSiteDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimPolSourceSiteService.FillPolSourceSitePolSourceSitePolSourceSiteModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                        Assert.IsTrue(polSourceSiteModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostDeletePolSourceSiteDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostDeletePolSourceSiteDB(polSourceSiteModelRet.PolSourceSiteID);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostDeletePolSourceSiteDB_GetPolSourceSiteWithPolSourceSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimPolSourceSiteService.GetPolSourceSiteWithPolSourceSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostDeletePolSourceSiteDB(polSourceSiteModelRet.PolSourceSiteID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.PolSourceSite), polSourceSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostDeletePolSourceSiteDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceSiteService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostDeletePolSourceSiteDB(polSourceSiteModelRet.PolSourceSiteID);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostDeletePolSourceSiteDB_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostDeletePolSourceSiteDB(polSourceSiteModelRet.PolSourceSiteID);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostDeletePolSourceSiteWithPolSourceSiteTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostDeletePolSourceSiteWithPolSourceSiteTVItemIDDB(polSourceSiteModelRet.PolSourceSiteTVItemID);
                    Assert.AreEqual("", polSourceSiteModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostDeletePolSourceSiteWithPolSourceSiteTVItemIDDB_IsContactOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostDeletePolSourceSiteWithPolSourceSiteTVItemIDDB(polSourceSiteModelRet.PolSourceSiteTVItemID);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostDeletePolSourceSiteWithPolSourceSiteTVItemIDDB_GetPolSourceSiteWithPolSourceSiteWithPolSourceSiteTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimPolSourceSiteService.GetPolSourceSiteWithPolSourceSiteWithPolSourceSiteTVItemIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostDeletePolSourceSiteWithPolSourceSiteTVItemIDDB(polSourceSiteModelRet.PolSourceSiteTVItemID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.PolSourceSite), polSourceSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostDeletePolSourceSiteWithPolSourceSiteTVItemIDDB_PostDeletePolSourceSiteDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceSiteService.PostDeletePolSourceSiteDBInt32 = (a) =>
                        {
                            return new PolSourceSiteModel() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostDeletePolSourceSiteWithPolSourceSiteTVItemIDDB(polSourceSiteModelRet.PolSourceSiteTVItemID);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostUpdatePolSourceSiteDB_PolSourceSiteModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceSiteService.PolSourceSiteModelOKPolSourceSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModelRet);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostUpdatePolSourceSiteDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModelRet);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostUpdatePolSourceSiteDB_GetPolSourceSiteWithPolSourceSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimPolSourceSiteService.GetPolSourceSiteWithPolSourceSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.PolSourceSite), polSourceSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostUpdatePolSourceSiteDB_FillPolSourceSiteModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceSiteService.FillPolSourceSitePolSourceSitePolSourceSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModelRet);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostUpdatePolSourceSiteDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual("", polSourceSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceSiteService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModelRet);
                        Assert.AreEqual(ErrorText, polSourceSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostAddPolSourceSiteDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    SetupTest(contactModelListBad[0], culture);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, polSourceSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceSiteService_PostAddPolSourceSiteDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelParent);

                    SetupTest(contactModelListGood[2], culture);

                    PolSourceSiteModel polSourceSiteModelRet = AddPolSourceSiteModel();
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, polSourceSiteModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Function
        public FormCollection GetFormCollectionForPolSourceSiteSaveAllDB(string LanguageRequest)
        {
            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
            Assert.AreEqual("", tvItemModelRoot.Error);

            TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, "NB-01-010-001", TVTypeEnum.Subsector);
            Assert.AreEqual("", tvItemModelSubsector.Error);

            PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(202598);
            Assert.AreEqual("", polSourceSiteModel.Error);

            FormCollection fc = new FormCollection();
            fc.Add("ParentTVItemID", tvItemModelSubsector.TVItemID.ToString());
            fc.Add("PolSourceSiteTVItemID", polSourceSiteModel.PolSourceSiteTVItemID.ToString());
            fc.Add("IsActive", true.ToString());
            fc.Add("InactiveReason", PolSourceInactiveReasonEnum.Error.ToString());
            fc.Add("IsPointSource", true.ToString());
            string Lat = "45.45";
            fc.Add("Lat", (LanguageRequest == "fr" ? Lat.Replace(".", ",") : Lat));
            string Lng = "-65.45";
            fc.Add("Lng", (LanguageRequest == "fr" ? Lng.Replace(".", ",") : Lng));

            return fc;

        }
        public PolSourceSiteModel AddPolSourceSiteModel()
        {
            TVItemModel tvItemModelSubsector = randomService.RandomTVItem(TVTypeEnum.Subsector);
            Assert.AreEqual("", tvItemModelSubsector.Error);

            TVItemModel tvItemModelPolSourceSite = polSourceSiteService._TVItemService.PostAddChildTVItemDB(tvItemModelSubsector.TVItemID, randomService.RandomString("Pol source ", 20), TVTypeEnum.PolSourceSite);
            if (!string.IsNullOrWhiteSpace(tvItemModelPolSourceSite.Error))
            {
                return new PolSourceSiteModel() { Error = tvItemModelPolSourceSite.Error };
            }

            polSourceSiteModelNew.PolSourceSiteTVItemID = tvItemModelPolSourceSite.TVItemID;

            FillPolSourceSiteModel(polSourceSiteModelNew);

            PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PostAddPolSourceSiteDB(polSourceSiteModelNew);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
            {
                return polSourceSiteModelRet;
            }


            polSourceSiteModelNew.PolSourceSiteTVItemID = polSourceSiteModelRet.PolSourceSiteTVItemID;

            ComparePolSourceSiteModels(polSourceSiteModelNew, polSourceSiteModelRet);

            return polSourceSiteModelRet;

        }
        //public PolSourceSiteModel UpdatePolSourceSiteModel(PolSourceSiteModel polSourceSiteModel)
        //{
        //    FillPolSourceSiteModel(polSourceSiteModel);

        //    PolSourceSiteModel polSourceSiteModelRet2 = polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModel);
        //    Assert.AreEqual("", polSourceSiteModelRet2.Error);
           
        //    ComparePolSourceSiteModels(polSourceSiteModel, polSourceSiteModelRet2);

        //    return polSourceSiteModelRet2;
        //}
        private void ComparePolSourceSiteModels(PolSourceSiteModel polSourceSiteModelNew, PolSourceSiteModel polSourceSiteModelRet)
        {
            Assert.AreEqual(polSourceSiteModelNew.PolSourceSiteTVItemID, polSourceSiteModelRet.PolSourceSiteTVItemID);
            Assert.AreEqual(polSourceSiteModelNew.Temp_Locator_CanDelete, polSourceSiteModelRet.Temp_Locator_CanDelete);
            Assert.AreEqual(polSourceSiteModelNew.Oldsiteid, polSourceSiteModelRet.Oldsiteid);
            Assert.AreEqual(polSourceSiteModelNew.Site, polSourceSiteModelRet.Site);
            Assert.AreEqual(polSourceSiteModelNew.SiteID, polSourceSiteModelRet.SiteID);
            Assert.AreEqual(polSourceSiteModelNew.IsPointSource, polSourceSiteModelRet.IsPointSource);

            foreach (LanguageEnum Lang in polSourceSiteService.LanguageListAllowable)
            {
                TVItemLanguageModel tvItemLanguageModel = polSourceSiteService._TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(polSourceSiteModelRet.PolSourceSiteTVItemID, Lang);
                Assert.AreEqual("", tvItemLanguageModel.Error);

                if (Lang == polSourceSiteService.LanguageRequest)
                {
                    Assert.AreEqual(polSourceSiteModelRet.PolSourceSiteTVText, tvItemLanguageModel.TVText);
                }
            }
        }
        public void FillPolSourceSiteModel(PolSourceSiteModel polSourceSiteModel)
        {
            polSourceSiteModel.PolSourceSiteTVItemID = polSourceSiteModel.PolSourceSiteTVItemID;
            polSourceSiteModel.PolSourceSiteTVText = randomService.RandomString("PolSourceSite", 30);
            polSourceSiteModel.Temp_Locator_CanDelete = randomService.RandomString("temp locator", 30);
            polSourceSiteModel.Oldsiteid = randomService.RandomInt(1, 100);
            polSourceSiteModel.Site = randomService.RandomInt(1, 100);
            polSourceSiteModel.SiteID = randomService.RandomInt(1, 100);
            polSourceSiteModel.IsPointSource = true;

            Assert.IsTrue(polSourceSiteModel.PolSourceSiteTVItemID != 0);
            Assert.IsTrue(polSourceSiteModel.PolSourceSiteTVText.Length == 30);
            Assert.IsTrue(polSourceSiteModel.Temp_Locator_CanDelete.Length == 30);
            Assert.IsTrue(polSourceSiteModel.Oldsiteid >= 0 && polSourceSiteModel.Oldsiteid <= 100);
            Assert.IsTrue(polSourceSiteModel.Site >= 0 && polSourceSiteModel.Site <= 100);
            Assert.IsTrue(polSourceSiteModel.SiteID >= 0 && polSourceSiteModel.SiteID <= 100);
            Assert.IsTrue(polSourceSiteModel.IsPointSource == true);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            polSourceSiteService = new PolSourceSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            polSourceSiteModelNew = new PolSourceSiteModel();
            polSourceSite = new PolSourceSite();
        }
        private void SetupShim()
        {
            shimPolSourceSiteService = new ShimPolSourceSiteService(polSourceSiteService);
            shimTVItemService = new ShimTVItemService(polSourceSiteService._TVItemService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(polSourceSiteService._TVItemService._TVItemLanguageService);
            shimMapInfoService = new ShimMapInfoService(polSourceSiteService._MapInfoService);
            shimMapInfoPointService = new ShimMapInfoPointService(polSourceSiteService._MapInfoService._MapInfoPointService);
            shimPolSourceObservationService = new ShimPolSourceObservationService(polSourceSiteService._PolSourceObservationService);
            shimPolSourceObservationIssueService = new ShimPolSourceObservationIssueService(polSourceSiteService._PolSourceObservationService._PolSourceObservationIssueService);
        }
        #endregion Functions private
    }
}

