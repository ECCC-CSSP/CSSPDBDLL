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
    public class ReportServiceSectorTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceSector reportServiceSector { get; set; }
        private ReportServiceSector_File reportServiceSector_File { get; set; }
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
        public ReportServiceSectorTest()
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
        #region Testing Methods Sector
        [TestMethod]
        public void ReportService_GetReportSectorModelListUnderTVItemIDDB_Start_Good_Test()
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
                sb.AppendLine("|||Start Sector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Sector_Error");
                sb.AppendLine("Sector_Counter");
                sb.AppendLine("Sector_ID");
                sb.AppendLine("Sector_Name_Translation_Status");
                sb.AppendLine("Sector_Name_Long");
                sb.AppendLine("Sector_Name_Short");
                sb.AppendLine("Sector_Is_Active");
                sb.AppendLine("Sector_Last_Update_Date_And_Time");
                sb.AppendLine("Sector_Last_Update_Contact_Name");
                sb.AppendLine("Sector_Last_Update_Contact_Initial");
                sb.AppendLine("Sector_Lat");
                sb.AppendLine("Sector_Lng");
                sb.AppendLine("Sector_Stat_Subsector_Count");
                sb.AppendLine("Sector_Stat_Municipality_Count");
                sb.AppendLine("Sector_Stat_Lift_Station_Count");
                sb.AppendLine("Sector_Stat_WWTP_Count");
                sb.AppendLine("Sector_Stat_MWQM_Sample_Count");
                sb.AppendLine("Sector_Stat_MWQM_Site_Count");
                sb.AppendLine("Sector_Stat_MWQM_Run_Count");
                sb.AppendLine("Sector_Stat_Pol_Source_Site_Count");
                sb.AppendLine("Sector_Stat_Mike_Scenario_Count");
                sb.AppendLine("Sector_Stat_Box_Model_Scenario_Count");
                sb.AppendLine("Sector_Stat_Visual_Plumes_Scenario_Count");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSector.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSectorModel> ReportSectorModelList = reportServiceSector.GetReportSectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSectorModelList.Count > 0);
                Assert.AreEqual("", ReportSectorModelList[0].Sector_Error);
                Assert.AreEqual(1, ReportSectorModelList[0].Sector_Counter);
                Assert.AreEqual(tvItemModelSector.TVItemID, ReportSectorModelList[0].Sector_ID);
                Assert.IsNotNull(ReportSectorModelList[0].Sector_Name_Translation_Status);
                Assert.IsNotNull(ReportSectorModelList[0].Sector_Last_Update_Date_And_Time_UTC);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Last_Update_Contact_Name.Length > 0);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Last_Update_Contact_Initial.Length > 0);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Lat != 0.0f);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Lng != 0.0f);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Subsector_Count > 0);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Municipality_Count > 0);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Lift_Station_Count > 0);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_WWTP_Count > 0);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_MWQM_Sample_Count > 0);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_MWQM_Site_Count > 0);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_MWQM_Run_Count > 0);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Pol_Source_Site_Count > 0);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Mike_Scenario_Count > 0);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Box_Model_Scenario_Count > 0);
                Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Visual_Plumes_Scenario_Count > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSectorModelListUnderTVItemIDDB_Start_TVItem_Null_Error_Test()
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
                sb.AppendLine("|||Start Sector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Sector_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSectorModel> ReportSectorModelList = reportServiceSector.GetReportSectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportSectorModelList[0].Sector_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSectorModelListUnderTVItemIDDB_Start_TVType_Not_Sector_Error_Test()
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
                sb.AppendLine("|||Start Sector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Sector_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSectorModel> ReportSectorModelList = reportServiceSector.GetReportSectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Sector.ToString()), ReportSectorModelList[0].Sector_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSectorModelListUnderTVItemIDDB_Start_GetReportTreeNodesFromTagText_Error_Test()
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
                sb.AppendLine("|||Start Sector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Sector_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Sector";

                List<string> AllowableParentTagItemList = reportServiceSector._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSectorModel> ReportSectorModelList = reportServiceSector.GetReportSectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSectorModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSectorModelList[0].Sector_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Sector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Sector_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSectorModelList = reportServiceSector.GetReportSectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSectorModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSectorModelList[0].Sector_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Sector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Sector_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSectorModelList = reportServiceSector.GetReportSectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSectorModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSectorModelList[0].Sector_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportSectorModelListUnderTVItemIDDB_Loop_Good_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, */
                    tvItemModelProvince, tvItemModelSector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Sector " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Sector_Error");
                    sb.AppendLine("Sector_Counter");
                    sb.AppendLine("Sector_ID");
                    sb.AppendLine("Sector_Name_Translation_Status");
                    sb.AppendLine("Sector_Name_Long");
                    sb.AppendLine("Sector_Name_Short");
                    sb.AppendLine("Sector_Is_Active");
                    sb.AppendLine("Sector_Last_Update_Date_And_Time");
                    sb.AppendLine("Sector_Last_Update_Contact_Name");
                    sb.AppendLine("Sector_Last_Update_Contact_Initial");
                    sb.AppendLine("Sector_Lat");
                    sb.AppendLine("Sector_Lng");
                    sb.AppendLine("Sector_Stat_Subsector_Count");
                    sb.AppendLine("Sector_Stat_Municipality_Count");
                    sb.AppendLine("Sector_Stat_Lift_Station_Count");
                    sb.AppendLine("Sector_Stat_WWTP_Count");
                    sb.AppendLine("Sector_Stat_MWQM_Sample_Count");
                    sb.AppendLine("Sector_Stat_MWQM_Site_Count");
                    sb.AppendLine("Sector_Stat_MWQM_Run_Count");
                    sb.AppendLine("Sector_Stat_Pol_Source_Site_Count");
                    sb.AppendLine("Sector_Stat_Mike_Scenario_Count");
                    sb.AppendLine("Sector_Stat_Box_Model_Scenario_Count");
                    sb.AppendLine("Sector_Stat_Visual_Plumes_Scenario_Count");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSectorModel> ReportSectorModelList = reportServiceSector.GetReportSectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSectorModelList.Count > 0);
                    Assert.AreEqual("", ReportSectorModelList[0].Sector_Error);
                    Assert.AreEqual(1, ReportSectorModelList[0].Sector_Counter);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_ID > 0);
                    Assert.IsNotNull(ReportSectorModelList[0].Sector_Name_Translation_Status);
                    Assert.IsNotNull(ReportSectorModelList[0].Sector_Last_Update_Date_And_Time_UTC);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Last_Update_Contact_Initial.Length > 0);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Lat != 0.0f);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Lng != 0.0f);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Subsector_Count > 0);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Municipality_Count > 0);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Lift_Station_Count > 0);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_WWTP_Count > 0);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_MWQM_Sample_Count > 0);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_MWQM_Site_Count > 0);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_MWQM_Run_Count > 0);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Pol_Source_Site_Count > 0);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Mike_Scenario_Count > 0);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Box_Model_Scenario_Count > 0);
                    Assert.IsTrue(ReportSectorModelList[0].Sector_Stat_Visual_Plumes_Scenario_Count > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSectorModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, */
                    tvItemModelProvince, tvItemModelSector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Sector " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Sector_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSectorModel> ReportSectorModelList = reportServiceSector.GetReportSectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSectorModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportSectorModelList[0].Sector_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSectorModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSector.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Sector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Sector_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = tvItemModelSubsector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Sector";

                List<string> AllowableParentTagItemList = reportServiceSector._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSectorModel> ReportSectorModelList = reportServiceSector.GetReportSectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSectorModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportSectorModelList[0].Sector_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSectorModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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
                sb.AppendLine("|||Loop Sector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Sector_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Sector";

                List<string> AllowableParentTagItemList = reportServiceSector._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSectorModel> ReportSectorModelList = reportServiceSector.GetReportSectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSectorModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSectorModelList[0].Sector_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Sector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Sector_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSectorModelList = reportServiceSector.GetReportSectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSectorModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSectorModelList[0].Sector_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Sector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Sector_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSectorModelList = reportServiceSector.GetReportSectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSectorModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSectorModelList[0].Sector_Error));
            }
        }
        #endregion Testing Methods Sector
        #region Testing Methods Sector_File
        [TestMethod]
        public void ReportService_GetReportSector_FileModelListUnderTVItemIDDB_Good_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, */
                    tvItemModelArea, tvItemModelSector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Sector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Sector_File_Error");
                    sb.AppendLine("Sector_File_Counter");
                    sb.AppendLine("Sector_File_ID");
                    sb.AppendLine("Sector_File_Language");
                    sb.AppendLine("Sector_File_File_Purpose");
                    sb.AppendLine("Sector_File_File_Type");
                    sb.AppendLine("Sector_File_File_Description");
                    sb.AppendLine("Sector_File_File_Size_kb");
                    sb.AppendLine("Sector_File_File_Info");
                    sb.AppendLine("Sector_File_File_Created_Date_UTC");
                    sb.AppendLine("Sector_File_From_Water");
                    sb.AppendLine("Sector_File_Server_File_Name");
                    sb.AppendLine("Sector_File_Server_File_Path");
                    sb.AppendLine("Sector_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Sector_File_Last_Update_Contact_Name");
                    sb.AppendLine("Sector_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSector_FileModel> ReportSector_FileModelList = reportServiceSector_File.GetReportSector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSector_FileModelList.Count > 0);
                    Assert.IsTrue(ReportSector_FileModelList[0].Sector_File_Error == "");
                    Assert.IsTrue(ReportSector_FileModelList[0].Sector_File_Counter > 0);
                    Assert.IsTrue(ReportSector_FileModelList[0].Sector_File_ID > 0);
                    Assert.IsTrue((int)ReportSector_FileModelList[0].Sector_File_Language > 0);
                    Assert.IsTrue((int)ReportSector_FileModelList[0].Sector_File_File_Purpose > 0);
                    Assert.IsTrue((int)ReportSector_FileModelList[0].Sector_File_File_Type > 0);
                    Assert.IsTrue(ReportSector_FileModelList[0].Sector_File_File_Description.Length > 0);
                    Assert.IsTrue(ReportSector_FileModelList[0].Sector_File_File_Size_kb > 0);
                    Assert.IsTrue(ReportSector_FileModelList[0].Sector_File_File_Info.Length > 0);
                    Assert.IsNotNull(ReportSector_FileModelList[0].Sector_File_File_Created_Date_UTC);
                    //Assert.IsNotNull(ReportSector_FileModelList[0].Sector_File_From_Water);
                    Assert.IsTrue(ReportSector_FileModelList[0].Sector_File_Server_File_Name.Length > 0);
                    Assert.IsTrue(ReportSector_FileModelList[0].Sector_File_Server_File_Path.Length > 0);
                    Assert.IsTrue(ReportSector_FileModelList[0].Sector_File_Last_Update_Date_And_Time_UTC > new DateTime(1979, 1, 1));
                    Assert.IsTrue(ReportSector_FileModelList[0].Sector_File_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportSector_FileModelList[0].Sector_File_Last_Update_Contact_Initial.Length > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSector_FileModelListUnderTVItemIDDB_Good_CountOnly_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, */
                    tvItemModelArea, tvItemModelSector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Sector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Sector_File_Error");
                    sb.AppendLine("Sector_File_Counter");
                    sb.AppendLine("Sector_File_ID");
                    sb.AppendLine("Sector_File_Language");
                    sb.AppendLine("Sector_File_File_Purpose");
                    sb.AppendLine("Sector_File_File_Type");
                    sb.AppendLine("Sector_File_File_Description");
                    sb.AppendLine("Sector_File_File_Size_kb");
                    sb.AppendLine("Sector_File_File_Info");
                    sb.AppendLine("Sector_File_File_Created_Date_UTC");
                    sb.AppendLine("Sector_File_From_Water");
                    sb.AppendLine("Sector_File_Server_File_Name");
                    sb.AppendLine("Sector_File_Server_File_Path");
                    sb.AppendLine("Sector_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Sector_File_Last_Update_Contact_Name");
                    sb.AppendLine("Sector_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = true;
                    int Take = 10;

                    List<ReportSector_FileModel> ReportSector_FileModelList = reportServiceSector_File.GetReportSector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSector_FileModelList.Count == 1);
                    Assert.IsTrue(ReportSector_FileModelList[0].Sector_File_Counter > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSector_FileModelListUnderTVItemIDDB_Error_Start_Tag_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, */
                    tvItemModelArea, tvItemModelSector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Sector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Sector_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Sector_File";

                    List<ReportSector_FileModel> ReportSector_FileModelList = reportServiceSector_File.GetReportSector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSector_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSector_FileModelList[0].Sector_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSector_FileModelListUnderTVItemIDDB_Error_TVItem_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, */
                    tvItemModelArea, tvItemModelSector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Sector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Sector_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSector_FileModel> ReportSector_FileModelList = reportServiceSector_File.GetReportSector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSector_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportSector_FileModelList[0].Sector_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSector_FileModelListUnderTVItemIDDB_Error_ParentTagItem_Empty_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, */
                    tvItemModelArea, tvItemModelSector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Sector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Sector_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSector_FileModel> ReportSector_FileModelList = reportServiceSector_File.GetReportSector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSector_FileModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.ParentTagItemShouldNotBeEmpty, ReportSector_FileModelList[0].Sector_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSector_FileModelListUnderTVItemIDDB_Error_Allowable_ParentTagItem_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, */
                    tvItemModelArea, tvItemModelSector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Sector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Sector_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "Municipality";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Sector_File";

                    List<string> AllowableParentTagItemList = reportServiceSector._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportSector_FileModel> ReportSector_FileModelList = reportServiceSector_File.GetReportSector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSector_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportSector_FileModelList[0].Sector_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSector_FileModelListUnderTVItemIDDB_Error_GetReportTreeNodesFromTagText_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, */
                    tvItemModelArea, tvItemModelSector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Sector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Sector_File_IDNot"); // line 2
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSector_FileModel> ReportSector_FileModelList = reportServiceSector_File.GetReportSector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSector_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ReportServiceRes._DoesNotExistFor_, "Sector_File_IDNot", "CSSPModelsDLL.Models.ReportSector_FileModel"), ReportSector_FileModelList[0].Sector_File_Error);
                }
            }
        }
        #endregion Testing Methods Sector_File
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
            reportServiceSector = new ReportServiceSector((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSector_File = new ReportServiceSector_File((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceSector);
        }
        #endregion Functions private
    }
}

