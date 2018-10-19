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
    public class ReportServiceSubsectorTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceSubsector reportServiceSubsector { get; set; }
        private ReportServiceSubsector_Special_Table reportServiceSubsector_Special_Table { get; set; }
        private ReportServiceSubsector_Climate_Site reportServiceSubsector_Climate_Site { get; set; }
        private ReportServiceSubsector_Climate_Site_Data reportServiceSubsector_Climate_Site_Data { get; set; }
        private ReportServiceSubsector_File reportServiceSubsector_File { get; set; }
        private ReportServiceSubsector_Hydrometric_Site reportServiceSubsector_Hydrometric_Site { get; set; }
        private ReportServiceSubsector_Hydrometric_Site_Data reportServiceSubsector_Hydrometric_Site_Data { get; set; }
        private ReportServiceSubsector_Hydrometric_Site_Rating_Curve reportServiceSubsector_Hydrometric_Site_Rating_Curve { get; set; }
        private ReportServiceSubsector_Hydrometric_Site_Rating_Curve_Value reportServiceSubsector_Hydrometric_Site_Rating_Curve_Value { get; set; }
        private ReportServiceSubsector_Lab_Sheet reportServiceSubsector_Lab_Sheet { get; set; }
        private ReportServiceSubsector_Lab_Sheet_Detail reportServiceSubsector_Lab_Sheet_Detail { get; set; }
        private ReportServiceSubsector_Lab_Sheet_Tube_And_MPN_Detail reportServiceSubsector_Lab_Sheet_Tube_And_MPN_Detail { get; set; }
        private ReportServiceSubsector_Tide_Site reportServiceSubsector_Tide_Site { get; set; }
        private ReportServiceSubsector_Tide_Site_Data reportServiceSubsector_Tide_Site_Data { get; set; }
        private TVItemService tvItemService { get; set; }
        private ShimReportServiceSubsector shimReportServiceSubsector { get; set; }
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
        public ReportServiceSubsectorTest()
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
        #region Testing Methods Subsector
        [TestMethod]
        public void ReportService_GetReportSubsectorModelListUnderTVItemIDDB_Start_Good_Test()
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

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Error");
                sb.AppendLine("Subsector_Counter");
                sb.AppendLine("Subsector_ID");
                sb.AppendLine("Subsector_Name_Translation_Status");
                sb.AppendLine("Subsector_Name_Long");
                sb.AppendLine("Subsector_Name_Short");
                sb.AppendLine("Subsector_Is_Active");
                sb.AppendLine("Subsector_Last_Update_Date_And_Time_UTC");
                sb.AppendLine("Subsector_Last_Update_Contact_Name");
                sb.AppendLine("Subsector_Last_Update_Contact_Initial");
                sb.AppendLine("Subsector_Lat");
                sb.AppendLine("Subsector_Lng");
                sb.AppendLine("Subsector_Stat_Municipality_Count");
                sb.AppendLine("Subsector_Stat_Lift_Station_Count");
                sb.AppendLine("Subsector_Stat_WWTP_Count");
                sb.AppendLine("Subsector_Stat_MWQM_Sample_Count");
                sb.AppendLine("Subsector_Stat_MWQM_Site_Count");
                sb.AppendLine("Subsector_Stat_MWQM_Run_Count");
                sb.AppendLine("Subsector_Stat_Pol_Source_Site_Count");
                sb.AppendLine("Subsector_Stat_Mike_Scenario_Count");
                sb.AppendLine("Subsector_Stat_Box_Model_Scenario_Count");
                sb.AppendLine("Subsector_Stat_Visual_Plumes_Scenario_Count");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsectorModel> ReportSubsectorModelList = reportServiceSubsector.GetReportSubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsectorModelList.Count > 0);
                Assert.AreEqual("", ReportSubsectorModelList[0].Subsector_Error);
                Assert.AreEqual(1, ReportSubsectorModelList[0].Subsector_Counter);
                Assert.AreEqual(tvItemModelSubsector.TVItemID, ReportSubsectorModelList[0].Subsector_ID);
                Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Name_Translation_Status);
                Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Last_Update_Date_And_Time_UTC);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Last_Update_Contact_Name.Length > 0);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Last_Update_Contact_Initial.Length > 0);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Lat != 0.0f);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Lng != 0.0f);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Stat_Municipality_Count > 0);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Stat_Lift_Station_Count > 0);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Stat_WWTP_Count > 0);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Stat_MWQM_Sample_Count > 0);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Stat_MWQM_Site_Count > 0);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Stat_MWQM_Run_Count > 0);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Stat_Pol_Source_Site_Count > 0);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Stat_Mike_Scenario_Count > 0);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Stat_Box_Model_Scenario_Count > 0);
                Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Stat_Visual_Plumes_Scenario_Count > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsectorModelListUnderTVItemIDDB_Start_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsectorModel> ReportSubsectorModelList = reportServiceSubsector.GetReportSubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportSubsectorModelList[0].Subsector_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsectorModelListUnderTVItemIDDB_Start_TVType_Not_Subsector_Error_Test()
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

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);


                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsectorModel> ReportSubsectorModelList = reportServiceSubsector.GetReportSubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Subsector.ToString()), ReportSubsectorModelList[0].Subsector_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsectorModelListUnderTVItemIDDB_Start_GetReportTreeNodesFromTagText_Error_Test()
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
                sb.AppendLine("|||Start Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector";

                List<string> AllowableParentTagItemList = reportServiceSubsector._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSubsectorModel> ReportSubsectorModelList = reportServiceSubsector.GetReportSubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsectorModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsectorModelList[0].Subsector_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSubsectorModelList = reportServiceSubsector.GetReportSubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsectorModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsectorModelList[0].Subsector_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSubsectorModelList = reportServiceSubsector.GetReportSubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsectorModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSubsectorModelList[0].Subsector_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsectorModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06-020", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, */
                    tvItemModelProvince, tvItemModelSubsector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Error");
                    sb.AppendLine("Subsector_Counter");
                    sb.AppendLine("Subsector_ID");
                    sb.AppendLine("Subsector_Name_Translation_Status");
                    sb.AppendLine("Subsector_Name_Long");
                    sb.AppendLine("Subsector_Name_Short");
                    sb.AppendLine("Subsector_Is_Active");
                    sb.AppendLine("Subsector_Last_Update_Date_And_Time_UTC");
                    sb.AppendLine("Subsector_Last_Update_Contact_Name");
                    sb.AppendLine("Subsector_Last_Update_Contact_Initial");
                    sb.AppendLine("Subsector_Lat");
                    sb.AppendLine("Subsector_Lng");
                    sb.AppendLine("Subsector_Stat_Municipality_Count");
                    sb.AppendLine("Subsector_Stat_Lift_Station_Count");
                    sb.AppendLine("Subsector_Stat_WWTP_Count");
                    sb.AppendLine("Subsector_Stat_MWQM_Sample_Count");
                    sb.AppendLine("Subsector_Stat_MWQM_Site_Count");
                    sb.AppendLine("Subsector_Stat_MWQM_Run_Count");
                    sb.AppendLine("Subsector_Stat_Pol_Source_Site_Count");
                    sb.AppendLine("Subsector_Stat_Mike_Scenario_Count");
                    sb.AppendLine("Subsector_Stat_Box_Model_Scenario_Count");
                    sb.AppendLine("Subsector_Stat_Visual_Plumes_Scenario_Count");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsectorModel> ReportSubsectorModelList = reportServiceSubsector.GetReportSubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsectorModelList.Count > 0);
                    Assert.AreEqual("", ReportSubsectorModelList[0].Subsector_Error);
                    Assert.AreEqual(1, ReportSubsectorModelList[0].Subsector_Counter);
                    Assert.IsTrue(ReportSubsectorModelList[0].Subsector_ID > 0);
                    Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Name_Translation_Status);
                    Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Last_Update_Date_And_Time_UTC);
                    Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Last_Update_Contact_Initial.Length > 0);
                    Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Lat != 0.0f);
                    Assert.IsTrue(ReportSubsectorModelList[0].Subsector_Lng != 0.0f);
                    Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Stat_Municipality_Count);
                    Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Stat_Lift_Station_Count);
                    Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Stat_WWTP_Count);
                    Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Stat_MWQM_Sample_Count);
                    Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Stat_MWQM_Site_Count);
                    Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Stat_MWQM_Run_Count);
                    Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Stat_Pol_Source_Site_Count);
                    Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Stat_Mike_Scenario_Count);
                    Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Stat_Box_Model_Scenario_Count);
                    Assert.IsNotNull(ReportSubsectorModelList[0].Subsector_Stat_Visual_Plumes_Scenario_Count);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsectorModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06-020", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, */
                    tvItemModelProvince, tvItemModelSubsector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsectorModel> ReportSubsectorModelList = reportServiceSubsector.GetReportSubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsectorModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportSubsectorModelList[0].Subsector_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsectorModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06-020-002", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector";

                List<string> AllowableParentTagItemList = reportServiceSubsector._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSubsectorModel> ReportSubsectorModelList = reportServiceSubsector.GetReportSubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsectorModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportSubsectorModelList[0].Subsector_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsectorModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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
                sb.AppendLine("|||Loop Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector";

                List<string> AllowableParentTagItemList = reportServiceSubsector._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSubsectorModel> ReportSubsectorModelList = reportServiceSubsector.GetReportSubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsectorModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsectorModelList[0].Subsector_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSubsectorModelList = reportServiceSubsector.GetReportSubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsectorModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsectorModelList[0].Subsector_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSubsectorModelList = reportServiceSubsector.GetReportSubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsectorModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSubsectorModelList[0].Subsector_Error));
            }
        }
        #endregion Testing Methods Subsector
        #region Testing Methods Subsector_Special_Table
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Special_Table";

                List<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(reportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_FCDensitiesTable_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL GeometricMeanTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 635; // tvItemModelSubsector.TVItemID;
                string ParentTagItem = tvItemModelSubsector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(reportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Last_X_Runs > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Type == SpecialTableTypeEnum.FCDensitiesTable);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Max == 30);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Min == 10);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Above_Min_Number == 14);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Below_Max_Number == 3000);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation == 3);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part == 35);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Site_Name_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Stat_Letter_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Run_Date_List.Length > 0);
                Assert.IsTrue(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Parameter_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Tide_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_24h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_48h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_72h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_96h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_120h_Value_List.Length > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_GeometricMeanTable_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL GeometricMeanTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = tvItemModelSubsector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(reportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Last_X_Runs > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Type == SpecialTableTypeEnum.GeometricMeanTable);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Max == 30);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Min == 10);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Above_Min_Number == 14);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Below_Max_Number == 3000);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation == 3);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part == 35);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Site_Name_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Stat_Letter_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Run_Date_List.Length > 0);
                Assert.IsTrue(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Parameter_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Tide_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_24h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_48h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_72h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_96h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_120h_Value_List.Length > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_MedianTable_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL MedianTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = tvItemModelSubsector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(reportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Last_X_Runs > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Type == SpecialTableTypeEnum.MedianTable);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Max == 30);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Min == 10);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Above_Min_Number == 14);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Below_Max_Number == 3000);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation == 3);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part == 35);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Site_Name_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Stat_Letter_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Run_Date_List.Length > 0);
                Assert.IsTrue(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Parameter_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Tide_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_24h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_48h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_72h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_96h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_120h_Value_List.Length > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_P90Table_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL P90Table");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = tvItemModelSubsector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(reportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Last_X_Runs > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Type == SpecialTableTypeEnum.P90Table);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Max == 30);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Min == 10);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Above_Min_Number == 14);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Below_Max_Number == 3000);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation == 3);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part == 35);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Site_Name_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Stat_Letter_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Run_Date_List.Length > 0);
                Assert.IsTrue(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Parameter_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Tide_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_24h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_48h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_72h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_96h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_120h_Value_List.Length > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_PercentOver260Table_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL PercentOver260Table");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = tvItemModelSubsector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(reportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Last_X_Runs > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Type == SpecialTableTypeEnum.PercentOver260Table);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Max == 30);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Min == 10);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Above_Min_Number == 14);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Below_Max_Number == 3000);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation == 3);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part == 35);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Site_Name_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Stat_Letter_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Run_Date_List.Length > 0);
                Assert.IsTrue(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Parameter_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Tide_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_24h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_48h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_72h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_96h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_120h_Value_List.Length > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_PercentOver43Table_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL PercentOver43Table");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = tvItemModelSubsector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(reportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Last_X_Runs > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Type == SpecialTableTypeEnum.PercentOver43Table);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Max == 30);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Min == 10);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Above_Min_Number == 14);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Below_Max_Number == 3000);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation == 3);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part == 35);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Site_Name_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Stat_Letter_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Run_Date_List.Length > 0);
                Assert.IsTrue(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Parameter_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Tide_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_24h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_48h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_72h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_96h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_120h_Value_List.Length > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_SalinitiyTable_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                 StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL SalinityTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = tvItemModelSubsector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(reportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Last_X_Runs > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Type == SpecialTableTypeEnum.SalinityTable);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Max == 30);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Min == 10);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Above_Min_Number == 14);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Below_Max_Number == 3000);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation == 3);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part == 35);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Site_Name_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Stat_Letter_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Run_Date_List.Length > 0);
                Assert.IsTrue(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Parameter_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Tide_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_24h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_48h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_72h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_96h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_120h_Value_List.Length > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_TemperatureTable_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL TemperatureTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = tvItemModelSubsector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(reportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Last_X_Runs > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Type == SpecialTableTypeEnum.TemperatureTable);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Max == 30);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Number_Of_Samples_For_Stat_Min == 10);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Above_Min_Number == 14);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Highlight_Below_Max_Number == 3000);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation == 3);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part == 35);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Site_Name_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Stat_Letter_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_MWQM_Run_Date_List.Length > 0);
                Assert.IsTrue(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Parameter_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Tide_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_24h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_48h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_72h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_96h_Value_List.Length > 0);
                Assert.IsNotNull(reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Prec_120h_Value_List.Length > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL MedianTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(reportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL MedianTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = "Root";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Special_Table";

                List<string> AllowableParentTagItemList = reportServiceSubsector_Special_Table._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSubsector_Special_TableModel> reportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(reportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, ServiceRes.Subsector, ParentTagItem), reportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL MedianTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List Not");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Special_Table";

                List<string> AllowableParentTagItemList = reportServiceSubsector_Special_Table._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSubsector_Special_TableModel> ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL MedianTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_ListNot");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL MedianTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Subsector_Special_Table_Last_X_Runs_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                //sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL MedianTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;
                //string TagItem = "Subsector_Special_Table";

                List<ReportSubsector_Special_TableModel> ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Last_X_Runs", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL MedianTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Last_X_Runs", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs BIGGER 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL MedianTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Last_X_Runs", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL MedianTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Subsector_Special_Table_Type_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                //sb.AppendLine("Subsector_Special_Table_Type EQUAL MedianTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;
                //string TagItem = "Subsector_Special_Table";

                List<ReportSubsector_Special_TableModel> ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Type", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Type", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Subsector_Special_Table_Number_Of_Samples_For_Stat_Max_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                //sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;
                //string TagItem = "Subsector_Special_Table";

                List<ReportSubsector_Special_TableModel> ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Number_Of_Samples_For_Stat_Max", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Number_Of_Samples_For_Stat_Max", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Subsector_Special_Table_Number_Of_Samples_For_Stat_Min_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                //sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;
                //string TagItem = "Subsector_Special_Table";

                List<ReportSubsector_Special_TableModel> ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Number_Of_Samples_For_Stat_Min", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Number_Of_Samples_For_Stat_Min", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Subsector_Special_Table_Highlight_Above_Min_Number_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                //sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;
                //string TagItem = "Subsector_Special_Table";

                List<ReportSubsector_Special_TableModel> ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Highlight_Above_Min_Number", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Highlight_Above_Min_Number", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Subsector_Special_Table_Highlight_Below_Max_Number_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                //sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;
                //string TagItem = "Subsector_Special_Table";

                List<ReportSubsector_Special_TableModel> ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Highlight_Below_Max_Number", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Highlight_Below_Max_Number", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                //sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;
                //string TagItem = "Subsector_Special_Table";

                List<ReportSubsector_Special_TableModel> ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 3000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Special_TableModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-04-030-001", TVTypeEnum.Subsector);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                //sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSubsector.TVItemID;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;
                //string TagItem = "Subsector_Special_Table";

                List<ReportSubsector_Special_TableModel> ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 3000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "EQUAL database filtering") + " for Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Special_Table " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Special_Table_Error");
                sb.AppendLine("Subsector_Special_Table_Last_X_Runs EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Type EQUAL FCDensitiesTable");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Is_Active TRUE");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Max EQUAL 30");
                sb.AppendLine("Subsector_Special_Table_Number_Of_Samples_For_Stat_Min EQUAL 10");
                sb.AppendLine("Subsector_Special_Table_Highlight_Above_Min_Number EQUAL 14");
                sb.AppendLine("Subsector_Special_Table_Highlight_Below_Max_Number EQUAL 30000");
                sb.AppendLine("Subsector_Special_Table_Show_Number_Of_Days_Of_Precipitation EQUAL 3");
                sb.AppendLine("Subsector_Special_Table_Max_Number_Of_Sites_Per_Table_Part EQUAL 35");
                sb.AppendLine("Subsector_Special_Table_MWQM_Site_Name_List");
                sb.AppendLine("Subsector_Special_Table_Stat_Letter_List");
                sb.AppendLine("Subsector_Special_Table_MWQM_Run_Date_List");
                sb.AppendLine("Subsector_Special_Table_Parameter_Value_List");
                sb.AppendLine("Subsector_Special_Table_Tide_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_24h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_48h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_72h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_96h_Value_List");
                sb.AppendLine("Subsector_Special_Table_Prec_120h_Value_List");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelSubsector.TVItemID;
                ParentTagItem = "Subsector";
                CountOnly = false;
                Take = 10;
                //TagItem = "Subsector_Special_Table";

                ReportSubsector_Special_TableModelList = reportServiceSubsector_Special_Table.GetReportSubsector_Special_TableModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Special_TableModelList.Count > 0);
                Assert.AreEqual("", ReportSubsector_Special_TableModelList[0].Subsector_Special_Table_Error);
            }
        }
        #endregion Testing Methods Subsector_Special_Table
        #region Testing Methods Subsector_Climate_Site
        [TestMethod]
        public void ReportService_GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                       where c.SiteType == (int)SiteTypeEnum.Climate
                                       select c).FirstOrDefault();
                Assert.IsNotNull(useOfSite);
                Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                TVItemModel tvItemModelSubsector = tvItemService.GetTVItemModelWithTVItemIDDB(useOfSite.SubsectorTVItemID);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelSector = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelSubsector.ParentID);
                Assert.AreEqual("", tvItemModelSector.Error);

                TVItemModel tvItemModelArea = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelSector.ParentID);
                Assert.AreEqual("", tvItemModelArea.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelArea.ParentID);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelProvince.ParentID);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);


                List<TVItemModel> tvItemModelList = new List<TVItemModel>()
                {
                    tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector
                };

                foreach (TVItemModel tvItemModel in tvItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Subsector_Climate_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Climate_Site_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = (int)tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Subsector_Climate_Site";

                    List<ReportSubsector_Climate_SiteModel> ReportSubsector_Climate_SiteModelList = reportServiceSubsector_Climate_Site.GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Climate_SiteModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                       where c.SiteType == (int)SiteTypeEnum.Climate
                                       select c).FirstOrDefault();
                Assert.IsNotNull(useOfSite);
                Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                TVItemModel tvItemModelSubsector = tvItemService.GetTVItemModelWithTVItemIDDB(useOfSite.SubsectorTVItemID);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelSector = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelSubsector.ParentID);
                Assert.AreEqual("", tvItemModelSector.Error);

                TVItemModel tvItemModelArea = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelSector.ParentID);
                Assert.AreEqual("", tvItemModelArea.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelArea.ParentID);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelProvince.ParentID);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);


                List<TVItemModel> tvItemModelList = new List<TVItemModel>()
                {
                    tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector
                };

                foreach (TVItemModel tvItemModel in tvItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Climate_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Climate_Site_Error");
                    sb.AppendLine("Subsector_Climate_Site_Counter");
                    sb.AppendLine("Subsector_Climate_Site_ID");
                    sb.AppendLine("Subsector_Climate_Site_Climate_ID");
                    sb.AppendLine("Subsector_Climate_Site_Name");
                    sb.AppendLine("Subsector_Climate_Site_Daily_End_Date_Local");
                    sb.AppendLine("Subsector_Climate_Site_Daily_Now");
                    sb.AppendLine("Subsector_Climate_Site_Daily_Start_Date_Local");
                    sb.AppendLine("Subsector_Climate_Site_ECDBID");
                    sb.AppendLine("Subsector_Climate_Site_Elevation_m");
                    sb.AppendLine("Subsector_Climate_Site_File_desc");
                    sb.AppendLine("Subsector_Climate_Site_Hourly_End_Date_Local");
                    sb.AppendLine("Subsector_Climate_Site_Hourly_Now");
                    sb.AppendLine("Subsector_Climate_Site_Hourly_Start_Date_Local");
                    sb.AppendLine("Subsector_Climate_Site_Is_Provincial");
                    sb.AppendLine("Subsector_Climate_Site_Last_Update_Date_UTC");
                    sb.AppendLine("Subsector_Climate_Site_Monthly_End_Date_Local");
                    sb.AppendLine("Subsector_Climate_Site_Monthly_Now");
                    sb.AppendLine("Subsector_Climate_Site_Monthly_Start_Date_Local");
                    sb.AppendLine("Subsector_Climate_Site_Province");
                    sb.AppendLine("Subsector_Climate_Site_Prov_Site_ID");
                    sb.AppendLine("Subsector_Climate_Site_TCID");
                    sb.AppendLine("Subsector_Climate_Site_Time_Offset_hour");
                    sb.AppendLine("Subsector_Climate_Site_WMOID");
                    sb.AppendLine("Subsector_Climate_Site_Last_Update_Contact_Name");
                    sb.AppendLine("Subsector_Climate_Site_Last_Update_Contact_Initial");
                    sb.AppendLine("Subsector_Climate_Site_Lat");
                    sb.AppendLine("Subsector_Climate_Site_Lng");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Climate_SiteModel> ReportSubsector_Climate_SiteModelList = reportServiceSubsector_Climate_Site.GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Climate_SiteModelList.Count > 0);
                    Assert.AreEqual("", ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Error);
                    Assert.AreEqual(1, ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Counter);
                    Assert.IsTrue(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_ID > 0);
                    Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Climate_ID);
                    Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Name);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Daily_End_Date_Local);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Daily_Now);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Daily_Start_Date_Local);
                    Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_ECDBID);
                    Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Elevation_m);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_File_desc);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Hourly_End_Date_Local);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Hourly_Now);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Hourly_Start_Date_Local);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Is_Provincial);
                    Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Last_Update_Date_UTC);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Monthly_End_Date_Local);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Monthly_Now);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Monthly_Start_Date_Local);
                    Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Province);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Prov_Site_ID);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_TCID);
                    Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Time_Offset_hour);
                    //Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_WMOID);
                    Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Last_Update_Contact_Name);
                    Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Last_Update_Contact_Initial);
                    Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Lat);
                    Assert.IsNotNull(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Lng);

                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                       where c.SiteType == (int)SiteTypeEnum.Climate
                                       select c).FirstOrDefault();
                Assert.IsNotNull(useOfSite);
                Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Climate_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Climate_SiteModel> ReportSubsector_Climate_SiteModelList = reportServiceSubsector_Climate_Site.GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Climate_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                       where c.SiteType == (int)SiteTypeEnum.Climate
                                       select c).FirstOrDefault();
                Assert.IsNotNull(useOfSite);
                Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Climate_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Climate_Site";

                List<string> AllowableParentTagItemList = reportServiceSubsector_Climate_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSubsector_Climate_SiteModel> ReportSubsector_Climate_SiteModelList = reportServiceSubsector_Climate_Site.GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Climate_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                       where c.SiteType == (int)SiteTypeEnum.Climate
                                       select c).FirstOrDefault();
                Assert.IsNotNull(useOfSite);
                Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Climate_Site_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)useOfSite.SubsectorTVItemID;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Climate_Site";

                List<string> AllowableParentTagItemList = reportServiceSubsector_Climate_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSubsector_Climate_SiteModel> ReportSubsector_Climate_SiteModelList = reportServiceSubsector_Climate_Site.GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Climate_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Climate_Site_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSubsector_Climate_SiteModelList = reportServiceSubsector_Climate_Site.GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Climate_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Climate_Site_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSubsector_Climate_SiteModelList = reportServiceSubsector_Climate_Site.GetReportSubsector_Climate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Climate_SiteModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSubsector_Climate_SiteModelList[0].Subsector_Climate_Site_Error));
            }
        }
        #endregion Testing Methods Subsector_Climate_Site
        #region Testing Methods Subsector_Climate_Site_Data
        [TestMethod]
        public void ReportService_GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector_Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Climate_Site_Data_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 229465;
                string ParentTagItem = "Subsector_Climate_Site";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Climate_Site_Data";

                List<ReportSubsector_Climate_Site_DataModel> ReportSubsector_Climate_Site_DataModelList = reportServiceSubsector_Climate_Site_Data.GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Climate_Site_DataModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelSubsector_Climate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelSubsector_Climate_Site.Error);

                var dbvar = (from c in tvItemService.db.ClimateSites
                             from cd in tvItemService.db.ClimateDataValues
                             where c.ClimateSiteID == cd.ClimateSiteID
                             && cd.TotalPrecip_mm_cm > 0
                             select new { c, cd }).FirstOrDefault();
                Assert.IsNotNull(dbvar);
                int ClimateSiteTVItemID = dbvar.c.ClimateSiteTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Climate_Site_Data_Error");
                sb.AppendLine("Subsector_Climate_Site_Data_Counter");
                sb.AppendLine("Subsector_Climate_Site_Data_ID");
                sb.AppendLine("Subsector_Climate_Site_Data_Cool_Deg_Days_C");
                sb.AppendLine("Subsector_Climate_Site_Data_Date_Time_Local");
                sb.AppendLine("Subsector_Climate_Site_Data_Dir_Max_Gust_0North");
                sb.AppendLine("Subsector_Climate_Site_Data_Heat_Deg_Days_C");
                sb.AppendLine("Subsector_Climate_Site_Data_Hourly_Values");
                sb.AppendLine("Subsector_Climate_Site_Data_Keep");
                sb.AppendLine("Subsector_Climate_Site_Data_Last_Update_Date_UTC");
                sb.AppendLine("Subsector_Climate_Site_Data_Max_Temp_C");
                sb.AppendLine("Subsector_Climate_Site_Data_Min_Temp_C");
                sb.AppendLine("Subsector_Climate_Site_Data_Rainfall_Entered_mm");
                sb.AppendLine("Subsector_Climate_Site_Data_Rainfall_mm");
                sb.AppendLine("Subsector_Climate_Site_Data_Snow_cm");
                sb.AppendLine("Subsector_Climate_Site_Data_Snow_On_Ground_cm");
                sb.AppendLine("Subsector_Climate_Site_Data_Spd_Max_Gust_kmh");
                sb.AppendLine("Subsector_Climate_Site_Data_Storage_Data_Type");
                sb.AppendLine("Subsector_Climate_Site_Data_Total_Precip_mm_cm");
                sb.AppendLine("Subsector_Climate_Site_Data_Last_Update_Contact_Name");
                sb.AppendLine("Subsector_Climate_Site_Data_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ClimateSiteTVItemID;
                string ParentTagItem = "Subsector_Climate_Site";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Climate_Site_DataModel> ReportSubsector_Climate_Site_DataModelList = reportServiceSubsector_Climate_Site_Data.GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Climate_Site_DataModelList.Count > 0);
                Assert.AreEqual("", ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Error);
                Assert.IsTrue(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Counter > 0);
                Assert.IsTrue(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_ID > 0);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Cool_Deg_Days_C);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Date_Time_Local);
                //Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Dir_Max_Gust_0North);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Heat_Deg_Days_C);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Hourly_Values);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Keep);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Max_Temp_C);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Min_Temp_C);
                //Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Rainfall_Entered_mm);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Rainfall_mm);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Snow_cm);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Snow_On_Ground_cm);
                //Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Spd_Max_Gust_kmh);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Storage_Data_Type);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Total_Precip_mm_cm);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB_Loop_Error_ParentTagItem_Not_Subsector_Climate_Site_Test()
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

                TVItemModel tvItemModelSubsector_Climate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelSubsector_Climate_Site.Error);

                var dbvar = (from c in tvItemService.db.ClimateSites
                             from cd in tvItemService.db.ClimateDataValues
                             where c.ClimateSiteID == cd.ClimateSiteID
                             && cd.TotalPrecip_mm_cm > 0
                             select new { c, cd }).FirstOrDefault();
                Assert.IsNotNull(dbvar);
                int ClimateSiteTVItemID = dbvar.c.ClimateSiteTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Climate_Site_Data_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Subsector_Climate_SiteNot";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Climate_Site_DataModel> ReportSubsector_Climate_Site_DataModelList = reportServiceSubsector_Climate_Site_Data.GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Climate_Site_DataModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Subsector_Climate_Site", ParentTagItem), ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB_Loop_Error_CouldNotFind_With_Equal__Test()
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

                TVItemModel tvItemModelSubsector_Climate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelSubsector_Climate_Site.Error);

                var dbvar = (from c in tvItemService.db.ClimateSites
                             from cd in tvItemService.db.ClimateDataValues
                             where c.ClimateSiteID == cd.ClimateSiteID
                             && cd.TotalPrecip_mm_cm > 0
                             select new { c, cd }).FirstOrDefault();
                Assert.IsNotNull(dbvar);
                int ClimateSiteTVItemID = dbvar.c.ClimateSiteTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Climate_Site_Data_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Subsector_Climate_Site";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Climate_Site_DataModel> ReportSubsector_Climate_Site_DataModelList = reportServiceSubsector_Climate_Site_Data.GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Climate_Site_DataModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateSite, ServiceRes.ClimateSiteTVItemID, UnderTVItemID.ToString()), ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelSubsector_Climate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelSubsector_Climate_Site.Error);

                var dbvar = (from c in tvItemService.db.ClimateSites
                             from cd in tvItemService.db.ClimateDataValues
                             where c.ClimateSiteID == cd.ClimateSiteID
                             && cd.TotalPrecip_mm_cm > 0
                             select new { c, cd }).FirstOrDefault();
                Assert.IsNotNull(dbvar);
                int ClimateSiteTVItemID = dbvar.c.ClimateSiteTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Climate_Site_Data_IDNot");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ClimateSiteTVItemID;
                string ParentTagItem = "Subsector_Climate_Site";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Climate_Site_Data";

                List<string> AllowableParentTagItemList = reportServiceSubsector_Climate_Site_Data._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSubsector_Climate_Site_DataModel> ReportSubsector_Climate_Site_DataModelList = reportServiceSubsector_Climate_Site_Data.GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Climate_Site_DataModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Climate_Site_Data_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSubsector_Climate_Site_DataModelList = reportServiceSubsector_Climate_Site_Data.GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Climate_Site_DataModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Climate_Site_Data_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSubsector_Climate_Site_DataModelList = reportServiceSubsector_Climate_Site_Data.GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Climate_Site_DataModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSubsector_Climate_Site_DataModelList[0].Subsector_Climate_Site_Data_Error));
            }
        }
        #endregion Testing Methods Subsector_Climate_Site_Data
        #region Testing Methods Subsector_File
        [TestMethod]
        public void ReportService_GetReportSubsector_FileModelListUnderTVItemIDDB_Good_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, */
                    tvItemModelSector, tvItemModelSubsector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_File_Error");
                    sb.AppendLine("Subsector_File_Counter");
                    sb.AppendLine("Subsector_File_ID");
                    sb.AppendLine("Subsector_File_Language");
                    sb.AppendLine("Subsector_File_Purpose");
                    sb.AppendLine("Subsector_File_Type");
                    sb.AppendLine("Subsector_File_Description");
                    sb.AppendLine("Subsector_File_Size_kb");
                    sb.AppendLine("Subsector_File_Info");
                    sb.AppendLine("Subsector_File_Created_Date_UTC");
                    sb.AppendLine("Subsector_File_From_Water");
                    sb.AppendLine("Subsector_File_Server_File_Name");
                    sb.AppendLine("Subsector_File_Server_File_Path");
                    sb.AppendLine("Subsector_File_Last_Update_Date_And_Time_UTC");
                    sb.AppendLine("Subsector_File_Last_Update_Contact_Name");
                    sb.AppendLine("Subsector_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_FileModel> ReportSubsector_FileModelList = reportServiceSubsector_File.GetReportSubsector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_FileModelList.Count > 0);
                    Assert.IsTrue(ReportSubsector_FileModelList[0].Subsector_File_Error == "");
                    Assert.IsTrue(ReportSubsector_FileModelList[0].Subsector_File_Counter > 0);
                    Assert.IsTrue(ReportSubsector_FileModelList[0].Subsector_File_ID > 0);
                    Assert.IsTrue((int)ReportSubsector_FileModelList[0].Subsector_File_Language > 0);
                    Assert.IsTrue((int)ReportSubsector_FileModelList[0].Subsector_File_Purpose > 0);
                    Assert.IsTrue((int)ReportSubsector_FileModelList[0].Subsector_File_Type > 0);
                    //Assert.IsTrue(ReportSubsector_FileModelList[0].Subsector_File_Description.Length > 0);
                    Assert.IsTrue(ReportSubsector_FileModelList[0].Subsector_File_Size_kb > 0);
                    Assert.IsTrue(ReportSubsector_FileModelList[0].Subsector_File_Info.Length > 0);
                    Assert.IsNotNull(ReportSubsector_FileModelList[0].Subsector_File_Created_Date_UTC);
                    //Assert.IsNotNull(ReportSubsector_FileModelList[0].Subsector_File_From_Water);
                    Assert.IsTrue(ReportSubsector_FileModelList[0].Subsector_File_Server_File_Name.Length > 0);
                    Assert.IsTrue(ReportSubsector_FileModelList[0].Subsector_File_Server_File_Path.Length > 0);
                    Assert.IsTrue(ReportSubsector_FileModelList[0].Subsector_File_Last_Update_Date_And_Time_UTC > new DateTime(1979, 1, 1));
                    Assert.IsTrue(ReportSubsector_FileModelList[0].Subsector_File_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportSubsector_FileModelList[0].Subsector_File_Last_Update_Contact_Initial.Length > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_FileModelListUnderTVItemIDDB_Good_CountOnly_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, */
                    tvItemModelSector, tvItemModelSubsector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_File_Error");
                    sb.AppendLine("Subsector_File_Counter");
                    sb.AppendLine("Subsector_File_ID");
                    sb.AppendLine("Subsector_File_Language");
                    sb.AppendLine("Subsector_File_Purpose");
                    sb.AppendLine("Subsector_File_Type");
                    sb.AppendLine("Subsector_File_Description");
                    sb.AppendLine("Subsector_File_Size_kb");
                    sb.AppendLine("Subsector_File_Info");
                    sb.AppendLine("Subsector_File_Created_Date_UTC");
                    sb.AppendLine("Subsector_File_From_Water");
                    sb.AppendLine("Subsector_File_Server_File_Name");
                    sb.AppendLine("Subsector_File_Server_File_Path");
                    sb.AppendLine("Subsector_File_Last_Update_Date_And_Time_UTC");
                    sb.AppendLine("Subsector_File_Last_Update_Contact_Name");
                    sb.AppendLine("Subsector_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = true;
                    int Take = 10;

                    List<ReportSubsector_FileModel> ReportSubsector_FileModelList = reportServiceSubsector_File.GetReportSubsector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_FileModelList.Count == 1);
                    Assert.IsTrue(ReportSubsector_FileModelList[0].Subsector_File_Counter > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_FileModelListUnderTVItemIDDB_Error_Start_Tag_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, */
                    tvItemModelSector, tvItemModelSubsector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Subsector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Subsector_File";

                    List<ReportSubsector_FileModel> ReportSubsector_FileModelList = reportServiceSubsector_File.GetReportSubsector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSubsector_FileModelList[0].Subsector_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_FileModelListUnderTVItemIDDB_Error_TVItem_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, */
                    tvItemModelSector, tvItemModelSubsector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_FileModel> ReportSubsector_FileModelList = reportServiceSubsector_File.GetReportSubsector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportSubsector_FileModelList[0].Subsector_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_FileModelListUnderTVItemIDDB_Error_ParentTagItem_Empty_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, */
                    tvItemModelSector, tvItemModelSubsector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_FileModel> ReportSubsector_FileModelList = reportServiceSubsector_File.GetReportSubsector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_FileModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.ParentTagItemShouldNotBeEmpty, ReportSubsector_FileModelList[0].Subsector_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_FileModelListUnderTVItemIDDB_Error_Allowable_ParentTagItem_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, */
                    tvItemModelSector, tvItemModelSubsector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "Municipality";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Subsector_File";

                    List<string> AllowableParentTagItemList = reportServiceSubsector_File._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportSubsector_FileModel> ReportSubsector_FileModelList = reportServiceSubsector_File.GetReportSubsector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportSubsector_FileModelList[0].Subsector_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_FileModelListUnderTVItemIDDB_Error_GetReportTreeNodesFromTagText_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, */
                    tvItemModelSector, tvItemModelSubsector };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_File_IDNot"); // line 2
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_FileModel> ReportSubsector_FileModelList = reportServiceSubsector_File.GetReportSubsector_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ReportServiceRes._DoesNotExistFor_, "Subsector_File_IDNot", "CSSPModelsDLL.Models.ReportSubsector_FileModel"), ReportSubsector_FileModelList[0].Subsector_File_Error);
                }
            }
        }
        #endregion Testing Methods Subsector_File
        #region Testing Methods Subsector_Hydrometric_Site
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_SiteModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                       where c.SiteType == (int)SiteTypeEnum.Hydrometric
                                       select c).FirstOrDefault();
                Assert.IsNotNull(useOfSite);
                Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                TVItemModel tvItemModelSubsector = tvItemService.GetTVItemModelWithTVItemIDDB(useOfSite.SubsectorTVItemID);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelSector = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelSubsector.ParentID);
                Assert.AreEqual("", tvItemModelSector.Error);

                TVItemModel tvItemModelArea = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelSector.ParentID);
                Assert.AreEqual("", tvItemModelArea.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelArea.ParentID);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelProvince.ParentID);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                List<TVItemModel> tvItemModelList = new List<TVItemModel>()
                {
                    tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector
                };

                foreach (TVItemModel tvItemModel in tvItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Subsector_Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = (int)tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Subsector_Hydrometric_Site";

                    List<ReportSubsector_Hydrometric_SiteModel> ReportSubsector_Hydrometric_SiteModelList = reportServiceSubsector_Hydrometric_Site.GetReportSubsector_Hydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_SiteModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_SiteModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SetupTest(contactModelListGood[0], culture);

                    UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                           where c.SiteType == (int)SiteTypeEnum.Hydrometric
                                           select c).FirstOrDefault();
                    Assert.IsNotNull(useOfSite);
                    Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                    HydrometricSite HydrometricSite = (from c in hydrometricSiteService.db.HydrometricSites
                                                       where c.HydrometricSiteTVItemID == useOfSite.SiteTVItemID
                                                       select c).FirstOrDefault();

                    if (HydrometricSite == null)
                    {
                        HydrometricSiteModel hydrometricSiteModelNew = new HydrometricSiteModel()
                        {
                            HydrometricSiteTVItemID = useOfSite.SiteTVItemID,
                            HydrometricSiteName = "Some unique name",
                            FedSiteNumber = randomService.RandomString("", 6),
                            QuebecSiteNumber = randomService.RandomString("", 6),
                            Description = randomService.RandomString("", 65),
                            Elevation_m = randomService.RandomFloat(3.4f, 56.6f),
                            StartDate_Local = randomService.RandomDateTime(),
                            EndDate_Local = randomService.RandomDateTime(),
                            TimeOffset_hour = randomService.RandomFloat(-3f, -8f),
                            DrainageArea_km2 = randomService.RandomFloat(3.4f, 56.6f),
                            IsNatural = true,
                            IsActive = true,
                            Sediment = true,
                            RHBN = true,
                            RealTime = true,
                            HasRatingCurve = true,
                            Province = "NB"
                        };

                        hydrometricSiteModelNew.EndDate_Local = hydrometricSiteModelNew.StartDate_Local.Value.AddDays(4);

                        HydrometricSiteModel tideHydrometricModelRet = hydrometricSiteService.PostAddHydrometricSiteDB(hydrometricSiteModelNew);
                        Assert.AreEqual("", tideHydrometricModelRet.Error);
                    }

                    TVItemModel tvItemModelSubsector = tvItemService.GetTVItemModelWithTVItemIDDB(useOfSite.SubsectorTVItemID);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    TVItemModel tvItemModelSector = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelSubsector.ParentID);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    TVItemModel tvItemModelArea = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelSector.ParentID);
                    Assert.AreEqual("", tvItemModelArea.Error);

                    TVItemModel tvItemModelProvince = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelArea.ParentID);
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    TVItemModel tvItemModelCountry = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelProvince.ParentID);
                    Assert.AreEqual("", tvItemModelCountry.Error);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    List<TVItemModel> tvItemModelList = new List<TVItemModel>()
                {
                    tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector
                };

                    foreach (TVItemModel tvItemModel in tvItemModelList)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("|||Loop Subsector_Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                        sb.AppendLine("Subsector_Hydrometric_Site_Error");
                        sb.AppendLine("Subsector_Hydrometric_Site_Counter");
                        sb.AppendLine("Subsector_Hydrometric_Site_ID");
                        sb.AppendLine("Subsector_Hydrometric_Site_Fed_Site_Number");
                        sb.AppendLine("Subsector_Hydrometric_Site_Quebec_Site_Number");
                        sb.AppendLine("Subsector_Hydrometric_Site_Name");
                        sb.AppendLine("Subsector_Hydrometric_Site_Description");
                        sb.AppendLine("Subsector_Hydrometric_Site_Province");
                        sb.AppendLine("Subsector_Hydrometric_Site_Elevation_m");
                        sb.AppendLine("Subsector_Hydrometric_Site_Start_Date_Local");
                        sb.AppendLine("Subsector_Hydrometric_Site_End_Date_Local");
                        sb.AppendLine("Subsector_Hydrometric_Site_Time_Offset_hour");
                        sb.AppendLine("Subsector_Hydrometric_Site_Drainage_Area_km2");
                        sb.AppendLine("Subsector_Hydrometric_Site_Is_Natural");
                        sb.AppendLine("Subsector_Hydrometric_Site_Is_Active");
                        sb.AppendLine("Subsector_Hydrometric_Site_Sediment");
                        sb.AppendLine("Subsector_Hydrometric_Site_RHBN");
                        sb.AppendLine("Subsector_Hydrometric_Site_Real_Time");
                        sb.AppendLine("Subsector_Hydrometric_Site_Has_Rating_Curve");
                        sb.AppendLine("Subsector_Hydrometric_Site_Last_Update_Date_UTC");
                        sb.AppendLine("Subsector_Hydrometric_Site_Last_Update_Contact_Name");
                        sb.AppendLine("Subsector_Hydrometric_Site_Last_Update_Contact_Initial");
                        sb.AppendLine("Subsector_Hydrometric_Site_Lat");
                        sb.AppendLine("Subsector_Hydrometric_Site_Lng");
                        sb.AppendLine("|||");

                        LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                        string TagText = sb.ToString();
                        int UnderTVItemID = tvItemModel.TVItemID;
                        string ParentTagItem = tvItemModel.TVType.ToString();
                        bool CountOnly = false;
                        int Take = 10;

                        List<ReportSubsector_Hydrometric_SiteModel> ReportSubsector_Hydrometric_SiteModelList = reportServiceSubsector_Hydrometric_Site.GetReportSubsector_Hydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                        Assert.IsTrue(ReportSubsector_Hydrometric_SiteModelList.Count > 0);
                        Assert.AreEqual("", ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Error);
                        Assert.AreEqual(1, ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Counter);
                        Assert.IsTrue(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_ID > 0);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Fed_Site_Number);
                        //Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Quebec_Site_Number);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Name);
                        //Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Description);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Province);
                        //Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Elevation_m);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Start_Date_Local);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_End_Date_Local);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Time_Offset_hour);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Drainage_Area_km2);
                        //Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Is_Natural);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Is_Active);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Sediment);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_RHBN);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Real_Time);
                        //Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Has_Rating_Curve);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Last_Update_Date_UTC);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Last_Update_Contact_Name);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Last_Update_Contact_Initial);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Lat);
                        Assert.IsNotNull(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Lng);
                    }
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_SiteModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                       where c.SiteType == (int)SiteTypeEnum.Hydrometric
                                       select c).FirstOrDefault();
                Assert.IsNotNull(useOfSite);
                Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Hydrometric_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Hydrometric_SiteModel> ReportSubsector_Hydrometric_SiteModelList = reportServiceSubsector_Hydrometric_Site.GetReportSubsector_Hydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Hydrometric_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_SiteModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                       where c.SiteType == (int)SiteTypeEnum.Hydrometric
                                       select c).FirstOrDefault();
                Assert.IsNotNull(useOfSite);
                Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Hydrometric_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Hydrometric_Site";

                List<string> AllowableParentTagItemList = reportServiceSubsector_Hydrometric_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSubsector_Hydrometric_SiteModel> ReportSubsector_Hydrometric_SiteModelList = reportServiceSubsector_Hydrometric_Site.GetReportSubsector_Hydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Hydrometric_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_SiteModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SetupTest(contactModelListGood[0], culture);

                    UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                           where c.SiteType == (int)SiteTypeEnum.Hydrometric
                                           select c).FirstOrDefault();
                    Assert.IsNotNull(useOfSite);
                    Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                    HydrometricSite HydrometricSite = (from c in hydrometricSiteService.db.HydrometricSites
                                                       where c.HydrometricSiteTVItemID == useOfSite.SiteTVItemID
                                                       select c).FirstOrDefault();

                    if (HydrometricSite == null)
                    {
                        HydrometricSiteModel hydrometricSiteModelNew = new HydrometricSiteModel()
                        {
                            HydrometricSiteTVItemID = useOfSite.SiteTVItemID,
                            HydrometricSiteName = "Some unique name",
                            FedSiteNumber = randomService.RandomString("", 6),
                            QuebecSiteNumber = randomService.RandomString("", 6),
                            Description = randomService.RandomString("", 65),
                            Elevation_m = randomService.RandomFloat(3.4f, 56.6f),
                            StartDate_Local = randomService.RandomDateTime(),
                            EndDate_Local = randomService.RandomDateTime(),
                            TimeOffset_hour = randomService.RandomFloat(-3f, -8f),
                            DrainageArea_km2 = randomService.RandomFloat(3.4f, 56.6f),
                            IsNatural = true,
                            IsActive = true,
                            Sediment = true,
                            RHBN = true,
                            RealTime = true,
                            HasRatingCurve = true,
                            Province = "NB"
                        };

                        hydrometricSiteModelNew.EndDate_Local = hydrometricSiteModelNew.StartDate_Local.Value.AddDays(4);

                        HydrometricSiteModel tideHydrometricModelRet = hydrometricSiteService.PostAddHydrometricSiteDB(hydrometricSiteModelNew);
                        Assert.AreEqual("", tideHydrometricModelRet.Error);
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_ID not");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = (int)useOfSite.SubsectorTVItemID;
                    string ParentTagItem = "Subsector";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Subsector_Hydrometric_Site";

                    List<string> AllowableParentTagItemList = reportServiceSubsector_Hydrometric_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportSubsector_Hydrometric_SiteModel> ReportSubsector_Hydrometric_SiteModelList = reportServiceSubsector_Hydrometric_Site.GetReportSubsector_Hydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_SiteModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_IDNot");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportSubsector_Hydrometric_SiteModelList = reportServiceSubsector_Hydrometric_Site.GetReportSubsector_Hydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_SiteModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_ID");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportSubsector_Hydrometric_SiteModelList = reportServiceSubsector_Hydrometric_Site.GetReportSubsector_Hydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_SiteModelList.Count > 0);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSubsector_Hydrometric_SiteModelList[0].Subsector_Hydrometric_Site_Error));
                }
            }
        }
        #endregion Testing Methods Subsector_Hydrometric_Site
        #region Testing Methods Subsector_Hydrometric_Site_Data
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_DataModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector_Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Hydrometric_Site_Data_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 229465;
                string ParentTagItem = "Subsector_Hydrometric_Site";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Hydrometric_Site_Data";

                List<ReportSubsector_Hydrometric_Site_DataModel> ReportSubsector_Hydrometric_Site_DataModelList = reportServiceSubsector_Hydrometric_Site_Data.GetReportSubsector_Hydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Hydrometric_Site_DataModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_DataModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                       select c).FirstOrDefault();

                    Assert.IsNotNull(hydrometricSite);

                    HydrometricDataValueModel hydrometricDataValueModelNew = new HydrometricDataValueModel()
                    {
                        HydrometricSiteID = hydrometricSite.HydrometricSiteID,
                        DateTime_Local = randomService.RandomDateTime(),
                        Keep = true,
                        StorageDataType = StorageDataTypeEnum.Archived,
                        Flow_m3_s = randomService.RandomFloat(3, 5),
                    };

                    HydrometricDataValueModel hydrometricDataValueModelRet = hydrometricDataValueService.PostAddHydrometricDataValueDB(hydrometricDataValueModelNew);
                    Assert.AreEqual("", hydrometricDataValueModelRet.Error);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_Error");
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_Counter");
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_ID");
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_Date_Time_Local");
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_Hourly_Values");
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_Keep");
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_Flow_m3_s");
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_Last_Update_Date_UTC");
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_Last_Update_Contact_Name");
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = hydrometricSite.HydrometricSiteTVItemID;
                    string ParentTagItem = "Subsector_Hydrometric_Site";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Hydrometric_Site_DataModel> ReportSubsector_Hydrometric_Site_DataModelList = reportServiceSubsector_Hydrometric_Site_Data.GetReportSubsector_Hydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_DataModelList.Count > 0);
                    Assert.AreEqual("", ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Error);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Counter > 0);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_ID > 0);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Date_Time_Local);
                    //Assert.IsNotNull(ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Hourly_Values);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Keep);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Flow_m3_s);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Last_Update_Date_UTC);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Last_Update_Contact_Name);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Last_Update_Contact_Initial);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_DataModelListUnderTVItemIDDB_Loop_Error_ParentTagItem_Not_Box_Model_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                       select c).FirstOrDefault();

                    Assert.IsNotNull(hydrometricSite);

                    HydrometricDataValueModel hydrometricDataValueModelNew = new HydrometricDataValueModel()
                    {
                        HydrometricSiteID = hydrometricSite.HydrometricSiteID,
                        DateTime_Local = randomService.RandomDateTime(),
                        Keep = true,
                        StorageDataType = StorageDataTypeEnum.Archived,
                        Flow_m3_s = randomService.RandomFloat(3, 5),
                    };

                    HydrometricDataValueModel hydrometricDataValueModelRet = hydrometricDataValueService.PostAddHydrometricDataValueDB(hydrometricDataValueModelNew);
                    Assert.AreEqual("", hydrometricDataValueModelRet.Error);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = "Subsector_Hydrometric_SiteNot";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Hydrometric_Site_DataModel> ReportSubsector_Hydrometric_Site_DataModelList = reportServiceSubsector_Hydrometric_Site_Data.GetReportSubsector_Hydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_DataModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Subsector_Hydrometric_Site", ParentTagItem), ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_DataModelListUnderTVItemIDDB_Loop_Error_Box_Model_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                       select c).FirstOrDefault();

                    Assert.IsNotNull(hydrometricSite);

                    HydrometricDataValueModel hydrometricDataValueModelNew = new HydrometricDataValueModel()
                    {
                        HydrometricSiteID = hydrometricSite.HydrometricSiteID,
                        DateTime_Local = randomService.RandomDateTime(),
                        Keep = true,
                        StorageDataType = StorageDataTypeEnum.Archived,
                        Flow_m3_s = randomService.RandomFloat(3, 5),
                    };

                    HydrometricDataValueModel hydrometricDataValueModelRet = hydrometricDataValueService.PostAddHydrometricDataValueDB(hydrometricDataValueModelNew);
                    Assert.AreEqual("", hydrometricDataValueModelRet.Error);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = "Subsector_Hydrometric_Site";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Hydrometric_Site_DataModel> ReportSubsector_Hydrometric_Site_DataModelList = reportServiceSubsector_Hydrometric_Site_Data.GetReportSubsector_Hydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_DataModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite, ServiceRes.HydrometricSiteTVItemID, UnderTVItemID.ToString()), ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_DataModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                       select c).FirstOrDefault();

                    Assert.IsNotNull(hydrometricSite);

                    HydrometricDataValueModel hydrometricDataValueModelNew = new HydrometricDataValueModel()
                    {
                        HydrometricSiteID = hydrometricSite.HydrometricSiteID,
                        DateTime_Local = randomService.RandomDateTime(),
                        Keep = true,
                        StorageDataType = StorageDataTypeEnum.Archived,
                        Flow_m3_s = randomService.RandomFloat(3, 5),
                    };

                    HydrometricDataValueModel hydrometricDataValueModelRet = hydrometricDataValueService.PostAddHydrometricDataValueDB(hydrometricDataValueModelNew);
                    Assert.AreEqual("", hydrometricDataValueModelRet.Error);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_IDNot");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = hydrometricSite.HydrometricSiteTVItemID;
                    string ParentTagItem = "Subsector_Hydrometric_Site";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Subsector_Hydrometric_Site_Data";

                    List<string> AllowableParentTagItemList = reportServiceSubsector_Hydrometric_Site_Data._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportSubsector_Hydrometric_Site_DataModel> ReportSubsector_Hydrometric_Site_DataModelList = reportServiceSubsector_Hydrometric_Site_Data.GetReportSubsector_Hydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_DataModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_IDNot");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportSubsector_Hydrometric_Site_DataModelList = reportServiceSubsector_Hydrometric_Site_Data.GetReportSubsector_Hydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_DataModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Data_ID");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportSubsector_Hydrometric_Site_DataModelList = reportServiceSubsector_Hydrometric_Site_Data.GetReportSubsector_Hydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_DataModelList.Count > 0);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSubsector_Hydrometric_Site_DataModelList[0].Subsector_Hydrometric_Site_Data_Error));
                }
            }
        }
        #endregion Testing Methods Subsector_Hydrometric_Site_Data
        #region Testing Methods Subsector_Hydrometric_Site_Rating_Curve
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                           from u in tvItemService.db.UseOfSites
                                           from h in tvItemService.db.HydrometricSites
                                           where h.HydrometricSiteTVItemID == u.SiteTVItemID
                                           && h.HydrometricSiteID == c.HydrometricSiteID
                                           && u.SiteType == (int)SiteTypeEnum.Hydrometric
                                           select c).FirstOrDefault();
                Assert.IsNotNull(ratingCurve);

                HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                   where c.HydrometricSiteID == ratingCurve.HydrometricSiteID
                                                   select c).FirstOrDefault();
                Assert.IsNotNull(hydrometricSite);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector_Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = hydrometricSite.HydrometricSiteID;
                string ParentTagItem = "Subsector_Hydrometric_Site";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Hydrometric_Site_Rating_Curve";

                List<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportSubsector_Hydrometric_Site_Rating_CurveModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve.GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_CurveModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                               from u in tvItemService.db.UseOfSites
                                               from h in tvItemService.db.HydrometricSites
                                               where h.HydrometricSiteTVItemID == u.SiteTVItemID
                                               && h.HydrometricSiteID == c.HydrometricSiteID
                                               && u.SiteType == (int)SiteTypeEnum.Hydrometric
                                               select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                       where c.HydrometricSiteID == ratingCurve.HydrometricSiteID
                                                       select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricSite);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Error");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Counter");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_ID");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = hydrometricSite.HydrometricSiteTVItemID;
                    string ParentTagItem = "Subsector_Hydrometric_Site";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportSubsector_Hydrometric_Site_Rating_CurveModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve.GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_CurveModelList.Count > 0);
                    Assert.AreEqual("", ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Error);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Counter > 0);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_ID > 0);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Rating_Curve_Number);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB_Loop_Error_ParentTagItem_Not_Hydrometric_Site_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                               from u in tvItemService.db.UseOfSites
                                               from h in tvItemService.db.HydrometricSites
                                               where h.HydrometricSiteTVItemID == u.SiteTVItemID
                                               && h.HydrometricSiteID == c.HydrometricSiteID
                                               && u.SiteType == (int)SiteTypeEnum.Hydrometric
                                               select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                       where c.HydrometricSiteID == ratingCurve.HydrometricSiteID
                                                       select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricSite);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = hydrometricSite.HydrometricSiteID;
                    string ParentTagItem = "Subsector_Hydrometric_SiteNot";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportSubsector_Hydrometric_Site_Rating_CurveModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve.GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_CurveModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Subsector_Hydrometric_Site", ParentTagItem), ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB_Loop_Error_Hydrometric_Site_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                               from u in tvItemService.db.UseOfSites
                                               from h in tvItemService.db.HydrometricSites
                                               where h.HydrometricSiteTVItemID == u.SiteTVItemID
                                               && h.HydrometricSiteID == c.HydrometricSiteID
                                               && u.SiteType == (int)SiteTypeEnum.Hydrometric
                                               select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                       where c.HydrometricSiteID == ratingCurve.HydrometricSiteID
                                                       select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricSite);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = "Subsector_Hydrometric_Site";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportSubsector_Hydrometric_Site_Rating_CurveModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve.GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_CurveModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite, ServiceRes.HydrometricSiteTVItemID, UnderTVItemID.ToString()), ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                               from u in tvItemService.db.UseOfSites
                                               from h in tvItemService.db.HydrometricSites
                                               where h.HydrometricSiteTVItemID == u.SiteTVItemID
                                               && h.HydrometricSiteID == c.HydrometricSiteID
                                               && u.SiteType == (int)SiteTypeEnum.Hydrometric
                                               select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                       where c.HydrometricSiteID == ratingCurve.HydrometricSiteID
                                                       select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricSite);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_IDNot");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = hydrometricSite.HydrometricSiteTVItemID;
                    string ParentTagItem = "Subsector_Hydrometric_Site";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Subsector_Hydrometric_Site_Rating_Curve";

                    List<string> AllowableParentTagItemList = reportServiceSubsector_Hydrometric_Site_Rating_Curve._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportSubsector_Hydrometric_Site_Rating_CurveModel> ReportSubsector_Hydrometric_Site_Rating_CurveModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve.GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_CurveModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_IDNot");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportSubsector_Hydrometric_Site_Rating_CurveModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve.GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_CurveModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_ID");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportSubsector_Hydrometric_Site_Rating_CurveModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve.GetReportSubsector_Hydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_CurveModelList.Count > 0);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSubsector_Hydrometric_Site_Rating_CurveModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Error));
                }
            }
        }
        #endregion Testing Methods Subsector_Hydrometric_Site_Rating_Curve
        #region Testing Methods Subsector_Hydrometric_Site_Rating_Curve_Value
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                           from u in tvItemService.db.UseOfSites
                                           from h in tvItemService.db.HydrometricSites
                                           where h.HydrometricSiteTVItemID == u.SiteTVItemID
                                           && h.HydrometricSiteID == c.HydrometricSiteID
                                           && u.SiteType == (int)SiteTypeEnum.Hydrometric
                                           select c).FirstOrDefault();
                Assert.IsNotNull(ratingCurve);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector_Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ratingCurve.RatingCurveID;
                string ParentTagItem = "Subsector_Hydrometric_Site_Rating_Curve";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Hydrometric_Site_Rating_Curve_Value";

                List<ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModel> ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve_Value.GetReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                               from u in tvItemService.db.UseOfSites
                                               from h in tvItemService.db.HydrometricSites
                                               where h.HydrometricSiteTVItemID == u.SiteTVItemID
                                               && h.HydrometricSiteID == c.HydrometricSiteID
                                               && u.SiteType == (int)SiteTypeEnum.Hydrometric
                                               select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_Error");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_Counter");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_ID");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_Stage_Value_m");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name");
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = ratingCurve.RatingCurveID;
                    string ParentTagItem = "Subsector_Hydrometric_Site_Rating_Curve";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModel> ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve_Value.GetReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                    Assert.AreEqual("", ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Error);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Counter > 0);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_ID > 0);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Stage_Value_m);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name);
                    Assert.IsNotNull(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB_Loop_Error_ParentTagItem_Not_Subsector_Hydrometric_Site_Rating_Curve_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                               from u in tvItemService.db.UseOfSites
                                               from h in tvItemService.db.HydrometricSites
                                               where h.HydrometricSiteTVItemID == u.SiteTVItemID
                                               && h.HydrometricSiteID == c.HydrometricSiteID
                                               && u.SiteType == (int)SiteTypeEnum.Hydrometric
                                               select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = ratingCurve.RatingCurveID;
                    string ParentTagItem = "Subsector_Hydrometric_Site_Rating_CurveNot";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModel> ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve_Value.GetReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Subsector_Hydrometric_Site_Rating_Curve", ParentTagItem), ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB_Loop_Error_Subsector_Hydrometric_Site_Rating_Curve_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                               from u in tvItemService.db.UseOfSites
                                               from h in tvItemService.db.HydrometricSites
                                               where h.HydrometricSiteTVItemID == u.SiteTVItemID
                                               && h.HydrometricSiteID == c.HydrometricSiteID
                                               && u.SiteType == (int)SiteTypeEnum.Hydrometric
                                               select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = "Subsector_Hydrometric_Site_Rating_Curve";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModel> ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve_Value.GetReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.RatingCurve, ServiceRes.RatingCurveID, UnderTVItemID.ToString()), ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                               from u in tvItemService.db.UseOfSites
                                               from h in tvItemService.db.HydrometricSites
                                               where h.HydrometricSiteTVItemID == u.SiteTVItemID
                                               && h.HydrometricSiteID == c.HydrometricSiteID
                                               && u.SiteType == (int)SiteTypeEnum.Hydrometric
                                               select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_IDNot");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = ratingCurve.RatingCurveID;
                    string ParentTagItem = "Subsector_Hydrometric_Site_Rating_Curve";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Subsector_Hydrometric_Site_Rating_Curve_Value";

                    List<string> AllowableParentTagItemList = reportServiceSubsector_Hydrometric_Site_Rating_Curve_Value._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModel> ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve_Value.GetReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_IDNot");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve_Value.GetReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Hydrometric_Site_Rating_Curve_Value_ID");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList = reportServiceSubsector_Hydrometric_Site_Rating_Curve_Value.GetReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSubsector_Hydrometric_Site_Rating_Curve_ValueModelList[0].Subsector_Hydrometric_Site_Rating_Curve_Value_Error));
                }
            }
        }
        #endregion Testing Methods Subsector_Hydrometric_Site_Rating_Curve_Value
        #region Testing Methods Subsector_Tide_Site
        [TestMethod]
        public void ReportService_GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                       where c.SiteType == (int)SiteTypeEnum.Tide
                                       select c).FirstOrDefault();
                Assert.IsNotNull(useOfSite);
                Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                TVItemModel tvItemModelSubsector = tvItemService.GetTVItemModelWithTVItemIDDB(useOfSite.SubsectorTVItemID);
                Assert.AreEqual("", tvItemModelSubsector.Error);

                TVItemModel tvItemModelSector = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelSubsector.ParentID);
                Assert.AreEqual("", tvItemModelSector.Error);

                TVItemModel tvItemModelArea = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelSector.ParentID);
                Assert.AreEqual("", tvItemModelArea.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelArea.ParentID);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelProvince.ParentID);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);


                List<TVItemModel> tvItemModelList = new List<TVItemModel>()
                {
                    tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector
                };

                foreach (TVItemModel tvItemModel in tvItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Subsector_Tide_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Tide_Site_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = (int)tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Subsector_Tide_Site";

                    List<ReportSubsector_Tide_SiteModel> ReportSubsector_Tide_SiteModelList = reportServiceSubsector_Tide_Site.GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Tide_SiteModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SetupTest(contactModelListGood[0], culture);

                    UseOfSite useOfSite = (from c in tideSiteService.db.UseOfSites
                                           where c.SiteType == (int)SiteTypeEnum.Tide
                                           select c).FirstOrDefault();
                    Assert.IsNotNull(useOfSite);
                    Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                    TideSite tideSite = (from c in tideSiteService.db.TideSites
                                         where c.TideSiteTVItemID == useOfSite.SiteTVItemID
                                         select c).FirstOrDefault();

                    if (tideSite == null)
                    {
                        TideSiteModel tideSiteModelNew = new TideSiteModel()
                        {
                            TideSiteTVItemID = useOfSite.SiteTVItemID,
                            TideSiteTVText = "something unique",
                            WebTideDatum_m = randomService.RandomFloat(2.3f, 3.4f),
                            WebTideModel = "web tide model",
                        };

                        TideSiteModel tideSiteModelRet = tideSiteService.PostAddTideSiteDB(tideSiteModelNew);
                        Assert.AreEqual("", tideSiteModelRet.Error);
                    }

                    TVItemModel tvItemModelSubsector = tvItemService.GetTVItemModelWithTVItemIDDB(useOfSite.SubsectorTVItemID);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    TVItemModel tvItemModelSector = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelSubsector.ParentID);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    TVItemModel tvItemModelArea = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelSector.ParentID);
                    Assert.AreEqual("", tvItemModelArea.Error);

                    TVItemModel tvItemModelProvince = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelArea.ParentID);
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    TVItemModel tvItemModelCountry = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelProvince.ParentID);
                    Assert.AreEqual("", tvItemModelCountry.Error);

                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);


                    List<TVItemModel> tvItemModelList = new List<TVItemModel>()
                    {
                    tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector
                    };

                    foreach (TVItemModel tvItemModel in tvItemModelList)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("|||Loop Subsector_Tide_Site " + culture.TwoLetterISOLanguageName);
                        sb.AppendLine("Subsector_Tide_Site_Error");
                        sb.AppendLine("Subsector_Tide_Site_Counter");
                        sb.AppendLine("Subsector_Tide_Site_ID");
                        sb.AppendLine("Subsector_Tide_Site_Name_Translation_Status");
                        sb.AppendLine("Subsector_Tide_Site_Name");
                        sb.AppendLine("Subsector_Tide_Site_Is_Active");
                        sb.AppendLine("Subsector_Tide_Site_Web_Tide_Model");
                        sb.AppendLine("Subsector_Tide_Site_Web_Tide_Datum_m");
                        sb.AppendLine("Subsector_Tide_Site_Last_Update_Date_And_Time_UTC");
                        sb.AppendLine("Subsector_Tide_Site_Last_Update_Contact_Name");
                        sb.AppendLine("Subsector_Tide_Site_Last_Update_Contact_Initial");
                        sb.AppendLine("Subsector_Tide_Site_Lat");
                        sb.AppendLine("Subsector_Tide_Site_Lng");
                        sb.AppendLine("|||");

                        LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                        string TagText = sb.ToString();
                        int UnderTVItemID = tvItemModel.TVItemID;
                        string ParentTagItem = tvItemModel.TVType.ToString();
                        bool CountOnly = false;
                        int Take = 10;

                        List<ReportSubsector_Tide_SiteModel> ReportSubsector_Tide_SiteModelList = reportServiceSubsector_Tide_Site.GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                        Assert.IsTrue(ReportSubsector_Tide_SiteModelList.Count > 0);
                        Assert.AreEqual("", ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Error);
                        Assert.AreEqual(1, ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Counter);
                        Assert.IsTrue(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_ID > 0);
                        Assert.IsNotNull(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Name_Translation_Status);
                        Assert.IsNotNull(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Name);
                        Assert.IsNotNull(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Is_Active);
                        Assert.IsNotNull(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Web_Tide_Model);
                        Assert.IsNotNull(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Web_Tide_Datum_m);
                        Assert.IsNotNull(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Last_Update_Date_And_Time_UTC);
                        Assert.IsNotNull(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Last_Update_Contact_Name);
                        Assert.IsNotNull(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Last_Update_Contact_Initial);
                        Assert.IsNotNull(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Lat);
                        Assert.IsNotNull(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Lng);
                    }
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                       where c.SiteType == (int)SiteTypeEnum.Tide
                                       select c).FirstOrDefault();
                Assert.IsNotNull(useOfSite);
                Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Tide_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Tide_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Tide_SiteModel> ReportSubsector_Tide_SiteModelList = reportServiceSubsector_Tide_Site.GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Tide_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                       where c.SiteType == (int)SiteTypeEnum.Tide
                                       select c).FirstOrDefault();
                Assert.IsNotNull(useOfSite);
                Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Tide_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Tide_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Tide_Site";

                List<string> AllowableParentTagItemList = reportServiceSubsector_Tide_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSubsector_Tide_SiteModel> ReportSubsector_Tide_SiteModelList = reportServiceSubsector_Tide_Site.GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Tide_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SetupTest(contactModelListGood[0], culture);

                    UseOfSite useOfSite = (from c in tvItemService.db.UseOfSites
                                           where c.SiteType == (int)SiteTypeEnum.Tide
                                           select c).FirstOrDefault();
                    Assert.IsNotNull(useOfSite);
                    Assert.IsTrue(useOfSite.SubsectorTVItemID > 0);

                    TideSite tideSite = (from c in tideSiteService.db.TideSites
                                         where c.TideSiteTVItemID == useOfSite.SiteTVItemID
                                         select c).FirstOrDefault();

                    if (tideSite == null)
                    {
                        TideSiteModel tideSiteModelNew = new TideSiteModel()
                        {
                            TideSiteTVItemID = useOfSite.SiteTVItemID,
                            TideSiteTVText = "something unique",
                            WebTideDatum_m = randomService.RandomFloat(2.3f, 3.4f),
                            WebTideModel = "web tide model",
                        };

                        TideSiteModel tideSiteModelRet = tideSiteService.PostAddTideSiteDB(tideSiteModelNew);
                        Assert.AreEqual("", tideSiteModelRet.Error);
                    }
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Tide_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Tide_Site_ID not");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = (int)useOfSite.SubsectorTVItemID;
                    string ParentTagItem = "Subsector";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Subsector_Tide_Site";

                    List<string> AllowableParentTagItemList = reportServiceSubsector_Tide_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportSubsector_Tide_SiteModel> ReportSubsector_Tide_SiteModelList = reportServiceSubsector_Tide_Site.GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Tide_SiteModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Tide_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Tide_Site_IDNot");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportSubsector_Tide_SiteModelList = reportServiceSubsector_Tide_Site.GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Tide_SiteModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Tide_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Tide_Site_ID");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportSubsector_Tide_SiteModelList = reportServiceSubsector_Tide_Site.GetReportSubsector_Tide_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Tide_SiteModelList.Count > 0);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSubsector_Tide_SiteModelList[0].Subsector_Tide_Site_Error));
                }
            }
        }
        #endregion Testing Methods Subsector_Tide_Site
        #region Testing Methods Subsector_Tide_Site_Data
        [TestMethod]
        public void ReportService_GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector_Tide_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Tide_Site_Data_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 229465;
                string ParentTagItem = "Subsector_Tide_Site";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Tide_Site_Data";

                List<ReportSubsector_Tide_Site_DataModel> ReportSubsector_Tide_Site_DataModelList = reportServiceSubsector_Tide_Site_Data.GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Tide_Site_DataModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSite TideSite = (from c in tvItemService.db.TideSites
                                         select c).FirstOrDefault();

                    Assert.IsNotNull(TideSite);

                    TideDataValueModel TideDataValueModelNew = new TideDataValueModel()
                    {
                        TideSiteTVItemID = TideSite.TideSiteTVItemID,
                        DateTime_Local = randomService.RandomDateTime(),
                        Keep = true,
                        TideDataType = TideDataTypeEnum.Min15,
                        StorageDataType = StorageDataTypeEnum.Archived,
                        Depth_m = randomService.RandomFloat(3, 5),
                        UVelocity_m_s = randomService.RandomFloat(3, 5),
                        VVelocity_m_s = randomService.RandomFloat(3, 5),
                        TideStart = TideTextEnum.HighTide,
                        TideEnd = TideTextEnum.HighTide,
                    };

                    TideDataValueModel TideDataValueModelRet = tideDataValueService.PostAddTideDataValueDB(TideDataValueModelNew);
                    Assert.AreEqual("", TideDataValueModelRet.Error);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Tide_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Tide_Site_Data_Error");
                    sb.AppendLine("Subsector_Tide_Site_Data_Counter");
                    sb.AppendLine("Subsector_Tide_Site_Data_ID");
                    sb.AppendLine("Subsector_Tide_Site_Data_Date_Time_Local");
                    sb.AppendLine("Subsector_Tide_Site_Data_Keep");
                    sb.AppendLine("Subsector_Tide_Site_Data_Tide_Data_Type");
                    sb.AppendLine("Subsector_Tide_Site_Data_Storage_Data_Type");
                    sb.AppendLine("Subsector_Tide_Site_Data_Depth_m");
                    sb.AppendLine("Subsector_Tide_Site_Data_U_Velocity_m_s");
                    sb.AppendLine("Subsector_Tide_Site_Data_V_Velocity_m_s");
                    sb.AppendLine("Subsector_Tide_Site_Data_Tide_Start");
                    sb.AppendLine("Subsector_Tide_Site_Data_Tide_End");
                    sb.AppendLine("Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC");
                    sb.AppendLine("Subsector_Tide_Site_Data_Last_Update_Contact_Name");
                    sb.AppendLine("Subsector_Tide_Site_Data_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = TideSite.TideSiteTVItemID;
                    string ParentTagItem = "Subsector_Tide_Site";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Tide_Site_DataModel> ReportSubsector_Tide_Site_DataModelList = reportServiceSubsector_Tide_Site_Data.GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Tide_Site_DataModelList.Count > 0);
                    Assert.AreEqual("", ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Error);
                    Assert.IsTrue(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Counter > 0);
                    Assert.IsTrue(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_ID > 0);
                    Assert.IsNotNull(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Date_Time_Local);
                    Assert.IsNotNull(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Keep);
                    Assert.IsNotNull(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Tide_Data_Type);
                    Assert.IsNotNull(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Storage_Data_Type);
                    Assert.IsNotNull(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Depth_m);
                    Assert.IsNotNull(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_U_Velocity_m_s);
                    Assert.IsNotNull(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_V_Velocity_m_s);
                    Assert.IsNotNull(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Tide_Start);
                    Assert.IsNotNull(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Tide_End);
                    Assert.IsNotNull(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC);
                    Assert.IsNotNull(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Last_Update_Contact_Name);
                    Assert.IsNotNull(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Last_Update_Contact_Initial);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB_Loop_Error_ParentTagItem_Not_Box_Model_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSite TideSite = (from c in tvItemService.db.TideSites
                                         select c).FirstOrDefault();

                    Assert.IsNotNull(TideSite);

                    TideDataValueModel TideDataValueModelNew = new TideDataValueModel()
                    {
                        TideSiteTVItemID = TideSite.TideSiteTVItemID,
                        DateTime_Local = randomService.RandomDateTime(),
                        Keep = true,
                        TideDataType = TideDataTypeEnum.Min15,
                        StorageDataType = StorageDataTypeEnum.Archived,
                        Depth_m = randomService.RandomFloat(3, 5),
                        UVelocity_m_s = randomService.RandomFloat(3, 5),
                        VVelocity_m_s = randomService.RandomFloat(3, 5),
                        TideStart = TideTextEnum.HighTide,
                        TideEnd = TideTextEnum.HighTide,
                    };

                    TideDataValueModel TideDataValueModelRet = tideDataValueService.PostAddTideDataValueDB(TideDataValueModelNew);
                    Assert.AreEqual("", TideDataValueModelRet.Error);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Tide_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Tide_Site_Data_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = "Subsector_Tide_SiteNot";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Tide_Site_DataModel> ReportSubsector_Tide_Site_DataModelList = reportServiceSubsector_Tide_Site_Data.GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Tide_Site_DataModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Subsector_Tide_Site", ParentTagItem), ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB_Loop_Error_Box_Model_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSite TideSite = (from c in tvItemService.db.TideSites
                                         select c).FirstOrDefault();

                    Assert.IsNotNull(TideSite);

                    TideDataValueModel TideDataValueModelNew = new TideDataValueModel()
                    {
                        TideSiteTVItemID = TideSite.TideSiteTVItemID,
                        DateTime_Local = randomService.RandomDateTime(),
                        Keep = true,
                        TideDataType = TideDataTypeEnum.Min15,
                        StorageDataType = StorageDataTypeEnum.Archived,
                        Depth_m = randomService.RandomFloat(3, 5),
                        UVelocity_m_s = randomService.RandomFloat(3, 5),
                        VVelocity_m_s = randomService.RandomFloat(3, 5),
                        TideStart = TideTextEnum.HighTide,
                        TideEnd = TideTextEnum.HighTide,
                    };

                    TideDataValueModel TideDataValueModelRet = tideDataValueService.PostAddTideDataValueDB(TideDataValueModelNew);
                    Assert.AreEqual("", TideDataValueModelRet.Error);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Tide_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Tide_Site_Data_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = "Subsector_Tide_Site";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportSubsector_Tide_Site_DataModel> ReportSubsector_Tide_Site_DataModelList = reportServiceSubsector_Tide_Site_Data.GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Tide_Site_DataModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TideSite, ServiceRes.TideSiteTVItemID, UnderTVItemID.ToString()), ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSite TideSite = (from c in tvItemService.db.TideSites
                                         select c).FirstOrDefault();

                    Assert.IsNotNull(TideSite);

                    TideDataValueModel TideDataValueModelNew = new TideDataValueModel()
                    {
                        TideSiteTVItemID = TideSite.TideSiteTVItemID,
                        DateTime_Local = randomService.RandomDateTime(),
                        Keep = true,
                        TideDataType = TideDataTypeEnum.Min15,
                        StorageDataType = StorageDataTypeEnum.Archived,
                        Depth_m = randomService.RandomFloat(3, 5),
                        UVelocity_m_s = randomService.RandomFloat(3, 5),
                        VVelocity_m_s = randomService.RandomFloat(3, 5),
                        TideStart = TideTextEnum.HighTide,
                        TideEnd = TideTextEnum.HighTide,
                    };

                    TideDataValueModel TideDataValueModelRet = tideDataValueService.PostAddTideDataValueDB(TideDataValueModelNew);
                    Assert.AreEqual("", TideDataValueModelRet.Error);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Tide_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Tide_Site_Data_IDNot");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = TideSite.TideSiteTVItemID;
                    string ParentTagItem = "Subsector_Tide_Site";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Subsector_Tide_Site_Data";

                    List<string> AllowableParentTagItemList = reportServiceSubsector_Tide_Site_Data._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportSubsector_Tide_Site_DataModel> ReportSubsector_Tide_Site_DataModelList = reportServiceSubsector_Tide_Site_Data.GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Tide_Site_DataModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Tide_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Tide_Site_Data_IDNot");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportSubsector_Tide_Site_DataModelList = reportServiceSubsector_Tide_Site_Data.GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Tide_Site_DataModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Subsector_Tide_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Subsector_Tide_Site_Data_ID");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportSubsector_Tide_Site_DataModelList = reportServiceSubsector_Tide_Site_Data.GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportSubsector_Tide_Site_DataModelList.Count > 0);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSubsector_Tide_Site_DataModelList[0].Subsector_Tide_Site_Data_Error));
                }
            }
        }
        #endregion Testing Methods Subsector_Tide_Site_Data
        #region Testing Methods Subsector_Lab_Sheet
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_ID");
                sb.AppendLine("|||");

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.SubsectorTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.SubsectorTVItemID > 0);

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.SubsectorTVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Lab_Sheet";

                List<ReportSubsector_Lab_SheetModel> ReportSubsector_Lab_SheetModelList = reportServiceSubsector_Lab_Sheet.GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_SheetModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.SubsectorTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.SubsectorTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_Error");
                sb.AppendLine("Subsector_Lab_Sheet_Counter");
                sb.AppendLine("Subsector_Lab_Sheet_ID");
                sb.AppendLine("Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID");
                sb.AppendLine("Subsector_Lab_Sheet_Sampling_Plan_Name");
                sb.AppendLine("Subsector_Lab_Sheet_Province");
                sb.AppendLine("Subsector_Lab_Sheet_For_Group_Name");
                sb.AppendLine("Subsector_Lab_Sheet_Year");
                sb.AppendLine("Subsector_Lab_Sheet_Month");
                sb.AppendLine("Subsector_Lab_Sheet_Day");
                sb.AppendLine("Subsector_Lab_Sheet_Secret_Code");
                sb.AppendLine("Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria");
                sb.AppendLine("Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria");
                sb.AppendLine("Subsector_Lab_Sheet_Subsector_Name_Short");
                sb.AppendLine("Subsector_Lab_Sheet_Subsector_Name_Long");
                sb.AppendLine("Subsector_Lab_Sheet_Sampling_Plan_Type");
                sb.AppendLine("Subsector_Lab_Sheet_Sample_Type");
                sb.AppendLine("Subsector_Lab_Sheet_Type");
                sb.AppendLine("Subsector_Lab_Sheet_Status");
                sb.AppendLine("Subsector_Lab_Sheet_File_Name");
                sb.AppendLine("Subsector_Lab_Sheet_File_Last_Modified_Date_Local");
                sb.AppendLine("Subsector_Lab_Sheet_File_Content");
                sb.AppendLine("Subsector_Lab_Sheet_Approved_Or_Rejected_By_Contact_Name");
                sb.AppendLine("Subsector_Lab_Sheet_Approved_Or_Rejected_By_Contact_Initial");
                sb.AppendLine("Subsector_Lab_Sheet_Approved_Or_Rejected_Date_Time");
                sb.AppendLine("Subsector_Lab_Sheet_Last_Update_Date_UTC");
                sb.AppendLine("Subsector_Lab_Sheet_Last_Update_Contact_Name");
                sb.AppendLine("Subsector_Lab_Sheet_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.SubsectorTVItemID;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Lab_SheetModel> ReportSubsector_Lab_SheetModelList = reportServiceSubsector_Lab_Sheet.GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_SheetModelList.Count > 0);
                Assert.AreEqual("", ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Error);
                Assert.AreEqual(1, ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Counter);
                Assert.IsTrue(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_ID > 0);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Other_Server_Lab_Sheet_ID);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Sampling_Plan_Name);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Province);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_For_Group_Name);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Year);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Month);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Day);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Secret_Code);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Daily_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Intertech_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Subsector_Name_Short);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Subsector_Name_Long);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Sampling_Plan_Type);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Sample_Type);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Type);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Status);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_File_Name);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_File_Last_Modified_Date_Local);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_File_Content);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Approved_Or_Rejected_By_Contact_Name);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Approved_Or_Rejected_By_Contact_Initial);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Approved_Or_Rejected_Date_Time);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMRunTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Lab_SheetModel> ReportSubsector_Lab_SheetModelList = reportServiceSubsector_Lab_Sheet.GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_SheetModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMRunTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Lab_Sheet";

                List<string> AllowableParentTagItemList = reportServiceSubsector_Lab_Sheet._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSubsector_Lab_SheetModel> ReportSubsector_Lab_SheetModelList = reportServiceSubsector_Lab_Sheet.GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_SheetModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.SubsectorTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.SubsectorTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.SubsectorTVItemID;
                string ParentTagItem = "Subsector";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Lab_Sheet";

                List<string> AllowableParentTagItemList = reportServiceSubsector_Lab_Sheet._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportSubsector_Lab_SheetModel> ReportSubsector_Lab_SheetModelList = reportServiceSubsector_Lab_Sheet.GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_SheetModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSubsector_Lab_SheetModelList = reportServiceSubsector_Lab_Sheet.GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_SheetModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportSubsector_Lab_SheetModelList = reportServiceSubsector_Lab_Sheet.GetReportSubsector_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_SheetModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportSubsector_Lab_SheetModelList[0].Subsector_Lab_Sheet_Error));
            }
        }
        #endregion Testing Methods Subsector_Lab_Sheet
        #region Testing Methods Subsector_Lab_Sheet_Detail
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_Sheet_DetailModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector_Lab_Sheet_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_Detail_ID");
                sb.AppendLine("|||");

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.SubsectorTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.SubsectorTVItemID > 0);

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheet.LabSheetID;
                string ParentTagItem = "Subsector_Lab_Sheet";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Lab_Sheet_Detail";

                List<ReportSubsector_Lab_Sheet_DetailModel> ReportSubsector_Lab_Sheet_DetailModelList = reportServiceSubsector_Lab_Sheet_Detail.GetReportSubsector_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_Sheet_DetailModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.SubsectorTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.SubsectorTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Lab_Sheet_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Error");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Counter");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_ID");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Version");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Run_Date");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Tides");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Sample_Crew_Initials");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Water_Bath1");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Water_Bath2");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Water_Bath3");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_TC_Field_1");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_TC_Lab_1");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_TC_Field_2");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_TC_Lab_2");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_TC_First");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_TC_Average");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Control_Lot");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Positive_35");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Non_Target_35");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Negative_35");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Blank_35");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Lot_35");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Lot_44_5");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Weather");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Run_Comment");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Salinities_Read_By");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Salinities_Read_Date");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Results_Read_By");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Results_Read_Date");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Results_Recorded_By");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Results_Recorded_Date");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Daily_Duplicate_R_Log");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Daily_Duplicate_Acceptable");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Intertech_Duplicate_R_Log");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Intertech_Read_Acceptable");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name");
                sb.AppendLine("Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.LabSheetID;
                string ParentTagItem = "Subsector_Lab_Sheet";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Lab_Sheet_DetailModel> ReportSubsector_Lab_Sheet_DetailModelList = reportServiceSubsector_Lab_Sheet_Detail.GetReportSubsector_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual("", ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Error);
                Assert.AreEqual(1, ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Counter);
                Assert.IsTrue(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_ID > 0);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Version);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Run_Date);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Tides);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Sample_Crew_Initials);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Water_Bath1);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Water_Bath2);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Water_Bath3);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_TC_Field_1);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_TC_Lab_1);
                //Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_TC_Field_2);
                //Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_TC_Lab_2);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_TC_First);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_TC_Average);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Control_Lot);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Positive_35);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Non_Target_35);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Negative_35);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Blank_35);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Lot_35);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Lot_44_5);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Weather);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Run_Comment);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Salinities_Read_By);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Salinities_Read_Date);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Results_Read_By);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Results_Read_Date);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Results_Recorded_By);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Results_Recorded_Date);
                //Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Daily_Duplicate_R_Log);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Daily_Duplicate_Acceptable);
                //Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Intertech_Duplicate_R_Log);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Intertech_Read_Acceptable);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_Sheet_DetailModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.SubsectorTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.SubsectorTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Lab_Sheet_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_Detail_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Subsector_Lab_Sheet";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Lab_Sheet_DetailModel> ReportSubsector_Lab_Sheet_DetailModelList = reportServiceSubsector_Lab_Sheet_Detail.GetReportSubsector_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheet, ServiceRes.LabSheetID, UnderTVItemID.ToString()), ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_Sheet_DetailModelListUnderTVItemIDDB_Loop_ParentTagItem_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.SubsectorTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.SubsectorTVItemID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Lab_Sheet_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_Detail_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheet.LabSheetID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Lab_Sheet_DetailModel> ReportSubsector_Lab_Sheet_DetailModelList = reportServiceSubsector_Lab_Sheet_Detail.GetReportSubsector_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Subsector_Lab_Sheet", ParentTagItem), ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Error);

                ParentTagItem = "Municipality";

                ReportSubsector_Lab_Sheet_DetailModelList = reportServiceSubsector_Lab_Sheet_Detail.GetReportSubsector_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Subsector_Lab_Sheet", ParentTagItem), ReportSubsector_Lab_Sheet_DetailModelList[0].Subsector_Lab_Sheet_Detail_Error);
            }
        }
        #endregion Testing Methods Subsector_Lab_Sheet_Detail
        #region Testing Methods Subsector_Lab_Sheet_Tube_And_MPN_Detail
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Subsector_Lab_Sheet_Tube_And_MPN_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID");
                sb.AppendLine("|||");

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.SubsectorTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.SubsectorTVItemID > 0);

                LabSheetDetail labSheetDetail = (from c in labSheetService.db.LabSheetDetails
                                                 where c.LabSheetID == labSheet.LabSheetID
                                                 select c).FirstOrDefault();
                Assert.IsNotNull(labSheetDetail);
                Assert.IsTrue(labSheetDetail.LabSheetDetailID > 0);

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheetDetail.LabSheetDetailID;
                string ParentTagItem = "Subsector_Lab_Sheet_Detail";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Subsector_Lab_Sheet_Tube_And_MPN_Detail";

                List<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceSubsector_Lab_Sheet_Tube_And_MPN_Detail.GetReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.SubsectorTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.SubsectorTVItemID > 0);

                LabSheetDetail labSheetDetail = (from c in labSheetService.db.LabSheetDetails
                                                 where c.LabSheetID == labSheet.LabSheetID
                                                 select c).FirstOrDefault();
                Assert.IsNotNull(labSheetDetail);
                Assert.IsTrue(labSheetDetail.LabSheetDetailID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Lab_Sheet_Tube_And_MPN_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Counter");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Ordinal");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_MPN");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_10");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Salinity");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Temperature");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name");
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheetDetail.LabSheetDetailID;
                string ParentTagItem = "Subsector_Lab_Sheet_Detail";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceSubsector_Lab_Sheet_Tube_And_MPN_Detail.GetReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual("", ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error);
                Assert.AreEqual(1, ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Counter);
                Assert.IsTrue(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID > 0);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Ordinal);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_MPN);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_10);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Salinity);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Temperature);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Processed_By);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type);
                //Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.SubsectorTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.SubsectorTVItemID > 0);

                LabSheetDetail labSheetDetail = (from c in labSheetService.db.LabSheetDetails
                                                 where c.LabSheetID == labSheet.LabSheetID
                                                 select c).FirstOrDefault();
                Assert.IsNotNull(labSheetDetail);
                Assert.IsTrue(labSheetDetail.LabSheetDetailID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Lab_Sheet_Tube_And_MPN_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Subsector_Lab_Sheet_Detail";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceSubsector_Lab_Sheet_Tube_And_MPN_Detail.GetReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheetTubeMPNDetail, ServiceRes.LabSheetDetailID, UnderTVItemID.ToString()), ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB_Loop_ParentTagItem_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.SubsectorTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.SubsectorTVItemID > 0);

                LabSheetDetail labSheetDetail = (from c in labSheetService.db.LabSheetDetails
                                                 where c.LabSheetID == labSheet.LabSheetID
                                                 select c).FirstOrDefault();
                Assert.IsNotNull(labSheetDetail);
                Assert.IsTrue(labSheetDetail.LabSheetDetailID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Subsector_Lab_Sheet_Tube_And_MPN_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Subsector_Lab_Sheet_Tube_And_MPN_Detail_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheetDetail.LabSheetDetailID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModel> ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceSubsector_Lab_Sheet_Tube_And_MPN_Detail.GetReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Subsector_Lab_Sheet_Detail", ParentTagItem), ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error);

                ParentTagItem = "Municipality";

                ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceSubsector_Lab_Sheet_Tube_And_MPN_Detail.GetReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Subsector_Lab_Sheet_Detail", ParentTagItem), ReportSubsector_Lab_Sheet_Tube_And_MPN_DetailModelList[0].Subsector_Lab_Sheet_Tube_And_MPN_Detail_Error);
            }
        }
        #endregion Testing Methods Subsector_Lab_Sheet_Tube_And_MPN_Detail
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
            reportServiceSubsector = new ReportServiceSubsector((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_Special_Table = new ReportServiceSubsector_Special_Table((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_Climate_Site = new ReportServiceSubsector_Climate_Site((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_Climate_Site_Data = new ReportServiceSubsector_Climate_Site_Data((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_File = new ReportServiceSubsector_File((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_Hydrometric_Site = new ReportServiceSubsector_Hydrometric_Site((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_Hydrometric_Site_Data = new ReportServiceSubsector_Hydrometric_Site_Data((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_Hydrometric_Site_Rating_Curve = new ReportServiceSubsector_Hydrometric_Site_Rating_Curve((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_Hydrometric_Site_Rating_Curve_Value = new ReportServiceSubsector_Hydrometric_Site_Rating_Curve_Value((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_Lab_Sheet = new ReportServiceSubsector_Lab_Sheet((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_Lab_Sheet_Detail = new ReportServiceSubsector_Lab_Sheet_Detail((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_Lab_Sheet_Tube_And_MPN_Detail = new ReportServiceSubsector_Lab_Sheet_Tube_And_MPN_Detail((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_Tide_Site = new ReportServiceSubsector_Tide_Site((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceSubsector_Tide_Site_Data = new ReportServiceSubsector_Tide_Site_Data((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportServiceSubsector = new ShimReportServiceSubsector(reportServiceSubsector);
        }
        #endregion Functions private
    }
}

