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
    public class MWQMRunLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string MWQMRunLanguageModelOK(MWQMRunLanguageModel mwqmRunLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(mwqmRunLanguageModel.MWQMRunID, ServiceRes.MWQMRunID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(mwqmRunLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(mwqmRunLanguageModel.RunComment, ServiceRes.RunComment, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(mwqmRunLanguageModel.RunWeatherComment, ServiceRes.RunWeatherComment, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }


            return "";
        }

        // Fill
        public string FillMWQMRunLanguage(MWQMRunLanguage mwqmRunLanguageNew, MWQMRunLanguageModel mwqmRunLanguageModel, ContactOK contactOK)
        {
            mwqmRunLanguageNew.MWQMRunID = mwqmRunLanguageModel.MWQMRunID;
            mwqmRunLanguageNew.Language = (int)mwqmRunLanguageModel.Language;
            mwqmRunLanguageNew.TranslationStatusRunComment = (int)mwqmRunLanguageModel.TranslationStatusRunComment;
            mwqmRunLanguageNew.RunComment = mwqmRunLanguageModel.RunComment;
            mwqmRunLanguageNew.TranslationStatusRunWeatherComment = (int)mwqmRunLanguageModel.TranslationStatusRunWeatherComment;
            mwqmRunLanguageNew.RunWeatherComment = mwqmRunLanguageModel.RunWeatherComment;
            mwqmRunLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mwqmRunLanguageNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mwqmRunLanguageNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMWQMRunLanguageModelCountDB()
        {
            int MWQMRunLanguageModelCount = (from c in db.MWQMRunLanguages
                                             select c).Count();

            return MWQMRunLanguageModelCount;
        }
        public MWQMRunLanguageModel GetMWQMRunLanguageModelWithMWQMRunIDAndLanguageDB(int MWQMRunID, LanguageEnum Language)
        {
            MWQMRunLanguageModel MWQMRunLanguageModel = (from c in db.MWQMRunLanguages
                                                         where c.MWQMRunID == MWQMRunID
                                                         && c.Language == (int)Language
                                                         select new MWQMRunLanguageModel
                                                         {
                                                             Error = "",
                                                             MWQMRunID = c.MWQMRunID,
                                                             MWQMRunLanguageID = c.MWQMRunLanguageID,
                                                             Language = (LanguageEnum)c.Language,
                                                             TranslationStatusRunComment = (TranslationStatusEnum)c.TranslationStatusRunComment,
                                                             RunComment = c.RunComment,
                                                             TranslationStatusRunWeatherComment = (TranslationStatusEnum)c.TranslationStatusRunWeatherComment,
                                                             RunWeatherComment = c.RunWeatherComment,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).FirstOrDefault<MWQMRunLanguageModel>();
            if (MWQMRunLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMRunLanguage, ServiceRes.MWQMRunID + "," + ServiceRes.Language, MWQMRunID.ToString() + "," + Language));

            return MWQMRunLanguageModel;
        }
        public MWQMRunLanguage GetMWQMRunLanguageWithMWQMRunIDAndLanguageDB(int MWQMRunID, LanguageEnum Language)
        {
            MWQMRunLanguage MWQMRunLanguage = (from c in db.MWQMRunLanguages
                                               where c.MWQMRunID == MWQMRunID
                                               && c.Language == (int)Language
                                               select c).FirstOrDefault<MWQMRunLanguage>();

            return MWQMRunLanguage;
        }

        // Helper
        public MWQMRunLanguageModel ReturnError(string Error)
        {
            return new MWQMRunLanguageModel() { Error = Error };
        }

        // Post
        public MWQMRunLanguageModel PostAddMWQMRunLanguageDB(MWQMRunLanguageModel mwqmRunLanguageModel)
        {
            string retStr = MWQMRunLanguageModelOK(mwqmRunLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMRunLanguageModel mwqmRunLanguageModelExist = GetMWQMRunLanguageModelWithMWQMRunIDAndLanguageDB(mwqmRunLanguageModel.MWQMRunID, mwqmRunLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(mwqmRunLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMRunLanguage));

            MWQMRunLanguage mwqmRunLanguageNew = new MWQMRunLanguage();
            retStr = FillMWQMRunLanguage(mwqmRunLanguageNew, mwqmRunLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMRunLanguages.Add(mwqmRunLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMRunLanguages", mwqmRunLanguageNew.MWQMRunLanguageID, LogCommandEnum.Add, mwqmRunLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMRunLanguageModelWithMWQMRunIDAndLanguageDB(mwqmRunLanguageNew.MWQMRunID, (LanguageEnum)mwqmRunLanguageNew.Language);
        }
        public MWQMRunLanguageModel PostDeleteMWQMRunLanguageDB(int MWQMRunID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMRunLanguage mwqmRunLanguageToDelete = GetMWQMRunLanguageWithMWQMRunIDAndLanguageDB(MWQMRunID, Language);
            if (mwqmRunLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMRunLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMRunLanguages.Remove(mwqmRunLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMRunLanguages", mwqmRunLanguageToDelete.MWQMRunLanguageID, LogCommandEnum.Delete, mwqmRunLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public MWQMRunLanguageModel PostUpdateMWQMRunLanguageDB(MWQMRunLanguageModel mwqmRunLanguageModel)
        {
            string retStr = MWQMRunLanguageModelOK(mwqmRunLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMRunLanguage mwqmRunLanguageToUpdate = GetMWQMRunLanguageWithMWQMRunIDAndLanguageDB(mwqmRunLanguageModel.MWQMRunID, mwqmRunLanguageModel.Language);
            if (mwqmRunLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMRunLanguage));

            retStr = FillMWQMRunLanguage(mwqmRunLanguageToUpdate, mwqmRunLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMRunLanguages", mwqmRunLanguageToUpdate.MWQMRunLanguageID, LogCommandEnum.Change, mwqmRunLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMRunLanguageModelWithMWQMRunIDAndLanguageDB(mwqmRunLanguageToUpdate.MWQMRunID, mwqmRunLanguageModel.Language);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
