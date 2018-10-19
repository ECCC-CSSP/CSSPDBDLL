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
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;
using System.Reflection;
using System.Web.UI.WebControls;
using CSSPReportWriterHelperDLL.Services;
using CSSPReportWriterHelperDLL.Services.Resources;
using System.IO;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for ReportServiceTest
    /// </summary>
    [TestClass]
    public class ReportServiceMWQM_SiteTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceMWQM_Site reportServiceMWQM_Site { get; set; }
        private ReportServiceMWQM_Site_File reportServiceMWQM_Site_File { get; set; }
        private ReportServiceMWQM_Site_Sample reportServiceMWQM_Site_Sample { get; set; }
        private ReportServiceMWQM_Site_Start_And_End_Date reportServiceMWQM_Site_Start_And_End_Date { get; set; }
        private TVItemService tvItemService { get; set; }
        private ShimReportService shimReportService { get; set; }
        private ReportBaseService reportBaseService { get; set; }
        private BoxModelService boxModelService { get; set; }
        private VPScenarioService vpScenarioService { get; set; }
        private LabSheetService labSheetService { get; set; }
        private PolSourceObservationService polSourceObservationService { get; set; }
        private TideSiteService tideSiteService { get; set; }
        private HydrometricSiteService hydrometricSiteService { get; set; }
        private ClimateSiteService climateSiteService { get; set; }
        private RandomService randomService { get; set; }
        private HydrometricDataValueService hydrometricDataValueService { get; set; }
        private TideDataValueService tideDataValueService { get; set; }

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
        public ReportServiceMWQM_SiteTest()
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
        #region Testing Methods MWQM_Site
        [TestMethod]
        public void ReportService_GetReportMWQM_SiteModelListUnderTVItemIDDB_Start_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Error");
                sb.AppendLine("MWQM_Site_Counter");
                sb.AppendLine("MWQM_Site_ID");
                sb.AppendLine("MWQM_Site_Name");
                sb.AppendLine("MWQM_Site_Name_Translation_Status");
                sb.AppendLine("MWQM_Site_Is_Active");
                sb.AppendLine("MWQM_Site_Number");
                sb.AppendLine("MWQM_Site_Description");
                sb.AppendLine("MWQM_Site_Latest_Classification");
                sb.AppendLine("MWQM_Site_Ordinal");
                sb.AppendLine("MWQM_Site_Last_Update_Date_And_Time");
                sb.AppendLine("MWQM_Site_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Site_Last_Update_Contact_Initial");
                sb.AppendLine("MWQM_Site_Lat");
                sb.AppendLine("MWQM_Site_Lng");
                sb.AppendLine("MWQM_Site_Stat_MWQM_Run_Count");
                sb.AppendLine("MWQM_Site_Stat_MWQM_Sample_Count");
                sb.AppendLine("MWQM_Site_Stat_GM_30_Samples");
                sb.AppendLine("MWQM_Site_Stat_Median_30_Samples");
                sb.AppendLine("MWQM_Site_Stat_P90_30_Samples");
                sb.AppendLine("MWQM_Site_Stat_P90_Over_43_30_Samples");
                sb.AppendLine("MWQM_Site_Stat_P90_Over_260_30_Samples");
                sb.AppendLine("MWQM_Site_Stat_Min_Year_30_Samples");
                sb.AppendLine("MWQM_Site_Stat_Max_Year_30_Samples");
                sb.AppendLine("MWQM_Site_Stat_Sample_Count_30_Samples");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMWQM_Site.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_SiteModel> ReportMWQM_SiteModelList = reportServiceMWQM_Site.GetReportMWQM_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_SiteModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_SiteModelList[0].MWQM_Site_Error);
                Assert.AreEqual(1, ReportMWQM_SiteModelList[0].MWQM_Site_Counter);
                Assert.AreEqual(tvItemModelMWQM_Site.TVItemID, ReportMWQM_SiteModelList[0].MWQM_Site_ID);
                Assert.IsTrue(ReportMWQM_SiteModelList[0].MWQM_Site_Name.Length > 0);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Name_Translation_Status);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Is_Active);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Number);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Description);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Latest_Classification);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Ordinal);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Last_Update_Contact_Name.Length);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Last_Update_Contact_Initial.Length);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Lat);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Lng);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_MWQM_Run_Count);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_MWQM_Sample_Count);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_GM_X_Last_Samples);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_Median_X_Last_Samples);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_P90_X_Last_Samples);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_P90_Over_43_X_Last_Samples);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_P90_Over_260_X_Last_Samples);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_Min_Year_X_Last_Samples);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_Max_Year_X_Last_Samples);
                Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_Sample_Count_X_Last_Samples);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_SiteModelListUnderTVItemIDDB_Start_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_SiteModel> ReportMWQM_SiteModelList = reportServiceMWQM_Site.GetReportMWQM_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMWQM_SiteModelList[0].MWQM_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_SiteModelListUnderTVItemIDDB_Start_TVType_Not_MWQM_Site_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_SiteModel> ReportMWQM_SiteModelList = reportServiceMWQM_Site.GetReportMWQM_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMSite.ToString()), ReportMWQM_SiteModelList[0].MWQM_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_SiteModelListUnderTVItemIDDB_Start_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMWQM_Site.TVItemID;
                string ParentTagItem = tvItemModelMWQM_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Site";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_SiteModel> ReportMWQM_SiteModelList = reportServiceMWQM_Site.GetReportMWQM_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_SiteModelList[0].MWQM_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_SiteModelList = reportServiceMWQM_Site.GetReportMWQM_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_SiteModelList[0].MWQM_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_SiteModelList = reportServiceMWQM_Site.GetReportMWQM_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_SiteModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMWQM_SiteModelList[0].MWQM_Site_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_SiteModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                   tvItemModelSubsector, tvItemModelMWQM_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Site_Error");
                    sb.AppendLine("MWQM_Site_Counter");
                    sb.AppendLine("MWQM_Site_ID");
                    sb.AppendLine("MWQM_Site_Name");
                    sb.AppendLine("MWQM_Site_Name_Translation_Status");
                    sb.AppendLine("MWQM_Site_Is_Active");
                    sb.AppendLine("MWQM_Site_Number");
                    sb.AppendLine("MWQM_Site_Description");
                    sb.AppendLine("MWQM_Site_Latest_Classification");
                    sb.AppendLine("MWQM_Site_Ordinal");
                    sb.AppendLine("MWQM_Site_Last_Update_Date_And_Time");
                    sb.AppendLine("MWQM_Site_Last_Update_Contact_Name");
                    sb.AppendLine("MWQM_Site_Last_Update_Contact_Initial");
                    sb.AppendLine("MWQM_Site_Lat");
                    sb.AppendLine("MWQM_Site_Lng");
                    sb.AppendLine("MWQM_Site_Stat_MWQM_Run_Count");
                    sb.AppendLine("MWQM_Site_Stat_MWQM_Sample_Count");
                    sb.AppendLine("MWQM_Site_Stat_GM_30_Samples");
                    sb.AppendLine("MWQM_Site_Stat_Median_30_Samples");
                    sb.AppendLine("MWQM_Site_Stat_P90_30_Samples");
                    sb.AppendLine("MWQM_Site_Stat_P90_Over_43_30_Samples");
                    sb.AppendLine("MWQM_Site_Stat_P90_Over_260_30_Samples");
                    sb.AppendLine("MWQM_Site_Stat_Min_Year_30_Samples");
                    sb.AppendLine("MWQM_Site_Stat_Max_Year_30_Samples");
                    sb.AppendLine("MWQM_Site_Stat_Sample_Count_30_Samples");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_SiteModel> ReportMWQM_SiteModelList = reportServiceMWQM_Site.GetReportMWQM_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_SiteModelList.Count > 0);
                    Assert.AreEqual("", ReportMWQM_SiteModelList[0].MWQM_Site_Error);
                    Assert.AreEqual(1, ReportMWQM_SiteModelList[0].MWQM_Site_Counter);
                    Assert.IsTrue(ReportMWQM_SiteModelList[0].MWQM_Site_ID > 0);
                    Assert.IsTrue(ReportMWQM_SiteModelList[0].MWQM_Site_Name.Length > 0);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Name_Translation_Status);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Is_Active);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Number);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Description);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Latest_Classification);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Ordinal);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Last_Update_Date_And_Time_UTC);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Last_Update_Contact_Name.Length);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Last_Update_Contact_Initial.Length);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Lat);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Lng);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_MWQM_Run_Count);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_MWQM_Sample_Count);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_GM_X_Last_Samples);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_Median_X_Last_Samples);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_P90_X_Last_Samples);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_P90_Over_43_X_Last_Samples);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_P90_Over_260_X_Last_Samples);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_Min_Year_X_Last_Samples);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_Max_Year_X_Last_Samples);
                    Assert.IsNotNull(ReportMWQM_SiteModelList[0].MWQM_Site_Stat_Sample_Count_X_Last_Samples);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_SiteModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                   tvItemModelSubsector, tvItemModelMWQM_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Site_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_SiteModel> ReportMWQM_SiteModelList = reportServiceMWQM_Site.GetReportMWQM_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_SiteModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMWQM_SiteModelList[0].MWQM_Site_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_SiteModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Site";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_SiteModel> ReportMWQM_SiteModelList = reportServiceMWQM_Site.GetReportMWQM_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMWQM_SiteModelList[0].MWQM_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_SiteModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMWQM_Site.TVItemID;
                string ParentTagItem = tvItemModelMWQM_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Site";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_SiteModel> ReportMWQM_SiteModelList = reportServiceMWQM_Site.GetReportMWQM_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_SiteModelList[0].MWQM_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_SiteModelList = reportServiceMWQM_Site.GetReportMWQM_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_SiteModelList[0].MWQM_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_SiteModelList = reportServiceMWQM_Site.GetReportMWQM_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_SiteModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMWQM_SiteModelList[0].MWQM_Site_Error));
            }
        }
        #endregion Testing Methods MWQM_Site
        #region Testing Methods MWQM_Site_File
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_FileModelListUnderTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCountry.TVItemID,
                    culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick", TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelArea = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06", TVTypeEnum.Area);
                Assert.AreEqual("", tvItemModelArea.Error);

                TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelArea.TVItemID, "NB-06-020", TVTypeEnum.Sector);
                Assert.AreEqual("", tvItemModelSector.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSector.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQMSite = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQMSite.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Site_File_Error");
                    sb.AppendLine("MWQM_Site_File_Counter");
                    sb.AppendLine("MWQM_Site_File_ID");
                    sb.AppendLine("MWQM_Site_File_Language");
                    sb.AppendLine("MWQM_Site_File_File_Purpose");
                    sb.AppendLine("MWQM_Site_File_File_Type");
                    sb.AppendLine("MWQM_Site_File_File_Description");
                    sb.AppendLine("MWQM_Site_File_File_Size_kb");
                    sb.AppendLine("MWQM_Site_File_File_Info");
                    sb.AppendLine("MWQM_Site_File_File_Created_Date_UTC");
                    sb.AppendLine("MWQM_Site_File_From_Water");
                    sb.AppendLine("MWQM_Site_File_Server_File_Name");
                    sb.AppendLine("MWQM_Site_File_Server_File_Path");
                    sb.AppendLine("MWQM_Site_File_Last_Update_Date_And_Time");
                    sb.AppendLine("MWQM_Site_File_Last_Update_Contact_Name");
                    sb.AppendLine("MWQM_Site_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MWQMSite" ? "MWQM_Site" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_Site_FileModel> ReportMWQM_Site_FileModelList = reportServiceMWQM_Site_File.GetReportMWQM_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList.Count > 0);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Error == "");
                    Assert.IsTrue(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Counter > 0);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_ID > 0);
                    Assert.IsTrue((int)ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Language > 0);
                    Assert.IsTrue((int)ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Purpose > 0);
                    Assert.IsTrue((int)ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Type > 0);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Description.Length > 0);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Size_kb > 0);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Info.Length > 0);
                    Assert.IsNotNull(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Created_Date_UTC);
                    //Assert.IsNotNull(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_From_Water);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Server_File_Name.Length > 0);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Server_File_Path.Length > 0);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Last_Update_Date_And_Time_UTC > new DateTime(1979, 1, 1));
                    Assert.IsTrue(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Last_Update_Contact_Initial.Length > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_FileModelListUnderTVItemIDDB_Good_CountOnly_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCountry.TVItemID,
                    culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick", TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelArea = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06", TVTypeEnum.Area);
                Assert.AreEqual("", tvItemModelArea.Error);

                TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelArea.TVItemID, "NB-06-020", TVTypeEnum.Sector);
                Assert.AreEqual("", tvItemModelSector.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSector.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQMSite = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQMSite.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Site_File_Error");
                    sb.AppendLine("MWQM_Site_File_Counter");
                    sb.AppendLine("MWQM_Site_File_ID");
                    sb.AppendLine("MWQM_Site_File_Language");
                    sb.AppendLine("MWQM_Site_File_File_Purpose");
                    sb.AppendLine("MWQM_Site_File_File_Type");
                    sb.AppendLine("MWQM_Site_File_File_Description");
                    sb.AppendLine("MWQM_Site_File_File_Size_kb");
                    sb.AppendLine("MWQM_Site_File_File_Info");
                    sb.AppendLine("MWQM_Site_File_File_Created_Date_UTC");
                    sb.AppendLine("MWQM_Site_File_From_Water");
                    sb.AppendLine("MWQM_Site_File_Server_File_Name");
                    sb.AppendLine("MWQM_Site_File_Server_File_Path");
                    sb.AppendLine("MWQM_Site_File_Last_Update_Date_And_Time");
                    sb.AppendLine("MWQM_Site_File_Last_Update_Contact_Name");
                    sb.AppendLine("MWQM_Site_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MWQMSite" ? "MWQM_Site" : tvItemModel.TVType.ToString());
                    bool CountOnly = true;
                    int Take = 10;

                    List<ReportMWQM_Site_FileModel> ReportMWQM_Site_FileModelList = reportServiceMWQM_Site_File.GetReportMWQM_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList.Count == 1);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Counter > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_FileModelListUnderTVItemIDDB_Error_Start_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCountry.TVItemID,
                    culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick", TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelArea = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06", TVTypeEnum.Area);
                Assert.AreEqual("", tvItemModelArea.Error);

                TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelArea.TVItemID, "NB-06-020", TVTypeEnum.Sector);
                Assert.AreEqual("", tvItemModelSector.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSector.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQMSite = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQMSite.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start MWQM_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Site_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MWQMSite" ? "MWQM_Site" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "MWQM_Site_File";

                    List<ReportMWQM_Site_FileModel> ReportMWQM_Site_FileModelList = reportServiceMWQM_Site_File.GetReportMWQM_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_FileModelListUnderTVItemIDDB_Error_TVItem_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCountry.TVItemID,
                    culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick", TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelArea = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06", TVTypeEnum.Area);
                Assert.AreEqual("", tvItemModelArea.Error);

                TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelArea.TVItemID, "NB-06-020", TVTypeEnum.Sector);
                Assert.AreEqual("", tvItemModelSector.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSector.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQMSite = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQMSite.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Site_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MWQMSite" ? "MWQM_Site" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_Site_FileModel> ReportMWQM_Site_FileModelList = reportServiceMWQM_Site_File.GetReportMWQM_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_FileModelListUnderTVItemIDDB_Error_ParentTagItem_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCountry.TVItemID,
                    culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick", TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelArea = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06", TVTypeEnum.Area);
                Assert.AreEqual("", tvItemModelArea.Error);

                TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelArea.TVItemID, "NB-06-020", TVTypeEnum.Sector);
                Assert.AreEqual("", tvItemModelSector.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSector.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQMSite = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQMSite.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Site_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_Site_FileModel> ReportMWQM_Site_FileModelList = reportServiceMWQM_Site_File.GetReportMWQM_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.ParentTagItemShouldNotBeEmpty, ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_FileModelListUnderTVItemIDDB_Error_Allowable_ParentTagItem_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCountry.TVItemID,
                    culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick", TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelArea = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06", TVTypeEnum.Area);
                Assert.AreEqual("", tvItemModelArea.Error);

                TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelArea.TVItemID, "NB-06-020", TVTypeEnum.Sector);
                Assert.AreEqual("", tvItemModelSector.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSector.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQMSite = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQMSite.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Site_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "Municipality";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "MWQM_Site_File";

                    List<string> AllowableParentTagItemList = reportServiceMWQM_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportMWQM_Site_FileModel> ReportMWQM_Site_FileModelList = reportServiceMWQM_Site_File.GetReportMWQM_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_FileModelListUnderTVItemIDDB_Error_GetReportTreeNodesFromTagText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelCountry.TVItemID,
                    culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick", TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelArea = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06", TVTypeEnum.Area);
                Assert.AreEqual("", tvItemModelArea.Error);

                TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelArea.TVItemID, "NB-06-020", TVTypeEnum.Sector);
                Assert.AreEqual("", tvItemModelSector.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSector.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQMSite = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQMSite.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Site_File_IDNot"); // line 2
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MWQMSite" ? "MWQM_Site" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_Site_FileModel> ReportMWQM_Site_FileModelList = reportServiceMWQM_Site_File.GetReportMWQM_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Site_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ReportServiceRes._DoesNotExistFor_, "MWQM_Site_File_IDNot", "CSSPModelsDLL.Models.ReportMWQM_Site_FileModel"), ReportMWQM_Site_FileModelList[0].MWQM_Site_File_Error);
                }
            }
        }
        #endregion Testing Methods MWQM_Site_File
        #region Testing Methods MWQM_Site_Sample
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_SampleModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Site_Sample " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Sample_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 13283;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Site_Sample";

                List<ReportMWQM_Site_SampleModel> ReportMWQM_Site_SampleModelList = reportServiceMWQM_Site_Sample.GetReportMWQM_Site_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Site_SampleModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_SampleModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site_Sample " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Sample_Error");
                sb.AppendLine("MWQM_Site_Sample_Counter");
                sb.AppendLine("MWQM_Site_Sample_ID");
                sb.AppendLine("MWQM_Site_Sample_Date_Time_Local");
                sb.AppendLine("MWQM_Site_Sample_Depth_m");
                sb.AppendLine("MWQM_Site_Sample_Fec_Col_MPN_100_ml");
                sb.AppendLine("MWQM_Site_Sample_Salinity_PPT");
                sb.AppendLine("MWQM_Site_Sample_Water_Temp_C");
                sb.AppendLine("MWQM_Site_Sample_PH");
                sb.AppendLine("MWQM_Site_Sample_Types");
                sb.AppendLine("MWQM_Site_Sample_Tube_10");
                sb.AppendLine("MWQM_Site_Sample_Tube_1_0");
                sb.AppendLine("MWQM_Site_Sample_Tube_0_1");
                sb.AppendLine("MWQM_Site_Sample_Processed_By");
                sb.AppendLine("MWQM_Site_Sample_Note_Translation_Status");
                sb.AppendLine("MWQM_Site_Sample_Note");
                sb.AppendLine("MWQM_Site_Sample_Last_Update_Date_And_Time");
                sb.AppendLine("MWQM_Site_Sample_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Site_Sample_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMWQM_Site.TVItemID;
                string ParentTagItem = tvItemModelMWQM_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Site_SampleModel> ReportMWQM_Site_SampleModelList = reportServiceMWQM_Site_Sample.GetReportMWQM_Site_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Site_SampleModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Error);
                Assert.AreEqual(1, ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Counter);
                Assert.IsTrue(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_ID > 0);
                Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Date_Time_Local);
                //Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Depth_m);
                Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Fec_Col_MPN_100_ml);
                Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Salinity_PPT);
                Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Water_Temp_C);
                //Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_PH);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Types));
                //Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Tube_10);
                //Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Tube_1_0);
                //Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Tube_0_1);
                //Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Processed_By);
                //Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Note_Translation_Status);
                //Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Note);
                Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_SampleModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                   tvItemModelSubsector, tvItemModelMWQM_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Site_Sample " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Site_Sample_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_Site_SampleModel> ReportMWQM_Site_SampleModelList = reportServiceMWQM_Site_Sample.GetReportMWQM_Site_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Site_SampleModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_SampleModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                        "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site_Sample " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Sample_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Site_Sample";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_Site_SampleModel> ReportMWQM_Site_SampleModelList = reportServiceMWQM_Site_Sample.GetReportMWQM_Site_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Site_SampleModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_SampleModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                      "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site_Sample " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Sample_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMWQM_Site.TVItemID;
                string ParentTagItem = tvItemModelMWQM_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Site_Sample";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_Site_SampleModel> ReportMWQM_Site_SampleModelList = reportServiceMWQM_Site_Sample.GetReportMWQM_Site_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Site_SampleModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site_Sample " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Sample_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_Site_SampleModelList = reportServiceMWQM_Site_Sample.GetReportMWQM_Site_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Site_SampleModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site_Sample " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Sample_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_Site_SampleModelList = reportServiceMWQM_Site_Sample.GetReportMWQM_Site_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Site_SampleModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMWQM_Site_SampleModelList[0].MWQM_Site_Sample_Error));
            }
        }
        #endregion Testing Methods MWQM_Site_Sample
        #region Testing Methods MWQM_Site_Start_And_End_Date
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Site_Start_And_End_Date " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Start_And_End_Date_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 7460;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Site_Start_And_End_Date";

                List<ReportMWQM_Site_Start_And_End_DateModel> ReportMWQM_Site_Start_And_End_DateModelList = reportServiceMWQM_Site_Start_And_End_Date.GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Site_Start_And_End_DateModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site_Start_And_End_Date " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Start_And_End_Date_Error");
                sb.AppendLine("MWQM_Site_Start_And_End_Date_Counter");
                sb.AppendLine("MWQM_Site_Start_And_End_Date_ID");
                sb.AppendLine("MWQM_Site_Start_And_End_Date_Start_Date");
                sb.AppendLine("MWQM_Site_Start_And_End_Date_End_Date");
                sb.AppendLine("MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time");
                sb.AppendLine("MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMWQM_Site.TVItemID;
                string ParentTagItem = tvItemModelMWQM_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Site_Start_And_End_DateModel> ReportMWQM_Site_Start_And_End_DateModelList = reportServiceMWQM_Site_Start_And_End_Date.GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Site_Start_And_End_DateModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_Error);
                Assert.IsTrue(ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_Counter > 0);
                Assert.IsTrue(ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_ID > 0);
                Assert.IsNotNull(ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_Start_Date);
                Assert.IsNotNull(ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_End_Date);
                Assert.IsNotNull(ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                   tvItemModelSubsector, tvItemModelMWQM_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Site_Start_And_End_Date " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Site_Start_And_End_Date_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_Site_Start_And_End_DateModel> ReportMWQM_Site_Start_And_End_DateModelList = reportServiceMWQM_Site_Start_And_End_Date.GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Site_Start_And_End_DateModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                        "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site_Start_And_End_Date " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Start_And_End_Date_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Site_Start_And_End_Date";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_Site_Start_And_End_DateModel> ReportMWQM_Site_Start_And_End_DateModelList = reportServiceMWQM_Site_Start_And_End_Date.GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Site_Start_And_End_DateModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMWQM_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                      "0001", TVTypeEnum.MWQMSite);
                Assert.AreEqual("", tvItemModelMWQM_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site_Start_And_End_Date " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Start_And_End_Date_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMWQM_Site.TVItemID;
                string ParentTagItem = tvItemModelMWQM_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Site_Start_And_End_Date";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_Site_Start_And_End_DateModel> ReportMWQM_Site_Start_And_End_DateModelList = reportServiceMWQM_Site_Start_And_End_Date.GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Site_Start_And_End_DateModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site_Start_And_End_Date " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Start_And_End_Date_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_Site_Start_And_End_DateModelList = reportServiceMWQM_Site_Start_And_End_Date.GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Site_Start_And_End_DateModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Site_Start_And_End_Date " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Site_Start_And_End_Date_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_Site_Start_And_End_DateModelList = reportServiceMWQM_Site_Start_And_End_Date.GetReportMWQM_Site_Start_And_End_DateModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Site_Start_And_End_DateModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMWQM_Site_Start_And_End_DateModelList[0].MWQM_Site_Start_And_End_Date_Error));
            }
        }
        #endregion Testing Methods MWQM_Site_Start_And_End_Date
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Function
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            reportServiceMWQM_Site = new ReportServiceMWQM_Site((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Site_File = new ReportServiceMWQM_Site_File((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Site_Sample = new ReportServiceMWQM_Site_Sample((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Site_Start_And_End_Date = new ReportServiceMWQM_Site_Start_And_End_Date((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            boxModelService = new BoxModelService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            vpScenarioService = new VPScenarioService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            labSheetService = new LabSheetService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            polSourceObservationService = new PolSourceObservationService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            climateSiteService = new ClimateSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            hydrometricSiteService = new HydrometricSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tideSiteService = new TideSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            hydrometricDataValueService = new HydrometricDataValueService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tideDataValueService = new TideDataValueService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
        }
        private void SetupShim()
        {
            shimReportService = new ShimReportService(reportServiceMWQM_Site);
        }
        #endregion Functions private
    }
}

