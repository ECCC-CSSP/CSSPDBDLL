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
    public class InfrastructureLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string InfrastructureLanguageModelOK(InfrastructureLanguageModel infrastructureLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(infrastructureLanguageModel.InfrastructureID, ServiceRes.InfrastructureID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(infrastructureLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(infrastructureLanguageModel.Comment, ServiceRes.Comment, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillInfrastructureLanguage(InfrastructureLanguage infrastructureLanguageNew, InfrastructureLanguageModel infrastructureLanguageModel, ContactOK contactOK)
        {
            infrastructureLanguageNew.InfrastructureID = infrastructureLanguageModel.InfrastructureID;
            infrastructureLanguageNew.Language = (int)infrastructureLanguageModel.Language;
            infrastructureLanguageNew.TranslationStatus = (int)infrastructureLanguageModel.TranslationStatus;
            infrastructureLanguageNew.Comment = infrastructureLanguageModel.Comment;
            infrastructureLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                infrastructureLanguageNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                infrastructureLanguageNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetInfrastructureLanguageModelCountDB()
        {
            int InfrastructureLanguageModelCount = (from c in db.InfrastructureLanguages
                                                    select c).Count();

            return InfrastructureLanguageModelCount;
        }
        public InfrastructureLanguageModel GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(int InfrastructureID, LanguageEnum Language)
        {
            InfrastructureLanguageModel infrastructureLanguageModel = (from c in db.InfrastructureLanguages
                                                                       where c.InfrastructureID == InfrastructureID
                                                                       && c.Language == (int)Language
                                                                       select new InfrastructureLanguageModel
                                                                       {
                                                                           Error = "",
                                                                           InfrastructureID = c.InfrastructureID,
                                                                           Language = (LanguageEnum)c.Language,
                                                                           Comment = c.Comment,
                                                                           TranslationStatus = (TranslationStatusEnum)c.TranslationStatus,
                                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                       }).FirstOrDefault<InfrastructureLanguageModel>();
            if (infrastructureLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.InfrastructureLanguage, ServiceRes.InfrastructureID + "," + ServiceRes.Language, InfrastructureID.ToString() + "," + Language));

            return infrastructureLanguageModel;
        }
        public InfrastructureLanguage GetInfrastructureLanguageWithInfrastructureIDAndLanguageDB(int InfrastructureID, LanguageEnum Language)
        {
            InfrastructureLanguage InfrastructureLanguage = (from c in db.InfrastructureLanguages
                                                             where c.InfrastructureID == InfrastructureID
                                                             && c.Language == (int)Language
                                                             select c).FirstOrDefault<InfrastructureLanguage>();

            return InfrastructureLanguage;
        }

        // Helper
        public InfrastructureLanguageModel ReturnError(string Error)
        {
            return new InfrastructureLanguageModel() { Error = Error };
        }

        // Post
        public InfrastructureLanguageModel PostAddInfrastructureLanguageDB(InfrastructureLanguageModel infrastructureLanguageModel)
        {
            string retStr = InfrastructureLanguageModelOK(infrastructureLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            InfrastructureLanguageModel infrastructureLanguageModelExist = GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureLanguageModel.InfrastructureID, infrastructureLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(infrastructureLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.InfrastructureLanguage));

            InfrastructureLanguage infrastructureLanguageNew = new InfrastructureLanguage();
            retStr = FillInfrastructureLanguage(infrastructureLanguageNew, infrastructureLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.InfrastructureLanguages.Add(infrastructureLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("InfrastructureLanguages", infrastructureLanguageNew.InfrastructureLanguageID, LogCommandEnum.Add, infrastructureLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureLanguageNew.InfrastructureID, infrastructureLanguageModel.Language);
        }
        public InfrastructureLanguageModel PostDeleteInfrastructureLanguageDB(int InfrastructureID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            InfrastructureLanguage infrastructureLanguageToDelete = GetInfrastructureLanguageWithInfrastructureIDAndLanguageDB(InfrastructureID, Language);
            if (infrastructureLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.InfrastructureLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.InfrastructureLanguages.Remove(infrastructureLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("InfrastructureLanguages", infrastructureLanguageToDelete.InfrastructureLanguageID, LogCommandEnum.Delete, infrastructureLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public InfrastructureLanguageModel PostUpdateInfrastructureLanguageDB(InfrastructureLanguageModel infrastructureLanguageModel)
        {
            string retStr = InfrastructureLanguageModelOK(infrastructureLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            InfrastructureLanguage infrastructureLanguageToUpdate = GetInfrastructureLanguageWithInfrastructureIDAndLanguageDB(infrastructureLanguageModel.InfrastructureID, infrastructureLanguageModel.Language);
            if (infrastructureLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.InfrastructureLanguage));

            retStr = FillInfrastructureLanguage(infrastructureLanguageToUpdate, infrastructureLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("InfrastructureLanguages", infrastructureLanguageToUpdate.InfrastructureLanguageID, LogCommandEnum.Change, infrastructureLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureLanguageToUpdate.InfrastructureID, (LanguageEnum)infrastructureLanguageToUpdate.Language);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
