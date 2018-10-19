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
using System.Threading;
using System.Globalization;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPDBDLL.Services
{
    public class OpenDataService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public AppTaskService _AppTaskService { get; private set; }
        #endregion Properties

        #region Constructors
        public OpenDataService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _AppTaskService = new AppTaskService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions public
        public override ContactOK IsContactOK()
        {
            return base.IsContactOK();
        }
        public TVItemModel ReturnError(string Error)
        {
            return new TVItemModel() { Error = Error };
        }
        public TVItemModel GenerateCSVDocumentOfMWQMSitesDB(int ProvinceTVItemID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.OpenDataCSVOfMWQMSites);
                if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                    return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask));

                List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();

                AppTaskModel appTaskModelNew = new AppTaskModel()
                {
                    TVItemID = ProvinceTVItemID,
                    TVItemID2 = ProvinceTVItemID,
                    AppTaskCommand = AppTaskCommandEnum.OpenDataCSVOfMWQMSites,
                    ErrorText = "",
                    StatusText = ServiceRes.GeneratingDocument + " " + _BaseEnumService.GetEnumText_AppTaskCommandEnum(AppTaskCommandEnum.OpenDataCSVOfMWQMSites),
                    AppTaskStatus = AppTaskStatusEnum.Created,
                    PercentCompleted = 1,
                    Parameters = "No Parameters",
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
        public TVItemModel GenerateCSVDocumentNationalOfMWQMSitesDB(int CountryTVItemID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(CountryTVItemID, CountryTVItemID, AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSites);
                if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                    return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask));

                List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();

                AppTaskModel appTaskModelNew = new AppTaskModel()
                {
                    TVItemID = CountryTVItemID,
                    TVItemID2 = CountryTVItemID,
                    AppTaskCommand = AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSites,
                    ErrorText = "",
                    StatusText = ServiceRes.GeneratingDocument + " " + _BaseEnumService.GetEnumText_AppTaskCommandEnum(AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSites),
                    AppTaskStatus = AppTaskStatusEnum.Created,
                    PercentCompleted = 1,
                    Parameters = "No Parameters",
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
        public TVItemModel GenerateCSVDocumentOfMWQMSamplesDB(int ProvinceTVItemID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.OpenDataCSVOfMWQMSamples);
                if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                    return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask));

                List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();

                AppTaskModel appTaskModelNew = new AppTaskModel()
                {
                    TVItemID = ProvinceTVItemID,
                    TVItemID2 = ProvinceTVItemID,
                    AppTaskCommand = AppTaskCommandEnum.OpenDataCSVOfMWQMSamples,
                    ErrorText = "",
                    StatusText = ServiceRes.GeneratingDocument + " " + _BaseEnumService.GetEnumText_AppTaskCommandEnum(AppTaskCommandEnum.OpenDataCSVOfMWQMSamples),
                    AppTaskStatus = AppTaskStatusEnum.Created,
                    PercentCompleted = 1,
                    Parameters = "No Parameters",
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
        public TVItemModel GenerateCSVDocumentNationalOfMWQMSamplesDB(int CountryTVItemID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(CountryTVItemID, CountryTVItemID, AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSamples);
                if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                    return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask));

                List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();

                AppTaskModel appTaskModelNew = new AppTaskModel()
                {
                    TVItemID = CountryTVItemID,
                    TVItemID2 = CountryTVItemID,
                    AppTaskCommand = AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSamples,
                    ErrorText = "",
                    StatusText = ServiceRes.GeneratingDocument + " " + _BaseEnumService.GetEnumText_AppTaskCommandEnum(AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSamples),
                    AppTaskStatus = AppTaskStatusEnum.Created,
                    PercentCompleted = 1,
                    Parameters = "No Parameters",
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
        public TVItemModel GenerateKMZDocumentOfMWQMSitesDB(int ProvinceTVItemID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.OpenDataKMZOfMWQMSites);
                if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                    return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask));

                List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();

                AppTaskModel appTaskModelNew = new AppTaskModel()
                {
                    TVItemID = ProvinceTVItemID,
                    TVItemID2 = ProvinceTVItemID,
                    AppTaskCommand = AppTaskCommandEnum.OpenDataKMZOfMWQMSites,
                    ErrorText = "",
                    StatusText = ServiceRes.GeneratingDocument + " " + _BaseEnumService.GetEnumText_AppTaskCommandEnum(AppTaskCommandEnum.OpenDataKMZOfMWQMSites),
                    AppTaskStatus = AppTaskStatusEnum.Created,
                    PercentCompleted = 1,
                    Parameters = "No Parameters",
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
        public TVItemModel GenerateXlsxDocumentOfMWQMSitesAndSamplesDB(int ProvinceTVItemID)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.OpenDataXlsxOfMWQMSitesAndSamples);
                if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                    return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask));

                List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();

                AppTaskModel appTaskModelNew = new AppTaskModel()
                {
                    TVItemID = ProvinceTVItemID,
                    TVItemID2 = ProvinceTVItemID,
                    AppTaskCommand = AppTaskCommandEnum.OpenDataXlsxOfMWQMSitesAndSamples,
                    ErrorText = "",
                    StatusText = ServiceRes.GeneratingDocument + " " + _BaseEnumService.GetEnumText_AppTaskCommandEnum(AppTaskCommandEnum.OpenDataXlsxOfMWQMSitesAndSamples),
                    AppTaskStatus = AppTaskStatusEnum.Created,
                    PercentCompleted = 1,
                    Parameters = "No Parameters",
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
        public OpenDataStat GetOpenDataStatDB(int TVItemID)
        {
            string routineTxt = ((int)SampleTypeEnum.Routine).ToString() + ",";

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return new OpenDataStat() { Error = tvItemModel.Error };

            using (CSSPDBEntities dd = new CSSPDBEntities())
            {
                OpenDataStat openDataStat = (from c in dd.TVItems
                                             let samples = (from d in dd.TVItems
                                                            from s in dd.MWQMSamples
                                                            where d.TVItemID == s.MWQMSiteTVItemID
                                                            && d.TVPath.StartsWith(c.TVPath)
                                                            && d.TVType == (int)TVTypeEnum.MWQMSite
                                                            && s.SampleTypesText.Contains(routineTxt)
                                                            select new { s.UseForOpenData })
                                             let totalSampleCount = (from s in samples select s).Count()
                                             let useForOpenDataSampleCount = (from s in samples
                                                                              where s.UseForOpenData == true
                                                                              select s).Count()
                                             where c.TVItemID == TVItemID
                                             select new OpenDataStat
                                             {
                                                 Error = "",
                                                 TotalNumberOfSamples = totalSampleCount,
                                                 NumberOfUseForOpenDataSamples = useForOpenDataSampleCount,
                                             }).FirstOrDefault<OpenDataStat>();

                return openDataStat;
            }
        }
        public TVItemModel MarkAllRoutineSamplesForOpenDataDB(FormCollection fc)
        {
            int TVItemID = 0;
            int StartYear = 0;
            int StartMonth = 0;
            int StartDay = 0;
            int EndYear = 0;
            int EndMonth = 0;
            int EndDay = 0;
            bool UseForOpenData = false;

            int.TryParse(fc["TVItemID"], out TVItemID);
            if (TVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID));

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return ReturnError(tvItemModel.Error);

            // Start Date
            int.TryParse(fc["StartYear"], out StartYear);
            if (StartYear == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StartYear));

            int.TryParse(fc["StartMonth"], out StartMonth);
            if (StartMonth == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StartMonth));

            int.TryParse(fc["StartDay"], out StartDay);
            if (StartDay == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StartDay));

            DateTime StartDate = new DateTime(StartYear, StartMonth, StartDay);

            // End Date
            int.TryParse(fc["EndYear"], out EndYear);
            if (EndYear == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EndYear));

            int.TryParse(fc["EndMonth"], out EndMonth);
            if (EndMonth == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EndMonth));

            int.TryParse(fc["EndDay"], out EndDay);
            if (EndDay == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EndDay));

            DateTime EndDate = new DateTime(EndYear, EndMonth, EndDay);

            if (StartDate >= EndDate)
                return ReturnError(string.Format(ServiceRes.StartDate_NeedsToBeBiggerThanEndDate_, StartDate.ToString(), EndDate.ToString()));

            UseForOpenData = bool.Parse(fc["UseForOpenData"]);

            switch (tvItemModel.TVType)
            {
                case TVTypeEnum.Province:
                    return ToggleUseForOpenDataFlagOfAllSamplesUnderProvinceTVItemIDDB(TVItemID, StartDate, EndDate, UseForOpenData);
                case TVTypeEnum.Subsector:
                    return ToggleUseForOpenDataFlagOfAllSamplesUnderSubsectorTVItemIDDB(TVItemID, StartDate, EndDate, UseForOpenData);
                case TVTypeEnum.MWQMSite:
                    return ToggleUseForOpenDataFlagOfAllSamplesUnderMWQMSiteTVItemIDDB(TVItemID, StartDate, EndDate, UseForOpenData);
                default:
                    return ReturnError(string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, TVItemID.ToString(), "[" + TVTypeEnum.Province + "," + TVTypeEnum.Subsector + "," + TVTypeEnum.MWQMSite + "]"));
            }
        }
        public TVItemModel MarkSamplesWithMWQMSampleIDForOpenDataDB(int MWQMSampleID, bool UseForOpenData)
        {
            using (CSSPDBEntities dd = new CSSPDBEntities())
            {
                MWQMSample mwqmSample = (from s in dd.MWQMSamples
                                         where s.MWQMSampleID == MWQMSampleID
                                         select s).FirstOrDefault();

                if (mwqmSample == null)
                {
                    return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSample, ServiceRes.MWQMSampleID, MWQMSampleID.ToString()));
                }

                mwqmSample.UseForOpenData = UseForOpenData;

                try
                {
                    dd.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ReturnError(string.Format(ServiceRes.CouldNotUpdateError_, ex.Message + " InnerException: " + (ex.InnerException != null ? ex.InnerException.Message : "")));
                }
            }

            return ReturnError("");
        }
        public TVItemModel ToggleUseForOpenDataFlagOfAllSamplesUnderProvinceTVItemIDDB(int ProvinceTVItemID, DateTime StartDate, DateTime EndDate, bool UseForOpenData)
        {
            string RoutineTxt = ((int)SampleTypeEnum.Routine).ToString() + ",";

            TVItem tvItemProv = new TVItem();
            using (CSSPDBEntities dd = new CSSPDBEntities())
            {
                tvItemProv = (from c in dd.TVItems
                              where c.TVItemID == ProvinceTVItemID
                              select c).FirstOrDefault();
            }

            if (tvItemProv == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Province, ServiceRes.ProvinceTVItemID, ProvinceTVItemID.ToString()));
            }

            List<TVItem> tvItemSSList = new List<TVItem>();
            using (CSSPDBEntities dd = new CSSPDBEntities())
            {
                tvItemSSList = (from t in dd.TVItems
                                where t.TVPath.StartsWith(tvItemProv.TVPath + "p")
                                && t.TVType == (int)TVTypeEnum.Subsector
                                select t).ToList();
            }

            foreach (TVItem tvItemSS in tvItemSSList)
            {
                using (CSSPDBEntities dd = new CSSPDBEntities())
                {
                    List<MWQMSample> mwqmSampleList = (from t in dd.TVItems
                                                       from s in dd.MWQMSamples
                                                       where t.TVItemID == s.MWQMSiteTVItemID
                                                       && t.TVPath.StartsWith(tvItemSS.TVPath + "p")
                                                       && t.TVType == (int)TVTypeEnum.MWQMSite
                                                       && s.SampleTypesText.Contains(RoutineTxt)
                                                       && s.UseForOpenData == !UseForOpenData
                                                       && s.SampleDateTime_Local >= StartDate
                                                       && s.SampleDateTime_Local <= EndDate
                                                       select s).ToList();

                    foreach (MWQMSample mwqmSample in mwqmSampleList)
                    {
                        mwqmSample.UseForOpenData = UseForOpenData;
                    }

                    try
                    {
                        dd.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return ReturnError(string.Format(ServiceRes.CouldNotUpdateError_, ex.Message + " InnerException: " + (ex.InnerException != null ? ex.InnerException.Message : "")));
                    }
                }

            }

            return ReturnError("");
        }
        public TVItemModel ToggleUseForOpenDataFlagOfAllSamplesUnderSubsectorTVItemIDDB(int SubsectorTVItemID, DateTime StartDate, DateTime EndDate, bool UseForOpenData)
        {
            string RoutineTxt = ((int)SampleTypeEnum.Routine).ToString() + ",";

            TVItem tvItemSS = new TVItem();
            using (CSSPDBEntities dd = new CSSPDBEntities())
            {
                tvItemSS = (from c in dd.TVItems
                            where c.TVItemID == SubsectorTVItemID
                            select c).FirstOrDefault();
            }

            if (tvItemSS == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Subsector, ServiceRes.SubsectorTVItemID, SubsectorTVItemID.ToString()));
            }

            using (CSSPDBEntities dd = new CSSPDBEntities())
            {
                List<MWQMSample> mwqmSampleList = (from t in dd.TVItems
                                                   from s in dd.MWQMSamples
                                                   where t.TVItemID == s.MWQMSiteTVItemID
                                                   && t.TVPath.StartsWith(tvItemSS.TVPath + "p")
                                                   && t.TVType == (int)TVTypeEnum.MWQMSite
                                                   && s.SampleTypesText.Contains(RoutineTxt)
                                                   && s.UseForOpenData == !UseForOpenData
                                                   && s.SampleDateTime_Local >= StartDate
                                                   && s.SampleDateTime_Local <= EndDate
                                                   select s).ToList();

                foreach (MWQMSample mwqmSample in mwqmSampleList)
                {
                    mwqmSample.UseForOpenData = UseForOpenData;
                }

                try
                {
                    dd.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ReturnError(string.Format(ServiceRes.CouldNotUpdateError_, ex.Message + " InnerException: " + (ex.InnerException != null ? ex.InnerException.Message : "")));
                }
            }

            return ReturnError("");
        }
        public TVItemModel ToggleUseForOpenDataFlagOfAllSamplesUnderMWQMSiteTVItemIDDB(int MWQMSiteTVItemID, DateTime StartDate, DateTime EndDate, bool UseForOpenData)
        {
            string RoutineTxt = ((int)SampleTypeEnum.Routine).ToString() + ",";

            TVItem tvItemSite = new TVItem();
            using (CSSPDBEntities dd = new CSSPDBEntities())
            {
                tvItemSite = (from c in dd.TVItems
                              where c.TVItemID == MWQMSiteTVItemID
                              select c).FirstOrDefault();
            }

            if (tvItemSite == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSite, ServiceRes.MWQMSiteTVItemID, MWQMSiteTVItemID.ToString()));
            }

            using (CSSPDBEntities dd = new CSSPDBEntities())
            {
                List<MWQMSample> mwqmSampleList = (from t in dd.TVItems
                                                   from s in dd.MWQMSamples
                                                   where t.TVItemID == s.MWQMSiteTVItemID
                                                   && t.TVItemID == MWQMSiteTVItemID
                                                   && t.TVType == (int)TVTypeEnum.MWQMSite
                                                   && s.SampleTypesText.Contains(RoutineTxt)
                                                   && s.UseForOpenData == !UseForOpenData
                                                   && s.SampleDateTime_Local >= StartDate
                                                   && s.SampleDateTime_Local <= EndDate
                                                   select s).ToList();

                foreach (MWQMSample mwqmSample in mwqmSampleList)
                {
                    mwqmSample.UseForOpenData = UseForOpenData;
                }

                try
                {
                    dd.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ReturnError(string.Format(ServiceRes.CouldNotUpdateError_, ex.Message + " InnerException: " + (ex.InnerException != null ? ex.InnerException.Message : "")));
                }
            }

            return ReturnError("");
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}