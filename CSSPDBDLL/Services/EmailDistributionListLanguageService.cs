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
using CSSPEnumsDLL.Services;

namespace CSSPDBDLL.Services
{
    public class EmailDistributionListLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _LogService = new LogService(LanguageRequest, User);
            _BaseEnumService = new BaseEnumService(LanguageRequest);
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
        public string EmailDistributionListLanguageModelOK(EmailDistributionListLanguageModel emailDistributionListLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(emailDistributionListLanguageModel.EmailDistributionListID, ServiceRes.EmailDistributionListID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(emailDistributionListLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(emailDistributionListLanguageModel.EmailListName, ServiceRes.EmailListName, 2, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(emailDistributionListLanguageModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillEmailDistributionListLanguageModel(EmailDistributionListLanguage emailDistributionListLanguage, EmailDistributionListLanguageModel emailDistributionListLanguageModel, ContactOK contactOK)
        {
            try
            {
                emailDistributionListLanguage.DBCommand = (int)emailDistributionListLanguageModel.DBCommand;
                emailDistributionListLanguage.EmailDistributionListID = emailDistributionListLanguageModel.EmailDistributionListID;
                emailDistributionListLanguage.Language = (int)emailDistributionListLanguageModel.Language;
                emailDistributionListLanguage.EmailListName = emailDistributionListLanguageModel.EmailListName;
                emailDistributionListLanguage.TranslationStatus = (int)emailDistributionListLanguageModel.TranslationStatus;
                emailDistributionListLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                if (contactOK == null)
                {
                    emailDistributionListLanguage.LastUpdateContactTVItemID = 2;
                }
                else
                {
                    emailDistributionListLanguage.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }

        // Get
        public int GetEmailDistributionListLanguageModelCountDB()
        {
            int EmailDistributionListLanguageModelCount = (from c in db.EmailDistributionListLanguages
                                              select c).Count();


            return EmailDistributionListLanguageModelCount;
        }
        public EmailDistributionListLanguageModel GetEmailDistributionListLanguageModelWithEmailDistributionListIDAndLanguageDB(int EmailDistributionListID, LanguageEnum Language)
        {
            EmailDistributionListLanguageModel emailDistributionListLanguageModel = (from c in db.EmailDistributionListLanguages
                                                           where c.EmailDistributionListID == EmailDistributionListID
                                                           && c.Language == (int)Language
                                                           select new EmailDistributionListLanguageModel
                                                           {
                                                               Error = "",
                                                               EmailDistributionListLanguageID = c.EmailDistributionListLanguageID,
                                                               DBCommand = (DBCommandEnum)c.DBCommand,
                                                               EmailDistributionListID = c.EmailDistributionListID,
                                                               Language = (LanguageEnum)c.Language,
                                                               EmailListName = c.EmailListName,
                                                               TranslationStatus = (TranslationStatusEnum)c.TranslationStatus,
                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                           }).FirstOrDefault<EmailDistributionListLanguageModel>();


            if (emailDistributionListLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.EmailDistributionListLanguage, ServiceRes.EmailDistributionListID + "," + ServiceRes.Language, EmailDistributionListID + "," + Language));

            return emailDistributionListLanguageModel;
        }
        public EmailDistributionListLanguage GetEmailDistributionListLanguageWithEmailDistributionListIDAndLanguageDB(int EmailDistributionListID, LanguageEnum Language)
        {
            EmailDistributionListLanguage emailDistributionListLanguage = (from c in db.EmailDistributionListLanguages
                                                 where c.EmailDistributionListID == EmailDistributionListID
                                                 && c.Language == (int)Language
                                                 select c).FirstOrDefault<EmailDistributionListLanguage>();

            return emailDistributionListLanguage;
        }

        // Helper
        public EmailDistributionListLanguageModel ReturnError(string Error)
        {
            return new EmailDistributionListLanguageModel() { Error = Error };
        }

        // Post
        public EmailDistributionListLanguageModel PostAddEmailDistributionListLanguageDB(EmailDistributionListLanguageModel emailDistributionListLanguageModel)
        {
            string retStr = EmailDistributionListLanguageModelOK(emailDistributionListLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailDistributionListLanguageModel emailDistributionListLanguageModelExist = GetEmailDistributionListLanguageModelWithEmailDistributionListIDAndLanguageDB(emailDistributionListLanguageModel.EmailDistributionListID, emailDistributionListLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(emailDistributionListLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.EmailDistributionListLanguage));

            EmailDistributionListLanguage emailDistributionListLanguageNew = new EmailDistributionListLanguage();
            retStr = FillEmailDistributionListLanguageModel(emailDistributionListLanguageNew, emailDistributionListLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.EmailDistributionListLanguages.Add(emailDistributionListLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("EmailDistributionListLanguages", emailDistributionListLanguageNew.EmailDistributionListLanguageID, LogCommandEnum.Add, emailDistributionListLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetEmailDistributionListLanguageModelWithEmailDistributionListIDAndLanguageDB(emailDistributionListLanguageNew.EmailDistributionListID, (LanguageEnum)emailDistributionListLanguageNew.Language);
        }
        public EmailDistributionListLanguageModel PostDeleteEmailDistributionListLanguageDB(int EmailDistributionListID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailDistributionListLanguage emailDistributionListLanguageToDelete = GetEmailDistributionListLanguageWithEmailDistributionListIDAndLanguageDB(EmailDistributionListID, Language);
            if (emailDistributionListLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.EmailDistributionListLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.EmailDistributionListLanguages.Remove(emailDistributionListLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("EmailDistributionListLanguages", emailDistributionListLanguageToDelete.EmailDistributionListLanguageID, LogCommandEnum.Delete, emailDistributionListLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public EmailDistributionListLanguageModel PostUpdateEmailDistributionListLanguageDB(EmailDistributionListLanguageModel emailDistributionListLanguageModel)
        {
            string retStr = EmailDistributionListLanguageModelOK(emailDistributionListLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailDistributionListLanguage emailDistributionListLanguageToUpdate = GetEmailDistributionListLanguageWithEmailDistributionListIDAndLanguageDB(emailDistributionListLanguageModel.EmailDistributionListID, emailDistributionListLanguageModel.Language);
            if (emailDistributionListLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.EmailDistributionListLanguage));

            retStr = FillEmailDistributionListLanguageModel(emailDistributionListLanguageToUpdate, emailDistributionListLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("EmailDistributionListLanguages", emailDistributionListLanguageToUpdate.EmailDistributionListLanguageID, LogCommandEnum.Change, emailDistributionListLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetEmailDistributionListLanguageModelWithEmailDistributionListIDAndLanguageDB(emailDistributionListLanguageToUpdate.EmailDistributionListID, (LanguageEnum)emailDistributionListLanguageToUpdate.Language);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
