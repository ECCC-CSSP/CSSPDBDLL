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
    public class RatingCurveValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
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
        public string RatingCurveValueModelOK(RatingCurveValueModel ratingCurveValueModel)
        {
            string retStr = FieldCheckNotZeroInt(ratingCurveValueModel.RatingCurveID, ServiceRes.RatingCurveID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(ratingCurveValueModel.StageValue_m, ServiceRes.StageValue_m, -1, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(ratingCurveValueModel.DischargeValue_m3_s, ServiceRes.DischargeValue_m3_s, 0, 100000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillRatingCurveValue(RatingCurveValue ratingCurveValueNew, RatingCurveValueModel ratingCurveValueModel, ContactOK contactOK)
        {
            ratingCurveValueNew.RatingCurveID = ratingCurveValueModel.RatingCurveID;
            ratingCurveValueNew.StageValue_m = ratingCurveValueModel.StageValue_m;
            ratingCurveValueNew.DischargeValue_m3_s = ratingCurveValueModel.DischargeValue_m3_s;
            ratingCurveValueNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                ratingCurveValueNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                ratingCurveValueNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetRatingCurveValueModelCountDB()
        {
            int RatingCurveValueModelCount = (from c in db.RatingCurveValues
                                              select c).Count();

            return RatingCurveValueModelCount;
        }
        public List<RatingCurveValueModel> GetRatingCurveValueModelListWithRatingCurveIDDB(int RatingCurveID)
        {
            List<RatingCurveValueModel> ratingCurveValueModelList = (from c in db.RatingCurveValues
                                                                     where c.RatingCurveID == RatingCurveID
                                                                     orderby c.StageValue_m
                                                                     select new RatingCurveValueModel
                                                                     {
                                                                         Error = "",
                                                                         RatingCurveValueID = c.RatingCurveValueID,
                                                                         RatingCurveID = c.RatingCurveID,
                                                                         StageValue_m = c.StageValue_m,
                                                                         DischargeValue_m3_s = c.DischargeValue_m3_s,
                                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                     }).ToList<RatingCurveValueModel>();

            return ratingCurveValueModelList;
        }
        public RatingCurveValueModel GetRatingCurveValueModelWithRatingCurveValueIDDB(int RatingCurveValueID)
        {
            RatingCurveValueModel ratingCurveValueModel = (from c in db.RatingCurveValues
                                                           where c.RatingCurveValueID == RatingCurveValueID
                                                           select new RatingCurveValueModel
                                                           {
                                                               Error = "",
                                                               RatingCurveValueID = c.RatingCurveValueID,
                                                               RatingCurveID = c.RatingCurveID,
                                                               StageValue_m = c.StageValue_m,
                                                               DischargeValue_m3_s = c.DischargeValue_m3_s,
                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                           }).FirstOrDefault<RatingCurveValueModel>();

            if (ratingCurveValueModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.RatingCurveValue, ServiceRes.RatingCurveValueID, RatingCurveValueID));

            return ratingCurveValueModel;
        }
        public RatingCurveValue GetRatingCurveValueWithRatingCurveValueIDDB(int RatingCurveValueID)
        {
            RatingCurveValue ratingCurveValue = (from c in db.RatingCurveValues
                                                 where c.RatingCurveValueID == RatingCurveValueID
                                                 select c).FirstOrDefault<RatingCurveValue>();

            return ratingCurveValue;
        }
        public RatingCurveValue GetRatingCurveValueExistDB(RatingCurveValueModel ratingCurveValueModel)
        {
            RatingCurveValue ratingCurveValue = (from c in db.RatingCurveValues
                                                 where c.RatingCurveID == ratingCurveValueModel.RatingCurveID
                                                 && c.StageValue_m == ratingCurveValueModel.StageValue_m
                                                 && c.DischargeValue_m3_s == ratingCurveValueModel.DischargeValue_m3_s
                                                 select c).FirstOrDefault<RatingCurveValue>();

            return ratingCurveValue;
        }

        // Helper
        public RatingCurveValueModel ReturnError(string Error)
        {
            return new RatingCurveValueModel() { Error = Error };
        }

        // Post
        public RatingCurveValueModel PostAddRatingCurveValueDB(RatingCurveValueModel ratingCurveValueModel)
        {
            string retStr = RatingCurveValueModelOK(ratingCurveValueModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            RatingCurveValue ratingCurveValueExist = GetRatingCurveValueExistDB(ratingCurveValueModel);
            if (ratingCurveValueExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.RatingCurveValue));

            RatingCurveValue ratingCurveValueNew = new RatingCurveValue();
            retStr = FillRatingCurveValue(ratingCurveValueNew, ratingCurveValueModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.RatingCurveValues.Add(ratingCurveValueNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("RatingCurveValues", ratingCurveValueNew.RatingCurveValueID, LogCommandEnum.Add, ratingCurveValueNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetRatingCurveValueModelWithRatingCurveValueIDDB(ratingCurveValueNew.RatingCurveValueID);
        }
        public RatingCurveValueModel PostDeleteRatingCurveValueDB(int RatingCurveValueID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            RatingCurveValue ratingCurveValueToDelete = GetRatingCurveValueWithRatingCurveValueIDDB(RatingCurveValueID);
            if (ratingCurveValueToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.RatingCurveValue));

            using (TransactionScope ts = new TransactionScope())
            {
                db.RatingCurveValues.Remove(ratingCurveValueToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("RatingCurveValues", ratingCurveValueToDelete.RatingCurveValueID, LogCommandEnum.Delete, ratingCurveValueToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public RatingCurveValueModel PostUpdateRatingCurveValueDB(RatingCurveValueModel ratingCurveValueModel)
        {
            string retStr = RatingCurveValueModelOK(ratingCurveValueModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            RatingCurveValue ratingCurveValueToUpdate = GetRatingCurveValueWithRatingCurveValueIDDB(ratingCurveValueModel.RatingCurveValueID);
            if (ratingCurveValueToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.RatingCurveValue));

            retStr = FillRatingCurveValue(ratingCurveValueToUpdate, ratingCurveValueModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("RatingCurveValues", ratingCurveValueToUpdate.RatingCurveValueID, LogCommandEnum.Change, ratingCurveValueToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetRatingCurveValueModelWithRatingCurveValueIDDB(ratingCurveValueToUpdate.RatingCurveValueID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
