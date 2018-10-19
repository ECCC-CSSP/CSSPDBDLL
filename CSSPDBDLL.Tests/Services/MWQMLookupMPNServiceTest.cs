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
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MWQMLookupMPNServiceTest
    /// </summary>
    [TestClass]
    public class MWQMLookupMPNServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MWQMLookupMPN";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MWQMLookupMPNService mwqmLookupMPNService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MWQMLookupMPNModel mwqmLookupMPNModelNew { get; set; }
        private MWQMLookupMPN mwqmLookupMPN { get; set; }
        private ShimMWQMLookupMPNService shimMWQMLookupMPNService { get; set; }
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
        public MWQMLookupMPNServiceTest()
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
        public void MWQMLookupMPNService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // in Arrange
                Assert.IsNotNull(mwqmLookupMPNService);
                Assert.IsNotNull(mwqmLookupMPNService.db);
                Assert.IsNotNull(mwqmLookupMPNService.LanguageRequest);
                Assert.IsNotNull(mwqmLookupMPNService.User);
                Assert.AreEqual(user.Identity.Name, mwqmLookupMPNService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mwqmLookupMPNService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_MWQMLookupMPNModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                #region Good
                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);

                string retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);
                #endregion Good

                #region Tubes01
                int Min = 0;
                int Max = 5;

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes01 = Min - 1;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Tubes01, Min, Max), retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes01 = Max + 1;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Tubes01, Min, Max), retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes01 = Max - 1;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes01 = Max;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes01 = Min;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);
                #endregion Tubes01

                #region Tubes1
                Min = 0;
                Max = 5;

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes1 = Min - 1;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Tubes1, Min, Max), retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes1 = Max + 1;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Tubes1, Min, Max), retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes1 = Max - 1;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes1 = Max;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes1 = Min;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);
                #endregion Tubes1

                #region Tubes10
                Min = 0;
                Max = 5;

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes10 = Min - 1;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Tubes10, Min, Max), retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes10 = Max + 1;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Tubes10, Min, Max), retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes10 = Max - 1;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes10 = Max;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.Tubes10 = Min;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);
                #endregion Tubes10

                #region MPN_100ml
                Min = 0;
                Max = 1700;

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.MPN_100ml = Min - 1;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MPN_100ml, Min, Max), retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.MPN_100ml = Max + 1;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.MPN_100ml, Min, Max), retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.MPN_100ml = Max - 1;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.MPN_100ml = Max;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);

                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);
                mwqmLookupMPNModelNew.MPN_100ml = Min;

                retStr = mwqmLookupMPNService.MWQMLookupMPNModelOK(mwqmLookupMPNModelNew);
                Assert.AreEqual("", retStr);
                #endregion MPN_100ml

            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_FillMWQMLookupMPN_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);

                    ContactOK contactOK = mwqmLookupMPNService.IsContactOK();

                    string retStr = mwqmLookupMPNService.FillMWQMLookupMPN(mwqmLookupMPN, mwqmLookupMPNModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mwqmLookupMPN.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mwqmLookupMPNService.FillMWQMLookupMPN(mwqmLookupMPN, mwqmLookupMPNModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, mwqmLookupMPN.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_GetMWQMLookupMPNModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    int mwqmLookupMPNCount = mwqmLookupMPNService.GetMWQMLookupMPNModelCountDB();
                    Assert.AreEqual(1, mwqmLookupMPNCount);
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_GetMWQMLookupMPNModelWithMWQMLookupMPNIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNMode4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNMode4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    MWQMLookupMPNModel mwqmLookupMPNModelRet2 = mwqmLookupMPNService.GetMWQMLookupMPNModelWithMWQMLookupMPNIDDB(mwqmLookupMPNModelRet.MWQMLookupMPNID);
                    Assert.AreEqual(mwqmLookupMPNModelRet.MWQMLookupMPNID, mwqmLookupMPNModelRet2.MWQMLookupMPNID);

                    int MWQMLookupMPNID = 0;
                    mwqmLookupMPNModelRet2 = mwqmLookupMPNService.GetMWQMLookupMPNModelWithMWQMLookupMPNIDDB(MWQMLookupMPNID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMLookupMPN, ServiceRes.MWQMLookupMPNID, MWQMLookupMPNID), mwqmLookupMPNModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_GetMWQMLookupMPNWithMWQMLookupMPNIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    MWQMLookupMPN mwqmLookupMPN = mwqmLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNIDDB(mwqmLookupMPNModelRet.MWQMLookupMPNID);
                    Assert.AreEqual(mwqmLookupMPNModelRet.MWQMLookupMPNID, mwqmLookupMPN.MWQMLookupMPNID);

                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_GetMWQMLookupMPNExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    MWQMLookupMPN mwqmLookupMPN = mwqmLookupMPNService.GetMWQMLookupMPNExistDB(mwqmLookupMPNModelRet.Tubes10, mwqmLookupMPNModelRet.Tubes1, mwqmLookupMPNModelRet.Tubes01, mwqmLookupMPNModelRet.MPN_100ml);
                    Assert.AreEqual(mwqmLookupMPNModelRet.MWQMLookupMPNID, mwqmLookupMPN.MWQMLookupMPNID);

                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MWQMLookupMPNModel mwqmLookupMPNModelRet = mwqmLookupMPNService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, mwqmLookupMPNModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostAddUpdateDeleteMWQMLookupMPN_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    MWQMLookupMPNModel mwqmLookupMPNModelRet2 = UpdateMWQMLookupMPNModel(mwqmLookupMPNModelRet);

                    MWQMLookupMPNModel mwqmLookupMPNModelRet3 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModelRet2.MWQMLookupMPNID);
                    Assert.AreEqual("", mwqmLookupMPNModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostAddDeleteUpdateMWQMLookupMPN_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = mwqmLookupMPNService.PostAddMWQMLookupMPNDB(mwqmLookupMPNModelNew);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mwqmLookupMPNModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostAddDeleteUpdateMWQMLookupMPN_UserMWQMLookupMPNNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = mwqmLookupMPNService.PostAddMWQMLookupMPNDB(mwqmLookupMPNModelNew);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mwqmLookupMPNModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostAddMWQMLookupMPN_MWQMLookupMPNModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.MWQMLookupMPNModelOKMWQMLookupMPNModel = (a) =>
                        {
                            return ErrorText;
                        };

                        FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);

                        MWQMLookupMPNModel mwqmLookupMPNModelRet = mwqmLookupMPNService.PostAddMWQMLookupMPNDB(mwqmLookupMPNModelNew);
                        Assert.AreEqual(ErrorText, mwqmLookupMPNModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostAddMWQMLookupMPN_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);

                        MWQMLookupMPNModel mwqmLookupMPNModelRet = mwqmLookupMPNService.PostAddMWQMLookupMPNDB(mwqmLookupMPNModelNew);
                        Assert.AreEqual(ErrorText, mwqmLookupMPNModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostAddMWQMLookupMPN_GetMWQMLookupMPNExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.GetMWQMLookupMPNExistDBInt32Int32Int32Int32 = (a, b, c, d) =>
                        {
                            return new MWQMLookupMPN();
                        };

                        FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);

                        MWQMLookupMPNModel mwqmLookupMPNModelRet = mwqmLookupMPNService.PostAddMWQMLookupMPNDB(mwqmLookupMPNModelNew);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMLookupMPN), mwqmLookupMPNModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostAddMWQMLookupMPN_FillMWQMLookupMPNModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.FillMWQMLookupMPNMWQMLookupMPNMWQMLookupMPNModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);

                        MWQMLookupMPNModel mwqmLookupMPNModelRet = mwqmLookupMPNService.PostAddMWQMLookupMPNDB(mwqmLookupMPNModelNew);

                        Assert.AreEqual(ErrorText, mwqmLookupMPNModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostAddMWQMLookupMPN_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);

                        MWQMLookupMPNModel mwqmLookupMPNModelRet = mwqmLookupMPNService.PostAddMWQMLookupMPNDB(mwqmLookupMPNModelNew);

                        Assert.AreEqual(ErrorText, mwqmLookupMPNModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostAddMWQMLookupMPN_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.FillMWQMLookupMPNMWQMLookupMPNMWQMLookupMPNModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MWQMLookupMPNModel mwqmLookupMPNModelRet = mwqmLookupMPNService.PostAddMWQMLookupMPNDB(mwqmLookupMPNModelNew);
                        Assert.IsTrue(mwqmLookupMPNModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostDeleteMWQMLookupMPN_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMLookupMPNModel mwqmLookupMPNModelRet2 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModelRet.MWQMLookupMPNID);
                        Assert.AreEqual(ErrorText, mwqmLookupMPNModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostDeleteMWQMLookupMPN_GetMWQMLookupMPNWithMWQMLookupMPNIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMLookupMPNModel mwqmLookupMPNModelRet2 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModelRet.MWQMLookupMPNID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMLookupMPN), mwqmLookupMPNModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostDeleteMWQMLookupMPN_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMLookupMPNModel mwqmLookupMPNModelRet2 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModelRet.MWQMLookupMPNID);
                        Assert.AreEqual(ErrorText, mwqmLookupMPNModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostUpdateMWQMLookupMPN_MWQMLookupMPNModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.MWQMLookupMPNModelOKMWQMLookupMPNModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMLookupMPNModel mwqmLookupMPNModelRet2 = UpdateMWQMLookupMPNModel(mwqmLookupMPNModelRet);
                        Assert.AreEqual(ErrorText, mwqmLookupMPNModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostUpdateMWQMLookupMPN_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMLookupMPNModel mwqmLookupMPNModelRet2 = UpdateMWQMLookupMPNModel(mwqmLookupMPNModelRet);
                        Assert.AreEqual(ErrorText, mwqmLookupMPNModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostUpdateMWQMLookupMPN_GetMWQMLookupMPNWithMWQMLookupMPNIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMLookupMPNModel mwqmLookupMPNModelRet2 = UpdateMWQMLookupMPNModel(mwqmLookupMPNModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMLookupMPN), mwqmLookupMPNModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostUpdateMWQMLookupMPN_FillMWQMLookupMPNModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.FillMWQMLookupMPNMWQMLookupMPNMWQMLookupMPNModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMLookupMPNModel mwqmLookupMPNModelRet2 = UpdateMWQMLookupMPNModel(mwqmLookupMPNModelRet);
                        Assert.AreEqual(ErrorText, mwqmLookupMPNModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMLookupMPNService_PostUpdateMWQMLookupMPN_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<MWQMLookupMPNModel> mwqmLookupMPNModelList = mwqmLookupMPNService.GetMWQMLookupMPNModelListDB();
                    foreach (MWQMLookupMPNModel mwqmLookupMPNModel in mwqmLookupMPNModelList)
                    {
                        MWQMLookupMPNModel mwqmLookupMPNModelRet4 = mwqmLookupMPNService.PostDeleteMWQMLookupMPNDB(mwqmLookupMPNModel.MWQMLookupMPNID);
                        Assert.AreEqual("", mwqmLookupMPNModelRet4.Error);
                    }

                    MWQMLookupMPNModel mwqmLookupMPNModelRet = AddMWQMLookupMPNModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMWQMLookupMPNService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMLookupMPNModel mwqmLookupMPNModelRet2 = UpdateMWQMLookupMPNModel(mwqmLookupMPNModelRet);
                        Assert.AreEqual(ErrorText, mwqmLookupMPNModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public MWQMLookupMPNModel AddMWQMLookupMPNModel()
        {
            MWQMLookupMPNModel mwqmLookupMPNModelRet = new MWQMLookupMPNModel();
            for (int i = 0; i < 50; i++)
            {
                FillMWQMLookupMPNModel(mwqmLookupMPNModelNew);

                mwqmLookupMPNModelRet = mwqmLookupMPNService.PostAddMWQMLookupMPNDB(mwqmLookupMPNModelNew);
                if (string.IsNullOrWhiteSpace(mwqmLookupMPNModelRet.Error))
                {
                    break;
                }
            }

            CompareMWQMLookupMPNModels(mwqmLookupMPNModelNew, mwqmLookupMPNModelRet);

            return mwqmLookupMPNModelRet;
        }
        public MWQMLookupMPNModel UpdateMWQMLookupMPNModel(MWQMLookupMPNModel mwqmLookupMPNModel)
        {
            FillMWQMLookupMPNModel(mwqmLookupMPNModel);

            MWQMLookupMPNModel mwqmLookupMPNModelRet2 = mwqmLookupMPNService.PostUpdateMWQMLookupMPNDB(mwqmLookupMPNModel);
            if (!string.IsNullOrWhiteSpace(mwqmLookupMPNModelRet2.Error))
            {
                return mwqmLookupMPNModelRet2;
            }

            CompareMWQMLookupMPNModels(mwqmLookupMPNModel, mwqmLookupMPNModelRet2);

            return mwqmLookupMPNModelRet2;
        }
        private void CompareMWQMLookupMPNModels(MWQMLookupMPNModel mwqmLookupMPNModelNew, MWQMLookupMPNModel mwqmLookupMPNModelRet)
        {
            Assert.AreEqual(mwqmLookupMPNModelNew.Tubes01, mwqmLookupMPNModelRet.Tubes01);
            Assert.AreEqual(mwqmLookupMPNModelNew.Tubes1, mwqmLookupMPNModelRet.Tubes1);
            Assert.AreEqual(mwqmLookupMPNModelNew.Tubes10, mwqmLookupMPNModelRet.Tubes10);
            Assert.AreEqual(mwqmLookupMPNModelNew.MPN_100ml, mwqmLookupMPNModelRet.MPN_100ml);
        }
        private void FillMWQMLookupMPNModel(MWQMLookupMPNModel mwqmLookupMPNModel)
        {
            mwqmLookupMPNModel.Tubes01 = randomService.RandomInt(0, 5);
            mwqmLookupMPNModel.Tubes1 = randomService.RandomInt(0, 5);
            mwqmLookupMPNModel.Tubes10 = randomService.RandomInt(0, 5);
            mwqmLookupMPNModel.MPN_100ml = randomService.RandomInt(0, 1700);

            Assert.IsTrue(mwqmLookupMPNModel.Tubes01 >= 0 && mwqmLookupMPNModel.Tubes01 <= 5);
            Assert.IsTrue(mwqmLookupMPNModel.Tubes1 >= 0 && mwqmLookupMPNModel.Tubes1 <= 5);
            Assert.IsTrue(mwqmLookupMPNModel.Tubes10 >= 0 && mwqmLookupMPNModel.Tubes10 <= 5);
            Assert.IsTrue(mwqmLookupMPNModel.MPN_100ml >= 0 && mwqmLookupMPNModel.MPN_100ml <= 1700);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mwqmLookupMPNService = new MWQMLookupMPNService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmLookupMPNModelNew = new MWQMLookupMPNModel();
            mwqmLookupMPN = new MWQMLookupMPN();
        }
        private void SetupShim()
        {
            shimMWQMLookupMPNService = new ShimMWQMLookupMPNService(mwqmLookupMPNService);
        }
        #endregion Functions private
    }
}

