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
    /// Summary description for TVFileServiceTest
    /// </summary>
    [TestClass]
    public class TVFileLanguageServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "TVFileLanguage";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private TVFileService tvFileService { get; set; }
        private TVFileLanguageService tvFileLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private TVFileLanguageModel tvFileLanguageModelNew { get; set; }
        private TVFileLanguage tvFileLanguage { get; set; }
        private ShimTVFileLanguageService shimTVFileLanguageService { get; set; }
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
        public TVFileLanguageServiceTest()
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
        public void TVFileLanguageService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(tvFileLanguageService);
                Assert.IsNotNull(tvFileLanguageService.db);
                Assert.IsNotNull(tvFileLanguageService.LanguageRequest);
                Assert.IsNotNull(tvFileLanguageService.User);
                Assert.AreEqual(user.Identity.Name, tvFileLanguageService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), tvFileLanguageService.LanguageRequest);
            }
        }
        [TestMethod]
        public void TVFileLanguageService_TVFileLanguageModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum LangToAdd = LanguageEnum.es;

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileLanguageModel tvFileLanguageModel = AddTVFileLanguageModel(LangToAdd);
                    Assert.AreEqual("", tvFileLanguageModel.Error);

                    tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;

                    #region TVFileID
                    FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);
                    tvFileLanguageModelNew.TVFileID = 0;

                    string retStr = tvFileLanguageService.TVFileLanguageModelOK(tvFileLanguageModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TVFileID), retStr);
                    #endregion TVFileID

                    #region Language
                    tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;
                    FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);
                    int Max = 2;
                    tvFileLanguageModelNew.Language = (LanguageEnum)1000;

                    retStr = tvFileLanguageService.TVFileLanguageModelOK(tvFileLanguageModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);

                    FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);
                    tvFileLanguageModelNew.Language = LanguageEnum.en;

                    retStr = tvFileLanguageService.TVFileLanguageModelOK(tvFileLanguageModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Language

                    #region FileDescription
                    FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);
                    Max = 1000;
                    tvFileLanguageModelNew.FileDescription = randomService.RandomString("", 0);

                    retStr = tvFileLanguageService.TVFileLanguageModelOK(tvFileLanguageModelNew);
                    Assert.IsNotNull("", retStr);

                    FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);
                    tvFileLanguageModelNew.FileDescription = randomService.RandomString("", Max + 1);

                    retStr = tvFileLanguageService.TVFileLanguageModelOK(tvFileLanguageModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Language, Max), retStr);

                    FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);
                    tvFileLanguageModelNew.FileDescription = randomService.RandomString("", Max - 1);

                    retStr = tvFileLanguageService.TVFileLanguageModelOK(tvFileLanguageModelNew);
                    Assert.IsNotNull("", retStr);

                    FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);
                    tvFileLanguageModelNew.FileDescription = randomService.RandomString("", Max);

                    retStr = tvFileLanguageService.TVFileLanguageModelOK(tvFileLanguageModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion TVText
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_FillTVFileLanguage_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;
                    TVFileLanguageModel tvFileLanguageModel = AddTVFileLanguageModel(LangToAdd);
                    Assert.AreEqual("", tvFileLanguageModel.Error);

                    tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;

                    FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);

                    ContactOK contactOK = tvFileLanguageService.IsContactOK();

                    string retStr = tvFileLanguageService.FillTVFileLanguage(tvFileLanguage, tvFileLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, tvFileLanguage.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = tvFileLanguageService.FillTVFileLanguage(tvFileLanguage, tvFileLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, tvFileLanguage.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_GetTVFileLanguageModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVFileLanguageModel tvFileModelLanguageRet = AddTVFileLanguageModel(LangToAdd);

                    int tvFileCount = tvFileLanguageService.GetTVFileLanguageModelCountDB();
                    Assert.AreEqual(testDBService.Count + 2, tvFileCount);
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_GetTVFileLanguageModelWithTVFileIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LanguageEnum.en);

                    TVFileLanguageModel tvFileLanguageModelRet2 = tvFileLanguageService.GetTVFileLanguageModelWithTVFileIDAndLanguageDB(tvFileLanguageModelRet.TVFileID, LanguageEnum.en);
                    Assert.AreEqual(tvFileLanguageModelRet.TVFileID, tvFileLanguageModelRet2.TVFileID);
                    Assert.AreEqual(tvFileLanguageModelRet.Language, tvFileLanguageModelRet2.Language);
                    Assert.AreEqual(LanguageEnum.en, tvFileLanguageModelRet2.Language);
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_GetTVFileLanguageWithTVFileIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.en;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);

                    TVFileLanguage tvFileLanguageRet2 = tvFileLanguageService.GetTVFileLanguageWithTVFileIDAndLanguageDB(tvFileLanguageModelRet.TVFileID, LangToAdd);
                    Assert.AreEqual(tvFileLanguageModelRet.TVFileID, tvFileLanguageRet2.TVFileID);
                    Assert.AreEqual(tvFileLanguageModelRet.Language, (LanguageEnum)tvFileLanguageRet2.Language);
                    Assert.AreEqual(LangToAdd, (LanguageEnum)tvFileLanguageRet2.Language);
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_ReturnError_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                using (TransactionScope ts = new TransactionScope())
                {

                    string ErrorText = "ErrorText";
                    TVFileLanguageModel tvFileLanguageModel = tvFileLanguageService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, tvFileLanguageModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.en;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);

                    TVFileLanguageModel tvFileLanguageModelRet2 = UpdateTVFileLanguageModel(tvFileLanguageModelRet);

                    TVFileLanguageModel tvFileLanguageModelRet3 = tvFileLanguageService.PostDeleteTVFileLanguageDB(tvFileLanguageModelRet2.TVFileID, LangToAdd);
                    Assert.AreEqual("", tvFileLanguageModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileLanguageDB_TVFileLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        LanguageEnum LangToAdd = LanguageEnum.en;
                        TVFileLanguageModel tvFileLanguageModel = AddTVFileLanguageModel(LangToAdd);
                        Assert.AreEqual("", tvFileLanguageModel.Error);

                        LangToAdd = LanguageEnum.es;
                        tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;
                        tvFileLanguageModelNew.FileDescription = tvFileLanguageModel.FileDescription;
                        FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);

                        string ErrorText = "ErrorText";
                        ShimTVFileLanguageService shimTVFileLanguageService = new ShimTVFileLanguageService(tvFileLanguageService);
                        shimTVFileLanguageService.TVFileLanguageModelOKTVFileLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVFileLanguageModel tvFileLanguageModelRet = tvFileLanguageService.PostAddTVFileLanguageDB(tvFileLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.en;
                        TVFileLanguageModel tvFileLanguageModel = AddTVFileLanguageModel(LangToAdd);
                        Assert.AreEqual("", tvFileLanguageModel.Error);

                        LangToAdd = LanguageEnum.es;
                        tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;
                        tvFileLanguageModelNew.FileDescription = tvFileLanguageModel.FileDescription;
                        FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimTVFileLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVFileLanguageModel tvFileLanguageModelRet = tvFileLanguageService.PostAddTVFileLanguageDB(tvFileLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileLanguageDB_GetTVFileLanguageModelWithTVFileIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.en;
                        TVFileLanguageModel tvFileLanguageModel = AddTVFileLanguageModel(LangToAdd);
                        Assert.AreEqual("", tvFileLanguageModel.Error);

                        LangToAdd = LanguageEnum.es;
                        tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;
                        tvFileLanguageModelNew.FileDescription = tvFileLanguageModel.FileDescription;
                        FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimTVFileLanguageService.GetTVFileLanguageModelWithTVFileIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVFileLanguageModel();
                        };

                        TVFileLanguageModel tvFileLanguageModelRet = tvFileLanguageService.PostAddTVFileLanguageDB(tvFileLanguageModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVFileLanguage), tvFileLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileLanguageDB_FillTVFileLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.en;
                        TVFileLanguageModel tvFileLanguageModel = AddTVFileLanguageModel(LangToAdd);
                        Assert.AreEqual("", tvFileLanguageModel.Error);

                        LangToAdd = LanguageEnum.es;
                        tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;
                        tvFileLanguageModelNew.FileDescription = tvFileLanguageModel.FileDescription;
                        FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimTVFileLanguageService.FillTVFileLanguageTVFileLanguageTVFileLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVFileLanguageModel tvFileLanguageModelRet = tvFileLanguageService.PostAddTVFileLanguageDB(tvFileLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileLanguageDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.en;
                        TVFileLanguageModel tvFileLanguageModel = AddTVFileLanguageModel(LangToAdd);
                        Assert.AreEqual("", tvFileLanguageModel.Error);

                        LangToAdd = LanguageEnum.es;
                        tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;
                        tvFileLanguageModelNew.FileDescription = tvFileLanguageModel.FileDescription;
                        FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimTVFileLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVFileLanguageModel tvFileLanguageModelRet = tvFileLanguageService.PostAddTVFileLanguageDB(tvFileLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileLanguageDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.en;
                        TVFileLanguageModel tvFileLanguageModel = AddTVFileLanguageModel(LangToAdd);
                        Assert.AreEqual("", tvFileLanguageModel.Error);

                        LangToAdd = LanguageEnum.es;
                        tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;
                        tvFileLanguageModelNew.FileDescription = tvFileLanguageModel.FileDescription;
                        FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimTVFileLanguageService.FillTVFileLanguageTVFileLanguageTVFileLanguageModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        TVFileLanguageModel tvFileLanguageModelRet = tvFileLanguageService.PostAddTVFileLanguageDB(tvFileLanguageModelNew);
                        Assert.IsTrue(tvFileLanguageModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileContactLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.en;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);

                    TVFileLanguageModel tvFileLanguageModelRet2 = UpdateTVFileLanguageModel(tvFileLanguageModelRet);

                    TVFileLanguageModel tvFileLanguageModelRet3 = tvFileLanguageService.PostDeleteTVFileLanguageDB(tvFileLanguageModelRet2.TVFileID, LangToAdd);
                    Assert.AreEqual("", tvFileLanguageModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileContactLanguageDB_TVFileLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        LanguageEnum LangToAdd = LanguageEnum.en;
                        TVFileLanguageModel tvFileLanguageModel = AddTVFileLanguageModel(LangToAdd);
                        Assert.AreEqual("", tvFileLanguageModel.Error);

                        LangToAdd = LanguageEnum.es;
                        tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;
                        tvFileLanguageModelNew.FileDescription = tvFileLanguageModel.FileDescription;
                        FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);

                        string ErrorText = "ErrorText";
                        ShimTVFileLanguageService shimTVFileLanguageService = new ShimTVFileLanguageService(tvFileLanguageService);
                        shimTVFileLanguageService.TVFileLanguageModelOKTVFileLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVFileLanguageModel tvFileLanguageModelRet = tvFileLanguageService.PostAddTVFileContactLanguageDB(tvFileLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileContactLanguageDB_GetTVFileLanguageModelWithTVFileIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.en;
                        TVFileLanguageModel tvFileLanguageModel = AddTVFileLanguageModel(LangToAdd);
                        Assert.AreEqual("", tvFileLanguageModel.Error);

                        LangToAdd = LanguageEnum.es;
                        tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;
                        tvFileLanguageModelNew.FileDescription = tvFileLanguageModel.FileDescription;
                        FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimTVFileLanguageService.GetTVFileLanguageModelWithTVFileIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVFileLanguageModel();
                        };

                        TVFileLanguageModel tvFileLanguageModelRet = tvFileLanguageService.PostAddTVFileContactLanguageDB(tvFileLanguageModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVFileLanguage), tvFileLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileContactLanguageDB_FillTVFileLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.en;
                        TVFileLanguageModel tvFileLanguageModel = AddTVFileLanguageModel(LangToAdd);
                        Assert.AreEqual("", tvFileLanguageModel.Error);

                        LangToAdd = LanguageEnum.es;
                        tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;
                        tvFileLanguageModelNew.FileDescription = tvFileLanguageModel.FileDescription;
                        FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimTVFileLanguageService.FillTVFileLanguageTVFileLanguageTVFileLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVFileLanguageModel tvFileLanguageModelRet = tvFileLanguageService.PostAddTVFileContactLanguageDB(tvFileLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileContactLanguageDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.en;
                        TVFileLanguageModel tvFileLanguageModel = AddTVFileLanguageModel(LangToAdd);
                        Assert.AreEqual("", tvFileLanguageModel.Error);

                        LangToAdd = LanguageEnum.es;
                        tvFileLanguageModelNew.TVFileID = tvFileLanguageModel.TVFileID;
                        tvFileLanguageModelNew.FileDescription = tvFileLanguageModel.FileDescription;
                        FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimTVFileLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVFileLanguageModel tvFileLanguageModelRet = tvFileLanguageService.PostAddTVFileContactLanguageDB(tvFileLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostDeleteTVFileLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);

                    TVFileLanguageModel tvFileLanguageModelRet2 = UpdateTVFileLanguageModel(tvFileLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVFileLanguageModel tvFileLanguageModelRet3 = tvFileLanguageService.PostDeleteTVFileLanguageDB(tvFileLanguageModelRet2.TVFileID, LangToAdd);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostDeleteTVFileLanguageDB_GetTVFileLanguageWithTVFileLanguageIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);

                    TVFileLanguageModel tvFileLanguageModelRet2 = UpdateTVFileLanguageModel(tvFileLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVFileLanguageService.GetTVFileLanguageWithTVFileIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        TVFileLanguageModel tvFileLanguageModelRet3 = tvFileLanguageService.PostDeleteTVFileLanguageDB(tvFileLanguageModelRet2.TVFileLanguageID, LangToAdd);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVFileLanguage), tvFileLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostDeleteTVFileLanguageDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.en;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileLanguageService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVFileLanguageModel tvFileLanguageModelRet2 = tvFileLanguageService.PostDeleteTVFileLanguageDB(tvFileLanguageModelRet.TVFileID, LangToAdd);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostUpdateTVFileLanguageDB_TVFileLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        FillTVFileLanguageModelUpdate(tvFileLanguageModelRet);
                        string ErrorText = "ErrorText";
                        shimTVFileLanguageService.TVFileLanguageModelOKTVFileLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVFileLanguageModel tvFileLanguageModelRet2 = tvFileLanguageService.PostUpdateTVFileLanguageDB(tvFileLanguageModelRet);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostUpdateTVFileLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillTVFileLanguageModelUpdate(tvFileLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimTVFileLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVFileLanguageModel tvFileLanguageModelRet2 = tvFileLanguageService.PostUpdateTVFileLanguageDB(tvFileLanguageModelRet);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostUpdateTVFileLanguageDB_GetTVFileLanguageWithTVFileIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillTVFileLanguageModelUpdate(tvFileLanguageModelRet);

                        //string ErrorText = "ErrorText";
                        shimTVFileLanguageService.GetTVFileLanguageWithTVFileIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        TVFileLanguageModel tvFileLanguageModelRet2 = tvFileLanguageService.PostUpdateTVFileLanguageDB(tvFileLanguageModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVFileLanguage), tvFileLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostUpdateTVFileLanguageDB_FillTVFileLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillTVFileLanguageModelUpdate(tvFileLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimTVFileLanguageService.FillTVFileLanguageTVFileLanguageTVFileLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVFileLanguageModel tvFileLanguageModelRet2 = tvFileLanguageService.PostUpdateTVFileLanguageDB(tvFileLanguageModelRet);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostUpdateTVFileLanguageDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillTVFileLanguageModelUpdate(tvFileLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimTVFileLanguageService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVFileLanguageModel tvFileLanguageModelRet2 = tvFileLanguageService.PostUpdateTVFileLanguageDB(tvFileLanguageModelRet);
                        Assert.AreEqual(ErrorText, tvFileLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, tvFileLanguageModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileLanguageService_PostAddTVFileLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVFileLanguageModel tvFileLanguageModelRet = AddTVFileLanguageModel(LangToAdd);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, tvFileLanguageModelRet.Error);

                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private TVFileLanguageModel AddTVFileLanguageModel(LanguageEnum LangToAdd)
        {
            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
            if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
                return new TVFileLanguageModel() { Error = tvItemModelRoot.Error };


            TVItemModel tvItemModelFile = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, "Unique File Name", TVTypeEnum.File);
            if (!string.IsNullOrWhiteSpace(tvItemModelFile.Error))
                return new TVFileLanguageModel() { Error = tvItemModelFile.Error };

            TVFileModel tvFileModelNew = new TVFileModel()
            {
                ClientFilePath = randomService.RandomString("", 20),
                FileCreatedDate_UTC = DateTime.Now,
                FileInfo = randomService.RandomString("", 20),
                FileDescription = randomService.RandomString("", 20),
                FilePurpose = FilePurposeEnum.Picture,
                FileSize_kb = randomService.RandomInt(10, 20),
                FileType = FileTypeEnum.JPEG,
                FromWater = false,
                Language = LanguageEnum.en,
                ServerFileName = randomService.RandomString("", 20),
                ServerFilePath = randomService.RandomString("", 20),
                TemplateTVType = (int)TVTypeEnum.Error,
                TVFileTVItemID = tvItemModelFile.TVItemID,
            };

            TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
            if (!string.IsNullOrWhiteSpace(tvFileModelRet.Error))
                return new TVFileLanguageModel() { Error = tvFileModelRet.Error };

            //TVFileLanguageModel tvFileLanguageModelNew = new TVFileLanguageModel();
            //tvFileLanguageModelNew.TVFileID = tvFileModelRet.TVFileID;
            //tvFileLanguageModelNew.FileDescription = tvFileModelNew.FileDescription;
            //FillTVFileLanguageModelNew(LangToAdd, tvFileLanguageModelNew);

            TVFileLanguageModel tvFileLanguagModelRet = tvFileLanguageService.GetTVFileLanguageModelWithTVFileIDAndLanguageDB(tvFileModelRet.TVFileID, LanguageEnum.en);
            if (!string.IsNullOrWhiteSpace(tvFileLanguagModelRet.Error))
            {
                return tvFileLanguagModelRet;
            }

            //Assert.IsNotNull(tvFileLanguagModelRet);
            //CompareTVFileLanguageModels(tvFileLanguageModelNew, tvFileLanguagModelRet);

            return tvFileLanguagModelRet;
        }
        private void CompareTVFileLanguageModels(TVFileLanguageModel tvFileLanguageModelNew, TVFileLanguageModel tvFileLanguageModelRet)
        {
            Assert.AreEqual(tvFileLanguageModelNew.Language, tvFileLanguageModelRet.Language);
            Assert.AreEqual(tvFileLanguageModelNew.FileDescription, tvFileLanguageModelRet.FileDescription);
        }
        private void FillTVFileLanguageModelNew(LanguageEnum Language, TVFileLanguageModel tvFileLanguageModel)
        {
            tvFileLanguageModel.TVFileID = tvFileLanguageModel.TVFileID;
            tvFileLanguageModel.Language = Language;
            tvFileLanguageModel.FileDescription = randomService.RandomString("TV Text", 20);
            tvFileLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(tvFileLanguageModel.TVFileID != 0);
            Assert.IsTrue(tvFileLanguageModel.Language == Language);
            Assert.IsTrue(tvFileLanguageModel.FileDescription.Length == 20);
            Assert.IsTrue(tvFileLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private void FillTVFileLanguageModelUpdate(TVFileLanguageModel tvFileLanguageModel)
        {
            tvFileLanguageModel.FileDescription = randomService.RandomString("File Desc", 20);
            tvFileLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(tvFileLanguageModel.FileDescription.Length == 20);
            Assert.IsTrue(tvFileLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private TVFileLanguageModel UpdateTVFileLanguageModel(TVFileLanguageModel tvFileLanguageModelRet)
        {
            FillTVFileLanguageModelUpdate(tvFileLanguageModelRet);

            TVFileLanguageModel tvFileLanguageModelRet2 = tvFileLanguageService.PostUpdateTVFileLanguageDB(tvFileLanguageModelRet);
            if (!string.IsNullOrWhiteSpace(tvFileLanguageModelRet2.Error))
            {
                return tvFileLanguageModelRet2;
            }

            Assert.IsNotNull(tvFileLanguageModelRet2);
            CompareTVFileLanguageModels(tvFileLanguageModelRet, tvFileLanguageModelRet2);

            return tvFileLanguageModelRet2;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            tvFileService = new TVFileService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvFileLanguageService = new TVFileLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvFileLanguageModelNew = new TVFileLanguageModel();
            tvFileLanguage = new TVFileLanguage();
        }
        private void SetupShim()
        {
            shimTVFileLanguageService = new ShimTVFileLanguageService(tvFileLanguageService);
        }
        #endregion Functions private
    }
}

