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
    /// Summary description for MWQMPlanSubsectorSiteServiceTest
    /// </summary>
    [TestClass]
    public class MWQMPlanSubsectorSiteServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MWQMPlanSubsectorSite";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MWQMPlanSubsectorSiteService labContractSubsectorSiteService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelNew { get; set; }
        private MWQMPlanSubsectorSite labContractSubsectorSite { get; set; }
        private ShimMWQMPlanSubsectorSiteService shimMWQMPlanSubsectorSiteService { get; set; }
        private MWQMPlanSubsectorServiceTest labContractSubsectorServiceTest { get; set; }
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
        public MWQMPlanSubsectorSiteServiceTest()
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
        public void MWQMPlanSubsectorSiteService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(labContractSubsectorSiteService);
                Assert.IsNotNull(labContractSubsectorSiteService.db);
                Assert.IsNotNull(labContractSubsectorSiteService.LanguageRequest);
                Assert.IsNotNull(labContractSubsectorSiteService.User);
                Assert.AreEqual(user.Identity.Name, labContractSubsectorSiteService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), labContractSubsectorSiteService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_MWQMPlanSubsectorSiteModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModel = labContractSubsectorServiceTest.AddMWQMPlanSubsectorModel();
                    Assert.AreEqual("", labContractSubsectorModel.Error);

                    TVItemModel tvItemModelRet = randomService.RandomTVItem(TVTypeEnum.MWQMSite);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    #region Good
                    labContractSubsectorSiteModelNew.MWQMPlanSubsectorID = labContractSubsectorModel.MWQMPlanSubsectorID;
                    labContractSubsectorSiteModelNew.MWQMSiteTVItemID = tvItemModelRet.TVItemID;
                    FillMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelNew);

                    string retStr = labContractSubsectorSiteService.MWQMPlanSubsectorSiteModelOK(labContractSubsectorSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region MWQMPlanSubsectorID
                    labContractSubsectorSiteModelNew.MWQMPlanSubsectorID = tvItemModelRet.TVItemID;
                    FillMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelNew);
                    labContractSubsectorSiteModelNew.MWQMPlanSubsectorID = 0;

                    retStr = labContractSubsectorSiteService.MWQMPlanSubsectorSiteModelOK(labContractSubsectorSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMPlanSubsectorID), retStr);

                    labContractSubsectorSiteModelNew.MWQMPlanSubsectorID = tvItemModelRet.TVItemID;
                    FillMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelNew);
                    labContractSubsectorSiteModelNew.MWQMPlanSubsectorID = 1;

                    retStr = labContractSubsectorSiteService.MWQMPlanSubsectorSiteModelOK(labContractSubsectorSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMPlanSubsectorID

                    #region MWQMSiteTVItemID
                    labContractSubsectorSiteModelNew.MWQMSiteTVItemID = tvItemModelRet.TVItemID;
                    FillMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelNew);
                    labContractSubsectorSiteModelNew.MWQMSiteTVItemID = 0;

                    retStr = labContractSubsectorSiteService.MWQMPlanSubsectorSiteModelOK(labContractSubsectorSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID), retStr);

                    labContractSubsectorSiteModelNew.MWQMSiteTVItemID = tvItemModelRet.TVItemID;
                    FillMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelNew);
                    labContractSubsectorSiteModelNew.MWQMSiteTVItemID = 1;

                    retStr = labContractSubsectorSiteService.MWQMPlanSubsectorSiteModelOK(labContractSubsectorSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMSiteTVItemID

                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_FillMWQMPlanSubsectorSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModel = labContractSubsectorServiceTest.AddMWQMPlanSubsectorModel();
                    Assert.AreEqual("", labContractSubsectorModel.Error);

                    TVItemModel tvItemModelMWQMSite = randomService.RandomTVItem(TVTypeEnum.MWQMSite);
                    Assert.AreEqual("", tvItemModelMWQMSite.Error);

                    labContractSubsectorSiteModelNew.MWQMPlanSubsectorID = labContractSubsectorModel.MWQMPlanSubsectorID;
                    labContractSubsectorSiteModelNew.MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID;
                    FillMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelNew);

                    ContactOK contactOK = labContractSubsectorSiteService.IsContactOK();

                    string retStr = labContractSubsectorSiteService.FillMWQMPlanSubsectorSite(labContractSubsectorSite, labContractSubsectorSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, labContractSubsectorSite.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = labContractSubsectorSiteService.FillMWQMPlanSubsectorSite(labContractSubsectorSite, labContractSubsectorSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, labContractSubsectorSite.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_GetMWQMPlanSubsectorSiteModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();
                    Assert.AreEqual("", labContractSubsectorSiteModelRet.Error);

                    int labContractCount = labContractSubsectorSiteService.GetMWQMPlanSubsectorSiteModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, labContractCount);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_GetMWQMPlanSubsectorSiteModelListWithSubsectorTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    List<MWQMPlanSubsectorSiteModel> labContractSubsectorSiteModelList = labContractSubsectorSiteService.GetMWQMPlanSubsectorSiteModelListWithMWQMPlanSubsectorIDDB(labContractSubsectorSiteModelRet.MWQMPlanSubsectorID);
                    Assert.IsTrue(labContractSubsectorSiteModelList.Where(c => c.MWQMPlanSubsectorSiteID == labContractSubsectorSiteModelRet.MWQMPlanSubsectorSiteID).Any());

                    int MWQMPlanSubsectorID = 0;
                    labContractSubsectorSiteModelList = labContractSubsectorSiteService.GetMWQMPlanSubsectorSiteModelListWithMWQMPlanSubsectorIDDB(MWQMPlanSubsectorID);
                    Assert.AreEqual(0, labContractSubsectorSiteModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_GetMWQMPlanSubsectorSiteModelWithMWQMPlanSubsectorSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet2 = labContractSubsectorSiteService.GetMWQMPlanSubsectorSiteModelWithMWQMPlanSubsectorSiteIDDB(labContractSubsectorSiteModelRet.MWQMPlanSubsectorSiteID);
                    Assert.AreEqual(labContractSubsectorSiteModelRet.MWQMPlanSubsectorSiteID, labContractSubsectorSiteModelRet2.MWQMPlanSubsectorSiteID);

                    int MWQMPlanSubsectorSiteID = 0;
                    labContractSubsectorSiteModelRet2 = labContractSubsectorSiteService.GetMWQMPlanSubsectorSiteModelWithMWQMPlanSubsectorSiteIDDB(MWQMPlanSubsectorSiteID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMPlanSubsectorSite, ServiceRes.MWQMPlanSubsectorSiteID, MWQMPlanSubsectorSiteID), labContractSubsectorSiteModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_GetMWQMPlanSubsectorSiteModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();
                    Assert.AreEqual("", labContractSubsectorSiteModelRet.Error);

                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet2 = labContractSubsectorSiteService.GetMWQMPlanSubsectorSiteModelExistDB(labContractSubsectorSiteModelRet);
                    Assert.AreEqual(labContractSubsectorSiteModelRet.MWQMPlanSubsectorSiteID, labContractSubsectorSiteModelRet2.MWQMPlanSubsectorSiteID);

                    labContractSubsectorSiteModelRet.MWQMPlanSubsectorID = 0;
                    labContractSubsectorSiteModelRet2 = labContractSubsectorSiteService.GetMWQMPlanSubsectorSiteModelExistDB(labContractSubsectorSiteModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_,
ServiceRes.MWQMPlanSubsectorSite,
ServiceRes.MWQMPlanSubsectorID + "," +
ServiceRes.MWQMSiteTVItemID,
labContractSubsectorSiteModelRet.MWQMPlanSubsectorID.ToString() + "," +
labContractSubsectorSiteModelRet.MWQMSiteTVItemID), labContractSubsectorSiteModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_GetMWQMPlanSubsectorSiteWithMWQMPlanSubsectorSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    MWQMPlanSubsectorSite labContractSubsectorSiteRet = labContractSubsectorSiteService.GetMWQMPlanSubsectorSiteWithMWQMPlanSubsectorSiteIDDB(labContractSubsectorSiteModelRet.MWQMPlanSubsectorSiteID);
                    Assert.AreEqual(labContractSubsectorSiteModelRet.MWQMPlanSubsectorSiteID, labContractSubsectorSiteRet.MWQMPlanSubsectorSiteID);

                    int MWQMPlanSubsectorSiteID = 0;
                    MWQMPlanSubsectorSite labContractSubsectorSiteRet2 = labContractSubsectorSiteService.GetMWQMPlanSubsectorSiteWithMWQMPlanSubsectorSiteIDDB(MWQMPlanSubsectorSiteID);
                    Assert.IsNull(labContractSubsectorSiteRet2);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = labContractSubsectorSiteService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, labContractSubsectorSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostAddUpdateDeleteMWQMPlanSubsectorSite_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet2 = UpdateMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelRet);

                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet3 = labContractSubsectorSiteService.PostDeleteMWQMPlanSubsectorSiteDB(labContractSubsectorSiteModelRet2.MWQMPlanSubsectorSiteID);
                    Assert.AreEqual("", labContractSubsectorSiteModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostAddMWQMPlanSubsectorSiteDB_MWQMPlanSubsectorSiteModelOK_Error_Test()
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
                        shimMWQMPlanSubsectorSiteService.MWQMPlanSubsectorSiteModelOKMWQMPlanSubsectorSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();
                        Assert.AreEqual(ErrorText, labContractSubsectorSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostAddMWQMPlanSubsectorSiteDB_IsContactOK_Error_Test()
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
                        shimMWQMPlanSubsectorSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();
                        Assert.AreEqual(ErrorText, labContractSubsectorSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostAddMWQMPlanSubsectorSiteDB_GetMWQMPlanSubsectorSiteExistDB_Error_Test()
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
                        shimMWQMPlanSubsectorSiteService.GetMWQMPlanSubsectorSiteModelExistDBMWQMPlanSubsectorSiteModel = (a) =>
                        {
                            return new MWQMPlanSubsectorSiteModel();
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMPlanSubsectorSite), labContractSubsectorSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostAddMWQMPlanSubsectorSiteDB_FillMWQMPlanSubsectorSite_Error_Test()
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
                        shimMWQMPlanSubsectorSiteService.FillMWQMPlanSubsectorSiteMWQMPlanSubsectorSiteMWQMPlanSubsectorSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();
                        Assert.AreEqual(ErrorText, labContractSubsectorSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostAddMWQMPlanSubsectorSiteDB_DoAddChanges_Error_Test()
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
                        shimMWQMPlanSubsectorSiteService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();
                        Assert.AreEqual(ErrorText, labContractSubsectorSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostAddMWQMPlanSubsectorSiteDB_Add_Error_Test()
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
                        shimMWQMPlanSubsectorSiteService.FillMWQMPlanSubsectorSiteMWQMPlanSubsectorSiteMWQMPlanSubsectorSiteModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();
                        Assert.IsTrue(labContractSubsectorSiteModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostAddMWQMPlanSubsectorSiteDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();
                    Assert.IsNotNull(labContractSubsectorSiteModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, labContractSubsectorSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostAddMWQMPlanSubsectorSiteDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();
                    Assert.IsNotNull(labContractSubsectorSiteModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, labContractSubsectorSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostDeleteMWQMPlanSubsectorSite_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet2 = labContractSubsectorSiteService.PostDeleteMWQMPlanSubsectorSiteDB(labContractSubsectorSiteModelRet.MWQMPlanSubsectorSiteID);
                        Assert.AreEqual(ErrorText, labContractSubsectorSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostDeleteMWQMPlanSubsectorSite_GetMWQMPlanSubsectorSiteWithMWQMPlanSubsectorSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorSiteService.GetMWQMPlanSubsectorSiteWithMWQMPlanSubsectorSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet2 = labContractSubsectorSiteService.PostDeleteMWQMPlanSubsectorSiteDB(labContractSubsectorSiteModelRet.MWQMPlanSubsectorSiteID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMPlanSubsectorSite), labContractSubsectorSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostDeleteMWQMPlanSubsectorSite_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorSiteService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet2 = labContractSubsectorSiteService.PostDeleteMWQMPlanSubsectorSiteDB(labContractSubsectorSiteModelRet.MWQMPlanSubsectorSiteID);
                        Assert.AreEqual(ErrorText, labContractSubsectorSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostUpdateMWQMPlanSubsectorSite_MWQMPlanSubsectorSiteModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorSiteService.MWQMPlanSubsectorSiteModelOKMWQMPlanSubsectorSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet2 = UpdateMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelRet);
                        Assert.AreEqual(ErrorText, labContractSubsectorSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostUpdateMWQMPlanSubsectorSite_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet2 = UpdateMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelRet);
                        Assert.AreEqual(ErrorText, labContractSubsectorSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostUpdateMWQMPlanSubsectorSite_GetMWQMPlanSubsectorSiteWithMWQMPlanSubsectorSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorSiteService.GetMWQMPlanSubsectorSiteWithMWQMPlanSubsectorSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet2 = UpdateMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMPlanSubsectorSite), labContractSubsectorSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostUpdateMWQMPlanSubsectorSite_FillMWQMPlanSubsectorSite_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorSiteService.FillMWQMPlanSubsectorSiteMWQMPlanSubsectorSiteMWQMPlanSubsectorSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet2 = UpdateMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelRet);
                        Assert.AreEqual(ErrorText, labContractSubsectorSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostUpdateMWQMPlanSubsectorSite_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorSiteService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet2 = UpdateMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelRet);
                        Assert.AreEqual(ErrorText, labContractSubsectorSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostAddMWQMPlanSubsectorSiteAndMWQMPlanSubsectorSiteLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, labContractSubsectorSiteModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorSiteService_PostAddMWQMPlanSubsectorSiteAndMWQMPlanSubsectorSiteLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = AddMWQMPlanSubsectorSiteModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, labContractSubsectorSiteModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public MWQMPlanSubsectorSiteModel AddMWQMPlanSubsectorSiteModel()
        {
            MWQMPlanSubsectorModel labContractSubsectorModel = labContractSubsectorServiceTest.AddMWQMPlanSubsectorModel();

            if (!string.IsNullOrWhiteSpace(labContractSubsectorModel.Error))
                return new MWQMPlanSubsectorSiteModel() { Error = labContractSubsectorModel.Error };

            TVItemModel tvItemModelMWQMSite = randomService.RandomTVItem(TVTypeEnum.MWQMSite);

            if (!string.IsNullOrWhiteSpace(tvItemModelMWQMSite.Error))
                return new MWQMPlanSubsectorSiteModel() { Error = tvItemModelMWQMSite.Error };

            labContractSubsectorSiteModelNew.MWQMPlanSubsectorID = labContractSubsectorModel.MWQMPlanSubsectorID;
            labContractSubsectorSiteModelNew.MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID;
            FillMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModelNew);

            MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet = labContractSubsectorSiteService.PostAddMWQMPlanSubsectorSiteDB(labContractSubsectorSiteModelNew);
            if (!string.IsNullOrWhiteSpace(labContractSubsectorSiteModelRet.Error))
            {
                return labContractSubsectorSiteModelRet;
            }

            CompareMWQMPlanSubsectorSiteModels(labContractSubsectorSiteModelNew, labContractSubsectorSiteModelRet);

            return labContractSubsectorSiteModelRet;
        }
        public MWQMPlanSubsectorSiteModel UpdateMWQMPlanSubsectorSiteModel(MWQMPlanSubsectorSiteModel labContractSubsectorSiteModel)
        {
            FillMWQMPlanSubsectorSiteModel(labContractSubsectorSiteModel);

            MWQMPlanSubsectorSiteModel labContractModelRet2 = labContractSubsectorSiteService.PostUpdateMWQMPlanSubsectorSiteDB(labContractSubsectorSiteModel);
            if (!string.IsNullOrWhiteSpace(labContractModelRet2.Error))
            {
                return labContractModelRet2;
            }

            CompareMWQMPlanSubsectorSiteModels(labContractSubsectorSiteModel, labContractModelRet2);

            return labContractModelRet2;
        }
        private void CompareMWQMPlanSubsectorSiteModels(MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelNew, MWQMPlanSubsectorSiteModel labContractSubsectorSiteModelRet)
        {
            Assert.AreEqual(labContractSubsectorSiteModelNew.MWQMPlanSubsectorID, labContractSubsectorSiteModelRet.MWQMPlanSubsectorID);
            Assert.AreEqual(labContractSubsectorSiteModelNew.MWQMSiteTVItemID, labContractSubsectorSiteModelRet.MWQMSiteTVItemID);
        }
        private void FillMWQMPlanSubsectorSiteModel(MWQMPlanSubsectorSiteModel labContractSubsectorSiteModel)
        {
            labContractSubsectorSiteModel.MWQMPlanSubsectorID = labContractSubsectorSiteModel.MWQMPlanSubsectorID;
            labContractSubsectorSiteModel.MWQMSiteTVItemID = labContractSubsectorSiteModel.MWQMSiteTVItemID;

            Assert.IsTrue(labContractSubsectorSiteModel.MWQMPlanSubsectorID != 0);
            Assert.IsTrue(labContractSubsectorSiteModel.MWQMSiteTVItemID != 0);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            labContractSubsectorSiteService = new MWQMPlanSubsectorSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            labContractSubsectorSiteModelNew = new MWQMPlanSubsectorSiteModel();
            labContractSubsectorSite = new MWQMPlanSubsectorSite();
            labContractSubsectorServiceTest = new MWQMPlanSubsectorServiceTest();
            labContractSubsectorServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimMWQMPlanSubsectorSiteService = new ShimMWQMPlanSubsectorSiteService(labContractSubsectorSiteService);
        }
        #endregion Functions private
    }
}

