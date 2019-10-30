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
    public class RainExceedanceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public RainExceedanceClimateSiteService _RainExceedanceClimateSiteService { get; private set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _RainExceedanceClimateSiteService = new RainExceedanceClimateSiteService(LanguageRequest, User);
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
        public string RainExceedanceModelOK(RainExceedanceModel rainExceedanceModel)
        {
            string retStr = FieldCheckNotZeroInt(rainExceedanceModel.RainExceedanceTVItemID, ServiceRes.RainExceedanceTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (rainExceedanceModel.StartMonth < 1 || rainExceedanceModel.StartMonth > 12)
            {
                return string.Format(ServiceRes.PleaseEnterValidFor_, ServiceRes.StartMonth);
            }

            if (rainExceedanceModel.StartDay < 1 || rainExceedanceModel.StartDay > 31)
            {
                return string.Format(ServiceRes.PleaseEnterValidFor_, ServiceRes.StartDay);
            }

            if (rainExceedanceModel.EndMonth < 1 || rainExceedanceModel.EndMonth > 12)
            {
                return string.Format(ServiceRes.PleaseEnterValidFor_, ServiceRes.EndMonth);
            }

            if (rainExceedanceModel.EndDay < 1 || rainExceedanceModel.EndDay > 31)
            {
                return string.Format(ServiceRes.PleaseEnterValidFor_, ServiceRes.EndDay);
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(rainExceedanceModel.RainMaximum_mm, ServiceRes.RainMaximum, 0.0f, 500.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillRainExceedance(RainExceedance rainExceedanceNew, RainExceedanceModel rainExceedanceModel, ContactOK contactOK)
        {
            rainExceedanceNew.RainExceedanceTVItemID = rainExceedanceModel.RainExceedanceTVItemID;
            rainExceedanceNew.StartMonth = rainExceedanceModel.StartMonth;
            rainExceedanceNew.StartDay = rainExceedanceModel.StartDay;
            rainExceedanceNew.EndMonth = rainExceedanceModel.EndMonth;
            rainExceedanceNew.EndDay = rainExceedanceModel.EndDay;
            rainExceedanceNew.RainMaximum_mm = rainExceedanceModel.RainMaximum_mm;
            rainExceedanceNew.StakeholdersEmailDistributionListID = rainExceedanceModel.StakeholdersEmailDistributionListID;
            rainExceedanceNew.OnlyStaffEmailDistributionListID = rainExceedanceModel.OnlyStaffEmailDistributionListID;
            rainExceedanceNew.IsActive = rainExceedanceModel.IsActive;
            rainExceedanceNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                rainExceedanceNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                rainExceedanceNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public RainExceedanceFullClimateSites GetRainExceedanceFullClimateSitesDB(int RainExceedanceTVItemID, float Radius_km)
        {
            RainExceedanceFullClimateSites rainExceedanceFullClimateSites = new RainExceedanceFullClimateSites();

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(RainExceedanceTVItemID, TVTypeEnum.RainExceedance, MapInfoDrawTypeEnum.Point);
            if (mapInfoPointModelList.Count == 0)
            {
                rainExceedanceFullClimateSites.Error = string.Format(ServiceRes._ShouldNotBeNullOrEmpty, "MapInfoPointModelList with RainExceedanceTVItemID = [" + RainExceedanceTVItemID + "]");
                return rainExceedanceFullClimateSites;
            }

            // Getting RainExceedance
            RainExceedanceModel rainExceedanceModel = GetRainExceedanceModelWithRainExceedanceTVItemIDDB(RainExceedanceTVItemID);
            if (!string.IsNullOrWhiteSpace(rainExceedanceModel.Error))
            {
                rainExceedanceFullClimateSites.Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.RainExceedance, ServiceRes.RainExceedanceTVItemID, RainExceedanceTVItemID);
                return rainExceedanceFullClimateSites;
            }


            List<int> currentlyUsedClimateSiteTVItemIDList = _RainExceedanceClimateSiteService.GetRainExceedanceClimateSiteModelListWithRainExceedanceTVItemIDDB(RainExceedanceTVItemID).Select(c => c.ClimateSiteTVItemID).ToList();

            rainExceedanceFullClimateSites.CurrentlyUsedClimateSiteTVItemIDList = currentlyUsedClimateSiteTVItemIDList;

            List<int> distClimateSiteTVItemIDList = _MapInfoService.GetMapInfoModelWithinCircleWithTVTypeAndMapInfoDrawTypeDB((float)rainExceedanceModel.Lat, (float)rainExceedanceModel.Lng,
                (float)Radius_km, TVTypeEnum.ClimateSite, MapInfoDrawTypeEnum.Point).Select(c => c.TVItemID).Distinct().ToList();

            List<int> ClimateSiteTVItemIDList = currentlyUsedClimateSiteTVItemIDList.Concat(distClimateSiteTVItemIDList).Distinct().ToList();

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


            foreach (ClimateSiteWithLatLngAndOrdinalModel climateSiteWithLatLngAndOrdinalModel in ClimateSiteWithLatLngAndOrdinalModelList)
            {
                climateSiteWithLatLngAndOrdinalModel.Distance_km = (float)(_MapInfoService.CalculateDistance((double)rainExceedanceModel.Lat * d2r, (double)rainExceedanceModel.Lng * d2r, (double)climateSiteWithLatLngAndOrdinalModel.Lat * d2r, (double)climateSiteWithLatLngAndOrdinalModel.Lng * d2r, (double)R) / 1000);
            }


            rainExceedanceFullClimateSites.ClimateSiteModelUsedAndWithinDistanceModelList = ClimateSiteWithLatLngAndOrdinalModelList;

            return rainExceedanceFullClimateSites;
        }
        public int GetRainExceedanceModelCountDB()
        {
            int RainExceedanceModelCount = (from c in db.RainExceedances
                                            select c).Count();

            return RainExceedanceModelCount;
        }
        public List<RainExceedanceModel> GetRainExceedanceModelListDB()
        {
            List<RainExceedanceModel> RainExceedanceModelList = (from c in db.RainExceedances
                                                                 let rainExceedanceName = (from t in db.TVItems
                                                                                           from tl in db.TVItemLanguages
                                                                                           where t.TVItemID == tl.TVItemID
                                                                                           && tl.Language == (int)LanguageRequest
                                                                                           && t.TVItemID == c.RainExceedanceTVItemID
                                                                                           select tl.TVText).FirstOrDefault()
                                                                 let stakeholdersEmailDistributionListName = (from e in db.EmailDistributionLists
                                                                                                              from el in db.EmailDistributionListLanguages
                                                                                                              where e.EmailDistributionListID == el.EmailDistributionListID
                                                                                                              && el.Language == (int)LanguageRequest
                                                                                                              && e.EmailDistributionListID == c.StakeholdersEmailDistributionListID
                                                                                                              select el.EmailListName).FirstOrDefault()
                                                                 let onlyStaffEmailDistributionListName = (from e in db.EmailDistributionLists
                                                                                                           from el in db.EmailDistributionListLanguages
                                                                                                           where e.EmailDistributionListID == el.EmailDistributionListID
                                                                                                           && el.Language == (int)LanguageRequest
                                                                                                           && e.EmailDistributionListID == c.OnlyStaffEmailDistributionListID
                                                                                                           select el.EmailListName).FirstOrDefault()
                                                                 let mapInfoPoint = (from mi in db.MapInfos
                                                                                     from mip in db.MapInfoPoints
                                                                                     where mi.MapInfoID == mip.MapInfoID
                                                                                     && mi.TVItemID == c.RainExceedanceTVItemID
                                                                                     && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                                                                     && mi.TVType == (int)TVTypeEnum.RainExceedance
                                                                                     select mip).FirstOrDefault()
                                                                 select new RainExceedanceModel
                                                                 {
                                                                     Error = "",
                                                                     RainExceedanceID = c.RainExceedanceID,
                                                                     RainExceedanceTVItemID = c.RainExceedanceTVItemID,
                                                                     RainExceedanceName = rainExceedanceName ?? "",
                                                                     StartMonth = c.StartMonth,
                                                                     StartDay = c.StartDay,
                                                                     EndMonth = c.EndMonth,
                                                                     EndDay = c.EndDay,
                                                                     RainMaximum_mm = (float)c.RainMaximum_mm,
                                                                     StakeholdersEmailDistributionListID = c.StakeholdersEmailDistributionListID,
                                                                     StakeholdersEmailDistributionListName = stakeholdersEmailDistributionListName,
                                                                     OnlyStaffEmailDistributionListID = c.OnlyStaffEmailDistributionListID,
                                                                     OnlyStaffEmailDistributionListName = onlyStaffEmailDistributionListName,
                                                                     IsActive = c.IsActive,
                                                                     Lat = mapInfoPoint.Lat,
                                                                     Lng = mapInfoPoint.Lng,
                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                 }).ToList<RainExceedanceModel>();

            return RainExceedanceModelList;
        }
        public RainExceedanceModel GetRainExceedanceModelWithRainExceedanceIDDB(int RainExceedanceID)
        {
            RainExceedanceModel rainExceedanceModel = (from c in db.RainExceedances
                                                       let rainExceedanceName = (from t in db.TVItems
                                                                                 from tl in db.TVItemLanguages
                                                                                 where t.TVItemID == tl.TVItemID
                                                                                 && tl.Language == (int)LanguageRequest
                                                                                 && t.TVItemID == c.RainExceedanceTVItemID
                                                                                 select tl.TVText).FirstOrDefault()
                                                       let stakeholdersEmailDistributionListName = (from e in db.EmailDistributionLists
                                                                                                    from el in db.EmailDistributionListLanguages
                                                                                                    where e.EmailDistributionListID == el.EmailDistributionListID
                                                                                                    && el.Language == (int)LanguageRequest
                                                                                                    && e.EmailDistributionListID == c.StakeholdersEmailDistributionListID
                                                                                                    select el.EmailListName).FirstOrDefault()
                                                       let onlyStaffEmailDistributionListName = (from e in db.EmailDistributionLists
                                                                                                 from el in db.EmailDistributionListLanguages
                                                                                                 where e.EmailDistributionListID == el.EmailDistributionListID
                                                                                                 && el.Language == (int)LanguageRequest
                                                                                                 && e.EmailDistributionListID == c.OnlyStaffEmailDistributionListID
                                                                                                 select el.EmailListName).FirstOrDefault()
                                                       let mapInfoPoint = (from mi in db.MapInfos
                                                                           from mip in db.MapInfoPoints
                                                                           where mi.MapInfoID == mip.MapInfoID
                                                                           && mi.TVItemID == c.RainExceedanceTVItemID
                                                                           && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                                                           && mi.TVType == (int)TVTypeEnum.RainExceedance
                                                                           select mip).FirstOrDefault()
                                                       where c.RainExceedanceID == RainExceedanceID
                                                       select new RainExceedanceModel
                                                       {
                                                           Error = "",
                                                           RainExceedanceID = c.RainExceedanceID,
                                                           RainExceedanceTVItemID = c.RainExceedanceTVItemID,
                                                           RainExceedanceName = rainExceedanceName ?? "",
                                                           StartMonth = c.StartMonth,
                                                           StartDay = c.StartDay,
                                                           EndMonth = c.EndMonth,
                                                           EndDay = c.EndDay,
                                                           RainMaximum_mm = (float)c.RainMaximum_mm,
                                                           StakeholdersEmailDistributionListID = c.StakeholdersEmailDistributionListID,
                                                           StakeholdersEmailDistributionListName = stakeholdersEmailDistributionListName,
                                                           OnlyStaffEmailDistributionListID = c.OnlyStaffEmailDistributionListID,
                                                           OnlyStaffEmailDistributionListName = onlyStaffEmailDistributionListName,
                                                           IsActive = c.IsActive,
                                                           Lat = mapInfoPoint.Lat,
                                                           Lng = mapInfoPoint.Lng,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<RainExceedanceModel>();

            if (rainExceedanceModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.RainExceedance, ServiceRes.RainExceedanceID, RainExceedanceID));

            return rainExceedanceModel;
        }
        public RainExceedanceModel GetRainExceedanceModelWithRainExceedanceTVItemIDDB(int RainExceedanceTVItemID)
        {
            RainExceedanceModel rainExceedanceModel = (from c in db.RainExceedances
                                                       let rainExceedanceName = (from t in db.TVItems
                                                                                 from tl in db.TVItemLanguages
                                                                                 where t.TVItemID == tl.TVItemID
                                                                                 && tl.Language == (int)LanguageRequest
                                                                                 && t.TVItemID == c.RainExceedanceTVItemID
                                                                                 select tl.TVText).FirstOrDefault()
                                                       let stakeholdersEmailDistributionListName = (from e in db.EmailDistributionLists
                                                                                                    from el in db.EmailDistributionListLanguages
                                                                                                    where e.EmailDistributionListID == el.EmailDistributionListID
                                                                                                    && el.Language == (int)LanguageRequest
                                                                                                    && e.EmailDistributionListID == c.StakeholdersEmailDistributionListID
                                                                                                    select el.EmailListName).FirstOrDefault()
                                                       let onlyStaffEmailDistributionListName = (from e in db.EmailDistributionLists
                                                                                                 from el in db.EmailDistributionListLanguages
                                                                                                 where e.EmailDistributionListID == el.EmailDistributionListID
                                                                                                 && el.Language == (int)LanguageRequest
                                                                                                 && e.EmailDistributionListID == c.OnlyStaffEmailDistributionListID
                                                                                                 select el.EmailListName).FirstOrDefault()
                                                       let mapInfoPoint = (from mi in db.MapInfos
                                                                           from mip in db.MapInfoPoints
                                                                           where mi.MapInfoID == mip.MapInfoID
                                                                           && mi.TVItemID == c.RainExceedanceTVItemID
                                                                           && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                                                           && mi.TVType == (int)TVTypeEnum.RainExceedance
                                                                           select mip).FirstOrDefault()
                                                       where c.RainExceedanceTVItemID == RainExceedanceTVItemID
                                                       select new RainExceedanceModel
                                                       {
                                                           Error = "",
                                                           RainExceedanceID = c.RainExceedanceID,
                                                           RainExceedanceTVItemID = c.RainExceedanceTVItemID,
                                                           RainExceedanceName = rainExceedanceName ?? "",
                                                           StartMonth = c.StartMonth,
                                                           StartDay = c.StartDay,
                                                           EndMonth = c.EndMonth,
                                                           EndDay = c.EndDay,
                                                           RainMaximum_mm = (float)c.RainMaximum_mm,
                                                           StakeholdersEmailDistributionListID = c.StakeholdersEmailDistributionListID,
                                                           StakeholdersEmailDistributionListName = stakeholdersEmailDistributionListName,
                                                           OnlyStaffEmailDistributionListID = c.OnlyStaffEmailDistributionListID,
                                                           OnlyStaffEmailDistributionListName = onlyStaffEmailDistributionListName,
                                                           IsActive = c.IsActive,
                                                           Lat = mapInfoPoint.Lat,
                                                           Lng = mapInfoPoint.Lng,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<RainExceedanceModel>();

            if (rainExceedanceModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.RainExceedance, ServiceRes.RainExceedanceTVItemID, RainExceedanceTVItemID));

            return rainExceedanceModel;
        }
        public RainExceedance GetRainExceedanceWithRainExceedanceIDDB(int RainExceedanceID)
        {
            RainExceedance RainExceedance = (from c in db.RainExceedances
                                             where c.RainExceedanceID == RainExceedanceID
                                             select c).FirstOrDefault<RainExceedance>();

            return RainExceedance;
        }
        public RainExceedance GetRainExceedanceExistDB(RainExceedanceModel rainExceedanceModel)
        {
            RainExceedance rainExceedance = (from c in db.RainExceedances
                                             where c.RainExceedanceTVItemID == rainExceedanceModel.RainExceedanceTVItemID
                                             select c).FirstOrDefault<RainExceedance>();

            return rainExceedance;
        }

        // Helper
        public RainExceedanceModel ReturnError(string Error)
        {
            return new RainExceedanceModel() { Error = Error };
        }

        // Post
        public RainExceedanceModel PostRainExceedanceSaveDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int TempInt = 0;
            int ParentTVItemID = 0;
            int RainExceedanceID = 0;
            string RainExceedanceName = "";
            int StartMonth = 0;
            int StartDay = 0;
            int EndMonth = 0;
            int EndDay = 0;
            float RainMaximum_mm = 0.0f;
            int? StakeholdersEmailDistributionListID = null;
            int? OnlyStaffEmailDistributionListID = null;
            bool IsActive = false;
            double Lat = 0.0D;
            double Lng = 0.0D;

            int.TryParse(fc["ParentTVItemID"], out ParentTVItemID);
            if (ParentTVItemID == 0)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID));
            }

            int.TryParse(fc["RainExceedanceID"], out RainExceedanceID);
            // if 0 then want to add new RainExceedance else want to modify

            RainExceedanceName = fc["RainExceedanceName"];
            if (string.IsNullOrWhiteSpace(RainExceedanceName))
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.RainExceedanceName));
            }

            int.TryParse(fc["StartMonth"], out StartMonth);
            if (StartMonth == 0)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StartMonth));
            }

            int.TryParse(fc["StartDay"], out StartDay);
            if (StartDay == 0)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StartDay));
            }

            int.TryParse(fc["EndMonth"], out EndMonth);
            if (EndMonth == 0)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EndMonth));
            }

            int.TryParse(fc["EndDay"], out EndDay);
            if (EndDay == 0)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EndDay));
            }

            float.TryParse(fc["RainMaximum_mm"], out RainMaximum_mm);
            if (RainMaximum_mm == 0.0f)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.RainMaximum_mm));
            }

            int.TryParse(fc["StakeholdersEmailDistributionListID"], out TempInt);
            if (TempInt != 0)
            {
                StakeholdersEmailDistributionListID = TempInt;
            }

            int.TryParse(fc["OnlyStaffEmailDistributionListID"], out TempInt);
            if (TempInt != 0)
            {
                OnlyStaffEmailDistributionListID = TempInt;
            }

            if (!string.IsNullOrWhiteSpace(fc["IsActive"]))
            {
                IsActive = true;
            }

            double.TryParse(fc["Lat"], out Lat);
            if (Lat == 0.0D)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Lat));
            }

            double.TryParse(fc["Lng"], out Lng);
            if (Lng == 0.0D)
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Lng));
            }

            RainExceedanceModel RainExceedanceModelRet = new RainExceedanceModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (RainExceedanceID == 0)
                {
                    TVItemModel tvItemModelRainExceedance = _TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(ParentTVItemID, RainExceedanceName, TVTypeEnum.RainExceedance);
                    if (!string.IsNullOrWhiteSpace(tvItemModelRainExceedance.Error))
                    {
                        tvItemModelRainExceedance = _TVItemService.PostAddChildTVItemDB(ParentTVItemID, RainExceedanceName, TVTypeEnum.RainExceedance);
                        if (!string.IsNullOrWhiteSpace(tvItemModelRainExceedance.Error))
                        {
                            return ReturnError(tvItemModelRainExceedance.Error);
                        }
                    }

                    List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelRainExceedance.TVItemID, TVTypeEnum.RainExceedance, MapInfoDrawTypeEnum.Point);
                    if (mapInfoPointModelList.Count == 0)
                    {
                        List<Coord> coordList = new List<Coord>()
                        {
                            new Coord() { Lat = (float)Lat, Lng = (float)Lng, Ordinal = 0 }
                        };
                        MapInfoModel mapInfoModel = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.RainExceedance, tvItemModelRainExceedance.TVItemID);
                        if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                        {
                            return ReturnError(mapInfoModel.Error);
                        }
                    }
                    else
                    {
                        mapInfoPointModelList[0].Lat = Lat;
                        mapInfoPointModelList[0].Lng = Lng;

                        MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[0]);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                        {
                            return ReturnError(mapInfoPointModelRet.Error);
                        }
                    }

                    RainExceedanceModel RainExceedanceModelNew = new RainExceedanceModel()
                    {
                        RainExceedanceTVItemID = tvItemModelRainExceedance.TVItemID,
                        StartMonth = StartMonth,
                        StartDay = StartDay,
                        EndMonth = EndMonth,
                        EndDay = EndDay,
                        RainMaximum_mm = RainMaximum_mm,
                        StakeholdersEmailDistributionListID = StakeholdersEmailDistributionListID,
                        OnlyStaffEmailDistributionListID = OnlyStaffEmailDistributionListID,
                        IsActive = IsActive,
                    };

                    RainExceedanceModelRet = PostAddRainExceedanceDB(RainExceedanceModelNew);
                    if (!string.IsNullOrWhiteSpace(RainExceedanceModelRet.Error))
                        ReturnError(RainExceedanceModelRet.Error);

                }
                else
                {
                    RainExceedanceModel rainExceedanceModelToUpdate = GetRainExceedanceModelWithRainExceedanceIDDB(RainExceedanceID);
                    if (!string.IsNullOrWhiteSpace(rainExceedanceModelToUpdate.Error))
                    {
                        return ReturnError(rainExceedanceModelToUpdate.Error);
                    }

                    TVItemModel tvItemModelRainExceedance = _TVItemService.GetTVItemModelWithTVItemIDDB(rainExceedanceModelToUpdate.RainExceedanceTVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemModelRainExceedance.Error))
                    {
                        return ReturnError(tvItemModelRainExceedance.Error);
                    }

                    if (tvItemModelRainExceedance.TVText != RainExceedanceName)
                    {
                        tvItemModelRainExceedance.TVText = RainExceedanceName;

                        TVItemModel tvItemModelRainExceedanceRet = _TVItemService.PostUpdateTVItemDB(tvItemModelRainExceedance);
                        if (!string.IsNullOrWhiteSpace(tvItemModelRainExceedanceRet.Error))
                        {
                            return ReturnError(tvItemModelRainExceedanceRet.Error);
                        }
                    }

                    List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelRainExceedance.TVItemID, TVTypeEnum.RainExceedance, MapInfoDrawTypeEnum.Point);
                    if (mapInfoPointModelList.Count == 0)
                    {
                        List<Coord> coordList = new List<Coord>()
                        {
                            new Coord() { Lat = (float)Lat, Lng = (float)Lng, Ordinal = 0 }
                        };
                        MapInfoModel mapInfoModel = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.RainExceedance, tvItemModelRainExceedance.TVItemID);
                        if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                        {
                            return ReturnError(mapInfoModel.Error);
                        }
                    }
                    else
                    {
                        if (!(mapInfoPointModelList[0].Lat == Lat && mapInfoPointModelList[0].Lng == Lng))
                        {
                            mapInfoPointModelList[0].Lat = Lat;
                            mapInfoPointModelList[0].Lng = Lng;

                            MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[0]);
                            if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                            {
                                return ReturnError(mapInfoPointModelRet.Error);
                            }
                        }
                    }

                    rainExceedanceModelToUpdate.StartMonth = StartMonth;
                    rainExceedanceModelToUpdate.StartDay = StartDay;
                    rainExceedanceModelToUpdate.EndMonth = EndMonth;
                    rainExceedanceModelToUpdate.EndDay = EndDay;
                    rainExceedanceModelToUpdate.RainMaximum_mm = RainMaximum_mm;
                    rainExceedanceModelToUpdate.StakeholdersEmailDistributionListID = StakeholdersEmailDistributionListID;
                    rainExceedanceModelToUpdate.OnlyStaffEmailDistributionListID = OnlyStaffEmailDistributionListID;
                    rainExceedanceModelToUpdate.IsActive = IsActive;

                    RainExceedanceModelRet = PostUpdateRainExceedanceDB(rainExceedanceModelToUpdate);
                    if (!string.IsNullOrWhiteSpace(RainExceedanceModelRet.Error))
                        ReturnError(RainExceedanceModelRet.Error);
                }

                ts.Complete();
            }

            return RainExceedanceModelRet;
        }
        public RainExceedanceModel PostAddRainExceedanceDB(RainExceedanceModel rainExceedanceModel)
        {
            string retStr = RainExceedanceModelOK(rainExceedanceModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            RainExceedance rainExceedanceExist = GetRainExceedanceExistDB(rainExceedanceModel);
            if (rainExceedanceExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.RainExceedance));

            RainExceedance rainExceedanceNew = new RainExceedance();
            retStr = FillRainExceedance(rainExceedanceNew, rainExceedanceModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.RainExceedances.Add(rainExceedanceNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("RainExceedances", rainExceedanceNew.RainExceedanceID, LogCommandEnum.Add, rainExceedanceNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetRainExceedanceModelWithRainExceedanceIDDB(rainExceedanceNew.RainExceedanceID);
        }
        public RainExceedanceModel PostDeleteRainExceedanceDB(int RainExceedanceID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            RainExceedance rainExceedanceToDelete = GetRainExceedanceWithRainExceedanceIDDB(RainExceedanceID);
            if (rainExceedanceToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.RainExceedance));

            using (TransactionScope ts = new TransactionScope())
            {
                db.RainExceedances.Remove(rainExceedanceToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("RainExceedances", rainExceedanceToDelete.RainExceedanceID, LogCommandEnum.Delete, rainExceedanceToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public RainExceedanceModel PostDeleteRainExceedanceWithRainExceedanceTVItemIDDB(int RainExceedanceTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            RainExceedanceModel rainExceedanceModelToDelete = GetRainExceedanceModelWithRainExceedanceTVItemIDDB(RainExceedanceTVItemID);
            if (!string.IsNullOrWhiteSpace(rainExceedanceModelToDelete.Error))
            {
                return ReturnError(rainExceedanceModelToDelete.Error);
            }

            RainExceedanceModel rainExceedanceModelRet = PostDeleteRainExceedanceDB(rainExceedanceModelToDelete.RainExceedanceID);
            if (!string.IsNullOrWhiteSpace(rainExceedanceModelRet.Error))
            {
                return ReturnError(rainExceedanceModelRet.Error);
            }

            MapInfoModel mapInfoModelRet = _MapInfoService.PostDeleteMapInfoWithTVItemIDDB(rainExceedanceModelToDelete.RainExceedanceTVItemID);
            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
            {
                return ReturnError(mapInfoModelRet.Error);
            }

            TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(rainExceedanceModelToDelete.RainExceedanceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
            {
                return ReturnError(tvItemModelRet.Error);
            }

            return ReturnError("");
        }
        public RainExceedanceModel PostUpdateRainExceedanceDB(RainExceedanceModel rainExceedanceModel)
        {
            string retStr = RainExceedanceModelOK(rainExceedanceModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            RainExceedance rainExceedanceToUpdate = GetRainExceedanceWithRainExceedanceIDDB(rainExceedanceModel.RainExceedanceID);
            if (rainExceedanceToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.RainExceedance));

            retStr = FillRainExceedance(rainExceedanceToUpdate, rainExceedanceModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("RainExceedances", rainExceedanceToUpdate.RainExceedanceID, LogCommandEnum.Change, rainExceedanceToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetRainExceedanceModelWithRainExceedanceIDDB(rainExceedanceToUpdate.RainExceedanceID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
