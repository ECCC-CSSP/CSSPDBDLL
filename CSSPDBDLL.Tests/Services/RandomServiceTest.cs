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
using System.Globalization;
using System.Threading;
using CSSPWebToolsDBDLL.Services.Fakes;
using System.Linq;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for RandomServiceTest
    /// </summary>
    [TestClass]
    public class RandomServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private RandomService randomService { get; set; }
        private TVItemService tvItemService { get; set; }
        private TideSiteService tideSiteService { get; set; }
        private AddressService addressService { get; set; }
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
        public RandomServiceTest()
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

        #region Testing Random Functions
        [TestMethod]
        public void RandomService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);

                RandomService randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
                Assert.IsNotNull(randomService.db);
                Assert.IsNotNull(randomService.LanguageRequest);
                Assert.IsNotNull(randomService.User);
                Assert.AreEqual(user.Identity.Name, randomService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), randomService.LanguageRequest);
            }
        }
        [TestMethod]
        public void RandomService_RandomAddressModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Address", "es");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelCountry = randomService.RandomTVItem(TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCountry.Error);

                    TVItemModel tvItemModelProvince = randomService.RandomTVItem(TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    AddressModel AddressModelRet = randomService.RandomAddressModel(tvItemModelCountry, tvItemModelProvince, tvItemModelMunicipality, false);
                    Assert.IsNotNull(AddressModelRet);
                    Assert.IsTrue(AddressModelRet.AddressID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Address", "es");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    AddressModel AddressModelRet2 = randomService.RandomAddressModel(tvItemModelCountry, tvItemModelProvince, tvItemModelMunicipality, true);
                    Assert.IsNotNull(AddressModelRet2);
                    Assert.IsTrue(AddressModelRet2.AddressID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Address", "es");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomAppErrLogModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "AppErrLog", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    AppErrLogModel AppErrLogModelRet = randomService.RandomAppErrLogModel(false);
                    Assert.IsNotNull(AppErrLogModelRet);
                    Assert.IsTrue(AppErrLogModelRet.AppErrLogID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "AppErrLog", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    AppErrLogModel AppErrLogModelRet2 = randomService.RandomAppErrLogModel(true);
                    Assert.IsNotNull(AppErrLogModelRet2);
                    Assert.IsTrue(AppErrLogModelRet2.AppErrLogID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "AppErrLog", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomAppTaskLanguageModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "AppTaskLanguage", "s");

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskLanguageModel AppTaskLanguageModelRet = randomService.RandomAppTaskLanguageModel(languageEnum);
                    Assert.IsNotNull(AppTaskLanguageModelRet);
                    Assert.IsTrue(AppTaskLanguageModelRet.AppTaskLanguageID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "AppTaskLanguage", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomAppTaskModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "AppTask", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelFirstTVItemID = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelFirstTVItemID.Error);

                    TVItemModel tvItemModelSecondTVItemID = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelSecondTVItemID.Error);

                    AppTaskModel AppTaskModelRet = randomService.RandomAppTaskModel(tvItemModelFirstTVItemID, tvItemModelSecondTVItemID, false);
                    Assert.IsNotNull(AppTaskModelRet);
                    Assert.IsTrue(AppTaskModelRet.AppTaskID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "AppTask", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    AppTaskModel AppTaskModelRet2 = randomService.RandomAppTaskModel(tvItemModelFirstTVItemID, tvItemModelSecondTVItemID, true);
                    Assert.IsNotNull(AppTaskModelRet2);
                    Assert.IsTrue(AppTaskModelRet2.AppTaskID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "AppTask", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomBoxModelResultModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "BoxModelResult", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelInfrastructure = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelInfrastructure.Error);

                    BoxModelModel boxModelModelRet = randomService.RandomBoxModelModel(tvItemModelInfrastructure, true);

                    BoxModelResultModel BoxModelResultModelRet = randomService.RandomBoxModelResultModel(boxModelModelRet, false);
                    Assert.IsNotNull(BoxModelResultModelRet);
                    Assert.IsTrue(BoxModelResultModelRet.BoxModelResultID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "BoxModelResult", "s");
                    Assert.AreEqual(testDBService.Count + 5, testDBService2.Count);

                    BoxModelResultModel BoxModelResultModelRet2 = randomService.RandomBoxModelResultModel(boxModelModelRet, true);
                    Assert.IsNotNull(BoxModelResultModelRet2);
                    Assert.IsTrue(BoxModelResultModelRet2.BoxModelResultID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "BoxModelResult", "s");
                    Assert.AreEqual(testDBService.Count + 5 + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomBoxModelLanguageModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "BoxModelLanguage", "s");

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelInfrastructure = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelInfrastructure.Error);

                    BoxModelModel BoxModelModelRet = randomService.RandomBoxModelModel(tvItemModelInfrastructure, true);

                    BoxModelLanguageModel BoxModelLanguageModelRet = randomService.RandomBoxModelLanguageModel(languageEnum);
                    Assert.IsNotNull(BoxModelLanguageModelRet);
                    Assert.IsTrue(BoxModelLanguageModelRet.BoxModelLanguageID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "BoxModelLanguage", "s");
                    Assert.AreEqual(testDBService.Count + 2, testDBService2.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomBoxModelModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "BoxModel", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelInfrastructure = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelInfrastructure.Error);

                    BoxModelModel BoxModelModelRet = randomService.RandomBoxModelModel(tvItemModelInfrastructure, false);
                    Assert.IsNotNull(BoxModelModelRet);
                    Assert.IsTrue(BoxModelModelRet.BoxModelID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "BoxModel", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    BoxModelModel BoxModelModelRet2 = randomService.RandomBoxModelModel(tvItemModelInfrastructure, true);
                    Assert.IsNotNull(BoxModelModelRet2);
                    Assert.IsTrue(BoxModelModelRet2.BoxModelID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "BoxModel", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomClimateDataValueModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "ClimateDataValue", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.ClimateSite);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModel.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    ClimateSiteModel ClimateSiteModel = randomService.RandomClimateSiteModel(tvItemModel, true);

                    ClimateDataValueModel ClimateDataValueModelRet = randomService.RandomClimateDataValueModel(ClimateSiteModel, false);
                    Assert.IsNotNull(ClimateDataValueModelRet);
                    Assert.IsTrue(ClimateDataValueModelRet.ClimateDataValueID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "ClimateDataValue", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    ClimateDataValueModel ClimateDataValueModelRet2 = randomService.RandomClimateDataValueModel(ClimateSiteModel, true);
                    Assert.IsNotNull(ClimateDataValueModelRet2);
                    Assert.IsTrue(ClimateDataValueModelRet2.ClimateDataValueID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "ClimateDataValue", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomClimateSiteModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "ClimateSite", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.ClimateSite);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModel.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    ClimateSiteModel ClimateSiteModelRet = randomService.RandomClimateSiteModel(tvItemModel, false);
                    Assert.IsNotNull(ClimateSiteModelRet);
                    Assert.IsTrue(ClimateSiteModelRet.ClimateSiteID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "ClimateSite", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    ClimateSiteModel ClimateSiteModelRet2 = randomService.RandomClimateSiteModel(tvItemModel, true);
                    Assert.IsNotNull(ClimateSiteModelRet2);
                    Assert.IsTrue(ClimateSiteModelRet2.ClimateSiteID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "ClimateSite", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomContactModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Contact", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    ContactModel ContactModelRet = randomService.RandomContactModel();
                    Assert.IsNotNull(ContactModelRet);
                    Assert.IsTrue(ContactModelRet.ContactID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Contact", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomEmailModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Email", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Email", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    EmailModel EmailModelRet2 = randomService.RandomEmailModel(true);
                    Assert.IsNotNull(EmailModelRet2);
                    Assert.IsTrue(EmailModelRet2.EmailID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Email", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomHydrometricDataValueModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "HydrometricDataValue", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.ClimateSite);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModel.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    HydrometricSiteModel HydrometricSiteModel = randomService.RandomHydrometricSiteModel(tvItemModelParent, tvItemModel, true);

                    HydrometricDataValueModel HydrometricDataValueModelRet = randomService.RandomHydrometricDataValueModel(HydrometricSiteModel, false);
                    Assert.IsNotNull(HydrometricDataValueModelRet);
                    Assert.IsTrue(HydrometricDataValueModelRet.HydrometricDataValueID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "HydrometricDataValue", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    HydrometricDataValueModel HydrometricDataValueModelRet2 = randomService.RandomHydrometricDataValueModel(HydrometricSiteModel, true);
                    Assert.IsNotNull(HydrometricDataValueModelRet2);
                    Assert.IsTrue(HydrometricDataValueModelRet2.HydrometricDataValueID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "HydrometricDataValue", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomHydrometricSiteModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "HydrometricSite", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.ClimateSite);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModel.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    HydrometricSiteModel HydrometricSiteModelRet = randomService.RandomHydrometricSiteModel(tvItemModelParent, tvItemModel, false);
                    Assert.IsNotNull(HydrometricSiteModelRet);
                    Assert.IsTrue(HydrometricSiteModelRet.HydrometricSiteID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "HydrometricSite", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    HydrometricSiteModel HydrometricSiteModelRet2 = randomService.RandomHydrometricSiteModel(tvItemModelParent, tvItemModel, true);
                    Assert.IsNotNull(HydrometricSiteModelRet2);
                    Assert.IsTrue(HydrometricSiteModelRet2.HydrometricSiteID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "HydrometricSite", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomInfrastructureLanguageModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "InfrastructureLanguage", "s");

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureLanguageModel InfrastructureLanguageModelRet = randomService.RandomInfrastructureLanguageModel(languageEnum);
                    Assert.IsNotNull(InfrastructureLanguageModelRet);
                    Assert.IsTrue(InfrastructureLanguageModelRet.InfrastructureLanguageID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "InfrastructureLanguage", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomInfrastructureModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Infrastructure", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModel.Error);

                    InfrastructureModel InfrastructureModelRet = randomService.RandomInfrastructureModel(tvItemModel, false);
                    Assert.IsNotNull(InfrastructureModelRet);
                    Assert.IsTrue(InfrastructureModelRet.InfrastructureID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Infrastructure", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    InfrastructureModel InfrastructureModelRet2 = randomService.RandomInfrastructureModel(tvItemModel, true);
                    Assert.IsNotNull(InfrastructureModelRet2);
                    Assert.IsTrue(InfrastructureModelRet2.InfrastructureID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Infrastructure", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMapInfoPointModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MapInfoPoint", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModel.Error);

                    MapInfoModel MapInfoModelRet = randomService.RandomMapInfoModel(tvItemModel, true);
                    Assert.AreEqual("", MapInfoModelRet.Error);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MapInfoPoint", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    MapInfoPointModel mapInfoPointModel = randomService.RandomMapInfoPointModel(MapInfoModelRet, true);
                    Assert.AreEqual("", mapInfoPointModel.Error);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MapInfoPoint", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);

                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMapInfoModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MapInfo", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModel.Error);

                    MapInfoModel MapInfoModelRet = randomService.RandomMapInfoModel(tvItemModel, false);
                    Assert.IsNotNull(MapInfoModelRet);
                    Assert.IsTrue(MapInfoModelRet.MapInfoID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MapInfo", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    MapInfoModel MapInfoModelRet2 = randomService.RandomMapInfoModel(tvItemModel, true);
                    Assert.IsNotNull(MapInfoModelRet2);
                    Assert.IsTrue(MapInfoModelRet2.MapInfoID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MapInfo", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMikeBoundaryConditionModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MikeBoundaryCondition", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModel.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    MikeBoundaryConditionModel MikeBoundaryConditionModelRet = randomService.RandomMikeBoundaryConditionModel(tvItemModelParent, tvItemModel, false);
                    Assert.IsNotNull(MikeBoundaryConditionModelRet);
                    Assert.IsTrue(MikeBoundaryConditionModelRet.MikeBoundaryConditionID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MikeBoundaryCondition", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    MikeBoundaryConditionModel MikeBoundaryConditionModelRet2 = randomService.RandomMikeBoundaryConditionModel(tvItemModelParent, tvItemModel, true);
                    Assert.IsNotNull(MikeBoundaryConditionModelRet2);
                    Assert.IsTrue(MikeBoundaryConditionModelRet2.MikeBoundaryConditionID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MikeBoundaryCondition", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMikeScenarioModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MikeScenario", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModel.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    MikeScenarioModel MikeScenarioModelRet = randomService.RandomMikeScenarioModel(tvItemModel, false);
                    Assert.IsNotNull(MikeScenarioModelRet);
                    Assert.IsTrue(MikeScenarioModelRet.MikeScenarioID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MikeScenario", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    MikeScenarioModel MikeScenarioModelRet2 = randomService.RandomMikeScenarioModel(tvItemModel, true);
                    Assert.IsNotNull(MikeScenarioModelRet2);
                    Assert.IsTrue(MikeScenarioModelRet2.MikeScenarioID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MikeScenario", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMikeSourceModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MikeSource", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeSource = randomService.RandomTVItem(TVTypeEnum.MikeSource);
                    Assert.AreEqual("", tvItemModelMikeSource.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModelMikeSource.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    MikeSourceModel MikeSourceModelRet = randomService.RandomMikeSourceModel(tvItemModelParent, tvItemModelMikeSource, false);
                    Assert.IsNotNull(MikeSourceModelRet);
                    Assert.IsTrue(MikeSourceModelRet.MikeSourceID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MikeSource", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    MikeSourceModel MikeSourceModelRet2 = randomService.RandomMikeSourceModel(tvItemModelParent, tvItemModelMikeSource, true);
                    Assert.IsNotNull(MikeSourceModelRet2);
                    Assert.IsTrue(MikeSourceModelRet2.MikeSourceID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MikeSource", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMikeSourceStartEndModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MikeSourceStartEnd", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeSource = randomService.RandomTVItem(TVTypeEnum.MikeSource);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModelMikeSource.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    MikeSourceModel mikeSourceModelRet = randomService.RandomMikeSourceModel(tvItemModelParent, tvItemModelMikeSource, true);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    MikeSourceStartEndModel MikeSourceStartEndModelRet2 = randomService.RandomMikeSourceStartEndModel(mikeSourceModelRet, true);
                    Assert.IsNotNull(MikeSourceStartEndModelRet2);
                    Assert.IsTrue(MikeSourceStartEndModelRet2.MikeSourceStartEndID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MikeSourceStartEnd", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMWQMLookupMPNModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMLookupMPN", "s");
                MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);

                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel MWQMLookupMPNModelRet = randomService.RandomMWQMLookupMPNModel(false);
                    Assert.IsNotNull(MWQMLookupMPNModelRet);
                    Assert.IsTrue(MWQMLookupMPNModelRet.MWQMLookupMPNID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMLookupMPN", "s");
                    Assert.AreEqual(0, testDBService2.Count);

                    MWQMLookupMPNModel MWQMLookupMPNModelRet2 = randomService.RandomMWQMLookupMPNModel(true);
                    Assert.IsNotNull(MWQMLookupMPNModelRet2);
                    Assert.IsTrue(MWQMLookupMPNModelRet2.MWQMLookupMPNID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMLookupMPN", "s");
                    Assert.AreEqual(1, testDBService3.Count);

                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMWQMRunLanguageModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMRunLanguage", "s");

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunLanguageModel MWQMRunLanguageModelRet = randomService.RandomMWQMRunLanguageModel(languageEnum);
                    Assert.IsNotNull(MWQMRunLanguageModelRet);
                    Assert.IsTrue(MWQMRunLanguageModelRet.MWQMRunLanguageID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMRunLanguage", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMWQMRunModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMRun", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelSubsector = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    TVItemModel tvItemModelSamplingContact = randomService.RandomTVItem(TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelSamplingContact.Error);

                    TVItemModel tvItemModelValidatorContact = randomService.RandomTVItem(TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelValidatorContact.Error);

                    TVItemModel tvItemModelRun = tvItemService.PostAddChildTVItemDB(tvItemModelSubsector.TVItemID, "unique Run", TVTypeEnum.MWQMRun);
                    Assert.AreEqual("", tvItemModelValidatorContact.Error);

                    MWQMRunModel MWQMRunModelRet = randomService.RandomMWQMRunModel(tvItemModelSubsector, tvItemModelRun, "DF", tvItemModelValidatorContact, false);
                    Assert.IsNotNull(MWQMRunModelRet);
                    Assert.IsTrue(MWQMRunModelRet.MWQMRunID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMRun", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    MWQMRunModel MWQMRunModelRet2 = randomService.RandomMWQMRunModel(tvItemModelSubsector, tvItemModelRun, "DF", tvItemModelValidatorContact, true);
                    Assert.IsNotNull(MWQMRunModelRet2);
                    Assert.IsTrue(MWQMRunModelRet2.MWQMRunID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMRun", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMWQMSampleLanguageModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSampleLanguage", "s");

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleLanguageModel MWQMSampleLanguageModelRet = randomService.RandomMWQMSampleLanguageModel(languageEnum);
                    Assert.IsNotNull(MWQMSampleLanguageModelRet);
                    Assert.IsTrue(MWQMSampleLanguageModelRet.MWQMSampleLanguageID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSampleLanguage", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMWQMSampleModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSample", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMWQMSite = randomService.RandomTVItem(TVTypeEnum.MWQMSite);
                    Assert.AreEqual("", tvItemModelMWQMSite.Error);

                    TVItemModel tvItemModelMWQMRun = randomService.RandomTVItem(TVTypeEnum.MWQMRun);
                    Assert.AreEqual("", tvItemModelMWQMRun.Error);

                    MWQMSampleModel MWQMSampleModelRet = randomService.RandomMWQMSampleModel(tvItemModelMWQMSite, tvItemModelMWQMRun, false);
                    Assert.IsNotNull(MWQMSampleModelRet);
                    Assert.AreEqual(0, MWQMSampleModelRet.MWQMSampleID);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSample", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    MWQMSampleModel MWQMSampleModelRet2 = randomService.RandomMWQMSampleModel(tvItemModelMWQMSite, tvItemModelMWQMRun, true);
                    Assert.AreEqual("", MWQMSampleModelRet2.Error);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSample", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMWQMSiteModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSite", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.MWQMSite);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModel.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    MWQMSiteModel MWQMSiteModelRet = randomService.RandomMWQMSiteModel(tvItemModel, false);
                    Assert.IsNotNull(MWQMSiteModelRet);
                    Assert.IsTrue(MWQMSiteModelRet.MWQMSiteID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSite", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    MWQMSiteModel MWQMSiteModelRet2 = randomService.RandomMWQMSiteModel(tvItemModel, true);
                    Assert.IsNotNull(MWQMSiteModelRet2);
                    Assert.IsTrue(MWQMSiteModelRet2.MWQMSiteID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSite", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMWQMSubsectorLanguageModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSubsectorLanguage", "s");

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorLanguageModel MWQMSubsectorLanguageModelRet = randomService.RandomMWQMSubsectorLanguageModel(languageEnum);
                    Assert.IsNotNull(MWQMSubsectorLanguageModelRet);
                    Assert.IsTrue(MWQMSubsectorLanguageModelRet.MWQMSubsectorLanguageID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSubsectorLanguage", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomMWQMSubsectorModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSubsector", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModel.Error);

                    MWQMSubsectorModel MWQMSubsectorModelRet = randomService.RandomMWQMSubsectorModel(tvItemModel, false);
                    Assert.IsNotNull(MWQMSubsectorModelRet);
                    Assert.IsTrue(MWQMSubsectorModelRet.MWQMSubsectorID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSubsector", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    MWQMSubsectorModel MWQMSubsectorModelRet2 = randomService.RandomMWQMSubsectorModel(tvItemModel, true);
                    Assert.IsNotNull(MWQMSubsectorModelRet2);
                    Assert.IsTrue(MWQMSubsectorModelRet2.MWQMSubsectorID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "MWQMSubsector", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomPolSourceObservationModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "PolSourceObservation", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.PolSourceSite);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModel.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    TVItemModel tvItemModelContact = tvItemService.GetTVItemModelWithTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    Assert.AreEqual("", tvItemModelContact.Error);

                    PolSourceSiteModel PolSourceSiteModelRet = randomService.RandomPolSourceSiteModel(tvItemModel, tvItemModelContact, true);
                    Assert.AreEqual("", PolSourceSiteModelRet.Error);

                    //PolSourceObservationModel PolSourceObservationModelRet = randomService.RandomPolSourceObservationModel(PolSourceSiteModelRet, tvItemModelContact, false);
                    //Assert.IsNotNull(PolSourceObservationModelRet);
                    //Assert.IsTrue(PolSourceObservationModelRet.PolSourceObservationID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "PolSourceObservation", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService2.Count);

                    //PolSourceObservationModel PolSourceObservationModelRet2 = randomService.RandomPolSourceObservationModel(PolSourceSiteModelRet, tvItemModelContact, true);
                    //Assert.IsNotNull(PolSourceObservationModelRet2);
                    //Assert.IsTrue(PolSourceObservationModelRet2.PolSourceObservationID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "PolSourceObservation", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomPolSourceSiteModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "PolSourceSite", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.PolSourceSite);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModel.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    TVItemModel tvItemModelContact = tvItemService.GetTVItemModelWithTVItemIDDB(contactModelListGood[0].ContactTVItemID);
                    Assert.AreEqual("", tvItemModelContact.Error);


                    PolSourceSiteModel PolSourceSiteModelRet = randomService.RandomPolSourceSiteModel(tvItemModel, tvItemModelContact, false);
                    Assert.IsNotNull(PolSourceSiteModelRet);
                    Assert.IsTrue(PolSourceSiteModelRet.PolSourceSiteID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "PolSourceSite", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    PolSourceSiteModel PolSourceSiteModelRet2 = randomService.RandomPolSourceSiteModel(tvItemModel, tvItemModelContact, true);
                    Assert.IsNotNull(PolSourceSiteModelRet2);
                    Assert.IsTrue(PolSourceSiteModelRet2.PolSourceSiteID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "PolSourceSite", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomRatingCurveModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "RatingCurve", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.ClimateSite);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModel.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    HydrometricSiteModel HydrometricSiteModelRet = randomService.RandomHydrometricSiteModel(tvItemModelParent, tvItemModel, true);

                    RatingCurveModel RatingCurveModelRet = randomService.RandomRatingCurveModel(HydrometricSiteModelRet, false);
                    Assert.IsNotNull(RatingCurveModelRet);
                    Assert.IsTrue(RatingCurveModelRet.RatingCurveID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "RatingCurve", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    RatingCurveModel RatingCurveModelRet2 = randomService.RandomRatingCurveModel(HydrometricSiteModelRet, true);
                    Assert.IsNotNull(RatingCurveModelRet2);
                    Assert.IsTrue(RatingCurveModelRet2.RatingCurveID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "RatingCurve", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomRatingCurveValueModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "RatingCurveValue", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.ClimateSite);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModel.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    HydrometricSiteModel HydrometricSiteModelRet = randomService.RandomHydrometricSiteModel(tvItemModelParent, tvItemModel, true);

                    RatingCurveModel RatingCurveModelRet = randomService.RandomRatingCurveModel(HydrometricSiteModelRet, true);

                    RatingCurveValueModel RatingCurveValueModelRet = randomService.RandomRatingCurveValueModel(RatingCurveModelRet, false);
                    Assert.IsNotNull(RatingCurveValueModelRet);
                    Assert.IsTrue(RatingCurveValueModelRet.RatingCurveValueID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "RatingCurveValue", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    RatingCurveValueModel RatingCurveValueModelRet2 = randomService.RandomRatingCurveValueModel(RatingCurveModelRet, true);
                    Assert.IsNotNull(RatingCurveValueModelRet2);
                    Assert.IsTrue(RatingCurveValueModelRet2.RatingCurveValueID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "RatingCurveValue", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomResetPasswordModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "ResetPassword", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel ResetPasswordModelRet = randomService.RandomResetPasswordModel(false);
                    Assert.IsNotNull(ResetPasswordModelRet);
                    Assert.IsTrue(ResetPasswordModelRet.ResetPasswordID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "ResetPassword", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    ResetPasswordModel ResetPasswordModelRet2 = randomService.RandomResetPasswordModel(true);
                    Assert.AreEqual("", ResetPasswordModelRet2.Error);
                    Assert.IsTrue(ResetPasswordModelRet2.ResetPasswordID > 0);

                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomSpillLanguageModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "SpillLanguage", "s");

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillLanguageModel SpillLanguageModelRet = randomService.RandomSpillLanguageModel(languageEnum);
                    Assert.IsNotNull(SpillLanguageModelRet);
                    Assert.IsTrue(SpillLanguageModelRet.SpillLanguageID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "SpillLanguage", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomSpillModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Spill", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    TVItemModel tvItemModelInfrastructure = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelInfrastructure.Error);

                    SpillModel SpillModelRet = randomService.RandomSpillModel(tvItemModelMunicipality, tvItemModelInfrastructure, false);
                    Assert.IsNotNull(SpillModelRet);
                    Assert.IsTrue(SpillModelRet.SpillID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Spill", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    SpillModel SpillModelRet2 = randomService.RandomSpillModel(tvItemModelMunicipality, tvItemModelInfrastructure, true);
                    Assert.IsNotNull(SpillModelRet2);
                    Assert.IsTrue(SpillModelRet2.SpillID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Spill", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomTelModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Tel", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TelModel TelModelRet = randomService.RandomTelModel(false);
                    Assert.IsNotNull(TelModelRet);
                    Assert.IsTrue(TelModelRet.TelID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Tel", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    TelModel TelModelRet2 = randomService.RandomTelModel(true);
                    Assert.IsNotNull(TelModelRet2);
                    Assert.IsTrue(TelModelRet2.TelID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Tel", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomTideDataValueModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TideDataValue", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelTideSite = randomService.RandomTVItem(TVTypeEnum.TideSite);
                    Assert.AreEqual("", tvItemModelTideSite.Error);

                    TideSiteModel tideSiteModel = tideSiteService.GetTideSiteModelWithTideSiteTVItemIDDB(tvItemModelTideSite.TVItemID);

                    TideSiteModel tideSiteModelRet = tideSiteService.GetTideSiteModelWithTideSiteTVItemIDDB(tideSiteModel.TideSiteTVItemID);
                    Assert.AreEqual("", tideSiteModelRet.Error);

                    TideDataValueModel TideDataValueModelRet = randomService.RandomTideDataValueModel(tideSiteModelRet, false);
                    Assert.IsNotNull(TideDataValueModelRet);
                    Assert.IsTrue(TideDataValueModelRet.TideDataValueID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TideDataValue", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    TideDataValueModel TideDataValueModelRet2 = randomService.RandomTideDataValueModel(tideSiteModelRet, true);
                    Assert.IsNotNull(TideDataValueModelRet2);
                    Assert.IsTrue(TideDataValueModelRet2.TideDataValueID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TideDataValue", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomTideSiteModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TideSite", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.ClimateSite);
                    Assert.AreEqual("", tvItemModel.Error);

                    TVItemModel tvItemModelParent = tvItemService.GetTVItemModelWithTVItemIDDB((int)tvItemModel.ParentID);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    TideSiteModel TideSiteModelRet = randomService.RandomTideSiteModel(tvItemModelParent, tvItemModel, false);
                    Assert.IsNotNull(TideSiteModelRet);
                    Assert.IsTrue(TideSiteModelRet.TideSiteID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TideSite", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    TideSiteModel TideSiteModelRet2 = randomService.RandomTideSiteModel(tvItemModelParent, tvItemModel, true);
                    Assert.IsNotNull(TideSiteModelRet2);
                    Assert.IsTrue(TideSiteModelRet2.TideSiteID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TideSite", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomTVFileModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVFile", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelParent.Error);

                    TVFileModel TVFileModelRet = randomService.RandomTVFileModel(tvItemModelParent, false);
                    Assert.IsNotNull(TVFileModelRet);
                    Assert.IsTrue(TVFileModelRet.TVFileID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVFile", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    TVFileModel TVFileModelRet2 = randomService.RandomTVFileModel(tvItemModelParent, true);
                    Assert.IsNotNull(TVFileModelRet2);
                    Assert.IsTrue(TVFileModelRet2.TVFileID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVFile", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomTVItemLinkModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVItemLink", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelFrom = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelFrom.Error);

                    TVItemModel tvItemModelTo = randomService.RandomTVItem(TVTypeEnum.Contact);
                    Assert.AreEqual("", tvItemModelTo.Error);

                    TVItemLinkModel TVItemLinkModelRet = randomService.RandomTVItemLinkModel(tvItemModelFrom, tvItemModelTo, false);
                    Assert.IsNotNull(TVItemLinkModelRet);
                    Assert.IsTrue(TVItemLinkModelRet.TVItemLinkID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVItemLink", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    TVItemLinkModel TVItemLinkModelRet2 = randomService.RandomTVItemLinkModel(tvItemModelFrom, tvItemModelTo, true);
                    Assert.IsNotNull(TVItemLinkModelRet2);
                    Assert.IsTrue(TVItemLinkModelRet2.TVItemLinkID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVItemLink", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomTVItemLanguageModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVItemLanguage", "s");

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLanguageModel TVItemLanguageModelRet = randomService.RandomTVItemLanguageModel(languageEnum);
                    Assert.IsNotNull(TVItemLanguageModelRet);
                    Assert.IsTrue(TVItemLanguageModelRet.TVItemLanguageID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVItemLanguage", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomTVItemModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVItem", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVTypeEnum TVType = TVTypeEnum.Province;
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVType);

                    TVItemModel TVItemModelRet = randomService.RandomTVItemModel(tvItemModelParent, TVType, false);
                    Assert.IsNotNull(TVItemModelRet);
                    Assert.IsTrue(TVItemModelRet.TVItemID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVItem", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    TVItemModel TVItemModelRet2 = randomService.RandomTVItemModel(tvItemModelParent, TVType, true);
                    Assert.IsNotNull(TVItemModelRet2);
                    Assert.IsTrue(TVItemModelRet2.TVItemID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVItem", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomTVItemUserAuthorizationModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVItemUserAuthorization", "s");
                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);

                using (TransactionScope ts = new TransactionScope())
                {

                    TVItemUserAuthorizationModel TVItemUserAuthorizationModelRet = randomService.RandomTVItemUserAuthorizationModel(false);
                    Assert.IsNotNull(TVItemUserAuthorizationModelRet);
                    Assert.IsTrue(TVItemUserAuthorizationModelRet.TVItemUserAuthorizationID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVItemUserAuthorization", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    TVItemUserAuthorizationModel TVItemUserAuthorizationModelRet2 = randomService.RandomTVItemUserAuthorizationModel(true);
                    Assert.IsNotNull(TVItemUserAuthorizationModelRet2);
                    Assert.IsTrue(TVItemUserAuthorizationModelRet2.TVItemUserAuthorizationID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "TVItemUserAuthorization", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomUseOfSiteModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "UseOfSite", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelSite = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelSite.Error);

                    TVItemModel tvItemModelSubsector = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    UseOfSiteModel UseOfSiteModelRet = randomService.RandomUseOfSiteModel(tvItemModelSite, tvItemModelSubsector, SiteTypeEnum.Climate, false);
                    Assert.IsNotNull(UseOfSiteModelRet);
                    Assert.IsTrue(UseOfSiteModelRet.UseOfSiteID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "UseOfSite", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    UseOfSiteModel UseOfSiteModelRet2 = randomService.RandomUseOfSiteModel(tvItemModelSite, tvItemModelSubsector, SiteTypeEnum.Climate, true);
                    Assert.IsNotNull(UseOfSiteModelRet2);
                    Assert.IsTrue(UseOfSiteModelRet2.UseOfSiteID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "UseOfSite", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomVPAmbientModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "VPAmbient", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelInfrastructure = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelInfrastructure.Error);

                    VPScenarioModel VPScenarioModelRet = randomService.RandomVPScenarioModel(tvItemModelInfrastructure, true);

                    VPAmbientModel VPAmbientModelRet = randomService.RandomVPAmbientModel(VPScenarioModelRet, false);
                    Assert.IsNotNull(VPAmbientModelRet);
                    Assert.IsTrue(VPAmbientModelRet.VPAmbientID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "VPAmbient", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    VPAmbientModel VPAmbientModelRet2 = randomService.RandomVPAmbientModel(VPScenarioModelRet, true);
                    Assert.IsNotNull(VPAmbientModelRet2);
                    Assert.IsTrue(VPAmbientModelRet2.VPAmbientID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "VPAmbient", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomVPResultModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "VPResult", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelInfrastructure = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelInfrastructure.Error);

                    VPScenarioModel VPScenarioModelRet = randomService.RandomVPScenarioModel(tvItemModelInfrastructure, true);

                    VPResultModel VPResultModelRet = randomService.RandomVPResultModel(VPScenarioModelRet, false);
                    Assert.IsNotNull(VPResultModelRet);
                    Assert.IsTrue(VPResultModelRet.VPResultID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "VPResult", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    VPResultModel VPResultModelRet2 = randomService.RandomVPResultModel(VPScenarioModelRet, true);
                    Assert.IsNotNull(VPResultModelRet2);
                    Assert.IsTrue(VPResultModelRet2.VPResultID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "VPResult", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomVPScenarioLanguageModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "VPScenarioLanguage", "s");

                LanguageEnum languageEnum = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioLanguageModel VPScenarioLanguageModelRet = randomService.RandomVPScenarioLanguageModel(languageEnum);
                    Assert.IsNotNull(VPScenarioLanguageModelRet);
                    Assert.IsTrue(VPScenarioLanguageModelRet.VPScenarioLanguageID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "VPScenarioLanguage", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);
                }
                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomVPScenarioModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "VPScenario", "s");

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelInfrastructure = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelInfrastructure.Error);

                    VPScenarioModel VPScenarioModelRet = randomService.RandomVPScenarioModel(tvItemModelInfrastructure, false);
                    Assert.IsNotNull(VPScenarioModelRet);
                    Assert.IsTrue(VPScenarioModelRet.VPScenarioID == 0);

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "VPScenario", "s");
                    Assert.AreEqual(testDBService.Count, testDBService2.Count);

                    VPScenarioModel VPScenarioModelRet2 = randomService.RandomVPScenarioModel(tvItemModelInfrastructure, true);
                    Assert.IsNotNull(VPScenarioModelRet2);
                    Assert.IsTrue(VPScenarioModelRet2.VPScenarioID > 0);

                    TestDBService testDBService3 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "VPScenario", "s");
                    Assert.AreEqual(testDBService.Count + 1, testDBService3.Count);


                }
                break; // only do one language
            }
        }
        #endregion Testing Random Functions

        #region Testing Methods Helpers
        [TestMethod]
        public void RandomService_RandomDateTime_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                DateTime dateTime = randomService.RandomDateTime();
                Assert.IsNotNull(dateTime);

                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomDouble_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                double Min = 10.34D;
                double Max = 20.56D;
                int TestCount = 1000;

                for (int i = 0; i < TestCount; i++)
                {
                    double retDouble = randomService.RandomDouble(Min, Max);
                    Assert.IsTrue(retDouble >= Min && retDouble <= Max);
                }

                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomEmail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string retStr = randomService.RandomEmail();
                Assert.IsTrue(retStr.Length > 0);
                Assert.IsTrue(retStr.Contains("@") == true);

                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomFloat_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                float Min = 10.34f;
                float Max = 20.56f;
                int TestCount = 1000;

                for (int i = 0; i < TestCount; i++)
                {
                    float retFloat = randomService.RandomFloat(Min, Max);
                    Assert.IsTrue(retFloat >= Min && retFloat <= Max);
                }

                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomGuid_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Guid guid = randomService.RandomGuid();
                Assert.IsNotNull(guid);

                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomInt_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int Min = 10;
                int Max = 2000;
                int TestCount = 1000;

                for (int i = 0; i < TestCount; i++)
                {
                    int retInt = randomService.RandomInt(Min, Max);
                    Assert.IsTrue(retInt >= Min && retInt <= Max);
                }

                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomPassword_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string retStr = randomService.RandomPassword();
                Assert.IsTrue(retStr.Length > 0);

                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomString_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string retStr = randomService.RandomString("", 5);
                Assert.AreEqual(5, retStr.Length);

                retStr = randomService.RandomString("slijflisjfleifj", 5);
                Assert.AreEqual(5, retStr.Length);

                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomTel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string retStr = randomService.RandomTel();
                Assert.IsTrue(retStr.Length > 0);

                break; // only do one language
            }
        }
        [TestMethod]
        public void RandomService_RandomTVItem_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = randomService.RandomTVItem(TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelProvince = randomService.RandomTVItem(TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                AddressModel addressModelNew = new AddressModel()
                {
                    AddressType = AddressTypeEnum.Mailing,
                    CountryTVItemID = tvItemModelCountry.TVItemID,
                    ProvinceTVItemID = tvItemModelProvince.TVItemID,
                    MunicipalityTVItemID = tvItemModelMunicipality.TVItemID,
                    StreetName = randomService.RandomString("Street Name ", 30),
                    StreetNumber = randomService.RandomString("23", 2),
                    StreetType = StreetTypeEnum.Street,
                };

                string TVText = addressService.CreateTVText(addressModelNew);

                TVItemModel tvItemModelAddress = addressService._TVItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Address);
                Assert.AreEqual("", tvItemModelAddress.Error);

                addressModelNew.AddressTVItemID = tvItemModelAddress.TVItemID;

                AddressModel addressModelRet = addressService.PostAddAddressDB(addressModelNew);
                Assert.AreEqual("", addressModelRet.Error);

                TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Address);
                Assert.IsNotNull(tvItemModel);
                Assert.IsTrue(tvItemModel.TVItemID > 0);
            }
        }
        #endregion Testing Methods Helpers

        #region Functions
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tideSiteService = new TideSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            addressService = new AddressService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
        }
        private void SetupShim()
        {
        }
        #endregion Functions
    }
}

