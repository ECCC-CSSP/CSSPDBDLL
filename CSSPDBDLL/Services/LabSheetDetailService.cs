using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using System.Collections.Generic;
using System;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using System.IO;
using System.Web.Mvc;
using System.Net.Mail;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class LabSheetDetailService : BaseService
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
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public LabSheetDetailService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _MWQMRunService = new MWQMRunService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _MWQMSiteService = new MWQMSiteService(LanguageRequest, User);
            _MWQMSampleService = new MWQMSampleService(LanguageRequest, User);
            _TVFileService = new TVFileService(LanguageRequest, User);
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _ContactService = new ContactService(LanguageRequest, User);
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
        public string LabSheetDetailModelOK(LabSheetDetailModel labSheetDetailModel)
        {
            string retStr = FieldCheckNotZeroInt(labSheetDetailModel.LabSheetID, ServiceRes.LabSheetID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(labSheetDetailModel.SamplingPlanID, ServiceRes.SamplingPlanID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(labSheetDetailModel.SubsectorTVItemID, ServiceRes.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(labSheetDetailModel.Version, ServiceRes.Version);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(labSheetDetailModel.RunDate, ServiceRes.RunDate);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(labSheetDetailModel.Tides, ServiceRes.Tides, 7, 7);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (labSheetDetailModel.IncludeLaboratoryQAQC)
            {
                retStr = FieldCheckNotEmptyAndMaxLengthString(labSheetDetailModel.SampleCrewInitials, ServiceRes.SampleCrewInitials, 20);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotZeroInt(labSheetDetailModel.WaterBathCount, ServiceRes.WaterBathCount);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotNullDateTime(labSheetDetailModel.IncubationBath1StartTime, ServiceRes.IncubationBath1StartTime);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotNullDateTime(labSheetDetailModel.IncubationBath1EndTime, ServiceRes.IncubationBath1EndTime);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotNullAndWithinRangeInt(labSheetDetailModel.IncubationBath1TimeCalculated_minutes, ServiceRes.IncubationBath1TimeCalculated_minutes, -10000, 10000);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotEmptyAndMaxLengthString(labSheetDetailModel.WaterBath1, ServiceRes.WaterBath1, 10);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetDetailModel.TCField1, ServiceRes.TCField1, 0, 40);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetDetailModel.TCLab1, ServiceRes.TCLab1, 0, 40);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetDetailModel.TCField2, ServiceRes.TCField2, 0, 40);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetDetailModel.TCLab2, ServiceRes.TCLab2, 0, 40);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetDetailModel.TCFirst, ServiceRes.TCFirst, 0, 40);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetDetailModel.TCAverage, ServiceRes.TCAverage, 0, 40);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotEmptyAndMaxLengthString(labSheetDetailModel.ControlLot, ServiceRes.ControlLot, 100);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotEmptyAndMaxLengthString(labSheetDetailModel.Positive35, ServiceRes.Positive35, 1);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                if (!"+-".Contains(labSheetDetailModel.Positive35))
                {
                    return string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.Positive35);
                }

                retStr = FieldCheckNotEmptyAndMaxLengthString(labSheetDetailModel.NonTarget35, ServiceRes.NonTarget35, 1);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                if (!"+-N".Contains(labSheetDetailModel.NonTarget35))
                {
                    return string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.NonTarget35);
                }

                retStr = FieldCheckNotEmptyAndMaxLengthString(labSheetDetailModel.Negative35, ServiceRes.Negative35, 1);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                if (!"+-".Contains(labSheetDetailModel.Negative35))
                {
                    return string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.Negative35);
                }

                retStr = FieldCheckNotEmptyAndMaxLengthString(labSheetDetailModel.Bath1Positive44_5, ServiceRes.Bath1Positive44_5, 1);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                if (!"+-".Contains(labSheetDetailModel.Bath1Positive44_5))
                {
                    return string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.Bath1Positive44_5);
                }

                retStr = FieldCheckNotEmptyAndMaxLengthString(labSheetDetailModel.Bath1NonTarget44_5, ServiceRes.Bath1NonTarget44_5, 1);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                if (!"+-N".Contains(labSheetDetailModel.Bath1NonTarget44_5))
                {
                    return string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.Bath1NonTarget44_5);
                }

                retStr = FieldCheckNotEmptyAndMaxLengthString(labSheetDetailModel.Bath1Negative44_5, ServiceRes.Bath1Negative44_5, 1);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                if (!"+-".Contains(labSheetDetailModel.Bath1Negative44_5))
                {
                    return string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.Bath1Negative44_5);
                }

                retStr = FieldCheckNotEmptyAndMaxLengthString(labSheetDetailModel.Blank35, ServiceRes.Blank35, 1);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                if (!"+-".Contains(labSheetDetailModel.Blank35))
                {
                    return string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.Blank35);
                }

                if (!"+-".Contains(labSheetDetailModel.Bath1Blank44_5))
                {
                    return string.Format(ServiceRes._CanOnlyContainPlusOrMinus, ServiceRes.Bath1Blank44_5);
                }

                retStr = FieldCheckNotEmptyAndMaxLengthString(labSheetDetailModel.Lot35, ServiceRes.Lot35, 20);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotEmptyAndMaxLengthString(labSheetDetailModel.Lot44_5, ServiceRes.Lot44_5, 20);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullMaxLengthString(labSheetDetailModel.RunComment, ServiceRes.RunComment, 250);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullMaxLengthString(labSheetDetailModel.RunWeatherComment, ServiceRes.RunWeatherComment, 250);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullMaxLengthString(labSheetDetailModel.SampleBottleLotNumber, ServiceRes.SampleBottleLotNumber, 20);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullMaxLengthString(labSheetDetailModel.SalinitiesReadBy, ServiceRes.SalinitiesReadBy, 20);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotNullDateTime(labSheetDetailModel.SalinitiesReadDate, ServiceRes.SalinitiesReadDate);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullMaxLengthString(labSheetDetailModel.ResultsReadBy, ServiceRes.ResultsReadBy, 20);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotNullDateTime(labSheetDetailModel.ResultsReadDate, ServiceRes.ResultsReadDate);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullMaxLengthString(labSheetDetailModel.ResultsRecordedBy, ServiceRes.ResultsRecordedBy, 20);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotNullDateTime(labSheetDetailModel.ResultsRecordedDate, ServiceRes.ResultsRecordedDate);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetDetailModel.DailyDuplicateRLog, ServiceRes.DailyDuplicateRLog, 0, 100);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetDetailModel.DailyDuplicatePrecisionCriteria, ServiceRes.DailyDuplicatePrecisionCriteria, 0, 10);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetDetailModel.IntertechDuplicateRLog, ServiceRes.IntertechDuplicateRLog, 0, 100);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetDetailModel.IntertechDuplicatePrecisionCriteria, ServiceRes.IntertechDuplicatePrecisionCriteria, 0, 10);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

            }

            return "";
        }

        // Fill
        public string FillLabSheetDetail(LabSheetDetail labSheetDetail, LabSheetDetailModel labSheetDetailModel, ContactOK contactOK)
        {
            labSheetDetail.LabSheetID = labSheetDetailModel.LabSheetID;
            labSheetDetail.SamplingPlanID = labSheetDetailModel.SamplingPlanID;
            labSheetDetail.SubsectorTVItemID = labSheetDetailModel.SubsectorTVItemID;
            labSheetDetail.Version = labSheetDetailModel.Version;
            labSheetDetail.RunDate = labSheetDetailModel.RunDate;
            labSheetDetail.Tides = labSheetDetailModel.Tides;
            labSheetDetail.SampleCrewInitials = labSheetDetailModel.SampleCrewInitials;
            labSheetDetail.WaterBathCount = labSheetDetailModel.WaterBathCount;
            labSheetDetail.IncubationBath1StartTime = labSheetDetailModel.IncubationBath1StartTime;
            labSheetDetail.IncubationBath2StartTime = labSheetDetailModel.IncubationBath2StartTime;
            labSheetDetail.IncubationBath3StartTime = labSheetDetailModel.IncubationBath3StartTime;
            labSheetDetail.IncubationBath1EndTime = labSheetDetailModel.IncubationBath1EndTime;
            labSheetDetail.IncubationBath2EndTime = labSheetDetailModel.IncubationBath2EndTime;
            labSheetDetail.IncubationBath3EndTime = labSheetDetailModel.IncubationBath3EndTime;
            labSheetDetail.IncubationBath1TimeCalculated_minutes = labSheetDetailModel.IncubationBath1TimeCalculated_minutes;
            labSheetDetail.IncubationBath2TimeCalculated_minutes = labSheetDetailModel.IncubationBath2TimeCalculated_minutes;
            labSheetDetail.IncubationBath3TimeCalculated_minutes = labSheetDetailModel.IncubationBath3TimeCalculated_minutes;
            labSheetDetail.WaterBath1 = labSheetDetailModel.WaterBath1;
            labSheetDetail.WaterBath2 = labSheetDetailModel.WaterBath2;
            labSheetDetail.WaterBath3 = labSheetDetailModel.WaterBath3;
            labSheetDetail.TCField1 = labSheetDetailModel.TCField1;
            labSheetDetail.TCLab1 = labSheetDetailModel.TCLab1;
            labSheetDetail.TCField2 = labSheetDetailModel.TCField2;
            labSheetDetail.TCLab2 = labSheetDetailModel.TCLab2;
            labSheetDetail.TCFirst = labSheetDetailModel.TCFirst;
            labSheetDetail.TCAverage = labSheetDetailModel.TCAverage;
            labSheetDetail.ControlLot = labSheetDetailModel.ControlLot;
            labSheetDetail.Positive35 = labSheetDetailModel.Positive35;
            labSheetDetail.NonTarget35 = labSheetDetailModel.NonTarget35;
            labSheetDetail.Negative35 = labSheetDetailModel.Negative35;
            labSheetDetail.Bath1Positive44_5 = labSheetDetailModel.Bath1Positive44_5;
            labSheetDetail.Bath2Positive44_5 = labSheetDetailModel.Bath2Positive44_5;
            labSheetDetail.Bath3Positive44_5 = labSheetDetailModel.Bath3Positive44_5;
            labSheetDetail.Bath1NonTarget44_5 = labSheetDetailModel.Bath1NonTarget44_5;
            labSheetDetail.Bath2NonTarget44_5 = labSheetDetailModel.Bath2NonTarget44_5;
            labSheetDetail.Bath3NonTarget44_5 = labSheetDetailModel.Bath3NonTarget44_5;
            labSheetDetail.Bath1Negative44_5 = labSheetDetailModel.Bath1Negative44_5;
            labSheetDetail.Bath2Negative44_5 = labSheetDetailModel.Bath2Negative44_5;
            labSheetDetail.Bath3Negative44_5 = labSheetDetailModel.Bath3Negative44_5;
            labSheetDetail.Blank35 = labSheetDetailModel.Blank35;
            labSheetDetail.Bath1Blank44_5 = labSheetDetailModel.Bath1Blank44_5;
            labSheetDetail.Bath2Blank44_5 = labSheetDetailModel.Bath2Blank44_5;
            labSheetDetail.Bath3Blank44_5 = labSheetDetailModel.Bath3Blank44_5;
            labSheetDetail.Lot35 = labSheetDetailModel.Lot35;
            labSheetDetail.Lot44_5 = labSheetDetailModel.Lot44_5;
            labSheetDetail.RunComment = labSheetDetailModel.RunComment;
            labSheetDetail.RunWeatherComment = labSheetDetailModel.RunWeatherComment;
            labSheetDetail.SampleBottleLotNumber = labSheetDetailModel.SampleBottleLotNumber;
            labSheetDetail.SalinitiesReadBy = labSheetDetailModel.SalinitiesReadBy;
            labSheetDetail.SalinitiesReadDate = labSheetDetailModel.SalinitiesReadDate;
            labSheetDetail.ResultsReadBy = labSheetDetailModel.ResultsReadBy;
            labSheetDetail.ResultsReadDate = labSheetDetailModel.ResultsReadDate;
            labSheetDetail.ResultsRecordedBy = labSheetDetailModel.ResultsRecordedBy;
            labSheetDetail.ResultsRecordedDate = labSheetDetailModel.ResultsRecordedDate;
            labSheetDetail.DailyDuplicateRLog = labSheetDetailModel.DailyDuplicateRLog;
            labSheetDetail.DailyDuplicatePrecisionCriteria = labSheetDetailModel.DailyDuplicatePrecisionCriteria;
            labSheetDetail.DailyDuplicateAcceptable = labSheetDetailModel.DailyDuplicateAcceptable;
            labSheetDetail.IntertechDuplicateRLog = labSheetDetailModel.IntertechDuplicateRLog;
            labSheetDetail.IntertechDuplicatePrecisionCriteria = labSheetDetailModel.IntertechDuplicatePrecisionCriteria;
            labSheetDetail.IntertechDuplicateAcceptable = labSheetDetailModel.IntertechDuplicateAcceptable;
            labSheetDetail.IntertechReadAcceptable = labSheetDetailModel.IntertechReadAcceptable;
            labSheetDetail.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                labSheetDetail.LastUpdateContactTVItemID = 2;
            }
            else
            {
                labSheetDetail.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetLabSheetDetailModelCountDB()
        {
            int LabSheetDetailModelCount = (from c in db.LabSheetDetails
                                            select c).Count();

            return LabSheetDetailModelCount;
        }
        public LabSheetDetailModel GetLabSheetDetailModelExistDB(LabSheetDetailModel labSheetDetailModel)
        {
            LabSheetDetailModel labSheetDetailModelRet = (from c in db.LabSheetDetails
                                                          let subsectorTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault()
                                                          where c.SamplingPlanID == labSheetDetailModel.SamplingPlanID
                                                          && c.SubsectorTVItemID == labSheetDetailModel.SubsectorTVItemID
                                                          && c.RunDate.Year == labSheetDetailModel.RunDate.Year
                                                          && c.RunDate.Month == labSheetDetailModel.RunDate.Month
                                                          && c.RunDate.Day == labSheetDetailModel.RunDate.Day
                                                          select new LabSheetDetailModel
                                                          {
                                                              Error = "",
                                                              LabSheetDetailID = c.LabSheetDetailID,
                                                              LabSheetID = c.LabSheetID,
                                                              SamplingPlanID = c.SamplingPlanID,
                                                              SubsectorTVItemID = c.SubsectorTVItemID,
                                                              SubsectorTVText = subsectorTVText,
                                                              Version = c.Version,
                                                              RunDate = c.RunDate,
                                                              Tides = c.Tides,
                                                              SampleCrewInitials = c.SampleCrewInitials,
                                                              WaterBathCount = c.WaterBathCount,
                                                              IncubationBath1StartTime = c.IncubationBath1StartTime,
                                                              IncubationBath2StartTime = c.IncubationBath2StartTime,
                                                              IncubationBath3StartTime = c.IncubationBath3StartTime,
                                                              IncubationBath1EndTime = c.IncubationBath1EndTime,
                                                              IncubationBath2EndTime = c.IncubationBath2EndTime,
                                                              IncubationBath3EndTime = c.IncubationBath3EndTime,
                                                              IncubationBath1TimeCalculated_minutes = c.IncubationBath1TimeCalculated_minutes,
                                                              IncubationBath2TimeCalculated_minutes = c.IncubationBath2TimeCalculated_minutes,
                                                              IncubationBath3TimeCalculated_minutes = c.IncubationBath3TimeCalculated_minutes,
                                                              WaterBath1 = c.WaterBath1,
                                                              WaterBath2 = c.WaterBath2,
                                                              WaterBath3 = c.WaterBath3,
                                                              TCField1 = (float)c.TCField1,
                                                              TCLab1 = (float)c.TCLab1,
                                                              TCField2 = (float)c.TCField2,
                                                              TCLab2 = (float)c.TCLab2,
                                                              TCFirst = (float)c.TCFirst,
                                                              TCAverage = (float)c.TCAverage,
                                                              ControlLot = c.ControlLot,
                                                              Positive35 = c.Positive35,
                                                              NonTarget35 = c.NonTarget35,
                                                              Negative35 = c.Negative35,
                                                              Bath1Positive44_5 = c.Bath1Positive44_5,
                                                              Bath2Positive44_5 = c.Bath2Positive44_5,
                                                              Bath3Positive44_5 = c.Bath3Positive44_5,
                                                              Bath1NonTarget44_5 = c.Bath1NonTarget44_5,
                                                              Bath2NonTarget44_5 = c.Bath2NonTarget44_5,
                                                              Bath3NonTarget44_5 = c.Bath3NonTarget44_5,
                                                              Bath1Negative44_5 = c.Bath1Negative44_5,
                                                              Bath2Negative44_5 = c.Bath2Negative44_5,
                                                              Bath3Negative44_5 = c.Bath3Negative44_5,
                                                              Blank35 = c.Blank35,
                                                              Bath1Blank44_5 = c.Bath1Blank44_5,
                                                              Bath2Blank44_5 = c.Bath2Blank44_5,
                                                              Bath3Blank44_5 = c.Bath3Blank44_5,
                                                              Lot35 = c.Lot35,
                                                              Lot44_5 = c.Lot44_5,
                                                              RunComment = c.RunComment,
                                                              RunWeatherComment = c.RunWeatherComment,
                                                              SampleBottleLotNumber = c.SampleBottleLotNumber,
                                                              SalinitiesReadBy = c.SalinitiesReadBy,
                                                              SalinitiesReadDate = c.SalinitiesReadDate,
                                                              ResultsReadBy = c.ResultsReadBy,
                                                              ResultsReadDate = c.ResultsReadDate,
                                                              ResultsRecordedBy = c.ResultsRecordedBy,
                                                              ResultsRecordedDate = c.ResultsRecordedDate,
                                                              DailyDuplicateRLog = c.DailyDuplicateRLog,
                                                              DailyDuplicatePrecisionCriteria = c.DailyDuplicatePrecisionCriteria,
                                                              DailyDuplicateAcceptable = c.DailyDuplicateAcceptable,
                                                              IntertechDuplicateRLog = c.IntertechDuplicateRLog,
                                                              IntertechDuplicatePrecisionCriteria = c.IntertechDuplicatePrecisionCriteria,
                                                              IntertechDuplicateAcceptable = c.IntertechDuplicateAcceptable,
                                                              IntertechReadAcceptable = c.IntertechReadAcceptable,                                                               
                                                              LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                              LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                          }).FirstOrDefault<LabSheetDetailModel>();

            if (labSheetDetailModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.SamplingPlanID,
                    ServiceRes.SubsectorTVItemID + "," +
                    ServiceRes.Year + "," +
                    ServiceRes.Month + "," +
                    ServiceRes.Day,
                    labSheetDetailModel.SamplingPlanID + "," +
                    labSheetDetailModel.SubsectorTVItemID + "," +
                    labSheetDetailModel.RunDate.Year.ToString() + "," +
                    labSheetDetailModel.RunDate.Month.ToString() + "," +
                    labSheetDetailModel.RunDate.Day.ToString()));

            return labSheetDetailModelRet;
        }
        public List<LabSheetDetailModel> GetLabSheetDetailModelListWithLabSheetIDDB(int LabSheetID)
        {
            List<LabSheetDetailModel> LabSheetDetailModelList = (from c in db.LabSheetDetails
                                                                 let subsectorTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault()
                                                                 where c.LabSheetID == LabSheetID
                                                                 select new LabSheetDetailModel
                                                                 {
                                                                     Error = "",
                                                                     LabSheetDetailID = c.LabSheetDetailID,
                                                                     LabSheetID = c.LabSheetID,
                                                                     SamplingPlanID = c.SamplingPlanID,
                                                                     SubsectorTVItemID = c.SubsectorTVItemID,
                                                                     SubsectorTVText = subsectorTVText,
                                                                     Version = c.Version,
                                                                     RunDate = c.RunDate,
                                                                     Tides = c.Tides,
                                                                     SampleCrewInitials = c.SampleCrewInitials,
                                                                     WaterBathCount = c.WaterBathCount,
                                                                     IncubationBath1StartTime = c.IncubationBath1StartTime,
                                                                     IncubationBath2StartTime = c.IncubationBath2StartTime,
                                                                     IncubationBath3StartTime = c.IncubationBath3StartTime,
                                                                     IncubationBath1EndTime = c.IncubationBath1EndTime,
                                                                     IncubationBath2EndTime = c.IncubationBath2EndTime,
                                                                     IncubationBath3EndTime = c.IncubationBath3EndTime,
                                                                     IncubationBath1TimeCalculated_minutes = c.IncubationBath1TimeCalculated_minutes,
                                                                     IncubationBath2TimeCalculated_minutes = c.IncubationBath2TimeCalculated_minutes,
                                                                     IncubationBath3TimeCalculated_minutes = c.IncubationBath3TimeCalculated_minutes,
                                                                     WaterBath1 = c.WaterBath1,
                                                                     WaterBath2 = c.WaterBath2,
                                                                     WaterBath3 = c.WaterBath3,
                                                                     TCField1 = (float)c.TCField1,
                                                                     TCLab1 = (float)c.TCLab1,
                                                                     TCField2 = (float)c.TCField2,
                                                                     TCLab2 = (float)c.TCLab2,
                                                                     TCFirst = (float)c.TCFirst,
                                                                     TCAverage = (float)c.TCAverage,
                                                                     ControlLot = c.ControlLot,
                                                                     Positive35 = c.Positive35,
                                                                     NonTarget35 = c.NonTarget35,
                                                                     Negative35 = c.Negative35,
                                                                     Bath1Positive44_5 = c.Bath1Positive44_5,
                                                                     Bath2Positive44_5 = c.Bath2Positive44_5,
                                                                     Bath3Positive44_5 = c.Bath3Positive44_5,
                                                                     Bath1NonTarget44_5 = c.Bath1NonTarget44_5,
                                                                     Bath2NonTarget44_5 = c.Bath2NonTarget44_5,
                                                                     Bath3NonTarget44_5 = c.Bath3NonTarget44_5,
                                                                     Bath1Negative44_5 = c.Bath1Negative44_5,
                                                                     Bath2Negative44_5 = c.Bath2Negative44_5,
                                                                     Bath3Negative44_5 = c.Bath3Negative44_5,
                                                                     Blank35 = c.Blank35,
                                                                     Bath1Blank44_5 = c.Bath1Blank44_5,
                                                                     Bath2Blank44_5 = c.Bath2Blank44_5,
                                                                     Bath3Blank44_5 = c.Bath3Blank44_5,
                                                                     Lot35 = c.Lot35,
                                                                     Lot44_5 = c.Lot44_5,
                                                                     RunComment = c.RunComment,
                                                                     RunWeatherComment = c.RunWeatherComment,
                                                                     SampleBottleLotNumber = c.SampleBottleLotNumber,
                                                                     SalinitiesReadBy = c.SalinitiesReadBy,
                                                                     SalinitiesReadDate = c.SalinitiesReadDate,
                                                                     ResultsReadBy = c.ResultsReadBy,
                                                                     ResultsReadDate = c.ResultsReadDate,
                                                                     ResultsRecordedBy = c.ResultsRecordedBy,
                                                                     ResultsRecordedDate = c.ResultsRecordedDate,
                                                                     DailyDuplicateRLog = c.DailyDuplicateRLog,
                                                                     DailyDuplicatePrecisionCriteria = c.DailyDuplicatePrecisionCriteria,
                                                                     DailyDuplicateAcceptable = c.DailyDuplicateAcceptable,
                                                                     IntertechDuplicateRLog = c.IntertechDuplicateRLog,
                                                                     IntertechDuplicatePrecisionCriteria = c.IntertechDuplicatePrecisionCriteria,
                                                                     IntertechDuplicateAcceptable = c.IntertechDuplicateAcceptable,
                                                                     IntertechReadAcceptable = c.IntertechReadAcceptable,
                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                 }).ToList<LabSheetDetailModel>();

            return LabSheetDetailModelList;
        }
        public List<LabSheetDetailModel> GetLabSheetDetailModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<LabSheetDetailModel> LabSheetDetailModelList = (from c in db.LabSheetDetails
                                                                 let subsectorTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault()
                                                                 where c.SubsectorTVItemID == SubsectorTVItemID
                                                                 orderby c.RunDate.Year, c.RunDate.Month, c.RunDate.Day
                                                                 select new LabSheetDetailModel
                                                                 {
                                                                     Error = "",
                                                                     LabSheetDetailID = c.LabSheetDetailID,
                                                                     LabSheetID = c.LabSheetID,
                                                                     SamplingPlanID = c.SamplingPlanID,
                                                                     SubsectorTVItemID = c.SubsectorTVItemID,
                                                                     SubsectorTVText = subsectorTVText,
                                                                     Version = c.Version,
                                                                     RunDate = c.RunDate,
                                                                     Tides = c.Tides,
                                                                     SampleCrewInitials = c.SampleCrewInitials,
                                                                     WaterBathCount = c.WaterBathCount,
                                                                     IncubationBath1StartTime = c.IncubationBath1StartTime,
                                                                     IncubationBath2StartTime = c.IncubationBath2StartTime,
                                                                     IncubationBath3StartTime = c.IncubationBath3StartTime,
                                                                     IncubationBath1EndTime = c.IncubationBath1EndTime,
                                                                     IncubationBath2EndTime = c.IncubationBath2EndTime,
                                                                     IncubationBath3EndTime = c.IncubationBath3EndTime,
                                                                     IncubationBath1TimeCalculated_minutes = c.IncubationBath1TimeCalculated_minutes,
                                                                     IncubationBath2TimeCalculated_minutes = c.IncubationBath2TimeCalculated_minutes,
                                                                     IncubationBath3TimeCalculated_minutes = c.IncubationBath3TimeCalculated_minutes,
                                                                     WaterBath1 = c.WaterBath1,
                                                                     WaterBath2 = c.WaterBath2,
                                                                     WaterBath3 = c.WaterBath3,
                                                                     TCField1 = (float)c.TCField1,
                                                                     TCLab1 = (float)c.TCLab1,
                                                                     TCField2 = (float)c.TCField2,
                                                                     TCLab2 = (float)c.TCLab2,
                                                                     TCFirst = (float)c.TCFirst,
                                                                     TCAverage = (float)c.TCAverage,
                                                                     ControlLot = c.ControlLot,
                                                                     Positive35 = c.Positive35,
                                                                     NonTarget35 = c.NonTarget35,
                                                                     Negative35 = c.Negative35,
                                                                     Bath1Positive44_5 = c.Bath1Positive44_5,
                                                                     Bath2Positive44_5 = c.Bath2Positive44_5,
                                                                     Bath3Positive44_5 = c.Bath3Positive44_5,
                                                                     Bath1NonTarget44_5 = c.Bath1NonTarget44_5,
                                                                     Bath2NonTarget44_5 = c.Bath2NonTarget44_5,
                                                                     Bath3NonTarget44_5 = c.Bath3NonTarget44_5,
                                                                     Bath1Negative44_5 = c.Bath1Negative44_5,
                                                                     Bath2Negative44_5 = c.Bath2Negative44_5,
                                                                     Bath3Negative44_5 = c.Bath3Negative44_5,
                                                                     Blank35 = c.Blank35,
                                                                     Bath1Blank44_5 = c.Bath1Blank44_5,
                                                                     Bath2Blank44_5 = c.Bath2Blank44_5,
                                                                     Bath3Blank44_5 = c.Bath3Blank44_5,
                                                                     Lot35 = c.Lot35,
                                                                     Lot44_5 = c.Lot44_5,
                                                                     RunComment = c.RunComment,
                                                                     RunWeatherComment = c.RunWeatherComment,
                                                                     SampleBottleLotNumber = c.SampleBottleLotNumber,
                                                                     SalinitiesReadBy = c.SalinitiesReadBy,
                                                                     SalinitiesReadDate = c.SalinitiesReadDate,
                                                                     ResultsReadBy = c.ResultsReadBy,
                                                                     ResultsReadDate = c.ResultsReadDate,
                                                                     ResultsRecordedBy = c.ResultsRecordedBy,
                                                                     ResultsRecordedDate = c.ResultsRecordedDate,
                                                                     DailyDuplicateRLog = c.DailyDuplicateRLog,
                                                                     DailyDuplicatePrecisionCriteria = c.DailyDuplicatePrecisionCriteria,
                                                                     DailyDuplicateAcceptable = c.DailyDuplicateAcceptable,
                                                                     IntertechDuplicateRLog = c.IntertechDuplicateRLog,
                                                                     IntertechDuplicatePrecisionCriteria = c.IntertechDuplicatePrecisionCriteria,
                                                                     IntertechDuplicateAcceptable = c.IntertechDuplicateAcceptable,
                                                                     IntertechReadAcceptable = c.IntertechReadAcceptable,
                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                 }).ToList<LabSheetDetailModel>();

            return LabSheetDetailModelList;
        }
        public LabSheetDetailModel GetLabSheetDetailModelWithLabSheetDetailIDDB(int LabSheetDetailID)
        {
            LabSheetDetailModel labSheetDetailModel = (from c in db.LabSheetDetails
                                                       let subsectorTVText = (from cl in db.TVItemLanguages where cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault()
                                                       where c.LabSheetDetailID == LabSheetDetailID
                                                       select new LabSheetDetailModel
                                                       {
                                                           Error = "",
                                                           LabSheetDetailID = c.LabSheetDetailID,
                                                           LabSheetID = c.LabSheetID,
                                                           SamplingPlanID = c.SamplingPlanID,
                                                           SubsectorTVItemID = c.SubsectorTVItemID,
                                                           SubsectorTVText = subsectorTVText,
                                                           Version = c.Version,
                                                           RunDate = c.RunDate,
                                                           Tides = c.Tides,
                                                           SampleCrewInitials = c.SampleCrewInitials,
                                                           WaterBathCount = c.WaterBathCount,
                                                           IncubationBath1StartTime = c.IncubationBath1StartTime,
                                                           IncubationBath2StartTime = c.IncubationBath2StartTime,
                                                           IncubationBath3StartTime = c.IncubationBath3StartTime,
                                                           IncubationBath1EndTime = c.IncubationBath1EndTime,
                                                           IncubationBath2EndTime = c.IncubationBath2EndTime,
                                                           IncubationBath3EndTime = c.IncubationBath3EndTime,
                                                           IncubationBath1TimeCalculated_minutes = c.IncubationBath1TimeCalculated_minutes,
                                                           IncubationBath2TimeCalculated_minutes = c.IncubationBath2TimeCalculated_minutes,
                                                           IncubationBath3TimeCalculated_minutes = c.IncubationBath3TimeCalculated_minutes,
                                                           WaterBath1 = c.WaterBath1,
                                                           WaterBath2 = c.WaterBath2,
                                                           WaterBath3 = c.WaterBath3,
                                                           TCField1 = (float)c.TCField1,
                                                           TCLab1 = (float)c.TCLab1,
                                                           TCField2 = (float)c.TCField2,
                                                           TCLab2 = (float)c.TCLab2,
                                                           TCFirst = (float)c.TCFirst,
                                                           TCAverage = (float)c.TCAverage,
                                                           ControlLot = c.ControlLot,
                                                           Positive35 = c.Positive35,
                                                           NonTarget35 = c.NonTarget35,
                                                           Negative35 = c.Negative35,
                                                           Bath1Positive44_5 = c.Bath1Positive44_5,
                                                           Bath2Positive44_5 = c.Bath2Positive44_5,
                                                           Bath3Positive44_5 = c.Bath3Positive44_5,
                                                           Bath1NonTarget44_5 = c.Bath1NonTarget44_5,
                                                           Bath2NonTarget44_5 = c.Bath2NonTarget44_5,
                                                           Bath3NonTarget44_5 = c.Bath3NonTarget44_5,
                                                           Bath1Negative44_5 = c.Bath1Negative44_5,
                                                           Bath2Negative44_5 = c.Bath2Negative44_5,
                                                           Bath3Negative44_5 = c.Bath3Negative44_5,
                                                           Blank35 = c.Blank35,
                                                           Bath1Blank44_5 = c.Bath1Blank44_5,
                                                           Bath2Blank44_5 = c.Bath2Blank44_5,
                                                           Bath3Blank44_5 = c.Bath3Blank44_5,
                                                           Lot35 = c.Lot35,
                                                           Lot44_5 = c.Lot44_5,
                                                           RunComment = c.RunComment,
                                                           RunWeatherComment = c.RunWeatherComment,
                                                           SampleBottleLotNumber = c.SampleBottleLotNumber,
                                                           SalinitiesReadBy = c.SalinitiesReadBy,
                                                           SalinitiesReadDate = c.SalinitiesReadDate,
                                                           ResultsReadBy = c.ResultsReadBy,
                                                           ResultsReadDate = c.ResultsReadDate,
                                                           ResultsRecordedBy = c.ResultsRecordedBy,
                                                           ResultsRecordedDate = c.ResultsRecordedDate,
                                                           DailyDuplicateRLog = c.DailyDuplicateRLog,
                                                           DailyDuplicatePrecisionCriteria = c.DailyDuplicatePrecisionCriteria,
                                                           DailyDuplicateAcceptable = c.DailyDuplicateAcceptable,
                                                           IntertechDuplicateRLog = c.IntertechDuplicateRLog,
                                                           IntertechDuplicatePrecisionCriteria = c.IntertechDuplicatePrecisionCriteria,
                                                           IntertechDuplicateAcceptable = c.IntertechDuplicateAcceptable,
                                                           IntertechReadAcceptable = c.IntertechReadAcceptable,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<LabSheetDetailModel>();

            if (labSheetDetailModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheetDetail, ServiceRes.LabSheetDetailID, LabSheetDetailID));

            return labSheetDetailModel;
        }
        public LabSheetDetail GetLabSheetDetailWithLabSheetDetailIDDB(int LabSheetDetailID)
        {
            LabSheetDetail labSheetDetail = (from c in db.LabSheetDetails
                                             where c.LabSheetDetailID == LabSheetDetailID
                                             select c).FirstOrDefault<LabSheetDetail>();

            return labSheetDetail;
        }

        // Helper
        public LabSheetDetailModel ReturnError(string Error)
        {
            return new LabSheetDetailModel() { Error = Error };
        }

        // Post
        public LabSheetDetailModel PostAddLabSheetDetailDB(LabSheetDetailModel labSheetDetailModel)
        {
            string retStr = LabSheetDetailModelOK(labSheetDetailModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            LabSheetDetailModel labSheetDetailModelExist = GetLabSheetDetailModelExistDB(labSheetDetailModel);
            if (string.IsNullOrWhiteSpace(labSheetDetailModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.LabSheetDetail));

            LabSheetDetail labSheetDetailNew = new LabSheetDetail();
            retStr = FillLabSheetDetail(labSheetDetailNew, labSheetDetailModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.LabSheetDetails.Add(labSheetDetailNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("LabSheetDetails", labSheetDetailNew.LabSheetDetailID, LogCommandEnum.Add, labSheetDetailNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetLabSheetDetailModelWithLabSheetDetailIDDB(labSheetDetailNew.LabSheetDetailID);
        }
        public LabSheetDetailModel PostDeleteLabSheetDetailDB(int LabSheetDetailID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            LabSheetDetail labSheetDetailToDelete = GetLabSheetDetailWithLabSheetDetailIDDB(LabSheetDetailID);
            if (labSheetDetailToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.LabSheetDetail));

            using (TransactionScope ts = new TransactionScope())
            {
                db.LabSheetDetails.Remove(labSheetDetailToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("LabSheetDetails", labSheetDetailToDelete.LabSheetDetailID, LogCommandEnum.Delete, labSheetDetailToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public LabSheetDetailModel PostUpdateLabSheetDetailDB(LabSheetDetailModel labSheetDetailModel)
        {
            string retStr = LabSheetDetailModelOK(labSheetDetailModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            LabSheetDetail labSheetDetailToUpdate = GetLabSheetDetailWithLabSheetDetailIDDB(labSheetDetailModel.LabSheetDetailID);
            if (labSheetDetailToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.LabSheetDetail));

            retStr = FillLabSheetDetail(labSheetDetailToUpdate, labSheetDetailModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("LabSheetDetails", labSheetDetailToUpdate.LabSheetDetailID, LogCommandEnum.Change, labSheetDetailToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetLabSheetDetailModelWithLabSheetDetailIDDB(labSheetDetailToUpdate.LabSheetDetailID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
