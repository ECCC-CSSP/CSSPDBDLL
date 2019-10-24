using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPDBDLL.Tests.SetupInfo;
using CSSPDBDLL.Models;
using System.Security.Principal;
using CSSPDBDLL.Services;
using CSSPDBDLL.Services.Resources;
using System.Linq;
using System.Transactions;
using CSSPDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;
using System.Web.Mvc;
using CSSPDBDLL;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MWQMSubsectorServiceTest
    /// </summary>
    [TestClass]
    public class MWQMSubsectorServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MWQMSubsector";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MWQMSubsectorService mwqmSubsectorService { get; set; }
        private MWQMSubsectorLanguageService mwqmSubsectorLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MWQMSubsectorModel mwqmSubsectorModelNew { get; set; }
        private MWQMSubsector mwqmSubsector { get; set; }
        private ShimMWQMSubsectorService shimMWQMSubsectorService { get; set; }
        private ShimMWQMSubsectorLanguageService shimMWQMSubsectorLanguageService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test subsector.
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
        public MWQMSubsectorServiceTest()
        {
            setupData = new SetupData();
        }
        #endregion Constructors

        #region Initialize and Cleanup
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to subsector code before subsectorning the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to subsector code after all tests in a class have subsector
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to subsector code before subsectorning each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to subsector code after each test has subsector
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion Initialize and Cleanup

        #region Testing Methods public
        [TestMethod]
        public void MWQMSubsectorService_GetMWQMSubsectorHydrometricSitesDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MWQMSubsectorTVItemID = 635; // bouctouche harbour
                    float Radius_m = 100000;

                    MWQMSubsectorHydrometricSites mwqmSubsectorHydrometricSites = mwqmSubsectorService.GetMWQMSubsectorHydrometricSitesDB(MWQMSubsectorTVItemID, Radius_m);
                    Assert.AreEqual(69, mwqmSubsectorHydrometricSites.HydrometricSiteModelUsedAndWithinDistanceModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(mwqmSubsectorService);
                Assert.IsNotNull(mwqmSubsectorService._MWQMSubsectorLanguageService);
                Assert.IsNotNull(mwqmSubsectorService.db);
                Assert.IsNotNull(mwqmSubsectorService.LanguageRequest);
                Assert.IsNotNull(mwqmSubsectorService.User);
                Assert.AreEqual(user.Identity.Name, mwqmSubsectorService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mwqmSubsectorService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_MWQMSubsectorModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModel = AddMWQMSubsectorModel();
                    Assert.AreEqual("", mwqmSubsectorModel.Error);

                    #region Good
                    mwqmSubsectorModelNew.MWQMSubsectorTVItemID = mwqmSubsectorModel.MWQMSubsectorTVItemID;
                    FillMWQMSubsectorModel(mwqmSubsectorModelNew);

                    string retStr = mwqmSubsectorService.MWQMSubsectorModelOK(mwqmSubsectorModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region MWQMSubsectorTVItemID
                    FillMWQMSubsectorModel(mwqmSubsectorModelNew);
                    mwqmSubsectorModelNew.MWQMSubsectorTVItemID = 0;

                    retStr = mwqmSubsectorService.MWQMSubsectorModelOK(mwqmSubsectorModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSubsectorTVItemID), retStr);

                    mwqmSubsectorModelNew.MWQMSubsectorTVItemID = mwqmSubsectorModel.MWQMSubsectorTVItemID;
                    FillMWQMSubsectorModel(mwqmSubsectorModelNew);

                    retStr = mwqmSubsectorService.MWQMSubsectorModelOK(mwqmSubsectorModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion MWQMSubsectorTVItemID

                    #region SubsectorHistoricKey
                    FillMWQMSubsectorModel(mwqmSubsectorModelNew);
                    int Max = 20;
                    mwqmSubsectorModelNew.SubsectorHistoricKey = randomService.RandomString("", 0);

                    retStr = mwqmSubsectorService.MWQMSubsectorModelOK(mwqmSubsectorModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorHistoricKey), retStr);

                    FillMWQMSubsectorModel(mwqmSubsectorModelNew);
                    mwqmSubsectorModelNew.SubsectorHistoricKey = randomService.RandomString("", Max + 1);

                    retStr = mwqmSubsectorService.MWQMSubsectorModelOK(mwqmSubsectorModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.SubsectorHistoricKey, Max), retStr);

                    FillMWQMSubsectorModel(mwqmSubsectorModelNew);
                    mwqmSubsectorModelNew.SubsectorHistoricKey = randomService.RandomString("", Max - 1);

                    retStr = mwqmSubsectorService.MWQMSubsectorModelOK(mwqmSubsectorModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSubsectorModel(mwqmSubsectorModelNew);
                    mwqmSubsectorModelNew.SubsectorHistoricKey = randomService.RandomString("", Max);

                    retStr = mwqmSubsectorService.MWQMSubsectorModelOK(mwqmSubsectorModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion SubsectorHistoricKey

                    #region SubsectorDesc
                    FillMWQMSubsectorModel(mwqmSubsectorModelNew);
                    Max = 250;
                    mwqmSubsectorModelNew.SubsectorDesc = randomService.RandomString("", 0);

                    retStr = mwqmSubsectorService.MWQMSubsectorModelOK(mwqmSubsectorModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorDesc), retStr);

                    FillMWQMSubsectorModel(mwqmSubsectorModelNew);
                    mwqmSubsectorModelNew.SubsectorDesc = randomService.RandomString("", Max + 1);

                    retStr = mwqmSubsectorService.MWQMSubsectorModelOK(mwqmSubsectorModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.SubsectorDesc, Max), retStr);

                    FillMWQMSubsectorModel(mwqmSubsectorModelNew);
                    mwqmSubsectorModelNew.SubsectorDesc = randomService.RandomString("", Max - 1);

                    retStr = mwqmSubsectorService.MWQMSubsectorModelOK(mwqmSubsectorModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMSubsectorModel(mwqmSubsectorModelNew);
                    mwqmSubsectorModelNew.SubsectorDesc = randomService.RandomString("", Max);

                    retStr = mwqmSubsectorService.MWQMSubsectorModelOK(mwqmSubsectorModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion SubsectorDesc
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_FillMWQMSubsector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelSubsector = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    mwqmSubsectorModelNew.MWQMSubsectorTVItemID = tvItemModelSubsector.TVItemID;
                    FillMWQMSubsectorModel(mwqmSubsectorModelNew);

                    ContactOK contactOK = mwqmSubsectorService.IsContactOK();

                    string retStr = mwqmSubsectorService.FillMWQMSubsector(mwqmSubsector, mwqmSubsectorModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mwqmSubsector.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mwqmSubsectorService.FillMWQMSubsector(mwqmSubsector, mwqmSubsectorModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, mwqmSubsector.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_FillClimateSiteUseStartEndYears_All_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> YearsTextList = new List<string>()
                    {
                        "1999", "1999-2001", "1999,2000,2013", "1989-2002,2004-2013", "1999,2000-2003,2006-2010,2013-",
                        "1999,2000-2003,2004,2006-2010,2013-",
                        "1999,2000-2003,2004,2006-2010, 2013-",
                        "1999,20 00-2003,200 4,2006-2010, 2013-",
                        "1999,20 00-2003 ,20 04,2006-2 010, 2013-",
                    };
                    List<List<ClimateSiteUseStartEndYears>> ExpectedResList = new List<List<ClimateSiteUseStartEndYears>>()
                    {
                         new List<ClimateSiteUseStartEndYears>()
                         {
                             new ClimateSiteUseStartEndYears() { StartYear = 1999, EndYear = 1999 }
                         },
                         new List<ClimateSiteUseStartEndYears>()
                         {
                             new ClimateSiteUseStartEndYears() { StartYear = 1999, EndYear = 2001 }
                         },
                         new List<ClimateSiteUseStartEndYears>()
                         {
                             new ClimateSiteUseStartEndYears() { StartYear = 1999, EndYear = 1999 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2000, EndYear = 2000 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2013, EndYear = 2013 }
                         },
                         new List<ClimateSiteUseStartEndYears>()
                         {
                             new ClimateSiteUseStartEndYears() { StartYear = 1989, EndYear = 2002 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2004, EndYear = 2013 }
                         },
                         new List<ClimateSiteUseStartEndYears>()
                         {
                             new ClimateSiteUseStartEndYears() { StartYear = 1999, EndYear = 1999 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2000, EndYear = 2003 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2006, EndYear = 2010 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2013, EndYear = null }
                         },
                         new List<ClimateSiteUseStartEndYears>()
                         {
                             new ClimateSiteUseStartEndYears() { StartYear = 1999, EndYear = 1999 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2000, EndYear = 2003 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2004, EndYear = 2004 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2006, EndYear = 2010 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2013, EndYear = null }
                         },
                         new List<ClimateSiteUseStartEndYears>()
                         {
                             new ClimateSiteUseStartEndYears() { StartYear = 1999, EndYear = 1999 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2000, EndYear = 2003 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2004, EndYear = 2004 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2006, EndYear = 2010 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2013, EndYear = null }
                         },
                         new List<ClimateSiteUseStartEndYears>()
                         {
                             new ClimateSiteUseStartEndYears() { StartYear = 1999, EndYear = 1999 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2000, EndYear = 2003 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2004, EndYear = 2004 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2006, EndYear = 2010 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2013, EndYear = null }
                         },
                         new List<ClimateSiteUseStartEndYears>()
                         {
                             new ClimateSiteUseStartEndYears() { StartYear = 1999, EndYear = 1999 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2000, EndYear = 2003 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2004, EndYear = 2004 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2006, EndYear = 2010 },
                             new ClimateSiteUseStartEndYears() { StartYear = 2013, EndYear = null }
                         },
                    };
                    for (int i = 0, count = YearsTextList.Count(); i < count; i++)
                    {
                        ClimateSiteTVItemIDYearsText climateSiteTVItemIDYearsText = new ClimateSiteTVItemIDYearsText()
                        {
                            ClimateSiteTVItemID = 8,
                            ClimateSiteUseStartEndYearList = new List<ClimateSiteUseStartEndYears>(),
                            YearsText = YearsTextList[i]
                        };
                        string retStr = mwqmSubsectorService.FillClimateSiteUseStartEndYears(climateSiteTVItemIDYearsText);
                        Assert.AreEqual("", retStr);

                        YearsTextList[i] = YearsTextList[i].Trim();
                        YearsTextList[i] = YearsTextList[i].Replace(" ", "");
                        Assert.AreEqual(YearsTextList[i], climateSiteTVItemIDYearsText.YearsText);
                        Assert.AreEqual(8, climateSiteTVItemIDYearsText.ClimateSiteTVItemID);
                        for (int j = 0, count2 = ExpectedResList[i].Count(); j < count2; j++)
                        {
                            Assert.AreEqual(climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[j].StartYear, ExpectedResList[i].Skip(j).Take(1).FirstOrDefault().StartYear);
                            Assert.AreEqual(climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[j].EndYear, ExpectedResList[i].Skip(j).Take(1).FirstOrDefault().EndYear);
                        }
                    }
                }
                break;
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_FillClimateSiteUseStartEndYears_All_Errors_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> YearsTextList = new List<string>()
                    {
                      "2001,a","199", "1999-200", "1999,,2000,2013", "1989-201,2004-2013", "199,2001", "1999-200,2003", "19999-2000",
                      "1999-20000", "-2000", "1999--2000", "1999-,-2000", "2000-1999", "2000,1999", "1998,1999,1997,2000",
                       "2001-1999,1999-2000", ""
                    };
                    List<string> ExpectedResList = new List<String>()
                    {
                        string.Format(ServiceRes._NotAllowedIn_, "a", YearsTextList[0]),
                        string.Format(ServiceRes._Of_IsNotAYear, "199", YearsTextList[1]),
                        string.Format(ServiceRes._Of_IsNotAYear, "200", YearsTextList[2]),
                        string.Format(ServiceRes._Of_IsNotAYear, "", YearsTextList[3]),
                        string.Format(ServiceRes._Of_IsNotAYear, "201", YearsTextList[4]),
                        string.Format(ServiceRes._Of_IsNotAYear, "199", YearsTextList[5]),
                        string.Format(ServiceRes._Of_IsNotAYear, "200", YearsTextList[6]),
                        string.Format(ServiceRes._Of_IsNotAYear, "19999", YearsTextList[7]),
                        string.Format(ServiceRes._Of_IsNotAYear, "20000", YearsTextList[8]),
                        string.Format(ServiceRes._Of_IsNotAYear, "", YearsTextList[9]),
                        string.Format(ServiceRes._Of_IsNotAYear, "", YearsTextList[10]),
                        string.Format(ServiceRes._Of_IsNotAYear, "", YearsTextList[11]),
                        string.Format(ServiceRes.AllYearsOf_ShouldBeAscending, YearsTextList[12]),
                        string.Format(ServiceRes.AllYearsOf_ShouldBeAscending, YearsTextList[13]),
                        string.Format(ServiceRes.AllYearsOf_ShouldBeAscending, YearsTextList[14]),
                        string.Format(ServiceRes.AllYearsOf_ShouldBeAscending, YearsTextList[15]),
                        string.Format(ServiceRes._Of_IsNotAYear, "", YearsTextList[16]),
                    };
                    for (int i = 0, count = YearsTextList.Count(); i < count; i++)
                    {
                        ClimateSiteTVItemIDYearsText climateSiteTVItemIDYearsText = new ClimateSiteTVItemIDYearsText()
                        {
                            ClimateSiteTVItemID = 8,
                            ClimateSiteUseStartEndYearList = new List<ClimateSiteUseStartEndYears>(),
                            YearsText = YearsTextList[i]
                        };
                        string retStr = mwqmSubsectorService.FillClimateSiteUseStartEndYears(climateSiteTVItemIDYearsText);
                        Assert.AreEqual(ExpectedResList[i], retStr);
                    }
                }
                break;
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_CheckPercentCompletedDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // todo 
                    int retInt = mwqmSubsectorService.CheckPercentCompletedDB(999);
                    Assert.AreEqual(1000, retInt);
                }
                break;
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_ClimateSiteGetDataForRunsOfYearDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int SubsectorTVItemID = 717; // Bouctouche harbor subsector

                    // todo 
                    AppTaskModel appTaskModelRet = mwqmSubsectorService.ClimateSiteGetDataForRunsOfYearDB(SubsectorTVItemID, 2019);
                    Assert.AreEqual("", appTaskModelRet.Error);
                }
                break;
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_ClimateSiteSetDataToUseByAverageOrPriorityDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int SubsectorTVItemID = 717; // Deer Island

                    // todo 
                    MWQMSubsectorModel mwqmSubsectorModel = mwqmSubsectorService.ClimateSiteSetDataToUseByAverageOrPriorityDB(SubsectorTVItemID, 2019, "Priority");
                    Assert.AreEqual("", mwqmSubsectorModel.Error);
                }
                break;
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_ClimateSitePrioritiesSaveDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int SubsectorTVItemID = 635; // Bouctouche harbor subsector

                    FormCollection fc = new FormCollection();
                    fc.Add("SubsectorTVItemID", SubsectorTVItemID.ToString());
                    fc.Add("ClimateSiteUseOfSiteOrdinalList[0][UseOfSiteID]", "need a UseOfSiteID number"); // will not work
                    fc.Add("ClimateSiteUseOfSiteOrdinalList[0][UseOfSiteID]", "need a UseOfSiteID number"); // will not work)

                    // todo 
                    MWQMSubsectorModel mwqmSubsectorModel = mwqmSubsectorService.ClimateSitePrioritiesSaveDB(fc);
                    Assert.AreEqual("", mwqmSubsectorModel.Error);
                }
                break;
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_ClimateSitePrecipitationEnteredSaveDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int SubsectorTVItemID = 635; // Bouctouche harbor subsector
                    MWQMRunModel mwqmRunModel = mwqmSubsectorService._MWQMRunService.GetMWQMRunModelListWithSubsectorTVItemIDDB(SubsectorTVItemID).FirstOrDefault();
                    Assert.AreEqual("", mwqmRunModel.Error);

                    int MWQMRunTVItemID = mwqmRunModel.MWQMRunTVItemID; 

                    FormCollection fc = new FormCollection();
                    fc.Add("SubsectorTVItemID", SubsectorTVItemID.ToString());
                    fc.Add("MWQMRunTVItemID", SubsectorTVItemID.ToString());
                    fc.Add("RainDay0_mm]", "1000");
                    fc.Add("RainDay1_mm]", "1000");
                    fc.Add("RainDay2_mm]", "1000");
                    fc.Add("RainDay3_mm]", "1000");
                    fc.Add("RainDay4_mm]", "1000");
                    fc.Add("RainDay5_mm]", "1000");
                    fc.Add("RainDay6_mm]", "1000");
                    fc.Add("RainDay7_mm]", "1000");
                    fc.Add("RainDay8_mm]", "1000");
                    fc.Add("RainDay9_mm]", "1000");
                    fc.Add("RainDay10_mm]", "1000");

                    // todo 
                    MWQMSubsectorModel mwqmSubsectorModel = mwqmSubsectorService.ClimateSitePrecipitationEnteredSaveDB(fc);
                    Assert.AreEqual("", mwqmSubsectorModel.Error);
                }
                break;
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_ClimateSitesToUseForSubsectorVerifyAndSaveDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int SubsectorTVItemID = 635; // bouctouche harbour subsector
                    int ClimateSiteTVItemID = 229528; // BUCTOUCHE CDA CS(8100593)
                    FormCollection fc = new FormCollection();
                    fc.Add("SubsectorTVItemID", SubsectorTVItemID.ToString());
                    fc.Add("ClimateSiteYearsList[0][ClimateSiteTVItemID]", ClimateSiteTVItemID.ToString());
                    fc.Add("ClimateSiteYearsList[0][YearsText]", "1999,2003-2005,2010-2013");

                    MWQMSubsectorModel mwqmSubsectorModel = mwqmSubsectorService.ClimateSitesToUseForSubsectorVerifyAndSaveDB(fc);
                    Assert.AreEqual("", mwqmSubsectorModel.Error);

                    List<UseOfSite> useOfSiteList = (from c in mwqmSubsectorService.db.UseOfSites
                                                     where c.SubsectorTVItemID == SubsectorTVItemID
                                                     && c.SiteTVItemID == ClimateSiteTVItemID
                                                     orderby c.StartYear
                                                     select c).ToList();

                    Assert.AreEqual(3, useOfSiteList.Count());

                    // first
                    Assert.AreEqual(SubsectorTVItemID, useOfSiteList[0].SubsectorTVItemID);
                    Assert.AreEqual(ClimateSiteTVItemID, useOfSiteList[0].SiteTVItemID);
                    Assert.AreEqual(1999, useOfSiteList[0].StartYear);
                    Assert.AreEqual(1999, useOfSiteList[0].EndYear);

                    // second
                    Assert.AreEqual(SubsectorTVItemID, useOfSiteList[1].SubsectorTVItemID);
                    Assert.AreEqual(ClimateSiteTVItemID, useOfSiteList[1].SiteTVItemID);
                    Assert.AreEqual(2003, useOfSiteList[1].StartYear);
                    Assert.AreEqual(2005, useOfSiteList[1].EndYear);

                    // first
                    Assert.AreEqual(SubsectorTVItemID, useOfSiteList[2].SubsectorTVItemID);
                    Assert.AreEqual(ClimateSiteTVItemID, useOfSiteList[2].SiteTVItemID);
                    Assert.AreEqual(2010, useOfSiteList[2].StartYear);
                    Assert.AreEqual(2013, useOfSiteList[2].EndYear);
                }
                break;
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_ClimateSitesToUseForSubsectorVerifyAndSaveDB2_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int SubsectorTVItemID = 635; // bouctouche harbour subsector
                    int ClimateSiteTVItemID = 229528; // BUCTOUCHE CDA CS(8100593)
                    int ClimateSiteTVItemID2 = 229526; // BUCTOUCHE
                    FormCollection fc = new FormCollection();
                    fc.Add("SubsectorTVItemID", SubsectorTVItemID.ToString());
                    fc.Add("ClimateSiteYearsList[0][ClimateSiteTVItemID]", ClimateSiteTVItemID.ToString());
                    fc.Add("ClimateSiteYearsList[0][YearsText]", "1999,2003-2005,2010-2013");
                    fc.Add("ClimateSiteYearsList[1][ClimateSiteTVItemID]", ClimateSiteTVItemID2.ToString());
                    fc.Add("ClimateSiteYearsList[1][YearsText]", "1999,2001,2003-2005,2010-2013,2015-");

                    MWQMSubsectorModel mwqmSubsectorModel = mwqmSubsectorService.ClimateSitesToUseForSubsectorVerifyAndSaveDB(fc);
                    Assert.AreEqual("", mwqmSubsectorModel.Error);

                    List<UseOfSite> useOfSiteList = (from c in mwqmSubsectorService.db.UseOfSites
                                                     where c.SubsectorTVItemID == SubsectorTVItemID
                                                     && c.SiteTVItemID == ClimateSiteTVItemID
                                                     && c.TVType == (int)TVTypeEnum.ClimateSite
                                                     orderby c.StartYear
                                                     select c).ToList();

                    Assert.AreEqual(3, useOfSiteList.Count());

                    // 0
                    Assert.AreEqual(SubsectorTVItemID, useOfSiteList[0].SubsectorTVItemID);
                    Assert.AreEqual(ClimateSiteTVItemID, useOfSiteList[0].SiteTVItemID);
                    Assert.AreEqual(1999, useOfSiteList[0].StartYear);
                    Assert.AreEqual(1999, useOfSiteList[0].EndYear);

                    // 1
                    Assert.AreEqual(SubsectorTVItemID, useOfSiteList[1].SubsectorTVItemID);
                    Assert.AreEqual(ClimateSiteTVItemID, useOfSiteList[1].SiteTVItemID);
                    Assert.AreEqual(2003, useOfSiteList[1].StartYear);
                    Assert.AreEqual(2005, useOfSiteList[1].EndYear);

                    // 2
                    Assert.AreEqual(SubsectorTVItemID, useOfSiteList[2].SubsectorTVItemID);
                    Assert.AreEqual(ClimateSiteTVItemID, useOfSiteList[2].SiteTVItemID);
                    Assert.AreEqual(2010, useOfSiteList[2].StartYear);
                    Assert.AreEqual(2013, useOfSiteList[2].EndYear);

                    List<UseOfSite> useOfSiteList2 = (from c in mwqmSubsectorService.db.UseOfSites
                                                      where c.SubsectorTVItemID == SubsectorTVItemID
                                                      && c.SiteTVItemID == ClimateSiteTVItemID2
                                                     && c.TVType == (int)TVTypeEnum.ClimateSite
                                                      orderby c.StartYear
                                                      select c).ToList();

                    Assert.AreEqual(5, useOfSiteList2.Count());

                    // 0
                    Assert.AreEqual(SubsectorTVItemID, useOfSiteList2[0].SubsectorTVItemID);
                    Assert.AreEqual(ClimateSiteTVItemID2, useOfSiteList2[0].SiteTVItemID);
                    Assert.AreEqual(1999, useOfSiteList2[0].StartYear);
                    Assert.AreEqual(1999, useOfSiteList2[0].EndYear);

                    // 1
                    Assert.AreEqual(SubsectorTVItemID, useOfSiteList2[1].SubsectorTVItemID);
                    Assert.AreEqual(ClimateSiteTVItemID2, useOfSiteList2[1].SiteTVItemID);
                    Assert.AreEqual(2001, useOfSiteList2[1].StartYear);
                    Assert.AreEqual(2001, useOfSiteList2[1].EndYear);

                    // 2
                    Assert.AreEqual(SubsectorTVItemID, useOfSiteList2[2].SubsectorTVItemID);
                    Assert.AreEqual(ClimateSiteTVItemID2, useOfSiteList2[2].SiteTVItemID);
                    Assert.AreEqual(2003, useOfSiteList2[2].StartYear);
                    Assert.AreEqual(2005, useOfSiteList2[2].EndYear);

                    // 3
                    Assert.AreEqual(SubsectorTVItemID, useOfSiteList2[3].SubsectorTVItemID);
                    Assert.AreEqual(ClimateSiteTVItemID2, useOfSiteList2[3].SiteTVItemID);
                    Assert.AreEqual(2010, useOfSiteList2[3].StartYear);
                    Assert.AreEqual(2013, useOfSiteList2[3].EndYear);

                    // 4
                    Assert.AreEqual(SubsectorTVItemID, useOfSiteList2[4].SubsectorTVItemID);
                    Assert.AreEqual(ClimateSiteTVItemID2, useOfSiteList2[4].SiteTVItemID);
                    Assert.AreEqual(2015, useOfSiteList2[4].StartYear);
                    Assert.AreEqual(null, useOfSiteList2[4].EndYear);

                }
                break;
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_GetAdjacentSubsectors_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVItemModel> tvItemModelList = mwqmSubsectorService.GetAdjacentSubsectors(635 /* bouctouche harbour subsector*/, 2);
                    Assert.AreEqual(4, tvItemModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_GetMWQMSubsectorAnalysisModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorAnalysisModel mwqmSubsectorAnalysisModel = mwqmSubsectorService.GetMWQMSubsectorAnalysisModel(635 /* bouctouche harbour subsector*/);
                    Assert.AreEqual("", mwqmSubsectorAnalysisModel.MWQMSubsectorModel.Error);
                    Assert.IsTrue(mwqmSubsectorAnalysisModel.MWQMSiteAnalysisModelList.Count > 0);
                    Assert.IsTrue(mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList.Count > 0);
                    Assert.IsTrue(mwqmSubsectorAnalysisModel.MWQMSampleAnalysisModelList.Count > 0);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_GetMWQMSubsectorModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    int mwqmSubsectorCount = mwqmSubsectorService.GetMWQMSubsectorModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, mwqmSubsectorCount);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_GetAllMWQMSubsectorModelDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    List<MWQMSubsectorModel> mwqmSubsectorModelList = mwqmSubsectorService.GetAllMWQMSubsectorModelDB();
                    Assert.AreEqual(testDBService.Count + 1, mwqmSubsectorModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_GetMWQMSubsectorModelListWithMWQMSubsectorTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    MWQMSubsectorModel mwqmSubsectorModelRet2 = mwqmSubsectorService.GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(mwqmSubsectorModelRet.MWQMSubsectorTVItemID);
                    Assert.AreEqual("", mwqmSubsectorModelRet2.Error);

                    int MWQMSubsectorTVItemID = 0;
                    MWQMSubsectorModel mwqmSubsectorModelRet3 = mwqmSubsectorService.GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(MWQMSubsectorTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSubsector, ServiceRes.MWQMSubsectorTVItemID, MWQMSubsectorTVItemID), mwqmSubsectorModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_GetMWQMSubsectorModelWithMWQMSubsectorIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    MWQMSubsectorModel mwqmSubsectorModelRet2 = mwqmSubsectorService.GetMWQMSubsectorModelWithMWQMSubsectorIDDB(mwqmSubsectorModelRet.MWQMSubsectorID);
                    Assert.AreEqual(mwqmSubsectorModelRet.MWQMSubsectorID, mwqmSubsectorModelRet2.MWQMSubsectorID);

                    int MWQMSubsectorID = 0;
                    mwqmSubsectorModelRet2 = mwqmSubsectorService.GetMWQMSubsectorModelWithMWQMSubsectorIDDB(MWQMSubsectorID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSubsector, ServiceRes.MWQMSubsectorID, MWQMSubsectorID), mwqmSubsectorModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_GetMWQMSubsectorModelWithSubsectorHistoricKeyDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    MWQMSubsectorModel mwqmSubsectorModelRet2 = mwqmSubsectorService.GetMWQMSubsectorModelWithSubsectorHistoricKeyDB(mwqmSubsectorModelRet.SubsectorHistoricKey);
                    Assert.AreEqual(mwqmSubsectorModelRet.MWQMSubsectorID, mwqmSubsectorModelRet2.MWQMSubsectorID);

                    string SubsectorHistoricKey = "WillNotExist";
                    mwqmSubsectorModelRet2 = mwqmSubsectorService.GetMWQMSubsectorModelWithSubsectorHistoricKeyDB(SubsectorHistoricKey);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSubsector, ServiceRes.SubsectorHistoricKey, SubsectorHistoricKey), mwqmSubsectorModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_GetMWQMSubsectorWithMWQMSubsectorIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    MWQMSubsector mwqmSubsectorRet = mwqmSubsectorService.GetMWQMSubsectorWithMWQMSubsectorIDDB(mwqmSubsectorModelRet.MWQMSubsectorID);
                    Assert.AreEqual(mwqmSubsectorModelRet.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    int MWQMSubsectorID = 0;
                    MWQMSubsector mwqmSubsectorRet2 = mwqmSubsectorService.GetMWQMSubsectorWithMWQMSubsectorIDDB(MWQMSubsectorID);
                    Assert.IsNull(mwqmSubsectorRet2);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_GetMWQMSubsectorExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    MWQMSubsector mwqmSubsectorRet = mwqmSubsectorService.GetMWQMSubsectorExistDB(mwqmSubsectorModelRet);
                    Assert.AreEqual(mwqmSubsectorModelRet.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);

                    mwqmSubsectorModelRet.MWQMSubsectorTVItemID = 0;
                    DateTime dateTime = DateTime.Now;
                    MWQMSubsector mwqmSubsectorRet2 = mwqmSubsectorService.GetMWQMSubsectorExistDB(mwqmSubsectorModelRet);
                    Assert.IsNull(mwqmSubsectorRet2);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_GetMWQMSubsectorClimateSiteModelAndRainsDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int SubsectorTVItemID = 635; //  bouctouche harbour subsector
                    float Radius = 50000;
                    MWQMSubsectorClimateSites mwqmSubsectorClimateSites = mwqmSubsectorService.GetMWQMSubsectorClimateSitesDB(SubsectorTVItemID, Radius);
                    Assert.AreEqual(SubsectorTVItemID, mwqmSubsectorClimateSites.MWQMSubsectorWithLatLngModel.MWQMSubsectorTVItemID);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_GetMWQMSubsectorClimateSitesAndValuesForAParicularRunsDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int SubsectorTVItemID = 635; //  bouctouche harbour subsector

                    int MWQMRunTVItemID = (from c in mwqmSubsectorService.db.MWQMRuns
                                           where c.SubsectorTVItemID == SubsectorTVItemID
                                           orderby c.DateTime_Local descending
                                           select c.MWQMRunTVItemID).FirstOrDefault();

                    if (MWQMRunTVItemID == 0)
                    {
                        Assert.IsTrue(false);
                    }

                    List<ClimateSitesAndRains> climateSitesAndRainsList = mwqmSubsectorService.GetMWQMSubsectorClimateSitesAndValuesForAParicularRunsDB(SubsectorTVItemID, MWQMRunTVItemID);
                    Assert.IsTrue(climateSitesAndRainsList.Count > 0);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddUpdateDeleteMWQMSubsector_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    MWQMSubsectorModel mwqmSubsectorModelRet2 = UpdateMWQMSubsectorModel(mwqmSubsectorModelRet);

                    MWQMSubsectorModel mwqmSubsectorModelRet3 = mwqmSubsectorService.PostDeleteMWQMSubsectorDB(mwqmSubsectorModelRet2.MWQMSubsectorID);
                    Assert.AreEqual("", mwqmSubsectorModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddMWQMSubsectorDB_MWQMSubsectorModelOK_Error_Test()
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
                        shimMWQMSubsectorService.MWQMSubsectorModelOKMWQMSubsectorModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddMWQMSubsectorDB_IsContactOK_Error_Test()
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
                        shimMWQMSubsectorService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddMWQMSubsectorDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
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
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddMWQMSubsectorDB_GetMWQMSubsectorExistDB_Error_Test()
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
                        shimMWQMSubsectorService.GetMWQMSubsectorExistDBMWQMSubsectorModel = (a) =>
                        {
                            return new MWQMSubsector();
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMSubsector), mwqmSubsectorModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddMWQMSubsectorDB_FillMWQMSubsector_Error_Test()
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
                        shimMWQMSubsectorService.FillMWQMSubsectorMWQMSubsectorMWQMSubsectorModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddMWQMSubsectorDB_DoAddChanges_Error_Test()
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
                        shimMWQMSubsectorService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddMWQMSubsectorDB_Add_Error_Test()
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
                        shimMWQMSubsectorService.FillMWQMSubsectorMWQMSubsectorMWQMSubsectorModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();
                        Assert.IsTrue(mwqmSubsectorModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddMWQMSubsectorDB_PostAddMWQMSubsectorLanguageDB_Error_Test()
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
                        shimMWQMSubsectorLanguageService.PostAddMWQMSubsectorLanguageDBMWQMSubsectorLanguageModel = (a) =>
                        {
                            return new MWQMSubsectorLanguageModel() { Error = ErrorText };
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddMWQMSubsectorDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();
                    Assert.IsNotNull(mwqmSubsectorModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mwqmSubsectorModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddMWQMSubsectorDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();
                    Assert.IsNotNull(mwqmSubsectorModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mwqmSubsectorModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostDeleteMWQMSubsector_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet2 = mwqmSubsectorService.PostDeleteMWQMSubsectorDB(mwqmSubsectorModelRet.MWQMSubsectorID);
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostDeleteMWQMSubsector_GetMWQMSubsectorWithMWQMSubsectorIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMSubsectorService.GetMWQMSubsectorWithMWQMSubsectorIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet2 = mwqmSubsectorService.PostDeleteMWQMSubsectorDB(mwqmSubsectorModelRet.MWQMSubsectorID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMSubsector), mwqmSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostDeleteMWQMSubsector_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet2 = mwqmSubsectorService.PostDeleteMWQMSubsectorDB(mwqmSubsectorModelRet.MWQMSubsectorID);
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostUpdateMWQMSubsector_MWQMSubsectorModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorService.MWQMSubsectorModelOKMWQMSubsectorModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet2 = UpdateMWQMSubsectorModel(mwqmSubsectorModelRet);
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostUpdateMWQMSubsector_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet2 = UpdateMWQMSubsectorModel(mwqmSubsectorModelRet);
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostUpdateMWQMSubsector_GetMWQMSubsectorWithMWQMSubsectorIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMSubsectorService.GetMWQMSubsectorWithMWQMSubsectorIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet2 = UpdateMWQMSubsectorModel(mwqmSubsectorModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSubsector), mwqmSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostUpdateMWQMSubsector_FillMWQMSubsector_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorService.FillMWQMSubsectorMWQMSubsectorMWQMSubsectorModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet2 = UpdateMWQMSubsectorModel(mwqmSubsectorModelRet);
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostUpdateMWQMSubsector_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet2 = UpdateMWQMSubsectorModel(mwqmSubsectorModelRet);
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostUpdateMWQMSubsector_PostUpdateMWQMSubsectorLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSubsectorLanguageService.PostUpdateMWQMSubsectorLanguageDBMWQMSubsectorLanguageModel = (a) =>
                        {
                            return new MWQMSubsectorLanguageModel() { Error = ErrorText };
                        };

                        MWQMSubsectorModel mwqmSubsectorModelRet2 = UpdateMWQMSubsectorModel(mwqmSubsectorModelRet);
                        Assert.AreEqual(ErrorText, mwqmSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddMWQMSubsectorAndMWQMSubsectorLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mwqmSubsectorModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMSubsectorService_PostAddMWQMSubsectorAndMWQMSubsectorLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSubsectorModel mwqmSubsectorModelRet = AddMWQMSubsectorModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mwqmSubsectorModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public MWQMSubsectorModel AddMWQMSubsectorModel()
        {
            TVItemModel tvItemModelSubsector = randomService.RandomTVItem(TVTypeEnum.Subsector);

            Assert.AreEqual("", tvItemModelSubsector.Error);

            mwqmSubsectorModelNew.MWQMSubsectorTVItemID = tvItemModelSubsector.TVItemID;
            FillMWQMSubsectorModel(mwqmSubsectorModelNew);

            MWQMSubsectorModel mwqmSubsectorModelRet = mwqmSubsectorService.PostAddMWQMSubsectorDB(mwqmSubsectorModelNew);
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorModelRet.Error))
            {
                return mwqmSubsectorModelRet;
            }

            CompareMWQMSubsectorModels(mwqmSubsectorModelNew, mwqmSubsectorModelRet);

            return mwqmSubsectorModelRet;
        }
        public MWQMSubsectorModel UpdateMWQMSubsectorModel(MWQMSubsectorModel mwqmSubsectorModel)
        {
            FillMWQMSubsectorModel(mwqmSubsectorModel);

            MWQMSubsectorModel mwqmSubsectorModelRet2 = mwqmSubsectorService.PostUpdateMWQMSubsectorDB(mwqmSubsectorModel);
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorModelRet2.Error))
            {
                return mwqmSubsectorModelRet2;
            }

            CompareMWQMSubsectorModels(mwqmSubsectorModel, mwqmSubsectorModelRet2);

            return mwqmSubsectorModelRet2;
        }
        private void CompareMWQMSubsectorModels(MWQMSubsectorModel mwqmSubsectorModelNew, MWQMSubsectorModel mwqmSubsectorModelRet)
        {
            Assert.AreEqual(mwqmSubsectorModelNew.MWQMSubsectorTVItemID, mwqmSubsectorModelRet.MWQMSubsectorTVItemID);
            Assert.AreEqual(mwqmSubsectorModelNew.SubsectorHistoricKey, mwqmSubsectorModelRet.SubsectorHistoricKey);

            foreach (LanguageEnum Lang in mwqmSubsectorService.LanguageListAllowable)
            {
                MWQMSubsectorLanguageModel mwqmSubsectorLanguageModel = mwqmSubsectorService._MWQMSubsectorLanguageService.GetMWQMSubsectorLanguageModelWithMWQMSubsectorIDAndLanguageDB(mwqmSubsectorModelRet.MWQMSubsectorID, Lang);

                Assert.AreEqual("", mwqmSubsectorLanguageModel.Error);
                if (Lang == mwqmSubsectorService.LanguageRequest)
                {
                    Assert.AreEqual(mwqmSubsectorModelRet.SubsectorDesc, mwqmSubsectorLanguageModel.SubsectorDesc);
                }
            }
        }
        private void FillMWQMSubsectorModel(MWQMSubsectorModel mwqmSubsectorModel)
        {
            mwqmSubsectorModel.MWQMSubsectorTVItemID = mwqmSubsectorModel.MWQMSubsectorTVItemID;
            mwqmSubsectorModel.SubsectorHistoricKey = randomService.RandomString("subsekey", 20);
            mwqmSubsectorModel.SubsectorDesc = randomService.RandomString("SubsectorDesc", 40);

            Assert.IsTrue(mwqmSubsectorModel.MWQMSubsectorTVItemID != 0);
            Assert.IsTrue(mwqmSubsectorModel.SubsectorHistoricKey.Length == 20);
            Assert.IsTrue(mwqmSubsectorModel.SubsectorDesc.Length == 40);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mwqmSubsectorService = new MWQMSubsectorService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmSubsectorLanguageService = new MWQMSubsectorLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmSubsectorModelNew = new MWQMSubsectorModel();
            mwqmSubsector = new MWQMSubsector();
        }
        private void SetupShim()
        {
            shimMWQMSubsectorService = new ShimMWQMSubsectorService(mwqmSubsectorService);
            shimMWQMSubsectorLanguageService = new ShimMWQMSubsectorLanguageService(mwqmSubsectorService._MWQMSubsectorLanguageService);
            shimTVItemService = new ShimTVItemService(mwqmSubsectorService._TVItemService);
        }
        #endregion Functions private
    }
}

