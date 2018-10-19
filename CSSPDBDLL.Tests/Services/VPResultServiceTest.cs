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
    /// Summary description for VPResultServiceTest
    /// </summary>
    [TestClass]
    public class VPResultServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "VPResult";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private VPResultService vpResultService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private VPResultModel vpResultModelNew { get; set; }
        private VPResult vpResult { get; set; }
        private ShimVPResultService shimVPResultService { get; set; }
        private VPScenarioServiceTest vpScenarioServiceTest { get; set; }
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
        public VPResultServiceTest()
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
        public void VPResultService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(vpResultService);
                Assert.IsNotNull(vpResultService.db);
                Assert.IsNotNull(vpResultService.LanguageRequest);
                Assert.IsNotNull(vpResultService.User);
                Assert.AreEqual(user.Identity.Name, vpResultService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), vpResultService.LanguageRequest);
            }
        }
        [TestMethod]
        public void VPResultService_VPResultModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    vpResultModelNew.VPScenarioID = vpResultModelRet.VPScenarioID;

                    #region Good
                    FillVPResultModel(vpResultModelNew);

                    string retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region VPScenarioID
                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.VPScenarioID = 0;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioID), retStr);

                    vpResultModelNew.VPScenarioID = vpResultModelRet.VPScenarioID;
                    FillVPResultModel(vpResultModelNew);

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.IsNotNull("", retStr);

                    #endregion VPScenarioID

                    #region Ordinal
                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.Ordinal = 0;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Ordinal), retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.Ordinal = 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Ordinal

                    #region Concentration_MPN_100ml
                    FillVPResultModel(vpResultModelNew);
                    int MinInt = 0;
                    int MaxInt = 10000000;
                    vpResultModelNew.Concentration_MPN_100ml = MinInt - 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Concentration_MPN_100ml, MinInt, MaxInt), retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.Concentration_MPN_100ml = MaxInt + 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Concentration_MPN_100ml, MinInt, MaxInt), retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.Concentration_MPN_100ml = MaxInt - 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.Concentration_MPN_100ml = MinInt;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.Concentration_MPN_100ml = MaxInt;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Concentration_MPN_100ml

                    #region Dilution
                    FillVPResultModel(vpResultModelNew);
                    double Min = 1D;
                    double Max = 1000000D;
                    vpResultModelNew.Dilution = Min - 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Dilution, Min, Max), retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.Dilution = Max + 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Dilution, Min, Max), retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.Dilution = Max - 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.Dilution = Min;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.Dilution = Max;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Dilution

                    #region FarFieldWidth_m
                    FillVPResultModel(vpResultModelNew);
                    Min = 0D;
                    Max = 10000D;
                    vpResultModelNew.FarFieldWidth_m = Min - 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FarFieldWidth_m, Min, Max), retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.FarFieldWidth_m = Max + 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FarFieldWidth_m, Min, Max), retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.FarFieldWidth_m = Max - 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.FarFieldWidth_m = Min;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.FarFieldWidth_m = Max;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion FarFieldWidth_m

                    #region DispersionDistance_m
                    FillVPResultModel(vpResultModelNew);
                    Min = 0D;
                    Max = 50000D;
                    vpResultModelNew.DispersionDistance_m = Min - 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DispersionDistance_m, Min, Max), retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.DispersionDistance_m = Max + 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DispersionDistance_m, Min, Max), retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.DispersionDistance_m = Max - 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.DispersionDistance_m = Min;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.DispersionDistance_m = Max;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion DispersionDistance_m

                    #region TravelTime_hour
                    FillVPResultModel(vpResultModelNew);
                    Min = 0D;
                    Max = 200D;
                    vpResultModelNew.TravelTime_hour = Min - 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TravelTime_hour, Min, Max), retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.TravelTime_hour = Max + 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TravelTime_hour, Min, Max), retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.TravelTime_hour = Max - 1;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.TravelTime_hour = Min;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPResultModel(vpResultModelNew);
                    vpResultModelNew.TravelTime_hour = Max;

                    retStr = vpResultService.VPResultModelOK(vpResultModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TravelTime_hour

                }
            }
        }
        [TestMethod]
        public void VPResultService_FillVPResult_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    FillVPResultModel(vpResultModelRet);

                    ContactOK contactOK = vpResultService.IsContactOK();

                    string retStr = vpResultService.FillVPResult(vpResult, vpResultModelRet, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, vpResult.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = vpResultService.FillVPResult(vpResult, vpResultModelRet, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, vpResult.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void VPResultService_GetVPResultModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    int vpResultCount = vpResultService.GetVPResultModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, vpResultCount);

                }
            }
        }
        [TestMethod]
        public void VPResultService_GetVPResultModelListWithVPScenarioIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    List<VPResultModel> vpResultModelList = vpResultService.GetVPResultModelListWithVPScenarioIDDB(vpResultModelRet.VPScenarioID);
                    Assert.AreEqual(testDBService.Count + 1, vpResultModelList.Count);

                }
            }
        }
        [TestMethod]
        public void VPResultService_GetVPResultModelWithVPScenarioIDAndOrdinalDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    VPResultModel vpResultModelRet2 = vpResultService.GetVPResultModelWithVPScenarioIDAndOrdinalDB(vpResultModelRet.VPScenarioID, vpResultModelRet.Ordinal);
                    Assert.AreEqual(vpResultModelRet.VPScenarioID, vpResultModelRet2.VPScenarioID);

                    int VPScenarioID = 0;
                    vpResultModelRet2 = vpResultService.GetVPResultModelWithVPScenarioIDAndOrdinalDB(VPScenarioID, vpResultModelRet.Ordinal);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPResult, ServiceRes.VPScenarioID + "," + ServiceRes.Ordinal, VPScenarioID.ToString() + "," + vpResultModelRet.Ordinal), vpResultModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void VPResultService_GetVPResultWithVPScenarioIDAndOrdinalDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    VPResult vpResultRet = vpResultService.GetVPResultWithVPScenarioIDAndOrdinalDB(vpResultModelRet.VPScenarioID, vpResultModelRet.Ordinal);
                    Assert.AreEqual(vpResultModelRet.VPScenarioID, vpResultRet.VPScenarioID);

                }
            }
        }
        [TestMethod]
        public void VPResultService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    VPResultModel vpResultModelRet = vpResultService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, vpResultModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostAddUpdateDeleteVPResultDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    VPResultModel vpResultModelRet2 = UpdateVPResultModel(vpResultModelRet);

                    VPResultModel vpResultModelRet3 = vpResultService.PostDeleteVPResultDB(vpResultModelRet2.VPScenarioID, vpResultModelRet2.Ordinal);
                    Assert.AreEqual("", vpResultModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostAddVPResultDB_VPResultModelOK_Error_Test()
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
                        shimVPResultService.VPResultModelOKVPResultModel = (a) =>
                        {
                            return ErrorText;
                        };

                        VPResultModel vpResultModelRet = AddVPResultModel();
                        Assert.AreEqual(ErrorText, vpResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostAddVPResultDB_IsContactOK_Error_Test()
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
                        shimVPResultService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        VPResultModel vpResultModelRet = AddVPResultModel();
                        Assert.AreEqual(ErrorText, vpResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostAddVPResultDB_GetVPResultWithVPScenarioIDAndOrdinalDB_Error_Test()
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
                        shimVPResultService.GetVPResultWithVPScenarioIDAndOrdinalDBInt32Int32 = (a, b) =>
                        {
                            return new VPResult();
                        };

                        VPResultModel vpResultModelRet = AddVPResultModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.VPResult), vpResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostAddVPResultDB_FillVPResultModel_Error_Test()
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
                        shimVPResultService.FillVPResultVPResultVPResultModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        VPResultModel vpResultModelRet = AddVPResultModel();
                        Assert.AreEqual(ErrorText, vpResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostAddVPResultDB_DoAddChanges_Error_Test()
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
                        shimVPResultService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        VPResultModel vpResultModelRet = AddVPResultModel();
                        Assert.AreEqual(ErrorText, vpResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostAddVPResultDB_Add_Error_Test()
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
                        shimVPResultService.FillVPResultVPResultVPResultModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        VPResultModel vpResultModelRet = AddVPResultModel();
                        Assert.IsTrue(vpResultModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostDeleteVPResultDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPResultService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        VPResultModel vpResultModelRet2 = vpResultService.PostDeleteVPResultDB(vpResult.VPScenarioID, vpResult.Ordinal);

                        Assert.AreEqual(ErrorText, vpResultModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostDeleteVPResultDB_GetVPResultWithVPScenarioIDAndOrdinalDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPResultService.GetVPResultWithVPScenarioIDAndOrdinalDBInt32Int32 = (a, b) =>
                        {
                            return null;
                        };

                        VPResultModel vpResultModelRet2 = vpResultService.PostDeleteVPResultDB(vpResult.VPScenarioID, vpResult.Ordinal);

                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.VPResult), vpResultModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostDeleteVPResultDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPResultService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        VPResultModel vpResultModelRet2 = vpResultService.PostDeleteVPResultDB(vpResultModelRet.VPScenarioID, vpResultModelRet.Ordinal);

                        Assert.AreEqual(ErrorText, vpResultModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostUpdateVPResultDB_VPResultModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPResultService.VPResultModelOKVPResultModel = (a) =>
                        {
                            return ErrorText;
                        };

                        VPResultModel vpResultModelret2 = UpdateVPResultModel(vpResultModelRet);

                        Assert.AreEqual(ErrorText, vpResultModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostUpdateVPResultDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPResultService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        VPResultModel vpResultModelret2 = UpdateVPResultModel(vpResultModelRet);

                        Assert.AreEqual(ErrorText, vpResultModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostUpdateVPResultDB_GetVPResultWithVPScenarioIDAndOrdinalDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPResultService.GetVPResultWithVPScenarioIDAndOrdinalDBInt32Int32 = (a, b) =>
                        {
                            return null;
                        };

                        VPResultModel vpResultModelret2 = UpdateVPResultModel(vpResultModelRet);

                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.VPResult), vpResultModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostUpdateVPResultDB_FillVPResultModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPResultService.FillVPResultVPResultVPResultModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        VPResultModel vpResultModelret2 = UpdateVPResultModel(vpResultModelRet);

                        Assert.AreEqual(ErrorText, vpResultModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostUpdateVPResultDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPResultService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        VPResultModel vpResultModelret2 = UpdateVPResultModel(vpResultModelRet);

                        Assert.AreEqual(ErrorText, vpResultModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostAddUpdateDeleteVPResultDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, vpResultModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void VPResultService_PostAddUpdateDeleteVPResultDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPResultModel vpResultModelRet = AddVPResultModel();
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, vpResultModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public VPResultModel AddVPResultModel()
        {
            VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();
            if (!string.IsNullOrWhiteSpace(vpScenarioModelRet.Error))
            {
                return new VPResultModel() { Error = vpScenarioModelRet.Error };
            }

            vpResultModelNew.VPScenarioID = vpScenarioModelRet.VPScenarioID;
            FillVPResultModel(vpResultModelNew);

            VPResultModel vpResultModelRet = vpResultService.PostAddVPResultDB(vpResultModelNew);
            if (!string.IsNullOrWhiteSpace(vpResultModelRet.Error))
            {
                return vpResultModelRet;
            }

            CompareVPResultModels(vpResultModelNew, vpResultModelRet);

            return vpResultModelRet;
        }
        public VPResultModel UpdateVPResultModel(VPResultModel vpResultModel)
        {
            FillVPResultModel(vpResultModel);

            VPResultModel vpResultModelRet2 = vpResultService.PostUpdateVPResultDB(vpResultModel);
            if (!string.IsNullOrWhiteSpace(vpResultModelRet2.Error))
            {
                return vpResultModelRet2;
            }

            CompareVPResultModels(vpResultModel, vpResultModelRet2);

            return vpResultModelRet2;
        }
        private void CompareVPResultModels(VPResultModel vpResultModelNew, VPResultModel vpResultModelRet)
        {
            Assert.AreEqual(vpResultModelNew.VPScenarioID, vpResultModelRet.VPScenarioID);
            Assert.AreEqual(vpResultModelNew.Ordinal, vpResultModelRet.Ordinal);
            Assert.AreEqual(vpResultModelNew.Concentration_MPN_100ml, vpResultModelRet.Concentration_MPN_100ml);
            Assert.AreEqual(vpResultModelNew.Dilution, vpResultModelRet.Dilution);
            Assert.AreEqual(vpResultModelNew.FarFieldWidth_m, vpResultModelRet.FarFieldWidth_m);
            Assert.AreEqual(vpResultModelNew.DispersionDistance_m, vpResultModelRet.DispersionDistance_m);
            Assert.AreEqual(vpResultModelNew.TravelTime_hour, vpResultModelRet.TravelTime_hour);
        }
        private void FillVPResultModel(VPResultModel vpResultModel)
        {
            vpResultModel.VPScenarioID = vpResultModel.VPScenarioID;
            vpResultModel.Ordinal = (vpResultModel.Ordinal == 0 ? randomService.RandomInt(1, 8000) : vpResultModel.Ordinal);
            vpResultModel.Concentration_MPN_100ml = randomService.RandomInt(0, 10000000);
            vpResultModel.Dilution = randomService.RandomDouble(1, 1000000);
            vpResultModel.FarFieldWidth_m = randomService.RandomDouble(0, 10000);
            vpResultModel.DispersionDistance_m = randomService.RandomDouble(0, 50000);
            vpResultModel.TravelTime_hour = randomService.RandomDouble(0, 200);

            Assert.IsTrue(vpResultModel.VPScenarioID != 0);
            Assert.IsTrue(vpResultModel.Ordinal >= 1 && vpResultModel.Ordinal <= 8000);
            Assert.IsTrue(vpResultModel.Concentration_MPN_100ml >= 0 && vpResultModel.Concentration_MPN_100ml <= 10000000);
            Assert.IsTrue(vpResultModel.Dilution >= 1 && vpResultModel.Dilution <= 1000000);
            Assert.IsTrue(vpResultModel.FarFieldWidth_m >= 0 && vpResultModel.FarFieldWidth_m <= 10000);
            Assert.IsTrue(vpResultModel.DispersionDistance_m >= 0 && vpResultModel.DispersionDistance_m <= 50000);
            Assert.IsTrue(vpResultModel.TravelTime_hour >= 0 && vpResultModel.TravelTime_hour <= 200);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            vpResultService = new VPResultService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            vpResultModelNew = new VPResultModel();
            vpResult = new VPResult();
            vpScenarioServiceTest = new VPScenarioServiceTest();
            vpScenarioServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimVPResultService = new ShimVPResultService(vpResultService);
        }
        #endregion Functions private
    }
}

