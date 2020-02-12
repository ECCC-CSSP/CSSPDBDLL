using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;


namespace CSSPDBDLL.Services
{
    public class EmailService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public TVItemLinkService _TVItemLinkService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public EmailService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _TVItemLinkService = new TVItemLinkService(LanguageRequest, User);
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
        public string EmailModelOK(EmailModel emailModel)
        {
            string retStr = EmailOK(emailModel.EmailAddress);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.EmailTypeOK(emailModel.EmailType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(emailModel.EmailTVItemID, ServiceRes.EmailTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillEmail(Email emailNew, EmailModel emailModel, ContactOK contactOK)
        {
            emailNew.EmailTVItemID = emailModel.EmailTVItemID;
            emailNew.EmailAddress = emailModel.EmailAddress;
            emailNew.EmailType = (int)emailModel.EmailType;
            emailNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                emailNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                emailNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetEmailModelCountDB()
        {
            int emailModelCount = (from c in db.Emails
                                   select c).Count();

            return emailModelCount;
        }
        public EmailModel GetEmailModelWithEmailIDDB(int EmailID)
        {
            EmailModel emailModel = (from c in db.Emails
                                     where c.EmailID == EmailID
                                     select new EmailModel
                                     {
                                         Error = "",
                                         EmailID = c.EmailID,
                                         EmailTVItemID = c.EmailTVItemID,
                                         EmailAddress = c.EmailAddress,
                                         EmailType = (EmailTypeEnum)c.EmailType,
                                         EmailTypeText = "",
                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                     }).FirstOrDefault<EmailModel>();

            if (emailModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Email, ServiceRes.EmailID, EmailID));
            }
            else
            {
                emailModel.EmailTypeText = _BaseEnumService.GetEnumText_EmailTypeEnum((EmailTypeEnum)emailModel.EmailType);
            }
            return emailModel;
        }
        public EmailModel GetEmailModelExistDB(EmailModel emailModel)
        {
            EmailModel emailModelExist = (from c in db.Emails
                                     where c.EmailAddress == emailModel.EmailAddress
                                     select new EmailModel
                                     {
                                         Error = "",
                                         EmailID = c.EmailID,
                                         EmailTVItemID = c.EmailTVItemID,
                                         EmailAddress = c.EmailAddress,
                                         EmailType = (EmailTypeEnum)c.EmailType,
                                         EmailTypeText = "",
                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                     }).FirstOrDefault<EmailModel>();

            if (emailModelExist == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Email, ServiceRes.EmailAddress, emailModel.EmailAddress));
            }
            else
            {
                emailModelExist.EmailTypeText = _BaseEnumService.GetEnumText_EmailTypeEnum((EmailTypeEnum)emailModel.EmailType);
            }
            return emailModelExist;
        }
        public EmailModel GetEmailModelWithEmailTVItemIDDB(int EmailTVItemID)
        {
            EmailModel emailModel = (from c in db.Emails
                                     where c.EmailTVItemID == EmailTVItemID
                                     select new EmailModel
                                     {
                                         Error = "",
                                         EmailID = c.EmailID,
                                         EmailTVItemID = c.EmailTVItemID,
                                         EmailAddress = c.EmailAddress,
                                         EmailType = (EmailTypeEnum)c.EmailType,
                                         EmailTypeText = "",
                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                     }).FirstOrDefault<EmailModel>();

            if (emailModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Email, ServiceRes.EmailTVItemID, EmailTVItemID));
            }
            else
            {
                emailModel.EmailTypeText = _BaseEnumService.GetEnumText_EmailTypeEnum((EmailTypeEnum)emailModel.EmailType);
            }
            return emailModel;
        }
        public Email GetEmailWithEmailIDDB(int EmailID)
        {
            Email email = (from c in db.Emails
                           where c.EmailID == EmailID
                           select c).FirstOrDefault<Email>();
            return email;
        }

        // Helper
        public string CreateTVText(EmailModel emailModel)
        {
            return emailModel.EmailAddress;
        }
        public EmailModel ReturnError(string Error)
        {
            return new EmailModel() { Error = Error };
        }
        
        // Post
        public EmailModel PostAddOrModifyDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int ContactTVItemID = 0;
            int EmailTVItemID = 0;
            string EmailAddress = "";
            int EmailTypeInt = 0;
            EmailTypeEnum EmailType = EmailTypeEnum.Error;

            int.TryParse(fc["ContactTVItemID"], out ContactTVItemID);
            if (ContactTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID));

            int.TryParse(fc["EmailTVItemID"], out EmailTVItemID);
            // if 0 then want to add new TVItem else want to modify

            EmailAddress = fc["EmailAddress"];
            if (string.IsNullOrWhiteSpace(EmailAddress))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EmailAddress));

            int.TryParse(fc["EmailType"], out EmailTypeInt);
            if (EmailTypeInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EmailType));

            EmailType = (EmailTypeEnum)EmailTypeInt;

            EmailModel EmailModel = new EmailModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (EmailTVItemID == 0)
                {
                    TVItemModel tvItemModelRoot = _TVItemService.GetRootTVItemModelDB();
                    if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
                        return ReturnError(tvItemModelRoot.Error);

                    TVItemModel tvItemModelContact = _TVItemService.GetTVItemModelWithTVItemIDDB(ContactTVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                        return ReturnError(tvItemModelContact.Error);

                    EmailModel EmailModelNew = new EmailModel()
                    {
                        EmailAddress = EmailAddress,
                        EmailType = EmailType,
                    };

                    string TVText = CreateTVText(EmailModelNew);
                    if (string.IsNullOrWhiteSpace(TVText))
                        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                    TVItemModel tvItemModelEmail = _TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Email);
                    if (!string.IsNullOrWhiteSpace(tvItemModelEmail.Error))
                    {
                        // Should add
                        tvItemModelEmail = _TVItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Email);
                        if (!string.IsNullOrWhiteSpace(tvItemModelEmail.Error))
                            return ReturnError(tvItemModelEmail.Error);

                        EmailModelNew.EmailTVItemID = tvItemModelEmail.TVItemID;

                        EmailModel = PostAddEmailDB(EmailModelNew);
                        if (!string.IsNullOrWhiteSpace(EmailModel.Error))
                            return ReturnError(EmailModel.Error);
                    }

                    EmailModel = GetEmailModelWithEmailTVItemIDDB(tvItemModelEmail.TVItemID);
                    if (!string.IsNullOrWhiteSpace(EmailModel.Error))
                        return ReturnError(EmailModel.Error);

                    TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                    {
                        FromTVItemID = tvItemModelContact.TVItemID,
                        ToTVItemID = tvItemModelEmail.TVItemID,
                        FromTVType = tvItemModelContact.TVType,
                        ToTVType = TVTypeEnum.Email,
                        StartDateTime_Local = DateTime.Now,
                        Ordinal = 0,
                        TVLevel = 0,
                        TVPath = "p" + tvItemModelContact.TVItemID + "p" + tvItemModelEmail.TVItemID,
                    };

                    TVItemLinkModel tvItemLinkModel = _TVItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB(tvItemModelContact.TVItemID, tvItemModelEmail.TVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                    {
                        tvItemLinkModel = _TVItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                        if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                            return ReturnError(tvItemLinkModel.Error);
                    }
                }
                else
                {
                    EmailModel EmailModelToChange = GetEmailModelWithEmailTVItemIDDB(EmailTVItemID);
                    if (!string.IsNullOrWhiteSpace(EmailModelToChange.Error))
                        return ReturnError(EmailModelToChange.Error);

                    EmailModelToChange.EmailAddress = EmailAddress;
                    EmailModelToChange.EmailType = EmailType;

                    EmailModel = PostUpdateEmailDB(EmailModelToChange);
                    if (!string.IsNullOrWhiteSpace(EmailModel.Error))
                        return ReturnError(EmailModel.Error);

                    foreach (LanguageEnum Lang in LanguageListAllowable)
                    {
                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(EmailModelToChange.EmailTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);

                        tvItemLanguageModel.TVText = CreateTVText(EmailModelToChange);

                        tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);
                    }
                }

                ts.Complete();
            }

            return EmailModel;
        }
        public EmailModel PostAddEmailDB(EmailModel emailModel)
        {
            string retStr = EmailModelOK(emailModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelEmailExist = _TVItemService.GetTVItemModelWithTVItemIDDB(emailModel.EmailTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelEmailExist.Error))
                return ReturnError(tvItemModelEmailExist.Error);

            Email emailNew = new Email();
            retStr = FillEmail(emailNew, emailModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.Emails.Add(emailNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Emails", emailNew.EmailID, LogCommandEnum.Add, emailNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetEmailModelWithEmailIDDB(emailNew.EmailID);
        }
        public EmailModel PostDeleteEmailDB(int emailID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            Email emailToDelete = GetEmailWithEmailIDDB(emailID);
            if (emailToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Email));

            int TVItemIDToDelete = emailToDelete.EmailTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.Emails.Remove(emailToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Emails", emailToDelete.EmailID, LogCommandEnum.Delete, emailToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemIDToDelete);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnError(tvItemModelRet.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public EmailModel PostDeleteEmailUnderContactTVItemIDDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int ContactTVItemID = 0;
            int EmailTVItemID = 0;

            int.TryParse(fc["ContactTVItemID"], out ContactTVItemID);
            if (ContactTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID));

            int.TryParse(fc["EmailTVItemID"], out EmailTVItemID);
            if (EmailTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EmailTVItemID));

            TVItemModel tvItemModelContact = _TVItemService.GetTVItemModelWithTVItemIDDB(ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                return ReturnError(tvItemModelContact.Error);

            TVItemModel tvItemModelEmail = _TVItemService.GetTVItemModelWithTVItemIDDB(EmailTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelEmail.Error))
                return ReturnError(tvItemModelEmail.Error);

            EmailModel EmailModel = GetEmailModelWithEmailTVItemIDDB(EmailTVItemID);
            if (!string.IsNullOrWhiteSpace(EmailModel.Error))
                return ReturnError(EmailModel.Error);

            using (TransactionScope ts = new TransactionScope())
            {
                TVItemLinkModel tvItemLinkModel = _TVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB(tvItemModelContact.TVItemID, tvItemModelEmail.TVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                    return ReturnError(tvItemLinkModel.Error);

                EmailModel EmailModelDel = PostDeleteEmailDB(EmailModel.EmailID);
                //if (!string.IsNullOrWhiteSpace(EmailModelDel.Error))
                //    return ReturnError(EmailModelDel.Error);

                ts.Complete();
            }

            return new EmailModel() { Error = "" }; // no error
        }
        public EmailModel PostDeleteEmailWithEmailTVItemIDDB(int EmailTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailModel EmailModelToDelete = GetEmailModelWithEmailTVItemIDDB(EmailTVItemID);
            if (!string.IsNullOrWhiteSpace(EmailModelToDelete.Error))
                return ReturnError(EmailModelToDelete.Error);

            EmailModelToDelete = PostDeleteEmailDB(EmailModelToDelete.EmailID);
            if (!string.IsNullOrWhiteSpace(EmailModelToDelete.Error))
                return ReturnError(EmailModelToDelete.Error);

            return ReturnError("");
        }
        public EmailModel PostUpdateEmailDB(EmailModel emailModel)
        {
            string retStr = EmailModelOK(emailModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            Email emailToUpdate = GetEmailWithEmailIDDB(emailModel.EmailID);
            if (emailToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Email));

            retStr = FillEmail(emailToUpdate, emailModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Emails", emailToUpdate.EmailID, LogCommandEnum.Change, emailToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        TVItemLanguageModel tvItemLanguageModelToUpdate = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(emailToUpdate.EmailTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.Error))
                            return ReturnError(tvItemLanguageModelToUpdate.Error);

                        tvItemLanguageModelToUpdate.TVText = CreateTVText(emailModel);
                        if (string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.TVText))
                            return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelToUpdate);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);
                    }
                }

                ts.Complete();
            }
            return GetEmailModelWithEmailIDDB(emailToUpdate.EmailID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}

