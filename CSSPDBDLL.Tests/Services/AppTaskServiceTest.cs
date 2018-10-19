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
using Microsoft.QualityTools.Testing.Fakes;
using CSSPWebToolsDBDLL.Services.Fakes;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for AppTaskServiceTest
    /// </summary>
    [TestClass]
    public class AppTaskServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "AppTask";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private AppTaskService appTaskService { get; set; }
        private AppTaskLanguageService appTaskLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private AppTaskModel appTaskModelNew { get; set; }
        private AppTask appTask { get; set; }
        private ShimAppTaskService shimAppTaskService { get; set; }
        private ShimAppTaskLanguageService shimAppTaskLanguageService { get; set; }
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
        public AppTaskServiceTest()
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
        public void AppTaskService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange
                Assert.IsNotNull(appTaskService);
                Assert.IsNotNull(appTaskService._AppTaskLanguageService);
                Assert.IsNotNull(appTaskService.db);
                Assert.IsNotNull(appTaskService.LanguageRequest);
                Assert.IsNotNull(appTaskService.User);
                Assert.AreEqual(user.Identity.Name, appTaskService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), appTaskService.LanguageRequest);
            }
        }
        [TestMethod]
        public void AppTaskService_AppTaskModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = AddAppTaskModel();
                    Assert.AreEqual("", appTaskModel.Error);

                    #region Good
                    appTaskModelNew.TVItemID = appTaskModel.TVItemID;
                    appTaskModelNew.TVItemID2 = appTaskModel.TVItemID;
                    FillAppTaskModel(appTaskModelNew);

                    string retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region TVItemID
                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.TVItemID = 0;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID), retStr);

                    appTaskModelNew.TVItemID = appTaskModel.TVItemID;
                    appTaskModelNew.TVItemID2 = appTaskModel.TVItemID;
                    FillAppTaskModel(appTaskModelNew);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TVItemID

                    #region TVItemID2
                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.TVItemID2 = 0;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID2), retStr);

                    appTaskModelNew.TVItemID = appTaskModel.TVItemID;
                    appTaskModelNew.TVItemID2 = appTaskModel.TVItemID;
                    FillAppTaskModel(appTaskModelNew);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TVItemID2

                    #region Command
                    int Min = 2;
                    int Max = 100;

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.Command = (AppTaskCommandEnum)100000;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AppTaskCommand), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.Command = AppTaskCommandEnum.MikeScenarioRunning;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AppTaskName

                    #region ErrorText
                    Max = 250;

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.ErrorText = null;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.ErrorText = randomService.RandomString("", Max + 1);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ErrorText, Max), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.ErrorText = randomService.RandomString("", Max - 1);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.ErrorText = randomService.RandomString("", Max);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ErrorText

                    #region StatusText
                    Max = 250;

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.StatusText = null;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.StatusText = randomService.RandomString("", Max + 1);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.StatusText, Max), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.StatusText = randomService.RandomString("", Max - 1);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.StatusText = randomService.RandomString("", Max);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion StatusText

                    #region Status

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.Status = (AppTaskStatusEnum)100000;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AppTaskStatus), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.Status = AppTaskStatusEnum.Completed;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AppTaskName

                    #region PercentCompleted
                    Min = 0;
                    Max = 100;

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.PercentCompleted = Min - 1;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PercentCompleted, Min, Max), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.PercentCompleted = Max + 1;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PercentCompleted, Min, Max), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.PercentCompleted = Max - 1;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.PercentCompleted = Min;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.PercentCompleted = Max;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PercentCompleted

                    #region Parameters
                    Min = 2;
                    Max = 1000;

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.Parameters = randomService.RandomString("", Min - 1);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.Parameters, Min), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.Parameters = randomService.RandomString("", Max + 1);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Parameters, Max), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.Parameters = randomService.RandomString("", Max - 1);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.Parameters = randomService.RandomString("", Min);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.Parameters = randomService.RandomString("", Max);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Parameters

                    #region Language
                    Min = 2;
                    Max = 2;

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.Language = (LanguageEnum)100000;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.Language = LanguageEnum.en;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Language

                    #region StartDateTime_Local
                    FillAppTaskModel(appTaskModelNew);
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAppTaskService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion StartDateTime_Local

                    #region EndDateTime_Local
                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.StartDateTime_UTC = DateTime.UtcNow;
                    appTaskModelNew.EndDateTime_UTC = appTaskModelNew.StartDateTime_UTC.AddHours(1);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.StartDateTime_UTC = DateTime.UtcNow;
                    appTaskModelNew.EndDateTime_UTC = appTaskModelNew.StartDateTime_UTC.AddHours(-1);

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDateTime_Local, ServiceRes.EndDateTime_Local), retStr);
                    #endregion EndDateTime_Local

                    #region EstimatedLength_second
                    Min = 0;
                    Max = 86400;

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.EstimatedLength_second = Min - 1;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.EstimatedLength_second, Min, Max), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.EstimatedLength_second = Max + 1;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.EstimatedLength_second, Min, Max), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.EstimatedLength_second = Max - 1;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.EstimatedLength_second = Min;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.EstimatedLength_second = Max;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion EstimatedLength_second

                    #region RemainingTime_second
                    Min = 0;
                    Max = 86400;

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.RemainingTime_second = Min - 1;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.RemainingTime_second, Min, Max), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.RemainingTime_second = Max + 1;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.RemainingTime_second, Min, Max), retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.RemainingTime_second = Max - 1;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.RemainingTime_second = Min;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskModel(appTaskModelNew);
                    appTaskModelNew.RemainingTime_second = Max;

                    retStr = appTaskService.AppTaskModelOK(appTaskModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion RemainingTime_second
                }
            }
        }
        [TestMethod]
        public void AppTaskService_FillAppTask_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModel.Error);

                    appTaskModelNew.TVItemID = tvItemModel.TVItemID;
                    appTaskModelNew.TVItemID2 = appTaskModelNew.TVItemID;
                    FillAppTaskModel(appTaskModelNew);

                    ContactOK contactOK = appTaskService.IsContactOK();

                    string retStr = appTaskService.FillAppTask(appTask, appTaskModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, appTask.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = appTaskService.FillAppTask(appTask, appTaskModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, appTask.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void AppTaskService_CheckAppTask_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RemoveAllTask();

                    AppTaskModel appTaskModelRet = AddAppTaskModel();
                    appTaskModelRet.Status = AppTaskStatusEnum.Created;

                    AppTaskModel appTaskModelRet2 = appTaskService.PostUpdateAppTask(appTaskModelRet);

                    AppTaskModel appTaskModelRet3 = appTaskService.CheckAppTask();
                    Assert.AreEqual(appTaskModelRet2.AppTaskID, appTaskModelRet3.AppTaskID);

                    List<AppTaskModel> appTaskModelList = appTaskService.GetAppTaskModelListDB();
                    foreach (AppTaskModel appTaskModel in appTaskModelList)
                    {
                        AppTaskModel appTaskModelRet4 = appTaskService.PostDeleteAppTaskDB(appTaskModel.AppTaskID);
                        Assert.AreEqual("", appTaskModelRet4.Error);
                    }

                    AppTaskModel appTaskModelRet5 = appTaskService.CheckAppTask();
                    Assert.AreEqual(ServiceRes.NoNewTaskToRun, appTaskModelRet5.Error);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_GetAppTaskModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    int appTaskCount = appTaskService.GetAppTaskModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, appTaskCount);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_GetAppTaskModelCountWithAppTaskStatusDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RemoveAllTask();

                    AppTaskModel appTaskModelRet = AddAppTaskModel();
                    appTaskModelRet.Status = AppTaskStatusEnum.Created;

                    AppTaskModel appTaskModelRet2 = appTaskService.PostUpdateAppTask(appTaskModelRet);

                    int Count = appTaskService.GetAppTaskModelCountWithAppTaskStatusDB(appTaskModelRet.Status);
                    Assert.AreEqual(1, Count);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_GetAppTaskModelListDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    List<AppTaskModel> appTaskModelList = appTaskService.GetAppTaskModelListDB();
                    Assert.AreEqual(testDBService.Count + 1, appTaskModelList.Count);

                }
            }
        }
        [TestMethod]
        public void AppTaskService_GetAppTaskModelCountWithAppTaskStatusDB_With_MikeScenarioToCancel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RemoveAllTask();

                    AppTaskModel appTaskModelRet = AddAppTaskModel();
                    appTaskModelRet.Status = AppTaskStatusEnum.Running;
                    appTaskModelRet.Command = AppTaskCommandEnum.MikeScenarioToCancel;

                    AppTaskModel appTaskModelRet2 = appTaskService.PostUpdateAppTask(appTaskModelRet);

                    List<AppTaskModel> appTaskModelList = appTaskService.GetAppTaskModelListOfRunningMikeScenariosDB();
                    Assert.IsTrue(appTaskModelList.Count > 0);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_GetAppTaskModelCountWithAppTaskStatusDB_With_MikeScenarioRunning_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RemoveAllTask();

                    AppTaskModel appTaskModelRet = AddAppTaskModel();
                    appTaskModelRet.Status = AppTaskStatusEnum.Running;
                    appTaskModelRet.Command = AppTaskCommandEnum.MikeScenarioRunning;

                    AppTaskModel appTaskModelRet2 = appTaskService.PostUpdateAppTask(appTaskModelRet);

                    List<AppTaskModel> appTaskModelList = appTaskService.GetAppTaskModelListOfRunningMikeScenariosDB();
                    Assert.IsTrue(appTaskModelList.Count > 0);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_GetAppTaskModelCountWithAppTaskStatusDB_Zero_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RemoveAllTask();

                    AppTaskModel appTaskModelRet = AddAppTaskModel();
                    appTaskModelRet.Status = AppTaskStatusEnum.Created;

                    AppTaskModel appTaskModelRet2 = appTaskService.PostUpdateAppTask(appTaskModelRet);

                    List<AppTaskModel> appTaskModelList = appTaskService.GetAppTaskModelListOfRunningMikeScenariosDB();
                    Assert.IsTrue(appTaskModelList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_GetAppTaskModelWithAppTaskIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    AppTaskModel appTaskModelRet2 = appTaskService.GetAppTaskModelWithAppTaskIDDB(appTaskModelRet.AppTaskID);
                    Assert.AreEqual(appTaskModelRet.AppTaskID, appTaskModelRet2.AppTaskID);

                    int AppTaskID = 0;
                    AppTaskModel appTaskModelRet3 = appTaskService.GetAppTaskModelWithAppTaskIDDB(AppTaskID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.AppTask, ServiceRes.AppTaskID, AppTaskID), appTaskModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_GetAppTaskModelListWithTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    List<AppTaskModel> appTaskModelList = appTaskService.GetAppTaskModelListWithTVItemIDDB(appTaskModelRet.TVItemID);
                    Assert.IsTrue(appTaskModelList.Count > 0);

                }
            }
        }
        [TestMethod]
        public void AppTaskService_GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    AppTaskModel appTaskModelRet2 = appTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(appTaskModelRet.TVItemID, appTaskModelRet.TVItemID2, appTaskModelRet.Command);
                    Assert.AreEqual(appTaskModelRet.TVItemID, appTaskModelRet2.TVItemID);
                    Assert.AreEqual(appTaskModelRet.TVItemID2, appTaskModelRet2.TVItemID2);
                    Assert.AreEqual(appTaskModelRet.Command, appTaskModelRet2.Command);

                    appTaskModelRet2.Command = (AppTaskCommandEnum)10000;
                    AppTaskModel appTaskModelRet3 = appTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(appTaskModelRet2.TVItemID, appTaskModelRet2.TVItemID2, appTaskModelRet2.Command);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.AppTask, ServiceRes.TVItemID + "," + ServiceRes.TVItemID2 + "," + ServiceRes.AppTaskCommand, appTaskModelRet2.TVItemID + "," + appTaskModelRet2.TVItemID2 + "," + appTaskModelRet2.Command.ToString()), appTaskModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_GetAppTaskWithAppTaskIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    AppTask appTaskRet2 = appTaskService.GetAppTaskWithAppTaskIDDB(appTaskModelRet.AppTaskID);
                    Assert.AreEqual(appTaskModelRet.AppTaskID, appTaskRet2.AppTaskID);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_GetAppTaskWithTVItemIDTVItemID2AndCommandDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    AppTask appTask = appTaskService.GetAppTaskWithTVItemIDTVItemID2AndCommandDB(appTaskModelRet.TVItemID, appTaskModelRet.TVItemID2, appTaskModelRet.Command);
                    Assert.AreEqual(appTaskModelRet.TVItemID, appTask.TVItemID);
                    Assert.AreEqual(appTaskModelRet.TVItemID2, appTask.TVItemID2);
                    Assert.AreEqual(appTaskModelRet.Command, (AppTaskCommandEnum)appTask.Command);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_GetAppTaskParamStr_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Parameters = "|||TVItemID,1|||FileGenerator,2|||FileGeneratorType,3|||Generate,1|||Command,0|||FileName,Root_2014_3_14_en.html";

                    string retStr = appTaskService.GetAppTaskParamStr(Parameters, "TVItemID");
                    Assert.AreEqual("1", retStr);

                    retStr = appTaskService.GetAppTaskParamStr(Parameters, "FileGenerator");
                    Assert.AreEqual("2", retStr);

                    retStr = appTaskService.GetAppTaskParamStr(Parameters, "FileGeneratorType");
                    Assert.AreEqual("3", retStr);

                    retStr = appTaskService.GetAppTaskParamStr(Parameters, "Generate");
                    Assert.AreEqual("1", retStr);

                    retStr = appTaskService.GetAppTaskParamStr(Parameters, "Command");
                    Assert.AreEqual("0", retStr);

                    retStr = appTaskService.GetAppTaskParamStr(Parameters, "DoesNotExist");
                    Assert.AreEqual("", retStr);

                    retStr = appTaskService.GetAppTaskParamStr(Parameters, "Gener");
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_RemoveCommaFromParamStr_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Param = "";

                    string retStr = appTaskService.RemoveCommaFromParamStr(Param);
                    Assert.AreEqual("", retStr);

                    Param = "test";

                    retStr = appTaskService.RemoveCommaFromParamStr(Param);
                    Assert.AreEqual("test", retStr);

                    Param = "test,bonjour";

                    retStr = appTaskService.RemoveCommaFromParamStr(Param);
                    Assert.AreEqual("test_bonjour", retStr);

                    Param = "test,bonjour,allo";

                    retStr = appTaskService.RemoveCommaFromParamStr(Param);
                    Assert.AreEqual("test_bonjour_allo", retStr);

                    Param = "test,,,,,bon";

                    retStr = appTaskService.RemoveCommaFromParamStr(Param);
                    Assert.AreEqual("test_____bon", retStr);

                }
            }
        }
        [TestMethod]
        public void AppTaskService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    AppTaskModel appTaskModel = appTaskService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, appTaskModel.Error);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostAddUpdateDeleteAppTask_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    AppTaskModel appTaskModelRet2 = UpdateAppTaskModel(appTaskModelRet);

                    AppTaskModel appTaskModelRet3 = appTaskService.PostDeleteAppTaskDB(appTaskModelRet2.AppTaskID);
                    Assert.AreEqual("", appTaskModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostAddAppTaskDB_AppTaskModelOK_Error_Test()
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
                        shimAppTaskService.AppTaskModelOKAppTaskModel = (a) =>
                        {
                            return ErrorText;
                        };

                        AppTaskModel appTaskModelRet = AddAppTaskModel();
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostAddAppTaskDB_IsContactOK_Error_Test()
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
                        shimAppTaskService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet = AddAppTaskModel();
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostAddAppTaskDB_GetAppTaskModelWithTVItemIDTVItemID2AndAppTaskNameDB_Error_Test()
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
                        shimAppTaskService.GetAppTaskWithTVItemIDTVItemID2AndCommandDBInt32Int32AppTaskCommandEnum = (a, b, c) =>
                        {
                            return new AppTask();
                        };

                        AppTaskModel appTaskModelRet = AddAppTaskModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask), appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostAddAppTaskDB_FillAppTaskModel_Error_Test()
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
                        shimAppTaskService.FillAppTaskAppTaskAppTaskModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        AppTaskModel appTaskModelRet = AddAppTaskModel();
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostAddAppTaskDB_DoAddChanges_Error_Test()
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
                        shimAppTaskService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        AppTaskModel appTaskModelRet = AddAppTaskModel();
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostAddAppTaskDB_Add_Error_Test()
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
                        shimAppTaskService.FillAppTaskAppTaskAppTaskModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        AppTaskModel appTaskModelRet = AddAppTaskModel();
                        Assert.IsTrue(appTaskModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostAddAppTaskDB_PostAddAppTaskLanguageDB_Error_Test()
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
                        shimAppTaskLanguageService.PostAddAppTaskLanguageDBAppTaskLanguageModel = (a) =>
                        {
                            return new AppTaskLanguageModel() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet = AddAppTaskModel();
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostAddAppTaskDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();
                    Assert.IsNotNull(appTaskModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, appTaskModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostAddAppTaskDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();
                    Assert.IsNotNull(appTaskModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, appTaskModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostDeleteAppTask_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppTaskService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRe2 = appTaskService.PostDeleteAppTaskDB(appTaskModelRet.AppTaskID);
                        Assert.AreEqual(ErrorText, appTaskModelRe2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostDeleteAppTask_GetAppTaskWithAppTaskIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAppTaskService.GetAppTaskWithAppTaskIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        AppTaskModel appTaskModelRet2 = appTaskService.PostDeleteAppTaskDB(appTaskModelRet.AppTaskID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.AppTask), appTaskModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostDeleteAppTask_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppTaskService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        AppTaskModel appTaskModelRet2 = appTaskService.PostDeleteAppTaskDB(appTaskModelRet.AppTaskID);
                        Assert.AreEqual(ErrorText, appTaskModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostUpdateAppTask_AppTaskModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppTaskService.AppTaskModelOKAppTaskModel = (a) =>
                        {
                            return ErrorText;
                        };

                        AppTaskModel appTaskModelRet2 = UpdateAppTaskModel(appTaskModelRet);
                        Assert.AreEqual(ErrorText, appTaskModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostUpdateAppTask_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppTaskService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet2 = UpdateAppTaskModel(appTaskModelRet);
                        Assert.AreEqual(ErrorText, appTaskModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostUpdateAppTask_GetAppTaskWithAppTaskIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAppTaskService.GetAppTaskWithAppTaskIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        AppTaskModel appTaskModelRet2 = UpdateAppTaskModel(appTaskModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.AppTask), appTaskModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostUpdateAppTask_FillAppTask_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppTaskService.FillAppTaskAppTaskAppTaskModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        AppTaskModel appTaskModelRet2 = UpdateAppTaskModel(appTaskModelRet);
                        Assert.AreEqual(ErrorText, appTaskModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostUpdateAppTask_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppTaskService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        AppTaskModel appTaskModelRet2 = UpdateAppTaskModel(appTaskModelRet);
                        Assert.AreEqual(ErrorText, appTaskModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskService_PostUpdateAppTask_PostUpdateAppTaskLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelRet = AddAppTaskModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.PostUpdateAppTaskLanguageDBAppTaskLanguageModel = (a) =>
                        {
                            return new AppTaskLanguageModel() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet2 = UpdateAppTaskModel(appTaskModelRet);
                        Assert.AreEqual(ErrorText, appTaskModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public AppTaskModel AddAppTaskModel()
        {
            TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Municipality);

            Assert.AreEqual("", tvItemModel.Error);

            appTaskModelNew.TVItemID = tvItemModel.TVItemID;
            appTaskModelNew.TVItemID2 = tvItemModel.TVItemID;
            FillAppTaskModel(appTaskModelNew);

            AppTaskModel appTaskModelRet = appTaskService.PostAddAppTask(appTaskModelNew);
            if (!string.IsNullOrWhiteSpace(appTaskModelRet.Error))
            {
                return appTaskModelRet;
            }

            CompareAppTaskModels(appTaskModelNew, appTaskModelRet);

            return appTaskModelRet;
        }
        private AppTaskModel UpdateAppTaskModel(AppTaskModel appTaskModelRet)
        {
            FillAppTaskModel(appTaskModelRet);

            AppTaskModel appTaskModelRet2 = appTaskService.PostUpdateAppTask(appTaskModelRet);
            if (!string.IsNullOrWhiteSpace(appTaskModelRet2.Error))
            {
                return appTaskModelRet2;
            }

            CompareAppTaskModels(appTaskModelRet, appTaskModelRet2);

            return appTaskModelRet2;
        }
        private void CompareAppTaskModels(AppTaskModel appTaskModelNew, AppTaskModel appTaskModelRet)
        {
            Assert.AreEqual(appTaskModelNew.TVItemID, appTaskModelRet.TVItemID);
            Assert.AreEqual(appTaskModelNew.TVItemID2, appTaskModelRet.TVItemID2);
            Assert.AreEqual(appTaskModelNew.Command, appTaskModelRet.Command);
            Assert.AreEqual(appTaskModelNew.ErrorText, appTaskModelRet.ErrorText);
            Assert.AreEqual(appTaskModelNew.StatusText, appTaskModelRet.StatusText);
            Assert.AreEqual(appTaskModelNew.Status, appTaskModelRet.Status);
            Assert.AreEqual(appTaskModelNew.PercentCompleted, appTaskModelRet.PercentCompleted);
            Assert.AreEqual(appTaskModelNew.Parameters, appTaskModelRet.Parameters);
            Assert.AreEqual(appTaskModelNew.Language, appTaskModelRet.Language);
            Assert.AreEqual(appTaskModelNew.EndDateTime_UTC, appTaskModelRet.EndDateTime_UTC);
            Assert.AreEqual(appTaskModelNew.StartDateTime_UTC, appTaskModelRet.StartDateTime_UTC);
            Assert.AreEqual(appTaskModelNew.EstimatedLength_second, appTaskModelRet.EstimatedLength_second);
            Assert.AreEqual(appTaskModelNew.RemainingTime_second, appTaskModelRet.RemainingTime_second);

            foreach (LanguageEnum Lang in appTaskService.LanguageListAllowable)
            {
                AppTaskLanguageModel appTaskLanguageModel = appTaskService._AppTaskLanguageService.GetAppTaskLanguageModelWithAppTaskIDAndLanguageDB(appTaskModelRet.AppTaskID, Lang);
                Assert.AreEqual("", appTaskLanguageModel.Error);

                if (Lang == appTaskService.LanguageRequest)
                {
                    Assert.AreEqual(appTaskModelRet.ErrorText, appTaskLanguageModel.ErrorText);
                    Assert.AreEqual(appTaskModelRet.StatusText, appTaskLanguageModel.StatusText);
                }
            }
        }
        private void FillAppTaskModel(AppTaskModel appTaskModel)
        {
            appTaskModel.TVItemID = appTaskModel.TVItemID;
            appTaskModel.TVItemID2 = appTaskModel.TVItemID2;
            appTaskModel.Command = AppTaskCommandEnum.MikeScenarioImport;
            appTaskModel.ErrorText = randomService.RandomString("ErrorText", 20);
            appTaskModel.StatusText = randomService.RandomString("StatusText", 20);
            appTaskModel.Status = AppTaskStatusEnum.Completed;
            appTaskModel.PercentCompleted = randomService.RandomInt(0, 100);
            appTaskModel.Parameters = randomService.RandomString("TVPath,p1p5|||", "TVPath,p1p5|||".Length);
            appTaskModel.Language = LanguageEnum.en;
            appTaskModel.StartDateTime_UTC = randomService.RandomDateTime();
            appTaskModel.EndDateTime_UTC = appTaskModel.StartDateTime_UTC.AddHours(1);
            appTaskModel.EstimatedLength_second = randomService.RandomInt(0, 86400);
            appTaskModel.RemainingTime_second = randomService.RandomInt(0, 86400);

            Assert.IsTrue(appTaskModel.TVItemID != 0);
            Assert.IsTrue(appTaskModel.TVItemID2 != 0);
            Assert.IsTrue(appTaskModel.Command == AppTaskCommandEnum.MikeScenarioImport);
            Assert.IsTrue(appTaskModel.ErrorText.Length == 20);
            Assert.IsTrue(appTaskModel.StatusText.Length == 20);
            Assert.IsTrue(appTaskModel.Status == AppTaskStatusEnum.Completed);
            Assert.IsTrue(appTaskModel.PercentCompleted >= 0 && appTaskModel.PercentCompleted <= 100);
            Assert.IsTrue(appTaskModel.Parameters == "TVPath,p1p5|||");
            Assert.IsTrue(appTaskModel.Language == LanguageEnum.en);
            Assert.IsTrue(appTaskModel.EndDateTime_UTC != null);
            Assert.IsTrue(appTaskModel.StartDateTime_UTC != null);
            Assert.IsTrue(appTaskModel.EstimatedLength_second >= 0 && appTaskModel.EstimatedLength_second <= 86400);
            Assert.IsTrue(appTaskModel.RemainingTime_second >= 0 && appTaskModel.RemainingTime_second <= 86400);
        }
        private void RemoveAllTask()
        {
            List<AppTaskModel> appTaskModelList = appTaskService.GetAppTaskModelListDB();
            foreach (AppTaskModel appTaskModel in appTaskModelList)
            {
                AppTaskModel appTaskModelRet = appTaskService.PostDeleteAppTaskDB(appTaskModel.AppTaskID);
                Assert.AreEqual("", appTaskModelRet.Error);
            }
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            appTaskService = new AppTaskService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            appTaskLanguageService = new AppTaskLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            appTaskModelNew = new AppTaskModel();
            appTask = new AppTask();
        }
        private void SetupShim()
        {
            shimAppTaskService = new ShimAppTaskService(appTaskService);
            shimAppTaskLanguageService = new ShimAppTaskLanguageService(appTaskService._AppTaskLanguageService);
        }
        #endregion Functions private
    }
}

