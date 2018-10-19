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
    public class ReportServiceRootTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceRoot reportServiceRoot { get; set; }
        private ReportServiceRoot_File reportServiceRoot_File { get; set; }
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
        public ReportServiceRootTest()
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
        #region Testing Methods Root
        [TestMethod]
        public void ReportService_GetReportRootModelListUnderTVItemIDDB_Start_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Root " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Root_Error");
                sb.AppendLine("Root_Counter");
                sb.AppendLine("Root_ID");
                sb.AppendLine("Root_Name_Translation_Status");
                sb.AppendLine("Root_Name");
                sb.AppendLine("Root_Is_Active");
                sb.AppendLine("Root_Last_Update_Date_And_Time");
                sb.AppendLine("Root_Last_Update_Contact_Name");
                sb.AppendLine("Root_Last_Update_Contact_Initial");
                sb.AppendLine("Root_Lat");
                sb.AppendLine("Root_Lng");
                sb.AppendLine("Root_Stat_Country_Count");
                sb.AppendLine("Root_Stat_Province_Count");
                sb.AppendLine("Root_Stat_Area_Count");
                sb.AppendLine("Root_Stat_Sector_Count");
                sb.AppendLine("Root_Stat_Subsector_Count");
                sb.AppendLine("Root_Stat_Municipality_Count");
                sb.AppendLine("Root_Stat_Lift_Station_Count");
                sb.AppendLine("Root_Stat_WWTP_Count");
                sb.AppendLine("Root_Stat_MWQM_Sample_Count");
                sb.AppendLine("Root_Stat_MWQM_Site_Count");
                sb.AppendLine("Root_Stat_MWQM_Run_Count");
                sb.AppendLine("Root_Stat_Pol_Source_Site_Count");
                sb.AppendLine("Root_Stat_Mike_Scenario_Count");
                sb.AppendLine("Root_Stat_Box_Model_Scenario_Count");
                sb.AppendLine("Root_Stat_Visual_Plumes_Scenario_Count");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelRoot.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportRootModel> ReportRootModelList = reportServiceRoot.GetReportRootModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportRootModelList.Count > 0);
                Assert.AreEqual("", ReportRootModelList[0].Root_Error);
                Assert.AreEqual(1, ReportRootModelList[0].Root_Counter);
                Assert.AreEqual(tvItemModelRoot.TVItemID, ReportRootModelList[0].Root_ID);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? "Tous les endroits" : "All locations"), ReportRootModelList[0].Root_Name);
                Assert.IsNotNull(ReportRootModelList[0].Root_Name_Translation_Status);
                Assert.IsNotNull(ReportRootModelList[0].Root_Last_Update_Date_And_Time_UTC);
                Assert.IsTrue(ReportRootModelList[0].Root_Last_Update_Contact_Name.Length > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Last_Update_Contact_Initial.Length > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Lat != 0.0f);
                Assert.IsTrue(ReportRootModelList[0].Root_Lng != 0.0f);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_Country_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_Province_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_Area_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_Sector_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_Subsector_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_Municipality_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_Lift_Station_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_WWTP_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_MWQM_Sample_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_MWQM_Site_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_MWQM_Run_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_Pol_Source_Site_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_Mike_Scenario_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_Box_Model_Scenario_Count > 0);
                Assert.IsTrue(ReportRootModelList[0].Root_Stat_Visual_Plumes_Scenario_Count > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportRootModelListUnderTVItemIDDB_Start_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Root " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Root_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportRootModel> ReportRootModelList = reportServiceRoot.GetReportRootModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportRootModelList[0].Root_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportRootModelListUnderTVItemIDDB_Start_TVType_Not_Root_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Root " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Root_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportRootModel> ReportRootModelList = reportServiceRoot.GetReportRootModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Root.ToString()), ReportRootModelList[0].Root_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportRootModelListUnderTVItemIDDB_Start_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Root " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Root_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelRoot.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Root";

                List<string> AllowableParentTagItemList = reportServiceRoot._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportRootModel> ReportRootModelList = reportServiceRoot.GetReportRootModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportRootModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportRootModelList[0].Root_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Root " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Root_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportRootModelList = reportServiceRoot.GetReportRootModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportRootModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportRootModelList[0].Root_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Root " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Root_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportRootModelList = reportServiceRoot.GetReportRootModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportRootModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportRootModelList[0].Root_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportRootModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);


                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    tvItemModelRoot };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Root " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Root_Error");
                    sb.AppendLine("Root_Counter");
                    sb.AppendLine("Root_ID");
                    sb.AppendLine("Root_Name_Translation_Status");
                    sb.AppendLine("Root_Name");
                    sb.AppendLine("Root_Is_Active");
                    sb.AppendLine("Root_Last_Update_Date_And_Time");
                    sb.AppendLine("Root_Last_Update_Contact_Name");
                    sb.AppendLine("Root_Last_Update_Contact_Initial");
                    sb.AppendLine("Root_Lat");
                    sb.AppendLine("Root_Lng");
                    sb.AppendLine("Root_Stat_Country_Count");
                    sb.AppendLine("Root_Stat_Province_Count");
                    sb.AppendLine("Root_Stat_Area_Count");
                    sb.AppendLine("Root_Stat_Sector_Count");
                    sb.AppendLine("Root_Stat_Subsector_Count");
                    sb.AppendLine("Root_Stat_Municipality_Count");
                    sb.AppendLine("Root_Stat_Lift_Station_Count");
                    sb.AppendLine("Root_Stat_WWTP_Count");
                    sb.AppendLine("Root_Stat_MWQM_Sample_Count");
                    sb.AppendLine("Root_Stat_MWQM_Site_Count");
                    sb.AppendLine("Root_Stat_MWQM_Run_Count");
                    sb.AppendLine("Root_Stat_Pol_Source_Site_Count");
                    sb.AppendLine("Root_Stat_Mike_Scenario_Count");
                    sb.AppendLine("Root_Stat_Box_Model_Scenario_Count");
                    sb.AppendLine("Root_Stat_Visual_Plumes_Scenario_Count");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportRootModel> ReportRootModelList = reportServiceRoot.GetReportRootModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportRootModelList.Count > 0);
                    Assert.AreEqual("", ReportRootModelList[0].Root_Error);
                    Assert.AreEqual(1, ReportRootModelList[0].Root_Counter);
                    Assert.IsTrue(ReportRootModelList[0].Root_ID > 0);
                    Assert.IsNotNull(ReportRootModelList[0].Root_Name);
                    Assert.IsNotNull(ReportRootModelList[0].Root_Name_Translation_Status);
                    Assert.IsNotNull(ReportRootModelList[0].Root_Last_Update_Date_And_Time_UTC);
                    Assert.IsTrue(ReportRootModelList[0].Root_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Last_Update_Contact_Initial.Length > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Lat != 0.0f);
                    Assert.IsTrue(ReportRootModelList[0].Root_Lng != 0.0f);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_Country_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_Province_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_Area_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_Sector_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_Subsector_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_Municipality_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_Lift_Station_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_WWTP_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_MWQM_Sample_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_MWQM_Site_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_MWQM_Run_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_Pol_Source_Site_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_Mike_Scenario_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_Box_Model_Scenario_Count > 0);
                    Assert.IsTrue(ReportRootModelList[0].Root_Stat_Visual_Plumes_Scenario_Count > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportRootModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    tvItemModelRoot };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Root " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Root_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportRootModel> ReportRootModelList = reportServiceRoot.GetReportRootModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportRootModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportRootModelList[0].Root_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportRootModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Root " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Root_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelRoot.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Root";

                List<string> AllowableParentTagItemList = reportServiceRoot._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportRootModel> ReportRootModelList = reportServiceRoot.GetReportRootModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportRootModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportRootModelList[0].Root_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Root " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Root_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportRootModelList = reportServiceRoot.GetReportRootModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportRootModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportRootModelList[0].Root_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Root " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Root_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportRootModelList = reportServiceRoot.GetReportRootModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportRootModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportRootModelList[0].Root_Error));
            }
        }
        #endregion Testing Methods Root
        #region Testing Methods Root_File
        [TestMethod]
        public void ReportService_GetReportRoot_FileModelListUnderTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Root_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Root_File_Error");
                    sb.AppendLine("Root_File_Counter");
                    sb.AppendLine("Root_File_ID");
                    sb.AppendLine("Root_File_Language");
                    sb.AppendLine("Root_File_File_Purpose");
                    sb.AppendLine("Root_File_File_Type");
                    sb.AppendLine("Root_File_File_Description");
                    sb.AppendLine("Root_File_File_Size_kb");
                    sb.AppendLine("Root_File_File_Info");
                    sb.AppendLine("Root_File_File_Created_Date_UTC");
                    sb.AppendLine("Root_File_From_Water");
                    sb.AppendLine("Root_File_Server_File_Name");
                    sb.AppendLine("Root_File_Server_File_Path");
                    sb.AppendLine("Root_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Root_File_Last_Update_Contact_Name");
                    sb.AppendLine("Root_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportRoot_FileModel> ReportRoot_FileModelList = reportServiceRoot_File.GetReportRoot_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportRoot_FileModelList.Count > 0);
                    Assert.IsTrue(ReportRoot_FileModelList[0].Root_File_Error == "");
                    Assert.IsTrue(ReportRoot_FileModelList[0].Root_File_Counter > 0);
                    Assert.IsTrue(ReportRoot_FileModelList[0].Root_File_ID > 0);
                    Assert.IsTrue((int)ReportRoot_FileModelList[0].Root_File_Language > 0);
                    Assert.IsTrue((int)ReportRoot_FileModelList[0].Root_File_File_Purpose > 0);
                    Assert.IsTrue((int)ReportRoot_FileModelList[0].Root_File_File_Type > 0);
                    Assert.IsTrue(ReportRoot_FileModelList[0].Root_File_File_Description.Length > 0);
                    Assert.IsTrue(ReportRoot_FileModelList[0].Root_File_File_Size_kb > 0);
                    Assert.IsTrue(ReportRoot_FileModelList[0].Root_File_File_Info.Length > 0);
                    Assert.IsNotNull(ReportRoot_FileModelList[0].Root_File_File_Created_Date_UTC);
                    //Assert.IsNotNull(ReportRoot_FileModelList[0].Root_File_From_Water);
                    Assert.IsTrue(ReportRoot_FileModelList[0].Root_File_Server_File_Name.Length > 0);
                    Assert.IsTrue(ReportRoot_FileModelList[0].Root_File_Server_File_Path.Length > 0);
                    Assert.IsTrue(ReportRoot_FileModelList[0].Root_File_Last_Update_Date_And_Time_UTC > new DateTime(1979, 1, 1));
                    Assert.IsTrue(ReportRoot_FileModelList[0].Root_File_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportRoot_FileModelList[0].Root_File_Last_Update_Contact_Initial.Length > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportRoot_FileModelListUnderTVItemIDDB_Good_CountOnly_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Root_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Root_File_Error");
                    sb.AppendLine("Root_File_Counter");
                    sb.AppendLine("Root_File_ID");
                    sb.AppendLine("Root_File_Language");
                    sb.AppendLine("Root_File_File_Purpose");
                    sb.AppendLine("Root_File_File_Type");
                    sb.AppendLine("Root_File_File_Description");
                    sb.AppendLine("Root_File_File_Size_kb");
                    sb.AppendLine("Root_File_File_Info");
                    sb.AppendLine("Root_File_File_Created_Date_UTC");
                    sb.AppendLine("Root_File_From_Water");
                    sb.AppendLine("Root_File_Server_File_Name");
                    sb.AppendLine("Root_File_Server_File_Path");
                    sb.AppendLine("Root_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Root_File_Last_Update_Contact_Name");
                    sb.AppendLine("Root_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = true;
                    int Take = 10;

                    List<ReportRoot_FileModel> ReportRoot_FileModelList = reportServiceRoot_File.GetReportRoot_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportRoot_FileModelList.Count == 1);
                    Assert.IsTrue(ReportRoot_FileModelList[0].Root_File_Counter > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportRoot_FileModelListUnderTVItemIDDB_Error_Start_Tag_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Root_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Root_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Root_File";

                    List<ReportRoot_FileModel> ReportRoot_FileModelList = reportServiceRoot_File.GetReportRoot_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportRoot_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportRoot_FileModelList[0].Root_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportRoot_FileModelListUnderTVItemIDDB_Error_TVItem_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Root_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Root_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportRoot_FileModel> ReportRoot_FileModelList = reportServiceRoot_File.GetReportRoot_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportRoot_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportRoot_FileModelList[0].Root_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportRoot_FileModelListUnderTVItemIDDB_Error_ParentTagItem_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Root_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Root_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportRoot_FileModel> ReportRoot_FileModelList = reportServiceRoot_File.GetReportRoot_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportRoot_FileModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.ParentTagItemShouldNotBeEmpty, ReportRoot_FileModelList[0].Root_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportRoot_FileModelListUnderTVItemIDDB_Error_Allowable_ParentTagItem_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Root_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Root_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "Municipality";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Root_File";

                    List<string> AllowableParentTagItemList = reportServiceRoot._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportRoot_FileModel> ReportRoot_FileModelList = reportServiceRoot_File.GetReportRoot_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportRoot_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportRoot_FileModelList[0].Root_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportRoot_FileModelListUnderTVItemIDDB_Error_GetReportTreeNodesFromTagText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Root_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Root_File_IDNot"); // line 2
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportRoot_FileModel> ReportRoot_FileModelList = reportServiceRoot_File.GetReportRoot_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportRoot_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ReportServiceRes._DoesNotExistFor_, "Root_File_IDNot", "CSSPModelsDLL.Models.ReportRoot_FileModel"), ReportRoot_FileModelList[0].Root_File_Error);
                }
            }
        }
        #endregion Testing Methods Root_File
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
            reportServiceRoot = new ReportServiceRoot((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceRoot_File = new ReportServiceRoot_File((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceRoot);
        }
        #endregion Functions private
    }
}

