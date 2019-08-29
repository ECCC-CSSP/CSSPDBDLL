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

namespace CSSPDBDLL.Services
{
    public class MWQMSitePolSourceSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public MWQMSitePolSourceSiteService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
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
        public string MWQMSitePolSourceSiteModelOK(MWQMSitePolSourceSiteModel MWQMSitePolSourceSiteModel)
        {
            string retStr = FieldCheckNotZeroInt(MWQMSitePolSourceSiteModel.MWQMSiteTVItemID, ServiceRes.MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(MWQMSitePolSourceSiteModel.PolSourceSiteTVItemID, ServiceRes.PolSourceSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TVTypeOK(MWQMSitePolSourceSiteModel.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(MWQMSitePolSourceSiteModel.LinkReasons, ServiceRes.LinkReasons, 4000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMWQMSitePolSourceSite(MWQMSitePolSourceSite MWQMSitePolSourceSite, MWQMSitePolSourceSiteModel MWQMSitePolSourceSiteModel, ContactOK contactOK)
        {
            MWQMSitePolSourceSite.MWQMSiteTVItemID = MWQMSitePolSourceSiteModel.MWQMSiteTVItemID;
            MWQMSitePolSourceSite.PolSourceSiteTVItemID = MWQMSitePolSourceSiteModel.PolSourceSiteTVItemID;
            MWQMSitePolSourceSite.TVType = (int)MWQMSitePolSourceSiteModel.TVType;
            MWQMSitePolSourceSite.LinkReasons = MWQMSitePolSourceSiteModel.LinkReasons;
            MWQMSitePolSourceSite.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                MWQMSitePolSourceSite.LastUpdateContactTVItemID = 2;
            }
            else
            {
                MWQMSitePolSourceSite.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMWQMSitePolSourceSiteModelCountDB()
        {
            int MWQMSitePolSourceSiteModelCount = (from c in db.MWQMSitePolSourceSites
                                                   select c).Count();

            return MWQMSitePolSourceSiteModelCount;
        }
        public MWQMSitePolSourceSiteModel GetMWQMSitePolSourceSiteModelWithMWQMSitePolSourceSiteIDDB(int MWQMSitePolSourceSiteID)
        {
            MWQMSitePolSourceSiteModel mwqmSitePolSourceSiteModel = (from c in db.MWQMSitePolSourceSites
                                                                     let MWQMSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                     let PolSourceSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                     where c.MWQMSitePolSourceSiteID == MWQMSitePolSourceSiteID
                                                                     select new MWQMSitePolSourceSiteModel
                                                                     {
                                                                         Error = "",
                                                                         MWQMSitePolSourceSiteID = c.MWQMSitePolSourceSiteID,
                                                                         MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                         MWQMSiteTVText = MWQMSiteTVText,
                                                                         PolSourceSiteTVText = PolSourceSiteTVText,
                                                                         PolSourceSiteTVItemID = c.PolSourceSiteTVItemID,
                                                                         TVType = (TVTypeEnum)c.TVType,
                                                                         LinkReasons = c.LinkReasons,
                                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                     }).FirstOrDefault<MWQMSitePolSourceSiteModel>();

            if (mwqmSitePolSourceSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSitePolSourceSite, ServiceRes.MWQMSitePolSourceSiteID, MWQMSitePolSourceSiteID));

            return mwqmSitePolSourceSiteModel;
        }
        public List<MWQMSitePolSourceSiteModel> GetMWQMSitePolSourceSiteModelListWithMWQMSiteTVItemIDDB(int MWQMSiteTVItemID, TVTypeEnum tvType)
        {
            List<MWQMSitePolSourceSiteModel> mwqmSitePolSourceSiteModelList = (from c in db.MWQMSitePolSourceSites
                                                                               let MWQMSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                               let PolSourceSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                               where c.MWQMSiteTVItemID == MWQMSiteTVItemID
                                                                               && c.TVType == (int)tvType
                                                                               select new MWQMSitePolSourceSiteModel
                                                                               {
                                                                                   Error = "",
                                                                                   MWQMSitePolSourceSiteID = c.MWQMSitePolSourceSiteID,
                                                                                   MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                                   MWQMSiteTVText = MWQMSiteTVText,
                                                                                   PolSourceSiteTVText = PolSourceSiteTVText,
                                                                                   PolSourceSiteTVItemID = c.PolSourceSiteTVItemID,
                                                                                   TVType = (TVTypeEnum)c.TVType,
                                                                                   LinkReasons = c.LinkReasons,
                                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                               }).ToList<MWQMSitePolSourceSiteModel>();

            return mwqmSitePolSourceSiteModelList;
        }
        public List<MWQMSitePolSourceSiteModel> GetMWQMSitePolSourceSiteModelListWithPolSourceSiteTVItemIDDB(int PolSourceSiteTVItemID)
        {
            List<MWQMSitePolSourceSiteModel> mwqmSitePolSourceSiteModelList = (from c in db.MWQMSitePolSourceSites
                                                                               let MWQMSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                               let PolSourceSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                               where c.PolSourceSiteTVItemID == PolSourceSiteTVItemID
                                                                               select new MWQMSitePolSourceSiteModel
                                                                               {
                                                                                   Error = "",
                                                                                   MWQMSitePolSourceSiteID = c.MWQMSitePolSourceSiteID,
                                                                                   MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                                   MWQMSiteTVText = MWQMSiteTVText,
                                                                                   PolSourceSiteTVText = PolSourceSiteTVText,
                                                                                   PolSourceSiteTVItemID = c.PolSourceSiteTVItemID,
                                                                                   TVType = (TVTypeEnum)c.TVType,
                                                                                   LinkReasons = c.LinkReasons,
                                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                               }).ToList<MWQMSitePolSourceSiteModel>();

            return mwqmSitePolSourceSiteModelList;
        }
        public MWQMSitePolSourceSiteModel GetMWQMSitePolSourceSiteModelWithMWQMSiteTVItemIDAndPolSourceSiteTVItemIDDB(int MWQMSiteTVItemID, int PolSourceSiteTVItemID)
        {
            MWQMSitePolSourceSiteModel mwqmSitePolSourceSiteModel = (from c in db.MWQMSitePolSourceSites
                                                                     let MWQMSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                     let PolSourceSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                     where c.MWQMSiteTVItemID == MWQMSiteTVItemID
                                                                     && c.PolSourceSiteTVItemID == PolSourceSiteTVItemID
                                                                     select new MWQMSitePolSourceSiteModel
                                                                     {
                                                                         Error = "",
                                                                         MWQMSitePolSourceSiteID = c.MWQMSitePolSourceSiteID,
                                                                         MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                         MWQMSiteTVText = MWQMSiteTVText,
                                                                         PolSourceSiteTVText = PolSourceSiteTVText,
                                                                         PolSourceSiteTVItemID = c.PolSourceSiteTVItemID,
                                                                         TVType = (TVTypeEnum)c.TVType,
                                                                         LinkReasons = c.LinkReasons,
                                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                     }).FirstOrDefault<MWQMSitePolSourceSiteModel>();

            if (mwqmSitePolSourceSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSitePolSourceSite, ServiceRes.MWQMSiteTVItemID + "," + ServiceRes.PolSourceSiteTVItemID, MWQMSiteTVItemID.ToString() + "," + PolSourceSiteTVItemID.ToString()));

            return mwqmSitePolSourceSiteModel;
        }
        public MWQMSitePolSourceSite GetMWQMSitePolSourceSiteWithMWQMSitePolSourceSiteIDDB(int MWQMSitePolSourceSiteID)
        {
            MWQMSitePolSourceSite mwqmSitePolSourceSite = (from c in db.MWQMSitePolSourceSites
                                                                     let MWQMSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                     let PolSourceSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.PolSourceSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                     where c.MWQMSitePolSourceSiteID == MWQMSitePolSourceSiteID
                                                                     select c).FirstOrDefault<MWQMSitePolSourceSite>();

            return mwqmSitePolSourceSite;
        }

        // Helper
        public MWQMSitePolSourceSiteModel ReturnError(string Error)
        {
            return new MWQMSitePolSourceSiteModel() { Error = Error };
        }

        // Post
        public MWQMSitePolSourceSiteModel PostAddMWQMSitePolSourceSiteDB(MWQMSitePolSourceSiteModel MWQMSitePolSourceSiteModel)
        {
            string retStr = MWQMSitePolSourceSiteModelOK(MWQMSitePolSourceSiteModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(MWQMSitePolSourceSiteModel.MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnError(tvItemModelExist.Error);

            TVItemModel tvItemModelExist2 = _TVItemService.GetTVItemModelWithTVItemIDDB(MWQMSitePolSourceSiteModel.PolSourceSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist2.Error))
                return ReturnError(tvItemModelExist2.Error);

            MWQMSitePolSourceSite MWQMSitePolSourceSiteNew = new MWQMSitePolSourceSite();
            retStr = FillMWQMSitePolSourceSite(MWQMSitePolSourceSiteNew, MWQMSitePolSourceSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSitePolSourceSites.Add(MWQMSitePolSourceSiteNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSitePolSourceSites", MWQMSitePolSourceSiteNew.MWQMSitePolSourceSiteID, LogCommandEnum.Add, MWQMSitePolSourceSiteNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMSitePolSourceSiteModelWithMWQMSitePolSourceSiteIDDB(MWQMSitePolSourceSiteNew.MWQMSitePolSourceSiteID);
        }
        public MWQMSitePolSourceSiteModel PostDeleteMWQMSitePolSourceSiteDB(int MWQMSitePolSourceSiteID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSitePolSourceSite MWQMSitePolSourceSiteToDelete = GetMWQMSitePolSourceSiteWithMWQMSitePolSourceSiteIDDB(MWQMSitePolSourceSiteID);
            if (MWQMSitePolSourceSiteToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMSitePolSourceSite));

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSitePolSourceSites.Remove(MWQMSitePolSourceSiteToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSitePolSourceSites", MWQMSitePolSourceSiteToDelete.MWQMSitePolSourceSiteID, LogCommandEnum.Delete, MWQMSitePolSourceSiteToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public MWQMSitePolSourceSiteModel PostUpdateMWQMSitePolSourceSiteDB(MWQMSitePolSourceSiteModel MWQMSitePolSourceSiteModel)
        {
            string retStr = MWQMSitePolSourceSiteModelOK(MWQMSitePolSourceSiteModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSitePolSourceSite MWQMSitePolSourceSiteToUpdate = GetMWQMSitePolSourceSiteWithMWQMSitePolSourceSiteIDDB(MWQMSitePolSourceSiteModel.MWQMSitePolSourceSiteID);
            if (MWQMSitePolSourceSiteToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSitePolSourceSite));

            retStr = FillMWQMSitePolSourceSite(MWQMSitePolSourceSiteToUpdate, MWQMSitePolSourceSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSitePolSourceSites", MWQMSitePolSourceSiteToUpdate.MWQMSitePolSourceSiteID, LogCommandEnum.Change, MWQMSitePolSourceSiteToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMSitePolSourceSiteModelWithMWQMSitePolSourceSiteIDDB(MWQMSitePolSourceSiteToUpdate.MWQMSitePolSourceSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}