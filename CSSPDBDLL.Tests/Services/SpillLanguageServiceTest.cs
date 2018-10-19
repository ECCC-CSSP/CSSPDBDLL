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
    /// Summary description for SpillServiceTest
    /// </summary>
    [TestClass]
    public class SpillLanguageServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "SpillLanguage";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private SpillService spillService { get; set; }
        private SpillLanguageService spillLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private SpillLanguageModel spillLanguageModelNew { get; set; }
        private SpillLanguage spillLanguage { get; set; }
        private ShimSpillLanguageService shimSpillLanguageService { get; set; }
        private SpillServiceTest spillServiceTest { get; set; }
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
        public SpillLanguageServiceTest()
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
        public void SpillLanguageService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(spillLanguageService);
                Assert.IsNotNull(spillLanguageService.db);
                Assert.IsNotNull(spillLanguageService.LanguageRequest);
                Assert.IsNotNull(spillLanguageService.User);
                Assert.AreEqual(user.Identity.Name, spillLanguageService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), spillLanguageService.LanguageRequest);
            }
        }
        [TestMethod]
        public void SpillLanguageService_SpillLanguageModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum LangToAdd = LanguageEnum.es;

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    #region Good
                    FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);

                    string retStr = spillLanguageService.SpillLanguageModelOK(spillLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region SpillID
                    FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);
                    spillLanguageModelNew.SpillID = 0;

                    retStr = spillLanguageService.SpillLanguageModelOK(spillLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SpillID), retStr);
                    #endregion SpillID

                    #region Language
                    FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);
                    spillLanguageModelNew.Language = (LanguageEnum)1000;

                    retStr = spillLanguageService.SpillLanguageModelOK(spillLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);

                    FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);
                    spillLanguageModelNew.Language = LanguageEnum.en;

                    retStr = spillLanguageService.SpillLanguageModelOK(spillLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Language

                    #region SpillComment
                    FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);
                    int Max = 10000;
                    spillLanguageModelNew.SpillComment = randomService.RandomString("", 0);

                    retStr = spillLanguageService.SpillLanguageModelOK(spillLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);
                    spillLanguageModelNew.SpillComment = randomService.RandomString("", Max + 1);

                    retStr = spillLanguageService.SpillLanguageModelOK(spillLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.SpillComment, Max), retStr);

                    FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);
                    spillLanguageModelNew.SpillComment = randomService.RandomString("", Max - 1);

                    retStr = spillLanguageService.SpillLanguageModelOK(spillLanguageModelNew);
                    Assert.AreEqual("", retStr);

                    FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);
                    spillLanguageModelNew.SpillComment = randomService.RandomString("", Max);

                    retStr = spillLanguageService.SpillLanguageModelOK(spillLanguageModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SpillComment
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_FillSpillLanguage_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);

                    ContactOK contactOK = spillLanguageService.IsContactOK();

                    string retStr = spillLanguageService.FillSpillLanguage(spillLanguage, spillLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, spillLanguage.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = spillLanguageService.FillSpillLanguage(spillLanguage, spillLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, spillLanguage.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_GetSpillModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    SpillLanguageModel spillModelLanguageRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    int spillCount = spillLanguageService.GetSpillLanguageModelCountDB();
                    Assert.AreEqual(testDBService.Count + 3, spillCount);
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_GetSpillLanguageModelWithSpillIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    SpillLanguageModel spillLanguageModelRet2 = spillLanguageService.GetSpillLanguageModelWithSpillIDAndLanguageDB(spillLanguageModelRet.SpillID, LangToAdd);
                    Assert.AreEqual(spillLanguageModelRet.SpillID, spillLanguageModelRet2.SpillID);
                    Assert.AreEqual(spillLanguageModelRet.Language, spillLanguageModelRet2.Language);
                    Assert.AreEqual(LangToAdd, spillLanguageModelRet2.Language);
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_GetSpillLanguageWithSpillIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    SpillLanguage spillLanguageRet2 = spillLanguageService.GetSpillLanguageWithSpillIDAndLanguageDB(spillLanguageModelRet.SpillID, LangToAdd);
                    Assert.AreEqual(spillLanguageModelRet.SpillID, spillLanguageRet2.SpillID);
                    Assert.AreEqual(spillLanguageModelRet.Language, (LanguageEnum)spillLanguageRet2.Language);
                    Assert.AreEqual(LangToAdd, (LanguageEnum)spillLanguageRet2.Language);
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    SpillLanguageModel spillLanguageModelRet = spillLanguageService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, spillLanguageModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostAddSpillLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    SpillLanguageModel spillLanguageModelRet2 = UpdateSpillLanguageModel(spillLanguageModelRet);

                    SpillLanguageModel spillLanguageModelRet3 = spillLanguageService.PostDeleteSpillLanguageDB(spillLanguageModelRet2.SpillID, LangToAdd);
                    Assert.AreEqual("", spillLanguageModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostAddSpillLanguageDB_SpillModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);

                        string ErrorText = "ErrorText";
                        ShimSpillLanguageService shimSpillLanguageService = new ShimSpillLanguageService(spillLanguageService);
                        shimSpillLanguageService.SpillLanguageModelOKSpillLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        SpillLanguageModel spillLanguageModelRet = spillLanguageService.PostAddSpillLanguageDB(spillLanguageModelNew);
                        Assert.AreEqual(ErrorText, spillLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostAddSpillLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimSpillLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        SpillLanguageModel spillLanguageModelRet = spillLanguageService.PostAddSpillLanguageDB(spillLanguageModelNew);
                        Assert.AreEqual(ErrorText, spillLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostAddSpillLanguageDB_GetSpillLanguageModelWithSpillIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimSpillLanguageService.GetSpillLanguageModelWithSpillIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new SpillLanguageModel();
                        };

                        SpillLanguageModel spillLanguageModelRet = spillLanguageService.PostAddSpillLanguageDB(spillLanguageModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.SpillLanguage), spillLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostAddSpillLanguageDB_FillSpillLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimSpillLanguageService.FillSpillLanguageSpillLanguageSpillLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        SpillLanguageModel spillLanguageModelRet = spillLanguageService.PostAddSpillLanguageDB(spillLanguageModelNew);
                        Assert.AreEqual(ErrorText, spillLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostAddSpillLanguageDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimSpillLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        SpillLanguageModel spillLanguageModelRet = spillLanguageService.PostAddSpillLanguageDB(spillLanguageModelNew);
                        Assert.AreEqual(ErrorText, spillLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostAddSpillLanguageDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillSpillLanguageModelNew(LangToAdd, spillModelRet, spillLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimSpillLanguageService.FillSpillLanguageSpillLanguageSpillLanguageModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        SpillLanguageModel spillLanguageModelRet = spillLanguageService.PostAddSpillLanguageDB(spillLanguageModelNew);
                        Assert.IsTrue(spillLanguageModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostDeleteSpillLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    SpillLanguageModel spillLanguageModelRet2 = UpdateSpillLanguageModel(spillLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimSpillLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        SpillLanguageModel spillLanguageModelRet3 = spillLanguageService.PostDeleteSpillLanguageDB(spillLanguageModelRet2.SpillID, LangToAdd);
                        Assert.AreEqual(ErrorText, spillLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostDeleteSpillLanguageDB_GetSpillLanguageWithSpillLanguageIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    SpillLanguageModel spillLanguageModelRet2 = UpdateSpillLanguageModel(spillLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimSpillLanguageService.GetSpillLanguageWithSpillIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        SpillLanguageModel spillLanguageModelRet3 = spillLanguageService.PostDeleteSpillLanguageDB(spillLanguageModelRet2.SpillID, LangToAdd);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, "SpillLanguage"), spillLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostDeleteSpillLanguageDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimSpillLanguageService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        SpillLanguageModel spillLanguageModelRet3 = spillLanguageService.PostDeleteSpillLanguageDB(spillLanguageModelRet.SpillID, LangToAdd);
                        Assert.AreEqual(ErrorText, spillLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostUpdateSpillLanguageDB_SpillLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        FillSpillLanguageModelUpdate(spillLanguageModelRet);
                        string ErrorText = "ErrorText";
                        shimSpillLanguageService.SpillLanguageModelOKSpillLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        SpillLanguageModel spillLanguageModelRet2 = spillLanguageService.PostUpdateSpillLanguageDB(spillLanguageModelRet);
                        Assert.AreEqual(ErrorText, spillLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostUpdateSpillLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillSpillLanguageModelUpdate(spillLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimSpillLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        SpillLanguageModel spillLanguageModelRet2 = spillLanguageService.PostUpdateSpillLanguageDB(spillLanguageModelRet);
                        Assert.AreEqual(ErrorText, spillLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostUpdateSpillLanguageDB_GetSpillLanguageWithSpillIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillSpillLanguageModelUpdate(spillLanguageModelRet);

                        //string ErrorText = "ErrorText";
                        shimSpillLanguageService.GetSpillLanguageWithSpillIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        SpillLanguageModel spillLanguageModelRet2 = spillLanguageService.PostUpdateSpillLanguageDB(spillLanguageModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.SpillLanguage), spillLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostUpdateSpillLanguageDB_FillSpillLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillSpillLanguageModelUpdate(spillLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimSpillLanguageService.FillSpillLanguageSpillLanguageSpillLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        SpillLanguageModel spillLanguageModelRet2 = spillLanguageService.PostUpdateSpillLanguageDB(spillLanguageModelRet);
                        Assert.AreEqual(ErrorText, spillLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostUpdateSpillLanguageDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillSpillLanguageModelUpdate(spillLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimSpillLanguageService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        SpillLanguageModel spillLanguageModelRet2 = spillLanguageService.PostUpdateSpillLanguageDB(spillLanguageModelRet);
                        Assert.AreEqual(ErrorText, spillLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostAddSpillLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    ContactModel contactModelBad = contactModelListBad[0];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    spillLanguageService = new SpillLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    // Assert 1
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, spillLanguageModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void SpillLanguageService_PostAddSpillLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = spillServiceTest.AddSpillModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    ContactModel contactModelBad = contactModelListGood[2];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    spillLanguageService = new SpillLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    SpillLanguageModel spillLanguageModelRet = AddSpillLanguageModel(LangToAdd, spillModelRet);

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, spillLanguageModelRet.Error);

                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private SpillLanguageModel AddSpillLanguageModel(LanguageEnum LangToAdd, SpillModel spillModel)
        {
            SpillLanguageModel spillLanguageModelNew = new SpillLanguageModel();
            FillSpillLanguageModelNew(LangToAdd, spillModel, spillLanguageModelNew);

            SpillLanguageModel spillLanguagModelRet = spillLanguageService.PostAddSpillLanguageDB(spillLanguageModelNew);
            if (!string.IsNullOrWhiteSpace(spillLanguagModelRet.Error))
            {
                return spillLanguagModelRet;
            }

            Assert.IsNotNull(spillLanguagModelRet);
            CompareSpillLanguageModels(spillLanguageModelNew, spillLanguagModelRet);

            return spillLanguagModelRet;
        }
        private void CompareSpillLanguageModels(SpillLanguageModel spillLanguageModelNew, SpillLanguageModel spillLanguageModelRet)
        {
            Assert.AreEqual(spillLanguageModelNew.Language, spillLanguageModelRet.Language);
            Assert.AreEqual(spillLanguageModelNew.SpillComment, spillLanguageModelRet.SpillComment);
        }
        private void FillSpillLanguageModelNew(LanguageEnum Language, SpillModel spillModel, SpillLanguageModel spillLanguageModel)
        {
            spillLanguageModel.SpillID = spillModel.SpillID;
            spillLanguageModel.SpillComment = randomService.RandomString("SpillName", 30);
            spillLanguageModel.Language = Language;
            spillLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(spillLanguageModel.SpillID != 0);
            Assert.IsTrue(spillLanguageModel.SpillComment.Length == 30);
            Assert.IsTrue(spillLanguageModel.Language == Language);
            Assert.IsTrue(spillLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private void FillSpillLanguageModelUpdate(SpillLanguageModel spillLanguageModel)
        {
            spillLanguageModel.SpillComment = randomService.RandomString("SpillName", 30);
            spillLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(spillLanguageModel.SpillComment.Length == 30);
            Assert.IsTrue(spillLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private SpillLanguageModel UpdateSpillLanguageModel(SpillLanguageModel spillLanguageModelRet)
        {
            FillSpillLanguageModelUpdate(spillLanguageModelRet);

            SpillLanguageModel spillLanguageModelRet2 = spillLanguageService.PostUpdateSpillLanguageDB(spillLanguageModelRet);
            if (!string.IsNullOrWhiteSpace(spillLanguageModelRet2.Error))
            {
                return spillLanguageModelRet2;
            }

            Assert.IsNotNull(spillLanguageModelRet2);
            CompareSpillLanguageModels(spillLanguageModelRet, spillLanguageModelRet2);

            return spillLanguageModelRet2;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            spillService = new SpillService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            spillLanguageService = new SpillLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            spillLanguageModelNew = new SpillLanguageModel();
            spillLanguage = new SpillLanguage();
            spillServiceTest = new SpillServiceTest();
            spillServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimSpillLanguageService = new ShimSpillLanguageService(spillLanguageService);
        }
        #endregion Functions private
    }
}

