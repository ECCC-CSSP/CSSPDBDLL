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
using System.Threading;
using System.Globalization;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for InfrastructureServiceTest
    /// </summary>
    [TestClass]
    public class InfrastructureLanguageServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "InfrastructureLanguage";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private InfrastructureLanguageService infrastructureLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private InfrastructureLanguageModel infrastructureLanguageModelNew { get; set; }
        private InfrastructureLanguage infrastructureLanguage { get; set; }
        private ShimInfrastructureLanguageService shimInfrastructureLanguageService { get; set; }
        private InfrastructureServiceTest infrastructureServiceTest { get; set; }
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
        public InfrastructureLanguageServiceTest()
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
        public void InfrastructureLanguageService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(infrastructureLanguageService);
                Assert.IsNotNull(infrastructureLanguageService.db);
                Assert.IsNotNull(infrastructureLanguageService.LanguageRequest);
                Assert.IsNotNull(infrastructureLanguageService.User);
                Assert.AreEqual(user.Identity.Name, infrastructureLanguageService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), infrastructureLanguageService.LanguageRequest);
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_InfrastructureLanguageModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = infrastructureServiceTest.AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    #region InfrastructureID
                    infrastructureLanguageModelNew.InfrastructureID = infrastructureModelRet.InfrastructureID;
                    FillInfrastructureLanguageModel(infrastructureLanguageModelNew);
                    infrastructureLanguageModelNew.InfrastructureID = 0;

                    string retStr = infrastructureLanguageService.InfrastructureLanguageModelOK(infrastructureLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureID), retStr);

                    infrastructureLanguageModelNew.InfrastructureID = infrastructureModelRet.InfrastructureID;
                    FillInfrastructureLanguageModel(infrastructureLanguageModelNew);

                    retStr = infrastructureLanguageService.InfrastructureLanguageModelOK(infrastructureLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion InfrastructureID

                    #region Language
                    //int Min = 2;
                    int Max = 2;

                    FillInfrastructureLanguageModel(infrastructureLanguageModelNew);
                    infrastructureLanguageModelNew.Language = LanguageEnum.en;

                    retStr = infrastructureLanguageService.InfrastructureLanguageModelOK(infrastructureLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureLanguageModel(infrastructureLanguageModelNew);
                    infrastructureLanguageModelNew.Language = (LanguageEnum)1000;

                    retStr = infrastructureLanguageService.InfrastructureLanguageModelOK(infrastructureLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);
                    #endregion Language

                    #region Comment
                    FillInfrastructureLanguageModel(infrastructureLanguageModelNew);
                    Max = 10000;
                    infrastructureLanguageModelNew.Comment = randomService.RandomString("", 0);

                    retStr = infrastructureLanguageService.InfrastructureLanguageModelOK(infrastructureLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureLanguageModel(infrastructureLanguageModelNew);
                    infrastructureLanguageModelNew.Comment = randomService.RandomString("", Max + 1);

                    retStr = infrastructureLanguageService.InfrastructureLanguageModelOK(infrastructureLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Comment, Max), retStr);

                    FillInfrastructureLanguageModel(infrastructureLanguageModelNew);
                    infrastructureLanguageModelNew.Comment = randomService.RandomString("", Max - 1);

                    retStr = infrastructureLanguageService.InfrastructureLanguageModelOK(infrastructureLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureLanguageModel(infrastructureLanguageModelNew);
                    infrastructureLanguageModelNew.Comment = randomService.RandomString("", Max);

                    retStr = infrastructureLanguageService.InfrastructureLanguageModelOK(infrastructureLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Comment
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_FillInfrastructureLanguage_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = infrastructureServiceTest.AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    infrastructureLanguageModelNew.InfrastructureID = infrastructureModelRet.InfrastructureID;
                    FillInfrastructureLanguageModel(infrastructureLanguageModelNew);

                    ContactOK contactOK = infrastructureLanguageService.IsContactOK();

                    string retStr = infrastructureLanguageService.FillInfrastructureLanguage(infrastructureLanguage, infrastructureLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, infrastructureLanguage.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = infrastructureLanguageService.FillInfrastructureLanguage(infrastructureLanguage, infrastructureLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, infrastructureLanguage.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_GetInfrastructureModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureModelLanguageRet = AddInfrastructureLanguageModel(LangToAdd);

                    int infrastructureCount = infrastructureLanguageService.GetInfrastructureLanguageModelCountDB();
                    Assert.AreEqual(testDBService.Count + 3, infrastructureCount);
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                    Assert.AreEqual("", infrastructureLanguageModelRet.Error);

                    InfrastructureLanguageModel infrastructureLanguageModelRet2 = infrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureLanguageModelRet.InfrastructureID, LangToAdd);
                    Assert.AreEqual(infrastructureLanguageModelRet.InfrastructureID, infrastructureLanguageModelRet2.InfrastructureID);
                    Assert.AreEqual(infrastructureLanguageModelRet.Language, infrastructureLanguageModelRet2.Language);
                    Assert.AreEqual(LangToAdd, infrastructureLanguageModelRet2.Language);
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_GetInfrastructureLanguageWithInfrastructureIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                    Assert.AreEqual("", infrastructureLanguageModelRet.Error);

                    InfrastructureLanguage infrastructureLanguageRet2 = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureIDAndLanguageDB(infrastructureLanguageModelRet.InfrastructureID, LangToAdd);
                    Assert.AreEqual(infrastructureLanguageModelRet.InfrastructureID, infrastructureLanguageRet2.InfrastructureID);
                    Assert.AreEqual(infrastructureLanguageModelRet.Language, (LanguageEnum)infrastructureLanguageRet2.Language);
                    Assert.AreEqual(LangToAdd, (LanguageEnum)infrastructureLanguageRet2.Language);
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    InfrastructureLanguageModel infrastructureLanguageModelRet = infrastructureLanguageService.ReturnError(ErrorText);

                    Assert.AreEqual(ErrorText, infrastructureLanguageModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostAddInfrastructureLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                    Assert.AreEqual("", infrastructureLanguageModelRet.Error);

                    InfrastructureLanguageModel infrastructureLanguageModelRet2 = UpdateInfrastructureLanguageModel(infrastructureLanguageModelRet);
                    Assert.AreEqual("", infrastructureLanguageModelRet2.Error);

                    InfrastructureLanguageModel infrastructureLanguageModelRet3 = infrastructureLanguageService.PostDeleteInfrastructureLanguageDB(infrastructureLanguageModelRet2.InfrastructureID, LangToAdd);
                    Assert.AreEqual("", infrastructureLanguageModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostAddInfrastructureLanguageDB_InfrastructureLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        LanguageEnum LangToAdd = LanguageEnum.es;

                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimInfrastructureLanguageService.InfrastructureLanguageModelOKInfrastructureLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                        Assert.AreEqual(ErrorText, infrastructureLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostAddInfrastructureLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;

                        string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                        Assert.AreEqual(ErrorText, infrastructureLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostAddInfrastructureLanguageDB_GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;

                        //string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new InfrastructureLanguageModel();
                        };
                        InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.InfrastructureLanguage), infrastructureLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostAddInfrastructureLanguageDB_FillInfrastructureLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;

                        string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.FillInfrastructureLanguageInfrastructureLanguageInfrastructureLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                        Assert.AreEqual(ErrorText, infrastructureLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostAddInfrastructureLanguageDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;

                        string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                        Assert.AreEqual(ErrorText, infrastructureLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostAddInfrastructureLanguageDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;

                        //string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.FillInfrastructureLanguageInfrastructureLanguageInfrastructureLanguageModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                        Assert.IsTrue(infrastructureLanguageModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostDeleteInfrastructureLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                    Assert.AreEqual("", infrastructureLanguageModelRet.Error);

                    InfrastructureLanguageModel infrastructureLanguageModelRet2 = UpdateInfrastructureLanguageModel(infrastructureLanguageModelRet);
                    Assert.AreEqual("", infrastructureLanguageModelRet2.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet3 = infrastructureLanguageService.PostDeleteInfrastructureLanguageDB(infrastructureLanguageModelRet2.InfrastructureID, LangToAdd);
                        Assert.AreEqual(ErrorText, infrastructureLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostDeleteInfrastructureLanguageDB_GetInfrastructureLanguageWithInfrastructureIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                    Assert.AreEqual("", infrastructureLanguageModelRet.Error);

                    InfrastructureLanguageModel infrastructureLanguageModelRet2 = UpdateInfrastructureLanguageModel(infrastructureLanguageModelRet);
                    Assert.AreEqual("", infrastructureLanguageModelRet2.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet3 = infrastructureLanguageService.PostDeleteInfrastructureLanguageDB(infrastructureLanguageModelRet2.InfrastructureID, LangToAdd);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.InfrastructureLanguage), infrastructureLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostDeleteInfrastructureLanguageDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                    Assert.AreEqual("", infrastructureLanguageModelRet.Error);

                    InfrastructureLanguageModel infrastructureLanguageModelRet2 = UpdateInfrastructureLanguageModel(infrastructureLanguageModelRet);
                    Assert.AreEqual("", infrastructureLanguageModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet3 = infrastructureLanguageService.PostDeleteInfrastructureLanguageDB(infrastructureLanguageModelRet2.InfrastructureID, LangToAdd);
                        Assert.AreEqual(ErrorText, infrastructureLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostUpdateInfrastructureLanguageDB_InfrastructureLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                    Assert.AreEqual("", infrastructureLanguageModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        FillInfrastructureLanguageModel(infrastructureLanguageModelRet);
                        string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.InfrastructureLanguageModelOKInfrastructureLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet2 = UpdateInfrastructureLanguageModel(infrastructureLanguageModelRet);
                        Assert.AreEqual(ErrorText, infrastructureLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostUpdateInfrastructureLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                    Assert.AreEqual("", infrastructureLanguageModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillInfrastructureLanguageModel(infrastructureLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet2 = UpdateInfrastructureLanguageModel(infrastructureLanguageModelRet);
                        Assert.AreEqual(ErrorText, infrastructureLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostUpdateInfrastructureLanguageDB_GetInfrastructureLanguageWithInfrastructureIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                    Assert.AreEqual("", infrastructureLanguageModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillInfrastructureLanguageModel(infrastructureLanguageModelRet);

                        //string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet2 = UpdateInfrastructureLanguageModel(infrastructureLanguageModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.InfrastructureLanguage), infrastructureLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostUpdateInfrastructureLanguageDB_FillInfrastructureLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                    Assert.AreEqual("", infrastructureLanguageModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillInfrastructureLanguageModel(infrastructureLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.FillInfrastructureLanguageInfrastructureLanguageInfrastructureLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet2 = UpdateInfrastructureLanguageModel(infrastructureLanguageModelRet);
                        Assert.AreEqual(ErrorText, infrastructureLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostUpdateInfrastructureLanguageDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);
                    Assert.AreEqual("", infrastructureLanguageModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillInfrastructureLanguageModel(infrastructureLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        InfrastructureLanguageModel infrastructureLanguageModelRet2 = UpdateInfrastructureLanguageModel(infrastructureLanguageModelRet);
                        Assert.AreEqual(ErrorText, infrastructureLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostAddInfrastructureLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);

                    // Assert 1
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, infrastructureLanguageModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureLanguageService_PostAddInfrastructureLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    InfrastructureLanguageModel infrastructureLanguageModelRet = AddInfrastructureLanguageModel(LangToAdd);

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, infrastructureLanguageModelRet.Error);
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private InfrastructureLanguageModel AddInfrastructureLanguageModel(LanguageEnum LangToAdd)
        {
            InfrastructureModel infrastructureModel = infrastructureServiceTest.AddInfrastructureModel();
            if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
            {
                return new InfrastructureLanguageModel() { Error = infrastructureModel.Error };
            }

            infrastructureLanguageModelNew.InfrastructureID = infrastructureModel.InfrastructureID;
            FillInfrastructureLanguageModel(infrastructureLanguageModelNew);

            InfrastructureLanguageModel infrastructureLanguagModelRet = infrastructureLanguageService.PostAddInfrastructureLanguageDB(infrastructureLanguageModelNew);
            if (!string.IsNullOrWhiteSpace(infrastructureLanguagModelRet.Error))
            {
                return infrastructureLanguagModelRet;
            }

            CompareInfrastructureLanguageModels(infrastructureLanguageModelNew, infrastructureLanguagModelRet);

            return infrastructureLanguagModelRet;
        }
        private void CompareInfrastructureLanguageModels(InfrastructureLanguageModel infrastructureLanguageModelNew, InfrastructureLanguageModel infrastructureLanguageModelRet)
        {
            Assert.AreEqual(infrastructureLanguageModelNew.Language, infrastructureLanguageModelRet.Language);
            Assert.AreEqual(infrastructureLanguageModelNew.Comment, infrastructureLanguageModelRet.Comment);
        }
        private void FillInfrastructureLanguageModel(InfrastructureLanguageModel infrastructureLanguageModel)
        {
            infrastructureLanguageModel.InfrastructureID = infrastructureLanguageModel.InfrastructureID;
            infrastructureLanguageModel.Language = LanguageEnum.es;
            infrastructureLanguageModel.Comment = randomService.RandomString("Busy Text", 20);
            infrastructureLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(infrastructureLanguageModel.InfrastructureID != 0);
            Assert.IsTrue(infrastructureLanguageModel.Language == LanguageEnum.es);
            Assert.IsTrue(infrastructureLanguageModel.Comment.Length == 20);
            Assert.IsTrue(infrastructureLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private InfrastructureLanguageModel UpdateInfrastructureLanguageModel(InfrastructureLanguageModel infrastructureLanguageModelRet)
        {
            FillInfrastructureLanguageModel(infrastructureLanguageModelRet);

            InfrastructureLanguageModel infrastructureLanguageModelRet2 = infrastructureLanguageService.PostUpdateInfrastructureLanguageDB(infrastructureLanguageModelRet);
            if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelRet2.Error))
            {
                return infrastructureLanguageModelRet2;
            }

            Assert.IsNotNull(infrastructureLanguageModelRet2);
            CompareInfrastructureLanguageModels(infrastructureLanguageModelRet, infrastructureLanguageModelRet2);

            return infrastructureLanguageModelRet2;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            infrastructureLanguageService = new InfrastructureLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            infrastructureLanguageModelNew = new InfrastructureLanguageModel();
            infrastructureLanguage = new InfrastructureLanguage();
            infrastructureServiceTest = new InfrastructureServiceTest();
            infrastructureServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimInfrastructureLanguageService = new ShimInfrastructureLanguageService(infrastructureLanguageService);
        }
        #endregion Functions private
    }
}

