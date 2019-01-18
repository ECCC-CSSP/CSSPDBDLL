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
    public class DrogueRunService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public AppTaskService _AppTaskService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public DrogueRunService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
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
        public string DrogueRunModelOK(DrogueRunModel drogueRunModel)
        {
            string retStr = FieldCheckNotZeroInt(drogueRunModel.SubsectorTVItemID, ServiceRes.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(drogueRunModel.DrogueNumber, ServiceRes.DrogueNumber, 0, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DrogueTypeOK(drogueRunModel.DrogueType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(drogueRunModel.RunStartDateTime, ServiceRes.RunStartDateTime);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillDrogueRun(DrogueRun drogueRunNew, DrogueRunModel drogueRunModel, ContactOK contactOK)
        {
            drogueRunNew.SubsectorTVItemID = drogueRunModel.SubsectorTVItemID;
            drogueRunNew.DrogueNumber = drogueRunModel.DrogueNumber;
            drogueRunNew.DrogueType = (int)drogueRunModel.DrogueType;
            drogueRunNew.RunStartDateTime = drogueRunModel.RunStartDateTime;
            drogueRunNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                drogueRunNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                drogueRunNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetDrogueRunModelCountDB()
        {
            int DrogueRunModelCount = (from c in db.DrogueRuns
                                       select c).Count();

            return DrogueRunModelCount;
        }
        public DrogueRunModel GetDrogueRunModelWithDrogueRunIDDB(int DrogueRunID)
        {
            DrogueRunModel DrogueRunModel = (from c in db.DrogueRuns
                                             where c.DrogueRunID == DrogueRunID
                                             select new DrogueRunModel
                                             {
                                                 Error = "",
                                                 DrogueRunID = c.DrogueRunID,
                                                 SubsectorTVItemID = c.SubsectorTVItemID,
                                                 DrogueNumber = c.DrogueNumber,
                                                 DrogueType = (DrogueTypeEnum)c.DrogueType,
                                                 RunStartDateTime = c.RunStartDateTime,
                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             }).FirstOrDefault<DrogueRunModel>();

            if (DrogueRunModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DrogueRun, ServiceRes.DrogueRunID, DrogueRunID));

            return DrogueRunModel;
        }
        public List<DrogueRunModel> GetDrogueRunModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<DrogueRunModel> DrogueRunModelList = (from c in db.DrogueRuns
                                                       where c.SubsectorTVItemID == SubsectorTVItemID
                                                       orderby c.DrogueRunID descending
                                                       select new DrogueRunModel
                                                       {
                                                           Error = "",
                                                           DrogueRunID = c.DrogueRunID,
                                                           SubsectorTVItemID = c.SubsectorTVItemID,
                                                           DrogueNumber = c.DrogueNumber,
                                                           DrogueType = (DrogueTypeEnum)c.DrogueType,
                                                           RunStartDateTime = c.RunStartDateTime,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).ToList<DrogueRunModel>();

            return DrogueRunModelList;
        }
        public DrogueRunModel GetDrogueRunModelExistDB(DrogueRunModel drogueRunModel)
        {
            DrogueRunModel DrogueRunModel = (from c in db.DrogueRuns
                                             where c.SubsectorTVItemID == drogueRunModel.SubsectorTVItemID
                                             && c.DrogueNumber == drogueRunModel.DrogueNumber
                                             && c.DrogueType == (int)drogueRunModel.DrogueType
                                             && c.RunStartDateTime == drogueRunModel.RunStartDateTime
                                             select new DrogueRunModel
                                             {
                                                 Error = "",
                                                 DrogueRunID = c.DrogueRunID,
                                                 SubsectorTVItemID = c.SubsectorTVItemID,
                                                 DrogueNumber = c.DrogueNumber,
                                                 DrogueType = (DrogueTypeEnum)c.DrogueType,
                                                 RunStartDateTime = c.RunStartDateTime,
                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             }).FirstOrDefault<DrogueRunModel>();

            if (DrogueRunModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DrogueRun,
                    ServiceRes.SubsectorTVItemID + "," +
                    ServiceRes.DrogueNumber + "," +
                    ServiceRes.DrogueType + "," +
                    ServiceRes.RunStartDateTime,
                    drogueRunModel.SubsectorTVItemID + "," +
                    drogueRunModel.DrogueNumber + "," +
                    drogueRunModel.DrogueType + "," +
                    drogueRunModel.RunStartDateTime));

            return DrogueRunModel;
        }
        public DrogueRun GetDrogueRunWithDrogueRunIDDB(int DrogueRunID)
        {
            DrogueRun DrogueRun = (from c in db.DrogueRuns
                                   where c.DrogueRunID == DrogueRunID
                                   orderby c.DrogueRunID descending
                                   select c).FirstOrDefault<DrogueRun>();
            return DrogueRun;
        }
        public DrogueRunModel ReturnError(string Error)
        {
            return new DrogueRunModel() { Error = Error };
        }

        // Post
        public DrogueRunModel PostAddDrogueRunDB(DrogueRunModel drogueRunModel)
        {
            string retStr = DrogueRunModelOK(drogueRunModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(drogueRunModel.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnError(tvItemModelExist.Error);

            DrogueRunModel DrogueRunModelExist = GetDrogueRunModelExistDB(drogueRunModel);
            if (string.IsNullOrWhiteSpace(DrogueRunModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.DrogueRun));

            DrogueRun drogueRunNew = new DrogueRun();
            retStr = FillDrogueRun(drogueRunNew, drogueRunModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.DrogueRuns.Add(drogueRunNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DrogueRuns", drogueRunNew.DrogueRunID, LogCommandEnum.Add, drogueRunNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetDrogueRunModelWithDrogueRunIDDB(drogueRunNew.DrogueRunID);
        }
        public DrogueRunModel PostDeleteDrogueRunDB(int DrogueRunID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            DrogueRun drogueRunToDelete = GetDrogueRunWithDrogueRunIDDB(DrogueRunID);
            if (drogueRunToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.DrogueRun));

            using (TransactionScope ts = new TransactionScope())
            {
                db.DrogueRuns.Remove(drogueRunToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DrogueRuns", drogueRunToDelete.DrogueRunID, LogCommandEnum.Delete, drogueRunToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public DrogueRunModel PostUpdateDrogueRunDB(DrogueRunModel drogueRunModel)
        {
            string retStr = DrogueRunModelOK(drogueRunModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            DrogueRun drogueRunToUpdate = GetDrogueRunWithDrogueRunIDDB(drogueRunModel.DrogueRunID);
            if (drogueRunToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.DrogueRun));

            retStr = FillDrogueRun(drogueRunToUpdate, drogueRunModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DrogueRuns", drogueRunToUpdate.DrogueRunID, LogCommandEnum.Change, drogueRunToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetDrogueRunModelWithDrogueRunIDDB(drogueRunToUpdate.DrogueRunID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
