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
    public class ReportServiceBoxModelTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceBox_Model reportServiceBox_Model { get; set; }
        private ReportServiceBox_Model_Result reportServiceBox_Model_Result { get; set; }
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
        public ReportServiceBoxModelTest()
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
        #region Testing Methods Box_Model
        [TestMethod]
        public void ReportService_GetReportBox_ModelModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Box_Model " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 28689;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Box_Model";

                List<ReportBox_ModelModel> ReportBox_ModelModelList = reportServiceBox_Model.GetReportBox_ModelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_ModelModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportBox_ModelModelList[0].Box_Model_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportBox_ModelModelListUnderTVItemIDDB_Loop_Good_Test()
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
                sb.AppendLine("|||Loop Box_Model " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_Error");
                sb.AppendLine("Box_Model_Counter");
                sb.AppendLine("Box_Model_ID");
                sb.AppendLine("Box_Model_Scenario_Name_Translation_Status");
                sb.AppendLine("Box_Model_Scenario_Name");
                sb.AppendLine("Box_Model_Flow_m3_day");
                sb.AppendLine("Box_Model_Depth_m");
                sb.AppendLine("Box_Model_Temperature_C");
                sb.AppendLine("Box_Model_Dilution");
                sb.AppendLine("Box_Model_Decay_Rate_per_day");
                sb.AppendLine("Box_Model_FC_Untreated_MPN_100ml");
                sb.AppendLine("Box_Model_FC_Pre_Disinfection_MPN_100_ml");
                sb.AppendLine("Box_Model_Concentration_MPN_100_ml");
                sb.AppendLine("Box_Model_T90_hour");
                sb.AppendLine("Box_Model_Flow_Duration_hour");
                sb.AppendLine("Box_Model_Last_Update_Date_UTC");
                sb.AppendLine("Box_Model_Last_Update_Contact_Name");
                sb.AppendLine("Box_Model_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelInfrastructure.TVItemID;
                string ParentTagItem = tvItemModelInfrastructure.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportBox_ModelModel> ReportBox_ModelModelList = reportServiceBox_Model.GetReportBox_ModelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_ModelModelList.Count > 0);
                Assert.AreEqual("", ReportBox_ModelModelList[0].Box_Model_Error);
                Assert.IsTrue(ReportBox_ModelModelList[0].Box_Model_Counter > 0);
                Assert.IsTrue(ReportBox_ModelModelList[0].Box_Model_ID > 0);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_Scenario_Name_Translation_Status);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_Scenario_Name);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_Flow_m3_day);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_Depth_m);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_Temperature_C);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_Dilution);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_Decay_Rate_per_day);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_FC_Untreated_MPN_100ml);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_FC_Pre_Disinfection_MPN_100_ml);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_Concentration_MPN_100_ml);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_T90_hour);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_Flow_Duration_hour);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportBox_ModelModelList[0].Box_Model_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportBox_ModelModelListUnderTVItemIDDB_Loop_Error_TVItem_Null_Test()
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
                    sb.AppendLine("|||Loop Box_Model " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Box_Model_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportBox_ModelModel> ReportBox_ModelModelList = reportServiceBox_Model.GetReportBox_ModelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportBox_ModelModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportBox_ModelModelList[0].Box_Model_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportBox_ModelModelListUnderTVItemIDDB_Loop_Error_AllowableParentTag_Test()
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
                sb.AppendLine("|||Loop Box_Model " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPolSourceSite.TVItemID;
                string ParentTagItem = tvItemModelPolSourceSite.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Box_Model";

                List<string> AllowableParentTagItemList = reportServiceBox_Model._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportBox_ModelModel> ReportBox_ModelModelList = reportServiceBox_Model.GetReportBox_ModelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_ModelModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportBox_ModelModelList[0].Box_Model_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportBox_ModelModelListUnderTVItemIDDB_Loop_Error_GetReportTreeNodesFromTagText_Test()
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
                sb.AppendLine("|||Loop Box_Model " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_IDNot");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelInfrastructure.TVItemID;
                string ParentTagItem = tvItemModelInfrastructure.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Box_Model";

                List<string> AllowableParentTagItemList = reportServiceBox_Model._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportBox_ModelModel> ReportBox_ModelModelList = reportServiceBox_Model.GetReportBox_ModelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_ModelModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportBox_ModelModelList[0].Box_Model_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Box_Model " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportBox_ModelModelList = reportServiceBox_Model.GetReportBox_ModelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_ModelModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportBox_ModelModelList[0].Box_Model_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Box_Model " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportBox_ModelModelList = reportServiceBox_Model.GetReportBox_ModelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_ModelModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportBox_ModelModelList[0].Box_Model_Error));
            }
        }
        #endregion Testing Methods Box_Model
        #region Testing Methods Box_Model_Result
        [TestMethod]
        public void ReportService_GetReportBox_Model_ResultModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Box_Model_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_Result_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 28689;
                string ParentTagItem = "Box_Model";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Box_Model_Result";

                List<ReportBox_Model_ResultModel> ReportBox_Model_ResultModelList = reportServiceBox_Model_Result.GetReportBox_Model_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_Model_ResultModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportBox_Model_ResultModelList[0].Box_Model_Result_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportBox_Model_ResultModelListUnderTVItemIDDB_Loop_Good_Test()
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

                List<BoxModelModel> boxModelModelList = boxModelService.GetBoxModelModelOrderByScenarioNameDB(tvItemModelInfrastructure.TVItemID);
                Assert.IsTrue(boxModelModelList.Count > 0);

                BoxModelModel boxModelModel = boxModelModelList.FirstOrDefault();
                Assert.IsNotNull(boxModelModel);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Box_Model_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_Result_Error");
                sb.AppendLine("Box_Model_Result_Counter");
                sb.AppendLine("Box_Model_Result_ID");
                sb.AppendLine("Box_Model_Result_Result_Type");
                sb.AppendLine("Box_Model_Result_Volume_m3");
                sb.AppendLine("Box_Model_Result_Surface_m2");
                sb.AppendLine("Box_Model_Result_Radius_m");
                sb.AppendLine("Box_Model_Result_Left_Side_Diameter_Line_Angle_deg");
                sb.AppendLine("Box_Model_Result_Circle_Center_Latitude");
                sb.AppendLine("Box_Model_Result_Circle_Center_Longitude");
                sb.AppendLine("Box_Model_Result_Fix_Length");
                sb.AppendLine("Box_Model_Result_Fix_Width");
                sb.AppendLine("Box_Model_Result_Rect_Length_m");
                sb.AppendLine("Box_Model_Result_Rect_Width_m");
                sb.AppendLine("Box_Model_Result_Left_Side_Line_Angle_deg");
                sb.AppendLine("Box_Model_Result_Left_Side_Line_Start_Latitude");
                sb.AppendLine("Box_Model_Result_Left_Side_Line_Start_Longitude");
                sb.AppendLine("Box_Model_Result_Last_Update_Date_UTC");
                sb.AppendLine("Box_Model_Result_Last_Update_Contact_Name");
                sb.AppendLine("Box_Model_Result_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = boxModelModel.BoxModelID;
                string ParentTagItem = "Box_Model";
                bool CountOnly = false;
                int Take = 10;

                List<ReportBox_Model_ResultModel> ReportBox_Model_ResultModelList = reportServiceBox_Model_Result.GetReportBox_Model_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_Model_ResultModelList.Count > 0);
                Assert.AreEqual("", ReportBox_Model_ResultModelList[0].Box_Model_Result_Error);
                Assert.IsTrue(ReportBox_Model_ResultModelList[0].Box_Model_Result_Counter > 0);
                Assert.IsTrue(ReportBox_Model_ResultModelList[0].Box_Model_Result_ID > 0);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Result_Type);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Volume_m3);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Surface_m2);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Radius_m);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Left_Side_Diameter_Line_Angle_deg);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Circle_Center_Latitude);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Circle_Center_Longitude);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Fix_Length);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Fix_Width);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Rect_Length_m);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Rect_Width_m);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Left_Side_Line_Angle_deg);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Left_Side_Line_Start_Latitude);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Left_Side_Line_Start_Longitude);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportBox_Model_ResultModelList[0].Box_Model_Result_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportBox_Model_ResultModelListUnderTVItemIDDB_Loop_Error_ParentTagItem_Not_Box_Model_Test()
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

                List<BoxModelModel> boxModelModelList = boxModelService.GetBoxModelModelOrderByScenarioNameDB(tvItemModelInfrastructure.TVItemID);
                Assert.IsTrue(boxModelModelList.Count > 0);

                BoxModelModel boxModelModel = boxModelModelList.FirstOrDefault();
                Assert.IsNotNull(boxModelModel);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Box_Model_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_Result_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Box_ModelNot";
                bool CountOnly = false;
                int Take = 10;

                List<ReportBox_Model_ResultModel> ReportBox_Model_ResultModelList = reportServiceBox_Model_Result.GetReportBox_Model_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_Model_ResultModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Box_Model", ParentTagItem), ReportBox_Model_ResultModelList[0].Box_Model_Result_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportBox_Model_ResultModelListUnderTVItemIDDB_Loop_Error_Box_Model_Null_Test()
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

                List<BoxModelModel> boxModelModelList = boxModelService.GetBoxModelModelOrderByScenarioNameDB(tvItemModelInfrastructure.TVItemID);
                Assert.IsTrue(boxModelModelList.Count > 0);

                BoxModelModel boxModelModel = boxModelModelList.FirstOrDefault();
                Assert.IsNotNull(boxModelModel);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Box_Model_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_Result_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Box_Model";
                bool CountOnly = false;
                int Take = 10;

                List<ReportBox_Model_ResultModel> ReportBox_Model_ResultModelList = reportServiceBox_Model_Result.GetReportBox_Model_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_Model_ResultModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModel, ServiceRes.BoxModelID, UnderTVItemID.ToString()), ReportBox_Model_ResultModelList[0].Box_Model_Result_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportBox_Model_ResultModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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

                List<BoxModelModel> boxModelModelList = boxModelService.GetBoxModelModelOrderByScenarioNameDB(tvItemModelInfrastructure.TVItemID);
                Assert.IsTrue(boxModelModelList.Count > 0);

                BoxModelModel boxModelModel = boxModelModelList.FirstOrDefault();
                Assert.IsNotNull(boxModelModel);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Box_Model_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_Result_IDNot");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = boxModelModel.BoxModelID;
                string ParentTagItem = "Box_Model";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Box_Model_Result";

                List<string> AllowableParentTagItemList = reportServiceBox_Model._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportBox_Model_ResultModel> ReportBox_Model_ResultModelList = reportServiceBox_Model_Result.GetReportBox_Model_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_Model_ResultModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportBox_Model_ResultModelList[0].Box_Model_Result_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Box_Model_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_Result_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportBox_Model_ResultModelList = reportServiceBox_Model_Result.GetReportBox_Model_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_Model_ResultModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportBox_Model_ResultModelList[0].Box_Model_Result_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Box_Model_Result " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Box_Model_Result_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportBox_Model_ResultModelList = reportServiceBox_Model_Result.GetReportBox_Model_ResultModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportBox_Model_ResultModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportBox_Model_ResultModelList[0].Box_Model_Result_Error));
            }
        }
        #endregion Testing Methods Box_Model_Result
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
            reportServiceBox_Model = new ReportServiceBox_Model((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceBox_Model_Result = new ReportServiceBox_Model_Result((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceBox_Model);
        }
        #endregion Functions private
    }
}

