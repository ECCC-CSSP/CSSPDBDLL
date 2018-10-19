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

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for LabSheetDetailServiceTest
    /// </summary>
    [TestClass]
    public class LabSheetDetailServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "LabSheetDetail";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private LabSheetDetailService labSheetDetailService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private LabSheetDetailModel labSheetDetailModelNew { get; set; }
        private LabSheetDetail labSheetDetail { get; set; }
        private AppTaskService appTaskService { get; set; }
        private TVFileService tvFileService { get; set; }
        private ShimLabSheetDetailService shimLabSheetDetailService { get; set; }
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
        public LabSheetDetailServiceTest()
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
        public void LabSheetDetailService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(labSheetDetailService);
                Assert.IsNotNull(labSheetDetailService.db);
                Assert.IsNotNull(labSheetDetailService.LanguageRequest);
                Assert.IsNotNull(labSheetDetailService.User);
                Assert.AreEqual(user.Identity.Name, labSheetDetailService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), labSheetDetailService.LanguageRequest);
            }
        }
        [TestMethod]
        public void LabSheetDetailService_LabSheetDetailModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelNew = AddLabSheetDetailModel();
                    Assert.AreEqual("", labSheetDetailModelNew.Error);

                    #region Good
                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    string retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region LabSheetID
                    int LabSheetID = labSheetDetailModelNew.LabSheetID;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.LabSheetID = 0;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LabSheetID), retStr);

                    labSheetDetailModelNew.LabSheetID = LabSheetID;
                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion LabSheetID

                    #region MWQMPlanID
                    int MWQMPlanID = labSheetDetailModelNew.MWQMPlanID;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.MWQMPlanID = 0;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMPlanID), retStr);

                    labSheetDetailModelNew.MWQMPlanID = MWQMPlanID;
                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMPlanID

                    #region SubsectorTVItemID
                    int SubsectorTVItemID = labSheetDetailModelNew.SubsectorTVItemID;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.SubsectorTVItemID = 0;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID), retStr);

                    labSheetDetailModelNew.SubsectorTVItemID = SubsectorTVItemID;
                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SubsectorTVItemID

                    #region Version
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Version = 0;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Version), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Version = 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Version

                    #region RunDate
                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetDetailService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion RunDate

                    #region Tides
                    int Min = 7;
                    int Max = 7;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Tides = randomService.RandomString("", Min - 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.Tides, Min), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Tides = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Tides, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Tides = randomService.RandomString("", Min);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Tides = randomService.RandomString("", Max);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Tides

                    #region SampleCrewInitials
                    Max = 20;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.SampleCrewInitials = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.SampleCrewInitials, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.SampleCrewInitials = randomService.RandomString("", Max - 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SampleCrewInitials

                    #region IncubationStartTime
                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimLabSheetDetailService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            count += 1;
                            if (count == 2)
                                return ErrorText;

                            return "";
                        };

                        retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion IncubationStartTime

                    #region IncubationEndTime
                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimLabSheetDetailService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            count += 1;
                            if (count == 3)
                                return ErrorText;

                            return "";
                        };

                        retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion IncubationEndTime

                    #region IncubationTimeCalculated_minutes
                    Min = -10000;
                    Max = 10000;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.IncubationTimeCalculated_minutes = Min -1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.IncubationTimeCalculated_minutes, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.IncubationTimeCalculated_minutes = Max + 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.IncubationTimeCalculated_minutes, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.IncubationTimeCalculated_minutes = Min + 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.IncubationTimeCalculated_minutes = Max - 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion IncubationTimeCalculated_minutes

                    #region WaterBath
                    Max = 10;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.WaterBath = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.WaterBath, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.WaterBath = randomService.RandomString("", Max - 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion WaterBath

                    #region TCField1
                    Min = 0;
                    Max = 40;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCField1 = Min - 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TCField1, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCField1 = Max + 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TCField1, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCField1 = Min;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCField1 = Max;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TCField1

                    #region TCLab1
                    Min = 0;
                    Max = 40;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCLab1 = Min - 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TCLab1, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCLab1 = Max + 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TCLab1, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCLab1 = Min;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCLab1 = Max;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TCLab1

                    #region TCField2
                    Min = 0;
                    Max = 40;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCField2 = Min - 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TCField2, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCField2 = Max + 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TCField2, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCField2 = Min;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCField2 = Max;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TCField2

                    #region TCLab2
                    Min = 0;
                    Max = 40;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCLab2 = Min - 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TCLab2, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCLab2 = Max + 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TCLab2, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCLab2 = Min;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCLab2 = Max;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TCLab2

                    #region TCFirst
                    Min = 0;
                    Max = 40;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCFirst = Min - 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TCFirst, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCFirst = Max + 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TCFirst, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCFirst = Min;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCFirst = Max;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TCFirst

                    #region TCAverage
                    Min = 0;
                    Max = 40;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCAverage = Min - 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TCAverage, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCAverage = Max + 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TCAverage, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCAverage = Min;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.TCAverage = Max;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TCAverage

                    #region ControlLot
                    Max = 100;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.ControlLot = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ControlLot, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.ControlLot = randomService.RandomString("", Max - 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ControlLot

                    #region Positive35
                    Max = 1;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Positive35 = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Positive35, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Positive35 = "K";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.Positive35), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Positive35 = "+";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Positive35 = "-";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Positive35

                    #region NonTarget35
                    Max = 1;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.NonTarget35 = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.NonTarget35, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.NonTarget35 = "K";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.NonTarget35), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.NonTarget35 = "+";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.NonTarget35 = "-";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.NonTarget35 = "N";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion NonTarget35

                    #region Negative35
                    Max = 1;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Negative35 = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Negative35, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Negative35 = "K";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.Negative35), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Negative35 = "+";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Negative35 = "-";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Negative35

                    #region Positive44_5
                    Max = 1;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Positive44_5 = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Positive44_5, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Positive44_5 = "K";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.Positive44_5), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Positive44_5 = "+";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Positive44_5 = "-";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Positive44_5

                    #region NonTarget44_5
                    Max = 1;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.NonTarget44_5 = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.NonTarget44_5, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.NonTarget44_5 = "K";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.NonTarget44_5), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.NonTarget44_5 = "+";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.NonTarget44_5 = "-";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.NonTarget44_5 = "N";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion NonTarget44_5

                    #region Negative44_5
                    Max = 1;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Negative44_5 = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Negative44_5, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Negative44_5 = "K";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.Negative44_5), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Negative44_5 = "+";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Negative44_5 = "-";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Negative44_5

                    #region Blank35
                    Max = 1;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Blank35 = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Blank35, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Blank35 = "K";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.Blank35), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Blank35 = "+";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Blank35 = "-";

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Blank35

                    #region Lot44_5
                    Max = 20;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Lot44_5 = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Lot44_5, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Lot44_5 = randomService.RandomString("", Max - 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Lot44_5

                    #region Weather
                    Max = 250;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Weather = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Weather, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.Weather = randomService.RandomString("", Max - 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Weather

                    #region RunComment
                    Max = 250;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.RunComment = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.RunComment, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.RunComment = randomService.RandomString("", Max - 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion RunComment

                    #region SampleBottleLotNumber
                    Max = 20;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.SampleBottleLotNumber = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.SampleBottleLotNumber, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.SampleBottleLotNumber = randomService.RandomString("", Max - 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SampleBottleLotNumber

                    #region SalinitiesReadBy
                    Max = 20;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.SalinitiesReadBy = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.SalinitiesReadBy, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.SalinitiesReadBy = randomService.RandomString("", Max - 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SalinitiesReadBy

                    #region SalinitiesReadDate
                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimLabSheetDetailService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            count += 1;
                            if (count == 4)
                                return ErrorText;

                            return "";
                        };

                        retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion SalinitiesReadDate

                    #region ResultsReadBy
                    Max = 20;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.ResultsReadBy = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ResultsReadBy, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.ResultsReadBy = randomService.RandomString("", Max - 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ResultsReadBy

                    #region ResultsReadDate
                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimLabSheetDetailService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            count += 1;
                            if (count == 5)
                                return ErrorText;

                            return "";
                        };

                        retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion ResultsReadDate

                    #region ResultsRecordedBy
                    Max = 20;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.ResultsRecordedBy = randomService.RandomString("", Max + 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ResultsRecordedBy, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.ResultsRecordedBy = randomService.RandomString("", Max - 1);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ResultsRecordedBy

                    #region ResultsRecordedDate
                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimLabSheetDetailService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            count += 1;
                            if (count == 6)
                                return ErrorText;

                            return "";
                        };

                        retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion ResultsRecordedDate

                    #region DailyDuplicateRLog
                    Min = 0;
                    Max = 100;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.DailyDuplicateRLog = Min - 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DailyDuplicateRLog, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.DailyDuplicateRLog = Max + 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DailyDuplicateRLog, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.DailyDuplicateRLog = Min;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.DailyDuplicateRLog = Max;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion DailyDuplicateRLog

                    #region DailyDuplicatePrecisionCriteria
                    Min = 0;
                    Max = 10;
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.DailyDuplicatePrecisionCriteria = Min - 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DailyDuplicatePrecisionCriteria, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.DailyDuplicatePrecisionCriteria = Max + 1;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DailyDuplicatePrecisionCriteria, Min, Max), retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.DailyDuplicatePrecisionCriteria = Min;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.DailyDuplicatePrecisionCriteria = Max;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion DailyDuplicatePrecisionCriteria

                    #region DuplicateDataEntryDate
                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimLabSheetDetailService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            count += 1;
                            if (count == 6)
                                return ErrorText;

                            return "";
                        };

                        retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion DuplicateDataEntryDate

                    #region DailyDuplicateAcceptable
                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.DailyDuplicateAcceptable = true;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.DailyDuplicateAcceptable = false;

                    retStr = labSheetDetailService.LabSheetDetailModelOK(labSheetDetailModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetDetailModel(labSheetDetailModelNew);
                    labSheetDetailModelNew.DailyDuplicatePrecisionCriteria = Min;
                    #endregion DailyDuplicatePrecisionCriteria
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_FillLabSheetDetail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModel = AddLabSheetDetailModel();
                    Assert.AreEqual("", labSheetDetailModel.Error);

                    FillLabSheetDetailModel(labSheetDetailModel);

                    ContactOK contactOK = labSheetDetailService.IsContactOK();

                    string retStr = labSheetDetailService.FillLabSheetDetail(labSheetDetail, labSheetDetailModel, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, labSheetDetail.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = labSheetDetailService.FillLabSheetDetail(labSheetDetail, labSheetDetailModel, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, labSheetDetail.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_GetLabSheetDetailModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModel = AddLabSheetDetailModel();
                    Assert.AreEqual("", labSheetDetailModel.Error);

                    int labSheetDetailCount = labSheetDetailService.GetLabSheetDetailModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, labSheetDetailCount);
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_GetLabSheetDetailModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();
                    Assert.AreEqual("", labSheetDetailModelRet.Error);

                    LabSheetDetailModel labSheetDetailModelRet2 = labSheetDetailService.GetLabSheetDetailModelExistDB(labSheetDetailModelRet);
                    Assert.AreEqual(labSheetDetailModelRet.LabSheetDetailID, labSheetDetailModelRet2.LabSheetDetailID);

                    labSheetDetailModelRet.SubsectorTVItemID = 0;
                    labSheetDetailModelRet2 = labSheetDetailService.GetLabSheetDetailModelExistDB(labSheetDetailModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.MWQMPlanID,
                    ServiceRes.SubsectorTVItemID + "," +
                    ServiceRes.Year + "," +
                    ServiceRes.Month + "," +
                    ServiceRes.Day,
                    labSheetDetailModelRet.MWQMPlanID + "," +
                    labSheetDetailModelRet.SubsectorTVItemID + "," +
                    labSheetDetailModelRet.RunDate.Year.ToString() + "," +
                    labSheetDetailModelRet.RunDate.Month.ToString() + "," +
                    labSheetDetailModelRet.RunDate.Day.ToString()), labSheetDetailModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_GetLabSheetDetailModelListWithLabSheetIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();
                    Assert.AreEqual("", labSheetDetailModelRet.Error);

                    List<LabSheetDetailModel> labSheetDetailModelList = labSheetDetailService.GetLabSheetDetailModelListWithLabSheetIDDB(labSheetDetailModelRet.LabSheetID);
                    Assert.IsTrue(labSheetDetailModelList.Count > 0);

                    int LabSheetID = 0;
                    labSheetDetailModelList = labSheetDetailService.GetLabSheetDetailModelListWithLabSheetIDDB(LabSheetID);
                    Assert.IsTrue(labSheetDetailModelList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_GetLabSheetDetailModelListWithSubsectorTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModel = AddLabSheetDetailModel();
                    Assert.AreEqual("", labSheetDetailModel.Error);

                    List<LabSheetDetailModel> labSheetDetailModelList = labSheetDetailService.GetLabSheetDetailModelListWithSubsectorTVItemIDDB(labSheetDetailModel.SubsectorTVItemID);
                    Assert.IsTrue(labSheetDetailModelList.Where(c => c.LabSheetDetailID == labSheetDetailModel.LabSheetDetailID).Any());

                    int SubsectorTVItemID = 0;
                    labSheetDetailModelList = labSheetDetailService.GetLabSheetDetailModelListWithSubsectorTVItemIDDB(SubsectorTVItemID);
                    Assert.AreEqual(0, labSheetDetailModelList.Count);
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_GetLabSheetDetailModelWithLabSheetDetailIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();
                    Assert.AreEqual("", labSheetDetailModelRet.Error);

                    LabSheetDetailModel labSheetDetailModelRet2 = labSheetDetailService.GetLabSheetDetailModelWithLabSheetDetailIDDB(labSheetDetailModelRet.LabSheetDetailID);
                    Assert.AreEqual("", labSheetDetailModelRet2.Error);

                    int LabSheetDetailID = 0;
                    labSheetDetailModelRet2 = labSheetDetailService.GetLabSheetDetailModelWithLabSheetDetailIDDB(LabSheetDetailID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheetDetail, ServiceRes.LabSheetDetailID, LabSheetDetailID), labSheetDetailModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_GetLabSheetDetailWithLabSheetDetailIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();

                    LabSheetDetail labSheetDetailRet = labSheetDetailService.GetLabSheetDetailWithLabSheetDetailIDDB(labSheetDetailModelRet.LabSheetDetailID);
                    Assert.AreEqual(labSheetDetailModelRet.LabSheetDetailID, labSheetDetailRet.LabSheetDetailID);

                    int LabSheetDetailID = 0;
                    LabSheetDetail labSheetDetailRet2 = labSheetDetailService.GetLabSheetDetailWithLabSheetDetailIDDB(LabSheetDetailID);
                    Assert.IsNull(labSheetDetailRet2);
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    LabSheetDetailModel labSheetDetailModelRet = labSheetDetailService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, labSheetDetailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostAddUpdateDeleteLabSheetDetail_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();
                    Assert.AreEqual("", labSheetDetailModelRet.Error);

                    LabSheetDetailModel labSheetDetailModelRet2 = UpdateLabSheetDetailModel(labSheetDetailModelRet);
                    Assert.AreEqual("", labSheetDetailModelRet2.Error);

                    LabSheetDetailModel labSheetDetailModelRet3 = labSheetDetailService.PostDeleteLabSheetDetailDB(labSheetDetailModelRet2.LabSheetDetailID);
                    Assert.AreEqual("", labSheetDetailModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostAddLabSheetDetailDB_LabSheetDetailModelOK_Error_Test()
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
                        shimLabSheetDetailService.LabSheetDetailModelOKLabSheetDetailModel = (a) =>
                        {
                            return ErrorText;
                        };

                        LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();
                        Assert.AreEqual(ErrorText, labSheetDetailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostAddLabSheetDetailDB_IsContactOK_Error_Test()
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
                        shimLabSheetDetailService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();
                        Assert.AreEqual(ErrorText, labSheetDetailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostAddLabSheetDetailDB_GetLabSheetDetailExistDB_Error_Test()
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
                        shimLabSheetDetailService.GetLabSheetDetailModelExistDBLabSheetDetailModel = (a) =>
                        {
                            return new LabSheetDetailModel();
                        };

                        LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.LabSheetDetail), labSheetDetailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostAddLabSheetDetailDB_FillLabSheetDetail_Error_Test()
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
                        shimLabSheetDetailService.FillLabSheetDetailLabSheetDetailLabSheetDetailModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();
                        Assert.AreEqual(ErrorText, labSheetDetailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostAddLabSheetDetailDB_DoAddChanges_Error_Test()
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
                        shimLabSheetDetailService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();
                        Assert.AreEqual(ErrorText, labSheetDetailModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostAddLabSheetDetailDB_Add_Error_Test()
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
                        shimLabSheetDetailService.FillLabSheetDetailLabSheetDetailLabSheetDetailModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();
                        Assert.IsTrue(labSheetDetailModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostAddLabSheetDetailDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();
                    Assert.IsNotNull(labSheetDetailModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, labSheetDetailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostAddLabSheetDetailDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();
                    Assert.IsNotNull(labSheetDetailModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, labSheetDetailModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostDeleteLabSheetDetail_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetDetailService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        LabSheetDetailModel labSheetDetailModelRet2 = labSheetDetailService.PostDeleteLabSheetDetailDB(labSheetDetailModelRet.LabSheetDetailID);
                        Assert.AreEqual(ErrorText, labSheetDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostDeleteLabSheetDetail_GetLabSheetDetailWithLabSheetDetailIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimLabSheetDetailService.GetLabSheetDetailWithLabSheetDetailIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        LabSheetDetailModel labSheetDetailModelRet2 = labSheetDetailService.PostDeleteLabSheetDetailDB(labSheetDetailModelRet.LabSheetDetailID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.LabSheetDetail), labSheetDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostDeleteLabSheetDetail_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetDetailService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        LabSheetDetailModel labSheetDetailModelRet2 = labSheetDetailService.PostDeleteLabSheetDetailDB(labSheetDetailModelRet.LabSheetDetailID);
                        Assert.AreEqual(ErrorText, labSheetDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostUpdateLabSheetDetail_LabSheetDetailModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetDetailService.LabSheetDetailModelOKLabSheetDetailModel = (a) =>
                        {
                            return ErrorText;
                        };

                        LabSheetDetailModel labSheetDetailModelRet2 = UpdateLabSheetDetailModel(labSheetDetailModelRet);
                        Assert.AreEqual(ErrorText, labSheetDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostUpdateLabSheetDetail_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetDetailService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        LabSheetDetailModel labSheetDetailModelRet2 = UpdateLabSheetDetailModel(labSheetDetailModelRet);
                        Assert.AreEqual(ErrorText, labSheetDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostUpdateLabSheetDetail_GetLabSheetDetailWithLabSheetDetailIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimLabSheetDetailService.GetLabSheetDetailWithLabSheetDetailIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        LabSheetDetailModel labSheetDetailModelRet2 = UpdateLabSheetDetailModel(labSheetDetailModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.LabSheetDetail), labSheetDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostUpdateLabSheetDetail_FillLabSheetDetail_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetDetailService.FillLabSheetDetailLabSheetDetailLabSheetDetailModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        LabSheetDetailModel labSheetDetailModelRet2 = UpdateLabSheetDetailModel(labSheetDetailModelRet);
                        Assert.AreEqual(ErrorText, labSheetDetailModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetDetailService_PostUpdateLabSheetDetail_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetDetailModel labSheetDetailModelRet = AddLabSheetDetailModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetDetailService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        LabSheetDetailModel labSheetDetailModelRet2 = UpdateLabSheetDetailModel(labSheetDetailModelRet);
                        Assert.AreEqual(ErrorText, labSheetDetailModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public LabSheetDetailModel AddLabSheetDetailModel()
        {
            labSheetDetailModelNew.LabSheetID = (from c in labSheetDetailService.db.LabSheets select c).FirstOrDefault().LabSheetID;
            labSheetDetailModelNew.MWQMPlanID = (from c in labSheetDetailService.db.LabSheets select c).FirstOrDefault().MWQMPlanID;
            labSheetDetailModelNew.SubsectorTVItemID = (from c in labSheetDetailService.db.LabSheets select c).FirstOrDefault().SubsectorTVItemID;

            FillLabSheetDetailModel(labSheetDetailModelNew);

            LabSheetDetailModel labSheetDetailModelRet = labSheetDetailService.PostAddLabSheetDetailDB(labSheetDetailModelNew);
            if (!string.IsNullOrWhiteSpace(labSheetDetailModelRet.Error))
            {
                return labSheetDetailModelRet;
            }

            CompareLabSheetDetailModels(labSheetDetailModelNew, labSheetDetailModelRet);

            return labSheetDetailModelRet;
        }
        public LabSheetDetailModel UpdateLabSheetDetailModel(LabSheetDetailModel labSheetDetailModel)
        {
            LabSheetDetailModel labSheetDetailModelRet2 = labSheetDetailService.PostUpdateLabSheetDetailDB(labSheetDetailModel);
            if (!string.IsNullOrWhiteSpace(labSheetDetailModelRet2.Error))
            {
                return labSheetDetailModelRet2;
            }

            CompareLabSheetDetailModels(labSheetDetailModel, labSheetDetailModelRet2);

            return labSheetDetailModelRet2;
        }
        private void CompareLabSheetDetailModels(LabSheetDetailModel labSheetDetailModelNew, LabSheetDetailModel labSheetDetailModelRet)
        {
            Assert.AreEqual(labSheetDetailModelNew.LabSheetID, labSheetDetailModelRet.LabSheetID);
            Assert.AreEqual(labSheetDetailModelNew.MWQMPlanID, labSheetDetailModelRet.MWQMPlanID);
            Assert.AreEqual(labSheetDetailModelNew.SubsectorTVItemID, labSheetDetailModelRet.SubsectorTVItemID);
            Assert.AreEqual(labSheetDetailModelNew.Version, labSheetDetailModelRet.Version);
            Assert.AreEqual(labSheetDetailModelNew.RunDate, labSheetDetailModelRet.RunDate);
            Assert.AreEqual(labSheetDetailModelNew.Tides, labSheetDetailModelRet.Tides);
            Assert.AreEqual(labSheetDetailModelNew.SampleCrewInitials, labSheetDetailModelRet.SampleCrewInitials);
            Assert.AreEqual(labSheetDetailModelNew.IncubationStartTime, labSheetDetailModelRet.IncubationStartTime);
            Assert.AreEqual(labSheetDetailModelNew.IncubationEndTime, labSheetDetailModelRet.IncubationEndTime);
            Assert.AreEqual(labSheetDetailModelNew.IncubationTimeCalculated_minutes, labSheetDetailModelRet.IncubationTimeCalculated_minutes);
            Assert.AreEqual(labSheetDetailModelNew.WaterBath, labSheetDetailModelRet.WaterBath);
            Assert.AreEqual(labSheetDetailModelNew.TCField1, labSheetDetailModelRet.TCField1);
            Assert.AreEqual(labSheetDetailModelNew.TCLab1, labSheetDetailModelRet.TCLab1);
            Assert.AreEqual(labSheetDetailModelNew.TCField2, labSheetDetailModelRet.TCField2);
            Assert.AreEqual(labSheetDetailModelNew.TCLab2, labSheetDetailModelRet.TCLab2);
            Assert.AreEqual(labSheetDetailModelNew.TCFirst, labSheetDetailModelRet.TCFirst);
            Assert.AreEqual(labSheetDetailModelNew.TCAverage, labSheetDetailModelRet.TCAverage);
            Assert.AreEqual(labSheetDetailModelNew.ControlLot, labSheetDetailModelRet.ControlLot);
            Assert.AreEqual(labSheetDetailModelNew.Positive35, labSheetDetailModelRet.Positive35);
            Assert.AreEqual(labSheetDetailModelNew.NonTarget35, labSheetDetailModelRet.NonTarget35);
            Assert.AreEqual(labSheetDetailModelNew.Negative35, labSheetDetailModelRet.Negative35);
            Assert.AreEqual(labSheetDetailModelNew.Positive44_5, labSheetDetailModelRet.Positive44_5);
            Assert.AreEqual(labSheetDetailModelNew.NonTarget44_5, labSheetDetailModelRet.NonTarget44_5);
            Assert.AreEqual(labSheetDetailModelNew.Negative44_5, labSheetDetailModelRet.Negative44_5);
            Assert.AreEqual(labSheetDetailModelNew.Blank35, labSheetDetailModelRet.Blank35);
            Assert.AreEqual(labSheetDetailModelNew.Lot35, labSheetDetailModelRet.Lot35);
            Assert.AreEqual(labSheetDetailModelNew.Lot44_5, labSheetDetailModelRet.Lot44_5);
            Assert.AreEqual(labSheetDetailModelNew.Weather, labSheetDetailModelRet.Weather);
            Assert.AreEqual(labSheetDetailModelNew.RunComment, labSheetDetailModelRet.RunComment);
            Assert.AreEqual(labSheetDetailModelNew.SampleBottleLotNumber, labSheetDetailModelRet.SampleBottleLotNumber);
            Assert.AreEqual(labSheetDetailModelNew.SalinitiesReadBy, labSheetDetailModelRet.SalinitiesReadBy);
            Assert.AreEqual(labSheetDetailModelNew.SalinitiesReadDate, labSheetDetailModelRet.SalinitiesReadDate);
            Assert.AreEqual(labSheetDetailModelNew.ResultsReadBy, labSheetDetailModelRet.ResultsReadBy);
            Assert.AreEqual(labSheetDetailModelNew.ResultsReadDate, labSheetDetailModelRet.ResultsReadDate);
            Assert.AreEqual(labSheetDetailModelNew.ResultsRecordedBy, labSheetDetailModelRet.ResultsRecordedBy);
            Assert.AreEqual(labSheetDetailModelNew.ResultsRecordedDate, labSheetDetailModelRet.ResultsRecordedDate);
            Assert.AreEqual(labSheetDetailModelNew.DailyDuplicateRLog, labSheetDetailModelRet.DailyDuplicateRLog);
            Assert.AreEqual(labSheetDetailModelNew.DailyDuplicatePrecisionCriteria, labSheetDetailModelRet.DailyDuplicatePrecisionCriteria);
            Assert.AreEqual(labSheetDetailModelNew.DailyDuplicateAcceptable, labSheetDetailModelRet.DailyDuplicateAcceptable);
        }
        private void FillLabSheetDetailModel(LabSheetDetailModel labSheetDetailModel)
        {
            labSheetDetailModel.LabSheetID = labSheetDetailModel.LabSheetID;
            labSheetDetailModel.MWQMPlanID = labSheetDetailModel.MWQMPlanID;
            labSheetDetailModel.SubsectorTVItemID = labSheetDetailModel.SubsectorTVItemID;
            labSheetDetailModel.Version = 1;
            labSheetDetailModel.RunDate = randomService.RandomDateTime();
            labSheetDetailModel.Tides = "HT / HF";
            labSheetDetailModel.SampleCrewInitials = "WT HJ";
            labSheetDetailModel.IncubationStartTime = randomService.RandomDateTime();
            labSheetDetailModel.IncubationEndTime = labSheetDetailModel.IncubationStartTime.AddMinutes(23 * 60);
            labSheetDetailModel.IncubationTimeCalculated_minutes = (int)new TimeSpan(labSheetDetailModel.IncubationEndTime.Ticks - labSheetDetailModel.IncubationStartTime.Ticks).TotalMinutes;
            labSheetDetailModel.WaterBath = "W";
            labSheetDetailModel.TCField1 = randomService.RandomFloat(10, 20);
            labSheetDetailModel.TCLab1 = randomService.RandomFloat(10, 20);
            labSheetDetailModel.TCField2 = randomService.RandomFloat(10, 20);
            labSheetDetailModel.TCLab2 = randomService.RandomFloat(10, 20);
            labSheetDetailModel.TCFirst = randomService.RandomFloat(10, 20);
            labSheetDetailModel.TCAverage = randomService.RandomFloat(10, 20);
            labSheetDetailModel.ControlLot = randomService.RandomString("", 20);
            labSheetDetailModel.Positive35 = (randomService.RandomInt(0, 1000) > 5000 ? "+" : "-");
            labSheetDetailModel.NonTarget35 = (randomService.RandomInt(0, 1000) > 5000 ? "+" : "-");
            labSheetDetailModel.Negative35 = (randomService.RandomInt(0, 1000) > 5000 ? "+" : "-");
            labSheetDetailModel.Positive44_5 = (randomService.RandomInt(0, 1000) > 5000 ? "+" : "-");
            labSheetDetailModel.NonTarget44_5 = (randomService.RandomInt(0, 1000) > 5000 ? "+" : "-");
            labSheetDetailModel.Negative44_5 = (randomService.RandomInt(0, 1000) > 5000 ? "+" : "-");
            labSheetDetailModel.Blank35 = "-";
            labSheetDetailModel.Lot35 = "34 45";
            labSheetDetailModel.Lot44_5 = "33 56";
            labSheetDetailModel.Weather = "Sunny";
            labSheetDetailModel.RunComment = "20 Birds";
            labSheetDetailModel.SampleBottleLotNumber = "45 56";
            labSheetDetailModel.SalinitiesReadBy = "TY";
            labSheetDetailModel.SalinitiesReadDate = randomService.RandomDateTime();
            labSheetDetailModel.ResultsReadBy = "TT";
            labSheetDetailModel.ResultsReadDate = randomService.RandomDateTime();
            labSheetDetailModel.ResultsRecordedBy = "UT";
            labSheetDetailModel.ResultsRecordedDate = randomService.RandomDateTime();
            labSheetDetailModel.DailyDuplicateRLog = randomService.RandomFloat(0.4f, 0.8f);
            labSheetDetailModel.DailyDuplicatePrecisionCriteria = randomService.RandomFloat(0.4f, 0.8f);
            labSheetDetailModel.DailyDuplicateAcceptable = (randomService.RandomInt(0, 1000) > 5000 ? true : false);

            Assert.IsTrue(labSheetDetailModel.LabSheetID > 0);
            Assert.IsTrue(labSheetDetailModel.MWQMPlanID > 0);
            Assert.IsTrue(labSheetDetailModel.SubsectorTVItemID > 0);
            Assert.IsTrue(labSheetDetailModel.Version == 1);
            Assert.IsTrue(labSheetDetailModel.RunDate != null);
            Assert.IsTrue(labSheetDetailModel.Tides.Length > 0);
            Assert.IsTrue(labSheetDetailModel.SampleCrewInitials.Length > 0);
            Assert.IsTrue(labSheetDetailModel.IncubationStartTime != null);
            Assert.IsTrue(labSheetDetailModel.IncubationEndTime != null);
            Assert.IsTrue(labSheetDetailModel.IncubationTimeCalculated_minutes == 23 * 60);
            Assert.IsTrue(labSheetDetailModel.WaterBath.Length > 0);
            Assert.IsTrue(labSheetDetailModel.TCField1 >= 10 && labSheetDetailModel.TCField1 <= 20);
            Assert.IsTrue(labSheetDetailModel.TCLab1 >= 10 && labSheetDetailModel.TCLab1 <= 20);
            Assert.IsTrue(labSheetDetailModel.TCField2 >= 10 && labSheetDetailModel.TCField2 <= 20);
            Assert.IsTrue(labSheetDetailModel.TCLab2 >= 10 && labSheetDetailModel.TCLab2 <= 20);
            Assert.IsTrue(labSheetDetailModel.TCFirst >= 10 && labSheetDetailModel.TCFirst <= 20);
            Assert.IsTrue(labSheetDetailModel.TCAverage >= 10 && labSheetDetailModel.TCAverage <= 20);
            Assert.IsTrue(labSheetDetailModel.ControlLot.Length > 0);
            Assert.IsTrue(labSheetDetailModel.Positive35.Length == 1 && "+-".Contains(labSheetDetailModel.Positive35));
            Assert.IsTrue(labSheetDetailModel.NonTarget35.Length == 1 && "+-".Contains(labSheetDetailModel.NonTarget35));
            Assert.IsTrue(labSheetDetailModel.Negative35.Length == 1 && "+-".Contains(labSheetDetailModel.Negative35));
            Assert.IsTrue(labSheetDetailModel.Positive44_5.Length == 1 && "+-".Contains(labSheetDetailModel.Positive44_5));
            Assert.IsTrue(labSheetDetailModel.NonTarget44_5.Length == 1 && "+-".Contains(labSheetDetailModel.NonTarget44_5));
            Assert.IsTrue(labSheetDetailModel.Negative44_5.Length == 1 && "+-".Contains(labSheetDetailModel.Negative44_5));
            Assert.IsTrue(labSheetDetailModel.Blank35 == "-");
            Assert.IsTrue(labSheetDetailModel.Lot35.Length > 0);
            Assert.IsTrue(labSheetDetailModel.Lot44_5.Length > 0);
            Assert.IsTrue(labSheetDetailModel.Weather.Length > 0);
            Assert.IsTrue(labSheetDetailModel.RunComment.Length > 0);
            Assert.IsTrue(labSheetDetailModel.SampleBottleLotNumber.Length > 0);
            Assert.IsTrue(labSheetDetailModel.SalinitiesReadBy.Length > 0);
            Assert.IsTrue(labSheetDetailModel.SalinitiesReadDate != null);
            Assert.IsTrue(labSheetDetailModel.ResultsReadBy.Length > 0);
            Assert.IsTrue(labSheetDetailModel.ResultsReadDate != null);
            Assert.IsTrue(labSheetDetailModel.ResultsRecordedBy.Length > 0);
            Assert.IsTrue(labSheetDetailModel.ResultsRecordedDate != null);
            Assert.IsTrue(labSheetDetailModel.DailyDuplicateRLog >= 0.4f && labSheetDetailModel.DailyDuplicateRLog <= 0.8f);
            Assert.IsTrue(labSheetDetailModel.DailyDuplicatePrecisionCriteria >= 0.4f && labSheetDetailModel.DailyDuplicatePrecisionCriteria <= 0.8f);
            Assert.IsTrue(labSheetDetailModel.DailyDuplicateAcceptable == true || labSheetDetailModel.DailyDuplicateAcceptable == false);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            labSheetDetailService = new LabSheetDetailService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            appTaskService = new AppTaskService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvFileService = new TVFileService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            labSheetDetailModelNew = new LabSheetDetailModel();
            labSheetDetail = new LabSheetDetail();
        }
        private void SetupShim()
        {
            shimLabSheetDetailService = new ShimLabSheetDetailService(labSheetDetailService);
        }
        #endregion Functions private
    }
}


