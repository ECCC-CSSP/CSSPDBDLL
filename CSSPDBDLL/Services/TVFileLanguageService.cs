using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class TVFileLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string TVFileLanguageModelOK(TVFileLanguageModel tvFileLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(tvFileLanguageModel.TVFileID, ServiceRes.TVFileID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(tvFileLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(tvFileLanguageModel.FileDescription, ServiceRes.FileDescription, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillTVFileLanguage(TVFileLanguage tvFileLanguageNew, TVFileLanguageModel tvFileLanguageModel, ContactOK contactOK)
        {
            tvFileLanguageNew.TVFileID = tvFileLanguageModel.TVFileID;
            tvFileLanguageNew.Language = (int)tvFileLanguageModel.Language;
            tvFileLanguageNew.TranslationStatus = (int)tvFileLanguageModel.TranslationStatus;
            tvFileLanguageNew.FileDescription = tvFileLanguageModel.FileDescription;
            tvFileLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                tvFileLanguageNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                tvFileLanguageNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetTVFileLanguageModelCountDB()
        {
            return (from c in db.TVFileLanguages
                    select c).Count();
        }
        public TVFileLanguageModel GetTVFileLanguageModelWithTVFileIDAndLanguageDB(int TVFileID, LanguageEnum Language)
        {
            TVFileLanguageModel tvFileLanguageModel = (from c in db.TVFileLanguages
                                                       where c.TVFileID == TVFileID
                                                       && c.Language == (int)Language
                                                       select new TVFileLanguageModel
                                                       {
                                                           Error = "",
                                                           TVFileLanguageID = c.TVFileLanguageID,
                                                           TVFileID = c.TVFileID,
                                                           Language = (LanguageEnum)c.Language,
                                                           TranslationStatus = (TranslationStatusEnum)c.TranslationStatus,
                                                           FileDescription = c.FileDescription,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<TVFileLanguageModel>();

            if (tvFileLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVFileLanguage, ServiceRes.TVFileID + "," + ServiceRes.Language, TVFileID + "," + Language));

            return tvFileLanguageModel;
        }
        public TVFileLanguage GetTVFileLanguageWithTVFileIDAndLanguageDB(int TVFileID, LanguageEnum Language)
        {
            TVFileLanguage tvFileLanguage = (from c in db.TVFileLanguages
                                             where c.TVFileID == TVFileID
                                             && c.Language == (int)Language
                                             select c).FirstOrDefault<TVFileLanguage>();
            return tvFileLanguage;
        }

        // Helper
        public TVFileLanguageModel ReturnError(string Error)
        {
            return new TVFileLanguageModel() { Error = Error };
        }

        // Post
        public TVFileLanguageModel PostAddTVFileLanguageDB(TVFileLanguageModel tvFileLanguageModel)
        {
            string retStr = TVFileLanguageModelOK(tvFileLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVFileLanguageModel tvFileLanguageModelExist = GetTVFileLanguageModelWithTVFileIDAndLanguageDB(tvFileLanguageModel.TVFileID, tvFileLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(tvFileLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVFileLanguage));

            TVFileLanguage tvFileLanguageNew = new TVFileLanguage();
            retStr = FillTVFileLanguage(tvFileLanguageNew, tvFileLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            db.TVFileLanguages.Add(tvFileLanguageNew);
            retStr = DoAddChanges();
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            LogModel logModel = _LogService.PostAddLogForObj("TVFileLanguages", tvFileLanguageNew.TVFileLanguageID, LogCommandEnum.Add, tvFileLanguageNew);
            if (!string.IsNullOrWhiteSpace(logModel.Error))
                return ReturnError(logModel.Error);

            return GetTVFileLanguageModelWithTVFileIDAndLanguageDB(tvFileLanguageNew.TVFileID, tvFileLanguageModel.Language);
        }
        public TVFileLanguageModel PostAddTVFileContactLanguageDB(TVFileLanguageModel tvFileLanguageModel)
        {
            string retStr = TVFileLanguageModelOK(tvFileLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = null;

            TVFileLanguageModel tvFileLanguageModelExist = GetTVFileLanguageModelWithTVFileIDAndLanguageDB(tvFileLanguageModel.TVFileID, tvFileLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(tvFileLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVFileLanguage));

            TVFileLanguage tvFileLanguageNew = new TVFileLanguage();
            retStr = FillTVFileLanguage(tvFileLanguageNew, tvFileLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVFileLanguages.Add(tvFileLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVFileLanguages", tvFileLanguageNew.TVFileLanguageID, LogCommandEnum.Add, tvFileLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetTVFileLanguageModelWithTVFileIDAndLanguageDB(tvFileLanguageNew.TVFileID, tvFileLanguageModel.Language);
        }
        public TVFileLanguageModel PostDeleteTVFileLanguageDB(int TVFileID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVFileLanguage tvFileLanguageToDelete = GetTVFileLanguageWithTVFileIDAndLanguageDB(TVFileID, Language);
            if (tvFileLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVFileLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVFileLanguages.Remove(tvFileLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVFileLanguages", tvFileLanguageToDelete.TVFileLanguageID, LogCommandEnum.Delete, tvFileLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public TVFileLanguageModel PostUpdateTVFileLanguageDB(TVFileLanguageModel tvFileLanguageModel)
        {
            string retStr = TVFileLanguageModelOK(tvFileLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVFileLanguage tvFileLanguageToUpdate = GetTVFileLanguageWithTVFileIDAndLanguageDB(tvFileLanguageModel.TVFileID, tvFileLanguageModel.Language);
            if (tvFileLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVFileLanguage));

            retStr = FillTVFileLanguage(tvFileLanguageToUpdate, tvFileLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVFileLanguages", tvFileLanguageToUpdate.TVFileLanguageID, LogCommandEnum.Change, tvFileLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetTVFileLanguageModelWithTVFileIDAndLanguageDB(tvFileLanguageToUpdate.TVFileID, (LanguageEnum)tvFileLanguageToUpdate.Language);

        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
