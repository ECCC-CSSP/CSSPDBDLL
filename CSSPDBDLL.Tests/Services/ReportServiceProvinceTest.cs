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
    public class ReportServiceProvinceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceProvince reportServiceProvince { get; set; }
        private ReportServiceProvince_File reportServiceProvince_File { get; set; }
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
        public ReportServiceProvinceTest()
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
        #region Testing Methods Province
        [TestMethod]
        public void ReportService_GetReportProvinceModelListUnderTVItemIDDB_Start_Good_Test()
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
                sb.AppendLine("|||Start Province " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Province_Error");
                sb.AppendLine("Province_Counter");
                sb.AppendLine("Province_ID");
                sb.AppendLine("Province_Name_Translation_Status");
                sb.AppendLine("Province_Name");
                sb.AppendLine("Province_Initial");
                sb.AppendLine("Province_Is_Active");
                sb.AppendLine("Province_Last_Update_Date_And_Time");
                sb.AppendLine("Province_Last_Update_Contact_Name");
                sb.AppendLine("Province_Last_Update_Contact_Initial");
                sb.AppendLine("Province_Lat");
                sb.AppendLine("Province_Lng");
                sb.AppendLine("Province_Stat_Area_Count");
                sb.AppendLine("Province_Stat_Sector_Count");
                sb.AppendLine("Province_Stat_Subsector_Count");
                sb.AppendLine("Province_Stat_Municipality_Count");
                sb.AppendLine("Province_Stat_Lift_Station_Count");
                sb.AppendLine("Province_Stat_WWTP_Count");
                sb.AppendLine("Province_Stat_MWQM_Sample_Count");
                sb.AppendLine("Province_Stat_MWQM_Site_Count");
                sb.AppendLine("Province_Stat_MWQM_Run_Count");
                sb.AppendLine("Province_Stat_Pol_Source_Site_Count");
                sb.AppendLine("Province_Stat_Mike_Scenario_Count");
                sb.AppendLine("Province_Stat_Box_Model_Scenario_Count");
                sb.AppendLine("Province_Stat_Visual_Plumes_Scenario_Count");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportProvinceModel> ReportProvinceModelList = reportServiceProvince.GetReportProvinceModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportProvinceModelList.Count > 0);
                Assert.AreEqual("", ReportProvinceModelList[0].Province_Error);
                Assert.AreEqual(1, ReportProvinceModelList[0].Province_Counter);
                Assert.AreEqual(tvItemModelProvince.TVItemID, ReportProvinceModelList[0].Province_ID);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Name.Length > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Initial.Length > 0);
                Assert.IsNotNull(ReportProvinceModelList[0].Province_Name_Translation_Status);
                Assert.IsNotNull(ReportProvinceModelList[0].Province_Last_Update_Date_And_Time_UTC);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Last_Update_Contact_Name.Length > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Last_Update_Contact_Initial.Length > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Lat != 0.0f);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Lng != 0.0f);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Area_Count > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Sector_Count > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Subsector_Count > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Municipality_Count > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Lift_Station_Count > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_WWTP_Count > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_MWQM_Sample_Count > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_MWQM_Site_Count > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_MWQM_Run_Count > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Pol_Source_Site_Count > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Mike_Scenario_Count > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Box_Model_Scenario_Count > 0);
                Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Visual_Plumes_Scenario_Count > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvinceModelListUnderTVItemIDDB_Start_TVItem_Null_Error_Test()
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
                sb.AppendLine("|||Start Province " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Province_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportProvinceModel> ReportProvinceModelList = reportServiceProvince.GetReportProvinceModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportProvinceModelList[0].Province_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvinceModelListUnderTVItemIDDB_Start_TVType_Not_Province_Error_Test()
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
                sb.AppendLine("|||Start Province " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Province_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportProvinceModel> ReportProvinceModelList = reportServiceProvince.GetReportProvinceModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Province.ToString()), ReportProvinceModelList[0].Province_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvinceModelListUnderTVItemIDDB_Start_GetReportTreeNodesFromTagText_Error_Test()
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
                sb.AppendLine("|||Start Province " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Province_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Province";

                List<string> AllowableParentTagItemList = reportServiceProvince._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportProvinceModel> ReportProvinceModelList = reportServiceProvince.GetReportProvinceModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportProvinceModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportProvinceModelList[0].Province_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Province " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Province_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportProvinceModelList = reportServiceProvince.GetReportProvinceModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportProvinceModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportProvinceModelList[0].Province_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Province " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Province_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportProvinceModelList = reportServiceProvince.GetReportProvinceModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportProvinceModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportProvinceModelList[0].Province_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvinceModelListUnderTVItemIDDB_Loop_Good_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, */ tvItemModelCountry, tvItemModelProvince };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Province " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Province_Error");
                    sb.AppendLine("Province_Counter");
                    sb.AppendLine("Province_ID");
                    sb.AppendLine("Province_Name_Translation_Status");
                    sb.AppendLine("Province_Name");
                    sb.AppendLine("Province_Initial");
                    sb.AppendLine("Province_Is_Active");
                    sb.AppendLine("Province_Last_Update_Date_And_Time");
                    sb.AppendLine("Province_Last_Update_Contact_Name");
                    sb.AppendLine("Province_Last_Update_Contact_Initial");
                    sb.AppendLine("Province_Lat");
                    sb.AppendLine("Province_Lng");
                    sb.AppendLine("Province_Stat_Area_Count");
                    sb.AppendLine("Province_Stat_Sector_Count");
                    sb.AppendLine("Province_Stat_Subsector_Count");
                    sb.AppendLine("Province_Stat_Municipality_Count");
                    sb.AppendLine("Province_Stat_Lift_Station_Count");
                    sb.AppendLine("Province_Stat_WWTP_Count");
                    sb.AppendLine("Province_Stat_MWQM_Sample_Count");
                    sb.AppendLine("Province_Stat_MWQM_Site_Count");
                    sb.AppendLine("Province_Stat_MWQM_Run_Count");
                    sb.AppendLine("Province_Stat_Pol_Source_Site_Count");
                    sb.AppendLine("Province_Stat_Mike_Scenario_Count");
                    sb.AppendLine("Province_Stat_Box_Model_Scenario_Count");
                    sb.AppendLine("Province_Stat_Visual_Plumes_Scenario_Count");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportProvinceModel> ReportProvinceModelList = reportServiceProvince.GetReportProvinceModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportProvinceModelList.Count > 0);
                    Assert.AreEqual("", ReportProvinceModelList[0].Province_Error);
                    Assert.AreEqual(1, ReportProvinceModelList[0].Province_Counter);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_ID > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Name.Length > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Initial.Length > 0);
                    Assert.IsNotNull(ReportProvinceModelList[0].Province_Name_Translation_Status);
                    Assert.IsNotNull(ReportProvinceModelList[0].Province_Last_Update_Date_And_Time_UTC);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Last_Update_Contact_Initial.Length > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Lat != 0.0f);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Lng != 0.0f);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Area_Count > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Sector_Count > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Subsector_Count > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Municipality_Count > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Lift_Station_Count > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_WWTP_Count > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_MWQM_Sample_Count > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_MWQM_Site_Count > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_MWQM_Run_Count > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Pol_Source_Site_Count > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Mike_Scenario_Count > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Box_Model_Scenario_Count > 0);
                    Assert.IsTrue(ReportProvinceModelList[0].Province_Stat_Visual_Plumes_Scenario_Count > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvinceModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, */
                    tvItemModelProvince, tvItemModelProvince };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Province " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Province_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportProvinceModel> ReportProvinceModelList = reportServiceProvince.GetReportProvinceModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportProvinceModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportProvinceModelList[0].Province_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvinceModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06-020", TVTypeEnum.Sector);
                Assert.AreEqual("", tvItemModelSector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Province " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Province_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSector.TVItemID;
                string ParentTagItem = tvItemModelSector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Province";

                List<string> AllowableParentTagItemList = reportServiceProvince._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportProvinceModel> ReportProvinceModelList = reportServiceProvince.GetReportProvinceModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportProvinceModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportProvinceModelList[0].Province_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvinceModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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
                sb.AppendLine("|||Loop Province " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Province_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Province";

                List<string> AllowableParentTagItemList = reportServiceProvince._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportProvinceModel> ReportProvinceModelList = reportServiceProvince.GetReportProvinceModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportProvinceModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportProvinceModelList[0].Province_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Province " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Province_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportProvinceModelList = reportServiceProvince.GetReportProvinceModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportProvinceModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportProvinceModelList[0].Province_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Province " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Province_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportProvinceModelList = reportServiceProvince.GetReportProvinceModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportProvinceModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportProvinceModelList[0].Province_Error));
            }
        }
        #endregion Testing Methods Province
        #region Testing Methods Province_File
        [TestMethod]
        public void ReportService_GetReportProvince_FileModelListUnderTVItemIDDB_Good_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Province_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Province_File_Error");
                    sb.AppendLine("Province_File_Counter");
                    sb.AppendLine("Province_File_ID");
                    sb.AppendLine("Province_File_Language");
                    sb.AppendLine("Province_File_File_Purpose");
                    sb.AppendLine("Province_File_File_Type");
                    sb.AppendLine("Province_File_File_Description");
                    sb.AppendLine("Province_File_File_Size_kb");
                    sb.AppendLine("Province_File_File_Info");
                    sb.AppendLine("Province_File_File_Created_Date_UTC");
                    sb.AppendLine("Province_File_From_Water");
                    sb.AppendLine("Province_File_Server_File_Name");
                    sb.AppendLine("Province_File_Server_File_Path");
                    sb.AppendLine("Province_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Province_File_Last_Update_Contact_Name");
                    sb.AppendLine("Province_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportProvince_FileModel> ReportProvince_FileModelList = reportServiceProvince_File.GetReportProvince_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportProvince_FileModelList.Count > 0);
                    Assert.IsTrue(ReportProvince_FileModelList[0].Province_File_Error == "");
                    Assert.IsTrue(ReportProvince_FileModelList[0].Province_File_Counter > 0);
                    Assert.IsTrue(ReportProvince_FileModelList[0].Province_File_ID > 0);
                    Assert.IsTrue((int)ReportProvince_FileModelList[0].Province_File_Language > 0);
                    Assert.IsTrue((int)ReportProvince_FileModelList[0].Province_File_File_Purpose > 0);
                    Assert.IsTrue((int)ReportProvince_FileModelList[0].Province_File_File_Type > 0);
                    Assert.IsTrue(ReportProvince_FileModelList[0].Province_File_File_Description.Length > 0);
                    Assert.IsTrue(ReportProvince_FileModelList[0].Province_File_File_Size_kb > 0);
                    Assert.IsTrue(ReportProvince_FileModelList[0].Province_File_File_Info.Length > 0);
                    Assert.IsNotNull(ReportProvince_FileModelList[0].Province_File_File_Created_Date_UTC);
                    //Assert.IsNotNull(ReportProvince_FileModelList[0].Province_File_From_Water);
                    Assert.IsTrue(ReportProvince_FileModelList[0].Province_File_Server_File_Name.Length > 0);
                    Assert.IsTrue(ReportProvince_FileModelList[0].Province_File_Server_File_Path.Length > 0);
                    Assert.IsTrue(ReportProvince_FileModelList[0].Province_File_Last_Update_Date_And_Time_UTC > new DateTime(1979, 1, 1));
                    Assert.IsTrue(ReportProvince_FileModelList[0].Province_File_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportProvince_FileModelList[0].Province_File_Last_Update_Contact_Initial.Length > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvince_FileModelListUnderTVItemIDDB_Good_CountOnly_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Province_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Province_File_Error");
                    sb.AppendLine("Province_File_Counter");
                    sb.AppendLine("Province_File_ID");
                    sb.AppendLine("Province_File_Language");
                    sb.AppendLine("Province_File_File_Purpose");
                    sb.AppendLine("Province_File_File_Type");
                    sb.AppendLine("Province_File_File_Description");
                    sb.AppendLine("Province_File_File_Size_kb");
                    sb.AppendLine("Province_File_File_Info");
                    sb.AppendLine("Province_File_File_Created_Date_UTC");
                    sb.AppendLine("Province_File_From_Water");
                    sb.AppendLine("Province_File_Server_File_Name");
                    sb.AppendLine("Province_File_Server_File_Path");
                    sb.AppendLine("Province_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Province_File_Last_Update_Contact_Name");
                    sb.AppendLine("Province_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = true;
                    int Take = 10;

                    List<ReportProvince_FileModel> ReportProvince_FileModelList = reportServiceProvince_File.GetReportProvince_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportProvince_FileModelList.Count == 1);
                    Assert.IsTrue(ReportProvince_FileModelList[0].Province_File_Counter > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvince_FileModelListUnderTVItemIDDB_Error_Start_Tag_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Province_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Province_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Province_File";

                    List<ReportProvince_FileModel> ReportProvince_FileModelList = reportServiceProvince_File.GetReportProvince_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportProvince_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportProvince_FileModelList[0].Province_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvince_FileModelListUnderTVItemIDDB_Error_TVItem_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Province_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Province_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportProvince_FileModel> ReportProvince_FileModelList = reportServiceProvince_File.GetReportProvince_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportProvince_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportProvince_FileModelList[0].Province_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvince_FileModelListUnderTVItemIDDB_Error_ParentTagItem_Empty_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Province_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Province_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportProvince_FileModel> ReportProvince_FileModelList = reportServiceProvince_File.GetReportProvince_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportProvince_FileModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.ParentTagItemShouldNotBeEmpty, ReportProvince_FileModelList[0].Province_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvince_FileModelListUnderTVItemIDDB_Error_Allowable_ParentTagItem_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Province_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Province_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "Municipality";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Province_File";

                    List<string> AllowableParentTagItemList = reportServiceProvince._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportProvince_FileModel> ReportProvince_FileModelList = reportServiceProvince_File.GetReportProvince_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportProvince_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportProvince_FileModelList[0].Province_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportProvince_FileModelListUnderTVItemIDDB_Error_GetReportTreeNodesFromTagText_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Province_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Province_File_IDNot"); // line 2
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportProvince_FileModel> ReportProvince_FileModelList = reportServiceProvince_File.GetReportProvince_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportProvince_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ReportServiceRes._DoesNotExistFor_, "Province_File_IDNot", "CSSPModelsDLL.Models.ReportProvince_FileModel"), ReportProvince_FileModelList[0].Province_File_Error);
                }
            }
        }
        #endregion Testing Methods Province_File
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
            reportServiceProvince = new ReportServiceProvince((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceProvince_File = new ReportServiceProvince_File((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceProvince);
        }
        #endregion Functions private
    }
}

