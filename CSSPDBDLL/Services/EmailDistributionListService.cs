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
    public class EmailDistributionListService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public TVItemLinkService _TVItemLinkService { get; private set; }
        public LogService _LogService { get; private set; }
        public AppTaskService _AppTaskService { get; private set; }
        public EmailDistributionListLanguageService _EmailDistributionListLanguageService { get; private set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _TVItemLinkService = new TVItemLinkService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _EmailDistributionListLanguageService = new EmailDistributionListLanguageService(LanguageRequest, User);
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
        public string EmailDistributionListModelOK(EmailDistributionListModel emailDistributionListModel)
        {
            string retStr = FieldCheckNotZeroInt(emailDistributionListModel.ParentTVItemID, ServiceRes.ParentTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(emailDistributionListModel.EmailListName, ServiceRes.Name, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(emailDistributionListModel.Ordinal, ServiceRes.Ordinal, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillEmailDistributionList(EmailDistributionList emailDistributionListNew, EmailDistributionListModel emailDistributionListModel, ContactOK contactOK)
        {
            emailDistributionListNew.EmailDistributionListID = emailDistributionListModel.EmailDistributionListID;
            emailDistributionListNew.ParentTVItemID = emailDistributionListModel.ParentTVItemID;
            emailDistributionListNew.Ordinal = emailDistributionListModel.Ordinal;
            emailDistributionListNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                emailDistributionListNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                emailDistributionListNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetEmailDistributionListModelCountDB()
        {
            int emailDistributionListModelCount = (from c in db.EmailDistributionLists
                                                   select c).Count();

            return emailDistributionListModelCount;
        }
        public List<EmailDistributionListModel> GetEmailDistributionListModelListWithEmailDistributionListIDsDB(List<int> EmailDistributionListIDList)
        {
            List<EmailDistributionListModel> emailDistributionListModelList = (from c in db.EmailDistributionLists
                                                                               from cl in db.EmailDistributionListLanguages
                                                                               from l in EmailDistributionListIDList
                                                                               where c.EmailDistributionListID == cl.EmailDistributionListID
                                                                               && c.EmailDistributionListID == l
                                                                               && cl.Language == (int)LanguageRequest
                                                                               orderby c.Ordinal
                                                                               select new EmailDistributionListModel
                                                                               {
                                                                                   Error = "",
                                                                                   EmailDistributionListID = c.EmailDistributionListID,
                                                                                   ParentTVItemID = c.ParentTVItemID,
                                                                                   EmailListName = cl.EmailListName,
                                                                                   Ordinal = c.Ordinal,
                                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                               }).ToList<EmailDistributionListModel>();

            return emailDistributionListModelList;
        }
        public EmailDistributionListModel GetEmailDistributionListModelWithEmailDistributionListIDDB(int EmailDistributionListID)
        {
            EmailDistributionListModel emailDistributionListModel = (from c in db.EmailDistributionLists
                                                                     from cl in db.EmailDistributionListLanguages
                                                                     where c.EmailDistributionListID == cl.EmailDistributionListID
                                                                     && c.EmailDistributionListID == EmailDistributionListID
                                                                     && cl.Language == (int)LanguageRequest
                                                                     select new EmailDistributionListModel
                                                                     {
                                                                         Error = "",
                                                                         EmailDistributionListID = c.EmailDistributionListID,
                                                                         ParentTVItemID = c.ParentTVItemID,
                                                                         EmailListName = cl.EmailListName,
                                                                         Ordinal = c.Ordinal,
                                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                     }).FirstOrDefault<EmailDistributionListModel>();

            if (emailDistributionListModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.EmailDistributionList, ServiceRes.EmailDistributionListID, EmailDistributionListID));
            }

            return emailDistributionListModel;
        }
        public List<EmailDistributionListModel> GetEmailDistributionListModelWithParentTVItemIDDB(int ParentTVItemID)
        {
            List<EmailDistributionListModel> emailDistributionListModelList = (from c in db.EmailDistributionLists
                                                                               from cl in db.EmailDistributionListLanguages
                                                                               let ContactLastUpdate = (from cc in db.EmailDistributionListContacts
                                                                                                        where cc.EmailDistributionListID == c.EmailDistributionListID
                                                                                                        orderby cc.LastUpdateDate_UTC descending
                                                                                                        select cc.LastUpdateDate_UTC).FirstOrDefault()
                                                                               let lastModifiedBy = (from cc in db.EmailDistributionListContacts
                                                                                                     from t in db.TVItemLanguages
                                                                                                     where cc.LastUpdateContactTVItemID == t.TVItemID
                                                                                                     && cc.EmailDistributionListID == c.EmailDistributionListID
                                                                                                     select t.TVText).FirstOrDefault()
                                                                               where c.EmailDistributionListID == cl.EmailDistributionListID
                                                                               && c.ParentTVItemID == ParentTVItemID
                                                                               && cl.Language == (int)LanguageRequest
                                                                               orderby c.Ordinal
                                                                               select new EmailDistributionListModel
                                                                               {
                                                                                   Error = "",
                                                                                   EmailDistributionListID = c.EmailDistributionListID,
                                                                                   ParentTVItemID = c.ParentTVItemID,
                                                                                   EmailListName = cl.EmailListName,
                                                                                   Ordinal = c.Ordinal,
                                                                                   LastModifiedBy = lastModifiedBy,
                                                                                   LastUpdateDate_UTC = ContactLastUpdate,
                                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                               }).ToList<EmailDistributionListModel>();

            return emailDistributionListModelList;
        }
        public EmailDistributionList GetEmailDistributionListWithEmailDistributionListIDDB(int EmailDistributionListID)
        {
            EmailDistributionList emailDistributionList = (from c in db.EmailDistributionLists
                                                           where c.EmailDistributionListID == EmailDistributionListID
                                                           select c).FirstOrDefault<EmailDistributionList>();

            return emailDistributionList;
        }

        // Helper
        public AppTaskModel ReturnAppTaskError(string Error)
        {
            return new AppTaskModel() { Error = Error };
        }
        public EmailDistributionListModel ReturnError(string Error)
        {
            return new EmailDistributionListModel() { Error = Error };
        }

        // Post
        public AppTaskModel EmailDistributionListGenerateExcelFileDB(int ParentTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnAppTaskError(contactOK.Error);

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(ParentTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return ReturnAppTaskError(tvItemModel.Error);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ParentTVItemID", Value = ParentTVItemID.ToString() });

            StringBuilder sbParameters = new StringBuilder();
            int count = 0;
            foreach (AppTaskParameter atp in appTaskParameterList)
            {
                if (count == 0)
                {
                    sbParameters.Append("|||");
                }
                sbParameters.Append(atp.Name + "," + atp.Value + "|||");
                count += 1;
            }

            AppTaskModel appTaskModelNew = new AppTaskModel()
            {
                TVItemID = ParentTVItemID,
                TVItemID2 = ParentTVItemID,
                AppTaskCommand = AppTaskCommandEnum.ExportEmailDistributionLists,
                ErrorText = "",
                StatusText = ServiceRes.ExportingEmailDistributionLists,
                AppTaskStatus = AppTaskStatusEnum.Created,
                PercentCompleted = 1,
                Parameters = sbParameters.ToString(),
                Language = LanguageRequest,
                StartDateTime_UTC = DateTime.UtcNow,
                EndDateTime_UTC = null,
                EstimatedLength_second = null,
                RemainingTime_second = null,
            };

            AppTaskModel appTaskModelRet = _AppTaskService.PostAddAppTask(appTaskModelNew);
            if (!string.IsNullOrWhiteSpace(appTaskModelRet.Error))
                return ReturnAppTaskError(appTaskModelRet.Error);

            return appTaskModelRet;
        }
        public EmailDistributionListModel PostEmailDistributionListMoveDownDB(int ParentTVItemID, int EmailDistributionListID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            List<EmailDistributionListModel> emailDistributionListModelList = GetEmailDistributionListModelWithParentTVItemIDDB(ParentTVItemID);

            EmailDistributionListModel emailDistributionListModelRet = new EmailDistributionListModel();
            using (TransactionScope ts = new TransactionScope())
            {
                for (int i = 0, count = emailDistributionListModelList.Count; i < count; i++)
                {

                    if (emailDistributionListModelList[i].EmailDistributionListID == EmailDistributionListID)
                    {
                        int NextOrdinal = emailDistributionListModelList[i + 1].Ordinal;
                        emailDistributionListModelList[i + 1].Ordinal = emailDistributionListModelList[i].Ordinal;
                        emailDistributionListModelList[i].Ordinal = NextOrdinal;

                        emailDistributionListModelRet = PostUpdateEmailDistributionListDB(emailDistributionListModelList[i + 1]);
                        if (!string.IsNullOrWhiteSpace(emailDistributionListModelRet.Error))
                            return ReturnError(emailDistributionListModelRet.Error);

                        emailDistributionListModelRet = PostUpdateEmailDistributionListDB(emailDistributionListModelList[i]);
                        if (!string.IsNullOrWhiteSpace(emailDistributionListModelRet.Error))
                            return ReturnError(emailDistributionListModelRet.Error);

                    }
                }

                ts.Complete();
            }
            return GetEmailDistributionListModelWithEmailDistributionListIDDB(emailDistributionListModelRet.EmailDistributionListID);
        }
        public EmailDistributionListModel PostEmailDistributionListMoveUpDB(int ParentTVItemID, int EmailDistributionListID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            List<EmailDistributionListModel> emailDistributionListModelList = GetEmailDistributionListModelWithParentTVItemIDDB(ParentTVItemID);

            EmailDistributionListModel emailDistributionListModelRet = new EmailDistributionListModel();
            using (TransactionScope ts = new TransactionScope())
            {
                for (int i = 0, count = emailDistributionListModelList.Count; i < count; i++)
                {

                    if (emailDistributionListModelList[i].EmailDistributionListID == EmailDistributionListID)
                    {
                        int PrevOrdinal = emailDistributionListModelList[i - 1].Ordinal;
                        emailDistributionListModelList[i - 1].Ordinal = emailDistributionListModelList[i].Ordinal;
                        emailDistributionListModelList[i].Ordinal = PrevOrdinal;

                        emailDistributionListModelRet = PostUpdateEmailDistributionListDB(emailDistributionListModelList[i - 1]);
                        if (!string.IsNullOrWhiteSpace(emailDistributionListModelRet.Error))
                            return ReturnError(emailDistributionListModelRet.Error);

                        emailDistributionListModelRet = PostUpdateEmailDistributionListDB(emailDistributionListModelList[i]);
                        if (!string.IsNullOrWhiteSpace(emailDistributionListModelRet.Error))
                            return ReturnError(emailDistributionListModelRet.Error);

                    }
                }

                ts.Complete();
            }
            return GetEmailDistributionListModelWithEmailDistributionListIDDB(emailDistributionListModelRet.EmailDistributionListID);
        }
        public EmailDistributionListModel PostEmailDistributionListSaveDB(FormCollection fc)
        {
            int EmailDistributionListID = 0;
            int ParentTVItemID = 0;
            string EmailListName = "";
            int Ordinal = 0;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int.TryParse(fc["EmailDistributionListID"], out EmailDistributionListID);
            // can be 0, if 0 then we want to add a new one

            int.TryParse(fc["ParentTVItemID"], out ParentTVItemID);
            if (ParentTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID));

            EmailListName = fc["EmailListName"];
            if (string.IsNullOrWhiteSpace(EmailListName))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EmailListName));


            List<EmailDistributionListModel> emailDistributionListModelList = GetEmailDistributionListModelWithParentTVItemIDDB(ParentTVItemID);

            if (emailDistributionListModelList.Count > 0)
            {
                Ordinal = emailDistributionListModelList.Last().Ordinal;
            }

            EmailDistributionListModel emailDistributionListModel = new EmailDistributionListModel();
            if (EmailDistributionListID > 0)
            {
                emailDistributionListModel = GetEmailDistributionListModelWithEmailDistributionListIDDB(EmailDistributionListID);
                if (!string.IsNullOrWhiteSpace(emailDistributionListModel.Error))
                    return ReturnError(emailDistributionListModel.Error);

            }

            emailDistributionListModel.ParentTVItemID = ParentTVItemID;
            emailDistributionListModel.EmailListName = EmailListName;
            emailDistributionListModel.Ordinal = Ordinal + 1;

            EmailDistributionListModel emailDistributionListModelRet = new EmailDistributionListModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (EmailDistributionListID == 0)
                {
                    emailDistributionListModelRet = PostAddEmailDistributionListDB(emailDistributionListModel);
                    if (!string.IsNullOrWhiteSpace(emailDistributionListModelRet.Error))
                        return ReturnError(emailDistributionListModelRet.Error);

                }
                else
                {
                    emailDistributionListModelRet = PostUpdateEmailDistributionListDB(emailDistributionListModel);
                    if (!string.IsNullOrWhiteSpace(emailDistributionListModelRet.Error))
                        return ReturnError(emailDistributionListModelRet.Error);

                }

                ts.Complete();
            }
            return GetEmailDistributionListModelWithEmailDistributionListIDDB(emailDistributionListModelRet.EmailDistributionListID);
        }
        public EmailDistributionListModel PostAddEmailDistributionListDB(EmailDistributionListModel emailDistributionListModel)
        {
            string retStr = EmailDistributionListModelOK(emailDistributionListModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailDistributionList emailDistributionListNew = new EmailDistributionList();
            retStr = FillEmailDistributionList(emailDistributionListNew, emailDistributionListModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.EmailDistributionLists.Add(emailDistributionListNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("EmailDistributionLists", emailDistributionListNew.EmailDistributionListID, LogCommandEnum.Add, emailDistributionListNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    EmailDistributionListLanguageModel emailDistributionListLanguageModel = new EmailDistributionListLanguageModel()
                    {
                        EmailDistributionListID = emailDistributionListNew.EmailDistributionListID,
                        Language = Lang,
                        EmailListName = emailDistributionListModel.EmailListName,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    EmailDistributionListLanguageModel emailDistributionListLanguageModelRet = _EmailDistributionListLanguageService.PostAddEmailDistributionListLanguageDB(emailDistributionListLanguageModel);
                    if (!string.IsNullOrEmpty(emailDistributionListLanguageModelRet.Error))
                        return ReturnError(string.Format(ServiceRes.CouldNotAddError_, emailDistributionListLanguageModelRet.Error));
                }

                ts.Complete();
            }
            return GetEmailDistributionListModelWithEmailDistributionListIDDB(emailDistributionListNew.EmailDistributionListID);
        }
        public EmailDistributionListModel PostDeleteEmailDistributionListDB(int emailDistributionListID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailDistributionList emailDistributionListToDelete = GetEmailDistributionListWithEmailDistributionListIDDB(emailDistributionListID);
            if (emailDistributionListToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.EmailDistributionList));

            using (TransactionScope ts = new TransactionScope())
            {
                db.EmailDistributionLists.Remove(emailDistributionListToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("EmailDistributionLists", emailDistributionListToDelete.EmailDistributionListID, LogCommandEnum.Delete, emailDistributionListToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public EmailDistributionListModel PostUpdateEmailDistributionListDB(EmailDistributionListModel emailDistributionListModel)
        {
            string retStr = EmailDistributionListModelOK(emailDistributionListModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            EmailDistributionList emailDistributionListToUpdate = GetEmailDistributionListWithEmailDistributionListIDDB(emailDistributionListModel.EmailDistributionListID);
            if (emailDistributionListToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.EmailDistributionList));

            retStr = FillEmailDistributionList(emailDistributionListToUpdate, emailDistributionListModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("EmailDistributionLists", emailDistributionListToUpdate.EmailDistributionListID, LogCommandEnum.Change, emailDistributionListToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        EmailDistributionListLanguageModel emailDistributionListLanguageModel = new EmailDistributionListLanguageModel()
                        {
                            EmailDistributionListID = emailDistributionListToUpdate.EmailDistributionListID,
                            Language = Lang,
                            EmailListName = emailDistributionListModel.EmailListName,
                            TranslationStatus = TranslationStatusEnum.Translated,
                        };

                        EmailDistributionListLanguageModel emailDistributionListLanguageModelRet = _EmailDistributionListLanguageService.PostUpdateEmailDistributionListLanguageDB(emailDistributionListLanguageModel);
                        if (!string.IsNullOrEmpty(emailDistributionListLanguageModelRet.Error))
                            return ReturnError(string.Format(ServiceRes.CouldNotAddError_, emailDistributionListLanguageModelRet.Error));
                    }
                }


                ts.Complete();
            }
            return GetEmailDistributionListModelWithEmailDistributionListIDDB(emailDistributionListToUpdate.EmailDistributionListID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}

