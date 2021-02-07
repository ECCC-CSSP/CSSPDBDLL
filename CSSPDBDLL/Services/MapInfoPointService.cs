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

namespace CSSPDBDLL.Services
{
    public class MapInfoPointService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public MapInfoPointService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _LogService = new LogService(LanguageRequest, User);
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

        // Check
        public string MapInfoPointModelOK(MapInfoPointModel mapInfoPointModel)
        {
            string retStr = FieldCheckNotZeroInt(mapInfoPointModel.MapInfoID, ServiceRes.MapInfoID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mapInfoPointModel.Lat, ServiceRes.Lat, -90, 90);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mapInfoPointModel.Lng, ServiceRes.Lng, -180, 180);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(mapInfoPointModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMapInfoPoint(MapInfoPoint mapInfoPoint, MapInfoPointModel mapInfoPointModel, ContactOK contactOK)
        {
            mapInfoPoint.DBCommand = (int)mapInfoPointModel.DBCommand;
            mapInfoPoint.MapInfoID = mapInfoPointModel.MapInfoID;
            mapInfoPoint.Ordinal = mapInfoPointModel.Ordinal;
            mapInfoPoint.Lat = mapInfoPointModel.Lat;
            mapInfoPoint.Lng = mapInfoPointModel.Lng;
            mapInfoPoint.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mapInfoPoint.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mapInfoPoint.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMapInfoPointModelCountDB()
        {
            return (from c in db.MapInfoPoints
                    select c).Count();
        }
        public List<MapInfoPointModel> GetMapInfoPointModelListWithMapInfoIDDB(int MapInfoID)
        {
            List<MapInfoPointModel> mapInfoPointModelList = (from mi in db.MapInfos
                                                             from mip in db.MapInfoPoints
                                                             where mi.MapInfoID == mip.MapInfoID
                                                             && mip.MapInfoID == MapInfoID
                                                             orderby mip.Ordinal
                                                             select new MapInfoPointModel
                                                             {
                                                                 Error = "",
                                                                 MapInfoPointID = mip.MapInfoPointID,
                                                                 DBCommand = (DBCommandEnum)mip.DBCommand,
                                                                 MapInfoID = mip.MapInfoID,
                                                                 Lat = mip.Lat,
                                                                 Lng = mip.Lng,
                                                                 Ordinal = mip.Ordinal,
                                                                 TVItemID = mi.TVItemID,
                                                                 LastUpdateDate_UTC = mip.LastUpdateDate_UTC,
                                                                 LastUpdateContactTVItemID = mip.LastUpdateContactTVItemID
                                                             }).ToList<MapInfoPointModel>();

            return mapInfoPointModelList;
        }
        public MapInfoPointModel GetMapInfoPointModelWithMapInfoPointIDDB(int MapInfoPointID)
        {
            MapInfoPointModel mapInfoPointModel = (from mi in db.MapInfos
                                                   from mip in db.MapInfoPoints
                                                   where mi.MapInfoID == mip.MapInfoID
                                                   && mip.MapInfoPointID == MapInfoPointID
                                                   select new MapInfoPointModel
                                                   {
                                                       Error = "",
                                                       MapInfoPointID = mip.MapInfoPointID,
                                                       DBCommand = (DBCommandEnum)mip.DBCommand,
                                                       MapInfoID = mip.MapInfoID,
                                                       Lat = mip.Lat,
                                                       Lng = mip.Lng,
                                                       Ordinal = mip.Ordinal,
                                                       TVItemID = mi.TVItemID,
                                                       LastUpdateDate_UTC = mip.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = mip.LastUpdateContactTVItemID
                                                   }).FirstOrDefault<MapInfoPointModel>();

            if (mapInfoPointModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MapInfoPoint, ServiceRes.MapInfoPointID, MapInfoPointID));

            return mapInfoPointModel;
        }
        public MapInfoPoint GetMapInfoPointWithMapInfoPointIDDB(int MapInfoPointID)
        {
            MapInfoPoint mapInfoPoint = (from c in db.MapInfoPoints
                                         where c.MapInfoPointID == MapInfoPointID
                                         select c).FirstOrDefault<MapInfoPoint>();

            return mapInfoPoint;
        }
        public List<MapInfoPointModel> GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(int TVItemID, TVTypeEnum TVType, MapInfoDrawTypeEnum mapInfoDrawType)
        {
            List<MapInfoPointModel> mapInfoPointModelList = (from mi in db.MapInfos
                                                             from mip in db.MapInfoPoints
                                                             where mi.MapInfoID == mip.MapInfoID
                                                             && mi.MapInfoDrawType == (int)mapInfoDrawType
                                                             && mi.TVType == (int)TVType
                                                             && mi.TVItemID == TVItemID
                                                             select new MapInfoPointModel
                                                             {
                                                                 Error = "",
                                                                 MapInfoPointID = mip.MapInfoPointID,
                                                                 DBCommand = (DBCommandEnum)mip.DBCommand,
                                                                 MapInfoID = mip.MapInfoID,
                                                                 Lat = mip.Lat,
                                                                 Lng = mip.Lng,
                                                                 Ordinal = mip.Ordinal,
                                                                 TVItemID = mi.TVItemID,
                                                                 LastUpdateDate_UTC = mip.LastUpdateDate_UTC,
                                                                 LastUpdateContactTVItemID = mip.LastUpdateContactTVItemID
                                                             }).ToList<MapInfoPointModel>();

            return mapInfoPointModelList;
        }
        public List<MapInfoPointModel> GetMapInfoPointModelListWithParentIDAndTVTypeAndMapInfoDrawTypeDB(int ParentID, TVTypeEnum TVType, MapInfoDrawTypeEnum mapInfoDrawType)
        {
            List<MapInfoPointModel> mapInfoPointModelList = (from mi in db.MapInfos
                                                             from mip in db.MapInfoPoints
                                                             from t in db.TVItems
                                                             where mi.TVItemID == t.TVItemID
                                                             && mi.MapInfoID == mip.MapInfoID
                                                             && mi.MapInfoDrawType == (int)mapInfoDrawType
                                                             && mi.TVType == (int)TVType
                                                             && t.ParentID == ParentID
                                                             select new MapInfoPointModel
                                                             {
                                                                 Error = "",
                                                                 MapInfoPointID = mip.MapInfoPointID,
                                                                 DBCommand = (DBCommandEnum)mip.DBCommand,
                                                                 MapInfoID = mi.MapInfoID,
                                                                 Lat = mip.Lat,
                                                                 Lng = mip.Lng,
                                                                 Ordinal = mip.Ordinal,
                                                                 TVItemID = t.TVItemID,
                                                                 LastUpdateDate_UTC = mip.LastUpdateDate_UTC,
                                                                 LastUpdateContactTVItemID = mip.LastUpdateContactTVItemID
                                                             }).ToList<MapInfoPointModel>();

            return mapInfoPointModelList;
        }

        // Helper
        public MapInfoPointModel ReturnError(string Error)
        {
            return new MapInfoPointModel() { Error = Error };
        }

        // Post
        public MapInfoPointModel PostAddMapInfoPointDB(MapInfoPointModel mapInfoPointModel)
        {
            string retStr = MapInfoPointModelOK(mapInfoPointModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MapInfoPoint mapInfoPointNew = new MapInfoPoint();
            retStr = FillMapInfoPoint(mapInfoPointNew, mapInfoPointModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MapInfoPoints.Add(mapInfoPointNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MapInfoPoints", mapInfoPointNew.MapInfoPointID, LogCommandEnum.Add, mapInfoPointNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMapInfoPointModelWithMapInfoPointIDDB(mapInfoPointNew.MapInfoPointID);
        }
        public MapInfoPointModel PostDeleteMapInfoPointDB(int MapInfoPointID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MapInfoPoint mapInfoPointToDelete = GetMapInfoPointWithMapInfoPointIDDB(MapInfoPointID);
            if (mapInfoPointToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MapInfoPoint));

            using (TransactionScope ts = new TransactionScope())
            {
                db.MapInfoPoints.Remove(mapInfoPointToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MapInfoPoints", mapInfoPointToDelete.MapInfoPointID, LogCommandEnum.Delete, mapInfoPointToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public MapInfoPointModel PostUpdateMapInfoPointDB(MapInfoPointModel mapInfoPointModel)
        {
            string retStr = MapInfoPointModelOK(mapInfoPointModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MapInfoPoint mapInfoPointToUpdate = GetMapInfoPointWithMapInfoPointIDDB(mapInfoPointModel.MapInfoPointID);
            if (mapInfoPointToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MapInfoPoint));

            retStr = FillMapInfoPoint(mapInfoPointToUpdate, mapInfoPointModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MapInfoPoints", mapInfoPointToUpdate.MapInfoPointID, LogCommandEnum.Change, mapInfoPointToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMapInfoPointModelWithMapInfoPointIDDB(mapInfoPointToUpdate.MapInfoPointID);
        }
        #endregion Function public

        #region Function private
        #endregion Functions private
    }
}
