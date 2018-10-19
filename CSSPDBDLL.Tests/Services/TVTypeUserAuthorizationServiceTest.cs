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
using CSSPWebToolsDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Threading;
using System.Globalization;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for TVTypeUserAuthorizationServiceTest
    /// </summary>
    [TestClass]
    public class TVTypeUserAuthorizationServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "TVTypeUserAuthorization";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private TVTypeUserAuthorizationService tvTypeUserAuthorizationService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelNew { get; set; }
        private TVTypeUserAuthorization tvTypeUserAuthorization { get; set; }
        private ShimTVTypeUserAuthorizationService shimTVTypeUserAuthorizationService { get; set; }
        private ShimContactService shimContactService { get; set; }
        private ContactService contactService { get; set; }
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
        public TVTypeUserAuthorizationServiceTest()
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

        #region Testing Methods
        [TestMethod]
        public void TVTypeUserAuthorizationService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(tvTypeUserAuthorizationService);
                Assert.IsNotNull(tvTypeUserAuthorizationService.db);
                Assert.IsNotNull(tvTypeUserAuthorizationService.LanguageRequest);
                Assert.IsNotNull(tvTypeUserAuthorizationService.User);
                Assert.AreEqual(user.Identity.Name, tvTypeUserAuthorizationService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), tvTypeUserAuthorizationService.LanguageRequest);
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_TVTypeUserAuthorizationModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);
                    Assert.AreEqual("", tvTypeUserAuthorizationModelRet.Error);

                    #region Good
                    tvTypeUserAuthorizationModelNew.ContactTVItemID = tvTypeUserAuthorizationModelRet.ContactTVItemID;
                    FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);

                    string retStr = tvTypeUserAuthorizationService.TVTypeUserAuthorizationModelOK(tvTypeUserAuthorizationModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region ContactID
                    FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                    tvTypeUserAuthorizationModelNew.ContactTVItemID = 0;

                    retStr = tvTypeUserAuthorizationService.TVTypeUserAuthorizationModelOK(tvTypeUserAuthorizationModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.ContactID), retStr);

                    tvTypeUserAuthorizationModelNew.ContactTVItemID = tvTypeUserAuthorizationModelRet.ContactTVItemID;
                    FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);

                    retStr = tvTypeUserAuthorizationService.TVTypeUserAuthorizationModelOK(tvTypeUserAuthorizationModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion ContactID

                    #region TVType
                    FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                    tvTypeUserAuthorizationModelNew.TVType = (TVTypeEnum)1000;

                    retStr = tvTypeUserAuthorizationService.TVTypeUserAuthorizationModelOK(tvTypeUserAuthorizationModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TVType), retStr);

                    FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                    tvTypeUserAuthorizationModelNew.TVType = TVTypeEnum.Municipality;

                    retStr = tvTypeUserAuthorizationService.TVTypeUserAuthorizationModelOK(tvTypeUserAuthorizationModelNew);
                    Assert.IsNotNull("", retStr);

                    #endregion TVType

                    #region TVAuth
                    FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                    tvTypeUserAuthorizationModelNew.TVAuth = (TVAuthEnum)1000;

                    retStr = tvTypeUserAuthorizationService.TVTypeUserAuthorizationModelOK(tvTypeUserAuthorizationModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TVAuth), retStr);

                    FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                    tvTypeUserAuthorizationModelNew.TVAuth = TVAuthEnum.Create;

                    retStr = tvTypeUserAuthorizationService.TVTypeUserAuthorizationModelOK(tvTypeUserAuthorizationModelNew);
                    Assert.IsNotNull("", retStr);

                    #endregion TVAuth
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_FillTVTypeUserAuthorization_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);
                    Assert.AreEqual("", tvTypeUserAuthorizationModelRet.Error);

                    ContactOK contactOK = tvTypeUserAuthorizationService.IsContactOK();

                    TVTypeUserAuthorization tvTypeUserAuthorizationNew = new TVTypeUserAuthorization();

                    string retStr = tvTypeUserAuthorizationService.FillTVTypeUserAuthorization(tvTypeUserAuthorizationNew, tvTypeUserAuthorizationModelRet, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, tvTypeUserAuthorizationNew.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = tvTypeUserAuthorizationService.FillTVTypeUserAuthorization(tvTypeUserAuthorizationNew, tvTypeUserAuthorizationModelRet, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, tvTypeUserAuthorizationNew.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_GetTVTypeUserAuthorizationModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    int tvTypeUserAuthorizationCount = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, tvTypeUserAuthorizationCount);

                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_GetTVTypeUserAuthorizationModelListDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    List<TVTypeUserAuthorizationModel> tvTypeUserAuthorizationModel = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelListDB();
                    Assert.IsNotNull(tvTypeUserAuthorizationModel);
                    Assert.IsTrue(tvTypeUserAuthorizationModel.Count > 0);
                    Assert.IsTrue(tvTypeUserAuthorizationModel.Where(c => c.ContactTVItemID == tvTypeUserAuthorizationModelRet.ContactTVItemID).Any());
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_GetTVTypeUserAuthorizationListWithContactIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    List<TVTypeUserAuthorizationModel> tvTypeUserAuthorizationModelList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelListWithContactTVItemIDDB(tvTypeUserAuthorizationModelRet.ContactTVItemID);
                    Assert.IsTrue(tvTypeUserAuthorizationModelList.Count > 0);
                    Assert.IsTrue(tvTypeUserAuthorizationModelList.Where(c => c.TVTypeUserAuthorizationID == tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID).Any());

                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_GetTVTypeUserAuthorizationModelWithContactIDAndTVTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel2 = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(tvTypeUserAuthorizationModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID, tvTypeUserAuthorizationModel2.TVTypeUserAuthorizationID);

                    int ContactTVItemID = 0;
                    tvTypeUserAuthorizationModel2 = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(ContactTVItemID, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, BaseEnumServiceRes.TVTypeUserAuthorization, ServiceRes.ContactID + "," + ServiceRes.TVType, ContactTVItemID.ToString() + "," + tvTypeUserAuthorizationModelRet.TVType.ToString()), tvTypeUserAuthorizationModel2.Error);

                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_GetTVTypeUserAuthorizationModelWithTVTypeUserAuthorizationIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithTVTypeUserAuthorizationIDDB(tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID);
                    Assert.AreEqual(tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID, tvTypeUserAuthorizationModelRet2.TVTypeUserAuthorizationID);

                    int TVTypeUserAuthorizationID = 0;
                    tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithTVTypeUserAuthorizationIDDB(TVTypeUserAuthorizationID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, BaseEnumServiceRes.TVTypeUserAuthorization, BaseEnumServiceRes.TVTypeUserAuthorizationID, TVTypeUserAuthorizationID), tvTypeUserAuthorizationModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_GetTVTypeUserAuthorizationWithContactIDAndTVTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVTypeUserAuthorization tvTypeUserAuthorization2 = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithContactTVItemIDAndTVTypeDB(tvTypeUserAuthorizationModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID, tvTypeUserAuthorization2.TVTypeUserAuthorizationID);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationIDDB(tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID);
                    Assert.AreEqual(tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddUpdateDeleteTVTypeUserAuthorizationDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = UpdateTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelRet, tvTypeUserAuthorizationService);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet3 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet2.TVTypeUserAuthorizationID);
                    Assert.AreEqual("", tvTypeUserAuthorizationModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddUpdateDeleteTVTypeUserAuthorizationDB_ContactEqualLoggedIn_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = UpdateTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelRet, tvTypeUserAuthorizationService);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet3 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet2.TVTypeUserAuthorizationID);
                    Assert.AreEqual("", tvTypeUserAuthorizationModelRet3.Error);

                    tvTypeUserAuthorizationModelRet2.ContactTVItemID = contactModelListGood[0].ContactTVItemID;
                    tvTypeUserAuthorizationModelRet3 = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet2);
                    Assert.AreEqual(ServiceRes.CantSetOwnAuthorization, tvTypeUserAuthorizationModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddTVTypeUserAuthorizationDB_TVTypeUserAuthorizationModelOK_Error_Test()
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
                        shimTVTypeUserAuthorizationService.TVTypeUserAuthorizationModelOKTVTypeUserAuthorizationModel = (a) =>
                        {
                            return ErrorText;
                        };

                        FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelNew);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddTVTypeUserAuthorizationDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    tvTypeUserAuthorizationModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(4).ContactTVItemID;
                    FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelNew);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddTVTypeUserAuthorizationDB_IsAdministratorDB_Error_Test()
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
                        shimTVTypeUserAuthorizationService.IsAdministratorDBString = (a) =>
                        {
                            return false;
                        };

                        tvTypeUserAuthorizationModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(4).ContactTVItemID;
                        FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelNew);
                        Assert.AreEqual(ServiceRes.OnlyAdministratorsCanManageUsers, tvTypeUserAuthorizationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddTVTypeUserAuthorizationDB_GetContactModelWithContactTVItemIDDB_Error_Test()
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
                        shimTVTypeUserAuthorizationService.GetContactModelWithContactTVItemIDDBInt32 = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        tvTypeUserAuthorizationModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(3).ContactTVItemID;
                        FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelNew);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddTVTypeUserAuthorizationDB_GetContactLoggedInDB_Error_Test()
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
                        shimTVTypeUserAuthorizationService.GetContactLoggedInDB = () =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        tvTypeUserAuthorizationModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(4).ContactTVItemID;
                        FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelNew);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddTVTypeUserAuthorizationDB_ContactID_Equal_LoggedInContactID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = UpdateTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelRet, tvTypeUserAuthorizationService);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet3 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet2.TVTypeUserAuthorizationID);
                    Assert.AreEqual("", tvTypeUserAuthorizationModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddTVTypeUserAuthorizationDB_GetTVTypeUserAuthorizationWithContactIDAndTVTypeDB_Error_Test()
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
                        shimTVTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithContactTVItemIDAndTVTypeDBInt32TVTypeEnum = (a, b) =>
                        {
                            return new TVTypeUserAuthorization();
                        };

                        tvTypeUserAuthorizationModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(4).ContactTVItemID;
                        FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, BaseEnumServiceRes.TVTypeUserAuthorization), tvTypeUserAuthorizationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddTVTypeUserAuthorizationDB_FillTVTypeUserAuthorization_Error_Test()
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
                        shimTVTypeUserAuthorizationService.FillTVTypeUserAuthorizationTVTypeUserAuthorizationTVTypeUserAuthorizationModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        tvTypeUserAuthorizationModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(4).ContactTVItemID;
                        FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelNew);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddTVTypeUserAuthorizationDB_Add_Error_Test()
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
                        shimTVTypeUserAuthorizationService.FillTVTypeUserAuthorizationTVTypeUserAuthorizationTVTypeUserAuthorizationModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        tvTypeUserAuthorizationModelNew.ContactTVItemID = 3;
                        FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelNew);
                        Assert.IsTrue(tvTypeUserAuthorizationModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddTVTypeUserAuthorizationDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    tvTypeUserAuthorizationModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(3).ContactTVItemID;
                    FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelNew);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, tvTypeUserAuthorizationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostAddTVTypeUserAuthorizationDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    tvTypeUserAuthorizationModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(4).ContactTVItemID;
                    FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelNew);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, tvTypeUserAuthorizationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostDeleteTVTypeUserAuthorizationWithContactIDAndTVTypeDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationWithContactTVItemIDAndTVTypeDB(tvTypeUserAuthorizationModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual("", tvTypeUserAuthorizationModelRet2.Error);

                    TVTypeUserAuthorization tvTypeUserAuthorization = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithContactTVItemIDAndTVTypeDB(tvTypeUserAuthorizationModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.IsNull(tvTypeUserAuthorization);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostDeleteTVTypeUserAuthorizationWithContactIDAndTVTypeDB_TryingToDelete_Root_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(contactModelListGood[0].ContactTVItemID, TVTypeEnum.Root);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationWithContactTVItemIDAndTVTypeDB(tvTypeUserAuthorizationModelRet.ContactTVItemID, tvTypeUserAuthorizationModelRet.TVType);
                    Assert.AreEqual(ServiceRes.CantRemoveRootAutorization, tvTypeUserAuthorizationModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostDeleteTVTypeUserAuthorizationDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRe2 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRe2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostDeleteTVTypeUserAuthorizationDB_IsAdministratorDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.IsAdministratorDBString = (a) =>
                        {
                            return false;
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRe2 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID);
                        Assert.AreEqual(ServiceRes.OnlyAdministratorsCanManageUsers, tvTypeUserAuthorizationModelRe2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostDeleteTVTypeUserAuthorizationDB_GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRe2 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, BaseEnumServiceRes.TVTypeUserAuthorization), tvTypeUserAuthorizationModelRe2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostDeleteTVTypeUserAuthorizationDB_GetContactModelWithContactTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.GetContactModelWithContactTVItemIDDBInt32 = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRe2 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRe2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostDeleteTVTypeUserAuthorizationDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRe2 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRe2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostDeleteTVTypeUserAuthorizationDB_GetContactLoggedInDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.GetContactLoggedInDB = () =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRe2 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRe2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostDeleteTVTypeUserAuthorizationWithContactIDAndTVTypeDB_Good_with_ContactID_And_TVType_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    tvTypeUserAuthorizationModelRet.TVTypeUserAuthorizationID = 0;
                    if (tvTypeUserAuthorizationModelRet.TVAuth == TVAuthEnum.Delete)
                    {
                        tvTypeUserAuthorizationModelRet.TVAuth = TVAuthEnum.Create;
                    }
                    else
                    {
                        tvTypeUserAuthorizationModelRet.TVAuth = TVAuthEnum.Delete;
                    }
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet3 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet2.TVTypeUserAuthorizationID);
                    Assert.AreEqual("", tvTypeUserAuthorizationModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostDeleteTVTypeUserAuthorizationWithContactIDAndTVTypeDB_Good_with_ContactID_And_TVType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDBInt32TVTypeEnum = (a, b) =>
                        {
                            return new TVTypeUserAuthorizationModel() { Error = ErrorText };
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationWithContactTVItemIDAndTVTypeDB(tvTypeUserAuthorizationModelRet.ContactTVItemID + 1000000, tvTypeUserAuthorizationModelRet.TVType);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostSetTVTypeUserAuthorizationDB_Good_AddAndUpdate_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    tvTypeUserAuthorizationModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(3).ContactTVItemID;
                    FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);
                    tvTypeUserAuthorizationModelNew.TVType = TVTypeEnum.Country;

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostSetTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelNew);

                    CompareTVTypeUserAuthorizationModels(tvTypeUserAuthorizationModelNew, tvTypeUserAuthorizationModelRet);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostSetTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet);

                    CompareTVTypeUserAuthorizationModels(tvTypeUserAuthorizationModelRet, tvTypeUserAuthorizationModelRet2);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostUpdateTVTypeUserAuthorizationDB_ContactEqualLoggedIn_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = UpdateTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelRet, tvTypeUserAuthorizationService);

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet3 = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet2.TVTypeUserAuthorizationID);
                    Assert.AreEqual("", tvTypeUserAuthorizationModelRet3.Error);

                    tvTypeUserAuthorizationModelRet2.ContactTVItemID = contactModelListGood[0].ContactTVItemID;
                    tvTypeUserAuthorizationModelRet3 = tvTypeUserAuthorizationService.PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet2);
                    Assert.AreEqual(ServiceRes.CantSetOwnAuthorization, tvTypeUserAuthorizationModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostUpdateTVTypeUserAuthorizationDB_TVTypeUserAuthorizationModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.TVTypeUserAuthorizationModelOKTVTypeUserAuthorizationModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostUpdateTVTypeUserAuthorizationDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostUpdateTVTypeUserAuthorizationDB_IsAdministratorDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.IsAdministratorDBString = (a) =>
                        {
                            return false;
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet);
                        Assert.AreEqual(ServiceRes.OnlyAdministratorsCanManageUsers, tvTypeUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostUpdateTVTypeUserAuthorizationDB_GetContactModelWithContactTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.GetContactModelWithContactTVItemIDDBInt32 = (a) =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostUpdateTVTypeUserAuthorizationDB_GetContactLoggedInDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.GetContactLoggedInDB = () =>
                        {
                            return new ContactModel() { Error = ErrorText };
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostUpdateTVTypeUserAuthorizationDB_GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, BaseEnumServiceRes.TVTypeUserAuthorization), tvTypeUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostUpdateTVTypeUserAuthorizationDB_FillTVTypeUserAuthorization_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.FillTVTypeUserAuthorizationTVTypeUserAuthorizationTVTypeUserAuthorizationModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVTypeUserAuthorizationService_PostUpdateTVTypeUserAuthorizationDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = AddTVTypeUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVTypeUserAuthorizationService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet);
                        Assert.AreEqual(ErrorText, tvTypeUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods

        #region Functions private
        private TVTypeUserAuthorizationModel AddTVTypeUserAuthorizationModel(int ContactTVItemID)
        {
            TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = new TVTypeUserAuthorizationModel();
            tvTypeUserAuthorizationModelNew.ContactTVItemID = ContactTVItemID;
            FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelNew);

            tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelNew);
            Assert.IsNotNull(tvTypeUserAuthorizationModelRet);
            Assert.AreEqual("", tvTypeUserAuthorizationModelRet.Error);
            CompareTVTypeUserAuthorizationModels(tvTypeUserAuthorizationModelNew, tvTypeUserAuthorizationModelRet);

            return tvTypeUserAuthorizationModelRet;
        }
        private TVTypeUserAuthorizationModel UpdateTVTypeUserAuthorizationModel(TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet, TVTypeUserAuthorizationService tvTypeUserAuthorizationService)
        {
            FillTVTypeUserAuthorizationModel(tvTypeUserAuthorizationModelRet);

            TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet2 = tvTypeUserAuthorizationService.PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModelRet);
            if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationModelRet2.Error))
            {
                return tvTypeUserAuthorizationModelRet2;
            }
            Assert.IsNotNull(tvTypeUserAuthorizationModelRet2);
            CompareTVTypeUserAuthorizationModels(tvTypeUserAuthorizationModelRet, tvTypeUserAuthorizationModelRet2);

            return tvTypeUserAuthorizationModelRet2;
        }
        private void CompareTVTypeUserAuthorizationModels(TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelNew, TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet)
        {
            Assert.AreEqual(tvTypeUserAuthorizationModelNew.ContactTVItemID, tvTypeUserAuthorizationModelRet.ContactTVItemID);
            Assert.AreEqual(tvTypeUserAuthorizationModelNew.TVType, tvTypeUserAuthorizationModelRet.TVType);
            Assert.AreEqual(tvTypeUserAuthorizationModelNew.TVAuth, tvTypeUserAuthorizationModelRet.TVAuth);
        }
        private void FillTVTypeUserAuthorizationModel(TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel)
        {
            int TVTypeCount = Enum.GetNames(typeof(TVTypeEnum)).Length;
            int TVAuthCount = Enum.GetNames(typeof(TVAuthEnum)).Length;

            tvTypeUserAuthorizationModel.ContactTVItemID = tvTypeUserAuthorizationModel.ContactTVItemID;
            tvTypeUserAuthorizationModel.TVType = TVTypeEnum.PolSourceSite;
            tvTypeUserAuthorizationModel.TVAuth = TVAuthEnum.Read;
            Assert.IsTrue(tvTypeUserAuthorizationModel.ContactTVItemID != 2);
            Assert.IsTrue(tvTypeUserAuthorizationModel.TVType == TVTypeEnum.PolSourceSite);
            Assert.IsTrue(tvTypeUserAuthorizationModel.TVAuth == TVAuthEnum.Read);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            contactService = new ContactService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvTypeUserAuthorizationModelNew = new TVTypeUserAuthorizationModel();
            tvTypeUserAuthorization = new TVTypeUserAuthorization();
        }
        private void SetupShim()
        {
            shimTVTypeUserAuthorizationService = new ShimTVTypeUserAuthorizationService(tvTypeUserAuthorizationService);
            shimContactService = new ShimContactService(contactService);
        }
        #endregion Functions private
    }
}
