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
    public class ReportServiceAreaTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceArea reportServiceArea { get; set; }
        private ReportServiceArea_File reportServiceArea_File { get; set; }
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
        public ReportServiceAreaTest()
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
        #region Testing Methods Area
        [TestMethod]
        public void ReportService_GetReportAreaModelListUnderTVItemIDDB_Start_Good_Test()
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

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Error");
                sb.AppendLine("Area_Counter");
                sb.AppendLine("Area_ID");
                sb.AppendLine("Area_Name_Translation_Status");
                sb.AppendLine("Area_Name_Long");
                sb.AppendLine("Area_Name_Short");
                sb.AppendLine("Area_Is_Active");
                sb.AppendLine("Area_Last_Update_Date_And_Time");
                sb.AppendLine("Area_Last_Update_Contact_Name");
                sb.AppendLine("Area_Last_Update_Contact_Initial");
                sb.AppendLine("Area_Lat");
                sb.AppendLine("Area_Lng");
                sb.AppendLine("Area_Stat_Sector_Count");
                sb.AppendLine("Area_Stat_Subsector_Count");
                sb.AppendLine("Area_Stat_Municipality_Count");
                sb.AppendLine("Area_Stat_Lift_Station_Count");
                sb.AppendLine("Area_Stat_WWTP_Count");
                sb.AppendLine("Area_Stat_MWQM_Sample_Count");
                sb.AppendLine("Area_Stat_MWQM_Site_Count");
                sb.AppendLine("Area_Stat_MWQM_Run_Count");
                sb.AppendLine("Area_Stat_Pol_Source_Site_Count");
                sb.AppendLine("Area_Stat_Mike_Scenario_Count");
                sb.AppendLine("Area_Stat_Box_Model_Scenario_Count");
                sb.AppendLine("Area_Stat_Visual_Plumes_Scenario_Count");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelArea.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportAreaModel> ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportAreaModelList.Count > 0);
                Assert.AreEqual("", ReportAreaModelList[0].Area_Error);
                Assert.AreEqual(1, ReportAreaModelList[0].Area_Counter);
                Assert.AreEqual(tvItemModelArea.TVItemID, ReportAreaModelList[0].Area_ID);
                Assert.IsNotNull(ReportAreaModelList[0].Area_Name_Translation_Status);
                Assert.IsNotNull(ReportAreaModelList[0].Area_Last_Update_Date_And_Time_UTC);
                Assert.IsTrue(ReportAreaModelList[0].Area_Last_Update_Contact_Name.Length > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Last_Update_Contact_Initial.Length > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Lat != 0.0f);
                Assert.IsTrue(ReportAreaModelList[0].Area_Lng != 0.0f);
                Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Sector_Count > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Subsector_Count > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Municipality_Count > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Lift_Station_Count > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Stat_WWTP_Count > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Stat_MWQM_Sample_Count > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Stat_MWQM_Site_Count > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Stat_MWQM_Run_Count > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Pol_Source_Site_Count > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Mike_Scenario_Count > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Box_Model_Scenario_Count > 0);
                Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Visual_Plumes_Scenario_Count > 0);
            }
        }
        [TestMethod]
        public void ReportService_GetReportAreaModelListUnderTVItemIDDB_Start_ASCENDING_Good_Test()
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

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short ASCENDING 1");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelArea.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportAreaModel> ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportAreaModelList.Count > 0);
                Assert.AreEqual("", ReportAreaModelList[0].Area_Error);
                Assert.AreEqual("NB-06", ReportAreaModelList[0].Area_Name_Short);
            }
        }
        [TestMethod]
        public void ReportService_GetReportAreaModelListUnderTVItemIDDB_Start_CONTAIN_Good_Test()
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

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short CONTAIN NB");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelArea.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportAreaModel> ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(1, ReportAreaModelList.Count);
                Assert.AreEqual("", ReportAreaModelList[0].Area_Error);
                Assert.AreEqual("NB-06", ReportAreaModelList[0].Area_Name_Short);


                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short NOT_CONTAIN NB");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(0, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short CONTAIN AA");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(0, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short EQUAL NB-06");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(1, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short START_WITH n");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(1, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short START_WITH p");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(0, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short BIGGER_THAN NA");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(1, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short BIGGER_THAN NC");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(0, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short SMALLER_THAN NC");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(1, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short SMALLER_THAN NA");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(0, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short BETWEEN NA NC");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(1, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short BETWEEN NC ND");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(0, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short BETWEEN N Na");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(0, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short NOT_BETWEEN N Na");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(1, ReportAreaModelList.Count);

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_Name_Short NOT_BETWEEN Nc Nd");
                sb.AppendLine("|||");

                Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                TagText = sb.ToString();
                UnderTVItemID = tvItemModelArea.TVItemID;
                ParentTagItem = "";
                CountOnly = false;
                Take = 10;

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(1, ReportAreaModelList.Count);
            }
        }
        [TestMethod]
        public void ReportService_GetReportAreaModelListUnderTVItemIDDB_Start_Error_TVItem_Null_Test()
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

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportAreaModel> ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportAreaModelList[0].Area_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportAreaModelListUnderTVItemIDDB_Start_Error_TVType_Not_Area_Test()
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


                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportAreaModel> ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Area.ToString()), ReportAreaModelList[0].Area_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportAreaModelListUnderTVItemIDDB_Start_Error_GetReportTreeNodesFromTagText_Test()
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
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Area";

                List<string> AllowableParentTagItemList = reportServiceArea._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportAreaModel> ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportAreaModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportAreaModelList[0].Area_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportAreaModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportAreaModelList[0].Area_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportAreaModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportAreaModelList[0].Area_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportAreaModelListUnderTVItemIDDB_Loop_Good_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Area " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Area_Error");
                    sb.AppendLine("Area_Counter");
                    sb.AppendLine("Area_ID");
                    sb.AppendLine("Area_Name_Translation_Status");
                    sb.AppendLine("Area_Name_Long");
                    sb.AppendLine("Area_Name_Short");
                    sb.AppendLine("Area_Is_Active");
                    sb.AppendLine("Area_Last_Update_Date_And_Time");
                    sb.AppendLine("Area_Last_Update_Contact_Name");
                    sb.AppendLine("Area_Last_Update_Contact_Initial");
                    sb.AppendLine("Area_Lat");
                    sb.AppendLine("Area_Lng");
                    sb.AppendLine("Area_Stat_Sector_Count");
                    sb.AppendLine("Area_Stat_Subsector_Count");
                    sb.AppendLine("Area_Stat_Municipality_Count");
                    sb.AppendLine("Area_Stat_Lift_Station_Count");
                    sb.AppendLine("Area_Stat_WWTP_Count");
                    sb.AppendLine("Area_Stat_MWQM_Sample_Count");
                    sb.AppendLine("Area_Stat_MWQM_Site_Count");
                    sb.AppendLine("Area_Stat_MWQM_Run_Count");
                    sb.AppendLine("Area_Stat_Pol_Source_Site_Count");
                    sb.AppendLine("Area_Stat_Mike_Scenario_Count");
                    sb.AppendLine("Area_Stat_Box_Model_Scenario_Count");
                    sb.AppendLine("Area_Stat_Visual_Plumes_Scenario_Count");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportAreaModel> ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportAreaModelList.Count > 0);
                    Assert.AreEqual("", ReportAreaModelList[0].Area_Error);
                    Assert.AreEqual(1, ReportAreaModelList[0].Area_Counter);
                    Assert.IsTrue(ReportAreaModelList[0].Area_ID > 0);
                    Assert.IsNotNull(ReportAreaModelList[0].Area_Name_Translation_Status);
                    Assert.IsNotNull(ReportAreaModelList[0].Area_Last_Update_Date_And_Time_UTC);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Last_Update_Contact_Initial.Length > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Lat != 0.0f);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Lng != 0.0f);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Sector_Count > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Subsector_Count > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Municipality_Count > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Lift_Station_Count > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Stat_WWTP_Count > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Stat_MWQM_Sample_Count > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Stat_MWQM_Site_Count > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Stat_MWQM_Run_Count > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Pol_Source_Site_Count > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Mike_Scenario_Count > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Box_Model_Scenario_Count > 0);
                    Assert.IsTrue(ReportAreaModelList[0].Area_Stat_Visual_Plumes_Scenario_Count > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportAreaModelListUnderTVItemIDDB_Loop_Error_TVItem_Null_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Area " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Area_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportAreaModel> ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportAreaModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportAreaModelList[0].Area_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportAreaModelListUnderTVItemIDDB_Loop_Error_AllowableParentTag_Test()
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

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSector.TVItemID;
                string ParentTagItem = tvItemModelSector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Area";

                List<string> AllowableParentTagItemList = reportServiceArea._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportAreaModel> ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportAreaModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportAreaModelList[0].Area_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportAreaModelListUnderTVItemIDDB_Loop_Error_GetReportTreeNodesFromTagText_Test()
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
                sb.AppendLine("|||Loop Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Area";

                List<string> AllowableParentTagItemList = reportServiceArea._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportAreaModel> ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportAreaModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportAreaModelList[0].Area_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportAreaModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportAreaModelList[0].Area_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Area " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Area_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportAreaModelList = reportServiceArea.GetReportAreaModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportAreaModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportAreaModelList[0].Area_Error));
            }
        }
        #endregion Testing Methods Area
        #region Testing Methods Area_File
        [TestMethod]
        public void ReportService_GetReportArea_FileModelListUnderTVItemIDDB_Good_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Area_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Area_File_Error");
                    sb.AppendLine("Area_File_Counter");
                    sb.AppendLine("Area_File_ID");
                    sb.AppendLine("Area_File_Language");
                    sb.AppendLine("Area_File_File_Purpose");
                    sb.AppendLine("Area_File_File_Type");
                    sb.AppendLine("Area_File_File_Description");
                    sb.AppendLine("Area_File_File_Size_kb");
                    sb.AppendLine("Area_File_File_Info");
                    sb.AppendLine("Area_File_File_Created_Date_UTC");
                    sb.AppendLine("Area_File_From_Water");
                    sb.AppendLine("Area_File_Server_File_Name");
                    sb.AppendLine("Area_File_Server_File_Path");
                    sb.AppendLine("Area_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Area_File_Last_Update_Contact_Name");
                    sb.AppendLine("Area_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportArea_FileModel> ReportArea_FileModelList = reportServiceArea_File.GetReportArea_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportArea_FileModelList.Count > 0);
                    Assert.IsTrue(ReportArea_FileModelList[0].Area_File_Error == "");
                    Assert.IsTrue(ReportArea_FileModelList[0].Area_File_Counter > 0);
                    Assert.IsTrue(ReportArea_FileModelList[0].Area_File_ID > 0);
                    Assert.IsTrue((int)ReportArea_FileModelList[0].Area_File_Language > 0);
                    Assert.IsTrue((int)ReportArea_FileModelList[0].Area_File_File_Purpose > 0);
                    Assert.IsTrue((int)ReportArea_FileModelList[0].Area_File_File_Type > 0);
                    Assert.IsTrue(ReportArea_FileModelList[0].Area_File_File_Description.Length > 0);
                    Assert.IsTrue(ReportArea_FileModelList[0].Area_File_File_Size_kb > 0);
                    Assert.IsTrue(ReportArea_FileModelList[0].Area_File_File_Info.Length > 0);
                    Assert.IsNotNull(ReportArea_FileModelList[0].Area_File_File_Created_Date_UTC);
                    //Assert.IsNotNull(ReportArea_FileModelList[0].Area_File_From_Water);
                    Assert.IsTrue(ReportArea_FileModelList[0].Area_File_Server_File_Name.Length > 0);
                    Assert.IsTrue(ReportArea_FileModelList[0].Area_File_Server_File_Path.Length > 0);
                    Assert.IsTrue(ReportArea_FileModelList[0].Area_File_Last_Update_Date_And_Time_UTC > new DateTime(1979, 1, 1));
                    Assert.IsTrue(ReportArea_FileModelList[0].Area_File_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportArea_FileModelList[0].Area_File_Last_Update_Contact_Initial.Length > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportArea_FileModelListUnderTVItemIDDB_Good_CountOnly_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Area_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Area_File_Error");
                    sb.AppendLine("Area_File_Counter");
                    sb.AppendLine("Area_File_ID");
                    sb.AppendLine("Area_File_Language");
                    sb.AppendLine("Area_File_File_Purpose");
                    sb.AppendLine("Area_File_File_Type");
                    sb.AppendLine("Area_File_File_Description");
                    sb.AppendLine("Area_File_File_Size_kb");
                    sb.AppendLine("Area_File_File_Info");
                    sb.AppendLine("Area_File_File_Created_Date_UTC");
                    sb.AppendLine("Area_File_From_Water");
                    sb.AppendLine("Area_File_Server_File_Name");
                    sb.AppendLine("Area_File_Server_File_Path");
                    sb.AppendLine("Area_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Area_File_Last_Update_Contact_Name");
                    sb.AppendLine("Area_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = true;
                    int Take = 10;

                    List<ReportArea_FileModel> ReportArea_FileModelList = reportServiceArea_File.GetReportArea_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportArea_FileModelList.Count == 1);
                    Assert.IsTrue(ReportArea_FileModelList[0].Area_File_Counter > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportArea_FileModelListUnderTVItemIDDB_Error_Start_Tag_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Area_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Area_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Area_File";

                    List<ReportArea_FileModel> ReportArea_FileModelList = reportServiceArea_File.GetReportArea_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportArea_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportArea_FileModelList[0].Area_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportArea_FileModelListUnderTVItemIDDB_Error_TVItem_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Area_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Area_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportArea_FileModel> ReportArea_FileModelList = reportServiceArea_File.GetReportArea_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportArea_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportArea_FileModelList[0].Area_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportArea_FileModelListUnderTVItemIDDB_Error_ParentTagItem_Empty_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Area_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Area_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportArea_FileModel> ReportArea_FileModelList = reportServiceArea_File.GetReportArea_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportArea_FileModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.ParentTagItemShouldNotBeEmpty, ReportArea_FileModelList[0].Area_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportArea_FileModelListUnderTVItemIDDB_Error_Allowable_ParentTagItem_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Area_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Area_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "Municipality";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Area_File";

                    List<string> AllowableParentTagItemList = reportServiceArea._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportArea_FileModel> ReportArea_FileModelList = reportServiceArea_File.GetReportArea_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportArea_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportArea_FileModelList[0].Area_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportArea_FileModelListUnderTVItemIDDB_Error_GetReportTreeNodesFromTagText_Test()
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

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() { tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Area_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Area_File_IDNot"); // line 2
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportArea_FileModel> ReportArea_FileModelList = reportServiceArea_File.GetReportArea_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportArea_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ReportServiceRes._DoesNotExistFor_, "Area_File_IDNot", "CSSPModelsDLL.Models.ReportArea_FileModel"), ReportArea_FileModelList[0].Area_File_Error);
                }
            }
        }
        #endregion Testing Methods Area_File
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
            reportServiceArea = new ReportServiceArea((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceArea_File = new ReportServiceArea_File((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceArea);
        }
        #endregion Functions private
    }
}

