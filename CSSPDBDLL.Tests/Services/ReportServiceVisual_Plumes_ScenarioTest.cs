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
    public class ReportServiceVisual_Plumes_ScenarioTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceVisual_Plumes_Scenario reportServiceVisual_Plumes_Scenario { get; set; }
        private ReportServiceVisual_Plumes_Scenario_Ambient reportServiceVisual_Plumes_Scenario_Ambient { get; set; }
        private ReportServiceVisual_Plumes_Scenario_Result reportServiceVisual_Plumes_Scenario_Result { get; set; }
        private TVItemService tvItemService { get; set; }
        private ShimReportServiceVisual_Plumes_Scenario shimReportServiceVisual_Plumes_Scenario { get; set; }
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
        public ReportServiceVisual_Plumes_ScenarioTest()
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
        #region Testing Methods Visual_Plumes_Scenario
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Visual_Plumes_Scenario " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 28689;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Visual_Plumes_Scenario";

                List<ReportVisual_Plumes_ScenarioModel> ReportVisual_Plumes_ScenarioModelList = reportServiceVisual_Plumes_Scenario.GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_ScenarioModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Error");
                sb.AppendLine("Visual_Plumes_Scenario_Counter");
                sb.AppendLine("Visual_Plumes_Scenario_ID");
                sb.AppendLine("Visual_Plumes_Scenario_Acute_Mix_Zone_m");
                sb.AppendLine("Visual_Plumes_Scenario_Chronic_Mix_Zone_m");
                sb.AppendLine("Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml");
                sb.AppendLine("Visual_Plumes_Scenario_Effluent_Flow_m3_s");
                sb.AppendLine("Visual_Plumes_Scenario_Effluent_Salinity_PSU");
                sb.AppendLine("Visual_Plumes_Scenario_Effluent_Temperature_C");
                sb.AppendLine("Visual_Plumes_Scenario_Effluent_Velocity_m_s");
                sb.AppendLine("Visual_Plumes_Scenario_Froude_Number");
                sb.AppendLine("Visual_Plumes_Scenario_Horizontal_Angle_deg");
                sb.AppendLine("Visual_Plumes_Scenario_Name");
                sb.AppendLine("Visual_Plumes_Scenario_Name_Translation_Status");
                sb.AppendLine("Visual_Plumes_Scenario_Number_Of_Ports");
                sb.AppendLine("Visual_Plumes_Scenario_Port_Depth_m");
                sb.AppendLine("Visual_Plumes_Scenario_Port_Diameter_m");
                sb.AppendLine("Visual_Plumes_Scenario_Port_Elevation_m");
                sb.AppendLine("Visual_Plumes_Scenario_Port_Spacing_m");
                sb.AppendLine("Visual_Plumes_Scenario_Raw_Results");
                sb.AppendLine("Visual_Plumes_Scenario_Use_As_Best_Estimate");
                sb.AppendLine("Visual_Plumes_Scenario_Vertical_Angle_deg");
                sb.AppendLine("Visual_Plumes_Scenario_Last_Update_Contact_Name");
                sb.AppendLine("Visual_Plumes_Scenario_Last_Update_Contact_Initial");
                sb.AppendLine("Visual_Plumes_Scenario_Last_Update_Date_UTC");
                sb.AppendLine("Visual_Plumes_Scenario_Status");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelInfrastructure.TVItemID;
                string ParentTagItem = tvItemModelInfrastructure.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportVisual_Plumes_ScenarioModel> ReportVisual_Plumes_ScenarioModelList = reportServiceVisual_Plumes_Scenario.GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_ScenarioModelList.Count > 0);
                Assert.AreEqual("", ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Error);
                Assert.IsTrue(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Counter > 0);
                Assert.IsTrue(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_ID > 0);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Acute_Mix_Zone_m);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Chronic_Mix_Zone_m);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Effluent_Concentration_MPN_100ml);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Effluent_Flow_m3_s);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Effluent_Salinity_PSU);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Effluent_Temperature_C);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Effluent_Velocity_m_s);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Froude_Number);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Horizontal_Angle_deg);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Name);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Name_Translation_Status);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Number_Of_Ports);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Port_Depth_m);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Port_Diameter_m);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Port_Elevation_m);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Port_Spacing_m);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Raw_Results);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Use_As_Best_Estimate);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Vertical_Angle_deg);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Last_Update_Contact_Initial);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Status);
            }
        }
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                   tvItemModelSubsector, tvItemModelMunicipality, tvItemModelInfrastructure };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Visual_Plumes_Scenario " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Visual_Plumes_Scenario_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportVisual_Plumes_ScenarioModel> ReportVisual_Plumes_ScenarioModelList = reportServiceVisual_Plumes_Scenario.GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportVisual_Plumes_ScenarioModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                   "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                TVItemModel tvItemModelPolSourceSite = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPolSourceSite);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPolSourceSite.TVItemID;
                string ParentTagItem = tvItemModelPolSourceSite.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Visual_Plumes_Scenario";

                List<string> AllowableParentTagItemList = reportServiceVisual_Plumes_Scenario._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportVisual_Plumes_ScenarioModel> ReportVisual_Plumes_ScenarioModelList = reportServiceVisual_Plumes_Scenario.GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_ScenarioModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                      "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelInfrastructure.TVItemID;
                string ParentTagItem = tvItemModelInfrastructure.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Visual_Plumes_Scenario";

                List<string> AllowableParentTagItemList = reportServiceVisual_Plumes_Scenario._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportVisual_Plumes_ScenarioModel> ReportVisual_Plumes_ScenarioModelList = reportServiceVisual_Plumes_Scenario.GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_ScenarioModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportVisual_Plumes_ScenarioModelList = reportServiceVisual_Plumes_Scenario.GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_ScenarioModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportVisual_Plumes_ScenarioModelList = reportServiceVisual_Plumes_Scenario.GetReportVisual_Plumes_ScenarioModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_ScenarioModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportVisual_Plumes_ScenarioModelList[0].Visual_Plumes_Scenario_Error));
            }
        }
        #endregion Testing Methods Visual_Plumes_Scenario
        #region Testing Methods Visual_Plumes_Scenario_Ambient
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Visual_Plumes_Scenario_Ambient " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 28689;
                string ParentTagItem = "Visual_Plumes_Scenario";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Visual_Plumes_Scenario_Ambient";

                List<ReportVisual_Plumes_Scenario_AmbientModel> ReportVisual_Plumes_Scenario_AmbientModelList = reportServiceVisual_Plumes_Scenario_Ambient.GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_AmbientModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB_Loop_ParentTagItem_Not_Visual_Plumes_ScenarioError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario_Ambient " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 28689;
                string ParentTagItem = "Visual_Plumes_ScenarioNot";
                bool CountOnly = false;
                int Take = 10;

                List<ReportVisual_Plumes_Scenario_AmbientModel> ReportVisual_Plumes_Scenario_AmbientModelList = reportServiceVisual_Plumes_Scenario_Ambient.GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_AmbientModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Visual_Plumes_Scenario", ParentTagItem), ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                List<VPScenarioModel> vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(tvItemModelInfrastructure.TVItemID);
                Assert.IsTrue(vpScenarioModelList.Count > 0);

                VPScenarioModel vpScenarioModel = vpScenarioModelList.FirstOrDefault();
                Assert.IsNotNull(vpScenarioModel);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario_Ambient " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Error");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Counter");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_ID");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Current_Direction_deg");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Current_Speed_m_s");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Measurement_Depth_m");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Row");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name");
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = vpScenarioModel.VPScenarioID;
                string ParentTagItem = "Visual_Plumes_Scenario";
                bool CountOnly = false;
                int Take = 10;

                List<ReportVisual_Plumes_Scenario_AmbientModel> ReportVisual_Plumes_Scenario_AmbientModelList = reportServiceVisual_Plumes_Scenario_Ambient.GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_AmbientModelList.Count > 0);
                Assert.AreEqual("", ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Error);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Counter > 0);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_ID > 0);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Ambient_Salinity_PSU);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Ambient_Temperature_C);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Background_Concentration_MPN_100ml);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Current_Direction_deg);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Current_Speed_m_s);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Far_Field_Current_Direction_deg);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Far_Field_Current_Speed_m_s);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Far_Field_Diffusion_Coefficient);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Measurement_Depth_m);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Pollutant_Decay_Rate_per_day);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Row);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                List<VPScenarioModel> vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(tvItemModelInfrastructure.TVItemID);
                Assert.IsTrue(vpScenarioModelList.Count > 0);

                VPScenarioModel vpScenarioModel = vpScenarioModelList.FirstOrDefault();
                Assert.IsNotNull(vpScenarioModel);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario_Ambient " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Visual_Plumes_Scenario";
                bool CountOnly = false;
                int Take = 10;

                List<ReportVisual_Plumes_Scenario_AmbientModel> ReportVisual_Plumes_Scenario_AmbientModelList = reportServiceVisual_Plumes_Scenario_Ambient.GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_AmbientModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPScenario, ServiceRes.VPScenarioID, UnderTVItemID.ToString()), ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                      "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                List<VPScenarioModel> vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(tvItemModelInfrastructure.TVItemID);
                Assert.IsTrue(vpScenarioModelList.Count > 0);

                VPScenarioModel vpScenarioModel = vpScenarioModelList.FirstOrDefault();
                Assert.IsNotNull(vpScenarioModel);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario_Ambient " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = vpScenarioModel.VPScenarioID;
                string ParentTagItem = "Visual_Plumes_Scenario";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Visual_Plumes_Scenario_Ambient";

                List<string> AllowableParentTagItemList = reportServiceVisual_Plumes_Scenario_Ambient._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportVisual_Plumes_Scenario_AmbientModel> ReportVisual_Plumes_Scenario_AmbientModelList = reportServiceVisual_Plumes_Scenario_Ambient.GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_AmbientModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario_Ambient " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportVisual_Plumes_Scenario_AmbientModelList = reportServiceVisual_Plumes_Scenario_Ambient.GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_AmbientModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario_Ambient " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Ambient_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportVisual_Plumes_Scenario_AmbientModelList = reportServiceVisual_Plumes_Scenario_Ambient.GetReportVisual_Plumes_Scenario_AmbientModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_AmbientModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportVisual_Plumes_Scenario_AmbientModelList[0].Visual_Plumes_Scenario_Ambient_Error));
            }
        }
        #endregion Testing Methods Visual_Plumes_Scenario_Ambient
        #region Testing Methods Visual_Plumes_Scenario_Result
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Visual_Plumes_Scenario_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Result_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 28689;
                string ParentTagItem = "Visual_Plumes_Scenario";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Visual_Plumes_Scenario_Result";

                List<ReportVisual_Plumes_Scenario_ResultModel> ReportVisual_Plumes_Scenario_ResultModelList = reportServiceVisual_Plumes_Scenario_Result.GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_ResultModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB_Loop_ParentTagItem_Not_Visual_Plumes_ScenarioError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Result_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 28689;
                string ParentTagItem = "Visual_Plumes_ScenarioNot";
                bool CountOnly = false;
                int Take = 10;

                List<ReportVisual_Plumes_Scenario_ResultModel> ReportVisual_Plumes_Scenario_ResultModelList = reportServiceVisual_Plumes_Scenario_Result.GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_ResultModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Visual_Plumes_Scenario", ParentTagItem), ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                List<VPScenarioModel> vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(tvItemModelInfrastructure.TVItemID);
                Assert.IsTrue(vpScenarioModelList.Count > 0);

                VPScenarioModel vpScenarioModel = vpScenarioModelList.FirstOrDefault();
                Assert.IsNotNull(vpScenarioModel);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Result_Error");
                sb.AppendLine("Visual_Plumes_Scenario_Result_Counter");
                sb.AppendLine("Visual_Plumes_Scenario_Result_ID");
                sb.AppendLine("Visual_Plumes_Scenario_Result_Concentration_MPN_100ml");
                sb.AppendLine("Visual_Plumes_Scenario_Result_Dilution");
                sb.AppendLine("Visual_Plumes_Scenario_Result_Dispersion_Distance_m");
                sb.AppendLine("Visual_Plumes_Scenario_Result_Far_Field_Width_m");
                sb.AppendLine("Visual_Plumes_Scenario_Result_Ordinal");
                sb.AppendLine("Visual_Plumes_Scenario_Result_Travel_Time_hour");
                sb.AppendLine("Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time");
                sb.AppendLine("Visual_Plumes_Scenario_Result_Last_Update_Contact_Name");
                sb.AppendLine("Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = vpScenarioModel.VPScenarioID;
                string ParentTagItem = "Visual_Plumes_Scenario";
                bool CountOnly = false;
                int Take = 10;

                List<ReportVisual_Plumes_Scenario_ResultModel> ReportVisual_Plumes_Scenario_ResultModelList = reportServiceVisual_Plumes_Scenario_Result.GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_ResultModelList.Count > 0);
                Assert.AreEqual("", ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Error);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Counter > 0);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_ID > 0);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Concentration_MPN_100ml);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Dilution);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Dispersion_Distance_m);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Far_Field_Width_m);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Ordinal);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Travel_Time_hour);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                List<VPScenarioModel> vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(tvItemModelInfrastructure.TVItemID);
                Assert.IsTrue(vpScenarioModelList.Count > 0);

                VPScenarioModel vpScenarioModel = vpScenarioModelList.FirstOrDefault();
                Assert.IsNotNull(vpScenarioModel);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Result_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Visual_Plumes_Scenario";
                bool CountOnly = false;
                int Take = 10;

                List<ReportVisual_Plumes_Scenario_ResultModel> ReportVisual_Plumes_Scenario_ResultModelList = reportServiceVisual_Plumes_Scenario_Result.GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_ResultModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPScenario, ServiceRes.VPScenarioID, UnderTVItemID.ToString()), ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                      "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                List<VPScenarioModel> vpScenarioModelList = vpScenarioService.GetVPScenarioModelListWithInfrastructureTVItemIDDB(tvItemModelInfrastructure.TVItemID);
                Assert.IsTrue(vpScenarioModelList.Count > 0);

                VPScenarioModel vpScenarioModel = vpScenarioModelList.FirstOrDefault();
                Assert.IsNotNull(vpScenarioModel);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Result_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = vpScenarioModel.VPScenarioID;
                string ParentTagItem = "Visual_Plumes_Scenario";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Visual_Plumes_Scenario_Result";

                List<string> AllowableParentTagItemList = reportServiceVisual_Plumes_Scenario_Result._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportVisual_Plumes_Scenario_ResultModel> ReportVisual_Plumes_Scenario_ResultModelList = reportServiceVisual_Plumes_Scenario_Result.GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_ResultModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Result_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportVisual_Plumes_Scenario_ResultModelList = reportServiceVisual_Plumes_Scenario_Result.GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_ResultModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Visual_Plumes_Scenario_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Visual_Plumes_Scenario_Result_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportVisual_Plumes_Scenario_ResultModelList = reportServiceVisual_Plumes_Scenario_Result.GetReportVisual_Plumes_Scenario_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportVisual_Plumes_Scenario_ResultModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportVisual_Plumes_Scenario_ResultModelList[0].Visual_Plumes_Scenario_Result_Error));
            }
        }
        #endregion Testing Methods Visual_Plumes_Scenario_Result
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
            reportServiceVisual_Plumes_Scenario = new ReportServiceVisual_Plumes_Scenario((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceVisual_Plumes_Scenario_Ambient = new ReportServiceVisual_Plumes_Scenario_Ambient((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceVisual_Plumes_Scenario_Result = new ReportServiceVisual_Plumes_Scenario_Result((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportServiceVisual_Plumes_Scenario = new ShimReportServiceVisual_Plumes_Scenario(reportServiceVisual_Plumes_Scenario);
        }
        #endregion Functions private
    }
}

