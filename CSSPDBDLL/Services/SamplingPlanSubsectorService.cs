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
    public class SamplingPlanSubsectorService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string SamplingPlanSubsectorModelOK(SamplingPlanSubsectorModel samplingPlanSubsectorModel)
        {
            string retStr = FieldCheckNotZeroInt(samplingPlanSubsectorModel.SamplingPlanID, ServiceRes.SamplingPlanID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(samplingPlanSubsectorModel.SubsectorTVItemID, ServiceRes.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(samplingPlanSubsectorModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillSamplingPlanSubsector(SamplingPlanSubsector samplingPlanSubsector, SamplingPlanSubsectorModel samplingPlanSubsectorModel, ContactOK contactOK)
        {
            samplingPlanSubsector.DBCommand = (int)samplingPlanSubsectorModel.DBCommand;
            samplingPlanSubsector.SamplingPlanID = samplingPlanSubsectorModel.SamplingPlanID;
            samplingPlanSubsector.SubsectorTVItemID = samplingPlanSubsectorModel.SubsectorTVItemID;
            samplingPlanSubsector.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                samplingPlanSubsector.LastUpdateContactTVItemID = 2;
            }
            else
            {
                samplingPlanSubsector.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetSamplingPlanSubsectorModelCountDB()
        {
            int SamplingPlanSubsectorModelCount = (from c in db.SamplingPlanSubsectors
                                               select c).Count();

            return SamplingPlanSubsectorModelCount;
        }
        public SamplingPlanSubsectorModel GetSamplingPlanSubsectorModelExistDB(SamplingPlanSubsectorModel SamplingPlanSubsectorModel)
        {
            SamplingPlanSubsectorModel SamplingPlanSubsectorModelRet = (from c in db.SamplingPlanSubsectors
                                                                let subsectorTVText = (from p in db.TVItemLanguages where c.SubsectorTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                                let siteCount = (from p in db.SamplingPlanSubsectorSites where c.SamplingPlanSubsectorID == p.SamplingPlanSubsectorID select p).Count()
                                                                where c.SamplingPlanID == SamplingPlanSubsectorModel.SamplingPlanID
                                                                && c.SubsectorTVItemID == SamplingPlanSubsectorModel.SubsectorTVItemID
                                                                select new SamplingPlanSubsectorModel
                                                                {
                                                                    Error = "",
                                                                    SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                                                                    DBCommand = (DBCommandEnum)c.DBCommand,
                                                                    SamplingPlanID = c.SamplingPlanID,
                                                                    SubsectorTVItemID = c.SubsectorTVItemID,
                                                                    SubsectorTVText = subsectorTVText,
                                                                    SiteCount = siteCount,
                                                                    LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                    LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                }).FirstOrDefault<SamplingPlanSubsectorModel>();


            if (SamplingPlanSubsectorModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.SamplingPlanSubsector,
                    ServiceRes.SamplingPlanID + "," +
                    ServiceRes.SubsectorTVItemID,
                    SamplingPlanSubsectorModel.SamplingPlanID.ToString() + "," +
                    SamplingPlanSubsectorModel.SubsectorTVItemID.ToString()));

            return SamplingPlanSubsectorModelRet;
        }
        public List<SamplingPlanSubsectorModel> GetSamplingPlanSubsectorModelListWithSamplingPlanIDDB(int SamplingPlanID)
        {
            List<SamplingPlanSubsectorModel> SamplingPlanSubsectorModelList = (from c in db.SamplingPlanSubsectors
                                                                       let subsectorTVText = (from p in db.TVItemLanguages where c.SubsectorTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                                       let siteCount = (from p in db.SamplingPlanSubsectorSites where c.SamplingPlanSubsectorID == p.SamplingPlanSubsectorID select p).Count()
                                                                       where c.SamplingPlanID == SamplingPlanID
                                                                       orderby c.SamplingPlanSubsectorID
                                                                       select new SamplingPlanSubsectorModel
                                                                       {
                                                                           Error = "",
                                                                           SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                                                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                                                           SamplingPlanID = c.SamplingPlanID,
                                                                           SubsectorTVItemID = c.SubsectorTVItemID,
                                                                           SubsectorTVText = subsectorTVText,
                                                                           SiteCount = siteCount,
                                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                       }).ToList<SamplingPlanSubsectorModel>();

            return SamplingPlanSubsectorModelList;
        }
        public SamplingPlanSubsectorModel GetSamplingPlanSubsectorModelWithSamplingPlanSubsectorIDDB(int SamplingPlanSubsectorID)
        {
            SamplingPlanSubsectorModel SamplingPlanSubsectorModel = (from c in db.SamplingPlanSubsectors
                                                             let subsectorTVText = (from p in db.TVItemLanguages where c.SubsectorTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                             let siteCount = (from p in db.SamplingPlanSubsectorSites where c.SamplingPlanSubsectorID == p.SamplingPlanSubsectorID select p).Count()
                                                             where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                                                             select new SamplingPlanSubsectorModel
                                                             {
                                                                 Error = "",
                                                                 SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                                 SamplingPlanID = c.SamplingPlanID,
                                                                 SubsectorTVItemID = c.SubsectorTVItemID,
                                                                 SubsectorTVText = subsectorTVText,
                                                                 SiteCount = siteCount,
                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                             }).FirstOrDefault<SamplingPlanSubsectorModel>();

            if (SamplingPlanSubsectorModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.SamplingPlanSubsector, ServiceRes.SamplingPlanSubsectorID, SamplingPlanSubsectorID));

            return SamplingPlanSubsectorModel;
        }
        public SamplingPlanSubsectorModel GetSamplingPlanSubsectorModelWithSamplingPlanIDAndSubsectorTVItemIDDB(int SamplingPlanID, int SubsectorTVItemID)
        {
            SamplingPlanSubsectorModel SamplingPlanSubsectorModel = (from c in db.SamplingPlanSubsectors
                                                             let subsectorTVText = (from p in db.TVItemLanguages where c.SubsectorTVItemID == p.TVItemID select p.TVText).FirstOrDefault()
                                                             let siteCount = (from p in db.SamplingPlanSubsectorSites where c.SamplingPlanSubsectorID == p.SamplingPlanSubsectorID select p).Count()
                                                             where c.SamplingPlanID == SamplingPlanID
                                                             && c.SubsectorTVItemID == SubsectorTVItemID
                                                             select new SamplingPlanSubsectorModel
                                                             {
                                                                 Error = "",
                                                                 SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                                 SamplingPlanID = c.SamplingPlanID,
                                                                 SubsectorTVItemID = c.SubsectorTVItemID,
                                                                 SubsectorTVText = subsectorTVText,
                                                                 SiteCount = siteCount,
                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                             }).FirstOrDefault<SamplingPlanSubsectorModel>();

            if (SamplingPlanSubsectorModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.SamplingPlanSubsector, ServiceRes.SamplingPlanID + "," + ServiceRes.SubsectorTVItemID, SamplingPlanID + "," + SubsectorTVItemID));

            return SamplingPlanSubsectorModel;
        }
        public SamplingPlanSubsector GetSamplingPlanSubsectorWithSamplingPlanSubsectorIDDB(int SamplingPlanSubsectorID)
        {
            SamplingPlanSubsector SamplingPlanSubsector = (from c in db.SamplingPlanSubsectors
                                                   where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                                                   select c).FirstOrDefault<SamplingPlanSubsector>();

            return SamplingPlanSubsector;
        }

        // Helper
        public SamplingPlanSubsectorModel ReturnError(string Error)
        {
            return new SamplingPlanSubsectorModel() { Error = Error };
        }

        // Post
        public SamplingPlanSubsectorModel PostAddSamplingPlanSubsectorDB(SamplingPlanSubsectorModel SamplingPlanSubsectorModel)
        {
            string retStr = SamplingPlanSubsectorModelOK(SamplingPlanSubsectorModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlanSubsectorModel SamplingPlanSubsectorModelExist = GetSamplingPlanSubsectorModelExistDB(SamplingPlanSubsectorModel);
            if (string.IsNullOrWhiteSpace(SamplingPlanSubsectorModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.SamplingPlanSubsector));

            SamplingPlanSubsector SamplingPlanSubsectorNew = new SamplingPlanSubsector();
            retStr = FillSamplingPlanSubsector(SamplingPlanSubsectorNew, SamplingPlanSubsectorModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.SamplingPlanSubsectors.Add(SamplingPlanSubsectorNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SamplingPlanSubsectors", SamplingPlanSubsectorNew.SamplingPlanSubsectorID, LogCommandEnum.Add, SamplingPlanSubsectorNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetSamplingPlanSubsectorModelWithSamplingPlanSubsectorIDDB(SamplingPlanSubsectorNew.SamplingPlanSubsectorID);
        }
        public SamplingPlanSubsectorModel PostDeleteSamplingPlanSubsectorDB(int SamplingPlanSubsectorID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlanSubsector SamplingPlanSubsectorToDelete = GetSamplingPlanSubsectorWithSamplingPlanSubsectorIDDB(SamplingPlanSubsectorID);
            if (SamplingPlanSubsectorToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.SamplingPlanSubsector));

            using (TransactionScope ts = new TransactionScope())
            {
                db.SamplingPlanSubsectors.Remove(SamplingPlanSubsectorToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SamplingPlanSubsectors", SamplingPlanSubsectorToDelete.SamplingPlanSubsectorID, LogCommandEnum.Delete, SamplingPlanSubsectorToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public SamplingPlanSubsectorModel PostUpdateSamplingPlanSubsectorDB(SamplingPlanSubsectorModel SamplingPlanSubsectorModel)
        {
            string retStr = SamplingPlanSubsectorModelOK(SamplingPlanSubsectorModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlanSubsector SamplingPlanSubsectorToUpdate = GetSamplingPlanSubsectorWithSamplingPlanSubsectorIDDB(SamplingPlanSubsectorModel.SamplingPlanSubsectorID);
            if (SamplingPlanSubsectorToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.SamplingPlanSubsector));

            retStr = FillSamplingPlanSubsector(SamplingPlanSubsectorToUpdate, SamplingPlanSubsectorModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SamplingPlanSubsectors", SamplingPlanSubsectorToUpdate.SamplingPlanSubsectorID, LogCommandEnum.Change, SamplingPlanSubsectorToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetSamplingPlanSubsectorModelWithSamplingPlanSubsectorIDDB(SamplingPlanSubsectorToUpdate.SamplingPlanSubsectorID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
