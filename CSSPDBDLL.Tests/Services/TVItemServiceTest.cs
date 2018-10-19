using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPDBDLL.Tests.SetupInfo;
using CSSPDBDLL.Models;
using System.Security.Principal;
using CSSPDBDLL.Services;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using System.Linq;
using CSSPDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using CSSPDBDLL.Fakes;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for TVItemServiceTest
    /// </summary>
    [TestClass]
    public class TVItemServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "TVItem";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private TVItemService tvItemService { get; set; }
        private TVItemLinkService tvItemLinkService { get; set; }
        private TestDBService testDBService { get; set; }
        private TVItemLinkServiceTest tvItemLinkServiceTest { get; set; }
        private RandomService randomService { get; set; }
        private TVItemModel tvItemModelNew { get; set; }
        private TVItem tvItem { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
        private MapInfoService mapInfoService { get; set; }
        private ShimTVItemLinkService shimTVItemLinkService { get; set; }
        private TVFileService tvFileService { get; set; }
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
        public TVItemServiceTest()
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

        #region Testing Methods public check and fill
        [TestMethod]
        public void TVItemService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(tvItemService);
                Assert.IsNotNull(tvItemService._TVItemLanguageService);
                Assert.IsNotNull(tvItemService.db);
                Assert.IsNotNull(tvItemService.LanguageRequest);
                Assert.IsNotNull(tvItemService.User);
                Assert.AreEqual(user.Identity.Name, tvItemService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), tvItemService.LanguageRequest);
            }
        }
        [TestMethod]
        public void TVItemService_TVItemModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    #region Good
                    SetupTest(contactModelListGood[0], culture);
                    TVItemModel tvItemModelCountry = randomService.RandomTVItem(TVTypeEnum.Country);

                    TVItemModel tvItemModelNew = new TVItemModel();
                    #endregion Good

                    #region TVLevel
                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    int Min = 0;
                    int Max = 100;
                    tvItemModelNew.TVLevel = Min - 1;

                    string retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TVLevel, Min, Max), retStr);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.TVLevel = Max + 1;

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TVLevel, Min, Max), retStr);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.TVLevel = Max - 1;

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.TVLevel = Min;

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.TVLevel = Max;

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion TVLevel

                    #region TVPath
                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    Max = 250;
                    tvItemModelNew.TVPath = randomService.RandomString("", 0);

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVPath), retStr);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.TVPath = randomService.RandomString("", Max + 1);

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.TVPath, Max), retStr);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.TVPath = randomService.RandomString("", Max - 1);

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.TVPath = randomService.RandomString("", Max);

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion TVPath

                    #region TVType
                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.TVType = (TVTypeEnum)10000;

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVType), retStr);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.TVType = TVTypeEnum.Country;

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion TVType

                    #region ParentID
                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    Min = 0;
                    Max = 1000000;
                    tvItemModelNew.ParentID = Min - 1;

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ParentID, Min, Max), retStr);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.ParentID = Max + 1;

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ParentID, Min, Max), retStr);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.ParentID = Max - 1;

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.ParentID = Min;

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelCountry, TVTypeEnum.Province);
                    tvItemModelNew.ParentID = Max;

                    retStr = tvItemService.TVItemModelOK(tvItemModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion ParentID
                }
            }
        }
        [TestMethod]
        public void TVItemService_FillTVItem_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual(1, tvItemModelParent.TVItemID);

                    FillTVItemModelNew(tvItemModelNew, tvItemModelParent, TVTypeEnum.Country);

                    ContactOK contactOK = tvItemService.IsContactOK();

                    string retStr = tvItemService.FillTVItem(tvItem, tvItemModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, tvItem.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = tvItemService.FillTVItem(tvItem, tvItemModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, tvItem.LastUpdateContactTVItemID);

                }
            }
        }
        #endregion Testing Methods public check and fill

        #region Testing Methods public Get
        [TestMethod]
        public void TVItemService_GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB_Root_Country_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Country);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelParentNew.TVItemID, TVTypeEnum.Country);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);
                    Assert.IsTrue(tvItemModelList.Where(c => c.TVItemID == tvItemModelRet.TVItemID).Any());

                    int TVItemID = 0;
                    tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, TVTypeEnum.Country);
                    Assert.IsTrue(tvItemModelList.Count == 1);
                    Assert.IsTrue(!string.IsNullOrWhiteSpace(tvItemModelList[0].Error));
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB_Root_Country_Province_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Country);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Province);

                    // Act for Add
                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelParentNew.TVItemID, TVTypeEnum.Province);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);
                    Assert.IsTrue(tvItemModelList.Where(c => c.TVItemID == tvItemModelRet.TVItemID).Any());
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB_Root_Country_Province_Area_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Province);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Area);

                    // Act for Add
                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelParentNew.TVItemID, TVTypeEnum.Area);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);
                    Assert.IsTrue(tvItemModelList.Where(c => c.TVItemID == tvItemModelRet.TVItemID).Any());
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB_Root_Country_Province_Area_Sector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Area);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Sector);

                    // Act for Add
                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelParentNew.TVItemID, TVTypeEnum.Sector);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);
                    Assert.IsTrue(tvItemModelList.Where(c => c.TVItemID == tvItemModelRet.TVItemID).Any());
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB_Root_Country_Province_Area_Sector_Subsector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Sector);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Subsector);

                    // Act for Add
                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelParentNew.TVItemID, TVTypeEnum.Subsector);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);
                    Assert.IsTrue(tvItemModelList.Where(c => c.TVItemID == tvItemModelRet.TVItemID).Any());
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB_Root_Country_Province_Area_Sector_Subsector_Municipality_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Subsector);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Municipality);

                    // Act for Add
                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelParentNew.TVItemID, TVTypeEnum.Municipality);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);
                    Assert.IsTrue(tvItemModelList.Where(c => c.TVItemID == tvItemModelRet.TVItemID).Any());
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB_Root_Tel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Tel);

                    // Act for Add
                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelParentNew.TVItemID, TVTypeEnum.Tel);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);
                    Assert.IsTrue(tvItemModelList.Where(c => c.TVItemID == tvItemModelRet.TVItemID).Any());
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetChildrenTVItemModelAndChildCountListWithTVItemIDAndTVTypeDB_Root_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Country);

                    List<TVItemModelAndChildCount> tvItemModelAndChildCountList = tvItemService.GetChildrenTVItemModelAndChildCountListWithTVItemIDAndTVTypeDB(tvItemModelParentNew.TVItemID, TVTypeEnum.Country);
                    Assert.IsNotNull(tvItemModelAndChildCountList);
                    Assert.IsTrue(tvItemModelAndChildCountList.Count > 0);
                    Assert.IsTrue(tvItemModelAndChildCountList.Where(c => c.TVItemID == tvItemModelRet.TVItemID).Any());
                    Assert.IsTrue(tvItemModelAndChildCountList.Where(c => c.TVItemID == tvItemModelRet.TVItemID).FirstOrDefault().ChildCount == 0);

                    tvItemModelAndChildCountList = tvItemService.GetChildrenTVItemModelAndChildCountListWithTVItemIDAndTVTypeDB(tvItemModelParentNew.TVItemID, TVTypeEnum.Error);
                    Assert.IsNotNull(tvItemModelAndChildCountList);
                    Assert.IsTrue(tvItemModelAndChildCountList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetChildrenTVItemModelAndChildCountListWithTVItemIDAndTVTypeDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Country);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        List<TVItemModelAndChildCount> tvItemModelAndChildCountList = tvItemService.GetChildrenTVItemModelAndChildCountListWithTVItemIDAndTVTypeDB(0, TVTypeEnum.Error);
                        Assert.IsNotNull(tvItemModelAndChildCountList);
                        Assert.IsTrue(tvItemModelAndChildCountList.Count == 1);
                        Assert.AreEqual(ErrorText, tvItemModelAndChildCountList[0].Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB_Root_Country_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Country);

                    // Act for Add
                    TVItemModel tvItemModelRet2 = tvItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(tvItemModelParentNew.TVItemID, tvItemModelRet.TVText, TVTypeEnum.Country);
                    Assert.IsNotNull(tvItemModelRet2);
                    CompareTVItemModels(tvItemModelRet, tvItemModelRet2);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB_Root_Country_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Country);

                    TVItemModel tvItemModelRet2 = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelParentNew.TVItemID, tvItemModelRet.TVText, TVTypeEnum.Country);

                    CompareTVItemModels(tvItemModelRet, tvItemModelRet2);

                    string TVText = "WillNotFind";
                    tvItemModelRet2 = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelParentNew.TVItemID, TVText, TVTypeEnum.Country);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID + "," + ServiceRes.TVText + "," + ServiceRes.TVType, tvItemModelParentNew.TVItemID.ToString() + "," + TVText + "," + TVTypeEnum.Country.ToString()), tvItemModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Country);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModelRet2 = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelParentNew.TVItemID, tvItemModelRet.TVText, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemModelListWithTVItemIDForActivityDB_Root_Country_Province_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Country);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Province);

                    List<TVItemModel> tvItemModelList = tvItemService.GetParentTVItemModelListWithTVItemIDForActivityDB(tvItemModelRet.TVItemID);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.AllActivities, tvItemModelList[0].TVText);
                    Assert.AreEqual(TVTypeEnum.Root, tvItemModelList[0].TVType);
                    Assert.AreEqual(tvItemModelParentNew.TVText, tvItemModelList[1].TVText);
                    Assert.AreEqual(TVTypeEnum.Country, tvItemModelList[1].TVType);

                    int TVItemID = 0;
                    tvItemModelList = tvItemService.GetParentTVItemModelListWithTVItemIDForActivityDB(TVItemID);
                    Assert.IsTrue(tvItemModelList.Count == 1);
                    Assert.IsTrue(!string.IsNullOrWhiteSpace(tvItemModelList[0].Error));
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemModelListWithTVItemIDForActivityDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Country);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Province);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        List<TVItemModel> tvItemModelList = tvItemService.GetParentTVItemModelListWithTVItemIDForActivityDB(tvItemModelRet.TVItemID);
                        Assert.IsNotNull(tvItemModelList);
                        Assert.AreEqual(1, tvItemModelList.Count);
                        Assert.AreEqual(ErrorText, tvItemModelList[0].Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemModelListWithTVItemIDForActivityDB_GetParentsTVItemIDList_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Country);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Province);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetParentsTVItemIDListString = (a) =>
                        {
                            return new List<int>();
                        };

                        List<TVItemModel> tvItemModelList = tvItemService.GetParentTVItemModelListWithTVItemIDForActivityDB(tvItemModelRet.TVItemID);
                        Assert.IsNotNull(tvItemModelList);
                        Assert.AreEqual(0, tvItemModelList.Count);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemModelListWithTVItemIDForLocationDB_Root_Country_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Country);

                    // Act for Add
                    List<TVItemModel> tvItemModelList = tvItemService.GetParentTVItemModelListWithTVItemIDForLocationDB(tvItemModelRet.TVItemID);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.AllLocations, tvItemModelList[0].TVText);
                    Assert.AreEqual(TVTypeEnum.Root, tvItemModelList[0].TVType);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemModelListWithTVItemIDForLocationDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Country);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Province);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        List<TVItemModel> tvItemModelList = tvItemService.GetParentTVItemModelListWithTVItemIDForLocationDB(tvItemModelRet.TVItemID);
                        Assert.IsNotNull(tvItemModelList);
                        Assert.AreEqual(1, tvItemModelList.Count);
                        Assert.AreEqual(ErrorText, tvItemModelList[0].Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemModelListWithTVItemIDForLocationDB_GetParentsTVItemIDList_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Country);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Province);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetParentsTVItemIDListString = (a) =>
                        {
                            return new List<int>();
                        };

                        List<TVItemModel> tvItemModelList = tvItemService.GetParentTVItemModelListWithTVItemIDForLocationDB(tvItemModelRet.TVItemID);
                        Assert.IsNotNull(tvItemModelList);
                        Assert.AreEqual(0, tvItemModelList.Count);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemModelListWithTVItemIDForLocationDB_Root_Country_Province_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Country);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Province);

                    // Act for Add
                    List<TVItemModel> tvItemModelList = tvItemService.GetParentTVItemModelListWithTVItemIDForLocationDB(tvItemModelRet.TVItemID);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.AllLocations, tvItemModelList[0].TVText);
                    Assert.AreEqual(TVTypeEnum.Root, tvItemModelList[0].TVType);
                    Assert.AreEqual(tvItemModelParentNew.TVText, tvItemModelList[1].TVText);
                    Assert.AreEqual(TVTypeEnum.Country, tvItemModelList[1].TVType);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemModelWithTVItemIDForActivityDB_Root_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = tvItemService.GetParentTVItemModelWithTVItemIDForActivityDB(tvItemModel.TVItemID);
                    Assert.AreEqual(ServiceRes.RootTVItemDoesNotHaveParentTVItem, tvItemModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemModelWithTVItemIDForActivityDB_Not_Root_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Country);

                    TVItemModel tvItemModelRet = tvItemService.GetParentTVItemModelWithTVItemIDForActivityDB(tvItemModel.TVItemID);
                    Assert.AreEqual("", tvItemModel.Error);
                    Assert.AreEqual(TVTypeEnum.Root, tvItemModelRet.TVType);

                    int TVItemID = 0;
                    tvItemModelRet = tvItemService.GetParentTVItemModelWithTVItemIDForActivityDB(TVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFindParent_WithChild_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, TVItemID), tvItemModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemModelWithTVItemIDForLocationDB_Root_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = tvItemService.GetParentTVItemModelWithTVItemIDForLocationDB(tvItemModel.TVItemID);
                    Assert.AreEqual(ServiceRes.RootTVItemDoesNotHaveParentTVItem, tvItemModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemModelWithTVItemIDForLocationDB_Not_Root_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Country);

                    TVItemModel tvItemModelRet = tvItemService.GetParentTVItemModelWithTVItemIDForLocationDB(tvItemModel.TVItemID);
                    Assert.AreEqual("", tvItemModel.Error);
                    Assert.AreEqual(TVTypeEnum.Root, tvItemModelRet.TVType);

                    int TVItemID = 0;
                    tvItemModelRet = tvItemService.GetParentTVItemModelWithTVItemIDForLocationDB(TVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFindParent_WithChild_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, TVItemID), tvItemModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetRootTVItemModelDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRet2 = tvItemService.GetRootTVItemModelDB();
                    Assert.IsNotNull(tvItemModelRet2);
                    Assert.AreEqual(ServiceRes.AllLocations, tvItemModelRet2.TVText);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetSearchTag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    for (int i = 1, count = Enum.GetNames(typeof(SearchTagEnum)).Length; i < count; i++)
                    {
                        SearchTagEnum searchTag = tvItemService.GetSearchTag(((SearchTagEnum)i).ToString());
                        Assert.AreEqual((SearchTagEnum)i, searchTag);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetSearchTagAndTermsList_no_Tags_1_term_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> termList = new List<string>() { "bonjour" };
                    string SearchTerm = "";
                    int c = 0;
                    foreach (string s in termList)
                    {
                        SearchTerm += (c == 0 ? "" : " ") + s;
                        c += 1;
                    }
                    List<SearchTagAndTerms> searchTagAndTermsList = tvItemService.GetSearchTagAndTermsList(SearchTerm);
                    Assert.AreEqual(1, searchTagAndTermsList.Count);
                    Assert.AreEqual(SearchTagEnum.notag, searchTagAndTermsList[0].SearchTag);
                    Assert.AreEqual(termList.Count, searchTagAndTermsList[0].SearchTermList.Count);
                    int count = 0;
                    foreach (string s in termList)
                    {
                        Assert.AreEqual(s, searchTagAndTermsList[0].SearchTermList[count]);
                        count += 1;
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetSearchTagAndTermsList_no_Tags_2_term_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> termList = new List<string>() { "bonjour", "allo" };
                    string SearchTerm = "";
                    int c = 0;
                    foreach (string s in termList)
                    {
                        SearchTerm += (c == 0 ? "" : " ") + s;
                        c += 1;
                    }
                    List<SearchTagAndTerms> searchTagAndTermsList = tvItemService.GetSearchTagAndTermsList(SearchTerm);
                    Assert.AreEqual(1, searchTagAndTermsList.Count);
                    Assert.AreEqual(SearchTagEnum.notag, searchTagAndTermsList[0].SearchTag);
                    Assert.AreEqual(termList.Count, searchTagAndTermsList[0].SearchTermList.Count);
                    int count = 0;
                    foreach (string s in termList)
                    {
                        Assert.AreEqual(s, searchTagAndTermsList[0].SearchTermList[count]);
                        count += 1;
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetSearchTagAndTermsList_no_Tags_x_term_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> termList = new List<string>();
                    for (int i = 0; i < 10; i++)
                    {
                        termList.Add(randomService.RandomString("", 10));

                        string SearchTerm = "";
                        int c = 0;
                        foreach (string s in termList)
                        {
                            SearchTerm += (c == 0 ? "" : " ") + s;
                            c += 1;
                        }
                        List<SearchTagAndTerms> searchTagAndTermsList = tvItemService.GetSearchTagAndTermsList(SearchTerm);
                        Assert.AreEqual(1, searchTagAndTermsList.Count);
                        Assert.AreEqual(SearchTagEnum.notag, searchTagAndTermsList[0].SearchTag);
                        Assert.AreEqual(termList.Count, searchTagAndTermsList[0].SearchTermList.Count);
                        int count = 0;
                        foreach (string s in termList)
                        {
                            Assert.AreEqual(s, searchTagAndTermsList[0].SearchTermList[count]);
                            count += 1;
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetSearchTagAndTermsList_1_Tags_1_term_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> termList = new List<string>() { "bonjour" };
                    List<string> tagList = new List<string>() { "c:" };

                    string SearchTerm = "";
                    int c = 0;
                    foreach (string s in termList)
                    {
                        SearchTerm += (c == 0 ? "" : " ") + s;
                        c += 1;
                    }

                    SearchTerm = tagList[0] + " " + SearchTerm;
                    List<SearchTagAndTerms> searchTagAndTermsList = tvItemService.GetSearchTagAndTermsList(SearchTerm);
                    Assert.AreEqual(1, searchTagAndTermsList.Count);
                    Assert.AreEqual(SearchTagEnum.c, searchTagAndTermsList[0].SearchTag);
                    Assert.AreEqual(termList.Count, searchTagAndTermsList[0].SearchTermList.Count);
                    int count = 0;
                    foreach (string s in termList)
                    {
                        Assert.AreEqual(s, searchTagAndTermsList[0].SearchTermList[count]);
                        count += 1;
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetSearchTagAndTermsList_x_Tags_x_term_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> termList = new List<string>();
                    List<SearchTagEnum> tagList = new List<SearchTagEnum>();
                    for (int i = 0; i < 10; i++)
                    {
                        termList.Add(randomService.RandomString("", 10));

                        string Term = "";
                        int c = 0;
                        foreach (string s in termList)
                        {
                            Term += (c == 0 ? "" : " ") + s;
                            c += 1;
                        }

                        for (int j = 1, countTag = Enum.GetNames(typeof(SearchTagEnum)).Length; j < countTag; j++)
                        {
                            tagList.Add((SearchTagEnum)j);

                            string SearchTerm = "";
                            int d = 0;
                            foreach (SearchTagEnum st in tagList)
                            {
                                string TagTerm = (d == 0 ? "" : " ") + st + ": " + Term;
                                SearchTerm = SearchTerm + TagTerm;
                                d += 1;
                            }
                            List<SearchTagAndTerms> searchTagAndTermsList = tvItemService.GetSearchTagAndTermsList(SearchTerm);
                            Assert.AreEqual(tagList.Count, searchTagAndTermsList.Count);
                            int countd = 0;
                            foreach (SearchTagEnum stt in tagList)
                            {
                                Assert.AreEqual(stt, searchTagAndTermsList[countd].SearchTag);
                                Assert.AreEqual(termList.Count, searchTagAndTermsList[countd].SearchTermList.Count);
                                int count = 0;
                                foreach (string s in termList)
                                {
                                    Assert.AreEqual(s, searchTagAndTermsList[countd].SearchTermList[count]);
                                    count += 1;
                                }
                                countd += 1;
                            }
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetSearchTagAndTermsList_Tag_After_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string SearchTerm = "u: c: joe";
                    List<SearchTagAndTerms> searchTagAndTermsList = tvItemService.GetSearchTagAndTermsList(SearchTerm);
                    Assert.AreEqual(2, searchTagAndTermsList.Count);
                    Assert.AreEqual(SearchTagEnum.u, searchTagAndTermsList[0].SearchTag);
                    Assert.AreEqual(0, searchTagAndTermsList[0].SearchTermList.Count);
                    Assert.AreEqual(SearchTagEnum.c, searchTagAndTermsList[1].SearchTag);
                    Assert.AreEqual(1, searchTagAndTermsList[1].SearchTermList.Count);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetSearchTagAndTermsList_noTag_than_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string SearchTerm = "New Brunswick c: joe";
                    List<SearchTagAndTerms> searchTagAndTermsList = tvItemService.GetSearchTagAndTermsList(SearchTerm);
                    Assert.AreEqual(2, searchTagAndTermsList.Count);
                    Assert.AreEqual(SearchTagEnum.notag, searchTagAndTermsList[0].SearchTag);
                    Assert.AreEqual(2, searchTagAndTermsList[0].SearchTermList.Count);
                    Assert.AreEqual("New", searchTagAndTermsList[0].SearchTermList[0]);
                    Assert.AreEqual("Brunswick", searchTagAndTermsList[0].SearchTermList[1]);
                    Assert.AreEqual(SearchTagEnum.c, searchTagAndTermsList[1].SearchTag);
                    Assert.AreEqual(1, searchTagAndTermsList[1].SearchTermList.Count);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetSubTVItemModelWithFromTVItemIDAndToTVItemIDOfTVTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelProvince = randomService.RandomTVItem(TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    TVItemModel tvItemModelFrom = tvItemService.PostAddChildTVItemDB(tvItemModelProvince.TVItemID, "unique muni", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelFrom.Error);

                    TVItemModel tvItemModelTo = randomService.RandomTVItem(TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelTo.Error);

                    TVItemLinkModel tvItemLinkModelNew = randomService.RandomTVItemLinkModel(tvItemModelFrom, tvItemModelTo, true);
                    Assert.IsNotNull(tvItemLinkModelNew);
                    Assert.AreEqual("", tvItemLinkModelNew.Error);

                    TVItemModel tvItemModelFrom2 = tvItemService.PostAddChildTVItemDB(tvItemModelProvince.TVItemID, "unique muni2", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelFrom2.Error);

                    TVItemLinkModel tvItemLinkModelNew2 = randomService.RandomTVItemLinkModel(tvItemModelFrom2, tvItemModelTo, true);
                    Assert.IsNotNull(tvItemLinkModelNew2);
                    Assert.AreEqual("", tvItemLinkModelNew2.Error);

                    tvItemLinkModelNew2.FromTVItemID = tvItemLinkModelNew.ToTVItemID;
                    tvItemLinkModelNew2.ParentTVItemLinkID = tvItemLinkModelNew.TVItemLinkID;

                    TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostUpdateTVItemLinkDB(tvItemLinkModelNew2);
                    Assert.IsNotNull(tvItemLinkModelRet);
                    tvItemLinkServiceTest.CompareTVItemLinkModels(tvItemLinkModelRet, tvItemLinkModelNew2);

                    List<TVItemModel> tvItemModelList = tvItemService.GetSubTVItemModelWithFromTVItemIDAndToTVItemIDOfTVTypeDB(tvItemLinkModelNew.FromTVItemID, tvItemLinkModelNew.ToTVItemID, tvItemLinkModelRet.ToTVType);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Country);

                    int tvItemCount = tvItemService.GetTVItemModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, tvItemCount);

                    TVItemModel tvItemModelRet2 = tvItemService.PostDeleteTVItemWithTVItemIDDB(tvItemModelRet.TVItemID);
                    Assert.AreEqual("", tvItemModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelCountWithTVTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Country);

                    // Act for Add
                    int CountryCount = tvItemService.GetTVItemModelCountWithTVTypeDB(TVTypeEnum.Country);
                    Assert.IsTrue(CountryCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListWithTVTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Country);

                    // Act for Add
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.Country);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelProv = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelRoot.TVItemID, TVTypeEnum.Province).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelProv.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelRoot.TVItemID, tvItemModelProv.TVText);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelRoot.TVItemID, "");
                    Assert.IsNotNull(tvItemModelList);
                    Assert.IsTrue(tvItemModelList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_2_letter_Random_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    for (int i = 0; i < 5; i++)
                    {
                        string SearchTerm = randomService.RandomString("", 2);

                        List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelRoot.TVItemID, SearchTerm);
                        Assert.IsNotNull(tvItemModelList);
                        if (tvItemModelList.Count > 0)
                        {
                            Assert.IsTrue(tvItemModelList.Where(c => c.TVText.ToLower().Contains(SearchTerm)).Any());
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_Multiple_SearchTerms_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    List<string> TermList = new List<string>() { "rrrr", "dddd", "gggg" };

                    string TVText = "";
                    foreach (string s in TermList)
                    {
                        TVText += s + " ";
                        TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Country);
                        Assert.AreEqual("", tvItemModelRet.Error);
                    }

                    for (int i = 0, count = TermList.Count; i < count; i++)
                    {
                        string SearchTerm = TermList[i];
                        List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelRoot.TVItemID, SearchTerm);
                        Assert.AreEqual(TermList.Count - i, tvItemModelList.Count);

                        SearchTerm = "u: " + TermList[i];
                        tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelMunicipality.TVItemID, SearchTerm);
                        Assert.AreEqual(0, tvItemModelList.Count);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_Contact_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    List<string> TermList = new List<string>() { "rrrr", "dddd", "gggg" };
                    string TVText = "";
                    foreach (string s in TermList)
                    {
                        TVText += s + " ";
                        TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                        Assert.AreEqual("", tvItemModelRet.Error);
                    }

                    for (int i = 0, count = TermList.Count; i < count; i++)
                    {
                        string tag = "c:";
                        string SearchTerm = tag + " " + TermList[i];
                        List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelRoot.TVItemID, SearchTerm);
                        Assert.AreEqual(TermList.Count - i, tvItemModelList.Count);

                        SearchTerm = "u: " + TermList[i];
                        tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelMunicipality.TVItemID, SearchTerm);
                        Assert.AreEqual(0, tvItemModelList.Count);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_Email_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string TVText = "rrrrrrrrrr@ec.gc.ca";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Email);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    string tag = "e:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelRoot.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelRoot.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_Tel_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string TVText = "(506) 555-55555";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Tel);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    string tag = "t:";
                    string Term = "55555";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelRoot.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelRoot.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_Image_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.Image,
                        FileType = FileTypeEnum.GIF,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fi:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_Picture_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.Picture,
                        FileType = FileTypeEnum.GIF,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fp:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_Reported_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.ReportGenerated,
                        FileType = FileTypeEnum.GIF,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fr:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_Generated_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.TemplateGenerated,
                        FileType = FileTypeEnum.GIF,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fg:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_PDF_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.TemplateGenerated,
                        FileType = FileTypeEnum.PDF,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fpdf:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_DOCX_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.TemplateGenerated,
                        FileType = FileTypeEnum.DOCX,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fdocx:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_XLSX_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.TemplateGenerated,
                        FileType = FileTypeEnum.XLSX,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fxlsx:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_KMZ_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.TemplateGenerated,
                        FileType = FileTypeEnum.KMZ,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fkmz:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_XYZ_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.TemplateGenerated,
                        FileType = FileTypeEnum.XYZ,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fxyz:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_DFS0_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.TemplateGenerated,
                        FileType = FileTypeEnum.DFS0,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fdfs:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_DFS1_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.TemplateGenerated,
                        FileType = FileTypeEnum.DFS1,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fdfs:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_DFSU_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.TemplateGenerated,
                        FileType = FileTypeEnum.DFSU,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fdfs:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_MikeInput_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.MikeInput,
                        FileType = FileTypeEnum.MDF,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fmike:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_MikeInputMDF_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.MikeInputMDF,
                        FileType = FileTypeEnum.MDF,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fmike:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_MikeResultDFSU_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.MikeResultDFSU,
                        FileType = FileTypeEnum.MDF,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fmike:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_MikeResultKMZ_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.MikeResultKMZ,
                        FileType = FileTypeEnum.MDF,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fmike:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_MDF_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.MikeInputMDF,
                        FileType = FileTypeEnum.MDF,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fmdf:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_M21FM_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.MikeInput,
                        FileType = FileTypeEnum.M21FM,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fm21fm:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_M3FM_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.MikeInput,
                        FileType = FileTypeEnum.M3FM,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fm3fm:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_MESH_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.MikeInput,
                        FileType = FileTypeEnum.MESH,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "fmesh:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_LOG_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.MikeResultDFSU,
                        FileType = FileTypeEnum.LOG,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "flog:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_File_TXT_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    TVFileModel tvFileModelNew = new TVFileModel()
                    {
                        TVFileTVText = TVText,
                        Language = LanguageEnum.en,
                        FilePurpose = FilePurposeEnum.TemplateGenerated,
                        FileType = FileTypeEnum.TXT,
                        FileDescription = "Desc",
                        FileSize_kb = 4,
                        FileInfo = "info",
                        FileCreatedDate_UTC = DateTime.Now,
                        ClientFilePath = "",
                        ServerFileName = "testing",
                        ServerFilePath = "ssliefjslefj",
                        TVFileTVItemID = tvItemModelRet.TVItemID,
                    };

                    TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModel.Error);

                    string tag = "ftxt:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCanada.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelNB.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_Municipality_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-01-010-001", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelMunicipality = tvItemService.PostAddChildTVItemDB(tvItemModelSubsector.TVItemID, TVText, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    string tag = "m:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelMunicipality.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelMunicipality.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelMunicipality.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelMunicipality.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_Province_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelProvince = tvItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, TVText, TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    string tag = "p:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelCanada.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelProvince.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelProvince.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelProvince.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_MikeScenario_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelMikeScenario = tvItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    string tag = "ms:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelMikeScenario.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelMikeScenario.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelMikeScenario.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelMikeScenario.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_ClimateSite_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelClimateSite = tvItemService.PostAddChildTVItemDB(tvItemModelProvince.TVItemID, TVText, TVTypeEnum.ClimateSite);
                    Assert.AreEqual("", tvItemModelClimateSite.Error);

                    string tag = "cs:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelClimateSite.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelClimateSite.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelClimateSite.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelClimateSite.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_HydrometricSite_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelHydrometricSite = tvItemService.PostAddChildTVItemDB(tvItemModelProvince.TVItemID, TVText, TVTypeEnum.HydrometricSite);
                    Assert.AreEqual("", tvItemModelHydrometricSite.Error);

                    string tag = "hs:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelHydrometricSite.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelHydrometricSite.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelHydrometricSite.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelHydrometricSite.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_TideSite_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelTideSite = tvItemService.PostAddChildTVItemDB(tvItemModelProvince.TVItemID, TVText, TVTypeEnum.TideSite);
                    Assert.AreEqual("", tvItemModelTideSite.Error);

                    string tag = "ts:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelTideSite.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelTideSite.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelTideSite.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelTideSite.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_WasteWaterTreatmentPlant_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelBouctouche = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouctouche.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelWW = tvItemService.PostAddChildTVItemDB(tvItemModelBouctouche.TVItemID, TVText, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelWW.Error);

                    string tag = "ww:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelWW.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelWW.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelWW.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelWW.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_LiftStation_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelBouctouche = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouctouche.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelLS = tvItemService.PostAddChildTVItemDB(tvItemModelBouctouche.TVItemID, TVText, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelLS.Error);

                    string tag = "ls:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelLS.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelLS.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelLS.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelLS.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_MWQMSite_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-01-010-001", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelMWQMSite = tvItemService.PostAddChildTVItemDB(tvItemModelSubsector.TVItemID, TVText, TVTypeEnum.MWQMSite);
                    Assert.AreEqual("", tvItemModelMWQMSite.Error);

                    string tag = "st:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelMWQMSite.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelMWQMSite.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelMWQMSite.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelMWQMSite.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_PollutionSourceSite_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-01-010-001", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelPollutionSourceSite = tvItemService.PostAddChildTVItemDB(tvItemModelSubsector.TVItemID, TVText, TVTypeEnum.PolSourceSite);
                    Assert.AreEqual("", tvItemModelPollutionSourceSite.Error);

                    string tag = "ps:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelPollutionSourceSite.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelPollutionSourceSite.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelPollutionSourceSite.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelPollutionSourceSite.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_Area_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelArea = tvItemService.PostAddChildTVItemDB(tvItemModelProvince.TVItemID, TVText, TVTypeEnum.Area);
                    Assert.AreEqual("", tvItemModelArea.Error);

                    string tag = "a:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelArea.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelArea.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelArea.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelArea.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_Sector_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelArea = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-01", TVTypeEnum.Area);
                    Assert.AreEqual("", tvItemModelArea.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelSector = tvItemService.PostAddChildTVItemDB(tvItemModelArea.TVItemID, TVText, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    string tag = "s:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelSector.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelSector.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelSector.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelSector.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_Subsector_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-01-010", TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelSubsector = tvItemService.PostAddChildTVItemDB(tvItemModelSector.TVItemID, TVText, TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    string tag = "ss:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelSubsector.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelSubsector.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelSubsector.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelSubsector.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_Under_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-01-010", TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelSubsector = tvItemService.PostAddChildTVItemDB(tvItemModelSector.TVItemID, TVText, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    string tag = "u:";
                    string Term = "rrrrrrrrrr";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelSector.TVItemID, SearchTerm);
                    Assert.AreEqual(1, tvItemModelList.Count);
                    Assert.AreEqual(tvItemModelSubsector.TVText, tvItemModelList[0].TVText);

                    Term = "dddddddddddd";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelSubsector.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    string tag2 = "u:";
                    Term = "rrrrrrrrrr";
                    SearchTerm = tag2 + " " + tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelSubsector.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                    tag = "u:";
                    Term = "";
                    SearchTerm = tag + " " + Term;
                    tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelSector.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelListContainingTVTextDB_Under_Tag_Empty_Term_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-01-010", TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    string TVText = "rrrrrrrrrrrrrrrrr";
                    TVItemModel tvItemModelSubsector = tvItemService.PostAddChildTVItemDB(tvItemModelSector.TVItemID, TVText, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    string tag = "u:";
                    string Term = "";
                    string SearchTerm = tag + " " + Term;
                    List<TVItemModel> tvItemModelList = tvItemService.GetTVItemModelListContainingTVTextDB(tvItemModelSector.TVItemID, SearchTerm);
                    Assert.AreEqual(0, tvItemModelList.Count);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemModelWithTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Country);

                    TVItemModel tvItemModelRet2 = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelRet.TVItemID);
                    Assert.IsNotNull(tvItemModelRet2);
                    Assert.AreEqual(tvItemModelParentNew.TVItemID, tvItemModelRet2.ParentID);
                    Assert.AreEqual(TVTypeEnum.Country, tvItemModelRet2.TVType);

                    tvItemModelRet2 = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelParentNew.TVItemID);
                    Assert.AreEqual(ServiceRes.AllLocations, tvItemModelRet2.TVText);

                    int TVItemID = 0;
                    tvItemModelRet2 = tvItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, TVItemID), tvItemModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemWithTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Root);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Country);

                    // Act for Add
                    TVItem tvItemRet2 = tvItemService.GetTVItemWithTVItemIDDB(tvItemModelRet.TVItemID);
                    Assert.IsNotNull(tvItemRet2);
                    Assert.AreEqual(tvItemModelParentNew.TVItemID, tvItemRet2.ParentID);
                    Assert.AreEqual((int)TVTypeEnum.Country, tvItemRet2.TVType);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVTypeNamesAndPathParentsWithTVType_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> TVTypeNameList = new List<string>() { "Root", "Country", "Province", "Area", "Sector", "Subsector", "Municipality", "Infrastructure" };

                    string TVPath = "";

                    List<TVTypeNamesAndPath> tvTypeNamesAndPathParentsList = tvItemService.GetTVTypeNamesAndPathParentsWithTVType(TVPath);
                    Assert.IsTrue(tvTypeNamesAndPathParentsList.Count == 0);

                    for (int i = 0, count = TVTypeNameList.Count; i < count; i++)
                    {

                        TVPath = tvItemService.tvTypeNamesAndPathList.Where(c => c.TVTypeName == TVTypeNameList[i]).FirstOrDefault().TVPath;

                        tvTypeNamesAndPathParentsList = tvItemService.GetTVTypeNamesAndPathParentsWithTVType(TVPath);
                        Assert.IsTrue(tvTypeNamesAndPathParentsList.Count > 0);

                        for (int j = 0; j <= i; j++)
                        {
                            Assert.AreEqual(TVTypeNameList[j], tvTypeNamesAndPathParentsList[j].TVTypeName);
                        }
                    }
                }
            }
        }
        #endregion Testing Methods public Get

        #region Testing Methods public Helper
        [TestMethod]
        public void TVItemService_CleanText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> NotCleanTextList = new List<string>() { "\t\r\n/#&", "bonjour" };
                    List<string> CleanTextList = new List<string>() { "- AND", "bonjour" };

                    for (int i = 0, count = NotCleanTextList.Count; i < count; i++)
                    {
                        string retStr = tvItemService.CleanText(NotCleanTextList[i]);
                        Assert.AreEqual(CleanTextList[i], retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_CreateMapInfoObjectDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    List<Coord> coordList = new List<Coord>() { new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 } };

                    MapInfoModel mapInfoModel = tvItemService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Country, tvItemModelCanada.TVItemID);
                    Assert.AreEqual("", mapInfoModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetIsItSameObject_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModel = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);

                    bool retBool = tvItemService.GetIsItSameObject(tvItemModel, tvItemModel);
                    Assert.IsTrue(retBool);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetCoordFromText_Good_1_Point_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    List<Coord> coordListToEnter = new List<Coord>()
                    {
                        new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                    };

                    sb.Clear();
                    sb.AppendLine(coordListToEnter[0].Lat + " " + coordListToEnter[0].Lng);

                    List<Coord> coordList = tvItemService.GetCoordFromText(sb.ToString());
                    Assert.AreEqual(1, coordList.Count);
                    Assert.AreEqual(coordListToEnter[0].Lat, coordList[0].Lat, 0.001D);
                    Assert.AreEqual(coordListToEnter[0].Lng, coordList[0].Lng, 0.001D);

                    sb.Clear();
                    sb.AppendLine("");
                    sb.AppendLine(coordListToEnter[0].Lat + " " + coordListToEnter[0].Lng);
                    sb.AppendLine("");
                    sb.AppendLine("");

                    coordList = tvItemService.GetCoordFromText(sb.ToString());
                    Assert.AreEqual(1, coordList.Count);
                    Assert.AreEqual(coordListToEnter[0].Lat, coordList[0].Lat, 0.001D);
                    Assert.AreEqual(coordListToEnter[0].Lng, coordList[0].Lng, 0.001D);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetCoordFromText_Good_Many_Points_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();
                    List<Coord> coordListToEnter = new List<Coord>()
                    {
                        new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                        new Coord() { Lat = 45.2f, Lng = -66.2f, Ordinal = 1 },
                        new Coord() { Lat = 45.3f, Lng = -66.3f, Ordinal = 2 },
                    };

                    sb.Clear();
                    foreach (Coord coord in coordListToEnter)
                    {
                        sb.AppendLine(coord.Lat + " " + coord.Lng);
                    }

                    List<Coord> coordList = tvItemService.GetCoordFromText(sb.ToString());
                    Assert.AreEqual(3, coordList.Count);
                    Assert.AreEqual(coordListToEnter[0].Lat, coordList[0].Lat, 0.001D);
                    Assert.AreEqual(coordListToEnter[0].Lng, coordList[0].Lng, 0.001D);
                    Assert.AreEqual(coordListToEnter[1].Lat, coordList[1].Lat, 0.001);
                    Assert.AreEqual(coordListToEnter[1].Lng, coordList[1].Lng, 0.001D);

                    sb.Clear();
                    sb.AppendLine("");
                    foreach (Coord coord in coordListToEnter)
                    {
                        sb.AppendLine(coord.Lat + " " + coord.Lng);
                    }
                    sb.AppendLine("");

                    coordList = tvItemService.GetCoordFromText(sb.ToString());
                    Assert.AreEqual(3, coordList.Count);
                    Assert.AreEqual(coordListToEnter[0].Lat, coordList[0].Lat, 0.001D);
                    Assert.AreEqual(coordListToEnter[0].Lng, coordList[0].Lng, 0.001D);
                    Assert.AreEqual(coordListToEnter[1].Lat, coordList[1].Lat, 0.001);
                    Assert.AreEqual(coordListToEnter[1].Lng, coordList[1].Lng, 0.001D);

                    sb.Clear();
                    sb.AppendLine("");
                    foreach (Coord coord in coordListToEnter)
                    {
                        sb.AppendLine(coord.Lat + " " + coord.Lng);
                    }
                    sb.AppendLine("");
                    foreach (Coord coord in coordListToEnter)
                    {
                        sb.AppendLine(coord.Lat + " " + coord.Lng);
                    }

                    coordList = tvItemService.GetCoordFromText(sb.ToString());
                    Assert.AreEqual(6, coordList.Count);
                    Assert.AreEqual(coordListToEnter[0].Lat, coordList[0].Lat, 0.001D);
                    Assert.AreEqual(coordListToEnter[0].Lng, coordList[0].Lng, 0.001D);
                    Assert.AreEqual(coordListToEnter[1].Lat, coordList[1].Lat, 0.001);
                    Assert.AreEqual(coordListToEnter[1].Lng, coordList[1].Lng, 0.001D);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemID_TVPath_Random_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int LastTVPathID = randomService.RandomInt(200, 19827);
                        string TVPath = "p1p123p134p" + LastTVPathID;

                        int tvItemID = tvItemService.GetTVItemID(TVPath);
                        Assert.AreEqual(LastTVPathID, tvItemID);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemID_TVPath_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "";

                    int tvItemID = tvItemService.GetTVItemID(TVPath);
                    Assert.AreEqual(-1, tvItemID);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemID_TVPath_NotWellFormed_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "p1p";

                    int tvItemID = tvItemService.GetTVItemID(TVPath);
                    Assert.AreEqual(-1, tvItemID);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVLevel_TVPath_Random_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "";
                    for (int i = 0; i < 10; i++)
                    {
                        TVPath += "p" + i.ToString();

                        int level = tvItemService.GetTVLevel(TVPath);
                        Assert.AreEqual(i, level);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVLevel_TVPath_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "";

                    int level = tvItemService.GetTVLevel(TVPath);
                    Assert.AreEqual(-1, level);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVLevel_TVPath_NotWellFormed_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "p1p34p";

                    int level = tvItemService.GetTVLevel(TVPath);
                    Assert.AreEqual(-1, level);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVLevel_TVPath_Random_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "";
                    for (int i = 0; i < 10; i++)
                    {
                        TVPath += "p" + i.ToString();

                        int level = tvItemService.GetParentTVLevel(TVPath);

                        if (i == 0)
                        {
                            Assert.AreEqual(-1, level);
                        }
                        else
                        {
                            Assert.AreEqual(i - 1, level);
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVLevel_TVPath_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "";

                    int level = tvItemService.GetParentTVLevel(TVPath);
                    Assert.AreEqual(-1, level);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVLevel_TVPath_NotWellFormed_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "p1p34p345p";

                    int level = tvItemService.GetParentTVLevel(TVPath);
                    Assert.AreEqual(-1, level);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemID_TVPath_Random_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int BeforeLastTVPathID = randomService.RandomInt(200, 19827);
                        string TVPath = "p1p123p134p" + BeforeLastTVPathID + "p234234";

                        int tvItemID = tvItemService.GetParentTVItemID(TVPath);
                        Assert.AreEqual(BeforeLastTVPathID, tvItemID);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemID_TVPath_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "";

                    int tvItemID = tvItemService.GetParentTVItemID(TVPath);
                    Assert.AreEqual(-1, tvItemID);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemID_TVPath_Root_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "p1";

                    int tvItemID = tvItemService.GetParentTVItemID(TVPath);
                    Assert.AreEqual(-1, tvItemID);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVItemID_TVPath_NotWellFormed_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "p1p234p";

                    int tvItemID = tvItemService.GetParentTVItemID(TVPath);
                    Assert.AreEqual(-1, tvItemID);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVPath_TVPath_Random_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "";
                    for (int i = 0; i < 10; i++)
                    {
                        TVPath = "p" + i.ToString();

                        string strRet = tvItemService.GetParentTVPath(TVPath);

                        if (i == 0)
                        {
                            Assert.AreEqual("", strRet);
                        }
                        else
                        {
                            Assert.IsTrue(TVPath.StartsWith(strRet));
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVPath_TVPath_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "";

                    string strRet = tvItemService.GetParentTVPath(TVPath);
                    Assert.AreEqual("", strRet);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentTVPath_TVPath_NotWellFormed_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "p1p234p";

                    string strRet = tvItemService.GetParentTVPath(TVPath);
                    Assert.AreEqual("", strRet);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentsTVItemIDList_Random_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "";
                    List<int> intList = new List<int>();
                    for (int i = 1; i < 10; i++)
                    {
                        intList.Add(i);

                        TVPath += "p" + i.ToString();

                        List<int> intListRet = tvItemService.GetParentsTVItemIDList(TVPath);

                        int j = 0;
                        foreach (int num in intListRet)
                        {
                            Assert.AreEqual(intList[j], intListRet[j]);
                            j += 1;
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentsTVItemIDList_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "";

                    List<int> intListRet = tvItemService.GetParentsTVItemIDList(TVPath);
                    Assert.AreEqual(0, intListRet.Count);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentsTVItemIDList_NotWellFormed_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVPath = "p1p234p";

                    List<int> intListRet = tvItemService.GetParentsTVItemIDList(TVPath);
                    Assert.AreEqual(0, intListRet.Count);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetParentsTVItemModelList_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelMuni = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMuni.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetParentsTVItemModelList(tvItemModelMuni.TVPath);
                    Assert.IsNotNull(tvItemModelList);
                    Assert.AreEqual(7, tvItemModelList.Count);
                    Assert.IsTrue(tvItemModelList.Where(c => c.TVText == tvItemModelMuni.TVText).Any());
                }
            }
        }
        [TestMethod]
        public void TVItemService_IsMapInfoPointTextProperFormat_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    List<Coord> coordListToEnter = new List<Coord>()
                    {
                        new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                    };

                    sb.Clear();
                    sb.AppendLine(coordListToEnter[0].Lat + " " + coordListToEnter[0].Lng);

                    string retStr = tvItemService.IsMapInfoPointTextProperFormat(sb.ToString());
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void TVItemService_IsMapInfoPointTextProperFormat_Errors_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    List<Coord> coordListToEnter = new List<Coord>()
                    {
                        new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                    };

                    sb.Clear();

                    string retStr = tvItemService.IsMapInfoPointTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotWellFormedShouldHave1Point, retStr);

                    sb.Clear();
                    sb.AppendLine(coordListToEnter[0].Lat + " " + coordListToEnter[0].Lng);
                    sb.AppendLine(coordListToEnter[0].Lat + " " + coordListToEnter[0].Lng);

                    retStr = tvItemService.IsMapInfoPointTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotWellFormedShouldHave1Point, retStr);

                    sb.Clear();
                    sb.AppendLine(coordListToEnter[0].Lat + " ");

                    retStr = tvItemService.IsMapInfoPointTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotWellFormedShouldHave2Values, retStr);

                    sb.Clear();
                    sb.AppendLine("a" + coordListToEnter[0].Lat + " " + coordListToEnter[0].Lng);

                    retStr = tvItemService.IsMapInfoPointTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotADecimalValue, retStr);

                    sb.Clear();
                    sb.AppendLine(coordListToEnter[0].Lat + " a" + coordListToEnter[0].Lng);

                    retStr = tvItemService.IsMapInfoPointTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotADecimalValue, retStr);

                }
            }
        }
        [TestMethod]
        public void TVItemService_IsMapInfoPolylineTextProperFormat_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    List<Coord> coordListToEnter = new List<Coord>()
                    {
                        new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                        new Coord() { Lat = 45.2f, Lng = -66.2f, Ordinal = 1 },
                        new Coord() { Lat = 45.3f, Lng = -66.3f, Ordinal = 2 },
                    };

                    sb.Clear();
                    foreach (Coord coord in coordListToEnter)
                    {
                        sb.AppendLine(coord.Lat + " " + coord.Lng);
                    }

                    string retStr = tvItemService.IsMapInfoPolylineTextProperFormat(sb.ToString());
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void TVItemService_IsMapInfoPolylineTextProperFormat_Errors_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    List<Coord> coordListToEnter = new List<Coord>()
                    {
                        new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                        new Coord() { Lat = 45.2f, Lng = -66.2f, Ordinal = 1 },
                        new Coord() { Lat = 45.3f, Lng = -66.3f, Ordinal = 2 },
                    };

                    sb.Clear();
                    for (int i = 0; i < 1; i++)
                    {
                        sb.AppendLine(coordListToEnter[i].Lat + " " + coordListToEnter[i].Lng);
                    }

                    string retStr = tvItemService.IsMapInfoPolylineTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotWellFormedShouldHaveMoreThan1Point, retStr);

                    sb.Clear();
                    for (int i = 0; i < 3; i++)
                    {
                        sb.AppendLine(coordListToEnter[i].Lat + " ");
                    }

                    retStr = tvItemService.IsMapInfoPolylineTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotWellFormedShouldHave2Values, retStr);

                    sb.Clear();
                    for (int i = 0; i < 3; i++)
                    {
                        sb.AppendLine("a" + coordListToEnter[i].Lat + " " + coordListToEnter[i].Lng);
                    }

                    retStr = tvItemService.IsMapInfoPolylineTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotADecimalValue, retStr);

                    sb.Clear();
                    for (int i = 0; i < 3; i++)
                    {
                        sb.AppendLine(coordListToEnter[i].Lat + " a" + coordListToEnter[i].Lng);
                    }

                    retStr = tvItemService.IsMapInfoPolylineTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotADecimalValue, retStr);
                }
            }
        }
        [TestMethod]
        public void TVItemService_IsMapInfoPolygonTextProperFormat_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    List<Coord> coordListToEnter = new List<Coord>()
                    {
                        new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                        new Coord() { Lat = 45.2f, Lng = -66.2f, Ordinal = 1 },
                        new Coord() { Lat = 45.3f, Lng = -66.3f, Ordinal = 2 },
                    };

                    sb.Clear();
                    foreach (Coord coord in coordListToEnter)
                    {
                        sb.AppendLine(coord.Lat + " " + coord.Lng);
                    }

                    string retStr = tvItemService.IsMapInfoPolygonTextProperFormat(sb.ToString());
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void TVItemService_IsMapInfoPolygonTextProperFormat_Errors_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    List<Coord> coordListToEnter = new List<Coord>()
                    {
                        new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                        new Coord() { Lat = 45.2f, Lng = -66.2f, Ordinal = 1 },
                        new Coord() { Lat = 45.3f, Lng = -66.3f, Ordinal = 2 },
                    };

                    sb.Clear();
                    for (int i = 0; i < 1; i++)
                    {
                        sb.AppendLine(coordListToEnter[i].Lat + " " + coordListToEnter[i].Lng);
                    }

                    string retStr = tvItemService.IsMapInfoPolygonTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotWellFormedShouldHaveMoreThan2Points, retStr);

                    sb.Clear();
                    for (int i = 0; i < 3; i++)
                    {
                        sb.AppendLine(coordListToEnter[i].Lat + " ");
                    }

                    retStr = tvItemService.IsMapInfoPolygonTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotWellFormedShouldHave2Values, retStr);

                    sb.Clear();
                    for (int i = 0; i < 3; i++)
                    {
                        sb.AppendLine("a" + coordListToEnter[i].Lat + " " + coordListToEnter[i].Lng);
                    }

                    retStr = tvItemService.IsMapInfoPolygonTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotADecimalValue, retStr);

                    sb.Clear();
                    for (int i = 0; i < 3; i++)
                    {
                        sb.AppendLine(coordListToEnter[i].Lat + " a" + coordListToEnter[i].Lng);
                    }

                    retStr = tvItemService.IsMapInfoPolygonTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotADecimalValue, retStr);
                }
            }
        }
        [TestMethod]
        public void TVItemService_IsPointTextProperFormat_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    List<Coord> coordListToEnter = new List<Coord>()
                    {
                        new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                    };

                    sb.Clear();
                    foreach (Coord coord in coordListToEnter)
                    {
                        sb.AppendLine(coord.Lat + " " + coord.Lng);
                    }

                    string retStr = tvItemService.IsPointTextProperFormat(sb.ToString());
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void TVItemService_IsPointTextProperFormat_Errors_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    List<Coord> coordListToEnter = new List<Coord>()
                    {
                        new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                    };

                    sb.Clear();
                    foreach (Coord coord in coordListToEnter)
                    {
                        sb.Append(coord.Lat + " ");
                    }

                    string retStr = tvItemService.IsPointTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotWellFormedShouldHave2Values, retStr);

                    sb.Clear();
                    foreach (Coord coord in coordListToEnter)
                    {
                        sb.Append("a" + coord.Lat + " " + coord.Lng);
                    }

                    retStr = tvItemService.IsPointTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotADecimalValue, retStr);

                    sb.Clear();
                    foreach (Coord coord in coordListToEnter)
                    {
                        sb.Append(coord.Lat + " a" + coord.Lng);
                    }

                    retStr = tvItemService.IsPointTextProperFormat(sb.ToString());
                    Assert.AreEqual(ServiceRes.MapInfoPointNotADecimalValue, retStr);
                }
            }
        }
        [TestMethod]
        public void TVItemService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";

                    TVItemModel tvItemModel = tvItemService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, tvItemModel.Error);
                }
            }
        }
        #endregion Testing Methods public Helper

        #region Testing Methods public More Info
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoInfrastructureDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.Infrastructure).FirstOrDefault();

                    TVItemMoreInfoInfrastructureModel tvItemMoreInfoInfrastructureModel = tvItemService.GetTVItemMoreInfoInfrastructureDB(tvItemModel.TVItemID);
                    Assert.IsNotNull(tvItemMoreInfoInfrastructureModel);
                    Assert.AreEqual("", tvItemMoreInfoInfrastructureModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoInfrastructureDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.Infrastructure).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemMoreInfoInfrastructureModel tvItemMoreInfoInfrastructureModel = tvItemService.GetTVItemMoreInfoInfrastructureDB(tvItemModel.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemMoreInfoInfrastructureModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoInfrastructureDB_PercFlowOfTotal_NotNull_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.Infrastructure).FirstOrDefault();
                    Assert.AreEqual("", tvItemModel.Error);

                    Infrastructure inf = (from c in tvItemService.db.Infrastructures
                                          where c.InfrastructureTVItemID == tvItemModel.TVItemID
                                          select c).FirstOrDefault<Infrastructure>();
                    Assert.IsNotNull(inf);

                    float PeakFlow_m3_day = randomService.RandomFloat(150.0f, 200.0f);
                    float AverageFlow_m3_day = randomService.RandomFloat(100.0f, 149.0f);
                    float PercFlow = randomService.RandomFloat(10.0f, 90.0f);

                    inf.PeakFlow_m3_day = PeakFlow_m3_day;
                    inf.AverageFlow_m3_day = AverageFlow_m3_day;
                    inf.PercFlowOfTotal = PercFlow;

                    tvItemService.db.SaveChanges();
                    Assert.AreEqual(PeakFlow_m3_day, inf.PeakFlow_m3_day);
                    Assert.AreEqual(PercFlow, inf.PercFlowOfTotal);
                    Assert.AreEqual(AverageFlow_m3_day, inf.AverageFlow_m3_day);

                    TVItemMoreInfoInfrastructureModel tvItemMoreInfoInfrastructureModel = tvItemService.GetTVItemMoreInfoInfrastructureDB(tvItemModel.TVItemID);
                    Assert.AreEqual("", tvItemMoreInfoInfrastructureModel.Error);
                    Assert.AreEqual(PeakFlow_m3_day, tvItemMoreInfoInfrastructureModel.PeakFlow_m3_day);
                    Assert.AreEqual(AverageFlow_m3_day, tvItemMoreInfoInfrastructureModel.AverageFlow_m3_day);
                    Assert.AreEqual(PercFlow, tvItemMoreInfoInfrastructureModel.PercOfTotalFlow);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoMikeScenarioDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MikeScenario).FirstOrDefault();

                    TVItemMoreInfoMikeScenarioModel tvItemMoreInfoMikeScenarioModel = tvItemService.GetTVItemMoreInfoMikeScenarioDB(tvItemModel.TVItemID);
                    Assert.IsNotNull(tvItemMoreInfoMikeScenarioModel);
                    Assert.AreEqual("", tvItemMoreInfoMikeScenarioModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoMikeScenarioDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MikeScenario).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemMoreInfoMikeScenarioModel tvItemMoreInfoMikeScenarioModel = tvItemService.GetTVItemMoreInfoMikeScenarioDB(tvItemModel.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemMoreInfoMikeScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoMunicipalityDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.Municipality).FirstOrDefault();

                    TVItemMoreInfoMunicipalityModel tvItemMoreInfoMunicipalityModel = tvItemService.GetTVItemMoreInfoMunicipalityDB(tvItemModel.TVItemID);
                    Assert.IsNotNull(tvItemMoreInfoMunicipalityModel);
                    Assert.AreEqual("", tvItemMoreInfoMunicipalityModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoMunicipalityDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.Municipality).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemMoreInfoMunicipalityModel tvItemMoreInfoMunicipalityModel = tvItemService.GetTVItemMoreInfoMunicipalityDB(tvItemModel.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemMoreInfoMunicipalityModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoPolSourceSiteDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.PolSourceSite).FirstOrDefault();

                    TVItemMoreInfoPolSourceSiteModel tvItemMoreInfoPolSourceSiteModel = tvItemService.GetTVItemMoreInfoPolSourceSiteDB(tvItemModel.TVItemID);
                    Assert.IsNotNull(tvItemMoreInfoPolSourceSiteModel);
                    Assert.AreEqual("", tvItemMoreInfoPolSourceSiteModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoPolSourceSiteDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.PolSourceSite).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemMoreInfoPolSourceSiteModel tvItemMoreInfoPolSourceSiteModel = tvItemService.GetTVItemMoreInfoPolSourceSiteDB(tvItemModel.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemMoreInfoPolSourceSiteModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoProvinceDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.Province).FirstOrDefault();

                    TVItemMoreInfoProvinceModel tvItemMoreInfoProvinceModel = tvItemService.GetTVItemMoreInfoProvinceDB(tvItemModel.TVItemID);
                    Assert.IsNotNull(tvItemMoreInfoProvinceModel);
                    Assert.AreEqual("", tvItemMoreInfoProvinceModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoProvinceDB_GetTVItemModelWithTVItemIDDB_Eror_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.Province).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemMoreInfoProvinceModel tvItemMoreInfoProvinceModel = tvItemService.GetTVItemMoreInfoProvinceDB(tvItemModel.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemMoreInfoProvinceModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoSectorDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.Sector).FirstOrDefault();

                    TVItemMoreInfoSectorModel tvItemMoreInfoSectorModel = tvItemService.GetTVItemMoreInfoSectorDB(tvItemModel.TVItemID);
                    Assert.IsNotNull(tvItemMoreInfoSectorModel);
                    Assert.AreEqual("", tvItemMoreInfoSectorModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoSectorDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.Sector).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemMoreInfoSectorModel tvItemMoreInfoSectorModel = tvItemService.GetTVItemMoreInfoSectorDB(tvItemModel.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemMoreInfoSectorModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoSubsectorDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.Subsector).FirstOrDefault();

                    TVItemMoreInfoSubsectorModel tvItemMoreInfoSubsectorModel = tvItemService.GetTVItemMoreInfoSubsectorDB(tvItemModel.TVItemID);
                    Assert.IsNotNull(tvItemMoreInfoSubsectorModel);
                    Assert.AreEqual("", tvItemMoreInfoSubsectorModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoSubsectorDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.Subsector).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemMoreInfoSubsectorModel tvItemMoreInfoSubsectorModel = tvItemService.GetTVItemMoreInfoSubsectorDB(tvItemModel.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemMoreInfoSubsectorModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoMWQMSiteDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MWQMSite).FirstOrDefault();

                    TVItemMoreInfoMWQMSiteModel tvItemMoreInfoMWQMSiteModel = tvItemService.GetTVItemMoreInfoMWQMSiteTVItemIDDB(tvItemModel.TVItemID, 30);
                    Assert.IsNotNull(tvItemMoreInfoMWQMSiteModel);
                    Assert.AreEqual("", tvItemMoreInfoMWQMSiteModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoMWQMSiteDB_Bouctouche_Harbour_Site_0001_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    float? SampCount = 30.0f;
                    int StatMaxYear = 2017;
                    int StatMinYear = 2012;
                    float? MinFC = 4.0f;
                    float? MaxFC = 350.0f;
                    float? GeoMean = 39.90702f;
                    float? Median = 49;
                    float? P90 = 153.1126f;
                    float? PercOver43 = 53.3333321f;
                    float? PercOver260 = 6.66666651f;
                    string Coloring = "failed";
                    string Letter = "F";
                    int MWQMSampleCount = 83;
                    MWQMSiteLatestClassificationEnum MWQMSiteLatestClassification = MWQMSiteLatestClassificationEnum.Restricted;
                    int SampMaxYear = 2017;
                    int SampMinYear = 1985;

                    int TVItemID = 7460; //  NB-06-020-002 (Bouctouche River AND Harbour) site 0001
                    // should add all year automatically and do calculations with 1.9 if MPN == 1
                    TVItemMoreInfoMWQMSiteModel tvItemMoreInfoMWQMSiteModel = tvItemService.GetTVItemMoreInfoMWQMSiteTVItemIDDB(TVItemID, 30);
                    Assert.IsNotNull(tvItemMoreInfoMWQMSiteModel);
                    Assert.AreEqual("", tvItemMoreInfoMWQMSiteModel.Error);
                    Assert.AreEqual(SampCount, tvItemMoreInfoMWQMSiteModel.SampCount);
                    Assert.AreEqual(StatMaxYear, tvItemMoreInfoMWQMSiteModel.StatMaxYear);
                    Assert.AreEqual(StatMinYear, tvItemMoreInfoMWQMSiteModel.StatMinYear);
                    Assert.AreEqual(MinFC, tvItemMoreInfoMWQMSiteModel.MinFC);
                    Assert.AreEqual(MaxFC, tvItemMoreInfoMWQMSiteModel.MaxFC);
                    Assert.AreEqual(GeoMean, tvItemMoreInfoMWQMSiteModel.GeoMean);
                    Assert.AreEqual(Median, tvItemMoreInfoMWQMSiteModel.Median);
                    Assert.AreEqual(P90, tvItemMoreInfoMWQMSiteModel.P90);
                    Assert.AreEqual(PercOver43, tvItemMoreInfoMWQMSiteModel.PercOver43);
                    Assert.AreEqual(PercOver260, tvItemMoreInfoMWQMSiteModel.PercOver260);
                    Assert.AreEqual(Coloring, tvItemMoreInfoMWQMSiteModel.Coloring);
                    Assert.AreEqual(Letter, tvItemMoreInfoMWQMSiteModel.Letter);
                    Assert.AreEqual(MWQMSampleCount, tvItemMoreInfoMWQMSiteModel.MWQMSampleCount);
                    Assert.AreEqual(MWQMSiteLatestClassificationEnum.Restricted, tvItemMoreInfoMWQMSiteModel.MWQMSiteLatestClassification);
                    Assert.AreEqual(SampMaxYear, tvItemMoreInfoMWQMSiteModel.SampMaxYear);
                    Assert.AreEqual(SampMinYear, tvItemMoreInfoMWQMSiteModel.SampMinYear);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoMWQMSiteDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = tvItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MWQMSite).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemMoreInfoMWQMSiteModel tvItemMoreInfoMWQMSiteModel = tvItemService.GetTVItemMoreInfoMWQMSiteTVItemIDDB(tvItemModel.TVItemID, 30);
                        Assert.AreEqual(ErrorText, tvItemMoreInfoMWQMSiteModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoMWQMSiteDB_SampleCount_LessThan10_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int TVItemID = (from t in tvItemService.db.TVItems
                                    let sampleCount = (from s in tvItemService.db.MWQMSamples where s.MWQMSiteTVItemID == t.TVItemID select s).Count()
                                    where sampleCount < 10
                                    && sampleCount > 3
                                    && t.TVType == (int)TVTypeEnum.MWQMSite
                                    select t.TVItemID).FirstOrDefault<int>();
                    Assert.IsTrue(TVItemID > 0);

                    TVItemModel tvItemModel = tvItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemMoreInfoMWQMSiteModel tvItemMoreInfoMWQMSiteModel = tvItemService.GetTVItemMoreInfoMWQMSiteTVItemIDDB(tvItemModel.TVItemID, 30);
                    Assert.AreEqual("", tvItemMoreInfoMWQMSiteModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoMWQMSiteDB_SampleCount_Between10And30_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int TVItemID = (from t in tvItemService.db.TVItems
                                    let sampleCount = (from s in tvItemService.db.MWQMSamples where s.MWQMSiteTVItemID == t.TVItemID select s).Count()
                                    where sampleCount < 30
                                    && sampleCount > 10
                                    && t.TVType == (int)TVTypeEnum.MWQMSite
                                    select t.TVItemID).FirstOrDefault<int>();
                    Assert.IsTrue(TVItemID > 0);

                    TVItemModel tvItemModel = tvItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemMoreInfoMWQMSiteModel tvItemMoreInfoMWQMSiteModel = tvItemService.GetTVItemMoreInfoMWQMSiteTVItemIDDB(tvItemModel.TVItemID, 30);
                    Assert.AreEqual("", tvItemMoreInfoMWQMSiteModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_GetTVItemMoreInfoMWQMSiteDB_SampleCount_MoreThan30_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int TVItemID = (from t in tvItemService.db.TVItems
                                    let sampleCount = (from s in tvItemService.db.MWQMSamples where s.MWQMSiteTVItemID == t.TVItemID select s).Count()
                                    where sampleCount > 30
                                    && t.TVType == (int)TVTypeEnum.MWQMSite
                                    select t.TVItemID).FirstOrDefault<int>();
                    Assert.IsTrue(TVItemID > 0);

                    TVItemModel tvItemModel = tvItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemMoreInfoMWQMSiteModel tvItemMoreInfoMWQMSiteModel = tvItemService.GetTVItemMoreInfoMWQMSiteTVItemIDDB(tvItemModel.TVItemID, 30);
                    Assert.AreEqual("", tvItemMoreInfoMWQMSiteModel.Error);
                }
            }
        }
        #endregion Testing Methods public More info

        #region Testing Methods public Stat
        [TestMethod]
        public void TVItemService_GeometricMean_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                double geometricMean = tvItemService.GeometricMean(StatData);

                Assert.AreEqual((double)13.747842348, geometricMean, 0.0001);
            }
        }
        [TestMethod]
        public void TVItemService_GetStandardDeviation_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                double standardDeviation = tvItemService.GetStandardDeviation(StatData);

                Assert.AreEqual((double)430.115168988, standardDeviation, 0.0001);
            }
        }
        [TestMethod]
        public void TVItemService_GetMedian_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                double median = tvItemService.GetMedian(StatData);

                Assert.AreEqual(7.5, median);

                median = tvItemService.GetMedian(null);

                Assert.AreEqual(0.0f, median);

            }
        }
        [TestMethod]
        public void TVItemService_GetP90_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                double p90 = tvItemService.GetP90(StatDataP90);

                Assert.AreEqual((double)300.3727, p90, 0.0001);
            }
        }
        #endregion Testing Methods public Stat

        #region Testing Methods public Post
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Good_Add_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();
                    int ParentTVItemID = int.Parse(fc["ParentTVItemID"]);
                    string TVText = fc["TVText"];

                    TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelRet = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(ParentTVItemID, TVText, TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelRet.Error);
                    Assert.AreEqual(TVText, tvItemModel.TVText);
                    Assert.AreEqual(ParentTVItemID, tvItemModel.ParentID);
                    Assert.AreEqual(TVTypeEnum.Country, tvItemModel.TVType);

                    List<MapInfoModel> mapInfoModelList = mapInfoService.GetMapInfoModelListWithTVItemIDDB(tvItemModelRet.TVItemID);
                    Assert.AreEqual(3, mapInfoModelList.Count());
                    Assert.AreEqual(3, mapInfoModelList.Where(c => c.TVType == TVTypeEnum.Country).Count());
                    Assert.AreEqual(1, mapInfoModelList.Where(c => c.MapInfoDrawType == MapInfoDrawTypeEnum.Point).Count());
                    Assert.AreEqual(1, mapInfoModelList.Where(c => c.MapInfoDrawType == MapInfoDrawTypeEnum.Polyline).Count());
                    Assert.AreEqual(1, mapInfoModelList.Where(c => c.MapInfoDrawType == MapInfoDrawTypeEnum.Polygon).Count());
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_ParentTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();
                    fc["ParentTVItemID"] = "0";

                    TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID), tvItemModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_TVType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();
                    fc["TVType"] = "0";

                    TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVType), tvItemModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_TVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();
                    fc["TVText"] = "";

                    TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), tvItemModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_MapInfoPoint_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();
                    fc["MapInfoPoint"] = "";

                    TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoPoint), tvItemModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_IsMapInfoPointTextProperFormat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.IsMapInfoPointTextProperFormatString = (a) =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_GetCoordFromText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetCoordFromTextString = (a) =>
                        {
                            return new List<Coord>();
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ServiceRes.MapInfoPointNotWellFormedShouldHave1Point, tvItemModel.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_IsMapInfoPolylineTextProperFormat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.IsMapInfoPolylineTextProperFormatString = (a) =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_GetCoordFromText2_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimTVItemService.GetCoordFromTextString = (a) =>
                        {
                            count += 1;
                            if (count == 1)
                            {
                                return new List<Coord>()
                                {
                                    new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 }
                                };
                            }
                            return new List<Coord>();
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ServiceRes.MapInfoPointNotWellFormedShouldHaveMoreThan1Point, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_IsMapInfoPolygonTextProperFormat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.IsMapInfoPolygonTextProperFormatString = (a) =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_GetCoordFromText3_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimTVItemService.GetCoordFromTextString = (a) =>
                        {
                            count += 1;
                            if (count == 1)
                            {
                                return new List<Coord>()
                                {
                                    new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 }
                                };
                            }
                            if (count == 2)
                            {
                                return new List<Coord>()
                                {
                                    new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                                    new Coord() { Lat = 45.2f, Lng = -66.2f, Ordinal = 1 }
                                };
                            }
                            return new List<Coord>();
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ServiceRes.MapInfoPointNotWellFormedShouldHaveMoreThan2Points, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_CreateMapInfoObjectDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.CreateMapInfoObjectDBListOfCoordMapInfoDrawTypeEnumTVTypeEnumInt32 = (a, b, c, d) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_CreateMapInfoObjectDB2_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimTVItemService.CreateMapInfoObjectDBListOfCoordMapInfoDrawTypeEnumTVTypeEnumInt32 = (a, b, c, d) =>
                        {
                            count += 1;
                            if (count == 1)
                            {
                                return new MapInfoModel();
                            }
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Add_CreateMapInfoObjectDB3_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForAdd();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimTVItemService.CreateMapInfoObjectDBListOfCoordMapInfoDrawTypeEnumTVTypeEnumInt32 = (a, b, c, d) =>
                        {
                            count += 1;
                            if (count == 1)
                            {
                                return new MapInfoModel();
                            }
                            if (count == 2)
                            {
                                return new MapInfoModel();
                            }
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Good_Modify_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForModify();
                    int ParentTVItemID = int.Parse(fc["ParentTVItemID"]);
                    int TVItemID = int.Parse(fc["TVItemID"]);
                    string TVText = fc["TVText"];

                    TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelRet = tvItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
                    Assert.AreEqual("", tvItemModelRet.Error);
                    Assert.AreEqual(TVText, tvItemModel.TVText);
                    Assert.AreEqual(ParentTVItemID, tvItemModel.ParentID);
                    Assert.AreEqual(TVTypeEnum.Country, tvItemModel.TVType);

                    List<MapInfoModel> mapInfoModelList = mapInfoService.GetMapInfoModelListWithTVItemIDDB(tvItemModelRet.TVItemID);
                    Assert.AreEqual(3, mapInfoModelList.Count());
                    Assert.AreEqual(3, mapInfoModelList.Where(c => c.TVType == TVTypeEnum.Country).Count());
                    Assert.AreEqual(1, mapInfoModelList.Where(c => c.MapInfoDrawType == MapInfoDrawTypeEnum.Point).Count());
                    Assert.AreEqual(1, mapInfoModelList.Where(c => c.MapInfoDrawType == MapInfoDrawTypeEnum.Polyline).Count());
                    Assert.AreEqual(1, mapInfoModelList.Where(c => c.MapInfoDrawType == MapInfoDrawTypeEnum.Polygon).Count());
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Modify_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForModify();
                    int ParentTVItemID = int.Parse(fc["ParentTVItemID"]);
                    int TVItemID = int.Parse(fc["TVItemID"]);
                    string TVText = fc["TVText"];

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Modify_PostUpdateTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForModify();
                    int ParentTVItemID = int.Parse(fc["ParentTVItemID"]);
                    int TVItemID = int.Parse(fc["TVItemID"]);
                    string TVText = fc["TVText"];

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.PostUpdateTVItemDBTVItemModel = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddOrModifyTVItemDB_Modify_PostDeleteMapInfoWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyTVItemDBFormCollectionForModify();
                    int ParentTVItemID = int.Parse(fc["ParentTVItemID"]);
                    int TVItemID = int.Parse(fc["TVItemID"]);
                    string TVText = fc["TVText"];

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.PostDeleteMapInfoWithTVItemIDDBInt32 = (a) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostAddOrModifyTVItemDB(fc);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddUpdateDeleteRootTVItemDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // only do if DB Empty
                int CountTVItem = tvItemService.GetTVItemModelCountDB();

                if (CountTVItem == 0)
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        TVItemModel tvItemModelRet = AddTestTVItemRoot();
                        Assert.IsNotNull(tvItemModelRet);
                        Assert.AreEqual(1, tvItemModelRet.TVItemID);
                        Assert.AreEqual(0, tvItemModelRet.TVLevel);
                        Assert.AreEqual("p1", tvItemModelRet.TVPath);
                        Assert.AreEqual(1, tvItemModelRet.ParentID);
                        Assert.AreEqual(true, tvItemModelRet.IsActive);
                    }

                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddRootTVItemDB_GetTVItemModelCountDB_bigger_0_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // only do if DB Empty
                int CountTVItem = tvItemService.GetTVItemModelCountDB();

                if (CountTVItem == 0)
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        using (ShimsContext.Create())
                        {
                            SetupShim();
                            shimTVItemService.GetTVItemModelCountDB = () =>
                            {
                                return 1;
                            };

                            TVItemModel tvItemModelRet = AddTestTVItemRoot();

                            Assert.AreEqual(ServiceRes.TVItemRootShouldBeTheFirstOneAdded, tvItemModelRet.Error);
                        }
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddRootTVItemDB_GetRootTVItemModelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // only do if DB Empty
                int CountTVItem = tvItemService.GetTVItemModelCountDB();

                if (CountTVItem == 0)
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimTVItemService.GetRootTVItemModelDB = () =>
                            {
                                return new TVItemModel() { Error = ErrorText };
                            };

                            TVItemModel tvItemModelRet = AddTestTVItemRoot();

                            Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                        }
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddRootTVItemDB_FillTVItemModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // only do if DB Empty
                int CountTVItem = tvItemService.GetTVItemModelCountDB();

                if (CountTVItem == 0)
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimTVItemService.FillTVItemTVItemTVItemModelContactOK = (a, b, c) =>
                            {
                                return ErrorText;
                            };

                            TVItemModel tvItemModelRet = AddTestTVItemRoot();

                            Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                        }
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddRootTVItemDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // only do if DB Empty
                int CountTVItem = tvItemService.GetTVItemModelCountDB();

                if (CountTVItem == 0)
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimTVItemService.DoAddChanges = () =>
                            {
                                return ErrorText;
                            };

                            TVItemModel tvItemModelRet = AddTestTVItemRoot();

                            Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                        }
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddRootTVItemDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // only do if DB Empty
                int CountTVItem = tvItemService.GetTVItemModelCountDB();

                if (CountTVItem == 0)
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        using (ShimsContext.Create())
                        {
                            //string ErrorText = "ErrorText";
                            SetupShim();
                            shimTVItemService.FillTVItemTVItemTVItemModelContactOK = (a, b, c) =>
                            {
                                return "";
                            };

                            TVItemModel tvItemModelRet = AddTestTVItemRoot();

                            Assert.IsTrue(tvItemModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                        }
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddRootTVItemDB_PostAddAppTaskLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // only do if DB Empty
                int CountTVItem = tvItemService.GetTVItemModelCountDB();

                if (CountTVItem == 0)
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimTVItemLanguageService.PostAddTVItemLanguageDBTVItemLanguageModel = (a) =>
                            {
                                return new TVItemLanguageModel() { Error = ErrorText };
                            };

                            TVItemModel tvItemModelRet = AddTestTVItemRoot();

                            Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                        }
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddUpdateDeleteChildTVItemDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Province);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParent, TVTypeEnum.Municipality);

                    TVItemModel tvItemModelRet2 = UpdateTVItemModel(tvItemModelRet, tvItemModelParent, tvItemModelRet.TVType);

                    TVItemModel tvItemModelRet3 = tvItemService.PostDeleteTVItemWithTVItemIDDB(tvItemModelRet.TVItemID);
                    Assert.AreEqual("", tvItemModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildTVItemDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildTVItemDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildTVItemDB_GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel();
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVText), tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildTVItemDB_FillTVItem_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.FillTVItemTVItemTVItemModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildTVItemDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildTVItemDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildTVItemDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.FillTVItemTVItemTVItemModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.IsTrue(tvItemModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildTVItemDB_PostAddAppTaskLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.PostAddTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotAddError_, ErrorText), tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildContactTVItemDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildContactTVItemDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildContactTVItemDB_GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel();
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVText), tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildContactTVItemDB_FillTVItem_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.FillTVItemTVItemTVItemModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildContactTVItemDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildContactTVItemDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildContactTVItemDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.FillTVItemTVItemTVItemModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.IsTrue(tvItemModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildContactTVItemDB_PostAddAppTaskLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.PostAddTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotAddError_, ErrorText), tvItemModelRet.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostDeleteTVItemWithTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                    Assert.IsTrue(tvItemModelRet.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemModel tvItemModelRet2 = tvItemService.PostDeleteTVItemWithTVItemIDDB(tvItemModelRet.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemModelRet2.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostDeleteTVItemWithTVItemIDDB_GetTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                    Assert.IsTrue(tvItemModelRet.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TVItemModel tvItemModelRet2 = tvItemService.PostDeleteTVItemWithTVItemIDDB(tvItemModelRet.TVItemID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVItem), tvItemModelRet2.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostDeleteTVItemWithTVItemIDDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                    Assert.IsTrue(tvItemModelRet.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModelRet2 = tvItemService.PostDeleteTVItemWithTVItemIDDB(tvItemModelRet.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemModelRet2.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostMoveTVItemUnderAnotherTVItemDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche is under NB-06-020-002
                    TVItemModel tvItemModelBouct = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouct.Error);

                    string OldTVPathBouct = tvItemModelBouct.TVPath;

                    // Moving under Cocagne NB-06-020-003
                    TVItemModel tvItemModelUnder = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-003", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelUnder.Error);

                    string OldTVPathUnder = tvItemModelUnder.TVPath;

                    TVItemModel tvItemModel = tvItemService.PostMoveTVItemUnderAnotherTVItemDB(tvItemModelBouct.TVItemID, tvItemModelUnder.TVItemID);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelBouct2 = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouct.Error);
                    Assert.AreEqual(tvItemModelUnder.TVItemID, tvItemModelBouct2.ParentID);
                    Assert.AreEqual(tvItemModelUnder.TVPath + "p" + tvItemModelBouct.TVItemID, tvItemModelBouct2.TVPath);

                    TVItemModel tvItemModelFirstInf = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelBouct2.TVItemID, TVTypeEnum.Infrastructure).FirstOrDefault();
                    Assert.AreEqual(tvItemModelBouct2.TVPath + "p" + tvItemModelFirstInf.TVItemID, tvItemModelFirstInf.TVPath);
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostMoveTVItemUnderAnotherTVItemDB_With_TVType_Infrastructure_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche is under NB-06-020-002
                    TVItemModel tvItemModelBouct = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouct.Error);

                    TVItemModel tvItemModelBouctInf = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelBouct.TVItemID, TVTypeEnum.Infrastructure).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelBouctInf.Error);

                    string OldTVPathBouctInf = tvItemModelBouct.TVPath;

                    // Moving under Richibucto
                    TVItemModel tvItemModelRichibucto = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Richibucto", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelRichibucto.Error);

                    string OldTVPathUnder = tvItemModelRichibucto.TVPath;


                    TVItemModel tvItemModel = tvItemService.PostMoveTVItemUnderAnotherTVItemDB(tvItemModelBouctInf.TVItemID, tvItemModelRichibucto.TVItemID);
                    Assert.AreEqual("", tvItemModel.Error);

                    List<TVItemLink> tvItemLinkList = tvItemService._TVItemLinkService.GetTVItemLinkListWithFromTVItemIDDB(tvItemModelBouctInf.TVItemID);
                    Assert.AreEqual(0, tvItemLinkList.Count);

                    tvItemLinkList = tvItemService._TVItemLinkService.GetTVItemLinkListWithToTVItemIDDB(tvItemModelBouctInf.TVItemID);
                    Assert.AreEqual(0, tvItemLinkList.Count);
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostMoveTVItemUnderAnotherTVItemDB_TVItemIDToMove_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche is under NB-06-020-002
                    TVItemModel tvItemModelBouct = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouct.Error);

                    string OldTVPathBouct = tvItemModelBouct.TVPath;

                    // Moving under Cocagne NB-06-020-003
                    TVItemModel tvItemModelUnder = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-003", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelUnder.Error);

                    string OldTVPathUnder = tvItemModelUnder.TVPath;

                    int TVItemIDToMove = 0;
                    TVItemModel tvItemModel = tvItemService.PostMoveTVItemUnderAnotherTVItemDB(TVItemIDToMove, tvItemModelUnder.TVItemID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemIDToMove), tvItemModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostMoveTVItemUnderAnotherTVItemDB_TVItemIDUnder_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche is under NB-06-020-002
                    TVItemModel tvItemModelBouct = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouct.Error);

                    string OldTVPathBouct = tvItemModelBouct.TVPath;

                    // Moving under Cocagne NB-06-020-003
                    TVItemModel tvItemModelUnder = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-003", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelUnder.Error);

                    string OldTVPathUnder = tvItemModelUnder.TVPath;

                    int TVItemIDUnder = 0;
                    TVItemModel tvItemModel = tvItemService.PostMoveTVItemUnderAnotherTVItemDB(tvItemModelBouct.TVItemID, TVItemIDUnder);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemIDUnder), tvItemModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostMoveTVItemUnderAnotherTVItemDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche is under NB-06-020-002
                    TVItemModel tvItemModelBouct = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouct.Error);

                    string OldTVPathBouct = tvItemModelBouct.TVPath;

                    // Moving under Cocagne NB-06-020-003
                    TVItemModel tvItemModelUnder = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-003", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelUnder.Error);

                    string OldTVPathUnder = tvItemModelUnder.TVPath;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostMoveTVItemUnderAnotherTVItemDB(tvItemModelBouct.TVItemID, tvItemModelUnder.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostMoveTVItemUnderAnotherTVItemDB_GetTVItemModelWithTVItemIDDB2_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche is under NB-06-020-002
                    TVItemModel tvItemModelBouct = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouct.Error);

                    string OldTVPathBouct = tvItemModelBouct.TVPath;

                    // Moving under Cocagne NB-06-020-003
                    TVItemModel tvItemModelUnder = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-003", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelUnder.Error);

                    string OldTVPathUnder = tvItemModelUnder.TVPath;

                    int count = 0;
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            count += 1;
                            if (count == 1)
                            {
                                return tvItemModelBouct;
                            }
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostMoveTVItemUnderAnotherTVItemDB(tvItemModelBouct.TVItemID, tvItemModelUnder.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostMoveTVItemUnderAnotherTVItemDB_GetTVItemModelWithTVItemIDDB3_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche is under NB-06-020-002
                    TVItemModel tvItemModelBouct = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouct.Error);

                    string OldTVPathBouct = tvItemModelBouct.TVPath;

                    // Moving under Cocagne NB-06-020-003
                    TVItemModel tvItemModelUnder = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-003", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelUnder.Error);

                    string OldTVPathUnder = tvItemModelUnder.TVPath;

                    int count = 0;
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            count += 1;
                            if (count == 1 || count == 2)
                            {
                                return tvItemModelBouct;
                            }
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostMoveTVItemUnderAnotherTVItemDB(tvItemModelBouct.TVItemID, tvItemModelUnder.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostMoveTVItemUnderAnotherTVItemDB_PostUpdateTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche is under NB-06-020-002
                    TVItemModel tvItemModelBouct = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouct.Error);

                    string OldTVPathBouct = tvItemModelBouct.TVPath;

                    // Moving under Cocagne NB-06-020-003
                    TVItemModel tvItemModelUnder = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-003", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelUnder.Error);

                    string OldTVPathUnder = tvItemModelUnder.TVPath;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.PostUpdateTVItemDBTVItemModel = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostMoveTVItemUnderAnotherTVItemDB(tvItemModelBouct.TVItemID, tvItemModelUnder.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostMoveTVItemUnderAnotherTVItemDB_PostDeleteTVItemLinkWithFromTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche is under NB-06-020-002
                    TVItemModel tvItemModelBouct = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouct.Error);

                    TVItemModel tvItemModelBouctInf = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelBouct.TVItemID, TVTypeEnum.Infrastructure).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelBouctInf.Error);

                    string OldTVPathBouctInf = tvItemModelBouct.TVPath;

                    // Moving under Richibucto
                    TVItemModel tvItemModelRichibucto = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Richibucto", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelRichibucto.Error);

                    string OldTVPathUnder = tvItemModelRichibucto.TVPath;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostMoveTVItemUnderAnotherTVItemDB(tvItemModelBouctInf.TVItemID, tvItemModelRichibucto.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostMoveTVItemUnderAnotherTVItemDB_PostDeleteTVItemLinkWithToTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche is under NB-06-020-002
                    TVItemModel tvItemModelBouct = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouct.Error);

                    TVItemModel tvItemModelBouctInf = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelBouct.TVItemID, TVTypeEnum.Infrastructure).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelBouctInf.Error);

                    string OldTVPathBouctInf = tvItemModelBouct.TVPath;

                    // Moving under Richibucto
                    TVItemModel tvItemModelRichibucto = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Richibucto", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelRichibucto.Error);

                    string OldTVPathUnder = tvItemModelRichibucto.TVPath;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.PostDeleteTVItemLinkWithToTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = tvItemService.PostMoveTVItemUnderAnotherTVItemDB(tvItemModelBouctInf.TVItemID, tvItemModelRichibucto.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostMoveTVItemUnderAnotherTVItemDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche is under NB-06-020-002
                    TVItemModel tvItemModelBouct = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouct.Error);

                    string OldTVPathBouct = tvItemModelBouct.TVPath;

                    // Moving under Cocagne NB-06-020-003
                    TVItemModel tvItemModelUnder = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-003", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelUnder.Error);

                    string OldTVPathUnder = tvItemModelUnder.TVPath;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModel = tvItemService.PostMoveTVItemUnderAnotherTVItemDB(tvItemModelBouct.TVItemID, tvItemModelUnder.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostUpdateTVItemDB_TVItemModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                    Assert.IsTrue(tvItemModelRet.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.TVItemModelOKTVItemModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModel = UpdateTVItemModel(tvItemModelRet, tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostUpdateTVItemDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                    Assert.IsTrue(tvItemModelRet.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = UpdateTVItemModel(tvItemModelRet, tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostUpdateTVItemDB_GetTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                    Assert.IsTrue(tvItemModelRet.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TVItemModel tvItemModel = UpdateTVItemModel(tvItemModelRet, tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVItem), tvItemModel.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostUpdateTVItemDB_GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                    Assert.IsTrue(tvItemModelRet.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel();
                        };
                        shimTVItemService.GetIsItSameObjectTVItemModelTVItemModel = (a, b) =>
                        {
                            return false;
                        };

                        TVItemModel tvItemModel = UpdateTVItemModel(tvItemModelRet, tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItem), tvItemModel.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostUpdateTVItemDB_FillTVItem_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);

                    FillTVItemModelUpdate(tvItemModelRet, tvItemModelRoot, TVTypeEnum.Country);
                    Assert.IsTrue(tvItemModelRet.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.FillTVItemTVItemTVItemModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModel = tvItemService.PostUpdateTVItemDB(tvItemModelRet);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostUpdateTVItemDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);

                    FillTVItemModelUpdate(tvItemModelRet, tvItemModelRoot, TVTypeEnum.Country);
                    Assert.IsTrue(tvItemModelRet.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModel = tvItemService.PostUpdateTVItemDB(tvItemModelRet);
                        Assert.AreEqual(ErrorText, tvItemModel.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostUpdateTVItemDB_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelRoot, TVTypeEnum.Country);
                    Assert.IsTrue(tvItemModelRet.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModel = UpdateTVItemModel(tvItemModelRet, tvItemModelRoot, TVTypeEnum.Country);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotAddError_, ErrorText), tvItemModel.Error);
                    }
                }

                break; // only do one language [en]
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildTVItem_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Province);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Municipality);
                    Assert.IsNotNull(tvItemModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, tvItemModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemService_PostAddChildTVItem_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParentNew = randomService.RandomTVItem(TVTypeEnum.Province);

                    TVItemModel tvItemModelRet = AddTestTVItemChild(tvItemModelParentNew, TVTypeEnum.Municipality);
                    Assert.IsNotNull(tvItemModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, tvItemModelRet.Error);

                }
            }
        }
        #endregion Testing Methods public Post

        #region Testing Methods private
        #endregion Testing Methods private

        #region Functions private
        private TVItemModel AddTestTVItemRoot()
        {
            FillTVItemModelRootNew(tvItemModelNew);

            TVItemModel tvItemModelRet = tvItemService.PostAddRootTVItemDB();
            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
            {
                return tvItemModelRet;
            }

            tvItemModelNew.TVItemID = tvItemModelRet.TVItemID;

            Assert.IsNotNull(tvItemModelRet);
            CompareTVItemModels(tvItemModelNew, tvItemModelRet);

            return tvItemModelRet;
        }
        private TVItemModel AddTestTVItemChild(TVItemModel tvItemModelParent, TVTypeEnum tvType)
        {
            FillTVItemModelNew(tvItemModelNew, tvItemModelParent, tvType);

            string TVText = randomService.RandomString("", 20);

            TVItemModel tvItemModelRet = tvItemService.PostAddChildTVItemDB(tvItemModelParent.TVItemID, TVText, tvType);
            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
            {
                return tvItemModelRet;
            }

            tvItemModelNew.TVItemID = tvItemModelRet.TVItemID;
            tvItemModelNew.TVPath = tvItemModelParent.TVPath + "p" + tvItemModelRet.TVItemID;
            tvItemModelNew.TVLevel = tvItemModelRet.TVLevel;
            tvItemModelNew.ParentID = tvItemModelParent.TVItemID;

            Assert.IsNotNull(tvItemModelRet);
            CompareTVItemModels(tvItemModelNew, tvItemModelRet);

            return tvItemModelRet;
        }
        private TVItemModel UpdateTVItemModel(TVItemModel tvItemModelRet, TVItemModel tvItemModelParent, TVTypeEnum tvType)
        {
            FillTVItemModelUpdate(tvItemModelRet, tvItemModelParent, tvType);

            TVItemModel tvItemModelRet2 = tvItemService.PostUpdateTVItemDB(tvItemModelRet);
            if (!string.IsNullOrWhiteSpace(tvItemModelRet2.Error))
            {
                return tvItemModelRet2;
            }

            Assert.IsNotNull(tvItemModelRet2);
            CompareTVItemModels(tvItemModelRet, tvItemModelRet2);

            return tvItemModelRet2;
        }
        private void CompareTVItemModels(TVItemModel tvItemModel, TVItemModel tvItemModelRet)
        {
            Assert.AreEqual(tvItemModel.TVItemID, tvItemModelRet.TVItemID);
            Assert.AreEqual(tvItemModel.TVLevel, tvItemModelRet.TVLevel);
            Assert.AreEqual(tvItemModel.TVPath, tvItemModelRet.TVPath);
            Assert.AreEqual(tvItemModel.TVType, tvItemModelRet.TVType);
            Assert.AreEqual(tvItemModel.ParentID, tvItemModelRet.ParentID);
            Assert.AreEqual(tvItemModel.IsActive, tvItemModelRet.IsActive);

            foreach (LanguageEnum Lang in tvItemService.LanguageListAllowable)
            {
                if (Lang == tvItemService.LanguageRequest)
                {
                    TVItemLanguageModel tvItemLanguageModel = tvItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemModelRet.TVItemID, Lang);
                    Assert.AreEqual(tvItemModelRet.TVText, tvItemLanguageModel.TVText);
                }
            }
        }
        private FormCollection FillPostAddOrModifyTVItemDBFormCollectionForAdd()
        {
            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

            Assert.AreEqual("", tvItemModelRoot.Error);

            string TVText = "unique country";
            StringBuilder sbMapInfoPoint = new StringBuilder();
            StringBuilder sbMapInfoPolyline = new StringBuilder();
            StringBuilder sbMapInfoPolygon = new StringBuilder();

            List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                new Coord() { Lat = 45.2f, Lng = -66.2f, Ordinal = 1 },
                new Coord() { Lat = 45.3f, Lng = -66.3f, Ordinal = 2 },
            };

            sbMapInfoPoint.AppendLine(coordList[0].Lat + " " + coordList[0].Lng);

            foreach (Coord coord in coordList)
            {
                sbMapInfoPolyline.AppendLine(coord.Lat + " " + coord.Lng);
                sbMapInfoPolygon.AppendLine(coord.Lat + " " + coord.Lng);
            }

            FormCollection fc = new FormCollection();
            fc.Add("ParentTVItemID", tvItemModelRoot.TVItemID.ToString());
            fc.Add("TVItemID", "0");
            fc.Add("TVType", ((int)TVTypeEnum.Country).ToString());
            fc.Add("TVText", TVText);
            fc.Add("MapInfoPoint", sbMapInfoPoint.ToString());
            fc.Add("MapInfoPolyline", sbMapInfoPolyline.ToString());
            fc.Add("MapInfoPolygon", sbMapInfoPolygon.ToString());

            return fc;
        }
        private FormCollection FillPostAddOrModifyTVItemDBFormCollectionForModify()
        {
            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

            Assert.AreEqual("", tvItemModelRoot.Error);

            TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);

            Assert.AreEqual("", tvItemModelCanada.Error);

            MapInfoService mapInfoService = new MapInfoService(tvItemService.LanguageRequest, tvItemService.User);

            List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelCanada.TVItemID, TVTypeEnum.Country, MapInfoDrawTypeEnum.Point);

            Assert.AreEqual(1, mapInfoPointModelList.Count);

            Assert.AreEqual("", tvItemModelCanada.Error);

            string TVText = "unique country";
            StringBuilder sbMapInfoPoint = new StringBuilder();
            StringBuilder sbMapInfoPolyline = new StringBuilder();
            StringBuilder sbMapInfoPolygon = new StringBuilder();

            List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.1f, Lng = -66.1f, Ordinal = 0 },
                new Coord() { Lat = 45.2f, Lng = -66.2f, Ordinal = 1 },
                new Coord() { Lat = 45.3f, Lng = -66.3f, Ordinal = 2 },
            };

            sbMapInfoPoint.AppendLine(mapInfoPointModelList[0].Lat + " " + mapInfoPointModelList[0].Lng);

            foreach (Coord coord in coordList)
            {
                sbMapInfoPolyline.AppendLine(coord.Lat + " " + coord.Lng);
                sbMapInfoPolygon.AppendLine(coord.Lat + " " + coord.Lng);
            }

            FormCollection fc = new FormCollection();
            fc.Add("ParentTVItemID", tvItemModelRoot.TVItemID.ToString());
            fc.Add("TVItemID", tvItemModelCanada.TVItemID.ToString());
            fc.Add("TVType", ((int)tvItemModelCanada.TVType).ToString());
            fc.Add("TVText", TVText);
            fc.Add("MapInfoPoint", sbMapInfoPoint.ToString());
            fc.Add("MapInfoPolyline", sbMapInfoPolyline.ToString());
            fc.Add("MapInfoPolygon", sbMapInfoPolygon.ToString());

            return fc;
        }
        private void FillTVItemModelNew(TVItemModel tvItemModel, TVItemModel tvItemModelParent, TVTypeEnum tvType)
        {
            tvItemModel.TVLevel = tvItemModelParent.TVLevel + 1;
            tvItemModel.TVPath = tvItemModelParent.TVPath + "p0";
            tvItemModel.TVType = tvType;
            tvItemModel.ParentID = tvItemModelParent.TVItemID;
            tvItemModel.IsActive = true;

            Assert.IsTrue(tvItemModel.TVLevel == tvItemModelParent.TVLevel + 1);
            Assert.IsTrue(tvItemModel.TVPath == tvItemModelParent.TVPath + "p0");
            Assert.IsTrue(tvItemModel.TVType == tvType);
            Assert.IsTrue(tvItemModel.ParentID == tvItemModelParent.TVItemID);
            Assert.IsTrue(tvItemModel.IsActive == true);
        }
        private void FillTVItemModelRootNew(TVItemModel tvItemModel)
        {
            tvItemModel.TVLevel = 0;
            tvItemModel.TVPath = "p1";
            tvItemModel.TVType = TVTypeEnum.Root;
            tvItemModel.ParentID = 1;
            tvItemModel.IsActive = true;

            Assert.IsTrue(tvItemModel.TVLevel == 0);
            Assert.IsTrue(tvItemModel.TVPath == "p1");
            Assert.IsTrue(tvItemModel.TVType == TVTypeEnum.Root);
            Assert.IsTrue(tvItemModel.ParentID == 1);
            Assert.IsTrue(tvItemModel.IsActive == true);
        }
        private void FillTVItemModelUpdate(TVItemModel tvItemModel, TVItemModel tvItemModelParent, TVTypeEnum tvType)
        {
            tvItemModel.TVLevel = tvItemModelParent.TVLevel + 1;
            tvItemModel.TVPath = tvItemModelParent.TVPath + "p" + tvItemModel.TVItemID;
            tvItemModel.TVType = tvType;
            tvItemModel.ParentID = tvItemModelParent.TVItemID;
            tvItemModel.IsActive = true;

            Assert.IsTrue(tvItemModel.TVLevel == tvItemModelParent.TVLevel + 1);
            Assert.IsTrue(tvItemModel.TVPath == tvItemModelParent.TVPath + "p" + tvItemModel.TVItemID);
            Assert.IsTrue(tvItemModel.TVType == tvType);
            Assert.IsTrue(tvItemModel.ParentID == tvItemModelParent.TVItemID);
            Assert.IsTrue(tvItemModel.IsActive == true);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemLinkService = new TVItemLinkService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mapInfoService = new MapInfoService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvFileService = new TVFileService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemModelNew = new TVItemModel();
            tvItem = new TVItem();
            tvItemLinkServiceTest = new TVItemLinkServiceTest();
        }
        private void SetupShim()
        {
            shimTVItemService = new ShimTVItemService(tvItemService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(tvItemService._TVItemLanguageService);
            shimTVItemLinkService = new ShimTVItemLinkService(tvItemService._TVItemLinkService);
        }
        #endregion Functions private
    }
}


