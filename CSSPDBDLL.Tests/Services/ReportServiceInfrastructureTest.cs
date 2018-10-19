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
    public class ReportServiceInfrastructureTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceInfrastructure reportServiceInfrastructure { get; set; }
        private ReportServiceInfrastructure_Address reportServiceInfrastructure_Address { get; set; }
        private ReportServiceInfrastructure_File reportServiceInfrastructure_File { get; set; }
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
        public ReportServiceInfrastructureTest()
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
        #region Testing Methods Infrastructure
        [TestMethod]
        public void ReportService_GetReportInfrastructureModelListUnderTVItemIDDB_Start_Good_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Infrastructure " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_Error");
                sb.AppendLine("Infrastructure_Counter");
                sb.AppendLine("Infrastructure_ID");
                sb.AppendLine("Infrastructure_Is_Active");
                sb.AppendLine("Infrastructure_Last_Update_Date_And_Time");
                sb.AppendLine("Infrastructure_Lat");
                sb.AppendLine("Infrastructure_Lng");
                sb.AppendLine("Infrastructure_Name");
                sb.AppendLine("Infrastructure_Name_Translation_Status");
                sb.AppendLine("Infrastructure_Last_Update_Contact_Name");
                sb.AppendLine("Infrastructure_Last_Update_Contact_Initial");
                sb.AppendLine("Infrastructure_Last_Update_Date_UTC");
                sb.AppendLine("Infrastructure_Aeration_Type");
                sb.AppendLine("Infrastructure_Alarm_System_Type");
                sb.AppendLine("Infrastructure_Average_Depth_m");
                sb.AppendLine("Infrastructure_Average_Flow_m3_day");
                sb.AppendLine("Infrastructure_Can_Overflow");
                sb.AppendLine("Infrastructure_Collection_System_Type");
                sb.AppendLine("Infrastructure_Comment");
                sb.AppendLine("Infrastructure_Comment_Last_Update_Contact_Name");
                sb.AppendLine("Infrastructure_Comment_Last_Update_Contact_Initial");
                sb.AppendLine("Infrastructure_Comment_Last_Update_Date_UTC");
                sb.AppendLine("Infrastructure_Comment_Translation_Status");
                sb.AppendLine("Infrastructure_Decay_Rate_per_day");
                sb.AppendLine("Infrastructure_Design_Flow_m3_day");
                sb.AppendLine("Infrastructure_Disinfection_Type");
                sb.AppendLine("Infrastructure_Distance_From_Shore_m");
                sb.AppendLine("Infrastructure_Facility_Type");
                sb.AppendLine("Infrastructure_Far_Field_Velocity_m_s");
                sb.AppendLine("Infrastructure_Horizontal_Angle_deg");
                sb.AppendLine("Infrastructure_Infrastructure_Category");
                sb.AppendLine("Infrastructure_Infrastructure_Type");
                sb.AppendLine("Infrastructure_Is_Mechanically_Aerated");
                sb.AppendLine("Infrastructure_LSID");
                sb.AppendLine("Infrastructure_Near_Field_Velocity_m_s");
                sb.AppendLine("Infrastructure_Number_Of_Aerated_Cells");
                sb.AppendLine("Infrastructure_Number_Of_Cells");
                sb.AppendLine("Infrastructure_Number_Of_Ports");
                sb.AppendLine("Infrastructure_Outfall_Lat");
                sb.AppendLine("Infrastructure_Outfall_Lng");
                sb.AppendLine("Infrastructure_Peak_Flow_m3_day");
                sb.AppendLine("Infrastructure_Perc_Flow_Of_Total");
                sb.AppendLine("Infrastructure_Pop_Served");
                sb.AppendLine("Infrastructure_Port_Diameter_m");
                sb.AppendLine("Infrastructure_Port_Elevation_m");
                sb.AppendLine("Infrastructure_Port_Spacing_m");
                sb.AppendLine("Infrastructure_Preliminary_Treatment_Type");
                sb.AppendLine("Infrastructure_Primary_Treatment_Type");
                sb.AppendLine("Infrastructure_Prism_ID");
                sb.AppendLine("Infrastructure_Receiving_Water_MPN_per_100_ml");
                sb.AppendLine("Infrastructure_Receiving_Water_Salinity_PSU");
                sb.AppendLine("Infrastructure_Receiving_Water_Temperature_C");
                sb.AppendLine("Infrastructure_Secondary_Treatment_Type");
                sb.AppendLine("Infrastructure_See_Other_ID");
                sb.AppendLine("Infrastructure_Site");
                sb.AppendLine("Infrastructure_Site_ID");
                sb.AppendLine("Infrastructure_Temp_Catch_All_Remove_Later");
                sb.AppendLine("Infrastructure_Tertiary_Treatment_Type");
                sb.AppendLine("Infrastructure_Time_Offset_hour");
                sb.AppendLine("Infrastructure_TPID");
                sb.AppendLine("Infrastructure_Treatment_Type");
                sb.AppendLine("Infrastructure_Vertical_Angle_deg");
                sb.AppendLine("Infrastructure_Stat_Box_Model_Scenario_Count");
                sb.AppendLine("Infrastructure_Stat_Visual_Plumes_Scenario_Count");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelInfrastructure.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportInfrastructureModel> ReportInfrastructureModelList = reportServiceInfrastructure.GetReportInfrastructureModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportInfrastructureModelList.Count > 0);
                Assert.AreEqual("", ReportInfrastructureModelList[0].Infrastructure_Error);
                Assert.AreEqual(1, ReportInfrastructureModelList[0].Infrastructure_Counter);
                Assert.AreEqual(tvItemModelInfrastructure.TVItemID, ReportInfrastructureModelList[0].Infrastructure_ID);
                Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Is_Active);
                Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Last_Update_Date_And_Time_UTC);
                Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Lat != 0.0f);
                Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Lng != 0.0f);
                Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Name_Translation_Status > 0);
                Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Last_Update_Contact_Name.Length > 0);
                Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Last_Update_Contact_Initial.Length > 0);
                Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Last_Update_Date_UTC);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Aeration_Type > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Alarm_System_Type > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Average_Depth_m > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Average_Flow_m3_day > 0);
                //Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Can_Overflow);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Collection_System_Type > 0);
                //Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Comment);
                //Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Comment_Last_Update_Contact_Name);
                //Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Comment_Last_Update_Contact_Initial);
                //Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Comment_Last_Update_Date_UTC);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Comment_Translation_Status > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Decay_Rate_per_day > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Design_Flow_m3_day > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Disinfection_Type > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Distance_From_Shore_m > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Facility_Type > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Far_Field_Velocity_m_s > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Horizontal_Angle_deg > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Infrastructure_Category.Length > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Infrastructure_Type > 0);
                //Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Is_Mechanically_Aerated);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_LSID > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Near_Field_Velocity_m_s > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Number_Of_Aerated_Cells > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Number_Of_Cells > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Number_Of_Ports > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Outfall_Lat > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Outfall_Lng > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Peak_Flow_m3_day > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Perc_Flow_Of_Total > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Pop_Served > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Port_Diameter_m > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Port_Elevation_m > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Port_Spacing_m > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Preliminary_Treatment_Type > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Primary_Treatment_Type > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Prism_ID > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Receiving_Water_MPN_per_100_ml > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Receiving_Water_Salinity_PSU > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Receiving_Water_Temperature_C > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Secondary_Treatment_Type > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_See_Other_ID > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Site > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Site_ID > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Temp_Catch_All_Remove_Later.Length > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Tertiary_Treatment_Type > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Time_Offset_hour > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_TPID > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Treatment_Type > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Vertical_Angle_deg > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Stat_Box_Model_Scenario_Count > 0);
                //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Stat_Visual_Plumes_Scenario_Count > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructureModelListUnderTVItemIDDB_Start_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Infrastructure " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportInfrastructureModel> ReportInfrastructureModelList = reportServiceInfrastructure.GetReportInfrastructureModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportInfrastructureModelList[0].Infrastructure_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructureModelListUnderTVItemIDDB_Start_TVType_Not_Infrastructure_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Infrastructure " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 28475; // Mike scenario should create the expected error
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportInfrastructureModel> ReportInfrastructureModelList = reportServiceInfrastructure.GetReportInfrastructureModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Infrastructure.ToString()), ReportInfrastructureModelList[0].Infrastructure_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructureModelListUnderTVItemIDDB_Start_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Infrastructure " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelInfrastructure.TVItemID;
                string ParentTagItem = tvItemModelInfrastructure.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Infrastructure";

                List<string> AllowableParentTagItemList = reportServiceInfrastructure._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportInfrastructureModel> ReportInfrastructureModelList = reportServiceInfrastructure.GetReportInfrastructureModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportInfrastructureModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportInfrastructureModelList[0].Infrastructure_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Infrastructure " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportInfrastructureModelList = reportServiceInfrastructure.GetReportInfrastructureModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportInfrastructureModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportInfrastructureModelList[0].Infrastructure_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Infrastructure " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportInfrastructureModelList = reportServiceInfrastructure.GetReportInfrastructureModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportInfrastructureModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportInfrastructureModelList[0].Infrastructure_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructureModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelMunicipality, tvItemModelInfrastructure };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Infrastructure " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Infrastructure_Error");
                    sb.AppendLine("Infrastructure_Counter");
                    sb.AppendLine("Infrastructure_ID");
                    sb.AppendLine("Infrastructure_Is_Active");
                    sb.AppendLine("Infrastructure_Last_Update_Date_And_Time");
                    sb.AppendLine("Infrastructure_Lat");
                    sb.AppendLine("Infrastructure_Lng");
                    sb.AppendLine("Infrastructure_Name");
                    sb.AppendLine("Infrastructure_Name_Translation_Status");
                    sb.AppendLine("Infrastructure_Last_Update_Contact_Name");
                    sb.AppendLine("Infrastructure_Last_Update_Contact_Initial");
                    sb.AppendLine("Infrastructure_Last_Update_Date_UTC");
                    sb.AppendLine("Infrastructure_Aeration_Type");
                    sb.AppendLine("Infrastructure_Alarm_System_Type");
                    sb.AppendLine("Infrastructure_Average_Depth_m");
                    sb.AppendLine("Infrastructure_Average_Flow_m3_day");
                    sb.AppendLine("Infrastructure_Can_Overflow");
                    sb.AppendLine("Infrastructure_Collection_System_Type");
                    sb.AppendLine("Infrastructure_Comment");
                    sb.AppendLine("Infrastructure_Comment_Last_Update_Contact_Name");
                    sb.AppendLine("Infrastructure_Comment_Last_Update_Contact_Initial");
                    sb.AppendLine("Infrastructure_Comment_Last_Update_Date_UTC");
                    sb.AppendLine("Infrastructure_Comment_Translation_Status");
                    sb.AppendLine("Infrastructure_Decay_Rate_per_day");
                    sb.AppendLine("Infrastructure_Design_Flow_m3_day");
                    sb.AppendLine("Infrastructure_Disinfection_Type");
                    sb.AppendLine("Infrastructure_Distance_From_Shore_m");
                    sb.AppendLine("Infrastructure_Facility_Type");
                    sb.AppendLine("Infrastructure_Far_Field_Velocity_m_s");
                    sb.AppendLine("Infrastructure_Horizontal_Angle_deg");
                    sb.AppendLine("Infrastructure_Infrastructure_Category");
                    sb.AppendLine("Infrastructure_Infrastructure_Type");
                    sb.AppendLine("Infrastructure_Is_Mechanically_Aerated");
                    sb.AppendLine("Infrastructure_LSID");
                    sb.AppendLine("Infrastructure_Near_Field_Velocity_m_s");
                    sb.AppendLine("Infrastructure_Number_Of_Aerated_Cells");
                    sb.AppendLine("Infrastructure_Number_Of_Cells");
                    sb.AppendLine("Infrastructure_Number_Of_Ports");
                    sb.AppendLine("Infrastructure_Outfall_Lat");
                    sb.AppendLine("Infrastructure_Outfall_Lng");
                    sb.AppendLine("Infrastructure_Peak_Flow_m3_day");
                    sb.AppendLine("Infrastructure_Perc_Flow_Of_Total");
                    sb.AppendLine("Infrastructure_Pop_Served");
                    sb.AppendLine("Infrastructure_Port_Diameter_m");
                    sb.AppendLine("Infrastructure_Port_Elevation_m");
                    sb.AppendLine("Infrastructure_Port_Spacing_m");
                    sb.AppendLine("Infrastructure_Preliminary_Treatment_Type");
                    sb.AppendLine("Infrastructure_Primary_Treatment_Type");
                    sb.AppendLine("Infrastructure_Prism_ID");
                    sb.AppendLine("Infrastructure_Receiving_Water_MPN_per_100_ml");
                    sb.AppendLine("Infrastructure_Receiving_Water_Salinity_PSU");
                    sb.AppendLine("Infrastructure_Receiving_Water_Temperature_C");
                    sb.AppendLine("Infrastructure_Secondary_Treatment_Type");
                    sb.AppendLine("Infrastructure_See_Other_ID");
                    sb.AppendLine("Infrastructure_Site");
                    sb.AppendLine("Infrastructure_Site_ID");
                    sb.AppendLine("Infrastructure_Temp_Catch_All_Remove_Later");
                    sb.AppendLine("Infrastructure_Tertiary_Treatment_Type");
                    sb.AppendLine("Infrastructure_Time_Offset_hour");
                    sb.AppendLine("Infrastructure_TPID");
                    sb.AppendLine("Infrastructure_Treatment_Type");
                    sb.AppendLine("Infrastructure_Vertical_Angle_deg");
                    sb.AppendLine("Infrastructure_Stat_Box_Model_Scenario_Count");
                    sb.AppendLine("Infrastructure_Stat_Visual_Plumes_Scenario_Count");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportInfrastructureModel> ReportInfrastructureModelList = reportServiceInfrastructure.GetReportInfrastructureModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportInfrastructureModelList.Count > 0);
                    Assert.AreEqual("", ReportInfrastructureModelList[0].Infrastructure_Error);
                    Assert.AreEqual(1, ReportInfrastructureModelList[0].Infrastructure_Counter);
                    Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_ID > 0);
                    Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Is_Active);
                    Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Last_Update_Date_And_Time_UTC);
                    Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Lat != 0.0f);
                    Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Lng != 0.0f);
                    Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Name_Translation_Status > 0);
                    Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Last_Update_Contact_Initial.Length > 0);
                    Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Last_Update_Date_UTC);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Aeration_Type > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Alarm_System_Type > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Average_Depth_m > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Average_Flow_m3_day > 0);
                    //Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Can_Overflow);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Collection_System_Type > 0);
                    //Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Comment);
                    //Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Comment_Last_Update_Contact_Name);
                    //Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Comment_Last_Update_Contact_Initial);
                    //Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Comment_Last_Update_Date_UTC);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Comment_Translation_Status > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Decay_Rate_per_day > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Design_Flow_m3_day > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Disinfection_Type > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Distance_From_Shore_m > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Facility_Type > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Far_Field_Velocity_m_s > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Horizontal_Angle_deg > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Infrastructure_Category.Length > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Infrastructure_Type > 0);
                    //Assert.IsNotNull(ReportInfrastructureModelList[0].Infrastructure_Is_Mechanically_Aerated);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_LSID > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Near_Field_Velocity_m_s > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Number_Of_Aerated_Cells > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Number_Of_Cells > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Number_Of_Ports > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Outfall_Lat > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Outfall_Lng > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Peak_Flow_m3_day > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Perc_Flow_Of_Total > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Pop_Served > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Port_Diameter_m > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Port_Elevation_m > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Port_Spacing_m > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Preliminary_Treatment_Type > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Primary_Treatment_Type > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Prism_ID > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Receiving_Water_MPN_per_100_ml > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Receiving_Water_Salinity_PSU > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Receiving_Water_Temperature_C > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Secondary_Treatment_Type > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_See_Other_ID > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Site > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Site_ID > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Temp_Catch_All_Remove_Later.Length > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Tertiary_Treatment_Type > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Time_Offset_hour > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_TPID > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Treatment_Type > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Vertical_Angle_deg > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Stat_Box_Model_Scenario_Count > 0);
                    //Assert.IsTrue(ReportInfrastructureModelList[0].Infrastructure_Stat_Visual_Plumes_Scenario_Count > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructureModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelMunicipality, tvItemModelInfrastructure };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Infrastructure " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Infrastructure_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportInfrastructureModel> ReportInfrastructureModelList = reportServiceInfrastructure.GetReportInfrastructureModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportInfrastructureModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportInfrastructureModelList[0].Infrastructure_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructureModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                TVItemModel tvItemModelInfrastructure = tvItemModelInfrastructureList.Where(c => c.TVText.Contains("WWTP")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);

                TVItemModel tvItemModelPolSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelProvince.TVItemID, TVTypeEnum.PolSourceSite).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPolSource);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Infrastructure " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPolSource.TVItemID;
                string ParentTagItem = tvItemModelPolSource.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Infrastructure";

                List<string> AllowableParentTagItemList = reportServiceInfrastructure._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportInfrastructureModel> ReportInfrastructureModelList = reportServiceInfrastructure.GetReportInfrastructureModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportInfrastructureModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportInfrastructureModelList[0].Infrastructure_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructureModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> tvItemModelInfrastructureList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Infrastructure " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Infrastructure";

                List<string> AllowableParentTagItemList = reportServiceInfrastructure._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportInfrastructureModel> ReportInfrastructureModelList = reportServiceInfrastructure.GetReportInfrastructureModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportInfrastructureModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportInfrastructureModelList[0].Infrastructure_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Infrastructure " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportInfrastructureModelList = reportServiceInfrastructure.GetReportInfrastructureModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportInfrastructureModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportInfrastructureModelList[0].Infrastructure_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Infrastructure " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportInfrastructureModelList = reportServiceInfrastructure.GetReportInfrastructureModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportInfrastructureModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportInfrastructureModelList[0].Infrastructure_Error));
            }
        }
        #endregion Testing Methods Infrastructure
        #region Testing Methods Infrastructure_Address
        [TestMethod]
        public void ReportService_GetReportInfrastructure_AddressModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Infrastructure infrastructure = (from c in tvItemService.db.Infrastructures
                                                 from a in tvItemService.db.Addresses
                                                 where c.CivicAddressTVItemID == a.AddressTVItemID
                                                 && c.CivicAddressTVItemID > 0
                                                 && a.GoogleAddressText != null
                                                 && a.GoogleAddressText.Length > 0
                                                 select c).FirstOrDefault();


                TVItemModel tvItemModelInfrastructure = tvItemService.GetTVItemModelWithTVItemIDDB(infrastructure.InfrastructureTVItemID);
                Assert.AreEqual("", tvItemModelInfrastructure.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelInfrastructure.ParentID);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Infrastructure_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_Address_Error");
                sb.AppendLine("Infrastructure_Address_Counter");
                sb.AppendLine("Infrastructure_Address_ID");
                sb.AppendLine("Infrastructure_Address_Type");
                sb.AppendLine("Infrastructure_Address_Country");
                sb.AppendLine("Infrastructure_Address_Province");
                sb.AppendLine("Infrastructure_Address_Municipality");
                sb.AppendLine("Infrastructure_Address_Street_Name");
                sb.AppendLine("Infrastructure_Address_Street_Number");
                sb.AppendLine("Infrastructure_Address_Street_Type");
                sb.AppendLine("Infrastructure_Address_Postal_Code");
                sb.AppendLine("Infrastructure_Address_Google_Address_Text");
                sb.AppendLine("Infrastructure_Address_Last_Update_Date_And_Time");
                sb.AppendLine("Infrastructure_Address_Last_Update_Contact_Name");
                sb.AppendLine("Infrastructure_Address_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelInfrastructure.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Infrastructure_Address";

                List<ReportInfrastructure_AddressModel> ReportInfrastructure_AddressModelList = reportServiceInfrastructure_Address.GetReportInfrastructure_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructure_AddressModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Infrastructure infrastructure = (from c in tvItemService.db.Infrastructures
                                                 from a in tvItemService.db.Addresses
                                                 where c.CivicAddressTVItemID == a.AddressTVItemID
                                                 && c.CivicAddressTVItemID > 0
                                                 && a.GoogleAddressText != null
                                                 && a.GoogleAddressText.Length > 0
                                                 select c).FirstOrDefault();


                TVItemModel tvItemModelInfrastructure = tvItemService.GetTVItemModelWithTVItemIDDB(infrastructure.InfrastructureTVItemID);
                Assert.AreEqual("", tvItemModelInfrastructure.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelInfrastructure.ParentID);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, */
                    tvItemModelMunicipality, tvItemModelInfrastructure };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Infrastructure_Address " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Infrastructure_Address_Error");
                    sb.AppendLine("Infrastructure_Address_Counter");
                    sb.AppendLine("Infrastructure_Address_ID");
                    sb.AppendLine("Infrastructure_Address_Type");
                    sb.AppendLine("Infrastructure_Address_Country");
                    sb.AppendLine("Infrastructure_Address_Province");
                    sb.AppendLine("Infrastructure_Address_Municipality");
                    sb.AppendLine("Infrastructure_Address_Street_Name");
                    sb.AppendLine("Infrastructure_Address_Street_Number");
                    sb.AppendLine("Infrastructure_Address_Street_Type");
                    sb.AppendLine("Infrastructure_Address_Postal_Code");
                    sb.AppendLine("Infrastructure_Address_Google_Address_Text");
                    sb.AppendLine("Infrastructure_Address_Last_Update_Date_And_Time");
                    sb.AppendLine("Infrastructure_Address_Last_Update_Contact_Name");
                    sb.AppendLine("Infrastructure_Address_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportInfrastructure_AddressModel> ReportInfrastructure_AddressModelList = reportServiceInfrastructure_Address.GetReportInfrastructure_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportInfrastructure_AddressModelList.Count > 0);
                    Assert.AreEqual("", ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Error);
                    Assert.IsTrue(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Counter > 0);
                    Assert.IsTrue(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_ID > 0);
                    Assert.IsNotNull(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Type);
                    Assert.IsNotNull(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Country);
                    Assert.IsNotNull(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Province);
                    Assert.IsNotNull(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Municipality);
                    Assert.IsNotNull(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Street_Name);
                    Assert.IsNotNull(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Street_Number);
                    Assert.IsNotNull(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Street_Type);
                    Assert.IsNotNull(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Postal_Code);
                    Assert.IsNotNull(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Google_Address_Text);
                    Assert.IsNotNull(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Last_Update_Date_And_Time_UTC);
                    Assert.IsNotNull(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Last_Update_Contact_Initial);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructure_AddressModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Infrastructure infrastructure = (from c in tvItemService.db.Infrastructures
                                                 from a in tvItemService.db.Addresses
                                                 where c.CivicAddressTVItemID == a.AddressTVItemID
                                                 && c.CivicAddressTVItemID > 0
                                                 && a.GoogleAddressText != null
                                                 && a.GoogleAddressText.Length > 0
                                                 select c).FirstOrDefault();


                TVItemModel tvItemModelInfrastructure = tvItemService.GetTVItemModelWithTVItemIDDB(infrastructure.InfrastructureTVItemID);
                Assert.AreEqual("", tvItemModelInfrastructure.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelInfrastructure.ParentID);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, */
                    tvItemModelMunicipality, tvItemModelInfrastructure };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Infrastructure_Address " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Infrastructure_Address_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportInfrastructure_AddressModel> ReportInfrastructure_AddressModelList = reportServiceInfrastructure_Address.GetReportInfrastructure_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportInfrastructure_AddressModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructure_AddressModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Infrastructure infrastructure = (from c in tvItemService.db.Infrastructures
                                                 from a in tvItemService.db.Addresses
                                                 where c.CivicAddressTVItemID == a.AddressTVItemID
                                                 && c.CivicAddressTVItemID > 0
                                                 && a.GoogleAddressText != null
                                                 && a.GoogleAddressText.Length > 0
                                                 select c).FirstOrDefault();


                TVItemModel tvItemModelInfrastructure = tvItemService.GetTVItemModelWithTVItemIDDB(infrastructure.InfrastructureTVItemID);
                Assert.AreEqual("", tvItemModelInfrastructure.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelInfrastructure.ParentID);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelPolSourceSite = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelRoot.TVItemID, TVTypeEnum.PolSourceSite).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPolSourceSite);


                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Infrastructure_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_Address_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPolSourceSite.TVItemID;
                string ParentTagItem = "Pol_Source_Site"; // will create error
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Infrastructure_Address";

                List<string> AllowableParentTagItemList = reportServiceInfrastructure._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportInfrastructure_AddressModel> ReportInfrastructure_AddressModelList = reportServiceInfrastructure_Address.GetReportInfrastructure_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportInfrastructure_AddressModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructure_AddressModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Infrastructure infrastructure = (from c in tvItemService.db.Infrastructures
                                                 from a in tvItemService.db.Addresses
                                                 where c.CivicAddressTVItemID == a.AddressTVItemID
                                                 && c.CivicAddressTVItemID > 0
                                                 && a.GoogleAddressText != null
                                                 && a.GoogleAddressText.Length > 0
                                                 select c).FirstOrDefault();


                TVItemModel tvItemModelInfrastructure = tvItemService.GetTVItemModelWithTVItemIDDB(infrastructure.InfrastructureTVItemID);
                Assert.AreEqual("", tvItemModelInfrastructure.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelInfrastructure.ParentID);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Infrastructure_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_Address_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Infrastructure_Address";

                List<string> AllowableParentTagItemList = reportServiceInfrastructure._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportInfrastructure_AddressModel> ReportInfrastructure_AddressModelList = reportServiceInfrastructure_Address.GetReportInfrastructure_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportInfrastructure_AddressModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Infrastructure_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_Address_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportInfrastructure_AddressModelList = reportServiceInfrastructure_Address.GetReportInfrastructure_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportInfrastructure_AddressModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Infrastructure_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Infrastructure_Address_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportInfrastructure_AddressModelList = reportServiceInfrastructure_Address.GetReportInfrastructure_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportInfrastructure_AddressModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportInfrastructure_AddressModelList[0].Infrastructure_Address_Error));
            }
        }
        #endregion Testing Methods Infrastructure_Address
        #region Testing Methods Infrastructure_File
        [TestMethod]
        public void ReportService_GetReportInfrastructure_FileModelListUnderTVItemIDDB_Good_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                TVItemModel tvItemModelInfrastructure = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelMunicipality.TVItemID, "Bouctouche WWTP", TVTypeEnum.Infrastructure);
                Assert.AreEqual("", tvItemModelInfrastructure.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelInfrastructure };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Infrastructure_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Infrastructure_File_Error");
                    sb.AppendLine("Infrastructure_File_Counter");
                    sb.AppendLine("Infrastructure_File_ID");
                    sb.AppendLine("Infrastructure_File_Language");
                    sb.AppendLine("Infrastructure_File_File_Purpose");
                    sb.AppendLine("Infrastructure_File_File_Type");
                    sb.AppendLine("Infrastructure_File_File_Description");
                    sb.AppendLine("Infrastructure_File_File_Size_kb");
                    sb.AppendLine("Infrastructure_File_File_Info");
                    sb.AppendLine("Infrastructure_File_File_Created_Date_UTC");
                    sb.AppendLine("Infrastructure_File_From_Water");
                    sb.AppendLine("Infrastructure_File_Server_File_Name");
                    sb.AppendLine("Infrastructure_File_Server_File_Path");
                    sb.AppendLine("Infrastructure_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Infrastructure_File_Last_Update_Contact_Name");
                    sb.AppendLine("Infrastructure_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportInfrastructure_FileModel> ReportInfrastructure_FileModelList = reportServiceInfrastructure_File.GetReportInfrastructure_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportInfrastructure_FileModelList.Count > 0);
                    Assert.IsTrue(ReportInfrastructure_FileModelList[0].Infrastructure_File_Error == "");
                    Assert.IsTrue(ReportInfrastructure_FileModelList[0].Infrastructure_File_Counter > 0);
                    Assert.IsTrue(ReportInfrastructure_FileModelList[0].Infrastructure_File_ID > 0);
                    Assert.IsTrue((int)ReportInfrastructure_FileModelList[0].Infrastructure_File_Language > 0);
                    Assert.IsTrue((int)ReportInfrastructure_FileModelList[0].Infrastructure_File_File_Purpose > 0);
                    Assert.IsTrue((int)ReportInfrastructure_FileModelList[0].Infrastructure_File_File_Type > 0);
                    Assert.IsTrue(ReportInfrastructure_FileModelList[0].Infrastructure_File_File_Description.Length > 0);
                    Assert.IsTrue(ReportInfrastructure_FileModelList[0].Infrastructure_File_File_Size_kb > 0);
                    Assert.IsTrue(ReportInfrastructure_FileModelList[0].Infrastructure_File_File_Info.Length > 0);
                    Assert.IsNotNull(ReportInfrastructure_FileModelList[0].Infrastructure_File_File_Created_Date_UTC);
                    //Assert.IsNotNull(ReportInfrastructure_FileModelList[0].Infrastructure_File_From_Water);
                    Assert.IsTrue(ReportInfrastructure_FileModelList[0].Infrastructure_File_Server_File_Name.Length > 0);
                    Assert.IsTrue(ReportInfrastructure_FileModelList[0].Infrastructure_File_Server_File_Path.Length > 0);
                    Assert.IsTrue(ReportInfrastructure_FileModelList[0].Infrastructure_File_Last_Update_Date_And_Time_UTC > new DateTime(1979, 1, 1));
                    Assert.IsTrue(ReportInfrastructure_FileModelList[0].Infrastructure_File_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportInfrastructure_FileModelList[0].Infrastructure_File_Last_Update_Contact_Initial.Length > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructure_FileModelListUnderTVItemIDDB_Good_CountOnly_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                TVItemModel tvItemModelInfrastructure = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelMunicipality.TVItemID, "Bouctouche WWTP", TVTypeEnum.Infrastructure);
                Assert.AreEqual("", tvItemModelInfrastructure.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelInfrastructure };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Infrastructure_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Infrastructure_File_Error");
                    sb.AppendLine("Infrastructure_File_Counter");
                    sb.AppendLine("Infrastructure_File_ID");
                    sb.AppendLine("Infrastructure_File_Language");
                    sb.AppendLine("Infrastructure_File_File_Purpose");
                    sb.AppendLine("Infrastructure_File_File_Type");
                    sb.AppendLine("Infrastructure_File_File_Description");
                    sb.AppendLine("Infrastructure_File_File_Size_kb");
                    sb.AppendLine("Infrastructure_File_File_Info");
                    sb.AppendLine("Infrastructure_File_File_Created_Date_UTC");
                    sb.AppendLine("Infrastructure_File_From_Water");
                    sb.AppendLine("Infrastructure_File_Server_File_Name");
                    sb.AppendLine("Infrastructure_File_Server_File_Path");
                    sb.AppendLine("Infrastructure_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Infrastructure_File_Last_Update_Contact_Name");
                    sb.AppendLine("Infrastructure_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = true;
                    int Take = 10;

                    List<ReportInfrastructure_FileModel> ReportInfrastructure_FileModelList = reportServiceInfrastructure_File.GetReportInfrastructure_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportInfrastructure_FileModelList.Count == 1);
                    Assert.IsTrue(ReportInfrastructure_FileModelList[0].Infrastructure_File_Counter > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructure_FileModelListUnderTVItemIDDB_Error_Start_Tag_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                TVItemModel tvItemModelInfrastructure = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelMunicipality.TVItemID, "Bouctouche WWTP", TVTypeEnum.Infrastructure);
                Assert.AreEqual("", tvItemModelInfrastructure.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelInfrastructure };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Infrastructure_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Infrastructure_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Infrastructure_File";

                    List<ReportInfrastructure_FileModel> ReportInfrastructure_FileModelList = reportServiceInfrastructure_File.GetReportInfrastructure_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportInfrastructure_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportInfrastructure_FileModelList[0].Infrastructure_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructure_FileModelListUnderTVItemIDDB_Error_TVItem_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                TVItemModel tvItemModelInfrastructure = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelMunicipality.TVItemID, "Bouctouche WWTP", TVTypeEnum.Infrastructure);
                Assert.AreEqual("", tvItemModelInfrastructure.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelInfrastructure };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Infrastructure_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Infrastructure_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportInfrastructure_FileModel> ReportInfrastructure_FileModelList = reportServiceInfrastructure_File.GetReportInfrastructure_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportInfrastructure_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportInfrastructure_FileModelList[0].Infrastructure_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructure_FileModelListUnderTVItemIDDB_Error_ParentTagItem_Empty_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                TVItemModel tvItemModelInfrastructure = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelMunicipality.TVItemID, "Bouctouche WWTP", TVTypeEnum.Infrastructure);
                Assert.AreEqual("", tvItemModelInfrastructure.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelInfrastructure };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Infrastructure_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Infrastructure_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportInfrastructure_FileModel> ReportInfrastructure_FileModelList = reportServiceInfrastructure_File.GetReportInfrastructure_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportInfrastructure_FileModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.ParentTagItemShouldNotBeEmpty, ReportInfrastructure_FileModelList[0].Infrastructure_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructure_FileModelListUnderTVItemIDDB_Error_Allowable_ParentTagItem_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                TVItemModel tvItemModelInfrastructure = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelMunicipality.TVItemID, "Bouctouche WWTP", TVTypeEnum.Infrastructure);
                Assert.AreEqual("", tvItemModelInfrastructure.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelInfrastructure };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Infrastructure_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Infrastructure_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "Pol_Source_Site";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Infrastructure_File";

                    List<string> AllowableParentTagItemList = reportServiceInfrastructure._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportInfrastructure_FileModel> ReportInfrastructure_FileModelList = reportServiceInfrastructure_File.GetReportInfrastructure_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportInfrastructure_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportInfrastructure_FileModelList[0].Infrastructure_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportInfrastructure_FileModelListUnderTVItemIDDB_Error_GetReportTreeNodesFromTagText_Test()
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

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                TVItemModel tvItemModelInfrastructure = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelMunicipality.TVItemID, "Bouctouche WWTP", TVTypeEnum.Infrastructure);
                Assert.AreEqual("", tvItemModelInfrastructure.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelInfrastructure };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Infrastructure_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Infrastructure_File_IDNot"); // line 2
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportInfrastructure_FileModel> ReportInfrastructure_FileModelList = reportServiceInfrastructure_File.GetReportInfrastructure_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportInfrastructure_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ReportServiceRes._DoesNotExistFor_, "Infrastructure_File_IDNot", "CSSPModelsDLL.Models.ReportInfrastructure_FileModel"), ReportInfrastructure_FileModelList[0].Infrastructure_File_Error);
                }
            }
        }
        #endregion Testing Methods Infrastructure_File
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
            reportServiceInfrastructure = new ReportServiceInfrastructure((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceInfrastructure_Address = new ReportServiceInfrastructure_Address((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceInfrastructure_File = new ReportServiceInfrastructure_File((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceInfrastructure);
        }
        #endregion Functions private
    }
}

