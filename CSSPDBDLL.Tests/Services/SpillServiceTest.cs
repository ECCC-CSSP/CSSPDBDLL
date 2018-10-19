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
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for SpillServiceTest
    /// </summary>
    [TestClass]
    public class SpillServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "Spill";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private SpillService spillService { get; set; }
        private SpillLanguageService spillLanguageService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private SpillModel spillModelNew { get; set; }
        private Spill spill { get; set; }
        private ShimSpillService shimSpillService { get; set; }
        private ShimSpillLanguageService shimSpillLanguageService { get; set; }
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
        public SpillServiceTest()
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
        public void SpillService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(spillService);
                Assert.IsNotNull(spillService._SpillLanguageService);
                Assert.IsNotNull(spillService.db);
                Assert.IsNotNull(spillService.LanguageRequest);
                Assert.IsNotNull(spillService.User);
                Assert.AreEqual(user.Identity.Name, spillService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), spillService.LanguageRequest);
            }
        }
        [TestMethod]
        public void SpillService_SpillModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModel = AddSpillModel();
                    Assert.AreEqual("", spillModel.Error);

                    #region Good
                    spillModelNew.InfrastructureTVItemID = spillModel.InfrastructureTVItemID;
                    spillModelNew.MunicipalityTVItemID = spillModel.MunicipalityTVItemID;
                    FillSpillModel(spillModelNew);

                    string retStr = spillService.SpillModelOK(spillModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region MunicipalityTVItemID
                    spillModelNew.InfrastructureTVItemID = spillModel.InfrastructureTVItemID;
                    spillModelNew.MunicipalityTVItemID = spillModel.MunicipalityTVItemID;
                    FillSpillModel(spillModelNew);
                    spillModelNew.MunicipalityTVItemID = 0;

                    retStr = spillService.SpillModelOK(spillModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.MunicipalityTVItemID), retStr);

                    spillModelNew.InfrastructureTVItemID = spillModel.InfrastructureTVItemID;
                    spillModelNew.MunicipalityTVItemID = spillModel.MunicipalityTVItemID;
                    FillSpillModel(spillModelNew);
                    spillModelNew.MunicipalityTVItemID = 1;

                    retStr = spillService.SpillModelOK(spillModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.MunicipalityTVItemID), retStr);
                    #endregion MunicipalityTVItemID

                    #region InfrastructureTVItemID
                    spillModelNew.InfrastructureTVItemID = spillModel.InfrastructureTVItemID;
                    spillModelNew.MunicipalityTVItemID = spillModel.MunicipalityTVItemID;
                    FillSpillModel(spillModelNew);
                    spillModelNew.InfrastructureTVItemID = 0;

                    retStr = spillService.SpillModelOK(spillModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID), retStr);

                    spillModelNew.InfrastructureTVItemID = spillModel.InfrastructureTVItemID;
                    spillModelNew.MunicipalityTVItemID = spillModel.MunicipalityTVItemID;
                    FillSpillModel(spillModelNew);
                    spillModelNew.InfrastructureTVItemID = 1;

                    retStr = spillService.SpillModelOK(spillModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion InfrastructureTVItemID

                    #region StartDateTime_Local
                    spillModelNew.InfrastructureTVItemID = spillModel.InfrastructureTVItemID;
                    spillModelNew.MunicipalityTVItemID = spillModel.MunicipalityTVItemID;
                    FillSpillModel(spillModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimSpillService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };
                        retStr = spillService.SpillModelOK(spillModelNew);
                        Assert.IsNotNull(ErrorText, retStr);
                    }
                    #endregion StartDateTime_Local

                    #region StartDateTime_Local > EndDateTime_Local
                    FillSpillModel(spillModelNew);
                    spillModelNew.StartDateTime_Local = randomService.RandomDateTime();
                    spillModelNew.EndDateTime_Local = spillModelNew.StartDateTime_Local.AddHours(-1);

                    retStr = spillService.SpillModelOK(spillModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDateTime_Local, ServiceRes.EndDateTime_Local), retStr);
                    #endregion StartDateTime_Local > EndDateTime_Local

                    #region AverageFlow_m3_day
                    FillSpillModel(spillModelNew);
                    double Min = 1D;
                    double Max = 100000D;
                    spillModelNew.AverageFlow_m3_day = Min - 1;

                    retStr = spillService.SpillModelOK(spillModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AverageFlow_m3_day, Min, Max), retStr);

                    FillSpillModel(spillModelNew);
                    spillModelNew.AverageFlow_m3_day = Max + 1;

                    retStr = spillService.SpillModelOK(spillModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AverageFlow_m3_day, Min, Max), retStr);

                    FillSpillModel(spillModelNew);
                    spillModelNew.AverageFlow_m3_day = Max - 1;

                    retStr = spillService.SpillModelOK(spillModelNew);
                    Assert.AreEqual("", retStr);

                    FillSpillModel(spillModelNew);
                    spillModelNew.AverageFlow_m3_day = Min;

                    retStr = spillService.SpillModelOK(spillModelNew);
                    Assert.AreEqual("", retStr);

                    FillSpillModel(spillModelNew);
                    spillModelNew.AverageFlow_m3_day = Max;

                    retStr = spillService.SpillModelOK(spillModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AverageFlow_m3_day
                }
            }
        }
        [TestMethod]
        public void SpillService_FillSpill_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelInfrastructure = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelInfrastructure.Error);

                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    spillModelNew.InfrastructureTVItemID = tvItemModelInfrastructure.TVItemID;
                    spillModelNew.MunicipalityTVItemID = tvItemModelMunicipality.TVItemID;
                    FillSpillModel(spillModelNew);

                    ContactOK contactOK = spillService.IsContactOK();

                    string retStr = spillService.FillSpill(spill, spillModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, spill.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = spillService.FillSpill(spill, spillModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, spill.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void SpillService_GetSpillModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    int spillCount = spillService.GetSpillModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, spillCount);
                }
            }
        }
        [TestMethod]
        public void SpillService_GetSpillModelListWithInfrastructureTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    List<SpillModel> spillModelList = spillService.GetSpillModelListWithInfrastructureTVItemIDDB((int)spillModelRet.InfrastructureTVItemID);
                    Assert.IsTrue(spillModelList.Where(c => c.SpillID == spillModelRet.SpillID).Any());

                    int InfrastructureTVItemID = 0;
                    spillModelList = spillService.GetSpillModelListWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
                    Assert.AreEqual(0, spillModelList.Count);
                }
            }
        }
        [TestMethod]
        public void SpillService_GetSpillModelListWithMunicipalityTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    List<SpillModel> spillModelList = spillService.GetSpillModelListWithMunicipalityTVItemIDDB(spillModelRet.MunicipalityTVItemID);
                    Assert.IsTrue(spillModelList.Where(c => c.SpillID == spillModelRet.SpillID).Any());

                    int MunicipalityTVItemID = 0;
                    spillModelList = spillService.GetSpillModelListWithMunicipalityTVItemIDDB(MunicipalityTVItemID);
                    Assert.AreEqual(0, spillModelList.Count);
                }
            }
        }
        [TestMethod]
        public void SpillService_GetSpillModelWithSpillIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    SpillModel spillModelRet2 = spillService.GetSpillModelWithSpillIDDB(spillModelRet.SpillID);
                    Assert.AreEqual(spillModelRet.SpillID, spillModelRet2.SpillID);

                    int SpillID = 0;
                    SpillModel spillRet2 = spillService.GetSpillModelWithSpillIDDB(SpillID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Spill, ServiceRes.SpillID, SpillID), spillRet2.Error);
                }
            }
        }
        [TestMethod]
        public void SpillService_GetSpillWithSpillIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    Spill spillRet = spillService.GetSpillWithSpillIDDB(spillModelRet.SpillID);
                    Assert.AreEqual(spillModelRet.SpillID, spillRet.SpillID);

                    Spill spillRet2 = spillService.GetSpillWithSpillIDDB(0);
                    Assert.IsNull(spillRet2);
                }
            }
        }
        [TestMethod]
        public void SpillService_GetSpillExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    Spill spillRet = spillService.GetSpillExistDB(spillModelRet);
                    Assert.AreEqual(spillModelRet.SpillID, spillRet.SpillID);

                    spillModelRet.MunicipalityTVItemID = 0;
                    Spill spillRet2 = spillService.GetSpillExistDB(spillModelRet);
                    Assert.IsNull(spillRet2);
                }
            }
        }
        [TestMethod]
        public void SpillService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    SpillModel spillModelRet = spillService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, spillModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddUpdateDeleteSpill_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    SpillModel spillModelRet2 = UpdateSpillModel(spillModelRet);

                    SpillModel spillModelRet3 = spillService.PostDeleteSpillDB(spillModelRet2.SpillID);
                    Assert.AreEqual("", spillModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddSpillDB_SpillModelOK_Error_Test()
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
                        shimSpillService.SpillModelOKSpillModel = (a) =>
                        {
                            return ErrorText;
                        };

                        SpillModel spillModelRet = AddSpillModel();
                        Assert.AreEqual(ErrorText, spillModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddSpillDB_IsContactOK_Error_Test()
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
                        shimSpillService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        SpillModel spillModelRet = AddSpillModel();
                        Assert.AreEqual(ErrorText, spillModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddSpillDB_GetTVItemModelWithTVItemIDDB_Error_Test()
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

                        SpillModel spillModelRet = AddSpillModel();
                        Assert.AreEqual(ErrorText, spillModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddSpillDB_GetSpillExistDB_Error_Test()
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
                        shimSpillService.GetSpillExistDBSpillModel = (a) =>
                        {
                            return new Spill();
                        };

                        SpillModel spillModelRet = AddSpillModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.Spill), spillModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddSpillDB_FillSpill_Error_Test()
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
                        shimSpillService.FillSpillSpillSpillModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        SpillModel spillModelRet = AddSpillModel();
                        Assert.AreEqual(ErrorText, spillModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddSpillDB_DoAddChanges_Error_Test()
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
                        shimSpillService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        SpillModel spillModelRet = AddSpillModel();
                        Assert.AreEqual(ErrorText, spillModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddSpillDB_Add_Error_Test()
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
                        shimSpillService.FillSpillSpillSpillModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        SpillModel spillModelRet = AddSpillModel();
                        Assert.IsTrue(spillModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddSpillDB_PostAddSpillLanguageDB_Error_Test()
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
                        shimSpillLanguageService.PostAddSpillLanguageDBSpillLanguageModel = (a) =>
                        {
                            return new SpillLanguageModel() { Error = ErrorText };
                        };

                        SpillModel spillModelRet = AddSpillModel();
                        Assert.AreEqual(ErrorText, spillModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddSpillDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();
                    Assert.IsNotNull(spillModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, spillModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddSpillDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();
                    Assert.IsNotNull(spillModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, spillModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void SpillService_PostDeleteSpill_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimSpillService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        SpillModel spillModelRet2 = spillService.PostDeleteSpillDB(spillModelRet.SpillID);
                        Assert.AreEqual(ErrorText, spillModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostDeleteSpill_GetSpillWithSpillIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimSpillService.GetSpillWithSpillIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        SpillModel spillModelRet2 = spillService.PostDeleteSpillDB(spillModelRet.SpillID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Spill), spillModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostDeleteSpill_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimSpillService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        SpillModel spillModelRet2 = spillService.PostDeleteSpillDB(spillModelRet.SpillID);
                        Assert.AreEqual(ErrorText, spillModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostUpdateSpill_SpillModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimSpillService.SpillModelOKSpillModel = (a) =>
                        {
                            return ErrorText;
                        };

                        SpillModel spillModelRet2 = UpdateSpillModel(spillModelRet);
                        Assert.AreEqual(ErrorText, spillModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostUpdateSpill_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimSpillService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        SpillModel spillModelRet2 = UpdateSpillModel(spillModelRet);
                        Assert.AreEqual(ErrorText, spillModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostUpdateSpill_GetSpillWithSpillIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimSpillService.GetSpillWithSpillIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        SpillModel spillModelRet2 = UpdateSpillModel(spillModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Spill), spillModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostUpdateSpill_FillSpill_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimSpillService.FillSpillSpillSpillModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        SpillModel spillModelRet2 = UpdateSpillModel(spillModelRet);
                        Assert.AreEqual(ErrorText, spillModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostUpdateSpill_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimSpillService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        SpillModel spillModelRet2 = UpdateSpillModel(spillModelRet);
                        Assert.AreEqual(ErrorText, spillModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostUpdateSpill_PostUpdateSpillLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimSpillLanguageService.PostUpdateSpillLanguageDBSpillLanguageModel = (a) =>
                        {
                            return new SpillLanguageModel() { Error = ErrorText };
                        };

                        SpillModel spillModelRet2 = UpdateSpillModel(spillModelRet);
                        Assert.AreEqual(ErrorText, spillModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddSpillAndSpillLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    SpillModel spillModelRet = AddSpillModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, spillModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void SpillService_PostAddSpillAndSpillLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SpillModel spillModelRet = AddSpillModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, spillModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public SpillModel AddSpillModel()
        {
            TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
            Assert.AreEqual("", tvItemModelMunicipality.Error);

            TVItemModel tvItemModelInfrastructure = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
            Assert.AreEqual("", tvItemModelInfrastructure.Error);

            spillModelNew.MunicipalityTVItemID = tvItemModelMunicipality.TVItemID;
            spillModelNew.InfrastructureTVItemID = tvItemModelInfrastructure.TVItemID;
            FillSpillModel(spillModelNew);

            SpillModel spillModelRet = spillService.PostAddSpillDB(spillModelNew);
            if (!string.IsNullOrWhiteSpace(spillModelRet.Error))
            {
                return spillModelRet;
            }

            CompareSpillModels(spillModelNew, spillModelRet);

            return spillModelRet;
        }
        public SpillModel UpdateSpillModel(SpillModel spillModel)
        {
            FillSpillModel(spillModel);

            SpillModel spillModelRet2 = spillService.PostUpdateSpillDB(spillModel);
            if (!string.IsNullOrWhiteSpace(spillModelRet2.Error))
            {
                return spillModelRet2;
            }

            CompareSpillModels(spillModel, spillModelRet2);

            return spillModelRet2;
        }
        private void CompareSpillModels(SpillModel spillModelNew, SpillModel spillModelRet)
        {
            Assert.AreEqual(spillModelNew.MunicipalityTVItemID, spillModelRet.MunicipalityTVItemID);
            Assert.AreEqual(spillModelNew.InfrastructureTVItemID, spillModelRet.InfrastructureTVItemID);
            Assert.AreEqual(spillModelNew.StartDateTime_Local, spillModelRet.StartDateTime_Local);
            Assert.AreEqual(spillModelNew.EndDateTime_Local, spillModelRet.EndDateTime_Local);
            Assert.AreEqual(spillModelNew.AverageFlow_m3_day, spillModelRet.AverageFlow_m3_day);

            foreach (LanguageEnum Lang in spillService.LanguageListAllowable)
            {
                SpillLanguageModel spillLanguageModel = spillService._SpillLanguageService.GetSpillLanguageModelWithSpillIDAndLanguageDB(spillModelRet.SpillID, Lang);

                Assert.AreEqual("", spillLanguageModel.Error);
                if (Lang == spillService.LanguageRequest)
                {
                    Assert.AreEqual(spillModelRet.SpillComment, spillLanguageModel.SpillComment);
                }
            }
        }
        private void FillSpillModel(SpillModel spillModel)
        {
            spillModel.SpillComment = randomService.RandomString("", 50);
            spillModel.MunicipalityTVItemID = spillModel.MunicipalityTVItemID;
            spillModel.InfrastructureTVItemID = spillModel.InfrastructureTVItemID;
            spillModel.StartDateTime_Local = randomService.RandomDateTime();
            spillModel.EndDateTime_Local = spillModel.StartDateTime_Local.AddHours(1);
            spillModel.AverageFlow_m3_day = randomService.RandomDouble(0, 100000);
            Assert.IsTrue(spillModel.SpillComment.Length == 50);
            Assert.IsTrue(spillModel.MunicipalityTVItemID != 0);
            Assert.IsTrue(spillModel.InfrastructureTVItemID != 0);
            Assert.IsTrue(spillModel.StartDateTime_Local != null);
            Assert.IsTrue(spillModel.EndDateTime_Local != null);
            Assert.IsTrue(spillModel.AverageFlow_m3_day >= 0 && spillModel.AverageFlow_m3_day <= 100000);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            spillService = new SpillService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            spillLanguageService = new SpillLanguageService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            spillModelNew = new SpillModel();
            spill = new Spill();
        }
        private void SetupShim()
        {
            shimSpillService = new ShimSpillService(spillService);
            shimSpillLanguageService = new ShimSpillLanguageService(spillService._SpillLanguageService);
            shimTVItemService = new ShimTVItemService(spillService._TVItemService);
        }
        #endregion Functions private
    }
}

