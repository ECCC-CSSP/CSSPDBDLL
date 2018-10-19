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
using CSSPWebToolsDBDLL.Tests.Services;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Service
{
    /// <summary>
    /// Summary description for MWQMRunServiceTest
    /// </summary>
    [TestClass]
    public class MWQMRunLanguageServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MWQMRunLanguage";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MWQMRunService mwqmRunService { get; set; }
        private MWQMRunLanguageService mwqmRunLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MWQMRunLanguageModel mwqmRunLanguageModelNew { get; set; }
        private MWQMRunLanguage mwqmRunLanguage { get; set; }
        private ShimMWQMRunLanguageService shimMWQMRunLanguageService { get; set; }
        private MWQMRunServiceTest mwqmRunServiceTest { get; set; }
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
        public MWQMRunLanguageServiceTest()
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
        public void MWQMRunLanguageService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                Assert.IsNotNull(mwqmRunLanguageService);
                Assert.IsNotNull(mwqmRunLanguageService.db);
                Assert.IsNotNull(mwqmRunLanguageService.LanguageRequest);
                Assert.IsNotNull(mwqmRunLanguageService.User);
                Assert.AreEqual(user.Identity.Name, mwqmRunLanguageService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mwqmRunLanguageService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_MWQMRunLanguageModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum LangToAdd = LanguageEnum.es;

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    #region Good
                    FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);

                    string retStr = mwqmRunLanguageService.MWQMRunLanguageModelOK(mwqmRunLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region MWQMRunID
                    FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);
                    mwqmRunLanguageModelNew.MWQMRunID = 0;

                    retStr = mwqmRunLanguageService.MWQMRunLanguageModelOK(mwqmRunLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMRunID), retStr);
                    #endregion MWQMRunID

                    #region Language
                    int Max = 2;

                    FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);
                    mwqmRunLanguageModelNew.Language = (LanguageEnum)10000;

                    retStr = mwqmRunLanguageService.MWQMRunLanguageModelOK(mwqmRunLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);

                    FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);
                    mwqmRunLanguageModelNew.Language = LanguageEnum.en;

                    retStr = mwqmRunLanguageService.MWQMRunLanguageModelOK(mwqmRunLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Language

                    #region MWQMRunComment
                    FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);
                    Max = 10000;
                    mwqmRunLanguageModelNew.MWQMRunComment = randomService.RandomString("", 0);

                    retStr = mwqmRunLanguageService.MWQMRunLanguageModelOK(mwqmRunLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);
                    mwqmRunLanguageModelNew.MWQMRunComment = randomService.RandomString("", Max + 1);

                    retStr = mwqmRunLanguageService.MWQMRunLanguageModelOK(mwqmRunLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.MWQMRunComment, Max), retStr);

                    FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);
                    mwqmRunLanguageModelNew.MWQMRunComment = randomService.RandomString("", Max - 1);

                    retStr = mwqmRunLanguageService.MWQMRunLanguageModelOK(mwqmRunLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);
                    mwqmRunLanguageModelNew.MWQMRunComment = randomService.RandomString("", Max);

                    retStr = mwqmRunLanguageService.MWQMRunLanguageModelOK(mwqmRunLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMRunComment
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_FillMWQMRunLanguage_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);

                    ContactOK contactOK = mwqmRunLanguageService.IsContactOK();

                    string retStr = mwqmRunLanguageService.FillMWQMRunLanguage(mwqmRunLanguage, mwqmRunLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mwqmRunLanguage.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mwqmRunLanguageService.FillMWQMRunLanguage(mwqmRunLanguage, mwqmRunLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, mwqmRunLanguage.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_GetMWQMRunModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMRunLanguageModel mwqmRunModelLanguageRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    int mwqmRunCount = mwqmRunLanguageService.GetMWQMRunLanguageModelCountDB();
                    Assert.AreEqual(testDBService.Count + 3, mwqmRunCount);
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_GetMWQMRunLanguageModelWithMWQMRunIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    MWQMRunLanguageModel mwqmRunLanguageModelRet2 = mwqmRunLanguageService.GetMWQMRunLanguageModelWithMWQMRunIDAndLanguageDB(mwqmRunLanguageModelRet.MWQMRunID, LangToAdd);
                    Assert.AreEqual(mwqmRunLanguageModelRet.MWQMRunID, mwqmRunLanguageModelRet2.MWQMRunID);
                    Assert.AreEqual(mwqmRunLanguageModelRet.Language, mwqmRunLanguageModelRet2.Language);
                    Assert.AreEqual(LangToAdd, mwqmRunLanguageModelRet2.Language);
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_GetMWQMRunLanguageWithMWQMRunIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    MWQMRunLanguage mwqmRunLanguageRet2 = mwqmRunLanguageService.GetMWQMRunLanguageWithMWQMRunIDAndLanguageDB(mwqmRunLanguageModelRet.MWQMRunID, LangToAdd);
                    Assert.AreEqual(mwqmRunLanguageModelRet.MWQMRunID, mwqmRunLanguageRet2.MWQMRunID);
                    Assert.AreEqual(mwqmRunLanguageModelRet.Language, (LanguageEnum)mwqmRunLanguageRet2.Language);
                    Assert.AreEqual(LangToAdd, (LanguageEnum)mwqmRunLanguageRet2.Language);
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MWQMRunLanguageModel mwqmRunLanguageModelRet = mwqmRunLanguageService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, mwqmRunLanguageModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostAddMWQMRunLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    MWQMRunLanguageModel mwqmRunLanguageModelRet2 = UpdateMWQMRunLanguageModel(mwqmRunLanguageModelRet);

                    MWQMRunLanguageModel mwqmRunLanguageModelRet3 = mwqmRunLanguageService.PostDeleteMWQMRunLanguageDB(mwqmRunLanguageModelRet2.MWQMRunID, LangToAdd);
                    Assert.AreEqual("", mwqmRunLanguageModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostAddMWQMRunLanguageDB_MWQMRunModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);

                        string ErrorText = "ErrorText";
                        ShimMWQMRunLanguageService shimMWQMRunLanguageService = new ShimMWQMRunLanguageService(mwqmRunLanguageService);
                        shimMWQMRunLanguageService.MWQMRunLanguageModelOKMWQMRunLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet = mwqmRunLanguageService.PostAddMWQMRunLanguageDB(mwqmRunLanguageModelNew);
                        Assert.AreEqual(ErrorText, mwqmRunLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostAddMWQMRunLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet = mwqmRunLanguageService.PostAddMWQMRunLanguageDB(mwqmRunLanguageModelNew);
                        Assert.AreEqual(ErrorText, mwqmRunLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostAddMWQMRunLanguageDB_GetMWQMRunLanguageModelWithMWQMRunIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.GetMWQMRunLanguageModelWithMWQMRunIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new MWQMRunLanguageModel() { Error = "" };
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet = mwqmRunLanguageService.PostAddMWQMRunLanguageDB(mwqmRunLanguageModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMRunLanguage), mwqmRunLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostAddMWQMRunLanguageDB_FillMWQMRunLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.FillMWQMRunLanguageMWQMRunLanguageMWQMRunLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet = mwqmRunLanguageService.PostAddMWQMRunLanguageDB(mwqmRunLanguageModelNew);
                        Assert.AreEqual(ErrorText, mwqmRunLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostAddMWQMRunLanguageDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet = mwqmRunLanguageService.PostAddMWQMRunLanguageDB(mwqmRunLanguageModelNew);
                        Assert.AreEqual(ErrorText, mwqmRunLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostAddMWQMRunLanguageDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModelRet, mwqmRunLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.FillMWQMRunLanguageMWQMRunLanguageMWQMRunLanguageModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet = mwqmRunLanguageService.PostAddMWQMRunLanguageDB(mwqmRunLanguageModelNew);
                        Assert.IsTrue(mwqmRunLanguageModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostAddMWQMRunLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    ContactModel contactModelBad = contactModelListBad[0];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    mwqmRunLanguageService = new MWQMRunLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    // Assert 1
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mwqmRunLanguageModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostAddMWQMRunLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    ContactModel contactModelBad = contactModelListGood[2];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    mwqmRunLanguageService = new MWQMRunLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mwqmRunLanguageModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostDeleteMWQMRunLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    MWQMRunLanguageModel mwqmRunLanguageModelRet2 = UpdateMWQMRunLanguageModel(mwqmRunLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet3 = mwqmRunLanguageService.PostDeleteMWQMRunLanguageDB(mwqmRunLanguageModelRet2.MWQMRunID, LangToAdd);
                        Assert.AreEqual(ErrorText, mwqmRunLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostDeleteMWQMRunLanguageDB_GetMWQMRunLanguageWithMWQMRunLanguageIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    MWQMRunLanguageModel mwqmRunLanguageModelRet2 = UpdateMWQMRunLanguageModel(mwqmRunLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.GetMWQMRunLanguageWithMWQMRunIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet3 = mwqmRunLanguageService.PostDeleteMWQMRunLanguageDB(mwqmRunLanguageModelRet2.MWQMRunID, LangToAdd);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMRunLanguage), mwqmRunLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostDeleteMWQMRunLanguageDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet3 = mwqmRunLanguageService.PostDeleteMWQMRunLanguageDB(mwqmRunLanguageModelRet.MWQMRunID, LangToAdd);
                        Assert.AreEqual(ErrorText, mwqmRunLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostUpdateMWQMRunLanguageDB_MWQMRunLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        FillMWQMRunLanguageModelUpdate(mwqmRunLanguageModelRet);
                        string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.MWQMRunLanguageModelOKMWQMRunLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet2 = mwqmRunLanguageService.PostUpdateMWQMRunLanguageDB(mwqmRunLanguageModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostUpdateMWQMRunLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillMWQMRunLanguageModelUpdate(mwqmRunLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet2 = mwqmRunLanguageService.PostUpdateMWQMRunLanguageDB(mwqmRunLanguageModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostUpdateMWQMRunLanguageDB_GetMWQMRunLanguageWithMWQMRunIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillMWQMRunLanguageModelUpdate(mwqmRunLanguageModelRet);

                        //string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.GetMWQMRunLanguageWithMWQMRunIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet2 = mwqmRunLanguageService.PostUpdateMWQMRunLanguageDB(mwqmRunLanguageModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMRunLanguage), mwqmRunLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostUpdateMWQMRunLanguageDB_FillMWQMRunLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillMWQMRunLanguageModelUpdate(mwqmRunLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.FillMWQMRunLanguageMWQMRunLanguageMWQMRunLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet2 = mwqmRunLanguageService.PostUpdateMWQMRunLanguageDB(mwqmRunLanguageModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunLanguageService_PostUpdateMWQMRunLanguageDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = mwqmRunServiceTest.AddMWQMRunModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = AddMWQMRunLanguageModel(LangToAdd, mwqmRunModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillMWQMRunLanguageModelUpdate(mwqmRunLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMRunLanguageModel mwqmRunLanguageModelRet2 = mwqmRunLanguageService.PostUpdateMWQMRunLanguageDB(mwqmRunLanguageModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunLanguageModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private MWQMRunLanguageModel AddMWQMRunLanguageModel(LanguageEnum LangToAdd, MWQMRunModel mwqmRunModel)
        {
            MWQMRunLanguageModel mwqmRunLanguageModelNew = new MWQMRunLanguageModel();
            FillMWQMRunLanguageModelNew(LangToAdd, mwqmRunModel, mwqmRunLanguageModelNew);

            MWQMRunLanguageModel mwqmRunLanguagModelRet = mwqmRunLanguageService.PostAddMWQMRunLanguageDB(mwqmRunLanguageModelNew);
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguagModelRet.Error))
            {
                return mwqmRunLanguagModelRet;
            }
            Assert.IsNotNull(mwqmRunLanguagModelRet);
            CompareMWQMRunLanguageModels(mwqmRunLanguageModelNew, mwqmRunLanguagModelRet);

            return mwqmRunLanguagModelRet;
        }
        private void CompareMWQMRunLanguageModels(MWQMRunLanguageModel mwqmRunLanguageModelNew, MWQMRunLanguageModel mwqmRunLanguageModelRet)
        {
            Assert.AreEqual(mwqmRunLanguageModelNew.Language, mwqmRunLanguageModelRet.Language);
            Assert.AreEqual(mwqmRunLanguageModelNew.MWQMRunComment, mwqmRunLanguageModelRet.MWQMRunComment);
        }
        private void FillMWQMRunLanguageModelNew(LanguageEnum Language, MWQMRunModel mwqmRunModel, MWQMRunLanguageModel mwqmRunLanguageModel)
        {
            mwqmRunLanguageModel.MWQMRunID = mwqmRunModel.MWQMRunID;
            mwqmRunLanguageModel.MWQMRunComment = randomService.RandomString("MWQMRunName", 30);
            mwqmRunLanguageModel.Language = Language;
            mwqmRunLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;
            Assert.IsTrue(mwqmRunLanguageModel.MWQMRunID != 0);
            Assert.IsTrue(mwqmRunLanguageModel.MWQMRunComment.Length == 30);
            Assert.IsTrue(mwqmRunLanguageModel.Language == Language);
            Assert.IsTrue(mwqmRunLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private void FillMWQMRunLanguageModelUpdate(MWQMRunLanguageModel mwqmRunLanguageModel)
        {
            mwqmRunLanguageModel.MWQMRunComment = randomService.RandomString("MWQMRunName", 30);
            mwqmRunLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;
            Assert.IsTrue(mwqmRunLanguageModel.MWQMRunComment.Length == 30);
            Assert.IsTrue(mwqmRunLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private MWQMRunLanguageModel UpdateMWQMRunLanguageModel(MWQMRunLanguageModel mwqmRunLanguageModelRet)
        {
            FillMWQMRunLanguageModelUpdate(mwqmRunLanguageModelRet);

            MWQMRunLanguageModel mwqmRunLanguageModelRet2 = mwqmRunLanguageService.PostUpdateMWQMRunLanguageDB(mwqmRunLanguageModelRet);
            if (!string.IsNullOrWhiteSpace(mwqmRunLanguageModelRet2.Error))
            {
                return mwqmRunLanguageModelRet2;
            }
            Assert.IsNotNull(mwqmRunLanguageModelRet2);
            CompareMWQMRunLanguageModels(mwqmRunLanguageModelRet, mwqmRunLanguageModelRet2);

            return mwqmRunLanguageModelRet2;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mwqmRunService = new MWQMRunService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmRunLanguageService = new MWQMRunLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmRunLanguageModelNew = new MWQMRunLanguageModel();
            mwqmRunLanguage = new MWQMRunLanguage();
            mwqmRunServiceTest = new MWQMRunServiceTest();
            mwqmRunServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimMWQMRunLanguageService = new ShimMWQMRunLanguageService(mwqmRunLanguageService);
        }
        #endregion Functions private
    }
}

