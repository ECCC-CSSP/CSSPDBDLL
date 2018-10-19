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
    public class ReportServiceMike_ScenarioTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceMike_Scenario_File reportServiceMike_Scenario_File { get; set; }
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
        public ReportServiceMike_ScenarioTest()
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
        #region Testing Methods Mike_Scenario_File
        [TestMethod]
        public void ReportService_GetReportMike_Scenario_FileModelListUnderTVItemIDDB_Good_Test()
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

                List<TVItemModel> tvItemModelMikeScenarioList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.MikeScenario);
                Assert.IsTrue(tvItemModelMikeScenarioList.Count > 0);

                TVItemModel tvItemModelMikeScenario = tvItemModelMikeScenarioList.Where(c => c.TVText == "Bouctouche Riv HF LS 2 HT wind east 20 km_h").FirstOrDefault();
                Assert.IsNotNull(tvItemModelMikeScenario);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelMikeScenario };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Mike_Scenario_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Mike_Scenario_File_Error");
                    sb.AppendLine("Mike_Scenario_File_Counter");
                    sb.AppendLine("Mike_Scenario_File_ID");
                    sb.AppendLine("Mike_Scenario_File_Language");
                    sb.AppendLine("Mike_Scenario_File_File_Purpose");
                    sb.AppendLine("Mike_Scenario_File_File_Type");
                    sb.AppendLine("Mike_Scenario_File_File_Description");
                    sb.AppendLine("Mike_Scenario_File_File_Size_kb");
                    sb.AppendLine("Mike_Scenario_File_File_Info");
                    sb.AppendLine("Mike_Scenario_File_File_Created_Date_UTC");
                    sb.AppendLine("Mike_Scenario_File_From_Water");
                    sb.AppendLine("Mike_Scenario_File_Server_File_Name");
                    sb.AppendLine("Mike_Scenario_File_Server_File_Path");
                    sb.AppendLine("Mike_Scenario_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Mike_Scenario_File_Last_Update_Contact_Name");
                    sb.AppendLine("Mike_Scenario_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MikeScenario" ? "Mike_Scenario" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMike_Scenario_FileModel> ReportMike_Scenario_FileModelList = reportServiceMike_Scenario_File.GetReportMike_Scenario_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList.Count > 0);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Error == "");
                    Assert.IsTrue(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Counter > 0);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_ID > 0);
                    Assert.IsTrue((int)ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Language > 0);
                    Assert.IsTrue((int)ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_File_Purpose > 0);
                    Assert.IsTrue((int)ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_File_Type > 0);
                    //Assert.IsTrue(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_File_Description.Length > 0);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_File_Size_kb > 0);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_File_Info.Length > 0);
                    Assert.IsNotNull(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_File_Created_Date_UTC);
                    //Assert.IsNotNull(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_From_Water);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Server_File_Name.Length > 0);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Server_File_Path.Length > 0);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Last_Update_Date_And_Time_UTC > new DateTime(1979, 1, 1));
                    Assert.IsTrue(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Last_Update_Contact_Initial.Length > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMike_Scenario_FileModelListUnderTVItemIDDB_Good_CountOnly_Test()
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

                List<TVItemModel> tvItemModelMikeScenarioList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.MikeScenario);
                Assert.IsTrue(tvItemModelMikeScenarioList.Count > 0);

                TVItemModel tvItemModelMikeScenario = tvItemModelMikeScenarioList.Where(c => c.TVText == "Bouctouche Riv HF LS 2 HT wind east 20 km_h").FirstOrDefault();
                Assert.IsNotNull(tvItemModelMikeScenario);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelMikeScenario };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Mike_Scenario_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Mike_Scenario_File_Error");
                    sb.AppendLine("Mike_Scenario_File_Counter");
                    sb.AppendLine("Mike_Scenario_File_ID");
                    sb.AppendLine("Mike_Scenario_File_Language");
                    sb.AppendLine("Mike_Scenario_File_File_Purpose");
                    sb.AppendLine("Mike_Scenario_File_File_Type");
                    sb.AppendLine("Mike_Scenario_File_File_Description");
                    sb.AppendLine("Mike_Scenario_File_File_Size_kb");
                    sb.AppendLine("Mike_Scenario_File_File_Info");
                    sb.AppendLine("Mike_Scenario_File_File_Created_Date_UTC");
                    sb.AppendLine("Mike_Scenario_File_From_Water");
                    sb.AppendLine("Mike_Scenario_File_Server_File_Name");
                    sb.AppendLine("Mike_Scenario_File_Server_File_Path");
                    sb.AppendLine("Mike_Scenario_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Mike_Scenario_File_Last_Update_Contact_Name");
                    sb.AppendLine("Mike_Scenario_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MikeScenario" ? "Mike_Scenario" : tvItemModel.TVType.ToString());
                    bool CountOnly = true;
                    int Take = 10;

                    List<ReportMike_Scenario_FileModel> ReportMike_Scenario_FileModelList = reportServiceMike_Scenario_File.GetReportMike_Scenario_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList.Count == 1);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Counter > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMike_Scenario_FileModelListUnderTVItemIDDB_Error_Start_Tag_Test()
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

                List<TVItemModel> tvItemModelMikeScenarioList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.MikeScenario);
                Assert.IsTrue(tvItemModelMikeScenarioList.Count > 0);

                TVItemModel tvItemModelMikeScenario = tvItemModelMikeScenarioList.Where(c => c.TVText == "Bouctouche Riv HF LS 2 HT wind east 20 km_h").FirstOrDefault();
                Assert.IsNotNull(tvItemModelMikeScenario);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelMikeScenario };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Mike_Scenario_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Mike_Scenario_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MikeScenario" ? "Mike_Scenario" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Mike_Scenario_File";

                    List<ReportMike_Scenario_FileModel> ReportMike_Scenario_FileModelList = reportServiceMike_Scenario_File.GetReportMike_Scenario_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMike_Scenario_FileModelListUnderTVItemIDDB_Error_TVItem_Test()
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

                List<TVItemModel> tvItemModelMikeScenarioList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.MikeScenario);
                Assert.IsTrue(tvItemModelMikeScenarioList.Count > 0);

                TVItemModel tvItemModelMikeScenario = tvItemModelMikeScenarioList.Where(c => c.TVText == "Bouctouche Riv HF LS 2 HT wind east 20 km_h").FirstOrDefault();
                Assert.IsNotNull(tvItemModelMikeScenario);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelMikeScenario };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Mike_Scenario_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Mike_Scenario_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MikeScenario" ? "Mike_Scenario" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMike_Scenario_FileModel> ReportMike_Scenario_FileModelList = reportServiceMike_Scenario_File.GetReportMike_Scenario_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMike_Scenario_FileModelListUnderTVItemIDDB_Error_ParentTagItem_Empty_Test()
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

                List<TVItemModel> tvItemModelMikeScenarioList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.MikeScenario);
                Assert.IsTrue(tvItemModelMikeScenarioList.Count > 0);

                TVItemModel tvItemModelMikeScenario = tvItemModelMikeScenarioList.Where(c => c.TVText == "Bouctouche Riv HF LS 2 HT wind east 20 km_h").FirstOrDefault();
                Assert.IsNotNull(tvItemModelMikeScenario);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelMikeScenario };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Mike_Scenario_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Mike_Scenario_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMike_Scenario_FileModel> ReportMike_Scenario_FileModelList = reportServiceMike_Scenario_File.GetReportMike_Scenario_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.ParentTagItemShouldNotBeEmpty, ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMike_Scenario_FileModelListUnderTVItemIDDB_Error_Allowable_ParentTagItem_Test()
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

                List<TVItemModel> tvItemModelMikeScenarioList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.MikeScenario);
                Assert.IsTrue(tvItemModelMikeScenarioList.Count > 0);

                TVItemModel tvItemModelMikeScenario = tvItemModelMikeScenarioList.Where(c => c.TVText == "Bouctouche Riv HF LS 2 HT wind east 20 km_h").FirstOrDefault();
                Assert.IsNotNull(tvItemModelMikeScenario);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelMikeScenario };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Mike_Scenario_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Mike_Scenario_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "Pol_Source_Site";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Mike_Scenario_File";

                    List<string> AllowableParentTagItemList = reportServiceMike_Scenario_File._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportMike_Scenario_FileModel> ReportMike_Scenario_FileModelList = reportServiceMike_Scenario_File.GetReportMike_Scenario_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportMike_Scenario_FileModelListUnderTVItemIDDB_Error_GetReportTreeNodesFromTagText_Test()
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

                List<TVItemModel> tvItemModelMikeScenarioList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.MikeScenario);
                Assert.IsTrue(tvItemModelMikeScenarioList.Count > 0);

                TVItemModel tvItemModelMikeScenario = tvItemModelMikeScenarioList.Where(c => c.TVText == "Bouctouche Riv HF LS 2 HT wind east 20 km_h").FirstOrDefault();
                Assert.IsNotNull(tvItemModelMikeScenario);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, tvItemModelSubsector, */
                    tvItemModelMunicipality, tvItemModelMikeScenario };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Mike_Scenario_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Mike_Scenario_File_IDNot"); // line 2
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "MikeScenario" ? "Mike_Scenario" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportMike_Scenario_FileModel> ReportMike_Scenario_FileModelList = reportServiceMike_Scenario_File.GetReportMike_Scenario_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportMike_Scenario_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ReportServiceRes._DoesNotExistFor_, "Mike_Scenario_File_IDNot", "CSSPModelsDLL.Models.ReportMike_Scenario_FileModel"), ReportMike_Scenario_FileModelList[0].Mike_Scenario_File_Error);
                }
            }
        }
        #endregion Testing Methods Mike_Scenario_File
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
            reportServiceMike_Scenario_File = new ReportServiceMike_Scenario_File((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceMike_Scenario_File);
        }
        #endregion Functions private
    }
}

