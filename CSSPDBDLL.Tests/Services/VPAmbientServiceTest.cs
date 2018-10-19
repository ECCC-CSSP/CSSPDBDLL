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
    /// Summary description for VPAmbientServiceTest
    /// </summary>
    [TestClass]
    public class VPAmbientServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "VPAmbient";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private VPAmbientService vpAmbientService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private VPAmbientModel vpAmbientModelNew { get; set; }
        private VPAmbient vpAmbient { get; set; }
        private ShimVPAmbientService shimVPAmbientService { get; set; }
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
        public VPAmbientServiceTest()
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
        public void VPAmbientService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(vpAmbientService);
                Assert.IsNotNull(vpAmbientService.db);
                Assert.IsNotNull(vpAmbientService.LanguageRequest);
                Assert.IsNotNull(vpAmbientService.User);
                Assert.AreEqual(user.Identity.Name, vpAmbientService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), vpAmbientService.LanguageRequest);
            }
        }
        [TestMethod]
        public void VPAmbientService_VPAmbientModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    vpAmbientModelNew.VPScenarioID = vpAmbientModelRet.VPScenarioID;

                    #region Good
                    FillVPAmbientModel(vpAmbientModelNew);

                    string retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region VPScenarioID
                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.VPScenarioID = 0;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioID), retStr);

                    vpAmbientModelNew.VPScenarioID = vpAmbientModelRet.VPScenarioID;
                    FillVPAmbientModel(vpAmbientModelNew);

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion VPScenarioID

                    #region Row
                    int MinInt = 1;
                    int MaxInt = 8;
                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.Row = MinInt - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Row, MinInt, MaxInt), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.Row = MaxInt + 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Row, MinInt, MaxInt), retStr);

                    vpAmbientModelNew.Row = MaxInt - 1;
                    FillVPAmbientModel(vpAmbientModelNew);

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.Row = MinInt;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.Row = MaxInt;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Row

                    #region MeasurementDepth_m
                    FillVPAmbientModel(vpAmbientModelNew);
                    double Min = 0D;
                    double Max = 1000D;
                    vpAmbientModelNew.MeasurementDepth_m = Min - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MeasurementDepth_m, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.MeasurementDepth_m = Max + 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MeasurementDepth_m, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.MeasurementDepth_m = Max - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.MeasurementDepth_m = Min;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.MeasurementDepth_m = Max;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MeasurementDepth_m

                    #region CurrentSpeed_m_s
                    FillVPAmbientModel(vpAmbientModelNew);
                    Min = 0D;
                    Max = 10D;
                    vpAmbientModelNew.CurrentSpeed_m_s = Min - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.CurrentSpeed_m_s, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.CurrentSpeed_m_s = Max + 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.CurrentSpeed_m_s, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.CurrentSpeed_m_s = Max - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.CurrentSpeed_m_s = Min;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.CurrentSpeed_m_s = Max;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion CurrentSpeed_m_s

                    #region CurrentDirection_deg
                    FillVPAmbientModel(vpAmbientModelNew);
                    Min = 0D;
                    Max = 360D;
                    vpAmbientModelNew.CurrentDirection_deg = Min - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.CurrentDirection_deg, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.CurrentDirection_deg = Max + 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.CurrentDirection_deg, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.CurrentDirection_deg = Max - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.CurrentDirection_deg = Min;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.CurrentDirection_deg = Max;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion CurrentDirection_deg

                    #region AmbientSalinity_PSU
                    FillVPAmbientModel(vpAmbientModelNew);
                    Min = 0D;
                    Max = 35D;
                    vpAmbientModelNew.AmbientSalinity_PSU = Min - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AmbientSalinity_PSU, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.AmbientSalinity_PSU = Max + 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AmbientSalinity_PSU, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.AmbientSalinity_PSU = Max - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.AmbientSalinity_PSU = Min;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.AmbientSalinity_PSU = Max;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AmbientSalinity_PSU

                    #region AmbientTemperature_C
                    FillVPAmbientModel(vpAmbientModelNew);
                    Min = 0D;
                    Max = 35D;
                    vpAmbientModelNew.AmbientTemperature_C = Min - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AmbientTemperature_C, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.AmbientTemperature_C = Max + 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AmbientTemperature_C, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.AmbientTemperature_C = Max - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.AmbientTemperature_C = Min;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.AmbientTemperature_C = Max;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AmbientTemperature_C

                    #region BackgroundConcentration_MPN_100ml
                    FillVPAmbientModel(vpAmbientModelNew);
                    MinInt = 0;
                    MaxInt = 10000000;
                    vpAmbientModelNew.BackgroundConcentration_MPN_100ml = MinInt - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.BackgroundConcentration_MPN_100ml, MinInt, MaxInt), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.BackgroundConcentration_MPN_100ml = MaxInt + 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.BackgroundConcentration_MPN_100ml, MinInt, MaxInt), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.BackgroundConcentration_MPN_100ml = MaxInt - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.BackgroundConcentration_MPN_100ml = MinInt;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.BackgroundConcentration_MPN_100ml = MaxInt;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion BackgroundConcentration_MPN_100ml

                    #region PollutantDecayRate_per_day
                    FillVPAmbientModel(vpAmbientModelNew);
                    Min = 0D;
                    Max = 100D;
                    vpAmbientModelNew.PollutantDecayRate_per_day = Min - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PollutantDecayRate_per_day, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.PollutantDecayRate_per_day = Max + 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PollutantDecayRate_per_day, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.PollutantDecayRate_per_day = Max - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.PollutantDecayRate_per_day = Min;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.PollutantDecayRate_per_day = Max;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PollutantDecayRate_per_day

                    #region FarFieldCurrentSpeed_m_s
                    FillVPAmbientModel(vpAmbientModelNew);
                    Min = 0D;
                    Max = 10D;
                    vpAmbientModelNew.FarFieldCurrentSpeed_m_s = Min - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FarFieldCurrentSpeed_m_s, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.FarFieldCurrentSpeed_m_s = Max + 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FarFieldCurrentSpeed_m_s, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.FarFieldCurrentSpeed_m_s = Max - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.FarFieldCurrentSpeed_m_s = Min;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.FarFieldCurrentSpeed_m_s = Max;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion FarFieldCurrentSpeed_m_s

                    #region FarFieldCurrentDirection_deg
                    FillVPAmbientModel(vpAmbientModelNew);
                    Min = 0D;
                    Max = 360D;
                    vpAmbientModelNew.FarFieldCurrentDirection_deg = Min - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FarFieldCurrentDirection_deg, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.FarFieldCurrentDirection_deg = Max + 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FarFieldCurrentDirection_deg, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.FarFieldCurrentDirection_deg = Max - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.FarFieldCurrentDirection_deg = Min;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.FarFieldCurrentDirection_deg = Max;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion FarFieldCurrentDirection_deg

                    #region FarFieldDiffusionCoefficient
                    FillVPAmbientModel(vpAmbientModelNew);
                    Min = 0D;
                    Max = 2D;
                    vpAmbientModelNew.FarFieldDiffusionCoefficient = Min - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FarFieldDiffusionCoefficient, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.FarFieldDiffusionCoefficient = Max + 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FarFieldDiffusionCoefficient, Min, Max), retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.FarFieldDiffusionCoefficient = Max - 1;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.FarFieldDiffusionCoefficient = Min;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPAmbientModel(vpAmbientModelNew);
                    vpAmbientModelNew.FarFieldDiffusionCoefficient = Max;

                    retStr = vpAmbientService.VPAmbientModelOK(vpAmbientModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion FarFieldDiffusionCoefficient

                }
            }
        }
        [TestMethod]
        public void VPAmbientService_FillVPAmbient_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    VPAmbient vpAmbient = new VPAmbient();

                    FillVPAmbientModel(vpAmbientModelRet);

                    ContactOK contactOK = vpAmbientService.IsContactOK();

                    string retStr = vpAmbientService.FillVPAmbient(vpAmbient, vpAmbientModelRet, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, vpAmbient.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = vpAmbientService.FillVPAmbient(vpAmbient, vpAmbientModelRet, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, vpAmbient.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void VPAmbientService_GetVPAmbientModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    int vpAmbientCount = vpAmbientService.GetVPAmbientModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, vpAmbientCount);

                }
            }
        }
        [TestMethod]
        public void VPAmbientService_GetVPAmbientModelListWithVPScenarioIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    List<VPAmbientModel> vpAmbientModelList = vpAmbientService.GetVPAmbientModelListWithVPScenarioIDDB(vpAmbientModelRet.VPScenarioID);
                    Assert.AreEqual(1, vpAmbientModelList.Count);

                }
            }
        }
        [TestMethod]
        public void VPAmbientService_GetVPAmbientModelWithVPScenarioIDAndRowDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    VPAmbientModel vpAmbientModelRet2 = vpAmbientService.GetVPAmbientModelWithVPScenarioIDAndRowDB(vpAmbientModelRet.VPScenarioID, vpAmbientModelRet.Row);
                    Assert.AreEqual(vpAmbientModelRet.VPScenarioID, vpAmbientModelRet2.VPScenarioID);

                    int VPScenarioID = 0;
                    vpAmbientModelRet2 = vpAmbientService.GetVPAmbientModelWithVPScenarioIDAndRowDB(VPScenarioID, vpAmbientModelRet.Row);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPAmbient, ServiceRes.VPScenarioID + "," + ServiceRes.Row, VPScenarioID.ToString() + "," + vpAmbientModelRet.Row), vpAmbientModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_GetVPAmbientWithVPScenarioIDAndRowDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    VPAmbient vpAmbientRet = vpAmbientService.GetVPAmbientWithVPScenarioIDAndRowDB(vpAmbientModelRet.VPScenarioID, vpAmbientModelRet.Row);
                    Assert.AreEqual(vpAmbientModelRet.VPScenarioID, vpAmbientRet.VPScenarioID);

                }
            }
        }
        [TestMethod]
        public void VPAmbientService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    VPAmbientModel vpAmbientModelRet = vpAmbientService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, vpAmbientModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostAddUpdateDeleteVPAmbientDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    VPAmbientModel vpAmbientModelRet2 = UpdateVPAmbientModel(vpAmbientModelRet);

                    VPAmbientModel vpAmbientModelRet3 = vpAmbientService.PostDeleteVPAmbientDB(vpAmbientModelRet2.VPScenarioID, vpAmbientModelRet2.Row);
                    Assert.AreEqual("", vpAmbientModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostAddVPAmbientDB_VPAmbientModelOK_Error_Test()
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
                        shimVPAmbientService.VPAmbientModelOKVPAmbientModel = (a) =>
                        {
                            return ErrorText;
                        };

                        VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                        Assert.AreEqual(ErrorText, vpAmbientModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostAddVPAmbientDB_IsContactOK_Error_Test()
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
                        shimVPAmbientService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();
                        Assert.AreEqual(ErrorText, vpAmbientModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostAddVPAmbientDB_GetVPAmbientWithVPScenarioIDAndRowDB_Error_Test()
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
                        shimVPAmbientService.GetVPAmbientWithVPScenarioIDAndRowDBInt32Int32 = (a, b) =>
                        {
                            return new VPAmbient();
                        };

                        VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.VPAmbient), vpAmbientModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostAddVPAmbientDB_FillVPAmbientModel_Error_Test()
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
                        shimVPAmbientService.FillVPAmbientVPAmbientVPAmbientModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();
                        Assert.AreEqual(ErrorText, vpAmbientModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostAddVPAmbientDB_DoAddChanges_Error_Test()
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
                        shimVPAmbientService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();
                        Assert.AreEqual(ErrorText, vpAmbientModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostAddVPAmbientDB_Add_Error_Test()
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
                        shimVPAmbientService.FillVPAmbientVPAmbientVPAmbientModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();
                        Assert.IsTrue(vpAmbientModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostDeleteVPAmbientDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPAmbientService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        VPAmbientModel vpAmbientModelRet2 = vpAmbientService.PostDeleteVPAmbientDB(vpAmbient.VPScenarioID, vpAmbient.Row);

                        Assert.AreEqual(ErrorText, vpAmbientModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostDeleteVPAmbientDB_GetVPAmbientWithVPScenarioIDAndRowDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPAmbientService.GetVPAmbientWithVPScenarioIDAndRowDBInt32Int32 = (a, b) =>
                        {
                            return null;
                        };

                        VPAmbientModel vpAmbientModelRet2 = vpAmbientService.PostDeleteVPAmbientDB(vpAmbient.VPScenarioID, vpAmbient.Row);

                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.VPAmbient), vpAmbientModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostDeleteVPAmbientDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPAmbientService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        VPAmbientModel vpAmbientModelRet2 = vpAmbientService.PostDeleteVPAmbientDB(vpAmbientModelRet.VPScenarioID, vpAmbientModelRet.Row);
                        Assert.AreEqual(ErrorText, vpAmbientModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostUpdateVPAmbientDB_VPAmbientModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPAmbientService.VPAmbientModelOKVPAmbientModel = (a) =>
                        {
                            return ErrorText;
                        };

                        VPAmbientModel vpAmbientModelret2 = UpdateVPAmbientModel(vpAmbientModelRet);

                        Assert.AreEqual(ErrorText, vpAmbientModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostUpdateVPAmbientDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPAmbientService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        VPAmbientModel vpAmbientModelret2 = UpdateVPAmbientModel(vpAmbientModelRet);

                        Assert.AreEqual(ErrorText, vpAmbientModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostUpdateVPAmbientDB_GetVPAmbientWithVPScenarioIDAndRowDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPAmbientService.GetVPAmbientWithVPScenarioIDAndRowDBInt32Int32 = (a, b) =>
                        {
                            return null;
                        };

                        VPAmbientModel vpAmbientModelret2 = UpdateVPAmbientModel(vpAmbientModelRet);

                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.VPAmbient), vpAmbientModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostUpdateVPAmbientDB_FillVPAmbientModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPAmbientService.FillVPAmbientVPAmbientVPAmbientModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        VPAmbientModel vpAmbientModelret2 = UpdateVPAmbientModel(vpAmbientModelRet);

                        Assert.AreEqual(ErrorText, vpAmbientModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostUpdateVPAmbientDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPAmbientService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        VPAmbientModel vpAmbientModelret2 = UpdateVPAmbientModel(vpAmbientModelRet);

                        Assert.AreEqual(ErrorText, vpAmbientModelret2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostAddUpdateDeleteVPAmbientDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, vpAmbientModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void VPAmbientService_PostAddUpdateDeleteVPAmbientDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPAmbientModel vpAmbientModelRet = AddVPAmbientModel();
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, vpAmbientModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public 

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public VPAmbientModel AddVPAmbientModel()
        {
            VPScenarioModel vpScenarioModelRet = vpScenarioServiceTest.AddVPScenarioModel();
            if (!string.IsNullOrWhiteSpace(vpScenarioModelRet.Error))
            {
                return new VPAmbientModel() { Error = vpScenarioModelRet.Error };
            }

            vpAmbientModelNew.VPScenarioID = vpScenarioModelRet.VPScenarioID;
            FillVPAmbientModel(vpAmbientModelNew);

            VPAmbientModel vpAmbientModelRet = vpAmbientService.PostAddVPAmbientDB(vpAmbientModelNew);
            if (!string.IsNullOrWhiteSpace(vpAmbientModelRet.Error))
            {
                return vpAmbientModelRet;
            }

            CompareVPAmbientModels(vpAmbientModelNew, vpAmbientModelRet);

            return vpAmbientModelRet;
        }
        public VPAmbientModel UpdateVPAmbientModel(VPAmbientModel vpAmbientModel)
        {
            FillVPAmbientModel(vpAmbientModel);

            VPAmbientModel vpAmbientModelRet2 = vpAmbientService.PostUpdateVPAmbientDB(vpAmbientModel);
            if (!string.IsNullOrWhiteSpace(vpAmbientModelRet2.Error))
            {
                return vpAmbientModelRet2;
            }

            CompareVPAmbientModels(vpAmbientModel, vpAmbientModelRet2);

            return vpAmbientModelRet2;
        }
        private void CompareVPAmbientModels(VPAmbientModel vpAmbientModelNew, VPAmbientModel vpAmbientModelRet)
        {
            Assert.AreEqual(vpAmbientModelNew.VPScenarioID, vpAmbientModelRet.VPScenarioID);
            Assert.AreEqual(vpAmbientModelNew.Row, vpAmbientModelRet.Row);
            Assert.AreEqual(vpAmbientModelNew.MeasurementDepth_m, vpAmbientModelRet.MeasurementDepth_m);
            Assert.AreEqual(vpAmbientModelNew.CurrentSpeed_m_s, vpAmbientModelRet.CurrentSpeed_m_s);
            Assert.AreEqual(vpAmbientModelNew.CurrentDirection_deg, vpAmbientModelRet.CurrentDirection_deg);
            Assert.AreEqual(vpAmbientModelNew.AmbientSalinity_PSU, vpAmbientModelRet.AmbientSalinity_PSU);
            Assert.AreEqual(vpAmbientModelNew.AmbientTemperature_C, vpAmbientModelRet.AmbientTemperature_C);
            Assert.AreEqual(vpAmbientModelNew.BackgroundConcentration_MPN_100ml, vpAmbientModelRet.BackgroundConcentration_MPN_100ml);
            Assert.AreEqual(vpAmbientModelNew.PollutantDecayRate_per_day, vpAmbientModelRet.PollutantDecayRate_per_day);
            Assert.AreEqual(vpAmbientModelNew.FarFieldCurrentSpeed_m_s, vpAmbientModelRet.FarFieldCurrentSpeed_m_s);
            Assert.AreEqual(vpAmbientModelNew.FarFieldCurrentDirection_deg, vpAmbientModelRet.FarFieldCurrentDirection_deg);
            Assert.AreEqual(vpAmbientModelNew.FarFieldDiffusionCoefficient, vpAmbientModelRet.FarFieldDiffusionCoefficient);
        }
        private void FillVPAmbientModel(VPAmbientModel vpAmbientModel)
        {
            vpAmbientModel.VPScenarioID = vpAmbientModel.VPScenarioID;
            vpAmbientModel.Row = (vpAmbientModel.Row == 0 ? randomService.RandomInt(1, 8) : vpAmbientModel.Row);
            vpAmbientModel.MeasurementDepth_m = randomService.RandomDouble(0, 1000);
            vpAmbientModel.CurrentSpeed_m_s = randomService.RandomDouble(0, 10);
            vpAmbientModel.CurrentDirection_deg = randomService.RandomDouble(0, 360);
            vpAmbientModel.AmbientSalinity_PSU = randomService.RandomDouble(0, 35);
            vpAmbientModel.AmbientTemperature_C = randomService.RandomDouble(0, 35);
            vpAmbientModel.BackgroundConcentration_MPN_100ml = randomService.RandomInt(1, 10000000);
            vpAmbientModel.PollutantDecayRate_per_day = randomService.RandomDouble(0, 100);
            vpAmbientModel.FarFieldCurrentSpeed_m_s = randomService.RandomDouble(0, 10);
            vpAmbientModel.FarFieldCurrentDirection_deg = randomService.RandomDouble(0, 360);
            vpAmbientModel.FarFieldDiffusionCoefficient = randomService.RandomDouble(0, 2);

            Assert.IsTrue(vpAmbientModel.VPScenarioID != 0);
            Assert.IsTrue(vpAmbientModel.Row >= 1 && vpAmbientModel.Row <= 8);
            Assert.IsTrue(vpAmbientModel.MeasurementDepth_m >= 0 && vpAmbientModel.MeasurementDepth_m <= 1000);
            Assert.IsTrue(vpAmbientModel.CurrentSpeed_m_s >= 0 && vpAmbientModel.CurrentSpeed_m_s <= 10);
            Assert.IsTrue(vpAmbientModel.CurrentDirection_deg >= 0 && vpAmbientModel.CurrentDirection_deg <= 360);
            Assert.IsTrue(vpAmbientModel.AmbientSalinity_PSU >= 0 && vpAmbientModel.AmbientSalinity_PSU <= 35);
            Assert.IsTrue(vpAmbientModel.AmbientTemperature_C >= 0 && vpAmbientModel.AmbientTemperature_C <= 35);
            Assert.IsTrue(vpAmbientModel.BackgroundConcentration_MPN_100ml >= 0 && vpAmbientModel.BackgroundConcentration_MPN_100ml <= 10000000);
            Assert.IsTrue(vpAmbientModel.PollutantDecayRate_per_day >= 0 && vpAmbientModel.PollutantDecayRate_per_day <= 100);
            Assert.IsTrue(vpAmbientModel.FarFieldCurrentSpeed_m_s >= 0 && vpAmbientModel.FarFieldCurrentSpeed_m_s <= 10);
            Assert.IsTrue(vpAmbientModel.FarFieldCurrentDirection_deg >= 0 && vpAmbientModel.FarFieldCurrentDirection_deg <= 360);
            Assert.IsTrue(vpAmbientModel.FarFieldDiffusionCoefficient >= 0 && vpAmbientModel.FarFieldDiffusionCoefficient <= 2);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            vpAmbientService = new VPAmbientService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            vpAmbientModelNew = new VPAmbientModel();
            vpAmbient = new VPAmbient();
            vpScenarioServiceTest = new VPScenarioServiceTest();
            vpScenarioServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimVPAmbientService = new ShimVPAmbientService(vpAmbientService);
        }
        #endregion Functions private
    }
}

