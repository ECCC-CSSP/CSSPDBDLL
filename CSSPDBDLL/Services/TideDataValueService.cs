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
    public class TideDataValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public TideDataValueService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public override string FieldCheckNotNullDateTime(DateTime? Value, string Res)
        {
            return base.FieldCheckNotNullDateTime(Value, Res);
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
        public string TideDataValueModelOK(TideDataValueModel tideDataValueModel)
        {
            string retStr = FieldCheckNotZeroInt(tideDataValueModel.TideSiteTVItemID, ServiceRes.TideSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckNotNullDateTime(tideDataValueModel.DateTime_Local, ServiceRes.DateTime_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckNotNullBool(tideDataValueModel.Keep, ServiceRes.Keep);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TideDataTypeOK(tideDataValueModel.TideDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.StorageDataTypeOK(tideDataValueModel.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(tideDataValueModel.Depth_m, ServiceRes.Depth_m, -10, 10);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(tideDataValueModel.UVelocity_m_s, ServiceRes.UVelocity_m_s, -10, 10);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckIfNotNullWithinRangeDouble(tideDataValueModel.VVelocity_m_s, ServiceRes.VVelocity_m_s, -10, 10);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            return "";
        }

        // Fill
        public string FillTideDataValue(TideDataValue tideDataValueNew, TideDataValueModel tideDataValueModel, ContactOK contactOK)
        {
            tideDataValueNew.TideSiteTVItemID = tideDataValueModel.TideSiteTVItemID;
            tideDataValueNew.DateTime_Local = tideDataValueModel.DateTime_Local;
            tideDataValueNew.Keep = tideDataValueModel.Keep;
            tideDataValueNew.TideDataType = (int)tideDataValueModel.TideDataType;
            tideDataValueNew.StorageDataType = (int)tideDataValueModel.StorageDataType;
            tideDataValueNew.Depth_m = tideDataValueModel.Depth_m;
            tideDataValueNew.UVelocity_m_s = tideDataValueModel.UVelocity_m_s;
            tideDataValueNew.VVelocity_m_s = tideDataValueModel.VVelocity_m_s;
            tideDataValueNew.TideEnd = (int?)tideDataValueModel.TideEnd;
            tideDataValueNew.TideStart = (int?)tideDataValueModel.TideStart;
            tideDataValueNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                tideDataValueNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                tideDataValueNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get 
        public int GetTideDataValueModelCountDB()
        {
            int TideDataValueModelCount = (from c in db.TideDataValues
                                           select c).Count();

            return TideDataValueModelCount;
        }
        public TideDataValueModel GetTideDataValueModelWithTideDataValueIDDB(int TideDataValueID)
        {
            TideDataValueModel TideDataValueModel = (from c in db.TideDataValues
                                                     where c.TideDataValueID == TideDataValueID
                                                     select new TideDataValueModel
                                                     {
                                                         Error = "",
                                                         TideSiteTVItemID = c.TideSiteTVItemID,
                                                         TideDataValueID = c.TideDataValueID,
                                                         DateTime_Local = c.DateTime_Local,
                                                         Keep = c.Keep,
                                                         TideDataType = (TideDataTypeEnum)c.TideDataType,
                                                         StorageDataType = (StorageDataTypeEnum)c.StorageDataType,
                                                         TideEnd = (TideTextEnum)c.TideEnd,
                                                         TideStart = (TideTextEnum)c.TideStart,
                                                         Depth_m = c.Depth_m,
                                                         UVelocity_m_s = c.UVelocity_m_s,
                                                         VVelocity_m_s = c.VVelocity_m_s,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<TideDataValueModel>();

            if (TideDataValueModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TideDataValue, ServiceRes.TideDataValueID, TideDataValueID));

            return TideDataValueModel;
        }
        public TideDataValueModel GetTideDataValueModelWithTideSiteTVItemIDAndDateDB(int TideSiteTVItemID, DateTime DateTimeOfTideDataValue)
        {
            TideDataValueModel TideDataValueModel = (from c in db.TideDataValues
                                                     where c.TideSiteTVItemID == TideSiteTVItemID
                                                     && c.DateTime_Local.Year == DateTimeOfTideDataValue.Year
                                                     && c.DateTime_Local.Month == DateTimeOfTideDataValue.Month
                                                     && c.DateTime_Local.Day == DateTimeOfTideDataValue.Day
                                                     select new TideDataValueModel
                                                     {
                                                         Error = "",
                                                         TideSiteTVItemID = c.TideSiteTVItemID,
                                                         TideDataValueID = c.TideDataValueID,
                                                         DateTime_Local = c.DateTime_Local,
                                                         Keep = c.Keep,
                                                         TideDataType = (TideDataTypeEnum)c.TideDataType,
                                                         StorageDataType = (StorageDataTypeEnum)c.StorageDataType,
                                                         TideEnd = (TideTextEnum)c.TideEnd,
                                                         TideStart = (TideTextEnum)c.TideStart,
                                                         Depth_m = c.Depth_m,
                                                         UVelocity_m_s = c.UVelocity_m_s,
                                                         VVelocity_m_s = c.VVelocity_m_s,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<TideDataValueModel>();

            if (TideDataValueModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TideDataValue, ServiceRes.TideSiteTVItemID + ", " + ServiceRes.DateTimeOfTideDataValue, TideSiteTVItemID.ToString() + ", " + DateTimeOfTideDataValue.ToString()));

            return TideDataValueModel;
        }
        public TideDataValueModel GetTideDataValueModelExistDB(TideDataValueModel tideDataValueModel)
        {
            TideDataValueModel TideDataValueModel = (from c in db.TideDataValues
                                                     where c.TideSiteTVItemID == tideDataValueModel.TideSiteTVItemID
                                                     && c.DateTime_Local == tideDataValueModel.DateTime_Local
                                                     select new TideDataValueModel
                                                     {
                                                         Error = "",
                                                         TideSiteTVItemID = c.TideSiteTVItemID,
                                                         TideDataValueID = c.TideDataValueID,
                                                         DateTime_Local = c.DateTime_Local,
                                                         Keep = c.Keep,
                                                         TideDataType = (TideDataTypeEnum)c.TideDataType,
                                                         StorageDataType = (StorageDataTypeEnum)c.StorageDataType,
                                                         TideEnd = (TideTextEnum)c.TideEnd,
                                                         TideStart = (TideTextEnum)c.TideStart,
                                                         Depth_m = c.Depth_m,
                                                         UVelocity_m_s = c.UVelocity_m_s,
                                                         VVelocity_m_s = c.VVelocity_m_s,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<TideDataValueModel>();

            if (TideDataValueModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TideDataValue, ServiceRes.TideSiteTVItemID + "," + ServiceRes.DateTime_Local, tideDataValueModel.TideSiteTVItemID + "," + tideDataValueModel.DateTime_Local));

            return TideDataValueModel;
        }
        public TideDataValue GetTideDataValueWithTideDataValueIDDB(int TideDataValueID)
        {
            TideDataValue TideDataValue = (from c in db.TideDataValues
                                           where c.TideDataValueID == TideDataValueID
                                           select c).FirstOrDefault<TideDataValue>();

            return TideDataValue;
        }

        // Helper
        public TideDataValueModel ReturnError(string Error)
        {
            return new TideDataValueModel() { Error = Error };
        }

        // Post
        public TideDataValueModel PostAddTideDataValueDB(TideDataValueModel tideDataValueModel)
        {
            string retStr = TideDataValueModelOK(tideDataValueModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TideDataValueModel tideDataValueModelExist = GetTideDataValueModelExistDB(tideDataValueModel);
            if (string.IsNullOrWhiteSpace(tideDataValueModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TideDataValue));

            TideDataValue tideDataValueNew = new TideDataValue();
            retStr = FillTideDataValue(tideDataValueNew, tideDataValueModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TideDataValues.Add(tideDataValueNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TideDataValues", tideDataValueNew.TideDataValueID, LogCommandEnum.Add, tideDataValueNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetTideDataValueModelWithTideDataValueIDDB(tideDataValueNew.TideDataValueID);
        }
        public TideDataValueModel PostDeleteTideDataValueDB(int TideDataValueID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TideDataValue tideDataValueToDelete = GetTideDataValueWithTideDataValueIDDB(TideDataValueID);
            if (tideDataValueToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TideDataValue));

            using (TransactionScope ts = new TransactionScope())
            {
                db.TideDataValues.Remove(tideDataValueToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TideDataValues", tideDataValueToDelete.TideDataValueID, LogCommandEnum.Delete, tideDataValueToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public TideDataValueModel PostUpdateTideDataValueDB(TideDataValueModel tideDataValueModel)
        {
            string retStr = TideDataValueModelOK(tideDataValueModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TideDataValue tideDataValueToUpdate = GetTideDataValueWithTideDataValueIDDB(tideDataValueModel.TideDataValueID);
            if (tideDataValueToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TideDataValue));

            retStr = FillTideDataValue(tideDataValueToUpdate, tideDataValueModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TideDataValues", tideDataValueToUpdate.TideDataValueID, LogCommandEnum.Change, tideDataValueToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetTideDataValueModelWithTideDataValueIDDB(tideDataValueToUpdate.TideDataValueID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}

