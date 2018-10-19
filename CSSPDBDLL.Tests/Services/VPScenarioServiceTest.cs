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
using CSSPWebToolsDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Linq;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.IO;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for VPScenarioServiceTest
    /// </summary>
    [TestClass]
    public class VPScenarioServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "VPScenario";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private VPScenarioService vpScenarioService { get; set; }
        private VPScenarioLanguageService vpScenarioLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private VPScenarioModel vpScenarioModelNew { get; set; }
        private VPScenario vpScenario { get; set; }
        private ShimVPScenarioService shimVPScenarioService { get; set; }
        private ShimVPScenarioLanguageService shimVPScenarioLanguageService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimVPAmbientService shimVPAmbientService { get; set; }
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
        public VPScenarioServiceTest()
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
        public void VPScenarioService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Assert.IsNotNull(vpScenarioService);
                Assert.IsNotNull(vpScenarioService._VPScenarioLanguageService);
                Assert.IsNotNull(vpScenarioService.db);
                Assert.IsNotNull(vpScenarioService.LanguageRequest);
                Assert.IsNotNull(vpScenarioService.User);
                Assert.AreEqual(user.Identity.Name, vpScenarioService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), vpScenarioService.LanguageRequest);
            }
        }
        [TestMethod]
        public void VPScenarioService_VPScenarioModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // Act 
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModel.Error);

                    #region Good
                    vpScenarioModelNew.InfrastructureTVItemID = tvItemModel.TVItemID;
                    FillVPScenarioModel(vpScenarioModelNew);

                    string retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region InfrastructureTVItemID
                    FillVPScenarioModel(vpScenarioModelNew);

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.InfrastructureTVItemID = 0;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID), retStr);
                    #endregion InfrastructureTVItemID

                    #region VPScenarioName
                    int MinInt = 3;
                    int MaxInt = 100;
                    vpScenarioModelNew.InfrastructureTVItemID = tvItemModel.TVItemID;
                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.VPScenarioName = randomService.RandomString("", MinInt - 1);

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.VPScenarioName, MinInt), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.VPScenarioName = randomService.RandomString("", MaxInt + 1);

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.VPScenarioName, MaxInt), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.VPScenarioName = randomService.RandomString("", MaxInt - 1);

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.VPScenarioName = randomService.RandomString("", MinInt);

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.VPScenarioName = randomService.RandomString("", MaxInt);

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion VPScenarioName

                    #region VPScenarioStatus
                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.VPScenarioStatus = (ScenarioStatusEnum)10000;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioStatus), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.VPScenarioStatus = ScenarioStatusEnum.Changing;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion VPScenarioStatus

                    #region EffluentFlow_m3_s
                    FillVPScenarioModel(vpScenarioModelNew);
                    double Min = 0D;
                    double Max = 100000D;
                    vpScenarioModelNew.EffluentFlow_m3_s = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.EffluentFlow_m3_s, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentFlow_m3_s = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.EffluentFlow_m3_s, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentFlow_m3_s = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentFlow_m3_s = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentFlow_m3_s = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion EffluentFlow_m3_s

                    #region EffluentConcentration_MPN_100ml
                    FillVPScenarioModel(vpScenarioModelNew);
                    MinInt = 0;
                    MaxInt = 15000000;
                    vpScenarioModelNew.EffluentConcentration_MPN_100ml = MinInt - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.EffluentConcentration_MPN_100ml, MinInt, MaxInt), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentConcentration_MPN_100ml = MaxInt + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.EffluentConcentration_MPN_100ml, MinInt, MaxInt), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentConcentration_MPN_100ml = MaxInt - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentConcentration_MPN_100ml = MinInt;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentConcentration_MPN_100ml = MaxInt;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion EffluentConcentration_MPN_100ml

                    #region FroudeNumber
                    FillVPScenarioModel(vpScenarioModelNew);
                    Min = 0D;
                    Max = 10000D;
                    vpScenarioModelNew.FroudeNumber = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FroudeNumber, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.FroudeNumber = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FroudeNumber, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.FroudeNumber = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.FroudeNumber = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.FroudeNumber = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion FroudeNumber

                    #region PortDiameter_m
                    FillVPScenarioModel(vpScenarioModelNew);
                    Min = 0D;
                    Max = 100D;
                    vpScenarioModelNew.PortDiameter_m = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortDiameter_m, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortDiameter_m = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortDiameter_m, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortDiameter_m = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortDiameter_m = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortDiameter_m = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PortDiameter_m

                    #region PortDepth_m
                    FillVPScenarioModel(vpScenarioModelNew);
                    Min = 0D;
                    Max = 1000D;
                    vpScenarioModelNew.PortDepth_m = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortDepth_m, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortDepth_m = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortDepth_m, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortDepth_m = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortDepth_m = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortDepth_m = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PortDepth_m

                    #region PortElevation_m
                    FillVPScenarioModel(vpScenarioModelNew);
                    Min = 0D;
                    Max = 1000D;
                    vpScenarioModelNew.PortElevation_m = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortElevation_m, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortElevation_m = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortElevation_m, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortElevation_m = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortElevation_m = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortElevation_m = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PortElevation_m

                    #region VerticalAngle_deg
                    FillVPScenarioModel(vpScenarioModelNew);
                    Min = -90D;
                    Max = 90D;
                    vpScenarioModelNew.VerticalAngle_deg = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.VerticalAngle_deg, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.VerticalAngle_deg = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.VerticalAngle_deg, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.VerticalAngle_deg = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.VerticalAngle_deg = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.VerticalAngle_deg = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion VerticalAngle_deg

                    #region HorizontalAngle_deg
                    FillVPScenarioModel(vpScenarioModelNew);
                    Min = -180D;
                    Max = 180D;
                    vpScenarioModelNew.HorizontalAngle_deg = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.HorizontalAngle_deg, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.HorizontalAngle_deg = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.HorizontalAngle_deg, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.HorizontalAngle_deg = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.HorizontalAngle_deg = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.HorizontalAngle_deg = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion HorizontalAngle_deg

                    #region NumberOfPorts
                    FillVPScenarioModel(vpScenarioModelNew);
                    MinInt = 1;
                    MaxInt = 200;
                    vpScenarioModelNew.NumberOfPorts = MinInt - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.NumberOfPorts, MinInt, MaxInt), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.NumberOfPorts = MaxInt + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.NumberOfPorts, MinInt, MaxInt), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.NumberOfPorts = MaxInt - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.NumberOfPorts = MinInt;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.NumberOfPorts = MaxInt;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion NumberOfPorts

                    #region PortSpacing_m
                    FillVPScenarioModel(vpScenarioModelNew);
                    Min = 0D;
                    Max = 10000D;
                    vpScenarioModelNew.PortSpacing_m = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortSpacing_m, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortSpacing_m = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortSpacing_m, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortSpacing_m = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortSpacing_m = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.PortSpacing_m = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PortSpacing_m

                    #region AcuteMixZone_m
                    FillVPScenarioModel(vpScenarioModelNew);
                    Min = 0D;
                    Max = 1000D;
                    vpScenarioModelNew.AcuteMixZone_m = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AcuteMixZone_m, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.AcuteMixZone_m = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AcuteMixZone_m, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.AcuteMixZone_m = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.AcuteMixZone_m = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.AcuteMixZone_m = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AcuteMixZone_m

                    #region ChronicMixZone_m
                    FillVPScenarioModel(vpScenarioModelNew);
                    Min = 0D;
                    Max = 50000D;
                    vpScenarioModelNew.ChronicMixZone_m = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ChronicMixZone_m, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.ChronicMixZone_m = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ChronicMixZone_m, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.ChronicMixZone_m = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.ChronicMixZone_m = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.ChronicMixZone_m = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ChronicMixZone_m

                    #region EffluentSalinity_PSU
                    FillVPScenarioModel(vpScenarioModelNew);
                    Min = 0D;
                    Max = 35D;
                    vpScenarioModelNew.EffluentSalinity_PSU = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.EffluentSalinity_PSU, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentSalinity_PSU = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.EffluentSalinity_PSU, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentSalinity_PSU = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentSalinity_PSU = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentSalinity_PSU = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion EffluentSalinity_PSU

                    #region EffluentTemperature_C
                    FillVPScenarioModel(vpScenarioModelNew);
                    Min = 0D;
                    Max = 35D;
                    vpScenarioModelNew.EffluentTemperature_C = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.EffluentTemperature_C, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentTemperature_C = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.EffluentTemperature_C, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentTemperature_C = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentTemperature_C = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentTemperature_C = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion EffluentTemperature_C

                    #region EffluentVelocity_m_s
                    FillVPScenarioModel(vpScenarioModelNew);
                    Min = 0D;
                    Max = 100D;
                    vpScenarioModelNew.EffluentVelocity_m_s = Min - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.EffluentVelocity_m_s, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentVelocity_m_s = Max + 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.EffluentVelocity_m_s, Min, Max), retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentVelocity_m_s = Max - 1;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentVelocity_m_s = Min;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillVPScenarioModel(vpScenarioModelNew);
                    vpScenarioModelNew.EffluentVelocity_m_s = Max;

                    retStr = vpScenarioService.VPScenarioModelOK(vpScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion EffluentVelocity_m_s
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_FillVPScenario_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    vpScenarioModelNew.InfrastructureTVItemID = randomService.RandomTVItem(TVTypeEnum.Infrastructure).TVItemID;
                    FillVPScenarioModel(vpScenarioModelNew);

                    ContactOK contactOK = vpScenarioService.IsContactOK();

                    string retStr = vpScenarioService.FillVPScenarioWithoutRawResults(vpScenario, vpScenarioModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, vpScenario.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = vpScenarioService.FillVPScenarioWithoutRawResults(vpScenario, vpScenarioModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, vpScenario.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_GetNextVPScenarioToRunDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    vpScenarioModelRet.VPScenarioStatus = ScenarioStatusEnum.Changed;

                    VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostUpdateVPScenarioWithoutRawResultsDB(vpScenarioModelRet);
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    VPFullModel vpFullModel = vpScenarioService.GetNextVPScenarioToRunDB();
                    Assert.AreEqual("", vpFullModel.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_GetNextVPScenarioToRunDB_empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPFullModel vpFullModel = vpScenarioService.GetNextVPScenarioToRunDB();
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPScenario,
                    ServiceRes.VPScenarioStatus,
                    ScenarioStatusEnum.Changed), vpFullModel.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_GetVPScenarioFullDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    VPFullModel vpFullModel = vpScenarioService.GetVPScenarioFullDB(vpScenario.VPScenarioID);
                    Assert.AreEqual("", vpFullModel.Error);

                    int VPScenarioID = 0;
                    vpFullModel = vpScenarioService.GetVPScenarioFullDB(VPScenarioID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioID), vpFullModel.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_GetVPScenarioModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    int vpScenarioCount = vpScenarioService.GetVPScenarioModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, vpScenarioCount);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_GetVPScenarioModelListWithInfrastructureTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    List<VPScenarioModel> vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(vpScenarioModelRet.InfrastructureTVItemID);
                    Assert.IsNotNull(vpScenarioModelList);
                    Assert.IsTrue(vpScenarioModelList.Count > 0);
                    Assert.IsTrue(vpScenarioModelList.Where(c => c.VPScenarioID == vpScenarioModelRet.VPScenarioID).Any());

                    int InfrastructureTVItemID = 0;
                    vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
                    Assert.IsNotNull(vpScenarioModelList);
                    Assert.AreEqual(0, vpScenarioModelList.Count);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_GetVPScenarioModelWithVPScenarioIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    VPScenarioModel vpScenarioModelRet2 = vpScenarioService.GetVPScenarioModelWithVPScenarioIDDB(vpScenarioModelRet.VPScenarioID);
                    Assert.AreEqual(vpScenarioModelRet.VPScenarioID, vpScenarioModelRet2.VPScenarioID);

                    int VPScenarioID = 0;
                    VPScenarioModel vpScenarioModelRet3 = vpScenarioService.GetVPScenarioModelWithVPScenarioIDDB(VPScenarioID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPScenario, ServiceRes.VPScenarioID, VPScenarioID), vpScenarioModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_GetVPScenarioModelWithInfrastructureTVItemIDAndVPScenarioNameDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    VPScenarioModel vpScenarioModelRet2 = vpScenarioService.GetVPScenarioModelWithInfrastructureTVItemIDAndVPScenarioNameDB(vpScenarioModelRet.InfrastructureTVItemID, vpScenarioModelRet.VPScenarioName);
                    Assert.AreEqual(vpScenarioModelRet.VPScenarioID, vpScenarioModelRet2.VPScenarioID);

                    int InfrastructureTVItemID = 0;
                    vpScenarioModelRet2 = vpScenarioService.GetVPScenarioModelWithInfrastructureTVItemIDAndVPScenarioNameDB(InfrastructureTVItemID, vpScenarioModelRet.VPScenarioName);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPScenario, ServiceRes.InfrastructureTVItemID + "," + ServiceRes.VPScenarioName, InfrastructureTVItemID + "," + vpScenarioModelRet.VPScenarioName), vpScenarioModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_GetVPScenarioWithVPScenarioIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    VPScenario vpScenarioRet = vpScenarioService.GetVPScenarioWithVPScenarioIDDB(vpScenarioModelRet.VPScenarioID);
                    Assert.AreEqual(vpScenarioModelRet.VPScenarioID, vpScenarioRet.VPScenarioID);

                    VPScenario vpScenarioRet2 = vpScenarioService.GetVPScenarioWithVPScenarioIDDB(0);
                    Assert.IsNull(vpScenarioRet2);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_GetVPScenarioWithInfrastructureTVItemIDAndVPScenarioNameDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    VPScenario vpScenarioRet = vpScenarioService.GetVPScenarioWithInfrastructureTVItemIDAndVPScenarioNameDB(vpScenarioModelRet.InfrastructureTVItemID, vpScenarioModelRet.VPScenarioName);
                    Assert.AreEqual(vpScenarioModelRet.VPScenarioID, vpScenarioRet.VPScenarioID);

                    int InfraTVItemID = vpScenarioModelRet.InfrastructureTVItemID;
                    string ScenarioName = vpScenarioModelRet.VPScenarioName + "not";
                    VPScenario vpScenarioRet2 = vpScenarioService.GetVPScenarioWithInfrastructureTVItemIDAndVPScenarioNameDB(InfraTVItemID, ScenarioName);
                    Assert.IsNull(vpScenarioRet2);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    VPScenarioModel vpScenarioModelRet = vpScenarioService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, vpScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostAddUpdateDeleteVPScenario_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    VPScenarioModel vpScenarioModelRet2 = UpdateVPScenarioModel(vpScenarioModelRet);
                    Assert.AreEqual("", vpScenarioModelRet2.Error);

                    VPScenarioModel vpScenarioModelRet3 = vpScenarioService.PostDeleteVPScenarioDB(vpScenarioModelRet2.VPScenarioID);
                    Assert.AreEqual("", vpScenarioModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostAddVPScenarioDB_VPScenarioModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.VPScenarioModelOKVPScenarioModel = (a) =>
                        {
                            return ErrorText;
                        };

                        vpScenarioModelRet.VPScenarioName = randomService.RandomString("unique VPScenario ", 30);

                        VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostAddVPScenarioDB(vpScenarioModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostAddVPScenarioDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        vpScenarioModelRet.VPScenarioName = randomService.RandomString("unique VPScenario ", 30);

                        VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostAddVPScenarioDB(vpScenarioModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostAddVPScenarioDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        vpScenarioModelRet.VPScenarioName = randomService.RandomString("unique VPScenario ", 30);

                        VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostAddVPScenarioDB(vpScenarioModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostAddVPScenarioDB_GetVPScenarioWithInfrastructureTVItemIDAndScenarioNameDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimVPScenarioService.GetVPScenarioWithInfrastructureTVItemIDAndVPScenarioNameDBInt32String = (a, b) =>
                        {
                            return new VPScenario();
                        };

                        vpScenarioModelRet.VPScenarioName = randomService.RandomString("unique VPScenario ", 30);

                        VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostAddVPScenarioDB(vpScenarioModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.VPScenario), vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostAddVPScenarioDB_FillVPScenario_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.FillVPScenarioWithoutRawResultsVPScenarioVPScenarioModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        vpScenarioModelRet.VPScenarioName = randomService.RandomString("unique VPScenario ", 30);

                        VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostAddVPScenarioDB(vpScenarioModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostAddVPScenarioDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        vpScenarioModelRet.VPScenarioName = randomService.RandomString("unique VPScenario ", 30);

                        VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostAddVPScenarioDB(vpScenarioModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostAddVPScenarioDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimVPScenarioService.FillVPScenarioWithoutRawResultsVPScenarioVPScenarioModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        vpScenarioModelRet.VPScenarioName = randomService.RandomString("unique VPScenario ", 30);

                        VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostAddVPScenarioDB(vpScenarioModelRet);
                        Assert.IsTrue(vpScenarioModelRet2.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostAddVPScenarioDB_PostAddVPScenarioLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.PostAddVPScenarioLanguageDBVPScenarioLanguageModel = (a) =>
                        {
                            return new VPScenarioLanguageModel() { Error = ErrorText };
                        };

                        vpScenarioModelRet.VPScenarioName = randomService.RandomString("unique VPScenario ", 30);

                        VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostAddVPScenarioDB(vpScenarioModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostAddVPScenarioDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    SetupTest(contactModelListBad[0], culture);

                    vpScenarioModelRet.VPScenarioName = randomService.RandomString("unique VPScenario ", 30);

                    VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostAddVPScenarioDB(vpScenarioModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, vpScenarioModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostAddVPScenarioDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    SetupTest(contactModelListGood[2], culture);

                    vpScenarioModelRet.VPScenarioName = randomService.RandomString("unique VPScenario ", 30);

                    VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostAddVPScenarioDB(vpScenarioModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, vpScenarioModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostDeleteVPScenario_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostDeleteVPScenarioDB(vpScenarioModelRet.VPScenarioID);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostDeleteVPScenario_GetVPScenarioWithVPScenarioIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimVPScenarioService.GetVPScenarioWithVPScenarioIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostDeleteVPScenarioDB(vpScenarioModelRet.VPScenarioID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.VPScenario), vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostDeleteVPScenario_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostDeleteVPScenarioDB(vpScenarioModelRet.VPScenarioID);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostUpdateVPScenarioWithoutRawResultsDB_VPScenarioModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.VPScenarioModelOKVPScenarioModel = (a) =>
                        {
                            return ErrorText;
                        };

                        VPScenarioModel vpScenarioModelRet2 = UpdateVPScenarioModel(vpScenarioModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostUpdateVPScenarioWithoutRawResultsDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModelRet2 = UpdateVPScenarioModel(vpScenarioModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostUpdateVPScenarioWithoutRawResultsDB_GetVPScenarioWithVPScenarioIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimVPScenarioService.GetVPScenarioWithVPScenarioIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        VPScenarioModel vpScenarioModelRet2 = UpdateVPScenarioModel(vpScenarioModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.VPScenario), vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostUpdateVPScenarioWithoutRawResultsDB_FillVPScenario_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.FillVPScenarioWithoutRawResultsVPScenarioVPScenarioModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        VPScenarioModel vpScenarioModelRet2 = UpdateVPScenarioModel(vpScenarioModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostUpdateVPScenarioWithoutRawResultsDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        VPScenarioModel vpScenarioModelRet2 = UpdateVPScenarioModel(vpScenarioModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostUpdateVPScenarioWithoutRawResultsDB_PostUpdateVPScenarioLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    VPScenarioModel vpScenarioModelRet = AddVPScenarioModel();
                    Assert.AreEqual("", vpScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioLanguageService.PostUpdateVPScenarioLanguageDBVPScenarioLanguageModel = (a) =>
                        {
                            return new VPScenarioLanguageModel() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModelRet2 = UpdateVPScenarioModel(vpScenarioModelRet);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostUpdateVPScenarioRawResultsDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    VPScenarioModel vpScenarioModelRet = vpScenarioService.PostUpdateVPScenarioRawResultsDB(vpScenario.VPScenarioID, vpScenario.RawResults);
                    Assert.AreEqual("", vpScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostUpdateVPScenarioRawResultsDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModelRet = vpScenarioService.PostUpdateVPScenarioRawResultsDB(vpScenario.VPScenarioID, vpScenario.RawResults);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostUpdateVPScenarioRawResultsDB_GetVPScenarioWithVPScenarioIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimVPScenarioService.GetVPScenarioWithVPScenarioIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        VPScenarioModel vpScenarioModelRet = vpScenarioService.PostUpdateVPScenarioRawResultsDB(vpScenario.VPScenarioID, vpScenario.RawResults);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.VPScenario), vpScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostUpdateVPScenarioRawResultsDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        VPScenarioModel vpScenarioModelRet = vpScenarioService.PostUpdateVPScenarioRawResultsDB(vpScenario.VPScenarioID, vpScenario.RawResults);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCopyVPScenarioDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    List<VPScenarioModel> vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
                    Assert.IsTrue(vpScenarioModelList.Count > 0);

                    VPScenarioModel vpScenarioModelRet = vpScenarioService.PostCopyVPScenarioDB(vpScenarioModelList[0].VPScenarioID);
                    Assert.AreEqual("", vpScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCopyVPScenarioDB_GetVPScenarioModelWithVPScenarioIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    List<VPScenarioModel> vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
                    Assert.IsTrue(vpScenarioModelList.Count > 0);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.GetVPScenarioModelWithVPScenarioIDDBInt32 = (a) =>
                        {
                            return new VPScenarioModel() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModelRet = vpScenarioService.PostCopyVPScenarioDB(vpScenarioModelList[0].VPScenarioID);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCopyVPScenarioDB_PostAddVPScenarioDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    List<VPScenarioModel> vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
                    Assert.IsTrue(vpScenarioModelList.Count > 0);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.PostAddVPScenarioDBVPScenarioModel = (a) =>
                        {
                            return new VPScenarioModel() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModelRet = vpScenarioService.PostCopyVPScenarioDB(vpScenarioModelList[0].VPScenarioID);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCopyVPScenarioDB_GetVPAmbientModelListWithVPScenarioIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    List<VPScenarioModel> vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
                    Assert.IsTrue(vpScenarioModelList.Count > 0);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPAmbientService.GetVPAmbientModelListWithVPScenarioIDDBInt32 = (a) =>
                        {
                            return new List<VPAmbientModel>() { new VPAmbientModel() { Error = ErrorText } };
                        };

                        VPScenarioModel vpScenarioModelRet = vpScenarioService.PostCopyVPScenarioDB(vpScenarioModelList[0].VPScenarioID);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCopyVPScenarioDB_PostAddVPAmbientDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    List<VPScenarioModel> vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
                    Assert.IsTrue(vpScenarioModelList.Count > 0);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPAmbientService.PostAddVPAmbientDBVPAmbientModel = (a) =>
                        {
                            return new VPAmbientModel() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModelRet = vpScenarioService.PostCopyVPScenarioDB(vpScenarioModelList[0].VPScenarioID);
                        Assert.AreEqual(ErrorText, vpScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCreateNewVPScenarioDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    VPScenarioModel vpScenarioModel = vpScenarioService.PostCreateNewVPScenarioDB(InfrastructureTVItemID);
                    Assert.AreEqual("", vpScenarioModel.Error);

                    InfrastructureTVItemID = 0;
                    vpScenarioModel = vpScenarioService.PostCreateNewVPScenarioDB(InfrastructureTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID), vpScenarioModel.Error);

                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCreateNewVPScenarioDB_PostAddVPScenarioDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPScenarioService.PostAddVPScenarioDBVPScenarioModel = (a) =>
                        {
                            return new VPScenarioModel() { Error = ErrorText };
                        };
                        VPScenarioModel vpScenarioModel = vpScenarioService.PostCreateNewVPScenarioDB(InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCreateNewVPScenarioDB_PostAddVPAmbientDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPAmbientService.PostAddVPAmbientDBVPAmbientModel = (a) =>
                        {
                            return new VPAmbientModel() { Error = ErrorText };
                        };
                        VPScenarioModel vpScenarioModel = vpScenarioService.PostCreateNewVPScenarioDB(InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCreateNewVPScenarioDB_PostAddVPAmbientDB_Row2_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    int count = 0;
                    using (ShimsContext.Create())
                    {

                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPAmbientService.PostAddVPAmbientDBVPAmbientModel = (a) =>
                        {
                            count += 1;
                            if (count == 2)
                            {
                                return new VPAmbientModel() { Error = ErrorText };
                            }
                            else
                            {
                                return new VPAmbientModel();
                            }
                        };
                        VPScenarioModel vpScenarioModel = vpScenarioService.PostCreateNewVPScenarioDB(InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCreateNewVPScenarioDB_PostAddVPAmbientDB_Row3_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    int count = 0;
                    using (ShimsContext.Create())
                    {

                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPAmbientService.PostAddVPAmbientDBVPAmbientModel = (a) =>
                        {
                            count += 1;
                            if (count == 3)
                            {
                                return new VPAmbientModel() { Error = ErrorText };
                            }
                            else
                            {
                                return new VPAmbientModel();
                            }
                        };
                        VPScenarioModel vpScenarioModel = vpScenarioService.PostCreateNewVPScenarioDB(InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCreateNewVPScenarioDB_PostAddVPAmbientDB_Row4_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    int count = 0;
                    using (ShimsContext.Create())
                    {

                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPAmbientService.PostAddVPAmbientDBVPAmbientModel = (a) =>
                        {
                            count += 1;
                            if (count == 4)
                            {
                                return new VPAmbientModel() { Error = ErrorText };
                            }
                            else
                            {
                                return new VPAmbientModel();
                            }
                        };
                        VPScenarioModel vpScenarioModel = vpScenarioService.PostCreateNewVPScenarioDB(InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCreateNewVPScenarioDB_PostAddVPAmbientDB_Row5_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    int count = 0;
                    using (ShimsContext.Create())
                    {

                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPAmbientService.PostAddVPAmbientDBVPAmbientModel = (a) =>
                        {
                            count += 1;
                            if (count == 5)
                            {
                                return new VPAmbientModel() { Error = ErrorText };
                            }
                            else
                            {
                                return new VPAmbientModel();
                            }
                        };
                        VPScenarioModel vpScenarioModel = vpScenarioService.PostCreateNewVPScenarioDB(InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCreateNewVPScenarioDB_PostAddVPAmbientDB_Row6_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    int count = 0;
                    using (ShimsContext.Create())
                    {

                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPAmbientService.PostAddVPAmbientDBVPAmbientModel = (a) =>
                        {
                            count += 1;
                            if (count == 6)
                            {
                                return new VPAmbientModel() { Error = ErrorText };
                            }
                            else
                            {
                                return new VPAmbientModel();
                            }
                        };
                        VPScenarioModel vpScenarioModel = vpScenarioService.PostCreateNewVPScenarioDB(InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCreateNewVPScenarioDB_PostAddVPAmbientDB_Row7_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    int count = 0;
                    using (ShimsContext.Create())
                    {

                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPAmbientService.PostAddVPAmbientDBVPAmbientModel = (a) =>
                        {
                            count += 1;
                            if (count == 7)
                            {
                                return new VPAmbientModel() { Error = ErrorText };
                            }
                            else
                            {
                                return new VPAmbientModel();
                            }
                        };
                        VPScenarioModel vpScenarioModel = vpScenarioService.PostCreateNewVPScenarioDB(InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostCreateNewVPScenarioDB_PostAddVPAmbientDB_Row8_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    int InfrastructureTVItemID = (from c in vpScenarioService.db.VPScenarios select c.InfrastructureTVItemID).FirstOrDefault<int>();

                    int count = 0;
                    using (ShimsContext.Create())
                    {

                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimVPAmbientService.PostAddVPAmbientDBVPAmbientModel = (a) =>
                        {
                            count += 1;
                            if (count == 8)
                            {
                                return new VPAmbientModel() { Error = ErrorText };
                            }
                            else
                            {
                                return new VPAmbientModel();
                            }
                        };
                        VPScenarioModel vpScenarioModel = vpScenarioService.PostCreateNewVPScenarioDB(InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveResultsInDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios where c.RawResults != null select c).FirstOrDefault();

                    VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveResultsInDB(vpScenario.VPScenarioID, vpScenario.RawResults);
                    Assert.AreEqual("", vpScenarioModel.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveResultsInDB_GetVPScenarioModelWithVPScenarioIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios where c.RawResults != null select c).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPScenarioService.GetVPScenarioModelWithVPScenarioIDDBInt32 = (a) =>
                        {
                            return new VPScenarioModel() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveResultsInDB(vpScenario.VPScenarioID, vpScenario.RawResults);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveResultsInDB_PostUpdateVPScenarioWithoutRawResultsDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios where c.RawResults != null select c).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPScenarioService.PostUpdateVPScenarioWithoutRawResultsDBVPScenarioModel = (a) =>
                        {
                            return new VPScenarioModel() { Error = ErrorText };
                        };
                        VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveResultsInDB(vpScenario.VPScenarioID, "Error " + vpScenario.RawResults);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveResultsInDB_PostUpdateVPScenarioRawResultsDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios where c.RawResults != null select c).FirstOrDefault();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPScenarioService.PostUpdateVPScenarioRawResultsDBInt32String = (a, b) =>
                        {
                            return new VPScenarioModel() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveResultsInDB(vpScenario.VPScenarioID, "Error " + vpScenario.RawResults);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveResultsInDB_GetVPAmbientModelListWithVPScenarioIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios where c.RawResults != null select c).FirstOrDefault();
                    Assert.IsNotNull(vpScenario);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPAmbientService.GetVPAmbientModelListWithVPScenarioIDDBInt32 = (a) =>
                        {
                            return new List<VPAmbientModel>();
                        };

                        VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveResultsInDB(vpScenario.VPScenarioID, vpScenario.RawResults);
                        Assert.AreEqual(ServiceRes.AmbientCountNotEqual8, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveVPScenarioDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    FormCollection fc = GetPostSaveVPScenarioDBFormCollection();

                    VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                    Assert.AreEqual("", vpScenarioModel.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveVPScenarioDB_InfrastructureTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    FormCollection fc = GetPostSaveVPScenarioDBFormCollection();

                    fc["InfrastructureTVItemID"] = "";

                    VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID), vpScenarioModel.Error);

                    fc["InfrastructureTVItemID"] = "0";

                    vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID), vpScenarioModel.Error);

                    fc["InfrastructureTVItemID"] = null;

                    vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID), vpScenarioModel.Error);

                    fc.Remove("InfrastructureTVItemID");

                    vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID), vpScenarioModel.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveVPScenarioDB_VPScenarioID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    FormCollection fc = GetPostSaveVPScenarioDBFormCollection();

                    fc["VPScenarioID"] = "";

                    VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioID), vpScenarioModel.Error);

                    fc["VPScenarioID"] = "0";

                    vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioID), vpScenarioModel.Error);

                    fc["VPScenarioID"] = null;

                    vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioID), vpScenarioModel.Error);

                    fc.Remove("VPScenarioID");

                    vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioID), vpScenarioModel.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveVPScenarioDB_UseAsBest_false_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    FormCollection fc = GetPostSaveVPScenarioDBFormCollection();

                    fc["UseAsBestEstimate"] = "false";

                    VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                    Assert.AreEqual("", vpScenarioModel.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveVPScenarioDB_UseAsBest_true_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    FormCollection fc = GetPostSaveVPScenarioDBFormCollection();

                    fc["UseAsBestEstimate"] = "true";

                    VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                    Assert.AreEqual("", vpScenarioModel.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveVPScenarioDB_UseAsBest_true_GetVPScenarioModelListWithInfrastructureTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    FormCollection fc = GetPostSaveVPScenarioDBFormCollection();

                    fc["UseAsBestEstimate"] = "true";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPScenarioService.PostUpdateVPScenarioWithoutRawResultsDBVPScenarioModel = (a) =>
                        {
                            return new VPScenarioModel() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveVPScenarioDB_GetVPScenarioModelWithVPScenarioIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    FormCollection fc = GetPostSaveVPScenarioDBFormCollection();

                    fc["UseAsBestEstimate"] = "false";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPScenarioService.GetVPScenarioModelWithVPScenarioIDDBInt32 = (a) =>
                        {
                            return new VPScenarioModel() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveVPScenarioDB_VPScenarioName_Empty_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios where c.RawResults != null select c).FirstOrDefault();

                    FormCollection fc = GetPostSaveVPScenarioDBFormCollection();

                    fc["VPScenarioName"] = "";

                    VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.VPScenarioName), vpScenarioModel.Error);
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveVPScenarioDB_PostUpdateVPScenarioWithoutRawResultsDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios select c).FirstOrDefault();

                    FormCollection fc = GetPostSaveVPScenarioDBFormCollection();

                    fc["UseAsBestEstimate"] = "false";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPScenarioService.PostUpdateVPScenarioWithoutRawResultsDBVPScenarioModel = (a) =>
                        {
                            return new VPScenarioModel() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveVPScenarioDB_GetVPAmbientModelWithVPScenarioIDAndRowDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios where c.RawResults != null select c).FirstOrDefault();

                    FormCollection fc = GetPostSaveVPScenarioDBFormCollection();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPAmbientService.GetVPAmbientModelWithVPScenarioIDAndRowDBInt32Int32 = (a, b) =>
                        {
                            return new VPAmbientModel() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void VPScenarioService_PostSaveVPScenarioDB_PostUpdateVPAmbientDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // find Infrastructure with VPScenarios
                    VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios where c.RawResults != null select c).FirstOrDefault();

                    FormCollection fc = GetPostSaveVPScenarioDBFormCollection();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimVPAmbientService.PostUpdateVPAmbientDBVPAmbientModel = (a) =>
                        {
                            return new VPAmbientModel() { Error = ErrorText };
                        };

                        VPScenarioModel vpScenarioModel = vpScenarioService.PostSaveVPScenarioDB(fc);
                        Assert.AreEqual(ErrorText, vpScenarioModel.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions
        public VPScenarioModel AddVPScenarioModel()
        {
            TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Infrastructure);

            Assert.AreEqual("", tvItemModel.Error);

            vpScenarioModelNew.InfrastructureTVItemID = tvItemModel.TVItemID;
            FillVPScenarioModel(vpScenarioModelNew);

            VPScenarioModel vpScenarioModelRet = vpScenarioService.PostAddVPScenarioDB(vpScenarioModelNew);
            if (!string.IsNullOrWhiteSpace(vpScenarioModelRet.Error))
            {
                return vpScenarioModelRet;
            }

            CompareVPScenarioModels(vpScenarioModelNew, vpScenarioModelRet);

            return vpScenarioModelRet;
        }
        private FormCollection GetPostSaveVPScenarioDBFormCollection()
        {
            VPScenario vpScenario = (from c in vpScenarioService.db.VPScenarios where c.RawResults != null select c).FirstOrDefault();

            Assert.IsTrue(vpScenario.VPScenarioID > 0);

            FormCollection fc = new FormCollection();
            fc["InfrastructureTVItemID"] = vpScenario.InfrastructureTVItemID.ToString();
            fc["VPScenarioID"] = vpScenario.VPScenarioID.ToString();
            fc["UseAsBestEstimate"] = "true";
            fc["VPScenarioName"] = randomService.RandomString("newVPScenarioName ", 30);
            fc["PortDiameter_m"] = randomService.RandomFloat(0.2f, 0.22f).ToString();
            fc["PortElevation_m"] = randomService.RandomFloat(0.1f, 0.11f).ToString();
            fc["VerticalAngle_deg"] = "0";
            fc["HorizontalAngle_deg"] = "90";
            fc["NumberOfPorts"] = "1";
            fc["PortSpacing_m"] = "1000";
            fc["AcuteMixZone_m"] = "50";
            fc["ChronicMixZone_m"] = "40000";
            fc["PortDepth_m"] = "1";
            fc["EffluentFlow_m3_s"] = randomService.RandomFloat(0.001f, 0.0011f).ToString();
            fc["EffluentSalinity_PSU"] = "0";
            fc["EffluentTemperature_C"] = "15";
            fc["EffluentConcentration_MPN_100ml"] = "5600000";

            List<VPAmbient> vpAmbientList = (from c in vpScenarioService.db.VPAmbients where c.VPScenarioID == vpScenario.VPScenarioID orderby c.Row select c).ToList();

            Assert.IsTrue(vpAmbientList.Count == 8);

            for (int Row = 1; Row < 9; Row++)
            {
                VPAmbient vpAmbient = vpAmbientList.Where(c => c.Row == Row).FirstOrDefault();

                Assert.AreEqual(Row, vpAmbient.Row);

                if (vpScenarioService.LanguageRequest == LanguageEnum.fr)
                {
                    fc["MeasurementDepth_m" + Row.ToString()] = vpAmbient.MeasurementDepth_m.ToString().Replace(".", ",");
                    fc["CurrentSpeed_m_s" + Row.ToString()] = vpAmbient.CurrentSpeed_m_s.ToString().Replace(".", ",");
                    fc["CurrentDirection_deg" + Row.ToString()] = vpAmbient.CurrentDirection_deg.ToString().Replace(".", ",");
                    fc["AmbientSalinity_PSU" + Row.ToString()] = vpAmbient.AmbientSalinity_PSU.ToString().Replace(".", ",");
                    fc["AmbientTemperature_C" + Row.ToString()] = vpAmbient.AmbientTemperature_C.ToString().Replace(".", ",");
                    fc["BackgroundConcentration_MPN_100ml" + Row.ToString()] = vpAmbient.BackgroundConcentration_MPN_100ml.ToString().Replace(".", ",");
                    fc["PollutantDecayRate_per_day" + Row.ToString()] = vpAmbient.PollutantDecayRate_per_day.ToString().Replace(".", ",");
                    fc["FarFieldCurrentSpeed_m_s" + Row.ToString()] = vpAmbient.FarFieldCurrentSpeed_m_s.ToString().Replace(".", ",");
                    fc["FarFieldCurrentDirection_deg" + Row.ToString()] = vpAmbient.FarFieldCurrentDirection_deg.ToString().Replace(".", ",");
                    fc["FarFieldDiffusionCoefficient" + Row.ToString()] = vpAmbient.FarFieldDiffusionCoefficient.ToString().Replace(".", ",");
                }
                else
                {
                    fc["MeasurementDepth_m" + Row.ToString()] = vpAmbient.MeasurementDepth_m.ToString();
                    fc["CurrentSpeed_m_s" + Row.ToString()] = vpAmbient.CurrentSpeed_m_s.ToString();
                    fc["CurrentDirection_deg" + Row.ToString()] = vpAmbient.CurrentDirection_deg.ToString();
                    fc["AmbientSalinity_PSU" + Row.ToString()] = vpAmbient.AmbientSalinity_PSU.ToString();
                    fc["AmbientTemperature_C" + Row.ToString()] = vpAmbient.AmbientTemperature_C.ToString();
                    fc["BackgroundConcentration_MPN_100ml" + Row.ToString()] = vpAmbient.BackgroundConcentration_MPN_100ml.ToString();
                    fc["PollutantDecayRate_per_day" + Row.ToString()] = vpAmbient.PollutantDecayRate_per_day.ToString();
                    fc["FarFieldCurrentSpeed_m_s" + Row.ToString()] = vpAmbient.FarFieldCurrentSpeed_m_s.ToString();
                    fc["FarFieldCurrentDirection_deg" + Row.ToString()] = vpAmbient.FarFieldCurrentDirection_deg.ToString();
                    fc["FarFieldDiffusionCoefficient" + Row.ToString()] = vpAmbient.FarFieldDiffusionCoefficient.ToString();
                }
            }

            return fc;
        }
        public VPScenarioModel UpdateVPScenarioModel(VPScenarioModel vpScenarioModel)
        {
            FillVPScenarioModel(vpScenarioModel);

            VPScenarioModel vpScenarioModelRet2 = vpScenarioService.PostUpdateVPScenarioWithoutRawResultsDB(vpScenarioModel);
            if (!string.IsNullOrWhiteSpace(vpScenarioModelRet2.Error))
            {
                return vpScenarioModelRet2;
            }

            CompareVPScenarioModels(vpScenarioModel, vpScenarioModelRet2);

            return vpScenarioModelRet2;
        }
        private void CompareVPScenarioModels(VPScenarioModel vpScenarioModelNew, VPScenarioModel vpScenarioModelRet)
        {
            Assert.AreEqual(vpScenarioModelNew.InfrastructureTVItemID, vpScenarioModelRet.InfrastructureTVItemID);
            Assert.AreEqual(vpScenarioModelNew.VPScenarioStatus, vpScenarioModelRet.VPScenarioStatus);
            Assert.AreEqual(vpScenarioModelNew.UseAsBestEstimate, vpScenarioModelRet.UseAsBestEstimate);
            Assert.AreEqual(vpScenarioModelNew.EffluentFlow_m3_s, vpScenarioModelRet.EffluentFlow_m3_s);
            Assert.AreEqual(vpScenarioModelNew.EffluentConcentration_MPN_100ml, vpScenarioModelRet.EffluentConcentration_MPN_100ml);
            Assert.AreEqual(vpScenarioModelNew.FroudeNumber, vpScenarioModelRet.FroudeNumber);
            Assert.AreEqual(vpScenarioModelNew.PortDiameter_m, vpScenarioModelRet.PortDiameter_m);
            Assert.AreEqual(vpScenarioModelNew.PortDepth_m, vpScenarioModelRet.PortDepth_m);
            Assert.AreEqual(vpScenarioModelNew.PortElevation_m, vpScenarioModelRet.PortElevation_m);
            Assert.AreEqual(vpScenarioModelNew.VerticalAngle_deg, vpScenarioModelRet.VerticalAngle_deg);
            Assert.AreEqual(vpScenarioModelNew.HorizontalAngle_deg, vpScenarioModelRet.HorizontalAngle_deg);
            Assert.AreEqual(vpScenarioModelNew.NumberOfPorts, vpScenarioModelRet.NumberOfPorts);
            Assert.AreEqual(vpScenarioModelNew.PortSpacing_m, vpScenarioModelRet.PortSpacing_m);
            Assert.AreEqual(vpScenarioModelNew.AcuteMixZone_m, vpScenarioModelRet.AcuteMixZone_m);
            Assert.AreEqual(vpScenarioModelNew.ChronicMixZone_m, vpScenarioModelRet.ChronicMixZone_m);
            Assert.AreEqual(vpScenarioModelNew.EffluentTemperature_C, vpScenarioModelRet.EffluentTemperature_C);
            //Assert.AreEqual(vpScenarioModelNew.RawResults, vpScenarioModelRet.RawResults);

            foreach (LanguageEnum Lang in vpScenarioService.LanguageListAllowable)
            {
                VPScenarioLanguageModel vpScenarioLanguageModel = vpScenarioService._VPScenarioLanguageService.GetVPScenarioLanguageModelWithVPScenarioIDAndLanguageDB(vpScenarioModelRet.VPScenarioID, Lang);

                Assert.AreEqual("", vpScenarioLanguageModel.Error);
                if (Lang == vpScenarioService.LanguageRequest)
                {
                    Assert.AreEqual(vpScenarioModelRet.VPScenarioName, vpScenarioLanguageModel.VPScenarioName);
                }
            }
        }
        private void FillVPScenarioModel(VPScenarioModel vpScenarioModel)
        {
            vpScenarioModel.InfrastructureTVItemID = vpScenarioModel.InfrastructureTVItemID;
            vpScenarioModel.VPScenarioName = randomService.RandomString("VPScenarioName", 30);
            vpScenarioModel.VPScenarioStatus = ScenarioStatusEnum.Changing;
            vpScenarioModel.UseAsBestEstimate = true;
            vpScenarioModel.EffluentFlow_m3_s = randomService.RandomDouble(0, 10);
            vpScenarioModel.EffluentConcentration_MPN_100ml = randomService.RandomInt(0, 10000000);
            vpScenarioModel.FroudeNumber = randomService.RandomDouble(0, 100);
            vpScenarioModel.PortDiameter_m = randomService.RandomDouble(0, 10);
            vpScenarioModel.PortDepth_m = randomService.RandomDouble(0, 1000);
            vpScenarioModel.PortElevation_m = randomService.RandomDouble(0, 1000);
            vpScenarioModel.VerticalAngle_deg = randomService.RandomDouble(-90, 90);
            vpScenarioModel.HorizontalAngle_deg = randomService.RandomDouble(-180, 180);
            vpScenarioModel.NumberOfPorts = randomService.RandomInt(1, 100);
            vpScenarioModel.PortSpacing_m = randomService.RandomDouble(0, 10000);
            vpScenarioModel.AcuteMixZone_m = randomService.RandomDouble(0, 1000);
            vpScenarioModel.ChronicMixZone_m = randomService.RandomDouble(0, 50000);
            vpScenarioModel.EffluentSalinity_PSU = randomService.RandomDouble(0, 35);
            vpScenarioModel.EffluentTemperature_C = randomService.RandomDouble(0, 35);
            vpScenarioModel.EffluentVelocity_m_s = randomService.RandomDouble(0, 10);

            Assert.IsTrue(vpScenarioModel.InfrastructureTVItemID != 0);
            Assert.IsTrue(vpScenarioModel.VPScenarioName.Length == 30);
            Assert.IsTrue(vpScenarioModel.VPScenarioStatus == ScenarioStatusEnum.Changing);
            Assert.IsTrue(vpScenarioModel.UseAsBestEstimate == true);
            Assert.IsTrue(vpScenarioModel.EffluentFlow_m3_s >= 0 && vpScenarioModel.EffluentFlow_m3_s <= 10);
            Assert.IsTrue(vpScenarioModel.EffluentConcentration_MPN_100ml >= 0 && vpScenarioModel.EffluentConcentration_MPN_100ml <= 10000000);
            Assert.IsTrue(vpScenarioModel.FroudeNumber >= 0 && vpScenarioModel.FroudeNumber <= 100);
            Assert.IsTrue(vpScenarioModel.PortDiameter_m >= 0 && vpScenarioModel.PortDiameter_m <= 10);
            Assert.IsTrue(vpScenarioModel.PortDepth_m >= 0 && vpScenarioModel.PortDepth_m <= 1000);
            Assert.IsTrue(vpScenarioModel.PortElevation_m >= 0 && vpScenarioModel.PortElevation_m <= 1000);
            Assert.IsTrue(vpScenarioModel.VerticalAngle_deg >= -90 && vpScenarioModel.VerticalAngle_deg <= 90);
            Assert.IsTrue(vpScenarioModel.HorizontalAngle_deg >= -180 && vpScenarioModel.HorizontalAngle_deg <= 180);
            Assert.IsTrue(vpScenarioModel.NumberOfPorts >= 1 && vpScenarioModel.NumberOfPorts <= 100);
            Assert.IsTrue(vpScenarioModel.PortSpacing_m >= 0 && vpScenarioModel.PortSpacing_m <= 10000);
            Assert.IsTrue(vpScenarioModel.AcuteMixZone_m >= 0 && vpScenarioModel.AcuteMixZone_m <= 1000);
            Assert.IsTrue(vpScenarioModel.ChronicMixZone_m >= 0 && vpScenarioModel.ChronicMixZone_m <= 50000);
            Assert.IsTrue(vpScenarioModel.EffluentSalinity_PSU >= 0 && vpScenarioModel.EffluentSalinity_PSU <= 35);
            Assert.IsTrue(vpScenarioModel.EffluentTemperature_C >= 0 && vpScenarioModel.EffluentTemperature_C <= 35);
            Assert.IsTrue(vpScenarioModel.EffluentVelocity_m_s >= 0 && vpScenarioModel.EffluentVelocity_m_s <= 10);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            vpScenarioService = new VPScenarioService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            vpScenarioLanguageService = new VPScenarioLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            vpScenarioModelNew = new VPScenarioModel();
            vpScenario = new VPScenario();
        }
        private void SetupShim()
        {
            shimVPScenarioService = new ShimVPScenarioService(vpScenarioService);
            shimVPScenarioLanguageService = new ShimVPScenarioLanguageService(vpScenarioService._VPScenarioLanguageService);
            shimTVItemService = new ShimTVItemService(vpScenarioService._TVItemService);
            shimVPAmbientService = new ShimVPAmbientService(vpScenarioService._VPAmbientService);
        }
        #endregion Functions private
    }
}


