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
    public class ReportServiceMWQM_PlanTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceMWQM_Plan reportServiceMWQM_Plan { get; set; }
        private ReportServiceMWQM_Plan_Lab_Sheet reportServiceMWQM_Plan_Lab_Sheet { get; set; }
        private ReportServiceMWQM_Plan_Lab_Sheet_Detail reportServiceMWQM_Plan_Lab_Sheet_Detail { get; set; }
        private ReportServiceMWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail reportServiceMWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail { get; set; }
        private ReportServiceMWQM_Plan_Subsector reportServiceMWQM_Plan_Subsector { get; set; }
        private ReportServiceMWQM_Plan_Subsector_Site reportServiceMWQM_Plan_Subsector_Site { get; set; }
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
        public ReportServiceMWQM_PlanTest()
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
        #region Testing Methods MWQM_Plan
        [TestMethod]
        public void ReportService_GetReportMWQM_PlanModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Plan " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 7;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Plan";

                List<ReportMWQM_PlanModel> ReportMWQM_PlanModelList = reportServiceMWQM_Plan.GetReportMWQM_PlanModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_PlanModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_PlanModelList[0].MWQM_Plan_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_PlanModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick"), TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelProvince.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Error");
                sb.AppendLine("MWQM_Plan_Counter");
                sb.AppendLine("MWQM_Plan_ID");
                sb.AppendLine("MWQM_Plan_Config_File_Name");
                sb.AppendLine("MWQM_Plan_For_Group_Name");
                sb.AppendLine("MWQM_Plan_Sample_Type");
                sb.AppendLine("MWQM_Plan_Config_Type");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Type");
                sb.AppendLine("MWQM_Plan_Province");
                sb.AppendLine("MWQM_Plan_Creator_Name");
                sb.AppendLine("MWQM_Plan_Creator_Initial");
                sb.AppendLine("MWQM_Plan_Year");
                sb.AppendLine("MWQM_Plan_Secret_Code");
                sb.AppendLine("MWQM_Plan_Daily_Duplicate_Precision_Criteria");
                sb.AppendLine("MWQM_Plan_Intertech_Duplicate_Precision_Criteria");
                sb.AppendLine("MWQM_Plan_Config_File_Txt");
                sb.AppendLine("MWQM_Plan_Last_Update_Date_UTC");
                sb.AppendLine("MWQM_Plan_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Plan_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_PlanModel> ReportMWQM_PlanModelList = reportServiceMWQM_Plan.GetReportMWQM_PlanModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_PlanModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_PlanModelList[0].MWQM_Plan_Error);
                Assert.AreEqual(1, ReportMWQM_PlanModelList[0].MWQM_Plan_Counter);
                Assert.IsTrue(ReportMWQM_PlanModelList[0].MWQM_Plan_ID > 0);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Config_File_Name);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_For_Group_Name);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Sample_Type);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Config_Type);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Lab_Sheet_Type);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Province);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Creator_Name);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Creator_Initial);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Year);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Secret_Code);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Daily_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Intertech_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Config_File_Txt);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMWQM_PlanModelList[0].MWQM_Plan_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_PlanModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick"), TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelProvince.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_PlanModel> ReportMWQM_PlanModelList = reportServiceMWQM_Plan.GetReportMWQM_PlanModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_PlanModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMWQM_PlanModelList[0].MWQM_Plan_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_PlanModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick"), TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelProvince.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Plan";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Plan._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_PlanModel> ReportMWQM_PlanModelList = reportServiceMWQM_Plan.GetReportMWQM_PlanModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_PlanModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMWQM_PlanModelList[0].MWQM_Plan_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_PlanModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelCountry = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
                Assert.AreEqual("", tvItemModelCountry.Error);

                TVItemModel tvItemModelProvince = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick"), TVTypeEnum.Province);
                Assert.AreEqual("", tvItemModelProvince.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_ID Not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Plan";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Plan._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_PlanModel> ReportMWQM_PlanModelList = reportServiceMWQM_Plan.GetReportMWQM_PlanModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_PlanModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_PlanModelList[0].MWQM_Plan_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_PlanModelList = reportServiceMWQM_Plan.GetReportMWQM_PlanModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_PlanModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_PlanModelList[0].MWQM_Plan_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_PlanModelList = reportServiceMWQM_Plan.GetReportMWQM_PlanModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_PlanModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMWQM_PlanModelList[0].MWQM_Plan_Error));
            }
        }
        #endregion Testing Methods MWQM_Plan
        #region Testing Methods MWQM_Plan_Lab_Sheet
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_SheetModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Plan_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_ID");
                sb.AppendLine("|||");

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.MWQMPlanID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Plan_Lab_Sheet";

                List<ReportMWQM_Plan_Lab_SheetModel> ReportMWQM_Plan_Lab_SheetModelList = reportServiceMWQM_Plan_Lab_Sheet.GetReportMWQM_Plan_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_SheetModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_SheetModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Error");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Counter");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_ID");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Config_File_Name");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Province");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_For_Group_Name");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Year");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Month");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Day");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Secret_Code");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Subsector_Name_Short");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Subsector_Name_Long");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_MWQM_Plan_Name");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Config_Type");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Sample_Type");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Lab_Sheet_Type");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Status");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_File_Name");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_File_Last_Modified_Date_Local");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_File_Content");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Approved_Or_Rejected_By_Contact_Name");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Approved_Or_Rejected_By_Contact_Initial");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Approved_Or_Rejected_Date_Time");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Last_Update_Date_UTC");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.MWQMPlanID;
                string ParentTagItem = "MWQM_Plan";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_Lab_SheetModel> ReportMWQM_Plan_Lab_SheetModelList = reportServiceMWQM_Plan_Lab_Sheet.GetReportMWQM_Plan_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_SheetModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Error);
                Assert.AreEqual(1, ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Counter);
                Assert.IsTrue(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_ID > 0);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Other_Server_Lab_Sheet_ID);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Config_File_Name);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Province);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_For_Group_Name);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Year);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Month);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Day);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Secret_Code);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Daily_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Intertech_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Subsector_Name_Short);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Subsector_Name_Long);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_MWQM_Plan_Name);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Config_Type);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Sample_Type);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Lab_Sheet_Type);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Status);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_File_Name);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_File_Last_Modified_Date_Local);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_File_Content);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Approved_Or_Rejected_By_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Approved_Or_Rejected_By_Contact_Initial);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Approved_Or_Rejected_Date_Time);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_SheetModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "MWQM_Plan";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_Lab_SheetModel> ReportMWQM_Plan_Lab_SheetModelList = reportServiceMWQM_Plan_Lab_Sheet.GetReportMWQM_Plan_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_SheetModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMPlan, ServiceRes.MWQMPlanID, UnderTVItemID.ToString()), ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_SheetModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.MWQMPlanID;
                string ParentTagItem = "Municipality";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_Lab_SheetModel> ReportMWQM_Plan_Lab_SheetModelList = reportServiceMWQM_Plan_Lab_Sheet.GetReportMWQM_Plan_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_SheetModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMPlan.ToString()), ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_SheetModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.MWQMPlanID;
                string ParentTagItem = "MWQM_Plan";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Plan_Lab_Sheet";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Plan._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_Plan_Lab_SheetModel> ReportMWQM_Plan_Lab_SheetModelList = reportServiceMWQM_Plan_Lab_Sheet.GetReportMWQM_Plan_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_SheetModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_Plan_Lab_SheetModelList = reportServiceMWQM_Plan_Lab_Sheet.GetReportMWQM_Plan_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_SheetModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Lab_Sheet " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_Plan_Lab_SheetModelList = reportServiceMWQM_Plan_Lab_Sheet.GetReportMWQM_Plan_Lab_SheetModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_SheetModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMWQM_Plan_Lab_SheetModelList[0].MWQM_Plan_Lab_Sheet_Error));
            }
        }
        #endregion Testing Methods MWQM_Plan_Lab_Sheet
        #region Testing Methods MWQM_Plan_Lab_Sheet_Detail
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_Sheet_DetailModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Plan_Lab_Sheet_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_ID");
                sb.AppendLine("|||");

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheet.LabSheetID;
                string ParentTagItem = "MWQM_Plan_Lab_Sheet";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Plan_Lab_Sheet_Detail";

                List<ReportMWQM_Plan_Lab_Sheet_DetailModel> ReportMWQM_Plan_Lab_Sheet_DetailModelList = reportServiceMWQM_Plan_Lab_Sheet_Detail.GetReportMWQM_Plan_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_Sheet_DetailModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Lab_Sheet_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Error");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Counter");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_ID");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Version");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Run_Date");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Tides");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Sample_Crew_Initials");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Incubation_Start_Time");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Incubation_End_Time");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Incubation_Time_Calculated_minutes");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Water_Bath");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_TC_Field_1");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_TC_Lab_1");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_TC_Field_2");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_TC_Lab_2");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_TC_First");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_TC_Average");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Control_Lot");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Positive_35");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Non_Target_35");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Negative_35");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Positive_44_5");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Non_Target_44_5");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Negative_44_5");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Blank_35");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Lot_35");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Lot_44_5");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Weather");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Run_Comment");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Salinities_Read_By");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Salinities_Read_Date");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Results_Read_By");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Results_Read_Date");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Results_Recorded_By");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Results_Recorded_Date");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Daily_Duplicate_R_Log");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Daily_Duplicate_Acceptable");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Intertech_Duplicate_R_Log");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Intertech_Read_Acceptable");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.LabSheetID;
                string ParentTagItem = "MWQM_Plan_Lab_Sheet";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_Lab_Sheet_DetailModel> ReportMWQM_Plan_Lab_Sheet_DetailModelList = reportServiceMWQM_Plan_Lab_Sheet_Detail.GetReportMWQM_Plan_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Error);
                Assert.AreEqual(1, ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Counter);
                Assert.IsTrue(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_ID > 0);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Version);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Run_Date);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Tides);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Sample_Crew_Initials);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Incubation_Start_Time);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Incubation_End_Time);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Incubation_Time_Calculated_minutes);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Water_Bath);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_TC_Field_1);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_TC_Lab_1);
                //Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_TC_Field_2);
                //Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_TC_Lab_2);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_TC_First);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_TC_Average);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Control_Lot);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Positive_35);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Non_Target_35);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Negative_35);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Positive_44_5);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Non_Target_44_5);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Negative_44_5);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Blank_35);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Lot_35);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Lot_44_5);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Weather);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Run_Comment);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Salinities_Read_By);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Salinities_Read_Date);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Results_Read_By);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Results_Read_Date);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Results_Recorded_By);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Results_Recorded_Date);
                //Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Daily_Duplicate_R_Log);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Daily_Duplicate_Acceptable);
                //Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Intertech_Duplicate_R_Log);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Intertech_Read_Acceptable);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_Sheet_DetailModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Lab_Sheet_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "MWQM_Plan_Lab_Sheet";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_Lab_Sheet_DetailModel> ReportMWQM_Plan_Lab_Sheet_DetailModelList = reportServiceMWQM_Plan_Lab_Sheet_Detail.GetReportMWQM_Plan_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheet, ServiceRes.LabSheetID, UnderTVItemID.ToString()), ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_Sheet_DetailModelListUnderTVItemIDDB_Loop_ParentTagItem_Error_Test()
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
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Lab_Sheet_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Detail_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheet.LabSheetID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_Lab_Sheet_DetailModel> ReportMWQM_Plan_Lab_Sheet_DetailModelList = reportServiceMWQM_Plan_Lab_Sheet_Detail.GetReportMWQM_Plan_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "MWQM_Plan_Lab_Sheet", ParentTagItem), ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Error);

                ParentTagItem = "Municipality";

                ReportMWQM_Plan_Lab_Sheet_DetailModelList = reportServiceMWQM_Plan_Lab_Sheet_Detail.GetReportMWQM_Plan_Lab_Sheet_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_Sheet_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "MWQM_Plan_Lab_Sheet", ParentTagItem), ReportMWQM_Plan_Lab_Sheet_DetailModelList[0].MWQM_Plan_Lab_Sheet_Detail_Error);
            }
        }
        #endregion Testing Methods MWQM_Plan_Lab_Sheet_Detail
        #region Testing Methods MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_ID");
                sb.AppendLine("|||");

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                LabSheetDetail labSheetDetail = (from c in labSheetService.db.LabSheetDetails
                                                 where c.LabSheetID == labSheet.LabSheetID
                                                 select c).FirstOrDefault();
                Assert.IsNotNull(labSheetDetail);
                Assert.IsTrue(labSheetDetail.LabSheetDetailID > 0);

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheetDetail.LabSheetDetailID;
                string ParentTagItem = "MWQM_Plan_Lab_Sheet_Detail";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail";

                List<ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModel> ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceMWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail.GetReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                LabSheetDetail labSheetDetail = (from c in labSheetService.db.LabSheetDetails
                                                 where c.LabSheetID == labSheet.LabSheetID
                                                 select c).FirstOrDefault();
                Assert.IsNotNull(labSheetDetail);
                Assert.IsTrue(labSheetDetail.LabSheetDetailID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Counter");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_ID");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Ordinal");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_MPN");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Tube_10");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Salinity");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Temperature");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Processed_By");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheetDetail.LabSheetDetailID;
                string ParentTagItem = "MWQM_Plan_Lab_Sheet_Detail";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModel> ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceMWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail.GetReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error);
                Assert.AreEqual(1, ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Counter);
                Assert.IsTrue(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_ID > 0);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Ordinal);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_MWQM_Site);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Sample_Date_Time);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_MPN);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Tube_10);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Tube_1_0);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Tube_0_1);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Salinity);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Temperature);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Processed_By);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Sample_Type);
                //Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Site_Comment);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                LabSheetDetail labSheetDetail = (from c in labSheetService.db.LabSheetDetails
                                                 where c.LabSheetID == labSheet.LabSheetID
                                                 select c).FirstOrDefault();
                Assert.IsNotNull(labSheetDetail);
                Assert.IsTrue(labSheetDetail.LabSheetDetailID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "MWQM_Plan_Lab_Sheet_Detail";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModel> ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceMWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail.GetReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheetTubeMPNDetail, ServiceRes.LabSheetDetailID, UnderTVItemID.ToString()), ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB_Loop_ParentTagItem_Error_Test()
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
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                LabSheetDetail labSheetDetail = (from c in labSheetService.db.LabSheetDetails
                                                 where c.LabSheetID == labSheet.LabSheetID
                                                 select c).FirstOrDefault();
                Assert.IsNotNull(labSheetDetail);
                Assert.IsTrue(labSheetDetail.LabSheetDetailID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheetDetail.LabSheetDetailID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModel> ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceMWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail.GetReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "MWQM_Plan_Lab_Sheet_Detail", ParentTagItem), ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error);

                ParentTagItem = "Municipality";

                ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList = reportServiceMWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail.GetReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "MWQM_Plan_Lab_Sheet_Detail", ParentTagItem), ReportMWQM_Plan_Lab_Sheet_Tube_And_MPN_DetailModelList[0].MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail_Error);
            }
        }
        #endregion Testing Methods MWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail
        #region Testing Methods MWQM_Plan_Subsector
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_SubsectorModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Plan_Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Subsector_ID");
                sb.AppendLine("|||");

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.MWQMPlanID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Plan_Subsector";

                List<ReportMWQM_Plan_SubsectorModel> ReportMWQM_Plan_SubsectorModelList = reportServiceMWQM_Plan_Subsector.GetReportMWQM_Plan_SubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_SubsectorModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_SubsectorModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Subsector_Error");
                sb.AppendLine("MWQM_Plan_Subsector_Counter");
                sb.AppendLine("MWQM_Plan_Subsector_ID");
                sb.AppendLine("MWQM_Plan_Subsector_Name_Long");
                sb.AppendLine("MWQM_Plan_Subsector_Name_Short");
                sb.AppendLine("MWQM_Plan_Subsector_Lat");
                sb.AppendLine("MWQM_Plan_Subsector_Lng");
                sb.AppendLine("MWQM_Plan_Subsector_Last_Update_Date_UTC");
                sb.AppendLine("MWQM_Plan_Subsector_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Plan_Subsector_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = (int)labSheet.MWQMPlanID;
                string ParentTagItem = "MWQM_Plan";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_SubsectorModel> ReportMWQM_Plan_SubsectorModelList = reportServiceMWQM_Plan_Subsector.GetReportMWQM_Plan_SubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_SubsectorModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Error);
                Assert.AreEqual(1, ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Counter);
                Assert.IsTrue(ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_ID > 0);
                Assert.IsNotNull(ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Name_Long);
                Assert.IsNotNull(ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Name_Short);
                Assert.IsNotNull(ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Lat);
                Assert.IsNotNull(ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Lng);
                Assert.IsNotNull(ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_SubsectorModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Subsector_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "MWQM_Plan";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_SubsectorModel> ReportMWQM_Plan_SubsectorModelList = reportServiceMWQM_Plan_Subsector.GetReportMWQM_Plan_SubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_SubsectorModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMPlan, ServiceRes.MWQMPlanID, UnderTVItemID.ToString()), ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_SubsectorModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Subsector_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheet.MWQMPlanID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_SubsectorModel> ReportMWQM_Plan_SubsectorModelList = reportServiceMWQM_Plan_Subsector.GetReportMWQM_Plan_SubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_SubsectorModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMPlan.ToString()), ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_SubsectorModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                     where c.MWQMRunTVItemID > 0
                                     select c).FirstOrDefault();
                Assert.IsNotNull(labSheet);
                Assert.IsTrue(labSheet.MWQMPlanID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Subsector_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = labSheet.MWQMPlanID;
                string ParentTagItem = "MWQM_Plan";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Plan_Subsector";

                List<string> AllowableParentTagItemList = reportServiceMWQM_Plan._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMWQM_Plan_SubsectorModel> ReportMWQM_Plan_SubsectorModelList = reportServiceMWQM_Plan_Subsector.GetReportMWQM_Plan_SubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_SubsectorModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Subsector_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_Plan_SubsectorModelList = reportServiceMWQM_Plan_Subsector.GetReportMWQM_Plan_SubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_SubsectorModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Subsector " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Subsector_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMWQM_Plan_SubsectorModelList = reportServiceMWQM_Plan_Subsector.GetReportMWQM_Plan_SubsectorModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_SubsectorModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMWQM_Plan_SubsectorModelList[0].MWQM_Plan_Subsector_Error));
            }
        }
        #endregion Testing Methods MWQM_Plan_Subsector
        #region Testing Methods MWQM_Plan_Subsector_Site
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Subsector_SiteModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MWQM_Plan_Subsector_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Subsector_Site_ID");
                sb.AppendLine("|||");

                MWQMPlanSubsectorSite mwqmPlanSubsectorSite = (from c in labSheetService.db.MWQMPlanSubsectorSites
                                                               where c.MWQMPlanSubsectorID > 0
                                                               select c).FirstOrDefault();
                Assert.IsNotNull(mwqmPlanSubsectorSite);
                Assert.IsTrue(mwqmPlanSubsectorSite.MWQMPlanSubsectorID > 0);

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = mwqmPlanSubsectorSite.MWQMPlanSubsectorID;
                string ParentTagItem = "MWQM_Plan_Lab_Sheet";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MWQM_Plan_Subsector_Site";

                List<ReportMWQM_Plan_Subsector_SiteModel> ReportMWQM_Plan_Subsector_SiteModelList = reportServiceMWQM_Plan_Subsector_Site.GetReportMWQM_Plan_Subsector_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Subsector_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Subsector_SiteModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                MWQMPlanSubsectorSite mwqmPlanSubsectorSite = (from c in labSheetService.db.MWQMPlanSubsectorSites
                                                               where c.MWQMPlanSubsectorID > 0
                                                               select c).FirstOrDefault();
                Assert.IsNotNull(mwqmPlanSubsectorSite);
                Assert.IsTrue(mwqmPlanSubsectorSite.MWQMPlanSubsectorID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Subsector_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Subsector_Site_Error");
                sb.AppendLine("MWQM_Plan_Subsector_Site_Counter");
                sb.AppendLine("MWQM_Plan_Subsector_Site_ID");
                sb.AppendLine("MWQM_Plan_Subsector_Site_MWQM_Site");
                sb.AppendLine("MWQM_Plan_Subsector_Site_Is_Duplicate");
                sb.AppendLine("MWQM_Plan_Subsector_Site_Lat");
                sb.AppendLine("MWQM_Plan_Subsector_Site_Lng");
                sb.AppendLine("MWQM_Plan_Subsector_Site_Last_Update_Date_UTC");
                sb.AppendLine("MWQM_Plan_Subsector_Site_Last_Update_Contact_Name");
                sb.AppendLine("MWQM_Plan_Subsector_Site_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = mwqmPlanSubsectorSite.MWQMPlanSubsectorID;
                string ParentTagItem = "MWQM_Plan_Subsector";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_Subsector_SiteModel> ReportMWQM_Plan_Subsector_SiteModelList = reportServiceMWQM_Plan_Subsector_Site.GetReportMWQM_Plan_Subsector_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Subsector_SiteModelList.Count > 0);
                Assert.AreEqual("", ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_Error);
                Assert.AreEqual(1, ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_Counter);
                Assert.IsTrue(ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_ID > 0);
                Assert.IsNotNull(ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_MWQM_Site);
                Assert.IsNotNull(ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_Is_Duplicate);
                Assert.IsTrue(ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_Lat > 0);
                Assert.IsTrue(ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_Lng < 0);
                Assert.IsNotNull(ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Subsector_SiteModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                MWQMPlanSubsectorSite mwqmPlanSubsectorSite = (from c in labSheetService.db.MWQMPlanSubsectorSites
                                                               where c.MWQMPlanSubsectorID > 0
                                                               select c).FirstOrDefault();
                Assert.IsNotNull(mwqmPlanSubsectorSite);
                Assert.IsTrue(mwqmPlanSubsectorSite.MWQMPlanSubsectorID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Subsector_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Subsector_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "MWQM_Plan_Subsector";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_Subsector_SiteModel> ReportMWQM_Plan_Subsector_SiteModelList = reportServiceMWQM_Plan_Subsector_Site.GetReportMWQM_Plan_Subsector_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Subsector_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMPlanSubsector, ServiceRes.MWQMPlanSubsectorID, UnderTVItemID.ToString()), ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMWQM_Plan_Subsector_SiteModelListUnderTVItemIDDB_Loop_ParentTagItem_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                MWQMPlanSubsectorSite mwqmPlanSubsectorSite = (from c in labSheetService.db.MWQMPlanSubsectorSites
                                                               where c.MWQMPlanSubsectorID > 0
                                                               select c).FirstOrDefault();
                Assert.IsNotNull(mwqmPlanSubsectorSite);
                Assert.IsTrue(mwqmPlanSubsectorSite.MWQMPlanSubsectorID > 0);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MWQM_Plan_Subsector_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MWQM_Plan_Subsector_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = mwqmPlanSubsectorSite.MWQMPlanSubsectorID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMWQM_Plan_Subsector_SiteModel> ReportMWQM_Plan_Subsector_SiteModelList = reportServiceMWQM_Plan_Subsector_Site.GetReportMWQM_Plan_Subsector_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Subsector_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "MWQM_Plan_Subsector", ParentTagItem), ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_Error);

                ParentTagItem = "Municipality";

                ReportMWQM_Plan_Subsector_SiteModelList = reportServiceMWQM_Plan_Subsector_Site.GetReportMWQM_Plan_Subsector_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMWQM_Plan_Subsector_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "MWQM_Plan_Subsector", ParentTagItem), ReportMWQM_Plan_Subsector_SiteModelList[0].MWQM_Plan_Subsector_Site_Error);
            }
        }
        #endregion Testing Methods MWQM_Plan_Subsector_Site
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
            reportServiceMWQM_Plan = new ReportServiceMWQM_Plan((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Plan_Lab_Sheet = new ReportServiceMWQM_Plan_Lab_Sheet((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Plan_Lab_Sheet_Detail = new ReportServiceMWQM_Plan_Lab_Sheet_Detail((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail = new ReportServiceMWQM_Plan_Lab_Sheet_Tube_And_MPN_Detail((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Plan_Subsector = new ReportServiceMWQM_Plan_Subsector((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMWQM_Plan_Subsector_Site = new ReportServiceMWQM_Plan_Subsector_Site((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceMWQM_Plan);
        }
        #endregion Functions private
    }
}

