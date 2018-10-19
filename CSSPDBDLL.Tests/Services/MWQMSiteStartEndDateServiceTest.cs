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
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MWQMSiteStartEndDateServiceTest
    /// </summary>
    [TestClass]
    public class MWQMSiteStartEndDateServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MWQMSiteStartEndDate";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MWQMSiteStartEndDateService mwqmSiteStartEndDateService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelNew { get; set; }
        private MWQMSiteStartEndDate mwqmSiteStartEndDate { get; set; }
        private ShimMWQMSiteStartEndDateService shimMWQMSiteStartEndDateService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
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
        public MWQMSiteStartEndDateServiceTest()
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
        public void MWQMSiteStartEndDateService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(mwqmSiteStartEndDateService);
                Assert.IsNotNull(mwqmSiteStartEndDateService.db);
                Assert.IsNotNull(mwqmSiteStartEndDateService.LanguageRequest);
                Assert.IsNotNull(mwqmSiteStartEndDateService.User);
                Assert.AreEqual(user.Identity.Name, mwqmSiteStartEndDateService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mwqmSiteStartEndDateService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModel = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModel.Error);

                    #region Good
                    mwqmSiteStartEndDateModelNew.MWQMSiteTVItemID = mwqmSiteStartEndDateModel.MWQMSiteTVItemID;
                    FillMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelNew);

                    string retStr = mwqmSiteStartEndDateService.MWQMSiteStartEndDateModelOK(mwqmSiteStartEndDateModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region MWQMSiteTVItemID
                    FillMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelNew);
                    mwqmSiteStartEndDateModelNew.MWQMSiteTVItemID = 0;

                    retStr = mwqmSiteStartEndDateService.MWQMSiteStartEndDateModelOK(mwqmSiteStartEndDateModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID), retStr);

                    mwqmSiteStartEndDateModelNew.MWQMSiteTVItemID = mwqmSiteStartEndDateModel.MWQMSiteTVItemID;
                    FillMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelNew);

                    retStr = mwqmSiteStartEndDateService.MWQMSiteStartEndDateModelOK(mwqmSiteStartEndDateModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MWQMSiteTVItemID

                    #region StartDate
                    //DateTime? dt = null;
                    //FillMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelNew);
                    //mwqmSiteStartEndDateModelNew.StartDate = (DateTime)dt;

                    //                    //retStr = mwqmSiteStartEndDateService.MWQMSiteStartEndDateModelOK(mwqmSiteStartEndDateModelNew);

                    //                    //Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StartDate), retStr);

                    mwqmSiteStartEndDateModelNew.StartDate = mwqmSiteStartEndDateModel.StartDate;
                    FillMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelNew);

                    retStr = mwqmSiteStartEndDateService.MWQMSiteStartEndDateModelOK(mwqmSiteStartEndDateModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion StartDate

                    #region EndDate
                    FillMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelNew);
                    mwqmSiteStartEndDateModelNew.EndDate = null;

                    retStr = mwqmSiteStartEndDateService.MWQMSiteStartEndDateModelOK(mwqmSiteStartEndDateModelNew);
                    Assert.AreEqual("", retStr);

                    mwqmSiteStartEndDateModelNew.EndDate = mwqmSiteStartEndDateModel.EndDate;
                    FillMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelNew);

                    retStr = mwqmSiteStartEndDateService.MWQMSiteStartEndDateModelOK(mwqmSiteStartEndDateModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion EndDate
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_FillMWQMSiteStartEndDate_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);

                    mwqmSiteStartEndDateModelNew.MWQMSiteTVItemID = mwqmSiteStartEndDateModelRet.MWQMSiteTVItemID;
                    FillMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelNew);

                    ContactOK contactOK = mwqmSiteStartEndDateService.IsContactOK();

                    string retStr = mwqmSiteStartEndDateService.FillMWQMSiteStartEndDate(mwqmSiteStartEndDate, mwqmSiteStartEndDateModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mwqmSiteStartEndDate.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mwqmSiteStartEndDateService.FillMWQMSiteStartEndDate(mwqmSiteStartEndDate, mwqmSiteStartEndDateModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, mwqmSiteStartEndDate.LastUpdateContactTVItemID);

                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods public Get
        [TestMethod]
        public void MWQMSiteStartEndDateService_GetMWQMSiteStartEndDateModelCount_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);

                    int mwqmSiteStartEndDateCount = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, mwqmSiteStartEndDateCount);

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet2 = mwqmSiteStartEndDateService.PostDeleteMWQMSiteStartEndDateDB(mwqmSiteStartEndDateModelRet.MWQMSiteStartEndDateID);
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_GetMWQMSiteStartEndDateModelWithMWQMSiteStartEndDateIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet2 = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateModelWithMWQMSiteStartEndDateIDDB(mwqmSiteStartEndDateModelRet.MWQMSiteStartEndDateID);
                    Assert.AreEqual(mwqmSiteStartEndDateModelRet.MWQMSiteStartEndDateID, mwqmSiteStartEndDateModelRet2.MWQMSiteStartEndDateID);

                    int MWQMSiteStartEndDateID = 0;
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet3 = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateModelWithMWQMSiteStartEndDateIDDB(MWQMSiteStartEndDateID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSiteStartEndDate, ServiceRes.MWQMSiteStartEndDateID, MWQMSiteStartEndDateID), mwqmSiteStartEndDateModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_GetMWQMSiteStartEndDateModelListWithMWQMSiteTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);

                    List<MWQMSiteStartEndDateModel> mwqmSiteStartEndDateModelList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateModelListWithMWQMSiteTVItemIDDB(mwqmSiteStartEndDateModelRet.MWQMSiteTVItemID);
                    Assert.IsTrue(mwqmSiteStartEndDateModelList.Count > 0);

                    int MWQMSiteTVItemID = 0;
                    mwqmSiteStartEndDateModelList = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateModelListWithMWQMSiteTVItemIDDB(MWQMSiteTVItemID);
                    Assert.IsTrue(mwqmSiteStartEndDateModelList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);

                    MWQMSiteStartEndDate mwqmSiteStartEndDateRet = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateIDDB(mwqmSiteStartEndDateModelRet.MWQMSiteStartEndDateID);
                    Assert.AreEqual(mwqmSiteStartEndDateModelRet.MWQMSiteStartEndDateID, mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID);

                    int MWQMSiteStartEndDateID = 0;
                    MWQMSiteStartEndDate mwqmSiteStartEndDateRet2 = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateIDDB(MWQMSiteStartEndDateID);
                    Assert.IsNull(mwqmSiteStartEndDateRet2);
                }
            }
        }
        #endregion Testing Methods public Get

        #region Testing Methods public helper
        [TestMethod]
        public void MWQMSiteStartEndDateService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public helper

        #region Testing Methods public Post
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Add_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.MWQMSiteStartEndDateAddOrModifyDB(fc);
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Add_Good2_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();
                    fc["EndDateYear"] = "-1";

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.MWQMSiteStartEndDateAddOrModifyDB(fc);
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);
                    Assert.IsNull(mwqmSiteStartEndDateModelRet.EndDate);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Add_MWQMSiteTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();
                    fc["MWQMSiteTVItemID"] = "0";

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.MWQMSiteStartEndDateAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID), mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Add_StartDateYear_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();
                    fc["StartDateYear"] = "0";

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.MWQMSiteStartEndDateAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StartDateYear), mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Add_StartDateMonth_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();
                    fc["StartDateMonth"] = "0";

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.MWQMSiteStartEndDateAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StartDateMonth), mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Add_StartDateDay_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();
                    fc["StartDateDay"] = "0";

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.MWQMSiteStartEndDateAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StartDateDay), mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Add_EndDateYear_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();
                    fc["EndDateYear"] = "0";

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.MWQMSiteStartEndDateAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.EndDateYear), mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Add_EndDateMonth_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();
                    fc["EndDateMonth"] = "0";

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.MWQMSiteStartEndDateAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.EndDateMonth), mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Add_EndDateDay_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();
                    fc["EndDateDay"] = "0";

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.MWQMSiteStartEndDateAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.EndDateDay), mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Add_EndDate_not_null_and_Smaller_StartDate_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();
                    fc["EndDateYear"] = (int.Parse(fc["StartDateYear"]) - 1).ToString();

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.MWQMSiteStartEndDateAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDate, ServiceRes.EndDate), mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Add_PostAddMWQMSiteStartEndDateDB_Error_Test()
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
                        shimMWQMSiteStartEndDateService.PostAddMWQMSiteStartEndDateDBMWQMSiteStartEndDateModel = (a) =>
                        {
                            return new MWQMSiteStartEndDateModel() { Error = ErrorText };
                        };

                        FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.MWQMSiteStartEndDateAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Modify_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();

                    FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();
                    fc["MWQMSiteStartEndDateID"] = mwqmSiteStartEndDateModelRet.MWQMSiteStartEndDateID.ToString();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_MWQMSiteStartEndDateAddOrModifyDB_Modify_PostAddMWQMSiteStartEndDateDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();

                    FormCollection fc = GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB();
                    fc["MWQMSiteStartEndDateID"] = mwqmSiteStartEndDateModelRet.MWQMSiteStartEndDateID.ToString();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteStartEndDateService.PostUpdateMWQMSiteStartEndDateDBMWQMSiteStartEndDateModel = (a) =>
                        {
                            return new MWQMSiteStartEndDateModel() { Error = ErrorText };
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet2 = mwqmSiteStartEndDateService.MWQMSiteStartEndDateAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostAddMWQMSiteStartEndDateDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostAddMWQMSiteStartEndDateDB_MWQMSiteStartEndDateModelOK_Test()
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
                        shimMWQMSiteStartEndDateService.MWQMSiteStartEndDateModelOKMWQMSiteStartEndDateModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostAddMWQMSiteStartEndDateDB_IsContactOK_Error_Test()
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
                        shimMWQMSiteStartEndDateService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostAddMWQMSiteStartEndDateDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.PostAddMWQMSiteStartEndDateDB(mwqmSiteStartEndDateModelRet);
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostAddMWQMSiteStartEndDateDB_FillMWQMSiteStartEndDateModel_ErrorTest()
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
                        shimMWQMSiteStartEndDateService.FillMWQMSiteStartEndDateMWQMSiteStartEndDateMWQMSiteStartEndDateModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostAddMWQMSiteStartEndDateDB_DoAddChanges_ErrorTest()
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
                        shimMWQMSiteStartEndDateService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostAddMWQMSiteStartEndDateDB_Add_Error_Test()
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
                        shimMWQMSiteStartEndDateService.FillMWQMSiteStartEndDateMWQMSiteStartEndDateMWQMSiteStartEndDateModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                        Assert.IsTrue(mwqmSiteStartEndDateModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostDeleteMWQMSiteStartEndDateDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteStartEndDateService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet2 = mwqmSiteStartEndDateService.PostDeleteMWQMSiteStartEndDateDB(mwqmSiteStartEndDateModelRet.MWQMSiteStartEndDateID);
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostDeleteMWQMSiteStartEndDateDB_GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet2 = mwqmSiteStartEndDateService.PostDeleteMWQMSiteStartEndDateDB(mwqmSiteStartEndDateModelRet.MWQMSiteStartEndDateID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMSiteStartEndDate), mwqmSiteStartEndDateModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostDeleteMWQMSiteStartEndDateDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteStartEndDateService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet2 = mwqmSiteStartEndDateService.PostDeleteMWQMSiteStartEndDateDB(mwqmSiteStartEndDateModelRet.MWQMSiteStartEndDateID);
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostUpdateMWQMSiteStartEndDateDB_MWQMSiteStartEndDateModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteStartEndDateService.MWQMSiteStartEndDateModelOKMWQMSiteStartEndDateModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet2 = UpdateMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelRet);
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostUpdateMWQMSiteStartEndDateDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteStartEndDateService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet2 = UpdateMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelRet);
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostUpdateMWQMSiteStartEndDateDB_GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual("", mwqmSiteStartEndDateModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMWQMSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet2 = UpdateMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSiteStartEndDate), mwqmSiteStartEndDateModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostUpdateMWQMSiteStartEndDateDB_FillMWQMSiteStartEndDateModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteStartEndDateService.FillMWQMSiteStartEndDateMWQMSiteStartEndDateMWQMSiteStartEndDateModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet2 = UpdateMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelRet);
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostUpdateMWQMSiteStartEndDateDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMWQMSiteStartEndDateService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet2 = UpdateMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelRet);
                        Assert.AreEqual(ErrorText, mwqmSiteStartEndDateModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostAddMWQMSiteStartEndDateDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SetupTest(contactModelListBad[0], culture);

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MWQMSiteStartEndDateService_PostAddMWQMSiteStartEndDateDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    SetupTest(contactModelListGood[2], culture);

                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = AddMWQMSiteStartEndDateModel();
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mwqmSiteStartEndDateModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public Post

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Function
        public FormCollection GetFormCollectionForMWQMSiteStartEndDateAddOrModifyDB()
        {
            FormCollection fc = new FormCollection();
            fc.Add("MWQMSiteStartEndDateID", "0");
            fc.Add("MWQMSiteTVItemID", randomService.RandomTVItem(TVTypeEnum.MWQMSite).TVItemID.ToString());
            fc.Add("StartDateYear", "2010");
            fc.Add("StartDateMonth", "05");
            fc.Add("StartDateDay", "23");
            fc.Add("EndDateYear", "2015");
            fc.Add("EndDateMonth", "06");
            fc.Add("EndDateDay", "23");

            return fc;
        }
        public MWQMSiteStartEndDateModel AddMWQMSiteStartEndDateModel()
        {
            TVItemModel tvItemModelMWQMSite = randomService.RandomTVItem(TVTypeEnum.MWQMSite);
            Assert.IsNotNull(tvItemModelMWQMSite);

            mwqmSiteStartEndDateModelNew.MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID;
            FillMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModelNew);

            MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = mwqmSiteStartEndDateService.PostAddMWQMSiteStartEndDateDB(mwqmSiteStartEndDateModelNew);
            if (!string.IsNullOrWhiteSpace(mwqmSiteStartEndDateModelRet.Error))
            {
                return mwqmSiteStartEndDateModelRet;
            }

            CompareMWQMSiteStartEndDateModels(mwqmSiteStartEndDateModelNew, mwqmSiteStartEndDateModelRet);

            return mwqmSiteStartEndDateModelRet;

        }
        public MWQMSiteStartEndDateModel UpdateMWQMSiteStartEndDateModel(MWQMSiteStartEndDateModel mwqmSiteStartEndDateModel)
        {
            FillMWQMSiteStartEndDateModel(mwqmSiteStartEndDateModel);

            MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet2 = mwqmSiteStartEndDateService.PostUpdateMWQMSiteStartEndDateDB(mwqmSiteStartEndDateModel);
            if (!string.IsNullOrWhiteSpace(mwqmSiteStartEndDateModelRet2.Error))
            {
                return mwqmSiteStartEndDateModelRet2;
            }

            CompareMWQMSiteStartEndDateModels(mwqmSiteStartEndDateModel, mwqmSiteStartEndDateModelRet2);

            return mwqmSiteStartEndDateModelRet2;
        }
        private void CompareMWQMSiteStartEndDateModels(MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelNew, MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet)
        {
            Assert.AreEqual(mwqmSiteStartEndDateModelNew.MWQMSiteTVItemID, mwqmSiteStartEndDateModelRet.MWQMSiteTVItemID);
            Assert.AreEqual(mwqmSiteStartEndDateModelNew.StartDate, mwqmSiteStartEndDateModelRet.StartDate);
            Assert.AreEqual(mwqmSiteStartEndDateModelNew.EndDate, mwqmSiteStartEndDateModelRet.EndDate);
        }
        private void FillMWQMSiteStartEndDateModel(MWQMSiteStartEndDateModel mwqmSiteStartEndDateModel)
        {
            mwqmSiteStartEndDateModel.MWQMSiteTVItemID = mwqmSiteStartEndDateModel.MWQMSiteTVItemID;
            mwqmSiteStartEndDateModel.StartDate = randomService.RandomDateTime();
            mwqmSiteStartEndDateModel.EndDate = mwqmSiteStartEndDateModel.StartDate.AddYears(3);
            Assert.IsTrue(mwqmSiteStartEndDateModel.MWQMSiteTVItemID != 0);
            Assert.IsTrue(mwqmSiteStartEndDateModel.StartDate != null);
            Assert.IsTrue(mwqmSiteStartEndDateModel.EndDate != null);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmSiteStartEndDateModelNew = new MWQMSiteStartEndDateModel();
            mwqmSiteStartEndDate = new MWQMSiteStartEndDate();
        }
        private void SetupShim()
        {
            shimMWQMSiteStartEndDateService = new ShimMWQMSiteStartEndDateService(mwqmSiteStartEndDateService);
            shimTVItemService = new ShimTVItemService(mwqmSiteStartEndDateService._TVItemService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(mwqmSiteStartEndDateService._TVItemService._TVItemLanguageService);
        }
        #endregion Functions private
    }


}

