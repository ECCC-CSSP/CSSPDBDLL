using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPDBDLL.Tests.SetupInfo;
using CSSPDBDLL.Models;
using System.Security.Principal;
using CSSPDBDLL.Services;
using CSSPDBDLL.Services.Resources;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Transactions;
using CSSPDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for TVItemLinkServiceTest
    /// </summary>
    [TestClass]
    public class TVItemLinkServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "TVItemLink";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private TVItemLinkService tvItemLinkService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private TVItemLinkModel tvItemLinkModelNew { get; set; }
        private TVItemLink tvItemLink { get; set; }
        private ShimTVItemLinkService shimTVItemLinkService { get; set; }
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
        public TVItemLinkServiceTest()
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
        public void TVItemLinkService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange


                Assert.IsNotNull(tvItemLinkService);
                Assert.IsNotNull(tvItemLinkService.db);
                Assert.IsNotNull(tvItemLinkService.LanguageRequest);
                Assert.IsNotNull(tvItemLinkService.User);
                Assert.AreEqual(user.Identity.Name, tvItemLinkService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), tvItemLinkService.LanguageRequest);
            }
        }
        [TestMethod]
        public void TVItemLinkService_TVItemLinkModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    #region Good
                    SetupTest(contactModelListGood[0], culture);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);

                    string retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region FromTVItemID
                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.FromTVItemID = 0;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FromTVItemID), retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.FromTVItemID = 1;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion FromTVItemID

                    #region ToTVItemID
                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.ToTVItemID = 0;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ToTVItemID), retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.ToTVItemID = 1;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion ToTVItemID

                    #region FromTVType
                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.FromTVType = (TVTypeEnum)10000000;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVType), retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.FromTVType = TVTypeEnum.Contact;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion FromTVType

                    #region ToTVType
                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.ToTVType = (TVTypeEnum)10000000;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVType), retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.ToTVType = TVTypeEnum.Contact;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion ToTVType

                    #region Ordinal
                    int Min = 0;
                    int Max = 1000000;
                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.Ordinal = Min - 1;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Ordinal, Min, Max), retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.Ordinal = Min;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.Ordinal = Min + 1;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.Ordinal = Max + 1;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Ordinal, Min, Max), retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.Ordinal = Max;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.Ordinal = Max - 1;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Ordinal

                    #region TVLevel
                    Min = 0;
                    Max = 1000;
                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.TVLevel = Min - 1;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TVLevel, Min, Max), retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.TVLevel = Min;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.TVLevel = Min + 1;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.TVLevel = Max + 1;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TVLevel, Min, Max), retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.TVLevel = Max;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.TVLevel = Max - 1;

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion TVLevel

                    #region TVPath
                    Min = 2;
                    Max = 250;
                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.TVPath = randomService.RandomString("", Min - 1);

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.TVPath, Min), retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.TVPath = randomService.RandomString("", Min);

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.TVPath = randomService.RandomString("", Min + 1);

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.TVPath = randomService.RandomString("", Max + 1);

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.TVPath, Max), retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.TVPath = randomService.RandomString("", Max);

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.TVPath = randomService.RandomString("", Max - 1);

                    retStr = tvItemLinkService.TVItemLinkModelOK(tvItemLinkModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion TVPath
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_FillTVItemLink_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FillTVItemLinkModelNew(tvItemLinkModelNew);

                    ContactOK contactOK = tvItemLinkService.IsContactOK();

                    string retStr = tvItemLinkService.FillTVItemLink(tvItemLink, tvItemLinkModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, tvItemLink.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = tvItemLinkService.FillTVItemLink(tvItemLink, tvItemLinkModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, tvItemLink.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkModelCountWithFromTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    int tvItemLinkCount = tvItemLinkService.GetTVItemLinkModelCountWithFromTVItemIDDB(tvItemLinkModelRet.FromTVItemID);
                    Assert.IsTrue(tvItemLinkCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkModelCountWithToTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    int tvItemLinkCount = tvItemLinkService.GetTVItemLinkModelCountWithToTVItemIDDB(tvItemLinkModelRet.ToTVItemID);
                    Assert.IsTrue(tvItemLinkCount > 0);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkModelWithFromTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    // Act 
                    List<TVItemLinkModel> tvItemLinkModelListRet = tvItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(tvItemLinkModelRet.FromTVItemID);
                    Assert.IsTrue(tvItemLinkModelListRet.Count > 0);
                    Assert.IsTrue(tvItemLinkModelListRet.Where(c => c.FromTVItemID == tvItemLinkModelRet.FromTVItemID).Any());
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkModelWithToTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    List<TVItemLinkModel> tvItemLinkModelListRet = tvItemLinkService.GetTVItemLinkModelListWithToTVItemIDDB(tvItemLinkModelRet.ToTVItemID);
                    Assert.IsTrue(tvItemLinkModelListRet.Count > 0);
                    Assert.IsTrue(tvItemLinkModelListRet.Where(c => c.ToTVItemID == tvItemLinkModelRet.ToTVItemID).Any());
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB(tvItemLinkModelRet.FromTVItemID, tvItemLinkModelRet.ToTVItemID);

                    CompareTVItemLinkModels(tvItemLinkModelRet, tvItemLinkModelRet2);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB_CantFind_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    int Factor = 1000;
                    TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB(tvItemLinkModelRet.FromTVItemID + Factor, tvItemLinkModelRet.ToTVItemID + Factor);

                     Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemLink, ServiceRes.FromTVItemID + "," + ServiceRes.ToTVItemID, (tvItemLinkModelRet.FromTVItemID + Factor) + "," + (tvItemLinkModelRet.ToTVItemID + Factor)), tvItemLinkModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkWithFromTVItemIDAndToTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    TVItemLink tvItemLink = tvItemLinkService.GetTVItemLinkWithFromTVItemIDAndToTVItemIDDB(tvItemLinkModelRet.FromTVItemID, tvItemLinkModelRet.ToTVItemID);
                    Assert.AreEqual(tvItemLinkModelRet.TVItemLinkID, tvItemLink.TVItemLinkID);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkWithFromTVItemIDAndToTVItemIDDB_CantFind_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                      int Factor = 10000;
                    TVItemLink tvItemLink = tvItemLinkService.GetTVItemLinkWithFromTVItemIDAndToTVItemIDDB(tvItemLinkModelRet.FromTVItemID * Factor, tvItemLinkModelRet.ToTVItemID * Factor);

                     Assert.IsNull(tvItemLink);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkListWithFromTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                      List<TVItemLink> tvItemLinkModelList = tvItemLinkService.GetTVItemLinkListWithFromTVItemIDDB(tvItemLinkModelRet.FromTVItemID);

                     Assert.IsTrue(tvItemLinkModelList.Where(c => c.FromTVItemID == tvItemLinkModelRet.FromTVItemID).Any());
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkListWithFromTVItemIDDB_CantFind_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    List<TVItemLink> tvItemLinkModelList = tvItemLinkService.GetTVItemLinkListWithFromTVItemIDDB(-1);
                    Assert.AreEqual(0, tvItemLinkModelList.Count);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkListWithToTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                     List<TVItemLink> tvItemLinkModelList = tvItemLinkService.GetTVItemLinkListWithToTVItemIDDB(tvItemLinkModelRet.ToTVItemID);

                     Assert.IsTrue(tvItemLinkModelList.Where(c => c.ToTVItemID == tvItemLinkModelRet.ToTVItemID).Any());

                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkListWithToTVItemIDDB_CantFind_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    List<TVItemLink> tvItemLinkModelList = tvItemLinkService.GetTVItemLinkListWithToTVItemIDDB(-1);
                    Assert.AreEqual(0, tvItemLinkModelList.Count);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkModelWithTVItemLinkIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                     TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.GetTVItemLinkModelWithTVItemLinkIDDB(tvItemLinkModelRet.TVItemLinkID);

                     CompareTVItemLinkModels(tvItemLinkModelRet, tvItemLinkModelRet2);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkModelWithTVItemLinkIDDB_CantFind_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    int TVItemLinkID = 0;
                    TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.GetTVItemLinkModelWithTVItemLinkIDDB(TVItemLinkID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemLanguage, ServiceRes.TVItemLinkID, TVItemLinkID), tvItemLinkModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkWithTVItemLinkIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    TVItemLink tvItemLinkRet = tvItemLinkService.GetTVItemLinkWithTVItemLinkIDDB(tvItemLinkModelRet.TVItemLinkID);

                    Assert.AreEqual(tvItemLinkModelRet.TVItemLinkID, tvItemLinkRet.TVItemLinkID);
                    Assert.AreEqual(tvItemLinkModelRet.FromTVItemID, tvItemLinkRet.FromTVItemID);
                    Assert.AreEqual(tvItemLinkModelRet.ToTVItemID, tvItemLinkRet.ToTVItemID);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_GetTVItemLinkWithTVItemLinkIDDB_CantFind_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    int TVItemLinkID = 0;
                    TVItemLink tvItemLinkRet = tvItemLinkService.GetTVItemLinkWithTVItemLinkIDDB(TVItemLinkID);
                    Assert.IsNull(tvItemLinkRet);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    string ErrorText = "ErrorText";
                    TVItemLinkModel tvItemLinkModel = tvItemLinkService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, tvItemLinkModel.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostAddDeleteTVItemLinkDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();
                    TVItemLinkModel tvItemLinkModelRet2 = UpdateTestTVItemLink(tvItemLinkModelRet);

                    TVItemLinkModel tvItemLinkModelRet4 = tvItemLinkService.PostDeleteTVItemLinkWithTVItemLinkIDDB(tvItemLinkModelRet2.TVItemLinkID);
                    Assert.AreEqual("", tvItemLinkModelRet4.Error);

                     TVItemLinkModel tvItemLinkModelRet3 = tvItemLinkService.GetTVItemLinkModelWithTVItemLinkIDDB(tvItemLinkModelRet.TVItemLinkID);

                     Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemLanguage, ServiceRes.TVItemLinkID, tvItemLinkModelRet.TVItemLinkID), tvItemLinkModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostAddTVItemLinkDB_TVItemLinkModelOK_Error_Test()
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
                        shimTVItemLinkService.TVItemLinkModelOKTVItemLinkModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostAddTVItemLinkDB_IsContactOK_Error_Test()
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
                        shimTVItemLinkService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostAddTVItemLinkDB_GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB_Error_Test()
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
                        shimTVItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDBInt32Int32 = (a, b) =>
                        {
                            return new TVItemLinkModel() { Error = "" };
                        };

                        TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItemLink), tvItemLinkModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostAddTVItemLinkDB_FillTVItemLink_Error_Test()
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
                        shimTVItemLinkService.FillTVItemLinkTVItemLinkTVItemLinkModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostAddTVItemLinkDB_DoAddChanges_Error_Test()
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
                        shimTVItemLinkService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostAddTVItemLinkDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel();
                    FillTVItemLinkModelNew(tvItemLinkModelNew);
                    tvItemLinkModelNew.FromTVItemID = -1;

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemLinkService.FillTVItemLinkTVItemLinkTVItemLinkModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                        Assert.IsTrue(tvItemLinkModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostAddTVItemLinkDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();
                    Assert.IsNotNull(tvItemLinkModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, tvItemLinkModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostAddTVItemLinkDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();
                    Assert.IsNotNull(tvItemLinkModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, tvItemLinkModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithTVItemLinkIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLinkService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostDeleteTVItemLinkWithTVItemLinkIDDB(tvItemLinkModelRet.TVItemLinkID);
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithTVItemLinkIDDB_GetTVItemLinkWithTVItemLinkIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemLinkService.GetTVItemLinkWithTVItemLinkIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostDeleteTVItemLinkWithTVItemLinkIDDB(tvItemLinkModelRet.TVItemLinkID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVItemLink), tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithTVItemLinkIDDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLinkService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostDeleteTVItemLinkWithTVItemLinkIDDB(tvItemLinkModelRet.TVItemLinkID);
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB(tvItemLinkModelRet.FromTVItemID, tvItemLinkModelRet.ToTVItemID);
                    Assert.AreEqual("", tvItemLinkModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLinkService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB(tvItemLinkModelRet.FromTVItemID, tvItemLinkModelRet.ToTVItemID);
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB_GetTVItemLinkWithFromTVItemIDAndToTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemLinkService.GetTVItemLinkWithFromTVItemIDAndToTVItemIDDBInt32Int32 = (a, b) =>
                        {
                            return null;
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB(tvItemLinkModelRet.FromTVItemID, tvItemLinkModelRet.ToTVItemID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVItemLink), tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLinkService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB(tvItemLinkModelRet.FromTVItemID, tvItemLinkModelRet.ToTVItemID);
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithFromTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();
                    TVItemLinkModel tvItemLinkModelRet2 = UpdateTestTVItemLink(tvItemLinkModelRet);

                    TVItemLinkModel tvItemLinkModelRet4 = tvItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDDB(tvItemLinkModelRet2.FromTVItemID);
                    Assert.AreEqual("", tvItemLinkModelRet4.Error);

                    TVItemLinkModel tvItemLinkModelRet3 = tvItemLinkService.GetTVItemLinkModelWithTVItemLinkIDDB(tvItemLinkModelRet.TVItemLinkID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemLanguage, ServiceRes.TVItemLinkID, tvItemLinkModelRet.TVItemLinkID), tvItemLinkModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithFromTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDDB(tvItemLinkModelRet.FromTVItemID);
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithFromTVItemIDDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDDB(tvItemLinkModelRet.FromTVItemID);
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithToTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();
                    TVItemLinkModel tvItemLinkModelRet2 = UpdateTestTVItemLink(tvItemLinkModelRet);

                    TVItemLinkModel tvItemLinkModelRet4 = tvItemLinkService.PostDeleteTVItemLinkWithToTVItemIDDB(tvItemLinkModelRet2.ToTVItemID);
                    Assert.AreEqual("", tvItemLinkModelRet4.Error);

                    TVItemLinkModel tvItemLinkModelRet3 = tvItemLinkService.GetTVItemLinkModelWithTVItemLinkIDDB(tvItemLinkModelRet.TVItemLinkID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemLanguage, ServiceRes.TVItemLinkID, tvItemLinkModelRet.TVItemLinkID), tvItemLinkModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithToTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostDeleteTVItemLinkWithToTVItemIDDB(tvItemLinkModelRet.ToTVItemID);
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostDeleteTVItemLinkWithToTVItemIDDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostDeleteTVItemLinkWithToTVItemIDDB(tvItemLinkModelRet.ToTVItemID);
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostUpdateTVItemLink_TVItemLinkModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLinkService.TVItemLinkModelOKTVItemLinkModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostUpdateTVItemLinkDB(tvItemLinkModelRet);
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostUpdateTVItemLink_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLinkService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostUpdateTVItemLinkDB(tvItemLinkModelRet);
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostUpdateTVItemLink_GetTVItemLinkWithTVItemLinkIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemLinkService.GetTVItemLinkWithTVItemLinkIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostUpdateTVItemLinkDB(tvItemLinkModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVItemLink), tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostUpdateTVItemLink_GetTVItemLinkModelWithFromTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDBInt32 = (a) =>
                        {
                            return new List<TVItemLinkModel>()
                            {
                                new TVItemLinkModel() { FromTVItemID = tvItemLinkModelRet.FromTVItemID, ToTVItemID = tvItemLinkModelRet.ToTVItemID, TVItemLinkID = tvItemLinkModelRet.TVItemLinkID },
                                new TVItemLinkModel() { FromTVItemID = tvItemLinkModelRet.FromTVItemID, ToTVItemID = tvItemLinkModelRet.ToTVItemID, TVItemLinkID = tvItemLinkModelRet.TVItemLinkID + 1 },
                            };
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostUpdateTVItemLinkDB(tvItemLinkModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItemLink), tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostUpdateTVItemLink_FillTVItemLink_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLinkService.FillTVItemLinkTVItemLinkTVItemLinkModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostUpdateTVItemLinkDB(tvItemLinkModelRet);
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVItemLinkService_PostUpdateTVItemLink_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemLinkModel tvItemLinkModelRet = AddTestTVItemLink();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLinkService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostUpdateTVItemLinkDB(tvItemLinkModelRet);
                        Assert.AreEqual(ErrorText, tvItemLinkModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Function
        public TVItemLinkModel AddTestTVItemLink()
        {
            TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel();
            FillTVItemLinkModelNew(tvItemLinkModelNew);

            TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
            if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
            {
                return tvItemLinkModelRet;
            }

            Assert.IsNotNull(tvItemLinkModelRet);
            CompareTVItemLinkModels(tvItemLinkModelNew, tvItemLinkModelRet);

            return tvItemLinkModelRet;

        }
        public void CompareTVItemLinkModels(TVItemLinkModel tvItemLinkModelRet, TVItemLinkModel tvItemLinkModel)
        {
            Assert.AreEqual(tvItemLinkModelRet.FromTVItemID, tvItemLinkModel.FromTVItemID);
            Assert.AreEqual(tvItemLinkModelRet.ToTVItemID, tvItemLinkModel.ToTVItemID);
            Assert.AreEqual(tvItemLinkModelRet.FromTVType, tvItemLinkModel.FromTVType);
            Assert.AreEqual(tvItemLinkModelRet.ToTVType, tvItemLinkModel.ToTVType);
            Assert.AreEqual(tvItemLinkModelRet.Ordinal, tvItemLinkModel.Ordinal);
            Assert.AreEqual(tvItemLinkModelRet.TVLevel, tvItemLinkModel.TVLevel);
            Assert.AreEqual(tvItemLinkModelRet.TVPath, tvItemLinkModel.TVPath);
        }
        public void FillTVItemLinkModelNew(TVItemLinkModel tvItemLinkModel)
        {
            tvItemLinkModel.FromTVItemID = randomService.RandomTVItem(TVTypeEnum.Contact).TVItemID;
            tvItemLinkModel.ToTVItemID = randomService.RandomTVItem(TVTypeEnum.Municipality).TVItemID;
            tvItemLinkModel.FromTVType = TVTypeEnum.Contact;
            tvItemLinkModel.ToTVType = TVTypeEnum.Municipality;
            tvItemLinkModel.Ordinal = 3;
            tvItemLinkModel.TVLevel = 0;
            tvItemLinkModel.TVPath = "p" + tvItemLinkModel.FromTVItemID + "p" + tvItemLinkModel.ToTVItemID;

            Assert.IsTrue(tvItemLinkModel.FromTVItemID != 0);
            Assert.IsTrue(tvItemLinkModel.ToTVItemID != 0);
            Assert.IsTrue(tvItemLinkModel.FromTVType == TVTypeEnum.Contact);
            Assert.IsTrue(tvItemLinkModel.ToTVType == TVTypeEnum.Municipality);
            Assert.IsTrue(tvItemLinkModel.FromTVItemID != 0);
            Assert.IsTrue(tvItemLinkModel.Ordinal == 3);
            Assert.IsTrue(tvItemLinkModel.TVLevel == 0);
            Assert.IsTrue(tvItemLinkModel.TVPath == "p" + tvItemLinkModel.FromTVItemID + "p" + tvItemLinkModel.ToTVItemID);
        }
        public void FillTVItemLinkModelUpdate(TVItemLinkModel tvItemLinkModel)
        {
            tvItemLinkModel.FromTVItemID = randomService.RandomTVItem(TVTypeEnum.Contact).TVItemID;
            tvItemLinkModel.ToTVItemID = randomService.RandomTVItem(TVTypeEnum.Municipality).TVItemID;
            tvItemLinkModel.FromTVType = TVTypeEnum.Contact;
            tvItemLinkModel.ToTVType = TVTypeEnum.Municipality;
            tvItemLinkModel.Ordinal = 3;
            tvItemLinkModel.TVLevel = 0;
            tvItemLinkModel.TVPath = "p" + tvItemLinkModel.FromTVItemID + "p" + tvItemLinkModel.ToTVItemID;

            Assert.IsTrue(tvItemLinkModel.FromTVItemID != 0);
            Assert.IsTrue(tvItemLinkModel.ToTVItemID != 0);
            Assert.IsTrue(tvItemLinkModel.FromTVType == TVTypeEnum.Contact);
            Assert.IsTrue(tvItemLinkModel.ToTVType == TVTypeEnum.Municipality);
            Assert.IsTrue(tvItemLinkModel.FromTVItemID != 0);
            Assert.IsTrue(tvItemLinkModel.Ordinal == 3);
            Assert.IsTrue(tvItemLinkModel.TVLevel == 0);
            Assert.IsTrue(tvItemLinkModel.TVPath == "p" + tvItemLinkModel.FromTVItemID + "p" + tvItemLinkModel.ToTVItemID);

        }
        public TVItemLinkModel UpdateTestTVItemLink(TVItemLinkModel tvItemLinkModel)
        {
            FillTVItemLinkModelUpdate(tvItemLinkModel);

            TVItemLinkModel tvItemLinkModelRet2 = tvItemLinkService.PostUpdateTVItemLinkDB(tvItemLinkModel);
            if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet2.Error))
            {
                return tvItemLinkModelRet2;
            }

            Assert.IsNotNull(tvItemLinkModelRet2);
            CompareTVItemLinkModels(tvItemLinkModel, tvItemLinkModelRet2);

            return tvItemLinkModelRet2;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            tvItemLinkService = new TVItemLinkService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemLinkModelNew = new TVItemLinkModel();
            tvItemLink = new TVItemLink();
        }
        private void SetupShim()
        {
            shimTVItemLinkService = new ShimTVItemLinkService(tvItemLinkService);
        }
        #endregion Function
    }
}
