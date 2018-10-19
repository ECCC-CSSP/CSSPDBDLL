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
    public class ReportServiceMWQM_RunTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceMWQM_Run reportServiceMWQM_Run { get; set; }
        private ReportServiceMWQM_Run_File reportServiceMWQM_Run_File { get; set; }
        private ReportServiceMWQM_Run_Lab_Sheet reportServiceMWQM_Run_Lab_Sheet { get; set; }
        private ReportServiceMWQM_Run_Lab_Sheet_Detail reportServiceMWQM_Run_Lab_Sheet_Detail { get; set; }
        private ReportServiceMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail reportServiceMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail { get; set; }
        private ReportServiceMWQM_Run_Sample reportServiceMWQM_Run_Sample { get; set; }
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
        public ReportServiceMWQM_RunTest()
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
        #region Testing Methods MWQM_Run
        [TestMethod]
        public void ReportService_GetReportMWQM_RunModelListUnderTVItemIDDB_Start_Good_Test()
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

                TVItemModel tvItemModelMWQM_Run = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQM_Run.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Run " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Error");
                sb.AppendLine("MWQM_Run_Counter");
                sb.AppendLine("MWQM_Run_ID");
                sb.AppendLine("MWQM_Run_Name");
                sb.AppendLine("MWQM_Run_Is_Active");
                sb.AppendLine("MWQM_Run_Name_Translation_Status");
                sb.AppendLine("MWQM_Run_Date_Time_Local");
                sb.AppendLine("MWQM_Run_Start_Date_Time_Local");
                sb.AppendLine("MWQM_Run_End_Date_Time_Local");
                sb.AppendLine("MWQM_Run_Lab_Received_Date_Time_Local");
                sb.AppendLine("MWQM_Run_Temperature_Control_1_C");
                sb.AppendLine("MWQM_Run_Temperature_Control_2_C");
                sb.AppendLine("MWQM_Run_Sea_State_At_Start_Beaufort_Scale");
                sb.AppendLine("MWQM_Run_Sea_State_At_End_Beaufort_Scale");
                sb.AppendLine("MWQM_Run_Water_Level_At_Brook_m");
                sb.AppendLine("MWQM_Run_Wave_Hight_At_Start_m");
                sb.AppendLine("MWQM_Run_Wave_Hight_At_End_m");
                sb.AppendLine("MWQM_Run_Sample_Crew_Initials");
                sb.AppendLine("MWQM_Run_Analyze_Method");
                sb.AppendLine("MWQM_Run_Sample_Matrix");
                sb.AppendLine("MWQM_Run_Laboratory");
                sb.AppendLine("MWQM_Run_Sample_Status");
                sb.AppendLine("MWQM_Run_Lab_Sample_Approval_Contact_Name");
                sb.AppendLine("MWQM_Run_Lab_Sample_Approval_Contact_Initial");
                sb.AppendLine("MWQM_Run_Lab_Analyze_Incubation_Start_Date_Time_Local");
                sb.AppendLine("MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local");
                sb.AppendLine("MWQM_Run_PPT_24_mm");
                sb.AppendLine("MWQM_Run_PPT_48_mm");
                sb.AppendLine("MWQM_Run_PPT_72_mm");
                sb.AppendLine("MWQM_Run_Comment_Translation_Status");
                sb.AppendLine("MWQM_Run_Comment");
                sb.AppendLine("MWQM_Run_Last_Update_Date_And_Time");
                sb.AppendLine("MWQM_Run_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Run_Last_Update_Contact_Initial");
                sb.AppendLine("MWQM_Run_Stat_MWQM_Site_Count");
                sb.AppendLine("MWQM_Run_Stat_Sample_Count");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMWQM_Run.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_RunModel> ReportMWQM_RunModelList = reportServiceMWQM_Run.GetReportMWQM_RunModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_RunModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_RunModelList[0].MWQM_Run_Error);
                Assert.AreEqual(1, ReportMWQM_RunModelList[0].MWQM_Run_Counter);
                Assert.AreEqual(tvItemModelMWQM_Run.TVItemID, ReportMWQM_RunModelList[0].MWQM_Run_ID);
                Assert.IsTrue(ReportMWQM_RunModelList[0].MWQM_Run_Name.Length > 0);
                Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Is_Active);
                Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Name_Translation_Status);
                Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Date_Time_Local);
                Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Start_Date_Time_Local);
                Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_End_Date_Time_Local);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Lab_Received_Date_Time_Local);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Temperature_Control_1_C);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Temperature_Control_2_C);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Sea_State_At_Start_Beaufort_Scale);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Sea_State_At_End_Beaufort_Scale);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Water_Level_At_Brook_m);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Wave_Hight_At_Start_m);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Wave_Hight_At_End_m);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Sample_Crew_Initials);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Analyze_Method);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Sample_Matrix);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Laboratory);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Sample_Status);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Lab_Sample_Approval_Contact_Name);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Lab_Sample_Approval_Contact_Initial);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Lab_Analyze_Incubation_Start_Date_Time_Local);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_PPT_24_mm);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_PPT_48_mm);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_PPT_72_mm);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Comment_Translation_Status);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Comment);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Last_Update_Date_And_Time);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Last_Update_Contact_Name);
                //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_RunModelListUnderTVItemIDDB_Start_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelMWQM_Run = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQM_Run.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Run " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_RunModel> ReportMWQM_RunModelList = reportServiceMWQM_Run.GetReportMWQM_RunModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMWQM_RunModelList[0].MWQM_Run_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_RunModelListUnderTVItemIDDB_Start_TVType_Not_MWQM_Run_Error_Test()
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

                TVItemModel tvItemModelMWQM_Run = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQM_Run.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Run " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_RunModel> ReportMWQM_RunModelList = reportServiceMWQM_Run.GetReportMWQM_RunModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMRun.ToString()), ReportMWQM_RunModelList[0].MWQM_Run_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_RunModelListUnderTVItemIDDB_Start_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelMWQM_Run = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQM_Run.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Run " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMWQM_Run.TVItemID;
                string ParentTagItem = tvItemModelMWQM_Run.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Run";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Run._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_RunModel> ReportMWQM_RunModelList = reportServiceMWQM_Run.GetReportMWQM_RunModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_RunModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_RunModelList[0].MWQM_Run_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Run " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_RunModelList = reportServiceMWQM_Run.GetReportMWQM_RunModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_RunModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_RunModelList[0].MWQM_Run_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Run " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_RunModelList = reportServiceMWQM_Run.GetReportMWQM_RunModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_RunModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMWQM_RunModelList[0].MWQM_Run_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_RunModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelMWQM_Run = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQM_Run.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                   tvItemModelSubsector, tvItemModelMWQM_Run };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Run " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Run_Error");
                    sb.AppendLine("MWQM_Run_Counter");
                    sb.AppendLine("MWQM_Run_ID");
                    sb.AppendLine("MWQM_Run_Name EQUAL 2012*08*07");
                    sb.AppendLine("MWQM_Run_Is_Active");
                    sb.AppendLine("MWQM_Run_Name_Translation_Status");
                    sb.AppendLine("MWQM_Run_Date_Time_Local");
                    sb.AppendLine("MWQM_Run_Start_Date_Time_Local");
                    sb.AppendLine("MWQM_Run_End_Date_Time_Local");
                    sb.AppendLine("MWQM_Run_Lab_Received_Date_Time_Local");
                    sb.AppendLine("MWQM_Run_Temperature_Control_1_C");
                    sb.AppendLine("MWQM_Run_Temperature_Control_2_C");
                    sb.AppendLine("MWQM_Run_Sea_State_At_Start_Beaufort_Scale");
                    sb.AppendLine("MWQM_Run_Sea_State_At_End_Beaufort_Scale");
                    sb.AppendLine("MWQM_Run_Water_Level_At_Brook_m");
                    sb.AppendLine("MWQM_Run_Wave_Hight_At_Start_m");
                    sb.AppendLine("MWQM_Run_Wave_Hight_At_End_m");
                    sb.AppendLine("MWQM_Run_Sample_Crew_Initials");
                    sb.AppendLine("MWQM_Run_Analyze_Method");
                    sb.AppendLine("MWQM_Run_Sample_Matrix");
                    sb.AppendLine("MWQM_Run_Laboratory");
                    sb.AppendLine("MWQM_Run_Sample_Status");
                    sb.AppendLine("MWQM_Run_Lab_Sample_Approval_Contact_Name");
                    sb.AppendLine("MWQM_Run_Lab_Sample_Approval_Contact_Initial");
                    sb.AppendLine("MWQM_Run_Lab_Analyze_Incubation_Start_Date_Time_Local");
                    sb.AppendLine("MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local");
                    sb.AppendLine("MWQM_Run_PPT_24_mm");
                    sb.AppendLine("MWQM_Run_PPT_48_mm");
                    sb.AppendLine("MWQM_Run_PPT_72_mm");
                    sb.AppendLine("MWQM_Run_Comment_Translation_Status");
                    sb.AppendLine("MWQM_Run_Comment");
                    sb.AppendLine("MWQM_Run_Last_Update_Date_And_Time");
                    sb.AppendLine("MWQM_Run_Last_Update_Contact_Name");
                    sb.AppendLine("MWQM_Run_Last_Update_Contact_Initial");
                    sb.AppendLine("MWQM_Run_Stat_MWQM_Site_Count");
                    sb.AppendLine("MWQM_Run_Stat_Sample_Count");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 1000;

                    List<ReportMWQM_RunModel> ReportMWQM_RunModelList = reportServiceMWQM_Run.GetReportMWQM_RunModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_RunModelList.Count > 0);
                    Assert.AreEqual("", ReportMWQM_RunModelList[0].MWQM_Run_Error);
                    Assert.AreEqual(1, ReportMWQM_RunModelList[0].MWQM_Run_Counter);
                    Assert.IsTrue(ReportMWQM_RunModelList[0].MWQM_Run_ID > 0);
                    Assert.IsTrue(ReportMWQM_RunModelList[0].MWQM_Run_Name.Length > 0);
                    Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Is_Active);
                    Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Name_Translation_Status);
                    Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Date_Time_Local);
                    Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Start_Date_Time_Local);
                    Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_End_Date_Time_Local);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Lab_Received_Date_Time_Local);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Temperature_Control_1_C);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Temperature_Control_2_C);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Sea_State_At_Start_Beaufort_Scale);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Sea_State_At_End_Beaufort_Scale);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Water_Level_At_Brook_m);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Wave_Hight_At_Start_m);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Wave_Hight_At_End_m);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Sample_Crew_Initials);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Analyze_Method);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Sample_Matrix);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Laboratory);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Sample_Status);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Lab_Sample_Approval_Contact_Name);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Lab_Sample_Approval_Contact_Initial);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Lab_Analyze_Incubation_Start_Date_Time_Local);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_PPT_24_mm);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_PPT_48_mm);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_PPT_72_mm);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Comment_Translation_Status);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Comment);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Last_Update_Date_And_Time);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Last_Update_Contact_Name);
                    //Assert.IsNotNull(ReportMWQM_RunModelList[0].MWQM_Run_Last_Update_Contact_Initial);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_RunModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelMWQM_Run = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQM_Run.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                   tvItemModelSubsector, tvItemModelMWQM_Run };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Run " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Run_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_RunModel> ReportMWQM_RunModelList = reportServiceMWQM_Run.GetReportMWQM_RunModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_RunModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMWQM_RunModelList[0].MWQM_Run_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_RunModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                TVItemModel tvItemModelMWQM_Run = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQM_Run.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Run";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Run._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_RunModel> ReportMWQM_RunModelList = reportServiceMWQM_Run.GetReportMWQM_RunModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_RunModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMWQM_RunModelList[0].MWQM_Run_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_RunModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelMWQM_Run = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQM_Run.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMWQM_Run.TVItemID;
                string ParentTagItem = tvItemModelMWQM_Run.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Run";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Run._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_RunModel> ReportMWQM_RunModelList = reportServiceMWQM_Run.GetReportMWQM_RunModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_RunModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_RunModelList[0].MWQM_Run_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_RunModelList = reportServiceMWQM_Run.GetReportMWQM_RunModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_RunModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_RunModelList[0].MWQM_Run_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_RunModelList = reportServiceMWQM_Run.GetReportMWQM_RunModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_RunModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMWQM_RunModelList[0].MWQM_Run_Error));
            }
        }
        #endregion Testing Methods MWQM_Run
        #region Testing Methods MWQM_Run_File
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_FileModelListUnderTVItemIDDB_Good_Test()
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

                TVItemModel tvItemModelMWQMRun = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQMRun.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMRun };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Run_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Run_File_Error");
                    sb.AppendLine("MWQM_Run_File_Counter");
                    sb.AppendLine("MWQM_Run_File_ID");
                    sb.AppendLine("MWQM_Run_File_Language");
                    sb.AppendLine("MWQM_Run_File_File_Purpose");
                    sb.AppendLine("MWQM_Run_File_File_Type");
                    sb.AppendLine("MWQM_Run_File_File_Description");
                    sb.AppendLine("MWQM_Run_File_File_Size_kb");
                    sb.AppendLine("MWQM_Run_File_File_Info");
                    sb.AppendLine("MWQM_Run_File_File_Created_Date_UTC");
                    sb.AppendLine("MWQM_Run_File_From_Water");
                    sb.AppendLine("MWQM_Run_File_Server_File_Name");
                    sb.AppendLine("MWQM_Run_File_Server_File_Path");
                    sb.AppendLine("MWQM_Run_File_Last_Update_Date_And_Time");
                    sb.AppendLine("MWQM_Run_File_Last_Update_Contact_Name");
                    sb.AppendLine("MWQM_Run_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MWQMRun" ? "MWQM_Run" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_Run_FileModel> ReportMWQM_Run_FileModelList = reportServiceMWQM_Run_File.GetReportMWQM_Run_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList.Count > 0);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Error == "");
                    Assert.IsTrue(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Counter > 0);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_ID > 0);
                    Assert.IsTrue((int)ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Language > 0);
                    Assert.IsTrue((int)ReportMWQM_Run_FileModelList[0].MWQM_Run_File_File_Purpose > 0);
                    Assert.IsTrue((int)ReportMWQM_Run_FileModelList[0].MWQM_Run_File_File_Type > 0);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_File_Description.Length > 0);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_File_Size_kb > 0);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_File_Info.Length > 0);
                    Assert.IsNotNull(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_File_Created_Date_UTC);
                    //Assert.IsNotNull(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_From_Water);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Server_File_Name.Length > 0);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Server_File_Path.Length > 0);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Last_Update_Date_And_Time_UTC > new DateTime(1979, 1, 1));
                    Assert.IsTrue(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Last_Update_Contact_Initial.Length > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_FileModelListUnderTVItemIDDB_Good_CountOnly_Test()
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

                TVItemModel tvItemModelMWQMRun = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQMRun.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMRun };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Run_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Run_File_Error");
                    sb.AppendLine("MWQM_Run_File_Counter");
                    sb.AppendLine("MWQM_Run_File_ID");
                    sb.AppendLine("MWQM_Run_File_Language");
                    sb.AppendLine("MWQM_Run_File_File_Purpose");
                    sb.AppendLine("MWQM_Run_File_File_Type");
                    sb.AppendLine("MWQM_Run_File_File_Description");
                    sb.AppendLine("MWQM_Run_File_File_Size_kb");
                    sb.AppendLine("MWQM_Run_File_File_Info");
                    sb.AppendLine("MWQM_Run_File_File_Created_Date_UTC");
                    sb.AppendLine("MWQM_Run_File_From_Water");
                    sb.AppendLine("MWQM_Run_File_Server_File_Name");
                    sb.AppendLine("MWQM_Run_File_Server_File_Path");
                    sb.AppendLine("MWQM_Run_File_Last_Update_Date_And_Time");
                    sb.AppendLine("MWQM_Run_File_Last_Update_Contact_Name");
                    sb.AppendLine("MWQM_Run_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MWQMRun" ? "MWQM_Run" : tvItemModel.TVType.ToString());
                    bool CountOnly = true;
                    int Take = 10;

                    List<ReportMWQM_Run_FileModel> ReportMWQM_Run_FileModelList = reportServiceMWQM_Run_File.GetReportMWQM_Run_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList.Count == 1);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Counter > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_FileModelListUnderTVItemIDDB_Error_Start_Tag_Test()
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

                TVItemModel tvItemModelMWQMRun = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQMRun.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMRun };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start MWQM_Run_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Run_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MWQMRun" ? "MWQM_Run" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "MWQM_Run_File";

                    List<ReportMWQM_Run_FileModel> ReportMWQM_Run_FileModelList = reportServiceMWQM_Run_File.GetReportMWQM_Run_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_FileModelListUnderTVItemIDDB_Error_TVItem_Test()
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

                TVItemModel tvItemModelMWQMRun = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQMRun.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMRun };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Run_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Run_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MWQMRun" ? "MWQM_Run" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_Run_FileModel> ReportMWQM_Run_FileModelList = reportServiceMWQM_Run_File.GetReportMWQM_Run_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_FileModelListUnderTVItemIDDB_Error_ParentTagItem_Empty_Test()
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

                TVItemModel tvItemModelMWQMRun = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQMRun.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMRun };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Run_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Run_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_Run_FileModel> ReportMWQM_Run_FileModelList = reportServiceMWQM_Run_File.GetReportMWQM_Run_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.ParentTagItemShouldNotBeEmpty, ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_FileModelListUnderTVItemIDDB_Error_Allowable_ParentTagItem_Test()
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

                TVItemModel tvItemModelMWQMRun = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQMRun.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMRun };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Run_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Run_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "Municipality";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "MWQM_Run_File";

                    List<string> AllowableParentTagItemList = reportServiceMWQM_Run._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportMWQM_Run_FileModel> ReportMWQM_Run_FileModelList = reportServiceMWQM_Run_File.GetReportMWQM_Run_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_FileModelListUnderTVItemIDDB_Error_GetReportTreeNodesFromTagText_Test()
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

                TVItemModel tvItemModelMWQMRun = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID, "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQMRun.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMWQMRun };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Run_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Run_File_IDNot"); // line 2
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MWQMRun" ? "MWQM_Run" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_Run_FileModel> ReportMWQM_Run_FileModelList = reportServiceMWQM_Run_File.GetReportMWQM_Run_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Run_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ReportServiceRes._DoesNotExistFor_, "MWQM_Run_File_IDNot", "CSSPModelsDLL.Models.ReportMWQM_Run_FileModel"), ReportMWQM_Run_FileModelList[0].MWQM_Run_File_Error);
                }
            }
        }
        #endregion Testing Methods MWQM_Run_File
        #region Testing Methods MWQM_Run_Lab_Sheet_Detail
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_Sheet_DetailModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Run_Lab_Sheet_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_ID");
                sb.AppendLine("|||");

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMRunTVItemID > 0);

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheet.LabSheetID;
                string ParentTagItem = "MWQM_Run_Lab_Sheet";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Run_Lab_Sheet_Detail";

                List<ReportMWQM_Run_Lab_Sheet_DetailModel> ReportMWQM_Run_Lab_Sheet_DetailModelList = reportServiceMWQM_Run_Lab_Sheet_Detail.GetReportMWQM_Run_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_Sheet_DetailModelListUnderTVItemIDDB_Loop_Good_Test()
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
                sb.AppendLine("|||Loop MWQM_Run_Lab_Sheet_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Error");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Counter");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_ID");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Version");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Run_Date");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Tides");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Sample_Crew_Initials");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Incubation_Start_Time");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Incubation_End_Time");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Incubation_Time_Calculated_minutes");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Water_Bath");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_TC_Field_1");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_TC_Lab_1");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_TC_Field_2");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_TC_Lab_2");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_TC_First");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_TC_Average");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Control_Lot");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Positive_35");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Non_Target_35");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Negative_35");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Positive_44_5");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Non_Target_44_5");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Negative_44_5");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Blank_35");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Lot_35");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Lot_44_5");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Weather");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Run_Comment");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Sample_Bottle_Lot_Number");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Salinities_Read_By");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Salinities_Read_Date");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Results_Read_By");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Results_Read_Date");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Results_Recorded_By");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Results_Recorded_Date");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Daily_Duplicate_R_Log");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Daily_Duplicate_Acceptable");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Intertech_Duplicate_R_Log");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Intertech_Read_Acceptable");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Last_Update_Date_UTC");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.LabSheetID;
                string ParentTagItem = "MWQM_Run_Lab_Sheet";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Run_Lab_Sheet_DetailModel> ReportMWQM_Run_Lab_Sheet_DetailModelList = reportServiceMWQM_Run_Lab_Sheet_Detail.GetReportMWQM_Run_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Error);
                Assert.AreEqual(1, ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Counter);
                Assert.IsTrue(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_ID > 0);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Version);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Run_Date);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Tides);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Sample_Crew_Initials);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Incubation_Start_Time);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Incubation_End_Time);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Incubation_Time_Calculated_minutes);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Water_Bath);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_TC_Field_1);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_TC_Lab_1);
                //Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_TC_Field_2);
                //Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_TC_Lab_2);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_TC_First);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_TC_Average);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Control_Lot);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Positive_35);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Non_Target_35);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Negative_35);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Positive_44_5);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Non_Target_44_5);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Negative_44_5);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Blank_35);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Lot_35);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Lot_44_5);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Weather);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Run_Comment);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Sample_Bottle_Lot_Number);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Salinities_Read_By);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Salinities_Read_Date);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Results_Read_By);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Results_Read_Date);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Results_Recorded_By);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Results_Recorded_Date);
                //Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Daily_Duplicate_R_Log);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Daily_Duplicate_Acceptable);
                //Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Intertech_Duplicate_R_Log);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Intertech_Read_Acceptable);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_Sheet_DetailModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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
                sb.AppendLine("|||Loop MWQM_Run_Lab_Sheet_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "MWQM_Run_Lab_Sheet";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Run_Lab_Sheet_DetailModel> ReportMWQM_Run_Lab_Sheet_DetailModelList = reportServiceMWQM_Run_Lab_Sheet_Detail.GetReportMWQM_Run_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheet, ServiceRes.LabSheetID, UnderTVItemID.ToString()), ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_Sheet_DetailModelListUnderTVItemIDDB_Loop_ParentTagItem_Error_Test()
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
                sb.AppendLine("|||Loop MWQM_Run_Lab_Sheet_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_Detail_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheet.LabSheetID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Run_Lab_Sheet_DetailModel> ReportMWQM_Run_Lab_Sheet_DetailModelList = reportServiceMWQM_Run_Lab_Sheet_Detail.GetReportMWQM_Run_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "MWQM_Run_Lab_Sheet", ParentTagItem), ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Error);

                ParentTagItem = "Municipality";

                ReportMWQM_Run_Lab_Sheet_DetailModelList = reportServiceMWQM_Run_Lab_Sheet_Detail.GetReportMWQM_Run_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "MWQM_Run_Lab_Sheet", ParentTagItem), ReportMWQM_Run_Lab_Sheet_DetailModelList[0].MWQM_Run_Lab_Sheet_Detail_Error);
            }
        }
        #endregion Testing Methods MWQM_Run_Lab_Sheet_Detail
        #region Testing Methods MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID");
                sb.AppendLine("|||");

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMRunTVItemID > 0);

                LabSheetDetail labSheetDetail = (from c in labSheetService.db.LabSheetDetails
                                                 where c.LabSheetID == labSheet.LabSheetID
                                                 select c).FirstOrDefault();
                Assert.IsNotNull(labSheetDetail);
                Assert.IsTrue(labSheetDetail.LabSheetDetailID > 0);

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheetDetail.LabSheetDetailID;
                string ParentTagItem = "MWQM_Run_Lab_Sheet_Detail";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail";

                List<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail.GetReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMRunTVItemID > 0);

                LabSheetDetail labSheetDetail = (from c in labSheetService.db.LabSheetDetails
                                                 where c.LabSheetID == labSheet.LabSheetID
                                                 select c).FirstOrDefault();
                Assert.IsNotNull(labSheetDetail);
                Assert.IsTrue(labSheetDetail.LabSheetDetailID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Counter");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Ordinal");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MPN");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_10");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Salinity");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Temperature");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheetDetail.LabSheetDetailID;
                string ParentTagItem = "MWQM_Run_Lab_Sheet_Detail";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail.GetReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error);
                Assert.AreEqual(1, ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Counter);
                Assert.IsTrue(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID > 0);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Ordinal);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_MPN);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_10);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Salinity);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Temperature);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Processed_By);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type);
                //Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMRunTVItemID > 0);

                LabSheetDetail labSheetDetail = (from c in labSheetService.db.LabSheetDetails
                                                 where c.LabSheetID == labSheet.LabSheetID
                                                 select c).FirstOrDefault();
                Assert.IsNotNull(labSheetDetail);
                Assert.IsTrue(labSheetDetail.LabSheetDetailID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "MWQM_Run_Lab_Sheet_Detail";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail.GetReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheetTubeMPNDetail, ServiceRes.LabSheetDetailID, UnderTVItemID.ToString()), ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB_Loop_ParentTagItem_Error_Test()
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

                LabSheetDetail labSheetDetail = (from c in labSheetService.db.LabSheetDetails
                                                 where c.LabSheetID == labSheet.LabSheetID
                                                 select c).FirstOrDefault();
                Assert.IsNotNull(labSheetDetail);
                Assert.IsTrue(labSheetDetail.LabSheetDetailID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheetDetail.LabSheetDetailID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModel> ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail.GetReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "MWQM_Run_Lab_Sheet_Detail", ParentTagItem), ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error);

                ParentTagItem = "Municipality";

                ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail.GetReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "MWQM_Run_Lab_Sheet_Detail", ParentTagItem), ReportMWQM_Run_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail_Error);
            }
        }
        #endregion Testing Methods MWQM_Run_Lab_Sheet_Tube_And_MPN_Detail
        #region Testing Methods MWQM_Run_Lab_Sheet
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Run_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_ID");
                sb.AppendLine("|||");

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMRunTVItemID > 0);

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.MWQMRunTVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Run_Lab_Sheet";

                List<ReportMWQM_Run_Lab_SheetModel> ReportMWQM_Run_Lab_SheetModelList = reportServiceMWQM_Run_Lab_Sheet.GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_SheetModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB_Loop_Good_Test()
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
                sb.AppendLine("|||Loop MWQM_Run_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_Error");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Counter");
                sb.AppendLine("MWQM_Run_Lab_Sheet_ID");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Config_File_Name");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Province");
                sb.AppendLine("MWQM_Run_Lab_Sheet_For_Group_Name");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Year");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Month");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Day");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Secret_Code");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Subsector_Name_Short");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Subsector_Name_Long");
                sb.AppendLine("MWQM_Run_Lab_Sheet_MWQM_Run_Name");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Config_Type");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Sample_Type");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Type");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Status");
                sb.AppendLine("MWQM_Run_Lab_Sheet_File_Name");
                sb.AppendLine("MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local");
                sb.AppendLine("MWQM_Run_Lab_Sheet_File_Content");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Approved_Or_Rejected_By_Contact_Name");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Approved_Or_Rejected_By_Contact_Initial");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Approved_Or_Rejected_Date_Time");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Last_Update_Date_UTC");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.MWQMRunTVItemID;
                string ParentTagItem = "MWQM_Run";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Run_Lab_SheetModel> ReportMWQM_Run_Lab_SheetModelList = reportServiceMWQM_Run_Lab_Sheet.GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_SheetModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Error);
                Assert.AreEqual(1, ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Counter);
                Assert.IsTrue(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_ID > 0);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Other_Server_Lab_Sheet_ID);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Config_File_Name);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Province);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_For_Group_Name);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Year);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Month);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Day);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Secret_Code);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Daily_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Intertech_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Subsector_Name_Short);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Subsector_Name_Long);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_MWQM_Run_Name);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Config_Type);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Sample_Type);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Type);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Status);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_File_Name);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_File_Last_Modified_Date_Local);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_File_Content);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Approved_Or_Rejected_By_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Approved_Or_Rejected_By_Contact_Initial);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Approved_Or_Rejected_Date_Time);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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
                sb.AppendLine("|||Loop MWQM_Run_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "MWQM_Run";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Run_Lab_SheetModel> ReportMWQM_Run_Lab_SheetModelList = reportServiceMWQM_Run_Lab_Sheet.GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_SheetModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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
                sb.AppendLine("|||Loop MWQM_Run_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Run_Lab_Sheet";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Run._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_Run_Lab_SheetModel> ReportMWQM_Run_Lab_SheetModelList = reportServiceMWQM_Run_Lab_Sheet.GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_SheetModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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
                sb.AppendLine("|||Loop MWQM_Run_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.MWQMRunTVItemID;
                string ParentTagItem = "MWQM_Run";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Run_Lab_Sheet";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Run._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_Run_Lab_SheetModel> ReportMWQM_Run_Lab_SheetModelList = reportServiceMWQM_Run_Lab_Sheet.GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_SheetModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_Run_Lab_SheetModelList = reportServiceMWQM_Run_Lab_Sheet.GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_SheetModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Lab_Sheet_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_Run_Lab_SheetModelList = reportServiceMWQM_Run_Lab_Sheet.GetReportMWQM_Run_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_Lab_SheetModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMWQM_Run_Lab_SheetModelList[0].MWQM_Run_Lab_Sheet_Error));
            }
        }
        #endregion Testing Methods MWQM_Run_Lab_Sheet
        #region Testing Methods MWQM_Run_Sample
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_SampleModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Run_Sample " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Sample_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 13283;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Run_Sample";

                List<ReportMWQM_Run_SampleModel> ReportMWQM_Run_SampleModelList = reportServiceMWQM_Run_Sample.GetReportMWQM_Run_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_SampleModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_SampleModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelMWQM_Run = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "2010 06 16", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQM_Run.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run_Sample " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Sample_Error");
                sb.AppendLine("MWQM_Run_Sample_Counter");
                sb.AppendLine("MWQM_Run_Sample_ID");
                sb.AppendLine("MWQM_Run_Sample_Date_Time_Local");
                sb.AppendLine("MWQM_Run_Sample_Depth_m");
                sb.AppendLine("MWQM_Run_Sample_Fec_Col_MPN_100_ml");
                sb.AppendLine("MWQM_Run_Sample_Salinity_PPT");
                sb.AppendLine("MWQM_Run_Sample_Water_Temp_C");
                sb.AppendLine("MWQM_Run_Sample_PH");
                sb.AppendLine("MWQM_Run_Sample_Types");
                sb.AppendLine("MWQM_Run_Sample_Tube_10");
                sb.AppendLine("MWQM_Run_Sample_Tube_1_0");
                sb.AppendLine("MWQM_Run_Sample_Tube_0_1");
                sb.AppendLine("MWQM_Run_Sample_Processed_By");
                sb.AppendLine("MWQM_Run_Sample_Note_Translation_Status");
                sb.AppendLine("MWQM_Run_Sample_Note");
                sb.AppendLine("MWQM_Run_Sample_Last_Update_Date_And_Time_UTC");
                sb.AppendLine("MWQM_Run_Sample_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Run_Sample_Last_Update_Contact_Initial");
                sb.AppendLine("MWQM_Run_Sample_PPT_24_mm");
                sb.AppendLine("MWQM_Run_Sample_PPT_48_mm");
                sb.AppendLine("MWQM_Run_Sample_PPT_72_mm");
                sb.AppendLine("MWQM_Run_Sample_Tide_Start");
                sb.AppendLine("MWQM_Run_Sample_Tide_End");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMWQM_Run.TVItemID;
                string ParentTagItem = tvItemModelMWQM_Run.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Run_SampleModel> ReportMWQM_Run_SampleModelList = reportServiceMWQM_Run_Sample.GetReportMWQM_Run_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_SampleModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Error);
                Assert.AreEqual(1, ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Counter);
                Assert.IsTrue(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_ID > 0);
                Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Date_Time_Local);
                //Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Depth_m);
                Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Fec_Col_MPN_100_ml);
                Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Salinity_PPT);
                Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Water_Temp_C);
                //Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_PH);
                Assert.IsTrue(!string.IsNullOrWhiteSpace(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Types));
                //Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Tube_10);
                //Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Tube_1_0);
                //Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Tube_0_1);
                //Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Processed_By);
                //Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Note_Translation_Status);
                //Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Note);
                Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Last_Update_Contact_Initial);
                Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_PPT_24_mm);
                Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_PPT_48_mm);
                Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_PPT_72_mm);
                Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Tide_Start);
                Assert.IsNotNull(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Tide_End);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_SampleModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelMWQM_Run = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQM_Run.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                   tvItemModelSubsector, tvItemModelMWQM_Run };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop MWQM_Run_Sample " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("MWQM_Run_Sample_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMWQM_Run_SampleModel> ReportMWQM_Run_SampleModelList = reportServiceMWQM_Run_Sample.GetReportMWQM_Run_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMWQM_Run_SampleModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_SampleModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                TVItemModel tvItemModelMWQM_Run = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                   "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQM_Run.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run_Sample " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Sample_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Run_Sample";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Run._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_Run_SampleModel> ReportMWQM_Run_SampleModelList = reportServiceMWQM_Run_Sample.GetReportMWQM_Run_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_SampleModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Run_SampleModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelMWQM_Run = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelSubsector.TVItemID,
                    "2012 08 07", TVTypeEnum.MWQMRun);
                Assert.AreEqual("", tvItemModelMWQM_Run.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run_Sample " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Sample_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMWQM_Run.TVItemID;
                string ParentTagItem = tvItemModelMWQM_Run.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Run_Sample";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Run._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_Run_SampleModel> ReportMWQM_Run_SampleModelList = reportServiceMWQM_Run_Sample.GetReportMWQM_Run_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_SampleModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run_Sample " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Sample_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_Run_SampleModelList = reportServiceMWQM_Run_Sample.GetReportMWQM_Run_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_SampleModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Run_Sample " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Run_Sample_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_Run_SampleModelList = reportServiceMWQM_Run_Sample.GetReportMWQM_Run_SampleModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Run_SampleModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMWQM_Run_SampleModelList[0].MWQM_Run_Sample_Error));
            }
        }
        #endregion Testing Methods MWQM_Run_Sample
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
            reportServiceMWQM_Run = new ReportServiceMWQM_Run((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Run_File = new ReportServiceMWQM_Run_File((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Run_Lab_Sheet = new ReportServiceMWQM_Run_Lab_Sheet((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Run_Lab_Sheet_Detail = new ReportServiceMWQM_Run_Lab_Sheet_Detail((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail = new ReportServiceMWQM_Run_Lab_Sheet_Tube_And_MPN_Detail((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Run_Sample = new ReportServiceMWQM_Run_Sample((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceMWQM_Run);
        }
        #endregion Functions private
    }
}

