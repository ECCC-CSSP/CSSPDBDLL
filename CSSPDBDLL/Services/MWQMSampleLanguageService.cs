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
    public class MWQMSampleLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string MWQMSampleLanguageModelOK(MWQMSampleLanguageModel mwqmSampleLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(mwqmSampleLanguageModel.MWQMSampleID, ServiceRes.MWQMSampleID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(mwqmSampleLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(mwqmSampleLanguageModel.MWQMSampleNote, ServiceRes.MWQMSampleNote, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMWQMSampleLanguage(MWQMSampleLanguage mwqmSampleLanguageNew, MWQMSampleLanguageModel mwqmSampleLanguageModel, ContactOK contactOK)
        {
            mwqmSampleLanguageNew.MWQMSampleID = mwqmSampleLanguageModel.MWQMSampleID;
            mwqmSampleLanguageNew.Language = (int)mwqmSampleLanguageModel.Language;
            mwqmSampleLanguageNew.TranslationStatus = (int)mwqmSampleLanguageModel.TranslationStatus;
            mwqmSampleLanguageNew.MWQMSampleNote = mwqmSampleLanguageModel.MWQMSampleNote;
            mwqmSampleLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mwqmSampleLanguageNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mwqmSampleLanguageNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMWQMSampleLanguageModelCountDB()
        {
            int MWQMSampleLanguageModelCount = (from c in db.MWQMSampleLanguages
                                                select c).Count();

            return MWQMSampleLanguageModelCount;
        }
        public MWQMSampleLanguageModel GetMWQMSampleLanguageModelWithMWQMSampleIDAndLanguageDB(int MWQMSampleID, LanguageEnum Language)
        {
            MWQMSampleLanguageModel mwqmSampleLanguageModel = (from c in db.MWQMSampleLanguages
                                                               where c.MWQMSampleID == MWQMSampleID
                                                               && c.Language == (int)Language
                                                               select new MWQMSampleLanguageModel
                                                               {
                                                                   Error = "",
                                                                   MWQMSampleID = c.MWQMSampleID,
                                                                   Language = (LanguageEnum)c.Language,
                                                                   TranslationStatus = (TranslationStatusEnum)c.TranslationStatus,
                                                                   MWQMSampleNote = c.MWQMSampleNote,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                               }).FirstOrDefault<MWQMSampleLanguageModel>();

            if (mwqmSampleLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSampleLanguage, ServiceRes.MWQMSampleID + "," + ServiceRes.Language, MWQMSampleID.ToString() + "," + Language));

            return mwqmSampleLanguageModel;
        }
        public MWQMSampleLanguage GetMWQMSampleLanguageWithMWQMSampleIDAndLanguageDB(int MWQMSampleID, LanguageEnum Language)
        {
            MWQMSampleLanguage mwqmSampleLanguage = (from c in db.MWQMSampleLanguages
                                                     where c.MWQMSampleID == MWQMSampleID
                                                     && c.Language == (int)Language
                                                     select c).FirstOrDefault<MWQMSampleLanguage>();

            return mwqmSampleLanguage;
        }

        // Helper
        public MWQMSampleLanguageModel ReturnError(string Error)
        {
            return new MWQMSampleLanguageModel() { Error = Error };
        }

        // Post
        public MWQMSampleLanguageModel PostAddMWQMSampleLanguageDB(MWQMSampleLanguageModel mwqmSampleLanguageModel)
        {
            string retStr = MWQMSampleLanguageModelOK(mwqmSampleLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSampleLanguageModel mwqmSampleLanguageModelExist = GetMWQMSampleLanguageModelWithMWQMSampleIDAndLanguageDB(mwqmSampleLanguageModel.MWQMSampleID, mwqmSampleLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(mwqmSampleLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMSampleLanguage));

            MWQMSampleLanguage mwqmSampleLanguageNew = new MWQMSampleLanguage();
            retStr = FillMWQMSampleLanguage(mwqmSampleLanguageNew, mwqmSampleLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSampleLanguages.Add(mwqmSampleLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSampleLanguages", mwqmSampleLanguageNew.MWQMSampleLanguageID, LogCommandEnum.Add, mwqmSampleLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMSampleLanguageModelWithMWQMSampleIDAndLanguageDB(mwqmSampleLanguageNew.MWQMSampleID, mwqmSampleLanguageModel.Language);
        }
        public MWQMSampleLanguageModel PostDeleteMWQMSampleLanguageDB(int MWQMSampleID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSampleLanguage mwqmSampleLanguageToDelete = GetMWQMSampleLanguageWithMWQMSampleIDAndLanguageDB(MWQMSampleID, Language);
            if (mwqmSampleLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMSampleLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSampleLanguages.Remove(mwqmSampleLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSampleLanguages", mwqmSampleLanguageToDelete.MWQMSampleLanguageID, LogCommandEnum.Delete, mwqmSampleLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public MWQMSampleLanguageModel PostUpdateMWQMSampleLanguageDB(MWQMSampleLanguageModel mwqmSampleLanguageModel)
        {
            string retStr = MWQMSampleLanguageModelOK(mwqmSampleLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSampleLanguage mwqmSampleLanguageToUpdate = GetMWQMSampleLanguageWithMWQMSampleIDAndLanguageDB(mwqmSampleLanguageModel.MWQMSampleID, mwqmSampleLanguageModel.Language);
            if (mwqmSampleLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSampleLanguage));

            retStr = FillMWQMSampleLanguage(mwqmSampleLanguageToUpdate, mwqmSampleLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSampleLanguages", mwqmSampleLanguageToUpdate.MWQMSampleLanguageID, LogCommandEnum.Change, mwqmSampleLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMSampleLanguageModelWithMWQMSampleIDAndLanguageDB(mwqmSampleLanguageToUpdate.MWQMSampleID, mwqmSampleLanguageModel.Language);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
