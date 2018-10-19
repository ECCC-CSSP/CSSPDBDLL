using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPWebToolsDBDLL.Tests.SetupInfo;
using CSSPWebToolsDBDLL.Models;
using System.Security.Principal;
using CSSPWebToolsDBDLL.Services;
using CSSPWebToolsDBDLL.Services.Resources;
using System.Linq;
using System.Transactions;
using CSSPWebToolsDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Globalization;
using System.Threading;
using System.IO;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for LabSheetServiceTest
    /// </summary>
    [TestClass]
    public class LabSheetServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "LabSheet";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private LabSheetService labSheetService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private TVItemService tvItemService { get; set; }
        private LabSheetModel labSheetModelNew { get; set; }
        private LabSheet labSheet { get; set; }
        private AppTaskService appTaskService { get; set; }
        private TVFileService tvFileService { get; set; }
        private ShimLabSheetService shimLabSheetService { get; set; }
        private ShimMWQMPlanService shimMWQMPlanService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVFileService shimTVFileService { get; set; }
        private ShimAppTaskService shimAppTaskService { get; set; }
        private ShimMWQMRunService shimMWQMRunService { get; set; }
        private ShimMWQMSiteService shimMWQMSiteService { get; set; }
        private ShimMWQMSampleService shimMWQMSampleService { get; set; }
        private ShimContactService shimContactService { get; set; }
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
        public LabSheetServiceTest()
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
        [TestMethod]
        public void LabSheetService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Assert.IsNotNull(labSheetService);
                Assert.IsNotNull(labSheetService.db);
                Assert.IsNotNull(labSheetService.LanguageRequest);
                Assert.IsNotNull(labSheetService.User);
                Assert.AreEqual(user.Identity.Name, labSheetService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), labSheetService.LanguageRequest);
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                         select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    #region Good
                    labSheetModelNew.OtherServerLabSheetID = labSheet.OtherServerLabSheetID ;
                    labSheetModelNew.MWQMPlanID = labSheet.MWQMPlanID;
                    labSheetModelNew.SubsectorTVItemID = labSheet.SubsectorTVItemID;
                    labSheetModelNew.MWQMRunTVItemID = labSheet.MWQMRunTVItemID ?? randomService.RandomTVItem(TVTypeEnum.MWQMRun).TVItemID;
                    FillLabSheetModel(labSheetModelNew);

                    string retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region OtherServerLabSheetID
                    labSheetModelNew.OtherServerLabSheetID = labSheet.OtherServerLabSheetID;
                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.OtherServerLabSheetID = 0;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.OtherServerLabSheetID), retStr);

                    labSheetModelNew.OtherServerLabSheetID = labSheet.OtherServerLabSheetID;
                    FillLabSheetModel(labSheetModelNew);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion OtherServerLabSheetID

                    #region MWQMPlanID
                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.MWQMPlanID = 0;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMPlanID), retStr);

                    labSheetModelNew.MWQMPlanID = labSheet.MWQMPlanID;
                    FillLabSheetModel(labSheetModelNew);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMPlanID

                    #region ConfigFileName
                    int Min = 6;
                    int Max = 250;

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.ConfigFileName = randomService.RandomString("", Min - 1);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.ConfigFileName, Min), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.ConfigFileName = randomService.RandomString("", Max + 1);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ConfigFileName, Max), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.ConfigFileName = randomService.RandomString("", Min);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.ConfigFileName = randomService.RandomString("", Max);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.ConfigFileName = randomService.RandomString("", Max - 1);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ConfigFileName

                    #region Year
                    Min = 2000;
                    Max = 2050;

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Year = Min - 1;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Year, Min, Max), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Year = Max + 1;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Year, Min, Max), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Year = Min;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Year = Max;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Year = Max - 1;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Year

                    #region Month
                    Min = 1;
                    Max = 12;

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Month = Min - 1;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Month, Min, Max), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Month = Max + 1;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Month, Min, Max), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Month = Min;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Month = Max;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Month = Max - 1;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Month

                    #region Day
                    Min = 1;
                    Max = 31;

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Day = Min - 1;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Day, Min, Max), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Day = Max + 1;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Day, Min, Max), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Day = Min;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Day = Max;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.Day = Max - 1;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Day

                    #region SubsectorTVItemID
                    labSheetModelNew.SubsectorTVItemID = labSheet.SubsectorTVItemID;
                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.SubsectorTVItemID = 0;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID), retStr);

                    labSheetModelNew.SubsectorTVItemID = labSheet.SubsectorTVItemID;
                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.SubsectorTVItemID = 1;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SubsectorTVItemID

                    #region MWQMRunTVItemID
                    labSheetModelNew.MWQMRunTVItemID = randomService.RandomTVItem(TVTypeEnum.MWQMRun).TVItemID;
                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.MWQMRunTVItemID = 0;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMRunTVItemID), retStr);

                    labSheetModelNew.MWQMRunTVItemID = randomService.RandomTVItem(TVTypeEnum.MWQMRun).TVItemID;
                    FillLabSheetModel(labSheetModelNew);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMRunTVItemID

                    #region ConfigType
                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.ConfigType = (ConfigTypeEnum)10000;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ConfigType), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.ConfigType = ConfigTypeEnum.Subsector;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ConfigType

                    #region SampleType
                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.SampleType = (SampleTypeEnum)10000;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SampleType), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.SampleType = SampleTypeEnum.Routine;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SampleType

                    #region LabSheetType
                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.LabSheetType = (LabSheetTypeEnum)10000;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LabSheetType), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.LabSheetType = LabSheetTypeEnum.A1;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion LabSheetType

                    #region LabSheetStatus
                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.LabSheetStatus = (LabSheetStatusEnum)10000;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LabSheetStatus), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.LabSheetStatus = LabSheetStatusEnum.Transferred;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion LabSheetStatus

                    #region FileName
                    Min = 10;
                    Max = 250;

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.FileName = randomService.RandomString("", Min - 1);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.FileName, Min), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.FileName = randomService.RandomString("", Max + 1);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.FileName, Max), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.FileName = randomService.RandomString("", Min);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.FileName = randomService.RandomString("", Max);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.FileName = randomService.RandomString("", Max - 1);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion FileName

                    #region FileLastModifiedDate_Local
                    FillLabSheetModel(labSheetModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion FileLastModifiedDate_Local

                    #region FileContent
                    Min = 100;
                    Max = 100000;

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.FileContent = randomService.RandomString("", Min - 1);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.FileContent, Min), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.FileContent = randomService.RandomString("", Max + 1);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.FileContent, Max), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.FileContent = randomService.RandomString("", Min);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.FileContent = randomService.RandomString("", Max);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.FileContent = randomService.RandomString("", Max - 1);

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion FileContent

                    #region ApprovedOrRejectedByContactTVItemID
                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.ApprovedOrRejectedByContactTVItemID = 0;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ApprovedOrRejectedByContactTVItemID), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.ApprovedOrRejectedByContactTVItemID = randomService.RandomTVItem(TVTypeEnum.Contact).TVItemID;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ApprovedOrRejectedByContactTVItemID

                    #region ApprovedOrRejectedDateTime
                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.ApprovedOrRejectedDateTime = null;

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ApprovedOrRejectedDateTime), retStr);

                    FillLabSheetModel(labSheetModelNew);
                    labSheetModelNew.ApprovedOrRejectedDateTime = randomService.RandomDateTime();

                    retStr = labSheetService.LabSheetModelOK(labSheetModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ApprovedOrRejectedDateTime
                }
            }
        }
        [TestMethod]
        public void LabSheetService_FillLabSheet_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModel = AddLabSheetModel();
                    Assert.AreEqual("", labSheetModel.Error);

                    FillLabSheetModel(labSheetModel);

                    ContactOK contactOK = labSheetService.IsContactOK();

                    string retStr = labSheetService.FillLabSheet(labSheet, labSheetModel, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, labSheet.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = labSheetService.FillLabSheet(labSheet, labSheetModel, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, labSheet.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_GetLabSheetModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModel = AddLabSheetModel();
                    Assert.AreEqual("", labSheetModel.Error);

                    int labSheetCount = labSheetService.GetLabSheetModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, labSheetCount);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_GetLabSheetModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();
                    Assert.AreEqual("", labSheetModelRet.Error);

                    LabSheetModel labSheetModelRet2 = labSheetService.GetLabSheetModelExistDB(labSheetModelRet);
                    Assert.AreEqual(labSheetModelRet.LabSheetID, labSheetModelRet2.LabSheetID);

                    labSheetModelRet.SubsectorTVItemID = 0;
                    labSheetModelRet2 = labSheetService.GetLabSheetModelExistDB(labSheetModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.LabSheet,
                    ServiceRes.ConfigFileName + "," +
                    ServiceRes.Year + "," +
                    ServiceRes.Month + "," +
                    ServiceRes.Day + "," +
                    ServiceRes.ConfigType + "," +
                    ServiceRes.SampleType + "," +
                    ServiceRes.LabSheetType + "," +
                    ServiceRes.SecretCode + "," +
                    ServiceRes.SampleDate_Local + "," +
                    ServiceRes.SubsectorTVItemID,
                    labSheetModelRet.ConfigFileName + "," +
                    labSheetModelRet.Year.ToString() + "," +
                    labSheetModelRet.Month.ToString() + "," +
                    labSheetModelRet.Day.ToString() + "," +
                    labSheetModelRet.ConfigType.ToString() + "," +
                    labSheetModelRet.SampleType.ToString() + "," +
                    labSheetModelRet.LabSheetType.ToString() + "," +
                    labSheetModelRet.SubsectorTVItemID.ToString()), labSheetModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_GetLabSheetModelListWithMWQMRunTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModel = AddLabSheetModel();
                    Assert.AreEqual("", labSheetModel.Error);

                    List<LabSheetModel> labSheetModelList = labSheetService.GetLabSheetModelListWithMWQMRunTVItemIDDB((int)labSheetModel.MWQMRunTVItemID);
                    Assert.IsTrue(labSheetModelList.Where(c => c.LabSheetID == labSheetModel.LabSheetID).Any());

                    int MWQMRunTVItemID = 0;
                    labSheetModelList = labSheetService.GetLabSheetModelListWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
                    Assert.AreEqual(0, labSheetModelList.Count);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_GetLabSheetModelListWithSubsectorTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModel = AddLabSheetModel();
                    Assert.AreEqual("", labSheetModel.Error);

                    List<LabSheetModel> labSheetModelList = labSheetService.GetLabSheetModelListWithSubsectorTVItemIDDB(labSheetModel.SubsectorTVItemID);
                    Assert.IsTrue(labSheetModelList.Where(c => c.LabSheetID == labSheetModel.LabSheetID).Any());

                    int SubsectorTVItemID = 0;
                    labSheetModelList = labSheetService.GetLabSheetModelListWithSubsectorTVItemIDDB(SubsectorTVItemID);
                    Assert.AreEqual(0, labSheetModelList.Count);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_GetLabSheetModelListWithMWQMPlanIDAndLabSheetStatusDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModel = AddLabSheetModel();
                    Assert.AreEqual("", labSheetModel.Error);

                    List<LabSheetModel> labSheetModelList = labSheetService.GetLabSheetModelListWithMWQMPlanIDAndLabSheetStatusDB(labSheetModel.MWQMPlanID, labSheetModel.LabSheetStatus);
                    Assert.IsTrue(labSheetModelList.Where(c => c.LabSheetID == labSheetModel.LabSheetID).Any());

                    int MWQMPlanID = 0;
                    labSheetModelList = labSheetService.GetLabSheetModelListWithMWQMPlanIDAndLabSheetStatusDB(MWQMPlanID, labSheetModel.LabSheetStatus);
                    Assert.AreEqual(0, labSheetModelList.Count);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_GetLabSheetModelWithLabSheetIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();
                    Assert.AreEqual("", labSheetModelRet.Error);

                    LabSheetModel labSheetModelRet2 = labSheetService.GetLabSheetModelWithLabSheetIDDB(labSheetModelRet.LabSheetID);
                    Assert.AreEqual(labSheetModelRet.LabSheetID, labSheetModelRet2.LabSheetID);

                    int LabSheetID = 0;
                    labSheetModelRet2 = labSheetService.GetLabSheetModelWithLabSheetIDDB(LabSheetID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheet, ServiceRes.LabSheetID, LabSheetID), labSheetModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_GetLabSheetWithLabSheetIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();
                    Assert.AreEqual("", labSheetModelRet.Error);

                    LabSheet labSheetRet = labSheetService.GetLabSheetWithLabSheetIDDB(labSheetModelRet.LabSheetID);
                    Assert.AreEqual(labSheetModelRet.LabSheetID, labSheetRet.LabSheetID);

                    int LabSheetID = 0;
                    LabSheet labSheetRet2 = labSheetService.GetLabSheetWithLabSheetIDDB(LabSheetID);
                    Assert.IsNull(labSheetRet2);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_GetLabSheetCountWithMWQMPlanIDAndLabSheetStatusDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();
                    Assert.AreEqual("", labSheetModelRet.Error);

                    int count = labSheetService.GetLabSheetCountWithMWQMPlanIDAndLabSheetStatusDB(labSheetModelRet.MWQMPlanID, (LabSheetStatusEnum)labSheetModelRet.LabSheetStatus);
                    Assert.IsTrue(count > 0);

                    int MWQMPlanID = 0;
                    count = labSheetService.GetLabSheetCountWithMWQMPlanIDAndLabSheetStatusDB(MWQMPlanID, (LabSheetStatusEnum)labSheetModelRet.LabSheetStatus);
                    Assert.IsTrue(count == 0);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_GetValueWithinBracket_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string retStr = labSheetService.GetValueWithinBracket("selifj\r\n");
                Assert.AreEqual("", retStr);

                retStr = labSheetService.GetValueWithinBracket("|||||[allo]|||||\r\n");
                Assert.AreEqual("allo", retStr);
            }
        }
        [TestMethod]
        public void LabSheetService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    LabSheetModel labSheetModelRet = labSheetService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, labSheetModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_CheckFollowingAndCount_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int LineNumber = 23;
                string OldFirstObj = "ToFollow";
                List<string> ValueArr = new List<string>() { "test", "allo", "three", "four" };
                string ToFollow = "ToFollow";
                int count = 4;
                string retStr = labSheetService.CheckFollowingAndCount(LineNumber, OldFirstObj, ValueArr, ToFollow, count);
                Assert.AreEqual("", retStr);

                ToFollow = "ToFollow2";
                retStr = labSheetService.CheckFollowingAndCount(LineNumber, OldFirstObj, ValueArr, ToFollow, count);
                Assert.AreEqual(string.Format(ServiceRes.ErrorReadingFileAtLine_Error_, LineNumber, string.Format(ServiceRes._HasToBeFollowing_InTheFile, ValueArr[0], ToFollow)), retStr);

                ToFollow = "ToFollow";
                count = 3;
                retStr = labSheetService.CheckFollowingAndCount(LineNumber, OldFirstObj, ValueArr, ToFollow, count);
                Assert.AreEqual(string.Format(ServiceRes.ErrorReadingFileAtLine_Error_, LineNumber, string.Format(ServiceRes._Requires_Value, ValueArr[0], count)), retStr);
            }
        }
        [TestMethod]
        public void LabSheetService_AddOrUpdateLabSheetDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string FullLabSheetText = "";
                    FileInfo fi = new FileInfo(@"C:\CSSP latest code\CSSPWebToolsTaskRunner\FullLabSheetText.txt");

                    StreamReader sr = fi.OpenText();
                    FullLabSheetText = sr.ReadToEnd();
                    sr.Close();

                    LabSheetModel labSheetModel = labSheetService.AddOrUpdateLabSheetDB(FullLabSheetText);
                    Assert.AreEqual("", labSheetModel.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_AddOrUpdateLabSheetDB_Parameters_Missing_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    // the text below comes from the CSSPLabSheet project function GetNextAvailableLabSheet
                    if (labSheet != null)
                    {
                        sb.AppendLine("OtherServerLabSheetID|||||[" + labSheet.OtherServerLabSheetID + "]");
                        sb.AppendLine("ConfigFileName|||||[" + labSheet.ConfigFileName + "]");
                        sb.AppendLine("Year|||||[" + labSheet.Year + "]");
                        sb.AppendLine("Month|||||[" + labSheet.Month + "]");
                        sb.AppendLine("Day|||||[" + labSheet.Day + "]");
                        sb.AppendLine("SubsectorTVItemID|||||[" + labSheet.SubsectorTVItemID + "]");
                        sb.AppendLine("ConfigType|||||[" + labSheet.ConfigType + "]");
                        sb.AppendLine("SampleType|||||[" + labSheet.SampleType + "]");
                        sb.AppendLine("LabSheetType|||||[" + labSheet.LabSheetType + "]");
                        sb.AppendLine("LabSheetStatus|||||[" + labSheet.LabSheetStatus + "]");
                        sb.AppendLine("FileName|||||[" + labSheet.FileName + "]");
                        sb.AppendLine("FileLastModifiedDate_Local|||||["
                            + labSheet.FileLastModifiedDate_Local.Year + ","
                            + labSheet.FileLastModifiedDate_Local.Month + ","
                            + labSheet.FileLastModifiedDate_Local.Day + ","
                            + labSheet.FileLastModifiedDate_Local.Hour + ","
                            + labSheet.FileLastModifiedDate_Local.Minute + ","
                            + labSheet.FileLastModifiedDate_Local.Second + ","
                            + "]");
                        sb.AppendLine("FileContent|||||[" + labSheet.FileContent + "]");
                    }

                    List<string> parameterList = new List<string>()
                    {
                        "OtherServerLabSheetID", "ConfigFileName", "Year", "Month", "Day", "SubsectorTVItemID",
                        "ConfigType", "SampleType", "LabSheetType", "LabSheetStatus", "FileName",
                        "FileLastModifiedDate_Local", "FileContent",
                    };
                    for (int i = 0, count = parameterList.Count; i < count; i++)
                    {
                        string FullLabSheetTextWithError = sb.ToString();
                        FullLabSheetTextWithError = FullLabSheetTextWithError.Replace((i == 0 ? "" : "\n") + parameterList[i] + "|||||[", (i == 0 ? "" : "\n") + parameterList[i] + "2|||||[");
                        LabSheetModel labSheetModel = labSheetService.AddOrUpdateLabSheetDB(FullLabSheetTextWithError);
                        Assert.AreEqual(string.Format(ServiceRes.FullLabSheetTextParameter_IsMissing, parameterList[i]), labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_AddOrUpdateLabSheetDB_Parameters_ConfigFileName_Empty_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    // the text below comes from the CSSPLabSheet project function GetNextAvailableLabSheet
                    if (labSheet != null)
                    {
                        sb.AppendLine("OtherServerLabSheetID|||||[" + labSheet.OtherServerLabSheetID + "]");
                        sb.AppendLine("ConfigFileName|||||[]"); // + labSheet.ConfigFileName + "]");
                        sb.AppendLine("Year|||||[" + labSheet.Year + "]");
                        sb.AppendLine("Month|||||[" + labSheet.Month + "]");
                        sb.AppendLine("Day|||||[" + labSheet.Day + "]");
                        sb.AppendLine("SubsectorTVItemID|||||[" + labSheet.SubsectorTVItemID + "]");
                        sb.AppendLine("ConfigType|||||[" + labSheet.ConfigType + "]");
                        sb.AppendLine("SampleType|||||[" + labSheet.SampleType + "]");
                        sb.AppendLine("LabSheetType|||||[" + labSheet.LabSheetType + "]");
                        sb.AppendLine("LabSheetStatus|||||[" + labSheet.LabSheetStatus + "]");
                        sb.AppendLine("FileName|||||[" + labSheet.FileName + "]");
                        sb.AppendLine("FileLastModifiedDate_Local|||||["
                            + labSheet.FileLastModifiedDate_Local.Year + ","
                            + labSheet.FileLastModifiedDate_Local.Month + ","
                            + labSheet.FileLastModifiedDate_Local.Day + ","
                            + labSheet.FileLastModifiedDate_Local.Hour + ","
                            + labSheet.FileLastModifiedDate_Local.Minute + ","
                            + labSheet.FileLastModifiedDate_Local.Second + ","
                            + "]");
                        sb.AppendLine("FileContent|||||[" + labSheet.FileContent + "]");
                    }

                    LabSheetModel labSheetModel = labSheetService.AddOrUpdateLabSheetDB(sb.ToString());
                    Assert.AreEqual(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.ConfigFileName), labSheetModel.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_AddOrUpdateLabSheetDB_Parameters_ConfigFileName_WrongText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    // the text below comes from the CSSPLabSheet project function GetNextAvailableLabSheet
                    if (labSheet != null)
                    {
                        sb.AppendLine("LabSheetID|||||[" + labSheet.LabSheetID + "]");
                        sb.AppendLine("ConfigFileName|||||[error]"); // + labSheet.ConfigFileName + "]");
                        sb.AppendLine("Year|||||[" + labSheet.Year + "]");
                        sb.AppendLine("Month|||||[" + labSheet.Month + "]");
                        sb.AppendLine("Day|||||[" + labSheet.Day + "]");
                        sb.AppendLine("SubsectorTVItemID|||||[" + labSheet.SubsectorTVItemID + "]");
                        sb.AppendLine("LabSheetType|||||[" + labSheet.LabSheetType + "]");
                        sb.AppendLine("LabSheetStatus|||||[" + labSheet.LabSheetStatus + "]");
                        sb.AppendLine("FileName|||||[" + labSheet.FileName + "]");
                        sb.AppendLine("FileLastModifiedDate_Local|||||["
                            + labSheet.FileLastModifiedDate_Local.Year + ","
                            + labSheet.FileLastModifiedDate_Local.Month + ","
                            + labSheet.FileLastModifiedDate_Local.Day + ","
                            + labSheet.FileLastModifiedDate_Local.Hour + ","
                            + labSheet.FileLastModifiedDate_Local.Minute + ","
                            + labSheet.FileLastModifiedDate_Local.Second + ","
                            + "]");
                        sb.AppendLine("FileContent|||||[" + labSheet.FileContent + "]");
                    }

                    LabSheetModel labSheetModel = labSheetService.AddOrUpdateLabSheetDB(sb.ToString());
                    Assert.IsTrue(labSheetModel.Error.Length > 0);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_AddOrUpdateLabSheetDB_GetMWQMPlanModelWithConfigFileNameDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    // the text below comes from the CSSPLabSheet project function GetNextAvailableLabSheet
                    if (labSheet != null)
                    {
                        sb.AppendLine("OtherServerLabSheetID|||||[" + labSheet.OtherServerLabSheetID + "]");
                        sb.AppendLine("ConfigFileName|||||[" + labSheet.ConfigFileName + "]");
                        sb.AppendLine("Year|||||[" + labSheet.Year + "]");
                        sb.AppendLine("Month|||||[" + labSheet.Month + "]");
                        sb.AppendLine("Day|||||[" + labSheet.Day + "]");
                        sb.AppendLine("SubsectorTVItemID|||||[" + labSheet.SubsectorTVItemID + "]");
                        sb.AppendLine("ConfigType|||||[" + labSheet.ConfigType + "]");
                        sb.AppendLine("SampleType|||||[" + labSheet.SampleType + "]");
                        sb.AppendLine("LabSheetType|||||[" + labSheet.LabSheetType + "]");
                        sb.AppendLine("LabSheetStatus|||||[" + labSheet.LabSheetStatus + "]");
                        sb.AppendLine("FileName|||||[" + labSheet.FileName + "]");
                        sb.AppendLine("FileLastModifiedDate_Local|||||["
                            + labSheet.FileLastModifiedDate_Local.Year + ","
                            + labSheet.FileLastModifiedDate_Local.Month + ","
                            + labSheet.FileLastModifiedDate_Local.Day + ","
                            + labSheet.FileLastModifiedDate_Local.Hour + ","
                            + labSheet.FileLastModifiedDate_Local.Minute + ","
                            + labSheet.FileLastModifiedDate_Local.Second + ","
                            + "]");
                        sb.AppendLine("FileContent|||||[" + labSheet.FileContent + "]");
                    }

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMPlanService.GetMWQMPlanModelWithConfigFileNameDBString = (a) =>
                        {
                            return new MWQMPlanModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.AddOrUpdateLabSheetDB(sb.ToString());
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_AddOrUpdateLabSheetDB_PostAddLabSheetDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    // the text below comes from the CSSPLabSheet project function GetNextAvailableLabSheet
                    if (labSheet != null)
                    {
                        sb.AppendLine("OtherServerLabSheetID|||||[" + labSheet.OtherServerLabSheetID + "]");
                        sb.AppendLine("ConfigFileName|||||[" + labSheet.ConfigFileName + "]");
                        sb.AppendLine("Year|||||[" + labSheet.Year + "]");
                        sb.AppendLine("Month|||||[" + labSheet.Month + "]");
                        sb.AppendLine("Day|||||[" + labSheet.Day + "]");
                        sb.AppendLine("SubsectorTVItemID|||||[" + labSheet.SubsectorTVItemID + "]");
                        sb.AppendLine("ConfigType|||||[" + labSheet.ConfigType + "]");
                        sb.AppendLine("SampleType|||||[" + labSheet.SampleType + "]");
                        sb.AppendLine("LabSheetType|||||[" + labSheet.LabSheetType + "]");
                        sb.AppendLine("LabSheetStatus|||||[" + labSheet.LabSheetStatus + "]");
                        sb.AppendLine("FileName|||||[" + labSheet.FileName + "]");
                        sb.AppendLine("FileLastModifiedDate_Local|||||["
                            + labSheet.FileLastModifiedDate_Local.Year + ","
                            + labSheet.FileLastModifiedDate_Local.Month + ","
                            + labSheet.FileLastModifiedDate_Local.Day + ","
                            + labSheet.FileLastModifiedDate_Local.Hour + ","
                            + labSheet.FileLastModifiedDate_Local.Minute + ","
                            + labSheet.FileLastModifiedDate_Local.Second + ","
                            + "]");
                        sb.AppendLine("FileContent|||||[" + labSheet.FileContent + "]");
                    }

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.GetLabSheetModelExistDBLabSheetModel = (a) =>
                        {
                            return new LabSheetModel() { Error = ErrorText + ErrorText };
                        };
                        shimLabSheetService.PostAddLabSheetDBLabSheetModel = (a) =>
                        {
                            return new LabSheetModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.AddOrUpdateLabSheetDB(sb.ToString());
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_AddOrUpdateLabSheetDB_PostUpdateLabSheetDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    StringBuilder sb = new StringBuilder();

                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    // the text below comes from the CSSPLabSheet project function GetNextAvailableLabSheet
                    if (labSheet != null)
                    {
                        sb.AppendLine("OtherServerLabSheetID|||||[" + labSheet.OtherServerLabSheetID + "]");
                        sb.AppendLine("ConfigFileName|||||[" + labSheet.ConfigFileName + "]");
                        sb.AppendLine("Year|||||[" + labSheet.Year + "]");
                        sb.AppendLine("Month|||||[" + labSheet.Month + "]");
                        sb.AppendLine("Day|||||[" + labSheet.Day + "]");
                        sb.AppendLine("SubsectorTVItemID|||||[" + labSheet.SubsectorTVItemID + "]");
                        sb.AppendLine("ConfigType|||||[" + labSheet.ConfigType + "]");
                        sb.AppendLine("SampleType|||||[" + labSheet.SampleType + "]");
                        sb.AppendLine("LabSheetType|||||[" + labSheet.LabSheetType + "]");
                        sb.AppendLine("LabSheetStatus|||||[" + labSheet.LabSheetStatus + "]");
                        sb.AppendLine("FileName|||||[" + labSheet.FileName + "]");
                        sb.AppendLine("FileLastModifiedDate_Local|||||["
                            + labSheet.FileLastModifiedDate_Local.Year + ","
                            + labSheet.FileLastModifiedDate_Local.Month + ","
                            + labSheet.FileLastModifiedDate_Local.Day + ","
                            + labSheet.FileLastModifiedDate_Local.Hour + ","
                            + labSheet.FileLastModifiedDate_Local.Minute + ","
                            + labSheet.FileLastModifiedDate_Local.Second + ","
                            + "]");
                        sb.AppendLine("FileContent|||||[" + labSheet.FileContent + "]");
                    }

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.GetLabSheetModelExistDBLabSheetModel = (a) =>
                        {
                            return new LabSheetModel() { Error = "" };
                        };
                        shimLabSheetService.PostUpdateLabSheetDBLabSheetModel = (a) =>
                        {
                            return new LabSheetModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.AddOrUpdateLabSheetDB(sb.ToString());
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_FCFormGenerateDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    string retStr = labSheetService.FCFormGenerateDB(labSheet.LabSheetID);
                    Assert.AreEqual("", retStr);

                    List<AppTaskModel> appTaskModelList = appTaskService.GetAppTaskModelListWithTVItemIDDB(labSheet.SubsectorTVItemID);
                    Assert.IsTrue(appTaskModelList.Count > 0);
                    Assert.AreEqual(labSheet.LabSheetID.ToString(), appTaskService.GetAppTaskParamStr(appTaskModelList[0].Parameters, "LabSheetID"));

                    string ServerFilePath = tvFileService.GetServerFilePath(labSheet.SubsectorTVItemID);
                    Assert.IsTrue(!string.IsNullOrWhiteSpace(ServerFilePath));

                    FileInfo fi = new FileInfo(labSheet.FileName.Replace(".txt", ".docx"));
                    fi = new FileInfo(ServerFilePath + fi.Name);
                    Assert.AreEqual(fi.Name, appTaskService.GetAppTaskParamStr(appTaskModelList[0].Parameters, "FileName"));
                }
            }
        }
        [TestMethod]
        public void LabSheetService_FCFormGenerateDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        string retStr = labSheetService.FCFormGenerateDB(labSheet.LabSheetID);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_FCFormGenerateDB_GetLabSheetModelWithLabSheetIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.GetLabSheetModelWithLabSheetIDDBInt32 = (a) =>
                        {
                            return new LabSheetModel() { Error = ErrorText };
                        };

                        string retStr = labSheetService.FCFormGenerateDB(labSheet.LabSheetID);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_FCFormGenerateDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        string retStr = labSheetService.FCFormGenerateDB(labSheet.LabSheetID);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_FCFormGenerateDB_GetServerFilePath_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVFileService.GetServerFilePathInt32 = (a) =>
                        {
                            return "";
                        };

                        string retStr = labSheetService.FCFormGenerateDB(labSheet.LabSheetID);
                        Assert.AreEqual(ServiceRes.ServerFilePathIsEmpty, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_FCFormGenerateDB_GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimAppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDBInt32Int32AppTaskCommandEnum = (a, b, c) =>
                        {
                            return new AppTaskModel() { Error = "" };
                        };

                        string retStr = labSheetService.FCFormGenerateDB(labSheet.LabSheetID);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask), retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_FCFormGenerateDB_PostAddAppTask_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAppTaskService.PostAddAppTaskAppTaskModel = (a) =>
                        {
                            return new AppTaskModel() { Error = ErrorText };
                        };

                        string retStr = labSheetService.FCFormGenerateDB(labSheet.LabSheetID);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetApprovedDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    LabSheetModel labSheetModel = labSheetService.LabSheetApprovedDB(labSheet.LabSheetID, -180, 0, 0, 0);
                    Assert.AreEqual("", labSheetModel.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetApprovedDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetApprovedDB(labSheet.LabSheetID, -180, 0, 0, 0);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetApprovedDB_GetLabSheetModelWithLabSheetIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.GetLabSheetModelWithLabSheetIDDBInt32 = (a) =>
                        {
                            return new LabSheetModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetApprovedDB(labSheet.LabSheetID, -180, 0, 0, 0);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetApprovedDB_ParseLabSheetA1WithLabSheetIDInt32_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.ParseLabSheetA1WithLabSheetIDInt32 = (a) =>
                        {
                            return new LabSheetA1Sheet() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetApprovedDB(labSheet.LabSheetID, -180, 0, 0, 0);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetApprovedDB_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMRunService.GetMWQMRunModelExistDBMWQMRunModel = (a) =>
                        {
                            return new MWQMRunModel() { Error = ErrorText };
                        };
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetApprovedDB(labSheet.LabSheetID, -180, 0, 0, 0);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetApprovedDB_PostAddMWQMRunDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMRunService.GetMWQMRunModelExistDBMWQMRunModel = (a) =>
                        {
                            return new MWQMRunModel() { Error = ErrorText };
                        };
                        shimMWQMRunService.PostAddMWQMRunDBMWQMRunModel = (a) =>
                        {
                            return new MWQMRunModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetApprovedDB(labSheet.LabSheetID, -180, 0, 0, 0);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetApprovedDB_PostUpdateMWQMRunDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMRunService.GetMWQMRunModelExistDBMWQMRunModel = (a) =>
                        {
                            return new MWQMRunModel() { Error = "" };
                        };
                        shimMWQMRunService.PostUpdateMWQMRunDBMWQMRunModel = (a) =>
                        {
                            return new MWQMRunModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetApprovedDB(labSheet.LabSheetID, -180, 0, 0, 0);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetApprovedDB_GetMWQMSiteModelWithMWQMSiteTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMSiteService.GetMWQMSiteModelWithMWQMSiteTVItemIDDBInt32 = (a) =>
                        {
                            return new MWQMSiteModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetApprovedDB(labSheet.LabSheetID, -180, 0, 0, 0);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetApprovedDB_PostAddMWQMSampleDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMSampleService.GetMWQMSampleModelListWithMWQMSiteTVItemIDAndSampleTypeAndSampleDateTimeDBInt32SampleTypeEnumDateTime = (a, b, c) =>
                        {
                            return new List<MWQMSampleModel>() { };
                        };
                        shimMWQMSampleService.PostAddMWQMSampleDBMWQMSampleModel = (a) =>
                        {
                            return new MWQMSampleModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetApprovedDB(labSheet.LabSheetID, -180, 0, 0, 0);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetApprovedDB_PostUpdateMWQMSampleDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMSampleService.GetMWQMSampleModelListWithMWQMSiteTVItemIDAndSampleTypeAndSampleDateTimeDBInt32SampleTypeEnumDateTime = (a, b, c) =>
                        {
                            return new List<MWQMSampleModel>() { new MWQMSampleModel() };
                        };
                        shimMWQMSampleService.PostUpdateMWQMSampleDBMWQMSampleModel = (a) =>
                        {
                            return new MWQMSampleModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetApprovedDB(labSheet.LabSheetID, -180, 0, 0, 0);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetApprovedDB_PostUpdateLabSheetDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.PostUpdateLabSheetDBLabSheetModel = (a) =>
                        {
                            return new LabSheetModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetApprovedDB(labSheet.LabSheetID, -180, 0, 0, 0);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetApprovedDB_FCFormGenerateDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.FCFormGenerateDBInt32 = (a) =>
                        {
                            return ErrorText;
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetApprovedDB(labSheet.LabSheetID, -180, 0, 0, 0);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetNotApprovedDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    LabSheetModel labSheetModel = labSheetService.LabSheetRejectedDB(labSheet.LabSheetID);
                    Assert.AreEqual("", labSheetModel.Error);

                    labSheetModel = labSheetService.GetLabSheetModelWithLabSheetIDDB(labSheet.LabSheetID);
                    Assert.AreEqual(LabSheetStatusEnum.Rejected, labSheetModel.LabSheetStatus);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetNotApprovedDB_GetLabSheetModelWithLabSheetIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.GetLabSheetModelWithLabSheetIDDBInt32 = (a) =>
                        {
                            return new LabSheetModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetRejectedDB(labSheet.LabSheetID);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetNotApprovedDB_PostUpdateLabSheetDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.PostUpdateLabSheetDBLabSheetModel = (a) =>
                        {
                            return new LabSheetModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetRejectedDB(labSheet.LabSheetID);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_LabSheetNotApprovedDB_SendLabSheetNotApprovedEmail_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.SendLabSheetRejectedEmailInt32 = (a) =>
                        {
                            return new LabSheetModel() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModel = labSheetService.LabSheetRejectedDB(labSheet.LabSheetID);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostAddUpdateDeleteLabSheet_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();

                    LabSheetModel labSheetModelRet2 = UpdateLabSheetModel(labSheetModelRet);

                    LabSheetModel labSheetModelRet3 = labSheetService.PostDeleteLabSheetDB(labSheetModelRet2.LabSheetID);
                    Assert.AreEqual("", labSheetModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostAddLabSheetDB_LabSheetModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetService.LabSheetModelOKLabSheetModel = (a) =>
                        {
                            return ErrorText;
                        };

                        LabSheetModel labSheetModelRet = AddLabSheetModel();
                        Assert.AreEqual(ErrorText, labSheetModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostAddLabSheetDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModelRet = AddLabSheetModel();
                        Assert.AreEqual(ErrorText, labSheetModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostAddLabSheetDB_GetLabSheetModelExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimLabSheetService.GetLabSheetModelExistDBLabSheetModel = (a) =>
                        {
                            return new LabSheetModel();
                        };

                        LabSheetModel labSheetModelRet = AddLabSheetModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.LabSheet), labSheetModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostAddLabSheetDB_FillLabSheet_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetService.FillLabSheetLabSheetLabSheetModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        LabSheetModel labSheetModelRet = AddLabSheetModel();
                        Assert.AreEqual(ErrorText, labSheetModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostAddLabSheetDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        LabSheetModel labSheetModelRet = AddLabSheetModel();
                        Assert.AreEqual(ErrorText, labSheetModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostAddLabSheetDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimLabSheetService.FillLabSheetLabSheetLabSheetModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        LabSheetModel labSheetModelRet = AddLabSheetModel();
                        Assert.IsTrue(labSheetModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostAddLabSheetDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();
                    Assert.IsNotNull(labSheetModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, labSheetModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostAddLabSheetDB_NeedToBeLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[3], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();
                    Assert.IsNotNull(labSheetModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, labSheetModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostDeleteLabSheet_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModelRet2 = labSheetService.PostDeleteLabSheetDB(labSheetModelRet.LabSheetID);
                        Assert.AreEqual(ErrorText, labSheetModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostDeleteLabSheet_GetLabSheetWithLabSheetIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimLabSheetService.GetLabSheetWithLabSheetIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        LabSheetModel labSheetModelRet2 = labSheetService.PostDeleteLabSheetDB(labSheetModelRet.LabSheetID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.LabSheet), labSheetModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostDeleteLabSheet_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        LabSheetModel labSheetModelRet2 = labSheetService.PostDeleteLabSheetDB(labSheetModelRet.LabSheetID);
                        Assert.AreEqual(ErrorText, labSheetModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostUpdateLabSheet_LabSheetModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();
                    Assert.AreEqual("", labSheetModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetService.LabSheetModelOKLabSheetModel = (a) =>
                        {
                            return ErrorText;
                        };

                        LabSheetModel labSheetModelRet2 = UpdateLabSheetModel(labSheetModelRet);
                        Assert.AreEqual(ErrorText, labSheetModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostUpdateLabSheet_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        LabSheetModel labSheetModelRet2 = UpdateLabSheetModel(labSheetModelRet);
                        Assert.AreEqual(ErrorText, labSheetModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostUpdateLabSheet_GetLabSheetWithLabSheetIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimLabSheetService.GetLabSheetWithLabSheetIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        LabSheetModel labSheetModelRet2 = UpdateLabSheetModel(labSheetModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.LabSheet), labSheetModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostUpdateLabSheet_FillLabSheet_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetService.FillLabSheetLabSheetLabSheetModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        LabSheetModel labSheetModelRet2 = UpdateLabSheetModel(labSheetModelRet);
                        Assert.AreEqual(ErrorText, labSheetModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_PostUpdateLabSheet_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheetModel labSheetModelRet = AddLabSheetModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimLabSheetService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        LabSheetModel labSheetModelRet2 = UpdateLabSheetModel(labSheetModelRet);
                        Assert.AreEqual(ErrorText, labSheetModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_SendLabSheetNotApprovedEmail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    LabSheetModel labSheetModel = labSheetService.SendLabSheetRejectedEmail(labSheet.LabSheetID);
                    Assert.AreEqual("", labSheetModel.Error);
                }
            }
        }
        [TestMethod]
        public void LabSheetService_SendLabSheetNotApprovedEmail_GetLabSheetModelWithLabSheetIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.GetLabSheetModelWithLabSheetIDDBInt32 = (a) =>
                        {
                            return new LabSheetModel() { Error = ErrorText };
                        };
                        LabSheetModel labSheetModel = labSheetService.SendLabSheetRejectedEmail(labSheet.LabSheetID);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_SendLabSheetNotApprovedEmail_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };
                        LabSheetModel labSheetModel = labSheetService.SendLabSheetRejectedEmail(labSheet.LabSheetID);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_SendLabSheetNotApprovedEmail_GetParentsTVItemModelList_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetParentsTVItemModelListString = (a) =>
                        {
                            return new List<TVItemModel>();
                        };
                        LabSheetModel labSheetModel = labSheetService.SendLabSheetRejectedEmail(labSheet.LabSheetID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_, ServiceRes.Province), labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_SendLabSheetNotApprovedEmail_GetContactModelWithMWQMPlanner_ProvincesTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    TVItemModel tvItemModelSubsector = tvItemService.GetTVItemModelWithTVItemIDDB(labSheet.SubsectorTVItemID);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    List<TVItemModel> tvItemModelParents = tvItemService.GetParentsTVItemModelList(tvItemModelSubsector.TVPath);

                    TVItemModel tvItemModelProvince = tvItemModelParents.Where(c => c.TVType == TVTypeEnum.Province).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimContactService.GetContactModelWithMWQMPlanner_ProvincesTVItemIDDBInt32 = (a) =>
                        {
                            return new List<ContactModel>();
                        };
                        LabSheetModel labSheetModel = labSheetService.SendLabSheetRejectedEmail(labSheet.LabSheetID);
                        Assert.AreEqual(string.Format(ServiceRes.NoContactFoundToSendTheEmailForProvince_, tvItemModelProvince.TVText), labSheetModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void LabSheetService_SendLabSheetNotApprovedEmail_SendEmail_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    LabSheet labSheet = (from c in labSheetService.db.LabSheets select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    TVItemModel tvItemModelSubsector = tvItemService.GetTVItemModelWithTVItemIDDB(labSheet.SubsectorTVItemID);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    List<TVItemModel> tvItemModelParents = tvItemService.GetParentsTVItemModelList(tvItemModelSubsector.TVPath);

                    TVItemModel tvItemModelProvince = tvItemModelParents.Where(c => c.TVType == TVTypeEnum.Province).FirstOrDefault();
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimLabSheetService.SendEmailMailMessage = (a) =>
                        {
                            return ErrorText;
                        };
                        LabSheetModel labSheetModel = labSheetService.SendLabSheetRejectedEmail(labSheet.LabSheetID);
                        Assert.AreEqual(ErrorText, labSheetModel.Error);
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public LabSheetModel AddLabSheetModel()
        {
            LabSheet labSheet = (from c in labSheetService.db.LabSheets
                                 select c).FirstOrDefault();

            labSheetModelNew.OtherServerLabSheetID = labSheet.OtherServerLabSheetID;
            labSheetModelNew.MWQMPlanID = labSheet.MWQMPlanID;
            labSheetModelNew.SubsectorTVItemID = labSheet.SubsectorTVItemID;
            if (labSheet.MWQMRunTVItemID == null)
            {
                labSheetModelNew.MWQMRunTVItemID = randomService.RandomTVItem(TVTypeEnum.MWQMRun).TVItemID;
            }
            FillLabSheetModel(labSheetModelNew);

            LabSheetModel labSheetModelRet = labSheetService.PostAddLabSheetDB(labSheetModelNew);
            if (!string.IsNullOrWhiteSpace(labSheetModelRet.Error))
            {
                return labSheetModelRet;
            }

            CompareLabSheetModels(labSheetModelNew, labSheetModelRet);

            return labSheetModelRet;
        }
        public LabSheetModel UpdateLabSheetModel(LabSheetModel labSheetModel)
        {
            FillLabSheetModel(labSheetModel);

            LabSheetModel labSheetModelRet2 = labSheetService.PostUpdateLabSheetDB(labSheetModel);
            if (!string.IsNullOrWhiteSpace(labSheetModelRet2.Error))
            {
                return labSheetModelRet2;
            }

            CompareLabSheetModels(labSheetModel, labSheetModelRet2);

            return labSheetModelRet2;
        }
        private void CompareLabSheetModels(LabSheetModel labSheetModelNew, LabSheetModel labSheetModelRet)
        {
            Assert.AreEqual(labSheetModelNew.OtherServerLabSheetID, labSheetModelRet.OtherServerLabSheetID);
            Assert.AreEqual(labSheetModelNew.MWQMPlanID, labSheetModelRet.MWQMPlanID);
            Assert.AreEqual(labSheetModelNew.ConfigFileName, labSheetModelRet.ConfigFileName);
            Assert.AreEqual(labSheetModelNew.Year, labSheetModelRet.Year);
            Assert.AreEqual(labSheetModelNew.Month, labSheetModelRet.Month);
            Assert.AreEqual(labSheetModelNew.Day, labSheetModelRet.Day);
            Assert.AreEqual(labSheetModelNew.SubsectorTVItemID, labSheetModelRet.SubsectorTVItemID);
            Assert.AreEqual(labSheetModelNew.MWQMRunTVItemID, labSheetModelRet.MWQMRunTVItemID);
            Assert.AreEqual(labSheetModelNew.ConfigType, labSheetModelRet.ConfigType);
            Assert.AreEqual(labSheetModelNew.SampleType, labSheetModelRet.SampleType);
            Assert.AreEqual(labSheetModelNew.LabSheetType, labSheetModelRet.LabSheetType);
            Assert.AreEqual(labSheetModelNew.LabSheetStatus, labSheetModelRet.LabSheetStatus);
            Assert.AreEqual(labSheetModelNew.FileName, labSheetModelRet.FileName);
            Assert.AreEqual(labSheetModelNew.FileLastModifiedDate_Local, labSheetModelRet.FileLastModifiedDate_Local);
            Assert.AreEqual(labSheetModelNew.FileContent, labSheetModelRet.FileContent);
            Assert.AreEqual(labSheetModelNew.ApprovedOrRejectedByContactTVItemID, labSheetModelRet.ApprovedOrRejectedByContactTVItemID);
            Assert.AreEqual(labSheetModelNew.ApprovedOrRejectedDateTime, labSheetModelRet.ApprovedOrRejectedDateTime);
        }
        private void FillLabSheetModel(LabSheetModel labSheetModel)
        {
            labSheetModel.OtherServerLabSheetID = labSheetModel.OtherServerLabSheetID;
            labSheetModel.MWQMPlanID = labSheetModel.MWQMPlanID;
            labSheetModel.ConfigFileName = randomService.RandomString("", 99);
            labSheetModel.Year = randomService.RandomInt(2012, 2016);
            labSheetModel.Month = randomService.RandomInt(4, 8);
            labSheetModel.Day = randomService.RandomInt(1, 29);
            labSheetModel.SubsectorTVItemID = labSheetModel.SubsectorTVItemID;
            labSheetModel.MWQMRunTVItemID = labSheetModel.MWQMRunTVItemID;
            labSheetModel.ConfigType = ConfigTypeEnum.Subsector;
            labSheetModel.SampleType = SampleTypeEnum.Routine;
            labSheetModel.LabSheetType = LabSheetTypeEnum.A1;
            labSheetModel.LabSheetStatus = LabSheetStatusEnum.Transferred;
            labSheetModel.FileName = randomService.RandomString("", 20);
            labSheetModel.FileLastModifiedDate_Local = randomService.RandomDateTime();
            labSheetModel.FileContent = randomService.RandomString("", 123);
            labSheetModel.ApprovedOrRejectedByContactTVItemID = randomService.RandomTVItem(TVTypeEnum.Contact).TVItemID;
            labSheetModel.ApprovedOrRejectedDateTime = randomService.RandomDateTime();

            Assert.IsTrue(labSheetModel.OtherServerLabSheetID > 0);
            Assert.IsTrue(labSheetModel.MWQMPlanID > 0);
            Assert.IsTrue(labSheetModel.ConfigFileName.Length == 99);
            Assert.IsTrue(labSheetModel.Year >= 2012 && labSheetModel.Year <= 2016);
            Assert.IsTrue(labSheetModel.Month >= 4 && labSheetModel.Month <= 8);
            Assert.IsTrue(labSheetModel.Day >= 1 && labSheetModel.Day <= 29);
            Assert.IsTrue(labSheetModel.SubsectorTVItemID != 0);
            Assert.IsTrue(labSheetModel.MWQMRunTVItemID > 0);
            Assert.IsTrue(labSheetModel.ConfigType == ConfigTypeEnum.Subsector);
            Assert.IsTrue(labSheetModel.SampleType == SampleTypeEnum.Routine);
            Assert.IsTrue(labSheetModel.LabSheetType == LabSheetTypeEnum.A1);
            Assert.IsTrue(labSheetModel.LabSheetStatus == LabSheetStatusEnum.Transferred);
            Assert.IsTrue(labSheetModel.FileLastModifiedDate_Local != null);
            Assert.IsTrue(labSheetModel.FileContent.Length == 123);
            Assert.IsTrue(labSheetModel.ApprovedOrRejectedByContactTVItemID > 0);
            Assert.IsTrue(labSheetModel.ApprovedOrRejectedDateTime != null);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            labSheetService = new LabSheetService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            appTaskService = new AppTaskService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvFileService = new TVFileService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            labSheetModelNew = new LabSheetModel();
            labSheet = new LabSheet();
        }
        private void SetupShim()
        {
            shimLabSheetService = new ShimLabSheetService(labSheetService);
            shimMWQMPlanService = new ShimMWQMPlanService(labSheetService._MWQMPlanService);
            shimTVItemService = new ShimTVItemService(labSheetService._TVItemService);
            shimTVFileService = new ShimTVFileService(labSheetService._TVFileService);
            shimAppTaskService = new ShimAppTaskService(labSheetService._AppTaskService);
            shimMWQMRunService = new ShimMWQMRunService(labSheetService._MWQMRunService);
            shimMWQMSiteService = new ShimMWQMSiteService(labSheetService._MWQMSiteService);
            shimMWQMSampleService = new ShimMWQMSampleService(labSheetService._MWQMSampleService);
            shimContactService = new ShimContactService(labSheetService._ContactService);
        }
        #endregion Functions private
    }
}


