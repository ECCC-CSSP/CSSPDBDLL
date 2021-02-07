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
    public class AppTaskLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string AppTaskLanguageModelOK(AppTaskLanguageModel appTaskLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(appTaskLanguageModel.AppTaskID, ServiceRes.AppTaskID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(appTaskLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(appTaskLanguageModel.ErrorText, ServiceRes.ErrorText, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(appTaskLanguageModel.StatusText, ServiceRes.StatusText, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(appTaskLanguageModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillAppTaskLanguage(AppTaskLanguage appTaskLanguageNew, AppTaskLanguageModel appTaskLanguageModel, ContactOK contactOK)
        {
            appTaskLanguageNew.DBCommand = (int)appTaskLanguageModel.DBCommand;
            appTaskLanguageNew.AppTaskID = appTaskLanguageModel.AppTaskID;
            appTaskLanguageNew.Language = (int)appTaskLanguageModel.Language;
            appTaskLanguageNew.TranslationStatus = (int)appTaskLanguageModel.TranslationStatus;
            appTaskLanguageNew.StatusText = appTaskLanguageModel.StatusText;
            appTaskLanguageNew.ErrorText = appTaskLanguageModel.ErrorText;
            appTaskLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                appTaskLanguageNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                appTaskLanguageNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetAppTaskLanguageModelCountDB()
        {
            int AppTaskLanguageModelCount = (from c in db.AppTaskLanguages
                                             select c).Count();

            return AppTaskLanguageModelCount;
        }
        public AppTaskLanguageModel GetAppTaskLanguageModelWithAppTaskIDAndLanguageDB(int AppTaskID, LanguageEnum Language)
        {
            AppTaskLanguageModel appTaskLanguageModel = (from c in db.AppTaskLanguages
                                                         where c.AppTaskID == AppTaskID
                                                         && c.Language == (int)Language
                                                         select new AppTaskLanguageModel
                                                         {
                                                             Error = "",
                                                             AppTaskLanguageID = c.AppTaskLanguageID,
                                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                                             AppTaskID = (int)c.AppTaskID,
                                                             Language = (LanguageEnum)c.Language,
                                                             TranslationStatus = (TranslationStatusEnum)c.TranslationStatus,
                                                             StatusText = c.StatusText,
                                                             ErrorText = c.ErrorText,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).FirstOrDefault<AppTaskLanguageModel>();

            if (appTaskLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.AppTaskLanguage, ServiceRes.AppTaskID + "," + ServiceRes.Language, AppTaskID.ToString() + "," + Language));

            return appTaskLanguageModel;
        }
        public AppTaskLanguage GetAppTaskLanguageWithAppTaskIDAndLanguageDB(int AppTaskID, LanguageEnum Language)
        {
            AppTaskLanguage AppTaskLanguage = (from c in db.AppTaskLanguages
                                               where c.AppTaskID == AppTaskID
                                               && c.Language == (int)Language
                                               select c).FirstOrDefault<AppTaskLanguage>();

            return AppTaskLanguage;
        }

        // Helper
        public AppTaskLanguageModel ReturnError(string Error)
        {
            return new AppTaskLanguageModel() { Error = Error };
        }

        // Post
        public AppTaskLanguageModel PostAddAppTaskLanguageDB(AppTaskLanguageModel appTaskLanguageModel)
        {
            string retStr = AppTaskLanguageModelOK(appTaskLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            AppTaskLanguageModel appTaskLanguageModelExist = GetAppTaskLanguageModelWithAppTaskIDAndLanguageDB(appTaskLanguageModel.AppTaskID, appTaskLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(appTaskLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTaskLanguage));

            AppTaskLanguage appTaskLanguageNew = new AppTaskLanguage();
            retStr = FillAppTaskLanguage(appTaskLanguageNew, appTaskLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.AppTaskLanguages.Add(appTaskLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("AppTaskLanguages", appTaskLanguageNew.AppTaskLanguageID, LogCommandEnum.Add, appTaskLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);


                ts.Complete();
            }
            return GetAppTaskLanguageModelWithAppTaskIDAndLanguageDB((int)appTaskLanguageNew.AppTaskID, appTaskLanguageModel.Language);
        }
        public AppTaskLanguageModel PostDeleteAppTaskLanguageDB(int AppTaskID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            AppTaskLanguage appTaskLanguageToDelete = GetAppTaskLanguageWithAppTaskIDAndLanguageDB(AppTaskID, Language);
            if (appTaskLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.AppTaskLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.AppTaskLanguages.Remove(appTaskLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("AppTaskLanguages", appTaskLanguageToDelete.AppTaskLanguageID, LogCommandEnum.Delete, appTaskLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError(""); ;
        }
        public AppTaskLanguageModel PostUpdateAppTaskLanguageDB(AppTaskLanguageModel appTaskLanguageModel)
        {
            string retStr = AppTaskLanguageModelOK(appTaskLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            AppTaskLanguage appTaskLanguageToUpdate = GetAppTaskLanguageWithAppTaskIDAndLanguageDB(appTaskLanguageModel.AppTaskID, appTaskLanguageModel.Language);
            if (appTaskLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.AppTaskLanguage));

            retStr = FillAppTaskLanguage(appTaskLanguageToUpdate, appTaskLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                try
                {
                    LogModel logModel = _LogService.PostAddLogForObj("AppTaskLanguages", appTaskLanguageToUpdate.AppTaskLanguageID, LogCommandEnum.Change, appTaskLanguageToUpdate);
                    if (!string.IsNullOrWhiteSpace(logModel.Error))
                        return ReturnError(logModel.Error);

                }
                catch (Exception)
                {
                    // nothing for now
                }

                ts.Complete();
            }
            return GetAppTaskLanguageModelWithAppTaskIDAndLanguageDB((int)appTaskLanguageToUpdate.AppTaskID, (LanguageEnum)appTaskLanguageToUpdate.Language);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
