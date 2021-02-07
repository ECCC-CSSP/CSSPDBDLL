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
    public class ReportTypeService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public ReportTypeService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string ReportTypeModelOK(ReportTypeModel reportTypeModel)
        {
            string retStr = _BaseEnumService.TVTypeOK(reportTypeModel.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.FileTypeOK(reportTypeModel.FileType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(reportTypeModel.UniqueCode, ServiceRes.UniqueCode, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(reportTypeModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(reportTypeModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillReportType(ReportType reportType, ReportTypeModel reportTypeModel, ContactOK contactOK)
        {
            reportType.DBCommand = (int)reportTypeModel.DBCommand;
            reportType.ReportTypeID = reportTypeModel.ReportTypeID;
            reportType.TVType = (int)reportTypeModel.TVType;
            reportType.FileType = (int)reportTypeModel.FileType;
            reportType.UniqueCode = reportTypeModel.UniqueCode;
            reportType.Language = (int)reportTypeModel.Language;
            reportType.Name = reportTypeModel.Name;
            reportType.Description = reportTypeModel.Description;
            reportType.StartOfFileName = reportTypeModel.StartOfFileName;
            reportType.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                reportType.LastUpdateContactTVItemID = 2;
            }
            else
            {
                reportType.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetReportTypeModelCountDB()
        {
            int ReportTypeModelCount = (from c in db.ReportTypes
                                        select c).Count();

            return ReportTypeModelCount;
        }
        public List<ReportTypeModel> GetReportTypeModelListWithLanguageDB(LanguageEnum language)
        {
            List<ReportTypeModel> ReportTypeModelList = (from c in db.ReportTypes
                                                         where c.Language == (int)language
                                                         orderby c.TVType
                                                         select new ReportTypeModel
                                                         {
                                                             Error = "",
                                                             ReportTypeID = c.ReportTypeID,
                                                             DBCommand = DBCommandEnum.Original,
                                                             TVType = (TVTypeEnum)c.TVType,
                                                             FileType = (FileTypeEnum)c.FileType,
                                                             UniqueCode = c.UniqueCode,
                                                             Language = (LanguageEnum)c.Language,
                                                             Name = c.Name,
                                                             Description = c.Description,
                                                             StartOfFileName = c.StartOfFileName,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).ToList<ReportTypeModel>();

            return ReportTypeModelList;
        }
        public List<ReportTypeModel> GetReportTypeModelListWithTVTypeAndLanguageDB(TVTypeEnum TVType, LanguageEnum language)
        {
            List<ReportTypeModel> ReportTypeModelList = (from c in db.ReportTypes
                                                         where c.TVType == (int)TVType
                                                         && c.Language == (int)language
                                                         orderby c.TVType
                                                         select new ReportTypeModel
                                                         {
                                                             Error = "",
                                                             ReportTypeID = c.ReportTypeID,
                                                             DBCommand = DBCommandEnum.Original,
                                                             TVType = (TVTypeEnum)c.TVType,
                                                             FileType = (FileTypeEnum)c.FileType,
                                                             UniqueCode = c.UniqueCode,
                                                             Language = (LanguageEnum)c.Language,
                                                             Name = c.Name,
                                                             Description = c.Description,
                                                             StartOfFileName = c.StartOfFileName,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).ToList<ReportTypeModel>();

            return ReportTypeModelList;
        }
        public ReportTypeModel GetReportTypeModelWithReportTypeIDDB(int ReportTypeID)
        {
            ReportTypeModel reportTypeModel = (from c in db.ReportTypes
                                               where c.ReportTypeID == ReportTypeID
                                               orderby c.TVType
                                               select new ReportTypeModel
                                               {
                                                   Error = "",
                                                   ReportTypeID = c.ReportTypeID,
                                                   DBCommand = DBCommandEnum.Original,
                                                   TVType = (TVTypeEnum)c.TVType,
                                                   FileType = (FileTypeEnum)c.FileType,
                                                   UniqueCode = c.UniqueCode,
                                                   Language = (LanguageEnum)c.Language,
                                                   Name = c.Name,
                                                   Description = c.Description,
                                                   StartOfFileName = c.StartOfFileName,
                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                               }).FirstOrDefault<ReportTypeModel>();

            if (reportTypeModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ReportType, ServiceRes.ReportTypeID, ReportTypeID.ToString()));
            }

            return reportTypeModel;
        }
        public ReportType GetReportTypeWithReportTypeIDDB(int ReportTypeID)
        {
            ReportType reportType = (from c in db.ReportTypes
                                     where c.ReportTypeID == ReportTypeID
                                     select c).FirstOrDefault<ReportType>();

            return reportType;
        }
        public ReportTypeModel GetReportTypeModelWithUniqueCodeDB(string UniqueCode)
        {
            ReportTypeModel reportTypeModelRet = (from c in db.ReportTypes
                                                  where c.UniqueCode == UniqueCode
                                                  select new ReportTypeModel
                                                  {
                                                      Error = "",
                                                      ReportTypeID = c.ReportTypeID,
                                                      DBCommand = DBCommandEnum.Original,
                                                      TVType = (TVTypeEnum)c.TVType,
                                                      FileType = (FileTypeEnum)c.FileType,
                                                      UniqueCode = c.UniqueCode,
                                                      Language = (LanguageEnum)c.Language,
                                                      Name = c.Name,
                                                      Description = c.Description,
                                                      StartOfFileName = c.StartOfFileName,
                                                      LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                      LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                  }).FirstOrDefault<ReportTypeModel>();

            if (reportTypeModelRet == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ReportType, ServiceRes.UniqueCode, UniqueCode));
            }

            return reportTypeModelRet;
        }

        // Helper
        public ReportTypeModel ReturnError(string Error)
        {
            return new ReportTypeModel() { Error = Error };
        }

        public ReportTypeModel PostAddOrModifyReportTypeDB(FormCollection fc)
        {
            int tempInt = 0;
            int ReportTypeID = 0;
            TVTypeEnum TVType = TVTypeEnum.Error;
            FileTypeEnum FileType = FileTypeEnum.Error;
            string UniqueCode = "";
            LanguageEnum Language = LanguageEnum.Error;
            //string Name = "";
            //string StartOfFileName = "";
            //string Description = "";

            int.TryParse(fc["ReportTypeID"], out ReportTypeID);
            // if ReportTypeID == 0 then we should create a new one else we should modify the existing one

            ReportTypeModel reportTypeModel = new ReportTypeModel();
            if (ReportTypeID != 0)
            {
                reportTypeModel = GetReportTypeModelWithReportTypeIDDB(ReportTypeID);
                if (!string.IsNullOrWhiteSpace(reportTypeModel.Error))
                    return ReturnError(reportTypeModel.Error);
            }

            reportTypeModel.DBCommand = DBCommandEnum.Original;

            int.TryParse(fc["TVType"], out tempInt);
            TVType = (TVTypeEnum)tempInt;
            reportTypeModel.TVType = TVType;

            int.TryParse(fc["FileType"], out tempInt);
            FileType = (FileTypeEnum)tempInt;
            reportTypeModel.FileType = FileType;

            UniqueCode = fc["UniqueCode"];
            reportTypeModel.UniqueCode = UniqueCode;

            int.TryParse(fc["Language"], out tempInt);
            Language = (LanguageEnum)tempInt;
            reportTypeModel.Language = Language;

            reportTypeModel.Name = fc["Name"];
            reportTypeModel.StartOfFileName = fc["StartOfFileName"];
            reportTypeModel.Description = fc["Description"];

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportTypeModel reportTypeModelHasUniqueCode = GetReportTypeModelWithUniqueCodeDB(UniqueCode);
            if (string.IsNullOrWhiteSpace(reportTypeModelHasUniqueCode.Error))
            {
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.UniqueCode));
            }

            ReportTypeModel reportTypeModelRet = new ReportTypeModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (ReportTypeID == 0)
                {
                    reportTypeModelRet = PostAddReportTypeDB(reportTypeModel);
                    if (!string.IsNullOrWhiteSpace(reportTypeModelRet.Error))
                        return ReturnError(reportTypeModelRet.Error);

                    LogModel logModel = _LogService.PostAddLogForObj("ReportTypes", reportTypeModelRet.ReportTypeID, LogCommandEnum.Add, reportTypeModelRet);
                    if (!string.IsNullOrWhiteSpace(logModel.Error))
                        return ReturnError(logModel.Error);
                }
                else
                {
                    reportTypeModelRet = PostUpdateReportTypeDB(reportTypeModel);
                    if (!string.IsNullOrWhiteSpace(reportTypeModelRet.Error))
                        return ReturnError(reportTypeModelRet.Error);

                    LogModel logModel = _LogService.PostAddLogForObj("ReportTypes", reportTypeModelRet.ReportTypeID, LogCommandEnum.Change, reportTypeModelRet);
                    if (!string.IsNullOrWhiteSpace(logModel.Error))
                        return ReturnError(logModel.Error);
                }

                ts.Complete();
            }
            return GetReportTypeModelWithReportTypeIDDB(reportTypeModelRet.ReportTypeID);
        }
        public ReportTypeModel PostAddReportTypeDB(ReportTypeModel reportTypeModel)
        {
            string retStr = ReportTypeModelOK(reportTypeModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportTypeModel reportTypeModelExist = GetReportTypeModelWithUniqueCodeDB(reportTypeModel.UniqueCode);
            if (string.IsNullOrWhiteSpace(reportTypeModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.ReportType));

            ReportType reportTypeNew = new ReportType();
            retStr = FillReportType(reportTypeNew, reportTypeModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.ReportTypes.Add(reportTypeNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ReportTypes", reportTypeNew.ReportTypeID, LogCommandEnum.Add, reportTypeNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportTypeModelWithReportTypeIDDB(reportTypeNew.ReportTypeID);
        }
        public ReportTypeModel PostDeleteReportTypeWithReportTypeIDDB(int ReportTypeID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportType reportTypeToDelete = GetReportTypeWithReportTypeIDDB(ReportTypeID);
            if (reportTypeToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ReportType));

            using (TransactionScope ts = new TransactionScope())
            {
                db.ReportTypes.Remove(reportTypeToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ReportTypes", reportTypeToDelete.ReportTypeID, LogCommandEnum.Delete, reportTypeToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public ReportTypeModel PostUpdateReportTypeDB(ReportTypeModel reportTypeModel)
        {
            string retStr = ReportTypeModelOK(reportTypeModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ReportType reportTypeToUpdate = GetReportTypeWithReportTypeIDDB(reportTypeModel.ReportTypeID);
            if (reportTypeToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.ReportType));

            retStr = FillReportType(reportTypeToUpdate, reportTypeModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ReportTypes", reportTypeToUpdate.ReportTypeID, LogCommandEnum.Change, reportTypeToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetReportTypeModelWithReportTypeIDDB(reportTypeToUpdate.ReportTypeID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
