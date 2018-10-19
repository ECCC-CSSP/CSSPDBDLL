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
using System.IO;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;
using CSSPLabSheetParserDLL.Services;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for LabSheetTubeMPNDetailServiceTest
    /// </summary>
    [TestClass]
    public class LabSheetTubeMPNDetailServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "LabSheetTubeMPNDetail";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private LabSheetTubeMPNDetailService labSheetTubeMPNDetailService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelNew { get; set; }
        private LabSheetTubeMPNDetail labSheetTubeMPNDetail { get; set; }
        private AppTaskService appTaskService { get; set; }
        private TVFileService tvFileService { get; set; }
        private ShimLabSheetTubeMPNDetailService shimLabSheetTubeMPNDetailService { get; set; }
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
        public LabSheetTubeMPNDetailServiceTest()
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
        public void Add_new_LabSheetDetail_And_LabSheetTubeMPNDetail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetTubeMPNDetailService.db.LabSheets select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);

                string FullLabSheetText = labSheet.FileContent;

                CSSPLabSheetParser csspLabSheetParser = new CSSPLabSheetParser();
                LabSheetA1Sheet labSheetA1Sheet = csspLabSheetParser.ParseLabSheetA1(FullLabSheetText);

                DateTime RunDate = new DateTime(int.Parse(labSheetA1Sheet.RunYear), int.Parse(labSheetA1Sheet.RunMonth), int.Parse(labSheetA1Sheet.RunDay));
                DateTime SalinityReadDate = new DateTime(int.Parse(labSheetA1Sheet.SalinitiesReadYear), int.Parse(labSheetA1Sheet.SalinitiesReadMonth), int.Parse(labSheetA1Sheet.SalinitiesReadDay));
                DateTime ResultsReadDate = new DateTime(int.Parse(labSheetA1Sheet.ResultsReadYear), int.Parse(labSheetA1Sheet.ResultsReadMonth), int.Parse(labSheetA1Sheet.ResultsReadDay));
                DateTime ResultsRecordedDate = new DateTime(int.Parse(labSheetA1Sheet.ResultsRecordedYear), int.Parse(labSheetA1Sheet.ResultsRecordedMonth), int.Parse(labSheetA1Sheet.ResultsRecordedDay));
                //DateTime DuplicateDataEntryDate = new DateTime(int.Parse(labSheetA1Sheet.DuplicateDataEntryYear), int.Parse(labSheetA1Sheet.DuplicateDataEntryMonth), int.Parse(labSheetA1Sheet.DuplicateDataEntryDay));

                float TCFirst = 0.0f;
                try
                {
                    float.Parse(labSheetA1Sheet.TCFirst);
                }
                catch (Exception)
                {
                    TCFirst = (float)(from c in labSheetA1Sheet.LabSheetA1MeasurementList
                                      where c.Temperature != null
                                      select c.Temperature).FirstOrDefault();

                }

                float TCAverage = 0.0f;
                try
                {
                    float.Parse(labSheetA1Sheet.TCAverage);
                }
                catch (Exception)
                {
                    TCAverage = (float)(from c in labSheetA1Sheet.LabSheetA1MeasurementList
                                        where c.Temperature != null
                                        select c.Temperature).Average();

                }

                LabSheetDetailModel labSheetDetailModelNew = new LabSheetDetailModel();
                labSheetDetailModelNew.LabSheetID = labSheet.LabSheetID;
                labSheetDetailModelNew.MWQMPlanID = labSheet.MWQMPlanID;
                labSheetDetailModelNew.SubsectorTVItemID = labSheet.SubsectorTVItemID;
                labSheetDetailModelNew.Version = labSheetA1Sheet.Version;
                labSheetDetailModelNew.RunDate = RunDate.AddDays(1);
                labSheetDetailModelNew.Tides = labSheetA1Sheet.Tides;
                labSheetDetailModelNew.SampleCrewInitials = labSheetA1Sheet.SampleCrewInitials;
                labSheetDetailModelNew.IncubationStartTime = RunDate.AddDays(1).AddHours(int.Parse(labSheetA1Sheet.IncubationStartTime.Substring(0, 2))).AddMinutes(int.Parse(labSheetA1Sheet.IncubationStartTime.Substring(3, 2)));
                labSheetDetailModelNew.IncubationEndTime = RunDate.AddDays(1).AddHours(int.Parse(labSheetA1Sheet.IncubationEndTime.Substring(0, 2))).AddMinutes(int.Parse(labSheetA1Sheet.IncubationEndTime.Substring(3, 2)));
                labSheetDetailModelNew.IncubationTimeCalculated_minutes = int.Parse(labSheetA1Sheet.IncubationTimeCalculated.Substring(0, 2)) * 60 + int.Parse(labSheetA1Sheet.IncubationTimeCalculated.Substring(3, 2));
                labSheetDetailModelNew.WaterBath = labSheetA1Sheet.WaterBath;
                if (!string.IsNullOrWhiteSpace(labSheetA1Sheet.TCField1))
                {
                    labSheetDetailModelNew.TCField1 = float.Parse(labSheetA1Sheet.TCField1);
                }
                else
                {
                    labSheetDetailModelNew.TCField1 = null;
                }
                if (!string.IsNullOrWhiteSpace(labSheetA1Sheet.TCLab1))
                {
                    labSheetDetailModelNew.TCLab1 = float.Parse(labSheetA1Sheet.TCLab1);
                }
                else
                {
                    labSheetDetailModelNew.TCLab1 = null;
                }
                if (!string.IsNullOrWhiteSpace(labSheetA1Sheet.TCField2))
                {
                    labSheetDetailModelNew.TCField2 = float.Parse(labSheetA1Sheet.TCField2);
                }
                else
                {
                    labSheetDetailModelNew.TCField2 = null;
                }
                if (!string.IsNullOrWhiteSpace(labSheetA1Sheet.TCLab2))
                {
                    labSheetDetailModelNew.TCLab2 = float.Parse(labSheetA1Sheet.TCLab2);
                }
                else
                {
                    labSheetDetailModelNew.TCLab2 = null;
                }
                if (!string.IsNullOrWhiteSpace(labSheetA1Sheet.TCFirst))
                {
                    labSheetDetailModelNew.TCFirst = float.Parse(labSheetA1Sheet.TCFirst);
                }
                else
                {
                    labSheetDetailModelNew.TCFirst = null;
                }
                if (!string.IsNullOrWhiteSpace(labSheetA1Sheet.TCAverage))
                {
                    labSheetDetailModelNew.TCAverage = float.Parse(labSheetA1Sheet.TCAverage);
                }
                else
                {
                    labSheetDetailModelNew.TCAverage = null;
                }
                labSheetDetailModelNew.ControlLot = labSheetA1Sheet.ControlLot;
                labSheetDetailModelNew.Positive35 = labSheetA1Sheet.Positive35;
                labSheetDetailModelNew.NonTarget35 = labSheetA1Sheet.NonTarget35;
                labSheetDetailModelNew.Negative35 = labSheetA1Sheet.Negative35;
                labSheetDetailModelNew.Positive44_5 = labSheetA1Sheet.Positive44_5;
                labSheetDetailModelNew.NonTarget44_5 = labSheetA1Sheet.NonTarget44_5;
                labSheetDetailModelNew.Negative44_5 = labSheetA1Sheet.Negative44_5;
                labSheetDetailModelNew.Blank35 = labSheetA1Sheet.Blank35;
                labSheetDetailModelNew.Lot35 = labSheetA1Sheet.Lot35;
                labSheetDetailModelNew.Lot44_5 = labSheetA1Sheet.Lot44_5;
                labSheetDetailModelNew.Weather = labSheetA1Sheet.Weather;
                labSheetDetailModelNew.RunComment = labSheetA1Sheet.RunComment;
                labSheetDetailModelNew.SampleBottleLotNumber = labSheetA1Sheet.SampleBottleLotNumber;
                labSheetDetailModelNew.SalinitiesReadBy = labSheetA1Sheet.SalinitiesReadBy;
                labSheetDetailModelNew.SalinitiesReadDate = SalinityReadDate;
                labSheetDetailModelNew.ResultsReadBy = labSheetA1Sheet.ResultsReadBy;
                labSheetDetailModelNew.ResultsReadDate = ResultsReadDate;
                labSheetDetailModelNew.ResultsRecordedBy = labSheetA1Sheet.ResultsRecordedBy;
                labSheetDetailModelNew.ResultsRecordedDate = ResultsRecordedDate;
                labSheetDetailModelNew.DailyDuplicateRLog = float.Parse(labSheetA1Sheet.DailyDuplicateRLog);
                labSheetDetailModelNew.DailyDuplicatePrecisionCriteria = float.Parse(labSheetA1Sheet.DailyDuplicatePrecisionCriteria);
                labSheetDetailModelNew.DailyDuplicateAcceptable = (labSheetA1Sheet.DailyDuplicateAcceptableOrUnacceptable == "Acceptable" ? true : false);

                LabSheetDetailService labSheetDetailService = new LabSheetDetailService(LanguageEnum.en, user);
                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModel = labSheetDetailService.PostAddLabSheetDetailDB(labSheetDetailModelNew);
                    Assert.AreEqual("", labSheetDetailModel.Error);

                    foreach (LabSheetA1Measurement LabSheetA1Measurement in labSheetA1Sheet.LabSheetA1MeasurementList)
                    {
                        if (LabSheetA1Measurement.TVItemID == 0)
                            continue;

                        if (LabSheetA1Measurement.MPN == null)
                            continue;

                        if (LabSheetA1Measurement.Time == null)
                            continue;

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelNew = new LabSheetTubeMPNDetailModel();
                        labSheetTubeMPNDetailModelNew.LabSheetDetailID = labSheetDetailModel.LabSheetDetailID;
                        labSheetTubeMPNDetailModelNew.MWQMSiteTVItemID = LabSheetA1Measurement.TVItemID;
                        labSheetTubeMPNDetailModelNew.SampleDateTime = (DateTime)LabSheetA1Measurement.Time;
                        labSheetTubeMPNDetailModelNew.MPN = (int)LabSheetA1Measurement.MPN;
                        labSheetTubeMPNDetailModelNew.Tube10 = (int)LabSheetA1Measurement.Tube10;
                        labSheetTubeMPNDetailModelNew.Tube1_0 = (int)LabSheetA1Measurement.Tube1_0;
                        labSheetTubeMPNDetailModelNew.Tube0_1 = (int)LabSheetA1Measurement.Tube0_1;
                        labSheetTubeMPNDetailModelNew.Salinity = (float)LabSheetA1Measurement.Salinity;
                        labSheetTubeMPNDetailModelNew.Temperature = (float)LabSheetA1Measurement.Temperature;
                        labSheetTubeMPNDetailModelNew.ProcessedBy = LabSheetA1Measurement.ProcessedBy;
                        labSheetTubeMPNDetailModelNew.SampleType = (SampleTypeEnum)LabSheetA1Measurement.SampleType;
                        labSheetTubeMPNDetailModelNew.SiteComment = LabSheetA1Measurement.SiteComment;

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = labSheetTubeMPNDetailService.PostAddLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelNew);
                        Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);
                    }

                   // ts.Complete();
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(labSheetTubeMPNDetailService);
                Assert.IsNotNull(labSheetTubeMPNDetailService.db);
                Assert.IsNotNull(labSheetTubeMPNDetailService.LanguageRequest);
                Assert.IsNotNull(labSheetTubeMPNDetailService.User);
                Assert.AreEqual(user.Identity.Name, labSheetTubeMPNDetailService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), labSheetTubeMPNDetailService.LanguageRequest);
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_LabSheetTubeMPNDetailModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelNew = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelNew.Error);

                    #region Good
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);

                    string retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region LabSheetDetailID
                    int LabSheetDetailID = labSheetTubeMPNDetailModelNew.LabSheetDetailID;
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.LabSheetDetailID = 0;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LabSheetDetailID), retStr);

                    labSheetTubeMPNDetailModelNew.LabSheetDetailID = LabSheetDetailID;
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMPlanID

                    #region MWQMSiteTVItemID
                    int MWQMSiteTVItemID = labSheetTubeMPNDetailModelNew.MWQMSiteTVItemID;
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.MWQMSiteTVItemID = 0;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID), retStr);

                    labSheetTubeMPNDetailModelNew.MWQMSiteTVItemID = MWQMSiteTVItemID;
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SubsectorTVItemID

                    #region SampleDateTime
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetTubeMPNDetailService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion RunDate

                    #region MPN
                    int Min = 1;
                    int Max = 100000000;
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.MPN = Min - 1;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MPN, Min, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.MPN = Max + 1;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MPN, Min, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.MPN = Min;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.MPN = Max;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MPN

                    #region Tube10
                    Min = 0;
                    Max = 5;
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Tube10 = Min - 1;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Tube10, Min, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Tube10 = Max + 1;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Tube10, Min, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Tube10 = Min;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Tube10 = Max;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Tube10

                    #region Tube1_0
                    Min = 0;
                    Max = 5;
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Tube1_0 = Min - 1;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Tube1_0, Min, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Tube1_0 = Max + 1;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Tube1_0, Min, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Tube1_0 = Min;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Tube1_0 = Max;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Tube1_0

                    #region Tube0_1
                    Min = 0;
                    Max = 5;
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Tube0_1 = Min - 1;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Tube0_1, Min, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Tube0_1 = Max + 1;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Tube0_1, Min, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Tube0_1 = Min;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Tube0_1 = Max;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Tube0_1

                    #region Salinity
                    Min = 0;
                    Max = 40;
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Salinity = Min - 1;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Salinity, Min, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Salinity = Max + 1;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Salinity, Min, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Salinity = Min;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Salinity = Max;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Salinity

                    #region Temperature
                    Min = 0;
                    Max = 40;
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Temperature = Min - 1;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Temperature, Min, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Temperature = Max + 1;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Temperature, Min, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Temperature = Min;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.Temperature = Max;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Temperature

                    #region ProcessedBy
                    Max = 10;
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.ProcessedBy = randomService.RandomString("", Max + 1);

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ProcessedBy, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.ProcessedBy = randomService.RandomString("", Max - 1);

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ProcessedBy

                    #region SampleType
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.SampleType = (SampleTypeEnum)100000;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SampleType), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.SampleType = SampleTypeEnum.Routine;

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SampleType

                    #region SiteComment
                    Max = 250;
                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.SiteComment = randomService.RandomString("", Max + 1);

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.SiteComment, Max), retStr);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);
                    labSheetTubeMPNDetailModelNew.SiteComment = randomService.RandomString("", Max - 1);

                    retStr = labSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SiteComment

                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_FillLabSheetTubeMPNDetail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModel = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModel.Error);

                    FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModel);

                    ContactOK contactOK = labSheetTubeMPNDetailService.IsContactOK();

                    string retStr = labSheetTubeMPNDetailService.FillLabSheetTubeMPNDetail(labSheetTubeMPNDetail, labSheetTubeMPNDetailModel, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, labSheetTubeMPNDetail.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = labSheetTubeMPNDetailService.FillLabSheetTubeMPNDetail(labSheetTubeMPNDetail, labSheetTubeMPNDetailModel, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, labSheetTubeMPNDetail.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_GetLabSheetTubeMPNDetailModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModel = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModel.Error);

                    int labSheetTubeMPNDetailCount = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, labSheetTubeMPNDetailCount);
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_GetLabSheetTubeMPNDetailModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailModelExistDB(labSheetTubeMPNDetailModelRet);
                    Assert.AreEqual(labSheetTubeMPNDetailModelRet.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailModelRet2.LabSheetTubeMPNDetailID);

                    labSheetTubeMPNDetailModelRet.MWQMSiteTVItemID = 0;
                    labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailModelExistDB(labSheetTubeMPNDetailModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheetTubeMPNDetail,
                    ServiceRes.LabSheetDetailID + "," +
                    ServiceRes.MWQMSiteTVItemID + "," +
                    ServiceRes.SampleDateTime + "," +
                    ServiceRes.SampleType,
                    labSheetTubeMPNDetailModelRet.LabSheetDetailID + "," +
                    labSheetTubeMPNDetailModelRet.MWQMSiteTVItemID + "," +
                    labSheetTubeMPNDetailModelRet.SampleDateTime + "," +
                    labSheetTubeMPNDetailModelRet.SampleType), labSheetTubeMPNDetailModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_GetLabSheetTubeMPNDetailModelListWithLabSheetDetailIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModel = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModel.Error);

                    List<LabSheetTubeMPNDetailModel> labSheetTubeMPNDetailModelList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailModelListWithLabSheetDetailIDDB(labSheetTubeMPNDetailModel.LabSheetDetailID);
                    Assert.IsTrue(labSheetTubeMPNDetailModelList.Where(c => c.LabSheetTubeMPNDetailID == labSheetTubeMPNDetailModel.LabSheetTubeMPNDetailID).Any());

                    int LabSheetDetailID = 0;
                    labSheetTubeMPNDetailModelList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailModelListWithLabSheetDetailIDDB(LabSheetDetailID);
                    Assert.AreEqual(0, labSheetTubeMPNDetailModelList.Count);
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_GetLabSheetTubeMPNDetailModelListWithMWQMSiteTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModel = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModel.Error);

                    List<LabSheetTubeMPNDetailModel> labSheetTubeMPNDetailModelList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailModelListWithMWQMSiteTVItemIDDB(labSheetTubeMPNDetailModel.MWQMSiteTVItemID);
                    Assert.IsTrue(labSheetTubeMPNDetailModelList.Where(c => c.LabSheetTubeMPNDetailID == labSheetTubeMPNDetailModel.LabSheetTubeMPNDetailID).Any());

                    int MWQMSiteTVItemID = 0;
                    labSheetTubeMPNDetailModelList = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailModelListWithMWQMSiteTVItemIDDB(MWQMSiteTVItemID);
                    Assert.AreEqual(0, labSheetTubeMPNDetailModelList.Count);
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_GetLabSheetTubeMPNDetailModelWithLabSheetTubeMPNDetailIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();

                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailModelWithLabSheetTubeMPNDetailIDDB(labSheetTubeMPNDetailModelRet.LabSheetTubeMPNDetailID);
                    Assert.AreEqual(labSheetTubeMPNDetailModelRet.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailModelRet2.LabSheetTubeMPNDetailID);

                    int LabSheetTubeMPNDetailID = 0;
                    labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailModelWithLabSheetTubeMPNDetailIDDB(LabSheetTubeMPNDetailID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheetTubeMPNDetail, ServiceRes.LabSheetTubeMPNDetailID, LabSheetTubeMPNDetailID), labSheetTubeMPNDetailModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();

                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailIDDB(labSheetTubeMPNDetailModelRet.LabSheetTubeMPNDetailID);
                    Assert.AreEqual(labSheetTubeMPNDetailModelRet.LabSheetTubeMPNDetailID, labSheetTubeMPNDetailRet.LabSheetTubeMPNDetailID);

                    int LabSheetTubeMPNDetailID = 0;
                    LabSheetTubeMPNDetail labSheetTubeMPNDetailRet2 = labSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailIDDB(LabSheetTubeMPNDetailID);
                    Assert.IsNull(labSheetTubeMPNDetailRet2);
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = labSheetTubeMPNDetailService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, labSheetTubeMPNDetailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostAddUpdateDeleteLabSheetTubeMPNDetail_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();

                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = UpdateLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelRet);

                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet3 = labSheetTubeMPNDetailService.PostDeleteLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelRet2.LabSheetTubeMPNDetailID);
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostAddLabSheetTubeMPNDetailDB_LabSheetTubeMPNDetailModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOKLabSheetTubeMPNDetailModel = (a) =>
                        {
                            return ErrorText;
                        };

                        labSheetTubeMPNDetailModelRet.SampleDateTime = ((DateTime)labSheetTubeMPNDetailModelRet.SampleDateTime).AddSeconds(1);

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.PostAddLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelRet);
                        Assert.AreEqual(ErrorText, labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostAddLabSheetTubeMPNDetailDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        labSheetTubeMPNDetailModelRet.SampleDateTime = ((DateTime)labSheetTubeMPNDetailModelRet.SampleDateTime).AddSeconds(1);

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.PostAddLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelRet);
                        Assert.AreEqual(ErrorText, labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostAddLabSheetTubeMPNDetailDB_GetLabSheetTubeMPNDetailExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailModelExistDBLabSheetTubeMPNDetailModel = (a) =>
                        {
                            return new LabSheetTubeMPNDetailModel();
                        };

                        labSheetTubeMPNDetailModelRet.SampleDateTime = ((DateTime)labSheetTubeMPNDetailModelRet.SampleDateTime).AddSeconds(1);

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.PostAddLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.LabSheetTubeMPNDetail), labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostAddLabSheetTubeMPNDetailDB_FillLabSheetTubeMPNDetail_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.FillLabSheetTubeMPNDetailLabSheetTubeMPNDetailLabSheetTubeMPNDetailModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        labSheetTubeMPNDetailModelRet.SampleDateTime = ((DateTime)labSheetTubeMPNDetailModelRet.SampleDateTime).AddSeconds(1);

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.PostAddLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelRet);
                        Assert.AreEqual(ErrorText, labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostAddLabSheetTubeMPNDetailDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        labSheetTubeMPNDetailModelRet.SampleDateTime = ((DateTime)labSheetTubeMPNDetailModelRet.SampleDateTime).AddSeconds(1);

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.PostAddLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelRet);
                        Assert.AreEqual(ErrorText, labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostAddLabSheetTubeMPNDetailDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.FillLabSheetTubeMPNDetailLabSheetTubeMPNDetailLabSheetTubeMPNDetailModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        labSheetTubeMPNDetailModelRet.SampleDateTime = ((DateTime)labSheetTubeMPNDetailModelRet.SampleDateTime).AddSeconds(1);

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.PostAddLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelRet);
                        Assert.IsTrue(labSheetTubeMPNDetailModelRet2.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostAddLabSheetTubeMPNDetailDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    SetupTest(contactModelListGood[2], culture);

                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.PostAddLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, labSheetTubeMPNDetailModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostDeleteLabSheetTubeMPNDetail_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.PostDeleteLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelRet.LabSheetTubeMPNDetailID);
                        Assert.AreEqual(ErrorText, labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostDeleteLabSheetTubeMPNDetail_GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.PostDeleteLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelRet.LabSheetTubeMPNDetailID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.LabSheetTubeMPNDetail), labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostDeleteLabSheetTubeMPNDetail_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.PostDeleteLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelRet.LabSheetTubeMPNDetailID);
                        Assert.AreEqual(ErrorText, labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostUpdateLabSheetTubeMPNDetail_LabSheetTubeMPNDetailModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.LabSheetTubeMPNDetailModelOKLabSheetTubeMPNDetailModel = (a) =>
                        {
                            return ErrorText;
                        };

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = UpdateLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelRet);
                        Assert.AreEqual(ErrorText, labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostUpdateLabSheetTubeMPNDetail_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = UpdateLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelRet);
                        Assert.AreEqual(ErrorText, labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostUpdateLabSheetTubeMPNDetail_GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = UpdateLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.LabSheetTubeMPNDetail), labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostUpdateLabSheetTubeMPNDetail_FillLabSheetTubeMPNDetail_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.FillLabSheetTubeMPNDetailLabSheetTubeMPNDetailLabSheetTubeMPNDetailModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = UpdateLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelRet);
                        Assert.AreEqual(ErrorText, labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetTubeMPNDetailService_PostUpdateLabSheetTubeMPNDetail_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = AddLabSheetTubeMPNDetailModel();
                    Assert.AreEqual("", labSheetTubeMPNDetailModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetTubeMPNDetailService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = UpdateLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelRet);
                        Assert.AreEqual(ErrorText, labSheetTubeMPNDetailModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public LabSheetTubeMPNDetailModel AddLabSheetTubeMPNDetailModel()
        {
            int LabSheetDetailID = (from c in labSheetTubeMPNDetailService.db.LabSheetDetails orderby c.LabSheetDetailID descending select c).FirstOrDefault().LabSheetDetailID;
            int MWQMSiteTVItemID = randomService.RandomTVItem(TVTypeEnum.MWQMSite).TVItemID;

            labSheetTubeMPNDetailModelNew.LabSheetDetailID = LabSheetDetailID;
            labSheetTubeMPNDetailModelNew.MWQMSiteTVItemID = MWQMSiteTVItemID;

            FillLabSheetTubeMPNDetailModel(labSheetTubeMPNDetailModelNew);

            LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = labSheetTubeMPNDetailService.PostAddLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModelNew);
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailModelRet.Error))
            {
                return labSheetTubeMPNDetailModelRet;
            }

            labSheetTubeMPNDetailModelNew.LabSheetTubeMPNDetailID = labSheetTubeMPNDetailModelRet.LabSheetTubeMPNDetailID;
            CompareLabSheetTubeMPNDetailModels(labSheetTubeMPNDetailModelNew, labSheetTubeMPNDetailModelRet);

            return labSheetTubeMPNDetailModelRet;
        }
        public LabSheetTubeMPNDetailModel UpdateLabSheetTubeMPNDetailModel(LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModel)
        {
            LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet2 = labSheetTubeMPNDetailService.PostUpdateLabSheetTubeMPNDetailDB(labSheetTubeMPNDetailModel);
            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetailModelRet2.Error))
            {
                return labSheetTubeMPNDetailModelRet2;
            }

            CompareLabSheetTubeMPNDetailModels(labSheetTubeMPNDetailModel, labSheetTubeMPNDetailModelRet2);

            return labSheetTubeMPNDetailModelRet2;
        }
        private void CompareLabSheetTubeMPNDetailModels(LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelNew, LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet)
        {
            Assert.AreEqual(labSheetTubeMPNDetailModelNew.LabSheetDetailID, labSheetTubeMPNDetailModelRet.LabSheetDetailID);
            Assert.AreEqual(labSheetTubeMPNDetailModelNew.MWQMSiteTVItemID, labSheetTubeMPNDetailModelRet.MWQMSiteTVItemID);
            Assert.AreEqual(labSheetTubeMPNDetailModelNew.SampleDateTime, labSheetTubeMPNDetailModelRet.SampleDateTime);
            Assert.AreEqual(labSheetTubeMPNDetailModelNew.MPN, labSheetTubeMPNDetailModelRet.MPN);
            Assert.AreEqual(labSheetTubeMPNDetailModelNew.Tube10, labSheetTubeMPNDetailModelRet.Tube10);
            Assert.AreEqual(labSheetTubeMPNDetailModelNew.Tube1_0, labSheetTubeMPNDetailModelRet.Tube1_0);
            Assert.AreEqual(labSheetTubeMPNDetailModelNew.Tube0_1, labSheetTubeMPNDetailModelRet.Tube0_1);
            Assert.AreEqual(labSheetTubeMPNDetailModelNew.Salinity, labSheetTubeMPNDetailModelRet.Salinity);
            Assert.AreEqual(labSheetTubeMPNDetailModelNew.Temperature, labSheetTubeMPNDetailModelRet.Temperature);
            Assert.AreEqual(labSheetTubeMPNDetailModelNew.ProcessedBy, labSheetTubeMPNDetailModelRet.ProcessedBy);
            Assert.AreEqual(labSheetTubeMPNDetailModelNew.SampleType, labSheetTubeMPNDetailModelRet.SampleType);
            Assert.AreEqual(labSheetTubeMPNDetailModelNew.SiteComment, labSheetTubeMPNDetailModelRet.SiteComment);
        }
        private void FillLabSheetTubeMPNDetailModel(LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModel)
        {
            labSheetTubeMPNDetailModel.LabSheetDetailID = labSheetTubeMPNDetailModel.LabSheetDetailID;
            labSheetTubeMPNDetailModel.MWQMSiteTVItemID = labSheetTubeMPNDetailModel.MWQMSiteTVItemID;
            labSheetTubeMPNDetailModel.SampleDateTime = randomService.RandomDateTime();
            labSheetTubeMPNDetailModel.MPN = 1600;
            labSheetTubeMPNDetailModel.Tube10 = 5;
            labSheetTubeMPNDetailModel.Tube1_0 = 5;
            labSheetTubeMPNDetailModel.Tube0_1 = 4;
            labSheetTubeMPNDetailModel.Salinity = randomService.RandomFloat(10, 20);
            labSheetTubeMPNDetailModel.Temperature = randomService.RandomFloat(10, 20);
            labSheetTubeMPNDetailModel.ProcessedBy = "JG";
            labSheetTubeMPNDetailModel.SampleType = SampleTypeEnum.Routine;
            labSheetTubeMPNDetailModel.SiteComment = randomService.RandomString("", 30);

            Assert.IsTrue(labSheetTubeMPNDetailModel.LabSheetDetailID > 0);
            Assert.IsTrue(labSheetTubeMPNDetailModel.MWQMSiteTVItemID > 0);
            Assert.IsTrue(labSheetTubeMPNDetailModel.SampleDateTime != null);
            Assert.IsTrue(labSheetTubeMPNDetailModel.MPN == 1600);
            Assert.IsTrue(labSheetTubeMPNDetailModel.Tube10 == 5);
            Assert.IsTrue(labSheetTubeMPNDetailModel.Tube1_0 == 5);
            Assert.IsTrue(labSheetTubeMPNDetailModel.Tube0_1 == 4);
            Assert.IsTrue(labSheetTubeMPNDetailModel.Salinity >= 10 && labSheetTubeMPNDetailModel.Salinity <= 20);
            Assert.IsTrue(labSheetTubeMPNDetailModel.Temperature >= 10 && labSheetTubeMPNDetailModel.Temperature <= 20);
            Assert.IsTrue(labSheetTubeMPNDetailModel.ProcessedBy == "JG");
            Assert.IsTrue(labSheetTubeMPNDetailModel.SampleType == SampleTypeEnum.Routine);
            Assert.IsTrue(labSheetTubeMPNDetailModel.SiteComment.Length == 30);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            labSheetTubeMPNDetailService = new LabSheetTubeMPNDetailService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            appTaskService = new AppTaskService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvFileService = new TVFileService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            labSheetTubeMPNDetailModelNew = new LabSheetTubeMPNDetailModel();
            labSheetTubeMPNDetail = new LabSheetTubeMPNDetail();
        }
        private void SetupShim()
        {
            shimLabSheetTubeMPNDetailService = new ShimLabSheetTubeMPNDetailService(labSheetTubeMPNDetailService);
        }
        #endregion Functions private
    }
}


