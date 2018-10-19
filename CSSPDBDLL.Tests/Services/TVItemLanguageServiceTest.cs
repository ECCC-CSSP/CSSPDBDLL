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
    /// Summary description for TVItemServiceTest
    /// </summary>
    [TestClass]
    public class TVItemLanguageServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "TVItemLanguage";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private TVItemService tvItemService { get; set; }
        private TVItemLanguageService tvItemLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private TVItemLanguageModel tvItemLanguageModelNew { get; set; }
        private TVItemLanguage tvItemLanguage { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
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
        public TVItemLanguageServiceTest()
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
        public void TVItemLanguageService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(tvItemLanguageService);
                Assert.IsNotNull(tvItemLanguageService.db);
                Assert.IsNotNull(tvItemLanguageService.LanguageRequest);
                Assert.IsNotNull(tvItemLanguageService.User);
                Assert.AreEqual(user.Identity.Name, tvItemLanguageService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), tvItemLanguageService.LanguageRequest);
            }
        }
        [TestMethod]
        public void TVItemLanguageService_TVItemLanguageModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum LangToAdd = LanguageEnum.es;

                using (TransactionScope ts = new TransactionScope())
                {
                    #region TVItemID
                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);
                    tvItemLanguageModelNew.TVItemID = 0;

                    string retStr = tvItemLanguageService.TVItemLanguageModelOK(tvItemLanguageModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID), retStr);
                    #endregion TVItemID

                    #region Language
                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);
                    int Max = 2;
                    tvItemLanguageModelNew.Language = (LanguageEnum)1000;

                    retStr = tvItemLanguageService.TVItemLanguageModelOK(tvItemLanguageModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);

                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);
                    tvItemLanguageModelNew.Language = LanguageEnum.en;

                    retStr = tvItemLanguageService.TVItemLanguageModelOK(tvItemLanguageModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Language

                    #region TVText
                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);
                    Max = 250;
                    tvItemLanguageModelNew.TVText = randomService.RandomString("", 0);

                    retStr = tvItemLanguageService.TVItemLanguageModelOK(tvItemLanguageModelNew);
                    Assert.IsNotNull("", retStr);

                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);
                    tvItemLanguageModelNew.TVText = randomService.RandomString("", Max + 1);

                    retStr = tvItemLanguageService.TVItemLanguageModelOK(tvItemLanguageModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Language, Max), retStr);

                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);
                    tvItemLanguageModelNew.TVText = randomService.RandomString("", Max - 1);

                    retStr = tvItemLanguageService.TVItemLanguageModelOK(tvItemLanguageModelNew);
                    Assert.IsNotNull("", retStr);

                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);
                    tvItemLanguageModelNew.TVText = randomService.RandomString("", Max);

                    retStr = tvItemLanguageService.TVItemLanguageModelOK(tvItemLanguageModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion TVText
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_FillTVItemLanguage_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                    ContactOK contactOK = tvItemLanguageService.IsContactOK();

                    string retStr = tvItemLanguageService.FillTVItemLanguage(tvItemLanguage, tvItemLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, tvItemLanguage.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = tvItemLanguageService.FillTVItemLanguage(tvItemLanguage, tvItemLanguageModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, tvItemLanguage.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_GetTVItemLanguageModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemModelLanguageRet = AddTVItemLanguageModel(LangToAdd);

                    int tvItemCount = tvItemLanguageService.GetTVItemLanguageModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, tvItemCount);
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);

                    TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemLanguageModelRet.TVItemID, LangToAdd);
                    Assert.AreEqual(tvItemLanguageModelRet.TVItemID, tvItemLanguageModelRet2.TVItemID);
                    Assert.AreEqual(tvItemLanguageModelRet.Language, tvItemLanguageModelRet2.Language);
                    Assert.AreEqual(LangToAdd, tvItemLanguageModelRet2.Language);
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_GetTVItemLanguageWithTVItemIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);

                    TVItemLanguage tvItemLanguageRet2 = tvItemLanguageService.GetTVItemLanguageWithTVItemIDAndLanguageDB(tvItemLanguageModelRet.TVItemID, LangToAdd);
                    Assert.AreEqual(tvItemLanguageModelRet.TVItemID, tvItemLanguageRet2.TVItemID);
                    Assert.AreEqual(tvItemLanguageModelRet.Language, (LanguageEnum)tvItemLanguageRet2.Language);
                    Assert.AreEqual(LangToAdd, (LanguageEnum)tvItemLanguageRet2.Language);
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_ReturnError_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                using (TransactionScope ts = new TransactionScope())
                {

                    string ErrorText = "ErrorText";
                    TVItemLanguageModel tvItemLanguageModel = tvItemLanguageService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, tvItemLanguageModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddRootTVItemLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                    int count = tvItemService.GetTVItemModelCountDB();
                    if (count == 1)
                    {
                        TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                        TVItemLanguageModel tvItemLanguageModel = tvItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemModelRoot.TVItemID, languageEnum);

                        TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostDeleteTVItemLanguageDB(tvItemModelRoot.TVItemID, languageEnum);
                        Assert.AreEqual("", tvItemLanguageModelRet2.Error);

                        LanguageEnum LangToAdd = languageEnum;

                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        tvItemLanguageModelNew.TVItemID = tvItemModelRoot.TVItemID;

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddRootTVItemLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual("", tvItemLanguageModelRet.Error);
                    }
                    else
                    {
                        TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                        TVItemLanguageModel tvItemLanguageModel = tvItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemModelRoot.TVItemID, languageEnum);

                        TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostDeleteTVItemLanguageDB(tvItemModelRoot.TVItemID, languageEnum);
                        Assert.AreEqual("", tvItemLanguageModelRet2.Error);

                        LanguageEnum LangToAdd = languageEnum;

                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        using (ShimsContext.Create())
                        {
                            //string ErrorText = "ErrorText";
                            SetupShim();
                            shimTVItemLanguageService.GetTVItemLanguageModelCountDB = () =>
                            {
                                return 0;
                            };

                            TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddRootTVItemLanguageDB(tvItemLanguageModelNew);

                            Assert.AreEqual("", tvItemLanguageModelRet.Error);
                        }
                    }
                }
                break;
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddRootTVItemLanguageDB_GetTVItemLanguageModelCountDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    TVItemLanguageModel tvItemLanguageModel = tvItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemModelRoot.TVItemID, languageEnum);

                    TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostDeleteTVItemLanguageDB(tvItemModelRoot.TVItemID, languageEnum);
                    Assert.AreEqual("", tvItemLanguageModelRet2.Error);

                    LanguageEnum LangToAdd = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelCountDB = () =>
                        {
                            return 2;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddRootTVItemLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(ServiceRes.TVItemRootShouldBeTheFirstOneAdded, tvItemLanguageModelRet.Error);
                    }
                }
                break;
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddRootTVItemLanguageDB_TVItemLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    TVItemLanguageModel tvItemLanguageModel = tvItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemModelRoot.TVItemID, languageEnum);

                    TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostDeleteTVItemLanguageDB(tvItemModelRoot.TVItemID, languageEnum);
                    Assert.AreEqual("", tvItemLanguageModelRet2.Error);

                    LanguageEnum LangToAdd = languageEnum;

                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimTVItemLanguageService.TVItemLanguageModelOKTVItemLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddRootTVItemLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet.Error);
                    }
                }
                break;
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddRootTVItemLanguageDB_FillTVItemLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    TVItemLanguageModel tvItemLanguageModel = tvItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemModelRoot.TVItemID, languageEnum);

                    TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostDeleteTVItemLanguageDB(tvItemModelRoot.TVItemID, languageEnum);
                    Assert.AreEqual("", tvItemLanguageModelRet2.Error);

                    LanguageEnum LangToAdd = languageEnum;

                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimTVItemLanguageService.FillTVItemLanguageTVItemLanguageTVItemLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddRootTVItemLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet.Error);
                    }
                }
                break;
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddRootTVItemLanguageDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    TVItemLanguageModel tvItemLanguageModel = tvItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemModelRoot.TVItemID, languageEnum);

                    TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostDeleteTVItemLanguageDB(tvItemModelRoot.TVItemID, languageEnum);
                    Assert.AreEqual("", tvItemLanguageModelRet2.Error);

                    LanguageEnum LangToAdd = languageEnum;

                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimTVItemLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddRootTVItemLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet.Error);
                    }
                }
                break;
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddRootTVItemLanguageDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    TVItemLanguageModel tvItemLanguageModel = tvItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemModelRoot.TVItemID, languageEnum);

                    TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostDeleteTVItemLanguageDB(tvItemModelRoot.TVItemID, languageEnum);
                    Assert.AreEqual("", tvItemLanguageModelRet2.Error);

                    LanguageEnum LangToAdd = languageEnum;

                    FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimTVItemLanguageService.FillTVItemLanguageTVItemLanguageTVItemLanguageModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddRootTVItemLanguageDB(tvItemLanguageModelNew);
                        Assert.IsTrue(tvItemLanguageModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
                break;
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);

                    TVItemLanguageModel tvItemLanguageModelRet2 = UpdateTVItemLanguageModel(tvItemLanguageModelRet);

                    TVItemLanguageModel tvItemLanguageModelRet3 = tvItemLanguageService.PostDeleteTVItemLanguageDB(tvItemLanguageModelRet2.TVItemID, LangToAdd);
                    Assert.AreEqual("", tvItemLanguageModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemLanguageDB_TVItemLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        string ErrorText = "ErrorText";
                        ShimTVItemLanguageService shimTVItemLanguageService = new ShimTVItemLanguageService(tvItemLanguageService);
                        shimTVItemLanguageService.TVItemLanguageModelOKTVItemLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddTVItemLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemLanguageDB_IsContactOK_Error_Test()
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
                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddTVItemLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemLanguageDB_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
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
                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel();
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddTVItemLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItemLanguage), tvItemLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemLanguageDB_FillTVItemLanguage_Error_Test()
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
                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.FillTVItemLanguageTVItemLanguageTVItemLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddTVItemLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemLanguageDB_DoAddChanges_Error_Test()
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
                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddTVItemLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemLanguageDB_Add_Error_Test()
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
                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimTVItemLanguageService.FillTVItemLanguageTVItemLanguageTVItemLanguageModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddTVItemLanguageDB(tvItemLanguageModelNew);
                        Assert.IsTrue(tvItemLanguageModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemContactLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);

                    TVItemLanguageModel tvItemLanguageModelRet2 = UpdateTVItemLanguageModel(tvItemLanguageModelRet);

                    TVItemLanguageModel tvItemLanguageModelRet3 = tvItemLanguageService.PostDeleteTVItemLanguageDB(tvItemLanguageModelRet2.TVItemID, LangToAdd);
                    Assert.AreEqual("", tvItemLanguageModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemContactLanguageDB_TVItemLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        string ErrorText = "ErrorText";
                        ShimTVItemLanguageService shimTVItemLanguageService = new ShimTVItemLanguageService(tvItemLanguageService);
                        shimTVItemLanguageService.TVItemLanguageModelOKTVItemLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddTVItemContactLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemContactLanguageDB_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
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
                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel();
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddTVItemContactLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItemLanguage), tvItemLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemContactLanguageDB_FillTVItemLanguage_Error_Test()
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
                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.FillTVItemLanguageTVItemLanguageTVItemLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddTVItemContactLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemContactLanguageDB_DoAddChanges_Error_Test()
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
                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddTVItemContactLanguageDB(tvItemLanguageModelNew);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemContactLanguageDB_Add_Error_Test()
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
                        FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimTVItemLanguageService.FillTVItemLanguageTVItemLanguageTVItemLanguageModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostAddTVItemContactLanguageDB(tvItemLanguageModelNew);
                        Assert.IsTrue(tvItemLanguageModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostDeleteTVItemLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);

                    TVItemLanguageModel tvItemLanguageModelRet2 = UpdateTVItemLanguageModel(tvItemLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemLanguageModel tvItemLanguageModelRet3 = tvItemLanguageService.PostDeleteTVItemLanguageDB(tvItemLanguageModelRet2.TVItemID, LangToAdd);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostDeleteTVItemLanguageDB_GetTVItemLanguageWithTVItemLanguageIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);

                    TVItemLanguageModel tvItemLanguageModelRet2 = UpdateTVItemLanguageModel(tvItemLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemLanguageService.GetTVItemLanguageWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet3 = tvItemLanguageService.PostDeleteTVItemLanguageDB(tvItemLanguageModelRet2.TVItemLanguageID, LangToAdd);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVItemLanguage), tvItemLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostDeleteTVItemLanguageDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostDeleteTVItemLanguageDB(tvItemLanguageModelRet.TVItemID, LangToAdd);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostUpdateTVItemLanguageDB_TVItemLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        FillTVItemLanguageModelUpdate(tvItemLanguageModelRet);
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.TVItemLanguageModelOKTVItemLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelRet);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostUpdateTVItemLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillTVItemLanguageModelUpdate(tvItemLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelRet);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostUpdateTVItemLanguageDB_GetTVItemLanguageWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillTVItemLanguageModelUpdate(tvItemLanguageModelRet);

                        //string ErrorText = "ErrorText";
                        shimTVItemLanguageService.GetTVItemLanguageWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVItemLanguage), tvItemLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostUpdateTVItemLanguageDB_FillTVItemLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillTVItemLanguageModelUpdate(tvItemLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.FillTVItemLanguageTVItemLanguageTVItemLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelRet);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostUpdateTVItemLanguageDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillTVItemLanguageModelUpdate(tvItemLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelRet);
                        Assert.AreEqual(ErrorText, tvItemLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, tvItemLanguageModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void TVItemLanguageService_PostAddTVItemLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LanguageEnum LangToAdd = LanguageEnum.es;

                    TVItemLanguageModel tvItemLanguageModelRet = AddTVItemLanguageModel(LangToAdd);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, tvItemLanguageModelRet.Error);

                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private TVItemLanguageModel AddTVItemLanguageModel(LanguageEnum LangToAdd)
        {
            TVItemLanguageModel tvItemLanguageModelNew = new TVItemLanguageModel();
            FillTVItemLanguageModelNew(LangToAdd, tvItemLanguageModelNew);

            TVItemLanguageModel tvItemLanguagModelRet = tvItemLanguageService.PostAddTVItemLanguageDB(tvItemLanguageModelNew);
            if (!string.IsNullOrWhiteSpace(tvItemLanguagModelRet.Error))
            {
                return tvItemLanguagModelRet;
            }

            Assert.IsNotNull(tvItemLanguagModelRet);
            CompareTVItemLanguageModels(tvItemLanguageModelNew, tvItemLanguagModelRet);

            return tvItemLanguagModelRet;
        }
        private void CompareTVItemLanguageModels(TVItemLanguageModel tvItemLanguageModelNew, TVItemLanguageModel tvItemLanguageModelRet)
        {
            Assert.AreEqual(tvItemLanguageModelNew.Language, tvItemLanguageModelRet.Language);
            Assert.AreEqual(tvItemLanguageModelNew.TVText, tvItemLanguageModelRet.TVText);
        }
        private void FillTVItemLanguageModelNew(LanguageEnum Language, TVItemLanguageModel tvItemLanguageModel)
        {
            tvItemLanguageModel.TVItemID = randomService.RandomTVItem(TVTypeEnum.Municipality).TVItemID;
            tvItemLanguageModel.Language = Language;
            tvItemLanguageModel.TVText = randomService.RandomString("TV Text", 20);
            tvItemLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(tvItemLanguageModel.TVItemID != 0);
            Assert.IsTrue(tvItemLanguageModel.Language == Language);
            Assert.IsTrue(tvItemLanguageModel.TVText.Length == 20);
            Assert.IsTrue(tvItemLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private void FillTVItemLanguageModelUpdate(TVItemLanguageModel tvItemLanguageModel)
        {
            tvItemLanguageModel.TVText = randomService.RandomString("TV Text2", 20);
            tvItemLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(tvItemLanguageModel.TVText.Length == 20);
            Assert.IsTrue(tvItemLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private TVItemLanguageModel UpdateTVItemLanguageModel(TVItemLanguageModel tvItemLanguageModelRet)
        {
            FillTVItemLanguageModelUpdate(tvItemLanguageModelRet);

            TVItemLanguageModel tvItemLanguageModelRet2 = tvItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelRet);
            if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet2.Error))
            {
                return tvItemLanguageModelRet2;
            }

            Assert.IsNotNull(tvItemLanguageModelRet2);
            CompareTVItemLanguageModels(tvItemLanguageModelRet, tvItemLanguageModelRet2);

            return tvItemLanguageModelRet2;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemLanguageService = new TVItemLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemLanguageModelNew = new TVItemLanguageModel();
            tvItemLanguage = new TVItemLanguage();
        }
        private void SetupShim()
        {
            shimTVItemLanguageService = new ShimTVItemLanguageService(tvItemLanguageService);
        }
        #endregion Functions private
    }
}

