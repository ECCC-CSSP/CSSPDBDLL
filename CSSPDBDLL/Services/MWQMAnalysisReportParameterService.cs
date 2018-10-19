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
    public class MWQMAnalysisReportParameterService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public AppTaskService _AppTaskService { get; private set; }
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _LogService = new LogService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _AppTaskService = new AppTaskService(LanguageRequest, User);
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
        public string MWQMAnalysisReportParameterModelOK(MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModel)
        {
            string retStr = FieldCheckNotZeroInt(mwqmAnalysisReportParameterModel.SubsectorTVItemID, ServiceRes.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(mwqmAnalysisReportParameterModel.AnalysisName, ServiceRes.AnalysisName, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.AnalysisReportExportCommandOK(mwqmAnalysisReportParameterModel.Command);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (mwqmAnalysisReportParameterModel.Command == AnalysisReportExportCommandEnum.Report)
            {
                retStr = FieldCheckNotNullAndWithinRangeInt(mwqmAnalysisReportParameterModel.AnalysisReportYear, ServiceRes.AnalysisReportYear, 1980, 2050);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (mwqmAnalysisReportParameterModel.StartDate < new DateTime(1980, 1, 1))
            {
                return string.Format(ServiceRes._ShouldBeAfter_, ServiceRes.StartDate, new DateTime(1980, 1, 1));
            }

            if (mwqmAnalysisReportParameterModel.EndDate < new DateTime(1980, 1, 1))
            {
                return string.Format(ServiceRes._ShouldBeAfter_, ServiceRes.EndDate, new DateTime(1980, 1, 1));
            }

            // In this particular case the StartDate should actually bigger than the end date since we are analysing everyting starting 
            // with the earliest run date.
            if (mwqmAnalysisReportParameterModel.EndDate > mwqmAnalysisReportParameterModel.StartDate)
            {
                return string.Format(ServiceRes._IsBiggerOrEqualTo_, ServiceRes.EndDate, ServiceRes.StartDate);
            }

            retStr = _BaseEnumService.AnalysisCalculationTypeOK(mwqmAnalysisReportParameterModel.AnalysisCalculationType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmAnalysisReportParameterModel.NumberOfRuns, ServiceRes.NumberOfRuns, 5, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mwqmAnalysisReportParameterModel.SalinityHighlightDeviationFromAverage, ServiceRes.SalinityHighlightDeviationFromAverage, 1.0f, 30.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmAnalysisReportParameterModel.ShortRangeNumberOfDays, ServiceRes.ShortRangeNumberOfDays, -5, -1);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmAnalysisReportParameterModel.MidRangeNumberOfDays, ServiceRes.MidRangeNumberOfDays, -8, -2);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmAnalysisReportParameterModel.DryLimit24h, ServiceRes.DryLimit24h, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmAnalysisReportParameterModel.DryLimit48h, ServiceRes.DryLimit48h, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmAnalysisReportParameterModel.DryLimit72h, ServiceRes.DryLimit72h, 1, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmAnalysisReportParameterModel.DryLimit96h, ServiceRes.DryLimit96h, 1, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmAnalysisReportParameterModel.WetLimit24h, ServiceRes.WetLimit24h, 1, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmAnalysisReportParameterModel.WetLimit48h, ServiceRes.WetLimit48h, 1, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmAnalysisReportParameterModel.WetLimit72h, ServiceRes.WetLimit72h, 1, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmAnalysisReportParameterModel.WetLimit96h, ServiceRes.WetLimit96h, 1, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(mwqmAnalysisReportParameterModel.RunsToOmit, ServiceRes.RunsToOmit, 4000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(mwqmAnalysisReportParameterModel.ShowDataTypes, ServiceRes.ShowDataTypes, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMWQMAnalysisReportParameter(MWQMAnalysisReportParameter mwqmAnalysisReportParameterNew, MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModel, ContactOK contactOK)
        {
            mwqmAnalysisReportParameterNew.SubsectorTVItemID = mwqmAnalysisReportParameterModel.SubsectorTVItemID;
            mwqmAnalysisReportParameterNew.AnalysisName = mwqmAnalysisReportParameterModel.AnalysisName;
            mwqmAnalysisReportParameterNew.AnalysisReportYear = mwqmAnalysisReportParameterModel.AnalysisReportYear;
            mwqmAnalysisReportParameterNew.StartDate = mwqmAnalysisReportParameterModel.StartDate;
            mwqmAnalysisReportParameterNew.EndDate = mwqmAnalysisReportParameterModel.EndDate;
            mwqmAnalysisReportParameterNew.AnalysisCalculationType = (int)mwqmAnalysisReportParameterModel.AnalysisCalculationType;
            mwqmAnalysisReportParameterNew.NumberOfRuns = mwqmAnalysisReportParameterModel.NumberOfRuns;
            mwqmAnalysisReportParameterNew.FullYear = mwqmAnalysisReportParameterModel.FullYear;
            mwqmAnalysisReportParameterNew.SalinityHighlightDeviationFromAverage = mwqmAnalysisReportParameterModel.SalinityHighlightDeviationFromAverage;
            mwqmAnalysisReportParameterNew.ShortRangeNumberOfDays = mwqmAnalysisReportParameterModel.ShortRangeNumberOfDays;
            mwqmAnalysisReportParameterNew.MidRangeNumberOfDays = mwqmAnalysisReportParameterModel.MidRangeNumberOfDays;
            mwqmAnalysisReportParameterNew.DryLimit24h = mwqmAnalysisReportParameterModel.DryLimit24h;
            mwqmAnalysisReportParameterNew.DryLimit48h = mwqmAnalysisReportParameterModel.DryLimit48h;
            mwqmAnalysisReportParameterNew.DryLimit72h = mwqmAnalysisReportParameterModel.DryLimit72h;
            mwqmAnalysisReportParameterNew.DryLimit96h = mwqmAnalysisReportParameterModel.DryLimit96h;
            mwqmAnalysisReportParameterNew.WetLimit24h = mwqmAnalysisReportParameterModel.WetLimit24h;
            mwqmAnalysisReportParameterNew.WetLimit48h = mwqmAnalysisReportParameterModel.WetLimit48h;
            mwqmAnalysisReportParameterNew.WetLimit72h = mwqmAnalysisReportParameterModel.WetLimit72h;
            mwqmAnalysisReportParameterNew.WetLimit96h = mwqmAnalysisReportParameterModel.WetLimit96h;
            mwqmAnalysisReportParameterNew.RunsToOmit = mwqmAnalysisReportParameterModel.RunsToOmit;
            mwqmAnalysisReportParameterNew.ShowDataTypes = mwqmAnalysisReportParameterModel.ShowDataTypes;
            mwqmAnalysisReportParameterNew.ExcelTVFileTVItemID = mwqmAnalysisReportParameterModel.ExcelTVFileTVItemID;
            mwqmAnalysisReportParameterNew.Command = (int)mwqmAnalysisReportParameterModel.Command;
            mwqmAnalysisReportParameterNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mwqmAnalysisReportParameterNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mwqmAnalysisReportParameterNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMWQMAnalysisReportParameterModelCountDB()
        {
            int MWQMAnalysisReportParameterModelCount = (from c in db.MWQMAnalysisReportParameters
                                                         select c).Count();

            return MWQMAnalysisReportParameterModelCount;
        }
        public List<MWQMAnalysisReportParameterModel> GetMWQMAnalysisReportParameterModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<MWQMAnalysisReportParameterModel> mwqmAnalysisReportParameterModelList = (from c in db.MWQMAnalysisReportParameters
                                                                                           let ExcelTVFileTVText = (from cl in db.TVItemLanguages where c.ExcelTVFileTVItemID == cl.TVItemID select cl.TVText).FirstOrDefault()
                                                                                           where c.SubsectorTVItemID == SubsectorTVItemID
                                                                                           select new MWQMAnalysisReportParameterModel
                                                                                           {
                                                                                               Error = "",
                                                                                               MWQMAnalysisReportParameterID = c.MWQMAnalysisReportParameterID,
                                                                                               SubsectorTVItemID = c.SubsectorTVItemID,
                                                                                               AnalysisName = c.AnalysisName,
                                                                                               AnalysisReportYear = c.AnalysisReportYear,
                                                                                               StartDate = c.StartDate,
                                                                                               EndDate = c.EndDate,
                                                                                               AnalysisCalculationType = (AnalysisCalculationTypeEnum)c.AnalysisCalculationType,
                                                                                               NumberOfRuns = c.NumberOfRuns,
                                                                                               FullYear = c.FullYear,
                                                                                               SalinityHighlightDeviationFromAverage = (float)c.SalinityHighlightDeviationFromAverage,
                                                                                               ShortRangeNumberOfDays = c.ShortRangeNumberOfDays,
                                                                                               MidRangeNumberOfDays = c.MidRangeNumberOfDays,
                                                                                               DryLimit24h = c.DryLimit24h,
                                                                                               DryLimit48h = c.DryLimit48h,
                                                                                               DryLimit72h = c.DryLimit72h,
                                                                                               DryLimit96h = c.DryLimit96h,
                                                                                               WetLimit24h = c.WetLimit24h,
                                                                                               WetLimit48h = c.WetLimit48h,
                                                                                               WetLimit72h = c.WetLimit72h,
                                                                                               WetLimit96h = c.WetLimit96h,
                                                                                               RunsToOmit = c.RunsToOmit,
                                                                                               ShowDataTypes = c.ShowDataTypes,
                                                                                               ExcelTVFileTVItemID = c.ExcelTVFileTVItemID,
                                                                                               ExcelTVFileTVText = ExcelTVFileTVText,
                                                                                               Command = (AnalysisReportExportCommandEnum)c.Command,
                                                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                           }).ToList<MWQMAnalysisReportParameterModel>();

            return mwqmAnalysisReportParameterModelList;
        }
        public MWQMAnalysisReportParameterModel GetMWQMAnalysisReportParameterModelWithSubsectorTVItemIDAndAnalysisNameDB(int SubsectorTVItemID, string AnalysisName)
        {
            MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModel = (from c in db.MWQMAnalysisReportParameters
                                                                                 let ExcelTVFileTVText = (from cl in db.TVItemLanguages where c.ExcelTVFileTVItemID == cl.TVItemID select cl.TVText).FirstOrDefault()
                                                                                 where c.SubsectorTVItemID == SubsectorTVItemID
                                                                                 && c.AnalysisName == AnalysisName
                                                                                 select new MWQMAnalysisReportParameterModel
                                                                                 {
                                                                                     Error = "",
                                                                                     MWQMAnalysisReportParameterID = c.MWQMAnalysisReportParameterID,
                                                                                     SubsectorTVItemID = c.SubsectorTVItemID,
                                                                                     AnalysisName = c.AnalysisName,
                                                                                     AnalysisReportYear = c.AnalysisReportYear,
                                                                                     StartDate = c.StartDate,
                                                                                     EndDate = c.EndDate,
                                                                                     AnalysisCalculationType = (AnalysisCalculationTypeEnum)c.AnalysisCalculationType,
                                                                                     NumberOfRuns = c.NumberOfRuns,
                                                                                     FullYear = c.FullYear,
                                                                                     SalinityHighlightDeviationFromAverage = (float)c.SalinityHighlightDeviationFromAverage,
                                                                                     ShortRangeNumberOfDays = c.ShortRangeNumberOfDays,
                                                                                     MidRangeNumberOfDays = c.MidRangeNumberOfDays,
                                                                                     DryLimit24h = c.DryLimit24h,
                                                                                     DryLimit48h = c.DryLimit48h,
                                                                                     DryLimit72h = c.DryLimit72h,
                                                                                     DryLimit96h = c.DryLimit96h,
                                                                                     WetLimit24h = c.WetLimit24h,
                                                                                     WetLimit48h = c.WetLimit48h,
                                                                                     WetLimit72h = c.WetLimit72h,
                                                                                     WetLimit96h = c.WetLimit96h,
                                                                                     RunsToOmit = c.RunsToOmit,
                                                                                     ShowDataTypes = c.ShowDataTypes,
                                                                                     ExcelTVFileTVItemID = c.ExcelTVFileTVItemID,
                                                                                     ExcelTVFileTVText = ExcelTVFileTVText,
                                                                                     Command = (AnalysisReportExportCommandEnum)c.Command,
                                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                 }).FirstOrDefault<MWQMAnalysisReportParameterModel>();

            if (mwqmAnalysisReportParameterModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMAnalysisReportParameter,
                    ServiceRes.SubsectorTVItemID + ", " +
                    ServiceRes.AnalysisName,
                    SubsectorTVItemID.ToString() + ", " +
                    AnalysisName));

            return mwqmAnalysisReportParameterModel;
        }
        public MWQMAnalysisReportParameterModel GetMWQMAnalysisReportParameterModelWithMWQMAnalysisReportParameterIDDB(int MWQMAnalysisReportParameterID)
        {
            MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModel = (from c in db.MWQMAnalysisReportParameters
                                                                                 let ExcelTVFileTVText = (from cl in db.TVItemLanguages where c.ExcelTVFileTVItemID == cl.TVItemID select cl.TVText).FirstOrDefault()
                                                                                 where c.MWQMAnalysisReportParameterID == MWQMAnalysisReportParameterID
                                                                                 select new MWQMAnalysisReportParameterModel
                                                                                 {
                                                                                     Error = "",
                                                                                     MWQMAnalysisReportParameterID = c.MWQMAnalysisReportParameterID,
                                                                                     SubsectorTVItemID = c.SubsectorTVItemID,
                                                                                     AnalysisName = c.AnalysisName,
                                                                                     AnalysisReportYear = c.AnalysisReportYear,
                                                                                     StartDate = c.StartDate,
                                                                                     EndDate = c.EndDate,
                                                                                     AnalysisCalculationType = (AnalysisCalculationTypeEnum)c.AnalysisCalculationType,
                                                                                     NumberOfRuns = c.NumberOfRuns,
                                                                                     FullYear = c.FullYear,
                                                                                     SalinityHighlightDeviationFromAverage = (float)c.SalinityHighlightDeviationFromAverage,
                                                                                     ShortRangeNumberOfDays = c.ShortRangeNumberOfDays,
                                                                                     MidRangeNumberOfDays = c.MidRangeNumberOfDays,
                                                                                     DryLimit24h = c.DryLimit24h,
                                                                                     DryLimit48h = c.DryLimit48h,
                                                                                     DryLimit72h = c.DryLimit72h,
                                                                                     DryLimit96h = c.DryLimit96h,
                                                                                     WetLimit24h = c.WetLimit24h,
                                                                                     WetLimit48h = c.WetLimit48h,
                                                                                     WetLimit72h = c.WetLimit72h,
                                                                                     WetLimit96h = c.WetLimit96h,
                                                                                     RunsToOmit = c.RunsToOmit,
                                                                                     ShowDataTypes = c.ShowDataTypes,
                                                                                     ExcelTVFileTVItemID = c.ExcelTVFileTVItemID,
                                                                                     ExcelTVFileTVText = ExcelTVFileTVText,
                                                                                     Command = (AnalysisReportExportCommandEnum)c.Command,
                                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                 }).FirstOrDefault<MWQMAnalysisReportParameterModel>();

            if (mwqmAnalysisReportParameterModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMAnalysisReportParameter, ServiceRes.MWQMAnalysisReportParameterID, MWQMAnalysisReportParameterID));

            return mwqmAnalysisReportParameterModel;
        }
        public MWQMAnalysisReportParameterModel GetMWQMAnalysisReportParameterModelExistDB(MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModel)
        {
            MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModelRet = (from c in db.MWQMAnalysisReportParameters
                                                                                    let ExcelTVFileTVText = (from cl in db.TVItemLanguages where c.ExcelTVFileTVItemID == cl.TVItemID select cl.TVText).FirstOrDefault()
                                                                                    where c.SubsectorTVItemID == mwqmAnalysisReportParameterModel.SubsectorTVItemID
                                                                                    && c.AnalysisReportYear == mwqmAnalysisReportParameterModel.AnalysisReportYear
                                                                                    && c.StartDate == mwqmAnalysisReportParameterModel.StartDate
                                                                                    && c.EndDate == mwqmAnalysisReportParameterModel.EndDate
                                                                                    && c.AnalysisCalculationType == (int)mwqmAnalysisReportParameterModel.AnalysisCalculationType
                                                                                    && c.NumberOfRuns == mwqmAnalysisReportParameterModel.NumberOfRuns
                                                                                    && c.FullYear == mwqmAnalysisReportParameterModel.FullYear
                                                                                    && c.SalinityHighlightDeviationFromAverage == mwqmAnalysisReportParameterModel.SalinityHighlightDeviationFromAverage
                                                                                    && c.ShortRangeNumberOfDays == mwqmAnalysisReportParameterModel.ShortRangeNumberOfDays
                                                                                    && c.MidRangeNumberOfDays == mwqmAnalysisReportParameterModel.MidRangeNumberOfDays
                                                                                    && c.DryLimit24h == mwqmAnalysisReportParameterModel.DryLimit24h
                                                                                    && c.DryLimit48h == mwqmAnalysisReportParameterModel.DryLimit48h
                                                                                    && c.DryLimit72h == mwqmAnalysisReportParameterModel.DryLimit72h
                                                                                    && c.DryLimit96h == mwqmAnalysisReportParameterModel.DryLimit96h
                                                                                    && c.WetLimit24h == mwqmAnalysisReportParameterModel.WetLimit24h
                                                                                    && c.WetLimit48h == mwqmAnalysisReportParameterModel.WetLimit48h
                                                                                    && c.WetLimit72h == mwqmAnalysisReportParameterModel.WetLimit72h
                                                                                    && c.WetLimit96h == mwqmAnalysisReportParameterModel.WetLimit96h
                                                                                    && c.RunsToOmit == mwqmAnalysisReportParameterModel.RunsToOmit
                                                                                    && c.ShowDataTypes == mwqmAnalysisReportParameterModel.ShowDataTypes
                                                                                    && c.Command == (int)mwqmAnalysisReportParameterModel.Command
                                                                                    select new MWQMAnalysisReportParameterModel
                                                                                    {
                                                                                        Error = "",
                                                                                        MWQMAnalysisReportParameterID = c.MWQMAnalysisReportParameterID,
                                                                                        SubsectorTVItemID = c.SubsectorTVItemID,
                                                                                        AnalysisName = c.AnalysisName,
                                                                                        AnalysisReportYear = c.AnalysisReportYear,
                                                                                        StartDate = c.StartDate,
                                                                                        EndDate = c.EndDate,
                                                                                        AnalysisCalculationType = (AnalysisCalculationTypeEnum)c.AnalysisCalculationType,
                                                                                        NumberOfRuns = c.NumberOfRuns,
                                                                                        FullYear = c.FullYear,
                                                                                        SalinityHighlightDeviationFromAverage = (float)c.SalinityHighlightDeviationFromAverage,
                                                                                        ShortRangeNumberOfDays = c.ShortRangeNumberOfDays,
                                                                                        MidRangeNumberOfDays = c.MidRangeNumberOfDays,
                                                                                        DryLimit24h = c.DryLimit24h,
                                                                                        DryLimit48h = c.DryLimit48h,
                                                                                        DryLimit72h = c.DryLimit72h,
                                                                                        DryLimit96h = c.DryLimit96h,
                                                                                        WetLimit24h = c.WetLimit24h,
                                                                                        WetLimit48h = c.WetLimit48h,
                                                                                        WetLimit72h = c.WetLimit72h,
                                                                                        WetLimit96h = c.WetLimit96h,
                                                                                        RunsToOmit = c.RunsToOmit,
                                                                                        ShowDataTypes = c.ShowDataTypes,
                                                                                        ExcelTVFileTVItemID = c.ExcelTVFileTVItemID,
                                                                                        ExcelTVFileTVText = ExcelTVFileTVText,
                                                                                        Command = (AnalysisReportExportCommandEnum)c.Command,
                                                                                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                    }).FirstOrDefault<MWQMAnalysisReportParameterModel>();

            if (mwqmAnalysisReportParameterModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMAnalysisReportParameter,
                    ServiceRes.SubsectorTVItemID + ", " +
                    ServiceRes.AnalysisReportYear + ", " +
                    ServiceRes.StartDate + ", " +
                    ServiceRes.EndDate + ", " +
                    ServiceRes.AnalysisCalculationType + ", " +
                    ServiceRes.NumberOfRuns + ", " +
                    ServiceRes.FullYear + ", " +
                    ServiceRes.SalinityHighlightDeviationFromAverage + ", " +
                    ServiceRes.ShortRangeNumberOfDays + ", " +
                    ServiceRes.MidRangeNumberOfDays + ", " +
                    ServiceRes.DryLimit24h + ", " +
                    ServiceRes.DryLimit48h + ", " +
                    ServiceRes.DryLimit72h + ", " +
                    ServiceRes.DryLimit96h + ", " +
                    ServiceRes.WetLimit24h + ", " +
                    ServiceRes.WetLimit48h + ", " +
                    ServiceRes.WetLimit72h + ", " +
                    ServiceRes.WetLimit96h + ", " +
                    ServiceRes.RunsToOmit + ", " +
                    ServiceRes.ShowDataTypes,
                    mwqmAnalysisReportParameterModel.SubsectorTVItemID + ", " +
                    mwqmAnalysisReportParameterModel.AnalysisReportYear + ", " +
                    mwqmAnalysisReportParameterModel.StartDate + ", " +
                    mwqmAnalysisReportParameterModel.EndDate + ", " +
                    mwqmAnalysisReportParameterModel.AnalysisCalculationType + ", " +
                    mwqmAnalysisReportParameterModel.NumberOfRuns + ", " +
                    mwqmAnalysisReportParameterModel.FullYear + ", " +
                    mwqmAnalysisReportParameterModel.SalinityHighlightDeviationFromAverage + ", " +
                    mwqmAnalysisReportParameterModel.ShortRangeNumberOfDays + ", " +
                    mwqmAnalysisReportParameterModel.MidRangeNumberOfDays + ", " +
                    mwqmAnalysisReportParameterModel.DryLimit24h + ", " +
                    mwqmAnalysisReportParameterModel.DryLimit48h + ", " +
                    mwqmAnalysisReportParameterModel.DryLimit72h + ", " +
                    mwqmAnalysisReportParameterModel.DryLimit96h + ", " +
                    mwqmAnalysisReportParameterModel.WetLimit24h + ", " +
                    mwqmAnalysisReportParameterModel.WetLimit48h + ", " +
                    mwqmAnalysisReportParameterModel.WetLimit72h + ", " +
                    mwqmAnalysisReportParameterModel.WetLimit96h + ", " +
                    mwqmAnalysisReportParameterModel.RunsToOmit + ", " +
                    mwqmAnalysisReportParameterModel.ShowDataTypes));

            return mwqmAnalysisReportParameterModelRet;
        }
        public MWQMAnalysisReportParameter GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterIDDB(int MWQMAnalysisReportParameterID)
        {
            MWQMAnalysisReportParameter mwqmAnalysisReportParameter = (from c in db.MWQMAnalysisReportParameters
                                                                       where c.MWQMAnalysisReportParameterID == MWQMAnalysisReportParameterID
                                                                       select c).FirstOrDefault<MWQMAnalysisReportParameter>();

            return mwqmAnalysisReportParameter;
        }

        // Helper
        public MWQMAnalysisReportParameterModel ReturnError(string Error)
        {
            return new MWQMAnalysisReportParameterModel() { Error = Error };
        }

        // Post
        public MWQMAnalysisReportParameterModel PostAddFormMWQMAnalysisReportParameterDB(FormCollection fc)
        {
            int TempInt = 0;
            int SubsectorTVItemID = 0;
            string AnalysisName = "";
            int AnalysisReportYear = 0;
            DateTime StartDate = new DateTime(1900, 1, 1);
            DateTime EndDate = new DateTime(1900, 1, 1);
            AnalysisCalculationTypeEnum AnalysisCalculationType = AnalysisCalculationTypeEnum.Error;
            int NumberOfRuns = 0;
            bool FullYear = false;
            float SalinityHighlightDeviationFromAverage = 0.0f;
            int ShortRangeNumberOfDays = 0;
            int MidRangeNumberOfDays = 0;
            int DryLimit24h = 0;
            int DryLimit48h = 0;
            int DryLimit72h = 0;
            int DryLimit96h = 0;
            int WetLimit24h = 0;
            int WetLimit48h = 0;
            int WetLimit72h = 0;
            int WetLimit96h = 0;
            string RunsToOmit = "";
            string ShowDataTypes = "";
            AnalysisReportExportCommandEnum Command = AnalysisReportExportCommandEnum.Error;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int.TryParse(fc["SubsectorTVItemID"], out SubsectorTVItemID);
            if (SubsectorTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID));

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return ReturnError(tvItemModel.Error);

            AnalysisName = fc["AnalysisName"];
            if (string.IsNullOrWhiteSpace(AnalysisName))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AnalysisName));

            MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModelRet = GetMWQMAnalysisReportParameterModelWithSubsectorTVItemIDAndAnalysisNameDB(SubsectorTVItemID, AnalysisName);
            if (string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterModelRet.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, AnalysisName));

            int.TryParse(fc["Command"], out TempInt);
            if (TempInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Command));

            Command = (AnalysisReportExportCommandEnum)TempInt;

            if (Command == AnalysisReportExportCommandEnum.Report)
            {
                int.TryParse(fc["AnalysisReportYear"], out AnalysisReportYear);
                if (AnalysisReportYear == 0)
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AnalysisReportYear));
            }

            string StartDateText = fc["StartDate"];
            if (string.IsNullOrWhiteSpace(StartDateText))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StartDate));

            if (StartDateText.Length != 10)
                return ReturnError(string.Format(ServiceRes._FormatShouldBeSomethingLike_ItIs_, ServiceRes.StartDate, "2017-05-23", StartDateText));

            StartDate = new DateTime(int.Parse(StartDateText.Substring(0, 4)), int.Parse(StartDateText.Substring(5, 2)), int.Parse(StartDateText.Substring(8, 2)));

            string EndDateText = fc["EndDate"];
            if (string.IsNullOrWhiteSpace(EndDateText))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EndDate));

            if (EndDateText.Length != 10)
                return ReturnError(string.Format(ServiceRes._FormatShouldBeSomethingLike_ItIs_, ServiceRes.EndDate, "2000-05-23", EndDateText));

            EndDate = new DateTime(int.Parse(EndDateText.Substring(0, 4)), int.Parse(EndDateText.Substring(5, 2)), int.Parse(EndDateText.Substring(8, 2)));

            string AnalysisCalculationTypeText = fc["AnalysisCalculationType"];
            if (string.IsNullOrWhiteSpace(AnalysisCalculationTypeText))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AnalysisCalculationType));

            switch (AnalysisCalculationTypeText)
            {
                case "All_All_All":
                    {
                        AnalysisCalculationType = AnalysisCalculationTypeEnum.AllAllAll;
                    }
                    break;
                case "Wet_All_All":
                    {
                        AnalysisCalculationType = AnalysisCalculationTypeEnum.WetAllAll;
                    }
                    break;
                case "Dry_All_All":
                    {
                        AnalysisCalculationType = AnalysisCalculationTypeEnum.DryAllAll;
                    }
                    break;
                case "Wet_Wet_All":
                    {
                        AnalysisCalculationType = AnalysisCalculationTypeEnum.WetWetAll;
                    }
                    break;
                case "Dry_Dry_All":
                    {
                        AnalysisCalculationType = AnalysisCalculationTypeEnum.DryDryAll;
                    }
                    break;
                case "Wet_Dry_All":
                    {
                        AnalysisCalculationType = AnalysisCalculationTypeEnum.WetDryAll;
                    }
                    break;
                case "Dry_Wet_All":
                    {
                        AnalysisCalculationType = AnalysisCalculationTypeEnum.DryWetAll;
                    }
                    break;
                default:
                    break;
            }

            int.TryParse(fc["NumberOfRuns"], out NumberOfRuns);
            if (NumberOfRuns == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.NumberOfRuns));


            if (!string.IsNullOrWhiteSpace(fc["FullYear"]))
            {
                bool.TryParse(fc["FullYear"], out FullYear);
            }

            float.TryParse(fc["SalinityHighlightDeviationFromAverage"], out SalinityHighlightDeviationFromAverage);
            if (SalinityHighlightDeviationFromAverage == 0.0f)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SalinityHighlightDeviationFromAverage));

            int.TryParse(fc["ShortRangeNumberOfDays"], out ShortRangeNumberOfDays);
            if (ShortRangeNumberOfDays == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ShortRangeNumberOfDays));

            int.TryParse(fc["MidRangeNumberOfDays"], out MidRangeNumberOfDays);
            if (MidRangeNumberOfDays == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MidRangeNumberOfDays));

            int.TryParse(fc["DryLimit24h"], out DryLimit24h);
            if (DryLimit24h == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.DryLimit24h));

            int.TryParse(fc["DryLimit48h"], out DryLimit48h);
            if (DryLimit48h == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.DryLimit48h));

            int.TryParse(fc["DryLimit72h"], out DryLimit72h);
            if (DryLimit72h == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.DryLimit72h));

            int.TryParse(fc["DryLimit96h"], out DryLimit96h);
            if (DryLimit96h == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.DryLimit96h));

            int.TryParse(fc["WetLimit24h"], out WetLimit24h);
            if (WetLimit24h == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.WetLimit24h));

            int.TryParse(fc["WetLimit48h"], out WetLimit48h);
            if (WetLimit48h == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.WetLimit48h));

            int.TryParse(fc["WetLimit72h"], out WetLimit72h);
            if (WetLimit72h == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.WetLimit72h));

            int.TryParse(fc["WetLimit96h"], out WetLimit96h);
            if (WetLimit96h == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.WetLimit96h));

            RunsToOmit = fc["RunsToOmit"];
            if (string.IsNullOrWhiteSpace(RunsToOmit))
            {
                RunsToOmit = ",";
            }

            ShowDataTypes = fc["ShowDataTypes"];
            if (string.IsNullOrWhiteSpace(ShowDataTypes))
            {
                ShowDataTypes = ",";
            }

            MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModelNew = new MWQMAnalysisReportParameterModel();
            mwqmAnalysisReportParameterModelNew.SubsectorTVItemID = SubsectorTVItemID;
            mwqmAnalysisReportParameterModelNew.AnalysisName = AnalysisName;
            mwqmAnalysisReportParameterModelNew.AnalysisReportYear = null;
            if (Command == AnalysisReportExportCommandEnum.Report)
            {
                mwqmAnalysisReportParameterModelNew.AnalysisReportYear = AnalysisReportYear;
            }
            mwqmAnalysisReportParameterModelNew.StartDate = StartDate;
            mwqmAnalysisReportParameterModelNew.EndDate = EndDate;
            mwqmAnalysisReportParameterModelNew.AnalysisCalculationType = AnalysisCalculationType;
            mwqmAnalysisReportParameterModelNew.NumberOfRuns = NumberOfRuns;
            mwqmAnalysisReportParameterModelNew.FullYear = FullYear;
            mwqmAnalysisReportParameterModelNew.SalinityHighlightDeviationFromAverage = SalinityHighlightDeviationFromAverage;
            mwqmAnalysisReportParameterModelNew.ShortRangeNumberOfDays = ShortRangeNumberOfDays;
            mwqmAnalysisReportParameterModelNew.MidRangeNumberOfDays = MidRangeNumberOfDays;
            mwqmAnalysisReportParameterModelNew.DryLimit24h = DryLimit24h;
            mwqmAnalysisReportParameterModelNew.DryLimit48h = DryLimit48h;
            mwqmAnalysisReportParameterModelNew.DryLimit72h = DryLimit72h;
            mwqmAnalysisReportParameterModelNew.DryLimit96h = DryLimit96h;
            mwqmAnalysisReportParameterModelNew.WetLimit24h = WetLimit24h;
            mwqmAnalysisReportParameterModelNew.WetLimit48h = WetLimit48h;
            mwqmAnalysisReportParameterModelNew.WetLimit72h = WetLimit72h;
            mwqmAnalysisReportParameterModelNew.WetLimit96h = WetLimit96h;
            mwqmAnalysisReportParameterModelNew.RunsToOmit = RunsToOmit;
            mwqmAnalysisReportParameterModelNew.ShowDataTypes = ShowDataTypes;
            mwqmAnalysisReportParameterModelNew.ExcelTVFileTVItemID = null;
            mwqmAnalysisReportParameterModelNew.Command = Command;

            MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModelRet2 = new MWQMAnalysisReportParameterModel();
            using (TransactionScope ts = new TransactionScope())
            {
                mwqmAnalysisReportParameterModelRet2 = PostAddMWQMAnalysisReportParameterDB(mwqmAnalysisReportParameterModelNew);
                if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterModelRet2.Error))
                    return ReturnError(mwqmAnalysisReportParameterModelRet2.Error);

                ts.Complete();
            }

            if (Command == AnalysisReportExportCommandEnum.Report)
            {
                // done on the previous transaction
            }
            else if (Command == AnalysisReportExportCommandEnum.Excel)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(SubsectorTVItemID, SubsectorTVItemID, AppTaskCommandEnum.ExportAnalysisToExcel);
                    if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                        return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask));

                    List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
                    appTaskParameterList.Add(new AppTaskParameter() { Name = "SubsectorTVItemID", Value = SubsectorTVItemID.ToString() });
                    appTaskParameterList.Add(new AppTaskParameter() { Name = "MWQMAnalysisReportParameterID", Value = mwqmAnalysisReportParameterModelRet2.MWQMAnalysisReportParameterID.ToString() });

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
                        AppTaskCommand = AppTaskCommandEnum.ExportAnalysisToExcel,
                        ErrorText = "",
                        StatusText = ServiceRes.ExportAnalysisToExcel,
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
                        return ReturnError(appTaskModelRet.Error);

                    ts.Complete();
                }

                return ReturnError("");
            }
            else
            {
                return ReturnError(string.Format(ServiceRes.Command_NotRecognized, Command.ToString()));
            }

            return mwqmAnalysisReportParameterModelRet2;
        }
        public MWQMAnalysisReportParameterModel PostAddMWQMAnalysisReportParameterDB(MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModel)
        {
            string retStr = MWQMAnalysisReportParameterModelOK(mwqmAnalysisReportParameterModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModelExist = GetMWQMAnalysisReportParameterModelExistDB(mwqmAnalysisReportParameterModel);
            if (string.IsNullOrWhiteSpace(mwqmAnalysisReportParameterModelExist.Error))
            {
                if (mwqmAnalysisReportParameterModelExist.Command == AnalysisReportExportCommandEnum.Report)
                {
                    return ReturnError(string.Format(ServiceRes._AlreadyExists, "") + ". " + ServiceRes.See +  " - [" + mwqmAnalysisReportParameterModelExist.AnalysisReportYear + "] - " + mwqmAnalysisReportParameterModelExist.AnalysisName);
                }
                else
                {
                    return ReturnError(string.Format(ServiceRes._AlreadyExists, "") + ". " + ServiceRes.See + " - [Excel] - " + mwqmAnalysisReportParameterModelExist.AnalysisName);
                }
            }

            MWQMAnalysisReportParameter mwqmAnalysisReportParameterNew = new MWQMAnalysisReportParameter();
            retStr = FillMWQMAnalysisReportParameter(mwqmAnalysisReportParameterNew, mwqmAnalysisReportParameterModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMAnalysisReportParameters.Add(mwqmAnalysisReportParameterNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMAnalysisReportParameters", mwqmAnalysisReportParameterNew.MWQMAnalysisReportParameterID, LogCommandEnum.Add, mwqmAnalysisReportParameterNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMAnalysisReportParameterModelWithMWQMAnalysisReportParameterIDDB(mwqmAnalysisReportParameterNew.MWQMAnalysisReportParameterID);
        }
        public MWQMAnalysisReportParameterModel PostDeleteMWQMAnalysisReportParameterDB(int MWQMAnalysisReportParameterID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMAnalysisReportParameter MWQMAnalysisReportParameterToDelete = GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterIDDB(MWQMAnalysisReportParameterID);
            if (MWQMAnalysisReportParameterToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMAnalysisReportParameter));

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMAnalysisReportParameters.Remove(MWQMAnalysisReportParameterToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMAnalysisReportParameters", MWQMAnalysisReportParameterToDelete.MWQMAnalysisReportParameterID, LogCommandEnum.Delete, MWQMAnalysisReportParameterToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public MWQMAnalysisReportParameterModel PostUpdateMWQMAnalysisReportParameterDB(MWQMAnalysisReportParameterModel mwqmAnalysisReportParameterModel)
        {
            string retStr = MWQMAnalysisReportParameterModelOK(mwqmAnalysisReportParameterModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMAnalysisReportParameter mwqmAnalysisReportParameterToUpdate = GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterIDDB(mwqmAnalysisReportParameterModel.MWQMAnalysisReportParameterID);
            if (mwqmAnalysisReportParameterToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMAnalysisReportParameter));

            retStr = FillMWQMAnalysisReportParameter(mwqmAnalysisReportParameterToUpdate, mwqmAnalysisReportParameterModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMAnalysisReportParameters", mwqmAnalysisReportParameterToUpdate.MWQMAnalysisReportParameterID, LogCommandEnum.Change, mwqmAnalysisReportParameterToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMAnalysisReportParameterModelWithMWQMAnalysisReportParameterIDDB(mwqmAnalysisReportParameterToUpdate.MWQMAnalysisReportParameterID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
