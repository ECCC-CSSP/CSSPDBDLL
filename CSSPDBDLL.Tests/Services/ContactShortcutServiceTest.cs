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
using System.Linq;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for ContactShortcutServiceTest
    /// </summary>
    [TestClass]
    public class ContactShortcutServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "ContactShortcut";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private ContactShortcutService contactShortcutService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private ContactShortcutModel contactShortcutModelNew { get; set; }
        private ContactShortcut contactShortcut { get; set; }
        private ShimContactShortcutService shimContactShortcutService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private TVItemService tvItemService { get; set; }
        private ShimContactService shimContactService { get; set; }
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
        public ContactShortcutServiceTest()
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
        public void ContactShortcutService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(contactShortcutService);
                Assert.IsNotNull(contactShortcutService._TVItemService);
                Assert.IsNotNull(contactShortcutService._TVItemService._TVItemLanguageService);
                Assert.IsNotNull(contactShortcutService.db);
                Assert.IsNotNull(contactShortcutService.LanguageRequest);
                Assert.IsNotNull(contactShortcutService.User);
                Assert.AreEqual(user.Identity.Name, contactShortcutService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), contactShortcutService.LanguageRequest);
            }
        }
        [TestMethod]
        public void ContactShortcutService_ContactShortcutModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModel = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModel.Error);

                    contactShortcutModelNew.ContactShortcutID = contactShortcutModel.ContactShortcutID;

                    #region Good
                    FillContactShortcutModelNew(contactShortcutModelNew);

                    string retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region ContactID
                    FillContactShortcutModelNew(contactShortcutModelNew);
                    contactShortcutModelNew.ContactID = 0;

                    retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.ContactID), retStr);

                    FillContactShortcutModelNew(contactShortcutModelNew);
                    contactShortcutModelNew.ContactID = contactShortcutModel.ContactID;

                    retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion ContactID

                    #region ShortCutText
                    int min = 3;
                    int max = 100;
                    FillContactShortcutModelNew(contactShortcutModelNew);
                    contactShortcutModelNew.ShortCutText = randomService.RandomString("", min - 1);

                    retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._MinLengthIs_, ServiceRes.ShortCutText, min), retStr);

                    FillContactShortcutModelNew(contactShortcutModelNew);
                    contactShortcutModelNew.ShortCutText = randomService.RandomString("", max + 1);

                    retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ShortCutText, max), retStr);

                    FillContactShortcutModelNew(contactShortcutModelNew);
                    contactShortcutModelNew.ShortCutText = randomService.RandomString("", min);

                    retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull("", retStr);

                    FillContactShortcutModelNew(contactShortcutModelNew);
                    contactShortcutModelNew.ShortCutText = randomService.RandomString("", max);

                    retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull("", retStr);

                    FillContactShortcutModelNew(contactShortcutModelNew);
                    contactShortcutModelNew.ShortCutText = randomService.RandomString("", max - 1);

                    retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion ShortCutText

                    #region ShortCutAddress
                    min = 3;
                    max = 200;
                    FillContactShortcutModelNew(contactShortcutModelNew);
                    contactShortcutModelNew.ShortCutAddress = randomService.RandomString("", min - 1);

                    retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._MinLengthIs_, ServiceRes.ShortCutAddress, min), retStr);

                    FillContactShortcutModelNew(contactShortcutModelNew);
                    contactShortcutModelNew.ShortCutAddress = randomService.RandomString("", max + 1);

                    retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ShortCutAddress, max), retStr);

                    FillContactShortcutModelNew(contactShortcutModelNew);
                    contactShortcutModelNew.ShortCutAddress = randomService.RandomString("", min);

                    retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull("", retStr);

                    FillContactShortcutModelNew(contactShortcutModelNew);
                    contactShortcutModelNew.ShortCutAddress = randomService.RandomString("", max);

                    retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull("", retStr);

                    FillContactShortcutModelNew(contactShortcutModelNew);
                    contactShortcutModelNew.ShortCutAddress = randomService.RandomString("", max - 1);

                    retStr = contactShortcutService.ContactShortcutModelOK(contactShortcutModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion ShortCutAddress
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_FillContactShortcut_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    contactShortcutModelNew.ContactShortcutID = contactShortcutModelRet.ContactShortcutID;

                    ContactOK contactOK = contactShortcutService.IsContactOK();

                    string retStr = contactShortcutService.FillContactShortcut(contactShortcut, contactShortcutModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, contactShortcut.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = contactShortcutService.FillContactShortcut(contactShortcut, contactShortcutModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, contactShortcut.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_GetContactShortcutModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "ContactShortcut", "s");

                    int contactShortcutCount = contactShortcutService.GetContactShortcutModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, contactShortcutCount);

                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_GetContactShortcutModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.GetContactShortcutModelExistDB(contactShortcutModelRet);
                    Assert.AreEqual("", contactShortcutModelRet2.Error);

                    contactShortcutModelRet.ContactID = 0;
                    ContactShortcutModel contactShortcutModelRet3 = contactShortcutService.GetContactShortcutModelExistDB(contactShortcutModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ContactID, 
                    ServiceRes.ContactID + "," +
                    ServiceRes.ShortCutText,
                    contactShortcutModelRet.ContactID.ToString() + "," +
                    contactShortcutModelRet.ShortCutText), contactShortcutModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_GetContactShortcutModelWithContactShortcutIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.GetContactShortcutModelWithContactShortcutIDDB(contactShortcutModelRet.ContactShortcutID);
                    Assert.IsNotNull(contactShortcutModelRet2);
                    CompareContactShortcutModels(contactShortcutModelRet, contactShortcutModelRet2);

                    int ContactShortcutID = 0;
                    ContactShortcutModel contactShortcutModelRet3 = contactShortcutService.GetContactShortcutModelWithContactShortcutIDDB(ContactShortcutID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ContactShortcut, ServiceRes.ContactShortcutID, ContactShortcutID), contactShortcutModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_GetContactShortcutModelListWithContactIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    List<ContactShortcutModel> contactShortcutModelList = contactShortcutService.GetContactShortcutModelListWithContactIDDB(contactShortcutModelRet.ContactID);
                    Assert.IsTrue(contactShortcutModelList.Count > 0);

                    int ContactID = 0;
                    contactShortcutModelList = contactShortcutService.GetContactShortcutModelListWithContactIDDB(ContactID);
                    Assert.IsTrue(contactShortcutModelList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_GetContactShortcutWithContactShortcutIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();

                    ContactShortcut contactShortcutRet2 = contactShortcutService.GetContactShortcutWithContactShortcutIDDB(contactShortcutModelRet.ContactShortcutID);
                    Assert.IsNotNull(contactShortcutRet2);
                    Assert.AreEqual(contactShortcutModelRet.ContactShortcutID, contactShortcutRet2.ContactShortcutID);

                    ContactShortcut contactShortcutRet3 = contactShortcutService.GetContactShortcutWithContactShortcutIDDB(0);
                    Assert.IsNull(contactShortcutRet3);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    ContactShortcutModel contactShortcutModelRet = contactShortcutService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, contactShortcutModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddOrModifyDB_Good_Add_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["ContactShortcutID"] = "0";

                    ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", contactShortcutModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddOrModifyDB_Good_Add_AlreadyExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", contactShortcutModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddOrModifyDB_Good_Modify_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["MarkerSize"] = "10";

                    ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", contactShortcutModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddOrModifyDB_Add_ContactID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["ContactShortcutID"] = "0";
                    fc["ContactID"] = "0";

                    ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ContactID), contactShortcutModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddOrModifyDB_Add_ShortCutText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["ContactShortcutID"] = "0";
                    fc["ShortCutText"] = "";

                    ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ShortCutText), contactShortcutModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddOrModifyDB_Add_ShortCutAddress_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["ContactShortcutID"] = "0";
                    fc["ShortCutAddress"] = "";

                    ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ShortCutAddress), contactShortcutModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddOrModifyDB_Add_GetContactModelWithContactIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["ContactShortcutID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.GetContactModelWithContactIDDBInt32 = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddOrModifyDB_Add_GetContactShortcutModelExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["ContactShortcutID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactShortcutService.GetContactShortcutModelExistDBContactShortcutModel = (a) =>
                        {
                            return new ContactShortcutModel() { Error = ErrorText };
                        };

                        ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddOrModifyDB_Add_PostAddContactShortcutDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["ContactShortcutID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactShortcutService.PostAddContactShortcutDBContactShortcutModel = (a) =>
                        {
                            return new ContactShortcutModel() { Error = ErrorText };
                        };

                        ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddOrModifyDB_Modify_GetContactShortcutModelExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactShortcutService.GetContactShortcutModelExistDBContactShortcutModel = (a) =>
                        {
                            return new ContactShortcutModel() { Error = ErrorText };
                        };

                        ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddOrModifyDB_Modify_PostUpdateContactShortcutDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactShortcutService.PostUpdateContactShortcutDBContactShortcutModel = (a) =>
                        {
                            return new ContactShortcutModel() { Error = ErrorText };
                        };

                        ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddContactShortcutDB_ContactShortcutModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactShortcutService.ContactShortcutModelOKContactShortcutModel = (a) =>
                        {
                            return ErrorText;
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostAddContactShortcutDB(contactShortcutModelRet);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddContactShortcutDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactShortcutService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostAddContactShortcutDB(contactShortcutModelRet);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddContactShortcutDB_GetContactModelWithContactIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.GetContactModelWithContactIDDBInt32 = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostAddContactShortcutDB(contactShortcutModelRet);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddContactShortcutDB_FillContactShortcut_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactShortcutService.FillContactShortcutContactShortcutContactShortcutModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostAddContactShortcutDB(contactShortcutModelRet);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddContactShortcutDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactShortcutService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostAddContactShortcutDB(contactShortcutModelRet);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddContactShortcutDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimContactShortcutService.FillContactShortcutContactShortcutContactShortcutModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostAddContactShortcutDB(contactShortcutModelRet);
                        Assert.IsTrue(contactShortcutModelRet2.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddContactShortcutDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    SetupTest(contactModelListBad[0], culture);

                    ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostAddContactShortcutDB(contactShortcutModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, contactShortcutModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostAddContactShortcutDB_UserContactShortcutNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    SetupTest(contactModelListGood[2], culture);

                    ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostAddContactShortcutDB(contactShortcutModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, contactShortcutModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostDeleteContactShortcutDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactShortcutService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostDeleteContactShortcutDB(contactShortcutModelRet.ContactShortcutID);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostDeleteContactShortcutDB_GetContactShortcutWithContactShortcutIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimContactShortcutService.GetContactShortcutWithContactShortcutIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostDeleteContactShortcutDB(contactShortcutModelRet.ContactShortcutID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ContactShortcut), contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostDeleteContactShortcutDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactShortcutService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostDeleteContactShortcutDB(contactShortcutModelRet.ContactShortcutID);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostUpdateContactShortcutDB_ContactShortcutModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactShortcutService.ContactShortcutModelOKContactShortcutModel = (a) =>
                        {
                            return ErrorText;
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostUpdateContactShortcutDB(contactShortcutModelRet);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostUpdateContactShortcutDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactShortcutService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostUpdateContactShortcutDB(contactShortcutModelRet);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostUpdateContactShortcutDB_GetContactShortcutWithContactShortcutIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimContactShortcutService.GetContactShortcutWithContactShortcutIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostUpdateContactShortcutDB(contactShortcutModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.ContactShortcut), contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostUpdateContactShortcutDB_FillContactShortcut_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactShortcutService.FillContactShortcutContactShortcutContactShortcutModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostUpdateContactShortcutDB(contactShortcutModelRet);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactShortcutService_PostUpdateContactShortcutDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactShortcutModel contactShortcutModelRet = AddContactShortcutModel();
                    Assert.AreEqual("", contactShortcutModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactShortcutService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        ContactShortcutModel contactShortcutModelRet2 = contactShortcutService.PostUpdateContactShortcutDB(contactShortcutModelRet);
                        Assert.AreEqual(ErrorText, contactShortcutModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private ContactShortcutModel AddContactShortcutModel()
        {
            Contact contact = (from c in contactShortcutService.db.Contacts
                               orderby c.ContactID
                               select c).FirstOrDefault();

            Assert.IsNotNull(contact);

            List<ContactShortcut> contactShortcutList = (from c in contactShortcutService.db.ContactShortcuts
                                                         where c.ContactID == contact.ContactID
                                                         select c).ToList();

            foreach (ContactShortcut contactShortcut in contactShortcutList)
            {
                contactShortcutService.db.ContactShortcuts.Remove(contactShortcut);
            }

            try
            {
                contactShortcutService.db.SaveChanges();
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }

            ContactShortcutModel contactShortcutModelNew = new ContactShortcutModel()
            {
                ContactID = contact.ContactID,
                ShortCutText = randomService.RandomString("", 30),
                ShortCutAddress = randomService.RandomString("", 30),
            };

            ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostAddContactShortcutDB(contactShortcutModelNew);
            if (!string.IsNullOrWhiteSpace(contactShortcutModelRet.Error))
            {
                return contactShortcutModelRet;
            }

            contactShortcutModelNew.ContactShortcutID = contactShortcutModelRet.ContactShortcutID;

            CompareContactShortcutModels(contactShortcutModelNew, contactShortcutModelRet);

            return contactShortcutModelRet;
        }
        //private ContactShortcutModel UpdateContactShortcutModel(ContactShortcutModel contactShortcutModel)
        //{
        //    Contact contact = (from c in contactShortcutService.db.Contacts
        //                       orderby c.ContactID
        //                       select c).FirstOrDefault();

        //    Assert.IsNotNull(contact);

        //    ContactShortcutModel contactShortcutModelNew = new ContactShortcutModel()
        //    {
        //        ContactID = contact.ContactID,
        //        TVType = TVTypeEnum.Province,
        //        MarkerSize = randomService.RandomInt(1, 50),
        //    };

        //    ContactShortcut contactShortcut = (from c in contactShortcutService.db.ContactShortcuts
        //                                           where c.ContactID == contact.ContactID
        //                                           && (c.TVType == (int)TVTypeEnum.Province
        //                                           || c.TVType == (int)TVTypeEnum.Municipality)
        //                                           select c).FirstOrDefault();

        //    if (contactShortcut != null)
        //    {
        //        contactShortcutService.db.ContactShortcuts.Remove(contactShortcut);
        //        try
        //        {
        //            contactShortcutService.db.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            Assert.IsTrue(false);
        //        }
        //    }

        //    ContactShortcutModel contactShortcutModelRet = contactShortcutService.PostUpdateContactShortcutDB(contactShortcutModel);
        //    if (!string.IsNullOrWhiteSpace(contactShortcutModelRet.Error))
        //    {
        //        return contactShortcutModelRet;
        //    }

        //    CompareContactShortcutModels(contactShortcutModel, contactShortcutModelRet);

        //    return contactShortcutModelRet;
        //}
        private void CompareContactShortcutModels(ContactShortcutModel contactShortcutModelNew, ContactShortcutModel contactShortcutModelRet)
        {
            Assert.AreEqual(contactShortcutModelNew.ContactShortcutID, contactShortcutModelRet.ContactShortcutID);
            Assert.AreEqual(contactShortcutModelNew.ContactID, contactShortcutModelRet.ContactID);
            Assert.AreEqual(contactShortcutModelNew.ShortCutText, contactShortcutModelRet.ShortCutText);
            Assert.AreEqual(contactShortcutModelNew.ShortCutAddress, contactShortcutModelRet.ShortCutAddress);
        }
        public FormCollection FillPostAddOrModifyDBFormCollection()
        {
            Contact contact = (from c in contactShortcutService.db.Contacts
                               orderby c.ContactID
                               select c).FirstOrDefault();

            Assert.IsNotNull(contact);

            List<ContactShortcut> contactShortcutList = (from c in contactShortcutService.db.ContactShortcuts
                                                         where c.ContactID == contact.ContactID
                                                         select c).ToList();

            foreach (ContactShortcut contactShortcut in contactShortcutList)
            {
                contactShortcutService.db.ContactShortcuts.Remove(contactShortcut);
            }

            try
            {
                contactShortcutService.db.SaveChanges();
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }

            ContactShortcutModel contactShortcutModelNew = new ContactShortcutModel()
            {
                ContactID = contact.ContactID,
                ShortCutText = randomService.RandomString("", 30),
                ShortCutAddress = randomService.RandomString("", 30),
            };

            ContactShortcutModel ContactShortcutModel = contactShortcutService.PostAddContactShortcutDB(contactShortcutModelNew);
            if (!string.IsNullOrWhiteSpace(ContactShortcutModel.Error))
                return null;

            FormCollection fc = new FormCollection();
            fc.Add("ContactShortcutID", ContactShortcutModel.ContactShortcutID.ToString());
            fc.Add("ContactID", ContactShortcutModel.ContactID.ToString());
            fc.Add("ShortCutText", ContactShortcutModel.ShortCutText);
            fc.Add("ShortCutAddress", ContactShortcutModel.ShortCutAddress);

            return fc;
        }
        private void FillContactShortcutModelNew(ContactShortcutModel contactShortcutModel)
        {
            contactShortcutModel.ContactShortcutID = contactShortcutModel.ContactShortcutID;
            contactShortcutModel.ContactID = randomService.RandomContact().ContactID;
            contactShortcutModel.ShortCutText = randomService.RandomString("", 30);
            contactShortcutModel.ShortCutAddress = randomService.RandomString("", 30);

            Assert.IsTrue(contactShortcutModel.ContactShortcutID != 0);
            Assert.IsTrue(contactShortcutModel.ContactID > 0);
            Assert.IsTrue(contactShortcutModel.ShortCutText.Length == 30);
            Assert.IsTrue(contactShortcutModel.ShortCutAddress.Length == 30);
        }
        //private void FillContactShortcutModelUpdate(ContactShortcutModel contactShortcutModel)
        //{
        //    contactShortcutModel.ContactShortcutNumber = randomService.RandomContactShortcut();
        //    contactShortcutModel.ContactShortcutType = ContactShortcutTypeEnum.Personal;

        //    Assert.IsTrue(contactShortcutModel.ContactShortcutNumber != null);
        //    Assert.IsTrue(contactShortcutModel.ContactShortcutType == ContactShortcutTypeEnum.Personal);
        //}
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
            contactShortcutService = new ContactShortcutService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            contactShortcutModelNew = new ContactShortcutModel();
            contactShortcut = new ContactShortcut();
        }
        private void SetupShim()
        {
            shimContactShortcutService = new ShimContactShortcutService(contactShortcutService);
            shimTVItemService = new ShimTVItemService(contactShortcutService._TVItemService);
            shimContactService = new ShimContactService(contactShortcutService._ContactService);
        }
        #endregion Functions private
    }
}

