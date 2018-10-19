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
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for TelServiceTest
    /// </summary>
    [TestClass]
    public class TelServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "Tel";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private TelService telService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private TelModel telModelNew { get; set; }
        private Tel tel { get; set; }
        private ShimTelService shimTelService { get; set; }
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
        public TelServiceTest()
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
        public void TelService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(telService);
                Assert.IsNotNull(telService._TVItemService);
                Assert.IsNotNull(telService._TVItemService._TVItemLanguageService);
                Assert.IsNotNull(telService.db);
                Assert.IsNotNull(telService.LanguageRequest);
                Assert.IsNotNull(telService.User);
                Assert.AreEqual(user.Identity.Name, telService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), telService.LanguageRequest);
            }
        }
        [TestMethod]
        public void TelService_TelModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModel = AddTelModel();
                    Assert.AreEqual("", telModel.Error);

                    #region TelText
                    int Max = 255;
                    telModelNew.TelTVItemID = telModel.TelTVItemID;
                    FillTelModelNew(telModelNew);
                    telModelNew.TelNumber = "";

                    string retStr = telService.TelModelOK(telModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.Tel), retStr);

                    FillTelModelNew(telModelNew);
                    telModelNew.TelNumber = randomService.RandomString("", Max + 1) + randomService.RandomTel();

                    retStr = telService.TelModelOK(telModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Tel, Max), retStr);

                    FillTelModelNew(telModelNew);
                    telModelNew.TelNumber = "Charles.LeBalnc.seifjl.gc.gc.ca";

                    retStr = telService.TelModelOK(telModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._EmailNotWellFormed, telModelNew.TelNumber), retStr);

                    #endregion TelText

                    #region TelType
                    FillTelModelNew(telModelNew);
                    telModelNew.TelType = (TelTypeEnum)10000;

                    retStr = telService.TelModelOK(telModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TelType), retStr);

                    FillTelModelNew(telModelNew);
                    telModelNew.TelType = TelTypeEnum.Work;

                    retStr = telService.TelModelOK(telModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion TelType

                    #region TelTVItemID
                    telModelNew.TelTVItemID = telModel.TelTVItemID;
                    FillTelModelNew(telModelNew);
                    telModelNew.TelTVItemID = 0;

                    retStr = telService.TelModelOK(telModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TelTVItemID), retStr);

                    telModelNew.TelTVItemID = telModel.TelTVItemID;
                    FillTelModelNew(telModelNew);

                    retStr = telService.TelModelOK(telModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion TelTVItemID
                }
            }
        }
        [TestMethod]
        public void TelService_FillTel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();
                    Assert.AreEqual("", telModelRet.Error);

                    telModelNew.TelTVItemID = telModelRet.TelTVItemID;
                    FillTelModelNew(telModelNew);

                    ContactOK contactOK = telService.IsContactOK();

                    string retStr = telService.FillTel(tel, telModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, tel.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = telService.FillTel(tel, telModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, tel.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void TelService_GetTelModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();
                    Assert.AreEqual("", telModelRet.Error);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Tel", "s");

                    int telCount = telService.GetTelModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, telCount);

                }
            }
        }
        [TestMethod]
        public void TelService_GetTelModelWithTelIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    TelModel telModelRet2 = telService.GetTelModelWithTelIDDB(telModelRet.TelID);
                    Assert.IsNotNull(telModelRet2);
                    CompareTelModels(telModelRet, telModelRet2);

                    int TelID = 0;
                    TelModel telModelRet3 = telService.GetTelModelWithTelIDDB(TelID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Tel, ServiceRes.TelID, TelID), telModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_GetTelModelWithTelTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    TelModel telModelRet2 = telService.GetTelModelWithTelTVItemIDDB(telModelRet.TelTVItemID);
                    Assert.IsNotNull(telModelRet2);
                    CompareTelModels(telModelRet, telModelRet2);

                    int TelTVItemID = 0;
                    TelModel telModelRet3 = telService.GetTelModelWithTelTVItemIDDB(TelTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Tel, ServiceRes.TelTVItemID, TelTVItemID), telModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_GetTelWithTelIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    Tel telRet2 = telService.GetTelWithTelIDDB(telModelRet.TelID);
                    Assert.IsNotNull(telRet2);
                    Assert.AreEqual(telModelRet.TelID, telRet2.TelID);

                    Tel telRet3 = telService.GetTelWithTelIDDB(0);
                    Assert.IsNull(telRet3);
                }
            }
        }
        [TestMethod]
        public void TelService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    string retStr = telService.CreateTVText(telModelRet);
                    Assert.AreEqual(telModelRet.TelNumber, retStr);

                    telModelRet.TelNumber = "";
                    retStr = telService.CreateTVText(telModelRet);
                    Assert.AreEqual(telModelRet.TelNumber, retStr);
                }
            }
        }
        [TestMethod]
        public void TelService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    TelModel telModelRet = telService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, telModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Good_Add_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487874";
                    //fc["TelType"] = "0";
                    Assert.IsNotNull(fc);

                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", telModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Good_Add_AlreadyExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    //fc["TelNumber"] = "";
                    //fc["TelType"] = "0";
                    Assert.IsNotNull(fc);

                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", telModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Good_Modify_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23847784";
                    //fc["TelType"] = "0";
                    Assert.IsNotNull(fc);

                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", telModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_ContactTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    fc["ContactTVItemID"] = "0";
                    //fc["TelTVItemID"] = "0";
                    //fc["TelNumber"] = "";
                    //fc["TelType"] = "0";


                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID), telModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_TelNumber_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "";
                    //fc["TelType"] = "0";


                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TelNumber), telModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_TelType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["TelTVItemID"] = "0";
                    //fc["TelNumber"] = "";
                    fc["TelType"] = "0";


                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TelType), telModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Add_GetRootTVItemModelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    //fc["TelNumber"] = "";
                    //fc["TelType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetRootTVItemModelDB = () =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Add_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    //fc["TelNumber"] = "";
                    //fc["TelType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Add_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    //fc["TelNumber"] = "";
                    //fc["TelType"] = "0";

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTelService.CreateTVTextTelModel = (a) =>
                        {
                            return "";
                        };

                        TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Add_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    //fc["TelNumber"] = "";
                    //fc["TelType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Add_PostAddTelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    //fc["TelNumber"] = "";
                    //fc["TelType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };
                        shimTelService.PostAddTelDBTelModel = (a) =>
                        {
                            return new TelModel() { Error = ErrorText };
                        };

                        TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Add_GetTelModelWithTelTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    //fc["TelNumber"] = "";
                    //fc["TelType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTelService.GetTelModelWithTelTVItemIDDBInt32 = (a) =>
                        {
                            return new TelModel() { Error = ErrorText };
                        };

                        TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Add_GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    //fc["TelNumber"] = "";
                    //fc["TelType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDBInt32Int32 = (a, b) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                        Assert.AreEqual("", telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Add_PostAddTVItemLinkDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    //fc["TelNumber"] = "";
                    //fc["TelType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.PostAddTVItemLinkDBTVItemLinkModel = (a) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Modify_GetTelModelWithTelTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487473";
                    //fc["TelType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTelService.GetTelModelWithTelTVItemIDDBInt32 = (a) =>
                        {
                            return new TelModel() { Error = ErrorText };
                        };

                        TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Modify_PostUpdateTelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487473";
                    //fc["TelType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTelService.PostUpdateTelDBTelModel = (a) =>
                        {
                            return new TelModel() { Error = ErrorText };
                        };

                        TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Modify_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487473";
                    //fc["TelType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddOrModifyDB_Modify_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487473";
                    //fc["TelType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddUpdateDeleteTel_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    TelModel telModelRet2 = UpdateTelModel(telModelRet);

                    TelModel telModelRet3 = telService.PostDeleteTelDB(telModelRet2.TelID);
                    Assert.AreEqual("", telModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void TelService_PostAddTelDB_TelModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTelService.TelModelOKTelModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TelModel telModelRet = AddTelModel();
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddTelDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTelService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TelModel telModelRet = AddTelModel();
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddTelDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        telModelNew.TelTVItemID = 1;

                        FillTelModelNew(telModelNew);

                        TelModel telModelRet = telService.PostAddTelDB(telModelNew);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddTelDB_FillTel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTelService.FillTelTelTelModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TelModel telModelRet = AddTelModel();
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddTelDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTelService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        TelModel telModelRet = AddTelModel();
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddTelDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTelService.FillTelTelTelModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        TelModel telModelRet = AddTelModel();
                        Assert.IsTrue(telModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddTelDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    telModelNew.TelTVItemID = 1;
                    FillTelModelNew(telModelNew);

                    TelModel telModelRet = telService.PostAddTelDB(telModelNew);
                    Assert.IsNotNull(telModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, telModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_PostAddTelDB_UserTelNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    telModelNew.TelTVItemID = 1;

                    FillTelModelNew(telModelNew);

                    TelModel telModelRet = telService.PostAddTelDB(telModelNew);
                    Assert.IsNotNull(telModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, telModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_PostDeleteTelDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTelService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TelModel telModelRet2 = telService.PostDeleteTelDB(telModelRet.TelID);
                        Assert.AreEqual(ErrorText, telModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostDeleteTelDB_GetTelWithTelIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTelService.GetTelWithTelIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TelModel telModelRet2 = telService.PostDeleteTelDB(telModelRet.TelID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Tel), telModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostDeleteTelDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTelService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TelModel telModelRet2 = telService.PostDeleteTelDB(telModelRet.TelID);
                        Assert.AreEqual(ErrorText, telModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostDeleteTelDB_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TelModel telModelRet2 = telService.PostDeleteTelDB(telModelRet.TelID);
                        Assert.AreEqual(ErrorText, telModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostDeleteTelUnderContactTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487874";
                    Assert.IsNotNull(fc);

                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", telModelRet.Error);

                    fc["TelTVItemID"] = telModelRet.TelTVItemID.ToString();

                    telModelRet = telService.PostDeleteTelUnderContactTVItemIDDB(fc);
                    Assert.AreEqual("", telModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_PostDeleteTelUnderContactTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487874";

                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);

                    fc["TelTVItemID"] = telModelRet.TelTVItemID.ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTelService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        telModelRet = telService.PostDeleteTelUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostDeleteTelUnderContactTVItemIDDB_ContactTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487874";

                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);

                    fc["TelTVItemID"] = telModelRet.TelTVItemID.ToString();

                    fc["ContactTVItemID"] = "0";

                    telModelRet = telService.PostDeleteTelUnderContactTVItemIDDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID), telModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_PostDeleteTelUnderContactTVItemIDDB_TelTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487874";

                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);

                    //fc["TelTVItemID"] = telModelRet.TelTVItemID.ToString();

                    fc["TelTVItemID"] = "0";

                    telModelRet = telService.PostDeleteTelUnderContactTVItemIDDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TelTVItemID), telModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TelService_PostDeleteTelUnderContactTVItemIDDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487874";

                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);

                    fc["TelTVItemID"] = telModelRet.TelTVItemID.ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        telModelRet = telService.PostDeleteTelUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostDeleteTelUnderContactTVItemIDDB_GetTVItemModelWithTVItemIDDB2_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487874";

                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);

                    fc["TelTVItemID"] = telModelRet.TelTVItemID.ToString();

                    int count = 0;
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            count += 1;
                            if (count == 1)
                            {
                                return new TVItemModel();
                            }
                            return new TVItemModel() { Error = ErrorText };
                        };

                        telModelRet = telService.PostDeleteTelUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostDeleteTelUnderContactTVItemIDDB_GetTelModelWithTelTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487874";

                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);

                    fc["TelTVItemID"] = telModelRet.TelTVItemID.ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTelService.GetTelModelWithTelTVItemIDDBInt32 = (a) =>
                        {
                            return new TelModel() { Error = ErrorText };
                        };

                        telModelRet = telService.PostDeleteTelUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostDeleteTelUnderContactTVItemIDDB_PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["TelTVItemID"] = "0";
                    fc["TelNumber"] = "23487874";

                    TelModel telModelRet = telService.PostAddOrModifyDB(fc);

                    fc["TelTVItemID"] = telModelRet.TelTVItemID.ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDBInt32Int32 = (a, b) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        telModelRet = telService.PostDeleteTelUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, telModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostUpdateTelDB_TelModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    FillTelModelUpdate(telModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTelService.TelModelOKTelModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TelModel telModelRet2 = telService.PostUpdateTelDB(telModelRet);
                        Assert.AreEqual(ErrorText, telModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostUpdateTelDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    FillTelModelUpdate(telModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTelService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TelModel telModelRet2 = telService.PostUpdateTelDB(telModelRet);
                        Assert.AreEqual(ErrorText, telModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostUpdateTelDB_GetTelWithTelIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    FillTelModelUpdate(telModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTelService.GetTelWithTelIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TelModel telModelRet2 = telService.PostUpdateTelDB(telModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Tel), telModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostUpdateTelDB_FillTel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    FillTelModelUpdate(telModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTelService.FillTelTelTelModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TelModel telModelRet2 = telService.PostUpdateTelDB(telModelRet);
                        Assert.AreEqual(ErrorText, telModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostUpdateTelDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    FillTelModelUpdate(telModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTelService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TelModel telModelRet2 = telService.PostUpdateTelDB(telModelRet);
                        Assert.AreEqual(ErrorText, telModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostUpdateTelDB_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    FillTelModelUpdate(telModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        TelModel telModelRet2 = telService.PostUpdateTelDB(telModelRet);
                        Assert.AreEqual(ErrorText, telModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostUpdateTelDB_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    FillTelModelUpdate(telModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTelService.CreateTVTextTelModel = (a) =>
                        {
                            return "";
                        };

                        TelModel telModelRet2 = telService.PostUpdateTelDB(telModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), telModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TelService_PostUpdateTelDB_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel telModelRet = AddTelModel();

                    FillTelModelUpdate(telModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        TelModel telModelRet2 = telService.PostUpdateTelDB(telModelRet);
                        Assert.AreEqual(ErrorText, telModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private TelModel AddTelModel()
        {
            TVItemModel tvItemRoot = telService._TVItemService.GetRootTVItemModelDB();

            Assert.AreEqual("", tvItemRoot.Error);

            string TVText = randomService.RandomString("Tel ", 20);
            TVItemModel tvItemModelTel = telService._TVItemService.PostAddChildTVItemDB(tvItemRoot.TVItemID, TVText, TVTypeEnum.Tel);
            if (!string.IsNullOrWhiteSpace(tvItemModelTel.Error))
            {
                return new TelModel() { Error = tvItemModelTel.Error };
            }

            telModelNew.TelTVItemID = tvItemModelTel.TVItemID;

            FillTelModelNew(telModelNew);

            TelModel telModelRet = telService.PostAddTelDB(telModelNew);
            if (!string.IsNullOrWhiteSpace(telModelRet.Error))
            {
                return telModelRet;
            }

            CompareTelModels(telModelNew, telModelRet);

            return telModelRet;
        }
        private TelModel UpdateTelModel(TelModel telModel)
        {
            FillTelModelUpdate(telModel);

            TelModel telModelRet = telService.PostUpdateTelDB(telModel);
            if (!string.IsNullOrWhiteSpace(telModelRet.Error))
            {
                return telModelRet;
            }

            CompareTelModels(telModel, telModelRet);

            return telModelRet;
        }
        private void CompareTelModels(TelModel telModelNew, TelModel telModelRet)
        {
            Assert.AreEqual(telModelNew.TelTVItemID, telModelRet.TelTVItemID);
            Assert.AreEqual(telModelNew.TelNumber, telModelRet.TelNumber);
            Assert.AreEqual(telModelNew.TelType, telModelRet.TelType);
        }
        public FormCollection FillPostAddOrModifyDBFormCollection()
        {
            string TelNumber = "15063459587";
            TVItemModel tvItemModelTel = tvItemService.PostAddChildTVItemDB(1, TelNumber, TVTypeEnum.Tel);
            if (!string.IsNullOrWhiteSpace(tvItemModelTel.Error))
                return null;

            TelModel telModelNew = new TelModel()
            {
                TelNumber = TelNumber,
                TelType = TelTypeEnum.Personal,
                TelTVItemID = tvItemModelTel.TVItemID,
            };

            TelModel TelModel = telService.PostAddTelDB(telModelNew);
            if (!string.IsNullOrWhiteSpace(TelModel.Error))
                return null;

            FormCollection fc = new FormCollection();
            fc.Add("ContactTVItemID", contactModelListGood[0].ContactTVItemID.ToString());
            fc.Add("TelNumber", TelNumber);
            fc.Add("TelTVItemID", tvItemModelTel.TVItemID.ToString());
            fc.Add("TelType", ((int)TelTypeEnum.Personal).ToString());

            return fc;
        }
        private void FillTelModelNew(TelModel telModel)
        {
            telModel.TelTVItemID = telModel.TelTVItemID;
            telModel.TelNumber = randomService.RandomTel();
            telModel.TelType = TelTypeEnum.Work;

            Assert.IsTrue(telModel.TelTVItemID != 0);
            Assert.IsTrue(telModel.TelNumber != null);
            Assert.IsTrue(telModel.TelType == TelTypeEnum.Work);
        }
        private void FillTelModelUpdate(TelModel telModel)
        {
            telModel.TelNumber = randomService.RandomTel();
            telModel.TelType = TelTypeEnum.Personal;

            Assert.IsTrue(telModel.TelNumber != null);
            Assert.IsTrue(telModel.TelType == TelTypeEnum.Personal);
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
            telService = new TelService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            telModelNew = new TelModel();
            tel = new Tel();
        }
        private void SetupShim()
        {
            shimTelService = new ShimTelService(telService);
            shimTVItemService = new ShimTVItemService(telService._TVItemService);
            shimTVItemLinkService = new ShimTVItemLinkService(telService._TVItemLinkService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(telService._TVItemService._TVItemLanguageService);
        }
        #endregion Functions private
    }
}

