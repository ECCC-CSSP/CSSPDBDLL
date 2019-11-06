using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Transactions;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using System.Xml;
using System.IO;
using System.Web.Mvc;

namespace CSSPDBDLL.Services
{
    public class MapInfoService : BaseService
    {
        #region Properties
        public MapInfoPointService _MapInfoPointService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public UseOfSiteService _UseOfSiteService { get; private set; }
        public MWQMSampleService _MWQMSampleService { get; private set; }
        public LogService _LogService { get; private set; }
        public PolSourceSiteEffectService _PolSourceSiteEffectService { get; private set; }
        #endregion Properties

        #region Constructors
        public MapInfoService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _MapInfoPointService = new MapInfoPointService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _UseOfSiteService = new UseOfSiteService(LanguageRequest, User);
            _MWQMSampleService = new MWQMSampleService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
            _PolSourceSiteEffectService = new PolSourceSiteEffectService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions public
        public override ContactOK IsContactOK()
        {
            return base.IsContactOK();
        }
        public override string DoAddChanges()
        {
            return base.DoAddChanges();
        }
        public override string DoDeleteChanges()
        {
            return base.DoDeleteChanges();
        }
        public override string DoUpdateChanges()
        {
            return base.DoUpdateChanges();
        }
        public InfrastructureModel InfrastructureTVItemLinkPolylineUpdateDB(InfrastructureModel infrastructureModelRet, TVTypeEnum tvType, float Lat, float Lng)
        {
            InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, User);
            return infrastructureService.InfrastructureTVItemLinkPolylineUpdateDB(infrastructureModelRet, tvType, Lat, Lng);
        }
        public InfrastructureModel InfrastructureCoordinateUpdateDB(InfrastructureModel infrastructureModelRet, TVTypeEnum tvType, float Lat, float Lng, float? LatOutfall, float? LngOutfall)
        {
            InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, User);
            return infrastructureService.InfrastructureCoordinateUpdateDB(infrastructureModelRet, tvType, Lat, Lng, LatOutfall, LngOutfall);
        }

        public InfrastructureModel GetInfrastructureModelWithInfrastructureTVItemIDDB(int InfrastructureTVItemID)
        {
            InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, User);
            return infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
        }

        // Check
        public string MapInfoModelOK(MapInfoModel mapInfoModel)
        {
            string retStr = FieldCheckNotZeroInt(mapInfoModel.TVItemID, ServiceRes.TVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TVTypeOK(mapInfoModel.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mapInfoModel.LatMin, ServiceRes.LatMin, -90.0D, 90.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mapInfoModel.LatMax, ServiceRes.LatMax, -90.0D, 90.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mapInfoModel.LngMin, ServiceRes.LngMin, -180.0D, 180.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mapInfoModel.LngMax, ServiceRes.LngMax, -180.0D, 180.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMapInfo(MapInfo mapInfo, MapInfoModel mapInfoModel, ContactOK contactOK)
        {
            mapInfo.TVItemID = mapInfoModel.TVItemID;
            mapInfo.TVType = (int)mapInfoModel.TVType;
            mapInfo.LatMin = mapInfoModel.LatMin;
            mapInfo.LatMax = mapInfoModel.LatMax;
            mapInfo.LngMin = mapInfoModel.LngMin;
            mapInfo.LngMax = mapInfoModel.LngMax;
            mapInfo.MapInfoDrawType = (int)mapInfoModel.MapInfoDrawType;
            mapInfo.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mapInfo.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mapInfo.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }
        public void FillMapInfoPoint(List<MapInfoPointModel> mapInfoPointModelList, TVLocation tvlNew, MapInfoDrawTypeEnum mapInfoDrawType)
        {
            MapObj mapObj = new MapObj();
            mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
            mapObj.MapInfoDrawType = mapInfoDrawType;

            List<Coord> coordList = new List<Coord>();

            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
            {
                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
            }

            mapObj.CoordList = coordList;
            tvlNew.MapObjList.Add(mapObj);
        }
        public void FillTVLocation(List<TVLocation> tvLocationList, TVItemModel tvItemModel, TVTypeEnum TVType)
        {
            TVLocation tvlNew = new TVLocation();
            tvlNew.TVItemID = tvItemModel.TVItemID;
            tvlNew.TVText = tvItemModel.TVText;
            tvlNew.TVType = tvItemModel.TVType;
            tvlNew.SubTVType = tvItemModel.TVType;

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVType, MapInfoDrawTypeEnum.Polygon);
            if (mapInfoPointModelList.Count > 0)
            {
                FillMapInfoPoint(mapInfoPointModelList, tvlNew, MapInfoDrawTypeEnum.Polygon);
                tvLocationList.Add(tvlNew);
            }

            tvlNew = new TVLocation();
            tvlNew.TVItemID = tvItemModel.TVItemID;
            tvlNew.TVText = tvItemModel.TVText;
            tvlNew.TVType = tvItemModel.TVType;
            tvlNew.SubTVType = tvItemModel.TVType;

            mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVType, MapInfoDrawTypeEnum.Polyline);
            if (mapInfoPointModelList.Count > 0)
            {
                FillMapInfoPoint(mapInfoPointModelList, tvlNew, MapInfoDrawTypeEnum.Polyline);
                tvLocationList.Add(tvlNew);
            }

            tvlNew = new TVLocation();
            tvlNew.TVItemID = tvItemModel.TVItemID;
            tvlNew.TVText = tvItemModel.TVText;
            tvlNew.TVType = tvItemModel.TVType;
            tvlNew.SubTVType = tvItemModel.TVType;

            mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVType, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelList.Count > 0)
            {
                FillMapInfoPoint(mapInfoPointModelList, tvlNew, MapInfoDrawTypeEnum.Point);
                tvLocationList.Add(tvlNew);
            }
        }
        public void FillTVLocationList(List<TVLocation> tvLocationList, List<TVItemModel> tvItemModelList, TVTypeEnum TVType, TVTypeEnum ShowTVType)
        {
            foreach (TVItemModel tvItemModel in tvItemModelList)
            {
                TVLocation tvlNew = new TVLocation();
                tvlNew.TVItemID = tvItemModel.TVItemID;
                tvlNew.TVText = tvItemModel.TVText;
                tvlNew.TVType = tvItemModel.TVType;
                tvlNew.SubTVType = ShowTVType;

                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVType, MapInfoDrawTypeEnum.Polygon);
                if (mapInfoPointModelList.Count > 0)
                {
                    FillMapInfoPoint(mapInfoPointModelList, tvlNew, MapInfoDrawTypeEnum.Polygon);
                    tvLocationList.Add(tvlNew);
                }

            }

            foreach (TVItemModel tvItemModel in tvItemModelList)
            {
                TVLocation tvlNew = new TVLocation();
                tvlNew.TVItemID = tvItemModel.TVItemID;
                tvlNew.TVText = tvItemModel.TVText;
                tvlNew.TVType = tvItemModel.TVType;
                tvlNew.SubTVType = ShowTVType;

                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVType, MapInfoDrawTypeEnum.Polyline);
                if (mapInfoPointModelList.Count > 0)
                {
                    FillMapInfoPoint(mapInfoPointModelList, tvlNew, MapInfoDrawTypeEnum.Polyline);
                    tvLocationList.Add(tvlNew);
                }
            }

            foreach (TVItemModel tvItemModel in tvItemModelList)
            {
                TVLocation tvlNew = new TVLocation();
                tvlNew.TVItemID = tvItemModel.TVItemID;
                tvlNew.TVText = tvItemModel.TVText;
                tvlNew.TVType = tvItemModel.TVType;
                tvlNew.SubTVType = ShowTVType;

                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVType, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count > 0)
                {
                    FillMapInfoPoint(mapInfoPointModelList, tvlNew, MapInfoDrawTypeEnum.Point);
                    tvLocationList.Add(tvlNew);
                }
            }
        }

        // Get
        public double Bound(double value, double min, double max)
        {
            value = Math.Min(value, max);
            return Math.Max(value, min);
        }
        public Coord Mercator(double latitude, double longitude)
        {
            double siny = Bound(Math.Sin(latitude * Math.PI / 180.0), -.9999, .9999);

            Coord coord = new Coord() { Lat = 0.0f, Lng = 0.0f, Ordinal = 0 };
            coord.Lng = (float)(OriginX + longitude * PixelsPerLonDegree);
            coord.Lat = (float)(OriginY + .5 * Math.Log((1 + siny) / (1 - siny)) * -PixelsPerLonRadian);

            return coord;
        }
        public Coord InverseMercator(double x, double y)
        {
            Coord coord = new Coord() { Lat = 0.0f, Lng = 0.0f, Ordinal = 0 };

            coord.Lng = (float)((x - OriginX) / PixelsPerLonDegree);
            double latRadians = (y - OriginY) / -PixelsPerLonRadian;
            coord.Lat = (float)(Math.Atan(Math.Sinh(latRadians)) * 180.0 / Math.PI);

            return coord;
        }
        public CoordMap GetBounds(Coord center, int zoom, int mapWidth, int mapHeight)
        {
            var scale = 1 << zoom;

            var centerWorld = Mercator(center.Lat, center.Lng);
            var centerPixel = new Coord() { Lat = 0.0f, Lng = 0.0f, Ordinal = 0 };
            centerPixel.Lng = centerWorld.Lng * scale;
            centerPixel.Lat = centerWorld.Lat * scale;

            var NEPixel = new Coord { Lat = 0.0f, Lng = 0.0f, Ordinal = 0 };
            NEPixel.Lng = (float)(centerPixel.Lng + mapWidth / 2.0);
            NEPixel.Lat = (float)(centerPixel.Lat - mapHeight / 2.0);

            var SWPixel = new Coord { Lat = 0.0f, Lng = 0.0f, Ordinal = 0 };
            SWPixel.Lng = (float)(centerPixel.Lng - mapWidth / 2.0);
            SWPixel.Lat = (float)(centerPixel.Lat + mapHeight / 2.0);

            var NEWorld = new Coord { Lat = 0.0f, Lng = 0.0f, Ordinal = 0 };
            NEWorld.Lng = NEPixel.Lng / scale;
            NEWorld.Lat = NEPixel.Lat / scale;

            var SWWorld = new Coord { Lat = 0.0f, Lng = 0.0f, Ordinal = 0 };
            SWWorld.Lng = SWPixel.Lng / scale;
            SWWorld.Lat = SWPixel.Lat / scale;

            var NELatLon = InverseMercator(NEWorld.Lng, NEWorld.Lat);
            var SWLatLon = InverseMercator(SWWorld.Lng, SWWorld.Lat);

            return new CoordMap() { NorthEast = NELatLon, SouthWest = SWLatLon };
        }
        public double CalculateAreaOfPolygon(List<Coord> NodeList)
        {
            double TotalArea = 0;

            double MinLat = (double)NodeList.Min(e => e.Lat);
            double MinLong = (double)NodeList.Min(e => e.Lng);
            double DistOneLat = CalculateDistance(MinLat * d2r, MinLong * d2r, (MinLat + 1) * d2r, MinLong * d2r, R);
            double DistOneLong = CalculateDistance(MinLat * d2r, MinLong * d2r, MinLat * d2r, (MinLong + 1) * d2r, R);

            double SumPositive = 0;
            double SumNegative = 0;
            for (int i = 0; i < NodeList.Count; i++)
            {
                if (i == NodeList.Count - 1)
                {
                    SumPositive += ((double)NodeList[i].Lng * DistOneLong) * ((double)NodeList[0].Lat * DistOneLat);
                    SumNegative += ((double)NodeList[i].Lat * DistOneLat) * ((double)NodeList[0].Lng * DistOneLong);
                }
                else
                {
                    SumPositive += ((double)NodeList[i].Lng * DistOneLong) * ((double)NodeList[i + 1].Lat * DistOneLat);
                    SumNegative += ((double)NodeList[i].Lat * DistOneLat) * ((double)NodeList[i + 1].Lng * DistOneLong);
                }

                TotalArea = (SumPositive - SumNegative) / 2;

            }

            return TotalArea;
        }
        public double CalculateAreaOfPolygon(List<Node> NodeList)
        {
            double TotalArea = 0;

            double MinLat = (double)NodeList.Min(e => e.Y);
            double MinLong = (double)NodeList.Min(e => e.X);
            double DistOneLat = CalculateDistance(MinLat * d2r, MinLong * d2r, (MinLat + 1) * d2r, MinLong * d2r, R);
            double DistOneLong = CalculateDistance(MinLat * d2r, MinLong * d2r, MinLat * d2r, (MinLong + 1) * d2r, R);

            double SumPositive = 0;
            double SumNegative = 0;
            for (int i = 0; i < NodeList.Count; i++)
            {
                if (i == NodeList.Count - 1)
                {
                    SumPositive += ((double)NodeList[i].X * DistOneLong) * ((double)NodeList[0].Y * DistOneLat);
                    SumNegative += ((double)NodeList[i].Y * DistOneLat) * ((double)NodeList[0].X * DistOneLong);
                }
                else
                {
                    SumPositive += ((double)NodeList[i].X * DistOneLong) * ((double)NodeList[i + 1].Y * DistOneLat);
                    SumNegative += ((double)NodeList[i].Y * DistOneLat) * ((double)NodeList[i + 1].X * DistOneLong);
                }

                TotalArea = (SumPositive - SumNegative) / 2;

            }

            return TotalArea;
        }
        public double CalculateDistance(double lat1, double long1, double lat2, double long2, double EarthRadius)
        {
            return Math.Abs(EarthRadius * Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(long2 - long1)));
        }

        public Coord CalculateDestination(double Lat, double Lng, double distance, double bearing)
        {
            double Lat2 = Math.Asin(Math.Sin(Lat) * Math.Cos(distance / R) + Math.Cos(Lat) * Math.Sin(distance / R) * Math.Cos(bearing));
            double Lng2 = Lng + Math.Atan2(Math.Sin(bearing) * Math.Sin(distance / R) * Math.Cos(Lat), Math.Cos(distance / R) - Math.Sin(Lat) * Math.Sin(Lat2));
            return new Coord() { Lat = (float)(Lat2 * r2d), Lng = (float)(Lng2 * r2d), Ordinal = 0 };
        }
        public void CalculateMWQMSiteStat(List<MWQMSample> mwqmSampleList, TVLocation tvlNew, int MinFC, int MaxFC, int SampCount)
        {
            MWQMSiteService mwqmSiteService = new MWQMSiteService(LanguageRequest, User);
            mwqmSiteService.CalculateMWQMSiteStat(mwqmSampleList, tvlNew, MinFC, MaxFC, SampCount);
        }
        public void CalculateMWQMSiteStatOneDay(List<MWQMSample> mwqmSampleList, TVLocation tvlNew)
        {
            MWQMSiteService mwqmSiteService = new MWQMSiteService(LanguageRequest, User);
            mwqmSiteService.CalculateMWQMSiteStatOneDay(mwqmSampleList, tvlNew);
        }
        public int GetMapInfoModelCountDB()
        {
            return (from c in db.MapInfos
                    select c).Count();
        }
        public List<MapInfo> GetMapInfoListWithTVItemIDDB(int TVItemID)
        {
            List<MapInfo> mapInfoList = (from c in db.MapInfos
                                         where c.TVItemID == TVItemID
                                         orderby c.MapInfoID
                                         select c).ToList<MapInfo>();

            return mapInfoList;
        }
        public List<MapInfoModel> GetMapInfoModelListWithTVItemIDDB(int TVItemID)
        {
            List<MapInfoModel> mapInfoModelList = (from c in db.MapInfos
                                                   where c.TVItemID == TVItemID
                                                   orderby c.MapInfoID
                                                   select new MapInfoModel
                                                   {
                                                       Error = "",
                                                       MapInfoID = c.MapInfoID,
                                                       TVItemID = c.TVItemID,
                                                       TVType = (TVTypeEnum)c.TVType,
                                                       MapInfoDrawType = (MapInfoDrawTypeEnum)c.MapInfoDrawType,
                                                       LatMax = c.LatMax,
                                                       LatMin = c.LatMin,
                                                       LngMax = c.LngMax,
                                                       LngMin = c.LngMin,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                   }).ToList<MapInfoModel>();

            return mapInfoModelList;
        }
        public List<MapInfoModel> GetMapInfoModelWithLatAndLngInPolygonWithTVTypeDB(float Lat, float Lng, TVTypeEnum TVType)
        {
            List<MapInfoModel> mapInfoModelList = (from c in db.MapInfos
                                                   where c.LatMin <= Lat
                                                   && c.LatMax >= Lat
                                                   && c.LngMin <= Lng
                                                   && c.LngMax >= Lng
                                                   && c.TVType == (int)TVType
                                                   select new MapInfoModel
                                                   {
                                                       Error = "",
                                                       MapInfoID = c.MapInfoID,
                                                       TVItemID = c.TVItemID,
                                                       TVType = (TVTypeEnum)c.TVType,
                                                       MapInfoDrawType = (MapInfoDrawTypeEnum)c.MapInfoDrawType,
                                                       LatMax = c.LatMax,
                                                       LatMin = c.LatMin,
                                                       LngMax = c.LngMax,
                                                       LngMin = c.LngMin,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                   }).ToList<MapInfoModel>();

            Coord coord = new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 };
            foreach (MapInfoModel mapInfoModel in mapInfoModelList)
            {
                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDB(mapInfoModel.MapInfoID);

                List<Coord> coordList = new List<Coord>();
                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                {
                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                }

                if (!CoordInPolygon(coordList, coord))
                {
                    mapInfoModel.Error = "R";
                }
            }

            return mapInfoModelList.Where(c => c.Error == "").ToList();
        }
        public List<MapInfoModel> GetMapInfoModelWithinCircleWithTVTypeAndMapInfoDrawTypeDB(float LatCircleCenter, float LngCircleCenter, float Radius_m, TVTypeEnum TVType, MapInfoDrawTypeEnum mapInfoDrawType)
        {
            float Factor = 10;
            List<float> FactorList = new List<float>() { 10, 1, 0.1f, 0.01f, 0.001f, 0.0001f, 0.00001f, 0.000001f };
            List<float> DistList = new List<float>() { 786647.4f, 78714.27f, 7871.476f, 787.1476f, 78.7148f, 7.871836f, 0.7837335f, 0.09504165f };

            if (Radius_m < 1)
            {
                Factor = FactorList.Last();
            }
            else
            {
                for (int i = 0, count = FactorList.Count - 1; i < count; i++)
                {
                    if (DistList[i] >= Radius_m && DistList[i + 1] <= Radius_m)
                    {
                        float GapFactor = (DistList[i] - Radius_m) / (DistList[i] - DistList[i + 1]);
                        Factor = FactorList[i] - ((FactorList[i] - FactorList[i + 1]) * GapFactor);
                        break;
                    }
                }
            }
            List<MapInfoModel> mapInfoModelList = (from c in db.MapInfos
                                                   where (LatCircleCenter - Factor) <= ((c.LatMax + c.LatMin) / 2)
                                                   && (LatCircleCenter + Factor) >= ((c.LatMax + c.LatMin) / 2)
                                                   && (LngCircleCenter - Factor) <= ((c.LngMax + c.LngMin) / 2)
                                                   && (LngCircleCenter + Factor) >= ((c.LngMax + c.LngMin) / 2)
                                                   && c.TVType == (int)TVType
                                                   && c.MapInfoDrawType == (int)mapInfoDrawType
                                                   select new MapInfoModel
                                                   {
                                                       Error = "",
                                                       MapInfoID = c.MapInfoID,
                                                       TVItemID = c.TVItemID,
                                                       TVType = (TVTypeEnum)c.TVType,
                                                       MapInfoDrawType = (MapInfoDrawTypeEnum)c.MapInfoDrawType,
                                                       LatMax = c.LatMax,
                                                       LatMin = c.LatMin,
                                                       LngMax = c.LngMax,
                                                       LngMin = c.LngMin,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                   }).ToList<MapInfoModel>();

            mapInfoModelList = (from c in mapInfoModelList
                                let lat = ((c.LatMax + c.LatMin) / 2)
                                let lng = ((c.LngMax + c.LngMin) / 2)
                                let r = Math.Sqrt((lat - LatCircleCenter) * (lat - LatCircleCenter) + (lng - LngCircleCenter) * (lng - LngCircleCenter))
                                orderby r
                                select c).ToList();


            return mapInfoModelList.ToList();
        }
        public MapInfoModel GetMapInfoModelWithMapInfoIDDB(int MapInfoID)
        {
            MapInfoModel mapInfoModel = (from c in db.MapInfos
                                         where c.MapInfoID == MapInfoID
                                         orderby c.MapInfoID
                                         select new MapInfoModel
                                         {
                                             Error = "",
                                             MapInfoID = c.MapInfoID,
                                             TVItemID = c.TVItemID,
                                             TVType = (TVTypeEnum)c.TVType,
                                             MapInfoDrawType = (MapInfoDrawTypeEnum)c.MapInfoDrawType,
                                             LatMax = c.LatMax,
                                             LatMin = c.LatMin,
                                             LngMax = c.LngMax,
                                             LngMin = c.LngMin,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                         }).FirstOrDefault<MapInfoModel>();

            if (mapInfoModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MapInfo, ServiceRes.MapInfoID, MapInfoID));

            return mapInfoModel;
        }
        public MapInfo GetMapInfoWithMapInfoIDDB(int MapInfoID)
        {
            MapInfo mapInfo = (from c in db.MapInfos
                               where c.MapInfoID == MapInfoID
                               orderby c.MapInfoID
                               select c).FirstOrDefault<MapInfo>();

            return mapInfo;
        }
        public CoordModel GetParentLatLngDB(int TVItemID)
        {
            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return new CoordModel() { Error = tvItemModelExist.Error };

            string[] strArr = tvItemModelExist.TVPath.Split("p".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            CoordModel coordModel = new CoordModel();
            for (int i = strArr.Length - 1; i > -1; i--)
            {
                int CurrentTVItemID = int.Parse(strArr[i]);

                coordModel = (from mi in db.MapInfos
                              from mip in db.MapInfoPoints
                              where mi.MapInfoID == mip.MapInfoID
                              && mi.TVItemID == CurrentTVItemID
                              && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                              select new CoordModel
                              {
                                  Error = "",
                                  Lat = (float)mip.Lat,
                                  Lng = (float)mip.Lng,
                                  Ordinal = mip.Ordinal,
                              }).FirstOrDefault<CoordModel>();

                if (coordModel != null)
                {
                    break;
                }
            }

            return coordModel;
        }
        public List<TVLocation> GetMapInfoDB(int TVItemID, TVTypeEnum ShowTVType, int Year, int Month, int Day, int NumberOfSamples, bool OnlyActive)
        {
            List<TVLocation> tvLocationList = new List<TVLocation>();

            if (TVItemID == 0)
                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID)) };

            string retStr = _BaseEnumService.TVTypeOK(ShowTVType);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes._IsRequired, ServiceRes.ShowTVType)) };

            if (Year == 0)
                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes._IsRequired, ServiceRes.Year)) };

            if (Month == 0)
                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes._IsRequired, ServiceRes.Month)) };

            if (Day == 0)
                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes._IsRequired, ServiceRes.Day)) };

            if (NumberOfSamples < 5)
                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes._ShouldBeMoreThan_, ServiceRes.NumberOfSamples, 5)) };


            TVItemModel tvItemModelCurrent = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelCurrent.Error))
                return new List<TVLocation>() { ReturnTVLocationError(tvItemModelCurrent.Error) };

            DateTime CurrentDate = new DateTime(Year, Month, Day);
            //DateTime NextDate = new DateTime(CurrentDate.Year, CurrentDate.Month, CurrentDate.Day).AddDays(1);

            switch (tvItemModelCurrent.TVType)
            {
                case TVTypeEnum.Area:
                    {
                        switch (ShowTVType)
                        {
                            case TVTypeEnum.Sector:
                                {
                                    List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Sector, ShowTVType);
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Municipality, ShowTVType);
                                }
                                break;
                            default:
                                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
                        }
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        switch (ShowTVType)
                        {
                            case TVTypeEnum.Province:
                                {
                                    List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Province, ShowTVType);
                                }
                                break;
                            default:
                                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
                        }

                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        switch (ShowTVType)
                        {
                            case TVTypeEnum.Infrastructure:
                                {
                                    List<TVItemModel> tvItemModelList = new List<TVItemModel>() { _TVItemService.GetTVItemModelWithTVItemIDDB(tvItemModelCurrent.TVItemID) };

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    foreach (TVItemModel tvItemModel in tvItemModelList)
                                    {
                                        TVLocation tvlNew = new TVLocation();
                                        tvlNew.TVItemID = tvItemModel.TVItemID;
                                        tvlNew.TVText = tvItemModel.TVText.Replace(@"\n", "<br />");
                                        tvlNew.TVType = tvItemModel.TVType;
                                        tvlNew.SubTVType = TVTypeEnum.OtherInfrastructure;

                                        InfrastructureModel infrastructureModel = GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModel.TVItemID);
                                        if (string.IsNullOrWhiteSpace(infrastructureModel.Error))
                                        {
                                            switch (infrastructureModel.InfrastructureType)
                                            {
                                                case null:
                                                case InfrastructureTypeEnum.Error:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.OtherInfrastructure;
                                                    }
                                                    break;
                                                case InfrastructureTypeEnum.LiftStation:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.LiftStation;
                                                    }
                                                    break;
                                                case InfrastructureTypeEnum.LineOverflow:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.LineOverflow;
                                                    }
                                                    break;
                                                case InfrastructureTypeEnum.Other:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.OtherInfrastructure;
                                                    }
                                                    break;
                                                case InfrastructureTypeEnum.SeeOtherMunicipality:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.SeeOtherMunicipality;
                                                    }
                                                    break;
                                                case InfrastructureTypeEnum.WWTP:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.WasteWaterTreatmentPlant;
                                                    }
                                                    break;
                                                default:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.OtherInfrastructure;
                                                    }
                                                    break;
                                            }
                                        }

                                        MapObj mapObjInfrastructure = new MapObj();
                                        List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, tvlNew.SubTVType, MapInfoDrawTypeEnum.Point);
                                        if (mapInfoPointModelList.Count > 0)
                                        {
                                            mapObjInfrastructure.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                            mapObjInfrastructure.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObjInfrastructure.CoordList = coordList;
                                            tvlNew.MapObjList.Add(mapObjInfrastructure);
                                        }

                                        tvLocationList.Add(tvlNew);

                                        TVLocation tvlNew2 = new TVLocation();
                                        tvlNew2.TVItemID = tvItemModel.TVItemID;
                                        tvlNew2.TVText = (tvItemModel.TVText + ServiceRes.Outfall).Replace(@"\n", "<br />");
                                        tvlNew2.TVType = tvItemModel.TVType;
                                        tvlNew2.SubTVType = TVTypeEnum.Outfall;

                                        MapObj mapObjOutfall = new MapObj();
                                        List<MapInfoPointModel> mapInfoPointModelList2 = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, tvlNew2.SubTVType, MapInfoDrawTypeEnum.Point);
                                        if (mapInfoPointModelList2.Count > 0)
                                        {
                                            mapObjOutfall.MapInfoID = mapInfoPointModelList2[0].MapInfoID;
                                            mapObjOutfall.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList2)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObjOutfall.CoordList = coordList;
                                            tvlNew2.MapObjList.Add(mapObjOutfall);
                                        }

                                        tvLocationList.Add(tvlNew2);

                                        if (mapInfoPointModelList.Count > 0 && mapInfoPointModelList2.Count > 0)
                                        {
                                            TVLocation tvlNew3 = new TVLocation();
                                            tvlNew3.TVItemID = tvItemModel.TVItemID;
                                            tvlNew3.TVText = (tvItemModel.TVText + ServiceRes.Outfall).Replace(@"\n", "<br />");
                                            tvlNew3.TVType = tvItemModel.TVType;
                                            tvlNew3.SubTVType = tvItemModel.TVType;

                                            MapObj mapObjLineInfrastructureToOutfall = new MapObj();
                                            mapObjLineInfrastructureToOutfall.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                            mapObjLineInfrastructureToOutfall.MapInfoDrawType = MapInfoDrawTypeEnum.Polyline;

                                            List<Coord> coordList3 = new List<Coord>();

                                            coordList3.Add(new Coord() { Lat = (float)mapObjInfrastructure.CoordList[0].Lat, Lng = (float)mapObjInfrastructure.CoordList[0].Lng, Ordinal = 0 });
                                            coordList3.Add(new Coord() { Lat = (float)mapObjOutfall.CoordList[0].Lat, Lng = (float)mapObjOutfall.CoordList[0].Lng, Ordinal = 0 });

                                            mapObjLineInfrastructureToOutfall.CoordList = coordList3;
                                            tvlNew3.MapObjList.Add(mapObjLineInfrastructureToOutfall);

                                            tvLocationList.Add(tvlNew3);
                                        }
                                    }

                                    List<int> MWQMSiteTVItemIDList = _PolSourceSiteEffectService.GetPolSourceSiteEffectModelListWithPolSourceSiteOrInfrastructureTVItemIDDB(tvItemModelCurrent.TVItemID)
                                               .Select(c => c.MWQMSiteTVItemID).ToList();

                                    using (CSSPDBEntities db2 = new CSSPDBEntities())
                                    {
                                        var tvItemMWQMSiteList = (from c in db2.TVItems
                                                                  from cl in db2.TVItemLanguages
                                                                  from l in MWQMSiteTVItemIDList
                                                                  where c.TVItemID == cl.TVItemID
                                                                  && c.TVItemID == l
                                                                  && cl.Language == (int)LanguageRequest
                                                                  && c.TVType == (int)TVTypeEnum.MWQMSite
                                                                  select new { c, cl }).ToList();



                                        foreach (var tvItemModel in tvItemMWQMSiteList)
                                        {
                                            TVLocation tvlNew = new TVLocation();
                                            tvlNew.TVItemID = tvItemModel.c.TVItemID;
                                            tvlNew.TVText = tvItemModel.cl.TVText;
                                            tvlNew.TVType = TVTypeEnum.PolSourceSite;
                                            tvlNew.SubTVType = TVTypeEnum.MWQMSite;

                                            GetMWQMSiteMapInfoStatDB(tvItemModel.c.TVItemID, tvlNew, NumberOfSamples);

                                            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.c.TVItemID, TVTypeEnum.MWQMSite, MapInfoDrawTypeEnum.Point);
                                            if (mapInfoPointModelList.Count > 0)
                                            {
                                                MapObj mapObj = new MapObj();
                                                mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                                mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                                List<Coord> coordList = new List<Coord>();

                                                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                                {
                                                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                                }

                                                mapObj.CoordList = coordList;
                                                tvlNew.MapObjList.Add(mapObj);
                                            }

                                            tvLocationList.Add(tvlNew);
                                        }
                                    }
                                }
                                break;
                            default:
                                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
                        }
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        switch (ShowTVType)
                        {
                            case TVTypeEnum.MikeScenario:
                                {
                                    List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, TVTypeEnum.MikeSource);

                                    MikeSourceService mikeSourceService = new MikeSourceService(LanguageRequest, User);
                                    List<MikeSourceModel> mikeSourceModelList = mikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(TVItemID);

                                    foreach (TVItemModel tvItemModel in tvItemModelList)
                                    {
                                        MikeSourceModel mikeSourceModel = (from c in mikeSourceModelList
                                                                           where c.MikeSourceTVItemID == tvItemModel.TVItemID
                                                                           select c).FirstOrDefault();

                                        if (mikeSourceModel != null)
                                        {
                                            if (mikeSourceModel.IsRiver)
                                            {
                                                FillTVLocationList(tvLocationList, new List<TVItemModel>() { tvItemModel }, TVTypeEnum.MikeSource, TVTypeEnum.MikeSourceIsRiver);
                                            }
                                            else if (mikeSourceModel.Include)
                                            {
                                                FillTVLocationList(tvLocationList, new List<TVItemModel>() { tvItemModel }, TVTypeEnum.MikeSource, TVTypeEnum.MikeSourceIncluded);
                                            }
                                            else
                                            {
                                                FillTVLocationList(tvLocationList, new List<TVItemModel>() { tvItemModel }, TVTypeEnum.MikeSource, TVTypeEnum.MikeSourceNotIncluded);
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
                        }

                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        switch (ShowTVType)
                        {
                            case TVTypeEnum.Infrastructure:
                                {
                                    List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelCurrent.TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    foreach (TVItemModel tvItemModel in tvItemModelList)
                                    {
                                        TVLocation tvlNew = new TVLocation();
                                        tvlNew.TVItemID = tvItemModel.TVItemID;
                                        tvlNew.TVText = tvItemModel.TVText.Replace(@"\n", "<br />");
                                        tvlNew.TVType = tvItemModel.TVType;
                                        tvlNew.SubTVType = TVTypeEnum.OtherInfrastructure;

                                        InfrastructureModel infrastructureModel = GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModel.TVItemID);
                                        if (string.IsNullOrWhiteSpace(infrastructureModel.Error))
                                        {
                                            switch (infrastructureModel.InfrastructureType)
                                            {
                                                case null:
                                                case InfrastructureTypeEnum.Error:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.OtherInfrastructure;
                                                    }
                                                    break;
                                                case InfrastructureTypeEnum.LiftStation:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.LiftStation;
                                                    }
                                                    break;
                                                case InfrastructureTypeEnum.Other:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.OtherInfrastructure;
                                                    }
                                                    break;
                                                case InfrastructureTypeEnum.SeeOtherMunicipality:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.SeeOtherMunicipality;
                                                    }
                                                    break;
                                                case InfrastructureTypeEnum.WWTP:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.WasteWaterTreatmentPlant;
                                                    }
                                                    break;
                                                case InfrastructureTypeEnum.LineOverflow:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.LineOverflow;
                                                    }
                                                    break;
                                                default:
                                                    {
                                                        tvlNew.SubTVType = TVTypeEnum.OtherInfrastructure;
                                                    }
                                                    break;
                                            }
                                        }

                                        MapObj mapObjInfrastructure = new MapObj();
                                        List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, tvlNew.SubTVType, MapInfoDrawTypeEnum.Point);
                                        if (mapInfoPointModelList.Count > 0)
                                        {
                                            mapObjInfrastructure.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                            mapObjInfrastructure.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObjInfrastructure.CoordList = coordList;
                                            tvlNew.MapObjList.Add(mapObjInfrastructure);
                                        }

                                        tvLocationList.Add(tvlNew);

                                        TVLocation tvlNew2 = new TVLocation();
                                        tvlNew2.TVItemID = tvItemModel.TVItemID;
                                        tvlNew2.TVText = (tvItemModel.TVText + ServiceRes.Outfall).Replace(@"\n", "<br />");
                                        tvlNew2.TVType = tvItemModel.TVType;
                                        tvlNew2.SubTVType = TVTypeEnum.Outfall;

                                        MapObj mapObjOutfallPoint = new MapObj();
                                        List<MapInfoPointModel> mapInfoPointModelList2 = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Point);
                                        if (mapInfoPointModelList2.Count > 0)
                                        {
                                            mapObjOutfallPoint.MapInfoID = mapInfoPointModelList2[0].MapInfoID;
                                            mapObjOutfallPoint.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList2)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObjOutfallPoint.CoordList = coordList;
                                            tvlNew2.MapObjList.Add(mapObjOutfallPoint);
                                        }

                                        tvLocationList.Add(tvlNew2);

                                        TVLocation tvlNew3 = new TVLocation();
                                        tvlNew3.TVItemID = tvItemModel.TVItemID;
                                        tvlNew3.TVText = (tvItemModel.TVText + ServiceRes.Outfall).Replace(@"\n", "<br />");
                                        tvlNew3.TVType = tvItemModel.TVType;
                                        tvlNew3.SubTVType = TVTypeEnum.Outfall;

                                        MapObj mapObjOutfallPolyline = new MapObj();
                                        List<MapInfoPointModel> mapInfoPointModelList3 = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Polyline);
                                        if (mapInfoPointModelList3.Count > 0)
                                        {
                                            mapObjOutfallPolyline.MapInfoID = mapInfoPointModelList3[0].MapInfoID;
                                            mapObjOutfallPolyline.MapInfoDrawType = MapInfoDrawTypeEnum.Polyline;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList3)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObjOutfallPolyline.CoordList = coordList;
                                            tvlNew3.MapObjList.Add(mapObjOutfallPolyline);
                                        }

                                        tvLocationList.Add(tvlNew3);

                                        TVLocation tvlNew4 = new TVLocation();
                                        tvlNew4.TVItemID = tvItemModel.TVItemID;
                                        tvlNew4.TVText = (tvItemModel.TVText + ServiceRes.Outfall).Replace(@"\n", "<br />");
                                        tvlNew4.TVType = tvItemModel.TVType;
                                        tvlNew4.SubTVType = tvlNew.SubTVType;

                                        MapObj mapObjTVItemLinkPolyline = new MapObj();
                                        List<MapInfoPointModel> mapInfoPointModelList4 = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, tvlNew.SubTVType, MapInfoDrawTypeEnum.Polyline);
                                        if (mapInfoPointModelList4.Count > 0)
                                        {
                                            mapObjTVItemLinkPolyline.MapInfoID = mapInfoPointModelList4[0].MapInfoID;
                                            mapObjTVItemLinkPolyline.MapInfoDrawType = MapInfoDrawTypeEnum.Polyline;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList4)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObjTVItemLinkPolyline.CoordList = coordList;
                                            tvlNew4.MapObjList.Add(mapObjTVItemLinkPolyline);
                                        }

                                        tvLocationList.Add(tvlNew4);

                                    }
                                }
                                break;
                            default:
                                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
                        }

                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        switch (ShowTVType)
                        {
                            case TVTypeEnum.PolSourceSite:
                                {
                                    List<TVItemModel> tvItemModelList = new List<TVItemModel>() { _TVItemService.GetTVItemModelWithTVItemIDDB(tvItemModelCurrent.ParentID) };

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Subsector, TVTypeEnum.Subsector);

                                    tvItemModelList = new List<TVItemModel>() { _TVItemService.GetTVItemModelWithTVItemIDDB(tvItemModelCurrent.TVItemID) };

                                    foreach (TVItemModel tvItemModel in tvItemModelList)
                                    {
                                        TVLocation tvlNew = new TVLocation();
                                        tvlNew.TVItemID = tvItemModel.TVItemID;
                                        tvlNew.TVText = tvItemModel.TVText;
                                        tvlNew.TVType = TVTypeEnum.PolSourceSite;
                                        tvlNew.SubTVType = TVTypeEnum.PolSourceSite;

                                        List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVTypeEnum.PolSourceSite, MapInfoDrawTypeEnum.Point);
                                        if (mapInfoPointModelList.Count > 0)
                                        {
                                            MapObj mapObj = new MapObj();
                                            mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                            mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObj.CoordList = coordList;
                                            tvlNew.MapObjList.Add(mapObj);
                                        }

                                        tvLocationList.Add(tvlNew);
                                    }

                                    List<int> MWQMSiteTVItemIDList = _PolSourceSiteEffectService.GetPolSourceSiteEffectModelListWithPolSourceSiteOrInfrastructureTVItemIDDB(tvItemModelCurrent.TVItemID)
                                                .Select(c => c.MWQMSiteTVItemID).ToList();

                                    using (CSSPDBEntities db2 = new CSSPDBEntities())
                                    {
                                        var tvItemMWQMSiteList = (from c in db2.TVItems
                                                                  from cl in db2.TVItemLanguages
                                                                  from l in MWQMSiteTVItemIDList
                                                                  where c.TVItemID == cl.TVItemID
                                                                  && c.TVItemID == l
                                                                  && cl.Language == (int)LanguageRequest
                                                                  && c.TVType == (int)TVTypeEnum.MWQMSite
                                                                  select new { c, cl }).ToList();



                                        foreach (var tvItemModel in tvItemMWQMSiteList)
                                        {
                                            TVLocation tvlNew = new TVLocation();
                                            tvlNew.TVItemID = tvItemModel.c.TVItemID;
                                            tvlNew.TVText = tvItemModel.cl.TVText;
                                            tvlNew.TVType = TVTypeEnum.PolSourceSite;
                                            tvlNew.SubTVType = TVTypeEnum.MWQMSite;

                                            GetMWQMSiteMapInfoStatDB(tvItemModel.c.TVItemID, tvlNew, NumberOfSamples);

                                            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.c.TVItemID, TVTypeEnum.MWQMSite, MapInfoDrawTypeEnum.Point);
                                            if (mapInfoPointModelList.Count > 0)
                                            {
                                                MapObj mapObj = new MapObj();
                                                mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                                mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                                List<Coord> coordList = new List<Coord>();

                                                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                                {
                                                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                                }

                                                mapObj.CoordList = coordList;
                                                tvlNew.MapObjList.Add(mapObj);
                                            }

                                            tvLocationList.Add(tvlNew);
                                        }
                                    }
                                }
                                break;
                            default:
                                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
                        }
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        switch (ShowTVType)
                        {
                            case TVTypeEnum.Area:
                                {
                                    List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Area, ShowTVType);
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Municipality, ShowTVType);
                                }
                                break;
                            case TVTypeEnum.File:
                                {
                                    List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.File, ShowTVType);
                                }
                                break;
                            case TVTypeEnum.SamplingPlan:
                                {
                                    List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.SamplingPlan, ShowTVType);
                                }
                                break;
                            default:
                                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
                        }
                    }
                    break;
                case TVTypeEnum.Root:
                    {
                        switch (ShowTVType)
                        {
                            case TVTypeEnum.Country:
                                {
                                    List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Country, ShowTVType);
                                }
                                break;
                            default:
                                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
                        }

                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        switch (ShowTVType)
                        {
                            case TVTypeEnum.Subsector:
                                {
                                    List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Subsector, ShowTVType);
                                }
                                break;
                            case TVTypeEnum.Municipality:
                                {
                                    List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Municipality, ShowTVType);
                                }
                                break;
                            default:
                                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
                        }

                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        List<TVItemModel> tvItemModelList = new List<TVItemModel>() { _TVItemService.GetTVItemModelWithTVItemIDDB(tvItemModelCurrent.TVItemID) };

                        if (OnlyActive)
                        {
                            tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                        }

                        FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Subsector, TVTypeEnum.Subsector);

                        switch (ShowTVType)
                        {
                            case TVTypeEnum.Municipality:
                                {
                                    tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Municipality, ShowTVType);
                                }
                                break;
                            case TVTypeEnum.PolSourceSite:
                                {
                                    tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelCurrent.TVItemID, ShowTVType);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    foreach (TVItemModel tvItemModel in tvItemModelList)
                                    {
                                        TVLocation tvlNew = new TVLocation();
                                        tvlNew.TVItemID = tvItemModel.TVItemID;
                                        tvlNew.TVText = tvItemModel.TVText;
                                        tvlNew.TVType = tvItemModel.TVType;
                                        tvlNew.SubTVType = ShowTVType;

                                        List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVTypeEnum.PolSourceSite, MapInfoDrawTypeEnum.Point);
                                        if (mapInfoPointModelList.Count > 0)
                                        {
                                            MapObj mapObj = new MapObj();
                                            mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                            mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObj.CoordList = coordList;
                                            tvlNew.MapObjList.Add(mapObj);
                                        }

                                        tvLocationList.Add(tvlNew);
                                    }

                                    List<TVItemModel> tvItemModelListMunicipality = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelCurrent.ParentID, TVTypeEnum.Municipality);

                                    foreach (TVItemModel tvItemModelMunicipality in tvItemModelListMunicipality)
                                    {
                                        tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);

                                        if (OnlyActive)
                                        {
                                            tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                        }

                                        foreach (TVItemModel tvItemModel in tvItemModelList)
                                        {
                                            TVLocation tvlNew = new TVLocation();
                                            tvlNew.TVItemID = tvItemModel.TVItemID;
                                            tvlNew.TVText = tvItemModel.TVText.Replace(@"\n", "<br />");
                                            tvlNew.TVType = tvItemModel.TVType;
                                            tvlNew.SubTVType = TVTypeEnum.OtherInfrastructure;

                                            InfrastructureModel infrastructureModel = GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModel.TVItemID);
                                            if (string.IsNullOrWhiteSpace(infrastructureModel.Error))
                                            {
                                                switch (infrastructureModel.InfrastructureType)
                                                {
                                                    case null:
                                                    case InfrastructureTypeEnum.Error:
                                                        {
                                                            tvlNew.SubTVType = TVTypeEnum.OtherInfrastructure;
                                                        }
                                                        break;
                                                    case InfrastructureTypeEnum.LiftStation:
                                                        {
                                                            tvlNew.SubTVType = TVTypeEnum.LiftStation;
                                                        }
                                                        break;
                                                    case InfrastructureTypeEnum.Other:
                                                        {
                                                            tvlNew.SubTVType = TVTypeEnum.OtherInfrastructure;
                                                        }
                                                        break;
                                                    case InfrastructureTypeEnum.SeeOtherMunicipality:
                                                        {
                                                            tvlNew.SubTVType = TVTypeEnum.SeeOtherMunicipality;
                                                        }
                                                        break;
                                                    case InfrastructureTypeEnum.WWTP:
                                                        {
                                                            tvlNew.SubTVType = TVTypeEnum.WasteWaterTreatmentPlant;
                                                        }
                                                        break;
                                                    case InfrastructureTypeEnum.LineOverflow:
                                                        {
                                                            tvlNew.SubTVType = TVTypeEnum.LineOverflow;
                                                        }
                                                        break;
                                                    default:
                                                        {
                                                            tvlNew.SubTVType = TVTypeEnum.OtherInfrastructure;
                                                        }
                                                        break;
                                                }
                                            }

                                            MapObj mapObjInfrastructure = new MapObj();
                                            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, tvlNew.SubTVType, MapInfoDrawTypeEnum.Point);
                                            if (mapInfoPointModelList.Count > 0)
                                            {
                                                mapObjInfrastructure.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                                mapObjInfrastructure.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                                List<Coord> coordList = new List<Coord>();

                                                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                                {
                                                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                                }

                                                mapObjInfrastructure.CoordList = coordList;
                                                tvlNew.MapObjList.Add(mapObjInfrastructure);
                                            }

                                            tvLocationList.Add(tvlNew);

                                            TVLocation tvlNew2 = new TVLocation();
                                            tvlNew2.TVItemID = tvItemModel.TVItemID;
                                            tvlNew2.TVText = (tvItemModel.TVText + ServiceRes.Outfall).Replace(@"\n", "<br />");
                                            tvlNew2.TVType = tvItemModel.TVType;
                                            tvlNew2.SubTVType = TVTypeEnum.Outfall;

                                            MapObj mapObjOutfallPoint = new MapObj();
                                            List<MapInfoPointModel> mapInfoPointModelList2 = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Point);
                                            if (mapInfoPointModelList2.Count > 0)
                                            {
                                                mapObjOutfallPoint.MapInfoID = mapInfoPointModelList2[0].MapInfoID;
                                                mapObjOutfallPoint.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                                List<Coord> coordList = new List<Coord>();

                                                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList2)
                                                {
                                                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                                }

                                                mapObjOutfallPoint.CoordList = coordList;
                                                tvlNew2.MapObjList.Add(mapObjOutfallPoint);
                                            }

                                            tvLocationList.Add(tvlNew2);

                                            TVLocation tvlNew3 = new TVLocation();
                                            tvlNew3.TVItemID = tvItemModel.TVItemID;
                                            tvlNew3.TVText = (tvItemModel.TVText + ServiceRes.Outfall).Replace(@"\n", "<br />");
                                            tvlNew3.TVType = tvItemModel.TVType;
                                            tvlNew3.SubTVType = TVTypeEnum.Outfall;

                                            MapObj mapObjOutfallPolyline = new MapObj();
                                            List<MapInfoPointModel> mapInfoPointModelList3 = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Polyline);
                                            if (mapInfoPointModelList3.Count > 0)
                                            {
                                                mapObjOutfallPolyline.MapInfoID = mapInfoPointModelList3[0].MapInfoID;
                                                mapObjOutfallPolyline.MapInfoDrawType = MapInfoDrawTypeEnum.Polyline;

                                                List<Coord> coordList = new List<Coord>();

                                                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList3)
                                                {
                                                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                                }

                                                mapObjOutfallPolyline.CoordList = coordList;
                                                tvlNew3.MapObjList.Add(mapObjOutfallPolyline);
                                            }

                                            tvLocationList.Add(tvlNew3);

                                            TVLocation tvlNew4 = new TVLocation();
                                            tvlNew4.TVItemID = tvItemModel.TVItemID;
                                            tvlNew4.TVText = (tvItemModel.TVText + ServiceRes.Outfall).Replace(@"\n", "<br />");
                                            tvlNew4.TVType = tvItemModel.TVType;
                                            tvlNew4.SubTVType = tvlNew.SubTVType;

                                            MapObj mapObjTVItemLinkPolyline = new MapObj();
                                            List<MapInfoPointModel> mapInfoPointModelList4 = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, tvlNew.SubTVType, MapInfoDrawTypeEnum.Polyline);
                                            if (mapInfoPointModelList4.Count > 0)
                                            {
                                                mapObjTVItemLinkPolyline.MapInfoID = mapInfoPointModelList4[0].MapInfoID;
                                                mapObjTVItemLinkPolyline.MapInfoDrawType = MapInfoDrawTypeEnum.Polyline;

                                                List<Coord> coordList = new List<Coord>();

                                                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList4)
                                                {
                                                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                                }

                                                mapObjTVItemLinkPolyline.CoordList = coordList;
                                                tvlNew4.MapObjList.Add(mapObjTVItemLinkPolyline);
                                            }

                                            tvLocationList.Add(tvlNew4);

                                        }

                                    }

                                    ClassificationService classificationService = new ClassificationService(_TVItemService.LanguageRequest, _TVItemService.User);

                                    tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelCurrent.TVItemID, TVTypeEnum.Classification);

                                    List<ClassificationModel> classificationModelList = classificationService.GetClassificationModelListWithSubsectorTVItemIDDB(tvItemModelCurrent.TVItemID);

                                    foreach (TVItemModel tvItemModel in tvItemModelList)
                                    {
                                        TVLocation tvlNew = new TVLocation();
                                        tvlNew.TVItemID = tvItemModel.TVItemID;
                                        tvlNew.TVText = tvItemModel.TVText;
                                        tvlNew.TVType = tvItemModel.TVType;

                                        ClassificationModel classificationModel = classificationModelList.Where(c => c.ClassificationTVItemID == tvItemModel.TVItemID).FirstOrDefault();

                                        if (classificationModel != null)
                                        {
                                            TVTypeEnum tvTypeSubType = TVTypeEnum.Error;

                                            switch (classificationModel.ClassificationType)
                                            {
                                                case ClassificationTypeEnum.Approved:
                                                    {
                                                        tvTypeSubType = TVTypeEnum.Approved;
                                                    }
                                                    break;
                                                case ClassificationTypeEnum.Restricted:
                                                    {
                                                        tvTypeSubType = TVTypeEnum.Restricted;
                                                    }
                                                    break;
                                                case ClassificationTypeEnum.Prohibited:
                                                    {
                                                        tvTypeSubType = TVTypeEnum.Prohibited;
                                                    }
                                                    break;
                                                case ClassificationTypeEnum.ConditionallyApproved:
                                                    {
                                                        tvTypeSubType = TVTypeEnum.ConditionallyApproved;
                                                    }
                                                    break;
                                                case ClassificationTypeEnum.ConditionallyRestricted:
                                                    {
                                                        tvTypeSubType = TVTypeEnum.ConditionallyRestricted;
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }

                                            tvlNew.SubTVType = tvTypeSubType;

                                            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, tvTypeSubType, MapInfoDrawTypeEnum.Polyline);
                                            if (mapInfoPointModelList.Count > 0)
                                            {
                                                MapObj mapObj = new MapObj();
                                                mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                                mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Polyline;

                                                List<Coord> coordList = new List<Coord>();

                                                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                                {
                                                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                                }

                                                mapObj.CoordList = coordList;
                                                tvlNew.MapObjList.Add(mapObj);
                                            }

                                            tvLocationList.Add(tvlNew);
                                        }
                                    }
                                }
                                break;
                            case TVTypeEnum.SubsectorTools:
                                {
                                    tvItemModelList = new List<TVItemModel>() { _TVItemService.GetTVItemModelWithTVItemIDDB(tvItemModelCurrent.TVItemID) };

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Subsector, TVTypeEnum.Subsector);
                                }
                                break;
                            case TVTypeEnum.SamplingPlan:
                                {
                                    tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelCurrent.TVItemID, TVTypeEnum.MWQMSite);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    foreach (TVItemModel tvItemModel in tvItemModelList)
                                    {
                                        TVLocation tvlNew = new TVLocation();
                                        tvlNew.TVItemID = tvItemModel.TVItemID;
                                        tvlNew.TVText = tvItemModel.TVText;
                                        tvlNew.TVType = tvItemModel.TVType;
                                        tvlNew.SubTVType = ShowTVType;

                                        List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVTypeEnum.MWQMSite, MapInfoDrawTypeEnum.Point);
                                        if (mapInfoPointModelList.Count > 0)
                                        {
                                            MapObj mapObj = new MapObj();
                                            mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                            mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObj.CoordList = coordList;
                                            tvlNew.MapObjList.Add(mapObj);
                                        }

                                        tvLocationList.Add(tvlNew);
                                    }
                                }
                                break;
                            case TVTypeEnum.MWQMRun:
                                {
                                    tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelCurrent.TVItemID, TVTypeEnum.MWQMSite);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    foreach (TVItemModel tvItemModel in tvItemModelList)
                                    {
                                        TVLocation tvlNew = new TVLocation();
                                        tvlNew.TVItemID = tvItemModel.TVItemID;
                                        tvlNew.TVText = tvItemModel.TVText;
                                        tvlNew.TVType = tvItemModel.TVType;
                                        tvlNew.SubTVType = ShowTVType;

                                        GetMWQMSiteMapInfoStatOneDayDB(tvItemModel.TVItemID, tvlNew, new DateTime(CurrentDate.Year, CurrentDate.Month, CurrentDate.Day));

                                        List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVTypeEnum.MWQMSite, MapInfoDrawTypeEnum.Point);
                                        if (mapInfoPointModelList.Count > 0)
                                        {
                                            MapObj mapObj = new MapObj();
                                            mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                            mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObj.CoordList = coordList;
                                            tvlNew.MapObjList.Add(mapObj);
                                        }

                                        if (tvlNew.SubTVType != TVTypeEnum.NoData)
                                        {
                                            tvLocationList.Add(tvlNew);
                                        }
                                    }
                                }
                                break;
                            case TVTypeEnum.MWQMSite:
                                {
                                    tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelCurrent.TVItemID, TVTypeEnum.MWQMSite);

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    foreach (TVItemModel tvItemModel in tvItemModelList)
                                    {
                                        TVLocation tvlNew = new TVLocation();
                                        tvlNew.TVItemID = tvItemModel.TVItemID;
                                        tvlNew.TVText = tvItemModel.TVText;
                                        tvlNew.TVType = tvItemModel.TVType;
                                        tvlNew.SubTVType = ShowTVType;

                                        GetMWQMSiteMapInfoStatDB(tvItemModel.TVItemID, tvlNew, NumberOfSamples);

                                        List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVTypeEnum.MWQMSite, MapInfoDrawTypeEnum.Point);
                                        if (mapInfoPointModelList.Count > 0)
                                        {
                                            MapObj mapObj = new MapObj();
                                            mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                            mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObj.CoordList = coordList;
                                            tvlNew.MapObjList.Add(mapObj);
                                        }

                                        tvLocationList.Add(tvlNew);
                                    }

                                    ClassificationService classificationService = new ClassificationService(_TVItemService.LanguageRequest, _TVItemService.User);

                                    tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelCurrent.TVItemID, TVTypeEnum.Classification);

                                    List<ClassificationModel> classificationModelList = classificationService.GetClassificationModelListWithSubsectorTVItemIDDB(tvItemModelCurrent.TVItemID);

                                    foreach (TVItemModel tvItemModel in tvItemModelList)
                                    {
                                        TVLocation tvlNew = new TVLocation();
                                        tvlNew.TVItemID = tvItemModel.TVItemID;
                                        tvlNew.TVText = tvItemModel.TVText;
                                        tvlNew.TVType = tvItemModel.TVType;

                                        ClassificationModel classificationModel = classificationModelList.Where(c => c.ClassificationTVItemID == tvItemModel.TVItemID).FirstOrDefault();

                                        if (classificationModel != null)
                                        {
                                            TVTypeEnum tvTypeSubType = TVTypeEnum.Error;

                                            switch (classificationModel.ClassificationType)
                                            {
                                                case ClassificationTypeEnum.Approved:
                                                    {
                                                        tvTypeSubType = TVTypeEnum.Approved;
                                                    }
                                                    break;
                                                case ClassificationTypeEnum.Restricted:
                                                    {
                                                        tvTypeSubType = TVTypeEnum.Restricted;
                                                    }
                                                    break;
                                                case ClassificationTypeEnum.Prohibited:
                                                    {
                                                        tvTypeSubType = TVTypeEnum.Prohibited;
                                                    }
                                                    break;
                                                case ClassificationTypeEnum.ConditionallyApproved:
                                                    {
                                                        tvTypeSubType = TVTypeEnum.ConditionallyApproved;
                                                    }
                                                    break;
                                                case ClassificationTypeEnum.ConditionallyRestricted:
                                                    {
                                                        tvTypeSubType = TVTypeEnum.ConditionallyRestricted;
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }

                                            tvlNew.SubTVType = tvTypeSubType;

                                            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, tvTypeSubType, MapInfoDrawTypeEnum.Polyline);
                                            if (mapInfoPointModelList.Count > 0)
                                            {
                                                MapObj mapObj = new MapObj();
                                                mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                                mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Polyline;

                                                List<Coord> coordList = new List<Coord>();

                                                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                                {
                                                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                                }

                                                mapObj.CoordList = coordList;
                                                tvlNew.MapObjList.Add(mapObj);
                                            }

                                            tvLocationList.Add(tvlNew);
                                        }
                                    }

                                }
                                break;
                            case TVTypeEnum.ClimateSite:
                                {
                                    //TVTypeEnum tvType = TVTypeEnum.ClimateSite;
                                    //List<TVTypeEnum> tvTypeEnumList = new List<TVTypeEnum>() { TVTypeEnum.ClimateSite };

                                    //foreach (TVTypeEnum type in tvTypeEnumList)
                                    //{
                                    //    // doing ClimateSite
                                    //    List<UseOfSiteModel> useOfSiteModelList = _UseOfSiteService.GetUseOfSiteModelListWithTVTypeAndSubsectorTVItemIDDB(type, tvItemModelCurrent.TVItemID);

                                    //    if (useOfSiteModelList.Count > 0)
                                    //    {
                                    //        List<string> SiteNameList = useOfSiteModelList.Select(c => c.SiteTVText).Distinct().ToList();
                                    //        foreach (string siteName in SiteNameList)
                                    //        {
                                    //            TVLocation tvlNew = new TVLocation();
                                    //            tvlNew.TVItemID = useOfSiteModelList.Where(c => c.SiteTVText == siteName).First().SiteTVItemID;
                                    //            tvlNew.TVText = useOfSiteModelList.Where(c => c.SiteTVText == siteName).First().SiteTVText;

                                    //            if (type == TVTypeEnum.HydrometricSite)
                                    //                tvType = TVTypeEnum.HydrometricSite;

                                    //            if (type == TVTypeEnum.TideSite)
                                    //                tvType = TVTypeEnum.TideSite;

                                    //            tvlNew.TVType = tvType;
                                    //            tvlNew.SubTVType = tvType;

                                    //            foreach (UseOfSiteModel useOfSiteModel in useOfSiteModelList.Where(c => c.SiteTVText == siteName))
                                    //            {
                                    //                if (useOfSiteModel.StartYear == useOfSiteModel.EndYear)
                                    //                {
                                    //                    tvlNew.TVText += " [" + useOfSiteModel.StartYear + "]";
                                    //                }
                                    //                else
                                    //                {
                                    //                    tvlNew.TVText += " [" + useOfSiteModel.StartYear + "," + useOfSiteModel.EndYear + "]";
                                    //                }
                                    //            }

                                    //            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvlNew.TVItemID, tvType, MapInfoDrawTypeEnum.Point);
                                    //            if (mapInfoPointModelList.Count > 0)
                                    //            {
                                    //                MapObj mapObj = new MapObj();
                                    //                mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                    //                mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                    //                List<Coord> coordList = new List<Coord>();

                                    //                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                    //                {
                                    //                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                    //                }

                                    //                mapObj.CoordList = coordList;
                                    //                tvlNew.MapObjList.Add(mapObj);
                                    //            }

                                    //            tvLocationList.Add(tvlNew);
                                    //        }
                                    //    }
                                    //}
                                }
                                break;
                            case TVTypeEnum.HydrometricSite:
                                {
                                    //TVTypeEnum tvType = TVTypeEnum.HydrometricSite;
                                    //List<TVTypeEnum> tvTypeEnumList = new List<TVTypeEnum>() { TVTypeEnum.HydrometricSite };

                                    //foreach (TVTypeEnum type in tvTypeEnumList)
                                    //{
                                    //    // doing ClimateSite
                                    //    List<UseOfSiteModel> useOfSiteModelList = _UseOfSiteService.GetUseOfSiteModelListWithTVTypeAndSubsectorTVItemIDDB(type, tvItemModelCurrent.TVItemID);

                                    //    if (useOfSiteModelList.Count > 0)
                                    //    {
                                    //        List<string> SiteNameList = useOfSiteModelList.Select(c => c.SiteTVText).Distinct().ToList();
                                    //        foreach (string siteName in SiteNameList)
                                    //        {
                                    //            TVLocation tvlNew = new TVLocation();
                                    //            tvlNew.TVItemID = useOfSiteModelList.Where(c => c.SiteTVText == siteName).First().SiteTVItemID;
                                    //            tvlNew.TVText = useOfSiteModelList.Where(c => c.SiteTVText == siteName).First().SiteTVText;

                                    //            if (type == TVTypeEnum.HydrometricSite)
                                    //                tvType = TVTypeEnum.HydrometricSite;

                                    //            if (type == TVTypeEnum.TideSite)
                                    //                tvType = TVTypeEnum.TideSite;

                                    //            tvlNew.TVType = tvType;
                                    //            tvlNew.SubTVType = tvType;

                                    //            foreach (UseOfSiteModel useOfSiteModel in useOfSiteModelList.Where(c => c.SiteTVText == siteName))
                                    //            {
                                    //                if (useOfSiteModel.StartYear == useOfSiteModel.EndYear)
                                    //                {
                                    //                    tvlNew.TVText += " [" + useOfSiteModel.StartYear + "]";
                                    //                }
                                    //                else
                                    //                {
                                    //                    tvlNew.TVText += " [" + useOfSiteModel.StartYear + "," + useOfSiteModel.EndYear + "]";
                                    //                }
                                    //            }

                                    //            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvlNew.TVItemID, tvType, MapInfoDrawTypeEnum.Point);
                                    //            if (mapInfoPointModelList.Count > 0)
                                    //            {
                                    //                MapObj mapObj = new MapObj();
                                    //                mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                    //                mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                    //                List<Coord> coordList = new List<Coord>();

                                    //                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                    //                {
                                    //                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                    //                }

                                    //                mapObj.CoordList = coordList;
                                    //                tvlNew.MapObjList.Add(mapObj);
                                    //            }

                                    //            tvLocationList.Add(tvlNew);
                                    //        }
                                    //    }
                                    //}
                                }
                                break;
                            case TVTypeEnum.TideSite:
                                {
                                    //TVTypeEnum tvType = TVTypeEnum.TideSite;
                                    //List<TVTypeEnum> tvTypeEnumList = new List<TVTypeEnum>() { TVTypeEnum.TideSite };

                                    //foreach (TVTypeEnum type in tvTypeEnumList)
                                    //{
                                    //    // doing ClimateSite
                                    //    List<UseOfSiteModel> useOfSiteModelList = _UseOfSiteService.GetUseOfSiteModelListWithTVTypeAndSubsectorTVItemIDDB(type, tvItemModelCurrent.TVItemID);

                                    //    if (useOfSiteModelList.Count > 0)
                                    //    {
                                    //        List<string> SiteNameList = useOfSiteModelList.Select(c => c.SiteTVText).Distinct().ToList();
                                    //        foreach (string siteName in SiteNameList)
                                    //        {
                                    //            TVLocation tvlNew = new TVLocation();
                                    //            tvlNew.TVItemID = useOfSiteModelList.Where(c => c.SiteTVText == siteName).First().SiteTVItemID;
                                    //            tvlNew.TVText = useOfSiteModelList.Where(c => c.SiteTVText == siteName).First().SiteTVText;

                                    //            if (type == TVTypeEnum.HydrometricSite)
                                    //                tvType = TVTypeEnum.HydrometricSite;

                                    //            if (type == TVTypeEnum.TideSite)
                                    //                tvType = TVTypeEnum.TideSite;

                                    //            tvlNew.TVType = tvType;
                                    //            tvlNew.SubTVType = tvType;

                                    //            foreach (UseOfSiteModel useOfSiteModel in useOfSiteModelList.Where(c => c.SiteTVText == siteName))
                                    //            {
                                    //                if (useOfSiteModel.StartYear == useOfSiteModel.EndYear)
                                    //                {
                                    //                    tvlNew.TVText += " [" + useOfSiteModel.StartYear + "]";
                                    //                }
                                    //                else
                                    //                {
                                    //                    tvlNew.TVText += " [" + useOfSiteModel.StartYear + "," + useOfSiteModel.EndYear + "]";
                                    //                }
                                    //            }

                                    //            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvlNew.TVItemID, tvType, MapInfoDrawTypeEnum.Point);
                                    //            if (mapInfoPointModelList.Count > 0)
                                    //            {
                                    //                MapObj mapObj = new MapObj();
                                    //                mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                    //                mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                    //                List<Coord> coordList = new List<Coord>();

                                    //                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                    //                {
                                    //                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                    //                }

                                    //                mapObj.CoordList = coordList;
                                    //                tvlNew.MapObjList.Add(mapObj);
                                    //            }

                                    //            tvLocationList.Add(tvlNew);
                                    //        }
                                    //    }
                                    //}
                                }
                                break;
                            default:
                                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
                        }
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        switch (ShowTVType)
                        {
                            case TVTypeEnum.MWQMRun:
                                {
                                    List<TVItemModel> tvItemModelList = new List<TVItemModel>() { _TVItemService.GetTVItemModelWithTVItemIDDB(tvItemModelCurrent.ParentID) };

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Subsector, TVTypeEnum.Subsector);

                                    List<MWQMSampleModel> mwqmSampleModelList = _MWQMSampleService.GetMWQMSampleModelListWithMWQMRunTVItemIDDB(tvItemModelCurrent.TVItemID);

                                    foreach (MWQMSampleModel mwqmSampleModel in mwqmSampleModelList)
                                    {
                                        TVLocation tvlNew = new TVLocation();
                                        tvlNew.TVItemID = mwqmSampleModel.MWQMSiteTVItemID;
                                        tvlNew.TVText = mwqmSampleModel.MWQMSiteTVText;
                                        tvlNew.TVType = TVTypeEnum.MWQMSite;
                                        tvlNew.SubTVType = ShowTVType;

                                        GetMWQMSiteMapInfoStatOneDayDB(mwqmSampleModel.MWQMSiteTVItemID, tvlNew, mwqmSampleModel.SampleDateTime_Local);

                                        List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mwqmSampleModel.MWQMSiteTVItemID, TVTypeEnum.MWQMSite, MapInfoDrawTypeEnum.Point);
                                        if (mapInfoPointModelList.Count > 0)
                                        {
                                            MapObj mapObj = new MapObj();
                                            mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                            mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObj.CoordList = coordList;
                                            tvlNew.MapObjList.Add(mapObj);
                                        }

                                        tvLocationList.Add(tvlNew);
                                    }
                                }
                                break;
                            default:
                                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
                        }
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        switch (ShowTVType)
                        {
                            case TVTypeEnum.MWQMSite:
                                {
                                    List<TVItemModel> tvItemModelList = new List<TVItemModel>() { _TVItemService.GetTVItemModelWithTVItemIDDB(tvItemModelCurrent.ParentID) };

                                    if (OnlyActive)
                                    {
                                        tvItemModelList = tvItemModelList.Where(c => c.IsActive == true).ToList();
                                    }

                                    FillTVLocationList(tvLocationList, tvItemModelList, TVTypeEnum.Subsector, TVTypeEnum.Subsector);

                                    tvItemModelList = new List<TVItemModel>() { _TVItemService.GetTVItemModelWithTVItemIDDB(tvItemModelCurrent.TVItemID) };

                                    foreach (TVItemModel tvItemModel in tvItemModelList)
                                    {
                                        TVLocation tvlNew = new TVLocation();
                                        tvlNew.TVItemID = tvItemModel.TVItemID;
                                        tvlNew.TVText = tvItemModel.TVText;
                                        tvlNew.TVType = tvItemModel.TVType;
                                        tvlNew.SubTVType = ShowTVType;

                                        GetMWQMSiteMapInfoStatDB(tvItemModel.TVItemID, tvlNew, NumberOfSamples);

                                        List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.TVItemID, TVTypeEnum.MWQMSite, MapInfoDrawTypeEnum.Point);
                                        if (mapInfoPointModelList.Count > 0)
                                        {
                                            MapObj mapObj = new MapObj();
                                            mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                            mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                            List<Coord> coordList = new List<Coord>();

                                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                            {
                                                coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                            }

                                            mapObj.CoordList = coordList;
                                            tvlNew.MapObjList.Add(mapObj);
                                        }

                                        tvLocationList.Add(tvlNew);
                                    }

                                    List<int> PolSourceSiteTVItemIDList = _PolSourceSiteEffectService.GetPolSourceSiteEffectModelListWithMWQMSiteTVItemIDDB(tvItemModelCurrent.TVItemID)
                                        .Select(c => c.PolSourceSiteOrInfrastructureTVItemID).ToList();

                                    using (CSSPDBEntities db2 = new CSSPDBEntities())
                                    {
                                        var tvItemPSSList = (from c in db2.TVItems
                                                             from cl in db2.TVItemLanguages
                                                             from l in PolSourceSiteTVItemIDList
                                                             where c.TVItemID == cl.TVItemID
                                                             && c.TVItemID == l
                                                             && cl.Language == (int)LanguageRequest
                                                             && c.TVType == (int)TVTypeEnum.PolSourceSite
                                                             select new { c, cl }).ToList();



                                        foreach (var tvItemModel in tvItemPSSList)
                                        {
                                            TVLocation tvlNew = new TVLocation();
                                            tvlNew.TVItemID = tvItemModel.c.TVItemID;
                                            tvlNew.TVText = tvItemModel.cl.TVText;
                                            tvlNew.TVType = TVTypeEnum.MWQMSite;
                                            tvlNew.SubTVType = TVTypeEnum.PolSourceSite;

                                            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.c.TVItemID, TVTypeEnum.PolSourceSite, MapInfoDrawTypeEnum.Point);
                                            if (mapInfoPointModelList.Count > 0)
                                            {
                                                MapObj mapObj = new MapObj();
                                                mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                                mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                                List<Coord> coordList = new List<Coord>();

                                                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                                {
                                                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                                }

                                                mapObj.CoordList = coordList;
                                                tvlNew.MapObjList.Add(mapObj);
                                            }

                                            tvLocationList.Add(tvlNew);
                                        }
                                    }

                                    //List<int> InfrastructureTVItemIDList = _PolSourceSiteEffectService.GetPolSourceSiteEffectModelListWithMWQMSiteOrInfrastructureTVItemIDDB(tvItemModelCurrent.TVItemID)
                                    //    .Select(c => c.PolSourceSiteTVItemID).ToList();

                                    using (CSSPDBEntities db2 = new CSSPDBEntities())
                                    {
                                        var tvItemInfraList = (from c in db2.TVItems
                                                               from cl in db2.TVItemLanguages
                                                               from inf in db2.Infrastructures
                                                               from l in PolSourceSiteTVItemIDList
                                                               where c.TVItemID == cl.TVItemID
                                                               && cl.TVItemID == inf.InfrastructureTVItemID
                                                               && c.TVItemID == l
                                                               && cl.Language == (int)LanguageRequest
                                                               && c.TVType == (int)TVTypeEnum.Infrastructure
                                                               select new { c, cl, inf }).ToList();


                                        foreach (var tvItemModel in tvItemInfraList)
                                        {
                                            TVLocation tvlNew = new TVLocation();
                                            tvlNew.TVItemID = tvItemModel.c.TVItemID;
                                            tvlNew.TVText = tvItemModel.cl.TVText;
                                            tvlNew.TVType = TVTypeEnum.MWQMSite;

                                            TVTypeEnum tvTypeInf = TVTypeEnum.Error;
                                            switch ((InfrastructureTypeEnum)tvItemModel.inf.InfrastructureType)
                                            {
                                                case InfrastructureTypeEnum.WWTP:
                                                    {
                                                        tvTypeInf = TVTypeEnum.WasteWaterTreatmentPlant;
                                                    }
                                                    break;
                                                case InfrastructureTypeEnum.LiftStation:
                                                    {
                                                        tvTypeInf = TVTypeEnum.LiftStation;
                                                    }
                                                    break;
                                                case InfrastructureTypeEnum.LineOverflow:
                                                    {
                                                        tvTypeInf = TVTypeEnum.LineOverflow;
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }

                                            tvlNew.SubTVType = tvTypeInf;

                                            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModel.c.TVItemID, tvTypeInf, MapInfoDrawTypeEnum.Point);
                                            if (mapInfoPointModelList.Count > 0)
                                            {
                                                MapObj mapObj = new MapObj();
                                                mapObj.MapInfoID = mapInfoPointModelList[0].MapInfoID;
                                                mapObj.MapInfoDrawType = MapInfoDrawTypeEnum.Point;

                                                List<Coord> coordList = new List<Coord>();

                                                foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                                                {
                                                    coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                                                }

                                                mapObj.CoordList = coordList;
                                                tvlNew.MapObjList.Add(mapObj);
                                            }

                                            tvLocationList.Add(tvlNew);
                                        }
                                    }
                                }
                                break;
                            default:
                                return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
                        }
                    }
                    break;
                default:
                    return new List<TVLocation>() { ReturnTVLocationError(string.Format(ServiceRes.TVType_WithShowTVType_IsNotImplemented, tvItemModelCurrent.TVType.ToString(), ShowTVType.ToString())) };
            }

            return tvLocationList;
        }
        public MWQMSiteModel GetMWQMSiteModelWithMWQMSiteTVItemIDDB(int MWQMSiteTVItemID)
        {
            MWQMSiteService mwqmSiteService = new MWQMSiteService(LanguageRequest, User);
            MWQMSiteModel mwqmSiteModel = mwqmSiteService.GetMWQMSiteModelWithMWQMSiteTVItemIDDB(MWQMSiteTVItemID);

            return mwqmSiteModel;
        }
        public void GetMWQMSiteMapInfoStatOneDayDB(int TVItemID, TVLocation tvlNew, DateTime SampleDate)
        {
            MWQMSiteService mwqmSiteService = new MWQMSiteService(LanguageRequest, User);
            mwqmSiteService.GetMWQMSiteMapInfoStatOneDayDB(TVItemID, tvlNew, SampleDate);
        }
        public void GetMWQMSiteMapInfoStatDB(int TVItemID, TVLocation tvlNew, int NumberOfSamples)
        {
            MWQMSiteService mwqmSiteService = new MWQMSiteService(LanguageRequest, User);
            mwqmSiteService.GetMWQMSiteMapInfoStatDB(TVItemID, tvlNew, NumberOfSamples);
        }
        public Coord GetNextPointOnCircle(float radius, float angleInDegrees, Coord origin)
        {
            float Lng = (float)(radius * Math.Cos(angleInDegrees * d2r)) + origin.Lng;
            float Lat = (float)(radius * Math.Sin(angleInDegrees * d2r)) + origin.Lat;

            return new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 };
        }
        public List<PolSourceObservationModel> GetPolSourceObservationModelListWithPolSourceSiteIDDB(int PolSourceSiteID)
        {
            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, User);
            List<PolSourceObservationModel> polSourceObservationModelList = polSourceObservationService.GetPolSourceObservationModelListWithPolSourceSiteIDDB(PolSourceSiteID);

            return polSourceObservationModelList;
        }
        public PolSourceSiteModel GetPolSourceSiteModelWithPolSourceSiteIDDB(int PolSourceSiteID)
        {
            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, User);
            PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteIDDB(PolSourceSiteID);

            return polSourceSiteModel;
        }
        public MapInfoModel ReturnError(string Error)
        {
            return new MapInfoModel() { Error = Error };
        }
        public TVLocation ReturnTVLocationError(string Error)
        {
            return new TVLocation() { Error = Error };
        }
        public MapInfoPointModel ReturnMapInfoPointError(string Error)
        {
            return new MapInfoPointModel() { Error = Error };
        }
        public MapInfoModel ReturnMapInfoError(string Error)
        {
            return new MapInfoModel() { Error = Error };
        }
        public bool CoordInPolygon(List<Coord> poly, Coord pnt)
        {
            int i, j;
            int nvert = poly.Count;
            bool InPoly = false;
            for (i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((poly[i].Lat > pnt.Lat) != (poly[j].Lat > pnt.Lat)) &&
                 (pnt.Lng < (poly[j].Lng - poly[i].Lng) * (pnt.Lat - poly[i].Lat) / (poly[j].Lat - poly[i].Lat) + poly[i].Lng))
                    InPoly = !InPoly;
            }
            return InPoly;
        }
        public float GetDrainageAreaWithTVItemIDWillCreatePolygonIfItDoesNotExistDB(int TVItemID)
        {
            float DrainageArea = 0;
            bool PolygonExist = false;
            List<MapInfoModel> mapInfoModelList = GetMapInfoModelListWithTVItemIDDB(TVItemID);

            foreach (MapInfoModel mapInfoModel in mapInfoModelList)
            {
                if (mapInfoModel.MapInfoDrawType == MapInfoDrawTypeEnum.Polygon)
                {
                    List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDB(mapInfoModel.MapInfoID);

                    if (mapInfoPointModelList.Count > 0)
                    {
                        List<Coord> coordList = new List<Coord>();
                        foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                        {
                            coordList.Add(new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = mapInfoPointModel.Ordinal });
                        }

                        return (float)CalculateAreaOfPolygon(coordList) / 1000.0f / 1000.0f;
                    }
                }
            }

            if (!PolygonExist)
            {
                foreach (MapInfoModel mapInfoModel in mapInfoModelList)
                {
                    if (mapInfoModel.MapInfoDrawType == MapInfoDrawTypeEnum.Point)
                    {
                        List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDB(mapInfoModel.MapInfoID);

                        if (mapInfoPointModelList.Count > 0)
                        {
                            List<Coord> coordList = new List<Coord>();
                            coordList.Add(new Coord() { Lat = (float)(mapInfoPointModelList[0].Lat - 0.01f), Lng = (float)(mapInfoPointModelList[0].Lng - 0.01f), Ordinal = 0 });
                            coordList.Add(new Coord() { Lat = (float)(mapInfoPointModelList[0].Lat - 0.01f), Lng = (float)(mapInfoPointModelList[0].Lng + 0.01f), Ordinal = 0 });
                            coordList.Add(new Coord() { Lat = (float)(mapInfoPointModelList[0].Lat + 0.01f), Lng = (float)(mapInfoPointModelList[0].Lng + 0.01f), Ordinal = 0 });
                            coordList.Add(new Coord() { Lat = (float)(mapInfoPointModelList[0].Lat + 0.01f), Lng = (float)(mapInfoPointModelList[0].Lng - 0.01f), Ordinal = 0 });
                            coordList.Add(new Coord() { Lat = (float)(mapInfoPointModelList[0].Lat - 0.01f), Lng = (float)(mapInfoPointModelList[0].Lng - 0.01f), Ordinal = 0 });

                            MapInfoModel mapInfoModelRet = CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polygon, TVTypeEnum.MikeSource, TVItemID);
                            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                            {
                                return 0;
                            }

                            return (float)CalculateAreaOfPolygon(coordList) / 1000.0f / 1000.0f;
                        }
                    }
                }
            }

            return DrainageArea;
        }

        // Post
        public MapInfoModel CreateMapInfoObjectDB(List<Coord> coordList, MapInfoDrawTypeEnum mapInfoDrawType, TVTypeEnum TVType, int TVItemID)
        {
            MapInfoModel mapInfoModelRet = new MapInfoModel();

            List<MapInfoModel> mapInfoModelList = GetMapInfoModelListWithTVItemIDDB(TVItemID).Where(c => c.TVType == TVType && c.MapInfoDrawType == mapInfoDrawType).ToList();

            foreach (MapInfoModel mapInfoModel in mapInfoModelList)
            {
                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDB(mapInfoModel.MapInfoID);

                if (mapInfoPointModelList.Count == coordList.Count)
                {
                    bool ThisItemExist = true;
                    for (int i = 0, count = coordList.Count; i < count; i++)
                    {
                        if (mapInfoPointModelList[i].Lat != coordList[i].Lat)
                        {
                            ThisItemExist = false;
                            break;
                        }
                        if (mapInfoPointModelList[i].Lng != coordList[i].Lng)
                        {
                            ThisItemExist = false;
                            break;
                        }
                    }

                    if (ThisItemExist)
                    {
                        return mapInfoModel;
                    }
                }
            }

            using (TransactionScope ts = new TransactionScope())
            {
                MapInfoModel mapInfoModelNew = new MapInfoModel()
                {
                    TVItemID = TVItemID,
                    TVType = TVType,
                    MapInfoDrawType = mapInfoDrawType,
                    LatMin = (float)(coordList.Min(c => c.Lat) - 0.001),
                    LatMax = (float)(coordList.Max(c => c.Lat) + 0.001),
                    LngMin = (float)(coordList.Min(c => c.Lng) - 0.001),
                    LngMax = (float)(coordList.Max(c => c.Lng) + 0.001),
                };

                mapInfoModelRet = PostAddMapInfoDB(mapInfoModelNew);
                if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                    return ReturnError(mapInfoModelRet.Error);

                int ord = 0;
                foreach (Coord c in coordList)
                {
                    MapInfoPointModel mapInfoPointModelNew = new MapInfoPointModel()
                    {
                        MapInfoID = mapInfoModelRet.MapInfoID,
                        Lat = c.Lat,
                        Lng = c.Lng,
                        Ordinal = c.Ordinal,
                    };

                    MapInfoPointModel mapInfoPointModelRet = _MapInfoPointService.PostAddMapInfoPointDB(mapInfoPointModelNew);
                    if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                        return ReturnError(mapInfoPointModelRet.Error);

                    ord += 1;
                }

                ts.Complete();
            }
            return mapInfoModelRet;
        }
        public MapInfoModel PostAddMapInfoDB(MapInfoModel mapInfoModel)
        {
            string retStr = MapInfoModelOK(mapInfoModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MapInfo mapInfoNew = new MapInfo();
            retStr = FillMapInfo(mapInfoNew, mapInfoModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MapInfos.Add(mapInfoNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MapInfos", mapInfoNew.MapInfoID, LogCommandEnum.Add, mapInfoNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMapInfoModelWithMapInfoIDDB(mapInfoNew.MapInfoID);
        }
        public MapInfoModel PostDeleteMapInfoDB(int MapInfoID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MapInfo mapInfoToDelete = GetMapInfoWithMapInfoIDDB(MapInfoID);
            if (mapInfoToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MapInfo));

            using (TransactionScope ts = new TransactionScope())
            {
                db.MapInfos.Remove(mapInfoToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MapInfos", mapInfoToDelete.MapInfoID, LogCommandEnum.Delete, mapInfoToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public MapInfoModel PostDeleteMapInfoWithTVItemIDDB(int TVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            using (TransactionScope ts = new TransactionScope())
            {
                List<MapInfoModel> mapInfoModelListToDelete = GetMapInfoModelListWithTVItemIDDB(TVItemID);
                foreach (MapInfoModel mapInfoModelToDelete in mapInfoModelListToDelete)
                {
                    MapInfoModel mapInfoModelRet = PostDeleteMapInfoDB(mapInfoModelToDelete.MapInfoID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                        return ReturnError(mapInfoModelRet.Error);
                }

                ts.Complete();
            }
            return ReturnError("");
        }
        public MapInfoModel PostDeleteMapInfoWithTVPathStartWithDB(string TVPath)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            List<MapInfo> mapInfoList = (from c in db.TVItems
                                         from p in db.MapInfos
                                         where c.TVItemID == p.TVItemID
                                         && c.TVPath.StartsWith(TVPath)
                                         select p).ToList<MapInfo>();

            foreach (MapInfo mi in mapInfoList)
            {
                db.MapInfos.Remove(mi);

                LogModel logModel = _LogService.PostAddLogForObj("MapInfos", mi.MapInfoID, LogCommandEnum.Delete, mi);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);
            }

            string retStr = DoDeleteChanges();
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);


            return ReturnError("");
        }
        public MapInfoPointModel PostSavePointDB(int MapInfoID, float Lat, float Lng)
        {
            if (MapInfoID == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoID));

            string retStr = FieldCheckNotNullAndWithinRangeDouble((double)Lat, ServiceRes.Lat, -90, 90);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMapInfoPointError(retStr);

            retStr = FieldCheckNotNullAndWithinRangeDouble((double)Lng, ServiceRes.Lng, -180, 180);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMapInfoPointError(retStr);

            MapInfoModel mapInfoModel = GetMapInfoModelWithMapInfoIDDB(MapInfoID);
            if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                return ReturnMapInfoPointError(mapInfoModel.Error);

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(mapInfoModel.TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return ReturnMapInfoPointError(tvItemModel.Error);

            List<MapInfoPointModel> mapInfoPointModelToChangeList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mapInfoModel.TVItemID, mapInfoModel.TVType, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelToChangeList.Count == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.MapInfoPoint));

            mapInfoPointModelToChangeList[0].Lat = Lat;
            mapInfoPointModelToChangeList[0].Lng = Lng;

            MapInfoPointModel mapInfoPointModel = _MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelToChangeList[0]);
            if (!string.IsNullOrWhiteSpace(mapInfoPointModel.Error))
                return ReturnMapInfoPointError(mapInfoPointModel.Error);

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDB(mapInfoPointModelToChangeList[0].MapInfoID);
            if (mapInfoPointModelList.Count == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint));

            mapInfoModel = GetMapInfoModelWithMapInfoIDDB(mapInfoPointModelToChangeList[0].MapInfoID);
            if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                return ReturnMapInfoPointError(mapInfoModel.Error);

            mapInfoModel.LatMin = (float)((from c in mapInfoPointModelList select c.Lat).Min() - 0.001f);
            mapInfoModel.LatMax = (float)((from c in mapInfoPointModelList select c.Lat).Max() + 0.001f);
            mapInfoModel.LngMin = (float)((from c in mapInfoPointModelList select c.Lng).Min() - 0.001f);
            mapInfoModel.LngMax = (float)((from c in mapInfoPointModelList select c.Lng).Max() + 0.001f);

            MapInfoModel mapInfoModelRet = PostUpdateMapInfoDB(mapInfoModel);
            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                return ReturnMapInfoPointError(mapInfoModelRet.Error);

            if (mapInfoModel.TVType == TVTypeEnum.Outfall
                || mapInfoModel.TVType == TVTypeEnum.WasteWaterTreatmentPlant
                || mapInfoModel.TVType == TVTypeEnum.LiftStation
                || mapInfoModel.TVType == TVTypeEnum.OtherInfrastructure
                || mapInfoModel.TVType == TVTypeEnum.SeeOtherMunicipality
                || mapInfoModel.TVType == TVTypeEnum.LineOverflow
                )
            {

                InfrastructureModel infrastructureModel = GetInfrastructureModelWithInfrastructureTVItemIDDB(mapInfoModel.TVItemID);
                TVTypeEnum tvType = TVTypeEnum.Error;
                switch (infrastructureModel.InfrastructureType)
                {
                    case InfrastructureTypeEnum.LiftStation:
                        {
                            tvType = TVTypeEnum.LiftStation;
                        }
                        break;
                    case InfrastructureTypeEnum.WWTP:
                        {
                            tvType = TVTypeEnum.WasteWaterTreatmentPlant;
                        }
                        break;
                    case InfrastructureTypeEnum.LineOverflow:
                        {
                            tvType = TVTypeEnum.LineOverflow;
                        }
                        break;
                    case InfrastructureTypeEnum.Other:
                        {
                            tvType = TVTypeEnum.OtherInfrastructure;
                        }
                        break;
                    case InfrastructureTypeEnum.SeeOtherMunicipality:
                        {
                            tvType = TVTypeEnum.SeeOtherMunicipality;
                        }
                        break;
                    default:
                        break;
                }

                if (mapInfoModel.TVType == TVTypeEnum.Outfall)
                {
                    List<MapInfoPointModel> mapInfoPointModelInfrastructureList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mapInfoModel.TVItemID, tvType, MapInfoDrawTypeEnum.Point);

                    if (mapInfoPointModelInfrastructureList.Count > 0)
                    {
                        InfrastructureModel infrastructureModelRet = InfrastructureCoordinateUpdateDB(infrastructureModel, tvType, (float)mapInfoPointModelInfrastructureList[0].Lat, (float)mapInfoPointModelInfrastructureList[0].Lng, (float?)mapInfoPointModelToChangeList[0].Lat, (float?)mapInfoPointModelToChangeList[0].Lng);
                        if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                            return ReturnMapInfoPointError(infrastructureModelRet.Error);

                        InfrastructureModel infrastructureModelRet3 = InfrastructureTVItemLinkPolylineUpdateDB(infrastructureModel, tvType, (float)mapInfoPointModelInfrastructureList[0].Lat, (float)mapInfoPointModelInfrastructureList[0].Lng);
                        if (!string.IsNullOrWhiteSpace(infrastructureModelRet3.Error))
                            return ReturnMapInfoPointError(infrastructureModelRet3.Error);
                    }
                }
                else
                {
                    List<MapInfoPointModel> mapInfoPointModelInfrastructureList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mapInfoModel.TVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Point);

                    if (mapInfoPointModelInfrastructureList.Count > 0)
                    {
                        InfrastructureModel infrastructureModelRet = InfrastructureCoordinateUpdateDB(infrastructureModel, tvType, (float)mapInfoPointModelToChangeList[0].Lat, (float)mapInfoPointModelToChangeList[0].Lng, (float)mapInfoPointModelInfrastructureList[0].Lat, (float)mapInfoPointModelInfrastructureList[0].Lng);
                        if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                            return ReturnMapInfoPointError(infrastructureModelRet.Error);

                        InfrastructureModel infrastructureModelRet3 = InfrastructureTVItemLinkPolylineUpdateDB(infrastructureModel, tvType, (float)mapInfoPointModelToChangeList[0].Lat, (float)mapInfoPointModelToChangeList[0].Lng);
                        if (!string.IsNullOrWhiteSpace(infrastructureModelRet3.Error))
                            return ReturnMapInfoPointError(infrastructureModelRet3.Error);
                    }
                }
            }
            return mapInfoPointModel;
        }
        public MapInfoPointModel PostSaveMoveLabelPointDB(int MapInfoID, float Lat, float Lng)
        {
            if (MapInfoID == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoID));

            string retStr = FieldCheckNotNullAndWithinRangeDouble((double)Lat, ServiceRes.Lat, -90, 90);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMapInfoPointError(retStr);

            retStr = FieldCheckNotNullAndWithinRangeDouble((double)Lng, ServiceRes.Lng, -180, 180);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMapInfoPointError(retStr);

            MapInfoModel mapInfoModel = GetMapInfoModelWithMapInfoIDDB(MapInfoID);
            if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                return ReturnMapInfoPointError(mapInfoModel.Error);

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(mapInfoModel.TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return ReturnMapInfoPointError(tvItemModel.Error);

            List<MapInfoPointModel> mapInfoPointModelToChangeList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mapInfoModel.TVItemID, mapInfoModel.TVType, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelToChangeList.Count == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.MapInfoPoint));

            if (mapInfoPointModelToChangeList.Count == 1)
            {
                // need to add a new point
                MapInfoPointModel mapInfoPointModelLabel = new MapInfoPointModel()
                {
                    MapInfoID = MapInfoID,
                    Lat = Lat,
                    Lng = Lng,
                    Ordinal = 1,
                };

                MapInfoPointModel mapInfoPointModelLabelRet = _MapInfoPointService.PostAddMapInfoPointDB(mapInfoPointModelLabel);
                if (!string.IsNullOrWhiteSpace(mapInfoPointModelLabelRet.Error))
                    return ReturnMapInfoPointError(mapInfoPointModelLabelRet.Error);

            }

            mapInfoPointModelToChangeList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mapInfoModel.TVItemID, mapInfoModel.TVType, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelToChangeList.Count == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.MapInfoPoint));

            if (mapInfoPointModelToChangeList.Count != 2)
            {
                return ReturnMapInfoPointError(string.Format(ServiceRes.MapInfoPointListShouldHave_Values, 2));
            }

            // point 1 is the Site location and point 2 is the Label location
            mapInfoPointModelToChangeList[1].Lat = Lat;
            mapInfoPointModelToChangeList[1].Lng = Lng;

            MapInfoPointModel mapInfoPointModel = _MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelToChangeList[1]);
            if (!string.IsNullOrWhiteSpace(mapInfoPointModel.Error))
                return ReturnMapInfoPointError(mapInfoPointModel.Error);

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDB(mapInfoPointModelToChangeList[0].MapInfoID);
            if (mapInfoPointModelList.Count == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint));

            mapInfoModel = GetMapInfoModelWithMapInfoIDDB(mapInfoPointModelToChangeList[0].MapInfoID);
            if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                return ReturnMapInfoPointError(mapInfoModel.Error);

            mapInfoModel.LatMin = (float)((from c in mapInfoPointModelList select c.Lat).Min() - 0.001f);
            mapInfoModel.LatMax = (float)((from c in mapInfoPointModelList select c.Lat).Max() + 0.001f);
            mapInfoModel.LngMin = (float)((from c in mapInfoPointModelList select c.Lng).Min() - 0.001f);
            mapInfoModel.LngMax = (float)((from c in mapInfoPointModelList select c.Lng).Max() + 0.001f);

            MapInfoModel mapInfoModelRet = PostUpdateMapInfoDB(mapInfoModel);
            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                return ReturnMapInfoPointError(mapInfoModelRet.Error);

            if (mapInfoModel.TVType == TVTypeEnum.Outfall
                || mapInfoModel.TVType == TVTypeEnum.WasteWaterTreatmentPlant
                || mapInfoModel.TVType == TVTypeEnum.LiftStation
                || mapInfoModel.TVType == TVTypeEnum.OtherInfrastructure
                || mapInfoModel.TVType == TVTypeEnum.SeeOtherMunicipality
                || mapInfoModel.TVType == TVTypeEnum.LineOverflow
                )
            {

                InfrastructureModel infrastructureModel = GetInfrastructureModelWithInfrastructureTVItemIDDB(mapInfoModel.TVItemID);
                TVTypeEnum tvType = TVTypeEnum.Error;
                switch (infrastructureModel.InfrastructureType)
                {
                    case InfrastructureTypeEnum.LiftStation:
                        {
                            tvType = TVTypeEnum.LiftStation;
                        }
                        break;
                    case InfrastructureTypeEnum.WWTP:
                        {
                            tvType = TVTypeEnum.WasteWaterTreatmentPlant;
                        }
                        break;
                    case InfrastructureTypeEnum.LineOverflow:
                        {
                            tvType = TVTypeEnum.LineOverflow;
                        }
                        break;
                    case InfrastructureTypeEnum.Other:
                        {
                            tvType = TVTypeEnum.OtherInfrastructure;
                        }
                        break;
                    case InfrastructureTypeEnum.SeeOtherMunicipality:
                        {
                            tvType = TVTypeEnum.SeeOtherMunicipality;
                        }
                        break;
                    default:
                        break;
                }

                if (mapInfoModel.TVType == TVTypeEnum.Outfall)
                {
                    List<MapInfoPointModel> mapInfoPointModelInfrastructureList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mapInfoModel.TVItemID, tvType, MapInfoDrawTypeEnum.Point);

                    if (mapInfoPointModelInfrastructureList.Count > 0)
                    {
                        InfrastructureModel infrastructureModelRet = InfrastructureCoordinateUpdateDB(infrastructureModel, tvType, (float)mapInfoPointModelInfrastructureList[0].Lat, (float)mapInfoPointModelInfrastructureList[0].Lng, (float?)mapInfoPointModelToChangeList[0].Lat, (float?)mapInfoPointModelToChangeList[0].Lng);
                        if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                            return ReturnMapInfoPointError(infrastructureModelRet.Error);

                        InfrastructureModel infrastructureModelRet3 = InfrastructureTVItemLinkPolylineUpdateDB(infrastructureModel, tvType, (float)mapInfoPointModelInfrastructureList[0].Lat, (float)mapInfoPointModelInfrastructureList[0].Lng);
                        if (!string.IsNullOrWhiteSpace(infrastructureModelRet3.Error))
                            return ReturnMapInfoPointError(infrastructureModelRet3.Error);
                    }
                }
                else
                {
                    List<MapInfoPointModel> mapInfoPointModelInfrastructureList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mapInfoModel.TVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Point);

                    if (mapInfoPointModelInfrastructureList.Count > 0)
                    {
                        InfrastructureModel infrastructureModelRet = InfrastructureCoordinateUpdateDB(infrastructureModel, tvType, (float)mapInfoPointModelToChangeList[0].Lat, (float)mapInfoPointModelToChangeList[0].Lng, (float)mapInfoPointModelInfrastructureList[0].Lat, (float)mapInfoPointModelInfrastructureList[0].Lng);
                        if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                            return ReturnMapInfoPointError(infrastructureModelRet.Error);

                        InfrastructureModel infrastructureModelRet3 = InfrastructureTVItemLinkPolylineUpdateDB(infrastructureModel, tvType, (float)mapInfoPointModelToChangeList[0].Lat, (float)mapInfoPointModelToChangeList[0].Lng);
                        if (!string.IsNullOrWhiteSpace(infrastructureModelRet3.Error))
                            return ReturnMapInfoPointError(infrastructureModelRet3.Error);
                    }
                }
            }

            return mapInfoPointModel;
        }
        public MapInfoPointModel PostMapDeleteLabelDB(int MapInfoID, float Lat, float Lng)
        {
            if (MapInfoID == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoID));

            string retStr = FieldCheckNotNullAndWithinRangeDouble((double)Lat, ServiceRes.Lat, -90, 90);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMapInfoPointError(retStr);

            retStr = FieldCheckNotNullAndWithinRangeDouble((double)Lng, ServiceRes.Lng, -180, 180);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMapInfoPointError(retStr);

            MapInfoModel mapInfoModel = GetMapInfoModelWithMapInfoIDDB(MapInfoID);
            if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                return ReturnMapInfoPointError(mapInfoModel.Error);

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(mapInfoModel.TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return ReturnMapInfoPointError(tvItemModel.Error);

            List<MapInfoPointModel> mapInfoPointModelToChangeList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mapInfoModel.TVItemID, mapInfoModel.TVType, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelToChangeList.Count == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.MapInfoPoint));

            if (mapInfoPointModelToChangeList.Count == 2)
            {
                MapInfoPointModel mapInfoPointModelLabelRet = _MapInfoPointService.PostDeleteMapInfoPointDB(mapInfoPointModelToChangeList[1].MapInfoPointID);
                if (!string.IsNullOrWhiteSpace(mapInfoPointModelLabelRet.Error))
                    return ReturnMapInfoPointError(mapInfoPointModelLabelRet.Error);

            }

            mapInfoPointModelToChangeList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mapInfoModel.TVItemID, mapInfoModel.TVType, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelToChangeList.Count == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.MapInfoPoint));

            if (mapInfoPointModelToChangeList.Count != 1)
            {
                return ReturnMapInfoPointError(string.Format(ServiceRes.MapInfoPointListShouldHave_Values, 1));
            }

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDB(mapInfoPointModelToChangeList[0].MapInfoID);
            if (mapInfoPointModelList.Count == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint));

            mapInfoModel = GetMapInfoModelWithMapInfoIDDB(mapInfoPointModelToChangeList[0].MapInfoID);
            if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                return ReturnMapInfoPointError(mapInfoModel.Error);

            mapInfoModel.LatMin = (float)((from c in mapInfoPointModelList select c.Lat).Min() - 0.001f);
            mapInfoModel.LatMax = (float)((from c in mapInfoPointModelList select c.Lat).Max() + 0.001f);
            mapInfoModel.LngMin = (float)((from c in mapInfoPointModelList select c.Lng).Min() - 0.001f);
            mapInfoModel.LngMax = (float)((from c in mapInfoPointModelList select c.Lng).Max() + 0.001f);

            MapInfoModel mapInfoModelRet = PostUpdateMapInfoDB(mapInfoModel);
            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                return ReturnMapInfoPointError(mapInfoModelRet.Error);

            if (mapInfoModel.TVType == TVTypeEnum.Outfall
                || mapInfoModel.TVType == TVTypeEnum.WasteWaterTreatmentPlant
                || mapInfoModel.TVType == TVTypeEnum.LiftStation
                || mapInfoModel.TVType == TVTypeEnum.OtherInfrastructure
                || mapInfoModel.TVType == TVTypeEnum.SeeOtherMunicipality
                || mapInfoModel.TVType == TVTypeEnum.LineOverflow
                )
            {

                InfrastructureModel infrastructureModel = GetInfrastructureModelWithInfrastructureTVItemIDDB(mapInfoModel.TVItemID);
                TVTypeEnum tvType = TVTypeEnum.Error;
                switch (infrastructureModel.InfrastructureType)
                {
                    case InfrastructureTypeEnum.LiftStation:
                        {
                            tvType = TVTypeEnum.LiftStation;
                        }
                        break;
                    case InfrastructureTypeEnum.WWTP:
                        {
                            tvType = TVTypeEnum.WasteWaterTreatmentPlant;
                        }
                        break;
                    case InfrastructureTypeEnum.LineOverflow:
                        {
                            tvType = TVTypeEnum.LineOverflow;
                        }
                        break;
                    case InfrastructureTypeEnum.Other:
                        {
                            tvType = TVTypeEnum.OtherInfrastructure;
                        }
                        break;
                    case InfrastructureTypeEnum.SeeOtherMunicipality:
                        {
                            tvType = TVTypeEnum.SeeOtherMunicipality;
                        }
                        break;
                    default:
                        break;
                }

                if (mapInfoModel.TVType == TVTypeEnum.Outfall)
                {
                    List<MapInfoPointModel> mapInfoPointModelInfrastructureList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mapInfoModel.TVItemID, tvType, MapInfoDrawTypeEnum.Point);

                    if (mapInfoPointModelInfrastructureList.Count > 0)
                    {
                        InfrastructureModel infrastructureModelRet = InfrastructureCoordinateUpdateDB(infrastructureModel, tvType, (float)mapInfoPointModelInfrastructureList[0].Lat, (float)mapInfoPointModelInfrastructureList[0].Lng, (float?)mapInfoPointModelToChangeList[0].Lat, (float?)mapInfoPointModelToChangeList[0].Lng);
                        if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                            return ReturnMapInfoPointError(infrastructureModelRet.Error);

                        InfrastructureModel infrastructureModelRet3 = InfrastructureTVItemLinkPolylineUpdateDB(infrastructureModel, tvType, (float)mapInfoPointModelInfrastructureList[0].Lat, (float)mapInfoPointModelInfrastructureList[0].Lng);
                        if (!string.IsNullOrWhiteSpace(infrastructureModelRet3.Error))
                            return ReturnMapInfoPointError(infrastructureModelRet3.Error);
                    }
                }
                else
                {
                    List<MapInfoPointModel> mapInfoPointModelInfrastructureList = _MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mapInfoModel.TVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Point);

                    if (mapInfoPointModelInfrastructureList.Count > 0)
                    {
                        InfrastructureModel infrastructureModelRet = InfrastructureCoordinateUpdateDB(infrastructureModel, tvType, (float)mapInfoPointModelToChangeList[0].Lat, (float)mapInfoPointModelToChangeList[0].Lng, (float)mapInfoPointModelInfrastructureList[0].Lat, (float)mapInfoPointModelInfrastructureList[0].Lng);
                        if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                            return ReturnMapInfoPointError(infrastructureModelRet.Error);

                        InfrastructureModel infrastructureModelRet3 = InfrastructureTVItemLinkPolylineUpdateDB(infrastructureModel, tvType, (float)mapInfoPointModelToChangeList[0].Lat, (float)mapInfoPointModelToChangeList[0].Lng);
                        if (!string.IsNullOrWhiteSpace(infrastructureModelRet3.Error))
                            return ReturnMapInfoPointError(infrastructureModelRet3.Error);
                    }
                }
            }

            return mapInfoPointModelList[0];
        }
        public MapInfoPointModel PostMapMoveLabelAutoDB(int SubsectorTVItemID, int TVType, bool OnlyActive)
        {
            List<LabelPosition> LabelPositionList = new List<LabelPosition>();

            if (SubsectorTVItemID == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoID));

            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return ReturnMapInfoPointError(tvItemModelSubsector.Error);

            if (!(TVType == (int)TVTypeEnum.MWQMSite || TVType == (int)TVTypeEnum.PolSourceSite))
            {
                return ReturnMapInfoPointError(string.Format(ServiceRes.TVTypeNeedsToBeOneOf_, "[" + TVTypeEnum.MWQMSite.ToString() + "," + TVTypeEnum.PolSourceSite.ToString() + "]"));
            }

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithParentIDAndTVTypeAndMapInfoDrawTypeDB(SubsectorTVItemID, (TVTypeEnum)TVType, MapInfoDrawTypeEnum.Point);

            if (mapInfoPointModelList.Count == 0)
            {
                return ReturnMapInfoPointError(string.Format(ServiceRes.CouldNotFindAny_, ServiceRes.MapInfoPoint));
            }

            List<int> MapInfoIDList = (from c in mapInfoPointModelList
                                       orderby c.MapInfoID
                                       select c.MapInfoID).Distinct().ToList();

            foreach (int MapInfoID in MapInfoIDList)
            {
                List<MapInfoPointModel> mapInfoPointModelList2 = (from c in mapInfoPointModelList
                                                                  where c.MapInfoID == MapInfoID
                                                                  select c).ToList();

                if (mapInfoPointModelList2.Count > 3)
                {
                    return ReturnMapInfoPointError(ServiceRes.MapInfoPointForPointShouldNeverHaveMoreThan2Points);
                }

                // need to delete all Label position i.e. point with ordinal == 1
                if (mapInfoPointModelList2.Count == 2)
                {
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList2)
                    {
                        if (mapInfoPointModel.Ordinal == 1)
                        {
                            MapInfoPointModel mapInfoPointModelRet = _MapInfoPointService.PostDeleteMapInfoPointDB(mapInfoPointModel.MapInfoPointID);
                            if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                                return ReturnMapInfoPointError(mapInfoPointModelRet.Error);
                        }

                    }
                }
            }

            float LabelHeight = 18.0f;
            float LabelWidth = 30.0f;
            float StepSize = 5.0f;

            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
            {
                LabelPosition labelPosition = new LabelPosition()
                {
                    SitePoint = new Coord() { Lat = (float)mapInfoPointModel.Lat, Lng = (float)mapInfoPointModel.Lng, Ordinal = 0 },
                    LabelPoint = new Coord() { Lat = (float)mapInfoPointModel.Lat - 1, Lng = (float)mapInfoPointModel.Lng + 1, Ordinal = 0 },
                    LabelNorthEast = new Coord() { Lat = (float)mapInfoPointModel.Lat - LabelHeight, Lng = (float)mapInfoPointModel.Lng + LabelWidth, Ordinal = 0 },
                    LabelSouthWest = new Coord() { Lat = (float)mapInfoPointModel.Lat - 1, Lng = (float)mapInfoPointModel.Lng + 1, Ordinal = 0 },
                    Position = PositionEnum.LeftBottom,
                    Distance = 0.0f,
                    Ordinal = LabelPositionList.Count(),
                    MapInfoPointModel = mapInfoPointModel,
                };
                LabelPositionList.Add(labelPosition);
            }

            RedrawPointsAndLabels(LabelPositionList, LabelHeight, LabelWidth, StepSize);

            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
            {
                LabelPosition labelPosition = LabelPositionList.Where(c => c.MapInfoPointModel.MapInfoID == mapInfoPointModel.MapInfoID).FirstOrDefault();
                if (labelPosition == null)
                {
                    return ReturnMapInfoPointError(string.Format(ServiceRes.CouldNotFind_With_Equal_, "LabelPosition", "mapInfoPointModel.MapInfoID", mapInfoPointModel.MapInfoID.ToString()));
                }

                MapInfoPointModel mapInfoPointModelNew = new MapInfoPointModel()
                {
                    MapInfoID = mapInfoPointModel.MapInfoID,
                    Lat = labelPosition.LabelPoint.Lat,
                    Lng = labelPosition.LabelPoint.Lng,
                    Ordinal = 1,
                };

                MapInfoPointModel mapInfoPointModelRet = _MapInfoPointService.PostAddMapInfoPointDB(mapInfoPointModelNew);
                if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                    return ReturnMapInfoPointError(mapInfoPointModelRet.Error);
            }

            return mapInfoPointModelList[0];
        }
        public MapInfoPointModel PostMapMoveLabelClearDB(int SubsectorTVItemID, int TVType, bool OnlyActive)
        {
            List<LabelPosition> LabelPositionList = new List<LabelPosition>();

            if (SubsectorTVItemID == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoID));

            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return ReturnMapInfoPointError(tvItemModelSubsector.Error);

            if (!(TVType == (int)TVTypeEnum.MWQMSite || TVType == (int)TVTypeEnum.PolSourceSite))
            {
                return ReturnMapInfoPointError(string.Format(ServiceRes.TVTypeNeedsToBeOneOf_, "[" + TVTypeEnum.MWQMSite.ToString() + "," + TVTypeEnum.PolSourceSite.ToString() + "]"));
            }

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithParentIDAndTVTypeAndMapInfoDrawTypeDB(SubsectorTVItemID, (TVTypeEnum)TVType, MapInfoDrawTypeEnum.Point);

            if (mapInfoPointModelList.Count == 0)
            {
                return ReturnMapInfoPointError(string.Format(ServiceRes.CouldNotFindAny_, ServiceRes.MapInfoPoint));
            }

            List<int> MapInfoIDList = (from c in mapInfoPointModelList
                                       orderby c.MapInfoID
                                       select c.MapInfoID).Distinct().ToList();

            foreach (int MapInfoID in MapInfoIDList)
            {
                List<MapInfoPointModel> mapInfoPointModelList2 = (from c in mapInfoPointModelList
                                                                  where c.MapInfoID == MapInfoID
                                                                  select c).ToList();

                if (mapInfoPointModelList2.Count > 3)
                {
                    return ReturnMapInfoPointError(ServiceRes.MapInfoPointForPointShouldNeverHaveMoreThan2Points);
                }

                // need to delete all Label position i.e. point with ordinal == 1
                if (mapInfoPointModelList2.Count == 2)
                {
                    foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList2)
                    {
                        if (mapInfoPointModel.Ordinal == 1)
                        {
                            MapInfoPointModel mapInfoPointModelRet = _MapInfoPointService.PostDeleteMapInfoPointDB(mapInfoPointModel.MapInfoPointID);
                            if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                                return ReturnMapInfoPointError(mapInfoPointModelRet.Error);
                        }

                    }
                }
            }

            return mapInfoPointModelList[0];
        }
        public MapInfoModel PostSavePolyDB(string LatLngListText, int MapInfoID)
        {
            if (MapInfoID == 0)
                return ReturnMapInfoError(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoID));

            if (string.IsNullOrEmpty(LatLngListText))
                return ReturnMapInfoError(string.Format(ServiceRes._IsRequired, ServiceRes.LatLngListText));

            if (!LatLngListText.Contains("s"))
                return ReturnMapInfoError(ServiceRes.LatLngListTextShouldContainTheLetterSToSeparateLatLng);

            if (!LatLngListText.Contains("p"))
                return ReturnMapInfoError(ServiceRes.LatLngListTextShouldContainTheLetterSToSeparatePoints);

            List<LatLng> LatLngList = new List<LatLng>();

            string[] LatLngTxtArr = LatLngListText.Split("p".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in LatLngTxtArr)
            {
                string[] LatLngTxt = s.Split("s".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (LatLngTxt.Length == 2)
                {
                    if (LanguageRequest == LanguageEnum.fr)
                    {
                        LatLngList.Add(new LatLng() { Lat = float.Parse(LatLngTxt[0].Replace(".", ",")), Lng = float.Parse(LatLngTxt[1].Replace(".", ",")) });
                    }
                    else
                    {
                        LatLngList.Add(new LatLng() { Lat = float.Parse(LatLngTxt[0]), Lng = float.Parse(LatLngTxt[1]) });
                    }
                }
            }

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDB(MapInfoID);
            if (mapInfoPointModelList.Count == 0)
                return ReturnMapInfoError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint));

            MapInfoModel mapInfoModel = GetMapInfoModelWithMapInfoIDDB(MapInfoID);
            if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                return ReturnMapInfoError(mapInfoModel.Error);

            if (mapInfoModel.MapInfoDrawType == MapInfoDrawTypeEnum.Polyline)
                if (LatLngList.Count < 2)
                    return ReturnMapInfoError(ServiceRes.PolylinesShouldContainAtLeast2Points);

            if (mapInfoModel.MapInfoDrawType == MapInfoDrawTypeEnum.Polygon)
                if (LatLngList.Count < 4)
                    return ReturnMapInfoError(ServiceRes.PolygonsShouldContainAtLeast4Points);

            int mapInfoPointCount = mapInfoPointModelList.Count;

            if (mapInfoPointCount >= LatLngList.Count)
            {
                for (int i = 0, Count = mapInfoPointCount; i < Count; i++)
                {
                    if (i < LatLngList.Count)
                    {
                        mapInfoPointModelList[i].Lat = LatLngList[i].Lat;
                        mapInfoPointModelList[i].Lng = LatLngList[i].Lng;
                        mapInfoPointModelList[i].Ordinal = i;
                        MapInfoPointModel mapInfoPointModel = _MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[i]);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModel.Error))
                            return ReturnMapInfoError(mapInfoPointModel.Error);
                    }
                    else
                    {
                        MapInfoPointModel mapInfoPointModel = _MapInfoPointService.PostDeleteMapInfoPointDB(mapInfoPointModelList[i].MapInfoPointID);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModel.Error))
                            return ReturnMapInfoError(mapInfoPointModel.Error);
                    }
                }
            }
            else
            {
                for (int i = 0, Count = LatLngList.Count; i < Count; i++)
                {
                    if (i < mapInfoPointCount)
                    {
                        mapInfoPointModelList[i].Lat = LatLngList[i].Lat;
                        mapInfoPointModelList[i].Lng = LatLngList[i].Lng;
                        mapInfoPointModelList[i].Ordinal = i;
                        MapInfoPointModel mapInfoPointModel = _MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[i]);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModel.Error))
                            return ReturnMapInfoError(mapInfoPointModel.Error);
                    }
                    else
                    {
                        MapInfoPointModel mapInfoPointModelNew = new MapInfoPointModel();
                        mapInfoPointModelNew.Lat = LatLngList[i].Lat;
                        mapInfoPointModelNew.Lng = LatLngList[i].Lng;
                        mapInfoPointModelNew.MapInfoID = MapInfoID;
                        mapInfoPointModelNew.Ordinal = i;

                        MapInfoPointModel mapInfoPointModel = _MapInfoPointService.PostAddMapInfoPointDB(mapInfoPointModelNew);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModel.Error))
                            return ReturnMapInfoError(mapInfoPointModel.Error);
                    }
                }
            }

            mapInfoPointModelList = _MapInfoPointService.GetMapInfoPointModelListWithMapInfoIDDB(MapInfoID);
            if (mapInfoPointModelList.Count == 0)
                return ReturnMapInfoError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint));

            mapInfoModel.LatMin = (float)((from c in mapInfoPointModelList select c.Lat).Min() - 0.001f);
            mapInfoModel.LatMax = (float)((from c in mapInfoPointModelList select c.Lat).Max() + 0.001f);
            mapInfoModel.LngMin = (float)((from c in mapInfoPointModelList select c.Lng).Min() - 0.001f);
            mapInfoModel.LngMax = (float)((from c in mapInfoPointModelList select c.Lng).Max() + 0.001f);

            MapInfoModel mapInfoModelRet = PostUpdateMapInfoDB(mapInfoModel);
            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                return ReturnMapInfoError(mapInfoModelRet.Error);

            return mapInfoModelRet;
        }
        public MapInfoModel PostUpdateMapInfoDB(MapInfoModel mapInfoModel)
        {
            string retStr = MapInfoModelOK(mapInfoModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MapInfo mapInfoToUpdate = GetMapInfoWithMapInfoIDDB(mapInfoModel.MapInfoID);
            if (mapInfoToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MapInfo));

            retStr = FillMapInfo(mapInfoToUpdate, mapInfoModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MapInfos", mapInfoToUpdate.MapInfoID, LogCommandEnum.Change, mapInfoToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMapInfoModelWithMapInfoIDDB(mapInfoToUpdate.MapInfoID);
        }
        public MapInfoModel ResetDrainageAreaWithTVItemIDWillCreatePolygonIfItDoesNotExistDB(FormCollection fc)
        {
            int MikeSourceTVItemID = int.Parse(fc["MikeSourceTVItemID"]);
            string KMLDrainageArea = fc["KMLDrainageArea"];
            KMLDrainageArea = KMLDrainageArea.Replace("|||", "<");

            MapInfoModel mapInfoModel = new MapInfoModel() { Error = ServiceRes.CouldNotFindCoordinates };
            List<Coord> coordList = new List<Coord>();

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.LoadXml(KMLDrainageArea);
            }
            catch (Exception)
            {
                return mapInfoModel;
            }

            foreach (XmlNode node in doc.ChildNodes)
            {
                coordList = GetCoordinates(node);
                if (coordList.Count > 0)
                {
                    List<MapInfoModel> mapInfoModelList = GetMapInfoModelListWithTVItemIDDB(MikeSourceTVItemID);

                    foreach (MapInfoModel mapInfoModelTemp in mapInfoModelList)
                    {
                        if (mapInfoModelTemp.MapInfoDrawType == MapInfoDrawTypeEnum.Polygon)
                        {
                            MapInfoModel mapInfoModelRet = PostDeleteMapInfoDB(mapInfoModelTemp.MapInfoID);
                            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                            {
                                return mapInfoModel;
                            }
                        }
                    }
                    
                    mapInfoModel = CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polygon, TVTypeEnum.MikeSource, MikeSourceTVItemID);
                    break;
                }
            }

            return mapInfoModel;
        }
        #endregion Function public

        #region Function private
        private void RedrawPointsAndLabels(List<LabelPosition> LabelPositionList, float LabelHeight, float LabelWidth, float StepSize)
        {
            Coord AverageCoord = new Coord() { Lat = 0.0f, Lng = 0.0f, Ordinal = 0 };

            if (LabelPositionList.Count > 0)
            {
                AverageCoord = new Coord() { Lat = LabelPositionList.Average(c => c.SitePoint.Lat), Lng = LabelPositionList.Average(c => c.SitePoint.Lng), Ordinal = 0 };

                foreach (LabelPosition labelPosition in LabelPositionList)
                {
                    labelPosition.LabelPoint = labelPosition.SitePoint;
                    labelPosition.Distance = (float)Math.Sqrt((labelPosition.SitePoint.Lng - AverageCoord.Lng) * (labelPosition.SitePoint.Lng - AverageCoord.Lng) + (labelPosition.SitePoint.Lat - AverageCoord.Lat) * (labelPosition.SitePoint.Lat - AverageCoord.Lat));

                    if ((labelPosition.SitePoint.Lng - AverageCoord.Lng) >= 0 && (labelPosition.SitePoint.Lat - AverageCoord.Lat) <= 0) // first quartier
                    {
                        labelPosition.LabelSouthWest = new Coord() { Lat = labelPosition.SitePoint.Lat - 1, Lng = labelPosition.SitePoint.Lng + 1, Ordinal = 0 };
                        labelPosition.LabelNorthEast = new Coord() { Lat = labelPosition.SitePoint.Lat - LabelHeight - 1, Lng = labelPosition.SitePoint.Lng + LabelWidth + 1, Ordinal = 0 };
                        labelPosition.Position = PositionEnum.LeftBottom;
                    }
                    else if ((labelPosition.SitePoint.Lng - AverageCoord.Lng) > 0 && (labelPosition.SitePoint.Lat - AverageCoord.Lat) > 0) // second quartier
                    {
                        labelPosition.LabelSouthWest = new Coord() { Lat = labelPosition.SitePoint.Lat + LabelHeight + 1, Lng = labelPosition.SitePoint.Lng + 1, Ordinal = 0 };
                        labelPosition.LabelNorthEast = new Coord() { Lat = labelPosition.SitePoint.Lat - 1, Lng = labelPosition.SitePoint.Lng + LabelWidth + 1, Ordinal = 0 };
                        labelPosition.Position = PositionEnum.LeftTop;
                    }
                    else if ((labelPosition.SitePoint.Lng - AverageCoord.Lng) < 0 && (labelPosition.SitePoint.Lat - AverageCoord.Lat) > 0) // third quartier
                    {
                        labelPosition.LabelSouthWest = new Coord() { Lat = labelPosition.SitePoint.Lat + LabelHeight + 1, Lng = labelPosition.SitePoint.Lng - LabelWidth - 1, Ordinal = 0 };
                        labelPosition.LabelNorthEast = new Coord() { Lat = labelPosition.SitePoint.Lat + 1, Lng = labelPosition.SitePoint.Lng + 1, Ordinal = 0 };
                        labelPosition.Position = PositionEnum.RightTop;
                    }
                    else // forth quartier
                    {
                        labelPosition.LabelSouthWest = new Coord() { Lat = labelPosition.SitePoint.Lat - 1, Lng = labelPosition.SitePoint.Lng - LabelWidth - 1, Ordinal = 0 };
                        labelPosition.LabelNorthEast = new Coord() { Lat = labelPosition.SitePoint.Lat - LabelHeight - 1, Lng = labelPosition.SitePoint.Lng - 1, Ordinal = 0 };
                        labelPosition.Position = PositionEnum.RightBottom;
                    }
                }
                foreach (LabelPosition labelPosition in LabelPositionList.OrderBy(c => c.Distance))
                {
                    bool HidingPoint = true;
                    while (HidingPoint)
                    {
                        List<Coord> coordList = new List<Coord>()
                        {
                            new Coord() { Lat = labelPosition.LabelSouthWest.Lat, Lng = labelPosition.LabelSouthWest.Lng, Ordinal = 0 },
                            new Coord() { Lat = labelPosition.LabelSouthWest.Lat, Lng = labelPosition.LabelNorthEast.Lng, Ordinal = 0 },
                            new Coord() { Lat = labelPosition.LabelNorthEast.Lat, Lng = labelPosition.LabelNorthEast.Lng, Ordinal = 0 },
                            new Coord() { Lat = labelPosition.LabelNorthEast.Lat, Lng = labelPosition.LabelSouthWest.Lng, Ordinal = 0 },
                        };

                        bool PleaseRedo = false;
                        foreach (LabelPosition labelPosition2 in LabelPositionList.Where(c => c.Ordinal != labelPosition.Ordinal))
                        {
                            Coord coord = new Coord()
                            {
                                Lat = labelPosition2.LabelPoint.Lat,
                                Lng = labelPosition2.LabelPoint.Lng,
                                Ordinal = 0,
                            };
                            if (CoordInPolygon(coordList, coord))
                            {
                                float XNew = StepSize;
                                float YNew = StepSize;
                                float dist = (float)Math.Sqrt((AverageCoord.Lat - labelPosition.SitePoint.Lat) * (AverageCoord.Lat - labelPosition.SitePoint.Lat) + (AverageCoord.Lng - labelPosition.SitePoint.Lng) * (AverageCoord.Lng - labelPosition.SitePoint.Lng));
                                float factor = dist / StepSize;
                                float deltX = Math.Abs((AverageCoord.Lng - labelPosition.LabelPoint.Lng) / factor);
                                float deltY = Math.Abs((AverageCoord.Lat - labelPosition.LabelPoint.Lat) / factor);
                                switch (labelPosition.Position)
                                {
                                    case PositionEnum.Error:
                                        break;
                                    case PositionEnum.LeftBottom:
                                        {
                                            XNew = labelPosition.LabelPoint.Lng + deltX;
                                            YNew = labelPosition.LabelPoint.Lat - deltY;
                                            labelPosition.LabelSouthWest = new Coord() { Lat = YNew, Lng = XNew, Ordinal = 0 };
                                            labelPosition.LabelNorthEast = new Coord() { Lat = YNew - LabelHeight, Lng = XNew + LabelWidth, Ordinal = 0 };
                                        }
                                        break;
                                    case PositionEnum.RightBottom:
                                        {
                                            XNew = labelPosition.LabelPoint.Lng - deltX;
                                            YNew = labelPosition.LabelPoint.Lat - deltY;
                                            labelPosition.LabelSouthWest = new Coord() { Lat = YNew, Lng = XNew - LabelWidth, Ordinal = 0 };
                                            labelPosition.LabelNorthEast = new Coord() { Lat = YNew - LabelHeight, Lng = XNew, Ordinal = 0 };
                                        }
                                        break;
                                    case PositionEnum.LeftTop:
                                        {
                                            XNew = labelPosition.LabelPoint.Lng + deltX;
                                            YNew = labelPosition.LabelPoint.Lat + deltY;
                                            labelPosition.LabelSouthWest = new Coord() { Lat = YNew + LabelHeight, Lng = XNew, Ordinal = 0 };
                                            labelPosition.LabelNorthEast = new Coord() { Lat = YNew, Lng = XNew + LabelWidth, Ordinal = 0 };
                                        }
                                        break;
                                    case PositionEnum.RightTop:
                                        {
                                            XNew = labelPosition.LabelPoint.Lng - deltX;
                                            YNew = labelPosition.LabelPoint.Lat + deltY;
                                            labelPosition.LabelSouthWest = new Coord() { Lat = YNew + LabelHeight, Lng = XNew - LabelWidth, Ordinal = 0 };
                                            labelPosition.LabelNorthEast = new Coord() { Lat = YNew, Lng = XNew, Ordinal = 0 };
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                labelPosition.LabelPoint = new Coord() { Lat = YNew, Lng = XNew, Ordinal = 0 };
                                PleaseRedo = true;
                                break;
                            }
                        }
                        if (!PleaseRedo)
                        {
                            HidingPoint = false;
                        }
                    }

                    HidingPoint = true;
                    while (HidingPoint)
                    {
                        List<Coord> coordList = new List<Coord>()
                        {
                            new Coord() { Lat = labelPosition.LabelSouthWest.Lat, Lng = labelPosition.LabelSouthWest.Lng, Ordinal = 0 },
                            new Coord() { Lat = labelPosition.LabelSouthWest.Lat, Lng = labelPosition.LabelNorthEast.Lng, Ordinal = 0 },
                            new Coord() { Lat = labelPosition.LabelNorthEast.Lat, Lng = labelPosition.LabelNorthEast.Lng, Ordinal = 0 },
                            new Coord() { Lat = labelPosition.LabelNorthEast.Lat, Lng = labelPosition.LabelSouthWest.Lng, Ordinal = 0 },
                        };

                        bool PleaseRedo = false;
                        foreach (LabelPosition labelPosition2 in LabelPositionList.Where(c => c.Ordinal != labelPosition.Ordinal && c.Distance <= labelPosition.Distance))
                        {
                            List<Coord> coordToCompare = new List<Coord>()
                            {
                                new Coord() { Lat = labelPosition2.LabelSouthWest.Lat, Lng = labelPosition2.LabelSouthWest.Lng, Ordinal = 0 },
                                new Coord() { Lat = labelPosition2.LabelSouthWest.Lat, Lng = labelPosition2.LabelNorthEast.Lng, Ordinal = 0 },
                                new Coord() { Lat = labelPosition2.LabelNorthEast.Lat, Lng = labelPosition2.LabelNorthEast.Lng, Ordinal = 0 },
                                new Coord() { Lat = labelPosition2.LabelNorthEast.Lat, Lng = labelPosition2.LabelSouthWest.Lng, Ordinal = 0 },
                            };
                            for (int i = 0; i < 4; i++)
                            {
                                if (CoordInPolygon(coordList, coordToCompare[i]))
                                {
                                    float XNew = StepSize;
                                    float YNew = StepSize;
                                    float dist = (float)Math.Sqrt((AverageCoord.Lat - labelPosition.SitePoint.Lat) * (AverageCoord.Lat - labelPosition.SitePoint.Lat) + (AverageCoord.Lng - labelPosition.SitePoint.Lng) * (AverageCoord.Lng - labelPosition.SitePoint.Lng));
                                    float factor = dist / StepSize;
                                    float deltX = Math.Abs((AverageCoord.Lng - labelPosition.LabelPoint.Lng) / factor);
                                    float deltY = Math.Abs((AverageCoord.Lat - labelPosition.LabelPoint.Lat) / factor);
                                    switch (labelPosition.Position)
                                    {
                                        case PositionEnum.Error:
                                            break;
                                        case PositionEnum.LeftBottom:
                                            {
                                                XNew = labelPosition.LabelPoint.Lng + deltX;
                                                YNew = labelPosition.LabelPoint.Lat - deltY;
                                                labelPosition.LabelSouthWest = new Coord() { Lat = YNew, Lng = XNew, Ordinal = 0 };
                                                labelPosition.LabelNorthEast = new Coord() { Lat = YNew - LabelHeight, Lng = XNew + LabelWidth, Ordinal = 0 };
                                            }
                                            break;
                                        case PositionEnum.RightBottom:
                                            {
                                                XNew = labelPosition.LabelPoint.Lng - deltX;
                                                YNew = labelPosition.LabelPoint.Lat - deltY;
                                                labelPosition.LabelSouthWest = new Coord() { Lat = YNew, Lng = XNew - LabelWidth, Ordinal = 0 };
                                                labelPosition.LabelNorthEast = new Coord() { Lat = YNew - LabelHeight, Lng = XNew, Ordinal = 0 };
                                            }
                                            break;
                                        case PositionEnum.LeftTop:
                                            {
                                                XNew = labelPosition.LabelPoint.Lng + deltX;
                                                YNew = labelPosition.LabelPoint.Lat + deltY;
                                                labelPosition.LabelSouthWest = new Coord() { Lat = YNew + LabelHeight, Lng = XNew, Ordinal = 0 };
                                                labelPosition.LabelNorthEast = new Coord() { Lat = YNew, Lng = XNew + LabelWidth, Ordinal = 0 };
                                            }
                                            break;
                                        case PositionEnum.RightTop:
                                            {
                                                XNew = labelPosition.LabelPoint.Lng - deltX;
                                                YNew = labelPosition.LabelPoint.Lat + deltY;
                                                labelPosition.LabelSouthWest = new Coord() { Lat = YNew + LabelHeight, Lng = XNew - LabelWidth, Ordinal = 0 };
                                                labelPosition.LabelNorthEast = new Coord() { Lat = YNew, Lng = XNew, Ordinal = 0 };
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    labelPosition.LabelPoint = new Coord() { Lat = YNew, Lng = XNew, Ordinal = 0 };
                                    PleaseRedo = true;
                                    break;
                                }
                                if (PleaseRedo)
                                {
                                    break;
                                }
                            }
                        }
                        if (!PleaseRedo)
                        {
                            HidingPoint = false;
                        }
                    }
                }
            }
        }
        private List<Coord> GetCoordinates(XmlNode node)
        {
            List<Coord> coordList = new List<Coord>();

            if (node.Name == "coordinates")
            {
                string coordNode = node.InnerText;
                string[] coordStr = node.InnerText.Trim().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                int Ordinal = 0;
                foreach (string cs in coordStr)
                {
                    string[] coordVal = cs.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    Coord c = new Coord() { Lng = float.Parse(coordVal[0]), Lat = float.Parse(coordVal[1]), Ordinal = Ordinal };
                    coordList.Add(c);
                    Ordinal += 1;
                }
            }

            if (coordList.Count > 0)
            {
                return coordList;
            }

            if (node.ChildNodes.Count > 0)
            {
                foreach (XmlNode nodeChild in node.ChildNodes)
                {
                    coordList = GetCoordinates(nodeChild);
                    if (coordList.Count > 0)
                    {
                        return coordList;
                    }
                }
            }

            return coordList;
        }
        #endregion Functions private
    }
}
