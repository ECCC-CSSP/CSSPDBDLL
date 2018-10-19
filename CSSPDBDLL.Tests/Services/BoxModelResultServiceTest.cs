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
using System.Threading;
using System.Globalization;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for BoxModelResultServiceTest
    /// </summary>
    [TestClass]
    public class BoxModelResultServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "BoxModelResult";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private BoxModelService boxModelService { get; set; }
        private BoxModelResultService boxModelResultService { get; set; }
        private BoxModelLanguageService boxModelLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private BoxModelModel boxModelModelNew { get; set; }
        private BoxModelResultModel boxModelResultModelNew { get; set; }
        private BoxModel boxModel { get; set; }
        private ShimBoxModelService shimBoxModelService { get; set; }
        private ShimBoxModelResultService shimBoxModelResultService { get; set; }
        private ShimBoxModelLanguageService shimBoxModelLanguageService { get; set; }
        private BoxModelServiceTest boxModelServiceTest { get; set; }
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
        public BoxModelResultServiceTest()
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
        public void BoxModelResultService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // Act for Add
                // In Arrange

                Assert.IsNotNull(boxModelResultService);
                Assert.IsNotNull(boxModelResultService.db);
                Assert.IsNotNull(boxModelResultService.LanguageRequest);
                Assert.IsNotNull(boxModelResultService.User);
                Assert.AreEqual(user.Identity.Name, boxModelResultService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), boxModelResultService.LanguageRequest);
            }
        }
        [TestMethod]
        public void BoxModelResultService_BoxModelResultModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelResultModel boxModelResultModel = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.DecayUntreated);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    Assert.IsNotNull(boxModelModelRet);
                    Assert.AreEqual("", boxModelModelRet.Error);

                    #region Good
                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);

                    string retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region BoxModelID
                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.BoxModelID = 0;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.BoxModelID), retStr);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.BoxModelID = 1;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion BoxModelID

                    #region ResultType
                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.BoxModelResultType = (BoxModelResultTypeEnum)100000;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.BoxModelResultType), retStr);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.BoxModelResultType = BoxModelResultTypeEnum.DecayUntreated;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ResultType

                    #region Volume_m3
                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.Volume_m3 = 0;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Volume_m3), retStr);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.Volume_m3 = 1;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Volume_m3

                    #region Surface_m2
                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.Surface_m2 = 0;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Surface_m2), retStr);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.Surface_m2 = 1;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Surface_m2

                    #region Radius_m
                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.Radius_m = 0;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Radius_m), retStr);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.Radius_m = 1;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Radius_m

                    #region RectLength_m
                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.RectLength_m = 0;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RectLength_m), retStr);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.RectLength_m = 1;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion RectLength_m

                    #region RectWidth_m
                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.RectWidth_m = 0;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.RectWidth_m), retStr);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);
                    boxModelResultModelNew.RectWidth_m = 1;

                    retStr = boxModelResultService.BoxModelResultModelOK(boxModelResultModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion RectWidth_m
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_FillBoxModelResult_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);

                    ContactOK contactOK = boxModelResultService.IsContactOK();

                    BoxModelResult boxModelResult = new BoxModelResult();

                    string retStr = boxModelResultService.FillBoxModelResultModel(boxModelResult, boxModelResultModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, boxModelResult.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = boxModelResultService.FillBoxModelResultModel(boxModelResult, boxModelResultModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, boxModelResult.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_GetBoxModelResultModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    int boxModelResultCount = boxModelResultService.GetBoxModelResultModelCountDB();
                    Assert.AreEqual(testDBService.Count + 5, boxModelResultCount);

                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_GetBoxModelResultModelListWithBoxModelIDOrderByResultTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModelSpecific();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    List<BoxModelResultModel> boxModelResultModelList = boxModelResultService.GetBoxModelResultModelListWithBoxModelIDOrderByResultTypeDB(boxModelModelRet.BoxModelID);
                    Assert.AreEqual(5, boxModelResultModelList.Count);

                    foreach (BoxModelResultModel bmrm in boxModelResultModelList)
                    {
                        switch ((BoxModelResultTypeEnum)bmrm.BoxModelResultType)
                        {
                            case BoxModelResultTypeEnum.Dilution:
                                {
                                    Assert.IsNotNull(bmrm);
                                    Assert.AreEqual(1234000, bmrm.Volume_m3, 1);
                                    Assert.AreEqual(411333, bmrm.Surface_m2, 1);
                                    Assert.AreEqual(512, bmrm.Radius_m, 1);
                                    Assert.AreEqual(641, bmrm.RectLength_m, 1);
                                    Assert.AreEqual(641, bmrm.RectWidth_m, 1);
                                }
                                break;
                            case BoxModelResultTypeEnum.NoDecayUntreated:
                                {
                                    Assert.IsNotNull(bmrm);
                                    Assert.AreEqual(264428571.42857143, bmrm.Volume_m3, 1);
                                    Assert.AreEqual(88142857.142857149, bmrm.Surface_m2, 1);
                                    Assert.AreEqual(7490.893514802754, bmrm.Radius_m, 1);
                                    Assert.AreEqual(9388.44274322729, bmrm.RectLength_m, 1);
                                    Assert.AreEqual(9388.44274322729, bmrm.RectWidth_m, 1);
                                }
                                break;
                            case BoxModelResultTypeEnum.NoDecayPreDisinfection:
                                {
                                    Assert.IsNotNull(bmrm);
                                    Assert.AreEqual(70514.28571428571, bmrm.Volume_m3, 1);
                                    Assert.AreEqual(23504.761904761905, bmrm.Surface_m2, 1);
                                    Assert.AreEqual(122.32577885860249, bmrm.Radius_m, 1);
                                    Assert.AreEqual(153.31262800161605, bmrm.RectLength_m, 1);
                                    Assert.AreEqual(153.31262800161605, bmrm.RectWidth_m, 1);
                                }
                                break;
                            case BoxModelResultTypeEnum.DecayUntreated:
                                {
                                    Assert.IsNotNull(bmrm);
                                    Assert.AreEqual(56476225.930367015, bmrm.Volume_m3, 1);
                                    Assert.AreEqual(18825408.643455673, bmrm.Surface_m2, 1);
                                    Assert.AreEqual(3461.8820553744245, bmrm.Radius_m, 1);
                                    Assert.AreEqual(4338.8257217196078, bmrm.RectLength_m, 1);
                                    Assert.AreEqual(4338.8257217196078, bmrm.RectWidth_m, 1);
                                }
                                break;
                            case BoxModelResultTypeEnum.DecayPreDisinfection:
                                {
                                    Assert.IsNotNull(bmrm);
                                    Assert.AreEqual(14796.840245677306, bmrm.Volume_m3, 1);
                                    Assert.AreEqual(4932.2800818924352, bmrm.Surface_m2, 1);
                                    Assert.AreEqual(56.03558711200872, bmrm.Radius_m, 1);
                                    Assert.AreEqual(70.230193520254772, bmrm.RectLength_m, 1);
                                    Assert.AreEqual(70.230193520254772, bmrm.RectWidth_m, 1);
                                }
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_GetBoxModelResultModelWithBoxModelIDAndResultTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModelSpecific();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelResultModel boxModelResultModelRet1 = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.Dilution);
                    Assert.IsNotNull(boxModelResultModelRet1);
                    Assert.AreEqual(1234000, boxModelResultModelRet1.Volume_m3, 1);
                    Assert.AreEqual(411333, boxModelResultModelRet1.Surface_m2, 1);
                    Assert.AreEqual(512, boxModelResultModelRet1.Radius_m, 1);
                    Assert.AreEqual(641, boxModelResultModelRet1.RectLength_m, 1);
                    Assert.AreEqual(641, boxModelResultModelRet1.RectWidth_m, 1);


                    BoxModelResultModel boxModelResultModelRet2 = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.NoDecayUntreated);
                    Assert.IsNotNull(boxModelResultModelRet2);
                    Assert.AreEqual(264428571.42857143, boxModelResultModelRet2.Volume_m3, 1);
                    Assert.AreEqual(88142857.142857149, boxModelResultModelRet2.Surface_m2, 1);
                    Assert.AreEqual(7490.893514802754, boxModelResultModelRet2.Radius_m, 1);
                    Assert.AreEqual(9388.44274322729, boxModelResultModelRet2.RectLength_m, 1);
                    Assert.AreEqual(9388.44274322729, boxModelResultModelRet2.RectWidth_m, 1);

                    BoxModelResultModel boxModelResultModelRet3 = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.NoDecayPreDisinfection);
                    Assert.IsNotNull(boxModelResultModelRet3);
                    Assert.AreEqual(70514.28571428571, boxModelResultModelRet3.Volume_m3, 1);
                    Assert.AreEqual(23504.761904761905, boxModelResultModelRet3.Surface_m2, 1);
                    Assert.AreEqual(122.32577885860249, boxModelResultModelRet3.Radius_m, 1);
                    Assert.AreEqual(153.31262800161605, boxModelResultModelRet3.RectLength_m, 1);
                    Assert.AreEqual(153.31262800161605, boxModelResultModelRet3.RectWidth_m, 1);


                    BoxModelResultModel boxModelResultModelRet4 = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.DecayUntreated);
                    Assert.IsNotNull(boxModelResultModelRet4);
                    Assert.AreEqual(56476225.930367015, boxModelResultModelRet4.Volume_m3, 1);
                    Assert.AreEqual(18825408.643455673, boxModelResultModelRet4.Surface_m2, 1);
                    Assert.AreEqual(3461.8820553744245, boxModelResultModelRet4.Radius_m, 1);
                    Assert.AreEqual(4338.8257217196078, boxModelResultModelRet4.RectLength_m, 1);
                    Assert.AreEqual(4338.8257217196078, boxModelResultModelRet4.RectWidth_m, 1);


                    BoxModelResultModel boxModelResultModelRet5 = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.DecayPreDisinfection);
                    Assert.IsNotNull(boxModelResultModelRet5);
                    Assert.AreEqual(14796.840245677306, boxModelResultModelRet5.Volume_m3, 1);
                    Assert.AreEqual(4932.2800818924352, boxModelResultModelRet5.Surface_m2, 1);
                    Assert.AreEqual(56.03558711200872, boxModelResultModelRet5.Radius_m, 1);
                    Assert.AreEqual(70.230193520254772, boxModelResultModelRet5.RectLength_m, 1);
                    Assert.AreEqual(70.230193520254772, boxModelResultModelRet5.RectWidth_m, 1);

                    int BoxModelID = 0;
                    BoxModelResultTypeEnum boxModelRetultType = BoxModelResultTypeEnum.DecayUntreated;
                    BoxModelResultModel boxModelResultModelRetError = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(BoxModelID, boxModelRetultType);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModelResultModel, ServiceRes.BoxModelID + "," + ServiceRes.BoxModelResultType, BoxModelID + "," + boxModelRetultType), boxModelResultModelRetError.Error);

                    BoxModelID = boxModelModelRet.BoxModelID;
                    boxModelRetultType = (BoxModelResultTypeEnum)1000;
                    boxModelResultModelRetError = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(BoxModelID, boxModelRetultType);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModelResultModel, ServiceRes.BoxModelID + "," + ServiceRes.BoxModelResultType, BoxModelID + "," + boxModelRetultType), boxModelResultModelRetError.Error);

                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_GetBoxModelResultModelWithBoxModelResultIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    List<BoxModelResultModel> boxModelResultModelList = boxModelResultService.GetBoxModelResultModelListWithBoxModelIDOrderByResultTypeDB(boxModelModelRet.BoxModelID);
                    Assert.AreEqual(5, boxModelResultModelList.Count);

                    BoxModelResultModel boxModelResultModelRet = boxModelResultService.GetBoxModelResultModelWithBoxModelResultIDDB(boxModelResultModelList[0].BoxModelResultID);
                    Assert.IsNotNull(boxModelResultModelRet);

                    int BoxModelResultID = 0;
                    BoxModelResultModel boxModelResultModelRet2 = boxModelResultService.GetBoxModelResultModelWithBoxModelResultIDDB(BoxModelResultID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModelResultModel, ServiceRes.BoxModelResultID, BoxModelResultID), boxModelResultModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_GetBoxModelResultWithBoxModelResultIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    List<BoxModelResultModel> boxModelResultModelList = boxModelResultService.GetBoxModelResultModelListWithBoxModelIDOrderByResultTypeDB(boxModelModelRet.BoxModelID);
                    Assert.AreEqual(5, boxModelResultModelList.Count);

                    BoxModelResult boxModelResultRet = boxModelResultService.GetBoxModelResultWithBoxModelResultIDDB(boxModelResultModelList[0].BoxModelResultID);
                    Assert.IsNotNull(boxModelResultRet);

                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    BoxModelResultModel boxModelResultModel = boxModelResultService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, boxModelResultModel.Error);
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostAddBoxModelResultDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelLanguageModel boxModelLanguageModelRet = boxModelLanguageService.GetBoxModelLanguageModelWithBoxModelIDAndLanguageDB(boxModelModelRet.BoxModelID, LanguageEnum.en);
                    Assert.AreEqual(LanguageEnum.en, boxModelLanguageModelRet.Language);

                    int boxModelResultCount2 = boxModelResultService.GetBoxModelResultModelCountDB();
                    Assert.AreEqual(testDBService.Count + 5, boxModelResultCount2);


                    BoxModelModel boxModelModelRet2 = boxModelServiceTest.UpdateBoxModelModel(boxModelModelRet);
                    Assert.AreEqual("", boxModelModelRet2.Error);

                    BoxModelLanguageModel boxModelLanguageModelRet2 = boxModelLanguageService.GetBoxModelLanguageModelWithBoxModelIDAndLanguageDB(boxModelModelRet2.BoxModelID, LanguageEnum.en);
                    Assert.AreEqual(LanguageEnum.en, boxModelLanguageModelRet2.Language);

                    BoxModelModel boxModelModelRet4 = boxModelService.PostDeleteBoxModelDB(boxModelModelRet2.BoxModelID);
                    Assert.AreEqual("", boxModelModelRet4.Error);

                    BoxModelModel boxModelModelRet3 = boxModelService.GetBoxModelModelWithBoxModelIDDB(boxModelModelRet2.BoxModelID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModel, ServiceRes.BoxModelID, boxModelModelRet2.BoxModelID), boxModelModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostAddBoxModelDB_BoxModelResultModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelResultService.BoxModelResultModelOKBoxModelResultModel = (a) =>
                        {
                            return ErrorText;
                        };

                        BoxModelResultModel boxModelResultModel = new BoxModelResultModel();

                        FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModel);

                        BoxModelResultModel boxModelResultModelRet = boxModelResultService.PostAddBoxModelResultDB(boxModelResultModel);
                        Assert.AreEqual(ErrorText, boxModelResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostAddBoxModelDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelResultService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelResultModel boxModelResultModel = new BoxModelResultModel();

                        FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModel);

                        BoxModelResultModel boxModelResultModelRet = boxModelResultService.PostAddBoxModelResultDB(boxModelResultModel);
                        Assert.AreEqual(ErrorText, boxModelResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostAddBoxModelDB_FillBoxModelResultModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelResultService.FillBoxModelResultModelBoxModelResultBoxModelResultModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        BoxModelResultModel boxModelResultModel = new BoxModelResultModel();

                        FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModel);

                        BoxModelResultModel boxModelResultModelRet = boxModelResultService.PostAddBoxModelResultDB(boxModelResultModel);
                        Assert.AreEqual(ErrorText, boxModelResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostAddBoxModelDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelResultService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        BoxModelResultModel boxModelResultModel = new BoxModelResultModel();

                        FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModel);

                        BoxModelResultModel boxModelResultModelRet = boxModelResultService.PostAddBoxModelResultDB(boxModelResultModel);
                        Assert.AreEqual(ErrorText, boxModelResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostAddBoxModelDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelResultService.FillBoxModelResultModelBoxModelResultBoxModelResultModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        BoxModelResultModel boxModelResultModel = new BoxModelResultModel();

                        FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModel);

                        BoxModelResultModel boxModelResultModelRet = boxModelResultService.PostAddBoxModelResultDB(boxModelResultModel);
                        Assert.IsTrue(boxModelResultModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostAddBoxModelResultDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    List<BoxModelResultModel> boxModelResultModelList = boxModelResultService.GetBoxModelResultModelListWithBoxModelIDOrderByResultTypeDB(boxModelModelRet.BoxModelID);
                    Assert.AreEqual(5, boxModelResultModelList.Count);

                    foreach (BoxModelResultModel bmrm in boxModelResultModelList)
                    {
                        BoxModelResultModel BoxModelResultModelRet = boxModelResultService.PostDeleteBoxModelResultDB(bmrm.BoxModelResultID);
                        Assert.AreEqual("", BoxModelResultModelRet.Error);
                    }

                    List<BoxModelResultModel> boxModelResultModelList2 = boxModelResultService.GetBoxModelResultModelListWithBoxModelIDOrderByResultTypeDB(boxModelModelRet.BoxModelID);
                    Assert.AreEqual(0, boxModelResultModelList2.Count);

                    ContactModel contactModelBad = contactModelListBad[0];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    BoxModelResultService boxModelResultServiceBad = new BoxModelResultService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    BoxModelResultModel boxModelResultModelNew = new BoxModelResultModel()
                    {
                        BoxModelID = boxModelModelRet.BoxModelID,
                        FixLength = false,
                        FixWidth = false,
                        Radius_m = 234,
                        RectLength_m = 453,
                        RectWidth_m = 345,
                        BoxModelResultType = BoxModelResultTypeEnum.Dilution,
                        Surface_m2 = 12342,
                        Volume_m3 = 34563,
                    };


                    BoxModelResultModel boxModelResultModelRet = boxModelResultServiceBad.PostAddBoxModelResultDB(boxModelResultModelNew);
                    Assert.IsNotNull(boxModelResultModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, boxModelResultModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostAddBoxModelResultDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    List<BoxModelResultModel> boxModelResultModelList = boxModelResultService.GetBoxModelResultModelListWithBoxModelIDOrderByResultTypeDB(boxModelModelRet.BoxModelID);
                    Assert.AreEqual(5, boxModelResultModelList.Count);

                    foreach (BoxModelResultModel bmrm in boxModelResultModelList)
                    {
                        BoxModelResultModel BoxModelResultModelRet = boxModelResultService.PostDeleteBoxModelResultDB(bmrm.BoxModelResultID);
                        Assert.AreEqual("", BoxModelResultModelRet.Error);
                    }

                    List<BoxModelResultModel> boxModelResultModelList2 = boxModelResultService.GetBoxModelResultModelListWithBoxModelIDOrderByResultTypeDB(boxModelModelRet.BoxModelID);
                    Assert.AreEqual(0, boxModelResultModelList2.Count);

                    ContactModel contactModelBad = contactModelListGood[2];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    BoxModelResultService boxModelResultServiceBad = new BoxModelResultService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    BoxModelResultModel boxModelResultModelNew = new BoxModelResultModel()
                    {
                        BoxModelID = boxModelModelRet.BoxModelID,
                        FixLength = false,
                        FixWidth = false,
                        Radius_m = 234,
                        RectLength_m = 453,
                        RectWidth_m = 345,
                        BoxModelResultType = BoxModelResultTypeEnum.Dilution,
                        Surface_m2 = 12342,
                        Volume_m3 = 34563,
                    };


                    BoxModelResultModel boxModelResultModelRet = boxModelResultServiceBad.PostAddBoxModelResultDB(boxModelResultModelNew);
                    Assert.IsNotNull(boxModelResultModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, boxModelResultModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostDeleteBoxModelDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelResultModel boxModelResultModel = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.DecayUntreated);
                    Assert.AreEqual("", boxModelResultModel.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelResultService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelResultModel boxModelResultModel2 = boxModelResultService.PostDeleteBoxModelResultDB(boxModelResultModel.BoxModelResultID);
                        Assert.AreEqual(ErrorText, boxModelResultModel2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostDeleteBoxModelDB_GetBoxModelResultWithBoxModelResultIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelResultModel boxModelResultModel = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.DecayUntreated);
                    Assert.AreEqual("", boxModelResultModel.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelResultService.GetBoxModelResultWithBoxModelResultIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        BoxModelResultModel boxModelResultModel2 = boxModelResultService.PostDeleteBoxModelResultDB(boxModelResultModel.BoxModelResultID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.BoxModelResult), boxModelResultModel2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostDeleteBoxModelDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelResultModel boxModelResultModel = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.DecayUntreated);
                    Assert.AreEqual("", boxModelResultModel.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelResultService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        BoxModelResultModel boxModelResultModel2 = boxModelResultService.PostDeleteBoxModelResultDB(boxModelResultModel.BoxModelResultID);
                        Assert.AreEqual(ErrorText, boxModelResultModel2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostUpdateBoxModelDB_BoxModelResultModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelResultModel boxModelResultModel = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.DecayUntreated);
                    Assert.AreEqual("", boxModelResultModel.Error);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);

                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        string ErrorText = "ErrorText";
                        shimBoxModelResultService.BoxModelResultModelOKBoxModelResultModel = (a) =>
                        {
                            return ErrorText;
                        };

                        BoxModelResultModel boxModelResultModelRet = boxModelResultService.PostUpdateBoxModelResultDB(boxModelResultModelNew);
                        Assert.AreEqual(ErrorText, boxModelResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostUpdateBoxModelDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelResultModel boxModelResultModel = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.DecayUntreated);
                    Assert.AreEqual("", boxModelResultModel.Error);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);

                    using (ShimsContext.Create())
                    {

                        SetupShim();

                        string ErrorText = "ErrorText";
                        shimBoxModelResultService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        BoxModelResultModel boxModelResultModelRet = boxModelResultService.PostUpdateBoxModelResultDB(boxModelResultModelNew);
                        Assert.AreEqual(ErrorText, boxModelResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostUpdateBoxModelDB_GetBoxModelResultWithBoxModelResultIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelResultModel boxModelResultModel = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.DecayUntreated);
                    Assert.AreEqual("", boxModelResultModel.Error);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelResultService.GetBoxModelResultWithBoxModelResultIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        BoxModelResultModel boxModelResultModelRet = boxModelResultService.PostUpdateBoxModelResultDB(boxModelResultModelNew);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.BoxModelResult), boxModelResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostUpdateBoxModelDB_FillBoxModelResultModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelResultModel boxModelResultModel = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.DecayUntreated);
                    Assert.AreEqual("", boxModelResultModel.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelResultService.FillBoxModelResultModelBoxModelResultBoxModelResultModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        BoxModelResultModel boxModelResultModelRet = boxModelResultService.PostUpdateBoxModelResultDB(boxModelResultModel);
                        Assert.AreEqual(ErrorText, boxModelResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostUpdateBoxModelDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelResultModel boxModelResultModel = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.DecayUntreated);
                    Assert.AreEqual("", boxModelResultModel.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelResultService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        BoxModelResultModel boxModelResultModelRet = boxModelResultService.PostUpdateBoxModelResultDB(boxModelResultModel);
                        Assert.AreEqual(ErrorText, boxModelResultModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void BoxModelResultService_PostUpdateBoxModelDB_Update_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    BoxModelModel boxModelModelRet = boxModelServiceTest.AddBoxModelModel();
                    Assert.AreEqual("", boxModelModelRet.Error);

                    BoxModelResultModel boxModelResultModel = boxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModelRet.BoxModelID, BoxModelResultTypeEnum.DecayUntreated);
                    Assert.AreEqual("", boxModelResultModel.Error);

                    FillBoxModelResultModelNew(boxModelModelRet, boxModelResultModelNew);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimBoxModelResultService.FillBoxModelResultModelBoxModelResultBoxModelResultModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        BoxModelResultModel boxModelResultModelRet = boxModelResultService.PostUpdateBoxModelResultDB(boxModelResultModelNew);
                        Assert.IsTrue(boxModelResultModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions
        private void FillBoxModelResultModelNew(BoxModelModel boxModelModel, BoxModelResultModel boxModelResultModel)
        {
            boxModelResultModel.BoxModelID = boxModelModel.BoxModelID;
            boxModelResultModel.CircleCenterLatitude = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.CircleCenterLongitude = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.FixLength = true;
            boxModelResultModel.FixWidth = false;
            boxModelResultModel.LeftSideDiameterLineAngle_deg = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.LeftSideLineAngle_deg = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.LeftSideLineStartLatitude = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.LeftSideLineStartLongitude = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.Radius_m = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.RectLength_m = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.RectWidth_m = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.BoxModelResultType = BoxModelResultTypeEnum.DecayUntreated;
            boxModelResultModel.Surface_m2 = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.Volume_m3 = randomService.RandomDouble(1.0, 1000.0);

            Assert.IsTrue(boxModelResultModel.BoxModelID == boxModelModel.BoxModelID);
            Assert.IsTrue(boxModelResultModel.BoxModelResultType == BoxModelResultTypeEnum.DecayUntreated);
            Assert.IsTrue(boxModelResultModel.Volume_m3 >= 1 && boxModelResultModel.Volume_m3 <= 1000);
            Assert.IsTrue(boxModelResultModel.Surface_m2 >= 1 && boxModelResultModel.Surface_m2 <= 1000);
            Assert.IsTrue(boxModelResultModel.Radius_m >= 1 && boxModelResultModel.Radius_m <= 1000);
            Assert.IsTrue(boxModelResultModel.LeftSideDiameterLineAngle_deg >= 1 && boxModelResultModel.LeftSideDiameterLineAngle_deg <= 1000);
            Assert.IsTrue(boxModelResultModel.CircleCenterLatitude >= 1 && boxModelResultModel.CircleCenterLatitude <= 1000);
            Assert.IsTrue(boxModelResultModel.CircleCenterLongitude >= 1 && boxModelResultModel.CircleCenterLongitude <= 1000);
            Assert.IsTrue(boxModelResultModel.FixLength == true);
            Assert.IsTrue(boxModelResultModel.FixWidth == false);
            Assert.IsTrue(boxModelResultModel.RectLength_m >= 1 && boxModelResultModel.RectLength_m <= 1000);
            Assert.IsTrue(boxModelResultModel.RectWidth_m >= 1 && boxModelResultModel.RectWidth_m <= 1000);
            Assert.IsTrue(boxModelResultModel.LeftSideLineAngle_deg >= 1 && boxModelResultModel.LeftSideLineAngle_deg <= 1000);
            Assert.IsTrue(boxModelResultModel.LeftSideLineStartLatitude >= 1 && boxModelResultModel.LeftSideLineStartLatitude <= 1000);
            Assert.IsTrue(boxModelResultModel.LeftSideLineStartLongitude >= 1 && boxModelResultModel.LeftSideLineStartLongitude <= 1000);
        }
        private void FillBoxModelResultModelUpdate(BoxModelResultModel boxModelResultModel)
        {
            boxModelResultModel.CircleCenterLatitude = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.CircleCenterLongitude = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.FixLength = true;
            boxModelResultModel.FixWidth = false;
            boxModelResultModel.LeftSideDiameterLineAngle_deg = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.LeftSideLineAngle_deg = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.LeftSideLineStartLatitude = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.LeftSideLineStartLongitude = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.Radius_m = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.RectLength_m = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.RectWidth_m = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.BoxModelResultType = BoxModelResultTypeEnum.DecayUntreated;
            boxModelResultModel.Surface_m2 = randomService.RandomDouble(1.0, 1000.0);
            boxModelResultModel.Volume_m3 = randomService.RandomDouble(1.0, 1000.0);

            Assert.IsTrue(boxModelResultModel.BoxModelID != 0);
            Assert.IsTrue(boxModelResultModel.BoxModelResultType == BoxModelResultTypeEnum.DecayUntreated);
            Assert.IsTrue(boxModelResultModel.Volume_m3 >= 1 && boxModelResultModel.Volume_m3 <= 1000);
            Assert.IsTrue(boxModelResultModel.Surface_m2 >= 1 && boxModelResultModel.Surface_m2 <= 1000);
            Assert.IsTrue(boxModelResultModel.Radius_m >= 1 && boxModelResultModel.Radius_m <= 1000);
            Assert.IsTrue(boxModelResultModel.LeftSideDiameterLineAngle_deg >= 1 && boxModelResultModel.LeftSideDiameterLineAngle_deg <= 1000);
            Assert.IsTrue(boxModelResultModel.CircleCenterLatitude >= 1 && boxModelResultModel.CircleCenterLatitude <= 1000);
            Assert.IsTrue(boxModelResultModel.CircleCenterLongitude >= 1 && boxModelResultModel.CircleCenterLongitude <= 1000);
            Assert.IsTrue(boxModelResultModel.FixLength == true);
            Assert.IsTrue(boxModelResultModel.FixWidth == false);
            Assert.IsTrue(boxModelResultModel.RectLength_m >= 1 && boxModelResultModel.RectLength_m <= 1000);
            Assert.IsTrue(boxModelResultModel.RectWidth_m >= 1 && boxModelResultModel.RectWidth_m <= 1000);
            Assert.IsTrue(boxModelResultModel.LeftSideLineAngle_deg >= 1 && boxModelResultModel.LeftSideLineAngle_deg <= 1000);
            Assert.IsTrue(boxModelResultModel.LeftSideLineStartLatitude >= 1 && boxModelResultModel.LeftSideLineStartLatitude <= 1000);
            Assert.IsTrue(boxModelResultModel.LeftSideLineStartLongitude >= 1 && boxModelResultModel.LeftSideLineStartLongitude <= 1000);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            boxModelService = new BoxModelService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            boxModelResultService = new BoxModelResultService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            boxModelLanguageService = new BoxModelLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            boxModelModelNew = new BoxModelModel();
            boxModelResultModelNew = new BoxModelResultModel();
            boxModel = new BoxModel();
            boxModelServiceTest = new BoxModelServiceTest();
            boxModelServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimBoxModelResultService = new ShimBoxModelResultService(boxModelResultService);
        }
        #endregion Functions
    }
}


