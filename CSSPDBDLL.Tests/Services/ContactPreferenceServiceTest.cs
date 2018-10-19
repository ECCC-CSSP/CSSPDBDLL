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
    /// Summary description for ContactPreferenceServiceTest
    /// </summary>
    [TestClass]
    public class ContactPreferenceServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "ContactPreference";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private ContactPreferenceService contactPreferenceService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private ContactPreferenceModel contactPreferenceModelNew { get; set; }
        private ContactPreference contactPreference { get; set; }
        private ShimContactPreferenceService shimContactPreferenceService { get; set; }
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
        public ContactPreferenceServiceTest()
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
        public void ContactPreferenceService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(contactPreferenceService);
                Assert.IsNotNull(contactPreferenceService._TVItemService);
                Assert.IsNotNull(contactPreferenceService._TVItemService._TVItemLanguageService);
                Assert.IsNotNull(contactPreferenceService.db);
                Assert.IsNotNull(contactPreferenceService.LanguageRequest);
                Assert.IsNotNull(contactPreferenceService.User);
                Assert.AreEqual(user.Identity.Name, contactPreferenceService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), contactPreferenceService.LanguageRequest);
            }
        }
        [TestMethod]
        public void ContactPreferenceService_ContactPreferenceModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModel = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModel.Error);

                    contactPreferenceModelNew.ContactPreferenceID = contactPreferenceModel.ContactPreferenceID;

                    #region Good
                    FillContactPreferenceModelNew(contactPreferenceModelNew);

                    string retStr = contactPreferenceService.ContactPreferenceModelOK(contactPreferenceModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region ContactID
                    FillContactPreferenceModelNew(contactPreferenceModelNew);
                    contactPreferenceModelNew.ContactID = 0;

                    retStr = contactPreferenceService.ContactPreferenceModelOK(contactPreferenceModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.ContactID), retStr);

                    FillContactPreferenceModelNew(contactPreferenceModelNew);
                    contactPreferenceModelNew.ContactID = contactPreferenceModel.ContactID;

                    retStr = contactPreferenceService.ContactPreferenceModelOK(contactPreferenceModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion ContactID

                    #region TVType
                    FillContactPreferenceModelNew(contactPreferenceModelNew);
                    contactPreferenceModelNew.TVType = (TVTypeEnum)10000;

                    retStr = contactPreferenceService.ContactPreferenceModelOK(contactPreferenceModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TVType), retStr);

                    FillContactPreferenceModelNew(contactPreferenceModelNew);
                    contactPreferenceModelNew.TVType = TVTypeEnum.Province;

                    retStr = contactPreferenceService.ContactPreferenceModelOK(contactPreferenceModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion TVType

                    #region MarkerSize
                    int min = 1;
                    int max = 200;
                    FillContactPreferenceModelNew(contactPreferenceModelNew);
                    contactPreferenceModelNew.MarkerSize = min - 1;

                    retStr = contactPreferenceService.ContactPreferenceModelOK(contactPreferenceModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MarkerSize, min, max), retStr);

                    FillContactPreferenceModelNew(contactPreferenceModelNew);
                    contactPreferenceModelNew.MarkerSize = max + 1;

                    retStr = contactPreferenceService.ContactPreferenceModelOK(contactPreferenceModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MarkerSize, min, max), retStr);

                    FillContactPreferenceModelNew(contactPreferenceModelNew);
                    contactPreferenceModelNew.MarkerSize = min;

                    retStr = contactPreferenceService.ContactPreferenceModelOK(contactPreferenceModelNew);
                    Assert.IsNotNull("", retStr);

                    FillContactPreferenceModelNew(contactPreferenceModelNew);
                    contactPreferenceModelNew.MarkerSize = max;

                    retStr = contactPreferenceService.ContactPreferenceModelOK(contactPreferenceModelNew);
                    Assert.IsNotNull("", retStr);

                    FillContactPreferenceModelNew(contactPreferenceModelNew);
                    contactPreferenceModelNew.MarkerSize = max - 1;

                    retStr = contactPreferenceService.ContactPreferenceModelOK(contactPreferenceModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion MarkerSize
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_FillContactPreference_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    contactPreferenceModelNew.ContactPreferenceID = contactPreferenceModelRet.ContactPreferenceID;

                    ContactOK contactOK = contactPreferenceService.IsContactOK();

                    string retStr = contactPreferenceService.FillContactPreference(contactPreference, contactPreferenceModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, contactPreference.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = contactPreferenceService.FillContactPreference(contactPreference, contactPreferenceModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, contactPreference.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_GetContactPreferenceModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "ContactPreference", "s");

                    int contactPreferenceCount = contactPreferenceService.GetContactPreferenceModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, contactPreferenceCount);

                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_GetContactPreferenceModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.GetContactPreferenceModelExistDB(contactPreferenceModelRet);
                    Assert.AreEqual("", contactPreferenceModelRet2.Error);

                    contactPreferenceModelRet.ContactID = 0;
                    ContactPreferenceModel contactPreferenceModelRet3 = contactPreferenceService.GetContactPreferenceModelExistDB(contactPreferenceModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.ContactID, ServiceRes.ContactID + "," +
                    ServiceRes.TVType,
                    contactPreferenceModelRet.ContactID.ToString() + "," +
                    contactPreferenceModelRet.TVType.ToString()), contactPreferenceModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_GetContactPreferenceModelWithContactPreferenceIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.GetContactPreferenceModelWithContactPreferenceIDDB(contactPreferenceModelRet.ContactPreferenceID);
                    Assert.IsNotNull(contactPreferenceModelRet2);
                    CompareContactPreferenceModels(contactPreferenceModelRet, contactPreferenceModelRet2);

                    int ContactPreferenceID = 0;
                    ContactPreferenceModel contactPreferenceModelRet3 = contactPreferenceService.GetContactPreferenceModelWithContactPreferenceIDDB(ContactPreferenceID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ContactPreference, ServiceRes.ContactPreferenceID, ContactPreferenceID), contactPreferenceModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_GetContactPreferenceModelListWithContactIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    List<ContactPreferenceModel> contactPreferenceModelList = contactPreferenceService.GetContactPreferenceModelListWithContactIDDB(contactPreferenceModelRet.ContactID);
                    Assert.IsTrue(contactPreferenceModelList.Count > 0);

                    int ContactID = 0;
                    contactPreferenceModelList = contactPreferenceService.GetContactPreferenceModelListWithContactIDDB(ContactID);
                    Assert.IsTrue(contactPreferenceModelList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_GetContactPreferenceWithContactPreferenceIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();

                    ContactPreference contactPreferenceRet2 = contactPreferenceService.GetContactPreferenceWithContactPreferenceIDDB(contactPreferenceModelRet.ContactPreferenceID);
                    Assert.IsNotNull(contactPreferenceRet2);
                    Assert.AreEqual(contactPreferenceModelRet.ContactPreferenceID, contactPreferenceRet2.ContactPreferenceID);

                    ContactPreference contactPreferenceRet3 = contactPreferenceService.GetContactPreferenceWithContactPreferenceIDDB(0);
                    Assert.IsNull(contactPreferenceRet3);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, contactPreferenceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddOrModifyDB_Good_Add_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);
                    fc["ContactPreferenceID"] = "0";

                    ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", contactPreferenceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddOrModifyDB_Good_Add_AlreadyExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", contactPreferenceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddOrModifyDB_Good_Modify_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["MarkerSize"] = "10";

                    ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", contactPreferenceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddOrModifyDB_Add_ContactID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["ContactPreferenceID"] = "0";
                    fc["ContactID"] = "0";

                    ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ContactID), contactPreferenceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddOrModifyDB_Add_TVType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["ContactPreferenceID"] = "0";
                    fc["TVType"] = "0";

                    ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVType), contactPreferenceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddOrModifyDB_Add_MarkerSize_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["ContactPreferenceID"] = "0";
                    fc["MarkerSize"] = "0";

                    ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MarkerSize), contactPreferenceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddOrModifyDB_Add_GetContactModelWithContactIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["ContactPreferenceID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.GetContactModelWithContactIDDBInt32 = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddOrModifyDB_Add_GetContactPreferenceModelExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["ContactPreferenceID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactPreferenceService.GetContactPreferenceModelExistDBContactPreferenceModel = (a) =>
                        {
                            return new ContactPreferenceModel() { Error = ErrorText };
                        };

                        ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddOrModifyDB_Add_PostAddContactPreferenceDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["ContactPreferenceID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactPreferenceService.PostAddContactPreferenceDBContactPreferenceModel = (a) =>
                        {
                            return new ContactPreferenceModel() { Error = ErrorText };
                        };

                        ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddOrModifyDB_Modify_GetContactPreferenceModelExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["TVType"] = ((int)TVTypeEnum.Country).ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactPreferenceService.GetContactPreferenceModelExistDBContactPreferenceModel = (a) =>
                        {
                            return new ContactPreferenceModel() { Error = ErrorText };
                        };

                        ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddOrModifyDB_Modify_PostUpdateContactPreferenceDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["MarkerSize"] = "10";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactPreferenceService.PostUpdateContactPreferenceDBContactPreferenceModel = (a) =>
                        {
                            return new ContactPreferenceModel() { Error = ErrorText };
                        };

                        ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddContactPreferenceDB_ContactPreferenceModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactPreferenceService.ContactPreferenceModelOKContactPreferenceModel = (a) =>
                        {
                            return ErrorText;
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostAddContactPreferenceDB(contactPreferenceModelRet);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddContactPreferenceDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactPreferenceService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostAddContactPreferenceDB(contactPreferenceModelRet);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddContactPreferenceDB_GetContactModelWithContactIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactService.GetContactModelWithContactIDDBInt32 = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostAddContactPreferenceDB(contactPreferenceModelRet);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddContactPreferenceDB_FillContactPreference_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactPreferenceService.FillContactPreferenceContactPreferenceContactPreferenceModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostAddContactPreferenceDB(contactPreferenceModelRet);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddContactPreferenceDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactPreferenceService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostAddContactPreferenceDB(contactPreferenceModelRet);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddContactPreferenceDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimContactPreferenceService.FillContactPreferenceContactPreferenceContactPreferenceModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostAddContactPreferenceDB(contactPreferenceModelRet);
                        Assert.IsTrue(contactPreferenceModelRet2.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddContactPreferenceDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    SetupTest(contactModelListBad[0], culture);

                    ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostAddContactPreferenceDB(contactPreferenceModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, contactPreferenceModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostAddContactPreferenceDB_UserContactPreferenceNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    SetupTest(contactModelListGood[2], culture);

                    ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostAddContactPreferenceDB(contactPreferenceModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, contactPreferenceModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostDeleteContactPreferenceDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactPreferenceService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostDeleteContactPreferenceDB(contactPreferenceModelRet.ContactPreferenceID);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostDeleteContactPreferenceDB_GetContactPreferenceWithContactPreferenceIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimContactPreferenceService.GetContactPreferenceWithContactPreferenceIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostDeleteContactPreferenceDB(contactPreferenceModelRet.ContactPreferenceID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ContactPreference), contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostDeleteContactPreferenceDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactPreferenceService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostDeleteContactPreferenceDB(contactPreferenceModelRet.ContactPreferenceID);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostUpdateContactPreferenceDB_ContactPreferenceModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactPreferenceService.ContactPreferenceModelOKContactPreferenceModel = (a) =>
                        {
                            return ErrorText;
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostUpdateContactPreferenceDB(contactPreferenceModelRet);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostUpdateContactPreferenceDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactPreferenceService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostUpdateContactPreferenceDB(contactPreferenceModelRet);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostUpdateContactPreferenceDB_GetContactPreferenceWithContactPreferenceIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimContactPreferenceService.GetContactPreferenceWithContactPreferenceIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostUpdateContactPreferenceDB(contactPreferenceModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.ContactPreference), contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostUpdateContactPreferenceDB_FillContactPreference_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactPreferenceService.FillContactPreferenceContactPreferenceContactPreferenceModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostUpdateContactPreferenceDB(contactPreferenceModelRet);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ContactPreferenceService_PostUpdateContactPreferenceDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactPreferenceModel contactPreferenceModelRet = AddContactPreferenceModel();
                    Assert.AreEqual("", contactPreferenceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimContactPreferenceService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        ContactPreferenceModel contactPreferenceModelRet2 = contactPreferenceService.PostUpdateContactPreferenceDB(contactPreferenceModelRet);
                        Assert.AreEqual(ErrorText, contactPreferenceModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private ContactPreferenceModel AddContactPreferenceModel()
        {
            Contact contact = (from c in contactPreferenceService.db.Contacts
                               orderby c.ContactID
                               select c).FirstOrDefault();

            Assert.IsNotNull(contact);

            ContactPreferenceModel contactPreferenceModelNew = new ContactPreferenceModel()
            {
                ContactID = contact.ContactID,
                TVType = TVTypeEnum.Province,
                MarkerSize = randomService.RandomInt(1, 50),
            };

            List<ContactPreference> contactPreferenceList = (from c in contactPreferenceService.db.ContactPreferences
                                                   where c.ContactID == contact.ContactID
                                                   select c).ToList();

            foreach (ContactPreference contactPreference in contactPreferenceList)
            {
                contactPreferenceService.db.ContactPreferences.Remove(contactPreference);
            }

            try
            {
                contactPreferenceService.db.SaveChanges();
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }

            ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostAddContactPreferenceDB(contactPreferenceModelNew);
            if (!string.IsNullOrWhiteSpace(contactPreferenceModelRet.Error))
            {
                return contactPreferenceModelRet;
            }

            contactPreferenceModelNew.ContactPreferenceID = contactPreferenceModelRet.ContactPreferenceID;

            CompareContactPreferenceModels(contactPreferenceModelNew, contactPreferenceModelRet);

            return contactPreferenceModelRet;
        }
        //private ContactPreferenceModel UpdateContactPreferenceModel(ContactPreferenceModel contactPreferenceModel)
        //{
        //    Contact contact = (from c in contactPreferenceService.db.Contacts
        //                       orderby c.ContactID
        //                       select c).FirstOrDefault();

        //    Assert.IsNotNull(contact);

        //    ContactPreferenceModel contactPreferenceModelNew = new ContactPreferenceModel()
        //    {
        //        ContactID = contact.ContactID,
        //        TVType = TVTypeEnum.Province,
        //        MarkerSize = randomService.RandomInt(1, 50),
        //    };

        //    ContactPreference contactPreference = (from c in contactPreferenceService.db.ContactPreferences
        //                                           where c.ContactID == contact.ContactID
        //                                           && (c.TVType == (int)TVTypeEnum.Province
        //                                           || c.TVType == (int)TVTypeEnum.Municipality)
        //                                           select c).FirstOrDefault();

        //    if (contactPreference != null)
        //    {
        //        contactPreferenceService.db.ContactPreferences.Remove(contactPreference);
        //        try
        //        {
        //            contactPreferenceService.db.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            Assert.IsTrue(false);
        //        }
        //    }

        //    ContactPreferenceModel contactPreferenceModelRet = contactPreferenceService.PostUpdateContactPreferenceDB(contactPreferenceModel);
        //    if (!string.IsNullOrWhiteSpace(contactPreferenceModelRet.Error))
        //    {
        //        return contactPreferenceModelRet;
        //    }

        //    CompareContactPreferenceModels(contactPreferenceModel, contactPreferenceModelRet);

        //    return contactPreferenceModelRet;
        //}
        private void CompareContactPreferenceModels(ContactPreferenceModel contactPreferenceModelNew, ContactPreferenceModel contactPreferenceModelRet)
        {
            Assert.AreEqual(contactPreferenceModelNew.ContactPreferenceID, contactPreferenceModelRet.ContactPreferenceID);
            Assert.AreEqual(contactPreferenceModelNew.ContactID, contactPreferenceModelRet.ContactID);
            Assert.AreEqual(contactPreferenceModelNew.TVType, contactPreferenceModelRet.TVType);
            Assert.AreEqual(contactPreferenceModelNew.MarkerSize, contactPreferenceModelRet.MarkerSize);
        }
        public FormCollection FillPostAddOrModifyDBFormCollection()
        {
            Contact contact = (from c in contactPreferenceService.db.Contacts
                               orderby c.ContactID
                               select c).FirstOrDefault();

            Assert.IsNotNull(contact);

            ContactPreferenceModel contactPreferenceModelNew = new ContactPreferenceModel()
            {
                ContactID = contact.ContactID,
                TVType = TVTypeEnum.Province,
                MarkerSize = randomService.RandomInt(1, 50),
            };

            List<ContactPreference> contactPreferenceList = (from c in contactPreferenceService.db.ContactPreferences
                                                             where c.ContactID == contact.ContactID
                                                             select c).ToList();

            foreach (ContactPreference contactPreference in contactPreferenceList)
            {
                contactPreferenceService.db.ContactPreferences.Remove(contactPreference);
            }

            try
            {
                contactPreferenceService.db.SaveChanges();
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }

            ContactPreferenceModel ContactPreferenceModel = contactPreferenceService.PostAddContactPreferenceDB(contactPreferenceModelNew);
            if (!string.IsNullOrWhiteSpace(ContactPreferenceModel.Error))
                return null;

            FormCollection fc = new FormCollection();
            fc.Add("ContactPreferenceID", ContactPreferenceModel.ContactPreferenceID.ToString());
            fc.Add("ContactID", ContactPreferenceModel.ContactID.ToString());
            fc.Add("TVType", ((int)ContactPreferenceModel.TVType).ToString());
            fc.Add("MarkerSize", ContactPreferenceModel.MarkerSize.ToString());

            return fc;
        }
        private void FillContactPreferenceModelNew(ContactPreferenceModel contactPreferenceModel)
        {
            contactPreferenceModel.ContactPreferenceID = contactPreferenceModel.ContactPreferenceID;
            contactPreferenceModel.ContactID = randomService.RandomContact().ContactID;
            contactPreferenceModel.TVType = TVTypeEnum.Province;
            contactPreferenceModel.MarkerSize = randomService.RandomInt(3, 20);

            Assert.IsTrue(contactPreferenceModel.ContactPreferenceID != 0);
            Assert.IsTrue(contactPreferenceModel.ContactID > 0);
            Assert.IsTrue(contactPreferenceModel.TVType == TVTypeEnum.Province);
            Assert.IsTrue(contactPreferenceModel.MarkerSize >= 3 && contactPreferenceModel.MarkerSize <= 20);
        }
        //private void FillContactPreferenceModelUpdate(ContactPreferenceModel contactPreferenceModel)
        //{
        //    contactPreferenceModel.ContactPreferenceNumber = randomService.RandomContactPreference();
        //    contactPreferenceModel.ContactPreferenceType = ContactPreferenceTypeEnum.Personal;

        //    Assert.IsTrue(contactPreferenceModel.ContactPreferenceNumber != null);
        //    Assert.IsTrue(contactPreferenceModel.ContactPreferenceType == ContactPreferenceTypeEnum.Personal);
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
            contactPreferenceService = new ContactPreferenceService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            contactPreferenceModelNew = new ContactPreferenceModel();
            contactPreference = new ContactPreference();
        }
        private void SetupShim()
        {
            shimContactPreferenceService = new ShimContactPreferenceService(contactPreferenceService);
            shimTVItemService = new ShimTVItemService(contactPreferenceService._TVItemService);
            shimContactService = new ShimContactService(contactPreferenceService._ContactService);
        }
        #endregion Functions private
    }
}

