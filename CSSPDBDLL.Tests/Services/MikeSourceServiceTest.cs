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
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MikeSourceServiceTest
    /// </summary>
    [TestClass]
    public class MikeSourceServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MikeSource";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MikeSourceService mikeSourceService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MikeSourceModel mikeSourceModelNew { get; set; }
        private MikeSource mikeSource { get; set; }
        private ShimMikeSourceService shimMikeSourceService { get; set; }
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
        public MikeSourceServiceTest()
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
        public void MikeSourceService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(mikeSourceService);
                Assert.IsNotNull(mikeSourceService.db);
                Assert.IsNotNull(mikeSourceService.LanguageRequest);
                Assert.IsNotNull(mikeSourceService.User);
                Assert.AreEqual(user.Identity.Name, mikeSourceService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mikeSourceService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MikeSourceService_MikeSourceModelOK_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceModel mikeSourceModel = AddMikeSourceModel();
                    Assert.AreEqual("", mikeSourceModel.Error);

                    #region Good
                    mikeSourceModelNew.MikeSourceTVItemID = mikeSourceModel.MikeSourceTVItemID;
                    FillMikeSourceModel(mikeSourceModelNew);

                    string retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region MikeSourceTVItemID
                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.MikeSourceTVItemID = 0;

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID), retStr);

                    mikeSourceModelNew.MikeSourceTVItemID = mikeSourceModel.MikeSourceTVItemID;
                    FillMikeSourceModel(mikeSourceModelNew);

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MikeSourceTVItemID

                    #region MikeSourceTVText
                    int Min = 3;
                    int Max = 200;

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.MikeSourceTVText = randomService.RandomString("", Min - 1);

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.MikeSourceTVText, Min), retStr);

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.MikeSourceTVText = randomService.RandomString("", Max + 1);

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.MikeSourceTVText, Max), retStr);

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.MikeSourceTVText = randomService.RandomString("", Min);

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.MikeSourceTVText = randomService.RandomString("", Max);

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.MikeSourceTVText = randomService.RandomString("", Max - 1);

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MikeSourceTVText

                    #region IsContinuous
                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.IsContinuous = true;

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.IsContinuous = false;

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion IsContinuous

                    #region Include
                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.Include = true;

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.Include = false;

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Include

                    #region IsRiver
                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.IsRiver = true;

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.IsRiver = false;

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion IsRiver

                    #region SourceNumberString
                    Min = 3;
                    Max = 50;

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.SourceNumberString = randomService.RandomString("", Min - 1);

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.SourceNumberString, Min), retStr);

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.SourceNumberString = randomService.RandomString("", Max + 1);

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.SourceNumberString, Max), retStr);

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.SourceNumberString = randomService.RandomString("", Min);

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.SourceNumberString = randomService.RandomString("", Max);

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);

                    FillMikeSourceModel(mikeSourceModelNew);
                    mikeSourceModelNew.SourceNumberString = randomService.RandomString("", Max - 1);

                    retStr = mikeSourceService.MikeSourceModelOK(mikeSourceModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SourceNumberString
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_CheckIfSourceNameIsUniqueDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeSource = randomService.RandomTVItem(TVTypeEnum.MikeSource);
                    Assert.AreEqual("", tvItemModelMikeSource.Error);

                    TVItemModel tvItemModelMikeScenario = mikeSourceService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    MikeSourceModel mikeSourceModelRet = mikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(tvItemModelMikeSource.TVItemID);
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    string retStr = mikeSourceService.CheckIfSourceNameIsUniqueDB(tvItemModelMikeScenario.TVItemID, mikeSourceModelRet.MikeSourceTVText);
                    Assert.AreEqual(string.Format(ServiceRes._HasToBeUnique, ServiceRes.SourceName), retStr);

                    mikeSourceModelRet.MikeSourceTVText = "notExist";
                    retStr = mikeSourceService.CheckIfSourceNameIsUniqueDB(tvItemModelMikeScenario.TVItemID, mikeSourceModelRet.MikeSourceTVText);
                    Assert.AreEqual("true", retStr);

                }
            }
        }
        [TestMethod]
        public void MikeSourceService_CheckIfSourceNameIsUniqueDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        string retStr = mikeSourceService.CheckIfSourceNameIsUniqueDB(mikeSourceModelRet.MikeSourceTVItemID, mikeSourceModelRet.MikeSourceTVText);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_CheckIfSourceNameIsUniqueDB_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMikeSourceService.CreateTVTextMikeSourceModel = (a) =>
                        {
                            return "";
                        };

                        string retStr = mikeSourceService.CheckIfSourceNameIsUniqueDB(mikeSourceModelRet.MikeSourceTVItemID, mikeSourceModelRet.MikeSourceTVText);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_CheckIfSourceNameIsUniqueDB_GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        string retStr = mikeSourceService.CheckIfSourceNameIsUniqueDB(mikeSourceModelRet.MikeSourceTVItemID, mikeSourceModelRet.MikeSourceTVText);
                        Assert.AreEqual("true", retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_FillMikeSource_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    mikeSourceModelNew.MikeSourceTVItemID = randomService.RandomTVItem(TVTypeEnum.MikeSource).TVItemID;
                    FillMikeSourceModel(mikeSourceModelNew);

                    ContactOK contactOK = mikeSourceService.IsContactOK();

                    string retStr = mikeSourceService.FillMikeSource(mikeSource, mikeSourceModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mikeSource.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mikeSourceService.FillMikeSource(mikeSource, mikeSourceModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, mikeSource.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_GetMikeSourceModelCount_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    int mikeSourceCount = mikeSourceService.GetMikeSourceModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, mikeSourceCount);

                    MikeSourceModel mikeSourceModelRet2 = mikeSourceService.PostDeleteMikeSourceDB(mikeSourceModelRet.MikeSourceID);
                    Assert.AreEqual("", mikeSourceModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_GetMikeSourceModelListWithMikeScenarioTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    TVItemModel tvItemModelMikeScenario = mikeSourceService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(mikeSourceModelRet.MikeSourceTVItemID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<MikeSourceModel> mikeSourceModelList = mikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(tvItemModelMikeScenario.TVItemID);

                    Assert.IsTrue(mikeSourceModelList.Where(c => c.MikeSourceID == mikeSourceModelRet.MikeSourceID).Any());

                    int MikeSourceID = 0;
                    MikeSourceModel mikeSourceModelRet3 = mikeSourceService.GetMikeSourceModelWithMikeSourceIDDB(MikeSourceID);

                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeSource, ServiceRes.MikeSourceID, MikeSourceID), mikeSourceModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_GetMikeSourceModelWithMikeSourceIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    MikeSourceModel mikeSourceModelRet2 = mikeSourceService.GetMikeSourceModelWithMikeSourceIDDB(mikeSourceModelRet.MikeSourceID);

                    CompareMikeSourceModels(mikeSourceModelRet, mikeSourceModelRet2);

                    int MikeSourceID = 0;
                    MikeSourceModel mikeSourceModelRet3 = mikeSourceService.GetMikeSourceModelWithMikeSourceIDDB(MikeSourceID);

                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeSource, ServiceRes.MikeSourceID, MikeSourceID), mikeSourceModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_GetMikeSourceModelWithMikeSourceTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    MikeSourceModel mikeSourceModelRet2 = mikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(mikeSourceModelRet.MikeSourceTVItemID);

                    CompareMikeSourceModels(mikeSourceModelRet, mikeSourceModelRet2);

                    int MikeSourceTVItemID = 0;
                    MikeSourceModel mikeSourceModelRet3 = mikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(MikeSourceTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeSource, ServiceRes.MikeSourceTVItemID, MikeSourceTVItemID), mikeSourceModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void MikeSourceService_GetMikeSourceWithMikeSourceIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    MikeSource mikeSourceRet = mikeSourceService.GetMikeSourceWithMikeSourceIDDB(mikeSourceModelRet.MikeSourceID);
                    Assert.AreEqual(mikeSourceModelRet.MikeSourceID, mikeSourceRet.MikeSourceID);

                    int MikeSourceID = 0;
                    MikeSource mikeSourceRet2 = mikeSourceService.GetMikeSourceWithMikeSourceIDDB(MikeSourceID);
                    Assert.IsNull(mikeSourceRet2);
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    string retStr = mikeSourceService.CreateTVText(mikeSourceModelRet);
                    Assert.AreEqual(mikeSourceModelRet.MikeSourceTVText, retStr);

                    mikeSourceModelRet.MikeSourceTVText = "";
                    retStr = mikeSourceService.CreateTVText(mikeSourceModelRet);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_GetIsItSameObject_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    TVItemModel tvItemModelMikeSource = mikeSourceService._TVItemService.GetTVItemModelWithTVItemIDDB(mikeSourceModelRet.MikeSourceTVItemID);
                    Assert.AreEqual("", tvItemModelMikeSource.Error);

                    bool retBool = mikeSourceService.GetIsItSameObject(mikeSourceModelRet, tvItemModelMikeSource);
                    Assert.IsTrue(retBool);
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MikeSourceModel mikeSourceModelRet = mikeSourceService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostAddUpdateDeleteMikeSourceDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                    MikeSourceModel mikeSourceModelRet2 = UpdateMikeSourceModel(mikeSourceModelRet);

                    MikeSourceModel mikeSourceModelRet3 = mikeSourceService.PostDeleteMikeSourceDB(mikeSourceModelRet2.MikeSourceID);
                    Assert.AreEqual("", mikeSourceModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostAddMikeSourceDB_MikeSourceModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.MikeSourceModelOKMikeSourceModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostAddMikeSourceDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostAddMikeSourceDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                    Assert.AreEqual("", mikeSourceModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet2 = mikeSourceService.PostAddMikeSourceDB(mikeSourceModelRet);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostAddMikeSourceDB_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostAddMikeSourceDB_FillMikeSourceModel_ErrorTest()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.FillMikeSourceMikeSourceMikeSourceModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostAddMikeSourceDB_DoAddChanges_ErrorTest()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                        Assert.AreEqual(ErrorText, mikeSourceModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostAddMikeSourceDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMikeSourceService.FillMikeSourceMikeSourceMikeSourceModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                        Assert.IsTrue(mikeSourceModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostDeleteMikeSourceDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet2 = mikeSourceService.PostDeleteMikeSourceDB(mikeSourceModelRet.MikeSourceID);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostDeleteMikeSourceDB_GetMikeSourceWithMikeSourceIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMikeSourceService.GetMikeSourceWithMikeSourceIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MikeSourceModel mikeSourceModelRet2 = mikeSourceService.PostDeleteMikeSourceDB(mikeSourceModelRet.MikeSourceID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MikeSource), mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostDeleteMikeSourceDB_PostDeleteMapInfoWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoService.PostDeleteMapInfoWithTVItemIDDBInt32 = (a) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet2 = mikeSourceService.PostDeleteMikeSourceDB(mikeSourceModelRet.MikeSourceID);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostDeleteMikeSourceDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MikeSourceModel mikeSourceModelRet2 = mikeSourceService.PostDeleteMikeSourceDB(mikeSourceModelRet.MikeSourceID);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostDeleteMikeSourceDB_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet2 = mikeSourceService.PostDeleteMikeSourceDB(mikeSourceModelRet.MikeSourceID);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostAddUpdateDeleteMikeSourceWithTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                    MikeSourceModel mikeSourceModelRet2 = UpdateMikeSourceModel(mikeSourceModelRet);

                    MikeSourceModel mikeSourceModelRet3 = mikeSourceService.PostDeleteMikeSourceWithTVItemIDDB(mikeSourceModelRet2.MikeSourceTVItemID);
                    Assert.AreEqual("", mikeSourceModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostDeleteMikeSourceWithTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet2 = mikeSourceService.PostDeleteMikeSourceWithTVItemIDDB(mikeSourceModelRet.MikeSourceTVItemID);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostDeleteMikeSourceWithTVItemIDDB_GetMikeSourceModelWithMikeSourceTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDBInt32 = (a) =>
                        {
                            return new MikeSourceModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet2 = mikeSourceService.PostDeleteMikeSourceWithTVItemIDDB(mikeSourceModelRet.MikeSourceTVItemID);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostDeleteMikeSourceWithTVItemIDDB_PostDeleteMikeSourceDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.PostDeleteMikeSourceDBInt32 = (a) =>
                        {
                            return new MikeSourceModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet2 = mikeSourceService.PostDeleteMikeSourceWithTVItemIDDB(mikeSourceModelRet.MikeSourceTVItemID);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostUpdateMikeSourceDB_MikeSourceModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.MikeSourceModelOKMikeSourceModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MikeSourceModel mikeSourceModelRet2 = UpdateMikeSourceModel(mikeSourceModelRet);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostUpdateMikeSourceDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet2 = UpdateMikeSourceModel(mikeSourceModelRet);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostUpdateMikeSourceDB_GetMikeSourceWithMikeSourceIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMikeSourceService.GetMikeSourceWithMikeSourceIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MikeSourceModel mikeSourceModelRet2 = UpdateMikeSourceModel(mikeSourceModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MikeSource), mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostUpdateMikeSourceDB_FillMikeSourceModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.FillMikeSourceMikeSourceMikeSourceModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MikeSourceModel mikeSourceModelRet2 = UpdateMikeSourceModel(mikeSourceModelRet);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostUpdateMikeSourceDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMikeSourceService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MikeSourceModel mikeSourceModelRet2 = UpdateMikeSourceModel(mikeSourceModelRet);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostUpdateMikeSourceDB_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet2 = UpdateMikeSourceModel(mikeSourceModelRet);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostUpdateMikeSourceDB_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMikeSourceService.CreateTVTextMikeSourceModel = (a) =>
                        {
                            return "";
                        };

                        MikeSourceModel mikeSourceModelRet2 = UpdateMikeSourceModel(mikeSourceModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostUpdateMikeSourceDB_GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB_GetIsItSameObject_false_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = "", TVItemID = mikeSourceModelRet.MikeSourceTVItemID };
                        };
                        shimMikeSourceService.GetIsItSameObjectMikeSourceModelTVItemModel = (a, b) =>
                        {
                            return false;
                        };

                        MikeSourceModel mikeSourceModelRet2 = UpdateMikeSourceModel(mikeSourceModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MikeSource), mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostUpdateMikeSourceDB_GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB_GetIsItSameObject_true_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = "", TVItemID = mikeSourceModelRet.MikeSourceTVItemID };
                        };
                        shimMikeSourceService.GetIsItSameObjectMikeSourceModelTVItemModel = (a, b) =>
                        {
                            return true;
                        };

                        MikeSourceModel mikeSourceModelRet2 = UpdateMikeSourceModel(mikeSourceModelRet);
                        Assert.AreEqual("", mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostUpdateMikeSourceDB_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        MikeSourceModel mikeSourceModelRet2 = UpdateMikeSourceModel(mikeSourceModelRet);
                        Assert.AreEqual(ErrorText, mikeSourceModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostAddMikeSourceDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    SetupTest(contactModelListBad[0], culture);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mikeSourceModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MikeSourceService_PostAddMikeSourceDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelParent = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.IsNotNull(tvItemModelParent);

                    SetupTest(contactModelListGood[2], culture);

                    MikeSourceModel mikeSourceModelRet = AddMikeSourceModel();
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mikeSourceModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions
        public MikeSourceModel AddMikeSourceModel()
        {
            TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
            Assert.AreEqual("", tvItemModelMikeScenario.Error);

            string TVText = randomService.RandomString("Mike Source ", 20);
            TVItemModel tvItemModelMikeSource = mikeSourceService._TVItemService.PostAddChildTVItemDB(tvItemModelMikeScenario.TVItemID, TVText, TVTypeEnum.MikeSource);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeSource.Error))
            {
                return new MikeSourceModel() { Error = tvItemModelMikeSource.Error };
            }

            mikeSourceModelNew.MikeSourceTVItemID = tvItemModelMikeSource.TVItemID;
            FillMikeSourceModel(mikeSourceModelNew);

            MikeSourceModel mikeSourceModelRet = mikeSourceService.PostAddMikeSourceDB(mikeSourceModelNew);
            if (!string.IsNullOrWhiteSpace(mikeSourceModelRet.Error))
            {
                return mikeSourceModelRet;
            }

            CompareMikeSourceModels(mikeSourceModelNew, mikeSourceModelRet);

            return mikeSourceModelRet;

        }
        public MikeSourceModel UpdateMikeSourceModel(MikeSourceModel mikeSourceModel)
        {
            FillMikeSourceModel(mikeSourceModel);

            MikeSourceModel mikeSourceModelRet2 = mikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
            if (!string.IsNullOrWhiteSpace(mikeSourceModelRet2.Error))
            {
                return mikeSourceModelRet2;
            }

            CompareMikeSourceModels(mikeSourceModel, mikeSourceModelRet2);

            return mikeSourceModelRet2;
        }
        private void CompareMikeSourceModels(MikeSourceModel mikeSourceModelNew, MikeSourceModel mikeSourceModelRet)
        {
            Assert.AreEqual(mikeSourceModelNew.MikeSourceTVItemID, mikeSourceModelRet.MikeSourceTVItemID);
            Assert.AreEqual(mikeSourceModelNew.Include, mikeSourceModelRet.Include);
            Assert.AreEqual(mikeSourceModelNew.IsContinuous, mikeSourceModelRet.IsContinuous);
            Assert.AreEqual(mikeSourceModelNew.IsRiver, mikeSourceModelRet.IsRiver);
            Assert.AreEqual(mikeSourceModelNew.SourceNumberString, mikeSourceModelRet.SourceNumberString);
        }
        private void FillMikeSourceModel(MikeSourceModel mikeSourceModel)
        {
            mikeSourceModel.MikeSourceTVItemID = mikeSourceModel.MikeSourceTVItemID;
            mikeSourceModel.MikeSourceTVText = randomService.RandomString("MikeSource", 20);
            mikeSourceModel.Include = false;
            mikeSourceModel.IsContinuous = false;
            mikeSourceModel.IsRiver = false;
            mikeSourceModel.SourceNumberString = randomService.RandomString("Source 1", 10);
            Assert.IsTrue(mikeSourceModel.MikeSourceTVItemID != 0);
            Assert.IsTrue(mikeSourceModel.MikeSourceTVText.Length == 20);
            Assert.IsTrue(mikeSourceModel.Include == false);
            Assert.IsTrue(mikeSourceModel.IsContinuous == false);
            Assert.IsTrue(mikeSourceModel.IsRiver == false);
            Assert.IsTrue(mikeSourceModel.SourceNumberString.Length == 10);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mikeSourceService = new MikeSourceService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mikeSourceModelNew = new MikeSourceModel();
            mikeSource = new MikeSource();
        }
        private void SetupShim()
        {
            shimMikeSourceService = new ShimMikeSourceService(mikeSourceService);
            shimTVItemService = new ShimTVItemService(mikeSourceService._TVItemService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(mikeSourceService._TVItemService._TVItemLanguageService);
            shimMapInfoService = new ShimMapInfoService(mikeSourceService._MapInfoService);
        }
        #endregion Functions

    }
}


