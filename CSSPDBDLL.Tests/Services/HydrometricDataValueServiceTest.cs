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
using System.Threading;
using System.Globalization;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for HydrometricDataValueServiceTest
    /// </summary>
    [TestClass]
    public class HydrometricDataValueServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "HydrometricDataValue";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private HydrometricDataValueService hydrometricDataValueService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private HydrometricDataValueModel hydrometricDataValueModelNew { get; set; }
        private HydrometricDataValue hydrometricDataValue { get; set; }
        private ShimHydrometricDataValueService shimHydrometricDataValueService { get; set; }
        private HydrometricSiteServiceTest hydrometricSiteServiceTest { get; set; }
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
        public HydrometricDataValueServiceTest()
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
        public void HydrometricDataValueService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);

                // Act for Add
                HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);

                Assert.IsNotNull(hydrometricDataValueService);
                Assert.IsNotNull(hydrometricDataValueService.db);
                Assert.IsNotNull(hydrometricDataValueService.LanguageRequest);
                Assert.IsNotNull(hydrometricDataValueService.User);
                Assert.AreEqual(user.Identity.Name, hydrometricDataValueService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), hydrometricDataValueService.LanguageRequest);
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_HydrometricDataValueModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = hydrometricSiteServiceTest.AddHydrometricSiteModel();

                    hydrometricDataValueModelNew.HydrometricSiteID = hydrometricSiteModelRet.HydrometricSiteID;

                    #region Good
                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);

                    string retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region HydrometricSiteID
                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.HydrometricSiteID = 0;

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.HydrometricSiteID), retStr);

                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.HydrometricSiteID = 1;

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion HydrometricSiteID

                    #region DateTime_Local
                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.DateTime_Local = DateTime.UtcNow;

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.DateTime_Local = DateTime.UtcNow;
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimHydrometricDataValueService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion DateTime_Local

                    #region Keep
                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.Keep = false;

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.Keep = true;

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Keep

                    #region StorageDataType
                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.StorageDataType = (StorageDataTypeEnum)1000;

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StorageDataType), retStr);

                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.StorageDataType = StorageDataTypeEnum.Archived;

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion StorageDataType

                    #region Flow_m3_s
                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    double Min = 0D;
                    double Max = 100000D;
                    hydrometricDataValueModelNew.Flow_m3_s = Min - 1;

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Flow_m3_s, Min, Max), retStr);

                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.Flow_m3_s = Max + 1;

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Flow_m3_s, Min, Max), retStr);

                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.Flow_m3_s = Max - 1;

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.Flow_m3_s = Min;

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.Flow_m3_s = Max;

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Flow_m3_s

                    #region HourlyValues
                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.HourlyValues = "";

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual("", retStr);

                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    hydrometricDataValueModelNew.HourlyValues = randomService.RandomString("", 30);

                    retStr = hydrometricDataValueService.HydrometricDataValueModelOK(hydrometricDataValueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion HourlyValues
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_FillHydrometricDataValue_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);

                    ContactOK contactOK = hydrometricDataValueService.IsContactOK();

                    string retStr = hydrometricDataValueService.FillHydrometricDataValue(hydrometricDataValue, hydrometricDataValueModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, hydrometricDataValue.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = hydrometricDataValueService.FillHydrometricDataValue(hydrometricDataValue, hydrometricDataValueModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, hydrometricDataValue.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_GetHydrometricDataValueModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    int hydrometricDataValueCount = hydrometricDataValueService.GetHydrometricDataValueModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, hydrometricDataValueCount);
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_GetHydrometricDataValueModelWithHydrometricDataValueIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    HydrometricDataValueModel hydrometricDataValueModelRet2 = hydrometricDataValueService.GetHydrometricDataValueModelWithHydrometricDataValueIDDB(hydrometricDataValueModelRet.HydrometricDataValueID);

                    CompareHydrometricDataValueModels(hydrometricDataValueModelRet, hydrometricDataValueModelRet2);

                    int HydrometricDataValueID = 0;
                    hydrometricDataValueModelRet2 = hydrometricDataValueService.GetHydrometricDataValueModelWithHydrometricDataValueIDDB(HydrometricDataValueID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricDataValue, ServiceRes.HydrometricDataValueID, HydrometricDataValueID), hydrometricDataValueModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_GetHydrometricDataValueWithHydrometricDataValueIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    HydrometricDataValue hydrometricDataValueRet = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueIDDB(hydrometricDataValueModelRet.HydrometricDataValueID);
                    Assert.AreEqual(hydrometricDataValueModelRet.HydrometricDataValueID, hydrometricDataValueRet.HydrometricDataValueID);
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_GetHydrometricDataValueExitDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    HydrometricDataValue hydrometricDataValueRet = hydrometricDataValueService.GetHydrometricDataValueExitDB(hydrometricDataValueModelRet);
                    Assert.AreEqual(hydrometricDataValueModelRet.HydrometricDataValueID, hydrometricDataValueRet.HydrometricDataValueID);
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    HydrometricDataValueModel hydrometricDataValueModelRet = hydrometricDataValueService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, hydrometricDataValueModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostAddDeleteUpdateHydrometricDataValueDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    HydrometricDataValueModel hydrometricDataValueModelRet2 = UpdateHydrometricDataValue(hydrometricDataValueModelRet);

                    HydrometricDataValueModel hydrometricDataValueModelRet3 = hydrometricDataValueService.PostDeleteHydrometricDataValueDB(hydrometricDataValueModelRet2.HydrometricDataValueID);
                    Assert.AreEqual("", hydrometricDataValueModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostAddHydrometricDataValueDB_HydrometricDataValueModelOK_Error_Test()
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
                        shimHydrometricDataValueService.HydrometricDataValueModelOKHydrometricDataValueModel = (a) =>
                        {
                            return ErrorText;
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();
                        Assert.AreEqual(ErrorText, hydrometricDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostAddHydrometricDataValueDB_IsContactOK_Error_Test()
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
                        shimHydrometricDataValueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();
                        Assert.AreEqual(ErrorText, hydrometricDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostAddHydrometricDataValueDB_GetHydrometricDataValueExitDB_Error_Test()
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
                        shimHydrometricDataValueService.GetHydrometricDataValueExitDBHydrometricDataValueModel = (a) =>
                        {
                            return new HydrometricDataValue();
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.HydrometricDataValue), hydrometricDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostAddHydrometricDataValueDB_FillHydrometricDataValueModel_Error_Test()
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
                        shimHydrometricDataValueService.FillHydrometricDataValueHydrometricDataValueHydrometricDataValueModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();
                        Assert.AreEqual(ErrorText, hydrometricDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostAddHydrometricDataValueDB_DoAddChanges_Error_Test()
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
                        shimHydrometricDataValueService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();
                        Assert.AreEqual(ErrorText, hydrometricDataValueModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostAddHydrometricDataValueDB_Add_Error_Test()
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
                        shimHydrometricDataValueService.FillHydrometricDataValueHydrometricDataValueHydrometricDataValueModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();
                        Assert.IsTrue(hydrometricDataValueModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostDeleteHydrometricDataValueDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimHydrometricDataValueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet2 = hydrometricDataValueService.PostDeleteHydrometricDataValueDB(hydrometricDataValueModelRet.HydrometricDataValueID);
                        Assert.AreEqual(ErrorText, hydrometricDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostDeleteHydrometricDataValueDB_GetHydrometricDataValueWithHydrometricDataValueIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimHydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet2 = hydrometricDataValueService.PostDeleteHydrometricDataValueDB(hydrometricDataValueModelRet.HydrometricDataValueID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.HydrometricDataValue), hydrometricDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostDeleteHydrometricDataValueDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimHydrometricDataValueService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet2 = hydrometricDataValueService.PostDeleteHydrometricDataValueDB(hydrometricDataValueModelRet.HydrometricDataValueID);
                        Assert.AreEqual(ErrorText, hydrometricDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostUpdateHydrometricDataValueDB_HydrometricDataValueModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimHydrometricDataValueService.HydrometricDataValueModelOKHydrometricDataValueModel = (a) =>
                        {
                            return ErrorText;
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet2 = UpdateHydrometricDataValue(hydrometricDataValueModelRet);
                        Assert.AreEqual(ErrorText, hydrometricDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostUpdateHydrometricDataValueDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimHydrometricDataValueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet2 = UpdateHydrometricDataValue(hydrometricDataValueModelRet);
                        Assert.AreEqual(ErrorText, hydrometricDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostUpdateHydrometricDataValueDB_GetHydrometricDataValueWithHydrometricDataValueIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimHydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet2 = UpdateHydrometricDataValue(hydrometricDataValueModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.HydrometricDataValue), hydrometricDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostUpdateHydrometricDataValueDB_FillHydrometricDataValueModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimHydrometricDataValueService.FillHydrometricDataValueHydrometricDataValueHydrometricDataValueModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet2 = UpdateHydrometricDataValue(hydrometricDataValueModelRet);
                        Assert.AreEqual(ErrorText, hydrometricDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostUpdateHydrometricDataValueDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricDataValueModel hydrometricDataValueModelRet = AddHydrometricDataValue();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimHydrometricDataValueService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        HydrometricDataValueModel hydrometricDataValueModelRet2 = UpdateHydrometricDataValue(hydrometricDataValueModelRet);
                        Assert.AreEqual(ErrorText, hydrometricDataValueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostAddDeleteHydrometricDataValueDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = hydrometricSiteServiceTest.AddHydrometricSiteModel();

                    ContactModel contactModelBad = contactModelListBad[0];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    HydrometricSiteService hydrometricSiteServiceBad = new HydrometricSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);
                    HydrometricDataValueService hydrometricDataValueServiceBad = new HydrometricDataValueService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    HydrometricDataValueModel hydrometricDataValueModelRet = hydrometricDataValueServiceBad.PostAddHydrometricDataValueDB(hydrometricDataValueModelNew);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, hydrometricDataValueModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void HydrometricDataValueService_PostAddDeleteHydrometricDataValueDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    HydrometricSiteModel hydrometricSiteModelRet = hydrometricSiteServiceTest.AddHydrometricSiteModel();

                    SetupTest(contactModelListGood[2], culture);

                    FillHydrometricDataValueModel(hydrometricDataValueModelNew);
                    HydrometricDataValueModel hydrometricDataValueModelRet = hydrometricDataValueService.PostAddHydrometricDataValueDB(hydrometricDataValueModelNew);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, hydrometricDataValueModelRet.Error);
                }
            }
        }
        #endregion Testing Methods

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Funtions
        private HydrometricDataValueModel AddHydrometricDataValue()
        {
            HydrometricSiteModel hydrometricSiteModelRet = hydrometricSiteServiceTest.AddHydrometricSiteModel();

            HydrometricDataValueModel hydrometricDataValueModelNew = new HydrometricDataValueModel();
            FillHydrometricDataValueModel(hydrometricDataValueModelNew);

            HydrometricDataValueModel hydrometricDataValueModelRet = hydrometricDataValueService.PostAddHydrometricDataValueDB(hydrometricDataValueModelNew);
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueModelRet.Error))
            {
                return hydrometricDataValueModelRet;
            }

            Assert.IsNotNull(hydrometricDataValueModelRet);
            CompareHydrometricDataValueModels(hydrometricDataValueModelNew, hydrometricDataValueModelRet);

            return hydrometricDataValueModelRet;
        }
        private HydrometricDataValueModel UpdateHydrometricDataValue(HydrometricDataValueModel hydrometricDataValueModelRet)
        {
            FillHydrometricDataValueModel(hydrometricDataValueModelRet);

            HydrometricDataValueModel hydrometricDataValueModelRet2 = hydrometricDataValueService.PostUpdateHydrometricDataValueDB(hydrometricDataValueModelRet);
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueModelRet2.Error))
            {
                return hydrometricDataValueModelRet2;
            }

            Assert.IsNotNull(hydrometricDataValueModelRet2);
            CompareHydrometricDataValueModels(hydrometricDataValueModelRet, hydrometricDataValueModelRet2);

            return hydrometricDataValueModelRet2;
        }
        private void CompareHydrometricDataValueModels(HydrometricDataValueModel hydrometricDataValueModelNew, HydrometricDataValueModel hydrometricDataValueModelRet)
        {
            Assert.AreEqual(hydrometricDataValueModelNew.HydrometricSiteID, hydrometricDataValueModelRet.HydrometricSiteID);
            Assert.AreEqual(hydrometricDataValueModelNew.DateTime_Local, hydrometricDataValueModelRet.DateTime_Local);
            Assert.AreEqual(hydrometricDataValueModelNew.Keep, hydrometricDataValueModelRet.Keep);
            Assert.AreEqual(hydrometricDataValueModelNew.StorageDataType, StorageDataTypeEnum.Archived);
            Assert.AreEqual(hydrometricDataValueModelNew.Flow_m3_s, hydrometricDataValueModelRet.Flow_m3_s);
            Assert.AreEqual(hydrometricDataValueModelNew.HourlyValues, hydrometricDataValueModelRet.HourlyValues);
        }
        private void FillHydrometricDataValueModel(HydrometricDataValueModel hydrometricDataValueModelRet)
        {
            hydrometricDataValueModelRet.HydrometricSiteID = (hydrometricDataValueModelRet.HydrometricSiteID == 0 ? 1 : hydrometricDataValueModelRet.HydrometricSiteID);
            hydrometricDataValueModelRet.DateTime_Local = randomService.RandomDateTime();
            hydrometricDataValueModelRet.Keep = true;
            hydrometricDataValueModelRet.StorageDataType = StorageDataTypeEnum.Archived;
            hydrometricDataValueModelRet.Flow_m3_s = randomService.RandomDouble(0, 2000);
            hydrometricDataValueModelRet.HourlyValues = randomService.RandomString("", 30);

            Assert.IsTrue(hydrometricDataValueModelRet.HydrometricSiteID != 0);
            Assert.IsTrue(hydrometricDataValueModelRet.HydrometricSiteID == (hydrometricDataValueModelRet.HydrometricSiteID == 0 ? 1 : hydrometricDataValueModelRet.HydrometricSiteID));
            Assert.IsTrue(hydrometricDataValueModelRet.DateTime_Local != null);
            Assert.IsTrue(hydrometricDataValueModelRet.Keep == true);
            Assert.IsTrue(hydrometricDataValueModelRet.StorageDataType == StorageDataTypeEnum.Archived);
            Assert.IsTrue(hydrometricDataValueModelRet.Flow_m3_s >= 0 && hydrometricDataValueModelRet.Flow_m3_s <= 20000);
            Assert.IsTrue(hydrometricDataValueModelRet.HourlyValues.Length == 30);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            hydrometricDataValueService = new HydrometricDataValueService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            hydrometricDataValueModelNew = new HydrometricDataValueModel();
            hydrometricDataValue = new HydrometricDataValue();
            hydrometricSiteServiceTest = new HydrometricSiteServiceTest();
            hydrometricSiteServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimHydrometricDataValueService = new ShimHydrometricDataValueService(hydrometricDataValueService);
        }
        #endregion Functions
    }
}
