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
    /// Summary description for MWQMSampleServiceTest
    /// </summary>
    [TestClass]
    public class MWQMSampleServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MWQMSample";
        private string Plurial = "s";
        List<string> BadTimeFormatList = new List<string>() { "1", "1:23", "1,23", "12;23", "9:45", "12:8", "233:23", "aa:bb", "25:12", "12:87" };
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MWQMSampleService mwqmSampleService { get; set; }
        private MWQMSampleLanguageService mwqmSampleLanguageService { get; set; }
        private TVItemService tvItemService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MWQMSampleModel mwqmSampleModelNew { get; set; }
        private MWQMSample mwqmSample { get; set; }
        private ShimMWQMSampleService shimMWQMSampleService { get; set; }
        private ShimMWQMSampleLanguageService shimMWQMSampleLanguageService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimMWQMRunService shimMWQMRunService { get; set; }
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
        public MWQMSampleServiceTest()
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
        public void MWQMSampleService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(mwqmSampleService);
                Assert.IsNotNull(mwqmSampleService._MWQMSampleLanguageService);
                Assert.IsNotNull(mwqmSampleService.db);
                Assert.IsNotNull(mwqmSampleService.LanguageRequest);
                Assert.IsNotNull(mwqmSampleService.User);
                Assert.AreEqual(user.Identity.Name, mwqmSampleService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mwqmSampleService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMWQMSite = randomService.RandomTVItem(TVTypeEnum.MWQMSite);
                    Assert.AreEqual("", tvItemModelMWQMSite.Error);

                    TVItemModel tvItemModelMWQMRun = randomService.RandomTVItem(TVTypeEnum.MWQMRun);
                    Assert.AreEqual("", tvItemModelMWQMRun.Error);

                    #region Good
                    mwqmSampleModelNew.MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID;
                    mwqmSampleModelNew.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
                    FillMWQMSampleModel(mwqmSampleModelNew);

                    string retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region MWQMSiteTVItemID
                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.MWQMSiteTVItemID = 0;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID), retStr);

                    mwqmSampleModelNew.MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID;
                    mwqmSampleModelNew.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
                    FillMWQMSampleModel(mwqmSampleModelNew);

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion MWQMSiteTVItemID

                    #region MWQMRunTVItemID
                    mwqmSampleModelNew.MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID;
                    mwqmSampleModelNew.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.MWQMRunTVItemID = 0;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMRunTVItemID), retStr);

                    mwqmSampleModelNew.MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID;
                    mwqmSampleModelNew.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
                    FillMWQMSampleModel(mwqmSampleModelNew);

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion MWQMRunTVItemID

                    #region SampleDateTime_Local
                    FillMWQMSampleModel(mwqmSampleModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMSampleService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion SampleDateTime_Local

                    #region Depth_m
                    FillMWQMSampleModel(mwqmSampleModelNew);
                    double Min = 0;
                    double Max = 10000;
                    mwqmSampleModelNew.Depth_m = Min - 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Depth_m, Min, Max), retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.Depth_m = Max + 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Depth_m, Min, Max), retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.Depth_m = Max - 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.Depth_m = Min;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.Depth_m = Max;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Depth_m

                    #region FecCol_MPN_100ml
                    FillMWQMSampleModel(mwqmSampleModelNew);
                    int MinInt = 0;
                    int MaxInt = 100000000;
                    mwqmSampleModelNew.FecCol_MPN_100ml = MinInt - 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FecCol_MPN_100ml, MinInt, MaxInt), retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.FecCol_MPN_100ml = MaxInt + 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FecCol_MPN_100ml, MinInt, MaxInt), retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.FecCol_MPN_100ml = MaxInt - 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.FecCol_MPN_100ml = MinInt;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.FecCol_MPN_100ml = MaxInt;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion FecCol_MPN_100ml

                    #region Salinity_PPT
                    FillMWQMSampleModel(mwqmSampleModelNew);
                    Min = 0;
                    Max = 40;
                    mwqmSampleModelNew.Salinity_PPT = Min - 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Salinity_PPT, Min, Max), retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.Salinity_PPT = Max + 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Salinity_PPT, Min, Max), retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.Salinity_PPT = Max - 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.Salinity_PPT = Min;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.Salinity_PPT = Max;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Salinity_PPT

                    #region WaterTemp_C
                    FillMWQMSampleModel(mwqmSampleModelNew);
                    Min = 0;
                    Max = 40;
                    mwqmSampleModelNew.WaterTemp_C = Min - 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WaterTemp_C, Min, Max), retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.WaterTemp_C = Max + 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WaterTemp_C, Min, Max), retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.WaterTemp_C = Max - 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.WaterTemp_C = Min;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.WaterTemp_C = Max;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion WaterTemp_C

                    #region PH
                    FillMWQMSampleModel(mwqmSampleModelNew);
                    Min = 0;
                    Max = 14;
                    mwqmSampleModelNew.PH = Min - 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PH, Min, Max), retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.PH = Max + 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PH, Min, Max), retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.PH = Max - 1;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.PH = Min;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.PH = Max;

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PH

                    #region SampleTypesText
                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.SampleTypesText = "";

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.SampleTypesText), retStr);

                    mwqmSampleModelNew.MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID;
                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.SampleTypesText = "" + ((int)SampleTypeEnum.Routine).ToString() + "," + ((int)SampleTypeEnum.DailyDuplicate).ToString() + ",";

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion SampleTypesText

                    #region MWQMSampleNote
                    FillMWQMSampleModel(mwqmSampleModelNew);
                    mwqmSampleModelNew.MWQMSampleNote = randomService.RandomString("", 30);

                    retStr = mwqmSampleService.MWQMSampleModelOK(mwqmSampleModelNew);
                    Assert.IsNotNull("", retStr);

                    // did not test the max of 10000 characters
                    #endregion MWQMSampleNote

                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_SampleTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                SampleTypeEnum sampleTypeEnum = (SampleTypeEnum)10000;

                string retStr = mwqmSampleService._BaseEnumService.SampleTypeOK(sampleTypeEnum);

                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SampleType), retStr);

                sampleTypeEnum = SampleTypeEnum.Routine;

                retStr = mwqmSampleService._BaseEnumService.SampleTypeOK(sampleTypeEnum);

                Assert.AreEqual("", retStr);
            }
        }
        [TestMethod]
        public void MWQMSampleService_FillMWQMSample_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FillMWQMSampleModel(mwqmSampleModelNew);

                    ContactOK contactOK = mwqmSampleService.IsContactOK();

                    string retStr = mwqmSampleService.FillMWQMSample(mwqmSample, mwqmSampleModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mwqmSample.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mwqmSampleService.FillMWQMSample(mwqmSample, mwqmSampleModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, mwqmSample.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_GetMWQMSampleModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    int mwqmSampleCount = mwqmSampleService.GetMWQMSampleModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, mwqmSampleCount);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_GetMWQMSampleModelListWithMWQMRunTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    List<MWQMSampleModel> mwqmSampleModelList = mwqmSampleService.GetMWQMSampleModelListWithMWQMRunTVItemIDDB(mwqmSampleModelRet.MWQMRunTVItemID);
                    Assert.IsTrue(mwqmSampleModelList.Where(c => c.MWQMSampleID == mwqmSampleModelRet.MWQMSampleID).Any());

                    int MWQMRunTVItemID = 0;
                    mwqmSampleModelList = mwqmSampleService.GetMWQMSampleModelListWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
                    Assert.AreEqual(0, mwqmSampleModelList.Count);

                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_GetMWQMSampleModelListWithMWQMSiteTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    List<MWQMSampleModel> mwqmSampleModelList = mwqmSampleService.GetMWQMSampleModelListWithMWQMSiteTVItemIDDB(mwqmSampleModelRet.MWQMSiteTVItemID);
                    Assert.IsTrue(mwqmSampleModelList.Where(c => c.MWQMSampleID == mwqmSampleModelRet.MWQMSampleID).Any());

                    int MWQMSiteTVItemID = 0;
                    mwqmSampleModelList = mwqmSampleService.GetMWQMSampleModelListWithMWQMSiteTVItemIDDB(MWQMSiteTVItemID);
                    Assert.AreEqual(0, mwqmSampleModelList.Count);

                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_GetMWQMSampleModelWithMWQMSampleIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    MWQMSampleModel mwqmSampleModelRet2 = mwqmSampleService.GetMWQMSampleModelWithMWQMSampleIDDB(mwqmSampleModelRet.MWQMSampleID);
                    Assert.AreEqual(mwqmSampleModelRet.MWQMSampleID, mwqmSampleModelRet2.MWQMSampleID);

                    int MWQMSampleID = 0;
                    MWQMSampleModel mwqmSampleModelRet3 = mwqmSampleService.GetMWQMSampleModelWithMWQMSampleIDDB(MWQMSampleID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSample, ServiceRes.MWQMSampleID, MWQMSampleID), mwqmSampleModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_GetMWQMSampleModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    MWQMSampleModel mwqmSampleModelRet2 = mwqmSampleService.GetMWQMSampleModelExistDB(mwqmSampleModelRet);
                    Assert.AreEqual(mwqmSampleModelRet.MWQMSampleID, mwqmSampleModelRet2.MWQMSampleID);

                    mwqmSampleModelRet.MWQMSiteTVItemID = 0;
                    MWQMSampleModel mwqmSampleModelRet3 = mwqmSampleService.GetMWQMSampleModelExistDB(mwqmSampleModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSample,
                        ServiceRes.MWQMSiteTVItemID + "," +
                        ServiceRes.SampleDateTime_Local + "," +
                        ServiceRes.Depth_m + "," +
                        ServiceRes.FecCol_MPN_100ml + "," +
                        ServiceRes.Salinity_PPT + "," +
                        ServiceRes.WaterTemp_C + "," +
                        ServiceRes.PH,
                        mwqmSampleModelRet.MWQMSiteTVItemID + "," +
                        mwqmSampleModelRet.SampleDateTime_Local + "," +
                        mwqmSampleModelRet.Depth_m + "," +
                        mwqmSampleModelRet.FecCol_MPN_100ml + "," +
                        mwqmSampleModelRet.Salinity_PPT + "," +
                        mwqmSampleModelRet.WaterTemp_C + "," +
                        mwqmSampleModelRet.PH), mwqmSampleModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_GetMWQMSampleModelWithMWQMSiteTVItemIDAndSampleDateTimeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    List<MWQMSampleModel> mwqmSampleModelList = mwqmSampleService.GetMWQMSampleModelListWithMWQMSiteTVItemIDAndSampleTypeAndSampleDateTimeDB(mwqmSampleModelRet.MWQMSiteTVItemID, SampleTypeEnum.Routine, mwqmSampleModelRet.SampleDateTime_Local);
                    Assert.IsTrue(mwqmSampleModelList.Count > 0);

                    int MWQMSiteTVItemID = 0;
                    mwqmSampleModelList = mwqmSampleService.GetMWQMSampleModelListWithMWQMSiteTVItemIDAndSampleTypeAndSampleDateTimeDB(MWQMSiteTVItemID, SampleTypeEnum.Routine, mwqmSampleModelRet.SampleDateTime_Local);
                    Assert.IsTrue(mwqmSampleModelList.Count == 0);

                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_GetMWQMSampleWithMWQMSampleIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    MWQMSample mwqmSampleRet = mwqmSampleService.GetMWQMSampleWithMWQMSampleIDDB(mwqmSampleModelRet.MWQMSampleID);
                    Assert.AreEqual(mwqmSampleModelRet.MWQMSampleID, mwqmSampleRet.MWQMSampleID);

                    int MWQMSampleID = 0;
                    MWQMSample mwqmSampleRet2 = mwqmSampleService.GetMWQMSampleWithMWQMSampleIDDB(MWQMSampleID);
                    Assert.IsNull(mwqmSampleRet2);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_GetMWQMSampleYearWithSubsectorTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    List<SubsectorMWQMSampleYear> subsectorMWQMSampleYearList = mwqmSampleService.GetMWQMSampleYearWithSubsectorTVItemIDDB(tvItemModelSubsector.TVItemID);
                    Assert.IsTrue(subsectorMWQMSampleYearList.Count > 0);

                    int SubsectorTVItemID = 0;
                    subsectorMWQMSampleYearList = mwqmSampleService.GetMWQMSampleYearWithSubsectorTVItemIDDB(SubsectorTVItemID);

                    Assert.IsTrue(subsectorMWQMSampleYearList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";

                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual("", mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_MWQMSampleID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "";

                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSampleID), mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_MWQMRunTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";
                    fc.Remove("MWQMRunTVItemID");

                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMRunTVItemID), mwqmSampleModelRet.Error);

                    fc["MWQMRunTVItemID"] = "";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMRunTVItemID), mwqmSampleModelRet.Error);

                    fc["MWQMRunTVItemID"] = "0";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMRunTVItemID), mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_GetMWQMRunModelWithMWQMRunTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";
                    fc["MWQMRunTVItemID"] = "989773420";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMRunService.GetMWQMRunModelWithMWQMRunTVItemIDDBInt32 = (a) =>
                        {
                            return new MWQMRunModel() { Error = ErrorText };
                        };

                        MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_MWQMSiteTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";
                    fc.Remove("MWQMSiteTVItemID");

                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID), mwqmSampleModelRet.Error);

                    fc["MWQMSiteTVItemID"] = "";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID), mwqmSampleModelRet.Error);

                    fc["MWQMSiteTVItemID"] = "0";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID), mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";
                    fc["MWQMSiteTVItemID"] = "989773420";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_SampleTime_bad_format_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";

                    foreach (string badTimeFormat in BadTimeFormatList)
                    {
                        fc["SampleTime"] = badTimeFormat;

                        MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes.Time_NotWellFormed, badTimeFormat), mwqmSampleModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_FecCol_MPN_100ml_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";
                    fc.Remove("FecCol_MPN_100ml");

                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FecCol_MPN_100ml), mwqmSampleModelRet.Error);

                    fc["FecCol_MPN_100ml"] = "";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FecCol_MPN_100ml), mwqmSampleModelRet.Error);

                    fc["FecCol_MPN_100ml"] = "-1";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._OnlyAllowsPositiveValues, ServiceRes.FecCol_MPN_100ml), mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_WaterTemp_C_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";
                    fc.Remove("WaterTemp_C");

                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.IsNull(mwqmSampleModelRet.WaterTemp_C);

                    fc["WaterTemp_C"] = "";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.IsNull(mwqmSampleModelRet.WaterTemp_C);

                    fc["WaterTemp_C"] = "-1";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WaterTemp_C, 0, 40), mwqmSampleModelRet.Error);

                    fc["WaterTemp_C"] = "41";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WaterTemp_C, 0, 40), mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_Salinity_PPT_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";
                    fc.Remove("Salinity_PPT");

                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.IsNull(mwqmSampleModelRet.Salinity_PPT);

                    fc["Salinity_PPT"] = "";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.IsNull(mwqmSampleModelRet.Salinity_PPT);

                    fc["Salinity_PPT"] = "-1";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Salinity_PPT, 0, 40), mwqmSampleModelRet.Error);

                    fc["Salinity_PPT"] = "41";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Salinity_PPT, 0, 40), mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_Depth_m_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";
                    fc.Remove("Depth_m");

                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.IsNull(mwqmSampleModelRet.Depth_m);

                    fc["Depth_m"] = "";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.IsNull(mwqmSampleModelRet.Depth_m);

                    fc["Depth_m"] = "-1";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Depth_m, 0, 10000), mwqmSampleModelRet.Error);

                    fc["Depth_m"] = "10001";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Depth_m, 0, 10000), mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_PH_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";
                    fc.Remove("PH");

                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.IsNull(mwqmSampleModelRet.PH);

                    fc["PH"] = "";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.IsNull(mwqmSampleModelRet.PH);

                    fc["PH"] = "-1";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PH, 0, 14), mwqmSampleModelRet.Error);

                    fc["PH"] = "15";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PH, 0, 14), mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_ProcessedBy_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";
                    fc.Remove("ProcessedBy");

                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.IsNull(mwqmSampleModelRet.ProcessedBy);

                    fc["ProcessedBy"] = randomService.RandomString("", 11);

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ProcessedBy, 10), mwqmSampleModelRet.Error);

                    fc["SampleTime"] = "04:04";
                    fc["ProcessedBy"] = "aa";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual("AA", mwqmSampleModelRet.ProcessedBy);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_SampleType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";
                    fc.Remove("SampleTypes[]");

                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SampleTypes), mwqmSampleModelRet.Error);

                    fc["SampleTypes[]"] = "";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SampleTypes), mwqmSampleModelRet.Error);

                    fc["SampleTypes[]"] = "823748";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SampleType), mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_MWQMSampleNote_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";
                    fc.Remove("MWQMSampleNote");

                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual((mwqmSampleService.LanguageRequest == LanguageEnum.fr ? "Empty (fr)" : "Empty"), mwqmSampleModelRet.MWQMSampleNote);

                    fc["MWQMSampleNote"] = "";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.IsNull(mwqmSampleModelRet.MWQMSampleNote);

                    fc["SampleTime"] = "04:04";
                    fc["MWQMSampleNote"] = "samplenote";

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual("samplenote", mwqmSampleModelRet.MWQMSampleNote);

                    fc["SampleTime"] = "04:05";
                    fc["MWQMSampleNote"] = randomService.RandomString("", 251);

                    mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Comment, 250), mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Add_PostAddMWQMSampleDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMSampleService.PostAddMWQMSampleDBMWQMSampleModel = (a) =>
                        {
                            return new MWQMSampleModel() { Error = ErrorText };
                        };

                        MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Modify_GetMWQMSampleModelWithMWQMSampleIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    fc["MWQMSampleID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMSampleService.GetMWQMSampleModelWithMWQMSampleIDDBInt32 = (a) =>
                        {
                            return new MWQMSampleModel() { Error = ErrorText };
                        };
                        MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Modify_MWQMSiteTVItem_not_Equal_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                    int OldMWQMSiteTVItemID = int.Parse(fc["MWQMSiteTVItemID"]);
                    int NewMWQMSiteTVItemID = randomService.RandomTVItem(TVTypeEnum.MWQMSite).TVItemID;

                    while (OldMWQMSiteTVItemID == NewMWQMSiteTVItemID)
                    {
                        NewMWQMSiteTVItemID = randomService.RandomTVItem(TVTypeEnum.MWQMSite).TVItemID;
                    }

                    fc["MWQMSiteTVItemID"] = NewMWQMSiteTVItemID.ToString();


                    MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._NotEqual, OldMWQMSiteTVItemID + ", " + NewMWQMSiteTVItemID), mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_MWQMSampleAddOrModifyDB_Modify_PostUpdateMWQMSampleDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillFormCollectionForMWQMSampleService();
                    Assert.IsNotNull(fc);

                     using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMSampleService.PostUpdateMWQMSampleDBMWQMSampleModel = (a) =>
                        {
                            return new MWQMSampleModel() { Error = ErrorText };
                        };

                        MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.MWQMSampleAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostAddUpdateDeleteMWQMSample_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    mwqmSampleModelRet.Salinity_PPT = mwqmSampleModelRet.Salinity_PPT + 1;

                    MWQMSampleModel mwqmSampleModelRet2 = mwqmSampleService.PostUpdateMWQMSampleDB(mwqmSampleModelRet);
                    Assert.AreEqual("", mwqmSampleModelRet2.Error);

                    MWQMSampleModel mwqmSampleModelRet3 = mwqmSampleService.PostDeleteMWQMSampleDB(mwqmSampleModelRet2.MWQMSampleID);
                    Assert.AreEqual("", mwqmSampleModelRet3.Error);

                    mwqmSampleModelRet2.MWQMSampleNote = null;

                    MWQMSampleModel mwqmSampleModelRet4 = mwqmSampleService.PostAddMWQMSampleDB(mwqmSampleModelRet2);
                    Assert.AreEqual("", mwqmSampleModelRet4.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostAddMWQMSampleDB_MWQMSampleModelOK_Error_Test()
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
                        shimMWQMSampleService.MWQMSampleModelOKMWQMSampleModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostAddMWQMSampleDB_IsContactOK_Error_Test()
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
                        shimMWQMSampleService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostAddMWQMSampleDB_GetMWQMSampleModelExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMSampleService.GetMWQMSampleModelExistDBMWQMSampleModel = (a) =>
                        {
                            return new MWQMSampleModel() { Error = "" };
                        };

                        FillMWQMSampleModel(mwqmSampleModelRet);

                        MWQMSampleModel mwqmSampleModelRet2 = mwqmSampleService.PostAddMWQMSampleDB(mwqmSampleModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMSample), mwqmSampleModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostAddMWQMSampleDB_FillMWQMSample_Error_Test()
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
                        shimMWQMSampleService.FillMWQMSampleMWQMSampleMWQMSampleModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostAddMWQMSampleDB_DoAddChanges_Error_Test()
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
                        shimMWQMSampleService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostAddMWQMSampleDB_Add_Error_Test()
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
                        shimMWQMSampleService.FillMWQMSampleMWQMSampleMWQMSampleModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                        Assert.IsTrue(mwqmSampleModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostAddMWQMSampleDB_PostAddMWQMSampleLanguageDB_Error_Test()
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
                        shimMWQMSampleLanguageService.PostAddMWQMSampleLanguageDBMWQMSampleLanguageModel = (a) =>
                        {
                            return new MWQMSampleLanguageModel() { Error = ErrorText };
                        };

                        MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostAddMWQMSampleDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.IsNotNull(mwqmSampleModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostAddMWQMSampleDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.IsNotNull(mwqmSampleModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mwqmSampleModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostDeleteMWQMSample_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSampleService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSampleModel mwqmSampleModelRet2 = mwqmSampleService.PostDeleteMWQMSampleDB(mwqmSampleModelRet.MWQMSampleID);
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostDeleteMWQMSample_GetMWQMSampleWithMWQMSampleIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMSampleService.GetMWQMSampleWithMWQMSampleIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMSampleModel mwqmSampleModelRet2 = mwqmSampleService.PostDeleteMWQMSampleDB(mwqmSampleModelRet.MWQMSampleID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMSample), mwqmSampleModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostDeleteMWQMSample_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSampleService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleModel mwqmSampleModelRet2 = mwqmSampleService.PostDeleteMWQMSampleDB(mwqmSampleModelRet.MWQMSampleID);
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostUpdateMWQMSample_MWQMSampleModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSampleService.MWQMSampleModelOKMWQMSampleModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleModel mwqmSampleModelRet2 = UpdateMWQMSampleModel(mwqmSampleModelRet);
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostUpdateMWQMSample_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSampleService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSampleModel mwqmSampleModelRet2 = UpdateMWQMSampleModel(mwqmSampleModelRet);
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostUpdateMWQMSample_GetMWQMSampleWithMWQMSampleIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMSampleService.GetMWQMSampleWithMWQMSampleIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMSampleModel mwqmSampleModelRet2 = UpdateMWQMSampleModel(mwqmSampleModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSample), mwqmSampleModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostUpdateMWQMSample_FillMWQMSample_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSampleService.FillMWQMSampleMWQMSampleMWQMSampleModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleModel mwqmSampleModelRet2 = UpdateMWQMSampleModel(mwqmSampleModelRet);
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostUpdateMWQMSample_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSampleService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSampleModel mwqmSampleModelRet2 = UpdateMWQMSampleModel(mwqmSampleModelRet);
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSampleService_PostUpdateMWQMSample_PostUpdateMWQMSampleLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSampleModel mwqmSampleModelRet = AddMWQMSampleModel();
                    Assert.AreEqual("", mwqmSampleModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSampleLanguageService.PostUpdateMWQMSampleLanguageDBMWQMSampleLanguageModel = (a) =>
                        {
                            return new MWQMSampleLanguageModel() { Error = ErrorText };
                        };

                        MWQMSampleModel mwqmSampleModelRet2 = UpdateMWQMSampleModel(mwqmSampleModelRet);
                        Assert.AreEqual(ErrorText, mwqmSampleModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public MWQMSampleModel AddMWQMSampleModel()
        {
            TVItemModel tvItemModelMWQMSite = randomService.RandomTVItem(TVTypeEnum.MWQMSite);
            Assert.AreEqual("", tvItemModelMWQMSite.Error);

            TVItemModel tvItemModelMWQMRun = randomService.RandomTVItem(TVTypeEnum.MWQMRun);
            Assert.AreEqual("", tvItemModelMWQMRun.Error);

            mwqmSampleModelNew.MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID;
            mwqmSampleModelNew.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;
            FillMWQMSampleModel(mwqmSampleModelNew);

            MWQMSampleModel mwqmSampleModelRet = mwqmSampleService.PostAddMWQMSampleDB(mwqmSampleModelNew);
            if (!string.IsNullOrWhiteSpace(mwqmSampleModelRet.Error))
            {
                return mwqmSampleModelRet;
            }

            CompareMWQMSampleModels(mwqmSampleModelNew, mwqmSampleModelRet);

            return mwqmSampleModelRet;
        }
        public MWQMSampleModel UpdateMWQMSampleModel(MWQMSampleModel mwqmSampleModel)
        {
            FillMWQMSampleModel(mwqmSampleModel);

            MWQMSampleModel mwqmSampleModelRet2 = mwqmSampleService.PostUpdateMWQMSampleDB(mwqmSampleModel);
            if (!string.IsNullOrWhiteSpace(mwqmSampleModelRet2.Error))
            {
                return mwqmSampleModelRet2;
            }

            CompareMWQMSampleModels(mwqmSampleModel, mwqmSampleModelRet2);

            return mwqmSampleModelRet2;
        }
        private void CompareMWQMSampleModels(MWQMSampleModel mwqmSampleModelNew, MWQMSampleModel mwqmSampleModelRet)
        {
            Assert.AreEqual(mwqmSampleModelNew.MWQMSiteTVItemID, mwqmSampleModelRet.MWQMSiteTVItemID);
            Assert.AreEqual(mwqmSampleModelNew.Depth_m, mwqmSampleModelRet.Depth_m);
            Assert.AreEqual(mwqmSampleModelNew.FecCol_MPN_100ml, mwqmSampleModelRet.FecCol_MPN_100ml);
            Assert.AreEqual(mwqmSampleModelNew.PH, mwqmSampleModelRet.PH);
            Assert.AreEqual(mwqmSampleModelNew.Salinity_PPT, mwqmSampleModelRet.Salinity_PPT);
            Assert.AreEqual(mwqmSampleModelNew.SampleDateTime_Local, mwqmSampleModelRet.SampleDateTime_Local);
            Assert.AreEqual(mwqmSampleModelNew.WaterTemp_C, mwqmSampleModelRet.WaterTemp_C);
            Assert.AreEqual(mwqmSampleModelNew.SampleTypesText, mwqmSampleModelRet.SampleTypesText);
            Assert.AreEqual(mwqmSampleModelNew.Tube_10, mwqmSampleModelRet.Tube_10);
            Assert.AreEqual(mwqmSampleModelNew.Tube_1_0, mwqmSampleModelRet.Tube_1_0);
            Assert.AreEqual(mwqmSampleModelNew.Tube_0_1, mwqmSampleModelRet.Tube_0_1);
            Assert.AreEqual(mwqmSampleModelNew.ProcessedBy, mwqmSampleModelRet.ProcessedBy);
            Assert.AreEqual(mwqmSampleModelNew.MWQMSampleNote, mwqmSampleModelRet.MWQMSampleNote);

            foreach (LanguageEnum Lang in mwqmSampleService.LanguageListAllowable)
            {
                MWQMSampleLanguageModel mwqmSampleLanguageModel = mwqmSampleService._MWQMSampleLanguageService.GetMWQMSampleLanguageModelWithMWQMSampleIDAndLanguageDB(mwqmSampleModelRet.MWQMSampleID, Lang);

                Assert.AreEqual("", mwqmSampleLanguageModel.Error);
                if (Lang == mwqmSampleService.LanguageRequest)
                {
                    Assert.AreEqual(mwqmSampleModelRet.MWQMSampleNote, mwqmSampleLanguageModel.MWQMSampleNote);
                }
            }
        }
        private FormCollection FillFormCollectionForMWQMSampleService()
        {
            FormCollection fc = new FormCollection();
            MWQMSampleModel mwqmSampleModel = AddMWQMSampleModel();
            Assert.AreEqual("", mwqmSampleModel.Error);

            fc.Add("MWQMSampleID", mwqmSampleModel.MWQMSampleID.ToString());
            fc.Add("MWQMSiteTVItemID", mwqmSampleModel.MWQMSiteTVItemID.ToString());
            fc.Add("MWQMRunTVItemID", mwqmSampleModel.MWQMRunTVItemID.ToString());
            fc.Add("Depth_m", ((float)mwqmSampleModel.Depth_m).ToString("F1"));
            fc.Add("FecCol_MPN_100ml", mwqmSampleModel.FecCol_MPN_100ml.ToString());
            fc.Add("PH", ((float)mwqmSampleModel.PH).ToString("F1"));
            fc.Add("Salinity_PPT", ((float)mwqmSampleModel.Salinity_PPT).ToString("F1"));
            fc.Add("SampleTime", ((DateTime)mwqmSampleModel.SampleDateTime_Local).ToString("hh:mm"));
            fc.Add("WaterTemp_C", ((float)mwqmSampleModel.WaterTemp_C).ToString("F1"));
            fc.Add("SampleTypes[]", mwqmSampleModel.SampleTypesText);
            fc.Add("Tube_10", mwqmSampleModel.Tube_10.ToString());
            fc.Add("Tube_1_0", mwqmSampleModel.Tube_1_0.ToString());
            fc.Add("Tube_0_1", mwqmSampleModel.Tube_0_1.ToString());
            fc.Add("ProcessedBy", mwqmSampleModel.ProcessedBy);
            fc.Add("MWQMSampleNote", mwqmSampleModel.MWQMSampleNote);

            return fc;
        }
        private void FillMWQMSampleModel(MWQMSampleModel mwqmSampleModel)
        {
            //mwqmSampleModel.MWQMSiteTVItemID = mwqmSampleModel.MWQMSiteTVItemID;
            //mwqmSampleModel.MWQMRunTVItemID = mwqmSampleModel.MWQMRunTVItemID;
            mwqmSampleModel.Depth_m = randomService.RandomDouble(0.0, 10000.0);
            mwqmSampleModel.FecCol_MPN_100ml = randomService.RandomInt(0, 10000000);
            mwqmSampleModel.PH = randomService.RandomDouble(0.0, 14.0);
            mwqmSampleModel.Salinity_PPT = randomService.RandomDouble(0.0, 35.0);
            mwqmSampleModel.SampleDateTime_Local = new DateTime(2017, 3, 3, 3, 3, 0);
            mwqmSampleModel.WaterTemp_C = randomService.RandomDouble(0.0, 35.0);
            mwqmSampleModel.SampleTypesText = "" + ((int)SampleTypeEnum.Routine).ToString() + "," + ((int)SampleTypeEnum.DailyDuplicate).ToString();
            mwqmSampleModel.Tube_10 = 5;
            mwqmSampleModel.Tube_1_0 = 4;
            mwqmSampleModel.Tube_0_1 = 1;
            mwqmSampleModel.ProcessedBy = randomService.RandomString("", 6);
            mwqmSampleModel.MWQMSampleNote = randomService.RandomString("", 20);

            //Assert.IsTrue(mwqmSampleModel.MWQMSiteTVItemID != 0);
            //Assert.IsTrue(mwqmSampleModel.MWQMRunTVItemID != 0);
            Assert.IsTrue(mwqmSampleModel.Depth_m >= 0.0 && mwqmSampleModel.Depth_m <= 10000.0);
            Assert.IsTrue(mwqmSampleModel.FecCol_MPN_100ml >= 0 && mwqmSampleModel.FecCol_MPN_100ml <= 10000000);
            Assert.IsTrue(mwqmSampleModel.PH >= 0.0 && mwqmSampleModel.PH <= 14.0);
            Assert.IsTrue(mwqmSampleModel.Salinity_PPT >= 0.0 && mwqmSampleModel.Salinity_PPT <= 35.0);
            Assert.IsTrue(mwqmSampleModel.SampleDateTime_Local != null);
            Assert.IsTrue(mwqmSampleModel.WaterTemp_C >= 0.0 && mwqmSampleModel.WaterTemp_C <= 35.0);
            Assert.IsTrue(mwqmSampleModel.SampleTypesText == "" + ((int)SampleTypeEnum.Routine).ToString() + "," + ((int)SampleTypeEnum.DailyDuplicate).ToString());
            Assert.IsTrue(mwqmSampleModel.Tube_10 == 5);
            Assert.IsTrue(mwqmSampleModel.Tube_1_0 == 4);
            Assert.IsTrue(mwqmSampleModel.Tube_0_1 == 1);
            Assert.IsTrue(mwqmSampleModel.ProcessedBy.Length > 0);
            Assert.IsTrue(mwqmSampleModel.MWQMSampleNote.Length == 20);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mwqmSampleService = new MWQMSampleService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmSampleLanguageService = new MWQMSampleLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmSampleModelNew = new MWQMSampleModel();
            mwqmSample = new MWQMSample();
        }
        private void SetupShim()
        {
            shimMWQMSampleService = new ShimMWQMSampleService(mwqmSampleService);
            shimMWQMSampleLanguageService = new ShimMWQMSampleLanguageService(mwqmSampleService._MWQMSampleLanguageService);
            shimTVItemService = new ShimTVItemService(mwqmSampleService._TVItemService);
            shimMWQMRunService = new ShimMWQMRunService(mwqmSampleService._MWQMRunService);
        }
        #endregion Functions private
    }

}

