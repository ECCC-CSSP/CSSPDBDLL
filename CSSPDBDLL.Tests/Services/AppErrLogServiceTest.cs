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
using CSSPWebToolsDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Threading;
using System.Globalization;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for AppErrLogServiceTest
    /// </summary>
    [TestClass]
    public class AppErrLogServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "AppErrLog";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private AppErrLogService appErrLogService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private AppErrLogModel appErrLogModelNew { get; set; }
        private AppErrLog appErrLog { get; set; }
        private ShimAppErrLogService shimAppErrLogService { get; set; }
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
        public AppErrLogServiceTest()
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
        public void AppErrLogService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(appErrLogService.db);
                Assert.IsNotNull(appErrLogService.LanguageRequest);
                Assert.IsNotNull(appErrLogService.User);
                Assert.AreEqual(user.Identity.Name, appErrLogService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), appErrLogService.LanguageRequest);
            }
        }
        [TestMethod]
        public void AppErrLogService_AppErrLogModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    #region Tag
                    int Min = 2;
                    int Max = 100;

                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Tag = randomService.RandomString("Tag", Min - 1);

                    string retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.Tag, Min), retStr);

                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Tag = randomService.RandomString("Tag", Max + 1);

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Tag, Max), retStr);

                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Tag = randomService.RandomString("Tag", Max - 1);

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Tag = randomService.RandomString("Tag", Max);

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Tag = randomService.RandomString("Tag", Min);

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Tag

                    #region Source
                    Max = 1000;
                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Source = "";

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Source), retStr);

                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Source = randomService.RandomString("Source", Max + 1);

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Source, Max), retStr);

                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Source = randomService.RandomString("Source", Max - 1);

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Source = randomService.RandomString("Source", Max);

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Source

                    #region Message
                    Max = 1000;
                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Message = "";

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Message), retStr);

                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Message = randomService.RandomString("Message", Max + 1);

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Message, Max), retStr);

                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Message = randomService.RandomString("Message", Max - 1);

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual("", retStr);

                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.Message = randomService.RandomString("Message", Max);

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Message

                    #region LineNumber
                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.LineNumber = 0;

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LineNumber), retStr);

                    FillAppErrLogModelNew(appErrLogModelNew);
                    appErrLogModelNew.LineNumber = 10;

                    retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion LineNumber

                    #region DateTime_Local
                    FillAppErrLogModelNew(appErrLogModelNew);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppErrLogService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = appErrLogService.AppErrLogModelOK(appErrLogModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion DataTime_Local
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_GetAppErrLogModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    int appErrLogCount = appErrLogService.GetAppErrLogModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, appErrLogCount);

                }
            }
        }
        [TestMethod]
        public void AppErrLogService_GetAppErrLogModelOrderByDateDescDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    int skip = 0;
                    int take = 100000;
                    List<AppErrLogModel> appErrLogModelList = appErrLogService.GetAppErrLogModelOrderByDateDescDB(skip, take);
                    Assert.AreEqual(testDBService.Count + 1, appErrLogModelList.Count);

                }
            }
        }
        [TestMethod]
        public void AppErrLogService_GetAppErrLogModelFilterSourceOrderByDateDescDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    int skip = 0;
                    int take = 100000;
                    string FilterSource = appErrLogModelNew.Source;
                    List<AppErrLogModel> appErrLogModelList = appErrLogService.GetAppErrLogModelFilterSourceOrderByDateDescDB(FilterSource, skip, take);
                    Assert.IsTrue(appErrLogModelList.Count >= 1);

                }
            }
        }
        [TestMethod]
        public void AppErrLogService_GetAppErrLogModelFilterMessageOrderByDateDescDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    int skip = 0;
                    int take = 100000;
                    string FilterMessage = appErrLogModelNew.Message;
                    List<AppErrLogModel> appErrLogModelList = appErrLogService.GetAppErrLogModelFilterMessageOrderByDateDescDB(FilterMessage, skip, take);
                    Assert.IsTrue(appErrLogModelList.Count >= 1);

                }
            }
        }
        [TestMethod]
        public void AppErrLogService_GetAppErrLogModelWithAppErrLogIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    AppErrLogModel appErrLogModelRet2 = appErrLogService.GetAppErrLogModelWithAppErrLogIDDB(appErrLogModelRet.AppErrLogID);
                    Assert.IsNotNull(appErrLogModelRet2);
                    CompareAppErrLogModels(appErrLogModelRet, appErrLogModelRet2);

                    int AppErrLogID = 0;
                    AppErrLogModel appErrLogModelRet3 = appErrLogService.GetAppErrLogModelWithAppErrLogIDDB(AppErrLogID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.AppErrLog, ServiceRes.AppErrLogID, AppErrLogID), appErrLogModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_GetAppErrLogWithAppErrLogIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    AppErrLog appErrLogRet2 = appErrLogService.GetAppErrLogWithAppErrLogIDDB(appErrLogModelRet.AppErrLogID);
                    Assert.IsNotNull(appErrLogRet2);
                    Assert.AreEqual(appErrLogModelRet.AppErrLogID, appErrLogRet2.AppErrLogID);

                    AppErrLog appErrLogRet3 = appErrLogService.GetAppErrLogWithAppErrLogIDDB(0);
                    Assert.IsNull(appErrLogRet3);
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_FillAppErrLog_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FillAppErrLogModelNew(appErrLogModelNew);

                    ContactOK contactOK = appErrLogService.IsContactOK();

                    string retStr = appErrLogService.FillAppErrLog(appErrLog, appErrLogModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, appErrLog.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = appErrLogService.FillAppErrLog(appErrLog, appErrLogModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, appErrLog.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void AppErrLogService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    string ErrorText = "ErrorText";
                    AppErrLogModel appErrLogModelRet2 = appErrLogService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, appErrLogModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostAddUpdateDeleteAppErrLog_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    AppErrLogModel appErrLogModelRet2 = UpdateAppErrLogModel(appErrLogModelRet);

                    AppErrLogModel appErrLogModelRet3 = appErrLogService.PostDeleteAppErrLogDB(appErrLogModelRet2.AppErrLogID);
                    Assert.AreEqual("", appErrLogModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostAddAppErrLogDB_AppErrLogModelOK_Error_Test()
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
                        shimAppErrLogService.AppErrLogModelOKAppErrLogModel = (a) =>
                        {
                            return ErrorText;
                        };

                        AppErrLogModel appErrLogModelRet = AddAppErrLogModel();
                        Assert.AreEqual(ErrorText, appErrLogModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostAddAppErrLogDB_IsContactOK_Error_Test()
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
                        shimAppErrLogService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AppErrLogModel appErrLogModelRet = AddAppErrLogModel();
                        Assert.AreEqual(ErrorText, appErrLogModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostAddAppErrLogDB_FillAppErrLog_Error_Test()
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
                        shimAppErrLogService.FillAppErrLogAppErrLogAppErrLogModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        AppErrLogModel appErrLogModelRet = AddAppErrLogModel();
                        Assert.AreEqual(ErrorText, appErrLogModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostAddAppErrLogDB_DoAddChanges_Error_Test()
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
                        shimAppErrLogService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        AppErrLogModel appErrLogModelRet = AddAppErrLogModel();
                        Assert.AreEqual(ErrorText, appErrLogModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostAddAppErrLogDB_Add_Error_Test()
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
                        shimAppErrLogService.FillAppErrLogAppErrLogAppErrLogModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        AppErrLogModel appErrLogModelRet = AddAppErrLogModel();
                        Assert.IsTrue(appErrLogModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostAddAppErrLogDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    Assert.IsNotNull(appErrLogModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, appErrLogModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostAddAppErrLogDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    Assert.IsNotNull(appErrLogModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, appErrLogModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostDeleteAppErrLog_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppErrLogService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AppErrLogModel appErrLogModelRet3 = appErrLogService.PostDeleteAppErrLogDB(appErrLogModelRet.AppErrLogID);
                        Assert.AreEqual(ErrorText, appErrLogModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostDeleteAppErrLog_GetAppErrLogWithAppErrLogIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAppErrLogService.GetAppErrLogWithAppErrLogIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        AppErrLogModel appErrLogModelRet3 = appErrLogService.PostDeleteAppErrLogDB(appErrLogModelRet.AppErrLogID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.AppErrLog), appErrLogModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostDeleteAppErrLog_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppErrLogService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        AppErrLogModel appErrLogModelRet2 = appErrLogService.PostDeleteAppErrLogDB(appErrLogModelRet.AppErrLogID);
                        Assert.AreEqual(ErrorText, appErrLogModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostUpdateAppErrLog_AppErrLogModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppErrLogService.AppErrLogModelOKAppErrLogModel = (a) =>
                        {
                            return ErrorText;
                        };

                        AppErrLogModel appErrLogModelRet2 = UpdateAppErrLogModel(appErrLogModelRet);
                        Assert.AreEqual(ErrorText, appErrLogModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostUpdateAppErrLog_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppErrLogService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AppErrLogModel appErrLogModelRet2 = UpdateAppErrLogModel(appErrLogModelRet);
                        Assert.AreEqual(ErrorText, appErrLogModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostUpdateAppErrLog_GetAppErrLogWithAppErrLogIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAppErrLogService.GetAppErrLogWithAppErrLogIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        AppErrLogModel appErrLogModelRet2 = UpdateAppErrLogModel(appErrLogModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.AppErrLog), appErrLogModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostUpdateAppErrLog_FillAppErrLog_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppErrLogService.FillAppErrLogAppErrLogAppErrLogModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        AppErrLogModel appErrLogModelRet2 = UpdateAppErrLogModel(appErrLogModelRet);
                        Assert.AreEqual(ErrorText, appErrLogModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AppErrLogService_PostUpdateAppErrLog_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel appErrLogModelRet = AddAppErrLogModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAppErrLogService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        AppErrLogModel appErrLogModelRet2 = UpdateAppErrLogModel(appErrLogModelRet);
                        Assert.AreEqual(ErrorText, appErrLogModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private AppErrLogModel AddAppErrLogModel()
        {
            FillAppErrLogModelNew(appErrLogModelNew);

            AppErrLogModel appErrLogModelRet = appErrLogService.PostAddAppErrLogDB(appErrLogModelNew);
            if (!string.IsNullOrWhiteSpace(appErrLogModelRet.Error))
            {
                return appErrLogModelRet;
            }
            Assert.IsNotNull(appErrLogModelRet);
            CompareAppErrLogModels(appErrLogModelNew, appErrLogModelRet);

            return appErrLogModelRet;
        }
        private AppErrLogModel UpdateAppErrLogModel(AppErrLogModel appErrLogModel)
        {
            FillAppErrLogModelUpdate(appErrLogModel);

            AppErrLogModel appErrLogModelRet = appErrLogService.PostUpdateAppErrLogDB(appErrLogModel);
            if (!string.IsNullOrWhiteSpace(appErrLogModelRet.Error))
            {
                return appErrLogModelRet;
            }
            Assert.IsNotNull(appErrLogModelRet);
            CompareAppErrLogModels(appErrLogModel, appErrLogModelRet);

            return appErrLogModelRet;
        }
        private void CompareAppErrLogModels(AppErrLogModel appErrLogModelNew, AppErrLogModel appErrLogModelRet)
        {
            Assert.AreEqual(appErrLogModelNew.Tag, appErrLogModelRet.Tag);
            Assert.AreEqual(appErrLogModelNew.DateTime_UTC, appErrLogModelRet.DateTime_UTC);
            Assert.AreEqual(appErrLogModelNew.LineNumber, appErrLogModelRet.LineNumber);
            Assert.AreEqual(appErrLogModelNew.Message, appErrLogModelRet.Message);
            Assert.AreEqual(appErrLogModelNew.Source, appErrLogModelRet.Source);
        }
        private void FillAppErrLogModelNew(AppErrLogModel appErrLogModel)
        {
            appErrLogModel.Tag = randomService.RandomString("Tag Text", 10);
            appErrLogModel.DateTime_UTC = randomService.RandomDateTime();
            appErrLogModel.LineNumber = randomService.RandomInt(5, 150);
            appErrLogModel.Message = randomService.RandomString("Message text", 20);
            appErrLogModel.Source = randomService.RandomString("Source text", 20);
            Assert.IsTrue(appErrLogModel.Tag.Length == 10);
            Assert.IsTrue(appErrLogModel.DateTime_UTC != null);
            Assert.IsTrue(appErrLogModel.LineNumber >= 5 && appErrLogModel.LineNumber <= 150);
            Assert.IsTrue(appErrLogModel.Message.Length == 20);
            Assert.IsTrue(appErrLogModel.Source.Length == 20);
        }
        private void FillAppErrLogModelUpdate(AppErrLogModel appErrLogModel)
        {
            appErrLogModel.Tag = randomService.RandomString("Tag Text2", 10);
            appErrLogModel.DateTime_UTC = randomService.RandomDateTime();
            appErrLogModel.LineNumber = randomService.RandomInt(500, 650);
            appErrLogModel.Message = randomService.RandomString("Message text2", 20);
            appErrLogModel.Source = randomService.RandomString("Source text2", 20);
            Assert.IsTrue(appErrLogModel.Tag.Length == 10);
            Assert.IsTrue(appErrLogModel.DateTime_UTC != null);
            Assert.IsTrue(appErrLogModel.LineNumber >= 500 && appErrLogModel.LineNumber <= 650);
            Assert.IsTrue(appErrLogModel.Message.Length == 20);
            Assert.IsTrue(appErrLogModel.Source.Length == 20);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            appErrLogService = new AppErrLogService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            appErrLogModelNew = new AppErrLogModel();
            appErrLog = new AppErrLog();
        }
        private void SetupShim()
        {
            shimAppErrLogService = new ShimAppErrLogService(appErrLogService);
        }
        #endregion Functions private
    }
}


