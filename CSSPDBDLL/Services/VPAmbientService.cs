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
    public class VPAmbientService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public VPAmbientService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string VPAmbientModelOK(VPAmbientModel vpAmbientModel)
        {
            string retStr = FieldCheckNotZeroInt(vpAmbientModel.VPScenarioID, ServiceRes.VPScenarioID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(vpAmbientModel.Row, ServiceRes.Row, 1, 8);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (vpAmbientModel.MeasurementDepth_m != null)
            {
                retStr = FieldCheckNotNullAndWithinRangeDouble(vpAmbientModel.MeasurementDepth_m, ServiceRes.MeasurementDepth_m, 0, 1000);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (vpAmbientModel.CurrentSpeed_m_s != null)
            {
                retStr = FieldCheckNotNullAndWithinRangeDouble(vpAmbientModel.CurrentSpeed_m_s, ServiceRes.CurrentSpeed_m_s, 0, 10);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (vpAmbientModel.CurrentDirection_deg != null)
            {
                retStr = FieldCheckNotNullAndWithinRangeDouble(vpAmbientModel.CurrentDirection_deg, ServiceRes.CurrentDirection_deg, 0, 360);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (vpAmbientModel.AmbientSalinity_PSU != null)
            {
                retStr = FieldCheckNotNullAndWithinRangeDouble(vpAmbientModel.AmbientSalinity_PSU, ServiceRes.AmbientSalinity_PSU, 0, 35);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (vpAmbientModel.AmbientTemperature_C != null)
            {
                retStr = FieldCheckNotNullAndWithinRangeDouble(vpAmbientModel.AmbientTemperature_C, ServiceRes.AmbientTemperature_C, 0, 35);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (vpAmbientModel.BackgroundConcentration_MPN_100ml != null)
            {
                retStr = FieldCheckNotNullAndWithinRangeInt(vpAmbientModel.BackgroundConcentration_MPN_100ml, ServiceRes.BackgroundConcentration_MPN_100ml, 0, 10000000);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (vpAmbientModel.PollutantDecayRate_per_day != null)
            {
                retStr = FieldCheckNotNullAndWithinRangeDouble(vpAmbientModel.PollutantDecayRate_per_day, ServiceRes.PollutantDecayRate_per_day, 0, 100);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (vpAmbientModel.FarFieldCurrentSpeed_m_s != null)
            {
                retStr = FieldCheckNotNullAndWithinRangeDouble(vpAmbientModel.FarFieldCurrentSpeed_m_s, ServiceRes.FarFieldCurrentSpeed_m_s, 0, 10);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (vpAmbientModel.FarFieldCurrentDirection_deg != null)
            {
                retStr = FieldCheckNotNullAndWithinRangeDouble(vpAmbientModel.FarFieldCurrentDirection_deg, ServiceRes.FarFieldCurrentDirection_deg, 0, 360);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (vpAmbientModel.FarFieldDiffusionCoefficient != null)
            {
                retStr = FieldCheckNotNullAndWithinRangeDouble(vpAmbientModel.FarFieldDiffusionCoefficient, ServiceRes.FarFieldDiffusionCoefficient, 0, 2);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            retStr = _BaseEnumService.DBCommandOK(vpAmbientModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillVPAmbient(VPAmbient vpAmbient, VPAmbientModel vpAmbientModel, ContactOK contactOK)
        {
            vpAmbient.DBCommand = (int)vpAmbientModel.DBCommand;
            vpAmbient.VPScenarioID = vpAmbientModel.VPScenarioID;
            vpAmbient.Row = vpAmbientModel.Row;
            vpAmbient.MeasurementDepth_m = vpAmbientModel.MeasurementDepth_m;
            vpAmbient.CurrentSpeed_m_s = vpAmbientModel.CurrentSpeed_m_s;
            vpAmbient.CurrentDirection_deg = vpAmbientModel.CurrentDirection_deg;
            vpAmbient.AmbientSalinity_PSU = vpAmbientModel.AmbientSalinity_PSU;
            vpAmbient.AmbientTemperature_C = vpAmbientModel.AmbientTemperature_C;
            vpAmbient.BackgroundConcentration_MPN_100ml = vpAmbientModel.BackgroundConcentration_MPN_100ml;
            vpAmbient.PollutantDecayRate_per_day = vpAmbientModel.PollutantDecayRate_per_day;
            vpAmbient.FarFieldCurrentSpeed_m_s = vpAmbientModel.FarFieldCurrentSpeed_m_s;
            vpAmbient.FarFieldCurrentDirection_deg = vpAmbientModel.FarFieldCurrentDirection_deg;
            vpAmbient.FarFieldDiffusionCoefficient = vpAmbientModel.FarFieldDiffusionCoefficient;
            vpAmbient.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                vpAmbient.LastUpdateContactTVItemID = 2;
            }
            else
            {
                vpAmbient.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetVPAmbientModelCountDB()
        {
            int VPAmbientModelCount = (from c in db.VPAmbients
                                       select c).Count();

            return VPAmbientModelCount;
        }
        public List<VPAmbientModel> GetVPAmbientModelListWithVPScenarioIDDB(int VPScenarioID)
        {
            List<VPAmbientModel> VPAmbientModelList = (from c in db.VPAmbients
                                                       where c.VPScenarioID == VPScenarioID
                                                       orderby c.VPScenarioID, c.Row
                                                       select new VPAmbientModel
                                                       {
                                                           Error = "",
                                                           VPScenarioID = c.VPScenarioID,
                                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                                           Row = c.Row,
                                                           MeasurementDepth_m = c.MeasurementDepth_m,
                                                           CurrentSpeed_m_s = c.CurrentSpeed_m_s,
                                                           CurrentDirection_deg = c.CurrentDirection_deg,
                                                           AmbientSalinity_PSU = c.AmbientSalinity_PSU,
                                                           AmbientTemperature_C = c.AmbientTemperature_C,
                                                           BackgroundConcentration_MPN_100ml = c.BackgroundConcentration_MPN_100ml,
                                                           PollutantDecayRate_per_day = c.PollutantDecayRate_per_day,
                                                           FarFieldCurrentSpeed_m_s = c.FarFieldCurrentSpeed_m_s,
                                                           FarFieldCurrentDirection_deg = c.FarFieldCurrentDirection_deg,
                                                           FarFieldDiffusionCoefficient = c.FarFieldDiffusionCoefficient,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).ToList<VPAmbientModel>();

            return VPAmbientModelList;
        }
        public VPAmbientModel GetVPAmbientModelWithVPScenarioIDAndRowDB(int VPScenarioID, int Row)
        {
            VPAmbientModel vpAmbientModel = (from c in db.VPAmbients
                                             where c.VPScenarioID == VPScenarioID
                                             && c.Row == Row
                                             select new VPAmbientModel
                                             {
                                                 Error = "",
                                                 VPAmbientID = c.VPAmbientID,
                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                 VPScenarioID = c.VPScenarioID,
                                                 Row = c.Row,
                                                 MeasurementDepth_m = c.MeasurementDepth_m,
                                                 CurrentSpeed_m_s = c.CurrentSpeed_m_s,
                                                 CurrentDirection_deg = c.CurrentDirection_deg,
                                                 AmbientSalinity_PSU = c.AmbientSalinity_PSU,
                                                 AmbientTemperature_C = c.AmbientTemperature_C,
                                                 BackgroundConcentration_MPN_100ml = c.BackgroundConcentration_MPN_100ml,
                                                 PollutantDecayRate_per_day = c.PollutantDecayRate_per_day,
                                                 FarFieldCurrentSpeed_m_s = c.FarFieldCurrentSpeed_m_s,
                                                 FarFieldCurrentDirection_deg = c.FarFieldCurrentDirection_deg,
                                                 FarFieldDiffusionCoefficient = c.FarFieldDiffusionCoefficient,
                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             }).FirstOrDefault<VPAmbientModel>();

            if (vpAmbientModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPAmbient, ServiceRes.VPScenarioID + "," + ServiceRes.Row, VPScenarioID.ToString() + "," + Row));

            return vpAmbientModel;
        }
        public VPAmbient GetVPAmbientWithVPScenarioIDAndRowDB(int VPScenarioID, int Row)
        {
            VPAmbient vpAmbient = (from c in db.VPAmbients
                                   where c.VPScenarioID == VPScenarioID
                                   && c.Row == Row
                                   select c).FirstOrDefault<VPAmbient>();

            return vpAmbient;
        }

        // Helper
        public VPAmbientModel ReturnError(string Error)
        {
            return new VPAmbientModel() { Error = Error };
        }

        // Post
        public VPAmbientModel PostAddVPAmbientDB(VPAmbientModel vpAmbientModel)
        {
            string retStr = VPAmbientModelOK(vpAmbientModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            VPAmbient vpAmbientExist = GetVPAmbientWithVPScenarioIDAndRowDB(vpAmbientModel.VPScenarioID, vpAmbientModel.Row);
            if (vpAmbientExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.VPAmbient));

            VPAmbient vpAmbientNew = new VPAmbient();
            retStr = FillVPAmbient(vpAmbientNew, vpAmbientModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.VPAmbients.Add(vpAmbientNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPAmbients", vpAmbientNew.VPAmbientID, LogCommandEnum.Add, vpAmbientNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetVPAmbientModelWithVPScenarioIDAndRowDB(vpAmbientNew.VPScenarioID, vpAmbientNew.Row);
        }
        public VPAmbientModel PostDeleteVPAmbientDB(int VPScenarioID, int Row)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            VPAmbient vpAmbientToDelete = GetVPAmbientWithVPScenarioIDAndRowDB(VPScenarioID, Row);
            if (vpAmbientToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.VPAmbient));

            using (TransactionScope ts = new TransactionScope())
            {
                db.VPAmbients.Remove(vpAmbientToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPAmbients", vpAmbientToDelete.VPAmbientID, LogCommandEnum.Delete, vpAmbientToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public VPAmbientModel PostUpdateVPAmbientDB(VPAmbientModel vpAmbientModel)
        {
            string retStr = VPAmbientModelOK(vpAmbientModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            VPAmbient vpAmbientToUpdate = GetVPAmbientWithVPScenarioIDAndRowDB(vpAmbientModel.VPScenarioID, vpAmbientModel.Row);
            if (vpAmbientToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.VPAmbient));

            retStr = FillVPAmbient(vpAmbientToUpdate, vpAmbientModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPAmbients", vpAmbientToUpdate.VPAmbientID, LogCommandEnum.Change, vpAmbientToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetVPAmbientModelWithVPScenarioIDAndRowDB(vpAmbientToUpdate.VPScenarioID, vpAmbientToUpdate.Row);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
