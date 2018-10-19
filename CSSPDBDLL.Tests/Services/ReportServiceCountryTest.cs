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
    public class ReportServiceCountryTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceCountry reportServiceCountry { get; set; }
        private ReportServiceCountry_File reportServiceCountry_File { get; set; }
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
        public ReportServiceCountryTest()
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
        #region Testing Methods Country
        [TestMethod]
        public void ReportService_GetReportCountryModelListUnderTVItemIDDB_Start_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Country " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Country_Error");
                sb.AppendLine("Country_Counter");
                sb.AppendLine("Country_ID");
                sb.AppendLine("Country_Name_Translation_Status");
                sb.AppendLine("Country_Name");
                sb.AppendLine("Country_Initial");
                sb.AppendLine("Country_Is_Active");
                sb.AppendLine("Country_Last_Update_Date_And_Time");
                sb.AppendLine("Country_Last_Update_Contact_Name");
                sb.AppendLine("Country_Last_Update_Contact_Initial");
                sb.AppendLine("Country_Lat");
                sb.AppendLine("Country_Lng");
                sb.AppendLine("Country_Stat_Province_Count");
                sb.AppendLine("Country_Stat_Area_Count");
                sb.AppendLine("Country_Stat_Sector_Count");
                sb.AppendLine("Country_Stat_Subsector_Count");
                sb.AppendLine("Country_Stat_Municipality_Count");
                sb.AppendLine("Country_Stat_Lift_Station_Count");
                sb.AppendLine("Country_Stat_WWTP_Count");
                sb.AppendLine("Country_Stat_MWQM_Sample_Count");
                sb.AppendLine("Country_Stat_MWQM_Site_Count");
                sb.AppendLine("Country_Stat_MWQM_Run_Count");
                sb.AppendLine("Country_Stat_Pol_Source_Site_Count");
                sb.AppendLine("Country_Stat_Mike_Scenario_Count");
                sb.AppendLine("Country_Stat_Box_Model_Scenario_Count");
                sb.AppendLine("Country_Stat_Visual_Plumes_Scenario_Count");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelCountry.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportCountryModel> ReportCountryModelList = reportServiceCountry.GetReportCountryModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportCountryModelList.Count > 0);
                Assert.AreEqual("", ReportCountryModelList[0].Country_Error);
                Assert.AreEqual(1, ReportCountryModelList[0].Country_Counter);
                Assert.AreEqual(tvItemModelCountry.TVItemID, ReportCountryModelList[0].Country_ID);
                Assert.IsNotNull(ReportCountryModelList[0].Country_Name);
                Assert.IsNotNull(ReportCountryModelList[0].Country_Initial);
                Assert.IsNotNull(ReportCountryModelList[0].Country_Name_Translation_Status);
                Assert.IsNotNull(ReportCountryModelList[0].Country_Last_Update_Date_And_Time_UTC);
                Assert.IsTrue(ReportCountryModelList[0].Country_Last_Update_Contact_Name.Length > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Last_Update_Contact_Initial.Length > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Lat != 0.0f);
                Assert.IsTrue(ReportCountryModelList[0].Country_Lng != 0.0f);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Province_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Area_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Sector_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Subsector_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Municipality_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Lift_Station_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_WWTP_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_MWQM_Sample_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_MWQM_Site_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_MWQM_Run_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Pol_Source_Site_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Mike_Scenario_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Box_Model_Scenario_Count > 0);
                Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Visual_Plumes_Scenario_Count > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountryModelListUnderTVItemIDDB_Start_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Country " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Country_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportCountryModel> ReportCountryModelList = reportServiceCountry.GetReportCountryModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportCountryModelList[0].Country_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountryModelListUnderTVItemIDDB_Start_TVType_Not_Country_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Country " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Country_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 7;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportCountryModel> ReportCountryModelList = reportServiceCountry.GetReportCountryModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Country.ToString()), ReportCountryModelList[0].Country_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountryModelListUnderTVItemIDDB_Start_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Country " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Country_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelCountry.TVItemID;
                string ParentTagItem = tvItemModelCountry.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Country";

                List<string> AllowableParentTagItemList = reportServiceCountry._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportCountryModel> ReportCountryModelList = reportServiceCountry.GetReportCountryModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportCountryModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportCountryModelList[0].Country_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Country " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Country_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportCountryModelList = reportServiceCountry.GetReportCountryModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportCountryModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportCountryModelList[0].Country_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Country " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Country_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportCountryModelList = reportServiceCountry.GetReportCountryModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportCountryModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportCountryModelList[0].Country_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountryModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, */
                    tvItemModelRoot, tvItemModelCountry };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Country " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Country_Error");
                    sb.AppendLine("Country_Counter");
                    sb.AppendLine("Country_ID");
                    sb.AppendLine("Country_Name_Translation_Status");
                    sb.AppendLine("Country_Name");
                    sb.AppendLine("Country_Initial");
                    sb.AppendLine("Country_Is_Active");
                    sb.AppendLine("Country_Last_Update_Date_And_Time");
                    sb.AppendLine("Country_Last_Update_Contact_Name");
                    sb.AppendLine("Country_Last_Update_Contact_Initial");
                    sb.AppendLine("Country_Lat");
                    sb.AppendLine("Country_Lng");
                    sb.AppendLine("Country_Stat_Province_Count");
                    sb.AppendLine("Country_Stat_Area_Count");
                    sb.AppendLine("Country_Stat_Sector_Count");
                    sb.AppendLine("Country_Stat_Subsector_Count");
                    sb.AppendLine("Country_Stat_Municipality_Count");
                    sb.AppendLine("Country_Stat_Lift_Station_Count");
                    sb.AppendLine("Country_Stat_WWTP_Count");
                    sb.AppendLine("Country_Stat_MWQM_Sample_Count");
                    sb.AppendLine("Country_Stat_MWQM_Site_Count");
                    sb.AppendLine("Country_Stat_MWQM_Run_Count");
                    sb.AppendLine("Country_Stat_Pol_Source_Site_Count");
                    sb.AppendLine("Country_Stat_Mike_Scenario_Count");
                    sb.AppendLine("Country_Stat_Box_Model_Scenario_Count");
                    sb.AppendLine("Country_Stat_Visual_Plumes_Scenario_Count");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportCountryModel> ReportCountryModelList = reportServiceCountry.GetReportCountryModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportCountryModelList.Count > 0);
                    Assert.AreEqual("", ReportCountryModelList[0].Country_Error);
                    Assert.AreEqual(1, ReportCountryModelList[0].Country_Counter);
                    Assert.IsTrue(ReportCountryModelList[0].Country_ID > 0);
                    Assert.IsNotNull(ReportCountryModelList[0].Country_Name);
                    Assert.IsNotNull(ReportCountryModelList[0].Country_Initial);
                    Assert.IsNotNull(ReportCountryModelList[0].Country_Name_Translation_Status);
                    Assert.IsNotNull(ReportCountryModelList[0].Country_Last_Update_Date_And_Time_UTC);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Last_Update_Contact_Initial.Length > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Lat != 0.0f);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Lng != 0.0f);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Province_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Area_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Sector_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Subsector_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Municipality_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Lift_Station_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_WWTP_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_MWQM_Sample_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_MWQM_Site_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_MWQM_Run_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Pol_Source_Site_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Mike_Scenario_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Box_Model_Scenario_Count > 0);
                    Assert.IsTrue(ReportCountryModelList[0].Country_Stat_Visual_Plumes_Scenario_Count > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountryModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, */
                    tvItemModelRoot, tvItemModelCountry };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Country " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Country_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportCountryModel> ReportCountryModelList = reportServiceCountry.GetReportCountryModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportCountryModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportCountryModelList[0].Country_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountryModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Country " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Country_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Country";

                List<string> AllowableParentTagItemList = reportServiceCountry._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportCountryModel> ReportCountryModelList = reportServiceCountry.GetReportCountryModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportCountryModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportCountryModelList[0].Country_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountryModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Country " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Country_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelRoot.TVItemID;
                string ParentTagItem = tvItemModelRoot.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Country";

                List<string> AllowableParentTagItemList = reportServiceCountry._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportCountryModel> ReportCountryModelList = reportServiceCountry.GetReportCountryModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportCountryModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportCountryModelList[0].Country_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Country " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Country_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportCountryModelList = reportServiceCountry.GetReportCountryModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportCountryModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportCountryModelList[0].Country_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Country " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Country_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportCountryModelList = reportServiceCountry.GetReportCountryModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportCountryModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportCountryModelList[0].Country_Error));
            }
        }
        #endregion Testing Methods Country
        #region Testing Methods Country_File
        [TestMethod]
        public void ReportService_GetReportCountry_FileModelListUnderTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Country_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Country_File_Error");
                    sb.AppendLine("Country_File_Counter");
                    sb.AppendLine("Country_File_ID");
                    sb.AppendLine("Country_File_Language");
                    sb.AppendLine("Country_File_File_Purpose");
                    sb.AppendLine("Country_File_File_Type");
                    sb.AppendLine("Country_File_File_Description");
                    sb.AppendLine("Country_File_File_Size_kb");
                    sb.AppendLine("Country_File_File_Info");
                    sb.AppendLine("Country_File_File_Created_Date_UTC");
                    sb.AppendLine("Country_File_From_Water");
                    sb.AppendLine("Country_File_Server_File_Name");
                    sb.AppendLine("Country_File_Server_File_Path");
                    sb.AppendLine("Country_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Country_File_Last_Update_Contact_Name");
                    sb.AppendLine("Country_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportCountry_FileModel> ReportCountry_FileModelList = reportServiceCountry_File.GetReportCountry_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportCountry_FileModelList.Count > 0);
                    Assert.IsTrue(ReportCountry_FileModelList[0].Country_File_Error == "");
                    Assert.IsTrue(ReportCountry_FileModelList[0].Country_File_Counter > 0);
                    Assert.IsTrue(ReportCountry_FileModelList[0].Country_File_ID > 0);
                    Assert.IsTrue((int)ReportCountry_FileModelList[0].Country_File_Language > 0);
                    Assert.IsTrue((int)ReportCountry_FileModelList[0].Country_File_File_Purpose > 0);
                    Assert.IsTrue((int)ReportCountry_FileModelList[0].Country_File_File_Type > 0);
                    Assert.IsTrue(ReportCountry_FileModelList[0].Country_File_File_Description.Length > 0);
                    Assert.IsTrue(ReportCountry_FileModelList[0].Country_File_File_Size_kb > 0);
                    Assert.IsTrue(ReportCountry_FileModelList[0].Country_File_File_Info.Length > 0);
                    Assert.IsNotNull(ReportCountry_FileModelList[0].Country_File_File_Created_Date_UTC);
                    //Assert.IsNotNull(ReportCountry_FileModelList[0].Country_File_From_Water);
                    Assert.IsTrue(ReportCountry_FileModelList[0].Country_File_Server_File_Name.Length > 0);
                    Assert.IsTrue(ReportCountry_FileModelList[0].Country_File_Server_File_Path.Length > 0);
                    Assert.IsTrue(ReportCountry_FileModelList[0].Country_File_Last_Update_Date_And_Time_UTC > new DateTime(1979, 1, 1));
                    Assert.IsTrue(ReportCountry_FileModelList[0].Country_File_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportCountry_FileModelList[0].Country_File_Last_Update_Contact_Initial.Length > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountry_FileModelListUnderTVItemIDDB_Good_CountOnly_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Country_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Country_File_Error");
                    sb.AppendLine("Country_File_Counter");
                    sb.AppendLine("Country_File_ID");
                    sb.AppendLine("Country_File_Language");
                    sb.AppendLine("Country_File_File_Purpose");
                    sb.AppendLine("Country_File_File_Type");
                    sb.AppendLine("Country_File_File_Description");
                    sb.AppendLine("Country_File_File_Size_kb");
                    sb.AppendLine("Country_File_File_Info");
                    sb.AppendLine("Country_File_File_Created_Date_UTC");
                    sb.AppendLine("Country_File_From_Water");
                    sb.AppendLine("Country_File_Server_File_Name");
                    sb.AppendLine("Country_File_Server_File_Path");
                    sb.AppendLine("Country_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Country_File_Last_Update_Contact_Name");
                    sb.AppendLine("Country_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = true;
                    int Take = 10;

                    List<ReportCountry_FileModel> ReportCountry_FileModelList = reportServiceCountry_File.GetReportCountry_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportCountry_FileModelList.Count == 1);
                    Assert.IsTrue(ReportCountry_FileModelList[0].Country_File_Counter > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountry_FileModelListUnderTVItemIDDB_Error_Start_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Country_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Country_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Country_File";

                    List<ReportCountry_FileModel> ReportCountry_FileModelList = reportServiceCountry_File.GetReportCountry_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportCountry_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportCountry_FileModelList[0].Country_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountry_FileModelListUnderTVItemIDDB_Error_TVItem_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Country_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Country_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportCountry_FileModel> ReportCountry_FileModelList = reportServiceCountry_File.GetReportCountry_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportCountry_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportCountry_FileModelList[0].Country_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountry_FileModelListUnderTVItemIDDB_Error_ParentTagItem_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Country_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Country_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportCountry_FileModel> ReportCountry_FileModelList = reportServiceCountry_File.GetReportCountry_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportCountry_FileModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.ParentTagItemShouldNotBeEmpty, ReportCountry_FileModelList[0].Country_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountry_FileModelListUnderTVItemIDDB_Error_Allowable_ParentTagItem_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Country_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Country_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "Municipality";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Country_File";

                    List<string> AllowableParentTagItemList = reportServiceCountry._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportCountry_FileModel> ReportCountry_FileModelList = reportServiceCountry_File.GetReportCountry_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportCountry_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportCountry_FileModelList[0].Country_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportCountry_FileModelListUnderTVItemIDDB_Error_GetReportTreeNodesFromTagText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Country_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Country_File_IDNot"); // line 2
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportCountry_FileModel> ReportCountry_FileModelList = reportServiceCountry_File.GetReportCountry_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportCountry_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ReportServiceRes._DoesNotExistFor_, "Country_File_IDNot", "CSSPModelsDLL.Models.ReportCountry_FileModel"), ReportCountry_FileModelList[0].Country_File_Error);
                }
            }
        }
        #endregion Testing Methods Country_File
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
            reportServiceCountry = new ReportServiceCountry((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceCountry_File = new ReportServiceCountry_File((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceCountry);
        }
        #endregion Functions private
    }
}

