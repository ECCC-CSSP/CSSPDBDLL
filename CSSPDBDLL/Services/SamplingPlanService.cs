using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using System.Collections.Generic;
using System;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using System.Web.Mvc;
using System.IO;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPDBDLL.Services
{
    public class SamplingPlanService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public AppTaskService _AppTaskService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public SamplingPlanEmailService _SamplingPlanEmailService { get; private set; }
        public SamplingPlanSubsectorService _SamplingPlanSubsectorService { get; private set; }
        public SamplingPlanSubsectorSiteService _SamplingPlanSubsectorSiteService { get; private set; }
        public TVFileService _TVFileService { get; private set; }
        public MWQMSubsectorService _MWQMSubsectorService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _SamplingPlanEmailService = new SamplingPlanEmailService(LanguageRequest, User);
            _SamplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageRequest, User);
            _SamplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(LanguageRequest, User);
            _TVFileService = new TVFileService(LanguageRequest, User);
            _MWQMSubsectorService = new MWQMSubsectorService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
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
        public string SamplingPlanModelOK(SamplingPlanModel SamplingPlanModel)
        {
            string retStr = FieldCheckNotNullAndMinMaxLengthString(SamplingPlanModel.SamplingPlanName, ServiceRes.SamplingPlanName, 3, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (SamplingPlanModel.SamplingPlanID > 0)
            {
                SamplingPlan SamplingPlan = (from c in db.SamplingPlans
                                             where c.SamplingPlanID != SamplingPlanModel.SamplingPlanID
                                             && c.SamplingPlanName == SamplingPlanModel.SamplingPlanName
                                             select c).FirstOrDefault();

                if (SamplingPlan != null)
                {
                    return string.Format(ServiceRes._AlreadyExists, ServiceRes.SamplingPlanName);
                }
            }
            else
            {
                SamplingPlan SamplingPlan = (from c in db.SamplingPlans
                                             where c.SamplingPlanName == SamplingPlanModel.SamplingPlanName
                                             select c).FirstOrDefault();

                if (SamplingPlan != null)
                {
                    return string.Format(ServiceRes._AlreadyExists, ServiceRes.SamplingPlanName);
                }
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(SamplingPlanModel.ForGroupName, ServiceRes.ForGroupName, 3, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.SampleTypeOK(SamplingPlanModel.SampleType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.SamplingPlanTypeOK(SamplingPlanModel.SamplingPlanType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LabSheetTypeOK(SamplingPlanModel.LabSheetType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(SamplingPlanModel.ProvinceTVItemID, ServiceRes.ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(SamplingPlanModel.CreatorTVItemID, ServiceRes.CreatorTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(SamplingPlanModel.Year, ServiceRes.Year, 2000, 2050);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(SamplingPlanModel.AccessCode, ServiceRes.AccessCode, 3, 10);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(SamplingPlanModel.IncludeLaboratoryQAQC, ServiceRes.IncludeLaboratoryQAQC);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (SamplingPlanModel.IncludeLaboratoryQAQC)
            {
                retStr = FieldCheckIfNotNullMaxLengthString(SamplingPlanModel.ApprovalCode, ServiceRes.ApprovalCode, 10);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotNullAndWithinRangeDouble(SamplingPlanModel.DailyDuplicatePrecisionCriteria, ServiceRes.DailyDuplicatePrecisionCriteria, 0.0f, 5.0f);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }

                retStr = FieldCheckNotNullAndWithinRangeDouble(SamplingPlanModel.IntertechDuplicatePrecisionCriteria, ServiceRes.IntertechDuplicatePrecisionCriteria, 0.0f, 5.0f);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            retStr = FieldCheckIfNotNullNotZeroInt(SamplingPlanModel.SamplingPlanFileTVItemID, ServiceRes.SamplingPlanFileTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillSamplingPlan(SamplingPlan SamplingPlan, SamplingPlanModel SamplingPlanModel, ContactOK contactOK)
        {
            SamplingPlan.SamplingPlanName = SamplingPlanModel.SamplingPlanName;
            SamplingPlan.ForGroupName = SamplingPlanModel.ForGroupName;
            SamplingPlan.SampleType = (int)SamplingPlanModel.SampleType;
            SamplingPlan.SamplingPlanType = (int)SamplingPlanModel.SamplingPlanType;
            SamplingPlan.LabSheetType = (int)SamplingPlanModel.LabSheetType;
            SamplingPlan.ProvinceTVItemID = SamplingPlanModel.ProvinceTVItemID;
            SamplingPlan.CreatorTVItemID = SamplingPlanModel.CreatorTVItemID;
            SamplingPlan.Year = SamplingPlanModel.Year;
            SamplingPlan.AccessCode = SamplingPlanModel.AccessCode;
            SamplingPlan.DailyDuplicatePrecisionCriteria = SamplingPlanModel.DailyDuplicatePrecisionCriteria;
            SamplingPlan.IntertechDuplicatePrecisionCriteria = SamplingPlanModel.IntertechDuplicatePrecisionCriteria;
            SamplingPlan.IncludeLaboratoryQAQC = SamplingPlanModel.IncludeLaboratoryQAQC;
            SamplingPlan.ApprovalCode = SamplingPlanModel.ApprovalCode;
            SamplingPlan.SamplingPlanFileTVItemID = SamplingPlanModel.SamplingPlanFileTVItemID;
            SamplingPlan.AnalyzeMethodDefault = (int)(SamplingPlanModel.AnalyzeMethodDefault != null ? SamplingPlanModel.AnalyzeMethodDefault : AnalyzeMethodEnum.Error);
            SamplingPlan.SampleMatrixDefault = (int)(SamplingPlanModel.SampleMatrixDefault != null ? SamplingPlanModel.SampleMatrixDefault : SampleMatrixEnum.Error);
            SamplingPlan.LaboratoryDefault = (int)(SamplingPlanModel.LaboratoryDefault != null ? SamplingPlanModel.LaboratoryDefault : LaboratoryEnum.Error);
            SamplingPlan.BackupDirectory = SamplingPlanModel.BackupDirectory;
            SamplingPlan.IsActive = SamplingPlanModel.IsActive;
            SamplingPlan.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                SamplingPlan.LastUpdateContactTVItemID = 2;
            }
            else
            {
                SamplingPlan.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetSamplingPlanModelCountDB()
        {
            int SamplingPlanModelCount = (from c in db.SamplingPlans
                                          select c).Count();

            return SamplingPlanModelCount;
        }
        public List<SamplingPlanModel> GetAllActiveSamplingPlanModelListDB()
        {
            List<SamplingPlanModel> SamplingPlanModelList = (from c in db.SamplingPlans
                                                             let provinceTVText = (from p in db.TVItemLanguages where c.ProvinceTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                             let creatorTVText = (from p in db.TVItemLanguages where c.CreatorTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                             where c.IsActive == true
                                                             orderby c.ForGroupName
                                                             select new SamplingPlanModel
                                                             {
                                                                 Error = "",
                                                                 SamplingPlanID = c.SamplingPlanID,
                                                                 SamplingPlanName = c.SamplingPlanName,
                                                                 ForGroupName = c.ForGroupName,
                                                                 SampleType = (SampleTypeEnum)c.SampleType,
                                                                 SamplingPlanType = (SamplingPlanTypeEnum)c.SamplingPlanType,
                                                                 LabSheetType = (LabSheetTypeEnum)c.LabSheetType,
                                                                 ProvinceTVItemID = c.ProvinceTVItemID,
                                                                 ProvinceTVText = provinceTVText,
                                                                 CreatorTVItemID = c.CreatorTVItemID,
                                                                 CreatorTVText = creatorTVText,
                                                                 Year = c.Year,
                                                                 AccessCode = c.AccessCode,
                                                                 DailyDuplicatePrecisionCriteria = (float)c.DailyDuplicatePrecisionCriteria,
                                                                 IntertechDuplicatePrecisionCriteria = (float)c.IntertechDuplicatePrecisionCriteria,
                                                                 IncludeLaboratoryQAQC = c.IncludeLaboratoryQAQC,
                                                                 ApprovalCode = c.ApprovalCode,
                                                                 SamplingPlanFileTVItemID = c.SamplingPlanFileTVItemID,
                                                                 AnalyzeMethodDefault = (AnalyzeMethodEnum)c.AnalyzeMethodDefault,
                                                                 SampleMatrixDefault = (SampleMatrixEnum)c.SampleMatrixDefault,
                                                                 LaboratoryDefault = (LaboratoryEnum)c.LaboratoryDefault,
                                                                 BackupDirectory = c.BackupDirectory,
                                                                 IsActive = c.IsActive,
                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                             }).ToList<SamplingPlanModel>();

            return SamplingPlanModelList;
        }
        public SamplingPlanModel GetSamplingPlanModelExistDB(SamplingPlanModel SamplingPlanModel)
        {
            SamplingPlanModel SamplingPlanModelRet = (from c in db.SamplingPlans
                                                      let provinceTVText = (from p in db.TVItemLanguages where c.ProvinceTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                      let creatorTVText = (from p in db.TVItemLanguages where c.CreatorTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                      where c.Year == SamplingPlanModel.Year
                                                      && c.SamplingPlanName == SamplingPlanModel.SamplingPlanName
                                                      && c.ForGroupName == SamplingPlanModel.ForGroupName
                                                      && c.SampleType == (int)SamplingPlanModel.SampleType
                                                      && c.SamplingPlanType == (int)SamplingPlanModel.SamplingPlanType
                                                      && c.LabSheetType == (int)SamplingPlanModel.LabSheetType
                                                      && c.ProvinceTVItemID == SamplingPlanModel.ProvinceTVItemID
                                                      select new SamplingPlanModel
                                                      {
                                                          Error = "",
                                                          SamplingPlanID = c.SamplingPlanID,
                                                          SamplingPlanName = c.SamplingPlanName,
                                                          ForGroupName = c.ForGroupName,
                                                          SampleType = (SampleTypeEnum)c.SampleType,
                                                          SamplingPlanType = (SamplingPlanTypeEnum)c.SamplingPlanType,
                                                          LabSheetType = (LabSheetTypeEnum)c.LabSheetType,
                                                          ProvinceTVItemID = c.ProvinceTVItemID,
                                                          ProvinceTVText = provinceTVText,
                                                          CreatorTVItemID = c.CreatorTVItemID,
                                                          CreatorTVText = creatorTVText,
                                                          Year = c.Year,
                                                          AccessCode = c.AccessCode,
                                                          DailyDuplicatePrecisionCriteria = (float)c.DailyDuplicatePrecisionCriteria,
                                                          IntertechDuplicatePrecisionCriteria = (float)c.IntertechDuplicatePrecisionCriteria,
                                                          IncludeLaboratoryQAQC = c.IncludeLaboratoryQAQC,
                                                          ApprovalCode = c.ApprovalCode,
                                                          SamplingPlanFileTVItemID = c.SamplingPlanFileTVItemID,
                                                          AnalyzeMethodDefault = (AnalyzeMethodEnum)c.AnalyzeMethodDefault,
                                                          SampleMatrixDefault = (SampleMatrixEnum)c.SampleMatrixDefault,
                                                          LaboratoryDefault = (LaboratoryEnum)c.LaboratoryDefault,
                                                          BackupDirectory = c.BackupDirectory,
                                                          IsActive = c.IsActive,
                                                          LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                          LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                      }).FirstOrDefault<SamplingPlanModel>();


            if (SamplingPlanModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.SamplingPlan,
                    ServiceRes.Year + "," +
                    ServiceRes.SamplingPlanName + "," +
                    ServiceRes.ForGroupName + "," +
                    ServiceRes.SampleType + "," +
                    ServiceRes.SamplingPlanType + "," +
                    ServiceRes.LabSheetType + "," +
                    ServiceRes.ProvinceTVItemID,
                    SamplingPlanModel.Year + "," +
                    SamplingPlanModel.SamplingPlanName + "," +
                    SamplingPlanModel.ForGroupName + "," +
                    SamplingPlanModel.SampleType.ToString() + "," +
                    SamplingPlanModel.SamplingPlanType.ToString() + "," +
                    SamplingPlanModel.LabSheetType.ToString() + "," +
                    SamplingPlanModel.ProvinceTVItemID));

            return SamplingPlanModelRet;
        }
        public List<SamplingPlanModel> GetSamplingPlanModelListWithProvinceTVItemIDDB(int ProvinceTVItemID)
        {
            List<SamplingPlanModel> SamplingPlanModelList = (from c in db.SamplingPlans
                                                             let provinceTVText = (from p in db.TVItemLanguages where c.ProvinceTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                             let creatorTVText = (from p in db.TVItemLanguages where c.CreatorTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                             where c.ProvinceTVItemID == ProvinceTVItemID
                                                             orderby c.ForGroupName
                                                             select new SamplingPlanModel
                                                             {
                                                                 Error = "",
                                                                 SamplingPlanID = c.SamplingPlanID,
                                                                 SamplingPlanName = c.SamplingPlanName,
                                                                 ForGroupName = c.ForGroupName,
                                                                 SampleType = (SampleTypeEnum)c.SampleType,
                                                                 SamplingPlanType = (SamplingPlanTypeEnum)c.SamplingPlanType,
                                                                 LabSheetType = (LabSheetTypeEnum)c.LabSheetType,
                                                                 ProvinceTVItemID = c.ProvinceTVItemID,
                                                                 ProvinceTVText = provinceTVText,
                                                                 CreatorTVItemID = c.CreatorTVItemID,
                                                                 CreatorTVText = creatorTVText,
                                                                 Year = c.Year,
                                                                 AccessCode = c.AccessCode,
                                                                 DailyDuplicatePrecisionCriteria = (float)c.DailyDuplicatePrecisionCriteria,
                                                                 IntertechDuplicatePrecisionCriteria = (float)c.IntertechDuplicatePrecisionCriteria,
                                                                 IncludeLaboratoryQAQC = c.IncludeLaboratoryQAQC,
                                                                 ApprovalCode = c.ApprovalCode,
                                                                 SamplingPlanFileTVItemID = c.SamplingPlanFileTVItemID,
                                                                 AnalyzeMethodDefault = (AnalyzeMethodEnum)c.AnalyzeMethodDefault,
                                                                 SampleMatrixDefault = (SampleMatrixEnum)c.SampleMatrixDefault,
                                                                 LaboratoryDefault = (LaboratoryEnum)c.LaboratoryDefault,
                                                                 BackupDirectory = c.BackupDirectory,
                                                                 IsActive = c.IsActive,
                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                             }).ToList<SamplingPlanModel>();

            return SamplingPlanModelList;
        }
        public SamplingPlanModel GetSamplingPlanModelWithSamplingPlanNameDB(string SamplingPlanName)
        {
            SamplingPlanModel SamplingPlanModel = (from c in db.SamplingPlans
                                                   let provinceTVText = (from p in db.TVItemLanguages where c.ProvinceTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                   let creatorTVText = (from p in db.TVItemLanguages where c.CreatorTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                   where c.SamplingPlanName == SamplingPlanName
                                                   select new SamplingPlanModel
                                                   {
                                                       Error = "",
                                                       SamplingPlanID = c.SamplingPlanID,
                                                       SamplingPlanName = c.SamplingPlanName,
                                                       ForGroupName = c.ForGroupName,
                                                       SampleType = (SampleTypeEnum)c.SampleType,
                                                       SamplingPlanType = (SamplingPlanTypeEnum)c.SamplingPlanType,
                                                       LabSheetType = (LabSheetTypeEnum)c.LabSheetType,
                                                       ProvinceTVItemID = c.ProvinceTVItemID,
                                                       ProvinceTVText = provinceTVText,
                                                       CreatorTVItemID = c.CreatorTVItemID,
                                                       CreatorTVText = creatorTVText,
                                                       Year = c.Year,
                                                       AccessCode = c.AccessCode,
                                                       DailyDuplicatePrecisionCriteria = (float)c.DailyDuplicatePrecisionCriteria,
                                                       IntertechDuplicatePrecisionCriteria = (float)c.IntertechDuplicatePrecisionCriteria,
                                                       IncludeLaboratoryQAQC = c.IncludeLaboratoryQAQC,
                                                       ApprovalCode = c.ApprovalCode,
                                                       SamplingPlanFileTVItemID = c.SamplingPlanFileTVItemID,
                                                       AnalyzeMethodDefault = (AnalyzeMethodEnum)c.AnalyzeMethodDefault,
                                                       SampleMatrixDefault = (SampleMatrixEnum)c.SampleMatrixDefault,
                                                       LaboratoryDefault = (LaboratoryEnum)c.LaboratoryDefault,
                                                       BackupDirectory = c.BackupDirectory,
                                                       IsActive = c.IsActive,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                   }).FirstOrDefault<SamplingPlanModel>();

            if (SamplingPlanModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.SamplingPlan,
                    ServiceRes.SamplingPlanName,
                    SamplingPlanName));


            return SamplingPlanModel;
        }
        public SamplingPlanModel GetSamplingPlanModelWithSamplingPlanIDDB(int SamplingPlanID)
        {
            SamplingPlanModel SamplingPlanModel = (from c in db.SamplingPlans
                                                   let provinceTVText = (from p in db.TVItemLanguages where c.ProvinceTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                   let creatorTVText = (from p in db.TVItemLanguages where c.CreatorTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                   where c.SamplingPlanID == SamplingPlanID
                                                   select new SamplingPlanModel
                                                   {
                                                       Error = "",
                                                       SamplingPlanID = c.SamplingPlanID,
                                                       SamplingPlanName = c.SamplingPlanName,
                                                       ForGroupName = c.ForGroupName,
                                                       SampleType = (SampleTypeEnum)c.SampleType,
                                                       SamplingPlanType = (SamplingPlanTypeEnum)c.SamplingPlanType,
                                                       LabSheetType = (LabSheetTypeEnum)c.LabSheetType,
                                                       ProvinceTVItemID = c.ProvinceTVItemID,
                                                       ProvinceTVText = provinceTVText,
                                                       CreatorTVItemID = c.CreatorTVItemID,
                                                       CreatorTVText = creatorTVText,
                                                       Year = c.Year,
                                                       AccessCode = c.AccessCode,
                                                       DailyDuplicatePrecisionCriteria = (float)c.DailyDuplicatePrecisionCriteria,
                                                       IntertechDuplicatePrecisionCriteria = (float)c.IntertechDuplicatePrecisionCriteria,
                                                       IncludeLaboratoryQAQC = c.IncludeLaboratoryQAQC,
                                                       ApprovalCode = c.ApprovalCode,
                                                       SamplingPlanFileTVItemID = c.SamplingPlanFileTVItemID,
                                                       AnalyzeMethodDefault = (AnalyzeMethodEnum)c.AnalyzeMethodDefault,
                                                       SampleMatrixDefault = (SampleMatrixEnum)c.SampleMatrixDefault,
                                                       LaboratoryDefault = (LaboratoryEnum)c.LaboratoryDefault,
                                                       BackupDirectory = c.BackupDirectory,
                                                       IsActive = c.IsActive,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                   }).FirstOrDefault<SamplingPlanModel>();

            if (SamplingPlanModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.SamplingPlan,
                    ServiceRes.SamplingPlanID,
                    SamplingPlanID));


            return SamplingPlanModel;
        }
        public SamplingPlan GetSamplingPlanWithSamplingPlanIDDB(int SamplingPlanID)
        {
            SamplingPlan SamplingPlan = (from c in db.SamplingPlans
                                         where c.SamplingPlanID == SamplingPlanID
                                         select c).FirstOrDefault<SamplingPlan>();

            return SamplingPlan;
        }

        // Helper
        public SamplingPlanModel ReturnError(string Error)
        {
            return new SamplingPlanModel() { Error = Error };
        }
        // Post
        public SamplingPlanModel SamplingPlanSaveTopDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int TempInt = 0;
            int ProvinceTVItemID = 0;
            int SamplingPlanID = 0;
            string SamplingPlanName = "";
            string ForGroupName = "";
            SampleTypeEnum SampleType = SampleTypeEnum.Error;
            SamplingPlanTypeEnum SamplingPlanType = SamplingPlanTypeEnum.Error;
            LabSheetTypeEnum LabSheetType = LabSheetTypeEnum.Error;
            int Year = 0;
            string AccessCode = "";
            float DailyDuplicatePrecisionCriteria = 0.0f;
            float IntertechDuplicatePrecisionCriteria = 0.0f;
            bool IncludeLaboratoryQAQC = false;
            string ApprovalCode = "";
            AnalyzeMethodEnum AnalyzeMethodDefault = AnalyzeMethodEnum.Error;
            SampleMatrixEnum SampleMatrixDefault = SampleMatrixEnum.Error;
            LaboratoryEnum LaboratoryDefault = LaboratoryEnum.Error;
            string BackupDirectory = "";
            bool IsActive = false;

            int.TryParse(fc["ProvinceTVItemID"], out ProvinceTVItemID);
            if (ProvinceTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ProvinceTVItemID));

            int.TryParse(fc["SamplingPlanID"], out SamplingPlanID);
            // if 0 then want to add new SamplingPlan else want to modify

            SamplingPlanName = fc["SamplingPlanName"];
            if (string.IsNullOrWhiteSpace(SamplingPlanName))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SamplingPlanName));

            ForGroupName = fc["ForGroupName"];
            if (string.IsNullOrWhiteSpace(ForGroupName))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ForGroupName));

            int.TryParse(fc["SampleType"], out TempInt);
            if (TempInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SampleType));

            SampleType = (SampleTypeEnum)TempInt;

            int.TryParse(fc["SamplingPlanType"], out TempInt);
            if (TempInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SamplingPlanType));

            SamplingPlanType = (SamplingPlanTypeEnum)TempInt;

            int.TryParse(fc["LabSheetType"], out TempInt);
            if (TempInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.LabSheetType));

            LabSheetType = (LabSheetTypeEnum)TempInt;

            int.TryParse(fc["Year"], out Year);
            if (Year == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Year));

            AccessCode = fc["AccessCode"];
            if (string.IsNullOrWhiteSpace(AccessCode))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AccessCode));

            TempInt = 0;
            int.TryParse(fc["AnalyzeMethodDefault"], out TempInt);

            AnalyzeMethodDefault = (AnalyzeMethodEnum)TempInt;

            TempInt = 0;
            int.TryParse(fc["SampleMatrixDefault"], out TempInt);

            SampleMatrixDefault = (SampleMatrixEnum)TempInt;

            TempInt = 0;
            int.TryParse(fc["LaboratoryDefault"], out TempInt);

            LaboratoryDefault = (LaboratoryEnum)TempInt;

            BackupDirectory = fc["BackupDirectory"];
            if (string.IsNullOrWhiteSpace(BackupDirectory))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.BackupDirectory));

            if (!string.IsNullOrWhiteSpace(fc["IsActive"]))
            {
                IsActive = true;
            }

            if (!string.IsNullOrWhiteSpace(fc["IncludeLaboratoryQAQC"]))
            {
                IncludeLaboratoryQAQC = true;
            }

            if (IncludeLaboratoryQAQC)
            {
                ApprovalCode = fc["ApprovalCode"];
                if (string.IsNullOrWhiteSpace(ApprovalCode))
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ApprovalCode));

                if (string.IsNullOrWhiteSpace(fc["DailyDuplicatePrecisionCriteria"]))
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.DailyDuplicatePrecisionCriteria));

                DailyDuplicatePrecisionCriteria = float.Parse(fc["DailyDuplicatePrecisionCriteria"]);
                if (DailyDuplicatePrecisionCriteria < 0.0001)
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.DailyDuplicatePrecisionCriteria));

                if (string.IsNullOrWhiteSpace(fc["IntertechDuplicatePrecisionCriteria"]))
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.IntertechDuplicatePrecisionCriteria));

                IntertechDuplicatePrecisionCriteria = float.Parse(fc["IntertechDuplicatePrecisionCriteria"]);
                if (IntertechDuplicatePrecisionCriteria < 0.0001)
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.IntertechDuplicatePrecisionCriteria));
            }

            SamplingPlanModel SamplingPlanModelRet = new SamplingPlanModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (SamplingPlanID == 0)
                {
                    SamplingPlanModel SamplingPlanModelNew = new SamplingPlanModel()
                    {
                        ProvinceTVItemID = ProvinceTVItemID,
                        SamplingPlanName = SamplingPlanName,
                        ForGroupName = ForGroupName,
                        SampleType = SampleType,
                        SamplingPlanType = SamplingPlanType,
                        LabSheetType = LabSheetType,
                        Year = Year,
                        AccessCode = AccessCode,
                        DailyDuplicatePrecisionCriteria = DailyDuplicatePrecisionCriteria,
                        IntertechDuplicatePrecisionCriteria = IntertechDuplicatePrecisionCriteria,
                        IncludeLaboratoryQAQC = IncludeLaboratoryQAQC,
                        ApprovalCode = ApprovalCode,
                        CreatorTVItemID = contactOK.ContactTVItemID,
                        AnalyzeMethodDefault = AnalyzeMethodDefault,
                        SampleMatrixDefault = SampleMatrixDefault,
                        LaboratoryDefault = LaboratoryDefault,
                        BackupDirectory = BackupDirectory,
                        IsActive = IsActive,
                    };

                    SamplingPlanModelRet = PostAddSamplingPlanDB(SamplingPlanModelNew);
                    if (!string.IsNullOrWhiteSpace(SamplingPlanModelRet.Error))
                        ReturnError(SamplingPlanModelRet.Error);

                }
                else
                {
                    SamplingPlanModel SamplingPlanModelToUpdate = GetSamplingPlanModelWithSamplingPlanIDDB(SamplingPlanID);
                    SamplingPlanModelToUpdate.ProvinceTVItemID = ProvinceTVItemID;
                    SamplingPlanModelToUpdate.SamplingPlanName = SamplingPlanName;
                    SamplingPlanModelToUpdate.ForGroupName = ForGroupName;
                    SamplingPlanModelToUpdate.SampleType = SampleType;
                    SamplingPlanModelToUpdate.SamplingPlanType = SamplingPlanType;
                    SamplingPlanModelToUpdate.LabSheetType = LabSheetType;
                    SamplingPlanModelToUpdate.Year = Year;
                    SamplingPlanModelToUpdate.AccessCode = AccessCode;
                    SamplingPlanModelToUpdate.DailyDuplicatePrecisionCriteria = DailyDuplicatePrecisionCriteria;
                    SamplingPlanModelToUpdate.IntertechDuplicatePrecisionCriteria = IntertechDuplicatePrecisionCriteria;
                    SamplingPlanModelToUpdate.IncludeLaboratoryQAQC = IncludeLaboratoryQAQC;
                    SamplingPlanModelToUpdate.ApprovalCode = ApprovalCode;
                    SamplingPlanModelToUpdate.CreatorTVItemID = contactOK.ContactTVItemID;
                    SamplingPlanModelToUpdate.AnalyzeMethodDefault = AnalyzeMethodDefault;
                    SamplingPlanModelToUpdate.SampleMatrixDefault = SampleMatrixDefault;
                    SamplingPlanModelToUpdate.LaboratoryDefault = LaboratoryDefault;
                    SamplingPlanModelToUpdate.BackupDirectory = BackupDirectory;
                    SamplingPlanModelToUpdate.IsActive = IsActive;

                    SamplingPlanModelRet = PostUpdateSamplingPlanDB(SamplingPlanModelToUpdate);
                    if (!string.IsNullOrWhiteSpace(SamplingPlanModelRet.Error))
                        ReturnError(SamplingPlanModelRet.Error);
                }

                if (SamplingPlanModelRet.SamplingPlanFileTVItemID > 0)
                {
                    int SamplingPlanTxtTVItemID = SamplingPlanModelRet.SamplingPlanFileTVItemID ?? 0;
                    SamplingPlanModelRet = SamplingPlanDeleteFileDB(SamplingPlanModelRet.SamplingPlanID);
                    if (!string.IsNullOrWhiteSpace(SamplingPlanModelRet.Error))
                        ReturnError(SamplingPlanModelRet.Error);
                }

                ts.Complete();
            }

            return SamplingPlanModelRet;
        }
        public SamplingPlanModel SamplingPlanSubsectorSaveDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int SamplingPlanID = 0;
            int ProvinceTVItemID = 0;
            int SubsectorTVItemID = 0;

            int.TryParse(fc["SamplingPlanID"], out SamplingPlanID);
            if (SamplingPlanID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SamplingPlanID));

            int.TryParse(fc["ProvinceTVItemID"], out ProvinceTVItemID);
            if (ProvinceTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ProvinceTVItemID));

            int.TryParse(fc["SubsectorTVItemID"], out SubsectorTVItemID);
            if (SubsectorTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID));

            List<TVItemModelSubsectorAndMWQMSite> tvItemModelSubsectorAndMWQMSiteList = new List<TVItemModelSubsectorAndMWQMSite>()
            {
                new TVItemModelSubsectorAndMWQMSite()
                    {
                        TVItemModelSubsector = new TVItemModel() { TVItemID = SubsectorTVItemID },
                    }
            };
            foreach (string km in fc.AllKeys)
            {
                if (km.Substring(0, 2) == "SS" && km.Contains("_S"))
                {
                    int MWQMSiteTVItemID = int.Parse(km.Substring(km.IndexOf("_S") + 2));
                    TVItemModelSubsectorAndMWQMSite tvItemModelSubsectorAndMWQMSite = tvItemModelSubsectorAndMWQMSiteList.Where(c => c.TVItemModelSubsector.TVItemID == SubsectorTVItemID).FirstOrDefault();
                    if (tvItemModelSubsectorAndMWQMSite != null)
                    {
                        tvItemModelSubsectorAndMWQMSite.TVItemMWQMSiteList.Add(new TVItemModel() { TVItemID = MWQMSiteTVItemID });
                    }
                }
                if (km.Substring(0, 2) == "SS" && km.Contains("_D"))
                {
                    string fcDuplicate = fc["SS" + SubsectorTVItemID + "_D"];
                    if (fcDuplicate != "0")
                    {
                        tvItemModelSubsectorAndMWQMSiteList.Where(c => c.TVItemModelSubsector.TVItemID == SubsectorTVItemID).First().TVItemMWQMSiteDuplicate = new TVItemModel() { TVItemID = int.Parse(fcDuplicate) };
                    }
                }
            }
            SamplingPlanModel SamplingPlanModelRet = new SamplingPlanModel();
            using (TransactionScope ts = new TransactionScope())
            {
                SamplingPlanSubsectorModel SamplingPlanSubsectorModelToDelete = _SamplingPlanSubsectorService.GetSamplingPlanSubsectorModelWithSamplingPlanIDAndSubsectorTVItemIDDB(SamplingPlanID, SubsectorTVItemID);
                SamplingPlanSubsectorModel SamplingPlanSubsectorModelRet = _SamplingPlanSubsectorService.PostDeleteSamplingPlanSubsectorDB(SamplingPlanSubsectorModelToDelete.SamplingPlanSubsectorID);
                if (!string.IsNullOrWhiteSpace(SamplingPlanSubsectorModelRet.Error))
                    ReturnError(SamplingPlanSubsectorModelRet.Error);

                foreach (TVItemModelSubsectorAndMWQMSite tvItemModelSubsectorAndMWQMSite in tvItemModelSubsectorAndMWQMSiteList)
                {
                    SamplingPlanSubsectorModel SamplingPlanSubsectorModelNew = new SamplingPlanSubsectorModel()
                    {
                        SamplingPlanID = SamplingPlanID,
                        SubsectorTVItemID = SubsectorTVItemID,
                    };

                    SamplingPlanSubsectorModel SamplingPlanSubsectorModel = _SamplingPlanSubsectorService.PostAddSamplingPlanSubsectorDB(SamplingPlanSubsectorModelNew);
                    if (!string.IsNullOrWhiteSpace(SamplingPlanSubsectorModel.Error))
                        ReturnError(SamplingPlanSubsectorModel.Error);

                    foreach (TVItemModel tvItemModelMWQMSite in tvItemModelSubsectorAndMWQMSite.TVItemMWQMSiteList)
                    {
                        bool IsDuplicate = false;
                        if (tvItemModelSubsectorAndMWQMSite.TVItemMWQMSiteDuplicate == null)
                        {
                            IsDuplicate = false;
                        }
                        else
                        {
                            IsDuplicate = (tvItemModelSubsectorAndMWQMSite.TVItemMWQMSiteDuplicate.TVItemID == tvItemModelMWQMSite.TVItemID ? true : false);
                        }
                        SamplingPlanSubsectorSiteModel SamplingPlanSubsectorSiteModelNew = new SamplingPlanSubsectorSiteModel()
                        {
                            IsDuplicate = IsDuplicate,
                            SamplingPlanSubsectorID = SamplingPlanSubsectorModel.SamplingPlanSubsectorID,
                            MWQMSiteTVItemID = tvItemModelMWQMSite.TVItemID,
                        };

                        SamplingPlanSubsectorSiteModel SamplingPlanSubsectorSiteModelRet = _SamplingPlanSubsectorSiteService.PostAddSamplingPlanSubsectorSiteDB(SamplingPlanSubsectorSiteModelNew);
                        if (!string.IsNullOrWhiteSpace(SamplingPlanSubsectorSiteModelRet.Error))
                            ReturnError(SamplingPlanSubsectorSiteModelRet.Error);

                    }
                }

                SamplingPlanModelRet = GetSamplingPlanModelWithSamplingPlanIDDB(SamplingPlanID);
                if (!string.IsNullOrWhiteSpace(SamplingPlanModelRet.Error))
                    ReturnError(SamplingPlanModelRet.Error);

                if (SamplingPlanModelRet.SamplingPlanFileTVItemID > 0)
                {
                    int SamplingPlanTxtTVItemID = SamplingPlanModelRet.SamplingPlanFileTVItemID ?? 0;
                    SamplingPlanModelRet = SamplingPlanDeleteFileDB(SamplingPlanModelRet.SamplingPlanID);
                    if (!string.IsNullOrWhiteSpace(SamplingPlanModelRet.Error))
                        ReturnError(SamplingPlanModelRet.Error);
                }

                ts.Complete();
            }

            return SamplingPlanModelRet;
        }
        public SamplingPlanModel SamplingPlanCopyDB(int SamplingPlanID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlanModel SamplingPlanModel = GetSamplingPlanModelWithSamplingPlanIDDB(SamplingPlanID);
            if (!string.IsNullOrWhiteSpace(SamplingPlanModel.Error))
                return ReturnError(SamplingPlanModel.Error);

            SamplingPlanModel SamplingPlanModelRet = new SamplingPlanModel();
            using (TransactionScope ts = new TransactionScope())
            {
                SamplingPlanModel SamplingPlanModelNew = new SamplingPlanModel()
                {
                    ProvinceTVItemID = SamplingPlanModel.ProvinceTVItemID,
                    SamplingPlanName = ServiceRes.CopyOf + "_" + SamplingPlanModel.SamplingPlanName,
                    ForGroupName = ServiceRes.CopyOf + "_" + SamplingPlanModel.ForGroupName,
                    SampleType = SamplingPlanModel.SampleType,
                    SamplingPlanType = SamplingPlanModel.SamplingPlanType,
                    LabSheetType = SamplingPlanModel.LabSheetType,
                    Year = SamplingPlanModel.Year,
                    AccessCode = SamplingPlanModel.AccessCode,
                    DailyDuplicatePrecisionCriteria = SamplingPlanModel.DailyDuplicatePrecisionCriteria,
                    IntertechDuplicatePrecisionCriteria = SamplingPlanModel.IntertechDuplicatePrecisionCriteria,
                    IncludeLaboratoryQAQC = SamplingPlanModel.IncludeLaboratoryQAQC,
                    ApprovalCode = SamplingPlanModel.ApprovalCode,
                    CreatorTVItemID = contactOK.ContactTVItemID,
                    SamplingPlanFileTVItemID = null,
                    AnalyzeMethodDefault = AnalyzeMethodEnum.Error,
                    SampleMatrixDefault = SampleMatrixEnum.Error,
                    LaboratoryDefault = LaboratoryEnum.Error,
                    BackupDirectory = SamplingPlanModel.BackupDirectory,
                    IsActive = SamplingPlanModel.IsActive,
                };

                SamplingPlanModelRet = PostAddSamplingPlanDB(SamplingPlanModelNew);
                if (!string.IsNullOrWhiteSpace(SamplingPlanModelRet.Error))
                    ReturnError(SamplingPlanModelRet.Error);

                List<SamplingPlanSubsectorModel> SamplingPlanSubsectorModelList = _SamplingPlanSubsectorService.GetSamplingPlanSubsectorModelListWithSamplingPlanIDDB(SamplingPlanID);

                foreach (SamplingPlanSubsectorModel SamplingPlanSubsectorModel in SamplingPlanSubsectorModelList)
                {
                    SamplingPlanSubsectorModel SamplingPlanSubsectorModelNew = new SamplingPlanSubsectorModel()
                    {
                        SamplingPlanID = SamplingPlanModelRet.SamplingPlanID,
                        SubsectorTVItemID = SamplingPlanSubsectorModel.SubsectorTVItemID,
                    };

                    SamplingPlanSubsectorModel SamplingPlanSubsectorModelRet = _SamplingPlanSubsectorService.PostAddSamplingPlanSubsectorDB(SamplingPlanSubsectorModelNew);
                    if (!string.IsNullOrWhiteSpace(SamplingPlanSubsectorModelRet.Error))
                        ReturnError(SamplingPlanSubsectorModelRet.Error);

                    List<SamplingPlanSubsectorSiteModel> SamplingPlanSubsectorSiteModelList = _SamplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteModelListWithSamplingPlanSubsectorIDDB(SamplingPlanSubsectorModel.SamplingPlanSubsectorID);

                    foreach (SamplingPlanSubsectorSiteModel SamplingPlanSubsectorSiteModel in SamplingPlanSubsectorSiteModelList)
                    {
                        SamplingPlanSubsectorSiteModel SamplingPlanSubsectorSiteModelNew = new SamplingPlanSubsectorSiteModel()
                        {
                            IsDuplicate = SamplingPlanSubsectorSiteModel.IsDuplicate,
                            SamplingPlanSubsectorID = SamplingPlanSubsectorModelRet.SamplingPlanSubsectorID,
                            MWQMSiteTVItemID = SamplingPlanSubsectorSiteModel.MWQMSiteTVItemID,
                        };

                        SamplingPlanSubsectorSiteModel SamplingPlanSubsectorSiteModelRet = _SamplingPlanSubsectorSiteService.PostAddSamplingPlanSubsectorSiteDB(SamplingPlanSubsectorSiteModelNew);
                        if (!string.IsNullOrWhiteSpace(SamplingPlanSubsectorSiteModelRet.Error))
                            ReturnError(SamplingPlanSubsectorSiteModelRet.Error);

                    }
                }

                List<SamplingPlanEmailModel> SamplingPlanEmailModelList = _SamplingPlanEmailService.GetSamplingPlanEmailModelListWithSamplingPlanIDDB(SamplingPlanID);

                foreach (SamplingPlanEmailModel SamplingPlanEmailModel in SamplingPlanEmailModelList)
                {
                    SamplingPlanEmailModel SamplingPlanEmailModelNew = new SamplingPlanEmailModel()
                    {
                        SamplingPlanID = SamplingPlanModelRet.SamplingPlanID,
                        Email = SamplingPlanEmailModel.Email,
                        LabSheetHasValueOver500 = SamplingPlanEmailModel.LabSheetHasValueOver500,
                        LabSheetReceived = SamplingPlanEmailModel.LabSheetReceived,
                        LabSheetAccepted = SamplingPlanEmailModel.LabSheetAccepted,
                        LabSheetRejected = SamplingPlanEmailModel.LabSheetRejected,
                    };

                    SamplingPlanEmailModel SamplingPlanEmailModelRet = _SamplingPlanEmailService.PostAddSamplingPlanEmailDB(SamplingPlanEmailModelNew);
                    if (!string.IsNullOrWhiteSpace(SamplingPlanEmailModelRet.Error))
                        ReturnError(SamplingPlanEmailModelRet.Error);
                }

                ts.Complete();
            }

            return SamplingPlanModelRet;
        }
        public SamplingPlanModel SamplingPlanDeleteFileDB(int SamplingPlanID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlanModel SamplingPlanModel = GetSamplingPlanModelWithSamplingPlanIDDB(SamplingPlanID);
            if (!string.IsNullOrWhiteSpace(SamplingPlanModel.Error))
                return ReturnError(SamplingPlanModel.Error);

            using (TransactionScope ts = new TransactionScope())
            {
                int SamplingPlanTxtTVItemID = SamplingPlanModel.SamplingPlanFileTVItemID ?? 0;

                if (SamplingPlanTxtTVItemID > 0)
                {
                    SamplingPlanModel.SamplingPlanFileTVItemID = null;

                    SamplingPlanModel = PostUpdateSamplingPlanDB(SamplingPlanModel);
                    if (!string.IsNullOrWhiteSpace(SamplingPlanModel.Error))
                        return ReturnError(SamplingPlanModel.Error);

                    TVFileModel tvFileModel = _TVFileService.PostDeleteTVFileWithTVItemIDDB(SamplingPlanTxtTVItemID);
                    if (!string.IsNullOrWhiteSpace(tvFileModel.Error))
                        return ReturnError(tvFileModel.Error);
                }

                ts.Complete();
            }

            return SamplingPlanModel;
        }
        public string SamplingPlanGenerateSamplingPlanDB(int SamplingPlanID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            SamplingPlanModel SamplingPlanModel = GetSamplingPlanModelWithSamplingPlanIDDB(SamplingPlanID);
            if (!string.IsNullOrWhiteSpace(SamplingPlanModel.Error))
                return SamplingPlanModel.Error;

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(SamplingPlanModel.ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            string ServerFilePath = _TVFileService.GetServerFilePath(SamplingPlanModel.ProvinceTVItemID);
            if (string.IsNullOrWhiteSpace(ServerFilePath))
                return ServiceRes.ServerFilePathIsEmpty;

            DirectoryInfo di = new DirectoryInfo(ServerFilePath);
            if (!di.Exists)
                di.Create();

            if (string.IsNullOrWhiteSpace(SamplingPlanModel.SamplingPlanName))
                return string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.SamplingPlanName);

            string FileName = "";
            AppTaskCommandEnum appTaskCommand = AppTaskCommandEnum.Error;
            FileName = SamplingPlanModel.SamplingPlanName;
            appTaskCommand = AppTaskCommandEnum.CreateSamplingPlanSamplingPlanTextFile;

            if (FileName == "")
                return ServiceRes.CouldNotGenerateFileName;

            FileInfo fi = new FileInfo(ServerFilePath + FileName.Replace("C:\\CSSPLabSheets\\", ""));
            if (_TVFileService.GetFileExist(fi))
                return string.Format(ServiceRes.File_AlreadyExist, fi.Name);

            List<string> allowableFileGeneratedTypeList = _TVFileService.GetAllowableFileGeneratedType();
            if (allowableFileGeneratedTypeList.Count == 0)
                return ServiceRes.AllowableFileGeneratedTypeListCountZero;

            if (!_TVFileService.IsAllowableFileGeneratedType(fi, allowableFileGeneratedTypeList))
                return string.Format(ServiceRes.FileType_IsNotAllowed, fi.Extension);

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(SamplingPlanModel.ProvinceTVItemID, SamplingPlanModel.ProvinceTVItemID, appTaskCommand);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "TVItemID", Value = SamplingPlanModel.ProvinceTVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "SamplingPlanID", Value = SamplingPlanModel.SamplingPlanID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "FileName", Value = FileName });

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
                TVItemID = SamplingPlanModel.ProvinceTVItemID,
                TVItemID2 = SamplingPlanModel.ProvinceTVItemID,
                AppTaskCommand = appTaskCommand,
                ErrorText = "",
                StatusText = string.Format(ServiceRes.CreatingFile_, FileName),
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
        public SamplingPlanModel PostAddSamplingPlanDB(SamplingPlanModel SamplingPlanModel)
        {
            string retStr = SamplingPlanModelOK(SamplingPlanModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlanModel SamplingPlanModelExist = GetSamplingPlanModelExistDB(SamplingPlanModel);
            if (string.IsNullOrWhiteSpace(SamplingPlanModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.SamplingPlan));

            SamplingPlan SamplingPlanNew = new SamplingPlan();
            retStr = FillSamplingPlan(SamplingPlanNew, SamplingPlanModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.SamplingPlans.Add(SamplingPlanNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SamplingPlans", SamplingPlanNew.SamplingPlanID, LogCommandEnum.Add, SamplingPlanNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetSamplingPlanModelWithSamplingPlanIDDB(SamplingPlanNew.SamplingPlanID);
        }
        public SamplingPlanModel PostDeleteSamplingPlanDB(int SamplingPlanID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlan SamplingPlanToDelete = GetSamplingPlanWithSamplingPlanIDDB(SamplingPlanID);
            if (SamplingPlanToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.SamplingPlan));

            using (TransactionScope ts = new TransactionScope())
            {
                db.SamplingPlans.Remove(SamplingPlanToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SamplingPlans", SamplingPlanToDelete.SamplingPlanID, LogCommandEnum.Delete, SamplingPlanToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public SamplingPlanModel PostUpdateSamplingPlanDB(SamplingPlanModel SamplingPlanModel)
        {
            string retStr = SamplingPlanModelOK(SamplingPlanModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlan SamplingPlanToUpdate = GetSamplingPlanWithSamplingPlanIDDB(SamplingPlanModel.SamplingPlanID);
            if (SamplingPlanToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.SamplingPlan));

            retStr = FillSamplingPlan(SamplingPlanToUpdate, SamplingPlanModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SamplingPlans", SamplingPlanToUpdate.SamplingPlanID, LogCommandEnum.Change, SamplingPlanToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetSamplingPlanModelWithSamplingPlanIDDB(SamplingPlanToUpdate.SamplingPlanID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
