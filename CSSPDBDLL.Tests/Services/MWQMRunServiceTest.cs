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
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MWQMRunServiceTest
    /// </summary>
    [TestClass]
    public class MWQMRunServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MWQMRun";
        private string Plurial = "s";
        List<string> BadTimeFormatList = new List<string>() { "1", "1:23", "1,23", "12;23", "9:45", "12:8", "233:23", "aa:bb", "25:12", "12:87" };
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MWQMRunService mwqmRunService { get; set; }
        private MWQMRunLanguageService mwqmRunLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MWQMRunModel mwqmRunModelNew { get; set; }
        private MWQMRun mwqmRun { get; set; }
        private TVItemService tvItemService { get; set; }
        private ShimMWQMRunService shimMWQMRunService { get; set; }
        private ShimMWQMRunLanguageService shimMWQMRunLanguageService { get; set; }
        private ShimLabSheetService shimLabSheetService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
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
        public MWQMRunServiceTest()
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
        public void MWQMRunService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Assert.IsNotNull(mwqmRunService);
                Assert.IsNotNull(mwqmRunService._MWQMRunLanguageService);
                Assert.IsNotNull(mwqmRunService.db);
                Assert.IsNotNull(mwqmRunService.LanguageRequest);
                Assert.IsNotNull(mwqmRunService.User);
                Assert.AreEqual(user.Identity.Name, mwqmRunService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mwqmRunService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMWQMRun = randomService.RandomTVItem(TVTypeEnum.MWQMRun);
                    Assert.AreEqual("", tvItemModelMWQMRun.Error);

                    TVItemModel tvItemModelSubsector = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelMWQMRun.ParentID);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    #region Good
                    mwqmRunModelNew.SubsectorTVItemID = tvItemModelSubsector.TVItemID;
                    mwqmRunModelNew.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
                    FillMWQMRunModel(mwqmRunModelNew);

                    string retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region SubsectorTVItemID
                    mwqmRunModelNew.SubsectorTVItemID = tvItemModelSubsector.TVItemID;
                    mwqmRunModelNew.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.SubsectorTVItemID = 0;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID), retStr);

                    mwqmRunModelNew.SubsectorTVItemID = tvItemModelSubsector.TVItemID;
                    FillMWQMRunModel(mwqmRunModelNew);

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SubsectorTVItemID

                    #region MWQMRunTVItemID
                    mwqmRunModelNew.SubsectorTVItemID = tvItemModelSubsector.TVItemID;
                    mwqmRunModelNew.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.MWQMRunTVItemID = 0;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMRunTVItemID), retStr);

                    mwqmRunModelNew.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
                    FillMWQMRunModel(mwqmRunModelNew);

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMRunTVItemID

                    #region DateTime_Local
                    mwqmRunModelNew.SubsectorTVItemID = tvItemModelSubsector.TVItemID;
                    mwqmRunModelNew.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
                    FillMWQMRunModel(mwqmRunModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMRunService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion DateTime_Local

                    #region StartDateTime_Local > EndDateTime_Local
                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.StartDateTime_Local = DateTime.UtcNow;
                    mwqmRunModelNew.EndDateTime_Local = mwqmRunModelNew.StartDateTime_Local.Value.AddHours(-1);

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDateAndTime_Local, ServiceRes.EndDateAndTime_Local), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.StartDateTime_Local = DateTime.UtcNow;
                    mwqmRunModelNew.EndDateTime_Local = mwqmRunModelNew.StartDateTime_Local.Value.AddHours(1);

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion StartDateTime_Local > EndDateTime_Local

                    #region TemperatureControl1_C
                    FillMWQMRunModel(mwqmRunModelNew);
                    double Min = -45;
                    double Max = 45;
                    mwqmRunModelNew.TemperatureControl1_C = Min - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TemperatureControl1_C, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.TemperatureControl1_C = Max + 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TemperatureControl1_C, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.TemperatureControl1_C = Max - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.TemperatureControl1_C = Min;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.TemperatureControl1_C = Max;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TemperatureControl1_C

                    #region TemperatureControl2_C
                    FillMWQMRunModel(mwqmRunModelNew);
                    Min = -45;
                    Max = 45;
                    mwqmRunModelNew.TemperatureControl2_C = Min - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TemperatureControl2_C, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.TemperatureControl2_C = Max + 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TemperatureControl2_C, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.TemperatureControl2_C = Max - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.TemperatureControl2_C = Min;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.TemperatureControl2_C = Max;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TemperatureControl2_C

                    #region SeaStateAtStart_BeaufortScale
                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)10000;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.BeaufortScale), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.SeaStateAtStart_BeaufortScale = BeaufortScaleEnum.GentleBreeze;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SeaStateAtStart_BeaufortScale

                    #region SeaStateAtEnd_BeaufortScale
                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)10000;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.BeaufortScale), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.SeaStateAtEnd_BeaufortScale = BeaufortScaleEnum.GentleBreeze;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SeaStateAtEnd_BeaufortScale

                    #region WaterLevelAtBrook_m
                    FillMWQMRunModel(mwqmRunModelNew);
                    Min = -5;
                    Max = 40;
                    mwqmRunModelNew.WaterLevelAtBrook_m = Min - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WaterLevelAtBrook_m, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.WaterLevelAtBrook_m = Max + 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WaterLevelAtBrook_m, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.WaterLevelAtBrook_m = Max - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.WaterLevelAtBrook_m = Min;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.WaterLevelAtBrook_m = Max;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion WaterLevelAtBrook_m

                    #region WaveHightAtStart_m
                    FillMWQMRunModel(mwqmRunModelNew);
                    Min = 0;
                    Max = 50;
                    mwqmRunModelNew.WaveHightAtStart_m = Min - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WaveHightAtStart_m, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.WaveHightAtStart_m = Max + 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WaveHightAtStart_m, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.WaveHightAtStart_m = Max - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.WaveHightAtStart_m = Min;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.WaveHightAtStart_m = Max;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion WaveHightAtStart_m

                    #region WaveHightAtEnd_m
                    FillMWQMRunModel(mwqmRunModelNew);
                    Min = 0;
                    Max = 50;
                    mwqmRunModelNew.WaveHightAtEnd_m = Min - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WaveHightAtEnd_m, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.WaveHightAtEnd_m = Max + 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WaveHightAtEnd_m, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.WaveHightAtEnd_m = Max - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.WaveHightAtEnd_m = Min;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.WaveHightAtEnd_m = Max;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion WaveHightAtEnd_m

                    #region SampleCrewInitials
                    int max = 20;
                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.SampleCrewInitials = randomService.RandomString("", 0);

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.SampleCrewInitials = randomService.RandomString("", max + 1);

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.SampleCrewInitials, max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.SampleCrewInitials = randomService.RandomString("", max);

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SampleCrewInitials

                    #region AnalyzeMethod
                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.AnalyzeMethod = (AnalyzeMethodEnum)10000;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AnalyzeMethod), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.AnalyzeMethod = AnalyzeMethodEnum.MF;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AnalyzeMethod

                    #region SampleMatrix
                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.SampleMatrix = (SampleMatrixEnum)1000000;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SampleMatrix), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.SampleMatrix = SampleMatrixEnum.W;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SampleMatrix

                    #region Laboratory
                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.Laboratory = (LaboratoryEnum)100000;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Laboratory), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.Laboratory = LaboratoryEnum._1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Laboratory

                    #region SampleStatus
                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.SampleStatus = (SampleStatusEnum)100000;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SampleStatus), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.SampleStatus = SampleStatusEnum.SampleStatus3;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SampleStatus

                    #region LabSampleApprovalContactTVItemID
                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.LabSampleApprovalContactTVItemID = 0;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LabSampleApprovalContactTVItemID), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.LabSampleApprovalContactTVItemID = 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ValidatorContactTVItemID

                    #region PPT24_mm
                    FillMWQMRunModel(mwqmRunModelNew);
                    Min = 0;
                    Max = 1000;
                    mwqmRunModelNew.PPT24_mm = Min - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PPT24_mm, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.PPT24_mm = Max + 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PPT24_mm, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.PPT24_mm = Max - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.PPT24_mm = Min;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.PPT24_mm = Max;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PPT24_mm

                    #region PPT48_mm
                    FillMWQMRunModel(mwqmRunModelNew);
                    Min = 0;
                    Max = 1000;
                    mwqmRunModelNew.PPT48_mm = Min - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PPT48_mm, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.PPT48_mm = Max + 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PPT48_mm, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.PPT48_mm = Max - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.PPT48_mm = Min;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.PPT48_mm = Max;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PPT48_mm

                    #region PPT72_mm
                    FillMWQMRunModel(mwqmRunModelNew);
                    Min = 0;
                    Max = 1000;
                    mwqmRunModelNew.PPT72_mm = Min - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PPT72_mm, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.PPT72_mm = Max + 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PPT72_mm, Min, Max), retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.PPT72_mm = Max - 1;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.PPT72_mm = Min;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMRunModel(mwqmRunModelNew);
                    mwqmRunModelNew.PPT72_mm = Max;

                    retStr = mwqmRunService.MWQMRunModelOK(mwqmRunModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PPT72_mm
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_FillMWQMRun_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMWQMRun = randomService.RandomTVItem(TVTypeEnum.MWQMRun);
                    Assert.AreEqual("", tvItemModelMWQMRun.Error);

                    TVItemModel tvItemModelSubsector = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelMWQMRun.ParentID);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    mwqmRunModelNew.SubsectorTVItemID = tvItemModelSubsector.TVItemID;
                    mwqmRunModelNew.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
                    FillMWQMRunModel(mwqmRunModelNew);

                    ContactOK contactOK = mwqmRunService.IsContactOK();

                    string retStr = mwqmRunService.FillMWQMRun(mwqmRun, mwqmRunModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mwqmRun.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mwqmRunService.FillMWQMRun(mwqmRun, mwqmRunModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, mwqmRun.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetLabSheetModelListWithMWQMRunTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in mwqmRunService.db.LabSheets
                                         where c.MWQMRunTVItemID > 0
                                         select c).FirstOrDefault();

                    Assert.IsNotNull(labSheet);

                    List<LabSheetModel> labSheetModelList = mwqmRunService.GetLabSheetModelListWithMWQMRunTVItemIDDB((int)labSheet.MWQMRunTVItemID);
                    Assert.IsTrue(labSheetModelList.Count > 0);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMRunModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    int mwqmRunCount = mwqmRunService.GetMWQMRunModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, mwqmRunCount);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMRunModelLastWithSubsectorTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    mwqmRunModelRet.DateTime_Local = DateTime.Now.AddYears(10);

                    MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostUpdateMWQMRunDB(mwqmRunModelRet);
                    Assert.AreEqual("", mwqmRunModelRet2.Error);

                    MWQMRunModel mwqmRunModelRet3 = mwqmRunService.GetMWQMRunModelLastWithSubsectorTVItemIDDB(mwqmRunModelRet.SubsectorTVItemID);
                    Assert.AreEqual("", mwqmRunModelRet3.Error);
                    Assert.AreEqual(mwqmRunModelRet2.DateTime_Local, mwqmRunModelRet3.DateTime_Local);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMRunModelListWithSubsectorTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    List<MWQMRunModel> mwqmRunModelList = mwqmRunService.GetMWQMRunModelListWithSubsectorTVItemIDDB(mwqmRunModelRet.SubsectorTVItemID);
                    Assert.IsTrue(mwqmRunModelList.Where(c => c.MWQMRunID == mwqmRunModelRet.MWQMRunID).Any());

                    int SubsectorTVItemID = 0;
                    mwqmRunModelList = mwqmRunService.GetMWQMRunModelListWithSubsectorTVItemIDDB(SubsectorTVItemID);
                    Assert.AreEqual(0, mwqmRunModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMRunModelWithSubsectorTVItemIDAndRunDateDB_1_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    List<MWQMRunModel> mwqmRunModelList = mwqmRunService.GetMWQMRunModelWithSubsectorTVItemIDAndRunDateDB(mwqmRunModelRet.SubsectorTVItemID, mwqmRunModelRet.DateTime_Local);
                    Assert.IsTrue(mwqmRunModelList.Where(c => c.MWQMRunID == mwqmRunModelRet.MWQMRunID).Any());

                    int SubsectorTVItemID = 0;
                    mwqmRunModelList = mwqmRunService.GetMWQMRunModelWithSubsectorTVItemIDAndRunDateDB(SubsectorTVItemID, mwqmRunModelRet.DateTime_Local);
                    Assert.AreEqual(0, mwqmRunModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMRunModelWithSubsectorTVItemIDAndRunDateDB_2_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet1 = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet1.Error);

                    MWQMRunModel mwqmRunModelRet2 = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet2.Error);

                    mwqmRunModelRet2.DateTime_Local = mwqmRunModelRet1.DateTime_Local.AddMinutes(1);
                    mwqmRunModelRet2.SubsectorTVItemID = mwqmRunModelRet1.SubsectorTVItemID;

                    MWQMRunModel mwqmRunModelRet3 = mwqmRunService.PostUpdateMWQMRunDB(mwqmRunModelRet2);
                    Assert.AreEqual("", mwqmRunModelRet3.Error);

                    List<MWQMRunModel> mwqmRunModelList = mwqmRunService.GetMWQMRunModelWithSubsectorTVItemIDAndRunDateDB(mwqmRunModelRet1.SubsectorTVItemID, mwqmRunModelRet1.DateTime_Local);
                    Assert.IsTrue(mwqmRunModelList.Where(c => c.MWQMRunID == mwqmRunModelRet1.MWQMRunID).Any());
                    Assert.IsTrue(mwqmRunModelList.Count > 1);

                    int SubsectorTVItemID = 0;
                    mwqmRunModelList = mwqmRunService.GetMWQMRunModelWithSubsectorTVItemIDAndRunDateDB(SubsectorTVItemID, mwqmRunModelRet1.DateTime_Local);
                    Assert.AreEqual(0, mwqmRunModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMRunModelWithMWQMRunIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    MWQMRunModel mwqmRunModelRet2 = mwqmRunService.GetMWQMRunModelWithMWQMRunIDDB(mwqmRunModelRet.MWQMRunID);
                    Assert.AreEqual(mwqmRunModelRet.MWQMRunID, mwqmRunModelRet2.MWQMRunID);

                    int MWQMRunID = 0;
                    mwqmRunModelRet2 = mwqmRunService.GetMWQMRunModelWithMWQMRunIDDB(MWQMRunID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMRun, ServiceRes.MWQMRunID, MWQMRunID), mwqmRunModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMRunModelWithMWQMRunTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    MWQMRunModel mwqmRunModelRet2 = mwqmRunService.GetMWQMRunModelWithMWQMRunTVItemIDDB(mwqmRunModelRet.MWQMRunTVItemID);
                    Assert.AreEqual("", mwqmRunModelRet2.Error);

                    int MWQMRunTVItemID = 0;
                    mwqmRunModelRet2 = mwqmRunService.GetMWQMRunModelWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMRun, ServiceRes.MWQMRunTVItemID, MWQMRunTVItemID), mwqmRunModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMRunModelWithSampleCrewInitialsContainsDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    mwqmRunModelRet = mwqmRunService.PostUpdateMWQMRunDB(mwqmRunModelRet);
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    MWQMRunModel mwqmRunModelRet2 = mwqmRunService.GetMWQMRunModelWithSampleCrewInitialsContainsDB(mwqmRunModelRet.SampleCrewInitials);
                    Assert.AreEqual(mwqmRunModelRet.MWQMRunID, mwqmRunModelRet2.MWQMRunID);

                    string SampleCrewInitials = "will not exist";
                    mwqmRunModelRet2 = mwqmRunService.GetMWQMRunModelWithSampleCrewInitialsContainsDB(SampleCrewInitials);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMRun, ServiceRes.SampleCrewInitials, SampleCrewInitials), mwqmRunModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMRunModelWithLabSampleApprovalContactTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    mwqmRunModelRet.LabSampleApprovalContactTVItemID = contactModelListGood[0].ContactTVItemID;
                    MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostUpdateMWQMRunDB(mwqmRunModelRet);
                    Assert.AreEqual("", mwqmRunModelRet2.Error);

                    List<MWQMRunModel> mwqmRunModelList = mwqmRunService.GetMWQMRunModelListWithLabSampleApprovalContactTVItemIDDB((int)mwqmRunModelRet2.LabSampleApprovalContactTVItemID);
                    Assert.IsTrue(mwqmRunModelList.Where(c => c.LabSampleApprovalContactTVItemID == mwqmRunModelRet.LabSampleApprovalContactTVItemID).Any());

                    int LabSampleApprovalContactTVItemID = 0;
                    List<MWQMRunModel> mwqmRunModelList2 = mwqmRunService.GetMWQMRunModelListWithLabSampleApprovalContactTVItemIDDB(LabSampleApprovalContactTVItemID);
                    Assert.IsTrue(mwqmRunModelList2.Count == 0);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMRunModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    MWQMRunModel mwqmRunModelRet2 = mwqmRunService.GetMWQMRunModelExistDB(mwqmRunModelRet);
                    Assert.AreEqual(mwqmRunModelRet.MWQMRunID, mwqmRunModelRet2.MWQMRunID);

                    mwqmRunModelRet.SubsectorTVItemID = 0;
                    mwqmRunModelRet2 = mwqmRunService.GetMWQMRunModelExistDB(mwqmRunModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMRun,
                        ServiceRes.SubsectorTVItemID + "," +
                        ServiceRes.DateTime_Local + "," +
                        ServiceRes.RunSampleType,
                        mwqmRunModelRet.SubsectorTVItemID + "," +
                        mwqmRunModelRet.DateTime_Local + "," +
                        mwqmRunModelRet.RunSampleType.ToString()), mwqmRunModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMRunWithMWQMRunIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    MWQMRun mwqmRunRet = mwqmRunService.GetMWQMRunWithMWQMRunIDDB(mwqmRunModelRet.MWQMRunID);
                    Assert.AreEqual(mwqmRunModelRet.MWQMRunID, mwqmRunRet.MWQMRunID);

                    int MWQMRunID = 0;
                    MWQMRun mwqmRunRet2 = mwqmRunService.GetMWQMRunWithMWQMRunIDDB(MWQMRunID);
                    Assert.IsNull(mwqmRunRet2);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMRunWithMWQMRunTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    MWQMRun mwqmRunRet = mwqmRunService.GetMWQMRunWithMWQMRunTVItemIDDB(mwqmRunModelRet.MWQMRunTVItemID);
                    Assert.AreEqual(mwqmRunModelRet.MWQMRunID, mwqmRunRet.MWQMRunID);

                    int MWQMRunTVItemID = 0;
                    MWQMRun mwqmRunRet2 = mwqmRunService.GetMWQMRunWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
                    Assert.IsNull(mwqmRunRet2);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_GetMWQMSampleCountWithMWQMRunTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    int count = mwqmRunService.GetMWQMSampleCountWithMWQMRunTVItemIDDB(mwqmRunModelRet.MWQMRunTVItemID);
                    Assert.AreEqual(0, count);

                    int MWQMRunTVItemID = (from c in mwqmRunService.db.MWQMSamples
                                           select c.MWQMRunTVItemID).FirstOrDefault();

                    Assert.IsTrue(MWQMRunTVItemID > 0);

                    count = mwqmRunService.GetMWQMSampleCountWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
                    Assert.IsTrue(count > 0);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MWQMRunModel mwqmRunModelRet = mwqmRunService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_ChangeLabSheetAndRemoveLabSheetDetail_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in mwqmRunService.db.LabSheets
                                         where c.MWQMRunTVItemID > 0
                                         select c).FirstOrDefault();

                    Assert.IsNotNull(labSheet);

                    List<LabSheetModel> labSheetModelList = mwqmRunService.GetLabSheetModelListWithMWQMRunTVItemIDDB((int)labSheet.MWQMRunTVItemID);
                    Assert.IsTrue(labSheetModelList.Count > 0);

                    LabSheetModel labSheetModel = labSheetModelList[0];
                    Assert.AreEqual("", labSheetModel.Error);

                    string retStr = mwqmRunService.ChangeLabSheetAndRemoveLabSheetDetail(labSheetModel);
                    Assert.AreEqual("", retStr);

                    List<LabSheetModel> labSheetModelList2 = mwqmRunService.GetLabSheetModelListWithMWQMRunTVItemIDDB((int)labSheet.MWQMRunTVItemID);
                    Assert.IsFalse(labSheetModelList2.Where(c => c.MWQMRunTVItemID == labSheetModel.MWQMRunTVItemID).Any());

                    LabSheetDetail labSheetDetail = (from c in mwqmRunService.db.LabSheetDetails
                                                     where c.LabSheetID == labSheetModel.LabSheetID
                                                     select c).FirstOrDefault();

                    Assert.IsNull(labSheetDetail);

                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual("", mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_SubsectorTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc.Remove("SubsectorTVItemID");

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID), mwqmRunModelRet.Error);

                    fc["SubsectorTVItemID"] = "";

                    mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID), mwqmRunModelRet.Error);

                    fc["SubsectorTVItemID"] = "0";

                    mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["SubsectorTVItemID"] = "928394848";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_RunDateYear_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc.Remove("RunDateYear");

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RunDateYear), mwqmRunModelRet.Error);

                    fc["RunDateYear"] = "";

                    mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RunDateYear), mwqmRunModelRet.Error);

                    fc["RunDateYear"] = "0";

                    mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RunDateYear), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_RunDateMonth_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc.Remove("RunDateMonth");

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RunDateMonth), mwqmRunModelRet.Error);

                    fc["RunDateMonth"] = "";

                    mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RunDateMonth), mwqmRunModelRet.Error);

                    fc["RunDateMonth"] = "0";

                    mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RunDateMonth), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_RunDateDay_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc.Remove("RunDateDay");

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RunDateDay), mwqmRunModelRet.Error);

                    fc["RunDateDay"] = "";

                    mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RunDateDay), mwqmRunModelRet.Error);

                    fc["RunDateDay"] = "0";

                    mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RunDateDay), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_NotValidDate_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc.Remove("RunDateYear");
                    fc["RunDateYear"] = "1949";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes.PleaseEnterAValidDateFor_, ServiceRes.RunDate), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_RunStartTime_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["RunStartTime"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.StartDateTime_Local);

                    fc["RunStartTime"] = "    ";

                    mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.StartDateTime_Local);

                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_RunStartTime_BadFormat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";

                    foreach (string badTimeFormat in BadTimeFormatList)
                    {
                        fc["RunStartTime"] = badTimeFormat;

                        MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes.Time_NotWellFormed, badTimeFormat), mwqmRunModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_RunEndTime_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["RunEndTime"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.EndDateTime_Local);

                    fc["RunEndTime"] = "   ";

                    mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.EndDateTime_Local);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_RunEndTime_BadFormat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["RunStartTime"] = "00:00";

                    foreach (string badTimeFormat in BadTimeFormatList)
                    {
                        fc["RunEndTime"] = badTimeFormat;

                        MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                        if (badTimeFormat == "aa:bb")
                        {
                            Assert.AreEqual(string.Format(ServiceRes.Time_NotWellFormed, "0"), mwqmRunModelRet.Error);
                        }
                        else
                        {
                            Assert.AreEqual(string.Format(ServiceRes.Time_NotWellFormed, badTimeFormat), mwqmRunModelRet.Error);
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_LabReceivedRunSample_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["LabReceivedRunSample"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual("", mwqmRunModelRet.Error);
                    Assert.IsNull(mwqmRunModelRet.LabReceivedDateTime_Local);

                    fc["LabReceivedRunSample"] = "0";
                    fc["RunDateDay"] = (int.Parse(fc["RunDateDay"]) + 1).ToString();

                    mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual("", mwqmRunModelRet.Error);
                    Assert.IsNull(mwqmRunModelRet.LabReceivedDateTime_Local);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_SameDayNextDayEnum_Invalid_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["LabReceivedRunSample"] = "3"; // bigger than SameDayNextDayEnum

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SameDayNextDay), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_LabReceivedTime_BadFormat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    foreach (string badTimeFormat in BadTimeFormatList)
                    {
                        fc["LabReceivedTime"] = badTimeFormat;

                        MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes.Time_NotWellFormed, badTimeFormat), mwqmRunModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_TemperatureControl1_C_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["TemperatureControl1_C"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.TemperatureControl1_C);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_TemperatureControl1_C_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["TemperatureControl1_C"] = "asf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsNotANumberForField_, fc["TemperatureControl1_C"], ServiceRes.TemperatureControl1_C), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_TemperatureControl2_C_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["TemperatureControl2_C"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.TemperatureControl2_C);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_TemperatureControl2_C_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["TemperatureControl2_C"] = "asf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsNotANumberForField_, fc["TemperatureControl2_C"], ServiceRes.TemperatureControl2_C), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_SeaStateAtStart_BeaufortScale_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["SeaStateAtStart_BeaufortScale"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.SeaStateAtStart_BeaufortScale);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_SeaStateAtStart_BeaufortScale_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["SeaStateAtStart_BeaufortScale"] = "asf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SeaStateAtStart_BeaufortScale), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_SeaStateAtEnd_BeaufortScale_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["SeaStateAtEnd_BeaufortScale"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.SeaStateAtEnd_BeaufortScale);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_SeaStateAtEnd_BeaufortScale_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["SeaStateAtEnd_BeaufortScale"] = "asf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SeaStateAtEnd_BeaufortScale), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_WaterLevelAtBrook_m_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["WaterLevelAtBrook_m"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.WaterLevelAtBrook_m);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_WaterLevelAtBrook_m_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["WaterLevelAtBrook_m"] = "asf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsNotANumberForField_, fc["WaterLevelAtBrook_m"], ServiceRes.WaterLevelAtBrook_m), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_WaveHightAtStart_m_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["WaveHightAtStart_m"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.WaveHightAtStart_m);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_WaveHightAtStart_m_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["WaveHightAtStart_m"] = "asf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsNotANumberForField_, fc["WaveHightAtStart_m"], ServiceRes.WaveHightAtStart_m), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_WaveHightAtEnd_m_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["WaveHightAtEnd_m"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.WaveHightAtEnd_m);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_WaveHightAtEnd_m_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["WaveHightAtEnd_m"] = "asf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsNotANumberForField_, fc["WaveHightAtEnd_m"], ServiceRes.WaveHightAtEnd_m), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_SampleCrewInitials_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["SampleCrewInitials"] = "aa";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(fc["SampleCrewInitials"], mwqmRunModelRet.SampleCrewInitials);

                    fc["RunDateDay"] = (mwqmRunModelRet.DateTime_Local.Day + 1).ToString();
                    fc["SampleCrewInitials"] = "aa,bb,cc";

                    mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(fc["SampleCrewInitials"], mwqmRunModelRet.SampleCrewInitials);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_AnalyzeMethod_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["AnalyzeMethod"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.AnalyzeMethod);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_AnalyzeMethod_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["AnalyzeMethod"] = "asf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AnalyzeMethod), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_SampleMatrix_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["SampleMatrix"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.SampleMatrix);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_SampleMatrix_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["SampleMatrix"] = "asf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SampleMatrix), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_Laboratory_Return_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["Laboratory"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.Laboratory);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_Laboratory_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["Laboratory"] = "asf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Laboratory), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_LabAnalyzeStartIncubationDay_SameDayNextDayEnum_Invalid_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["LabAnalyzeStartIncubationDay"] = "3"; // bigger than SameDayNextDayEnum

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SameDayNextDay), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_LabAnalyzeStartIncubationTime_BadFormat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    foreach (string badTimeFormat in BadTimeFormatList)
                    {
                        fc["LabAnalyzeStartIncubationTime"] = badTimeFormat;

                        MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes.Time_NotWellFormed, badTimeFormat), mwqmRunModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_LabSampleApprovalContactTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["LabSampleApprovalContactTVItemID"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.LabSampleApprovalContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_LabSampleApprovalContactTVItemID_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            count += 1;
                            if (count < 2)
                                return new TVItemModel();

                            return new TVItemModel() { Error = ErrorText };
                        };

                        MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet.Error);
                    }

                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_LabRunSampleApprovalTime_BadFormat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    foreach (string badTimeFormat in BadTimeFormatList)
                    {
                        fc["LabRunSampleApprovalTime"] = badTimeFormat;

                        MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes.Time_NotWellFormed, badTimeFormat), mwqmRunModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_PPT24_mm_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["PPT24_mm"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.PPT24_mm);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_PPT24_mm_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["PPT24_mm"] = "asdf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsNotANumberForField_, fc["PPT24_mm"], ServiceRes.PPT24_mm), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_PPT48_mm_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["PPT48_mm"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.PPT48_mm);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_PPT48_mm_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["PPT48_mm"] = "asdf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsNotANumberForField_, fc["PPT48_mm"], ServiceRes.PPT48_mm), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_PPT72_mm_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["PPT72_mm"] = "";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.IsNull(mwqmRunModelRet.PPT72_mm);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_PPT72_mm_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["PPT72_mm"] = "asdf";

                    MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsNotANumberForField_, fc["PPT72_mm"], ServiceRes.PPT72_mm), mwqmRunModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["RunDateDay"] = (int.Parse(fc["RunDateDay"]) + 1).ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Add_PostAddMWQMRunDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    fc["MWQMRunTVItemID"] = "0";
                    fc["RunDateDay"] = (int.Parse(fc["RunDateDay"]) + 1).ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMRunService.PostAddMWQMRunDBMWQMRunModel = (a) =>
                        {
                            return new MWQMRunModel() { Error = ErrorText };
                        };

                        MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Modify_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    //fc["MWQMRunTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMRunService.GetMWQMRunModelWithMWQMRunTVItemIDDBInt32 = (a) =>
                        {
                            return new MWQMRunModel() { Error = ErrorText };
                        };

                        MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_MWQMRunAddOrModifyDB_Modify_PostUpdateMWQMRunDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMRunAddOrModify();
                    Assert.IsNotNull(fc);

                    //fc["MWQMRunTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMRunService.PostUpdateMWQMRunDBMWQMRunModel = (a) =>
                        {
                            return new MWQMRunModel() { Error = ErrorText };
                        };

                        MWQMRunModel mwqmRunModelRet = mwqmRunService.MWQMRunAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostAddUpdateDeleteMWQMRun_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostUpdateMWQMRunDB(mwqmRunModelRet);
                    Assert.AreEqual("", mwqmRunModelRet2.Error);

                    MWQMRunModel mwqmRunModelRet3 = mwqmRunService.PostDeleteMWQMRunTVItemIDDB(mwqmRunModelRet2.MWQMRunTVItemID);
                    Assert.AreEqual("", mwqmRunModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostAddMWQMRunDB_MWQMRunModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunService.MWQMRunModelOKMWQMRunModel = (a) =>
                        {
                            return ErrorText;
                        };

                        mwqmRunModelRet.StartDateTime_Local = mwqmRunModelRet.StartDateTime_Local.Value.AddMinutes(1);

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostAddMWQMRunDB(mwqmRunModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostAddMWQMRunDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        mwqmRunModelRet.StartDateTime_Local = mwqmRunModelRet.StartDateTime_Local.Value.AddMinutes(1);

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostAddMWQMRunDB(mwqmRunModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostAddMWQMRunDB_GetMWQMRunModelExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMRunService.GetMWQMRunModelExistDBMWQMRunModel = (a) =>
                        {
                            return new MWQMRunModel() { Error = "" };
                        };

                        mwqmRunModelRet.StartDateTime_Local = mwqmRunModelRet.StartDateTime_Local.Value.AddMinutes(1);

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostAddMWQMRunDB(mwqmRunModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMRun), mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostAddMWQMRunDB_FillMWQMRun_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    mwqmRunModelRet.DateTime_Local = DateTime.Now;

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunService.FillMWQMRunMWQMRunMWQMRunModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        mwqmRunModelRet.StartDateTime_Local = mwqmRunModelRet.StartDateTime_Local.Value.AddMinutes(1);

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostAddMWQMRunDB(mwqmRunModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostAddMWQMRunDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    mwqmRunModelRet.DateTime_Local = DateTime.Now;

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        mwqmRunModelRet.StartDateTime_Local = mwqmRunModelRet.StartDateTime_Local.Value.AddMinutes(1);

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostAddMWQMRunDB(mwqmRunModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostAddMWQMRunDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    mwqmRunModelRet.DateTime_Local = DateTime.Now;

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMRunService.FillMWQMRunMWQMRunMWQMRunModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        mwqmRunModelRet.StartDateTime_Local = mwqmRunModelRet.StartDateTime_Local.Value.AddMinutes(1);

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostAddMWQMRunDB(mwqmRunModelRet);
                        Assert.IsTrue(mwqmRunModelRet2.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostAddMWQMRunDB_PostAddMWQMRunLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    mwqmRunModelRet.DateTime_Local = DateTime.Now;

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.PostAddMWQMRunLanguageDBMWQMRunLanguageModel = (a) =>
                        {
                            return new MWQMRunLanguageModel() { Error = ErrorText };
                        };

                        mwqmRunModelRet.StartDateTime_Local = mwqmRunModelRet.StartDateTime_Local.Value.AddMinutes(1);

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostAddMWQMRunDB(mwqmRunModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostAddMWQMRunDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    mwqmRunModelRet.StartDateTime_Local = mwqmRunModelRet.StartDateTime_Local.Value.AddMinutes(1);

                    SetupTest(contactModelListBad[0], culture);

                    MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostAddMWQMRunDB(mwqmRunModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mwqmRunModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostDeleteMWQMRun_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostDeleteMWQMRunTVItemIDDB(mwqmRunModelRet.MWQMRunTVItemID);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostDeleteMWQMRun_GetMWQMRunWithMWQMRunTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMRunService.GetMWQMRunWithMWQMRunTVItemIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostDeleteMWQMRunTVItemIDDB(mwqmRunModelRet.MWQMRunTVItemID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMRun), mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostDeleteMWQMRun_GetLabSheetModelListWithMWQMRunTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunService.GetLabSheetModelListWithMWQMRunTVItemIDDBInt32 = (a) =>
                        {
                            return new List<LabSheetModel>() { new LabSheetModel() };
                        };
                        shimMWQMRunService.ChangeLabSheetAndRemoveLabSheetDetailLabSheetModel = (a) =>
                        {
                            return ErrorText;
                        };
                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostDeleteMWQMRunTVItemIDDB(mwqmRunModelRet.MWQMRunTVItemID);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostDeleteMWQMRun_GetMWQMSampleCountWithMWQMRunTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMRunService.GetMWQMSampleCountWithMWQMRunTVItemIDDBInt32 = (a) =>
                        {
                            return 1;
                        };

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostDeleteMWQMRunTVItemIDDB(mwqmRunModelRet.MWQMRunTVItemID);
                        Assert.AreEqual(ServiceRes.AllSamplesHasToBeDeletedManuallyBeforeBeingAbleToDeleteTheRun, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostDeleteMWQMRun_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText } ;
                        };

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostDeleteMWQMRunTVItemIDDB(mwqmRunModelRet.MWQMRunTVItemID);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostDeleteMWQMRun_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostDeleteMWQMRunTVItemIDDB(mwqmRunModelRet.MWQMRunTVItemID);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostUpdateMWQMRun_MWQMRunModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunService.MWQMRunModelOKMWQMRunModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostUpdateMWQMRunDB(mwqmRunModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostUpdateMWQMRun_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostUpdateMWQMRunDB(mwqmRunModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostUpdateMWQMRun_GetMWQMRunWithMWQMRunIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMRunService.GetMWQMRunWithMWQMRunIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostUpdateMWQMRunDB(mwqmRunModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMRun), mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostUpdateMWQMRun_FillMWQMRun_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunService.FillMWQMRunMWQMRunMWQMRunModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostUpdateMWQMRunDB(mwqmRunModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostUpdateMWQMRun_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostUpdateMWQMRunDB(mwqmRunModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMRunService_PostUpdateMWQMRun_PostUpdateMWQMRunLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMRunModel mwqmRunModelRet = AddMWQMRunModel();
                    Assert.AreEqual("", mwqmRunModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMRunLanguageService.PostUpdateMWQMRunLanguageDBMWQMRunLanguageModel = (a) =>
                        {
                            return new MWQMRunLanguageModel() { Error = ErrorText };
                        };

                        MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostUpdateMWQMRunDB(mwqmRunModelRet);
                        Assert.AreEqual(ErrorText, mwqmRunModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public MWQMRunModel AddMWQMRunModel()
        {
            TVItemModel tvItemModelSubsector = randomService.RandomTVItem(TVTypeEnum.Subsector);
            mwqmRunModelNew.SubsectorTVItemID = tvItemModelSubsector.TVItemID;
            Assert.IsTrue(mwqmRunModelNew.SubsectorTVItemID > 0);

            TVItemModel tvItemModelMWQMRun = tvItemService.PostAddChildTVItemDB(tvItemModelSubsector.TVItemID, randomService.RandomString("Unique run", 30), TVTypeEnum.MWQMRun);
            Assert.AreEqual("", tvItemModelMWQMRun.Error);

            mwqmRunModelNew.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
            mwqmRunModelNew.RunSampleType = SampleTypeEnum.Routine;
            FillMWQMRunModel(mwqmRunModelNew);

            MWQMRunModel mwqmRunModelRet = mwqmRunService.PostAddMWQMRunDB(mwqmRunModelNew);
            if (!string.IsNullOrWhiteSpace(mwqmRunModelRet.Error))
            {
                return mwqmRunModelRet;
            }

            CompareMWQMRunModels(mwqmRunModelNew, mwqmRunModelRet);

            return mwqmRunModelRet;
        }
        public MWQMRunModel UpdateMWQMRunModel(MWQMRunModel mwqmRunModel)
        {
            FillMWQMRunModel(mwqmRunModel);

            MWQMRunModel mwqmRunModelRet2 = mwqmRunService.PostUpdateMWQMRunDB(mwqmRunModel);
            if (!string.IsNullOrWhiteSpace(mwqmRunModelRet2.Error))
            {
                return mwqmRunModelRet2;
            }

            CompareMWQMRunModels(mwqmRunModel, mwqmRunModelRet2);

            return mwqmRunModelRet2;
        }
        private void CompareMWQMRunModels(MWQMRunModel mwqmRunModelNew, MWQMRunModel mwqmRunModelRet)
        {
            Assert.AreEqual(mwqmRunModelNew.SubsectorTVItemID, mwqmRunModelRet.SubsectorTVItemID);
            Assert.AreEqual(mwqmRunModelNew.MWQMRunTVItemID, mwqmRunModelRet.MWQMRunTVItemID);
            Assert.AreEqual(mwqmRunModelNew.DateTime_Local, mwqmRunModelRet.DateTime_Local);
            Assert.AreEqual(mwqmRunModelNew.StartDateTime_Local, mwqmRunModelRet.StartDateTime_Local);
            Assert.AreEqual(mwqmRunModelNew.EndDateTime_Local, mwqmRunModelRet.EndDateTime_Local);
            Assert.AreEqual(mwqmRunModelNew.LabReceivedDateTime_Local, mwqmRunModelRet.LabReceivedDateTime_Local);
            Assert.AreEqual(mwqmRunModelNew.TemperatureControl1_C, mwqmRunModelRet.TemperatureControl1_C);
            Assert.AreEqual(mwqmRunModelNew.TemperatureControl2_C, mwqmRunModelRet.TemperatureControl2_C);
            Assert.AreEqual(mwqmRunModelNew.SeaStateAtEnd_BeaufortScale, mwqmRunModelRet.SeaStateAtEnd_BeaufortScale);
            Assert.AreEqual(mwqmRunModelNew.SeaStateAtStart_BeaufortScale, mwqmRunModelRet.SeaStateAtStart_BeaufortScale);
            Assert.AreEqual(mwqmRunModelNew.WaterLevelAtBrook_m, mwqmRunModelRet.WaterLevelAtBrook_m);
            Assert.AreEqual(mwqmRunModelNew.WaveHightAtEnd_m, mwqmRunModelRet.WaveHightAtEnd_m);
            Assert.AreEqual(mwqmRunModelNew.WaveHightAtStart_m, mwqmRunModelRet.WaveHightAtStart_m);
            Assert.AreEqual(mwqmRunModelNew.SampleCrewInitials, mwqmRunModelRet.SampleCrewInitials);
            Assert.AreEqual(mwqmRunModelNew.AnalyzeMethod, mwqmRunModelRet.AnalyzeMethod);
            Assert.AreEqual(mwqmRunModelNew.SampleMatrix, mwqmRunModelRet.SampleMatrix);
            Assert.AreEqual(mwqmRunModelNew.Laboratory, mwqmRunModelRet.Laboratory);
            Assert.AreEqual(mwqmRunModelNew.SampleStatus, mwqmRunModelRet.SampleStatus);
            Assert.AreEqual(mwqmRunModelNew.LabSampleApprovalContactTVItemID, mwqmRunModelRet.LabSampleApprovalContactTVItemID);
            Assert.AreEqual(mwqmRunModelNew.LabAnalyzeIncubationStartDateTime_Local, mwqmRunModelRet.LabAnalyzeIncubationStartDateTime_Local);
            Assert.AreEqual(mwqmRunModelNew.LabRunSampleApprovalDateTime_Local, mwqmRunModelRet.LabRunSampleApprovalDateTime_Local);
            Assert.AreEqual(mwqmRunModelNew.PPT24_mm, mwqmRunModelRet.PPT24_mm);
            Assert.AreEqual(mwqmRunModelNew.PPT48_mm, mwqmRunModelRet.PPT48_mm);
            Assert.AreEqual(mwqmRunModelNew.PPT72_mm, mwqmRunModelRet.PPT72_mm);

            foreach (LanguageEnum Lang in mwqmRunService.LanguageListAllowable)
            {
                MWQMRunLanguageModel mwqmRunLanguageModel = mwqmRunService._MWQMRunLanguageService.GetMWQMRunLanguageModelWithMWQMRunIDAndLanguageDB(mwqmRunModelRet.MWQMRunID, Lang);
                Assert.AreEqual("", mwqmRunLanguageModel.Error);
                if (Lang == mwqmRunService.LanguageRequest)
                {
                    Assert.AreEqual(mwqmRunModelRet.MWQMRunComment, mwqmRunLanguageModel.MWQMRunComment);
                }
            }
        }
        private FormCollection FillFormCollectionForMWQMRunAddOrModify()
        {
            FormCollection fc = new FormCollection();
            MWQMRunModel mwqmRunModel = AddMWQMRunModel();
            Assert.AreEqual("", mwqmRunModel.Error);

            fc.Add("SubsectorTVItemID", mwqmRunModel.SubsectorTVItemID.ToString());
            fc.Add("MWQMRunTVItemID", mwqmRunModel.MWQMRunTVItemID.ToString());
            fc.Add("RunSampleType", ((int)SampleTypeEnum.Routine).ToString());
            fc.Add("RunDateYear", mwqmRunModel.DateTime_Local.Year.ToString());
            fc.Add("RunDateMonth", mwqmRunModel.DateTime_Local.Month.ToString());
            fc.Add("RunDateDay", mwqmRunModel.DateTime_Local.Day.ToString());
            fc.Add("RunStartTime", ((DateTime)mwqmRunModel.StartDateTime_Local).ToString("hh:mm"));
            fc.Add("RunEndTime", ((DateTime)mwqmRunModel.EndDateTime_Local).ToString("hh:mm"));

            if (mwqmRunModel.LabReceivedDateTime_Local.Value.Year == mwqmRunModel.DateTime_Local.Year &&
                mwqmRunModel.LabReceivedDateTime_Local.Value.Month == mwqmRunModel.DateTime_Local.Month &&
                mwqmRunModel.LabReceivedDateTime_Local.Value.Day == mwqmRunModel.DateTime_Local.Day)
            {
                fc.Add("LabReceivedRunSample", ((int)SameDayNextDayEnum.SameDay).ToString());
            }
            else
            {
                fc.Add("LabReceivedRunSample", ((int)SameDayNextDayEnum.NextDay).ToString());
            }
            fc.Add("LabReceivedTime", ((DateTime)mwqmRunModel.LabReceivedDateTime_Local.Value).ToString("hh:mm"));
            fc.Add("TemperatureControl1_C", mwqmRunModel.TemperatureControl1_C.ToString());
            fc.Add("TemperatureControl2_C", mwqmRunModel.TemperatureControl2_C.ToString());
            fc.Add("SeaStateAtStart_BeaufortScale", ((int)mwqmRunModel.SeaStateAtStart_BeaufortScale).ToString());
            fc.Add("SeaStateAtEnd_BeaufortScale", ((int)mwqmRunModel.SeaStateAtEnd_BeaufortScale).ToString());
            fc.Add("WaterLevelAtBrook_m", ((float)mwqmRunModel.WaterLevelAtBrook_m).ToString("F1"));
            fc.Add("WaveHightAtStart_m", ((float)mwqmRunModel.WaveHightAtStart_m).ToString("F1"));
            fc.Add("WaveHightAtEnd_m", ((float)mwqmRunModel.WaveHightAtEnd_m).ToString("F1"));
            fc.Add("SampleCrewInitials", mwqmRunModel.SampleCrewInitials);
            fc.Add("AnalyzeMethod", ((int)mwqmRunModel.AnalyzeMethod).ToString());
            fc.Add("SampleMatrix", ((int)mwqmRunModel.SampleMatrix).ToString());
            fc.Add("Laboratory", ((int)mwqmRunModel.Laboratory).ToString());

            if (mwqmRunModel.LabAnalyzeIncubationStartDateTime_Local.Value.Year == mwqmRunModel.DateTime_Local.Year &&
                mwqmRunModel.LabAnalyzeIncubationStartDateTime_Local.Value.Month == mwqmRunModel.DateTime_Local.Month &&
                mwqmRunModel.LabAnalyzeIncubationStartDateTime_Local.Value.Day == mwqmRunModel.DateTime_Local.Day)
            {
                fc.Add("LabAnalyzeStartIncubationDay", ((int)SameDayNextDayEnum.SameDay).ToString());
            }
            else
            {
                fc.Add("LabAnalyzeStartIncubationDay", ((int)SameDayNextDayEnum.NextDay).ToString());
            }

            fc.Add("LabAnalyzeStartIncubationTime", ((DateTime)mwqmRunModel.LabAnalyzeIncubationStartDateTime_Local).ToString("hh:mm"));
            fc.Add("LabSampleApprovalContactTVItemID", mwqmRunModel.LabSampleApprovalContactTVItemID.ToString());
            fc.Add("LabRunSampleApprovalYear", mwqmRunModel.LabRunSampleApprovalDateTime_Local.Value.Year.ToString());
            fc.Add("LabRunSampleApprovalMonth", mwqmRunModel.LabRunSampleApprovalDateTime_Local.Value.Month.ToString());
            fc.Add("LabRunSampleApprovalDay", mwqmRunModel.LabRunSampleApprovalDateTime_Local.Value.Day.ToString());
            fc.Add("LabRunSampleApprovalTime", mwqmRunModel.LabRunSampleApprovalDateTime_Local.Value.ToString("hh:mm"));
            fc.Add("PPT24_mm", mwqmRunModel.PPT24_mm.ToString());
            fc.Add("PPT48_mm", mwqmRunModel.PPT48_mm.ToString());
            fc.Add("PPT72_mm", mwqmRunModel.PPT72_mm.ToString());
            fc.Add("MWQMRunComment", mwqmRunModel.MWQMRunComment.ToString());

            return fc;
        }
        private void FillMWQMRunModel(MWQMRunModel mwqmRunModel)
        {
            mwqmRunModel.SubsectorTVItemID = mwqmRunModel.SubsectorTVItemID;
            mwqmRunModel.MWQMRunTVItemID = mwqmRunModel.MWQMRunTVItemID;
            mwqmRunModel.RunSampleType = mwqmRunModel.RunSampleType;
            mwqmRunModel.DateTime_Local = randomService.RandomDateTime();
            mwqmRunModel.StartDateTime_Local = new DateTime(2015, 11, 8, 7, 12, 0);
            mwqmRunModel.EndDateTime_Local = mwqmRunModel.StartDateTime_Local.Value.AddHours(1);
            mwqmRunModel.LabReceivedDateTime_Local = mwqmRunModel.EndDateTime_Local.Value.AddHours(1);
            mwqmRunModel.TemperatureControl1_C = randomService.RandomInt(-45, 45);
            mwqmRunModel.TemperatureControl2_C = randomService.RandomInt(-45, 45);
            mwqmRunModel.SeaStateAtEnd_BeaufortScale = BeaufortScaleEnum.FreshBreeze;
            mwqmRunModel.SeaStateAtStart_BeaufortScale = BeaufortScaleEnum.Gale_FreshGale;
            mwqmRunModel.WaterLevelAtBrook_m = randomService.RandomDouble(0.0, 10.0);
            mwqmRunModel.WaveHightAtEnd_m = randomService.RandomDouble(0.0, 10.0);
            mwqmRunModel.WaveHightAtStart_m = randomService.RandomDouble(0.0, 10.0);
            mwqmRunModel.SampleCrewInitials = "AAA";
            mwqmRunModel.AnalyzeMethod = AnalyzeMethodEnum.MF;
            mwqmRunModel.SampleMatrix = SampleMatrixEnum.W;
            mwqmRunModel.Laboratory = LaboratoryEnum._0;
            mwqmRunModel.SampleStatus = SampleStatusEnum.SampleStatus3;
            mwqmRunModel.LabSampleApprovalContactTVItemID = 2;
            mwqmRunModel.LabAnalyzeIncubationStartDateTime_Local = mwqmRunModel.LabReceivedDateTime_Local.Value.AddHours(1);
            mwqmRunModel.LabRunSampleApprovalDateTime_Local = mwqmRunModel.LabAnalyzeIncubationStartDateTime_Local.Value.AddDays(1);
            mwqmRunModel.PPT24_mm = randomService.RandomDouble(0, 1000);
            mwqmRunModel.PPT48_mm = randomService.RandomDouble(0, 1000);
            mwqmRunModel.PPT72_mm = randomService.RandomDouble(0, 1000);
            mwqmRunModel.MWQMRunComment = randomService.RandomString("", 200);


            Assert.IsTrue(mwqmRunModel.SubsectorTVItemID != 0);
            Assert.IsTrue(mwqmRunModel.MWQMRunTVItemID != 0);
            Assert.IsTrue(mwqmRunModel.DateTime_Local != null);
            Assert.IsTrue(mwqmRunModel.StartDateTime_Local != null);
            Assert.IsTrue(mwqmRunModel.EndDateTime_Local != null);
            Assert.IsTrue(mwqmRunModel.LabReceivedDateTime_Local != null);
            Assert.IsTrue(mwqmRunModel.TemperatureControl1_C >= -45 && mwqmRunModel.TemperatureControl1_C <= 45);
            Assert.IsTrue(mwqmRunModel.TemperatureControl2_C >= -45 && mwqmRunModel.TemperatureControl2_C <= 45);
            Assert.IsTrue(mwqmRunModel.SeaStateAtEnd_BeaufortScale == BeaufortScaleEnum.FreshBreeze);
            Assert.IsTrue(mwqmRunModel.SeaStateAtStart_BeaufortScale == BeaufortScaleEnum.Gale_FreshGale);
            Assert.IsTrue(mwqmRunModel.WaterLevelAtBrook_m >= 0 && mwqmRunModel.WaterLevelAtBrook_m <= 10);
            Assert.IsTrue(mwqmRunModel.WaveHightAtEnd_m >= 0 && mwqmRunModel.WaveHightAtEnd_m <= 10);
            Assert.IsTrue(mwqmRunModel.WaveHightAtStart_m >= 0 && mwqmRunModel.WaveHightAtStart_m <= 10);
            Assert.IsTrue(mwqmRunModel.SampleCrewInitials == "AAA");
            Assert.IsTrue(mwqmRunModel.AnalyzeMethod == AnalyzeMethodEnum.MF);
            Assert.IsTrue(mwqmRunModel.SampleMatrix == SampleMatrixEnum.W);
            Assert.IsTrue(mwqmRunModel.Laboratory == LaboratoryEnum._0);
            Assert.IsTrue(mwqmRunModel.SampleStatus == SampleStatusEnum.SampleStatus3);
            Assert.IsTrue(mwqmRunModel.LabSampleApprovalContactTVItemID == 2);
            Assert.IsTrue(mwqmRunModel.LabAnalyzeIncubationStartDateTime_Local != null);
            Assert.IsTrue(mwqmRunModel.LabRunSampleApprovalDateTime_Local != null);
            Assert.IsTrue(mwqmRunModel.PPT24_mm >= 0 && mwqmRunModel.PPT24_mm <= 1000);
            Assert.IsTrue(mwqmRunModel.PPT48_mm >= 0 && mwqmRunModel.PPT24_mm <= 1000);
            Assert.IsTrue(mwqmRunModel.PPT72_mm >= 0 && mwqmRunModel.PPT24_mm <= 1000);
            Assert.IsTrue(mwqmRunModel.MWQMRunComment.Length == 200);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mwqmRunService = new MWQMRunService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmRunLanguageService = new MWQMRunLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmRunModelNew = new MWQMRunModel();
            mwqmRun = new MWQMRun();
        }
        private void SetupShim()
        {
            shimMWQMRunService = new ShimMWQMRunService(mwqmRunService);
            shimMWQMRunLanguageService = new ShimMWQMRunLanguageService(mwqmRunService._MWQMRunLanguageService);
            shimTVItemService = new ShimTVItemService(mwqmRunService._TVItemService);
        }
        #endregion Functions private
    }
}

