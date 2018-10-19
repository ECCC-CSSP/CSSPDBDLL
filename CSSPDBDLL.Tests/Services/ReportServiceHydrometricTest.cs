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
    public class ReportServiceHydrometricTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceHydrometric_Site reportServiceHydrometric_Site { get; set; }
        private ReportServiceHydrometric_Site_Data reportServiceHydrometric_Site_Data { get; set; }
        private ReportServiceHydrometric_Site_Rating_Curve reportServiceHydrometric_Site_Rating_Curve { get; set; }
        private ReportServiceHydrometric_Site_Rating_Curve_Value reportServiceHydrometric_Site_Rating_Curve_Value { get; set; }
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
        public ReportServiceHydrometricTest()
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
        #region Testing Methods Hydrometric_Site
        [TestMethod]
        public void ReportService_GetReportHydrometric_SiteModelListUnderTVItemIDDB_Start_Good_Test()
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

                TVItemModel tvItemModelHydrometric_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "SAINT JOHN RIVER AT FORT KENT", TVTypeEnum.HydrometricSite);
                Assert.AreEqual("", tvItemModelHydrometric_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_Error");
                sb.AppendLine("Hydrometric_Site_Counter");
                sb.AppendLine("Hydrometric_Site_ID");
                sb.AppendLine("Hydrometric_Site_Fed_Site_Number");
                sb.AppendLine("Hydrometric_Site_Quebec_Site_Number");
                sb.AppendLine("Hydrometric_Site_Name");
                sb.AppendLine("Hydrometric_Site_Description");
                sb.AppendLine("Hydrometric_Site_Province");
                sb.AppendLine("Hydrometric_Site_Elevation_m");
                sb.AppendLine("Hydrometric_Site_Start_Date_Local");
                sb.AppendLine("Hydrometric_Site_End_Date_Local");
                sb.AppendLine("Hydrometric_Site_Time_Offset_hour");
                sb.AppendLine("Hydrometric_Site_Drainage_Area_km2");
                sb.AppendLine("Hydrometric_Site_Is_Natural");
                sb.AppendLine("Hydrometric_Site_Is_Active");
                sb.AppendLine("Hydrometric_Site_Sediment");
                sb.AppendLine("Hydrometric_Site_RHBN");
                sb.AppendLine("Hydrometric_Site_Real_Time");
                sb.AppendLine("Hydrometric_Site_Has_Rating_Curve");
                sb.AppendLine("Hydrometric_Site_Last_Update_Date_UTC");
                sb.AppendLine("Hydrometric_Site_Last_Update_Contact_Name");
                sb.AppendLine("Hydrometric_Site_Last_Update_Contact_Initial");
                sb.AppendLine("Hydrometric_Site_Lat");
                sb.AppendLine("Hydrometric_Site_Lng");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelHydrometric_Site.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportHydrometric_SiteModel> ReportHydrometric_SiteModelList = reportServiceHydrometric_Site.GetReportHydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportHydrometric_SiteModelList.Count > 0);
                Assert.AreEqual("", ReportHydrometric_SiteModelList[0].Hydrometric_Site_Error);
                Assert.AreEqual(1, ReportHydrometric_SiteModelList[0].Hydrometric_Site_Counter);
                Assert.IsTrue(ReportHydrometric_SiteModelList[0].Hydrometric_Site_ID > 0);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Fed_Site_Number);
                //Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Quebec_Site_Number);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Name);
                //Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Description);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Province);
                //Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Elevation_m);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Start_Date_Local);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_End_Date_Local);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Time_Offset_hour);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Drainage_Area_km2);
                //Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Is_Natural);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Is_Active);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Sediment);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_RHBN);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Real_Time);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Has_Rating_Curve);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Last_Update_Date_UTC);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Last_Update_Contact_Initial);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Lat);
                Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Lng);
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_SiteModelListUnderTVItemIDDB_Start_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelHydrometric_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "SAINT JOHN RIVER AT FORT KENT", TVTypeEnum.HydrometricSite);
                Assert.AreEqual("", tvItemModelHydrometric_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportHydrometric_SiteModel> ReportHydrometric_SiteModelList = reportServiceHydrometric_Site.GetReportHydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportHydrometric_SiteModelList[0].Hydrometric_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_SiteModelListUnderTVItemIDDB_Start_Error_TVType_Not_Hydrometric_Site_Test()
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

                TVItemModel tvItemModelHydrometric_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "SAINT JOHN RIVER AT FORT KENT", TVTypeEnum.HydrometricSite);
                Assert.AreEqual("", tvItemModelHydrometric_Site.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportHydrometric_SiteModel> ReportHydrometric_SiteModelList = reportServiceHydrometric_Site.GetReportHydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.HydrometricSite.ToString()), ReportHydrometric_SiteModelList[0].Hydrometric_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_SiteModelListUnderTVItemIDDB_Start_Error_GetReportTreeNodesFromTagText_Test()
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
                sb.AppendLine("|||Start Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_IDNot");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Hydrometric_Site";

                List<string> AllowableParentTagItemList = reportServiceHydrometric_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportHydrometric_SiteModel> ReportHydrometric_SiteModelList = reportServiceHydrometric_Site.GetReportHydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportHydrometric_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportHydrometric_SiteModelList = reportServiceHydrometric_Site.GetReportHydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportHydrometric_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportHydrometric_SiteModelList = reportServiceHydrometric_Site.GetReportHydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportHydrometric_SiteModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_SiteModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelHydrometric_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "SAINT JOHN RIVER AT FORT KENT", TVTypeEnum.HydrometricSite);
                Assert.AreEqual("", tvItemModelHydrometric_Site.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelHydrometric_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Error");
                    sb.AppendLine("Hydrometric_Site_Counter");
                    sb.AppendLine("Hydrometric_Site_ID");
                    sb.AppendLine("Hydrometric_Site_Fed_Site_Number");
                    sb.AppendLine("Hydrometric_Site_Quebec_Site_Number");
                    sb.AppendLine("Hydrometric_Site_Name");
                    sb.AppendLine("Hydrometric_Site_Description");
                    sb.AppendLine("Hydrometric_Site_Province");
                    sb.AppendLine("Hydrometric_Site_Elevation_m");
                    sb.AppendLine("Hydrometric_Site_Start_Date_Local");
                    sb.AppendLine("Hydrometric_Site_End_Date_Local");
                    sb.AppendLine("Hydrometric_Site_Time_Offset_hour");
                    sb.AppendLine("Hydrometric_Site_Drainage_Area_km2");
                    sb.AppendLine("Hydrometric_Site_Is_Natural");
                    sb.AppendLine("Hydrometric_Site_Is_Active");
                    sb.AppendLine("Hydrometric_Site_Sediment");
                    sb.AppendLine("Hydrometric_Site_RHBN");
                    sb.AppendLine("Hydrometric_Site_Real_Time");
                    sb.AppendLine("Hydrometric_Site_Has_Rating_Curve");
                    sb.AppendLine("Hydrometric_Site_Last_Update_Date_UTC");
                    sb.AppendLine("Hydrometric_Site_Last_Update_Contact_Name");
                    sb.AppendLine("Hydrometric_Site_Last_Update_Contact_Initial");
                    sb.AppendLine("Hydrometric_Site_Lat");
                    sb.AppendLine("Hydrometric_Site_Lng");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportHydrometric_SiteModel> ReportHydrometric_SiteModelList = reportServiceHydrometric_Site.GetReportHydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_SiteModelList.Count > 0);
                    Assert.AreEqual("", ReportHydrometric_SiteModelList[0].Hydrometric_Site_Error);
                    Assert.AreEqual(1, ReportHydrometric_SiteModelList[0].Hydrometric_Site_Counter);
                    Assert.IsTrue(ReportHydrometric_SiteModelList[0].Hydrometric_Site_ID > 0);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Fed_Site_Number);
                    //Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Quebec_Site_Number);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Name);
                    //Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Description);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Province);
                    //Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Elevation_m);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Start_Date_Local);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_End_Date_Local);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Time_Offset_hour);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Drainage_Area_km2);
                    //Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Is_Natural);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Is_Active);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Sediment);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_RHBN);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Real_Time);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Has_Rating_Curve);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Last_Update_Date_UTC);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Last_Update_Contact_Name);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Last_Update_Contact_Initial);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Lat);
                    Assert.IsNotNull(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Lng);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_SiteModelListUnderTVItemIDDB_Loop_Error_TVItem_Null_Test()
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

                TVItemModel tvItemModelHydrometric_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "SAINT JOHN RIVER AT FORT KENT", TVTypeEnum.HydrometricSite);
                Assert.AreEqual("", tvItemModelHydrometric_Site.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, */
                    tvItemModelProvince, tvItemModelHydrometric_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportHydrometric_SiteModel> ReportHydrometric_SiteModelList = reportServiceHydrometric_Site.GetReportHydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_SiteModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportHydrometric_SiteModelList[0].Hydrometric_Site_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_SiteModelListUnderTVItemIDDB_Loop_Error_AllowableParentTag_Test()
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

                TVItemModel tvItemModelHydrometric_Site = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "SAINT JOHN RIVER AT FORT KENT", TVTypeEnum.HydrometricSite);
                Assert.AreEqual("", tvItemModelHydrometric_Site.Error);

                TVItemModel tvItemModelSector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelProvince.TVItemID, "NB-06-020", TVTypeEnum.Sector);
                Assert.AreEqual("", tvItemModelSector.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelSector.TVItemID;
                string ParentTagItem = tvItemModelSector.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Hydrometric_Site";

                List<string> AllowableParentTagItemList = reportServiceHydrometric_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportHydrometric_SiteModel> ReportHydrometric_SiteModelList = reportServiceHydrometric_Site.GetReportHydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportHydrometric_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportHydrometric_SiteModelList[0].Hydrometric_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_SiteModelListUnderTVItemIDDB_Loop_Error_GetReportTreeNodesFromTagText_Test()
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
                sb.AppendLine("|||Loop Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_IDNot");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelProvince.TVItemID;
                string ParentTagItem = tvItemModelProvince.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Hydrometric_Site";

                List<string> AllowableParentTagItemList = reportServiceHydrometric_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportHydrometric_SiteModel> ReportHydrometric_SiteModelList = reportServiceHydrometric_Site.GetReportHydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportHydrometric_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportHydrometric_SiteModelList = reportServiceHydrometric_Site.GetReportHydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportHydrometric_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Hydrometric_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportHydrometric_SiteModelList = reportServiceHydrometric_Site.GetReportHydrometric_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportHydrometric_SiteModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportHydrometric_SiteModelList[0].Hydrometric_Site_Error));
            }
        }
        #endregion Testing Methods Hydrometric_Site
        #region Testing Methods Hydrometric_Site_Data
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_DataModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_Data_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 229465;
                string ParentTagItem = "Hydrometric_Site";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Hydrometric_Site_Data";

                List<ReportHydrometric_Site_DataModel> ReportHydrometric_Site_DataModelList = reportServiceHydrometric_Site_Data.GetReportHydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportHydrometric_Site_DataModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_DataModelListUnderTVItemIDDB_Loop_Good_Test()
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
                    sb.AppendLine("|||Loop Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Data_Error");
                    sb.AppendLine("Hydrometric_Site_Data_Counter");
                    sb.AppendLine("Hydrometric_Site_Data_ID");
                    sb.AppendLine("Hydrometric_Site_Data_Date_Time_Local");
                    sb.AppendLine("Hydrometric_Site_Data_Hourly_Values");
                    sb.AppendLine("Hydrometric_Site_Data_Keep");
                    sb.AppendLine("Hydrometric_Site_Data_Flow_m3_s");
                    sb.AppendLine("Hydrometric_Site_Data_Last_Update_Date_UTC");
                    sb.AppendLine("Hydrometric_Site_Data_Last_Update_Contact_Name");
                    sb.AppendLine("Hydrometric_Site_Data_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = hydrometricSite.HydrometricSiteTVItemID;
                    string ParentTagItem = "Hydrometric_Site";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportHydrometric_Site_DataModel> ReportHydrometric_Site_DataModelList = reportServiceHydrometric_Site_Data.GetReportHydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_DataModelList.Count > 0);
                    Assert.AreEqual("", ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Error);
                    Assert.IsTrue(ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Counter > 0);
                    Assert.IsTrue(ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_ID > 0);
                    Assert.IsNotNull(ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Date_Time_Local);
                    //Assert.IsNotNull(ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Hourly_Values);
                    Assert.IsNotNull(ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Keep);
                    Assert.IsNotNull(ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Flow_m3_s);
                    Assert.IsNotNull(ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Last_Update_Date_UTC);
                    Assert.IsNotNull(ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Last_Update_Contact_Name);
                    Assert.IsNotNull(ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Last_Update_Contact_Initial);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_DataModelListUnderTVItemIDDB_Loop_Error_ParentTagItem_Not_Box_Model_Test()
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
                    sb.AppendLine("|||Loop Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Data_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = "Hydrometric_SiteNot";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportHydrometric_Site_DataModel> ReportHydrometric_Site_DataModelList = reportServiceHydrometric_Site_Data.GetReportHydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_DataModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Hydrometric_Site", ParentTagItem), ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_DataModelListUnderTVItemIDDB_Loop_Error_Box_Model_Null_Test()
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
                    sb.AppendLine("|||Loop Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Data_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = "Hydrometric_Site";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportHydrometric_Site_DataModel> ReportHydrometric_Site_DataModelList = reportServiceHydrometric_Site_Data.GetReportHydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_DataModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite, ServiceRes.HydrometricSiteTVItemID, UnderTVItemID.ToString()), ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_DataModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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
                    sb.AppendLine("|||Loop Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Data_IDNot");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = hydrometricSite.HydrometricSiteTVItemID;
                    string ParentTagItem = "Hydrometric_Site";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Hydrometric_Site_Data";

                    List<string> AllowableParentTagItemList = reportServiceHydrometric_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportHydrometric_Site_DataModel> ReportHydrometric_Site_DataModelList = reportServiceHydrometric_Site_Data.GetReportHydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_DataModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Data_IDNot");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportHydrometric_Site_DataModelList = reportServiceHydrometric_Site_Data.GetReportHydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_DataModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Data " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Data_ID");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportHydrometric_Site_DataModelList = reportServiceHydrometric_Site_Data.GetReportHydrometric_Site_DataModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_DataModelList.Count > 0);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(ReportHydrometric_Site_DataModelList[0].Hydrometric_Site_Data_Error));
                }
            }
        }
        #endregion Testing Methods Hydrometric_Site_Data
        #region Testing Methods Hydrometric_Site_Rating_Curve
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_Rating_CurveModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                           select c).FirstOrDefault();
                Assert.IsNotNull(ratingCurve);

                HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                   where c.HydrometricSiteID == ratingCurve.HydrometricSiteID
                                                   select c).FirstOrDefault();
                Assert.IsNotNull(hydrometricSite);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_Rating_Curve_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = hydrometricSite.HydrometricSiteID;
                string ParentTagItem = "Hydrometric_Site";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Hydrometric_Site_Rating_Curve";

                List<ReportHydrometric_Site_Rating_CurveModel> ReportHydrometric_Site_Rating_CurveModelList = reportServiceHydrometric_Site_Rating_Curve.GetReportHydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportHydrometric_Site_Rating_CurveModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_Rating_CurveModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                               select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                       where c.HydrometricSiteID == ratingCurve.HydrometricSiteID
                                                       select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricSite);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Error");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Counter");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_ID");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Rating_Curve_Number");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = hydrometricSite.HydrometricSiteTVItemID;
                    string ParentTagItem = "Hydrometric_Site";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportHydrometric_Site_Rating_CurveModel> ReportHydrometric_Site_Rating_CurveModelList = reportServiceHydrometric_Site_Rating_Curve.GetReportHydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_CurveModelList.Count > 0);
                    Assert.AreEqual("", ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_Error);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_Counter > 0);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_ID > 0);
                    Assert.IsNotNull(ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_Rating_Curve_Number);
                    Assert.IsNotNull(ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_Last_Update_Date_UTC);
                    Assert.IsNotNull(ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_Last_Update_Contact_Name);
                    Assert.IsNotNull(ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_Last_Update_Contact_Initial);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_Rating_CurveModelListUnderTVItemIDDB_Loop_Error_ParentTagItem_Not_Hydrometric_Site_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                               select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                       where c.HydrometricSiteID == ratingCurve.HydrometricSiteID
                                                       select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricSite);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = hydrometricSite.HydrometricSiteID;
                    string ParentTagItem = "Hydrometric_SiteNot";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportHydrometric_Site_Rating_CurveModel> ReportHydrometric_Site_Rating_CurveModelList = reportServiceHydrometric_Site_Rating_Curve.GetReportHydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_CurveModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Hydrometric_Site", ParentTagItem), ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_Rating_CurveModelListUnderTVItemIDDB_Loop_Error_Hydrometric_Site_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                               select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                       where c.HydrometricSiteID == ratingCurve.HydrometricSiteID
                                                       select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricSite);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = "Hydrometric_Site";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportHydrometric_Site_Rating_CurveModel> ReportHydrometric_Site_Rating_CurveModelList = reportServiceHydrometric_Site_Rating_Curve.GetReportHydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_CurveModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite, ServiceRes.HydrometricSiteTVItemID, UnderTVItemID.ToString()), ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_Rating_CurveModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurve ratingCurve = (from c in tvItemService.db.RatingCurves
                                               select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    HydrometricSite hydrometricSite = (from c in tvItemService.db.HydrometricSites
                                                       where c.HydrometricSiteID == ratingCurve.HydrometricSiteID
                                                       select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricSite);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_IDNot");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = hydrometricSite.HydrometricSiteTVItemID;
                    string ParentTagItem = "Hydrometric_Site";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Hydrometric_Site_Rating_Curve";

                    List<string> AllowableParentTagItemList = reportServiceHydrometric_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportHydrometric_Site_Rating_CurveModel> ReportHydrometric_Site_Rating_CurveModelList = reportServiceHydrometric_Site_Rating_Curve.GetReportHydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_CurveModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_IDNot");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportHydrometric_Site_Rating_CurveModelList = reportServiceHydrometric_Site_Rating_Curve.GetReportHydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_CurveModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Rating_Curve " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_ID");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportHydrometric_Site_Rating_CurveModelList = reportServiceHydrometric_Site_Rating_Curve.GetReportHydrometric_Site_Rating_CurveModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_CurveModelList.Count > 0);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(ReportHydrometric_Site_Rating_CurveModelList[0].Hydrometric_Site_Rating_Curve_Error));
                }
            }
        }
        #endregion Testing Methods Hydrometric_Site_Rating_Curve
        #region Testing Methods Hydrometric_Site_Rating_Curve_Value
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RatingCurveValue ratingCurveValue = (from c in tvItemService.db.RatingCurveValues
                                           select c).FirstOrDefault();
                Assert.IsNotNull(ratingCurveValue);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = ratingCurveValue.RatingCurveID;
                string ParentTagItem = "Hydrometric_Site_Rating_Curve";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Hydrometric_Site_Rating_Curve_Value";

                List<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportHydrometric_Site_Rating_Curve_ValueModelList = reportServiceHydrometric_Site_Rating_Curve_Value.GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportHydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValue ratingCurveValue = (from c in tvItemService.db.RatingCurveValues
                                                         select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurveValue);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_Error");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_Counter");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_ID");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_Stage_Value_m");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name");
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = ratingCurveValue.RatingCurveID;
                    string ParentTagItem = "Hydrometric_Site_Rating_Curve";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportHydrometric_Site_Rating_Curve_ValueModelList = reportServiceHydrometric_Site_Rating_Curve_Value.GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                    Assert.AreEqual("", ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Error);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Counter > 0);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_ID > 0);
                    Assert.IsNotNull(ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Stage_Value_m);
                    Assert.IsNotNull(ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Discharge_Value_m3_s);
                    Assert.IsNotNull(ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Last_Update_Date_UTC);
                    Assert.IsNotNull(ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Name);
                    Assert.IsNotNull(ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Last_Update_Contact_Initial);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB_Loop_Error_ParentTagItem_Not_Hydrometric_Site_Rating_Curve_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValue ratingCurveValue = (from c in tvItemService.db.RatingCurveValues
                                                         select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurveValue);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = ratingCurveValue.RatingCurveID;
                    string ParentTagItem = "Hydrometric_Site_Rating_CurveNot";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportHydrometric_Site_Rating_Curve_ValueModelList = reportServiceHydrometric_Site_Rating_Curve_Value.GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Hydrometric_Site_Rating_Curve", ParentTagItem), ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB_Loop_Error_Hydrometric_Site_Rating_Curve_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValue ratingCurveValue = (from c in tvItemService.db.RatingCurveValues
                                                         select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurveValue);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = "Hydrometric_Site_Rating_Curve";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportHydrometric_Site_Rating_Curve_ValueModelList = reportServiceHydrometric_Site_Rating_Curve_Value.GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.RatingCurve, ServiceRes.RatingCurveID, UnderTVItemID.ToString()), ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    RatingCurveValue ratingCurveValue = (from c in tvItemService.db.RatingCurveValues
                                                         select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurveValue);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_IDNot");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = ratingCurveValue.RatingCurveID;
                    string ParentTagItem = "Hydrometric_Site_Rating_Curve";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Hydrometric_Site_Rating_Curve_Value";

                    List<string> AllowableParentTagItemList = reportServiceHydrometric_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportHydrometric_Site_Rating_Curve_ValueModel> ReportHydrometric_Site_Rating_Curve_ValueModelList = reportServiceHydrometric_Site_Rating_Curve_Value.GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_IDNot");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportHydrometric_Site_Rating_Curve_ValueModelList = reportServiceHydrometric_Site_Rating_Curve_Value.GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Error));

                    sb = new StringBuilder();
                    sb.AppendLine("|||Loop Hydrometric_Site_Rating_Curve_Value " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Hydrometric_Site_Rating_Curve_Value_ID");
                    sb.AppendLine("|||");

                    TagText = sb.ToString();

                    ReportHydrometric_Site_Rating_Curve_ValueModelList = reportServiceHydrometric_Site_Rating_Curve_Value.GetReportHydrometric_Site_Rating_Curve_ValueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportHydrometric_Site_Rating_Curve_ValueModelList.Count > 0);
                    Assert.IsTrue(string.IsNullOrWhiteSpace(ReportHydrometric_Site_Rating_Curve_ValueModelList[0].Hydrometric_Site_Rating_Curve_Value_Error));
                }
            }
        }
        #endregion Testing Methods Hydrometric_Site_Rating_Curve_Value
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
            reportServiceHydrometric_Site = new ReportServiceHydrometric_Site((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceHydrometric_Site_Data = new ReportServiceHydrometric_Site_Data((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceHydrometric_Site_Rating_Curve = new ReportServiceHydrometric_Site_Rating_Curve((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServiceHydrometric_Site_Rating_Curve_Value = new ReportServiceHydrometric_Site_Rating_Curve_Value((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceHydrometric_Site);
        }
        #endregion Functions private
    }
}

