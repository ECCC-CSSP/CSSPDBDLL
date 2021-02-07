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
    public class ClimateSiteService : BaseService
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
        public ClimateSiteService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string ClimateSiteModelOK(ClimateSiteModel climateSiteModel)
        {
            string retStr = FieldCheckNotZeroInt(climateSiteModel.ClimateSiteTVItemID, ServiceRes.ClimateSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(climateSiteModel.ClimateSiteName, ServiceRes.ClimateSiteName, 2, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            // Commented out because the CoCoRaHS site do not have ECDBID 
            //
            //retStr = FieldCheckNotZeroInt(climateSiteModel.ECDBID, ServiceRes.ECDBID);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    return retStr;
            //}

            retStr = FieldCheckNotNullAndMinMaxLengthString(climateSiteModel.Province, ServiceRes.Province, 2, 4);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            List<string> ProvinceList = new List<string>() { "BC", "NB", "NL", "NS", "PE", "QC", "WA", "ME" };
            string ProvinceListTxt = "";
            foreach (string s in ProvinceList)
            {
                ProvinceListTxt += "," + s;
            }
            ProvinceListTxt = ProvinceListTxt.Substring(1);
            if (!ProvinceList.Contains(climateSiteModel.Province))
            {
                return string.Format(ServiceRes.ProvinceNotCorrectNeedToBeOneOf_Its_, ProvinceListTxt.ToString(), climateSiteModel.Province);
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(climateSiteModel.Elevation_m, ServiceRes.Elevation_m, 0, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(climateSiteModel.ClimateID, ServiceRes.ClimateID, 10);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }
            retStr = FieldCheckIfNotNullWithinRangeInt(climateSiteModel.WMOID, ServiceRes.WMOID, 10000, 99999);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }
            retStr = FieldCheckIfNotNullMaxLengthString(climateSiteModel.TCID, ServiceRes.TCID, 3);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }
            retStr = FieldCheckIfNotNullWithinRangeDouble(climateSiteModel.TimeOffset_hour, ServiceRes.TimeOffset_hour, -8, -3);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }
            retStr = FieldCheckIfNotNullMaxLengthString(climateSiteModel.File_desc, ServiceRes.File_desc, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }
            if (climateSiteModel.HourlyStartDate_Local != null && climateSiteModel.HourlyEndDate_Local != null)
            {
                if (climateSiteModel.HourlyEndDate_Local < climateSiteModel.HourlyStartDate_Local)
                {
                    return string.Format(ServiceRes._IsBiggerOrEqualTo_, ServiceRes.HourlyStartDate_Local, ServiceRes.HourlyEndDate_Local);
                }
            }
            if (climateSiteModel.DailyStartDate_Local != null && climateSiteModel.DailyEndDate_Local != null)
            {
                if (climateSiteModel.DailyEndDate_Local < climateSiteModel.DailyStartDate_Local)
                {
                    return string.Format(ServiceRes._IsBiggerOrEqualTo_, ServiceRes.DailyStartDate_Local, ServiceRes.DailyEndDate_Local);
                }
            }
            if (climateSiteModel.MonthlyStartDate_Local != null && climateSiteModel.MonthlyEndDate_Local != null)
            {
                if (climateSiteModel.MonthlyEndDate_Local < climateSiteModel.MonthlyStartDate_Local)
                {
                    return string.Format(ServiceRes._IsBiggerOrEqualTo_, ServiceRes.MonthlyStartDate_Local, ServiceRes.MonthlyEndDate_Local);
                }
            }

            retStr = _BaseEnumService.DBCommandOK(climateSiteModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillClimateSite(ClimateSite climateSiteNew, ClimateSiteModel climateSiteModel, ContactOK contactOK)
        {
            climateSiteNew.DBCommand = (int)climateSiteModel.DBCommand;
            climateSiteNew.ClimateSiteTVItemID = climateSiteModel.ClimateSiteTVItemID;
            climateSiteNew.ClimateID = climateSiteModel.ClimateID;
            climateSiteNew.ClimateSiteName = climateSiteModel.ClimateSiteName;
            climateSiteNew.DailyEndDate_Local = climateSiteModel.DailyEndDate_Local;
            climateSiteNew.DailyNow = climateSiteModel.DailyNow;
            climateSiteNew.DailyStartDate_Local = climateSiteModel.DailyStartDate_Local;
            climateSiteNew.ECDBID = climateSiteModel.ECDBID;
            climateSiteNew.Elevation_m = climateSiteModel.Elevation_m;
            climateSiteNew.File_desc = climateSiteModel.File_desc;
            climateSiteNew.HourlyEndDate_Local = climateSiteModel.HourlyEndDate_Local;
            climateSiteNew.HourlyNow = climateSiteModel.HourlyNow;
            climateSiteNew.HourlyStartDate_Local = climateSiteModel.HourlyStartDate_Local;
            climateSiteNew.IsQuebecSite = climateSiteModel.IsQuebecSite;
            climateSiteNew.IsCoCoRaHS = climateSiteModel.IsCoCoRaHS;
            climateSiteNew.MonthlyEndDate_Local = climateSiteModel.MonthlyEndDate_Local;
            climateSiteNew.MonthlyNow = climateSiteModel.MonthlyNow;
            climateSiteNew.MonthlyStartDate_Local = climateSiteModel.MonthlyStartDate_Local;
            climateSiteNew.Province = climateSiteModel.Province;
            climateSiteNew.TCID = climateSiteModel.TCID;
            climateSiteNew.TimeOffset_hour = climateSiteModel.TimeOffset_hour;
            climateSiteNew.WMOID = climateSiteModel.WMOID;
            climateSiteNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                climateSiteNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                climateSiteNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetClimateSiteModelCountDB()
        {
            int ClimateSiteModelCount = (from c in db.ClimateSites
                                         select c).Count();

            return ClimateSiteModelCount;
        }
        public ClimateSiteModel GetClimateSiteModelWithClimateIDDB(string ClimateID)
        {
            ClimateSiteModel climateSiteModel = (from c in db.ClimateSites
                                                 where c.ClimateID == ClimateID
                                                 select new ClimateSiteModel
                                                 {
                                                     Error = "",
                                                     ClimateSiteID = c.ClimateSiteID,
                                                     DBCommand = (DBCommandEnum)c.DBCommand,
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
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                 }).FirstOrDefault<ClimateSiteModel>();

            if (climateSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateSite, ServiceRes.ClimateID, ClimateID));

            return climateSiteModel;
        }
        public ClimateSiteModel GetClimateSiteModelWithECDBIDDB(int ECDBID)
        {
            ClimateSiteModel climateSiteModel = (from c in db.ClimateSites
                                                 where c.ECDBID == ECDBID
                                                 select new ClimateSiteModel
                                                 {
                                                     Error = "",
                                                     ClimateSiteID = c.ClimateSiteID,
                                                     DBCommand = (DBCommandEnum)c.DBCommand,
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
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                 }).FirstOrDefault<ClimateSiteModel>();

            if (climateSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateSite, ServiceRes.ECDBID, ECDBID));

            return climateSiteModel;
        }
        public ClimateSiteModel GetClimateSiteModelWithClimateSiteIDDB(int ClimateSiteID)
        {
            ClimateSiteModel climateSiteModel = (from c in db.ClimateSites
                                                 where c.ClimateSiteID == ClimateSiteID
                                                 select new ClimateSiteModel
                                                 {
                                                     Error = "",
                                                     ClimateSiteID = c.ClimateSiteID,
                                                     DBCommand = (DBCommandEnum)c.DBCommand,
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
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                 }).FirstOrDefault<ClimateSiteModel>();

            if (climateSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateSite, ServiceRes.ClimateSiteID, ClimateSiteID));

            return climateSiteModel;
        }
        public ClimateSiteModel GetClimateSiteModelWithClimateSiteTVItemIDDB(int ClimateSiteTVItemID)
        {
            ClimateSiteModel climateSiteModel = (from c in db.ClimateSites
                                                 where c.ClimateSiteTVItemID == ClimateSiteTVItemID
                                                 orderby c.ClimateSiteID descending
                                                 select new ClimateSiteModel
                                                 {
                                                     Error = "",
                                                     ClimateSiteID = c.ClimateSiteID,
                                                     DBCommand = (DBCommandEnum)c.DBCommand,
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
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                 }).FirstOrDefault<ClimateSiteModel>();

            if (climateSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateSite, ServiceRes.ClimateSiteTVItemID, ClimateSiteTVItemID));

            return climateSiteModel;
        }
        public ClimateSiteModel GetClimateSiteModelExistDB(ClimateSiteModel climateSiteModel)
        {
            ClimateSiteModel climateSiteModelRet = (from c in db.ClimateSites
                                                    where c.ClimateSiteName == climateSiteModel.ClimateSiteName
                                                    && c.Province == climateSiteModel.Province
                                                    && c.ECDBID == climateSiteModel.ECDBID
                                                    && c.ClimateID == climateSiteModel.ClimateID
                                                    select new ClimateSiteModel
                                                    {
                                                        Error = "",
                                                        ClimateSiteID = c.ClimateSiteID,
                                                        DBCommand = (DBCommandEnum)c.DBCommand,
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
                                                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                    }).FirstOrDefault<ClimateSiteModel>();

            if (climateSiteModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateSite,
                    ServiceRes.ClimateSiteName + "," +
                    ServiceRes.Province + "," +
                    ServiceRes.ECDBID + "," +
                    ServiceRes.ClimateID,
                    climateSiteModel.ClimateSiteName + "," +
                    climateSiteModel.Province + "," +
                    climateSiteModel.ECDBID.ToString() + "," +
                    climateSiteModel.ClimateID.ToString()));

            return climateSiteModelRet;
        }
        public ClimateSite GetClimateSiteWithClimateSiteIDDB(int ClimateSiteID)
        {
            ClimateSite ClimateSite = (from c in db.ClimateSites
                                       where c.ClimateSiteID == ClimateSiteID
                                       select c).FirstOrDefault<ClimateSite>();
            return ClimateSite;
        }

        // Helper
        public string CreateTVText(ClimateSiteModel climateSiteModel)
        {
            string retStr = climateSiteModel.ClimateSiteName + (climateSiteModel.ClimateID == null ? "" : ("(" + climateSiteModel.ClimateID + ")"));
            return retStr;
        }
        public string GetProvinceTVText(string ProvinceTxt)
        {
            string ProvTxt = "";
            switch (ProvinceTxt)
            {
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
                case "NFLD":
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
                case "PEI":
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
                case "QUE":
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
                default:
                    break;
            }

            return ProvTxt;
        }
        public ClimateSiteModel ReturnError(string Error)
        {
            return new ClimateSiteModel() { Error = Error };
        }
     
        // Post
        public ClimateSiteModel PostAddClimateSiteDB(ClimateSiteModel climateSiteModel)
        {
            string retStr = ClimateSiteModelOK(climateSiteModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(climateSiteModel.ClimateSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnError(tvItemModelExist.Error);

            ClimateSite climateSiteNew = new ClimateSite();

            retStr = FillClimateSite(climateSiteNew, climateSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.ClimateSites.Add(climateSiteNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ClimateSites", climateSiteNew.ClimateSiteID, LogCommandEnum.Add, climateSiteNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetClimateSiteModelWithClimateSiteIDDB(climateSiteNew.ClimateSiteID);
        }
        public ClimateSiteModel PostDeleteClimateSiteDB(int ClimateSiteID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ClimateSite climateSiteToDelete = GetClimateSiteWithClimateSiteIDDB(ClimateSiteID);
            if (climateSiteToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ClimateSite));

            int TVItemIDToDelete = climateSiteToDelete.ClimateSiteTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.ClimateSites.Remove(climateSiteToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ClimateSites", climateSiteToDelete.ClimateSiteID, LogCommandEnum.Delete, climateSiteToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemIDToDelete);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnError(tvItemModelRet.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public ClimateSiteModel PostUpdateClimateSiteDB(ClimateSiteModel climateSiteModel)
        {
            string retStr = ClimateSiteModelOK(climateSiteModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ClimateSite climateSiteToUpdate = GetClimateSiteWithClimateSiteIDDB(climateSiteModel.ClimateSiteID);
            if (climateSiteToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.ClimateSite));

            retStr = FillClimateSite(climateSiteToUpdate, climateSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ClimateSites", climateSiteToUpdate.ClimateSiteID, LogCommandEnum.Change, climateSiteToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        TVItemLanguageModel tvItemLanguageModelToUpdate = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(climateSiteToUpdate.ClimateSiteTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.Error))
                            return ReturnError(tvItemLanguageModelToUpdate.Error);

                        tvItemLanguageModelToUpdate.TVText = CreateTVText(climateSiteModel);
                        if (string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.TVText))
                            return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelToUpdate);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);
                    }
                }

                ts.Complete();
            }
            return GetClimateSiteModelWithClimateSiteIDDB(climateSiteToUpdate.ClimateSiteID);
        }
        public string UpdateClimateSitesInformationForProvinceTVItemIDDB(int ProvinceTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.UpdateClimateSiteInformation);
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
                DBCommand = DBCommandEnum.Original,
                TVItemID = ProvinceTVItemID,
                TVItemID2 = ProvinceTVItemID,
                AppTaskCommand = AppTaskCommandEnum.UpdateClimateSiteInformation,
                ErrorText = "",
                StatusText = ServiceRes.UpdatingClimateSiteInformation,
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
        public string UpdateClimateSiteDailyAndHourlyFromStartDateToEndDateDB(int ClimateSiteTVItemID, DateTime StartDate, DateTime EndDate)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(ClimateSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ClimateSiteTVItemID, ClimateSiteTVItemID, AppTaskCommandEnum.UpdateClimateSiteDailyAndHourlyFromStartDateToEndDate);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ClimateSiteTVItemID", Value = ClimateSiteTVItemID.ToString() });
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
                DBCommand = DBCommandEnum.Original,
                TVItemID = ClimateSiteTVItemID,
                TVItemID2 = ClimateSiteTVItemID,
                AppTaskCommand = AppTaskCommandEnum.UpdateClimateSiteDailyAndHourlyFromStartDateToEndDate,
                ErrorText = "",
                StatusText = string.Format(ServiceRes.UpdatingClimateSiteDailyAndHourlyFrom_To_, StartDate.ToString("G"), EndDate.ToString("G")),
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
        public string UpdateClimateSiteDailyAndHourlyForSubsectorFromStartDateToEndDateDB(int SubsectorTVItemID, DateTime StartDate, DateTime EndDate)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(SubsectorTVItemID, SubsectorTVItemID, AppTaskCommandEnum.UpdateClimateSiteDailyAndHourlyForSubsectorFromStartDateToEndDate);
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
                DBCommand = DBCommandEnum.Original,
                TVItemID = SubsectorTVItemID,
                TVItemID2 = SubsectorTVItemID,
                AppTaskCommand = AppTaskCommandEnum.UpdateClimateSiteDailyAndHourlyForSubsectorFromStartDateToEndDate,
                ErrorText = "",
                StatusText = string.Format(ServiceRes.UpdatingClimateSiteDailyAndHourlyFrom_To_, StartDate.ToString("G"), EndDate.ToString("G")),
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
