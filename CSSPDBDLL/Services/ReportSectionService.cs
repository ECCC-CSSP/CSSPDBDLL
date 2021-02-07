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
using System.Web.Mvc;
using System.IO;
using System.Threading;
using System.Globalization;

namespace CSSPDBDLL.Services
{
    public class ReportSectionService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public ReportSectionService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public override string FieldCheckNotNullDateTime(DateTime? Value, string Res)
        {
            return base.FieldCheckNotNullDateTime(Value, Res);
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
        public string ReportSectionModelOK(ReportSectionModel reportSectionModel)
        {
            string retStr = FieldCheckNotZeroInt(reportSectionModel.ReportTypeID, ServiceRes.ReportTypeID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(reportSectionModel.TVItemID, ServiceRes.TVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(reportSectionModel.Ordinal, ServiceRes.Ordinal, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(reportSectionModel.ParentReportSectionID, ServiceRes.ParentReportSectionID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(reportSectionModel.Year, ServiceRes.Year, 1980, 2050);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(reportSectionModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(reportSectionModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillReportSection(ReportSection reportSection, ReportSectionModel reportSectionModel, ContactOK contactOK)
        {
            reportSection.DBCommand = (int)reportSectionModel.DBCommand;
            reportSection.ReportSectionID = reportSectionModel.ReportSectionID;
            reportSection.ReportTypeID = (int)reportSectionModel.ReportTypeID;
            reportSection.TVItemID = reportSectionModel.TVItemID;
            reportSection.Language = (int)reportSectionModel.Language;
            reportSection.Ordinal = reportSectionModel.Ordinal;
            reportSection.IsStatic = reportSectionModel.IsStatic;
            reportSection.ParentReportSectionID = reportSectionModel.ParentReportSectionID;
            reportSection.Year = reportSectionModel.Year;
            reportSection.Locked = reportSectionModel.Locked;
            reportSection.TemplateReportSectionID = reportSectionModel.TemplateReportSectionID;
            reportSection.ReportSectionName = reportSectionModel.ReportSectionName;
            reportSection.ReportSectionText = reportSectionModel.ReportSectionText;
            reportSection.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                reportSection.LastUpdateContactTVItemID = 2;
            }
            else
            {
                reportSection.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetReportSectionModelCountDB()
        {
            int ReportSectionModelCount = (from c in db.ReportSections
                                           select c).Count();

            return ReportSectionModelCount;
        }
        public List<int?> GetReportSectionYearListWithReportTypeIDDB(int ReportTypeID)
        {
            List<int?> reportSectionYearList = (from c in db.ReportSections
                                                where c.ReportTypeID == ReportTypeID
                                                orderby c.Year descending
                                                select c.Year).Distinct().ToList<int?>();

            return reportSectionYearList;
        }
        public List<ReportSectionModel> GetReportSectionModelListWithReportTypeIDAndTVItemIDNoReportSectionTextDB(int ReportTypeID, int? TVItemID)
        {
            List<ReportSectionModel> reportSectionModelList = (from c in db.ReportSections
                                                               where c.ReportTypeID == ReportTypeID
                                                               && c.TVItemID == TVItemID
                                                               orderby c.Ordinal, c.ReportSectionName
                                                               select new ReportSectionModel
                                                               {
                                                                   Error = "",
                                                                   ReportSectionID = c.ReportSectionID,
                                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                                   ReportTypeID = c.ReportTypeID,
                                                                   TVItemID = c.TVItemID,
                                                                   Language = (LanguageEnum)c.Language,
                                                                   Ordinal = c.Ordinal,
                                                                   IsStatic = c.IsStatic,
                                                                   ReportSectionName = c.ReportSectionName,
                                                                   ReportSectionText = c.ReportSectionText,
                                                                   ParentReportSectionID = c.ParentReportSectionID,
                                                                   Year = c.Year,
                                                                   Locked = c.Locked,
                                                                   TemplateReportSectionID = c.TemplateReportSectionID,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                               }).ToList<ReportSectionModel>();

            return reportSectionModelList;
        }
        public List<ReportSectionModel> GetReportSectionModelListWithReportSectionIDTemplateLinkAndTVItemIDForAllYearsDB(int ReportSectionID, int TVItemID)
        {
            List<ReportSectionModel> reportSectionModelList = (from c in db.ReportSections
                                                               where c.TemplateReportSectionID == ReportSectionID
                                                               && c.TVItemID == TVItemID
                                                               orderby c.Ordinal, c.ReportSectionName
                                                               select new ReportSectionModel
                                                               {
                                                                   Error = "",
                                                                   ReportSectionID = c.ReportSectionID,
                                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                                   ReportTypeID = c.ReportTypeID,
                                                                   TVItemID = c.TVItemID,
                                                                   Language = (LanguageEnum)c.Language,
                                                                   Ordinal = c.Ordinal,
                                                                   IsStatic = c.IsStatic,
                                                                   ReportSectionName = c.ReportSectionName,
                                                                   ReportSectionText = c.ReportSectionText,
                                                                   ParentReportSectionID = c.ParentReportSectionID,
                                                                   Year = c.Year,
                                                                   Locked = c.Locked,
                                                                   TemplateReportSectionID = c.TemplateReportSectionID,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                               }).ToList<ReportSectionModel>();

            return reportSectionModelList;
        }
        public List<ReportSectionModel> GetReportSectionModelListWithReportTypeIDAndTVItemIDAndYearDB(int ReportTypeID, int? TVItemID, int? Year)
        {
            List<ReportSectionModel> reportSectionModelList = (from c in db.ReportSections
                                                               where c.ReportTypeID == ReportTypeID
                                                               && c.TVItemID == TVItemID
                                                               && c.Year == Year
                                                               orderby c.Ordinal, c.ReportSectionName
                                                               select new ReportSectionModel
                                                               {
                                                                   Error = "",
                                                                   ReportSectionID = c.ReportSectionID,
                                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                                   ReportTypeID = c.ReportTypeID,
                                                                   TVItemID = c.TVItemID,
                                                                   Language = (LanguageEnum)c.Language,
                                                                   Ordinal = c.Ordinal,
                                                                   IsStatic = c.IsStatic,
                                                                   ReportSectionName = c.ReportSectionName,
                                                                   ReportSectionText = c.ReportSectionText,
                                                                   ParentReportSectionID = c.ParentReportSectionID,
                                                                   Year = c.Year,
                                                                   Locked = c.Locked,
                                                                   TemplateReportSectionID = c.TemplateReportSectionID,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                               }).ToList<ReportSectionModel>();

            return reportSectionModelList;
        }
        public List<ReportSectionModel> GetReportSectionModelListWithReportTypeIDAndTVItemIDAndYearAndParentReportSectionIDDB(int ReportTypeID, LanguageEnum language, int? TVItemID, int? Year, int? ParentReportSectionID)
        {
            List<ReportSectionModel> reportSectionModelList = (from c in db.ReportSections
                                                               where c.ReportTypeID == ReportTypeID
                                                               && c.Language == (int)language
                                                               && c.TVItemID == TVItemID
                                                               && c.Year == Year
                                                               && c.ParentReportSectionID == ParentReportSectionID
                                                               orderby c.Ordinal, c.ReportSectionName
                                                               select new ReportSectionModel
                                                               {
                                                                   Error = "",
                                                                   ReportSectionID = c.ReportSectionID,
                                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                                   ReportTypeID = c.ReportTypeID,
                                                                   TVItemID = c.TVItemID,
                                                                   Language = (LanguageEnum)c.Language,
                                                                   Ordinal = c.Ordinal,
                                                                   IsStatic = c.IsStatic,
                                                                   ReportSectionName = c.ReportSectionName,
                                                                   ReportSectionText = c.ReportSectionText,
                                                                   ParentReportSectionID = c.ParentReportSectionID,
                                                                   Year = c.Year,
                                                                   Locked = c.Locked,
                                                                   TemplateReportSectionID = c.TemplateReportSectionID,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                               }).ToList<ReportSectionModel>();

            return reportSectionModelList;
        }
        public ReportSectionModel GetReportSectionModelWithReportSectionIDDB(int ReportSectionID)
        {
            ReportSectionModel reportSectionModel = (from c in db.ReportSections
                                                     where c.ReportSectionID == ReportSectionID
                                                     orderby c.Ordinal, c.ReportSectionName
                                                     select new ReportSectionModel
                                                     {
                                                         Error = "",
                                                         ReportSectionID = c.ReportSectionID,
                                                         DBCommand = (DBCommandEnum)c.DBCommand,
                                                         ReportTypeID = c.ReportTypeID,
                                                         TVItemID = c.TVItemID,
                                                         Language = (LanguageEnum)c.Language,
                                                         Ordinal = c.Ordinal,
                                                         IsStatic = c.IsStatic,
                                                         ReportSectionName = c.ReportSectionName,
                                                         ReportSectionText = c.ReportSectionText,
                                                         ParentReportSectionID = c.ParentReportSectionID,
                                                         Year = c.Year,
                                                         Locked = c.Locked,
                                                         TemplateReportSectionID = c.TemplateReportSectionID,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<ReportSectionModel>();

            if (reportSectionModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ReportSection, ServiceRes.ReportSectionID, ReportSectionID.ToString()));
            }

            return reportSectionModel;
        }
        public List<ReportSectionModel> GetReportSectionModelListWithTemplateReportSectionIDDB(int TemplateReportSectionID, LanguageEnum language)
        {
            List<ReportSectionModel> reportSectionModelList = (from c in db.ReportSections
                                                               where c.TemplateReportSectionID == TemplateReportSectionID
                                                               && c.Language == (int)language
                                                               orderby c.Ordinal, c.ReportSectionName
                                                               select new ReportSectionModel
                                                               {
                                                                   Error = "",
                                                                   ReportSectionID = c.ReportSectionID,
                                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                                   ReportTypeID = c.ReportTypeID,
                                                                   TVItemID = c.TVItemID,
                                                                   Language = (LanguageEnum)c.Language,
                                                                   Ordinal = c.Ordinal,
                                                                   IsStatic = c.IsStatic,
                                                                   ReportSectionName = c.ReportSectionName,
                                                                   ReportSectionText = c.ReportSectionText,
                                                                   ParentReportSectionID = c.ParentReportSectionID,
                                                                   Year = c.Year,
                                                                   Locked = c.Locked,
                                                                   TemplateReportSectionID = c.TemplateReportSectionID,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                               }).ToList<ReportSectionModel>();

            return reportSectionModelList;
        }
        public List<ReportSectionModel> GetReportSectionModelListWithParentReportSectionIDDB(int ParentReportSectionID, LanguageEnum language)
        {
            List<ReportSectionModel> reportSectionModelList = (from c in db.ReportSections
                                                               where c.ParentReportSectionID == ParentReportSectionID
                                                               && c.Language == (int)language
                                                               orderby c.Ordinal, c.ReportSectionName
                                                               select new ReportSectionModel
                                                               {
                                                                   Error = "",
                                                                   ReportSectionID = c.ReportSectionID,
                                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                                   ReportTypeID = c.ReportTypeID,
                                                                   TVItemID = c.TVItemID,
                                                                   Language = (LanguageEnum)c.Language,
                                                                   Ordinal = c.Ordinal,
                                                                   IsStatic = c.IsStatic,
                                                                   ReportSectionName = c.ReportSectionName,
                                                                   ReportSectionText = c.ReportSectionText,
                                                                   ParentReportSectionID = c.ParentReportSectionID,
                                                                   Year = c.Year,
                                                                   Locked = c.Locked,
                                                                   TemplateReportSectionID = c.TemplateReportSectionID,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                               }).ToList<ReportSectionModel>();

            return reportSectionModelList;
        }
        public ReportSection GetReportSectionWithReportSectionIDDB(int ReportSectionID)
        {
            ReportSection reportSection = (from c in db.ReportSections
                                           where c.ReportSectionID == ReportSectionID
                                           select c).FirstOrDefault<ReportSection>();

            return reportSection;
        }
        public ReportSectionModel GetReportSectionModelExistDB(ReportSectionModel reportSectionModel)
        {
            ReportSectionModel reportSectionModelRet = (from c in db.ReportSections
                                                        where c.ReportTypeID == reportSectionModel.ReportTypeID
                                                        && c.TVItemID == reportSectionModel.TVItemID
                                                        && c.Language == (int)reportSectionModel.Language
                                                        && c.ParentReportSectionID == reportSectionModel.ParentReportSectionID
                                                        && c.Year == reportSectionModel.Year
                                                        && c.ReportSectionName == reportSectionModel.ReportSectionName
                                                        select new ReportSectionModel
                                                        {
                                                            Error = "",
                                                            ReportSectionID = c.ReportSectionID,
                                                            DBCommand = (DBCommandEnum)c.DBCommand,
                                                            ReportTypeID = c.ReportTypeID,
                                                            TVItemID = c.TVItemID,
                                                            Language = (LanguageEnum)c.Language,
                                                            Ordinal = c.Ordinal,
                                                            IsStatic = c.IsStatic,
                                                            ReportSectionName = c.ReportSectionName,
                                                            ReportSectionText = c.ReportSectionText,
                                                            ParentReportSectionID = c.ParentReportSectionID,
                                                            Year = c.Year,
                                                            Locked = c.Locked,
                                                            TemplateReportSectionID = c.TemplateReportSectionID,
                                                            LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                            LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                        }).FirstOrDefault<ReportSectionModel>();

            if (reportSectionModelRet == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ReportSection,
                    ServiceRes.ReportTypeID + "," +
                    ServiceRes.TVItemID + "," +
                    ServiceRes.Language + "," +
                    ServiceRes.ParentReportSectionID + "," +
                    ServiceRes.Year + "," +
                    ServiceRes.ReportSectionName,
                    reportSectionModel.ReportTypeID.ToString() + "," +
                    (reportSectionModel.TVItemID == null ? "null" : reportSectionModel.TVItemID.ToString()) + "," +
                    reportSectionModel.Language + "," +
                    (reportSectionModel.ParentReportSectionID == null ? "null" : reportSectionModel.ParentReportSectionID.ToString()) + "," +
                    reportSectionModel.Year.ToString() + "," +
                    reportSectionModel.ReportSectionName));
            }

            return reportSectionModelRet;
        }

        // Helper
        public ReportSectionModel ReturnError(string Error)
        {
            return new ReportSectionModel() { Error = Error };
        }

        public ReportSectionModel PostReportSectionAddChildDB(int ReportSectionID)
        {
            ReportSectionModel reportSectionModelParent = GetReportSectionModelWithReportSectionIDDB(ReportSectionID);
            if (!string.IsNullOrWhiteSpace(reportSectionModelParent.Error))
            {
                return ReturnError(reportSectionModelParent.Error);
            }

            int MaxOrdinal = 0;
            ReportSectionModel reportSectionModelMaxOrdinal = GetReportSectionModelListWithReportTypeIDAndTVItemIDAndYearDB(reportSectionModelParent.ReportTypeID, null, null).OrderByDescending(c => c.Ordinal).FirstOrDefault();
            if (reportSectionModelMaxOrdinal != null)
            {
                MaxOrdinal = reportSectionModelMaxOrdinal.Ordinal + 1;
            }


            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionModel ReportSectionModelRet = new ReportSectionModel();
            using (TransactionScope ts = new TransactionScope())
            {
                Random r = new Random((int)DateTime.Now.Ticks);
                string RandomText = "";
                for (int i = 0; i < 10; i++)
                {
                    RandomText = RandomText + (char)(r.Next(65, 90));
                }
                ReportSectionModel reportSectionModel = new ReportSectionModel()
                {
                    DBCommand = DBCommandEnum.Original,
                    ReportTypeID = reportSectionModelParent.ReportTypeID,
                    TVItemID = null,
                    Ordinal = MaxOrdinal,
                    IsStatic = true,
                    ParentReportSectionID = reportSectionModelParent.ReportSectionID,
                    Year = null,
                    Locked = false,
                    TemplateReportSectionID = null,
                    ReportSectionName = reportSectionModelParent.ReportSectionName + " - " + RandomText,
                    ReportSectionText = reportSectionModelParent.ReportSectionName + " - " + RandomText,
                    Language = reportSectionModelParent.Language,
                };

                ReportSectionModelRet = PostAddReportSectionDB(reportSectionModel);
                if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                    return ReturnError(ReportSectionModelRet.Error);

                LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Add, ReportSectionModelRet);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportSectionModelWithReportSectionIDDB(ReportSectionModelRet.ReportSectionID);
        }
        public ReportSectionModel PostReportSectionAddSiblingDB(int ReportSectionID)
        {
            ReportSectionModel reportSectionModelSibling = GetReportSectionModelWithReportSectionIDDB(ReportSectionID);
            if (!string.IsNullOrWhiteSpace(reportSectionModelSibling.Error))
            {
                return ReturnError(reportSectionModelSibling.Error);
            }

            ReportSectionModel ReportSectionModelRet = new ReportSectionModel();
            if (reportSectionModelSibling.ParentReportSectionID == null)
            {
                ReportSectionModelRet = PostReportSectionAddTopDB(reportSectionModelSibling.ReportTypeID);
            }
            else
            {
                int MaxOrdinal = 0;
                ReportSectionModel reportSectionModelMaxOrdinal = GetReportSectionModelListWithReportTypeIDAndTVItemIDAndYearDB(reportSectionModelSibling.ReportTypeID, null, null).OrderByDescending(c => c.Ordinal).FirstOrDefault();
                if (reportSectionModelMaxOrdinal != null)
                {
                    MaxOrdinal = reportSectionModelMaxOrdinal.Ordinal + 1;
                }

                ContactOK contactOK = IsContactOK();
                if (!string.IsNullOrEmpty(contactOK.Error))
                    return ReturnError(contactOK.Error);

                using (TransactionScope ts = new TransactionScope())
                {
                    Random r = new Random((int)DateTime.Now.Ticks);
                    string RandomText = "";
                    for (int i = 0; i < 10; i++)
                    {
                        RandomText = RandomText + (char)(r.Next(65, 90));
                    }
                    ReportSectionModel reportSectionModel = new ReportSectionModel()
                    {
                        DBCommand = DBCommandEnum.Original,
                        ReportTypeID = reportSectionModelSibling.ReportTypeID,
                        TVItemID = null,
                        Ordinal = MaxOrdinal,
                        IsStatic = true,
                        ParentReportSectionID = reportSectionModelSibling.ParentReportSectionID,
                        Year = null,
                        Locked = false,
                        TemplateReportSectionID = null,
                        ReportSectionName = reportSectionModelSibling.ReportSectionName + " - " + RandomText,
                        ReportSectionText = reportSectionModelSibling.ReportSectionName + " - " + RandomText,
                        Language = reportSectionModelSibling.Language,
                    };

                    ReportSectionModelRet = PostAddReportSectionDB(reportSectionModel);
                    if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                        return ReturnError(ReportSectionModelRet.Error);

                    LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Add, ReportSectionModelRet);
                    if (!string.IsNullOrWhiteSpace(logModel.Error))
                        return ReturnError(logModel.Error);

                    ts.Complete();
                }

            }
            return GetReportSectionModelWithReportSectionIDDB(ReportSectionModelRet.ReportSectionID);
        }
        public ReportSectionModel PostReportSectionAddTopDB(int ReportTypeID)
        {
            int MaxOrdinal = 0;
            ReportSectionModel reportSectionModelMaxOrdinal = GetReportSectionModelListWithReportTypeIDAndTVItemIDAndYearDB(ReportTypeID, null, null).OrderByDescending(c => c.Ordinal).FirstOrDefault();
            if (reportSectionModelMaxOrdinal != null)
            {
                MaxOrdinal = reportSectionModelMaxOrdinal.Ordinal + 1;
            }

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionModel ReportSectionModelRet = new ReportSectionModel();
            using (TransactionScope ts = new TransactionScope())
            {
                Random r = new Random((int)DateTime.Now.Ticks);
                string RandomText = "";
                for (int i = 0; i < 10; i++)
                {
                    RandomText = RandomText + (char)(r.Next(65, 90));
                }

                ReportSectionModel reportSectionModel = new ReportSectionModel()
                {
                    DBCommand = DBCommandEnum.Original,
                    ReportTypeID = ReportTypeID,
                    TVItemID = null,
                    Ordinal = MaxOrdinal,
                    IsStatic = true,
                    ParentReportSectionID = null,
                    Year = null,
                    Locked = false,
                    TemplateReportSectionID = null,
                    ReportSectionName = ServiceRes.ReportSectionName + " - " + RandomText,
                    ReportSectionText = ServiceRes.ReportSectionName + " - " + RandomText,
                    Language = reportSectionModelMaxOrdinal.Language,
                };

                ReportSectionModelRet = PostAddReportSectionDB(reportSectionModel);
                if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                    return ReturnError(ReportSectionModelRet.Error);

                LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Add, ReportSectionModelRet);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportSectionModelWithReportSectionIDDB(ReportSectionModelRet.ReportSectionID);
        }
        public ReportSectionModel PostReportSectionChangeIsStaticDB(int ReportSectionID, bool IsStatic)
        {
            ReportSectionModel reportSectionModel = GetReportSectionModelWithReportSectionIDDB(ReportSectionID);
            if (!string.IsNullOrWhiteSpace(reportSectionModel.Error))
            {
                return ReturnError(reportSectionModel.Error);
            }

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionModel ReportSectionModelRet = new ReportSectionModel();
            using (TransactionScope ts = new TransactionScope())
            {
                reportSectionModel.IsStatic = IsStatic;

                ReportSectionModelRet = PostUpdateReportSectionDB(reportSectionModel);
                if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                    return ReturnError(ReportSectionModelRet.Error);

                LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Change, ReportSectionModelRet);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportSectionModelWithReportSectionIDDB(ReportSectionModelRet.ReportSectionID);
        }
        public ReportSectionModel PostReportSectionChangeLockedDB(int ReportTypeID, LanguageEnum language, bool Locked)
        {
            List<ReportSectionModel> reportSectionModelList = GetReportSectionModelListWithReportTypeIDAndTVItemIDAndYearDB(ReportTypeID, null, null);

            if (reportSectionModelList.Count == 0)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.ReportSection));
            }

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);


            using (TransactionScope ts = new TransactionScope())
            {
                foreach (ReportSectionModel reportSectionModel in reportSectionModelList)
                {
                    reportSectionModel.Locked = Locked;

                    ReportSectionModel ReportSectionModelRet = PostUpdateReportSectionDB(reportSectionModel);
                    if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                        return ReturnError(ReportSectionModelRet.Error);

                    LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Change, ReportSectionModelRet);
                    if (!string.IsNullOrWhiteSpace(logModel.Error))
                        return ReturnError(logModel.Error);
                }

                ts.Complete();
            }
            return GetReportSectionModelWithReportSectionIDDB(reportSectionModelList[0].ReportSectionID);
        }
        public ReportSectionModel PostReportSectionConvertToParentDB(int ReportSectionID)
        {
            ReportSectionModel reportSectionModel = GetReportSectionModelWithReportSectionIDDB(ReportSectionID);
            if (!string.IsNullOrWhiteSpace(reportSectionModel.Error))
            {
                return ReturnError(reportSectionModel.Error);
            }

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionModel ReportSectionModelRet = new ReportSectionModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (reportSectionModel.ParentReportSectionID != null)
                {
                    ReportSectionModel reportSectionModelParent = GetReportSectionModelWithReportSectionIDDB((int)reportSectionModel.ParentReportSectionID);
                    if (!string.IsNullOrWhiteSpace(reportSectionModelParent.Error))
                    {
                        return ReturnError(reportSectionModelParent.Error);
                    }

                    reportSectionModel.ParentReportSectionID = reportSectionModelParent.ParentReportSectionID;

                    ReportSectionModelRet = PostUpdateReportSectionDB(reportSectionModel);
                    if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                        return ReturnError(ReportSectionModelRet.Error);

                    LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Change, ReportSectionModelRet);
                    if (!string.IsNullOrWhiteSpace(logModel.Error))
                        return ReturnError(logModel.Error);

                }

                ts.Complete();
            }
            return GetReportSectionModelWithReportSectionIDDB(ReportSectionModelRet.ReportSectionID);
        }
        public ReportSectionModel PostReportSectionConvertToSubSectionDB(int ReportSectionID)
        {
            ReportSectionModel reportSectionModel = GetReportSectionModelWithReportSectionIDDB(ReportSectionID);
            if (!string.IsNullOrWhiteSpace(reportSectionModel.Error))
            {
                return ReturnError(reportSectionModel.Error);
            }

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionModel ReportSectionModelRet = new ReportSectionModel();
            using (TransactionScope ts = new TransactionScope())
            {
                List<ReportSectionModel> reportSectionModelList = GetReportSectionModelListWithReportTypeIDAndTVItemIDAndYearDB(reportSectionModel.ReportTypeID, reportSectionModel.TVItemID, reportSectionModel.Year).Where(c => c.ParentReportSectionID == reportSectionModel.ParentReportSectionID).OrderBy(c => c.Ordinal).ToList();

                for (int i = 0, count = reportSectionModelList.Count; i < count; i++)
                {
                    if (reportSectionModelList[i].ReportSectionID == ReportSectionID)
                    {
                        if (i > 0)
                        {
                            ReportSectionModel reportSectionModelParent = reportSectionModelList[i - 1];

                            reportSectionModel.ParentReportSectionID = reportSectionModelParent.ReportSectionID;

                            ReportSectionModelRet = PostUpdateReportSectionDB(reportSectionModel);
                            if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                                return ReturnError(ReportSectionModelRet.Error);

                            LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Change, ReportSectionModelRet);
                            if (!string.IsNullOrWhiteSpace(logModel.Error))
                                return ReturnError(logModel.Error);

                            break;
                        }
                    }
                }


                ts.Complete();
            }
            return GetReportSectionModelWithReportSectionIDDB(ReportSectionModelRet.ReportSectionID);
        }
        public ReportSectionModel PostReportSectionAddNewYearForTVItemIDDB(int ReportSectionID, int TVItemID, int Year)
        {
            ReportSectionModel reportSectionModel = GetReportSectionModelWithReportSectionIDDB(ReportSectionID);
            if (!string.IsNullOrWhiteSpace(reportSectionModel.Error))
            {
                return ReturnError(reportSectionModel.Error);
            }

            if (reportSectionModel.IsStatic)
            {
                return ReturnError(ServiceRes.StaticSectionOfReportCannotHaveACopyForYear);
            }

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionModel reportSectionModelToCopy = new ReportSectionModel()
            {
                DBCommand = DBCommandEnum.Original,
                ReportTypeID = reportSectionModel.ReportTypeID,
                TVItemID = TVItemID,
                Ordinal = reportSectionModel.Ordinal,
                IsStatic = reportSectionModel.IsStatic,
                ParentReportSectionID = reportSectionModel.ParentReportSectionID,
                Year = Year,
                Locked = false,
                TemplateReportSectionID = reportSectionModel.ReportSectionID,
                ReportSectionName = "---",
                ReportSectionText = ServiceRes.CopyOf + " - " + reportSectionModel.ReportSectionText,
                Language = reportSectionModel.Language,
            };

            ReportSectionModel reportSectionModelExist = GetReportSectionModelExistDB(reportSectionModelToCopy);
            if (!string.IsNullOrWhiteSpace(reportSectionModel.Error))
            {
                return ReturnError(reportSectionModel.Error);
            }

            ReportSectionModel ReportSectionModelRet = new ReportSectionModel();
            using (TransactionScope ts = new TransactionScope())
            {
                ReportSectionModelRet = PostAddReportSectionDB(reportSectionModelToCopy);

                LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Add, ReportSectionModelRet);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetReportSectionModelWithReportSectionIDDB(ReportSectionModelRet.ReportSectionID);
        }
        public ReportSectionModel PostReportSectionNameModifyDB(FormCollection fc)
        {
            int ReportSectionID = 0;
            string ReportSectionName = "";

            int.TryParse(fc["ReportSectionID"], out ReportSectionID);
            if (ReportSectionID == 0)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ReportSectionID));
            }

            ReportSectionModel reportSectionModel = GetReportSectionModelWithReportSectionIDDB(ReportSectionID);
            if (!string.IsNullOrWhiteSpace(reportSectionModel.Error))
            {
                return ReturnError(reportSectionModel.Error);
            }

            ReportSectionName = fc["ReportSectionName"];

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionModel ReportSectionModelRet = new ReportSectionModel();
            using (TransactionScope ts = new TransactionScope())
            {
                reportSectionModel.ReportSectionName = ReportSectionName;

                ReportSectionModelRet = PostUpdateReportSectionDB(reportSectionModel);
                if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                    return ReturnError(ReportSectionModelRet.Error);

                LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Add, ReportSectionModelRet);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportSectionModelWithReportSectionIDDB(ReportSectionModelRet.ReportSectionID);
        }
        public ReportSectionModel PostReportSectionTextModifyDB(FormCollection fc)
        {
            int ReportSectionID = 0;
            string ReportSectionText = "";

            int.TryParse(fc["ReportSectionID"], out ReportSectionID);
            if (ReportSectionID == 0)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ReportSectionID));
            }

            ReportSectionModel reportSectionModel = GetReportSectionModelWithReportSectionIDDB(ReportSectionID);
            if (!string.IsNullOrWhiteSpace(reportSectionModel.Error))
            {
                return ReturnError(reportSectionModel.Error);
            }

            ReportSectionText = fc["ReportSectionText"];

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionModel ReportSectionModelRet = new ReportSectionModel();
            using (TransactionScope ts = new TransactionScope())
            {
                reportSectionModel.ReportSectionText = ReportSectionText;

                ReportSectionModelRet = PostUpdateReportSectionDB(reportSectionModel);
                if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                    return ReturnError(ReportSectionModelRet.Error);

                LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Add, ReportSectionModelRet);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportSectionModelWithReportSectionIDDB(ReportSectionModelRet.ReportSectionID);
        }
        public ReportSectionModel PostReportSectionOrdinalDownDB(int ReportSectionID)
        {
            ReportSectionModel reportSectionModel = GetReportSectionModelWithReportSectionIDDB(ReportSectionID);
            if (!string.IsNullOrWhiteSpace(reportSectionModel.Error))
            {
                return ReturnError(reportSectionModel.Error);
            }

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionModel ReportSectionModelRet = new ReportSectionModel();
            using (TransactionScope ts = new TransactionScope())
            {
                List<ReportSectionModel> reportSectionModelList = GetReportSectionModelListWithReportTypeIDAndTVItemIDAndYearDB(reportSectionModel.ReportTypeID, reportSectionModel.TVItemID, reportSectionModel.Year).Where(c => c.ParentReportSectionID == reportSectionModel.ParentReportSectionID).OrderBy(c => c.Ordinal).ToList();

                for (int i = 0, count = reportSectionModelList.Count; i < count; i++)
                {
                    if (reportSectionModelList[i].ReportSectionID == ReportSectionID)
                    {
                        if (i < (reportSectionModelList.Count - 1))
                        {
                            int TempOrdinal = reportSectionModelList[i].Ordinal;
                            reportSectionModelList[i].Ordinal = reportSectionModelList[i + 1].Ordinal;
                            reportSectionModelList[i + 1].Ordinal = TempOrdinal;

                            ReportSectionModelRet = PostUpdateReportSectionDB(reportSectionModelList[i]);
                            if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                                return ReturnError(ReportSectionModelRet.Error);

                            LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Change, ReportSectionModelRet);
                            if (!string.IsNullOrWhiteSpace(logModel.Error))
                                return ReturnError(logModel.Error);

                            ReportSectionModelRet = PostUpdateReportSectionDB(reportSectionModelList[i + 1]);
                            if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                                return ReturnError(ReportSectionModelRet.Error);

                            logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Change, ReportSectionModelRet);
                            if (!string.IsNullOrWhiteSpace(logModel.Error))
                                return ReturnError(logModel.Error);
                        }
                    }
                }


                ts.Complete();
            }
            return GetReportSectionModelWithReportSectionIDDB(ReportSectionModelRet.ReportSectionID);
        }
        public ReportSectionModel PostReportSectionOrdinalUpDB(int ReportSectionID)
        {
            ReportSectionModel reportSectionModel = GetReportSectionModelWithReportSectionIDDB(ReportSectionID);
            if (!string.IsNullOrWhiteSpace(reportSectionModel.Error))
            {
                return ReturnError(reportSectionModel.Error);
            }

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionModel ReportSectionModelRet = new ReportSectionModel();
            using (TransactionScope ts = new TransactionScope())
            {
                List<ReportSectionModel> reportSectionModelList = GetReportSectionModelListWithReportTypeIDAndTVItemIDAndYearDB(reportSectionModel.ReportTypeID, reportSectionModel.TVItemID, reportSectionModel.Year).Where(c => c.ParentReportSectionID == reportSectionModel.ParentReportSectionID).OrderBy(c => c.Ordinal).ToList();

                for (int i = 0, count = reportSectionModelList.Count; i < count; i++)
                {
                    if (reportSectionModelList[i].ReportSectionID == ReportSectionID)
                    {
                        if (i > 0)
                        {
                            int TempOrdinal = reportSectionModelList[i].Ordinal;
                            reportSectionModelList[i].Ordinal = reportSectionModelList[i - 1].Ordinal;
                            reportSectionModelList[i - 1].Ordinal = TempOrdinal;

                            ReportSectionModelRet = PostUpdateReportSectionDB(reportSectionModelList[i]);
                            if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                                return ReturnError(ReportSectionModelRet.Error);

                            LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Change, ReportSectionModelRet);
                            if (!string.IsNullOrWhiteSpace(logModel.Error))
                                return ReturnError(logModel.Error);

                            ReportSectionModelRet = PostUpdateReportSectionDB(reportSectionModelList[i - 1]);
                            if (!string.IsNullOrWhiteSpace(ReportSectionModelRet.Error))
                                return ReturnError(ReportSectionModelRet.Error);

                            logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionModelRet.ReportSectionID, LogCommandEnum.Change, ReportSectionModelRet);
                            if (!string.IsNullOrWhiteSpace(logModel.Error))
                                return ReturnError(logModel.Error);
                        }
                    }
                }


                ts.Complete();
            }
            return GetReportSectionModelWithReportSectionIDDB(ReportSectionModelRet.ReportSectionID);
        }
        public ReportSectionModel PostAddReportSectionDB(ReportSectionModel ReportSectionModel)
        {
            string retStr = ReportSectionModelOK(ReportSectionModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSectionModel ReportSectionModelExist = GetReportSectionModelExistDB(ReportSectionModel);
            if (string.IsNullOrWhiteSpace(ReportSectionModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.ReportSection));

            ReportSection ReportSectionNew = new ReportSection();
            retStr = FillReportSection(ReportSectionNew, ReportSectionModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.ReportSections.Add(ReportSectionNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionNew.ReportSectionID, LogCommandEnum.Add, ReportSectionNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportSectionModelWithReportSectionIDDB(ReportSectionNew.ReportSectionID);
        }
        public ReportSectionModel PostDeleteReportSectionWithReportSectionIDDB(int ReportSectionID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSection ReportSectionToDelete = GetReportSectionWithReportSectionIDDB(ReportSectionID);
            if (ReportSectionToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ReportSection));

            using (TransactionScope ts = new TransactionScope())
            {
                db.ReportSections.Remove(ReportSectionToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionToDelete.ReportSectionID, LogCommandEnum.Delete, ReportSectionToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public ReportSectionModel PostUpdateReportSectionDB(ReportSectionModel ReportSectionModel)
        {
            string retStr = ReportSectionModelOK(ReportSectionModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportSection ReportSectionToUpdate = GetReportSectionWithReportSectionIDDB(ReportSectionModel.ReportSectionID);
            if (ReportSectionToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.ReportSection));

            retStr = FillReportSection(ReportSectionToUpdate, ReportSectionModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ReportSections", ReportSectionToUpdate.ReportSectionID, LogCommandEnum.Change, ReportSectionToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportSectionModelWithReportSectionIDDB(ReportSectionToUpdate.ReportSectionID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
