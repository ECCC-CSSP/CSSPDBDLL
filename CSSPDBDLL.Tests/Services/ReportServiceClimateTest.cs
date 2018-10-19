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
    public class ReportServiceClimateTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceClimate_Site reportServiceClimate_Site { get; set; }
        private ReportServiceClimate_Site_Data reportServiceClimate_Site_Data { get; set; }
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
        public ReportServiceClimateTest()
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
        #region Testing Methods Climate_Site
        [TestMethod]
        public void ReportService_GetReportClimate_SiteModelListUnderTVItemIDDB_Start_Good_Test()
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

                TVItemModel tvItemModelClimate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelClimate_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_Error");
                sb.AppendLine("Climate_Site_Counter");
                sb.AppendLine("Climate_Site_ID");
                sb.AppendLine("Climate_Site_Climate_ID");
                sb.AppendLine("Climate_Site_Name");
                sb.AppendLine("Climate_Site_Daily_End_Date_Local");
                sb.AppendLine("Climate_Site_Daily_Now");
                sb.AppendLine("Climate_Site_Daily_Start_Date_Local");
                sb.AppendLine("Climate_Site_ECDBID");
                sb.AppendLine("Climate_Site_Elevation_m");
                sb.AppendLine("Climate_Site_File_desc");
                sb.AppendLine("Climate_Site_Hourly_End_Date_Local");
                sb.AppendLine("Climate_Site_Hourly_Now");
                sb.AppendLine("Climate_Site_Hourly_Start_Date_Local");
                sb.AppendLine("Climate_Site_Is_Provincial");
                sb.AppendLine("Climate_Site_Last_Update_Date_UTC");
                sb.AppendLine("Climate_Site_Monthly_End_Date_Local");
                sb.AppendLine("Climate_Site_Monthly_Now");
                sb.AppendLine("Climate_Site_Monthly_Start_Date_Local");
                sb.AppendLine("Climate_Site_Province");
                sb.AppendLine("Climate_Site_Prov_Site_ID");
                sb.AppendLine("Climate_Site_TCID");
                sb.AppendLine("Climate_Site_Time_Offset_hour");
                sb.AppendLine("Climate_Site_WMOID");
                sb.AppendLine("Climate_Site_Last_Update_Contact_Name");
                sb.AppendLine("Climate_Site_Last_Update_Contact_Initial");
                sb.AppendLine("Climate_Site_Lat");
                sb.AppendLine("Climate_Site_Lng");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelClimate_Site.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportClimate_SiteModel> ReportClimate_SiteModelList = reportServiceClimate_Site.GetReportClimate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_SiteModelList.Count > 0);
                Assert.AreEqual("", ReportClimate_SiteModelList[0].Climate_Site_Error);
                Assert.AreEqual(1, ReportClimate_SiteModelList[0].Climate_Site_Counter);
                Assert.AreEqual(tvItemModelClimate_Site.TVItemID, ReportClimate_SiteModelList[0].Climate_Site_ID);
                Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Climate_ID);
                Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Name);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Daily_End_Date_Local);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Daily_Now);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Daily_Start_Date_Local);
                Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_ECDBID);
                Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Elevation_m);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_File_desc);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Hourly_End_Date_Local);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Hourly_Now);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Hourly_Start_Date_Local);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Is_Provincial);
                Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Last_Update_Date_UTC);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Monthly_End_Date_Local);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Monthly_Now);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Monthly_Start_Date_Local);
                Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Province);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Prov_Site_ID);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_TCID);
                Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Time_Offset_hour);
                //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_WMOID);
                Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Last_Update_Contact_Initial);
                Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Lat);
                Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Lng);
            }
        }
        [TestMethod]
        public void ReportService_GetReportClimate_SiteModelListUnderTVItemIDDB_Start_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelClimate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelClimate_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportClimate_SiteModel> ReportClimate_SiteModelList = reportServiceClimate_Site.GetReportClimate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportClimate_SiteModelList[0].Climate_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportClimate_SiteModelListUnderTVItemIDDB_Start_Error_TVType_Not_Climate_Site_Test()
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

                TVItemModel tvItemModelClimate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelClimate_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportClimate_SiteModel> ReportClimate_SiteModelList = reportServiceClimate_Site.GetReportClimate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.ClimateSite.ToString()), ReportClimate_SiteModelList[0].Climate_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportClimate_SiteModelListUnderTVItemIDDB_Start_Error_GetReportTreeNodesFromTagText_Test()
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
                sb.AppendLine("|||Start Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_IDNot");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Climate_Site";

                List<string> AllowableParentTagItemList = reportServiceClimate_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportClimate_SiteModel> ReportClimate_SiteModelList = reportServiceClimate_Site.GetReportClimate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportClimate_SiteModelList[0].Climate_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportClimate_SiteModelList = reportServiceClimate_Site.GetReportClimate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportClimate_SiteModelList[0].Climate_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportClimate_SiteModelList = reportServiceClimate_Site.GetReportClimate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_SiteModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportClimate_SiteModelList[0].Climate_Site_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportClimate_SiteModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelClimate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelClimate_Site.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelClimate_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Climate_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Climate_Site_Error");
                    sb.AppendLine("Climate_Site_Counter");
                    sb.AppendLine("Climate_Site_ID");
                    sb.AppendLine("Climate_Site_Climate_ID");
                    sb.AppendLine("Climate_Site_Name");
                    sb.AppendLine("Climate_Site_Daily_End_Date_Local");
                    sb.AppendLine("Climate_Site_Daily_Now");
                    sb.AppendLine("Climate_Site_Daily_Start_Date_Local");
                    sb.AppendLine("Climate_Site_ECDBID");
                    sb.AppendLine("Climate_Site_Elevation_m");
                    sb.AppendLine("Climate_Site_File_desc");
                    sb.AppendLine("Climate_Site_Hourly_End_Date_Local");
                    sb.AppendLine("Climate_Site_Hourly_Now");
                    sb.AppendLine("Climate_Site_Hourly_Start_Date_Local");
                    sb.AppendLine("Climate_Site_Is_Provincial");
                    sb.AppendLine("Climate_Site_Last_Update_Date_UTC");
                    sb.AppendLine("Climate_Site_Monthly_End_Date_Local");
                    sb.AppendLine("Climate_Site_Monthly_Now");
                    sb.AppendLine("Climate_Site_Monthly_Start_Date_Local");
                    sb.AppendLine("Climate_Site_Province");
                    sb.AppendLine("Climate_Site_Prov_Site_ID");
                    sb.AppendLine("Climate_Site_TCID");
                    sb.AppendLine("Climate_Site_Time_Offset_hour");
                    sb.AppendLine("Climate_Site_WMOID");
                    sb.AppendLine("Climate_Site_Last_Update_Contact_Name");
                    sb.AppendLine("Climate_Site_Last_Update_Contact_Initial");
                    sb.AppendLine("Climate_Site_Lat");
                    sb.AppendLine("Climate_Site_Lng");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportClimate_SiteModel> ReportClimate_SiteModelList = reportServiceClimate_Site.GetReportClimate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportClimate_SiteModelList.Count > 0);
                    Assert.AreEqual("", ReportClimate_SiteModelList[0].Climate_Site_Error);
                    Assert.AreEqual(1, ReportClimate_SiteModelList[0].Climate_Site_Counter);
                    Assert.IsTrue(ReportClimate_SiteModelList[0].Climate_Site_ID > 0);
                    Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Climate_ID);
                    Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Name);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Daily_End_Date_Local);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Daily_Now);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Daily_Start_Date_Local);
                    Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_ECDBID);
                    Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Elevation_m);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_File_desc);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Hourly_End_Date_Local);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Hourly_Now);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Hourly_Start_Date_Local);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Is_Provincial);
                    Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Last_Update_Date_UTC);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Monthly_End_Date_Local);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Monthly_Now);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Monthly_Start_Date_Local);
                    Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Province);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Prov_Site_ID);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_TCID);
                    Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Time_Offset_hour);
                    //Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_WMOID);
                    Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Last_Update_Contact_Name);
                    Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Last_Update_Contact_Initial);
                    Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Lat);
                    Assert.IsNotNull(ReportClimate_SiteModelList[0].Climate_Site_Lng);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportClimate_SiteModelListUnderTVItemIDDB_Loop_Error_TVItem_Null_Test()
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

                TVItemModel tvItemModelClimate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelClimate_Site.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, */
                    tvItemModelProvince, tvItemModelClimate_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Climate_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Climate_Site_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportClimate_SiteModel> ReportClimate_SiteModelList = reportServiceClimate_Site.GetReportClimate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportClimate_SiteModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportClimate_SiteModelList[0].Climate_Site_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportClimate_SiteModelListUnderTVItemIDDB_Loop_Error_AllowableParentTag_Test()
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

                TVItemModel tvItemModelClimate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelClimate_Site.Error);

                TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06-020", TVTypeEnum.Sector);
                Assert.AreEqual("", tvItemModelSector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSector.TVItemID;
                string ParentTagItem = tvItemModelSector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Climate_Site";

                List<string> AllowableParentTagItemList = reportServiceClimate_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportClimate_SiteModel> ReportClimate_SiteModelList = reportServiceClimate_Site.GetReportClimate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportClimate_SiteModelList[0].Climate_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportClimate_SiteModelListUnderTVItemIDDB_Loop_Error_GetReportTreeNodesFromTagText_Test()
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
                sb.AppendLine("|||Loop Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_IDNot");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Climate_Site";

                List<string> AllowableParentTagItemList = reportServiceClimate_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportClimate_SiteModel> ReportClimate_SiteModelList = reportServiceClimate_Site.GetReportClimate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportClimate_SiteModelList[0].Climate_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportClimate_SiteModelList = reportServiceClimate_Site.GetReportClimate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportClimate_SiteModelList[0].Climate_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Climate_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportClimate_SiteModelList = reportServiceClimate_Site.GetReportClimate_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_SiteModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportClimate_SiteModelList[0].Climate_Site_Error));
            }
        }
        #endregion Testing Methods Climate_Site
        #region Testing Methods Climate_Site_Data
        [TestMethod]
        public void ReportService_GetReportClimate_Site_DataModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_Data_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 229465;
                string ParentTagItem = "Climate_Site";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Climate_Site_Data";

                List<ReportClimate_Site_DataModel> ReportClimate_Site_DataModelList = reportServiceClimate_Site_Data.GetReportClimate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_Site_DataModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportClimate_Site_DataModelList[0].Climate_Site_Data_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportClimate_Site_DataModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelClimate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelClimate_Site.Error);

                var dbvar = (from c in tvItemService.db.ClimateSites
                             from cd in tvItemService.db.ClimateDataValues
                             where c.ClimateSiteID == cd.ClimateSiteID
                             && cd.TotalPrecip_mm_cm > 0
                             select new { c, cd }).FirstOrDefault();
                Assert.IsNotNull(dbvar);
                int ClimateSiteTVItemID = dbvar.c.ClimateSiteTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_Data_Error");
                sb.AppendLine("Climate_Site_Data_Counter");
                sb.AppendLine("Climate_Site_Data_ID");
                sb.AppendLine("Climate_Site_Data_Cool_Deg_Days_C");
                sb.AppendLine("Climate_Site_Data_Date_Time_Local");
                sb.AppendLine("Climate_Site_Data_Dir_Max_Gust_0North");
                sb.AppendLine("Climate_Site_Data_Heat_Deg_Days_C");
                sb.AppendLine("Climate_Site_Data_Hourly_Values");
                sb.AppendLine("Climate_Site_Data_Keep");
                sb.AppendLine("Climate_Site_Data_Last_Update_Date_UTC");
                sb.AppendLine("Climate_Site_Data_Max_Temp_C");
                sb.AppendLine("Climate_Site_Data_Min_Temp_C");
                sb.AppendLine("Climate_Site_Data_Rainfall_Entered_mm");
                sb.AppendLine("Climate_Site_Data_Rainfall_mm");
                sb.AppendLine("Climate_Site_Data_Snow_cm");
                sb.AppendLine("Climate_Site_Data_Snow_On_Ground_cm");
                sb.AppendLine("Climate_Site_Data_Spd_Max_Gust_kmh");
                sb.AppendLine("Climate_Site_Data_Storage_Data_Type");
                sb.AppendLine("Climate_Site_Data_Total_Precip_mm_cm");
                sb.AppendLine("Climate_Site_Data_Last_Update_Contact_Name");
                sb.AppendLine("Climate_Site_Data_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ClimateSiteTVItemID;
                string ParentTagItem = "Climate_Site";
                bool CountOnly = false;
                int Take = 10;

                List<ReportClimate_Site_DataModel> ReportClimate_Site_DataModelList = reportServiceClimate_Site_Data.GetReportClimate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_Site_DataModelList.Count > 0);
                Assert.AreEqual("", ReportClimate_Site_DataModelList[0].Climate_Site_Data_Error);
                Assert.IsTrue(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Counter > 0);
                Assert.IsTrue(ReportClimate_Site_DataModelList[0].Climate_Site_Data_ID > 0);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Cool_Deg_Days_C);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Date_Time_Local);
                //Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Dir_Max_Gust_0North);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Heat_Deg_Days_C);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Hourly_Values);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Keep);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Max_Temp_C);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Min_Temp_C);
                //Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Rainfall_Entered_mm);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Rainfall_mm);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Snow_cm);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Snow_On_Ground_cm);
                //Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Spd_Max_Gust_kmh);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Storage_Data_Type);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Total_Precip_mm_cm);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportClimate_Site_DataModelListUnderTVItemIDDB_Loop_Error_ParentTagItem_Not_Box_Model_Test()
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

                TVItemModel tvItemModelClimate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelClimate_Site.Error);

                var dbvar = (from c in tvItemService.db.ClimateSites
                             from cd in tvItemService.db.ClimateDataValues
                             where c.ClimateSiteID == cd.ClimateSiteID
                             && cd.TotalPrecip_mm_cm > 0
                             select new { c, cd }).FirstOrDefault();
                Assert.IsNotNull(dbvar);
                int ClimateSiteTVItemID = dbvar.c.ClimateSiteTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_Data_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Climate_SiteNot";
                bool CountOnly = false;
                int Take = 10;

                List<ReportClimate_Site_DataModel> ReportClimate_Site_DataModelList = reportServiceClimate_Site_Data.GetReportClimate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_Site_DataModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Climate_Site", ParentTagItem), ReportClimate_Site_DataModelList[0].Climate_Site_Data_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportClimate_Site_DataModelListUnderTVItemIDDB_Loop_Error_Box_Model_Null_Test()
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

                TVItemModel tvItemModelClimate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelClimate_Site.Error);

                var dbvar = (from c in tvItemService.db.ClimateSites
                             from cd in tvItemService.db.ClimateDataValues
                             where c.ClimateSiteID == cd.ClimateSiteID
                             && cd.TotalPrecip_mm_cm > 0
                             select new { c, cd }).FirstOrDefault();
                Assert.IsNotNull(dbvar);
                int ClimateSiteTVItemID = dbvar.c.ClimateSiteTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_Data_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Climate_Site";
                bool CountOnly = false;
                int Take = 10;

                List<ReportClimate_Site_DataModel> ReportClimate_Site_DataModelList = reportServiceClimate_Site_Data.GetReportClimate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_Site_DataModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateSite, ServiceRes.ClimateSiteTVItemID, UnderTVItemID.ToString()), ReportClimate_Site_DataModelList[0].Climate_Site_Data_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportClimate_Site_DataModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelClimate_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "BAS CARAQUET", TVTypeEnum.ClimateSite);
                Assert.AreEqual("", tvItemModelClimate_Site.Error);

                var dbvar = (from c in tvItemService.db.ClimateSites
                             from cd in tvItemService.db.ClimateDataValues
                             where c.ClimateSiteID == cd.ClimateSiteID
                             && cd.TotalPrecip_mm_cm > 0
                             select new { c, cd }).FirstOrDefault();
                Assert.IsNotNull(dbvar);
                int ClimateSiteTVItemID = dbvar.c.ClimateSiteTVItemID;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_Data_IDNot");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ClimateSiteTVItemID;
                string ParentTagItem = "Climate_Site";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Climate_Site_Data";

                List<string> AllowableParentTagItemList = reportServiceClimate_Site_Data._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportClimate_Site_DataModel> ReportClimate_Site_DataModelList = reportServiceClimate_Site_Data.GetReportClimate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_Site_DataModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_Data_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportClimate_Site_DataModelList = reportServiceClimate_Site_Data.GetReportClimate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_Site_DataModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Climate_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Climate_Site_Data_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportClimate_Site_DataModelList = reportServiceClimate_Site_Data.GetReportClimate_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportClimate_Site_DataModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportClimate_Site_DataModelList[0].Climate_Site_Data_Error));
            }
        }
        #endregion Testing Methods Climate_Site_Data
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
            reportServiceClimate_Site = new ReportServiceClimate_Site((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceClimate_Site_Data = new ReportServiceClimate_Site_Data((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceClimate_Site);
        }
        #endregion Functions private
    }
}

