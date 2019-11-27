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

namespace CSSPDBDLL.Services
{
    public class MWQMSubsectorService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public MWQMSubsectorLanguageService _MWQMSubsectorLanguageService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        public MWQMSiteService _MWQMSiteService { get; private set; }
        public MWQMRunService _MWQMRunService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public UseOfSiteService _UseOfSiteService { get; private set; }
        public AppTaskService _AppTaskService { get; private set; }
        public ClimateSiteService _ClimateSiteService { get; private set; }
        public HydrometricSiteService _HydrometricSiteService { get; private set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _MWQMSubsectorLanguageService = new MWQMSubsectorLanguageService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
            _MWQMSiteService = new MWQMSiteService(LanguageRequest, User);
            _MWQMRunService = new MWQMRunService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _UseOfSiteService = new UseOfSiteService(LanguageRequest, User);
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _ClimateSiteService = new ClimateSiteService(LanguageRequest, User);
            _HydrometricSiteService = new HydrometricSiteService(LanguageRequest, User);
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
        public string MWQMSubsectorModelOK(MWQMSubsectorModel mwqmSubsectorModel)
        {
            string retStr = FieldCheckNotZeroInt(mwqmSubsectorModel.MWQMSubsectorTVItemID, ServiceRes.MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(mwqmSubsectorModel.SubsectorHistoricKey, ServiceRes.SubsectorHistoricKey, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(mwqmSubsectorModel.SubsectorDesc, ServiceRes.SubsectorDesc, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMWQMSubsector(MWQMSubsector mwqmSubsector, MWQMSubsectorModel mwqmSubsectorModel, ContactOK contactOK)
        {
            mwqmSubsector.MWQMSubsectorTVItemID = mwqmSubsectorModel.MWQMSubsectorTVItemID;
            mwqmSubsector.SubsectorHistoricKey = mwqmSubsectorModel.SubsectorHistoricKey;
            mwqmSubsector.TideLocationSIDText = mwqmSubsectorModel.TideLocationSIDText;
            mwqmSubsector.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mwqmSubsector.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mwqmSubsector.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public List<TVItemModel> GetAdjacentSubsectors(int SubsectorTVItemID, int NumberOnEachSide)
        {
            List<TVItemModel> tvItemModelAdjacentSubsectors = new List<TVItemModel>();
            TVItemModel tvItemModelCurrentSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelCurrentSubsector.Error))
            {
                return new List<TVItemModel>();
            }

            TVItemModel tvItemModelProvince = new TVItemModel();
            List<TVItemModel> tvItemModelParentList = _TVItemService.GetParentsTVItemModelList(tvItemModelCurrentSubsector.TVPath);

            foreach (TVItemModel tvItemModel in tvItemModelParentList)
            {
                if (tvItemModel.TVType == TVTypeEnum.Province)
                {
                    tvItemModelProvince = tvItemModel;
                    break;
                }
            }

            int indexOfCurrent = 0;
            List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelProvince.TVItemID, TVTypeEnum.Subsector).OrderBy(c => c.TVText).ToList();
            for (int i = 0, count = tvItemModelList.Count(); i < count; i++)
            {
                if (tvItemModelCurrentSubsector.TVItemID == tvItemModelList[i].TVItemID)
                {
                    indexOfCurrent = i;
                    break;
                }
            }

            for (int i = (indexOfCurrent - NumberOnEachSide); i <= (indexOfCurrent + NumberOnEachSide); i++)
            {
                if (i < 0 || i > tvItemModelList.Count - 1 || i == indexOfCurrent)
                {
                    continue;
                }

                tvItemModelAdjacentSubsectors.Add(tvItemModelList[i]);

            }

            return tvItemModelAdjacentSubsectors;
        }
        public MWQMSubsectorAnalysisModel GetMWQMSubsectorAnalysisModel(int SubsectorTVItemID)
        {
            MWQMSubsectorAnalysisModel mwqmSubsectorAnalysisModel = new MWQMSubsectorAnalysisModel();

            TVItemModel tvItemModelSS = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSS.Error))
            {
                return mwqmSubsectorAnalysisModel;
            }

            MWQMSubsectorModel mwqmSubsectorModel = (from c in db.MWQMSubsectors
                                                     from cl in db.MWQMSubsectorLanguages
                                                     where c.MWQMSubsectorID == cl.MWQMSubsectorID
                                                     && c.MWQMSubsectorTVItemID == SubsectorTVItemID
                                                     && cl.Language == (int)LanguageRequest
                                                     select new MWQMSubsectorModel
                                                     {
                                                         Error = "",
                                                         MWQMSubsectorID = c.MWQMSubsectorID,
                                                         MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                                                         MWQMSubsectorTVText = tvItemModelSS.TVText,
                                                         SubsectorHistoricKey = c.SubsectorHistoricKey,
                                                         SubsectorDesc = cl.SubsectorDesc,
                                                         TideLocationSIDText = c.TideLocationSIDText,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorModel.Error))
            {
                return mwqmSubsectorAnalysisModel;
            }

            List<MWQMSiteAnalysisModel> mwqmSiteAnalysisModelList = (from c in db.MWQMSites
                                                                     from t in db.TVItems
                                                                     from tl in db.TVItemLanguages
                                                                     where t.TVItemID == tl.TVItemID
                                                                     && c.MWQMSiteTVItemID == t.TVItemID
                                                                     && t.ParentID == SubsectorTVItemID
                                                                     && tl.Language == (int)LanguageRequest
                                                                     && t.TVType == (int)TVTypeEnum.MWQMSite
                                                                     orderby tl.TVText
                                                                     select new MWQMSiteAnalysisModel
                                                                     {
                                                                         Error = "",
                                                                         MWQMSiteID = c.MWQMSiteID,
                                                                         MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                         MWQMSiteTVText = tl.TVText,
                                                                         MWQMSiteNumber = c.MWQMSiteNumber,
                                                                         MWQMSiteDescription = c.MWQMSiteDescription,
                                                                         MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)c.MWQMSiteLatestClassification,
                                                                         Ordinal = c.Ordinal,
                                                                         IsActive = t.IsActive,
                                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                     }).ToList();

            List<MWQMRunAnalysisModel> mwqmRunAnalysisModelList = (from c in db.MWQMRuns
                                                                   from cl in db.MWQMRunLanguages
                                                                   from t in db.TVItems
                                                                   from tl in db.TVItemLanguages
                                                                   where t.TVItemID == tl.TVItemID
                                                                   && c.MWQMRunID == cl.MWQMRunID
                                                                   && c.MWQMRunTVItemID == t.TVItemID
                                                                   && cl.Language == (int)LanguageRequest
                                                                   && t.ParentID == SubsectorTVItemID
                                                                   && tl.Language == (int)LanguageRequest
                                                                   && t.TVType == (int)TVTypeEnum.MWQMRun
                                                                   && c.RunSampleType == (int)SampleTypeEnum.Routine
                                                                   orderby c.DateTime_Local descending, c.RunNumber descending
                                                                   select new MWQMRunAnalysisModel
                                                                   {
                                                                       Error = "",
                                                                       MWQMRunID = c.MWQMRunID,
                                                                       SubsectorTVItemID = c.SubsectorTVItemID,
                                                                       SubsectorTVText = tvItemModelSS.TVText,
                                                                       MWQMRunTVItemID = (int)c.MWQMRunTVItemID,
                                                                       MWQMRunTVText = tl.TVText,
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
                                                                       RainDay0_mm = (float?)c.RainDay0_mm,
                                                                       RainDay1_mm = (float?)c.RainDay1_mm,
                                                                       RainDay2_mm = (float?)c.RainDay2_mm,
                                                                       RainDay3_mm = (float?)c.RainDay3_mm,
                                                                       RainDay4_mm = (float?)c.RainDay4_mm,
                                                                       RainDay5_mm = (float?)c.RainDay5_mm,
                                                                       RainDay6_mm = (float?)c.RainDay6_mm,
                                                                       RainDay7_mm = (float?)c.RainDay7_mm,
                                                                       RainDay8_mm = (float?)c.RainDay8_mm,
                                                                       RainDay9_mm = (float?)c.RainDay9_mm,
                                                                       RainDay10_mm = (float?)c.RainDay10_mm,
                                                                       RemoveFromStat = c.RemoveFromStat,
                                                                       RunComment = cl.RunComment,
                                                                       RunWeatherComment = cl.RunWeatherComment,
                                                                       IsActive = t.IsActive,
                                                                       ValidatorContactTVText = (from cl in db.TVItemLanguages
                                                                                                 where cl.TVItemID == c.LabSampleApprovalContactTVItemID
                                                                                                 && cl.Language == (int)LanguageRequest
                                                                                                 select cl.TVText).FirstOrDefault(),
                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                   }).ToList();

            mwqmSubsectorAnalysisModel.MWQMSubsectorModel = mwqmSubsectorModel;
            mwqmSubsectorAnalysisModel.MWQMSiteAnalysisModelList = mwqmSiteAnalysisModelList;
            mwqmSubsectorAnalysisModel.MWQMRunAnalysisModelList = mwqmRunAnalysisModelList;

            List<int> SiteTVItemIDList = mwqmSiteAnalysisModelList.Select(c => c.MWQMSiteTVItemID).Distinct().ToList();
            List<int> RunTVItemIDList = mwqmRunAnalysisModelList.Select(c => c.MWQMRunTVItemID).Distinct().ToList();

            List<MWQMSampleAnalysisModel> mwqmSampleAnalysisModelList = new List<MWQMSampleAnalysisModel>();
            if (mwqmSiteAnalysisModelList.Count > 0 && mwqmRunAnalysisModelList.Count > 0)
            {
                string routineNumberText = ((int)SampleTypeEnum.Routine).ToString() + ",";
                mwqmSampleAnalysisModelList = (from c in db.MWQMSamples
                                               from cl in db.MWQMSampleLanguages
                                               from siteTVItemID in SiteTVItemIDList
                                               from runTVItemID in RunTVItemIDList
                                               where c.MWQMSampleID == cl.MWQMSampleID
                                               && c.MWQMRunTVItemID == runTVItemID
                                               && c.MWQMSiteTVItemID == siteTVItemID
                                               && cl.Language == (int)LanguageRequest
                                               && c.SampleTypesText.Contains(routineNumberText)
                                               orderby c.SampleDateTime_Local descending
                                               select new MWQMSampleAnalysisModel
                                               {
                                                   Error = "",
                                                   MWQMSampleID = c.MWQMSampleID,
                                                   MWQMSampleNote = cl.MWQMSampleNote,
                                                   MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                   MWQMSiteTVText = (from sl in db.TVItemLanguages
                                                                     where sl.TVItemID == siteTVItemID
                                                                     && sl.Language == (int)LanguageRequest
                                                                     select sl.TVText).FirstOrDefault(),
                                                   MWQMRunTVItemID = c.MWQMRunTVItemID,
                                                   MWQMRunTVText = (from sl in db.TVItemLanguages
                                                                    where sl.TVItemID == runTVItemID
                                                                    && sl.Language == (int)LanguageRequest
                                                                    select sl.TVText).FirstOrDefault(),
                                                   Depth_m = c.Depth_m,
                                                   FecCol_MPN_100ml = c.FecCol_MPN_100ml,
                                                   PH = c.PH,
                                                   Salinity_PPT = c.Salinity_PPT,
                                                   SampleDateTime_Local = c.SampleDateTime_Local,
                                                   WaterTemp_C = c.WaterTemp_C,
                                                   SampleTypesText = c.SampleTypesText,
                                                   Tube_10 = c.Tube_10,
                                                   Tube_1_0 = c.Tube_1_0,
                                                   Tube_0_1 = c.Tube_0_1,
                                                   ProcessedBy = c.ProcessedBy,
                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                               }).ToList();

                foreach (MWQMSampleAnalysisModel mwqmSampleAnalysisModel in mwqmSampleAnalysisModelList)
                {
                    if (!string.IsNullOrWhiteSpace(mwqmSampleAnalysisModel.SampleTypesText))
                    {
                        if (mwqmSampleAnalysisModel.SampleTypesText.Contains(((int)SampleTypeEnum.Routine).ToString() + ","))
                        {
                            mwqmSampleAnalysisModel.SampleTypesText = SampleTypeEnum.Routine.ToString();
                        }
                        else
                        {
                            string FirstSampleTypeNumber = mwqmSampleAnalysisModel.SampleTypesText.Substring(0, mwqmSampleAnalysisModel.SampleTypesText.IndexOf(","));
                            mwqmSampleAnalysisModel.SampleTypesText = ((SampleTypeEnum)(int.Parse(FirstSampleTypeNumber))).ToString();
                        }
                    }
                }

                mwqmSubsectorAnalysisModel.MWQMSampleAnalysisModelList = mwqmSampleAnalysisModelList;

            }


            return mwqmSubsectorAnalysisModel;
        }
        public int GetMWQMSubsectorModelCountDB()
        {
            int MWQMSubsectorModelCount = (from c in db.MWQMSubsectors
                                           select c).Count();

            return MWQMSubsectorModelCount;
        }
        public List<MWQMSubsectorModel> GetAllMWQMSubsectorModelDB()
        {
            List<MWQMSubsectorModel> mwqmSubsectorModelList = (from c in db.MWQMSubsectors
                                                               let mwqmsubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                               let subsectorDesc = (from cl in db.MWQMSubsectorLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSubsectorID == c.MWQMSubsectorID select cl.SubsectorDesc).FirstOrDefault<string>()
                                                               select new MWQMSubsectorModel
                                                               {
                                                                   Error = "",
                                                                   MWQMSubsectorID = c.MWQMSubsectorID,
                                                                   MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                                                                   MWQMSubsectorTVText = mwqmsubsectorName,
                                                                   SubsectorHistoricKey = c.SubsectorHistoricKey,
                                                                   SubsectorDesc = subsectorDesc,
                                                                   TideLocationSIDText = c.TideLocationSIDText,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                               }).ToList<MWQMSubsectorModel>();

            return mwqmSubsectorModelList;
        }
        public MWQMSubsectorModel GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(int MWQMSubsectorTVItemID)
        {
            MWQMSubsectorModel mwqmSubsectorModel = (from c in db.MWQMSubsectors
                                                     let mwqmsubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                     let subsectorDesc = (from cl in db.MWQMSubsectorLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSubsectorID == c.MWQMSubsectorID select cl.SubsectorDesc).FirstOrDefault<string>()
                                                     where c.MWQMSubsectorTVItemID == MWQMSubsectorTVItemID
                                                     select new MWQMSubsectorModel
                                                     {
                                                         Error = "",
                                                         MWQMSubsectorID = c.MWQMSubsectorID,
                                                         MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                                                         MWQMSubsectorTVText = mwqmsubsectorName,
                                                         SubsectorHistoricKey = c.SubsectorHistoricKey,
                                                         SubsectorDesc = subsectorDesc,
                                                         TideLocationSIDText = c.TideLocationSIDText,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<MWQMSubsectorModel>();
            if (mwqmSubsectorModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSubsector, ServiceRes.MWQMSubsectorTVItemID, MWQMSubsectorTVItemID));

            return mwqmSubsectorModel;
        }
        public MWQMSubsectorModel GetMWQMSubsectorModelWithMWQMSubsectorIDDB(int MWQMSubsectorID)
        {
            MWQMSubsectorModel mwqmSubsectorModel = (from c in db.MWQMSubsectors
                                                     let mwqmSubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                     let subsectorDesc = (from cl in db.MWQMSubsectorLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSubsectorID == c.MWQMSubsectorID select cl.SubsectorDesc).FirstOrDefault<string>()
                                                     where c.MWQMSubsectorID == MWQMSubsectorID
                                                     select new MWQMSubsectorModel
                                                     {
                                                         Error = "",
                                                         MWQMSubsectorID = c.MWQMSubsectorID,
                                                         MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                                                         MWQMSubsectorTVText = mwqmSubsectorName,
                                                         SubsectorHistoricKey = c.SubsectorHistoricKey,
                                                         SubsectorDesc = subsectorDesc,
                                                         TideLocationSIDText = c.TideLocationSIDText,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<MWQMSubsectorModel>();
            if (mwqmSubsectorModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSubsector, ServiceRes.MWQMSubsectorID, MWQMSubsectorID));

            return mwqmSubsectorModel;
        }
        public MWQMSubsectorModel GetMWQMSubsectorModelWithSubsectorHistoricKeyDB(string SubsectorHistoricKey)
        {
            MWQMSubsectorModel mwqmSubsectorModel = (from c in db.MWQMSubsectors
                                                     let mwqmSubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                     let subsectorDesc = (from cl in db.MWQMSubsectorLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSubsectorID == c.MWQMSubsectorID select cl.SubsectorDesc).FirstOrDefault<string>()
                                                     where c.SubsectorHistoricKey == SubsectorHistoricKey
                                                     select new MWQMSubsectorModel
                                                     {
                                                         Error = "",
                                                         MWQMSubsectorID = c.MWQMSubsectorID,
                                                         MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                                                         MWQMSubsectorTVText = mwqmSubsectorName,
                                                         SubsectorHistoricKey = c.SubsectorHistoricKey,
                                                         SubsectorDesc = subsectorDesc,
                                                         TideLocationSIDText = c.TideLocationSIDText,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<MWQMSubsectorModel>();
            if (mwqmSubsectorModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSubsector, ServiceRes.SubsectorHistoricKey, SubsectorHistoricKey));

            return mwqmSubsectorModel;
        }
        public MWQMSubsector GetMWQMSubsectorWithMWQMSubsectorIDDB(int MWQMSubsectorID)
        {
            MWQMSubsector mwqmSubsector = (from c in db.MWQMSubsectors
                                           where c.MWQMSubsectorID == MWQMSubsectorID
                                           select c).FirstOrDefault<MWQMSubsector>();

            return mwqmSubsector;
        }
        public MWQMSubsector GetMWQMSubsectorExistDB(MWQMSubsectorModel mwqmSubsectorModel)
        {
            MWQMSubsector mwqmSubsector = (from c in db.MWQMSubsectors
                                           where c.MWQMSubsectorTVItemID == mwqmSubsectorModel.MWQMSubsectorTVItemID
                                           && c.SubsectorHistoricKey == mwqmSubsectorModel.SubsectorHistoricKey
                                           select c).FirstOrDefault<MWQMSubsector>();

            return mwqmSubsector;
        }
        public MWQMSubsectorClimateSites GetMWQMSubsectorClimateSitesDB(int MWQMSubsectorTVItemID, float Radius)
        {
            MWQMSubsectorClimateSites mwqmSubsectorClimateSites = new MWQMSubsectorClimateSites();

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(MWQMSubsectorTVItemID, TVTypeEnum.Subsector, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelList.Count == 0)
            {
                mwqmSubsectorClimateSites.Error = string.Format(ServiceRes._ShouldNotBeNullOrEmpty, "MapInfoPointModelList with MWQMSubsectorTVItemID = [" + MWQMSubsectorTVItemID + "]");
                return mwqmSubsectorClimateSites;
            }

            // Getting MWQMSubsectorModel
            MWQMSubsectorWithLatLngModel mwqmSubsectorWithLatLngModel = (from c in db.MWQMSubsectors
                                                                         let mwqmsubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                         let subsectorDesc = (from cl in db.MWQMSubsectorLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSubsectorID == c.MWQMSubsectorID select cl.SubsectorDesc).FirstOrDefault<string>()
                                                                         where c.MWQMSubsectorTVItemID == MWQMSubsectorTVItemID
                                                                         select new MWQMSubsectorWithLatLngModel
                                                                         {
                                                                             Error = "",
                                                                             MWQMSubsectorID = c.MWQMSubsectorID,
                                                                             MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                                                                             MWQMSubsectorTVText = mwqmsubsectorName,
                                                                             SubsectorHistoricKey = c.SubsectorHistoricKey,
                                                                             SubsectorDesc = subsectorDesc,
                                                                             TideLocationSIDText = c.TideLocationSIDText,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                         }).FirstOrDefault<MWQMSubsectorWithLatLngModel>();

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorWithLatLngModel.Error))
            {
                mwqmSubsectorClimateSites.Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSubsector, ServiceRes.MWQMSubsectorTVItemID, MWQMSubsectorTVItemID);
                return mwqmSubsectorClimateSites;
            }
            mwqmSubsectorWithLatLngModel.Lat = (float)mapInfoPointModelList[0].Lat;
            mwqmSubsectorWithLatLngModel.Lng = (float)mapInfoPointModelList[0].Lng;
            mwqmSubsectorClimateSites.MWQMSubsectorWithLatLngModel = mwqmSubsectorWithLatLngModel;

            List<int> useClimateSiteTVItemIDList = (from c in db.ClimateSites
                                                    from u in db.UseOfSites
                                                    where c.ClimateSiteTVItemID == u.SiteTVItemID
                                                    && u.TVType == (int)TVTypeEnum.ClimateSite
                                                    && u.SubsectorTVItemID == MWQMSubsectorTVItemID
                                                    select c.ClimateSiteTVItemID).Distinct().ToList();

            List<int> distClimateSiteTVItemIDList = _MapInfoService.GetMapInfoModelWithinCircleWithTVTypeAndMapInfoDrawTypeDB((float)mwqmSubsectorWithLatLngModel.Lat, (float)mwqmSubsectorWithLatLngModel.Lng,
                (float)Radius, TVTypeEnum.ClimateSite, MapInfoDrawTypeEnum.Point).Select(c => c.TVItemID).Distinct().ToList();

            List<int> ClimateSiteTVItemIDList = useClimateSiteTVItemIDList.Concat(distClimateSiteTVItemIDList).Distinct().ToList();

            List<ClimateSiteWithLatLngAndOrdinalModel> ClimateSiteWithLatLngAndOrdinalModelList = (from c in db.ClimateSites
                                                                                                   from id in ClimateSiteTVItemIDList
                                                                                                   let coord = (from mi in db.MapInfos
                                                                                                                from mip in db.MapInfoPoints
                                                                                                                where mi.MapInfoID == mip.MapInfoID
                                                                                                                && mi.TVItemID == c.ClimateSiteTVItemID
                                                                                                                && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                                                                                                && mi.TVType == (int)TVTypeEnum.ClimateSite
                                                                                                                select new { mip.Lat, mip.Lng, mip.MapInfoID }).FirstOrDefault()
                                                                                                   let climateSiteTVText = (from cl in db.TVItemLanguages
                                                                                                                            where cl.TVItemID == c.ClimateSiteTVItemID
                                                                                                                            && cl.Language == (int)LanguageRequest
                                                                                                                            select cl.TVText).FirstOrDefault()
                                                                                                   where c.ClimateSiteTVItemID == id
                                                                                                   orderby climateSiteTVText
                                                                                                   select new ClimateSiteWithLatLngAndOrdinalModel
                                                                                                   {
                                                                                                       Error = "",
                                                                                                       ClimateSiteID = c.ClimateSiteID,
                                                                                                       ClimateSiteTVItemID = c.ClimateSiteTVItemID,
                                                                                                       ClimateID = c.ClimateID,
                                                                                                       ClimateSiteName = c.ClimateSiteName,
                                                                                                       DailyEndDate_Local = c.DailyEndDate_Local,
                                                                                                       DailyNow = c.DailyNow,
                                                                                                       DailyStartDate_Local = c.DailyStartDate_Local,
                                                                                                       ECDBID = c.ECDBID,
                                                                                                       Elevation_m = c.Elevation_m,
                                                                                                       File_desc = c.File_desc,
                                                                                                       HourlyEndDate_Local = c.HourlyEndDate_Local,
                                                                                                       HourlyNow = c.HourlyNow,
                                                                                                       HourlyStartDate_Local = c.HourlyStartDate_Local,
                                                                                                       IsQuebecSite = c.IsQuebecSite,
                                                                                                       IsCoCoRaHS = c.IsCoCoRaHS,
                                                                                                       MonthlyEndDate_Local = c.MonthlyEndDate_Local,
                                                                                                       MonthlyNow = c.MonthlyNow,
                                                                                                       MonthlyStartDate_Local = c.MonthlyStartDate_Local,
                                                                                                       Province = c.Province,
                                                                                                       TCID = c.TCID,
                                                                                                       TimeOffset_hour = c.TimeOffset_hour,
                                                                                                       WMOID = c.WMOID,
                                                                                                       Lat = (float)coord.Lat,
                                                                                                       Lng = (float)coord.Lng,
                                                                                                       ClimateSiteTVText = climateSiteTVText,
                                                                                                       Ordinal = 0,
                                                                                                       Distance_km = 0,
                                                                                                       MapInfoID = coord.MapInfoID,
                                                                                                       YearsOfUseText = "",
                                                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                                   }).ToList();


            List<UseOfSite> useOfSiteList = (from c in db.UseOfSites
                                             where c.SubsectorTVItemID == MWQMSubsectorTVItemID
                                             && c.TVType == (int)TVTypeEnum.ClimateSite
                                             orderby c.SiteTVItemID, c.StartYear
                                             select c).ToList();


            foreach (ClimateSiteWithLatLngAndOrdinalModel climateSiteWithLatLngAndOrdinalModel in ClimateSiteWithLatLngAndOrdinalModelList)
            {
                climateSiteWithLatLngAndOrdinalModel.Distance_km = (float)(_MapInfoService.CalculateDistance((double)mwqmSubsectorWithLatLngModel.Lat * d2r, (double)mwqmSubsectorWithLatLngModel.Lng * d2r, (double)climateSiteWithLatLngAndOrdinalModel.Lat * d2r, (double)climateSiteWithLatLngAndOrdinalModel.Lng * d2r, (double)R) / 1000);
                foreach (UseOfSite useOfSite in useOfSiteList)
                {
                    if (climateSiteWithLatLngAndOrdinalModel.ClimateSiteTVItemID == useOfSite.SiteTVItemID)
                    {
                        if (string.IsNullOrWhiteSpace(climateSiteWithLatLngAndOrdinalModel.YearsOfUseText))
                        {
                            climateSiteWithLatLngAndOrdinalModel.YearsOfUseText = useOfSite.StartYear.ToString();
                        }
                        else
                        {
                            climateSiteWithLatLngAndOrdinalModel.YearsOfUseText = climateSiteWithLatLngAndOrdinalModel.YearsOfUseText + "," + useOfSite.StartYear;
                        }
                        if (useOfSite.StartYear != useOfSite.EndYear)
                        {
                            climateSiteWithLatLngAndOrdinalModel.YearsOfUseText = climateSiteWithLatLngAndOrdinalModel.YearsOfUseText + "-" + useOfSite.EndYear;
                        }
                    }
                }

            }
            using (CoCoRaHSEntities cocodb = new CoCoRaHSEntities())
            {

                foreach (ClimateSiteWithLatLngAndOrdinalModel climateSiteWithLatLngAndOrdinalModel in ClimateSiteWithLatLngAndOrdinalModelList)
                {
                    if (climateSiteWithLatLngAndOrdinalModel.IsCoCoRaHS != null && climateSiteWithLatLngAndOrdinalModel.IsCoCoRaHS == true)
                    {
                        List<CoCoRaHSValue> cocoRaHSValueList = (from c in cocodb.CoCoRaHSValues
                                                                 from s in cocodb.CoCoRaHSSites
                                                                 where c.CoCoRaHSSiteID == s.CoCoRaHSSiteID
                                                                 && s.StationNumber == climateSiteWithLatLngAndOrdinalModel.ClimateID
                                                                 orderby c.ObservationDateAndTime descending
                                                                 select c).ToList();

                        DateTime FirstDate = (from c in cocoRaHSValueList
                                              orderby c.ObservationDateAndTime
                                              select c.ObservationDateAndTime).FirstOrDefault();

                        DateTime LastDate = (from c in cocoRaHSValueList
                                             orderby c.ObservationDateAndTime descending
                                             select c.ObservationDateAndTime).FirstOrDefault();

                        TimeSpan ts = new TimeSpan(LastDate.Ticks - FirstDate.Ticks);

                        double Days = ts.TotalDays;
                        double CountValue = cocoRaHSValueList.Count;

                        double AverageHour = (from c in cocoRaHSValueList
                                              select c.ObservationDateAndTime.Hour).Average();

                        if (Days > 0 && CountValue > 0)
                        {
                            double Weeks = Days / 7.0D;
                            climateSiteWithLatLngAndOrdinalModel.CoCoRaHSSamplesPerWeek = (float)(CountValue / Weeks);
                            climateSiteWithLatLngAndOrdinalModel.CoCoRaHSSampleTimeAverage = (float)AverageHour;
                        }
                    }
                }
            }

            mwqmSubsectorClimateSites.ClimateSiteModelUsedAndWithinDistanceModelList = ClimateSiteWithLatLngAndOrdinalModelList;

            return mwqmSubsectorClimateSites;
        }
        public List<ClimateSitesAndRains> GetMWQMSubsectorClimateSitesAndValuesForAParicularRunsDB(int MWQMSubsectorTVItemID, int MWQMRunTVItemID)
        {
            List<ClimateSitesAndRains> climateSitesAndRainsList = new List<ClimateSitesAndRains>();

            // Getting MWQMSubsectorModel
            MWQMSubsectorModel mwqmSubsectorModel = GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(MWQMSubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorModel.Error))
            {
                return new List<ClimateSitesAndRains>();
            }

            // Getting MWQMRunModelList from the SubsectorTVItemID
            MWQMRunModel mwqmRunModel = _MWQMRunService.GetMWQMRunModelWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqmRunModel.Error))
            {
                return new List<ClimateSitesAndRains>();
            }


            // Getting ClimateSites within distance and the ones used for the subsector
            List<ClimateSiteModel> climateSiteModelUseInSubsectorList = (from c in db.ClimateSites
                                                                         from u in db.UseOfSites
                                                                         let climateSiteTVText = (from cl in db.TVItemLanguages
                                                                                                  where cl.TVItemID == c.ClimateSiteTVItemID
                                                                                                  && cl.Language == (int)LanguageRequest
                                                                                                  select cl.TVText).FirstOrDefault()
                                                                         where c.ClimateSiteTVItemID == u.SiteTVItemID
                                                                         && u.TVType == (int)TVTypeEnum.ClimateSite
                                                                         && u.SubsectorTVItemID == MWQMSubsectorTVItemID
                                                                         orderby u.Ordinal
                                                                         select new ClimateSiteModel
                                                                         {
                                                                             Error = "",
                                                                             ClimateSiteID = c.ClimateSiteID,
                                                                             ClimateSiteTVItemID = c.ClimateSiteTVItemID,
                                                                             ClimateID = c.ClimateID,
                                                                             ClimateSiteName = c.ClimateSiteName,
                                                                             DailyEndDate_Local = c.DailyEndDate_Local,
                                                                             DailyNow = c.DailyNow,
                                                                             DailyStartDate_Local = c.DailyStartDate_Local,
                                                                             ECDBID = c.ECDBID,
                                                                             Elevation_m = c.Elevation_m,
                                                                             File_desc = c.File_desc,
                                                                             HourlyEndDate_Local = c.HourlyEndDate_Local,
                                                                             HourlyNow = c.HourlyNow,
                                                                             HourlyStartDate_Local = c.HourlyStartDate_Local,
                                                                             IsQuebecSite = c.IsQuebecSite,
                                                                             IsCoCoRaHS = c.IsCoCoRaHS,
                                                                             MonthlyEndDate_Local = c.MonthlyEndDate_Local,
                                                                             MonthlyNow = c.MonthlyNow,
                                                                             MonthlyStartDate_Local = c.MonthlyStartDate_Local,
                                                                             Province = c.Province,
                                                                             TCID = c.TCID,
                                                                             TimeOffset_hour = c.TimeOffset_hour,
                                                                             WMOID = c.WMOID,
                                                                             ClimateSiteTVText = climateSiteTVText,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                         }).ToList();

            foreach (ClimateSiteModel climateSiteModel in climateSiteModelUseInSubsectorList)
            {
                DateTime RunDate = new DateTime(mwqmRunModel.DateTime_Local.Year, mwqmRunModel.DateTime_Local.Month, mwqmRunModel.DateTime_Local.Day);
                DateTime RunDateMinus10 = RunDate.AddDays(-10);

                List<ClimateDataValueModel> climateDataValueModelList = (from c in db.ClimateDataValues
                                                                         where c.ClimateSiteID == climateSiteModel.ClimateSiteID
                                                                         && c.DateTime_Local <= RunDate
                                                                         && c.DateTime_Local >= RunDateMinus10
                                                                         && c.StorageDataType == (int)StorageDataTypeEnum.Archived
                                                                         select new ClimateDataValueModel
                                                                         {
                                                                             Error = "",
                                                                             ClimateSiteID = c.ClimateSiteID,
                                                                             ClimateDataValueID = c.ClimateDataValueID,
                                                                             DateTime_Local = c.DateTime_Local,
                                                                             Keep = c.Keep,
                                                                             StorageDataType = (StorageDataTypeEnum)c.StorageDataType,
                                                                             HasBeenRead = c.HasBeenRead,
                                                                             CoolDegDays_C = c.CoolDegDays_C,
                                                                             DirMaxGust_0North = c.DirMaxGust_0North,
                                                                             HeatDegDays_C = c.HeatDegDays_C,
                                                                             MaxTemp_C = c.MaxTemp_C,
                                                                             MinTemp_C = c.MinTemp_C,
                                                                             Rainfall_mm = c.Rainfall_mm,
                                                                             RainfallEntered_mm = c.RainfallEntered_mm,
                                                                             Snow_cm = c.Snow_cm,
                                                                             SnowOnGround_cm = c.SnowOnGround_cm,
                                                                             SpdMaxGust_kmh = c.SpdMaxGust_kmh,
                                                                             TotalPrecip_mm_cm = c.TotalPrecip_mm_cm,
                                                                             HourlyValues = c.HourlyValues,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                         }).ToList();

                ClimateSitesAndRains climateSitesAndRains = new ClimateSitesAndRains();

                climateSitesAndRains.ClimateSiteModel = climateSiteModel;
                for (int i = 0; i < 11; i++)
                {
                    DateTime RunDateTemp = RunDate.AddDays(-i);
                    int Year = RunDateTemp.Year;
                    int Month = RunDateTemp.Month;
                    int Day = RunDateTemp.Day;

                    ClimateDataValueModel climateDataValueModel = (from c in climateDataValueModelList
                                                                   where c.DateTime_Local.Year == Year
                                                                   && c.DateTime_Local.Month == Month
                                                                   && c.DateTime_Local.Day == Day
                                                                   select c).FirstOrDefault();

                    if (climateDataValueModel == null)
                    {
                        climateDataValueModel = new ClimateDataValueModel()
                        {
                            Error = "",
                            ClimateSiteID = climateSiteModel.ClimateSiteID,
                            ClimateDataValueID = 0,
                            DateTime_Local = RunDateTemp,
                            Keep = false,
                            StorageDataType = StorageDataTypeEnum.Error,
                            HasBeenRead = false,
                            CoolDegDays_C = null,
                            DirMaxGust_0North = null,
                            HeatDegDays_C = null,
                            MaxTemp_C = null,
                            MinTemp_C = null,
                            Rainfall_mm = null,
                            RainfallEntered_mm = null,
                            Snow_cm = null,
                            SnowOnGround_cm = null,
                            SpdMaxGust_kmh = null,
                            TotalPrecip_mm_cm = null,
                            HourlyValues = null,
                            LastUpdateDate_UTC = RunDateTemp,
                            LastUpdateContactTVItemID = 2,
                        };
                    }

                    climateSitesAndRains.ClimateDataValueModelList.Add(climateDataValueModel);
                }
                climateSitesAndRainsList.Add(climateSitesAndRains);
            }

            return climateSitesAndRainsList;
        }
        public List<ClimateSiteUseOfSiteModel> GetClimateSiteUseOfSiteModelList(int SubsectorTVItemID, int SmallestYearOfSampling)
        {
            int CurrentYear = DateTime.Now.Year;
            List<ClimateSiteUseOfSiteModel> climateSiteUseOfSiteModelList = new List<ClimateSiteUseOfSiteModel>();

            List<TVItemLanguage> tvItemLanguageList = (from c in db.TVItems
                                                       from cl in db.TVItemLanguages
                                                       from u in db.UseOfSites
                                                       where c.TVItemID == cl.TVItemID
                                                       && c.TVItemID == u.SiteTVItemID
                                                       && u.TVType == (int)TVTypeEnum.ClimateSite
                                                       && u.SubsectorTVItemID == SubsectorTVItemID
                                                       && cl.Language == (int)LanguageRequest
                                                       orderby cl.TVText
                                                       select cl).Distinct().ToList();

            foreach (TVItemLanguage tvItemLanguage in tvItemLanguageList)
            {
                ClimateSiteUseOfSiteModel climateSiteUseOfSiteModel = new ClimateSiteUseOfSiteModel();

                climateSiteUseOfSiteModel.ClimateSiteText = tvItemLanguage.TVText;
                climateSiteUseOfSiteModel.UseOfSiteModelList = (from c in db.UseOfSites
                                                                let siteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                let subsectorTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                where c.SubsectorTVItemID == SubsectorTVItemID
                                                                && c.TVType == (int)TVTypeEnum.ClimateSite
                                                                && c.SiteTVItemID == tvItemLanguage.TVItemID
                                                                orderby c.StartYear
                                                                select new UseOfSiteModel
                                                                {
                                                                    Error = "",
                                                                    UseOfSiteID = c.UseOfSiteID,
                                                                    SiteTVItemID = c.SiteTVItemID,
                                                                    SiteTVText = siteTVText,
                                                                    SubsectorTVItemID = c.SubsectorTVItemID,
                                                                    SubsectorTVText = subsectorTVText,
                                                                    TVType = (TVTypeEnum)c.TVType,
                                                                    Ordinal = c.Ordinal,
                                                                    StartYear = c.StartYear,
                                                                    EndYear = c.EndYear,
                                                                    UseWeight = c.UseWeight,
                                                                    Weight_perc = c.Weight_perc,
                                                                    UseEquation = c.UseEquation,
                                                                    Param1 = c.Param1,
                                                                    Param2 = c.Param2,
                                                                    Param3 = c.Param3,
                                                                    Param4 = c.Param4,
                                                                    LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                    LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                }).ToList();

                climateSiteUseOfSiteModelList.Add(climateSiteUseOfSiteModel);
            }


            return climateSiteUseOfSiteModelList;
        }
        public MWQMSubsectorHydrometricSites GetMWQMSubsectorHydrometricSitesDB(int MWQMSubsectorTVItemID, float Radius_m)
        {
            MWQMSubsectorHydrometricSites mwqmSubsectorhydrometricSites = new MWQMSubsectorHydrometricSites();

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(MWQMSubsectorTVItemID, TVTypeEnum.Subsector, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelList.Count == 0)
            {
                mwqmSubsectorhydrometricSites.Error = string.Format(ServiceRes._ShouldNotBeNullOrEmpty, "MapInfoPointModelList with MWQMSubsectorTVItemID = [" + MWQMSubsectorTVItemID + "]");
                return mwqmSubsectorhydrometricSites;
            }

            // Getting MWQMSubsectorModel
            MWQMSubsectorWithLatLngModel mwqmSubsectorWithLatLngModel = (from c in db.MWQMSubsectors
                                                                         let mwqmsubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                         let subsectorDesc = (from cl in db.MWQMSubsectorLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSubsectorID == c.MWQMSubsectorID select cl.SubsectorDesc).FirstOrDefault<string>()
                                                                         where c.MWQMSubsectorTVItemID == MWQMSubsectorTVItemID
                                                                         select new MWQMSubsectorWithLatLngModel
                                                                         {
                                                                             Error = "",
                                                                             MWQMSubsectorID = c.MWQMSubsectorID,
                                                                             MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                                                                             MWQMSubsectorTVText = mwqmsubsectorName,
                                                                             SubsectorHistoricKey = c.SubsectorHistoricKey,
                                                                             SubsectorDesc = subsectorDesc,
                                                                             TideLocationSIDText = c.TideLocationSIDText,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                         }).FirstOrDefault<MWQMSubsectorWithLatLngModel>();

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorWithLatLngModel.Error))
            {
                mwqmSubsectorhydrometricSites.Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSubsector, ServiceRes.MWQMSubsectorTVItemID, MWQMSubsectorTVItemID);
                return mwqmSubsectorhydrometricSites;
            }
            mwqmSubsectorWithLatLngModel.Lat = (float)mapInfoPointModelList[0].Lat;
            mwqmSubsectorWithLatLngModel.Lng = (float)mapInfoPointModelList[0].Lng;
            mwqmSubsectorhydrometricSites.MWQMSubsectorWithLatLngModel = mwqmSubsectorWithLatLngModel;

            List<int> useHydrometricSiteTVItemIDList = (from c in db.HydrometricSites
                                                        from u in db.UseOfSites
                                                        where c.HydrometricSiteTVItemID == u.SiteTVItemID
                                                        && u.TVType == (int)TVTypeEnum.HydrometricSite
                                                        && u.SubsectorTVItemID == MWQMSubsectorTVItemID
                                                        select c.HydrometricSiteTVItemID).Distinct().ToList();

            List<int> distHydrometricSiteTVItemIDList = _MapInfoService.GetMapInfoModelWithinCircleWithTVTypeAndMapInfoDrawTypeDB((float)mwqmSubsectorWithLatLngModel.Lat, (float)mwqmSubsectorWithLatLngModel.Lng,
                (float)Radius_m, TVTypeEnum.HydrometricSite, MapInfoDrawTypeEnum.Point).Select(c => c.TVItemID).Distinct().ToList();

            List<int> HydrometricSiteTVItemIDList = useHydrometricSiteTVItemIDList.Concat(distHydrometricSiteTVItemIDList).Distinct().ToList();

            List<HydrometricSiteWithLatLngAndOrdinalModel> HydrometricSiteWithLatLngAndOrdinalModelList = (from c in db.HydrometricSites
                                                                                                           from id in HydrometricSiteTVItemIDList
                                                                                                           let coord = (from mi in db.MapInfos
                                                                                                                        from mip in db.MapInfoPoints
                                                                                                                        where mi.MapInfoID == mip.MapInfoID
                                                                                                                        && mi.TVItemID == c.HydrometricSiteTVItemID
                                                                                                                        && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                                                                                                        && mi.TVType == (int)TVTypeEnum.HydrometricSite
                                                                                                                        select new { mip.Lat, mip.Lng, mip.MapInfoID }).FirstOrDefault()
                                                                                                           let hydrometricSiteTVText = (from cl in db.TVItemLanguages
                                                                                                                                        where cl.TVItemID == c.HydrometricSiteTVItemID
                                                                                                                                        && cl.Language == (int)LanguageRequest
                                                                                                                                        select cl.TVText).FirstOrDefault()
                                                                                                           where c.HydrometricSiteTVItemID == id
                                                                                                           orderby hydrometricSiteTVText
                                                                                                           select new HydrometricSiteWithLatLngAndOrdinalModel
                                                                                                           {
                                                                                                               Error = "",
                                                                                                               HydrometricSiteID = c.HydrometricSiteID,
                                                                                                               HydrometricSiteTVItemID = c.HydrometricSiteTVItemID,
                                                                                                               FedSiteNumber = c.FedSiteNumber,
                                                                                                               QuebecSiteNumber = c.QuebecSiteNumber,
                                                                                                               HydrometricSiteName = c.HydrometricSiteName,
                                                                                                               Description = c.Description,
                                                                                                               Province = c.Province,
                                                                                                               Elevation_m = c.Elevation_m,
                                                                                                               StartDate_Local = c.StartDate_Local,
                                                                                                               EndDate_Local = c.EndDate_Local,
                                                                                                               TimeOffset_hour = c.TimeOffset_hour,
                                                                                                               DrainageArea_km2 = c.DrainageArea_km2,
                                                                                                               IsNatural = c.IsNatural,
                                                                                                               IsActive = c.IsActive,
                                                                                                               Sediment = c.Sediment,
                                                                                                               RHBN = c.RHBN,
                                                                                                               RealTime = c.RealTime,
                                                                                                               HasDischarge = c.HasDischarge,
                                                                                                               HasLevel = c.HasLevel,
                                                                                                               HasRatingCurve = c.HasRatingCurve,
                                                                                                               Lat = (float)coord.Lat,
                                                                                                               Lng = (float)coord.Lng,
                                                                                                               HydrometricSiteTVText = hydrometricSiteTVText,
                                                                                                               Ordinal = 0,
                                                                                                               Distance_km = 0,
                                                                                                               MapInfoID = coord.MapInfoID,
                                                                                                               YearsOfUseText = "",
                                                                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                                           }).ToList();


            List<UseOfSite> useOfSiteList = (from c in db.UseOfSites
                                             where c.SubsectorTVItemID == MWQMSubsectorTVItemID
                                             && c.TVType == (int)TVTypeEnum.HydrometricSite
                                             orderby c.SiteTVItemID, c.StartYear
                                             select c).ToList();

            foreach (HydrometricSiteWithLatLngAndOrdinalModel hydrometricSiteWithLatLngAndOrdinalModel in HydrometricSiteWithLatLngAndOrdinalModelList)
            {
                hydrometricSiteWithLatLngAndOrdinalModel.Distance_km = (float)(_MapInfoService.CalculateDistance((double)mwqmSubsectorWithLatLngModel.Lat * d2r, (double)mwqmSubsectorWithLatLngModel.Lng * d2r, (double)hydrometricSiteWithLatLngAndOrdinalModel.Lat * d2r, (double)hydrometricSiteWithLatLngAndOrdinalModel.Lng * d2r, (double)R) / 1000);
                foreach (UseOfSite useOfSite in useOfSiteList)
                {
                    if (hydrometricSiteWithLatLngAndOrdinalModel.HydrometricSiteTVItemID == useOfSite.SiteTVItemID)
                    {
                        if (string.IsNullOrWhiteSpace(hydrometricSiteWithLatLngAndOrdinalModel.YearsOfUseText))
                        {
                            hydrometricSiteWithLatLngAndOrdinalModel.YearsOfUseText = useOfSite.StartYear.ToString();
                        }
                        else
                        {
                            hydrometricSiteWithLatLngAndOrdinalModel.YearsOfUseText = hydrometricSiteWithLatLngAndOrdinalModel.YearsOfUseText + "," + useOfSite.StartYear;
                        }
                        if (useOfSite.StartYear != useOfSite.EndYear)
                        {
                            hydrometricSiteWithLatLngAndOrdinalModel.YearsOfUseText = hydrometricSiteWithLatLngAndOrdinalModel.YearsOfUseText + "-" + useOfSite.EndYear;
                        }
                    }
                }
            }


            mwqmSubsectorhydrometricSites.HydrometricSiteModelUsedAndWithinDistanceModelList = HydrometricSiteWithLatLngAndOrdinalModelList;

            return mwqmSubsectorhydrometricSites;
        }
        public MWQMSubsectorTideSites GetMWQMSubsectorTideSitesDB(int MWQMSubsectorTVItemID, float Radius_m)
        {
            MWQMSubsectorTideSites mwqmSubsectorTideSites = new MWQMSubsectorTideSites();

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(MWQMSubsectorTVItemID, TVTypeEnum.Subsector, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelList.Count == 0)
            {
                mwqmSubsectorTideSites.Error = string.Format(ServiceRes._ShouldNotBeNullOrEmpty, "MapInfoPointModelList with MWQMSubsectorTVItemID = [" + MWQMSubsectorTVItemID + "]");
                return mwqmSubsectorTideSites;
            }

            // Getting MWQMSubsectorModel
            MWQMSubsectorWithLatLngModel mwqmSubsectorWithLatLngModel = (from c in db.MWQMSubsectors
                                                                         let mwqmsubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                         let subsectorDesc = (from cl in db.MWQMSubsectorLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSubsectorID == c.MWQMSubsectorID select cl.SubsectorDesc).FirstOrDefault<string>()
                                                                         where c.MWQMSubsectorTVItemID == MWQMSubsectorTVItemID
                                                                         select new MWQMSubsectorWithLatLngModel
                                                                         {
                                                                             Error = "",
                                                                             MWQMSubsectorID = c.MWQMSubsectorID,
                                                                             MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                                                                             MWQMSubsectorTVText = mwqmsubsectorName,
                                                                             SubsectorHistoricKey = c.SubsectorHistoricKey,
                                                                             SubsectorDesc = subsectorDesc,
                                                                             TideLocationSIDText = c.TideLocationSIDText,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                         }).FirstOrDefault<MWQMSubsectorWithLatLngModel>();

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorWithLatLngModel.Error))
            {
                mwqmSubsectorTideSites.Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSubsector, ServiceRes.MWQMSubsectorTVItemID, MWQMSubsectorTVItemID);
                return mwqmSubsectorTideSites;
            }
            mwqmSubsectorWithLatLngModel.Lat = (float)mapInfoPointModelList[0].Lat;
            mwqmSubsectorWithLatLngModel.Lng = (float)mapInfoPointModelList[0].Lng;
            mwqmSubsectorTideSites.MWQMSubsectorWithLatLngModel = mwqmSubsectorWithLatLngModel;

            List<int> useTideSiteTVItemIDList = (from c in db.TVItems
                                                 from u in db.UseOfSites
                                                 where c.TVItemID == u.SiteTVItemID
                                                 && u.TVType == (int)TVTypeEnum.TideSite
                                                 && u.SubsectorTVItemID == MWQMSubsectorTVItemID
                                                 select c.TVItemID).Distinct().ToList();

            List<int> distTideSiteTVItemIDList = _MapInfoService.GetMapInfoModelWithinCircleWithTVTypeAndMapInfoDrawTypeDB((float)mwqmSubsectorWithLatLngModel.Lat, (float)mwqmSubsectorWithLatLngModel.Lng,
                (float)Radius_m, TVTypeEnum.TideSite, MapInfoDrawTypeEnum.Point).Select(c => c.TVItemID).Distinct().ToList();

            List<int> TideSiteTVItemIDList = useTideSiteTVItemIDList.Concat(distTideSiteTVItemIDList).Distinct().ToList();

            List<TideSiteWithLatLngAndOrdinalModel> TideSiteWithLatLngAndOrdinalModelList = (from c in db.TideSites
                                                                                             from id in TideSiteTVItemIDList
                                                                                             let coord = (from mi in db.MapInfos
                                                                                                          from mip in db.MapInfoPoints
                                                                                                          where mi.MapInfoID == mip.MapInfoID
                                                                                                          && mi.TVItemID == c.TideSiteTVItemID
                                                                                                          && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                                                                                          && mi.TVType == (int)TVTypeEnum.TideSite
                                                                                                          select new { mip.Lat, mip.Lng, mip.MapInfoID }).FirstOrDefault()
                                                                                             let tideSiteName = (from cl in db.TVItemLanguages
                                                                                                                 where cl.TVItemID == c.TideSiteTVItemID
                                                                                                                 && cl.Language == (int)LanguageRequest
                                                                                                                 select cl.TVText).FirstOrDefault()
                                                                                             where c.TideSiteTVItemID == id
                                                                                             orderby tideSiteName
                                                                                             select new TideSiteWithLatLngAndOrdinalModel
                                                                                             {
                                                                                                 Error = "",
                                                                                                 Province = c.Province,
                                                                                                 sid = c.sid,
                                                                                                 Zone = c.Zone,
                                                                                                 TideSiteID = c.TideSiteID,
                                                                                                 TideSiteName = tideSiteName,
                                                                                                 TideSiteTVItemID = c.TideSiteTVItemID,
                                                                                                 Lat = (float)coord.Lat,
                                                                                                 Lng = (float)coord.Lng,
                                                                                                 Ordinal = 0,
                                                                                                 Distance_km = 0,
                                                                                                 MapInfoID = coord.MapInfoID,
                                                                                                 IsUsed = false,
                                                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                             }).ToList();


            List<UseOfSite> useOfSiteList = (from c in db.UseOfSites
                                             where c.SubsectorTVItemID == MWQMSubsectorTVItemID
                                             && c.TVType == (int)TVTypeEnum.TideSite
                                             orderby c.SiteTVItemID, c.StartYear
                                             select c).ToList();

            foreach (TideSiteWithLatLngAndOrdinalModel TideSiteWithLatLngAndOrdinalModel in TideSiteWithLatLngAndOrdinalModelList)
            {
                TideSiteWithLatLngAndOrdinalModel.Distance_km = (float)(_MapInfoService.CalculateDistance((double)mwqmSubsectorWithLatLngModel.Lat * d2r, (double)mwqmSubsectorWithLatLngModel.Lng * d2r, (double)TideSiteWithLatLngAndOrdinalModel.Lat * d2r, (double)TideSiteWithLatLngAndOrdinalModel.Lng * d2r, (double)R) / 1000);
                foreach (UseOfSite useOfSite in useOfSiteList)
                {
                    if (TideSiteWithLatLngAndOrdinalModel.TideSiteTVItemID == useOfSite.SiteTVItemID)
                    {
                        TideSiteWithLatLngAndOrdinalModel.IsUsed = true;
                    }
                }
            }


            mwqmSubsectorTideSites.TideSiteModelUsedAndWithinDistanceModelList = TideSiteWithLatLngAndOrdinalModelList;

            return mwqmSubsectorTideSites;
        }
        public MWQMSubsectorMunicipalities GetMWQMSubsectorMunicipalitiesDB(int MWQMSubsectorTVItemID, float Radius_m)
        {
            MWQMSubsectorMunicipalities mwqmSubsectorMunicipalities = new MWQMSubsectorMunicipalities();

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(MWQMSubsectorTVItemID, TVTypeEnum.Subsector, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelList.Count == 0)
            {
                mwqmSubsectorMunicipalities.Error = string.Format(ServiceRes._ShouldNotBeNullOrEmpty, "MapInfoPointModelList with MWQMSubsectorTVItemID = [" + MWQMSubsectorTVItemID + "]");
                return mwqmSubsectorMunicipalities;
            }

            // Getting MWQMSubsectorModel
            MWQMSubsectorWithLatLngModel mwqmSubsectorWithLatLngModel = (from c in db.MWQMSubsectors
                                                                         let mwqmsubsectorName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                         let subsectorDesc = (from cl in db.MWQMSubsectorLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSubsectorID == c.MWQMSubsectorID select cl.SubsectorDesc).FirstOrDefault<string>()
                                                                         where c.MWQMSubsectorTVItemID == MWQMSubsectorTVItemID
                                                                         select new MWQMSubsectorWithLatLngModel
                                                                         {
                                                                             Error = "",
                                                                             MWQMSubsectorID = c.MWQMSubsectorID,
                                                                             MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                                                                             MWQMSubsectorTVText = mwqmsubsectorName,
                                                                             SubsectorHistoricKey = c.SubsectorHistoricKey,
                                                                             SubsectorDesc = subsectorDesc,
                                                                             TideLocationSIDText = c.TideLocationSIDText,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                         }).FirstOrDefault<MWQMSubsectorWithLatLngModel>();

            if (!string.IsNullOrWhiteSpace(mwqmSubsectorWithLatLngModel.Error))
            {
                mwqmSubsectorMunicipalities.Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSubsector, ServiceRes.MWQMSubsectorTVItemID, MWQMSubsectorTVItemID);
                return mwqmSubsectorMunicipalities;
            }
            mwqmSubsectorWithLatLngModel.Lat = (float)mapInfoPointModelList[0].Lat;
            mwqmSubsectorWithLatLngModel.Lng = (float)mapInfoPointModelList[0].Lng;
            mwqmSubsectorMunicipalities.MWQMSubsectorWithLatLngModel = mwqmSubsectorWithLatLngModel;

            List<int> useMunicipalityTVItemIDList = (from c in db.TVItems
                                                     from u in db.UseOfSites
                                                     where c.TVItemID == u.SiteTVItemID
                                                     && u.TVType == (int)TVTypeEnum.Municipality
                                                     && u.SubsectorTVItemID == MWQMSubsectorTVItemID
                                                     select c.TVItemID).Distinct().ToList();

            List<int> distMunicipalityTVItemIDList = _MapInfoService.GetMapInfoModelWithinCircleWithTVTypeAndMapInfoDrawTypeDB((float)mwqmSubsectorWithLatLngModel.Lat, (float)mwqmSubsectorWithLatLngModel.Lng,
                (float)Radius_m, TVTypeEnum.Municipality, MapInfoDrawTypeEnum.Point).Select(c => c.TVItemID).Distinct().ToList();

            List<int> MunicipalityTVItemIDList = useMunicipalityTVItemIDList.Concat(distMunicipalityTVItemIDList).Distinct().ToList();

            List<MunicipalityWithLatLngAndOrdinalModel> MunicipalityWithLatLngAndOrdinalModelList = (from c in db.TVItems
                                                                                                     from id in MunicipalityTVItemIDList
                                                                                                     let coord = (from mi in db.MapInfos
                                                                                                                  from mip in db.MapInfoPoints
                                                                                                                  where mi.MapInfoID == mip.MapInfoID
                                                                                                                  && mi.TVItemID == c.TVItemID
                                                                                                                  && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                                                                                                  && mi.TVType == (int)TVTypeEnum.Municipality
                                                                                                                  select new { mip.Lat, mip.Lng, mip.MapInfoID }).FirstOrDefault()
                                                                                                     let municipalityTVText = (from cl in db.TVItemLanguages
                                                                                                                               where cl.TVItemID == c.TVItemID
                                                                                                                               && cl.Language == (int)LanguageRequest
                                                                                                                               select cl.TVText).FirstOrDefault()
                                                                                                     where c.TVItemID == id
                                                                                                     orderby municipalityTVText
                                                                                                     select new MunicipalityWithLatLngAndOrdinalModel
                                                                                                     {
                                                                                                         Error = "",
                                                                                                         IsActive = c.IsActive,
                                                                                                         TVItemID = c.TVItemID,
                                                                                                         TVLevel = c.TVLevel,
                                                                                                         TVPath = c.TVPath,
                                                                                                         TVText = municipalityTVText,
                                                                                                         TVType = (TVTypeEnum)c.TVType,
                                                                                                         Lat = (float)coord.Lat,
                                                                                                         Lng = (float)coord.Lng,
                                                                                                         Ordinal = 0,
                                                                                                         Distance_km = 0,
                                                                                                         MapInfoID = coord.MapInfoID,
                                                                                                         IsUsed = false,
                                                                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                                     }).ToList();


            List<UseOfSite> useOfSiteList = (from c in db.UseOfSites
                                             where c.SubsectorTVItemID == MWQMSubsectorTVItemID
                                             && c.TVType == (int)TVTypeEnum.Municipality
                                             orderby c.SiteTVItemID, c.StartYear
                                             select c).ToList();

            foreach (MunicipalityWithLatLngAndOrdinalModel municipalityWithLatLngAndOrdinalModel in MunicipalityWithLatLngAndOrdinalModelList)
            {
                municipalityWithLatLngAndOrdinalModel.Distance_km = (float)(_MapInfoService.CalculateDistance((double)mwqmSubsectorWithLatLngModel.Lat * d2r, (double)mwqmSubsectorWithLatLngModel.Lng * d2r, (double)municipalityWithLatLngAndOrdinalModel.Lat * d2r, (double)municipalityWithLatLngAndOrdinalModel.Lng * d2r, (double)R) / 1000);
                foreach (UseOfSite useOfSite in useOfSiteList)
                {
                    if (municipalityWithLatLngAndOrdinalModel.TVItemID == useOfSite.SiteTVItemID)
                    {
                        municipalityWithLatLngAndOrdinalModel.IsUsed = true;
                    }
                }
            }


            mwqmSubsectorMunicipalities.MunicipalityModelUsedAndWithinDistanceModelList = MunicipalityWithLatLngAndOrdinalModelList;

            return mwqmSubsectorMunicipalities;
        }
        public List<HydrometricSitesAndDischarges> GetMWQMSubsectorHydrometricSitesAndValuesForAParicularRunsDB(int MWQMSubsectorTVItemID, int MWQMRunTVItemID)
        {
            List<HydrometricSitesAndDischarges> hydrometricSitesAndDischargesList = new List<HydrometricSitesAndDischarges>();

            // Getting MWQMSubsectorModel
            MWQMSubsectorModel mwqmSubsectorModel = GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(MWQMSubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorModel.Error))
            {
                return new List<HydrometricSitesAndDischarges>();
            }

            // Getting MWQMRunModelList from the SubsectorTVItemID
            MWQMRunModel mwqmRunModel = _MWQMRunService.GetMWQMRunModelWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqmRunModel.Error))
            {
                return new List<HydrometricSitesAndDischarges>();
            }


            // Getting HydrometricSites within distance and the ones used for the subsector
            List<HydrometricSiteModel> hydrometricSiteModelUseInSubsectorList = (from c in db.HydrometricSites
                                                                                 from u in db.UseOfSites
                                                                                 let hydrometricSiteTVText = (from cl in db.TVItemLanguages
                                                                                                              where cl.TVItemID == c.HydrometricSiteTVItemID
                                                                                                              && cl.Language == (int)LanguageRequest
                                                                                                              select cl.TVText).FirstOrDefault()
                                                                                 where c.HydrometricSiteTVItemID == u.SiteTVItemID
                                                                                 && u.TVType == (int)TVTypeEnum.HydrometricSite
                                                                                 && u.SubsectorTVItemID == MWQMSubsectorTVItemID
                                                                                 orderby u.Ordinal
                                                                                 select new HydrometricSiteModel
                                                                                 {
                                                                                     Error = "",
                                                                                     HydrometricSiteID = c.HydrometricSiteID,
                                                                                     HydrometricSiteTVItemID = c.HydrometricSiteTVItemID,
                                                                                     FedSiteNumber = c.FedSiteNumber,
                                                                                     QuebecSiteNumber = c.QuebecSiteNumber,
                                                                                     HydrometricSiteName = c.HydrometricSiteName,
                                                                                     Description = c.Description,
                                                                                     Province = c.Province,
                                                                                     Elevation_m = c.Elevation_m,
                                                                                     StartDate_Local = c.StartDate_Local,
                                                                                     EndDate_Local = c.EndDate_Local,
                                                                                     TimeOffset_hour = c.TimeOffset_hour,
                                                                                     DrainageArea_km2 = c.DrainageArea_km2,
                                                                                     IsNatural = c.IsNatural,
                                                                                     IsActive = c.IsActive,
                                                                                     Sediment = c.Sediment,
                                                                                     RHBN = c.RHBN,
                                                                                     RealTime = c.RealTime,
                                                                                     HasDischarge = c.HasDischarge,
                                                                                     HasLevel = c.HasLevel,
                                                                                     HasRatingCurve = c.HasRatingCurve,
                                                                                     HydrometricSiteTVText = hydrometricSiteTVText,
                                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                 }).ToList();

            foreach (HydrometricSiteModel hydrometricSiteModel in hydrometricSiteModelUseInSubsectorList)
            {
                DateTime RunDate = new DateTime(mwqmRunModel.DateTime_Local.Year, mwqmRunModel.DateTime_Local.Month, mwqmRunModel.DateTime_Local.Day);
                DateTime RunDateMinus10 = RunDate.AddDays(-10);

                List<HydrometricDataValueModel> hydrometricDataValueModelList = (from c in db.HydrometricDataValues
                                                                                 where c.HydrometricSiteID == hydrometricSiteModel.HydrometricSiteID
                                                                                 && c.DateTime_Local <= RunDate
                                                                                 && c.DateTime_Local >= RunDateMinus10
                                                                                 && c.StorageDataType == (int)StorageDataTypeEnum.Archived
                                                                                 select new HydrometricDataValueModel
                                                                                 {
                                                                                     Error = "",
                                                                                     HydrometricSiteID = c.HydrometricSiteID,
                                                                                     HydrometricDataValueID = c.HydrometricDataValueID,
                                                                                     DateTime_Local = c.DateTime_Local,
                                                                                     Keep = c.Keep,
                                                                                     StorageDataType = (StorageDataTypeEnum)c.StorageDataType,
                                                                                     HasBeenRead = c.HasBeenRead,
                                                                                     Discharge_m3_s = c.Discharge_m3_s,
                                                                                     DischargeEntered_m3_s = c.DischargeEntered_m3_s,
                                                                                     Level_m = c.Level_m,
                                                                                     HourlyValues = c.HourlyValues,
                                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                 }).ToList();

                HydrometricSitesAndDischarges hydrometricSitesAndDischarges = new HydrometricSitesAndDischarges();

                hydrometricSitesAndDischarges.HydrometricSiteModel = hydrometricSiteModel;
                for (int i = 0; i < 11; i++)
                {
                    DateTime RunDateTemp = RunDate.AddDays(-i);
                    int Year = RunDateTemp.Year;
                    int Month = RunDateTemp.Month;
                    int Day = RunDateTemp.Day;

                    HydrometricDataValueModel hydrometricDataValueModel = (from c in hydrometricDataValueModelList
                                                                           where c.DateTime_Local.Year == Year
                                                                           && c.DateTime_Local.Month == Month
                                                                           && c.DateTime_Local.Day == Day
                                                                           select c).FirstOrDefault();

                    if (hydrometricDataValueModel == null)
                    {
                        hydrometricDataValueModel = new HydrometricDataValueModel()
                        {
                            Error = "",
                            HydrometricSiteID = hydrometricSiteModel.HydrometricSiteID,
                            HydrometricDataValueID = 0,
                            DateTime_Local = RunDateTemp,
                            Keep = false,
                            StorageDataType = StorageDataTypeEnum.Error,
                            HasBeenRead = false,
                            Discharge_m3_s = null,
                            DischargeEntered_m3_s = null,
                            Level_m = null,
                            HourlyValues = null,
                            LastUpdateDate_UTC = RunDateTemp,
                            LastUpdateContactTVItemID = 2,
                        };
                    }

                    hydrometricSitesAndDischarges.HydrometricDataValueModelList.Add(hydrometricDataValueModel);
                }
                hydrometricSitesAndDischargesList.Add(hydrometricSitesAndDischarges);
            }

            return hydrometricSitesAndDischargesList;
        }
        public List<HydrometricSiteUseOfSiteModel> GetHydrometricSiteUseOfSiteModelList(int SubsectorTVItemID, int SmallestYearOfSampling)
        {
            int CurrentYear = DateTime.Now.Year;
            List<HydrometricSiteUseOfSiteModel> hydrometricSiteUseOfSiteModelList = new List<HydrometricSiteUseOfSiteModel>();

            List<TVItemLanguage> tvItemLanguageList = (from c in db.TVItems
                                                       from cl in db.TVItemLanguages
                                                       from u in db.UseOfSites
                                                       where c.TVItemID == cl.TVItemID
                                                       && c.TVItemID == u.SiteTVItemID
                                                       && u.TVType == (int)TVTypeEnum.HydrometricSite
                                                       && u.SubsectorTVItemID == SubsectorTVItemID
                                                       && cl.Language == (int)LanguageRequest
                                                       orderby cl.TVText
                                                       select cl).Distinct().ToList();

            foreach (TVItemLanguage tvItemLanguage in tvItemLanguageList)
            {
                HydrometricSiteUseOfSiteModel hydrometricSiteUseOfSiteModel = new HydrometricSiteUseOfSiteModel();

                hydrometricSiteUseOfSiteModel.HydrometricSiteText = tvItemLanguage.TVText;
                hydrometricSiteUseOfSiteModel.UseOfSiteModelList = (from c in db.UseOfSites
                                                                    let siteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                    let subsectorTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                    where c.SubsectorTVItemID == SubsectorTVItemID
                                                                    && c.TVType == (int)TVTypeEnum.HydrometricSite
                                                                    && c.SiteTVItemID == tvItemLanguage.TVItemID
                                                                    orderby c.StartYear
                                                                    select new UseOfSiteModel
                                                                    {
                                                                        Error = "",
                                                                        UseOfSiteID = c.UseOfSiteID,
                                                                        SiteTVItemID = c.SiteTVItemID,
                                                                        SiteTVText = siteTVText,
                                                                        SubsectorTVItemID = c.SubsectorTVItemID,
                                                                        SubsectorTVText = subsectorTVText,
                                                                        TVType = (TVTypeEnum)c.TVType,
                                                                        Ordinal = c.Ordinal,
                                                                        StartYear = c.StartYear,
                                                                        EndYear = c.EndYear,
                                                                        UseWeight = c.UseWeight,
                                                                        Weight_perc = c.Weight_perc,
                                                                        UseEquation = c.UseEquation,
                                                                        Param1 = c.Param1,
                                                                        Param2 = c.Param2,
                                                                        Param3 = c.Param3,
                                                                        Param4 = c.Param4,
                                                                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                    }).ToList();

                hydrometricSiteUseOfSiteModelList.Add(hydrometricSiteUseOfSiteModel);
            }


            return hydrometricSiteUseOfSiteModelList;
        }
        public List<int> GetMWQMSubsectorRunsYears(int SubsectorTVItemID)
        {
            List<int> runYearsList = (from c in db.MWQMRuns
                                      where c.SubsectorTVItemID == SubsectorTVItemID
                                      select c.DateTime_Local.Year).Distinct().ToList();

            return runYearsList;

        }
        // Helper
        public MWQMSubsectorModel ReturnError(string Error)
        {
            return new MWQMSubsectorModel() { Error = Error };
        }
        public string FillClimateSiteUseStartEndYears(ClimateSiteTVItemIDYearsText climateSiteTVItemIDYearsText)
        {
            int StartYear = 0;
            int? EndYear = null;
            string StartYearText = "";
            string EndYearText = "";
            bool IsStartYear = false;
            bool IsEndYear = false;
            int temp = 0;

            climateSiteTVItemIDYearsText.YearsText = climateSiteTVItemIDYearsText.YearsText.Trim();
            climateSiteTVItemIDYearsText.YearsText = climateSiteTVItemIDYearsText.YearsText.Replace(" ", "");

            if (climateSiteTVItemIDYearsText.YearsText.Contains(" "))
            {
                return string.Format(ServiceRes.AllEmptySpaceFrom_ShouldHaveBeenRemoved, climateSiteTVItemIDYearsText.YearsText);
            }

            for (int i = 0, count = climateSiteTVItemIDYearsText.YearsText.Count(); i < count; i++)
            {
                if (climateSiteTVItemIDYearsText.YearsText[i].ToString() == ",")
                {
                    if (IsStartYear && !IsEndYear)
                    {
                        if (StartYearText.Count() != 4)
                        {
                            return string.Format(ServiceRes._Of_IsNotAYear, StartYearText, climateSiteTVItemIDYearsText.YearsText);
                        }

                        StartYear = int.Parse(StartYearText);
                        EndYear = StartYear;
                        climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList.Add(new ClimateSiteUseStartEndYears() { StartYear = StartYear, EndYear = EndYear });
                    }
                    else if (!IsStartYear && IsEndYear)
                    {
                        if (EndYearText.Count() != 4)
                        {
                            return string.Format(ServiceRes._Of_IsNotAYear, EndYearText, climateSiteTVItemIDYearsText.YearsText);
                        }

                        EndYear = 0;
                        temp = int.Parse(EndYearText);
                        EndYear = temp;

                        climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList.Add(new ClimateSiteUseStartEndYears() { StartYear = StartYear, EndYear = EndYear });
                    }
                    else if (!IsStartYear && !IsEndYear)
                    {
                        return string.Format(ServiceRes._Of_IsNotAYear, StartYearText, climateSiteTVItemIDYearsText.YearsText);
                    }

                    IsStartYear = false;
                    IsEndYear = false;
                    StartYearText = "";
                    EndYearText = "";
                }
                else if (climateSiteTVItemIDYearsText.YearsText[i].ToString() == "-")
                {
                    if (IsStartYear)
                    {
                        if (StartYearText.Count() != 4)
                        {
                            return string.Format(ServiceRes._Of_IsNotAYear, StartYearText, climateSiteTVItemIDYearsText.YearsText);
                        }

                        StartYear = int.Parse(StartYearText);
                    }
                    else
                    {
                        return string.Format(ServiceRes._Of_IsNotAYear, StartYearText, climateSiteTVItemIDYearsText.YearsText);
                    }

                    IsStartYear = false;
                    IsEndYear = true;
                    StartYearText = "";
                    EndYearText = "";
                }
                else if ("0123456789".Contains(climateSiteTVItemIDYearsText.YearsText[i]))
                {
                    if (IsStartYear)
                    {
                        StartYearText = StartYearText + climateSiteTVItemIDYearsText.YearsText[i];
                    }
                    else if (IsEndYear)
                    {
                        EndYearText = EndYearText + climateSiteTVItemIDYearsText.YearsText[i];
                    }
                    else if (!IsStartYear && !IsEndYear)
                    {
                        IsStartYear = true;
                        StartYearText = climateSiteTVItemIDYearsText.YearsText[i].ToString();
                    }
                }
                else
                {
                    return string.Format(ServiceRes._NotAllowedIn_, climateSiteTVItemIDYearsText.YearsText[i].ToString(), climateSiteTVItemIDYearsText.YearsText);
                }

            }

            if (IsStartYear)
            {
                StartYear = 0;
                EndYear = null;

                if (StartYearText.Count() != 4)
                {
                    return string.Format(ServiceRes._Of_IsNotAYear, StartYearText, climateSiteTVItemIDYearsText.YearsText);
                }

                StartYear = int.Parse(StartYearText);

                if (climateSiteTVItemIDYearsText.YearsText.Last().ToString() != "-")
                {
                    EndYear = StartYear;
                    climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList.Add(new ClimateSiteUseStartEndYears() { StartYear = StartYear, EndYear = EndYear });
                }
                else
                {
                    climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList.Add(new ClimateSiteUseStartEndYears() { StartYear = StartYear, EndYear = EndYear });
                }
            }
            else if (IsEndYear)
            {
                EndYear = null;

                if (climateSiteTVItemIDYearsText.YearsText.Last().ToString() == "-")
                {
                    climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList.Add(new ClimateSiteUseStartEndYears() { StartYear = StartYear, EndYear = null });
                }
                else
                {
                    if (EndYearText.Count() != 4)
                    {
                        return string.Format(ServiceRes._Of_IsNotAYear, EndYearText, climateSiteTVItemIDYearsText.YearsText);
                    }

                    temp = int.Parse(EndYearText);
                    EndYear = temp;

                    climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList.Add(new ClimateSiteUseStartEndYears() { StartYear = StartYear, EndYear = EndYear });
                }

            }

            int CurrentYear = 0;
            for (int i = 0, count = climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList.Count(); i < count; i++)
            {
                if (i == count - 1)
                {
                    if (climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[i].StartYear < CurrentYear)
                    {
                        return string.Format(ServiceRes.AllYearsOf_ShouldBeAscending, climateSiteTVItemIDYearsText.YearsText);
                    }
                    CurrentYear = climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[i].StartYear;
                    if (climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[i].EndYear != null)
                    {
                        if (climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[i].EndYear < CurrentYear)
                        {
                            return string.Format(ServiceRes.AllYearsOf_ShouldBeAscending, climateSiteTVItemIDYearsText.YearsText);
                        }
                        CurrentYear = (int)climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[i].EndYear;
                    }
                }
                else
                {
                    if (climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[i].StartYear < CurrentYear)
                    {
                        return string.Format(ServiceRes.AllYearsOf_ShouldBeAscending, climateSiteTVItemIDYearsText.YearsText);
                    }
                    CurrentYear = climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[i].StartYear;
                    if (climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[i].EndYear < CurrentYear)
                    {
                        return string.Format(ServiceRes.AllYearsOf_ShouldBeAscending, climateSiteTVItemIDYearsText.YearsText);
                    }
                    CurrentYear = (int)climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[i].EndYear;
                }
            }

            return "";
        }
        public string FillHydrometricSiteUseStartEndYears(HydrometricSiteTVItemIDYearsText hydrometricSiteTVItemIDYearsText)
        {
            int StartYear = 0;
            int? EndYear = null;
            string StartYearText = "";
            string EndYearText = "";
            bool IsStartYear = false;
            bool IsEndYear = false;
            int temp = 0;

            hydrometricSiteTVItemIDYearsText.YearsText = hydrometricSiteTVItemIDYearsText.YearsText.Trim();
            hydrometricSiteTVItemIDYearsText.YearsText = hydrometricSiteTVItemIDYearsText.YearsText.Replace(" ", "");

            if (hydrometricSiteTVItemIDYearsText.YearsText.Contains(" "))
            {
                return string.Format(ServiceRes.AllEmptySpaceFrom_ShouldHaveBeenRemoved, hydrometricSiteTVItemIDYearsText.YearsText);
            }

            for (int i = 0, count = hydrometricSiteTVItemIDYearsText.YearsText.Count(); i < count; i++)
            {
                if (hydrometricSiteTVItemIDYearsText.YearsText[i].ToString() == ",")
                {
                    if (IsStartYear && !IsEndYear)
                    {
                        if (StartYearText.Count() != 4)
                        {
                            return string.Format(ServiceRes._Of_IsNotAYear, StartYearText, hydrometricSiteTVItemIDYearsText.YearsText);
                        }

                        StartYear = int.Parse(StartYearText);
                        EndYear = StartYear;
                        hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList.Add(new HydrometricSiteUseStartEndYears() { StartYear = StartYear, EndYear = EndYear });
                    }
                    else if (!IsStartYear && IsEndYear)
                    {
                        if (EndYearText.Count() != 4)
                        {
                            return string.Format(ServiceRes._Of_IsNotAYear, EndYearText, hydrometricSiteTVItemIDYearsText.YearsText);
                        }

                        EndYear = 0;
                        temp = int.Parse(EndYearText);
                        EndYear = temp;

                        hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList.Add(new HydrometricSiteUseStartEndYears() { StartYear = StartYear, EndYear = EndYear });
                    }
                    else if (!IsStartYear && !IsEndYear)
                    {
                        return string.Format(ServiceRes._Of_IsNotAYear, StartYearText, hydrometricSiteTVItemIDYearsText.YearsText);
                    }

                    IsStartYear = false;
                    IsEndYear = false;
                    StartYearText = "";
                    EndYearText = "";
                }
                else if (hydrometricSiteTVItemIDYearsText.YearsText[i].ToString() == "-")
                {
                    if (IsStartYear)
                    {
                        if (StartYearText.Count() != 4)
                        {
                            return string.Format(ServiceRes._Of_IsNotAYear, StartYearText, hydrometricSiteTVItemIDYearsText.YearsText);
                        }

                        StartYear = int.Parse(StartYearText);
                    }
                    else
                    {
                        return string.Format(ServiceRes._Of_IsNotAYear, StartYearText, hydrometricSiteTVItemIDYearsText.YearsText);
                    }

                    IsStartYear = false;
                    IsEndYear = true;
                    StartYearText = "";
                    EndYearText = "";
                }
                else if ("0123456789".Contains(hydrometricSiteTVItemIDYearsText.YearsText[i]))
                {
                    if (IsStartYear)
                    {
                        StartYearText = StartYearText + hydrometricSiteTVItemIDYearsText.YearsText[i];
                    }
                    else if (IsEndYear)
                    {
                        EndYearText = EndYearText + hydrometricSiteTVItemIDYearsText.YearsText[i];
                    }
                    else if (!IsStartYear && !IsEndYear)
                    {
                        IsStartYear = true;
                        StartYearText = hydrometricSiteTVItemIDYearsText.YearsText[i].ToString();
                    }
                }
                else
                {
                    return string.Format(ServiceRes._NotAllowedIn_, hydrometricSiteTVItemIDYearsText.YearsText[i].ToString(), hydrometricSiteTVItemIDYearsText.YearsText);
                }

            }

            if (IsStartYear)
            {
                StartYear = 0;
                EndYear = null;

                if (StartYearText.Count() != 4)
                {
                    return string.Format(ServiceRes._Of_IsNotAYear, StartYearText, hydrometricSiteTVItemIDYearsText.YearsText);
                }

                StartYear = int.Parse(StartYearText);

                if (hydrometricSiteTVItemIDYearsText.YearsText.Last().ToString() != "-")
                {
                    EndYear = StartYear;
                    hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList.Add(new HydrometricSiteUseStartEndYears() { StartYear = StartYear, EndYear = EndYear });
                }
                else
                {
                    hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList.Add(new HydrometricSiteUseStartEndYears() { StartYear = StartYear, EndYear = EndYear });
                }
            }
            else if (IsEndYear)
            {
                EndYear = null;

                if (hydrometricSiteTVItemIDYearsText.YearsText.Last().ToString() == "-")
                {
                    hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList.Add(new HydrometricSiteUseStartEndYears() { StartYear = StartYear, EndYear = null });
                }
                else
                {
                    if (EndYearText.Count() != 4)
                    {
                        return string.Format(ServiceRes._Of_IsNotAYear, EndYearText, hydrometricSiteTVItemIDYearsText.YearsText);
                    }

                    temp = int.Parse(EndYearText);
                    EndYear = temp;

                    hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList.Add(new HydrometricSiteUseStartEndYears() { StartYear = StartYear, EndYear = EndYear });
                }

            }

            int CurrentYear = 0;
            for (int i = 0, count = hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList.Count(); i < count; i++)
            {
                if (i == count - 1)
                {
                    if (hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList[i].StartYear < CurrentYear)
                    {
                        return string.Format(ServiceRes.AllYearsOf_ShouldBeAscending, hydrometricSiteTVItemIDYearsText.YearsText);
                    }
                    CurrentYear = hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList[i].StartYear;
                    if (hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList[i].EndYear != null)
                    {
                        if (hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList[i].EndYear < CurrentYear)
                        {
                            return string.Format(ServiceRes.AllYearsOf_ShouldBeAscending, hydrometricSiteTVItemIDYearsText.YearsText);
                        }
                        CurrentYear = (int)hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList[i].EndYear;
                    }
                }
                else
                {
                    if (hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList[i].StartYear < CurrentYear)
                    {
                        return string.Format(ServiceRes.AllYearsOf_ShouldBeAscending, hydrometricSiteTVItemIDYearsText.YearsText);
                    }
                    CurrentYear = hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList[i].StartYear;
                    if (hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList[i].EndYear < CurrentYear)
                    {
                        return string.Format(ServiceRes.AllYearsOf_ShouldBeAscending, hydrometricSiteTVItemIDYearsText.YearsText);
                    }
                    CurrentYear = (int)hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList[i].EndYear;
                }
            }

            return "";
        }

        // Post
        public int CheckPercentCompletedDB(int AppTaskID)
        {
            int PercentCompleted = 100;
            AppTask appTask = (from c in db.AppTasks
                               where c.AppTaskID == AppTaskID
                               select c).FirstOrDefault();

            if (appTask != null)
            {
                PercentCompleted = appTask.PercentCompleted;
            }

            return PercentCompleted;
        }
        public AppTaskModel ClimateSiteGetDataForRunsOfYearDB(int SubsectorTVItemID, int Year)
        {
            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return new AppTaskModel() { Error = tvItemModelSubsector.Error };


            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(SubsectorTVItemID, Year, AppTaskCommandEnum.GetClimateSitesDataForRunsOfYear);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return appTaskModelExist;

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "SubsectorTVItemID", Value = SubsectorTVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "Year", Value = Year.ToString() });

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
                TVItemID = SubsectorTVItemID,
                TVItemID2 = SubsectorTVItemID,
                AppTaskCommand = AppTaskCommandEnum.GetClimateSitesDataForRunsOfYear,
                ErrorText = "",
                StatusText = ServiceRes.GetClimateSitesDataForRunsOfYear + " " + Year.ToString(),
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

            return appTaskModelRet;
        }
        public AppTaskModel ClimateSiteLoadCoCoRaHSDataDB()
        {
            TVItemModel tvItemModelRoot = _TVItemService.GetRootTVItemModelDB();
            if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
                return new AppTaskModel() { Error = tvItemModelRoot.Error };


            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(tvItemModelRoot.TVItemID, tvItemModelRoot.TVItemID, AppTaskCommandEnum.ClimateSiteLoadCoCoRaHSData);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return appTaskModelExist;

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "TVItemID", Value = tvItemModelRoot.TVItemID.ToString() });

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
                TVItemID = tvItemModelRoot.TVItemID,
                TVItemID2 = tvItemModelRoot.TVItemID,
                AppTaskCommand = AppTaskCommandEnum.ClimateSiteLoadCoCoRaHSData,
                ErrorText = "",
                StatusText = ServiceRes.ClimateSiteLoadCoCoRaHSData,
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

            return appTaskModelRet;
        }
        public MWQMSubsectorModel ClimateSiteSetDataToUseByAverageOrPriorityDB(int SubsectorTVItemID, int Year, string AverageOrPriority)
        {
            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return ReturnError(tvItemModelSubsector.Error);

            List<UseOfSiteModel> useOfSiteModelList = _UseOfSiteService.GetUseOfSiteModelListWithTVTypeAndSubsectorTVItemIDDB(TVTypeEnum.ClimateSite, SubsectorTVItemID).OrderBy(c => c.Ordinal).ToList();
            if (useOfSiteModelList.Count == 0)
            {
                return ReturnError(ServiceRes.NoClimateSiteHaveBeenSelected + "." + ServiceRes.PleaseSelectClimateSitesAndSetPriorities);
            }

            List<MWQMRunModel> mwqmRunModelList = _MWQMRunService.GetMWQMRunModelListWithSubsectorTVItemIDDB(SubsectorTVItemID).Where(c => c.DateTime_Local.Year == Year).OrderByDescending(c => c.DateTime_Local).ToList();

            int CurrentYear = DateTime.Now.Year;

            // verify that we have all necessary data already in ClimateSiteDataValue table
            foreach (MWQMRunModel mwqmRunModel in mwqmRunModelList)
            {
                DateTime RunDate = new DateTime(mwqmRunModel.DateTime_Local.Year, mwqmRunModel.DateTime_Local.Month, mwqmRunModel.DateTime_Local.Day);
                DateTime RunDateMinus10 = RunDate.AddDays(-10);

                foreach (UseOfSiteModel useOfSiteModel in useOfSiteModelList)
                {
                    int EndYear = 0;
                    if (useOfSiteModel.EndYear == null)
                    {
                        EndYear = CurrentYear;
                    }
                    else
                    {
                        EndYear = (int)useOfSiteModel.EndYear;
                    }

                    if (useOfSiteModel.StartYear <= Year && EndYear >= Year)
                    {

                        ClimateSiteModel climateSiteModel = _ClimateSiteService.GetClimateSiteModelWithClimateSiteTVItemIDDB(useOfSiteModel.SiteTVItemID);
                        if (!string.IsNullOrWhiteSpace(climateSiteModel.Error))
                            return ReturnError(climateSiteModel.Error);

                        if (climateSiteModel.DailyStartDate_Local == null)
                        {
                            continue;
                        }

                        DateTime EndDate = DateTime.Now;
                        if (climateSiteModel.DailyEndDate_Local != null)
                        {
                            EndDate = (DateTime)climateSiteModel.DailyEndDate_Local;
                        }

                        if (climateSiteModel.DailyStartDate_Local <= RunDateMinus10 && EndDate >= RunDate)
                        {
                            List<ClimateDataValue> climateDataValueListTemp = (from c in db.ClimateDataValues
                                                                               where c.ClimateSiteID == climateSiteModel.ClimateSiteID
                                                                               && c.DateTime_Local >= RunDateMinus10
                                                                               && c.DateTime_Local <= RunDate
                                                                               orderby c.DateTime_Local descending
                                                                               select c).Distinct().ToList();

                            List<ClimateDataValue> climateDataValueList = new List<ClimateDataValue>();
                            ClimateDataValue climateDataValueOld = new ClimateDataValue();
                            foreach (ClimateDataValue climateDataValue in climateDataValueListTemp)
                            {
                                if (climateDataValue.DateTime_Local != climateDataValueOld.DateTime_Local)
                                {
                                    climateDataValueList.Add(climateDataValue);
                                }
                                else
                                {
                                    db.ClimateDataValues.Remove(climateDataValue);
                                }

                                climateDataValueOld = climateDataValue;
                            }

                            try
                            {
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                return ReturnError(string.Format(ServiceRes.CouldNotDelete_Error_, ServiceRes.ClimateDataValue, ex.Message + " InnerException: " + (ex.InnerException != null ? ex.InnerException.Message : "")));
                            }

                            if (climateDataValueList.Count != 11)
                            {
                                return ReturnError(string.Format(ServiceRes.AllClimateSiteDataForYear_HaveNotBeenImportedToTheCSSPWebSiteDatabase, Year));
                            }

                            // check that no data is null
                            bool HasBeenRead = (from c in climateDataValueList
                                                where c.HasBeenRead == false
                                                select c).Any();

                            if (HasBeenRead)
                            {
                                return ReturnError(string.Format(ServiceRes.AllClimateSiteDataForYear_HaveNotBeenImportedToTheCSSPWebSiteDatabase, Year));
                            }
                        }
                    }
                }
            }

            // Everything looks ok lets
            foreach (MWQMRunModel mwqmRunModel in mwqmRunModelList)
            {
                DateTime RunDate = new DateTime(mwqmRunModel.DateTime_Local.Year, mwqmRunModel.DateTime_Local.Month, mwqmRunModel.DateTime_Local.Day);
                DateTime RunDateMinus10 = RunDate.AddDays(-10);
                List<List<ClimateDataValue>> climateDataValueListList = new List<List<ClimateDataValue>>();

                foreach (UseOfSiteModel useOfSiteModel in useOfSiteModelList)
                {
                    int EndYear = 0;
                    if (useOfSiteModel.EndYear == null)
                    {
                        EndYear = CurrentYear;
                    }
                    else
                    {
                        EndYear = (int)useOfSiteModel.EndYear;
                    }

                    if (useOfSiteModel.StartYear <= Year && EndYear >= Year)
                    {
                        ClimateSiteModel climateSiteModel = _ClimateSiteService.GetClimateSiteModelWithClimateSiteTVItemIDDB(useOfSiteModel.SiteTVItemID);
                        if (!string.IsNullOrWhiteSpace(climateSiteModel.Error))
                            return ReturnError(climateSiteModel.Error);

                        if (climateSiteModel.DailyStartDate_Local == null)
                        {
                            continue;
                        }

                        DateTime EndDate = DateTime.Now;
                        if (climateSiteModel.DailyEndDate_Local != null)
                        {
                            EndDate = (DateTime)climateSiteModel.DailyEndDate_Local;
                        }

                        if (climateSiteModel.DailyStartDate_Local <= RunDateMinus10 && EndDate >= RunDate)
                        {
                            List<ClimateDataValue> climateDataValueList = (from c in db.ClimateDataValues
                                                                           where c.ClimateSiteID == climateSiteModel.ClimateSiteID
                                                                           && c.DateTime_Local >= RunDateMinus10
                                                                           && c.DateTime_Local <= RunDate
                                                                           orderby c.DateTime_Local descending
                                                                           select c).Distinct().ToList();

                            if (climateDataValueList.Count != 11)
                            {
                                return ReturnError(string.Format(ServiceRes.AllClimateSiteDataForYear_HaveNotBeenImportedToTheCSSPWebSiteDatabase, Year));
                            }

                            // check that no data is null
                            bool HasBeenRead = (from c in climateDataValueList
                                                where c.HasBeenRead == false
                                                select c).Any();

                            if (HasBeenRead)
                            {
                                return ReturnError(string.Format(ServiceRes.AllClimateSiteDataForYear_HaveNotBeenImportedToTheCSSPWebSiteDatabase, Year));
                            }

                            climateDataValueListList.Add(climateDataValueList.OrderByDescending(c => c.DateTime_Local).ToList());
                        }
                    }

                    if (climateDataValueListList.Count == 0)
                    {
                        continue;
                    }

                    if (AverageOrPriority == "Priority")
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            float? DataValue = null;
                            for (int i = 0, countClimateSite = climateDataValueListList.Count(); i < countClimateSite; i++)
                            {
                                if (climateDataValueListList[i][j].TotalPrecip_mm_cm != null)
                                {
                                    DataValue = (float)climateDataValueListList[i][j].TotalPrecip_mm_cm;
                                    break;
                                }
                            }
                            if (DataValue != null)
                            {
                                switch (j)
                                {
                                    case 0:
                                        {
                                            mwqmRunModel.RainDay0_mm = DataValue;
                                        }
                                        break;
                                    case 1:
                                        {
                                            mwqmRunModel.RainDay1_mm = DataValue;
                                        }
                                        break;
                                    case 2:
                                        {
                                            mwqmRunModel.RainDay2_mm = DataValue;
                                        }
                                        break;
                                    case 3:
                                        {
                                            mwqmRunModel.RainDay3_mm = DataValue;
                                        }
                                        break;
                                    case 4:
                                        {
                                            mwqmRunModel.RainDay4_mm = DataValue;
                                        }
                                        break;
                                    case 5:
                                        {
                                            mwqmRunModel.RainDay5_mm = DataValue;
                                        }
                                        break;
                                    case 6:
                                        {
                                            mwqmRunModel.RainDay6_mm = DataValue;
                                        }
                                        break;
                                    case 7:
                                        {
                                            mwqmRunModel.RainDay7_mm = DataValue;
                                        }
                                        break;
                                    case 8:
                                        {
                                            mwqmRunModel.RainDay8_mm = DataValue;
                                        }
                                        break;
                                    case 9:
                                        {
                                            mwqmRunModel.RainDay9_mm = DataValue;
                                        }
                                        break;
                                    case 10:
                                        {
                                            mwqmRunModel.RainDay10_mm = DataValue;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    else if (AverageOrPriority == "Average")
                    {
                        for (int j = 0; j < 11; j++)
                        {
                            float Total = 0;
                            float CountValue = 0;
                            for (int i = 0, countClimateSite = climateDataValueListList.Count(); i < countClimateSite; i++)
                            {
                                if (climateDataValueListList[i][j].TotalPrecip_mm_cm != null)
                                {
                                    CountValue += 1;
                                    Total += (float)climateDataValueListList[i][j].TotalPrecip_mm_cm;
                                }
                            }

                            if (CountValue > 0)
                            {
                                switch (j)
                                {
                                    case 0:
                                        {
                                            mwqmRunModel.RainDay0_mm = Total / CountValue;
                                        }
                                        break;
                                    case 1:
                                        {
                                            mwqmRunModel.RainDay1_mm = Total / CountValue;
                                        }
                                        break;
                                    case 2:
                                        {
                                            mwqmRunModel.RainDay2_mm = Total / CountValue;
                                        }
                                        break;
                                    case 3:
                                        {
                                            mwqmRunModel.RainDay3_mm = Total / CountValue;
                                        }
                                        break;
                                    case 4:
                                        {
                                            mwqmRunModel.RainDay4_mm = Total / CountValue;
                                        }
                                        break;
                                    case 5:
                                        {
                                            mwqmRunModel.RainDay5_mm = Total / CountValue;
                                        }
                                        break;
                                    case 6:
                                        {
                                            mwqmRunModel.RainDay6_mm = Total / CountValue;
                                        }
                                        break;
                                    case 7:
                                        {
                                            mwqmRunModel.RainDay7_mm = Total / CountValue;
                                        }
                                        break;
                                    case 8:
                                        {
                                            mwqmRunModel.RainDay8_mm = Total / CountValue;
                                        }
                                        break;
                                    case 9:
                                        {
                                            mwqmRunModel.RainDay9_mm = Total / CountValue;
                                        }
                                        break;
                                    case 10:
                                        {
                                            mwqmRunModel.RainDay10_mm = Total / CountValue;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        return ReturnError(string.Format(ServiceRes.AverageOrPriorityShouldBeOneOf_, "[Average, Priority]"));
                    }
                }

                MWQMRunModel mwqmRunModelRet = _MWQMRunService.PostUpdateMWQMRunDB(mwqmRunModel);
                if (!string.IsNullOrWhiteSpace(mwqmRunModelRet.Error))
                    return ReturnError(mwqmRunModelRet.Error);
            }

            return ReturnError("");
        }
        public MWQMSubsectorModel ClimateSitePrioritiesSaveDB(FormCollection fc)
        {
            int SubsectorTVItemID = 0;
            List<int> UseOfSiteIDList = new List<int>();
            List<int> OrdinalList = new List<int>();

            int.TryParse(fc["SubsectorTVItemID"], out SubsectorTVItemID);
            if (SubsectorTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID));

            bool Exist = true;
            int CountUniqueUserOfSiteID = 0;
            while (Exist)
            {
                int UseOfSiteID = 0;
                int Ordinal = 0;

                int.TryParse(fc["ClimateSiteUseOfSiteOrdinalList[" + CountUniqueUserOfSiteID + "][UseOfSiteID]"], out UseOfSiteID);
                if (UseOfSiteID == 0)
                {
                    break;
                }
                int.TryParse(fc["ClimateSiteUseOfSiteOrdinalList[" + CountUniqueUserOfSiteID + "][Ordinal]"], out Ordinal);

                UseOfSiteIDList.Add(UseOfSiteID);
                OrdinalList.Add(Ordinal);
                CountUniqueUserOfSiteID += 1;
            }

            MWQMSubsectorModel mwqwmSubsectorModel = GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqwmSubsectorModel.Error))
            {
                return new MWQMSubsectorModel() { Error = mwqwmSubsectorModel.Error };
            }

            using (TransactionScope ts = new TransactionScope())
            {
                for (int i = 0, count = UseOfSiteIDList.Count(); i < count; i++)
                {
                    UseOfSiteModel useOfSiteModel = _UseOfSiteService.GetUseOfSiteModelWithUseOfSiteIDDB(UseOfSiteIDList[i]);
                    useOfSiteModel.Ordinal = OrdinalList[i];
                    UseOfSiteModel useOfSiteModelRet = _UseOfSiteService.PostUpdateUseOfSiteDB(useOfSiteModel);
                    if (!string.IsNullOrWhiteSpace(useOfSiteModelRet.Error))
                    {
                        return ReturnError(useOfSiteModelRet.Error);
                    }
                }

                ts.Complete();
            }

            return ReturnError("");
        }
        public MWQMSubsectorModel ClimateSitePrecipitationEnteredSaveDB(FormCollection fc)
        {
            int SubsectorTVItemID = 0;
            int MWQMRunTVItemID = 0;
            List<float?> RainDay_mmList = new List<float?>();


            int.TryParse(fc["SubsectorTVItemID"], out SubsectorTVItemID);
            if (SubsectorTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID));

            int.TryParse(fc["MWQMRunTVItemID"], out MWQMRunTVItemID);
            if (MWQMRunTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMRunTVItemID));

            for (int i = 0; i < 11; i++)
            {
                if (string.IsNullOrWhiteSpace(fc["RainDay" + i.ToString() + "_mm"].Trim()))
                {
                    RainDay_mmList.Add(null);
                }
                else
                {
                    float temp = 0.0f;
                    if (float.TryParse(fc["RainDay" + i.ToString() + "_mm"], out temp))
                    {
                        RainDay_mmList.Add(temp);
                    }
                    else
                    {
                        return ReturnError(string.Format(ServiceRes._ShouldBeANumber, "RainDay" + i.ToString() + "_mm"));
                    }
                }
            }

            MWQMSubsectorModel mwqwmSubsectorModel = GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqwmSubsectorModel.Error))
            {
                return new MWQMSubsectorModel() { Error = mwqwmSubsectorModel.Error };
            }

            MWQMRunModel mwqmRunModel = _MWQMRunService.GetMWQMRunModelWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqmRunModel.Error))
            {
                return new MWQMSubsectorModel() { Error = mwqmRunModel.Error };
            }

            mwqmRunModel.RainDay0_mm = RainDay_mmList[0];
            mwqmRunModel.RainDay1_mm = RainDay_mmList[1];
            mwqmRunModel.RainDay2_mm = RainDay_mmList[2];
            mwqmRunModel.RainDay3_mm = RainDay_mmList[3];
            mwqmRunModel.RainDay4_mm = RainDay_mmList[4];
            mwqmRunModel.RainDay5_mm = RainDay_mmList[5];
            mwqmRunModel.RainDay6_mm = RainDay_mmList[6];
            mwqmRunModel.RainDay7_mm = RainDay_mmList[7];
            mwqmRunModel.RainDay8_mm = RainDay_mmList[8];
            mwqmRunModel.RainDay9_mm = RainDay_mmList[9];
            mwqmRunModel.RainDay10_mm = RainDay_mmList[10];


            MWQMRunModel mwqwmRunModelRet = _MWQMRunService.PostUpdateMWQMRunDB(mwqmRunModel);
            if (!string.IsNullOrWhiteSpace(mwqwmRunModelRet.Error))
            {
                return new MWQMSubsectorModel() { Error = mwqwmRunModelRet.Error };
            }

            return ReturnError("");

        }
        public MWQMSubsectorModel ClimateSitesToUseForSubsectorVerifyAndSaveDB(FormCollection fc)
        {
            int SubsectorTVItemID = 0;
            List<ClimateSiteTVItemIDYearsText> climateSiteTVItemIDYearsTextList = new List<ClimateSiteTVItemIDYearsText>();
            List<int> climateSiteTVItemIDList = new List<int>();

            int.TryParse(fc["SubsectorTVItemID"], out SubsectorTVItemID);
            if (SubsectorTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID));

            bool Exist = true;
            int CountClimateSite = 0;
            while (Exist)
            {
                int ClimateSiteTVItemID = 0;
                string YearsText = "";

                int.TryParse(fc["ClimateSiteYearsList[" + CountClimateSite + "][ClimateSiteTVItemID]"], out ClimateSiteTVItemID);
                if (ClimateSiteTVItemID == 0)
                {
                    break;
                }
                YearsText = fc["ClimateSiteYearsList[" + CountClimateSite + "][YearsText]"];

                climateSiteTVItemIDYearsTextList.Add(new ClimateSiteTVItemIDYearsText() { ClimateSiteTVItemID = ClimateSiteTVItemID, YearsText = YearsText });
                climateSiteTVItemIDList.Add(ClimateSiteTVItemID);

                CountClimateSite += 1;
            }

            foreach (ClimateSiteTVItemIDYearsText climateSiteTVItemIDYearsText in climateSiteTVItemIDYearsTextList)
            {
                string retStr = FillClimateSiteUseStartEndYears(climateSiteTVItemIDYearsText);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return ReturnError(retStr);
                }
            }

            MWQMSubsectorModel mwqwmSubsectorModel = GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqwmSubsectorModel.Error))
            {
                return new MWQMSubsectorModel() { Error = mwqwmSubsectorModel.Error };
            }

            // do remove
            List<UseOfSiteModel> useOfSiteModelList = _UseOfSiteService.GetUseOfSiteModelListWithTVTypeAndSubsectorTVItemIDDB(TVTypeEnum.ClimateSite, SubsectorTVItemID);
            foreach (UseOfSiteModel useOfSiteToDelete in useOfSiteModelList)
            {
                UseOfSiteModel useOfSiteModelRet = _UseOfSiteService.PostDeleteUseOfSiteDB(useOfSiteToDelete.UseOfSiteID);
                if (!string.IsNullOrWhiteSpace(useOfSiteModelRet.Error))
                {
                    return ReturnError(useOfSiteModelRet.Error);
                }
            }

            // do add
            foreach (ClimateSiteTVItemIDYearsText climateSiteTVItemIDYearsText in climateSiteTVItemIDYearsTextList)
            {
                List<UseOfSiteModel> useOfSiteModelListAlreadyInDB = useOfSiteModelList.Where(c => c.SiteTVItemID == climateSiteTVItemIDYearsText.ClimateSiteTVItemID && c.TVType == TVTypeEnum.ClimateSite).OrderBy(c => c.StartYear).ToList();

                for (int i = 0, count = climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList.Count(); i < count; i++)
                {
                    int StartYear = climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[i].StartYear;
                    int? EndYear = climateSiteTVItemIDYearsText.ClimateSiteUseStartEndYearList[i].EndYear;

                    UseOfSiteModel useOfSiteModelNew = new UseOfSiteModel()
                    {
                        Ordinal = 0,
                        SiteTVItemID = climateSiteTVItemIDYearsText.ClimateSiteTVItemID,
                        TVType = TVTypeEnum.ClimateSite,
                        SubsectorTVItemID = SubsectorTVItemID,
                        StartYear = StartYear,
                        EndYear = EndYear,
                    };
                    UseOfSiteModel useOfSiteModelRet = _UseOfSiteService.PostAddUseOfSiteDB(useOfSiteModelNew);
                    if (!string.IsNullOrWhiteSpace(useOfSiteModelRet.Error))
                    {
                        return ReturnError(useOfSiteModelRet.Error);
                    }
                }
            }

            return ReturnError("");
        }
        public MWQMSubsectorModel ClimateSitesUseSameAsSelectedSubsectorDB(int SubsectorTVItemID, int UseSubsectorTVItemID)
        {
            TVItemModel tvItemModelCurrentSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelCurrentSubsector.Error))
            {
                return ReturnError(tvItemModelCurrentSubsector.Error);
            }

            TVItemModel tvItemModelUseSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(UseSubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelUseSubsector.Error))
            {
                return ReturnError(tvItemModelUseSubsector.Error);
            }

            List<UseOfSiteModel> useOfSiteModelList = _UseOfSiteService.GetUseOfSiteModelListWithTVTypeAndSubsectorTVItemIDDB(TVTypeEnum.ClimateSite, SubsectorTVItemID);
            if (useOfSiteModelList.Count > 0)
            {
                return ReturnError(string.Format(ServiceRes.Subsector_AlreadyHasSomeClimateSitesSelected, tvItemModelCurrentSubsector.TVText));
            }

            List<UseOfSiteModel> useOfSiteModelList2 = _UseOfSiteService.GetUseOfSiteModelListWithTVTypeAndSubsectorTVItemIDDB(TVTypeEnum.ClimateSite, UseSubsectorTVItemID);
            if (useOfSiteModelList2.Count == 0)
            {
                return ReturnError(string.Format(ServiceRes.Subsector_DoesNotHaveAnyClimateSitesSelected, tvItemModelUseSubsector.TVText));
            }

            using (TransactionScope ts = new TransactionScope())
            {
                foreach (UseOfSiteModel useOfSiteModel in useOfSiteModelList2)
                {
                    UseOfSiteModel useOfSiteModelNew = new UseOfSiteModel()
                    {
                        EndYear = useOfSiteModel.EndYear,
                        Ordinal = useOfSiteModel.Ordinal,
                        Param1 = useOfSiteModel.Param1,
                        Param2 = useOfSiteModel.Param2,
                        Param3 = useOfSiteModel.Param3,
                        Param4 = useOfSiteModel.Param4,
                        SiteTVItemID = useOfSiteModel.SiteTVItemID,
                        TVType = useOfSiteModel.TVType,
                        StartYear = useOfSiteModel.StartYear,
                        SubsectorTVItemID = SubsectorTVItemID,
                        UseEquation = useOfSiteModel.UseEquation,
                        UseWeight = useOfSiteModel.UseWeight,
                        Weight_perc = useOfSiteModel.Weight_perc,
                    };

                    UseOfSiteModel useOfSiteModelRet = _UseOfSiteService.PostAddUseOfSiteDB(useOfSiteModelNew);
                    if (!string.IsNullOrWhiteSpace(useOfSiteModelRet.Error))
                    {
                        return ReturnError(useOfSiteModelRet.Error);
                    }
                }

                ts.Complete();
            }
            return ReturnError("");
        }
        public AppTaskModel HydrometricSiteGetDataForRunsOfYearDB(int SubsectorTVItemID, int Year)
        {
            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return new AppTaskModel() { Error = tvItemModelSubsector.Error };


            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(SubsectorTVItemID, Year, AppTaskCommandEnum.GetHydrometricSitesDataForRunsOfYear);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return appTaskModelExist;

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "SubsectorTVItemID", Value = SubsectorTVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "Year", Value = Year.ToString() });

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
                TVItemID = SubsectorTVItemID,
                TVItemID2 = SubsectorTVItemID,
                AppTaskCommand = AppTaskCommandEnum.GetHydrometricSitesDataForRunsOfYear,
                ErrorText = "",
                StatusText = ServiceRes.GetHydrometricSitesDataForRunsOfYear + " " + Year.ToString(),
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

            return appTaskModelRet;
        }
        public MWQMSubsectorModel HydrometricSitesToUseForSubsectorVerifyAndSaveDB(FormCollection fc)
        {
            int SubsectorTVItemID = 0;
            List<HydrometricSiteTVItemIDYearsText> hydrometricSiteTVItemIDYearsTextList = new List<HydrometricSiteTVItemIDYearsText>();
            List<int> hydrometricSiteTVItemIDList = new List<int>();

            int.TryParse(fc["SubsectorTVItemID"], out SubsectorTVItemID);
            if (SubsectorTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID));

            bool Exist = true;
            int CountHydrometricSite = 0;
            while (Exist)
            {
                int HydrometricSiteTVItemID = 0;
                string YearsText = "";

                int.TryParse(fc["HydrometricSiteYearsList[" + CountHydrometricSite + "][HydrometricSiteTVItemID]"], out HydrometricSiteTVItemID);
                if (HydrometricSiteTVItemID == 0)
                {
                    break;
                }
                YearsText = fc["HydrometricSiteYearsList[" + CountHydrometricSite + "][YearsText]"];

                hydrometricSiteTVItemIDYearsTextList.Add(new HydrometricSiteTVItemIDYearsText() { HydrometricSiteTVItemID = HydrometricSiteTVItemID, YearsText = YearsText });
                hydrometricSiteTVItemIDList.Add(HydrometricSiteTVItemID);

                CountHydrometricSite += 1;
            }

            foreach (HydrometricSiteTVItemIDYearsText hydrometricSiteTVItemIDYearsText in hydrometricSiteTVItemIDYearsTextList)
            {
                string retStr = FillHydrometricSiteUseStartEndYears(hydrometricSiteTVItemIDYearsText);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return ReturnError(retStr);
                }
            }

            MWQMSubsectorModel mwqwmSubsectorModel = GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqwmSubsectorModel.Error))
            {
                return new MWQMSubsectorModel() { Error = mwqwmSubsectorModel.Error };
            }

            // do remove
            List<UseOfSiteModel> useOfSiteModelList = _UseOfSiteService.GetUseOfSiteModelListWithTVTypeAndSubsectorTVItemIDDB(TVTypeEnum.HydrometricSite, SubsectorTVItemID);
            foreach (UseOfSiteModel useOfSiteToDelete in useOfSiteModelList)
            {
                UseOfSiteModel useOfSiteModelRet = _UseOfSiteService.PostDeleteUseOfSiteDB(useOfSiteToDelete.UseOfSiteID);
                if (!string.IsNullOrWhiteSpace(useOfSiteModelRet.Error))
                {
                    return ReturnError(useOfSiteModelRet.Error);
                }
            }

            // do add
            foreach (HydrometricSiteTVItemIDYearsText hydrometricSiteTVItemIDYearsText in hydrometricSiteTVItemIDYearsTextList)
            {
                List<UseOfSiteModel> useOfSiteModelListAlreadyInDB = useOfSiteModelList.Where(c => c.SiteTVItemID == hydrometricSiteTVItemIDYearsText.HydrometricSiteTVItemID && c.TVType == TVTypeEnum.HydrometricSite).OrderBy(c => c.StartYear).ToList();

                for (int i = 0, count = hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList.Count(); i < count; i++)
                {
                    int StartYear = hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList[i].StartYear;
                    int? EndYear = hydrometricSiteTVItemIDYearsText.HydrometricSiteUseStartEndYearList[i].EndYear;

                    UseOfSiteModel useOfSiteModelNew = new UseOfSiteModel()
                    {
                        Ordinal = 0,
                        SiteTVItemID = hydrometricSiteTVItemIDYearsText.HydrometricSiteTVItemID,
                        TVType = TVTypeEnum.HydrometricSite,
                        SubsectorTVItemID = SubsectorTVItemID,
                        StartYear = StartYear,
                        EndYear = EndYear,
                    };
                    UseOfSiteModel useOfSiteModelRet = _UseOfSiteService.PostAddUseOfSiteDB(useOfSiteModelNew);
                    if (!string.IsNullOrWhiteSpace(useOfSiteModelRet.Error))
                    {
                        return ReturnError(useOfSiteModelRet.Error);
                    }
                }
            }

            return ReturnError("");
        }
        public MWQMSubsectorModel MunicipalitiesToUseForSubsectorVerifyAndSaveDB(FormCollection fc)
        {
            int SubsectorTVItemID = 0;
            List<int> municipalityTVItemIDList = new List<int>();

            int.TryParse(fc["SubsectorTVItemID"], out SubsectorTVItemID);
            if (SubsectorTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID));

            string MunicipalityTVItemIDListText = fc["MunicipalityTVItemIDList"];

            List<string> idArr = MunicipalityTVItemIDListText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string s in idArr)
            {
                municipalityTVItemIDList.Add(int.Parse(s));
            }

            MWQMSubsectorModel mwqwmSubsectorModel = GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqwmSubsectorModel.Error))
            {
                return new MWQMSubsectorModel() { Error = mwqwmSubsectorModel.Error };
            }

            // do remove
            List<UseOfSiteModel> useOfSiteModelList = _UseOfSiteService.GetUseOfSiteModelListWithTVTypeAndSubsectorTVItemIDDB(TVTypeEnum.Municipality, SubsectorTVItemID);
            foreach (UseOfSiteModel useOfSiteToDelete in useOfSiteModelList)
            {
                UseOfSiteModel useOfSiteModelRet = _UseOfSiteService.PostDeleteUseOfSiteDB(useOfSiteToDelete.UseOfSiteID);
                if (!string.IsNullOrWhiteSpace(useOfSiteModelRet.Error))
                {
                    return ReturnError(useOfSiteModelRet.Error);
                }
            }

            // do add
            foreach (int municipalityTVItemID in municipalityTVItemIDList)
            {
                UseOfSiteModel useOfSiteModelNew = new UseOfSiteModel()
                {
                    Ordinal = 0,
                    SiteTVItemID = municipalityTVItemID,
                    TVType = TVTypeEnum.Municipality,
                    SubsectorTVItemID = SubsectorTVItemID,
                    StartYear = 1980,
                    EndYear = 1980,
                };

                UseOfSiteModel useOfSiteModelRet = _UseOfSiteService.PostAddUseOfSiteDB(useOfSiteModelNew);
                if (!string.IsNullOrWhiteSpace(useOfSiteModelRet.Error))
                {
                    return ReturnError(useOfSiteModelRet.Error);
                }
            }

            return ReturnError("");
        }
        public MWQMSubsectorModel TideSitesToUseForSubsectorVerifyAndSaveDB(FormCollection fc)
        {
            int SubsectorTVItemID = 0;
            List<int> tideSiteTVItemIDList = new List<int>();

            int.TryParse(fc["SubsectorTVItemID"], out SubsectorTVItemID);
            if (SubsectorTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID));

            string TideSiteTVItemIDListText = fc["TideSiteTVItemIDList"];

            List<string> idArr = TideSiteTVItemIDListText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string s in idArr)
            {
                tideSiteTVItemIDList.Add(int.Parse(s));
            }

            MWQMSubsectorModel mwqwmSubsectorModel = GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqwmSubsectorModel.Error))
            {
                return new MWQMSubsectorModel() { Error = mwqwmSubsectorModel.Error };
            }

            // do remove
            List<UseOfSiteModel> useOfSiteModelList = _UseOfSiteService.GetUseOfSiteModelListWithTVTypeAndSubsectorTVItemIDDB(TVTypeEnum.TideSite, SubsectorTVItemID);
            foreach (UseOfSiteModel useOfSiteToDelete in useOfSiteModelList)
            {
                UseOfSiteModel useOfSiteModelRet = _UseOfSiteService.PostDeleteUseOfSiteDB(useOfSiteToDelete.UseOfSiteID);
                if (!string.IsNullOrWhiteSpace(useOfSiteModelRet.Error))
                {
                    return ReturnError(useOfSiteModelRet.Error);
                }
            }

            // do add
            foreach (int tideSiteTVItemID in tideSiteTVItemIDList)
            {
                UseOfSiteModel useOfSiteModelNew = new UseOfSiteModel()
                {
                    Ordinal = 0,
                    SiteTVItemID = tideSiteTVItemID,
                    TVType = TVTypeEnum.TideSite,
                    SubsectorTVItemID = SubsectorTVItemID,
                    StartYear = 1980,
                    EndYear = 1980,
                };

                UseOfSiteModel useOfSiteModelRet = _UseOfSiteService.PostAddUseOfSiteDB(useOfSiteModelNew);
                if (!string.IsNullOrWhiteSpace(useOfSiteModelRet.Error))
                {
                    return ReturnError(useOfSiteModelRet.Error);
                }
            }

            return ReturnError("");
        }
        public MWQMSubsectorModel MWQMSubsectorAddOrModifyDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int SubsectorTVItemID = 0;
            string SubsectorDesc = "";
            string LogBook = "";

            if (!int.TryParse(fc["SubsectorTVItemID"], out SubsectorTVItemID))
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID));
            }

            SubsectorDesc = fc["SubsectorDesc"];
            LogBook = fc["LogBook"];

            MWQMSubsectorModel mwqmSubsectorModel = GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorModel.Error))
            {
                return ReturnError(mwqmSubsectorModel.Error);
            }

            MWQMSubsectorLanguageModel mwqmSubsectorLanguageModel = _MWQMSubsectorLanguageService.GetMWQMSubsectorLanguageModelWithMWQMSubsectorIDAndLanguageDB(mwqmSubsectorModel.MWQMSubsectorID, LanguageRequest);
            using (TransactionScope ts = new TransactionScope())
            {
                if (mwqmSubsectorLanguageModel.SubsectorDesc != SubsectorDesc)
                {
                    mwqmSubsectorLanguageModel.TranslationStatusSubsectorDesc = TranslationStatusEnum.Translated;
                }
                mwqmSubsectorLanguageModel.SubsectorDesc = (SubsectorDesc == null ? "" : SubsectorDesc.Trim());

                if (mwqmSubsectorLanguageModel.LogBook != LogBook)
                {
                    mwqmSubsectorLanguageModel.TranslationStatusLogBook = TranslationStatusEnum.Translated;
                }
                mwqmSubsectorLanguageModel.LogBook = (LogBook == null ? "" : LogBook.Trim());

                foreach (LanguageEnum language in LanguageListAllowable)
                {
                    if (language == LanguageRequest)
                    {
                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = _MWQMSubsectorLanguageService.PostUpdateMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModel);
                        if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageModelRet.Error))
                        {
                            return ReturnError(mwqmSubsectorLanguageModelRet.Error);
                        }
                    }
                }

                ts.Complete();
            }
            return GetMWQMSubsectorModelWithMWQMSubsectorTVItemIDDB(SubsectorTVItemID);
        }
        public MWQMSubsectorModel PostAddMWQMSubsectorDB(MWQMSubsectorModel mwqmSubsectorModel)
        {
            string retStr = MWQMSubsectorModelOK(mwqmSubsectorModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(mwqmSubsectorModel.MWQMSubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return ReturnError(tvItemModelSubsector.Error);

            MWQMSubsector mwqmSubsectorExist = GetMWQMSubsectorExistDB(mwqmSubsectorModel);
            if (mwqmSubsectorExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMSubsector));

            MWQMSubsector mwqmSubsectorNew = new MWQMSubsector();
            retStr = FillMWQMSubsector(mwqmSubsectorNew, mwqmSubsectorModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSubsectors.Add(mwqmSubsectorNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSubsectors", mwqmSubsectorNew.MWQMSubsectorID, LogCommandEnum.Add, mwqmSubsectorNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModel = new MWQMSubsectorLanguageModel()
                    {
                        MWQMSubsectorID = mwqmSubsectorNew.MWQMSubsectorID,
                        Language = Lang,
                        SubsectorDesc = mwqmSubsectorModel.SubsectorDesc,
                        TranslationStatusSubsectorDesc = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                        LogBook = mwqmSubsectorModel.SubsectorDesc,
                        TranslationStatusLogBook = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = _MWQMSubsectorLanguageService.PostAddMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModel);
                    if (!string.IsNullOrEmpty(mwqmSubsectorLanguageModelRet.Error))
                        return ReturnError(mwqmSubsectorLanguageModelRet.Error);
                }

                ts.Complete();
            }
            return GetMWQMSubsectorModelWithMWQMSubsectorIDDB(mwqmSubsectorNew.MWQMSubsectorID);
        }
        public MWQMSubsectorModel PostDeleteMWQMSubsectorDB(int MWQMSubsectorID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSubsector mwqmSubsectorToDelete = GetMWQMSubsectorWithMWQMSubsectorIDDB(MWQMSubsectorID);
            if (mwqmSubsectorToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMSubsector));

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSubsectors.Remove(mwqmSubsectorToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSubsectors", mwqmSubsectorToDelete.MWQMSubsectorID, LogCommandEnum.Delete, mwqmSubsectorToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public MWQMSubsectorModel PostUpdateMWQMSubsectorDB(MWQMSubsectorModel mwqmSubsectorModel)
        {
            string retStr = MWQMSubsectorModelOK(mwqmSubsectorModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSubsector mwqmSubsectorToUpdate = GetMWQMSubsectorWithMWQMSubsectorIDDB(mwqmSubsectorModel.MWQMSubsectorID);
            if (mwqmSubsectorToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSubsector));

            retStr = FillMWQMSubsector(mwqmSubsectorToUpdate, mwqmSubsectorModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSubsectors", mwqmSubsectorToUpdate.MWQMSubsectorID, LogCommandEnum.Change, mwqmSubsectorToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModel = new MWQMSubsectorLanguageModel()
                        {
                            MWQMSubsectorID = mwqmSubsectorModel.MWQMSubsectorID,
                            Language = Lang,
                            SubsectorDesc = mwqmSubsectorModel.SubsectorDesc,
                            TranslationStatusSubsectorDesc = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                            LogBook = mwqmSubsectorModel.SubsectorDesc,
                            TranslationStatusLogBook = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                        };

                        if (!string.IsNullOrWhiteSpace(mwqmSubsectorLanguageModel.SubsectorDesc))
                        {
                            mwqmSubsectorLanguageModel.SubsectorDesc = ServiceRes.Empty;
                        }

                        MWQMSubsectorLanguageModel mwqmSubsectorLanguageModelRet = _MWQMSubsectorLanguageService.PostUpdateMWQMSubsectorLanguageDB(mwqmSubsectorLanguageModel);
                        if (!string.IsNullOrEmpty(mwqmSubsectorLanguageModelRet.Error))
                            return ReturnError(mwqmSubsectorLanguageModelRet.Error);
                    }
                }

                ts.Complete();
            }
            return GetMWQMSubsectorModelWithMWQMSubsectorIDDB(mwqmSubsectorToUpdate.MWQMSubsectorID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
