using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPWebToolsDBDLL.Tests.SetupInfo;
using CSSPWebToolsDBDLL.Models;
using System.Security.Principal;
using CSSPWebToolsDBDLL.Services;
using CSSPWebToolsDBDLL.Services.Resources;
using CSSPWebToolsDBDLL.Services.Fakes;
using System.Linq;
using System.Globalization;
using System.Threading;
using System.Transactions;
using System.Net.Mail;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;


namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for BaseServiceTest
    /// </summary>
    [TestClass]
    public class BaseServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private BaseService baseService { get; set; }
        private RandomService randomService { get; set; }
        private ShimBaseService shimBaseService { get; set; }
        private TVItemUserAuthorizationService tvItemUserAuthorizationService { get; set; }
        private TVTypeUserAuthorizationService tvTypeUserAuthorizationService { get; set; }
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
        public BaseServiceTest()
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

        #region Testing Methods public
        [TestMethod]
        public void BaseService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                Assert.IsNotNull(baseService.db);
                Assert.IsInstanceOfType(baseService.db, typeof(CSSPWebToolsDBEntities));
                Assert.IsNotNull(baseService.LanguageRequest);
                Assert.IsInstanceOfType(baseService.User, typeof(IPrincipal));
                Assert.IsNotNull(baseService.User);
                Assert.AreEqual(user.Identity.Name, baseService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), baseService.LanguageRequest);
                Assert.AreEqual(1000000, baseService.TakeMax);
                Assert.AreEqual(@"E:\inetpub\wwwroot\csspwebtools\App_Data\", baseService.BasePath);
                Assert.AreEqual(6378137.0, baseService.R);
                Assert.AreEqual(Math.PI / 180, baseService.d2r);
                Assert.AreEqual(180 / Math.PI, baseService.r2d);
                Assert.AreEqual("CSSPWebToolsDBTest", baseService.DBName);
                Assert.AreEqual(2, baseService.LanguageListAllowable.Count);
                Assert.AreEqual(LanguageEnum.en, baseService.LanguageListAllowable[0]);
                Assert.AreEqual(LanguageEnum.fr, baseService.LanguageListAllowable[1]);
                Assert.AreEqual(22, baseService.tvTypeNamesAndPathList.Count);
                Assert.AreEqual("p1", baseService.tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Root").FirstOrDefault().TVPath);
                Assert.AreEqual("p1p6", baseService.tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Country").FirstOrDefault().TVPath);
                Assert.AreEqual("p1p6p18p3p19p20p15", baseService.tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Municipality").FirstOrDefault().TVPath);
                Assert.AreEqual(71, Enum.GetNames(typeof(TVTypeEnum)).Length);
                Assert.IsNotNull(baseService.random);
            }
        }
        [TestMethod]
        public void BaseService_Constructor_Bad_Culture_Test()
        {
            user = new GenericPrincipal(new GenericIdentity(contactModelListGood[0].LoginEmail, "Forms"), null);
            LanguageEnum LanguageRequest = LanguageEnum.Error;

            baseService = new BaseService(LanguageRequest, user);
            Assert.AreEqual(LanguageEnum.en, baseService.LanguageRequest);

            LanguageRequest = (LanguageEnum)10000;

            baseService = new BaseService(LanguageRequest, user);
            Assert.AreEqual(LanguageEnum.en, baseService.LanguageRequest);

        }
        [TestMethod]
        public void BaseService_DoAddChanges_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string retStr = baseService.DoAddChanges();
                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void BaseService_DoDeleteChanges_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string retStr = baseService.DoDeleteChanges();
                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void BaseService_DoUpdateChanges_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string retStr = baseService.DoUpdateChanges();
                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void BaseService_EmailOK_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                string Email = "charles.leblanc2@canada.ca";

                string retStr = baseService.EmailOK(Email);
                Assert.AreEqual("", retStr);

            }
        }
        [TestMethod]
        public void BaseService_EmailOK_IsRequired_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                string Email = "";

                string retStr = baseService.EmailOK(Email);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Email), retStr);

            }
        }
        [TestMethod]
        public void BaseService_EmailOK_MoreThan255_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                string Email = (new String("a".ToCharArray()[0], 256)).ToString();

                string retStr = baseService.EmailOK(Email);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Email, "255"), retStr);

            }
        }
        [TestMethod]
        public void BaseService_EmailOK_NotWellForm_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                string Email = "Charles.LeBlanc.ec.gc.ca";

                string retStr = baseService.EmailOK(Email);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, Email), retStr);

                Email = "Charles";

                retStr = baseService.EmailOK(Email);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, Email), retStr);

                Email = "Charles.LeBlanc";

                retStr = baseService.EmailOK(Email);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, Email), retStr);

                Email = "Charles.LeBlanc@ec";

                retStr = baseService.EmailOK(Email);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, Email), retStr);

                Email = "Charles.LeBlanc@ec@gc";

                retStr = baseService.EmailOK(Email);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, Email), retStr);

                Email = "Charles.LeB>lanc@ec.gc.ca";

                retStr = baseService.EmailOK(Email);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, Email), retStr);

                Email = "Char<les.LeBlanc@ec.gc.ca";

                retStr = baseService.EmailOK(Email);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, Email), retStr);

                Email = "Charles.LeBlanc@1234";

                retStr = baseService.EmailOK(Email);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, Email), retStr);

            }
        }
        [TestMethod]
        public void BaseService_FillPolSourceObsInfoChild_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                baseService.polSourceObsInfoChildList.Clear();

                baseService._BaseModelService.FillPolSourceObsInfoChild(baseService.polSourceObsInfoChildList);
                Assert.AreEqual(319, baseService.polSourceObsInfoChildList.Count);
                PolSourceObsInfoEnum polSourceObsInfoEnum = PolSourceObsInfoEnum.WaterSewageStart;
                List<PolSourceObsInfoChild> polSourceObsInfoChildList = baseService.polSourceObsInfoChildList.Where(c => c.PolSourceObsInfoChildStart == polSourceObsInfoEnum).ToList();
                Assert.AreEqual(6, polSourceObsInfoChildList.Count);
            }
        }
        [TestMethod]
        public void BaseService_FillTVTypeNamesAndPathList_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                baseService.tvTypeNamesAndPathList.Clear();

                baseService.FillTVTypeNamesAndPathList();
                Assert.AreEqual(22, baseService.tvTypeNamesAndPathList.Count);
                Assert.AreEqual("p1", baseService.tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Root").FirstOrDefault().TVPath);
                Assert.AreEqual("p1p6", baseService.tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Country").FirstOrDefault().TVPath);
                Assert.AreEqual("p1p6p18p3p19p20p15", baseService.tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Municipality").FirstOrDefault().TVPath);
            }
        }
        [TestMethod]
        public void BaseService_GetContactLoggedInDB_GoodUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                ContactModel contactModel = baseService.GetContactLoggedInDB();
                Assert.AreEqual(contactModelListGood[0].LoginEmail.ToLower(), contactModel.LoginEmail.ToLower());
            }
        }
        [TestMethod]
        public void BaseService_GetContactLoggedInDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                ContactModel contactModel = baseService.GetContactLoggedInDB();
                Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, contactModel.Error);
            }
        }
        [TestMethod]
        public void BaseService_GetContactLoggedInDB_NullUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);

                ContactModel contactModel = baseService.GetContactLoggedInDB();
                Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, contactModel.Error);
            }
        }
        [TestMethod]
        public void BaseService_GetContactModelWithContactIDDB_GoodUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                ContactModel contactModel = baseService.GetContactModelWithContactIDDB(contactModelListGood[0].ContactID);
                Assert.AreEqual(contactModelListGood[0].LoginEmail.ToLower(), contactModel.LoginEmail.ToLower());
            }
        }
        [TestMethod]
        public void BaseService_GetContactModelWithContactIDDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                int ContactID = 0;
                ContactModel contactModel = baseService.GetContactModelWithContactIDDB(ContactID);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.ContactID, ContactID), contactModel.Error);
            }
        }
        [TestMethod]
        public void BaseService_GetContactModelWithContactTVItemIDDB_GoodUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                ContactModel contactModel = baseService.GetContactModelWithContactTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                Assert.AreEqual(contactModelListGood[0].LoginEmail.ToLower(), contactModel.LoginEmail.ToLower());
            }
        }
        [TestMethod]
        public void BaseService_GetContactModelWithContactTVItemIDDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                int ContactTVItemID = 0;
                ContactModel contactModel = baseService.GetContactModelWithContactTVItemIDDB(ContactTVItemID);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.ContactTVItemID, ContactTVItemID), contactModel.Error);
            }
        }
        [TestMethod]
        public void BaseService_GetLastUpdateAndDateDB_Good_Addresses_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelCountry = randomService.RandomTVItem(TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCountry.Error);

                    TVItemModel tvItemModelProv = randomService.RandomTVItem(TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProv.Error);

                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    AddressModel addressModel = randomService.RandomAddressModel(tvItemModelCountry, tvItemModelProv, tvItemModelMunicipality, true);
                    Assert.AreEqual("", addressModel.Error);

                    int Offset_min = 240;
                    LastUpdateAndTVText lastUpdateAndText = baseService.GetLastUpdateAndDateDB("Address", addressModel.AddressID, Offset_min);
                    Assert.AreEqual(addressModel.LastUpdateDate_UTC, lastUpdateAndText.LastUpdateDate_UTC);
                    Assert.IsTrue(lastUpdateAndText.TVText.Contains(contactModelListGood[0].FirstName));
                    Assert.IsTrue(lastUpdateAndText.TVText.Contains(contactModelListGood[0].LastName));
                }
            }
        }
        [TestMethod]
        public void BaseService_GetLastUpdateAndDateDB_Good_Infrastructures_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    TVItemModel tvItemModelInfr = tvItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, "Unique Inf", TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelInfr.Error);

                    InfrastructureModel infrastructureModel = randomService.RandomInfrastructureModel(tvItemModelInfr, true);
                    Assert.AreEqual("", infrastructureModel.Error);

                    int Offset_min = 240;
                    LastUpdateAndTVText lastUpdateAndText = baseService.GetLastUpdateAndDateDB("Infrastructure", infrastructureModel.InfrastructureID, Offset_min);
                    Assert.AreEqual(infrastructureModel.LastUpdateDate_UTC, lastUpdateAndText.LastUpdateDate_UTC);
                    Assert.IsTrue(lastUpdateAndText.TVText.Contains(contactModelListGood[0].FirstName));
                    Assert.IsTrue(lastUpdateAndText.TVText.Contains(contactModelListGood[0].LastName));
                }
            }
        }
        [TestMethod]
        public void BaseService_GetTVAuthWithTVItemIDAndContactID_Admin_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = contactModelListGood[0].ContactTVItemID;
                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModel.Error);

                    int TVItemID = tvItemModel.TVItemID;
                    TVAuthEnum tvAuth = baseService.GetTVAuthWithTVItemIDAndContactID(ContactTVItemID, TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.Admin, tvAuth);
                }
            }
        }
        [TestMethod]
        public void BaseService_GetTVAuthWithTVItemIDAndContactID_TVType_Province_TVAuth_CanCreate_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = contactModelListGood[1].ContactTVItemID;
                using (TransactionScope ts = new TransactionScope())
                {
                    string retStr = RemoveAllContactAuthAndSetRootToNoAccess(ContactTVItemID);
                    Assert.AreEqual("", retStr);

                    TVItemModel tvItemModelProv = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProv.Error);

                    TVItemModel tvItemModelMunicipality = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelProv.TVItemID, TVTypeEnum.Municipality).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    TVAuthEnum tvAuth = baseService.GetTVAuthWithTVItemIDAndContactID(ContactTVItemID, tvItemModelProv.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvAuth);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndContactID(ContactTVItemID, tvItemModelMunicipality.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvAuth);

                    retStr = AddTVTypeAuth(ContactTVItemID, TVAuthEnum.Create, TVTypeEnum.Province);
                    Assert.AreEqual("", retStr);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndContactID(ContactTVItemID, tvItemModelProv.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.Create, tvAuth);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndContactID(ContactTVItemID, tvItemModelMunicipality.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.Create, tvAuth);
                }
            }
        }
        [TestMethod]
        public void BaseService_GetTVAuthWithTVItemIDAndContactID_TVItem_Province_TVAuth_CanCreate_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = contactModelListGood[1].ContactTVItemID;
                using (TransactionScope ts = new TransactionScope())
                {
                    string retStr = RemoveAllContactAuthAndSetRootToNoAccess(ContactTVItemID);
                    Assert.AreEqual("", retStr);

                    TVItemModel tvItemModelProv1 = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProv1.Error);

                    TVItemModel tvItemModelMuni1 = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelProv1.TVItemID, TVTypeEnum.Municipality).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelMuni1.Error);

                    TVItemModel tvItemModelProv2 = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, (culture.TwoLetterISOLanguageName == "en" ? "Nova Scotia" : "Nouvelle-Écosse"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProv2.Error);

                    TVItemModel tvItemModelMuni2 = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelProv2.TVItemID, TVTypeEnum.Municipality).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelMuni2.Error);

                    TVAuthEnum tvAuth = baseService.GetTVAuthWithTVItemIDAndContactID(ContactTVItemID, tvItemModelProv1.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvAuth);

                    retStr = AddTVItemAuth(ContactTVItemID, TVAuthEnum.Delete, tvItemModelProv1.TVItemID, null, null, null);
                    Assert.AreEqual("", retStr);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndContactID(ContactTVItemID, tvItemModelProv1.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.Delete, tvAuth);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndContactID(ContactTVItemID, tvItemModelMuni1.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.Delete, tvAuth);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndContactID(ContactTVItemID, tvItemModelProv2.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvAuth);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndContactID(ContactTVItemID, tvItemModelMuni2.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvAuth);
                }
            }
        }
        [TestMethod]
        public void BaseService_GetTVAuthWithTVItemIDAndLoggedInUser_TVType_Province_TVAuth_CanCreate_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = contactModelListGood[1].ContactTVItemID;
                using (TransactionScope ts = new TransactionScope())
                {
                    string retStr = RemoveAllContactAuthAndSetRootToNoAccess(ContactTVItemID);
                    Assert.AreEqual("", retStr);

                    TVItemModel tvItemModelProv = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProv.Error);

                    TVItemModel tvItemModelMunicipality = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelProv.TVItemID, TVTypeEnum.Municipality).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    SetupTest(contactModelListGood[1], culture);

                    TVAuthEnum tvAuth = baseService.GetTVAuthWithTVItemIDAndLoggedInUser(tvItemModelProv.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvAuth);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndLoggedInUser(tvItemModelMunicipality.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvAuth);

                    SetupTest(contactModelListGood[0], culture);

                    retStr = AddTVTypeAuth(ContactTVItemID, TVAuthEnum.Create, TVTypeEnum.Province);
                    Assert.AreEqual("", retStr);

                    SetupTest(contactModelListGood[1], culture);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndLoggedInUser(tvItemModelProv.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.Create, tvAuth);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndLoggedInUser(tvItemModelMunicipality.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.Create, tvAuth);

                    SetupTest(null, culture);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndLoggedInUser(tvItemModelMunicipality.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.Error, tvAuth);
                }
            }
        }
        [TestMethod]
        public void BaseService_GetTVAuthWithTVItemIDAndLoggedInUser_TVItem_Province_TVAuth_CanCreate_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int ContactTVItemID = contactModelListGood[1].ContactTVItemID;
                using (TransactionScope ts = new TransactionScope())
                {
                    string retStr = RemoveAllContactAuthAndSetRootToNoAccess(ContactTVItemID);
                    Assert.AreEqual("", retStr);

                    TVItemModel tvItemModelProv1 = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, (culture.TwoLetterISOLanguageName == "en" ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProv1.Error);

                    TVItemModel tvItemModelMuni1 = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelProv1.TVItemID, TVTypeEnum.Municipality).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelMuni1.Error);

                    TVItemModel tvItemModelProv2 = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, (culture.TwoLetterISOLanguageName == "en" ? "Nova Scotia" : "Nouvelle-Écosse"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProv2.Error);

                    TVItemModel tvItemModelMuni2 = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelProv2.TVItemID, TVTypeEnum.Municipality).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelMuni2.Error);

                    SetupTest(contactModelListGood[1], culture);

                    TVAuthEnum tvAuth = baseService.GetTVAuthWithTVItemIDAndLoggedInUser(tvItemModelProv1.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvAuth);

                    SetupTest(contactModelListGood[0], culture);

                    retStr = AddTVItemAuth(ContactTVItemID, TVAuthEnum.Delete, tvItemModelProv1.TVItemID, null, null, null);
                    Assert.AreEqual("", retStr);

                    SetupTest(contactModelListGood[1], culture);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndLoggedInUser(tvItemModelProv1.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.Delete, tvAuth);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndLoggedInUser(tvItemModelMuni1.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.Delete, tvAuth);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndLoggedInUser(tvItemModelProv2.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvAuth);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndLoggedInUser(tvItemModelMuni2.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.NoAccess, tvAuth);

                    SetupTest(null, culture);

                    tvAuth = baseService.GetTVAuthWithTVItemIDAndLoggedInUser(tvItemModelMuni2.TVItemID, null, null, null);
                    Assert.AreEqual(TVAuthEnum.Error, tvAuth);
                }
            }
        }
        [TestMethod]
        public void BaseService_IsAdministratorDB_LoggedIn_Charles_LeBlanc_ec_gc_ca_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                bool retBool = baseService.IsAdministratorDB(contactModelListGood[0].LoginEmail);
                Assert.IsTrue(retBool);

            }
        }
        [TestMethod]
        public void BaseService_IsAdministratorDB_NotLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);


                bool retBool = baseService.IsAdministratorDB(contactModelListBad[0].LoginEmail);
                Assert.IsFalse(retBool);
            }
        }
        [TestMethod]
        public void BaseService_IsAdministratorDB_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(null, culture);


                bool retBool = baseService.IsAdministratorDB("");
                Assert.IsFalse(retBool);
            }
        }
        [TestMethod]
        public void BaseService_IsContactOK_LoggedIn_Charles_LeBlanc_ec_gc_ca_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);


                ContactOK contactOK = baseService.IsContactOK();
                Assert.AreEqual(contactModel.ContactID, contactOK.ContactID);
                Assert.AreEqual("", contactOK.Error);

            }
        }
        [TestMethod]
        public void BaseService_IsContactOK_NotLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);


                ContactOK contactOK = baseService.IsContactOK();
                Assert.AreEqual(0, contactOK.ContactID);
                Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, contactOK.Error);

            }
        }
        [TestMethod]
        public void BaseService_IsContactOK_LoggedIn_EmailRequiresValidation_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                ContactOK contactOK = baseService.IsContactOK();
                Assert.AreEqual(0, contactOK.ContactID);
                Assert.AreEqual(0, contactOK.ContactTVItemID);
                Assert.AreEqual(ServiceRes.EmailRequiresValidation, contactOK.Error);

            }
        }
        [TestMethod]
        public void BaseService_IsMWQMPlannerDB_Charlesleblanc_NB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                bool retBool = baseService.IsSamplingPlannerDB(contactModelListGood[0].LoginEmail);
                Assert.AreEqual(true, retBool);
            }
        }
        [TestMethod]
        public void BaseService_IsMWQMPlannerDB_Nobody_NB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string NobodyLoginEmail = "nobodyemail";
                bool retBool = baseService.IsSamplingPlannerDB(NobodyLoginEmail);
                Assert.AreEqual(false, retBool);
            }
        }
        [TestMethod]
        public void BaseService_IsStartDateBiggerThanEndDate_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                bool retBool = baseService.IsStartDateBiggerThanEndDate(DateTime.Now, DateTime.Now.AddDays(-1));
                Assert.IsTrue(retBool);


                retBool = baseService.IsStartDateBiggerThanEndDate(DateTime.Now, DateTime.Now.AddDays(1));
                Assert.IsFalse(retBool);

                DateTime SameDate = DateTime.Now;
                retBool = baseService.IsStartDateBiggerThanEndDate(SameDate, SameDate);
                Assert.IsFalse(retBool);

            }
        }
        [TestMethod]
        public void BaseService_ReturnContactBaseError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string ErrorText = "ErrorText";
                ContactModel contactModel = baseService.ReturnContactBaseError(ErrorText);
                Assert.AreEqual(ErrorText, contactModel.Error);
            }
        }
        [TestMethod]
        public void BaseService_SampleTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                SampleTypeEnum sampleType = (SampleTypeEnum)10000;

                string retStr = baseService._BaseEnumService.SampleTypeOK(sampleType);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SampleType), retStr);

                for (int i = 101, count = Enum.GetNames(typeof(SampleTypeEnum)).Length + 100; i < count; i++)
                {
                    retStr = baseService._BaseEnumService.SampleTypeOK((SampleTypeEnum)i);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void BaseService_ScenarioStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                ScenarioStatusEnum scenarioStatus = (ScenarioStatusEnum)10000;

                string retStr = baseService._BaseEnumService.ScenarioStatusOK(scenarioStatus);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ScenarioStatus), retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ScenarioStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseService._BaseEnumService.ScenarioStatusOK((ScenarioStatusEnum)i);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void BaseService_SendEmail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                MailMessage mail = new MailMessage();

                mail.To.Add(contactModelListGood[0].LoginEmail.ToLower());
                mail.From = new MailAddress(contactModelListGood[0].LoginEmail.ToLower());
                mail.IsBodyHtml = true;
                mail.Subject = "This is the Subject";
                mail.Body = "This is the Body";

                baseService.CanSendEmail = true;

                string retStr = baseService.SendEmail(mail);
                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void BaseService_StorageDataTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                StorageDataTypeEnum storageDataType = (StorageDataTypeEnum)10000;

                string retStr = baseService._BaseEnumService.StorageDataTypeOK(storageDataType);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StorageDataType), retStr);

                for(int i = 0, count = Enum.GetNames(typeof(StorageDataTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseService._BaseEnumService.StorageDataTypeOK((StorageDataTypeEnum)i);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void BaseService_TVAuthOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                TVAuthEnum tvAuth = (TVAuthEnum)10000;

                string retStr = baseService._BaseEnumService.TVAuthOK(tvAuth);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVAuth), retStr);

                tvAuth = TVAuthEnum.Delete;

                retStr = baseService._BaseEnumService.TVAuthOK(tvAuth);
                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void BaseService_TVTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                TVTypeEnum tvType = (TVTypeEnum)10000;

                string retStr = baseService._BaseEnumService.TVTypeOK(tvType);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVType), retStr);

                tvType = TVTypeEnum.MikeScenario;

                retStr = baseService._BaseEnumService.TVTypeOK(tvType);
                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void BaseService_FieldCheckIfNotNullNotZeroInt_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                int? Value = null;
                string Res = ServiceRes.AddressTVItemID;

                string retStr = baseService.FieldCheckIfNotNullNotZeroInt(Value, Res);
                Assert.AreEqual("", retStr);

                Value = 0;

                retStr = baseService.FieldCheckIfNotNullNotZeroInt(Value, Res);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, Res), retStr);

                Value = 1;

                retStr = baseService.FieldCheckIfNotNullNotZeroInt(Value, Res);
                Assert.AreEqual("", retStr);

            }
        }
        [TestMethod]
        public void BaseService_FieldCheckIfNotNullWithinRangeDouble_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                double? Value = null;
                string Res = ServiceRes.AddressTVItemID;
                double Min = 2;
                double Max = 8;

                string retStr = baseService.FieldCheckIfNotNullWithinRangeDouble(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);

                Value = Min - 1;

                retStr = baseService.FieldCheckIfNotNullWithinRangeDouble(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, Res, Min, Max), retStr);

                Value = Max + 1;

                retStr = baseService.FieldCheckIfNotNullWithinRangeDouble(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, Res, Min, Max), retStr);

                Value = Max - 1;

                retStr = baseService.FieldCheckIfNotNullWithinRangeDouble(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);

                Value = Max;

                retStr = baseService.FieldCheckIfNotNullWithinRangeDouble(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);

                Value = Min;

                retStr = baseService.FieldCheckIfNotNullWithinRangeDouble(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void BaseService_FieldCheckIfNotNullWithinRangeInt_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                int? Value = null;
                string Res = ServiceRes.AddressTVItemID;
                int Min = 2;
                int Max = 8;

                string retStr = baseService.FieldCheckIfNotNullWithinRangeInt(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);

                Value = Min - 1;

                retStr = baseService.FieldCheckIfNotNullWithinRangeInt(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, Res, Min, Max), retStr);

                Value = Max + 1;

                retStr = baseService.FieldCheckIfNotNullWithinRangeInt(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, Res, Min, Max), retStr);

                Value = Max - 1;

                retStr = baseService.FieldCheckIfNotNullWithinRangeInt(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);

                Value = Max;

                retStr = baseService.FieldCheckIfNotNullWithinRangeInt(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);

                Value = Min;

                retStr = baseService.FieldCheckIfNotNullWithinRangeInt(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void BaseService_FieldCheckIfNotNullMaxLengthString_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                string Value = null;
                string Res = ServiceRes.AddressTVItemID;
                int Max = 8;

                string retStr = baseService.FieldCheckIfNotNullMaxLengthString(Value, Res, Max);
                Assert.AreEqual("", retStr);

                Value = (new String("a".ToCharArray()[0], Max + 1)).ToString();

                retStr = baseService.FieldCheckIfNotNullMaxLengthString(Value, Res, Max);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, Res, Max), retStr);

                Value = (new String("a".ToCharArray()[0], Max - 1)).ToString();

                retStr = baseService.FieldCheckIfNotNullMaxLengthString(Value, Res, Max);
                Assert.AreEqual("", retStr);

                Value = (new String("a".ToCharArray()[0], Max)).ToString();

                retStr = baseService.FieldCheckIfNotNullMaxLengthString(Value, Res, Max);
                Assert.AreEqual("", retStr);

            }
        }
        [TestMethod]
        public void BaseService_FieldCheckNotEmptyAndMaxLengthString_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                string Value = null;
                string Res = ServiceRes.AddressTVItemID;
                int Max = 8;

                string retStr = baseService.FieldCheckNotEmptyAndMaxLengthString(Value, Res, Max);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, Res), retStr);

                Value = "";

                retStr = baseService.FieldCheckNotEmptyAndMaxLengthString(Value, Res, Max);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, Res), retStr);

                Value = (new String("a".ToCharArray()[0], Max - 1)).ToString();

                retStr = baseService.FieldCheckNotEmptyAndMaxLengthString(Value, Res, Max);
                Assert.AreEqual("", retStr);

                Value = (new String("a".ToCharArray()[0], Max)).ToString();

                retStr = baseService.FieldCheckNotEmptyAndMaxLengthString(Value, Res, Max);
                Assert.AreEqual("", retStr);

                Value = (new String("a".ToCharArray()[0], Max + 1)).ToString();

                retStr = baseService.FieldCheckNotEmptyAndMaxLengthString(Value, Res, Max);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, Res, Max), retStr);
            }
        }
        [TestMethod]
        public void BaseService_FieldCheckNotNullBool_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                bool? Value = null;
                string Res = ServiceRes.AddressTVItemID;

                string retStr = baseService.FieldCheckNotNullBool(Value, Res);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, Res), retStr);

                Value = true;

                retStr = baseService.FieldCheckNotNullBool(Value, Res);
                Assert.AreEqual("", retStr);

                Value = false;

                retStr = baseService.FieldCheckNotNullBool(Value, Res);
                Assert.AreEqual("", retStr);

            }
        }
        [TestMethod]
        public void BaseService_FieldCheckNotNullDateTime_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                DateTime? Value = null;
                string Res = ServiceRes.AddressTVItemID;

                string retStr = baseService.FieldCheckNotNullDateTime(Value, Res);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, Res), retStr);

                Value = DateTime.Now;

                retStr = baseService.FieldCheckNotNullDateTime(Value, Res);
                Assert.AreEqual("", retStr);

            }
        }
        [TestMethod]
        public void BaseService_FieldCheckNotNullAndWithinRangeDouble_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                Double? Value = null;
                string Res = ServiceRes.AddressTVItemID;
                double Min = 3.0D;
                double Max = 6.9D;

                string retStr = baseService.FieldCheckNotNullAndWithinRangeDouble(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, Res), retStr);

                Value = Min - 1;

                retStr = baseService.FieldCheckNotNullAndWithinRangeDouble(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, Res, Min, Max), retStr);

                Value = Max + 1;

                retStr = baseService.FieldCheckNotNullAndWithinRangeDouble(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, Res, Min, Max), retStr);

                Value = Max - 1;

                retStr = baseService.FieldCheckNotNullAndWithinRangeDouble(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);

                Value = Min;

                retStr = baseService.FieldCheckNotNullAndWithinRangeDouble(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);

                Value = Max;

                retStr = baseService.FieldCheckNotNullAndWithinRangeDouble(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void BaseService_FieldCheckNotNullAndWithinRangeInt_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                int? Value = null;
                string Res = ServiceRes.AddressTVItemID;
                int Min = 3;
                int Max = 6;

                string retStr = baseService.FieldCheckNotNullAndWithinRangeInt(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, Res), retStr);

                Value = Min - 1;

                retStr = baseService.FieldCheckNotNullAndWithinRangeInt(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, Res, Min, Max), retStr);

                Value = Max + 1;

                retStr = baseService.FieldCheckNotNullAndWithinRangeInt(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, Res, Min, Max), retStr);

                Value = Max - 1;

                retStr = baseService.FieldCheckNotNullAndWithinRangeInt(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);

                Value = Min;

                retStr = baseService.FieldCheckNotNullAndWithinRangeInt(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);

                Value = Max;

                retStr = baseService.FieldCheckNotNullAndWithinRangeInt(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void BaseService_FieldCheckNotNullAndMinMaxLengthString_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                string Value = null;
                string Res = ServiceRes.AddressTVItemID;
                int Min = 20;
                int Max = 60;

                string retStr = baseService.FieldCheckNotNullAndMinMaxLengthString(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, Res), retStr);

                Value = (new String("a".ToCharArray()[0], Min - 1)).ToString();

                retStr = baseService.FieldCheckNotNullAndMinMaxLengthString(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, Res, Min), retStr);

                Value = (new String("a".ToCharArray()[0], Max + 1)).ToString();

                retStr = baseService.FieldCheckNotNullAndMinMaxLengthString(Value, Res, Min, Max);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, Res, Max), retStr);

                Value = (new String("a".ToCharArray()[0], Min)).ToString();

                retStr = baseService.FieldCheckNotNullAndMinMaxLengthString(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);

                Value = (new String("a".ToCharArray()[0], Max)).ToString();

                retStr = baseService.FieldCheckNotNullAndMinMaxLengthString(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);

                Value = (new String("a".ToCharArray()[0], Max - 1)).ToString();

                retStr = baseService.FieldCheckNotNullAndMinMaxLengthString(Value, Res, Min, Max);
                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void BaseService_FieldCheckNotZeroDouble_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                double Value = 0.0D;
                string Res = ServiceRes.AddressTVItemID;

                string retStr = baseService.FieldCheckNotZeroDouble(Value, Res);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, Res), retStr);

                Value = 1.0D;

                retStr = baseService.FieldCheckNotZeroDouble(Value, Res);
                Assert.AreEqual("", retStr);

            }
        }
        [TestMethod]
        public void BaseService_FieldCheckNotZeroInt_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                int Value = 0;
                string Res = ServiceRes.AddressTVItemID;

                string retStr = baseService.FieldCheckNotZeroInt(Value, Res);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, Res), retStr);

                Value = 1;

                retStr = baseService.FieldCheckNotZeroInt(Value, Res);
                Assert.AreEqual("", retStr);

            }
        }
        #endregion Testing Methods public

        #region Testing Methods private
        #endregion Testing Methods private

        #region Functions
        private string AddTVItemAuth(int ContactTVItemID, TVAuthEnum tvAuthEnum, int tvItemID1, int? tvItemID2, int? tvItemID3, int? tvItemID4)
        {
            TVItemUserAuthorizationModel tvItemUserAuthorizationModel = new TVItemUserAuthorizationModel()
            {
                ContactTVItemID = ContactTVItemID,
                TVAuth = tvAuthEnum,
                TVItemID1 = tvItemID1,
                TVItemID2 = tvItemID2,
                TVItemID3 = tvItemID3,
                TVItemID4 = tvItemID4,
            };

            tvItemUserAuthorizationModel = tvItemUserAuthorizationService.PostAddTVItemUserAuthorizationDB(tvItemUserAuthorizationModel);
            if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationModel.Error))
                return tvItemUserAuthorizationModel.Error;

            return "";
        }
        private string AddTVTypeAuth(int ContactTVItemID, TVAuthEnum tvAuthEnum, TVTypeEnum tvTypeEnum)
        {
            TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel = new TVTypeUserAuthorizationModel()
            {
                TVType = tvTypeEnum,
                TVAuth = tvAuthEnum,
                ContactTVItemID = ContactTVItemID,
            };

            tvTypeUserAuthorizationModel = tvTypeUserAuthorizationService.PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModel);
            if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationModel.Error))
                return tvTypeUserAuthorizationModel.Error;

            return "";
        }
        private string RemoveAllContactAuthAndSetRootToNoAccess(int ContactTVItemID)
        {
            TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageEnum.en, user);
            TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageEnum.en, user);

            List<TVTypeUserAuthorizationModel> tvTypeUserAuthorizationModelList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelListWithContactTVItemIDDB(ContactTVItemID);

            foreach (TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel in tvTypeUserAuthorizationModelList)
            {
                if (tvTypeUserAuthorizationModel.TVType != TVTypeEnum.Root)
                {
                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostDeleteTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModel.TVTypeUserAuthorizationID);
                    if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationModelRet.Error))
                        return tvTypeUserAuthorizationModelRet.Error;
                }
                else
                {
                    tvTypeUserAuthorizationModel.TVAuth = TVAuthEnum.NoAccess;

                    TVTypeUserAuthorizationModel tvTypeUserAuthorizationModelRet = tvTypeUserAuthorizationService.PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModel);
                    if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationModelRet.Error))
                        return tvTypeUserAuthorizationModelRet.Error;
                }
            }

            List<TVItemUserAuthorizationModel> tvItemUserAuthorizationModelList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationModelListWithContactTVItemIDDB(ContactTVItemID);

            foreach (TVItemUserAuthorizationModel tvItemUserAuthorizationModel in tvItemUserAuthorizationModelList)
            {
                TVItemUserAuthorizationModel tvItemUserAuthorizationModelRet = tvItemUserAuthorizationService.PostDeleteTVItemUserAuthorizationDB(tvItemUserAuthorizationModel.TVItemUserAuthorizationID);
                if (!string.IsNullOrWhiteSpace(tvItemUserAuthorizationModelRet.Error))
                    return tvItemUserAuthorizationModelRet.Error;
            }

            return "";
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
            baseService = new BaseService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemUserAuthorizationService = new TVItemUserAuthorizationService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
        }
        private void SetupShim()
        {
            shimBaseService = new ShimBaseService(baseService);
        }
        #endregion Functions
    }
}

