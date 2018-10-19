using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPWebToolsDBDLL.Tests.SetupInfo;
using CSSPWebToolsDBDLL.Models;
using System.Security.Principal;
using CSSPWebToolsDBDLL.Services;
using CSSPWebToolsDBDLL.Services.Resources;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Transactions;
using CSSPWebToolsDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Linq;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for ContactServiceTest
    /// </summary>
    [TestClass]
    public class ContactServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "Contact";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private ContactService contactService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private ContactModel contactModelNew { get; set; }
        private Contact contact { get; set; }
        private ShimAspNetUserService shimAspNetUserService { get; set; }
        private ShimContactService shimContactService { get; set; }
        private ShimTVTypeUserAuthorizationService shimTVTypeUserAuthorizationService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
        private ShimTVItemLinkService shimTVItemLinkService { get; set; }
        private ShimResetPasswordService shimResetPasswordService { get; set; }
        private ResetPasswordService resetPasswordService { get; set; }
        private ResetPasswordServiceTest resetPasswordServiceTest { get; set; }
        private AspNetUserService aspNetUserService { get; set; }
        private AspNetUserServiceTest aspNetUserServiceTest { get; set; }
        private TVItemService tvItemService { get; set; }
        private TelServiceTest telServiceTest { get; set; }
        private EmailServiceTest emailServiceTest { get; set; }
        private AddressServiceTest addressServiceTest { get; set; }
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
        public ContactServiceTest()
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

        #region Testing Methods public Check
        [TestMethod]
        public void ContactService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                string FromEmail = (string)(new PrivateObject(contactService, "FromEmail")).Target;
                int UniqueCodeSize = (int)(new PrivateObject(contactService, "UniqueCodeSize")).Target;
                bool CanSendEmail = (bool)(new PrivateObject(contactService, "CanSendEmail")).Target;
                int SearchMaxReturn = (int)(new PrivateObject(contactService, "SearchMaxReturn")).Target;
                Assert.IsNotNull(contactService);
                Assert.IsNotNull(contactService._AspNetUserService);
                Assert.IsNotNull(contactService._TVTypeUserAuthorizationService);
                Assert.IsNotNull(contactService._TVItemUserAuthorizationService);
                Assert.IsNotNull(contactService._TVItemService);
                Assert.IsNotNull(contactService._ResetPasswordService);
                Assert.IsNotNull(contactService.User);
                Assert.IsNotNull(contactService.db);
                Assert.IsNotNull(contactService.LanguageRequest);
                Assert.IsNotNull(contactService.User);
                Assert.AreEqual(user.Identity.Name, contactService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), contactService.LanguageRequest);
                Assert.AreEqual("ec.pccsm-cssp.ec@canada.ca".ToLower(), FromEmail.ToLower());
                Assert.AreEqual(8, UniqueCodeSize);
                Assert.AreEqual(true, CanSendEmail);
                Assert.AreEqual(10, SearchMaxReturn);
            }
        }
        [TestMethod]
        public void ContactService_CheckCodeEmailExistDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModel = resetPasswordServiceTest.AddResetPasswordModel();
                    Assert.AreEqual("", resetPasswordModel.Error);

                    string CodeEmail = resetPasswordModel.Code + "," + resetPasswordModel.Email;

                    string retStr = contactService.CheckCodeEmailExistDB(CodeEmail);
                    Assert.AreEqual("true", retStr);
                }
            }
        }
        [TestMethod]
        public void ContactService_CheckCodeEmailExistDB_CodeEmail_NotWellForm_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModel = resetPasswordServiceTest.AddResetPasswordModel();
                    Assert.AreEqual("", resetPasswordModel.Error);

                    string CodeEmail = resetPasswordModel.Code + "," + resetPasswordModel.Email + ",NotWellForm";

                    string retStr = contactService.CheckCodeEmailExistDB(CodeEmail);
                    Assert.AreEqual(string.Format(ServiceRes._IsNotComposedOf_Parts, ServiceRes.CodeEmail, 2), retStr);

                }

            }
        }
        [TestMethod]
        public void ContactService_CheckCodeEmailExistDB_CodeEmail_NotWellForm2_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModel = resetPasswordServiceTest.AddResetPasswordModel();
                    Assert.AreEqual("", resetPasswordModel.Error);

                    string CodeEmail = resetPasswordModel.Code + "bad";

                    string retStr = contactService.CheckCodeEmailExistDB(CodeEmail);
                    Assert.AreEqual(string.Format(ServiceRes._IsNotComposedOf_Parts, ServiceRes.CodeEmail, 2), retStr);

                }

            }
        }
        [TestMethod]
        public void ContactService_CheckCodeEmailExistDB_DoesNotExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModel = resetPasswordServiceTest.AddResetPasswordModel();
                    Assert.AreEqual("", resetPasswordModel.Error);

                    string CodeEmail = resetPasswordModel.Code + ",NotExist" + resetPasswordModel.Email;

                    string retStr = contactService.CheckCodeEmailExistDB(CodeEmail);
                    Assert.AreEqual(string.Format(ServiceRes.Code_ForEmail_DoesNotExist, resetPasswordModel.Code, "NotExist" + resetPasswordModel.Email), retStr);

                }

            }
        }
        [TestMethod]
        public void ContactService_CheckCodeEmailExistDB_EmailNotWellFormed_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModel = resetPasswordServiceTest.AddResetPasswordModel();
                    Assert.AreEqual("", resetPasswordModel.Error);

                    string Email = resetPasswordModel.Email.Replace("@", "");
                    string CodeEmail = resetPasswordModel.Code + "," + resetPasswordModel.Email.Replace("@", "");

                    string retStr = contactService.CheckCodeEmailExistDB(CodeEmail);
                    Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, Email), retStr);
                }
            }
        }
        [TestMethod]
        public void ContactService_CheckEmailExistDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string Email = "Charles.LeBlanc2@Canada.ca";

                string retStr = contactService.CheckEmailExistDB(Email);
                Assert.AreEqual("true", retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckEmailExistDB_EmailNotExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string Email = "NotExistCharles.LeBlanc2@Canada.ca";

                string retStr = contactService.CheckEmailExistDB(Email);
                Assert.AreEqual(string.Format(ServiceRes._DoesNotExist, Email), retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckEmailExistDB_EmailNotWellFormed_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string Email = "NotExistCharles.LeBlanc.ec.gc.ca";

                string retStr = contactService.CheckEmailExistDB(Email);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, Email), retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckEmailUniquenessDB_Good_LoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string Email = "UniqueCharles.LeBlanc2@Canada.ca";

                string retStr = contactService.CheckEmailUniquenessDB(Email);
                Assert.AreEqual("true", retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckEmailUniquenessDB_NotUnique_LoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string Email = "Christopher.Roberts@canada.ca";

                string retStr = contactService.CheckEmailUniquenessDB(Email);
                Assert.AreEqual(string.Format(ServiceRes._IsAlreadyTaken, Email), retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckEmailUniquenessDB_Good_NotLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                string Email = "UniqueCharles.LeBlanc2@Canada.ca";

                string retStr = contactService.CheckEmailUniquenessDB(Email);
                Assert.AreEqual("true", retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckEmailUniquenessDB_NotUnique_NotLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                string Email = "Charles.LeBlanc2@Canada.ca";

                string retStr = contactService.CheckEmailUniquenessDB(Email);
                Assert.AreEqual(string.Format(ServiceRes._IsAlreadyTaken, Email), retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckFullNameUniquenessDB_Good_LoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string FullName = "Charles,G,LeBlanc";

                string retStr = contactService.CheckFullNameUniquenessDB(FullName);
                Assert.AreEqual("true", retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckFullNameUniquenessDB_AlreadyTaken_LoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string FirstName = "Christopher";
                string Initial = "G";
                string LastName = "Roberts";
                string FullName = FirstName + "," + Initial + "," + LastName;

                string retStr = contactService.CheckFullNameUniquenessDB(FullName);
                Assert.AreEqual(string.Format(ServiceRes._IsAlreadyTaken, FirstName + (string.IsNullOrEmpty(Initial) ? " " : " " + Initial + ", ") + LastName), retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckFullNameUniquenessDB_NotWellFormed_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string FullName = "Charles,G,LeBlanc,notwellformed";

                string retStr = contactService.CheckFullNameUniquenessDB(FullName);
                Assert.AreEqual(string.Format(ServiceRes._IsNotComposedOf_Parts, ServiceRes.FullName, 3), retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckFullNameUniquenessDB_NotWellFormed2_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string FullName = "Charles,";

                string retStr = contactService.CheckFullNameUniquenessDB(FullName);
                Assert.AreEqual(string.Format(ServiceRes._IsNotComposedOf_Parts, ServiceRes.FullName, 3), retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckFullNameUniquenessDB_Good_NotLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                string FirstName = "UniqueCharles";
                string Initial = "G";
                string LastName = "LeBlanc";
                string FullName = FirstName + "," + Initial + "," + LastName;

                string retStr = contactService.CheckFullNameUniquenessDB(FullName);
                Assert.AreEqual("true", retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckFullNameUniquenessDB_AlreadyTaken_NotLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                string FirstName = "Charles";
                string Initial = "G";
                string LastName = "LeBlanc";
                string FullName = FirstName + "," + Initial + "," + LastName;

                string retStr = contactService.CheckFullNameUniquenessDB(FullName);
                Assert.AreEqual(string.Format(ServiceRes._IsAlreadyTaken, FirstName + (string.IsNullOrEmpty(Initial) ? " " : " " + Initial + ", ") + LastName), retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckFullNameUniquenessDB_AlreadyTaken_NotLoggedIn_NoInitial_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                string FirstName = "Christopher";
                string Initial = "G";
                string LastName = "Roberts";
                string FullName = FirstName + "," + Initial + "," + LastName;

                string retStr = contactService.CheckFullNameUniquenessDB(FullName);
                Assert.AreEqual(string.Format(ServiceRes._IsAlreadyTaken, FirstName + (string.IsNullOrEmpty(Initial) ? " " : " " + Initial + ", ") + LastName), retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckWebNameUniquenessDB_Good_LoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string WebName = "UniqueCharles";

                string retStr = contactService.CheckWebNameUniquenessDB(WebName);
                Assert.AreEqual("true", retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckWebNameUniquenessDB_Good_NotLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                string WebName = "UniqueCharles";

                string retStr = contactService.CheckWebNameUniquenessDB(WebName);
                Assert.AreEqual("true", retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckWebNameUniquenessDB_AlreadyTaken_LoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string WebName = "Christopher_Roberts";

                string retStr = contactService.CheckWebNameUniquenessDB(WebName);
                Assert.AreEqual(string.Format(ServiceRes._IsAlreadyTaken, WebName), retStr);

            }
        }
        [TestMethod]
        public void ContactService_CheckWebNameUniquenessDB_AlreadyTaken_NotLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                string WebName = "Christopher_Roberts";

                string retStr = contactService.CheckWebNameUniquenessDB(WebName);
                Assert.AreEqual(string.Format(ServiceRes._IsAlreadyTaken, WebName), retStr);

            }
        }
        [TestMethod]
        public void ContactService_ContactModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    Assert.AreEqual("", contactModelRet.Error);

                    #region Good
                    string retStr = contactService.ContactModelOK(contactModelRet);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region ContactTVItemID
                    retStr = contactService.ContactModelOK(contactModelRet);
                    Assert.AreEqual("", retStr);

                    contactModelNew.ContactTVItemID = contactModelRet.ContactTVItemID;
                    FillContactModel(contactModelNew);
                    contactModelNew.ContactTVItemID = 0;

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID), retStr);
                    #endregion ContactTVItemID

                    #region WebName
                    int Min = 3;
                    int Max = 50;

                    contactModelNew.ContactTVItemID = contactModelRet.ContactTVItemID;
                    FillContactModel(contactModelNew);
                    contactModelNew.WebName = randomService.RandomString("", Min - 1);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.WebName, Min), retStr);

                    FillContactModel(contactModelNew);
                    contactModelNew.WebName = randomService.RandomString("", Max + 1);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.WebName, Max), retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.WebName = randomService.RandomString("", Min);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual("", retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.WebName = randomService.RandomString("", Max);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual("", retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.WebName = randomService.RandomString("", Max - 1);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion WebName

                    #region FirstName
                    Min = 1;
                    Max = 100;

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.FirstName = randomService.RandomString("", Min - 1);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.FirstName, Min), retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.FirstName = randomService.RandomString("", Max + 1);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.FirstName, Max), retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.FirstName = randomService.RandomString("", Min);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual("", retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.FirstName = randomService.RandomString("", Max);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual("", retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.FirstName = randomService.RandomString("", Max - 1);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion FirstName

                    #region Initial
                    Min = 0;
                    Max = 50;

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.Initial = randomService.RandomString("", Max + 1);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Initial, Max), retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.Initial = randomService.RandomString("", Min);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual("", retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.Initial = randomService.RandomString("", Max);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual("", retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.Initial = randomService.RandomString("", Max - 1);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Initial

                    #region LastName
                    Min = 1;
                    Max = 100;

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.LastName = randomService.RandomString("", Min - 1);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.LastName, Min), retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.LastName = randomService.RandomString("", Max + 1);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.LastName, Max), retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.LastName = randomService.RandomString("", Min);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual("", retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.LastName = randomService.RandomString("", Max);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual("", retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.LastName = randomService.RandomString("", Max - 1);

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion LastName

                    #region LoginEmail
                    FillContactModel(contactModelNew);
                    Max = 255;
                    contactModelNew.LoginEmail = "";

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Email), retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.LoginEmail = randomService.RandomString("", Max + 1) + randomService.RandomEmail();

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Email, Max), retStr);

                    contactModelNew = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    contactModelNew.LoginEmail = "Charles.LeBalnc.seifjl.gc.gc.ca";

                    retStr = contactService.ContactModelOK(contactModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, contactModelNew.LoginEmail), retStr);

                    #endregion LoginEmail
                }
            }
        }
        [TestMethod]
        public void ContactService_ContactModelOK_WebName_NotUnique_LoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                ContactModel contactModelRet = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                Assert.AreEqual("", contactModelRet.Error);

                contactModelRet.WebName = "Christopher_Roberts";

                string retStr = contactService.ContactModelOK(contactModelRet);
                Assert.AreEqual(string.Format(ServiceRes._HasToBeUnique, ServiceRes.WebName), retStr);

            }
        }
        [TestMethod]
        public void ContactService_ContactModelOK_WebName_NotUnique_NotLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                contactModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(2).ContactTVItemID;

                FillContactModel(contactModelNew);
                contactModelNew.WebName = "Charles";

                string retStr = contactService.ContactModelOK(contactModelNew);
                Assert.AreEqual(string.Format(ServiceRes._HasToBeUnique, ServiceRes.WebName), retStr);

            }
        }
        [TestMethod]
        public void ContactService_ContactModelOK_FullName_NotUnique_LoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                ContactModel contactModelRet = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                Assert.AreEqual("", contactModelRet.Error);

                contactModelRet.FirstName = "Christopher";
                contactModelRet.Initial = "G";
                contactModelRet.LastName = "Roberts";
                contactModelRet.IsNew = true;

                string retStr = contactService.ContactModelOK(contactModelRet);
                Assert.AreEqual(string.Format(ServiceRes._HasToBeUnique, ServiceRes.FullName), retStr);

            }
        }
        [TestMethod]
        public void ContactService_ContactModelOK_FullName_NotUnique_NotLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                contactModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(2).ContactTVItemID;
                FillContactModel(contactModelNew);
                contactModelNew.FirstName = "Christopher";
                contactModelNew.Initial = "G";
                contactModelNew.LastName = "Roberts";

                string retStr = contactService.ContactModelOK(contactModelNew);
                Assert.AreEqual(string.Format(ServiceRes._HasToBeUnique, ServiceRes.FullName), retStr);

            }
        }
        [TestMethod]
        public void ContactService_ContactModelOK_LoginEmail_NotUnique_LoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                ContactModel contactModelRet = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                Assert.AreEqual("", contactModelRet.Error);

                contactModelRet.LoginEmail = "Christopher.Roberts@canada.ca";
                contactModelRet.IsNew = true;

                // Act Email Unique
                string retStr = contactService.ContactModelOK(contactModelRet);

                // Assert Email Unique
                Assert.AreEqual(string.Format(ServiceRes._HasToBeUnique, ServiceRes.Email), retStr);

            }
        }
        [TestMethod]
        public void ContactService_ContactModelOK_LoginEmail_NotUnique_NotLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                contactModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(2).ContactTVItemID;
                FillContactModel(contactModelNew);
                contactModelNew.LoginEmail = "Christopher.Roberts@canada.ca";

                // Act Email Unique
                string retStr = contactService.ContactModelOK(contactModelNew);

                // Assert Email Unique
                Assert.AreEqual(string.Format(ServiceRes._HasToBeUnique, ServiceRes.Email), retStr);

            }
        }
        [TestMethod]
        public void ContactService_LoginModelOK_RequiredFields_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LoginModel loginModelNew = new LoginModel();
                loginModelNew.Password = "Charles4$";

                string retStr = contactService.LoginModelOK(loginModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Email), retStr);

                loginModelNew = new LoginModel();
                loginModelNew.Email = "Charles.LeBlanc2@Canada.ca";

                retStr = contactService.LoginModelOK(loginModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Password), retStr);
            }
        }
        [TestMethod]
        public void ContactService_LoginModelOK_Email_MoreThan255_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LoginModel loginModelNew = new LoginModel();
                loginModelNew.Email = (new String("a".ToCharArray()[0], 256)).ToString(); // "Charles.LeBlanc2@Canada.ca";
                loginModelNew.Password = "Jour44$allo";

                string retStr = contactService.LoginModelOK(loginModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Email, 255), retStr);
            }
        }
        [TestMethod]
        public void ContactService_LoginModelOK_Password_MoreThan100_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LoginModel loginModelNew = new LoginModel();
                loginModelNew.Email = "Charles.LeBlanc2@Canada.ca";
                loginModelNew.Password = (new String("a".ToCharArray()[0], 101)).ToString(); //"Jour44$allo";

                string retStr = contactService.LoginModelOK(loginModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Password, 100), retStr);

            }
        }
        [TestMethod]
        public void ContactService_LoginModelOK_Email_NotWellFormed_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LoginModel loginModelNew = new LoginModel();
                loginModelNew.Email = "Charles.LeBlanc.ec.gc.ca";
                loginModelNew.Password = "Jour44$allo";

                string retStr = contactService.LoginModelOK(loginModelNew);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, loginModelNew.Email), retStr);
            }
        }
        [TestMethod]
        public void ContactService_NewContactModelOK_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                NewContactModel newContactModelNew = new NewContactModel();
                FillNewContactModel(newContactModelNew);

                string retStr = contactService.NewContactModelOK(newContactModelNew);
                Assert.AreEqual("", retStr);

                #region FirstName
                FillNewContactModel(newContactModelNew);
                int Max = 100;
                newContactModelNew.FirstName = "";

                retStr = contactService.NewContactModelOK(newContactModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FirstName), retStr);

                FillNewContactModel(newContactModelNew);
                newContactModelNew.FirstName = randomService.RandomString("", Max + 1);

                retStr = contactService.NewContactModelOK(newContactModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.FirstName, Max), retStr);

                FillNewContactModel(newContactModelNew);
                newContactModelNew.FirstName = randomService.RandomString("", Max);

                retStr = contactService.NewContactModelOK(newContactModelNew);
                Assert.AreEqual("", retStr);

                FillNewContactModel(newContactModelNew);
                newContactModelNew.FirstName = randomService.RandomString("", Max - 1);

                retStr = contactService.NewContactModelOK(newContactModelNew);
                Assert.AreEqual("", retStr);
                #endregion FirstName

                #region LastName
                FillNewContactModel(newContactModelNew);
                Max = 100;
                newContactModelNew.LastName = "";

                retStr = contactService.NewContactModelOK(newContactModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LastName), retStr);

                FillNewContactModel(newContactModelNew);
                newContactModelNew.LastName = randomService.RandomString("", Max + 1);

                retStr = contactService.NewContactModelOK(newContactModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.LastName, Max), retStr);

                FillNewContactModel(newContactModelNew);
                newContactModelNew.LastName = randomService.RandomString("", Max);

                retStr = contactService.NewContactModelOK(newContactModelNew);
                Assert.AreEqual("", retStr);

                FillNewContactModel(newContactModelNew);
                newContactModelNew.LastName = randomService.RandomString("", Max - 1);

                retStr = contactService.NewContactModelOK(newContactModelNew);
                Assert.AreEqual("", retStr);
                #endregion LastName

                #region LoginEmail
                FillNewContactModel(newContactModelNew);
                Max = 255;
                newContactModelNew.LoginEmail = "";

                retStr = contactService.NewContactModelOK(newContactModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Email), retStr);

                FillNewContactModel(newContactModelNew);
                newContactModelNew.LoginEmail = randomService.RandomString("", Max + 1) + randomService.RandomEmail();

                retStr = contactService.NewContactModelOK(newContactModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Email, Max), retStr);

                FillNewContactModel(newContactModelNew);
                newContactModelNew.LoginEmail = "Charles.LeBalnc.seifjl.gc.gc.ca";

                retStr = contactService.NewContactModelOK(newContactModelNew);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, newContactModelNew.LoginEmail), retStr);

                #endregion LoginEmail
            }
        }
        [TestMethod]
        public void ContactService_RegisterModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelNew = new RegisterModel();

                #region WebName
                FillRegisterModel(registerModelNew);
                int Max = 100;
                registerModelNew.WebName = "";

                string retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.WebName), retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.WebName = randomService.RandomString("", Max + 1);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.WebName, Max), retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.WebName = randomService.RandomString("", Max);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual("", retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.WebName = randomService.RandomString("", Max - 1);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual("", retStr);
                #endregion WebName

                #region FirstName
                FillRegisterModel(registerModelNew);
                Max = 100;
                registerModelNew.FirstName = "";

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FirstName), retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.FirstName = randomService.RandomString("", Max + 1);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.FirstName, Max), retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.FirstName = randomService.RandomString("", Max);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual("", retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.FirstName = randomService.RandomString("", Max - 1);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual("", retStr);
                #endregion FirstName

                #region Initial
                FillRegisterModel(registerModelNew);
                registerModelNew.Initial = "";

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual("", retStr);

                FillRegisterModel(registerModelNew);
                Max = 50;
                registerModelNew.Initial = randomService.RandomString("", Max + 1);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Initial, Max), retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.Initial = randomService.RandomString("", Max);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual("", retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.Initial = randomService.RandomString("", Max - 1);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual("", retStr);
                #endregion Initial

                #region LastName
                FillRegisterModel(registerModelNew);
                Max = 100;
                registerModelNew.LastName = "";

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LastName), retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.LastName = randomService.RandomString("", Max + 1);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.LastName, Max), retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.LastName = randomService.RandomString("", Max);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual("", retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.LastName = randomService.RandomString("", Max - 1);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual("", retStr);
                #endregion LastName

                #region LoginEmail
                FillRegisterModel(registerModelNew);
                Max = 255;
                registerModelNew.LoginEmail = "";

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Email), retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.LoginEmail = randomService.RandomString("", Max + 1) + randomService.RandomEmail();

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Email, Max), retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.LoginEmail = "Charles.LeBalnc.seifjl.gc.gc.ca";

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, registerModelNew.LoginEmail), retStr);

                #endregion LoginEmail

                #region Password
                FillRegisterModel(registerModelNew);
                int Min = 6;
                Max = 100;
                registerModelNew.Password = "";

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.Password, Min), retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.Password = randomService.RandomString("", Min - 1);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.Password, Min), retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.Password = randomService.RandomString("", Max + 1);

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Password, Max), retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.Password = randomService.RandomString("", Min);
                registerModelNew.ConfirmPassword = registerModelNew.Password;

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual("", retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.Password = randomService.RandomString("", Max);
                registerModelNew.ConfirmPassword = registerModelNew.Password;

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual("", retStr);

                FillRegisterModel(registerModelNew);
                registerModelNew.Password = randomService.RandomString("", Max - 1);
                registerModelNew.ConfirmPassword = registerModelNew.Password;

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual("", retStr);
                #endregion Password

                #region ConfirmPassword

                FillRegisterModel(registerModelNew);
                registerModelNew.Password = "Jour44$allo";
                registerModelNew.ConfirmPassword = "DiffJour44$allo";

                retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(ServiceRes.PasswordAndConfirmPasswordNotIdentical, retStr);

                #endregion ConfirmPassword

            }
        }
        [TestMethod]
        public void ContactService_RegisterModelOK_WebName_NotUnique_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelNew = new RegisterModel();

                FillRegisterModel(registerModelNew);
                registerModelNew.WebName = "Christopher_Roberts";

                string retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._HasToBeUnique, ServiceRes.WebName), retStr);
            }
        }
        [TestMethod]
        public void ContactService_RegisterModelOK_FullName_NotUnique_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelNew = new RegisterModel();

                FillRegisterModel(registerModelNew);
                registerModelNew.FirstName = "Christopher";
                registerModelNew.Initial = "G";
                registerModelNew.LastName = "Roberts";

                string retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._HasToBeUnique, ServiceRes.FullName), retStr);
            }
        }
        [TestMethod]
        public void ContactService_RegisterModelOK_Email_NotUnique_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelNew = new RegisterModel();

                FillRegisterModel(registerModelNew);
                registerModelNew.LoginEmail = "Charles.LeBlanc2@Canada.ca";

                string retStr = contactService.RegisterModelOK(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._HasToBeUnique, ServiceRes.Email), retStr);
            }
        }
        #endregion Testing Method public check

        #region Testing Methods public Fill
        [TestMethod]
        public void ContactService_FillContact_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FillContactModel(contactModelNew);

                    ContactOK contactOK = contactService.IsContactOK();

                    string retStr = contactService.FillContact(contact, contactModel, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, contact.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = contactService.FillContact(contact, contactModel, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, contact.LastUpdateContactTVItemID);
                }
            }
        }
        #endregion Testing Methods public Fill

        #region Testing Method public Get
        [TestMethod]
        public void ContactService_GetAdminContactModelListDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                List<ContactModel> contactModelList = contactService.GetAdminContactModelListDB();
                Assert.IsTrue(contactModelList.Where(c => c.ContactID == contactModelListGood[0].ContactID).Any());
            }
        }
        [TestMethod]
        public void ContactService_GetContactModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int contactCount = contactService.GetContactModelCountDB();
                Assert.AreEqual(testDBService.Count, contactCount);
            }
        }
        [TestMethod]
        public void ContactService_GetContactModelAndTelEmailAddressListWithContactTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                ContactModel contactModel = contactService.GetContactModelAndTelEmailAddressListWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                Assert.AreEqual("", contactModel.Error);
            }
        }
        [TestMethod]
        public void ContactService_GetContactModelListDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactID = contactModel.ContactID;

                int skip = 0;
                int take = 3;
                List<ContactModel> contactModelList = contactService.GetContactModelListDB(skip, take);
                Assert.IsNotNull(contactModelList);
                Assert.IsTrue(contactModelList.Count > 0);
            }
        }
        [TestMethod]
        public void ContactService_GetContactModelWithLoginEmailDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactID = contactModel.ContactID;

                ContactModel contactModelRet = contactService.GetContactModelWithContactIDDB(ContactID);
                Assert.IsNotNull(contactModelRet);
                Assert.AreEqual(contactModel.FirstName, contactModelRet.FirstName);
                Assert.AreEqual(contactModel.Initial, contactModelRet.Initial);
                Assert.AreEqual(contactModel.LastName, contactModelRet.LastName);

                ContactModel contactModelRet2 = contactService.GetContactModelWithLoginEmailDB(contactModelRet.LoginEmail);
                Assert.IsNotNull(contactModelRet2);
                Assert.AreEqual(contactModelRet.FirstName, contactModelRet2.FirstName);
                Assert.AreEqual(contactModelRet.Initial, contactModelRet2.Initial);
                Assert.AreEqual(contactModelRet.LastName, contactModelRet2.LastName);

                string LoginEmail = "willNotFindThis";
                contactModelRet2 = contactService.GetContactModelWithLoginEmailDB(LoginEmail);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.LoginEmail, LoginEmail), contactModelRet2.Error);

            }
        }
        [TestMethod]
        public void ContactService_GetContactModelWithFirstNameInitialAndLastNameDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactID = contactModel.ContactID;

                ContactModel contactModelRet = contactService.GetContactModelWithContactIDDB(ContactID);
                Assert.IsNotNull(contactModelRet);
                Assert.AreEqual(contactModel.FirstName, contactModelRet.FirstName);
                Assert.AreEqual(contactModel.Initial, contactModelRet.Initial);
                Assert.AreEqual(contactModel.LastName, contactModelRet.LastName);

                ContactModel contactModelRet2 = contactService.GetContactModelWithFirstNameInitialAndLastNameDB(contactModelRet.FirstName, contactModelRet.Initial, contactModelRet.LastName);
                Assert.IsNotNull(contactModelRet2);
                Assert.AreEqual(contactModelRet.FirstName, contactModelRet2.FirstName);
                Assert.AreEqual(contactModelRet.Initial, contactModelRet2.Initial);
                Assert.AreEqual(contactModelRet.LastName, contactModelRet2.LastName);

                ContactModel contactModelRet3 = contactService.GetContactModelWithFirstNameInitialAndLastNameDB(contactModelRet.FirstName, "", contactModelRet.LastName);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.Name, contactService.MakeFullName(contactModelRet.FirstName, "", contactModelRet.LastName)), contactModelRet3.Error);
            }
        }
        [TestMethod]
        public void ContactService_GetContactModelWithFirstLetterDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string FirstLetter = "L";

                List<ContactModel> contactModelList = contactService.GetContactModelWithFirstLetterDB(FirstLetter);
                Assert.IsNotNull(contactModelList);
                Assert.AreEqual(8, contactModelList.Count);
                Assert.AreEqual("Yves", contactModelList[0].FirstName);
                Assert.AreEqual("", contactModelList[0].Initial);
                Assert.AreEqual("Lamontagne", contactModelList[0].LastName);
            }
        }
        [TestMethod]
        public void ContactService_GetContactModelWithFirstLetterDB_FirstLetter_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string FirstLetter = "";

                List<ContactModel> contactModelList = contactService.GetContactModelWithFirstLetterDB(FirstLetter);
                Assert.IsNotNull(contactModelList);
                Assert.AreEqual(1, contactModelList.Count);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FirstLetter), contactModelList[0].Error);
            }
        }
        [TestMethod]
        public void ContactService_GetContactModelWithFirstLetterDB_FirstLetter_TooLong_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string FirstLetter = "LL";

                List<ContactModel> contactModelList = contactService.GetContactModelWithFirstLetterDB(FirstLetter);
                Assert.IsNotNull(contactModelList);
                Assert.AreEqual(1, contactModelList.Count);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.FirstLetter, 1), contactModelList[0].Error);
            }
        }
        [TestMethod]
        public void ContactService_GetContactModelWithMWQMPlanner_ProvincesTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelNB.Error);

                List<ContactModel> contactModelList = contactService.GetContactModelWithMWQMPlanner_ProvincesTVItemIDDB(tvItemModelNB.TVItemID);
                Assert.IsTrue(contactModelList.Where(c => c.FirstName == "Charles" && c.LastName == "LeBlanc").Any());
            }
        }
        [TestMethod]
        public void ContactService_GetContactWithContactIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Contact contact = contactService.GetContactWithContactIDDB(contactModel.ContactID);
                Assert.IsNotNull(contact);

                int ContactID = 0;
                contact = contactService.GetContactWithContactIDDB(ContactID);
                Assert.IsNull(contact);
            }
        }
        [TestMethod]
        public void ContactService_GetContactWithContactIDDB_Bad_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                Contact contact = contactService.GetContactWithContactIDDB(contactModel.ContactID);
                Assert.IsNull(contact);
            }
        }
        [TestMethod]
        public void ContactService_GetContactWithContactTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Contact contact = contactService.GetContactWithContactTVItemIDDB(contactModel.ContactTVItemID);
                Assert.IsNotNull(contact);

                int ContactTVItemID = 0;
                contact = contactService.GetContactWithContactTVItemIDDB(ContactTVItemID);
                Assert.IsNull(contact);

            }
        }
        [TestMethod]
        public void ContactService_GetContactWithEmailDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Contact contact = contactService.GetContactWithEmailDB(contactModel.LoginEmail);
                Assert.AreEqual(contact.ContactID, contactModel.ContactID);
            }
        }
        [TestMethod]
        public void ContactService_GetContactWithEmailDB_Bad_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                contactModel.LoginEmail = "willnotfindthis";
                Contact contact = contactService.GetContactWithEmailDB(contactModel.LoginEmail);
                Assert.IsNull(contact);
            }
        }
        [TestMethod]
        public void ContactService_GetFirstLetterOfLastNameDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                List<string> firstLetterList = contactService.GetFirstLetterOfLastNameDB();
                Assert.IsNotNull(firstLetterList);
                Assert.IsTrue(firstLetterList.Count >= 2);
                Assert.IsTrue(firstLetterList.Where(c => c.ToUpper() == "L").Any());
            }
        }
        [TestMethod]
        public void ContactService_GetResetPasswordWithExpireDate_LocalSmallerThanToday_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModel = new ResetPasswordModel()
                    {
                        Code = "12345678",
                        Email = contactModel.LoginEmail,
                        Password = "Ttttt!3",
                        ConfirmPassword = "Ttttt!3",
                        ExpireDate_Local = DateTime.Now.AddDays(-1)
                    };
                    ResetPasswordModel resetPasswordModelRet = resetPasswordService.PostAddResetPasswordDB(resetPasswordModel);
                    Assert.AreEqual("", resetPasswordModelRet.Error);

                    List<ResetPassword> resetPasswordList = contactService.GetResetPasswordWithExpireDate_LocalSmallerThanToday();
                    Assert.IsNotNull(resetPasswordList);
                    Assert.IsTrue(resetPasswordList.Count > 0);
                }
            }
        }
        [TestMethod]
        public void ContactService_GetResetPasswordWithEmail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModel = new ResetPasswordModel()
                    {
                        Code = "12345678",
                        Email = contactModel.LoginEmail,
                        Password = "Ttttt!3",
                        ConfirmPassword = "Ttttt!3",
                        ExpireDate_Local = DateTime.Now.AddDays(-1)
                    };
                    ResetPasswordModel resetPasswordModelRet = resetPasswordService.PostAddResetPasswordDB(resetPasswordModel);
                    Assert.AreEqual("", resetPasswordModelRet.Error);

                    string LoginEmail = contactModelListGood[0].LoginEmail;
                    List<ResetPassword> resetPasswordList = contactService.GetResetPasswordWithEmail(LoginEmail);
                    Assert.IsNotNull(resetPasswordList);
                    Assert.IsTrue(resetPasswordList.Count > 0);
                }
            }
        }
        #endregion Testing Method public Get

        #region Testing Method public Helper
        [TestMethod]
        public void ContactService_AddTVTypeUserAuthorization_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    ContactModel contactModel = new ContactModel()
                    {
                        FirstName = registerModelUser.FirstName,
                        Initial = registerModelUser.Initial,
                        LastName = registerModelUser.LastName,
                        WebName = registerModelUser.WebName,
                        LoginEmail = registerModelUser.LoginEmail,
                        Id = aspNetUserModel.Id,
                    };

                    string TVText = contactService.CreateTVText(contactModel);
                    Assert.IsTrue(!string.IsNullOrWhiteSpace(TVText));

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                    contactModel.IsNew = true;
                    ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);
                    Assert.AreEqual("", contactModelRet.Error);

                    List<TVTypeUserAuthorizationModel> tvTypeUserAuthorizationModelList = contactService._TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelListWithContactTVItemIDDB(contactModelRet.ContactTVItemID);

                    foreach (TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel in tvTypeUserAuthorizationModelList)
                    {
                        if (tvTypeUserAuthorizationModel.TVType != TVTypeEnum.Root)
                        {
                            TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = contactService._TVTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModel.TVTypeUserAuthorizationID);

                            Assert.AreEqual("", tvTypeUserAuthorizationModelRet.Error);
                        }
                    }
                }

            }
        }
        [TestMethod]
        public void ContactService_ContactTVItemIDIsBeingUsed_Return_False_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int ContactTVItemID = 0;
                    bool retBool = contactService.ContactTVItemIDIsBeingUsed(ContactTVItemID);
                    Assert.AreEqual(false, retBool);
                }
            }
        }
        [TestMethod]
        public void ContactService_ContactTVItemIDIsBeingUsed_UsedIn_MWQMRuns_LabSampleApprovalContactTVItemID_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    TVItemModel tvItemModelContact = contactService._TVItemService.GetTVItemModelWithTVItemIDDB(contactModelRet.ContactTVItemID);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    TVItemModel tvItemModelMWQMRun = randomService.RandomTVItem(TVTypeEnum.MWQMRun);
                    Assert.AreEqual("", tvItemModelMWQMRun.Error);

                    DateTime StartDate = new DateTime(1950, 1, 1);
                    MWQMRunModel mwqmRunModelNew = new MWQMRunModel()
                    {
                        MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID,
                        MWQMRunComment = randomService.RandomString("", 200),
                        SubsectorTVItemID = tvItemModelMWQMRun.ParentID,
                        AnalyzeMethod = AnalyzeMethodEnum.MF,
                        DateTime_Local = randomService.RandomDateTime(),
                        StartDateTime_Local = StartDate,
                        EndDateTime_Local = StartDate.AddHours(2),
                        LabAnalyzeIncubationStartDateTime_Local = randomService.RandomDateTime(),
                        LabReceivedDateTime_Local = randomService.RandomDateTime(),
                        Laboratory = LaboratoryEnum._0,
                        SampleMatrix = SampleMatrixEnum.W,
                        PPT24_mm = randomService.RandomDouble(0, 1000),
                        PPT48_mm = randomService.RandomDouble(0, 1000),
                        PPT72_mm = randomService.RandomDouble(0, 1000),
                        SampleCrewInitials = "sef",
                        SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)randomService.RandomInt(0, 7),
                        SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)randomService.RandomInt(0, 7),
                        SampleStatus = SampleStatusEnum.SampleStatus3,
                        TemperatureControl1_C = randomService.RandomInt(-45, 45),
                        TemperatureControl2_C = randomService.RandomInt(-45, 45),
                        LabRunSampleApprovalDateTime_Local = randomService.RandomDateTime(),
                        LabSampleApprovalContactTVItemID = tvItemModelContact.TVItemID,
                        WaterLevelAtBrook_m = randomService.RandomDouble(0.0, 10.0),
                        WaveHightAtEnd_m = randomService.RandomDouble(0.0, 10.0),
                        WaveHightAtStart_m = randomService.RandomDouble(0.0, 10.0),
                    };

                    MWQMRunModel mwqmRunModel = contactService._MWQMRunService.PostAddMWQMRunDB(mwqmRunModelNew);
                    Assert.AreEqual("", mwqmRunModel.Error);

                    bool retBool = contactService.ContactTVItemIDIsBeingUsed(tvItemModelContact.TVItemID);
                    Assert.AreEqual(true, retBool);
                }
            }
        }
        [TestMethod]
        public void ContactService_ContactTVItemIDIsBeingUsed_UsedIn_PolSourceObservation_ContactTVItemID_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    TVItemModel tvItemModelContact = contactService._TVItemService.GetTVItemModelWithTVItemIDDB(contactModelRet.ContactTVItemID);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    TVItemModel tvItemModelPolSourceSite = randomService.RandomTVItem(TVTypeEnum.PolSourceSite);
                    Assert.AreEqual("", tvItemModelPolSourceSite.Error);

                    DateTime StartDate = new DateTime(1950, 1, 1);
                    PolSourceObservationModel PolSourceObservationModelNew = new PolSourceObservationModel()
                    {
                        PolSourceSiteTVItemID = tvItemModelPolSourceSite.TVItemID,
                        ObservationDate_Local = randomService.RandomDateTime(),
                        Observation_ToBeDeleted = randomService.RandomString("", 50),
                        ContactTVItemID = tvItemModelContact.TVItemID,
                    };

                    PolSourceObservationModel polSourceObservationModel = contactService._PolSourceObservationService.PostAddPolSourceObservationDB(PolSourceObservationModelNew);
                    Assert.AreEqual("", polSourceObservationModel.Error);

                    bool retBool = contactService.ContactTVItemIDIsBeingUsed(tvItemModelContact.TVItemID);
                    Assert.AreEqual(true, retBool);
                }
            }
        }
        [TestMethod]
        public void ContactService_ContactTVItemIDIsBeingUsed_UsedIn_TVItemLinks_FromTVItemID_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    TVItemModel tvItemModelContact = contactService._TVItemService.GetTVItemModelWithTVItemIDDB(contactModelRet.ContactTVItemID);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    TVItemModel tvItemModelMuni = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMuni.Error);

                    TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                    {
                        FromTVItemID = tvItemModelContact.TVItemID,
                        ToTVItemID = tvItemModelMuni.TVItemID,
                        FromTVType = TVTypeEnum.Contact,
                        ToTVType = TVTypeEnum.Municipality,
                        Ordinal = 0,
                        TVLevel = 0,
                        TVPath = "p" + tvItemModelContact.TVItemID + "p" + tvItemModelMuni.TVItemID,
                    };

                    TVItemLinkModel tvItemLinkModel = contactService._TVItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                    Assert.AreEqual("", tvItemLinkModel.Error);

                    bool retBool = contactService.ContactTVItemIDIsBeingUsed(tvItemModelContact.TVItemID);
                    Assert.AreEqual(true, retBool);
                }
            }
        }
        [TestMethod]
        public void ContactService_ContactTVItemIDIsBeingUsed_UsedIn_TVItemLinks_ToTVItemID_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    TVItemModel tvItemModelContact = contactService._TVItemService.GetTVItemModelWithTVItemIDDB(contactModelRet.ContactTVItemID);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    TVItemModel tvItemModelMuni = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMuni.Error);

                    TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                    {
                        FromTVItemID = tvItemModelMuni.TVItemID,
                        ToTVItemID = tvItemModelContact.TVItemID,
                        FromTVType = TVTypeEnum.Municipality,
                        ToTVType = TVTypeEnum.Contact,
                        Ordinal = 0,
                        TVLevel = 0,
                        TVPath = "p" + tvItemModelMuni.TVItemID + "p" + tvItemModelContact.TVItemID,
                    };

                    TVItemLinkModel tvItemLinkModel = contactService._TVItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                    Assert.AreEqual("", tvItemLinkModel.Error);

                    bool retBool = contactService.ContactTVItemIDIsBeingUsed(tvItemModelContact.TVItemID);
                    Assert.AreEqual(true, retBool);
                }
            }
        }
        [TestMethod]
        public void ContactService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                ContactModel contactModel = new ContactModel() { FirstName = "FirstName", Initial = "Init", LastName = "LastName" };

                string retStr = contactService.CreateTVText(contactModel);
                Assert.AreEqual(contactModel.LastName + ", " + contactModel.FirstName + (string.IsNullOrWhiteSpace(contactModel.Initial) ? "" : " " + contactModel.Initial + "."), retStr);
            }
        }
        [TestMethod]
        public void ContactService_CreateUniquePassword_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string UniquePassword = contactService.CreateUniquePassword();
                Assert.AreEqual(12, UniquePassword.Length);
            }
        }
        [TestMethod]
        public void ContactService_CreateUniqueWebName_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string FirstName = "Roger";
                string LastName = "Breau";

                string UniqueWebName = contactService.CreateUniqueWebName(FirstName, LastName);
                Assert.AreEqual("Roger_Breau", UniqueWebName);
            }
        }
        [TestMethod]
        public void ContactService_Init_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                contactService.Init((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
                Assert.IsNotNull(contactService._AspNetUserService);
                Assert.IsNotNull(contactService._TVTypeUserAuthorizationService);
                Assert.IsNotNull(contactService._TVItemUserAuthorizationService);
                Assert.IsNotNull(contactService._TVItemService);
                Assert.IsNotNull(contactService._TVItemService._TVItemLanguageService);
                Assert.IsNotNull(contactService._TVItemLinkService);
                Assert.IsNotNull(contactService._ResetPasswordService);
            }
        }
        [TestMethod]
        public void ContactService_GenerateUniqueCodeForResetPasswordDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int UniqueCodeSize = (int)(new PrivateObject(contactService, "UniqueCodeSize")).Target;
                string UniqueCode = contactService.GenerateUniqueCodeForResetPasswordDB();
                Assert.AreEqual(UniqueCodeSize, UniqueCode.Length);
            }
        }
        [TestMethod]
        public void ContactService_GetBodyForSendEmailWithCode_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string Email = "First.Second@ec.gc.ca";
                string Code = "12345678";

                string retStr = contactService.GetBodyForSendEmailWithCode(Email, Code);
                Assert.AreEqual(ServiceRes.PlsUseFollowingUniqueCodeEtc
                + @"<br />"
                + @"<br />"
                + ServiceRes.YourEmailIs + " " + Email + @"<br />"
                + @"<br />"
                + ServiceRes.CodeIs + " " + Code + @"<br />"
                + @"<br />"
                + ServiceRes.AutoEmailFromServer + @"<br />", retStr);
            }
        }
        [TestMethod]
        public void ContactService_GetBodyOfCreateNewContactAndEmail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string FirstName = "FirstName";
                string Initial = "Init";
                string LastName = "LastName";

                string FullNameLoggedIn = contactService.MakeFullName(contactModel.FirstName, contactModel.Initial, contactModel.LastName);
                string FullNameAdded = contactService.MakeFullName(FirstName, Initial, LastName);

                string retStr = contactService.GetBodyOfCreateNewContactAndEmail(FullNameLoggedIn, FullNameAdded, user.Identity.Name);
                Assert.AreEqual(string.Format(ServiceRes._AddedInWebSiteBy_, @"<b>" + FullNameAdded + "</b>", FullNameLoggedIn + @"<br />"), retStr);
            }
        }
        [TestMethod]
        public void ContactService_GetContactIDFromLoggedInUserDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactID = contactService.GetContactIDFromLoggedInUserDB();
                Assert.AreEqual(contactModel.ContactID, ContactID);
            }
        }
        [TestMethod]
        public void ContactService_GetSubjectOfCreateNewContactAndEmail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string FirstName = "FirstName";
                string Initial = "Init";
                string LastName = "LastName";

                string FullNameLoggedIn = contactService.MakeFullName(contactModel.FirstName, contactModel.Initial, contactModel.LastName);
                string FullNameAdded = contactService.MakeFullName(FirstName, Initial, LastName);

                string retStr = contactService.GetSubjectOfCreateNewContactAndEmail(FullNameLoggedIn, FullNameAdded, user.Identity.Name);
                Assert.AreEqual(string.Format(ServiceRes.YouBeenAddedInWebSiteBy_, FullNameLoggedIn), retStr);
            }
        }
        [TestMethod]
        public void ContactService_MakeFullName_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string FirstName = "FirstName";
                string Initial = "Init";
                string LastName = "LastName";

                string retStr = contactService.MakeFullName(FirstName, Initial, LastName);
                Assert.AreEqual(LastName + ", " + FirstName + (Initial == null ? "" : " " + Initial + "."), retStr);
            }
        }
        [TestMethod]
        public void ContactService_ReturnContactError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string ErrorText = "ErrorText";
                ContactModel contactModelRet = contactService.ReturnContactError(ErrorText);
                Assert.AreEqual(ErrorText, contactModelRet.Error);
            }
        }
        [TestMethod]
        public void ContactService_ReturnRegisterError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string ErrorText = "ErrorText";
                RegisterModel registerModelRet = contactService.ReturnRegisterError(ErrorText);
                Assert.AreEqual(ErrorText, registerModelRet.Error);
            }
        }
        [TestMethod]
        public void ContactService_ReturnResetPasswordErrorr_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string ErrorText = "ErrorText";
                ResetPasswordModel resetPasswordModelRet = contactService.ReturnResetPasswordError(ErrorText);
                Assert.AreEqual(ErrorText, resetPasswordModelRet.Error);
            }
        }
        [TestMethod]
        public void ContactService_SetRegisterModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelNew = new RegisterModel();

                #region Good
                FillRegisterModelPartial(registerModelNew);

                RegisterModel registerModelRet = contactService.SetRegisterModel(registerModelNew);
                Assert.AreEqual(registerModelNew.LoginEmail, registerModelRet.LoginEmail);
                Assert.AreEqual(registerModelNew.FirstName, registerModelRet.FirstName);
                Assert.AreEqual(registerModelNew.LastName, registerModelRet.LastName);
                Assert.IsFalse(string.IsNullOrWhiteSpace(registerModelNew.Password));
                Assert.IsFalse(string.IsNullOrWhiteSpace(registerModelNew.ConfirmPassword));
                Assert.AreEqual(registerModelNew.Password, registerModelRet.ConfirmPassword);
                Assert.IsFalse(string.IsNullOrWhiteSpace(registerModelNew.WebName));
                #endregion Good

                #region Email Empty
                FillRegisterModelPartial(registerModelNew);
                registerModelNew.LoginEmail = "";

                registerModelRet = contactService.SetRegisterModel(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Email), registerModelRet.Error);
                #endregion Email Empty

                #region Email Too Long
                FillRegisterModelPartial(registerModelNew);
                registerModelNew.LoginEmail = "lsefjlisjf.sefloislfjsf.slfisljflsef.hotmail.com";

                registerModelRet = contactService.SetRegisterModel(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, registerModelNew.LoginEmail), registerModelRet.Error);
                #endregion Email Not Well Formed

                #region Email Too Long
                FillRegisterModelPartial(registerModelNew);
                registerModelNew.LoginEmail = (new String("a".ToCharArray()[0], 255)) + randomService.RandomEmail();

                registerModelRet = contactService.SetRegisterModel(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Email, 255), registerModelRet.Error);
                #endregion Email Not Well Formed

                #region FirstName Empty
                FillRegisterModelPartial(registerModelNew);
                registerModelNew.FirstName = "";

                registerModelRet = contactService.SetRegisterModel(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FirstName), registerModelRet.Error);
                #endregion FirstName Empty

                #region LastName Empty
                FillRegisterModelPartial(registerModelNew);
                registerModelNew.LastName = "";

                registerModelRet = contactService.SetRegisterModel(registerModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LastName), registerModelRet.Error);
                #endregion LastName Empty
            }
        }
        [TestMethod]
        public void ContactService_SetRegisterModel_EmailOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelNew = new RegisterModel();

                FillRegisterModelPartial(registerModelNew);

                using (ShimsContext.Create())
                {
                    string ErrorText = "ErrorText";
                    SetupShim();
                    shimContactService.EmailOKString = (a) =>
                    {
                        return ErrorText;
                    };

                    RegisterModel registerModelRet = contactService.SetRegisterModel(registerModelNew);
                    Assert.AreEqual(ErrorText, registerModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_SetRegisterModel_RegisterModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelNew = new RegisterModel();

                FillRegisterModelPartial(registerModelNew);

                using (ShimsContext.Create())
                {
                    string ErrorText = "ErrorText";
                    SetupShim();
                    shimContactService.RegisterModelOKRegisterModel = (a) =>
                    {
                        return ErrorText;
                    };

                    RegisterModel registerModelRet = contactService.SetRegisterModel(registerModelNew);
                    Assert.AreEqual(ErrorText, registerModelRet.Error);
                }
            }
        }
        #endregion Testing Method public Helper

        #region Testing Method public Post
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_Add_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_Modify_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    //fc["FirstName"] = "Unique" + fc["FirstName"];
                    //fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    //fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_ParentTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";
                    fc["ParentTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID), contactModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_FirstName_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "";
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FirstName), contactModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_LastName_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["LastName"] = "";
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LastName), contactModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_LoginEmail_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["LoginEmail"] = "";
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LoginEmail), contactModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_Add_PostLoggedInUserCreateNewUserDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.PostLoggedInUserCreateNewUserDBNewContactModel = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_Add_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_Add_GetTVItemModelWithTVItemIDDB2_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

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

                        ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_Add_GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModel = new ContactModel()
                    {
                        FirstName = fc["FirstName"],
                        Initial = fc["Initial"],
                        LastName = fc["LastName"],
                    };
                    string TVText = contactService.CreateTVText(contactModel);
                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDBInt32Int32 = (a, b) =>
                        {
                            return new TVItemLinkModel() { Error = "" };
                        };

                        ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);

                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, TVText), contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_Add_PostAddTVItemLinkDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.PostAddTVItemLinkDBTVItemLinkModel = (a) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_Modify_GetContactModelWithContactTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.GetContactModelWithContactIDDBInt32 = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_Modify_PostUpdateContactDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.PostUpdateContactDBContactModel = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_Modify_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddOrModifyContactUnderParentTVItemIDDB_Modify_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddUpdateDeleteContactDB_GoodUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string TVText = contactService.MakeFullName(registerModelUser.FirstName, registerModelUser.Initial, registerModelUser.LastName);

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                    contactModel.IsNew = true;
                    ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);
                    Assert.AreEqual("", contactModelRet.Error);
                }

            }
        }
        [TestMethod]
        public void ContactService_PostAddContactDB_ContactModelOK_Not_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string TVText = contactService.MakeFullName(registerModelUser.FirstName, registerModelUser.Initial, registerModelUser.LastName);

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.ContactModelOKContactModel = (a) =>
                        {
                            return ErrorText;
                        };

                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddContactDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string TVText = contactService.MakeFullName(registerModelUser.FirstName, registerModelUser.Initial, registerModelUser.LastName);

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };


                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddContactDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string TVText = contactService.MakeFullName(registerModelUser.FirstName, registerModelUser.Initial, registerModelUser.LastName);

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };


                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        contactModel.IsNew = true;
                        ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddContactDB_FillContactModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string TVText = contactService.MakeFullName(registerModelUser.FirstName, registerModelUser.Initial, registerModelUser.LastName);

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.FillContactContactContactModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };


                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        contactModel.IsNew = true;
                        ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddContactDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string TVText = contactService.MakeFullName(registerModelUser.FirstName, registerModelUser.Initial, registerModelUser.LastName);

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };


                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        contactModel.IsNew = true;
                        ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);

                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddContactDB_Adding_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string TVText = contactService.MakeFullName(registerModelUser.FirstName, registerModelUser.Initial, registerModelUser.LastName);

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimContactService.FillContactContactContactModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        contactModel.IsNew = true;
                        ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);

                        Assert.IsTrue(contactModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddContactDB_AddTVTypeUserAuthorization_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();

                    string TVText = contactService.MakeFullName(registerModelUser.FirstName, registerModelUser.Initial, registerModelUser.LastName);

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.AddTVTypeUserAuthorizationTVTypeUserAuthorization = (a) =>
                        {
                            return ErrorText;
                        };

                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        contactModel.IsNew = true;
                        ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);

                        Assert.IsNotNull(contactModelRet);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddContactDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string TVText = contactService.MakeFullName(registerModelUser.FirstName, registerModelUser.Initial, registerModelUser.LastName);

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);

                    SetupTest(contactModelListBad[0], culture);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                    ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, contactModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddContactDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string TVText = contactService.MakeFullName(registerModelUser.FirstName, registerModelUser.Initial, registerModelUser.LastName);

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);

                    SetupTest(contactModelListGood[2], culture);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                    ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, contactModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddFirstContactDB_GoodUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelFirstUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelFirstUser.LoginEmail, Password = registerModelFirstUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimContactService.GetContactModelCountDB = () =>
                        {
                            return 0;
                        };

                        AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModelNew);
                        Assert.AreEqual("", aspNetUserModel.Error);

                        FillContactModelWithRegisterModel(registerModelFirstUser, aspNetUserModel);

                        TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                        Assert.AreEqual("", tvItemModelRoot.Error);

                        string TVText = contactService.MakeFullName(registerModelFirstUser.FirstName, registerModelFirstUser.Initial, registerModelFirstUser.LastName);

                        TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                        Assert.AreEqual("", tvItemModelContact.Error);

                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        contactModel.IsNew = true;
                        ContactModel contactModelRet = contactService.PostAddFirstContactDB(contactModel);

                        Assert.AreEqual("", contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddFirstContactDB_GetContactModelCountDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelFirstUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelFirstUser.LoginEmail, Password = registerModelFirstUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimContactService.GetContactModelCountDB = () =>
                        {
                            return 1;
                        };

                        AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModelNew);
                        Assert.IsNotNull(aspNetUserModel);
                        Assert.AreEqual(registerModelFirstUser.LoginEmail, aspNetUserModel.Email);

                        FillContactModelWithRegisterModel(registerModelFirstUser, aspNetUserModel);

                        TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                        Assert.AreEqual("", tvItemModelRoot.Error);

                        string TVText = contactService.MakeFullName(registerModelFirstUser.FirstName, registerModelFirstUser.Initial, registerModelFirstUser.LastName);

                        TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                        Assert.AreEqual("", tvItemModelContact.Error);

                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        ContactModel contactModelRet = contactService.PostAddFirstContactDB(contactModel);

                        Assert.IsNotNull(contactModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.ToAddFirst_Requires_TableToBeEmpty, ServiceRes.Contacts), contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddFirstContactDB_ContactModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelFirstUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelFirstUser.LoginEmail, Password = registerModelFirstUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimContactService.GetContactModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimContactService.ContactModelOKContactModel = (a) =>
                        {
                            return ErrorText;
                        };

                        AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModelNew);
                        Assert.IsNotNull(aspNetUserModel);
                        Assert.AreEqual(registerModelFirstUser.LoginEmail, aspNetUserModel.Email);

                        FillContactModelWithRegisterModel(registerModelFirstUser, aspNetUserModel);

                        TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                        Assert.AreEqual("", tvItemModelRoot.Error);

                        string TVText = contactService.MakeFullName(registerModelFirstUser.FirstName, registerModelFirstUser.Initial, registerModelFirstUser.LastName);

                        TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                        Assert.AreEqual("", tvItemModelContact.Error);

                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        ContactModel contactModelRet = contactService.PostAddFirstContactDB(contactModel);

                        Assert.IsNotNull(contactModelRet);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddFirstContactDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelFirstUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelFirstUser.LoginEmail, Password = registerModelFirstUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimContactService.GetContactModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModelNew);
                        Assert.IsNotNull(aspNetUserModel);
                        Assert.AreEqual(registerModelFirstUser.LoginEmail, aspNetUserModel.Email);

                        FillContactModelWithRegisterModel(registerModelFirstUser, aspNetUserModel);

                        TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                        Assert.AreEqual("", tvItemModelRoot.Error);

                        string TVText = contactService.MakeFullName(registerModelFirstUser.FirstName, registerModelFirstUser.Initial, registerModelFirstUser.LastName);

                        TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                        Assert.AreEqual("", tvItemModelContact.Error);

                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        contactModel.IsNew = true;
                        ContactModel contactModelRet = contactService.PostAddFirstContactDB(contactModel);

                        Assert.IsNotNull(contactModelRet);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddFirstContactDB_FillContactModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelFirstUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelFirstUser.LoginEmail, Password = registerModelFirstUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimContactService.GetContactModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimContactService.FillContactContactContactModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModelNew);
                        Assert.IsNotNull(aspNetUserModel);
                        Assert.AreEqual(registerModelFirstUser.LoginEmail, aspNetUserModel.Email);

                        FillContactModelWithRegisterModel(registerModelFirstUser, aspNetUserModel);

                        TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                        Assert.AreEqual("", tvItemModelRoot.Error);

                        string TVText = contactService.MakeFullName(registerModelFirstUser.FirstName, registerModelFirstUser.Initial, registerModelFirstUser.LastName);

                        TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                        Assert.AreEqual("", tvItemModelContact.Error);

                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        contactModel.IsNew = true;
                        ContactModel contactModelRet = contactService.PostAddFirstContactDB(contactModel);

                        Assert.IsNotNull(contactModelRet);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddFirstContactDB_Adding_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelFirstUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelFirstUser.LoginEmail, Password = registerModelFirstUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };

                        AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModelNew);
                        Assert.IsNotNull(aspNetUserModel);
                        Assert.AreEqual(registerModelFirstUser.LoginEmail, aspNetUserModel.Email);


                        shimContactService.GetContactModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimContactService.FillContactContactContactModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };


                        FillContactModelWithRegisterModel(registerModelFirstUser, aspNetUserModel);

                        TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                        Assert.AreEqual("", tvItemModelRoot.Error);

                        string TVText = contactService.MakeFullName(registerModelFirstUser.FirstName, registerModelFirstUser.Initial, registerModelFirstUser.LastName);

                        TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                        Assert.AreEqual("", tvItemModelContact.Error);

                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        contactModel.IsNew = true;
                        ContactModel contactModelRet = contactService.PostAddFirstContactDB(contactModel);

                        Assert.IsNotNull(contactModelRet);
                        Assert.IsTrue(contactModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostAddFirstContactDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelFirstUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelFirstUser.LoginEmail, Password = registerModelFirstUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimContactService.GetContactModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimContactService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModelNew);
                        Assert.IsNotNull(aspNetUserModel);
                        Assert.AreEqual(registerModelFirstUser.LoginEmail, aspNetUserModel.Email);

                        FillContactModelWithRegisterModel(registerModelFirstUser, aspNetUserModel);

                        TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                        Assert.AreEqual("", tvItemModelRoot.Error);

                        string TVText = contactService.MakeFullName(registerModelFirstUser.FirstName, registerModelFirstUser.Initial, registerModelFirstUser.LastName);

                        TVItemModel tvItemModelContact = tvItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                        Assert.AreEqual("", tvItemModelContact.Error);

                        contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                        contactModel.IsNew = true;
                        ContactModel contactModelRet = contactService.PostAddFirstContactDB(contactModel);

                        Assert.IsNotNull(contactModelRet);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);

                    int contactCount = contactService.GetContactModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, contactCount);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(contactModelRet.Error));
                    Assert.AreEqual(newContactModelNew.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(newContactModelNew.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(newContactModelNew.LastName, contactModelRet.LastName);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactDB(contactModelRet.ContactID);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactDB_GetContactWithContactIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);

                    int contactCount = contactService.GetContactModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, contactCount);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(contactModelRet.Error));
                    Assert.AreEqual(newContactModelNew.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(newContactModelNew.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(newContactModelNew.LastName, contactModelRet.LastName);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimContactService.GetContactWithContactIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactDB(contactModelRet.ContactID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Contact), contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);

                    int contactCount = contactService.GetContactModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, contactCount);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(contactModelRet.Error));
                    Assert.AreEqual(newContactModelNew.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(newContactModelNew.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(newContactModelNew.LastName, contactModelRet.LastName);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactDB(contactModelRet.ContactID);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactDB_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);

                    int contactCount = contactService.GetContactModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, contactCount);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(contactModelRet.Error));
                    Assert.AreEqual(newContactModelNew.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(newContactModelNew.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(newContactModelNew.LastName, contactModelRet.LastName);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactDB(contactModelRet.ContactID);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc2);
                    Assert.AreEqual("", contactModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_Good_With_Other_TVItemLink_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fcTel = telServiceTest.FillPostAddOrModifyDBFormCollection();
                    fcTel["TelTVItemID"] = "0";
                    fcTel["TelNumber"] = "23487874";
                    fcTel["ContactTVItemID"] = contactModelRet.ContactTVItemID.ToString();

                    TelModel telModel = contactService._TelService.PostAddOrModifyDB(fcTel);
                    Assert.AreEqual("", telModel.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc2);
                    Assert.AreEqual("", contactModelRet2.Error);
                    List<TVItemLinkModel> tvItemLinkModelList = contactService._TVItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(contactModelRet.ContactTVItemID);
                    Assert.AreEqual(0, tvItemLinkModelList.Count);
                    TVItemModel tvItemModelRet = contactService._TVItemService.GetTVItemModelWithTVItemIDDB(telModel.TelTVItemID);
                    Assert.AreEqual(0, tvItemModelRet.TVItemID);
                    telModel = contactService._TelService.GetTelModelWithTelIDDB(telModel.TelID);
                    Assert.AreEqual(0, telModel.TelID);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc2);

                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_ParentTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", "0");  //, fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc2);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID), contactModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_ContactTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", "0"); // contactModelRet.ContactTVItemID.ToString());

                    ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc2);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID), contactModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_GetTVItemModelWithTVItemIDDB2_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    int Count = 0;
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            Count += 1;
                            if (Count == 1)
                            {
                                return new TVItemModel() { Error = "" };
                            }
                            return new TVItemModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDBInt32Int32 = (a, b) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_GetContactModelWithContactTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.GetContactModelWithContactTVItemIDDBInt32 = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_PostDeleteContactWithContactTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.PostDeleteAspNetUserWithIdDBString = (a) =>
                        {
                            return new AspNetUserModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_ContactBeingUsed_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyContactDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["FirstName"] = "Unique" + fc["FirstName"];
                    fc["LoginEmail"] = "Unique" + fc["LoginEmail"];
                    fc["ContactTVItemID"] = "0";

                    ContactModel contactModelRet = contactService.PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet.Error);

                    TVItemModel tvItemModelContact = contactService._TVItemService.GetTVItemModelWithTVItemIDDB(contactModelRet.ContactTVItemID);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    FormCollection fc2 = new FormCollection();
                    fc2.Add("ParentTVItemID", fc["ParentTVItemID"]);
                    fc2.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());

                    TVItemModel tvItemModelChild = randomService.RandomTVItem(TVTypeEnum.PolSourceSite);
                    Assert.AreEqual("", tvItemModelChild.Error);

                    TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                    {
                        FromTVItemID = tvItemModelChild.TVItemID,
                        ToTVItemID = tvItemModelContact.TVItemID,
                        FromTVType = TVTypeEnum.PolSourceSite,
                        ToTVType = TVTypeEnum.Contact,
                        Ordinal = 0,
                        TVLevel = 0,
                        TVPath = "p" + tvItemModelChild.TVItemID + "p" + tvItemModelContact.TVItemID,
                    };

                    TVItemLinkModel tvItemLinkModel = contactService._TVItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                    Assert.AreEqual("", tvItemLinkModel.Error);

                    ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc2);
                    Assert.AreEqual(string.Format(ServiceRes.Contact_IsBeingUsed, tvItemModelContact.TVText), contactModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactUnderParentTVItemIDDB_ContactBeingNotUsed_NotNew_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                    {
                        FromTVItemID = 1,
                        ToTVItemID = contactModelListGood[2].ContactTVItemID,
                        FromTVType = TVTypeEnum.Root,
                        ToTVType = TVTypeEnum.Contact,
                        Ordinal = 0,
                        TVLevel = 0,
                        TVPath = "p1p" + contactModelListGood[2].ContactTVItemID,
                    };

                    TVItemLinkModel tvItemLinkModel = contactService._TVItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                    Assert.AreEqual("", tvItemLinkModel.Error);

                    FormCollection fc = new FormCollection();
                    fc.Add("ParentTVItemID", "1");
                    fc.Add("ContactTVItemID", contactModelListGood[2].ContactTVItemID.ToString());

                    ContactModel contactModelRet2 = contactService.PostDeleteContactUnderParentTVItemIDDB(fc);
                    Assert.AreEqual("", contactModelRet2.Error);

                    contactModelRet2 = contactService.GetContactModelWithContactTVItemIDDB(contactModelListGood[2].ContactTVItemID);
                    Assert.AreEqual("", contactModelRet2.Error);
                    Assert.AreEqual(contactModelListGood[2].ContactTVItemID, contactModelRet2.ContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactWithContactTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);

                    int contactCount = contactService.GetContactModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, contactCount);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(contactModelRet.Error));
                    Assert.AreEqual(newContactModelNew.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(newContactModelNew.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(newContactModelNew.LastName, contactModelRet.LastName);

                    ContactModel contactModelRet2 = contactService.PostDeleteContactWithContactTVItemIDDB(contactModelRet.ContactTVItemID);
                    Assert.AreEqual("", contactModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactWithContactTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);

                    int contactCount = contactService.GetContactModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, contactCount);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(contactModelRet.Error));
                    Assert.AreEqual(newContactModelNew.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(newContactModelNew.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(newContactModelNew.LastName, contactModelRet.LastName);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactWithContactTVItemIDDB(contactModelRet.ContactTVItemID);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactWithContactTVItemIDDB_GetContactWithContactIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);

                    int contactCount = contactService.GetContactModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, contactCount);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(contactModelRet.Error));
                    Assert.AreEqual(newContactModelNew.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(newContactModelNew.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(newContactModelNew.LastName, contactModelRet.LastName);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimContactService.GetContactWithContactIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactWithContactTVItemIDDB(contactModelRet.ContactTVItemID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Contact), contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostDeleteContactWithContactTVItemIDDB_PostDeleteContactDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);

                    int contactCount = contactService.GetContactModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, contactCount);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(contactModelRet.Error));
                    Assert.AreEqual(newContactModelNew.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(newContactModelNew.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(newContactModelNew.LastName, contactModelRet.LastName);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.PostDeleteContactDBInt32 = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostDeleteContactWithContactTVItemIDDB(contactModelRet.ContactTVItemID);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostLinkParentTVItemIDAndContactTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMuni = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMuni.Error);

                    int ContactTVItemID = contactModelListGood[0].ContactTVItemID;
                    ContactModel contactModelRet2 = contactService.PostLinkParentTVItemIDAndContactTVItemIDDB(tvItemModelMuni.TVItemID, ContactTVItemID);
                    Assert.AreEqual("", contactModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostLinkParentTVItemIDAndContactTVItemIDDB_ParentTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    //                    //TVItemModel tvItemModelMuni = randomService.RandomTVItem(TVTypeEnum.Municipality);

                    //                    //Assert.AreEqual("", tvItemModelMuni.Error);

                    int ParentTVItemID = 0;
                    int ContactTVItemID = contactModelListGood[0].ContactTVItemID;
                    ContactModel contactModelRet2 = contactService.PostLinkParentTVItemIDAndContactTVItemIDDB(ParentTVItemID, ContactTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID), contactModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostLinkParentTVItemIDAndContactTVItemIDDB_ContactTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMuni = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMuni.Error);

                    int ContactTVItemID = 0; // contactModelListGood[0].ContactTVItemID;
                    ContactModel contactModelRet2 = contactService.PostLinkParentTVItemIDAndContactTVItemIDDB(tvItemModelMuni.TVItemID, ContactTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID), contactModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostLinkParentTVItemIDAndContactTVItemIDDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMuni = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMuni.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        int ContactTVItemID = contactModelListGood[0].ContactTVItemID;
                        ContactModel contactModelRet2 = contactService.PostLinkParentTVItemIDAndContactTVItemIDDB(tvItemModelMuni.TVItemID, ContactTVItemID);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostLinkParentTVItemIDAndContactTVItemIDDB_GetTVItemModelWithTVItemIDDB2_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMuni = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMuni.Error);

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

                        int ContactTVItemID = contactModelListGood[0].ContactTVItemID;
                        ContactModel contactModelRet2 = contactService.PostLinkParentTVItemIDAndContactTVItemIDDB(tvItemModelMuni.TVItemID, ContactTVItemID);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostLinkParentTVItemIDAndContactTVItemIDDB_GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMuni = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMuni.Error);

                    ContactModel contactModel = new ContactModel()
                    {
                        FirstName = contactModelListGood[0].FirstName,
                        Initial = contactModelListGood[0].Initial,
                        LastName = contactModelListGood[0].LastName,
                    };

                    string TVText = contactService.CreateTVText(contactModel);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDBInt32Int32 = (a, b) =>
                        {
                            return new TVItemLinkModel() { Error = "" };
                        };

                        int ContactTVItemID = contactModelListGood[0].ContactTVItemID;
                        ContactModel contactModelRet2 = contactService.PostLinkParentTVItemIDAndContactTVItemIDDB(tvItemModelMuni.TVItemID, ContactTVItemID);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, TVText), contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostLinkParentTVItemIDAndContactTVItemIDDB_PostAddTVItemLinkDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMuni = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMuni.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.PostAddTVItemLinkDBTVItemLinkModel = (a) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        int ContactTVItemID = contactModelListGood[0].ContactTVItemID;
                        ContactModel contactModelRet2 = contactService.PostLinkParentTVItemIDAndContactTVItemIDDB(tvItemModelMuni.TVItemID, ContactTVItemID);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostLoggedInUserCreateNewUserDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // Everything OK
                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);

                    int contactCount = contactService.GetContactModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, contactCount);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(contactModelRet.Error));
                    Assert.AreEqual(newContactModelNew.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(newContactModelNew.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(newContactModelNew.LastName, contactModelRet.LastName);

                    ContactModel contactModelRet2 = contactService.GetContactModelWithContactIDDB(contactModelRet.ContactID);
                    Assert.AreEqual(newContactModelNew.LoginEmail, contactModelRet2.LoginEmail);
                    Assert.AreEqual(newContactModelNew.FirstName, contactModelRet2.FirstName);
                    Assert.AreEqual(newContactModelNew.LastName, contactModelRet2.LastName);

                    ContactModel contactModelRet3 = contactService.GetContactModelWithContactTVItemIDDB(contactModelRet.ContactTVItemID);
                    Assert.AreEqual(newContactModelNew.LoginEmail, contactModelRet3.LoginEmail);
                    Assert.AreEqual(newContactModelNew.FirstName, contactModelRet3.FirstName);
                    Assert.AreEqual(newContactModelNew.LastName, contactModelRet3.LastName);

                }

            }
        }
        [TestMethod]
        public void ContactService_PostLoggedInUserCreateNewUserDB_NewContactModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.NewContactModelOKNewContactModel = (a) =>
                        {
                            return ErrorText;
                        };

                        ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }

            }
        }
        [TestMethod]
        public void ContactService_PostLoggedInUserCreateNewUserDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }

            }
        }
        [TestMethod]
        public void ContactService_PostLoggedInUserCreateNewUserDB_GetRootTVItemModelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetRootTVItemModelDB = () =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }

            }
        }
        [TestMethod]
        public void ContactService_PostLoggedInUserCreateNewUserDB_PostAddAspNetUserDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        bool IsShimed = false;

                        shimAspNetUserService.PostAddAspNetUserDBAspNetUserModelBoolean = (a, b) =>
                        {
                            IsShimed = true;
                            return new AspNetUserModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);
                        Assert.IsTrue(IsShimed);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostLoggedInUserCreateNewUserDB_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.CreateTVTextContactModel = (a) =>
                        {
                            return "";
                        };

                        ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), contactModelRet.Error);
                    }
                }

            }
        }
        [TestMethod]
        public void ContactService_PostLoggedInUserCreateNewUserDB_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostLoggedInUserCreateNewUserDB_PostAddContactDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        string ErrorText = "ErrorText";

                        shimContactService.PostAddContactDBContactModel = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostLoggedInUserCreateNewUserDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    NewContactModel newContactModelNew = new NewContactModel();

                    newContactModelNew.LoginEmail = randomService.RandomEmail();
                    newContactModelNew.FirstName = randomService.RandomString("FirstName", 20);
                    newContactModelNew.LastName = randomService.RandomString("LastName", 20);
                    newContactModelNew.Initial = "";

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        string ErrorText = "ErrorText";

                        shimContactService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRegisterNewContactDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = false, EmailValidated = false, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModel = contactService.PostRegisterNewContactDB(registerModelUser);
                    Assert.IsNotNull(contactModel);
                    Assert.AreEqual("", contactModel.Error);
                    Assert.AreEqual(registerModelUser.LoginEmail, contactModel.LoginEmail);
                    Assert.AreEqual(false, contactModel.IsAdmin);
                    Assert.AreEqual(false, contactModel.Disabled);
                    Assert.AreEqual(false, contactModel.EmailValidated);
                    Assert.AreEqual(registerModelUser.FirstName, contactModel.FirstName);
                    Assert.AreEqual(registerModelUser.Initial, contactModel.Initial);
                    Assert.AreEqual(registerModelUser.LastName, contactModel.LastName);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = contactService._TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(contactModel.ContactTVItemID, TVTypeEnum.Root);
                    Assert.AreEqual(contactModel.ContactTVItemID, tvTypeUserAuthorizationModelRet.ContactTVItemID);
                    Assert.AreEqual(TVTypeEnum.Root, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvTypeUserAuthorizationModelRet.TVAuth);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRegisterNewContactDB_RegisterModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = false, EmailValidated = false, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.RegisterModelOKRegisterModel = (a) =>
                        {
                            return ErrorText;
                        };

                        ContactModel contactModel = contactService.PostRegisterNewContactDB(registerModelUser);
                        Assert.AreEqual(ErrorText, contactModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRegisterNewContactDB_PostAddAspNetUserDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.PostAddAspNetUserDBAspNetUserModelBoolean = (a, b) =>
                        {
                            return new AspNetUserModel() { Error = ErrorText };
                        };

                        ContactModel contactModel = contactService.PostRegisterNewContactDB(registerModelUser);
                        Assert.AreEqual(ErrorText, contactModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRegisterNewContactDB_GetRootTVItemModelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetRootTVItemModelDB = () =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        ContactModel contactModel = contactService.PostRegisterNewContactDB(registerModelUser);
                        Assert.AreEqual(ErrorText, contactModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRegisterNewContactDB_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.CreateTVTextContactModel = (a) =>
                        {
                            return "";
                        };

                        ContactModel contactModel = contactService.PostRegisterNewContactDB(registerModelUser);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), contactModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRegisterNewContactDB_FillContact_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.FillContactContactContactModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        ContactModel contactModel = contactService.PostRegisterNewContactDB(registerModelUser);
                        Assert.AreEqual(ErrorText, contactModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRegisterNewContactDB_Register_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.FillContactContactContactModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        ContactModel contactModel = contactService.PostRegisterNewContactDB(registerModelUser);
                        Assert.IsTrue(contactModel.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRegisterNewContactDB_PostAddChildContactTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.InitLanguageEnumIPrincipal = (a, b) =>
                        {
                            SetupTest(contactModelListGood[0], culture);
                        };
                        shimTVItemService.PostAddChildContactTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        ContactModel contactModel = contactService.PostRegisterNewContactDB(registerModelUser);
                        Assert.AreEqual(ErrorText, contactModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRegisterNewContactDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.InitLanguageEnumIPrincipal = (a, b) =>
                        {
                            SetupTest(contactModelListGood[0], culture);
                        };
                        shimContactService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        ContactModel contactModel = contactService.PostRegisterNewContactDB(registerModelUser);
                        Assert.AreEqual(ErrorText, contactModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRegisterNewContactDB_GetContactModelWithContactIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.InitLanguageEnumIPrincipal = (a, b) =>
                        {
                            SetupTest(contactModelListGood[0], culture);
                        };
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = "" };
                        };
                        shimContactService.GetContactModelWithContactIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ContactModel contactModel = contactService.PostRegisterNewContactDB(registerModelUser);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Contact), contactModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRegisterNewContactDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.InitLanguageEnumIPrincipal = (a, b) =>
                        {
                            SetupTest(contactModelListGood[0], culture);
                        };
                        shimContactService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        ContactModel contactModel = contactService.PostRegisterNewContactDB(registerModelUser);
                        Assert.AreEqual(ErrorText, contactModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRemoveUserDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = false, EmailValidated = false, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.PostRegisterNewContactDB(registerModelUser);
                    Assert.IsNotNull(contactModelRet);
                    Assert.AreEqual("", contactModelRet.Error);
                    Assert.AreEqual(registerModelUser.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(false, contactModelRet.IsAdmin);
                    Assert.AreEqual(false, contactModelRet.Disabled);
                    Assert.AreEqual(false, contactModelRet.EmailValidated);
                    Assert.AreEqual(registerModelUser.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(registerModelUser.Initial, contactModelRet.Initial);
                    Assert.AreEqual(registerModelUser.LastName, contactModelRet.LastName);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = contactService._TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(contactModelRet.ContactTVItemID, TVTypeEnum.Root);
                    Assert.AreEqual(contactModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.ContactTVItemID);
                    Assert.AreEqual(TVTypeEnum.Root, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvTypeUserAuthorizationModelRet.TVAuth);

                    SetupTest(contactModelListGood[0], culture);

                    ContactModel contactModelRet2 = contactService.PostRemoveUserDB(contactModelRet.LoginEmail);
                    Assert.IsNotNull(contactModelRet2);
                    Assert.AreEqual("", contactModelRet2.Error);
                    Assert.AreEqual(contactModelRet.LoginEmail, contactModelRet2.LoginEmail);

                    ContactModel contactModelRet3 = contactService.GetContactModelWithLoginEmailDB(contactModelRet.LoginEmail);
                    Assert.IsNotNull(contactModelRet3);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.LoginEmail, contactModelRet.LoginEmail), contactModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRemoveUserDB_CantDeleteOneSelf_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet2 = contactService.PostRemoveUserDB(contactModelListGood[0].LoginEmail);
                    Assert.AreEqual(ServiceRes.CantDeleteOneSelf, contactModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRemoveUserDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = false, EmailValidated = false, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.PostRegisterNewContactDB(registerModelUser);
                    Assert.IsNotNull(contactModelRet);
                    Assert.AreEqual("", contactModelRet.Error);
                    Assert.AreEqual(registerModelUser.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(false, contactModelRet.IsAdmin);
                    Assert.AreEqual(false, contactModelRet.Disabled);
                    Assert.AreEqual(false, contactModelRet.EmailValidated);
                    Assert.AreEqual(registerModelUser.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(registerModelUser.Initial, contactModelRet.Initial);
                    Assert.AreEqual(registerModelUser.LastName, contactModelRet.LastName);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = contactService._TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(contactModelRet.ContactTVItemID, TVTypeEnum.Root);
                    Assert.AreEqual(contactModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.ContactTVItemID);
                    Assert.AreEqual(TVTypeEnum.Root, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvTypeUserAuthorizationModelRet.TVAuth);

                    SetupTest(contactModelListGood[0], culture);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostRemoveUserDB(contactModelRet.LoginEmail);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRemoveUserDB_IsAdministratorDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = false, EmailValidated = false, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.PostRegisterNewContactDB(registerModelUser);
                    Assert.IsNotNull(contactModelRet);
                    Assert.AreEqual("", contactModelRet.Error);
                    Assert.AreEqual(registerModelUser.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(false, contactModelRet.IsAdmin);
                    Assert.AreEqual(false, contactModelRet.Disabled);
                    Assert.AreEqual(false, contactModelRet.EmailValidated);
                    Assert.AreEqual(registerModelUser.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(registerModelUser.Initial, contactModelRet.Initial);
                    Assert.AreEqual(registerModelUser.LastName, contactModelRet.LastName);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = contactService._TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(contactModelRet.ContactTVItemID, TVTypeEnum.Root);
                    Assert.AreEqual(contactModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.ContactTVItemID);
                    Assert.AreEqual(TVTypeEnum.Root, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvTypeUserAuthorizationModelRet.TVAuth);

                    SetupTest(contactModelListGood[0], culture);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.IsAdministratorDBString = (a) =>
                        {
                            return false;
                        };

                        ContactModel contactModelRet2 = contactService.PostRemoveUserDB(contactModelRet.LoginEmail);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ServiceRes.OnlyAdministratorsCanManageUsers, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRemoveUserDB_GetContactLoggedInDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = false, EmailValidated = false, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.PostRegisterNewContactDB(registerModelUser);
                    Assert.IsNotNull(contactModelRet);
                    Assert.AreEqual("", contactModelRet.Error);
                    Assert.AreEqual(registerModelUser.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(false, contactModelRet.IsAdmin);
                    Assert.AreEqual(false, contactModelRet.Disabled);
                    Assert.AreEqual(false, contactModelRet.EmailValidated);
                    Assert.AreEqual(registerModelUser.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(registerModelUser.Initial, contactModelRet.Initial);
                    Assert.AreEqual(registerModelUser.LastName, contactModelRet.LastName);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = contactService._TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(contactModelRet.ContactTVItemID, TVTypeEnum.Root);
                    Assert.AreEqual(contactModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.ContactTVItemID);
                    Assert.AreEqual(TVTypeEnum.Root, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvTypeUserAuthorizationModelRet.TVAuth);

                    SetupTest(contactModelListGood[0], culture);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.GetContactLoggedInDB = () =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostRemoveUserDB(contactModelRet.LoginEmail);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRemoveUserDB_GetContactModelWithLoginEmailDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = false, EmailValidated = false, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.PostRegisterNewContactDB(registerModelUser);
                    Assert.IsNotNull(contactModelRet);
                    Assert.AreEqual("", contactModelRet.Error);
                    Assert.AreEqual(registerModelUser.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(false, contactModelRet.IsAdmin);
                    Assert.AreEqual(false, contactModelRet.Disabled);
                    Assert.AreEqual(false, contactModelRet.EmailValidated);
                    Assert.AreEqual(registerModelUser.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(registerModelUser.Initial, contactModelRet.Initial);
                    Assert.AreEqual(registerModelUser.LastName, contactModelRet.LastName);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = contactService._TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(contactModelRet.ContactTVItemID, TVTypeEnum.Root);
                    Assert.AreEqual(contactModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.ContactTVItemID);
                    Assert.AreEqual(TVTypeEnum.Root, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvTypeUserAuthorizationModelRet.TVAuth);

                    SetupTest(contactModelListGood[0], culture);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.GetContactModelWithLoginEmailDBString = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostRemoveUserDB(contactModelRet.LoginEmail);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRemoveUserDB_GetAspNetUserModelWithEmailDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = false, EmailValidated = false, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.PostRegisterNewContactDB(registerModelUser);
                    Assert.IsNotNull(contactModelRet);
                    Assert.AreEqual("", contactModelRet.Error);
                    Assert.AreEqual(registerModelUser.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(false, contactModelRet.IsAdmin);
                    Assert.AreEqual(false, contactModelRet.Disabled);
                    Assert.AreEqual(false, contactModelRet.EmailValidated);
                    Assert.AreEqual(registerModelUser.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(registerModelUser.Initial, contactModelRet.Initial);
                    Assert.AreEqual(registerModelUser.LastName, contactModelRet.LastName);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = contactService._TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(contactModelRet.ContactTVItemID, TVTypeEnum.Root);
                    Assert.AreEqual(contactModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.ContactTVItemID);
                    Assert.AreEqual(TVTypeEnum.Root, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvTypeUserAuthorizationModelRet.TVAuth);

                    SetupTest(contactModelListGood[0], culture);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.GetAspNetUserModelWithEmailDBString = (a) =>
                        {
                            return new AspNetUserModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostRemoveUserDB(contactModelRet.LoginEmail);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRemoveUserDB_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = false, EmailValidated = false, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.PostRegisterNewContactDB(registerModelUser);
                    Assert.IsNotNull(contactModelRet);
                    Assert.AreEqual("", contactModelRet.Error);
                    Assert.AreEqual(registerModelUser.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(false, contactModelRet.IsAdmin);
                    Assert.AreEqual(false, contactModelRet.Disabled);
                    Assert.AreEqual(false, contactModelRet.EmailValidated);
                    Assert.AreEqual(registerModelUser.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(registerModelUser.Initial, contactModelRet.Initial);
                    Assert.AreEqual(registerModelUser.LastName, contactModelRet.LastName);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = contactService._TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(contactModelRet.ContactTVItemID, TVTypeEnum.Root);
                    Assert.AreEqual(contactModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.ContactTVItemID);
                    Assert.AreEqual(TVTypeEnum.Root, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvTypeUserAuthorizationModelRet.TVAuth);

                    SetupTest(contactModelListGood[0], culture);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostRemoveUserDB(contactModelRet.LoginEmail);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRemoveUserDB_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = false, EmailValidated = false, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.PostRegisterNewContactDB(registerModelUser);
                    Assert.IsNotNull(contactModelRet);
                    Assert.AreEqual("", contactModelRet.Error);
                    Assert.AreEqual(registerModelUser.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(false, contactModelRet.IsAdmin);
                    Assert.AreEqual(false, contactModelRet.Disabled);
                    Assert.AreEqual(false, contactModelRet.EmailValidated);
                    Assert.AreEqual(registerModelUser.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(registerModelUser.Initial, contactModelRet.Initial);
                    Assert.AreEqual(registerModelUser.LastName, contactModelRet.LastName);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = contactService._TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(contactModelRet.ContactTVItemID, TVTypeEnum.Root);
                    Assert.AreEqual(contactModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.ContactTVItemID);
                    Assert.AreEqual(TVTypeEnum.Root, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvTypeUserAuthorizationModelRet.TVAuth);

                    SetupTest(contactModelListGood[0], culture);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostRemoveUserDB(contactModelRet.LoginEmail);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostRemoveUserDB_PostDeleteAspNetUserWithIdDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = false, EmailValidated = false, Disabled = false };

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.PostRegisterNewContactDB(registerModelUser);
                    Assert.IsNotNull(contactModelRet);
                    Assert.AreEqual("", contactModelRet.Error);
                    Assert.AreEqual(registerModelUser.LoginEmail, contactModelRet.LoginEmail);
                    Assert.AreEqual(false, contactModelRet.IsAdmin);
                    Assert.AreEqual(false, contactModelRet.Disabled);
                    Assert.AreEqual(false, contactModelRet.EmailValidated);
                    Assert.AreEqual(registerModelUser.FirstName, contactModelRet.FirstName);
                    Assert.AreEqual(registerModelUser.Initial, contactModelRet.Initial);
                    Assert.AreEqual(registerModelUser.LastName, contactModelRet.LastName);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = contactService._TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(contactModelRet.ContactTVItemID, TVTypeEnum.Root);
                    Assert.AreEqual(contactModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.ContactTVItemID);
                    Assert.AreEqual(TVTypeEnum.Root, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvTypeUserAuthorizationModelRet.TVAuth);

                    SetupTest(contactModelListGood[0], culture);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.PostDeleteAspNetUserWithIdDBString = (a) =>
                        {
                            return new AspNetUserModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostRemoveUserDB(contactModelRet.LoginEmail);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostResetPasswordDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                    Assert.AreEqual("", resetPasswordModelRet.Error);

                    resetPasswordModelRet.Password = contactService.CreateUniquePassword();
                    resetPasswordModelRet.ConfirmPassword = resetPasswordModelRet.Password;

                    ContactModel contactModelRet = contactService.PostResetPasswordDB(resetPasswordModelRet);
                    Assert.AreEqual("", contactModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostResetPasswordDB_ResetPasswordModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                    Assert.AreEqual("", resetPasswordModelRet.Error);

                    ResetPasswordModel resetPasswordModel = new ResetPasswordModel();
                    resetPasswordModel.Password = "new" + resetPasswordModel.Password;
                    resetPasswordModel.ConfirmPassword = resetPasswordModel.Password;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimResetPasswordService.ResetPasswordModelOKResetPasswordModel = (a) =>
                        {
                            return ErrorText;
                        };

                        ContactModel contactModel = contactService.PostResetPasswordDB(resetPasswordModel);
                        Assert.AreEqual(ErrorText, contactModel.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostResetPasswordDB_GetResetPasswordModelListWithCodeAndEmailDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                    Assert.AreEqual("", resetPasswordModelRet.Error);

                    resetPasswordModelRet.Password = contactService.CreateUniquePassword();
                    resetPasswordModelRet.ConfirmPassword = resetPasswordModelRet.Password;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimResetPasswordService.GetResetPasswordModelWithCodeAndEmailDBStringString = (a, b) =>
                        {
                            return new ResetPasswordModel() { Error = ErrorText };
                        };

                        ContactModel contactModel = contactService.PostResetPasswordDB(resetPasswordModelRet);
                        Assert.AreEqual(ErrorText, contactModel.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostResetPasswordDB_PostAddAspNetUserDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                    Assert.AreEqual("", resetPasswordModelRet.Error);

                    resetPasswordModelRet.Password = contactService.CreateUniquePassword();
                    resetPasswordModelRet.ConfirmPassword = resetPasswordModelRet.Password;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.PostAddAspNetUserDBAspNetUserModelBoolean = (a, b) =>
                        {
                            return new AspNetUserModel() { Error = ErrorText };
                        };

                        ContactModel contactModel = contactService.PostResetPasswordDB(resetPasswordModelRet);
                        Assert.AreEqual(ErrorText, contactModel.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostResetPasswordDB_PostDeleteAspNetUserWithIdDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                    Assert.AreEqual("", resetPasswordModelRet.Error);

                    resetPasswordModelRet.Password = contactService.CreateUniquePassword();
                    resetPasswordModelRet.ConfirmPassword = resetPasswordModelRet.Password;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.PostDeleteAspNetUserWithIdDBString = (a) =>
                        {
                            return new AspNetUserModel() { Error = ErrorText };
                        };

                        ContactModel contactModel = contactService.PostResetPasswordDB(resetPasswordModelRet);
                        Assert.AreEqual(ErrorText, contactModel.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostResetPasswordDB_GetAspNetUserModelWithEmailDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                    Assert.AreEqual("", resetPasswordModelRet.Error);

                    resetPasswordModelRet.Password = contactService.CreateUniquePassword();
                    resetPasswordModelRet.ConfirmPassword = resetPasswordModelRet.Password;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.GetAspNetUserModelWithEmailDBString = (a) =>
                        {
                            return new AspNetUserModel() { Error = ErrorText };
                        };

                        ContactModel contactModel = contactService.PostResetPasswordDB(resetPasswordModelRet);
                        Assert.AreEqual(ErrorText, contactModel.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostResetPasswordDB_PostUpdateAspNetUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                    Assert.AreEqual("", resetPasswordModelRet.Error);

                    resetPasswordModelRet.Password = contactService.CreateUniquePassword();
                    resetPasswordModelRet.ConfirmPassword = resetPasswordModelRet.Password;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAspNetUserService.PostUpdateAspNetUserDBAspNetUserModel = (a) =>
                        {
                            return new AspNetUserModel() { Error = ErrorText };
                        };

                        ContactModel contactModel = contactService.PostResetPasswordDB(resetPasswordModelRet);
                        Assert.AreEqual(ErrorText, contactModel.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostResetPasswordDB_PostDeleteResetPasswordDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                    Assert.AreEqual("", resetPasswordModelRet.Error);

                    resetPasswordModelRet.Password = contactService.CreateUniquePassword();
                    resetPasswordModelRet.ConfirmPassword = resetPasswordModelRet.Password;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimResetPasswordService.PostDeleteResetPasswordDBInt32 = (a) =>
                        {
                            return new ResetPasswordModel() { Error = ErrorText };
                        };

                        ContactModel contactModel = contactService.PostResetPasswordDB(resetPasswordModelRet);
                        Assert.AreEqual(ErrorText, contactModel.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetContactDisabledOrEnableForContactTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = 3;

                ContactModel contactModelRet = contactService.GetContactModelWithContactTVItemIDDB(ContactTVItemID);
                Assert.AreEqual("", contactModelRet.Error);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet2 = contactService.PostSetContactDisabledOrEnableForContactTVItemIDDB(ContactTVItemID);
                    Assert.IsNotNull(contactModelRet2);
                    Assert.AreEqual(ContactTVItemID, contactModelRet2.ContactTVItemID);
                    Assert.AreEqual(!contactModelRet.Disabled, contactModelRet2.Disabled);

                    ContactModel contactModelRet3 = contactService.PostSetContactDisabledOrEnableForContactTVItemIDDB(ContactTVItemID);
                    Assert.IsNotNull(contactModelRet3);
                    Assert.AreEqual(ContactTVItemID, contactModelRet3.ContactTVItemID);
                    Assert.AreEqual(!contactModelRet2.Disabled, contactModelRet3.Disabled);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetContactDisabledOrEnableForContactTVItemIDDB_CantDisableOrEnableOneSelf_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = contactModelListGood[0].ContactTVItemID;

                ContactModel contactModelRet = contactService.GetContactModelWithContactTVItemIDDB(ContactTVItemID);
                Assert.AreEqual("", contactModelRet.Error);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet2 = contactService.PostSetContactDisabledOrEnableForContactTVItemIDDB(ContactTVItemID);
                    Assert.IsNotNull(contactModelRet2);
                    Assert.AreEqual(ServiceRes.CantDisableOrEnableOneSelf, contactModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetContactDisabledOrEnableForContactTVItemIDDB_ContactID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = 0;

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet2 = contactService.PostSetContactDisabledOrEnableForContactTVItemIDDB(ContactTVItemID);
                    Assert.IsNotNull(contactModelRet2);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID), contactModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetContactDisabledOrEnableForContactTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = 3;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostSetContactDisabledOrEnableForContactTVItemIDDB(ContactTVItemID);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetContactDisabledOrEnableForContactTVItemIDDB_IsAdministratorDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = 3;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimContactService.IsAdministratorDBString = (a) =>
                        {
                            return false;
                        };

                        ContactModel contactModelRet2 = contactService.PostSetContactDisabledOrEnableForContactTVItemIDDB(ContactTVItemID);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ServiceRes.OnlyAdministratorsCanManageUsers, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetContactDisabledOrEnableForContactTVItemIDDB_GetContactModelWithLoginEmailDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = 3;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.GetContactModelWithLoginEmailDBString = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostSetContactDisabledOrEnableForContactTVItemIDDB(ContactTVItemID);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetContactDisabledOrEnableForContactTVItemIDDB_GetContactWithContactTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = 3;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.GetContactWithContactTVItemIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ContactModel contactModelRet2 = contactService.PostSetContactDisabledOrEnableForContactTVItemIDDB(ContactTVItemID);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.UserAccountIN, ServiceRes.UserInfoID, ContactTVItemID), contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetContactDisabledOrEnableForContactTVItemIDDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = 3;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        ContactModel contactModelRet2 = contactService.PostSetContactDisabledOrEnableForContactTVItemIDDB(ContactTVItemID);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetRemoveProvinceDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    ContactModel contactModelRet = contactService.PostSetRemoveProvinceDB(contactModelListGood[0].ContactTVItemID, tvItemModelNB.TVItemID);
                    Assert.AreEqual("", contactModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetRemoveProvinceDB_GetContactModelWithContactTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.PostSetRemoveProvinceDBInt32Int32 = (a, b) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostSetRemoveProvinceDB(contactModelListGood[0].ContactTVItemID, tvItemModelNB.TVItemID);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetRemoveProvinceDB_PostUpdateContactDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.PostUpdateContactDBContactModel = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostSetRemoveProvinceDB(contactModelListGood[0].ContactTVItemID, tvItemModelNB.TVItemID);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetAddProvinceDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    ContactModel contactModelRet = contactService.PostSetAddProvinceDB(contactModelListGood[0].ContactTVItemID, tvItemModelNB.TVItemID);
                    Assert.AreEqual("", contactModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetAddProvinceDB_GetContactModelWithContactTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.GetContactModelWithContactTVItemIDDBInt32 = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostSetAddProvinceDB(contactModelListGood[0].ContactTVItemID, tvItemModelNB.TVItemID);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostSetAddProvinceDB_PostUpdateContactDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelNB = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelNB.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.PostUpdateContactDBContactModel = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet = contactService.PostSetAddProvinceDB(contactModelListGood[0].ContactTVItemID, tvItemModelNB.TVItemID);
                        Assert.AreEqual(ErrorText, contactModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostTryToSendEmailDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                    Assert.AreEqual("", resetPasswordModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactService_PostTryToSendEmailDB_EmailOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (ShimsContext.Create())
                {
                    SetupShim();
                    string ErrorText = "ErrorText";
                    shimContactService.EmailOKString = (a) =>
                    {
                        return ErrorText;
                    };

                    using (TransactionScope ts = new TransactionScope())
                    {

                        ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                        Assert.AreEqual(ErrorText, resetPasswordModelRet.Error);
                    }
                }

            }
        }
        [TestMethod]
        public void ContactService_PostTryToSendEmailDB_GetContactWithEmailDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (ShimsContext.Create())
                {
                    SetupShim();
                    shimContactService.GetContactWithEmailDBString = (a) =>
                    {
                        return null;
                    };

                    using (TransactionScope ts = new TransactionScope())
                    {
                        ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.Email, contactModelListGood[0].LoginEmail), resetPasswordModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostTryToSendEmailDB_GetResetPasswordWithExpireDate_LocalSmallerThanToday_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (ShimsContext.Create())
                {
                    string ErrorText = "ErrorText";
                    SetupShim();
                    shimContactService.GetResetPasswordWithExpireDate_LocalSmallerThanToday = () =>
                    {
                        return new List<ResetPassword> { new ResetPassword() { ResetPasswordID = 0 } };
                    };
                    shimResetPasswordService.PostDeleteResetPasswordDBInt32 = (a) =>
                    {
                        return new ResetPasswordModel() { Error = ErrorText };
                    };

                    using (TransactionScope ts = new TransactionScope())
                    {
                        ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                        Assert.AreEqual(ErrorText, resetPasswordModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostTryToSendEmailDB_GetResetPasswordWithEmail_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (ShimsContext.Create())
                {
                    string ErrorText = "ErrorText";
                    SetupShim();
                    shimContactService.GetResetPasswordWithEmailString = (a) =>
                    {
                        return new List<ResetPassword> { new ResetPassword() { ResetPasswordID = 0 } };
                    };
                    shimResetPasswordService.PostDeleteResetPasswordDBInt32 = (a) =>
                    {
                        return new ResetPasswordModel() { Error = ErrorText };
                    };

                    using (TransactionScope ts = new TransactionScope())
                    {
                        ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);
                        Assert.AreEqual(ErrorText, resetPasswordModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostTryToSendEmailDB_PostAddResetPasswordDB_Error_Test()
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
                        shimResetPasswordService.PostAddResetPasswordDBResetPasswordModel = (a) =>
                        {
                            return new ResetPasswordModel() { Error = ErrorText };
                        };

                        ResetPasswordModel resetPasswordModelRet = contactService.PostTryToSendEmailDB(contactModelListGood[0].LoginEmail);

                        Assert.AreEqual(ErrorText, resetPasswordModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostUpdateContactDB_ContactModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    ContactModel contactModel = new ContactModel()
                    {
                        FirstName = registerModelUser.FirstName,
                        Initial = registerModelUser.Initial,
                        LastName = registerModelUser.LastName,
                        WebName = registerModelUser.WebName,
                        LoginEmail = registerModelUser.LoginEmail,
                        Id = aspNetUserModel.Id,
                    };

                    string TVText = contactService.CreateTVText(contactModel);
                    Assert.IsTrue(!string.IsNullOrWhiteSpace(TVText));

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                    contactModel.IsNew = true;
                    ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);
                    Assert.AreEqual("", contactModelRet.Error);

                    IPrincipal userNewlyLoggedIn = new GenericPrincipal(new GenericIdentity(contactModelRet.LoginEmail, "Forms"), null);
                    ContactService contactServiceNewlyLoggedIn = new ContactService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userNewlyLoggedIn);

                    using (ShimsContext.Create())
                    {
                        ShimContactService shimContactService2 = new ShimContactService(contactServiceNewlyLoggedIn);
                        string ErrorText = "ErrorText";
                        shimContactService2.ContactModelOKContactModel = (a) =>
                        {
                            return ErrorText;
                        };

                        ContactModel contactModelRet2 = contactServiceNewlyLoggedIn.PostUpdateContactDB(contactModelRet);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostUpdateContactDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RegisterModel registerModelUser = new RegisterModel() { FirstName = "CharlesFirstTest", Initial = "G", LastName = "LeBlanc", WebName = "CharlesFirstText", LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!", ConfirmPassword = "Charles2!", IsAdmin = true, EmailValidated = true, Disabled = false };

                AspNetUserModel aspNetUserModelNew = new AspNetUserModel() { LoginEmail = registerModelUser.LoginEmail, Password = registerModelUser.Password };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = contactService._AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                    Assert.AreEqual("", aspNetUserModel.Error);

                    FillContactModelWithRegisterModel(registerModelUser, aspNetUserModel);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    ContactModel contactModel = new ContactModel()
                    {
                        FirstName = registerModelUser.FirstName,
                        Initial = registerModelUser.Initial,
                        LastName = registerModelUser.LastName,
                        WebName = registerModelUser.WebName,
                        LoginEmail = registerModelUser.LoginEmail,
                        Id = aspNetUserModel.Id,
                    };

                    string TVText = contactService.CreateTVText(contactModel);
                    Assert.IsTrue(!string.IsNullOrWhiteSpace(TVText));

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    contactModel.ContactTVItemID = tvItemModelContact.TVItemID;
                    contactModel.IsNew = true;
                    ContactModel contactModelRet = contactService.PostAddContactDB(contactModel);
                    Assert.IsNotNull(contactModelRet);
                    Assert.AreEqual("", contactModelRet.Error);

                    IPrincipal userNewlyLoggedIn = new GenericPrincipal(new GenericIdentity(contactModelRet.LoginEmail, "Forms"), null);
                    ContactService contactServiceNewlyLoggedIn = new ContactService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userNewlyLoggedIn);

                    using (ShimsContext.Create())
                    {
                        ShimContactService shimContactService2 = new ShimContactService(contactServiceNewlyLoggedIn);
                        string ErrorText = "ErrorText";
                        shimContactService2.ContactModelOKContactModel = (a) =>
                        {
                            return "";
                        };
                        shimContactService2.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactServiceNewlyLoggedIn.PostUpdateContactDB(contactModelRet);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostUpdateContactDB_GetContactWithContactIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        ShimContactService shimContactService2 = new ShimContactService(contactService);
                        //string ErrorText = "ErrorText";
                        shimContactService2.GetContactWithContactIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        contactModel.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(2).ContactTVItemID;
                        ContactModel contactModelRet2 = contactService.PostUpdateContactDB(contactModel);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Contact), contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostUpdateContactDB_FillContactModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        ShimContactService shimContactService2 = new ShimContactService(contactService);
                        string ErrorText = "ErrorText";
                        shimContactService2.FillContactContactContactModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        contactModel.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(2).ContactTVItemID;
                        ContactModel contactModelRet2 = contactService.PostUpdateContactDB(contactModel);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostUpdateContactDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        ShimContactService shimContactService2 = new ShimContactService(contactService);
                        string ErrorText = "ErrorText";
                        shimContactService2.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        contactModel.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(2).ContactTVItemID;
                        ContactModel contactModelRet2 = contactService.PostUpdateContactDB(contactModel);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostUpdateContactDB_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    contactModel = contactService.GetContactModelWithContactTVItemIDDB(2);
                    Assert.AreEqual("", contactModel.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostUpdateContactDB(contactModel);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostUpdateContactDB_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    contactModel = contactService.GetContactModelWithContactTVItemIDDB(2);
                    Assert.AreEqual("", contactModel.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.CreateTVTextContactModel = (a) =>
                        {
                            return "";
                        };

                        ContactModel contactModelRet2 = contactService.PostUpdateContactDB(contactModel);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_PostUpdateContactDB_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    contactModel = contactService.GetContactModelWithContactTVItemIDDB(2);
                    Assert.AreEqual("", contactModel.Error);

                    using (ShimsContext.Create())
                    {
                        ShimContactService shimContactService2 = new ShimContactService(contactService);
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.PostUpdateContactDB(contactModel);
                        Assert.IsNotNull(contactModelRet2);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_ProfileSaveDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.GetContactLoggedInDB();
                    Assert.AreEqual("", contactModelRet.Error);

                    string FirstName = "New Unique First Name";

                    FormCollection fc = new FormCollection();
                    fc.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());
                    fc.Add("FirstName", FirstName);
                    fc.Add("Initial", "GGS");
                    fc.Add("LastName", "New Last Name");

                    ContactModel contactModelRet2 = contactService.ProfileSaveDB(fc);
                    Assert.AreEqual("", contactModelRet2.Error);

                    TVItemModel tvItemModelContact = tvItemService.GetTVItemModelWithTVItemIDDB(contactModelRet.ContactTVItemID);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    string TVText = contactService.CreateTVText(contactModelRet2);
                    Assert.AreEqual(TVText, tvItemModelContact.TVText);
                }
            }
        }
        [TestMethod]
        public void ContactService_ProfileSaveDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.GetContactLoggedInDB();
                    Assert.AreEqual("", contactModelRet.Error);

                    string FirstName = "New Unique First Name";

                    FormCollection fc = new FormCollection();
                    fc.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());
                    fc.Add("FirstName", FirstName);
                    fc.Add("Initial", "GGS");
                    fc.Add("LastName", "New Last Name");

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactModel contactModelRet2 = contactService.ProfileSaveDB(fc);
                        Assert.AreEqual(ErrorText, contactModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactService_ProfileSaveDB_FirstName_Empty_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel contactModelRet = contactService.GetContactLoggedInDB();
                    Assert.AreEqual("", contactModelRet.Error);

                    string FirstName = "";

                    FormCollection fc = new FormCollection();
                    fc.Add("ContactTVItemID", contactModelRet.ContactTVItemID.ToString());
                    fc.Add("FirstName", FirstName);
                    fc.Add("Initial", "GGS");
                    fc.Add("LastName", "New Last Name");

                    ContactModel contactModelRet2 = contactService.ProfileSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FirstName), contactModelRet2.Error);
                }
            }
        }
        #endregion Testing Methods Public Post

        #region Testing Method public search
        [TestMethod]
        public void ContactService_ContactSearchDB_Good_1Term_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddContactListToQuery(culture.TwoLetterISOLanguageName, user);

                    string term = "AAAAA";

                    List<ContactSearchModel> contactSearchModelList = contactService.ContactSearchDB(term);
                    Assert.AreEqual(3, contactSearchModelList.Count);
                }
            }
        }
        [TestMethod]
        public void ContactService_ContactSearchDB_Good_2Term_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddContactListToQuery(culture.TwoLetterISOLanguageName, user);

                    string term = "AAAAA First";

                    List<ContactSearchModel> contactSearchModelList = contactService.ContactSearchDB(term);
                    Assert.AreEqual(10, contactSearchModelList.Count);
                }
            }
        }
        [TestMethod]
        public void ContactService_ContactSearchDB_Good_3Term_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddContactListToQuery(culture.TwoLetterISOLanguageName, user);

                    string term = "AAAAA First Last";

                    List<ContactSearchModel> contactSearchModelList = contactService.ContactSearchDB(term);
                    Assert.AreEqual(10, contactSearchModelList.Count);
                }
            }
        }
        [TestMethod]
        public void ContactService_ContactSearchDB_Good_4Term_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddContactListToQuery(culture.TwoLetterISOLanguageName, user);

                    string term = "AAAAA First Last Name";

                    List<ContactSearchModel> contactSearchModelList = contactService.ContactSearchDB(term);
                    Assert.AreEqual(10, contactSearchModelList.Count);
                }
            }
        }
        [TestMethod]
        public void ContactService_ContactSearchDB_Return_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string term = "NotFoundTerm";

                List<ContactSearchModel> contactSearchModelList = contactService.ContactSearchDB(term);
                Assert.AreEqual(0, contactSearchModelList.Count);

            }
        }
        [TestMethod]
        public void ContactService_ContactSearchDB_Return_Empty2_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string term = "Cha rouge";

                List<ContactSearchModel> contactSearchModelList = contactService.ContactSearchDB(term);
                Assert.AreEqual(4, contactSearchModelList.Count);

            }
        }
        [TestMethod]
        public void ContactService_ContactSearchDB_Return_Empty_IfTermEmpty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                string term = "";

                List<ContactSearchModel> contactSearchModelList = contactService.ContactSearchDB(term);
                Assert.AreEqual(0, contactSearchModelList.Count);

            }
        }
        #endregion Testing Method public search

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions
        private void AddContactListToQuery(string Lang, IPrincipal user)
        {
            List<string> StartWithList = new List<string>() { "AAAAA", "BBBBB", "CCCCC", "DDDDD" };

            foreach (string StartWith in StartWithList)
            {
                for (int i = 0; i < 3; i++)
                {

                    AspNetUserModel aspNetUserModelRet = aspNetUserServiceTest.AddAspNetUserModel();
                    Assert.IsNotNull(aspNetUserModelRet.Id);

                    FillContactModelSpecificStartWith(StartWith, contactModelNew, aspNetUserModelRet);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    string TVText = contactService.CreateTVText(contactModelNew);
                    Assert.IsTrue(!string.IsNullOrWhiteSpace(TVText));

                    TVItemModel tvItemModelContact = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    contactModelNew.ContactTVItemID = tvItemModelContact.TVItemID;
                    contactModelNew.IsNew = true;
                    ContactModel contactModelRet = contactService.PostAddContactDB(contactModelNew);
                    CompareContactModels(contactModelNew, contactModelRet);
                }
            }
        }
        private void CompareContactModels(ContactModel contactModelNew, ContactModel contactModelRet)
        {
            Assert.AreEqual(contactModelNew.LoginEmail, contactModelRet.LoginEmail);
            Assert.AreEqual(contactModelNew.FirstName, contactModelRet.FirstName);
            Assert.AreEqual(contactModelNew.LastName, contactModelRet.LastName);
            Assert.AreEqual(contactModelNew.Initial, contactModelRet.Initial);
            Assert.AreEqual(contactModelNew.WebName, contactModelRet.WebName);
            Assert.AreEqual(contactModelNew.IsAdmin, contactModelRet.IsAdmin);
            Assert.AreEqual(contactModelNew.EmailValidated, contactModelRet.EmailValidated);
            Assert.AreEqual(contactModelNew.Disabled, contactModelRet.Disabled);
        }
        private void FillContactModel(ContactModel contactModel)
        {
            contactModel.Id = randomService.RandomContact().Id;
            contactModel.LoginEmail = randomService.RandomEmail();
            contactModel.FirstName = randomService.RandomString("FirstName", 14);
            contactModel.Initial = randomService.RandomString("Init", 8);
            contactModel.LastName = randomService.RandomString("LastName", 14);
            contactModel.WebName = randomService.RandomString("WebName", 14);
            contactModel.IsAdmin = true;
            contactModel.IsNew = false;
            contactModel.EmailValidated = true;
            contactModel.Disabled = false;
        }
        private void FillContactModelWithRegisterModel(RegisterModel registerModel, AspNetUserModel aspNetUserModel)
        {
            contactModel.Id = aspNetUserModel.Id;
            contactModel.LoginEmail = registerModel.LoginEmail;
            contactModel.FirstName = registerModel.FirstName;
            contactModel.Initial = registerModel.Initial;
            contactModel.LastName = registerModel.LastName;
            contactModel.WebName = registerModel.WebName;
            contactModel.IsAdmin = registerModel.IsAdmin;
            contactModel.IsNew = false;
            contactModel.EmailValidated = registerModel.EmailValidated;
            contactModel.Disabled = registerModel.Disabled;
        }
        private void FillContactModelSpecificStartWith(string StartWith, ContactModel contactModel, AspNetUserModel aspNetUserModel)
        {
            string randInt = randomService.RandomInt(100, 999).ToString();

            contactModel.Id = aspNetUserModel.Id;
            contactModel.LoginEmail = aspNetUserModel.Email;
            contactModel.FirstName = StartWith + "FirstName" + randInt;
            contactModel.LastName = StartWith + "LastName" + randInt;
            contactModel.Initial = StartWith + "Initial" + randInt;
            contactModel.WebName = StartWith + "WebName" + randInt;
            contactModel.IsAdmin = false;
            contactModel.IsNew = false;
            contactModel.EmailValidated = false;
            contactModel.Disabled = false;

            Assert.IsTrue(!string.IsNullOrWhiteSpace(contactModel.Id));
            Assert.IsTrue(contactModel.LoginEmail == aspNetUserModel.Email);
            Assert.IsTrue(contactModel.FirstName == StartWith + "FirstName" + randInt);
            Assert.IsTrue(contactModel.LastName == StartWith + "LastName" + randInt);
            Assert.IsTrue(contactModel.Initial == StartWith + "Initial" + randInt);
            Assert.IsTrue(contactModel.WebName == StartWith + "WebName" + randInt);
            Assert.IsTrue(contactModel.IsAdmin == false);
            Assert.IsTrue(contactModel.IsNew == false);
            Assert.IsTrue(contactModel.EmailValidated == false);
            Assert.IsTrue(contactModel.Disabled == false);
        }
        private void FillNewContactModel(NewContactModel newContactModel)
        {
            newContactModel.LoginEmail = randomService.RandomEmail();
            newContactModel.FirstName = randomService.RandomString("FirstName", 14);
            newContactModel.LastName = randomService.RandomString("LastName", 14);
        }
        private FormCollection FillPostAddOrModifyContactDBFormCollection()
        {
            TVItemModel tvItemModel = contactService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, "Bouctouche", TVTypeEnum.Municipality);

            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return null;

            int ParentTVItemID = tvItemModel.TVItemID;
            int ContactTVItemID = 0;
            string FirstName = randomService.RandomString("", 20);
            string Initial = randomService.RandomString("", 5);
            string LastName = randomService.RandomString("", 20);
            string LoginEmail = randomService.RandomEmail();

            NewContactModel newContactModelNew = new NewContactModel();

            newContactModelNew.LoginEmail = LoginEmail;
            newContactModelNew.FirstName = FirstName;
            newContactModelNew.LastName = LastName;
            newContactModelNew.Initial = Initial;

            ContactModel contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);

            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return null;

            ContactTVItemID = contactModelRet.ContactTVItemID;

            FormCollection fc = new FormCollection();
            fc.Add("ParentTVItemID", ParentTVItemID.ToString());
            fc.Add("ContactTVItemID", ContactTVItemID.ToString());
            fc.Add("FirstName", FirstName);
            fc.Add("Initial", Initial);
            fc.Add("LastName", LastName);
            fc.Add("LoginEmail", LoginEmail);

            return fc;
        }
        private void FillRegisterModel(RegisterModel registerModel)
        {
            registerModel.LoginEmail = randomService.RandomEmail();
            registerModel.FirstName = randomService.RandomString("FirstName", 14);
            registerModel.Initial = randomService.RandomString("Init", 8);
            registerModel.LastName = randomService.RandomString("LastName", 14);
            registerModel.WebName = randomService.RandomString("WebName", 14);
            registerModel.Password = randomService.RandomPassword();
            registerModel.ConfirmPassword = registerModel.Password;
            registerModel.IsAdmin = true;
            registerModel.EmailValidated = true;
            registerModel.Disabled = false;
        }
        private void FillRegisterModelPartial(RegisterModel registerModel)
        {
            registerModel.LoginEmail = randomService.RandomEmail();
            registerModel.FirstName = randomService.RandomString("FirstName", 14);
            registerModel.LastName = randomService.RandomString("LastName", 14);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            if (contactModelToDo == null)
            {
                user = null;
            }
            else
            {
                contactModel = new ContactModel()
                {
                    ContactID = contactModelToDo.ContactID,
                    ContactTVItemID = contactModelToDo.ContactTVItemID,
                    FirstName = contactModelToDo.FirstName,
                    Initial = contactModelToDo.Initial,
                    LastName = contactModelToDo.LastName,
                    WebName = contactModelToDo.WebName,
                    LoginEmail = contactModelToDo.LoginEmail,
                    IsAdmin = contactModelToDo.IsAdmin,
                    EmailValidated = contactModelToDo.EmailValidated,
                    Disabled = contactModelToDo.Disabled
                };
                user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            }
            contactService = new ContactService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            contactModelNew = new ContactModel();
            contact = new Contact();
            resetPasswordService = new ResetPasswordService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            resetPasswordServiceTest = new ResetPasswordServiceTest();
            resetPasswordServiceTest.SetupTest(contactModelToDo, culture);
            aspNetUserService = new AspNetUserService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            aspNetUserServiceTest = new AspNetUserServiceTest();
            aspNetUserServiceTest.SetupTest(contactModelToDo, culture);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            telServiceTest = new TelServiceTest();
            telServiceTest.SetupTest(contactModelToDo, culture);
            emailServiceTest = new EmailServiceTest();
            emailServiceTest.SetupTest(contactModelToDo, culture);
            addressServiceTest = new AddressServiceTest();
            addressServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimContactService = new ShimContactService(contactService);
            shimTVItemService = new ShimTVItemService(contactService._TVItemService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(contactService._TVItemService._TVItemLanguageService);
            shimTVItemLinkService = new ShimTVItemLinkService(contactService._TVItemLinkService);
            shimResetPasswordService = new ShimResetPasswordService(contactService._ResetPasswordService);
            shimAspNetUserService = new ShimAspNetUserService(contactService._AspNetUserService);
            shimTVTypeUserAuthorizationService = new ShimTVTypeUserAuthorizationService(contactService._TVTypeUserAuthorizationService);
        }
        #endregion Functions

    }
}


