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
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MapInfoPointServiceTest
    /// </summary>
    [TestClass]
    public class MapInfoPointServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MapInfoPoint";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MapInfoService mapInfoService { get; set; }
        private MapInfoPointService mapInfoPointService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MapInfoPointModel mapInfoPointModelNew { get; set; }
        private MapInfoPoint mapInfoPoint { get; set; }
        private ShimMapInfoPointService shimMapInfoPointService { get; set; }
        private MapInfoServiceTest mapInfoServiceTest { get; set; }
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
        public MapInfoPointServiceTest()
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
        public void MapInfoPointService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(mapInfoPointService);
                Assert.IsNotNull(mapInfoPointService.db);
                Assert.IsNotNull(mapInfoPointService.LanguageRequest);
                Assert.IsNotNull(mapInfoPointService.User);
                Assert.AreEqual(user.Identity.Name, mapInfoPointService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mapInfoPointService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MapInfoPointService_MapInfoPointModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = mapInfoServiceTest.AddMapInfoModel();

                    #region Good
                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);

                    string retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region MapInfoPolyID
                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);
                    mapInfoPointModelNew.MapInfoID = 0;

                    retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoID), retStr);

                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);
                    mapInfoPointModelNew.MapInfoID = 1;

                    retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion MapInfoPolyID

                    #region Lat
                    double MinDbl = -90D;
                    double MaxDbl = 90D;
                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);
                    mapInfoPointModelNew.Lat = MinDbl - 1;

                    retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Lat, MinDbl, MaxDbl), retStr);

                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);
                    mapInfoPointModelNew.Lat = MaxDbl + 1;

                    retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Lat, MinDbl, MaxDbl), retStr);

                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);
                    mapInfoPointModelNew.Lat = MaxDbl - 1;

                    retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual("", retStr);

                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);
                    mapInfoPointModelNew.Lat = MinDbl;

                    retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual("", retStr);

                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);
                    mapInfoPointModelNew.Lat = MaxDbl;

                    retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Lat

                    #region Lng
                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);
                    MinDbl = -180D;
                    MaxDbl = 180D;
                    mapInfoPointModelNew.Lng = MinDbl - 1;

                    retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Lng, MinDbl, MaxDbl), retStr);

                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);
                    mapInfoPointModelNew.Lng = MaxDbl + 1;

                    retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Lng, MinDbl, MaxDbl), retStr);

                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);
                    mapInfoPointModelNew.Lng = MaxDbl - 1;

                    retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual("", retStr);

                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);
                    mapInfoPointModelNew.Lng = MinDbl;

                    retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual("", retStr);

                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);
                    mapInfoPointModelNew.Lng = MaxDbl;

                    retStr = mapInfoPointService.MapInfoPointModelOK(mapInfoPointModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion Lng
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_FillMapInfoPoint_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = mapInfoServiceTest.AddMapInfoModel();

                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);

                    ContactOK contactOK = mapInfoPointService.IsContactOK();

                    string retStr = mapInfoPointService.FillMapInfoPoint(mapInfoPoint, mapInfoPointModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mapInfoPoint.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mapInfoPointService.FillMapInfoPoint(mapInfoPoint, mapInfoPointModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, mapInfoPoint.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_GetMapInfoPointModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();

                    int mapInfoPointCount = mapInfoPointService.GetMapInfoPointModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, mapInfoPointCount);
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_GetMapInfoPointModelWithMapInfoPointIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();

                    MapInfoPointModel mapInfoPointModelRet2 = mapInfoPointService.GetMapInfoPointModelWithMapInfoPointIDDB(mapInfoPointModelRet.MapInfoPointID);

                    CompareMapInfoPointModels(mapInfoPointModelRet, mapInfoPointModelRet2);

                    int MapInfoPointID = 0;
                    MapInfoPointModel mapInfoPointModelRet3 = mapInfoPointService.GetMapInfoPointModelWithMapInfoPointIDDB(MapInfoPointID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MapInfoPoint, ServiceRes.MapInfoPointID, MapInfoPointID), mapInfoPointModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_GetMapInfoPointWithMapInfoPointIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();

                    MapInfoPoint mapInfoPointRet = mapInfoPointService.GetMapInfoPointWithMapInfoPointIDDB(mapInfoPointModelRet.MapInfoPointID);
                    Assert.AreEqual(mapInfoPointModelRet.MapInfoPointID, mapInfoPointRet.MapInfoPointID);

                    int MapInfoPointID = 0;
                    MapInfoPoint mapInfoPointRet2 = mapInfoPointService.GetMapInfoPointWithMapInfoPointIDDB(MapInfoPointID);
                    Assert.IsNull(mapInfoPointRet2);
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_GetMapInfoPointModelListWithTVItemIDAndIsPolylineDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();

                    MapInfoModel mapInfoModelRet = mapInfoService.GetMapInfoModelWithMapInfoIDDB(mapInfoPointModelRet.MapInfoID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(
    mapInfoModelRet.TVItemID, (TVTypeEnum)mapInfoModelRet.TVType, (MapInfoDrawTypeEnum)mapInfoModelRet.MapInfoDrawType);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    int MapInfoPointID = 0;
                    MapInfoPoint mapInfoPointRet2 = mapInfoPointService.GetMapInfoPointWithMapInfoPointIDDB(MapInfoPointID);
                    Assert.IsNull(mapInfoPointRet2);
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    MapInfoPointModel mapInfoPointModelRet = mapInfoPointService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, mapInfoPointModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostAddDeleteUpdateMapInfoPoint_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();
                    Assert.AreEqual("", mapInfoPointModelRet.Error);

                    MapInfoPointModel mapInfoPointModelRet3 = UpdateMapInfoPointModel(mapInfoPointModelRet);
                    Assert.AreEqual("", mapInfoPointModelRet.Error);

                    // Act 
                    MapInfoPointModel mapInfoPointModelRet2 = mapInfoPointService.PostDeleteMapInfoPointDB(mapInfoPointModelRet.MapInfoPointID);
                    Assert.AreEqual("", mapInfoPointModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostAddMapInfoPoint_MapInfoPointModelOK_Error_Test()
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
                        shimMapInfoPointService.MapInfoPointModelOKMapInfoPointModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostAddMapInfoPoint_IsContactOK_Error_Test()
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
                        shimMapInfoPointService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostAddMapInfoPoint_FillMapInfoPoint_Error_Test()
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
                        shimMapInfoPointService.FillMapInfoPointMapInfoPointMapInfoPointModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostAddMapInfoPoint_DoAddChanges_Error_Test()
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
                        shimMapInfoPointService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostAddMapInfoPoint_Add_Error_Test()
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
                        shimMapInfoPointService.FillMapInfoPointMapInfoPointMapInfoPointModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();
                        Assert.IsTrue(mapInfoPointModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostDeleteMapInfoPoint_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoPointService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MapInfoPointModel mapInfoPointModelRet2 = mapInfoPointService.PostDeleteMapInfoPointDB(mapInfoPointModelRet.MapInfoPointID);
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostDeleteMapInfoPoint_GetMapInfoPointWithMapInfoPointIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMapInfoPointService.GetMapInfoPointWithMapInfoPointIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MapInfoPointModel mapInfoPointModelRet2 = mapInfoPointService.PostDeleteMapInfoPointDB(mapInfoPointModelRet.MapInfoPointID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MapInfoPoint), mapInfoPointModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostDeleteMapInfoPoint_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoPointService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MapInfoPointModel mapInfoPointModelRet2 = mapInfoPointService.PostDeleteMapInfoPointDB(mapInfoPointModelRet.MapInfoPointID);
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostUpdateMapInfoPoint_MapInfoPointModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoPointService.MapInfoPointModelOKMapInfoPointModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MapInfoPointModel mapInfoPointModelRet2 = UpdateMapInfoPointModel(mapInfoPointModelRet);
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostUpdateMapInfoPoint_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoPointService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MapInfoPointModel mapInfoPointModelRet2 = UpdateMapInfoPointModel(mapInfoPointModelRet);
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostUpdateMapInfoPoint_GetMapInfoPointWithMapInfoPointIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMapInfoPointService.GetMapInfoPointWithMapInfoPointIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MapInfoPointModel mapInfoPointModelRet2 = UpdateMapInfoPointModel(mapInfoPointModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MapInfoPoint), mapInfoPointModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostUpdateMapInfoPoint_FillMapInfoPoint_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoPointService.FillMapInfoPointMapInfoPointMapInfoPointModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MapInfoPointModel mapInfoPointModelRet2 = UpdateMapInfoPointModel(mapInfoPointModelRet);
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostUpdateMapInfoPoint_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoPointModel mapInfoPointModelRet = AddMapInfoPointModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoPointService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MapInfoPointModel mapInfoPointModelRet2 = UpdateMapInfoPointModel(mapInfoPointModelRet);
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostAddDeleteUpdateMapInfoPoint_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = mapInfoServiceTest.AddMapInfoModel();

                    ContactModel contactModelBad = contactModelListBad[0];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    MapInfoPointService mapInfoPointService = new MapInfoPointService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);

                    MapInfoPointModel mapInfoPointModelRet = mapInfoPointService.PostAddMapInfoPointDB(mapInfoPointModelNew);
                    Assert.IsNotNull(mapInfoPointModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mapInfoPointModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoPointService_PostAddDeleteUpdateMapInfoPoint_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = mapInfoServiceTest.AddMapInfoModel();

                    ContactModel contactModelBad = contactModelListGood[2];
                    IPrincipal userBad = new GenericPrincipal(new GenericIdentity(contactModelBad.LoginEmail, "Forms"), null);
                    MapInfoPointService mapInfoPointService = new MapInfoPointService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), userBad);

                    FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);

                    MapInfoPointModel mapInfoPointModelRet = mapInfoPointService.PostAddMapInfoPointDB(mapInfoPointModelNew);
                    Assert.IsNotNull(mapInfoPointModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mapInfoPointModelRet.Error);
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions
        public MapInfoPointModel AddMapInfoPointModel()
        {
            MapInfoModel mapInfoModelRet = mapInfoServiceTest.AddMapInfoModel();

            MapInfoPointModel mapInfoPointModelNew = new MapInfoPointModel();
            FillMapInfoPointModelNew(mapInfoModelRet, mapInfoPointModelNew);

            MapInfoPointModel mapInfoPointModelRet = mapInfoPointService.PostAddMapInfoPointDB(mapInfoPointModelNew);
            if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
            {
                return mapInfoPointModelRet;
            }

            Assert.IsNotNull(mapInfoPointModelRet);
            CompareMapInfoPointModels(mapInfoPointModelNew, mapInfoPointModelRet);

            return mapInfoPointModelRet;
        }
        public MapInfoPointModel UpdateMapInfoPointModel(MapInfoPointModel mapInfoPointModelRet)
        {
            FillMapInfoPointModelUpdate(mapInfoPointModelRet);

            MapInfoPointModel mapInfoPointModelRet2 = mapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelRet);
            if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet2.Error))
            {
                return mapInfoPointModelRet2;
            }

            Assert.IsNotNull(mapInfoPointModelRet2);
            CompareMapInfoPointModels(mapInfoPointModelRet, mapInfoPointModelRet2);

            return mapInfoPointModelRet2;
        }
        private void CompareMapInfoPointModels(MapInfoPointModel mapInfoPointModelNew, MapInfoPointModel mapInfoPointModelRet)
        {
            Assert.AreEqual(mapInfoPointModelNew.MapInfoID, mapInfoPointModelRet.MapInfoID);
            Assert.AreEqual(mapInfoPointModelNew.Lat, mapInfoPointModelRet.Lat);
            Assert.AreEqual(mapInfoPointModelNew.Lng, mapInfoPointModelRet.Lng);
            Assert.AreEqual(mapInfoPointModelNew.Ordinal, mapInfoPointModelRet.Ordinal);
        }
        private void FillMapInfoPointModelNew(MapInfoModel mapInfoModel, MapInfoPointModel mapInfoPointModel)
        {
            mapInfoPointModel.MapInfoID = mapInfoModel.MapInfoID;
            mapInfoPointModel.Lat = randomService.RandomDouble(45, 46);
            mapInfoPointModel.Lng = randomService.RandomDouble(-66, -65);
            mapInfoPointModel.Ordinal = randomService.RandomInt(0, 100);

            Assert.IsTrue(mapInfoPointModel.MapInfoID != 0);
            Assert.IsTrue(mapInfoPointModel.Lat >= 45 && mapInfoPointModel.Lat <= 46);
            Assert.IsTrue(mapInfoPointModel.Lng >= -66 && mapInfoPointModel.Lng <= -65);
            Assert.IsTrue(mapInfoPointModel.Ordinal >= 0 && mapInfoPointModel.Ordinal <= 100);
        }
        private void FillMapInfoPointModelUpdate(MapInfoPointModel mapInfoPointModel)
        {
            mapInfoPointModel.Lat = randomService.RandomDouble(46, 47);
            mapInfoPointModel.Lng = randomService.RandomDouble(-67, -65);
            mapInfoPointModel.Ordinal = randomService.RandomInt(0, 100);

            Assert.IsTrue(mapInfoPointModel.MapInfoID != 0);
            Assert.IsTrue(mapInfoPointModel.Lat >= 46 && mapInfoPointModel.Lat <= 47);
            Assert.IsTrue(mapInfoPointModel.Lng >= -67 && mapInfoPointModel.Lng <= -65);
            Assert.IsTrue(mapInfoPointModel.Ordinal >= 0 && mapInfoPointModel.Ordinal <= 100);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mapInfoService = new MapInfoService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mapInfoPointService = new MapInfoPointService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mapInfoPointModelNew = new MapInfoPointModel();
            mapInfoPoint = new MapInfoPoint();
            mapInfoServiceTest = new MapInfoServiceTest();
            mapInfoServiceTest.SetupTest(contactModelToDo, culture);
        }
        private void SetupShim()
        {
            shimMapInfoPointService = new ShimMapInfoPointService(mapInfoPointService);
        }
        #endregion Functions
    }
}

