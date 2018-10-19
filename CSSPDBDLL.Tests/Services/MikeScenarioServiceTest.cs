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
using System.Threading;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.IO;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MikeScenarioServiceTest
    /// </summary>
    [TestClass]
    public class MikeScenarioServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MikeScenario";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MikeScenarioService mikeScenarioService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MikeScenarioModel mikeScenarioModelNew { get; set; }
        private MikeScenario mikeScenario { get; set; }
        private ShimMikeScenarioService shimMikeScenarioService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
        private ShimAppTaskService shimAppTaskService { get; set; }
        private ShimMapInfoPointService shimMapInfoPointService { get; set; }
        private TVFileService tvFileService { get; set; }
        private TVItemService tvItemService { get; set; }
        private MikeSourceStartEndService mikeSourceStartEndService { get; set; }
        private MikeSourceService mikeSourceService { get; set; }
        private AppTaskService appTaskService { get; set; }
        private ShimMikeBoundaryConditionService shimMikeBoundaryConditionService { get; set; }
        private ShimMapInfoService shimMapInfoService { get; set; }
        private ShimMikeSourceService shimMikeSourceService { get; set; }
        private ShimMikeSourceStartEndService shimMikeSourceStartEndService { get; set; }
        private ShimTVFileService shimTVFileService { get; set; }
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
        public MikeScenarioServiceTest()
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
        public void MikeScenarioService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(mikeScenarioService);
                Assert.IsNotNull(mikeScenarioService.db);
                Assert.IsNotNull(mikeScenarioService.LanguageRequest);
                Assert.IsNotNull(mikeScenarioService.User);
                Assert.AreEqual(user.Identity.Name, mikeScenarioService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mikeScenarioService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MikeScenarioService_CheckIfMikeScenarioNameIsUniqueDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    TVItemModel tvItemModelMunicipality = mikeScenarioService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    string retStr = mikeScenarioService.CheckIfMikeScenarioNameIsUniqueDB(tvItemModelMunicipality.TVItemID, mikeScenarioModelRet.MikeScenarioTVText);
                    Assert.AreEqual(string.Format(ServiceRes._HasToBeUnique, ServiceRes.MikeScenarioName), retStr);

                    mikeScenarioModelRet.MikeScenarioTVText = "not used";
                    retStr = mikeScenarioService.CheckIfMikeScenarioNameIsUniqueDB(tvItemModelMunicipality.TVItemID, mikeScenarioModelRet.MikeScenarioTVText);
                    Assert.AreEqual("true", retStr);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CheckIfMikeScenarioNameIsUniqueDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    TVItemModel tvItemModelMunicipality = mikeScenarioService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        string retStr = mikeScenarioService.CheckIfMikeScenarioNameIsUniqueDB(tvItemModelMunicipality.TVItemID, mikeScenarioModelRet.MikeScenarioTVText);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CheckIfMikeScenarioNameIsUniqueDB_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    TVItemModel tvItemModelMunicipality = mikeScenarioService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.CreateTVTextMikeScenarioModel = (a) =>
                        {
                            return "";
                        };

                        string retStr = mikeScenarioService.CheckIfMikeScenarioNameIsUniqueDB(tvItemModelMunicipality.TVItemID, mikeScenarioModelRet.MikeScenarioTVText);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CheckIfMikeScenarioNameIsUniqueDB_GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    TVItemModel tvItemModelMunicipality = mikeScenarioService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = "" };
                        };

                        string retStr = mikeScenarioService.CheckIfMikeScenarioNameIsUniqueDB(tvItemModelMunicipality.TVItemID, mikeScenarioModelRet.MikeScenarioTVText);
                        Assert.AreEqual(string.Format(ServiceRes._HasToBeUnique, ServiceRes.MikeScenarioName), retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_MikeScenarioModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModel = AddMikeScenarioModel();

                    #region Good
                    mikeScenarioModelNew.MikeScenarioTVItemID = mikeScenarioModel.MikeScenarioTVItemID;
                    mikeScenarioModelNew.MikeScenarioTVText = randomService.RandomString("Mike Scenario", 24);
                    FillMikeScenarioModel(mikeScenarioModelNew);

                    string retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region MikeScenarioTVItemID
                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.MikeScenarioTVItemID = 0;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), retStr);

                    mikeScenarioModelNew.MikeScenarioTVItemID = mikeScenarioModel.MikeScenarioTVItemID;
                    FillMikeScenarioModel(mikeScenarioModelNew);

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MikeScenarioTVItemID

                    #region MikeScenarioTVText
                    FillMikeScenarioModel(mikeScenarioModelNew);
                    int MinInt = 3;
                    int MaxInt = 200;
                    mikeScenarioModelNew.MikeScenarioTVText = randomService.RandomString("", MinInt - 1);

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.MikeScenarioTVText, MinInt), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.MikeScenarioTVText = randomService.RandomString("", MaxInt + 1);

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.MikeScenarioTVText, MaxInt), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.MikeScenarioTVText = randomService.RandomString("", MaxInt - 1);

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.MikeScenarioTVText = randomService.RandomString("", MinInt);

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.MikeScenarioTVText = randomService.RandomString("", MaxInt);

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MikeScenarioTVText

                    #region MikeScenarioStatus
                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.ScenarioStatus = (ScenarioStatusEnum)10000;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ScenarioStatus), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.ScenarioStatus = ScenarioStatusEnum.Copying;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MikeScenarioStatus

                    #region MikeScenarioStartDateTime_Local > MikeScenarioEndDateTime_Local
                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.MikeScenarioStartDateTime_Local = DateTime.UtcNow;
                    mikeScenarioModelNew.MikeScenarioEndDateTime_Local = mikeScenarioModelNew.MikeScenarioStartDateTime_Local.AddHours(-1);

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsLaterThan_, ServiceRes.MikeScenarioStartDateTime_Local, ServiceRes.MikeScenarioEndDateTime_Local), retStr);
                    #endregion MikeScenarioStartDateTime_Local > MikeScenarioEndDateTime_Local

                    #region WindSpeed_km_h
                    FillMikeScenarioModel(mikeScenarioModelNew);
                    double Min = 0;
                    double Max = 100;
                    mikeScenarioModelNew.WindSpeed_km_h = Min - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WindSpeed_km_h, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.WindSpeed_km_h = Max + 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WindSpeed_km_h, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.WindSpeed_km_h = Max - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.WindSpeed_km_h = Min;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.WindSpeed_km_h = Max;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion WindSpeed_km_h

                    #region WindDirection_deg
                    FillMikeScenarioModel(mikeScenarioModelNew);
                    Min = 0;
                    Max = 360;
                    mikeScenarioModelNew.WindDirection_deg = Min - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WindDirection_deg, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.WindDirection_deg = Max + 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WindDirection_deg, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.WindDirection_deg = Max - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.WindDirection_deg = Min;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.WindDirection_deg = Max;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion WindDirection_deg

                    #region DecayFactor_per_day
                    FillMikeScenarioModel(mikeScenarioModelNew);
                    Min = 0;
                    Max = 100;
                    mikeScenarioModelNew.DecayFactor_per_day = Min - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DecayFactor_per_day, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.DecayFactor_per_day = Max + 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DecayFactor_per_day, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.DecayFactor_per_day = Max - 1;
                    mikeScenarioModelNew.DecayFactorAmplitude = mikeScenarioModelNew.DecayFactor_per_day - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.DecayFactor_per_day = Min + 1;
                    mikeScenarioModelNew.DecayFactorAmplitude = mikeScenarioModelNew.DecayFactor_per_day - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.DecayFactor_per_day = Max - 1;
                    mikeScenarioModelNew.DecayFactorAmplitude = mikeScenarioModelNew.DecayFactor_per_day - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion DecayFactor_per_day

                    #region DecayFactorAmplitude
                    FillMikeScenarioModel(mikeScenarioModelNew);
                    Min = 0;
                    Max = 100;
                    mikeScenarioModelNew.DecayFactorAmplitude = Min - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DecayFactorAmplitude, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.DecayFactorAmplitude = Max + 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DecayFactorAmplitude, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.DecayFactorAmplitude = Max - 2;
                    mikeScenarioModelNew.DecayFactor_per_day = Max - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.DecayFactorAmplitude = Min;
                    mikeScenarioModelNew.DecayFactor_per_day = Min + 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.DecayFactorAmplitude = Max - 1;
                    mikeScenarioModelNew.DecayFactor_per_day = Max;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.DecayFactor_per_day = Max - 1;
                    mikeScenarioModelNew.DecayFactorAmplitude = mikeScenarioModelNew.DecayFactor_per_day + 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsBiggerOrEqualTo_, ServiceRes.DecayFactorAmplitude, ServiceRes.DecayFactor_per_day), retStr);
                    #endregion DecayFactorAmplitude

                    #region ResultFrequency_min
                    FillMikeScenarioModel(mikeScenarioModelNew);
                    MinInt = 5;
                    MaxInt = 60;
                    mikeScenarioModelNew.ResultFrequency_min = MinInt - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ResultFrequency_min, MinInt, MaxInt), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.ResultFrequency_min = MaxInt + 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ResultFrequency_min, MinInt, MaxInt), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.ResultFrequency_min = MaxInt - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.ResultFrequency_min = MinInt;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.ResultFrequency_min = MaxInt;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ResultFrequency_min

                    #region AmbientTemperature_C
                    FillMikeScenarioModel(mikeScenarioModelNew);
                    Min = 0;
                    Max = 35;
                    mikeScenarioModelNew.AmbientTemperature_C = Min - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AmbientTemperature_C, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.AmbientTemperature_C = Max + 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AmbientTemperature_C, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.AmbientTemperature_C = Max - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.AmbientTemperature_C = Min;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.AmbientTemperature_C = Max;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AmbientTemperature_C

                    #region AmbientSalinity_PSU
                    FillMikeScenarioModel(mikeScenarioModelNew);
                    Min = 0;
                    Max = 35;
                    mikeScenarioModelNew.AmbientSalinity_PSU = Min - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AmbientSalinity_PSU, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.AmbientSalinity_PSU = Max + 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AmbientSalinity_PSU, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.AmbientSalinity_PSU = Max - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.AmbientSalinity_PSU = Min;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.AmbientSalinity_PSU = Max;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AmbientSalinity_PSU

                    #region ManningNumber
                    FillMikeScenarioModel(mikeScenarioModelNew);
                    Min = 20;
                    Max = 40;
                    mikeScenarioModelNew.ManningNumber = Min - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ManningNumber, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.ManningNumber = Max + 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ManningNumber, Min, Max), retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.ManningNumber = Max - 1;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.ManningNumber = Min;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeScenarioModel(mikeScenarioModelNew);
                    mikeScenarioModelNew.ManningNumber = Max;

                    retStr = mikeScenarioService.MikeScenarioModelOK(mikeScenarioModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ManningNumber
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_FillMikeScenario_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    mikeScenarioModelNew.MikeScenarioTVItemID = randomService.RandomTVItem(TVTypeEnum.MikeScenario).TVItemID;
                    mikeScenarioModelNew.MikeScenarioTVText = randomService.RandomString("Mike Scenario", 24);
                    FillMikeScenarioModel(mikeScenarioModelNew);

                    ContactOK contactOK = mikeScenarioService.IsContactOK();

                    string retStr = mikeScenarioService.FillMikeScenario(mikeScenario, mikeScenarioModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mikeScenario.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mikeScenarioService.FillMikeScenario(mikeScenario, mikeScenarioModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, mikeScenario.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioInputSummaryDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MikeScenario).FirstOrDefault();
                    Assert.IsTrue(tvItemModelMikeScenario.TVItemID > 0);

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModelMikeScenario.TVItemID);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    InputSummary inputSummary = mikeScenarioService.GetMikeScenarioInputSummaryDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual("", inputSummary.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioInputSummaryDB_DecayIsConstant_False_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MikeScenario).FirstOrDefault();
                    Assert.IsTrue(tvItemModelMikeScenario.TVItemID > 0);

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModelMikeScenario.TVItemID);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    mikeScenarioModelRet.DecayIsConstant = false;

                    mikeScenarioModelRet = mikeScenarioService.PostUpdateMikeScenarioDB(mikeScenarioModelRet);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    InputSummary inputSummary = mikeScenarioService.GetMikeScenarioInputSummaryDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual("", inputSummary.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioInputSummaryDB_DecayIsConstant_True_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MikeScenario).FirstOrDefault();
                    Assert.IsTrue(tvItemModelMikeScenario.TVItemID > 0);

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModelMikeScenario.TVItemID);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    mikeScenarioModelRet.DecayIsConstant = true;

                    mikeScenarioModelRet = mikeScenarioService.PostUpdateMikeScenarioDB(mikeScenarioModelRet);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    InputSummary inputSummary = mikeScenarioService.GetMikeScenarioInputSummaryDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual("", inputSummary.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioInputSummaryDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MikeScenario).FirstOrDefault();
                    Assert.IsTrue(tvItemModelMikeScenario.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        InputSummary inputSummaryRet = mikeScenarioService.GetMikeScenarioInputSummaryDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErrorText, inputSummaryRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioInputSummaryDB_TVItemID_Zero_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MikeScenario).FirstOrDefault();
                    Assert.IsTrue(tvItemModelMikeScenario.TVItemID > 0);

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModelMikeScenario.TVItemID);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    int MikeScenarioTVItemID = 0;
                    InputSummary inputSummary = mikeScenarioService.GetMikeScenarioInputSummaryDB(MikeScenarioTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeScenario, ServiceRes.MikeScenarioTVItemID, MikeScenarioTVItemID), inputSummary.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioInputSummaryDB_GetMikeScenarioModelWithMikeScenarioTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MikeScenario).FirstOrDefault();
                    Assert.IsTrue(tvItemModelMikeScenario.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErrorText };
                        };

                        MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioImportOtherFileToUploadDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MikeScenario).FirstOrDefault();
                    Assert.IsTrue(tvItemModelMikeScenario.TVItemID > 0);

                    List<TVFileModel> tvFileModelList = mikeScenarioService.GetMikeScenarioImportOtherFileToUploadDB(tvItemModelMikeScenario.TVItemID);
                    Assert.IsTrue(tvFileModelList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioImportOtherFileToUploadDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MikeScenario).FirstOrDefault();
                    Assert.IsTrue(tvItemModelMikeScenario.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        List<TVFileModel> tvFileModelList = mikeScenarioService.GetMikeScenarioImportOtherFileToUploadDB(tvItemModelMikeScenario.TVItemID);
                        Assert.IsTrue(tvFileModelList.Count == 1);
                        Assert.AreEqual(ErrorText, tvFileModelList[0].Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioImportOtherFileToUploadDB_MikeScenarioTVItemID_Zero_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 0;
                    List<TVFileModel> tvFileModelList = mikeScenarioService.GetMikeScenarioImportOtherFileToUploadDB(MikeScenarioTVItemID);
                    Assert.IsTrue(tvFileModelList.Count == 1);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), tvFileModelList[0].Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioImportOtherFileToUploadDB_GetMikeScenarioModelWithMikeScenarioTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelListWithTVTypeDB(TVTypeEnum.MikeScenario).FirstOrDefault();
                    Assert.IsTrue(tvItemModelMikeScenario.TVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErrorText };
                        };

                        List<TVFileModel> tvFileModelList = mikeScenarioService.GetMikeScenarioImportOtherFileToUploadDB(tvItemModelMikeScenario.TVItemID);
                        Assert.IsTrue(tvFileModelList.Count == 1);
                        Assert.AreEqual(ErrorText, tvFileModelList[0].Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    int mikeScenarioCount = mikeScenarioService.GetMikeScenarioModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, mikeScenarioCount);

                    MikeScenarioModel mikeScenarioModelRet2 = mikeScenarioService.PostDeleteMikeScenarioWithMikeScenarioTVItemIDDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioModelWithMikeScenarioIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    // Act 
                    MikeScenarioModel mikeScenarioModelRet2 = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioIDDB(mikeScenarioModelRet.MikeScenarioID);

                    // Assert 
                    CompareMikeScenarioModels(mikeScenarioModelRet, mikeScenarioModelRet2);

                    int MikeScenarioID = 0;
                    MikeScenarioModel mikeScenarioModelRet3 = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioIDDB(MikeScenarioID);

                    // Assert 
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeScenario, ServiceRes.MikeScenarioID, MikeScenarioID), mikeScenarioModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioModelWithMikeScenarioTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    MikeScenarioModel mikeScenarioModelRet2 = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(mikeScenarioModelRet.MikeScenarioTVItemID);

                    CompareMikeScenarioModels(mikeScenarioModelRet, mikeScenarioModelRet2);

                    int MikeScenarioTVItemID = 0;
                    MikeScenarioModel mikeScenarioModelRet3 = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeScenario, ServiceRes.MikeScenarioTVItemID, MikeScenarioTVItemID), mikeScenarioModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioWithMikeScenarioIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    MikeScenario mikeScenarioRet = mikeScenarioService.GetMikeScenarioWithMikeScenarioIDDB(mikeScenarioModelRet.MikeScenarioID);
                    Assert.AreEqual(mikeScenarioModelRet.MikeScenarioID, mikeScenarioRet.MikeScenarioID);

                    int MikeScenarioID = 0;
                    MikeScenario mikeScenarioRet2 = mikeScenarioService.GetMikeScenarioWithMikeScenarioIDDB(MikeScenarioID);
                    Assert.IsNull(mikeScenarioRet2);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetMikeScenarioWithMikeScenarioTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    MikeScenario mikeScenarioRet = mikeScenarioService.GetMikeScenarioWithMikeScenarioTVItemIDDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual(mikeScenarioModelRet.MikeScenarioTVItemID, mikeScenarioRet.MikeScenarioTVItemID);

                    int MikeScenarioTVItemID = 0;
                    MikeScenario mikeScenarioRet2 = mikeScenarioService.GetMikeScenarioWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.IsNull(mikeScenarioRet2);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetStudyAreaContourPolygonListWithMikeScenarioTVItemID_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 316737; // Municipality: Gaspé --- Scenario Name: Gaspe

                    List<ContourPolygon> contourPolygonList = mikeScenarioService.GetStudyAreaContourPolygonListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual(3, contourPolygonList.Count);
                    Assert.AreEqual(519, contourPolygonList[0].ContourNodeList.Count);
                    Assert.AreEqual(8, contourPolygonList[1].ContourNodeList.Count);
                    Assert.AreEqual(34, contourPolygonList[2].ContourNodeList.Count);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioBoundaryCondition_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<TVItemModel> tvItemModelBoundaryConditionList = mikeScenarioService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.IsTrue(tvItemModelBoundaryConditionList.Count > 0);

                    foreach (TVItemModel tvItemModelBoundaryCondition in tvItemModelBoundaryConditionList)
                    {
                        TVItemModel tvItemModelBC = mikeScenarioService.CopyMikeScenarioBoundaryCondition(tvItemModelMikeScenarioRet.TVItemID, tvItemModelBoundaryCondition, TVTypeEnum.MikeBoundaryConditionMesh);
                        Assert.AreEqual("", tvItemModelBC.Error);
                    }

                    tvItemModelBoundaryConditionList = mikeScenarioService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionWebTide);
                    Assert.IsTrue(tvItemModelBoundaryConditionList.Count > 0);

                    foreach (TVItemModel tvItemModelBoundaryCondition in tvItemModelBoundaryConditionList)
                    {
                        TVItemModel tvItemModelBC = mikeScenarioService.CopyMikeScenarioBoundaryCondition(tvItemModelMikeScenarioRet.TVItemID, tvItemModelBoundaryCondition, TVTypeEnum.MikeBoundaryConditionWebTide);
                        Assert.AreEqual("", tvItemModelBC.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioBoundaryCondition_GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount.ToString() + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<TVItemModel> tvItemModelBoundaryConditionList = mikeScenarioService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.IsTrue(tvItemModelBoundaryConditionList.Count > 0);

                    foreach (TVItemModel tvItemModelBoundaryCondition in tvItemModelBoundaryConditionList)
                    {
                        using (ShimsContext.Create())
                        {
                            //string ErrorText = "ErrorText";
                            SetupShim();
                            shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                            {
                                return new TVItemModel() { Error = "" };
                            };

                            TVItemModel tvItemModelBC = mikeScenarioService.CopyMikeScenarioBoundaryCondition(tvItemModelMikeScenarioRet.TVItemID, tvItemModelBoundaryCondition, TVTypeEnum.MikeBoundaryConditionMesh);

                            Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MikeBoundaryCondition), tvItemModelBC.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioBoundaryCondition_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<TVItemModel> tvItemModelBoundaryConditionList = mikeScenarioService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.IsTrue(tvItemModelBoundaryConditionList.Count > 0);

                    foreach (TVItemModel tvItemModelBoundaryCondition in tvItemModelBoundaryConditionList)
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                            {
                                return new TVItemModel() { Error = ErrorText };
                            };

                            TVItemModel tvItemModelBC = mikeScenarioService.CopyMikeScenarioBoundaryCondition(tvItemModelMikeScenarioRet.TVItemID, tvItemModelBoundaryCondition, TVTypeEnum.MikeBoundaryConditionMesh);

                            Assert.AreEqual(ErrorText, tvItemModelBC.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioBoundaryCondition_GetMikeBoundaryConditionModelWithMikeBoundaryConditionTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<TVItemModel> tvItemModelBoundaryConditionList = mikeScenarioService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.IsTrue(tvItemModelBoundaryConditionList.Count > 0);

                    foreach (TVItemModel tvItemModelBoundaryCondition in tvItemModelBoundaryConditionList)
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimMikeBoundaryConditionService.GetMikeBoundaryConditionModelWithMikeBoundaryConditionTVItemIDDBInt32 = (a) =>
                            {
                                return new MikeBoundaryConditionModel() { Error = ErrorText };
                            };

                            TVItemModel tvItemModelBC = mikeScenarioService.CopyMikeScenarioBoundaryCondition(tvItemModelMikeScenarioRet.TVItemID, tvItemModelBoundaryCondition, TVTypeEnum.MikeBoundaryConditionMesh);

                            Assert.AreEqual(ErrorText, tvItemModelBC.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioBoundaryCondition_PostAddMikeBoundaryConditionDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<TVItemModel> tvItemModelBoundaryConditionList = mikeScenarioService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.IsTrue(tvItemModelBoundaryConditionList.Count > 0);

                    foreach (TVItemModel tvItemModelBoundaryCondition in tvItemModelBoundaryConditionList)
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimMikeBoundaryConditionService.PostAddMikeBoundaryConditionDBMikeBoundaryConditionModel = (a) =>
                            {
                                return new MikeBoundaryConditionModel() { Error = ErrorText };
                            };

                            TVItemModel tvItemModelBC = mikeScenarioService.CopyMikeScenarioBoundaryCondition(tvItemModelMikeScenarioRet.TVItemID, tvItemModelBoundaryCondition, TVTypeEnum.MikeBoundaryConditionMesh);

                            Assert.AreEqual(ErrorText, tvItemModelBC.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioBoundaryCondition_GetMapInfoPointModelListWithTVItemIDAndMapPurposeAndMapInfoDrawTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<TVItemModel> tvItemModelBoundaryConditionList = mikeScenarioService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.IsTrue(tvItemModelBoundaryConditionList.Count > 0);

                    foreach (TVItemModel tvItemModelBoundaryCondition in tvItemModelBoundaryConditionList)
                    {
                        using (ShimsContext.Create())
                        {
                            //string ErrorText = "ErrorText";
                            SetupShim();
                            shimMapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDBInt32TVTypeEnumMapInfoDrawTypeEnum = (a, b, c) =>
                            {
                                return new List<MapInfoPointModel>();
                            };

                            TVItemModel tvItemModelBC = mikeScenarioService.CopyMikeScenarioBoundaryCondition(tvItemModelMikeScenarioRet.TVItemID, tvItemModelBoundaryCondition, TVTypeEnum.MikeBoundaryConditionMesh);

                            Assert.AreEqual(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint), tvItemModelBC.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioBoundaryCondition_CreateMapInfoObjectDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<TVItemModel> tvItemModelBoundaryConditionList = mikeScenarioService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.IsTrue(tvItemModelBoundaryConditionList.Count > 0);

                    foreach (TVItemModel tvItemModelBoundaryCondition in tvItemModelBoundaryConditionList)
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimMapInfoService.CreateMapInfoObjectDBListOfCoordMapInfoDrawTypeEnumTVTypeEnumInt32 = (a, b, c, d) =>
                            {
                                return new MapInfoModel() { Error = ErrorText };
                            };

                            TVItemModel tvItemModelBC = mikeScenarioService.CopyMikeScenarioBoundaryCondition(tvItemModelMikeScenarioRet.TVItemID, tvItemModelBoundaryCondition, TVTypeEnum.MikeBoundaryConditionMesh);

                            Assert.AreEqual(ErrorText, tvItemModelBC.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioSource_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<MikeSourceModel> mikeSourceModelOldList = mikeScenarioService._MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.IsTrue(mikeSourceModelOldList.Count > 0);

                    foreach (MikeSourceModel msm in mikeSourceModelOldList)
                    {
                        TVItemModel tvItemModelSource = mikeScenarioService.CopyMikeScenarioSource(tvItemModelMikeScenarioRet.TVItemID, msm);
                        Assert.AreEqual("", tvItemModelSource.Error);

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioSource_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<MikeSourceModel> mikeSourceModelOldList = mikeScenarioService._MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.IsTrue(mikeSourceModelOldList.Count > 0);

                    foreach (MikeSourceModel msm in mikeSourceModelOldList)
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                            {
                                return new TVItemModel() { Error = ErrorText };
                            };

                            TVItemModel tvItemModelSource = mikeScenarioService.CopyMikeScenarioSource(tvItemModelMikeScenarioRet.TVItemID, msm);

                            Assert.AreEqual(ErrorText, tvItemModelSource.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioSource_PostAddMikeSourceDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<MikeSourceModel> mikeSourceModelOldList = mikeScenarioService._MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.IsTrue(mikeSourceModelOldList.Count > 0);

                    foreach (MikeSourceModel msm in mikeSourceModelOldList)
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimMikeSourceService.PostAddMikeSourceDBMikeSourceModel = (a) =>
                            {
                                return new MikeSourceModel() { Error = ErrorText };
                            };

                            TVItemModel tvItemModelSource = mikeScenarioService.CopyMikeScenarioSource(tvItemModelMikeScenarioRet.TVItemID, msm);

                            Assert.AreEqual(ErrorText, tvItemModelSource.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioSource_GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<MikeSourceModel> mikeSourceModelOldList = mikeScenarioService._MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.IsTrue(mikeSourceModelOldList.Count > 0);

                    foreach (MikeSourceModel msm in mikeSourceModelOldList)
                    {
                        using (ShimsContext.Create())
                        {
                            //string ErrorText = "ErrorText";
                            SetupShim();
                            shimMikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDBInt32 = (a) =>
                            {
                                return new List<MikeSourceStartEndModel>();
                            };

                            TVItemModel tvItemModelSource = mikeScenarioService.CopyMikeScenarioSource(tvItemModelMikeScenarioRet.TVItemID, msm);

                            Assert.AreEqual(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MikeSourceStartEnd), tvItemModelSource.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioSource_PostAddMikeSourceStartEndDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<MikeSourceModel> mikeSourceModelOldList = mikeScenarioService._MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.IsTrue(mikeSourceModelOldList.Count > 0);

                    foreach (MikeSourceModel msm in mikeSourceModelOldList)
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimMikeSourceStartEndService.PostAddMikeSourceStartEndDBMikeSourceStartEndModel = (a) =>
                            {
                                return new MikeSourceStartEndModel() { Error = ErrorText };
                            };

                            TVItemModel tvItemModelSource = mikeScenarioService.CopyMikeScenarioSource(tvItemModelMikeScenarioRet.TVItemID, msm);

                            Assert.AreEqual(ErrorText, tvItemModelSource.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioSource_GetMapInfoPointModelListWithTVItemIDAndMapPurposeAndMapInfoDrawTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<MikeSourceModel> mikeSourceModelOldList = mikeScenarioService._MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.IsTrue(mikeSourceModelOldList.Count > 0);

                    foreach (MikeSourceModel msm in mikeSourceModelOldList)
                    {
                        using (ShimsContext.Create())
                        {
                            //string ErrorText = "ErrorText";
                            SetupShim();
                            shimMapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDBInt32TVTypeEnumMapInfoDrawTypeEnum = (a, b, c) =>
                            {
                                return new List<MapInfoPointModel>();
                            };

                            TVItemModel tvItemModelSource = mikeScenarioService.CopyMikeScenarioSource(tvItemModelMikeScenarioRet.TVItemID, msm);

                            Assert.AreEqual(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint), tvItemModelSource.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioSource_CreateMapInfoObjectDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<MikeSourceModel> mikeSourceModelOldList = mikeScenarioService._MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.IsTrue(mikeSourceModelOldList.Count > 0);

                    foreach (MikeSourceModel msm in mikeSourceModelOldList)
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimMapInfoService.CreateMapInfoObjectDBListOfCoordMapInfoDrawTypeEnumTVTypeEnumInt32 = (a, b, c, d) =>
                            {
                                return new MapInfoModel() { Error = ErrorText };
                            };

                            TVItemModel tvItemModelSource = mikeScenarioService.CopyMikeScenarioSource(tvItemModelMikeScenarioRet.TVItemID, msm);

                            Assert.AreEqual(ErrorText, tvItemModelSource.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioTVFile_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<TVFileModel> tvFileModelOldList = mikeScenarioService._TVFileService.GetTVFileModelListWithParentTVItemIDDB(MikeScenarioTVItemID).Where(c => c.FilePurpose == FilePurposeEnum.MikeInput || c.FilePurpose == FilePurposeEnum.MikeInputMDF || c.FilePurpose == FilePurposeEnum.MikeResultDFSU).ToList();
                    Assert.IsTrue(tvFileModelOldList.Count > 0);

                    foreach (TVFileModel tvFileModel in tvFileModelOldList)
                    {
                        TVItemModel tvItemModelTVFile = mikeScenarioService.CopyMikeScenarioTVFile(mikeScenarioModel, mikeScenarioModelRet, tvFileModel, TVText);
                        Assert.AreEqual("", tvItemModelTVFile.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioTVFile_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<TVFileModel> tvFileModelOldList = mikeScenarioService._TVFileService.GetTVFileModelListWithParentTVItemIDDB(MikeScenarioTVItemID).Where(c => c.FilePurpose == FilePurposeEnum.MikeInput || c.FilePurpose == FilePurposeEnum.MikeInputMDF || c.FilePurpose == FilePurposeEnum.MikeResultDFSU).ToList();
                    Assert.IsTrue(tvFileModelOldList.Count > 0);

                    foreach (TVFileModel tvFileModel in tvFileModelOldList)
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                            {
                                return new TVItemModel() { Error = ErrorText };
                            };
                            TVItemModel tvItemModelTVFile = mikeScenarioService.CopyMikeScenarioTVFile(mikeScenarioModel, mikeScenarioModelRet, tvFileModel, TVText);

                            Assert.AreEqual(ErrorText, tvItemModelTVFile.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CopyMikeScenarioTVFile_PostAddTVFileDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    int CopyCount = 0;
                    bool Found = false;
                    string TVText = "";
                    while (!Found)
                    {
                        CopyCount += 1;
                        TVText = "_" + CopyCount + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                        TVItemModel tvItemModelExist = mikeScenarioService._TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                        if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                        {
                            Found = true;
                        }
                    }

                    TVItemModel tvItemModelMikeScenarioRet = mikeScenarioService._TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                    {
                        AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                        AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                        DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                        DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                        DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                        EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                        EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                        LastUpdateDate_UTC = DateTime.UtcNow,
                        ManningNumber = mikeScenarioModel.ManningNumber,
                        MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                        MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                        MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                        NumberOfElements = mikeScenarioModel.NumberOfElements,
                        NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                        NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                        NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                        NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                        NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                        ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                        ScenarioStatus = ScenarioStatusEnum.Changed,
                        MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                        WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                        WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                        MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                        ErrorInfo = "",
                    };

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    List<TVFileModel> tvFileModelOldList = mikeScenarioService._TVFileService.GetTVFileModelListWithParentTVItemIDDB(MikeScenarioTVItemID).Where(c => c.FilePurpose == FilePurposeEnum.MikeInput || c.FilePurpose == FilePurposeEnum.MikeInputMDF || c.FilePurpose == FilePurposeEnum.MikeResultDFSU).ToList();
                    Assert.IsTrue(tvFileModelOldList.Count > 0);

                    foreach (TVFileModel tvFileModel in tvFileModelOldList)
                    {
                        using (ShimsContext.Create())
                        {
                            string ErrorText = "ErrorText";
                            SetupShim();
                            shimTVFileService.PostAddTVFileDBTVFileModel = (a) =>
                            {
                                return new TVFileModel() { Error = ErrorText };
                            };
                            TVItemModel tvItemModelTVFile = mikeScenarioService.CopyMikeScenarioTVFile(mikeScenarioModel, mikeScenarioModelRet, tvFileModel, TVText);

                            Assert.AreEqual(ErrorText, tvItemModelTVFile.Error);
                        }

                        break;
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    string retStr = mikeScenarioService.CreateTVText(mikeScenarioModelRet);
                    Assert.AreEqual(mikeScenarioModelRet.MikeScenarioTVText, retStr);

                    mikeScenarioModelRet.MikeScenarioTVText = "";
                    retStr = mikeScenarioService.CreateTVText(mikeScenarioModelRet);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_GetIsItSameObject_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    bool retBool = mikeScenarioService.GetIsItSameObject(mikeScenarioModelRet, tvItemModelMikeScenario);
                    Assert.IsTrue(retBool);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_ReturnAppTaskError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    AppTaskModel appTaskModelRet = mikeScenarioService.ReturnAppTaskError(ErrorText);
                    Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_ReturnMikeScenarioError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.ReturnMikeScenarioError(ErrorText);
                    Assert.AreEqual(ErrorText, mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_ReturnTVFileError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    TVFileModel tvFileModelRet = mikeScenarioService.ReturnTVFileError(ErrorText);
                    Assert.AreEqual(ErrorText, tvFileModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_ReturnTVItemError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    TVItemModel tvItemModelRet = mikeScenarioService.ReturnTVItemError(ErrorText);
                    Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_ReturnStrLimit_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string Blank = "                                                                   ";
                    string ErrorText = "ErrorText";
                    for (int i = 10; i < 40; i++)
                    {
                        string retStr = mikeScenarioService.ReturnStrLimit(ErrorText, i);
                        Assert.AreEqual(Blank.Substring(0, i - ErrorText.Length) + ErrorText, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioAskToRunDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    AppTaskModel appTaskModelRet = mikeScenarioService.PostMikeScenarioAskToRunDB(tvItemModelMikeScenario.TVItemID);
                    Assert.IsNotNull(appTaskModelRet);
                    Assert.AreEqual("", appTaskModelRet.Error);
                    Assert.AreEqual(tvItemModelMikeScenario.TVItemID, appTaskModelRet.TVItemID);
                    Assert.AreEqual(tvItemModelMikeScenario.TVItemID, appTaskModelRet.TVItemID2);
                    Assert.AreEqual(AppTaskCommandEnum.MikeScenarioAskToRun, appTaskModelRet.AppTaskCommand);
                    Assert.AreEqual("", appTaskModelRet.ErrorText);
                    Assert.AreEqual(ServiceRes.AskingToRunMIKEScenario, appTaskModelRet.StatusText);
                    Assert.AreEqual(AppTaskStatusEnum.Created, appTaskModelRet.AppTaskStatus);
                    Assert.AreEqual(1, appTaskModelRet.PercentCompleted);
                    Assert.AreEqual(tvItemModelMikeScenario.TVItemID.ToString(), mikeScenarioService._AppTaskService.GetAppTaskParamStr(appTaskModelRet.Parameters, "MikeScenarioTVItemID"));
                    Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mikeScenarioService.LanguageRequest);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioAskToRunDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = randomService.RandomTVItem(TVTypeEnum.MikeScenario).TVItemID;
                    Assert.IsTrue(MikeScenarioTVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet = mikeScenarioService.PostMikeScenarioAskToRunDB(MikeScenarioTVItemID);
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioAskToRunDB_MikeScenarioTVItemID_Equal_0_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = randomService.RandomTVItem(TVTypeEnum.MikeScenario).TVItemID;
                    Assert.IsTrue(MikeScenarioTVItemID > 0);

                    AppTaskModel appTaskModelRet = mikeScenarioService.PostMikeScenarioAskToRunDB(0);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), appTaskModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioAskToRunDB_GetMikeScenarioModelWithMikeScenarioTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = randomService.RandomTVItem(TVTypeEnum.MikeScenario).TVItemID;
                    Assert.IsTrue(MikeScenarioTVItemID > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet = mikeScenarioService.PostMikeScenarioAskToRunDB(MikeScenarioTVItemID);
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioAskToRunDB_GetParentTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetParentTVItemModelWithTVItemIDForLocationDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet = mikeScenarioService.PostMikeScenarioAskToRunDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioAskToRunDB_PostUpdateMikeScenarioDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.PostUpdateMikeScenarioDBMikeScenarioModel = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet = mikeScenarioService.PostMikeScenarioAskToRunDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioAskToRunDB_PostAddAppTask_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAppTaskService.PostAddAppTaskAppTaskModel = (a) =>
                        {
                            return new AppTaskModel() { Error = ErrorText };
                        };

                        AppTaskModel appTaskModelRet = mikeScenarioService.PostMikeScenarioAskToRunDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErrorText, appTaskModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAddUpdateDeleteMikeScenarioDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);

                    MikeScenarioModel mikeScenarioModelRet3 = mikeScenarioService.PostDeleteMikeScenarioWithMikeScenarioTVItemIDDB(mikeScenarioModelRet2.MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModelRet3.Error);

                    mikeScenarioModelRet3 = mikeScenarioService.PostDeleteMikeScenarioWithMikeScenarioTVItemIDDB(0);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MikeScenario), mikeScenarioModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAddMikeScenarioDB_MikeScenarioModelOK_Test()
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
                        shimMikeScenarioService.MikeScenarioModelOKMikeScenarioModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAddMikeScenarioDB_IsContactOK_Error_Test()
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
                        shimMikeScenarioService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAddMikeScenarioDB_GetTVItemModelWithTVItemIDDB_Error_Test()
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
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModelMikeScenairo = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                        Assert.AreEqual("", tvItemModelMikeScenairo.Error);

                        mikeScenarioModelNew.MikeScenarioTVItemID = tvItemModelMikeScenairo.TVItemID;
                        mikeScenarioModelNew.MikeScenarioTVText = randomService.RandomString("Mike Scenario ", 24);

                        FillMikeScenarioModel(mikeScenarioModelNew);

                        MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAddMikeScenarioDB_FillMikeScenarioModel_ErrorTest()
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
                        shimMikeScenarioService.FillMikeScenarioMikeScenarioMikeScenarioModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAddMikeScenarioDB_DoAddChanges_ErrorTest()
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
                        shimMikeScenarioService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAddMikeScenarioDB_Add_Error_Test()
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
                        shimMikeScenarioService.FillMikeScenarioMikeScenarioMikeScenarioModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                        Assert.IsTrue(mikeScenarioModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostDeleteMikeScenarioWithMikeScenarioTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope tss = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelCopiedMikeScenario = mikeScenarioService.PostMikeScenarioCopyDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelCopiedMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModelCopiedMikeScenario.TVItemID);
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostDeleteMikeScenarioWithMikeScenarioTVItemIDDB(mikeScenarioModel.MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostDeleteMikeScenarioWithMikeScenarioTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeScenarioService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeScenarioModel mikeScenarioModelRet2 = mikeScenarioService.PostDeleteMikeScenarioWithMikeScenarioTVItemIDDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostDeleteMikeScenarioWithMikeScenarioTVItemIDDB_GetMikeScenarioWithMikeScenarioIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMikeScenarioService.GetMikeScenarioWithMikeScenarioTVItemIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MikeScenarioModel mikeScenarioModelRe2 = mikeScenarioService.PostDeleteMikeScenarioWithMikeScenarioTVItemIDDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MikeScenario), mikeScenarioModelRe2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostDeleteMikeScenarioAndAllAssociationsWithMikeScenarioTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                Assert.AreEqual("", tvItemModelRoot.Error);

                TVItemModel tvItemModelBouctouche = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                Assert.AreEqual("", tvItemModelBouctouche.Error);

                List<TVItemModel> tvItemModelMikeScenarioList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelBouctouche.TVItemID, TVTypeEnum.MikeScenario);
                Assert.IsTrue(tvItemModelMikeScenarioList.Count > 0);

                TVItemModel tvItemModelMikeScenario = new TVItemModel();
                foreach (TVItemModel tvItemModel in tvItemModelMikeScenarioList)
                {
                    MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModel.TVItemID);
                    if (mikeScenarioModel.ScenarioStatus == ScenarioStatusEnum.Completed)
                    {
                        tvItemModelMikeScenario = tvItemModel;
                        break;
                    }
                }

                using (TransactionScope tss = new TransactionScope())
                {
                    TVItemModel tvItemModelCopiedMikeScenario = mikeScenarioService.PostMikeScenarioCopyDB(tvItemModelMikeScenario.TVItemID);
                    Assert.AreEqual("", tvItemModelCopiedMikeScenario.Error);

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModelCopiedMikeScenario.TVItemID);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    MikeScenarioModel mikeScenarioModelRet2 = mikeScenarioService.PostDeleteMikeScenarioAndAllAssociationsWithMikeScenarioTVItemIDDB(mikeScenarioModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostUpdateMikeScenarioDB_MikeScenarioModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeScenarioService.MikeScenarioModelOKMikeScenarioModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostUpdateMikeScenarioDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeScenarioService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostUpdateMikeScenarioDB_GetMikeScenarioWithMikeScenarioIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMikeScenarioService.GetMikeScenarioWithMikeScenarioIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MikeScenario), mikeScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostUpdateMikeScenarioDB_FillMikeScenarioModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeScenarioService.FillMikeScenarioMikeScenarioMikeScenarioModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostUpdateMikeScenarioDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeScenarioService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostUpdateMikeScenarioDB_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostUpdateMikeScenarioDB_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMikeScenarioService.CreateTVTextMikeScenarioModel = (a) =>
                        {
                            return "";
                        };

                        MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), mikeScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostUpdateMikeScenarioDB_GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = "", TVItemID = mikeScenarioModelRet.MikeScenarioTVItemID };
                        };

                        MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);
                        Assert.AreEqual("", mikeScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostUpdateMikeScenarioDB_GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB_GetIsItSameObject_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = "", TVItemID = mikeScenarioModelRet.MikeScenarioTVItemID };
                        };
                        shimMikeScenarioService.GetIsItSameObjectMikeScenarioModelTVItemModel = (a, b) =>
                        {
                            return false;
                        };

                        MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MikeScenario), mikeScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostUpdateMikeScenarioDB_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAddMikeScenarioDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    string TVText = randomService.RandomString("Mike Scenario", 24);
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    SetupTest(contactModelListBad[0], culture);

                    mikeScenarioModelNew.MikeScenarioTVItemID = tvItemModelMikeScenario.TVItemID;
                    mikeScenarioModelNew.MikeScenarioTVText = TVText;

                    FillMikeScenarioModel(mikeScenarioModelNew);

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAddMikeScenarioDB_NeedToBeLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    string TVText = randomService.RandomString("Mike Scenario", 24);
                    TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    SetupTest(contactModelListGood[3], culture);

                    mikeScenarioModelNew.MikeScenarioTVItemID = tvItemModelMikeScenario.TVItemID;
                    mikeScenarioModelNew.MikeScenarioTVText = TVText;

                    FillMikeScenarioModel(mikeScenarioModelNew);

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAcceptWebTideDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);

                    MikeScenarioModel mikeScenarioModelRet3 = mikeScenarioService.PostAcceptWebTideDB(mikeScenarioModelRet2.MikeScenarioTVItemID);
                    Assert.AreEqual("", mikeScenarioModelRet3.Error);
                    Assert.AreEqual(mikeScenarioModelRet2.MikeScenarioID, mikeScenarioModelRet3.MikeScenarioID);

                    MikeScenarioModel mikeScenarioModelRet4 = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioIDDB(mikeScenarioModelRet2.MikeScenarioID);
                    Assert.AreEqual("", mikeScenarioModelRet4.Error);
                    Assert.AreEqual(ScenarioStatusEnum.Completed, mikeScenarioModelRet4.ScenarioStatus);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAcceptWebTideDB_MikeScenarioTVItemID_Zero_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);

                    int MikeScenarioTVItemID = 0;
                    MikeScenarioModel mikeScenarioModelRet3 = mikeScenarioService.PostAcceptWebTideDB(MikeScenarioTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), mikeScenarioModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAcceptWebTideDB_GetMikeScenarioModelWithMikeScenarioTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);
                    MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErrorText };
                        };

                        MikeScenarioModel mikeScenarioModelRet3 = mikeScenarioService.PostAcceptWebTideDB(mikeScenarioModelRet2.MikeScenarioID);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAcceptWebTideDB_GetParentTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetParentTVItemModelWithTVItemIDForLocationDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MikeScenarioModel mikeScenarioModelRet3 = mikeScenarioService.PostAcceptWebTideDB(mikeScenarioModelRet2.MikeScenarioTVItemID);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostAcceptWebTideDB_PostUpdateMikeScenarioDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    MikeScenarioModel mikeScenarioModelRet2 = UpdateMikeScenarioModel(mikeScenarioModelRet);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.PostUpdateMikeScenarioDBMikeScenarioModel = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErrorText };
                        };

                        MikeScenarioModel mikeScenarioModelRet3 = mikeScenarioService.PostAcceptWebTideDB(mikeScenarioModelRet2.MikeScenarioTVItemID);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet3.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostDeleteMeshNodeDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModelRet = AddMikeScenarioModel();

                    SetupNewMikeBoundaryCondition(mikeScenarioModelRet);

                    List<MikeBoundaryConditionModel> mikeBoundaryConditionModelList = mikeScenarioService._MikeBoundaryConditionService.GetMikeBoundaryConditionModelListWithMikeScenarioTVItemIDAndTVTypeDB(mikeScenarioModelRet.MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.IsTrue(mikeBoundaryConditionModelList.Count > 0);

                    List<MapInfoPointModel> mapInfoPointModelList = mikeScenarioService._MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mikeBoundaryConditionModelList[0].MikeBoundaryConditionTVItemID, TVTypeEnum.MikeBoundaryConditionMesh, MapInfoDrawTypeEnum.Polyline);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    int Count = mapInfoPointModelList.Count;

                    MapInfoPointModel mapInfoPointModel = mikeScenarioService.PostDeleteMeshNodeDB(mapInfoPointModelList[0].MapInfoPointID);
                    Assert.AreEqual("", mapInfoPointModel.Error);

                    List<MapInfoPointModel> mapInfoPointModelList2 = mikeScenarioService._MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mikeBoundaryConditionModelList[0].MikeBoundaryConditionTVItemID, TVTypeEnum.MikeBoundaryConditionMesh, MapInfoDrawTypeEnum.Polyline);
                    Assert.IsTrue(mapInfoPointModelList2.Count > 0);
                    Assert.AreEqual(Count - 1, mapInfoPointModelList2.Count);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostDeleteMeshNodeDB_MapInfoPointID_Zero_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModel = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    SetupNewMikeBoundaryCondition(mikeScenarioModel);

                    List<MikeBoundaryConditionModel> mikeBoundaryConditionModelList = mikeScenarioService._MikeBoundaryConditionService.GetMikeBoundaryConditionModelListWithMikeScenarioTVItemIDAndTVTypeDB(mikeScenarioModel.MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.IsTrue(mikeBoundaryConditionModelList.Count > 0);

                    List<MapInfoPointModel> mapInfoPointModelList = mikeScenarioService._MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mikeBoundaryConditionModelList[0].MikeBoundaryConditionTVItemID, TVTypeEnum.MikeBoundaryConditionMesh, MapInfoDrawTypeEnum.Polyline);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    int MapInfoPointID = 0;
                    MapInfoPointModel mapInfoPointModel = mikeScenarioService.PostDeleteMeshNodeDB(MapInfoPointID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoPointID), mapInfoPointModel.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostDeleteMeshNodeDB_PostDeleteMapInfoPointDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModel = AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    SetupNewMikeBoundaryCondition(mikeScenarioModel);

                    List<MikeBoundaryConditionModel> mikeBoundaryConditionModelList = mikeScenarioService._MikeBoundaryConditionService.GetMikeBoundaryConditionModelListWithMikeScenarioTVItemIDAndTVTypeDB(mikeScenarioModel.MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.IsTrue(mikeBoundaryConditionModelList.Count > 0);

                    List<MapInfoPointModel> mapInfoPointModelList = mikeScenarioService._MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mikeBoundaryConditionModelList[0].MikeBoundaryConditionTVItemID, TVTypeEnum.MikeBoundaryConditionMesh, MapInfoDrawTypeEnum.Polyline);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.PostDeleteMapInfoPointDBInt32 = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };

                        MapInfoPointModel mapInfoPointModel = mikeScenarioService.PostDeleteMeshNodeDB(mapInfoPointModelList[0].MapInfoPointID);
                        Assert.AreEqual(ErrorText, mapInfoPointModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCancelAndResetDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenairoModelRet = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModelMikeScenario.TVItemID);
                    Assert.AreEqual("", mikeScenairoModelRet.Error);

                    mikeScenairoModelRet.ScenarioStatus = ScenarioStatusEnum.AskToRun;
                    MikeScenarioModel mikeScenarioModelRet2 = mikeScenarioService.PostUpdateMikeScenarioDB(mikeScenairoModelRet);
                    Assert.AreEqual("", mikeScenarioModelRet2.Error);

                    AppTaskModel appTaskModelNew = new AppTaskModel()
                    {
                        TVItemID = tvItemModelMikeScenario.TVItemID,
                        TVItemID2 = tvItemModelMikeScenario.TVItemID,
                        AppTaskCommand = AppTaskCommandEnum.MikeScenarioRunning,
                        Parameters = "|||TVItemID,3|||MikeScenarioTVItemID,98|||",
                        Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en),
                        StartDateTime_UTC = DateTime.UtcNow,
                    };

                    AppTaskModel appTaskModelRet = mikeScenarioService._AppTaskService.PostAddAppTask(appTaskModelNew);
                    Assert.AreEqual("", appTaskModelRet.Error);

                    TVItemModel tvItemModelRet = mikeScenarioService.PostMikeScenarioCancelAndResetDB(mikeScenairoModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    MikeScenarioModel mikeScenarioModelRet3 = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(mikeScenairoModelRet.MikeScenarioTVItemID);
                    Assert.AreEqual(ScenarioStatusEnum.Error, mikeScenarioModelRet3.ScenarioStatus);

                    AppTaskModel appTaskModelRet2 = mikeScenarioService._AppTaskService.GetAppTaskModelWithAppTaskIDDB(appTaskModelRet.AppTaskID);
                    Assert.AreEqual(AppTaskCommandEnum.MikeScenarioToCancel, appTaskModelRet2.AppTaskCommand);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCancelAndResetDB_MikeScenarioTVItemID_Zero_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 0;
                    TVItemModel tvItemModelRet = mikeScenarioService.PostMikeScenarioCancelAndResetDB(MikeScenarioTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID), tvItemModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCancelAndResetDB_GetMikeScenarioModelWithMikeScenarioTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    using (ShimsContext.Create())
                    {
                        string ErroText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErroText };
                        };

                        TVItemModel tvItemModelRet = mikeScenarioService.PostMikeScenarioCancelAndResetDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErroText, tvItemModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCancelAndResetDB_GetParentTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    using (ShimsContext.Create())
                    {
                        string ErroText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetParentTVItemModelWithTVItemIDForLocationDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErroText };
                        };

                        TVItemModel tvItemModelRet = mikeScenarioService.PostMikeScenarioCancelAndResetDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErroText, tvItemModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCancelAndResetDB_PostUpdateMikeScenarioDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    using (ShimsContext.Create())
                    {
                        string ErroText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.PostUpdateMikeScenarioDBMikeScenarioModel = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErroText };
                        };

                        TVItemModel tvItemModelRet = mikeScenarioService.PostMikeScenarioCancelAndResetDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErroText, tvItemModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCancelAndResetDB_GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    using (ShimsContext.Create())
                    {
                        string ErroText = "ErrorText";
                        SetupShim();
                        shimAppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDBInt32Int32AppTaskCommandEnum = (a, b, c) =>
                        {
                            return new AppTaskModel() { Error = ErroText };
                        };

                        TVItemModel tvItemModelRet = mikeScenarioService.PostMikeScenarioCancelAndResetDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErroText, tvItemModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCancelAndResetDB_PostUpdateAppTask_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenairoModelRet = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModelMikeScenario.TVItemID);
                    Assert.AreEqual("", mikeScenairoModelRet.Error);

                    mikeScenairoModelRet.ScenarioStatus = ScenarioStatusEnum.AskToRun;
                    MikeScenarioModel mikeScenarioModelRet2 = mikeScenarioService.PostUpdateMikeScenarioDB(mikeScenairoModelRet);
                    Assert.AreEqual("", mikeScenarioModelRet2.Error);

                    AppTaskModel appTaskModelNew = new AppTaskModel()
                    {
                        TVItemID = tvItemModelMikeScenario.TVItemID,
                        TVItemID2 = tvItemModelMikeScenario.TVItemID,
                        AppTaskCommand = AppTaskCommandEnum.MikeScenarioRunning,
                        Parameters = "|||TVItemID,3|||MikeScenarioTVItemID,98|||",
                        Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en),
                        StartDateTime_UTC = DateTime.UtcNow,
                    };

                    AppTaskModel appTaskModelRet = mikeScenarioService._AppTaskService.PostAddAppTask(appTaskModelNew);
                    Assert.AreEqual("", appTaskModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErroText = "ErrorText";
                        SetupShim();
                        shimAppTaskService.PostUpdateAppTaskAppTaskModel = (a) =>
                        {
                            return new AppTaskModel() { Error = ErroText };
                        };

                        TVItemModel tvItemModelRet = mikeScenarioService.PostMikeScenarioCancelAndResetDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErroText, tvItemModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCancelAndResetDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeScenarioModel mikeScenairoModelRet = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModelMikeScenario.TVItemID);
                    Assert.AreEqual("", mikeScenairoModelRet.Error);

                    mikeScenairoModelRet.ScenarioStatus = ScenarioStatusEnum.AskToRun;
                    MikeScenarioModel mikeScenarioModelRet2 = mikeScenarioService.PostUpdateMikeScenarioDB(mikeScenairoModelRet);
                    Assert.AreEqual("", mikeScenarioModelRet2.Error);

                    AppTaskModel appTaskModelNew = new AppTaskModel()
                    {
                        TVItemID = tvItemModelMikeScenario.TVItemID,
                        TVItemID2 = tvItemModelMikeScenario.TVItemID,
                        AppTaskCommand = AppTaskCommandEnum.MikeScenarioRunning,
                        Parameters = "|||TVItemID,3|||MikeScenarioTVItemID,98|||",
                        Language = (culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en),
                        StartDateTime_UTC = DateTime.UtcNow,
                    };

                    AppTaskModel appTaskModelRet = mikeScenarioService._AppTaskService.PostAddAppTask(appTaskModelNew);
                    Assert.AreEqual("", appTaskModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVItemModel tvItemModelRet = mikeScenarioService.PostMikeScenarioCancelAndResetDB(tvItemModelMikeScenario.TVItemID);
                        Assert.AreEqual(ErrorText, tvItemModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCopyDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 15538;
                    TVItemModel tvItemModelCopiedMikeScenario = mikeScenarioService.PostMikeScenarioCopyDB(MikeScenarioTVItemID);
                    Assert.AreEqual("", tvItemModelCopiedMikeScenario.Error);

                    DestroyNewMikeScenarioWithFiles(tvItemModelCopiedMikeScenario.TVItemID);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCopyDB_MikeScenarioTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 0; // 15538;
                    TVItemModel tvItemModelCopiedMikeScenario = mikeScenarioService.PostMikeScenarioCopyDB(MikeScenarioTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), tvItemModelCopiedMikeScenario.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCopyDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        int MikeScenarioTVItemID = 15538;
                        TVItemModel tvItemModelCopiedMikeScenario = mikeScenarioService.PostMikeScenarioCopyDB(MikeScenarioTVItemID);
                        Assert.AreEqual(ErrorText, tvItemModelCopiedMikeScenario.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCopyDB_GetMikeScenarioModelWithMikeScenarioTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErrorText };
                        };

                        int MikeScenarioTVItemID = 15538;
                        TVItemModel tvItemModelCopiedMikeScenario = mikeScenarioService.PostMikeScenarioCopyDB(MikeScenarioTVItemID);
                        Assert.AreEqual(ErrorText, tvItemModelCopiedMikeScenario.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCopyDB_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        int MikeScenarioTVItemID = 15538;
                        TVItemModel tvItemModelCopiedMikeScenario = mikeScenarioService.PostMikeScenarioCopyDB(MikeScenarioTVItemID);
                        Assert.AreEqual(ErrorText, tvItemModelCopiedMikeScenario.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCopyDB_PostAddMikeScenarioDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.PostAddMikeScenarioDBMikeScenarioModel = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErrorText };
                        };

                        int MikeScenarioTVItemID = 15538;
                        TVItemModel tvItemModelCopiedMikeScenario = mikeScenarioService.PostMikeScenarioCopyDB(MikeScenarioTVItemID);
                        Assert.AreEqual(ErrorText, tvItemModelCopiedMikeScenario.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCopyDB_CopyMikeScenarioSource_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.CopyMikeScenarioSourceInt32MikeSourceModel = (a, b) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        int MikeScenarioTVItemID = 15538;
                        TVItemModel tvItemModelCopiedMikeScenario = mikeScenarioService.PostMikeScenarioCopyDB(MikeScenarioTVItemID);
                        Assert.AreEqual(ErrorText, tvItemModelCopiedMikeScenario.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCopyDB_GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDBInt32TVTypeEnum = (a, b) =>
                        {
                            return new List<TVItemModel>();
                        };

                        int MikeScenarioTVItemID = 15538;
                        TVItemModel tvItemModelCopiedMikeScenario = mikeScenarioService.PostMikeScenarioCopyDB(MikeScenarioTVItemID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFindAny_, ServiceRes.MikeBoundaryCondition), tvItemModelCopiedMikeScenario.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCopyDB_CopyMikeScenarioBoundaryCondition_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.CopyMikeScenarioBoundaryConditionInt32TVItemModelTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        int MikeScenarioTVItemID = 15538;
                        TVItemModel tvItemModelCopiedMikeScenario = mikeScenarioService.PostMikeScenarioCopyDB(MikeScenarioTVItemID);
                        Assert.AreEqual(ErrorText, tvItemModelCopiedMikeScenario.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioCopyDB_CopyMikeScenarioTVFile_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.CopyMikeScenarioTVFileMikeScenarioModelMikeScenarioModelTVFileModelString = (a, b, c, d) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        int MikeScenarioTVItemID = 15538;
                        TVItemModel tvItemModelCopiedMikeScenario = mikeScenarioService.PostMikeScenarioCopyDB(MikeScenarioTVItemID);
                        Assert.AreEqual(ErrorText, tvItemModelCopiedMikeScenario.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);

                    fc.Remove("DecayIsConstant");

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual("", mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_MikeScenarioTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["MikeScenarioTVItemID"] = "0";

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_GetMikeScenarioModelWithMikeScenarioTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErrorText };
                        };

                        MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_MikeScenarioName_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["MikeScenarioName"] = "";

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioName), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_MikeScenarioStartYear_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["MikeScenarioStartYear"] = "0";

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartYear), mikeScenarioModelRet.Error);

                    fc["MikeScenarioStartYear"] = "";

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartYear), mikeScenarioModelRet.Error);

                    fc["MikeScenarioStartYear"] = null;

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartYear), mikeScenarioModelRet.Error);

                    fc.Remove("MikeScenarioStartYear");

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartYear), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_MikeScenarioStartMonth_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["MikeScenarioStartMonth"] = "0";

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartMonth), mikeScenarioModelRet.Error);

                    fc["MikeScenarioStartMonth"] = "";

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartMonth), mikeScenarioModelRet.Error);

                    fc["MikeScenarioStartMonth"] = null;

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartMonth), mikeScenarioModelRet.Error);

                    fc.Remove("MikeScenarioStartMonth");

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartMonth), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_MikeScenarioStartDay_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["MikeScenarioStartDay"] = "0";

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartDay), mikeScenarioModelRet.Error);

                    fc["MikeScenarioStartDay"] = "";

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartDay), mikeScenarioModelRet.Error);

                    fc["MikeScenarioStartDay"] = null;

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartDay), mikeScenarioModelRet.Error);

                    fc.Remove("MikeScenarioStartDay");

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartDay), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_MikeScenarioStartTime_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    List<string> StartTimeList = new List<string>() { "", "12:", "1:123", "-1:12", "-2:13", "32:14", "12:-1", "12:-2", "12:87" };
                    foreach (string s in StartTimeList)
                    {
                        fc["MikeScenarioStartTime"] = s;

                        MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);

                        switch (s)
                        {
                            case "":
                                {
                                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartTime), mikeScenarioModelRet.Error);
                                }
                                break;
                            default:
                                {
                                    Assert.AreEqual(string.Format(ServiceRes.Time_NotWellFormed, s), mikeScenarioModelRet.Error);
                                }
                                break;
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_MikeScenarioEndYear_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["MikeScenarioEndYear"] = "0";

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndYear), mikeScenarioModelRet.Error);

                    fc["MikeScenarioEndYear"] = "";

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndYear), mikeScenarioModelRet.Error);

                    fc["MikeScenarioEndYear"] = null;

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndYear), mikeScenarioModelRet.Error);

                    fc.Remove("MikeScenarioEndYear");

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndYear), mikeScenarioModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_MikeScenarioEndMonth_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["MikeScenarioEndMonth"] = "";

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndMonth), mikeScenarioModelRet.Error);

                    fc["MikeScenarioEndMonth"] = "";

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndMonth), mikeScenarioModelRet.Error);

                    fc["MikeScenarioEndMonth"] = null;

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndMonth), mikeScenarioModelRet.Error);

                    fc.Remove("MikeScenarioEndMonth");

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndMonth), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_MikeScenarioEndDay_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["MikeScenarioEndDay"] = "";

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndDay), mikeScenarioModelRet.Error);

                    fc["MikeScenarioEndDay"] = "";

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndDay), mikeScenarioModelRet.Error);

                    fc["MikeScenarioEndDay"] = null;

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndDay), mikeScenarioModelRet.Error);

                    fc.Remove("MikeScenarioEndDay");

                    mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndDay), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_MikeScenarioEndTime_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    List<string> EndTimeList = new List<string>() { "", "12:", "1:123", "-1:12", "-2:13", "32:14", "12:-1", "12:-2", "12:87" };
                    foreach (string s in EndTimeList)
                    {
                        fc["MikeScenarioEndTime"] = s;

                        MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);

                        switch (s)
                        {
                            case "":
                                {
                                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndTime), mikeScenarioModelRet.Error);
                                }
                                break;
                            default:
                                {
                                    Assert.AreEqual(string.Format(ServiceRes.Time_NotWellFormed, s), mikeScenarioModelRet.Error);
                                }
                                break;
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_DecayFactor_per_day_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["DecayFactor_per_day"] = randomService.RandomDouble(-0.1, -0.4).ToString();

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.DecayFactor_per_day), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_DecayFactorAmplitude_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["DecayFactorAmplitude"] = randomService.RandomDouble(-0.01, -0.06).ToString();

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.DecayFactorAmplitude), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_AmbientTemperature_C_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["AmbientTemperature_C"] = randomService.RandomDouble(-10.1, -10.4).ToString();

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AmbientTemperature_C), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_AmbientSalinity_PSU_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["AmbientSalinity_PSU"] = randomService.RandomDouble(-0.1, -0.4).ToString();

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AmbientSalinity_PSU), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_ResultFrequency_min_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["ResultFrequency_min"] = randomService.RandomInt(-5, -4).ToString();

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ResultFrequency_min), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_ManningNumber_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["ManningNumber"] = randomService.RandomInt(-25, -20).ToString();

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ManningNumber), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_WindSpeed_km_h_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["WindSpeed_km_h"] = randomService.RandomInt(-25, -20).ToString();

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.WindSpeed_km_h), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_WindDirection_deg_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    fc["WindDirection_deg"] = randomService.RandomInt(-25, -20).ToString();

                    MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.WindDirection_deg), mikeScenarioModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioGeneralParametersSaveDB_PostUpdateMikeScenarioDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fc = GetMikeScenarioGeneralParameterFormCollection(tvItemModelMikeScenario);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.PostUpdateMikeScenarioDBMikeScenarioModel = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErrorText };
                        };

                        MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostMikeScenarioGeneralParametersSaveDB(fc);
                        Assert.AreEqual(ErrorText, mikeScenarioModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioOtherFileNotImportDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVFileModel> tvFileModelList = tvFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModelMikeScenario.TVItemID);
                    Assert.IsTrue(tvFileModelList.Count > 0);

                    TVFileModel tvFileModelRet = mikeScenarioService.PostMikeScenarioOtherFileNotImportDB(tvFileModelList[0].TVFileTVItemID);
                    Assert.AreEqual("", tvFileModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioOtherFileNotImportDB_TVFileTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVFileModel> tvFileModelList = tvFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModelMikeScenario.TVItemID);
                    Assert.IsTrue(tvFileModelList.Count > 0);

                    TVFileModel tvFileModelRet = mikeScenarioService.PostMikeScenarioOtherFileNotImportDB(0);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVFileTVItemID), tvFileModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioOtherFileNotImportDB_GetTVFileModelWithTVFileTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVFileModel> tvFileModelList = tvFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModelMikeScenario.TVItemID);
                    Assert.IsTrue(tvFileModelList.Count > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVFileService.GetTVFileModelWithTVFileTVItemIDDBInt32 = (a) =>
                        {
                            return new TVFileModel() { Error = ErrorText };
                        };

                        TVFileModel tvFileModelRet = mikeScenarioService.PostMikeScenarioOtherFileNotImportDB(tvFileModelList[0].TVFileTVItemID);
                        Assert.AreEqual(ErrorText, tvFileModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeScenarioOtherFileNotImportDB_PostUpdateTVFileDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVFileModel> tvFileModelList = tvFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModelMikeScenario.TVItemID);
                    Assert.IsTrue(tvFileModelList.Count > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVFileService.PostUpdateTVFileDBTVFileModel = (a) =>
                        {
                            return new TVFileModel() { Error = ErrorText };
                        };

                        TVFileModel tvFileModelRet = mikeScenarioService.PostMikeScenarioOtherFileNotImportDB(tvFileModelList[0].TVFileTVItemID);
                        Assert.AreEqual(ErrorText, tvFileModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_MikeScenarioTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    fc["MikeScenarioTVItemID"] = "0";
                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), mikeSourceModelRet.Error);

                    fc["MikeScenarioTVItemID"] = "";
                    mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), mikeSourceModelRet.Error);

                    fc["MikeScenarioTVItemID"] = null;
                    mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), mikeSourceModelRet.Error);

                    fc.Remove("MikeScenarioTVItemID");
                    mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_GetMikeScenarioModelWithMikeScenarioTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_SourceName_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);


                    fc["SourceName"] = "";

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SourceName), mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_Include_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    fc["Include"] = "";

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    fc["Include"] = "true";

                    mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_IsRiver_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    fc["IsRiver"] = "";

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    fc["IsRiver"] = "true";

                    mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_IsContinuous_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    fc["IsContinuous"] = "";

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    fc["IsContinuous"] = "true";

                    mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_Lat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    fc["Lat"] = "0.0";

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Lat), mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_Lng_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    fc["Lng"] = "0.0";

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Lng), mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_MikeSourceSameName_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);

                    string MikeSourceName = fc["SourceName"].Trim();
                    Assert.AreEqual(string.Format(ServiceRes.MikeSource_AlreadyExist, MikeSourceName), mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceService.CreateTVTextMikeSourceModel = (a) =>
                        {
                            return "";
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_PostAddMikeSourceDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceService.PostAddMikeSourceDBMikeSourceModel = (a) =>
                        {
                            return new MikeSourceModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_CreateMapInfoObjectDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoService.CreateMapInfoObjectDBListOfCoordMapInfoDrawTypeEnumTVTypeEnumInt32 = (a, b, c, d) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_PostAddMikeSourceStartEndDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceStartEndService.PostAddMikeSourceStartEndDBMikeSourceStartEndModel = (a) =>
                        {
                            return new MikeSourceStartEndModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceDeleteDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    int FirstCounted = tvItemModelList.Count;

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceDeleteDB(tvItemModelList[0].TVItemID);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.AreEqual(FirstCounted - 1, tvItemModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceDeleteDB_MikeSourceTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    int FirstCounted = tvItemModelList.Count;

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceDeleteDB(0);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID), mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceDeleteDB_GetParentTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    int FirstCounted = tvItemModelList.Count;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetParentTVItemModelWithTVItemIDForLocationDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceDeleteDB(tvItemModelList[0].TVItemID);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceDeleteDB_GetMikeScenarioModelWithMikeScenarioTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    int FirstCounted = tvItemModelList.Count;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeScenarioModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceDeleteDB(tvItemModelList[0].TVItemID);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceDeleteDB_GetMikeSourceModelWithMikeSourceTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    int FirstCounted = tvItemModelList.Count;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeSourceModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceDeleteDB(tvItemModelList[0].TVItemID);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceDeleteDB_PostDeleteMikeSourceWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVItemModel> tvItemModelList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource);
                    Assert.IsTrue(tvItemModelList.Count > 0);

                    int FirstCounted = tvItemModelList.Count;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceService.PostDeleteMikeSourceWithTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeSourceModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceDeleteDB(tvItemModelList[0].TVItemID);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndAddDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    int CountMikeSourceStartEndModel = mikeSourceStartEndModelList.Count;

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndAddDB(tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual("", mikeSourceStartEndModelRet.Error);

                    mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual(CountMikeSourceStartEndModel + 1, mikeSourceStartEndModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndAddDB_MikeSourceTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    int CountMikeSourceStartEndModel = mikeSourceStartEndModelList.Count;

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndAddDB(0);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndAddDB_GetMikeSourceModelWithMikeSourceTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    int CountMikeSourceStartEndModel = mikeSourceStartEndModelList.Count;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeSourceModel() { Error = ErrorText };
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndAddDB(tvItemModelMikeSource.TVItemID);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndAddDB_PostAddMikeSourceStartEndDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    int CountMikeSourceStartEndModel = mikeSourceStartEndModelList.Count;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceStartEndService.PostAddMikeSourceStartEndDBMikeSourceStartEndModel = (a) =>
                        {
                            return new MikeSourceStartEndModel() { Error = ErrorText };
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndAddDB(tvItemModelMikeSource.TVItemID);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndDeleteDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    int CountMikeSourceStartEndModel = mikeSourceStartEndModelList.Count;

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndDeleteDB(mikeSourceStartEndModelList[0].MikeSourceStartEndID, tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual("", mikeSourceStartEndModelRet.Error);

                    mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual(CountMikeSourceStartEndModel - 1, mikeSourceStartEndModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndDeleteDB_MikeSourceTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    int CountMikeSourceStartEndModel = mikeSourceStartEndModelList.Count;

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndDeleteDB(mikeSourceStartEndModelList[0].MikeSourceStartEndID, 0);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndDeleteDB_MikeSourceStartEndID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    int CountMikeSourceStartEndModel = mikeSourceStartEndModelList.Count;

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndDeleteDB(0, tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartEndID), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndDeleteDB_GetMikeSourceModelWithMikeSourceTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    int CountMikeSourceStartEndModel = mikeSourceStartEndModelList.Count;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeSourceModel() { Error = ErrorText };
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndDeleteDB(mikeSourceStartEndModelList[0].MikeSourceStartEndID, tvItemModelMikeSource.TVItemID);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndDeleteDB_PostDeleteMikeSourceStartEndDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    int CountMikeSourceStartEndModel = mikeSourceStartEndModelList.Count;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceStartEndService.PostDeleteMikeSourceStartEndDBInt32 = (a) =>
                        {
                            return new MikeSourceStartEndModel() { Error = ErrorText };
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndDeleteDB(mikeSourceStartEndModelList[0].MikeSourceStartEndID, tvItemModelMikeSource.TVItemID);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceModel mikeSourceModel = mikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    MikeSourceModel mikeSourceModelRet = mikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual("", mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_MikeSourceTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    fc["MikeSourceID"] = "";
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceID"] = "0";
                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceID"] = null;
                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID), mikeSourceStartEndModelRet.Error);

                    fc.Remove("MikeSourceID");
                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_GetMikeSourceModelWithMikeSourceIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceModel mikeSourceModel = mikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    MikeSourceModel mikeSourceModelRet = mikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceService.GetMikeSourceModelWithMikeSourceIDDBInt32 = (a) =>
                        {
                            return new MikeSourceModel() { Error = ErrorText };
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_MikeSourceStartEndID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    fc["MikeSourceStartEndID"] = "";
                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartEndID), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceStartEndID"] = "0";
                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartEndID), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceStartEndID"] = null;
                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartEndID), mikeSourceStartEndModelRet.Error);

                    fc.Remove("MikeSourceStartEndID");
                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartEndID), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_GetMikeSourceStartEndModelWithMikeSourceStartEndIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceStartEndService.GetMikeSourceStartEndModelWithMikeSourceStartEndIDDBInt32 = (a) =>
                        {
                            return new MikeSourceStartEndModel() { Error = ErrorText };
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_MikeSourceStartYear_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceModel mikeSourceModel = mikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    MikeSourceModel mikeSourceModelRet = mikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    fc["MikeSourceStartYear"] = "0";

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartYear), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceStartYear"] = "";

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartYear), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceStartYear"] = null;

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartYear), mikeSourceStartEndModelRet.Error);

                    fc.Remove("MikeSourceStartYear");

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartYear), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_MikeSourceStartMonth_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceModel mikeSourceModel = mikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    MikeSourceModel mikeSourceModelRet = mikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    fc["MikeSourceStartMonth"] = "0";

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartMonth), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceStartMonth"] = "";

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartMonth), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceStartMonth"] = null;

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartMonth), mikeSourceStartEndModelRet.Error);

                    fc.Remove("MikeSourceStartMonth");

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartMonth), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_MikeSourceStartDay_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceModel mikeSourceModel = mikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    MikeSourceModel mikeSourceModelRet = mikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    fc["MikeSourceStartDay"] = "0";

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartDay), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceStartDay"] = "";

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartDay), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceStartDay"] = null;

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartDay), mikeSourceStartEndModelRet.Error);

                    fc.Remove("MikeSourceStartDay");

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartDay), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_MikeSourceStartTime_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceModel mikeSourceModel = mikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    MikeSourceModel mikeSourceModelRet = mikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    List<string> StartTimeList = new List<string>() { "", "12:", "1:123", "-1:12", "-2:13", "32:14", "12:-1", "12:-2", "12:87" };
                    foreach (string s in StartTimeList)
                    {
                        fc["MikeSourceStartTime"] = s;

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);

                        switch (s)
                        {
                            case "":
                                {
                                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartTime), mikeSourceStartEndModelRet.Error);
                                }
                                break;
                            default:
                                {
                                    Assert.AreEqual(string.Format(ServiceRes.Time_NotWellFormed, s), mikeSourceStartEndModelRet.Error);
                                }
                                break;
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_MikeSourceEndYear_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fcSource = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    MikeSourceModel mikeSourceModel = mikeScenarioService.PostMikeSourceAddOrModifyDB(fcSource);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    mikeSourceModel = mikeScenarioService._MikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    TVItemModel tvItemModelMikeSource = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceStartEndModel mikeSourceStartEndModel = mikeScenarioService.PostMikeSourceStartEndAddDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.AreEqual("", mikeSourceStartEndModel.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeScenarioService._MikeSourceService._MikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceIDDB(mikeSourceModel.MikeSourceID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    fc["MikeSourceEndYear"] = "0";

                    MikeSourceStartEndModel mikeSourceStarEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndYear), mikeSourceStarEndModelRet.Error);

                    fc["MikeSourceEndYear"] = "";

                    mikeSourceStarEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndYear), mikeSourceStarEndModelRet.Error);

                    fc["MikeSourceEndYear"] = null;

                    mikeSourceStarEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndYear), mikeSourceStarEndModelRet.Error);

                    fc.Remove("MikeSourceEndYear");

                    mikeSourceStarEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndYear), mikeSourceStarEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_MikeSourceEndMonth_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fcSource = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    MikeSourceModel mikeSourceModel = mikeScenarioService.PostMikeSourceAddOrModifyDB(fcSource);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    mikeSourceModel = mikeScenarioService._MikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    TVItemModel tvItemModelMikeSource = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceStartEndModel mikeSourceStartEndModel = mikeScenarioService.PostMikeSourceStartEndAddDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.AreEqual("", mikeSourceStartEndModel.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeScenarioService._MikeSourceService._MikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceIDDB(mikeSourceModel.MikeSourceID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    fc["MikeSourceEndMonth"] = "0";

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndMonth), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceEndMonth"] = "";

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndMonth), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceEndMonth"] = null;

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndMonth), mikeSourceStartEndModelRet.Error);

                    fc.Remove("MikeSourceEndMonth");

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndMonth), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_MikeSourceEndDay_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fcSource = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    MikeSourceModel mikeSourceModel = mikeScenarioService.PostMikeSourceAddOrModifyDB(fcSource);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    mikeSourceModel = mikeScenarioService._MikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    TVItemModel tvItemModelMikeSource = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceStartEndModel mikeSourceStartEndModel = mikeScenarioService.PostMikeSourceStartEndAddDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.AreEqual("", mikeSourceStartEndModel.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeScenarioService._MikeSourceService._MikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceIDDB(mikeSourceModel.MikeSourceID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    fc["MikeSourceEndDay"] = "0";

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndDay), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceEndDay"] = "";

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndDay), mikeSourceStartEndModelRet.Error);

                    fc["MikeSourceEndDay"] = null;

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndDay), mikeSourceStartEndModelRet.Error);

                    fc.Remove("MikeSourceEndDay");

                    mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndDay), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_MikeSourceEndTime_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fcSource = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    MikeSourceModel mikeSourceModel = mikeScenarioService.PostMikeSourceAddOrModifyDB(fcSource);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    mikeSourceModel = mikeScenarioService._MikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    TVItemModel tvItemModelMikeSource = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceStartEndModel mikeSourceStartEndModel = mikeScenarioService.PostMikeSourceStartEndAddDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.AreEqual("", mikeSourceStartEndModel.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeScenarioService._MikeSourceService._MikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceIDDB(mikeSourceModel.MikeSourceID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    List<string> StartTimeList = new List<string>() { "", "12:", "1:123", "-1:12", "-2:13", "32:14", "12:-1", "12:-2", "12:87" };
                    foreach (string s in StartTimeList)
                    {
                        fc["MikeSourceEndTime"] = s;

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);

                        switch (s)
                        {
                            case "":
                                {
                                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndTime), mikeSourceStartEndModelRet.Error);
                                }
                                break;
                            default:
                                {
                                    Assert.AreEqual(string.Format(ServiceRes.Time_NotWellFormed, s), mikeSourceStartEndModelRet.Error);
                                }
                                break;
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_SourceFlowStart_m3_day_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> MikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(MikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, MikeSourceStartEndModelList);

                    fc["SourceFlowStart_m3_day"] = randomService.RandomDouble(-0.1, -0.4).ToString();

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SourceFlowStart_m3_day), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_SourcePollutionStart_MPN_100ml_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> MikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(MikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, MikeSourceStartEndModelList);

                    fc["SourcePollutionStart_MPN_100ml"] = randomService.RandomInt(-6, -4).ToString();

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SourcePollutionStart_MPN_100ml), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_SourceTemperatureStart_C_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> MikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(MikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, MikeSourceStartEndModelList);

                    fc["SourceTemperatureStart_C"] = randomService.RandomDouble(-16.1, -14.3).ToString();

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SourceTemperatureStart_C), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_SourceSalinityStart_PSU_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> MikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(MikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, MikeSourceStartEndModelList);

                    fc["SourceSalinityStart_PSU"] = randomService.RandomDouble(-1.1, -1.3).ToString();

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SourceSalinityStart_PSU), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_SourceFlowEnd_m3_day_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fcSource = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    MikeSourceModel mikeSourceModel = mikeScenarioService.PostMikeSourceAddOrModifyDB(fcSource);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    mikeSourceModel = mikeScenarioService._MikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    TVItemModel tvItemModelMikeSource = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceStartEndModel mikeSourceStartEndModel = mikeScenarioService.PostMikeSourceStartEndAddDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.AreEqual("", mikeSourceStartEndModel.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeScenarioService._MikeSourceService._MikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceIDDB(mikeSourceModel.MikeSourceID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    fc["SourceFlowEnd_m3_day"] = randomService.RandomDouble(-0.1, -0.4).ToString();

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SourceFlowEnd_m3_day), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_SourcePollutionEnd_MPN_100ml_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fcSource = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    MikeSourceModel mikeSourceModel = mikeScenarioService.PostMikeSourceAddOrModifyDB(fcSource);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    mikeSourceModel = mikeScenarioService._MikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    TVItemModel tvItemModelMikeSource = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceStartEndModel mikeSourceStartEndModel = mikeScenarioService.PostMikeSourceStartEndAddDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.AreEqual("", mikeSourceStartEndModel.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeScenarioService._MikeSourceService._MikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceIDDB(mikeSourceModel.MikeSourceID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    fc["SourcePollutionEnd_MPN_100ml"] = randomService.RandomInt(-6, -4).ToString();

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SourcePollutionEnd_MPN_100ml), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_SourceTemperatureEnd_C_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fcSource = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    MikeSourceModel mikeSourceModel = mikeScenarioService.PostMikeSourceAddOrModifyDB(fcSource);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    mikeSourceModel = mikeScenarioService._MikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    TVItemModel tvItemModelMikeSource = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceStartEndModel mikeSourceStartEndModel = mikeScenarioService.PostMikeSourceStartEndAddDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.AreEqual("", mikeSourceStartEndModel.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeScenarioService._MikeSourceService._MikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceIDDB(mikeSourceModel.MikeSourceID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    fc["SourceTemperatureEnd_C"] = randomService.RandomInt(-16, -14).ToString();

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SourceTemperatureEnd_C), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_SourceSalinityEnd_PSU_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    FormCollection fcSource = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeScenario);

                    MikeSourceModel mikeSourceModel = mikeScenarioService.PostMikeSourceAddOrModifyDB(fcSource);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    mikeSourceModel.IsContinuous = false;

                    mikeSourceModel = mikeScenarioService._MikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    Assert.AreEqual("", mikeSourceModel.Error);

                    TVItemModel tvItemModelMikeSource = mikeScenarioService._TVItemService.GetTVItemModelWithTVItemIDDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.IsNotNull(tvItemModelMikeSource);

                    MikeSourceStartEndModel mikeSourceStartEndModel = mikeScenarioService.PostMikeSourceStartEndAddDB(mikeSourceModel.MikeSourceTVItemID);
                    Assert.AreEqual("", mikeSourceStartEndModel.Error);

                    List<MikeSourceStartEndModel> mikeSourceStartEndModelList = mikeScenarioService._MikeSourceService._MikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceIDDB(mikeSourceModel.MikeSourceID);
                    Assert.IsTrue(mikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, mikeSourceStartEndModelList);

                    fc["SourceSalinityEnd_PSU"] = randomService.RandomDouble(-1.1, -1.3).ToString();

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SourceSalinityEnd_PSU), mikeSourceStartEndModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceStartEndSaveDB_PostUpdateMikeSourceStartEndDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    List<MikeSourceStartEndModel> MikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.IsTrue(MikeSourceStartEndModelList.Count > 0);

                    FormCollection fc = GetPostMikeSourceStartEndSaveDBFormCollection(tvItemModelMikeSource, MikeSourceStartEndModelList);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceStartEndService.PostUpdateMikeSourceStartEndDBMikeSourceStartEndModel = (a) =>
                        {
                            return new MikeSourceStartEndModel() { Error = ErrorText };
                        };

                        MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService.PostMikeSourceStartEndSaveDB(fc);
                        Assert.AreEqual(ErrorText, mikeSourceStartEndModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_GetMikeSourceModelWithMikeSourceTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    string SourceName = randomService.RandomString("Source Name ", 30);
                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeSource, tvItemModelMikeScenario, SourceName);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeSourceModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_Include_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    string SourceName = randomService.RandomString("Source Name ", 30);
                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeSource, tvItemModelMikeScenario, SourceName);

                    fc["Include"] = "";

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    fc["Include"] = "true";

                    mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_IsRiver_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    string SourceName = randomService.RandomString("Source Name ", 30);
                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeSource, tvItemModelMikeScenario, SourceName);

                    fc["IsRiver"] = "";

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    fc["IsRiver"] = "true";

                    mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_IsContinuous_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    string SourceName = randomService.RandomString("Source Name ", 30);
                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeSource, tvItemModelMikeScenario, SourceName);

                    fc["IsContinuous"] = "";

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    fc["IsContinuous"] = "true";

                    mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual("", mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_Lat_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    string SourceName = randomService.RandomString("Source Name ", 30);
                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeSource, tvItemModelMikeScenario, SourceName);

                    fc["Lat"] = "0.0";

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Lat), mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_Lng_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    string SourceName = randomService.RandomString("Source Name ", 30);
                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeSource, tvItemModelMikeScenario, SourceName);

                    fc["Lng"] = "0.0";

                    MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Lng), mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_GetMapInfoPointModelListWithTVItemIDAndMapPurposeAndMapInfoDrawTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    string SourceName = randomService.RandomString("Source Name ", 30);
                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeSource, tvItemModelMikeScenario, SourceName);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDBInt32TVTypeEnumMapInfoDrawTypeEnum = (a, b, c) =>
                        {
                            return new List<MapInfoPointModel>();
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint), mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_PostUpdateMikeSourceDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    string SourceName = randomService.RandomString("Source Name ", 30);
                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeSource, tvItemModelMikeScenario, SourceName);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceService.PostUpdateMikeSourceDBMikeSourceModel = (a) =>
                        {
                            return new MikeSourceModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeScenarioService_PostMikeSourceAddOrModifyDB_PostUpdateMapInfoPointDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeSource = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelMikeSource);

                    string SourceName = randomService.RandomString("Source Name ", 30);
                    FormCollection fc = GetPostMikeSourceAddOrModifyDBFormCollection(tvItemModelMikeSource, tvItemModelMikeScenario, SourceName);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.PostUpdateMapInfoPointDBMapInfoPointModel = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = mikeScenarioService.PostMikeSourceAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions
        public MikeScenarioModel AddMikeScenarioModel()
        {
            TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);

            Assert.AreEqual("", tvItemModelMunicipality.Error);

            string TVText = randomService.RandomString("Mike Scenario ", 20);
            TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.MikeScenario);

            Assert.AreEqual("", tvItemModelMikeScenario.Error);

            mikeScenarioModelNew.MikeScenarioTVItemID = tvItemModelMikeScenario.TVItemID;
            mikeScenarioModelNew.MikeScenarioTVText = TVText;
            FillMikeScenarioModel(mikeScenarioModelNew);

            MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModelRet.Error))
            {
                return mikeScenarioModelRet;
            }

            mikeScenarioModelNew.MikeScenarioTVItemID = mikeScenarioModelRet.MikeScenarioTVItemID;

            CompareMikeScenarioModels(mikeScenarioModelNew, mikeScenarioModelRet);

            return mikeScenarioModelRet;

        }
        public MikeScenarioModel UpdateMikeScenarioModel(MikeScenarioModel mikeScenarioModel)
        {
            FillMikeScenarioModel(mikeScenarioModel);

            MikeScenarioModel mikeScenarioModelRet2 = mikeScenarioService.PostUpdateMikeScenarioDB(mikeScenarioModel);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModelRet2.Error))
            {
                return mikeScenarioModelRet2;
            }

            CompareMikeScenarioModels(mikeScenarioModel, mikeScenarioModelRet2);

            return mikeScenarioModelRet2;
        }
        private void CompareMikeScenarioModels(MikeScenarioModel mikeScenarioModelNew, MikeScenarioModel mikeScenarioModelRet)
        {
            Assert.AreEqual(mikeScenarioModelNew.MikeScenarioTVItemID, mikeScenarioModelRet.MikeScenarioTVItemID);
            Assert.AreEqual(mikeScenarioModelNew.AmbientSalinity_PSU, mikeScenarioModelRet.AmbientSalinity_PSU);
            Assert.AreEqual(mikeScenarioModelNew.AmbientTemperature_C, mikeScenarioModelRet.AmbientTemperature_C);
            Assert.AreEqual(mikeScenarioModelNew.DecayFactor_per_day, mikeScenarioModelRet.DecayFactor_per_day);
            Assert.AreEqual(mikeScenarioModelNew.DecayFactorAmplitude, mikeScenarioModelRet.DecayFactorAmplitude);
            Assert.AreEqual(mikeScenarioModelNew.DecayIsConstant, mikeScenarioModelRet.DecayIsConstant);
            Assert.AreEqual(mikeScenarioModelNew.ErrorInfo, mikeScenarioModelRet.ErrorInfo);
            Assert.AreEqual(mikeScenarioModelNew.EstimatedHydroFileSize, mikeScenarioModelRet.EstimatedHydroFileSize);
            Assert.AreEqual(mikeScenarioModelNew.EstimatedTransFileSize, mikeScenarioModelRet.EstimatedTransFileSize);
            Assert.AreEqual(mikeScenarioModelNew.ManningNumber, mikeScenarioModelRet.ManningNumber);
            Assert.AreEqual(mikeScenarioModelNew.MikeScenarioEndDateTime_Local, mikeScenarioModelRet.MikeScenarioEndDateTime_Local);
            Assert.AreEqual(mikeScenarioModelNew.MikeScenarioExecutionTime_min, mikeScenarioModelRet.MikeScenarioExecutionTime_min);
            Assert.AreEqual(mikeScenarioModelNew.MikeScenarioStartDateTime_Local, mikeScenarioModelRet.MikeScenarioStartDateTime_Local);
            Assert.AreEqual(mikeScenarioModelNew.MikeScenarioStartExecutionDateTime_Local, mikeScenarioModelRet.MikeScenarioStartExecutionDateTime_Local);
            Assert.AreEqual(mikeScenarioModelNew.NumberOfElements, mikeScenarioModelRet.NumberOfElements);
            Assert.AreEqual(mikeScenarioModelNew.NumberOfHydroOutputParameters, mikeScenarioModelRet.NumberOfHydroOutputParameters);
            Assert.AreEqual(mikeScenarioModelNew.NumberOfSigmaLayers, mikeScenarioModelRet.NumberOfSigmaLayers);
            Assert.AreEqual(mikeScenarioModelNew.NumberOfTimeSteps, mikeScenarioModelRet.NumberOfTimeSteps);
            Assert.AreEqual(mikeScenarioModelNew.NumberOfTransOutputParameters, mikeScenarioModelRet.NumberOfTransOutputParameters);
            Assert.AreEqual(mikeScenarioModelNew.NumberOfZLayers, mikeScenarioModelRet.NumberOfZLayers);
            Assert.AreEqual(mikeScenarioModelNew.ResultFrequency_min, mikeScenarioModelRet.ResultFrequency_min);
            Assert.AreEqual(mikeScenarioModelNew.ScenarioStatus, mikeScenarioModelRet.ScenarioStatus);
            Assert.AreEqual(mikeScenarioModelNew.WindDirection_deg, mikeScenarioModelRet.WindDirection_deg);
            Assert.AreEqual(mikeScenarioModelNew.WindSpeed_km_h, mikeScenarioModelRet.WindSpeed_km_h);
        }
        public void FillMikeScenarioModel(MikeScenarioModel mikeScenarioModel)
        {
            mikeScenarioModel.MikeScenarioTVItemID = mikeScenarioModel.MikeScenarioTVItemID;
            mikeScenarioModel.MikeScenarioTVText = mikeScenarioModel.MikeScenarioTVText;
            mikeScenarioModel.AmbientSalinity_PSU = randomService.RandomDouble(0, 35);
            mikeScenarioModel.AmbientTemperature_C = randomService.RandomDouble(0, 35);
            mikeScenarioModel.DecayFactor_per_day = randomService.RandomDouble(4.0f, 6.0f);
            mikeScenarioModel.DecayFactorAmplitude = mikeScenarioModel.DecayFactor_per_day - (double)0.1D;
            mikeScenarioModel.DecayIsConstant = true;
            mikeScenarioModel.ErrorInfo = randomService.RandomString("Error info2", 200);
            mikeScenarioModel.EstimatedHydroFileSize = randomService.RandomInt(100, 4000000);
            mikeScenarioModel.EstimatedTransFileSize = randomService.RandomInt(100, 4000000);
            mikeScenarioModel.ManningNumber = randomService.RandomDouble(20D, 40D);
            mikeScenarioModel.MikeScenarioStartDateTime_Local = randomService.RandomDateTime();
            mikeScenarioModel.MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local.AddHours(1);
            mikeScenarioModel.MikeScenarioExecutionTime_min = randomService.RandomDouble(10, 1000);
            mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local = randomService.RandomDateTime();
            mikeScenarioModel.NumberOfElements = randomService.RandomInt(10, 6000);
            mikeScenarioModel.NumberOfHydroOutputParameters = randomService.RandomInt(2, 20);
            mikeScenarioModel.NumberOfSigmaLayers = randomService.RandomInt(2, 5);
            mikeScenarioModel.NumberOfTimeSteps = randomService.RandomInt(20, 80);
            mikeScenarioModel.NumberOfTransOutputParameters = randomService.RandomInt(2, 20);
            mikeScenarioModel.NumberOfZLayers = randomService.RandomInt(2, 8);
            mikeScenarioModel.ResultFrequency_min = randomService.RandomInt(5, 60);
            mikeScenarioModel.ScenarioStatus = ScenarioStatusEnum.Running;
            mikeScenarioModel.WindDirection_deg = randomService.RandomDouble(0, 360);
            mikeScenarioModel.WindSpeed_km_h = randomService.RandomDouble(0, 100);

            Assert.IsTrue(mikeScenarioModel.MikeScenarioTVItemID != 0);
            Assert.IsTrue(mikeScenarioModel.MikeScenarioTVText.Length > 0);
            Assert.IsTrue(mikeScenarioModel.AmbientSalinity_PSU >= 0 && mikeScenarioModel.AmbientSalinity_PSU <= 35);
            Assert.IsTrue(mikeScenarioModel.AmbientTemperature_C >= 0 && mikeScenarioModel.AmbientTemperature_C <= 35);
            Assert.IsTrue(mikeScenarioModel.DecayFactor_per_day >= 4 && mikeScenarioModel.DecayFactor_per_day <= 6);
            Assert.IsTrue(mikeScenarioModel.DecayFactorAmplitude < mikeScenarioModel.DecayFactor_per_day);
            Assert.IsTrue(mikeScenarioModel.DecayIsConstant == true);
            Assert.IsTrue(mikeScenarioModel.ErrorInfo.Length == 200);
            Assert.IsTrue(mikeScenarioModel.EstimatedHydroFileSize >= 100 && mikeScenarioModel.EstimatedHydroFileSize <= 4000000);
            Assert.IsTrue(mikeScenarioModel.EstimatedTransFileSize >= 100 && mikeScenarioModel.EstimatedTransFileSize <= 4000000);
            Assert.IsTrue(mikeScenarioModel.ManningNumber >= 20 && mikeScenarioModel.ManningNumber <= 40);
            Assert.IsTrue(mikeScenarioModel.MikeScenarioEndDateTime_Local != null);
            Assert.IsTrue(mikeScenarioModel.MikeScenarioExecutionTime_min >= 10 && mikeScenarioModel.MikeScenarioExecutionTime_min <= 1000);
            Assert.IsTrue(mikeScenarioModel.MikeScenarioStartDateTime_Local != null);
            Assert.IsTrue(mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local != null);
            Assert.IsTrue(mikeScenarioModel.NumberOfElements >= 10 && mikeScenarioModel.NumberOfElements <= 6000);
            Assert.IsTrue(mikeScenarioModel.NumberOfHydroOutputParameters >= 2 && mikeScenarioModel.NumberOfHydroOutputParameters <= 20);
            Assert.IsTrue(mikeScenarioModel.NumberOfSigmaLayers >= 2 && mikeScenarioModel.NumberOfSigmaLayers <= 5);
            Assert.IsTrue(mikeScenarioModel.NumberOfTimeSteps >= 20 && mikeScenarioModel.NumberOfTimeSteps <= 80);
            Assert.IsTrue(mikeScenarioModel.NumberOfTransOutputParameters >= 2 && mikeScenarioModel.NumberOfTransOutputParameters <= 20);
            Assert.IsTrue(mikeScenarioModel.NumberOfZLayers >= 2 && mikeScenarioModel.NumberOfZLayers <= 8);
            Assert.IsTrue(mikeScenarioModel.ResultFrequency_min >= 5 && mikeScenarioModel.ResultFrequency_min <= 60);
            Assert.IsTrue(mikeScenarioModel.ScenarioStatus == ScenarioStatusEnum.Running);
            Assert.IsTrue(mikeScenarioModel.WindDirection_deg >= 0 && mikeScenarioModel.WindDirection_deg <= 360);
            Assert.IsTrue(mikeScenarioModel.WindSpeed_km_h >= 0 && mikeScenarioModel.WindSpeed_km_h <= 100);
        }
        private FormCollection GetMikeScenarioGeneralParameterFormCollection(TVItemModel tvItemModelMikeScenario)
        {
            int StartYear = randomService.RandomInt(2014, 2025);
            int StartMonth = randomService.RandomInt(1, 12);
            int StartDay = randomService.RandomInt(1, 20);
            int EndYear = StartYear;
            int EndMonth = StartMonth;
            int EndDay = StartDay + 3;
            string StartTime = "04:30";
            string EndTime = "10:00";
            double DecayFactor_per_day = randomService.RandomDouble(0.05, 20);
            double DecayFactorAmplitude = DecayFactor_per_day - 0.01;

            FormCollection fc = new FormCollection();
            fc.Add("MikeScenarioTVItemID", tvItemModelMikeScenario.TVItemID.ToString());
            fc.Add("MikeScenarioName", randomService.RandomString("New MikeScenario Name", 30));
            fc.Add("MikeScenarioStartYear", StartYear.ToString());
            fc.Add("MikeScenarioStartMonth", StartMonth.ToString());
            fc.Add("MikeScenarioStartDay", StartDay.ToString());
            fc.Add("MikeScenarioStartTime", StartTime);
            fc.Add("MikeScenarioEndYear", EndYear.ToString());
            fc.Add("MikeScenarioEndMonth", EndMonth.ToString());
            fc.Add("MikeScenarioEndDay", EndDay.ToString());
            fc.Add("MikeScenarioEndTime", EndTime);
            fc.Add("DecayFactor_per_day", DecayFactor_per_day.ToString());
            fc.Add("DecayIsConstant", "on");
            fc.Add("DecayFactorAmplitude", DecayFactorAmplitude.ToString());
            fc.Add("AmbientTemperature_C", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("AmbientSalinity_PSU", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("ResultFrequency_min", "15");
            fc.Add("ManningNumber", "25");
            fc.Add("WindSpeed_km_h", "20");
            fc.Add("WindDirection_deg", "90");

            return fc;
        }
        private FormCollection GetPostMikeSourceStartEndSaveDBFormCollection(TVItemModel tvItemModelMikeSource, List<MikeSourceStartEndModel> mikeSourceStartEndModelList)
        {
            int StartYear = randomService.RandomInt(2014, 2025);
            int StartMonth = randomService.RandomInt(1, 12);
            int StartDay = randomService.RandomInt(1, 20);
            int EndYear = StartYear;
            int EndMonth = StartMonth;
            int EndDay = StartDay + 3;
            string StartTime = "04:30";
            string EndTime = "10:00";

            MikeSourceModel mikeSourceModel = mikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);

            Assert.AreEqual("", mikeSourceModel.Error);

            FormCollection fc = new FormCollection();
            fc.Add("MikeSourceID", mikeSourceModel.MikeSourceID.ToString());
            fc.Add("MikeSourceStartEndID", mikeSourceStartEndModelList[0].MikeSourceStartEndID.ToString());
            fc.Add("MikeSourceStartYear", StartYear.ToString());
            fc.Add("MikeSourceStartMonth", StartMonth.ToString());
            fc.Add("MikeSourceStartDay", StartDay.ToString());
            fc.Add("MikeSourceStartTime", StartTime);
            fc.Add("MikeSourceEndYear", EndYear.ToString());
            fc.Add("MikeSourceEndMonth", EndMonth.ToString());
            fc.Add("MikeSourceEndDay", EndDay.ToString());
            fc.Add("MikeSourceEndTime", EndTime);
            fc.Add("SourceFlowStart_m3_day", randomService.RandomDouble(0.1, 10000000).ToString());
            fc.Add("SourcePollutionStart_MPN_100ml", randomService.RandomInt(1, 10000000).ToString());
            fc.Add("SourceTemperatureStart_C", randomService.RandomDouble(1.0, 35.0).ToString());
            fc.Add("SourceSalinityStart_PSU", randomService.RandomDouble(1.0, 35.0).ToString());
            fc.Add("SourceFlowEnd_m3_day", randomService.RandomDouble(0.1, 10000000).ToString());
            fc.Add("SourcePollutionEnd_MPN_100ml", randomService.RandomInt(1, 10000000).ToString());
            fc.Add("SourceTemperatureEnd_C", randomService.RandomDouble(1.0, 35.0).ToString());
            fc.Add("SourceSalinityEnd_PSU", randomService.RandomDouble(1.0, 35.0).ToString());

            return fc;
        }
        private FormCollection GetPostMikeSourceAddOrModifyDBFormCollection(TVItemModel tvItemModelMikeScenario)
        {
            string SourceName = randomService.RandomString("New Source Name ", 30);

            FormCollection fc = new FormCollection();
            fc.Add("MikeScenarioTVItemID", tvItemModelMikeScenario.TVItemID.ToString());
            fc.Add("SourceName", SourceName);
            fc.Add("Include", "on");
            fc.Add("IsRiver", "on");
            fc.Add("IsContinuous", "on");
            fc.Add("Lat", "45");
            fc.Add("Lng", "-66");

            return fc;
        }
        private FormCollection GetPostMikeSourceAddOrModifyDBFormCollection(TVItemModel tvItemModelMikeSource, TVItemModel tvItemModelMikeScenario, string SourceName)
        {
            FormCollection fc = new FormCollection();
            fc.Add("SourceName", SourceName);
            fc.Add("MikeSourceTVItemID", tvItemModelMikeSource.TVItemID.ToString());
            fc.Add("MikeScenarioTVItemID", tvItemModelMikeScenario.TVItemID.ToString());
            fc.Add("Include", null);
            fc.Add("IsRiver", "on");
            fc.Add("IsContinuous", "on");
            fc.Add("Lat", "45");
            fc.Add("Lng", "-66");

            return fc;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mikeScenarioService = new MikeScenarioService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvFileService = new TVFileService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mikeSourceStartEndService = new MikeSourceStartEndService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mikeSourceService = new MikeSourceService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            appTaskService = new AppTaskService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mikeScenarioModelNew = new MikeScenarioModel();
            mikeScenario = new MikeScenario();
        }
        private void SetupShim()
        {
            shimMikeScenarioService = new ShimMikeScenarioService(mikeScenarioService);
            shimTVItemService = new ShimTVItemService(mikeScenarioService._TVItemService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(mikeScenarioService._TVItemService._TVItemLanguageService);
            shimAppTaskService = new ShimAppTaskService(mikeScenarioService._AppTaskService);
            shimMapInfoPointService = new ShimMapInfoPointService(mikeScenarioService._MapInfoService._MapInfoPointService);
            shimMikeBoundaryConditionService = new ShimMikeBoundaryConditionService(mikeScenarioService._MikeBoundaryConditionService);
            shimMapInfoService = new ShimMapInfoService(mikeScenarioService._MapInfoService);
            shimMikeSourceService = new ShimMikeSourceService(mikeScenarioService._MikeSourceService);
            shimMikeSourceStartEndService = new ShimMikeSourceStartEndService(mikeScenarioService._MikeSourceService._MikeSourceStartEndService);
            shimTVFileService = new ShimTVFileService(mikeScenarioService._TVFileService);
        }
        private TVItemModel SetupNewMikeScenarioWithFiles()
        {
            TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);

            Assert.AreEqual("", tvItemModelMunicipality.Error);

            TVItemModel tvItemModelMikeScenario = mikeScenarioService._TVItemService.PostAddChildContactTVItemDB(tvItemModelMunicipality.TVItemID, "Testing Mike Scenario", TVTypeEnum.MikeScenario);

            Assert.AreEqual("", tvItemModelMikeScenario.Error);

            FillMikeScenarioModel(mikeScenarioModelNew);
            mikeScenarioModelNew.MikeScenarioTVItemID = tvItemModelMikeScenario.TVItemID;

            MikeScenarioModel mikeScenarioModelRet = mikeScenarioService.PostAddMikeScenarioDB(mikeScenarioModelNew);

            Assert.AreEqual("", mikeScenarioModelRet.Error);

            SetupNewMikeSource(mikeScenarioModelRet);
            SetupNewMikeBoundaryCondition(mikeScenarioModelRet);
            SetupNewTVFile(mikeScenarioModelRet);

            return tvItemModelMikeScenario;
        }
        private void SetupNewTVFile(MikeScenarioModel mikeScenarioModelRet)
        {
            string SourcePath = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(@"c:\", @"C:\");
            SourcePath = SourcePath.Replace(@"bin\Debug\CSSPWebToolsDBDLL.Tests.dll", @"Blacks Harbour\");

            DirectoryInfo diSource = new DirectoryInfo(SourcePath);

            Assert.IsTrue(diSource.Exists);

            string DestPath = mikeScenarioService._TVFileService.GetServerFilePath(mikeScenarioModelRet.MikeScenarioTVItemID);

            DirectoryInfo diDest = new DirectoryInfo(DestPath);

            if (!diDest.Exists)
            {
                diDest.Create();
            }

            diDest = new DirectoryInfo(DestPath);

            Assert.IsTrue(diDest.Exists);

            //DirectoryCopy(diSource.FullName, diDest.FullName, true);

            List<string> FileList = new List<string>()
            {
                SourcePath + @"Model\Model Inputs\Blacks Harbour.m21fm",
                SourcePath + @"Model\Model Inputs\Blacks Harbour.mdf",
                SourcePath + @"Model\Model Inputs\Blacks Harbour.mesh",
                SourcePath + @"Model\Model Inputs\Blacks Harbour.log",
                SourcePath + @"External Data\Blacks Harbour Currents North East.dfs1",
                SourcePath + @"External Data\Blacks Harbour Currents South West.dfs1",
                SourcePath + @"External Data\Blacks Harbour Water Levels South.dfs1",
                SourcePath + @"Result\Blacks Harbour.m21fm - Result Files\Hydro.dfsu",
                SourcePath + @"Result\Blacks Harbour.m21fm - Result Files\Trans.dfsu",
            };

            foreach (string fileName in FileList)
            {
                FileInfo fi = new FileInfo(fileName);

                Assert.IsTrue(fi.Exists);

                string Destination = fi.FullName.Replace(SourcePath, DestPath);

                DirectoryInfo di = new DirectoryInfo(Destination.Replace(fi.Name, ""));

                if (!di.Exists)
                {
                    di.Create();
                }

                di = new DirectoryInfo(Destination.Replace(fi.Name, ""));

                Assert.IsTrue(di.Exists);

                try
                {
                    fi.CopyTo(Destination);
                }
                catch (Exception ex)
                {
                    Assert.AreEqual("", ex.Message);
                }

                FilePurposeEnum filePurpose = FilePurposeEnum.Error;
                switch (fi.Extension.ToUpper())
                {
                    case ".DFSU":
                        {
                            filePurpose = FilePurposeEnum.MikeResultDFSU;
                        }
                        break;
                    case ".DFS1":
                    case ".DFS0":
                    case ".M21FM":
                    case ".M3FM":
                    case ".MESH":
                    case ".LOG":
                        {
                            filePurpose = FilePurposeEnum.MikeInput;
                        }
                        break;
                    case ".MDF":
                        {
                            filePurpose = FilePurposeEnum.MikeInputMDF;
                        }
                        break;
                    default:
                        break;
                }

                string ServerFilePath = fi.FullName.Substring(0, fi.FullName.LastIndexOf(@"\")) + @"\";

                TVItemModel tvItemModelTVFile = mikeScenarioService._TVItemService.PostAddChildTVItemDB(mikeScenarioModelRet.MikeScenarioTVItemID, fi.Name, TVTypeEnum.File);

                Assert.AreEqual("", tvItemModelTVFile.Error);

                TVFileModel tvFileModelNew = new TVFileModel()
                {
                    ClientFilePath = "",
                    FileCreatedDate_UTC = fi.CreationTimeUtc,
                    FileDescription = "file description",
                    FileInfo = "nothing for now",
                    FilePurpose = filePurpose,
                    Language = mikeScenarioService.LanguageRequest,
                    FileSize_kb = (int)fi.Length,
                    FileType = mikeScenarioService._TVFileService.GetFileType(fi.Extension.ToUpper()),
                    ServerFileName = fi.Name,
                    ServerFilePath = ServerFilePath.Replace(@"C:\", @"E:\"),
                    TVFileTVItemID = tvItemModelTVFile.TVItemID,
                    TVFileTVText = fi.Name,
                };

                TVFileModel tvFileModelRet = mikeScenarioService._TVFileService.PostAddTVFileDB(tvFileModelNew);

                Assert.AreEqual("", tvFileModelRet.Error);

                List<Coord> coordList = new List<Coord>()
                {
                    new Coord() { Lat = randomService.RandomFloat(45, 50), Lng = randomService.RandomFloat(-123, -66), Ordinal = 0 },
                };

                MapInfoModel mapInfoModelRet = mikeScenarioService._MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.File, tvItemModelTVFile.TVItemID);

                Assert.AreEqual("", mapInfoModelRet.Error);
            }
        }
        private void SetupNewMikeBoundaryCondition(MikeScenarioModel mikeScenarioModelRet)
        {
            for (int j = 1; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    // Doing Mike Boundary Condition Mesh

                    TVItemModel tvItemModelMikeBoundaryConditionMesh = mikeScenarioService._TVItemService.PostAddChildTVItemDB(mikeScenarioModelRet.MikeScenarioTVItemID, "MBC Mesh " + j.ToString() + " " + i.ToString(), TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", tvItemModelMikeBoundaryConditionMesh.Error);

                    MikeBoundaryConditionModel mikeBoundaryConditionModelMeshNew = new MikeBoundaryConditionModel()
                    {
                        MikeBoundaryConditionCode = "mbc code",
                        MikeBoundaryConditionFormat = "mbc format",
                        MikeBoundaryConditionLength_m = 12,
                        MikeBoundaryConditionName = "mbc name " + i.ToString(),
                        MikeBoundaryConditionLevelOrVelocity = MikeBoundaryConditionLevelOrVelocityEnum.Level,
                        NumberOfWebTideNodes = 5,
                        WebTideDataSet = WebTideDataSetEnum.nwatl,
                        MikeBoundaryConditionTVItemID = tvItemModelMikeBoundaryConditionMesh.TVItemID,
                        MikeBoundaryConditionTVText = tvItemModelMikeBoundaryConditionMesh.TVText,
                    };

                    MikeBoundaryConditionModel mikeBoundaryConditionModelMesh = mikeScenarioService._MikeBoundaryConditionService.PostAddMikeBoundaryConditionDB(mikeBoundaryConditionModelMeshNew);
                    Assert.AreEqual("", mikeBoundaryConditionModelMesh.Error);

                    Coord centerCoord = new Coord() { Lat = randomService.RandomFloat(45, 50), Lng = randomService.RandomFloat(-123, -66), Ordinal = 0 };
                    float SizeFactor = 0.0001f;
                    List<Coord> Polyline = new List<Coord>()
                    {
                        new Coord() { Lat = centerCoord.Lat + SizeFactor, Lng = centerCoord.Lng + SizeFactor, Ordinal = 0 },
                        new Coord() { Lat = centerCoord.Lat + SizeFactor*2, Lng = centerCoord.Lng + SizeFactor*2, Ordinal = 1 },
                        new Coord() { Lat = centerCoord.Lat + SizeFactor*3, Lng = centerCoord.Lng + SizeFactor*3, Ordinal = 2 },
                        new Coord() { Lat = centerCoord.Lat + SizeFactor*4, Lng = centerCoord.Lng + SizeFactor*4, Ordinal = 3 },
                    };

                    MapInfoModel mapInfoModelRet = mikeScenarioService._MapInfoService.CreateMapInfoObjectDB(Polyline, MapInfoDrawTypeEnum.Polyline, TVTypeEnum.MikeBoundaryConditionMesh, tvItemModelMikeBoundaryConditionMesh.TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                }
            }
        }
        private void SetupNewMikeSource(MikeScenarioModel mikeScenarioModelRet)
        {
            for (int i = 0; i < 3; i++)
            {
                TVItemModel tvItemModelMikeSource = mikeScenarioService._TVItemService.PostAddChildTVItemDB(mikeScenarioModelRet.MikeScenarioTVItemID, "Mike Source " + i.ToString(), TVTypeEnum.MikeSource);

                Assert.AreEqual("", tvItemModelMikeSource.Error);

                MikeSourceModel mikeSourceModelNew = new MikeSourceModel()
                {
                    Include = true,
                    IsContinuous = true,
                    IsRiver = false,
                    MikeSourceTVItemID = tvItemModelMikeSource.TVItemID,
                    MikeSourceTVText = tvItemModelMikeSource.TVText,
                    SourceNumberString = "source" + i.ToString(),
                };

                MikeSourceModel mikeSourceModelRet = mikeScenarioService._MikeSourceService.PostAddMikeSourceDB(mikeSourceModelNew);

                Assert.AreEqual("", mikeSourceModelRet.Error);

                List<Coord> coordList = new List<Coord>() { new Coord() { Lat = randomService.RandomFloat(45, 50), Lng = randomService.RandomFloat(-123, -66), Ordinal = 0 } };

                MapInfoModel mapInfoModelRet = mikeScenarioService._MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.MikeSource, mikeSourceModelRet.MikeSourceTVItemID);

                Assert.AreEqual("", mapInfoModelRet.Error);

                SetupMikeSourceStartEnd(mikeSourceModelRet);
            }
        }
        private void SetupMikeSourceStartEnd(MikeSourceModel mikeSourceModelRet)
        {
            for (int j = 0; j < 3; j++)
            {
                MikeSourceStartEndModel mikeSourceStartEndModelNew = new MikeSourceStartEndModel()
                {
                    MikeSourceID = mikeSourceModelRet.MikeSourceID,
                    SourceFlowStart_m3_day = 10f,
                    SourceFlowEnd_m3_day = 10f,
                    SourcePollutionStart_MPN_100ml = 1000000,
                    SourcePollutionEnd_MPN_100ml = 1000000,
                    SourceSalinityStart_PSU = 32f,
                    SourceSalinityEnd_PSU = 32f,
                    SourceTemperatureStart_C = 15f,
                    SourceTemperatureEnd_C = 15f,
                    StartDateAndTime_Local = DateTime.UtcNow.AddDays(j),
                    EndDateAndTime_Local = DateTime.UtcNow.AddDays(j).AddHours(5),
                };

                MikeSourceStartEndModel mikeSourceStartEndModelRet = mikeScenarioService._MikeSourceService._MikeSourceStartEndService.PostAddMikeSourceStartEndDB(mikeSourceStartEndModelNew);

                Assert.AreEqual("", mikeSourceStartEndModelRet.Error);
            }

        }
        private void DestroyNewMikeScenarioWithFiles(int MikeScenarioTVItemID)
        {
            Assert.IsTrue(MikeScenarioTVItemID > 0);

            List<TVFileModel> tvFileModelList = mikeScenarioService._TVFileService.GetTVFileModelListWithParentTVItemIDDB(MikeScenarioTVItemID);

            string DestPath = mikeScenarioService._TVFileService.GetServerFilePath(MikeScenarioTVItemID);

            DirectoryInfo diDest = new DirectoryInfo(DestPath);

            if (diDest.Exists)
            {
                diDest.Delete(true);
            }
        }
        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        #endregion Functions
    }


}


