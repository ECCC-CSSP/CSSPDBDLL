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
    public class UseOfSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public UseOfSiteService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _LogService = new LogService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions public
        // Override
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
        public string UseOfSiteModelOK(UseOfSiteModel useOfSiteModel)
        {
            string retStr = FieldCheckNotZeroInt(useOfSiteModel.SiteTVItemID, ServiceRes.SiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(useOfSiteModel.SubsectorTVItemID, ServiceRes.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.SiteTypeOK(useOfSiteModel.SiteType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(useOfSiteModel.Ordinal, ServiceRes.Ordinal, 0, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(useOfSiteModel.StartYear, ServiceRes.StartYear);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(useOfSiteModel.EndYear, ServiceRes.EndYear);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (useOfSiteModel.StartYear > useOfSiteModel.EndYear)
            {
                return string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartYear, ServiceRes.EndYear);
            }

            //retStr = FieldCheckNotNullBool(useOfSiteModel.UseWeight, ServiceRes.UseWeight);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    return retStr;
            //}

            //retStr = FieldCheckNotNullAndWithinRangeDouble(useOfSiteModel.Weight_perc, ServiceRes.Weight_perc, 0, 100);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    return retStr;
            //}

            retStr = FieldCheckIfNotNullWithinRangeDouble(useOfSiteModel.Weight_perc, ServiceRes.Weight_perc, 0, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            //retStr = FieldCheckNotNullBool(useOfSiteModel.UseEquation, ServiceRes.UseEquation);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //{
            //    return retStr;
            //}

            retStr = FieldCheckIfNotNullWithinRangeDouble(useOfSiteModel.Param1, ServiceRes.Param1, 0, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(useOfSiteModel.Param2, ServiceRes.Param2, 0, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(useOfSiteModel.Param3, ServiceRes.Param3, 0, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(useOfSiteModel.Param4, ServiceRes.Param4, 0, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillUseOfSite(UseOfSite useOfSite, UseOfSiteModel useOfSiteModel, ContactOK contactOK)
        {
            useOfSite.SiteTVItemID = useOfSiteModel.SiteTVItemID;
            useOfSite.SubsectorTVItemID = useOfSiteModel.SubsectorTVItemID;
            useOfSite.SiteType = (int)useOfSiteModel.SiteType;
            useOfSite.Ordinal = useOfSiteModel.Ordinal;
            useOfSite.StartYear = useOfSiteModel.StartYear;
            useOfSite.EndYear = useOfSiteModel.EndYear;
            useOfSite.UseWeight = useOfSiteModel.UseWeight;
            useOfSite.Weight_perc = useOfSiteModel.Weight_perc;
            useOfSite.UseEquation = useOfSiteModel.UseEquation;
            useOfSite.Param1 = useOfSiteModel.Param1;
            useOfSite.Param2 = useOfSiteModel.Param2;
            useOfSite.Param3 = useOfSiteModel.Param3;
            useOfSite.Param4 = useOfSiteModel.Param4;
            useOfSite.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                useOfSite.LastUpdateContactTVItemID = 2;
            }
            else
            {
                useOfSite.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetUseOfSiteModelCountDB()
        {
            int UseOfSiteModelCount = (from c in db.UseOfSites
                                       select c).Count();

            return UseOfSiteModelCount;
        }
        public UseOfSiteModel GetUseOfSiteModelWithUseOfSiteIDDB(int UseOfSiteID)
        {
            UseOfSiteModel UseOfSiteModel = (from c in db.UseOfSites
                                             let siteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                             let subsectorTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                             where c.UseOfSiteID == UseOfSiteID
                                             select new UseOfSiteModel
                                             {
                                                 Error = "",
                                                 UseOfSiteID = c.UseOfSiteID,
                                                 SiteTVItemID = c.SiteTVItemID,
                                                 SiteTVText = siteTVText,
                                                 SubsectorTVItemID = c.SubsectorTVItemID,
                                                 SubsectorTVText = subsectorTVText,
                                                 SiteType = (SiteTypeEnum)c.SiteType,
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
                                             }).FirstOrDefault<UseOfSiteModel>();

            if (UseOfSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.UseOfSite, ServiceRes.UseOfSiteID, UseOfSiteID));

            return UseOfSiteModel;
        }
        public List<UseOfSiteModel> GetUseOfSiteModelListWithSiteTVItemIDDB(int SiteTVItemID)
        {
            List<UseOfSiteModel> UseOfSiteModelList = (from c in db.UseOfSites
                                                       let siteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                       let subsectorTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                       where c.SiteTVItemID == SiteTVItemID
                                                       orderby c.UseOfSiteID descending
                                                       select new UseOfSiteModel
                                                       {
                                                           Error = "",
                                                           UseOfSiteID = c.UseOfSiteID,
                                                           SiteTVItemID = c.SiteTVItemID,
                                                           SiteTVText = siteTVText,
                                                           SubsectorTVItemID = c.SubsectorTVItemID,
                                                           SubsectorTVText = subsectorTVText,
                                                           SiteType = (SiteTypeEnum)c.SiteType,
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
                                                       }).ToList<UseOfSiteModel>();

            return UseOfSiteModelList;
        }
        public List<UseOfSiteModel> GetUseOfSiteModelListWithSiteTypeAndSubsectorTVItemIDDB(SiteTypeEnum SiteType, int SubsectorTVItemID)
        {
            List<UseOfSiteModel> UseOfSiteModelList = (from c in db.UseOfSites
                                                       let siteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                       let subsectorTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                       where c.SiteType == (int)SiteType
                                                       && c.SubsectorTVItemID == SubsectorTVItemID
                                                       orderby c.Ordinal descending
                                                       select new UseOfSiteModel
                                                       {
                                                           Error = "",
                                                           UseOfSiteID = c.UseOfSiteID,
                                                           SiteTVItemID = c.SiteTVItemID,
                                                           SiteTVText = siteTVText,
                                                           SubsectorTVItemID = c.SubsectorTVItemID,
                                                           SubsectorTVText = subsectorTVText,
                                                           SiteType = (SiteTypeEnum)c.SiteType,
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
                                                       }).ToList<UseOfSiteModel>();

            return UseOfSiteModelList;
        }
        public UseOfSiteModel GetUseOfSiteModelWithSiteTVItemIDAndSubsectorTVItemIDDB(int SiteTVItemID, int SubsectorTVItemID)
        {
            UseOfSiteModel UseOfSiteModel = (from c in db.UseOfSites
                                             let siteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                             let subsectorTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                             where c.SiteTVItemID == SiteTVItemID
                                             && c.SubsectorTVItemID == SubsectorTVItemID
                                             orderby c.UseOfSiteID descending
                                             select new UseOfSiteModel
                                             {
                                                 Error = "",
                                                 UseOfSiteID = c.UseOfSiteID,
                                                 SiteTVItemID = c.SiteTVItemID,
                                                 SiteTVText = siteTVText,
                                                 SubsectorTVItemID = c.SubsectorTVItemID,
                                                 SubsectorTVText = subsectorTVText,
                                                 SiteType = (SiteTypeEnum)c.SiteType,
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
                                             }).FirstOrDefault<UseOfSiteModel>();

            if (UseOfSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.UseOfSite, ServiceRes.SiteTVItemID + "," + ServiceRes.SubsectorTVItemID, SiteTVItemID.ToString() + "," + SubsectorTVItemID.ToString()));

            return UseOfSiteModel;
        }
        public List<UseOfSiteModel> GetUseOfSiteModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<UseOfSiteModel> UseOfSiteModelList = (from c in db.UseOfSites
                                                       let siteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                       let subsectorTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                       where c.SubsectorTVItemID == SubsectorTVItemID
                                                       orderby c.UseOfSiteID descending
                                                       select new UseOfSiteModel
                                                       {
                                                           Error = "",
                                                           UseOfSiteID = c.UseOfSiteID,
                                                           SiteTVItemID = c.SiteTVItemID,
                                                           SiteTVText = siteTVText,
                                                           SubsectorTVItemID = c.SubsectorTVItemID,
                                                           SubsectorTVText = subsectorTVText,
                                                           SiteType = (SiteTypeEnum)c.SiteType,
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
                                                       }).ToList<UseOfSiteModel>();

            return UseOfSiteModelList;
        }
        public UseOfSiteModel GetUseOfSiteModelExist(UseOfSiteModel useOfSiteModel)
        {
            UseOfSiteModel useOfSiteModelRet = (from c in db.UseOfSites
                                                let siteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                let subsectorTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.SubsectorTVItemID select cl.TVText).FirstOrDefault<string>()
                                                where c.SubsectorTVItemID == useOfSiteModel.SubsectorTVItemID
                                                && c.SiteType == (int)useOfSiteModel.SiteType
                                                && c.SiteTVItemID == useOfSiteModel.SiteTVItemID
                                                && c.StartYear >= useOfSiteModel.StartYear
                                                && c.EndYear <= useOfSiteModel.EndYear
                                                orderby c.UseOfSiteID descending
                                                select new UseOfSiteModel
                                                {
                                                    Error = "",
                                                    UseOfSiteID = c.UseOfSiteID,
                                                    SiteTVItemID = c.SiteTVItemID,
                                                    SiteTVText = siteTVText,
                                                    SubsectorTVItemID = c.SubsectorTVItemID,
                                                    SubsectorTVText = subsectorTVText,
                                                    SiteType = (SiteTypeEnum)c.SiteType,
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
                                                }).FirstOrDefault<UseOfSiteModel>();

            if (useOfSiteModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, 
                    ServiceRes.UseOfSite,
                    ServiceRes.SubsectorTVItemID + "," +
                    ServiceRes.SiteType + "," +
                    ServiceRes.SiteTVItemID + "," +
                    ServiceRes.StartYear + "," +
                    ServiceRes.EndYear,
                    useOfSiteModel.SubsectorTVItemID.ToString() + "," +
                    useOfSiteModel.SiteType.ToString() + "," +
                    useOfSiteModel.SiteTVItemID.ToString() + "," +
                    useOfSiteModel.StartYear + "," +
                    useOfSiteModel.EndYear
                    ));

            return useOfSiteModelRet;
        }
        public UseOfSite GetUseOfSiteWithUseOfSiteIDDB(int UseOfSiteID)
        {
            UseOfSite UseOfSite = (from c in db.UseOfSites
                                   where c.UseOfSiteID == UseOfSiteID
                                   select c).FirstOrDefault<UseOfSite>();

            return UseOfSite;
        }

        // Helper
        public UseOfSiteModel ReturnError(string Error)
        {
            return new UseOfSiteModel() { Error = Error };
        }

        // Post
        public UseOfSiteModel PostAddUseOfSiteDB(UseOfSiteModel useOfSiteModel)
        {
            string retStr = UseOfSiteModelOK(useOfSiteModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            UseOfSiteModel useOfSiteModelExist = GetUseOfSiteModelExist(useOfSiteModel);
            if (string.IsNullOrWhiteSpace(useOfSiteModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.UseOfSite));

            UseOfSite useOfSiteNew = new UseOfSite();
            retStr = FillUseOfSite(useOfSiteNew, useOfSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.UseOfSites.Add(useOfSiteNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("UseOfSites", useOfSiteNew.UseOfSiteID, LogCommandEnum.Add, useOfSiteNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetUseOfSiteModelWithUseOfSiteIDDB(useOfSiteNew.UseOfSiteID);
        }
        public UseOfSiteModel PostDeleteUseOfSiteDB(int UseOfSiteID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            UseOfSite useOfSiteToDelete = GetUseOfSiteWithUseOfSiteIDDB(UseOfSiteID);
            if (useOfSiteToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.UseOfSite));

            using (TransactionScope ts = new TransactionScope())
            {
                db.UseOfSites.Remove(useOfSiteToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("UseOfSites", useOfSiteToDelete.UseOfSiteID, LogCommandEnum.Delete, useOfSiteToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public UseOfSiteModel PostUpdateUseOfSiteDB(UseOfSiteModel useOfSiteModel)
        {
            string retStr = UseOfSiteModelOK(useOfSiteModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            UseOfSite useOfSiteToUpdate = GetUseOfSiteWithUseOfSiteIDDB(useOfSiteModel.UseOfSiteID);
            if (useOfSiteToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.UseOfSite));

            retStr = FillUseOfSite(useOfSiteToUpdate, useOfSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("UseOfSites", useOfSiteToUpdate.UseOfSiteID, LogCommandEnum.Change, useOfSiteToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetUseOfSiteModelWithUseOfSiteIDDB(useOfSiteToUpdate.UseOfSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
