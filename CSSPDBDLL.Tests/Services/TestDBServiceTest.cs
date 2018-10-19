using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPWebToolsDBDLL.Tests.SetupInfo;
using CSSPWebToolsDBDLL.Models;
using System.Security.Principal;
using CSSPWebToolsDBDLL.Services;
using CSSPWebToolsDBDLL.Services.Resources;
using System.Globalization;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for TestDBServiceTest
    /// </summary>
    [TestClass]
    public class TestDBServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        #endregion Variables

        #region Properties
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
        public TestDBServiceTest()
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

        #region Testing Methods
        [TestMethod]
        public void TestDBService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);

                string TableName = "";
                string Plurial = "";
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
                Assert.AreEqual(0, testDBService.Count);
                Assert.AreEqual(TableName, testDBService.dbTable.TableName);
                Assert.AreEqual(Plurial, testDBService.dbTable.Plurial);
            }
        }
        [TestMethod]
        public void TestDBService_CompareDBAndList_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "", "");

                List<DBTable> AllTables = new List<DBTable>();

                FillAllTables(testDBService, AllTables);

                // already in function

                List<string> TablesNameInDB = new List<string>();

                testDBService.FillDBTablesName(TablesNameInDB);

                string retStr = testDBService.CompareDBAndList(TablesNameInDB, AllTables);
                Assert.AreEqual("", retStr);

                break; // only do one language
            }
        }
        [TestMethod]
        public void TestDBService_CompareTableList_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "", "");

                List<DBTable> AllTables = new List<DBTable>();

                FillAllTables(testDBService, AllTables);

                List<DBTable> AllTablesToDelete = new List<DBTable>();
                FillAllTablesToDelete(testDBService, AllTablesToDelete);

                string retStr = testDBService.CompareTableList(AllTables, AllTablesToDelete);
                Assert.AreEqual("", retStr);

                break; // only do one language
            }
        }
        [TestMethod]
        public void TestDBService_CompareTableList_NotSameCount_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "", "");

                List<DBTable> AllTables = new List<DBTable>();

                FillAllTables(testDBService, AllTables);
                AllTables.Add(new DBTable() { TableName = "NotSameCount", Plurial = "s" });

                List<DBTable> AllTablesToDelete = new List<DBTable>();
                FillAllTablesToDelete(testDBService, AllTablesToDelete);

                string retStr = testDBService.CompareTableList(AllTables, AllTablesToDelete);
                Assert.AreEqual(string.Format(ServiceRes._CountAnd_CountNotEqual, "AllTables", "AllTablesToDelete"), retStr);

                break; // only do one language
            }
        }
        [TestMethod]
        public void TestDBService_CompareTableList_NotSameTableName_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "", "");
                string TableName1 = "aaa";
                string TableName2 = "aaaa";

                List<DBTable> AllTables = new List<DBTable>();

                FillAllTables(testDBService, AllTables);
                AllTables[0].TableName = TableName1;

                List<DBTable> AllTablesToDelete = new List<DBTable>();
                FillAllTablesToDelete(testDBService, AllTablesToDelete);
                AllTablesToDelete[0].TableName = TableName2;

                string retStr = testDBService.CompareTableList(AllTables, AllTablesToDelete);
                Assert.AreEqual(string.Format(ServiceRes.CompareTableNotEqual_And_, AllTables[0].TableName, AllTablesToDelete[0].TableName), retStr);

                break; // only do one language
            }
        }
        [TestMethod]
        public void TestDBService_CompareTableList_NotSamePlurial_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "", "");
                string TableName1 = "aaa";
                string TableName2 = "aaa";
                string Plurial1 = "s";
                string Plurial2 = "es";

                List<DBTable> AllTables = new List<DBTable>();

                FillAllTables(testDBService, AllTables);
                AllTables[0].TableName = TableName1;
                AllTables[0].Plurial = Plurial1;

                List<DBTable> AllTablesToDelete = new List<DBTable>();
                FillAllTablesToDelete(testDBService, AllTablesToDelete);
                AllTablesToDelete[0].TableName = TableName2;
                AllTablesToDelete[0].Plurial = Plurial2;

                string retStr = testDBService.CompareTableList(AllTables, AllTablesToDelete);
                Assert.AreEqual(string.Format(ServiceRes.CompareTablePlurialNotEqual_And_, AllTables[0].TableName, AllTablesToDelete[0].TableName), retStr);

                break; // only do one language
            }
        }
        [TestMethod]
        public void TestDBService_CSSPWebToolsDBIsOK_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "", "");

                string retStr = testDBService.CSSPWebToolsDBIsOK();
                Assert.AreEqual("", retStr);
                break; // only do one language
            }
        }
        [TestMethod]
        public void TestDBService_FillDBTablesName_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "", "");

                List<string> AllTableNames = new List<string>();

                testDBService.FillDBTablesName(AllTableNames);
                Assert.IsTrue(AllTableNames.Count > 0);

                break; // only do one language
            }
        }
        [TestMethod]
        public void TestDBService_FillTableNameList_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "", "");

                List<DBTable> AllTables = new List<DBTable>();

                FillAllTables(testDBService, AllTables);

                break; // only do one language
            }
        }
        [TestMethod]
        public void TestDBService_FillTableNameToDeleteList_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                ContactModel contactModel = contactModelListGood[0];
                IPrincipal user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
                TestDBService testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, "", "");

                List<DBTable> AllTablesToDelete = new List<DBTable>();

                FillAllTablesToDelete(testDBService, AllTablesToDelete);

                break; // only do one language
            }
        }
        #endregion Testing Methods

        #region Functions
        private void FillAllTables(TestDBService testDBService, List<DBTable> AllTables)
        {
            testDBService.FillTableNameList(AllTables);

            Assert.AreEqual(70, AllTables.Count);
            Assert.AreEqual("Address", AllTables[0].TableName);
            Assert.AreEqual("es", AllTables[0].Plurial);
            Assert.AreEqual("AppErrLog", AllTables[1].TableName);
            Assert.AreEqual("s", AllTables[1].Plurial);
        }
        private void FillAllTablesToDelete(TestDBService testDBService, List<DBTable> AllTablesToDelete)
        {
            PrivateObject privateObject = new PrivateObject(testDBService);

            privateObject.Invoke("FillTableNameToDeleteList", AllTablesToDelete);

            Assert.AreEqual(70, AllTablesToDelete.Count);
            Assert.AreEqual("Log", AllTablesToDelete[0].TableName);
            Assert.AreEqual("s", AllTablesToDelete[0].Plurial);
        }
        #endregion Functions
    }
}

