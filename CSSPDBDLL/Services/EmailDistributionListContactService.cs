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
    public class EmailDistributionListContactService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public TVItemLinkService _TVItemLinkService { get; private set; }
        public LogService _LogService { get; private set; }
        public EmailDistributionListContactLanguageService _EmailDistributionListContactLanguageService { get; private set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListContactService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _TVItemLinkService = new TVItemLinkService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
            _EmailDistributionListContactLanguageService = new EmailDistributionListContactLanguageService(LanguageRequest, User);
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
        public string EmailDistributionListContactModelOK(EmailDistributionListContactModel emailDistributionListContactModel)
        {
            string retStr = FieldCheckNotZeroInt(emailDistributionListContactModel.EmailDistributionListID, ServiceRes.EmailDistributionListID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(emailDistributionListContactModel.Agency, ServiceRes.Agency, 1, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(emailDistributionListContactModel.Name, ServiceRes.Name, 1, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(emailDistributionListContactModel.Email, ServiceRes.Email, 1, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = EmailOK(emailDistributionListContactModel.Email);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(emailDistributionListContactModel.CMPRainfallSeasonal, ServiceRes.CMPRainfallSeasonal);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(emailDistributionListContactModel.CMPWastewater, ServiceRes.CMPWastewater);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(emailDistributionListContactModel.EmergencyWeather, ServiceRes.EmergencyWeather);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(emailDistributionListContactModel.EmergencyWastewater, ServiceRes.EmergencyWastewater);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(emailDistributionListContactModel.ReopeningAllTypes, ServiceRes.ReopeningAllTypes);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(emailDistributionListContactModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillEmailDistributionListContact(EmailDistributionListContact emailDistributionListContactNew, EmailDistributionListContactModel emailDistributionListContactModel, ContactOK contactOK)
        {
            emailDistributionListContactNew.DBCommand = (int)emailDistributionListContactModel.DBCommand;
            emailDistributionListContactNew.EmailDistributionListID = emailDistributionListContactModel.EmailDistributionListID;
            emailDistributionListContactNew.IsCC = emailDistributionListContactModel.IsCC;
            //emailDistributionListContactNew.Agency = emailDistributionListContactModel.Agency;
            emailDistributionListContactNew.Name = emailDistributionListContactModel.Name;
            emailDistributionListContactNew.Email = emailDistributionListContactModel.Email;
            emailDistributionListContactNew.CMPRainfallSeasonal = emailDistributionListContactModel.CMPRainfallSeasonal;
            emailDistributionListContactNew.CMPWastewater = emailDistributionListContactModel.CMPWastewater;
            emailDistributionListContactNew.EmergencyWeather = emailDistributionListContactModel.EmergencyWeather;
            emailDistributionListContactNew.EmergencyWastewater = emailDistributionListContactModel.EmergencyWastewater;
            emailDistributionListContactNew.ReopeningAllTypes = emailDistributionListContactModel.ReopeningAllTypes;
            emailDistributionListContactNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                emailDistributionListContactNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                emailDistributionListContactNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetEmailDistributionListContactModelCountDB()
        {
            int emailDistributionListContactModelCount = (from c in db.EmailDistributionListContacts
                                                          select c).Count();

            return emailDistributionListContactModelCount;
        }

        public List<EmailDistributionListContactModel> GetEmailDistributionListContactModelListWithEmailDistributionListIDDB(int EmailDistributionListID)
        {
            List<EmailDistributionListContactModel> emailDistributionListContactModelList = (from c in db.EmailDistributionListContacts
                                                                                             from cl in db.EmailDistributionListContactLanguages
                                                                                             where c.EmailDistributionListContactID == cl.EmailDistributionListContactID
                                                                                             && c.EmailDistributionListID == EmailDistributionListID
                                                                                             && cl.Language == (int)LanguageRequest
                                                                                             orderby c.IsCC, cl.Agency, c.Name, c.Email
                                                                                             select new EmailDistributionListContactModel
                                                                                             {
                                                                                                 Error = "",
                                                                                                 EmailDistributionListContactID = c.EmailDistributionListContactID,
                                                                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                                                                 IsCC = c.IsCC,
                                                                                                 Agency = cl.Agency,
                                                                                                 Name = c.Name,
                                                                                                 Email = c.Email,
                                                                                                 CMPRainfallSeasonal = c.CMPRainfallSeasonal,
                                                                                                 CMPWastewater = c.CMPWastewater,
                                                                                                 EmergencyWeather = c.EmergencyWeather,
                                                                                                 EmergencyWastewater = c.EmergencyWastewater,
                                                                                                 ReopeningAllTypes = c.ReopeningAllTypes,
                                                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                             }).ToList<EmailDistributionListContactModel>();

            return emailDistributionListContactModelList;
        }
        public EmailDistributionListContactModel GetEmailDistributionListContactModelWithEmailDistributionListContactIDDB(int EmailDistributionListContactID)
        {
            EmailDistributionListContactModel emailDistributionListContactModel = (from c in db.EmailDistributionListContacts
                                                                                   from cl in db.EmailDistributionListContactLanguages
                                                                                   where c.EmailDistributionListContactID == cl.EmailDistributionListContactID
                                                                                   && c.EmailDistributionListContactID == EmailDistributionListContactID
                                                                                   && cl.Language == (int)LanguageRequest
                                                                                   select new EmailDistributionListContactModel
                                                                                   {
                                                                                       Error = "",
                                                                                       EmailDistributionListContactID = c.EmailDistributionListContactID,
                                                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                                                       IsCC = c.IsCC,
                                                                                       Agency = cl.Agency,
                                                                                       Name = c.Name,
                                                                                       Email = c.Email,
                                                                                       CMPRainfallSeasonal = c.CMPRainfallSeasonal,
                                                                                       CMPWastewater = c.CMPWastewater,
                                                                                       EmergencyWeather = c.EmergencyWeather,
                                                                                       EmergencyWastewater = c.EmergencyWastewater,
                                                                                       ReopeningAllTypes = c.ReopeningAllTypes,
                                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                   }).FirstOrDefault<EmailDistributionListContactModel>();

            if (emailDistributionListContactModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.EmailDistributionListContact, ServiceRes.EmailDistributionListContactID, EmailDistributionListContactID));
            }

            return emailDistributionListContactModel;
        }
        public EmailDistributionListContact GetEmailDistributionListContactWithEmailDistributionListContactIDDB(int EmailDistributionListContactID)
        {
            EmailDistributionListContact emailDistributionListContact = (from c in db.EmailDistributionListContacts
                                                                         where c.EmailDistributionListContactID == EmailDistributionListContactID
                                                                         select c).FirstOrDefault<EmailDistributionListContact>();
            return emailDistributionListContact;
        }

        // Helper
        public EmailDistributionListContactModel ReturnError(string Error)
        {
            return new EmailDistributionListContactModel() { Error = Error };
        }

        // Post
        public EmailDistributionListContactModel PostEmailDistributionListContactSaveDB(FormCollection fc)
        {
            int EmailDistributionListContactID = 0;
            int EmailDistributionListID = 0;
            bool IsCC = false;
            string Agency = "";
            string Name = "";
            string Email = "";
            bool CMPRainfallSeasonal = false;
            bool CMPWastewater = false;
            bool EmergencyWeather = false;
            bool EmergencyWastewater = false;
            bool ReopeningAllTypes = false;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int.TryParse(fc["EmailDistributionListContactID"], out EmailDistributionListContactID);
            // can be 0, if 0 then we want to add a new one

            int.TryParse(fc["EmailDistributionListID"], out EmailDistributionListID);
            if (EmailDistributionListID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EmailDistributionListID));

            if (!string.IsNullOrWhiteSpace(fc["IsCC"]))
            {
                IsCC = true;
            }

            Agency = fc["Agency"];
            if (string.IsNullOrWhiteSpace(Agency))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Agency));

            Name = fc["Name"];
            if (string.IsNullOrWhiteSpace(Name))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Name));

            Email = fc["Email"];
            if (string.IsNullOrWhiteSpace(Email))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Email));

            if (!string.IsNullOrWhiteSpace(fc["CMPRainfallSeasonal"]))
            {
                CMPRainfallSeasonal = true;
            }

            if (!string.IsNullOrWhiteSpace(fc["CMPWastewater"]))
            {
                CMPWastewater = true;
            }

            if (!string.IsNullOrWhiteSpace(fc["EmergencyWeather"]))
            {
                EmergencyWeather = true;
            }

            if (!string.IsNullOrWhiteSpace(fc["EmergencyWastewater"]))
            {
                EmergencyWastewater = true;
            }

            if (!string.IsNullOrWhiteSpace(fc["ReopeningAllTypes"]))
            {
                ReopeningAllTypes = true;
            }

            EmailDistributionListContactModel emailDistributionListContactModel = new EmailDistributionListContactModel();
            if (EmailDistributionListContactID > 0)
            {
                emailDistributionListContactModel = GetEmailDistributionListContactModelWithEmailDistributionListContactIDDB(EmailDistributionListContactID);
                if (!string.IsNullOrWhiteSpace(emailDistributionListContactModel.Error))
                    return ReturnError(emailDistributionListContactModel.Error);

            }

            emailDistributionListContactModel.DBCommand = DBCommandEnum.Original;
            emailDistributionListContactModel.EmailDistributionListID = EmailDistributionListID;
            emailDistributionListContactModel.IsCC = IsCC;
            emailDistributionListContactModel.Agency = Agency;
            emailDistributionListContactModel.Name = Name;
            emailDistributionListContactModel.Email = Email;
            emailDistributionListContactModel.CMPRainfallSeasonal = CMPRainfallSeasonal;
            emailDistributionListContactModel.CMPWastewater = CMPWastewater;
            emailDistributionListContactModel.EmergencyWeather = EmergencyWeather;
            emailDistributionListContactModel.EmergencyWastewater = EmergencyWastewater;
            emailDistributionListContactModel.ReopeningAllTypes = ReopeningAllTypes;

            EmailDistributionListContactModel emailDistributionListModelContactRet = new EmailDistributionListContactModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (EmailDistributionListContactID == 0)
                {
                    emailDistributionListModelContactRet = PostAddEmailDistributionListContactDB(emailDistributionListContactModel);
                    if (!string.IsNullOrWhiteSpace(emailDistributionListModelContactRet.Error))
                        return ReturnError(emailDistributionListModelContactRet.Error);

                }
                else
                {
                    emailDistributionListModelContactRet = PostUpdateEmailDistributionListContactDB(emailDistributionListContactModel);
                    if (!string.IsNullOrWhiteSpace(emailDistributionListModelContactRet.Error))
                        return ReturnError(emailDistributionListModelContactRet.Error);

                }

                ts.Complete();
            }
            return GetEmailDistributionListContactModelWithEmailDistributionListContactIDDB(emailDistributionListModelContactRet.EmailDistributionListContactID);
        }
        public EmailDistributionListContactModel PostAddEmailDistributionListContactDB(EmailDistributionListContactModel emailDistributionListContactModel)
        {
            string retStr = EmailDistributionListContactModelOK(emailDistributionListContactModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailDistributionListContact emailDistributionListContactNew = new EmailDistributionListContact();
            retStr = FillEmailDistributionListContact(emailDistributionListContactNew, emailDistributionListContactModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.EmailDistributionListContacts.Add(emailDistributionListContactNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("EmailDistributionListContacts", emailDistributionListContactNew.EmailDistributionListContactID, LogCommandEnum.Add, emailDistributionListContactNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    EmailDistributionListContactLanguageModel emailDistributionListContactLanguageModel = new EmailDistributionListContactLanguageModel()
                    {
                        DBCommand = DBCommandEnum.Original,
                        EmailDistributionListContactID = emailDistributionListContactNew.EmailDistributionListContactID,
                        Language = Lang,
                        Agency = emailDistributionListContactModel.Agency,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    EmailDistributionListContactLanguageModel emailDistributionListContactLanguageModelRet = _EmailDistributionListContactLanguageService.PostAddEmailDistributionListContactLanguageDB(emailDistributionListContactLanguageModel);
                    if (!string.IsNullOrEmpty(emailDistributionListContactLanguageModelRet.Error))
                        return ReturnError(string.Format(ServiceRes.CouldNotAddError_, emailDistributionListContactLanguageModelRet.Error));
                }

                ts.Complete();
            }
            return GetEmailDistributionListContactModelWithEmailDistributionListContactIDDB(emailDistributionListContactNew.EmailDistributionListContactID);
        }
        public EmailDistributionListContactModel PostDeleteEmailDistributionListContactDB(int emailDistributionListContactID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailDistributionListContact emailDistributionListContactToDelete = GetEmailDistributionListContactWithEmailDistributionListContactIDDB(emailDistributionListContactID);
            if (emailDistributionListContactToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.EmailDistributionListContact));

            using (TransactionScope ts = new TransactionScope())
            {
                db.EmailDistributionListContacts.Remove(emailDistributionListContactToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("EmailDistributionListContacts", emailDistributionListContactToDelete.EmailDistributionListContactID, LogCommandEnum.Delete, emailDistributionListContactToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public EmailDistributionListContactModel PostUpdateEmailDistributionListContactDB(EmailDistributionListContactModel emailDistributionListContactModel)
        {
            string retStr = EmailDistributionListContactModelOK(emailDistributionListContactModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailDistributionListContact emailDistributionListContactToUpdate = GetEmailDistributionListContactWithEmailDistributionListContactIDDB(emailDistributionListContactModel.EmailDistributionListContactID);
            if (emailDistributionListContactToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.EmailDistributionListContact));

            retStr = FillEmailDistributionListContact(emailDistributionListContactToUpdate, emailDistributionListContactModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("EmailDistributionListContacts", emailDistributionListContactToUpdate.EmailDistributionListContactID, LogCommandEnum.Change, emailDistributionListContactToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        EmailDistributionListContactLanguageModel emailDistributionListContactLanguageModel = new EmailDistributionListContactLanguageModel()
                        {
                            DBCommand = DBCommandEnum.Original,
                            EmailDistributionListContactID = emailDistributionListContactToUpdate.EmailDistributionListContactID,
                            Language = Lang,
                            Agency = emailDistributionListContactModel.Agency,
                            TranslationStatus = TranslationStatusEnum.Translated,
                        };

                        EmailDistributionListContactLanguageModel emailDistributionListContactLanguageModelRet = _EmailDistributionListContactLanguageService.PostUpdateEmailDistributionListContactLanguageDB(emailDistributionListContactLanguageModel);
                        if (!string.IsNullOrEmpty(emailDistributionListContactLanguageModelRet.Error))
                            return ReturnError(string.Format(ServiceRes.CouldNotAddError_, emailDistributionListContactLanguageModelRet.Error));
                    }
                }

                ts.Complete();
            }
            return GetEmailDistributionListContactModelWithEmailDistributionListContactIDDB(emailDistributionListContactToUpdate.EmailDistributionListContactID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}

