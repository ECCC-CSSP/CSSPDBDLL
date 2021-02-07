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
    public class EmailDistributionListContactLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string EmailDistributionListContactLanguageModelOK(EmailDistributionListContactLanguageModel emailDistributionListContactLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(emailDistributionListContactLanguageModel.EmailDistributionListContactID, ServiceRes.EmailDistributionListContactID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(emailDistributionListContactLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(emailDistributionListContactLanguageModel.Agency, ServiceRes.Agency, 2, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(emailDistributionListContactLanguageModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillEmailDistributionListContactLanguageModel(EmailDistributionListContactLanguage emailDistributionListContactLanguage, EmailDistributionListContactLanguageModel emailDistributionListContactLanguageModel, ContactOK contactOK)
        {
            try
            {
                emailDistributionListContactLanguage.DBCommand = (int)emailDistributionListContactLanguageModel.DBCommand;
                emailDistributionListContactLanguage.EmailDistributionListContactID = emailDistributionListContactLanguageModel.EmailDistributionListContactID;
                emailDistributionListContactLanguage.Language = (int)emailDistributionListContactLanguageModel.Language;
                emailDistributionListContactLanguage.Agency = emailDistributionListContactLanguageModel.Agency;
                emailDistributionListContactLanguage.TranslationStatus = (int)emailDistributionListContactLanguageModel.TranslationStatus;
                emailDistributionListContactLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                if (contactOK == null)
                {
                    emailDistributionListContactLanguage.LastUpdateContactTVItemID = 2;
                }
                else
                {
                    emailDistributionListContactLanguage.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }

        // Get
        public int GetEmailDistributionListContactLanguageModelCountDB()
        {
            int EmailDistributionListContactLanguageModelCount = (from c in db.EmailDistributionListContactLanguages
                                              select c).Count();


            return EmailDistributionListContactLanguageModelCount;
        }
        public EmailDistributionListContactLanguageModel GetEmailDistributionListContactLanguageModelWithEmailDistributionListContactIDAndLanguageDB(int EmailDistributionListContactID, LanguageEnum Language)
        {
            EmailDistributionListContactLanguageModel emailDistributionListContactLanguageModel = (from c in db.EmailDistributionListContactLanguages
                                                           where c.EmailDistributionListContactID == EmailDistributionListContactID
                                                           && c.Language == (int)Language
                                                           select new EmailDistributionListContactLanguageModel
                                                           {
                                                               Error = "",
                                                               EmailDistributionListContactLanguageID = c.EmailDistributionListContactLanguageID,
                                                               DBCommand = (DBCommandEnum)c.DBCommand,
                                                               EmailDistributionListContactID = c.EmailDistributionListContactID,
                                                               Language = (LanguageEnum)c.Language,
                                                               Agency = c.Agency,
                                                               TranslationStatus = (TranslationStatusEnum)c.TranslationStatus,
                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                           }).FirstOrDefault<EmailDistributionListContactLanguageModel>();


            if (emailDistributionListContactLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.EmailDistributionListContactLanguage, ServiceRes.EmailDistributionListContactID + "," + ServiceRes.Language, EmailDistributionListContactID + "," + Language));

            return emailDistributionListContactLanguageModel;
        }
        public EmailDistributionListContactLanguage GetEmailDistributionListContactLanguageWithEmailDistributionListContactIDAndLanguageDB(int EmailDistributionListContactID, LanguageEnum Language)
        {
            EmailDistributionListContactLanguage emailDistributionListContactLanguage = (from c in db.EmailDistributionListContactLanguages
                                                 where c.EmailDistributionListContactID == EmailDistributionListContactID
                                                 && c.Language == (int)Language
                                                 select c).FirstOrDefault<EmailDistributionListContactLanguage>();

            return emailDistributionListContactLanguage;
        }

        // Helper
        public EmailDistributionListContactLanguageModel ReturnError(string Error)
        {
            return new EmailDistributionListContactLanguageModel() { Error = Error };
        }

        // Post
        public EmailDistributionListContactLanguageModel PostAddEmailDistributionListContactLanguageDB(EmailDistributionListContactLanguageModel emailDistributionListContactLanguageModel)
        {
            string retStr = EmailDistributionListContactLanguageModelOK(emailDistributionListContactLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailDistributionListContactLanguageModel emailDistributionListContactLanguageModelExist = GetEmailDistributionListContactLanguageModelWithEmailDistributionListContactIDAndLanguageDB(emailDistributionListContactLanguageModel.EmailDistributionListContactID, emailDistributionListContactLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(emailDistributionListContactLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.EmailDistributionListContactLanguage));

            EmailDistributionListContactLanguage emailDistributionListContactLanguageNew = new EmailDistributionListContactLanguage();
            retStr = FillEmailDistributionListContactLanguageModel(emailDistributionListContactLanguageNew, emailDistributionListContactLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.EmailDistributionListContactLanguages.Add(emailDistributionListContactLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("EmailDistributionListContactLanguages", emailDistributionListContactLanguageNew.EmailDistributionListContactLanguageID, LogCommandEnum.Add, emailDistributionListContactLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetEmailDistributionListContactLanguageModelWithEmailDistributionListContactIDAndLanguageDB(emailDistributionListContactLanguageNew.EmailDistributionListContactID, (LanguageEnum)emailDistributionListContactLanguageNew.Language);
        }
        public EmailDistributionListContactLanguageModel PostDeleteEmailDistributionListContactLanguageDB(int EmailDistributionListContactID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailDistributionListContactLanguage emailDistributionListContactLanguageToDelete = GetEmailDistributionListContactLanguageWithEmailDistributionListContactIDAndLanguageDB(EmailDistributionListContactID, Language);
            if (emailDistributionListContactLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.EmailDistributionListContactLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.EmailDistributionListContactLanguages.Remove(emailDistributionListContactLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("EmailDistributionListContactLanguages", emailDistributionListContactLanguageToDelete.EmailDistributionListContactLanguageID, LogCommandEnum.Delete, emailDistributionListContactLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public EmailDistributionListContactLanguageModel PostUpdateEmailDistributionListContactLanguageDB(EmailDistributionListContactLanguageModel emailDistributionListContactLanguageModel)
        {
            string retStr = EmailDistributionListContactLanguageModelOK(emailDistributionListContactLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailDistributionListContactLanguage emailDistributionListContactLanguageToUpdate = GetEmailDistributionListContactLanguageWithEmailDistributionListContactIDAndLanguageDB(emailDistributionListContactLanguageModel.EmailDistributionListContactID, emailDistributionListContactLanguageModel.Language);
            if (emailDistributionListContactLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.EmailDistributionListContactLanguage));

            retStr = FillEmailDistributionListContactLanguageModel(emailDistributionListContactLanguageToUpdate, emailDistributionListContactLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("EmailDistributionListContactLanguages", emailDistributionListContactLanguageToUpdate.EmailDistributionListContactLanguageID, LogCommandEnum.Change, emailDistributionListContactLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetEmailDistributionListContactLanguageModelWithEmailDistributionListContactIDAndLanguageDB(emailDistributionListContactLanguageToUpdate.EmailDistributionListContactID, (LanguageEnum)emailDistributionListContactLanguageToUpdate.Language);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
