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
    public class ReportTypeLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public ReportTypeLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string ReportTypeLanguageModelOK(ReportTypeLanguageModel reportTypeLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(reportTypeLanguageModel.ReportTypeID, ServiceRes.ReportTypeID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(reportTypeLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(reportTypeLanguageModel.Name, ServiceRes.Name, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(reportTypeLanguageModel.Description, ServiceRes.Description, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(reportTypeLanguageModel.StartOfFileName, ServiceRes.StartOfFileName, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillReportTypeLanguage(ReportTypeLanguage reportTypeLanguageNew, ReportTypeLanguageModel reportTypeLanguageModel, ContactOK contactOK)
        {
            reportTypeLanguageNew.ReportTypeID = reportTypeLanguageModel.ReportTypeID;
            reportTypeLanguageNew.Language = (int)reportTypeLanguageModel.Language;
            reportTypeLanguageNew.Name = reportTypeLanguageModel.Name;
            reportTypeLanguageNew.TranslationStatusName = (int)reportTypeLanguageModel.TranslationStatusName;
            reportTypeLanguageNew.Description = reportTypeLanguageModel.Description;
            reportTypeLanguageNew.TranslationStatusDescription = (int)reportTypeLanguageModel.TranslationStatusDescription;
            reportTypeLanguageNew.StartOfFileName = reportTypeLanguageModel.StartOfFileName;
            reportTypeLanguageNew.TranslationStatusStartOfFileName = (int)reportTypeLanguageModel.TranslationStatusStartOfFileName;
            reportTypeLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                reportTypeLanguageNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                reportTypeLanguageNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetReportTypeLanguageModelCountDB()
        {
            int ReportTypeLanguageModelCount = (from c in db.ReportTypeLanguages
                                                    select c).Count();

            return ReportTypeLanguageModelCount;
        }
        public ReportTypeLanguageModel GetReportTypeLanguageModelWithReportTypeIDAndLanguageDB(int ReportTypeID, LanguageEnum Language)
        {
            ReportTypeLanguageModel reportTypeLanguageModel = (from c in db.ReportTypeLanguages
                                                                       where c.ReportTypeID == ReportTypeID
                                                                       && c.Language == (int)Language
                                                                       select new ReportTypeLanguageModel
                                                                       {
                                                                           Error = "",
                                                                           ReportTypeLanguageID = c.ReportTypeLanguageID,
                                                                           ReportTypeID = c.ReportTypeID,
                                                                           Language = (LanguageEnum)c.Language,
                                                                           Name = c.Name,
                                                                           TranslationStatusName = (TranslationStatusEnum)c.TranslationStatusName,
                                                                           Description = c.Description,
                                                                           TranslationStatusDescription = (TranslationStatusEnum)c.TranslationStatusDescription,
                                                                           StartOfFileName = c.StartOfFileName,
                                                                           TranslationStatusStartOfFileName = (TranslationStatusEnum)c.TranslationStatusStartOfFileName,
                                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                       }).FirstOrDefault<ReportTypeLanguageModel>();
            if (reportTypeLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ReportTypeLanguage, ServiceRes.ReportTypeID + "," + ServiceRes.Language, ReportTypeID.ToString() + "," + Language));

            return reportTypeLanguageModel;
        }
        public ReportTypeLanguage GetReportTypeLanguageWithReportTypeIDAndLanguageDB(int ReportTypeID, LanguageEnum Language)
        {
            ReportTypeLanguage ReportTypeLanguage = (from c in db.ReportTypeLanguages
                                                             where c.ReportTypeID == ReportTypeID
                                                             && c.Language == (int)Language
                                                             select c).FirstOrDefault<ReportTypeLanguage>();

            return ReportTypeLanguage;
        }

        // Helper
        public ReportTypeLanguageModel ReturnError(string Error)
        {
            return new ReportTypeLanguageModel() { Error = Error };
        }

        // Post
        public ReportTypeLanguageModel PostAddReportTypeLanguageDB(ReportTypeLanguageModel reportTypeLanguageModel)
        {
            string retStr = ReportTypeLanguageModelOK(reportTypeLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportTypeLanguageModel reportTypeLanguageModelExist = GetReportTypeLanguageModelWithReportTypeIDAndLanguageDB(reportTypeLanguageModel.ReportTypeID, reportTypeLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(reportTypeLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.ReportTypeLanguage));

            ReportTypeLanguage reportTypeLanguageNew = new ReportTypeLanguage();
            retStr = FillReportTypeLanguage(reportTypeLanguageNew, reportTypeLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.ReportTypeLanguages.Add(reportTypeLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ReportTypeLanguages", reportTypeLanguageNew.ReportTypeLanguageID, LogCommandEnum.Add, reportTypeLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportTypeLanguageModelWithReportTypeIDAndLanguageDB(reportTypeLanguageNew.ReportTypeID, reportTypeLanguageModel.Language);
        }
        public ReportTypeLanguageModel PostDeleteReportTypeLanguageDB(int ReportTypeID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportTypeLanguage reportTypeLanguageToDelete = GetReportTypeLanguageWithReportTypeIDAndLanguageDB(ReportTypeID, Language);
            if (reportTypeLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ReportTypeLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.ReportTypeLanguages.Remove(reportTypeLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ReportTypeLanguages", reportTypeLanguageToDelete.ReportTypeLanguageID, LogCommandEnum.Delete, reportTypeLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public ReportTypeLanguageModel PostUpdateReportTypeLanguageDB(ReportTypeLanguageModel reportTypeLanguageModel)
        {
            string retStr = ReportTypeLanguageModelOK(reportTypeLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportTypeLanguage reportTypeLanguageToUpdate = GetReportTypeLanguageWithReportTypeIDAndLanguageDB(reportTypeLanguageModel.ReportTypeID, reportTypeLanguageModel.Language);
            if (reportTypeLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.ReportTypeLanguage));

            retStr = FillReportTypeLanguage(reportTypeLanguageToUpdate, reportTypeLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ReportTypeLanguages", reportTypeLanguageToUpdate.ReportTypeLanguageID, LogCommandEnum.Change, reportTypeLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportTypeLanguageModelWithReportTypeIDAndLanguageDB(reportTypeLanguageToUpdate.ReportTypeID, (LanguageEnum)reportTypeLanguageToUpdate.Language);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
