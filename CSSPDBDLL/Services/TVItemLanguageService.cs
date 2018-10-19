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
    public class TVItemLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public TVItemLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string TVItemLanguageModelOK(TVItemLanguageModel tvItemLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(tvItemLanguageModel.TVItemID, ServiceRes.TVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(tvItemLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(tvItemLanguageModel.TVText, ServiceRes.TVText, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillTVItemLanguage(TVItemLanguage tvItemLanguageNew, TVItemLanguageModel tvItemLanguageModel, ContactOK contactOK)
        {
            tvItemLanguageNew.TVItemID = tvItemLanguageModel.TVItemID;
            tvItemLanguageNew.Language = (int)tvItemLanguageModel.Language;
            tvItemLanguageNew.TranslationStatus = (int)tvItemLanguageModel.TranslationStatus;
            tvItemLanguageNew.TVText = tvItemLanguageModel.TVText;
            tvItemLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                tvItemLanguageNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                tvItemLanguageNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetTVItemLanguageModelCountDB()
        {
            return (from c in db.TVItemLanguages
                    select c).Count();
        }
        public TVItemLanguageModel GetTVItemLanguageModelWithTVItemIDAndLanguageDB(int TVItemID, LanguageEnum Language)
        {
            TVItemLanguageModel tvItemLanguageModel = (from c in db.TVItemLanguages
                                                       where c.TVItemID == TVItemID
                                                       && c.Language == (int)Language
                                                       select new TVItemLanguageModel
                                                       {
                                                           Error = "",
                                                           TVItemLanguageID = c.TVItemLanguageID,
                                                           TVItemID = c.TVItemID,
                                                           Language = (LanguageEnum)c.Language,
                                                           TranslationStatus = (TranslationStatusEnum)c.TranslationStatus,
                                                           TVText = c.TVText,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<TVItemLanguageModel>();

            if (tvItemLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemLanguage, ServiceRes.TVItemID + "," + ServiceRes.Language, TVItemID + "," + Language));

            return tvItemLanguageModel;
        }
        public TVItemLanguage GetTVItemLanguageWithTVItemIDAndLanguageDB(int TVItemID, LanguageEnum Language)
        {
            TVItemLanguage tvItemLanguage = (from c in db.TVItemLanguages
                                             where c.TVItemID == TVItemID
                                             && c.Language == (int)Language
                                             select c).FirstOrDefault<TVItemLanguage>();
            return tvItemLanguage;
        }

        // Helper
        public TVItemLanguageModel ReturnError(string Error)
        {
            return new TVItemLanguageModel() { Error = Error };
        }

        // Post
        public TVItemLanguageModel PostAddRootTVItemLanguageDB(TVItemLanguageModel tvItemLanguageModel)
        {
            int TVItemLanguageCount = GetTVItemLanguageModelCountDB();
            if (TVItemLanguageCount > 1)
                return ReturnError(ServiceRes.TVItemRootShouldBeTheFirstOneAdded);

            string retStr = TVItemLanguageModelOK(tvItemLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            TVItemLanguage tvItemLanguageNew = new TVItemLanguage();
            retStr = FillTVItemLanguage(tvItemLanguageNew, tvItemLanguageModel, null);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItemLanguages.Add(tvItemLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemLanguages", tvItemLanguageNew.TVItemLanguageID, LogCommandEnum.Add, tvItemLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemLanguageNew.TVItemID, tvItemLanguageModel.Language);
        }
        public TVItemLanguageModel PostAddTVItemLanguageDB(TVItemLanguageModel tvItemLanguageModel)
        {
            string retStr = TVItemLanguageModelOK(tvItemLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemLanguageModel tvItemLanguageModelExist = GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemLanguageModel.TVItemID, tvItemLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(tvItemLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItemLanguage));

            TVItemLanguage tvItemLanguageNew = new TVItemLanguage();
            retStr = FillTVItemLanguage(tvItemLanguageNew, tvItemLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            db.TVItemLanguages.Add(tvItemLanguageNew);
            retStr = DoAddChanges();
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            LogModel logModel = _LogService.PostAddLogForObj("TVItemLanguages", tvItemLanguageNew.TVItemLanguageID, LogCommandEnum.Add, tvItemLanguageNew);
            if (!string.IsNullOrWhiteSpace(logModel.Error))
                return ReturnError(logModel.Error);

            return GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemLanguageNew.TVItemID, tvItemLanguageModel.Language);
        }
        public TVItemLanguageModel PostAddTVItemContactLanguageDB(TVItemLanguageModel tvItemLanguageModel)
        {
            string retStr = TVItemLanguageModelOK(tvItemLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = null;

            TVItemLanguageModel tvItemLanguageModelExist = GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemLanguageModel.TVItemID, tvItemLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(tvItemLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItemLanguage));

            TVItemLanguage tvItemLanguageNew = new TVItemLanguage();
            retStr = FillTVItemLanguage(tvItemLanguageNew, tvItemLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItemLanguages.Add(tvItemLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemLanguages", tvItemLanguageNew.TVItemLanguageID, LogCommandEnum.Add, tvItemLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemLanguageNew.TVItemID, tvItemLanguageModel.Language);
        }
        public TVItemLanguageModel PostDeleteTVItemLanguageDB(int TVItemID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemLanguage tvItemLanguageToDelete = GetTVItemLanguageWithTVItemIDAndLanguageDB(TVItemID, Language);
            if (tvItemLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVItemLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItemLanguages.Remove(tvItemLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemLanguages", tvItemLanguageToDelete.TVItemLanguageID, LogCommandEnum.Delete, tvItemLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public TVItemLanguageModel PostUpdateTVItemLanguageDB(TVItemLanguageModel tvItemLanguageModel)
        {
            string retStr = TVItemLanguageModelOK(tvItemLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemLanguage tvItemLanguageToUpdate = GetTVItemLanguageWithTVItemIDAndLanguageDB(tvItemLanguageModel.TVItemID, tvItemLanguageModel.Language);
            if (tvItemLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVItemLanguage));

            retStr = FillTVItemLanguage(tvItemLanguageToUpdate, tvItemLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemLanguages", tvItemLanguageToUpdate.TVItemLanguageID, LogCommandEnum.Change, tvItemLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemLanguageToUpdate.TVItemID, (LanguageEnum)tvItemLanguageToUpdate.Language);

        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
