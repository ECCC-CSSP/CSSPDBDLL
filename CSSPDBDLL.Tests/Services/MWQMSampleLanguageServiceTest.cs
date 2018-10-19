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

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MWQMSampleServiceTest
    /// </summary>
    [TestClass]
    public class MWQMSampleLanguageServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MWQMSampleLanguage";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MWQMSampleService mwqmSampleService { get; set; }
        private MWQMSampleLanguageService mwqmSampleLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MWQMSampleLanguageModel mwqmSampleLanguageModelNew { get; set; }
        private MWQMSampleLanguage mwqmSampleLanguage { get; set; }
        private ShimMWQMSampleLanguageService shimMWQMSampleLanguageService { get; set; }
        private MWQMSampleServiceTest mwqmSampleServiceTest { get; set; }
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test sample.
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
        public MWQMSampleLanguageServiceTest()
        {
            setupData = new SetupData();
        }
        #endregion Constructors

        #region Initialize and Cleanup
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to sample code before samplening the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to sample code after all tests in a class have sample
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to sample code before samplening each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to sample code after each test has sample
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion Initialize and Cleanup

        #region Testing Methods Public
        [TestMethod]
        public void MWQMSampleLanguageService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(mwqmSampleLanguageService);
                Assert.IsNotNull(mwqmSampleLanguageService.db);
                Assert.IsNotNull(mwqmSampleLanguageService.LanguageRequest);
                Assert.IsNotNull(mwqmSampleLanguageService.User);
                Assert.AreEqual(user.Identity.Name, mwqmSampleLanguageService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mwqmSampleLanguageService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_MWQMSampleLanguageModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum LangToAdd = LanguageEnum.es;

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    #region Good
                    FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);

                    string retStr = mwqmSampleLanguageService.MWQMSampleLanguageModelOK(mwqmSampleLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region MWQMSampleID
                    FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);
                    mwqmSampleLanguageModelNew.MWQMSampleID = 0;

                    retStr = mwqmSampleLanguageService.MWQMSampleLanguageModelOK(mwqmSampleLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSampleID), retStr);
                    #endregion MWQMSampleID

                    #region Language
                    int Max = 2;

                    FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);
                    mwqmSampleLanguageModelNew.Language = (LanguageEnum)10000;

                    retStr = mwqmSampleLanguageService.MWQMSampleLanguageModelOK(mwqmSampleLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);

                    FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);
                    mwqmSampleLanguageModelNew.Language = LanguageEnum.en;
                    #endregion Language

                    #region MWQMSampleNote
                    FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);
                    Max = 10000;
                    mwqmSampleLanguageModelNew.MWQMSampleNote = randomService.RandomString("", 0);

                    retStr = mwqmSampleLanguageService.MWQMSampleLanguageModelOK(mwqmSampleLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);
                    mwqmSampleLanguageModelNew.MWQMSampleNote = randomService.RandomString("", Max + 1);

                    retStr = mwqmSampleLanguageService.MWQMSampleLanguageModelOK(mwqmSampleLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.MWQMSampleNote, Max), retStr);

                    FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);
                    mwqmSampleLanguageModelNew.MWQMSampleNote = randomService.RandomString("", Max - 1);

                    retStr = mwqmSampleLanguageService.MWQMSampleLanguageModelOK(mwqmSampleLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);
                    mwqmSampleLanguageModelNew.MWQMSampleNote = randomService.RandomString("", Max);

                    retStr = mwqmSampleLanguageService.MWQMSampleLanguageModelOK(mwqmSampleLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMSampleNote
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_FillMWQMSampleLanguage_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);

                    ContactOK contactOK = mwqmSampleLanguageService.IsContactOK();

                    string retStr = mwqmSampleLanguageService.FillMWQMSampleLanguage(mwqmSampleLanguage, mwqmSampleLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mwqmSampleLanguage.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mwqmSampleLanguageService.FillMWQMSampleLanguage(mwqmSampleLanguage, mwqmSampleLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, mwqmSampleLanguage.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_GetMWQMSampleModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSampleLanguageModel mwqmSampleModelLanguageRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    int mwqmSampleCount = mwqmSampleLanguageService.GetMWQMSampleLanguageModelCountDB();
                    Assert.AreEqual(testDBService.Count + 3, mwqmSampleCount);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_GetMWQMSampleLanguageModelWithMWQMSampleIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet2 = mwqmSampleLanguageService.GetMWQMSampleLanguageModelWithMWQMSampleIDAndLanguageDB(mwqmSampleLanguageModelRet.MWQMSampleID, LangToAdd);
                    Assert.AreEqual(mwqmSampleLanguageModelRet.MWQMSampleID, mwqmSampleLanguageModelRet2.MWQMSampleID);
                    Assert.AreEqual(mwqmSampleLanguageModelRet.Language, mwqmSampleLanguageModelRet2.Language);
                    Assert.AreEqual(LangToAdd, mwqmSampleLanguageModelRet2.Language);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_GetMWQMSampleLanguageWithMWQMSampleIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    MWQMSampleLanguage mwqmSampleLanguageRet2 = mwqmSampleLanguageService.GetMWQMSampleLanguageWithMWQMSampleIDAndLanguageDB(mwqmSampleLanguageModelRet.MWQMSampleID, LangToAdd);
                    Assert.AreEqual(mwqmSampleLanguageModelRet.MWQMSampleID, mwqmSampleLanguageRet2.MWQMSampleID);
                    Assert.AreEqual(mwqmSampleLanguageModelRet.Language, (LanguageEnum)mwqmSampleLanguageRet2.Language);
                    Assert.AreEqual(LangToAdd, (LanguageEnum)mwqmSampleLanguageRet2.Language);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostAddMWQMSampleLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet2 = UpdateMWQMSampleLanguageModel(mwqmSampleLanguageModelRet);

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet3 = mwqmSampleLanguageService.PostDeleteMWQMSampleLanguageDB(mwqmSampleLanguageModelRet2.MWQMSampleID, LangToAdd);
                    Assert.AreEqual("", mwqmSampleLanguageModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostAddMWQMSampleLanguageDB_MWQMSampleModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);

                        string ErrorText = "ErrorText";
                        ShimMWQMSampleLanguageService shimMWQMSampleLanguageService = new ShimMWQMSampleLanguageService(mwqmSampleLanguageService);
                        shimMWQMSampleLanguageService.MWQMSampleLanguageModelOKMWQMSampleLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet = mwqmSampleLanguageService.PostAddMWQMSampleLanguageDB(mwqmSampleLanguageModelNew);
                        Assert.AreEqual(ErrorText, mwqmSampleLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostAddMWQMSampleLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet = mwqmSampleLanguageService.PostAddMWQMSampleLanguageDB(mwqmSampleLanguageModelNew);
                        Assert.AreEqual(ErrorText, mwqmSampleLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostAddMWQMSampleLanguageDB_GetMWQMSampleLanguageModelWithMWQMSampleIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.GetMWQMSampleLanguageModelWithMWQMSampleIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new MWQMSampleLanguageModel();
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet = mwqmSampleLanguageService.PostAddMWQMSampleLanguageDB(mwqmSampleLanguageModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMSampleLanguage), mwqmSampleLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostAddMWQMSampleLanguageDB_FillMWQMSampleLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.FillMWQMSampleLanguageMWQMSampleLanguageMWQMSampleLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet = mwqmSampleLanguageService.PostAddMWQMSampleLanguageDB(mwqmSampleLanguageModelNew);
                        Assert.AreEqual(ErrorText, mwqmSampleLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostAddMWQMSampleLanguageDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet = mwqmSampleLanguageService.PostAddMWQMSampleLanguageDB(mwqmSampleLanguageModelNew);
                        Assert.AreEqual(ErrorText, mwqmSampleLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostAddMWQMSampleLanguageDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModelRet, mwqmSampleLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.FillMWQMSampleLanguageMWQMSampleLanguageMWQMSampleLanguageModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet = mwqmSampleLanguageService.PostAddMWQMSampleLanguageDB(mwqmSampleLanguageModelNew);
                        Assert.IsTrue(mwqmSampleLanguageModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostDeleteMWQMSampleLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet2 = UpdateMWQMSampleLanguageModel(mwqmSampleLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet3 = mwqmSampleLanguageService.PostDeleteMWQMSampleLanguageDB(mwqmSampleLanguageModelRet2.MWQMSampleID, LangToAdd);
                        Assert.AreEqual(ErrorText, mwqmSampleLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostDeleteMWQMSampleLanguageDB_GetMWQMSampleLanguageWithMWQMSampleLanguageIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet2 = UpdateMWQMSampleLanguageModel(mwqmSampleLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.GetMWQMSampleLanguageWithMWQMSampleIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet3 = mwqmSampleLanguageService.PostDeleteMWQMSampleLanguageDB(mwqmSampleLanguageModelRet2.MWQMSampleID, LangToAdd);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, "MWQMSampleLanguage"), mwqmSampleLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostDeleteMWQMSampleLanguageDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet3 = mwqmSampleLanguageService.PostDeleteMWQMSampleLanguageDB(mwqmSampleLanguageModelRet.MWQMSampleID, LangToAdd);
                        Assert.AreEqual(ErrorText, mwqmSampleLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostUpdateMWQMSampleLanguageDB_MWQMSampleLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        FillMWQMSampleLanguageModelUpdate(mwqmSampleLanguageModelRet);
                        string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.MWQMSampleLanguageModelOKMWQMSampleLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet2 = mwqmSampleLanguageService.PostUpdateMWQMSampleLanguageDB(mwqmSampleLanguageModelRet);
                        Assert.AreEqual(ErrorText, mwqmSampleLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostUpdateMWQMSampleLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillMWQMSampleLanguageModelUpdate(mwqmSampleLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet2 = mwqmSampleLanguageService.PostUpdateMWQMSampleLanguageDB(mwqmSampleLanguageModelRet);
                        Assert.AreEqual(ErrorText, mwqmSampleLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostUpdateMWQMSampleLanguageDB_GetMWQMSampleLanguageWithMWQMSampleIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillMWQMSampleLanguageModelUpdate(mwqmSampleLanguageModelRet);

                        //string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.GetMWQMSampleLanguageWithMWQMSampleIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet2 = mwqmSampleLanguageService.PostUpdateMWQMSampleLanguageDB(mwqmSampleLanguageModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSampleLanguage), mwqmSampleLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostUpdateMWQMSampleLanguageDB_FillMWQMSampleLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillMWQMSampleLanguageModelUpdate(mwqmSampleLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.FillMWQMSampleLanguageMWQMSampleLanguageMWQMSampleLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet2 = mwqmSampleLanguageService.PostUpdateMWQMSampleLanguageDB(mwqmSampleLanguageModelRet);
                        Assert.AreEqual(ErrorText, mwqmSampleLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostUpdateMWQMSampleLanguageDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillMWQMSampleLanguageModelUpdate(mwqmSampleLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet2 = mwqmSampleLanguageService.PostUpdateMWQMSampleLanguageDB(mwqmSampleLanguageModelRet);
                        Assert.AreEqual(ErrorText, mwqmSampleLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostAddMWQMSampleLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    ContactModel contactModelBad = contactModelListBad[0];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    mwqmSampleLanguageService = new MWQMSampleLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    // Assert 1
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mwqmSampleLanguageModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMSampleLanguageService_PostAddMWQMSampleLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleServiceTest.AddMWQMSampleModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    ContactModel contactModelBad = contactModelListGood[2];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    mwqmSampleLanguageService = new MWQMSampleLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = AddMWQMSampleLanguageModel(LangToAdd, mwqmSampleModelRet);

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mwqmSampleLanguageModelRet.Error);

                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private MWQMSampleLanguageModel AddMWQMSampleLanguageModel(LanguageEnum LangToAdd, MWQMSampleModel mwqmSampleModel)
        {
            MWQMSampleLanguageModel mwqmSampleLanguageModelNew = new MWQMSampleLanguageModel();
            FillMWQMSampleLanguageModelNew(LangToAdd, mwqmSampleModel, mwqmSampleLanguageModelNew);

            MWQMSampleLanguageModel mwqmSampleLanguagModelRet = mwqmSampleLanguageService.PostAddMWQMSampleLanguageDB(mwqmSampleLanguageModelNew);
            if (!string.IsNullOrWhiteSpace(mwqmSampleLanguagModelRet.Error))
            {
                return mwqmSampleLanguagModelRet;
            }

            Assert.IsNotNull(mwqmSampleLanguagModelRet);
            CompareMWQMSampleLanguageModels(mwqmSampleLanguageModelNew, mwqmSampleLanguagModelRet);

            return mwqmSampleLanguagModelRet;
        }
        private void CompareMWQMSampleLanguageModels(MWQMSampleLanguageModel mwqmSampleLanguageModelNew, MWQMSampleLanguageModel mwqmSampleLanguageModelRet)
        {
            Assert.AreEqual(mwqmSampleLanguageModelNew.Language, mwqmSampleLanguageModelRet.Language);
            Assert.AreEqual(mwqmSampleLanguageModelNew.MWQMSampleNote, mwqmSampleLanguageModelRet.MWQMSampleNote);
        }
        private void FillMWQMSampleLanguageModelNew(LanguageEnum Language, MWQMSampleModel mwqmSampleModel, MWQMSampleLanguageModel mwqmSampleLanguageModel)
        {
            mwqmSampleLanguageModel.MWQMSampleID = mwqmSampleModel.MWQMSampleID;
            mwqmSampleLanguageModel.MWQMSampleNote = randomService.RandomString("MWQMSampleName", 30);
            mwqmSampleLanguageModel.Language = Language;
            mwqmSampleLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(mwqmSampleLanguageModel.MWQMSampleID != 0);
            Assert.IsTrue(mwqmSampleLanguageModel.MWQMSampleNote.Length == 30);
            Assert.IsTrue(mwqmSampleLanguageModel.Language == Language);
            Assert.IsTrue(mwqmSampleLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private void FillMWQMSampleLanguageModelUpdate(MWQMSampleLanguageModel mwqmSampleLanguageModel)
        {
            mwqmSampleLanguageModel.MWQMSampleNote = randomService.RandomString("MWQMSampleName", 30);
            mwqmSampleLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(mwqmSampleLanguageModel.MWQMSampleNote.Length == 30);
            Assert.IsTrue(mwqmSampleLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private MWQMSampleLanguageModel UpdateMWQMSampleLanguageModel(MWQMSampleLanguageModel mwqmSampleLanguageModelRet)
        {
            FillMWQMSampleLanguageModelUpdate(mwqmSampleLanguageModelRet);

            MWQMSampleLanguageModel mwqmSampleLanguageModelRet2 = mwqmSampleLanguageService.PostUpdateMWQMSampleLanguageDB(mwqmSampleLanguageModelRet);
            if (!string.IsNullOrWhiteSpace(mwqmSampleLanguageModelRet2.Error))
            {
                return mwqmSampleLanguageModelRet2;
            }

            Assert.IsNotNull(mwqmSampleLanguageModelRet2);
            CompareMWQMSampleLanguageModels(mwqmSampleLanguageModelRet, mwqmSampleLanguageModelRet2);

            return mwqmSampleLanguageModelRet2;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mwqmSampleService = new MWQMSampleService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmSampleLanguageService = new MWQMSampleLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmSampleLanguageModelNew = new MWQMSampleLanguageModel();
            mwqmSampleLanguage = new MWQMSampleLanguage();
            mwqmSampleServiceTest = new MWQMSampleServiceTest();
            mwqmSampleServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimMWQMSampleLanguageService = new ShimMWQMSampleLanguageService(mwqmSampleLanguageService);
        }
        #endregion Functions private
    }
}

