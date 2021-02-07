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
    public class HydrometricDataValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string HydrometricDataValueModelOK(HydrometricDataValueModel hydrometricDataValueModel)
        {
            string retStr = FieldCheckNotZeroInt(hydrometricDataValueModel.HydrometricSiteID, ServiceRes.HydrometricSiteID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(hydrometricDataValueModel.DateTime_Local, ServiceRes.DateTime_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(hydrometricDataValueModel.Discharge_m3_s, ServiceRes.Discharge_m3_s, 0, 100000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(hydrometricDataValueModel.DischargeEntered_m3_s, ServiceRes.DischargeEntered_m3_s, 0, 100000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(hydrometricDataValueModel.Level_m, ServiceRes.Level_m, 0, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(hydrometricDataValueModel.Keep, ServiceRes.Keep);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.StorageDataTypeOK(hydrometricDataValueModel.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(hydrometricDataValueModel.HasBeenRead, ServiceRes.HasBeenRead);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(hydrometricDataValueModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillHydrometricDataValue(HydrometricDataValue hydrometricDataValueNew, HydrometricDataValueModel hydrometricDataValueModel, ContactOK contactOK)
        {
            hydrometricDataValueNew.DBCommand = (int)hydrometricDataValueModel.DBCommand;
            hydrometricDataValueNew.HydrometricSiteID = hydrometricDataValueModel.HydrometricSiteID;
            hydrometricDataValueNew.DateTime_Local = hydrometricDataValueModel.DateTime_Local;
            hydrometricDataValueNew.Keep = hydrometricDataValueModel.Keep;
            hydrometricDataValueNew.StorageDataType = (int)hydrometricDataValueModel.StorageDataType;
            hydrometricDataValueNew.HasBeenRead = hydrometricDataValueModel.HasBeenRead;
            hydrometricDataValueNew.Discharge_m3_s = hydrometricDataValueModel.Discharge_m3_s;
            hydrometricDataValueNew.DischargeEntered_m3_s = hydrometricDataValueModel.DischargeEntered_m3_s;
            hydrometricDataValueNew.Level_m = hydrometricDataValueModel.Level_m;
            hydrometricDataValueNew.HourlyValues = hydrometricDataValueModel.HourlyValues;
            hydrometricDataValueNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                hydrometricDataValueNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                hydrometricDataValueNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetHydrometricDataValueModelCountDB()
        {
            int HydrometricDataValueModelCount = (from c in db.HydrometricDataValues
                                                  select c).Count();

            return HydrometricDataValueModelCount;
        }
        public HydrometricDataValueModel GetHydrometricDataValueModelWithHydrometricDataValueIDDB(int HydrometricDataValueID)
        {
            HydrometricDataValueModel HydrometricDataValueModel = (from c in db.HydrometricDataValues
                                                                   where c.HydrometricDataValueID == HydrometricDataValueID
                                                                   select new HydrometricDataValueModel
                                                                   {
                                                                       Error = "",
                                                                       HydrometricSiteID = c.HydrometricSiteID,
                                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                                       HydrometricDataValueID = c.HydrometricDataValueID,
                                                                       DateTime_Local = c.DateTime_Local,
                                                                       Keep = c.Keep,
                                                                       StorageDataType = (StorageDataTypeEnum)c.StorageDataType,
                                                                       HasBeenRead = c.HasBeenRead,
                                                                       Discharge_m3_s = c.Discharge_m3_s,
                                                                       DischargeEntered_m3_s = c.DischargeEntered_m3_s,
                                                                       Level_m = c.Level_m,
                                                                       HourlyValues = c.HourlyValues,
                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                   }).FirstOrDefault<HydrometricDataValueModel>();

            if (HydrometricDataValueModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricDataValue, ServiceRes.HydrometricDataValueID, HydrometricDataValueID));

            return HydrometricDataValueModel;
        }
        public List<HydrometricDataValueModel> GetHydrometricDataValueModelListWithHydrometricSiteIDAroundRunDateDB(int HydrometricSiteID, DateTime date)
        {
            date = date.AddDays(2);
            List<HydrometricDataValueModel> hydrometricDataValueModelList = (from c in db.HydrometricDataValues
                                                                   where c.HydrometricSiteID == HydrometricSiteID
                                                                   && c.DateTime_Local <= date
                                                                   orderby c.DateTime_Local descending
                                                                   select new HydrometricDataValueModel
                                                                   {
                                                                       Error = "",
                                                                       HydrometricSiteID = c.HydrometricSiteID,
                                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                                       HydrometricDataValueID = c.HydrometricDataValueID,
                                                                       DateTime_Local = c.DateTime_Local,
                                                                       Keep = c.Keep,
                                                                       StorageDataType = (StorageDataTypeEnum)c.StorageDataType,
                                                                       HasBeenRead = c.HasBeenRead,
                                                                       Discharge_m3_s = c.Discharge_m3_s,
                                                                       DischargeEntered_m3_s = c.DischargeEntered_m3_s,
                                                                       Level_m = c.Level_m,
                                                                       HourlyValues = c.HourlyValues,
                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                   }).Take(10).ToList<HydrometricDataValueModel>();

            return hydrometricDataValueModelList;
        }
        public List<HydrometricDataValueModel> GetHydrometricDataValueModelListWithHydrometricSiteIDDB(int HydrometricSiteID)
        {
            List<HydrometricDataValueModel> hydrometricDataValueModelList = (from c in db.HydrometricDataValues
                                                                             where c.HydrometricSiteID == HydrometricSiteID
                                                                             select new HydrometricDataValueModel
                                                                             {
                                                                                 Error = "",
                                                                                 HydrometricSiteID = c.HydrometricSiteID,
                                                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                                                 HydrometricDataValueID = c.HydrometricDataValueID,
                                                                                 DateTime_Local = c.DateTime_Local,
                                                                                 Keep = c.Keep,
                                                                                 StorageDataType = (StorageDataTypeEnum)c.StorageDataType,
                                                                                 HasBeenRead = c.HasBeenRead,
                                                                                 Discharge_m3_s = c.Discharge_m3_s,
                                                                                 DischargeEntered_m3_s = c.DischargeEntered_m3_s,
                                                                                 Level_m = c.Level_m,
                                                                                 HourlyValues = c.HourlyValues,
                                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                             }).ToList<HydrometricDataValueModel>();

            return hydrometricDataValueModelList;
        }
        public List<HydrometricDataValueModel> GetHydrometricDataValueModelListWithHydrometricSiteIDAndYearDB(int HydrometricSiteID, int Year)
        {
            List<HydrometricDataValueModel> hydrometricDataValueModelList = (from c in db.HydrometricDataValues
                                                                             where c.HydrometricSiteID == HydrometricSiteID
                                                                             && c.DateTime_Local.Year == Year
                                                                             select new HydrometricDataValueModel
                                                                             {
                                                                                 Error = "",
                                                                                 HydrometricSiteID = c.HydrometricSiteID,
                                                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                                                 HydrometricDataValueID = c.HydrometricDataValueID,
                                                                                 DateTime_Local = c.DateTime_Local,
                                                                                 Keep = c.Keep,
                                                                                 StorageDataType = (StorageDataTypeEnum)c.StorageDataType,
                                                                                 HasBeenRead = c.HasBeenRead,
                                                                                 Discharge_m3_s = c.Discharge_m3_s,
                                                                                 DischargeEntered_m3_s = c.DischargeEntered_m3_s,
                                                                                 Level_m = c.Level_m,
                                                                                 HourlyValues = c.HourlyValues,
                                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                             }).ToList<HydrometricDataValueModel>();

            return hydrometricDataValueModelList;
        }
        public HydrometricDataValue GetHydrometricDataValueWithHydrometricDataValueIDDB(int HydrometricDataValueID)
        {
            HydrometricDataValue HydrometricDataValue = (from c in db.HydrometricDataValues
                                                         where c.HydrometricDataValueID == HydrometricDataValueID
                                                         select c).FirstOrDefault<HydrometricDataValue>();

            return HydrometricDataValue;
        }
        public HydrometricDataValue GetHydrometricDataValueExitDB(HydrometricDataValueModel hydrometricDataValueModel)
        {
            HydrometricDataValue HydrometricDataValue = (from c in db.HydrometricDataValues
                                                         where c.HydrometricSiteID == hydrometricDataValueModel.HydrometricSiteID
                                                         && c.DateTime_Local == hydrometricDataValueModel.DateTime_Local
                                                         select c).FirstOrDefault<HydrometricDataValue>();

            return HydrometricDataValue;
        }

        // Helper
        public HydrometricDataValueModel ReturnError(string Error)
        {
            return new HydrometricDataValueModel() { Error = Error };
        }

        // Post
        public HydrometricDataValueModel PostAddHydrometricDataValueDB(HydrometricDataValueModel hydrometricDataValueModel)
        {
            string retStr = HydrometricDataValueModelOK(hydrometricDataValueModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            HydrometricDataValue hydrometricDataValueExist = GetHydrometricDataValueExitDB(hydrometricDataValueModel);
            if (hydrometricDataValueExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.HydrometricDataValue));

            HydrometricDataValue hydrometricDataValueNew = new HydrometricDataValue();
            retStr = FillHydrometricDataValue(hydrometricDataValueNew, hydrometricDataValueModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.HydrometricDataValues.Add(hydrometricDataValueNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("HydrometricDataValues", hydrometricDataValueNew.HydrometricDataValueID, LogCommandEnum.Add, hydrometricDataValueNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetHydrometricDataValueModelWithHydrometricDataValueIDDB(hydrometricDataValueNew.HydrometricDataValueID);
        }
        public HydrometricDataValueModel PostDeleteHydrometricDataValueDB(int hydrometricDataValueID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            HydrometricDataValue hydrometricDataValueToDelete = GetHydrometricDataValueWithHydrometricDataValueIDDB(hydrometricDataValueID);
            if (hydrometricDataValueToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.HydrometricDataValue));

            using (TransactionScope ts = new TransactionScope())
            {
                db.HydrometricDataValues.Remove(hydrometricDataValueToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("HydrometricDataValues", hydrometricDataValueToDelete.HydrometricDataValueID, LogCommandEnum.Delete, hydrometricDataValueToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public HydrometricDataValueModel PostUpdateHydrometricDataValueDB(HydrometricDataValueModel hydrometricDataValueModel)
        {
            string retStr = HydrometricDataValueModelOK(hydrometricDataValueModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            HydrometricDataValue hydrometricDataValueToUpdate = GetHydrometricDataValueWithHydrometricDataValueIDDB(hydrometricDataValueModel.HydrometricDataValueID);
            if (hydrometricDataValueToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.HydrometricDataValue));

            retStr = FillHydrometricDataValue(hydrometricDataValueToUpdate, hydrometricDataValueModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("HydrometricDataValues", hydrometricDataValueToUpdate.HydrometricDataValueID, LogCommandEnum.Change, hydrometricDataValueToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetHydrometricDataValueModelWithHydrometricDataValueIDDB(hydrometricDataValueToUpdate.HydrometricDataValueID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
