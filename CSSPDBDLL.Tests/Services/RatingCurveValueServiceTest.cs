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
using System.Linq;
using Microsoft.QualityTools.Testing.Fakes;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for RatingCurveValueServiceTest
    /// </summary>
    [TestClass]
    public class RatingCurveValueServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "RatingCurveValue";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private RatingCurveValueService ratingCurveValueService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private RatingCurveValueModel ratingCurveValueModelNew { get; set; }
        private RatingCurveValue ratingCurveValue { get; set; }
        private ShimRatingCurveValueService shimRatingCurveValueService { get; set; }
        private RatingCurveServiceTest ratingCurveServiceTest { get; set; }
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
        public RatingCurveValueServiceTest()
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
        public void RatingCurveValueService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(ratingCurveValueService);
                Assert.IsNotNull(ratingCurveValueService.db);
                Assert.IsNotNull(ratingCurveValueService.LanguageRequest);
                Assert.IsNotNull(ratingCurveValueService.User);
                Assert.AreEqual(user.Identity.Name, ratingCurveValueService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), ratingCurveValueService.LanguageRequest);
            }
        }
        [TestMethod]
        public void RatingCurveValueService_RatingCurveValueModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();
                    Assert.AreEqual("", ratingCurveValueModelRet.Error);

                    #region Good
                    ratingCurveValueModelNew.RatingCurveID = ratingCurveValueModelRet.RatingCurveID;
                    FillRatingCurveValueModel(ratingCurveValueModelNew);

                    string retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region RatingCurveID
                    FillRatingCurveValueModel(ratingCurveValueModelNew);
                    ratingCurveValueModelNew.RatingCurveID = 0;

                    retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RatingCurveID), retStr);

                    ratingCurveValueModelNew.RatingCurveID = ratingCurveValueModelRet.RatingCurveID;
                    FillRatingCurveValueModel(ratingCurveValueModelNew);

                    retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion RatingCurveID

                    #region StageValue_m
                    FillRatingCurveValueModel(ratingCurveValueModelNew);
                    double Min = -1D;
                    double Max = 10000D;
                    ratingCurveValueModelNew.StageValue_m = Min - 1;

                    retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.StageValue_m, Min, Max), retStr);

                    FillRatingCurveValueModel(ratingCurveValueModelNew);
                    ratingCurveValueModelNew.StageValue_m = Max + 1;

                    retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.StageValue_m, Min, Max), retStr);

                    FillRatingCurveValueModel(ratingCurveValueModelNew);
                    ratingCurveValueModelNew.StageValue_m = Max - 1;

                    retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillRatingCurveValueModel(ratingCurveValueModelNew);
                    ratingCurveValueModelNew.StageValue_m = Min;

                    retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillRatingCurveValueModel(ratingCurveValueModelNew);
                    ratingCurveValueModelNew.StageValue_m = Max;

                    retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion StageValue_m

                    #region DischargeValue_m3_s
                    FillRatingCurveValueModel(ratingCurveValueModelNew);
                    Min = 0D;
                    Max = 100000D;
                    ratingCurveValueModelNew.DischargeValue_m3_s = Min - 1;

                    retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DischargeValue_m3_s, Min, Max), retStr);

                    FillRatingCurveValueModel(ratingCurveValueModelNew);
                    ratingCurveValueModelNew.DischargeValue_m3_s = Max + 1;

                    retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DischargeValue_m3_s, Min, Max), retStr);

                    FillRatingCurveValueModel(ratingCurveValueModelNew);
                    ratingCurveValueModelNew.DischargeValue_m3_s = Max - 1;

                    retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillRatingCurveValueModel(ratingCurveValueModelNew);
                    ratingCurveValueModelNew.DischargeValue_m3_s = Min;

                    retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillRatingCurveValueModel(ratingCurveValueModelNew);
                    ratingCurveValueModelNew.DischargeValue_m3_s = Max;

                    retStr = ratingCurveValueService.RatingCurveValueModelOK(ratingCurveValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion DischargeValue_m3_s

                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_FillRatingCurveValue_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveModelRet = AddRatingCurveValueModel();
                    Assert.AreEqual("", ratingCurveModelRet.Error);

                    ratingCurveValueModelNew.RatingCurveID = ratingCurveModelRet.RatingCurveID;
                    FillRatingCurveValueModel(ratingCurveValueModelNew);

                    ContactOK contactOK = ratingCurveValueService.IsContactOK();

                    string retStr = ratingCurveValueService.FillRatingCurveValue(ratingCurveValue, ratingCurveValueModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, ratingCurveValue.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = ratingCurveValueService.FillRatingCurveValue(ratingCurveValue, ratingCurveValueModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, ratingCurveValue.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_GetRatingCurveValueModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    int ratingCurveValueCount = ratingCurveValueService.GetRatingCurveValueModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, ratingCurveValueCount);
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_GetRatingCurveValueModelListWithRatingCurveIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    List<RatingCurveValueModel> ratingCurveValueModelList = ratingCurveValueService.GetRatingCurveValueModelListWithRatingCurveIDDB(ratingCurveValueModelRet.RatingCurveID);
                    Assert.IsTrue(ratingCurveValueModelList.Where(c => c.RatingCurveValueID == ratingCurveValueModelRet.RatingCurveValueID).Any());

                    int RatingCurveValueID = 0;
                    ratingCurveValueModelList = ratingCurveValueService.GetRatingCurveValueModelListWithRatingCurveIDDB(RatingCurveValueID);
                    Assert.AreEqual(0, ratingCurveValueModelList.Count);
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_GetRatingCurveValueModelWithRatingCurveValueIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    RatingCurveValueModel ratingCurveValueModelRet2 = ratingCurveValueService.GetRatingCurveValueModelWithRatingCurveValueIDDB(ratingCurveValueModelRet.RatingCurveValueID);
                    Assert.AreEqual(ratingCurveValueModelRet.RatingCurveValueID, ratingCurveValueModelRet2.RatingCurveValueID);

                    int RatingCurveValueID = 0;
                    ratingCurveValueModelRet2 = ratingCurveValueService.GetRatingCurveValueModelWithRatingCurveValueIDDB(RatingCurveValueID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.RatingCurveValue, ServiceRes.RatingCurveValueID, RatingCurveValueID), ratingCurveValueModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_GetRatingCurveValueWithRatingCurveValueIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    RatingCurveValue ratingCurveValueRet = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueIDDB(ratingCurveValueModelRet.RatingCurveValueID);
                    Assert.AreEqual(ratingCurveValueModelRet.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    RatingCurveValue ratingCurveValueRet2 = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueIDDB(0);
                    Assert.IsNull(ratingCurveValueRet2);
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_GetRatingCurveValueExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    RatingCurveValue ratingCurveValueRet = ratingCurveValueService.GetRatingCurveValueExistDB(ratingCurveValueModelRet);
                    Assert.AreEqual(ratingCurveValueModelRet.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);

                    ratingCurveValueModelRet.RatingCurveID = 0;
                    RatingCurveValue ratingCurveValueRet2 = ratingCurveValueService.GetRatingCurveValueExistDB(ratingCurveValueModelRet);
                    Assert.IsNull(ratingCurveValueRet2);
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    RatingCurveValueModel ratingCurveValueModelRet = ratingCurveValueService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, ratingCurveValueModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostAddUpdateDeleteRatingCurveValue_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    RatingCurveValueModel ratingCurveValueModelRet2 = UpdateRatingCurveValueModel(ratingCurveValueModelRet);

                    RatingCurveValueModel ratingCurveValueModelRet3 = ratingCurveValueService.PostDeleteRatingCurveValueDB(ratingCurveValueModelRet2.RatingCurveValueID);
                    Assert.AreEqual("", ratingCurveValueModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostAddRatingCurveValueDB_RatingCurveValueModelOK_Error_Test()
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
                        shimRatingCurveValueService.RatingCurveValueModelOKRatingCurveValueModel = (a) =>
                        {
                            return ErrorText;
                        };

                        RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();
                        Assert.AreEqual(ErrorText, ratingCurveValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostAddRatingCurveValueDB_IsContactOK_Error_Test()
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
                        shimRatingCurveValueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();
                        Assert.AreEqual(ErrorText, ratingCurveValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostAddRatingCurveValueDB_GetRatingCurveValueExistDB_Error_Test()
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
                        shimRatingCurveValueService.GetRatingCurveValueExistDBRatingCurveValueModel = (a) =>
                        {
                            return new RatingCurveValue();
                        };

                        RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.RatingCurveValue), ratingCurveValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostAddRatingCurveValueDB_FillRatingCurveValue_Error_Test()
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
                        shimRatingCurveValueService.FillRatingCurveValueRatingCurveValueRatingCurveValueModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();
                        Assert.AreEqual(ErrorText, ratingCurveValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostAddRatingCurveValueDB_DoAddChanges_Error_Test()
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
                        shimRatingCurveValueService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();
                        Assert.AreEqual(ErrorText, ratingCurveValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostAddRatingCurveValueDB_Add_Error_Test()
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
                        shimRatingCurveValueService.FillRatingCurveValueRatingCurveValueRatingCurveValueModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();
                        Assert.IsTrue(ratingCurveValueModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostAddRatingCurveValueDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, ratingCurveValueModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostAddRatingCurveValueDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, ratingCurveValueModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostDeleteRatingCurveValue_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimRatingCurveValueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        RatingCurveValueModel ratingCurveValueModelRet2 = ratingCurveValueService.PostDeleteRatingCurveValueDB(ratingCurveValueModelRet.RatingCurveValueID);
                        Assert.AreEqual(ErrorText, ratingCurveValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostDeleteRatingCurveValue_GetRatingCurveValueWithRatingCurveValueIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimRatingCurveValueService.GetRatingCurveValueWithRatingCurveValueIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        RatingCurveValueModel ratingCurveValueModelRet2 = ratingCurveValueService.PostDeleteRatingCurveValueDB(ratingCurveValueModelRet.RatingCurveValueID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.RatingCurveValue), ratingCurveValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostDeleteRatingCurveValue_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimRatingCurveValueService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        RatingCurveValueModel ratingCurveValueModelRet2 = ratingCurveValueService.PostDeleteRatingCurveValueDB(ratingCurveValueModelRet.RatingCurveValueID);
                        Assert.AreEqual(ErrorText, ratingCurveValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostUpdateRatingCurveValue_RatingCurveValueModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimRatingCurveValueService.RatingCurveValueModelOKRatingCurveValueModel = (a) =>
                        {
                            return ErrorText;
                        };

                        RatingCurveValueModel ratingCurveValueModelRet2 = UpdateRatingCurveValueModel(ratingCurveValueModelRet);
                        Assert.AreEqual(ErrorText, ratingCurveValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostUpdateRatingCurveValue_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimRatingCurveValueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        RatingCurveValueModel ratingCurveValueModelRet2 = UpdateRatingCurveValueModel(ratingCurveValueModelRet);
                        Assert.AreEqual(ErrorText, ratingCurveValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostUpdateRatingCurveValue_GetRatingCurveValueWithRatingCurveValueIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimRatingCurveValueService.GetRatingCurveValueWithRatingCurveValueIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        RatingCurveValueModel ratingCurveValueModelRet2 = UpdateRatingCurveValueModel(ratingCurveValueModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.RatingCurveValue), ratingCurveValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostUpdateRatingCurveValue_FillRatingCurveValue_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimRatingCurveValueService.FillRatingCurveValueRatingCurveValueRatingCurveValueModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        RatingCurveValueModel ratingCurveValueModelRet2 = UpdateRatingCurveValueModel(ratingCurveValueModelRet);
                        Assert.AreEqual(ErrorText, ratingCurveValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostUpdateRatingCurveValue_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimRatingCurveValueService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        RatingCurveValueModel ratingCurveValueModelRet2 = UpdateRatingCurveValueModel(ratingCurveValueModelRet);
                        Assert.AreEqual(ErrorText, ratingCurveValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostAddRatingCurveValueAndRatingCurveValueLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, ratingCurveValueModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void RatingCurveValueService_PostAddRatingCurveValueAndRatingCurveValueLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValueModel ratingCurveValueModelRet = AddRatingCurveValueModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, ratingCurveValueModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Funtions
        public RatingCurveValueModel AddRatingCurveValueModel()
        {
            RatingCurveModel ratingCurveModel = ratingCurveServiceTest.AddRatingCurveModel();
            if (!string.IsNullOrWhiteSpace(ratingCurveModel.Error))
            {
                return new RatingCurveValueModel() { Error = ratingCurveModel.Error };
            }


            ratingCurveValueModelNew.RatingCurveID = ratingCurveModel.RatingCurveID;
            FillRatingCurveValueModel(ratingCurveValueModelNew);

            RatingCurveValueModel ratingCurveValueModelRet = ratingCurveValueService.PostAddRatingCurveValueDB(ratingCurveValueModelNew);
            if (!string.IsNullOrWhiteSpace(ratingCurveValueModelRet.Error))
            {
                return ratingCurveValueModelRet;
            }

            CompareRatingCurveValueModels(ratingCurveValueModelNew, ratingCurveValueModelRet);

            return ratingCurveValueModelRet;
        }
        public RatingCurveValueModel UpdateRatingCurveValueModel(RatingCurveValueModel ratingCurveValueModel)
        {
            FillRatingCurveValueModel(ratingCurveValueModel);

            RatingCurveValueModel ratingCurveValueModelRet2 = ratingCurveValueService.PostUpdateRatingCurveValueDB(ratingCurveValueModel);
            if (!string.IsNullOrWhiteSpace(ratingCurveValueModelRet2.Error))
            {
                return ratingCurveValueModelRet2;
            }

            CompareRatingCurveValueModels(ratingCurveValueModel, ratingCurveValueModelRet2);

            return ratingCurveValueModelRet2;
        }
        private void CompareRatingCurveValueModels(RatingCurveValueModel ratingCurveValueModelNew, RatingCurveValueModel ratingCurveValueModelRet)
        {
            Assert.AreEqual(ratingCurveValueModelNew.RatingCurveID, ratingCurveValueModelRet.RatingCurveID);
            Assert.AreEqual(ratingCurveValueModelNew.StageValue_m, ratingCurveValueModelRet.StageValue_m);
            Assert.AreEqual(ratingCurveValueModelNew.DischargeValue_m3_s, ratingCurveValueModelRet.DischargeValue_m3_s);
        }
        private void FillRatingCurveValueModel(RatingCurveValueModel ratingCurveValueModel)
        {
            ratingCurveValueModel.RatingCurveID = ratingCurveValueModel.RatingCurveID;
            ratingCurveValueModel.StageValue_m = randomService.RandomDouble(0, 10000);
            ratingCurveValueModel.DischargeValue_m3_s = randomService.RandomDouble(0, 100000);

            Assert.IsTrue(ratingCurveValueModel.RatingCurveID != 0);
            Assert.IsTrue(ratingCurveValueModel.StageValue_m >= 0 && ratingCurveValueModel.StageValue_m <= 10000);
            Assert.IsTrue(ratingCurveValueModel.DischargeValue_m3_s >= 0 && ratingCurveValueModel.DischargeValue_m3_s <= 100000);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            ratingCurveValueService = new RatingCurveValueService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            ratingCurveValueModelNew = new RatingCurveValueModel();
            ratingCurveValue = new RatingCurveValue();
            ratingCurveServiceTest = new RatingCurveServiceTest();
            ratingCurveServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimRatingCurveValueService = new ShimRatingCurveValueService(ratingCurveValueService);
        }
        #endregion Functions
    }
}
