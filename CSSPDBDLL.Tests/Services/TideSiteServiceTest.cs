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
    /// Summary description for TideSiteServiceTest
    /// </summary>
    [TestClass]
    public class TideSiteServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "TideSite";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private TideSiteService tideSiteService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private TideSiteModel tideSiteModelNew { get; set; }
        private TideSite tideSite { get; set; }
        private ShimTideSiteService shimTideSiteService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
        private ShimAppTaskService shimAppTaskService { get; set; }
        private MikeBoundaryConditionServiceTest mikeBoundaryConditionServiceTest { get; set; }
        private MapInfoService mapInfoService { get; set; }
        private ShimMikeBoundaryConditionService shimMikeBoundaryConditionService { get; set; }
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
        public TideSiteServiceTest()
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
        public void TideSiteService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(tideSiteService);
                Assert.IsNotNull(tideSiteService.db);
                Assert.IsNotNull(tideSiteService.LanguageRequest);
                Assert.IsNotNull(tideSiteService.User);
                Assert.AreEqual(user.Identity.Name, tideSiteService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), tideSiteService.LanguageRequest);
            }
        }
        [TestMethod]
        public void TideSiteService_TideSiteModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModel = AddTideSiteModel();
                    Assert.AreEqual("", tideSiteModel.Error);

                    #region Good
                    tideSiteModelNew.TideSiteTVItemID = tideSiteModel.TideSiteTVItemID;
                    tideSiteModelNew.TideSiteTVText = randomService.RandomString("Tide Site ", 20);
                    FillTideSiteModel(tideSiteModelNew);

                    string retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region TideSiteTVItemID
                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.TideSiteTVItemID = 0;

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TideSiteTVItemID), retStr);

                    tideSiteModelNew.TideSiteTVItemID = tideSiteModel.TideSiteTVItemID;
                    FillTideSiteModel(tideSiteModelNew);

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TideSiteTVItemID

                    #region TideSiteTVText
                    int Min = 3;
                    int Max = 100;

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.TideSiteTVText = randomService.RandomString("", Min - 1);

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.TideSiteTVText, Min), retStr);

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.TideSiteTVText = randomService.RandomString("", Max + 1);

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.TideSiteTVText, Max), retStr);

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.TideSiteTVText = randomService.RandomString("", Min);

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.TideSiteTVText = randomService.RandomString("", Max);

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.TideSiteTVText = randomService.RandomString("", Max - 1);

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TideSiteTVText

                    #region WebTideModel
                    Min = 3;
                    Max = 100;

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.WebTideModel = randomService.RandomString("", Min - 1);

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.WebTideModel, Min), retStr);

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.WebTideModel = randomService.RandomString("", Max + 1);

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.WebTideModel, Max), retStr);

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.WebTideModel = randomService.RandomString("", Min);

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.WebTideModel = randomService.RandomString("", Max);

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.WebTideModel = randomService.RandomString("", Max - 1);

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion WebTideModel

                    #region WebTideDatum_m
                    FillTideSiteModel(tideSiteModelNew);
                    double MinDbl = -10;
                    double MaxDbl = 10;
                    tideSiteModelNew.WebTideDatum_m = MinDbl - 1;

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WebTideDatum_m, MinDbl, MaxDbl), retStr);

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.WebTideDatum_m = MaxDbl + 1;

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WebTideDatum_m, MinDbl, MaxDbl), retStr);

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.WebTideDatum_m = MaxDbl - 1;

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.WebTideDatum_m = MinDbl;

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideSiteModel(tideSiteModelNew);
                    tideSiteModelNew.WebTideDatum_m = MaxDbl;

                    retStr = tideSiteService.TideSiteModelOK(tideSiteModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion WebTideDatum_m
                }
            }
        }
        [TestMethod]
        public void TideSiteService_FillTideSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    tideSiteModelNew.TideSiteTVItemID = randomService.RandomTVItem(TVTypeEnum.TideSite).TVItemID;
                    tideSiteModelNew.TideSiteTVText = randomService.RandomString("Tide Site ", 20);
                    FillTideSiteModel(tideSiteModelNew);

                    ContactOK contactOK = tideSiteService.IsContactOK();

                    string retStr = tideSiteService.FillTideSite(tideSite, tideSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, tideSite.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = tideSiteService.FillTideSite(tideSite, tideSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, tideSite.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void TideSiteService_GetTideSiteModelCount_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    int tideSiteCount = tideSiteService.GetTideSiteModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, tideSiteCount);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_GetTideSiteModelWithTideSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    // Act 
                    TideSiteModel tideSiteModelRet2 = tideSiteService.GetTideSiteModelWithTideSiteIDDB(tideSiteModelRet.TideSiteID);

                    // Assert 
                    CompareTideSiteModels(tideSiteModelRet, tideSiteModelRet2);

                    int TideSiteID = 0;
                    TideSiteModel tideSiteModelRet3 = tideSiteService.GetTideSiteModelWithTideSiteIDDB(TideSiteID);

                    // Assert 
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TideSite, ServiceRes.TideSiteID, TideSiteID), tideSiteModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_GetTideSiteModelWithTideSiteTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    TideSiteModel tideSiteModelRet2 = tideSiteService.GetTideSiteModelWithTideSiteTVItemIDDB(tideSiteModelRet.TideSiteTVItemID);

                    CompareTideSiteModels(tideSiteModelRet, tideSiteModelRet2);

                    int TideSiteTVItemID = 0;
                    TideSiteModel tideSiteModelRet3 = tideSiteService.GetTideSiteModelWithTideSiteTVItemIDDB(TideSiteTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TideSite, ServiceRes.TideSiteTVItemID, TideSiteTVItemID), tideSiteModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void TideSiteService_GetTideSiteWithTideSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    TideSite tideSiteRet = tideSiteService.GetTideSiteWithTideSiteIDDB(tideSiteModelRet.TideSiteID);
                    Assert.AreEqual(tideSiteModelRet.TideSiteID, tideSiteRet.TideSiteID);

                    int TideSiteID = 0;
                    TideSite tideSiteRet2 = tideSiteService.GetTideSiteWithTideSiteIDDB(TideSiteID);
                    Assert.IsNull(tideSiteRet2);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_GetTideDataPathsDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<DataPathOfTide> dataPathOfTideList = tideSiteService.GetTideDataPathsDB();
                    Assert.AreEqual(Enum.GetNames(typeof(WebTideDataSetEnum)).Count(), dataPathOfTideList.Count + 1);
                    for (int i = 1, count = dataPathOfTideList.Count; i < count; i++)
                    {
                        Assert.AreEqual((WebTideDataSetEnum)i, dataPathOfTideList[i - 1].WebTideDataSet);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    string retStr = tideSiteService.CreateTVText(tideSiteModelRet);
                    Assert.AreEqual(tideSiteModelRet.TideSiteTVText, retStr);

                    tideSiteModelRet.TideSiteTVText = "";
                    retStr = tideSiteService.CreateTVText(tideSiteModelRet);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_ReturnTideSiteError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    TideSiteModel tideSiteModelRet = tideSiteService.ReturnTideSiteError(ErrorText);
                    Assert.AreEqual(ErrorText, tideSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_ReturnAppTaskError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    AppTaskModel appTaskModelRet = tideSiteService.ReturnAppTaskError(ErrorText);
                    Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_GenerateWebTideDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelBoundaryConditions = randomService.RandomTVItem(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", tvItemModelBoundaryConditions.Error);

                    int WebTideNodeNumb = 5;
                    AppTaskModel appTaskModelRet = tideSiteService.GenerateWebTideDB(tvItemModelMikeScenario.TVItemID, tvItemModelBoundaryConditions.TVItemID, WebTideNodeNumb);
                    Assert.IsNotNull(appTaskModelRet);
                    Assert.AreEqual("", appTaskModelRet.Error);
                    Assert.AreEqual(tvItemModelMikeScenario.TVItemID, appTaskModelRet.TVItemID);
                    Assert.AreEqual(tvItemModelMikeScenario.TVItemID, appTaskModelRet.TVItemID2);
                    Assert.AreEqual(AppTaskCommandEnum.GenerateWebTide, appTaskModelRet.Command);
                    Assert.AreEqual("", appTaskModelRet.ErrorText);
                    Assert.AreEqual(ServiceRes.GeneratingWebTideNodes, appTaskModelRet.StatusText);
                    Assert.AreEqual(AppTaskStatusEnum.Created, appTaskModelRet.Status);
                    Assert.AreEqual(1, appTaskModelRet.PercentCompleted);
                    Assert.AreEqual(tvItemModelMikeScenario.TVItemID.ToString(), tideSiteService._AppTaskService.GetAppTaskParamStr(appTaskModelRet.Parameters, "MikeScenarioTVItemID"));
                    Assert.AreEqual(tvItemModelBoundaryConditions.TVItemID.ToString(), tideSiteService._AppTaskService.GetAppTaskParamStr(appTaskModelRet.Parameters, "BCMeshTVItemID"));
                    Assert.AreEqual(WebTideNodeNumb.ToString(), tideSiteService._AppTaskService.GetAppTaskParamStr(appTaskModelRet.Parameters, "WebTideNodeNumb"));
                    //Assert.AreEqual("0", tideSiteService._AppTaskService.GetAppTaskParamStr(appTaskModelRet.Parameters, "Generate"));
                    //Assert.AreEqual("1", tideSiteService._AppTaskService.GetAppTaskParamStr(appTaskModelRet.Parameters, "Command"));
                    Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), tideSiteService.LanguageRequest);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_GenerateWebTideDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelBoundaryConditions = randomService.RandomTVItem(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", tvItemModelBoundaryConditions.Error);
                    int WTNodeNumb = 5;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTideSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet = tideSiteService.GenerateWebTideDB(tvItemModelMikeScenario.TVItemID, tvItemModelBoundaryConditions.TVItemID, WTNodeNumb);
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_GenerateWebTideDB_MikeScenarioTVItemID_Equal_0_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelBoundaryConditions = randomService.RandomTVItem(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", tvItemModelBoundaryConditions.Error);
                    int NodeNumb = 5;

                    AppTaskModel appTaskModelRet = tideSiteService.GenerateWebTideDB(0, tvItemModelBoundaryConditions.TVItemID, NodeNumb);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), appTaskModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_GenerateWebTideDB_BCMeshTVItemID_Equal_0_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelBoundaryConditions = randomService.RandomTVItem(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", tvItemModelBoundaryConditions.Error);
                    int NodeNumb = 5;

                    AppTaskModel appTaskModelRet = tideSiteService.GenerateWebTideDB(tvItemModelMikeScenario.TVItemID, 0, NodeNumb);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.BCMeshTVItemID), appTaskModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_GenerateWebTideDB_WTNodeNumb_Equal_0_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelBoundaryConditions = randomService.RandomTVItem(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", tvItemModelBoundaryConditions.Error);
                    //int WTNodeNumb = 5;

                    AppTaskModel appTaskModelRet = tideSiteService.GenerateWebTideDB(tvItemModelMikeScenario.TVItemID, tvItemModelBoundaryConditions.TVItemID, 0);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.WTNodeNumb), appTaskModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_GenerateWebTideDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelBoundaryConditions = randomService.RandomTVItem(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", tvItemModelBoundaryConditions.Error);
                    int WTNodeNumb = 5;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet = tideSiteService.GenerateWebTideDB(tvItemModelMikeScenario.TVItemID, tvItemModelBoundaryConditions.TVItemID, WTNodeNumb);
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_GenerateWebTideDB_GetAppTaskModelWithTVItemIDTVItemID2AndAppTaskNameDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelBoundaryConditions = randomService.RandomTVItem(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", tvItemModelBoundaryConditions.Error);
                    int NodeNumb = 5;

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimAppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDBInt32Int32AppTaskCommandEnum = (a, b, c) =>
                        {
                            return new AppTaskModel() { Error = "" };
                        };

                        AppTaskModel appTaskModelRet = tideSiteService.GenerateWebTideDB(tvItemModelMikeScenario.TVItemID, tvItemModelBoundaryConditions.TVItemID, NodeNumb);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask), appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_GenerateWebTideDB_PostAddAppTask_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelBoundaryConditions = randomService.RandomTVItem(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", tvItemModelBoundaryConditions.Error);
                    int NodeNumb = 5;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAppTaskService.PostAddAppTaskAppTaskModel = (a) =>
                        {
                            return new AppTaskModel() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet = tideSiteService.GenerateWebTideDB(tvItemModelMikeScenario.TVItemID, tvItemModelBoundaryConditions.TVItemID, NodeNumb);
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_ResetWebTideDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    TVItemModel tvItemModelMikeScenario = tideSiteService._TVItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, randomService.RandomString("Mike Scenario ", 20), TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    AddMikeBoundaryCondition(tvItemModelMikeScenario);

                    string retStr3 = tideSiteService.ResetWebTideDB(tvItemModelMikeScenario.TVItemID);
                    Assert.AreEqual("", retStr3);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_ResetWebTideDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    TVItemModel tvItemModelMikeScenario = tideSiteService._TVItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, randomService.RandomString("Mike Scenario ", 20), TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    AddMikeBoundaryCondition(tvItemModelMikeScenario);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTideSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        string retStr3 = tideSiteService.ResetWebTideDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErrorText, retStr3);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_ResetWebTideDB_TVItemID_Zero_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string retStr3 = tideSiteService.ResetWebTideDB(0);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), retStr3);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_ResetWebTideDB_PostDeleteMikeBoundaryConditionDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    TVItemModel tvItemModelMikeScenario = tideSiteService._TVItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, randomService.RandomString("Mike Scenario ", 20), TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    AddMikeBoundaryCondition(tvItemModelMikeScenario);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeBoundaryConditionService.PostDeleteMikeBoundaryConditionDBInt32 = (a) =>
                        {
                            return new MikeBoundaryConditionModel() { Error = ErrorText };
                        };

                        string retStr3 = tideSiteService.ResetWebTideDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErrorText, retStr3);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_SetupWebTideDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelTVFileM21FM = tideSiteService._TVItemService.GetTVItemModelListContainingTVTextDB(1, "Black Harbour m21fm").FirstOrDefault();
                    Assert.AreEqual("", tvItemModelTVFileM21FM.Error);

                    TVItemModel tvItemModelMikeScenario = tideSiteService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(tvItemModelTVFileM21FM.TVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    AppTaskModel appTaskModelRet = tideSiteService.SetupWebTideDB(tvItemModelMikeScenario.TVItemID, (int)WebTideDataSetEnum.nwatl);
                    Assert.IsNotNull(appTaskModelRet);
                    Assert.AreEqual("", appTaskModelRet.Error);
                    Assert.AreEqual(tvItemModelMikeScenario.TVItemID, appTaskModelRet.TVItemID);
                    Assert.AreEqual(tvItemModelMikeScenario.TVItemID, appTaskModelRet.TVItemID2);
                    Assert.AreEqual(AppTaskCommandEnum.SetupWebTide, appTaskModelRet.Command);
                    Assert.AreEqual("", appTaskModelRet.ErrorText);
                    Assert.AreEqual(ServiceRes.SettingBoundaryConditions, appTaskModelRet.StatusText);
                    Assert.AreEqual(AppTaskStatusEnum.Created, appTaskModelRet.Status);
                    Assert.AreEqual(1, appTaskModelRet.PercentCompleted);
                    Assert.AreEqual(tvItemModelMikeScenario.TVItemID.ToString(), tideSiteService._AppTaskService.GetAppTaskParamStr(appTaskModelRet.Parameters, "MikeScenarioTVItemID"));
                    Assert.AreEqual(((int)WebTideDataSetEnum.nwatl).ToString(), tideSiteService._AppTaskService.GetAppTaskParamStr(appTaskModelRet.Parameters, "WebTideDataSet"));
                    //Assert.AreEqual("0", tideSiteService._AppTaskService.GetAppTaskParamStr(appTaskModelRet.Parameters, "Generate"));
                    //Assert.AreEqual("1", tideSiteService._AppTaskService.GetAppTaskParamStr(appTaskModelRet.Parameters, "Command"));
                    Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), tideSiteService.LanguageRequest);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_SetupWebTideDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = randomService.RandomTVItem(TVTypeEnum.MikeScenario).TVItemID;

                    List<DataPathOfTide> dataPathOfTide = tideSiteService.GetTideDataPathsDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTideSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet = tideSiteService.SetupWebTideDB(MikeScenarioTVItemID, (int)WebTideDataSetEnum.nwatl);
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_SetupWebTideDB_MikeScenarioTVItemID_Equal_0_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = randomService.RandomTVItem(TVTypeEnum.MikeScenario).TVItemID;

                    AppTaskModel appTaskModelRet = tideSiteService.SetupWebTideDB(0, (int)WebTideDataSetEnum.nwatl);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), appTaskModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_SetupWebTideDB_DataPathBC_Empty_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = randomService.RandomTVItem(TVTypeEnum.MikeScenario).TVItemID;

                    AppTaskModel appTaskModelRet = tideSiteService.SetupWebTideDB(MikeScenarioTVItemID, (int)WebTideDataSetEnum.Error);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.WebTideDataSet), appTaskModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_SetupWebTideDB_GetAppTaskModelWithTVItemIDTVItemID2AndAppTaskNameDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = randomService.RandomTVItem(TVTypeEnum.MikeScenario).TVItemID;

                    List<DataPathOfTide> dataPathOfTide = tideSiteService.GetTideDataPathsDB();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimAppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDBInt32Int32AppTaskCommandEnum = (a, b, c) =>
                        {
                            return new AppTaskModel() { Error = "" };
                        };

                        AppTaskModel appTaskModelRet = tideSiteService.SetupWebTideDB(MikeScenarioTVItemID, (int)WebTideDataSetEnum.nwatl);
                        Assert.AreEqual(string.Format(ServiceRes.TaskOf_AlreadyRunning, AppTaskCommandEnum.SetupWebTide), appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_SetupWebTideDB_PostAddAppTask_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = randomService.RandomTVItem(TVTypeEnum.MikeScenario).TVItemID;

                    List<DataPathOfTide> dataPathOfTide = tideSiteService.GetTideDataPathsDB();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAppTaskService.PostAddAppTaskAppTaskModel = (a) =>
                        {
                            return new AppTaskModel() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet = tideSiteService.SetupWebTideDB(MikeScenarioTVItemID, (int)WebTideDataSetEnum.nwatl);
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostAddUpdateDeleteTideSiteDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();
                    TideSiteModel tideSiteModelRet2 = UpdateTideSiteModel(tideSiteModelRet);

                    TideSiteModel tideSiteModelRet3 = tideSiteService.PostDeleteTideSiteDB(tideSiteModelRet2.TideSiteID);
                    Assert.AreEqual("", tideSiteModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostAddTideSiteDB_TideSiteModelOK_Test()
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
                        shimTideSiteService.TideSiteModelOKTideSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TideSiteModel tideSiteModelRet = AddTideSiteModel();
                        Assert.AreEqual(ErrorText, tideSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostAddTideSiteDB_IsContactOK_Error_Test()
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
                        shimTideSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TideSiteModel tideSiteModelRet = AddTideSiteModel();
                        Assert.AreEqual(ErrorText, tideSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostAddTideSiteDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();
                    Assert.AreEqual("", tideSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        tideSiteModelRet = tideSiteService.PostAddTideSiteDB(tideSiteModelRet);
                        Assert.AreEqual(ErrorText, tideSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostAddTideSiteDB_FillTideSiteModel_ErrorTest()
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
                        shimTideSiteService.FillTideSiteTideSiteTideSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TideSiteModel tideSiteModelRet = AddTideSiteModel();
                        Assert.AreEqual(ErrorText, tideSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostAddTideSiteDB_DoAddChanges_ErrorTest()
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
                        shimTideSiteService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        TideSiteModel tideSiteModelRet = AddTideSiteModel();
                        Assert.AreEqual(ErrorText, tideSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostAddTideSiteDB_Add_Error_Test()
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
                        shimTideSiteService.FillTideSiteTideSiteTideSiteModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        TideSiteModel tideSiteModelRet = AddTideSiteModel();
                        Assert.IsTrue(tideSiteModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostDeleteTideSiteDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTideSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TideSiteModel tideSiteModelRet2 = tideSiteService.PostDeleteTideSiteDB(tideSiteModelRet.TideSiteID);
                        Assert.AreEqual(ErrorText, tideSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostDeleteTideSiteDB_GetTideSiteWithTideSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTideSiteService.GetTideSiteWithTideSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TideSiteModel tideSiteModelRet2 = tideSiteService.PostDeleteTideSiteDB(tideSiteModelRet.TideSiteID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TideSite), tideSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostDeleteTideSiteDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTideSiteService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TideSiteModel tideSiteModelRet2 = tideSiteService.PostDeleteTideSiteDB(tideSiteModelRet.TideSiteID);
                        Assert.AreEqual(ErrorText, tideSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostDeleteTideSiteDB_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TideSiteModel tideSiteModelRet2 = tideSiteService.PostDeleteTideSiteDB(tideSiteModelRet.TideSiteID);
                        Assert.AreEqual(ErrorText, tideSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostUpdateTideSiteDB_TideSiteModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTideSiteService.TideSiteModelOKTideSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TideSiteModel tideSiteModelRet2 = UpdateTideSiteModel(tideSiteModelRet);
                        Assert.AreEqual(ErrorText, tideSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostUpdateTideSiteDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTideSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TideSiteModel tideSiteModelRet2 = UpdateTideSiteModel(tideSiteModelRet);
                        Assert.AreEqual(ErrorText, tideSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostUpdateTideSiteDB_GetTideSiteWithTideSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTideSiteService.GetTideSiteWithTideSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TideSiteModel tideSiteModelRet2 = UpdateTideSiteModel(tideSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TideSite), tideSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostUpdateTideSiteDB_FillTideSiteModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTideSiteService.FillTideSiteTideSiteTideSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TideSiteModel tideSiteModelRet2 = UpdateTideSiteModel(tideSiteModelRet);
                        Assert.AreEqual(ErrorText, tideSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostUpdateTideSiteDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTideSiteService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TideSiteModel tideSiteModelRet2 = UpdateTideSiteModel(tideSiteModelRet);
                        Assert.AreEqual(ErrorText, tideSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostAddTideSiteDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, tideSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TideSiteService_PostAddTideSiteDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = AddTideSiteModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, tideSiteModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Function
        private void AddMikeBoundaryCondition(TVItemModel tvItemModelMikeScenario)
        {
            for (int j = 1; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    TVItemModel tvItemModelMikeBoundaryCondition = tideSiteService._MikeBoundaryConditionService._TVItemService.PostAddChildTVItemDB(tvItemModelMikeScenario.TVItemID, "MBC Mesh " + j.ToString() + " " + i.ToString(), TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", tvItemModelMikeBoundaryCondition.Error);

                    MikeBoundaryConditionModel mikeBoundaryConditionModelNew = new MikeBoundaryConditionModel();
                    mikeBoundaryConditionModelNew.MikeBoundaryConditionTVItemID = tvItemModelMikeBoundaryCondition.TVItemID;
                    mikeBoundaryConditionServiceTest.FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);

                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = tideSiteService._MikeBoundaryConditionService.PostAddMikeBoundaryConditionDB(mikeBoundaryConditionModelNew);
                    Assert.AreEqual("", mikeBoundaryConditionModelRet.Error);

                    Coord coord = new Coord() { Lat = randomService.RandomFloat(45, 46), Lng = randomService.RandomFloat(-123, -66), Ordinal = 0 };

                    List<Coord> coordList = new List<Coord>()
                            {
                                new Coord() { Lat = (float)(coord.Lat + 0.3), Lng = (float)(coord.Lng + 0.3) },
                                new Coord() { Lat = (float)(coord.Lat + 0.4), Lng = (float)(coord.Lng + 0.4) },
                                new Coord() { Lat = (float)(coord.Lat + 0.5), Lng = (float)(coord.Lng + 0.5) },
                            };

                    MapInfoModel mapInfoModel = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polyline, TVTypeEnum.MikeBoundaryConditionMesh, mikeBoundaryConditionModelRet.MikeBoundaryConditionTVItemID);
                    Assert.AreEqual("", mapInfoModel.Error);
                }
            }
        }
        public TideSiteModel AddTideSiteModel()
        {
            TVItemModel tvItemModelSubsector = randomService.RandomTVItem(TVTypeEnum.Subsector);

            Assert.AreEqual("", tvItemModelSubsector.Error);

            string TVText = randomService.RandomString("TideSite ", 20);
            TVItemModel tvItemModelTideSite = tideSiteService._TVItemService.PostAddChildTVItemDB(tvItemModelSubsector.TVItemID, TVText, TVTypeEnum.MikeBoundaryConditionMesh);
            if (!string.IsNullOrWhiteSpace(tvItemModelTideSite.Error))
            {
                return new TideSiteModel() { Error = tvItemModelTideSite.Error };
            }

            tideSiteModelNew.TideSiteTVItemID = tvItemModelTideSite.TVItemID;
            tideSiteModelNew.TideSiteTVText = TVText;

            FillTideSiteModel(tideSiteModelNew);

            TideSiteModel tideSiteModelRet = tideSiteService.PostAddTideSiteDB(tideSiteModelNew);
            if (!string.IsNullOrWhiteSpace(tideSiteModelRet.Error))
            {
                return tideSiteModelRet;
            }

            CompareTideSiteModels(tideSiteModelNew, tideSiteModelRet);

            return tideSiteModelRet;

        }
        public TideSiteModel UpdateTideSiteModel(TideSiteModel tideSiteModel)
        {
            FillTideSiteModel(tideSiteModel);

            TideSiteModel tideSiteModelRet2 = tideSiteService.PostUpdateTideSiteDB(tideSiteModel);
            if (!string.IsNullOrWhiteSpace(tideSiteModelRet2.Error))
            {
                return tideSiteModelRet2;
            }

            CompareTideSiteModels(tideSiteModel, tideSiteModelRet2);

            return tideSiteModelRet2;
        }
        public void CompareTideSiteModels(TideSiteModel tideSiteModelRet, TideSiteModel tideSiteModel)
        {
            Assert.AreEqual(tideSiteModelRet.TideSiteTVItemID, tideSiteModel.TideSiteTVItemID);
            Assert.AreEqual(tideSiteModelRet.TideSiteTVText, tideSiteModel.TideSiteTVText);
            Assert.AreEqual(tideSiteModelRet.WebTideModel, tideSiteModel.WebTideModel);
            Assert.AreEqual(tideSiteModelRet.WebTideDatum_m, tideSiteModel.WebTideDatum_m);
        }
        public void FillTideSiteModel(TideSiteModel tideSiteModel)
        {
            tideSiteModel.TideSiteTVItemID = tideSiteModel.TideSiteTVItemID;
            tideSiteModel.TideSiteTVText = tideSiteModel.TideSiteTVText;
            tideSiteModel.WebTideModel = randomService.RandomString("WTM", 10);
            tideSiteModel.WebTideDatum_m = randomService.RandomDouble(-10, 10);

            Assert.IsTrue(tideSiteModel.TideSiteTVItemID != 0);
            Assert.IsTrue(tideSiteModel.TideSiteTVText.Length > 0);
            Assert.IsTrue(tideSiteModel.WebTideModel.Length == 10);
            Assert.IsTrue(tideSiteModel.WebTideDatum_m >= -10 && tideSiteModel.WebTideDatum_m <= 10);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            tideSiteService = new TideSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tideSiteModelNew = new TideSiteModel();
            tideSite = new TideSite();
            mikeBoundaryConditionServiceTest = new MikeBoundaryConditionServiceTest();
            mikeBoundaryConditionServiceTest.SetupTest(contactModelToDo, culture);
            mapInfoService = new MapInfoService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
        }
        private void SetupShim()
        {
            shimTideSiteService = new ShimTideSiteService(tideSiteService);
            shimTVItemService = new ShimTVItemService(tideSiteService._TVItemService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(tideSiteService._TVItemService._TVItemLanguageService);
            shimAppTaskService = new ShimAppTaskService(tideSiteService._AppTaskService);
            shimMikeBoundaryConditionService = new ShimMikeBoundaryConditionService(tideSiteService._MikeBoundaryConditionService);
        }
        #endregion Function
    }
}
