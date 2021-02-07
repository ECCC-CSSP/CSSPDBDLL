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
    public class AppTaskService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public AppTaskLanguageService _AppTaskLanguageService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public AppTaskService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _AppTaskLanguageService = new AppTaskLanguageService(LanguageRequest, User);
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
        public override bool IsStartDateBiggerThanEndDate(DateTime StartDate, DateTime? EndDate)
        {
            return base.IsStartDateBiggerThanEndDate(StartDate, EndDate);
        }

        // Check
        public string AppTaskModelOK(AppTaskModel appTaskModel)
        {

            string retStr = FieldCheckNotZeroInt(appTaskModel.TVItemID, ServiceRes.TVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(appTaskModel.TVItemID2, ServiceRes.TVItemID2);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.AppTaskCommandOK(appTaskModel.AppTaskCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(appTaskModel.ErrorText, ServiceRes.ErrorText, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(appTaskModel.StatusText, ServiceRes.StatusText, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.AppTaskStatusOK(appTaskModel.AppTaskStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(appTaskModel.PercentCompleted, ServiceRes.PercentCompleted, 0, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(appTaskModel.Parameters, ServiceRes.Parameters, 2, 100000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(appTaskModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(appTaskModel.StartDateTime_UTC, ServiceRes.StartDateTime_UTC);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (appTaskModel.EndDateTime_UTC != null)
            {
                if (IsStartDateBiggerThanEndDate(appTaskModel.StartDateTime_UTC, appTaskModel.EndDateTime_UTC))
                {
                    return string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDateTime_Local, ServiceRes.EndDateTime_Local);
                }
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(appTaskModel.EstimatedLength_second, ServiceRes.EstimatedLength_second, 0, 86400);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(appTaskModel.RemainingTime_second, ServiceRes.RemainingTime_second, 0, 86400);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(appTaskModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillAppTask(AppTask appTask, AppTaskModel appTaskModel, ContactOK contactOK)
        {
            appTask.DBCommand = (int)appTaskModel.DBCommand;
            appTask.TVItemID = appTaskModel.TVItemID;
            appTask.TVItemID2 = appTaskModel.TVItemID2;
            appTask.AppTaskCommand = (int)appTaskModel.AppTaskCommand;
            appTask.AppTaskStatus = (int)appTaskModel.AppTaskStatus;
            appTask.PercentCompleted = appTaskModel.PercentCompleted;
            appTask.Parameters = appTaskModel.Parameters;
            appTask.Language = (int)appTaskModel.Language;
            appTask.EndDateTime_UTC = appTaskModel.EndDateTime_UTC;
            appTask.StartDateTime_UTC = appTaskModel.StartDateTime_UTC;
            appTask.EstimatedLength_second = appTaskModel.EstimatedLength_second;
            appTask.RemainingTime_second = appTaskModel.RemainingTime_second;
            appTask.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                appTask.LastUpdateContactTVItemID = 2;
            }
            else
            {
                appTask.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }


            return "";
        } 

        // Get
        public AppTaskModel CheckAppTask()
        {
            AppTaskModel appTaskModel = new AppTaskModel();
            try
            {
                appTaskModel = (from c in db.AppTasks
                                             from cl in db.AppTaskLanguages
                                             where c.AppTaskID == cl.AppTaskID
                                             && c.AppTaskStatus == (int)AppTaskStatusEnum.Created
                                             select new AppTaskModel
                                             {
                                                 Error = "",
                                                 AppTaskID = c.AppTaskID,
                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                 AppTaskCommand = (AppTaskCommandEnum)c.AppTaskCommand,
                                                 EndDateTime_UTC = c.EndDateTime_UTC,
                                                 StartDateTime_UTC = c.StartDateTime_UTC,
                                                 EstimatedLength_second = c.EstimatedLength_second,
                                                 Language = (LanguageEnum)c.Language,
                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                 Parameters = c.Parameters,
                                                 PercentCompleted = c.PercentCompleted,
                                                 RemainingTime_second = c.RemainingTime_second,
                                                 AppTaskStatus = (AppTaskStatusEnum)c.AppTaskStatus,
                                                 TVItemID = c.TVItemID,
                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                 ErrorText = cl.ErrorText,
                                                 TVItemID2 = c.TVItemID2,
                                                 StatusText = cl.StatusText,
                                             }).FirstOrDefault<AppTaskModel>();

            }
            catch (Exception)
            {
                return ReturnError(ServiceRes.NoNewTaskToRun);
            }

            if (appTaskModel == null)
                return ReturnError(ServiceRes.NoNewTaskToRun);

            return appTaskModel;
        }
        public int GetAppTaskModelCountDB()
        {
            int AppTaskModelCount = (from c in db.AppTasks
                                     select c).Count();

            return AppTaskModelCount;
        }
        public int GetAppTaskModelCountWithAppTaskStatusAndAppTaskCommandDB(AppTaskStatusEnum appTaskStatus, AppTaskCommandEnum appTaskCommand)
        {
            int AppTaskModelCount = (from c in db.AppTasks
                                     where c.AppTaskStatus == (int)appTaskStatus
                                     && c.AppTaskCommand == (int)appTaskCommand
                                     select c).Count();

            return AppTaskModelCount;
        }
        public List<AppTaskModel> GetAppTaskModelListDB()
        {
            List<AppTaskModel> AppTaskModelList = (from c in db.AppTasks
                                                   let tvItemIDTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID select cl.TVText).FirstOrDefault<string>()
                                                   let tvItemIDTVText2 = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID2 select cl.TVText).FirstOrDefault<string>()
                                                   let errorText = (from cl in db.AppTaskLanguages where cl.Language == (int)LanguageRequest && cl.AppTaskID == c.AppTaskID select cl.ErrorText).FirstOrDefault<string>()
                                                   let statusText = (from cl in db.AppTaskLanguages where cl.Language == (int)LanguageRequest && cl.AppTaskID == c.AppTaskID select cl.StatusText).FirstOrDefault<string>()
                                                   orderby c.AppTaskID
                                                   select new AppTaskModel
                                                   {
                                                       Error = "",
                                                       AppTaskID = c.AppTaskID,
                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                       TVItemID = c.TVItemID,
                                                       TVItemIDTVText = tvItemIDTVText,
                                                       TVItemID2 = c.TVItemID2,
                                                       TVItemID2TVText = tvItemIDTVText2,
                                                       AppTaskCommand = (AppTaskCommandEnum)c.AppTaskCommand,
                                                       ErrorText = errorText,
                                                       StatusText = statusText,
                                                       AppTaskStatus = (AppTaskStatusEnum)c.AppTaskStatus,
                                                       PercentCompleted = c.PercentCompleted,
                                                       Parameters = c.Parameters,
                                                       Language = (LanguageEnum)c.Language,
                                                       EndDateTime_UTC = c.EndDateTime_UTC,
                                                       StartDateTime_UTC = c.StartDateTime_UTC,
                                                       EstimatedLength_second = c.EstimatedLength_second,
                                                       RemainingTime_second = c.RemainingTime_second,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                   }).ToList<AppTaskModel>();

            return AppTaskModelList;
        }
        public List<AppTaskModel> GetAppTaskModelListOfRunningMikeScenariosDB()
        {
            List<AppTaskModel> appTaskModelList = (from c in db.AppTasks
                                                   let tvItemIDTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID select cl.TVText).FirstOrDefault<string>()
                                                   let tvItemIDTVText2 = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID2 select cl.TVText).FirstOrDefault<string>()
                                                   let errorText = (from cl in db.AppTaskLanguages where cl.Language == (int)LanguageRequest && cl.AppTaskID == c.AppTaskID select cl.ErrorText).FirstOrDefault<string>()
                                                   let statusText = (from cl in db.AppTaskLanguages where cl.Language == (int)LanguageRequest && cl.AppTaskID == c.AppTaskID select cl.StatusText).FirstOrDefault<string>()
                                                   where c.AppTaskStatus == (int)AppTaskStatusEnum.Running
                                                   && (c.AppTaskCommand == (int)AppTaskCommandEnum.MikeScenarioToCancel
                                                   || c.AppTaskCommand == (int)AppTaskCommandEnum.MikeScenarioRunning)
                                                   select new AppTaskModel
                                                   {
                                                       Error = "",
                                                       AppTaskID = c.AppTaskID,
                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                       TVItemID = c.TVItemID,
                                                       TVItemIDTVText = tvItemIDTVText,
                                                       TVItemID2 = c.TVItemID2,
                                                       TVItemID2TVText = tvItemIDTVText2,
                                                       AppTaskCommand = (AppTaskCommandEnum)c.AppTaskCommand,
                                                       ErrorText = errorText,
                                                       StatusText = statusText,
                                                       AppTaskStatus = (AppTaskStatusEnum)c.AppTaskStatus,
                                                       PercentCompleted = c.PercentCompleted,
                                                       Parameters = c.Parameters,
                                                       Language = (LanguageEnum)c.Language,
                                                       EndDateTime_UTC = c.EndDateTime_UTC,
                                                       StartDateTime_UTC = c.StartDateTime_UTC,
                                                       EstimatedLength_second = c.EstimatedLength_second,
                                                       RemainingTime_second = c.RemainingTime_second,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                   }).ToList<AppTaskModel>();

            return appTaskModelList;
        }
        public AppTaskModel GetAppTaskModelWithAppTaskIDDB(int AppTaskID)
        {
           AppTaskModel appTaskModel = (from c in db.AppTasks
                                         let tvItemIDTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID select cl.TVText).FirstOrDefault<string>()
                                         let tvItemIDTVText2 = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID2 select cl.TVText).FirstOrDefault<string>()
                                         let errorText = (from cl in db.AppTaskLanguages where cl.Language == (int)LanguageRequest && cl.AppTaskID == c.AppTaskID select cl.ErrorText).FirstOrDefault<string>()
                                         let statusText = (from cl in db.AppTaskLanguages where cl.Language == (int)LanguageRequest && cl.AppTaskID == c.AppTaskID select cl.StatusText).FirstOrDefault<string>()
                                         where c.AppTaskID == AppTaskID
                                         select new AppTaskModel
                                         {
                                             Error = "",
                                             AppTaskID = c.AppTaskID,
                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                             TVItemID = c.TVItemID,
                                             TVItemIDTVText = tvItemIDTVText,
                                             TVItemID2 = c.TVItemID2,
                                             TVItemID2TVText = tvItemIDTVText2,
                                             AppTaskCommand = (AppTaskCommandEnum)c.AppTaskCommand,
                                             ErrorText = errorText,
                                             StatusText = statusText,
                                             AppTaskStatus = (AppTaskStatusEnum)c.AppTaskStatus,
                                             PercentCompleted = c.PercentCompleted,
                                             Parameters = c.Parameters,
                                             Language = (LanguageEnum)c.Language,
                                             EndDateTime_UTC = c.EndDateTime_UTC,
                                             StartDateTime_UTC = c.StartDateTime_UTC,
                                             EstimatedLength_second = c.EstimatedLength_second,
                                             RemainingTime_second = c.RemainingTime_second,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         }).FirstOrDefault<AppTaskModel>();

            if (appTaskModel == null) 
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.AppTask, ServiceRes.AppTaskID, AppTaskID));

            return appTaskModel;
        }
        public List<AppTaskModel> GetAppTaskModelListWithTVItemIDDB(int TVItemID)
        {
            List<AppTaskModel> AppTaskModelList = (from c in db.AppTasks
                                                   let tvItemIDTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID select cl.TVText).FirstOrDefault<string>()
                                                   let tvItemIDTVText2 = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID2 select cl.TVText).FirstOrDefault<string>()
                                                   let errorText = (from cl in db.AppTaskLanguages where cl.Language == (int)LanguageRequest && cl.AppTaskID == c.AppTaskID select cl.ErrorText).FirstOrDefault<string>()
                                                   let statusText = (from cl in db.AppTaskLanguages where cl.Language == (int)LanguageRequest && cl.AppTaskID == c.AppTaskID select cl.StatusText).FirstOrDefault<string>()
                                                   where c.TVItemID == TVItemID
                                                   orderby c.AppTaskID descending
                                                   select new AppTaskModel
                                                   {
                                                       Error = "",
                                                       AppTaskID = c.AppTaskID,
                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                       TVItemID = c.TVItemID,
                                                       TVItemIDTVText = tvItemIDTVText,
                                                       TVItemID2 = c.TVItemID2,
                                                       TVItemID2TVText = tvItemIDTVText2,
                                                       AppTaskCommand = (AppTaskCommandEnum)c.AppTaskCommand,
                                                       ErrorText = errorText,
                                                       StatusText = statusText,
                                                       AppTaskStatus = (AppTaskStatusEnum)c.AppTaskStatus,
                                                       PercentCompleted = c.PercentCompleted,
                                                       Parameters = c.Parameters,
                                                       Language = (LanguageEnum)c.Language,
                                                       EndDateTime_UTC = c.EndDateTime_UTC,
                                                       StartDateTime_UTC = c.StartDateTime_UTC,
                                                       EstimatedLength_second = c.EstimatedLength_second,
                                                       RemainingTime_second = c.RemainingTime_second,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                   }).ToList<AppTaskModel>();

            return AppTaskModelList;
        }
        public AppTaskModel GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(int TVItemID, int TVItemID2, AppTaskCommandEnum Command)
        {
            AppTaskModel appTaskModel = (from c in db.AppTasks
                                         let tvItemIDTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID select cl.TVText).FirstOrDefault<string>()
                                         let tvItemIDTVText2 = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID2 select cl.TVText).FirstOrDefault<string>()
                                         let errorText = (from cl in db.AppTaskLanguages where cl.Language == (int)LanguageRequest && cl.AppTaskID == c.AppTaskID select cl.ErrorText).FirstOrDefault<string>()
                                         let statusText = (from cl in db.AppTaskLanguages where cl.Language == (int)LanguageRequest && cl.AppTaskID == c.AppTaskID select cl.StatusText).FirstOrDefault<string>()
                                         where c.TVItemID == TVItemID
                                         && c.TVItemID2 == TVItemID2
                                         && c.AppTaskCommand == (int)Command
                                         select new AppTaskModel
                                         {
                                             Error = "",
                                             AppTaskID = c.AppTaskID,
                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                             TVItemID = c.TVItemID,
                                             TVItemIDTVText = tvItemIDTVText,
                                             TVItemID2 = c.TVItemID2,
                                             TVItemID2TVText = tvItemIDTVText2,
                                             AppTaskCommand = (AppTaskCommandEnum)c.AppTaskCommand,
                                             ErrorText = errorText,
                                             StatusText = statusText,
                                             AppTaskStatus = (AppTaskStatusEnum)c.AppTaskStatus,
                                             PercentCompleted = c.PercentCompleted,
                                             Parameters = c.Parameters,
                                             Language = (LanguageEnum)c.Language,
                                             EndDateTime_UTC = c.EndDateTime_UTC,
                                             StartDateTime_UTC = c.StartDateTime_UTC,
                                             EstimatedLength_second = c.EstimatedLength_second,
                                             RemainingTime_second = c.RemainingTime_second,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         }).FirstOrDefault<AppTaskModel>();

            if (appTaskModel == null) 
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.AppTask, ServiceRes.TVItemID + "," + ServiceRes.TVItemID2 + "," + ServiceRes.AppTaskCommand, TVItemID + "," + TVItemID2 + "," + Command.ToString()));

            return appTaskModel;
        }
        public AppTask GetAppTaskWithAppTaskIDDB(int AppTaskID)
        {
            AppTask appTask = (from c in db.AppTasks
                               where c.AppTaskID == AppTaskID
                               select c).FirstOrDefault<AppTask>();
            return appTask;
        }
        public AppTask GetAppTaskWithTVItemIDTVItemID2AndCommandDB(int TVItemID, int TVItemID2, AppTaskCommandEnum AppTaskCommand)
        {
            return (from c in db.AppTasks
                    where c.TVItemID == TVItemID
                    && c.TVItemID2 == TVItemID2
                    && c.AppTaskCommand == (int)AppTaskCommand
                    select c).FirstOrDefault<AppTask>();

        }
        public string GetAppTaskParamStr(string Parameters, string Param)
        {
            string p = Parameters;
            Param = ("|||" + Param + ",");
            if (!p.Contains(Param))
            {
                return "";
            }
            p = p.Substring(p.IndexOf(Param) + Param.Length);
            p = p.Substring(0, p.IndexOf("|||"));
            return p;
        }
        public string RemoveCommaFromParamStr(string Param)
        {
            return Param.Replace(",", "_");
        }

        // Helper   
        public AppTaskModel ReturnError(string Error)
        {
            return new AppTaskModel() { Error = Error };
        }

        // Post
        public AppTaskModel PostAddAppTask(AppTaskModel appTaskModel)
        {
            string retStr = AppTaskModelOK(appTaskModel);
            if (!string.IsNullOrEmpty(retStr)) 
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error)) 
                return ReturnError(contactOK.Error);

            AppTask appTaskExist = GetAppTaskWithTVItemIDTVItemID2AndCommandDB(appTaskModel.TVItemID, appTaskModel.TVItemID2, appTaskModel.AppTaskCommand);
            if (appTaskExist != null) 
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask));

            AppTask appTaskNew = new AppTask();
            retStr = FillAppTask(appTaskNew, appTaskModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr)) 
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.AppTasks.Add(appTaskNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr)) 
                    return ReturnError(retStr);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    AppTaskLanguageModel appTaskLanguageModelNew = new AppTaskLanguageModel()
                    {
                        AppTaskID = appTaskNew.AppTaskID,
                        DBCommand = DBCommandEnum.Original,
                        ErrorText = appTaskModel.ErrorText ?? "",
                        StatusText = appTaskModel.StatusText ?? "",
                        Language = Lang,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    AppTaskLanguageModel appTaskLanguageModelRet = _AppTaskLanguageService.PostAddAppTaskLanguageDB(appTaskLanguageModelNew);
                    if (!string.IsNullOrEmpty(appTaskLanguageModelRet.Error)) 
                        return ReturnError(appTaskLanguageModelRet.Error);
                }

                ts.Complete();
            }
            return GetAppTaskModelWithAppTaskIDDB(appTaskNew.AppTaskID);
        }
        public AppTaskModel PostDeleteAppTaskDB(int AppTaskID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error)) 
                return ReturnError(contactOK.Error);

            AppTask appTaskToDelete = GetAppTaskWithAppTaskIDDB(AppTaskID);
            if (appTaskToDelete == null) 
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.AppTask));

            using (TransactionScope ts = new TransactionScope())
            {
                db.AppTasks.Remove(appTaskToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr)) 
                    return ReturnError(retStr);

                ts.Complete();
            }
            return ReturnError("");
        }
        public AppTaskModel PostUpdateAppTask(AppTaskModel appTaskModel)
        {
            string retStr = AppTaskModelOK(appTaskModel);
            if (!string.IsNullOrEmpty(retStr)) 
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error)) 
                return ReturnError(contactOK.Error);

            AppTask appTaskToUpdate = GetAppTaskWithAppTaskIDDB(appTaskModel.AppTaskID);
            if (appTaskToUpdate == null) 
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.AppTask));

            retStr = FillAppTask(appTaskToUpdate, appTaskModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr)) 
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr)) 
                    return ReturnError(retStr);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    AppTaskLanguageModel appTaskLanguageModel = new AppTaskLanguageModel()
                    {
                        AppTaskID = appTaskModel.AppTaskID,
                        DBCommand = DBCommandEnum.Original,
                        ErrorText = appTaskModel.ErrorText,
                        StatusText = appTaskModel.StatusText,
                        Language = Lang,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    AppTaskLanguageModel appTaskLanguageModelRet = _AppTaskLanguageService.PostUpdateAppTaskLanguageDB(appTaskLanguageModel);
                    if (!string.IsNullOrEmpty(appTaskLanguageModelRet.Error)) 
                        return ReturnError(appTaskLanguageModelRet.Error);
                }

                ts.Complete();
            }
            return GetAppTaskModelWithAppTaskIDDB(appTaskToUpdate.AppTaskID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
