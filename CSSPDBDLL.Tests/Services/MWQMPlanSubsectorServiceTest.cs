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
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MWQMPlanSubsectorServiceTest
    /// </summary>
    [TestClass]
    public class MWQMPlanSubsectorServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MWQMPlanSubsector";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MWQMPlanSubsectorService labContractSubsectorService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MWQMPlanSubsectorModel labContractSubsectorModelNew { get; set; }
        private MWQMPlanSubsector labContractSubsector { get; set; }
        private ShimMWQMPlanSubsectorService shimMWQMPlanSubsectorService { get; set; }
        private MWQMPlanServiceTest labContractServiceTest { get; set; }
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
        public MWQMPlanSubsectorServiceTest()
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
        public void MWQMPlanSubsectorService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(labContractSubsectorService);
                Assert.IsNotNull(labContractSubsectorService.db);
                Assert.IsNotNull(labContractSubsectorService.LanguageRequest);
                Assert.IsNotNull(labContractSubsectorService.User);
                Assert.AreEqual(user.Identity.Name, labContractSubsectorService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), labContractSubsectorService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_MWQMPlanSubsectorModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel labContractModel = labContractServiceTest.AddMWQMPlanModel();
                    Assert.AreEqual("", labContractModel.Error);

                    TVItemModel tvItemModelRet = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    #region Good
                    labContractSubsectorModelNew.MWQMPlanID = labContractModel.MWQMPlanID;
                    labContractSubsectorModelNew.SubsectorTVItemID = tvItemModelRet.TVItemID;
                    FillMWQMPlanSubsectorModel(labContractSubsectorModelNew);

                    string retStr = labContractSubsectorService.MWQMPlanSubsectorModelOK(labContractSubsectorModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region MWQMPlanID
                    labContractSubsectorModelNew.MWQMPlanID = tvItemModelRet.TVItemID;
                    FillMWQMPlanSubsectorModel(labContractSubsectorModelNew);
                    labContractSubsectorModelNew.MWQMPlanID = 0;

                    retStr = labContractSubsectorService.MWQMPlanSubsectorModelOK(labContractSubsectorModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMPlanID), retStr);

                    labContractSubsectorModelNew.MWQMPlanID = tvItemModelRet.TVItemID;
                    FillMWQMPlanSubsectorModel(labContractSubsectorModelNew);
                    labContractSubsectorModelNew.MWQMPlanID = 1;

                    retStr = labContractSubsectorService.MWQMPlanSubsectorModelOK(labContractSubsectorModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMPlanID

                    #region SubsectorTVItemID
                    labContractSubsectorModelNew.SubsectorTVItemID = tvItemModelRet.TVItemID;
                    FillMWQMPlanSubsectorModel(labContractSubsectorModelNew);
                    labContractSubsectorModelNew.SubsectorTVItemID = 0;

                    retStr = labContractSubsectorService.MWQMPlanSubsectorModelOK(labContractSubsectorModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID), retStr);

                    labContractSubsectorModelNew.SubsectorTVItemID = tvItemModelRet.TVItemID;
                    FillMWQMPlanSubsectorModel(labContractSubsectorModelNew);
                    labContractSubsectorModelNew.SubsectorTVItemID = 1;

                    retStr = labContractSubsectorService.MWQMPlanSubsectorModelOK(labContractSubsectorModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SubsectorTVItemID

                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_FillMWQMPlanSubsector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanModel labContractModel = labContractServiceTest.AddMWQMPlanModel();
                    Assert.AreEqual("", labContractModel.Error);

                    TVItemModel tvItemModelSubsector = randomService.RandomTVItem(TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    labContractSubsectorModelNew.MWQMPlanID = labContractModel.MWQMPlanID;
                    labContractSubsectorModelNew.SubsectorTVItemID = tvItemModelSubsector.TVItemID;
                    FillMWQMPlanSubsectorModel(labContractSubsectorModelNew);

                    ContactOK contactOK = labContractSubsectorService.IsContactOK();

                    string retStr = labContractSubsectorService.FillMWQMPlanSubsector(labContractSubsector, labContractSubsectorModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, labContractSubsector.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = labContractSubsectorService.FillMWQMPlanSubsector(labContractSubsector, labContractSubsectorModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, labContractSubsector.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_GetMWQMPlanSubsectorModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    int labContractCount = labContractSubsectorService.GetMWQMPlanSubsectorModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, labContractCount);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_GetMWQMPlanSubsectorModelListWithSubsectorTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    List<MWQMPlanSubsectorModel> labContractSubsectorModelList = labContractSubsectorService.GetMWQMPlanSubsectorModelListWithMWQMPlanIDDB(labContractSubsectorModelRet.MWQMPlanID);
                    Assert.IsTrue(labContractSubsectorModelList.Where(c => c.MWQMPlanSubsectorID == labContractSubsectorModelRet.MWQMPlanSubsectorID).Any());

                    int LabContactID = 0;
                    labContractSubsectorModelList = labContractSubsectorService.GetMWQMPlanSubsectorModelListWithMWQMPlanIDDB(LabContactID);
                    Assert.AreEqual(0, labContractSubsectorModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_GetMWQMPlanSubsectorModelWithMWQMPlanSubsectorIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    MWQMPlanSubsectorModel labContractSubsectorModelRet2 = labContractSubsectorService.GetMWQMPlanSubsectorModelWithMWQMPlanSubsectorIDDB(labContractSubsectorModelRet.MWQMPlanSubsectorID);
                    Assert.AreEqual(labContractSubsectorModelRet.MWQMPlanSubsectorID, labContractSubsectorModelRet2.MWQMPlanSubsectorID);

                    int MWQMPlanSubsectorID = 0;
                    labContractSubsectorModelRet2 = labContractSubsectorService.GetMWQMPlanSubsectorModelWithMWQMPlanSubsectorIDDB(MWQMPlanSubsectorID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMPlanSubsector, ServiceRes.MWQMPlanSubsectorID, MWQMPlanSubsectorID), labContractSubsectorModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_GetMWQMPlanSubsectorModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();
                    Assert.AreEqual("", labContractSubsectorModelRet.Error);

                    MWQMPlanSubsectorModel labContractSubsectorModelRet2 = labContractSubsectorService.GetMWQMPlanSubsectorModelExistDB(labContractSubsectorModelRet);
                    Assert.AreEqual(labContractSubsectorModelRet.MWQMPlanSubsectorID, labContractSubsectorModelRet2.MWQMPlanSubsectorID);

                    labContractSubsectorModelRet.MWQMPlanID = 0;
                    labContractSubsectorModelRet2 = labContractSubsectorService.GetMWQMPlanSubsectorModelExistDB(labContractSubsectorModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_,
ServiceRes.MWQMPlanSubsector,
ServiceRes.MWQMPlanID + "," +
ServiceRes.SubsectorTVItemID,
labContractSubsectorModelRet.MWQMPlanID.ToString() + "," +
labContractSubsectorModelRet.SubsectorTVItemID), labContractSubsectorModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_GetMWQMPlanSubsectorWithMWQMPlanSubsectorIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    MWQMPlanSubsector labContractRet = labContractSubsectorService.GetMWQMPlanSubsectorWithMWQMPlanSubsectorIDDB(labContractSubsectorModelRet.MWQMPlanSubsectorID);
                    Assert.AreEqual(labContractSubsectorModelRet.MWQMPlanSubsectorID, labContractRet.MWQMPlanSubsectorID);

                    int MWQMPlanSubsectorID = 0;
                    MWQMPlanSubsector labContractRet2 = labContractSubsectorService.GetMWQMPlanSubsectorWithMWQMPlanSubsectorIDDB(MWQMPlanSubsectorID);
                    Assert.IsNull(labContractRet2);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = labContractSubsectorService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, labContractSubsectorModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostAddUpdateDeleteMWQMPlanSubsector_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    MWQMPlanSubsectorModel labContractSubsectorModelRet2 = UpdateMWQMPlanSubsectorModel(labContractSubsectorModelRet);

                    MWQMPlanSubsectorModel labContractSubsectorModelRet3 = labContractSubsectorService.PostDeleteMWQMPlanSubsectorDB(labContractSubsectorModelRet2.MWQMPlanSubsectorID);
                    Assert.AreEqual("", labContractSubsectorModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostAddMWQMPlanSubsectorDB_MWQMPlanSubsectorModelOK_Error_Test()
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
                        shimMWQMPlanSubsectorService.MWQMPlanSubsectorModelOKMWQMPlanSubsectorModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();
                        Assert.AreEqual(ErrorText, labContractSubsectorModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostAddMWQMPlanSubsectorDB_IsContactOK_Error_Test()
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
                        shimMWQMPlanSubsectorService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();
                        Assert.AreEqual(ErrorText, labContractSubsectorModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostAddMWQMPlanSubsectorDB_GetMWQMPlanSubsectorExistDB_Error_Test()
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
                        shimMWQMPlanSubsectorService.GetMWQMPlanSubsectorModelExistDBMWQMPlanSubsectorModel = (a) =>
                        {
                            return new MWQMPlanSubsectorModel();
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMPlanSubsector), labContractSubsectorModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostAddMWQMPlanSubsectorDB_FillMWQMPlanSubsector_Error_Test()
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
                        shimMWQMPlanSubsectorService.FillMWQMPlanSubsectorMWQMPlanSubsectorMWQMPlanSubsectorModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();
                        Assert.AreEqual(ErrorText, labContractSubsectorModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostAddMWQMPlanSubsectorDB_DoAddChanges_Error_Test()
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
                        shimMWQMPlanSubsectorService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();
                        Assert.AreEqual(ErrorText, labContractSubsectorModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostAddMWQMPlanSubsectorDB_Add_Error_Test()
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
                        shimMWQMPlanSubsectorService.FillMWQMPlanSubsectorMWQMPlanSubsectorMWQMPlanSubsectorModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();
                        Assert.IsTrue(labContractSubsectorModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostAddMWQMPlanSubsectorDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();
                    Assert.IsNotNull(labContractSubsectorModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, labContractSubsectorModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostAddMWQMPlanSubsectorDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();
                    Assert.IsNotNull(labContractSubsectorModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, labContractSubsectorModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostDeleteMWQMPlanSubsector_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet2 = labContractSubsectorService.PostDeleteMWQMPlanSubsectorDB(labContractSubsectorModelRet.MWQMPlanSubsectorID);
                        Assert.AreEqual(ErrorText, labContractSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostDeleteMWQMPlanSubsector_GetMWQMPlanSubsectorWithMWQMPlanSubsectorIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorService.GetMWQMPlanSubsectorWithMWQMPlanSubsectorIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet2 = labContractSubsectorService.PostDeleteMWQMPlanSubsectorDB(labContractSubsectorModelRet.MWQMPlanSubsectorID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMPlanSubsector), labContractSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostDeleteMWQMPlanSubsector_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet2 = labContractSubsectorService.PostDeleteMWQMPlanSubsectorDB(labContractSubsectorModelRet.MWQMPlanSubsectorID);
                        Assert.AreEqual(ErrorText, labContractSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostUpdateMWQMPlanSubsector_MWQMPlanSubsectorModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorService.MWQMPlanSubsectorModelOKMWQMPlanSubsectorModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet2 = UpdateMWQMPlanSubsectorModel(labContractSubsectorModelRet);
                        Assert.AreEqual(ErrorText, labContractSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostUpdateMWQMPlanSubsector_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet2 = UpdateMWQMPlanSubsectorModel(labContractSubsectorModelRet);
                        Assert.AreEqual(ErrorText, labContractSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostUpdateMWQMPlanSubsector_GetMWQMPlanSubsectorWithMWQMPlanSubsectorIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorService.GetMWQMPlanSubsectorWithMWQMPlanSubsectorIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet2 = UpdateMWQMPlanSubsectorModel(labContractSubsectorModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMPlanSubsector), labContractSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostUpdateMWQMPlanSubsector_FillMWQMPlanSubsector_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorService.FillMWQMPlanSubsectorMWQMPlanSubsectorMWQMPlanSubsectorModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet2 = UpdateMWQMPlanSubsectorModel(labContractSubsectorModelRet);
                        Assert.AreEqual(ErrorText, labContractSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostUpdateMWQMPlanSubsector_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMPlanSubsectorService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMPlanSubsectorModel labContractSubsectorModelRet2 = UpdateMWQMPlanSubsectorModel(labContractSubsectorModelRet);
                        Assert.AreEqual(ErrorText, labContractSubsectorModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostAddMWQMPlanSubsectorAndMWQMPlanSubsectorLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, labContractSubsectorModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMPlanSubsectorService_PostAddMWQMPlanSubsectorAndMWQMPlanSubsectorLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMPlanSubsectorModel labContractSubsectorModelRet = AddMWQMPlanSubsectorModel();
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, labContractSubsectorModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public MWQMPlanSubsectorModel AddMWQMPlanSubsectorModel()
        {
            MWQMPlanModel labContractModel = labContractServiceTest.AddMWQMPlanModel();

            if (!string.IsNullOrWhiteSpace(labContractModel.Error))
                return new MWQMPlanSubsectorModel() { Error = labContractModel.Error };

            TVItemModel tvItemModelSubsector = randomService.RandomTVItem(TVTypeEnum.Subsector);

            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return new MWQMPlanSubsectorModel() { Error = tvItemModelSubsector.Error };

            labContractSubsectorModelNew.MWQMPlanID = labContractModel.MWQMPlanID;
            labContractSubsectorModelNew.SubsectorTVItemID = tvItemModelSubsector.TVItemID;
            FillMWQMPlanSubsectorModel(labContractSubsectorModelNew);

            MWQMPlanSubsectorModel labContractModelRet = labContractSubsectorService.PostAddMWQMPlanSubsectorDB(labContractSubsectorModelNew);
            if (!string.IsNullOrWhiteSpace(labContractModelRet.Error))
            {
                return labContractModelRet;
            }

            CompareMWQMPlanSubsectorModels(labContractSubsectorModelNew, labContractModelRet);

            return labContractModelRet;
        }
        public MWQMPlanSubsectorModel UpdateMWQMPlanSubsectorModel(MWQMPlanSubsectorModel labContractSubsectorModel)
        {
            FillMWQMPlanSubsectorModel(labContractSubsectorModel);

            MWQMPlanSubsectorModel labContractModelRet2 = labContractSubsectorService.PostUpdateMWQMPlanSubsectorDB(labContractSubsectorModel);
            if (!string.IsNullOrWhiteSpace(labContractModelRet2.Error))
            {
                return labContractModelRet2;
            }

            CompareMWQMPlanSubsectorModels(labContractSubsectorModel, labContractModelRet2);

            return labContractModelRet2;
        }
        private void CompareMWQMPlanSubsectorModels(MWQMPlanSubsectorModel labContractSubsectorModelNew, MWQMPlanSubsectorModel labContractSubsectorModelRet)
        {
            Assert.AreEqual(labContractSubsectorModelNew.MWQMPlanID, labContractSubsectorModelRet.MWQMPlanID);
            Assert.AreEqual(labContractSubsectorModelNew.SubsectorTVItemID, labContractSubsectorModelRet.SubsectorTVItemID);
        }
        private void FillMWQMPlanSubsectorModel(MWQMPlanSubsectorModel labContractSubsectorModel)
        {
            labContractSubsectorModel.MWQMPlanID = labContractSubsectorModel.MWQMPlanID;
            labContractSubsectorModel.SubsectorTVItemID = labContractSubsectorModel.SubsectorTVItemID;

            Assert.IsTrue(labContractSubsectorModel.MWQMPlanID != 0);
            Assert.IsTrue(labContractSubsectorModel.SubsectorTVItemID != 0);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            labContractSubsectorService = new MWQMPlanSubsectorService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            labContractSubsectorModelNew = new MWQMPlanSubsectorModel();
            labContractSubsector = new MWQMPlanSubsector();
            labContractServiceTest = new MWQMPlanServiceTest();
            labContractServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimMWQMPlanSubsectorService = new ShimMWQMPlanSubsectorService(labContractSubsectorService);
        }
        #endregion Functions private
    }
}

