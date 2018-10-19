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
using System.IO;
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for PolSourceObservationIssueServiceTest
    /// </summary>
    [TestClass]
    public class PolSourceObservationIssueServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "PolSourceObservationIssue";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private PolSourceObservationIssueService polSourceObservationIssueService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private PolSourceObservationIssueModel polSourceObservationIssueModelNew { get; set; }
        private PolSourceObservationIssue polSourceObservationIssue { get; set; }
        private ShimPolSourceObservationIssueService shimPolSourceObservationIssueService { get; set; }
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
        public PolSourceObservationIssueServiceTest()
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
        public void Get_Path_ID_of_A_Certain_ID()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange 
                SetupTest(contactModelListGood[0], culture);

                Dictionary<string, string> ReplaceDict = new Dictionary<string, string>();

                ReplaceDict.Add("90003,", "90002,");
                ReplaceDict.Add("90004,", "90003,");
                ReplaceDict.Add("91002,", "92001,");
                ReplaceDict.Add("90001,91003,", "90001,93001,");
                ReplaceDict.Add("90002,91002,", "90002,92001,");
                ReplaceDict.Add("90002,91003,", "90002,92002, ");

                foreach (var replaceDict in ReplaceDict)
                {
                    List<PolSourceObservationIssue> polSourceObservationIssueList = (from c in polSourceObservationIssueService.db.PolSourceObservationIssues
                                                                                     where c.ObservationInfo.Contains(replaceDict.Key)
                                                                                     select c).ToList();

                    foreach (PolSourceObservationIssue polSourceObservationIssue in polSourceObservationIssueList)
                    {
                        polSourceObservationIssue.ObservationInfo = polSourceObservationIssue.ObservationInfo.Replace(replaceDict.Key, replaceDict.Value);
                    }

                    try
                    {
                        polSourceObservationIssueService.db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        Assert.IsTrue(false);
                    }
                }
                break;
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // Act
                // in Arrange

                Assert.IsNotNull(polSourceObservationIssueService);
                Assert.IsNotNull(polSourceObservationIssueService.db);
                Assert.IsNotNull(polSourceObservationIssueService.LanguageRequest);
                Assert.IsNotNull(polSourceObservationIssueService.User);
                Assert.AreEqual(user.Identity.Name, polSourceObservationIssueService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), polSourceObservationIssueService.LanguageRequest);
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PolSourceObservationIssueModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    #region Good
                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);

                    string retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region PolSourceObservationID
                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);
                    polSourceObservationIssueModelNew.PolSourceObservationID = 0;

                    retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceObservationID), retStr);

                    polSourceObservationIssueModelNew.PolSourceObservationID = polSourceObservationIssueModelRet.PolSourceObservationID;
                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);

                    retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion PolSourceObservationID

                    #region ObservationInfo
                    int min = 1;
                    int max = 250;
                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);
                    polSourceObservationIssueModelNew.ObservationInfo = "";

                    retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ObservationInfo), retStr);

                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);
                    polSourceObservationIssueModelNew.ObservationInfo = randomService.RandomString("", max + 1);

                    retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ObservationInfo, max), retStr);

                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);
                    polSourceObservationIssueModelNew.ObservationInfo = randomService.RandomString("", max);

                    retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.AreEqual("", retStr);

                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);
                    polSourceObservationIssueModelNew.ObservationInfo = randomService.RandomString("", max - 1);

                    retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ObservationDate_Local

                    #region Ordinal
                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);
                    polSourceObservationIssueModelNew.Ordinal = min - 1;

                    retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Ordinal, min, max), retStr);

                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);
                    polSourceObservationIssueModelNew.Ordinal = max + 1;

                    retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Ordinal, min, max), retStr);

                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);
                    polSourceObservationIssueModelNew.Ordinal = max;

                    retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.IsNotNull("", retStr);

                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);
                    polSourceObservationIssueModelNew.Ordinal = max - 1;

                    retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Ordinal

                    #region PolSourceObsInfoList
                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);
                    polSourceObservationIssueModelNew.PolSourceObsInfoList = new List<PolSourceObsInfoEnum>() { (PolSourceObsInfoEnum)10000000 };

                    retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceInfo), retStr);

                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);
                    polSourceObservationIssueModelNew.PolSourceObsInfoList = new List<PolSourceObsInfoEnum>() { PolSourceObsInfoEnum.WaterTypesEqualSmallBirds };

                    retStr = polSourceObservationIssueService.PolSourceObservationIssueModelOK(polSourceObservationIssueModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion PolSourceObsInfoList
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_FillPolSourceObservationIssue_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    polSourceObservationIssueModelNew.PolSourceObservationID = polSourceObservationIssueModelRet.PolSourceObservationID;
                    FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);

                    ContactOK contactOK = polSourceObservationIssueService.IsContactOK();

                    string retStr = polSourceObservationIssueService.FillPolSourceObservationIssue(polSourceObservationIssue, polSourceObservationIssueModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, polSourceObservationIssue.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = polSourceObservationIssueService.FillPolSourceObservationIssue(polSourceObservationIssue, polSourceObservationIssueModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, polSourceObservationIssue.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_GetPolSourceObservationIssueModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                // Arrange
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // Act
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();

                    // Act
                    int polSourceObservationIssueCount = polSourceObservationIssueService.GetPolSourceObservationIssueModelCountDB();

                    // Assert
                    Assert.AreEqual(testDBService.Count + 1, polSourceObservationIssueCount);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    List<PolSourceObservationIssueModel> polSourceObservationIssueModelList = polSourceObservationIssueService.GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(polSourceObservationIssueModelRet.PolSourceObservationID);
                    Assert.IsTrue(polSourceObservationIssueModelList.Where(c => c.PolSourceObservationID == polSourceObservationIssueModelRet.PolSourceObservationID).Any());

                    int PolSourceObservationID = 0;
                    polSourceObservationIssueModelList = polSourceObservationIssueService.GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(PolSourceObservationID);
                    Assert.AreEqual(0, polSourceObservationIssueModelList.Count);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB(polSourceObservationIssueModelRet.PolSourceObservationIssueID);
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    int PolSourceObservationIssueID = 0;
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet3 = polSourceObservationIssueService.GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB(PolSourceObservationIssueID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservationIssue,
                        ServiceRes.PolSourceObservationIssueID, PolSourceObservationIssueID), 
                        polSourceObservationIssueModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_GetPolSourceObservationIssueWithPolSourceObservationIssueIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    PolSourceObservationIssue polSourceObservationIssue = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueIDDB(polSourceObservationIssueModelRet.PolSourceObservationIssueID);
                    Assert.IsNotNull(polSourceObservationIssue);

                    int PolSourceObservationIssueID = 0;
                    PolSourceObservationIssue polSourceObservationIssue2 = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueIDDB(PolSourceObservationIssueID);
                    Assert.IsNull(polSourceObservationIssue2);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_GetPolSourceObservationIssueModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    PolSourceObservationIssueModel polSourceObservationIssueModel = polSourceObservationIssueService.GetPolSourceObservationIssueModelExistDB(polSourceObservationIssueModelRet);
                    Assert.AreEqual("", polSourceObservationIssueModel.Error);

                    polSourceObservationIssueModelRet.PolSourceObservationID = 0;
                    PolSourceObservationIssueModel polSourceObservationIssueModel2 = polSourceObservationIssueService.GetPolSourceObservationIssueModelExistDB(polSourceObservationIssueModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservationIssue, 
                        ServiceRes.PolSourceObservationID + "," + ServiceRes.Ordinal, 
                        polSourceObservationIssueModelRet.PolSourceObservationID + "," + polSourceObservationIssueModelRet.Ordinal), polSourceObservationIssueModel2.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_GetPolSourceObservationIssueExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    PolSourceObservationIssue polSourceObservationIssue = polSourceObservationIssueService.GetPolSourceObservationIssueExistDB(polSourceObservationIssueModelRet);
                    Assert.IsNotNull(polSourceObservationIssue);

                    polSourceObservationIssueModelRet.PolSourceObservationID = 0;
                    PolSourceObservationIssue polSourceObservationIssue2 = polSourceObservationIssueService.GetPolSourceObservationIssueExistDB(polSourceObservationIssueModelRet);
                    Assert.IsNull(polSourceObservationIssue2);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    PolSourceObservationIssueModel polSourceObservationIssueModel = polSourceObservationIssueService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, polSourceObservationIssueModel.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddEmptyPolSourceObservationIssueDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    FormCollection fc = new FormCollection();
                    fc.Add("PolSourceObservationID", polSourceObservationIssueModelRet.PolSourceObservationID.ToString());
                    fc.Add("NextIssueOrdinal", (polSourceObservationIssueModelRet.Ordinal + 1).ToString());

                    PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddEmptyPolSourceObservationIssueDB(fc);
                    Assert.AreEqual("", polSourceObservationIssueModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddEmptyPolSourceObservationIssueDB_PolSourceObservationID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    FormCollection fc = new FormCollection();
                    fc.Add("PolSourceObservationID", "0");
                    fc.Add("NextIssueOrdinal", (polSourceObservationIssueModelRet.Ordinal + 1).ToString());

                    PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddEmptyPolSourceObservationIssueDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceObservationID), polSourceObservationIssueModelRet2.Error);

                    fc.Remove("PolSourceObservationID");
                    fc.Add("PolSourceObservationID", "");
                    fc.Add("NextIssueOrdinal", (polSourceObservationIssueModelRet.Ordinal + 1).ToString());

                    polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddEmptyPolSourceObservationIssueDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceObservationID), polSourceObservationIssueModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddEmptyPolSourceObservationIssueDB_GetPolSourceObservationIssueModelExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    FormCollection fc = new FormCollection();
                    fc.Add("PolSourceObservationID", polSourceObservationIssueModelRet.PolSourceObservationID.ToString());
                    fc.Add("NextIssueOrdinal", (polSourceObservationIssueModelRet.Ordinal + 1).ToString());

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationIssueService.GetPolSourceObservationIssueModelExistDBPolSourceObservationIssueModel = (a) =>
                        {
                            return new PolSourceObservationIssueModel() { Error = "" };
                        };

                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddEmptyPolSourceObservationIssueDB(fc);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.PolSourceObservationIssue), polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddEmptyPolSourceObservationIssueDB_PostAddPolSourceObservationIssueDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    FormCollection fc = new FormCollection();
                    fc.Add("PolSourceObservationID", polSourceObservationIssueModelRet.PolSourceObservationID.ToString());
                    fc.Add("NextIssueOrdinal", (polSourceObservationIssueModelRet.Ordinal + 1).ToString());

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationIssueService.PostAddPolSourceObservationIssueDBPolSourceObservationIssueModel = (a) =>
                        {
                            return new PolSourceObservationIssueModel() { Error = ErrorText };
                        };

                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddEmptyPolSourceObservationIssueDB(fc);
                        Assert.AreEqual(ErrorText, polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostModifyPolSourceObservationIssueDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    FormCollection fc = new FormCollection();
                    fc.Add("PolSourceObservationIssueID", polSourceObservationIssueModelRet.PolSourceObservationIssueID.ToString());
                    fc.Add("c10100", ((int)PolSourceObsInfoEnum.LandBased).ToString());
                    fc.Add("c10203", ((int)PolSourceObsInfoEnum.DistanceFromShoreInMetersBetween100And250).ToString());
                    fc.Add("c10401", ((int)PolSourceObsInfoEnum.AreaSlopeLow).ToString());
                    fc.Add("c10501", ((int)PolSourceObsInfoEnum.SourceTypeLandAgriculture).ToString());

                    PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostModifyPolSourceObservationIssueDB(fc);
                    Assert.AreEqual("", polSourceObservationIssueModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddPolSourceObservationIssueDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    polSourceObservationIssueModelRet.Ordinal = 1;
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                    Assert.AreEqual("", polSourceObservationIssueModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddPolSourceObservationIssueDB_PolSourceObservationIssueModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.PolSourceObservationIssueModelOKPolSourceObservationIssueModel = (a) =>
                        {
                            return ErrorText;
                        };

                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                        Assert.AreEqual(ErrorText, polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddPolSourceObservationIssueDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                        Assert.AreEqual(ErrorText, polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddPolSourceObservationIssueDB_GetPolSourceObservationIssueExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.GetPolSourceObservationIssueExistDBPolSourceObservationIssueModel = (a) =>
                        {
                            return new PolSourceObservationIssue();
                        };

                        polSourceObservationIssueModelRet.Ordinal = 0;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.PolSourceObservationIssue), polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddPolSourceObservationIssueDB_FillPolSourceObservationIssue_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.FillPolSourceObservationIssuePolSourceObservationIssuePolSourceObservationIssueModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                        Assert.AreEqual(ErrorText, polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddPolSourceObservationIssueDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                        Assert.AreEqual(ErrorText, polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddPolSourceObservationIssueDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.FillPolSourceObservationIssuePolSourceObservationIssuePolSourceObservationIssueModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };
                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                        Assert.IsTrue(polSourceObservationIssueModelRet2.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddPolSourceObservationIssueDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    SetupTest(contactModelListBad[0], culture);

                    polSourceObservationIssueModelRet.Ordinal = 1;
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, polSourceObservationIssueModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostAddPolSourceObservationIssueDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    SetupTest(contactModelListGood[2], culture);

                    polSourceObservationIssueModelRet.Ordinal = 1;
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, polSourceObservationIssueModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostDeletePolSourceObservationIssue_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostDeletePolSourceObservationIssueDB(polSourceObservationIssueModelRet.PolSourceObservationIssueID);
                        Assert.AreEqual(ErrorText, polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostDeletePolSourceObservationIssue_GetPolSourceObservationIssueWithPolSourceObservationIssueIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostDeletePolSourceObservationIssueDB(polSourceObservationIssueModelRet.PolSourceObservationIssueID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.PolSourceObservationIssue), polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostDeletePolSourceObservationIssue_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostDeletePolSourceObservationIssueDB(polSourceObservationIssueModelRet.PolSourceObservationIssueID);
                        Assert.AreEqual(ErrorText, polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostUpdatePolSourceObservationIssue_PolSourceObservationIssueModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.PolSourceObservationIssueModelOKPolSourceObservationIssueModel = (a) =>
                        {
                            return ErrorText;
                        };

                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                        Assert.AreEqual(ErrorText, polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostUpdatePolSourceObservationIssue_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                        Assert.AreEqual(ErrorText, polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostUpdatePolSourceObservationIssue_GetPolSourceObservationIssueWithPolSourceObservationIssueIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.PolSourceObservationIssue), polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostUpdatePolSourceObservationIssue_FillPolSourceObservationIssue_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.FillPolSourceObservationIssuePolSourceObservationIssuePolSourceObservationIssueModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                        Assert.AreEqual(ErrorText, polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationIssueService_PostUpdatePolSourceObservationIssue_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = AddPolSourceObservationIssueModel();
                    Assert.AreEqual("", polSourceObservationIssueModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationIssueService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        polSourceObservationIssueModelRet.Ordinal = 1;
                        PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModelRet);
                        Assert.AreEqual(ErrorText, polSourceObservationIssueModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public PolSourceObservationIssueModel AddPolSourceObservationIssueModel()
        {
            PolSourceObservation polSourceObservation = (from c in polSourceObservationIssueService.db.PolSourceObservations
                                                         select c).FirstOrDefault();
            Assert.IsNotNull(polSourceObservation);

            polSourceObservationIssueModelNew.PolSourceObservationID = polSourceObservation.PolSourceObservationID;
            FillPolSourceObservationIssueModel(polSourceObservationIssueModelNew);

            polSourceObservationIssueModelNew.Ordinal = 10;

            PolSourceObservationIssueModel polSourceObservationIssueModelRet = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelNew);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
            {
                return polSourceObservationIssueModelRet;
            }

            polSourceObservationIssueModelNew.PolSourceObservationIssueID = polSourceObservationIssueModelRet.PolSourceObservationIssueID;
            ComparePolSourceObservationIssueModels(polSourceObservationIssueModelNew, polSourceObservationIssueModelRet);

            return polSourceObservationIssueModelRet;
        }
        public PolSourceObservationIssueModel UpdatePolSourceObservationIssueModel(PolSourceObservationIssueModel polSourceObservationIssueModel)
        {
            FillPolSourceObservationIssueModel(polSourceObservationIssueModel);

            // Act
            PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModel);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet2.Error))
            {
                return polSourceObservationIssueModelRet2;
            }

            // Assert
            ComparePolSourceObservationIssueModels(polSourceObservationIssueModel, polSourceObservationIssueModelRet2);

            return polSourceObservationIssueModelRet2;
        }
        private void ComparePolSourceObservationIssueModels(PolSourceObservationIssueModel polSourceObservationIssueModelNew, PolSourceObservationIssueModel polSourceObservationIssueModelRet)
        {
            Assert.AreEqual(polSourceObservationIssueModelNew.PolSourceObservationIssueID, polSourceObservationIssueModelRet.PolSourceObservationIssueID);
            Assert.AreEqual(polSourceObservationIssueModelNew.PolSourceObservationID, polSourceObservationIssueModelRet.PolSourceObservationID);
            Assert.AreEqual(polSourceObservationIssueModelNew.ObservationInfo, polSourceObservationIssueModelRet.ObservationInfo);
            Assert.AreEqual(polSourceObservationIssueModelNew.Ordinal, polSourceObservationIssueModelRet.Ordinal);
        }
        private void FillPolSourceObservationIssueModel(PolSourceObservationIssueModel polSourceObservationIssueModel)
        {
            // Act
            polSourceObservationIssueModel.PolSourceObservationID = polSourceObservationIssueModel.PolSourceObservationID;
            polSourceObservationIssueModel.Ordinal = 0;
            polSourceObservationIssueModel.PolSourceObsInfoList = new List<PolSourceObsInfoEnum>()
            {
                PolSourceObsInfoEnum.LandBased,
                PolSourceObsInfoEnum.DistanceFromShoreInMetersBetween100And250,
                PolSourceObsInfoEnum.AreaSlopeLow,
                PolSourceObsInfoEnum.SourceTypeLandAgriculture,
                PolSourceObsInfoEnum.AgricultureCrop,
                PolSourceObsInfoEnum.CropFood,
                PolSourceObsInfoEnum.AreaSizeSmall,
                PolSourceObsInfoEnum.FecalSourceLivestock,
                PolSourceObsInfoEnum.TypesEqualLargeDomestic,
                PolSourceObsInfoEnum.NumberPresentLessThan5,
                PolSourceObsInfoEnum.StatusPotential,
                PolSourceObsInfoEnum.RiskHigh,
            };
            polSourceObservationIssueModel.ObservationInfo = 
                ((int)PolSourceObsInfoEnum.LandBased) + "," +
                ((int)PolSourceObsInfoEnum.DistanceFromShoreInMetersBetween100And250) + "," +
                ((int)PolSourceObsInfoEnum.AreaSlopeLow) + "," +
                ((int)PolSourceObsInfoEnum.SourceTypeLandAgriculture) + "," +
                ((int)PolSourceObsInfoEnum.AgricultureCrop) + "," +
                ((int)PolSourceObsInfoEnum.CropFood) + "," +
                ((int)PolSourceObsInfoEnum.AreaSizeSmall) + "," +
                ((int)PolSourceObsInfoEnum.FecalSourceLivestock) + "," +
                ((int)PolSourceObsInfoEnum.TypesEqualLargeDomestic) + "," +
                ((int)PolSourceObsInfoEnum.NumberPresentLessThan5) + "," +
                ((int)PolSourceObsInfoEnum.StatusPotential) + "," +
                ((int)PolSourceObsInfoEnum.RiskHigh + ",");

            // Assert
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObservationID != 0);
            Assert.IsTrue(polSourceObservationIssueModel.Ordinal == 0);
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObsInfoList[0] == PolSourceObsInfoEnum.LandBased);
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObsInfoList[1] == PolSourceObsInfoEnum.DistanceFromShoreInMetersBetween100And250);
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObsInfoList[2] == PolSourceObsInfoEnum.AreaSlopeLow);
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObsInfoList[3] == PolSourceObsInfoEnum.SourceTypeLandAgriculture);
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObsInfoList[4] == PolSourceObsInfoEnum.AgricultureCrop);
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObsInfoList[5] == PolSourceObsInfoEnum.CropFood);
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObsInfoList[6] == PolSourceObsInfoEnum.AreaSizeSmall);
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObsInfoList[7] == PolSourceObsInfoEnum.FecalSourceLivestock);
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObsInfoList[8] == PolSourceObsInfoEnum.TypesEqualLargeDomestic);
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObsInfoList[9] == PolSourceObsInfoEnum.NumberPresentLessThan5);
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObsInfoList[10] == PolSourceObsInfoEnum.StatusPotential);
            Assert.IsTrue(polSourceObservationIssueModel.PolSourceObsInfoList[11] == PolSourceObsInfoEnum.RiskHigh);
            Assert.IsTrue(polSourceObservationIssueModel.ObservationInfo.Length > 0);

        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            polSourceObservationIssueService = new PolSourceObservationIssueService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            polSourceObservationIssueModelNew = new PolSourceObservationIssueModel();
            polSourceObservationIssue = new PolSourceObservationIssue();
        }
        private void SetupShim()
        {
            shimPolSourceObservationIssueService = new ShimPolSourceObservationIssueService(polSourceObservationIssueService);
            shimTVItemService = new ShimTVItemService(polSourceObservationIssueService._TVItemService);
        }
        #endregion Functions private
    }
}
