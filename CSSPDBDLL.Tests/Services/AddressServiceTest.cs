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
using System.Threading;
using System.Globalization;
using CSSPWebToolsDBDLL.Models.Fakes;
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;
using System.Reflection;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for AddressServiceTest
    /// </summary>
    [TestClass]
    public class AddressServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance { get; set; }
        private SetupData setupData;
        private string TableName = "Address";
        private string Plurial = "es";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private AddressService addressService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private AddressModel addressModelNew { get; set; }
        private Address address { get; set; }
        private MapInfoService mapInfoService { get; set; }
        private ShimAddressService shimAddressService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLinkService shimTVItemLinkService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
        private ShimInfrastructureService shimInfrastructureService { get; set; }
        private ShimMapInfoService shimMapInfoService { get; set; }
        private ShimMapInfoPointService shimMapInfoPointService { get; set; }
        private TVItemService tvItemService { get; set; }
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
        public AddressServiceTest()
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
        //[TestInitialize()]
        //public void MyTestInitialize() {}
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion Initialize and Cleanup

        #region Testing Methods Public
        [TestMethod]
        public void testing_FieldName_with_Refelection_Test()
        {
            Address address = new Address()
            {
                AddressID = 45,
                AddressType = (int)AddressTypeEnum.Civic,
                StreetName = "TheStreetName",
                StreetNumber = "23487",
                StreetType = (int)StreetTypeEnum.Road,
                CountryTVItemID = 4,
                ProvinceTVItemID = 5,
                MunicipalityTVItemID = 7
            };
            foreach (MemberInfo memberInfo in address.GetType().GetMembers())
            {
                Console.Write(memberInfo.Name);
            } 
        }
        [TestMethod]
        public void AddressService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(addressService._TVItemService);
                Assert.IsNotNull(addressService.db);
                Assert.IsNotNull(addressService.LanguageRequest);
                Assert.IsNotNull(addressService.User);
                Assert.AreEqual(user.Identity.Name, addressService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), addressService.LanguageRequest);
            }
        }
        [TestMethod]
        public void AddressService_AddressModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModel = AddAddressModel();
                    Assert.AreEqual("", addressModel.Error);

                    #region Good
                    addressModelNew.AddressTVItemID = addressModel.AddressTVItemID;
                    FillAddressModelNew(addressModelNew);

                    string retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region AddressTVItemID
                    FillAddressModelNew(addressModelNew);
                    addressModelNew.AddressTVItemID = 0;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AddressTVItemID), retStr);

                    addressModelNew.AddressTVItemID = addressModel.AddressTVItemID;
                    FillAddressModelNew(addressModelNew);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AddressTVItemID

                    #region AddressType
                    FillAddressModelNew(addressModelNew);
                    addressModelNew.AddressType = (AddressTypeEnum)100000;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AddressType), retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.AddressType = AddressTypeEnum.Mailing;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AddressType

                    #region CountryTVItemID
                    FillAddressModelNew(addressModelNew);
                    addressModelNew.CountryTVItemID = 0;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.CountryTVItemID), retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.CountryTVItemID = randomService.RandomTVItem(TVTypeEnum.Address).TVItemID;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion CountryTVItemID

                    #region ProvinceTVItemID
                    FillAddressModelNew(addressModelNew);
                    addressModelNew.ProvinceTVItemID = 0;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ProvinceTVItemID), retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.ProvinceTVItemID = randomService.RandomTVItem(TVTypeEnum.Address).TVItemID;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ProvinceTVItemID

                    #region MunicipalityTVItemID
                    FillAddressModelNew(addressModelNew);
                    addressModelNew.MunicipalityTVItemID = 0;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MunicipalityTVItemID), retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.MunicipalityTVItemID = randomService.RandomTVItem(TVTypeEnum.Address).TVItemID;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MunicipalityTVItemID

                    #region StreetName
                    int Max = 200;
                    FillAddressModelNew(addressModelNew);
                    addressModelNew.StreetName = null;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.StreetName = randomService.RandomString("", Max + 1);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.StreetName, Max), retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.StreetName = randomService.RandomString("", Max - 1);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.StreetName = randomService.RandomString("", Max);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion StreetName

                    #region StreetNumber
                    Max = 50;
                    FillAddressModelNew(addressModelNew);
                    addressModelNew.StreetNumber = null;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.StreetNumber = randomService.RandomString("", Max + 1);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.StreetNumber, Max), retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.StreetNumber = randomService.RandomString("", Max - 1);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.StreetNumber = randomService.RandomString("", Max);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion StreetNumber

                    #region StreetType
                    FillAddressModelNew(addressModelNew);
                    addressModelNew.StreetType = (StreetTypeEnum)100000;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StreetType), retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.StreetType = StreetTypeEnum.Road;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion StreetType

                    #region GoogleAddressText
                    Max = 200;
                    FillAddressModelNew(addressModelNew);
                    addressModelNew.GoogleAddressText = null;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.GoogleAddressText = randomService.RandomString("", Max + 1);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.GoogleAddressText, Max), retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.GoogleAddressText = randomService.RandomString("", Max - 1);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.GoogleAddressText = randomService.RandomString("", Max);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion GoogleAddressText

                    #region LatLngText
                    Max = 100;
                    FillAddressModelNew(addressModelNew);
                    addressModelNew.LatLngText = null;

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.LatLngText = randomService.RandomString("", Max + 1);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.LatLngText, Max), retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.LatLngText = randomService.RandomString("", Max - 1);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);

                    FillAddressModelNew(addressModelNew);
                    addressModelNew.LatLngText = randomService.RandomString("", Max);

                    retStr = addressService.AddressModelOK(addressModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion LatLngText

                }
            }
        }
        [TestMethod]
        public void AddressService_FillAddress_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModel = AddAddressModel();
                    Assert.AreEqual("", addressModel.Error);

                    addressModelNew.AddressTVItemID = addressModel.AddressTVItemID;
                    FillAddressModelNew(addressModelNew);

                    ContactOK contactOK = addressService.IsContactOK();

                    string retStr = addressService.FillAddress(address, addressModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, address.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = addressService.FillAddress(address, addressModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, address.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void AddressService_GetAddressModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    int addressCount = addressService.GetAddressModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, addressCount);
                }
            }
        }
        [TestMethod]
        public void AddressService_GetAddressModelWithAddressIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    AddressModel addressModelRet2 = addressService.GetAddressModelWithAddressIDDB(addressModelRet.AddressID);
                    Assert.AreEqual("", addressModelRet2.Error);

                    int AddressID = 0;
                    AddressModel addressModelRet3 = addressService.GetAddressModelWithAddressIDDB(AddressID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Address, ServiceRes.AddressID, AddressID), addressModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_GetAddressModelWithAddressTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    AddressModel addressModelRet2 = addressService.GetAddressModelWithAddressTVItemIDDB(addressModelRet.AddressTVItemID);
                    Assert.AreEqual("", addressModelRet2.Error);

                    int AddressTVItemID = 0;
                    AddressModel addressModelRet3 = addressService.GetAddressModelWithAddressTVItemIDDB(AddressTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Address, ServiceRes.AddressTVItemID, AddressTVItemID), addressModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_GetAddressWithAddressIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    Address addressRet = addressService.GetAddressWithAddressIDDB(addressModelRet.AddressID);
                    Assert.AreEqual(addressModelRet.AddressID, addressRet.AddressID);

                    Address addressRet2 = addressService.GetAddressWithAddressIDDB(0);
                    Assert.IsNull(addressRet2);
                }
            }
        }
        [TestMethod]
        public void AddressService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    string retStr = addressService.CreateTVText(addressModelNew);
                    Assert.AreEqual(addressModelRet.StreetNumber + " " + addressModelRet.StreetName + " [" + addressModelRet.CountryTVItemID + "," + addressModelRet.ProvinceTVItemID + "," + addressModelRet.MunicipalityTVItemID + "," + addressModelRet.StreetType + "]", retStr);
                }
            }
        }
        [TestMethod]
        public void AddressService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    string ErrorText = "ErrorText";
                    AddressModel addressModelRet2 = addressService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, addressModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Good_Add_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";
                    Assert.IsNotNull(fc);

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Good_Add_AlreadyExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";

                    Assert.IsNotNull(fc);

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Good_Modify_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    Assert.IsNotNull(fc);

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_ContactTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    fc["ContactTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_CountryTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    fc["CountryTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.CountryTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_ProvinceTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    fc["ProvinceTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ProvinceTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_MunicipalityTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    fc["MunicipalityTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MunicipalityTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_AddressType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    fc["AddressType"] = "0";


                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AddressType), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_StreetType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    fc["StreetType"] = "0";


                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StreetType), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_StreetName_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    fc["StreetName"] = "";


                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StreetName), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_StreetNumber_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    fc["StreetNumber"] = "";

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StreetNumber), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Add_GetRootTVItemModelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetRootTVItemModelDB = () =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Add_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Add_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.CreateTVTextAddressModel = (a) =>
                        {
                            return "";
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Add_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Add_PostAddAddressDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };
                        shimAddressService.PostAddAddressDBAddressModel = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Add_GetAddressModelWithAddressTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.GetAddressModelWithAddressTVItemIDDBInt32 = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Add_GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDBInt32Int32 = (a, b) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                        Assert.AreEqual("", addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Add_PostAddTVItemLinkDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.PostAddTVItemLinkDBTVItemLinkModel = (a) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Modify_GetAddressModelWithAddressTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.GetAddressModelWithAddressTVItemIDDBInt32 = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Modify_PostUpdateAddressDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.PostUpdateAddressDBAddressModel = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Modify_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyDB_Modify_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Good_Add_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";
                    Assert.IsNotNull(fc);

                    AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Good_Add_AlreadyExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    Assert.IsNotNull(fc);

                    AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVText), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Good_Modify_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    Assert.IsNotNull(fc);

                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    Assert.IsNotNull(fc);
                    AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_InfrastructureTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_CountryTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    fc["CountryTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.CountryTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_CountryTVItemID_TVItemModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    fc["CountryTVItemID"] = "-1";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AddressModel addressModel = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_ProvinceTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    fc["ProvinceTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ProvinceTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_ProvinceTVItemID_TVItemModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    fc["ProvinceTVItemID"] = "-1";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            count += 1;
                            if (count < 2)
                                return new TVItemModel();

                            return new TVItemModel() { Error = ErrorText };
                        };

                        AddressModel addressModel = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_MunicipalityTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    fc["MunicipalityTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MunicipalityTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_MunicipalityTVItemID_TVItemModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    fc["MunicipalityTVItemID"] = "-1";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            count += 1;
                            if (count < 3)
                                return new TVItemModel();

                            return new TVItemModel() { Error = ErrorText };
                        };

                        AddressModel addressModel = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_AddressType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    fc["AddressType"] = "0";


                    AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AddressType), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_StreetType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    fc["StreetType"] = "0";


                    AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StreetType), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_StreetName_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    fc["StreetName"] = "";


                    AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StreetName), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_StreetNumber_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    fc["StreetNumber"] = "";

                    AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StreetNumber), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Add_GetRootTVItemModelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetRootTVItemModelDB = () =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Add_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Add_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.CreateTVTextAddressModel = (a) =>
                        {
                            return "";
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Add_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Add_PostAddAddressDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    Assert.IsNotNull(fc);

                    //fc["InfrastructureTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };
                        shimAddressService.PostAddAddressDBAddressModel = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Add_GetAddressModelWithAddressTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "346";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.GetAddressModelWithAddressTVItemIDDBInt32 = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Add_PostUpdateInfrastructureDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "1234";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimInfrastructureService.PostUpdateInfrastructureDBInfrastructureModel = (a) =>
                        {
                            return new InfrastructureModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Add_CreateMapInfoObjectDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "1234";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDBInt32TVTypeEnumMapInfoDrawTypeEnum = (a, b, c) =>
                        {
                            return new List<MapInfoPointModel>();
                        };
                        shimMapInfoService.CreateMapInfoObjectDBListOfCoordMapInfoDrawTypeEnumTVTypeEnumInt32 = (a, b, c, d) =>
                         {
                             return new MapInfoModel() { Error = ErrorText };
                         };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Modify_GetAddressModelWithAddressTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.GetAddressModelWithAddressTVItemIDDBInt32 = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Modify_PostUpdateAddressDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.PostUpdateAddressDBAddressModel = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Modify_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Modify_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        int count = 0;
                        shimAddressService.CreateTVTextAddressModel = (a) =>
                        {
                            count += 1;
                            if (count < 2)
                                return "sliefjaslijfe";

                            return "";
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Modify_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Modify_CreateMapInfoObjectDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDBInt32TVTypeEnumMapInfoDrawTypeEnum = (a, b, c) =>
                        {
                            return new List<MapInfoPointModel>();
                        };
                        shimMapInfoService.CreateMapInfoObjectDBListOfCoordMapInfoDrawTypeEnumTVTypeEnumInt32 = (a, b, c, d) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };
                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Modify_GetMapInfoPointModelWithMapInfoPointIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDBInt32TVTypeEnumMapInfoDrawTypeEnum = (a, b, c) =>
                        {
                            return new List<MapInfoPointModel>() { new MapInfoPointModel() };
                        };
                        shimMapInfoPointService.GetMapInfoPointModelWithMapInfoPointIDDBInt32 = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };
                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyInfrastructureDB_Modify_PostUpdateMapInfoPointDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyInfrastructureDBFormCollection();
                    //fc["InfrastructureTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.PostUpdateMapInfoPointDBMapInfoPointModel = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };
                        AddressModel addressModelRet = addressService.PostAddOrModifyInfrastructureDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Good_Add_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";
                    Assert.IsNotNull(fc);

                    AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Good_Add_AlreadyExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    Assert.IsNotNull(fc);

                    AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Good_Modify_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";
                    Assert.IsNotNull(fc);

                    AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_PolSourceSiteTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["PolSourceSiteTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_CountryTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    fc["CountryTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.CountryTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_ProvinceTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    fc["ProvinceTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ProvinceTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_MunicipalityTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    Assert.IsNotNull(fc);

                    fc["MunicipalityTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    fc["StreetName"] = "Something";

                    AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MunicipalityTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_AddressType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    fc["AddressType"] = "0";


                    AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AddressType), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_StreetType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    fc["StreetType"] = "0";


                    AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StreetType), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_StreetName_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    fc["StreetName"] = "";


                    AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StreetName), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_StreetNumber_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    fc["StreetNumber"] = "";

                    AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.StreetNumber), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Add_GetRootTVItemModelDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetRootTVItemModelDB = () =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Add_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Add_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.CreateTVTextAddressModel = (a) =>
                        {
                            return "";
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Add_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Add_PostAddAddressDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };
                        shimAddressService.PostAddAddressDBAddressModel = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Add_GetAddressModelWithAddressTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.GetAddressModelWithAddressTVItemIDDBInt32 = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Add_GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    //fc["StreetNumber"] = "";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDBInt32Int32 = (a, b) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                        Assert.AreEqual("", addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Modify_GetAddressModelWithAddressTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.GetAddressModelWithAddressTVItemIDDBInt32 = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Modify_PostUpdateAddressDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.PostUpdateAddressDBAddressModel = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Modify_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddOrModifyPolSourceSiteDB_Modify_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyPolSourceSiteDBFormCollection();
                    //fc["PolSourceSiteTVItemID"] = "0";
                    //fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "23487473";
                    //fc["AddressType"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = addressService.PostAddOrModifyPolSourceSiteDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddUpdateDeleteAddress_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    TestDBService testDBService2 = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "Address", "es");
                    Assert.AreEqual(testDBService.Count + 1, testDBService2.Count);

                    FillAddressModelUpdate(addressModelRet);

                    AddressModel addressModelRet2 = addressService.PostUpdateAddressDB(addressModelRet);
                    Assert.IsNotNull(addressModelRet2);

                    CompareAddressModels(addressModelRet, addressModelRet2);

                    AddressModel addressModelRet3 = addressService.PostDeleteAddressDB(addressModelRet2.AddressID);
                    Assert.AreEqual("", addressModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddAddressDB_AddressModelOK_Error_Test()
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
                        shimAddressService.AddressModelOKAddressModel = (a) =>
                        {
                            return ErrorText;
                        };

                        AddressModel addressModelRet = AddAddressModel();
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddAddressDB_IsContactOK_Error_Test()
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
                        shimAddressService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AddressModel addressModelRet = AddAddressModel();
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddAddressDB_GetTVItemModelWithTVItemIDDB_Error_Test()
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

                        AddressModel addressModelRet = AddAddressModel();
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddAddressDB_FillAddress_Error_Test()
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
                        shimAddressService.FillAddressAddressAddressModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        AddressModel addressModelRet = AddAddressModel();
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddAddressDB_DoAddChanges_Error_Test()
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
                        shimAddressService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        AddressModel addressModelRet = AddAddressModel();
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddAddressDB_Add_Error_Test()
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
                        shimAddressService.FillAddressAddressAddressModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        AddressModel addressModelRet = AddAddressModel();
                        Assert.IsTrue(addressModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddAddressDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();
                    Assert.IsNotNull(addressModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostAddAddressDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    AddressModel addressModelRet = AddAddressModel();
                    Assert.IsNotNull(addressModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostDeleteAddress_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAddressService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AddressModel addressModelRet2 = addressService.PostDeleteAddressDB(addressModelRet.AddressID);
                        Assert.AreEqual(ErrorText, addressModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostDeleteAddress_GetAddressWithAddressIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAddressService.GetAddressWithAddressIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        AddressModel addressModelRet2 = addressService.PostDeleteAddressDB(addressModelRet.AddressID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Address), addressModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostDeleteAddress_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();
                    Assert.AreEqual("", addressModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAddressService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        AddressModel addressModelRet2 = addressService.PostDeleteAddressDB(addressModelRet.AddressID);
                        Assert.AreEqual(ErrorText, addressModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostDeleteAddressUnderContactTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";
                    Assert.IsNotNull(fc);

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);

                    fc["AddressTVItemID"] = addressModelRet.AddressTVItemID.ToString();

                    addressModelRet = addressService.PostDeleteAddressUnderContactTVItemIDDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostDeleteAddressUnderContactTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);

                    Assert.AreEqual("", addressModelRet.Error);

                    fc["AddressTVItemID"] = addressModelRet.AddressTVItemID.ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        addressModelRet = addressService.PostDeleteAddressUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostDeleteAddressUnderContactTVItemIDDB_ContactTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);

                    fc["AddressTVItemID"] = addressModelRet.AddressTVItemID.ToString();

                    fc["ContactTVItemID"] = "0";

                    addressModelRet = addressService.PostDeleteAddressUnderContactTVItemIDDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostDeleteAddressUnderContactTVItemIDDB_AddressTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);

                    //fc["AddressTVItemID"] = addressModelRet.AddressTVItemID.ToString();
                    Assert.AreEqual("", addressModelRet.Error);

                    fc["AddressTVItemID"] = "0";

                    addressModelRet = addressService.PostDeleteAddressUnderContactTVItemIDDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AddressTVItemID), addressModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AddressService_PostDeleteAddressUnderContactTVItemIDDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);

                    fc["AddressTVItemID"] = addressModelRet.AddressTVItemID.ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        addressModelRet = addressService.PostDeleteAddressUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostDeleteAddressUnderContactTVItemIDDB_GetTVItemModelWithTVItemIDDB2_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);

                    fc["AddressTVItemID"] = addressModelRet.AddressTVItemID.ToString();

                    int count = 0;
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            count += 1;
                            if (count == 1)
                            {
                                return new TVItemModel();
                            }
                            return new TVItemModel() { Error = ErrorText };
                        };

                        addressModelRet = addressService.PostDeleteAddressUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostDeleteAddressUnderContactTVItemIDDB_GetAddressModelWithAddressTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);

                    fc["AddressTVItemID"] = addressModelRet.AddressTVItemID.ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimAddressService.GetAddressModelWithAddressTVItemIDDBInt32 = (a) =>
                        {
                            return new AddressModel() { Error = ErrorText };
                        };

                        addressModelRet = addressService.PostDeleteAddressUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostDeleteAddressUnderContactTVItemIDDB_PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillPostAddOrModifyDBFormCollection();
                    //fc["ContactTVItemID"] = "0";
                    fc["AddressTVItemID"] = "0";
                    fc["StreetNumber"] = "234";

                    AddressModel addressModelRet = addressService.PostAddOrModifyDB(fc);
                    Assert.AreEqual("", addressModelRet.Error);

                    fc["AddressTVItemID"] = addressModelRet.AddressTVItemID.ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDBInt32Int32 = (a, b) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        addressModelRet = addressService.PostDeleteAddressUnderContactTVItemIDDB(fc);
                        Assert.AreEqual(ErrorText, addressModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostUpdateAddress_AddressModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAddressService.AddressModelOKAddressModel = (a) =>
                        {
                            return ErrorText;
                        };

                        AddressModel addressModelRet2 = UpdateAddressModel(addressModelRet);
                        Assert.AreEqual(ErrorText, addressModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostUpdateAddress_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAddressService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        AddressModel addressModelRet2 = UpdateAddressModel(addressModelRet);
                        Assert.AreEqual(ErrorText, addressModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostUpdateAddress_GetAddressWithAddressIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAddressService.GetAddressWithAddressIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        AddressModel addressModelRet2 = UpdateAddressModel(addressModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Address), addressModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostUpdateAddress_FillAddress_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAddressService.FillAddressAddressAddressModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        AddressModel addressModelRet2 = addressService.PostUpdateAddressDB(addressModelRet);
                        Assert.AreEqual(ErrorText, addressModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostUpdateAddress_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAddressService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        AddressModel addressModelRet2 = addressService.PostUpdateAddressDB(addressModelRet);
                        Assert.AreEqual(ErrorText, addressModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostUpdateAddress_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet2 = UpdateAddressModel(addressModelRet);
                        Assert.AreEqual(ErrorText, addressModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostUpdateAddress_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAddressService.CreateTVTextAddressModel = (a) =>
                        {
                            return "";
                        };

                        AddressModel addressModelRet2 = UpdateAddressModel(addressModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), addressModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AddressService_PostUpdateAddress_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AddressModel addressModelRet = AddAddressModel();

                    FillAddressModelUpdate(addressModelRet);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        AddressModel addressModelRet2 = addressService.PostUpdateAddressDB(addressModelRet);
                        Assert.AreEqual(ErrorText, addressModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        private AddressModel AddAddressModel()
        {
            TVItemModel tvItemModelRoot = addressService._TVItemService.GetRootTVItemModelDB();
            if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
            {
                return new AddressModel() { Error = tvItemModelRoot.Error };
            }

            string TVText = randomService.RandomString("Address ", 20);
            TVItemModel tvItemModelAddress = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Address);
            if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
            {
                return new AddressModel() { Error = tvItemModelAddress.Error };
            }

            addressModelNew.AddressTVItemID = tvItemModelAddress.TVItemID;
            FillAddressModelNew(addressModelNew);

            float Lat = float.Parse(addressModelNew.LatLngText.Substring(0, addressModelNew.LatLngText.IndexOfAny(" ".ToCharArray())));
            float Lng = float.Parse(addressModelNew.LatLngText.Substring(addressModelNew.LatLngText.LastIndexOfAny(" ".ToCharArray())));

            List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelAddress.TVItemID, TVTypeEnum.Address, MapInfoDrawTypeEnum.Point);

            if (mapInfoPointModelList.Count == 0)
            {
                List<Coord> coordList = new List<Coord>()
                {
                    new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 },
                };

                MapInfoModel mapInfoModel = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Address, tvItemModelAddress.TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                {
                    return new AddressModel() { Error = mapInfoModel.Error };
                }
            }
            else
            {
                MapInfoPointModel mapInfoPointModelRet = mapInfoService._MapInfoPointService.GetMapInfoPointModelWithMapInfoPointIDDB(mapInfoPointModelList[0].MapInfoPointID);
                if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                {
                    return new AddressModel() { Error = mapInfoPointModelRet.Error };
                }

                mapInfoPointModelRet.Lat = Lat;
                mapInfoPointModelRet.Lng = Lng;
                mapInfoPointModelRet.Ordinal = 0;

                mapInfoPointModelRet = mapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelRet);
                if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                {
                    return new AddressModel() { Error = mapInfoPointModelRet.Error };
                }
            }

            AddressModel addressModelRet = addressService.PostAddAddressDB(addressModelNew);
            if (!string.IsNullOrWhiteSpace(addressModelRet.Error))
            {
                return addressModelRet;
            }
            Assert.IsNotNull(addressModelRet);
            CompareAddressModels(addressModelNew, addressModelRet);

            return addressModelRet;
        }
        private AddressModel UpdateAddressModel(AddressModel addressModel)
        {
            FillAddressModelUpdate(addressModel);


            AddressModel addressModelRet = addressService.PostUpdateAddressDB(addressModel);
            if (!string.IsNullOrWhiteSpace(addressModelRet.Error))
            {
                return addressModelRet;
            }
            Assert.IsNotNull(addressModelRet);
            CompareAddressModels(addressModel, addressModelRet);

            return addressModelRet;
        }
        private void CompareAddressModels(AddressModel addressModelNew, AddressModel addressModelRet)
        {
            Assert.AreEqual(addressModelNew.CountryTVItemID, addressModelRet.CountryTVItemID);
            Assert.AreEqual(addressModelNew.ProvinceTVItemID, addressModelRet.ProvinceTVItemID);
            Assert.AreEqual(addressModelNew.MunicipalityTVItemID, addressModelRet.MunicipalityTVItemID);
            Assert.AreEqual(addressModelNew.StreetName, addressModelRet.StreetName);
            Assert.AreEqual(addressModelNew.StreetNumber, addressModelRet.StreetNumber);
            Assert.AreEqual(addressModelNew.StreetType, addressModelRet.StreetType);
            Assert.AreEqual(addressModelNew.PostalCode, addressModelRet.PostalCode);
            Assert.AreEqual(addressModelNew.GoogleAddressText, addressModelRet.GoogleAddressText);
            Assert.AreEqual(addressModelNew.LatLngText, (randomService.LanguageRequest == LanguageEnum.en ? addressModelRet.LatLngText.Replace(",", ".") : addressModelRet.LatLngText.Replace(".", ",")));
        }
        public FormCollection FillPostAddOrModifyDBFormCollection()
        {
            TVItemModel tvItemModelMuni = addressService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, "Bouctouche", TVTypeEnum.Municipality);
            Assert.AreEqual("", tvItemModelMuni.Error);

            TVItemModel tvItemModelProv = addressService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(tvItemModelMuni.ParentID);
            Assert.AreEqual("", tvItemModelProv.Error);

            TVItemModel tvItemModelCountry = addressService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(tvItemModelProv.ParentID);
            Assert.AreEqual("", tvItemModelCountry.Error);

            AddressModel addressModelNew = new AddressModel()
            {
                CountryTVItemID = tvItemModelCountry.TVItemID,
                ProvinceTVItemID = tvItemModelProv.TVItemID,
                MunicipalityTVItemID = tvItemModelMuni.TVItemID,
                StreetName = randomService.RandomString("", 20),
                StreetNumber = randomService.RandomInt(23, 2300).ToString(),
                StreetType = StreetTypeEnum.Street,
                AddressType = AddressTypeEnum.Mailing,
                PostalCode = randomService.RandomString("", 7),
                GoogleAddressText = randomService.RandomString("", 30),
                LatLngText = (randomService.LanguageRequest == LanguageEnum.en ? "50.2 -66.2" : "50,2 -66,2"),
            };

            string TVText = addressService.CreateTVText(addressModelNew);

            TVItemModel tvItemModelAddress = tvItemService.PostAddChildTVItemDB(1, TVText, TVTypeEnum.Address);
            if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                return null;

            addressModelNew.AddressTVItemID = tvItemModelAddress.TVItemID;

            float Lat = float.Parse(addressModelNew.LatLngText.Substring(0, addressModelNew.LatLngText.IndexOfAny(" ".ToCharArray())));
            float Lng = float.Parse(addressModelNew.LatLngText.Substring(addressModelNew.LatLngText.LastIndexOfAny(" ".ToCharArray())));

            List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelAddress.TVItemID, TVTypeEnum.Address, MapInfoDrawTypeEnum.Point);

            if (mapInfoPointModelList.Count == 0)
            {
                List<Coord> coordList = new List<Coord>()
                {
                    new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 },
                };

                MapInfoModel mapInfoModel = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Address, tvItemModelAddress.TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                {
                    return null;
                }
            }
            else
            {
                MapInfoPointModel mapInfoPointModelRet = mapInfoService._MapInfoPointService.GetMapInfoPointModelWithMapInfoPointIDDB(mapInfoPointModelList[0].MapInfoPointID);
                if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                {
                    return null;
                }

                mapInfoPointModelRet.Lat = Lat;
                mapInfoPointModelRet.Lng = Lng;
                mapInfoPointModelRet.Ordinal = 0;

                mapInfoPointModelRet = mapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelRet);
                if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                {
                    return null;
                }
            }

            AddressModel addressModel = addressService.PostAddAddressDB(addressModelNew);
            if (!string.IsNullOrWhiteSpace(addressModel.Error))
                return null;

            FormCollection fc = new FormCollection();
            fc.Add("ContactTVItemID", contactModelListGood[0].ContactTVItemID.ToString());
            fc.Add("AddressTVItemID", addressModel.AddressTVItemID.ToString());
            fc.Add("CountryTVItemID", addressModel.CountryTVItemID.ToString());
            fc.Add("ProvinceTVItemID", addressModel.ProvinceTVItemID.ToString());
            fc.Add("MunicipalityTVItemID", addressModel.MunicipalityTVItemID.ToString());
            fc.Add("StreetName", addressModel.StreetName);
            fc.Add("StreetNumber", addressModel.StreetNumber);
            fc.Add("StreetType", ((int)addressModel.StreetType).ToString());
            fc.Add("AddressType", ((int)AddressTypeEnum.Mailing).ToString());
            fc.Add("PostalCode", addressModel.PostalCode);
            fc.Add("GoogleAddressText", addressModel.GoogleAddressText);
            fc.Add("LatLngText", (randomService.LanguageRequest == LanguageEnum.en ? addressModel.LatLngText : addressModel.LatLngText.Replace(".", ",")));

            return fc;
        }
        public FormCollection FillPostAddOrModifyInfrastructureDBFormCollection()
        {
            TVItemModel tvItemModelMuni = addressService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, "Bouctouche", TVTypeEnum.Municipality);
            Assert.AreEqual("", tvItemModelMuni.Error);

            TVItemModel tvItemModelProv = addressService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(tvItemModelMuni.ParentID);
            Assert.AreEqual("", tvItemModelProv.Error);

            TVItemModel tvItemModelCountry = addressService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(tvItemModelProv.ParentID);
            Assert.AreEqual("", tvItemModelCountry.Error);

            AddressModel addressModelNew = new AddressModel()
            {
                CountryTVItemID = tvItemModelCountry.TVItemID,
                ProvinceTVItemID = tvItemModelProv.TVItemID,
                MunicipalityTVItemID = tvItemModelMuni.TVItemID,
                StreetName = randomService.RandomString("", 20),
                StreetNumber = randomService.RandomInt(23, 2300).ToString(),
                StreetType = StreetTypeEnum.Street,
                AddressType = AddressTypeEnum.Mailing,
                PostalCode = randomService.RandomString("", 7),
                GoogleAddressText = randomService.RandomString("", 30),
                LatLngText = (randomService.LanguageRequest == LanguageEnum.en ? "50.2 -66.2" : "50,2 -66,2"),
            };

            string TVText = addressService.CreateTVText(addressModelNew);

            TVItemModel tvItemModelAddress = tvItemService.PostAddChildTVItemDB(1, TVText, TVTypeEnum.Address);
            if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                return null;

            addressModelNew.AddressTVItemID = tvItemModelAddress.TVItemID;

            float Lat = float.Parse(addressModelNew.LatLngText.Substring(0, addressModelNew.LatLngText.IndexOfAny(" ".ToCharArray())));
            float Lng = float.Parse(addressModelNew.LatLngText.Substring(addressModelNew.LatLngText.LastIndexOfAny(" ".ToCharArray())));

            List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelAddress.TVItemID, TVTypeEnum.Address, MapInfoDrawTypeEnum.Point);

            if (mapInfoPointModelList.Count == 0)
            {
                List<Coord> coordList = new List<Coord>()
                {
                    new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 },
                };

                MapInfoModel mapInfoModel = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Address, tvItemModelAddress.TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                {
                    return null;
                }
            }
            else
            {
                MapInfoPointModel mapInfoPointModelRet = mapInfoService._MapInfoPointService.GetMapInfoPointModelWithMapInfoPointIDDB(mapInfoPointModelList[0].MapInfoPointID);
                if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                {
                    return null;
                }

                mapInfoPointModelRet.Lat = Lat;
                mapInfoPointModelRet.Lng = Lng;
                mapInfoPointModelRet.Ordinal = 0;

                mapInfoPointModelRet = mapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelRet);
                if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                {
                    return null;
                }
            }
            AddressModel addressModel = addressService.PostAddAddressDB(addressModelNew);
            if (!string.IsNullOrWhiteSpace(addressModel.Error))
                return null;

            FormCollection fc = new FormCollection();
            fc.Add("InfrastructureTVItemID", randomService.RandomTVItem(TVTypeEnum.Infrastructure).TVItemID.ToString());
            fc.Add("AddressTVItemID", addressModel.AddressTVItemID.ToString());
            fc.Add("CountryTVItemID", addressModel.CountryTVItemID.ToString());
            fc.Add("ProvinceTVItemID", addressModel.ProvinceTVItemID.ToString());
            fc.Add("MunicipalityTVItemID", addressModel.MunicipalityTVItemID.ToString());
            fc.Add("StreetName", addressModel.StreetName);
            fc.Add("StreetNumber", addressModel.StreetNumber);
            fc.Add("StreetType", ((int)addressModel.StreetType).ToString());
            fc.Add("AddressType", ((int)AddressTypeEnum.Mailing).ToString());
            fc.Add("PostalCode", addressModel.PostalCode);
            fc.Add("GoogleAddressText", addressModel.GoogleAddressText);
            fc.Add("LatLngText", (randomService.LanguageRequest == LanguageEnum.en ? addressModel.LatLngText : addressModel.LatLngText.Replace(".", ",")));

            return fc;
        }
        public FormCollection FillPostAddOrModifyPolSourceSiteDBFormCollection()
        {
            TVItemModel tvItemModelMuni = addressService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, "Bouctouche", TVTypeEnum.Municipality);
            Assert.AreEqual("", tvItemModelMuni.Error);

            TVItemModel tvItemModelProv = addressService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(tvItemModelMuni.ParentID);
            Assert.AreEqual("", tvItemModelProv.Error);

            TVItemModel tvItemModelCountry = addressService._TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(tvItemModelProv.ParentID);
            Assert.AreEqual("", tvItemModelCountry.Error);

            AddressModel addressModelNew = new AddressModel()
            {
                CountryTVItemID = tvItemModelCountry.TVItemID,
                ProvinceTVItemID = tvItemModelProv.TVItemID,
                MunicipalityTVItemID = tvItemModelMuni.TVItemID,
                StreetName = randomService.RandomString("", 20),
                StreetNumber = randomService.RandomInt(23, 2300).ToString(),
                StreetType = StreetTypeEnum.Street,
                AddressType = AddressTypeEnum.Mailing,
                PostalCode = randomService.RandomString("", 7),
                GoogleAddressText = randomService.RandomString("", 30),
                LatLngText = randomService.RandomString("", 30),
            };

            string TVText = addressService.CreateTVText(addressModelNew);

            TVItemModel tvItemModelAddress = tvItemService.PostAddChildTVItemDB(1, TVText, TVTypeEnum.Address);
            if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                return null;

            addressModelNew.AddressTVItemID = tvItemModelAddress.TVItemID;

            AddressModel addressModel = addressService.PostAddAddressDB(addressModelNew);
            if (!string.IsNullOrWhiteSpace(addressModel.Error))
                return null;

            FormCollection fc = new FormCollection();
            fc.Add("PolSourceSiteTVItemID", randomService.RandomTVItem(TVTypeEnum.PolSourceSite).TVItemID.ToString());
            fc.Add("AddressTVItemID", addressModel.AddressTVItemID.ToString());
            fc.Add("CountryTVItemID", addressModel.CountryTVItemID.ToString());
            fc.Add("ProvinceTVItemID", addressModel.ProvinceTVItemID.ToString());
            fc.Add("MunicipalityTVItemID", addressModel.MunicipalityTVItemID.ToString());
            fc.Add("StreetName", addressModel.StreetName);
            fc.Add("StreetNumber", addressModel.StreetNumber);
            fc.Add("StreetType", ((int)addressModel.StreetType).ToString());
            fc.Add("AddressType", ((int)AddressTypeEnum.Mailing).ToString());
            fc.Add("PostalCode", addressModel.PostalCode);
            fc.Add("GoogleAddressText", addressModel.GoogleAddressText);
            fc.Add("LatLngText", (randomService.LanguageRequest == LanguageEnum.en ? addressModel.LatLngText : addressModel.LatLngText.Replace(".", ",")));

            return fc;
        }
        private void FillAddressModelNew(AddressModel addressModel)
        {
            addressModel.AddressTVItemID = addressModel.AddressTVItemID;
            addressModel.CountryTVItemID = randomService.RandomTVItem(TVTypeEnum.Country).TVItemID;
            addressModel.ProvinceTVItemID = randomService.RandomTVItem(TVTypeEnum.Province).TVItemID;
            addressModel.MunicipalityTVItemID = randomService.RandomTVItem(TVTypeEnum.Municipality).TVItemID;
            addressModel.StreetName = randomService.RandomString("Street Name", "Street Name".Length + 3);
            addressModel.StreetNumber = randomService.RandomString("23", "23".Length);
            addressModel.StreetType = StreetTypeEnum.Road;
            addressModel.AddressType = AddressTypeEnum.Mailing;
            addressModel.PostalCode = randomService.RandomString("", 7);
            addressModel.GoogleAddressText = randomService.RandomString("", 40);
            addressModel.LatLngText = (randomService.LanguageRequest == LanguageEnum.en ? "50.2 -66.2" : "50,2 -66,2");

            Assert.IsTrue(addressModel.AddressTVItemID != 0);
            Assert.IsTrue(addressModel.CountryTVItemID != 0);
            Assert.IsTrue(addressModel.ProvinceTVItemID != 0);
            Assert.IsTrue(addressModel.MunicipalityTVItemID != 0);
            Assert.IsTrue(addressModel.StreetType == StreetTypeEnum.Road);
            Assert.IsTrue(addressModel.AddressType == AddressTypeEnum.Mailing);
            Assert.IsTrue(addressModel.PostalCode.Length == 7);
            Assert.IsTrue(addressModel.GoogleAddressText.Length == 40);
            Assert.IsTrue(addressModel.LatLngText == (randomService.LanguageRequest == LanguageEnum.en ? "50.2 -66.2" : "50,2 -66,2"));
        }
        private void FillAddressModelUpdate(AddressModel addressModel)
        {
            addressModel.CountryTVItemID = randomService.RandomTVItem(TVTypeEnum.Country).TVItemID;
            addressModel.ProvinceTVItemID = randomService.RandomTVItem(TVTypeEnum.Province).TVItemID;
            addressModel.MunicipalityTVItemID = randomService.RandomTVItem(TVTypeEnum.Municipality).TVItemID;
            addressModel.StreetName = randomService.RandomString("Street Name Update", "Street Name Update".Length + 3);
            addressModel.StreetNumber = randomService.RandomString("233", "233".Length);
            addressModel.StreetType = StreetTypeEnum.Street;
            addressModel.AddressType = AddressTypeEnum.Shipping;
            addressModel.PostalCode = randomService.RandomString("", 7);
            addressModel.GoogleAddressText = randomService.RandomString("", 40);
            addressModel.LatLngText = (randomService.LanguageRequest == LanguageEnum.en ? "50.2 -66.2" : "50,2 -66,2");

            Assert.IsTrue(addressModel.AddressTVItemID != 0);
            Assert.IsTrue(addressModel.CountryTVItemID != 0);
            Assert.IsTrue(addressModel.ProvinceTVItemID != 0);
            Assert.IsTrue(addressModel.MunicipalityTVItemID != 0);
            Assert.IsTrue(addressModel.StreetType == StreetTypeEnum.Street);
            Assert.IsTrue(addressModel.AddressType == AddressTypeEnum.Shipping);
            Assert.IsTrue(addressModel.PostalCode.Length == 7);
            Assert.IsTrue(addressModel.GoogleAddressText.Length == 40);
            Assert.IsTrue(addressModel.LatLngText == (randomService.LanguageRequest == LanguageEnum.en ? "50.2 -66.2" : "50,2 -66,2"));
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            if (contactModelToDo == null)
            {
                user = null;
            }
            else
            {
                user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            }
            addressService = new AddressService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mapInfoService = new MapInfoService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            addressModelNew = new AddressModel();
            address = new Address();
        }
        private void SetupShim()
        {
            shimAddressService = new ShimAddressService(addressService);
            shimTVItemService = new ShimTVItemService(addressService._TVItemService);
            shimTVItemLinkService = new ShimTVItemLinkService(addressService._TVItemLinkService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(addressService._TVItemService._TVItemLanguageService);
            shimInfrastructureService = new ShimInfrastructureService(addressService._InfrastructureService);
            shimMapInfoService = new ShimMapInfoService(addressService._MapInfoService);
            shimMapInfoPointService = new ShimMapInfoPointService(addressService._MapInfoService._MapInfoPointService);
        }
        #endregion Functions private
    }
}

