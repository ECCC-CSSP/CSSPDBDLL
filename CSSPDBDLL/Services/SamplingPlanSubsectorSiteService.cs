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
    public class SamplingPlanSubsectorSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string SamplingPlanSubsectorSiteModelOK(SamplingPlanSubsectorSiteModel samplingPlanSubsectorSiteModel)
        {
            string retStr = FieldCheckNotZeroInt(samplingPlanSubsectorSiteModel.SamplingPlanSubsectorID, ServiceRes.SamplingPlanSubsectorID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(samplingPlanSubsectorSiteModel.MWQMSiteTVItemID, ServiceRes.MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(samplingPlanSubsectorSiteModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillSamplingPlanSubsectorSite(SamplingPlanSubsectorSite samplingPlanSubsectorSite, SamplingPlanSubsectorSiteModel samplingPlanSubsectorSiteModel, ContactOK contactOK)
        {
            samplingPlanSubsectorSite.DBCommand = (int)samplingPlanSubsectorSiteModel.DBCommand;
            samplingPlanSubsectorSite.SamplingPlanSubsectorID = samplingPlanSubsectorSiteModel.SamplingPlanSubsectorID;
            samplingPlanSubsectorSite.MWQMSiteTVItemID = samplingPlanSubsectorSiteModel.MWQMSiteTVItemID;
            samplingPlanSubsectorSite.IsDuplicate = samplingPlanSubsectorSiteModel.IsDuplicate;
            samplingPlanSubsectorSite.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                samplingPlanSubsectorSite.LastUpdateContactTVItemID = 2;
            }
            else
            {
                samplingPlanSubsectorSite.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetSamplingPlanSubsectorSiteModelCountDB()
        {
            int SamplingPlanSubsectorSiteModelCount = (from c in db.SamplingPlanSubsectorSites
                                                   select c).Count();

            return SamplingPlanSubsectorSiteModelCount;
        }
        public SamplingPlanSubsectorSiteModel GetSamplingPlanSubsectorSiteModelExistDB(SamplingPlanSubsectorSiteModel samplingPlanSubsectorSiteModel)
        {
            SamplingPlanSubsectorSiteModel SamplingPlanSubsectorSiteModelRet = (from c in db.SamplingPlanSubsectorSites
                                                                        let mwqmSiteTVText = (from p in db.TVItemLanguages where c.MWQMSiteTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                                        where c.SamplingPlanSubsectorID == samplingPlanSubsectorSiteModel.SamplingPlanSubsectorID
                                                                        && c.MWQMSiteTVItemID == samplingPlanSubsectorSiteModel.MWQMSiteTVItemID
                                                                        select new SamplingPlanSubsectorSiteModel
                                                                        {
                                                                            Error = "",
                                                                            SamplingPlanSubsectorSiteID = c.SamplingPlanSubsectorSiteID,
                                                                            DBCommand = (DBCommandEnum)c.DBCommand,
                                                                            SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                                                                            MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                            MWQMSiteText = mwqmSiteTVText,
                                                                            IsDuplicate = c.IsDuplicate,
                                                                            LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                            LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                        }).FirstOrDefault<SamplingPlanSubsectorSiteModel>();

            if (SamplingPlanSubsectorSiteModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.SamplingPlanSubsectorSite,
                    ServiceRes.SamplingPlanSubsectorID + "," +
                    ServiceRes.MWQMSiteTVItemID,
                    samplingPlanSubsectorSiteModel.SamplingPlanSubsectorID + "," +
                    samplingPlanSubsectorSiteModel.MWQMSiteTVItemID));

            return SamplingPlanSubsectorSiteModelRet;
        }
        public List<SamplingPlanSubsectorSiteModel> GetSamplingPlanSubsectorSiteModelListWithSamplingPlanSubsectorIDDB(int SamplingPlanSubsectorID)
        {
            List<SamplingPlanSubsectorSiteModel> SamplingPlanSubsectorSiteModelList = (from c in db.SamplingPlanSubsectorSites
                                                                               let mwqmSiteTVText = (from p in db.TVItemLanguages where c.MWQMSiteTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                                               where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                                                                               orderby c.SamplingPlanSubsectorSiteID
                                                                               select new SamplingPlanSubsectorSiteModel
                                                                               {
                                                                                   Error = "",
                                                                                   SamplingPlanSubsectorSiteID = c.SamplingPlanSubsectorSiteID,
                                                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                                                   SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                                                                                   MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                                   MWQMSiteText = mwqmSiteTVText,
                                                                                   IsDuplicate = c.IsDuplicate,
                                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                               }).ToList<SamplingPlanSubsectorSiteModel>();
            
            return SamplingPlanSubsectorSiteModelList;
        }
        public SamplingPlanSubsectorSiteModel GetSamplingPlanSubsectorSiteModelWithSamplingPlanSubsectorSiteIDDB(int SamplingPlanSubsectorSiteID)
        {
            SamplingPlanSubsectorSiteModel SamplingPlanSubsectorSiteModel = (from c in db.SamplingPlanSubsectorSites
                                                                     let mwqmSiteTVText = (from p in db.TVItemLanguages where c.MWQMSiteTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                                     where c.SamplingPlanSubsectorSiteID == SamplingPlanSubsectorSiteID
                                                                     orderby c.SamplingPlanSubsectorSiteID
                                                                     select new SamplingPlanSubsectorSiteModel
                                                                     {
                                                                         Error = "",
                                                                         SamplingPlanSubsectorSiteID = c.SamplingPlanSubsectorSiteID,
                                                                         DBCommand = (DBCommandEnum)c.DBCommand,
                                                                         SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                                                                         MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                         MWQMSiteText = mwqmSiteTVText,
                                                                         IsDuplicate = c.IsDuplicate,
                                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                     }).FirstOrDefault<SamplingPlanSubsectorSiteModel>();

            if (SamplingPlanSubsectorSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.SamplingPlanSubsectorSite, ServiceRes.SamplingPlanSubsectorSiteID, SamplingPlanSubsectorSiteID));

            return SamplingPlanSubsectorSiteModel;
        }
        public SamplingPlanSubsectorSite GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteIDDB(int SamplingPlanSubsectorSiteID)
        {
            SamplingPlanSubsectorSite SamplingPlanSubsectorSite = (from c in db.SamplingPlanSubsectorSites
                                                           where c.SamplingPlanSubsectorSiteID == SamplingPlanSubsectorSiteID
                                                           select c).FirstOrDefault<SamplingPlanSubsectorSite>();

            return SamplingPlanSubsectorSite;
        }

        // Helper
        public SamplingPlanSubsectorSiteModel ReturnError(string Error)
        {
            return new SamplingPlanSubsectorSiteModel() { Error = Error };
        }

        // Post
        public SamplingPlanSubsectorSiteModel PostAddSamplingPlanSubsectorSiteDB(SamplingPlanSubsectorSiteModel samplingPlanSubsectorSiteModel)
        {
            string retStr = SamplingPlanSubsectorSiteModelOK(samplingPlanSubsectorSiteModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlanSubsectorSiteModel SamplingPlanSubsectorSiteModelExist = GetSamplingPlanSubsectorSiteModelExistDB(samplingPlanSubsectorSiteModel);
            if (string.IsNullOrWhiteSpace(SamplingPlanSubsectorSiteModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.SamplingPlanSubsectorSite));

            SamplingPlanSubsectorSite SamplingPlanSubsectorSiteNew = new SamplingPlanSubsectorSite();
            retStr = FillSamplingPlanSubsectorSite(SamplingPlanSubsectorSiteNew, samplingPlanSubsectorSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.SamplingPlanSubsectorSites.Add(SamplingPlanSubsectorSiteNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SamplingPlanSubsectorSites", SamplingPlanSubsectorSiteNew.SamplingPlanSubsectorSiteID, LogCommandEnum.Add, SamplingPlanSubsectorSiteNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetSamplingPlanSubsectorSiteModelWithSamplingPlanSubsectorSiteIDDB(SamplingPlanSubsectorSiteNew.SamplingPlanSubsectorSiteID);
        }
        public SamplingPlanSubsectorSiteModel PostDeleteSamplingPlanSubsectorSiteDB(int SamplingPlanSubsectorSiteID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlanSubsectorSite SamplingPlanSubsectorSiteToDelete = GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteIDDB(SamplingPlanSubsectorSiteID);
            if (SamplingPlanSubsectorSiteToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.SamplingPlanSubsectorSite));

            using (TransactionScope ts = new TransactionScope())
            {
                db.SamplingPlanSubsectorSites.Remove(SamplingPlanSubsectorSiteToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SamplingPlanSubsectorSites", SamplingPlanSubsectorSiteToDelete.SamplingPlanSubsectorSiteID, LogCommandEnum.Delete, SamplingPlanSubsectorSiteToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public SamplingPlanSubsectorSiteModel PostUpdateSamplingPlanSubsectorSiteDB(SamplingPlanSubsectorSiteModel samplingPlanSubsectorSiteModel)
        {
            string retStr = SamplingPlanSubsectorSiteModelOK(samplingPlanSubsectorSiteModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlanSubsectorSite SamplingPlanSubsectorSiteToUpdate = GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteIDDB(samplingPlanSubsectorSiteModel.SamplingPlanSubsectorSiteID);
            if (SamplingPlanSubsectorSiteToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.SamplingPlanSubsectorSite));

            retStr = FillSamplingPlanSubsectorSite(SamplingPlanSubsectorSiteToUpdate, samplingPlanSubsectorSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SamplingPlanSubsectorSites", SamplingPlanSubsectorSiteToUpdate.SamplingPlanSubsectorSiteID, LogCommandEnum.Change, SamplingPlanSubsectorSiteToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetSamplingPlanSubsectorSiteModelWithSamplingPlanSubsectorSiteIDDB(SamplingPlanSubsectorSiteToUpdate.SamplingPlanSubsectorSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
