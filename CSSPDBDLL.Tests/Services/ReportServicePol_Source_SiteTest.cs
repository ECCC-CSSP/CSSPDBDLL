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

//
// C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll
//

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for ReportServiceTest
    /// </summary>
    [TestClass]
    public class ReportServicePol_Source_SiteTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServicePol_Source_Site reportServicePol_Source_Site { get; set; }
        private ReportServicePol_Source_Site_Address reportServicePol_Source_Site_Address { get; set; }
        private ReportServicePol_Source_Site_File reportServicePol_Source_Site_File { get; set; }
        private ReportServicePol_Source_Site_Obs reportServicePol_Source_Site_Obs { get; set; }
        private ReportServicePol_Source_Site_Obs_Issue reportServicePol_Source_Site_Obs_Issue { get; set; }
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
        public ReportServicePol_Source_SiteTest()
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
        #region Testing Methods Pol_Source_Site
        //[TestMethod]
        //public void Fixing_PolSourceSiteObsIssues()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        bool Found = true;
        //        while (Found)
        //        {
        //            List<PolSourceObservationIssue> polSourceList = (from c in tvItemService.db.PolSourceObservationIssues
        //                                                             where c.ObservationInfo.StartsWith("10101,10201,105")
        //                                                             orderby c.PolSourceObservationIssueID
        //                                                             select c).Take(1000).ToList();

        //            if (polSourceList.Count == 0)
        //                break;

        //            foreach (PolSourceObservationIssue polSource in polSourceList)
        //            {
        //                polSource.ObservationInfo = polSource.ObservationInfo.Replace("10101,10201,105", "10101,10201,10301,10401,105");
        //            }

        //            try
        //            {
        //                tvItemService.db.SaveChanges();
        //            }
        //            catch (Exception)
        //            {
        //                int sleifj = 34;
        //            }

        //        }
        //        break;
        //    }
        //}
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Start_Good_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Error");
                sb.AppendLine("Pol_Source_Site_Counter");
                sb.AppendLine("Pol_Source_Site_ID");
                sb.AppendLine("Pol_Source_Site_Name");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering_Risk");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Sentence");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List");
                sb.AppendLine("Pol_Source_Site_Is_Active");
                sb.AppendLine("Pol_Source_Site_Name_Translation_Status");
                sb.AppendLine("Pol_Source_Site_Last_Update_Date_And_Time_UTC");
                sb.AppendLine("Pol_Source_Site_Last_Update_Contact_Name");
                sb.AppendLine("Pol_Source_Site_Last_Update_Contact_Initial");
                sb.AppendLine("Pol_Source_Site_Lat");
                sb.AppendLine("Pol_Source_Site_Lng");
                sb.AppendLine("Pol_Source_Site_Old_Site_Id");
                sb.AppendLine("Pol_Source_Site_Site_ID");
                sb.AppendLine("Pol_Source_Site_Site");
                sb.AppendLine("Pol_Source_Site_Is_Point_Source");
                sb.AppendLine("Pol_Source_Site_Inactive_Reason");
                sb.AppendLine("Pol_Source_Site_Civic_Address");
                sb.AppendLine("Pol_Source_Site_Google_Address");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 268925; // tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.AreEqual("", ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error);
                Assert.AreEqual(1, ReportPol_Source_SiteModelList[0].Pol_Source_Site_Counter);
                Assert.AreEqual(268925, ReportPol_Source_SiteModelList[0].Pol_Source_Site_ID);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Name.Length > 0);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Text.Length > 0);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level == null);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level == null);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Filtering_Risk == PolSourceIssueRiskEnum.Error);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal == null);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Filtering.Length == 0);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Sentence.Length > 0);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List.Length > 0);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Is_Active);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Name_Translation_Status);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Update_Contact_Name.Length);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Update_Contact_Initial.Length);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Lat);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Lng);
                //Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Old_Site_Id);
                //Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Site_ID);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Site);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Is_Point_Source);
                //Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Inactive_Reason);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Civic_Address);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Google_Address);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Start_Special_Good_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Error");
                sb.AppendLine("Pol_Source_Site_Counter");
                sb.AppendLine("Pol_Source_Site_ID");
                sb.AppendLine("Pol_Source_Site_Name");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level EQUAL 3");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level EQUAL 5");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering_Risk EQUAL ModerateRisk");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal TRUE");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering EQUAL SourceTypeLandForested*SourceTypeLandIndustry*SourceTypeLandMarine");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Sentence");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List");
                sb.AppendLine("Pol_Source_Site_Is_Active");
                sb.AppendLine("Pol_Source_Site_Name_Translation_Status");
                sb.AppendLine("Pol_Source_Site_Last_Update_Date_And_Time_UTC");
                sb.AppendLine("Pol_Source_Site_Last_Update_Contact_Name");
                sb.AppendLine("Pol_Source_Site_Last_Update_Contact_Initial");
                sb.AppendLine("Pol_Source_Site_Lat");
                sb.AppendLine("Pol_Source_Site_Lng");
                sb.AppendLine("Pol_Source_Site_Old_Site_Id");
                sb.AppendLine("Pol_Source_Site_Site_ID");
                sb.AppendLine("Pol_Source_Site_Site");
                sb.AppendLine("Pol_Source_Site_Is_Point_Source");
                sb.AppendLine("Pol_Source_Site_Inactive_Reason");
                sb.AppendLine("Pol_Source_Site_Civic_Address");
                sb.AppendLine("Pol_Source_Site_Google_Address");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 268925; // tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.AreEqual("", ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error);
                Assert.AreEqual(1, ReportPol_Source_SiteModelList[0].Pol_Source_Site_Counter);
                Assert.AreEqual(268925, ReportPol_Source_SiteModelList[0].Pol_Source_Site_ID);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Name.Length > 0);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Text.Length > 0);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level == 3);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level == 5);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Filtering_Risk == PolSourceIssueRiskEnum.ModerateRisk);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal == true);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Filtering.Length > 0);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Sentence.Length > 0);
                Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List.Length > 0);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Is_Active);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Name_Translation_Status);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Update_Contact_Name.Length);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Update_Contact_Initial.Length);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Lat);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Lng);
                //Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Old_Site_Id);
                //Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Site_ID);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Site);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Is_Point_Source);
                //Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Inactive_Reason);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Civic_Address);
                Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Google_Address);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Start_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Start_TVType_Not_Pol_Source_Site_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;

                List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMSite.ToString()), ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Start_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = tvItemModelPol_Source_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Pol_Source_Site";

                List<string> AllowableParentTagItemList = reportServicePol_Source_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error));
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Start_Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level_Required_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level EQUAL 3");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = tvItemModelPol_Source_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                //string TagItem = "Pol_Source_Site";

                List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level"), ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Start_Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level_Required_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level EQUAL 3");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = tvItemModelPol_Source_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                //string TagItem = "Pol_Source_Site";

                List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, "Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level"), ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Start_Text_Start_Level_Bigger_Text_End_Level_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level EQUAL 5");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level EQUAL 3");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = tvItemModelPol_Source_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                //string TagItem = "Pol_Source_Site";

                List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes._ShouldBeMoreThan_, "Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level", "Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level"), ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Start_Reverse_Equal_Issue_Filtering_Bigger_0_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal TRUE");
                sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = tvItemModelPol_Source_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                //string TagItem = "Pol_Source_Site";

                List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ToUse_YouNeed_NotToBeEmpty,
                        "Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal", "Pol_Source_Site_Last_Obs_Issue_Filtering"), 
                        ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                   tvItemModelSubsector, tvItemModelPol_Source_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_Error");
                    sb.AppendLine("Pol_Source_Site_Counter");
                    sb.AppendLine("Pol_Source_Site_ID");
                    sb.AppendLine("Pol_Source_Site_Name");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering_Risk");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Sentence");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List");
                    sb.AppendLine("Pol_Source_Site_Is_Active");
                    sb.AppendLine("Pol_Source_Site_Name_Translation_Status");
                    sb.AppendLine("Pol_Source_Site_Last_Update_Date_And_Time_UTC");
                    sb.AppendLine("Pol_Source_Site_Last_Update_Contact_Name");
                    sb.AppendLine("Pol_Source_Site_Last_Update_Contact_Initial");
                    sb.AppendLine("Pol_Source_Site_Lat");
                    sb.AppendLine("Pol_Source_Site_Lng");
                    sb.AppendLine("Pol_Source_Site_Old_Site_Id");
                    sb.AppendLine("Pol_Source_Site_Site_ID");
                    sb.AppendLine("Pol_Source_Site_Site");
                    sb.AppendLine("Pol_Source_Site_Is_Point_Source");
                    sb.AppendLine("Pol_Source_Site_Inactive_Reason");
                    sb.AppendLine("Pol_Source_Site_Civic_Address");
                    sb.AppendLine("Pol_Source_Site_Google_Address");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                    Assert.AreEqual("", ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error);
                    Assert.AreEqual(1, ReportPol_Source_SiteModelList[0].Pol_Source_Site_Counter);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_ID > 0);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Name.Length > 0);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Text.Length > 0);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level == null);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level == null);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Filtering_Risk == PolSourceIssueRiskEnum.Error);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal == null);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Filtering.Length == 0);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Sentence.Length > 0);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List.Length > 0);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Is_Active);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Name_Translation_Status);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Update_Date_And_Time_UTC);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Update_Contact_Name.Length);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Update_Contact_Initial.Length);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Lat);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Lng);
                    //Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Old_Site_Id);
                    //Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Site_ID);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Site);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Is_Point_Source);
                    //Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Inactive_Reason);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Civic_Address);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Google_Address);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Loop_Special_Good_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                   tvItemModelSubsector/*, tvItemModelPol_Source_Site*/ };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_Error");
                    sb.AppendLine("Pol_Source_Site_Counter");
                    sb.AppendLine("Pol_Source_Site_ID");
                    sb.AppendLine("Pol_Source_Site_Name");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level EQUAL 3");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level EQUAL 5");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering_Risk EQUAL ModerateRisk");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal TRUE");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Filtering EQUAL SourceTypeLandForested*SourceTypeLandIndustry*SourceTypeLandMarine");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Sentence");
                    sb.AppendLine("Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List");
                    sb.AppendLine("Pol_Source_Site_Is_Active");
                    sb.AppendLine("Pol_Source_Site_Name_Translation_Status");
                    sb.AppendLine("Pol_Source_Site_Last_Update_Date_And_Time_UTC");
                    sb.AppendLine("Pol_Source_Site_Last_Update_Contact_Name");
                    sb.AppendLine("Pol_Source_Site_Last_Update_Contact_Initial");
                    sb.AppendLine("Pol_Source_Site_Lat");
                    sb.AppendLine("Pol_Source_Site_Lng");
                    sb.AppendLine("Pol_Source_Site_Old_Site_Id");
                    sb.AppendLine("Pol_Source_Site_Site_ID");
                    sb.AppendLine("Pol_Source_Site_Site");
                    sb.AppendLine("Pol_Source_Site_Is_Point_Source");
                    sb.AppendLine("Pol_Source_Site_Inactive_Reason");
                    sb.AppendLine("Pol_Source_Site_Civic_Address");
                    sb.AppendLine("Pol_Source_Site_Google_Address");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                    Assert.AreEqual("", ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error);
                    Assert.AreEqual(1, ReportPol_Source_SiteModelList[0].Pol_Source_Site_Counter);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_ID > 0);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Name.Length > 0);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Text.Length > 0);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Text_Start_Level == 3);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Text_End_Level == 5);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Filtering_Risk == PolSourceIssueRiskEnum.ModerateRisk);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Filtering_Reverse_Equal == true);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Filtering.Length > 0);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Sentence.Length > 0);
                    Assert.IsTrue(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Obs_Issue_Item_Enum_ID_List.Length > 0);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Is_Active);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Name_Translation_Status);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Update_Date_And_Time_UTC);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Update_Contact_Name.Length);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Last_Update_Contact_Initial.Length);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Lat);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Lng);
                    //Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Old_Site_Id);
                    //Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Site_ID);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Site);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Is_Point_Source);
                    //Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Inactive_Reason);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Civic_Address);
                    Assert.IsNotNull(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Google_Address);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                   tvItemModelSubsector, tvItemModelPol_Source_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Pol_Source_Site";

                List<string> AllowableParentTagItemList = reportServicePol_Source_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_SiteModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = tvItemModelPol_Source_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Pol_Source_Site";

                List<string> AllowableParentTagItemList = reportServicePol_Source_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportPol_Source_SiteModel> ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportPol_Source_SiteModelList = reportServicePol_Source_Site.GetReportPol_Source_SiteModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_SiteModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportPol_Source_SiteModelList[0].Pol_Source_Site_Error));
            }
        }
        #endregion Testing Methods Pol_Source_Site
        #region Testing Methods Pol_Source_Site_Address
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                PolSourceSite polSourceSite = (from c in tvItemService.db.PolSourceSites
                                                 from a in tvItemService.db.Addresses
                                                 where c.CivicAddressTVItemID == a.AddressTVItemID
                                                 && c.CivicAddressTVItemID > 0
                                                 && a.GoogleAddressText != null
                                                 && a.GoogleAddressText.Length > 0
                                                 select c).FirstOrDefault();


                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetTVItemModelWithTVItemIDDB(polSourceSite.PolSourceSiteTVItemID);
                Assert.AreEqual("", tvItemModelPol_Source_Site.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelPol_Source_Site.ParentID);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Address_Error");
                sb.AppendLine("Pol_Source_Site_Address_Counter");
                sb.AppendLine("Pol_Source_Site_Address_ID");
                sb.AppendLine("Pol_Source_Site_Address_Type");
                sb.AppendLine("Pol_Source_Site_Address_Country");
                sb.AppendLine("Pol_Source_Site_Address_Province");
                sb.AppendLine("Pol_Source_Site_Address_Municipality");
                sb.AppendLine("Pol_Source_Site_Address_Street_Name");
                sb.AppendLine("Pol_Source_Site_Address_Street_Number");
                sb.AppendLine("Pol_Source_Site_Address_Street_Type");
                sb.AppendLine("Pol_Source_Site_Address_Postal_Code");
                sb.AppendLine("Pol_Source_Site_Address_Google_Address_Text");
                sb.AppendLine("Pol_Source_Site_Address_Last_Update_Date_And_Time");
                sb.AppendLine("Pol_Source_Site_Address_Last_Update_Contact_Name");
                sb.AppendLine("Pol_Source_Site_Address_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Pol_Source_Site_Address";

                List<ReportPol_Source_Site_AddressModel> ReportPol_Source_Site_AddressModelList = reportServicePol_Source_Site_Address.GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                PolSourceSite polSourceSite = (from c in tvItemService.db.PolSourceSites
                                                 from a in tvItemService.db.Addresses
                                                 where c.CivicAddressTVItemID == a.AddressTVItemID
                                                 && c.CivicAddressTVItemID > 0
                                                 && a.GoogleAddressText != null
                                                 && a.GoogleAddressText.Length > 0
                                                 select c).FirstOrDefault();


                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetTVItemModelWithTVItemIDDB(polSourceSite.PolSourceSiteTVItemID);
                Assert.AreEqual("", tvItemModelPol_Source_Site.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelPol_Source_Site.ParentID);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, */
                    tvItemModelMunicipality, tvItemModelPol_Source_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Pol_Source_Site_Address " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_Address_Error");
                    sb.AppendLine("Pol_Source_Site_Address_Counter");
                    sb.AppendLine("Pol_Source_Site_Address_ID");
                    sb.AppendLine("Pol_Source_Site_Address_Type");
                    sb.AppendLine("Pol_Source_Site_Address_Country");
                    sb.AppendLine("Pol_Source_Site_Address_Province");
                    sb.AppendLine("Pol_Source_Site_Address_Municipality");
                    sb.AppendLine("Pol_Source_Site_Address_Street_Name");
                    sb.AppendLine("Pol_Source_Site_Address_Street_Number");
                    sb.AppendLine("Pol_Source_Site_Address_Street_Type");
                    sb.AppendLine("Pol_Source_Site_Address_Postal_Code");
                    sb.AppendLine("Pol_Source_Site_Address_Google_Address_Text");
                    sb.AppendLine("Pol_Source_Site_Address_Last_Update_Date_And_Time");
                    sb.AppendLine("Pol_Source_Site_Address_Last_Update_Contact_Name");
                    sb.AppendLine("Pol_Source_Site_Address_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportPol_Source_Site_AddressModel> ReportPol_Source_Site_AddressModelList = reportServicePol_Source_Site_Address.GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_Site_AddressModelList.Count > 0);
                    Assert.AreEqual("", ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Error);
                    Assert.IsTrue(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Counter > 0);
                    Assert.IsTrue(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_ID > 0);
                    Assert.IsNotNull(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Type);
                    Assert.IsNotNull(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Country);
                    Assert.IsNotNull(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Province);
                    Assert.IsNotNull(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Municipality);
                    Assert.IsNotNull(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Street_Name);
                    Assert.IsNotNull(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Street_Number);
                    Assert.IsNotNull(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Street_Type);
                    Assert.IsNotNull(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Postal_Code);
                    Assert.IsNotNull(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Google_Address_Text);
                    Assert.IsNotNull(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Last_Update_Date_And_Time_UTC);
                    Assert.IsNotNull(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Last_Update_Contact_Initial);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                PolSourceSite polSourceSite = (from c in tvItemService.db.PolSourceSites
                                                 from a in tvItemService.db.Addresses
                                                 where c.CivicAddressTVItemID == a.AddressTVItemID
                                                 && c.CivicAddressTVItemID > 0
                                                 && a.GoogleAddressText != null
                                                 && a.GoogleAddressText.Length > 0
                                                 select c).FirstOrDefault();


                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetTVItemModelWithTVItemIDDB(polSourceSite.PolSourceSiteTVItemID);
                Assert.AreEqual("", tvItemModelPol_Source_Site.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelPol_Source_Site.ParentID);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, */
                    tvItemModelMunicipality, tvItemModelPol_Source_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Pol_Source_Site_Address " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_Address_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportPol_Source_Site_AddressModel> ReportPol_Source_Site_AddressModelList = reportServicePol_Source_Site_Address.GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_Site_AddressModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                PolSourceSite polSourceSite = (from c in tvItemService.db.PolSourceSites
                                                 from a in tvItemService.db.Addresses
                                                 where c.CivicAddressTVItemID == a.AddressTVItemID
                                                 && c.CivicAddressTVItemID > 0
                                                 && a.GoogleAddressText != null
                                                 && a.GoogleAddressText.Length > 0
                                                 select c).FirstOrDefault();


                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetTVItemModelWithTVItemIDDB(polSourceSite.PolSourceSiteTVItemID);
                Assert.AreEqual("", tvItemModelPol_Source_Site.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelPol_Source_Site.ParentID);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelInfrastructure = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelRoot.TVItemID, TVTypeEnum.Infrastructure).FirstOrDefault();
                Assert.IsNotNull(tvItemModelInfrastructure);


                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Address_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelInfrastructure.TVItemID;
                string ParentTagItem = "Infrastructure"; // will create error
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Pol_Source_Site_Address";

                List<string> AllowableParentTagItemList = reportServicePol_Source_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportPol_Source_Site_AddressModel> ReportPol_Source_Site_AddressModelList = reportServicePol_Source_Site_Address.GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_AddressModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                PolSourceSite polSourceSite = (from c in tvItemService.db.PolSourceSites
                                                 from a in tvItemService.db.Addresses
                                                 where c.CivicAddressTVItemID == a.AddressTVItemID
                                                 && c.CivicAddressTVItemID > 0
                                                 && a.GoogleAddressText != null
                                                 && a.GoogleAddressText.Length > 0
                                                 select c).FirstOrDefault();


                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetTVItemModelWithTVItemIDDB(polSourceSite.PolSourceSiteTVItemID);
                Assert.AreEqual("", tvItemModelPol_Source_Site.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModelPol_Source_Site.ParentID);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Address_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Pol_Source_Site_Address";

                List<string> AllowableParentTagItemList = reportServicePol_Source_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportPol_Source_Site_AddressModel> ReportPol_Source_Site_AddressModelList = reportServicePol_Source_Site_Address.GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_AddressModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Address_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportPol_Source_Site_AddressModelList = reportServicePol_Source_Site_Address.GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_AddressModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Address " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Address_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportPol_Source_Site_AddressModelList = reportServicePol_Source_Site_Address.GetReportPol_Source_Site_AddressModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_AddressModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportPol_Source_Site_AddressModelList[0].Pol_Source_Site_Address_Error));
            }
        }
        #endregion Testing Methods Pol_Source_Site_Address
        #region Testing Methods Pol_Source_Site_File
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_FileModelListUnderTVItemIDDB_Good_Test()
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

                List<TVItemModel> tvItemModelPolSourceSiteList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite);
                Assert.IsTrue(tvItemModelPolSourceSiteList.Count > 0);

                TVItemModel tvItemModelPolSourceSite = tvItemModelPolSourceSiteList.Where(c => c.TVItemID == 202466).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPolSourceSite);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelPolSourceSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Pol_Source_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_File_Error");
                    sb.AppendLine("Pol_Source_Site_File_Counter");
                    sb.AppendLine("Pol_Source_Site_File_ID");
                    sb.AppendLine("Pol_Source_Site_File_Language");
                    sb.AppendLine("Pol_Source_Site_File_File_Purpose");
                    sb.AppendLine("Pol_Source_Site_File_File_Type");
                    sb.AppendLine("Pol_Source_Site_File_File_Description");
                    sb.AppendLine("Pol_Source_Site_File_File_Size_kb");
                    sb.AppendLine("Pol_Source_Site_File_File_Info");
                    sb.AppendLine("Pol_Source_Site_File_File_Created_Date_UTC");
                    sb.AppendLine("Pol_Source_Site_File_From_Water");
                    sb.AppendLine("Pol_Source_Site_File_Server_File_Name");
                    sb.AppendLine("Pol_Source_Site_File_Server_File_Path");
                    sb.AppendLine("Pol_Source_Site_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Pol_Source_Site_File_Last_Update_Contact_Name");
                    sb.AppendLine("Pol_Source_Site_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "PolSourceSite" ? "Pol_Source_Site" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportPol_Source_Site_FileModel> ReportPol_Source_Site_FileModelList = reportServicePol_Source_Site_File.GetReportPol_Source_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList.Count > 0);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Error == "");
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Counter > 0);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_ID > 0);
                    Assert.IsTrue((int)ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Language > 0);
                    Assert.IsTrue((int)ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Purpose > 0);
                    Assert.IsTrue((int)ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Type > 0);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Description.Length > 0);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Size_kb > 0);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Info.Length > 0);
                    Assert.IsNotNull(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Created_Date_UTC);
                    //Assert.IsNotNull(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_From_Water);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Server_File_Name.Length > 0);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Server_File_Path.Length > 0);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Last_Update_Date_And_Time_UTC > new DateTime(1979, 1, 1));
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Last_Update_Contact_Name.Length > 0);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Last_Update_Contact_Initial.Length > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_FileModelListUnderTVItemIDDB_Good_CountOnly_Test()
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

                List<TVItemModel> tvItemModelPolSourceSiteList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite);
                Assert.IsTrue(tvItemModelPolSourceSiteList.Count > 0);

                TVItemModel tvItemModelPolSourceSite = tvItemModelPolSourceSiteList.Where(c => c.TVItemID == 202466).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPolSourceSite);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelPolSourceSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Pol_Source_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_File_Error");
                    sb.AppendLine("Pol_Source_Site_File_Counter");
                    sb.AppendLine("Pol_Source_Site_File_ID");
                    sb.AppendLine("Pol_Source_Site_File_Language");
                    sb.AppendLine("Pol_Source_Site_File_File_Purpose");
                    sb.AppendLine("Pol_Source_Site_File_File_Type");
                    sb.AppendLine("Pol_Source_Site_File_File_Description");
                    sb.AppendLine("Pol_Source_Site_File_File_Size_kb");
                    sb.AppendLine("Pol_Source_Site_File_File_Info");
                    sb.AppendLine("Pol_Source_Site_File_File_Created_Date_UTC");
                    sb.AppendLine("Pol_Source_Site_File_From_Water");
                    sb.AppendLine("Pol_Source_Site_File_Server_File_Name");
                    sb.AppendLine("Pol_Source_Site_File_Server_File_Path");
                    sb.AppendLine("Pol_Source_Site_File_Last_Update_Date_And_Time");
                    sb.AppendLine("Pol_Source_Site_File_Last_Update_Contact_Name");
                    sb.AppendLine("Pol_Source_Site_File_Last_Update_Contact_Initial");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "PolSourceSite" ? "Pol_Source_Site" : tvItemModel.TVType.ToString());
                    bool CountOnly = true;
                    int Take = 10;

                    List<ReportPol_Source_Site_FileModel> ReportPol_Source_Site_FileModelList = reportServicePol_Source_Site_File.GetReportPol_Source_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList.Count == 1);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Counter > 0);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_FileModelListUnderTVItemIDDB_Error_Start_Tag_Test()
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

                List<TVItemModel> tvItemModelPolSourceSiteList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite);
                Assert.IsTrue(tvItemModelPolSourceSiteList.Count > 0);

                TVItemModel tvItemModelPolSourceSite = tvItemModelPolSourceSiteList.Where(c => c.TVItemID == 202466).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPolSourceSite);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelPolSourceSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Start Pol_Source_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "PolSourceSite" ? "Pol_Source_Site" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Pol_Source_Site_File";

                    List<ReportPol_Source_Site_FileModel> ReportPol_Source_Site_FileModelList = reportServicePol_Source_Site_File.GetReportPol_Source_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_FileModelListUnderTVItemIDDB_Error_TVItem_Test()
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

                List<TVItemModel> tvItemModelPolSourceSiteList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite);
                Assert.IsTrue(tvItemModelPolSourceSiteList.Count > 0);

                TVItemModel tvItemModelPolSourceSite = tvItemModelPolSourceSiteList.Where(c => c.TVItemID == 202466).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPolSourceSite);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelPolSourceSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Pol_Source_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "PolSourceSite" ? "Pol_Source_Site" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportPol_Source_Site_FileModel> ReportPol_Source_Site_FileModelList = reportServicePol_Source_Site_File.GetReportPol_Source_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_FileModelListUnderTVItemIDDB_Error_ParentTagItem_Empty_Test()
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

                List<TVItemModel> tvItemModelPolSourceSiteList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite);
                Assert.IsTrue(tvItemModelPolSourceSiteList.Count > 0);

                TVItemModel tvItemModelPolSourceSite = tvItemModelPolSourceSiteList.Where(c => c.TVItemID == 202466).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPolSourceSite);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelPolSourceSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Pol_Source_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "";
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportPol_Source_Site_FileModel> ReportPol_Source_Site_FileModelList = reportServicePol_Source_Site_File.GetReportPol_Source_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList.Count > 0);
                    Assert.AreEqual(ServiceRes.ParentTagItemShouldNotBeEmpty, ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_FileModelListUnderTVItemIDDB_Error_Allowable_ParentTagItem_Test()
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

                List<TVItemModel> tvItemModelPolSourceSiteList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite);
                Assert.IsTrue(tvItemModelPolSourceSiteList.Count > 0);

                TVItemModel tvItemModelPolSourceSite = tvItemModelPolSourceSiteList.Where(c => c.TVItemID == 202466).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPolSourceSite);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelPolSourceSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Pol_Source_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_File_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = "Municipality";
                    bool CountOnly = false;
                    int Take = 10;
                    string TagItem = "Pol_Source_Site_File";

                    List<string> AllowableParentTagItemList = reportServicePol_Source_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                    List<ReportPol_Source_Site_FileModel> ReportPol_Source_Site_FileModelList = reportServicePol_Source_Site_File.GetReportPol_Source_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_FileModelListUnderTVItemIDDB_Error_GetReportTreeNodesFromTagText_Test()
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

                List<TVItemModel> tvItemModelPolSourceSiteList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite);
                Assert.IsTrue(tvItemModelPolSourceSiteList.Count > 0);

                TVItemModel tvItemModelPolSourceSite = tvItemModelPolSourceSiteList.Where(c => c.TVItemID == 202466).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPolSourceSite);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                    /*tvItemModelRoot, tvItemModelCountry, tvItemModelProvince, tvItemModelArea, tvItemModelSector, */
                    tvItemModelSubsector, tvItemModelPolSourceSite };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Pol_Source_Site_File " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_File_IDNot"); // line 2
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = tvItemModel.TVItemID;
                    string ParentTagItem = (tvItemModel.TVType.ToString() == "PolSourceSite" ? "Pol_Source_Site" : tvItemModel.TVType.ToString());
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportPol_Source_Site_FileModel> ReportPol_Source_Site_FileModelList = reportServicePol_Source_Site_File.GetReportPol_Source_Site_FileModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_Site_FileModelList.Count > 0);
                    Assert.AreEqual(string.Format(ReportServiceRes._DoesNotExistFor_, "Pol_Source_Site_File_IDNot", "CSSPModelsDLL.Models.ReportPol_Source_Site_FileModel"), ReportPol_Source_Site_FileModelList[0].Pol_Source_Site_File_Error);
                }
            }
        }
        #endregion Testing Methods Pol_Source_Site_File
        #region Testing Methods Pol_Source_Site_Obs
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site_Obs " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 268925;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Pol_Source_Site_Obs";

                List<ReportPol_Source_Site_ObsModel> ReportPol_Source_Site_ObsModelList = reportServicePol_Source_Site_Obs.GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_ObsModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Obs " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_Error");
                sb.AppendLine("Pol_Source_Site_Obs_Counter");
                sb.AppendLine("Pol_Source_Site_Obs_ID");
                sb.AppendLine("Pol_Source_Site_Obs_Only_Last");
                sb.AppendLine("Pol_Source_Site_Obs_Inspector_Name");
                sb.AppendLine("Pol_Source_Site_Obs_Inspector_Initial");
                sb.AppendLine("Pol_Source_Site_Obs_Observation_Date_Local");
                sb.AppendLine("Pol_Source_Site_Obs_Observation_To_Be_Deleted");
                sb.AppendLine("Pol_Source_Site_Obs_Last_Update_Date_And_Time");
                sb.AppendLine("Pol_Source_Site_Obs_Last_Update_Contact_Name");
                sb.AppendLine("Pol_Source_Site_Obs_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = tvItemModelPol_Source_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportPol_Source_Site_ObsModel> ReportPol_Source_Site_ObsModelList = reportServicePol_Source_Site_Obs.GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_ObsModelList.Count > 0);
                Assert.AreEqual("", ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Error);
                Assert.AreEqual(1, ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Counter);
                Assert.IsTrue(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_ID > 0);
                //Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Inspector_Name);
                //Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Inspector_Initial);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Observation_Date_Local);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Observation_To_Be_Deleted);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB_Loop_Good_Only_Last_TRUE_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Obs " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_Error");
                sb.AppendLine("Pol_Source_Site_Obs_Counter");
                sb.AppendLine("Pol_Source_Site_Obs_ID");
                sb.AppendLine("Pol_Source_Site_Obs_Only_Last TRUE");
                sb.AppendLine("Pol_Source_Site_Obs_Inspector_Name");
                sb.AppendLine("Pol_Source_Site_Obs_Inspector_Initial");
                sb.AppendLine("Pol_Source_Site_Obs_Observation_Date_Local");
                sb.AppendLine("Pol_Source_Site_Obs_Observation_To_Be_Deleted");
                sb.AppendLine("Pol_Source_Site_Obs_Last_Update_Date_And_Time");
                sb.AppendLine("Pol_Source_Site_Obs_Last_Update_Contact_Name");
                sb.AppendLine("Pol_Source_Site_Obs_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = tvItemModelPol_Source_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportPol_Source_Site_ObsModel> ReportPol_Source_Site_ObsModelList = reportServicePol_Source_Site_Obs.GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_ObsModelList.Count == 1);
                Assert.AreEqual("", ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Error);
                Assert.AreEqual(1, ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Counter);
                Assert.IsTrue(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_ID > 0);
                //Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Inspector_Name);
                //Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Inspector_Initial);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Observation_Date_Local);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Observation_To_Be_Deleted);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB_Loop_Good_Only_Last_FALSE_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Obs " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_Error");
                sb.AppendLine("Pol_Source_Site_Obs_Counter");
                sb.AppendLine("Pol_Source_Site_Obs_ID");
                sb.AppendLine("Pol_Source_Site_Obs_Only_Last FALSE");
                sb.AppendLine("Pol_Source_Site_Obs_Inspector_Name");
                sb.AppendLine("Pol_Source_Site_Obs_Inspector_Initial");
                sb.AppendLine("Pol_Source_Site_Obs_Observation_Date_Local");
                sb.AppendLine("Pol_Source_Site_Obs_Observation_To_Be_Deleted");
                sb.AppendLine("Pol_Source_Site_Obs_Last_Update_Date_And_Time");
                sb.AppendLine("Pol_Source_Site_Obs_Last_Update_Contact_Name");
                sb.AppendLine("Pol_Source_Site_Obs_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 202008; // tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = tvItemModelPol_Source_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;

                List<ReportPol_Source_Site_ObsModel> ReportPol_Source_Site_ObsModelList = reportServicePol_Source_Site_Obs.GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_ObsModelList.Count > 1);
                Assert.AreEqual("", ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Error);
                Assert.AreEqual(1, ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Counter);
                Assert.IsTrue(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_ID > 0);
                //Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Inspector_Name);
                //Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Inspector_Initial);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Observation_Date_Local);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Observation_To_Be_Deleted);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                List<TVItemModel> testTVItemModelList = new List<TVItemModel>() {
                   tvItemModelSubsector, tvItemModelPol_Source_Site };

                foreach (TVItemModel tvItemModel in testTVItemModelList)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("|||Loop Pol_Source_Site_Obs " + culture.TwoLetterISOLanguageName);
                    sb.AppendLine("Pol_Source_Site_Obs_ID");
                    sb.AppendLine("|||");

                    LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                    string TagText = sb.ToString();
                    int UnderTVItemID = 0;
                    string ParentTagItem = tvItemModel.TVType.ToString();
                    bool CountOnly = false;
                    int Take = 10;

                    List<ReportPol_Source_Site_ObsModel> ReportPol_Source_Site_ObsModelList = reportServicePol_Source_Site_Obs.GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                    Assert.IsTrue(ReportPol_Source_Site_ObsModelList.Count > 0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()), ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Error);
                }
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Obs " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelMunicipality.TVItemID;
                string ParentTagItem = tvItemModelMunicipality.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Pol_Source_Site_Obs";

                List<string> AllowableParentTagItemList = reportServicePol_Source_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportPol_Source_Site_ObsModel> ReportPol_Source_Site_ObsModelList = reportServicePol_Source_Site_Obs.GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_ObsModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)), ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Obs " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelPol_Source_Site.TVItemID;
                string ParentTagItem = tvItemModelPol_Source_Site.TVType.ToString();
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Pol_Source_Site_Obs";

                List<string> AllowableParentTagItemList = reportServicePol_Source_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportPol_Source_Site_ObsModel> ReportPol_Source_Site_ObsModelList = reportServicePol_Source_Site_Obs.GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_ObsModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Obs " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportPol_Source_Site_ObsModelList = reportServicePol_Source_Site_Obs.GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_ObsModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Obs " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportPol_Source_Site_ObsModelList = reportServicePol_Source_Site_Obs.GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_ObsModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportPol_Source_Site_ObsModelList[0].Pol_Source_Site_Obs_Error));
            }
        }
        #endregion Testing Methods Pol_Source_Site_Obs
        #region Testing Methods Pol_Source_Site_Obs_Issue
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start Pol_Source_Site_Obs_Issue " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_Issue_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 76208;
                string ParentTagItem = "";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Pol_Source_Site_Obs_Issue";

                List<ReportPol_Source_Site_Obs_IssueModel> ReportPol_Source_Site_Obs_IssueModelList = reportServicePol_Source_Site_Obs_Issue.GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB_Loop_Good_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                PolSourceObservationModel polSourceObservationModel = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(76208);
                Assert.AreEqual("", polSourceObservationModel.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||LoopStart Pol_Source_Site_Obs_Issue " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Error");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Counter");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_ID");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Items_Text");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Items_Text_Start_Level");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Items_Text_End_Level");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Enum_ID_List");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Risk");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Filtering");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Sentence");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Sentence_Reverse_Equal");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = polSourceObservationModel.PolSourceObservationID;
                string ParentTagItem = "Pol_Source_Site_Obs";
                bool CountOnly = false;
                int Take = 10;

                List<ReportPol_Source_Site_Obs_IssueModel> ReportPol_Source_Site_Obs_IssueModelList = reportServicePol_Source_Site_Obs_Issue.GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList.Count > 0);
                Assert.AreEqual("", ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Error);
                Assert.AreEqual(1, ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Counter);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_ID > 0);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Items_Text.Length > 0);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Items_Text_Start_Level == 0);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Items_Text_End_Level == 1000);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Enum_ID_List.Length > 0);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Risk == PolSourceIssueRiskEnum.Error);
                Assert.IsNotNull(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Filtering);
                Assert.IsNotNull(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Sentence);
                Assert.IsNotNull(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Sentence_Reverse_Equal);
                Assert.IsNotNull(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB_Loop_Special_Good_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true && c.TVText.Contains("00023")).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                PolSourceObservationModel polSourceObservationModel = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(91245);
                Assert.AreEqual("", polSourceObservationModel.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||LoopStart Pol_Source_Site_Obs_Issue " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Error");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Counter");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_ID");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Items_Text");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Items_Text_Start_Level EQUAL 3");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Items_Text_End_Level EQUAL 4");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Enum_ID_List");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Risk EQUAL ModerateRisk");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Filtering EQUAL AgricultureBuilding");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Sentence");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Sentence_Reverse_Equal TRUE");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name");
                sb.AppendLine("Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = polSourceObservationModel.PolSourceObservationID;
                string ParentTagItem = "Pol_Source_Site_Obs";
                bool CountOnly = false;
                int Take = 10;

                List<ReportPol_Source_Site_Obs_IssueModel> ReportPol_Source_Site_Obs_IssueModelList = reportServicePol_Source_Site_Obs_Issue.GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList.Count > 0);
                Assert.AreEqual("", ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Error);
                Assert.AreEqual(1, ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Counter);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_ID > 0);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Items_Text.Length > 0);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Items_Text_Start_Level == 0);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Items_Text_End_Level == 1000);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Enum_ID_List.Length > 0);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Risk == PolSourceIssueRiskEnum.Error);
                Assert.IsNotNull(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Filtering);
                Assert.IsNotNull(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Sentence);
                Assert.IsNotNull(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Sentence_Reverse_Equal);
                Assert.IsNotNull(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB_Loop_TVItem_Null_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                PolSourceObservationModel polSourceObservationModel = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(76208);
                Assert.AreEqual("", polSourceObservationModel.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Obs_Issue " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_Issue_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Pol_Source_Site_Obs";
                bool CountOnly = false;
                int Take = 10;

                List<ReportPol_Source_Site_Obs_IssueModel> ReportPol_Source_Site_Obs_IssueModelList = reportServicePol_Source_Site_Obs_Issue.GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservation, ServiceRes.PolSourceObservationID, UnderTVItemID.ToString()), ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB_Loop_AllowableParentTag_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                PolSourceObservationModel polSourceObservationModel = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(76208);
                Assert.AreEqual("", polSourceObservationModel.Error);

                TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelMunicipality.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Obs_Issue " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_Issue_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = polSourceObservationModel.PolSourceObservationID;
                string ParentTagItem = "Pol_Source_Site_ObsNot";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Pol_Source_Site_Obs_Issue";

                List<string> AllowableParentTagItemList = reportServicePol_Source_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportPol_Source_Site_Obs_IssueModel> ReportPol_Source_Site_Obs_IssueModelList = reportServicePol_Source_Site_Obs_Issue.GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Pol_Source_Site_Obs", ParentTagItem), ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB_Loop_GetReportTreeNodesFromTagText_Error_Test()
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

                TVItemModel tvItemModelPol_Source_Site = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).Where(c => c.IsActive == true).FirstOrDefault();
                Assert.IsNotNull(tvItemModelPol_Source_Site);

                PolSourceObservationModel polSourceObservationModel = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(76208);
                Assert.AreEqual("", polSourceObservationModel.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Obs_Issue " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_Issue_ID not");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = polSourceObservationModel.PolSourceObservationID;
                string ParentTagItem = "Pol_Source_Site_Obs";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "Pol_Source_Site_Obs_Issue";

                List<string> AllowableParentTagItemList = reportServicePol_Source_Site._ReportBaseService.GetAllowableParentTagItem(TagItem);

                List<ReportPol_Source_Site_Obs_IssueModel> ReportPol_Source_Site_Obs_IssueModelList = reportServicePol_Source_Site_Obs_Issue.GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Obs_Issue " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_Issue_IDNot");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportPol_Source_Site_Obs_IssueModelList = reportServicePol_Source_Site_Obs_Issue.GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Error));

                sb = new StringBuilder();
                sb.AppendLine("|||Loop Pol_Source_Site_Obs_Issue " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("Pol_Source_Site_Obs_Issue_ID");
                sb.AppendLine("|||");

                TagText = sb.ToString();

                ReportPol_Source_Site_Obs_IssueModelList = reportServicePol_Source_Site_Obs_Issue.GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportPol_Source_Site_Obs_IssueModelList.Count > 0);
                Assert.IsTrue(string.IsNullOrWhiteSpace(ReportPol_Source_Site_Obs_IssueModelList[0].Pol_Source_Site_Obs_Issue_Error));
            }
        }
        #endregion Testing Methods Pol_Source_Site_Obs_Issue
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
            reportServicePol_Source_Site = new ReportServicePol_Source_Site((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServicePol_Source_Site_Address = new ReportServicePol_Source_Site_Address((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServicePol_Source_Site_File = new ReportServicePol_Source_Site_File((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServicePol_Source_Site_Obs = new ReportServicePol_Source_Site_Obs((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            reportServicePol_Source_Site_Obs_Issue = new ReportServicePol_Source_Site_Obs_Issue((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServicePol_Source_Site);
        }
        #endregion Functions private
    }
}

