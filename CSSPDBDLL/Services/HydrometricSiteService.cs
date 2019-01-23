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

namespace CSSPDBDLL.Services
{
    public class HydrometricSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public AppTaskService _AppTaskService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public HydrometricSiteService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
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
        public string HydrometricSiteModelOK(HydrometricSiteModel hydrometricSiteModel)
        {
            string retStr = FieldCheckNotZeroInt(hydrometricSiteModel.HydrometricSiteTVItemID, ServiceRes.HydrometricSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(hydrometricSiteModel.HydrometricSiteName, ServiceRes.HydrometricSiteName, 2, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(hydrometricSiteModel.Province, ServiceRes.Province, 2, 2);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            List<string> ProvinceList = new List<string>() { "AB", "BC", "MB", "NB", "NL", "NS", "NT", "NU", "ON", "PE", "QC", "SK", "YT" };

            string ProvinceListTxt = "";
            foreach (string s in ProvinceList)
            {
                ProvinceListTxt += "," + s;
            }
            ProvinceListTxt = ProvinceListTxt.Substring(1);
            if (!ProvinceList.Contains(hydrometricSiteModel.Province))
            {
                return string.Format(ServiceRes.ProvinceNotCorrectNeedToBeOneOf_Its_, ProvinceListTxt.ToString(), hydrometricSiteModel.Province);
            }

            retStr = FieldCheckIfNotNullMaxLengthString(hydrometricSiteModel.FedSiteNumber, ServiceRes.FedSiteNumber, 7);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(hydrometricSiteModel.QuebecSiteNumber, ServiceRes.QuebecSiteNumber, 7);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(hydrometricSiteModel.Description, ServiceRes.Description, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(hydrometricSiteModel.Elevation_m, ServiceRes.Elevation_m, 0, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (hydrometricSiteModel.StartDate_Local != null && hydrometricSiteModel.EndDate_Local != null)
            {
                if (hydrometricSiteModel.EndDate_Local < hydrometricSiteModel.StartDate_Local)
                {
                    return string.Format(ServiceRes._IsBiggerOrEqualTo_, ServiceRes.StartDate_Local, ServiceRes.EndDate_Local);
                }
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(hydrometricSiteModel.TimeOffset_hour, ServiceRes.TimeOffset_hour, -8, -3);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(hydrometricSiteModel.DrainageArea_km2, ServiceRes.DrainageArea_km2, 0, 10000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillHydrometricSite(HydrometricSite hydrometricSiteNew, HydrometricSiteModel hydrometricSiteModel, ContactOK contactOK)
        {
            hydrometricSiteNew.HydrometricSiteTVItemID = hydrometricSiteModel.HydrometricSiteTVItemID;
            hydrometricSiteNew.FedSiteNumber = hydrometricSiteModel.FedSiteNumber;
            hydrometricSiteNew.QuebecSiteNumber = hydrometricSiteModel.QuebecSiteNumber;
            hydrometricSiteNew.HydrometricSiteName = hydrometricSiteModel.HydrometricSiteName;
            hydrometricSiteNew.Description = hydrometricSiteModel.Description;
            hydrometricSiteNew.Province = hydrometricSiteModel.Province;
            hydrometricSiteNew.Elevation_m = hydrometricSiteModel.Elevation_m;
            hydrometricSiteNew.Elevation_m = hydrometricSiteModel.Elevation_m;
            hydrometricSiteNew.StartDate_Local = hydrometricSiteModel.StartDate_Local;
            hydrometricSiteNew.EndDate_Local = hydrometricSiteModel.EndDate_Local;
            hydrometricSiteNew.TimeOffset_hour = hydrometricSiteModel.TimeOffset_hour;
            hydrometricSiteNew.DrainageArea_km2 = hydrometricSiteModel.DrainageArea_km2;
            hydrometricSiteNew.IsNatural = hydrometricSiteModel.IsNatural;
            hydrometricSiteNew.IsActive = hydrometricSiteModel.IsActive;
            hydrometricSiteNew.Sediment = hydrometricSiteModel.Sediment;
            hydrometricSiteNew.RHBN = hydrometricSiteModel.RHBN;
            hydrometricSiteNew.Province = hydrometricSiteModel.Province;
            hydrometricSiteNew.RealTime = hydrometricSiteModel.RealTime;
            hydrometricSiteNew.HasDischarge = hydrometricSiteModel.HasDischarge;
            hydrometricSiteNew.HasLevel = hydrometricSiteModel.HasLevel;
            hydrometricSiteNew.HasRatingCurve = hydrometricSiteModel.HasRatingCurve;
            hydrometricSiteNew.TimeOffset_hour = hydrometricSiteModel.TimeOffset_hour;
            hydrometricSiteNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                hydrometricSiteNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                hydrometricSiteNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetHydrometricSiteModelCountDB()
        {
            int HydrometricSiteModelCount = (from c in db.HydrometricSites
                                             select c).Count();

            return HydrometricSiteModelCount;
        }
        public HydrometricSiteModel GetHydrometricSiteModelWithFedSiteNumberDB(string FedSiteNumber)
        {
            HydrometricSiteModel HydrometricSiteModel = (from c in db.HydrometricSites
                                                         where c.FedSiteNumber == FedSiteNumber
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
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).FirstOrDefault<HydrometricSiteModel>();

            if (HydrometricSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite, ServiceRes.FedSiteNumber, FedSiteNumber));

            return HydrometricSiteModel;
        }
        public HydrometricSiteModel GetHydrometricSiteModelWithHydrometricSiteNameDB(string HydrometricSiteName)
        {
            HydrometricSiteModel HydrometricSiteModel = (from c in db.HydrometricSites
                                                         where c.HydrometricSiteName == HydrometricSiteName
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
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).FirstOrDefault<HydrometricSiteModel>();

            if (HydrometricSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite, ServiceRes.HydrometricSiteName, HydrometricSiteName));

            return HydrometricSiteModel;
        }
        public HydrometricSiteModel GetHydrometricSiteModelWithHydrometricSiteIDDB(int HydrometricSiteID)
        {
            HydrometricSiteModel HydrometricSiteModel = (from c in db.HydrometricSites
                                                         where c.HydrometricSiteID == HydrometricSiteID
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
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).FirstOrDefault<HydrometricSiteModel>();

            if (HydrometricSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite, ServiceRes.HydrometricSiteID, HydrometricSiteID));

            return HydrometricSiteModel;
        }
        public HydrometricSiteModel GetHydrometricSiteModelWithHydrometricSiteTVItemIDDB(int HydrometricSiteTVItemID)
        {
            HydrometricSiteModel HydrometricSiteModel = (from c in db.HydrometricSites
                                                         where c.HydrometricSiteTVItemID == HydrometricSiteTVItemID
                                                         orderby c.HydrometricSiteID descending
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
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).FirstOrDefault<HydrometricSiteModel>();

            if (HydrometricSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite, ServiceRes.HydrometricSiteTVItemID, HydrometricSiteTVItemID));

            return HydrometricSiteModel;
        }
        public HydrometricSiteModel GetHydrometricSiteModelExistDB(HydrometricSiteModel hydrometricSiteModel)
        {
            HydrometricSiteModel HydrometricSiteModel = (from c in db.HydrometricSites
                                                         where c.HydrometricSiteName == hydrometricSiteModel.HydrometricSiteName
                                                         && c.Province == hydrometricSiteModel.Province
                                                         && c.FedSiteNumber == hydrometricSiteModel.FedSiteNumber
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
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).FirstOrDefault<HydrometricSiteModel>();

            if (HydrometricSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite,
                    ServiceRes.HydrometricSiteName + "," +
                    ServiceRes.Province + "," +
                    ServiceRes.FedSiteNumber + "," +
                    ServiceRes.QuebecSiteNumber,
                    hydrometricSiteModel.HydrometricSiteName + "," +
                    hydrometricSiteModel.Province + "," +
                    hydrometricSiteModel.FedSiteNumber + "," +
                    hydrometricSiteModel.QuebecSiteNumber));

            return HydrometricSiteModel;
        }
        public HydrometricSite GetHydrometricSiteWithHydrometricSiteIDDB(int HydrometricSiteID)
        {
            HydrometricSite HydrometricSite = (from c in db.HydrometricSites
                                               where c.HydrometricSiteID == HydrometricSiteID
                                               orderby c.HydrometricSiteID descending
                                               select c).FirstOrDefault<HydrometricSite>();
            return HydrometricSite;
        }
        public List<HydrometricSiteModel> GetHydrometricSiteModelListWithSectorTVItemIDAndTVType(int SectorTVItemID, TVTypeEnum TVType)
        {
            TVItem tvItemSector = (from c in db.TVItems
                                   where c.TVItemID == SectorTVItemID
                                   select c).FirstOrDefault();
            if (tvItemSector == null)
            {
                return new List<HydrometricSiteModel>();
            }

            List<TVItemModel> tvItemSSModelList = tvItemSSModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemSector.TVItemID, TVTypeEnum.Subsector);
            if (tvItemSSModelList.Count == 0)
            {
                return new List<HydrometricSiteModel>();
            }

            List<int> TVItemIDSSList = new List<int>();
            foreach (TVItemModel tvItemModel in tvItemSSModelList)
            {
                TVItemIDSSList.Add(tvItemModel.TVItemID);
            }

            List<UseOfSite> useOfSiteList = (from c in db.UseOfSites
                                             from h in TVItemIDSSList
                                             where c.SubsectorTVItemID == h
                                             && c.TVType == (int)TVType
                                             select c).ToList();

            if (useOfSiteList.Count == 0)
            {
                return new List<HydrometricSiteModel>();
            }

            List<int> SiteTVItemIDList = new List<int>();
            foreach (UseOfSite useOfSite in useOfSiteList)
            {
                SiteTVItemIDList.Add(useOfSite.SiteTVItemID);
            }

            List<HydrometricSiteModel> hydrometricSiteModelList = (from c in db.HydrometricSites
                                                                   from u in SiteTVItemIDList
                                                                   where c.HydrometricSiteTVItemID == u
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
                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                   }).ToList<HydrometricSiteModel>();

            return hydrometricSiteModelList;
        }

        // Helper 
        public string CreateTVText(HydrometricSiteModel hydrometricSiteModel)
        {
            return hydrometricSiteModel.HydrometricSiteName +
                (hydrometricSiteModel.FedSiteNumber == null ? "" : " Fed:[" + hydrometricSiteModel.FedSiteNumber + "]") +
                (hydrometricSiteModel.QuebecSiteNumber == null ? "" : " QC:[" + hydrometricSiteModel.QuebecSiteNumber + "]");
        }
        public string GetProvinceTVText(string ProvinceTxt)
        {
            string ProvTxt = "";
            switch (ProvinceTxt)
            {
                case "AB":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Alberta";
                        }
                        else
                        {
                            ProvTxt = "Alberta";
                        }
                    }
                    break;
                case "BC":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Colombie-Britannique";
                        }
                        else
                        {
                            ProvTxt = "British Columbia";
                        }
                    }
                    break;
                case "MB":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Manitoba";
                        }
                        else
                        {
                            ProvTxt = "Manitoba";
                        }
                    }
                    break;
                case "NB":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Nouveau-Brunswick";
                        }
                        else
                        {
                            ProvTxt = "New Brunswick";
                        }
                    }
                    break;
                case "NL":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Terre-Neuve et Labrador";
                        }
                        else
                        {
                            ProvTxt = "Newfounland and Labrador";
                        }
                    }
                    break;
                case "NS":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Nouvelle-Écosse";
                        }
                        else
                        {
                            ProvTxt = "Nova Scotia";
                        }
                    }
                    break;
                case "NT":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Territoires du Nord-Ouest";
                        }
                        else
                        {
                            ProvTxt = "Northwest Territories";
                        }
                    }
                    break;
                case "NU":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Nunavut";
                        }
                        else
                        {
                            ProvTxt = "Nunavut";
                        }
                    }
                    break;
                case "ON":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Ontario";
                        }
                        else
                        {
                            ProvTxt = "Ontario";
                        }
                    }
                    break;
                case "PE":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Ile-du-Prince-Edouard";
                        }
                        else
                        {
                            ProvTxt = "Prince Edward Island";
                        }
                    }
                    break;
                case "QC":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Québec";
                        }
                        else
                        {
                            ProvTxt = "Quebec";
                        }
                    }
                    break;
                case "SK":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Saskatchewan";
                        }
                        else
                        {
                            ProvTxt = "Saskatchewan";
                        }
                    }
                    break;
                case "YT":
                    {
                        if (LanguageRequest == LanguageEnum.fr)
                        {
                            ProvTxt = "Territoire du Yukon";
                        }
                        else
                        {
                            ProvTxt = "Yukon Territory";
                        }
                    }
                    break;
                default:
                    break;
            }

            return ProvTxt;
        }
        public HydrometricSiteModel ReturnError(string Error)
        {
            return new HydrometricSiteModel() { Error = Error };
        }

        // Post
        public HydrometricSiteModel PostAddHydrometricSiteDB(HydrometricSiteModel hydrometricSiteModel)
        {
            string retStr = HydrometricSiteModelOK(hydrometricSiteModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(hydrometricSiteModel.HydrometricSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnError(tvItemModelExist.Error);

            HydrometricSite hydrometricSiteNew = new HydrometricSite();
            retStr = FillHydrometricSite(hydrometricSiteNew, hydrometricSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.HydrometricSites.Add(hydrometricSiteNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("HydrometricSites", hydrometricSiteNew.HydrometricSiteID, LogCommandEnum.Add, hydrometricSiteNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetHydrometricSiteModelWithHydrometricSiteIDDB(hydrometricSiteNew.HydrometricSiteID);
        }
        public HydrometricSiteModel PostDeleteHydrometricSiteDB(int HydrometricSiteID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            HydrometricSite hydrometricSiteToDelete = GetHydrometricSiteWithHydrometricSiteIDDB(HydrometricSiteID);
            if (hydrometricSiteToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.HydrometricSite));

            int TVItemIDToDelete = hydrometricSiteToDelete.HydrometricSiteTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.HydrometricSites.Remove(hydrometricSiteToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("HydrometricSites", hydrometricSiteToDelete.HydrometricSiteID, LogCommandEnum.Delete, hydrometricSiteToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemIDToDelete);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnError(tvItemModelRet.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public HydrometricSiteModel PostUpdateHydrometricSiteDB(HydrometricSiteModel hydrometricSiteModel)
        {
            string retStr = HydrometricSiteModelOK(hydrometricSiteModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            HydrometricSite hydrometricSiteToUpdate = GetHydrometricSiteWithHydrometricSiteIDDB(hydrometricSiteModel.HydrometricSiteID);
            if (hydrometricSiteToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.HydrometricSite));

            retStr = FillHydrometricSite(hydrometricSiteToUpdate, hydrometricSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("HydrometricSites", hydrometricSiteToUpdate.HydrometricSiteID, LogCommandEnum.Change, hydrometricSiteToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        TVItemLanguageModel tvItemLanguageModelToUpdate = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(hydrometricSiteToUpdate.HydrometricSiteTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.Error))
                            return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemLanguage, ServiceRes.TVItemID + "," + ServiceRes.Language, hydrometricSiteToUpdate.HydrometricSiteTVItemID.ToString() + "," + Lang));

                        tvItemLanguageModelToUpdate.TVText = CreateTVText(hydrometricSiteModel);
                        if (string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.TVText))
                            return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelToUpdate);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);
                    }
                }

                ts.Complete();
            }
            return GetHydrometricSiteModelWithHydrometricSiteIDDB(hydrometricSiteToUpdate.HydrometricSiteID);
        }
        public string UpdateHydrometricSitesInformationForProvinceTVItemIDDB(int ProvinceTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.UpdateHydrometricSiteInformation);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ProvinceTVItemID", Value = ProvinceTVItemID.ToString() });

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
                TVItemID = ProvinceTVItemID,
                TVItemID2 = ProvinceTVItemID,
                AppTaskCommand = AppTaskCommandEnum.UpdateHydrometricSiteInformation,
                ErrorText = "",
                StatusText = ServiceRes.UpdatingHydrometricSiteInformation,
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
        public string UpdateHydrometricSiteDailyAndHourlyFromStartDateToEndDateDB(int HydrometricSiteTVItemID, DateTime StartDate, DateTime EndDate)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(HydrometricSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(HydrometricSiteTVItemID, HydrometricSiteTVItemID, AppTaskCommandEnum.UpdateHydrometricSiteDailyAndHourlyFromStartDateToEndDate);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "HydrometricSiteTVItemID", Value = HydrometricSiteTVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "StartYear", Value = StartDate.Year.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "StartMonth", Value = StartDate.Month.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "StartDay", Value = StartDate.Day.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "EndYear", Value = EndDate.Year.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "EndMonth", Value = EndDate.Month.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "EndDay", Value = EndDate.Day.ToString() });

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
                TVItemID = HydrometricSiteTVItemID,
                TVItemID2 = HydrometricSiteTVItemID,
                AppTaskCommand = AppTaskCommandEnum.UpdateHydrometricSiteDailyAndHourlyFromStartDateToEndDate,
                ErrorText = "",
                StatusText = string.Format(ServiceRes.UpdatingHydrometricSiteDailyAndHourlyFrom_To_, StartDate.ToString("G"), EndDate.ToString("G")),
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
        public string UpdateHydrometricSiteDailyAndHourlyForSubsectorFromStartDateToEndDateDB(int SubsectorTVItemID, DateTime StartDate, DateTime EndDate)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(SubsectorTVItemID, SubsectorTVItemID, AppTaskCommandEnum.UpdateHydrometricSiteDailyAndHourlyForSubsectorFromStartDateToEndDate);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "SubsectorTVItemID", Value = SubsectorTVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "StartYear", Value = StartDate.Year.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "StartMonth", Value = StartDate.Month.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "StartDay", Value = StartDate.Day.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "EndYear", Value = EndDate.Year.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "EndMonth", Value = EndDate.Month.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "EndDay", Value = EndDate.Day.ToString() });

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
                AppTaskCommand = AppTaskCommandEnum.UpdateHydrometricSiteDailyAndHourlyForSubsectorFromStartDateToEndDate,
                ErrorText = "",
                StatusText = string.Format(ServiceRes.UpdatingHydrometricSiteDailyAndHourlyFrom_To_, StartDate.ToString("G"), EndDate.ToString("G")),
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
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
