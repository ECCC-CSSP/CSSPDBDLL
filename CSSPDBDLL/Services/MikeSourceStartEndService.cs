using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class MikeSourceStartEndService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string MikeSourceStartEndModelOK(MikeSourceStartEndModel mikeSourceStartEndModel)
        {
            string retStr = FieldCheckNotZeroInt(mikeSourceStartEndModel.MikeSourceID, ServiceRes.MikeSourceID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(mikeSourceStartEndModel.StartDateAndTime_Local, ServiceRes.StartDateAndTime_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(mikeSourceStartEndModel.EndDateAndTime_Local, ServiceRes.EndDateAndTime_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (mikeSourceStartEndModel.EndDateAndTime_Local < mikeSourceStartEndModel.StartDateAndTime_Local)
            {
                return string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDateAndTime_Local, ServiceRes.EndDateAndTime_Local);
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mikeSourceStartEndModel.SourceFlowStart_m3_day, ServiceRes.SourceFlowStart_m3_day, 0, 10000000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mikeSourceStartEndModel.SourceFlowEnd_m3_day, ServiceRes.SourceFlowEnd_m3_day, 0, 10000000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(mikeSourceStartEndModel.SourcePollutionStart_MPN_100ml, ServiceRes.SourcePollutionStart_MPN_100ml, 0, 30000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(mikeSourceStartEndModel.SourcePollutionEnd_MPN_100ml, ServiceRes.SourcePollutionEnd_MPN_100ml, 0, 30000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mikeSourceStartEndModel.SourceTemperatureStart_C, ServiceRes.SourceTemperatureStart_C, 0, 40);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mikeSourceStartEndModel.SourceTemperatureEnd_C, ServiceRes.SourceTemperatureEnd_C, 0, 40);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mikeSourceStartEndModel.SourceSalinityStart_PSU, ServiceRes.SourceSalinityStart_PSU, 0, 40);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mikeSourceStartEndModel.SourceSalinityEnd_PSU, ServiceRes.SourceSalinityEnd_PSU, 0, 40);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMikeSourceStartEnd(MikeSourceStartEnd mikeSourceStartEnd, MikeSourceStartEndModel mikeSourceStartEndModel, ContactOK contactOK)
        {
            mikeSourceStartEnd.MikeSourceID = mikeSourceStartEndModel.MikeSourceID;
            mikeSourceStartEnd.EndDateAndTime_Local = mikeSourceStartEndModel.EndDateAndTime_Local;
            mikeSourceStartEnd.StartDateAndTime_Local = mikeSourceStartEndModel.StartDateAndTime_Local;
            mikeSourceStartEnd.SourceFlowEnd_m3_day = mikeSourceStartEndModel.SourceFlowEnd_m3_day;
            mikeSourceStartEnd.SourceFlowStart_m3_day = mikeSourceStartEndModel.SourceFlowStart_m3_day;
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = mikeSourceStartEndModel.SourcePollutionEnd_MPN_100ml;
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = mikeSourceStartEndModel.SourcePollutionStart_MPN_100ml;
            mikeSourceStartEnd.SourceSalinityEnd_PSU = mikeSourceStartEndModel.SourceSalinityEnd_PSU;
            mikeSourceStartEnd.SourceSalinityStart_PSU = mikeSourceStartEndModel.SourceSalinityStart_PSU;
            mikeSourceStartEnd.SourceTemperatureEnd_C = mikeSourceStartEndModel.SourceTemperatureEnd_C;
            mikeSourceStartEnd.SourceTemperatureStart_C = mikeSourceStartEndModel.SourceTemperatureStart_C;
            mikeSourceStartEnd.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mikeSourceStartEnd.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mikeSourceStartEnd.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMikeSourceStartEndModelCountDB()
        {
            return (from c in db.MikeSourceStartEnds
                    select c).Count();
        }
        public List<MikeSourceStartEndModel> GetMikeSourceStartEndModelListWithMikeSourceIDDB(int MikeSourceID)
        {
            List<MikeSourceStartEndModel> mikeSourceStartEndModelList = (from c in db.MikeSourceStartEnds
                                                                         where c.MikeSourceID == MikeSourceID
                                                                         orderby c.StartDateAndTime_Local
                                                                         select new MikeSourceStartEndModel
                                                                         {
                                                                             Error = "",
                                                                             MikeSourceStartEndID = c.MikeSourceStartEndID,
                                                                             MikeSourceID = c.MikeSourceID,
                                                                             StartDateAndTime_Local = c.StartDateAndTime_Local,
                                                                             EndDateAndTime_Local = c.EndDateAndTime_Local,
                                                                             SourceFlowStart_m3_day = c.SourceFlowStart_m3_day,
                                                                             SourceFlowEnd_m3_day = c.SourceFlowEnd_m3_day,
                                                                             SourcePollutionStart_MPN_100ml = c.SourcePollutionStart_MPN_100ml,
                                                                             SourcePollutionEnd_MPN_100ml = c.SourcePollutionEnd_MPN_100ml,
                                                                             SourceSalinityStart_PSU = c.SourceSalinityStart_PSU,
                                                                             SourceSalinityEnd_PSU = c.SourceSalinityEnd_PSU,
                                                                             SourceTemperatureStart_C = c.SourceTemperatureStart_C,
                                                                             SourceTemperatureEnd_C = c.SourceTemperatureEnd_C,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                                         }).ToList<MikeSourceStartEndModel>();

            return mikeSourceStartEndModelList;
        }
        public List<MikeSourceStartEndModel> GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(int MikeSourceTVItemID)
        {
            List<MikeSourceStartEndModel> mikeSourceStartEndModelList = (from c in db.MikeSourceStartEnds
                                                                         from ms in db.MikeSources
                                                                         where c.MikeSourceID == ms.MikeSourceID
                                                                         && ms.MikeSourceTVItemID == MikeSourceTVItemID
                                                                         orderby c.StartDateAndTime_Local
                                                                         select new MikeSourceStartEndModel
                                                                         {
                                                                             Error = "",
                                                                             MikeSourceStartEndID = c.MikeSourceStartEndID,
                                                                             MikeSourceID = c.MikeSourceID,
                                                                             StartDateAndTime_Local = c.StartDateAndTime_Local,
                                                                             EndDateAndTime_Local = c.EndDateAndTime_Local,
                                                                             SourceFlowStart_m3_day = c.SourceFlowStart_m3_day,
                                                                             SourceFlowEnd_m3_day = c.SourceFlowEnd_m3_day,
                                                                             SourcePollutionStart_MPN_100ml = c.SourcePollutionStart_MPN_100ml,
                                                                             SourcePollutionEnd_MPN_100ml = c.SourcePollutionEnd_MPN_100ml,
                                                                             SourceSalinityStart_PSU = c.SourceSalinityStart_PSU,
                                                                             SourceSalinityEnd_PSU = c.SourceSalinityEnd_PSU,
                                                                             SourceTemperatureStart_C = c.SourceTemperatureStart_C,
                                                                             SourceTemperatureEnd_C = c.SourceTemperatureEnd_C,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                                         }).ToList<MikeSourceStartEndModel>();

            return mikeSourceStartEndModelList;
        }
        public MikeSourceStartEndModel GetMikeSourceStartEndModelWithMikeSourceStartEndIDDB(int MikeSourceStartEndID)
        {
            MikeSourceStartEndModel mikeSourceStartEndModel = (from c in db.MikeSourceStartEnds
                                                               where c.MikeSourceStartEndID == MikeSourceStartEndID
                                                               select new MikeSourceStartEndModel
                                                               {
                                                                   Error = "",
                                                                   MikeSourceStartEndID = c.MikeSourceStartEndID,
                                                                   MikeSourceID = c.MikeSourceID,
                                                                   StartDateAndTime_Local = c.StartDateAndTime_Local,
                                                                   EndDateAndTime_Local = c.EndDateAndTime_Local,
                                                                   SourceFlowStart_m3_day = c.SourceFlowStart_m3_day,
                                                                   SourceFlowEnd_m3_day = c.SourceFlowEnd_m3_day,
                                                                   SourcePollutionStart_MPN_100ml = c.SourcePollutionStart_MPN_100ml,
                                                                   SourcePollutionEnd_MPN_100ml = c.SourcePollutionEnd_MPN_100ml,
                                                                   SourceSalinityStart_PSU = c.SourceSalinityStart_PSU,
                                                                   SourceSalinityEnd_PSU = c.SourceSalinityEnd_PSU,
                                                                   SourceTemperatureStart_C = c.SourceTemperatureStart_C,
                                                                   SourceTemperatureEnd_C = c.SourceTemperatureEnd_C,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                               }).FirstOrDefault<MikeSourceStartEndModel>();

            if (mikeSourceStartEndModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeSourceStartEnd, ServiceRes.MikeSourceStartEndID, MikeSourceStartEndID));

            return mikeSourceStartEndModel;
        }
        public MikeSourceStartEnd GetMikeSourceStartEndWithMikeSourceStartEndIDDB(int MikeSourceStartEndID)
        {
            MikeSourceStartEnd mikeSourceStartEnd = (from c in db.MikeSourceStartEnds
                                                     where c.MikeSourceStartEndID == MikeSourceStartEndID
                                                     select c).FirstOrDefault<MikeSourceStartEnd>();

            return mikeSourceStartEnd;
        }
        public MikeSourceStartEndModel GetMikeSourceStartEndModelExist(MikeSourceStartEndModel mikeSourceStartEndModel)
        {
            MikeSourceStartEndModel mikeSourceStartEndModelRet = (from c in db.MikeSourceStartEnds
                                                               where c.StartDateAndTime_Local == mikeSourceStartEndModel.StartDateAndTime_Local
                                                               && c.EndDateAndTime_Local == mikeSourceStartEndModel.EndDateAndTime_Local
                                                               && c.MikeSourceID == mikeSourceStartEndModel.MikeSourceID
                                                               && c.SourceFlowStart_m3_day == mikeSourceStartEndModel.SourceFlowStart_m3_day
                                                               && c.SourceFlowEnd_m3_day == mikeSourceStartEndModel.SourceFlowEnd_m3_day
                                                               && c.SourcePollutionStart_MPN_100ml == mikeSourceStartEndModel.SourcePollutionStart_MPN_100ml
                                                               && c.SourcePollutionEnd_MPN_100ml == mikeSourceStartEndModel.SourcePollutionEnd_MPN_100ml
                                                               && c.SourceTemperatureStart_C == mikeSourceStartEndModel.SourceTemperatureStart_C
                                                               && c.SourceTemperatureEnd_C == mikeSourceStartEndModel.SourceTemperatureEnd_C
                                                               && c.SourceSalinityStart_PSU == mikeSourceStartEndModel.SourceSalinityStart_PSU
                                                               && c.SourceSalinityEnd_PSU == mikeSourceStartEndModel.SourceSalinityEnd_PSU
                                                               select new MikeSourceStartEndModel
                                                               {
                                                                   Error = "",
                                                                   MikeSourceStartEndID = c.MikeSourceStartEndID,
                                                                   MikeSourceID = c.MikeSourceID,
                                                                   StartDateAndTime_Local = c.StartDateAndTime_Local,
                                                                   EndDateAndTime_Local = c.EndDateAndTime_Local,
                                                                   SourceFlowStart_m3_day = c.SourceFlowStart_m3_day,
                                                                   SourceFlowEnd_m3_day = c.SourceFlowEnd_m3_day,
                                                                   SourcePollutionStart_MPN_100ml = c.SourcePollutionStart_MPN_100ml,
                                                                   SourcePollutionEnd_MPN_100ml = c.SourcePollutionEnd_MPN_100ml,
                                                                   SourceSalinityStart_PSU = c.SourceSalinityStart_PSU,
                                                                   SourceSalinityEnd_PSU = c.SourceSalinityEnd_PSU,
                                                                   SourceTemperatureStart_C = c.SourceTemperatureStart_C,
                                                                   SourceTemperatureEnd_C = c.SourceTemperatureEnd_C,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                               }).FirstOrDefault<MikeSourceStartEndModel>();

            if (mikeSourceStartEndModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeSourceStartEnd, ServiceRes.MikeSourceID + "," + ServiceRes.StartDateAndTime_Local + "," + ServiceRes.EndDateAndTime_Local, mikeSourceStartEndModel.MikeSourceID + "," + mikeSourceStartEndModel.StartDateAndTime_Local + "," + mikeSourceStartEndModel.EndDateAndTime_Local));

            return mikeSourceStartEndModelRet;
        }

        // Helper
        public MikeSourceStartEndModel ReturnError(string Error)
        {
            return new MikeSourceStartEndModel() { Error = Error };
        }

        // Post
        public MikeSourceStartEndModel PostAddMikeSourceStartEndDB(MikeSourceStartEndModel mikeSourceStartEndModel)
        {
            string retStr = MikeSourceStartEndModelOK(mikeSourceStartEndModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MikeSourceStartEndModel mikeSourceStartEndModelExist = GetMikeSourceStartEndModelExist(mikeSourceStartEndModel);
            if (string.IsNullOrWhiteSpace(mikeSourceStartEndModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.MikeSourceStartEnd));

            MikeSourceStartEnd mikeSourceStartEndNew = new MikeSourceStartEnd();
            retStr = FillMikeSourceStartEnd(mikeSourceStartEndNew, mikeSourceStartEndModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MikeSourceStartEnds.Add(mikeSourceStartEndNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MikeSourceStartEnds", mikeSourceStartEndNew.MikeSourceStartEndID, LogCommandEnum.Add, mikeSourceStartEndNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMikeSourceStartEndModelWithMikeSourceStartEndIDDB(mikeSourceStartEndNew.MikeSourceStartEndID);
        }
        public MikeSourceStartEndModel PostDeleteMikeSourceStartEndDB(int MikeSourceStartEndID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MikeSourceStartEnd mikeSourceStartEndToDelete = GetMikeSourceStartEndWithMikeSourceStartEndIDDB(MikeSourceStartEndID);
            if (mikeSourceStartEndToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MikeSourceStartEnd));

            using (TransactionScope ts = new TransactionScope())
            {
                db.MikeSourceStartEnds.Remove(mikeSourceStartEndToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MikeSourceStartEnds", mikeSourceStartEndToDelete.MikeSourceStartEndID, LogCommandEnum.Delete, mikeSourceStartEndToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public MikeSourceStartEndModel PostUpdateMikeSourceStartEndDB(MikeSourceStartEndModel mikeSourceStartEndModel)
        {
            string retStr = MikeSourceStartEndModelOK(mikeSourceStartEndModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MikeSourceStartEnd mikeSourceStartEndToUpdate = GetMikeSourceStartEndWithMikeSourceStartEndIDDB(mikeSourceStartEndModel.MikeSourceStartEndID);
            if (mikeSourceStartEndToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MikeSourceStartEnd));

            retStr = FillMikeSourceStartEnd(mikeSourceStartEndToUpdate, mikeSourceStartEndModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MikeSourceStartEnds", mikeSourceStartEndToUpdate.MikeSourceStartEndID, LogCommandEnum.Change, mikeSourceStartEndToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMikeSourceStartEndModelWithMikeSourceStartEndIDDB(mikeSourceStartEndToUpdate.MikeSourceStartEndID);
        }
        #endregion Function public

        #region Function private
        #endregion Functions private
    }
}
