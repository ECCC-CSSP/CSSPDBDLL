using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPDBDLL.Tests.SetupInfo;
using CSSPDBDLL.Models;
using System.Security.Principal;
using CSSPDBDLL.Services;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using System.Linq;
using CSSPDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;
using System.IO;

namespace CSSPDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for MapInfoServiceTest
    /// </summary>
    [TestClass]
    public class MapInfoServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "MapInfo";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private MapInfoService mapInfoService { get; set; }
        private TVItemService tvItemService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private MapInfoModel mapInfoModelNew { get; set; }
        private MapInfo mapInfo { get; set; }
        private ShimMapInfoService shimMapInfoService { get; set; }
        private ShimMapInfoPointService shimMapInfoPointService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private MWQMSampleService mwqmSampleService { get; set; }
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
        public MapInfoServiceTest()
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
        public void MapInfoService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(mapInfoService);
                Assert.IsNotNull(mapInfoService._TVItemService);
                Assert.IsNotNull(mapInfoService._MapInfoPointService);
                Assert.IsNotNull(mapInfoService.db);
                Assert.IsNotNull(mapInfoService.LanguageRequest);
                Assert.IsNotNull(mapInfoService.User);
                Assert.AreEqual(user.Identity.Name, mapInfoService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), mapInfoService.LanguageRequest);
            }
        }
        [TestMethod]
        public void MapInfoService_MapInfoModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    #region Good
                    FillMapInfoModel(mapInfoModelNew);

                    string retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region TVItemID
                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.TVItemID = 0;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID), retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.TVItemID = 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TVItemID

                    #region TVType
                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.TVType = (TVTypeEnum)100000;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVType), retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.TVType = TVTypeEnum.MWQMSite;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TVType

                    #region LatMin
                    double MinDbl = -90D;
                    double MaxDbl = 90D;
                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LatMin = MinDbl - 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.LatMin, MinDbl, MaxDbl), retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LatMin = MaxDbl + 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.LatMin, MinDbl, MaxDbl), retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LatMin = MaxDbl - 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LatMin = MinDbl;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LatMin = MaxDbl;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion LatMin

                    #region LatMax
                    MinDbl = -90D;
                    MaxDbl = 90D;
                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LatMax = MinDbl - 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.LatMax, MinDbl, MaxDbl), retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LatMax = MaxDbl + 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.LatMax, MinDbl, MaxDbl), retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LatMax = MaxDbl - 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LatMax = MinDbl;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LatMax = MaxDbl;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion LatMax

                    #region LngMin
                    FillMapInfoModel(mapInfoModelNew);
                    MinDbl = -180D;
                    MaxDbl = 180D;
                    mapInfoModelNew.LngMin = MinDbl - 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.LngMin, MinDbl, MaxDbl), retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LngMin = MaxDbl + 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.LngMin, MinDbl, MaxDbl), retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LngMin = MaxDbl - 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LngMin = MinDbl;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LngMin = MaxDbl;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion LngMin

                    #region LngMax
                    FillMapInfoModel(mapInfoModelNew);
                    MinDbl = -180D;
                    MaxDbl = 180D;
                    mapInfoModelNew.LngMax = MinDbl - 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.LngMax, MinDbl, MaxDbl), retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LngMax = MaxDbl + 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.LngMax, MinDbl, MaxDbl), retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LngMax = MaxDbl - 1;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LngMax = MinDbl;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);

                    FillMapInfoModel(mapInfoModelNew);
                    mapInfoModelNew.LngMax = MaxDbl;

                    retStr = mapInfoService.MapInfoModelOK(mapInfoModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion LngMax
                }
            }
        }
        [TestMethod]
        public void MapInfoService_FillMapInfo_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FillMapInfoModel(mapInfoModelNew);

                    ContactOK contactOK = mapInfoService.IsContactOK();

                    string retStr = mapInfoService.FillMapInfo(mapInfo, mapInfoModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, mapInfo.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = mapInfoService.FillMapInfo(mapInfo, mapInfoModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, mapInfo.LastUpdateContactTVItemID);

                }
            }
        }
        [TestMethod]
        public void MapInfoService_FillMapInfoPoint_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelBouc = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouct", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouc.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelBouc.TVItemID, TVTypeEnum.Municipality, MapInfoDrawTypeEnum.Point);
                    Assert.AreEqual(1, mapInfoPointModelList.Count());

                    TVLocation tvLocation = new TVLocation();


                    mapInfoService.FillMapInfoPoint(mapInfoPointModelList, tvLocation, MapInfoDrawTypeEnum.Point);
                    Assert.AreEqual(1, tvLocation.MapObjList.Count());
                    Assert.AreEqual(MapInfoDrawTypeEnum.Point, tvLocation.MapObjList[0].MapInfoDrawType);
                    Assert.AreEqual(mapInfoPointModelList[0].MapInfoID, tvLocation.MapObjList[0].MapInfoID);
                    Assert.AreEqual(1, tvLocation.MapObjList[0].CoordList.Count());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_FillTVLocationList_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelBouc = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouct", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouc.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelBouc.TVItemID, TVTypeEnum.Municipality, MapInfoDrawTypeEnum.Point);
                    Assert.AreEqual(1, mapInfoPointModelList.Count());

                    TVLocation tvLocation = new TVLocation();

                    mapInfoService.FillMapInfoPoint(mapInfoPointModelList, tvLocation, MapInfoDrawTypeEnum.Point);
                    Assert.AreEqual(1, tvLocation.MapObjList.Count());
                    Assert.AreEqual(MapInfoDrawTypeEnum.Point, tvLocation.MapObjList[0].MapInfoDrawType);
                    Assert.AreEqual(mapInfoPointModelList[0].MapInfoID, tvLocation.MapObjList[0].MapInfoID);
                    Assert.AreEqual(1, tvLocation.MapObjList[0].CoordList.Count());

                    List<TVLocation> tvLocationList = new List<TVLocation>();
                    List<TVItemModel> tvItemModelList = new List<TVItemModel>() { tvItemModelBouc };
                    mapInfoService.FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Municipality, TVTypeEnum.Municipality);
                    Assert.AreEqual(1, tvLocationList.Count());
                    Assert.AreEqual(tvItemModelBouc.TVItemID, tvLocationList[0].TVItemID);
                    Assert.AreEqual(tvItemModelBouc.TVText, tvLocationList[0].TVText);
                    Assert.AreEqual(tvItemModelBouc.TVType, tvLocationList[0].TVType);
                    Assert.AreEqual(tvItemModelBouc.TVType, tvLocationList[0].SubTVType);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_CalculateAreaOfPolygon_coordList_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // Act for Add
                    double area = mapInfoService.CalculateAreaOfPolygon(coordList);
                    Assert.AreEqual((double)327668740.421875, area, 0.0001);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_CalculateAreaOfPolygon_nodeList_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<Node> nodeList = new List<Node>();
                    foreach (Coord coord in coordList)
                    {
                        nodeList.Add(new Node() { X = coord.Lng, Y = coord.Lat });
                    }
                    double area = mapInfoService.CalculateAreaOfPolygon(nodeList);
                    Assert.AreEqual((double)327668740.421875, area, 0.0001);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_CalculateDistance_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // Act for Add
                    double distance = mapInfoService.CalculateDistance(coordList[0].Lat, coordList[0].Lng, coordList[1].Lat, coordList[1].Lng, R);
                    Assert.AreEqual((double)453329.494511511, distance, 0.0001);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetInfrastructureModelWithInfrastructureTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    Infrastructure infrastructure = (from c in mapInfoService.db.Infrastructures
                                                     select c).FirstOrDefault();
                    Assert.IsNotNull(infrastructure);

                    InfrastructureModel infrastructureModel = mapInfoService.GetInfrastructureModelWithInfrastructureTVItemIDDB(infrastructure.InfrastructureTVItemID);
                    Assert.AreEqual("", infrastructureModel.Error);

                    int InfrastructureTVItemID = 0;
                    infrastructureModel = mapInfoService.GetInfrastructureModelWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Infrastructure, ServiceRes.InfrastructureTVItemID, InfrastructureTVItemID), infrastructureModel.Error);

                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();

                    int mapInfoCount = mapInfoService.GetMapInfoModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, mapInfoCount);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoListWithTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();

                    List<MapInfo> mapInfoList = mapInfoService.GetMapInfoListWithTVItemIDDB(mapInfoModelRet.TVItemID);
                    Assert.IsTrue(mapInfoList.Where(c => c.MapInfoID == mapInfoModelRet.MapInfoID).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoModelListWithTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();

                    List<MapInfoModel> mapInfoModelList = mapInfoService.GetMapInfoModelListWithTVItemIDDB(mapInfoModelRet.TVItemID);
                    Assert.IsTrue(mapInfoModelList.Count > 0);
                    Assert.AreEqual(1, mapInfoModelList.Where(c => c.MapInfoID == mapInfoModelRet.MapInfoID).Count());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoModelWithLatAndLngInPolygonWithTVTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    Coord coordBouctouche = new Coord() { Lat = 46.473544f, Lng = -64.714258f, Ordinal = 0 };

                    List<MapInfoModel> mapInfoModelList = mapInfoService.GetMapInfoModelWithLatAndLngInPolygonWithTVTypeDB(coordBouctouche.Lat, coordBouctouche.Lng, TVTypeEnum.Subsector);
                    Assert.IsNotNull(mapInfoModelList);
                    Assert.AreEqual(1, mapInfoModelList.Count);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoModelWithinCircleWithTVTypeAndMapInfoDrawTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    Coord coordBouctouche = new Coord() { Lat = 46.473544f, Lng = -64.714258f, Ordinal = 0 };

                    List<MapInfoModel> mapInfoModelList = mapInfoService.GetMapInfoModelWithinCircleWithTVTypeAndMapInfoDrawTypeDB(coordBouctouche.Lat, coordBouctouche.Lng, 100000f, TVTypeEnum.ClimateSite, MapInfoDrawTypeEnum.Point);
                    Assert.IsTrue(mapInfoModelList.Count > 0);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoModelWithMapInfoIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();

                    MapInfoModel mapInfoModelRet2 = mapInfoService.GetMapInfoModelWithMapInfoIDDB(mapInfoModelRet.MapInfoID);

                    CompareMapInfoModels(mapInfoModelRet, mapInfoModelRet2);

                    int MapInfoID = 0;
                    MapInfoModel mapInfoModelRet3 = mapInfoService.GetMapInfoModelWithMapInfoIDDB(MapInfoID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MapInfo, ServiceRes.MapInfoID, MapInfoID), mapInfoModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoWithMapInfoIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();

                    MapInfo mapInfoRet = mapInfoService.GetMapInfoWithMapInfoIDDB(mapInfoModelRet.MapInfoID);
                    Assert.AreEqual(mapInfoModelRet.MapInfoID, mapInfoRet.MapInfoID);

                    int MapInfoID = 0;
                    MapInfo mapInfoRet2 = mapInfoService.GetMapInfoWithMapInfoIDDB(MapInfoID);
                    Assert.IsNull(mapInfoRet2);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetParentLatLngDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelProvince = randomService.RandomTVItem(TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    TVItemModel tvItemModelArea = tvItemService.PostAddChildTVItemDB(tvItemModelProvince.TVItemID, "Unique area name", TVTypeEnum.Area);
                    Assert.AreEqual("", tvItemModelArea.Error);

                    List<Coord> coordList = new List<Coord>() { new Coord() { Lat = (float)23.2, Lng = (float)34.4 } };

                    MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Area, tvItemModelArea.TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    CoordModel coordModel = mapInfoService.GetParentLatLngDB(tvItemModelArea.TVItemID);
                    Assert.AreEqual(coordList[0].Lat, coordModel.Lat);
                    Assert.AreEqual(coordList[0].Lng, coordModel.Lng);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int TVItemID = 0;
                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(TVItemID, TVTypeEnum.Area, 2000, 4, 4, 30, true);
                    Assert.AreEqual(1, tvLocationList.Count);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID), tvLocationList[0].Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_ShowTVType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(1, (TVTypeEnum)10000, 2000, 4, 4, 30, true);
                    Assert.AreEqual(1, tvLocationList.Count);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ShowTVType), tvLocationList[0].Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_Year_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(1, TVTypeEnum.Area, 0, 4, 4, 30, true);
                    Assert.AreEqual(1, tvLocationList.Count);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Year), tvLocationList[0].Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_Month_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(1, TVTypeEnum.Area, 2000, 0, 4, 30, true);
                    Assert.AreEqual(1, tvLocationList.Count);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Month), tvLocationList[0].Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_Day_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(1, TVTypeEnum.Area, 2000, 4, 0, 30, true);
                    Assert.AreEqual(1, tvLocationList.Count);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Day), tvLocationList[0].Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_NumberOfSamples_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(1, TVTypeEnum.Area, 2000, 4, 5, 4, true);
                    Assert.AreEqual(1, tvLocationList.Count);
                    Assert.AreEqual(string.Format(ServiceRes._ShouldBeMoreThan_, ServiceRes.NumberOfSamples, 5), tvLocationList[0].Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelArea = randomService.RandomTVItem(TVTypeEnum.Area);
                    Assert.AreEqual("", tvItemModelArea.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelArea.TVItemID, TVTypeEnum.Sector, 2000, 4, 5, 30, true);
                        Assert.AreEqual(1, tvLocationList.Count);
                        Assert.AreEqual(ErrorText, tvLocationList[0].Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Area_ShowTVType_Sector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextArea = "NB-06";
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelArea = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextArea, TVTypeEnum.Area);
                    Assert.AreEqual("", tvItemModelArea.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelArea.TVItemID, TVTypeEnum.Sector, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Sector
                        && c.SubTVType == TVTypeEnum.Sector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Sector
                        && c.SubTVType == TVTypeEnum.Sector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon
                        && c.TVText.Contains(PartOfTVTextSector)).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Sector
                        && c.SubTVType == TVTypeEnum.Sector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Sector
                        && c.SubTVType == TVTypeEnum.Sector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(PartOfTVTextSector)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Area_ShowTVType_Municipality_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextArea = "NB-06";
                    string PartOfTVTextMunicipality = "Bouctouche";

                    TVItemModel tvItemModelArea = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextArea, TVTypeEnum.Area);
                    Assert.AreEqual("", tvItemModelArea.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelArea.TVItemID, TVTypeEnum.Municipality, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Municipality
                        && c.SubTVType == TVTypeEnum.Municipality
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Municipality
                        && c.SubTVType == TVTypeEnum.Municipality
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(PartOfTVTextMunicipality)).Any());
                }
            }
        }
        //[TestMethod]
        //public void MapInfoService_GetMapInfoDB_TVType_Area_ShowTVType_Nothing_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            string PartOfTVTextArea = "NB-06";

        //            TVItemModel tvItemModelArea = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextArea, TVTypeEnum.Area);
        //            Assert.AreEqual("", tvItemModelArea.Error);

        //            using (ShimsContext.Create())
        //            {
        //                //string ErrorText = "ErrorText";
        //                SetupShim();
        //                shimMapInfoService.TVTypeOKTVTypeEnum = (a) =>
        //                {
        //                    return "";
        //                };

        //                List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelArea.TVItemID, TVTypeEnum.Error, 2000, 4, 5, 30, true);
        //                Assert.IsNotNull(tvLocationList);
        //                Assert.IsTrue(tvLocationList.Count > 0);
        //                Assert.AreEqual(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelArea.TVType.ToString(), TVTypeEnum.Error.ToString()), tvLocationList[0].Error);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Country_ShowTVType_Province_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextCountry = "Canada";
                    string PartOfTVTextProvince = "Brunswick";

                    TVItemModel tvItemModelCountry = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextCountry, TVTypeEnum.Country);
                    Assert.AreEqual("", tvItemModelCountry.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelCountry.TVItemID, TVTypeEnum.Province, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Province
                          && c.SubTVType == TVTypeEnum.Province
                          && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Province
                        && c.SubTVType == TVTypeEnum.Province
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(PartOfTVTextProvince)).Any());
                }
            }
        }
        //[TestMethod]
        //public void MapInfoService_GetMapInfoDB_TVType_Country_ShowTVType_Nothing_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            string PartOfTVTextCountry = "Canada";

        //            TVItemModel tvItemModelCountry = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextCountry, TVTypeEnum.Country);
        //            Assert.AreEqual("", tvItemModelCountry.Error);

        //            using (ShimsContext.Create())
        //            {
        //                //string ErrorText = "ErrorText";
        //                SetupShim();
        //                shimMapInfoService.TVTypeOKTVTypeEnum = (a) =>
        //                {
        //                    return "";
        //                };

        //                List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelCountry.TVItemID, TVTypeEnum.Error, 2000, 4, 5, 30, true);
        //                Assert.IsNotNull(tvLocationList);
        //                Assert.IsTrue(tvLocationList.Count > 0);
        //                Assert.AreEqual(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCountry.TVType.ToString(), TVTypeEnum.Error.ToString()), tvLocationList[0].Error);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Infrastructure_ShowTVType_Infrastructure_InfrastructureType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextMunicipality = "Bouctouche";

                    TVItemModel tvItemModelMunicipality = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextMunicipality, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    List<TVItemModel> tvItemModelInfrastructureList = mapInfoService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                    InfrastructureService infrastructureService = new InfrastructureService(mapInfoService.LanguageRequest, mapInfoService.User);

                    InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModelInfrastructureList[0].TVItemID);
                    Assert.AreEqual("", infrastructureModel.Error);

                    infrastructureModel.InfrastructureType = InfrastructureTypeEnum.Error;

                    InfrastructureModel infrastructureModelRet = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Infrastructure, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.OtherInfrastructure).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.OtherInfrastructure
                        && c.TVText.Contains(infrastructureModelRet.InfrastructureTVText)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Infrastructure_ShowTVType_Infrastructure_InfrastructureType_LiftStation_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextMunicipality = "Bouctouche";

                    TVItemModel tvItemModelMunicipality = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextMunicipality, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    List<TVItemModel> tvItemModelInfrastructureList = mapInfoService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                    InfrastructureService infrastructureService = new InfrastructureService(mapInfoService.LanguageRequest, mapInfoService.User);

                    InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModelInfrastructureList[0].TVItemID);
                    Assert.AreEqual("", infrastructureModel.Error);

                    infrastructureModel.InfrastructureType = InfrastructureTypeEnum.LiftStation;

                    InfrastructureModel infrastructureModelRet = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Infrastructure, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.Outfall
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.Outfall
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(infrastructureModelRet.InfrastructureTVText)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Infrastructure_ShowTVType_Infrastructure_InfrastructureType_Other_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextMunicipality = "Bouctouche";

                    TVItemModel tvItemModelMunicipality = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextMunicipality, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    List<TVItemModel> tvItemModelInfrastructureList = mapInfoService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                    InfrastructureService infrastructureService = new InfrastructureService(mapInfoService.LanguageRequest, mapInfoService.User);

                    InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModelInfrastructureList[0].TVItemID);
                    Assert.AreEqual("", infrastructureModel.Error);

                    infrastructureModel.InfrastructureType = InfrastructureTypeEnum.Other;

                    InfrastructureModel infrastructureModelRet = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Infrastructure, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.OtherInfrastructure).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.OtherInfrastructure
                        && c.TVText.Contains(infrastructureModelRet.InfrastructureTVText)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Infrastructure_ShowTVType_Infrastructure_InfrastructureType_WWTP_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextMunicipality = "Bouctouche";

                    TVItemModel tvItemModelMunicipality = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextMunicipality, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    List<TVItemModel> tvItemModelInfrastructureList = mapInfoService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                    InfrastructureService infrastructureService = new InfrastructureService(mapInfoService.LanguageRequest, mapInfoService.User);

                    InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModelInfrastructureList[0].TVItemID);
                    Assert.AreEqual("", infrastructureModel.Error);

                    infrastructureModel.InfrastructureType = InfrastructureTypeEnum.WWTP;

                    InfrastructureModel infrastructureModelRet = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Infrastructure, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.WasteWaterTreatmentPlant).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.WasteWaterTreatmentPlant
                        && c.TVText.Contains(infrastructureModelRet.InfrastructureTVText)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Infrastructure_ShowTVType_Infrastructure_InfrastructureType_Nothing_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextMunicipality = "Bouctouche";

                    TVItemModel tvItemModelMunicipality = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextMunicipality, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    List<TVItemModel> tvItemModelInfrastructureList = mapInfoService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                    InfrastructureService infrastructureService = new InfrastructureService(mapInfoService.LanguageRequest, mapInfoService.User);

                    InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModelInfrastructureList[0].TVItemID);
                    Assert.AreEqual("", infrastructureModel.Error);

                    infrastructureModel.InfrastructureType = InfrastructureTypeEnum.WWTP;

                    InfrastructureModel infrastructureModelRet = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoService.GetInfrastructureModelWithInfrastructureTVItemIDDBInt32 = (a) =>
                        {
                            return new InfrastructureModel() { InfrastructureType = (InfrastructureTypeEnum)1000 };
                        };

                        List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Infrastructure, 2000, 4, 5, 30, true);
                        Assert.IsNotNull(tvLocationList);
                        Assert.IsTrue(tvLocationList.Count > 0);
                        Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                            && c.SubTVType == TVTypeEnum.OtherInfrastructure).Any());
                        Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                            && c.SubTVType == TVTypeEnum.OtherInfrastructure
                            && c.TVText.Contains(infrastructureModelRet.InfrastructureTVText)).Any());
                    }
                }
            }
        }
        //[TestMethod]
        //public void MapInfoService_GetMapInfoDB_TVType_Infrastructure_ShowTVType_Nothing_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            string PartOfTVTextMunicipality = "Bouctouche";
        //            string PartOfTVTextInfrastructure = randomService.RandomString("", 40);

        //            TVItemModel tvItemModelMunicipality = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextMunicipality, TVTypeEnum.Municipality);
        //            Assert.AreEqual("", tvItemModelMunicipality.Error);

        //            TVItemModel tvItemModelInfrastructure = mapInfoService._TVItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, PartOfTVTextInfrastructure, TVTypeEnum.Infrastructure);
        //            Assert.AreEqual("", tvItemModelInfrastructure.Error);

        //            InfrastructureService infrastructureService = new InfrastructureService(mapInfoService.LanguageRequest, mapInfoService.User);

        //            InfrastructureModel infrastructureModelNew = new InfrastructureModel()
        //            {
        //                InfrastructureTVText = randomService.RandomString("", 20),
        //                InfrastructureTVItemID = tvItemModelInfrastructure.TVItemID,
        //                InfrastructureType = InfrastructureTypeEnum.WWTP,
        //            };

        //            InfrastructureModel infrastructureModel = infrastructureService.PostAddInfrastructureDB(infrastructureModelNew);
        //            Assert.AreEqual("", infrastructureModel.Error);

        //            using (ShimsContext.Create())
        //            {
        //                //string ErrorText = "ErrorText";
        //                SetupShim();
        //                shimMapInfoService.TVTypeOKTVTypeEnum = (a) =>
        //                {
        //                    return "";
        //                };

        //                List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelInfrastructure.TVItemID, TVTypeEnum.Error, 2000, 4, 5, 30, true);
        //                Assert.IsNotNull(tvLocationList);
        //                Assert.IsTrue(tvLocationList.Count > 0);
        //                Assert.AreEqual(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelInfrastructure.TVType.ToString(), TVTypeEnum.Error.ToString()), tvLocationList[0].Error);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_MikeScenario_ShowTVType_MikeSource_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeSource = randomService.RandomTVItem(TVTypeEnum.MikeSource);
                    Assert.AreEqual("", tvItemModelMikeSource.Error);

                    TVItemModel tvItemModelMikeScenario = mapInfoService._TVItemService.GetTVItemModelWithTVItemIDDB(tvItemModelMikeSource.ParentID);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.MikeSource, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.MikeSource
                        && c.SubTVType == TVTypeEnum.MikeSource
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.MikeSource
                        && c.SubTVType == TVTypeEnum.MikeSource
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(tvItemModelMikeSource.TVText)).Any());
                }
            }
        }
        //[TestMethod]
        //public void MapInfoService_GetMapInfoDB_TVType_MikeScenario_ShowTVType_Nothing_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            TVItemModel tvItemModelMikeSource = randomService.RandomTVItem(TVTypeEnum.MikeSource);
        //            Assert.AreEqual("", tvItemModelMikeSource.Error);

        //            TVItemModel tvItemModelMikeScenario = mapInfoService._TVItemService.GetTVItemModelWithTVItemIDDB(tvItemModelMikeSource.ParentID);

        //            using (ShimsContext.Create())
        //            {
        //                //string ErrorText = "ErrorText";
        //                SetupShim();
        //                shimMapInfoService.TVTypeOKTVTypeEnum = (a) =>
        //                {
        //                    return "";
        //                };

        //                List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelMikeScenario.TVItemID, TVTypeEnum.Error, 2000, 4, 5, 30, true);
        //                Assert.IsNotNull(tvLocationList);
        //                Assert.IsTrue(tvLocationList.Count > 0);
        //                Assert.AreEqual(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelMikeScenario.TVType.ToString(), TVTypeEnum.Error.ToString()), tvLocationList[0].Error);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Municipality_ShowTVType_Infrastructure_InfrastructureType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextMunicipality = "Bouctouche";

                    TVItemModel tvItemModelMunicipality = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextMunicipality, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    List<TVItemModel> tvItemModelInfrastructureList = mapInfoService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                    InfrastructureService infrastructureService = new InfrastructureService(mapInfoService.LanguageRequest, mapInfoService.User);

                    InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModelInfrastructureList[0].TVItemID);
                    Assert.AreEqual("", infrastructureModel.Error);

                    infrastructureModel.InfrastructureType = InfrastructureTypeEnum.Error;

                    InfrastructureModel infrastructureModelRet = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.OtherInfrastructure).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.OtherInfrastructure
                        && c.TVText.Contains(infrastructureModelRet.InfrastructureTVText)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Municipality_ShowTVType_Infrastructure_InfrastructureType_LiftStation_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextMunicipality = "Bouctouche";

                    TVItemModel tvItemModelMunicipality = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextMunicipality, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    List<TVItemModel> tvItemModelInfrastructureList = mapInfoService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                    InfrastructureService infrastructureService = new InfrastructureService(mapInfoService.LanguageRequest, mapInfoService.User);

                    InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModelInfrastructureList[0].TVItemID);
                    Assert.AreEqual("", infrastructureModel.Error);

                    infrastructureModel.InfrastructureType = InfrastructureTypeEnum.LiftStation;

                    InfrastructureModel infrastructureModelRet = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.Outfall
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.Outfall
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(infrastructureModelRet.InfrastructureTVText)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Municipality_ShowTVType_Infrastructure_InfrastructureType_Other_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextMunicipality = "Bouctouche";

                    TVItemModel tvItemModelMunicipality = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextMunicipality, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    List<TVItemModel> tvItemModelInfrastructureList = mapInfoService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                    InfrastructureService infrastructureService = new InfrastructureService(mapInfoService.LanguageRequest, mapInfoService.User);

                    InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModelInfrastructureList[0].TVItemID);
                    Assert.AreEqual("", infrastructureModel.Error);

                    infrastructureModel.InfrastructureType = InfrastructureTypeEnum.Other;

                    InfrastructureModel infrastructureModelRet = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.OtherInfrastructure).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.OtherInfrastructure
                        && c.TVText.Contains(infrastructureModelRet.InfrastructureTVText)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Municipality_ShowTVType_Infrastructure_InfrastructureType_WWTP_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextMunicipality = "Bouctouche";

                    TVItemModel tvItemModelMunicipality = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextMunicipality, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    List<TVItemModel> tvItemModelInfrastructureList = mapInfoService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                    InfrastructureService infrastructureService = new InfrastructureService(mapInfoService.LanguageRequest, mapInfoService.User);

                    InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModelInfrastructureList[0].TVItemID);
                    Assert.AreEqual("", infrastructureModel.Error);

                    infrastructureModel.InfrastructureType = InfrastructureTypeEnum.WWTP;

                    InfrastructureModel infrastructureModelRet = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.WasteWaterTreatmentPlant).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                        && c.SubTVType == TVTypeEnum.WasteWaterTreatmentPlant
                        && c.TVText.Contains(infrastructureModelRet.InfrastructureTVText)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Municipality_ShowTVType_Infrastructure_InfrastructureType_Nothing_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextMunicipality = "Bouctouche";

                    TVItemModel tvItemModelMunicipality = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextMunicipality, TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    List<TVItemModel> tvItemModelInfrastructureList = mapInfoService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfrastructureList.Count > 0);

                    InfrastructureService infrastructureService = new InfrastructureService(mapInfoService.LanguageRequest, mapInfoService.User);

                    InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModelInfrastructureList[0].TVItemID);
                    Assert.AreEqual("", infrastructureModel.Error);

                    infrastructureModel.InfrastructureType = InfrastructureTypeEnum.WWTP;

                    InfrastructureModel infrastructureModelRet = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoService.GetInfrastructureModelWithInfrastructureTVItemIDDBInt32 = (a) =>
                        {
                            return new InfrastructureModel() { InfrastructureType = (InfrastructureTypeEnum)1000 };
                        };

                        List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure, 2000, 4, 5, 30, true);
                        Assert.IsNotNull(tvLocationList);
                        Assert.IsTrue(tvLocationList.Count > 0);
                        Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                            && c.SubTVType == TVTypeEnum.OtherInfrastructure).Any());
                        Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Infrastructure
                            && c.SubTVType == TVTypeEnum.OtherInfrastructure
                            && c.TVText.Contains(infrastructureModelRet.InfrastructureTVText)).Any());
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Province_ShowTVType_Area_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVItemArea = "NB-06";

                    TVItemModel tvItemModelProvince = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, (culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProvince.Error);


                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelProvince.TVItemID, TVTypeEnum.Area, 2000, 4, 5, 30, true);

                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Area
                         && c.SubTVType == TVTypeEnum.Area
                         && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Area
                        && c.SubTVType == TVTypeEnum.Area
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon
                        && c.TVText.Contains(PartOfTVItemArea)).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Area
                        && c.SubTVType == TVTypeEnum.Area
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Area
                        && c.SubTVType == TVTypeEnum.Area
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(PartOfTVItemArea)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Province_ShowTVType_Municipality_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVItemMunicipality = "Bouctouche";

                    TVItemModel tvItemModelProvince = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, (culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick"), TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProvince.Error);


                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelProvince.TVItemID, TVTypeEnum.Municipality, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Municipality
                        && c.SubTVType == TVTypeEnum.Municipality
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Municipality
                        && c.SubTVType == TVTypeEnum.Municipality
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(PartOfTVItemMunicipality)).Any());
                }
            }
        }
        //[TestMethod]
        //public void MapInfoService_GetMapInfoDB_TVType_Province_ShowTVType_Nothing_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            TVItemModel tvItemModelProvince = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, (culture.TwoLetterISOLanguageName == "fr" ? "Nouveau-Brunswick" : "New Brunswick"), TVTypeEnum.Province);
        //            Assert.AreEqual("", tvItemModelProvince.Error);


        //            using (ShimsContext.Create())
        //            {
        //                //string ErrorText = "ErrorText";
        //                SetupShim();
        //                shimMapInfoService.TVTypeOKTVTypeEnum = (a) =>
        //                {
        //                    return "";
        //                };

        //                List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelProvince.TVItemID, TVTypeEnum.Error, 2000, 4, 5, 30, true);
        //                Assert.IsNotNull(tvLocationList);
        //                Assert.IsTrue(tvLocationList.Count > 0);
        //                Assert.AreEqual(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelProvince.TVType.ToString(), TVTypeEnum.Error.ToString()), tvLocationList[0].Error);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Root_ShowTVType_Country_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVItemCountry = "Canada";

                    TVItemModel tvItemModelRoot = mapInfoService._TVItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);


                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelRoot.TVItemID, TVTypeEnum.Country, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Country
                        && c.SubTVType == TVTypeEnum.Country
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Country
                        && c.SubTVType == TVTypeEnum.Country
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(PartOfTVItemCountry)).Any());
                }
            }
        }
        //[TestMethod]
        //public void MapInfoService_GetMapInfoDB_TVType_Root_ShowTVType_Nothing_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            //string PartOfTVItemCountry = "Canada";

        //            TVItemModel tvItemModelRoot = mapInfoService._TVItemService.GetRootTVItemModelDB();
        //            Assert.AreEqual("", tvItemModelRoot.Error);


        //            using (ShimsContext.Create())
        //            {
        //                //string ErrorText = "ErrorText";
        //                SetupShim();
        //                shimMapInfoService.TVTypeOKTVTypeEnum = (a) =>
        //                {
        //                    return "";
        //                };

        //                List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelRoot.TVItemID, TVTypeEnum.Error, 2000, 4, 5, 30, true);
        //                Assert.IsNotNull(tvLocationList);
        //                Assert.IsTrue(tvLocationList.Count > 0);
        //                Assert.AreEqual(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelRoot.TVType.ToString(), TVTypeEnum.Error.ToString()), tvLocationList[0].Error);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Sector_ShowTVType_Subsector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVItemSector = "NB-06-020";
                    string PartOfTVItemSubsector = "NB-06-020-002";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVItemSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelSector.TVItemID, TVTypeEnum.Subsector, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                         && c.SubTVType == TVTypeEnum.Subsector
                         && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon
                        && c.TVText.Contains(PartOfTVItemSubsector)).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(PartOfTVItemSubsector)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Sector_ShowTVType_Municipality_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVItemSector = "NB-06-020";
                    string PartOfTVItemMunicipality = "Bouctouche";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVItemSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelSector.TVItemID, TVTypeEnum.Municipality, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Municipality
                      && c.SubTVType == TVTypeEnum.Municipality
                      && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Municipality
                        && c.SubTVType == TVTypeEnum.Municipality
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(PartOfTVItemMunicipality)).Any());
                }
            }
        }
        //[TestMethod]
        //public void MapInfoService_GetMapInfoDB_TVType_Sector_ShowTVType_Nothing_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            string PartOfTVItemSector = "NB-06-020";

        //            TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVItemSector, TVTypeEnum.Sector);
        //            Assert.AreEqual("", tvItemModelSector.Error);


        //            using (ShimsContext.Create())
        //            {
        //                //string ErrorText = "ErrorText";
        //                SetupShim();
        //                shimMapInfoService.TVTypeOKTVTypeEnum = (a) =>
        //                {
        //                    return "";
        //                };

        //                List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelSector.TVItemID, TVTypeEnum.Error, 2000, 4, 5, 30, true);
        //                Assert.IsNotNull(tvLocationList);
        //                Assert.IsTrue(tvLocationList.Count > 0);
        //                Assert.AreEqual(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelSector.TVType.ToString(), TVTypeEnum.Error.ToString()), tvLocationList[0].Error);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Subsector_ShowTVType_Municipality_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVItemSubsector = "NB-06-020-002";
                    string PartOfTVItemMunicipality = "Bouctouche";

                    TVItemModel tvItemModelSubsector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVItemSubsector, TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelSubsector.TVItemID, TVTypeEnum.Municipality, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                         && c.SubTVType == TVTypeEnum.Subsector
                         && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon
                        && c.TVText.Contains(PartOfTVItemSubsector)).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(PartOfTVItemSubsector)).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Municipality
                        && c.SubTVType == TVTypeEnum.Municipality
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Municipality
                        && c.SubTVType == TVTypeEnum.Municipality
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(PartOfTVItemMunicipality)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Subsector_ShowTVType_Subsector_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVItemSubsector = "NB-06-020-002";

                    TVItemModel tvItemModelSubsector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVItemSubsector, TVTypeEnum.Subsector);
                    Assert.AreEqual("", tvItemModelSubsector.Error);


                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelSubsector.TVItemID, TVTypeEnum.Subsector, 2000, 4, 5, 30, true);
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                         && c.SubTVType == TVTypeEnum.Subsector
                         && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon
                        && c.TVText.Contains(PartOfTVItemSubsector)).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(PartOfTVItemSubsector)).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Subsector_ShowTVType_MWQMRun_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    int TVItemID = (from t in mapInfoService.db.TVItems
                                    let sampleCount = (from s in mapInfoService.db.MWQMSamples where s.MWQMSiteTVItemID == t.TVItemID select s).Count()
                                    where sampleCount > 30
                                    && t.TVType == (int)TVTypeEnum.MWQMSite
                                    select t.TVItemID).FirstOrDefault<int>();
                    Assert.IsTrue(TVItemID > 0);

                    TVItemModel tvItemModelMWQMSite = mapInfoService._TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
                    Assert.AreEqual("", tvItemModelMWQMSite.Error);

                    TVItemModel tvItemModelSubsector = mapInfoService._TVItemService.GetTVItemModelWithTVItemIDDB(tvItemModelMWQMSite.ParentID);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    List<MWQMSampleModel> mwqmSampleModelList = mwqmSampleService.GetMWQMSampleModelListWithMWQMSiteTVItemIDDB(tvItemModelMWQMSite.TVItemID);
                    Assert.IsTrue(mwqmSampleModelList.Count > 0);

                    DateTime SampleDate = mwqmSampleModelList[0].SampleDateTime_Local;

                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelSubsector.TVItemID, TVTypeEnum.MWQMRun, SampleDate.Year, SampleDate.Month, SampleDate.Day, 30, true);

                    TVLocation tvLocationRet = new TVLocation();
                    tvLocationRet.TVText = tvItemModelMWQMSite.TVText;

                    List<MWQMSample> mwqmSampleList = (from w in mapInfoService.db.MWQMSites
                                                       from s in mapInfoService.db.MWQMSamples
                                                       where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                                       && w.MWQMSiteTVItemID == tvItemModelMWQMSite.TVItemID
                                                       && (s.SampleDateTime_Local.Year == SampleDate.Year
                                                       && s.SampleDateTime_Local.Month == SampleDate.Month
                                                       && s.SampleDateTime_Local.Day == SampleDate.Day)
                                                       orderby s.SampleDateTime_Local descending
                                                       select s).ToList<MWQMSample>();

                    if (mwqmSampleList.Count >= 1)
                    {
                        mapInfoService.CalculateMWQMSiteStatOneDay(mwqmSampleList, tvLocationRet);
                    }
                    else
                    {
                        tvLocationRet.SubTVType = TVTypeEnum.NoData;
                        tvLocationRet.TVText += " - " + ServiceRes.NoData;
                    }


                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                         && c.SubTVType == TVTypeEnum.Subsector
                         && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon
                        && c.TVText.Contains(tvItemModelSubsector.TVText)).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(tvItemModelSubsector.TVText)).Any());

                    List<TVTypeEnum> TVTypeResList = new List<TVTypeEnum>() { TVTypeEnum.Passed, TVTypeEnum.Failed, TVTypeEnum.NoDepuration };

                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.MWQMSite).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.MWQMSite && c.TVText == tvLocationRet.TVText).Any());
                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_Subsector_ShowTVType_MWQMSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    int TVItemID = (from t in mapInfoService.db.TVItems
                                    let sampleCount = (from s in mapInfoService.db.MWQMSamples where s.MWQMSiteTVItemID == t.TVItemID select s).Count()
                                    where sampleCount > 30
                                    && t.TVType == (int)TVTypeEnum.MWQMSite
                                    select t.TVItemID).FirstOrDefault<int>();
                    Assert.IsTrue(TVItemID > 0);

                    TVItemModel tvItemModelMWQMSite = mapInfoService._TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
                    Assert.AreEqual("", tvItemModelMWQMSite.Error);

                    TVItemModel tvItemModelSubsector = mapInfoService._TVItemService.GetTVItemModelWithTVItemIDDB(tvItemModelMWQMSite.ParentID);
                    Assert.AreEqual("", tvItemModelSubsector.Error);

                    List<MWQMSampleModel> mwqmSampleModelList = mwqmSampleService.GetMWQMSampleModelListWithMWQMSiteTVItemIDDB(tvItemModelMWQMSite.TVItemID);
                    Assert.IsTrue(mwqmSampleModelList.Count > 0);

                    int BeforeYear = 2014;
                    int NumberOfSamples = 30;
                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelSubsector.TVItemID, TVTypeEnum.MWQMSite, BeforeYear, 1, 1, NumberOfSamples, true);

                    TVLocation tvLocationRet = new TVLocation();
                    tvLocationRet.TVText = tvItemModelMWQMSite.TVText;

                    List<MWQMSample> mwqmSampleList = (from w in mapInfoService.db.MWQMSites
                                                       from s in mapInfoService.db.MWQMSamples
                                                       where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                                       && w.MWQMSiteTVItemID == TVItemID
                                                       && s.SampleDateTime_Local.Year <= BeforeYear
                                                       orderby s.SampleDateTime_Local descending
                                                       select s).Take(NumberOfSamples).ToList<MWQMSample>();

                    int SampCount = mwqmSampleList.Count();
                    int MinFC = 0;
                    int MaxFC = 0;
                    if (SampCount > 0)
                    {
                        MinFC = (int)mwqmSampleList.Min(c => c.FecCol_MPN_100ml);
                        MaxFC = (int)mwqmSampleList.Max(c => c.FecCol_MPN_100ml);

                        if (mwqmSampleList.Count >= 10)
                        {
                            mapInfoService.CalculateMWQMSiteStat(mwqmSampleList, tvLocationRet, MinFC, MaxFC, SampCount);
                        }
                        else
                        {
                            tvLocationRet.SubTVType = TVTypeEnum.LessThan10;
                            tvLocationRet.TVText += " - " + ServiceRes.LessThan10Samples + " - " + ServiceRes.NumberOfSamples + ": [" + string.Format("{0:F0}", SampCount) + "]";
                        }
                    }
                    else
                    {
                        tvLocationRet.SubTVType = TVTypeEnum.NoData;
                        tvLocationRet.TVText += " - " + ServiceRes.NoData;
                    }
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                         && c.SubTVType == TVTypeEnum.Subsector
                         && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Polygon
                        && c.TVText.Contains(tvItemModelSubsector.TVText)).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.Subsector
                        && c.SubTVType == TVTypeEnum.Subsector
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(tvItemModelSubsector.TVText)).Any());

                    List<TVTypeEnum> TVTypeResList = new List<TVTypeEnum>() { TVTypeEnum.Passed, TVTypeEnum.Failed, TVTypeEnum.NoDepuration };

                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.MWQMSite
                       && TVTypeResList.Contains(c.SubTVType)
                       && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.MWQMSite
                       && TVTypeResList.Contains(c.SubTVType)
                       && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                       && c.TVText.Contains(tvLocationRet.TVText)).Any());
                }
            }
        }
        //[TestMethod]
        //public void MapInfoService_GetMapInfoDB_TVType_Subsector_ShowTVType_Nothing_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        using (TransactionScope ts = new TransactionScope())
        //        {

        //            TVItemModel tvItemModelSubsector = randomService.RandomTVItem(TVTypeEnum.Subsector);
        //            Assert.AreEqual("", tvItemModelSubsector.Error);

        //            using (ShimsContext.Create())
        //            {
        //                //string ErrorText = "ErrorText";
        //                SetupShim();
        //                shimMapInfoService.TVTypeOKTVTypeEnum = (a) =>
        //                {
        //                    return "";
        //                };

        //                List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelSubsector.TVItemID, TVTypeEnum.Error, 2000, 4, 5, 30, true);
        //                Assert.IsNotNull(tvLocationList);
        //                Assert.IsTrue(tvLocationList.Count > 0);
        //                Assert.AreEqual(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelSubsector.TVType.ToString(), TVTypeEnum.Error.ToString()), tvLocationList[0].Error);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void MapInfoService_GetMapInfoDB_TVType_MWQMSite_ShowTVType_MWQMSite_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    int TVItemID = (from t in mapInfoService.db.TVItems
                                    let sampleCount = (from s in mapInfoService.db.MWQMSamples where s.MWQMSiteTVItemID == t.TVItemID select s).Count()
                                    where sampleCount > 30
                                    && t.TVType == (int)TVTypeEnum.MWQMSite
                                    select t.TVItemID).FirstOrDefault<int>();
                    Assert.IsTrue(TVItemID > 0);

                    TVItemModel tvItemModelMWQMSite = mapInfoService._TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
                    Assert.AreEqual("", tvItemModelMWQMSite.Error);


                    List<MWQMSampleModel> mwqmSampleModelList = mwqmSampleService.GetMWQMSampleModelListWithMWQMSiteTVItemIDDB(tvItemModelMWQMSite.TVItemID);
                    Assert.IsTrue(mwqmSampleModelList.Count > 0);

                    int BeforeYear = 2014;
                    int NumberOfSamples = 30;
                    List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelMWQMSite.TVItemID, TVTypeEnum.MWQMSite, BeforeYear, 1, 1, NumberOfSamples, true);

                    TVLocation tvLocationRet = new TVLocation();
                    tvLocationRet.TVText = tvItemModelMWQMSite.TVText;

                    List<MWQMSample> mwqmSampleList = (from w in mapInfoService.db.MWQMSites
                                                       from s in mapInfoService.db.MWQMSamples
                                                       where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                                       && w.MWQMSiteTVItemID == TVItemID
                                                       && s.SampleDateTime_Local.Year <= BeforeYear
                                                       orderby s.SampleDateTime_Local descending
                                                       select s).Take(NumberOfSamples).ToList<MWQMSample>();

                    int SampCount = mwqmSampleList.Count();
                    int MinFC = 0;
                    int MaxFC = 0;
                    if (SampCount > 0)
                    {
                        MinFC = (int)mwqmSampleList.Min(c => c.FecCol_MPN_100ml);
                        MaxFC = (int)mwqmSampleList.Max(c => c.FecCol_MPN_100ml);

                        if (mwqmSampleList.Count >= 10)
                        {
                            mapInfoService.CalculateMWQMSiteStat(mwqmSampleList, tvLocationRet, MinFC, MaxFC, SampCount);
                        }
                        else
                        {
                            tvLocationRet.SubTVType = TVTypeEnum.LessThan10;
                            tvLocationRet.TVText += " - " + ServiceRes.LessThan10Samples + " - " + ServiceRes.NumberOfSamples + ": [" + string.Format("{0:F0}", SampCount) + "]";
                        }
                    }
                    else
                    {
                        tvLocationRet.SubTVType = TVTypeEnum.NoData;
                        tvLocationRet.TVText += " - " + ServiceRes.NoData;
                    }
                    Assert.IsNotNull(tvLocationList);
                    Assert.IsTrue(tvLocationList.Count > 0);
                    List<TVTypeEnum> TVTypeResList = new List<TVTypeEnum>() { TVTypeEnum.Passed, TVTypeEnum.Failed, TVTypeEnum.NoDepuration };
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.MWQMSite
                        && TVTypeResList.Contains(c.SubTVType)
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point).Any());
                    Assert.IsTrue(tvLocationList.Where(c => c.TVType == TVTypeEnum.MWQMSite
                        && TVTypeResList.Contains(c.SubTVType)
                        && c.MapObjList[0].MapInfoDrawType == MapInfoDrawTypeEnum.Point
                        && c.TVText.Contains(tvLocationRet.TVText)).Any());
                }
            }
        }
        //[TestMethod]
        //public void MapInfoService_GetMapInfoDB_TVType_MWQMSite_ShowTVType_Nothing_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            TVItemModel tvItemModelMWQMSite = randomService.RandomTVItem(TVTypeEnum.MWQMSite);
        //            Assert.AreEqual("", tvItemModelMWQMSite.Error);

        //            using (ShimsContext.Create())
        //            {
        //                //string ErrorText = "ErrorText";
        //                SetupShim();
        //                shimMapInfoService.TVTypeOKTVTypeEnum = (a) =>
        //                {
        //                    return "";
        //                };

        //                List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(tvItemModelMWQMSite.TVItemID, TVTypeEnum.Error, 2000, 4, 5, 30, true);
        //                Assert.IsNotNull(tvLocationList);
        //                Assert.IsTrue(tvLocationList.Count > 0);
        //                Assert.AreEqual(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelMWQMSite.TVType.ToString(), TVTypeEnum.Error.ToString()), tvLocationList[0].Error);
        //            }
        //        }
        //    }
        //}
        //[TestMethod]
        //public void MapInfoService_GetMapInfoDB_TVType_Nothing_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        using (TransactionScope ts = new TransactionScope())
        //        {

        //            TVItemModel tvItemModelRoot = mapInfoService._TVItemService.GetRootTVItemModelDB();
        //            Assert.AreEqual("", tvItemModelRoot.Error);

        //            using (ShimsContext.Create())
        //            {
        //                TVItemModel tvItemModelCurrent = new TVItemModel() { TVType = (TVTypeEnum)100000 };
        //                //string ErrorText = "ErrorText";
        //                SetupShim();
        //                shimMapInfoService.TVTypeOKTVTypeEnum = (a) =>
        //                {
        //                    return "";
        //                };
        //                shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
        //                {
        //                    return tvItemModelCurrent;
        //                };

        //                int TVItemID = 100000000;
        //                List<TVLocation> tvLocationList = mapInfoService.GetMapInfoDB(TVItemID, TVTypeEnum.Area, 2000, 4, 5, 30, true);
        //                Assert.IsNotNull(tvLocationList);
        //                Assert.IsTrue(tvLocationList.Count > 0);
        //                Assert.AreEqual(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), TVTypeEnum.Area.ToString()), tvLocationList[0].Error);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void MapInfoService_GetParentLatLngDB_TVItemIDMap_NotExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelProvince = randomService.RandomTVItem(TVTypeEnum.Province);
                    Assert.AreEqual("", tvItemModelProvince.Error);

                    TVItemModel tvItemModelArea = tvItemService.PostAddChildTVItemDB(tvItemModelProvince.TVItemID, "Unique area name", TVTypeEnum.Area);
                    Assert.AreEqual("", tvItemModelArea.Error);

                    List<Coord> coordList = new List<Coord>() { new Coord() { Lat = (float)23.2, Lng = (float)34.4 } };

                    MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Area, tvItemModelArea.TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    CoordModel coordModel = mapInfoService.GetParentLatLngDB(tvItemModelArea.TVItemID);
                    Assert.AreEqual(coordList[0].Lat, coordModel.Lat);
                    Assert.AreEqual(coordList[0].Lng, coordModel.Lng);

                    MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoWithTVItemIDDB(tvItemModelArea.TVItemID);
                    Assert.AreEqual("", mapInfoModelRet2.Error);

                    CoordModel coordModel2 = mapInfoService.GetParentLatLngDB(mapInfoModelRet.TVItemID);
                    Assert.IsTrue(coordModel.Lat != 0.0f);
                    Assert.IsTrue(coordModel.Lng != 0.0f);

                }
            }
        }
        [TestMethod]
        public void MapInfoService_GetParentLatLngDB_GetTVItemModelWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        int TVItemID = 0;
                        CoordModel coordModel = mapInfoService.GetParentLatLngDB(TVItemID);
                        Assert.AreEqual(ErrorText, coordModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";

                    MapInfoModel mapInfoModelRet = mapInfoService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_ReturnTVLocationError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";

                    TVLocation tvLocation = mapInfoService.ReturnTVLocationError(ErrorText);
                    Assert.AreEqual(ErrorText, tvLocation.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_ReturnMapInfoPointError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";

                    MapInfoPointModel mapInfoPointModel = mapInfoService.ReturnMapInfoPointError(ErrorText);
                    Assert.AreEqual(ErrorText, mapInfoPointModel.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_ReturnMapInfoError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";

                    MapInfoModel mapInfoModel = mapInfoService.ReturnMapInfoError(ErrorText);
                    Assert.AreEqual(ErrorText, mapInfoModel.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_CoordInPolygon_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<Coord> coordList = new List<Coord>()
                    {
                        new Coord()  { Lat = 1.0f, Lng = 1.0f, Ordinal = 0 },
                        new Coord()  { Lat = 2.0f, Lng = 1.0f, Ordinal = 0 },
                        new Coord()  { Lat = 2.0f, Lng = 2.0f, Ordinal = 0 },
                        new Coord()  { Lat = 1.0f, Lng = 2.0f, Ordinal = 0 },
                        new Coord()  { Lat = 1.0f, Lng = 1.0f, Ordinal = 0 },
                    };

                    Coord coord = new Coord() { Lat = 1.5f, Lng = 1.5f, Ordinal = 0 };

                    bool retBool = mapInfoService.CoordInPolygon(coordList, coord);
                    Assert.AreEqual(true, retBool);

                    coord = new Coord() { Lat = 2.5f, Lng = 1.5f, Ordinal = 0 };

                    retBool = mapInfoService.CoordInPolygon(coordList, coord);
                    Assert.AreEqual(false, retBool);

                    coord = new Coord() { Lat = -1.5f, Lng = 1.5f, Ordinal = 0 };

                    retBool = mapInfoService.CoordInPolygon(coordList, coord);
                    Assert.AreEqual(false, retBool);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_CreateMapInfoObjectInDB_Point_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<Coord> coordList = new List<Coord>() { new Coord() { Lat = (float)23.2, Lng = (float)34.4 } };
                    TVTypeEnum tvType = TVTypeEnum.Area;
                    int TVItemID = randomService.RandomTVItem(TVTypeEnum.Area).TVItemID;

                    MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, tvType, TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_CreateMapInfoObjectDB_Polygon_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<Coord> coordList = new List<Coord>() { new Coord() { Lat = (float)23.2, Lng = (float)34.4 }, new Coord() { Lat = (float)26.2, Lng = (float)36.4 }, new Coord() { Lat = (float)24.2, Lng = (float)35.4 } };
                    TVTypeEnum tvType = TVTypeEnum.Area;
                    int TVItemID = randomService.RandomTVItem(TVTypeEnum.Area).TVItemID;

                    MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polygon, tvType, TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_CreateMapInfoObjectDB_Polyline_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<Coord> coordList = new List<Coord>() { new Coord() { Lat = (float)23.2, Lng = (float)34.4 }, new Coord() { Lat = (float)26.2, Lng = (float)36.4 }, new Coord() { Lat = (float)24.2, Lng = (float)35.4 } };
                    TVTypeEnum tvType = TVTypeEnum.Area;
                    int TVItemID = randomService.RandomTVItem(TVTypeEnum.Area).TVItemID;

                    MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polyline, tvType, TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    MapInfoModel mapInfoModelRet2 = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polyline, tvType, TVItemID);
                    Assert.AreEqual("", mapInfoModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_CreateMapInfoObjectDB_PostAddMapInfoDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<Coord> coordList = new List<Coord>() { new Coord() { Lat = (float)23.2, Lng = (float)34.4 }, new Coord() { Lat = (float)26.2, Lng = (float)36.4 }, new Coord() { Lat = (float)24.2, Lng = (float)35.4 } };
                    TVTypeEnum tvType = TVTypeEnum.Area;
                    int TVItemID = randomService.RandomTVItem(TVTypeEnum.Area).TVItemID;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoService.PostAddMapInfoDBMapInfoModel = (a) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polygon, tvType, TVItemID);
                        Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_CreateMapInfoObjectInDB_PostAddMapInfoPointDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<Coord> coordList = new List<Coord>() { new Coord() { Lat = (float)23.2, Lng = (float)34.4 }, new Coord() { Lat = (float)26.2, Lng = (float)36.4 }, new Coord() { Lat = (float)24.2, Lng = (float)35.4 } };
                    TVTypeEnum tvType = TVTypeEnum.Area;
                    int TVItemID = randomService.RandomTVItem(TVTypeEnum.Area).TVItemID;

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.PostAddMapInfoPointDBMapInfoPointModel = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polygon, tvType, TVItemID);
                        Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostAddDeleteUpdateMapInfo_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();

                    MapInfoModel mapInfoModelRet2 = UpdateMapInfoModel(mapInfoModelRet);

                    MapInfoModel mapInfoModelRet3 = mapInfoService.PostDeleteMapInfoDB(mapInfoModelRet2.MapInfoID);
                    Assert.AreEqual("", mapInfoModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostAddDeleteUpdateMapInfo_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();
                    Assert.IsNotNull(mapInfoModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, mapInfoModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostAddDeleteUpdateMapInfo_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();
                    Assert.IsNotNull(mapInfoModelRet);
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, mapInfoModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostAddMapInfoDB_MapInfoModelOK_Error_Test()
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
                        shimMapInfoService.MapInfoModelOKMapInfoModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MapInfoModel mapInfoModelRet = AddMapInfoModel();
                        Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostAddMapInfoDB_IsContactOK_Error_Test()
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
                        shimMapInfoService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet = AddMapInfoModel();
                        Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostAddMapInfoDB_FillMapInfoModel_Error_Test()
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
                        shimMapInfoService.FillMapInfoMapInfoMapInfoModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MapInfoModel mapInfoModelRet = AddMapInfoModel();
                        Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostAddMapInfoDB_DoAddChanges_Error_Test()
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
                        shimMapInfoService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        MapInfoModel mapInfoModelRet = AddMapInfoModel();
                        Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostAddMapInfoDB_Add_Error_Test()
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
                        shimMapInfoService.FillMapInfoMapInfoMapInfoModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        MapInfoModel mapInfoModelRet = AddMapInfoModel();
                        Assert.IsTrue(mapInfoModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostDeleteMapInfoDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoDB(mapInfoModelRet.MapInfoID);
                        Assert.AreEqual(ErrorText, mapInfoModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostDeleteMapInfoDB_GetMapInfoWithMapInfoIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMapInfoService.GetMapInfoWithMapInfoIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoDB(mapInfoModelRet.MapInfoID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MapInfo), mapInfoModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostDeleteMapInfoDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoDB(mapInfoModelRet.MapInfoID);
                        Assert.AreEqual(ErrorText, mapInfoModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostDeleteMapInfoWithTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoWithTVItemIDDB(mapInfoModelRet.MapInfoID);
                        Assert.AreEqual(ErrorText, mapInfoModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostDeleteMapInfoWithTVItemIDDB_PostDeleteMapInfoDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoService.PostDeleteMapInfoDBInt32 = (a) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoWithTVItemIDDB(mapInfoModelRet.TVItemID);
                        Assert.AreEqual(ErrorText, mapInfoModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostDeleteMapInfoWithTVPathStartWithDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    TVItemModel tvItemModelRet = tvItemService.GetTVItemModelWithTVItemIDDB(mapInfoModelRet.TVItemID);
                    Assert.AreEqual("", tvItemModelRet.Error);

                    MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoWithTVPathStartWithDB(tvItemModelRet.TVPath);
                    Assert.AreEqual("", mapInfoModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostDeleteMapInfoWithTVPathStartWithDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVItemModel tvItemModelRet = tvItemService.GetTVItemModelWithTVItemIDDB(mapInfoModelRet.TVItemID);
                        Assert.AreEqual("", tvItemModelRet.Error);

                        MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoWithTVPathStartWithDB(tvItemModelRet.TVPath);
                        Assert.AreEqual(ErrorText, mapInfoModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostDeleteMapInfoWithTVPathStartWithDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVItemModel tvItemModelRet = tvItemService.GetTVItemModelWithTVItemIDDB(mapInfoModelRet.TVItemID);
                        Assert.AreEqual("", tvItemModelRet.Error);

                        MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoWithTVPathStartWithDB(tvItemModelRet.TVPath);
                        Assert.AreEqual(ErrorText, mapInfoModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePointDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    float Lat = 44.444f;
                    float Lng = -64.444f;
                    MapInfoPointModel mapInfoPointModelRet = mapInfoService.PostSavePointDB(mapInfoPointModelList[0].MapInfoPointID, Lat, Lng);
                    Assert.AreEqual("", mapInfoPointModelRet.Error);
                    Assert.AreEqual(Lat, mapInfoPointModelRet.Lat);
                    Assert.AreEqual(Lng, mapInfoPointModelRet.Lng);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePointDB_MapInfoPointID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    float Lat = 44.444f;
                    float Lng = -64.444f;
                    int MapInfoID = 0;
                    MapInfoPointModel mapInfoPointModelRet = mapInfoService.PostSavePointDB(MapInfoID, Lat, Lng);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoID), mapInfoPointModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePointDB_Lat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    float Lat = -91.0f;
                    float Lng = -64.444f;
                    MapInfoPointModel mapInfoPointModelRet = mapInfoService.PostSavePointDB(mapInfoPointModelList[0].MapInfoPointID, Lat, Lng);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Lat, -90, 90), mapInfoPointModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePointDB_Lng_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    float Lat = 44.0f;
                    float Lng = -181.444f;
                    MapInfoPointModel mapInfoPointModelRet = mapInfoService.PostSavePointDB(mapInfoPointModelList[0].MapInfoPointID, Lat, Lng);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Lng, -180, 180), mapInfoPointModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePointDB_GetMapInfoPointModelWithMapInfoPointIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.GetMapInfoPointModelWithMapInfoPointIDDBInt32 = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };

                        float Lat = 44.0f;
                        float Lng = -64.444f;
                        MapInfoPointModel mapInfoPointModelRet = mapInfoService.PostSavePointDB(mapInfoPointModelList[0].MapInfoPointID, Lat, Lng);
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePointDB_PostUpdateMapInfoPointDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.PostUpdateMapInfoPointDBMapInfoPointModel = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };

                        float Lat = 44.0f;
                        float Lng = -64.444f;
                        MapInfoPointModel mapInfoPointModelRet = mapInfoService.PostSavePointDB(mapInfoPointModelList[0].MapInfoPointID, Lat, Lng);
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePointDB_GetMapInfoPointModelListWithMapInfoIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDBInt32 = (a) =>
                        {
                            return new List<MapInfoPointModel>();
                        };

                        float Lat = 44.0f;
                        float Lng = -64.444f;
                        MapInfoPointModel mapInfoPointModelRet = mapInfoService.PostSavePointDB(mapInfoPointModelList[0].MapInfoPointID, Lat, Lng);
                        Assert.AreEqual(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint), mapInfoPointModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePointDB_GetMapInfoModelWithMapInfoIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoService.GetMapInfoModelWithMapInfoIDDBInt32 = (a) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        float Lat = 44.0f;
                        float Lng = -64.444f;
                        MapInfoPointModel mapInfoPointModelRet = mapInfoService.PostSavePointDB(mapInfoPointModelList[0].MapInfoPointID, Lat, Lng);
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePointDB_PostUpdateMapInfoDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoService.PostUpdateMapInfoDBMapInfoModel = (a) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        float Lat = 44.0f;
                        float Lng = -64.444f;
                        MapInfoPointModel mapInfoPointModelRet = mapInfoService.PostSavePointDB(mapInfoPointModelList[0].MapInfoPointID, Lat, Lng);
                        Assert.AreEqual(ErrorText, mapInfoPointModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_SameMapInfoPointList_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        sb.Append(mapInfoPointModel.Lat + "s" + mapInfoPointModel.Lng + "p");
                    }

                    MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                    Assert.AreEqual("", mapInfoModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_ChangePolygonToOnly4Points_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        count += 1;
                        if (count < 4)
                        {
                            sb.Append(mapInfoPointModel.Lat + "s" + mapInfoPointModel.Lng + "p");
                        }
                    }

                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "p");

                    MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    List<MapInfoPointModel> mapInfoPointModelList2 = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.AreEqual(4, mapInfoPointModelList2.Count);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_ChangePolygonToMorePoints_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    int FirstCount = mapInfoPointModelList.Count;

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0, count = mapInfoPointModelList.Count; i < count - 1; i++)
                    {
                        sb.Append(mapInfoPointModelList[i].Lat + "s" + mapInfoPointModelList[i].Lng + "p");
                    }

                    sb.Append(mapInfoPointModelList[2].Lat + "s" + mapInfoPointModelList[2].Lng + "p");
                    sb.Append(mapInfoPointModelList[3].Lat + "s" + mapInfoPointModelList[3].Lng + "p");
                    sb.Append(mapInfoPointModelList[4].Lat + "s" + mapInfoPointModelList[4].Lng + "p");
                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "p");

                    MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    List<MapInfoPointModel> mapInfoPointModelList2 = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.AreEqual(FirstCount + 3, mapInfoPointModelList2.Count);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_MapInfoID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        count += 1;
                        if (count < 5)
                        {
                            sb.Append(mapInfoPointModel.Lat + "s" + mapInfoPointModel.Lng + "p");
                        }
                    }

                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "p");

                    int MapInfoID = 0;
                    MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), MapInfoID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoID), mapInfoModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_LatLngListText_Empty_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB("", mapInfoPointModelList[0].MapInfoID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LatLngListText), mapInfoModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_LatLngListText_No_s_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        count += 1;
                        if (count < 5)
                        {
                            sb.Append(mapInfoPointModel.Lat + "t" + mapInfoPointModel.Lng + "p");
                        }
                    }

                    sb.Append(mapInfoPointModelList[0].Lat + "t" + mapInfoPointModelList[0].Lng + "p");

                    MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                    Assert.AreEqual(ServiceRes.LatLngListTextShouldContainTheLetterSToSeparateLatLng, mapInfoModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_LatLngListText_No_p_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        count += 1;
                        if (count < 5)
                        {
                            sb.Append(mapInfoPointModel.Lat + "s" + mapInfoPointModel.Lng + "y");
                        }
                    }

                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "y");

                    MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                    Assert.AreEqual(ServiceRes.LatLngListTextShouldContainTheLetterSToSeparatePoints, mapInfoModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_GetMapInfoPointModelListWithMapInfoIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        count += 1;
                        if (count < 5)
                        {
                            sb.Append(mapInfoPointModel.Lat + "s" + mapInfoPointModel.Lng + "p");
                        }
                    }

                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "p");

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDBInt32 = (a) =>
                        {
                            return new List<MapInfoPointModel>();
                        };

                        MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                        Assert.AreEqual(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint), mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_GetMapInfoModelWithMapInfoIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        count += 1;
                        if (count < 5)
                        {
                            sb.Append(mapInfoPointModel.Lat + "s" + mapInfoPointModel.Lng + "p");
                        }
                    }

                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "p");

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoService.GetMapInfoModelWithMapInfoIDDBInt32 = (a) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                        Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_MapInfoPointCountBiggerThanLatLngListCount_PostUpdateMapInfoPointDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        count += 1;
                        if (count < 5)
                        {
                            sb.Append(mapInfoPointModel.Lat + "s" + mapInfoPointModel.Lng + "p");
                        }
                    }

                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "p");

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.PostUpdateMapInfoPointDBMapInfoPointModel = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                        Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_MapInfoPointCountBiggeThanrLatLngListCount_PostDeleteMapInfoPointDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        count += 1;
                        if (count < 5)
                        {
                            sb.Append(mapInfoPointModel.Lat + "s" + mapInfoPointModel.Lng + "p");
                        }
                    }

                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "p");

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.PostDeleteMapInfoPointDBInt32 = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                        Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_MapInfoPointCountSmallerThanLatLngListCount_PostUpdateMapInfoPointDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0, count = mapInfoPointModelList.Count; i < count - 1; i++)
                    {
                        sb.Append(mapInfoPointModelList[i].Lat + "s" + mapInfoPointModelList[i].Lng + "p");
                    }

                    sb.Append(mapInfoPointModelList[2].Lat + "s" + mapInfoPointModelList[2].Lng + "p");
                    sb.Append(mapInfoPointModelList[3].Lat + "s" + mapInfoPointModelList[3].Lng + "p");
                    sb.Append(mapInfoPointModelList[4].Lat + "s" + mapInfoPointModelList[4].Lng + "p");
                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "p");

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.PostUpdateMapInfoPointDBMapInfoPointModel = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                        Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_MapInfoPointCountSmallerThanLatLngListCount_PostDeleteMapInfoPointDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0, count = mapInfoPointModelList.Count; i < count - 1; i++)
                    {
                        sb.Append(mapInfoPointModelList[i].Lat + "s" + mapInfoPointModelList[i].Lng + "p");
                    }

                    sb.Append(mapInfoPointModelList[2].Lat + "s" + mapInfoPointModelList[2].Lng + "p");
                    sb.Append(mapInfoPointModelList[3].Lat + "s" + mapInfoPointModelList[3].Lng + "p");
                    sb.Append(mapInfoPointModelList[4].Lat + "s" + mapInfoPointModelList[4].Lng + "p");
                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "p");

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.PostAddMapInfoPointDBMapInfoPointModel = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                        Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_ChangePolygonToOnly3Points_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        count += 1;
                        if (count < 3)
                        {
                            sb.Append(mapInfoPointModel.Lat + "s" + mapInfoPointModel.Lng + "p");
                        }
                    }

                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "p");

                    MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                    Assert.AreEqual(ServiceRes.PolygonsShouldContainAtLeast4Points, mapInfoModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_ChangePolylineToOnly1Points_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeBoundaryCondition = randomService.RandomTVItem(TVTypeEnum.MikeBoundaryConditionMesh);
                    Assert.AreEqual("", tvItemModelMikeBoundaryCondition.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelMikeBoundaryCondition.TVItemID, TVTypeEnum.MikeBoundaryConditionMesh, MapInfoDrawTypeEnum.Polyline);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        count += 1;
                        if (count < 2)
                        {
                            sb.Append(mapInfoPointModel.Lat + "s" + mapInfoPointModel.Lng + "p");
                        }
                    }

                    MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                    Assert.AreEqual(ServiceRes.PolylinesShouldContainAtLeast2Points, mapInfoModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_GetMapInfoPointModelListWithMapInfoIDDB_number_2_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        count += 1;
                        if (count < 5)
                        {
                            sb.Append(mapInfoPointModel.Lat + "s" + mapInfoPointModel.Lng + "p");
                        }
                    }

                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "p");

                    List<MapInfoPointModel> mapInfoPointModelListFirst = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDB(mapInfoPointModelList[0].MapInfoID);

                    using (ShimsContext.Create())
                    {
                        int CountGet = 0;
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDBInt32 = (a) =>
                        {
                            CountGet += 1;
                            if (CountGet == 1)
                            {
                                return mapInfoPointModelListFirst;
                            }
                            else
                            {
                                return new List<MapInfoPointModel>();
                            }
                        };

                        MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                        Assert.AreEqual(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint), mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostSavePolyDB_PostUpdateMapInfoDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string PartOfTVTextSector = "NB-06-020";

                    TVItemModel tvItemModelSector = mapInfoService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, PartOfTVTextSector, TVTypeEnum.Sector);
                    Assert.AreEqual("", tvItemModelSector.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelSector.TVItemID, TVTypeEnum.Sector, MapInfoDrawTypeEnum.Polygon);
                    Assert.IsTrue(mapInfoPointModelList.Count > 0);

                    StringBuilder sb = new StringBuilder();
                    int count = 0;
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                    {
                        count += 1;
                        if (count < 5)
                        {
                            sb.Append(mapInfoPointModel.Lat + "s" + mapInfoPointModel.Lng + "p");
                        }
                    }

                    sb.Append(mapInfoPointModelList[0].Lat + "s" + mapInfoPointModelList[0].Lng + "p");

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoService.PostUpdateMapInfoDBMapInfoModel = (a) =>
                        {
                            return new MapInfoModel() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet = mapInfoService.PostSavePolyDB(sb.ToString(), mapInfoPointModelList[0].MapInfoID);
                        Assert.AreEqual(ErrorText, mapInfoModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostUpdateMapInfoDB_MapInfoModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoService.MapInfoModelOKMapInfoModel = (a) =>
                        {
                            return ErrorText;
                        };

                        MapInfoModel mapInfoModelRet2 = UpdateMapInfoModel(mapInfoModelRet);
                        Assert.AreEqual(ErrorText, mapInfoModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostUpdateMapInfoDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        MapInfoModel mapInfoModelRet2 = UpdateMapInfoModel(mapInfoModelRet);
                        Assert.AreEqual(ErrorText, mapInfoModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostUpdateMapInfoDB_GetMapInfoWithMapInfoIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimMapInfoService.GetMapInfoWithMapInfoIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        MapInfoModel mapInfoModelRet2 = UpdateMapInfoModel(mapInfoModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MapInfo), mapInfoModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostUpdateMapInfoDB_FillMapInfoModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoService.FillMapInfoMapInfoMapInfoModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        MapInfoModel mapInfoModelRet2 = UpdateMapInfoModel(mapInfoModelRet);
                        Assert.AreEqual(ErrorText, mapInfoModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void MapInfoService_PostUpdateMapInfoDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MapInfoModel mapInfoModelRet = AddMapInfoModel();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimMapInfoService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        MapInfoModel mapInfoModelRet2 = UpdateMapInfoModel(mapInfoModelRet);
                        Assert.AreEqual(ErrorText, mapInfoModelRet2.Error);
                    }
                }
            }
        }
        //[TestMethod]
        //public void MapInfoService_ResetDrainageAreaWithTVItemIDWillCreatePolygonIfItDoesNotExistDB_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        int MikeSourceTVItemID = 357140;

        //        FileInfo fi = new FileInfo(@"C:\CSSP Latest Code Old\CSSPDBDLL\test.kml");
        //        Assert.IsTrue(fi.Exists);

        //        TextReader tr = fi.OpenText();
        //        string KMLDrainageArea = tr.ReadToEnd();
        //        tr.Close();

        //        MapInfoModel mapInfoModel = mapInfoService.ResetDrainageAreaWithTVItemIDWillCreatePolygonIfItDoesNotExistDB(MikeSourceTVItemID, KMLDrainageArea);
        //        Assert.AreEqual("", mapInfoModel.Error);

        //        break;
        //    }
        //}
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions
        public MapInfoModel AddMapInfoModel()
        {
            FillMapInfoModel(mapInfoModelNew);

            MapInfoModel mapInfoModelRet = mapInfoService.PostAddMapInfoDB(mapInfoModelNew);
            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
            {
                return mapInfoModelRet;
            }

            mapInfoModelNew.MapInfoID = mapInfoModelRet.MapInfoID;

            CompareMapInfoModels(mapInfoModelNew, mapInfoModelRet);

            return mapInfoModelRet;
        }
        public MapInfoModel UpdateMapInfoModel(MapInfoModel mapInfoModel)
        {
            FillMapInfoModel(mapInfoModel);

            MapInfoModel mapInfoModelRet = mapInfoService.PostUpdateMapInfoDB(mapInfoModel);
            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
            {
                return mapInfoModelRet;
            }

            CompareMapInfoModels(mapInfoModel, mapInfoModelRet);

            return mapInfoModelRet;
        }
        private void CompareMapInfoModels(MapInfoModel mapInfoModelNew, MapInfoModel mapInfoModelRet)
        {
            Assert.AreEqual(mapInfoModelNew.TVItemID, mapInfoModelRet.TVItemID);
            Assert.AreEqual(mapInfoModelNew.TVType, mapInfoModelRet.TVType);
        }
        private void FillMapInfoModel(MapInfoModel mapInfoModel)
        {
            mapInfoModel.TVItemID = randomService.RandomTVItem(TVTypeEnum.Municipality).TVItemID;
            mapInfoModel.TVType = TVTypeEnum.Municipality;
            mapInfoModel.LatMin = 45.0D;
            mapInfoModel.LatMax = 46.0D;
            mapInfoModel.LngMin = -66.0D;
            mapInfoModel.LngMax = -65.0D;

            Assert.IsTrue(mapInfoModel.TVItemID != 0);
            Assert.IsTrue(mapInfoModel.TVType == TVTypeEnum.Municipality);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            mapInfoService = new MapInfoService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mapInfoModelNew = new MapInfoModel();
            mapInfo = new MapInfo();
            mwqmSampleService = new MWQMSampleService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
        }
        private void SetupShim()
        {
            shimMapInfoService = new ShimMapInfoService(mapInfoService);
            shimMapInfoPointService = new ShimMapInfoPointService(mapInfoService._MapInfoPointService);
            shimTVItemService = new ShimTVItemService(mapInfoService._TVItemService);
        }
        #endregion Functions
    }
}

