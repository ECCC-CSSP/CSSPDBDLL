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
    /// Summary description for BoxModelServiceTest
    /// </summary>
    [TestClass]
    public class BoxModelLanguageServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "BoxModelLanguage";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private BoxModelService boxModelService { get; set; }
        private BoxModelLanguageService boxModelLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private BoxModelLanguageModel boxModelLanguageModelNew { get; set; }
        private BoxModelLanguage boxModelLanguage { get; set; }
        private ShimBoxModelLanguageService shimBoxModelLanguageService { get; set; }
        private BoxModelServiceTest boxModelServiceTest { get; set; }
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
        public BoxModelLanguageServiceTest()
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
        public void BoxModelLanguageService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(boxModelLanguageService);
                Assert.IsNotNull(boxModelLanguageService.db);
                Assert.IsNotNull(boxModelLanguageService.LanguageRequest);
                Assert.IsNotNull(boxModelLanguageService.User);
                Assert.AreEqual(user.Identity.Name, boxModelLanguageService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), boxModelLanguageService.LanguageRequest);
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_BoxModelLanguageModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LanguageEnum LangToAdd = LanguageEnum.es;

                using (TransactionScope ts = new TransactionScope())
                {

                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    #region BoxModelID
                    FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);
                    boxModelLanguageModelNew.BoxModelID = 0;

                    string retStr = boxModelLanguageService.BoxModelLanguageModelOK(boxModelLanguageModelNew);

                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.BoxModelID), retStr);
                    #endregion BoxModelID

                    #region Language
                    int Min = 2;
                    int Max = 2;

                    FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);
                    boxModelLanguageModelNew.Language = LanguageEnum.en;

                    retStr = boxModelLanguageService.BoxModelLanguageModelOK(boxModelLanguageModelNew);

                    Assert.AreEqual("", retStr);

                    FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);
                    boxModelLanguageModelNew.Language = (LanguageEnum)10000;

                    retStr = boxModelLanguageService.BoxModelLanguageModelOK(boxModelLanguageModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);
                    #endregion Language

                    #region ScenarioName
                    FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);
                    Max = 250;
                    boxModelLanguageModelNew.ScenarioName = randomService.RandomString("", Min - 1);

                    retStr = boxModelLanguageService.BoxModelLanguageModelOK(boxModelLanguageModelNew);

                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.ScenarioName, Min), retStr);

                    FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);
                    boxModelLanguageModelNew.ScenarioName = randomService.RandomString("", Max + 1);

                    retStr = boxModelLanguageService.BoxModelLanguageModelOK(boxModelLanguageModelNew);

                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ScenarioName, Max), retStr);

                    FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);
                    boxModelLanguageModelNew.ScenarioName = randomService.RandomString("", Max - 1);

                    retStr = boxModelLanguageService.BoxModelLanguageModelOK(boxModelLanguageModelNew);

                    Assert.AreEqual("", retStr);

                    FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);
                    boxModelLanguageModelNew.ScenarioName = randomService.RandomString("", Max);

                    retStr = boxModelLanguageService.BoxModelLanguageModelOK(boxModelLanguageModelNew);

                    Assert.AreEqual("", retStr);
                    #endregion ScenarioName
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_FillBoxModelLanguage_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);

                    ContactOK contactOK = boxModelLanguageService.IsContactOK();

                    string retStr = boxModelLanguageService.FillBoxModelLanguageModel(boxModelLanguage, boxModelLanguageModelNew, contactOK);

                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, boxModelLanguage.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = boxModelLanguageService.FillBoxModelLanguageModel(boxModelLanguage, boxModelLanguageModelNew, contactOK);

                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, boxModelLanguage.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_GetBoxModelModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    BoxModelLanguageModel boxModelModelLanguageRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    int boxModelCount = boxModelLanguageService.GetBoxModelLanguageModelCountDB();

                    Assert.AreEqual(testDBService.Count + 3, boxModelCount);
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_GetBoxModelLanguageModelWithBoxModelIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    BoxModelLanguageModel boxModelLanguageModelRet2 = boxModelLanguageService.GetBoxModelLanguageModelWithBoxModelIDAndLanguageDB(boxModelLanguageModelRet.BoxModelID, LangToAdd);

                    Assert.AreEqual(boxModelLanguageModelRet.BoxModelID, boxModelLanguageModelRet2.BoxModelID);
                    Assert.AreEqual(boxModelLanguageModelRet.Language, boxModelLanguageModelRet2.Language);
                    Assert.AreEqual(LangToAdd, boxModelLanguageModelRet2.Language);

                    int BoxModelID = 0;
                    LanguageEnum LangToAdd2 = LangToAdd;
                    BoxModelLanguageModel boxModelLanguageModelRetError = boxModelLanguageService.GetBoxModelLanguageModelWithBoxModelIDAndLanguageDB(BoxModelID, LangToAdd2);

                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModelLanguage, ServiceRes.BoxModelID + "," + ServiceRes.Language, BoxModelID + "," + LangToAdd2), boxModelLanguageModelRetError.Error);

                    BoxModelID = boxModelLanguageModelRet.BoxModelID;
                    LangToAdd2 = (LanguageEnum)1000; // will cause error
                    boxModelLanguageModelRetError = boxModelLanguageService.GetBoxModelLanguageModelWithBoxModelIDAndLanguageDB(BoxModelID, LangToAdd2);

                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModelLanguage, ServiceRes.BoxModelID + "," + ServiceRes.Language, BoxModelID + "," + LangToAdd2), boxModelLanguageModelRetError.Error);

                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_GetBoxModelLanguageWithBoxModelIDAndLanguageDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    BoxModelLanguage boxModelLanguageRet2 = boxModelLanguageService.GetBoxModelLanguageWithBoxModelIDAndLanguageDB(boxModelLanguageModelRet.BoxModelID, LangToAdd);

                    Assert.AreEqual(boxModelLanguageModelRet.BoxModelID, boxModelLanguageRet2.BoxModelID);
                    Assert.AreEqual(boxModelLanguageModelRet.Language, (LanguageEnum)boxModelLanguageRet2.Language);
                    Assert.AreEqual(LangToAdd, (LanguageEnum)boxModelLanguageRet2.Language);
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostAddBoxModelLanguageDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    BoxModelLanguageModel boxModelLanguageModelRet2 = UpdateBoxModelLanguageModel(boxModelLanguageModelRet);

                    BoxModelLanguageModel boxModelLanguageModelRet3 = boxModelLanguageService.PostDeleteBoxModelLanguageDB(boxModelLanguageModelRet2.BoxModelID, LangToAdd);

                    Assert.AreEqual("", boxModelLanguageModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostAddBoxModelLanguageDB_BoxModelModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);

                        string ErrorText = "ErrorText";
                        ShimBoxModelLanguageService shimBoxModelLanguageService = new ShimBoxModelLanguageService(boxModelLanguageService);
                        shimBoxModelLanguageService.BoxModelLanguageModelOKBoxModelLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet = boxModelLanguageService.PostAddBoxModelLanguageDB(boxModelLanguageModelNew);
                        Assert.AreEqual(ErrorText, boxModelLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostAddBoxModelLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet = boxModelLanguageService.PostAddBoxModelLanguageDB(boxModelLanguageModelNew);
                        Assert.AreEqual(ErrorText, boxModelLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostAddBoxModelLanguageDB_GetBoxModelLanguageModelWithBoxModelIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.GetBoxModelLanguageModelWithBoxModelIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new BoxModelLanguageModel();
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet = boxModelLanguageService.PostAddBoxModelLanguageDB(boxModelLanguageModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.BoxModelLanguage), boxModelLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostAddBoxModelLanguageDB_FillBoxModelLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.FillBoxModelLanguageModelBoxModelLanguageBoxModelLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet = boxModelLanguageService.PostAddBoxModelLanguageDB(boxModelLanguageModelNew);
                        Assert.AreEqual(ErrorText, boxModelLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostAddBoxModelLanguageDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);

                        string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet = boxModelLanguageService.PostAddBoxModelLanguageDB(boxModelLanguageModelNew);
                        Assert.AreEqual(ErrorText, boxModelLanguageModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostAddBoxModelLanguageDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        LanguageEnum LangToAdd = LanguageEnum.es;
                        FillBoxModelLanguageModelNew(LangToAdd, boxModelModelRet, boxModelLanguageModelNew);

                        //string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.FillBoxModelLanguageModelBoxModelLanguageBoxModelLanguageModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet = boxModelLanguageService.PostAddBoxModelLanguageDB(boxModelLanguageModelNew);
                        Assert.IsTrue(boxModelLanguageModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostDeleteBoxModelLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    BoxModelLanguageModel boxModelLanguageModelRet2 = UpdateBoxModelLanguageModel(boxModelLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet3 = boxModelLanguageService.PostDeleteBoxModelLanguageDB(boxModelLanguageModelRet2.BoxModelID, LangToAdd);
                        Assert.AreEqual(ErrorText, boxModelLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostDeleteBoxModelLanguageDB_GetBoxModelLanguageWithBoxModelLanguageIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    BoxModelLanguageModel boxModelLanguageModelRet2 = UpdateBoxModelLanguageModel(boxModelLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.GetBoxModelLanguageWithBoxModelIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet3 = boxModelLanguageService.PostDeleteBoxModelLanguageDB(boxModelLanguageModelRet2.BoxModelID, LangToAdd);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, "BoxModelLanguage"), boxModelLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostDeleteBoxModelLanguageDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    BoxModelLanguageModel boxModelLanguageModelRet2 = UpdateBoxModelLanguageModel(boxModelLanguageModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet3 = boxModelLanguageService.PostDeleteBoxModelLanguageDB(boxModelLanguageModelRet2.BoxModelID, LangToAdd);
                        Assert.AreEqual(ErrorText, boxModelLanguageModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostUpdateBoxModelLanguageDB_BoxModelLanguageModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        FillBoxModelLanguageModelUpdate(boxModelLanguageModelRet);
                        string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.BoxModelLanguageModelOKBoxModelLanguageModel = (a) =>
                        {
                            return ErrorText;
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet2 = boxModelLanguageService.PostUpdateBoxModelLanguageDB(boxModelLanguageModelRet);
                        Assert.AreEqual(ErrorText, boxModelLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostUpdateBoxModelLanguageDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillBoxModelLanguageModelUpdate(boxModelLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet2 = boxModelLanguageService.PostUpdateBoxModelLanguageDB(boxModelLanguageModelRet);
                        Assert.AreEqual(ErrorText, boxModelLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostUpdateBoxModelLanguageDB_GetBoxModelLanguageWithBoxModelIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillBoxModelLanguageModelUpdate(boxModelLanguageModelRet);

                        //string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.GetBoxModelLanguageWithBoxModelIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return null;
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet2 = boxModelLanguageService.PostUpdateBoxModelLanguageDB(boxModelLanguageModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.BoxModelLanguage), boxModelLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostUpdateBoxModelLanguageDB_FillBoxModelLanguage_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillBoxModelLanguageModelUpdate(boxModelLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.FillBoxModelLanguageModelBoxModelLanguageBoxModelLanguageModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet2 = boxModelLanguageService.PostUpdateBoxModelLanguageDB(boxModelLanguageModelRet);
                        Assert.AreEqual(ErrorText, boxModelLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostUpdateBoxModelLanguageDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        FillBoxModelLanguageModelUpdate(boxModelLanguageModelRet);

                        string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        BoxModelLanguageModel boxModelLanguageModelRet2 = boxModelLanguageService.PostUpdateBoxModelLanguageDB(boxModelLanguageModelRet);
                        Assert.AreEqual(ErrorText, boxModelLanguageModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostAddBoxModelLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    ContactModel contactModelBad = contactModelListBad[0];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    boxModelLanguageService = new BoxModelLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, boxModelLanguageModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void BoxModelLanguageService_PostAddBoxModelLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();

                    LanguageEnum LangToAdd = LanguageEnum.es;

                    ContactModel contactModelBad = contactModelListGood[2];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    boxModelLanguageService = new BoxModelLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    BoxModelLanguageModel boxModelLanguageModelRet = AddBoxModelLanguageModel(LangToAdd, boxModelModelRet);

                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, boxModelLanguageModelRet.Error);

                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private BoxModelLanguageModel AddBoxModelLanguageModel(LanguageEnum LangToAdd, BoxModelModel boxModelModel)
        {
            BoxModelLanguageModel boxModelLanguageModelNew = new BoxModelLanguageModel();
            FillBoxModelLanguageModelNew(LangToAdd, boxModelModel, boxModelLanguageModelNew);

            BoxModelLanguageModel boxModelLanguagModelRet = boxModelLanguageService.PostAddBoxModelLanguageDB(boxModelLanguageModelNew);
            if (!string.IsNullOrWhiteSpace(boxModelLanguagModelRet.Error))
            {
                return boxModelLanguagModelRet;
            }

            Assert.IsNotNull(boxModelLanguagModelRet);
            CompareBoxModelLanguageModels(boxModelLanguageModelNew, boxModelLanguagModelRet);

            return boxModelLanguagModelRet;
        }
        private void CompareBoxModelLanguageModels(BoxModelLanguageModel boxModelLanguageModelNew, BoxModelLanguageModel boxModelLanguageModelRet)
        {
            Assert.AreEqual(boxModelLanguageModelNew.Language, boxModelLanguageModelRet.Language);
            Assert.AreEqual(boxModelLanguageModelNew.ScenarioName, boxModelLanguageModelRet.ScenarioName);
        }
        private void FillBoxModelLanguageModelNew(LanguageEnum Language, BoxModelModel boxModelModel, BoxModelLanguageModel boxModelLanguageModel)
        {
            boxModelLanguageModel.BoxModelID = boxModelModel.BoxModelID;
            boxModelLanguageModel.Language = Language;
            boxModelLanguageModel.ScenarioName = randomService.RandomString("TV Text", 20);
            boxModelLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(boxModelLanguageModel.BoxModelID != 0);
            Assert.IsTrue(boxModelLanguageModel.Language == Language);
            Assert.IsTrue(boxModelLanguageModel.ScenarioName.Length == 20);
            Assert.IsTrue(boxModelLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private void FillBoxModelLanguageModelUpdate(BoxModelLanguageModel boxModelLanguageModel)
        {
            boxModelLanguageModel.ScenarioName = randomService.RandomString("TV Text2", 20);
            boxModelLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

            Assert.IsTrue(boxModelLanguageModel.ScenarioName.Length == 20);
            Assert.IsTrue(boxModelLanguageModel.TranslationStatus == TranslationStatusEnum.Translated);
        }
        private BoxModelLanguageModel UpdateBoxModelLanguageModel(BoxModelLanguageModel boxModelLanguageModelRet)
        {
            FillBoxModelLanguageModelUpdate(boxModelLanguageModelRet);

            BoxModelLanguageModel boxModelLanguageModelRet2 = boxModelLanguageService.PostUpdateBoxModelLanguageDB(boxModelLanguageModelRet);
            if (!string.IsNullOrWhiteSpace(boxModelLanguageModelRet2.Error))
            {
                return boxModelLanguageModelRet2;
            }

            Assert.IsNotNull(boxModelLanguageModelRet2);
            CompareBoxModelLanguageModels(boxModelLanguageModelRet, boxModelLanguageModelRet2);

            return boxModelLanguageModelRet2;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            boxModelService = new BoxModelService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            boxModelLanguageService = new BoxModelLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            boxModelLanguageModelNew = new BoxModelLanguageModel();
            boxModelLanguage = new BoxModelLanguage();
            boxModelServiceTest = new BoxModelServiceTest();
            boxModelServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimBoxModelLanguageService = new ShimBoxModelLanguageService(boxModelLanguageService);
        }
        #endregion Functions private
    }
}

