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
    public class AppErrLogService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public AppErrLogService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _LogService = new LogService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions public
        // Override
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
        public string AppErrLogModelOK(AppErrLogModel appErrLogModel)
        {
            string retStr = FieldCheckNotNullAndMinMaxLengthString(appErrLogModel.Tag, ServiceRes.Tag, 2, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(appErrLogModel.Source, ServiceRes.Source, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(appErrLogModel.Message, ServiceRes.Message, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(appErrLogModel.LineNumber, ServiceRes.LineNumber);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(appErrLogModel.DateTime_UTC, ServiceRes.DateTime_UTC);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(appErrLogModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Get
        public int GetAppErrLogModelCountDB()
        {
            int AppErrLogModelCount = (from c in db.AppErrLogs
                                       select c).Count();


            return AppErrLogModelCount;
        }
        public List<AppErrLogModel> GetAppErrLogModelOrderByDateDescDB(int skip, int take)
        {
            take = Math.Min(take, TakeMax);

            List<AppErrLogModel> appErrLogModelList = (from c in db.AppErrLogs
                                                       orderby c.DateTime_UTC descending
                                                       select new AppErrLogModel
                                                       {
                                                           Error = "",
                                                           AppErrLogID = c.AppErrLogID,
                                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                                           Tag = c.Tag,
                                                           LineNumber = c.LineNumber,
                                                           Message = c.Message,
                                                           Source = c.Source,
                                                           DateTime_UTC = c.DateTime_UTC,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).Skip(skip).Take(take).ToList<AppErrLogModel>();

            return appErrLogModelList;
        }
        public List<AppErrLogModel> GetAppErrLogModelFilterSourceOrderByDateDescDB(string SourceFilter, int skip, int take)
        {
            take = Math.Min(take, TakeMax);

            List<AppErrLogModel> appErrLogModelList = (from c in db.AppErrLogs
                                                       where c.Source.Contains(SourceFilter)
                                                       orderby c.DateTime_UTC descending
                                                       select new AppErrLogModel
                                                       {
                                                           Error = "",
                                                           AppErrLogID = c.AppErrLogID,
                                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                                           Tag = c.Tag,
                                                           LineNumber = c.LineNumber,
                                                           Message = c.Message,
                                                           Source = c.Source,
                                                           DateTime_UTC = c.DateTime_UTC,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).Skip(skip).Take(take).ToList<AppErrLogModel>();

            return appErrLogModelList;
        }
        public List<AppErrLogModel> GetAppErrLogModelFilterMessageOrderByDateDescDB(string MessageFilter, int skip, int take)
        {
            take = Math.Min(take, TakeMax);

            List<AppErrLogModel> appErrLogModelList = (from c in db.AppErrLogs
                                                       where c.Message.Contains(MessageFilter)
                                                       orderby c.DateTime_UTC descending
                                                       select new AppErrLogModel
                                                       {
                                                           Error = "",
                                                           AppErrLogID = c.AppErrLogID,
                                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                                           Tag = c.Tag,
                                                           LineNumber = c.LineNumber,
                                                           Message = c.Message,
                                                           Source = c.Source,
                                                           DateTime_UTC = c.DateTime_UTC,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).Skip(skip).Take(take).ToList<AppErrLogModel>();

            return appErrLogModelList;
        }
        public AppErrLogModel GetAppErrLogModelWithAppErrLogIDDB(int AppErrLogID)
        {
            AppErrLogModel appErrLogModel = (from c in db.AppErrLogs
                                             where c.AppErrLogID == AppErrLogID
                                             select new AppErrLogModel
                                             {
                                                 Error = "",
                                                 AppErrLogID = c.AppErrLogID,
                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                 Tag = c.Tag,
                                                 LineNumber = c.LineNumber,
                                                 Message = c.Message,
                                                 Source = c.Source,
                                                 DateTime_UTC = c.DateTime_UTC,
                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             }).FirstOrDefault<AppErrLogModel>();


            if (appErrLogModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.AppErrLog, ServiceRes.AppErrLogID, AppErrLogID));

            return appErrLogModel;
        }
        public AppErrLog GetAppErrLogWithAppErrLogIDDB(int AppErrLogID)
        {
            AppErrLog appErrLog = (from c in db.AppErrLogs
                                   where c.AppErrLogID == AppErrLogID
                                   select c).FirstOrDefault<AppErrLog>();
            return appErrLog;
        }

        // Fill
        public string FillAppErrLog(AppErrLog appErrLog, AppErrLogModel appErrLogModel, ContactOK contactOK)
        {
            appErrLog.DBCommand = (int)appErrLogModel.DBCommand;
            appErrLog.Tag = appErrLogModel.Tag;
            appErrLog.LineNumber = appErrLogModel.LineNumber;
            appErrLog.Source = appErrLogModel.Source;
            appErrLog.Message = appErrLogModel.Message;
            appErrLog.DateTime_UTC = appErrLogModel.DateTime_UTC;
            appErrLog.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                appErrLog.LastUpdateContactTVItemID = 2;
            }
            else
            {
                appErrLog.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }


            return "";
        }

        // Herlper
        public AppErrLogModel ReturnError(string Error)
        {
            return new AppErrLogModel() { Error = Error };
        }

        // Post
        public AppErrLogModel PostAddAppErrLogDB(AppErrLogModel appErrLogModel)
        {
            string retStr = AppErrLogModelOK(appErrLogModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);


            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);


            AppErrLog appErrLogNew = new AppErrLog();
            retStr = FillAppErrLog(appErrLogNew, appErrLogModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);


            using (TransactionScope ts = new TransactionScope())
            {
                db.AppErrLogs.Add(appErrLogNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("AppErrLogs", appErrLogNew.AppErrLogID, LogCommandEnum.Add, appErrLogNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetAppErrLogModelWithAppErrLogIDDB(appErrLogNew.AppErrLogID);
        }
        public AppErrLogModel PostDeleteAppErrLogDB(int AppErrLogID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            AppErrLog appErrLogToDelete = GetAppErrLogWithAppErrLogIDDB(AppErrLogID);
            if (appErrLogToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.AppErrLog));


            using (TransactionScope ts = new TransactionScope())
            {
                db.AppErrLogs.Remove(appErrLogToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("AppErrLogs", appErrLogToDelete.AppErrLogID, LogCommandEnum.Delete, appErrLogToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public AppErrLogModel PostUpdateAppErrLogDB(AppErrLogModel appErrLogModel)
        {
            string retStr = AppErrLogModelOK(appErrLogModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            AppErrLog appErrLogToUpdate = GetAppErrLogWithAppErrLogIDDB(appErrLogModel.AppErrLogID);
            if (appErrLogToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.AppErrLog));


            retStr = FillAppErrLog(appErrLogToUpdate, appErrLogModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("AppErrLogs", appErrLogToUpdate.AppErrLogID, LogCommandEnum.Change, appErrLogToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetAppErrLogModelWithAppErrLogIDDB(appErrLogToUpdate.AppErrLogID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
