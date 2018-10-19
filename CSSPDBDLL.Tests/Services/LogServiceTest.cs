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
using CSSPWebToolsDBDLL.Models.Fakes;
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;
using System.Reflection;
using System.Linq;

namespace CSSPWebToolsDBDLL.Test.Services
{
    /// <summary>
    /// Summary description for LogServiceTest
    /// </summary>
    [TestClass]
    public class LogServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "Log";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private LogService logService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private LogModel logModelNew { get; set; }
        private Log log { get; set; }
        private ShimLogService shimLogService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLinkService shimTVItemLinkService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
        private TVItemService tvItemService { get; set; }
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
        public LogServiceTest()
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
        public void LogService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(logService);
                Assert.IsNotNull(logService.db);
                Assert.IsNotNull(logService.LanguageRequest);
                Assert.IsNotNull(logService.User);
                Assert.AreEqual(user.Identity.Name, logService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), logService.LanguageRequest);
            }
        }
        [TestMethod]
        public void LogService_LogModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModel = AddLogModel();
                    Assert.AreEqual("", logModel.Error);

                    #region TableName
                    int Min = 1;
                    int Max = 50;
                    FillLogModelNew(logModelNew);
                    logModelNew.TableName = randomService.RandomString("", Min - 1);

                    string retStr = logService.LogModelOK(logModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TableName), retStr);

                    FillLogModelNew(logModelNew);
                    logModelNew.TableName = randomService.RandomString("", Max + 1);

                    retStr = logService.LogModelOK(logModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.TableName, Max), retStr);

                    FillLogModelNew(logModelNew);
                    logModelNew.TableName = randomService.RandomString("", Min);

                    retStr = logService.LogModelOK(logModelNew);
                    Assert.AreEqual("", retStr);

                    FillLogModelNew(logModelNew);
                    logModelNew.TableName = randomService.RandomString("", Max);

                    retStr = logService.LogModelOK(logModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TableName

                    #region ID
                    FillLogModelNew(logModelNew);
                    logModelNew.ID = 0;

                    retStr = logService.LogModelOK(logModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Id), retStr);

                    FillLogModelNew(logModelNew);
                    logModelNew.ID = randomService.RandomTVItem(TVTypeEnum.Country).TVItemID;

                    retStr = logService.LogModelOK(logModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion LogTVItemID

                    #region LogCommand
                    Min = 1;
                    Max = 150;
                    FillLogModelNew(logModelNew);
                    logModelNew.LogCommand = (LogCommandEnum)1000;

                    retStr = logService.LogModelOK(logModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LogCommand), retStr);

                    FillLogModelNew(logModelNew);
                    logModelNew.LogCommand = LogCommandEnum.Add;

                    retStr = logService.LogModelOK(logModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion LogCommand

                    #region Information
                    Min = 1;
                    Max = 100000;
                    FillLogModelNew(logModelNew);
                    logModelNew.Information = randomService.RandomString("", Min - 1);

                    retStr = logService.LogModelOK(logModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Information), retStr);

                    FillLogModelNew(logModelNew);
                    logModelNew.Information = randomService.RandomString("", Max + 1);

                    retStr = logService.LogModelOK(logModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Information, Max), retStr);

                    FillLogModelNew(logModelNew);
                    logModelNew.Information = randomService.RandomString("", Min);

                    retStr = logService.LogModelOK(logModelNew);
                    Assert.AreEqual("", retStr);

                    FillLogModelNew(logModelNew);
                    logModelNew.Information = randomService.RandomString("", Max);

                    retStr = logService.LogModelOK(logModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Information
                }
            }
        }
        [TestMethod]
        public void LogService_FillLog_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    FillLogModelNew(logModelNew);
                    ContactOK contactOK = logService.IsContactOK();

                    string retStr = logService.FillLog(log, logModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void LogService_GetLogModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    int logCount = logService.GetLogModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, logCount);
                }
            }
        }
        [TestMethod]
        public void LogService_GetLogModelListWithTableNameAndAfterLastUpdateDate_UTCDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    List<LogModel> logModelList = logService.GetLogModelListWithTableNameAndAfterLastUpdateDate_UTCDB(logModelRet.TableName, logModelRet.LastUpdateDate_UTC.AddDays(-1));
                    Assert.IsTrue(logModelList.Count > 0);
                    Assert.IsTrue(logModelList.Where(c => c.LogID == logModelRet.LogID).Any());

                    logModelRet.LastUpdateDate_UTC = new DateTime(2089, 1, 1);
                    logModelList = logService.GetLogModelListWithTableNameAndAfterLastUpdateDate_UTCDB(logModelRet.TableName, logModelRet.LastUpdateDate_UTC);
                    Assert.IsTrue(logModelList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void LogService_GetLogModelListWithLastUpdateContactTVItemIDAndAfterLastUpdateDate_UTCDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    List<LogModel> logModelList = logService.GetLogModelListWithLastUpdateContactTVItemIDAndAfterLastUpdateDate_UTCDB(logModelRet.LastUpdateContactTVItemID, logModelRet.LastUpdateDate_UTC.AddHours(-1));
                    Assert.IsTrue(logModelList.Count > 0);
                    Assert.IsTrue(logModelList.Where(c => c.LogID == logModelRet.LogID).Any());

                    logModelRet.LastUpdateContactTVItemID = 0;
                    logModelList = logService.GetLogModelListWithLastUpdateContactTVItemIDAndAfterLastUpdateDate_UTCDB(logModelRet.LastUpdateContactTVItemID, logModelRet.LastUpdateDate_UTC);
                    Assert.IsTrue(logModelList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void LogService_GetLogModelWithLogIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    LogModel logModelRet2 = logService.GetLogModelWithLogIDDB(logModelRet.LogID);
                    Assert.AreEqual("", logModelRet2.Error);

                    int LogID = 0;
                    logModelRet2 = logService.GetLogModelWithLogIDDB(LogID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Log, ServiceRes.LogID, LogID), logModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void LogService_GetLogWithLogIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    Log logRet2 = logService.GetLogWithLogIDDB(logModelRet.LogID);
                    Assert.IsNotNull(logRet2);
                    Assert.AreEqual(logModelRet.LogID, logRet2.LogID);

                    Log logRet3 = logService.GetLogWithLogIDDB(0);
                    Assert.IsNull(logRet3);
                }
            }
        }
        [TestMethod]
        public void LogService_GetInformation_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Address address = new Address()
                {
                    AddressID = 1,
                    AddressTVItemID = 2,
                    AddressType = (int)AddressTypeEnum.Civic,
                    CountryTVItemID = 3,
                    LastUpdateContactTVItemID = 4,
                    LastUpdateDate_UTC = DateTime.Now,
                    MunicipalityTVItemID = 5,
                    PostalCode = "123343",
                    ProvinceTVItemID = 6,
                    StreetName = "The Street name",
                    StreetNumber = "34324",
                    StreetType = (int)StreetTypeEnum.Error,
                };

                string strRet = logService.GetInformation(address);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(strRet));
            }
        }
        [TestMethod]
        public void LogService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    LogModel logModelRet = logService.ReturnError(ErrorText);

                    Assert.AreEqual(ErrorText, logModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void LogService_PostAddLogDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    LogModel logModelRet2 = logService.PostAddLogDB(logModelRet);
                    Assert.AreEqual("", logModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void LogService_PostAddLogDB_LogModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLogService.LogModelOKLogModel = (a) =>
                        {
                            return ErrorText;
                        };

                        LogModel logModelRet2 = logService.PostAddLogDB(logModelRet);
                        Assert.AreEqual(ErrorText, logModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LogService_PostAddLogDB_FillLog_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLogService.FillLogLogLogModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        LogModel logModelRet2 = logService.PostAddLogDB(logModelRet);
                        Assert.AreEqual(ErrorText, logModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LogService_PostAddLogDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLogService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        LogModel logModelRet2 = logService.PostAddLogDB(logModelRet);
                        Assert.AreEqual(ErrorText, logModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LogService_PostDeleteLogDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    LogModel logModelRet2 = logService.PostDeleteLogDB(logModelRet.LogID);
                    Assert.AreEqual("", logModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void LogService_PostDeleteLogDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLogService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        LogModel logModelRet2 = logService.PostDeleteLogDB(logModelRet.LogID);
                        Assert.AreEqual(ErrorText, logModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LogService_PostDeleteLogDB_GetLogWithLogIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LogModel logModelRet = AddLogModel();
                    Assert.AreEqual("", logModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimLogService.GetLogWithLogIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        LogModel logModelRet2 = logService.PostDeleteLogDB(logModelRet.LogID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Log, ServiceRes.LogID, logModelRet.LogID.ToString()), logModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LogService_PostDeleteLogDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LogModel logModelRet = AddLogModel();
                Assert.AreEqual("", logModelRet.Error);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLogService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        LogModel logModelRet2 = logService.PostDeleteLogDB(logModelRet.LogID);
                        Assert.AreEqual(ErrorText, logModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LogService_PostAddLogForObj_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Address address = new Address()
                {
                    AddressID = 1,
                    AddressTVItemID = 2,
                    AddressType = (int)AddressTypeEnum.Civic,
                    CountryTVItemID = 3,
                    LastUpdateContactTVItemID = 4,
                    LastUpdateDate_UTC = DateTime.Now,
                    MunicipalityTVItemID = 5,
                    PostalCode = "123343",
                    ProvinceTVItemID = 6,
                    StreetName = "The Street name",
                    StreetNumber = "34324",
                    StreetType = (int)StreetTypeEnum.Error,
                };

                string TableName = "Addresses";
                int ID = address.AddressID;
                LogCommandEnum LogCommand = LogCommandEnum.Add;
                LogModel logModel = logService.PostAddLogForObj(TableName, ID, LogCommand, address);
                Assert.AreEqual("", logModel.Error);
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private LogModel AddLogModel()
        {
            Log log = new Log()
            {
                TableName = "TVItems",
                ID = 2,
                Information = randomService.RandomString("", 30),
                LogCommand = (int)LogCommandEnum.Add,
                LastUpdateDate_UTC = DateTime.Now,
                LastUpdateContactTVItemID = contactModel.ContactTVItemID
            };

            try
            {
                logService.db.Logs.Add(log);
                logService.db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new LogModel() { Error = ex.Message };
            }

            LogModel logModel = logService.GetLogModelWithLogIDDB(log.LogID);

            return logModel;
        }
        private void CompareLogModels(LogModel logModelNew, LogModel logModelRet)
        {
            Assert.AreEqual(logModelNew.TableName, logModelRet.TableName);
            Assert.AreEqual(logModelNew.ID, logModelRet.ID);
            Assert.AreEqual(logModelNew.LogCommand, logModelRet.LogCommand);
            Assert.AreEqual(logModelNew.Information, logModelRet.Information);
            Assert.AreEqual(logModelNew.LastUpdateContactTVItemID, logModelRet.LastUpdateContactTVItemID);
        }
        private void FillLogModelNew(LogModel logModel)
        {
            logModel.LogID = logModel.LogID;
            logModel.TableName = "TVItems";
            logModel.ID = 2;
            logModel.LogCommand = LogCommandEnum.Add;
            logModel.Information = randomService.RandomString(" ", 30);
            logModel.LastUpdateContactTVItemID = contactModel.ContactTVItemID;

            Assert.IsTrue(!string.IsNullOrWhiteSpace(logModel.TableName));
            Assert.IsTrue(logModel.ID > 0);
            Assert.IsTrue(logModel.LogCommand == LogCommandEnum.Add);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(logModel.Information));
            Assert.IsTrue(logModel.LastUpdateContactTVItemID > 0);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            if (contactModelToDo == null)
            {
                user = null;
            }
            else
            {
                user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            }
            logService = new LogService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            logModelNew = new LogModel();
            log = new Log();
        }
        private void SetupShim()
        {
            shimLogService = new ShimLogService(logService);
        }
        #endregion Functions private
    }
}

