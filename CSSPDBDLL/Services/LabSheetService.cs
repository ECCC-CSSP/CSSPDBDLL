using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using System.IO;
using System.Web.Mvc;
using System.Net.Mail;
using System.Collections.Specialized;
using System.Net;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPLabSheetParserDLL.Services;
using System.Threading;
using System.Globalization;

namespace CSSPDBDLL.Services
{
    public class LabSheetService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public MWQMRunService _MWQMRunService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public MWQMSiteService _MWQMSiteService { get; private set; }
        public MWQMSampleService _MWQMSampleService { get; private set; }
        public TVFileService _TVFileService { get; private set; }
        public AppTaskService _AppTaskService { get; private set; }
        public ContactService _ContactService { get; private set; }
        public SamplingPlanService _SamplingPlanService { get; private set; }
        public SamplingPlanEmailService _SamplingPlanEmailService { get; private set; }
        public CSSPLabSheetParser _CSSPLabSheetParser { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public LabSheetService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _MWQMRunService = new MWQMRunService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _MWQMSiteService = new MWQMSiteService(LanguageRequest, User);
            _MWQMSampleService = new MWQMSampleService(LanguageRequest, User);
            _TVFileService = new TVFileService(LanguageRequest, User);
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _ContactService = new ContactService(LanguageRequest, User);
            _SamplingPlanService = new SamplingPlanService(LanguageRequest, User);
            _SamplingPlanEmailService = new SamplingPlanEmailService(LanguageRequest, User);
            _CSSPLabSheetParser = new CSSPLabSheetParser();
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
        public override string SendEmail(MailMessage mail)
        {
            return base.SendEmail(mail);
        }

        // Check
        public string LabSheetModelOK(LabSheetModel labSheetModel)
        {
            string retStr = FieldCheckNotZeroInt(labSheetModel.OtherServerLabSheetID, ServiceRes.OtherServerLabSheetID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(labSheetModel.SamplingPlanID, ServiceRes.SamplingPlanID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(labSheetModel.SamplingPlanName, ServiceRes.SamplingPlanName, 6, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(labSheetModel.Year, ServiceRes.Year, 2000, 2050);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(labSheetModel.Month, ServiceRes.Month, 1, 12);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(labSheetModel.Day, ServiceRes.Day, 1, 31);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(labSheetModel.RunNumber, ServiceRes.RunNumber, 1, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(labSheetModel.SubsectorTVItemID, ServiceRes.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(labSheetModel.MWQMRunTVItemID, ServiceRes.MWQMRunTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.SamplingPlanTypeOK(labSheetModel.SamplingPlanType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.SampleTypeOK(labSheetModel.SampleType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LabSheetTypeOK(labSheetModel.LabSheetType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LabSheetStatusOK(labSheetModel.LabSheetStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(labSheetModel.FileName, ServiceRes.FileName, 10, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(labSheetModel.FileLastModifiedDate_Local, ServiceRes.FileLastModifiedDate_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(labSheetModel.FileContent, ServiceRes.FileContent, 100, 100000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(labSheetModel.AcceptedOrRejectedByContactTVItemID, ServiceRes.ApprovedOrRejectedByContactTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (labSheetModel.AcceptedOrRejectedByContactTVItemID != null)
            {
                retStr = FieldCheckNotNullDateTime(labSheetModel.AcceptedOrRejectedDateTime, ServiceRes.ApprovedOrRejectedDateTime);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            return "";
        }

        // Fill
        public string FillLabSheet(LabSheet labSheet, LabSheetModel labSheetModel, ContactOK contactOK)
        {
            labSheet.OtherServerLabSheetID = labSheetModel.OtherServerLabSheetID;
            labSheet.SamplingPlanID = labSheetModel.SamplingPlanID;
            labSheet.SamplingPlanName = labSheetModel.SamplingPlanName;
            labSheet.Year = labSheetModel.Year;
            labSheet.Month = labSheetModel.Month;
            labSheet.Day = labSheetModel.Day;
            labSheet.RunNumber = labSheetModel.RunNumber;
            labSheet.SubsectorTVItemID = labSheetModel.SubsectorTVItemID;
            labSheet.MWQMRunTVItemID = labSheetModel.MWQMRunTVItemID;
            labSheet.SamplingPlanType = (int)labSheetModel.SamplingPlanType;
            labSheet.SampleType = (int)labSheetModel.SampleType;
            labSheet.LabSheetType = (int)labSheetModel.LabSheetType;
            labSheet.LabSheetStatus = (int)labSheetModel.LabSheetStatus;
            labSheet.FileName = labSheetModel.FileName;
            labSheet.FileLastModifiedDate_Local = labSheetModel.FileLastModifiedDate_Local;
            labSheet.FileContent = labSheetModel.FileContent;
            labSheet.AcceptedOrRejectedByContactTVItemID = labSheetModel.AcceptedOrRejectedByContactTVItemID;
            labSheet.AcceptedOrRejectedDateTime = labSheetModel.AcceptedOrRejectedDateTime;
            labSheet.RejectReason = labSheetModel.RejectReason;
            labSheet.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                labSheet.LastUpdateContactTVItemID = 2;
            }
            else
            {
                labSheet.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetLabSheetModelCountDB()
        {
            int LabSheetModelCount = (from c in db.LabSheets
                                      select c).Count();

            return LabSheetModelCount;
        }
        public LabSheetModel GetLabSheetModelExistDB(LabSheetModel labSheetModel)
        {
            LabSheetModel labSheetModelRet = (from c in db.LabSheets
                                              let subsectorTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault()
                                              let contactTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.AcceptedOrRejectedByContactTVItemID select cl.TVText).FirstOrDefault()
                                              let mwqmRunTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault()
                                              where c.OtherServerLabSheetID == labSheetModel.OtherServerLabSheetID
                                              && c.SamplingPlanName == labSheetModel.SamplingPlanName
                                              && c.Year == labSheetModel.Year
                                              && c.Month == labSheetModel.Month
                                              && c.Day == labSheetModel.Day
                                              && c.RunNumber == labSheetModel.RunNumber
                                              && c.SamplingPlanType == (int)labSheetModel.SamplingPlanType
                                              && c.SampleType == (int)labSheetModel.SampleType
                                              && c.LabSheetType == (int)labSheetModel.LabSheetType
                                              && c.SubsectorTVItemID == labSheetModel.SubsectorTVItemID
                                              select new LabSheetModel
                                              {
                                                  Error = "",
                                                  LabSheetID = c.LabSheetID,
                                                  OtherServerLabSheetID = c.OtherServerLabSheetID,
                                                  SamplingPlanID = c.SamplingPlanID,
                                                  SamplingPlanName = c.SamplingPlanName,
                                                  Year = c.Year,
                                                  Month = c.Month,
                                                  Day = c.Day,
                                                  RunNumber = c.RunNumber,
                                                  SubsectorTVItemID = c.SubsectorTVItemID,
                                                  SubsectorTVText = subsectorTVText,
                                                  MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                                  MWQMRunTVText = mwqmRunTVText,
                                                  FileName = c.FileName,
                                                  SamplingPlanType = (SamplingPlanTypeEnum)c.SamplingPlanType,
                                                  SampleType = (SampleTypeEnum)c.SampleType,
                                                  LabSheetType = (LabSheetTypeEnum)c.LabSheetType,
                                                  LabSheetStatus = (LabSheetStatusEnum)c.LabSheetStatus,
                                                  FileContent = c.FileContent,
                                                  FileLastModifiedDate_Local = c.FileLastModifiedDate_Local,
                                                  AcceptedOrRejectedByContactTVItemID = c.AcceptedOrRejectedByContactTVItemID,
                                                  AcceptedOrRejectedByContactTVText = contactTVText,
                                                  AcceptedOrRejectedDateTime = c.AcceptedOrRejectedDateTime,
                                                  RejectReason = c.RejectReason,
                                                  LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                  LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                              }).FirstOrDefault<LabSheetModel>();

            if (labSheetModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.LabSheet,
                    ServiceRes.SamplingPlanName + "," +
                    ServiceRes.Year + "," +
                    ServiceRes.Month + "," +
                    ServiceRes.Day + "," +
                    ServiceRes.RunNumber + "," +
                    ServiceRes.SamplingPlanType + "," +
                    ServiceRes.SampleType + "," +
                    ServiceRes.LabSheetType + "," +
                    ServiceRes.SubsectorTVItemID,
                    labSheetModel.SamplingPlanName + "," +
                    labSheetModel.Year.ToString() + "," +
                    labSheetModel.Month.ToString() + "," +
                    labSheetModel.Day.ToString() + "," +
                    labSheetModel.RunNumber.ToString() + "," +
                    labSheetModel.SamplingPlanType.ToString() + "," +
                    labSheetModel.SampleType.ToString() + "," +
                    labSheetModel.LabSheetType.ToString() + "," +
                    labSheetModel.SubsectorTVItemID.ToString()));

            return labSheetModelRet;
        }
        public List<LabSheetModel> GetLabSheetModelListWithMWQMRunTVItemIDDB(int MWQMRunTVItemID)
        {
            List<LabSheetModel> LabSheetModelList = (from c in db.LabSheets
                                                     let subsectorTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault()
                                                     let contactTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.AcceptedOrRejectedByContactTVItemID select cl.TVText).FirstOrDefault()
                                                     let mwqmRunTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault()
                                                     where c.MWQMRunTVItemID == MWQMRunTVItemID
                                                     orderby c.Year, c.Month, c.Day, c.RunNumber
                                                     select new LabSheetModel
                                                     {
                                                         Error = "",
                                                         LabSheetID = c.LabSheetID,
                                                         OtherServerLabSheetID = c.OtherServerLabSheetID,
                                                         SamplingPlanID = c.SamplingPlanID,
                                                         SamplingPlanName = c.SamplingPlanName,
                                                         Year = c.Year,
                                                         Month = c.Month,
                                                         Day = c.Day,
                                                         RunNumber = c.RunNumber,
                                                         SubsectorTVItemID = c.SubsectorTVItemID,
                                                         SubsectorTVText = subsectorTVText,
                                                         MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                                         MWQMRunTVText = mwqmRunTVText,
                                                         FileName = c.FileName,
                                                         SamplingPlanType = (SamplingPlanTypeEnum)c.SamplingPlanType,
                                                         SampleType = (SampleTypeEnum)c.SampleType,
                                                         LabSheetType = (LabSheetTypeEnum)c.LabSheetType,
                                                         LabSheetStatus = (LabSheetStatusEnum)c.LabSheetStatus,
                                                         FileContent = c.FileContent,
                                                         FileLastModifiedDate_Local = c.FileLastModifiedDate_Local,
                                                         AcceptedOrRejectedByContactTVItemID = c.AcceptedOrRejectedByContactTVItemID,
                                                         AcceptedOrRejectedByContactTVText = contactTVText,
                                                         AcceptedOrRejectedDateTime = c.AcceptedOrRejectedDateTime,
                                                         RejectReason = c.RejectReason,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).ToList<LabSheetModel>();

            return LabSheetModelList;
        }
        public List<LabSheetModel> GetLabSheetModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<LabSheetModel> LabSheetModelList = (from c in db.LabSheets
                                                     let subsectorTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault()
                                                     let contactTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.AcceptedOrRejectedByContactTVItemID select cl.TVText).FirstOrDefault()
                                                     let mwqmRunTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault()
                                                     where c.SubsectorTVItemID == SubsectorTVItemID
                                                     orderby c.Year, c.Month, c.Day, c.RunNumber
                                                     select new LabSheetModel
                                                     {
                                                         Error = "",
                                                         LabSheetID = c.LabSheetID,
                                                         OtherServerLabSheetID = c.OtherServerLabSheetID,
                                                         SamplingPlanID = c.SamplingPlanID,
                                                         SamplingPlanName = c.SamplingPlanName,
                                                         Year = c.Year,
                                                         Month = c.Month,
                                                         Day = c.Day,
                                                         RunNumber = c.RunNumber,
                                                         SubsectorTVItemID = c.SubsectorTVItemID,
                                                         SubsectorTVText = subsectorTVText,
                                                         MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                                         MWQMRunTVText = mwqmRunTVText,
                                                         FileName = c.FileName,
                                                         SamplingPlanType = (SamplingPlanTypeEnum)c.SamplingPlanType,
                                                         SampleType = (SampleTypeEnum)c.SampleType,
                                                         LabSheetType = (LabSheetTypeEnum)c.LabSheetType,
                                                         LabSheetStatus = (LabSheetStatusEnum)c.LabSheetStatus,
                                                         FileContent = c.FileContent,
                                                         FileLastModifiedDate_Local = c.FileLastModifiedDate_Local,
                                                         AcceptedOrRejectedByContactTVItemID = c.AcceptedOrRejectedByContactTVItemID,
                                                         AcceptedOrRejectedByContactTVText = contactTVText,
                                                         AcceptedOrRejectedDateTime = c.AcceptedOrRejectedDateTime,
                                                         RejectReason = c.RejectReason,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).ToList<LabSheetModel>();

            return LabSheetModelList;
        }
        public List<LabSheetModel> GetLabSheetModelListWithSamplingPlanIDDB(int SamplingPlanID)
        {
            List<LabSheetModel> LabSheetModelList = (from c in db.LabSheets
                                                     let subsectorTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault()
                                                     let contactTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.AcceptedOrRejectedByContactTVItemID select cl.TVText).FirstOrDefault()
                                                     let mwqmRunTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault()
                                                     where c.SamplingPlanID == SamplingPlanID
                                                     orderby c.Year, c.Month, c.Day, c.RunNumber
                                                     select new LabSheetModel
                                                     {
                                                         Error = "",
                                                         LabSheetID = c.LabSheetID,
                                                         OtherServerLabSheetID = c.OtherServerLabSheetID,
                                                         SamplingPlanID = c.SamplingPlanID,
                                                         SamplingPlanName = c.SamplingPlanName,
                                                         Year = c.Year,
                                                         Month = c.Month,
                                                         Day = c.Day,
                                                         RunNumber = c.RunNumber,
                                                         SubsectorTVItemID = c.SubsectorTVItemID,
                                                         SubsectorTVText = subsectorTVText,
                                                         MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                                         MWQMRunTVText = mwqmRunTVText,
                                                         FileName = c.FileName,
                                                         SamplingPlanType = (SamplingPlanTypeEnum)c.SamplingPlanType,
                                                         SampleType = (SampleTypeEnum)c.SampleType,
                                                         LabSheetType = (LabSheetTypeEnum)c.LabSheetType,
                                                         LabSheetStatus = (LabSheetStatusEnum)c.LabSheetStatus,
                                                         FileContent = c.FileContent,
                                                         FileLastModifiedDate_Local = c.FileLastModifiedDate_Local,
                                                         AcceptedOrRejectedByContactTVItemID = c.AcceptedOrRejectedByContactTVItemID,
                                                         AcceptedOrRejectedByContactTVText = contactTVText,
                                                         AcceptedOrRejectedDateTime = c.AcceptedOrRejectedDateTime,
                                                         RejectReason = c.RejectReason,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).ToList<LabSheetModel>();

            return LabSheetModelList;
        }
        public List<LabSheetSiteMonitoredCounts> GetLabSheetIDListAndCountSamplesWithSamplingPlanIDDB(int SamplingPlanID)
        {
            List<LabSheetSiteMonitoredCounts> LabSheetSiteMonitoredCountsList = (from c in db.LabSheets
                                                                                 let SamplingPlanSubsectorSiteCount = (from sps in db.SamplingPlanSubsectors
                                                                                                                       from spss in db.SamplingPlanSubsectorSites
                                                                                                                       where sps.SamplingPlanID == SamplingPlanID
                                                                                                                       && sps.SubsectorTVItemID == c.SubsectorTVItemID
                                                                                                                       && sps.SamplingPlanSubsectorID == spss.SamplingPlanSubsectorID
                                                                                                                       select spss).Count()
                                                                                 let LabSheetSiteRoutineCount = (from lsd in db.LabSheetDetails
                                                                                                                 from lst in db.LabSheetTubeMPNDetails
                                                                                                                 where lsd.LabSheetID == c.LabSheetID
                                                                                                                 && lsd.LabSheetDetailID == lst.LabSheetDetailID
                                                                                                                 && lst.SampleType == (int)SampleTypeEnum.Routine
                                                                                                                 && lst.MPN != null
                                                                                                                 select lst).Count()
                                                                                 let LabSheetHasDuplicate = (from lsd in db.LabSheetDetails
                                                                                                             from lst in db.LabSheetTubeMPNDetails
                                                                                                             where lsd.LabSheetID == c.LabSheetID
                                                                                                             && lsd.LabSheetDetailID == lst.LabSheetDetailID
                                                                                                             && lst.SampleType == (int)SampleTypeEnum.DailyDuplicate
                                                                                                             select lst).Any()
                                                                                 where c.SamplingPlanID == SamplingPlanID
                                                                                 select new LabSheetSiteMonitoredCounts
                                                                                 {
                                                                                     Error = "",
                                                                                     SamplingPlanID = SamplingPlanID,
                                                                                     LabSheetID = c.LabSheetID,
                                                                                     SamplingPlanSubsectorSiteCount = SamplingPlanSubsectorSiteCount,
                                                                                     LabSheetSiteRoutineCount = LabSheetSiteRoutineCount,
                                                                                     LabSheetHasDuplicate = LabSheetHasDuplicate
                                                                                 }).ToList<LabSheetSiteMonitoredCounts>();

            return LabSheetSiteMonitoredCountsList;
        }
        public List<LabSheetModel> GetLabSheetModelListWithSamplingPlanIDAndLabSheetStatusDB(int SamplingPlanID, LabSheetStatusEnum labSheetSatus)
        {
            List<LabSheetModel> LabSheetModelList = (from c in db.LabSheets
                                                     let subsectorTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault()
                                                     let contactTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.AcceptedOrRejectedByContactTVItemID select cl.TVText).FirstOrDefault()
                                                     let mwqmRunTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault()
                                                     where c.SamplingPlanID == SamplingPlanID
                                                     && c.LabSheetStatus == (int)labSheetSatus
                                                     orderby c.Year, c.Month, c.Day, c.RunNumber
                                                     select new LabSheetModel
                                                     {
                                                         Error = "",
                                                         LabSheetID = c.LabSheetID,
                                                         OtherServerLabSheetID = c.OtherServerLabSheetID,
                                                         SamplingPlanID = c.SamplingPlanID,
                                                         SamplingPlanName = c.SamplingPlanName,
                                                         Year = c.Year,
                                                         Month = c.Month,
                                                         Day = c.Day,
                                                         RunNumber = c.RunNumber,
                                                         SubsectorTVItemID = c.SubsectorTVItemID,
                                                         SubsectorTVText = subsectorTVText,
                                                         MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                                         MWQMRunTVText = mwqmRunTVText,
                                                         FileName = c.FileName,
                                                         SamplingPlanType = (SamplingPlanTypeEnum)c.SamplingPlanType,
                                                         SampleType = (SampleTypeEnum)c.SampleType,
                                                         LabSheetType = (LabSheetTypeEnum)c.LabSheetType,
                                                         LabSheetStatus = (LabSheetStatusEnum)c.LabSheetStatus,
                                                         FileContent = c.FileContent,
                                                         FileLastModifiedDate_Local = c.FileLastModifiedDate_Local,
                                                         AcceptedOrRejectedByContactTVItemID = c.AcceptedOrRejectedByContactTVItemID,
                                                         AcceptedOrRejectedByContactTVText = contactTVText,
                                                         AcceptedOrRejectedDateTime = c.AcceptedOrRejectedDateTime,
                                                         RejectReason = c.RejectReason,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).ToList<LabSheetModel>();

            return LabSheetModelList;
        }
        public LabSheetModel GetLabSheetModelWithLabSheetIDDB(int LabSheetID)
        {
            LabSheetModel labSheetModel = (from c in db.LabSheets
                                           let subsectorTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault()
                                           let contactTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.AcceptedOrRejectedByContactTVItemID select cl.TVText).FirstOrDefault()
                                           let mwqmRunTVText = (from cl in db.TVItemLanguages where c.MWQMRunTVItemID != null && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault()
                                           where c.LabSheetID == LabSheetID
                                           select new LabSheetModel
                                           {
                                               Error = "",
                                               LabSheetID = c.LabSheetID,
                                               OtherServerLabSheetID = c.OtherServerLabSheetID,
                                               SamplingPlanID = c.SamplingPlanID,
                                               SamplingPlanName = c.SamplingPlanName,
                                               Year = c.Year,
                                               Month = c.Month,
                                               Day = c.Day,
                                               RunNumber = c.RunNumber,
                                               SubsectorTVItemID = c.SubsectorTVItemID,
                                               SubsectorTVText = subsectorTVText,
                                               MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                               MWQMRunTVText = mwqmRunTVText,
                                               FileName = c.FileName,
                                               SamplingPlanType = (SamplingPlanTypeEnum)c.SamplingPlanType,
                                               SampleType = (SampleTypeEnum)c.SampleType,
                                               LabSheetType = (LabSheetTypeEnum)c.LabSheetType,
                                               LabSheetStatus = (LabSheetStatusEnum)c.LabSheetStatus,
                                               FileContent = c.FileContent,
                                               FileLastModifiedDate_Local = c.FileLastModifiedDate_Local,
                                               AcceptedOrRejectedByContactTVItemID = c.AcceptedOrRejectedByContactTVItemID,
                                               AcceptedOrRejectedByContactTVText = contactTVText,
                                               AcceptedOrRejectedDateTime = c.AcceptedOrRejectedDateTime,
                                               RejectReason = c.RejectReason,
                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           }).FirstOrDefault<LabSheetModel>();

            if (labSheetModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheet, ServiceRes.LabSheetID, LabSheetID));

            return labSheetModel;
        }
        public LabSheet GetLabSheetWithLabSheetIDDB(int LabSheetID)
        {
            LabSheet labSheet = (from c in db.LabSheets
                                 where c.LabSheetID == LabSheetID
                                 select c).FirstOrDefault<LabSheet>();

            return labSheet;
        }
        public int GetLabSheetCountWithSamplingPlanIDDB(int SamplingPlanID)
        {
            int LabSheetCount = (from c in db.LabSheets
                                 where c.SamplingPlanID == SamplingPlanID
                                 select c).Count();

            return LabSheetCount;
        }
        public int GetLabSheetCountWithSamplingPlanIDAndLabSheetStatusDB(int SamplingPlanID, LabSheetStatusEnum labSheetStatus)
        {
            int LabSheetCount = (from c in db.LabSheets
                                 where c.SamplingPlanID == SamplingPlanID
                                 && c.LabSheetStatus == (int)labSheetStatus
                                 select c).Count();

            return LabSheetCount;
        }

        // Helper
        public string GetValueWithinBracket(string line)
        {
            string retStr = "";
            if (!line.Contains("|||||["))
            {
                return "";
            }

            int pos = line.IndexOf("|||||[") + 6;
            retStr = line.Substring(pos, line.LastIndexOf("]") - pos);

            return retStr;
        }
        public LabSheetModel ReturnError(string Error)
        {
            return new LabSheetModel() { Error = Error };
        }
        public string CheckFollowingAndCount(int LineNumber, string OldFirstObj, List<string> ValueArr, string ToFollow, int count)
        {
            string retStr = "";
            if (OldFirstObj != ToFollow)
            {
                retStr = string.Format(ServiceRes.ErrorReadingFileAtLine_Error_, LineNumber, string.Format(ServiceRes._HasToBeFollowing_InTheFile, ValueArr[0], ToFollow));
            }
            if (ValueArr.Count != count)
            {
                retStr = string.Format(ServiceRes.ErrorReadingFileAtLine_Error_, LineNumber, string.Format(ServiceRes._Requires_Value, ValueArr[0], count));
            }

            return retStr;
        }

        // Post
        public LabSheetModel AddOrUpdateLabSheetDB(string FullLabSheetText)
        {
            int OtherServerLabSheetID = 0;
            string SamplingPlanName = "";
            int Year = 0;
            int Month = 0;
            int Day = 0;
            int RunNumber = 0;
            int SubsectorTVItemID = 0;
            SamplingPlanTypeEnum SamplingPlanType = SamplingPlanTypeEnum.Error;
            SampleTypeEnum SampleType = SampleTypeEnum.Error;
            LabSheetTypeEnum LabSheetType = LabSheetTypeEnum.Error;
            LabSheetStatusEnum LabSheetStatus = LabSheetStatusEnum.Error;
            string FileName = "";
            DateTime FileLastModifiedDate_Local = new DateTime(2050, 1, 1);
            string FileContent = "";

            // checking that all parameters exist in FullLabSheetText
            List<string> parameterList = new List<string>()
            {
                "OtherServerLabSheetID", "SamplingPlanName", "Year", "Month", "Day", "RunNumber", "SubsectorTVItemID", "SamplingPlanType", "SampleType", "LabSheetType",
                "LabSheetStatus", "FileName", "FileLastModifiedDate_Local", "FileContent",
            };
            for (int i = 0, count = parameterList.Count; i < count; i++)
            {
                if (!FullLabSheetText.Contains((i == 0 ? "" : "\n") + parameterList[i] + "|||||["))
                {
                    return ReturnError(string.Format(ServiceRes.FullLabSheetTextParameter_IsMissing, parameterList[i]));
                }
            }

            List<string> lineList = FullLabSheetText.Split("\r".ToCharArray(), StringSplitOptions.None).ToList();
            for (int i = 0, count = lineList.Count; i < count; i++)
            {
                if (lineList[i][0] == "\n".ToCharArray()[0])
                {
                    lineList[i] = lineList[i].Substring(1);
                }
            }
            int LineCount = lineList.Count;
            for (int j = 0; j < LineCount; j++)
            {
                if (lineList[j].Contains("|||||["))
                {
                    if (lineList[j].StartsWith("OtherServerLabSheetID"))
                    {
                        OtherServerLabSheetID = int.Parse(GetValueWithinBracket(lineList[j]));
                    }
                    else if (lineList[j].StartsWith("SamplingPlanName"))
                    {
                        SamplingPlanName = GetValueWithinBracket(lineList[j]);
                    }
                    else if (lineList[j].StartsWith("Year"))
                    {
                        Year = int.Parse(GetValueWithinBracket(lineList[j]));
                    }
                    else if (lineList[j].StartsWith("Month"))
                    {
                        Month = int.Parse(GetValueWithinBracket(lineList[j]));
                    }
                    else if (lineList[j].StartsWith("Day"))
                    {
                        Day = int.Parse(GetValueWithinBracket(lineList[j]));
                    }
                    else if (lineList[j].StartsWith("RunNumber"))
                    {
                        RunNumber = int.Parse(GetValueWithinBracket(lineList[j]));
                    }
                    else if (lineList[j].StartsWith("SubsectorTVItemID"))
                    {
                        SubsectorTVItemID = int.Parse(GetValueWithinBracket(lineList[j]));
                    }
                    else if (lineList[j].StartsWith("SamplingPlanType"))
                    {
                        for (int i = 1, count = Enum.GetNames(typeof(SamplingPlanTypeEnum)).Count(); i < count; i++)
                        {
                            if (GetValueWithinBracket(lineList[j]) == i.ToString())
                            {
                                SamplingPlanType = (SamplingPlanTypeEnum)i;
                                break;
                            }
                        }
                    }
                    else if (lineList[j].StartsWith("SampleType"))
                    {
                        for (int i = 101, count = Enum.GetNames(typeof(SampleTypeEnum)).Count() + 100; i < count; i++)
                        {
                            if (GetValueWithinBracket(lineList[j]) == i.ToString())
                            {
                                SampleType = (SampleTypeEnum)i;
                                break;
                            }
                        }
                    }
                    else if (lineList[j].StartsWith("LabSheetType"))
                    {
                        for (int i = 1, count = Enum.GetNames(typeof(LabSheetTypeEnum)).Count(); i < count; i++)
                        {
                            if (GetValueWithinBracket(lineList[j]) == i.ToString())
                            {
                                LabSheetType = (LabSheetTypeEnum)i;
                                break;
                            }
                        }
                    }
                    else if (lineList[j].StartsWith("LabSheetStatus"))
                    {
                        LabSheetStatus = LabSheetStatusEnum.Transferred;
                    }
                    else if (lineList[j].StartsWith("FileName"))
                    {
                        FileName = GetValueWithinBracket(lineList[j]);
                    }
                    else if (lineList[j].StartsWith("FileLastModifiedDate_Local"))
                    {
                        List<string> stringList = GetValueWithinBracket(lineList[j]).Split(",".ToCharArray(), StringSplitOptions.None).ToList();
                        FileLastModifiedDate_Local = new DateTime(
                            int.Parse(stringList[0]),  // Year
                            int.Parse(stringList[1]),  // Month
                            int.Parse(stringList[2]),  // Day
                            int.Parse(stringList[3]),  // Hour
                            int.Parse(stringList[4]),  // Minute
                            int.Parse(stringList[5])); // Second
                    }
                    else if (lineList[j].StartsWith("FileContent"))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(lineList[j].Substring(lineList[j].IndexOf("|||||[") + 6));
                        j += 1;
                        while (j < LineCount)
                        {
                            sb.AppendLine(lineList[j]);
                            j += 1;
                        }
                        FileContent = sb.ToString();
                        break;
                    }
                    else
                    {
                        return ReturnError("Could not properly read line [" + j + "]");
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(SamplingPlanName))
                return ReturnError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.SamplingPlanName));

            SamplingPlanModel SamplingPlanModel = _SamplingPlanService.GetSamplingPlanModelWithSamplingPlanNameDB(SamplingPlanName);
            if (!string.IsNullOrWhiteSpace(SamplingPlanModel.Error))
                return ReturnError(SamplingPlanModel.Error);

            LabSheetModel labSheetModelNewOrUpdate = new LabSheetModel()
            {
                OtherServerLabSheetID = OtherServerLabSheetID,
                SamplingPlanID = SamplingPlanModel.SamplingPlanID,
                MWQMRunTVItemID = null,
                SamplingPlanName = SamplingPlanName,
                Year = Year,
                Month = Month,
                Day = Day,
                RunNumber = RunNumber,
                SubsectorTVItemID = SubsectorTVItemID,
                SamplingPlanType = SamplingPlanType,
                SampleType = SampleType,
                LabSheetType = LabSheetType,
                LabSheetStatus = LabSheetStatus,
                FileName = FileName,
                FileLastModifiedDate_Local = FileLastModifiedDate_Local,
                FileContent = FileContent,
            };

            LabSheetModel labSheetModelExist = new LabSheetModel();

            labSheetModelExist = GetLabSheetModelExistDB(labSheetModelNewOrUpdate);
            if (!string.IsNullOrWhiteSpace(labSheetModelExist.Error))
            {
                labSheetModelExist = PostAddLabSheetDB(labSheetModelNewOrUpdate);
                if (!string.IsNullOrWhiteSpace(labSheetModelExist.Error))
                    return ReturnError(labSheetModelExist.Error);
            }
            else
            {
                labSheetModelNewOrUpdate.LabSheetID = labSheetModelExist.LabSheetID;
                labSheetModelExist = PostUpdateLabSheetDB(labSheetModelNewOrUpdate);
                if (!string.IsNullOrWhiteSpace(labSheetModelExist.Error))
                    return ReturnError(labSheetModelExist.Error);
            }

            return labSheetModelExist;
        }
        public string FCFormGenerateDB(int LabSheetID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            LabSheetModel labSheetModel = GetLabSheetModelWithLabSheetIDDB(LabSheetID);
            if (!string.IsNullOrWhiteSpace(labSheetModel.Error))
                return labSheetModel.Error;

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(labSheetModel.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            string ServerFilePath = _TVFileService.GetServerFilePath(labSheetModel.SubsectorTVItemID);
            if (string.IsNullOrWhiteSpace(ServerFilePath))
                return ServiceRes.ServerFilePathIsEmpty;

            DirectoryInfo di = new DirectoryInfo(ServerFilePath);
            if (!di.Exists)
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    return string.Format(ServiceRes.CouldNotCreateDirectory_Error_, di.FullName, ex.Message + (ex.InnerException != null ? ex.InnerException.Message : ""));
                }

            FileInfo fi = new FileInfo(labSheetModel.FileName.Replace(".txt", ".docx"));

            fi = new FileInfo(_TVFileService.ChoseEDriveOrCDrive(ServerFilePath + fi.Name));

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(labSheetModel.SubsectorTVItemID, labSheetModel.SubsectorTVItemID, AppTaskCommandEnum.CreateFCForm);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "LabSheetID", Value = labSheetModel.LabSheetID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "FileName", Value = fi.Name });

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
                TVItemID = labSheetModel.SubsectorTVItemID,
                TVItemID2 = labSheetModel.SubsectorTVItemID,
                AppTaskCommand = AppTaskCommandEnum.CreateFCForm,
                ErrorText = "",
                StatusText = string.Format(ServiceRes.CeatingFile_, fi.Name),
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
                return appTaskModelRet.Error;

            return "";
        }
        public LabSheetModel LabSheetAcceptedDB(int LabSheetID, int TimeOffsetMinutes, int AnalyzeMethod, int SampleMatrix, int Laboratory, string ChangeRunSamplingType)
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            TimeSpan timeSpan = localZone.GetUtcOffset(DateTime.Now);

            DateTime ClientDateTime = DateTime.Now.AddMinutes((int)timeSpan.TotalMinutes + TimeOffsetMinutes);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            LabSheetModel labSheetModel = GetLabSheetModelWithLabSheetIDDB(LabSheetID);
            if (!string.IsNullOrWhiteSpace(labSheetModel.Error))
                return ReturnError(labSheetModel.Error);

            AnalyzeMethodEnum? analyzeMethod = AnalyzeMethodEnum.Error;
            SampleMatrixEnum? sampleMatrix = SampleMatrixEnum.Error;
            LaboratoryEnum? laboratory = LaboratoryEnum.Error;
            List<SampleTypeEnum> sampleTypeList = new List<SampleTypeEnum>();

            if (AnalyzeMethod == 0)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AnalyzeMethod));
            }
            else
            {
                analyzeMethod = (AnalyzeMethodEnum)AnalyzeMethod;
            }

            if (SampleMatrix == 0)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SampleMatrix));
            }
            else
            {
                sampleMatrix = (SampleMatrixEnum)SampleMatrix;
            }

            if (Laboratory == 0)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Laboratory));
            }
            else
            {
                laboratory = (LaboratoryEnum)Laboratory;
            }

            if (ChangeRunSamplingType.Length == 0)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ChangeRunSamplingType));
            }
            bool RoutineExist = false;

            string[] changeArr = ChangeRunSamplingType.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in changeArr)
            {
                int val = int.Parse(s);
                SampleTypeEnum sampleType = (SampleTypeEnum)val;
                if (sampleType == SampleTypeEnum.Routine)
                {
                    RoutineExist = true;
                }
                sampleTypeList.Add(sampleType);
            }

            ChangeRunSamplingType = ChangeRunSamplingType.Replace("|", ",") + ",";

            LabSheetA1Sheet labSheetA1Sheet = ParseLabSheetA1WithLabSheetID(LabSheetID);
            if (!string.IsNullOrWhiteSpace(labSheetA1Sheet.Error))
                return ReturnError(labSheetA1Sheet.Error);

            DateTime? StartDateTime = (from c in labSheetA1Sheet.LabSheetA1MeasurementList
                                       where c.Time != null
                                       orderby c.Time
                                       select c.Time).FirstOrDefault();

            if (StartDateTime == null)
            {
                StartDateTime = new DateTime(int.Parse(labSheetA1Sheet.RunYear), int.Parse(labSheetA1Sheet.RunMonth), int.Parse(labSheetA1Sheet.RunDay), 0, 0, 0);
            }

            DateTime? EndDateTime = (from c in labSheetA1Sheet.LabSheetA1MeasurementList
                                     where c.Time != null
                                     orderby c.Time descending
                                     select c.Time).FirstOrDefault();

            if (EndDateTime == null)
            {
                EndDateTime = new DateTime(int.Parse(labSheetA1Sheet.RunYear), int.Parse(labSheetA1Sheet.RunMonth), int.Parse(labSheetA1Sheet.RunDay), 0, 0, 0);
            }

            DateTime RunDate = new DateTime(int.Parse(labSheetA1Sheet.RunYear), int.Parse(labSheetA1Sheet.RunMonth), int.Parse(labSheetA1Sheet.RunDay));
            DateTime? LabAnalyzeBath1IncubationStartDateTime_Local = null;
            DateTime? LabAnalyzeBath2IncubationStartDateTime_Local = null;
            DateTime? LabAnalyzeBath3IncubationStartDateTime_Local = null;
            try
            {
                LabAnalyzeBath1IncubationStartDateTime_Local = new DateTime(int.Parse(labSheetA1Sheet.RunYear), int.Parse(labSheetA1Sheet.RunMonth), int.Parse(labSheetA1Sheet.RunDay), int.Parse(labSheetA1Sheet.IncubationBath1StartTime.Substring(0, 2)), int.Parse(labSheetA1Sheet.IncubationBath1StartTime.Substring(3, 2)), 0);
            }
            catch (Exception)
            {
                // nothing
            }
            try
            {
                LabAnalyzeBath2IncubationStartDateTime_Local = new DateTime(int.Parse(labSheetA1Sheet.RunYear), int.Parse(labSheetA1Sheet.RunMonth), int.Parse(labSheetA1Sheet.RunDay), int.Parse(labSheetA1Sheet.IncubationBath2StartTime.Substring(0, 2)), int.Parse(labSheetA1Sheet.IncubationBath2StartTime.Substring(3, 2)), 0);
            }
            catch (Exception)
            {
                // nothing
            }
            try
            {
                LabAnalyzeBath3IncubationStartDateTime_Local = new DateTime(int.Parse(labSheetA1Sheet.RunYear), int.Parse(labSheetA1Sheet.RunMonth), int.Parse(labSheetA1Sheet.RunDay), int.Parse(labSheetA1Sheet.IncubationBath3StartTime.Substring(0, 2)), int.Parse(labSheetA1Sheet.IncubationBath3StartTime.Substring(3, 2)), 0);
            }
            catch (Exception)
            {
                // nothing
            }

            MWQMRunModel mwqmRunModel = new MWQMRunModel();
            using (TransactionScope ts = new TransactionScope())
            {
                MWQMRunModel mwqmRunModelModify = new MWQMRunModel()
                {
                    SubsectorTVItemID = labSheetA1Sheet.SubsectorTVItemID,
                    DateTime_Local = RunDate,
                    StartDateTime_Local = StartDateTime,
                    EndDateTime_Local = EndDateTime,
                    RunSampleType = (RoutineExist ? SampleTypeEnum.Routine : sampleTypeList[0]),
                    //RunSampleType = labSheetA1Sheet.SampleType,
                    RunNumber = labSheetA1Sheet.RunNumber
                    // other field are not important
                };
                MWQMRunModel mwqmRunModelToChange = _MWQMRunService.GetMWQMRunModelExistDB(mwqmRunModelModify);
                if (!string.IsNullOrWhiteSpace(mwqmRunModelToChange.Error))
                {
                    TVItemModel tvItemModel = _TVItemService.PostAddChildTVItemDB(labSheetA1Sheet.SubsectorTVItemID,
                        RunDate.ToString("yyyy MM dd") + (labSheetA1Sheet.RunNumber > 1 ? " " + ServiceRes.Run + " (" + labSheetA1Sheet.RunNumber + ")" : "") + (labSheetA1Sheet.SampleType != SampleTypeEnum.Routine
                        ? " (" + _BaseEnumService.GetEnumText_SampleTypeEnum(labSheetA1Sheet.SampleType) + ")"
                        : ""), TVTypeEnum.MWQMRun);
                    if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                        return ReturnError(tvItemModel.Error);

                    float? TempCont1 = null;
                    if (labSheetA1Sheet.TCLab1 != null && labSheetA1Sheet.TCLab1.Length > 0)
                    {
                        TempCont1 = (LanguageRequest == LanguageEnum.fr ? float.Parse(labSheetA1Sheet.TCLab1.Replace(".", ",")) : float.Parse(labSheetA1Sheet.TCLab1));
                    }
                    float? TempCont2 = null;
                    if (labSheetA1Sheet.TCLab2 != null && labSheetA1Sheet.TCLab2.Length > 0)
                    {
                        TempCont2 = (LanguageRequest == LanguageEnum.fr ? float.Parse(labSheetA1Sheet.TCLab2.Replace(".", ",")) : float.Parse(labSheetA1Sheet.TCLab2));
                    }

                    MWQMRunModel mwqmRunModelNew = new MWQMRunModel()
                    {
                        AnalyzeMethod = analyzeMethod,
                        SubsectorTVItemID = labSheetA1Sheet.SubsectorTVItemID,
                        RunSampleType = (RoutineExist ? SampleTypeEnum.Routine : sampleTypeList[0]),
                        //RunSampleType = labSheetA1Sheet.SampleType,
                        StartDateTime_Local = StartDateTime,
                        EndDateTime_Local = EndDateTime,
                        DateTime_Local = RunDate,
                        RunNumber = labSheetA1Sheet.RunNumber,
                        RunComment = labSheetA1Sheet.RunComment,
                        RunWeatherComment = labSheetA1Sheet.RunWeatherComment,
                        SampleMatrix = sampleMatrix,
                        SampleStatus = SampleStatusEnum.Archived,
                        Laboratory = laboratory,
                        RainDay0_mm = null,
                        RainDay1_mm = null,
                        RainDay2_mm = null,
                        RainDay3_mm = null,
                        RainDay4_mm = null,
                        RainDay5_mm = null,
                        RainDay6_mm = null,
                        RainDay7_mm = null,
                        RainDay8_mm = null,
                        RainDay9_mm = null,
                        RainDay10_mm = null,
                        SampleCrewInitials = labSheetA1Sheet.SampleCrewInitials,
                        LabRunSampleApprovalDateTime_Local = ClientDateTime,
                        MWQMRunTVItemID = tvItemModel.TVItemID,
                        MWQMRunTVText = RunDate.ToString("yyyy MM dd"),
                        LabAnalyzeBath1IncubationStartDateTime_Local = LabAnalyzeBath1IncubationStartDateTime_Local,
                        LabAnalyzeBath2IncubationStartDateTime_Local = LabAnalyzeBath2IncubationStartDateTime_Local,
                        LabAnalyzeBath3IncubationStartDateTime_Local = LabAnalyzeBath3IncubationStartDateTime_Local,
                        LabReceivedDateTime_Local = RunDate,
                        TemperatureControl1_C = TempCont1,
                        TemperatureControl2_C = TempCont2,
                        LabSampleApprovalContactTVItemID = contactOK.ContactTVItemID,
                    };

                    string TideText = labSheetA1Sheet.Tides.Trim();
                    string StartTideText = TideText.Substring(0, 2);
                    string EndTideText = TideText.Substring(TideText.Length - 2);
                    switch (StartTideText)
                    {
                        case "LF":
                            {
                                mwqmRunModelNew.Tide_Start = TideTextEnum.LowTideFalling;
                            }
                            break;
                        case "LR":
                            {
                                mwqmRunModelNew.Tide_Start = TideTextEnum.LowTideRising;
                            }
                            break;
                        case "LT":
                            {
                                mwqmRunModelNew.Tide_Start = TideTextEnum.LowTide;
                            }
                            break;
                        case "MF":
                            {
                                mwqmRunModelNew.Tide_Start = TideTextEnum.MidTideFalling;
                            }
                            break;
                        case "MR":
                            {
                                mwqmRunModelNew.Tide_Start = TideTextEnum.MidTideRising;
                            }
                            break;
                        case "MT":
                            {
                                mwqmRunModelNew.Tide_Start = TideTextEnum.MidTide;
                            }
                            break;
                        case "HF":
                            {
                                mwqmRunModelNew.Tide_Start = TideTextEnum.HighTideFalling;
                            }
                            break;
                        case "HR":
                            {
                                mwqmRunModelNew.Tide_Start = TideTextEnum.HighTideRising;
                            }
                            break;
                        case "HT":
                            {
                                mwqmRunModelNew.Tide_Start = TideTextEnum.HighTide;
                            }
                            break;
                        default:
                            break;
                    }
                    switch (EndTideText)
                    {
                        case "LF":
                            {
                                mwqmRunModelNew.Tide_End = TideTextEnum.LowTideFalling;
                            }
                            break;
                        case "LR":
                            {
                                mwqmRunModelNew.Tide_End = TideTextEnum.LowTideRising;
                            }
                            break;
                        case "LT":
                            {
                                mwqmRunModelNew.Tide_End = TideTextEnum.LowTide;
                            }
                            break;
                        case "MF":
                            {
                                mwqmRunModelNew.Tide_End = TideTextEnum.MidTideFalling;
                            }
                            break;
                        case "MR":
                            {
                                mwqmRunModelNew.Tide_End = TideTextEnum.MidTideRising;
                            }
                            break;
                        case "MT":
                            {
                                mwqmRunModelNew.Tide_End = TideTextEnum.MidTide;
                            }
                            break;
                        case "HF":
                            {
                                mwqmRunModelNew.Tide_End = TideTextEnum.HighTideFalling;
                            }
                            break;
                        case "HR":
                            {
                                mwqmRunModelNew.Tide_End = TideTextEnum.HighTideRising;
                            }
                            break;
                        case "HT":
                            {
                                mwqmRunModelNew.Tide_End = TideTextEnum.HighTide;
                            }
                            break;
                        default:
                            break;
                    }

                    mwqmRunModel = _MWQMRunService.PostAddMWQMRunDB(mwqmRunModelNew);
                    if (!string.IsNullOrWhiteSpace(mwqmRunModel.Error))
                        return ReturnError(mwqmRunModel.Error);

                }
                else
                {
                    float? TempCont1 = null;
                    if (labSheetA1Sheet.TCLab1 != null && labSheetA1Sheet.TCLab1.Length > 0)
                    {
                        TempCont1 = (LanguageRequest == LanguageEnum.fr ? float.Parse(labSheetA1Sheet.TCLab1.Replace(".", ",")) : float.Parse(labSheetA1Sheet.TCLab1));
                    }
                    float? TempCont2 = null;
                    if (labSheetA1Sheet.TCLab2 != null && labSheetA1Sheet.TCLab2.Length > 0)
                    {
                        TempCont2 = (LanguageRequest == LanguageEnum.fr ? float.Parse(labSheetA1Sheet.TCLab2.Replace(".", ",")) : float.Parse(labSheetA1Sheet.TCLab2));
                    }

                    mwqmRunModelToChange.AnalyzeMethod = analyzeMethod;
                    mwqmRunModelToChange.SubsectorTVItemID = labSheetA1Sheet.SubsectorTVItemID;
                    mwqmRunModelToChange.RunSampleType = (RoutineExist ? SampleTypeEnum.Routine : sampleTypeList[0]);
                    //mwqmRunModelToChange.RunSampleType = labSheetA1Sheet.SampleType;
                    mwqmRunModelToChange.StartDateTime_Local = StartDateTime;
                    mwqmRunModelToChange.EndDateTime_Local = EndDateTime;
                    mwqmRunModelToChange.DateTime_Local = RunDate;
                    mwqmRunModelToChange.RunNumber = labSheetA1Sheet.RunNumber;
                    mwqmRunModelToChange.RunComment = labSheetA1Sheet.RunComment;
                    mwqmRunModelToChange.RunWeatherComment = labSheetA1Sheet.RunWeatherComment;
                    mwqmRunModelToChange.SampleMatrix = sampleMatrix;
                    mwqmRunModelToChange.SampleStatus = SampleStatusEnum.Archived;
                    mwqmRunModelToChange.Laboratory = laboratory;
                    mwqmRunModelToChange.RainDay0_mm = null;
                    mwqmRunModelToChange.RainDay1_mm = null;
                    mwqmRunModelToChange.RainDay2_mm = null;
                    mwqmRunModelToChange.RainDay3_mm = null;
                    mwqmRunModelToChange.RainDay4_mm = null;
                    mwqmRunModelToChange.RainDay5_mm = null;
                    mwqmRunModelToChange.RainDay6_mm = null;
                    mwqmRunModelToChange.RainDay7_mm = null;
                    mwqmRunModelToChange.RainDay8_mm = null;
                    mwqmRunModelToChange.RainDay9_mm = null;
                    mwqmRunModelToChange.RainDay10_mm = null;
                    mwqmRunModelToChange.SampleCrewInitials = labSheetA1Sheet.SampleCrewInitials;
                    mwqmRunModelToChange.LabRunSampleApprovalDateTime_Local = ClientDateTime;
                    mwqmRunModelToChange.MWQMRunTVText = RunDate.ToString("yyyy MM dd");
                    mwqmRunModelToChange.LabAnalyzeBath1IncubationStartDateTime_Local = LabAnalyzeBath1IncubationStartDateTime_Local;
                    mwqmRunModelToChange.LabAnalyzeBath2IncubationStartDateTime_Local = LabAnalyzeBath2IncubationStartDateTime_Local;
                    mwqmRunModelToChange.LabAnalyzeBath3IncubationStartDateTime_Local = LabAnalyzeBath3IncubationStartDateTime_Local;
                    mwqmRunModelToChange.LabReceivedDateTime_Local = RunDate;
                    mwqmRunModelToChange.TemperatureControl1_C = TempCont1;
                    mwqmRunModelToChange.TemperatureControl2_C = TempCont2;
                    mwqmRunModelToChange.LabSampleApprovalContactTVItemID = contactOK.ContactTVItemID;

                    string TideText = labSheetA1Sheet.Tides.Trim();
                    string StartTideText = TideText.Substring(0, 2);
                    string EndTideText = TideText.Substring(TideText.Length - 2);
                    switch (StartTideText)
                    {
                        case "LF":
                            {
                                mwqmRunModelToChange.Tide_Start = TideTextEnum.LowTideFalling;
                            }
                            break;
                        case "LR":
                            {
                                mwqmRunModelToChange.Tide_Start = TideTextEnum.LowTideRising;
                            }
                            break;
                        case "LT":
                            {
                                mwqmRunModelToChange.Tide_Start = TideTextEnum.LowTide;
                            }
                            break;
                        case "MF":
                            {
                                mwqmRunModelToChange.Tide_Start = TideTextEnum.MidTideFalling;
                            }
                            break;
                        case "MR":
                            {
                                mwqmRunModelToChange.Tide_Start = TideTextEnum.MidTideRising;
                            }
                            break;
                        case "MT":
                            {
                                mwqmRunModelToChange.Tide_Start = TideTextEnum.MidTide;
                            }
                            break;
                        case "HF":
                            {
                                mwqmRunModelToChange.Tide_Start = TideTextEnum.HighTideFalling;
                            }
                            break;
                        case "HR":
                            {
                                mwqmRunModelToChange.Tide_Start = TideTextEnum.HighTideRising;
                            }
                            break;
                        case "HT":
                            {
                                mwqmRunModelToChange.Tide_Start = TideTextEnum.HighTide;
                            }
                            break;
                        default:
                            break;
                    }
                    switch (EndTideText)
                    {
                        case "LF":
                            {
                                mwqmRunModelToChange.Tide_End = TideTextEnum.LowTideFalling;
                            }
                            break;
                        case "LR":
                            {
                                mwqmRunModelToChange.Tide_End = TideTextEnum.LowTideRising;
                            }
                            break;
                        case "LT":
                            {
                                mwqmRunModelToChange.Tide_End = TideTextEnum.LowTide;
                            }
                            break;
                        case "MF":
                            {
                                mwqmRunModelToChange.Tide_End = TideTextEnum.MidTideFalling;
                            }
                            break;
                        case "MR":
                            {
                                mwqmRunModelToChange.Tide_End = TideTextEnum.MidTideRising;
                            }
                            break;
                        case "MT":
                            {
                                mwqmRunModelToChange.Tide_End = TideTextEnum.MidTide;
                            }
                            break;
                        case "HF":
                            {
                                mwqmRunModelToChange.Tide_End = TideTextEnum.HighTideFalling;
                            }
                            break;
                        case "HR":
                            {
                                mwqmRunModelToChange.Tide_End = TideTextEnum.HighTideRising;
                            }
                            break;
                        case "HT":
                            {
                                mwqmRunModelToChange.Tide_End = TideTextEnum.HighTide;
                            }
                            break;
                        default:
                            break;
                    }
                    mwqmRunModel = _MWQMRunService.PostUpdateMWQMRunDB(mwqmRunModelToChange);
                    if (!string.IsNullOrWhiteSpace(mwqmRunModel.Error))
                        return ReturnError(mwqmRunModel.Error);

                }

                List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(labSheetA1Sheet.SubsectorTVItemID, TVTypeEnum.MWQMSite);

                foreach (LabSheetA1Measurement labSheetA1Measurement in labSheetA1Sheet.LabSheetA1MeasurementList)
                {
                    if (labSheetA1Measurement.MPN == -999)
                        continue;

                    if (labSheetA1Measurement.TVItemID == 0)
                        continue;

                    if (labSheetA1Measurement.Time == null)
                        continue;

                    if (labSheetA1Measurement.MPN == null)
                        continue;

                    if (labSheetA1Measurement.Time == null)
                        continue;

                    if (labSheetA1Measurement.SampleType == null)
                        continue;

                    MWQMSiteModel mwqmSiteModel = _MWQMSiteService.GetMWQMSiteModelWithMWQMSiteTVItemIDDB(labSheetA1Measurement.TVItemID);
                    if (!string.IsNullOrWhiteSpace(mwqmSiteModel.Error))
                        return ReturnError(mwqmSiteModel.Error);


                    MWQMSampleModel mwqmSampleModelNew = new MWQMSampleModel();
                    mwqmSampleModelNew.FecCol_MPN_100ml = (int)labSheetA1Measurement.MPN;
                    mwqmSampleModelNew.SampleDateTime_Local = (DateTime)labSheetA1Measurement.Time;
                    mwqmSampleModelNew.MWQMSampleNote = labSheetA1Measurement.SiteComment;
                    mwqmSampleModelNew.Tube_10 = null;
                    if (labSheetA1Measurement.Tube10 >= 0)
                    {
                        mwqmSampleModelNew.Tube_10 = (int)labSheetA1Measurement.Tube10;
                    }
                    mwqmSampleModelNew.Tube_1_0 = null;
                    if (labSheetA1Measurement.Tube1_0 >= 0)
                    {
                        mwqmSampleModelNew.Tube_1_0 = labSheetA1Measurement.Tube1_0;
                    }
                    mwqmSampleModelNew.Tube_0_1 = null;
                    if (labSheetA1Measurement.Tube0_1 >= 0)
                    {
                        mwqmSampleModelNew.Tube_0_1 = labSheetA1Measurement.Tube0_1;
                    }
                    mwqmSampleModelNew.ProcessedBy = labSheetA1Measurement.ProcessedBy;
                    if ((SampleTypeEnum)labSheetA1Measurement.SampleType == SampleTypeEnum.DailyDuplicate
                        || (SampleTypeEnum)labSheetA1Measurement.SampleType == SampleTypeEnum.IntertechDuplicate
                        || (SampleTypeEnum)labSheetA1Measurement.SampleType == SampleTypeEnum.IntertechRead)
                    {
                        mwqmSampleModelNew.SampleTypesText = ((int)(SampleTypeEnum)labSheetA1Measurement.SampleType).ToString() + ",";
                    }
                    else
                    {
                        mwqmSampleModelNew.SampleTypesText = ChangeRunSamplingType;
                    }
                    mwqmSampleModelNew.Salinity_PPT = labSheetA1Measurement.Salinity;
                    mwqmSampleModelNew.WaterTemp_C = labSheetA1Measurement.Temperature;
                    mwqmSampleModelNew.MWQMRunTVItemID = mwqmRunModel.MWQMRunTVItemID;
                    mwqmSampleModelNew.MWQMSiteTVItemID = labSheetA1Measurement.TVItemID;

                    List<MWQMSampleModel> mwqmSampleModelList = _MWQMSampleService.GetMWQMSampleModelListWithMWQMSiteTVItemIDAndSampleTypeTextAndSampleDateTimeDB(mwqmSampleModelNew.MWQMSiteTVItemID, (SampleTypeEnum)labSheetA1Measurement.SampleType, mwqmSampleModelNew.SampleDateTime_Local);
                    if (mwqmSampleModelList.Count == 0)
                    {
                        MWQMSampleModel mwqmSampleModelRet = _MWQMSampleService.PostAddMWQMSampleDB(mwqmSampleModelNew);
                        if (!string.IsNullOrWhiteSpace(mwqmSampleModelRet.Error))
                            return ReturnError(mwqmSampleModelRet.Error);
                    }
                    else
                    {
                        if (mwqmSampleModelList.Count != 1)
                            return ReturnError(string.Format(ServiceRes.ShouldOnlyHaveOne_, ServiceRes.MWQMSample));

                        mwqmSampleModelNew.MWQMSampleID = mwqmSampleModelList[0].MWQMSampleID;
                        mwqmSampleModelNew.MWQMSiteTVItemID = labSheetA1Measurement.TVItemID;
                        MWQMSampleModel mwqmSampleModelRet = _MWQMSampleService.PostUpdateMWQMSampleDB(mwqmSampleModelNew);
                        if (!string.IsNullOrWhiteSpace(mwqmSampleModelRet.Error))
                            return ReturnError(mwqmSampleModelRet.Error);
                    }
                }

                labSheetModel.LabSheetStatus = LabSheetStatusEnum.Accepted;
                labSheetModel.AcceptedOrRejectedDateTime = DateTime.Now;
                labSheetModel.AcceptedOrRejectedByContactTVItemID = contactOK.ContactTVItemID;
                labSheetModel.MWQMRunTVItemID = mwqmRunModel.MWQMRunTVItemID;

                labSheetModel = PostUpdateLabSheetDB(labSheetModel);
                if (!string.IsNullOrWhiteSpace(labSheetModel.Error))
                    return ReturnError(labSheetModel.Error);

                if (labSheetA1Sheet.IncludeLaboratoryQAQC)
                {
                    string retStr = FCFormGenerateDB(labSheetModel.LabSheetID);
                    if (!string.IsNullOrWhiteSpace(retStr))
                        return ReturnError(retStr);
                }

                // doing Duplicate
                List<MWQMSampleModel> mwqmSampleModelList2 = _MWQMSampleService.GetMWQMSampleModelListWithMWQMRunTVItemIDDB(mwqmRunModel.MWQMRunTVItemID);
                MWQMSampleModel mwqmSampleModelDup = new MWQMSampleModel();
                MWQMSampleModel mwqmSampleModelToChange = new MWQMSampleModel();

                bool DoSwitch = false;
                bool HasDup = false;

                foreach (MWQMSampleModel mwqmSampleModel in mwqmSampleModelList2)
                {
                    if (mwqmSampleModel.SampleTypeList.Contains(SampleTypeEnum.DailyDuplicate))
                    {
                        mwqmSampleModelDup = mwqmSampleModel;
                        HasDup = true;
                        break;
                    }
                }
                if (HasDup)
                {
                    foreach (MWQMSampleModel mwqmSampleModel in mwqmSampleModelList2)
                    {
                        if (!(mwqmSampleModel.SampleTypeList.Contains(SampleTypeEnum.DailyDuplicate)
                            || mwqmSampleModel.SampleTypeList.Contains(SampleTypeEnum.IntertechDuplicate)
                            || mwqmSampleModel.SampleTypeList.Contains(SampleTypeEnum.IntertechRead)))
                        {
                            if (mwqmSampleModel.MWQMSiteTVItemID == mwqmSampleModelDup.MWQMSiteTVItemID)
                            {
                                if (mwqmSampleModelDup.FecCol_MPN_100ml > mwqmSampleModel.FecCol_MPN_100ml)
                                {
                                    mwqmSampleModelToChange = mwqmSampleModel;
                                    int temp = mwqmSampleModelDup.FecCol_MPN_100ml;
                                    mwqmSampleModelDup.FecCol_MPN_100ml = mwqmSampleModel.FecCol_MPN_100ml;
                                    mwqmSampleModel.FecCol_MPN_100ml = temp;
                                    DoSwitch = true;
                                    break;
                                }
                            }
                        }
                    }

                    MWQMSampleModel mwqmSampleModelRet3 = _MWQMSampleService.PostUpdateMWQMSampleDB(mwqmSampleModelDup);
                    if (!string.IsNullOrWhiteSpace(mwqmSampleModelRet3.Error))
                        return ReturnError(mwqmSampleModelRet3.Error);

                    if (DoSwitch)
                    {
                        MWQMSampleModel mwqmSampleModelRet4 = _MWQMSampleService.PostUpdateMWQMSampleDB(mwqmSampleModelToChange);
                        if (!string.IsNullOrWhiteSpace(mwqmSampleModelRet4.Error))
                            return ReturnError(mwqmSampleModelRet4.Error);
                    }
                }


                // doing Intertech duplicate
                mwqmSampleModelList2 = _MWQMSampleService.GetMWQMSampleModelListWithMWQMRunTVItemIDDB(mwqmRunModel.MWQMRunTVItemID);
                MWQMSampleModel mwqmSampleModelIntertechDup = new MWQMSampleModel();
                mwqmSampleModelToChange = new MWQMSampleModel();

                DoSwitch = false;
                bool HasIntertechDup = false;

                foreach (MWQMSampleModel mwqmSampleModel in mwqmSampleModelList2)
                {
                    if (mwqmSampleModel.SampleTypeList.Contains(SampleTypeEnum.IntertechDuplicate))
                    {
                        mwqmSampleModelIntertechDup = mwqmSampleModel;
                        HasIntertechDup = true;
                        break;
                    }
                }
                if (HasIntertechDup)
                {
                    foreach (MWQMSampleModel mwqmSampleModel in mwqmSampleModelList2)
                    {
                        if (!(mwqmSampleModel.SampleTypeList.Contains(SampleTypeEnum.DailyDuplicate)
                           || mwqmSampleModel.SampleTypeList.Contains(SampleTypeEnum.IntertechDuplicate)
                           || mwqmSampleModel.SampleTypeList.Contains(SampleTypeEnum.IntertechRead)))
                        {
                            if (mwqmSampleModel.MWQMSiteTVItemID == mwqmSampleModelIntertechDup.MWQMSiteTVItemID)
                            {
                                if (mwqmSampleModelIntertechDup.FecCol_MPN_100ml > mwqmSampleModel.FecCol_MPN_100ml)
                                {
                                    mwqmSampleModelToChange = mwqmSampleModel;
                                    int temp = mwqmSampleModelIntertechDup.FecCol_MPN_100ml;
                                    mwqmSampleModelIntertechDup.FecCol_MPN_100ml = mwqmSampleModel.FecCol_MPN_100ml;
                                    mwqmSampleModel.FecCol_MPN_100ml = temp;
                                    DoSwitch = true;
                                    break;
                                }
                            }
                        }
                    }

                    MWQMSampleModel mwqmSampleModelRet3 = _MWQMSampleService.PostUpdateMWQMSampleDB(mwqmSampleModelIntertechDup);
                    if (!string.IsNullOrWhiteSpace(mwqmSampleModelRet3.Error))
                        return ReturnError(mwqmSampleModelRet3.Error);

                    if (DoSwitch)
                    {
                        MWQMSampleModel mwqmSampleModelRet4 = _MWQMSampleService.PostUpdateMWQMSampleDB(mwqmSampleModelToChange);
                        if (!string.IsNullOrWhiteSpace(mwqmSampleModelRet4.Error))
                            return ReturnError(mwqmSampleModelRet4.Error);
                    }
                }


                ts.Complete();
            }

            string retStr2 = UpdateOtherServerWithOtherServerLabSheetIDWithLabSheetStatus(labSheetModel.OtherServerLabSheetID, LabSheetStatusEnum.Accepted);
            if (!string.IsNullOrWhiteSpace(retStr2))
                return ReturnError(retStr2);

            ContactModel contactModelContact = _ContactService.GetContactModelWithContactTVItemIDDB(contactOK.ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(contactModelContact.Error))
                return ReturnError(contactModelContact.Error);

            string retStr3 = UpdateOtherServerWithOtherServerLabSheetIDWithAcceptedOrRejectedBy(labSheetModel.OtherServerLabSheetID,
                (contactModelContact.FirstName.Length > 0 ? contactModelContact.FirstName.Substring(0, 1) + "." : contactModelContact.FirstName) + " " +
                (contactModelContact.LastName.Length > 0 ? contactModelContact.LastName.Substring(0, 1) + "." : contactModelContact.LastName), labSheetModel.RejectReason);
            if (!string.IsNullOrWhiteSpace(retStr3))
                return ReturnError(retStr3);

            if (!labSheetA1Sheet.IncludeLaboratoryQAQC)
            {
                string retStr4 = SendLabSheetAcceptedEmail(labSheetModel.LabSheetID);
                if (!string.IsNullOrWhiteSpace(retStr4))
                    return ReturnError(retStr4);
            }

            return labSheetModel;
        }
        public string SendLabSheetAcceptedEmail(int LabSheetID)
        {
            LabSheetModel labSheetModel = GetLabSheetModelWithLabSheetIDDB(LabSheetID);
            if (!string.IsNullOrWhiteSpace(labSheetModel.Error))
            {
                return labSheetModel.Error;
            }

            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(labSheetModel.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
            {
                return tvItemModelSubsector.Error;
            }

            List<TVItemModel> tvItemModelParents = _TVItemService.GetParentsTVItemModelList(tvItemModelSubsector.TVPath);

            TVItemModel tvItemModelProvince = tvItemModelParents.Where(c => c.TVType == TVTypeEnum.Province).FirstOrDefault();
            if (tvItemModelProvince == null)
            {
                return string.Format(ServiceRes.CouldNotFind_, ServiceRes.Province);
            }

            string hrefSubsector = "http://wmon01dtchlebl2/csspwebtools/en-CA/#!View/" + (tvItemModelProvince.TVText + "-" + tvItemModelSubsector.TVText).Replace(" ", "-") + "|||" + tvItemModelSubsector.TVItemID.ToString() + "|||30010000001000000000000000001000";

            foreach (bool IsContractor in new List<bool> { false, true })
            {
                List<string> ToEmailList = new List<string>();

                SamplingPlanModel samplingPlanModel = _SamplingPlanService.GetSamplingPlanModelWithSamplingPlanIDDB(labSheetModel.SamplingPlanID);

                if (!samplingPlanModel.IsActive)
                {
                    continue;
                }

                List<SamplingPlanEmailModel> SamplingPlanEmailModelList = _SamplingPlanEmailService.GetSamplingPlanEmailModelListWithSamplingPlanIDDB(samplingPlanModel.SamplingPlanID);

                foreach (SamplingPlanEmailModel samplingPlanEmailModel in SamplingPlanEmailModelList.Where(c => c.IsContractor == IsContractor && c.LabSheetAccepted == true))
                {
                    ToEmailList.Add(samplingPlanEmailModel.Email);
                }

                MailMessage mail = new MailMessage();

                foreach (string email in ToEmailList)
                {
                    mail.To.Add(email.ToLower());
                }

                if (mail.To.Count == 0)
                {
                    continue;
                }

                mail.From = new MailAddress("ec.pccsm-cssp.ec@canada.ca");
                mail.IsBodyHtml = true;

                SmtpClient myClient = new System.Net.Mail.SmtpClient();

                myClient.Host = "smtp.email-courriel.canada.ca";
                myClient.Port = 587;
                myClient.Credentials = new System.Net.NetworkCredential("ec.pccsm-cssp.ec@canada.ca", "H^9h6g@Gy$N57k=Dr@J7=F2y6p6b!T");
                myClient.EnableSsl = true;

                DateTime RunDate = new DateTime(labSheetModel.Year, labSheetModel.Month, labSheetModel.Day);

                int FirstSpace = tvItemModelSubsector.TVText.IndexOf(" ");

                string subject = tvItemModelSubsector.TVText.Substring(0, (FirstSpace > 0 ? FirstSpace : tvItemModelSubsector.TVText.Length))
                    + " – Lab sheet accepted / Feuille de laboratoire accepté";

                StringBuilder msg = new StringBuilder();

                // ----------------------- English part -------------

                msg.AppendLine(@"<p>(français suit)</p>");
                msg.AppendLine(@"<h2>Lab Sheet Accepted</h2>");

                if (!IsContractor)
                {
                    msg.AppendLine(@"<h4>Subsector: <a href=""" + hrefSubsector + @""">" + tvItemModelSubsector.TVText + "</a></h4>");
                }
                else
                {
                    msg.AppendLine(@"<h4>Subsector: " + tvItemModelSubsector.TVText + "</h4>");
                }

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");

                msg.AppendLine(@"<p><b>Date of run:</b> " + RunDate.ToString("MMMM dd, yyyy") + "</p>");
                msg.AppendLine(@"<p><b>Accepted by:</b> " + labSheetModel.AcceptedOrRejectedByContactTVText + "</p>");
                msg.AppendLine(@"<p></p>");
                msg.AppendLine(@"Auto email from CSSPWebTools");
                msg.AppendLine(@"<br>");
                msg.AppendLine(@"<hr />");

                // ---------------------- French part --------------

                msg.AppendLine(@"<hr />");
                msg.AppendLine(@"<br>");
                msg.AppendLine(@"<h2>Feuille de laboratoire accepté</h2>");

                if (!IsContractor)
                {
                    msg.AppendLine(@"<h4>Sous-secteur: <a href=""" + hrefSubsector.Replace("en-CA", "fr-CA") + @""">" + tvItemModelSubsector.TVText + "</a></h4>");
                }
                else
                {
                    msg.AppendLine(@"<h4>Sous-secteur: " + tvItemModelSubsector.TVText + "</h4>");
                }

                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");

                msg.AppendLine(@"<p><b>Date de la tournée:</b> " + RunDate.ToString("dd MMMM, yyyy") + "</p>");

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");

                msg.AppendLine(@"<p><b>Accepté par:</b> " + labSheetModel.AcceptedOrRejectedByContactTVText + "</p>");
                msg.AppendLine(@"<p></p>");
                msg.AppendLine(@"Courriel automatique provenant de CSSPWebTools");

                mail.Subject = subject;
                mail.Body = msg.ToString();
                myClient.Send(mail);
            }

            return "";
        }

        public LabSheetModel LabSheetRejectedDB(int LabSheetID, string RejectReason)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            LabSheetModel labSheetModel = GetLabSheetModelWithLabSheetIDDB(LabSheetID);
            if (!string.IsNullOrWhiteSpace(labSheetModel.Error))
                return ReturnError(labSheetModel.Error);

            labSheetModel.LabSheetStatus = LabSheetStatusEnum.Rejected;
            labSheetModel.AcceptedOrRejectedByContactTVItemID = GetContactLoggedInDB().ContactTVItemID;
            labSheetModel.AcceptedOrRejectedDateTime = DateTime.Now;
            labSheetModel.RejectReason = RejectReason;

            labSheetModel = PostUpdateLabSheetDB(labSheetModel);
            if (!string.IsNullOrWhiteSpace(labSheetModel.Error))
                return ReturnError(labSheetModel.Error);

            labSheetModel = SendLabSheetRejectedEmail(labSheetModel.LabSheetID);
            if (!string.IsNullOrWhiteSpace(labSheetModel.Error))
                return ReturnError(labSheetModel.Error);

            string retStr = UpdateOtherServerWithOtherServerLabSheetIDWithLabSheetStatus(labSheetModel.OtherServerLabSheetID, LabSheetStatusEnum.Rejected);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);


            ContactModel contactModelContact = _ContactService.GetContactModelWithContactTVItemIDDB(contactOK.ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(contactModelContact.Error))
                return ReturnError(contactModelContact.Error);

            string retStr3 = UpdateOtherServerWithOtherServerLabSheetIDWithAcceptedOrRejectedBy(labSheetModel.OtherServerLabSheetID,
                (contactModelContact.FirstName.Length > 3 ? contactModelContact.FirstName.Substring(0, 3) + "." : contactModelContact.FirstName) + " " +
                (contactModelContact.LastName.Length > 3 ? contactModelContact.LastName.Substring(0, 3) + "." : contactModelContact.LastName), labSheetModel.RejectReason);
            if (!string.IsNullOrWhiteSpace(retStr3))
                return ReturnError(retStr3);

            return labSheetModel;
        }
        public LabSheetModel PostAddLabSheetDB(LabSheetModel labSheetModel)
        {
            string retStr = LabSheetModelOK(labSheetModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            LabSheetModel labSheetModelExist = GetLabSheetModelExistDB(labSheetModel);
            if (string.IsNullOrWhiteSpace(labSheetModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.LabSheet));

            LabSheet labSheetNew = new LabSheet();
            retStr = FillLabSheet(labSheetNew, labSheetModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.LabSheets.Add(labSheetNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("LabSheets", labSheetNew.LabSheetID, LogCommandEnum.Add, labSheetNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetLabSheetModelWithLabSheetIDDB(labSheetNew.LabSheetID);
        }
        public LabSheetModel PostDeleteLabSheetDB(int LabSheetID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            LabSheet labSheetToDelete = GetLabSheetWithLabSheetIDDB(LabSheetID);
            if (labSheetToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.LabSheet));

            using (TransactionScope ts = new TransactionScope())
            {
                db.LabSheets.Remove(labSheetToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("LabSheets", labSheetToDelete.LabSheetID, LogCommandEnum.Delete, labSheetToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public LabSheetModel PostUpdateLabSheetDB(LabSheetModel labSheetModel)
        {
            string retStr = LabSheetModelOK(labSheetModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            LabSheet labSheetToUpdate = GetLabSheetWithLabSheetIDDB(labSheetModel.LabSheetID);
            if (labSheetToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.LabSheet));

            retStr = FillLabSheet(labSheetToUpdate, labSheetModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("LabSheets", labSheetToUpdate.LabSheetID, LogCommandEnum.Change, labSheetToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetLabSheetModelWithLabSheetIDDB(labSheetToUpdate.LabSheetID);
        }
        public LabSheetA1Sheet ParseLabSheetA1WithLabSheetID(int LabSheetID)
        {
            StringBuilder sbPrevCommands = new StringBuilder();
            LabSheetA1Sheet labSheetA1Sheet = new LabSheetA1Sheet() { Error = "" };

            LabSheetModel labSheetModel = GetLabSheetModelWithLabSheetIDDB(LabSheetID);
            if (!string.IsNullOrWhiteSpace(labSheetModel.Error))
            {
                labSheetA1Sheet.Error = labSheetModel.Error;
                return labSheetA1Sheet;
            }

            return _CSSPLabSheetParser.ParseLabSheetA1(labSheetModel.FileContent);
        }
        public LabSheetModel SendLabSheetRejectedEmail(int LabSheetID)
        {
            LabSheetModel labSheetModel = GetLabSheetModelWithLabSheetIDDB(LabSheetID);
            if (!string.IsNullOrWhiteSpace(labSheetModel.Error))
                return ReturnError(labSheetModel.Error);

            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(labSheetModel.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return ReturnError(tvItemModelSubsector.Error);

            List<TVItemModel> tvItemModelParents = _TVItemService.GetParentsTVItemModelList(tvItemModelSubsector.TVPath);

            TVItemModel tvItemModelProvince = tvItemModelParents.Where(c => c.TVType == TVTypeEnum.Province).FirstOrDefault();
            if (tvItemModelProvince == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.Province));

            string hrefSubsector = "http://wmon01dtchlebl2/csspwebtools/en-CA/#!View/" + (tvItemModelProvince.TVText + "-" + tvItemModelSubsector.TVText).Replace(" ", "-") + "|||" + tvItemModelSubsector.TVItemID.ToString() + "|||30010000001000000000000000001000";

            foreach (bool IsContractor in new List<bool> { false, true })
            {
                List<string> ToEmailList = new List<string>();

                SamplingPlanModel samplingPlanModel = _SamplingPlanService.GetSamplingPlanModelWithSamplingPlanIDDB(labSheetModel.SamplingPlanID);

                if (!samplingPlanModel.IsActive)
                {
                    continue;
                }

                List<SamplingPlanEmailModel> SamplingPlanEmailModelList = _SamplingPlanEmailService.GetSamplingPlanEmailModelListWithSamplingPlanIDDB(samplingPlanModel.SamplingPlanID);

                foreach (SamplingPlanEmailModel samplingPlanEmailModel in SamplingPlanEmailModelList.Where(c => c.IsContractor == IsContractor && c.LabSheetRejected == true))
                {
                    ToEmailList.Add(samplingPlanEmailModel.Email);
                }

                MailMessage mail = new MailMessage();

                //mail.To.Add("Test1.User@ssctest.itsso.gc.ca");

                foreach (string email in ToEmailList)
                {
                    mail.To.Add(email.ToLower());
                }

                if (mail.To.Count == 0)
                {
                    continue;
                }

                mail.From = new MailAddress("ec.pccsm-cssp.ec@canada.ca");
                mail.IsBodyHtml = true;

                SmtpClient myClient = new System.Net.Mail.SmtpClient();

                myClient.Host = "smtp.email-courriel.canada.ca";
                myClient.Port = 587;
                myClient.Credentials = new System.Net.NetworkCredential("ec.pccsm-cssp.ec@canada.ca", "H^9h6g@Gy$N57k=Dr@J7=F2y6p6b!T");
                myClient.EnableSsl = true;

                DateTime RunDate = new DateTime(labSheetModel.Year, labSheetModel.Month, labSheetModel.Day);

                int FirstSpace = tvItemModelSubsector.TVText.IndexOf(" ");

                string subject = tvItemModelSubsector.TVText.Substring(0, (FirstSpace > 0 ? FirstSpace : tvItemModelSubsector.TVText.Length))
                    + " – Lab sheet rejected / Feuille de laboratoire rejeté";

                StringBuilder msg = new StringBuilder();

                // ----------------------- English part -------------

                msg.AppendLine(@"<p>(français suit)</p>");
                msg.AppendLine(@"<h2>Lab Sheet Rejected</h2>");

                if (!IsContractor)
                {
                    msg.AppendLine(@"<h4>Subsector: <a href=""" + hrefSubsector + @""">" + tvItemModelSubsector.TVText + "</a></h4>");
                }
                else
                {
                    msg.AppendLine(@"<h4>Subsector: " + tvItemModelSubsector.TVText + "</h4>");
                }

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");

                msg.AppendLine(@"<p><b>Date of run:</b> " + RunDate.ToString("MMMM dd, yyyy") + "</p>");
                msg.AppendLine(@"<p><b>Rejected by:</b> " + labSheetModel.AcceptedOrRejectedByContactTVText + "</p>");
                msg.AppendLine(@"<p><b>Reason:</b> " + labSheetModel.RejectReason + "</p>");
                msg.AppendLine(@"<p></p>");
                msg.AppendLine(@"Auto email from CSSPWebTools");
                msg.AppendLine(@"<br>");
                msg.AppendLine(@"<hr />");

                // ---------------------- French part --------------

                msg.AppendLine(@"<hr />");
                msg.AppendLine(@"<br>");
                msg.AppendLine(@"<h2>Feuille de laboratoire rejeté</h2>");

                if (!IsContractor)
                {
                    msg.AppendLine(@"<h4>Sous-secteur: <a href=""" + hrefSubsector.Replace("en-CA", "fr-CA") + @""">" + tvItemModelSubsector.TVText + "</a></h4>");
                }
                else
                {
                    msg.AppendLine(@"<h4>Sous-secteur: " + tvItemModelSubsector.TVText + "</h4>");
                }

                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");

                msg.AppendLine(@"<p><b>Date de la tournée:</b> " + RunDate.ToString("dd MMMM, yyyy") + "</p>");

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");

                msg.AppendLine(@"<p><b>Rejeté par:</b> " + labSheetModel.AcceptedOrRejectedByContactTVText + "</p>");
                msg.AppendLine(@"<p><b>Raison:</b> " + labSheetModel.RejectReason + "</p>");
                msg.AppendLine(@"<p></p>");
                msg.AppendLine(@"Courriel automatique provenant de CSSPWebTools");

                mail.Subject = subject;
                mail.Body = msg.ToString();
                myClient.Send(mail);
            }


            return labSheetModel;
        }
        public string UpdateOtherServerWithOtherServerLabSheetIDWithLabSheetStatus(int OtherServerLabSheetID, LabSheetStatusEnum LabSheetStatus)
        {
            string retStr = "";

            NameValueCollection paramList = new NameValueCollection();
            paramList.Add("OtherServerLabSheetID", OtherServerLabSheetID.ToString());
            paramList.Add("LabSheetStatus", ((int)LabSheetStatus).ToString());

            using (WebClient webClient = new WebClient())
            {
                WebProxy webProxy = new WebProxy();
                webClient.Proxy = webProxy;

                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] ret = webClient.UploadValues(new Uri("http://cssplabsheet.azurewebsites.net/UpdateLabSheetStatus.aspx"), "POST", paramList);

                retStr = System.Text.Encoding.Default.GetString(ret);
            }

            return retStr;
        }
        public string UpdateOtherServerWithOtherServerLabSheetIDWithAcceptedOrRejectedBy(int OtherServerLabSheetID, string ApprovedOrRejectedBy, string RejectReason)
        {
            string retStr = "";

            NameValueCollection paramList = new NameValueCollection();
            paramList.Add("OtherServerLabSheetID", OtherServerLabSheetID.ToString());
            paramList.Add("AcceptedOrRejectedBy", ApprovedOrRejectedBy);
            if (string.IsNullOrWhiteSpace(RejectReason))
            {
                RejectReason = "-";
            }
            paramList.Add("RejectReason", RejectReason);

            using (WebClient webClient = new WebClient())
            {
                WebProxy webProxy = new WebProxy();
                webClient.Proxy = webProxy;

                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] ret = webClient.UploadValues(new Uri("http://cssplabsheet.azurewebsites.net/UpdateLabSheetAcceptedOrRejectedBy.aspx"), "POST", paramList);
                //byte[] ret = webClient.UploadValues(new Uri("http://localhost:7668/UpdateLabSheetAcceptedOrRejectedBy.aspx"), "POST", paramList);

                retStr = System.Text.Encoding.Default.GetString(ret);
            }

            return retStr;
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
