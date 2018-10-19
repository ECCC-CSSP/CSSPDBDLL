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
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for TVItemUserAuthorizationServiceTest
    /// </summary>
    [TestClass]
    public class TVItemUserAuthorizationServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "TVItemUserAuthorization";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private TVItemUserAuthorizationService tvItemUserAuthorizationService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private TVItemUserAuthorizationModel tvItemUserAuthorizationModelNew { get; set; }
        private TVItemUserAuthorization tvItemUserAuthorization { get; set; }
        private ShimTVItemUserAuthorizationService shimTVItemUserAuthorizationService { get; set; }
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
        public TVItemUserAuthorizationServiceTest()
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
        public void TVItemUserAuthorizationService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(tvItemUserAuthorizationService);
                Assert.IsNotNull(tvItemUserAuthorizationService.db);
                Assert.IsNotNull(tvItemUserAuthorizationService.LanguageRequest);
                Assert.IsNotNull(tvItemUserAuthorizationService.User);
                Assert.IsNotNull(tvItemUserAuthorizationService._TVItemService);
                Assert.AreEqual(user.Identity.Name, tvItemUserAuthorizationService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), tvItemUserAuthorizationService.LanguageRequest);
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_TVItemUserAuthorizationModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelContact = randomService.RandomTVItem(TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    #region Good
                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemModelContact.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemModelMunicipality.TVItemID;
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                    tvItemUserAuthorizationModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(randomService.RandomTVItem(TVTypeEnum.Contact).TVItemID).ContactTVItemID;

                    string retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region ContactID
                    tvItemUserAuthorizationModelNew.ContactTVItemID = contactModelListGood[0].ContactTVItemID;
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                    tvItemUserAuthorizationModelNew.ContactTVItemID = 0;

                    retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.ContactID), retStr);

                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemModelContact.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemModelMunicipality.TVItemID;
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);

                    retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion ContactID

                    #region TVItemID1
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                    tvItemUserAuthorizationModelNew.TVItemID1 = 0;

                    retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID1), retStr);

                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemModelContact.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemModelMunicipality.TVItemID;
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);

                    retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull("", retStr);

                    #endregion TVItemID1

                    #region TVItemID2
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                    tvItemUserAuthorizationModelNew.TVItemID2 = 0;

                    retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID2), retStr);

                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemModelContact.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemModelMunicipality.TVItemID;
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);

                    retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull("", retStr);

                    #endregion TVItemID2

                    #region TVItemID3
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                    tvItemUserAuthorizationModelNew.TVItemID3 = 0;

                    retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID3), retStr);

                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemModelContact.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemModelMunicipality.TVItemID;
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);

                    retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull("", retStr);

                    #endregion TVItemID3

                    #region TVItemID4
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                    tvItemUserAuthorizationModelNew.TVItemID4 = 0;

                    retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID4), retStr);

                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemModelContact.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemModelMunicipality.TVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemModelMunicipality.TVItemID;
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);

                    retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull("", retStr);

                    #endregion TVItemID4

                    #region TVAuth
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                    tvItemUserAuthorizationModelNew.TVAuth = (TVAuthEnum)1000;

                    retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TVAuth), retStr);

                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                    tvItemUserAuthorizationModelNew.TVAuth = TVAuthEnum.Create;

                    retStr = tvItemUserAuthorizationService.TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModelNew);
                    Assert.IsNotNull("", retStr);

                    #endregion TVAuth
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_FillTVItemUserAuthorization_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);
                    Assert.AreEqual("", tvItemUserAuthorizationModelRet.Error);

                    ContactOK contactOK = tvItemUserAuthorizationService.IsContactOK();

                    TVItemUserAuthorization tvItemUserAuthorizationNew = new TVItemUserAuthorization();

                    string retStr = tvItemUserAuthorizationService.FillTVItemUserAuthorization(tvItemUserAuthorizationNew, tvItemUserAuthorizationModelRet, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, tvItemUserAuthorizationNew.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = tvItemUserAuthorizationService.FillTVItemUserAuthorization(tvItemUserAuthorizationNew, tvItemUserAuthorizationModelRet, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, tvItemUserAuthorizationNew.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_GetTVItemTVAuthWithContactTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVItemModel tvItemModel = tvItemUserAuthorizationService._TVItemService.GetTVItemModelWithTVItemIDDB(tvItemUserAuthorizationModelRet.TVItemID1);
                    Assert.AreEqual("", tvItemModel.Error);

                    List<TVItemTVAuth> tvItemTVAuthList = tvItemUserAuthorizationService.GetTVItemTVAuthWithContactTVItemIDDB(tvItemUserAuthorizationModelRet.ContactTVItemID);
                    Assert.AreEqual(1, tvItemTVAuthList.Count);
                    Assert.AreEqual(tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID, tvItemTVAuthList[0].TVItemUserAuthID);
                    Assert.AreEqual(tvItemUserAuthorizationModelRet.TVItemID1, tvItemTVAuthList[0].TVItemID1);
                    Assert.AreEqual(tvItemUserAuthorizationModelRet.TVText1, tvItemTVAuthList[0].TVText);
                    Assert.AreEqual(tvItemModel.TVType.ToString(), tvItemTVAuthList[0].TVTypeStr);
                    Assert.AreEqual(tvItemUserAuthorizationModelRet.TVAuth, tvItemTVAuthList[0].TVAuth);
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_GetTVItemUserAuthorizationModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    int tvItemUserAuthorizationCount = tvItemUserAuthorizationService.GetTVItemUserAuthorizationModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, tvItemUserAuthorizationCount);
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_GetTVItemUserAuthorizationModelListWithContactIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    List<TVItemUserAuthorizationModel> tvItemUserAuthorizationModelList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationModelListWithContactTVItemIDDB(tvItemUserAuthorizationModelRet.ContactTVItemID);
                    Assert.IsTrue(tvItemUserAuthorizationModelList.Where(c => c.TVItemUserAuthorizationID == tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID).Any());

                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_GetTVItemUserAuthorizationModelListTVItemID1DB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    List<TVItemUserAuthorizationModel> tvItemUserAuthorizationModelList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationModelListWithTVItemID1DB(tvItemUserAuthorizationModelRet.TVItemID1);
                    Assert.IsTrue(tvItemUserAuthorizationModelList.Where(c => c.TVItemUserAuthorizationID == tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID).Any());

                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_GetTVItemUserAuthorizationModelWithTVItemUserAuthorizationIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet2 = tvItemUserAuthorizationService.GetTVItemUserAuthorizationModelWithTVItemUserAuthorizationIDDB(tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID);
                    Assert.AreEqual(tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID, tvItemUserAuthorizationModelRet2.TVItemUserAuthorizationID);

                    int TVItemUserAuthorizationID = 0;
                    tvItemUserAuthorizationModelRet2 = tvItemUserAuthorizationService.GetTVItemUserAuthorizationModelWithTVItemUserAuthorizationIDDB(TVItemUserAuthorizationID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemUserAuthorization, ServiceRes.TVItemUserAuthorizationID, TVItemUserAuthorizationID), tvItemUserAuthorizationModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_GetTVItemUserAuthorizationModelWithContactTVItemIDTVItemID1TVItemID2TVItemID3TVItemID4DB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet2 = tvItemUserAuthorizationService.GetTVItemUserAuthorizationModelWithContactTVItemIDTVItemID1TVItemID2TVItemID3TVItemID4DB(tvItemUserAuthorizationModelRet.ContactTVItemID, tvItemUserAuthorizationModelRet.TVItemID1, tvItemUserAuthorizationModelRet.TVItemID2, tvItemUserAuthorizationModelRet.TVItemID3, tvItemUserAuthorizationModelRet.TVItemID4);
                    Assert.AreEqual(tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID, tvItemUserAuthorizationModelRet2.TVItemUserAuthorizationID);

                    int ContactTVItemID = 0;
                    tvItemUserAuthorizationModelRet2 = tvItemUserAuthorizationService.GetTVItemUserAuthorizationModelWithContactTVItemIDTVItemID1TVItemID2TVItemID3TVItemID4DB(ContactTVItemID, tvItemUserAuthorizationModelRet.TVItemID1, tvItemUserAuthorizationModelRet.TVItemID2, tvItemUserAuthorizationModelRet.TVItemID3, tvItemUserAuthorizationModelRet.TVItemID4);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemUserAuthorization, ServiceRes.ContactTVItemID
+ "," + ServiceRes.TVItemID1 + ","
+ ServiceRes.TVItemID2 ?? "" + ","
+ ServiceRes.TVItemID3 ?? "" + ","
+ ServiceRes.TVItemID4 ?? "",
ContactTVItemID.ToString() + ","
+ tvItemUserAuthorizationModelRet.TVItemID1.ToString() + ","
+ tvItemUserAuthorizationModelRet.TVItemID2 ?? "" + ","
+ tvItemUserAuthorizationModelRet.TVItemID3 ?? "" + ","
+ tvItemUserAuthorizationModelRet.TVItemID4 ?? ""
), tvItemUserAuthorizationModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_GetTVItemUserAuthorizationWithTVItemUserAuthorizationIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVItemUserAuthorization tvItemUserAuthorizationRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationIDDB(tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID);
                    Assert.AreEqual(tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID, tvItemUserAuthorizationRet.TVItemUserAuthorizationID);

                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_GetTVItemUserAuthorizationWithContactIDTVItemID1TVItemID2TVItemID3TVItemID4DB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVItemUserAuthorization tvItemUserAuthorizationRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationWithContactTVItemIDTVItemID1TVItemID2TVItemID3TVItemID4DB(tvItemUserAuthorizationModelRet.ContactTVItemID, tvItemUserAuthorizationModelRet.TVItemID1, tvItemUserAuthorizationModelRet.TVItemID2, tvItemUserAuthorizationModelRet.TVItemID3, tvItemUserAuthorizationModelRet.TVItemID4);
                    Assert.AreEqual(tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID, tvItemUserAuthorizationRet.TVItemUserAuthorizationID);

                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostAddUpdateDeleteTVItemUserAuthorizationDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet2 = UpdateTVItemUserAuthorizationModel(tvItemUserAuthorizationModelRet);

                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet3 = tvItemUserAuthorizationService.PostDeleteTVItemUserAuthorizationDB(tvItemUserAuthorizationModelRet2.TVItemUserAuthorizationID);
                    Assert.AreEqual("", tvItemUserAuthorizationModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostAddTVItemUserAuthorizationDB_TVItemUserAuthorizationModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModel = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);
                    Assert.AreEqual("", tvItemUserAuthorizationModel.Error);

                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemUserAuthorizationModel.ContactTVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemUserAuthorizationModel.TVItemID1;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemUserAuthorizationModel.TVItemID2;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemUserAuthorizationModel.TVItemID3;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemUserAuthorizationModel.TVItemID4;

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.TVItemUserAuthorizationModelOKTVItemUserAuthorizationModel = (a) =>
                        {
                            return ErrorText;
                        };

                        FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.PostAddTVItemUserAuthorizationDB(tvItemUserAuthorizationModelNew);
                        Assert.AreEqual(ErrorText, tvItemUserAuthorizationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostAddTVItemUserAuthorizationDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModel = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);
                    Assert.AreEqual("", tvItemUserAuthorizationModel.Error);

                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemUserAuthorizationModel.ContactTVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemUserAuthorizationModel.TVItemID1;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemUserAuthorizationModel.TVItemID2;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemUserAuthorizationModel.TVItemID3;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemUserAuthorizationModel.TVItemID4;

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.PostAddTVItemUserAuthorizationDB(tvItemUserAuthorizationModelNew);
                        Assert.AreEqual(ErrorText, tvItemUserAuthorizationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostAddTVItemUserAuthorizationDB_GetTVItemUserAuthorizationWithContactIDTVItemID1TVItemID2TVItemID3TVItemID4DB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModel = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);
                    Assert.AreEqual("", tvItemUserAuthorizationModel.Error);

                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemUserAuthorizationModel.ContactTVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemUserAuthorizationModel.TVItemID1;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemUserAuthorizationModel.TVItemID2;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemUserAuthorizationModel.TVItemID3;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemUserAuthorizationModel.TVItemID4;

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.GetTVItemUserAuthorizationWithContactTVItemIDTVItemID1TVItemID2TVItemID3TVItemID4DBInt32Int32NullableOfInt32NullableOfInt32NullableOfInt32 = (a, b, c, d, e) =>
                        {
                            return new TVItemUserAuthorization();
                        };

                        FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.PostAddTVItemUserAuthorizationDB(tvItemUserAuthorizationModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItemUserAuthorization), tvItemUserAuthorizationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostAddTVItemUserAuthorizationDB_FillTVItemUserAuthorization_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModel = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);
                    Assert.AreEqual("", tvItemUserAuthorizationModel.Error);

                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemUserAuthorizationModel.ContactTVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemUserAuthorizationModel.TVItemID1;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemUserAuthorizationModel.TVItemID2;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemUserAuthorizationModel.TVItemID3;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemUserAuthorizationModel.TVItemID4;

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.FillTVItemUserAuthorizationTVItemUserAuthorizationTVItemUserAuthorizationModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.PostAddTVItemUserAuthorizationDB(tvItemUserAuthorizationModelNew);
                        Assert.AreEqual(ErrorText, tvItemUserAuthorizationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostAddTVItemUserAuthorizationDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModel = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);
                    Assert.AreEqual("", tvItemUserAuthorizationModel.Error);

                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemUserAuthorizationModel.ContactTVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemUserAuthorizationModel.TVItemID1;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemUserAuthorizationModel.TVItemID2;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemUserAuthorizationModel.TVItemID3;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemUserAuthorizationModel.TVItemID4;

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.FillTVItemUserAuthorizationTVItemUserAuthorizationTVItemUserAuthorizationModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };



                        FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.PostAddTVItemUserAuthorizationDB(tvItemUserAuthorizationModelNew);
                        Assert.IsTrue(tvItemUserAuthorizationModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostAddTVItemUserAuthorizationDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModel = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);
                    Assert.AreEqual("", tvItemUserAuthorizationModel.Error);

                    SetupTest(contactModelListBad[0], culture);

                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemUserAuthorizationModel.ContactTVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemUserAuthorizationModel.TVItemID1;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemUserAuthorizationModel.TVItemID2;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemUserAuthorizationModel.TVItemID3;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemUserAuthorizationModel.TVItemID4;

                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.PostAddTVItemUserAuthorizationDB(tvItemUserAuthorizationModelNew);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, tvItemUserAuthorizationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostAddTVItemUserAuthorizationDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModel = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);
                    Assert.AreEqual("", tvItemUserAuthorizationModel.Error);

                    SetupTest(contactModelListGood[2], culture);

                    tvItemUserAuthorizationModelNew.ContactTVItemID = tvItemUserAuthorizationModel.ContactTVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = tvItemUserAuthorizationModel.TVItemID1;
                    tvItemUserAuthorizationModelNew.TVItemID2 = tvItemUserAuthorizationModel.TVItemID2;
                    tvItemUserAuthorizationModelNew.TVItemID3 = tvItemUserAuthorizationModel.TVItemID3;
                    tvItemUserAuthorizationModelNew.TVItemID4 = tvItemUserAuthorizationModel.TVItemID4;

                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.PostAddTVItemUserAuthorizationDB(tvItemUserAuthorizationModelNew);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, tvItemUserAuthorizationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostDeleteTVItemUserAuthorization_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet3 = tvItemUserAuthorizationService.PostDeleteTVItemUserAuthorizationDB(tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID);
                        Assert.AreEqual(ErrorText, tvItemUserAuthorizationModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostDeleteTVItemUserAuthorization_GetTVItemUserAuthorizationWithTVItemUserAuthorizationIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet3 = tvItemUserAuthorizationService.PostDeleteTVItemUserAuthorizationDB(tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVItemUserAuthorization), tvItemUserAuthorizationModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostDeleteTVItemUserAuthorization_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet3 = tvItemUserAuthorizationService.PostDeleteTVItemUserAuthorizationDB(tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID);
                        Assert.AreEqual(ErrorText, tvItemUserAuthorizationModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostSetTVItemUserAuthorizationDB_Good_AddAndUpdate_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    tvItemUserAuthorizationModelNew.ContactTVItemID = contactService.GetContactModelWithContactTVItemIDDB(3).ContactTVItemID;
                    tvItemUserAuthorizationModelNew.TVItemID1 = randomService.RandomTVItem(TVTypeEnum.Country).TVItemID;
                    FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);
                    tvItemUserAuthorizationModelNew.TVItemID2 = null;
                    tvItemUserAuthorizationModelNew.TVItemID3 = null;
                    tvItemUserAuthorizationModelNew.TVItemID4 = null;

                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.GetTVItemUserAuthorizationModelWithContactTVItemIDTVItemID1TVItemID2TVItemID3TVItemID4DB(tvItemUserAuthorizationModelNew.ContactTVItemID, tvItemUserAuthorizationModelNew.TVItemID1, tvItemUserAuthorizationModelNew.TVItemID2, tvItemUserAuthorizationModelNew.TVItemID3, tvItemUserAuthorizationModelNew.TVItemID4);

                    if (tvItemUserAuthorizationModelRet.ContactTVItemID > 0)
                    {
                        tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.PostDeleteTVItemUserAuthorizationDB(tvItemUserAuthorizationModelRet.TVItemUserAuthorizationID);
                        Assert.AreEqual("", tvItemUserAuthorizationModelRet.Error);
                    }

                    tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.PostSetTVItemUserAuthorizationDB(tvItemUserAuthorizationModelNew);

                    CompareTVItemUserAuthorizationModels(tvItemUserAuthorizationModelNew, tvItemUserAuthorizationModelRet);

                    tvItemUserAuthorizationModelRet.TVAuth = TVAuthEnum.Delete;

                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet2 = tvItemUserAuthorizationService.PostSetTVItemUserAuthorizationDB(tvItemUserAuthorizationModelRet);

                    CompareTVItemUserAuthorizationModels(tvItemUserAuthorizationModelRet, tvItemUserAuthorizationModelRet2);
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostUpdateTVItemUserAuthorization_TVItemUserAuthorizationModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.TVItemUserAuthorizationModelOKTVItemUserAuthorizationModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet2 = UpdateTVItemUserAuthorizationModel(tvItemUserAuthorizationModelRet);
                        Assert.AreEqual(ErrorText, tvItemUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostUpdateTVItemUserAuthorization_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet2 = UpdateTVItemUserAuthorizationModel(tvItemUserAuthorizationModelRet);
                        Assert.AreEqual(ErrorText, tvItemUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostUpdateTVItemUserAuthorization_GetTVItemUserAuthorizationWithTVItemUserAuthorizationIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet2 = UpdateTVItemUserAuthorizationModel(tvItemUserAuthorizationModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVItemUserAuthorization), tvItemUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostUpdateTVItemUserAuthorization_FillTVItemUserAuthorization_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.FillTVItemUserAuthorizationTVItemUserAuthorizationTVItemUserAuthorizationModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet2 = UpdateTVItemUserAuthorizationModel(tvItemUserAuthorizationModelRet);
                        Assert.AreEqual(ErrorText, tvItemUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemUserAuthorizationService_PostUpdateTVItemUserAuthorization_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = AddTVItemUserAuthorizationModel(contactModelListGood[2].ContactTVItemID);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemUserAuthorizationService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet2 = UpdateTVItemUserAuthorizationModel(tvItemUserAuthorizationModelRet);
                        Assert.AreEqual(ErrorText, tvItemUserAuthorizationModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods

        #region Functions private
        private TVItemUserAuthorizationModel AddTVItemUserAuthorizationModel(int ContactTVItemID)
        {
            TVItemModel tvItemModelRoot = tvItemUserAuthorizationService._TVItemService.GetRootTVItemModelDB();
            Assert.AreEqual("", tvItemModelRoot.Error);

            TVItemModel tvItemModelCountry = tvItemUserAuthorizationService._TVItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, "unique country", TVTypeEnum.Country);
            Assert.AreEqual("", tvItemModelCountry.Error);

            TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = new TVItemUserAuthorizationModel();
            tvItemUserAuthorizationModelNew.ContactTVItemID = ContactTVItemID;
            tvItemUserAuthorizationModelNew.TVItemID1 = tvItemModelCountry.TVItemID;
            tvItemUserAuthorizationModelNew.TVItemID2 = null;
            tvItemUserAuthorizationModelNew.TVItemID3 = null;
            tvItemUserAuthorizationModelNew.TVItemID4 = null;
            FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelNew);

            tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.PostAddTVItemUserAuthorizationDB(tvItemUserAuthorizationModelNew);
            Assert.IsNotNull(tvItemUserAuthorizationModelRet);
            Assert.AreEqual("", tvItemUserAuthorizationModelRet.Error);
            CompareTVItemUserAuthorizationModels(tvItemUserAuthorizationModelNew, tvItemUserAuthorizationModelRet);

            return tvItemUserAuthorizationModelRet;
        }
        private TVItemUserAuthorizationModel UpdateTVItemUserAuthorizationModel(TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet)
        {
            FillTVItemUserAuthorizationModel(tvItemUserAuthorizationModelRet);

            TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet2 = tvItemUserAuthorizationService.PostUpdateTVItemUserAuthorizationDB(tvItemUserAuthorizationModelRet);
            if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationModelRet2.Error))
            {
                return tvItemUserAuthorizationModelRet2;
            }
            Assert.IsNotNull(tvItemUserAuthorizationModelRet2);
            CompareTVItemUserAuthorizationModels(tvItemUserAuthorizationModelRet, tvItemUserAuthorizationModelRet2);

            return tvItemUserAuthorizationModelRet2;
        }
        private void CompareTVItemUserAuthorizationModels(TVItemUserAuthorizationModel tvItemUserAuthorizationModelNew, TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet)
        {
            Assert.AreEqual(tvItemUserAuthorizationModelNew.ContactTVItemID, tvItemUserAuthorizationModelRet.ContactTVItemID);
            Assert.AreEqual(tvItemUserAuthorizationModelNew.TVItemID1, tvItemUserAuthorizationModelRet.TVItemID1);
            Assert.AreEqual(tvItemUserAuthorizationModelNew.TVItemID2, tvItemUserAuthorizationModelRet.TVItemID2);
            Assert.AreEqual(tvItemUserAuthorizationModelNew.TVItemID3, tvItemUserAuthorizationModelRet.TVItemID3);
            Assert.AreEqual(tvItemUserAuthorizationModelNew.TVItemID4, tvItemUserAuthorizationModelRet.TVItemID4);
            Assert.AreEqual(tvItemUserAuthorizationModelNew.TVAuth, tvItemUserAuthorizationModelRet.TVAuth);
        }
        private void FillTVItemUserAuthorizationModel(TVItemUserAuthorizationModel tvItemUserAuthorizationModel)
        {
            tvItemUserAuthorizationModel.ContactTVItemID = tvItemUserAuthorizationModel.ContactTVItemID;
            tvItemUserAuthorizationModel.TVItemID1 = tvItemUserAuthorizationModel.TVItemID1;
            tvItemUserAuthorizationModel.TVItemID2 = randomService.RandomTVItem(TVTypeEnum.Infrastructure).TVItemID;
            tvItemUserAuthorizationModel.TVItemID3 = randomService.RandomTVItem(TVTypeEnum.MWQMSite).TVItemID;
            tvItemUserAuthorizationModel.TVItemID4 = randomService.RandomTVItem(TVTypeEnum.PolSourceSite).TVItemID;
            tvItemUserAuthorizationModel.TVAuth = TVAuthEnum.Create;
            Assert.IsTrue(tvItemUserAuthorizationModel.ContactTVItemID != 0);
            Assert.IsTrue(tvItemUserAuthorizationModel.TVItemID1 != 0);
            Assert.IsTrue(tvItemUserAuthorizationModel.TVItemID2 != 0);
            Assert.IsTrue(tvItemUserAuthorizationModel.TVItemID3 != 0);
            Assert.IsTrue(tvItemUserAuthorizationModel.TVItemID4 != 0);
            Assert.IsTrue(tvItemUserAuthorizationModel.TVAuth == TVAuthEnum.Create);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            tvItemUserAuthorizationService = new TVItemUserAuthorizationService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            contactService = new ContactService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemUserAuthorizationModelNew = new TVItemUserAuthorizationModel();
            tvItemUserAuthorization = new TVItemUserAuthorization();
        }
        private void SetupShim()
        {
            shimTVItemUserAuthorizationService = new ShimTVItemUserAuthorizationService(tvItemUserAuthorizationService);
        }
        #endregion Functions private
    }
}


