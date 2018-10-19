using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPWebToolsDBDLL.Tests.SetupInfo;
using CSSPWebToolsDBDLL.Models;
using System.Security.Principal;
using CSSPWebToolsDBDLL.Services;
using CSSPWebToolsDBDLL.Services.Resources;
using System.Transactions;
using CSSPWebToolsDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Linq;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for BoxModelServiceTest
    /// </summary>
    [TestClass]
    public class BoxModelServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "BoxModel";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private BoxModelService boxModelService { get; set; }
        private BoxModelLanguageService boxModelLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private BoxModelModel boxModelModelNew { get; set; }
        private BoxModel boxModel { get; set; }
        private ShimBoxModelService shimBoxModelService { get; set; }
        private ShimBoxModelLanguageService shimBoxModelLanguageService { get; set; }
        private FormCollection formCollection { get; set; }
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
        public BoxModelServiceTest()
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

        #region Testing Methods Public
        [TestMethod]
        public void BoxModelService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(boxModelService);
                Assert.IsNotNull(boxModelService._BoxModelLanguageService);
                Assert.IsNotNull(boxModelService._BoxModelResultService);
                Assert.IsNotNull(boxModelService.db);
                Assert.IsNotNull(boxModelService.LanguageRequest);
                Assert.IsNotNull(boxModelService.User);
                Assert.AreEqual(user.Identity.Name, boxModelService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), boxModelService.LanguageRequest);
            }
        }
        [TestMethod]
        public void BoxModelService_BoxModelModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModel = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModel.Error);

                    #region Good
                    boxModelModelNew.InfrastructureTVItemID = boxModelModel.InfrastructureTVItemID;
                    FillBoxModelModel(boxModelModelNew);

                    string retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region InfrastructureTVItemID
                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.InfrastructureTVItemID = 0;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfraTVItemID), retStr);

                    boxModelModelNew.InfrastructureTVItemID = boxModelModel.InfrastructureTVItemID;
                    FillBoxModelModel(boxModelModelNew);

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion InfrastructureTVItemID

                    #region ScenarioName
                    int MinInt = 2;
                    int MaxInt = 100;
                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.ScenarioName = randomService.RandomString("", MinInt - 1);

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.ScenarioName, MinInt), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.ScenarioName = randomService.RandomString("", MaxInt + 1);

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ScenarioName, MaxInt), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.ScenarioName = randomService.RandomString("", MaxInt - 1);

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.ScenarioName = randomService.RandomString("", MinInt);

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.ScenarioName = randomService.RandomString("", MaxInt);

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion ScenarioName

                    #region Flow_m3_day
                    double Min = 1D;
                    double Max = 30000000D;
                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Flow_m3_day = Min - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Flow_m3_day, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Flow_m3_day = Max + 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Flow_m3_day, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Flow_m3_day = Max - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Flow_m3_day = Min;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Flow_m3_day = Max;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Flow_m3_day

                    #region Depth_m
                    Min = 0.01D;
                    Max = 10000D;
                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Depth_m = Min - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Depth_m, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Depth_m = Max + 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Depth_m, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Depth_m = Max - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Depth_m = Min;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Depth_m = Max;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Depth_m

                    #region Temperature_C
                    Min = 0.1D;
                    Max = 35D;
                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Temperature_C = Min - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Temperature_C, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Temperature_C = Max + 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Temperature_C, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Temperature_C = Max - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Temperature_C = Min;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Temperature_C = Max;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Temperature_C

                    #region Dilution
                    Min = 1D;
                    Max = 30000000D;
                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Dilution = Min - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Dilution, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Dilution = Max + 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Dilution, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Dilution = Max - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Dilution = Min;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Dilution = Max;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Dilution

                    #region DecayRate_per_day
                    Min = 0.0001D;
                    Max = 1000D;
                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.DecayRate_per_day = Min - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DecayRate_per_day, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.DecayRate_per_day = Max + 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DecayRate_per_day, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.DecayRate_per_day = Max - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.DecayRate_per_day = Min;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.DecayRate_per_day = Max;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion DecayRate_per_day

                    #region FCUntreated_MPN_100ml
                    MinInt = 1;
                    MaxInt = 30000000;
                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FCUntreated_MPN_100ml = MinInt - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FCUntreated_MPN_100ml, MinInt, MaxInt), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FCUntreated_MPN_100ml = MaxInt + 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FCUntreated_MPN_100ml, MinInt, MaxInt), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FCUntreated_MPN_100ml = MaxInt - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FCUntreated_MPN_100ml = MinInt;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FCUntreated_MPN_100ml = MaxInt;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion FCUntreated_MPN_100ml

                    #region FCPreDisinfection_MPN_100ml
                    MinInt = 1;
                    MaxInt = 30000000;
                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FCPreDisinfection_MPN_100ml = MinInt - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FCPreDisinfection_MPN_100ml, MinInt, MaxInt), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FCPreDisinfection_MPN_100ml = MaxInt + 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FCPreDisinfection_MPN_100ml, MinInt, MaxInt), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FCPreDisinfection_MPN_100ml = MaxInt - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FCPreDisinfection_MPN_100ml = MinInt;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FCPreDisinfection_MPN_100ml = MaxInt;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion FCPreDisinfection_MPN_100ml

                    #region Concentration_MPN_100ml
                    MinInt = 1;
                    MaxInt = 30000000;
                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Concentration_MPN_100ml = MinInt - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Concentration_MPN_100ml, MinInt, MaxInt), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Concentration_MPN_100ml = MaxInt + 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Concentration_MPN_100ml, MinInt, MaxInt), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Concentration_MPN_100ml = MaxInt - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Concentration_MPN_100ml = MinInt;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.Concentration_MPN_100ml = MaxInt;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Concentration_MPN_100ml

                    #region FlowDuration_hour
                    Min = 1;
                    Max = 24;
                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FlowDuration_hour = Min - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FlowDuration_hour, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FlowDuration_hour = Max + 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FlowDuration_hour, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FlowDuration_hour = Max - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FlowDuration_hour = Min;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.FlowDuration_hour = Max;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion FlowDuration_hour

                    #region T90_hour
                    Min = 1;
                    Max = 1000;
                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.T90_hour = Min - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.T90_hour, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.T90_hour = Max + 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.T90_hour, Min, Max), retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.T90_hour = Max - 1;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.T90_hour = Min;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    FillBoxModelModel(boxModelModelNew);
                    boxModelModelNew.T90_hour = Max;

                    retStr = boxModelService.BoxModelModelOK(boxModelModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion T90_hour
                }
            }
        }
        [TestMethod]
        public void BoxModelService_CheckUniquenessOfBoxModelScenarioNameDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModel = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModel.Error);

                    string retStr = boxModelService.CheckUniquenessOfBoxModelScenarioNameDB(boxModelModel.InfrastructureTVItemID, boxModelModel.BoxModelID, boxModelModel.ScenarioName);
                    Assert.AreEqual("true", retStr);

                    string PreviousBoxModelScenarioName = boxModelModel.ScenarioName;
                    boxModelModel.ScenarioName = "new" + boxModelModel.ScenarioName;
                    BoxModelModel boxModelModel2 = boxModelService.PostAddBoxModelDB(boxModelModel);
                    Assert.AreEqual("", boxModelModel2.Error);

                    retStr = boxModelService.CheckUniquenessOfBoxModelScenarioNameDB(boxModelModel.InfrastructureTVItemID, boxModelModel2.BoxModelID, PreviousBoxModelScenarioName);
                    Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, PreviousBoxModelScenarioName), retStr);

                }
            }
        }
        [TestMethod]
        public void BoxModelService_FillBoxModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModel = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModel.Error);

                    boxModelModelNew.InfrastructureTVItemID = boxModelModel.InfrastructureTVItemID;

                    FillBoxModelModel(boxModelModelNew);

                    ContactOK contactOK = boxModelService.IsContactOK();

                    string retStr = boxModelService.FillBoxModel(boxModel, boxModelModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, boxModel.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = boxModelService.FillBoxModel(boxModel, boxModelModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, boxModel.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_GetBoxModelModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    int boxModelCount = boxModelService.GetBoxModelModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, boxModelCount);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_GetBoxModelModelOrderByScenarioNameDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    List<BoxModelModel> boxModelModelList = boxModelService.GetBoxModelModelOrderByScenarioNameDB(boxModelModelRet.InfrastructureTVItemID);
                    Assert.IsTrue(boxModelModelList.Where(c => c.InfrastructureTVItemID == boxModelModelRet.InfrastructureTVItemID).Any());

                    int InfrastructureTVItemID = 0;
                    boxModelModelList = boxModelService.GetBoxModelModelOrderByScenarioNameDB(InfrastructureTVItemID);
                    Assert.AreEqual(0, boxModelModelList.Count);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_GetBoxModelModelWithBoxModelIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelModel boxModelModelRet2 = boxModelService.GetBoxModelModelWithBoxModelIDDB(boxModelModelRet.BoxModelID);
                    Assert.AreEqual(boxModelModelRet.BoxModelID, boxModelModelRet2.BoxModelID);

                    int BoxModelID = 0;
                    BoxModelModel boxModelModelRet3 = boxModelService.GetBoxModelModelWithBoxModelIDDB(BoxModelID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModel, ServiceRes.BoxModelID, BoxModelID), boxModelModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_GetBoxModelModelWithInfrastructureTVItemIDAndScenarioNameDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelModel boxModelModelRet2 = boxModelService.GetBoxModelModelWithInfrastructureTVItemIDAndScenarioNameDB(boxModelModelRet.InfrastructureTVItemID, boxModelModelRet.ScenarioName);
                    Assert.AreEqual(boxModelModelRet.BoxModelID, boxModelModelRet2.BoxModelID);

                    int InfrastructureTVItemID = 0;
                    BoxModelModel boxModelModelRet3 = boxModelService.GetBoxModelModelWithInfrastructureTVItemIDAndScenarioNameDB(InfrastructureTVItemID, boxModelModelRet.ScenarioName);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModel, ServiceRes.InfrastructureTVItemID + "," + ServiceRes.ScenarioName, InfrastructureTVItemID + "," + boxModelModelRet.ScenarioName), boxModelModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_GetBoxModelWithBoxModelIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModel boxModelRet = boxModelService.GetBoxModelWithBoxModelIDDB(boxModelModelRet.BoxModelID);
                    Assert.AreEqual(boxModelModelRet.BoxModelID, boxModelRet.BoxModelID);

                    BoxModel boxModelRet2 = boxModelService.GetBoxModelWithBoxModelIDDB(0);
                    Assert.IsNull(boxModelRet2);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_GetBoxModelWithInfrastructureTVItemIDAndScenarioNameDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModel boxModelRet = boxModelService.GetBoxModelWithInfrastructureTVItemIDAndScenarioNameDB(boxModelModelRet.InfrastructureTVItemID, boxModelModelRet.ScenarioName);
                    Assert.AreEqual(boxModelModelRet.BoxModelID, boxModelRet.BoxModelID);

                    int InfraTVItemID = boxModelModelRet.InfrastructureTVItemID;
                    string ScenarioName = boxModelModelRet.ScenarioName + "not";
                    BoxModel boxModelRet2 = boxModelService.GetBoxModelWithInfrastructureTVItemIDAndScenarioNameDB(InfraTVItemID, ScenarioName);
                    Assert.IsNull(boxModelRet2);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_AddOrUpdateBoxModelResultModel_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    double DilutionOld = boxModelModelRet.Dilution;
                    double ConcentrationOld = boxModelModelRet.Concentration_MPN_100ml;

                    boxModelModelRet.Dilution = boxModelModelRet.Dilution + 5;
                    boxModelModelRet.Concentration_MPN_100ml = boxModelModelRet.Concentration_MPN_100ml + 100;

                    BoxModelModel boxModelModelRet2 = boxModelService.PostUpdateBoxModelDB(boxModelModelRet);

                    BoxModelModel boxModelModelRet3 = boxModelService.AddOrUpdateBoxModelResultModel(boxModelModelRet2);
                    Assert.AreEqual("", boxModelModelRet3.Error);
                    Assert.AreEqual(DilutionOld + 5, boxModelModelRet3.Dilution);
                    Assert.AreEqual(ConcentrationOld + 100, boxModelModelRet3.Concentration_MPN_100ml);

                    boxModelModelRet2.FixLength = true;
                    boxModelModelRet2.Length_m = 400;
                    boxModelModelRet3 = boxModelService.AddOrUpdateBoxModelResultModel(boxModelModelRet2);
                    Assert.AreEqual("", boxModelModelRet3.Error);
                    Assert.AreEqual(DilutionOld + 5, boxModelModelRet3.Dilution);
                    Assert.AreEqual(ConcentrationOld + 100, boxModelModelRet3.Concentration_MPN_100ml);

                    boxModelModelRet2.FixLength = false;
                    boxModelModelRet2.Length_m = 0;
                    boxModelModelRet2.FixWidth = true;
                    boxModelModelRet2.Width_m = 400;
                    boxModelModelRet3 = boxModelService.AddOrUpdateBoxModelResultModel(boxModelModelRet2);
                    Assert.AreEqual("", boxModelModelRet3.Error);
                    Assert.AreEqual(DilutionOld + 5, boxModelModelRet3.Dilution);
                    Assert.AreEqual(ConcentrationOld + 100, boxModelModelRet3.Concentration_MPN_100ml);

                    boxModelModelRet2.FixLength = false;
                    boxModelModelRet2.Length_m = 0;
                    boxModelModelRet2.FixWidth = false;
                    boxModelModelRet2.Width_m = 0;
                    boxModelModelRet2.BoxModelID = 0;
                    boxModelModelRet3 = boxModelService.AddOrUpdateBoxModelResultModel(boxModelModelRet2);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.BoxModelID), boxModelModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_AddOrUpdateBoxModelResultModel_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    double DilutionOld = boxModelModelRet.Dilution;
                    double ConcentrationOld = boxModelModelRet.Concentration_MPN_100ml;

                    boxModelModelRet.Dilution = boxModelModelRet.Dilution + 5;
                    boxModelModelRet.Concentration_MPN_100ml = boxModelModelRet.Concentration_MPN_100ml + 100;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.AddOrUpdateBoxModelResultModel(boxModelModelRet);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_CalculateDecayDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    double T90_hour = 6;
                    double Temperature_C = 10;

                    CalDecay calDecay = boxModelService.CalculateDecayDB(T90_hour, Temperature_C);
                    Assert.AreEqual("", calDecay.Error);
                    Assert.AreEqual(4.6821, calDecay.Decay, 0.001);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_CalculateDecayDB_T90_hour_0_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    double T90_hour = 0;
                    double Temperature_C = 10;

                    CalDecay calDecay = boxModelService.CalculateDecayDB(T90_hour, Temperature_C);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.T90_hour), calDecay.Error);
                    Assert.AreEqual(-1, calDecay.Decay, 0.001);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_CalculateDecayDB_Temperature_C_0_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    double T90_hour = 6;
                    double Temperature_C = 0;

                    CalDecay calDecay = boxModelService.CalculateDecayDB(T90_hour, Temperature_C);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Temperature_C), calDecay.Error);
                    Assert.AreEqual(-1, calDecay.Decay, 0.001);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_CopyBoxModelScenarioDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelModel boxModelModelRet2 = boxModelService.CopyBoxModelScenarioDB(boxModelModelRet.BoxModelID);
                    Assert.AreEqual("", boxModelModelRet2.Error);
                    Assert.AreEqual(boxModelModelRet.InfrastructureTVItemID, boxModelModelRet2.InfrastructureTVItemID);
                    Assert.AreEqual(boxModelModelRet.Dilution, boxModelModelRet2.Dilution);
                    Assert.AreEqual(boxModelModelRet.Flow_m3_day, boxModelModelRet2.Flow_m3_day);
                    Assert.AreEqual("_ " + ServiceRes.CopyOf + " " + boxModelModelRet.ScenarioName, boxModelModelRet2.ScenarioName);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_CopyBoxModelScenarioDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.CopyBoxModelScenarioDB(boxModelModelRet.BoxModelID);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_CopyBoxModelScenarioDB_GetBoxModelModelWithBoxModelIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelService.GetBoxModelModelWithBoxModelIDDBInt32 = (a) =>
                        {
                            return new BoxModelModel() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.CopyBoxModelScenarioDB(boxModelModelRet.BoxModelID);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_CopyBoxModelScenarioDB_PostAddBoxModelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelService.PostAddBoxModelDBBoxModelModel = (a) =>
                        {
                            return new BoxModelModel() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.CopyBoxModelScenarioDB(boxModelModelRet.BoxModelID);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_CreateNewBMScenarioDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelModel boxModelModelRet2 = boxModelService.CreateNewBMScenarioDB(boxModelModelRet.InfrastructureTVItemID);
                    Assert.AreEqual("", boxModelModelRet2.Error);

                    int InfrastructureTVItemID = 0;
                    boxModelModelRet2 = boxModelService.CreateNewBMScenarioDB(InfrastructureTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID), boxModelModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void BoxModelService_CreateNewBMScenarioDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.CreateNewBMScenarioDB(boxModelModelRet.InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_CreateNewBMScenarioDB_PostAddBoxModelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelService.PostAddBoxModelDBBoxModelModel = (a) =>
                        {
                            return new BoxModelModel() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.CreateNewBMScenarioDB(boxModelModelRet.InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    BoxModelModel boxModelModel = boxModelService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, boxModelModel.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, "", "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual("", boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, "", "");
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_GetBoxModelModelWithBoxModelIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, "", "");
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelService.GetBoxModelModelWithBoxModelIDDBInt32 = (a) =>
                        {
                            return new BoxModelModel() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_CheckUniquenessOfBoxModelScenarioNameDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, "", "");
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelService.CheckUniquenessOfBoxModelScenarioNameDBInt32Int32String = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_BoxModelID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Key = "BoxModelID";
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, Key, "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.BoxModelID), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, Key, null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.BoxModelID), boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_ScenarioName_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Key = "ScenarioName";
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, Key, "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ScenarioName), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, Key, null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ScenarioName), boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_T90_hour_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Key = "T90_hour";
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, Key, "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.T90_hour), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, Key, null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.T90_hour), boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_Temperature_C_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Key = "Temperature_C";
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, Key, "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Temperature_C), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, Key, null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Temperature_C), boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_DecayRate_per_day_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Key = "DecayRate_per_day";
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, Key, "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.DecayRate_per_day), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, Key, null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.DecayRate_per_day), boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_Flow_m3_day_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Key = "Flow_m3_day";
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, Key, "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Flow_m3_day), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, Key, null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Flow_m3_day), boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_FlowDuration_hour_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Key = "FlowDuration_hour";
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, Key, "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FlowDuration_hour), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, Key, null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FlowDuration_hour), boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_Dilution_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Key = "Dilution";
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, Key, "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Dilution), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, Key, null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Dilution), boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_Depth_m_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Key = "Depth_m";
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, Key, "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Depth_m), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, Key, null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Depth_m), boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_FCUntreated_MPN_100ml_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Key = "FCUntreated_MPN_100ml";
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, Key, "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FCUntreated_MPN_100ml), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, Key, null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FCUntreated_MPN_100ml), boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_FCPreDisinfection_MPN_100ml_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Key = "FCPreDisinfection_MPN_100ml";
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, Key, "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FCPreDisinfection_MPN_100ml), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, Key, null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FCPreDisinfection_MPN_100ml), boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_Concentration_MPN_100ml_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Key = "Concentration_MPN_100ml";
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, Key, "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Concentration_MPN_100ml), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, Key, null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Concentration_MPN_100ml), boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_Length_m_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, "", "");
                    formCollection.Add("FixLength", "true");
                    formCollection.Add("Length_m", "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Length_m), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, "", "");
                    formCollection.Add("FixLength", "true");
                    formCollection.Add("Length_m", null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Length_m), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, "", "");
                    formCollection.Add("FixLength", "true");
                    formCollection.Add("Length_m", "-1");

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Length_m), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, "", "");
                    formCollection.Add("FixLength", "true");
                    formCollection.Add("Length_m", randomService.RandomFloat(0.3f, 0.4f).ToString());

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(ServiceRes.LengthShouldNotBeZeroWhenFixLengthIsChecked, boxModelModelRet2.Error);

                    if (culture.TwoLetterISOLanguageName == "fr")
                    {
                        Assert.IsTrue(randomService.RandomFloat(0.3f, 0.4f).ToString().Contains(","));
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_Width_m_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, "", "");
                    formCollection.Add("FixWidth", "true");
                    formCollection.Add("Width_m", "");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Width_m), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, "", "");
                    formCollection.Add("FixWidth", "true");
                    formCollection.Add("Width_m", null);

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Width_m), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, "", "");
                    formCollection.Add("FixWidth", "true");
                    formCollection.Add("Width_m", "-1");

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Width_m), boxModelModelRet2.Error);

                    FillForm(boxModelModelRet, "", "");
                    formCollection.Add("FixWidth", "true");
                    formCollection.Add("Width_m", randomService.RandomFloat(0.3f, 0.4f).ToString());

                    boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(ServiceRes.WidthShouldNotBeZeroWhenFixWidthIsChecked, boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_FixWidth_And_FixLength_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, "", "");
                    formCollection.Add("FixLength", "true");
                    formCollection.Add("Length_m", "12");
                    formCollection.Add("FixWidth", "true");
                    formCollection.Add("Width_m", "100");

                    BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                    Assert.AreEqual(ServiceRes.FixLengthAndFixWidthShouldNotBeCheckedAtTheSameTime, boxModelModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_PostUpdateBoxModelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, "", "");

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelService.PostUpdateBoxModelDBBoxModelModel = (a) =>
                        {
                            return new BoxModelModel() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_SaveBoxModelScenarioDB_AddOrUpdateBoxModelResultModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillForm(boxModelModelRet, "", "");

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelService.AddOrUpdateBoxModelResultModelBoxModelModel = (a) =>
                        {
                            return new BoxModelModel() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.SaveBoxModelScenarioDB(formCollection);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostAddUpdateDeleteBoxModel_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelModel boxModelModelRet2 = UpdateBoxModelModel(boxModelModelRet);
                    Assert.AreEqual("", boxModelModelRet2.Error);

                    BoxModelModel boxModelModelRet3 = boxModelService.PostDeleteBoxModelDB(boxModelModelRet2.BoxModelID);
                    Assert.AreEqual("", boxModelModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostAddBoxModelDB_BoxModelModelOK_Error_Test()
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
                        shimBoxModelService.BoxModelModelOKBoxModelModel = (a) =>
                        {
                            return ErrorText;
                        };

                        BoxModelModel boxModelModelRet = AddBoxModelModel();
                        Assert.AreEqual(ErrorText, boxModelModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostAddBoxModelDB_IsContactOK_Error_Test()
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
                        shimBoxModelService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet = AddBoxModelModel();
                        Assert.AreEqual(ErrorText, boxModelModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostAddBoxModelDB_GetBoxModelWithInfrastructureTVItemIDAndScenarioNameDB_Error_Test()
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
                        shimBoxModelService.GetBoxModelWithInfrastructureTVItemIDAndScenarioNameDBInt32String = (a, b) =>
                        {
                            return new BoxModel();
                        };

                        BoxModelModel boxModelModelRet = AddBoxModelModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.BoxModel), boxModelModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostAddBoxModelDB_FillBoxModel_Error_Test()
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
                        shimBoxModelService.FillBoxModelBoxModelBoxModelModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        BoxModelModel boxModelModelRet = AddBoxModelModel();
                        Assert.AreEqual(ErrorText, boxModelModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostAddBoxModelDB_DoAddChanges_Error_Test()
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
                        shimBoxModelService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        BoxModelModel boxModelModelRet = AddBoxModelModel();
                        Assert.AreEqual(ErrorText, boxModelModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostAddBoxModelDB_Add_Error_Test()
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
                        shimBoxModelService.FillBoxModelBoxModelBoxModelModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        BoxModelModel boxModelModelRet = AddBoxModelModel();
                        Assert.IsTrue(boxModelModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostAddBoxModelDB_PostAddBoxModelLanguageDB_Error_Test()
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
                        shimBoxModelLanguageService.PostAddBoxModelLanguageDBBoxModelLanguageModel = (a) =>
                        {
                            return new BoxModelLanguageModel() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet = AddBoxModelModel();
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotAddError_, ErrorText), boxModelModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostAddBoxModelDB_AddOrUpdateBoxModelResultModel_Error_Test()
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
                        shimBoxModelService.AddOrUpdateBoxModelResultModelBoxModelModel = (a) =>
                        {
                            return new BoxModelModel() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet = AddBoxModelModel();
                        Assert.AreEqual(ErrorText, boxModelModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostAddBoxModelDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.IsNotNull(boxModelModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, boxModelModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostAddBoxModelDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.IsNotNull(boxModelModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, boxModelModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostDeleteBoxModel_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimBoxModelService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.PostDeleteBoxModelDB(boxModelModelRet.BoxModelID);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostDeleteBoxModel_GetBoxModelWithBoxModelIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimBoxModelService.GetBoxModelWithBoxModelIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.PostDeleteBoxModelDB(boxModelModelRet.BoxModelID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.BoxModel), boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostDeleteBoxModel_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimBoxModelService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        BoxModelModel boxModelModelRet2 = boxModelService.PostDeleteBoxModelDB(boxModelModelRet.BoxModelID);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostUpdateBoxModel_BoxModelModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimBoxModelService.BoxModelModelOKBoxModelModel = (a) =>
                        {
                            return ErrorText;
                        };

                        BoxModelModel boxModelModelRet2 = UpdateBoxModelModel(boxModelModelRet);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostUpdateBoxModel_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimBoxModelService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = UpdateBoxModelModel(boxModelModelRet);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostUpdateBoxModel_GetBoxModelWithBoxModelIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimBoxModelService.GetBoxModelWithBoxModelIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        BoxModelModel boxModelModelRet2 = UpdateBoxModelModel(boxModelModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.BoxModel), boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostUpdateBoxModel_FillBoxModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimBoxModelService.FillBoxModelBoxModelBoxModelModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        BoxModelModel boxModelModelRet2 = UpdateBoxModelModel(boxModelModelRet);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostUpdateBoxModel_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimBoxModelService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        BoxModelModel boxModelModelRet2 = UpdateBoxModelModel(boxModelModelRet);
                        Assert.AreEqual(ErrorText, boxModelModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelService_PostUpdateBoxModel_PostUpdateBoxModelLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimBoxModelLanguageService.PostUpdateBoxModelLanguageDBBoxModelLanguageModel = (a) =>
                        {
                            return new BoxModelLanguageModel() { Error = ErrorText };
                        };

                        BoxModelModel boxModelModelRet2 = UpdateBoxModelModel(boxModelModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotAddError_, ErrorText), boxModelModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions
        public BoxModelModel AddBoxModelModel()
        {
            TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Infrastructure);

            Assert.AreEqual("", tvItemModel.Error);

            boxModelModelNew.InfrastructureTVItemID = tvItemModel.TVItemID;
            FillBoxModelModel(boxModelModelNew);

            BoxModelModel boxModelModelRet = boxModelService.PostAddBoxModelDB(boxModelModelNew);
            if (!string.IsNullOrWhiteSpace(boxModelModelRet.Error))
            {
                return boxModelModelRet;
            }

            CompareBoxModelModels(boxModelModelNew, boxModelModelRet);

            return boxModelModelRet;
        }
        public BoxModelModel UpdateBoxModelModel(BoxModelModel boxModelModel)
        {
            FillBoxModelModel(boxModelModel);

            BoxModelModel boxModelModelRet2 = boxModelService.PostUpdateBoxModelDB(boxModelModel);
            if (!string.IsNullOrWhiteSpace(boxModelModelRet2.Error))
            {
                return boxModelModelRet2;
            }

            CompareBoxModelModels(boxModelModel, boxModelModelRet2);

            return boxModelModelRet2;
        }
        public BoxModelModel AddBoxModelModelSpecific()
        {
            FillBoxModelModelSpecific(boxModelModelNew);

            BoxModelModel boxModelModelRet = boxModelService.PostAddBoxModelDB(boxModelModelNew);
            if (!string.IsNullOrWhiteSpace(boxModelModelRet.Error))
            {
                return boxModelModelRet;
            }

            CompareBoxModelModels(boxModelModelNew, boxModelModelRet);

            return boxModelModelRet;
        }
        private void CompareBoxModelModels(BoxModelModel boxModelModelNew, BoxModelModel boxModelModelRet)
        {
            Assert.AreEqual(boxModelModelNew.InfrastructureTVItemID, boxModelModelRet.InfrastructureTVItemID);
            Assert.AreEqual(boxModelModelNew.ScenarioName, boxModelModelRet.ScenarioName);
            Assert.AreEqual(boxModelModelNew.T90_hour, boxModelModelRet.T90_hour);
            Assert.AreEqual(boxModelModelNew.Temperature_C, boxModelModelRet.Temperature_C);
            Assert.AreEqual(boxModelModelNew.DecayRate_per_day, boxModelModelRet.DecayRate_per_day);
            Assert.AreEqual(boxModelModelNew.Flow_m3_day, boxModelModelRet.Flow_m3_day);
            Assert.AreEqual(boxModelModelNew.FlowDuration_hour, boxModelModelRet.FlowDuration_hour);
            Assert.AreEqual(boxModelModelNew.Dilution, boxModelModelRet.Dilution);
            Assert.AreEqual(boxModelModelNew.Depth_m, boxModelModelRet.Depth_m);
            Assert.AreEqual(boxModelModelNew.FCUntreated_MPN_100ml, boxModelModelRet.FCUntreated_MPN_100ml);
            Assert.AreEqual(boxModelModelNew.FCPreDisinfection_MPN_100ml, boxModelModelRet.FCPreDisinfection_MPN_100ml);
            Assert.AreEqual(boxModelModelNew.Concentration_MPN_100ml, boxModelModelRet.Concentration_MPN_100ml);
            Assert.AreEqual(boxModelModelNew.FixLength, boxModelModelRet.FixLength);
            Assert.AreEqual(boxModelModelNew.Length_m, boxModelModelRet.Length_m);
            Assert.AreEqual(boxModelModelNew.FixWidth, boxModelModelRet.FixWidth);
            Assert.AreEqual(boxModelModelNew.Width_m, boxModelModelRet.Width_m);

            foreach (LanguageEnum Lang in boxModelService.LanguageListAllowable)
            {
                if (Lang == boxModelService.LanguageRequest)
                {
                    BoxModelLanguageModel boxModelLanguageModel = boxModelService._BoxModelLanguageService.GetBoxModelLanguageModelWithBoxModelIDAndLanguageDB(boxModelModelRet.BoxModelID, Lang);
                    Assert.AreEqual(boxModelModelRet.ScenarioName, boxModelLanguageModel.ScenarioName);
                }
            }
        }
        private void FillBoxModelModel(BoxModelModel boxModelModel)
        {
            boxModelModel.InfrastructureTVItemID = boxModelModel.InfrastructureTVItemID;
            boxModelModel.ScenarioName = randomService.RandomString("ScenarioName", 20);
            boxModelModel.T90_hour = randomService.RandomInt(5, 7);
            boxModelModel.Temperature_C = randomService.RandomInt(9, 12);
            boxModelModel.DecayRate_per_day = randomService.RandomFloat(4.0f, 6.0f);
            boxModelModel.Flow_m3_day = randomService.RandomFloat(1000.0f, 2000.0f);
            boxModelModel.FlowDuration_hour = randomService.RandomInt(20, 24);
            boxModelModel.Dilution = randomService.RandomFloat(1000.000f, 1001.0f);
            boxModelModel.Depth_m = randomService.RandomFloat(2.0f, 4.0f);
            boxModelModel.FCUntreated_MPN_100ml = randomService.RandomInt(3000000, 3600000);
            boxModelModel.FCPreDisinfection_MPN_100ml = randomService.RandomInt(700, 900);
            boxModelModel.Concentration_MPN_100ml = randomService.RandomInt(14, 14);
            boxModelModel.FixLength = false;
            boxModelModel.Length_m = 0;
            boxModelModel.FixWidth = false;
            boxModelModel.Width_m = 0;

            Assert.IsTrue(boxModelModel.InfrastructureTVItemID != 0);
            Assert.IsTrue(boxModelModel.ScenarioName.Length == 20);
            Assert.IsTrue(boxModelModel.T90_hour >= 5 && boxModelModel.T90_hour <= 7);
            Assert.IsTrue(boxModelModel.Temperature_C >= 9 && boxModelModel.Temperature_C <= 12);
            Assert.IsTrue(boxModelModel.DecayRate_per_day >= 4.0f && boxModelModel.DecayRate_per_day <= 6.0f);
            Assert.IsTrue(boxModelModel.Flow_m3_day >= 1000.0f && boxModelModel.Flow_m3_day <= 2000.0f);
            Assert.IsTrue(boxModelModel.FlowDuration_hour >= 20 && boxModelModel.FlowDuration_hour <= 24);
            Assert.IsTrue(boxModelModel.Dilution >= 1000.0f && boxModelModel.Dilution <= 1001.0f);
            Assert.IsTrue(boxModelModel.Depth_m >= 2.0f && boxModelModel.Depth_m <= 4.0f);
            Assert.IsTrue(boxModelModel.FCUntreated_MPN_100ml >= 3000000.0f && boxModelModel.FCUntreated_MPN_100ml <= 3600000.0f);
            Assert.IsTrue(boxModelModel.FCPreDisinfection_MPN_100ml >= 700.0f && boxModelModel.FCPreDisinfection_MPN_100ml <= 900.0f);
            Assert.IsTrue(boxModelModel.Concentration_MPN_100ml >= 14 && boxModelModel.Concentration_MPN_100ml <= 14);
            Assert.IsFalse(boxModelModel.FixLength);
            Assert.IsTrue(boxModelModel.Length_m == 0);
            Assert.IsFalse(boxModelModel.FixWidth);
            Assert.IsTrue(boxModelModel.Width_m == 0);

        }
        private void FillBoxModelModelSpecific(BoxModelModel boxModelModel)
        {
            boxModelModel.InfrastructureTVItemID = randomService.RandomTVItem(TVTypeEnum.Infrastructure).TVItemID;
            boxModelModel.ScenarioName = "ScenarioName Specific";
            boxModelModel.T90_hour = 6;
            boxModelModel.Temperature_C = 10;
            boxModelModel.DecayRate_per_day = 4.6821;
            boxModelModel.Flow_m3_day = 1234;
            boxModelModel.FlowDuration_hour = 24;
            boxModelModel.Dilution = 1000;
            boxModelModel.Depth_m = 3;
            boxModelModel.FCUntreated_MPN_100ml = 3000000;
            boxModelModel.FCPreDisinfection_MPN_100ml = 800;
            boxModelModel.Concentration_MPN_100ml = 14;
            boxModelModel.FixLength = false;
            boxModelModel.Length_m = 0;
            boxModelModel.FixWidth = false;
            boxModelModel.Width_m = 0;

            Assert.IsTrue(boxModelModel.InfrastructureTVItemID != 0);
            Assert.IsTrue(boxModelModel.ScenarioName == "ScenarioName Specific");
            Assert.IsTrue(boxModelModel.T90_hour == 6);
            Assert.IsTrue(boxModelModel.Temperature_C == 10);
            Assert.IsTrue(boxModelModel.DecayRate_per_day == 4.6821);
            Assert.IsTrue(boxModelModel.Flow_m3_day == 1234);
            Assert.IsTrue(boxModelModel.FlowDuration_hour == 24);
            Assert.IsTrue(boxModelModel.Dilution == 1000);
            Assert.IsTrue(boxModelModel.Depth_m == 3);
            Assert.IsTrue(boxModelModel.FCUntreated_MPN_100ml == 3000000);
            Assert.IsTrue(boxModelModel.FCPreDisinfection_MPN_100ml == 800);
            Assert.IsTrue(boxModelModel.Concentration_MPN_100ml == 14);
            Assert.IsFalse(boxModelModel.FixLength);
            Assert.IsTrue(boxModelModel.Length_m == 0);
            Assert.IsFalse(boxModelModel.FixWidth);
            Assert.IsTrue(boxModelModel.Width_m == 0);

        }
        private void FillForm(BoxModelModel boxModelModel, string key, string value)
        {
            formCollection.Clear();
            formCollection.Add("BoxModelID", (key == "BoxModelID" ? value : boxModelModel.BoxModelID.ToString()));
            formCollection.Add("ScenarioName", (key == "ScenarioName" ? value : boxModelModel.ScenarioName));
            formCollection.Add("T90_hour", (key == "T90_hour" ? value : boxModelModel.T90_hour.ToString()));
            formCollection.Add("Temperature_C", (key == "Temperature_C" ? value : boxModelModel.Temperature_C.ToString()));
            formCollection.Add("DecayRate_per_day", (key == "DecayRate_per_day" ? value : boxModelModel.DecayRate_per_day.ToString()));
            formCollection.Add("Flow_m3_day", (key == "Flow_m3_day" ? value : boxModelModel.Flow_m3_day.ToString()));
            formCollection.Add("FlowDuration_hour", (key == "FlowDuration_hour" ? value : boxModelModel.FlowDuration_hour.ToString()));
            formCollection.Add("Dilution", (key == "Dilution" ? value : boxModelModel.Dilution.ToString()));
            formCollection.Add("Depth_m", (key == "Depth_m" ? value : boxModelModel.Depth_m.ToString()));
            formCollection.Add("FCUntreated_MPN_100ml", (key == "FCUntreated_MPN_100ml" ? value : boxModelModel.FCUntreated_MPN_100ml.ToString()));
            formCollection.Add("FCPreDisinfection_MPN_100ml", (key == "FCPreDisinfection_MPN_100ml" ? value : boxModelModel.FCPreDisinfection_MPN_100ml.ToString()));
            formCollection.Add("Concentration_MPN_100ml", (key == "Concentration_MPN_100ml" ? value : boxModelModel.Concentration_MPN_100ml.ToString()));
            //formCollection.Add("FixLength", (key == "FixLength" ? value : null));
            //formCollection.Add("FixWidth", (key == "FixWidth" ? value : null));
            //formCollection.Add("Length_m", (key == "Length_m" ? value : "0.0"));
            //formCollection.Add("Width_m", (key == "Width_m" ? value : "0.0"));

        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            boxModelService = new BoxModelService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            boxModelLanguageService = new BoxModelLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            boxModelModelNew = new BoxModelModel();
            boxModel = new BoxModel();
            formCollection = new FormCollection();
        }
        private void SetupShim()
        {
            shimBoxModelService = new ShimBoxModelService(boxModelService);
            shimBoxModelLanguageService = new ShimBoxModelLanguageService(boxModelService._BoxModelLanguageService);
        }
        #endregion Functions
    }
}


