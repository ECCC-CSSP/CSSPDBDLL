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
    public class ClimateDataValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public ClimateDataValueService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public override string FieldCheckNotNullDateTime(DateTime? Value, string Res)
        {
            return base.FieldCheckNotNullDateTime(Value, Res);
        }

        // Check
        public string ClimateDataValueModelOK(ClimateDataValueModel climateDataValueModel)
        {
            string retStr = FieldCheckNotZeroInt(climateDataValueModel.ClimateSiteID, ServiceRes.ClimateSiteID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(climateDataValueModel.DateTime_Local, ServiceRes.DateTime_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(climateDataValueModel.Keep, ServiceRes.Keep);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.StorageDataTypeOK(climateDataValueModel.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(climateDataValueModel.HasBeenRead, ServiceRes.HasBeenRead);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (climateDataValueModel.Snow_cm != null)
            {
                retStr = FieldCheckIfNotNullWithinRangeDouble(climateDataValueModel.Snow_cm, ServiceRes.Snow_cm, 0, 10000);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (climateDataValueModel.Rainfall_mm != null)
            {
                retStr = FieldCheckIfNotNullWithinRangeDouble(climateDataValueModel.Rainfall_mm, ServiceRes.Rainfall_mm, 0, 1000);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (climateDataValueModel.RainfallEntered_mm != null)
            {
                retStr = FieldCheckIfNotNullWithinRangeDouble(climateDataValueModel.RainfallEntered_mm, ServiceRes.RainfallEntered_mm, 0, 1000);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (climateDataValueModel.TotalPrecip_mm_cm != null)
            {
                retStr = FieldCheckIfNotNullWithinRangeDouble(climateDataValueModel.TotalPrecip_mm_cm, ServiceRes.TotalPrecip_mm_cm, 0, 1000);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (climateDataValueModel.MaxTemp_C != null)
            {
                retStr = FieldCheckIfNotNullWithinRangeDouble(climateDataValueModel.MaxTemp_C, ServiceRes.MaxTemp_C, -45, 45);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (climateDataValueModel.MinTemp_C != null)
            {
                retStr = FieldCheckIfNotNullWithinRangeDouble(climateDataValueModel.MinTemp_C, ServiceRes.MinTemp_C, -45, 45);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (climateDataValueModel.HeatDegDays_C != null)
            {
                retStr = FieldCheckIfNotNullWithinRangeDouble(climateDataValueModel.HeatDegDays_C, ServiceRes.HeatDegDays_C, 0, 45);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (climateDataValueModel.CoolDegDays_C != null)
            {
                retStr = FieldCheckIfNotNullWithinRangeDouble(climateDataValueModel.CoolDegDays_C, ServiceRes.CoolDegDays_C, 0, 45);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (climateDataValueModel.SnowOnGround_cm != null)
            {
                retStr = FieldCheckIfNotNullWithinRangeDouble(climateDataValueModel.SnowOnGround_cm, ServiceRes.SnowOnGround_cm, 0, 10000);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (climateDataValueModel.DirMaxGust_0North != null)
            {
                retStr = FieldCheckIfNotNullWithinRangeDouble(climateDataValueModel.DirMaxGust_0North, ServiceRes.DirMaxGust_0North, 0, 360);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (climateDataValueModel.SpdMaxGust_kmh != null)
            {
                retStr = FieldCheckIfNotNullWithinRangeDouble(climateDataValueModel.SpdMaxGust_kmh, ServiceRes.SpdMaxGust_kmh, 0, 200);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            return "";
        }

        // Fill
        public string FillClimateDataValue(ClimateDataValue climateDataValueNew, ClimateDataValueModel climateDataValueModel, ContactOK contactOK)
        {

            climateDataValueNew.ClimateSiteID = climateDataValueModel.ClimateSiteID;
            climateDataValueNew.DateTime_Local = climateDataValueModel.DateTime_Local;
            climateDataValueNew.Keep = climateDataValueModel.Keep;
            climateDataValueNew.StorageDataType = (int)climateDataValueModel.StorageDataType;
            climateDataValueNew.HasBeenRead = climateDataValueModel.HasBeenRead;
            climateDataValueNew.CoolDegDays_C = climateDataValueModel.CoolDegDays_C;
            climateDataValueNew.DirMaxGust_0North = climateDataValueModel.DirMaxGust_0North;
            climateDataValueNew.HeatDegDays_C = climateDataValueModel.HeatDegDays_C;
            climateDataValueNew.MaxTemp_C = climateDataValueModel.MaxTemp_C;
            climateDataValueNew.MinTemp_C = climateDataValueModel.MinTemp_C;
            climateDataValueNew.Rainfall_mm = climateDataValueModel.Rainfall_mm;
            climateDataValueNew.RainfallEntered_mm = climateDataValueModel.RainfallEntered_mm;
            climateDataValueNew.Snow_cm = climateDataValueModel.Snow_cm;
            climateDataValueNew.SnowOnGround_cm = climateDataValueModel.SnowOnGround_cm;
            climateDataValueNew.SpdMaxGust_kmh = climateDataValueModel.SpdMaxGust_kmh;
            climateDataValueNew.TotalPrecip_mm_cm = climateDataValueModel.TotalPrecip_mm_cm;
            climateDataValueNew.HourlyValues = climateDataValueModel.HourlyValues;
            climateDataValueNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                climateDataValueNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                climateDataValueNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetClimateDataValueModelCountDB()
        {
            int ClimateDataValueModelCount = (from c in db.ClimateDataValues
                                              select c).Count();

            return ClimateDataValueModelCount;
        }
        public ClimateDataValueModel GetClimateDataValueModelWithClimateDataValueIDDB(int ClimateDataValueID)
        {
            ClimateDataValueModel climateDataValueModel = (from c in db.ClimateDataValues
                                                           where c.ClimateDataValueID == ClimateDataValueID
                                                           select new ClimateDataValueModel
                                                           {
                                                               Error = "",
                                                               ClimateSiteID = c.ClimateSiteID,
                                                               ClimateDataValueID = c.ClimateDataValueID,
                                                               DateTime_Local = c.DateTime_Local,
                                                               Keep = c.Keep,
                                                               StorageDataType = (StorageDataTypeEnum)c.StorageDataType,
                                                               HasBeenRead = c.HasBeenRead,
                                                               CoolDegDays_C = c.CoolDegDays_C,
                                                               DirMaxGust_0North = c.DirMaxGust_0North,
                                                               HeatDegDays_C = c.HeatDegDays_C,
                                                               MaxTemp_C = c.MaxTemp_C,
                                                               MinTemp_C = c.MinTemp_C,
                                                               Rainfall_mm = c.Rainfall_mm,
                                                               RainfallEntered_mm = c.RainfallEntered_mm,
                                                               Snow_cm = c.Snow_cm,
                                                               SnowOnGround_cm = c.SnowOnGround_cm,
                                                               SpdMaxGust_kmh = c.SpdMaxGust_kmh,
                                                               TotalPrecip_mm_cm = c.TotalPrecip_mm_cm,
                                                               HourlyValues = c.HourlyValues,
                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                           }).FirstOrDefault<ClimateDataValueModel>();

            if (climateDataValueModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateDataValue, ServiceRes.ClimateDataValueID, ClimateDataValueID));

            return climateDataValueModel;
        }
        public List<ClimateDataValueModel> GetClimateDataValueModelWithClimateSiteIDDB(int ClimateSiteID)
        {
            List<ClimateDataValueModel> climateDataValueModelList = (from c in db.ClimateDataValues
                                                                     where c.ClimateSiteID == ClimateSiteID
                                                                     select new ClimateDataValueModel
                                                                     {
                                                                         Error = "",
                                                                         ClimateSiteID = c.ClimateSiteID,
                                                                         ClimateDataValueID = c.ClimateDataValueID,
                                                                         DateTime_Local = c.DateTime_Local,
                                                                         Keep = c.Keep,
                                                                         StorageDataType = (StorageDataTypeEnum)c.StorageDataType,
                                                                         HasBeenRead = c.HasBeenRead,
                                                                         CoolDegDays_C = c.CoolDegDays_C,
                                                                         DirMaxGust_0North = c.DirMaxGust_0North,
                                                                         HeatDegDays_C = c.HeatDegDays_C,
                                                                         MaxTemp_C = c.MaxTemp_C,
                                                                         MinTemp_C = c.MinTemp_C,
                                                                         Rainfall_mm = c.Rainfall_mm,
                                                                         RainfallEntered_mm = c.RainfallEntered_mm,
                                                                         Snow_cm = c.Snow_cm,
                                                                         SnowOnGround_cm = c.SnowOnGround_cm,
                                                                         SpdMaxGust_kmh = c.SpdMaxGust_kmh,
                                                                         TotalPrecip_mm_cm = c.TotalPrecip_mm_cm,
                                                                         HourlyValues = c.HourlyValues,
                                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                     }).ToList<ClimateDataValueModel>();

            return climateDataValueModelList;
        }
        public ClimateDataValueModel GetClimateDataValueModelExitDB(ClimateDataValueModel climateDataValueModel)
        {
            ClimateDataValueModel climateDataValueModelRet = (from c in db.ClimateDataValues
                                                              where c.ClimateSiteID == climateDataValueModel.ClimateSiteID
                                                              && c.DateTime_Local == climateDataValueModel.DateTime_Local
                                                              select new ClimateDataValueModel
                                                              {
                                                                  Error = "",
                                                                  ClimateSiteID = c.ClimateSiteID,
                                                                  ClimateDataValueID = c.ClimateDataValueID,
                                                                  DateTime_Local = c.DateTime_Local,
                                                                  Keep = c.Keep,
                                                                  StorageDataType = (StorageDataTypeEnum)c.StorageDataType,
                                                                  HasBeenRead = c.HasBeenRead,
                                                                  CoolDegDays_C = c.CoolDegDays_C,
                                                                  DirMaxGust_0North = c.DirMaxGust_0North,
                                                                  HeatDegDays_C = c.HeatDegDays_C,
                                                                  MaxTemp_C = c.MaxTemp_C,
                                                                  MinTemp_C = c.MinTemp_C,
                                                                  Rainfall_mm = c.Rainfall_mm,
                                                                  RainfallEntered_mm = c.RainfallEntered_mm,
                                                                  Snow_cm = c.Snow_cm,
                                                                  SnowOnGround_cm = c.SnowOnGround_cm,
                                                                  SpdMaxGust_kmh = c.SpdMaxGust_kmh,
                                                                  TotalPrecip_mm_cm = c.TotalPrecip_mm_cm,
                                                                  HourlyValues = c.HourlyValues,
                                                                  LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                  LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                              }).FirstOrDefault<ClimateDataValueModel>();

            if (climateDataValueModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateDataValue,
                    ServiceRes.ClimateSiteID + "," +
                    ServiceRes.DateTime_Local,
                    climateDataValueModel.ClimateSiteID.ToString() + "," +
                    climateDataValueModel.DateTime_Local
                    ));

            return climateDataValueModelRet;
        }
        public ClimateDataValue GetClimateDataValueWithClimateDataValueIDDB(int ClimateDataValueID)
        {
            ClimateDataValue climateDataValue = (from c in db.ClimateDataValues
                                                 where c.ClimateDataValueID == ClimateDataValueID
                                                 select c).FirstOrDefault<ClimateDataValue>();

            return climateDataValue;
        }

        // Helper
        public ClimateDataValueModel ReturnError(string Error)
        {
            return new ClimateDataValueModel() { Error = Error };
        }

        // Post
        public ClimateDataValueModel PostAddClimateDataValueDB(ClimateDataValueModel climateDataValueModel)
        {
            string retStr = ClimateDataValueModelOK(climateDataValueModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ClimateDataValueModel climateDataValueModelExist = GetClimateDataValueModelExitDB(climateDataValueModel);
            if (string.IsNullOrWhiteSpace(climateDataValueModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.ClimateDataValue));

            ClimateDataValue climateDataValueNew = new ClimateDataValue();
            retStr = FillClimateDataValue(climateDataValueNew, climateDataValueModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.ClimateDataValues.Add(climateDataValueNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ClimateDataValues", climateDataValueNew.ClimateDataValueID, LogCommandEnum.Add, climateDataValueNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetClimateDataValueModelWithClimateDataValueIDDB(climateDataValueNew.ClimateDataValueID);
        }
        public ClimateDataValueModel PostDeleteClimateDataValueDB(int climateDataValueID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ClimateDataValue climateDataValueToDelete = GetClimateDataValueWithClimateDataValueIDDB(climateDataValueID);
            if (climateDataValueToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ClimateDataValue));

            using (TransactionScope ts = new TransactionScope())
            {
                db.ClimateDataValues.Remove(climateDataValueToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ClimateDataValues", climateDataValueToDelete.ClimateDataValueID, LogCommandEnum.Delete, climateDataValueToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public ClimateDataValueModel PostUpdateClimateDataValueDB(ClimateDataValueModel climateDataValueModel)
        {
            string retStr = ClimateDataValueModelOK(climateDataValueModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ClimateDataValue climateDataValueToUpdate = GetClimateDataValueWithClimateDataValueIDDB(climateDataValueModel.ClimateDataValueID);
            if (climateDataValueToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.ClimateDataValue));

            retStr = FillClimateDataValue(climateDataValueToUpdate, climateDataValueModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ClimateDataValues", climateDataValueToUpdate.ClimateDataValueID, LogCommandEnum.Change, climateDataValueToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetClimateDataValueModelWithClimateDataValueIDDB(climateDataValueToUpdate.ClimateDataValueID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
