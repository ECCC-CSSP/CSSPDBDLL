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
    public class RatingCurveService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        public HydrometricSiteService _HydrometricSiteService { get; private set; }
        #endregion Properties

        #region Constructors
        public RatingCurveService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
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
        public string RatingCurveModelOK(RatingCurveModel ratingCurveModel)
        {
            string retStr = FieldCheckNotZeroInt(ratingCurveModel.HydrometricSiteID, ServiceRes.HydrometricSiteID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(ratingCurveModel.RatingCurveNumber, ServiceRes.RatingCurveNumber, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillRatingCurve(RatingCurve ratingCurveNew, RatingCurveModel ratingCurveModel, ContactOK contactOK)
        {
            ratingCurveNew.HydrometricSiteID = ratingCurveModel.HydrometricSiteID;
            ratingCurveNew.RatingCurveNumber = ratingCurveModel.RatingCurveNumber;
            ratingCurveNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                ratingCurveNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                ratingCurveNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetRatingCurveModelCountDB()
        {
            int RatingCurveModelCount = (from c in db.RatingCurves
                                         select c).Count();

            return RatingCurveModelCount;
        }
        public List<RatingCurveModel> GetRatingCurveModelListWithHydrometricSiteIDDB(int HydrometricSiteID)
        {
            List<RatingCurveModel> RatingCurveModelList = (from c in db.RatingCurves
                                                           let tvText = (from h in db.HydrometricSites
                                                                         from cl in db.TVItemLanguages
                                                                         where h.HydrometricSiteTVItemID == cl.TVItemID
                                                                         && cl.Language == (int)LanguageRequest 
                                                                         && cl.TVItemID == h.HydrometricSiteTVItemID
                                                                         select cl.TVText).FirstOrDefault<string>()
                                                           where c.HydrometricSiteID == HydrometricSiteID
                                                           orderby c.RatingCurveNumber
                                                           select new RatingCurveModel
                                                           {
                                                               Error = "",
                                                               RatingCurveID = c.RatingCurveID,
                                                               HydrometricSiteID = c.HydrometricSiteID,
                                                               HydrometricSiteTVText = tvText,
                                                               RatingCurveNumber = c.RatingCurveNumber,
                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                           }).ToList<RatingCurveModel>();

            return RatingCurveModelList;
        }
        public RatingCurveModel GetRatingCurveModelWithRatingCurveIDDB(int RatingCurveID)
        {
            RatingCurveModel ratingCurveModel = (from c in db.RatingCurves
                                                 let tvText = (from h in db.HydrometricSites
                                                               from cl in db.TVItemLanguages
                                                               where h.HydrometricSiteTVItemID == cl.TVItemID
                                                               && cl.Language == (int)LanguageRequest
                                                               && cl.TVItemID == h.HydrometricSiteTVItemID
                                                               select cl.TVText).FirstOrDefault<string>()
                                                 where c.RatingCurveID == RatingCurveID
                                                 select new RatingCurveModel
                                                 {
                                                     Error = "",
                                                     RatingCurveID = c.RatingCurveID,
                                                     HydrometricSiteID = c.HydrometricSiteID,
                                                     HydrometricSiteTVText = tvText,
                                                     RatingCurveNumber = c.RatingCurveNumber,
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                 }).FirstOrDefault<RatingCurveModel>();

            if (ratingCurveModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.RatingCurve, ServiceRes.RatingCurveID, RatingCurveID));

            return ratingCurveModel;
        }
        public RatingCurve GetRatingCurveWithRatingCurveIDDB(int RatingCurveID)
        {
            RatingCurve RatingCurve = (from c in db.RatingCurves
                                       where c.RatingCurveID == RatingCurveID
                                       select c).FirstOrDefault<RatingCurve>();

            return RatingCurve;
        }
        public RatingCurve GetRatingCurveExistDB(RatingCurveModel ratingCurveModel)
        {
            RatingCurve ratingCurve = (from c in db.RatingCurves
                                       where c.HydrometricSiteID == ratingCurveModel.HydrometricSiteID
                                       && c.RatingCurveNumber == ratingCurveModel.RatingCurveNumber
                                       select c).FirstOrDefault<RatingCurve>();

            return ratingCurve;
        }

        // Helper
        public RatingCurveModel ReturnError(string Error)
        {
            return new RatingCurveModel() { Error = Error };
        }

        // Post
        public RatingCurveModel PostAddRatingCurveDB(RatingCurveModel ratingCurveModel)
        {
            string retStr = RatingCurveModelOK(ratingCurveModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            HydrometricSiteModel hydrometricSiteModel = _HydrometricSiteService.GetHydrometricSiteModelWithHydrometricSiteIDDB(ratingCurveModel.HydrometricSiteID);
            if (!string.IsNullOrWhiteSpace(hydrometricSiteModel.Error))
                return ReturnError(hydrometricSiteModel.Error);

            RatingCurve ratingCurveExist = GetRatingCurveExistDB(ratingCurveModel);
            if (ratingCurveExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.RatingCurve));

            RatingCurve ratingCurveNew = new RatingCurve();
            retStr = FillRatingCurve(ratingCurveNew, ratingCurveModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.RatingCurves.Add(ratingCurveNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("RatingCurves", ratingCurveNew.RatingCurveID, LogCommandEnum.Add, ratingCurveNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetRatingCurveModelWithRatingCurveIDDB(ratingCurveNew.RatingCurveID);
        }
        public RatingCurveModel PostDeleteRatingCurveDB(int RatingCurveID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            RatingCurve ratingCurveToDelete = GetRatingCurveWithRatingCurveIDDB(RatingCurveID);
            if (ratingCurveToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.RatingCurve));

            using (TransactionScope ts = new TransactionScope())
            {
                db.RatingCurves.Remove(ratingCurveToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("RatingCurves", ratingCurveToDelete.RatingCurveID, LogCommandEnum.Delete, ratingCurveToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public RatingCurveModel PostUpdateRatingCurveDB(RatingCurveModel ratingCurveModel)
        {
            string retStr = RatingCurveModelOK(ratingCurveModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            RatingCurve ratingCurveToUpdate = GetRatingCurveWithRatingCurveIDDB(ratingCurveModel.RatingCurveID);
            if (ratingCurveToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.RatingCurve));

            retStr = FillRatingCurve(ratingCurveToUpdate, ratingCurveModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("RatingCurves", ratingCurveToUpdate.RatingCurveID, LogCommandEnum.Change, ratingCurveToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetRatingCurveModelWithRatingCurveIDDB(ratingCurveToUpdate.RatingCurveID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
