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
    /// Summary description for TideDataValueServiceTest
    /// </summary>
    [TestClass]
    public class TideDataValueServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "TideDataValue";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private TideDataValueService tideDataValueService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private TideDataValueModel tideDataValueModelNew { get; set; }
        private TideDataValue tideDataValue { get; set; }
        private ShimTideDataValueService shimTideDataValueService { get; set; }
        private TideSiteServiceTest tideSiteServiceTest { get; set; }
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
        public TideDataValueServiceTest()
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
        public void TideDataValueService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(tideDataValueService);
                Assert.IsNotNull(tideDataValueService.db);
                Assert.IsNotNull(tideDataValueService.LanguageRequest);
                Assert.IsNotNull(tideDataValueService.User);
                Assert.AreEqual(user.Identity.Name, tideDataValueService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), tideDataValueService.LanguageRequest);
            }
        }
        [TestMethod]
        public void TideDataValueService_TideDataValueModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();
                    Assert.AreEqual("", tideDataValueModelRet.Error);

                    #region Good
                    tideDataValueModelNew.TideSiteTVItemID = tideDataValueModelRet.TideSiteTVItemID;
                    FillTideDataValueModel(tideDataValueModelNew);

                    string retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region TideSiteTVItemID
                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.TideSiteTVItemID = 0;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TideSiteTVItemID), retStr);

                    tideDataValueModelNew.TideSiteTVItemID = tideDataValueModelRet.TideSiteTVItemID;
                    FillTideDataValueModel(tideDataValueModelNew);

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TideSiteTVItemID

                    #region TideDataDateTime_Local
                    FillTideDataValueModel(tideDataValueModelNew);
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTideDataValueService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        tideDataValueModelNew.DateTime_Local = DateTime.Now;
                        retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion TideDataDateTime_Local

                    #region Keep
                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.Keep = false;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.Keep = true;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Keep

                    #region TideDataType
                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.TideDataType = (TideDataTypeEnum)1000;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TideDataType), retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.TideDataType = TideDataTypeEnum.Min60;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TideDataType

                    #region StorageDataType
                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.StorageDataType = (StorageDataTypeEnum)1000;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StorageDataType), retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.StorageDataType = StorageDataTypeEnum.Archived;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion StorageDataType

                    #region Depth_m
                    FillTideDataValueModel(tideDataValueModelNew);
                    double Min = -10D;
                    double Max = 10D;
                    tideDataValueModelNew.Depth_m = Min - 1;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Depth_m, Min, Max), retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.Depth_m = Max + 1;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Depth_m, Min, Max), retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.Depth_m = Max - 1;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.Depth_m = Min;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.Depth_m = Max;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Depth_m

                    #region UVelocity_m_s
                    FillTideDataValueModel(tideDataValueModelNew);
                    Min = -10D;
                    Max = 10D;
                    tideDataValueModelNew.UVelocity_m_s = Min - 1;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.UVelocity_m_s, Min, Max), retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.UVelocity_m_s = Max + 1;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.UVelocity_m_s, Min, Max), retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.UVelocity_m_s = Max - 1;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.UVelocity_m_s = Min;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.UVelocity_m_s = Max;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion UVelocity_m_s

                    #region VVelocity_m_s
                    FillTideDataValueModel(tideDataValueModelNew);
                    Min = -10D;
                    Max = 10D;
                    tideDataValueModelNew.VVelocity_m_s = Min - 1;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.VVelocity_m_s, Min, Max), retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.VVelocity_m_s = Max + 1;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.VVelocity_m_s, Min, Max), retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.VVelocity_m_s = Max - 1;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.VVelocity_m_s = Min;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillTideDataValueModel(tideDataValueModelNew);
                    tideDataValueModelNew.VVelocity_m_s = Max;

                    retStr = tideDataValueService.TideDataValueModelOK(tideDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion VVelocity_m_s
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_FillTideDataValue_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = tideSiteServiceTest.AddTideSiteModel();

                    tideDataValueModelNew.TideSiteTVItemID = tideSiteModelRet.TideSiteTVItemID;

                    FillTideDataValueModel(tideDataValueModelNew);

                    ContactOK contactOK = tideDataValueService.IsContactOK();

                    string retStr = tideDataValueService.FillTideDataValue(tideDataValue, tideDataValueModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, tideDataValue.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = tideDataValueService.FillTideDataValue(tideDataValue, tideDataValueModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, tideDataValue.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void TideDataValueService_GetTideDataValueModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    int tideDataValueCount = tideDataValueService.GetTideDataValueModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, tideDataValueCount);
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_GetTideDataValueModelWithTideDataValueIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    TideDataValueModel tideDataValueModelRet2 = tideDataValueService.GetTideDataValueModelWithTideDataValueIDDB(tideDataValueModelRet.TideDataValueID);

                    CompareTideDataValueModels(tideDataValueModelRet, tideDataValueModelRet2);

                    int TideDataValueID = 0;
                    TideDataValueModel tideDataValueModelRet3 = tideDataValueService.GetTideDataValueModelWithTideDataValueIDDB(TideDataValueID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TideDataValue, ServiceRes.TideDataValueID, TideDataValueID), tideDataValueModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void TideDataValueService_GetTideDataValueModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    TideDataValueModel tideDataValueModelRet2 = tideDataValueService.GetTideDataValueModelExistDB(tideDataValueModelRet);

                    CompareTideDataValueModels(tideDataValueModelRet, tideDataValueModelRet2);

                    tideDataValueModelRet2.TideSiteTVItemID = 0;
                    TideDataValueModel tideDataValueModelRet3 = tideDataValueService.GetTideDataValueModelExistDB(tideDataValueModelRet2);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TideDataValue, ServiceRes.TideSiteTVItemID + "," + ServiceRes.DateTime_Local, tideDataValueModelRet2.TideSiteTVItemID + "," + tideDataValueModelRet2.DateTime_Local), tideDataValueModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_GetTideDataValueWithTideDataValueIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    TideDataValue tideDataValueRet = tideDataValueService.GetTideDataValueWithTideDataValueIDDB(tideDataValueModelRet.TideDataValueID);
                    Assert.AreEqual(tideDataValueModelRet.TideDataValueID, tideDataValueRet.TideDataValueID);
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    TideDataValueModel tideDataValueModelRet = tideDataValueService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, tideDataValueModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostAddUpdateDeleteTideDataValueDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    TideDataValueModel tideDataValueModelRet2 = UpdateTideDataValue(tideDataValueModelRet);

                    TideDataValueModel tideDataValueModelRet3 = tideDataValueService.PostDeleteTideDataValueDB(tideDataValueModelRet2.TideDataValueID);
                    Assert.AreEqual("", tideDataValueModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostAddTideDataValueDB_TideDataValueModelOK_Error_Test()
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
                        shimTideDataValueService.TideDataValueModelOKTideDataValueModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TideDataValueModel tideDataValueModelRet = AddTideDataValue();
                        Assert.AreEqual(ErrorText, tideDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostAddTideDataValueDB_IsContactOK_Error_Test()
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
                        shimTideDataValueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TideDataValueModel tideDataValueModelRet = AddTideDataValue();
                        Assert.AreEqual(ErrorText, tideDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostAddTideDataValueDB_GetTideDataValueModelExistDB_Error_Test()
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
                        shimTideDataValueService.GetTideDataValueModelExistDBTideDataValueModel = (a) =>
                        {
                            return new TideDataValueModel() { Error = "" };
                        };

                        TideDataValueModel tideDataValueModelRet = AddTideDataValue();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TideDataValue), tideDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostAddTideDataValueDB_FillTideDataValueModel_Error_Test()
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
                        shimTideDataValueService.FillTideDataValueTideDataValueTideDataValueModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TideDataValueModel tideDataValueModelRet = AddTideDataValue();
                        Assert.AreEqual(ErrorText, tideDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostAddTideDataValueDB_DoAddChanges_Error_Test()
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
                        shimTideDataValueService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        TideDataValueModel tideDataValueModelRet = AddTideDataValue();
                        Assert.AreEqual(ErrorText, tideDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostAddTideDataValueDB_Add_Error_Test()
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
                        shimTideDataValueService.FillTideDataValueTideDataValueTideDataValueModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        TideDataValueModel tideDataValueModelRet = AddTideDataValue();
                        Assert.IsTrue(tideDataValueModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostDeleteTideDataValueDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTideDataValueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TideDataValueModel tideDataValueModelRet2 = tideDataValueService.PostDeleteTideDataValueDB(tideDataValueModelRet.TideDataValueID);
                        Assert.AreEqual(ErrorText, tideDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostDeleteTideDataValueDB_GetTideDataValueWithTideDataValueIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTideDataValueService.GetTideDataValueWithTideDataValueIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TideDataValueModel tideDataValueModelRet2 = tideDataValueService.PostDeleteTideDataValueDB(tideDataValueModelRet.TideDataValueID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TideDataValue), tideDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostDeleteTideDataValueDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTideDataValueService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TideDataValueModel tideDataValueModelRet2 = tideDataValueService.PostDeleteTideDataValueDB(tideDataValueModelRet.TideDataValueID);
                        Assert.AreEqual(ErrorText, tideDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostUpdateTideDataValueDB_TideDataValueModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTideDataValueService.TideDataValueModelOKTideDataValueModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TideDataValueModel tideDataValueModelRet2 = UpdateTideDataValue(tideDataValueModelRet);
                        Assert.AreEqual(ErrorText, tideDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostUpdateTideDataValueDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTideDataValueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TideDataValueModel tideDataValueModelRet2 = UpdateTideDataValue(tideDataValueModelRet);
                        Assert.AreEqual(ErrorText, tideDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostUpdateTideDataValueDB_GetTideDataValueWithTideDataValueIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTideDataValueService.GetTideDataValueWithTideDataValueIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TideDataValueModel tideDataValueModelRet2 = UpdateTideDataValue(tideDataValueModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TideDataValue), tideDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostUpdateTideDataValueDB_FillTideDataValueModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTideDataValueService.FillTideDataValueTideDataValueTideDataValueModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TideDataValueModel tideDataValueModelRet2 = UpdateTideDataValue(tideDataValueModelRet);
                        Assert.AreEqual(ErrorText, tideDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostUpdateTideDataValueDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideDataValueModel tideDataValueModelRet = AddTideDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTideDataValueService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TideDataValueModel tideDataValueModelRet2 = UpdateTideDataValue(tideDataValueModelRet);
                        Assert.AreEqual(ErrorText, tideDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostAddTideDataValueDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = tideSiteServiceTest.AddTideSiteModel();

                    SetupTest(contactModelListBad[0], culture);

                    tideDataValueModelNew.TideSiteTVItemID = tideSiteModelRet.TideSiteTVItemID;

                    FillTideDataValueModel(tideDataValueModelNew);

                    TideDataValueModel tideDataValueModelRet2 = tideDataValueService.PostAddTideDataValueDB(tideDataValueModelNew);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, tideDataValueModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TideDataValueService_PostAddDeleteTideDataValueDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TideSiteModel tideSiteModelRet = tideSiteServiceTest.AddTideSiteModel();

                    SetupTest(contactModelListGood[2], culture);

                    tideDataValueModelNew.TideSiteTVItemID = tideSiteModelRet.TideSiteTVItemID;

                    FillTideDataValueModel(tideDataValueModelNew);

                    TideDataValueModel tideDataValueModelRet2 = tideDataValueService.PostAddTideDataValueDB(tideDataValueModelNew);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, tideDataValueModelRet2.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Funtions
        private TideDataValueModel AddTideDataValue()
        {
            TideSiteModel tideDataStartDateModelRet = tideSiteServiceTest.AddTideSiteModel();

            tideDataValueModelNew.TideSiteTVItemID = tideDataStartDateModelRet.TideSiteTVItemID;
            FillTideDataValueModel(tideDataValueModelNew);

            TideDataValueModel tideDataValueModelRet = tideDataValueService.PostAddTideDataValueDB(tideDataValueModelNew);
            if (!string.IsNullOrWhiteSpace(tideDataValueModelRet.Error))
            {
                return tideDataValueModelRet;
            }

            Assert.IsNotNull(tideDataValueModelRet);
            CompareTideDataValueModels(tideDataValueModelNew, tideDataValueModelRet);

            return tideDataValueModelRet;
        }
        private TideDataValueModel UpdateTideDataValue(TideDataValueModel tideDataValueModelRet)
        {
            FillTideDataValueModel(tideDataValueModelRet);

            TideDataValueModel tideDataValueModelRet2 = tideDataValueService.PostUpdateTideDataValueDB(tideDataValueModelRet);
            if (!string.IsNullOrWhiteSpace(tideDataValueModelRet2.Error))
            {
                return tideDataValueModelRet2;
            }

            Assert.IsNotNull(tideDataValueModelRet2);
            CompareTideDataValueModels(tideDataValueModelRet, tideDataValueModelRet2);

            return tideDataValueModelRet2;
        }
        private void CompareTideDataValueModels(TideDataValueModel tideDataValueModelNew, TideDataValueModel tideDataValueModelRet)
        {
            Assert.AreEqual(tideDataValueModelNew.TideSiteTVItemID, tideDataValueModelRet.TideSiteTVItemID);
            Assert.AreEqual(tideDataValueModelNew.DateTime_Local, tideDataValueModelRet.DateTime_Local);
            Assert.AreEqual(tideDataValueModelNew.Keep, tideDataValueModelRet.Keep);
            Assert.AreEqual(tideDataValueModelNew.TideDataType, tideDataValueModelRet.TideDataType);
            Assert.AreEqual(tideDataValueModelNew.StorageDataType, tideDataValueModelRet.StorageDataType);
            Assert.AreEqual(tideDataValueModelNew.Depth_m, tideDataValueModelRet.Depth_m);
            Assert.AreEqual(tideDataValueModelNew.UVelocity_m_s, tideDataValueModelRet.UVelocity_m_s);
            Assert.AreEqual(tideDataValueModelNew.VVelocity_m_s, tideDataValueModelRet.VVelocity_m_s);
        }
        private void FillTideDataValueModel(TideDataValueModel tideDataValueModelRet)
        {
            tideDataValueModelRet.TideSiteTVItemID = tideDataValueModelRet.TideSiteTVItemID;
            tideDataValueModelRet.DateTime_Local = randomService.RandomDateTime();
            tideDataValueModelRet.Keep = true;
            tideDataValueModelRet.TideDataType = TideDataTypeEnum.Min60;
            tideDataValueModelRet.StorageDataType = StorageDataTypeEnum.Archived;
            tideDataValueModelRet.Depth_m = randomService.RandomDouble(-10, 10);
            tideDataValueModelRet.UVelocity_m_s = randomService.RandomDouble(-10, 10);
            tideDataValueModelRet.VVelocity_m_s = randomService.RandomDouble(-10, 10);

            Assert.IsTrue(tideDataValueModelRet.TideSiteTVItemID != 0);
            Assert.IsTrue(tideDataValueModelRet.DateTime_Local != null);
            Assert.IsTrue(tideDataValueModelRet.Keep == true);
            Assert.IsTrue(tideDataValueModelRet.TideDataType == TideDataTypeEnum.Min60);
            Assert.IsTrue(tideDataValueModelRet.StorageDataType == StorageDataTypeEnum.Archived);
            Assert.IsTrue(tideDataValueModelRet.Depth_m >= -10 && tideDataValueModelRet.Depth_m <= 10);
            Assert.IsTrue(tideDataValueModelRet.UVelocity_m_s >= -10 && tideDataValueModelRet.UVelocity_m_s <= 10);
            Assert.IsTrue(tideDataValueModelRet.VVelocity_m_s >= -10 && tideDataValueModelRet.VVelocity_m_s <= 10);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            tideDataValueService = new TideDataValueService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tideDataValueModelNew = new TideDataValueModel();
            tideDataValue = new TideDataValue();
            tideSiteServiceTest = new TideSiteServiceTest();
            tideSiteServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimTideDataValueService = new ShimTideDataValueService(tideDataValueService);
        }
        #endregion Functions
    }
}
