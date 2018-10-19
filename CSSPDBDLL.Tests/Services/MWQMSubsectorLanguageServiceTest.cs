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
    /// Summary description for MWQMSubsectorServiceTest
    /// </summary>
    [TestClass]
    public class MWQMSubsectorLanguageServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MWQMSubsectorLanguage";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MWQMSubsectorService mwqmSubsectorService { get; set; }
        private MWQMSubsectorLanguageService mwqmSubsectorLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelNew { get; set; }
        private MWQMSubsectorLanguage mwqmSubsectorLanguage { get; set; }
        private ShimMWQMSubsectorLanguageService shimMWQMSubsectorLanguageService { get; set; }
        private MWQMSubsectorServiceTest mwqmSubsectorServiceTest { get; set; }
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test subsector.
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
        public MWQMSubsectorLanguageServiceTest()
        {
            setupData = new SetupData();
        }
        #endregion Constructors

        #region Initialize and Cleanup
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to subsector code before subsectorning the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to subsector code after all tests in a class have subsector
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to subsector code before subsectorning each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to subsector code after each test has subsector
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion Initialize and Cleanup

        #region Testing Methods Public
        [TestMethod]
        public void MWQMSubsectorLanguageService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(mwqmSubsectorLanguageService);
                Assert.IsNotNull(mwqmSubsectorLanguageService.db);
                Assert.IsNotNull(mwqmSubsectorLanguageService.LanguageRequest);
                Assert.IsNotNull(mwqmSubsectorLanguageService.User);
                Assert.AreEqual(user.Identity.Name, mwqmSubsectorLanguageService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mwqmSubsectorLanguageService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_MWQMSubsectorLanguageModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum LangToAdd = LanguageEnum.es;

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    #region Good
                    FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);

                    string retStr = mwqmSubsectorLanguageService.MWQMSubsectorLanguageModelOK(mwqmSubsectorLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region MWQMSubsectorID
                    FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);
                    mwqmSubsectorLanguageModelNew.MWQMSubsectorID = 0;

                    retStr = mwqmSubsectorLanguageService.MWQMSubsectorLanguageModelOK(mwqmSubsectorLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSubsectorID), retStr);
                    #endregion MWQMSubsectorID

                    #region Language
                    int Max = 2;

                    FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);
                    mwqmSubsectorLanguageModelNew.Language = (LanguageEnum)10000;

                    retStr = mwqmSubsectorLanguageService.MWQMSubsectorLanguageModelOK(mwqmSubsectorLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);

                    FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);
                    mwqmSubsectorLanguageModelNew.Language = LanguageEnum.en;

                    retStr = mwqmSubsectorLanguageService.MWQMSubsectorLanguageModelOK(mwqmSubsectorLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Language

                    #region SubsectorDesc
                    FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);
                    Max = 250;
                    mwqmSubsectorLanguageModelNew.SubsectorDesc = randomService.RandomString("", 0);

                    retStr = mwqmSubsectorLanguageService.MWQMSubsectorLanguageModelOK(mwqmSubsectorLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);
                    mwqmSubsectorLanguageModelNew.SubsectorDesc = randomService.RandomString("", Max + 1);

                    retStr = mwqmSubsectorLanguageService.MWQMSubsectorLanguageModelOK(mwqmSubsectorLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.SubsectorDesc, Max), retStr);

                    FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);
                    mwqmSubsectorLanguageModelNew.SubsectorDesc = randomService.RandomString("", Max - 1);

                    retStr = mwqmSubsectorLanguageService.MWQMSubsectorLanguageModelOK(mwqmSubsectorLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);
                    mwqmSubsectorLanguageModelNew.SubsectorDesc = randomService.RandomString("", Max);

                    retStr = mwqmSubsectorLanguageService.MWQMSubsectorLanguageModelOK(mwqmSubsectorLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SubsectorDesc
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_FillMWQMSubsectorLanguage_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);

                    ContactOK contactOK = mwqmSubsectorLanguageService.IsContactOK();

                    string retStr = mwqmSubsectorLanguageService.FillMWQMSubsectorLanguage(mwqmSubsectorLanguage, mwqmSubsectorLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mwqmSubsectorLanguage.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mwqmSubsectorLanguageService.FillMWQMSubsectorLanguage(mwqmSubsectorLanguage, mwqmSubsectorLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, mwqmSubsectorLanguage.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_GetMWQMSubsectorModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSubsectorLanguageModel mwqmSubsectorModelLanguageRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);

                    int mwqmSubsectorCount = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageModelCountDB();
                    Assert.AreEqual(testDBService.Count + 3, mwqmSubsectorCount);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_GetMWQMSubsectorLanguageModelWithMWQMSubsectorIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet2 = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageModelWithMWQMSubsectorIDAndLanguageDB(mwqmSubsectorLanguageModelRet.MWQMSubsectorID, LangToAdd);
                    Assert.AreEqual(mwqmSubsectorLanguageModelRet.MWQMSubsectorID, mwqmSubsectorLanguageModelRet2.MWQMSubsectorID);
                    Assert.AreEqual(mwqmSubsectorLanguageModelRet.Language, mwqmSubsectorLanguageModelRet2.Language);
                    Assert.AreEqual(LangToAdd, mwqmSubsectorLanguageModelRet2.Language);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_GetMWQMSubsectorLanguageWithMWQMSubsectorIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);

                    MWQMSubsectorLanguage mwqmSubsectorLanguageRet2 = mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageWithMWQMSubsectorIDAndLanguageDB(mwqmSubsectorLanguageModelRet.MWQMSubsectorID, LangToAdd);
                    Assert.AreEqual(mwqmSubsectorLanguageModelRet.MWQMSubsectorID, mwqmSubsectorLanguageRet2.MWQMSubsectorID);
                    Assert.AreEqual(mwqmSubsectorLanguageModelRet.Language, (LanguageEnum)mwqmSubsectorLanguageRet2.Language);
                    Assert.AreEqual(LangToAdd, (LanguageEnum)mwqmSubsectorLanguageRet2.Language);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostAddMWQMSubsectorLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet2 = UpdateMWQMSubsectorLanguageModel(mwqmSubsectorLanguageModelRet);

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet3 = mwqmSubsectorLanguageService.PostDeleteMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelRet2.MWQMSubsectorID, LangToAdd);
                    Assert.AreEqual("", mwqmSubsectorLanguageModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostAddMWQMSubsectorLanguageDB_MWQMSubsectorModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);

                        string ErrorText = "ErrorText";
                        ShimMWQMSubsectorLanguageService shimMWQMSubsectorLanguageService = new ShimMWQMSubsectorLanguageService(mwqmSubsectorLanguageService);
                        shimMWQMSubsectorLanguageService.MWQMSubsectorLanguageModelOKMWQMSubsectorLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = mwqmSubsectorLanguageService.PostAddMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelNew);
                        Assert.AreEqual(ErrorText, mwqmSubsectorLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostAddMWQMSubsectorLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = mwqmSubsectorLanguageService.PostAddMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelNew);
                        Assert.AreEqual(ErrorText, mwqmSubsectorLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostAddMWQMSubsectorLanguageDB_GetMWQMSubsectorLanguageModelWithMWQMSubsectorIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.GetMWQMSubsectorLanguageModelWithMWQMSubsectorIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new MWQMSubsectorLanguageModel();
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = mwqmSubsectorLanguageService.PostAddMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMSubsectorLanguage), mwqmSubsectorLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostAddMWQMSubsectorLanguageDB_FillMWQMSubsectorLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.FillMWQMSubsectorLanguageMWQMSubsectorLanguageMWQMSubsectorLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = mwqmSubsectorLanguageService.PostAddMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelNew);
                        Assert.AreEqual(ErrorText, mwqmSubsectorLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostAddMWQMSubsectorLanguageDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = mwqmSubsectorLanguageService.PostAddMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelNew);
                        Assert.AreEqual(ErrorText, mwqmSubsectorLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostAddMWQMSubsectorLanguageDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModelRet, mwqmSubsectorLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.FillMWQMSubsectorLanguageMWQMSubsectorLanguageMWQMSubsectorLanguageModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = mwqmSubsectorLanguageService.PostAddMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelNew);
                        Assert.IsTrue(mwqmSubsectorLanguageModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostDeleteMWQMSubsectorLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet2 = UpdateMWQMSubsectorLanguageModel(mwqmSubsectorLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet3 = mwqmSubsectorLanguageService.PostDeleteMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelRet2.MWQMSubsectorID, LangToAdd);
                        Assert.AreEqual(ErrorText, mwqmSubsectorLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostDeleteMWQMSubsectorLanguageDB_GetMWQMSubsectorLanguageWithMWQMSubsectorLanguageIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet2 = UpdateMWQMSubsectorLanguageModel(mwqmSubsectorLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.GetMWQMSubsectorLanguageWithMWQMSubsectorIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet3 = mwqmSubsectorLanguageService.PostDeleteMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelRet2.MWQMSubsectorID, LangToAdd);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMSubsectorLanguage), mwqmSubsectorLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostDeleteMWQMSubsectorLanguageDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);


                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet3 = mwqmSubsectorLanguageService.PostDeleteMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelRet.MWQMSubsectorID, LangToAdd);
                        Assert.AreEqual(ErrorText, mwqmSubsectorLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostUpdateMWQMSubsectorLanguageDB_MWQMSubsectorLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        FillMWQMSubsectorLanguageModelUpdate(mwqmSubsectorLanguageModelRet);
                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.MWQMSubsectorLanguageModelOKMWQMSubsectorLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet2 = mwqmSubsectorLanguageService.PostUpdateMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelRet);
                        Assert.AreEqual(ErrorText, mwqmSubsectorLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostUpdateMWQMSubsectorLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillMWQMSubsectorLanguageModelUpdate(mwqmSubsectorLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet2 = mwqmSubsectorLanguageService.PostUpdateMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelRet);
                        Assert.AreEqual(ErrorText, mwqmSubsectorLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostUpdateMWQMSubsectorLanguageDB_GetMWQMSubsectorLanguageWithMWQMSubsectorIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillMWQMSubsectorLanguageModelUpdate(mwqmSubsectorLanguageModelRet);

                        //string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.GetMWQMSubsectorLanguageWithMWQMSubsectorIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet2 = mwqmSubsectorLanguageService.PostUpdateMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSubsectorLanguage), mwqmSubsectorLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostUpdateMWQMSubsectorLanguageDB_FillMWQMSubsectorLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillMWQMSubsectorLanguageModelUpdate(mwqmSubsectorLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.FillMWQMSubsectorLanguageMWQMSubsectorLanguageMWQMSubsectorLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet2 = mwqmSubsectorLanguageService.PostUpdateMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelRet);
                        Assert.AreEqual(ErrorText, mwqmSubsectorLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostUpdateMWQMSubsectorLanguageDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillMWQMSubsectorLanguageModelUpdate(mwqmSubsectorLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet2 = mwqmSubsectorLanguageService.PostUpdateMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelRet);
                        Assert.AreEqual(ErrorText, mwqmSubsectorLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostAddMWQMSubsectorLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    ContactModel contactModelBad = contactModelListBad[0];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mwqmSubsectorLanguageModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorLanguageService_PostAddMWQMSubsectorLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorServiceTest.AddMWQMSubsectorModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    ContactModel contactModelBad = contactModelListGood[2];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = AddMWQMSubsectorLanguageModel(LangToAdd, mwqmSubsectorModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mwqmSubsectorLanguageModelRet.Error);

                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private MWQMSubsectorLanguageModel AddMWQMSubsectorLanguageModel(LanguageEnum LangToAdd, MWQMSubsectorModel mwqmSubsectorModel)
        {
            MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelNew = new MWQMSubsectorLanguageModel();
            FillMWQMSubsectorLanguageModelNew(LangToAdd, mwqmSubsectorModel, mwqmSubsectorLanguageModelNew);

            MWQMSubsectorLanguageModel mwqmSubsectorLanguagModelRet = mwqmSubsectorLanguageService.PostAddMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelNew);
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguagModelRet.Error))
            {
                return mwqmSubsectorLanguagModelRet;
            }
            Assert.IsNotNull(mwqmSubsectorLanguagModelRet);
            CompareMWQMSubsectorLanguageModels(mwqmSubsectorLanguageModelNew, mwqmSubsectorLanguagModelRet);

            return mwqmSubsectorLanguagModelRet;
        }
        private void CompareMWQMSubsectorLanguageModels(MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelNew, MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet)
        {
            Assert.AreEqual(mwqmSubsectorLanguageModelNew.Language, mwqmSubsectorLanguageModelRet.Language);
            Assert.AreEqual(mwqmSubsectorLanguageModelNew.SubsectorDesc, mwqmSubsectorLanguageModelRet.SubsectorDesc);
        }
        private void FillMWQMSubsectorLanguageModelNew(LanguageEnum Language, MWQMSubsectorModel mwqmSubsectorModel, MWQMSubsectorLanguageModel mwqmSubsectorLanguageModel)
        {
            mwqmSubsectorLanguageModel.MWQMSubsectorID = mwqmSubsectorModel.MWQMSubsectorID;
            mwqmSubsectorLanguageModel.SubsectorDesc = randomService.RandomString("MWQMSubsectorName", 30);
            mwqmSubsectorLanguageModel.Language = Language;
            mwqmSubsectorLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;
            Assert.IsTrue(mwqmSubsectorLanguageModel.MWQMSubsectorID != 0);
            Assert.IsTrue(mwqmSubsectorLanguageModel.SubsectorDesc.Length == 30);
            Assert.IsTrue(mwqmSubsectorLanguageModel.Language == Language);
            Assert.IsTrue(mwqmSubsectorLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private void FillMWQMSubsectorLanguageModelUpdate(MWQMSubsectorLanguageModel mwqmSubsectorLanguageModel)
        {
            mwqmSubsectorLanguageModel.SubsectorDesc = randomService.RandomString("MWQMSubsectorName", 30);
            mwqmSubsectorLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;
            Assert.IsTrue(mwqmSubsectorLanguageModel.SubsectorDesc.Length == 30);
            Assert.IsTrue(mwqmSubsectorLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private MWQMSubsectorLanguageModel UpdateMWQMSubsectorLanguageModel(MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet)
        {
            FillMWQMSubsectorLanguageModelUpdate(mwqmSubsectorLanguageModelRet);

            MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet2 = mwqmSubsectorLanguageService.PostUpdateMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModelRet);
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageModelRet2.Error))
            {
                return mwqmSubsectorLanguageModelRet2;
            }
            Assert.IsNotNull(mwqmSubsectorLanguageModelRet2);
            CompareMWQMSubsectorLanguageModels(mwqmSubsectorLanguageModelRet, mwqmSubsectorLanguageModelRet2);

            return mwqmSubsectorLanguageModelRet2;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mwqmSubsectorService = new MWQMSubsectorService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmSubsectorLanguageModelNew = new MWQMSubsectorLanguageModel();
            mwqmSubsectorLanguage = new MWQMSubsectorLanguage();
            mwqmSubsectorServiceTest = new MWQMSubsectorServiceTest();
            mwqmSubsectorServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimMWQMSubsectorLanguageService = new ShimMWQMSubsectorLanguageService(mwqmSubsectorLanguageService);
        }
        #endregion Functions private
    }
}

