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
    /// Summary description for RatingCurveServiceTest
    /// </summary>
    [TestClass]
    public class RatingCurveServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "RatingCurve";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private RatingCurveService ratingCurveService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private RatingCurveModel ratingCurveModelNew { get; set; }
        private RatingCurve ratingCurve { get; set; }
        private ShimRatingCurveService shimRatingCurveService { get; set; }
        private RatingCurveServiceTest ratingCurveServiceTest { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimHydrometricSiteService shimHydrometricSiteService { get; set; }
        private HydrometricSiteService hydrometricSiteService { get; set; }
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
        public RatingCurveServiceTest()
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
        public void RatingCurveService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(ratingCurveService);
                Assert.IsNotNull(ratingCurveService.db);
                Assert.IsNotNull(ratingCurveService.LanguageRequest);
                Assert.IsNotNull(ratingCurveService.User);
                Assert.AreEqual(user.Identity.Name, ratingCurveService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), ratingCurveService.LanguageRequest);
            }
        }
        [TestMethod]
        public void RatingCurveService_RatingCurveModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelHydrometricSite = randomService.RandomTVItem(TVTypeEnum.HydrometricSite);
                    Assert.AreEqual("", tvItemModelHydrometricSite.Error);

                    HydrometricSiteModel hydrometricSiteModel = hydrometricSiteService.GetHydrometricSiteModelWithHydrometricSiteTVItemIDDB(tvItemModelHydrometricSite.TVItemID);
                    Assert.AreEqual("", hydrometricSiteModel.Error);

                    #region Good
                    ratingCurveModelNew.HydrometricSiteID = hydrometricSiteModel.HydrometricSiteID;
                    FillRatingCurveModel(ratingCurveModelNew);

                    string retStr = ratingCurveService.RatingCurveModelOK(ratingCurveModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region HydrometricSiteID
                    FillRatingCurveModel(ratingCurveModelNew);
                    ratingCurveModelNew.HydrometricSiteID = 0;

                    retStr = ratingCurveService.RatingCurveModelOK(ratingCurveModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.HydrometricSiteID), retStr);

                    ratingCurveModelNew.HydrometricSiteID = hydrometricSiteModel.HydrometricSiteID;
                    FillRatingCurveModel(ratingCurveModelNew);

                    retStr = ratingCurveService.RatingCurveModelOK(ratingCurveModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion HydrometricSiteID

                    #region RatingCurveNumber
                    FillRatingCurveModel(ratingCurveModelNew);
                    int Max = 50;
                    ratingCurveModelNew.RatingCurveNumber = randomService.RandomString("", 0);

                    retStr = ratingCurveService.RatingCurveModelOK(ratingCurveModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RatingCurveNumber), retStr);

                    FillRatingCurveModel(ratingCurveModelNew);
                    ratingCurveModelNew.RatingCurveNumber = randomService.RandomString("", Max + 1);

                    retStr = ratingCurveService.RatingCurveModelOK(ratingCurveModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.RatingCurveNumber, Max), retStr);

                    FillRatingCurveModel(ratingCurveModelNew);
                    ratingCurveModelNew.RatingCurveNumber = randomService.RandomString("", Max - 1);

                    retStr = ratingCurveService.RatingCurveModelOK(ratingCurveModelNew);
                    Assert.AreEqual("", retStr);

                    FillRatingCurveModel(ratingCurveModelNew);
                    ratingCurveModelNew.RatingCurveNumber = randomService.RandomString("", Max);

                    retStr = ratingCurveService.RatingCurveModelOK(ratingCurveModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion RatingCurveNumber
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_FillRatingCurve_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    RatingCurve ratingCurve = new RatingCurve();

                    FillRatingCurveModel(ratingCurveModelRet);

                    ContactOK contactOK = ratingCurveService.IsContactOK();

                    string retStr = ratingCurveService.FillRatingCurve(ratingCurve, ratingCurveModelRet, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, ratingCurve.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = ratingCurveService.FillRatingCurve(ratingCurve, ratingCurveModelRet, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, ratingCurve.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void RatingCurveService_GetRatingCurveModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    int ratingCurveCount = ratingCurveService.GetRatingCurveModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, ratingCurveCount);

                }
            }
        }
        [TestMethod]
        public void RatingCurveService_GetRatingCurveModelListWithHydrometricSiteTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    List<RatingCurveModel> ratingCurveModelList = ratingCurveService.GetRatingCurveModelListWithHydrometricSiteIDDB(ratingCurveModelRet.HydrometricSiteID);
                    Assert.IsTrue(ratingCurveModelList.Where(c => c.RatingCurveID == ratingCurveModelRet.RatingCurveID).Any());

                }
            }
        }
        [TestMethod]
        public void RatingCurveService_GetRatingCurveModelWithRatingCurveIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    RatingCurveModel ratingCurveModelRet2 = ratingCurveService.GetRatingCurveModelWithRatingCurveIDDB(ratingCurveModelRet.RatingCurveID);
                    Assert.AreEqual(ratingCurveModelRet.RatingCurveID, ratingCurveModelRet2.RatingCurveID);

                    int RatingCurveID = 0;
                    ratingCurveModelRet2 = ratingCurveService.GetRatingCurveModelWithRatingCurveIDDB(RatingCurveID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.RatingCurve, ServiceRes.RatingCurveID, RatingCurveID), ratingCurveModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void RatingCurveService_GetRatingCurveWithRatingCurveIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    RatingCurve ratingCurveRet = ratingCurveService.GetRatingCurveWithRatingCurveIDDB(ratingCurveModelRet.RatingCurveID);
                    Assert.AreEqual(ratingCurveModelRet.RatingCurveID, ratingCurveRet.RatingCurveID);

                    int RatingCurveID = 0;
                    ratingCurveRet = ratingCurveService.GetRatingCurveWithRatingCurveIDDB(RatingCurveID);
                    Assert.IsNull(ratingCurveRet);
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_GetRatingCurveExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    RatingCurve ratingCurveRet = ratingCurveService.GetRatingCurveExistDB(ratingCurveModelRet);
                    Assert.AreEqual(ratingCurveModelRet.RatingCurveID, ratingCurveRet.RatingCurveID);

                    ratingCurveModelRet.HydrometricSiteID = 0;
                    ratingCurveRet = ratingCurveService.GetRatingCurveExistDB(ratingCurveModelRet);
                    Assert.IsNull(ratingCurveRet);
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostAddUpdateDeleteRatingCurveDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    RatingCurveModel ratingCurveModelRet2 = UpdateRatingCurveModel(ratingCurveModelRet);

                    RatingCurveModel ratingCurveModelRet3 = ratingCurveService.PostDeleteRatingCurveDB(ratingCurveModelRet2.RatingCurveID);
                    Assert.AreEqual("", ratingCurveModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostAddRatingCurveDB_RatingCurveModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.RatingCurveModelOKRatingCurveModel = (a) =>
                        {
                            return ErrorText;
                        };

                        RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();
                        Assert.AreEqual(ErrorText, ratingCurveModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostAddRatingCurveDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();
                        Assert.AreEqual(ErrorText, ratingCurveModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostAddRatingCurveDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimHydrometricSiteService.GetHydrometricSiteModelWithHydrometricSiteIDDBInt32 = (a) =>
                        {
                            return new HydrometricSiteModel() { Error = ErrorText };
                        };

                        RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();
                        Assert.AreEqual(ErrorText, ratingCurveModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostAddRatingCurveDB_GetRatingCurveExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.GetRatingCurveExistDBRatingCurveModel = (a) =>
                        {
                            return new RatingCurve();
                        };

                        RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.RatingCurve), ratingCurveModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostAddRatingCurveDB_FillRatingCurveModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.FillRatingCurveRatingCurveRatingCurveModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();
                        Assert.AreEqual(ErrorText, ratingCurveModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostAddRatingCurveDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();
                        Assert.AreEqual(ErrorText, ratingCurveModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostAddRatingCurveDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.FillRatingCurveRatingCurveRatingCurveModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();
                        Assert.IsTrue(ratingCurveModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostDeleteRatingCurveDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        RatingCurveModel ratingCurveModelRet2 = ratingCurveService.PostDeleteRatingCurveDB(ratingCurve.RatingCurveID);

                        Assert.AreEqual(ErrorText, ratingCurveModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostDeleteRatingCurveDB_GetRatingCurveWithRatingCurveIDAndRowDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.GetRatingCurveWithRatingCurveIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        RatingCurveModel ratingCurveModelRet2 = ratingCurveService.PostDeleteRatingCurveDB(ratingCurve.RatingCurveID);

                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.RatingCurve), ratingCurveModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostDeleteRatingCurveDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        RatingCurveModel ratingCurveModelRet2 = ratingCurveService.PostDeleteRatingCurveDB(ratingCurveModelRet.RatingCurveID);

                        Assert.AreEqual(ErrorText, ratingCurveModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostUpdateRatingCurveDB_RatingCurveModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.RatingCurveModelOKRatingCurveModel = (a) =>
                        {
                            return ErrorText;
                        };

                        RatingCurveModel ratingCurveModelret2 = UpdateRatingCurveModel(ratingCurveModelRet);

                        Assert.AreEqual(ErrorText, ratingCurveModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostUpdateRatingCurveDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        RatingCurveModel ratingCurveModelret2 = UpdateRatingCurveModel(ratingCurveModelRet);

                        Assert.AreEqual(ErrorText, ratingCurveModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostUpdateRatingCurveDB_GetRatingCurveWithRatingCurveIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.GetRatingCurveWithRatingCurveIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        RatingCurveModel ratingCurveModelret2 = UpdateRatingCurveModel(ratingCurveModelRet);

                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.RatingCurve), ratingCurveModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostUpdateRatingCurveDB_FillRatingCurveModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.FillRatingCurveRatingCurveRatingCurveModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        RatingCurveModel ratingCurveModelret2 = UpdateRatingCurveModel(ratingCurveModelRet);

                        Assert.AreEqual(ErrorText, ratingCurveModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostUpdateRatingCurveDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimRatingCurveService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        RatingCurveModel ratingCurveModelret2 = UpdateRatingCurveModel(ratingCurveModelRet);

                        Assert.AreEqual(ErrorText, ratingCurveModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostAddUpdateDeleteRatingDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, ratingCurveModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void RatingCurveService_PostAddUpdateDeleteRatingDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveModel ratingCurveModelRet = AddRatingCurveModel();
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, ratingCurveModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions
        public RatingCurveModel AddRatingCurveModel()
        {
            TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.HydrometricSite);
            Assert.AreEqual("", tvItemModel.Error);

            HydrometricSiteModel hydrometricSiteModel = hydrometricSiteService.GetHydrometricSiteModelWithHydrometricSiteTVItemIDDB(tvItemModel.TVItemID);
            Assert.AreEqual("", hydrometricSiteModel.Error);

            ratingCurveModelNew.HydrometricSiteID = hydrometricSiteModel.HydrometricSiteID;
            FillRatingCurveModel(ratingCurveModelNew);

            RatingCurveModel ratingCurveModelRet = ratingCurveService.PostAddRatingCurveDB(ratingCurveModelNew);
            if (!string.IsNullOrWhiteSpace(ratingCurveModelRet.Error))
            {
                return ratingCurveModelRet;
            }

            CompareRatingCurveModels(ratingCurveModelNew, ratingCurveModelRet);

            return ratingCurveModelRet;
        }
        public RatingCurveModel UpdateRatingCurveModel(RatingCurveModel ratingCurveModel)
        {
            FillRatingCurveModel(ratingCurveModel);

            RatingCurveModel ratingCurveModelRet2 = ratingCurveService.PostUpdateRatingCurveDB(ratingCurveModel);
            if (!string.IsNullOrWhiteSpace(ratingCurveModelRet2.Error))
            {
                return ratingCurveModelRet2;
            }

            CompareRatingCurveModels(ratingCurveModel, ratingCurveModelRet2);

            return ratingCurveModelRet2;
        }
        public void CompareRatingCurveModels(RatingCurveModel ratingCurveModelNew, RatingCurveModel ratingCurveModelRet)
        {
            Assert.AreEqual(ratingCurveModelNew.HydrometricSiteID, ratingCurveModelRet.HydrometricSiteID);
            Assert.AreEqual(ratingCurveModelNew.RatingCurveNumber, ratingCurveModelRet.RatingCurveNumber);
        }
        public void FillRatingCurveModel(RatingCurveModel ratingCurveModel)
        {
            ratingCurveModel.HydrometricSiteID = ratingCurveModel.HydrometricSiteID;
            ratingCurveModel.RatingCurveNumber = randomService.RandomString("Rating Curve", 30);

            Assert.IsTrue(ratingCurveModel.HydrometricSiteID != 0);
            Assert.IsTrue(ratingCurveModel.RatingCurveNumber.Length == 30);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            ratingCurveService = new RatingCurveService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            hydrometricSiteService = new HydrometricSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            ratingCurveModelNew = new RatingCurveModel();
            ratingCurve = new RatingCurve();
        }
        private void SetupShim()
        {
            shimRatingCurveService = new ShimRatingCurveService(ratingCurveService);
            shimTVItemService = new ShimTVItemService(ratingCurveService._TVItemService);
            shimHydrometricSiteService = new ShimHydrometricSiteService(ratingCurveService._HydrometricSiteService);
        }
        #endregion Functions
    }
}

