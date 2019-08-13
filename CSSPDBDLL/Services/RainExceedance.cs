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
        public HydrometricSiteService _HydrometricSiteService { get; private set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string RainExceedanceModelOK(RainExceedanceModel rainExceedanceModel)
        {
            string retStr = FieldCheckNotZeroInt(rainExceedanceModel.RainExceedanceTVItemID, ServiceRes.RainExceedanceTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (rainExceedanceModel.StartMonth != null)
            {
                if (rainExceedanceModel.StartMonth < 1 || rainExceedanceModel.StartMonth > 12)
                {
                    return string.Format(ServiceRes.PleaseEnterValidFor_, ServiceRes.StartMonth);
                }
            }

            if (rainExceedanceModel.StartDay != null)
            {
                if (rainExceedanceModel.StartDay < 1 || rainExceedanceModel.StartDay > 31)
                {
                    return string.Format(ServiceRes.PleaseEnterValidFor_, ServiceRes.StartDay);
                }
            }

            if (rainExceedanceModel.EndMonth != null)
            {
                if (rainExceedanceModel.EndMonth < 1 || rainExceedanceModel.EndMonth > 12)
                {
                    return string.Format(ServiceRes.PleaseEnterValidFor_, ServiceRes.EndMonth);
                }
            }

            if (rainExceedanceModel.EndDay != null)
            {
                if (rainExceedanceModel.EndDay < 1 || rainExceedanceModel.EndDay > 31)
                {
                    return string.Format(ServiceRes.PleaseEnterValidFor_, ServiceRes.EndDay);
                }
            }

            if (rainExceedanceModel.StartMonth != null || rainExceedanceModel.StartDay != null || rainExceedanceModel.EndMonth != null || rainExceedanceModel.EndDay != null)
            {
                return string.Format(ServiceRes.PleaseEnterValidFor_, ServiceRes.StartMonth + ",", ServiceRes.StartDay + ",", ServiceRes.EndDay + ",", ServiceRes.EndDay);
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
                                                                 let stakeholdersEmailDistributionListName = (from t in db.TVItems
                                                                                                              from tl in db.TVItemLanguages
                                                                                                              where t.TVItemID == tl.TVItemID
                                                                                                              && tl.Language == (int)LanguageRequest
                                                                                                              && t.TVItemID == c.StakeholdersEmailDistributionListID
                                                                                                              select tl.TVText).FirstOrDefault()
                                                                 let onlyStaffEmailDistributionListName = (from t in db.TVItems
                                                                                                           from tl in db.TVItemLanguages
                                                                                                           where t.TVItemID == tl.TVItemID
                                                                                                           && tl.Language == (int)LanguageRequest
                                                                                                           && t.TVItemID == c.OnlyStaffEmailDistributionListID
                                                                                                           select tl.TVText).FirstOrDefault()
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
                                                       let stakeholdersEmailDistributionListName = (from t in db.TVItems
                                                                                                    from tl in db.TVItemLanguages
                                                                                                    where t.TVItemID == tl.TVItemID
                                                                                                    && tl.Language == (int)LanguageRequest
                                                                                                    && t.TVItemID == c.StakeholdersEmailDistributionListID
                                                                                                    select tl.TVText).FirstOrDefault()
                                                       let onlyStaffEmailDistributionListName = (from t in db.TVItems
                                                                                                 from tl in db.TVItemLanguages
                                                                                                 where t.TVItemID == tl.TVItemID
                                                                                                 && tl.Language == (int)LanguageRequest
                                                                                                 && t.TVItemID == c.OnlyStaffEmailDistributionListID
                                                                                                 select tl.TVText).FirstOrDefault()
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
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<RainExceedanceModel>();

            if (rainExceedanceModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.RainExceedance, ServiceRes.RainExceedanceID, RainExceedanceID));

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
            float TempFloat = 0.0f;
            int RainExceedanceID = 0;
            int RainExceedanceTVItemID = 0;
            int? StartMonth = null;
            int? StartDay = null;
            int? EndMonth = null;
            int? EndDay = null;
            float? RainMaximum_mm = 0.0f;
            int? StakeholdersEmailDistributionListID = null;
            int? OnlyStaffEmailDistributionListID = null;

            int.TryParse(fc["RainExceedanceID"], out RainExceedanceID);
            // if 0 then want to add new SamplingPlan else want to modify

            int.TryParse(fc["RainExceedanceTVItemID"], out RainExceedanceTVItemID);
            if (RainExceedanceTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.RainExceedanceTVItemID));

            int.TryParse(fc["StartMonth"], out TempInt);
            if (TempInt != 0)
            {
                StartMonth = TempInt;
            }

            int.TryParse(fc["StartDay"], out TempInt);
            if (TempInt != 0)
            {
                StartDay = TempInt;
            }

            int.TryParse(fc["EndMonth"], out TempInt);
            if (TempInt != 0)
            {
                EndMonth = TempInt;
            }

            int.TryParse(fc["EndDay"], out TempInt);
            if (TempInt != 0)
            {
                EndDay = TempInt;
            }

            float.TryParse(fc["RainMaximum_mm"], out TempFloat);
            RainMaximum_mm = TempFloat;
            if (RainMaximum_mm == 0.0f)
            {
                RainMaximum_mm = null;
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

            RainExceedanceModel RainExceedanceModelRet = new RainExceedanceModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (RainExceedanceID == 0)
                {
                    RainExceedanceModel RainExceedanceModelNew = new RainExceedanceModel()
                    {
                        RainExceedanceTVItemID = RainExceedanceTVItemID,
                        StartMonth = StartMonth,
                        StartDay = StartDay,
                        EndMonth = EndMonth,
                        EndDay = EndDay,
                        RainMaximum_mm = RainMaximum_mm,
                        StakeholdersEmailDistributionListID = StakeholdersEmailDistributionListID,
                        OnlyStaffEmailDistributionListID = OnlyStaffEmailDistributionListID,
                    };

                    RainExceedanceModelRet = PostAddRainExceedanceDB(RainExceedanceModelNew);
                    if (!string.IsNullOrWhiteSpace(RainExceedanceModelRet.Error))
                        ReturnError(RainExceedanceModelRet.Error);

                }
                else
                {
                    RainExceedanceModel RainExceedanceModelToUpdate = GetRainExceedanceModelWithRainExceedanceIDDB(RainExceedanceID);
                    RainExceedanceModelToUpdate.RainExceedanceTVItemID = RainExceedanceTVItemID;
                    RainExceedanceModelToUpdate.StartMonth = StartMonth;
                    RainExceedanceModelToUpdate.StartDay = StartDay;
                    RainExceedanceModelToUpdate.EndMonth = EndMonth;
                    RainExceedanceModelToUpdate.EndDay = EndDay;
                    RainExceedanceModelToUpdate.RainMaximum_mm = RainMaximum_mm;
                    RainExceedanceModelToUpdate.StakeholdersEmailDistributionListID = StakeholdersEmailDistributionListID;
                    RainExceedanceModelToUpdate.OnlyStaffEmailDistributionListID = OnlyStaffEmailDistributionListID;

                    RainExceedanceModelRet = PostUpdateRainExceedanceDB(RainExceedanceModelToUpdate);
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
