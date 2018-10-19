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
using System.Threading;
using System.Globalization;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MWQMSiteServiceTest
    /// </summary>
    [TestClass]
    public class MWQMSiteServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MWQMSite";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MWQMSiteService mwqmSiteService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MWQMSiteModel mwqmSiteModelNew { get; set; }
        private MWQMSite mwqmSite { get; set; }
        private ShimMWQMSiteService shimMWQMSiteService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
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
        public MWQMSiteServiceTest()
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
        //[TestMethod]
        //public void Junk()
        //{
        //            //    SetupTest(contactModelListGood[0], setupData.cultureListGood[0]);

        //    List<TVItem> tvItemList = (from c in mwqmSiteService.db.TVItems
        //                               where c.TVType == (int)TVTypeEnum.MWQMSite
        //                               select c).ToList();
        //    int count = 0;
        //    foreach (TVItem tvItem in tvItemList)
        //    {
        //        count += 1;
        //        MWQMSiteStartEndDate mwqmSiteStartEndDate = (from c in mwqmSiteService.db.MWQMSiteStartEndDates
        //                                                     where c.MWQMSiteTVItemID == tvItem.TVItemID
        //                                                     orderby c.StartDate descending
        //                                                     select c).FirstOrDefault();

        //        if (mwqmSiteStartEndDate == null)
        //        {
        //            if (tvItem.IsActive != false)
        //            {
        //                tvItem.IsActive = false;
        //            }
        //        }
        //        else
        //        {
        //            if (mwqmSiteStartEndDate.EndDate == null)
        //            {
        //                if (tvItem.IsActive != true)
        //                {
        //                    tvItem.IsActive = true;
        //                }
        //            }
        //            else
        //            {
        //                if (tvItem.IsActive != false)
        //                {
        //                    tvItem.IsActive = false;
        //                }
        //            }
        //        }
        //    }

        //    try
        //    {
        //        mwqmSiteService.db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.IsTrue(false);
        //        return;
        //    }
        //}
        [TestMethod]
        public void MWQMSiteService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange
                Assert.IsNotNull(mwqmSiteService);
                Assert.IsNotNull(mwqmSiteService.db);
                Assert.IsNotNull(mwqmSiteService.LanguageRequest);
                Assert.IsNotNull(mwqmSiteService.User);
                Assert.AreEqual(user.Identity.Name, mwqmSiteService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mwqmSiteService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MWQMSiteService_MWQMSiteModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModel = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModel.Error);

                    #region Good
                    mwqmSiteModelNew.MWQMSiteTVItemID = mwqmSiteModel.MWQMSiteTVItemID;
                    FillMWQMSiteModel(mwqmSiteModelNew);

                    string retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region MWQMSiteTVItemID
                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.MWQMSiteTVItemID = 0;

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID), retStr);

                    mwqmSiteModelNew.MWQMSiteTVItemID = mwqmSiteModel.MWQMSiteTVItemID;
                    FillMWQMSiteModel(mwqmSiteModelNew);

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMSiteTVItemID

                    #region MWQMSiteTVText
                    int Min = 1;
                    int Max = 200;

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.MWQMSiteTVText = randomService.RandomString("", Min - 1);

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.MWQMSiteTVText, Min), retStr);

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.MWQMSiteTVText = randomService.RandomString("", Max + 1);

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.MWQMSiteTVText, Max), retStr);

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.MWQMSiteTVText = randomService.RandomString("", Min);

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.MWQMSiteTVText = randomService.RandomString("", Max);

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.MWQMSiteTVText = randomService.RandomString("", Max - 1);

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMSiteTVText

                    #region MWQMSiteNumber
                    Min = 1;
                    Max = 8;

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.MWQMSiteNumber = randomService.RandomString("", Min - 1);

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.MWQMSiteNumber, Min), retStr);

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.MWQMSiteNumber = randomService.RandomString("", Max + 1);

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.MWQMSiteNumber, Max), retStr);

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.MWQMSiteNumber = randomService.RandomString("", Min);

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.MWQMSiteNumber = randomService.RandomString("", Max);

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.MWQMSiteNumber = randomService.RandomString("", Max - 1);

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMSiteNumber

                    #region Ordinal
                    Min = 0;
                    Max = 1000;

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.Ordinal = Min - 1;

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Ordinal, Min, Max), retStr);

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.Ordinal = Max + 1;

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Ordinal, Min, Max), retStr);

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.Ordinal = Min;

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.Ordinal = Max;

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSiteModel(mwqmSiteModelNew);
                    mwqmSiteModelNew.Ordinal = Max - 1;

                    retStr = mwqmSiteService.MWQMSiteModelOK(mwqmSiteModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Ordinal
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_FillMWQMSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    mwqmSiteModelNew.MWQMSiteTVItemID = mwqmSiteModelRet.MWQMSiteTVItemID;
                    FillMWQMSiteModel(mwqmSiteModelNew);

                    ContactOK contactOK = mwqmSiteService.IsContactOK();

                    string retStr = mwqmSiteService.FillMWQMSite(mwqmSite, mwqmSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mwqmSite.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mwqmSiteService.FillMWQMSite(mwqmSite, mwqmSiteModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, mwqmSite.LastUpdateContactTVItemID);

                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods public Get
        [TestMethod]
        public void MWQMSiteService_GetMWQMSiteModelCount_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    int mwqmSiteCount = mwqmSiteService.GetMWQMSiteModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, mwqmSiteCount);

                    MWQMSiteModel mwqmSiteModelRet2 = mwqmSiteService.PostDeleteMWQMSiteDB(mwqmSiteModelRet.MWQMSiteID);
                    Assert.AreEqual("", mwqmSiteModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_GetMWQMSiteMapInfoStatDB_SampleCountLessThan10_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int TVItemID = (from t in mwqmSiteService.db.TVItems
                                    let sampleCount = (from s in mwqmSiteService.db.MWQMSamples where s.MWQMSiteTVItemID == t.TVItemID select s).Count()
                                    where sampleCount < 10
                                    && sampleCount > 3
                                    && t.TVType == (int)TVTypeEnum.MWQMSite
                                    select t.TVItemID).FirstOrDefault<int>();
                    Assert.IsTrue(TVItemID > 0);

                    int NumberOfSamples = 30;
                    int SampCount = (from w in mwqmSiteService.db.MWQMSites
                                     from s in mwqmSiteService.db.MWQMSamples
                                     where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                     && w.MWQMSiteTVItemID == TVItemID
                                     orderby s.SampleDateTime_Local descending
                                     select s).Take(NumberOfSamples).ToList<MWQMSample>().Count();

                    TVLocation tvLocation = new TVLocation();

                    mwqmSiteService.GetMWQMSiteMapInfoStatDB(TVItemID, tvLocation, NumberOfSamples);
                    Assert.AreEqual(TVTypeEnum.LessThan10, tvLocation.SubTVType);
                    Assert.AreEqual(SampCount.ToString() + " -  - " + ServiceRes.LessThan10Samples + " - " + ServiceRes.NumberOfSamples + ": [" + string.Format("{0:F0}", SampCount) + "]", tvLocation.TVText);

                    NumberOfSamples = 15;
                    SampCount = (from w in mwqmSiteService.db.MWQMSites
                                 from s in mwqmSiteService.db.MWQMSamples
                                 where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                 && w.MWQMSiteTVItemID == TVItemID
                                 orderby s.SampleDateTime_Local descending
                                 select s).Take(NumberOfSamples).ToList<MWQMSample>().Count();

                    tvLocation = new TVLocation();

                    mwqmSiteService.GetMWQMSiteMapInfoStatDB(TVItemID, tvLocation, NumberOfSamples);
                    Assert.AreEqual(TVTypeEnum.LessThan10, tvLocation.SubTVType);
                    Assert.AreEqual(SampCount.ToString() + " -  - " + ServiceRes.LessThan10Samples + " - " + ServiceRes.NumberOfSamples + ": [" + string.Format("{0:F0}", SampCount) + "]", tvLocation.TVText);

                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_GetMWQMSiteMapInfoStatDB_SampleCountBetween10And30_BeforeYear2014_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int TVItemID = (from t in mwqmSiteService.db.TVItems
                                    let sampleCount = (from s in mwqmSiteService.db.MWQMSamples where s.MWQMSiteTVItemID == t.TVItemID select s).Count()
                                    where sampleCount < 30
                                    && sampleCount > 10
                                    && t.TVType == (int)TVTypeEnum.MWQMSite
                                    select t.TVItemID).FirstOrDefault<int>();
                    Assert.IsTrue(TVItemID > 0);

                    int NumberOfSamples = 30;
                    List<MWQMSample> mwqmSampleList = (from w in mwqmSiteService.db.MWQMSites
                                                       from s in mwqmSiteService.db.MWQMSamples
                                                       where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                                       && w.MWQMSiteTVItemID == TVItemID
                                                       orderby s.SampleDateTime_Local descending
                                                       select s).Take(NumberOfSamples).ToList<MWQMSample>();

                    int SampCount = mwqmSampleList.Count();

                    List<double> GeoMeanList = (from c in mwqmSampleList
                                                orderby c.FecCol_MPN_100ml
                                                select (double)c.FecCol_MPN_100ml).ToList<double>();

                    double P90 = (float)mwqmSiteService._TVItemService.GetP90(GeoMeanList);
                    double GeoMean = (float)mwqmSiteService._TVItemService.GeometricMean(GeoMeanList);
                    double Median = (float)mwqmSiteService._TVItemService.GetMedian(GeoMeanList);
                    double PercOver43 = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 43).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
                    double PercOver260 = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 260).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
                    int MinYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Min().Year;
                    int MaxYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Max().Year;
                    int MinFC = 0;
                    int MaxFC = 0;
                    if (SampCount > 0)
                    {
                        MinFC = (int)mwqmSampleList.Min(c => c.FecCol_MPN_100ml);
                        MaxFC = (int)mwqmSampleList.Max(c => c.FecCol_MPN_100ml);
                    }

                    TVLocation tvLocation2 = new TVLocation();

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvLocation2, P90, GeoMean, Median, PercOver43, PercOver260);

                    TVLocation tvLocation = new TVLocation();

                    mwqmSiteService.GetMWQMSiteMapInfoStatDB(TVItemID, tvLocation, NumberOfSamples);

                    List<TVTypeEnum> tvTypeRes = new List<TVTypeEnum>() { TVTypeEnum.NoDepuration, TVTypeEnum.Failed, TVTypeEnum.Passed };
                    Assert.IsTrue(tvTypeRes.Contains(tvLocation.SubTVType));
                    Assert.AreEqual(tvLocation2.TVText + " - " + ServiceRes.GM + ": [" + string.Format("{0:F2}", GeoMean) +
                        "] " + ServiceRes.Med + ": [" + string.Format("{0:F2}", Median) +
                        "] " + ServiceRes.P90 + ": [" + string.Format("{0:F2}", P90) +
                        "] >43: [" + string.Format("{0:F2}%", PercOver43) +
                        "] >260: [" + string.Format("{0:F2}%", PercOver260) +
                        "] " + ServiceRes.Min + ": [" + string.Format("{0:F0}", MinFC) +
                        "] " + ServiceRes.Max + ": [" + string.Format("{0:F0}", MaxFC) +
                        "] " + ServiceRes.NumberOfSamples + ": [" + string.Format("{0:F0}", SampCount) +
                        "] " + ServiceRes.StatPeriod + ": [" + string.Format("{0} - {1}", MinYear, MaxYear) + "]", tvLocation.TVText);

                    NumberOfSamples = 15;
                    mwqmSampleList = (from w in mwqmSiteService.db.MWQMSites
                                      from s in mwqmSiteService.db.MWQMSamples
                                      where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                      && w.MWQMSiteTVItemID == TVItemID
                                      orderby s.SampleDateTime_Local descending
                                      select s).Take(NumberOfSamples).ToList<MWQMSample>();

                    SampCount = mwqmSampleList.Count();

                    GeoMeanList = (from c in mwqmSampleList
                                   orderby c.FecCol_MPN_100ml
                                   select (double)c.FecCol_MPN_100ml).ToList<double>();

                    P90 = (float)mwqmSiteService._TVItemService.GetP90(GeoMeanList);
                    GeoMean = (float)mwqmSiteService._TVItemService.GeometricMean(GeoMeanList);
                    Median = (float)mwqmSiteService._TVItemService.GetMedian(GeoMeanList);
                    PercOver43 = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 43).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
                    PercOver260 = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 260).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
                    MinYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Min().Year;
                    MaxYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Max().Year;
                    MinFC = 0;
                    MaxFC = 0;
                    if (SampCount > 0)
                    {
                        MinFC = (int)mwqmSampleList.Min(c => c.FecCol_MPN_100ml);
                        MaxFC = (int)mwqmSampleList.Max(c => c.FecCol_MPN_100ml);
                    }

                    tvLocation2 = new TVLocation();

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvLocation2, P90, GeoMean, Median, PercOver43, PercOver260);

                    tvLocation = new TVLocation();

                    mwqmSiteService.GetMWQMSiteMapInfoStatDB(TVItemID, tvLocation, NumberOfSamples);

                    tvTypeRes = new List<TVTypeEnum>() { TVTypeEnum.NoDepuration, TVTypeEnum.Failed, TVTypeEnum.Passed };
                    Assert.IsTrue(tvTypeRes.Contains(tvLocation.SubTVType));
                    Assert.AreEqual(tvLocation2.TVText + " - " + ServiceRes.GM + ": [" + string.Format("{0:F2}", GeoMean) +
                        "] " + ServiceRes.Med + ": [" + string.Format("{0:F2}", Median) +
                        "] " + ServiceRes.P90 + ": [" + string.Format("{0:F2}", P90) +
                        "] >43: [" + string.Format("{0:F2}%", PercOver43) +
                        "] >260: [" + string.Format("{0:F2}%", PercOver260) +
                        "] " + ServiceRes.Min + ": [" + string.Format("{0:F0}", MinFC) +
                        "] " + ServiceRes.Max + ": [" + string.Format("{0:F0}", MaxFC) +
                        "] " + ServiceRes.NumberOfSamples + ": [" + string.Format("{0:F0}", SampCount) +
                        "] " + ServiceRes.StatPeriod + ": [" + string.Format("{0} - {1}", MinYear, MaxYear) + "]", tvLocation.TVText);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_GetMWQMSiteMapInfoStatDB_SampleCountBiggerThan30_Before2014_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int TVItemID = (from t in mwqmSiteService.db.TVItems
                                    let sampleCount = (from s in mwqmSiteService.db.MWQMSamples where s.MWQMSiteTVItemID == t.TVItemID select s).Count()
                                    where sampleCount > 30
                                    && t.TVType == (int)TVTypeEnum.MWQMSite
                                    select t.TVItemID).FirstOrDefault<int>();
                    Assert.IsTrue(TVItemID > 0);

                    //int Year = 2014;
                    int NumberOfSamples = 30;
                    List<MWQMSample> mwqmSampleList = (from w in mwqmSiteService.db.MWQMSites
                                                       from s in mwqmSiteService.db.MWQMSamples
                                                       where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                                       && w.MWQMSiteTVItemID == TVItemID
                                                       orderby s.SampleDateTime_Local descending
                                                       select s).Take(NumberOfSamples).ToList<MWQMSample>();

                    int SampCount = mwqmSampleList.Count();

                    List<double> GeoMeanList = (from c in mwqmSampleList
                                                orderby c.FecCol_MPN_100ml
                                                select (double)c.FecCol_MPN_100ml).ToList<double>();

                    double P90 = (float)mwqmSiteService._TVItemService.GetP90(GeoMeanList);
                    double GeoMean = (float)mwqmSiteService._TVItemService.GeometricMean(GeoMeanList);
                    double Median = (float)mwqmSiteService._TVItemService.GetMedian(GeoMeanList);
                    double PercOver43 = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 43).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
                    double PercOver260 = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 260).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
                    int MinYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Min().Year;
                    int MaxYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Max().Year;
                    int MinFC = 0;
                    int MaxFC = 0;
                    if (SampCount > 0)
                    {
                        MinFC = (int)mwqmSampleList.Min(c => c.FecCol_MPN_100ml);
                        MaxFC = (int)mwqmSampleList.Max(c => c.FecCol_MPN_100ml);
                    }

                    TVLocation tvLocation2 = new TVLocation();

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvLocation2, P90, GeoMean, Median, PercOver43, PercOver260);

                    TVLocation tvLocation = new TVLocation();

                    mwqmSiteService.GetMWQMSiteMapInfoStatDB(TVItemID, tvLocation, NumberOfSamples);

                    List<TVTypeEnum> tvTypeRes = new List<TVTypeEnum>() { TVTypeEnum.NoDepuration, TVTypeEnum.Failed, TVTypeEnum.Passed };
                    Assert.IsTrue(tvTypeRes.Contains(tvLocation.SubTVType));
                    Assert.AreEqual(tvLocation2.TVText + " - " + ServiceRes.GM + ": [" + string.Format("{0:F2}", GeoMean) +
                        "] " + ServiceRes.Med + ": [" + string.Format("{0:F2}", Median) +
                        "] " + ServiceRes.P90 + ": [" + string.Format("{0:F2}", P90) +
                        "] >43: [" + string.Format("{0:F2}%", PercOver43) +
                        "] >260: [" + string.Format("{0:F2}%", PercOver260) +
                        "] " + ServiceRes.Min + ": [" + string.Format("{0:F0}", MinFC) +
                        "] " + ServiceRes.Max + ": [" + string.Format("{0:F0}", MaxFC) +
                        "] " + ServiceRes.NumberOfSamples + ": [" + string.Format("{0:F0}", SampCount) +
                        "] " + ServiceRes.StatPeriod + ": [" + string.Format("{0} - {1}", MinYear, MaxYear) + "]", tvLocation.TVText);

                    //Year = 2014;
                    NumberOfSamples = 15;
                    mwqmSampleList = (from w in mwqmSiteService.db.MWQMSites
                                      from s in mwqmSiteService.db.MWQMSamples
                                      where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                      && w.MWQMSiteTVItemID == TVItemID
                                      orderby s.SampleDateTime_Local descending
                                      select s).Take(NumberOfSamples).ToList<MWQMSample>();

                    SampCount = mwqmSampleList.Count();

                    GeoMeanList = (from c in mwqmSampleList
                                   orderby c.FecCol_MPN_100ml
                                   select (double)c.FecCol_MPN_100ml).ToList<double>();

                    P90 = (float)mwqmSiteService._TVItemService.GetP90(GeoMeanList);
                    GeoMean = (float)mwqmSiteService._TVItemService.GeometricMean(GeoMeanList);
                    Median = (float)mwqmSiteService._TVItemService.GetMedian(GeoMeanList);
                    PercOver43 = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 43).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
                    PercOver260 = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 260).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
                    MinYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Min().Year;
                    MaxYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Max().Year;
                    MinFC = 0;
                    MaxFC = 0;
                    if (SampCount > 0)
                    {
                        MinFC = (int)mwqmSampleList.Min(c => c.FecCol_MPN_100ml);
                        MaxFC = (int)mwqmSampleList.Max(c => c.FecCol_MPN_100ml);
                    }

                    tvLocation2 = new TVLocation();

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvLocation2, P90, GeoMean, Median, PercOver43, PercOver260);

                    tvLocation = new TVLocation();

                    mwqmSiteService.GetMWQMSiteMapInfoStatDB(TVItemID, tvLocation, NumberOfSamples);

                    tvTypeRes = new List<TVTypeEnum>() { TVTypeEnum.NoDepuration, TVTypeEnum.Failed, TVTypeEnum.Passed };
                    Assert.IsTrue(tvTypeRes.Contains(tvLocation.SubTVType));
                    Assert.AreEqual(tvLocation2.TVText + " - " + ServiceRes.GM + ": [" + string.Format("{0:F2}", GeoMean) +
                        "] " + ServiceRes.Med + ": [" + string.Format("{0:F2}", Median) +
                        "] " + ServiceRes.P90 + ": [" + string.Format("{0:F2}", P90) +
                        "] >43: [" + string.Format("{0:F2}%", PercOver43) +
                        "] >260: [" + string.Format("{0:F2}%", PercOver260) +
                        "] " + ServiceRes.Min + ": [" + string.Format("{0:F0}", MinFC) +
                        "] " + ServiceRes.Max + ": [" + string.Format("{0:F0}", MaxFC) +
                        "] " + ServiceRes.NumberOfSamples + ": [" + string.Format("{0:F0}", SampCount) +
                        "] " + ServiceRes.StatPeriod + ": [" + string.Format("{0} - {1}", MinYear, MaxYear) + "]", tvLocation.TVText);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_GetMWQMSiteMapInfoStatDBOneDay_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int TVItemID = (from t in mwqmSiteService.db.TVItems
                                    let sampleCount = (from s in mwqmSiteService.db.MWQMSamples where s.MWQMSiteTVItemID == t.TVItemID select s).Count()
                                    where sampleCount > 30
                                    && t.TVType == (int)TVTypeEnum.MWQMSite
                                    select t.TVItemID).FirstOrDefault<int>();
                    Assert.IsTrue(TVItemID > 0);

                    List<MWQMSample> mwqmSampleList = (from w in mwqmSiteService.db.MWQMSites
                                                       from s in mwqmSiteService.db.MWQMSamples
                                                       where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                                       && w.MWQMSiteTVItemID == TVItemID
                                                       orderby s.SampleDateTime_Local descending
                                                       select s).ToList<MWQMSample>();


                    TVLocation tvLocation = new TVLocation();

                    DateTime SampleDate = new DateTime(mwqmSampleList[0].SampleDateTime_Local.Year, mwqmSampleList[0].SampleDateTime_Local.Month, mwqmSampleList[0].SampleDateTime_Local.Day);

                    mwqmSampleList = (from w in mwqmSiteService.db.MWQMSites
                                      from s in mwqmSiteService.db.MWQMSamples
                                      where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                      && w.MWQMSiteTVItemID == TVItemID
                                      && (s.SampleDateTime_Local.Year == SampleDate.Year
                                      && s.SampleDateTime_Local.Month == SampleDate.Month
                                      && s.SampleDateTime_Local.Day == SampleDate.Day)
                                      orderby s.SampleDateTime_Local descending
                                      select s).ToList<MWQMSample>();

                    int SampCount = mwqmSampleList.Count();

                    double Mean = (from c in mwqmSampleList
                                   orderby c.FecCol_MPN_100ml
                                   select (double)c.FecCol_MPN_100ml).Average();

                    TVLocation tvLocation2 = new TVLocation();

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvLocation2, Mean);

                    mwqmSiteService.GetMWQMSiteMapInfoStatOneDayDB(TVItemID, tvLocation, SampleDate);

                    List<TVTypeEnum> tvTypeResList = new List<TVTypeEnum>() { TVTypeEnum.Passed, TVTypeEnum.Failed, TVTypeEnum.NoDepuration };

                    Assert.IsTrue(tvTypeResList.Contains(tvLocation.SubTVType));
                    Assert.AreEqual(tvLocation2.TVText + " - (" + string.Format("{0:F0}", Mean) + ")", tvLocation.TVText);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_GetMWQMSiteMapInfoStatDBOneDay_NoData_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int TVItemID = (from t in mwqmSiteService.db.TVItems
                                    let sampleCount = (from s in mwqmSiteService.db.MWQMSamples where s.MWQMSiteTVItemID == t.TVItemID select s).Count()
                                    where sampleCount == 0
                                    && t.TVType == (int)TVTypeEnum.MWQMSite
                                    select t.TVItemID).FirstOrDefault<int>();
                    Assert.IsTrue(TVItemID > 0);

                    TVLocation tvLocation = new TVLocation();
                    DateTime SampleDate = new DateTime(2100, 4, 5);

                    mwqmSiteService.GetMWQMSiteMapInfoStatOneDayDB(TVItemID, tvLocation, SampleDate);
                    Assert.AreEqual(TVTypeEnum.NoData, tvLocation.SubTVType);
                    Assert.AreEqual(" - " + ServiceRes.NoData, tvLocation.TVText);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_GetMWQMSiteModelWithMWQMSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    // Act 
                    MWQMSiteModel mwqmSiteModelRet2 = mwqmSiteService.GetMWQMSiteModelWithMWQMSiteIDDB(mwqmSiteModelRet.MWQMSiteID);

                    // Assert 
                    CompareMWQMSiteModels(mwqmSiteModelRet, mwqmSiteModelRet2);

                    int MWQMSiteID = 0;
                    MWQMSiteModel mwqmSiteModelRet3 = mwqmSiteService.GetMWQMSiteModelWithMWQMSiteIDDB(MWQMSiteID);

                    // Assert 
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSite, ServiceRes.MWQMSiteID, MWQMSiteID), mwqmSiteModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_GetMWQMSiteModelWithMWQMSiteTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    MWQMSiteModel mwqmSiteModelRet2 = mwqmSiteService.GetMWQMSiteModelWithMWQMSiteTVItemIDDB(mwqmSiteModelRet.MWQMSiteTVItemID);

                    CompareMWQMSiteModels(mwqmSiteModelRet, mwqmSiteModelRet2);

                    int MWQMSiteTVItemID = 0;
                    MWQMSiteModel mwqmSiteModelRet3 = mwqmSiteService.GetMWQMSiteModelWithMWQMSiteTVItemIDDB(MWQMSiteTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSite, ServiceRes.MWQMSiteTVItemID, MWQMSiteTVItemID), mwqmSiteModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_GetMWQMSiteRunWithTVItemIDSubsectorDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVText = "NB-06-020-002"; // Bouctouche River
                    TVItemModel tvItemModelSubsector = mwqmSiteService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, TVText, TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    List<DateTime> mwqmSiteRunDateList = mwqmSiteService.GetMWQMSiteRunWithTVItemIDSubsectorDB(tvItemModelSubsector.TVItemID);
                    Assert.IsTrue(mwqmSiteRunDateList.Count > 10);

                    int SubsectorTVItemID = 0;
                    mwqmSiteRunDateList = mwqmSiteService.GetMWQMSiteRunWithTVItemIDSubsectorDB(SubsectorTVItemID);
                    Assert.IsTrue(mwqmSiteRunDateList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_GetMWQMSiteSamplesWithMovingAverageDB_15_Days_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVText = "NB-06-020-002"; // Bouctouche River
                    TVItemModel tvItemModelSubsector = mwqmSiteService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, TVText, TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    List<TVItemModel> tvItemModelMWQMSiteList = mwqmSiteService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.MWQMSite);
                    Assert.IsTrue(tvItemModelMWQMSiteList.Count > 4);

                    List<MWQMSiteSampleFCModel> mwqmSiteSampleFCModelList15Days = mwqmSiteService.GetMWQMSiteSamplesWithMovingAverageDB(tvItemModelMWQMSiteList[0].TVItemID, 15);
                    Assert.IsTrue(mwqmSiteSampleFCModelList15Days.Count > 50);

                    int MWQMSiteTVItemID = 0;
                    mwqmSiteSampleFCModelList15Days = mwqmSiteService.GetMWQMSiteSamplesWithMovingAverageDB(MWQMSiteTVItemID, 15);
                    Assert.IsTrue(mwqmSiteSampleFCModelList15Days.Count == 0);

                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_GetMWQMSiteSamplesWithMovingAverageDB_30_Days_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string TVText = "NB-06-020-002"; // Bouctouche River
                    TVItemModel tvItemModelSubsector = mwqmSiteService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, TVText, TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    List<TVItemModel> tvItemModelMWQMSiteList = mwqmSiteService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.MWQMSite);
                    Assert.IsTrue(tvItemModelMWQMSiteList.Count > 4);

                    List<MWQMSiteSampleFCModel> mwqmSiteSampleFCModelList30Days = mwqmSiteService.GetMWQMSiteSamplesWithMovingAverageDB(tvItemModelMWQMSiteList[0].TVItemID, 30);
                    Assert.IsTrue(mwqmSiteSampleFCModelList30Days.Count > 50);

                    int MWQMSiteTVItemID = 0;
                    mwqmSiteSampleFCModelList30Days = mwqmSiteService.GetMWQMSiteSamplesWithMovingAverageDB(MWQMSiteTVItemID, 30);
                    Assert.IsTrue(mwqmSiteSampleFCModelList30Days.Count == 0);

                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_GetMWQMSiteWithMWQMSiteIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    MWQMSite mwqmSiteRet = mwqmSiteService.GetMWQMSiteWithMWQMSiteIDDB(mwqmSiteModelRet.MWQMSiteID);
                    Assert.AreEqual(mwqmSiteModelRet.MWQMSiteID, mwqmSiteRet.MWQMSiteID);

                    int MWQMSiteID = 0;
                    MWQMSite mwqmSiteRet2 = mwqmSiteService.GetMWQMSiteWithMWQMSiteIDDB(MWQMSiteID);
                    Assert.IsNull(mwqmSiteRet2);
                }
            }
        }
        #endregion Testing Methods public Get

        #region Testing Methods public helper
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStat1_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();
                    List<int> FCValueList = new List<int>() { 10, 20, 30, 40, 50, 60, 70 };
                    List<MWQMSample> mwqmSampleList = new List<MWQMSample>();
                    int MinFC = FCValueList.Min();
                    int MaxFC = FCValueList.Max();
                    int SampCount = FCValueList.Count();
                    foreach (double fcValue in FCValueList)
                    {
                        mwqmSampleList.Add(new MWQMSample() { FecCol_MPN_100ml = (int)fcValue });
                    }

                    List<double> GeoMeanList = (from c in mwqmSampleList
                                                orderby c.FecCol_MPN_100ml
                                                select (double)c.FecCol_MPN_100ml).ToList<double>();

                    double P90 = (float)mwqmSiteService._TVItemService.GetP90(GeoMeanList);
                    double GeoMean = (float)mwqmSiteService._TVItemService.GeometricMean(GeoMeanList);
                    double Median = (float)mwqmSiteService._TVItemService.GetMedian(GeoMeanList);
                    double PercOver43 = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 43).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
                    double PercOver260 = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 260).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
                    int MinYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Min().Year;
                    int MaxYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Max().Year;

                    mwqmSiteService.CalculateMWQMSiteStat(mwqmSampleList, tvlNew, MinFC, MaxFC, SampCount);
                    Assert.AreEqual("F -  - " + ServiceRes.GM + ": [" + string.Format("{0:F2}", GeoMean) +
                        "] " + ServiceRes.Med + ": [" + string.Format("{0:F2}", Median) +
                        "] " + ServiceRes.P90 + ": [" + string.Format("{0:F2}", P90) +
                        "] >43: [" + string.Format("{0:F2}%", PercOver43) +
                        "] >260: [" + string.Format("{0:F2}%", PercOver260) +
                        "] " + ServiceRes.Min + ": [" + string.Format("{0:F0}", MinFC) +
                        "] " + ServiceRes.Max + ": [" + string.Format("{0:F0}", MaxFC) +
                        "] " + ServiceRes.NumberOfSamples + ": [" + string.Format("{0:F0}", SampCount) +
                        "] " + ServiceRes.StatPeriod + ": [" + string.Format("{0} - {1}", MinYear, MaxYear) + "]", tvlNew.TVText);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_NoDepuration_F_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.NoDepuration;
                string Letter = "F";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(460.1D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 182.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 182.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 0.0D, 19.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_NoDepuration_E_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.NoDepuration;
                string Letter = "E";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(421.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 163.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 163.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 0.0D, 17.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_NoDepuration_D_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.NoDepuration;
                string Letter = "D";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(381.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 145.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 145.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 0.0D, 16.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_NoDepuration_C_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.NoDepuration;
                string Letter = "C";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(341.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 126.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 126.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 0.0D, 14.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_NoDepuration_B_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.NoDepuration;
                string Letter = "B";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(301.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 107.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 107.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 0.0D, 12.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_NoDepuration_A_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.NoDepuration;
                string Letter = "A";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(261.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 89.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 89.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 0.0D, 11.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_Failed_F_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Failed;
                string Letter = "F";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(224.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 76.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 76.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 27.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_Failed_E_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Failed;
                string Letter = "E";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(188.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 64.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 64.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 24.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_Failed_D_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Failed;
                string Letter = "D";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(152.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 52.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 52.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 21.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_Failed_C_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Failed;
                string Letter = "C";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(116.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 39.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 39.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 17.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_Failed_B_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Failed;
                string Letter = "B";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(80.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 27.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 27.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 14.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_Failed_A_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Failed;
                string Letter = "A";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(44.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 15.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 15.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 11.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_Passed_F_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Passed;
                string Letter = "F";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(36.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 12.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 12.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 9.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_Passed_E_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Passed;
                string Letter = "E";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(29.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 10.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 10.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 7.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_Passed_D_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Passed;
                string Letter = "D";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(22.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 8.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 8.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 6.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_Passed_C_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Passed;
                string Letter = "C";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(15.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 5.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 5.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 4.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_Passed_B_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Passed;
                string Letter = "B";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(8.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 3.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 3.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 2.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatLetterAndSubTVType_Passed_A_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Passed;
                string Letter = "A";

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    StatValue statValue = new StatValue(7.0D, 0.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 2.0D, 0.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 2.0D, 0.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));

                    statValue = new StatValue(0.0D, 0.0D, 0.0D, 1.0D, 0.0D);

                    mwqmSiteService.CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, statValue.P90, statValue.GeoMean, statValue.Median, statValue.PercOver43, statValue.PercOver260);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual(Letter, tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatMovingAverage_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = mwqmSiteService._TVItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    // NB-06-020-002 Bouctouche subsector
                    TVItemModel tvItemModelSubsector = mwqmSiteService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    List<TVItemModel> tvItemModelMWQMSiteList = mwqmSiteService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.MWQMSite);
                    Assert.IsTrue(tvItemModelMWQMSiteList.Count > 0);

                    List<MWQMSiteSampleFCModel> mwqmSiteSampleFCModelList = mwqmSiteService.CalculateMWQMSiteStatMovingAverage(tvItemModelMWQMSiteList[0].TVItemID, 30);
                    Assert.IsTrue(mwqmSiteSampleFCModelList.Count > 0);

                    mwqmSiteSampleFCModelList = mwqmSiteService.CalculateMWQMSiteStatMovingAverage(0, 30);
                    Assert.IsTrue(mwqmSiteSampleFCModelList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatOneDay1_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();
                    List<int> FCValueList = new List<int>() { 10, 20, 30, 40, 50, 60, 70 };
                    List<MWQMSample> mwqmSampleList = new List<MWQMSample>();

                    foreach (double fcValue in FCValueList)
                    {
                        mwqmSampleList.Add(new MWQMSample() { FecCol_MPN_100ml = (int)fcValue });
                    }

                    double Mean = (from c in mwqmSampleList
                                   orderby c.FecCol_MPN_100ml
                                   select (double)c.FecCol_MPN_100ml).Average();

                    mwqmSiteService.CalculateMWQMSiteStatOneDay(mwqmSampleList, tvlNew);
                    Assert.AreEqual("C -  - (" + string.Format("{0:F0}", Mean) + ")", tvlNew.TVText);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatOneDayLetterAndSubTVType_NoDepuration_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.NoDepuration;

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 182);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("F", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 163);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("E", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 145);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("D", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 126);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("C", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 107);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("B", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 89);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("A", tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatOneDayLetterAndSubTVType_Failed_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Failed;

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 76);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("F", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 64);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("E", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 52);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("D", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 39);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("C", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 27);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("B", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 15);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("A", tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CalculateMWQMSiteStatOneDayLetterAndSubTVType_Passed_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                TVTypeEnum tvTypeExpected = TVTypeEnum.Passed;

                using (TransactionScope ts = new TransactionScope())
                {
                    TVLocation tvlNew = new TVLocation();

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 12);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("F", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 10);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("E", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 8);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("D", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 5);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("C", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 3);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("B", tvlNew.TVText.Substring(0, 1));

                    mwqmSiteService.CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, 2);
                    Assert.AreEqual(tvTypeExpected, tvlNew.SubTVType);
                    Assert.AreEqual("A", tvlNew.TVText.Substring(0, 1));
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();

                    string retStr = mwqmSiteService.CreateTVText(mwqmSiteModelRet);
                    Assert.AreEqual(mwqmSiteModelRet.MWQMSiteTVText, retStr);

                    mwqmSiteModelRet.MWQMSiteTVText = "";
                    retStr = mwqmSiteService.CreateTVText(mwqmSiteModelRet);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_GetIsItSameObject_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    TVItemModel tvItemModelMWQMSite = mwqmSiteService._TVItemService.GetTVItemModelWithTVItemIDDB(mwqmSiteModelRet.MWQMSiteTVItemID);

                    bool retBool = mwqmSiteService.GetIsItSameObject(mwqmSiteModelRet, tvItemModelMWQMSite);
                    Assert.IsTrue(retBool);

                    tvItemModelMWQMSite.TVItemID = 0;

                    retBool = mwqmSiteService.GetIsItSameObject(mwqmSiteModelRet, tvItemModelMWQMSite);
                    Assert.IsFalse(retBool);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MWQMSiteModel mwqmSiteModelRet = mwqmSiteService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, mwqmSiteModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public helper

        #region Testing Methods public Post
        [TestMethod]
        public void MWQMSiteService_PostAddUpdateDeleteMWQMSiteDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    MWQMSiteModel mwqmSiteModelRet2 = UpdateMWQMSiteModel(mwqmSiteModelRet);

                    MWQMSiteModel mwqmSiteModelRet3 = mwqmSiteService.PostDeleteMWQMSiteDB(mwqmSiteModelRet2.MWQMSiteID);
                    Assert.AreEqual("", mwqmSiteModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostAddMWQMSiteDB_MWQMSiteModelOK_Test()
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
                        shimMWQMSiteService.MWQMSiteModelOKMWQMSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                        Assert.AreEqual(ErrorText, mwqmSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostAddMWQMSiteDB_IsContactOK_Error_Test()
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
                        shimMWQMSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                        Assert.AreEqual(ErrorText, mwqmSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostAddMWQMSiteDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        mwqmSiteModelRet = mwqmSiteService.PostAddMWQMSiteDB(mwqmSiteModelRet);
                        Assert.AreEqual(ErrorText, mwqmSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostAddMWQMSiteDB_FillMWQMSiteModel_ErrorTest()
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
                        shimMWQMSiteService.FillMWQMSiteMWQMSiteMWQMSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                        Assert.AreEqual(ErrorText, mwqmSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostAddMWQMSiteDB_DoAddChanges_ErrorTest()
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
                        shimMWQMSiteService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                        Assert.AreEqual(ErrorText, mwqmSiteModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostAddMWQMSiteDB_Add_Error_Test()
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
                        shimMWQMSiteService.FillMWQMSiteMWQMSiteMWQMSiteModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                        Assert.IsTrue(mwqmSiteModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostDeleteMWQMSiteDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSiteModel mwqmSiteModelRet2 = mwqmSiteService.PostDeleteMWQMSiteDB(mwqmSiteModelRet.MWQMSiteID);
                        Assert.AreEqual(ErrorText, mwqmSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostDeleteMWQMSiteDB_GetMWQMSiteWithMWQMSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMSiteService.GetMWQMSiteWithMWQMSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMSiteModel mwqmSiteModelRet2 = mwqmSiteService.PostDeleteMWQMSiteDB(mwqmSiteModelRet.MWQMSiteID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMSite), mwqmSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostDeleteMWQMSiteDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteModel mwqmSiteModelRet2 = mwqmSiteService.PostDeleteMWQMSiteDB(mwqmSiteModelRet.MWQMSiteID);
                        Assert.AreEqual(ErrorText, mwqmSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostUpdateMWQMSiteDB_MWQMSiteModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteService.MWQMSiteModelOKMWQMSiteModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteModel mwqmSiteModelRet2 = UpdateMWQMSiteModel(mwqmSiteModelRet);
                        Assert.AreEqual(ErrorText, mwqmSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostUpdateMWQMSiteDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSiteModel mwqmSiteModelRet2 = UpdateMWQMSiteModel(mwqmSiteModelRet);
                        Assert.AreEqual(ErrorText, mwqmSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostUpdateMWQMSiteDB_GetMWQMSiteWithMWQMSiteIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual("", mwqmSiteModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMSiteService.GetMWQMSiteWithMWQMSiteIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMSiteModel mwqmSiteModelRet2 = UpdateMWQMSiteModel(mwqmSiteModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSite), mwqmSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostUpdateMWQMSiteDB_FillMWQMSiteModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteService.FillMWQMSiteMWQMSiteMWQMSiteModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteModel mwqmSiteModelRet2 = UpdateMWQMSiteModel(mwqmSiteModelRet);
                        Assert.AreEqual(ErrorText, mwqmSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostUpdateMWQMSiteDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteModel mwqmSiteModelRet2 = UpdateMWQMSiteModel(mwqmSiteModelRet);
                        Assert.AreEqual(ErrorText, mwqmSiteModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostAddMWQMSiteDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SetupTest(contactModelListBad[0], culture);

                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mwqmSiteModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteService_PostAddMWQMSiteDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SetupTest(contactModelListGood[2], culture);

                    MWQMSiteModel mwqmSiteModelRet = AddMWQMSiteModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mwqmSiteModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public Post

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Function
        public MWQMSiteModel AddMWQMSiteModel()
        {
            TVItemModel tvItemModelSubsector = randomService.RandomTVItem(TVTypeEnum.Subsector);
            Assert.IsNotNull(tvItemModelSubsector);

            string TVText = randomService.RandomString("MWQM Site ", 20);
            TVItemModel tvItemModelMWQMSite = mwqmSiteService._TVItemService.PostAddChildTVItemDB(tvItemModelSubsector.TVItemID, TVText, TVTypeEnum.MWQMSite);
            if (!string.IsNullOrWhiteSpace(tvItemModelMWQMSite.Error))
            {
                return new MWQMSiteModel() { Error = tvItemModelMWQMSite.Error };
            }

            mwqmSiteModelNew.MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID;
            FillMWQMSiteModel(mwqmSiteModelNew);

            MWQMSiteModel mwqmSiteModelRet = mwqmSiteService.PostAddMWQMSiteDB(mwqmSiteModelNew);
            if (!string.IsNullOrWhiteSpace(mwqmSiteModelRet.Error))
            {
                return mwqmSiteModelRet;
            }

            CompareMWQMSiteModels(mwqmSiteModelNew, mwqmSiteModelRet);

            return mwqmSiteModelRet;

        }
        public MWQMSiteModel UpdateMWQMSiteModel(MWQMSiteModel mwqmSiteModel)
        {
            FillMWQMSiteModel(mwqmSiteModel);

            MWQMSiteModel mwqmSiteModelRet2 = mwqmSiteService.PostUpdateMWQMSiteDB(mwqmSiteModel);
            if (!string.IsNullOrWhiteSpace(mwqmSiteModelRet2.Error))
            {
                return mwqmSiteModelRet2;
            }

            CompareMWQMSiteModels(mwqmSiteModel, mwqmSiteModelRet2);

            return mwqmSiteModelRet2;
        }
        private void CompareMWQMSiteModels(MWQMSiteModel mwqmSiteModelNew, MWQMSiteModel mwqmSiteModelRet)
        {
            Assert.AreEqual(mwqmSiteModelNew.MWQMSiteTVItemID, mwqmSiteModelRet.MWQMSiteTVItemID);
            Assert.AreEqual(mwqmSiteModelNew.MWQMSiteNumber, mwqmSiteModelRet.MWQMSiteNumber);
            Assert.AreEqual(mwqmSiteModelNew.Ordinal, mwqmSiteModelRet.Ordinal);

            foreach (LanguageEnum Lang in mwqmSiteService.LanguageListAllowable)
            {
                TVItemLanguageModel tvItemLanguageModel = mwqmSiteService._TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(mwqmSiteModelRet.MWQMSiteTVItemID, Lang);
                Assert.AreEqual("", tvItemLanguageModel.Error);

                if (Lang == mwqmSiteService.LanguageRequest)
                {
                    Assert.AreEqual(mwqmSiteModelRet.MWQMSiteTVText, tvItemLanguageModel.TVText);
                }
            }
        }
        private void FillMWQMSiteModel(MWQMSiteModel mwqmSiteModel)
        {
            mwqmSiteModel.MWQMSiteTVItemID = mwqmSiteModel.MWQMSiteTVItemID;
            mwqmSiteModel.MWQMSiteTVText = randomService.RandomString("MWQMSite", 20);
            mwqmSiteModel.MWQMSiteNumber = randomService.RandomString("SN", 8);
            mwqmSiteModel.MWQMSiteDescription = randomService.RandomString("", 40);
            mwqmSiteModel.Ordinal = randomService.RandomInt(0, 100);

            Assert.IsTrue(mwqmSiteModel.MWQMSiteTVItemID != 0);
            Assert.IsTrue(mwqmSiteModel.MWQMSiteTVText.Length == 20);
            Assert.IsTrue(mwqmSiteModel.MWQMSiteNumber.Length == 8);
            Assert.IsTrue(mwqmSiteModel.MWQMSiteDescription.Length == 40);
            Assert.IsTrue(mwqmSiteModel.Ordinal >= 0 && mwqmSiteModel.Ordinal <= 100);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mwqmSiteService = new MWQMSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmSiteModelNew = new MWQMSiteModel();
            mwqmSite = new MWQMSite();
        }
        private void SetupShim()
        {
            shimMWQMSiteService = new ShimMWQMSiteService(mwqmSiteService);
            shimTVItemService = new ShimTVItemService(mwqmSiteService._TVItemService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(mwqmSiteService._TVItemService._TVItemLanguageService);
        }
        #endregion Functions private
    }

    public class StatValue
    {
        public StatValue(double P90, double GeoMean, double Median, double PercOver43, double PercOver260)
        {
            this.P90 = P90;
            this.GeoMean = GeoMean;
            this.Median = Median;
            this.PercOver43 = PercOver43;
            this.PercOver260 = PercOver260;
        }
        public double P90 { get; set; }
        public double GeoMean { get; set; }
        public double Median { get; set; }
        public double PercOver43 { get; set; }
        public double PercOver260 { get; set; }
    }

}

