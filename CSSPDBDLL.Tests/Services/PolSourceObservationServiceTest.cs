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
    /// Summary description for PolSourceObservationServiceTest
    /// </summary>
    [TestClass]
    public class PolSourceObservationServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "PolSourceObservation";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private PolSourceObservationService polSourceObservationService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private TVItemService tvItemService { get; set; }
        private PolSourceObservationModel polSourceObservationModelNew { get; set; }
        private PolSourceObservation polSourceObservation { get; set; }
        private ShimPolSourceObservationService shimPolSourceObservationService { get; set; }
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
        public PolSourceObservationServiceTest()
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
        //[TestMethod]
        //public void Get_Path_ID_of_A_Certain_ID()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        // Arrange 
        //        SetupTest(contactModelListGood[0], culture);

        //        Dictionary<string, string> ReplaceDict = new Dictionary<string, string>();

        //        ReplaceDict.Add("1001,1101,", "10101,10201,10501,10601,");
        //        ReplaceDict.Add("1001,1102,", "10101,10201,10501,10602,");
        //        ReplaceDict.Add("1002,1201,", "10101,10201,10502,11101,");
        //        ReplaceDict.Add("1002,1202,", "10101,10201,10502,11102,");
        //        ReplaceDict.Add("1003,1301,", "10101,10201,10503,11201, ");
        //        ReplaceDict.Add("1003,1302,", "10101,10201,10503,11202,");
        //        ReplaceDict.Add("1003,1303,", "10101,10201,10503,11203,");
        //        ReplaceDict.Add("1003,1304,", "10101,10201,10503,11204,");
        //        ReplaceDict.Add("1003,1305,", "10101,10201,10503,11205,");
        //        ReplaceDict.Add("1004,1401,", "10102,10301,14002,");
        //        ReplaceDict.Add("1004,1402,", "10102,10301,14004,");
        //        ReplaceDict.Add("1004,1403,", "10101,10201,10504,11402,");
        //        ReplaceDict.Add("1004,1404,", "10101,10201,10504,11403,");
        //        ReplaceDict.Add("1004,1405,", "10102,10301,14003,12202,");
        //        ReplaceDict.Add("1004,1406,", "10101,10201,10504,11404,");
        //        ReplaceDict.Add("1004,1407,", "10102,10301,14006,");
        //        ReplaceDict.Add("1005,1501,", "10101,10201,10505,11601,");
        //        ReplaceDict.Add("1005,1502,", "10101,10201,10505,11602,");
        //        ReplaceDict.Add("1005,1503,", "10101,10201,10505,11603,");
        //        ReplaceDict.Add("1005,1504,", "10101,10201,10505,11604,");
        //        ReplaceDict.Add("1006,1601,", "10101,10201,10506,11807,");
        //        ReplaceDict.Add("1006,1602,", "10101,10201,10509,");
        //        ReplaceDict.Add("1006,1603,", "10101,10201,10506,11807,12203,");
        //        ReplaceDict.Add("1006,1604,", "10101,10201,10506,11807,12212,");
        //        ReplaceDict.Add("1006,1605,", "10101,10201,10506,11803,");
        //        ReplaceDict.Add("1007,1701,", "10101,10201,12506,12506,");
        //        ReplaceDict.Add("1008,1801,", "10101,10201,10507,12001,");
        //        ReplaceDict.Add("1008,1802,", "10101,10201,10507,12006,");
        //        ReplaceDict.Add("1008,1803,", "10101,10201,10507,12002,");
        //        ReplaceDict.Add("1008,1804,", "10101,10201,10507,12003,");
        //        ReplaceDict.Add("1008,1805,", "10101,10201,10507,12004,");
        //        ReplaceDict.Add("1008,1806,", "10101,10201,10507,12005,");
        //        ReplaceDict.Add("1009,1901,", "10101,10201,10508,12101,");
        //        ReplaceDict.Add("1009,1902,", "10101,10201,10508,12102,");
        //        ReplaceDict.Add("1009,1903,", "10101,10201,10508,12103,");
        //        ReplaceDict.Add("1001,0,", "10104,10201,10501,");
        //        ReplaceDict.Add("1002,0,", "10104,10201,10502,");
        //        ReplaceDict.Add("1003,0,", "10101,10201,10503,");
        //        ReplaceDict.Add("1004,0,", "10104,10201,10504,");
        //        ReplaceDict.Add("1005,0,", "10101,10201,10505,");
        //        ReplaceDict.Add("1006,0,", "10101,10201,10506,");
        //        ReplaceDict.Add("1008,0,", "10101,10201,10507,");
        //        ReplaceDict.Add("1009,0,", "10101,10201,10508,");
        //        ReplaceDict.Add("0,0,", "10101,");

        //        foreach (var replaceDict in ReplaceDict)
        //        {
        //            List<PolSourceObservation> polSourceObservationList = (from c in polSourceObservationService.db.PolSourceObservations
        //                                                                   where c.ObservationInfo.Contains(replaceDict.Key)
        //                                                                   select c).ToList();

        //            foreach (PolSourceObservation polSourceObservation in polSourceObservationList)
        //            {
        //                polSourceObservation.ObservationInfo = replaceDict.Value;
        //            }

        //            try
        //            {
        //                polSourceObservationService.db.SaveChanges();
        //            }
        //            catch (Exception)
        //            {
        //                Assert.IsTrue(false);
        //            }
        //        }
        //        break;
        //    }
        //}
        [TestMethod]
        public void PolSourceObservationService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // in Arrange

                Assert.IsNotNull(polSourceObservationService);
                Assert.IsNotNull(polSourceObservationService.db);
                Assert.IsNotNull(polSourceObservationService.LanguageRequest);
                Assert.IsNotNull(polSourceObservationService.User);
                Assert.AreEqual(user.Identity.Name, polSourceObservationService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), polSourceObservationService.LanguageRequest);
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                    Assert.AreEqual("", polSourceObservationModelRet.Error);

                    #region Good
                    polSourceObservationModelNew.PolSourceSiteTVItemID = polSourceObservationModelRet.PolSourceSiteTVItemID;
                    FillPolSourceObservationModel(polSourceObservationModelNew);

                    string retStr = polSourceObservationService.PolSourceObservationModelOK(polSourceObservationModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region PolSourceSiteTVItemID
                    FillPolSourceObservationModel(polSourceObservationModelNew);
                    polSourceObservationModelNew.PolSourceSiteTVItemID = 0;

                    retStr = polSourceObservationService.PolSourceObservationModelOK(polSourceObservationModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteID), retStr);

                    polSourceObservationModelNew.PolSourceSiteTVItemID = polSourceObservationModelRet.PolSourceSiteTVItemID;
                    FillPolSourceObservationModel(polSourceObservationModelNew);

                    retStr = polSourceObservationService.PolSourceObservationModelOK(polSourceObservationModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion PolSourceSiteTVItemID

                    #region ObservationDate_Local
                    FillPolSourceObservationModel(polSourceObservationModelNew);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationService.FieldCheckNotNullDateTimeNullableOfDateTimeString = (a, b) =>
                        {
                            return ErrorText;
                        };

                        retStr = polSourceObservationService.PolSourceObservationModelOK(polSourceObservationModelNew);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                    #endregion ObservationDate_Local

                    #region ContactTVItemID
                    FillPolSourceObservationModel(polSourceObservationModelNew);
                    polSourceObservationModelNew.ContactTVItemID = 0;

                    retStr = polSourceObservationService.PolSourceObservationModelOK(polSourceObservationModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteID), retStr);

                    FillPolSourceObservationModel(polSourceObservationModelNew);
                    polSourceObservationModelNew.ContactTVItemID = 1;

                    retStr = polSourceObservationService.PolSourceObservationModelOK(polSourceObservationModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion ContactTVItemID
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_FillPolSourceObservation_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelPolSourceSite = randomService.RandomTVItem(TVTypeEnum.PolSourceSite);
                    Assert.AreEqual("", tvItemModelPolSourceSite.Error);

                    polSourceObservationModelNew.PolSourceSiteTVItemID = tvItemModelPolSourceSite.TVItemID;
                    FillPolSourceObservationModel(polSourceObservationModelNew);

                    ContactOK contactOK = polSourceObservationService.IsContactOK();

                    string retStr = polSourceObservationService.FillPolSourceObservation(polSourceObservation, polSourceObservationModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, polSourceObservation.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = polSourceObservationService.FillPolSourceObservation(polSourceObservation, polSourceObservationModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, polSourceObservation.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_GetPolSourceObservationModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    int polSourceObservationCount = polSourceObservationService.GetPolSourceObservationModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, polSourceObservationCount);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_GetPolSourceObservationModelListWithPolSourceSiteTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    List<PolSourceObservationModel> polSourceObservationModelList = polSourceObservationService.GetPolSourceObservationModelListWithPolSourceSiteTVItemIDDB(polSourceObservationModelRet.PolSourceSiteTVItemID);
                    Assert.IsTrue(polSourceObservationModelList.Where(c => c.PolSourceSiteTVItemID == polSourceObservationModelRet.PolSourceSiteTVItemID).Any());

                    int PolSourceSiteTVItemID = 0;
                    polSourceObservationModelList = polSourceObservationService.GetPolSourceObservationModelListWithPolSourceSiteTVItemIDDB(PolSourceSiteTVItemID);
                    Assert.AreEqual(0, polSourceObservationModelList.Count);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_GetPolSourceObservationModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    polSourceObservationModelRet = polSourceObservationService.GetPolSourceObservationModelExistDB(polSourceObservationModelRet);
                    Assert.AreEqual("", polSourceObservationModelRet.Error);

                    polSourceObservationModelRet.PolSourceSiteTVItemID = 0;
                    PolSourceObservationModel polSourceObservationModelRet2 = polSourceObservationService.GetPolSourceObservationModelExistDB(polSourceObservationModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservation, ServiceRes.PolSourceSiteTVItemID + "," + ServiceRes.ObservationDate_Local, polSourceObservationModelRet.PolSourceSiteTVItemID + "," + polSourceObservationModelRet.ObservationDate_Local), polSourceObservationModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_GetPolSourceObservationModelWithPolSourceObservationIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    PolSourceObservationModel polSourceObservationModelRet2 = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(polSourceObservationModelRet.PolSourceObservationID);
                    Assert.AreEqual(polSourceObservationModelRet.PolSourceObservationID, polSourceObservationModelRet2.PolSourceObservationID);

                    int PolSourceObservationID = 0;
                    PolSourceObservationModel polSourceObservationModelRet3 = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(PolSourceObservationID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservation, ServiceRes.PolSourceObservationID, PolSourceObservationID), polSourceObservationModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_GetPolSourceObservationModelFirstWithContactTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                    Assert.AreEqual("", polSourceObservationModelRet.Error);

                    polSourceObservationModelRet.ContactTVItemID = contactModelListGood[0].ContactTVItemID;
                    polSourceObservationModelRet = polSourceObservationService.PostUpdatePolSourceObservationDB(polSourceObservationModelRet);
                    Assert.AreEqual("", polSourceObservationModelRet.Error);

                    PolSourceObservationModel polSourceObservationModelFirst = polSourceObservationService.GetPolSourceObservationModelFirstWithContactTVItemIDDB(polSourceObservationModelRet.ContactTVItemID);
                    Assert.IsTrue(polSourceObservationModelFirst.PolSourceObservationID > 0);

                    int ContactTVItemID = 0;
                    polSourceObservationModelFirst = polSourceObservationService.GetPolSourceObservationModelFirstWithContactTVItemIDDB(ContactTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservation, ServiceRes.ContactTVItemID, ContactTVItemID), polSourceObservationModelFirst.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_GetPolSourceObservationModelListWithContactTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                    Assert.AreEqual("", polSourceObservationModelRet.Error);

                    polSourceObservationModelRet.ContactTVItemID = contactModelListGood[0].ContactTVItemID;
                    polSourceObservationModelRet = polSourceObservationService.PostUpdatePolSourceObservationDB(polSourceObservationModelRet);
                    Assert.AreEqual("", polSourceObservationModelRet.Error);

                    List<PolSourceObservationModel> polSourceObservationModelList = polSourceObservationService.GetPolSourceObservationModelListWithContactTVItemIDDB(polSourceObservationModelRet.ContactTVItemID);
                    Assert.IsTrue(polSourceObservationModelList.Where(c => c.PolSourceObservationID == polSourceObservationModelRet.PolSourceObservationID).Any());

                    int ContactTVItemID = 0;
                    polSourceObservationModelList = polSourceObservationService.GetPolSourceObservationModelListWithContactTVItemIDDB(ContactTVItemID);
                    Assert.IsTrue(polSourceObservationModelList.Count == 0);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_GetPolSourceObservationWithPolSourceObservationIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    PolSourceObservation polSourceObservationRet2 = polSourceObservationService.GetPolSourceObservationWithPolSourceObservationIDDB(polSourceObservationModelRet.PolSourceObservationID);
                    Assert.AreEqual(polSourceObservationModelRet.PolSourceObservationID, polSourceObservationRet2.PolSourceObservationID);

                    int PolSourceObservationID = 0;
                    polSourceObservationRet2 = polSourceObservationService.GetPolSourceObservationWithPolSourceObservationIDDB(PolSourceObservationID);
                    Assert.IsNull(polSourceObservationRet2);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_GetPolSourceObservationExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    PolSourceObservation polSourceObservationRet = polSourceObservationService.GetPolSourceObservationExistDB(polSourceObservationModelRet);
                    Assert.AreEqual(polSourceObservationModelRet.PolSourceObservationID, polSourceObservationRet.PolSourceObservationID);

                    polSourceObservationModelRet.PolSourceSiteTVItemID = 0;
                    PolSourceObservation polSourceObservationRet2 = polSourceObservationService.GetPolSourceObservationExistDB(polSourceObservationModelRet);
                    Assert.IsNull(polSourceObservationRet2);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationAddOrModifyDB_Add_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceObservationID"] = "0";
                    fc["ObsDay"] = (int.Parse(fc["ObsDay"]) + 1).ToString();

                    PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual("", polSourceObservationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationAddOrModifyDB_Add_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceObservationID"] = "0";
                    fc["ObsDay"] = (int.Parse(fc["ObsDay"]) + 1).ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationAddOrModifyDB_Add_PolSourceSiteTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceObservationID"] = "0";
                    fc["ObsDay"] = (int.Parse(fc["ObsDay"]) + 1).ToString();
                    fc.Remove("PolSourceSiteTVItemID");

                    PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteTVItemID), polSourceObservationModelRet.Error);

                    fc["PolSourceSiteTVItemID"] = "";

                    polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteTVItemID), polSourceObservationModelRet.Error);

                    fc["PolSourceSiteTVItemID"] = "0";

                    polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteTVItemID), polSourceObservationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationAddOrModifyDB_Add_PolSourceObservationID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceObservationID"] = "0";
                    fc["ObsDay"] = (int.Parse(fc["ObsDay"]) + 1).ToString();
                    fc.Remove("PolSourceObservationID");

                    PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceObservationID), polSourceObservationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationAddOrModifyDB_Add_ObsYear_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceObservationID"] = "0";
                    fc["ObsDay"] = (int.Parse(fc["ObsDay"]) + 1).ToString();
                    fc.Remove("ObsYear");

                    PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Year), polSourceObservationModelRet.Error);

                    fc["ObsYear"] = "";

                    polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Year), polSourceObservationModelRet.Error);

                    fc["ObsYear"] = "0";

                    polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Year), polSourceObservationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationAddOrModifyDB_Add_ObsMonth_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceObservationID"] = "0";
                    fc["ObsDay"] = (int.Parse(fc["ObsDay"]) + 1).ToString();
                    fc.Remove("ObsMonth");

                    PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Month), polSourceObservationModelRet.Error);

                    fc["ObsMonth"] = "";

                    polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Month), polSourceObservationModelRet.Error);

                    fc["ObsMonth"] = "0";

                    polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Month), polSourceObservationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationAddOrModifyDB_Add_ObsDay_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceObservationID"] = "0";
                    fc["ObsDay"] = (int.Parse(fc["ObsDay"]) + 1).ToString();
                    fc.Remove("ObsDay");

                    PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Day), polSourceObservationModelRet.Error);

                    fc["ObsDay"] = "";

                    polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Day), polSourceObservationModelRet.Error);

                    fc["ObsDay"] = "0";

                    polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Day), polSourceObservationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationAddOrModifyDB_Add_PostAddPolSourceObservationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceObservationID"] = "0";
                    fc["ObsDay"] = (int.Parse(fc["ObsDay"]) + 1).ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationService.PostAddPolSourceObservationDBPolSourceObservationModel = (a) =>
                        {
                            return new PolSourceObservationModel() { Error = ErrorText };
                        };

                        PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationAddOrModifyDB_Add_PostAddPolSourceObservationIssueDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    fc["PolSourceObservationID"] = "0";
                    fc["ObsDay"] = (int.Parse(fc["ObsDay"]) + 1).ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationIssueService.PostAddPolSourceObservationIssueDBPolSourceObservationIssueModel = (a) =>
                        {
                            return new PolSourceObservationIssueModel() { Error = ErrorText };
                        };

                        PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationAddOrModifyDB_Modify_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    //fc["PolSourceObservationID"] = "0";
                    fc["ObsDay"] = (int.Parse(fc["ObsDay"]) + 1).ToString();

                    PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                    Assert.AreEqual("", polSourceObservationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationAddOrModifyDB_Modify_PostUpdatePolSourceObservationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = GetFormCollectionForPolSourceSiteSaveAllDB(culture.TwoLetterISOLanguageName);
                    //fc["PolSourceObservationID"] = "0";
                    fc["ObsDay"] = (int.Parse(fc["ObsDay"]) + 1).ToString();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationService.PostUpdatePolSourceObservationDBPolSourceObservationModel = (a) =>
                        {
                            return new PolSourceObservationModel() { Error = ErrorText };
                        };

                        PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationCopyDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssue polSourceObservationIssue = (from c in polSourceObservationService.db.PolSourceObservationIssues
                                                                           select c).FirstOrDefault();

                    Assert.IsNotNull(polSourceObservationIssue);

                    PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationCopyDB(polSourceObservationIssue.PolSourceObservationID);
                    Assert.AreEqual("", polSourceObservationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationCopyDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssue polSourceObservationIssue = (from c in polSourceObservationService.db.PolSourceObservationIssues
                                                                           select c).FirstOrDefault();

                    Assert.IsNotNull(polSourceObservationIssue);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationCopyDB(polSourceObservationIssue.PolSourceObservationID);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationCopyDB_GetPolSourceObservationModelWithPolSourceObservationIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssue polSourceObservationIssue = (from c in polSourceObservationService.db.PolSourceObservationIssues
                                                                           select c).FirstOrDefault();

                    Assert.IsNotNull(polSourceObservationIssue);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDBInt32 = (a) =>
                        {
                            return new PolSourceObservationModel() { Error = ErrorText };
                        };

                        PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationCopyDB(polSourceObservationIssue.PolSourceObservationID);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationCopyDB_GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssue polSourceObservationIssue = (from c in polSourceObservationService.db.PolSourceObservationIssues
                                                                           select c).FirstOrDefault();

                    Assert.IsNotNull(polSourceObservationIssue);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationIssueService.GetPolSourceObservationIssueModelListWithPolSourceObservationIDDBInt32 = (a) =>
                        {
                            return new List<PolSourceObservationIssueModel>();
                        };

                        PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationCopyDB(polSourceObservationIssue.PolSourceObservationID);
                        Assert.AreEqual(string.Format(ServiceRes._ShouldBeMoreThan_, ServiceRes.PolSourceObservationIssue, 0.ToString()), polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationCopyDB_PostAddPolSourceObservationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssue polSourceObservationIssue = (from c in polSourceObservationService.db.PolSourceObservationIssues
                                                                           select c).FirstOrDefault();

                    Assert.IsNotNull(polSourceObservationIssue);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationService.PostAddPolSourceObservationDBPolSourceObservationModel = (a) =>
                        {
                            return new PolSourceObservationModel() { Error = ErrorText };
                        };

                        PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationCopyDB(polSourceObservationIssue.PolSourceObservationID);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PolSourceObservationCopyDB_PostAddPolSourceObservationIssueDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationIssue polSourceObservationIssue = (from c in polSourceObservationService.db.PolSourceObservationIssues
                                                                           select c).FirstOrDefault();

                    Assert.IsNotNull(polSourceObservationIssue);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimPolSourceObservationIssueService.PostAddPolSourceObservationIssueDBPolSourceObservationIssueModel = (a) =>
                        {
                            return new PolSourceObservationIssueModel() { Error = ErrorText };
                        };

                        PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PolSourceObservationCopyDB(polSourceObservationIssue.PolSourceObservationID);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostAddUpdateDeletePolSourceObservation_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    PolSourceObservationModel polSourceObservationModelRet2 = UpdatePolSourceObservationModel(polSourceObservationModelRet);

                    PolSourceObservationModel polSourceObservationModelRet3 = polSourceObservationService.PostDeletePolSourceObservationDB(polSourceObservationModelRet2.PolSourceObservationID);
                    Assert.AreEqual("", polSourceObservationModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostAddPolSourceObservationDB_PolSourceObservationModelOK_Error_Test()
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
                        shimPolSourceObservationService.PolSourceObservationModelOKPolSourceObservationModel = (a) =>
                        {
                            return ErrorText;
                        };

                        PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostAddPolSourceObservationDB_IsContactOK_Error_Test()
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
                        shimPolSourceObservationService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostAddPolSourceObservationDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
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

                        PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostAddPolSourceObservationDB_GetPolSourceObservationExistDB_Error_Test()
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
                        shimPolSourceObservationService.GetPolSourceObservationExistDBPolSourceObservationModel = (a) =>
                        {
                            return new PolSourceObservation();
                        };

                        PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.PolSourceObservation), polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostAddPolSourceObservationDB_FillPolSourceObservation_Error_Test()
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
                        shimPolSourceObservationService.FillPolSourceObservationPolSourceObservationPolSourceObservationModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostAddPolSourceObservationDB_DoAddChanges_Error_Test()
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
                        shimPolSourceObservationService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostAddPolSourceObservationDB_Add_Error_Test()
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
                        shimPolSourceObservationService.FillPolSourceObservationPolSourceObservationPolSourceObservationModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                        Assert.IsTrue(polSourceObservationModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostAddPolSourceObservationDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                    Assert.IsNotNull(polSourceObservationModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, polSourceObservationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostAddPolSourceObservationDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                    Assert.IsNotNull(polSourceObservationModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, polSourceObservationModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostDeletePolSourceObservation_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        PolSourceObservationModel polSourceObservationModelRet2 = polSourceObservationService.PostDeletePolSourceObservationDB(polSourceObservationModelRet.PolSourceObservationID);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostDeletePolSourceObservation_GetPolSourceObservationWithPolSourceObservationIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimPolSourceObservationService.GetPolSourceObservationWithPolSourceObservationIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        PolSourceObservationModel polSourceObservationModelRet2 = polSourceObservationService.PostDeletePolSourceObservationDB(polSourceObservationModelRet.PolSourceObservationID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.PolSourceObservation), polSourceObservationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostDeletePolSourceObservation_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        PolSourceObservationModel polSourceObservationModelRet2 = polSourceObservationService.PostDeletePolSourceObservationDB(polSourceObservationModelRet.PolSourceObservationID);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostUpdatePolSourceObservation_PolSourceObservationModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationService.PolSourceObservationModelOKPolSourceObservationModel = (a) =>
                        {
                            return ErrorText;
                        };

                        PolSourceObservationModel polSourceObservationModelRet2 = UpdatePolSourceObservationModel(polSourceObservationModelRet);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostUpdatePolSourceObservation_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        PolSourceObservationModel polSourceObservationModelRet2 = UpdatePolSourceObservationModel(polSourceObservationModelRet);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostUpdatePolSourceObservation_GetPolSourceObservationWithPolSourceObservationIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimPolSourceObservationService.GetPolSourceObservationWithPolSourceObservationIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        PolSourceObservationModel polSourceObservationModelRet2 = UpdatePolSourceObservationModel(polSourceObservationModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.PolSourceObservation), polSourceObservationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostUpdatePolSourceObservation_FillPolSourceObservation_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationService.FillPolSourceObservationPolSourceObservationPolSourceObservationModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        PolSourceObservationModel polSourceObservationModelRet2 = UpdatePolSourceObservationModel(polSourceObservationModelRet);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostUpdatePolSourceObservation_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimPolSourceObservationService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        PolSourceObservationModel polSourceObservationModelRet2 = UpdatePolSourceObservationModel(polSourceObservationModelRet);
                        Assert.AreEqual(ErrorText, polSourceObservationModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostAddPolSourceObservationAndPolSourceObservationLanguageDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, polSourceObservationModelRet.Error);

                }
            }
        }
        [TestMethod]
        public void PolSourceObservationService_PostAddPolSourceObservationAndPolSourceObservationLanguageDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    PolSourceObservationModel polSourceObservationModelRet = AddPolSourceObservationModel();
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, polSourceObservationModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public PolSourceObservationModel AddPolSourceObservationModel()
        {
            TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.PolSourceSite);
            Assert.AreEqual("", tvItemModel.Error);

            polSourceObservationModelNew.PolSourceSiteTVItemID = tvItemModel.TVItemID;
            FillPolSourceObservationModel(polSourceObservationModelNew);

            PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PostAddPolSourceObservationDB(polSourceObservationModelNew);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModelRet.Error))
            {
                return polSourceObservationModelRet;
            }

            polSourceObservationModelNew.PolSourceObservationID = polSourceObservationModelRet.PolSourceObservationID;
            ComparePolSourceObservationModels(polSourceObservationModelNew, polSourceObservationModelRet);

            return polSourceObservationModelRet;
        }
        public FormCollection GetFormCollectionForPolSourceSiteSaveAllDB(string LanguageRequest)
        {
            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
            Assert.AreEqual("", tvItemModelRoot.Error);

            TVItemModel tvItemModelSubsector = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "NB-01-010-001", TVTypeEnum.Subsector);
            Assert.AreEqual("", tvItemModelSubsector.Error);

            TVItemModel tvItemModelPolSourceSite = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.PolSourceSite).FirstOrDefault();
            Assert.AreEqual("", tvItemModelPolSourceSite.Error);

            PolSourceObservationModel polSourceObservationModelNew = new PolSourceObservationModel()
            {
                PolSourceSiteTVItemID = tvItemModelPolSourceSite.TVItemID,
                ObservationDate_Local = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                ContactTVItemID = tvItemService.GetContactLoggedInDB().ContactTVItemID,
                Observation_ToBeDeleted = "empty",
            };

            PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PostAddPolSourceObservationDB(polSourceObservationModelNew);
            Assert.AreEqual("", polSourceObservationModelRet.Error);

            FormCollection fc = new FormCollection();
            fc.Add("PolSourceSiteTVItemID", tvItemModelPolSourceSite.TVItemID.ToString());
            fc.Add("PolSourceObservationID", polSourceObservationModelRet.PolSourceObservationID.ToString());
            fc.Add("ObsYear", polSourceObservationModelRet.ObservationDate_Local.Year.ToString());
            fc.Add("ObsMonth", polSourceObservationModelRet.ObservationDate_Local.Month.ToString());
            fc.Add("ObsDay", polSourceObservationModelRet.ObservationDate_Local.Day.ToString());

            return fc;

        }
        public PolSourceObservationModel UpdatePolSourceObservationModel(PolSourceObservationModel polSourceObservationModel)
        {
            FillPolSourceObservationModel(polSourceObservationModel);

            PolSourceObservationModel polSourceObservationModelRet2 = polSourceObservationService.PostUpdatePolSourceObservationDB(polSourceObservationModel);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModelRet2.Error))
            {
                return polSourceObservationModelRet2;
            }

            ComparePolSourceObservationModels(polSourceObservationModel, polSourceObservationModelRet2);

            return polSourceObservationModelRet2;
        }
        private void ComparePolSourceObservationModels(PolSourceObservationModel polSourceObservationModelNew, PolSourceObservationModel polSourceObservationModelRet)
        {
            Assert.AreEqual(polSourceObservationModelNew.PolSourceObservationID, polSourceObservationModelRet.PolSourceObservationID);
            Assert.AreEqual(polSourceObservationModelNew.PolSourceSiteTVItemID, polSourceObservationModelRet.PolSourceSiteTVItemID);
            Assert.AreEqual(polSourceObservationModelNew.ObservationDate_Local, polSourceObservationModelRet.ObservationDate_Local);
            Assert.AreEqual(polSourceObservationModelNew.ContactTVItemID, polSourceObservationModelRet.ContactTVItemID);
        }
        private void FillPolSourceObservationModel(PolSourceObservationModel polSourceObservationModel)
        {
            polSourceObservationModel.PolSourceSiteTVItemID = polSourceObservationModel.PolSourceSiteTVItemID;
            polSourceObservationModel.ObservationDate_Local = randomService.RandomDateTime();
            polSourceObservationModel.ContactTVItemID = randomService.RandomTVItem(TVTypeEnum.Contact).TVItemID;
            polSourceObservationModel.Observation_ToBeDeleted = randomService.RandomString("", 30);
            Assert.IsTrue(polSourceObservationModel.PolSourceSiteTVItemID != 0);
            Assert.IsTrue(polSourceObservationModel.ObservationDate_Local != null);
            Assert.IsTrue(polSourceObservationModel.ContactTVItemID != 0);
            Assert.IsTrue(polSourceObservationModel.Observation_ToBeDeleted.Length > 0);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            polSourceObservationService = new PolSourceObservationService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            polSourceObservationModelNew = new PolSourceObservationModel();
            polSourceObservation = new PolSourceObservation();
        }
        private void SetupShim()
        {
            shimPolSourceObservationService = new ShimPolSourceObservationService(polSourceObservationService);
            shimPolSourceObservationIssueService = new ShimPolSourceObservationIssueService(polSourceObservationService._PolSourceObservationIssueService);
            shimTVItemService = new ShimTVItemService(polSourceObservationService._TVItemService);
        }
        #endregion Functions private
    }
}

