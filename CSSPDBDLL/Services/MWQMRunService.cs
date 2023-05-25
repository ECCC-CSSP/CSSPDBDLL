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
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;

namespace CSSPDBDLL.Services
{
    public class MWQMRunService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public MWQMRunLanguageService _MWQMRunLanguageService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public MWQMRunService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _MWQMRunLanguageService = new MWQMRunLanguageService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
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
        public string MWQMRunModelOK(MWQMRunModel mwqmRunModel)
        {
            string retStr = FieldCheckNotZeroInt(mwqmRunModel.SubsectorTVItemID, ServiceRes.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(mwqmRunModel.MWQMRunTVItemID, ServiceRes.MWQMRunTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.SampleTypeOK(mwqmRunModel.RunSampleType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(mwqmRunModel.DateTime_Local, ServiceRes.DateTime_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmRunModel.RunNumber, ServiceRes.RunNumber, 1, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (mwqmRunModel.StartDateTime_Local != null && mwqmRunModel.EndDateTime_Local != null)
            {
                if (mwqmRunModel.StartDateTime_Local > mwqmRunModel.EndDateTime_Local)
                {
                    return string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDateAndTime_Local, ServiceRes.EndDateAndTime_Local);
                }
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.TemperatureControl1_C, ServiceRes.TemperatureControl1_C, -45, 45);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.TemperatureControl2_C, ServiceRes.TemperatureControl2_C, -45, 45);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.BeaufortScaleOK(mwqmRunModel.SeaStateAtStart_BeaufortScale);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.BeaufortScaleOK(mwqmRunModel.SeaStateAtEnd_BeaufortScale);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.WaterLevelAtBrook_m, ServiceRes.WaterLevelAtBrook_m, -5, 40);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.WaveHightAtStart_m, ServiceRes.WaveHightAtStart_m, 0, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.WaveHightAtEnd_m, ServiceRes.WaveHightAtEnd_m, 0, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(mwqmRunModel.SampleCrewInitials, ServiceRes.SampleCrewInitials, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.AnalyzeMethodOK(mwqmRunModel.AnalyzeMethod);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.SampleMatrixOK(mwqmRunModel.SampleMatrix);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LaboratoryOK(mwqmRunModel.Laboratory);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.SampleStatusOK(mwqmRunModel.SampleStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(mwqmRunModel.LabSampleApprovalContactTVItemID, ServiceRes.LabSampleApprovalContactTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.RainDay0_mm, ServiceRes.RainDay0_mm, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }


            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.RainDay1_mm, ServiceRes.RainDay1_mm, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.RainDay2_mm, ServiceRes.RainDay2_mm, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.RainDay3_mm, ServiceRes.RainDay3_mm, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.RainDay4_mm, ServiceRes.RainDay4_mm, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.RainDay5_mm, ServiceRes.RainDay5_mm, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.RainDay6_mm, ServiceRes.RainDay6_mm, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.RainDay7_mm, ServiceRes.RainDay7_mm, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.RainDay8_mm, ServiceRes.RainDay8_mm, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.RainDay9_mm, ServiceRes.RainDay9_mm, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.RainDay10_mm, ServiceRes.RainDay10_mm, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h0_m, ServiceRes.Tide_h0_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h1_m, ServiceRes.Tide_h1_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h2_m, ServiceRes.Tide_h2_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h3_m, ServiceRes.Tide_h3_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h4_m, ServiceRes.Tide_h4_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h5_m, ServiceRes.Tide_h5_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h6_m, ServiceRes.Tide_h6_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h7_m, ServiceRes.Tide_h7_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h8_m, ServiceRes.Tide_h8_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h9_m, ServiceRes.Tide_h9_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h10_m, ServiceRes.Tide_h10_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h11_m, ServiceRes.Tide_h11_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h12_m, ServiceRes.Tide_h12_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h13_m, ServiceRes.Tide_h13_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h14_m, ServiceRes.Tide_h14_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h15_m, ServiceRes.Tide_h15_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h16_m, ServiceRes.Tide_h16_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h17_m, ServiceRes.Tide_h17_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h18_m, ServiceRes.Tide_h18_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h19_m, ServiceRes.Tide_h19_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h20_m, ServiceRes.Tide_h20_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h21_m, ServiceRes.Tide_h21_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h22_m, ServiceRes.Tide_h22_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h23_m, ServiceRes.Tide_h23_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h24_m, ServiceRes.Tide_h24_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h25_m, ServiceRes.Tide_h25_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h26_m, ServiceRes.Tide_h26_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h27_m, ServiceRes.Tide_h27_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h28_m, ServiceRes.Tide_h28_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h29_m, ServiceRes.Tide_h29_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmRunModel.Tide_h30_m, ServiceRes.Tide_h30_m, -20, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(mwqmRunModel.RunComment, ServiceRes.RunComment, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(mwqmRunModel.RunWeatherComment, ServiceRes.RunWeatherComment, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(mwqmRunModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMWQMRun(MWQMRun mwqmRun, MWQMRunModel mwqmRunModel, ContactOK contactOK)
        {
            mwqmRun.DBCommand = (int)mwqmRunModel.DBCommand;
            mwqmRun.SubsectorTVItemID = mwqmRunModel.SubsectorTVItemID;
            mwqmRun.MWQMRunTVItemID = mwqmRunModel.MWQMRunTVItemID;
            mwqmRun.RunSampleType = (int)mwqmRunModel.RunSampleType;
            mwqmRun.DateTime_Local = mwqmRunModel.DateTime_Local;
            mwqmRun.RunNumber = mwqmRunModel.RunNumber;
            mwqmRun.StartDateTime_Local = mwqmRunModel.StartDateTime_Local;
            mwqmRun.EndDateTime_Local = mwqmRunModel.EndDateTime_Local;
            mwqmRun.LabReceivedDateTime_Local = mwqmRunModel.LabReceivedDateTime_Local;
            mwqmRun.TemperatureControl1_C = mwqmRunModel.TemperatureControl1_C;
            mwqmRun.TemperatureControl2_C = mwqmRunModel.TemperatureControl2_C;
            mwqmRun.SeaStateAtStart_BeaufortScale = (int?)mwqmRunModel.SeaStateAtStart_BeaufortScale;
            mwqmRun.SeaStateAtEnd_BeaufortScale = (int?)mwqmRunModel.SeaStateAtEnd_BeaufortScale;
            mwqmRun.WaterLevelAtBrook_m = mwqmRunModel.WaterLevelAtBrook_m;
            mwqmRun.WaveHightAtEnd_m = mwqmRunModel.WaveHightAtEnd_m;
            mwqmRun.WaveHightAtStart_m = mwqmRunModel.WaveHightAtStart_m;
            mwqmRun.SampleCrewInitials = mwqmRunModel.SampleCrewInitials;
            mwqmRun.AnalyzeMethod = (int?)mwqmRunModel.AnalyzeMethod;
            mwqmRun.SampleMatrix = (int?)mwqmRunModel.SampleMatrix;
            mwqmRun.Laboratory = (int?)mwqmRunModel.Laboratory;
            mwqmRun.SampleStatus = (int?)mwqmRunModel.SampleStatus;
            mwqmRun.LabSampleApprovalContactTVItemID = mwqmRunModel.LabSampleApprovalContactTVItemID;
            mwqmRun.LabAnalyzeBath1IncubationStartDateTime_Local = mwqmRunModel.LabAnalyzeBath1IncubationStartDateTime_Local;
            mwqmRun.LabAnalyzeBath2IncubationStartDateTime_Local = mwqmRunModel.LabAnalyzeBath2IncubationStartDateTime_Local;
            mwqmRun.LabAnalyzeBath3IncubationStartDateTime_Local = mwqmRunModel.LabAnalyzeBath3IncubationStartDateTime_Local;
            mwqmRun.LabRunSampleApprovalDateTime_Local = mwqmRunModel.LabRunSampleApprovalDateTime_Local;
            mwqmRun.Tide_Start = (int?)mwqmRunModel.Tide_Start;
            mwqmRun.Tide_End = (int?)mwqmRunModel.Tide_End;
            mwqmRun.RainDay0_mm = mwqmRunModel.RainDay0_mm;
            mwqmRun.RainDay1_mm = mwqmRunModel.RainDay1_mm;
            mwqmRun.RainDay2_mm = mwqmRunModel.RainDay2_mm;
            mwqmRun.RainDay3_mm = mwqmRunModel.RainDay3_mm;
            mwqmRun.RainDay4_mm = mwqmRunModel.RainDay4_mm;
            mwqmRun.RainDay5_mm = mwqmRunModel.RainDay5_mm;
            mwqmRun.RainDay6_mm = mwqmRunModel.RainDay6_mm;
            mwqmRun.RainDay7_mm = mwqmRunModel.RainDay7_mm;
            mwqmRun.RainDay8_mm = mwqmRunModel.RainDay8_mm;
            mwqmRun.RainDay9_mm = mwqmRunModel.RainDay9_mm;
            mwqmRun.RainDay10_mm = mwqmRunModel.RainDay10_mm;
            mwqmRun.Tide_h0_m = mwqmRunModel.Tide_h0_m;
            mwqmRun.Tide_h1_m = mwqmRunModel.Tide_h1_m;
            mwqmRun.Tide_h2_m = mwqmRunModel.Tide_h2_m;
            mwqmRun.Tide_h3_m = mwqmRunModel.Tide_h3_m;
            mwqmRun.Tide_h4_m = mwqmRunModel.Tide_h4_m;
            mwqmRun.Tide_h5_m = mwqmRunModel.Tide_h5_m;
            mwqmRun.Tide_h6_m = mwqmRunModel.Tide_h6_m;
            mwqmRun.Tide_h7_m = mwqmRunModel.Tide_h7_m;
            mwqmRun.Tide_h8_m = mwqmRunModel.Tide_h8_m;
            mwqmRun.Tide_h9_m = mwqmRunModel.Tide_h9_m;
            mwqmRun.Tide_h10_m = mwqmRunModel.Tide_h10_m;
            mwqmRun.Tide_h11_m = mwqmRunModel.Tide_h11_m;
            mwqmRun.Tide_h12_m = mwqmRunModel.Tide_h12_m;
            mwqmRun.Tide_h13_m = mwqmRunModel.Tide_h13_m;
            mwqmRun.Tide_h14_m = mwqmRunModel.Tide_h14_m;
            mwqmRun.Tide_h15_m = mwqmRunModel.Tide_h15_m;
            mwqmRun.Tide_h16_m = mwqmRunModel.Tide_h16_m;
            mwqmRun.Tide_h17_m = mwqmRunModel.Tide_h17_m;
            mwqmRun.Tide_h18_m = mwqmRunModel.Tide_h18_m;
            mwqmRun.Tide_h19_m = mwqmRunModel.Tide_h19_m;
            mwqmRun.Tide_h20_m = mwqmRunModel.Tide_h20_m;
            mwqmRun.Tide_h21_m = mwqmRunModel.Tide_h21_m;
            mwqmRun.Tide_h22_m = mwqmRunModel.Tide_h22_m;
            mwqmRun.Tide_h23_m = mwqmRunModel.Tide_h23_m;
            mwqmRun.Tide_h24_m = mwqmRunModel.Tide_h24_m;
            mwqmRun.Tide_h25_m = mwqmRunModel.Tide_h25_m;
            mwqmRun.Tide_h26_m = mwqmRunModel.Tide_h26_m;
            mwqmRun.Tide_h27_m = mwqmRunModel.Tide_h27_m;
            mwqmRun.Tide_h28_m = mwqmRunModel.Tide_h28_m;
            mwqmRun.Tide_h29_m = mwqmRunModel.Tide_h29_m;
            mwqmRun.Tide_h30_m = mwqmRunModel.Tide_h30_m;
            mwqmRun.RemoveFromStat = mwqmRunModel.RemoveFromStat;
            mwqmRun.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mwqmRun.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mwqmRun.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public List<LabSheetModel> GetLabSheetModelListWithMWQMRunTVItemIDDB(int MWQMRunTVItemID)
        {
            LabSheetService labSheetService = new LabSheetService(LanguageRequest, User);
            List<LabSheetModel> labSheetModelList = labSheetService.GetLabSheetModelListWithMWQMRunTVItemIDDB(MWQMRunTVItemID);

            return labSheetModelList;
        }
        public int GetMWQMRunModelCountDB()
        {
            int MWQMRunModelCount = (from c in db.MWQMRuns
                                     select c).Count();

            return MWQMRunModelCount;
        }
        public MWQMRunModel GetMWQMRunModelLastWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            MWQMRunModel mwqmRunModel = (from c in db.MWQMRuns
                                         let mwqmSubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                         let mwqmMWQMRunName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                         let runComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunComment).FirstOrDefault<string>()
                                         let runWeatherComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunWeatherComment).FirstOrDefault<string>()
                                         where c.SubsectorTVItemID == SubsectorTVItemID
                                         orderby c.DateTime_Local descending
                                         select new MWQMRunModel
                                         {
                                             Error = "",
                                             MWQMRunID = c.MWQMRunID,
                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                             SubsectorTVItemID = c.SubsectorTVItemID,
                                             SubsectorTVText = mwqmSubsectorName,
                                             MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                             MWQMRunTVText = mwqmMWQMRunName,
                                             RunSampleType = (SampleTypeEnum)c.RunSampleType,
                                             DateTime_Local = c.DateTime_Local,
                                             RunNumber = c.RunNumber,
                                             StartDateTime_Local = c.StartDateTime_Local,
                                             EndDateTime_Local = c.EndDateTime_Local,
                                             LabReceivedDateTime_Local = c.LabReceivedDateTime_Local,
                                             TemperatureControl1_C = c.TemperatureControl1_C,
                                             TemperatureControl2_C = c.TemperatureControl2_C,
                                             SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtStart_BeaufortScale,
                                             SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtEnd_BeaufortScale,
                                             WaterLevelAtBrook_m = c.WaterLevelAtBrook_m,
                                             WaveHightAtEnd_m = c.WaveHightAtEnd_m,
                                             WaveHightAtStart_m = c.WaveHightAtStart_m,
                                             SampleCrewInitials = c.SampleCrewInitials,
                                             AnalyzeMethod = (AnalyzeMethodEnum)c.AnalyzeMethod,
                                             SampleMatrix = (SampleMatrixEnum)c.SampleMatrix,
                                             Laboratory = (LaboratoryEnum)c.Laboratory,
                                             SampleStatus = (SampleStatusEnum)c.SampleStatus,
                                             LabSampleApprovalContactTVItemID = c.LabSampleApprovalContactTVItemID,
                                             LabAnalyzeBath1IncubationStartDateTime_Local = c.LabAnalyzeBath1IncubationStartDateTime_Local,
                                             LabAnalyzeBath2IncubationStartDateTime_Local = c.LabAnalyzeBath2IncubationStartDateTime_Local,
                                             LabAnalyzeBath3IncubationStartDateTime_Local = c.LabAnalyzeBath3IncubationStartDateTime_Local,
                                             LabRunSampleApprovalDateTime_Local = c.LabRunSampleApprovalDateTime_Local,
                                             Tide_Start = (TideTextEnum)c.Tide_Start,
                                             Tide_End = (TideTextEnum)c.Tide_End,
                                             RainDay0_mm = c.RainDay0_mm,
                                             RainDay1_mm = c.RainDay1_mm,
                                             RainDay2_mm = c.RainDay2_mm,
                                             RainDay3_mm = c.RainDay3_mm,
                                             RainDay4_mm = c.RainDay4_mm,
                                             RainDay5_mm = c.RainDay5_mm,
                                             RainDay6_mm = c.RainDay6_mm,
                                             RainDay7_mm = c.RainDay7_mm,
                                             RainDay8_mm = c.RainDay8_mm,
                                             RainDay9_mm = c.RainDay9_mm,
                                             RainDay10_mm = c.RainDay10_mm,
                                             Tide_h0_m = c.Tide_h0_m,
                                             Tide_h1_m = c.Tide_h1_m,
                                             Tide_h2_m = c.Tide_h2_m,
                                             Tide_h3_m = c.Tide_h3_m,
                                             Tide_h4_m = c.Tide_h4_m,
                                             Tide_h5_m = c.Tide_h5_m,
                                             Tide_h6_m = c.Tide_h6_m,
                                             Tide_h7_m = c.Tide_h7_m,
                                             Tide_h8_m = c.Tide_h8_m,
                                             Tide_h9_m = c.Tide_h9_m,
                                             Tide_h10_m = c.Tide_h10_m,
                                             Tide_h11_m = c.Tide_h11_m,
                                             Tide_h12_m = c.Tide_h12_m,
                                             Tide_h13_m = c.Tide_h13_m,
                                             Tide_h14_m = c.Tide_h14_m,
                                             Tide_h15_m = c.Tide_h15_m,
                                             Tide_h16_m = c.Tide_h16_m,
                                             Tide_h17_m = c.Tide_h17_m,
                                             Tide_h18_m = c.Tide_h18_m,
                                             Tide_h19_m = c.Tide_h19_m,
                                             Tide_h20_m = c.Tide_h20_m,
                                             Tide_h21_m = c.Tide_h21_m,
                                             Tide_h22_m = c.Tide_h22_m,
                                             Tide_h23_m = c.Tide_h23_m,
                                             Tide_h24_m = c.Tide_h24_m,
                                             Tide_h25_m = c.Tide_h25_m,
                                             Tide_h26_m = c.Tide_h26_m,
                                             Tide_h27_m = c.Tide_h27_m,
                                             Tide_h28_m = c.Tide_h28_m,
                                             Tide_h29_m = c.Tide_h29_m,
                                             Tide_h30_m = c.Tide_h30_m,
                                             RemoveFromStat = c.RemoveFromStat,
                                             RunComment = runComment,
                                             RunWeatherComment = runWeatherComment,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         }).FirstOrDefault<MWQMRunModel>();

            if (mwqmRunModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMRun, ServiceRes.SubsectorTVItemID, SubsectorTVItemID.ToString()));

            return mwqmRunModel;
        }
        public List<MWQMRunModel> GetMWQMRunModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<MWQMRunModel> mwqmRunModelList = (from c in db.MWQMRuns
                                                   let mwqmSubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                   let mwqmMWQMRunName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                                   let runComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunComment).FirstOrDefault<string>()
                                                   let runWeatherComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunWeatherComment).FirstOrDefault<string>()
                                                   where c.SubsectorTVItemID == SubsectorTVItemID
                                                   orderby c.MWQMRunID descending
                                                   select new MWQMRunModel
                                                   {
                                                       Error = "",
                                                       MWQMRunID = c.MWQMRunID,
                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                       RunComment = runComment,
                                                       RunWeatherComment = runWeatherComment,
                                                       SubsectorTVItemID = c.SubsectorTVItemID,
                                                       SubsectorTVText = mwqmSubsectorName,
                                                       MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                                       MWQMRunTVText = mwqmMWQMRunName,
                                                       RunSampleType = (SampleTypeEnum)c.RunSampleType,
                                                       AnalyzeMethod = (AnalyzeMethodEnum)c.AnalyzeMethod,
                                                       DateTime_Local = c.DateTime_Local,
                                                       RunNumber = c.RunNumber,
                                                       EndDateTime_Local = c.EndDateTime_Local,
                                                       LabAnalyzeBath1IncubationStartDateTime_Local = c.LabAnalyzeBath1IncubationStartDateTime_Local,
                                                       LabAnalyzeBath2IncubationStartDateTime_Local = c.LabAnalyzeBath2IncubationStartDateTime_Local,
                                                       LabAnalyzeBath3IncubationStartDateTime_Local = c.LabAnalyzeBath3IncubationStartDateTime_Local,
                                                       LabReceivedDateTime_Local = c.LabReceivedDateTime_Local,
                                                       Laboratory = (LaboratoryEnum)c.Laboratory,
                                                       SampleMatrix = (SampleMatrixEnum)c.SampleMatrix,
                                                       Tide_Start = (TideTextEnum)c.Tide_Start,
                                                       Tide_End = (TideTextEnum)c.Tide_End,
                                                       RainDay0_mm = c.RainDay0_mm,
                                                       RainDay1_mm = c.RainDay1_mm,
                                                       RainDay2_mm = c.RainDay2_mm,
                                                       RainDay3_mm = c.RainDay3_mm,
                                                       RainDay4_mm = c.RainDay4_mm,
                                                       RainDay5_mm = c.RainDay5_mm,
                                                       RainDay6_mm = c.RainDay6_mm,
                                                       RainDay7_mm = c.RainDay7_mm,
                                                       RainDay8_mm = c.RainDay8_mm,
                                                       RainDay9_mm = c.RainDay9_mm,
                                                       RainDay10_mm = c.RainDay10_mm,
                                                       Tide_h0_m = c.Tide_h0_m,
                                                       Tide_h1_m = c.Tide_h1_m,
                                                       Tide_h2_m = c.Tide_h2_m,
                                                       Tide_h3_m = c.Tide_h3_m,
                                                       Tide_h4_m = c.Tide_h4_m,
                                                       Tide_h5_m = c.Tide_h5_m,
                                                       Tide_h6_m = c.Tide_h6_m,
                                                       Tide_h7_m = c.Tide_h7_m,
                                                       Tide_h8_m = c.Tide_h8_m,
                                                       Tide_h9_m = c.Tide_h9_m,
                                                       Tide_h10_m = c.Tide_h10_m,
                                                       Tide_h11_m = c.Tide_h11_m,
                                                       Tide_h12_m = c.Tide_h12_m,
                                                       Tide_h13_m = c.Tide_h13_m,
                                                       Tide_h14_m = c.Tide_h14_m,
                                                       Tide_h15_m = c.Tide_h15_m,
                                                       Tide_h16_m = c.Tide_h16_m,
                                                       Tide_h17_m = c.Tide_h17_m,
                                                       Tide_h18_m = c.Tide_h18_m,
                                                       Tide_h19_m = c.Tide_h19_m,
                                                       Tide_h20_m = c.Tide_h20_m,
                                                       Tide_h21_m = c.Tide_h21_m,
                                                       Tide_h22_m = c.Tide_h22_m,
                                                       Tide_h23_m = c.Tide_h23_m,
                                                       Tide_h24_m = c.Tide_h24_m,
                                                       Tide_h25_m = c.Tide_h25_m,
                                                       Tide_h26_m = c.Tide_h26_m,
                                                       Tide_h27_m = c.Tide_h27_m,
                                                       Tide_h28_m = c.Tide_h28_m,
                                                       Tide_h29_m = c.Tide_h29_m,
                                                       Tide_h30_m = c.Tide_h30_m,
                                                       RemoveFromStat = c.RemoveFromStat,
                                                       SampleCrewInitials = c.SampleCrewInitials,
                                                       SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtEnd_BeaufortScale,
                                                       SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtStart_BeaufortScale,
                                                       StartDateTime_Local = c.StartDateTime_Local,
                                                       SampleStatus = (SampleStatusEnum)c.SampleStatus,
                                                       TemperatureControl1_C = c.TemperatureControl1_C,
                                                       TemperatureControl2_C = c.TemperatureControl2_C,
                                                       LabRunSampleApprovalDateTime_Local = c.LabRunSampleApprovalDateTime_Local,
                                                       LabSampleApprovalContactTVItemID = c.LabSampleApprovalContactTVItemID,
                                                       WaterLevelAtBrook_m = c.WaterLevelAtBrook_m,
                                                       WaveHightAtEnd_m = c.WaveHightAtEnd_m,
                                                       WaveHightAtStart_m = c.WaveHightAtStart_m,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                   }).ToList<MWQMRunModel>();

            return mwqmRunModelList;
        }
        public List<MWQMRunModel> GetMWQMRunModelWithSubsectorTVItemIDAndRunDateDB(int SubsectorTVItemID, DateTime RunDate)
        {
            List<MWQMRunModel> mwqmRunModelList = (from c in db.MWQMRuns
                                                   let mwqmSubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                   let mwqmMWQMRunName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                                   let runComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunComment).FirstOrDefault<string>()
                                                   let runWeatherComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunWeatherComment).FirstOrDefault<string>()
                                                   where c.SubsectorTVItemID == SubsectorTVItemID
                                                   && c.DateTime_Local.Year == RunDate.Year
                                                   && c.DateTime_Local.Month == RunDate.Month
                                                   && c.DateTime_Local.Day == RunDate.Day
                                                   orderby c.MWQMRunID descending
                                                   select new MWQMRunModel
                                                   {
                                                       Error = "",
                                                       MWQMRunID = c.MWQMRunID,
                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                       SubsectorTVItemID = c.SubsectorTVItemID,
                                                       SubsectorTVText = mwqmSubsectorName,
                                                       MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                                       MWQMRunTVText = mwqmMWQMRunName,
                                                       RunSampleType = (SampleTypeEnum)c.RunSampleType,
                                                       DateTime_Local = c.DateTime_Local,
                                                       RunNumber = c.RunNumber,
                                                       StartDateTime_Local = c.StartDateTime_Local,
                                                       EndDateTime_Local = c.EndDateTime_Local,
                                                       LabReceivedDateTime_Local = c.LabReceivedDateTime_Local,
                                                       TemperatureControl1_C = c.TemperatureControl1_C,
                                                       TemperatureControl2_C = c.TemperatureControl2_C,
                                                       SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtStart_BeaufortScale,
                                                       SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtEnd_BeaufortScale,
                                                       WaterLevelAtBrook_m = c.WaterLevelAtBrook_m,
                                                       WaveHightAtEnd_m = c.WaveHightAtEnd_m,
                                                       WaveHightAtStart_m = c.WaveHightAtStart_m,
                                                       SampleCrewInitials = c.SampleCrewInitials,
                                                       AnalyzeMethod = (AnalyzeMethodEnum)c.AnalyzeMethod,
                                                       SampleMatrix = (SampleMatrixEnum)c.SampleMatrix,
                                                       Laboratory = (LaboratoryEnum)c.Laboratory,
                                                       SampleStatus = (SampleStatusEnum)c.SampleStatus,
                                                       LabSampleApprovalContactTVItemID = c.LabSampleApprovalContactTVItemID,
                                                       LabAnalyzeBath1IncubationStartDateTime_Local = c.LabAnalyzeBath1IncubationStartDateTime_Local,
                                                       LabAnalyzeBath2IncubationStartDateTime_Local = c.LabAnalyzeBath2IncubationStartDateTime_Local,
                                                       LabAnalyzeBath3IncubationStartDateTime_Local = c.LabAnalyzeBath3IncubationStartDateTime_Local,
                                                       LabRunSampleApprovalDateTime_Local = c.LabRunSampleApprovalDateTime_Local,
                                                       Tide_Start = (TideTextEnum)c.Tide_Start,
                                                       Tide_End = (TideTextEnum)c.Tide_End,
                                                       RainDay0_mm = c.RainDay0_mm,
                                                       RainDay1_mm = c.RainDay1_mm,
                                                       RainDay2_mm = c.RainDay2_mm,
                                                       RainDay3_mm = c.RainDay3_mm,
                                                       RainDay4_mm = c.RainDay4_mm,
                                                       RainDay5_mm = c.RainDay5_mm,
                                                       RainDay6_mm = c.RainDay6_mm,
                                                       RainDay7_mm = c.RainDay7_mm,
                                                       RainDay8_mm = c.RainDay8_mm,
                                                       RainDay9_mm = c.RainDay9_mm,
                                                       RainDay10_mm = c.RainDay10_mm,
                                                       Tide_h0_m = c.Tide_h0_m,
                                                       Tide_h1_m = c.Tide_h1_m,
                                                       Tide_h2_m = c.Tide_h2_m,
                                                       Tide_h3_m = c.Tide_h3_m,
                                                       Tide_h4_m = c.Tide_h4_m,
                                                       Tide_h5_m = c.Tide_h5_m,
                                                       Tide_h6_m = c.Tide_h6_m,
                                                       Tide_h7_m = c.Tide_h7_m,
                                                       Tide_h8_m = c.Tide_h8_m,
                                                       Tide_h9_m = c.Tide_h9_m,
                                                       Tide_h10_m = c.Tide_h10_m,
                                                       Tide_h11_m = c.Tide_h11_m,
                                                       Tide_h12_m = c.Tide_h12_m,
                                                       Tide_h13_m = c.Tide_h13_m,
                                                       Tide_h14_m = c.Tide_h14_m,
                                                       Tide_h15_m = c.Tide_h15_m,
                                                       Tide_h16_m = c.Tide_h16_m,
                                                       Tide_h17_m = c.Tide_h17_m,
                                                       Tide_h18_m = c.Tide_h18_m,
                                                       Tide_h19_m = c.Tide_h19_m,
                                                       Tide_h20_m = c.Tide_h20_m,
                                                       Tide_h21_m = c.Tide_h21_m,
                                                       Tide_h22_m = c.Tide_h22_m,
                                                       Tide_h23_m = c.Tide_h23_m,
                                                       Tide_h24_m = c.Tide_h24_m,
                                                       Tide_h25_m = c.Tide_h25_m,
                                                       Tide_h26_m = c.Tide_h26_m,
                                                       Tide_h27_m = c.Tide_h27_m,
                                                       Tide_h28_m = c.Tide_h28_m,
                                                       Tide_h29_m = c.Tide_h29_m,
                                                       Tide_h30_m = c.Tide_h30_m,
                                                       RemoveFromStat = c.RemoveFromStat,
                                                       RunComment = runComment,
                                                       RunWeatherComment = runWeatherComment,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                   }).ToList<MWQMRunModel>();



            return mwqmRunModelList;
        }
        public MWQMRunModel GetMWQMRunModelWithMWQMRunIDDB(int MWQMRunID)
        {
            MWQMRunModel mwqmRunModel = (from c in db.MWQMRuns
                                         let mwqmSubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                         let mwqmMWQMRunName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                         let runComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunComment).FirstOrDefault<string>()
                                         let runWeatherComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunWeatherComment).FirstOrDefault<string>()
                                         where c.MWQMRunID == MWQMRunID
                                         select new MWQMRunModel
                                         {
                                             Error = "",
                                             MWQMRunID = c.MWQMRunID,
                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                             SubsectorTVItemID = c.SubsectorTVItemID,
                                             SubsectorTVText = mwqmSubsectorName,
                                             MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                             MWQMRunTVText = mwqmMWQMRunName,
                                             RunSampleType = (SampleTypeEnum)c.RunSampleType,
                                             DateTime_Local = c.DateTime_Local,
                                             RunNumber = c.RunNumber,
                                             StartDateTime_Local = c.StartDateTime_Local,
                                             EndDateTime_Local = c.EndDateTime_Local,
                                             LabReceivedDateTime_Local = c.LabReceivedDateTime_Local,
                                             TemperatureControl1_C = c.TemperatureControl1_C,
                                             TemperatureControl2_C = c.TemperatureControl2_C,
                                             SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtStart_BeaufortScale,
                                             SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtEnd_BeaufortScale,
                                             WaterLevelAtBrook_m = c.WaterLevelAtBrook_m,
                                             WaveHightAtEnd_m = c.WaveHightAtEnd_m,
                                             WaveHightAtStart_m = c.WaveHightAtStart_m,
                                             SampleCrewInitials = c.SampleCrewInitials,
                                             AnalyzeMethod = (AnalyzeMethodEnum)c.AnalyzeMethod,
                                             SampleMatrix = (SampleMatrixEnum)c.SampleMatrix,
                                             Laboratory = (LaboratoryEnum)c.Laboratory,
                                             SampleStatus = (SampleStatusEnum)c.SampleStatus,
                                             LabSampleApprovalContactTVItemID = c.LabSampleApprovalContactTVItemID,
                                             LabAnalyzeBath1IncubationStartDateTime_Local = c.LabAnalyzeBath1IncubationStartDateTime_Local,
                                             LabAnalyzeBath2IncubationStartDateTime_Local = c.LabAnalyzeBath2IncubationStartDateTime_Local,
                                             LabAnalyzeBath3IncubationStartDateTime_Local = c.LabAnalyzeBath3IncubationStartDateTime_Local,
                                             LabRunSampleApprovalDateTime_Local = c.LabRunSampleApprovalDateTime_Local,
                                             Tide_Start = (TideTextEnum)c.Tide_Start,
                                             Tide_End = (TideTextEnum)c.Tide_End,
                                             RainDay0_mm = c.RainDay0_mm,
                                             RainDay1_mm = c.RainDay1_mm,
                                             RainDay2_mm = c.RainDay2_mm,
                                             RainDay3_mm = c.RainDay3_mm,
                                             RainDay4_mm = c.RainDay4_mm,
                                             RainDay5_mm = c.RainDay5_mm,
                                             RainDay6_mm = c.RainDay6_mm,
                                             RainDay7_mm = c.RainDay7_mm,
                                             RainDay8_mm = c.RainDay8_mm,
                                             RainDay9_mm = c.RainDay9_mm,
                                             RainDay10_mm = c.RainDay10_mm,
                                             Tide_h0_m = c.Tide_h0_m,
                                             Tide_h1_m = c.Tide_h1_m,
                                             Tide_h2_m = c.Tide_h2_m,
                                             Tide_h3_m = c.Tide_h3_m,
                                             Tide_h4_m = c.Tide_h4_m,
                                             Tide_h5_m = c.Tide_h5_m,
                                             Tide_h6_m = c.Tide_h6_m,
                                             Tide_h7_m = c.Tide_h7_m,
                                             Tide_h8_m = c.Tide_h8_m,
                                             Tide_h9_m = c.Tide_h9_m,
                                             Tide_h10_m = c.Tide_h10_m,
                                             Tide_h11_m = c.Tide_h11_m,
                                             Tide_h12_m = c.Tide_h12_m,
                                             Tide_h13_m = c.Tide_h13_m,
                                             Tide_h14_m = c.Tide_h14_m,
                                             Tide_h15_m = c.Tide_h15_m,
                                             Tide_h16_m = c.Tide_h16_m,
                                             Tide_h17_m = c.Tide_h17_m,
                                             Tide_h18_m = c.Tide_h18_m,
                                             Tide_h19_m = c.Tide_h19_m,
                                             Tide_h20_m = c.Tide_h20_m,
                                             Tide_h21_m = c.Tide_h21_m,
                                             Tide_h22_m = c.Tide_h22_m,
                                             Tide_h23_m = c.Tide_h23_m,
                                             Tide_h24_m = c.Tide_h24_m,
                                             Tide_h25_m = c.Tide_h25_m,
                                             Tide_h26_m = c.Tide_h26_m,
                                             Tide_h27_m = c.Tide_h27_m,
                                             Tide_h28_m = c.Tide_h28_m,
                                             Tide_h29_m = c.Tide_h29_m,
                                             Tide_h30_m = c.Tide_h30_m,
                                             RemoveFromStat = c.RemoveFromStat,
                                             RunComment = runComment,
                                             RunWeatherComment = runWeatherComment,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         }).FirstOrDefault<MWQMRunModel>();

            if (mwqmRunModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMRun, ServiceRes.MWQMRunID, MWQMRunID));

            return mwqmRunModel;
        }
        public MWQMRunModel GetMWQMRunModelWithMWQMRunTVItemIDDB(int MWQMRunTVItemID)
        {
            MWQMRunModel mwqmRunModel = (from c in db.MWQMRuns
                                         let mwqmSubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                         let mwqmMWQMRunName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                         let runComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunComment).FirstOrDefault<string>()
                                         let runWeatherComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunWeatherComment).FirstOrDefault<string>()
                                         where c.MWQMRunTVItemID == MWQMRunTVItemID
                                         select new MWQMRunModel
                                         {
                                             Error = "",
                                             MWQMRunID = c.MWQMRunID,
                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                             SubsectorTVItemID = c.SubsectorTVItemID,
                                             SubsectorTVText = mwqmSubsectorName,
                                             MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                             MWQMRunTVText = mwqmMWQMRunName,
                                             RunSampleType = (SampleTypeEnum)c.RunSampleType,
                                             DateTime_Local = c.DateTime_Local,
                                             RunNumber = c.RunNumber,
                                             StartDateTime_Local = c.StartDateTime_Local,
                                             EndDateTime_Local = c.EndDateTime_Local,
                                             LabReceivedDateTime_Local = c.LabReceivedDateTime_Local,
                                             TemperatureControl1_C = c.TemperatureControl1_C,
                                             TemperatureControl2_C = c.TemperatureControl2_C,
                                             SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtStart_BeaufortScale,
                                             SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtEnd_BeaufortScale,
                                             WaterLevelAtBrook_m = c.WaterLevelAtBrook_m,
                                             WaveHightAtEnd_m = c.WaveHightAtEnd_m,
                                             WaveHightAtStart_m = c.WaveHightAtStart_m,
                                             SampleCrewInitials = c.SampleCrewInitials,
                                             AnalyzeMethod = (AnalyzeMethodEnum)c.AnalyzeMethod,
                                             SampleMatrix = (SampleMatrixEnum)c.SampleMatrix,
                                             Laboratory = (LaboratoryEnum)c.Laboratory,
                                             SampleStatus = (SampleStatusEnum)c.SampleStatus,
                                             LabSampleApprovalContactTVItemID = c.LabSampleApprovalContactTVItemID,
                                             LabAnalyzeBath1IncubationStartDateTime_Local = c.LabAnalyzeBath1IncubationStartDateTime_Local,
                                             LabAnalyzeBath2IncubationStartDateTime_Local = c.LabAnalyzeBath2IncubationStartDateTime_Local,
                                             LabAnalyzeBath3IncubationStartDateTime_Local = c.LabAnalyzeBath3IncubationStartDateTime_Local,
                                             LabRunSampleApprovalDateTime_Local = c.LabRunSampleApprovalDateTime_Local,
                                             Tide_Start = (TideTextEnum)c.Tide_Start,
                                             Tide_End = (TideTextEnum)c.Tide_End,
                                             RainDay0_mm = c.RainDay0_mm,
                                             RainDay1_mm = c.RainDay1_mm,
                                             RainDay2_mm = c.RainDay2_mm,
                                             RainDay3_mm = c.RainDay3_mm,
                                             RainDay4_mm = c.RainDay4_mm,
                                             RainDay5_mm = c.RainDay5_mm,
                                             RainDay6_mm = c.RainDay6_mm,
                                             RainDay7_mm = c.RainDay7_mm,
                                             RainDay8_mm = c.RainDay8_mm,
                                             RainDay9_mm = c.RainDay9_mm,
                                             RainDay10_mm = c.RainDay10_mm,
                                             Tide_h0_m = c.Tide_h0_m,
                                             Tide_h1_m = c.Tide_h1_m,
                                             Tide_h2_m = c.Tide_h2_m,
                                             Tide_h3_m = c.Tide_h3_m,
                                             Tide_h4_m = c.Tide_h4_m,
                                             Tide_h5_m = c.Tide_h5_m,
                                             Tide_h6_m = c.Tide_h6_m,
                                             Tide_h7_m = c.Tide_h7_m,
                                             Tide_h8_m = c.Tide_h8_m,
                                             Tide_h9_m = c.Tide_h9_m,
                                             Tide_h10_m = c.Tide_h10_m,
                                             Tide_h11_m = c.Tide_h11_m,
                                             Tide_h12_m = c.Tide_h12_m,
                                             Tide_h13_m = c.Tide_h13_m,
                                             Tide_h14_m = c.Tide_h14_m,
                                             Tide_h15_m = c.Tide_h15_m,
                                             Tide_h16_m = c.Tide_h16_m,
                                             Tide_h17_m = c.Tide_h17_m,
                                             Tide_h18_m = c.Tide_h18_m,
                                             Tide_h19_m = c.Tide_h19_m,
                                             Tide_h20_m = c.Tide_h20_m,
                                             Tide_h21_m = c.Tide_h21_m,
                                             Tide_h22_m = c.Tide_h22_m,
                                             Tide_h23_m = c.Tide_h23_m,
                                             Tide_h24_m = c.Tide_h24_m,
                                             Tide_h25_m = c.Tide_h25_m,
                                             Tide_h26_m = c.Tide_h26_m,
                                             Tide_h27_m = c.Tide_h27_m,
                                             Tide_h28_m = c.Tide_h28_m,
                                             Tide_h29_m = c.Tide_h29_m,
                                             Tide_h30_m = c.Tide_h30_m,
                                             RemoveFromStat = c.RemoveFromStat,
                                             RunComment = runComment,
                                             RunWeatherComment = runWeatherComment,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         }).FirstOrDefault<MWQMRunModel>();

            if (mwqmRunModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMRun, ServiceRes.MWQMRunTVItemID, MWQMRunTVItemID));

            return mwqmRunModel;
        }
        public MWQMRunModel GetMWQMRunModelWithSampleCrewInitialsContainsDB(string SampleCrewInitials)
        {
            MWQMRunModel mwqmRunModel = (from c in db.MWQMRuns
                                         let mwqmSubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                         let mwqmMWQMRunName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                         let runComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunComment).FirstOrDefault<string>()
                                         let runWeatherComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunWeatherComment).FirstOrDefault<string>()
                                         where c.SampleCrewInitials.Contains(SampleCrewInitials)
                                         select new MWQMRunModel
                                         {
                                             Error = "",
                                             MWQMRunID = c.MWQMRunID,
                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                             SubsectorTVItemID = c.SubsectorTVItemID,
                                             SubsectorTVText = mwqmSubsectorName,
                                             MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                             MWQMRunTVText = mwqmMWQMRunName,
                                             RunSampleType = (SampleTypeEnum)c.RunSampleType,
                                             DateTime_Local = c.DateTime_Local,
                                             RunNumber = c.RunNumber,
                                             StartDateTime_Local = c.StartDateTime_Local,
                                             EndDateTime_Local = c.EndDateTime_Local,
                                             LabReceivedDateTime_Local = c.LabReceivedDateTime_Local,
                                             TemperatureControl1_C = c.TemperatureControl1_C,
                                             TemperatureControl2_C = c.TemperatureControl2_C,
                                             SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtStart_BeaufortScale,
                                             SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtEnd_BeaufortScale,
                                             WaterLevelAtBrook_m = c.WaterLevelAtBrook_m,
                                             WaveHightAtEnd_m = c.WaveHightAtEnd_m,
                                             WaveHightAtStart_m = c.WaveHightAtStart_m,
                                             SampleCrewInitials = c.SampleCrewInitials,
                                             AnalyzeMethod = (AnalyzeMethodEnum)c.AnalyzeMethod,
                                             SampleMatrix = (SampleMatrixEnum)c.SampleMatrix,
                                             Laboratory = (LaboratoryEnum)c.Laboratory,
                                             SampleStatus = (SampleStatusEnum)c.SampleStatus,
                                             LabSampleApprovalContactTVItemID = c.LabSampleApprovalContactTVItemID,
                                             LabAnalyzeBath1IncubationStartDateTime_Local = c.LabAnalyzeBath1IncubationStartDateTime_Local,
                                             LabAnalyzeBath2IncubationStartDateTime_Local = c.LabAnalyzeBath2IncubationStartDateTime_Local,
                                             LabAnalyzeBath3IncubationStartDateTime_Local = c.LabAnalyzeBath3IncubationStartDateTime_Local,
                                             LabRunSampleApprovalDateTime_Local = c.LabRunSampleApprovalDateTime_Local,
                                             Tide_Start = (TideTextEnum)c.Tide_Start,
                                             Tide_End = (TideTextEnum)c.Tide_End,
                                             RainDay0_mm = c.RainDay0_mm,
                                             RainDay1_mm = c.RainDay1_mm,
                                             RainDay2_mm = c.RainDay2_mm,
                                             RainDay3_mm = c.RainDay3_mm,
                                             RainDay4_mm = c.RainDay4_mm,
                                             RainDay5_mm = c.RainDay5_mm,
                                             RainDay6_mm = c.RainDay6_mm,
                                             RainDay7_mm = c.RainDay7_mm,
                                             RainDay8_mm = c.RainDay8_mm,
                                             RainDay9_mm = c.RainDay9_mm,
                                             RainDay10_mm = c.RainDay10_mm,
                                             Tide_h0_m = c.Tide_h0_m,
                                             Tide_h1_m = c.Tide_h1_m,
                                             Tide_h2_m = c.Tide_h2_m,
                                             Tide_h3_m = c.Tide_h3_m,
                                             Tide_h4_m = c.Tide_h4_m,
                                             Tide_h5_m = c.Tide_h5_m,
                                             Tide_h6_m = c.Tide_h6_m,
                                             Tide_h7_m = c.Tide_h7_m,
                                             Tide_h8_m = c.Tide_h8_m,
                                             Tide_h9_m = c.Tide_h9_m,
                                             Tide_h10_m = c.Tide_h10_m,
                                             Tide_h11_m = c.Tide_h11_m,
                                             Tide_h12_m = c.Tide_h12_m,
                                             Tide_h13_m = c.Tide_h13_m,
                                             Tide_h14_m = c.Tide_h14_m,
                                             Tide_h15_m = c.Tide_h15_m,
                                             Tide_h16_m = c.Tide_h16_m,
                                             Tide_h17_m = c.Tide_h17_m,
                                             Tide_h18_m = c.Tide_h18_m,
                                             Tide_h19_m = c.Tide_h19_m,
                                             Tide_h20_m = c.Tide_h20_m,
                                             Tide_h21_m = c.Tide_h21_m,
                                             Tide_h22_m = c.Tide_h22_m,
                                             Tide_h23_m = c.Tide_h23_m,
                                             Tide_h24_m = c.Tide_h24_m,
                                             Tide_h25_m = c.Tide_h25_m,
                                             Tide_h26_m = c.Tide_h26_m,
                                             Tide_h27_m = c.Tide_h27_m,
                                             Tide_h28_m = c.Tide_h28_m,
                                             Tide_h29_m = c.Tide_h29_m,
                                             Tide_h30_m = c.Tide_h30_m,
                                             RemoveFromStat = c.RemoveFromStat,
                                             RunComment = runComment,
                                             RunWeatherComment = runWeatherComment,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         }).FirstOrDefault<MWQMRunModel>();

            if (mwqmRunModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMRun, ServiceRes.SampleCrewInitials, SampleCrewInitials));

            return mwqmRunModel;
        }
        public List<MWQMRunModel> GetMWQMRunModelListWithLabSampleApprovalContactTVItemIDDB(int LabSampleApprovalContactTVItemID)
        {
            List<MWQMRunModel> mwqmRunModelList = (from c in db.MWQMRuns
                                                   let mwqmSubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                   let mwqmMWQMRunName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                                   let runComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunComment).FirstOrDefault<string>()
                                                   let runWeatherComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunWeatherComment).FirstOrDefault<string>()
                                                   where c.LabSampleApprovalContactTVItemID == LabSampleApprovalContactTVItemID
                                                   select new MWQMRunModel
                                                   {
                                                       Error = "",
                                                       MWQMRunID = c.MWQMRunID,
                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                       SubsectorTVItemID = c.SubsectorTVItemID,
                                                       SubsectorTVText = mwqmSubsectorName,
                                                       MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                                       MWQMRunTVText = mwqmMWQMRunName,
                                                       RunSampleType = (SampleTypeEnum)c.RunSampleType,
                                                       DateTime_Local = c.DateTime_Local,
                                                       RunNumber = c.RunNumber,
                                                       StartDateTime_Local = c.StartDateTime_Local,
                                                       EndDateTime_Local = c.EndDateTime_Local,
                                                       LabReceivedDateTime_Local = c.LabReceivedDateTime_Local,
                                                       TemperatureControl1_C = c.TemperatureControl1_C,
                                                       TemperatureControl2_C = c.TemperatureControl2_C,
                                                       SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtStart_BeaufortScale,
                                                       SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtEnd_BeaufortScale,
                                                       WaterLevelAtBrook_m = c.WaterLevelAtBrook_m,
                                                       WaveHightAtEnd_m = c.WaveHightAtEnd_m,
                                                       WaveHightAtStart_m = c.WaveHightAtStart_m,
                                                       SampleCrewInitials = c.SampleCrewInitials,
                                                       AnalyzeMethod = (AnalyzeMethodEnum)c.AnalyzeMethod,
                                                       SampleMatrix = (SampleMatrixEnum)c.SampleMatrix,
                                                       Laboratory = (LaboratoryEnum)c.Laboratory,
                                                       SampleStatus = (SampleStatusEnum)c.SampleStatus,
                                                       LabSampleApprovalContactTVItemID = c.LabSampleApprovalContactTVItemID,
                                                       LabAnalyzeBath1IncubationStartDateTime_Local = c.LabAnalyzeBath1IncubationStartDateTime_Local,
                                                       LabAnalyzeBath2IncubationStartDateTime_Local = c.LabAnalyzeBath2IncubationStartDateTime_Local,
                                                       LabAnalyzeBath3IncubationStartDateTime_Local = c.LabAnalyzeBath3IncubationStartDateTime_Local,
                                                       LabRunSampleApprovalDateTime_Local = c.LabRunSampleApprovalDateTime_Local,
                                                       Tide_Start = (TideTextEnum)c.Tide_Start,
                                                       Tide_End = (TideTextEnum)c.Tide_End,
                                                       RainDay0_mm = c.RainDay0_mm,
                                                       RainDay1_mm = c.RainDay1_mm,
                                                       RainDay2_mm = c.RainDay2_mm,
                                                       RainDay3_mm = c.RainDay3_mm,
                                                       RainDay4_mm = c.RainDay4_mm,
                                                       RainDay5_mm = c.RainDay5_mm,
                                                       RainDay6_mm = c.RainDay6_mm,
                                                       RainDay7_mm = c.RainDay7_mm,
                                                       RainDay8_mm = c.RainDay8_mm,
                                                       RainDay9_mm = c.RainDay9_mm,
                                                       RainDay10_mm = c.RainDay10_mm,
                                                       Tide_h0_m = c.Tide_h0_m,
                                                       Tide_h1_m = c.Tide_h1_m,
                                                       Tide_h2_m = c.Tide_h2_m,
                                                       Tide_h3_m = c.Tide_h3_m,
                                                       Tide_h4_m = c.Tide_h4_m,
                                                       Tide_h5_m = c.Tide_h5_m,
                                                       Tide_h6_m = c.Tide_h6_m,
                                                       Tide_h7_m = c.Tide_h7_m,
                                                       Tide_h8_m = c.Tide_h8_m,
                                                       Tide_h9_m = c.Tide_h9_m,
                                                       Tide_h10_m = c.Tide_h10_m,
                                                       Tide_h11_m = c.Tide_h11_m,
                                                       Tide_h12_m = c.Tide_h12_m,
                                                       Tide_h13_m = c.Tide_h13_m,
                                                       Tide_h14_m = c.Tide_h14_m,
                                                       Tide_h15_m = c.Tide_h15_m,
                                                       Tide_h16_m = c.Tide_h16_m,
                                                       Tide_h17_m = c.Tide_h17_m,
                                                       Tide_h18_m = c.Tide_h18_m,
                                                       Tide_h19_m = c.Tide_h19_m,
                                                       Tide_h20_m = c.Tide_h20_m,
                                                       Tide_h21_m = c.Tide_h21_m,
                                                       Tide_h22_m = c.Tide_h22_m,
                                                       Tide_h23_m = c.Tide_h23_m,
                                                       Tide_h24_m = c.Tide_h24_m,
                                                       Tide_h25_m = c.Tide_h25_m,
                                                       Tide_h26_m = c.Tide_h26_m,
                                                       Tide_h27_m = c.Tide_h27_m,
                                                       Tide_h28_m = c.Tide_h28_m,
                                                       Tide_h29_m = c.Tide_h29_m,
                                                       Tide_h30_m = c.Tide_h30_m,
                                                       RemoveFromStat = c.RemoveFromStat,
                                                       RunComment = runComment,
                                                       RunWeatherComment = runWeatherComment,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                   }).ToList<MWQMRunModel>();

            return mwqmRunModelList;
        }
        public MWQMRunModel GetMWQMRunModelExistDB(MWQMRunModel mwqmRunModel)
        {
            MWQMRunModel mwqmRunModelRet = (from c in db.MWQMRuns
                                            let mwqmSubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                            let mwqmMWQMRunName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                            let runComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunComment).FirstOrDefault<string>()
                                            let runWeatherComment = (from cl in db.MWQMRunLanguages where cl.Language == (int)LanguageRequest && cl.MWQMRunID == c.MWQMRunID select cl.RunWeatherComment).FirstOrDefault<string>()
                                            where c.SubsectorTVItemID == mwqmRunModel.SubsectorTVItemID
                                            && c.DateTime_Local == mwqmRunModel.DateTime_Local
                                            && c.RunSampleType == (int)mwqmRunModel.RunSampleType
                                            && c.RunNumber == mwqmRunModel.RunNumber
                                            select new MWQMRunModel
                                            {
                                                Error = "",
                                                MWQMRunID = c.MWQMRunID,
                                                DBCommand = (DBCommandEnum)c.DBCommand,
                                                SubsectorTVItemID = c.SubsectorTVItemID,
                                                SubsectorTVText = mwqmSubsectorName,
                                                MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                                MWQMRunTVText = mwqmMWQMRunName,
                                                RunSampleType = (SampleTypeEnum)c.RunSampleType,
                                                DateTime_Local = c.DateTime_Local,
                                                RunNumber = c.RunNumber,
                                                StartDateTime_Local = c.StartDateTime_Local,
                                                EndDateTime_Local = c.EndDateTime_Local,
                                                LabReceivedDateTime_Local = c.LabReceivedDateTime_Local,
                                                TemperatureControl1_C = c.TemperatureControl1_C,
                                                TemperatureControl2_C = c.TemperatureControl2_C,
                                                SeaStateAtStart_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtStart_BeaufortScale,
                                                SeaStateAtEnd_BeaufortScale = (BeaufortScaleEnum)c.SeaStateAtEnd_BeaufortScale,
                                                WaterLevelAtBrook_m = c.WaterLevelAtBrook_m,
                                                WaveHightAtEnd_m = c.WaveHightAtEnd_m,
                                                WaveHightAtStart_m = c.WaveHightAtStart_m,
                                                SampleCrewInitials = c.SampleCrewInitials,
                                                AnalyzeMethod = (AnalyzeMethodEnum)c.AnalyzeMethod,
                                                SampleMatrix = (SampleMatrixEnum)c.SampleMatrix,
                                                Laboratory = (LaboratoryEnum)c.Laboratory,
                                                SampleStatus = (SampleStatusEnum)c.SampleStatus,
                                                LabSampleApprovalContactTVItemID = c.LabSampleApprovalContactTVItemID,
                                                LabAnalyzeBath1IncubationStartDateTime_Local = c.LabAnalyzeBath1IncubationStartDateTime_Local,
                                                LabAnalyzeBath2IncubationStartDateTime_Local = c.LabAnalyzeBath2IncubationStartDateTime_Local,
                                                LabAnalyzeBath3IncubationStartDateTime_Local = c.LabAnalyzeBath3IncubationStartDateTime_Local,
                                                LabRunSampleApprovalDateTime_Local = c.LabRunSampleApprovalDateTime_Local,
                                                Tide_Start = (TideTextEnum)c.Tide_Start,
                                                Tide_End = (TideTextEnum)c.Tide_End,
                                                RainDay0_mm = c.RainDay0_mm,
                                                RainDay1_mm = c.RainDay1_mm,
                                                RainDay2_mm = c.RainDay2_mm,
                                                RainDay3_mm = c.RainDay3_mm,
                                                RainDay4_mm = c.RainDay4_mm,
                                                RainDay5_mm = c.RainDay5_mm,
                                                RainDay6_mm = c.RainDay6_mm,
                                                RainDay7_mm = c.RainDay7_mm,
                                                RainDay8_mm = c.RainDay8_mm,
                                                RainDay9_mm = c.RainDay9_mm,
                                                RainDay10_mm = c.RainDay10_mm,
                                                Tide_h0_m = c.Tide_h0_m,
                                                Tide_h1_m = c.Tide_h1_m,
                                                Tide_h2_m = c.Tide_h2_m,
                                                Tide_h3_m = c.Tide_h3_m,
                                                Tide_h4_m = c.Tide_h4_m,
                                                Tide_h5_m = c.Tide_h5_m,
                                                Tide_h6_m = c.Tide_h6_m,
                                                Tide_h7_m = c.Tide_h7_m,
                                                Tide_h8_m = c.Tide_h8_m,
                                                Tide_h9_m = c.Tide_h9_m,
                                                Tide_h10_m = c.Tide_h10_m,
                                                Tide_h11_m = c.Tide_h11_m,
                                                Tide_h12_m = c.Tide_h12_m,
                                                Tide_h13_m = c.Tide_h13_m,
                                                Tide_h14_m = c.Tide_h14_m,
                                                Tide_h15_m = c.Tide_h15_m,
                                                Tide_h16_m = c.Tide_h16_m,
                                                Tide_h17_m = c.Tide_h17_m,
                                                Tide_h18_m = c.Tide_h18_m,
                                                Tide_h19_m = c.Tide_h19_m,
                                                Tide_h20_m = c.Tide_h20_m,
                                                Tide_h21_m = c.Tide_h21_m,
                                                Tide_h22_m = c.Tide_h22_m,
                                                Tide_h23_m = c.Tide_h23_m,
                                                Tide_h24_m = c.Tide_h24_m,
                                                Tide_h25_m = c.Tide_h25_m,
                                                Tide_h26_m = c.Tide_h26_m,
                                                Tide_h27_m = c.Tide_h27_m,
                                                Tide_h28_m = c.Tide_h28_m,
                                                Tide_h29_m = c.Tide_h29_m,
                                                Tide_h30_m = c.Tide_h30_m,
                                                RemoveFromStat = c.RemoveFromStat,
                                                RunComment = runComment,
                                                RunWeatherComment = runWeatherComment,
                                                LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                            }).FirstOrDefault<MWQMRunModel>();

            if (mwqmRunModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMRun,
                    ServiceRes.SubsectorTVItemID + "," +
                    ServiceRes.DateTime_Local + "," +
                    ServiceRes.RunSampleType + "," +
                    ServiceRes.RunNumber,
                    mwqmRunModel.SubsectorTVItemID + "," +
                    mwqmRunModel.DateTime_Local + "," +
                    mwqmRunModel.RunSampleType + "," +
                    mwqmRunModel.RunNumber));

            return mwqmRunModelRet;
        }
        public MWQMRun GetMWQMRunWithMWQMRunIDDB(int MWQMRunID)
        {
            MWQMRun mwqmRun = (from c in db.MWQMRuns
                               where c.MWQMRunID == MWQMRunID
                               select c).FirstOrDefault<MWQMRun>();

            return mwqmRun;
        }
        public MWQMRun GetMWQMRunWithMWQMRunTVItemIDDB(int MWQMRunTVItemID)
        {
            MWQMRun mwqmRun = (from c in db.MWQMRuns
                               where c.MWQMRunTVItemID == MWQMRunTVItemID
                               select c).FirstOrDefault<MWQMRun>();

            return mwqmRun;
        }
        public int GetMWQMSampleCountWithMWQMRunTVItemIDDB(int MWQMRunTVItemID)
        {
            return (from c in db.MWQMSamples
                    where c.MWQMRunTVItemID == MWQMRunTVItemID
                    select c).Count();
        }
        public bool IsRainDataMissingWithSubsectorTVItemID(int SubsectorTVItemID)
        {
            bool RainDataMissing = (from c in db.MWQMRuns
                                    where c.SubsectorTVItemID == SubsectorTVItemID
                                    && (c.RainDay0_mm == null
                                    || c.RainDay1_mm == null
                                    || c.RainDay2_mm == null
                                    || c.RainDay3_mm == null
                                    || c.RainDay4_mm == null
                                    || c.RainDay5_mm == null
                                    || c.RainDay6_mm == null
                                    || c.RainDay7_mm == null
                                    || c.RainDay8_mm == null
                                    || c.RainDay9_mm == null
                                    || c.RainDay10_mm == null)
                                    select c).Any();
            return RainDataMissing;
        }

        // Helper
        public MWQMRunModel ReturnError(string Error)
        {
            return new MWQMRunModel() { Error = Error };
        }
        public string ChangeLabSheetAndRemoveLabSheetDetail(LabSheetModel labSheetModel)
        {
            LabSheetService labSheetService = new LabSheetService(LanguageRequest, User);
            LabSheetDetailService labSheetDetailService = new LabSheetDetailService(LanguageRequest, User);

            labSheetModel.MWQMRunTVItemID = null;
            labSheetModel.LabSheetStatus = LabSheetStatusEnum.Transferred;

            LabSheetModel labSheetModelRet = labSheetService.PostUpdateLabSheetDB(labSheetModel);
            if (!string.IsNullOrWhiteSpace(labSheetModelRet.Error))
                return labSheetModelRet.Error;

            List<LabSheetDetailModel> labSheetDetailModelList = labSheetDetailService.GetLabSheetDetailModelListWithLabSheetIDDB(labSheetModelRet.LabSheetID);

            foreach (LabSheetDetailModel labSheetDetailModel in labSheetDetailModelList)
            {
                LabSheetDetailModel labSheetDetailModelRet = labSheetDetailService.PostDeleteLabSheetDetailDB(labSheetDetailModel.LabSheetDetailID);
                if (!string.IsNullOrWhiteSpace(labSheetDetailModelRet.Error))
                    return labSheetDetailModelRet.Error;
            }

            return "";
        }

        // Post
        public MWQMRunModel MWQMRunAddOrModifyDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int TempInt = 0;
            int MWQMRunTVItemID = 0;
            SampleTypeEnum RunSampleType = SampleTypeEnum.Error;
            int SubsectorTVItemID = 0;
            int RunDateYear = 0;
            int RunDateMonth = 0;
            int RunDateDay = 0;
            int RunNumber = 0;
            string RunStartTime = "";
            string RunEndTime = "";
            SameDayNextDayEnum LabReceivedRunSample = SameDayNextDayEnum.Error;
            string LabReceivedTime = "";
            float? TemperatureControl1_C = 0.0f;
            float? TemperatureControl2_C = 0.0f;
            //BeaufortScaleEnum? SeaStateAtStart_BeaufortScale = BeaufortScaleEnum.Error;
            //BeaufortScaleEnum? SeaStateAtEnd_BeaufortScale = BeaufortScaleEnum.Error;
            float? WaterLevelAtBrook_m = 0.0f;
            float? WaveHightAtStart_m = 0.0f;
            float? WaveHightAtEnd_m = 0.0f;
            string SampleCrewInitials = "";
            //AnalyzeMethodEnum? AnalyzeMethod = AnalyzeMethodEnum.Error;
            //SampleMatrixEnum? SampleMatrix = SampleMatrixEnum.Error;
            //LaboratoryEnum? Laboratory = LaboratoryEnum.Error;
            SameDayNextDayEnum LabAnalyzeBath1StartIncubationDay = SameDayNextDayEnum.Error;
            SameDayNextDayEnum LabAnalyzeBath2StartIncubationDay = SameDayNextDayEnum.Error;
            SameDayNextDayEnum LabAnalyzeBath3StartIncubationDay = SameDayNextDayEnum.Error;
            string LabAnalyzeBath1StartIncubationTime = "";
            string LabAnalyzeBath2StartIncubationTime = "";
            string LabAnalyzeBath3StartIncubationTime = "";
            int LabSampleApprovalContactTVItemID = 0;
            int LabRunSampleApprovalYear = 0;
            int LabRunSampleApprovalMonth = 0;
            int LabRunSampleApprovalDay = 0;
            string LabRunSampleApprovalTime = "";
            TideTextEnum StartTide = TideTextEnum.Error;
            TideTextEnum EndTide = TideTextEnum.Error;
            string RunComment = "";
            string RunWeatherComment = "";
            //bool ShouldChangeTVText = false;


            // will be 0 to add a new MWQMRun
            int.TryParse(fc["MWQMRunTVItemID"], out MWQMRunTVItemID);

            if (MWQMRunTVItemID == 0)
            {
                int.TryParse(fc["SubsectorTVItemID"], out SubsectorTVItemID);
                if (SubsectorTVItemID == 0)
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID));

                TVItemModel tvItemModelParent = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelParent.Error))
                    return ReturnError(tvItemModelParent.Error);

            }

            MWQMRunModel mwqmRunModel = new MWQMRunModel();
            if (MWQMRunTVItemID > 0)
            {
                mwqmRunModel = GetMWQMRunModelWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
                if (!string.IsNullOrWhiteSpace(mwqmRunModel.Error))
                    return ReturnError(mwqmRunModel.Error);
            }

            int.TryParse(fc["RunSampleType"], out TempInt);
            if (TempInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.RunSampleType));

            RunSampleType = (SampleTypeEnum)TempInt;

            mwqmRunModel.RunSampleType = RunSampleType;

            int.TryParse(fc["StartTide"], out TempInt);
            if (TempInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StartTide));

            StartTide = (TideTextEnum)TempInt;

            mwqmRunModel.Tide_Start = StartTide;

            int.TryParse(fc["EndTide"], out TempInt);
            if (TempInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EndTide));

            EndTide = (TideTextEnum)TempInt;

            mwqmRunModel.Tide_End = EndTide;

            // RunDate
            int.TryParse(fc["RunDateYear"], out RunDateYear);
            if (RunDateYear == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.RunDateYear));

            int.TryParse(fc["RunDateMonth"], out RunDateMonth);
            if (RunDateMonth == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.RunDateMonth));

            int.TryParse(fc["RunDateDay"], out RunDateDay);
            if (RunDateDay == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.RunDateDay));

            DateTime RunDate = new DateTime(RunDateYear, RunDateMonth, RunDateDay);

            if (RunDate < new DateTime(1950, 1, 1))
                return ReturnError(string.Format(ServiceRes.PleaseEnterAValidDateFor_, ServiceRes.RunDate));

            if (mwqmRunModel.DateTime_Local != RunDate)
            {
                //ShouldChangeTVText = true;
            }

            mwqmRunModel.DateTime_Local = RunDate;

            int.TryParse(fc["RunNumber"], out RunNumber);
            if (RunNumber == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.RunNumber));

            mwqmRunModel.RunNumber = RunNumber;

            // RunStartTime
            int RunStartTimeHour = 0;
            int RunStartTimeMinute = 0;
            RunStartTime = fc["RunStartTime"];
            if (string.IsNullOrWhiteSpace(RunStartTime))
            {
                mwqmRunModel.StartDateTime_Local = null;
            }
            else
            {
                if (RunStartTime.Length != 5)
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, RunStartTime));

                if (RunStartTime.Substring(2, 1) != ":")
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, RunStartTime));

                try
                {
                    RunStartTimeHour = int.Parse(RunStartTime.Substring(0, 2));
                    RunStartTimeMinute = int.Parse(RunStartTime.Substring(3, 2));
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, RunStartTime));
                }

                if (RunStartTimeHour < 0 || RunStartTimeHour > 23)
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, RunStartTime));

                if (RunStartTimeMinute < 0 || RunStartTimeMinute > 59)
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, RunStartTime));

                mwqmRunModel.StartDateTime_Local = new DateTime(RunDate.Year, RunDate.Month, RunDate.Day, RunStartTimeHour, RunStartTimeMinute, 0);
            }

            // RunEndTime
            int RunEndTimeHour = 0;
            int RunEndTimeMinute = 0;
            RunEndTime = fc["RunEndTime"];
            if (string.IsNullOrWhiteSpace(RunEndTime))
            {
                mwqmRunModel.EndDateTime_Local = null;
            }
            else
            {
                if (RunEndTime.Length != 5)
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, RunEndTime));

                if (RunEndTime.Substring(2, 1) != ":")
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, RunEndTime));

                try
                {
                    RunEndTimeHour = int.Parse(RunEndTime.Substring(0, 2));
                    RunEndTimeMinute = int.Parse(RunEndTime.Substring(3, 2));
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, RunEndTimeHour));
                }

                if (RunEndTimeHour < 0 || RunEndTimeHour > 23)
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, RunEndTime));

                if (RunEndTimeMinute < 0 || RunEndTimeMinute > 59)
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, RunEndTime));

                mwqmRunModel.EndDateTime_Local = new DateTime(RunDate.Year, RunDate.Month, RunDate.Day, RunEndTimeHour, RunEndTimeMinute, 0);
            }

            if (mwqmRunModel.StartDateTime_Local > mwqmRunModel.EndDateTime_Local)
                return ReturnError(string.Format(ServiceRes._IsBiggerOrEqualTo_, ServiceRes.RunStartTimeHour, ServiceRes.RunEndTimeHour));

            // LabReceivedRunSample
            mwqmRunModel.LabReceivedDateTime_Local = null;
            int.TryParse(fc["LabReceivedRunSample"], out TempInt);
            if (TempInt > 0)
            {
                if (!(TempInt == (int)SameDayNextDayEnum.SameDay || TempInt == (int)SameDayNextDayEnum.NextDay))
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SameDayNextDay));

                LabReceivedRunSample = (SameDayNextDayEnum)TempInt;

                // LabReceivedTime
                LabReceivedTime = fc["LabReceivedTime"];
                if (string.IsNullOrWhiteSpace(RunEndTime))
                {
                    mwqmRunModel.LabReceivedDateTime_Local = null;
                }
                else
                {
                    if (LabReceivedTime.Length != 5)
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabReceivedTime));

                    if (LabReceivedTime.Substring(2, 1) != ":")
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabReceivedTime));

                    int Hour = 0;
                    int Minute = 0;
                    try
                    {
                        Hour = int.Parse(LabReceivedTime.Substring(0, 2));
                        Minute = int.Parse(LabReceivedTime.Substring(3, 2));
                    }
                    catch (Exception)
                    {
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabReceivedTime));
                    }

                    if (Hour < 0 || Hour > 23)
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabReceivedTime));

                    if (Minute < 0 || Minute > 59)
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabReceivedTime));

                    if (LabReceivedRunSample == SameDayNextDayEnum.SameDay)
                    {
                        mwqmRunModel.LabReceivedDateTime_Local = new DateTime(RunDate.Year, RunDate.Month, RunDate.Day, Hour, Minute, 0);
                    }
                    else if (LabReceivedRunSample == SameDayNextDayEnum.NextDay)
                    {
                        mwqmRunModel.LabReceivedDateTime_Local = new DateTime(RunDate.Year, RunDate.Month, RunDate.Day, Hour, Minute, 0);
                        mwqmRunModel.LabReceivedDateTime_Local = mwqmRunModel.LabReceivedDateTime_Local.Value.AddDays(1);
                    }
                    else
                    {
                        mwqmRunModel.LabReceivedDateTime_Local = null;
                    }
                }
            }

            // TemperatureControl1_C
            if (string.IsNullOrWhiteSpace(fc["TemperatureControl1_C"]))
            {
                TemperatureControl1_C = null;
            }
            else
            {
                try
                {
                    TemperatureControl1_C = float.Parse(fc["TemperatureControl1_C"]);
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsNotANumberForField_, fc["TemperatureControl1_C"], ServiceRes.TemperatureControl1_C));
                }
            }

            mwqmRunModel.TemperatureControl1_C = TemperatureControl1_C;

            // TemperatureControl2_C
            if (string.IsNullOrWhiteSpace(fc["TemperatureControl2_C"]))
            {
                TemperatureControl2_C = null;
            }
            else
            {
                try
                {
                    TemperatureControl2_C = float.Parse(fc["TemperatureControl2_C"]);
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsNotANumberForField_, fc["TemperatureControl2_C"], ServiceRes.TemperatureControl2_C));
                }
            }

            mwqmRunModel.TemperatureControl2_C = TemperatureControl2_C;

            // SeaStateAtStart_BeaufortScale
            if (string.IsNullOrWhiteSpace(fc["SeaStateAtStart_BeaufortScale"]))
            {
                mwqmRunModel.SeaStateAtStart_BeaufortScale = null;
            }
            else
            {
                try
                {
                    mwqmRunModel.SeaStateAtStart_BeaufortScale = ((BeaufortScaleEnum)int.Parse(fc["SeaStateAtStart_BeaufortScale"]));
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SeaStateAtStart_BeaufortScale));
                }
            }

            // SeaStateAtEnd_BeaufortScale
            if (string.IsNullOrWhiteSpace(fc["SeaStateAtEnd_BeaufortScale"]))
            {
                mwqmRunModel.SeaStateAtEnd_BeaufortScale = null;
            }
            else
            {
                try
                {
                    mwqmRunModel.SeaStateAtEnd_BeaufortScale = ((BeaufortScaleEnum)int.Parse(fc["SeaStateAtEnd_BeaufortScale"]));
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SeaStateAtEnd_BeaufortScale));
                }
            }

            // WaterLevelAtBrook_m
            if (string.IsNullOrWhiteSpace(fc["WaterLevelAtBrook_m"]))
            {
                WaterLevelAtBrook_m = null;
            }
            else
            {
                try
                {
                    WaterLevelAtBrook_m = float.Parse(fc["WaterLevelAtBrook_m"]);
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsNotANumberForField_, fc["WaterLevelAtBrook_m"], ServiceRes.WaterLevelAtBrook_m));
                }
            }

            mwqmRunModel.WaterLevelAtBrook_m = WaterLevelAtBrook_m;

            // WaveHightAtStart_m
            if (string.IsNullOrWhiteSpace(fc["WaveHightAtStart_m"]))
            {
                WaveHightAtStart_m = null;
            }
            else
            {
                try
                {
                    WaveHightAtStart_m = float.Parse(fc["WaveHightAtStart_m"]);
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsNotANumberForField_, fc["WaveHightAtStart_m"], ServiceRes.WaveHightAtStart_m));
                }
            }

            mwqmRunModel.WaveHightAtStart_m = WaveHightAtStart_m;

            // WaveHightAtEnd_m
            if (string.IsNullOrWhiteSpace(fc["WaveHightAtEnd_m"]))
            {
                WaveHightAtEnd_m = null;
            }
            else
            {
                try
                {
                    WaveHightAtEnd_m = float.Parse(fc["WaveHightAtEnd_m"]);
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsNotANumberForField_, fc["WaveHightAtEnd_m"], ServiceRes.WaveHightAtEnd_m));
                }
            }

            mwqmRunModel.WaveHightAtEnd_m = WaveHightAtEnd_m;

            RunComment = fc["RunComment"];
            mwqmRunModel.RunComment = RunComment;

            RunWeatherComment = fc["RunWeatherComment"];
            mwqmRunModel.RunWeatherComment = RunWeatherComment;

            // SampleCrewInitials
            SampleCrewInitials = fc["SampleCrewInitials"];

            mwqmRunModel.SampleCrewInitials = SampleCrewInitials;

            // AnalyzeMethod
            if (string.IsNullOrWhiteSpace(fc["AnalyzeMethod"]))
            {
                mwqmRunModel.AnalyzeMethod = null;
            }
            else
            {
                try
                {
                    mwqmRunModel.AnalyzeMethod = ((AnalyzeMethodEnum)int.Parse(fc["AnalyzeMethod"]));
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AnalyzeMethod));
                }
            }

            // SampleMatrix
            if (string.IsNullOrWhiteSpace(fc["SampleMatrix"]))
            {
                mwqmRunModel.SampleMatrix = null;
            }
            else
            {
                try
                {
                    mwqmRunModel.SampleMatrix = ((SampleMatrixEnum)int.Parse(fc["SampleMatrix"]));
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SampleMatrix));
                }
            }

            // Laboratory
            if (string.IsNullOrWhiteSpace(fc["Laboratory"]))
            {
                mwqmRunModel.Laboratory = null;
            }
            else
            {
                try
                {
                    mwqmRunModel.Laboratory = ((LaboratoryEnum)int.Parse(fc["Laboratory"]));
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Laboratory));
                }
            }

            // LabAnalyzeBath1StartIncubationDay
            mwqmRunModel.LabAnalyzeBath1IncubationStartDateTime_Local = null;
            int.TryParse(fc["LabAnalyzeBath1StartIncubationDay"], out TempInt);
            if (TempInt > 0)
            {
                if (!(TempInt == (int)SameDayNextDayEnum.SameDay || TempInt == (int)SameDayNextDayEnum.NextDay))
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SameDayNextDay));

                LabAnalyzeBath1StartIncubationDay = (SameDayNextDayEnum)TempInt;

                // LabAnalyzeBath1StartIncubationTime
                LabAnalyzeBath1StartIncubationTime = fc["LabAnalyzeBath1StartIncubationTime"];
                if (string.IsNullOrWhiteSpace(LabAnalyzeBath1StartIncubationTime))
                {
                    mwqmRunModel.LabAnalyzeBath1IncubationStartDateTime_Local = null;
                }
                else
                {
                    if (LabAnalyzeBath1StartIncubationTime.Length != 5)
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath1StartIncubationTime));

                    if (LabAnalyzeBath1StartIncubationTime.Substring(2, 1) != ":")
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath1StartIncubationTime));

                    int Hour = 0;
                    int Minute = 0;
                    try
                    {
                        Hour = int.Parse(LabAnalyzeBath1StartIncubationTime.Substring(0, 2));
                        Minute = int.Parse(LabAnalyzeBath1StartIncubationTime.Substring(3, 2));
                    }
                    catch (Exception)
                    {
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath1StartIncubationTime));
                    }

                    if (Hour < 0 || Hour > 23)
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath1StartIncubationTime));

                    if (Minute < 0 || Minute > 59)
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath1StartIncubationTime));

                    if (LabAnalyzeBath1StartIncubationDay == SameDayNextDayEnum.SameDay)
                    {
                        mwqmRunModel.LabAnalyzeBath1IncubationStartDateTime_Local = new DateTime(RunDate.Year, RunDate.Month, RunDate.Day, Hour, Minute, 0);
                    }
                    else if (LabAnalyzeBath1StartIncubationDay == SameDayNextDayEnum.NextDay)
                    {
                        mwqmRunModel.LabAnalyzeBath1IncubationStartDateTime_Local = new DateTime(RunDate.Year, RunDate.Month, RunDate.Day, Hour, Minute, 0);
                        mwqmRunModel.LabAnalyzeBath1IncubationStartDateTime_Local = mwqmRunModel.LabAnalyzeBath1IncubationStartDateTime_Local.Value.AddDays(1);
                    }
                    else
                    {
                        mwqmRunModel.LabAnalyzeBath1IncubationStartDateTime_Local = null;
                    }
                }
            }

            // LabAnalyzeBath2StartIncubationDay
            mwqmRunModel.LabAnalyzeBath2IncubationStartDateTime_Local = null;
            int.TryParse(fc["LabAnalyzeBath2StartIncubationDay"], out TempInt);
            if (TempInt > 0)
            {
                if (!(TempInt == (int)SameDayNextDayEnum.SameDay || TempInt == (int)SameDayNextDayEnum.NextDay))
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SameDayNextDay));

                LabAnalyzeBath2StartIncubationDay = (SameDayNextDayEnum)TempInt;

                // LabAnalyzeBath2StartIncubationTime
                LabAnalyzeBath2StartIncubationTime = fc["LabAnalyzeBath2StartIncubationTime"];
                if (string.IsNullOrWhiteSpace(LabAnalyzeBath2StartIncubationTime))
                {
                    mwqmRunModel.LabAnalyzeBath2IncubationStartDateTime_Local = null;
                }
                else
                {
                    if (LabAnalyzeBath2StartIncubationTime.Length != 5)
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath2StartIncubationTime));

                    if (LabAnalyzeBath2StartIncubationTime.Substring(2, 1) != ":")
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath2StartIncubationTime));

                    int Hour = 0;
                    int Minute = 0;
                    try
                    {
                        Hour = int.Parse(LabAnalyzeBath2StartIncubationTime.Substring(0, 2));
                        Minute = int.Parse(LabAnalyzeBath2StartIncubationTime.Substring(3, 2));
                    }
                    catch (Exception)
                    {
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath2StartIncubationTime));
                    }

                    if (Hour < 0 || Hour > 23)
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath2StartIncubationTime));

                    if (Minute < 0 || Minute > 59)
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath2StartIncubationTime));

                    if (LabAnalyzeBath2StartIncubationDay == SameDayNextDayEnum.SameDay)
                    {
                        mwqmRunModel.LabAnalyzeBath2IncubationStartDateTime_Local = new DateTime(RunDate.Year, RunDate.Month, RunDate.Day, Hour, Minute, 0);
                    }
                    else if (LabAnalyzeBath2StartIncubationDay == SameDayNextDayEnum.NextDay)
                    {
                        mwqmRunModel.LabAnalyzeBath2IncubationStartDateTime_Local = new DateTime(RunDate.Year, RunDate.Month, RunDate.Day, Hour, Minute, 0);
                        mwqmRunModel.LabAnalyzeBath2IncubationStartDateTime_Local = mwqmRunModel.LabAnalyzeBath2IncubationStartDateTime_Local.Value.AddDays(2);
                    }
                    else
                    {
                        mwqmRunModel.LabAnalyzeBath2IncubationStartDateTime_Local = null;
                    }
                }
            }

            // LabAnalyzeBath3StartIncubationDay
            mwqmRunModel.LabAnalyzeBath3IncubationStartDateTime_Local = null;
            int.TryParse(fc["LabAnalyzeBath3StartIncubationDay"], out TempInt);
            if (TempInt > 0)
            {
                if (!(TempInt == (int)SameDayNextDayEnum.SameDay || TempInt == (int)SameDayNextDayEnum.NextDay))
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SameDayNextDay));

                LabAnalyzeBath3StartIncubationDay = (SameDayNextDayEnum)TempInt;

                // LabAnalyzeBath3StartIncubationTime
                LabAnalyzeBath3StartIncubationTime = fc["LabAnalyzeBath3StartIncubationTime"];
                if (string.IsNullOrWhiteSpace(LabAnalyzeBath3StartIncubationTime))
                {
                    mwqmRunModel.LabAnalyzeBath3IncubationStartDateTime_Local = null;
                }
                else
                {
                    if (LabAnalyzeBath3StartIncubationTime.Length != 5)
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath3StartIncubationTime));

                    if (LabAnalyzeBath3StartIncubationTime.Substring(2, 1) != ":")
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath3StartIncubationTime));

                    int Hour = 0;
                    int Minute = 0;
                    try
                    {
                        Hour = int.Parse(LabAnalyzeBath3StartIncubationTime.Substring(0, 2));
                        Minute = int.Parse(LabAnalyzeBath3StartIncubationTime.Substring(3, 2));
                    }
                    catch (Exception)
                    {
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath3StartIncubationTime));
                    }

                    if (Hour < 0 || Hour > 23)
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath3StartIncubationTime));

                    if (Minute < 0 || Minute > 59)
                        return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabAnalyzeBath3StartIncubationTime));

                    if (LabAnalyzeBath3StartIncubationDay == SameDayNextDayEnum.SameDay)
                    {
                        mwqmRunModel.LabAnalyzeBath3IncubationStartDateTime_Local = new DateTime(RunDate.Year, RunDate.Month, RunDate.Day, Hour, Minute, 0);
                    }
                    else if (LabAnalyzeBath3StartIncubationDay == SameDayNextDayEnum.NextDay)
                    {
                        mwqmRunModel.LabAnalyzeBath3IncubationStartDateTime_Local = new DateTime(RunDate.Year, RunDate.Month, RunDate.Day, Hour, Minute, 0);
                        mwqmRunModel.LabAnalyzeBath3IncubationStartDateTime_Local = mwqmRunModel.LabAnalyzeBath3IncubationStartDateTime_Local.Value.AddDays(3);
                    }
                    else
                    {
                        mwqmRunModel.LabAnalyzeBath3IncubationStartDateTime_Local = null;
                    }
                }
            }

            int.TryParse(fc["LabSampleApprovalContactTVItemID"], out LabSampleApprovalContactTVItemID);
            if (LabSampleApprovalContactTVItemID == 0)
            {
                mwqmRunModel.LabSampleApprovalContactTVItemID = null;
            }
            else
            {
                TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(LabSampleApprovalContactTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                    return ReturnError(tvItemModel.Error);

                mwqmRunModel.LabSampleApprovalContactTVItemID = LabSampleApprovalContactTVItemID;
            }

            // LabRunSampleApprovalYear
            int.TryParse(fc["LabRunSampleApprovalYear"], out LabRunSampleApprovalYear);
            if (LabRunSampleApprovalYear == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.LabRunSampleApprovalYear));

            int.TryParse(fc["LabRunSampleApprovalMonth"], out LabRunSampleApprovalMonth);
            if (LabRunSampleApprovalMonth == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.LabRunSampleApprovalMonth));

            int.TryParse(fc["LabRunSampleApprovalDay"], out LabRunSampleApprovalDay);
            if (LabRunSampleApprovalDay == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.LabRunSampleApprovalDay));

            // LabRunSampleApprovalTime
            LabRunSampleApprovalTime = fc["LabRunSampleApprovalTime"];
            if (string.IsNullOrWhiteSpace(LabRunSampleApprovalTime))
            {
                mwqmRunModel.LabRunSampleApprovalDateTime_Local = null;
            }
            else
            {
                if (LabRunSampleApprovalTime.Length != 5)
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabRunSampleApprovalTime));

                if (LabRunSampleApprovalTime.Substring(2, 1) != ":")
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabRunSampleApprovalTime));

                int Hour = 0;
                int Minute = 0;
                try
                {
                    Hour = int.Parse(LabRunSampleApprovalTime.Substring(0, 2));
                    Minute = int.Parse(LabRunSampleApprovalTime.Substring(3, 2));
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabRunSampleApprovalTime));
                }

                if (Hour < 0 || Hour > 23)
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabRunSampleApprovalTime));

                if (Minute < 0 || Minute > 59)
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, LabRunSampleApprovalTime));

                mwqmRunModel.LabRunSampleApprovalDateTime_Local = new DateTime(LabRunSampleApprovalYear, LabRunSampleApprovalMonth, LabRunSampleApprovalDay, Hour, Minute, 0);
            }

            // RainDay1_mm
            if (string.IsNullOrWhiteSpace(fc["RainDay1_mm"]))
            {
                mwqmRunModel.RainDay1_mm = null;
            }
            else
            {
                try
                {
                    mwqmRunModel.RainDay1_mm = float.Parse(fc["RainDay1_mm"]);
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsNotANumberForField_, fc["RainDay1_mm"], ServiceRes.RainDay1_mm));
                }
            }

            // RainDay2_mm
            if (string.IsNullOrWhiteSpace(fc["RainDay2_mm"]))
            {
                mwqmRunModel.RainDay2_mm = null;
            }
            else
            {
                try
                {
                    mwqmRunModel.RainDay2_mm = float.Parse(fc["RainDay2_mm"]);
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsNotANumberForField_, fc["RainDay2_mm"], ServiceRes.RainDay2_mm));
                }
            }

            // RainDay3_mm
            if (string.IsNullOrWhiteSpace(fc["RainDay3_mm"]))
            {
                mwqmRunModel.RainDay3_mm = null;
            }
            else
            {
                try
                {
                    mwqmRunModel.RainDay3_mm = float.Parse(fc["RainDay3_mm"]);
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes._IsNotANumberForField_, fc["RainDay3_mm"], ServiceRes.RainDay3_mm));
                }
            }

            RunComment = fc["RunComment"];
            RunWeatherComment = fc["RunWeatherComment"];

            MWQMRunModel mwqmRunModelRet = new MWQMRunModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (MWQMRunTVItemID > 0)
                {
                    mwqmRunModelRet = PostUpdateMWQMRunDB(mwqmRunModel);
                    if (!string.IsNullOrWhiteSpace(mwqmRunModelRet.Error))
                        return ReturnError(mwqmRunModelRet.Error);

                    foreach (LanguageEnum language in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        TVItemLanguageModel tvItemLanguageModelExist = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(MWQMRunTVItemID, language);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelExist.Error))
                            return ReturnError(tvItemLanguageModelExist.Error);

                        BaseEnumService baseEnumService = new BaseEnumService(language);

                        string TVText = RunDate.ToString("yyyy MM dd");
                        if (mwqmRunModel.RunNumber > 1)
                        {
                            TVText = TVText + " (" + mwqmRunModel.RunNumber.ToString() + ")";
                        }
                        TVText = TVText + (RunSampleType != SampleTypeEnum.Routine ? " (" + baseEnumService.GetEnumText_SampleTypeEnum(RunSampleType) + ")" : "");

                        tvItemLanguageModelExist.TVText = TVText;
                        TVItemLanguageModel tvItemLanguageModelRet = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelExist);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                            return ReturnError(tvItemLanguageModelRet.Error);
                    }
                }
                else
                {
                    string TVText = RunDate.ToString("yyyy MM dd");
                    if (mwqmRunModel.RunNumber > 1)
                    {
                        TVText = TVText + " (" + mwqmRunModel.RunNumber.ToString() + ")";
                    }
                    TVItemModel tvItemModelMWQMRun = _TVItemService.PostAddChildTVItemDB(SubsectorTVItemID, TVText, TVTypeEnum.MWQMRun);
                    if (!string.IsNullOrWhiteSpace(tvItemModelMWQMRun.Error))
                        return ReturnError(tvItemModelMWQMRun.Error);

                    mwqmRunModel.SubsectorTVItemID = SubsectorTVItemID;
                    mwqmRunModel.MWQMRunTVItemID = tvItemModelMWQMRun.TVItemID;

                    mwqmRunModelRet = PostAddMWQMRunDB(mwqmRunModel);
                    if (!string.IsNullOrWhiteSpace(mwqmRunModelRet.Error))
                        return ReturnError(mwqmRunModelRet.Error);

                    foreach (LanguageEnum language in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                    {
                        TVItemLanguageModel tvItemLanguageModelExist = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemModelMWQMRun.TVItemID, language);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelExist.Error))
                            return ReturnError(tvItemLanguageModelExist.Error);

                        BaseEnumService baseEnumService = new BaseEnumService(language);

                        TVText = RunDate.ToString("yyyy MM dd");
                        if (mwqmRunModel.RunNumber > 1)
                        {
                            TVText = TVText + " (" + mwqmRunModel.RunNumber.ToString() + ")";
                        }
                        TVText = TVText + (RunSampleType != SampleTypeEnum.Routine ? " (" + baseEnumService.GetEnumText_SampleTypeEnum(RunSampleType) + ")" : "");

                        tvItemLanguageModelExist.TVText = TVText;
                        TVItemLanguageModel tvItemLanguageModelRet = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelExist);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                            return ReturnError(tvItemLanguageModelRet.Error);
                    }
                }

                ts.Complete();
            }
            return GetMWQMRunModelWithMWQMRunIDDB(mwqmRunModelRet.MWQMRunID);
        }
        //public MWQMRunModel MarkAllRoutineSamplesAsUseForOpenDataDB(int MWQMRunTVItemID)
        //{
        //    ContactOK contactOK = IsContactOK();
        //    if (!string.IsNullOrEmpty(contactOK.Error))
        //        return ReturnError(contactOK.Error);

        //    string routine = ((int)SampleTypeEnum.Routine).ToString() + ",";

        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        using (CSSPDBEntities db2 = new CSSPDBEntities())
        //        {
        //            List<MWQMSample> mwqmSampleList = (from c in db2.MWQMSamples
        //                                               where c.MWQMRunTVItemID == MWQMRunTVItemID
        //                                               && c.SampleTypesText.Contains(routine)
        //                                               select c).ToList();

        //            foreach (MWQMSample mwqmSample in mwqmSampleList)
        //            {
        //                mwqmSample.UseForOpenData = true;
        //            }

        //            try
        //            {
        //                db2.SaveChanges();
        //            }
        //            catch (Exception ex)
        //            {
        //                return ReturnError(ex.Message + " InnerError: " + (ex.InnerException != null ? ex.InnerException.Message : ""));
        //            }
        //        }

        //        ts.Complete();
        //    }

        //    return ReturnError("");
        //}
        //public MWQMRunModel MarkAllRoutineSamplesAsNotUseForOpenDataDB(int MWQMRunTVItemID)
        //{
        //    ContactOK contactOK = IsContactOK();
        //    if (!string.IsNullOrEmpty(contactOK.Error))
        //        return ReturnError(contactOK.Error);

        //    string routine = ((int)SampleTypeEnum.Routine).ToString() + ",";

        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        using (CSSPDBEntities db2 = new CSSPDBEntities())
        //        {
        //            List<MWQMSample> mwqmSampleList = (from c in db2.MWQMSamples
        //                                               where c.MWQMRunTVItemID == MWQMRunTVItemID
        //                                               && c.SampleTypesText.Contains(routine)
        //                                               select c).ToList();

        //            foreach (MWQMSample mwqmSample in mwqmSampleList)
        //            {
        //                mwqmSample.UseForOpenData = false;
        //            }

        //            try
        //            {
        //                db2.SaveChanges();
        //            }
        //            catch (Exception ex)
        //            {
        //                return ReturnError(ex.Message + " InnerError: " + (ex.InnerException != null ? ex.InnerException.Message : ""));
        //            }
        //        }

        //        ts.Complete();
        //    }

        //    return ReturnError("");
        //}
        public MWQMRunModel PostAddMWQMRunDB(MWQMRunModel mwqmRunModel)
        {
            string retStr = MWQMRunModelOK(mwqmRunModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMRunModel mwqmRunModelExist = GetMWQMRunModelExistDB(mwqmRunModel);
            if (string.IsNullOrWhiteSpace(mwqmRunModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMRun));

            MWQMRun mwqmRunNew = new MWQMRun();
            retStr = FillMWQMRun(mwqmRunNew, mwqmRunModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMRuns.Add(mwqmRunNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMRuns", mwqmRunNew.MWQMRunID, LogCommandEnum.Add, mwqmRunNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    MWQMRunLanguageModel mwqmRunLanguageModel = new MWQMRunLanguageModel()
                    {
                        DBCommand = DBCommandEnum.Original,
                        MWQMRunID = mwqmRunNew.MWQMRunID,
                        Language = Lang,
                        RunComment = mwqmRunModel.RunComment,
                        TranslationStatusRunComment = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                        RunWeatherComment = mwqmRunModel.RunWeatherComment,
                        TranslationStatusRunWeatherComment = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    if (string.IsNullOrWhiteSpace(mwqmRunLanguageModel.RunComment))
                    {
                        mwqmRunLanguageModel.RunComment = ServiceRes.Empty;
                    }
                    if (string.IsNullOrWhiteSpace(mwqmRunLanguageModel.RunWeatherComment))
                    {
                        mwqmRunLanguageModel.RunWeatherComment = ServiceRes.Empty;
                    }

                    MWQMRunLanguageModel mwqmRunLanguageModelRet = _MWQMRunLanguageService.PostAddMWQMRunLanguageDB(mwqmRunLanguageModel);
                    if (!string.IsNullOrEmpty(mwqmRunLanguageModelRet.Error))
                        return ReturnError(mwqmRunLanguageModelRet.Error);
                }

                ts.Complete();
            }
            return GetMWQMRunModelWithMWQMRunIDDB(mwqmRunNew.MWQMRunID);
        }
        public MWQMRunModel PostDeleteMWQMRunTVItemIDDB(int MWQMRunTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMRun mwqmRunToDelete = GetMWQMRunWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
            if (mwqmRunToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMRun));

            using (TransactionScope ts = new TransactionScope())
            {
                List<LabSheetModel> labSheetModelList = GetLabSheetModelListWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
                foreach (LabSheetModel labSheetModel in labSheetModelList)
                {
                    string retStr2 = ChangeLabSheetAndRemoveLabSheetDetail(labSheetModel);
                    if (!string.IsNullOrWhiteSpace(retStr2))
                        return ReturnError(retStr2);

                }

                db.MWQMRuns.Remove(mwqmRunToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMRuns", mwqmRunToDelete.MWQMRunID, LogCommandEnum.Delete, mwqmRunToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                int CountMWQMSampleWithMWQMRun = GetMWQMSampleCountWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
                if (CountMWQMSampleWithMWQMRun > 0)
                    return ReturnError(ServiceRes.AllSamplesHasToBeDeletedManuallyBeforeBeingAbleToDeleteTheRun);

                TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(MWQMRunTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnError(tvItemModelRet.Error);


                ts.Complete();
            }
            return ReturnError("");
        }
        public MWQMRunModel PostUpdateMWQMRunDB(MWQMRunModel mwqmRunModel)
        {
            string retStr = MWQMRunModelOK(mwqmRunModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMRun mwqmRunToUpdate = GetMWQMRunWithMWQMRunIDDB(mwqmRunModel.MWQMRunID);
            if (mwqmRunToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMRun));

            retStr = FillMWQMRun(mwqmRunToUpdate, mwqmRunModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMRuns", mwqmRunToUpdate.MWQMRunID, LogCommandEnum.Change, mwqmRunToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        MWQMRunLanguageModel mwqmRunLanguageModel = new MWQMRunLanguageModel()
                        {
                            DBCommand = DBCommandEnum.Original,
                            MWQMRunID = mwqmRunModel.MWQMRunID,
                            Language = Lang,
                            RunComment = mwqmRunModel.RunComment,
                            TranslationStatusRunComment = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                            RunWeatherComment = mwqmRunModel.RunWeatherComment,
                            TranslationStatusRunWeatherComment = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                        };

                        if (string.IsNullOrWhiteSpace(mwqmRunModel.RunComment))
                        {
                            mwqmRunModel.RunComment = ServiceRes.Empty;
                        }
                        if (string.IsNullOrWhiteSpace(mwqmRunModel.RunWeatherComment))
                        {
                            mwqmRunModel.RunWeatherComment = ServiceRes.Empty;
                        }

                        MWQMRunLanguageModel mwqmRunLanguageModelRet = _MWQMRunLanguageService.PostUpdateMWQMRunLanguageDB(mwqmRunLanguageModel);
                        if (!string.IsNullOrEmpty(mwqmRunLanguageModelRet.Error))
                            return ReturnError(mwqmRunLanguageModelRet.Error);
                    }
                }

                ts.Complete();
            }
            return GetMWQMRunModelWithMWQMRunIDDB(mwqmRunToUpdate.MWQMRunID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
