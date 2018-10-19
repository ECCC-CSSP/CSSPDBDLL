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
using System.Web.Mvc;
using System.IO;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MWQMPlanServiceTest
    /// </summary>
    [TestClass]
    public class MWQMPlanServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MWQMPlan";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MWQMPlanService mwqmPlanService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MWQMPlanModel mwqmPlanModelNew { get; set; }
        private MWQMPlan mwqmPlan { get; set; }
        private ShimMWQMPlanService shimMWQMPlanService { get; set; }
        private ShimAppTaskService shimAppTaskService { get; set; }
        private ShimTVFileService shimTVFileService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
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
        public MWQMPlanServiceTest()
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
        public void MWQMPlanService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(mwqmPlanService);
                Assert.IsNotNull(mwqmPlanService.db);
                Assert.IsNotNull(mwqmPlanService.LanguageRequest);
                Assert.IsNotNull(mwqmPlanService.User);
                Assert.AreEqual(user.Identity.Name, mwqmPlanService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mwqmPlanService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MWQMPlanService_MWQMPlanModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRet = randomService.RandomTVItem(TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    #region Good
                    mwqmPlanModelNew.ProvinceTVItemID = tvItemModelRet.TVItemID;
                    mwqmPlanModelNew.CreatorTVItemID = contactModelListGood[0].ContactTVItemID;
                    FillMWQMPlanModel(mwqmPlanModelNew);

                    string retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region ConfigFileName
                    int Min = 3;
                    int Max = 100;

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.ConfigFileName = randomService.RandomString("", Min - 1);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.ConfigFileName, Min), retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.ConfigFileName = randomService.RandomString("", Max + 1);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ConfigFileName, Max), retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.ConfigFileName = randomService.RandomString("", Min);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.ConfigFileName = randomService.RandomString("", Max);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.ConfigFileName = randomService.RandomString("", Max - 1);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ConfigFileName

                    #region ForGroupName
                    Min = 3;
                    Max = 100;

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.ForGroupName = randomService.RandomString("", Min - 1);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.ForGroupName, Min), retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.ForGroupName = randomService.RandomString("", Max + 1);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ForGroupName, Max), retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.ForGroupName = randomService.RandomString("", Min);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.ForGroupName = randomService.RandomString("", Max);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.ForGroupName = randomService.RandomString("", Max - 1);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ForGroupName

                    #region CreatorTVItemID
                    mwqmPlanModelNew.CreatorTVItemID = tvItemModelRet.TVItemID;
                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.CreatorTVItemID = 0;

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.CreatorTVItemID), retStr);

                    mwqmPlanModelNew.CreatorTVItemID = tvItemModelRet.TVItemID;
                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.CreatorTVItemID = 1;

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion CreatorTVItemID

                    #region Year
                    Min = 2000;
                    Max = 2050;

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.Year = Min - 1;

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Year, Min, Max), retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.Year = Max + 1;

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Year, Min, Max), retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.Year = Min;

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.Year = Max;

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.Year = Max - 1;

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Year

                    #region SecretCode
                    Min = 3;
                    Max = 10;

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.SecretCode = randomService.RandomString("", Min - 1);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.SecretCode, Min), retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.SecretCode = randomService.RandomString("", Max + 1);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.SecretCode, Max), retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.SecretCode = randomService.RandomString("", Min);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.SecretCode = randomService.RandomString("", Max);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);

                    FillMWQMPlanModel(mwqmPlanModelNew);
                    mwqmPlanModelNew.SecretCode = randomService.RandomString("", Max - 1);

                    retStr = mwqmPlanService.MWQMPlanModelOK(mwqmPlanModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SecretCode
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_FillMWQMPlan_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelProvince = randomService.RandomTVItem(TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    mwqmPlanModelNew.ProvinceTVItemID = tvItemModelProvince.TVItemID;
                    mwqmPlanModelNew.CreatorTVItemID = contactModelListGood[0].ContactTVItemID;
                    FillMWQMPlanModel(mwqmPlanModelNew);

                    ContactOK contactOK = mwqmPlanService.IsContactOK();

                    string retStr = mwqmPlanService.FillMWQMPlan(mwqmPlan, mwqmPlanModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mwqmPlan.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mwqmPlanService.FillMWQMPlan(mwqmPlan, mwqmPlanModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, mwqmPlan.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_GetMWQMPlanModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    int mwqmPlanCount = mwqmPlanService.GetMWQMPlanModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, mwqmPlanCount);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_GetMWQMPlanModelListWithSubsectorTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    List<MWQMPlanModel> mwqmPlanModelList = mwqmPlanService.GetMWQMPlanModelListWithProvinceTVItemIDDB(mwqmPlanModelRet.ProvinceTVItemID);
                    Assert.IsTrue(mwqmPlanModelList.Where(c => c.MWQMPlanID == mwqmPlanModelRet.MWQMPlanID).Any());

                    int ProvinceTVItemID = 0;
                    mwqmPlanModelList = mwqmPlanService.GetMWQMPlanModelListWithProvinceTVItemIDDB(ProvinceTVItemID);
                    Assert.AreEqual(0, mwqmPlanModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_GetMWQMPlanModelWithMWQMPlanIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    MWQMPlanModel mwqmPlanModelRet2 = mwqmPlanService.GetMWQMPlanModelWithMWQMPlanIDDB(mwqmPlanModelRet.MWQMPlanID);
                    Assert.AreEqual(mwqmPlanModelRet.MWQMPlanID, mwqmPlanModelRet2.MWQMPlanID);

                    int MWQMPlanID = 0;
                    mwqmPlanModelRet2 = mwqmPlanService.GetMWQMPlanModelWithMWQMPlanIDDB(MWQMPlanID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMPlan, ServiceRes.MWQMPlanID, MWQMPlanID), mwqmPlanModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_GetMWQMPlanModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();
                    Assert.AreEqual("", mwqmPlanModelRet.Error);

                    MWQMPlanModel mwqmPlanModelRet2 = mwqmPlanService.GetMWQMPlanModelExistDB(mwqmPlanModelRet);
                    Assert.AreEqual(mwqmPlanModelRet.MWQMPlanID, mwqmPlanModelRet2.MWQMPlanID);

                    mwqmPlanModelRet.ProvinceTVItemID = 0;
                    mwqmPlanModelRet2 = mwqmPlanService.GetMWQMPlanModelExistDB(mwqmPlanModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.MWQMPlan,
                    ServiceRes.Year + "," +
                    ServiceRes.ConfigFileName + "," +
                    ServiceRes.ForGroupName + "," +
                    ServiceRes.SampleType + "," +
                    ServiceRes.ConfigType + "," +
                    ServiceRes.LabSheetType + "," +
                    ServiceRes.ProvinceTVItemID + "," +
                    ServiceRes.SecretCode,
                    mwqmPlanModelRet.Year + "," +
                    mwqmPlanModelRet.ConfigFileName + "," +
                    mwqmPlanModelRet.ForGroupName + "," +
                    mwqmPlanModelRet.SampleType.ToString() + "," +
                    mwqmPlanModelRet.ConfigType.ToString() + "," +
                    mwqmPlanModelRet.LabSheetType.ToString() + "," +
                    mwqmPlanModelRet.ProvinceTVItemID + "," +
                    mwqmPlanModelRet.SecretCode), mwqmPlanModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_GetMWQMPlanWithMWQMPlanIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    MWQMPlan mwqmPlanRet = mwqmPlanService.GetMWQMPlanWithMWQMPlanIDDB(mwqmPlanModelRet.MWQMPlanID);
                    Assert.AreEqual(mwqmPlanModelRet.MWQMPlanID, mwqmPlanRet.MWQMPlanID);

                    int MWQMPlanID = 0;
                    MWQMPlan mwqmPlanRet2 = mwqmPlanService.GetMWQMPlanWithMWQMPlanIDDB(MWQMPlanID);
                    Assert.IsNull(mwqmPlanRet2);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, mwqmPlanModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileService_MWQMPlanGenerateConfigFileDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModel = AddMWQMPlanModel();
                    Assert.AreEqual("", mwqmPlanModel.Error);

                    string retStr = mwqmPlanService.MWQMPlanGenerateConfigFileDB(mwqmPlanModel.MWQMPlanID);
                    Assert.AreEqual("", retStr);

                    List<AppTaskModel> appTaskModelList = mwqmPlanService._AppTaskService.GetAppTaskModelListWithTVItemIDDB(mwqmPlanModel.ProvinceTVItemID);
                    Assert.IsTrue(appTaskModelList.Count > 0);
                    Assert.AreEqual(AppTaskCommandEnum.CreateMWQMPlanConfigTextFile, appTaskModelList[0].Command);
                }
            }
        }
        [TestMethod]
        public void TVFileService_MWQMPlanGenerateConfigFileDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModel = AddMWQMPlanModel();
                    Assert.AreEqual("", mwqmPlanModel.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMPlanService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        string retStr = mwqmPlanService.MWQMPlanGenerateConfigFileDB(mwqmPlanModel.MWQMPlanID);
                        Assert.AreEqual(ErrorText, retStr);

                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_MWQMPlanGenerateConfigFileDB_GetMWQMPlanModelWithMWQMPlanIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModel = AddMWQMPlanModel();
                    Assert.AreEqual("", mwqmPlanModel.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMPlanService.GetMWQMPlanModelWithMWQMPlanIDDBInt32 = (a) =>
                        {
                            return new MWQMPlanModel() { Error = ErrorText };
                        };

                        string retStr = mwqmPlanService.MWQMPlanGenerateConfigFileDB(mwqmPlanModel.MWQMPlanID);
                        Assert.AreEqual(ErrorText, retStr);

                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_MWQMPlanGenerateConfigFileDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModel = AddMWQMPlanModel();
                    Assert.AreEqual("", mwqmPlanModel.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        string retStr = mwqmPlanService.MWQMPlanGenerateConfigFileDB(mwqmPlanModel.MWQMPlanID);
                        Assert.AreEqual(ErrorText, retStr);

                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_MWQMPlanGenerateConfigFileDB_GetServerFilePath_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModel = AddMWQMPlanModel();
                    Assert.AreEqual("", mwqmPlanModel.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVFileService.GetServerFilePathInt32 = (a) =>
                        {
                            return "";
                        };

                        string retStr = mwqmPlanService.MWQMPlanGenerateConfigFileDB(mwqmPlanModel.MWQMPlanID);
                        Assert.AreEqual(ServiceRes.ServerFilePathIsEmpty, retStr);

                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_MWQMPlanGenerateConfigFileDB_ConfigFileName_Empty_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModel = AddMWQMPlanModel();
                    Assert.AreEqual("", mwqmPlanModel.Error);

                    MWQMPlan mwqmPlan = (from c in mwqmPlanService.db.MWQMPlans
                                         where c.MWQMPlanID == mwqmPlanModel.MWQMPlanID
                                         select c).FirstOrDefault();

                    Assert.IsNotNull(mwqmPlan);

                    try
                    {
                        mwqmPlan.ConfigFileName = "";
                        mwqmPlanService.db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        Assert.IsTrue(false);
                    }

                    MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.GetMWQMPlanModelWithMWQMPlanIDDB(mwqmPlanModel.MWQMPlanID);
                    Assert.AreEqual("", mwqmPlanModelRet.Error);

                    string retStr = mwqmPlanService.MWQMPlanGenerateConfigFileDB(mwqmPlanModelRet.MWQMPlanID);
                    Assert.AreEqual(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.ConfigFileName), retStr);
                }
            }
        }
        [TestMethod]
        public void TVFileService_MWQMPlanGenerateConfigFileDB_GetFileExist_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModel = AddMWQMPlanModel();
                    Assert.AreEqual("", mwqmPlanModel.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVFileService.GetFileExistFileInfo = (a) =>
                        {
                            return true;
                        };

                        string ServerFilePath = mwqmPlanService._TVFileService.GetServerFilePath(mwqmPlanModel.ProvinceTVItemID);

                        FileInfo fi = new FileInfo(ServerFilePath + mwqmPlanModel.ConfigFileName);

                        string retStr = mwqmPlanService.MWQMPlanGenerateConfigFileDB(mwqmPlanModel.MWQMPlanID);
                        Assert.AreEqual(string.Format(ServiceRes.File_AlreadyExist, mwqmPlanModel.ConfigFileName), retStr);

                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_MWQMPlanGenerateConfigFileDB_GetAllowableFileGeneratedType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModel = AddMWQMPlanModel();
                    Assert.AreEqual("", mwqmPlanModel.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVFileService.GetAllowableFileGeneratedType = () =>
                        {
                            return new List<string>();
                        };

                        string retStr = mwqmPlanService.MWQMPlanGenerateConfigFileDB(mwqmPlanModel.MWQMPlanID);
                        Assert.AreEqual(ServiceRes.AllowableFileGeneratedTypeListCountZero, retStr);

                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_MWQMPlanGenerateConfigFileDB_IsAllowableFileGeneratedType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModel = AddMWQMPlanModel();
                    Assert.AreEqual("", mwqmPlanModel.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVFileService.IsAllowableFileGeneratedTypeFileInfoListOfString = (a, b) =>
                        {
                            return false;
                        };

                        string retStr = mwqmPlanService.MWQMPlanGenerateConfigFileDB(mwqmPlanModel.MWQMPlanID);
                        Assert.AreEqual(string.Format(ServiceRes.FileType_IsNotAllowed, ".txt"), retStr);

                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_MWQMPlanGenerateConfigFileDB_GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModel = AddMWQMPlanModel();
                    Assert.AreEqual("", mwqmPlanModel.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimAppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDBInt32Int32AppTaskCommandEnum = (a, b, c) =>
                        {
                            return new AppTaskModel() { Error = "" };
                        };

                        string retStr = mwqmPlanService.MWQMPlanGenerateConfigFileDB(mwqmPlanModel.MWQMPlanID);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask), retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_MWQMPlanGenerateConfigFileDB_PostAddAppTask_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModel = AddMWQMPlanModel();
                    Assert.AreEqual("", mwqmPlanModel.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAppTaskService.PostAddAppTaskAppTaskModel = (a) =>
                        {
                            return new AppTaskModel() { Error = ErrorText };
                        };

                        string retStr = mwqmPlanService.MWQMPlanGenerateConfigFileDB(mwqmPlanModel.MWQMPlanID);
                        Assert.AreEqual(ErrorText, retStr);

                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_MWQMPlanSaveAllDB_Add_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillMWQMPlanFormCollection();

                    MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.MWQMPlanSaveTopDB(fc);
                    Assert.AreEqual("", mwqmPlanModelRet.Error);

                    mwqmPlanModelRet = mwqmPlanService.GetMWQMPlanModelWithMWQMPlanIDDB(mwqmPlanModelRet.MWQMPlanID);
                    Assert.AreEqual("", mwqmPlanModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_MWQMPlanSaveAllDB_Add_Error_ProvinceTVItemID_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillMWQMPlanFormCollection();
                    fc["ProvinceTVItemID"] = "0";

                    MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.MWQMPlanSaveTopDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ProvinceTVItemID), mwqmPlanModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_MWQMPlanSaveAllDB_Add_Error_ConfigFileName_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillMWQMPlanFormCollection();
                    fc["ConfigFileName"] = "";

                    MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.MWQMPlanSaveTopDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ConfigFileName), mwqmPlanModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_MWQMPlanSaveAllDB_Add_Error_ForGroupName_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillMWQMPlanFormCollection();
                    fc["ForGroupName"] = "";

                    MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.MWQMPlanSaveTopDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ForGroupName), mwqmPlanModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_MWQMPlanSaveAllDB_Add_Error_Year_Empty_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillMWQMPlanFormCollection();
                    fc["Year"] = "";

                    MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.MWQMPlanSaveTopDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Year), mwqmPlanModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_MWQMPlanSaveAllDB_Add_Error_Year_Before_2000_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillMWQMPlanFormCollection();
                    fc["Year"] = "1999";

                    MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.MWQMPlanSaveTopDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Year, 2000, 2050), mwqmPlanModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_MWQMPlanSaveAllDB_Add_Error_Year_After_2050_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillMWQMPlanFormCollection();
                    fc["Year"] = "2051";

                    MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.MWQMPlanSaveTopDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Year, 2000, 2050), mwqmPlanModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_MWQMPlanSaveAllDB_Add_Error_SecretCode_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillMWQMPlanFormCollection();
                    fc["SecretCode"] = "";

                    MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.MWQMPlanSaveTopDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SecretCode), mwqmPlanModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_MWQMPlanSaveAllDB_Modify_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillMWQMPlanFormCollection();

                    MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.MWQMPlanSaveTopDB(fc);
                    Assert.AreEqual("", mwqmPlanModelRet.Error);

                    mwqmPlanModelRet = mwqmPlanService.GetMWQMPlanModelWithMWQMPlanIDDB(mwqmPlanModelRet.MWQMPlanID);
                    Assert.AreEqual("", mwqmPlanModelRet.Error);

                    fc.Remove("ConfigFileName");
                    string ConfigFileName = randomService.RandomString("", 24);
                    fc.Add("ConfigFileName", ConfigFileName);
                    fc.Add("MWQMPlanID", mwqmPlanModelRet.MWQMPlanID.ToString());

                    mwqmPlanModelRet = mwqmPlanService.MWQMPlanSaveTopDB(fc);
                    Assert.AreEqual("", mwqmPlanModelRet.Error);

                    mwqmPlanModelRet = mwqmPlanService.GetMWQMPlanModelWithMWQMPlanIDDB(mwqmPlanModelRet.MWQMPlanID);
                    Assert.AreEqual("", mwqmPlanModelRet.Error);
                    Assert.AreEqual(ConfigFileName, mwqmPlanModelRet.ConfigFileName);

                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostAddUpdateDeleteMWQMPlan_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    MWQMPlanModel mwqmPlanModelRet2 = UpdateMWQMPlanModel(mwqmPlanModelRet);

                    MWQMPlanModel mwqmPlanModelRet3 = mwqmPlanService.PostDeleteMWQMPlanDB(mwqmPlanModelRet2.MWQMPlanID);
                    Assert.AreEqual("", mwqmPlanModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostAddMWQMPlanDB_MWQMPlanModelOK_Error_Test()
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
                        shimMWQMPlanService.MWQMPlanModelOKMWQMPlanModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();
                        Assert.AreEqual(ErrorText, mwqmPlanModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostAddMWQMPlanDB_IsContactOK_Error_Test()
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
                        shimMWQMPlanService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();
                        Assert.AreEqual(ErrorText, mwqmPlanModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostAddMWQMPlanDB_GetMWQMPlanExistDB_Error_Test()
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
                        shimMWQMPlanService.GetMWQMPlanModelExistDBMWQMPlanModel = (a) =>
                        {
                            return new MWQMPlanModel();
                        };

                        MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMPlan), mwqmPlanModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostAddMWQMPlanDB_FillMWQMPlan_Error_Test()
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
                        shimMWQMPlanService.FillMWQMPlanMWQMPlanMWQMPlanModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();
                        Assert.AreEqual(ErrorText, mwqmPlanModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostAddMWQMPlanDB_DoAddChanges_Error_Test()
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
                        shimMWQMPlanService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();
                        Assert.AreEqual(ErrorText, mwqmPlanModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostAddMWQMPlanDB_Add_Error_Test()
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
                        shimMWQMPlanService.FillMWQMPlanMWQMPlanMWQMPlanModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();
                        Assert.IsTrue(mwqmPlanModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostAddMWQMPlanDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();
                    Assert.IsNotNull(mwqmPlanModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mwqmPlanModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostAddMWQMPlanDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();
                    Assert.IsNotNull(mwqmPlanModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mwqmPlanModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostDeleteMWQMPlan_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMPlanModel mwqmPlanModelRet2 = mwqmPlanService.PostDeleteMWQMPlanDB(mwqmPlanModelRet.MWQMPlanID);
                        Assert.AreEqual(ErrorText, mwqmPlanModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostDeleteMWQMPlan_GetMWQMPlanWithMWQMPlanIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMPlanService.GetMWQMPlanWithMWQMPlanIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMPlanModel mwqmPlanModelRet2 = mwqmPlanService.PostDeleteMWQMPlanDB(mwqmPlanModelRet.MWQMPlanID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMPlan), mwqmPlanModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostDeleteMWQMPlan_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanModel mwqmPlanModelRet2 = mwqmPlanService.PostDeleteMWQMPlanDB(mwqmPlanModelRet.MWQMPlanID);
                        Assert.AreEqual(ErrorText, mwqmPlanModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostUpdateMWQMPlan_MWQMPlanModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanService.MWQMPlanModelOKMWQMPlanModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanModel mwqmPlanModelRet2 = UpdateMWQMPlanModel(mwqmPlanModelRet);
                        Assert.AreEqual(ErrorText, mwqmPlanModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostUpdateMWQMPlan_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMPlanModel mwqmPlanModelRet2 = UpdateMWQMPlanModel(mwqmPlanModelRet);
                        Assert.AreEqual(ErrorText, mwqmPlanModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostUpdateMWQMPlan_GetMWQMPlanWithMWQMPlanIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMPlanService.GetMWQMPlanWithMWQMPlanIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMPlanModel mwqmPlanModelRet2 = UpdateMWQMPlanModel(mwqmPlanModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMPlan), mwqmPlanModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostUpdateMWQMPlan_FillMWQMPlan_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanService.FillMWQMPlanMWQMPlanMWQMPlanModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanModel mwqmPlanModelRet2 = UpdateMWQMPlanModel(mwqmPlanModelRet);
                        Assert.AreEqual(ErrorText, mwqmPlanModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostUpdateMWQMPlan_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanModel mwqmPlanModelRet2 = UpdateMWQMPlanModel(mwqmPlanModelRet);
                        Assert.AreEqual(ErrorText, mwqmPlanModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostAddMWQMPlanAndMWQMPlanLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mwqmPlanModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMPlanService_PostAddMWQMPlanAndMWQMPlanLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel mwqmPlanModelRet = AddMWQMPlanModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mwqmPlanModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public MWQMPlanModel AddMWQMPlanModel()
        {
            TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Province);
            mwqmPlanModelNew.ProvinceTVItemID = tvItemModel.TVItemID;
            mwqmPlanModelNew.CreatorTVItemID = contactModelListGood[0].ContactTVItemID;
            FillMWQMPlanModel(mwqmPlanModelNew);

            MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.PostAddMWQMPlanDB(mwqmPlanModelNew);
            if (!string.IsNullOrWhiteSpace(mwqmPlanModelRet.Error))
            {
                return mwqmPlanModelRet;
            }

            CompareMWQMPlanModels(mwqmPlanModelNew, mwqmPlanModelRet);

            return mwqmPlanModelRet;
        }
        public MWQMPlanModel UpdateMWQMPlanModel(MWQMPlanModel mwqmPlanModel)
        {
            FillMWQMPlanModel(mwqmPlanModel);

            MWQMPlanModel mwqmPlanModelRet2 = mwqmPlanService.PostUpdateMWQMPlanDB(mwqmPlanModel);
            if (!string.IsNullOrWhiteSpace(mwqmPlanModelRet2.Error))
            {
                return mwqmPlanModelRet2;
            }

            CompareMWQMPlanModels(mwqmPlanModel, mwqmPlanModelRet2);

            return mwqmPlanModelRet2;
        }
        private void CompareMWQMPlanModels(MWQMPlanModel mwqmPlanModelNew, MWQMPlanModel mwqmPlanModelRet)
        {
            Assert.AreEqual(mwqmPlanModelNew.ConfigFileName, mwqmPlanModelRet.ConfigFileName);
            Assert.AreEqual(mwqmPlanModelNew.ForGroupName, mwqmPlanModelRet.ForGroupName);
            Assert.AreEqual(mwqmPlanModelNew.CreatorTVItemID, mwqmPlanModelRet.CreatorTVItemID);
            Assert.AreEqual(mwqmPlanModelNew.Year, mwqmPlanModelRet.Year);
            Assert.AreEqual(mwqmPlanModelNew.SecretCode, mwqmPlanModelRet.SecretCode);
        }
        private void FillMWQMPlanModel(MWQMPlanModel mwqmPlanModel)
        {
            mwqmPlanModel.ConfigFileName = "config_" + randomService.RandomString("", 20) + ".txt";
            mwqmPlanModel.ForGroupName = randomService.RandomString("", 20);
            mwqmPlanModel.CreatorTVItemID = mwqmPlanModel.CreatorTVItemID;
            mwqmPlanModel.Year = randomService.RandomInt(2000, 2050);
            mwqmPlanModel.SecretCode = randomService.RandomString("", 9);

            Assert.IsTrue(mwqmPlanModel.ConfigFileName.Length == 31);
            Assert.IsTrue(mwqmPlanModel.ForGroupName.Length == 20);
            Assert.IsTrue(mwqmPlanModel.CreatorTVItemID != 0);
            Assert.IsTrue(mwqmPlanModel.Year >= 2000 && mwqmPlanModel.Year <= 2050);
            Assert.IsTrue(mwqmPlanModel.SecretCode.Length == 9);
        }
        private FormCollection FillMWQMPlanFormCollection()
        {
            FormCollection fc = new FormCollection();
            fc.Add("ProvinceTVItemID", randomService.RandomTVItem(TVTypeEnum.Province).TVItemID.ToString());
            fc.Add("ConfigFileName", randomService.RandomString("", 23));
            fc.Add("ForGroupName", randomService.RandomString("", 23));
            fc.Add("SampleType", ((int)SampleTypeEnum.Routine).ToString());
            fc.Add("ConfigType", ((int)ConfigTypeEnum.Subsector).ToString());
            fc.Add("LabSheetType", ((int)LabSheetTypeEnum.A1).ToString());
            fc.Add("Year", randomService.RandomInt(2000, 2020).ToString());
            fc.Add("DailyDuplicatePrecisionCriteria", randomService.RandomFloat(0.3f, 0.9f).ToString());
            fc.Add("IntertechDuplicatePrecisionCriteria", randomService.RandomFloat(0.3f, 0.9f).ToString());
            fc.Add("SecretCode", randomService.RandomString("", 8));

            TVItemModel tvItemModelRoot = mwqmPlanService._TVItemService.GetRootTVItemModelDB();
            Assert.AreEqual("", tvItemModelRoot.Error);

            TVItemModel tvItemModelProvince = mwqmPlanService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, (mwqmPlanService.LanguageRequest == LanguageEnum.en ? "New Brunswick" : "Nouveau-Brunswick"), TVTypeEnum.Province);
            Assert.AreEqual("", tvItemModelProvince.Error);

            List<TVItemModel> tvItemModelSubsectorList = mwqmPlanService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelProvince.TVItemID, TVTypeEnum.Subsector);
            Assert.IsTrue(tvItemModelSubsectorList.Count > 0);

            int SubsectorCountWithSites = 0;
            foreach (TVItemModel tvItemModelSubsector in tvItemModelSubsectorList)
            {
                string Duplicate = "0";
                List<TVItemModel> tvItemModelMWQMSiteList = mwqmPlanService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.MWQMSite);

                if (tvItemModelMWQMSiteList.Count > 0)
                {
                    SubsectorCountWithSites += 1;

                    if (SubsectorCountWithSites > 4)
                    {
                        break;
                    }
                    fc.Add("SS" + tvItemModelSubsector.TVItemID, tvItemModelSubsector.TVItemID.ToString());

                    bool Even = false;
                    foreach (TVItemModel tvItemModelMWQMSite in tvItemModelMWQMSiteList)
                    {
                        if (Even)
                        {
                            fc.Add("SS" + tvItemModelSubsector.TVItemID + "_S" + tvItemModelMWQMSite.TVItemID, tvItemModelMWQMSite.TVItemID.ToString());
                            if (Duplicate == "0")
                            {
                                Duplicate = tvItemModelMWQMSite.TVItemID.ToString();
                            }
                        }
                        Even = !Even;
                    }

                }
                fc.Add("SS" + tvItemModelSubsector.TVItemID + "_D", Duplicate);
            }

            return fc;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mwqmPlanService = new MWQMPlanService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmPlanModelNew = new MWQMPlanModel();
            mwqmPlan = new MWQMPlan();
        }
        private void SetupShim()
        {
            shimMWQMPlanService = new ShimMWQMPlanService(mwqmPlanService);
            shimAppTaskService = new ShimAppTaskService(mwqmPlanService._AppTaskService);
            shimTVItemService = new ShimTVItemService(mwqmPlanService._TVItemService);
            shimTVFileService = new ShimTVFileService(mwqmPlanService._TVFileService);
        }
        #endregion Functions private
    }
}

