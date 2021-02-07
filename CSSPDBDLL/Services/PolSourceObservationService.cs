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
    public class PolSourceObservationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public PolSourceObservationIssueService _PolSourceObservationIssueService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _PolSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, User);
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
        public string PolSourceObservationModelOK(PolSourceObservationModel polSourceObservationModel)
        {
            string retStr = FieldCheckNotZeroInt(polSourceObservationModel.PolSourceSiteID, ServiceRes.PolSourceSiteID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(polSourceObservationModel.ObservationDate_Local, ServiceRes.ObservationDate_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(polSourceObservationModel.ContactTVItemID, ServiceRes.ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(polSourceObservationModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillPolSourceObservation(PolSourceObservation polSourceObservation, PolSourceObservationModel polSourceObservationModel, ContactOK contactOK)
        {
            polSourceObservation.DBCommand = (int)polSourceObservationModel.DBCommand;
            polSourceObservation.PolSourceSiteID = polSourceObservationModel.PolSourceSiteID;
            polSourceObservation.ObservationDate_Local = polSourceObservationModel.ObservationDate_Local;
            polSourceObservation.Observation_ToBeDeleted = polSourceObservationModel.Observation_ToBeDeleted;
            polSourceObservation.ContactTVItemID = polSourceObservationModel.ContactTVItemID;
            polSourceObservation.DesktopReviewed = polSourceObservationModel.DesktopReviewed;
            polSourceObservation.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                polSourceObservation.LastUpdateContactTVItemID = 2;
            }
            else
            {
                polSourceObservation.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetPolSourceObservationModelCountDB()
        {
            int PolSourceObservationModelCount = (from c in db.PolSourceObservations
                                                  select c).Count();

            return PolSourceObservationModelCount;
        }
        public List<PolSourceObservationModel> GetPolSourceObservationModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<PolSourceObservationModel> PolSourceObservationModelList = (from pss in db.PolSourceSites
                                                                             from pso in db.PolSourceObservations
                                                                             from t in db.TVItems
                                                                             where pss.PolSourceSiteID == pso.PolSourceSiteID
                                                                             && pss.PolSourceSiteTVItemID == t.TVItemID
                                                                             && t.ParentID == SubsectorTVItemID
                                                                             orderby pso.ObservationDate_Local descending
                                                                             select new PolSourceObservationModel
                                                                             {
                                                                                 Error = "",
                                                                                 PolSourceObservationID = pso.PolSourceObservationID,
                                                                                 DBCommand = (DBCommandEnum)pso.DBCommand,
                                                                                 PolSourceSiteID = pso.PolSourceSiteID,
                                                                                 PolSourceSiteTVItemID = t.TVItemID,
                                                                                 PolSourceSiteTVText = "",
                                                                                 ObservationDate_Local = pso.ObservationDate_Local,
                                                                                 ContactTVItemID = pso.ContactTVItemID,
                                                                                 DesktopReviewed = pso.DesktopReviewed,
                                                                                 ContactTVText = "",
                                                                                 Observation_ToBeDeleted = pso.Observation_ToBeDeleted,
                                                                                 LastUpdateDate_UTC = pso.LastUpdateDate_UTC,
                                                                                 LastUpdateContactTVItemID = pso.LastUpdateContactTVItemID,
                                                                             }).ToList<PolSourceObservationModel>();

            return PolSourceObservationModelList;
        }
        public List<PolSourceObservationModel> GetPolSourceObservationModelListWithPolSourceSiteIDDB(int PolSourceSiteID)
        {
            List<PolSourceObservationModel> PolSourceObservationModelList = (from c in db.PolSourceObservations
                                                                             let PolSourceSiteTVItemID = (from p in db.PolSourceSites where p.PolSourceSiteID == PolSourceSiteID select p.PolSourceSiteTVItemID).FirstOrDefault()
                                                                             let tvText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                             let contactTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.ContactTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                             where c.PolSourceSiteID == PolSourceSiteID
                                                                             orderby c.ObservationDate_Local descending
                                                                             select new PolSourceObservationModel
                                                                             {
                                                                                 Error = "",
                                                                                 PolSourceObservationID = c.PolSourceObservationID,
                                                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                                                 PolSourceSiteID = c.PolSourceSiteID,
                                                                                 PolSourceSiteTVItemID = PolSourceSiteTVItemID,
                                                                                 PolSourceSiteTVText = tvText,
                                                                                 ObservationDate_Local = c.ObservationDate_Local,
                                                                                 ContactTVItemID = c.ContactTVItemID,
                                                                                 DesktopReviewed = c.DesktopReviewed,
                                                                                 ContactTVText = contactTVText,
                                                                                 Observation_ToBeDeleted = c.Observation_ToBeDeleted,
                                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                             }).ToList<PolSourceObservationModel>();

            return PolSourceObservationModelList;
        }
        public PolSourceObservationModel GetPolSourceObservationModelLatestWithPolSourceSiteIDDB(int PolSourceSiteID)
        {
            PolSourceObservationModel polSourceObservationModel = (from c in db.PolSourceObservations
                                                                   let PolSourceSiteTVItemID = (from p in db.PolSourceSites where p.PolSourceSiteID == PolSourceSiteID select p.PolSourceSiteTVItemID).FirstOrDefault()
                                                                   let tvText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                   let contactTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.ContactTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                   where c.PolSourceSiteID == PolSourceSiteID
                                                                   orderby c.ObservationDate_Local descending
                                                                   select new PolSourceObservationModel
                                                                   {
                                                                       Error = "",
                                                                       PolSourceObservationID = c.PolSourceObservationID,
                                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                                       PolSourceSiteID = c.PolSourceSiteID,
                                                                       PolSourceSiteTVItemID = PolSourceSiteTVItemID,
                                                                       PolSourceSiteTVText = tvText,
                                                                       ObservationDate_Local = c.ObservationDate_Local,
                                                                       ContactTVItemID = c.ContactTVItemID,
                                                                       DesktopReviewed = c.DesktopReviewed,
                                                                       ContactTVText = contactTVText,
                                                                       Observation_ToBeDeleted = c.Observation_ToBeDeleted,
                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                   }).FirstOrDefault<PolSourceObservationModel>();

            if (polSourceObservationModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservation, ServiceRes.PolSourceSiteID, PolSourceSiteID));

            return polSourceObservationModel;
        }
        public PolSourceObservationModel GetPolSourceObservationModelWithPolSourceObservationIDDB(int PolSourceObservationID)
        {
            PolSourceObservationModel polSourceObservationModel = (from c in db.PolSourceObservations
                                                                   let PolSourceSiteTVItemID = (from p in db.PolSourceSites where p.PolSourceSiteID == c.PolSourceSiteID select p.PolSourceSiteTVItemID).FirstOrDefault()
                                                                   let tvText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                   let contactTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.ContactTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                   where c.PolSourceObservationID == PolSourceObservationID
                                                                   select new PolSourceObservationModel
                                                                   {
                                                                       Error = "",
                                                                       PolSourceObservationID = c.PolSourceObservationID,
                                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                                       PolSourceSiteID = c.PolSourceSiteID,
                                                                       PolSourceSiteTVItemID = PolSourceSiteTVItemID,
                                                                       PolSourceSiteTVText = tvText,
                                                                       ObservationDate_Local = c.ObservationDate_Local,
                                                                       ContactTVItemID = c.ContactTVItemID,
                                                                       DesktopReviewed = c.DesktopReviewed,
                                                                       ContactTVText = contactTVText,
                                                                       Observation_ToBeDeleted = c.Observation_ToBeDeleted,
                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                   }).FirstOrDefault<PolSourceObservationModel>();

            if (polSourceObservationModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservation, ServiceRes.PolSourceObservationID, PolSourceObservationID));

            return polSourceObservationModel;
        }
        public PolSourceObservationModel GetPolSourceObservationModelFirstWithContactTVItemIDDB(int ContactTVItemID)
        {
            PolSourceObservationModel polSourceObservationModelFirst = (from c in db.PolSourceObservations
                                                                        let PolSourceSiteTVItemID = (from p in db.PolSourceSites where p.PolSourceSiteID == c.PolSourceSiteID select p.PolSourceSiteTVItemID).FirstOrDefault()
                                                                        let tvText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                        let contactTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.ContactTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                        where c.ContactTVItemID == ContactTVItemID
                                                                        select new PolSourceObservationModel
                                                                        {
                                                                            Error = "",
                                                                            PolSourceObservationID = c.PolSourceObservationID,
                                                                            DBCommand = (DBCommandEnum)c.DBCommand,
                                                                            PolSourceSiteID = c.PolSourceSiteID,
                                                                            PolSourceSiteTVItemID = PolSourceSiteTVItemID,
                                                                            PolSourceSiteTVText = tvText,
                                                                            ObservationDate_Local = c.ObservationDate_Local,
                                                                            ContactTVItemID = c.ContactTVItemID,
                                                                            DesktopReviewed = c.DesktopReviewed,
                                                                            ContactTVText = contactTVText,
                                                                            Observation_ToBeDeleted = c.Observation_ToBeDeleted,
                                                                            LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                            LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                        }).FirstOrDefault<PolSourceObservationModel>();

            if (polSourceObservationModelFirst == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservation, ServiceRes.ContactTVItemID, ContactTVItemID));

            return polSourceObservationModelFirst;
        }
        public List<PolSourceObservationModel> GetPolSourceObservationModelListWithContactTVItemIDDB(int ContactTVItemID)
        {
            List<PolSourceObservationModel> polSourceObservationModelList = (from c in db.PolSourceObservations
                                                                             let PolSourceSiteTVItemID = (from p in db.PolSourceSites where p.PolSourceSiteID == c.PolSourceSiteID select p.PolSourceSiteTVItemID).FirstOrDefault()
                                                                             let tvText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                             let contactTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.ContactTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                             where c.ContactTVItemID == ContactTVItemID
                                                                             select new PolSourceObservationModel
                                                                             {
                                                                                 Error = "",
                                                                                 PolSourceObservationID = c.PolSourceObservationID,
                                                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                                                 PolSourceSiteID = c.PolSourceSiteID,
                                                                                 PolSourceSiteTVItemID = PolSourceSiteTVItemID,
                                                                                 PolSourceSiteTVText = tvText,
                                                                                 ObservationDate_Local = c.ObservationDate_Local,
                                                                                 ContactTVItemID = c.ContactTVItemID,
                                                                                 DesktopReviewed = c.DesktopReviewed,
                                                                                 ContactTVText = contactTVText,
                                                                                 Observation_ToBeDeleted = c.Observation_ToBeDeleted,
                                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                             }).ToList<PolSourceObservationModel>();

            return polSourceObservationModelList;
        }
        public PolSourceObservation GetPolSourceObservationWithPolSourceObservationIDDB(int PolSourceObservationID)
        {
            PolSourceObservation PolSourceObservation = (from c in db.PolSourceObservations
                                                         where c.PolSourceObservationID == PolSourceObservationID
                                                         select c).FirstOrDefault<PolSourceObservation>();

            return PolSourceObservation;
        }
        public PolSourceObservationModel GetPolSourceObservationModelExistDB(PolSourceObservationModel polSourceObservationModel)
        {
            PolSourceObservationModel polSourceObservationModelRet = (from c in db.PolSourceObservations
                                                                      let PolSourceSiteTVItemID = (from p in db.PolSourceSites where p.PolSourceSiteID == c.PolSourceSiteID select p.PolSourceSiteTVItemID).FirstOrDefault()
                                                                      let tvText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                      let contactTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.ContactTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                      where c.PolSourceSiteID == polSourceObservationModel.PolSourceSiteID
                                                                      && c.ObservationDate_Local == polSourceObservationModel.ObservationDate_Local
                                                                      select new PolSourceObservationModel
                                                                      {
                                                                          Error = "",
                                                                          PolSourceObservationID = c.PolSourceObservationID,
                                                                          DBCommand = (DBCommandEnum)c.DBCommand,
                                                                          PolSourceSiteID = c.PolSourceSiteID,
                                                                          PolSourceSiteTVItemID = PolSourceSiteTVItemID,
                                                                          PolSourceSiteTVText = tvText,
                                                                          ObservationDate_Local = c.ObservationDate_Local,
                                                                          ContactTVItemID = c.ContactTVItemID,
                                                                          DesktopReviewed = c.DesktopReviewed,
                                                                          ContactTVText = contactTVText,
                                                                          Observation_ToBeDeleted = c.Observation_ToBeDeleted,
                                                                          LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                          LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                      }).FirstOrDefault<PolSourceObservationModel>();

            if (polSourceObservationModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservation, ServiceRes.PolSourceSiteTVItemID + "," + ServiceRes.ObservationDate_Local, polSourceObservationModel.PolSourceSiteID + "," + polSourceObservationModel.ObservationDate_Local));

            return polSourceObservationModelRet;
        }
        public PolSourceObservation GetPolSourceObservationExistDB(PolSourceObservationModel polSourceObservationModel)
        {
            PolSourceObservation polSourceObservation = (from c in db.PolSourceObservations
                                                         where c.PolSourceSiteID == polSourceObservationModel.PolSourceSiteID
                                                         && c.ObservationDate_Local == polSourceObservationModel.ObservationDate_Local
                                                         select c).FirstOrDefault<PolSourceObservation>();

            return polSourceObservation;
        }
        public int GetSiteWithPolSourceSiteID(int PolSourceSiteID)
        {
            int? Site = (from c in db.PolSourceSites
                         where c.PolSourceSiteID == PolSourceSiteID
                         select c.Site).FirstOrDefault();

            if (Site == null)
                return 0;

            return (int)Site;
        }
        // Helper
        public PolSourceObservationModel ReturnError(string Error)
        {
            return new PolSourceObservationModel() { Error = Error };
        }

        // Post
        public PolSourceObservationModel PolSourceObservationAddOrModifyDB(FormCollection fc)
        {
            int PolSourceSiteID = 0;
            int PolSourceSiteTVItemID = 0;
            int PolSourceObservationID = 0;
            int Year = 0;
            int Month = 0;
            int Day = 0;
            bool DesktopReviewed = false;

            DateTime ObsDate = new DateTime(1900, 1, 1);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            if (string.IsNullOrWhiteSpace(fc["PolSourceSiteTVItemID"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteTVItemID));

            int.TryParse(fc["PolSourceSiteTVItemID"], out PolSourceSiteTVItemID);
            if (PolSourceSiteTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteTVItemID));

            TVItemModel tvItemModelPolSourcSite = _TVItemService.GetTVItemModelWithTVItemIDDB(PolSourceSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelPolSourcSite.Error))
                return ReturnError(tvItemModelPolSourcSite.Error);

            if (string.IsNullOrWhiteSpace(fc["PolSourceSiteID"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteID));

            int.TryParse(fc["PolSourceSiteID"], out PolSourceSiteID);
            if (PolSourceSiteID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteID));

            if (string.IsNullOrWhiteSpace(fc["PolSourceObservationID"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceObservationID));

            int.TryParse(fc["PolSourceObservationID"], out PolSourceObservationID);

            // PolSourceObservationID == 0 ==> Add 
            // PolSourceObservationID > 0 ==> Modify

            PolSourceObservationModel polSourceObservationModelToAddOrChange = new PolSourceObservationModel();
            if (PolSourceObservationID > 0)
            {
                polSourceObservationModelToAddOrChange = GetPolSourceObservationModelWithPolSourceObservationIDDB(PolSourceObservationID);
                if (!string.IsNullOrWhiteSpace(polSourceObservationModelToAddOrChange.Error))
                    return ReturnError(polSourceObservationModelToAddOrChange.Error);
            }

            int.TryParse(fc["ObsYear"], out Year);
            if (Year == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Year));

            int.TryParse(fc["ObsMonth"], out Month);
            if (Month == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Month));

            int.TryParse(fc["ObsDay"], out Day);
            if (Day == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Day));

            ObsDate = new DateTime(Year, Month, Day);

            if (fc["DesktopReviewed"] != null)
            {
                DesktopReviewed = true;
            }

            //PolSourceObservationModel polSourceObservationModelRet = new PolSourceObservationModel();
            using (TransactionScope ts = new TransactionScope())
            {
                PolSourceObservationModel polSourceObservationModelNew = new PolSourceObservationModel()
                {
                    DBCommand = DBCommandEnum.Original,
                    PolSourceSiteID = PolSourceSiteID,
                    ObservationDate_Local = ObsDate,
                    ContactTVItemID = contactOK.ContactTVItemID,
                    DesktopReviewed = DesktopReviewed,
                    Observation_ToBeDeleted = "",
                };

                if (PolSourceObservationID == 0) // new
                {
                    polSourceObservationModelToAddOrChange = PostAddPolSourceObservationDB(polSourceObservationModelNew);
                    if (!string.IsNullOrWhiteSpace(polSourceObservationModelToAddOrChange.Error))
                        return ReturnError(polSourceObservationModelToAddOrChange.Error);

                    string ObservationInfo = ((int)PolSourceObsInfoEnum.SourceStart).ToString() + ",";
                    List<int> obsIntList = ObservationInfo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                    PolSourceObservationIssueModel polSourceObservationIssueModelNew = new PolSourceObservationIssueModel();
                    polSourceObservationIssueModelNew.DBCommand = DBCommandEnum.Original;
                    polSourceObservationIssueModelNew.PolSourceObservationID = polSourceObservationModelToAddOrChange.PolSourceObservationID;
                    polSourceObservationIssueModelNew.ObservationInfo = ObservationInfo;
                    polSourceObservationIssueModelNew.Ordinal = 0;

                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = _PolSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelNew);
                    if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
                        return ReturnError(polSourceObservationIssueModelRet.Error);

                    // doing the other language
                    foreach (LanguageEnum lang in LanguageListAllowable.Where(c => c != LanguageRequest))
                    {
                        TVItemService tvItemService = new TVItemService(lang, _PolSourceObservationIssueService.User);
                        Thread.CurrentThread.CurrentCulture = new CultureInfo(lang + "-CA");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang + "-CA");

                        ObservationInfo = ((int)PolSourceObsInfoEnum.SourceStart).ToString() + ",";
                        string ObservationLanguageTVText = ServiceRes.Error;
                        string TVText = _BaseEnumService.GetEnumText_PolSourceObsInfoTextEnum(PolSourceObsInfoEnum.Error); ;

                        TVText = (string.IsNullOrWhiteSpace(TVText) ? ServiceRes.Error : TVText);

                        int Site = GetSiteWithPolSourceSiteID(PolSourceSiteID);

                        TVText = TVText + " - " + "000000".Substring(0, "000000".Length - Site.ToString().Length) + Site.ToString();

                        TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel();
                        tvItemLanguageModel.DBCommand = DBCommandEnum.Original;
                        tvItemLanguageModel.Language = lang;
                        tvItemLanguageModel.TVText = TVText;
                        tvItemLanguageModel.TVItemID = PolSourceSiteID;

                        TVItemLanguageModel tvItemLanguageModelRet = tvItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                            return ReturnError(tvItemLanguageModelRet.Error);

                        Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageRequest + "-CA");
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageRequest + "-CA");
                    }
                }
                else
                {
                    polSourceObservationModelNew.PolSourceObservationID = polSourceObservationModelToAddOrChange.PolSourceObservationID;
                    polSourceObservationModelToAddOrChange = PostUpdatePolSourceObservationDB(polSourceObservationModelNew);
                    if (!string.IsNullOrWhiteSpace(polSourceObservationModelToAddOrChange.Error))
                        return ReturnError(polSourceObservationModelToAddOrChange.Error);
                }

                ts.Complete();
            }
            return polSourceObservationModelToAddOrChange;
        }
        public PolSourceObservationModel PolSourceObservationCopyDB(int PolSourceObservationID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceObservationModel polSourceObservationModelToCopy = GetPolSourceObservationModelWithPolSourceObservationIDDB(PolSourceObservationID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModelToCopy.Error))
                return ReturnError(polSourceObservationModelToCopy.Error);

            List<PolSourceObservationIssueModel> polSourceObservationIssueModelList = _PolSourceObservationIssueService.GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(PolSourceObservationID);
            if (polSourceObservationIssueModelList.Count == 0)
                return ReturnError(string.Format(ServiceRes._ShouldBeMoreThan_, ServiceRes.PolSourceObservationIssue, 0.ToString()));

            PolSourceObservationModel polSourceObservationModelRet = new PolSourceObservationModel();
            using (TransactionScope ts = new TransactionScope())
            {
                polSourceObservationModelToCopy.PolSourceObservationID = 0;
                polSourceObservationModelToCopy.DBCommand = DBCommandEnum.Original;
                polSourceObservationModelToCopy.ObservationDate_Local = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                polSourceObservationModelRet = PostAddPolSourceObservationDB(polSourceObservationModelToCopy);
                if (!string.IsNullOrWhiteSpace(polSourceObservationModelRet.Error))
                    return ReturnError(polSourceObservationModelRet.Error);

                foreach (PolSourceObservationIssueModel polSourceObservationIssueModel in polSourceObservationIssueModelList)
                {
                    polSourceObservationIssueModel.DBCommand = DBCommandEnum.Original;
                    polSourceObservationIssueModel.PolSourceObservationID = polSourceObservationModelRet.PolSourceObservationID;
                    polSourceObservationIssueModel.PolSourceObservationIssueID = 0;

                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = _PolSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModel);
                    if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
                        return ReturnError(polSourceObservationIssueModelRet.Error);
                }

                ts.Complete();
            }
            return polSourceObservationModelRet;
        }
        public PolSourceObservationModel PostAddPolSourceObservationDB(PolSourceObservationModel polSourceObservationModel)
        {
            string retStr = PolSourceObservationModelOK(polSourceObservationModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, User);
            PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteIDDB(polSourceObservationModel.PolSourceSiteID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
                return ReturnError(polSourceSiteModel.Error);

            PolSourceObservation polSourceObservationExist = GetPolSourceObservationExistDB(polSourceObservationModel);
            if (polSourceObservationExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.PolSourceObservation));

            PolSourceObservation polSourceObservationNew = new PolSourceObservation();
            retStr = FillPolSourceObservation(polSourceObservationNew, polSourceObservationModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.PolSourceObservations.Add(polSourceObservationNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceObservations", polSourceObservationNew.PolSourceObservationID, LogCommandEnum.Add, polSourceObservationNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetPolSourceObservationModelWithPolSourceObservationIDDB(polSourceObservationNew.PolSourceObservationID);
        }
        public PolSourceObservationModel PostDeletePolSourceObservationDB(int PolSourceObservationID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceObservation polSourceObservationToDelete = GetPolSourceObservationWithPolSourceObservationIDDB(PolSourceObservationID);
            if (polSourceObservationToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.PolSourceObservation));

            // should not be able to delete the last observation
            List<PolSourceObservationModel> polSourceObservationModelList = GetPolSourceObservationModelListWithPolSourceSiteIDDB(polSourceObservationToDelete.PolSourceSiteID);
            if (polSourceObservationModelList.Count < 2)
                return ReturnError(ServiceRes.ShouldNotDeleteTheLastObservation);

            using (TransactionScope ts = new TransactionScope())
            {
                db.PolSourceObservations.Remove(polSourceObservationToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceObservations", polSourceObservationToDelete.PolSourceObservationID, LogCommandEnum.Delete, polSourceObservationToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public PolSourceObservationModel PostUpdatePolSourceObservationDB(PolSourceObservationModel polSourceObservationModel)
        {
            string retStr = PolSourceObservationModelOK(polSourceObservationModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceObservation polSourceObservationToUpdate = GetPolSourceObservationWithPolSourceObservationIDDB(polSourceObservationModel.PolSourceObservationID);
            if (polSourceObservationToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.PolSourceObservation));

            retStr = FillPolSourceObservation(polSourceObservationToUpdate, polSourceObservationModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceObservations", polSourceObservationToUpdate.PolSourceObservationID, LogCommandEnum.Change, polSourceObservationToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetPolSourceObservationModelWithPolSourceObservationIDDB(polSourceObservationToUpdate.PolSourceObservationID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}