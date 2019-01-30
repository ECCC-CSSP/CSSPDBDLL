using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using System.Collections.Generic;
using System;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class DrogueRunPositionService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public AppTaskService _AppTaskService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public LogService _LogService { get; private set; }
        public DrogueRunService _DrogueRunService { get; private set; }
        #endregion Properties

        #region Constructors
        public DrogueRunPositionService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
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
        public string DrogueRunPositionModelOK(DrogueRunPositionModel drogueRunPositionModel)
        {
            string retStr = FieldCheckNotZeroInt(drogueRunPositionModel.DrogueRunID, ServiceRes.DrogueRunID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(drogueRunPositionModel.Ordinal, ServiceRes.Ordinal, 0, 20000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(drogueRunPositionModel.StepLat, ServiceRes.StepLat, -90.0D, 90.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(drogueRunPositionModel.StepLng, ServiceRes.StepLng, -180.0D, 180.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(drogueRunPositionModel.StepDateTime_Local, ServiceRes.StepDateTime_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(drogueRunPositionModel.CalculatedSpeed_m_s, ServiceRes.CalculatedSpeed_m_s, 0.0D, 20.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(drogueRunPositionModel.CalculatedDirection_deg, ServiceRes.CalculatedDirection_deg, 0.0D, 20.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillDrogueRunPosition(DrogueRunPosition drogueRunPositionNew, DrogueRunPositionModel drogueRunPositionModel, ContactOK contactOK)
        {
            drogueRunPositionNew.DrogueRunID = drogueRunPositionModel.DrogueRunID;
            drogueRunPositionNew.Ordinal = drogueRunPositionModel.Ordinal;
            drogueRunPositionNew.StepLat = (int)drogueRunPositionModel.StepLat;
            drogueRunPositionNew.StepLng = drogueRunPositionModel.StepLng;
            drogueRunPositionNew.StepDateTime_Local = drogueRunPositionModel.StepDateTime_Local;
            drogueRunPositionNew.CalculatedSpeed_m_s = drogueRunPositionModel.CalculatedSpeed_m_s;
            drogueRunPositionNew.CalculatedDirection_deg = drogueRunPositionModel.CalculatedDirection_deg;
            drogueRunPositionNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                drogueRunPositionNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                drogueRunPositionNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetDrogueRunPositionModelCountDB()
        {
            int DrogueRunPositionModelCount = (from c in db.DrogueRunPositions
                                            select c).Count();

            return DrogueRunPositionModelCount;
        }
        public DrogueRunPositionModel GetDrogueRunPositionModelWithDrogueRunPositionIDDB(int DrogueRunPositionID)
        {
            DrogueRunPositionModel DrogueRunPositionModel = (from c in db.DrogueRunPositions
                                                       where c.DrogueRunPositionID == DrogueRunPositionID
                                                       select new DrogueRunPositionModel
                                                       {
                                                           Error = "",
                                                           DrogueRunPositionID = c.DrogueRunPositionID,
                                                           DrogueRunID = c.DrogueRunID,
                                                           Ordinal = c.Ordinal,
                                                           StepLat = c.StepLat,
                                                           StepLng = c.StepLng,
                                                           StepDateTime_Local = c.StepDateTime_Local,
                                                           CalculatedSpeed_m_s = c.CalculatedSpeed_m_s,
                                                           CalculatedDirection_deg = c.CalculatedDirection_deg,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<DrogueRunPositionModel>();

            if (DrogueRunPositionModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DrogueRunPosition, ServiceRes.DrogueRunPositionID, DrogueRunPositionID));

            return DrogueRunPositionModel;
        }
        public List<DrogueRunPositionModel> GetDrogueRunPositionModelListWithDrogueRunIDDB(int DrogueRunID)
        {
            List<DrogueRunPositionModel> DrogueRunPositionModelList = (from c in db.DrogueRunPositions
                                                                 where c.DrogueRunID == DrogueRunID
                                                                 orderby c.DrogueRunPositionID descending
                                                                 select new DrogueRunPositionModel
                                                                 {
                                                                     Error = "",
                                                                     DrogueRunPositionID = c.DrogueRunPositionID,
                                                                     DrogueRunID = c.DrogueRunID,
                                                                     Ordinal = c.Ordinal,
                                                                     StepLat = c.StepLat,
                                                                     StepLng = c.StepLng,
                                                                     StepDateTime_Local = c.StepDateTime_Local,
                                                                     CalculatedSpeed_m_s = c.CalculatedSpeed_m_s,
                                                                     CalculatedDirection_deg = c.CalculatedDirection_deg,
                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                 }).ToList<DrogueRunPositionModel>();

            return DrogueRunPositionModelList;
        }
        public DrogueRunPositionModel GetDrogueRunPositionModelExistDB(DrogueRunPositionModel droguePositionModel)
        {
            DrogueRunPositionModel DrogueRunPositionModel = (from c in db.DrogueRunPositions
                                                       where c.DrogueRunID == droguePositionModel.DrogueRunID
                                                       && c.Ordinal == droguePositionModel.Ordinal
                                                       && c.StepDateTime_Local == droguePositionModel.StepDateTime_Local
                                                       select new DrogueRunPositionModel
                                                       {
                                                           Error = "",
                                                           DrogueRunPositionID = c.DrogueRunPositionID,
                                                           DrogueRunID = c.DrogueRunID,
                                                           Ordinal = c.Ordinal,
                                                           StepLat = c.StepLat,
                                                           StepLng = c.StepLng,
                                                           StepDateTime_Local = c.StepDateTime_Local,
                                                           CalculatedSpeed_m_s = c.CalculatedSpeed_m_s,
                                                           CalculatedDirection_deg = c.CalculatedDirection_deg,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<DrogueRunPositionModel>();

            if (DrogueRunPositionModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DrogueRunPosition,
                    ServiceRes.DrogueRunID + "," +
                    ServiceRes.Ordinal + "," +
                    ServiceRes.StepDateTime_Local,
                    droguePositionModel.DrogueRunID + "," +
                    droguePositionModel.Ordinal + "," +
                    droguePositionModel.StepDateTime_Local));

            return DrogueRunPositionModel;
        }
        public DrogueRunPosition GetDrogueRunPositionWithDrogueRunPositionIDDB(int DrogueRunPositionID)
        {
            DrogueRunPosition DrogueRunPosition = (from c in db.DrogueRunPositions
                                             where c.DrogueRunPositionID == DrogueRunPositionID
                                             orderby c.DrogueRunPositionID descending
                                             select c).FirstOrDefault<DrogueRunPosition>();
            return DrogueRunPosition;
        }
        public DrogueRunPositionModel ReturnError(string Error)
        {
            return new DrogueRunPositionModel() { Error = Error };
        }

        // Post
        public DrogueRunPositionModel PostAddDrogueRunPositionDB(DrogueRunPositionModel droguePositionModel)
        {
            string retStr = DrogueRunPositionModelOK(droguePositionModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            DrogueRunModel drogueRunModelExist = _DrogueRunService.GetDrogueRunModelWithDrogueRunIDDB(droguePositionModel.DrogueRunID);
            if (!string.IsNullOrWhiteSpace(drogueRunModelExist.Error))
                return ReturnError(drogueRunModelExist.Error);

            DrogueRunPositionModel DrogueRunPositionModelExist = GetDrogueRunPositionModelExistDB(droguePositionModel);
            if (string.IsNullOrWhiteSpace(DrogueRunPositionModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.DrogueRunPosition));

            DrogueRunPosition droguePositionNew = new DrogueRunPosition();
            retStr = FillDrogueRunPosition(droguePositionNew, droguePositionModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.DrogueRunPositions.Add(droguePositionNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DrogueRunPositions", droguePositionNew.DrogueRunPositionID, LogCommandEnum.Add, droguePositionNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetDrogueRunPositionModelWithDrogueRunPositionIDDB(droguePositionNew.DrogueRunPositionID);
        }
        public DrogueRunPositionModel PostDeleteDrogueRunPositionDB(int DrogueRunPositionID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            DrogueRunPosition droguePositionToDelete = GetDrogueRunPositionWithDrogueRunPositionIDDB(DrogueRunPositionID);
            if (droguePositionToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.DrogueRunPosition));

            using (TransactionScope ts = new TransactionScope())
            {
                db.DrogueRunPositions.Remove(droguePositionToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DrogueRunPositions", droguePositionToDelete.DrogueRunPositionID, LogCommandEnum.Delete, droguePositionToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public DrogueRunPositionModel PostUpdateDrogueRunPositionDB(DrogueRunPositionModel droguePositionModel)
        {
            string retStr = DrogueRunPositionModelOK(droguePositionModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            DrogueRunPosition droguePositionToUpdate = GetDrogueRunPositionWithDrogueRunPositionIDDB(droguePositionModel.DrogueRunPositionID);
            if (droguePositionToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.DrogueRunPosition));

            retStr = FillDrogueRunPosition(droguePositionToUpdate, droguePositionModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DrogueRunPositions", droguePositionToUpdate.DrogueRunPositionID, LogCommandEnum.Change, droguePositionToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetDrogueRunPositionModelWithDrogueRunPositionIDDB(droguePositionToUpdate.DrogueRunPositionID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
