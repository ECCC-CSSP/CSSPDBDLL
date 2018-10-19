using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPWebToolsDBDLL.Tests.SetupInfo;
using CSSPWebToolsDBDLL.Models;
using System.Security.Principal;
using CSSPWebToolsDBDLL.Services;
using CSSPWebToolsDBDLL.Services.Resources;
using System.Transactions;
using System.Linq;
using CSSPWebToolsDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for TVItemServiceTest
    /// </summary>
    [TestClass]
    public class TVItemStatServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private TVItemStatService tvItemStatService { get; set; }
        private RandomService randomService { get; set; }
        private TVItemService tvItemService { get; set; }
        private ShimTVItemStatService shimTVItemStatService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private InfrastructureService infrastructureService { get; set; }
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
        public TVItemStatServiceTest()
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
        public void TVItemStatService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(tvItemStatService);
                Assert.IsNotNull(tvItemStatService.db);
                Assert.IsNotNull(tvItemStatService.LanguageRequest);
                Assert.IsNotNull(tvItemStatService.User);
                Assert.AreEqual(user.Identity.Name, tvItemStatService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), tvItemStatService.LanguageRequest);
            }
        }
        [TestMethod]
        public void TVItemStatService_TVItemStatModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    #region Good
                    SetupTest(contactModelListGood[0], culture);
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);

                    TVItemStatModel tvItemStatModelNew = new TVItemStatModel();
                    #endregion Good

                    #region TVItemID
                    FillTVItemStatModel(tvItemStatModelNew, tvItemModelMunicipality, TVTypeEnum.Infrastructure);

                    string retStr = tvItemStatService.TVItemStatModelOK(tvItemStatModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemStatModel(tvItemStatModelNew, tvItemModelMunicipality, TVTypeEnum.Infrastructure);
                    tvItemStatModelNew.TVItemID = 0;

                    retStr = tvItemStatService.TVItemStatModelOK(tvItemStatModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID), retStr);

                    #endregion TVItemID

                    #region TVType
                    FillTVItemStatModel(tvItemStatModelNew, tvItemModelMunicipality, TVTypeEnum.Infrastructure);
                    tvItemStatModelNew.TVType = (TVTypeEnum)10000;

                    retStr = tvItemStatService.TVItemStatModelOK(tvItemStatModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVType), retStr);

                    FillTVItemStatModel(tvItemStatModelNew, tvItemModelMunicipality, TVTypeEnum.Infrastructure);
                    tvItemStatModelNew.TVType = TVTypeEnum.Country;

                    retStr = tvItemStatService.TVItemStatModelOK(tvItemStatModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion TVType
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_FillTVItemStat_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    TVItemStatModel tvItemStatModelNew = new TVItemStatModel();
                    TVItemStat tvItemStat = new TVItemStat();
                    FillTVItemStatModel(tvItemStatModelNew, tvItemModelMunicipality, TVTypeEnum.Infrastructure);

                    ContactOK contactOK = tvItemStatService.IsContactOK();

                    string retStr = tvItemStatService.FillTVItemStat(tvItemStat, tvItemStatModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, tvItemStat.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = tvItemStatService.FillTVItemStat(tvItemStat, tvItemStatModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, tvItemStat.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_Root_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Root);
                    Assert.AreEqual(26, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelRoot, ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_Area_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche Area NB-06
                    TVItemModel tvItemModelArea = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06", TVTypeEnum.Area);
                    Assert.AreEqual("", tvItemModelArea.Error);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Area);
                    Assert.AreEqual(21, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelArea, ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_Country_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Canada
                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Country);
                    Assert.AreEqual(23, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelCanada, ChildTVType);

                        if (ChildTVType != TVTypeEnum.Spill)
                        {
                            Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_Infrastructure_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche
                    TVItemModel tvItemModelBouctouche = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouctouche.Error);

                    List<TVItemModel> tvItemModelInfList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelBouctouche.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfList.Count > 0);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Infrastructure);
                    Assert.AreEqual(4, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelInfList[0], ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_BoxModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche
                    TVItemModel tvItemModelBouctouche = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouctouche.Error);

                    List<TVItemModel> tvItemModelInfList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelBouctouche.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfList.Count > 0);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Infrastructure);
                    Assert.AreEqual(4, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelInfList[0], ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_MikeScenario_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche
                    TVItemModel tvItemModelBouctouche = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouctouche.Error);

                    List<TVItemModel> tvItemModelMSList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelBouctouche.TVItemID, TVTypeEnum.MikeScenario);
                    Assert.IsTrue(tvItemModelMSList.Count > 0);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.MikeScenario);
                    Assert.AreEqual(3, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelMSList[0], ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_Municipality_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche
                    TVItemModel tvItemModelBouctouche = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouctouche.Error);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Municipality);
                    Assert.AreEqual(11, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelBouctouche, ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_MWQMSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020-002
                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    TVItemModel tvItemModelMWQMSite = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.MWQMSite).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelMWQMSite.Error);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.MWQMSite);
                    Assert.AreEqual(3, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelMWQMSite, ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_PolSourceSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020-002
                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    TVItemModel tvItemModelPolSourceSite = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.MWQMSite).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelPolSourceSite.Error);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.PolSourceSite);
                    Assert.AreEqual(2, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelPolSourceSite, ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_Province_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB
                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Province);
                    Assert.AreEqual(22, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelNB, ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_Sector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020
                    TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020", TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Sector);
                    Assert.AreEqual(20, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelSector, ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_Subsector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020-002
                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Subsector);
                    Assert.AreEqual(19, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelSubsector, ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_MWQMRun_Subsector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020-002
                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.MWQMRun);
                    Assert.AreEqual(3, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelSubsector, ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_MWQMRun_MWQMSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020-002
                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    TVItemModel tvItemModelMWQMSite = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelRoot.TVItemID, TVTypeEnum.MWQMSite).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelMWQMSite.Error);

                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.MWQMRun);
                    Assert.AreEqual(3, SubTVTypeList.Count);

                    foreach (TVTypeEnum ChildTVType in SubTVTypeList)
                    {
                        int childCount = tvItemStatService.GetChildCount(tvItemModelMWQMSite, ChildTVType);
                        Assert.IsTrue(childCount >= 0, "childCount == -1 for [" + ChildTVType.ToString() + "]");
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetChildCount_Default_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    int childCount = tvItemStatService.GetChildCount(tvItemModelRoot, TVTypeEnum.Passed);
                    Assert.AreEqual(-1, childCount);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_Root_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Root);
                    Assert.AreEqual(26, SubTVTypeList.Count);
                    Assert.AreEqual(TVTypeEnum.Address, SubTVTypeList[0]);
                    Assert.AreEqual(TVTypeEnum.Area, SubTVTypeList[1]);
                    Assert.AreEqual(TVTypeEnum.ClimateSite, SubTVTypeList[2]);
                    Assert.AreEqual(TVTypeEnum.Contact, SubTVTypeList[3]);
                    Assert.AreEqual(TVTypeEnum.Country, SubTVTypeList[4]);
                    Assert.AreEqual(TVTypeEnum.Email, SubTVTypeList[5]);
                    Assert.AreEqual(TVTypeEnum.File, SubTVTypeList[6]);
                    Assert.AreEqual(TVTypeEnum.TotalFile, SubTVTypeList[7]);
                    Assert.AreEqual(TVTypeEnum.HydrometricSite, SubTVTypeList[8]);
                    Assert.AreEqual(TVTypeEnum.Infrastructure, SubTVTypeList[9]);
                    Assert.AreEqual(TVTypeEnum.MikeScenario, SubTVTypeList[10]);
                    Assert.AreEqual(TVTypeEnum.Municipality, SubTVTypeList[11]);
                    Assert.AreEqual(TVTypeEnum.MWQMSite, SubTVTypeList[12]);
                    Assert.AreEqual(TVTypeEnum.MWQMRun, SubTVTypeList[13]);
                    Assert.AreEqual(TVTypeEnum.PolSourceSite, SubTVTypeList[14]);
                    Assert.AreEqual(TVTypeEnum.Province, SubTVTypeList[15]);
                    Assert.AreEqual(TVTypeEnum.Sector, SubTVTypeList[16]);
                    Assert.AreEqual(TVTypeEnum.Subsector, SubTVTypeList[17]);
                    Assert.AreEqual(TVTypeEnum.Tel, SubTVTypeList[18]);
                    Assert.AreEqual(TVTypeEnum.TideSite, SubTVTypeList[19]);
                    Assert.AreEqual(TVTypeEnum.MWQMSiteSample, SubTVTypeList[20]);
                    Assert.AreEqual(TVTypeEnum.WasteWaterTreatmentPlant, SubTVTypeList[21]);
                    Assert.AreEqual(TVTypeEnum.LiftStation, SubTVTypeList[22]);
                    Assert.AreEqual(TVTypeEnum.Spill, SubTVTypeList[23]);
                    Assert.AreEqual(TVTypeEnum.BoxModel, SubTVTypeList[24]);
                    Assert.AreEqual(TVTypeEnum.VisualPlumesScenario, SubTVTypeList[25]);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_Area_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Area);
                    Assert.AreEqual(21, SubTVTypeList.Count);
                    Assert.AreEqual(TVTypeEnum.Address, SubTVTypeList[0]);
                    Assert.AreEqual(TVTypeEnum.ClimateSite, SubTVTypeList[1]);
                    Assert.AreEqual(TVTypeEnum.File, SubTVTypeList[2]);
                    Assert.AreEqual(TVTypeEnum.TotalFile, SubTVTypeList[3]);
                    Assert.AreEqual(TVTypeEnum.HydrometricSite, SubTVTypeList[4]);
                    Assert.AreEqual(TVTypeEnum.Infrastructure, SubTVTypeList[5]);
                    Assert.AreEqual(TVTypeEnum.MikeScenario, SubTVTypeList[6]);
                    Assert.AreEqual(TVTypeEnum.Municipality, SubTVTypeList[7]);
                    Assert.AreEqual(TVTypeEnum.MWQMSite, SubTVTypeList[8]);
                    Assert.AreEqual(TVTypeEnum.MWQMRun, SubTVTypeList[9]);
                    Assert.AreEqual(TVTypeEnum.PolSourceSite, SubTVTypeList[10]);
                    Assert.AreEqual(TVTypeEnum.Sector, SubTVTypeList[11]);
                    Assert.AreEqual(TVTypeEnum.Subsector, SubTVTypeList[12]);
                    Assert.AreEqual(TVTypeEnum.TideSite, SubTVTypeList[13]);
                    Assert.AreEqual(TVTypeEnum.MWQMSiteSample, SubTVTypeList[14]);
                    Assert.AreEqual(TVTypeEnum.WasteWaterTreatmentPlant, SubTVTypeList[15]);
                    Assert.AreEqual(TVTypeEnum.LiftStation, SubTVTypeList[16]);
                    Assert.AreEqual(TVTypeEnum.Spill, SubTVTypeList[17]);
                    Assert.AreEqual(TVTypeEnum.BoxModel, SubTVTypeList[18]);
                    Assert.AreEqual(TVTypeEnum.VisualPlumesScenario, SubTVTypeList[19]);
                    Assert.AreEqual(TVTypeEnum.Contact, SubTVTypeList[20]);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_Country_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Country);
                    Assert.AreEqual(23, SubTVTypeList.Count);
                    Assert.AreEqual(TVTypeEnum.Area, SubTVTypeList[0]);
                    Assert.AreEqual(TVTypeEnum.ClimateSite, SubTVTypeList[1]);
                    Assert.AreEqual(TVTypeEnum.File, SubTVTypeList[2]);
                    Assert.AreEqual(TVTypeEnum.HydrometricSite, SubTVTypeList[3]);
                    Assert.AreEqual(TVTypeEnum.Infrastructure, SubTVTypeList[4]);
                    Assert.AreEqual(TVTypeEnum.MikeScenario, SubTVTypeList[5]);
                    Assert.AreEqual(TVTypeEnum.Municipality, SubTVTypeList[6]);
                    Assert.AreEqual(TVTypeEnum.MWQMSite, SubTVTypeList[7]);
                    Assert.AreEqual(TVTypeEnum.MWQMRun, SubTVTypeList[8]);
                    Assert.AreEqual(TVTypeEnum.PolSourceSite, SubTVTypeList[9]);
                    Assert.AreEqual(TVTypeEnum.Province, SubTVTypeList[10]);
                    Assert.AreEqual(TVTypeEnum.Sector, SubTVTypeList[11]);
                    Assert.AreEqual(TVTypeEnum.Subsector, SubTVTypeList[12]);
                    Assert.AreEqual(TVTypeEnum.TideSite, SubTVTypeList[13]);
                    Assert.AreEqual(TVTypeEnum.MWQMSiteSample, SubTVTypeList[14]);
                    Assert.AreEqual(TVTypeEnum.WasteWaterTreatmentPlant, SubTVTypeList[15]);
                    Assert.AreEqual(TVTypeEnum.LiftStation, SubTVTypeList[16]);
                    Assert.AreEqual(TVTypeEnum.Spill, SubTVTypeList[17]);
                    Assert.AreEqual(TVTypeEnum.BoxModel, SubTVTypeList[18]);
                    Assert.AreEqual(TVTypeEnum.VisualPlumesScenario, SubTVTypeList[19]);
                    Assert.AreEqual(TVTypeEnum.Address, SubTVTypeList[20]);
                    Assert.AreEqual(TVTypeEnum.TotalFile, SubTVTypeList[21]);
                    Assert.AreEqual(TVTypeEnum.Contact, SubTVTypeList[22]);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_Infrastructure_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Infrastructure);
                    Assert.AreEqual(4, SubTVTypeList.Count);
                    Assert.AreEqual(TVTypeEnum.File, SubTVTypeList[0]);
                    Assert.AreEqual(TVTypeEnum.Spill, SubTVTypeList[1]);
                    Assert.AreEqual(TVTypeEnum.BoxModel, SubTVTypeList[2]);
                    Assert.AreEqual(TVTypeEnum.VisualPlumesScenario, SubTVTypeList[3]);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_MikeScenario_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.MikeScenario);
                    Assert.AreEqual(3, SubTVTypeList.Count);
                    Assert.AreEqual(TVTypeEnum.File, SubTVTypeList[0]);
                    Assert.AreEqual(TVTypeEnum.TotalFile, SubTVTypeList[1]);
                    Assert.AreEqual(TVTypeEnum.MikeSource, SubTVTypeList[2]);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_Municipality_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Municipality);
                    Assert.AreEqual(11, SubTVTypeList.Count);
                    Assert.AreEqual(TVTypeEnum.Address, SubTVTypeList[0]);
                    Assert.AreEqual(TVTypeEnum.Contact, SubTVTypeList[1]);
                    Assert.AreEqual(TVTypeEnum.File, SubTVTypeList[2]);
                    Assert.AreEqual(TVTypeEnum.TotalFile, SubTVTypeList[3]);
                    Assert.AreEqual(TVTypeEnum.Infrastructure, SubTVTypeList[4]);
                    Assert.AreEqual(TVTypeEnum.MikeScenario, SubTVTypeList[5]);
                    Assert.AreEqual(TVTypeEnum.WasteWaterTreatmentPlant, SubTVTypeList[6]);
                    Assert.AreEqual(TVTypeEnum.LiftStation, SubTVTypeList[7]);
                    Assert.AreEqual(TVTypeEnum.Spill, SubTVTypeList[8]);
                    Assert.AreEqual(TVTypeEnum.BoxModel, SubTVTypeList[9]);
                    Assert.AreEqual(TVTypeEnum.VisualPlumesScenario, SubTVTypeList[10]);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_MWQMSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.MWQMSite);
                    Assert.AreEqual(3, SubTVTypeList.Count);
                    Assert.AreEqual(TVTypeEnum.File, SubTVTypeList[0]);
                    Assert.AreEqual(TVTypeEnum.MWQMSiteSample, SubTVTypeList[1]);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_PolSourceSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.PolSourceSite);
                    Assert.AreEqual(2, SubTVTypeList.Count);
                    Assert.AreEqual(TVTypeEnum.Address, SubTVTypeList[0]);
                    Assert.AreEqual(TVTypeEnum.File, SubTVTypeList[1]);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_Province_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Province);
                    Assert.AreEqual(22, SubTVTypeList.Count);
                    Assert.AreEqual(TVTypeEnum.Address, SubTVTypeList[0]);
                    Assert.AreEqual(TVTypeEnum.Area, SubTVTypeList[1]);
                    Assert.AreEqual(TVTypeEnum.ClimateSite, SubTVTypeList[2]);
                    Assert.AreEqual(TVTypeEnum.File, SubTVTypeList[3]);
                    Assert.AreEqual(TVTypeEnum.TotalFile, SubTVTypeList[4]);
                    Assert.AreEqual(TVTypeEnum.HydrometricSite, SubTVTypeList[5]);
                    Assert.AreEqual(TVTypeEnum.Infrastructure, SubTVTypeList[6]);
                    Assert.AreEqual(TVTypeEnum.MikeScenario, SubTVTypeList[7]);
                    Assert.AreEqual(TVTypeEnum.Municipality, SubTVTypeList[8]);
                    Assert.AreEqual(TVTypeEnum.MWQMSite, SubTVTypeList[9]);
                    Assert.AreEqual(TVTypeEnum.MWQMRun, SubTVTypeList[10]);
                    Assert.AreEqual(TVTypeEnum.PolSourceSite, SubTVTypeList[11]);
                    Assert.AreEqual(TVTypeEnum.Sector, SubTVTypeList[12]);
                    Assert.AreEqual(TVTypeEnum.Subsector, SubTVTypeList[13]);
                    Assert.AreEqual(TVTypeEnum.TideSite, SubTVTypeList[14]);
                    Assert.AreEqual(TVTypeEnum.MWQMSiteSample, SubTVTypeList[15]);
                    Assert.AreEqual(TVTypeEnum.WasteWaterTreatmentPlant, SubTVTypeList[16]);
                    Assert.AreEqual(TVTypeEnum.LiftStation, SubTVTypeList[17]);
                    Assert.AreEqual(TVTypeEnum.Spill, SubTVTypeList[18]);
                    Assert.AreEqual(TVTypeEnum.BoxModel, SubTVTypeList[19]);
                    Assert.AreEqual(TVTypeEnum.VisualPlumesScenario, SubTVTypeList[20]);
                    Assert.AreEqual(TVTypeEnum.Contact, SubTVTypeList[21]);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_Sector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Sector);
                    Assert.AreEqual(20, SubTVTypeList.Count);
                    Assert.AreEqual(TVTypeEnum.ClimateSite, SubTVTypeList[0]);
                    Assert.AreEqual(TVTypeEnum.File, SubTVTypeList[1]);
                    Assert.AreEqual(TVTypeEnum.HydrometricSite, SubTVTypeList[2]);
                    Assert.AreEqual(TVTypeEnum.Infrastructure, SubTVTypeList[3]);
                    Assert.AreEqual(TVTypeEnum.MikeScenario, SubTVTypeList[4]);
                    Assert.AreEqual(TVTypeEnum.Municipality, SubTVTypeList[5]);
                    Assert.AreEqual(TVTypeEnum.MWQMSite, SubTVTypeList[6]);
                    Assert.AreEqual(TVTypeEnum.MWQMRun, SubTVTypeList[7]);
                    Assert.AreEqual(TVTypeEnum.PolSourceSite, SubTVTypeList[8]);
                    Assert.AreEqual(TVTypeEnum.Subsector, SubTVTypeList[9]);
                    Assert.AreEqual(TVTypeEnum.TideSite, SubTVTypeList[10]);
                    Assert.AreEqual(TVTypeEnum.MWQMSiteSample, SubTVTypeList[11]);
                    Assert.AreEqual(TVTypeEnum.WasteWaterTreatmentPlant, SubTVTypeList[12]);
                    Assert.AreEqual(TVTypeEnum.LiftStation, SubTVTypeList[13]);
                    Assert.AreEqual(TVTypeEnum.Spill, SubTVTypeList[14]);
                    Assert.AreEqual(TVTypeEnum.BoxModel, SubTVTypeList[15]);
                    Assert.AreEqual(TVTypeEnum.VisualPlumesScenario, SubTVTypeList[16]);
                    Assert.AreEqual(TVTypeEnum.Address, SubTVTypeList[17]);
                    Assert.AreEqual(TVTypeEnum.Contact, SubTVTypeList[18]);
                    Assert.AreEqual(TVTypeEnum.TotalFile, SubTVTypeList[19]);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_Subsector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Subsector);
                    Assert.AreEqual(19, SubTVTypeList.Count);
                    Assert.AreEqual(TVTypeEnum.ClimateSite, SubTVTypeList[0]);
                    Assert.AreEqual(TVTypeEnum.File, SubTVTypeList[1]);
                    Assert.AreEqual(TVTypeEnum.HydrometricSite, SubTVTypeList[2]);
                    Assert.AreEqual(TVTypeEnum.Infrastructure, SubTVTypeList[3]);
                    Assert.AreEqual(TVTypeEnum.MikeScenario, SubTVTypeList[4]);
                    Assert.AreEqual(TVTypeEnum.Municipality, SubTVTypeList[5]);
                    Assert.AreEqual(TVTypeEnum.MWQMSite, SubTVTypeList[6]);
                    Assert.AreEqual(TVTypeEnum.MWQMRun, SubTVTypeList[7]);
                    Assert.AreEqual(TVTypeEnum.PolSourceSite, SubTVTypeList[8]);
                    Assert.AreEqual(TVTypeEnum.TideSite, SubTVTypeList[9]);
                    Assert.AreEqual(TVTypeEnum.MWQMSiteSample, SubTVTypeList[10]);
                    Assert.AreEqual(TVTypeEnum.WasteWaterTreatmentPlant, SubTVTypeList[11]);
                    Assert.AreEqual(TVTypeEnum.LiftStation, SubTVTypeList[12]);
                    Assert.AreEqual(TVTypeEnum.Spill, SubTVTypeList[13]);
                    Assert.AreEqual(TVTypeEnum.BoxModel, SubTVTypeList[14]);
                    Assert.AreEqual(TVTypeEnum.VisualPlumesScenario, SubTVTypeList[15]);
                    Assert.AreEqual(TVTypeEnum.Address, SubTVTypeList[16]);
                    Assert.AreEqual(TVTypeEnum.Contact, SubTVTypeList[17]);
                    Assert.AreEqual(TVTypeEnum.TotalFile, SubTVTypeList[18]);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_MWQMRun_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.MWQMRun);
                    Assert.AreEqual(3, SubTVTypeList.Count);
                    Assert.AreEqual(TVTypeEnum.File, SubTVTypeList[0]);
                    Assert.AreEqual(TVTypeEnum.MWQMSite, SubTVTypeList[1]);
                    Assert.AreEqual(TVTypeEnum.MWQMSiteSample, SubTVTypeList[2]);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetSubTVTypeForTVItemStat_Default_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVTypeEnum> SubTVTypeList = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Passed);
                    Assert.AreEqual(0, SubTVTypeList.Count);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetTVItemStatModelListWithTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    List<TVItemStatModel> tvItemStatModelList = tvItemStatService.GetTVItemStatModelListWithTVItemIDDB(tvItemStatModelRet.TVItemID);
                    Assert.IsTrue(tvItemStatModelList.Count > 0);
                    Assert.IsTrue(tvItemStatModelList.Where(c => c.TVItemID == tvItemStatModelRet.TVItemID && c.TVType == tvItemStatModelRet.TVType).Any());
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetTVItemStatModelWithTVItemIDAndTVTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    TVItemStatModel tvItemStatModelRet2 = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemStatModelRet.TVItemID, tvItemStatModelRet.TVType);
                    Assert.AreEqual(tvItemStatModelRet.TVItemID, tvItemStatModelRet2.TVItemID);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetTVItemStatModelWithTVItemIDAndTVTypeDB_TVItemID_584_TVType_MWQMRun_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(584, TVTypeEnum.MWQMRun);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetTVItemStatListWithTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    List<TVItemStat> tvItemStatList = tvItemStatService.GetTVItemStatListWithTVItemIDDB(tvItemStatModelRet.TVItemID);
                    Assert.IsTrue(tvItemStatList.Count > 0);
                    Assert.IsTrue(tvItemStatList.Where(c => c.TVItemID == tvItemStatModelRet.TVItemID && c.TVType == (int)tvItemStatModelRet.TVType).Any());
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_GetTVItemStatListWithTVItemIDAndTVTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    TVItemStat tvItemStatRet2 = tvItemStatService.GetTVItemStatWithTVItemIDAndTVTypeDB(tvItemStatModelRet.TVItemID, tvItemStatModelRet.TVType);
                    Assert.AreEqual(tvItemStatModelRet.TVItemID, tvItemStatRet2.TVItemID);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";

                    TVItemStatModel tvItemStatModel = tvItemStatService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, tvItemStatModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostAddTVItemStatDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.IsNotNull(tvItemStatModelRet);
                    Assert.IsTrue(tvItemStatModelRet.TVItemID > 0);
                    Assert.IsTrue(tvItemStatModelRet.TVType != TVTypeEnum.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostAddTVItemStatDB_TVItemStatModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    TVItemStatModel tvItemStatModelRet2 = tvItemStatService.PostDeleteTVItemStatWithTVItemIDDB(tvItemStatModelRet.TVItemID);
                    Assert.AreEqual("", tvItemStatModelRet2.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.TVItemStatModelOKTVItemStatModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVItemStatModel tvItemStatModelRet3 = tvItemStatService.PostAddTVItemStatDB(tvItemStatModelRet);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostAddTVItemStatDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        tvItemStatModelRet = tvItemStatService.PostAddTVItemStatDB(tvItemStatModelRet);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostAddTVItemStatDB_GetTVItemStatModelWithTVItemIDAndTVTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        // string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDBInt32TVTypeEnum = (a, b) =>
                        {
                            return new TVItemStatModel() { Error = "" };
                        };

                        tvItemStatModelRet = tvItemStatService.PostAddTVItemStatDB(tvItemStatModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItem), tvItemStatModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostAddTVItemStatDB_FillTVItemStat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.FillTVItemStatTVItemStatTVItemStatModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        tvItemStatModelRet.TVType = TVTypeEnum.PolSourceSite;

                        tvItemStatModelRet = tvItemStatService.PostAddTVItemStatDB(tvItemStatModelRet);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostAddTVItemStatDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        tvItemStatModelRet.TVType = TVTypeEnum.PolSourceSite;

                        tvItemStatModelRet = tvItemStatService.PostAddTVItemStatDB(tvItemStatModelRet);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostDeleteTVItemStatWithTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.IsNotNull(tvItemStatModelRet);
                    Assert.IsTrue(tvItemStatModelRet.TVItemID > 0);
                    Assert.IsTrue(tvItemStatModelRet.TVType != TVTypeEnum.Error);

                    TVItemStatModel tvItemStatModelRet2 = tvItemStatService.PostDeleteTVItemStatWithTVItemIDDB(tvItemStatModelRet.TVItemID);
                    Assert.AreEqual("", tvItemStatModelRet2.Error);

                    TVItemStatModel tvItemStatModelRet3 = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemStatModelRet.TVItemID, tvItemStatModelRet.TVType);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID + "," + ServiceRes.TVType, tvItemStatModelRet.TVItemID.ToString() + "," + tvItemStatModelRet.TVType.ToString()), tvItemStatModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostDeleteTVItemStatWithTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.IsNotNull("", tvItemStatModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemStatModel tvItemStatModelRet2 = tvItemStatService.PostDeleteTVItemStatWithTVItemIDDB(tvItemStatModelRet.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostDeleteTVItemStatWithTVItemIDDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.IsNotNull("", tvItemStatModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemStatModel tvItemStatModelRet2 = tvItemStatService.PostDeleteTVItemStatWithTVItemIDDB(tvItemStatModelRet.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostUpdateTVItemStatDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.IsNotNull(tvItemStatModelRet);
                    Assert.IsTrue(tvItemStatModelRet.TVItemID > 0);
                    Assert.IsTrue(tvItemStatModelRet.TVType != TVTypeEnum.Error);

                    tvItemStatModelRet.ChildCount = 983247;

                    TVItemStatModel tvItemStatModelRet2 = tvItemStatService.PostUpdateTVItemStatDB(tvItemStatModelRet);
                    Assert.AreEqual("", tvItemStatModelRet2.Error);

                    TVItemStatModel tvItemStatModelRet3 = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemStatModelRet.TVItemID, tvItemStatModelRet.TVType);
                    Assert.AreEqual("", tvItemStatModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostUpdateTVItemStatDB_TVItemStatModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.TVItemStatModelOKTVItemStatModel = (a) =>
                        {
                            return ErrorText;
                        };

                        tvItemStatModelRet.ChildCount = 983247;

                        TVItemStatModel tvItemStatModelRet2 = tvItemStatService.PostUpdateTVItemStatDB(tvItemStatModelRet);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostUpdateTVItemStatDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        tvItemStatModelRet.ChildCount = 983247;

                        TVItemStatModel tvItemStatModelRet2 = tvItemStatService.PostUpdateTVItemStatDB(tvItemStatModelRet);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostUpdateTVItemStatDB_GetTVItemStatWithTVItemIDAndTVTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.GetTVItemStatWithTVItemIDAndTVTypeDBInt32TVTypeEnum = (a, b) =>
                        {
                            return null;
                        };

                        tvItemStatModelRet.ChildCount = 983247;

                        TVItemStatModel tvItemStatModelRet2 = tvItemStatService.PostUpdateTVItemStatDB(tvItemStatModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVItemStat), tvItemStatModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostUpdateTVItemStatDB_FillTVItemStat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.FillTVItemStatTVItemStatTVItemStatModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        tvItemStatModelRet.ChildCount = 983247;

                        TVItemStatModel tvItemStatModelRet2 = tvItemStatService.PostUpdateTVItemStatDB(tvItemStatModelRet);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_PostUpdateTVItemStatDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = AddTestTVItemStat();
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        tvItemStatModelRet.ChildCount = 983247;

                        TVItemStatModel tvItemStatModelRet2 = tvItemStatService.PostUpdateTVItemStatDB(tvItemStatModelRet);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemID_TVItemID_130904_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int TVItemID = 130904;
                    string retStr = tvItemStatService.SetTVItemStatForTVItemID(TVItemID);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_Root_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelRoot.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Root);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelRoot.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_Area_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06 Bouctouche
                    TVItemModel tvItemModelArea = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06", TVTypeEnum.Area);
                    Assert.AreEqual("", tvItemModelArea.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelArea.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Area);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelArea.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_Country_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Canada
                    TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCanada.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelCanada.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Country);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelCanada.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_Infrastructure_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche
                    TVItemModel tvItemModelBouctouche = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouctouche.Error);

                    TVItemModel tvItemModelInf = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelBouctouche.TVItemID, TVTypeEnum.Infrastructure).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelInf.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelInf.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Infrastructure);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelInf.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_MikeScenario_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche
                    TVItemModel tvItemModelBouctouche = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouctouche.Error);

                    TVItemModel tvItemModelMS = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelBouctouche.TVItemID, TVTypeEnum.MikeScenario).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelMS.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelMS.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.MikeScenario);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelMS.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_Municipality_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // Bouctouche
                    TVItemModel tvItemModelBouctouche = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouctouche.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelBouctouche.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Municipality);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelBouctouche.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_MWQMSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020-002
                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    TVItemModel tvItemModelMWQMSite = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.MWQMSite).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelMWQMSite.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelMWQMSite.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.MWQMSite);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelMWQMSite.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_PolSourceSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020-002
                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    TVItemModel tvItemModelPolSourceSite = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelPolSourceSite.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelPolSourceSite.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.PolSourceSite);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelPolSourceSite.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_Province_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB
                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelNB.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Province);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelNB.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_Sector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020
                    TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020", TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelSector.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Sector);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelSector.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_Subsector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020-002
                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelSubsector.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.Subsector);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_MWQMRun_Subsector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020-002
                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelSubsector.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.MWQMRun);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_MWQMRun_MWQMSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020-002
                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    TVItemModel tvItemModelMWQMRun = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.MWQMRun).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelMWQMRun.Error);

                    string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelMWQMRun.TVItemID);
                    Assert.AreEqual("", retStr);

                    List<TVTypeEnum> subTVType = tvItemStatService.GetSubTVTypeForTVItemStat(TVTypeEnum.MWQMRun);
                    foreach (TVTypeEnum ChildTVType in subTVType)
                    {
                        TVItemStatModel tvItemStatModel = tvItemStatService.GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemModelMWQMRun.TVItemID, ChildTVType);
                        Assert.AreEqual("", tvItemStatModel.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelRoot.TVItemID);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelRoot.TVItemID);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndParentsTVItemID_FillTVItemStat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.FillTVItemStatTVItemStatTVItemStatModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        string retStr = tvItemStatService.SetTVItemStatForTVItemIDAndParentsTVItemID(tvItemModelRoot.TVItemID);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet2 = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemStatModelRet2.Error);
                    Assert.AreEqual(2, tvItemStatModelRet2.ChildCount);

                    tvItemStatModelRet2 = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.WasteWaterTreatmentPlant);
                    Assert.AreEqual("", tvItemStatModelRet2.Error);

                    tvItemStatModelRet2 = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.LiftStation);
                    Assert.AreEqual("", tvItemStatModelRet2.Error);

                    tvItemStatModelRet2 = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.MWQMSiteSample);
                    Assert.AreEqual("", tvItemStatModelRet2.Error);

                    tvItemStatModelRet2 = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.BoxModel);
                    Assert.AreEqual("", tvItemStatModelRet2.Error);

                    tvItemStatModelRet2 = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.VisualPlumesScenario);
                    Assert.AreEqual("", tvItemStatModelRet2.Error);

                    int MWQMSiteBouctoucheSite0001TVItemID = 7460;
                    tvItemStatModelRet2 = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(MWQMSiteBouctoucheSite0001TVItemID, TVTypeEnum.MWQMRun);
                    Assert.AreEqual("", tvItemStatModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Address_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Address);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(645 /*Shediac Harbour*/, TVTypeEnum.Address);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Area_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Area);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(7 /*New Brunswick*/, TVTypeEnum.Area);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_ClimateSite_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.ClimateSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(1455 /*Tignish River PEI Sector*/, TVTypeEnum.ClimateSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(1456 /*Tignish River PEI Subsector*/, TVTypeEnum.ClimateSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Contact_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(642 /*NB-07 (Shediac River to Tidnish River)*/, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(41884 /*Shediac Municipality*/, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Country_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Email_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Email);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(642 /*NB-07 (Shediac River to Tidnish River)*/, TVTypeEnum.Email);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(41884 /*Shediac*/, TVTypeEnum.Email);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_File_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(645 /*Shediac Harbour*/, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_HydrometricSite_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.HydrometricSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.HydrometricSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.HydrometricSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Infrastructure_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_MikeScenario_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_MikeSource_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(28475 /*Bouctouche Riv HF LS 2 HT wind east 20 km_h (Mike Scenario)*/, TVTypeEnum.MikeSource);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Municipality_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_MWQMRun_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.MWQMRun);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.MWQMRun);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.MWQMRun);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    int MWQMSiteBouctoucheSite0001TVItemID = 7460;
                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(MWQMSiteBouctoucheSite0001TVItemID, TVTypeEnum.MWQMRun);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_MWQMSite_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.MWQMSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.MWQMSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.MWQMSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    int MWQMSiteBouctoucheRun20120807TVItemID = 130894;
                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(MWQMSiteBouctoucheRun20120807TVItemID, TVTypeEnum.MWQMSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_MWQMSiteSample_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.MWQMSiteSample);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.MWQMSiteSample);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.MWQMSiteSample);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    int MWQMSiteBouctoucheRun20120807TVItemID = 130894;
                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(MWQMSiteBouctoucheRun20120807TVItemID, TVTypeEnum.MWQMSiteSample);
                    Assert.AreEqual("", tvItemStatModelRet.Error);

                    int MWQMSiteBouctoucheSite0001TVItemID = 7460;
                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(MWQMSiteBouctoucheSite0001TVItemID, TVTypeEnum.MWQMSiteSample);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_PolSourceSite_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.PolSourceSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.PolSourceSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.PolSourceSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Province_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Sector_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Subsector_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Tel_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Tel);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(642 /*NB-07 (Shediac River to Tidnish River)*/, TVTypeEnum.Tel);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(41884 /*Shediac*/, TVTypeEnum.Tel);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_TideSite_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.TideSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.TideSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.TideSite);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_WasteWaterTreatmentPlant_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.WasteWaterTreatmentPlant);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.WasteWaterTreatmentPlant);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.WasteWaterTreatmentPlant);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_LiftStation_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.LiftStation);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.LiftStation);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.LiftStation);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_Spill_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    //TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    //Assert.AreEqual("", tvItemModelRoot.Error);

                    //TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Spill);
                    //Assert.AreEqual("", tvItemStatModelRet.Error);
                    //Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    //tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.Spill);
                    //Assert.AreEqual("", tvItemStatModelRet.Error);
                    //Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    //tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.Spill);
                    //Assert.AreEqual("", tvItemStatModelRet.Error);
                    //Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_BoxModel_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.BoxModel);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.BoxModel);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.BoxModel);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(28689 /*Bouctouche WWTP*/, TVTypeEnum.BoxModel);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_VisualPlumesScenario_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.VisualPlumesScenario);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(633 /*NB-06-020 (Bouctouche) Sector*/, TVTypeEnum.VisualPlumesScenario);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(635 /*NB-06-020-002 (Bouctouche River AND Harbour) Subsector*/, TVTypeEnum.VisualPlumesScenario);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);

                    tvItemStatModelRet = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(28689 /*Bouctouche WWTP*/, TVTypeEnum.VisualPlumesScenario);
                    Assert.AreEqual("", tvItemStatModelRet.Error);
                    Assert.IsTrue(tvItemStatModelRet.ChildCount > 0);


                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };
                        TVItemStatModel tvItemStatModelRet2 = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };
                        TVItemStatModel tvItemStatModelRet2 = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_FillTVItemStat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.FillTVItemStatTVItemStatTVItemStatModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVItemStatModel tvItemStatModelRet2 = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemStatService_SetTVItemStatForTVItemIDAndTVType_PostUpdateTVItemStatDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemStatModel tvItemStatModelRet2 = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemStatModelRet2.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemStatService.PostUpdateTVItemStatDBTVItemStatModel = (a) =>
                        {
                            return new TVItemStatModel() { Error = ErrorText };
                        };

                        TVItemStatModel tvItemStatModelRet3 = tvItemStatService.SetTVItemStatForTVItemIDAndTVType(tvItemModelRoot.TVItemID, TVTypeEnum.Country);
                        Assert.AreEqual(ErrorText, tvItemStatModelRet3.Error);
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Functions private
        private TVItemStatModel AddTestTVItemStat()
        {
            TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Municipality);

            Assert.AreEqual("", tvItemModel.Error);

            TVItemStatModel tvItemStatModelNew = new TVItemStatModel();

            FillTVItemStatModel(tvItemStatModelNew, tvItemModel, TVTypeEnum.Infrastructure);

            TVItemStatModel tvItemStatModel = tvItemStatService.PostDeleteTVItemStatWithTVItemIDDB(tvItemModel.TVItemID);

            Assert.AreEqual("", tvItemStatModel.Error);

            TVItemStatModel tvItemStatModelRet = tvItemStatService.PostAddTVItemStatDB(tvItemStatModelNew);
            if (!string.IsNullOrWhiteSpace(tvItemStatModelRet.Error))
            {
                return tvItemStatModelRet;
            }

            Assert.IsNotNull(tvItemStatModelRet);
            CompareTVItemModels(tvItemStatModelNew, tvItemStatModelRet);

            return tvItemStatModelRet;
        }
        private void CompareTVItemModels(TVItemStatModel tvItemStatModel, TVItemStatModel tvItemStatModelRet)
        {
            Assert.AreEqual(tvItemStatModel.TVItemID, tvItemStatModelRet.TVItemID);
            Assert.AreEqual(tvItemStatModel.TVType, tvItemStatModelRet.TVType);
            Assert.AreEqual(tvItemStatModel.ChildCount, tvItemStatModelRet.ChildCount);
        }
        private void FillTVItemStatModel(TVItemStatModel tvItemStatModel, TVItemModel tvItemModel, TVTypeEnum tvType)
        {
            tvItemStatModel.TVItemID = tvItemModel.TVItemID;
            tvItemStatModel.TVType = tvType;
            tvItemStatModel.ChildCount = randomService.RandomInt(0, 100000);

            Assert.IsTrue(tvItemModel.TVItemID == tvItemStatModel.TVItemID);
            Assert.IsTrue(tvType == tvItemStatModel.TVType);
            Assert.IsTrue(tvItemStatModel.ChildCount >= 0 && tvItemStatModel.ChildCount <= 100000);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            tvItemStatService = new TVItemStatService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            infrastructureService = new InfrastructureService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
        }
        private void SetupShim()
        {
            shimTVItemStatService = new ShimTVItemStatService(tvItemStatService);
            shimTVItemService = new ShimTVItemService(tvItemStatService._TVItemService);
        }
        #endregion Functions private
    }
}

