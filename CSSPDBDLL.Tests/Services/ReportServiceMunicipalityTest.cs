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
    public class ReportServiceMunicipalityTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceMunicipality reportServiceMunicipality { get; set; }
        private ReportServiceMunicipality_Contact reportServiceMunicipality_Contact { get; set; }
        private ReportServiceMunicipality_Contact_Address reportServiceMunicipality_Contact_Address { get; set; }
        private ReportServiceMunicipality_Contact_Email reportServiceMunicipality_Contact_Email { get; set; }
        private ReportServiceMunicipality_Contact_Tel reportServiceMunicipality_Contact_Tel { get; set; }
        private ReportServiceMunicipality_File reportServiceMunicipality_File { get; set; }
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
        public ReportServiceMunicipalityTest()
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
        #region Testing Methods Municipality
        [TestMethod]
        public void ReportService_GetReportMunicipalityModelListUnderTVItemIDDB_Start_Good_Test()
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

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Municipality " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Error");
                sb.AppendLine("Municipality_Counter");
                sb.AppendLine("Municipality_ID");
                sb.AppendLine("Municipality_Name_Translation_Status");
                sb.AppendLine("Municipality_Name");
                sb.AppendLine("Municipality_Is_Active");
                sb.AppendLine("Municipality_Last_Update_Date_And_Time");
                sb.AppendLine("Municipality_Last_Update_Contact_Name");
                sb.AppendLine("Municipality_Last_Update_Contact_Initial");
                sb.AppendLine("Municipality_Lat");
                sb.AppendLine("Municipality_Lng");
                sb.AppendLine("Municipality_Stat_Lift_Station_Count");
                sb.AppendLine("Municipality_Stat_WWTP_Count");
                sb.AppendLine("Municipality_Stat_Mike_Scenario_Count");
                sb.AppendLine("Municipality_Stat_Box_Model_Scenario_Count");
                sb.AppendLine("Municipality_Stat_Visual_Plumes_Scenario_Count");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMunicipalityModel> ReportMunicipalityModelList = reportServiceMunicipality.GetReportMunicipalityModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipalityModelList.Count > 0);
                Assert.AreEqual("", ReportMunicipalityModelList[0].Municipality_Error);
                Assert.AreEqual(1, ReportMunicipalityModelList[0].Municipality_Counter);
                Assert.AreEqual(tvItemModelMunicipality.TVItemID, ReportMunicipalityModelList[0].Municipality_ID);
                Assert.IsNotNull(ReportMunicipalityModelList[0].Municipality_Name);
                Assert.IsNotNull(ReportMunicipalityModelList[0].Municipality_Name_Translation_Status);
                Assert.IsNotNull(ReportMunicipalityModelList[0].Municipality_Last_Update_Date_And_Time_UTC);
                Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Last_Update_Contact_Name.Length > 0);
                Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Last_Update_Contact_Initial.Length > 0);
                Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Lat != 0.0f);
                Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Lng != 0.0f);
                Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Stat_Lift_Station_Count > 0);
                Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Stat_WWTP_Count > 0);
                Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Stat_Mike_Scenario_Count > 0);
                Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Stat_Box_Model_Scenario_Count > 0);
                Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Stat_Visual_Plumes_Scenario_Count > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipalityModelListUnderTVItemIDDB_Start_TVItem_Null_Error_Test()
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

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Municipality " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMunicipalityModel> ReportMunicipalityModelList = reportServiceMunicipality.GetReportMunicipalityModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMunicipalityModelList[0].Municipality_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipalityModelListUnderTVItemIDDB_Start_TVType_Not_Municipality_Error_Test()
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

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Municipality " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMunicipalityModel> ReportMunicipalityModelList = reportServiceMunicipality.GetReportMunicipalityModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Municipality.ToString()), ReportMunicipalityModelList[0].Municipality_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipalityModelListUnderTVItemIDDB_Start_GetReportTreeNodesFromTagText_Error_Test()
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

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Municipality " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality";

                List<string> AllowableParentTagItemList = reportServiceMunicipality._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMunicipalityModel> ReportMunicipalityModelList = reportServiceMunicipality.GetReportMunicipalityModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipalityModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMunicipalityModelList[0].Municipality_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Municipality " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMunicipalityModelList = reportServiceMunicipality.GetReportMunicipalityModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipalityModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMunicipalityModelList[0].Municipality_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Municipality " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMunicipalityModelList = reportServiceMunicipality.GetReportMunicipalityModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipalityModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMunicipalityModelList[0].Municipality_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipalityModelListUnderTVItemIDDB_Loop_Good_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, */
                    tvItemModelProvince, tvItemModelMunicipality };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Municipality " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Municipality_Error");
                    sb.AppendLine("Municipality_Counter");
                    sb.AppendLine("Municipality_ID");
                    sb.AppendLine("Municipality_Name_Translation_Status");
                    sb.AppendLine("Municipality_Name");
                    sb.AppendLine("Municipality_Is_Active");
                    sb.AppendLine("Municipality_Last_Update_Date_And_Time");
                    sb.AppendLine("Municipality_Last_Update_Contact_Name");
                    sb.AppendLine("Municipality_Last_Update_Contact_Initial");
                    sb.AppendLine("Municipality_Lat");
                    sb.AppendLine("Municipality_Lng");
                    sb.AppendLine("Municipality_Stat_Lift_Station_Count");
                    sb.AppendLine("Municipality_Stat_WWTP_Count");
                    sb.AppendLine("Municipality_Stat_Mike_Scenario_Count");
                    sb.AppendLine("Municipality_Stat_Box_Model_Scenario_Count");
                    sb.AppendLine("Municipality_Stat_Visual_Plumes_Scenario_Count");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMunicipalityModel> ReportMunicipalityModelList = reportServiceMunicipality.GetReportMunicipalityModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMunicipalityModelList.Count > 0);
                    Assert.AreEqual("", ReportMunicipalityModelList[0].Municipality_Error);
                    Assert.AreEqual(1, ReportMunicipalityModelList[0].Municipality_Counter);
                    Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_ID > 0);
                    Assert.IsNotNull(ReportMunicipalityModelList[0].Municipality_Name);
                    Assert.IsNotNull(ReportMunicipalityModelList[0].Municipality_Name_Translation_Status);
                    Assert.IsNotNull(ReportMunicipalityModelList[0].Municipality_Last_Update_Date_And_Time_UTC);
                    Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Last_Update_Contact_Initial.Length > 0);
                    Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Lat != 0.0f);
                    Assert.IsTrue(ReportMunicipalityModelList[0].Municipality_Lng != 0.0f);
                    Assert.IsNotNull(ReportMunicipalityModelList[0].Municipality_Stat_Lift_Station_Count);
                    Assert.IsNotNull(ReportMunicipalityModelList[0].Municipality_Stat_WWTP_Count);
                    Assert.IsNotNull(ReportMunicipalityModelList[0].Municipality_Stat_Mike_Scenario_Count);
                    Assert.IsNotNull(ReportMunicipalityModelList[0].Municipality_Stat_Box_Model_Scenario_Count);
                    Assert.IsNotNull(ReportMunicipalityModelList[0].Municipality_Stat_Visual_Plumes_Scenario_Count);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipalityModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, */
                    tvItemModelProvince, tvItemModelMunicipality };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Municipality " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Municipality_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMunicipalityModel> ReportMunicipalityModelList = reportServiceMunicipality.GetReportMunicipalityModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMunicipalityModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMunicipalityModelList[0].Municipality_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipalityModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 28475; // should create error
                string ParentTagItem = "Infrastructure";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality";

                List<string> AllowableParentTagItemList = reportServiceMunicipality._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMunicipalityModel> ReportMunicipalityModelList = reportServiceMunicipality.GetReportMunicipalityModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipalityModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMunicipalityModelList[0].Municipality_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipalityModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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
                sb.AppendLine("|||Loop Municipality " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality";

                List<string> AllowableParentTagItemList = reportServiceMunicipality._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMunicipalityModel> ReportMunicipalityModelList = reportServiceMunicipality.GetReportMunicipalityModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipalityModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMunicipalityModelList[0].Municipality_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMunicipalityModelList = reportServiceMunicipality.GetReportMunicipalityModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipalityModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMunicipalityModelList[0].Municipality_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMunicipalityModelList = reportServiceMunicipality.GetReportMunicipalityModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipalityModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMunicipalityModelList[0].Municipality_Error));
            }
        }
        #endregion Testing Methods Municipality
        #region Testing Methods Municipality_Contact
        [TestMethod]
        public void ReportService_GetReportMunicipality_ContactModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Municipality_Contact " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 229268;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality_Contact";

                List<ReportMunicipality_ContactModel> ReportMunicipality_ContactModelList = reportServiceMunicipality_Contact.GetReportMunicipality_ContactModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_ContactModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMunicipality_ContactModelList[0].Municipality_Contact_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_ContactModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Address
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int AddressTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Error");
                sb.AppendLine("Municipality_Contact_Counter");
                sb.AppendLine("Municipality_Contact_ID");
                sb.AppendLine("Municipality_Contact_First_Name");
                sb.AppendLine("Municipality_Contact_Initial");
                sb.AppendLine("Municipality_Contact_Last_Name");
                sb.AppendLine("Municipality_Contact_Full_Name");
                sb.AppendLine("Municipality_Contact_Title");
                sb.AppendLine("Municipality_Contact_Tels");
                sb.AppendLine("Municipality_Contact_Emails");
                sb.AppendLine("Municipality_Contact_Civic_Address");
                sb.AppendLine("Municipality_Contact_Google_Address");
                sb.AppendLine("Municipality_Contact_Last_Update_Date_And_Time");
                sb.AppendLine("Municipality_Contact_Last_Update_Contact_Name");
                sb.AppendLine("Municipality_Contact_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = MunicipalityTVItemID;
                string ParentTagItem = "Municipality";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMunicipality_ContactModel> ReportMunicipality_ContactModelList = reportServiceMunicipality_Contact.GetReportMunicipality_ContactModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_ContactModelList.Count > 0);
                Assert.AreEqual("", ReportMunicipality_ContactModelList[0].Municipality_Contact_Error);
                Assert.AreEqual(1, ReportMunicipality_ContactModelList[0].Municipality_Contact_Counter);
                Assert.IsTrue(ReportMunicipality_ContactModelList[0].Municipality_Contact_ID > 0);
                Assert.IsNotNull(ReportMunicipality_ContactModelList[0].Municipality_Contact_First_Name);
                Assert.IsNotNull(ReportMunicipality_ContactModelList[0].Municipality_Contact_Initial);
                Assert.IsNotNull(ReportMunicipality_ContactModelList[0].Municipality_Contact_Last_Name);
                Assert.IsNotNull(ReportMunicipality_ContactModelList[0].Municipality_Contact_Full_Name);
                //Assert.IsNotNull(ReportMunicipality_ContactModelList[0].Municipality_Contact_Title);
                Assert.IsNotNull(ReportMunicipality_ContactModelList[0].Municipality_Contact_Tels);
                Assert.IsNotNull(ReportMunicipality_ContactModelList[0].Municipality_Contact_Emails);
                Assert.IsNotNull(ReportMunicipality_ContactModelList[0].Municipality_Contact_Civic_Address);
                //Assert.IsNotNull(ReportMunicipality_ContactModelList[0].Municipality_Contact_Google_Address);
                Assert.IsNotNull(ReportMunicipality_ContactModelList[0].Municipality_Contact_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportMunicipality_ContactModelList[0].Municipality_Contact_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMunicipality_ContactModelList[0].Municipality_Contact_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_ContactModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Address
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int AddressTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Municipality";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMunicipality_ContactModel> ReportMunicipality_ContactModelList = reportServiceMunicipality_Contact.GetReportMunicipality_ContactModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_ContactModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMunicipality_ContactModelList[0].Municipality_Contact_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_ContactModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Address
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int AddressTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                TVItemModel tvItemModelPolSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelRoot.TVItemID, TVTypeEnum.PolSourceSite).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPolSource);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPolSource.TVItemID;
                string ParentTagItem = tvItemModelPolSource.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality_Contact";

                List<string> AllowableParentTagItemList = reportServiceMunicipality._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMunicipality_ContactModel> ReportMunicipality_ContactModelList = reportServiceMunicipality_Contact.GetReportMunicipality_ContactModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_ContactModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMunicipality_ContactModelList[0].Municipality_Contact_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_ContactModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Address
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int AddressTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_IDNot");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = MunicipalityTVItemID;
                string ParentTagItem = "Municipality";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality_Contact";

                List<string> AllowableParentTagItemList = reportServiceMunicipality._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMunicipality_ContactModel> ReportMunicipality_ContactModelList = reportServiceMunicipality_Contact.GetReportMunicipality_ContactModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_ContactModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMunicipality_ContactModelList[0].Municipality_Contact_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMunicipality_ContactModelList = reportServiceMunicipality_Contact.GetReportMunicipality_ContactModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_ContactModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMunicipality_ContactModelList[0].Municipality_Contact_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMunicipality_ContactModelList = reportServiceMunicipality_Contact.GetReportMunicipality_ContactModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_ContactModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMunicipality_ContactModelList[0].Municipality_Contact_Error));
            }
        }
        #endregion Testing Methods Municipality_Contact
        #region Testing Methods Municipality_Contact_Address
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Address
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int AddressTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Municipality_Contact_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Address_Error");
                sb.AppendLine("Municipality_Contact_Address_Counter");
                sb.AppendLine("Municipality_Contact_Address_ID");
                sb.AppendLine("Municipality_Contact_Address_Type");
                sb.AppendLine("Municipality_Contact_Address_Country");
                sb.AppendLine("Municipality_Contact_Address_Province");
                sb.AppendLine("Municipality_Contact_Address_Municipality");
                sb.AppendLine("Municipality_Contact_Address_Street_Name");
                sb.AppendLine("Municipality_Contact_Address_Street_Number");
                sb.AppendLine("Municipality_Contact_Address_Street_Type");
                sb.AppendLine("Municipality_Contact_Address_Postal_Code");
                sb.AppendLine("Municipality_Contact_Address_Google_Address_Text");
                sb.AppendLine("Municipality_Contact_Address_Last_Update_Date_And_Time");
                sb.AppendLine("Municipality_Contact_Address_Last_Update_Contact_Name");
                sb.AppendLine("Municipality_Contact_Address_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = MunicipalityTVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality_Contact_Address";

                List<ReportMunicipality_Contact_AddressModel> ReportMunicipality_Contact_AddressModelList = reportServiceMunicipality_Contact_Address.GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Address
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int AddressTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Address_Error");
                sb.AppendLine("Municipality_Contact_Address_Counter");
                sb.AppendLine("Municipality_Contact_Address_ID");
                sb.AppendLine("Municipality_Contact_Address_Type");
                sb.AppendLine("Municipality_Contact_Address_Country");
                sb.AppendLine("Municipality_Contact_Address_Province");
                sb.AppendLine("Municipality_Contact_Address_Municipality");
                sb.AppendLine("Municipality_Contact_Address_Street_Name");
                sb.AppendLine("Municipality_Contact_Address_Street_Number");
                sb.AppendLine("Municipality_Contact_Address_Street_Type");
                sb.AppendLine("Municipality_Contact_Address_Postal_Code");
                sb.AppendLine("Municipality_Contact_Address_Google_Address_Text");
                sb.AppendLine("Municipality_Contact_Address_Last_Update_Date_And_Time");
                sb.AppendLine("Municipality_Contact_Address_Last_Update_Contact_Name");
                sb.AppendLine("Municipality_Contact_Address_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ContactTVItemID;
                string ParentTagItem = "Municipality_Contact";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMunicipality_Contact_AddressModel> ReportMunicipality_Contact_AddressModelList = reportServiceMunicipality_Contact_Address.GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_AddressModelList.Count > 0);
                Assert.AreEqual("", ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Error);
                Assert.IsTrue(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Counter > 0);
                Assert.IsTrue(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_ID > 0);
                Assert.IsNotNull(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Type);
                Assert.IsNotNull(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Country);
                Assert.IsNotNull(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Province);
                Assert.IsNotNull(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Municipality);
                Assert.IsNotNull(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Street_Name);
                Assert.IsNotNull(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Street_Number);
                Assert.IsNotNull(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Street_Type);
                Assert.IsNotNull(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Postal_Code);
                Assert.IsNotNull(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Google_Address_Text);
                Assert.IsNotNull(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Address
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int AddressTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Address_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Municipality_Contact";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMunicipality_Contact_AddressModel> ReportMunicipality_Contact_AddressModelList = reportServiceMunicipality_Contact_Address.GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_AddressModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Address
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int AddressTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Address_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ContactTVItemID;
                string ParentTagItem = "Pol_Source_Site"; // will create error
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality_Contact_Address";

                List<string> AllowableParentTagItemList = reportServiceMunicipality._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMunicipality_Contact_AddressModel> ReportMunicipality_Contact_AddressModelList = reportServiceMunicipality_Contact_Address.GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_AddressModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Municipality_Contact", ParentTagItem), ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Address
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int AddressTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Address_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ContactTVItemID;
                string ParentTagItem = "Municipality_Contact";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality_Contact_Address";

                List<string> AllowableParentTagItemList = reportServiceMunicipality._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMunicipality_Contact_AddressModel> ReportMunicipality_Contact_AddressModelList = reportServiceMunicipality_Contact_Address.GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_AddressModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Address_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMunicipality_Contact_AddressModelList = reportServiceMunicipality_Contact_Address.GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_AddressModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Address_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMunicipality_Contact_AddressModelList = reportServiceMunicipality_Contact_Address.GetReportMunicipality_Contact_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_AddressModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMunicipality_Contact_AddressModelList[0].Municipality_Contact_Address_Error));
            }
        }
        #endregion Testing Methods Municipality_Contact_Address
        #region Testing Methods Municipality_Contact_Email
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Email
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int EmailTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Municipality_Contact_Email " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Email_Error");
                sb.AppendLine("Municipality_Contact_Email_Counter");
                sb.AppendLine("Municipality_Contact_Email_ID");
                sb.AppendLine("Municipality_Contact_Email_Type");
                sb.AppendLine("Municipality_Contact_Email_Address");
                sb.AppendLine("Municipality_Contact_Email_Last_Update_Date_And_Time");
                sb.AppendLine("Municipality_Contact_Email_Last_Update_Contact_Name");
                sb.AppendLine("Municipality_Contact_Email_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = MunicipalityTVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality_Contact_Email";

                List<ReportMunicipality_Contact_EmailModel> ReportMunicipality_Contact_EmailModelList = reportServiceMunicipality_Contact_Email.GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Email
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int EmailTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Email " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Email_Error");
                sb.AppendLine("Municipality_Contact_Email_Counter");
                sb.AppendLine("Municipality_Contact_Email_ID");
                sb.AppendLine("Municipality_Contact_Email_Type");
                sb.AppendLine("Municipality_Contact_Email_Address");
                sb.AppendLine("Municipality_Contact_Email_Last_Update_Date_And_Time");
                sb.AppendLine("Municipality_Contact_Email_Last_Update_Contact_Name");
                sb.AppendLine("Municipality_Contact_Email_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ContactTVItemID;
                string ParentTagItem = "Municipality_Contact";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMunicipality_Contact_EmailModel> ReportMunicipality_Contact_EmailModelList = reportServiceMunicipality_Contact_Email.GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_EmailModelList.Count > 0);
                Assert.AreEqual("", ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_Error);
                Assert.IsTrue(ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_Counter > 0);
                Assert.IsTrue(ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_ID > 0);
                Assert.IsNotNull(ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_Type);
                Assert.IsNotNull(ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_Address);
                Assert.IsNotNull(ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Email
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int EmailTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Email " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Email_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Municipality_Contact";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMunicipality_Contact_EmailModel> ReportMunicipality_Contact_EmailModelList = reportServiceMunicipality_Contact_Email.GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_EmailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Email
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int EmailTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Email " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Email_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ContactTVItemID;
                string ParentTagItem = "Pol_Source_Site"; // will create error
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality_Contact_Email";

                List<string> AllowableParentTagItemList = reportServiceMunicipality._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMunicipality_Contact_EmailModel> ReportMunicipality_Contact_EmailModelList = reportServiceMunicipality_Contact_Email.GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_EmailModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Municipality_Contact", ParentTagItem), ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Email
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int EmailTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Email " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Email_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ContactTVItemID;
                string ParentTagItem = "Municipality_Contact";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality_Contact_Email";

                List<string> AllowableParentTagItemList = reportServiceMunicipality._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMunicipality_Contact_EmailModel> ReportMunicipality_Contact_EmailModelList = reportServiceMunicipality_Contact_Email.GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_EmailModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Email " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Email_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMunicipality_Contact_EmailModelList = reportServiceMunicipality_Contact_Email.GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_EmailModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Email " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Email_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMunicipality_Contact_EmailModelList = reportServiceMunicipality_Contact_Email.GetReportMunicipality_Contact_EmailModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_EmailModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMunicipality_Contact_EmailModelList[0].Municipality_Contact_Email_Error));
            }
        }
        #endregion Testing Methods Municipality_Contact_Email
        #region Testing Methods Municipality_Contact_Tel
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Tel
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int TelTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Municipality_Contact_Tel " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Tel_Error");
                sb.AppendLine("Municipality_Contact_Tel_Counter");
                sb.AppendLine("Municipality_Contact_Tel_ID");
                sb.AppendLine("Municipality_Contact_Tel_Type");
                sb.AppendLine("Municipality_Contact_Tel_Number");
                sb.AppendLine("Municipality_Contact_Tel_Last_Update_Date_And_Time");
                sb.AppendLine("Municipality_Contact_Tel_Last_Update_Contact_Name");
                sb.AppendLine("Municipality_Contact_Tel_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = MunicipalityTVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality_Contact_Tel";

                List<ReportMunicipality_Contact_TelModel> ReportMunicipality_Contact_TelModelList = reportServiceMunicipality_Contact_Tel.GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Tel
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int TelTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Tel " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Tel_Error");
                sb.AppendLine("Municipality_Contact_Tel_Counter");
                sb.AppendLine("Municipality_Contact_Tel_ID");
                sb.AppendLine("Municipality_Contact_Tel_Type");
                sb.AppendLine("Municipality_Contact_Tel_Number");
                sb.AppendLine("Municipality_Contact_Tel_Last_Update_Date_And_Time");
                sb.AppendLine("Municipality_Contact_Tel_Last_Update_Contact_Name");
                sb.AppendLine("Municipality_Contact_Tel_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ContactTVItemID;
                string ParentTagItem = "Municipality_Contact";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMunicipality_Contact_TelModel> ReportMunicipality_Contact_TelModelList = reportServiceMunicipality_Contact_Tel.GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_TelModelList.Count > 0);
                Assert.AreEqual("", ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_Error);
                Assert.IsTrue(ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_Counter > 0);
                Assert.IsTrue(ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_ID > 0);
                Assert.IsNotNull(ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_Type);
                Assert.IsNotNull(ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_Number);
                Assert.IsNotNull(ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Tel
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int TelTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Tel " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Tel_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Municipality_Contact";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMunicipality_Contact_TelModel> ReportMunicipality_Contact_TelModelList = reportServiceMunicipality_Contact_Tel.GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_TelModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Tel
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int TelTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Tel " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Tel_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ContactTVItemID;
                string ParentTagItem = "Pol_Source_Site"; // will create error
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality_Contact_Tel";

                List<string> AllowableParentTagItemList = reportServiceMunicipality._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMunicipality_Contact_TelModel> ReportMunicipality_Contact_TelModelList = reportServiceMunicipality_Contact_Tel.GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_TelModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Municipality_Contact", ParentTagItem), ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                var tvItemLink = (from c in tvItemService.db.TVItemLinks
                                  from c2 in tvItemService.db.TVItemLinks
                                  where c.FromTVType == (int)TVTypeEnum.Contact
                                  && c.ToTVType == (int)TVTypeEnum.Tel
                                  && c2.FromTVType == (int)TVTypeEnum.Municipality
                                  && c2.ToTVType == (int)TVTypeEnum.Contact
                                  && c.FromTVItemID == c2.ToTVItemID
                                  select new { c, c2 }).FirstOrDefault();

                int TelTVItemID = tvItemLink.c.ToTVItemID;
                int ContactTVItemID = tvItemLink.c.FromTVItemID;
                int MunicipalityTVItemID = tvItemLink.c2.FromTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Tel " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Tel_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ContactTVItemID;
                string ParentTagItem = "Municipality_Contact";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Municipality_Contact_Tel";

                List<string> AllowableParentTagItemList = reportServiceMunicipality._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportMunicipality_Contact_TelModel> ReportMunicipality_Contact_TelModelList = reportServiceMunicipality_Contact_Tel.GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_TelModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Tel " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Tel_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMunicipality_Contact_TelModelList = reportServiceMunicipality_Contact_Tel.GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_TelModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Municipality_Contact_Tel " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Municipality_Contact_Tel_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportMunicipality_Contact_TelModelList = reportServiceMunicipality_Contact_Tel.GetReportMunicipality_Contact_TelModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMunicipality_Contact_TelModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportMunicipality_Contact_TelModelList[0].Municipality_Contact_Tel_Error));
            }
        }
        #endregion Testing Methods Municipality_Contact_Tel
        #region Testing Methods Municipality_File
        [TestMethod]
        public void ReportService_GetReportMunicipality_FileModelListUnderTVItemIDDB_Good_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMunicipality };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Municipality_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Municipality_File_Error");
                    sb.AppendLine("Municipality_File_Counter");
                    sb.AppendLine("Municipality_File_ID");
                    sb.AppendLine("Municipality_File_Language");
                    sb.AppendLine("Municipality_File_File_Purpose");
                    sb.AppendLine("Municipality_File_File_Type");
                    sb.AppendLine("Municipality_File_File_Description");
                    sb.AppendLine("Municipality_File_File_Size_kb");
                    sb.AppendLine("Municipality_File_File_Info");
                    sb.AppendLine("Municipality_File_File_Created_Date_UTC");
                    sb.AppendLine("Municipality_File_From_Water");
                    sb.AppendLine("Municipality_File_Server_File_Name");
                    sb.AppendLine("Municipality_File_Server_File_Path");
                    sb.AppendLine("Municipality_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Municipality_File_Last_Update_Contact_Name");
                    sb.AppendLine("Municipality_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMunicipality_FileModel> ReportMunicipality_FileModelList = reportServiceMunicipality_File.GetReportMunicipality_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMunicipality_FileModelList.Count > 0);
                    Assert.IsTrue(ReportMunicipality_FileModelList[0].Municipality_File_Error == "");
                    Assert.IsTrue(ReportMunicipality_FileModelList[0].Municipality_File_Counter > 0);
                    Assert.IsTrue(ReportMunicipality_FileModelList[0].Municipality_File_ID > 0);
                    Assert.IsTrue((int)ReportMunicipality_FileModelList[0].Municipality_File_Language > 0);
                    Assert.IsTrue((int)ReportMunicipality_FileModelList[0].Municipality_File_File_Purpose > 0);
                    Assert.IsTrue((int)ReportMunicipality_FileModelList[0].Municipality_File_File_Type > 0);
                    Assert.IsTrue(ReportMunicipality_FileModelList[0].Municipality_File_File_Description.Length > 0);
                    Assert.IsTrue(ReportMunicipality_FileModelList[0].Municipality_File_File_Size_kb > 0);
                    Assert.IsTrue(ReportMunicipality_FileModelList[0].Municipality_File_File_Info.Length > 0);
                    Assert.IsNotNull(ReportMunicipality_FileModelList[0].Municipality_File_File_Created_Date_UTC);
                    //Assert.IsNotNull(ReportMunicipality_FileModelList[0].Municipality_File_From_Water);
                    Assert.IsTrue(ReportMunicipality_FileModelList[0].Municipality_File_Server_File_Name.Length > 0);
                    Assert.IsTrue(ReportMunicipality_FileModelList[0].Municipality_File_Server_File_Path.Length > 0);
                    Assert.IsTrue(ReportMunicipality_FileModelList[0].Municipality_File_Last_Update_Date_And_Time_UTC > new DateTime(1979, 1, 1));
                    Assert.IsTrue(ReportMunicipality_FileModelList[0].Municipality_File_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportMunicipality_FileModelList[0].Municipality_File_Last_Update_Contact_Initial.Length > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_FileModelListUnderTVItemIDDB_Good_CountOnly_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMunicipality };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Municipality_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Municipality_File_Error");
                    sb.AppendLine("Municipality_File_Counter");
                    sb.AppendLine("Municipality_File_ID");
                    sb.AppendLine("Municipality_File_Language");
                    sb.AppendLine("Municipality_File_File_Purpose");
                    sb.AppendLine("Municipality_File_File_Type");
                    sb.AppendLine("Municipality_File_File_Description");
                    sb.AppendLine("Municipality_File_File_Size_kb");
                    sb.AppendLine("Municipality_File_File_Info");
                    sb.AppendLine("Municipality_File_File_Created_Date_UTC");
                    sb.AppendLine("Municipality_File_From_Water");
                    sb.AppendLine("Municipality_File_Server_File_Name");
                    sb.AppendLine("Municipality_File_Server_File_Path");
                    sb.AppendLine("Municipality_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Municipality_File_Last_Update_Contact_Name");
                    sb.AppendLine("Municipality_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = true;
                    int Take = 10;

                    List<ReportMunicipality_FileModel> ReportMunicipality_FileModelList = reportServiceMunicipality_File.GetReportMunicipality_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMunicipality_FileModelList.Count == 1);
                    Assert.IsTrue(ReportMunicipality_FileModelList[0].Municipality_File_Counter > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_FileModelListUnderTVItemIDDB_Error_Start_Tag_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMunicipality };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Municipality_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Municipality_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Municipality_File";

                    List<ReportMunicipality_FileModel> ReportMunicipality_FileModelList = reportServiceMunicipality_File.GetReportMunicipality_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMunicipality_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMunicipality_FileModelList[0].Municipality_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_FileModelListUnderTVItemIDDB_Error_TVItem_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMunicipality };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Municipality_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Municipality_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMunicipality_FileModel> ReportMunicipality_FileModelList = reportServiceMunicipality_File.GetReportMunicipality_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMunicipality_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMunicipality_FileModelList[0].Municipality_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_FileModelListUnderTVItemIDDB_Error_ParentTagItem_Empty_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMunicipality };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Municipality_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Municipality_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMunicipality_FileModel> ReportMunicipality_FileModelList = reportServiceMunicipality_File.GetReportMunicipality_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMunicipality_FileModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.ParentTagItemShouldNotBeEmpty, ReportMunicipality_FileModelList[0].Municipality_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_FileModelListUnderTVItemIDDB_Error_Allowable_ParentTagItem_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMunicipality };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Municipality_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Municipality_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "Pol_Source_Site";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Municipality_File";

                    List<string> AllowableParentTagItemList = reportServiceMunicipality._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportMunicipality_FileModel> ReportMunicipality_FileModelList = reportServiceMunicipality_File.GetReportMunicipality_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMunicipality_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMunicipality_FileModelList[0].Municipality_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMunicipality_FileModelListUnderTVItemIDDB_Error_GetReportTreeNodesFromTagText_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelMunicipality };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Municipality_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Municipality_File_IDNot"); // line 2
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMunicipality_FileModel> ReportMunicipality_FileModelList = reportServiceMunicipality_File.GetReportMunicipality_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMunicipality_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ReportServiceRes._DoesNotExistFor_, "Municipality_File_IDNot", "CSSPModelsDLL.Models.ReportMunicipality_FileModel"), ReportMunicipality_FileModelList[0].Municipality_File_Error);
                }
            }
        }
        #endregion Testing Methods Municipality_File
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
            reportServiceMunicipality = new ReportServiceMunicipality((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMunicipality_Contact = new ReportServiceMunicipality_Contact((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMunicipality_Contact_Address = new ReportServiceMunicipality_Contact_Address((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMunicipality_Contact_Email = new ReportServiceMunicipality_Contact_Email((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMunicipality_Contact_Tel = new ReportServiceMunicipality_Contact_Tel((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceMunicipality_File = new ReportServiceMunicipality_File((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceMunicipality);
        }
        #endregion Functions private
    }
}

