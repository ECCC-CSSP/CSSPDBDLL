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
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for EmailServiceTest
    /// </summary>
    [TestClass]
    public class EmailServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "Email";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private EmailService emailService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private EmailModel emailModelNew { get; set; }
        private Email email { get; set; }
        private ShimEmailService shimEmailService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLinkService shimTVItemLinkService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
        private TVItemService tvItemService { get; set; }
        private BaseEnumService baseEnumService { get; set; }
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
        public EmailServiceTest()
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
        public void EmailService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(emailService);
                Assert.IsNotNull(emailService._TVItemService);
                Assert.IsNotNull(emailService._TVItemService._TVItemLanguageService);
                Assert.IsNotNull(emailService.db);
                Assert.IsNotNull(emailService.LanguageRequest);
                Assert.IsNotNull(emailService.User);
                Assert.AreEqual(user.Identity.Name, emailService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), emailService.LanguageRequest);
            }
        }
        [TestMethod]
        public void EmailService_EmailModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModel = AddEmailModel();

                    Assert.AreEqual("", emailModel.Error);

                    #region EmailText
                    int Max = 255;
                    emailModelNew.EmailTVItemID = emailModel.EmailTVItemID;
                    FillEmailModelNew(emailModelNew);
                    emailModelNew.EmailAddress = "";

                    string retStr = emailService.EmailModelOK(emailModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.Email), retStr);

                    FillEmailModelNew(emailModelNew);
                    emailModelNew.EmailAddress = randomService.RandomString("", Max + 1) + randomService.RandomEmail();

                    retStr = emailService.EmailModelOK(emailModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Email, Max), retStr);

                    FillEmailModelNew(emailModelNew);
                    emailModelNew.EmailAddress = "Charles.LeBalnc.seifjl.gc.gc.ca";

                    retStr = emailService.EmailModelOK(emailModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._EmailNotWellFormed, emailModelNew.EmailAddress), retStr);

                    #endregion EmailText

                    #region EmailType
                    FillEmailModelNew(emailModelNew);
                    emailModelNew.EmailType = (EmailTypeEnum)10000;

                    retStr = emailService.EmailModelOK(emailModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.EmailType), retStr);

                    FillEmailModelNew(emailModelNew);
                    emailModelNew.EmailType = EmailTypeEnum.Work;

                    retStr = emailService.EmailModelOK(emailModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion EmailType

                    #region EmailTVItemID
                    FillEmailModelNew(emailModelNew);
                    emailModelNew.EmailTVItemID = 0;

                    retStr = emailService.EmailModelOK(emailModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.EmailTVItemID), retStr);

                    emailModelNew.EmailTVItemID = emailModel.EmailTVItemID;
                    FillEmailModelNew(emailModelNew);

                    retStr = emailService.EmailModelOK(emailModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion EmailTVItemID
                }
            }
        }
        [TestMethod]
        public void EmailService_FillEmail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    Assert.AreEqual("", emailModelRet.Error);

                    emailModelNew.EmailTVItemID = emailModelRet.EmailTVItemID;

                    FillEmailModelNew(emailModelNew);

                    ContactOK contactOK = emailService.IsContactOK();

                    string retStr = emailService.FillEmail(email, emailModelNew, contactOK);

                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, email.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = emailService.FillEmail(email, emailModelNew, contactOK);

                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, email.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void EmailService_GetEmailModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    int emailCount = emailService.GetEmailModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, emailCount);
                }
            }
        }
        [TestMethod]
        public void EmailService_GetEmailModelWithEmailIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    EmailModel emailModelRet2 = emailService.GetEmailModelWithEmailIDDB(emailModelRet.EmailID);

                    Assert.IsNotNull(emailModelRet2);
                    CompareEmailModels(emailModelRet, emailModelRet2);

                    int EmailID = 0;
                    EmailModel emailModelRet3 = emailService.GetEmailModelWithEmailIDDB(EmailID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Email, ServiceRes.EmailID, EmailID), emailModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_GetEmailModelWithEmailTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    EmailModel emailModelRet2 = emailService.GetEmailModelWithEmailTVItemIDDB(emailModelRet.EmailTVItemID);

                    Assert.IsNotNull(emailModelRet2);
                    CompareEmailModels(emailModelRet, emailModelRet2);

                    int EmailTVItemID = 0;
                    EmailModel emailModelRet3 = emailService.GetEmailModelWithEmailTVItemIDDB(EmailTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Email, ServiceRes.EmailTVItemID, EmailTVItemID), emailModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_GetEmailWithEmailIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    Email emailRet2 = emailService.GetEmailWithEmailIDDB(emailModelRet.EmailID);

                    Assert.IsNotNull(emailRet2);
                    Assert.AreEqual(emailModelRet.EmailID, emailRet2.EmailID);

                    Email emailRet3 = emailService.GetEmailWithEmailIDDB(0);
                    Assert.IsNull(emailRet3);
                }
            }
        }
        [TestMethod]
        public void EmailService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    string retStr = emailService.CreateTVText(emailModelRet);

                    Assert.AreEqual(emailModelRet.EmailAddress, retStr);

                    emailModelRet.EmailAddress = "";
                    retStr = emailService.CreateTVText(emailModelRet);
                    Assert.AreEqual(emailModelRet.EmailAddress, retStr);
                }
            }
        }
        [TestMethod]
        public void EmailService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    EmailModel emailModelRet = emailService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, emailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Good_Add_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();
                    //fc["EmailType"] = "0";

                    Assert.IsNotNull(fc);

                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", emailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Good_Add_AlreadyExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    //fc["EmailAddress"] = "";
                    //fc["EmailType"] = "0";

                    Assert.IsNotNull(fc);

                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", emailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Good_Modify_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();
                    //fc["EmailType"] = "0";

                    Assert.IsNotNull(fc);

                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", emailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_ContactTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    fc["ContactTVItemID"] = "0";
                    //fc["EmailTVItemID"] = "0";
                    //fc["EmailAddress"] = "";
                    //fc["EmailType"] = "0";


                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID), emailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_EmailAddress_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = "";
                    //fc["EmailType"] = "0";

                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.EmailAddress), emailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_EmailType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["EmailTVItemID"] = "0";
                    //fc["EmailAddress"] = "";
                    fc["EmailType"] = "0";


                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.EmailType), emailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Add_GetRootTVItemModelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    //fc["EmailAddress"] = "";
                    //fc["EmailType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetRootTVItemModelDB = () =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Add_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    //fc["EmailAddress"] = "";
                    //fc["EmailType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Add_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    //fc["EmailAddress"] = "";
                    //fc["EmailType"] = "0";

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimEmailService.CreateTVTextEmailModel = (a) =>
                        {
                            return "";
                        };

                        EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Add_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    //fc["EmailAddress"] = "";
                    //fc["EmailType"] = "0";

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

                        EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Add_PostAddEmailDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    //fc["EmailAddress"] = "";
                    //fc["EmailType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };
                        shimEmailService.PostAddEmailDBEmailModel = (a) =>
                        {
                            return new EmailModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Add_GetEmailModelWithEmailTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    //fc["EmailAddress"] = "";
                    //fc["EmailType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimEmailService.GetEmailModelWithEmailTVItemIDDBInt32 = (a) =>
                        {
                            return new EmailModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Add_GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    //fc["EmailAddress"] = "";
                    //fc["EmailType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDBInt32Int32 = (a, b) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                        Assert.AreEqual("", emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Add_PostAddTVItemLinkDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    //fc["EmailAddress"] = "";
                    //fc["EmailType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.PostAddTVItemLinkDBTVItemLinkModel = (a) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Modify_GetEmailModelWithEmailTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();
                    //fc["EmailType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimEmailService.GetEmailModelWithEmailTVItemIDDBInt32 = (a) =>
                        {
                            return new EmailModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Modify_PostUpdateEmailDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();
                    //fc["EmailType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimEmailService.PostUpdateEmailDBEmailModel = (a) =>
                        {
                            return new EmailModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Modify_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();
                    //fc["EmailType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddOrModifyDB_Modify_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();
                    //fc["EmailType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddUpdateDeleteEmail_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    EmailModel emailModelRet2 = UpdateEmailModel(emailModelRet);

                    EmailModel emailModelRet3 = emailService.PostDeleteEmailDB(emailModelRet2.EmailID);

                    Assert.AreEqual("", emailModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddEmailDB_EmailModelOK_Error_Test()
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
                        shimEmailService.EmailModelOKEmailModel = (a) =>
                        {
                            return ErrorText;
                        };

                        EmailModel emailModelRet = AddEmailModel();
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddEmailDB_IsContactOK_Error_Test()
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
                        shimEmailService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        EmailModel emailModelRet = AddEmailModel();
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddEmailDB_GetTVItemModelWithTVItemIDDB_Error_Test()
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

                        EmailModel emailModelRet = AddEmailModel();
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddEmailDB_FillEmail_Error_Test()
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
                        shimEmailService.FillEmailEmailEmailModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        EmailModel emailModelRet = AddEmailModel();
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddEmailDB_DoAddChanges_Error_Test()
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
                        shimEmailService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        EmailModel emailModelRet = AddEmailModel();
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddEmailDB_Add_Error_Test()
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
                        shimEmailService.FillEmailEmailEmailModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        EmailModel emailModelRet = AddEmailModel();
                        Assert.IsTrue(emailModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddEmailDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    Assert.IsNotNull(emailModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, emailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_PostAddEmailDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    Assert.IsNotNull(emailModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, emailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_PostDeleteEmail_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimEmailService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        EmailModel emailModelRet2 = emailService.PostDeleteEmailDB(emailModelRet.EmailID);
                        Assert.AreEqual(ErrorText, emailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostDeleteEmail_GetEmailWithEmailIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimEmailService.GetEmailWithEmailIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        EmailModel emailModelRet2 = emailService.PostDeleteEmailDB(emailModelRet.EmailID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Email), emailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostDeleteEmail_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimEmailService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        EmailModel emailModelRet2 = emailService.PostDeleteEmailDB(emailModelRet.EmailID);
                        Assert.AreEqual(ErrorText, emailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostDeleteEmail_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet2 = emailService.PostDeleteEmailDB(emailModelRet.EmailID);
                        Assert.AreEqual(ErrorText, emailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostDeleteEmailUnderContactTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();

                    Assert.IsNotNull(fc);

                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);

                    Assert.AreEqual("", emailModelRet.Error);

                    fc["EmailTVItemID"] = emailModelRet.EmailTVItemID.ToString();

                    emailModelRet = emailService.PostDeleteEmailUnderContactTVItemIDDB(fc);
                    Assert.AreEqual("", emailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_PostDeleteEmailUnderContactTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();

                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);

                    fc["EmailTVItemID"] = emailModelRet.EmailTVItemID.ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimEmailService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        emailModelRet = emailService.PostDeleteEmailUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostDeleteEmailUnderContactTVItemIDDB_ContactTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();

                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);

                    fc["EmailTVItemID"] = emailModelRet.EmailTVItemID.ToString();

                    fc["ContactTVItemID"] = "0";

                    emailModelRet = emailService.PostDeleteEmailUnderContactTVItemIDDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID), emailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_PostDeleteEmailUnderContactTVItemIDDB_EmailTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();

                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);

                    //fc["EmailTVItemID"] = emailModelRet.EmailTVItemID.ToString();

                    fc["EmailTVItemID"] = "0";

                    emailModelRet = emailService.PostDeleteEmailUnderContactTVItemIDDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.EmailTVItemID), emailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void EmailService_PostDeleteEmailUnderContactTVItemIDDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();

                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);

                    fc["EmailTVItemID"] = emailModelRet.EmailTVItemID.ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        emailModelRet = emailService.PostDeleteEmailUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostDeleteEmailUnderContactTVItemIDDB_GetTVItemModelWithTVItemIDDB2_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();

                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);

                    fc["EmailTVItemID"] = emailModelRet.EmailTVItemID.ToString();

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

                        emailModelRet = emailService.PostDeleteEmailUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostDeleteEmailUnderContactTVItemIDDB_GetEmailModelWithEmailTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();

                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);

                    fc["EmailTVItemID"] = emailModelRet.EmailTVItemID.ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimEmailService.GetEmailModelWithEmailTVItemIDDBInt32 = (a) =>
                        {
                            return new EmailModel() { Error = ErrorText };
                        };

                        emailModelRet = emailService.PostDeleteEmailUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostDeleteEmailUnderContactTVItemIDDB_PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["EmailTVItemID"] = "0";
                    fc["EmailAddress"] = randomService.RandomEmail();

                    EmailModel emailModelRet = emailService.PostAddOrModifyDB(fc);

                    fc["EmailTVItemID"] = emailModelRet.EmailTVItemID.ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDBInt32Int32 = (a, b) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        emailModelRet = emailService.PostDeleteEmailUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, emailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostUpdateEmail_EmailModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    FillEmailModelUpdate(emailModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimEmailService.EmailModelOKEmailModel = (a) =>
                        {
                            return ErrorText;
                        };

                        EmailModel emailModelRet2 = emailService.PostUpdateEmailDB(emailModelRet);
                        Assert.AreEqual(ErrorText, emailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostUpdateEmail_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    FillEmailModelUpdate(emailModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimEmailService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        EmailModel emailModelRet2 = emailService.PostUpdateEmailDB(emailModelRet);
                        Assert.AreEqual(ErrorText, emailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostUpdateEmail_GetEmailWithEmailIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    FillEmailModelUpdate(emailModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimEmailService.GetEmailWithEmailIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        EmailModel emailModelRet2 = emailService.PostUpdateEmailDB(emailModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Email), emailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostUpdateEmail_FillEmail_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    FillEmailModelUpdate(emailModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimEmailService.FillEmailEmailEmailModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        EmailModel emailModelRet2 = emailService.PostUpdateEmailDB(emailModelRet);
                        Assert.AreEqual(ErrorText, emailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostUpdateEmail_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    FillEmailModelUpdate(emailModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimEmailService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        EmailModel emailModelRet2 = emailService.PostUpdateEmailDB(emailModelRet);
                        Assert.AreEqual(ErrorText, emailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostUpdateEmail_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    FillEmailModelUpdate(emailModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet2 = emailService.PostUpdateEmailDB(emailModelRet);
                        Assert.AreEqual(ErrorText, emailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostUpdateEmail_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    FillEmailModelUpdate(emailModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimEmailService.CreateTVTextEmailModel = (a) =>
                        {
                            return "";
                        };

                        EmailModel emailModelRet2 = emailService.PostUpdateEmailDB(emailModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, "TVText"), emailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void EmailService_PostUpdateEmail_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    EmailModel emailModelRet = AddEmailModel();

                    FillEmailModelUpdate(emailModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        EmailModel emailModelRet2 = emailService.PostUpdateEmailDB(emailModelRet);
                        Assert.AreEqual(ErrorText, emailModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private EmailModel AddEmailModel()
        {
            TVItemModel tvItemRoot = emailService._TVItemService.GetRootTVItemModelDB();

            Assert.AreEqual("", tvItemRoot.Error);

            string TVText = randomService.RandomString("Email ", 15);
            TVItemModel tvItemModelEmail = emailService._TVItemService.PostAddChildTVItemDB(tvItemRoot.TVItemID, TVText, TVTypeEnum.Email);
            if (!string.IsNullOrWhiteSpace(tvItemModelEmail.Error))
            {
                return new EmailModel() { Error = tvItemModelEmail.Error };
            }

            emailModelNew.EmailTVItemID = tvItemModelEmail.TVItemID;

            FillEmailModelNew(emailModelNew);

            EmailModel emailModelRet = emailService.PostAddEmailDB(emailModelNew);
            if (!string.IsNullOrWhiteSpace(emailModelRet.Error))
            {
                return emailModelRet;
            }

            emailModelNew.EmailTVItemID = emailModelRet.EmailTVItemID;

            CompareEmailModels(emailModelNew, emailModelRet);

            return emailModelRet;
        }
        private EmailModel UpdateEmailModel(EmailModel emailModel)
        {
            FillEmailModelUpdate(emailModel);

            EmailModel emailModelRet = emailService.PostUpdateEmailDB(emailModel);
            if (!string.IsNullOrWhiteSpace(emailModelRet.Error))
            {
                return emailModelRet;
            }

            CompareEmailModels(emailModel, emailModelRet);

            return emailModelRet;
        }
        private void CompareEmailModels(EmailModel emailModelNew, EmailModel emailModelRet)
        {
            Assert.AreEqual(emailModelNew.EmailTVItemID, emailModelRet.EmailTVItemID);
            Assert.AreEqual(emailModelNew.EmailAddress, emailModelRet.EmailAddress);
            Assert.AreEqual(emailModelNew.EmailType, emailModelRet.EmailType);
        }
        public FormCollection FillPostAddOrModifyDBFormCollection()
        {
            string EmailAddress = randomService.RandomEmail();
            TVItemModel tvItemModelEmail = tvItemService.PostAddChildTVItemDB(1, EmailAddress, TVTypeEnum.Email);
            if (!string.IsNullOrWhiteSpace(tvItemModelEmail.Error))
                return null;

            EmailModel EmailModelNew = new EmailModel()
            {
                EmailAddress = EmailAddress,
                EmailType = EmailTypeEnum.Personal,
                EmailTVItemID = tvItemModelEmail.TVItemID,
            };

            EmailModel EmailModel = emailService.PostAddEmailDB(EmailModelNew);
            if (!string.IsNullOrWhiteSpace(EmailModel.Error))
                return null;

            FormCollection fc = new FormCollection();
            fc.Add("ContactTVItemID", contactModelListGood[0].ContactTVItemID.ToString());
            fc.Add("EmailAddress", EmailAddress);
            fc.Add("EmailTVItemID", tvItemModelEmail.TVItemID.ToString());
            fc.Add("EmailType", ((int)EmailTypeEnum.Personal).ToString());

            return fc;
        }
        private void FillEmailModelNew(EmailModel emailModel)
        {
            emailModel.EmailTVItemID = emailModel.EmailTVItemID;
            emailModel.EmailAddress = randomService.RandomEmail();
            emailModel.EmailType = EmailTypeEnum.Work;

            Assert.IsTrue(emailModel.EmailTVItemID != 0);
            Assert.IsTrue(emailModel.EmailAddress != null);
            Assert.IsTrue(emailModel.EmailType == EmailTypeEnum.Work);
        }
        private void FillEmailModelUpdate(EmailModel emailModel)
        {
            emailModel.EmailAddress = randomService.RandomEmail();
            emailModel.EmailType = EmailTypeEnum.Personal;

            Assert.IsTrue(emailModel.EmailAddress != null);
            Assert.IsTrue(emailModel.EmailType == EmailTypeEnum.Personal);
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
            emailService = new EmailService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            baseEnumService = new BaseEnumService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en));
            emailModelNew = new EmailModel();
            email = new Email();
        }
        private void SetupShim()
        {
            shimEmailService = new ShimEmailService(emailService);
            shimTVItemService = new ShimTVItemService(emailService._TVItemService);
            shimTVItemLinkService = new ShimTVItemLinkService(emailService._TVItemLinkService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(emailService._TVItemService._TVItemLanguageService);
        }
        #endregion Functions private
    }
}

