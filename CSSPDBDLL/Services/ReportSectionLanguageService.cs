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
    public class ReportSectionLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public ReportSectionLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string ReportSectionLanguageModelOK(ReportSectionLanguageModel ReportSectionLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(ReportSectionLanguageModel.ReportSectionID, ServiceRes.ReportSectionID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(ReportSectionLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(ReportSectionLanguageModel.ReportSectionName, ServiceRes.ReportSectionName, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(ReportSectionLanguageModel.ReportSectionText, ServiceRes.ReportSectionText, 100000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillReportSectionLanguage(ReportSectionLanguage ReportSectionLanguageNew, ReportSectionLanguageModel ReportSectionLanguageModel, ContactOK contactOK)
        {
            ReportSectionLanguageNew.ReportSectionID = ReportSectionLanguageModel.ReportSectionID;
            ReportSectionLanguageNew.Language = (int)ReportSectionLanguageModel.Language;
            ReportSectionLanguageNew.ReportSectionName = ReportSectionLanguageModel.ReportSectionName;
            ReportSectionLanguageNew.TranslationStatusReportSectionName = (int)ReportSectionLanguageModel.TranslationStatusReportSectionName;
            ReportSectionLanguageNew.ReportSectionText = ReportSectionLanguageModel.ReportSectionText;
            List<string> TagsToRemove = new List<string>()
            {
                "</body>", "</html>", "<!DOCTYPE html>", "<html>", "<head>", "</head>", "<body>"
            };

            foreach (string s in TagsToRemove)
            {
                ReportSectionLanguageNew.ReportSectionText = ReportSectionLanguageNew.ReportSectionText.Replace(s, "");
            }

            ReportSectionLanguageNew.TranslationStatusReportSectionText = (int)ReportSectionLanguageModel.TranslationStatusReportSectionText;
            ReportSectionLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                ReportSectionLanguageNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                ReportSectionLanguageNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetReportSectionLanguageModelCountDB()
        {
            int ReportSectionLanguageModelCount = (from c in db.ReportSectionLanguages
                                                    select c).Count();

            return ReportSectionLanguageModelCount;
        }
        public ReportSectionLanguageModel GetReportSectionLanguageModelWithReportSectionIDAndLanguageDB(int ReportSectionID, LanguageEnum Language)
        {
            ReportSectionLanguageModel ReportSectionLanguageModel = (from c in db.ReportSectionLanguages
                                                                       where c.ReportSectionID == ReportSectionID
                                                                       && c.Language == (int)Language
                                                                       select new ReportSectionLanguageModel
                                                                       {
                                                                           Error = "",
                                                                           ReportSectionLanguageID = c.ReportSectionLanguageID,
                                                                           ReportSectionID = c.ReportSectionID,
                                                                           Language = (LanguageEnum)c.Language,
                                                                           ReportSectionName = c.ReportSectionName,
                                                                           TranslationStatusReportSectionName = (TranslationStatusEnum)c.TranslationStatusReportSectionName,
                                                                           ReportSectionText = c.ReportSectionText,
                                                                           TranslationStatusReportSectionText = (TranslationStatusEnum)c.TranslationStatusReportSectionText,
                                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                       }).FirstOrDefault<ReportSectionLanguageModel>();
            if (ReportSectionLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ReportSectionLanguage, ServiceRes.ReportSectionID + "," + ServiceRes.Language, ReportSectionID.ToString() + "," + Language));

            return ReportSectionLanguageModel;
        }
        public ReportSectionLanguage GetReportSectionLanguageWithReportSectionIDAndLanguageDB(int ReportSectionID, LanguageEnum Language)
        {
            ReportSectionLanguage ReportSectionLanguage = (from c in db.ReportSectionLanguages
                                                             where c.ReportSectionID == ReportSectionID
                                                             && c.Language == (int)Language
                                                             select c).FirstOrDefault<ReportSectionLanguage>();

            return ReportSectionLanguage;
        }

        // Helper
        public ReportSectionLanguageModel ReturnError(string Error)
        {
            return new ReportSectionLanguageModel() { Error = Error };
        }

        // Post
        public ReportSectionLanguageModel PostAddReportSectionLanguageDB(ReportSectionLanguageModel ReportSectionLanguageModel)
        {
            string retStr = ReportSectionLanguageModelOK(ReportSectionLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionLanguageModel ReportSectionLanguageModelExist = GetReportSectionLanguageModelWithReportSectionIDAndLanguageDB(ReportSectionLanguageModel.ReportSectionID, ReportSectionLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(ReportSectionLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.ReportSectionLanguage));

            ReportSectionLanguage ReportSectionLanguageNew = new ReportSectionLanguage();
            retStr = FillReportSectionLanguage(ReportSectionLanguageNew, ReportSectionLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.ReportSectionLanguages.Add(ReportSectionLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ReportSectionLanguages", ReportSectionLanguageNew.ReportSectionLanguageID, LogCommandEnum.Add, ReportSectionLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportSectionLanguageModelWithReportSectionIDAndLanguageDB(ReportSectionLanguageNew.ReportSectionID, ReportSectionLanguageModel.Language);
        }
        public ReportSectionLanguageModel PostDeleteReportSectionLanguageDB(int ReportSectionID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionLanguage ReportSectionLanguageToDelete = GetReportSectionLanguageWithReportSectionIDAndLanguageDB(ReportSectionID, Language);
            if (ReportSectionLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ReportSectionLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.ReportSectionLanguages.Remove(ReportSectionLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ReportSectionLanguages", ReportSectionLanguageToDelete.ReportSectionLanguageID, LogCommandEnum.Delete, ReportSectionLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public ReportSectionLanguageModel PostUpdateReportSectionLanguageDB(ReportSectionLanguageModel ReportSectionLanguageModel)
        {
            string retStr = ReportSectionLanguageModelOK(ReportSectionLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionLanguage ReportSectionLanguageToUpdate = GetReportSectionLanguageWithReportSectionIDAndLanguageDB(ReportSectionLanguageModel.ReportSectionID, ReportSectionLanguageModel.Language);
            if (ReportSectionLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.ReportSectionLanguage));

            retStr = FillReportSectionLanguage(ReportSectionLanguageToUpdate, ReportSectionLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ReportSectionLanguages", ReportSectionLanguageToUpdate.ReportSectionLanguageID, LogCommandEnum.Change, ReportSectionLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportSectionLanguageModelWithReportSectionIDAndLanguageDB(ReportSectionLanguageToUpdate.ReportSectionID, (LanguageEnum)ReportSectionLanguageToUpdate.Language);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
