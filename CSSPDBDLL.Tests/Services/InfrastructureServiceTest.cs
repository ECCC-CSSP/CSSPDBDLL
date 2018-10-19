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
using System.Threading;
using System.Globalization;
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for InfrastructureServiceTest
    /// </summary>
    [TestClass]
    public class InfrastructureServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "Infrastructure";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private InfrastructureService infrastructureService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private InfrastructureModel infrastructureModelNew { get; set; }
        private Infrastructure infrastructure { get; set; }
        private ShimInfrastructureService shimInfrastructureService { get; set; }
        private ShimInfrastructureLanguageService shimInfrastructureLanguageService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVItemLanguageService shimTVItemLanguageService { get; set; }
        private ShimMapInfoService shimMapInfoService { get; set; }
        private ShimMapInfoPointService shimMapInfoPointService { get; set; }
        private ShimTVItemLinkService shimTVItemLinkService { get; set; }
        private TVItemService tvItemService { get; set; }
        private MapInfoService mapInfoService { get; set; }
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
        public InfrastructureServiceTest()
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
        public void Create_Polyline_Between_Infrastructure_and_outfall_Test()
        {
            //SetupTest(contactModelListGood[0], setupData.cultureListGood.First());

            //MapInfoService _MapInfoService = new MapInfoService("en", user);

            //List<TVItem> tvItemList = (from c in infrastructureService.db.TVItems
            //                                   where c.TVItemID > 232422
            //                                   && c.TVType == (int)TVTypeEnum.Infrastructure
            //                                   orderby c.TVItemID
            //                                   select c).ToList();

            //int count = 0;
            //foreach (TVItem tvItem in tvItemList)
            //{
            //    count += 1;
            //    if (count % 100 == 0)
            //    {
            //        int sefi = 34;
            //    }
            //    int TVItemID = tvItem.TVItemID;

            //    InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(TVItemID);
            //    Assert.AreEqual("", infrastructureModel.Error);

            //    if (infrastructureModel.InfrastructureType == null)
            //        continue;

            //    TVTypeEnum tvType = TVTypeEnum.Error;

            //    switch (infrastructureModel.InfrastructureType)
            //    {
            //        case InfrastructureTypeEnum.LiftStation:
            //            tvType = TVTypeEnum.LiftStation;
            //            break;
            //        case InfrastructureTypeEnum.WWTP:
            //            tvType = TVTypeEnum.WasteWaterTreatmentPlant;
            //            break;
            //        case InfrastructureTypeEnum.LineOverflow:
            //            tvType = TVTypeEnum.LineOverflow;
            //            break;
            //        case InfrastructureTypeEnum.Other:
            //            tvType = TVTypeEnum.OtherInfrastructure;
            //            break;
            //        case InfrastructureTypeEnum.SeeOther:
            //            tvType = TVTypeEnum.SeeOther;
            //            break;
            //        default:
            //            break;
            //    }

            //    List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemID, tvType, MapInfoDrawTypeEnum.Point);
            //    Assert.IsTrue(mapInfoPointModelList.Count > 0);

            //    List<MapInfoPointModel> mapInfoPointModelOutfallList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Point);
            //    if (mapInfoPointModelOutfallList.Count == 0)
            //    {
            //        mapInfoPointModelOutfallList.Add(new MapInfoPointModel() { Lat = mapInfoPointModelList[0].Lat + 0.0001f, Lng = mapInfoPointModelList[0].Lng + 0.0001f, Ordinal = 0 });
            //    }

            //    // doing outfall polyline
            //    List<Coord> coordList = new List<Coord>();
            //    coordList.Add(new Coord() { Lat = (float)mapInfoPointModelList[0].Lat, Lng = (float)mapInfoPointModelList[0].Lng, Ordinal = 0 });
            //    coordList.Add(new Coord() { Lat = (float)mapInfoPointModelOutfallList[0].Lat, Lng = (float)mapInfoPointModelOutfallList[0].Lng, Ordinal = 1 });

            //    List<MapInfoPointModel> mapInfoModelPointList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Polyline);
            //    if (mapInfoModelPointList.Count > 0)
            //    {
            //        MapInfoModel mapInfoModel = _MapInfoService.PostDeleteMapInfoDB(mapInfoModelPointList[0].MapInfoID);
            //        Assert.AreEqual("", mapInfoModel.Error);
            //    }

            //    MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polyline, TVTypeEnum.Outfall, TVItemID);
            //    Assert.AreEqual("", mapInfoModelRet.Error);
            //}
        }
        [TestMethod]
        public void Create_Polyline_With_All_TVItemLinks_Test()
        {
            SetupTest(contactModelListGood[0], setupData.cultureListGood.First());

            MapInfoService _MapInfoService = new MapInfoService(LanguageEnum.en, user);

            List<TVItemLink> tvItemLinkList = (from c in infrastructureService.db.TVItemLinks
                                               where c.TVItemLinkID == 3704
                                               orderby c.TVItemLinkID
                                               select c).ToList();

            int count = 0;
            foreach (TVItemLink tvItemLink in tvItemLinkList)
            {
                count += 1;
                if (count % 100 == 0)
                {
                    //int sef = 545;
                }

                if (tvItemLink.FromTVType == (int)TVTypeEnum.Infrastructure && tvItemLink.ToTVType == (int)TVTypeEnum.Infrastructure)
                {
                    // From
                    InfrastructureModel infrastructureModelFrom = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemLink.FromTVItemID);
                    Assert.AreEqual("", infrastructureModelFrom.Error);

                    TVTypeEnum tvTypeFrom = TVTypeEnum.Error;

                    if (infrastructureModelFrom.InfrastructureType == null)
                        continue;

                    switch (infrastructureModelFrom.InfrastructureType)
                    {
                        case InfrastructureTypeEnum.LiftStation:
                            tvTypeFrom = TVTypeEnum.LiftStation;
                            break;
                        case InfrastructureTypeEnum.WWTP:
                            tvTypeFrom = TVTypeEnum.WasteWaterTreatmentPlant;
                            break;
                        case InfrastructureTypeEnum.LineOverflow:
                            tvTypeFrom = TVTypeEnum.LineOverflow;
                            break;
                        case InfrastructureTypeEnum.Other:
                            tvTypeFrom = TVTypeEnum.OtherInfrastructure;
                            break;
                        case InfrastructureTypeEnum.SeeOther:
                            tvTypeFrom = TVTypeEnum.SeeOther;
                            break;
                        default:
                            break;
                    }

                    List<MapInfoPointModel> mapInfoPointModelFromList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemLink.FromTVItemID, tvTypeFrom, MapInfoDrawTypeEnum.Point);
                    Assert.IsTrue(mapInfoPointModelFromList.Count > 0);


                    // To
                    InfrastructureModel infrastructureModelTo = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemLink.ToTVItemID);
                    Assert.AreEqual("", infrastructureModelTo.Error);

                    TVTypeEnum tvTypeTo = TVTypeEnum.Error;

                    if (infrastructureModelTo.InfrastructureType == null)
                        continue;

                    switch (infrastructureModelTo.InfrastructureType)
                    {
                        case InfrastructureTypeEnum.LiftStation:
                            tvTypeTo = TVTypeEnum.LiftStation;
                            break;
                        case InfrastructureTypeEnum.WWTP:
                            tvTypeTo = TVTypeEnum.WasteWaterTreatmentPlant;
                            break;
                        case InfrastructureTypeEnum.LineOverflow:
                            tvTypeTo = TVTypeEnum.LineOverflow;
                            break;
                        case InfrastructureTypeEnum.Other:
                            tvTypeTo = TVTypeEnum.OtherInfrastructure;
                            break;
                        case InfrastructureTypeEnum.SeeOther:
                            tvTypeTo = TVTypeEnum.SeeOther;
                            break;
                        default:
                            break;
                    }

                    List<MapInfoPointModel> mapInfoPointModelToList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemLink.ToTVItemID, tvTypeTo, MapInfoDrawTypeEnum.Point);
                    Assert.IsTrue(mapInfoPointModelToList.Count > 0);

                    // doing TVItemLink polyline
                    List<Coord> coordList = new List<Coord>();
                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModelFromList[0].Lat, Lng = (float)mapInfoPointModelFromList[0].Lng, Ordinal = 0 });
                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModelToList[0].Lat, Lng = (float)mapInfoPointModelToList[0].Lng, Ordinal = 1 });

                    List<MapInfoPointModel> mapInfoModelPointList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemLink.FromTVItemID, tvTypeFrom, MapInfoDrawTypeEnum.Polyline);
                    if (mapInfoModelPointList.Count > 0)
                    {
                        MapInfoModel mapInfoModel = _MapInfoService.PostDeleteMapInfoDB(mapInfoModelPointList[0].MapInfoID);
                        Assert.AreEqual("", mapInfoModel.Error);
                    }

                    MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polyline, tvTypeFrom, tvItemLink.FromTVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);
                }
            }

        }
        [TestMethod]
        public void InfrastructureService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);
                Assert.IsNotNull(infrastructureService);
                Assert.IsNotNull(infrastructureService._InfrastructureLanguageService);
                Assert.IsNotNull(infrastructureService._TVItemService);
                Assert.IsNotNull(infrastructureService._TVItemService._TVItemLanguageService);
                Assert.IsNotNull(infrastructureService.db);
                Assert.IsNotNull(infrastructureService.LanguageRequest);
                Assert.IsNotNull(infrastructureService.User);
                Assert.AreEqual(user.Identity.Name, infrastructureService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), infrastructureService.LanguageRequest);
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModel = AddInfrastructureModel();

                    Assert.AreEqual("", infrastructureModel.Error);

                    #region Good
                    infrastructureModelNew.InfrastructureTVItemID = infrastructureModel.InfrastructureTVItemID;
                    FillInfrastructureModel(infrastructureModelNew);

                    string retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region InfrastructureTVText
                    int Min = 2;
                    int Max = 200;
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.InfrastructureTVText = randomService.RandomString("", Min - 1);

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.InfrastructureTVText, Min), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.InfrastructureTVText = randomService.RandomString("", Max + 1);

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.InfrastructureTVText, Max), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.InfrastructureTVText = randomService.RandomString("", Max - 1);

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.InfrastructureTVText = randomService.RandomString("", Min);

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.InfrastructureTVText = randomService.RandomString("", Max);

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion InfrastructureTVText

                    #region InfrastructureTVItemID
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.InfrastructureTVItemID = 0;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID), retStr);

                    infrastructureModelNew.InfrastructureTVItemID = infrastructureModel.InfrastructureTVItemID;
                    FillInfrastructureModel(infrastructureModelNew);

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion InfrastructureTVItemID

                    #region PrismID
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PrismID = 0;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.PrismID), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PrismID = 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion PrismID

                    #region TPID
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.TPID = 0;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TPID), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.TPID = 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TPID

                    #region LSID
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.LSID = 0;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.LSID), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.LSID = 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion LSID

                    #region SiteID
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.SiteID = 0;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.SiteID), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.SiteID = 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion SiteID

                    #region Site
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.Site = 0;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Site), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.Site = 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Site

                    #region InfrastructureCategory
                    Max = 1;
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.InfrastructureCategory = "AA";

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.InfrastructureCategory, Max), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.InfrastructureCategory = "";

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.InfrastructureCategory = "A";

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion InfrastructureCategory

                    #region InfrastructureType
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.InfrastructureType = (InfrastructureTypeEnum)100000;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureType), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.InfrastructureType = InfrastructureTypeEnum.LiftStation;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.InfrastructureType = null;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion InfrastructureType

                    #region FacilityType
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.FacilityType = (FacilityTypeEnum)100000;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FacilityType), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.FacilityType = FacilityTypeEnum.Lagoon;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion FacilityType

                    #region IsMechanicallyAerated
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.IsMechanicallyAerated = true;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.IsMechanicallyAerated = false;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion IsMechanicallyAerated

                    #region NumberOfCells
                    int min = 0;
                    int max = 6;
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfCells = min - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.NumberOfCells, min, max), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfCells = max + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.NumberOfCells, min, max), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfCells = min;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfCells = max;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfCells = max - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion NumberOfCells

                    #region NumberOfAeratedCells
                    min = 0;
                    max = 6;
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfAeratedCells = min - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.NumberOfAeratedCells, min, max), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfAeratedCells = max + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.NumberOfAeratedCells, min, max), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfAeratedCells = min;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfAeratedCells = max;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfAeratedCells = max - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion NumberOfAeratedCells

                    #region TreatmentType
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.TreatmentType = (TreatmentTypeEnum)100000;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TreatmentType), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.TreatmentType = TreatmentTypeEnum.ActivatedSludgeWithBiofilter;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TreatmentType

                    #region DisinfectionType
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DisinfectionType = (DisinfectionTypeEnum)100000;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.DisinfectionType), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DisinfectionType = DisinfectionTypeEnum.ChlorinationWithDechlorination;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion DisinfectionType

                    #region CollectionSystemType
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.CollectionSystemType = (CollectionSystemTypeEnum)10000;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.CollectionSystemType), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.CollectionSystemType = CollectionSystemTypeEnum.Combined50Separated50;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion CollectionSystemType

                    #region AlarmSystemType
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.AlarmSystemType = (AlarmSystemTypeEnum)10000;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.AlarmSystemType), retStr);
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.AlarmSystemType = AlarmSystemTypeEnum.SCADA;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion AlarmSystemType

                    #region DesignFlow_m3_day
                    FillInfrastructureModel(infrastructureModelNew);
                    double MinDbl = 0.0000001D;
                    double MaxDbl = 10000000D;
                    infrastructureModelNew.DesignFlow_m3_day = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DesignFlow_m3_day, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DesignFlow_m3_day = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DesignFlow_m3_day, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DesignFlow_m3_day = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DesignFlow_m3_day = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DesignFlow_m3_day = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion DesignFlow_m3_day

                    #region AverageFlow_m3_day
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0.0000001D;
                    MaxDbl = 10000000D;
                    infrastructureModelNew.AverageFlow_m3_day = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AverageFlow_m3_day, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.AverageFlow_m3_day = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AverageFlow_m3_day, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.AverageFlow_m3_day = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.AverageFlow_m3_day = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.AverageFlow_m3_day = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion AverageFlow_m3_day

                    #region PeakFlow_m3_day
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0.0000001D;
                    MaxDbl = 10000000D;
                    infrastructureModelNew.PeakFlow_m3_day = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PeakFlow_m3_day, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PeakFlow_m3_day = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PeakFlow_m3_day, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PeakFlow_m3_day = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PeakFlow_m3_day = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PeakFlow_m3_day = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion PeakFlow_m3_day

                    #region PopServed
                    FillInfrastructureModel(infrastructureModelNew);
                    Min = 5;
                    Max = 100000000;
                    infrastructureModelNew.PopServed = Min - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PopServed, Min, Max), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PopServed = Max + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PopServed, Min, Max), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PopServed = Max - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PopServed = Min;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PopServed = Max;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion PopServed

                    #region PercFlowOfTotal
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0D;
                    MaxDbl = 100D;
                    infrastructureModelNew.PercFlowOfTotal = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PercFlowOfTotal, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PercFlowOfTotal = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PercFlowOfTotal, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PercFlowOfTotal = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PercFlowOfTotal = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PercFlowOfTotal = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion PercFlowOfTotal

                    #region TimeOffset_hour
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = -8;
                    MaxDbl = -3;
                    infrastructureModelNew.TimeOffset_hour = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TimeOffset_hour, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.TimeOffset_hour = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.TimeOffset_hour, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.TimeOffset_hour = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.TimeOffset_hour = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.TimeOffset_hour = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion TimeOffset_hour

                    #region AverageDepth_m
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0.01D;
                    MaxDbl = 10000D;
                    infrastructureModelNew.AverageDepth_m = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AverageDepth_m, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.AverageDepth_m = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.AverageDepth_m, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.AverageDepth_m = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.AverageDepth_m = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.AverageDepth_m = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion AverageDepth_m

                    #region NumberOfPorts
                    FillInfrastructureModel(infrastructureModelNew);
                    Min = 1;
                    Max = 200;
                    infrastructureModelNew.NumberOfPorts = Min - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.NumberOfPorts, Min, Max), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfPorts = Max + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.NumberOfPorts, Min, Max), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfPorts = Max - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfPorts = Min;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NumberOfPorts = Max;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion NumberOfPorts

                    #region PortDiameter_m
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0.01D;
                    MaxDbl = 10D;
                    infrastructureModelNew.PortDiameter_m = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortDiameter_m, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PortDiameter_m = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortDiameter_m, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PortDiameter_m = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PortDiameter_m = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PortDiameter_m = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion PortDiameter_m

                    #region PortSpacing_m
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0.01D;
                    MaxDbl = 10000D;
                    infrastructureModelNew.PortSpacing_m = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortSpacing_m, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PortSpacing_m = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortSpacing_m, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PortSpacing_m = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PortSpacing_m = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PortSpacing_m = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion PortSpacing_m

                    #region PortElevation_m
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0.01D;
                    MaxDbl = 10000D;
                    infrastructureModelNew.PortElevation_m = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortElevation_m, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PortElevation_m = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PortElevation_m, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PortElevation_m = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PortElevation_m = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.PortElevation_m = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion PortElevation_m

                    #region VerticalAngle_deg
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = -90D;
                    MaxDbl = 90D;
                    infrastructureModelNew.VerticalAngle_deg = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.VerticalAngle_deg, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.VerticalAngle_deg = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.VerticalAngle_deg, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.VerticalAngle_deg = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.VerticalAngle_deg = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.VerticalAngle_deg = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion VerticalAngle_deg

                    #region HorizontalAngle_deg
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = -180D;
                    MaxDbl = 180D;
                    infrastructureModelNew.HorizontalAngle_deg = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.HorizontalAngle_deg, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.HorizontalAngle_deg = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.HorizontalAngle_deg, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.HorizontalAngle_deg = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.HorizontalAngle_deg = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.HorizontalAngle_deg = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion HorizontalAngle_deg

                    #region DecayRate_per_day
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0D;
                    MaxDbl = 1000D;
                    infrastructureModelNew.DecayRate_per_day = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DecayRate_per_day, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DecayRate_per_day = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DecayRate_per_day, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DecayRate_per_day = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DecayRate_per_day = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DecayRate_per_day = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion DecayRate_per_day

                    #region NearFieldVelocity_m_s
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0D;
                    MaxDbl = 10D;
                    infrastructureModelNew.NearFieldVelocity_m_s = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.NearFieldVelocity_m_s, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NearFieldVelocity_m_s = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.NearFieldVelocity_m_s, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NearFieldVelocity_m_s = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NearFieldVelocity_m_s = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.NearFieldVelocity_m_s = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion NearFieldVelocity_m_s

                    #region FarFieldVelocity_m_s
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0D;
                    MaxDbl = 10D;
                    infrastructureModelNew.FarFieldVelocity_m_s = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FarFieldVelocity_m_s, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.FarFieldVelocity_m_s = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FarFieldVelocity_m_s, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.FarFieldVelocity_m_s = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.FarFieldVelocity_m_s = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.FarFieldVelocity_m_s = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion FarFieldVelocity_m_s

                    #region ReceivingWaterSalinity_PSU
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0D;
                    MaxDbl = 35D;
                    infrastructureModelNew.ReceivingWaterSalinity_PSU = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ReceivingWaterSalinity_PSU, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.ReceivingWaterSalinity_PSU = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ReceivingWaterSalinity_PSU, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.ReceivingWaterSalinity_PSU = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.ReceivingWaterSalinity_PSU = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.ReceivingWaterSalinity_PSU = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion ReceivingWaterSalinity_PSU

                    #region ReceivingWaterTemperature_C
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0D;
                    MaxDbl = 35D;
                    infrastructureModelNew.ReceivingWaterTemperature_C = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ReceivingWaterTemperature_C, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.ReceivingWaterTemperature_C = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ReceivingWaterTemperature_C, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.ReceivingWaterTemperature_C = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.ReceivingWaterTemperature_C = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.ReceivingWaterTemperature_C = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion ReceivingWaterTemperature_C

                    #region ReceivingWater_MPN_per_100ml
                    FillInfrastructureModel(infrastructureModelNew);
                    Min = 0;
                    Max = 30000000;
                    infrastructureModelNew.ReceivingWater_MPN_per_100ml = Min - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ReceivingWater_MPN_per_100ml, Min, Max), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.ReceivingWater_MPN_per_100ml = Max + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.ReceivingWater_MPN_per_100ml, Min, Max), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.ReceivingWater_MPN_per_100ml = Max - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.ReceivingWater_MPN_per_100ml = Min;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.ReceivingWater_MPN_per_100ml = Max;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion ReceivingWater_MPN_per_100ml

                    #region DistanceFromShore_m
                    FillInfrastructureModel(infrastructureModelNew);
                    MinDbl = 0D;
                    MaxDbl = 10000D;
                    infrastructureModelNew.DistanceFromShore_m = MinDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DistanceFromShore_m, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DistanceFromShore_m = MaxDbl + 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.DistanceFromShore_m, MinDbl, MaxDbl), retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DistanceFromShore_m = MaxDbl - 1;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DistanceFromShore_m = MinDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.DistanceFromShore_m = MaxDbl;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    #endregion DistanceFromShore_m

                    #region Comment
                    Max = 10000;
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.Comment = null;

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual("", retStr);

                    infrastructureModelNew.InfrastructureTVItemID = infrastructureModel.InfrastructureTVItemID;
                    FillInfrastructureModel(infrastructureModelNew);
                    infrastructureModelNew.Comment = randomService.RandomString("", Max + 1);

                    retStr = infrastructureService.InfrastructureModelOK(infrastructureModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Comment, Max), retStr);
                    #endregion Comment

                }
            }
        }
        [TestMethod]
        public void InfrastructureService_FillInfrastructure_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    infrastructureModelNew.InfrastructureTVItemID = randomService.RandomTVItem(TVTypeEnum.Infrastructure).TVItemID;
                    infrastructureModelNew.InfrastructureTVText = randomService.RandomString("Infr ", 20);
                    FillInfrastructureModel(infrastructureModelNew);

                    ContactOK contactOK = infrastructureService.IsContactOK();

                    string retStr = infrastructureService.FillInfrastructure(infrastructure, infrastructureModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, infrastructure.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = infrastructureService.FillInfrastructure(infrastructure, infrastructureModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactModelListGood[0].ContactTVItemID, infrastructure.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_GetInfrastructureModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();

                    int infrastructureCount = infrastructureService.GetInfrastructureModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, infrastructureCount);

                }
            }
        }
        [TestMethod]
        public void InfrastructureService_GetInfrastructureModelWithInfrastructureIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();

                    InfrastructureModel infrastructureModelRet2 = infrastructureService.GetInfrastructureModelWithInfrastructureIDDB(infrastructureModelRet.InfrastructureID);

                    CompareInfrastructureModels(infrastructureModelRet, infrastructureModelRet2);

                    int InfrastructureID = 0;
                    infrastructureModelRet2 = infrastructureService.GetInfrastructureModelWithInfrastructureIDDB(InfrastructureID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Infrastructure, ServiceRes.InfrastructureID, InfrastructureID), infrastructureModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_GetInfrastructureModelWithInfrastructureTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();

                    InfrastructureModel infrastructureModelRet2 = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(infrastructureModelRet.InfrastructureTVItemID);

                    CompareInfrastructureModels(infrastructureModelRet, infrastructureModelRet2);

                    int InfrastructureTVItemID = 0;
                    infrastructureModelRet2 = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Infrastructure, ServiceRes.InfrastructureTVItemID, InfrastructureTVItemID), infrastructureModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_GetInfrastructureWithInfrastructureIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();

                    Infrastructure infrastructureRet = infrastructureService.GetInfrastructureWithInfrastructureIDDB(infrastructureModelRet.InfrastructureID);
                    Assert.AreEqual(infrastructureRet.InfrastructureID, infrastructureModelRet.InfrastructureID);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_GetInfrastructureTVItemAndTVItemLinkAndInfrastructureTypeListWithMunicipalityTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = infrastructureService._TVItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelBouctouche = infrastructureService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouctouche.Error);

                    List<TVItemModelInfrastructureTypeTVItemLinkModel> tvItemModelInfrastructureTypeTVItemLinkModel = infrastructureService.GetInfrastructureTVItemAndTVItemLinkAndInfrastructureTypeListWithMunicipalityTVItemIDDB(tvItemModelBouctouche.TVItemID);
                    Assert.IsNotNull(tvItemModelInfrastructureTypeTVItemLinkModel);
                    Assert.IsTrue(tvItemModelInfrastructureTypeTVItemLinkModel.Count > 0);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_CreateTVText_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    string retStr = infrastructureService.CreateTVText(infrastructureModelRet);
                    Assert.AreEqual(infrastructureModelRet.InfrastructureTVText, retStr);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    InfrastructureModel infrastructureModelRet = infrastructureService.ReturnError(ErrorText);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_Add_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "unique infrastructure";
                    fc["InfrastructureTVItemID"] = "0";

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual("", infrastructureModel.Error);
                    Assert.IsNull(infrastructure.SeeOtherTVItemID);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_Add_Good_With_SeeOtherTVItemID_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "unique infrastructure";
                    fc["InfrastructureTVItemID"] = "0";
                    fc["InfrastructureType"] = ((int)InfrastructureTypeEnum.SeeOther).ToString();
                    fc["SeeOtherTVItemID"] = (randomService.RandomTVItem(TVTypeEnum.Municipality).TVItemID).ToString();

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual("", infrastructureModel.Error);
                    Assert.AreEqual(int.Parse(fc["SeeOtherTVItemID"]), infrastructureModel.SeeOtherTVItemID);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_Add_Good_With_SeeOtherTVItemID_Error_Same_Municipality_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "unique infrastructure";
                    fc["InfrastructureTVItemID"] = "0";
                    fc["InfrastructureType"] = ((int)InfrastructureTypeEnum.SeeOther).ToString();
                    fc["SeeOtherTVItemID"] = fc["TVItemIDMunicipality"].ToString();

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual(ServiceRes.SeeOtherShouldBeReferingToAnotherMunicipality, infrastructureModel.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_Add_Good_With_SeeOtherTVItemID_Error_Not_Municipality_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "unique infrastructure";
                    fc["InfrastructureTVItemID"] = "0";
                    fc["InfrastructureType"] = ((int)InfrastructureTypeEnum.SeeOther).ToString();
                    fc["SeeOtherTVItemID"] = (randomService.RandomTVItem(TVTypeEnum.Province).TVItemID).ToString();

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual(ServiceRes.SeeOtherShouldBeReferingToAnotherMunicipality, infrastructureModel.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimInfrastructureService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, infrastructureModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_InfrastructureTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "";
                    fc["InfrastructureTVItemID"] = "0";

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVText), infrastructureModel.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_TVItemIDMunicipality_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["TVItemIDMunicipality"] = "0";
                    fc["InfrastructureTVItemID"] = "0";

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemIDMunicipality), infrastructureModel.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, infrastructureModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_InfrastructureType_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureType"] = "";
                    fc["InfrastructureTVItemID"] = "0";

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureType), infrastructureModel.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_Lat_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVItemID"] = "0";
                    fc["Lat"] = "0";

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Lat), infrastructureModel.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_Lng_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVItemID"] = "0";
                    fc["Lng"] = "0";

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Lng), infrastructureModel.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_Add_PostAddChildTVItemDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "Unique Infrastructure";
                    fc["InfrastructureTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.PostAddChildTVItemDBInt32StringTVTypeEnum = (a, b, c) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, infrastructureModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_Add_PostAddInfrastructureDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "Unique Infrastructure";
                    fc["InfrastructureTVItemID"] = "0";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimInfrastructureService.PostAddInfrastructureDBInfrastructureModel = (a) =>
                        {
                            return new InfrastructureModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, infrastructureModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_Modify_GetInfrastructureModelWithInfrastructureTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "unique infrastructure";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimInfrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDBInt32 = (a) =>
                        {
                            return new InfrastructureModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, infrastructureModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_Modify_PostUpdateInfrastructureDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "Changed Infrastructure";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimInfrastructureService.PostUpdateInfrastructureDBInfrastructureModel = (a) =>
                        {
                            return new InfrastructureModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, infrastructureModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_Modify_CreateMapInfoObjectDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "Changed Infrastructure";

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

                        InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, infrastructureModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureAddOrModifyDB_Modify_PostUpdateMapInfoPointDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "Changed Infrastructure";

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimMapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDBInt32TVTypeEnumMapInfoDrawTypeEnum = (a, b, c) =>
                        {
                            return new List<MapInfoPointModel>() { new MapInfoPointModel() };
                        };
                        shimMapInfoPointService.PostUpdateMapInfoPointDBMapInfoPointModel = (a) =>
                        {
                            return new MapInfoPointModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                        Assert.AreEqual(ErrorText, infrastructureModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureSaveAllDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual("", infrastructureModel.Error);

                    fc = FillInfrastructureSaveAllDBFormCollection(infrastructureModel);

                    infrastructureModel = infrastructureService.InfrastructureSaveAllDB(fc);
                    Assert.AreEqual("", infrastructureModel.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureSaveAllDB_Lat_Equal_0_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual("", infrastructureModel.Error);

                    fc = FillInfrastructureSaveAllDBFormCollection(infrastructureModel);
                    fc["Lat"] = "0.0";

                    infrastructureModel = infrastructureService.InfrastructureSaveAllDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Lat), infrastructureModel.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureSaveAllDB_WithNulls_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual("", infrastructureModel.Error);

                    fc = FillInfrastructureSaveAllDBFormCollection(infrastructureModel);
                    fc["InfrastructureType"] = "";
                    fc["TreatmentType"] = "";
                    fc["DisinfectionType"] = "";
                    fc["CollectionSystemType"] = "";
                    fc["AlarmSystemType"] = "";
                    fc["DesignFlow_m3_day"] = "";
                    fc["AverageFlow_m3_day"] = "";
                    fc["PeakFlow_m3_day"] = "";
                    fc["CanOverflow"] = "";
                    fc["PopServed"] = "";
                    fc["CanOverflow"] = "";
                    fc["PercFlowOfTotal"] = "";
                    fc["TimeOffset_hour"] = "";
                    fc["AverageDepth_m"] = "";
                    fc["NumberOfPorts"] = "";
                    fc["PortDiameter_m"] = "";
                    fc["PortSpacing_m"] = "";
                    fc["PortElevation_m"] = "";
                    fc["VerticalAngle_deg"] = "";
                    fc["HorizontalAngle_deg"] = "";
                    fc["DecayRate_per_day"] = "";
                    fc["NearFieldVelocity_m_s"] = "";
                    fc["FarFieldVelocity_m_s"] = "";
                    fc["ReceivingWaterSalinity_PSU"] = "";
                    fc["ReceivingWaterTemperature_C"] = "";
                    fc["ReceivingWater_MPN_per_100ml"] = "";
                    fc["DistanceFromShore_m"] = "";
                    fc["TempCatchAllRemoveLater"] = "";
                    fc["InputDataComments"] = "";
                    fc["Comments"] = "";

                    infrastructureModel = infrastructureService.InfrastructureSaveAllDB(fc);
                    Assert.AreEqual("", infrastructureModel.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureSaveAllDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual("", infrastructureModel.Error);

                    fc = FillInfrastructureSaveAllDBFormCollection(infrastructureModel);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimInfrastructureService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        infrastructureModel = infrastructureService.InfrastructureSaveAllDB(fc);
                        Assert.AreEqual(ErrorText, infrastructureModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureSaveAllDB_InfrastructureTVItemID_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual("", infrastructureModel.Error);

                    fc = FillInfrastructureSaveAllDBFormCollection(infrastructureModel);
                    fc["InfrastructureTVItemID"] = "0";

                    infrastructureModel = infrastructureService.InfrastructureSaveAllDB(fc);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID), infrastructureModel.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureSaveAllDB_GetInfrastructureModelWithInfrastructureTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual("", infrastructureModel.Error);

                    fc = FillInfrastructureSaveAllDBFormCollection(infrastructureModel);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimInfrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDBInt32 = (a) =>
                        {
                            return new InfrastructureModel() { Error = ErrorText };
                        };

                        infrastructureModel = infrastructureService.InfrastructureSaveAllDB(fc);
                        Assert.AreEqual(ErrorText, infrastructureModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_InfrastructureSaveAllDB_GetMapInfoPointModelListWithTVItemIDAndMapPurposeAndMapInfoDrawTypeDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual("", infrastructureModel.Error);

                    fc = FillInfrastructureSaveAllDBFormCollection(infrastructureModel);

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

                        infrastructureModel = infrastructureService.InfrastructureSaveAllDB(fc);
                        Assert.AreEqual(ErrorText, infrastructureModel.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostAddUpdateDeleteInfrastructureDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    InfrastructureModel infrastructureModelRet2 = UpdateInfrastructureModel(infrastructureModelRet);
                    Assert.AreEqual("", infrastructureModelRet2.Error);

                    infrastructureModelRet.Comment = null;
                    InfrastructureModel infrastructureModelRet4 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModelRet);
                    Assert.AreEqual("", infrastructureModelRet4.Error);

                    InfrastructureModel infrastructureModelRet3 = infrastructureService.PostDeleteInfrastructureDB(infrastructureModelRet2.InfrastructureID);
                    Assert.AreEqual("", infrastructureModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostAddInfrastructureDB_InfrastructureModelOK_Error_Test()
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
                        shimInfrastructureService.InfrastructureModelOKInfrastructureModel = (a) =>
                        {
                            return ErrorText;
                        };

                        InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                        Assert.AreEqual(ErrorText, infrastructureModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostAddInfrastructureDB_IsContactOK_Error_Test()
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
                        shimInfrastructureService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                        Assert.AreEqual(ErrorText, infrastructureModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostAddInfrastructureDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostAddInfrastructureDB(infrastructureModelRet);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);

                        infrastructureModelRet2 = infrastructureService.PostAddInfrastructureDB(infrastructureModelRet);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostAddInfrastructureDB_FillInfrastructure_Error_Test()
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
                        shimInfrastructureService.FillInfrastructureInfrastructureInfrastructureModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                        Assert.AreEqual(ErrorText, infrastructureModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostAddInfrastructureDB_DoAddChanges_Error_Test()
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
                        shimInfrastructureService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                        Assert.AreEqual(ErrorText, infrastructureModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostAddInfrastructureDB_PostAddInfrastructureLanguageDB_Error_Test()
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
                        shimInfrastructureLanguageService.PostAddInfrastructureLanguageDBInfrastructureLanguageModel = (a) =>
                        {
                            return new InfrastructureLanguageModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                        Assert.AreEqual(ErrorText, infrastructureModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostAddInfrastructureDB_Comment_And_InputDataComment_NULL_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    infrastructureModelRet.Comment = null;
                    InfrastructureModel infrastructureModelRet2 = infrastructureService.PostAddInfrastructureDB(infrastructureModelRet);
                    Assert.AreEqual("", infrastructureModelRet2.Error);
                    Assert.AreEqual(ServiceRes.Empty, infrastructureModelRet2.Comment);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostAddInfrastructureDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, infrastructureModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostAddInfrastructureDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[2], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();

                    // Assert 1
                    Assert.AreEqual(ServiceRes.EmailRequiresValidation, infrastructureModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostDeleteInfrastructureDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimInfrastructureService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostDeleteInfrastructureDB(infrastructureModelRet.InfrastructureID);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostDeleteInfrastructureDB_GetInfrastructureWithInfrastructureIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimInfrastructureService.GetInfrastructureWithInfrastructureIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostDeleteInfrastructureDB(infrastructureModelRet.InfrastructureID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Infrastructure), infrastructureModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostDeleteInfrastructureDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimInfrastructureService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostDeleteInfrastructureDB(infrastructureModelRet.InfrastructureID);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostDeleteInfrastructureDB_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostDeleteInfrastructureDB(infrastructureModelRet.InfrastructureID);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostDeleteInfrastructureWithInfrastructureTVItemIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    InfrastructureModel infrastructureModelRet2 = infrastructureService.PostDeleteInfrastructureWithInfrastructureTVItemIDDB(infrastructureModelRet.InfrastructureTVItemID);
                    Assert.AreEqual("", infrastructureModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostDeleteInfrastructureWithInfrastructureTVItemIDDB_HasChildItems_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FormCollection fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "New LS infrastructure";
                    fc["InfrastructureTVItemID"] = "0";
                    fc["InfrastructureType"] = ((int)InfrastructureTypeEnum.LiftStation).ToString();

                    InfrastructureModel infrastructureModel = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual("", infrastructureModel.Error);

                    fc = FillInfrastructureAddOrModifyDBFormCollection();
                    fc["InfrastructureTVText"] = "New LS infrastructure 2";
                    fc["InfrastructureTVItemID"] = "0";
                    fc["InfrastructureType"] = ((int)InfrastructureTypeEnum.WWTP).ToString();

                    InfrastructureModel infrastructureModel2 = infrastructureService.InfrastructureAddOrModifyDB(fc);
                    Assert.AreEqual("", infrastructureModel2.Error);

                    string retStr = infrastructureService.SetInfrastructureChildParentDB(infrastructureModel.InfrastructureTVItemID, infrastructureModel2.InfrastructureTVItemID);
                    Assert.AreEqual("", retStr);

                    InfrastructureModel infrastructureModelRet2 = infrastructureService.PostDeleteInfrastructureWithInfrastructureTVItemIDDB(infrastructureModel2.InfrastructureTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes._HasChildItems, ServiceRes.Infrastructure), infrastructureModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostDeleteInfrastructureWithInfrastructureTVItemIDDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimInfrastructureService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostDeleteInfrastructureWithInfrastructureTVItemIDDB(infrastructureModelRet.InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostDeleteInfrastructureWithInfrastructureTVItemIDDB_GetInfrastructureModelWithInfrastructureTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimInfrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDBInt32 = (a) =>
                        {
                            return new InfrastructureModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostDeleteInfrastructureWithInfrastructureTVItemIDDB(infrastructureModelRet.InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostDeleteInfrastructureWithInfrastructureTVItemIDDB_PostDeleteInfrastructureDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimInfrastructureService.PostDeleteInfrastructureDBInt32 = (a) =>
                        {
                            return new InfrastructureModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostDeleteInfrastructureWithInfrastructureTVItemIDDB(infrastructureModelRet.InfrastructureTVItemID);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostUpdateInfrastructureDB_InfrastructureModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimInfrastructureService.InfrastructureModelOKInfrastructureModel = (a) =>
                        {
                            return ErrorText;
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModelRet);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostUpdateInfrastructureDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimInfrastructureService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModelRet);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostUpdateInfrastructureDB_GetInfrastructureWithInfrastructureIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimInfrastructureService.GetInfrastructureWithInfrastructureIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Infrastructure), infrastructureModelRet2.Error);

                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostUpdateInfrastructureDB_FillInfrastructure_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimInfrastructureService.FillInfrastructureInfrastructureInfrastructureModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModelRet);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostUpdateInfrastructureDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimInfrastructureService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModelRet);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostUpdateInfrastructureDB_GetTVItemLanguageModelWithTVItemIDAndLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDBInt32LanguageEnum = (a, b) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModelRet);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostUpdateInfrastructureDB_CreateTVText_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimInfrastructureService.CreateTVTextInfrastructureModel = (a) =>
                        {
                            return "";
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModelRet);
                        Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVText), infrastructureModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostUpdateInfrastructureDB_PostUpdateTVItemLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemLanguageService.PostUpdateTVItemLanguageDBTVItemLanguageModel = (a) =>
                        {
                            return new TVItemLanguageModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModelRet);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_PostUpdateInfrastructureDB_PostUpdateInfrastructureLanguageDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    InfrastructureModel infrastructureModelRet = AddInfrastructureModel();
                    Assert.AreEqual("", infrastructureModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimInfrastructureLanguageService.PostUpdateInfrastructureLanguageDBInfrastructureLanguageModel = (a) =>
                        {
                            return new InfrastructureLanguageModel() { Error = ErrorText };
                        };

                        InfrastructureModel infrastructureModelRet2 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModelRet);
                        Assert.AreEqual(ErrorText, infrastructureModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_SetInfrastructureChildParentDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelBouctouche = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(tvItemModelRoot.TVItemID, "Bouctouche", TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelBouctouche.Error);

                    List<TVItemModel> tvItemModelInfList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelBouctouche.TVItemID, TVTypeEnum.Infrastructure);
                    Assert.IsTrue(tvItemModelInfList.Count > 0);

                    TVItemModel tvItemModelWWTP = tvItemModelInfList.Where(c => c.TVText.Contains("WWTP") || c.TVText.Contains("UTEU")).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelWWTP);

                    TVItemModel tvItemModelLS = tvItemModelInfList.Where(c => c.TVText.Contains("LS")).FirstOrDefault();
                    Assert.IsNotNull(tvItemModelLS);

                    string retStr = infrastructureService.SetInfrastructureChildParentDB(tvItemModelLS.TVItemID, tvItemModelWWTP.TVItemID);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_SetInfrastructureChildParentDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    string TVText = randomService.RandomString("new WWTP ", 20);
                    TVItemModel tvItemModelWWTP = tvItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelWWTP.Error);

                    TVText = randomService.RandomString("new LS ", 20);
                    TVItemModel tvItemModelLS = tvItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelLS.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimInfrastructureService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        string retStr = infrastructureService.SetInfrastructureChildParentDB(tvItemModelLS.TVItemID, tvItemModelWWTP.TVItemID);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_SetInfrastructureChildParentDB_FromTVItemID_Equal_0_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    string TVText = randomService.RandomString("new WWTP ", 20);
                    TVItemModel tvItemModelWWTP = tvItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelWWTP.Error);

                    TVText = randomService.RandomString("new LS ", 20);
                    TVItemModel tvItemModelLS = tvItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelLS.Error);

                    int FromTVItemID = 0;
                    string retStr = infrastructureService.SetInfrastructureChildParentDB(FromTVItemID, tvItemModelWWTP.TVItemID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FromTVItemID), retStr);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_SetInfrastructureChildParentDB_ToTVItemID_Equal_0_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    string TVText = randomService.RandomString("new WWTP ", 20);
                    TVItemModel tvItemModelWWTP = tvItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelWWTP.Error);

                    TVText = randomService.RandomString("new LS ", 20);
                    TVItemModel tvItemModelLS = tvItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelLS.Error);

                    int ToTVItemID = 0;
                    string retStr = infrastructureService.SetInfrastructureChildParentDB(tvItemModelLS.TVItemID, ToTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ToTVItemID), retStr);
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_SetInfrastructureChildParentDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    string TVText = randomService.RandomString("new WWTP ", 20);
                    TVItemModel tvItemModelWWTP = tvItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelWWTP.Error);

                    TVText = randomService.RandomString("new LS ", 20);
                    TVItemModel tvItemModelLS = tvItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelLS.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        string retStr = infrastructureService.SetInfrastructureChildParentDB(tvItemModelLS.TVItemID, tvItemModelWWTP.TVItemID);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                }
            }
        }
        [TestMethod]
        public void InfrastructureService_SetInfrastructureChildParentDB_PostAddTVItemLinkDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    string TVText = randomService.RandomString("new WWTP ", 20);
                    TVItemModel tvItemModelWWTP = tvItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelWWTP.Error);

                    TVText = randomService.RandomString("new LS ", 20);
                    TVItemModel tvItemModelLS = tvItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelLS.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemLinkService.PostAddTVItemLinkDBTVItemLinkModel = (a) =>
                        {
                            return new TVItemLinkModel() { Error = ErrorText };
                        };

                        string retStr = infrastructureService.SetInfrastructureChildParentDB(tvItemModelLS.TVItemID, tvItemModelWWTP.TVItemID);
                        Assert.AreEqual(ErrorText, retStr);
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions
        public InfrastructureModel AddInfrastructureModel()
        {
            TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
            if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
            {
                return new InfrastructureModel();
            }

            string TVText = randomService.RandomString("Infrastructure ", 20);
            TVItemModel tvItemModelInfrastructure = infrastructureService._TVItemService.PostAddChildTVItemDB(tvItemModelMunicipality.TVItemID, TVText, TVTypeEnum.Infrastructure);
            if (!string.IsNullOrWhiteSpace(tvItemModelInfrastructure.Error))
            {
                return new InfrastructureModel() { Error = tvItemModelInfrastructure.Error };
            }

            List<Coord> coordList = new List<Coord>() { new Coord() { Lat = 45.0f, Lng = -66.0f, Ordinal = 1 } };

            MapInfoModel mapInfoModel = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Infrastructure, tvItemModelInfrastructure.TVItemID);
            if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
            {
                return new InfrastructureModel() { Error = mapInfoModel.Error };
            }

            infrastructureModelNew.InfrastructureTVItemID = tvItemModelInfrastructure.TVItemID;
            infrastructureModelNew.InfrastructureTVText = TVText;
            FillInfrastructureModel(infrastructureModelNew);

            InfrastructureModel infrastructureModelRet = infrastructureService.PostAddInfrastructureDB(infrastructureModelNew);
            if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
            {
                return infrastructureModelRet;
            }

            CompareInfrastructureModels(infrastructureModelNew, infrastructureModelRet);

            return infrastructureModelRet;

        }
        public InfrastructureModel UpdateInfrastructureModel(InfrastructureModel infrastructureModel)
        {
            FillInfrastructureModel(infrastructureModel);

            InfrastructureModel infrastructureModelRet2 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
            if (!string.IsNullOrWhiteSpace(infrastructureModelRet2.Error))
            {
                return infrastructureModelRet2;
            }

            CompareInfrastructureModels(infrastructureModel, infrastructureModelRet2);

            return infrastructureModelRet2;
        }
        private void CompareInfrastructureModels(InfrastructureModel infrastructureModelNew, InfrastructureModel infrastructureModelRet)
        {
            Assert.AreEqual(infrastructureModelNew.InfrastructureTVItemID, infrastructureModelRet.InfrastructureTVItemID);
            Assert.AreEqual(infrastructureModelNew.InfrastructureTVText, infrastructureModelRet.InfrastructureTVText);
            Assert.AreEqual(infrastructureModelNew.PrismID, infrastructureModelRet.PrismID);
            Assert.AreEqual(infrastructureModelNew.TPID, infrastructureModelRet.TPID);
            Assert.AreEqual(infrastructureModelNew.LSID, infrastructureModelRet.LSID);
            Assert.AreEqual(infrastructureModelNew.SiteID, infrastructureModelRet.SiteID);
            Assert.AreEqual(infrastructureModelNew.Site, infrastructureModelRet.Site);
            Assert.AreEqual(infrastructureModelNew.InfrastructureCategory, infrastructureModelRet.InfrastructureCategory);
            Assert.AreEqual(infrastructureModelNew.InfrastructureType, infrastructureModelRet.InfrastructureType);
            Assert.AreEqual(infrastructureModelNew.FacilityType, infrastructureModelRet.FacilityType);
            Assert.AreEqual(infrastructureModelNew.IsMechanicallyAerated, infrastructureModelRet.IsMechanicallyAerated);
            Assert.AreEqual(infrastructureModelNew.NumberOfCells, infrastructureModelRet.NumberOfCells);
            Assert.AreEqual(infrastructureModelNew.NumberOfAeratedCells, infrastructureModelRet.NumberOfAeratedCells);
            Assert.AreEqual(infrastructureModelNew.AerationType, infrastructureModelRet.AerationType);
            Assert.AreEqual(infrastructureModelNew.PreliminaryTreatmentType, infrastructureModelRet.PreliminaryTreatmentType);
            Assert.AreEqual(infrastructureModelNew.PrimaryTreatmentType, infrastructureModelRet.PrimaryTreatmentType);
            Assert.AreEqual(infrastructureModelNew.SecondaryTreatmentType, infrastructureModelRet.SecondaryTreatmentType);
            Assert.AreEqual(infrastructureModelNew.TertiaryTreatmentType, infrastructureModelRet.TertiaryTreatmentType);
            Assert.AreEqual(infrastructureModelNew.TreatmentType, infrastructureModelRet.TreatmentType);
            Assert.AreEqual(infrastructureModelNew.DisinfectionType, infrastructureModelRet.DisinfectionType);
            Assert.AreEqual(infrastructureModelNew.CollectionSystemType, infrastructureModelRet.CollectionSystemType);
            Assert.AreEqual(infrastructureModelNew.AlarmSystemType, infrastructureModelRet.AlarmSystemType);
            Assert.AreEqual(infrastructureModelNew.DesignFlow_m3_day, infrastructureModelRet.DesignFlow_m3_day);
            Assert.AreEqual(infrastructureModelNew.AverageFlow_m3_day, infrastructureModelRet.AverageFlow_m3_day);
            Assert.AreEqual(infrastructureModelNew.PeakFlow_m3_day, infrastructureModelRet.PeakFlow_m3_day);
            Assert.AreEqual(infrastructureModelNew.PopServed, infrastructureModelRet.PopServed);
            Assert.AreEqual(infrastructureModelNew.CanOverflow, infrastructureModelRet.CanOverflow);
            Assert.AreEqual(infrastructureModelNew.PercFlowOfTotal, infrastructureModelRet.PercFlowOfTotal);
            Assert.AreEqual(infrastructureModelNew.TimeOffset_hour, infrastructureModelRet.TimeOffset_hour);
            Assert.AreEqual(infrastructureModelNew.TempCatchAllRemoveLater, infrastructureModelRet.TempCatchAllRemoveLater);
            Assert.AreEqual(infrastructureModelNew.AverageDepth_m, infrastructureModelRet.AverageDepth_m);
            Assert.AreEqual(infrastructureModelNew.NumberOfPorts, infrastructureModelRet.NumberOfPorts);
            Assert.AreEqual(infrastructureModelNew.PortDiameter_m, infrastructureModelRet.PortDiameter_m);
            Assert.AreEqual(infrastructureModelNew.PortSpacing_m, infrastructureModelRet.PortSpacing_m);
            Assert.AreEqual(infrastructureModelNew.PortElevation_m, infrastructureModelRet.PortElevation_m);
            Assert.AreEqual(infrastructureModelNew.VerticalAngle_deg, infrastructureModelRet.VerticalAngle_deg);
            Assert.AreEqual(infrastructureModelNew.HorizontalAngle_deg, infrastructureModelRet.HorizontalAngle_deg);
            Assert.AreEqual(infrastructureModelNew.DecayRate_per_day, infrastructureModelRet.DecayRate_per_day);
            Assert.AreEqual(infrastructureModelNew.NearFieldVelocity_m_s, infrastructureModelRet.NearFieldVelocity_m_s);
            Assert.AreEqual(infrastructureModelNew.FarFieldVelocity_m_s, infrastructureModelRet.FarFieldVelocity_m_s);
            Assert.AreEqual(infrastructureModelNew.ReceivingWaterSalinity_PSU, infrastructureModelRet.ReceivingWaterSalinity_PSU);
            Assert.AreEqual(infrastructureModelNew.ReceivingWaterTemperature_C, infrastructureModelRet.ReceivingWaterTemperature_C);
            Assert.AreEqual(infrastructureModelNew.ReceivingWater_MPN_per_100ml, infrastructureModelRet.ReceivingWater_MPN_per_100ml);
            Assert.AreEqual(infrastructureModelNew.DistanceFromShore_m, infrastructureModelRet.DistanceFromShore_m);
            Assert.AreEqual(infrastructureModelNew.Comment, infrastructureModelRet.Comment);
            Assert.AreEqual(infrastructureModelNew.SeeOtherTVItemID, infrastructureModelRet.SeeOtherTVItemID);
            Assert.AreEqual(infrastructureModelNew.CivicAddressTVItemID, infrastructureModelRet.CivicAddressTVItemID);

            foreach (LanguageEnum Lang in infrastructureService.LanguageListAllowable)
            {
                InfrastructureLanguageModel infrastructureLanguageModel = infrastructureService._InfrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureModelRet.InfrastructureID, Lang);
                Assert.AreEqual("", infrastructureLanguageModel.Error);

                if (Lang == infrastructureService.LanguageRequest)
                {
                    Assert.AreEqual(infrastructureModelRet.Comment, infrastructureLanguageModel.Comment);
                }
            }

            foreach (LanguageEnum Lang in infrastructureService.LanguageListAllowable)
            {
                TVItemLanguageModel tvItemLanguageModel = infrastructureService._TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(infrastructureModelRet.InfrastructureTVItemID, Lang);
                Assert.AreEqual("", tvItemLanguageModel.Error);

                if (Lang == infrastructureService.LanguageRequest)
                {
                    Assert.AreEqual(infrastructureModelRet.InfrastructureTVText, tvItemLanguageModel.TVText);
                }
            }

        }
        private void FillInfrastructureModel(InfrastructureModel infrastructureModel)
        {
            infrastructureModel.InfrastructureTVItemID = infrastructureModel.InfrastructureTVItemID;
            infrastructureModel.InfrastructureTVText = infrastructureModel.InfrastructureTVText;
            infrastructureModel.PrismID = randomService.RandomInt(1, 100);
            infrastructureModel.TPID = randomService.RandomInt(1, 100);
            infrastructureModel.LSID = randomService.RandomInt(1, 100);
            infrastructureModel.SiteID = randomService.RandomInt(1, 100);
            infrastructureModel.Site = randomService.RandomInt(1, 100);
            infrastructureModel.InfrastructureCategory = "A";
            infrastructureModel.InfrastructureType = InfrastructureTypeEnum.LiftStation;
            infrastructureModel.FacilityType = FacilityTypeEnum.Lagoon;
            infrastructureModel.IsMechanicallyAerated = true;
            infrastructureModel.NumberOfCells = randomService.RandomInt(1, 4);
            infrastructureModel.NumberOfAeratedCells = randomService.RandomInt(1, 4);
            infrastructureModel.AerationType = AerationTypeEnum.Diffuser;
            infrastructureModel.PreliminaryTreatmentType = PreliminaryTreatmentTypeEnum.BarScreen;
            infrastructureModel.PrimaryTreatmentType = PrimaryTreatmentTypeEnum.ChemicalCoagulation;
            infrastructureModel.SecondaryTreatmentType = SecondaryTreatmentTypeEnum.OxidationDitch;
            infrastructureModel.TertiaryTreatmentType = TertiaryTreatmentTypeEnum.BiologicalNutrientRemoval;
            infrastructureModel.TreatmentType = TreatmentTypeEnum.ActivatedSludgeWithBiofilter;
            infrastructureModel.DisinfectionType = DisinfectionTypeEnum.ChlorinationWithDechlorination;
            infrastructureModel.CollectionSystemType = CollectionSystemTypeEnum.Combined50Separated50;
            infrastructureModel.AlarmSystemType = AlarmSystemTypeEnum.SCADA;
            infrastructureModel.DesignFlow_m3_day = randomService.RandomDouble(1, 100000);
            infrastructureModel.AverageFlow_m3_day = randomService.RandomDouble(1, 100000);
            infrastructureModel.PeakFlow_m3_day = randomService.RandomDouble(1, 100000);
            infrastructureModel.PopServed = randomService.RandomInt(50, 100000);
            infrastructureModel.CanOverflow = true;
            infrastructureModel.PercFlowOfTotal = randomService.RandomDouble(0, 100);
            infrastructureModel.TimeOffset_hour = randomService.RandomDouble(-8, -4);
            infrastructureModel.TempCatchAllRemoveLater = randomService.RandomString("TempCatchAllRemoveLater", 200);
            infrastructureModel.AverageDepth_m = randomService.RandomDouble(0.1, 1000);
            infrastructureModel.NumberOfPorts = randomService.RandomInt(1, 100);
            infrastructureModel.PortDiameter_m = randomService.RandomDouble(0.1, 10);
            infrastructureModel.PortSpacing_m = randomService.RandomDouble(0.1, 10000);
            infrastructureModel.PortElevation_m = randomService.RandomDouble(0.1, 10000);
            infrastructureModel.VerticalAngle_deg = randomService.RandomDouble(-90, 90);
            infrastructureModel.HorizontalAngle_deg = randomService.RandomDouble(-180, 180);
            infrastructureModel.DecayRate_per_day = randomService.RandomDouble(0, 1000);
            infrastructureModel.NearFieldVelocity_m_s = randomService.RandomDouble(0, 10);
            infrastructureModel.FarFieldVelocity_m_s = randomService.RandomDouble(0, 10);
            infrastructureModel.ReceivingWaterSalinity_PSU = randomService.RandomDouble(0, 35);
            infrastructureModel.ReceivingWaterTemperature_C = randomService.RandomDouble(0, 35);
            infrastructureModel.ReceivingWater_MPN_per_100ml = randomService.RandomInt(0, 1000000);
            infrastructureModel.DistanceFromShore_m = randomService.RandomDouble(0, 10000);
            infrastructureModel.Comment = randomService.RandomString("Comment", 100);
            infrastructureModel.SeeOtherTVItemID = randomService.RandomTVItem(TVTypeEnum.Infrastructure).TVItemID;
            infrastructureModel.CivicAddressTVItemID = randomService.RandomTVItem(TVTypeEnum.Address).TVItemID;

            Assert.IsTrue(infrastructureModel.InfrastructureTVItemID > 0);
            Assert.IsTrue(infrastructureModel.InfrastructureTVText.Length > 0);
            Assert.IsTrue(infrastructureModel.PrismID >= 1 && infrastructureModel.PrismID <= 100);
            Assert.IsTrue(infrastructureModel.TPID >= 1 && infrastructureModel.TPID <= 100);
            Assert.IsTrue(infrastructureModel.LSID >= 1 && infrastructureModel.LSID <= 100);
            Assert.IsTrue(infrastructureModel.SiteID >= 1 && infrastructureModel.SiteID <= 100);
            Assert.IsTrue(infrastructureModel.Site >= 1 && infrastructureModel.Site <= 100);
            Assert.IsTrue(infrastructureModel.InfrastructureCategory == "A");
            Assert.IsTrue(infrastructureModel.InfrastructureType == InfrastructureTypeEnum.LiftStation);
            Assert.IsTrue(infrastructureModel.FacilityType == FacilityTypeEnum.Lagoon);
            Assert.IsTrue(infrastructureModel.IsMechanicallyAerated == true);
            Assert.IsTrue(infrastructureModel.NumberOfCells >= 1 && infrastructureModel.NumberOfCells <= 4);
            Assert.IsTrue(infrastructureModel.NumberOfAeratedCells >= 1 && infrastructureModel.NumberOfAeratedCells <= 4);
            Assert.IsTrue(infrastructureModel.AerationType == AerationTypeEnum.Diffuser);
            Assert.IsTrue(infrastructureModel.PreliminaryTreatmentType == PreliminaryTreatmentTypeEnum.BarScreen);
            Assert.IsTrue(infrastructureModel.PrimaryTreatmentType == PrimaryTreatmentTypeEnum.ChemicalCoagulation);
            Assert.IsTrue(infrastructureModel.SecondaryTreatmentType == SecondaryTreatmentTypeEnum.OxidationDitch);
            Assert.IsTrue(infrastructureModel.TertiaryTreatmentType == TertiaryTreatmentTypeEnum.BiologicalNutrientRemoval);
            Assert.IsTrue(infrastructureModel.TreatmentType == TreatmentTypeEnum.ActivatedSludgeWithBiofilter);
            Assert.IsTrue(infrastructureModel.DisinfectionType == DisinfectionTypeEnum.ChlorinationWithDechlorination);
            Assert.IsTrue(infrastructureModel.CollectionSystemType == CollectionSystemTypeEnum.Combined50Separated50);
            Assert.IsTrue(infrastructureModel.AlarmSystemType == AlarmSystemTypeEnum.SCADA);
            Assert.IsTrue(infrastructureModel.DesignFlow_m3_day >= 1 && infrastructureModel.DesignFlow_m3_day <= 100000);
            Assert.IsTrue(infrastructureModel.AverageFlow_m3_day >= 1 && infrastructureModel.AverageFlow_m3_day <= 100000);
            Assert.IsTrue(infrastructureModel.PeakFlow_m3_day >= 1 && infrastructureModel.PeakFlow_m3_day <= 100000);
            Assert.IsTrue(infrastructureModel.PopServed >= 50 && infrastructureModel.PopServed <= 100000);
            Assert.IsTrue(infrastructureModel.CanOverflow == true);
            Assert.IsTrue(infrastructureModel.PercFlowOfTotal >= 0 && infrastructureModel.PercFlowOfTotal <= 100);
            Assert.IsTrue(infrastructureModel.TimeOffset_hour >= -8 && infrastructureModel.TimeOffset_hour <= -4);
            Assert.IsTrue(infrastructureModel.TempCatchAllRemoveLater.Length == 200);
            Assert.IsTrue(infrastructureModel.AverageDepth_m >= 0.1 && infrastructureModel.AverageDepth_m <= 1000);
            Assert.IsTrue(infrastructureModel.NumberOfPorts >= 1 && infrastructureModel.NumberOfPorts <= 100);
            Assert.IsTrue(infrastructureModel.PortDiameter_m >= 0.1 && infrastructureModel.PortDiameter_m <= 10);
            Assert.IsTrue(infrastructureModel.PortSpacing_m >= 0.1 && infrastructureModel.PortSpacing_m <= 10000);
            Assert.IsTrue(infrastructureModel.PortElevation_m >= 0.1 && infrastructureModel.PortElevation_m <= 10000);
            Assert.IsTrue(infrastructureModel.VerticalAngle_deg >= -90 && infrastructureModel.VerticalAngle_deg <= 90);
            Assert.IsTrue(infrastructureModel.HorizontalAngle_deg >= -180 && infrastructureModel.HorizontalAngle_deg <= 180);
            Assert.IsTrue(infrastructureModel.DecayRate_per_day >= 0 && infrastructureModel.DecayRate_per_day <= 1000);
            Assert.IsTrue(infrastructureModel.NearFieldVelocity_m_s >= 0 && infrastructureModel.NearFieldVelocity_m_s <= 10);
            Assert.IsTrue(infrastructureModel.FarFieldVelocity_m_s >= 0 && infrastructureModel.FarFieldVelocity_m_s <= 10);
            Assert.IsTrue(infrastructureModel.ReceivingWaterSalinity_PSU >= 0 && infrastructureModel.ReceivingWaterSalinity_PSU <= 35);
            Assert.IsTrue(infrastructureModel.ReceivingWaterTemperature_C >= 0 && infrastructureModel.ReceivingWaterTemperature_C <= 35);
            Assert.IsTrue(infrastructureModel.ReceivingWater_MPN_per_100ml >= 0 && infrastructureModel.ReceivingWater_MPN_per_100ml <= 1000000);
            Assert.IsTrue(infrastructureModel.DistanceFromShore_m >= 0 && infrastructureModel.DistanceFromShore_m <= 10000);
            Assert.IsTrue(infrastructureModel.Comment.Length == 100);
            Assert.IsTrue(infrastructureModel.SeeOtherTVItemID > 0);
            Assert.IsTrue(infrastructureModel.CivicAddressTVItemID > 0);
        }
        private FormCollection FillInfrastructureAddOrModifyDBFormCollection()
        {
            FormCollection fc = new FormCollection();
            TVItemModel tvItemModelMuni = infrastructureService._TVItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(1, "Bouctouche", TVTypeEnum.Municipality);
            if (!string.IsNullOrWhiteSpace(tvItemModelMuni.Error))
                return null;

            List<TVItemModel> tvItemModelInfrastructureList = infrastructureService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMuni.TVItemID, TVTypeEnum.Infrastructure); ;
            if (tvItemModelInfrastructureList.Count == 0)
                return null;

            fc.Add("InfrastructureTVText", "Unique " + tvItemModelInfrastructureList[1].TVText);
            fc.Add("TVItemIDMunicipality", tvItemModelMuni.TVItemID.ToString());
            fc.Add("InfrastructureTVItemID", tvItemModelInfrastructureList[2].TVItemID.ToString());
            fc.Add("InfrastructureType", ((int)InfrastructureTypeEnum.LiftStation).ToString());
            fc.Add("Lat", randomService.RandomDouble(45.0, 46.0).ToString());
            fc.Add("Lng", randomService.RandomDouble(-66.0, -65.0).ToString());
            fc.Add("LatOutfall", randomService.RandomDouble(45.0, 46.0).ToString());
            fc.Add("LngOutfall", randomService.RandomDouble(-66.0, -65.0).ToString());
            fc.Add("SeeOtherTVItemID", "0");

            return fc;
        }
        private FormCollection FillInfrastructureSaveAllDBFormCollection(InfrastructureModel infrastructureModel)
        {
            FormCollection fc = new FormCollection();
            fc.Add("InfrastructureTVText", randomService.RandomString("", 20));
            fc.Add("InfrastructureTVItemID", infrastructureModel.InfrastructureTVItemID.ToString());
            fc.Add("PrismID", randomService.RandomInt(200, 300).ToString());
            fc.Add("TPID", randomService.RandomInt(200, 300).ToString());
            fc.Add("LSID", randomService.RandomInt(200, 300).ToString());
            fc.Add("SiteID", randomService.RandomInt(200, 300).ToString());
            fc.Add("Site", randomService.RandomInt(200, 300).ToString());
            fc.Add("InfrastructureCategory", "P");
            fc.Add("InfrastructureType", ((int)InfrastructureTypeEnum.LiftStation).ToString());
            fc.Add("FacilityType", ((int)FacilityTypeEnum.Lagoon).ToString());
            fc.Add("IsMechanicallyAerated", true.ToString());
            fc.Add("NumberOfCells", randomService.RandomInt(1, 3).ToString());
            fc.Add("NumberOfAeratedCells", randomService.RandomInt(2, 3).ToString());
            fc.Add("AerationType", ((int)AerationTypeEnum.Diffuser).ToString());
            fc.Add("PreliminaryTreatmentType", ((int)PreliminaryTreatmentTypeEnum.BarScreen).ToString());
            fc.Add("PrimaryTreatmentType", ((int)PrimaryTreatmentTypeEnum.ChemicalCoagulation).ToString());
            fc.Add("SecondaryTreatmentType", ((int)SecondaryTreatmentTypeEnum.RotatingBiologicalContactor).ToString());
            fc.Add("TertiaryTreatmentType", ((int)TertiaryTreatmentTypeEnum.BiologicalNutrientRemoval).ToString());
            fc.Add("TreatmentType", ((int)TreatmentTypeEnum.BioFilmReactor).ToString());
            fc.Add("DisinfectionType", ((int)DisinfectionTypeEnum.UV).ToString());
            fc.Add("CollectionSystemType", ((int)CollectionSystemTypeEnum.Combined50Separated50).ToString());
            fc.Add("AlarmSystemType", ((int)AlarmSystemTypeEnum.SCADA).ToString());
            fc.Add("DesignFlow_m3_day", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("AverageFlow_m3_day", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("PeakFlow_m3_day", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("PopServed", randomService.RandomInt(10, 20).ToString());
            fc.Add("CanOverflow", "true");
            fc.Add("PercFlowOfTotal", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("TimeOffset_hour", randomService.RandomInt(-8, -4).ToString());
            fc.Add("TempCatchAllRemoveLater", randomService.RandomString("", 100));
            fc.Add("AverageDepth_m", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("NumberOfPorts", randomService.RandomInt(1, 2).ToString());
            fc.Add("PortDiameter_m", randomService.RandomDouble(0.25, 0.75).ToString());
            fc.Add("PortSpacing_m", randomService.RandomDouble(100.0, 1000.0).ToString());
            fc.Add("PortElevation_m", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("VerticalAngle_deg", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("HorizontalAngle_deg", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("DecayRate_per_day", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("NearFieldVelocity_m_s", randomService.RandomDouble(0.01, 10.0).ToString());
            fc.Add("FarFieldVelocity_m_s", randomService.RandomDouble(0.01, 10.0).ToString());
            fc.Add("ReceivingWaterSalinity_PSU", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("ReceivingWaterTemperature_C", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("ReceivingWater_MPN_per_100ml", randomService.RandomInt(2, 200000).ToString());
            fc.Add("DistanceFromShore_m", randomService.RandomDouble(2.0, 20.0).ToString());
            fc.Add("Comments", randomService.RandomString("", 100));
            fc.Add("InputDataComments", randomService.RandomString("", 100));
            fc.Add("SeeOtherTVItemID", "0");
            fc.Add("CivicAddressTVItemID", "0");
            fc.Add("Lat", randomService.RandomDouble(45.0, 46.0).ToString());
            fc.Add("Lng", randomService.RandomDouble(-66.0, -65.0).ToString());
            fc.Add("LatOutfall", randomService.RandomDouble(45.0, 46.0).ToString());
            fc.Add("LngOutfall", randomService.RandomDouble(-66.0, -65.0).ToString());

            return fc;
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            infrastructureService = new InfrastructureService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            infrastructureModelNew = new InfrastructureModel();
            infrastructure = new Infrastructure();
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mapInfoService = new MapInfoService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
        }
        private void SetupShim()
        {
            shimInfrastructureService = new ShimInfrastructureService(infrastructureService);
            shimTVItemService = new ShimTVItemService(infrastructureService._TVItemService);
            shimTVItemLanguageService = new ShimTVItemLanguageService(infrastructureService._TVItemService._TVItemLanguageService);
            shimInfrastructureLanguageService = new ShimInfrastructureLanguageService(infrastructureService._InfrastructureLanguageService);
            shimMapInfoService = new ShimMapInfoService(infrastructureService._MapInfoService);
            shimMapInfoPointService = new ShimMapInfoPointService(infrastructureService._MapInfoService._MapInfoPointService);
            shimTVItemLinkService = new ShimTVItemLinkService(infrastructureService._TVItemLinkService);
        }
        #endregion Functions
    }
}


