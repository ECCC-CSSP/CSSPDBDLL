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
    public class PolSourceSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public PolSourceObservationService _PolSourceObservationService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _PolSourceObservationService = new PolSourceObservationService(LanguageRequest, User);
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
        public string PolSourceSiteModelOK(PolSourceSiteModel polSourceSiteModel)
        {
            string retStr = FieldCheckNotZeroInt(polSourceSiteModel.PolSourceSiteTVItemID, ServiceRes.PolSourceSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(polSourceSiteModel.PolSourceSiteTVText, ServiceRes.PolSourceSiteTVText, 3, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(polSourceSiteModel.Temp_Locator_CanDelete, ServiceRes.Temp_Locator_CanDelete, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(polSourceSiteModel.Oldsiteid, ServiceRes.Oldsiteid);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(polSourceSiteModel.Site, ServiceRes.Site, 0, 1000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(polSourceSiteModel.SiteID, ServiceRes.SiteID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(polSourceSiteModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }
            return "";
        }

        // Fill
        public string FillPolSourceSite(PolSourceSite polSourceSite, PolSourceSiteModel polSourceSiteModel, ContactOK contactOK)
        {
            polSourceSite.DBCommand = (int)polSourceSiteModel.DBCommand;
            polSourceSite.PolSourceSiteTVItemID = polSourceSiteModel.PolSourceSiteTVItemID;
            polSourceSite.Temp_Locator_CanDelete = polSourceSiteModel.Temp_Locator_CanDelete;
            polSourceSite.Oldsiteid = polSourceSiteModel.Oldsiteid;
            polSourceSite.Site = polSourceSiteModel.Site;
            polSourceSite.SiteID = polSourceSiteModel.SiteID;
            polSourceSite.IsPointSource = polSourceSiteModel.IsPointSource;
            if (polSourceSiteModel.InactiveReason == null)
            {
                polSourceSite.InactiveReason = null;
            }
            else
            {
                polSourceSite.InactiveReason = (int)polSourceSiteModel.InactiveReason;
            }
            polSourceSite.CivicAddressTVItemID = polSourceSiteModel.CivicAddressTVItemID;
            polSourceSite.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                polSourceSite.LastUpdateContactTVItemID = 2;
            }
            else
            {
                polSourceSite.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetPolSourceSiteModelCountDB()
        {
            int PolSourceSiteModelCount = (from c in db.PolSourceSites
                                           select c).Count();

            return PolSourceSiteModelCount;
        }
        public List<PolSourceSiteModel> GetPolSourceSiteModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<PolSourceSiteModel> polSourceSiteModelList = (from c in db.TVItems
                                                               from p in db.PolSourceSites
                                                               let siteName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == p.PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                               where c.ParentID == SubsectorTVItemID
                                                               && c.TVItemID == p.PolSourceSiteTVItemID
                                                               select new PolSourceSiteModel
                                                               {
                                                                   Error = "",
                                                                   PolSourceSiteID = p.PolSourceSiteID,
                                                                   DBCommand = (DBCommandEnum)p.DBCommand,
                                                                   PolSourceSiteTVItemID = p.PolSourceSiteTVItemID,
                                                                   PolSourceSiteTVText = siteName,
                                                                   Temp_Locator_CanDelete = p.Temp_Locator_CanDelete,
                                                                   Oldsiteid = p.Oldsiteid,
                                                                   Site = p.Site,
                                                                   SiteID = p.SiteID,
                                                                   IsPointSource = p.IsPointSource,
                                                                   InactiveReason = (PolSourceInactiveReasonEnum)p.InactiveReason,
                                                                   CivicAddressTVItemID = p.CivicAddressTVItemID,
                                                                   LastUpdateDate_UTC = p.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = p.LastUpdateContactTVItemID,
                                                               }).ToList<PolSourceSiteModel>();

            return polSourceSiteModelList;
        }
        public PolSourceSiteModel GetPolSourceSiteModelWithPolSourceSiteIDDB(int PolSourceSiteID)
        {
            PolSourceSiteModel polSourceSiteModel = (from c in db.PolSourceSites
                                                     let siteName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                     where c.PolSourceSiteID == PolSourceSiteID
                                                     select new PolSourceSiteModel
                                                     {
                                                         Error = "",
                                                         PolSourceSiteID = c.PolSourceSiteID,
                                                         DBCommand = (DBCommandEnum)c.DBCommand,
                                                         PolSourceSiteTVItemID = c.PolSourceSiteTVItemID,
                                                         PolSourceSiteTVText = siteName,
                                                         Temp_Locator_CanDelete = c.Temp_Locator_CanDelete,
                                                         Oldsiteid = c.Oldsiteid,
                                                         Site = c.Site,
                                                         SiteID = c.SiteID,
                                                         IsPointSource = c.IsPointSource,
                                                         InactiveReason = (PolSourceInactiveReasonEnum)c.InactiveReason,
                                                         CivicAddressTVItemID = c.CivicAddressTVItemID,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<PolSourceSiteModel>();

            if (polSourceSiteModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceSite, ServiceRes.PolSourceSiteID, PolSourceSiteID));
            }
            else
            {
                polSourceSiteModel.PolSourceObservationModelList = _PolSourceObservationService.GetPolSourceObservationModelListWithPolSourceSiteIDDB(polSourceSiteModel.PolSourceSiteID);
            }
            return polSourceSiteModel;
        }
        public PolSourceSiteModel GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(int PolSourceSiteTVItemID)
        {
            PolSourceSiteModel polSourceSiteModel = (from c in db.PolSourceSites
                                                     let siteName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                     where c.PolSourceSiteTVItemID == PolSourceSiteTVItemID
                                                     select new PolSourceSiteModel
                                                     {
                                                         Error = "",
                                                         PolSourceSiteID = c.PolSourceSiteID,
                                                         DBCommand = (DBCommandEnum)c.DBCommand,
                                                         PolSourceSiteTVItemID = c.PolSourceSiteTVItemID,
                                                         PolSourceSiteTVText = siteName,
                                                         Temp_Locator_CanDelete = c.Temp_Locator_CanDelete,
                                                         Oldsiteid = c.Oldsiteid,
                                                         Site = c.Site,
                                                         SiteID = c.SiteID,
                                                         IsPointSource = c.IsPointSource,
                                                         InactiveReason = (PolSourceInactiveReasonEnum)c.InactiveReason,
                                                         CivicAddressTVItemID = c.CivicAddressTVItemID,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<PolSourceSiteModel>();

            if (polSourceSiteModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceSite, ServiceRes.PolSourceSiteTVItemID, PolSourceSiteTVItemID));
            }
            else
            {
                polSourceSiteModel.PolSourceObservationModelList = _PolSourceObservationService.GetPolSourceObservationModelListWithPolSourceSiteIDDB(polSourceSiteModel.PolSourceSiteID);
            }

            return polSourceSiteModel;
        }
        public PolSourceSite GetPolSourceSiteWithPolSourceSiteWithPolSourceSiteTVItemIDDB(int PolSourceSiteTVItemID)
        {
            PolSourceSite polSourceSite = (from c in db.PolSourceSites
                                           where c.PolSourceSiteTVItemID == PolSourceSiteTVItemID
                                           select c).FirstOrDefault<PolSourceSite>();

            return polSourceSite;
        }
        public PolSourceSite GetPolSourceSiteWithPolSourceSiteIDDB(int PolSourceSiteID)
        {
            PolSourceSite polSourceSite = (from c in db.PolSourceSites
                                           where c.PolSourceSiteID == PolSourceSiteID
                                           select c).FirstOrDefault<PolSourceSite>();

            return polSourceSite;
        }
        public int GetNextAvailableSiteNumberWithParentTVItemIDDB(int ParentTVItemID)
        {
            int NextAvailableSiteNumber = 1;
            PolSourceSite polSourceSite = (from c in db.TVItems
                                           from p in db.PolSourceSites
                                           where c.TVItemID == p.PolSourceSiteTVItemID
                                           && c.ParentID == ParentTVItemID
                                           && p.Site != null
                                           orderby p.Site descending
                                           select p).FirstOrDefault<PolSourceSite>();

            if (polSourceSite != null)
            {
                NextAvailableSiteNumber = (int)polSourceSite.Site + 1;
            }

            return NextAvailableSiteNumber;
        }

        // Helper
        public string CreateTVText(PolSourceSiteModel polSourceSiteModel)
        {
            return polSourceSiteModel.PolSourceSiteTVText;
        }
        public bool GetIsItSameObject(PolSourceSiteModel polSourceSiteModel, TVItemModel tvItemModelPolSourceSiteExit)
        {
            bool IsSame = false;
            if (polSourceSiteModel.PolSourceSiteTVItemID == tvItemModelPolSourceSiteExit.TVItemID)
            {
                IsSame = true;
            }

            return IsSame;
        }
        public PolSourceSiteModel ReturnError(string Error)
        {
            return new PolSourceSiteModel() { Error = Error };
        }

        // Post
        public PolSourceSiteModel PolSourceSiteAddOrModifyDB(FormCollection fc)
        {
            int tempInt = 0;
            int ParentTVItemID = 0;
            int PolSourceSiteTVItemID = 0;
            bool IsActive = false;
            bool IsPointSource = false;
            double Lat = 0.0D;
            double Lng = 0.0D;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            if (string.IsNullOrWhiteSpace(fc["ParentTVItemID"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID));

            int.TryParse(fc["ParentTVItemID"], out ParentTVItemID);
            if (ParentTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID));

            if (string.IsNullOrWhiteSpace(fc["PolSourceSiteTVItemID"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteTVItemID));

            int.TryParse(fc["PolSourceSiteTVItemID"], out PolSourceSiteTVItemID);

            // PolSourceSiteTVItemID == 0 ==> Add 
            // PolSourceSiteTVItemID > 0 ==> Modify

            TVItemModel tvItemModelPolSource = null;
            if (PolSourceSiteTVItemID != 0)
            {
                tvItemModelPolSource = _TVItemService.GetTVItemModelWithTVItemIDDB(PolSourceSiteTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelPolSource.Error))
                    return ReturnError(tvItemModelPolSource.Error);
            }

            PolSourceSiteModel polSourceSiteNewOrToChange = new PolSourceSiteModel();

            if (PolSourceSiteTVItemID != 0)
            {
                polSourceSiteNewOrToChange = GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(PolSourceSiteTVItemID);
                if (!string.IsNullOrWhiteSpace(polSourceSiteNewOrToChange.Error))
                    return ReturnError(polSourceSiteNewOrToChange.Error);
            }

            polSourceSiteNewOrToChange.DBCommand = DBCommandEnum.Original;

            if (string.IsNullOrWhiteSpace(fc["IsActive"]))
                IsActive = false;
            else
                IsActive = true;

            if (!IsActive)
            {
                int.TryParse(fc["InactiveReason"], out tempInt);
                if (tempInt == 0)
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.InactiveReason));

                polSourceSiteNewOrToChange.InactiveReason = (PolSourceInactiveReasonEnum)tempInt;
            }
            else
            {
                polSourceSiteNewOrToChange.InactiveReason = null;
            }

            if (string.IsNullOrWhiteSpace(fc["IsPointSource"]))
                IsPointSource = false;
            else
                IsPointSource = true;

            polSourceSiteNewOrToChange.IsPointSource = IsPointSource;

            double.TryParse(fc["Lat"], out Lat);
            if (Lat == 0.0D)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Lat));

            double.TryParse(fc["Lng"], out Lng);
            if (Lng == 0.0D)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Lng));

            List<Coord> coordList = new List<Coord>() { new Coord() { Lat = (float)Lat, Lng = (float)Lng, Ordinal = 0 } };

            using (TransactionScope ts = new TransactionScope())
            {
                string ObservationInfo = ((int)PolSourceObsInfoEnum.SourceStart).ToString() + ",";
                List<int> obsIntList = ObservationInfo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                string ObservationLanguageTVText = ServiceRes.Error;
                string TVText = _BaseEnumService.GetEnumText_PolSourceObsInfoTextEnum(PolSourceObsInfoEnum.Error);
                int NextSiteNumber = 0;

                if (PolSourceSiteTVItemID == 0)
                {
                    NextSiteNumber = GetNextAvailableSiteNumberWithParentTVItemIDDB(ParentTVItemID);

                    polSourceSiteNewOrToChange.Site = NextSiteNumber;

                    TVText = TVText + " - " + "000000".Substring(0, "000000".Length - NextSiteNumber.ToString().Length) + NextSiteNumber.ToString();

                    TVItemModel tvItemModelNewPolSourceSite = _TVItemService.PostAddChildTVItemDB(ParentTVItemID, TVText, TVTypeEnum.PolSourceSite);
                    if (!string.IsNullOrWhiteSpace(tvItemModelNewPolSourceSite.Error))
                        return ReturnError(tvItemModelNewPolSourceSite.Error);

                    polSourceSiteNewOrToChange.PolSourceSiteTVItemID = tvItemModelNewPolSourceSite.TVItemID;
                    polSourceSiteNewOrToChange.PolSourceSiteTVText = TVText;

                    polSourceSiteNewOrToChange = PostAddPolSourceSiteDB(polSourceSiteNewOrToChange);
                    if (!string.IsNullOrWhiteSpace(polSourceSiteNewOrToChange.Error))
                        return ReturnError(polSourceSiteNewOrToChange.Error);

                    // Automatically add one Pollution Source Observation for today
                    PolSourceObservationModel polSourceObservationModelNew = new PolSourceObservationModel()
                    {
                        DBCommand = DBCommandEnum.Original,
                        PolSourceSiteID = polSourceSiteNewOrToChange.PolSourceSiteID,
                        ObservationDate_Local = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                        ContactTVItemID = contactOK.ContactTVItemID,
                        Observation_ToBeDeleted = "",
                    };

                    PolSourceObservationModel polSourceObservationModelRet = _PolSourceObservationService.PostAddPolSourceObservationDB(polSourceObservationModelNew);
                    if (!string.IsNullOrWhiteSpace(polSourceObservationModelRet.Error))
                        return ReturnError(polSourceObservationModelRet.Error);

                    // Automatically add one Pollution Source Observation Issue
                    PolSourceObservationIssueModel polSourceObservationIssueModelNew = new PolSourceObservationIssueModel();
                    polSourceObservationIssueModelNew.DBCommand = DBCommandEnum.Original;
                    polSourceObservationIssueModelNew.PolSourceObservationID = polSourceObservationModelRet.PolSourceObservationID;
                    polSourceObservationIssueModelNew.ObservationInfo = ObservationInfo;
                    polSourceObservationIssueModelNew.Ordinal = 0;

                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = _PolSourceObservationService._PolSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelNew);
                    if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
                        return ReturnError(polSourceObservationIssueModelRet.Error);

                    // doing the other language
                    foreach (LanguageEnum lang in LanguageListAllowable.Where(c => c != LanguageRequest))
                    {
                        TVItemService tvItemService = new TVItemService(lang, _TVItemService.User);
                        Thread.CurrentThread.CurrentCulture = new CultureInfo(lang + "-CA");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang + "-CA");

                        ObservationInfo = ((int)PolSourceObsInfoEnum.SourceStart).ToString() + ",";
                        ObservationLanguageTVText = ServiceRes.Error;
                        TVText = _BaseEnumService.GetEnumText_PolSourceObsInfoTextEnum(PolSourceObsInfoEnum.Error);

                        TVText = (string.IsNullOrWhiteSpace(TVText) ? ServiceRes.Error : TVText);

                        if (PolSourceSiteTVItemID == 0)
                        {
                            TVText = TVText + " - " + "000000".Substring(0, "000000".Length - NextSiteNumber.ToString().Length) + NextSiteNumber.ToString();
                        }
                        else
                        {
                            TVText = TVText + " - " + "000000".Substring(0, "000000".Length - polSourceSiteNewOrToChange.Site.ToString().Length) + polSourceSiteNewOrToChange.Site.ToString();
                        }

                        TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel();
                        tvItemLanguageModel.DBCommand = DBCommandEnum.Original;
                        tvItemLanguageModel.Language = lang;
                        tvItemLanguageModel.TVText = TVText;
                        tvItemLanguageModel.TVItemID = polSourceSiteNewOrToChange.PolSourceSiteTVItemID;

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                            return ReturnError(tvItemLanguageModelRet.Error);

                        Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageRequest + "-CA");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageRequest + "-CA");
                    }
                }
                else
                {
                    polSourceSiteNewOrToChange = PostUpdatePolSourceSiteDB(polSourceSiteNewOrToChange);
                    if (!string.IsNullOrWhiteSpace(polSourceSiteNewOrToChange.Error))
                        return ReturnError(polSourceSiteNewOrToChange.Error);

                }

                // Adding map info
                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(polSourceSiteNewOrToChange.PolSourceSiteTVItemID, TVTypeEnum.PolSourceSite, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count == 0)
                {
                    MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.PolSourceSite, polSourceSiteNewOrToChange.PolSourceSiteTVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                        return ReturnError(mapInfoModelRet.Error);
                }
                else
                {
                    mapInfoPointModelList[0].Lat = coordList[0].Lat;
                    mapInfoPointModelList[0].Lng = coordList[0].Lng;

                    MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[0]);
                    if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                        return ReturnError(mapInfoPointModelRet.Error);
                }

                TVItemModel tvItemModelPolSourceSite = _TVItemService.GetTVItemModelWithTVItemIDDB(polSourceSiteNewOrToChange.PolSourceSiteTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelPolSourceSite.Error))
                    return ReturnError(tvItemModelPolSourceSite.Error);

                tvItemModelPolSourceSite.IsActive = IsActive;

                TVItemModel tvItemModelRet = _TVItemService.PostUpdateTVItemDB(tvItemModelPolSourceSite);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnError(tvItemModelRet.Error);

                ts.Complete();
            }
            return polSourceSiteNewOrToChange;
        }
        public PolSourceSiteModel PostAddPolSourceSiteDB(PolSourceSiteModel polSourceSiteModel)
        {
            string retStr = PolSourceSiteModelOK(polSourceSiteModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(polSourceSiteModel.PolSourceSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnError(tvItemModelExist.Error);

            PolSourceSite polSourceSiteNew = new PolSourceSite();
            retStr = FillPolSourceSite(polSourceSiteNew, polSourceSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return new PolSourceSiteModel() { Error = retStr };
            }

            using (TransactionScope ts = new TransactionScope())
            {
                db.PolSourceSites.Add(polSourceSiteNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceSites", polSourceSiteNew.PolSourceSiteID, LogCommandEnum.Add, polSourceSiteNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetPolSourceSiteModelWithPolSourceSiteIDDB(polSourceSiteNew.PolSourceSiteID);
        }
        public PolSourceSiteModel PostDeletePolSourceSiteDB(int PolSourceSiteID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceSite polSourceSiteToDelete = GetPolSourceSiteWithPolSourceSiteIDDB(PolSourceSiteID);
            if (polSourceSiteToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.PolSourceSite));

            int TVItemIDToDelete = polSourceSiteToDelete.PolSourceSiteTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.PolSourceSites.Remove(polSourceSiteToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceSites", polSourceSiteToDelete.PolSourceSiteID, LogCommandEnum.Delete, polSourceSiteToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                try
                {
                    TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemIDToDelete);
                }
                catch (Exception)
                {
                    // nothing
                }

                ts.Complete();
            }
            return ReturnError("");
        }
        public PolSourceSiteModel PostDeletePolSourceSiteWithPolSourceSiteTVItemIDDB(int PolSourceSiteTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceSite polSourceSiteToDelete = GetPolSourceSiteWithPolSourceSiteWithPolSourceSiteTVItemIDDB(PolSourceSiteTVItemID);
            if (polSourceSiteToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.PolSourceSite));

            PolSourceSiteModel polSourceSiteModelRet = PostDeletePolSourceSiteDB(polSourceSiteToDelete.PolSourceSiteID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
                return ReturnError(polSourceSiteModelRet.Error);

            return ReturnError("");
        }
        public PolSourceSiteModel PostUpdatePolSourceSiteDB(PolSourceSiteModel polSourceSiteModel)
        {
            string retStr = PolSourceSiteModelOK(polSourceSiteModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceSite polSourceSiteToUpdate = GetPolSourceSiteWithPolSourceSiteIDDB(polSourceSiteModel.PolSourceSiteID);
            if (polSourceSiteToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.PolSourceSite));

            retStr = FillPolSourceSite(polSourceSiteToUpdate, polSourceSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceSites", polSourceSiteToUpdate.PolSourceSiteID, LogCommandEnum.Change, polSourceSiteToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetPolSourceSiteModelWithPolSourceSiteIDDB(polSourceSiteToUpdate.PolSourceSiteID);
        }
        public PolSourceSiteModel PolSourceSiteSetActiveDB(int TVItemID, bool SetActive)
        {
            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
            {
                return new PolSourceSiteModel() { Error = tvItemModel.Error };
            }

            tvItemModel.IsActive = SetActive;
            TVItemModel tvItemModelRet = _TVItemService.PostUpdateTVItemDB(tvItemModel);
            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
            {
                return new PolSourceSiteModel() { Error = tvItemModelRet.Error };
            }

            return ReturnError("");
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}