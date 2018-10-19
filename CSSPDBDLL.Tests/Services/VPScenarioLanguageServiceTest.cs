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
    /// Summary description for VPScenarioServiceTest
    /// </summary>
    [TestClass]
    public class VPScenarioLanguageServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "VPScenarioLanguage";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private VPScenarioService vpScenarioService { get; set; }
        private VPScenarioLanguageService vpScenarioLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private VPScenarioLanguageModel vpScenarioLanguageModelNew { get; set; }
        private VPScenarioLanguage vpScenarioLanguage { get; set; }
        private ShimVPScenarioLanguageService shimVPScenarioLanguageService { get; set; }
        private VPScenarioServiceTest vpScenarioServiceTest { get; set; }
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
        public VPScenarioLanguageServiceTest()
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
        public void VPScenarioLanguageService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(vpScenarioLanguageService);
                Assert.IsNotNull(vpScenarioLanguageService.db);
                Assert.IsNotNull(vpScenarioLanguageService.LanguageRequest);
                Assert.IsNotNull(vpScenarioLanguageService.User);
                Assert.AreEqual(user.Identity.Name, vpScenarioLanguageService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), vpScenarioLanguageService.LanguageRequest);
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_VPScenarioLanguageModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum LangToAdd = LanguageEnum.es;

                using (TransactionScope ts = new TransactionScope())
                {

                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    #region Good
                    FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);

                    string retStr = vpScenarioLanguageService.VPScenarioLanguageModelOK(vpScenarioLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region VPScenarioID
                    FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);
                    vpScenarioLanguageModelNew.VPScenarioID = 0;

                    retStr = vpScenarioLanguageService.VPScenarioLanguageModelOK(vpScenarioLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioID), retStr);
                    #endregion VPScenarioID

                    #region Language
                    int Min = 2;
                    int Max = 2;

                    FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);
                    vpScenarioLanguageModelNew.Language = (LanguageEnum)1000;

                    retStr = vpScenarioLanguageService.VPScenarioLanguageModelOK(vpScenarioLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);

                    FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);
                    vpScenarioLanguageModelNew.Language = LanguageEnum.en;

                    retStr = vpScenarioLanguageService.VPScenarioLanguageModelOK(vpScenarioLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Language

                    #region ScenarioName
                    FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);
                    Min = 3;
                    Max = 100;
                    vpScenarioLanguageModelNew.VPScenarioName = randomService.RandomString("", Min - 1);

                    retStr = vpScenarioLanguageService.VPScenarioLanguageModelOK(vpScenarioLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.VPScenarioName, Min), retStr);

                    FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);
                    vpScenarioLanguageModelNew.VPScenarioName = randomService.RandomString("", Max + 1);

                    retStr = vpScenarioLanguageService.VPScenarioLanguageModelOK(vpScenarioLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.VPScenarioName, Max), retStr);

                    FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);
                    vpScenarioLanguageModelNew.VPScenarioName = randomService.RandomString("", Max - 1);

                    retStr = vpScenarioLanguageService.VPScenarioLanguageModelOK(vpScenarioLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);
                    vpScenarioLanguageModelNew.VPScenarioName = randomService.RandomString("", Max);

                    retStr = vpScenarioLanguageService.VPScenarioLanguageModelOK(vpScenarioLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ScenarioName
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_FillVPScenarioLanguage_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);

                    ContactOK contactOK = vpScenarioLanguageService.IsContactOK();

                    string retStr = vpScenarioLanguageService.FillVPScenarioLanguage(vpScenarioLanguage, vpScenarioLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, vpScenarioLanguage.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = vpScenarioLanguageService.FillVPScenarioLanguage(vpScenarioLanguage, vpScenarioLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, vpScenarioLanguage.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_GetVPScenarioModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    VPScenarioLanguageModel vpScenarioModelLanguageRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);

                    int vpScenarioCount = vpScenarioLanguageService.GetVPScenarioLanguageModelCountDB();
                    Assert.AreEqual(testDBService.Count + 3, vpScenarioCount);
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_GetVPScenarioLanguageModelWithVPScenarioIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);

                    VPScenarioLanguageModel vpScenarioLanguageModelRet2 = vpScenarioLanguageService.GetVPScenarioLanguageModelWithVPScenarioIDAndLanguageDB(vpScenarioLanguageModelRet.VPScenarioID, LangToAdd);
                    Assert.AreEqual(vpScenarioLanguageModelRet.VPScenarioID, vpScenarioLanguageModelRet2.VPScenarioID);
                    Assert.AreEqual(vpScenarioLanguageModelRet.Language, vpScenarioLanguageModelRet2.Language);
                    Assert.AreEqual(LangToAdd, vpScenarioLanguageModelRet2.Language);
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_GetVPScenarioLanguageWithVPScenarioIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);

                    VPScenarioLanguage vpScenarioLanguageRet2 = vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioIDAndLanguageDB(vpScenarioLanguageModelRet.VPScenarioID, LangToAdd);
                    Assert.AreEqual(vpScenarioLanguageModelRet.VPScenarioID, vpScenarioLanguageRet2.VPScenarioID);
                    Assert.AreEqual(vpScenarioLanguageModelRet.Language, (LanguageEnum)vpScenarioLanguageRet2.Language);
                    Assert.AreEqual(LangToAdd, (LanguageEnum)vpScenarioLanguageRet2.Language);
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    VPScenarioLanguageModel vpScenarioLanguageModelRet = vpScenarioLanguageService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, vpScenarioLanguageModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostAddVPScenarioLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);

                    VPScenarioLanguageModel vpScenarioLanguageModelRet2 = UpdateVPScenarioLanguageModel(vpScenarioLanguageModelRet);

                    VPScenarioLanguageModel vpScenarioLanguageModelRet3 = vpScenarioLanguageService.PostDeleteVPScenarioLanguageDB(vpScenarioLanguageModelRet2.VPScenarioID, LangToAdd);
                    Assert.AreEqual("", vpScenarioLanguageModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostAddVPScenarioLanguageDB_VPScenarioModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);

                        string ErrorText = "ErrorText";
                        ShimVPScenarioLanguageService shimVPScenarioLanguageService = new ShimVPScenarioLanguageService(vpScenarioLanguageService);
                        shimVPScenarioLanguageService.VPScenarioLanguageModelOKVPScenarioLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet = vpScenarioLanguageService.PostAddVPScenarioLanguageDB(vpScenarioLanguageModelNew);
                        Assert.AreEqual(ErrorText, vpScenarioLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostAddVPScenarioLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet = vpScenarioLanguageService.PostAddVPScenarioLanguageDB(vpScenarioLanguageModelNew);
                        Assert.AreEqual(ErrorText, vpScenarioLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostAddVPScenarioLanguageDB_GetVPScenarioLanguageModelWithVPScenarioIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.GetVPScenarioLanguageModelWithVPScenarioIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new VPScenarioLanguageModel();
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet = vpScenarioLanguageService.PostAddVPScenarioLanguageDB(vpScenarioLanguageModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.VPScenarioLanguage), vpScenarioLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostAddVPScenarioLanguageDB_FillVPScenarioLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.FillVPScenarioLanguageVPScenarioLanguageVPScenarioLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet = vpScenarioLanguageService.PostAddVPScenarioLanguageDB(vpScenarioLanguageModelNew);
                        Assert.AreEqual(ErrorText, vpScenarioLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostAddVPScenarioLanguageDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet = vpScenarioLanguageService.PostAddVPScenarioLanguageDB(vpScenarioLanguageModelNew);
                        Assert.AreEqual(ErrorText, vpScenarioLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostAddVPScenarioLanguageDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModelRet, vpScenarioLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.FillVPScenarioLanguageVPScenarioLanguageVPScenarioLanguageModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet = vpScenarioLanguageService.PostAddVPScenarioLanguageDB(vpScenarioLanguageModelNew);
                        Assert.IsTrue(vpScenarioLanguageModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostDeleteVPScenarioLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);

                    VPScenarioLanguageModel vpScenarioLanguageModelRet2 = UpdateVPScenarioLanguageModel(vpScenarioLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet3 = vpScenarioLanguageService.PostDeleteVPScenarioLanguageDB(vpScenarioLanguageModelRet2.VPScenarioID, LangToAdd);
                        Assert.AreEqual(ErrorText, vpScenarioLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostDeleteVPScenarioLanguageDB_GetVPScenarioLanguageWithVPScenarioLanguageIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);

                    VPScenarioLanguageModel vpScenarioLanguageModelRet2 = UpdateVPScenarioLanguageModel(vpScenarioLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet3 = vpScenarioLanguageService.PostDeleteVPScenarioLanguageDB(vpScenarioLanguageModelRet2.VPScenarioID, LangToAdd);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.VPScenarioLanguage), vpScenarioLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostDeleteVPScenarioLanguageDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);
                    Assert.AreEqual("", vpScenarioLanguageModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet3 = vpScenarioLanguageService.PostDeleteVPScenarioLanguageDB(vpScenarioLanguageModelRet.VPScenarioID, LangToAdd);
                        Assert.AreEqual(ErrorText, vpScenarioLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostUpdateVPScenarioLanguageDB_VPScenarioLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        FillVPScenarioLanguageModelUpdate(vpScenarioLanguageModelRet);
                        string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.VPScenarioLanguageModelOKVPScenarioLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet2 = vpScenarioLanguageService.PostUpdateVPScenarioLanguageDB(vpScenarioLanguageModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostUpdateVPScenarioLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillVPScenarioLanguageModelUpdate(vpScenarioLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet2 = vpScenarioLanguageService.PostUpdateVPScenarioLanguageDB(vpScenarioLanguageModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostUpdateVPScenarioLanguageDB_GetVPScenarioLanguageWithVPScenarioIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillVPScenarioLanguageModelUpdate(vpScenarioLanguageModelRet);

                        //string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet2 = vpScenarioLanguageService.PostUpdateVPScenarioLanguageDB(vpScenarioLanguageModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.VPScenarioLanguage), vpScenarioLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostUpdateVPScenarioLanguageDB_FillVPScenarioLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillVPScenarioLanguageModelUpdate(vpScenarioLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.FillVPScenarioLanguageVPScenarioLanguageVPScenarioLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet2 = vpScenarioLanguageService.PostUpdateVPScenarioLanguageDB(vpScenarioLanguageModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostUpdateVPScenarioLanguageDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillVPScenarioLanguageModelUpdate(vpScenarioLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        VPScenarioLanguageModel vpScenarioLanguageModelRet2 = vpScenarioLanguageService.PostUpdateVPScenarioLanguageDB(vpScenarioLanguageModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostAddVPScenarioLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    ContactModel contactModelBad = contactModelListBad[0];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    vpScenarioLanguageService = new VPScenarioLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, vpScenarioLanguageModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void VPScenarioLanguageService_PostAddVPScenarioLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    ContactModel contactModelBad = contactModelListGood[2];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    vpScenarioLanguageService = new VPScenarioLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    VPScenarioLanguageModel vpScenarioLanguageModelRet = AddVPScenarioLanguageModel(LangToAdd, vpScenarioModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, vpScenarioLanguageModelRet.Error);

                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private VPScenarioLanguageModel AddVPScenarioLanguageModel(LanguageEnum LangToAdd, VPScenarioModel vpScenarioModel)
        {
            VPScenarioLanguageModel vpScenarioLanguageModelNew = new VPScenarioLanguageModel();
            FillVPScenarioLanguageModelNew(LangToAdd, vpScenarioModel, vpScenarioLanguageModelNew);

            VPScenarioLanguageModel vpScenarioLanguagModelRet = vpScenarioLanguageService.PostAddVPScenarioLanguageDB(vpScenarioLanguageModelNew);
            if (!string.IsNullOrWhiteSpace(vpScenarioLanguagModelRet.Error))
            {
                return vpScenarioLanguagModelRet;
            }

            Assert.IsNotNull(vpScenarioLanguagModelRet);
            CompareVPScenarioLanguageModels(vpScenarioLanguageModelNew, vpScenarioLanguagModelRet);

            return vpScenarioLanguagModelRet;
        }
        private void CompareVPScenarioLanguageModels(VPScenarioLanguageModel vpScenarioLanguageModelNew, VPScenarioLanguageModel vpScenarioLanguageModelRet)
        {
            Assert.AreEqual(vpScenarioLanguageModelNew.Language, vpScenarioLanguageModelRet.Language);
            Assert.AreEqual(vpScenarioLanguageModelNew.VPScenarioName, vpScenarioLanguageModelRet.VPScenarioName);
        }
        private void FillVPScenarioLanguageModelNew(LanguageEnum Language, VPScenarioModel vpScenarioModel, VPScenarioLanguageModel vpScenarioLanguageModel)
        {
            vpScenarioLanguageModel.VPScenarioID = vpScenarioModel.VPScenarioID;
            vpScenarioLanguageModel.VPScenarioName = randomService.RandomString("VPScenarioName", 30);
            vpScenarioLanguageModel.Language = Language;
            vpScenarioLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(vpScenarioLanguageModel.VPScenarioID != 0);
            Assert.IsTrue(vpScenarioLanguageModel.VPScenarioName.Length == 30);
            Assert.IsTrue(vpScenarioLanguageModel.Language == Language);
            Assert.IsTrue(vpScenarioLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private void FillVPScenarioLanguageModelUpdate(VPScenarioLanguageModel vpScenarioLanguageModel)
        {
            vpScenarioLanguageModel.VPScenarioName = randomService.RandomString("VPScenarioName", 30);
            vpScenarioLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(vpScenarioLanguageModel.VPScenarioName.Length == 30);
            Assert.IsTrue(vpScenarioLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private VPScenarioLanguageModel UpdateVPScenarioLanguageModel(VPScenarioLanguageModel vpScenarioLanguageModelRet)
        {
            FillVPScenarioLanguageModelUpdate(vpScenarioLanguageModelRet);

            VPScenarioLanguageModel vpScenarioLanguageModelRet2 = vpScenarioLanguageService.PostUpdateVPScenarioLanguageDB(vpScenarioLanguageModelRet);
            if (!string.IsNullOrWhiteSpace(vpScenarioLanguageModelRet2.Error))
            {
                return vpScenarioLanguageModelRet2;
            }

            Assert.IsNotNull(vpScenarioLanguageModelRet2);
            CompareVPScenarioLanguageModels(vpScenarioLanguageModelRet, vpScenarioLanguageModelRet2);

            return vpScenarioLanguageModelRet2;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            vpScenarioService = new VPScenarioService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            vpScenarioLanguageService = new VPScenarioLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            vpScenarioLanguageModelNew = new VPScenarioLanguageModel();
            vpScenarioLanguage = new VPScenarioLanguage();
            vpScenarioServiceTest = new VPScenarioServiceTest();
            vpScenarioServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimVPScenarioLanguageService = new ShimVPScenarioLanguageService(vpScenarioLanguageService);
        }
        #endregion Functions private
    }
}

