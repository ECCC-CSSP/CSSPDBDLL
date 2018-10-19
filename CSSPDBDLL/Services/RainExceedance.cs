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
            if (rainExceedanceModel.StartDate_Local != null && rainExceedanceModel.EndDate_Local != null)
            {
                if (rainExceedanceModel.StartDate_Local > rainExceedanceModel.EndDate_Local)
                {
                    return string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDate, ServiceRes.EndDate);
                }
            }

            string retStr = FieldCheckIfNotNullWithinRangeDouble(rainExceedanceModel.RainMaximum_mm, ServiceRes.RainMaximum, 0.0f, 500.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(rainExceedanceModel.RainExtreme_mm, ServiceRes.RainExtreme, 0.0f, 500.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(rainExceedanceModel.DaysPriorToStart, ServiceRes.DaysPriorToStart, 1, 10);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillRainExceedance(RainExceedance rainExceedanceNew, RainExceedanceModel rainExceedanceModel, ContactOK contactOK)
        {
            rainExceedanceNew.YearRound = rainExceedanceModel.YearRound;
            rainExceedanceNew.StartDate_Local = rainExceedanceModel.StartDate_Local;
            rainExceedanceNew.EndDate_Local = rainExceedanceModel.EndDate_Local;
            rainExceedanceNew.RainMaximum_mm = rainExceedanceModel.RainMaximum_mm;
            rainExceedanceNew.RainExtreme_mm = rainExceedanceModel.RainExtreme_mm;
            rainExceedanceNew.DaysPriorToStart = rainExceedanceModel.DaysPriorToStart;
            rainExceedanceNew.RepeatEveryYear = rainExceedanceModel.RepeatEveryYear;
            rainExceedanceNew.ProvinceTVItemIDs = rainExceedanceModel.ProvinceTVItemIDs;
            rainExceedanceNew.SubsectorTVItemIDs = rainExceedanceModel.SubsectorTVItemIDs;
            rainExceedanceNew.ClimateSiteTVItemIDs = rainExceedanceModel.ClimateSiteTVItemIDs;
            rainExceedanceNew.EmailDistributionListIDs = rainExceedanceModel.EmailDistributionListIDs;
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
                                                                 orderby c.StartDate_Local
                                                                 select new RainExceedanceModel
                                                                 {
                                                                     Error = "",
                                                                     RainExceedanceID = c.RainExceedanceID,
                                                                     YearRound = c.YearRound,
                                                                     StartDate_Local = c.StartDate_Local,
                                                                     EndDate_Local = c.EndDate_Local,
                                                                     RainMaximum_mm = (float)c.RainMaximum_mm,
                                                                     RainExtreme_mm = (float)c.RainExtreme_mm,
                                                                     DaysPriorToStart = c.DaysPriorToStart,
                                                                     RepeatEveryYear = c.RepeatEveryYear,
                                                                     ProvinceTVItemIDs = c.ProvinceTVItemIDs,
                                                                     SubsectorTVItemIDs = c.SubsectorTVItemIDs,
                                                                     ClimateSiteTVItemIDs = c.ClimateSiteTVItemIDs,
                                                                     EmailDistributionListIDs = c.EmailDistributionListIDs,
                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                 }).ToList<RainExceedanceModel>();

            return RainExceedanceModelList;
        }
        public List<RainExceedanceModel> GetRainExceedanceModelListWithSubsectorTVItemIDDB(List<int> SubsectorTVItemIDs)
        {
            List<RainExceedanceModel> RainExceedanceModelList = (from c in db.RainExceedances
                                                                 from l in SubsectorTVItemIDs
                                                                 where c.SubsectorTVItemIDs.Contains("," + l + ",")
                                                                 orderby c.StartDate_Local
                                                                 select new RainExceedanceModel
                                                                 {
                                                                     Error = "",
                                                                     RainExceedanceID = c.RainExceedanceID,
                                                                     YearRound = c.YearRound,
                                                                     StartDate_Local = c.StartDate_Local,
                                                                     EndDate_Local = c.EndDate_Local,
                                                                     RainMaximum_mm = (float)c.RainMaximum_mm,
                                                                     RainExtreme_mm = (float)c.RainExtreme_mm,
                                                                     DaysPriorToStart = c.DaysPriorToStart,
                                                                     RepeatEveryYear = c.RepeatEveryYear,
                                                                     ProvinceTVItemIDs = c.ProvinceTVItemIDs,
                                                                     SubsectorTVItemIDs = c.SubsectorTVItemIDs,
                                                                     ClimateSiteTVItemIDs = c.ClimateSiteTVItemIDs,
                                                                     EmailDistributionListIDs = c.EmailDistributionListIDs,
                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                 }).ToList<RainExceedanceModel>();

            return RainExceedanceModelList;
        }
        public RainExceedanceModel GetRainExceedanceModelWithRainExceedanceIDDB(int RainExceedanceID)
        {
            RainExceedanceModel rainExceedanceModel = (from c in db.RainExceedances
                                                       where c.RainExceedanceID == RainExceedanceID
                                                       select new RainExceedanceModel
                                                       {
                                                           Error = "",
                                                           RainExceedanceID = c.RainExceedanceID,
                                                           YearRound = c.YearRound,
                                                           StartDate_Local = c.StartDate_Local,
                                                           EndDate_Local = c.EndDate_Local,
                                                           RainMaximum_mm = (float)c.RainMaximum_mm,
                                                           RainExtreme_mm = (float)c.RainExtreme_mm,
                                                           DaysPriorToStart = c.DaysPriorToStart,
                                                           RepeatEveryYear = c.RepeatEveryYear,
                                                           ProvinceTVItemIDs = c.ProvinceTVItemIDs,
                                                           SubsectorTVItemIDs = c.SubsectorTVItemIDs,
                                                           ClimateSiteTVItemIDs = c.ClimateSiteTVItemIDs,
                                                           EmailDistributionListIDs = c.EmailDistributionListIDs,
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
                                             where c.StartDate_Local == rainExceedanceModel.StartDate_Local
                                             && c.EndDate_Local == rainExceedanceModel.EndDate_Local
                                             && c.StartDate_Local == rainExceedanceModel.StartDate_Local
                                             && c.EndDate_Local == rainExceedanceModel.EndDate_Local
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

            float TempFloat = 0.0f;
            int RainExceedanceID = 0;
            bool YearRound = false;
            int SubsectorTVItemID = 0;
            DateTime StartDate_Local = new DateTime(2050, 1, 1);
            DateTime EndDate_Local = new DateTime(2050, 1, 1);
            float? RainMaximum_mm = 0.0f;
            float? RainExtreme_mm = 0.0f;
            int DaysPriorToStart = 0;
            bool RepeatEveryYear = false;
            string ProvinceTVItemIDs = "";
            string SubsectorTVItemIDs = "";
            string ClimateSiteTVItemIDs = "";
            string EmailDistributionListIDs = "";

            int.TryParse(fc["RainExceedanceID"], out RainExceedanceID);
            // if 0 then want to add new SamplingPlan else want to modify

            if (string.IsNullOrWhiteSpace(fc["YearRound"]))
            {
                YearRound = true;
            }

            DateTime.TryParse(fc["StartDate_Local"], out StartDate_Local);
            if (StartDate_Local.Year == 2050)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StartDate));

            DateTime.TryParse(fc["EndDate_Local"], out EndDate_Local);
            if (EndDate_Local.Year == 2050)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EndDate));

            if (StartDate_Local > EndDate_Local)
                return ReturnError(string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDate, ServiceRes.EndDate));

            float.TryParse(fc["RainMaximum_mm"], out TempFloat);
            RainMaximum_mm = TempFloat;
            if (RainMaximum_mm == 0.0f)
            {
                RainMaximum_mm = null;
            }

            float.TryParse(fc["RainExtreme_mm"], out TempFloat);
            RainExtreme_mm = TempFloat;
            if (RainMaximum_mm == 0.0f)
            {
                RainMaximum_mm = null;
            }

            int.TryParse(fc["DaysPriorToStart"], out DaysPriorToStart);
            if (DaysPriorToStart == 0.0f)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.DaysPriorToStart));

            if (string.IsNullOrWhiteSpace(fc["RepeatEveryYear"]))
            {
                RepeatEveryYear = true;
            }

            ProvinceTVItemIDs = fc["ProvinceTVItemIDs"];
            SubsectorTVItemIDs = fc["SubsectorTVItemIDs"];
            ClimateSiteTVItemIDs = fc["ClimateSiteTVItemIDs"];
            EmailDistributionListIDs = fc["EmailDistributionListIDs"];

            RainExceedanceModel RainExceedanceModelRet = new RainExceedanceModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (RainExceedanceID == 0)
                {
                    RainExceedanceModel RainExceedanceModelNew = new RainExceedanceModel()
                    {
                        YearRound = YearRound,
                        StartDate_Local = StartDate_Local,
                        EndDate_Local = EndDate_Local,
                        RainMaximum_mm = RainMaximum_mm,
                        RainExtreme_mm = RainExtreme_mm,
                        DaysPriorToStart = DaysPriorToStart,
                        RepeatEveryYear = RepeatEveryYear,
                        ProvinceTVItemIDs = ProvinceTVItemIDs,
                        SubsectorTVItemIDs = SubsectorTVItemIDs,
                        ClimateSiteTVItemIDs = ClimateSiteTVItemIDs,
                        EmailDistributionListIDs = EmailDistributionListIDs,
                    };

                    RainExceedanceModelRet = PostAddRainExceedanceDB(RainExceedanceModelNew);
                    if (!string.IsNullOrWhiteSpace(RainExceedanceModelRet.Error))
                        ReturnError(RainExceedanceModelRet.Error);

                }
                else
                {
                    RainExceedanceModel RainExceedanceModelToUpdate = GetRainExceedanceModelWithRainExceedanceIDDB(RainExceedanceID);
                    RainExceedanceModelToUpdate.YearRound = YearRound;
                    RainExceedanceModelToUpdate.StartDate_Local = StartDate_Local;
                    RainExceedanceModelToUpdate.EndDate_Local = EndDate_Local;
                    RainExceedanceModelToUpdate.RainMaximum_mm = RainMaximum_mm;
                    RainExceedanceModelToUpdate.RainExtreme_mm = RainExtreme_mm;
                    RainExceedanceModelToUpdate.DaysPriorToStart = DaysPriorToStart;
                    RainExceedanceModelToUpdate.RepeatEveryYear = RepeatEveryYear;
                    RainExceedanceModelToUpdate.ProvinceTVItemIDs = ProvinceTVItemIDs;
                    RainExceedanceModelToUpdate.SubsectorTVItemIDs = SubsectorTVItemIDs;
                    RainExceedanceModelToUpdate.ClimateSiteTVItemIDs = ClimateSiteTVItemIDs;
                    RainExceedanceModelToUpdate.EmailDistributionListIDs = EmailDistributionListIDs;

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
