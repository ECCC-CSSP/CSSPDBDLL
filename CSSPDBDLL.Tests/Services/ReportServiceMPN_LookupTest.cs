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
    public class ReportServiceMPN_LookupTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
        private IPrincipal user { get; set; }
        private ContactModel contactModel { get; set; }

        private ReportServiceMPN_Lookup reportServiceMPN_Lookup { get; set; }
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
        public ReportServiceMPN_LookupTest()
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
        #region Testing Methods MPN_Lookup
        [TestMethod]
        public void ReportService_GetReportMPN_LookupModelListUnderTVItemIDDB_Start_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Start MPN_Lookup " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MPN_Lookup_ID");
                sb.AppendLine("|||");

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelRoot.TVItemID;
                string ParentTagItem = "Root";
                bool CountOnly = false;
                int Take = 10;
                string TagItem = "MPN_Lookup";

                List<ReportMPN_LookupModel> ReportMPN_LookupModelList = reportServiceMPN_Lookup.GetReportMPN_LookupModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMPN_LookupModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "..."), ReportMPN_LookupModelList[0].MPN_Lookup_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMPN_LookupModelListUnderTVItemIDDB_Loop_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MPN_Lookup " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MPN_Lookup_Error");
                sb.AppendLine("MPN_Lookup_Counter");
                sb.AppendLine("MPN_Lookup_ID");
                sb.AppendLine("MPN_Lookup_Tubes_10");
                sb.AppendLine("MPN_Lookup_Tubes_1_0");
                sb.AppendLine("MPN_Lookup_Tubes_0_1");
                sb.AppendLine("MPN_Lookup_MPN_100_ml");
                sb.AppendLine("MPN_Lookup_Last_Update_Date_And_Time");
                sb.AppendLine("MPN_Lookup_Last_Update_Contact_Name");
                sb.AppendLine("MPN_Lookup_Last_Update_Contact_Initial");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = tvItemModelRoot.TVItemID;
                string ParentTagItem = "Root";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMPN_LookupModel> ReportMPN_LookupModelList = reportServiceMPN_Lookup.GetReportMPN_LookupModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMPN_LookupModelList.Count > 0);
                Assert.AreEqual("", ReportMPN_LookupModelList[0].MPN_Lookup_Error);
                Assert.AreEqual(1, ReportMPN_LookupModelList[0].MPN_Lookup_Counter);
                Assert.IsTrue(ReportMPN_LookupModelList[0].MPN_Lookup_ID > 0);
                Assert.IsNotNull(ReportMPN_LookupModelList[0].MPN_Lookup_Tubes_10);
                Assert.IsNotNull(ReportMPN_LookupModelList[0].MPN_Lookup_Tubes_1_0);
                Assert.IsNotNull(ReportMPN_LookupModelList[0].MPN_Lookup_Tubes_0_1);
                Assert.IsNotNull(ReportMPN_LookupModelList[0].MPN_Lookup_MPN_100_ml);
                Assert.IsNotNull(ReportMPN_LookupModelList[0].MPN_Lookup_Last_Update_Date_And_Time_UTC);
                Assert.IsNotNull(ReportMPN_LookupModelList[0].MPN_Lookup_Last_Update_Contact_Name);
                Assert.IsNotNull(ReportMPN_LookupModelList[0].MPN_Lookup_Last_Update_Contact_Initial);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMPN_LookupModelListUnderTVItemIDDB_Loop_Error_TVItem_Null_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MPN_Lookup " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MPN_Lookup_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 0;
                string ParentTagItem = "Root";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMPN_LookupModel> ReportMPN_LookupModelList = reportServiceMPN_Lookup.GetReportMPN_LookupModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMPN_LookupModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Root.ToString()), ReportMPN_LookupModelList[0].MPN_Lookup_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMPN_LookupModelListUnderTVItemIDDB_Loop_Error_UnderTVItemID_Not_Equal_Root_TVItemID_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MPN_Lookup " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MPN_Lookup_ID");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "Root";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMPN_LookupModel> ReportMPN_LookupModelList = reportServiceMPN_Lookup.GetReportMPN_LookupModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMPN_LookupModelList.Count > 0);
                Assert.AreEqual(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Root.ToString()), ReportMPN_LookupModelList[0].MPN_Lookup_Error);
            }
        }
        [TestMethod]
        public void ReportService_GetReportMPN_LookupModelListUnderTVItemIDDB_Loop_Error_GetReportTreeNodesFromTagText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("|||Loop MPN_Lookup " + culture.TwoLetterISOLanguageName);
                sb.AppendLine("MPN_Lookup_IDNot");
                sb.AppendLine("|||");

                LanguageEnum Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en);
                string TagText = sb.ToString();
                int UnderTVItemID = 5;
                string ParentTagItem = "Root";
                bool CountOnly = false;
                int Take = 10;

                List<ReportMPN_LookupModel> ReportMPN_LookupModelList = reportServiceMPN_Lookup.GetReportMPN_LookupModelListUnderTVItemIDDB(Language, TagText, UnderTVItemID, ParentTagItem, CountOnly, Take);
                Assert.IsTrue(ReportMPN_LookupModelList.Count > 0);
                Assert.IsFalse(string.IsNullOrWhiteSpace(ReportMPN_LookupModelList[0].MPN_Lookup_Error));
            }
        }
        #endregion Testing Methods MPN_Lookup
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
            reportServiceMPN_Lookup = new ReportServiceMPN_Lookup((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
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
            shimReportService = new ShimReportService(reportServiceMPN_Lookup);
        }
        #endregion Functions private
    }
}

