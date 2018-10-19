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
    /// Summary description for MikeSourceStartEndServiceTest
    /// </summary>
    [TestClass]
    public class MikeSourceStartEndServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MikeSourceStartEnd";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MikeSourceStartEndService mikeSourceStartEndService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MikeSourceStartEndModel mikeSourceStartEndModelNew { get; set; }
        private MikeSourceStartEnd mikeSourceStartEnd { get; set; }
        private ShimMikeSourceStartEndService shimMikeSourceStartEndService { get; set; }
        private MikeSourceServiceTest mikeSourceServiceTest { get; set; }
        private MikeSourceService mikeSourceService { get; set; }
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
        public MikeSourceStartEndServiceTest()
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
        public void MikeSourceStartEndService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(mikeSourceStartEndService.db);
                Assert.IsNotNull(mikeSourceStartEndService.LanguageRequest);
                Assert.IsNotNull(mikeSourceStartEndService.User);
                Assert.AreEqual(user.Identity.Name, mikeSourceStartEndService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mikeSourceStartEndService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_MikeSourceStartEndModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = mikeSourceServiceTest.AddMikeSourceModel();
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    #region Good
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);

                    string retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region MikeSourceID
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.MikeSourceID = 0;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceID), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.MikeSourceID = 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MikeSourceID

                    #region StartDateAndTime_Local
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.StartDateAndTime_Local = DateTime.UtcNow;
                    mikeSourceStartEndModelNew.EndDateAndTime_Local = mikeSourceStartEndModelNew.StartDateAndTime_Local.AddHours(1);

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.StartDateAndTime_Local = DateTime.UtcNow;
                    mikeSourceStartEndModelNew.EndDateAndTime_Local = mikeSourceStartEndModelNew.StartDateAndTime_Local.AddHours(1);
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceStartEndService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion StartDateAndTime_Local

                    #region EndDateAndTime_Local
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.StartDateAndTime_Local = DateTime.UtcNow;
                    mikeSourceStartEndModelNew.EndDateAndTime_Local = mikeSourceStartEndModelNew.StartDateAndTime_Local.AddHours(1);

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.StartDateAndTime_Local = DateTime.UtcNow;
                    mikeSourceStartEndModelNew.EndDateAndTime_Local = mikeSourceStartEndModelNew.StartDateAndTime_Local.AddHours(1);
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceStartEndService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion EndDateAndTime_Local

                    #region StartDateAndTime_Local > EndDateAndTime_Local
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.StartDateAndTime_Local = DateTime.UtcNow;
                    mikeSourceStartEndModelNew.EndDateAndTime_Local = mikeSourceStartEndModelNew.StartDateAndTime_Local.AddHours(-1);

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDateAndTime_Local, ServiceRes.EndDateAndTime_Local), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.StartDateAndTime_Local = DateTime.UtcNow;
                    mikeSourceStartEndModelNew.EndDateAndTime_Local = mikeSourceStartEndModelNew.StartDateAndTime_Local.AddHours(1);

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion StartDateAndTime_Local > EndDateAndTime_Local

                    #region SourceFlowStart_m3_day
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    double Min = 0;
                    double Max = 10000000000;
                    mikeSourceStartEndModelNew.SourceFlowStart_m3_day = Min - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourceFlowStart_m3_day, Min, Max), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceFlowStart_m3_day = Max + 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourceFlowStart_m3_day, Min, Max), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceFlowStart_m3_day = Max - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceFlowStart_m3_day = Min;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceFlowStart_m3_day = Max;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SourceFlowStart_m3_day

                    #region SourceFlowEnd_m3_day
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    Min = 0;
                    Max = 10000000000;
                    mikeSourceStartEndModelNew.SourceFlowEnd_m3_day = Min - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourceFlowEnd_m3_day, Min, Max), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceFlowEnd_m3_day = Max + 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourceFlowEnd_m3_day, Min, Max), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceFlowEnd_m3_day = Max - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceFlowEnd_m3_day = Min;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceFlowEnd_m3_day = Max;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SourceFlowEnd_m3_day

                    #region SourcePollutionStart_MPN_100ml_m3_day
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    int MinInt = 0;
                    int MaxInt = 30000000;
                    mikeSourceStartEndModelNew.SourcePollutionStart_MPN_100ml = MinInt - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourcePollutionStart_MPN_100ml, MinInt, MaxInt), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourcePollutionStart_MPN_100ml = MaxInt + 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourcePollutionStart_MPN_100ml, MinInt, MaxInt), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourcePollutionStart_MPN_100ml = MaxInt - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourcePollutionStart_MPN_100ml = MinInt;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourcePollutionStart_MPN_100ml = MaxInt;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SourcePollutionStart_MPN_100ml_m3_day

                    #region SourcePollutionEnd_MPN_100ml_m3_day
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    MinInt = 0;
                    MaxInt = 30000000;
                    mikeSourceStartEndModelNew.SourcePollutionEnd_MPN_100ml = MinInt - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourcePollutionEnd_MPN_100ml, MinInt, MaxInt), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourcePollutionEnd_MPN_100ml = MaxInt + 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourcePollutionEnd_MPN_100ml, MinInt, MaxInt), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourcePollutionEnd_MPN_100ml = MaxInt - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourcePollutionEnd_MPN_100ml = MinInt;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourcePollutionEnd_MPN_100ml = MaxInt;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SourcePollutionEnd_MPN_100ml_m3_day

                    #region SourceTemperatureStart_C
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    Min = 0;
                    Max = 40;
                    mikeSourceStartEndModelNew.SourceTemperatureStart_C = Min - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourceTemperatureStart_C, Min, Max), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceTemperatureStart_C = Max + 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourceTemperatureStart_C, Min, Max), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceTemperatureStart_C = Max - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceTemperatureStart_C = Min;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceTemperatureStart_C = Max;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SourceTemperatureStart_C

                    #region SourceTemperatureEnd_C
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    Min = 0;
                    Max = 40;
                    mikeSourceStartEndModelNew.SourceTemperatureEnd_C = Min - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourceTemperatureEnd_C, Min, Max), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceTemperatureEnd_C = Max + 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourceTemperatureEnd_C, Min, Max), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceTemperatureEnd_C = Max - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceTemperatureEnd_C = Min;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceTemperatureEnd_C = Max;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SourceTemperatureEnd_C

                    #region SourceSalinityStart_PSU
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    Min = 0;
                    Max = 40;
                    mikeSourceStartEndModelNew.SourceSalinityStart_PSU = Min - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourceSalinityStart_PSU, Min, Max), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceSalinityStart_PSU = Max + 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourceSalinityStart_PSU, Min, Max), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceSalinityStart_PSU = Max - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceSalinityStart_PSU = Min;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceSalinityStart_PSU = Max;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SourceSalinityStart_PSU

                    #region SourceSalinityEnd_PSU
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    Min = 0;
                    Max = 40;
                    mikeSourceStartEndModelNew.SourceSalinityEnd_PSU = Min - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourceSalinityEnd_PSU, Min, Max), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceSalinityEnd_PSU = Max + 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.SourceSalinityEnd_PSU, Min, Max), retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceSalinityEnd_PSU = Max - 1;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceSalinityEnd_PSU = Min;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    mikeSourceStartEndModelNew.SourceSalinityEnd_PSU = Max;

                    retStr = mikeSourceStartEndService.MikeSourceStartEndModelOK(mikeSourceStartEndModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SourceSalinityEnd_PSU
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_FillMikeSourceStartEnd_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = mikeSourceServiceTest.AddMikeSourceModel();
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    mikeSourceStartEndModelNew.MikeSourceID = mikeSourceModelRet.MikeSourceID;
                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);

                    ContactOK contactOK = mikeSourceStartEndService.IsContactOK();

                    string retStr = mikeSourceStartEndService.FillMikeSourceStartEnd(mikeSourceStartEnd, mikeSourceStartEndModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mikeSourceStartEnd.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mikeSourceStartEndService.FillMikeSourceStartEnd(mikeSourceStartEnd, mikeSourceStartEndModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, mikeSourceStartEnd.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_GetMikeSourceStartEndModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    int mikeSourceStartEndCount = mikeSourceStartEndService.GetMikeSourceStartEndModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, mikeSourceStartEndCount);

                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_GetMikeSourceStartEndModelListWithMikeSourceIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceIDDB(mikeSourceStartEndModelRet.MikeSourceID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Where(c => c.MikeSourceStartEndID == mikeSourceStartEndModelRet.MikeSourceStartEndID).Any());

                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    MikeSourceModel mikeSourceModelRet = mikeSourceService.GetMikeSourceModelWithMikeSourceIDDB(mikeSourceStartEndModelRet.MikeSourceID);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(mikeSourceModelRet.MikeSourceTVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Where(c => c.MikeSourceStartEndID == mikeSourceStartEndModelRet.MikeSourceStartEndID).Any());

                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_GetMikeSourceStartEndModelWithMikeSourceStartEndIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    MikeSourceStartEndModel mikeSourceStartEndModelRet2 = mikeSourceStartEndService.GetMikeSourceStartEndModelWithMikeSourceStartEndIDDB(mikeSourceStartEndModelRet.MikeSourceStartEndID);
                    Assert.AreEqual(mikeSourceStartEndModelRet.MikeSourceStartEndID, mikeSourceStartEndModelRet2.MikeSourceStartEndID);

                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_GetMikeSourceStartEndWithMikeSourceStartEndIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    MikeSourceStartEnd mikeSourceStartEndRet = mikeSourceStartEndService.GetMikeSourceStartEndWithMikeSourceStartEndIDDB(mikeSourceStartEndModelRet.MikeSourceStartEndID);
                    Assert.AreEqual(mikeSourceStartEndModelRet.MikeSourceStartEndID, mikeSourceStartEndRet.MikeSourceStartEndID);

                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_GetMikeSourceStartEndModelExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    MikeSourceStartEndModel mikeSourceStartEndModelRet2 = mikeSourceStartEndService.GetMikeSourceStartEndModelExist(mikeSourceStartEndModelRet);
                    Assert.AreEqual(mikeSourceStartEndModelRet.MikeSourceStartEndID, mikeSourceStartEndModelRet2.MikeSourceStartEndID);

                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeSourceStartEndService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostAddUpdateDeleteMikeSourceStartEnd_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    MikeSourceStartEndModel mikeSourceStartEndModelRet2 = UpdateMikeSourceStartEndModel(mikeSourceStartEndModelRet);

                    MikeSourceStartEndModel mikeSourceStartEndModelRet3 = mikeSourceStartEndService.PostDeleteMikeSourceStartEndDB(mikeSourceStartEndModelRet2.MikeSourceStartEndID);
                    Assert.AreEqual("", mikeSourceStartEndModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostAddMikeSourceStartEndDB_MikeSourceStartEndModelOK_Error_Test()
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
                        shimMikeSourceStartEndService.MikeSourceStartEndModelOKMikeSourceStartEndModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostAddMikeSourceStartEndDB_IsContactOK_Error_Test()
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
                        shimMikeSourceStartEndService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostAddMikeSourceStartEndDB_GetMikeSourceStartEndModelExist_Error_Test()
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
                        shimMikeSourceStartEndService.GetMikeSourceStartEndModelExistMikeSourceStartEndModel = (a) =>
                        {
                            return new MikeSourceStartEndModel() { Error = "" };
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MikeSourceStartEnd), mikeSourceStartEndModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostAddMikeSourceStartEndDB_FillMikeSourceStartEnd_Error_Test()
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
                        shimMikeSourceStartEndService.FillMikeSourceStartEndMikeSourceStartEndMikeSourceStartEndModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostAddMikeSourceStartEndDB_DoAddChanges_Error_Test()
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
                        shimMikeSourceStartEndService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostAddMikeSourceStartEndDB_Add_Error_Test()
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
                        shimMikeSourceStartEndService.FillMikeSourceStartEndMikeSourceStartEndMikeSourceStartEndModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();
                        Assert.IsTrue(mikeSourceStartEndModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostAddMikeSourceStartEndDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = mikeSourceServiceTest.AddMikeSourceModel();
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    SetupTest(contactModelListBad[0], culture);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeSourceStartEndService.PostAddMikeSourceStartEndDB(mikeSourceStartEndModelNew);
                    Assert.IsNotNull(mikeSourceStartEndModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostAddMikeSourceStartEndDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = mikeSourceServiceTest.AddMikeSourceModel();

                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    SetupTest(contactModelListGood[2], culture);

                    FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeSourceStartEndService.PostAddMikeSourceStartEndDB(mikeSourceStartEndModelNew);
                    Assert.IsNotNull(mikeSourceStartEndModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostDeleteMikeSourceStartEnd_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceStartEndService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet2 = mikeSourceStartEndService.PostDeleteMikeSourceStartEndDB(mikeSourceStartEndModelRet.MikeSourceStartEndID);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostDeleteMikeSourceStartEnd_GetMikeSourceStartEndWithMikeSourceStartEndIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMikeSourceStartEndService.GetMikeSourceStartEndWithMikeSourceStartEndIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet2 = mikeSourceStartEndService.PostDeleteMikeSourceStartEndDB(mikeSourceStartEndModelRet.MikeSourceStartEndID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MikeSourceStartEnd), mikeSourceStartEndModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostDeleteMikeSourceStartEnd_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceStartEndService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet2 = mikeSourceStartEndService.PostDeleteMikeSourceStartEndDB(mikeSourceStartEndModelRet.MikeSourceStartEndID);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostUpdateMikeSourceStartEnd_MikeSourceStartEndModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceStartEndService.MikeSourceStartEndModelOKMikeSourceStartEndModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet2 = UpdateMikeSourceStartEndModel(mikeSourceStartEndModelRet);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostUpdateMikeSourceStartEnd_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceStartEndService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet2 = UpdateMikeSourceStartEndModel(mikeSourceStartEndModelRet);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostUpdateMikeSourceStartEnd_GetMikeSourceStartEndWithMikeSourceStartEndIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMikeSourceStartEndService.GetMikeSourceStartEndWithMikeSourceStartEndIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet2 = UpdateMikeSourceStartEndModel(mikeSourceStartEndModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MikeSourceStartEnd), mikeSourceStartEndModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostUpdateMikeSourceStartEnd_FillMikeSourceStartEnd_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceStartEndService.FillMikeSourceStartEndMikeSourceStartEndMikeSourceStartEndModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet2 = UpdateMikeSourceStartEndModel(mikeSourceStartEndModelRet);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceStartEndService_PostUpdateMikeSourceStartEnd_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = AddMikeSourceStartEndModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceStartEndService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet2 = UpdateMikeSourceStartEndModel(mikeSourceStartEndModelRet);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions
        public MikeSourceStartEndModel AddMikeSourceStartEndModel()
        {
            TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
            Assert.IsNotNull(tvItemModelParent);

            MikeSourceModel mikeSourceModelRet = mikeSourceServiceTest.AddMikeSourceModel();

            mikeSourceStartEndModelNew.MikeSourceID = mikeSourceModelRet.MikeSourceID;
            FillMikeSourceStartEndModel(mikeSourceStartEndModelNew);

            MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeSourceStartEndService.PostAddMikeSourceStartEndDB(mikeSourceStartEndModelNew);
            if (!string.IsNullOrWhiteSpace(mikeSourceStartEndModelRet.Error))
            {
                return mikeSourceStartEndModelRet;
            }

            CompareMikeSourceStartEndModels(mikeSourceStartEndModelNew, mikeSourceStartEndModelRet);

            return mikeSourceStartEndModelRet;
        }
        public MikeSourceStartEndModel UpdateMikeSourceStartEndModel(MikeSourceStartEndModel mikeSourceStartEndModelRet)
        {
            FillMikeSourceStartEndModel(mikeSourceStartEndModelRet);

            MikeSourceStartEndModel mikeSourceStartEndModelRet2 = mikeSourceStartEndService.PostUpdateMikeSourceStartEndDB(mikeSourceStartEndModelRet);
            if (!string.IsNullOrWhiteSpace(mikeSourceStartEndModelRet2.Error))
            {
                return mikeSourceStartEndModelRet2;
            }
            Assert.IsNotNull(mikeSourceStartEndModelRet2);
            CompareMikeSourceStartEndModels(mikeSourceStartEndModelRet, mikeSourceStartEndModelRet2);

            return mikeSourceStartEndModelRet2;
        }
        private void CompareMikeSourceStartEndModels(MikeSourceStartEndModel mikeSourceStartEndModelNew, MikeSourceStartEndModel mikeSourceStartEndModelRet)
        {
            Assert.AreEqual(mikeSourceStartEndModelNew.MikeSourceID, mikeSourceStartEndModelRet.MikeSourceID);
            Assert.AreEqual(mikeSourceStartEndModelNew.StartDateAndTime_Local, mikeSourceStartEndModelRet.StartDateAndTime_Local);
            Assert.AreEqual(mikeSourceStartEndModelNew.EndDateAndTime_Local, mikeSourceStartEndModelRet.EndDateAndTime_Local);
            Assert.AreEqual(mikeSourceStartEndModelNew.SourceFlowStart_m3_day, mikeSourceStartEndModelRet.SourceFlowStart_m3_day);
            Assert.AreEqual(mikeSourceStartEndModelNew.SourceFlowEnd_m3_day, mikeSourceStartEndModelRet.SourceFlowEnd_m3_day);
            Assert.AreEqual(mikeSourceStartEndModelNew.SourcePollutionStart_MPN_100ml, mikeSourceStartEndModelRet.SourcePollutionStart_MPN_100ml);
            Assert.AreEqual(mikeSourceStartEndModelNew.SourcePollutionEnd_MPN_100ml, mikeSourceStartEndModelRet.SourcePollutionEnd_MPN_100ml);
            Assert.AreEqual(mikeSourceStartEndModelNew.SourceSalinityStart_PSU, mikeSourceStartEndModelRet.SourceSalinityStart_PSU);
            Assert.AreEqual(mikeSourceStartEndModelNew.SourceSalinityEnd_PSU, mikeSourceStartEndModelRet.SourceSalinityEnd_PSU);
            Assert.AreEqual(mikeSourceStartEndModelNew.SourceTemperatureStart_C, mikeSourceStartEndModelRet.SourceTemperatureStart_C);
            Assert.AreEqual(mikeSourceStartEndModelNew.SourceTemperatureEnd_C, mikeSourceStartEndModelRet.SourceTemperatureEnd_C);
        }
        private void FillMikeSourceStartEndModel(MikeSourceStartEndModel mikeSourceStartEndModel)
        {
            mikeSourceStartEndModel.MikeSourceID = (mikeSourceStartEndModel.MikeSourceID == 0 ? 1 : mikeSourceStartEndModel.MikeSourceID);
            mikeSourceStartEndModel.StartDateAndTime_Local = randomService.RandomDateTime();
            mikeSourceStartEndModel.EndDateAndTime_Local = mikeSourceStartEndModel.StartDateAndTime_Local.AddHours(5);
            mikeSourceStartEndModel.SourceFlowStart_m3_day = randomService.RandomDouble(10, 1000);
            mikeSourceStartEndModel.SourceFlowEnd_m3_day = randomService.RandomDouble(10, 1000);
            mikeSourceStartEndModel.SourcePollutionStart_MPN_100ml = randomService.RandomInt(10, 1000000);
            mikeSourceStartEndModel.SourcePollutionEnd_MPN_100ml = randomService.RandomInt(10, 1000000);
            mikeSourceStartEndModel.SourceSalinityStart_PSU = randomService.RandomDouble(0, 32);
            mikeSourceStartEndModel.SourceSalinityEnd_PSU = randomService.RandomDouble(0, 32);
            mikeSourceStartEndModel.SourceTemperatureStart_C = randomService.RandomDouble(0, 25);
            mikeSourceStartEndModel.SourceTemperatureEnd_C = randomService.RandomDouble(0, 25);
            Assert.IsTrue(mikeSourceStartEndModel.MikeSourceID != 0);
            Assert.IsTrue(mikeSourceStartEndModel.MikeSourceID == (mikeSourceStartEndModel.MikeSourceID == 0 ? 1 : mikeSourceStartEndModel.MikeSourceID));
            Assert.IsTrue(mikeSourceStartEndModel.StartDateAndTime_Local != null);
            Assert.IsTrue(mikeSourceStartEndModel.EndDateAndTime_Local != null);
            Assert.IsTrue(mikeSourceStartEndModel.SourceFlowStart_m3_day >= 10 && mikeSourceStartEndModel.SourceFlowStart_m3_day <= 1000);
            Assert.IsTrue(mikeSourceStartEndModel.SourceFlowEnd_m3_day >= 10 && mikeSourceStartEndModel.SourceFlowEnd_m3_day <= 1000);
            Assert.IsTrue(mikeSourceStartEndModel.SourcePollutionStart_MPN_100ml >= 10 && mikeSourceStartEndModel.SourcePollutionStart_MPN_100ml <= 1000000);
            Assert.IsTrue(mikeSourceStartEndModel.SourcePollutionEnd_MPN_100ml >= 10 && mikeSourceStartEndModel.SourcePollutionEnd_MPN_100ml <= 1000000);
            Assert.IsTrue(mikeSourceStartEndModel.SourceSalinityStart_PSU >= 0 && mikeSourceStartEndModel.SourceSalinityStart_PSU <= 32);
            Assert.IsTrue(mikeSourceStartEndModel.SourceSalinityEnd_PSU >= 0 && mikeSourceStartEndModel.SourceSalinityEnd_PSU <= 32);
            Assert.IsTrue(mikeSourceStartEndModel.SourceTemperatureStart_C >= 0 && mikeSourceStartEndModel.SourceTemperatureStart_C <= 25);
            Assert.IsTrue(mikeSourceStartEndModel.SourceTemperatureEnd_C >= 0 && mikeSourceStartEndModel.SourceTemperatureEnd_C <= 25);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mikeSourceStartEndService = new MikeSourceStartEndService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mikeSourceService = new MikeSourceService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mikeSourceStartEndModelNew = new MikeSourceStartEndModel();
            mikeSourceStartEnd = new MikeSourceStartEnd();
            mikeSourceServiceTest = new MikeSourceServiceTest();
            mikeSourceServiceTest.SetupTest(contactModelToDo, culture);

        }
        private void SetupShim()
        {
            shimMikeSourceStartEndService = new ShimMikeSourceStartEndService(mikeSourceStartEndService);
        }
        #endregion Functions

    }
}


