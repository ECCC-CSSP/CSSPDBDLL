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
    public class SpillLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string SpillLanguageModelOK(SpillLanguageModel spillLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(spillLanguageModel.SpillID, ServiceRes.SpillID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(spillLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(spillLanguageModel.SpillComment, ServiceRes.SpillComment, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillSpillLanguage(SpillLanguage spillLanguageNew, SpillLanguageModel spillLanguageModel, ContactOK contactOK)
        {
            spillLanguageNew.SpillID = spillLanguageModel.SpillID;
            spillLanguageNew.Language = (int)spillLanguageModel.Language;
            spillLanguageNew.TranslationStatus = (int)spillLanguageModel.TranslationStatus;
            spillLanguageNew.SpillComment = spillLanguageModel.SpillComment;
            spillLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                spillLanguageNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                spillLanguageNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetSpillLanguageModelCountDB()
        {
            int SpillLanguageModelCount = (from c in db.SpillLanguages
                                           select c).Count();

            return SpillLanguageModelCount;
        }
        public SpillLanguageModel GetSpillLanguageModelWithSpillIDAndLanguageDB(int SpillID, LanguageEnum Language)
        {
            SpillLanguageModel spillLanguageModel = (from c in db.SpillLanguages
                                                     where c.SpillID == SpillID
                                                     && c.Language == (int)Language
                                                     select new SpillLanguageModel
                                                     {
                                                         Error = "",
                                                         SpillID = c.SpillID,
                                                         Language = (LanguageEnum)c.Language,
                                                         TranslationStatus = (TranslationStatusEnum)c.TranslationStatus,
                                                         SpillComment = c.SpillComment,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<SpillLanguageModel>();
            if (spillLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.SpillLanguage, ServiceRes.SpillID + "," + ServiceRes.Language, SpillID.ToString() + "," + Language));

            return spillLanguageModel;
        }
        public SpillLanguage GetSpillLanguageWithSpillIDAndLanguageDB(int SpillID, LanguageEnum Language)
        {
            SpillLanguage spillLanguage = (from c in db.SpillLanguages
                                           where c.SpillID == SpillID
                                           && c.Language == (int)Language
                                           select c).FirstOrDefault<SpillLanguage>();

            return spillLanguage;
        }

        // Helper
        public SpillLanguageModel ReturnError(string Error)
        {
            return new SpillLanguageModel() { Error = Error };
        }

        // Post
        public SpillLanguageModel PostAddSpillLanguageDB(SpillLanguageModel spillLanguageModel)
        {
            string retStr = SpillLanguageModelOK(spillLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SpillLanguageModel spillLanguageModelExist = GetSpillLanguageModelWithSpillIDAndLanguageDB(spillLanguageModel.SpillID, spillLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(spillLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.SpillLanguage));

            SpillLanguage spillLanguageNew = new SpillLanguage();
            retStr = FillSpillLanguage(spillLanguageNew, spillLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.SpillLanguages.Add(spillLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SpillLanguages", spillLanguageNew.SpillLanguageID, LogCommandEnum.Add, spillLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetSpillLanguageModelWithSpillIDAndLanguageDB(spillLanguageNew.SpillID, spillLanguageModel.Language);
        }
        public SpillLanguageModel PostDeleteSpillLanguageDB(int SpillID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SpillLanguage spillLanguageToDelete = GetSpillLanguageWithSpillIDAndLanguageDB(SpillID, Language);
            if (spillLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.SpillLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.SpillLanguages.Remove(spillLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SpillLanguages", spillLanguageToDelete.SpillLanguageID, LogCommandEnum.Delete, spillLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public SpillLanguageModel PostUpdateSpillLanguageDB(SpillLanguageModel spillLanguageModel)
        {
            string retStr = SpillLanguageModelOK(spillLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SpillLanguage spillLanguageToUpdate = GetSpillLanguageWithSpillIDAndLanguageDB(spillLanguageModel.SpillID, spillLanguageModel.Language);
            if (spillLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.SpillLanguage));

            retStr = FillSpillLanguage(spillLanguageToUpdate, spillLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SpillLanguages", spillLanguageToUpdate.SpillLanguageID, LogCommandEnum.Change, spillLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetSpillLanguageModelWithSpillIDAndLanguageDB(spillLanguageToUpdate.SpillID, spillLanguageModel.Language);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
