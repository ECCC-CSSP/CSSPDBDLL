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
    public class VPResultService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public VPResultService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string VPResultModelOK(VPResultModel vpResultModel)
        {
            string retStr = FieldCheckNotZeroInt(vpResultModel.VPScenarioID, ServiceRes.VPScenarioID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(vpResultModel.Ordinal, ServiceRes.Ordinal);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(vpResultModel.Concentration_MPN_100ml, ServiceRes.Concentration_MPN_100ml, 0, 10000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(vpResultModel.Dilution, ServiceRes.Dilution, 1, 1000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(vpResultModel.FarFieldWidth_m, ServiceRes.FarFieldWidth_m, 0, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }
            retStr = FieldCheckNotNullAndWithinRangeDouble(vpResultModel.DispersionDistance_m, ServiceRes.DispersionDistance_m, 0, 50000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }
            retStr = FieldCheckNotNullAndWithinRangeDouble(vpResultModel.TravelTime_hour, ServiceRes.TravelTime_hour, 0, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillVPResult(VPResult vpResult, VPResultModel vpResultModel, ContactOK contactOK)
        {
            vpResult.VPScenarioID = vpResultModel.VPScenarioID;
            vpResult.Ordinal = vpResultModel.Ordinal;
            vpResult.Concentration_MPN_100ml = vpResultModel.Concentration_MPN_100ml;
            vpResult.Dilution = vpResultModel.Dilution;
            vpResult.FarFieldWidth_m = vpResultModel.FarFieldWidth_m;
            vpResult.DispersionDistance_m = vpResultModel.DispersionDistance_m;
            vpResult.TravelTime_hour = vpResultModel.TravelTime_hour;
            vpResult.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                vpResult.LastUpdateContactTVItemID = 2;
            }
            else
            {
                vpResult.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetVPResultModelCountDB()
        {
            int VPResultModelCount = (from c in db.VPResults
                                      select c).Count();

            return VPResultModelCount;
        }
        public List<VPResultModel> GetVPResultModelListWithVPScenarioIDDB(int VPScenarioID)
        {
            List<VPResultModel> VPResultModelList = (from c in db.VPResults
                                                     orderby c.VPScenarioID, c.Ordinal
                                                     select new VPResultModel
                                                     {
                                                         Error = "",
                                                         VPScenarioID = c.VPScenarioID,
                                                         Ordinal = c.Ordinal,
                                                         Concentration_MPN_100ml = c.Concentration_MPN_100ml,
                                                         Dilution = c.Dilution,
                                                         FarFieldWidth_m = c.FarFieldWidth_m,
                                                         DispersionDistance_m = c.DispersionDistance_m,
                                                         TravelTime_hour = c.TravelTime_hour,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).ToList<VPResultModel>();

            return VPResultModelList;
        }
        public VPResultModel GetVPResultModelWithVPScenarioIDAndOrdinalDB(int VPScenarioID, int Ordinal)
        {
            VPResultModel vpResultModel = (from c in db.VPResults
                                           where c.VPScenarioID == VPScenarioID
                                           && c.Ordinal == Ordinal
                                           select new VPResultModel
                                           {
                                               Error = "",
                                               VPResultID = c.VPResultID,
                                               VPScenarioID = c.VPScenarioID,
                                               Ordinal = c.Ordinal,
                                               Concentration_MPN_100ml = c.Concentration_MPN_100ml,
                                               Dilution = c.Dilution,
                                               FarFieldWidth_m = c.FarFieldWidth_m,
                                               DispersionDistance_m = c.DispersionDistance_m,
                                               TravelTime_hour = c.TravelTime_hour,
                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           }).FirstOrDefault<VPResultModel>();

            if (vpResultModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPResult, ServiceRes.VPScenarioID + "," + ServiceRes.Ordinal, VPScenarioID.ToString() + "," + Ordinal));

            return vpResultModel;
        }
        public VPResult GetVPResultWithVPScenarioIDAndOrdinalDB(int VPScenarioID, int Ordinal)
        {
            VPResult vpResult = (from c in db.VPResults
                                 where c.VPScenarioID == VPScenarioID
                                 && c.Ordinal == Ordinal
                                 select c).FirstOrDefault<VPResult>();

            return vpResult;
        }
        public List<VPResult> GetVPResultListWithVPScenarioIDDB(int VPScenarioID)
        {
            List<VPResult> VPResultList = (from c in db.VPResults
                                           where c.VPScenarioID == VPScenarioID
                                           orderby c.VPScenarioID, c.Ordinal
                                           select c).ToList<VPResult>();

            return VPResultList;
        }

        // Helper
        public VPResultModel ReturnError(string Error)
        {
            return new VPResultModel() { Error = Error };
        }

        // Post
        public VPResultModel PostAddVPResultDB(VPResultModel vpResultModel)
        {
            string retStr = VPResultModelOK(vpResultModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            VPResult vpResultExist = GetVPResultWithVPScenarioIDAndOrdinalDB(vpResultModel.VPScenarioID, vpResultModel.Ordinal);
            if (vpResultExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.VPResult));

            VPResult vpResultNew = new VPResult();
            retStr = FillVPResult(vpResultNew, vpResultModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.VPResults.Add(vpResultNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPResults", vpResultNew.VPResultID, LogCommandEnum.Add, vpResultNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetVPResultModelWithVPScenarioIDAndOrdinalDB(vpResultNew.VPScenarioID, vpResultNew.Ordinal);
        }
        public VPResultModel PostDeleteVPResultAllWithVPScenarioIDDB(int VPScenarioID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            List<VPResult> vpResultListToDelete = GetVPResultListWithVPScenarioIDDB(VPScenarioID);
            foreach (VPResult vpResultToDelete in vpResultListToDelete)
            {
                db.VPResults.Remove(vpResultToDelete);

                LogModel logModel = _LogService.PostAddLogForObj("VPResults", vpResultToDelete.VPResultID, LogCommandEnum.Delete, vpResultToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);
            }
            using (TransactionScope ts = new TransactionScope())
            {
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);


                ts.Complete();
            }
            return ReturnError("");
        }
        public VPResultModel PostDeleteVPResultDB(int VPScenarioID, int Ordinal)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            VPResult VPResultToDelete = GetVPResultWithVPScenarioIDAndOrdinalDB(VPScenarioID, Ordinal);
            if (VPResultToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.VPResult));

            using (TransactionScope ts = new TransactionScope())
            {
                db.VPResults.Remove(VPResultToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPResults", VPResultToDelete.VPResultID, LogCommandEnum.Delete, VPResultToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public VPResultModel PostUpdateVPResultDB(VPResultModel vpResultModel)
        {
            string retStr = VPResultModelOK(vpResultModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            VPResult vpResultToUpdate = GetVPResultWithVPScenarioIDAndOrdinalDB(vpResultModel.VPScenarioID, vpResultModel.Ordinal);
            if (vpResultToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.VPResult));

            retStr = FillVPResult(vpResultToUpdate, vpResultModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPResults", vpResultToUpdate.VPResultID, LogCommandEnum.Change, vpResultToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetVPResultModelWithVPScenarioIDAndOrdinalDB(vpResultToUpdate.VPScenarioID, vpResultToUpdate.Ordinal);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
 