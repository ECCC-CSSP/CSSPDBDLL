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
    public class AppTaskLanguageServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "AppTaskLanguage";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private AppTaskLanguageService appTaskLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private AppTaskLanguageModel appTaskLanguageModelNew { get; set; }
        private AppTaskLanguage appTaskLanguage { get; set; }
        private ShimAppTaskLanguageService shimAppTaskLanguageService { get; set; }
        private AppTaskServiceTest appTaskServiceTest { get; set; }
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
        public AppTaskLanguageServiceTest()
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
        public void AppTaskLanguageService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(appTaskLanguageService);
                Assert.IsNotNull(appTaskLanguageService.db);
                Assert.IsNotNull(appTaskLanguageService.LanguageRequest);
                Assert.IsNotNull(appTaskLanguageService.User);
                Assert.AreEqual(user.Identity.Name, appTaskLanguageService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), appTaskLanguageService.LanguageRequest);
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_AppTaskLanguageModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                LanguageEnum LangToAdd = LanguageEnum.es;

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskLanguageModel appTaskLanguageModel = AddAppTaskLanguageModel(LangToAdd);
                    Assert.AreEqual("", appTaskLanguageModel.Error);

                    #region AppTaskID
                    appTaskLanguageModelNew.AppTaskID = appTaskLanguageModel.AppTaskID;
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);
                    appTaskLanguageModelNew.AppTaskID = 0;

                    string retStr = appTaskLanguageService.AppTaskLanguageModelOK(appTaskLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AppTaskID), retStr);

                    appTaskLanguageModelNew.AppTaskID = appTaskLanguageModel.AppTaskID;
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                    retStr = appTaskLanguageService.AppTaskLanguageModelOK(appTaskLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AppTaskID

                    #region Language
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);
                    appTaskLanguageModelNew.Language = LanguageEnum.en;

                    retStr = appTaskLanguageService.AppTaskLanguageModelOK(appTaskLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);
                    appTaskLanguageModelNew.Language = (LanguageEnum)10000;

                    retStr = appTaskLanguageService.AppTaskLanguageModelOK(appTaskLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);
                    #endregion Language

                    #region ErrorText
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);
                    int Max = 250;
                    appTaskLanguageModelNew.ErrorText = randomService.RandomString("", 0);

                    retStr = appTaskLanguageService.AppTaskLanguageModelOK(appTaskLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);
                    appTaskLanguageModelNew.ErrorText = randomService.RandomString("", Max + 1);

                    retStr = appTaskLanguageService.AppTaskLanguageModelOK(appTaskLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ErrorText, Max), retStr);

                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);
                    appTaskLanguageModelNew.ErrorText = randomService.RandomString("", Max - 1);

                    retStr = appTaskLanguageService.AppTaskLanguageModelOK(appTaskLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);
                    appTaskLanguageModelNew.ErrorText = randomService.RandomString("", Max);

                    retStr = appTaskLanguageService.AppTaskLanguageModelOK(appTaskLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ErrorText

                    #region StatusText
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);
                    Max = 250;
                    appTaskLanguageModelNew.StatusText = randomService.RandomString("", 0);

                    retStr = appTaskLanguageService.AppTaskLanguageModelOK(appTaskLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);
                    appTaskLanguageModelNew.StatusText = randomService.RandomString("", Max + 1);

                    retStr = appTaskLanguageService.AppTaskLanguageModelOK(appTaskLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.StatusText, Max), retStr);

                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);
                    appTaskLanguageModelNew.StatusText = randomService.RandomString("", Max - 1);

                    retStr = appTaskLanguageService.AppTaskLanguageModelOK(appTaskLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);
                    appTaskLanguageModelNew.StatusText = randomService.RandomString("", Max);

                    retStr = appTaskLanguageService.AppTaskLanguageModelOK(appTaskLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion StatusText
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_FillAppTaskLanguage_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();
                    Assert.AreEqual("", appTaskModel.Error);

                    LanguageEnum LangToAdd = LanguageEnum.es;
                    appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                    ContactOK contactOK = appTaskLanguageService.IsContactOK();

                    string retStr = appTaskLanguageService.FillAppTaskLanguage(appTaskLanguage, appTaskLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, appTaskLanguage.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = appTaskLanguageService.FillAppTaskLanguage(appTaskLanguage, appTaskLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, appTaskLanguage.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_GetAppTaskModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    AppTaskLanguageModel appTaskModelLanguageRet = AddAppTaskLanguageModel(LangToAdd);
                    Assert.AreEqual("", appTaskModelLanguageRet.Error);

                    int appTaskCount = appTaskLanguageService.GetAppTaskLanguageModelCountDB();
                    Assert.AreEqual(testDBService.Count + 3, appTaskCount);
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_GetAppTaskLanguageModelWithAppTaskIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    AppTaskLanguageModel appTaskLanguageModelRet = AddAppTaskLanguageModel(LangToAdd);
                    Assert.AreEqual("", appTaskLanguageModelRet.Error);

                    AppTaskLanguageModel appTaskLanguageModelRet2 = appTaskLanguageService.GetAppTaskLanguageModelWithAppTaskIDAndLanguageDB(appTaskLanguageModelRet.AppTaskID, LangToAdd);
                    Assert.AreEqual(appTaskLanguageModelRet.AppTaskID, appTaskLanguageModelRet2.AppTaskID);
                    Assert.AreEqual(appTaskLanguageModelRet.Language, appTaskLanguageModelRet2.Language);
                    Assert.AreEqual(LangToAdd, appTaskLanguageModelRet2.Language);
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_GetAppTaskLanguageWithAppTaskIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    AppTaskLanguageModel appTaskLanguageModelRet = AddAppTaskLanguageModel(LangToAdd);
                    Assert.AreEqual("", appTaskLanguageModelRet.Error);

                    AppTaskLanguage appTaskLanguageRet2 = appTaskLanguageService.GetAppTaskLanguageWithAppTaskIDAndLanguageDB(appTaskLanguageModelRet.AppTaskID, LangToAdd);
                    Assert.AreEqual(appTaskLanguageModelRet.AppTaskID, appTaskLanguageRet2.AppTaskID);
                    Assert.AreEqual(appTaskLanguageModelRet.Language, (LanguageEnum)appTaskLanguageRet2.Language);
                    Assert.AreEqual(LangToAdd, (LanguageEnum)appTaskLanguageRet2.Language);
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostAddAppTaskLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    AppTaskLanguageModel appTaskLanguageModelRet = AddAppTaskLanguageModel(LangToAdd);
                    Assert.AreEqual("", appTaskLanguageModelRet.Error);

                    AppTaskLanguageModel appTaskLanguageModelRet2 = UpdateAppTaskLanguageModel(LangToAdd, appTaskLanguageModelRet);

                    AppTaskLanguageModel appTaskLanguageModelRet3 = appTaskLanguageService.PostDeleteAppTaskLanguageDB(appTaskLanguageModelRet.AppTaskID, LangToAdd);
                    Assert.AreEqual("", appTaskLanguageModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostAddAppTaskLanguageDB_AppTaskLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();
                    Assert.AreEqual("", appTaskModel.Error);

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    using (ShimsContext.Create())
                    {

                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAppTaskLanguageService.AppTaskLanguageModelOKAppTaskLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                        FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                        AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);

                        Assert.AreEqual(ErrorText, appTaskLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostAddAppTaskLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();
                    Assert.AreEqual("", appTaskModel.Error);

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                        FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                        AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);

                        Assert.AreEqual(ErrorText, appTaskLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostAddAppTaskLanguageDB_GetAppTaskLanguageModelWithAppTaskIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();
                    Assert.AreEqual("", appTaskModel.Error);

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        //string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.GetAppTaskLanguageModelWithAppTaskIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new AppTaskLanguageModel();
                        };

                        appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                        FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                        AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);

                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTaskLanguage), appTaskLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostAddAppTaskLanguageDB_FillAppTaskLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();
                    Assert.AreEqual("", appTaskModel.Error);

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.FillAppTaskLanguageAppTaskLanguageAppTaskLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                        FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                        AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);
                        Assert.AreEqual(ErrorText, appTaskLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostAddAppTaskLanguageDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();
                    Assert.AreEqual("", appTaskModel.Error);

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                        FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                        AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);
                        Assert.AreEqual(ErrorText, appTaskLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostAddAppTaskLanguageDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();
                    Assert.AreEqual("", appTaskModel.Error);

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        //string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.FillAppTaskLanguageAppTaskLanguageAppTaskLanguageModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                        FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                        AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);
                        Assert.IsTrue(appTaskLanguageModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostDeleteAppTaskLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                    AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AppTaskLanguageModel appTaskLanguageModelRet3 = appTaskLanguageService.PostDeleteAppTaskLanguageDB(appTaskLanguageModelRet.AppTaskID, LangToAdd);
                        Assert.AreEqual(ErrorText, appTaskLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostDeleteAppTaskLanguageDB_GetAppTaskLanguageWithAppTaskIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                    AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.GetAppTaskLanguageWithAppTaskIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        AppTaskLanguageModel appTaskLanguageModelRet3 = appTaskLanguageService.PostDeleteAppTaskLanguageDB(appTaskLanguageModelRet.AppTaskID, LangToAdd);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.AppTaskLanguage), appTaskLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostDeleteAppTaskLanguageDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                    AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);

                    appTaskLanguageModelRet.StatusText = "New Value" + appTaskLanguageModelRet.StatusText;
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        AppTaskLanguageModel appTaskLanguageModelRet2 = appTaskLanguageService.PostDeleteAppTaskLanguageDB(appTaskLanguageModelRet.AppTaskID, LangToAdd);
                        Assert.AreEqual(ErrorText, appTaskLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostUpdateAppTaskLanguageDB_AppTaskLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                    AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelRet);
                        string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.AppTaskLanguageModelOKAppTaskLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        AppTaskLanguageModel appTaskLanguageModelRet2 = UpdateAppTaskLanguageModel(LangToAdd, appTaskLanguageModelRet);
                        Assert.AreEqual(ErrorText, appTaskLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostUpdateAppTaskLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                    AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AppTaskLanguageModel appTaskLanguageModelRet2 = UpdateAppTaskLanguageModel(LangToAdd, appTaskLanguageModelRet);
                        Assert.AreEqual(ErrorText, appTaskLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostUpdateAppTaskLanguageDB_GetAppTaskLanguageWithAppTaskIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                    AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelRet);

                        //string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.GetAppTaskLanguageWithAppTaskIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        AppTaskLanguageModel appTaskLanguageModelRet2 = UpdateAppTaskLanguageModel(LangToAdd, appTaskLanguageModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.AppTaskLanguage), appTaskLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostUpdateAppTaskLanguageDB_FillAppTaskLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                    AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.FillAppTaskLanguageAppTaskLanguageAppTaskLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        AppTaskLanguageModel appTaskLanguageModelRet2 = UpdateAppTaskLanguageModel(LangToAdd, appTaskLanguageModelRet);
                        Assert.AreEqual(ErrorText, appTaskLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostUpdateAppTaskLanguageDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
                    FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

                    AppTaskLanguageModel appTaskLanguageModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimAppTaskLanguageService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        AppTaskLanguageModel appTaskLanguageModelRet2 = UpdateAppTaskLanguageModel(LangToAdd, appTaskLanguageModelRet);
                        Assert.AreEqual(ErrorText, appTaskLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostAddAppTaskLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                LanguageEnum LangToAdd = LanguageEnum.es;

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskLanguageModel appTaskLanguageModelRet = AddAppTaskLanguageModel(LangToAdd);

                    // Assert 1
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, appTaskLanguageModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void AppTaskLanguageService_PostAddAppTaskLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                LanguageEnum LangToAdd = LanguageEnum.es;

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskLanguageModel appTaskLanguageModelRet = AddAppTaskLanguageModel(LangToAdd);

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, appTaskLanguageModelRet.Error);
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private AppTaskLanguageModel AddAppTaskLanguageModel(LanguageEnum LangToAdd)
        {
            AppTaskModel appTaskModel = appTaskServiceTest.AddAppTaskModel();
            if (!string.IsNullOrWhiteSpace(appTaskModel.Error))
            {
                return new AppTaskLanguageModel() { Error = appTaskModel.Error };
            }

            appTaskLanguageModelNew.AppTaskID = appTaskModel.AppTaskID;
            FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelNew);

            AppTaskLanguageModel appTaskLanguagModelRet = appTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);
            if (!string.IsNullOrWhiteSpace(appTaskLanguagModelRet.Error))
            {
                return appTaskLanguagModelRet;
            }

            CompareAppTaskLanguageModels(appTaskLanguageModelNew, appTaskLanguagModelRet);

            return appTaskLanguagModelRet;
        }
        private void CompareAppTaskLanguageModels(AppTaskLanguageModel appTaskLanguageModelNew, AppTaskLanguageModel appTaskLanguageModelRet)
        {
            Assert.AreEqual(appTaskLanguageModelNew.Language, appTaskLanguageModelRet.Language);
            Assert.AreEqual(appTaskLanguageModelNew.ErrorText, appTaskLanguageModelRet.ErrorText);
            Assert.AreEqual(appTaskLanguageModelNew.StatusText, appTaskLanguageModelRet.StatusText);
        }
        private void FillAppTaskLanguageModel(LanguageEnum Language, AppTaskLanguageModel appTaskLanguageModel)
        {
            appTaskLanguageModel.AppTaskID = appTaskLanguageModel.AppTaskID;
            appTaskLanguageModel.Language = Language;
            appTaskLanguageModel.ErrorText = randomService.RandomString("Error Text", 20);
            appTaskLanguageModel.StatusText = randomService.RandomString("Status Text", 20);
            appTaskLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(appTaskLanguageModel.AppTaskID != 0);
            Assert.IsTrue(appTaskLanguageModel.Language == Language);
            Assert.IsTrue(appTaskLanguageModel.ErrorText.Length == 20);
            Assert.IsTrue(appTaskLanguageModel.StatusText.Length == 20);
            Assert.IsTrue(appTaskLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private AppTaskLanguageModel UpdateAppTaskLanguageModel(LanguageEnum LangToAdd, AppTaskLanguageModel appTaskLanguageModelRet)
        {
            FillAppTaskLanguageModel(LangToAdd, appTaskLanguageModelRet);

            AppTaskLanguageModel appTaskLanguageModelRet2 = appTaskLanguageService.PostUpdateAppTaskLanguageDB(appTaskLanguageModelRet);
            if (!string.IsNullOrWhiteSpace(appTaskLanguageModelRet2.Error))
            {
                return appTaskLanguageModelRet2;
            }

            Assert.IsNotNull(appTaskLanguageModelRet2);
            CompareAppTaskLanguageModels(appTaskLanguageModelRet, appTaskLanguageModelRet2);

            return appTaskLanguageModelRet2;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            appTaskLanguageService = new AppTaskLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            appTaskLanguageModelNew = new AppTaskLanguageModel();
            appTaskLanguage = new AppTaskLanguage();
            appTaskServiceTest = new AppTaskServiceTest();
            appTaskServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimAppTaskLanguageService = new ShimAppTaskLanguageService(appTaskLanguageService);
        }
        #endregion Functions private
    }
}

