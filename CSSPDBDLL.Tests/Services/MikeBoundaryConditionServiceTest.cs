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
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MikeBoundaryConditionServiceTest
    /// </summary>
    [TestClass]
    public class MikeBoundaryConditionServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MikeBoundaryCondition";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MikeBoundaryConditionService mikeBoundaryConditionService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MikeBoundaryConditionModel mikeBoundaryConditionModelNew { get; set; }
        private MikeBoundaryCondition mikeBoundaryCondition { get; set; }
        private ShimMikeBoundaryConditionService shimMikeBoundaryConditionService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
        private ShimMapInfoService shimMapInfoService { get; set; }
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
        public MikeBoundaryConditionServiceTest()
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
        public void MikeBoundaryConditionService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange
                Assert.IsNotNull(mikeBoundaryConditionService);
                Assert.IsNotNull(mikeBoundaryConditionService.db);
                Assert.IsNotNull(mikeBoundaryConditionService.LanguageRequest);
                Assert.IsNotNull(mikeBoundaryConditionService.User);
                Assert.AreEqual(user.Identity.Name, mikeBoundaryConditionService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mikeBoundaryConditionService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_MikeBoundaryConditionModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelMikeBoundaryCondition = randomService.RandomTVItem(TVTypeEnum.MikeBoundaryConditionMesh);

                #region Good
                mikeBoundaryConditionModelNew.MikeBoundaryConditionTVItemID = tvItemModelMikeBoundaryCondition.TVItemID;
                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);

                string retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);
                #endregion Good

                #region MikeBoundaryConditionTVItemID
                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionTVItemID = 0;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeBoundaryConditionTVItemID), retStr);

                mikeBoundaryConditionModelNew.MikeBoundaryConditionTVItemID = tvItemModelMikeBoundaryCondition.TVItemID;
                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionTVItemID = 1;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);
                #endregion MikeBoundaryConditionTVItemID

                #region MikeBoundaryConditionTVText
                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                int Min = 1;
                int Max = 200;

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionTVText = randomService.RandomString("", Min - 1);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.MikeBoundaryConditionTVText, Min), retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionTVText = randomService.RandomString("", Max + 1);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.MikeBoundaryConditionTVText, Max), retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionTVText = randomService.RandomString("", Max - 1);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionTVText = randomService.RandomString("", Min);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionTVText = randomService.RandomString("", Max);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);
                #endregion MikeBoundaryConditionTVText

                #region BoundaryConditionCode
                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                Min = 3;
                Max = 100;

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionCode = randomService.RandomString("", Min - 1);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.MikeBoundaryConditionCode, Min), retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionCode = randomService.RandomString("", Max + 1);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.MikeBoundaryConditionCode, Max), retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionCode = randomService.RandomString("", Max - 1);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionCode = randomService.RandomString("", Min);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionCode = randomService.RandomString("", Max);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);
                #endregion BoundaryConditionCode

                #region BoundaryConditionName
                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                Min = 1;
                Max = 100;

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionName = randomService.RandomString("", Min - 1);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.MikeBoundaryConditionName, Min), retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionName = randomService.RandomString("", Max + 1);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.MikeBoundaryConditionName, Max), retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionName = randomService.RandomString("", Max - 1);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionName = randomService.RandomString("", Min);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionName = randomService.RandomString("", Max);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);
                #endregion BoundaryConditionName

                #region BoundaryConditionLength_m
                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                double MinDbl = 0;
                double MaxDbl = 500000;
                mikeBoundaryConditionModelNew.MikeBoundaryConditionLength_m = MinDbl - 1;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MikeBoundaryConditionLength_m, MinDbl, MaxDbl), retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionLength_m = MaxDbl + 1;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MikeBoundaryConditionLength_m, MinDbl, MaxDbl), retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionLength_m = MaxDbl - 1;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionLength_m = MaxDbl;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionLength_m = MinDbl;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);


                #endregion BoundaryConditionLength_m

                #region BoundaryConditionFormat
                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                Min = 3;
                Max = 100;

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionFormat = randomService.RandomString("", Min - 1);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.MikeBoundaryConditionFormat, Min), retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionFormat = randomService.RandomString("", Max + 1);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.MikeBoundaryConditionFormat, Max), retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionFormat = randomService.RandomString("", Max - 1);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionFormat = randomService.RandomString("", Min);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionFormat = randomService.RandomString("", Max);

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);
                #endregion BoundaryConditionFormat

                #region BoundaryConditionLevelOrVelocity
                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionLevelOrVelocity = MikeBoundaryConditionLevelOrVelocityEnum.Level;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)10000;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeBoundaryConditionLevelOrVelocity), retStr);
                #endregion BoundaryConditionType

                #region WebTideDataSet
                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.WebTideDataSet = WebTideDataSetEnum.flood;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.WebTideDataSet = (WebTideDataSetEnum)10000;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.WebTideDataSet), retStr);
                #endregion WebTideModel

                #region NumberOfWebTideNodes
                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                Min = 0;
                Max = 10000;
                mikeBoundaryConditionModelNew.NumberOfWebTideNodes = Min - 1;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.NumberOfWebTideNodes, Min, Max), retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.NumberOfWebTideNodes = Max + 1;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.NumberOfWebTideNodes, Min, Max), retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.NumberOfWebTideNodes = Max - 1;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.NumberOfWebTideNodes = Max;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);

                FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);
                mikeBoundaryConditionModelNew.NumberOfWebTideNodes = Min;

                retStr = mikeBoundaryConditionService.MikeBoundaryConditionModelOK(mikeBoundaryConditionModelNew);
                Assert.AreEqual("", retStr);


                #endregion NumberOfWebTideNodes

            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_FillMikeBoundaryCondition_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeBoundaryCondition = randomService.RandomTVItem(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", tvItemModelMikeBoundaryCondition.Error);

                    mikeBoundaryConditionModelNew.MikeBoundaryConditionTVItemID = tvItemModelMikeBoundaryCondition.TVItemID;

                    FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);

                    ContactOK contactOK = mikeBoundaryConditionService.IsContactOK();

                    string retStr = mikeBoundaryConditionService.FillMikeBoundaryCondition(mikeBoundaryCondition, mikeBoundaryConditionModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mikeBoundaryCondition.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mikeBoundaryConditionService.FillMikeBoundaryCondition(mikeBoundaryCondition, mikeBoundaryConditionModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, mikeBoundaryCondition.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_GetMikeBoundaryConditionCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    int mikeBoundaryConditionCount = mikeBoundaryConditionService.GetMikeBoundaryConditionCountDB();
                    Assert.AreEqual(testDBService.Count + 1, mikeBoundaryConditionCount);

                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = mikeBoundaryConditionService.PostDeleteMikeBoundaryConditionDB(mikeBoundaryConditionModelRet.MikeBoundaryConditionID);
                    Assert.AreEqual("", mikeBoundaryConditionModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_GetMikeBoundaryConditionModelListWithMikeScenarioTVItemIDAndTVTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", mikeBoundaryConditionModelRet.Error);

                    TVItemModel tvItemModelMikeScenarioRet = mikeBoundaryConditionService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(mikeBoundaryConditionModelRet.MikeBoundaryConditionTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenarioRet.Error);

                    // Act 
                    List<MikeBoundaryConditionModel> mikeBoundaryConditionModelList = mikeBoundaryConditionService.GetMikeBoundaryConditionModelListWithMikeScenarioTVItemIDAndTVTypeDB(tvItemModelMikeScenarioRet.TVItemID, TVTypeEnum.MikeBoundaryConditionMesh);

                    // Assert 
                    Assert.IsTrue(mikeBoundaryConditionModelList.Where(c => c.MikeBoundaryConditionID == mikeBoundaryConditionModelRet.MikeBoundaryConditionID).Any());

                    int MikeScenarioTVItemID = 0;
                    List<MikeBoundaryConditionModel> mikeBoundaryConditionModelList2 = mikeBoundaryConditionService.GetMikeBoundaryConditionModelListWithMikeScenarioTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);

                    // Assert 
                    Assert.AreEqual(0, mikeBoundaryConditionModelList2.Count);
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_GetMikeBoundaryConditionModelWithMikeBoundaryConditionIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", mikeBoundaryConditionModelRet.Error);

                    // Act 
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = mikeBoundaryConditionService.GetMikeBoundaryConditionModelWithMikeBoundaryConditionIDDB(mikeBoundaryConditionModelRet.MikeBoundaryConditionID);

                    // Assert 
                    CompareMikeBoundaryConditionModels(mikeBoundaryConditionModelRet, mikeBoundaryConditionModelRet2);

                    int MikeBoundaryConditionID = 0;
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet3 = mikeBoundaryConditionService.GetMikeBoundaryConditionModelWithMikeBoundaryConditionIDDB(MikeBoundaryConditionID);

                    // Assert 
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeBoundaryCondition, ServiceRes.MikeBoundaryConditionID, MikeBoundaryConditionID), mikeBoundaryConditionModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_GetMikeBoundaryConditionModelWithMikeBoundaryConditionTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = mikeBoundaryConditionService.GetMikeBoundaryConditionModelWithMikeBoundaryConditionTVItemIDDB(mikeBoundaryConditionModelRet.MikeBoundaryConditionTVItemID);

                    CompareMikeBoundaryConditionModels(mikeBoundaryConditionModelRet, mikeBoundaryConditionModelRet2);

                    int MikeBoundaryConditionTVItemID = 0;
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet3 = mikeBoundaryConditionService.GetMikeBoundaryConditionModelWithMikeBoundaryConditionTVItemIDDB(MikeBoundaryConditionTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeBoundaryCondition, ServiceRes.MikeBoundaryConditionTVItemID, MikeBoundaryConditionTVItemID), mikeBoundaryConditionModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_GetMikeBoundaryConditionModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", mikeBoundaryConditionModelRet.Error);

                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = mikeBoundaryConditionService.GetMikeBoundaryConditionModelExistDB(mikeBoundaryConditionModelRet);

                    CompareMikeBoundaryConditionModels(mikeBoundaryConditionModelRet, mikeBoundaryConditionModelRet2);

                    mikeBoundaryConditionModelRet2.MikeBoundaryConditionTVItemID = 0;
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet3 = mikeBoundaryConditionService.GetMikeBoundaryConditionModelExistDB(mikeBoundaryConditionModelRet2);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeBoundaryCondition,
ServiceRes.MikeBoundaryConditionTVItemID + "," +
ServiceRes.MikeBoundaryConditionCode + "," +
ServiceRes.MikeBoundaryConditionFormat + "," +
ServiceRes.MikeBoundaryConditionName + "," +
ServiceRes.MikeBoundaryConditionLevelOrVelocity,
mikeBoundaryConditionModelRet2.MikeBoundaryConditionTVItemID + "," +
mikeBoundaryConditionModelRet2.MikeBoundaryConditionCode + "," +
mikeBoundaryConditionModelRet2.MikeBoundaryConditionFormat + "," +
mikeBoundaryConditionModelRet2.MikeBoundaryConditionName + "," +
mikeBoundaryConditionModelRet2.MikeBoundaryConditionLevelOrVelocity), mikeBoundaryConditionModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_GetMikeBoundaryConditionWithMikeBoundaryConditionIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    MikeBoundaryCondition mikeBoundaryConditionRet = mikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionIDDB(mikeBoundaryConditionModelRet.MikeBoundaryConditionID);
                    Assert.AreEqual(mikeBoundaryConditionModelRet.MikeBoundaryConditionID, mikeBoundaryConditionRet.MikeBoundaryConditionID);

                    int MikeBoundaryConditionID = 0;
                    MikeBoundaryCondition mikeBoundaryConditionRet2 = mikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionIDDB(MikeBoundaryConditionID);
                    Assert.IsNull(mikeBoundaryConditionRet2);
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    string retStr = mikeBoundaryConditionService.CreateTVText(mikeBoundaryConditionModelRet);
                    Assert.AreEqual(mikeBoundaryConditionModelRet.MikeBoundaryConditionTVText, retStr);

                    mikeBoundaryConditionModelRet.MikeBoundaryConditionTVText = "";
                    retStr = mikeBoundaryConditionService.CreateTVText(mikeBoundaryConditionModelRet);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_GetIsItSameObject_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    TVItemModel tvItemModelMikeBoundaryCondition = mikeBoundaryConditionService._TVItemService.GetTVItemModelWithTVItemIDDB(mikeBoundaryConditionModelRet.MikeBoundaryConditionTVItemID);
                    Assert.AreEqual("", tvItemModelMikeBoundaryCondition.Error);

                    bool retBool = mikeBoundaryConditionService.GetIsItSameObject(mikeBoundaryConditionModelRet, tvItemModelMikeBoundaryCondition);
                    Assert.IsTrue(retBool);
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = mikeBoundaryConditionService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostAddUpdateDeleteMikeBoundaryConditionDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = UpdateMikeBoundaryConditionModel(mikeBoundaryConditionModelRet);

                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet3 = mikeBoundaryConditionService.PostDeleteMikeBoundaryConditionDB(mikeBoundaryConditionModelRet2.MikeBoundaryConditionID);
                    Assert.AreEqual("", mikeBoundaryConditionModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostAddMikeBoundaryConditionDB_MikeBoundaryConditionModelOK_Test()
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
                        shimMikeBoundaryConditionService.MikeBoundaryConditionModelOKMikeBoundaryConditionModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostAddMikeBoundaryConditionDB_IsContactOK_Error_Test()
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
                        shimMikeBoundaryConditionService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostAddMikeBoundaryConditionDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", mikeBoundaryConditionModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = mikeBoundaryConditionService.PostAddMikeBoundaryConditionDB(mikeBoundaryConditionModelRet);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostAddMikeBoundaryConditionDB_FillMikeBoundaryConditionModel_ErrorTest()
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
                        shimMikeBoundaryConditionService.FillMikeBoundaryConditionMikeBoundaryConditionMikeBoundaryConditionModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostAddMikeBoundaryConditionDB_DoAddChanges_ErrorTest()
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
                        shimMikeBoundaryConditionService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostAddMikeBoundaryConditionDB_Add_Error_Test()
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
                        shimMikeBoundaryConditionService.FillMikeBoundaryConditionMikeBoundaryConditionMikeBoundaryConditionModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);
                        Assert.IsTrue(mikeBoundaryConditionModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostDeleteMikeBoundaryConditionDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeBoundaryConditionService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = mikeBoundaryConditionService.PostDeleteMikeBoundaryConditionDB(mikeBoundaryConditionModelRet.MikeBoundaryConditionID);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostDeleteMikeBoundaryConditionDB_GetMikeBoundaryConditionWithMikeBoundaryConditionIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = mikeBoundaryConditionService.PostDeleteMikeBoundaryConditionDB(mikeBoundaryConditionModelRet.MikeBoundaryConditionID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MikeBoundaryCondition), mikeBoundaryConditionModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostDeleteMikeBoundaryConditionDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeBoundaryConditionService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = mikeBoundaryConditionService.PostDeleteMikeBoundaryConditionDB(mikeBoundaryConditionModelRet.MikeBoundaryConditionID);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostDeleteMikeBoundaryConditionDB_PostDeleteMapInfoWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoService.PostDeleteMapInfoWithTVItemIDDBInt32 = (a) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = mikeBoundaryConditionService.PostDeleteMikeBoundaryConditionDB(mikeBoundaryConditionModelRet.MikeBoundaryConditionID);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostDeleteMikeBoundaryConditionDB_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = mikeBoundaryConditionService.PostDeleteMikeBoundaryConditionDB(mikeBoundaryConditionModelRet.MikeBoundaryConditionID);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostUpdateMikeBoundaryConditionDB_MikeBoundaryConditionModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeBoundaryConditionService.MikeBoundaryConditionModelOKMikeBoundaryConditionModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = UpdateMikeBoundaryConditionModel(mikeBoundaryConditionModelRet);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostUpdateMikeBoundaryConditionDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeBoundaryConditionService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = UpdateMikeBoundaryConditionModel(mikeBoundaryConditionModelRet);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostUpdateMikeBoundaryConditionDB_GetMikeBoundaryConditionWithMikeBoundaryConditionIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMikeBoundaryConditionService.GetMikeBoundaryConditionWithMikeBoundaryConditionIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = UpdateMikeBoundaryConditionModel(mikeBoundaryConditionModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MikeBoundaryCondition), mikeBoundaryConditionModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostUpdateMikeBoundaryConditionDB_FillMikeBoundaryConditionModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeBoundaryConditionService.FillMikeBoundaryConditionMikeBoundaryConditionMikeBoundaryConditionModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = UpdateMikeBoundaryConditionModel(mikeBoundaryConditionModelRet);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostUpdateMikeBoundaryConditionDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeBoundaryConditionService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = UpdateMikeBoundaryConditionModel(mikeBoundaryConditionModelRet);
                        Assert.AreEqual(ErrorText, mikeBoundaryConditionModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostAddMikeBoundaryConditionDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SetupTest(contactModelListBad[0], culture);

                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mikeBoundaryConditionModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeBoundaryConditionService_PostAddMikeBoundaryConditionDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = AddMikeBoundaryConditionModel(TVTypeEnum.MikeBoundaryConditionMesh);

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mikeBoundaryConditionModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions
        public MikeBoundaryConditionModel AddMikeBoundaryConditionModel(TVTypeEnum TVType)
        {
            TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);

            Assert.AreEqual("", tvItemModelMikeScenario.Error);

            TVItemModel tvItemModelMikeBoundaryCondition = mikeBoundaryConditionService._TVItemService.PostAddChildTVItemDB(tvItemModelMikeScenario.TVItemID, randomService.RandomString("MBC ", 20), TVTypeEnum.MikeBoundaryConditionMesh);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeBoundaryCondition.Error))
            {
                return new MikeBoundaryConditionModel() { Error = tvItemModelMikeBoundaryCondition.Error };
            }

            mikeBoundaryConditionModelNew.MikeBoundaryConditionTVItemID = tvItemModelMikeBoundaryCondition.TVItemID;

            FillMikeBoundaryConditionModel(mikeBoundaryConditionModelNew);

            MikeBoundaryConditionModel mikeBoundaryConditionModelRet = mikeBoundaryConditionService.PostAddMikeBoundaryConditionDB(mikeBoundaryConditionModelNew);
            if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionModelRet.Error))
            {
                return mikeBoundaryConditionModelRet;
            }

            mikeBoundaryConditionModelNew.MikeBoundaryConditionTVItemID = mikeBoundaryConditionModelRet.MikeBoundaryConditionTVItemID;

            CompareMikeBoundaryConditionModels(mikeBoundaryConditionModelNew, mikeBoundaryConditionModelRet);

            return mikeBoundaryConditionModelRet;

        }
        public MikeBoundaryConditionModel UpdateMikeBoundaryConditionModel(MikeBoundaryConditionModel mikeBoundaryConditionModel)
        {
            FillMikeBoundaryConditionModel(mikeBoundaryConditionModel);

            MikeBoundaryConditionModel mikeBoundaryConditionModelRet2 = mikeBoundaryConditionService.PostUpdateMikeBoundaryConditionDB(mikeBoundaryConditionModel);
            if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionModelRet2.Error))
            {
                return mikeBoundaryConditionModelRet2;
            }

            CompareMikeBoundaryConditionModels(mikeBoundaryConditionModel, mikeBoundaryConditionModelRet2);

            return mikeBoundaryConditionModelRet2;
        }
        private void CompareMikeBoundaryConditionModels(MikeBoundaryConditionModel mikeBoundaryConditionModelNew, MikeBoundaryConditionModel mikeBoundaryConditionModelRet)
        {
            Assert.AreEqual(mikeBoundaryConditionModelNew.MikeBoundaryConditionTVItemID, mikeBoundaryConditionModelRet.MikeBoundaryConditionTVItemID);
            Assert.AreEqual(mikeBoundaryConditionModelNew.MikeBoundaryConditionCode, mikeBoundaryConditionModelRet.MikeBoundaryConditionCode);
            Assert.AreEqual(mikeBoundaryConditionModelNew.MikeBoundaryConditionFormat, mikeBoundaryConditionModelRet.MikeBoundaryConditionFormat);
            Assert.AreEqual(mikeBoundaryConditionModelNew.MikeBoundaryConditionLength_m, mikeBoundaryConditionModelRet.MikeBoundaryConditionLength_m);
            Assert.AreEqual(mikeBoundaryConditionModelNew.MikeBoundaryConditionName, mikeBoundaryConditionModelRet.MikeBoundaryConditionName);
            Assert.AreEqual(mikeBoundaryConditionModelNew.MikeBoundaryConditionLevelOrVelocity, mikeBoundaryConditionModelRet.MikeBoundaryConditionLevelOrVelocity);
            Assert.AreEqual(mikeBoundaryConditionModelNew.NumberOfWebTideNodes, mikeBoundaryConditionModelRet.NumberOfWebTideNodes);
            Assert.AreEqual(mikeBoundaryConditionModelNew.WebTideDataSet, mikeBoundaryConditionModelRet.WebTideDataSet);
        }
        public void FillMikeBoundaryConditionModel(MikeBoundaryConditionModel mikeBoundaryConditionModel)
        {
            mikeBoundaryConditionModel.MikeBoundaryConditionTVItemID = mikeBoundaryConditionModel.MikeBoundaryConditionTVItemID;
            mikeBoundaryConditionModel.MikeBoundaryConditionTVText = randomService.RandomString("BC TVText", 12);
            mikeBoundaryConditionModel.MikeBoundaryConditionCode = randomService.RandomString("BC Code2", 12);
            mikeBoundaryConditionModel.MikeBoundaryConditionFormat = randomService.RandomString("BC Format2", 12);
            mikeBoundaryConditionModel.MikeBoundaryConditionLength_m = randomService.RandomInt(10, 10000);
            mikeBoundaryConditionModel.MikeBoundaryConditionName = randomService.RandomString("BC Name2", 12);
            mikeBoundaryConditionModel.MikeBoundaryConditionLevelOrVelocity = MikeBoundaryConditionLevelOrVelocityEnum.Level;
            mikeBoundaryConditionModel.NumberOfWebTideNodes = randomService.RandomInt(10, 10000);
            mikeBoundaryConditionModel.WebTideDataSet = WebTideDataSetEnum.flood;

            Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionTVItemID != 0);
            Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionTVText.Length == 12);
            Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionCode.Length == 12);
            Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionFormat.Length == 12);
            Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionLength_m >= 10 && mikeBoundaryConditionModel.MikeBoundaryConditionLength_m <= 10000);
            Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionName.Length == 12);
            Assert.IsTrue(mikeBoundaryConditionModel.MikeBoundaryConditionLevelOrVelocity == MikeBoundaryConditionLevelOrVelocityEnum.Level);
            Assert.IsTrue(mikeBoundaryConditionModel.NumberOfWebTideNodes >= 10 && mikeBoundaryConditionModel.NumberOfWebTideNodes <= 10000);
            Assert.IsTrue(mikeBoundaryConditionModel.WebTideDataSet == WebTideDataSetEnum.flood);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mikeBoundaryConditionService = new MikeBoundaryConditionService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mikeBoundaryConditionModelNew = new MikeBoundaryConditionModel();
            mikeBoundaryCondition = new MikeBoundaryCondition();
        }
        private void SetupShim()
        {
            shimMikeBoundaryConditionService = new ShimMikeBoundaryConditionService(mikeBoundaryConditionService);
            shimTVItemService = new ShimTVItemService(mikeBoundaryConditionService._TVItemService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(mikeBoundaryConditionService._TVItemService._TVItemLanguageService);
            shimMapInfoService = new ShimMapInfoService(mikeBoundaryConditionService._MapInfoService);
        }
        #endregion Functions

    }
}


