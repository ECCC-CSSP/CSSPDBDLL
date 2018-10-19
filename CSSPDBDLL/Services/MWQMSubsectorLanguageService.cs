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
    public class MWQMSubsectorLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string MWQMSubsectorLanguageModelOK(MWQMSubsectorLanguageModel mwqmSubsectorLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(mwqmSubsectorLanguageModel.MWQMSubsectorID, ServiceRes.MWQMSubsectorID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(mwqmSubsectorLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(mwqmSubsectorLanguageModel.SubsectorDesc, ServiceRes.SubsectorDesc, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMWQMSubsectorLanguage(MWQMSubsectorLanguage mwqmSubsectorLanguageNew, MWQMSubsectorLanguageModel mwqmSubsectorLanguageModel, ContactOK contactOK)
        {
            mwqmSubsectorLanguageNew.MWQMSubsectorID = mwqmSubsectorLanguageModel.MWQMSubsectorID;
            mwqmSubsectorLanguageNew.Language = (int)mwqmSubsectorLanguageModel.Language;
            mwqmSubsectorLanguageNew.SubsectorDesc = mwqmSubsectorLanguageModel.SubsectorDesc;
            mwqmSubsectorLanguageNew.TranslationStatusSubsectorDesc = (int)mwqmSubsectorLanguageModel.TranslationStatusSubsectorDesc;
            mwqmSubsectorLanguageNew.LogBook = mwqmSubsectorLanguageModel.LogBook;
            mwqmSubsectorLanguageNew.TranslationStatusLogBook = (int)mwqmSubsectorLanguageModel.TranslationStatusLogBook;
            mwqmSubsectorLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mwqmSubsectorLanguageNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mwqmSubsectorLanguageNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMWQMSubsectorLanguageModelCountDB()
        {
            int MWQMSubsectorLanguageModelCount = (from c in db.MWQMSubsectorLanguages
                                                   select c).Count();

            return MWQMSubsectorLanguageModelCount;
        }
        public MWQMSubsectorLanguageModel GetMWQMSubsectorLanguageModelWithMWQMSubsectorIDAndLanguageDB(int MWQMSubsectorID, LanguageEnum Language)
        {
            MWQMSubsectorLanguageModel mwqmSubsectorLanguageModel = (from c in db.MWQMSubsectorLanguages
                                                                     where c.MWQMSubsectorID == MWQMSubsectorID
                                                                     && c.Language == (int)Language
                                                                     select new MWQMSubsectorLanguageModel
                                                                     {
                                                                         Error = "",
                                                                         MWQMSubsectorID = c.MWQMSubsectorID,
                                                                         Language = (LanguageEnum)c.Language,
                                                                         SubsectorDesc = c.SubsectorDesc,
                                                                         TranslationStatusSubsectorDesc = (TranslationStatusEnum)c.TranslationStatusSubsectorDesc,
                                                                         LogBook = c.LogBook,
                                                                         TranslationStatusLogBook = (TranslationStatusEnum)c.TranslationStatusLogBook,
                                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                     }).FirstOrDefault<MWQMSubsectorLanguageModel>();

            if (mwqmSubsectorLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSubsectorLanguage, ServiceRes.MWQMSubsectorID + "," + ServiceRes.Language, MWQMSubsectorID.ToString() + "," + Language));

            return mwqmSubsectorLanguageModel;
        }
        public MWQMSubsectorLanguage GetMWQMSubsectorLanguageWithMWQMSubsectorIDAndLanguageDB(int MWQMSubsectorID, LanguageEnum Language)
        {
            MWQMSubsectorLanguage mwqmSubsectorLanguage = (from c in db.MWQMSubsectorLanguages
                                                           where c.MWQMSubsectorID == MWQMSubsectorID
                                                           && c.Language == (int)Language
                                                           select c).FirstOrDefault<MWQMSubsectorLanguage>();

            return mwqmSubsectorLanguage;
        }

        // Helper
        public MWQMSubsectorLanguageModel ReturnError(string Error)
        {
            return new MWQMSubsectorLanguageModel() { Error = Error };
        }

        // Post
        public MWQMSubsectorLanguageModel PostAddMWQMSubsectorLanguageDB(MWQMSubsectorLanguageModel mwqmSubsectorLanguageModel)
        {
            string retStr = MWQMSubsectorLanguageModelOK(mwqmSubsectorLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelExist = GetMWQMSubsectorLanguageModelWithMWQMSubsectorIDAndLanguageDB(mwqmSubsectorLanguageModel.MWQMSubsectorID, mwqmSubsectorLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(mwqmSubsectorLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMSubsectorLanguage));

            MWQMSubsectorLanguage mwqmSubsectorLanguageNew = new MWQMSubsectorLanguage();
            retStr = FillMWQMSubsectorLanguage(mwqmSubsectorLanguageNew, mwqmSubsectorLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSubsectorLanguages.Add(mwqmSubsectorLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSubsectorLanguages", mwqmSubsectorLanguageNew.MWQMSubsectorLanguageID, LogCommandEnum.Add, mwqmSubsectorLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMSubsectorLanguageModelWithMWQMSubsectorIDAndLanguageDB(mwqmSubsectorLanguageNew.MWQMSubsectorID, mwqmSubsectorLanguageModel.Language);
        }
        public MWQMSubsectorLanguageModel PostDeleteMWQMSubsectorLanguageDB(int MWQMSubsectorID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSubsectorLanguage mwqmSubsectorLanguageToDelete = GetMWQMSubsectorLanguageWithMWQMSubsectorIDAndLanguageDB(MWQMSubsectorID, Language);
            if (mwqmSubsectorLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMSubsectorLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSubsectorLanguages.Remove(mwqmSubsectorLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSubsectorLanguages", mwqmSubsectorLanguageToDelete.MWQMSubsectorLanguageID, LogCommandEnum.Delete, mwqmSubsectorLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public MWQMSubsectorLanguageModel PostUpdateMWQMSubsectorLanguageDB(MWQMSubsectorLanguageModel mwqmSubsectorLanguageModel)
        {
            string retStr = MWQMSubsectorLanguageModelOK(mwqmSubsectorLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);


            MWQMSubsectorLanguage mwqmSubsectorLanguageToUpdate = GetMWQMSubsectorLanguageWithMWQMSubsectorIDAndLanguageDB(mwqmSubsectorLanguageModel.MWQMSubsectorID, mwqmSubsectorLanguageModel.Language);
            if (mwqmSubsectorLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSubsectorLanguage));

            retStr = FillMWQMSubsectorLanguage(mwqmSubsectorLanguageToUpdate, mwqmSubsectorLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSubsectorLanguages", mwqmSubsectorLanguageToUpdate.MWQMSubsectorLanguageID, LogCommandEnum.Change, mwqmSubsectorLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMSubsectorLanguageModelWithMWQMSubsectorIDAndLanguageDB(mwqmSubsectorLanguageToUpdate.MWQMSubsectorID, mwqmSubsectorLanguageModel.Language);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}

