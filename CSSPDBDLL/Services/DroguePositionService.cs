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
    public class DroguePositionService : BaseService
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
        public DroguePositionService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string DroguePositionModelOK(DroguePositionModel droguePositionModel)
        {
            string retStr = FieldCheckNotZeroInt(droguePositionModel.DrogueRunID, ServiceRes.DrogueRunID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(droguePositionModel.Ordinal, ServiceRes.Ordinal, 0, 20000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(droguePositionModel.StepLat, ServiceRes.StepLat, -90.0D, 90.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(droguePositionModel.StepLng, ServiceRes.StepLng, -180.0D, 180.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(droguePositionModel.StepDateTime_Local, ServiceRes.StepDateTime_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(droguePositionModel.CalculatedSpeed_m_s, ServiceRes.CalculatedSpeed_m_s, 0.0D, 20.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(droguePositionModel.CalculatedDirection_deg, ServiceRes.CalculatedDirection_deg, 0.0D, 20.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillDroguePosition(DroguePosition droguePositionNew, DroguePositionModel droguePositionModel, ContactOK contactOK)
        {
            droguePositionNew.DrogueRunID = droguePositionModel.DrogueRunID;
            droguePositionNew.Ordinal = droguePositionModel.Ordinal;
            droguePositionNew.StepLat = (int)droguePositionModel.StepLat;
            droguePositionNew.StepLng = droguePositionModel.StepLng;
            droguePositionNew.StepDateTime_Local = droguePositionModel.StepDateTime_Local;
            droguePositionNew.CalculatedSpeed_m_s = droguePositionModel.CalculatedSpeed_m_s;
            droguePositionNew.CalculatedDirection_deg = droguePositionModel.CalculatedDirection_deg;
            droguePositionNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                droguePositionNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                droguePositionNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetDroguePositionModelCountDB()
        {
            int DroguePositionModelCount = (from c in db.DroguePositions
                                            select c).Count();

            return DroguePositionModelCount;
        }
        public DroguePositionModel GetDroguePositionModelWithDroguePositionIDDB(int DroguePositionID)
        {
            DroguePositionModel DroguePositionModel = (from c in db.DroguePositions
                                                       where c.DroguePositionID == DroguePositionID
                                                       select new DroguePositionModel
                                                       {
                                                           Error = "",
                                                           DroguePositionID = c.DroguePositionID,
                                                           DrogueRunID = c.DrogueRunID,
                                                           Ordinal = c.Ordinal,
                                                           StepLat = c.StepLat,
                                                           StepLng = c.StepLng,
                                                           StepDateTime_Local = c.StepDateTime_Local,
                                                           CalculatedSpeed_m_s = c.CalculatedSpeed_m_s,
                                                           CalculatedDirection_deg = c.CalculatedDirection_deg,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<DroguePositionModel>();

            if (DroguePositionModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DroguePosition, ServiceRes.DroguePositionID, DroguePositionID));

            return DroguePositionModel;
        }
        public List<DroguePositionModel> GetDroguePositionModelListWithDrogueRunIDDB(int DrogueRunID)
        {
            List<DroguePositionModel> DroguePositionModelList = (from c in db.DroguePositions
                                                                 where c.DrogueRunID == DrogueRunID
                                                                 orderby c.DroguePositionID descending
                                                                 select new DroguePositionModel
                                                                 {
                                                                     Error = "",
                                                                     DroguePositionID = c.DroguePositionID,
                                                                     DrogueRunID = c.DrogueRunID,
                                                                     Ordinal = c.Ordinal,
                                                                     StepLat = c.StepLat,
                                                                     StepLng = c.StepLng,
                                                                     StepDateTime_Local = c.StepDateTime_Local,
                                                                     CalculatedSpeed_m_s = c.CalculatedSpeed_m_s,
                                                                     CalculatedDirection_deg = c.CalculatedDirection_deg,
                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                 }).ToList<DroguePositionModel>();

            return DroguePositionModelList;
        }
        public DroguePositionModel GetDroguePositionModelExistDB(DroguePositionModel droguePositionModel)
        {
            DroguePositionModel DroguePositionModel = (from c in db.DroguePositions
                                                       where c.DrogueRunID == droguePositionModel.DrogueRunID
                                                       && c.Ordinal == droguePositionModel.Ordinal
                                                       && c.StepDateTime_Local == droguePositionModel.StepDateTime_Local
                                                       select new DroguePositionModel
                                                       {
                                                           Error = "",
                                                           DroguePositionID = c.DroguePositionID,
                                                           DrogueRunID = c.DrogueRunID,
                                                           Ordinal = c.Ordinal,
                                                           StepLat = c.StepLat,
                                                           StepLng = c.StepLng,
                                                           StepDateTime_Local = c.StepDateTime_Local,
                                                           CalculatedSpeed_m_s = c.CalculatedSpeed_m_s,
                                                           CalculatedDirection_deg = c.CalculatedDirection_deg,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<DroguePositionModel>();

            if (DroguePositionModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DroguePosition,
                    ServiceRes.DrogueRunID + "," +
                    ServiceRes.Ordinal + "," +
                    ServiceRes.StepDateTime_Local,
                    droguePositionModel.DrogueRunID + "," +
                    droguePositionModel.Ordinal + "," +
                    droguePositionModel.StepDateTime_Local));

            return DroguePositionModel;
        }
        public DroguePosition GetDroguePositionWithDroguePositionIDDB(int DroguePositionID)
        {
            DroguePosition DroguePosition = (from c in db.DroguePositions
                                             where c.DroguePositionID == DroguePositionID
                                             orderby c.DroguePositionID descending
                                             select c).FirstOrDefault<DroguePosition>();
            return DroguePosition;
        }
        public DroguePositionModel ReturnError(string Error)
        {
            return new DroguePositionModel() { Error = Error };
        }

        // Post
        public DroguePositionModel PostAddDroguePositionDB(DroguePositionModel droguePositionModel)
        {
            string retStr = DroguePositionModelOK(droguePositionModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            DrogueRunModel drogueRunModelExist = _DrogueRunService.GetDrogueRunModelWithDrogueRunIDDB(droguePositionModel.DrogueRunID);
            if (!string.IsNullOrWhiteSpace(drogueRunModelExist.Error))
                return ReturnError(drogueRunModelExist.Error);

            DroguePositionModel DroguePositionModelExist = GetDroguePositionModelExistDB(droguePositionModel);
            if (string.IsNullOrWhiteSpace(DroguePositionModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.DroguePosition));

            DroguePosition droguePositionNew = new DroguePosition();
            retStr = FillDroguePosition(droguePositionNew, droguePositionModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.DroguePositions.Add(droguePositionNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DroguePositions", droguePositionNew.DroguePositionID, LogCommandEnum.Add, droguePositionNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetDroguePositionModelWithDroguePositionIDDB(droguePositionNew.DroguePositionID);
        }
        public DroguePositionModel PostDeleteDroguePositionDB(int DroguePositionID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            DroguePosition droguePositionToDelete = GetDroguePositionWithDroguePositionIDDB(DroguePositionID);
            if (droguePositionToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.DroguePosition));

            using (TransactionScope ts = new TransactionScope())
            {
                db.DroguePositions.Remove(droguePositionToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DroguePositions", droguePositionToDelete.DroguePositionID, LogCommandEnum.Delete, droguePositionToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public DroguePositionModel PostUpdateDroguePositionDB(DroguePositionModel droguePositionModel)
        {
            string retStr = DroguePositionModelOK(droguePositionModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            DroguePosition droguePositionToUpdate = GetDroguePositionWithDroguePositionIDDB(droguePositionModel.DroguePositionID);
            if (droguePositionToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.DroguePosition));

            retStr = FillDroguePosition(droguePositionToUpdate, droguePositionModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DroguePositions", droguePositionToUpdate.DroguePositionID, LogCommandEnum.Change, droguePositionToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetDroguePositionModelWithDroguePositionIDDB(droguePositionToUpdate.DroguePositionID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
